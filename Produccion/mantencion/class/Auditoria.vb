Imports System.Data.SqlClient
Public Class Auditoria
    Public Sub CrgInfAuditoria(ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DS As DataSet)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_AUDITORIA", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim p_fecha_inicio As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_fecha_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", Format(fecha_fin, "MM/dd/yyyy"))

            DA.Fill(DS)
            conexion.Desconectar(cnx)
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
