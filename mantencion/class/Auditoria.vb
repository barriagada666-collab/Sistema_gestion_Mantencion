Imports System.Data.SqlClient
Public Class Auditoria
    Public Sub CrgInfAuditoria(ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DS As DataSet)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_AUDITORIA", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure

                Dim p_fecha_inicio As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio", fecha_inicio.ToString("yyyyMMdd 00:00:00"))
                Dim p_fecha_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", fecha_fin.ToString("yyyyMMdd 23:59:59"))

                DA.Fill(DS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Informe Auditoría")
        Finally
            conexion.Desconectar(cnx)
        End Try

    End Sub
End Class
