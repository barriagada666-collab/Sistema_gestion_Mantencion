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
    ''' Ruta del archivo local de configuración personalizada persistente.
    ''' </summary>
    Public Shared Function ObtenerRutaConfigPersonalizada() As String
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
        
        ' 1. Intentar leer desde archivo de anulación local persistente (conexion_servidor.cfg)
        Try
            Dim rutaLocalCfg As String = ObtenerRutaConfigPersonalizada()
            If File.Exists(rutaLocalCfg) Then
                Dim contenido As String = File.ReadAllText(rutaLocalCfg).Trim()
                If Not String.IsNullOrEmpty(contenido) Then
                    cadena = contenido
                End If
            Else
                ' 2. Intentar leer desde ConfigurationManager (.config XML)
                Dim setting = ConfigurationManager.ConnectionStrings("MantencionConnectionString")
                If setting IsNot Nothing AndAlso Not String.IsNullOrEmpty(setting.ConnectionString) Then
                    cadena = setting.ConnectionString
                End If
            End If
        Catch
        End Try

        ' Pool de conexiones explícito para reutilizar sockets y acelerar todas las consultas
        Try
            Dim sb As New SqlConnectionStringBuilder(cadena)
            sb.Pooling = True
            If sb.MinPoolSize < 2 Then sb.MinPoolSize = 2
            If sb.MaxPoolSize < 50 Then sb.MaxPoolSize = 50
            If sb.ConnectTimeout < 15 Then sb.ConnectTimeout = 15
            If String.IsNullOrEmpty(sb.ApplicationName) OrElse sb.ApplicationName = ".Net SqlClient Data Provider" Then
                sb.ApplicationName = "Sistema de Gestion Mantencion"
            End If
            cadena = sb.ConnectionString
        Catch
        End Try

        _connectionStringCache = cadena
        Return cadena
    End Function

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
    ''' Realiza una prueba de conexión rápida (timeout 5s) hacia la base de datos SQL Server.
    ''' </summary>
    Public Shared Function ProbarConexion(ByVal cadena As String) As (Exito As Boolean, Mensaje As String)
        Try
            Dim sb As New SqlConnectionStringBuilder(cadena)
            sb.ConnectTimeout = 5
            Using testCnx As New SqlConnection(sb.ConnectionString)
                testCnx.Open()
                Return (True, "Conexión establecida correctamente con el servidor SQL.")
            End Using
        Catch ex As Exception
            Return (False, ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Guarda y aplica una nueva cadena de conexión, realizando un respaldo de los archivos originales.
    ''' </summary>
    Public Shared Function GuardarNuevaConexion(ByVal nuevaCadena As String) As (Exito As Boolean, Mensaje As String)
        Try
            Dim timestamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
            
            ' 1. Guardar en archivo local conexion_servidor.cfg con respaldo
            Dim rutaLocalCfg As String = ObtenerRutaConfigPersonalizada()
            If File.Exists(rutaLocalCfg) Then
                Dim rutaBakLocal As String = rutaLocalCfg & "." & timestamp & ".bak"
                File.Copy(rutaLocalCfg, rutaBakLocal, True)
            End If
            File.WriteAllText(rutaLocalCfg, nuevaCadena)

            ' 2. Actualizar también en el archivo XML de configuración (.dll.config)
            Dim rutaXml As String = ObtenerRutaArchivoConfigXml()
            If File.Exists(rutaXml) Then
                ' Respaldo inmutable original si aún no existe
                Dim rutaOriginalBak As String = rutaXml & ".original.bak"
                If Not File.Exists(rutaOriginalBak) Then
                    File.Copy(rutaXml, rutaOriginalBak, False)
                End If
                
                ' Respaldo con timestamp
                Dim rutaTimestampBak As String = rutaXml & "." & timestamp & ".bak"
                File.Copy(rutaXml, rutaTimestampBak, True)

                ' Modificar el nodo de cadena de conexión
                Try
                    Dim doc As New XmlDocument()
                    doc.Load(rutaXml)
                    Dim node As XmlNode = doc.SelectSingleNode("//connectionStrings/add[@name='MantencionConnectionString']")
                    If node IsNot Nothing AndAlso node.Attributes("connectionString") IsNot Nothing Then
                        node.Attributes("connectionString").Value = nuevaCadena
                        doc.Save(rutaXml)
                    End If
                Catch
                End Try
            End If

            ' 3. Actualizar también app.config si existe en la ruta de desarrollo
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

            ' 4. Invalidar el caché en memoria para que tome efecto inmediato en caliente
            _connectionStringCache = Nothing
            ObtenerConnectionString()

            Return (True, "La configuración de conexión fue guardada y respaldada exitosamente.")
        Catch ex As Exception
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
        If cnx Is Nothing Then Exit Sub
        Try
            If cnx.State = ConnectionState.Open Then Exit Sub
            If cnx.State = ConnectionState.Broken Then cnx.Close()
            cnx.ConnectionString = ObtenerConnectionString()
            cnx.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
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
