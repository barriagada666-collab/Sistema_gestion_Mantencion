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
                    Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_inicio", Utilitarios.SafeSqlDateStart(fecha_inicio))
                    Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_fin", Utilitarios.SafeSqlDateEnd(fecha_fin))
                    DA.Fill(DS)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Informe Auditoría")
        End Try
    End Sub
End Class
