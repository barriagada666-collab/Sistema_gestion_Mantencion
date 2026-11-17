Imports System.Data.SqlClient

Public Class Auditoria
    Public Sub CrgInfAuditoria(ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DS As DataSet)
        If DS Is Nothing Then DS = New DataSet()
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("INF_AUDITORIA", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio", fecha_inicio.ToString("yyyyMMdd 00:00:00"))
                    DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", fecha_fin.ToString("yyyyMMdd 23:59:59"))
                    DA.Fill(DS)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Informe Auditoría")
        End Try
    End Sub
End Class
