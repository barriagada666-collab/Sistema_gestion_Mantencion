Imports System.Data.SqlClient
Public Class ModoFalla
    Public Sub crgTipoFalla(ByRef combo As ComboBox)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_CMB_TIPO_FALLA", cnx)
            Dim DS As New DataSet

            DA.Fill(DS)
            combo.DataSource = DS.Tables(0)
            combo.DisplayMember = "desc_tipo_falla"
            combo.ValueMember = "id_tipo_falla"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub crgModoFalla(ByRef combo As ComboBox)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_CMB_MODO_FALLA", cnx)
            Dim DS As New DataSet

            DA.Fill(DS)
            combo.DataSource = DS.Tables(0)
            combo.DisplayMember = "desc_modo_falla"
            combo.ValueMember = "id_modo_falla"
            combo.SelectedValue = "Q000"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error")
        End Try
    End Sub
End Class
