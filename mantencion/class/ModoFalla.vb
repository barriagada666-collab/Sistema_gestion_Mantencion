Imports System.Data.SqlClient
Public Class ModoFalla
    Public Sub crgTipoFalla(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        Try
            combo.BeginUpdate()
            Dim dt As DataTable = Conexion.ObtenerCatalogoEnCache("CRG_CMB_TIPO_FALLA", Function()
                Dim conexion As New Conexion
                Dim cnx As New SqlConnection
                Try
                    conexion.Conectar(cnx)
                    Using DA As New SqlDataAdapter("CRG_CMB_TIPO_FALLA", cnx)
                        Dim t As New DataTable()
                        DA.Fill(t)
                        Return t
                    End Using
                Finally
                    conexion.Desconectar(cnx)
                End Try
            End Function)
            If dt IsNot Nothing Then
                combo.DataSource = dt
                combo.DisplayMember = "desc_tipo_falla"
                combo.ValueMember = "id_tipo_falla"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            combo.EndUpdate()
        End Try
    End Sub

    Public Sub crgModoFalla(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        Try
            combo.BeginUpdate()
            Dim dt As DataTable = Conexion.ObtenerCatalogoEnCache("CRG_CMB_MODO_FALLA", Function()
                Dim conexion As New Conexion
                Dim cnx As New SqlConnection
                Try
                    conexion.Conectar(cnx)
                    Using DA As New SqlDataAdapter("CRG_CMB_MODO_FALLA", cnx)
                        Dim t As New DataTable()
                        DA.Fill(t)
                        Return t
                    End Using
                Finally
                    conexion.Desconectar(cnx)
                End Try
            End Function)
            If dt IsNot Nothing Then
                combo.DataSource = dt
                combo.DisplayMember = "desc_modo_falla"
                combo.ValueMember = "id_modo_falla"
                combo.SelectedValue = "Q000"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error")
        Finally
            combo.EndUpdate()
        End Try
    End Sub
End Class
