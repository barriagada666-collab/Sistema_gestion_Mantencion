Public Class FrmPersonal

    Private Function ValidarCamposObligatorios(ByRef mensajeError As String) As Boolean
        Dim rutLimpio As String = txtRut.Text.Trim()
        Dim dvLimpio As String = txtDv.Text.Trim()

        If String.IsNullOrEmpty(rutLimpio) OrElse String.IsNullOrEmpty(dvLimpio) Then
            mensajeError = "Debe ingresar el RUT y dígito verificador."
            txtRut.Focus()
            Return False
        End If

        Dim uSvc As New Usuario()
        If Not uSvc.ValidarRut(rutLimpio, dvLimpio) Then
            mensajeError = "El RUT y dígito verificador ingresados no son válidos."
            txtRut.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtNombres.Text) OrElse String.IsNullOrWhiteSpace(txtApPaterno.Text) OrElse String.IsNullOrWhiteSpace(txtAlias.Text) Then
            mensajeError = "Debe ingresar Nombres, Apellido Paterno y Alias."
            Return False
        End If

        If cmbPlanta.SelectedValue Is Nothing OrElse TypeOf cmbPlanta.SelectedValue Is DataRowView OrElse
           cmbSeccion.SelectedValue Is Nothing OrElse TypeOf cmbSeccion.SelectedValue Is DataRowView OrElse
           cmbCargo.SelectedValue Is Nothing OrElse TypeOf cmbCargo.SelectedValue Is DataRowView Then
            mensajeError = "Debe seleccionar Planta, Sección y Cargo."
            Return False
        End If

        Return True
    End Function

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        Dim err As String = String.Empty
        If Not ValidarCamposObligatorios(err) Then
            MessageBox.Show(Me, err, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim personal As New Personal
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim dv As String = txtDv.Text.Trim()

        personal.IngPersonal(txtRut.Text.Trim(), dv, txtCodInt.Text.Trim(), txtNombres.Text.Trim(), txtApPaterno.Text.Trim(), txtApMaterno.Text.Trim(), txtAlias.Text.Trim(), fecha_nac.Value, txtfono.Text.Trim(), txtEmail.Text.Trim(), cmbPlanta.SelectedValue.ToString(), cmbSeccion.SelectedValue.ToString(), cmbCargo.SelectedValue.ToString(), principal.lblUsuario.Text, opc_activo_si.Checked, txtDireccion.Text.Trim(), fecha_ingreso.Value, txtCelular.Text.Trim(), cod_resp, resp)

        If cod_resp = 1 Then
            MessageBox.Show(Me, resp, "Personal", MessageBoxButtons.OK, MessageBoxIcon.Information)
            personal.limpiarFormPersonal(Me)
        ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
            MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            btnCrearUsuario.Enabled = principal.UsuariosToolStripMenuItem.Enabled
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
        Dim err As String = String.Empty
        If Not ValidarCamposObligatorios(err) Then
            MessageBox.Show(Me, err, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If MessageBox.Show(Me, "¿Está seguro que desea actualizar los datos del trabajador?", "Confirmar Actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim personal As New Personal
            Dim cod_resp As Integer = 0
            Dim resp As String = ""
            Dim dv As String = txtDv.Text.Trim()

            personal.UpdPersonal(txtRut.Text.Trim(), dv, txtCodInt.Text.Trim(), txtNombres.Text.Trim(), txtApPaterno.Text.Trim(), txtApMaterno.Text.Trim(), txtAlias.Text.Trim(), fecha_nac.Value, txtfono.Text.Trim(), txtEmail.Text.Trim(), cmbPlanta.SelectedValue.ToString(), cmbSeccion.SelectedValue.ToString(), cmbCargo.SelectedValue.ToString(), principal.lblUsuario.Text, opc_activo_si.Checked, txtDireccion.Text.Trim(), fecha_ingreso.Value, txtCelular.Text.Trim(), cod_resp, resp)

            If cod_resp = 1 Then
                MessageBox.Show(Me, resp, "Personal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                personal.limpiarFormPersonal(Me)
            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim rutLimpio As String = txtRut.Text.Trim()
        If String.IsNullOrEmpty(rutLimpio) Then
            MessageBox.Show(Me, "Debe buscar y seleccionar un trabajador antes de eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If MessageBox.Show(Me, "¿Está seguro que desea eliminar al trabajador con RUT " & rutLimpio & "?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Dim personal As New Personal
            Dim cod_resp As Integer = 0
            Dim resp As String = ""
            personal.DelPersonal(rutLimpio, principal.lblUsuario.Text, cod_resp, resp)
            If cod_resp = 1 Then
                MessageBox.Show(Me, resp, "Personal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                personal.limpiarFormPersonal(Me)
            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub btnBuscarPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersonal.Click
        FrmBuscarPersonal.nombre_form = "personal"
        FrmBuscarPersonal.Show()
    End Sub

    Private Sub txtRut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRut.KeyPress, txtfono.KeyPress, txtCelular.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnSalirPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirPersonal.Click
        Me.Close()
    End Sub

    Private Sub btnCrearUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearUsuario.Click
        If Not principal.UsuariosToolStripMenuItem.Enabled Then
            MessageBox.Show(Me, "No posee permisos para acceder al módulo de gestión de usuarios.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txtRut.Text.Trim() <> "" AndAlso txtAlias.Text.Trim() <> "" Then
            principal.AbrirAmbienteMdi(FrmAdminUsuarios)
            FrmAdminUsuarios.PrepararNuevoUsuario(txtRut.Text.Trim(), txtAlias.Text.Trim())
        Else
            MessageBox.Show(Me, "Para crear el usuario debe ingresar el RUT y el Alias.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRut.Focus()
        End If
    End Sub
End Class
