Imports System.Data.SqlClient

Public Class ModoFalla
    Public Sub crgTipoFalla(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        Try
            combo.BeginUpdate()
            Dim dt As DataTable = Conexion.ObtenerCatalogoEnCache("CRG_CMB_TIPO_FALLA", Function()
                Dim conexion As New Conexion
                Using cnx As New SqlConnection
                    conexion.Conectar(cnx)
                    Using DA As New SqlDataAdapter("CRG_CMB_TIPO_FALLA", cnx)
                        DA.SelectCommand.CommandType = CommandType.StoredProcedure
                        Dim t As New DataTable()
                        DA.Fill(t)
                        Return t
                    End Using
                End Using
            End Function)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                combo.DisplayMember = "desc_tipo_falla"
                combo.ValueMember = "id_tipo_falla"
                combo.DataSource = dt
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Tipos de Falla")
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
                Using cnx As New SqlConnection
                    conexion.Conectar(cnx)
                    Using DA As New SqlDataAdapter("CRG_CMB_MODO_FALLA", cnx)
                        DA.SelectCommand.CommandType = CommandType.StoredProcedure
                        Dim t As New DataTable()
                        DA.Fill(t)
                        Return t
                    End Using
                End Using
            End Function)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                combo.DisplayMember = "desc_modo_falla"
                combo.ValueMember = "id_modo_falla"
                combo.DataSource = dt
                Try
                    combo.SelectedValue = "Q000"
                Catch
                End Try
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Modos de Falla")
        Finally
            combo.EndUpdate()
        End Try
    End Sub
End Class
