Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms

''' <summary>
''' Sistema centralizado de captura, almacenamiento y traducción amigable de errores.
''' Registra todo fallo en disco para depuración y muestra explicaciones comprensibles al usuario.
''' </summary>
Public NotInheritable Class RegistroErrores

    Private Shared ReadOnly SyncLockObj As New Object()
    Private Shared _ultimoHashError As String = String.Empty
    Private Shared _ultimaFechaDialogo As DateTime = DateTime.MinValue
    Private Shared _ultimaDepuracionLogs As DateTime = DateTime.MinValue

    Private Sub New()
    End Sub

    ''' <summary>
    ''' Carpeta persistente y siempre escribible donde se guardan los registros de depuración.
    ''' </summary>
    Public Shared Function ObtenerCarpetaLogs() As String
        Dim baseLocal As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        If String.IsNullOrWhiteSpace(baseLocal) Then
            baseLocal = AppDomain.CurrentDomain.BaseDirectory
        End If
        Dim carpeta As String = Path.Combine(baseLocal, "SistemaMantencion", "logs")
        Try
            If Not Directory.Exists(carpeta) Then
                Directory.CreateDirectory(carpeta)
            End If
        Catch
            carpeta = Path.Combine(Path.GetTempPath(), "SistemaMantencion_logs")
            Try
                If Not Directory.Exists(carpeta) Then Directory.CreateDirectory(carpeta)
            Catch
            End Try
        End Try
        Return carpeta
    End Function

    ''' <summary>
    ''' Ruta del archivo de registro diario correspondiente a la fecha actual.
    ''' </summary>
    Public Shared Function ObtenerRutaLogActual() As String
        Return Path.Combine(ObtenerCarpetaLogs(), "errores_" & DateTime.Now.ToString("yyyyMMdd") & ".log")
    End Function

    ''' <summary>
    ''' Detecta si la excepción corresponde a un fallo de red, resolución DNS, puerto o instancia SQL Server.
    ''' </summary>
    Public Shared Function EsErrorDeConexionSql(ByVal ex As Exception) As Boolean
        Dim sqlEx As SqlException = BuscarSqlException(ex)
        If sqlEx IsNot Nothing Then
            For Each err As SqlError In sqlEx.Errors
                Select Case err.Number
                    Case -1, -2, 2, 40, 53, 233, 258, 10053, 10054, 10060, 10061, 11001, 11004
                        Return True
                End Select
            Next
        End If

        Dim texto As String = ObtenerMensajesEncadenados(ex).ToLowerInvariant()
        Return texto.Contains("named pipes provider") OrElse
               texto.Contains("tcp provider") OrElse
               texto.Contains("network-related") OrElse
               texto.Contains("server was not found") OrElse
               texto.Contains("could not open a connection") OrElse
               texto.Contains("error: 40") OrElse
               texto.Contains("error: 26") OrElse
               texto.Contains("connection timeout") OrElse
               texto.Contains("timeout expired") OrElse
               texto.Contains("no such host") OrElse
               texto.Contains("connection refused")
    End Function

    ''' <summary>
    ''' Guarda el detalle completo del error en disco para depuración y reparación.
    ''' </summary>
    Public Shared Function RegistrarError(ByVal ex As Exception, Optional ByVal contexto As String = "General", Optional ByVal detalleExtra As String = "") As String
        Dim rutaLog As String = ObtenerRutaLogActual()
        Try
            Dim infoSql As String = ObtenerResumenServidorSeguro()
            Dim usuarioSistema As String = ObtenerUsuarioActivo()

            Dim sb As New StringBuilder()
            sb.AppendLine("================================================================================")
            sb.AppendFormat("[{0:yyyy-MM-dd HH:mm:ss.fff}] ERROR CAPTURADO - Módulo: {1}{2}", DateTime.Now, If(String.IsNullOrWhiteSpace(contexto), "General", contexto), Environment.NewLine)
            sb.AppendFormat("Equipo: {0} | Usuario SO: {1} | Usuario App: {2}{3}", Environment.MachineName, Environment.UserName, usuarioSistema, Environment.NewLine)
            sb.AppendFormat("SO: {0} | Arq: {1} | .NET: {2}{3}", RuntimeInformation.OSDescription, RuntimeInformation.ProcessArchitecture, Environment.Version, Environment.NewLine)
            sb.AppendFormat("Destino SQL: {0}{1}", infoSql, Environment.NewLine)
            If Not String.IsNullOrWhiteSpace(detalleExtra) Then
                sb.AppendFormat("Detalle adicional: {0}{1}", detalleExtra, Environment.NewLine)
            End If

            Dim actual As Exception = ex
            Dim nivel As Integer = 0
            While actual IsNot Nothing
                Dim prefijo As String = If(nivel = 0, "Excepción", "Excepción Interna #" & nivel.ToString())
                sb.AppendFormat("{0}: {1} (HResult=0x{2:X8}){3}", prefijo, actual.GetType().FullName, actual.HResult, Environment.NewLine)
                sb.AppendFormat("Mensaje: {0}{1}", actual.Message, Environment.NewLine)

                Dim sqlEx = TryCast(actual, SqlException)
                If sqlEx IsNot Nothing Then
                    sb.AppendFormat("SqlException Number={0}, State={1}, Class={2}, Server='{3}', Procedure='{4}', Line={5}{6}",
                                    sqlEx.Number, sqlEx.State, sqlEx.Class, sqlEx.Server, sqlEx.Procedure, sqlEx.LineNumber, Environment.NewLine)
                    For Each err As SqlError In sqlEx.Errors
                        sb.AppendFormat("  -> SqlError #{0}: {1} (Proc: {2}, Línea: {3}){4}", err.Number, err.Message, err.Procedure, err.LineNumber, Environment.NewLine)
                    Next
                End If

                If Not String.IsNullOrWhiteSpace(actual.StackTrace) Then
                    sb.AppendLine("StackTrace:")
                    sb.AppendLine(actual.StackTrace)
                End If

                actual = actual.InnerException
                nivel += 1
            End While
            sb.AppendLine()

            Dim textoLog As String = sb.ToString()
            SyncLock SyncLockObj
                File.AppendAllText(rutaLog, textoLog, Encoding.UTF8)
                If (DateTime.UtcNow - _ultimaDepuracionLogs).TotalHours >= 6.0R Then
                    _ultimaDepuracionLogs = DateTime.UtcNow
                    DepurarLogsAntiguos(ObtenerCarpetaLogs())
                End If

                ' Copia best-effort en la carpeta de la aplicación si tiene permisos de escritura
                Try
                    Dim dirAppLogs As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs")
                    If Not Directory.Exists(dirAppLogs) Then Directory.CreateDirectory(dirAppLogs)
                    Dim rutaAppLog As String = Path.Combine(dirAppLogs, Path.GetFileName(rutaLog))
                    File.AppendAllText(rutaAppLog, textoLog, Encoding.UTF8)
                Catch
                End Try
            End SyncLock
        Catch
        End Try
        Return rutaLog
    End Function

    ''' <summary>
    ''' Traduce una excepción técnica a un mensaje claro y entendible en español indicando causa y solución.
    ''' </summary>
    Public Shared Function FormatearMensajeAmigable(ByVal ex As Exception, ByVal contexto As String, ByVal rutaLog As String) As (Titulo As String, Mensaje As String, EsErrorRedSql As Boolean, Icono As MessageBoxIcon)
        Dim servidor As String = "SrvMagicInfo"
        Dim baseDatos As String = "mantencion"
        Try
            Dim builder = Conexion.ObtenerParametrosActuales()
            If builder IsNot Nothing Then
                If Not String.IsNullOrWhiteSpace(builder.DataSource) Then servidor = builder.DataSource
                If Not String.IsNullOrWhiteSpace(builder.InitialCatalog) Then baseDatos = builder.InitialCatalog
            End If
        Catch
        End Try

        Dim sqlEx As SqlException = BuscarSqlException(ex)
        Dim msgLower As String = ObtenerMensajesEncadenados(ex).ToLowerInvariant()
        Dim rutaAviso As String = Environment.NewLine & Environment.NewLine & "Registro guardado para diagnóstico:" & Environment.NewLine & rutaLog

        ' 1. Errores de red / instancia / Named Pipes / Timeout SQL
        If EsErrorDeConexionSql(ex) Then
            Dim esTimeout As Boolean = (sqlEx IsNot Nothing AndAlso sqlEx.Number = -2) OrElse msgLower.Contains("timeout")
            If esTimeout Then
                Dim msgTimeout As String = String.Format(
                    "El servidor de base de datos '{0}' (BD '{1}') tardó demasiado en responder y se agotó el tiempo de espera.{2}{2}" &
                    "¿Por qué ocurre esto?{2}" &
                    "• La red corporativa o VPN está lenta o inestable.{2}" &
                    "• El servidor SQL Server está temporalmente sobrecargado.{2}{2}" &
                    "Qué puede hacer:{2}" &
                    "• Verifique su conexión de red/VPN e intente nuevamente, o aumente el Timeout en Configuración de Servidor SQL.{3}",
                    servidor, baseDatos, Environment.NewLine, rutaAviso)
                Return ("Tiempo de Espera Agotado (SQL Server)", msgTimeout, True, MessageBoxIcon.Warning)
            End If

            Dim msgRed As String = String.Format(
                "No se pudo conectar con el servidor SQL Server '{0}' (Base de datos: '{1}').{2}{2}" &
                "¿Por qué aparece este mensaje?{2}" &
                "• Su equipo no tiene acceso en este momento a la red interna de la empresa o la VPN está desconectada.{2}" &
                "• El nombre o dirección del servidor '{0}' no responde o no se resuelve en su red (en Mac o fuera de oficina suele requerirse la IP directa del servidor, ej. 192.168.x.x).{2}" &
                "• El servicio SQL Server está detenido o el firewall bloquea el puerto 1433.{2}{2}" &
                "¿Cómo solucionarlo?{2}" &
                "• Verifique que esté conectado a la red/VPN corporativa.{2}" &
                "• Revise o cambie el servidor/IP en 'Configuración de Servidor SQL'.{3}",
                servidor, baseDatos, Environment.NewLine, rutaAviso)
            Return ("Sin Conexión con SQL Server", msgRed, True, MessageBoxIcon.Warning)
        End If

        ' 2. Otros códigos específicos de SQL Server
        If sqlEx IsNot Nothing Then
            Select Case sqlEx.Number
                Case 18456
                    Return ("Credenciales de Base de Datos Incorrectas",
                            String.Format("El servidor '{0}' rechazó el acceso porque el usuario o contraseña configurados para SQL Server no son válidos.{1}{1}Revise la configuración en 'Configurar Servidor de Base de Datos'.{2}",
                                          servidor, Environment.NewLine, rutaAviso),
                            True, MessageBoxIcon.Error)
                Case 4060
                    Return ("Base de Datos No Disponible",
                            String.Format("Se alcanzó el servidor '{0}', pero no fue posible abrir la base de datos '{1}' (puede no existir o faltarle permisos al usuario SQL).{2}",
                                          servidor, baseDatos, rutaAviso),
                            True, MessageBoxIcon.Error)
                Case 2627, 2601
                    Return ("Registro Duplicado",
                            String.Format("No se pudo guardar en '{0}' porque ya existe un registro con el mismo código o identificador único.{1}",
                                          contexto, rutaAviso),
                            False, MessageBoxIcon.Warning)
                Case 547
                    Return ("Registro en Uso",
                            String.Format("No se pudo completar la operación en '{0}' porque el registro está vinculado a otros datos activos (OTs, máquinas o pautas).{1}",
                                          contexto, rutaAviso),
                            False, MessageBoxIcon.Warning)
                Case 229, 230
                    Return ("Permisos Insuficientes en SQL Server",
                            String.Format("El usuario SQL configurado no tiene permisos suficientes para ejecutar '{0}'.{1}",
                                          contexto, rutaAviso),
                            False, MessageBoxIcon.Error)
                Case 208, 2812
                    Return ("Objeto de Base de Datos Faltante",
                            String.Format("La base de datos '{0}' no contiene una tabla o procedimiento requerido por '{1}'.{2}Detalle técnico: {3}{4}",
                                          baseDatos, contexto, Environment.NewLine, sqlEx.Message, rutaAviso),
                            False, MessageBoxIcon.Error)
                Case Else
                    Return ("Error de Base de Datos (" & contexto & ")",
                            String.Format("Ocurrió un problema en la base de datos al ejecutar '{0}':{1}{2}{3}",
                                          contexto, Environment.NewLine, sqlEx.Message, rutaAviso),
                            False, MessageBoxIcon.Error)
            End Select
        End If

        ' 3. Archivos y permisos
        If TypeOf ex Is UnauthorizedAccessException OrElse TypeOf ex Is IOException Then
            Return ("Error de Acceso a Archivo (" & contexto & ")",
                    String.Format("No se pudo leer o guardar el archivo requerido en '{0}'.{1}" &
                                  "Verifique que el archivo no esté abierto en Excel u otro programa y que cuente con permisos de escritura.{1}{1}Detalle: {2}{3}",
                                  contexto, Environment.NewLine, ex.Message, rutaAviso),
                    False, MessageBoxIcon.Warning)
        End If

        ' 4. Excel / COM
        If TypeOf ex Is COMException Then
            Return ("Error de Comunicación con Excel (" & contexto & ")",
                    String.Format("No se pudo completar la automatización con Microsoft Excel en '{0}'.{1}" &
                                  "Cierre ventanas pendientes de Excel e intente nuevamente; el sistema cuenta además con exportación nativa sin Excel.{1}{1}Detalle: {2}{3}",
                                  contexto, Environment.NewLine, ex.Message, rutaAviso),
                    False, MessageBoxIcon.Warning)
        End If

        ' 5. Error genérico controlado
        Dim mensajeBase As String = If(ex IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(ex.Message), ex.Message, "Error interno inesperado.")
        Return ("Error en " & If(String.IsNullOrWhiteSpace(contexto), "el Sistema", contexto),
                String.Format("Se produjo un inconveniente en '{0}':{1}{2}{3}", contexto, Environment.NewLine, mensajeBase, rutaAviso),
                False, MessageBoxIcon.Error)
    End Function

    ''' <summary>
    ''' Captura y guarda el error en el archivo de depuración y, si corresponde, muestra un mensaje claro al usuario.
    ''' Si detecta fallo de red SQL y se permite, ofrece abrir el Asistente de Configuración de Servidor SQL.
    ''' </summary>
    Public Shared Function MostrarYRegistrar(ByVal ex As Exception,
                                             Optional ByVal contexto As String = "Operación del Sistema",
                                             Optional ByVal mostrarDialogo As Boolean = True,
                                             Optional ByVal owner As IWin32Window = Nothing,
                                             Optional ByVal permitirAbrirConfigSql As Boolean = True) As Boolean
        Dim rutaLog As String = RegistrarError(ex, contexto)
        If Not mostrarDialogo Then Return EsErrorDeConexionSql(ex)

        Dim diag = FormatearMensajeAmigable(ex, contexto, rutaLog)

        ' Evitar ráfagas idénticas en menos de 1.5 segundos
        Dim firma As String = contexto & "|" & If(ex IsNot Nothing, ex.Message, "")
        SyncLock SyncLockObj
            If String.Equals(firma, _ultimoHashError, StringComparison.Ordinal) AndAlso
               (DateTime.UtcNow - _ultimaFechaDialogo).TotalSeconds < 1.5R Then
                Return diag.EsErrorRedSql
            End If
            _ultimoHashError = firma
            _ultimaFechaDialogo = DateTime.UtcNow
        End SyncLock

        Dim invokerCtrl As Control = TryCast(owner, Control)
        If invokerCtrl Is Nothing Then
            Try
                For Each openFrm As Form In Application.OpenForms
                    If openFrm IsNot Nothing AndAlso Not openFrm.IsDisposed AndAlso openFrm.IsHandleCreated Then
                        invokerCtrl = openFrm
                        Exit For
                    End If
                Next
            Catch
            End Try
        End If
        If invokerCtrl IsNot Nothing AndAlso invokerCtrl.InvokeRequired Then
            Try
                Return CBool(invokerCtrl.Invoke(New Func(Of Boolean)(Function() MostrarDialogoEnUi(diag, owner, permitirAbrirConfigSql))))
            Catch
                Return diag.EsErrorRedSql
            End Try
        End If

        Return MostrarDialogoEnUi(diag, owner, permitirAbrirConfigSql)
    End Function

    Private Shared Function MostrarDialogoEnUi(ByVal diag As (Titulo As String, Mensaje As String, EsErrorRedSql As Boolean, Icono As MessageBoxIcon),
                                               ByVal owner As IWin32Window,
                                               ByVal permitirAbrirConfigSql As Boolean) As Boolean
        If owner Is Nothing Then
            Try
                Dim activeFrm As Form = Form.ActiveForm
                If activeFrm IsNot Nothing AndAlso Not activeFrm.IsDisposed AndAlso activeFrm.IsHandleCreated AndAlso Not activeFrm.InvokeRequired Then
                    owner = activeFrm
                End If
            Catch
            End Try
        End If

        Dim yaEnConfig As Boolean = False
        Try
            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is FrmConfiguracionServidor AndAlso frm.Visible Then
                    yaEnConfig = True
                    Exit For
                End If
            Next
        Catch
        End Try

        Dim puedeAbrirConfigSql As Boolean = (Not Usuario.UsuarioAutenticado) OrElse Usuario.EsAdministrador
        If diag.EsErrorRedSql AndAlso permitirAbrirConfigSql AndAlso puedeAbrirConfigSql AndAlso Not yaEnConfig Then
            Dim textoPregunta As String = diag.Mensaje & Environment.NewLine & Environment.NewLine &
                                          "¿Desea abrir ahora la ventana 'Configurar Servidor SQL' para revisar o cambiar el host/IP?"
            Dim resp As DialogResult
            If owner IsNot Nothing Then
                resp = MessageBox.Show(owner, textoPregunta, diag.Titulo, MessageBoxButtons.YesNo, diag.Icono)
            Else
                resp = MessageBox.Show(textoPregunta, diag.Titulo, MessageBoxButtons.YesNo, diag.Icono)
            End If

            If resp = DialogResult.Yes Then
                Try
                    Using frmCfg As New FrmConfiguracionServidor()
                        If owner IsNot Nothing Then
                            frmCfg.ShowDialog(owner)
                        Else
                            frmCfg.ShowDialog()
                        End If
                    End Using
                    Conexion.PrecalentarPool()
                Catch exCfg As Exception
                    RegistrarError(exCfg, "Abrir FrmConfiguracionServidor desde error")
                End Try
            End If
        Else
            If owner IsNot Nothing Then
                MessageBox.Show(owner, diag.Mensaje, diag.Titulo, MessageBoxButtons.OK, diag.Icono)
            Else
                MessageBox.Show(diag.Mensaje, diag.Titulo, MessageBoxButtons.OK, diag.Icono)
            End If
        End If

        Return diag.EsErrorRedSql
    End Function

    ''' <summary>
    ''' Abre la carpeta de archivos de registro (.log) en el Explorador de Windows o Finder de macOS.
    ''' </summary>
    Public Shared Sub AbrirCarpetaLogs()
        Dim carpeta As String = ObtenerCarpetaLogs()
        Try
            Process.Start(New ProcessStartInfo() With {
                .FileName = carpeta,
                .UseShellExecute = True
            })
        Catch ex As Exception
            RegistrarError(ex, "Abrir Carpeta de Logs")
            MessageBox.Show("Los archivos de registro se guardan en:" & Environment.NewLine & carpeta,
                            "Carpeta de Diagnóstico", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Shared Function BuscarSqlException(ByVal ex As Exception) As SqlException
        Dim actual As Exception = ex
        While actual IsNot Nothing
            Dim sqlEx = TryCast(actual, SqlException)
            If sqlEx IsNot Nothing Then Return sqlEx
            actual = actual.InnerException
        End While
        Return Nothing
    End Function

    Private Shared Function ObtenerMensajesEncadenados(ByVal ex As Exception) As String
        Dim sb As New StringBuilder()
        Dim actual As Exception = ex
        While actual IsNot Nothing
            If Not String.IsNullOrEmpty(actual.Message) Then
                sb.AppendLine(actual.Message)
            End If
            actual = actual.InnerException
        End While
        Return sb.ToString()
    End Function

    Private Shared Function ObtenerResumenServidorSeguro() As String
        Try
            Dim b = Conexion.ObtenerParametrosActuales()
            If b IsNot Nothing Then
                Return String.Format("Servidor='{0}', BD='{1}', Timeout={2}s", b.DataSource, b.InitialCatalog, b.ConnectTimeout)
            End If
        Catch
        End Try
        Return "No disponible"
    End Function

    Private Shared Function ObtenerUsuarioActivo() As String
        Try
            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is principal Then
                    Dim p = DirectCast(frm, principal)
                    If p.lblUsuario IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(p.lblUsuario.Text) Then
                        Return p.lblUsuario.Text.Trim()
                    End If
                End If
            Next
        Catch
        End Try
        Return "(Sin sesión)"
    End Function

    Private Shared Sub DepurarLogsAntiguos(ByVal carpeta As String)
        Try
            Dim limite As DateTime = DateTime.Now.AddDays(-30)
            For Each archivo As String In Directory.GetFiles(carpeta, "errores_*.log")
                Try
                    If File.GetLastWriteTime(archivo) < limite Then
                        File.Delete(archivo)
                    End If
                Catch
                End Try
            Next
        Catch
        End Try
    End Sub

End Class
