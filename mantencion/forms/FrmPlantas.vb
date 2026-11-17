Public Class FrmPlantas

    Private Sub btnIngPlanta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngPlanta.Click
        Dim planta As New Planta
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        planta.IngPlanta(txtCodPlanta.Text.Trim(), txtNomPlanta.Text.Trim(), principal.lblUsuario.Text, cod_resp, resp)
        If cod_resp = 1 Then
            MessageBox.Show(Me, resp, "Plantas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            planta.LimpiarFrmPlanta()
        ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
            MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodPlanta.Focus()
        End If
    End Sub

    Private Sub btnLimpiarFrmPlanta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarFrmPlanta.Click
        Dim planta As New Planta
        planta.LimpiarFrmPlanta()
    End Sub

    Private Sub btnActPlanta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActPlanta.Click
        If String.IsNullOrWhiteSpace(txtCodPlanta.Text) OrElse String.IsNullOrWhiteSpace(txtNomPlanta.Text) Then
            MessageBox.Show(Me, "Debe ingresar el código y nombre de la planta antes de actualizar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodPlanta.Focus()
            Exit Sub
        End If
        If MessageBox.Show(Me, "¿Está seguro que desea actualizar esta planta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If

        Dim planta As New Planta
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        planta.UpdPlanta(txtCodPlanta.Text.Trim(), txtNomPlanta.Text.Trim(), cod_resp, resp)

        If cod_resp = 1 Then
            MessageBox.Show(Me, resp, "Plantas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            planta.LimpiarFrmPlanta()
        ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
            MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnDelPlanta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelPlanta.Click
        If String.IsNullOrWhiteSpace(txtCodPlanta.Text) Then
            MessageBox.Show(Me, "Debe seleccionar o ingresar el código de planta antes de eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodPlanta.Focus()
            Exit Sub
        End If

        Dim planta As New Planta
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        If MessageBox.Show(Me, "¿Está seguro que desea eliminar la planta del sistema?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            planta.DelPlanta(txtCodPlanta.Text.Trim(), principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MessageBox.Show(Me, resp, "Plantas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                planta.LimpiarFrmPlanta()
            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub txtCodPlanta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodPlanta.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnBuscarPlanta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPlanta.Click
        FrmBuscarPlanta.Show()
    End Sub

    Private Sub FrmPlantas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Utilitarios.AplicarTemaModerno(Me)
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class
