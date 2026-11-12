Imports System.Data.SqlClient
Public Class Proveedor
    Public Sub crgprovee(ByRef combo As ComboBox)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_CMB_PROVEEDOR ", cnx)
                Dim DS As New DataSet
                DA.Fill(DS)
                combo.DataSource = DS.Tables(0)
                combo.DisplayMember = "nombre_prov"
                combo.ValueMember = "idproveedor"
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub
End Class
