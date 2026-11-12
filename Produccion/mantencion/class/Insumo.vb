Imports System.Data.SqlClient
Public Class Insumo

    Public Sub CrgInsumosMp(ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_INSUMOS", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub
End Class
