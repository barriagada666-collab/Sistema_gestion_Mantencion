Imports System.Data.SqlClient
Public Class Sintoma
    Public Sub crgCmbSintoma(ByRef combo As ComboBox)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_CMB_SINTOMA", cnx)
            Dim DS As New DataSet

            DA.Fill(DS)
            combo.DataSource = DS.Tables(0)
            combo.DisplayMember = "desc_sintoma"
            combo.ValueMember = "idsintoma"
            combo.SelectedValue = "S000"
            conexion.Desconectar(cnx)
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
