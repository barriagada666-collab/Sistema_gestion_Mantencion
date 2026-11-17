Imports System.Data.SqlClient

Public Class Insumo
    Public Sub CrgInsumosMp(ByRef DS As DataSet)
        If DS Is Nothing Then DS = New DataSet()
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_INSUMOS", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.Fill(DS)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Insumos MP")
        End Try
    End Sub
End Class
