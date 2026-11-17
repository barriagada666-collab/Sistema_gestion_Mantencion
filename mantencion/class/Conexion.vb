Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Xml

Public Class Conexion

    Private Shared ReadOnly DefaultConnectionString As String = "Data Source = SrvMagicInfo; Initial Catalog = mantencion; User Id = mantencion; Password = cambiaso"

    Private Shared _connectionStringCache As String = Nothing

    ''' <summary>
    ''' Cadena de conexión original de fábrica de Cambiaso Hnos. S.A.C.
    ''' </summary>
    Public Shared ReadOnly Property CadenaPredeterminadaOriginal As String
        Get
            Return DefaultConnectionString
        End Get
    End Property

    ''' <summary>
    ''' Ruta persistente y siempre escribible del archivo local de configuración personalizada.
    ''' </summary>
    Public Shared Function ObtenerRutaConfigPersonalizada() As String
        Try
            Dim appDataDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SistemaMantencion")
            If Not String.IsNullOrWhiteSpace(appDataDir) Then
                Return Path.Combine(appDataDir, "conexion_servidor.cfg")
            End If
        Catch
        End Try
        Return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conexion_servidor.cfg")
    End Function

    ''' <summary>
    ''' Ruta heredada en el directorio base del ejecutable (para instalaciones portables).
    ''' </summary>
    Public Shared Function ObtenerRutaConfigPortable() As String
        Return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conexion_servidor.cfg")
    End Function

    ''' <summary>
    ''' Ruta del archivo XML de configuración de la aplicación (.dll.config o .exe.config).
    ''' </summary>
    Public Shared Function ObtenerRutaArchivoConfigXml() As String
        Dim baseDir As String = AppDomain.CurrentDomain.BaseDirectory
        Dim dllConfig As String = Path.Combine(baseDir, "Sistema de Gestion Mantencion.dll.config")
        If File.Exists(dllConfig) Then Return dllConfig

        Dim exeConfig As String = Path.Combine(baseDir, "Sistema de Gestion Mantencion.exe.config")
        If File.Exists(exeConfig) Then Return exeConfig

        Try
            Dim cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            If cfg IsNot Nothing AndAlso File.Exists(cfg.FilePath) Then Return cfg.FilePath
        Catch
        End Try

        Return dllConfig
    End Function

    ''' <summary>
    ''' Obtiene la cadena de conexión activa con pool optimizado y reutilización de sockets.
    ''' </summary>
    Public Shared Function ObtenerConnectionString() As String
        If _connectionStringCache IsNot Nothing Then Return _connectionStringCache

        Dim cadena As String = DefaultConnectionString

        ' 1. Prioridad: archivo de usuario en LocalApplicationData (sobreviene a actualizaciones y no requiere admin)
        ' 2. Respaldo: archivo portable junto al ejecutable
        ' 3. Respaldo: ConfigurationManager (.config XML)
        Try
            Dim rutaUsuarioCfg As String = ObtenerRutaConfigPersonalizada()
            Dim rutaPortableCfg As String = ObtenerRutaConfigPortable()

            If File.Exists(rutaUsuarioCfg) Then
                Dim contenido As String = File.ReadAllText(rutaUsuarioCfg).Trim()
                If Not String.IsNullOrEmpty(contenido) Then cadena = contenido
            ElseIf File.Exists(rutaPortableCfg) Then
                Dim contenido As String = File.ReadAllText(rutaPortableCfg).Trim()
                If Not String.IsNullOrEmpty(contenido) Then cadena = contenido
            Else
                Dim setting = ConfigurationManager.ConnectionStrings("MantencionConnectionString")
                If setting IsNot Nothing AndAlso Not String.IsNullOrEmpty(setting.ConnectionString) Then
                    cadena = setting.ConnectionString
                End If
            End If
        Catch
        End Try

        ' Pool de conexiones de alto rendimiento para reutilizar sockets y acelerar todas las consultas
        Try
            Dim sb As New SqlConnectionStringBuilder(cadena)
            sb.Pooling = True
            If sb.MinPoolSize < 5 Then sb.MinPoolSize = 5
            If sb.MaxPoolSize < 100 Then sb.MaxPoolSize = 100
            If sb.ConnectTimeout < 5 Then
                sb.ConnectTimeout = 10
            ElseIf sb.ConnectTimeout > 120 Then
                sb.ConnectTimeout = 120
            End If
            sb.Enlist = False
            sb.PacketSize = 8192
            sb.MultipleActiveResultSets = True
            sb.LoadBalanceTimeout = 0
            If String.IsNullOrEmpty(sb.ApplicationName) OrElse sb.ApplicationName = ".Net SqlClient Data Provider" Then
                sb.ApplicationName = "Sistema de Gestion Mantencion"
            End If
            cadena = sb.ConnectionString
        Catch
        End Try

        _connectionStringCache = cadena
        Return cadena
    End Function

    Private Shared ReadOnly _catalogoCache As New System.Collections.Concurrent.ConcurrentDictionary(Of String, DataTable)(StringComparer.OrdinalIgnoreCase)

    ''' <summary>
    ''' Obtiene una copia en memoria de un catálogo común si existe en caché, o ejecuta la función cargadora.
    ''' </summary>
    Public Shared Function ObtenerCatalogoEnCache(ByVal clave As String, ByVal cargador As Func(Of DataTable)) As DataTable
        If String.IsNullOrEmpty(clave) OrElse cargador Is Nothing Then Return Nothing
        Dim dt As DataTable = Nothing
        If _catalogoCache.TryGetValue(clave, dt) AndAlso dt IsNot Nothing Then
            Return dt.Copy()
        End If
        dt = cargador()
        If dt IsNot Nothing Then
            _catalogoCache(clave) = dt
            Return dt.Copy()
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Invalida la caché de catálogos en memoria tras modificaciones o altas.
    ''' </summary>
    Public Shared Sub InvalidarCacheCatalogos(Optional ByVal clave As String = Nothing)
        If String.IsNullOrEmpty(clave) Then
            _catalogoCache.Clear()
        Else
            _catalogoCache.TryRemove(clave, Nothing)
        End If
    End Sub

    Private Shared _poolPrecalentadoIntentado As Boolean = False
    Private Shared _ultimoEstadoConectado As Boolean? = Nothing
    Private Shared _ultimoServidorConectado As String = Nothing
    Private Shared _ultimaBaseDatosConectada As String = Nothing

    ''' <summary>
    ''' Precalienta el pool de conexiones en segundo plano para eliminar la latencia inicial al abrir formularios.
    ''' </summary>
    Public Shared Sub PrecalentarPool()
        System.Threading.ThreadPool.QueueUserWorkItem(Sub()
                                                         Dim srv As String = String.Empty
                                                         Dim bd As String = String.Empty
                                                         Try
                                                             Dim sb As New SqlConnectionStringBuilder(ObtenerConnectionString())
                                                             srv = sb.DataSource
                                                             bd = sb.InitialCatalog
                                                             If sb.ConnectTimeout > 6 Then sb.ConnectTimeout = 6
                                                             Using cnx As New SqlConnection(sb.ConnectionString)
                                                                 cnx.Open()
                                                             End Using
                                                             _ultimoEstadoConectado = True
                                                             _ultimoServidorConectado = srv
                                                             _ultimaBaseDatosConectada = bd
                                                         Catch ex As Exception
                                                             _ultimoEstadoConectado = False
                                                             _ultimoServidorConectado = srv
                                                             _ultimaBaseDatosConectada = bd
                                                             If Not _poolPrecalentadoIntentado Then
                                                                 _poolPrecalentadoIntentado = True
                                                                 RegistroErrores.RegistrarError(ex, "Precalentamiento de Pool SQL (Inicio)", "Fallo en segundo plano al verificar disponibilidad inicial del servidor.")
                                                             End If
                                                         End Try
                                                     End Sub)
    End Sub

    ''' <summary>
    ''' Desglosa los parámetros actuales de la conexión en un SqlConnectionStringBuilder.
    ''' </summary>
    Public Shared Function ObtenerParametrosActuales() As SqlConnectionStringBuilder
        Dim actual As String = ObtenerConnectionString()
        Try
            Return New SqlConnectionStringBuilder(actual)
        Catch
            Return New SqlConnectionStringBuilder(DefaultConnectionString)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene el servidor, base de datos y estado de conexión actual (opcionalmente ejecutando una verificación en vivo).
    ''' </summary>
    Public Shared Function ObtenerEstadoConexionActual(Optional ByVal forzarPrueba As Boolean = False) As (Conectado As Boolean, Servidor As String, BaseDatos As String)
        Dim sb As SqlConnectionStringBuilder = ObtenerParametrosActuales()
        Dim srv As String = If(sb.DataSource, String.Empty).Trim()
        Dim bd As String = If(sb.InitialCatalog, String.Empty).Trim()

        If Not forzarPrueba AndAlso _ultimoEstadoConectado.HasValue AndAlso
           String.Equals(_ultimoServidorConectado, srv, StringComparison.OrdinalIgnoreCase) AndAlso
           String.Equals(_ultimaBaseDatosConectada, bd, StringComparison.OrdinalIgnoreCase) Then
            Return (_ultimoEstadoConectado.Value, srv, bd)
        End If

        Try
            Dim sbTest As New SqlConnectionStringBuilder(sb.ConnectionString)
            sbTest.ConnectTimeout = 4
            Using testCnx As New SqlConnection(sbTest.ConnectionString)
                testCnx.Open()
            End Using
            _ultimoEstadoConectado = True
            _ultimoServidorConectado = srv
            _ultimaBaseDatosConectada = bd
            Return (True, srv, bd)
        Catch
            _ultimoEstadoConectado = False
            _ultimoServidorConectado = srv
            _ultimaBaseDatosConectada = bd
            Return (False, srv, bd)
        End Try
    End Function

    ''' <summary>
    ''' Devuelve el texto estándar para mostrar el servidor y base de datos activos en barras e indicadores.
    ''' </summary>
    Public Shared Function FormatearEstadoConexion(ByVal servidor As String, ByVal baseDatos As String, ByVal conectado As Boolean) As String
        Dim srvTxt As String = If(String.IsNullOrWhiteSpace(servidor), "(No definido)", servidor.Trim())
        Dim bdTxt As String = If(String.IsNullOrWhiteSpace(baseDatos), "(No definida)", baseDatos.Trim())
        If conectado Then
            Return "Conectado a Servidor: " & srvTxt & " - BD: " & bdTxt
        Else
            Return "Sin conexión a Servidor: " & srvTxt & " - BD: " & bdTxt
        End If
    End Function

    ''' <summary>
    ''' Realiza una prueba de conexión rápida (timeout 5s) hacia la base de datos SQL Server.
    ''' </summary>
    Public Shared Function ProbarConexion(ByVal cadena As String) As (Exito As Boolean, Mensaje As String)
        Try
            Dim sb As New SqlConnectionStringBuilder(cadena)
            sb.ConnectTimeout = 5
            Using testCnx As New SqlConnection(sb.ConnectionString)
                testCnx.Open()
                Return (True, "Conexión establecida correctamente con el servidor SQL '" & sb.DataSource & "' (BD '" & sb.InitialCatalog & "').")
            End Using
        Catch ex As Exception
            Dim rutaLog As String = RegistroErrores.RegistrarError(ex, "Prueba de Conexión SQL")
            Dim diag = RegistroErrores.FormatearMensajeAmigable(ex, "Prueba de Conexión SQL", rutaLog)
            Return (False, diag.Titulo & " — " & ex.Message & Environment.NewLine & "Verifique red/VPN, host/IP y puerto 1433. (Log guardado)")
        End Try
    End Function

    ''' <summary>
    ''' Guarda y aplica una nueva cadena de conexión, realizando un respaldo de los archivos originales.
    ''' </summary>
    Public Shared Function GuardarNuevaConexion(ByVal nuevaCadena As String) As (Exito As Boolean, Mensaje As String)
        Try
            Dim timestamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")

            ' 1. Guardar en LocalApplicationData (siempre escribible en Windows Program Files y macOS)
            Dim rutaUsuarioCfg As String = ObtenerRutaConfigPersonalizada()
            Dim dirUsuario As String = Path.GetDirectoryName(rutaUsuarioCfg)
            If Not String.IsNullOrWhiteSpace(dirUsuario) AndAlso Not Directory.Exists(dirUsuario) Then
                Directory.CreateDirectory(dirUsuario)
            End If
            If File.Exists(rutaUsuarioCfg) Then
                File.Copy(rutaUsuarioCfg, rutaUsuarioCfg & "." & timestamp & ".bak", True)
            End If
            File.WriteAllText(rutaUsuarioCfg, nuevaCadena)

            ' 2. Copia best-effort en directorio base (instalaciones portables o desarrollo)
            Try
                Dim rutaPortableCfg As String = ObtenerRutaConfigPortable()
                If Not String.Equals(rutaPortableCfg, rutaUsuarioCfg, StringComparison.OrdinalIgnoreCase) Then
                    If File.Exists(rutaPortableCfg) Then
                        File.Copy(rutaPortableCfg, rutaPortableCfg & "." & timestamp & ".bak", True)
                    End If
                    File.WriteAllText(rutaPortableCfg, nuevaCadena)
                End If
            Catch
            End Try

            ' 3. Actualizar también en el archivo XML de configuración (.dll.config) si es escribible
            Try
                Dim rutaXml As String = ObtenerRutaArchivoConfigXml()
                If File.Exists(rutaXml) Then
                    Dim rutaOriginalBak As String = rutaXml & ".original.bak"
                    If Not File.Exists(rutaOriginalBak) Then
                        File.Copy(rutaXml, rutaOriginalBak, False)
                    End If
                    File.Copy(rutaXml, rutaXml & "." & timestamp & ".bak", True)

                    Dim doc As New XmlDocument()
                    doc.Load(rutaXml)
                    Dim node As XmlNode = doc.SelectSingleNode("//connectionStrings/add[@name='MantencionConnectionString']")
                    If node IsNot Nothing AndAlso node.Attributes("connectionString") IsNot Nothing Then
                        node.Attributes("connectionString").Value = nuevaCadena
                        doc.Save(rutaXml)
                    End If
                End If
            Catch
            End Try

            ' 4. Actualizar también app.config si existe en la ruta de desarrollo
            Try
                Dim rutaAppConfig As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\..\..\app.config")
                If File.Exists(rutaAppConfig) Then
                    Dim fullAppConfig As String = Path.GetFullPath(rutaAppConfig)
                    If Not File.Exists(fullAppConfig & ".original.bak") Then
                        File.Copy(fullAppConfig, fullAppConfig & ".original.bak", False)
                    End If
                    Dim docApp As New XmlDocument()
                    docApp.Load(fullAppConfig)
                    Dim nodeApp As XmlNode = docApp.SelectSingleNode("//connectionStrings/add[@name='MantencionConnectionString']")
                    If nodeApp IsNot Nothing AndAlso nodeApp.Attributes("connectionString") IsNot Nothing Then
                        nodeApp.Attributes("connectionString").Value = nuevaCadena
                        docApp.Save(fullAppConfig)
                    End If
                End If
            Catch
            End Try

            ' 5. Invalidar el caché en memoria para que tome efecto inmediato en caliente
            _connectionStringCache = Nothing
            _poolPrecalentadoIntentado = False
            _ultimoEstadoConectado = Nothing
            _ultimoServidorConectado = Nothing
            _ultimaBaseDatosConectada = Nothing
            InvalidarCacheCatalogos()
            ObtenerConnectionString()

            Return (True, "La configuración de conexión fue guardada y respaldada exitosamente.")
        Catch ex As Exception
            RegistroErrores.RegistrarError(ex, "Guardar Nueva Conexión SQL")
            Return (False, "Error al guardar configuración: " & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Restaura los valores de conexión de fábrica de Cambiaso Hnos. S.A.C. (SrvMagicInfo).
    ''' </summary>
    Public Shared Function RestaurarConexionOriginal() As (Exito As Boolean, Mensaje As String)
        Return GuardarNuevaConexion(DefaultConnectionString)
    End Function

    Public Sub Conectar(ByVal cnx As SqlConnection)
        If cnx Is Nothing Then Throw New ArgumentNullException(NameOf(cnx))
        Try
            If cnx.State = ConnectionState.Open Then Exit Sub
            If cnx.State = ConnectionState.Broken Then cnx.Close()
            If String.IsNullOrEmpty(cnx.ConnectionString) Then
                cnx.ConnectionString = ObtenerConnectionString()
            End If
            cnx.Open()
            _ultimoEstadoConectado = True
            _ultimoServidorConectado = cnx.DataSource
            _ultimaBaseDatosConectada = cnx.Database
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Desconectar(ByVal cnx As SqlConnection)
        If cnx Is Nothing Then Exit Sub
        Try
            If cnx.State <> ConnectionState.Closed Then
                cnx.Close()
            End If
            cnx.Dispose()
        Catch ex As Exception
        End Try
    End Sub

End Class
