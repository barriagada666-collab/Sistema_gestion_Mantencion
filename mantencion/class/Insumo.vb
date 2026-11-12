Imports System.Data.SqlClient
Public Class Insumo

    Public Sub CrgInsumosMp(ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_INSUMOS", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.Fill(DS)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub
End Class
