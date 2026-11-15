Imports System.Data.SqlClient
Public Class Sintoma
    Public Sub crgCmbSintoma(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        Try
            combo.BeginUpdate()
            Dim dt As DataTable = Conexion.ObtenerCatalogoEnCache("CRG_CMB_SINTOMA", Function()
                Dim conexion As New Conexion
                Dim cnx As New SqlConnection
                Try
                    conexion.Conectar(cnx)
                    Using DA As New SqlDataAdapter("CRG_CMB_SINTOMA", cnx)
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
                combo.DisplayMember = "desc_sintoma"
                combo.ValueMember = "idsintoma"
                combo.SelectedValue = "S000"
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "")
        Finally
            combo.EndUpdate()
        End Try
    End Sub
End Class
