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
            Else
                MsgBox(resp, MsgBoxStyle.Critical, "Validación")
            End If
        End If

    End Sub

    Private Sub IngPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim planta As New Planta
        Dim seccion As New Seccion
        Dim cargo As New Cargo
        Dim width As Double = Screen.PrimaryScreen.Bounds.Width
        Dim heigh As Double = Screen.PrimaryScreen.Bounds.Height

        Me.Width = width
        Me.Height = heigh

        planta.crgPlanta(cmbPlanta)
        seccion.crgCmbSeccion(cmbSeccion)
        cargo.crgCmbCargo(cmbCargo)
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
                Else
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

    Private Sub txtRut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRut.TextChanged

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

    Private Sub txtfono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfono.TextChanged
      
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

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

    Private Sub txtDv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDv.LostFocus
        
    End Sub

    Private Sub txtDv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDv.TextChanged

    End Sub

    Private Sub txtCodInt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodInt.Enter
        'Dim usuario As New Usuario
        'Dim rutValido As Boolean
        'rutValido = usuario.ValidarRut(txtRut.Text, txtDv.Text)

        'If rutValido = False Then
        '    MsgBox("El rut ingresado no es valido, favor ingrese nuevamente", MsgBoxStyle.Exclamation, "Validación Rut")
        '    txtDv.ResetText()
        '    txtRut.ResetText()
        '    txtRut.Focus()
        'End If
    End Sub

    Private Sub txtCodInt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodInt.TextChanged

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

    Private Sub txtCelular_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCelular.TextChanged

    End Sub
End Class