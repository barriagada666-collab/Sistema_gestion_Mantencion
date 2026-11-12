Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Configuration

Public Class Conexion

    Private Shared ReadOnly DefaultConnectionString As String = "Data Source = SrvMagicInfo; Initial Catalog = mantencion; User Id = mantencion; Password = cambiaso"

    Private Shared _connectionStringCache As String = Nothing

    Private Shared Function ObtenerConnectionString() As String
        If _connectionStringCache IsNot Nothing Then Return _connectionStringCache
        Dim cadena As String = DefaultConnectionString
        Try
            Dim setting = ConfigurationManager.ConnectionStrings("MantencionConnectionString")
            If setting IsNot Nothing AndAlso Not String.IsNullOrEmpty(setting.ConnectionString) Then
                cadena = setting.ConnectionString
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

    Public Sub Conectar(ByVal cnx As SqlConnection)
        If cnx Is Nothing Then Exit Sub
        Try
            If cnx.State = ConnectionState.Open Then Exit Sub
            If cnx.State = ConnectionState.Broken Then cnx.Close()
            cnx.ConnectionString = ObtenerConnectionString()
            'cnx.ConnectionString = "File Name=" & System.AppDomain.CurrentDomain.BaseDirectory() & "\conexion.udl"
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
End Class
