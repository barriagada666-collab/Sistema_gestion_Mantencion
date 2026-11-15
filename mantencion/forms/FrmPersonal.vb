Public Class FrmPersonal

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        Dim personal As New Personal
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim activo As Boolean = False

        If txtRut.Text = "" Or txtDv.Text = "" Then
            MsgBox("Debe ingresar un RUT antes de ingresar !!!", MsgBoxStyle.Exclamation, "Validación")
        Else
            If opc_activo_si.Checked Then
                activo = True
            End If
            personal.IngPersonal(txtRut.Text, txtDv.Text, txtCodInt.Text, txtNombres.Text, txtApPaterno.Text, txtApMaterno.Text, txtAlias.Text, fecha_nac.Value, txtfono.Text, txtEmail.Text, cmbPlanta.SelectedValue, cmbSeccion.SelectedValue, cmbCargo.SelectedValue, principal.lblUsuario.Text, activo, txtDireccion.Text, fecha_ingreso.Value, txtCelular.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MsgBox(resp, MsgBoxStyle.Information, "Validación")
                personal.limpiarFormPersonal(Me)
            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                MsgBox(resp, MsgBoxStyle.Critical, "Validación")
            End If
        End If

    End Sub

    Private Sub IngPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Dim planta As New Planta
        Dim seccion As New Seccion
        Dim cargo As New Cargo

        Try
            planta.crgPlanta(cmbPlanta)
            seccion.crgCmbSeccion(cmbSeccion)
            cargo.crgCmbCargo(cmbCargo)
            Utilitarios.AplicarTemaModerno(Me)
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Dim personal As New Personal

        personal.limpiarFormPersonal(Me)
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        If txtRut.Text = "" Or txtDv.Text = "" Then
            MsgBox("Debe ingresar un RUT antes de guardar", MsgBoxStyle.Exclamation, "Validación")
        Else
            If MsgBox("¿Esta Seguro Que Desea Actualizar Los Datos?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                Dim personal As New Personal
                Dim cod_resp As Integer = 0
                Dim resp As String = ""
                Dim activo As Boolean = False

                If opc_activo_si.Checked Then
                    activo = True
                End If
                personal.UpdPersonal(txtRut.Text, txtDv.Text, txtCodInt.Text, txtNombres.Text, txtApPaterno.Text, txtApMaterno.Text, txtAlias.Text, fecha_nac.Value, txtfono.Text, txtEmail.Text, cmbPlanta.SelectedValue, cmbSeccion.SelectedValue, cmbCargo.SelectedValue, principal.lblUsuario.Text, activo, txtDireccion.Text, fecha_ingreso.Value, txtCelular.Text, cod_resp, resp)

                If cod_resp = 1 Then
                    MsgBox(resp, MsgBoxStyle.Information, "Validación")
                    personal.limpiarFormPersonal(Me)
                ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                    MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                End If
            End If
        End If

    End Sub

    Private Sub btnBuscarPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersonal.Click
        FrmBuscarPersonal.nombre_form = "personal"
        FrmBuscarPersonal.Show()
    End Sub

    Private Sub txtRut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRut.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtfono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfono.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnSalirPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirPersonal.Click
        Me.Close()
    End Sub

    Private Sub btnCrearUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearUsuario.Click
        If txtRut.Text <> "" And txtAlias.Text <> "" Then
            FrmAdminUsuarios.Show()
            FrmAdminUsuarios.txtRutUsuario.Text = txtRut.Text
            FrmAdminUsuarios.txtNomUsuario.Text = txtAlias.Text
        Else
            MsgBox("Para crear el usuario debe ingresar el rut y el alias", MsgBoxStyle.Exclamation, "Validación")
            txtRut.Focus()
        End If

    End Sub

    Private Sub txtCelular_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCelular.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class