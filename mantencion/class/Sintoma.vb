Imports System.Data.SqlClient

Public Class Sintoma
    Public Sub crgCmbSintoma(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        Try
            combo.BeginUpdate()
            Dim dt As DataTable = Conexion.ObtenerCatalogoEnCache("CRG_CMB_SINTOMA", Function()
                Dim conexion As New Conexion
                Using cnx As New SqlConnection
                    conexion.Conectar(cnx)
                    Using DA As New SqlDataAdapter("CRG_CMB_SINTOMA", cnx)
                        DA.SelectCommand.CommandType = CommandType.StoredProcedure
                        Dim t As New DataTable()
                        DA.Fill(t)
                        Return t
                    End Using
                End Using
            End Function)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                combo.DisplayMember = "desc_sintoma"
                combo.ValueMember = "idsintoma"
                combo.DataSource = dt
                Try
                    combo.SelectedValue = "S000"
                Catch
                End Try
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Síntomas")
        Finally
            combo.EndUpdate()
        End Try
    End Sub
End Class
