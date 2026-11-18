Public Class FrmDatosTecnicos

    Private Sub FrmDatosTecnicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Utilitarios.AplicarTemaModerno(Me)
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnNuevoDato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoDato.Click
        Try
            Dim datos_tecnicos As New DatosTecnicos
            txtIdDatoTecnico.Text = datos_tecnicos.NUEVO_ID_DATO_TECNICO().ToString()
            txtDescDatoTecnico.ResetText()
            opcDatoActivado.Checked = True
            txtDescDatoTecnico.Focus()
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Datos Técnicos (Nuevo)", True, Me)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Try
            txtIdDatoTecnico.ResetText()
            txtDescDatoTecnico.ResetText()
            opcDatoActivado.Checked = True
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Datos Técnicos (Limpiar)", True, Me)
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim idVal As Integer = 0
        If Not Integer.TryParse(txtIdDatoTecnico.Text.Trim(), idVal) OrElse idVal <= 0 Then
            MessageBox.Show(Me, "Presione 'Nuevo' o busque un dato técnico válido antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(txtDescDatoTecnico.Text) Then
            MessageBox.Show(Me, "Debe ingresar la descripción del dato técnico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescDatoTecnico.Focus()
            Exit Sub
        End If

        Try
            Dim datos_tecnicos As New DatosTecnicos
            Dim respuesta As Integer = datos_tecnicos.BuscarIdDatoTecnico(idVal.ToString())
            Dim estado_dato_tecnico As Boolean = opcDatoActivado.Checked
            Dim cod_resp As Integer = 0
            Dim resp As String = ""

            If respuesta = 0 Then
                datos_tecnicos.IngDatoTecnico(idVal.ToString(), txtDescDatoTecnico.Text.Trim(), estado_dato_tecnico, principal.lblUsuario.Text, cod_resp, resp)
            Else
                datos_tecnicos.UpdDatoTecnico(idVal.ToString(), txtDescDatoTecnico.Text.Trim(), estado_dato_tecnico, principal.lblUsuario.Text, cod_resp, resp)
            End If

            If cod_resp = 1 Then
                MessageBox.Show(Me, resp, "Datos Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtIdDatoTecnico.ResetText()
                txtDescDatoTecnico.ResetText()
                opcDatoActivado.Checked = True
            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Datos Técnicos (Guardar)", True, Me)
        End Try
    End Sub

    Private Sub btnBuscarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDatos.Click
        FrmBuscarDatosTecnicos.nombre_form = Me.Name
        FrmBuscarDatosTecnicos.Show()
    End Sub
End Class
