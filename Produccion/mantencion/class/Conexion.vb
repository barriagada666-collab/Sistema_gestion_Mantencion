Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class Conexion

    Public Sub Conectar(ByVal cnx As SqlConnection)
        cnx.ConnectionString = "Data Source = sap60sma; Initial Catalog = mantencion; User Id = appdesarrollo; Password = cambiaso"
        'cnx.ConnectionString = "File Name=" & System.AppDomain.CurrentDomain.BaseDirectory() & "\conexion.udl"------ conexion con ODBC en equipo cliente leyendo el archivo UDL
        Try
            cnx.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Public Sub Desconectar(ByVal cnx As SqlConnection)
        Try
            cnx.Close()
            cnx.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        
    End Sub
End Class
