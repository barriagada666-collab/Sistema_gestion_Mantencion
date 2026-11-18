Public Class FrmCargo

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim cargo As New Cargo
        cargo.LimpiarFrmCargo()
    End Sub

    Private Sub txtCodCargo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodCargo.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btn_guardar_cargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_cargo.Click
        Dim codLimpio As String = txtCodCargo.Text.Trim()
        Dim descLimpia As String = txtDescCargo.Text.Trim()
        Dim idVal As Integer = 0
        If Not Integer.TryParse(codLimpio, idVal) Then
            MessageBox.Show(Me, "Debe ingresar un código numérico de cargo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodCargo.Focus()
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(descLimpia) Then
            MessageBox.Show(Me, "Debe ingresar la descripción del cargo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescCargo.Focus()
            Exit Sub
        End If

        Dim cargo As New Cargo
        Dim resp As String = ""
        Dim cod_resp As Integer = cargo.BuscarCargo(codLimpio)
        If cod_resp < 0 Then Exit Sub

        If cod_resp = 0 Then
            cargo.IngCargo(codLimpio, descLimpia, principal.lblUsuario.Text, cod_resp, resp)
        Else
            cod_resp = 0
            cargo.UpdCargo(codLimpio, descLimpia, principal.lblUsuario.Text, cod_resp, resp)
        End If

        If cod_resp = 1 Then
            MessageBox.Show(Me, resp, "Cargos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cargo.LimpiarFrmCargo()
        ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
            MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btn_eliminar_cargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_cargo.Click
        Dim codLimpio As String = txtCodCargo.Text.Trim()
        Dim idVal As Integer = 0
        If Not Integer.TryParse(codLimpio, idVal) Then
            MessageBox.Show(Me, "Debe seleccionar o ingresar un código de cargo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodCargo.Focus()
            Exit Sub
        End If

        If MessageBox.Show(Me, "¿Está seguro de eliminar el cargo '" & txtDescCargo.Text.Trim() & "'?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Dim cargo As New Cargo
            Dim cod_resp As Integer = 0
            Dim resp As String = ""

            cargo.DelCargo(codLimpio, principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MessageBox.Show(Me, resp, "Cargos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cargo.LimpiarFrmCargo()
            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub FrmCargo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Utilitarios.AplicarTemaModerno(Me)
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub btn_buscar_cargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_cargo.Click
        Dim cargos As New Cargo
        Dim DST_CARGOS As New DataSet
        Dim formato_grid As New FormatoGrillas

        Try
            grillaCargos.SuspendLayout()
            cargos.CrgCargos(DST_CARGOS)
            If DST_CARGOS.Tables.Count > 0 Then
                grillaCargos.DataSource = DST_CARGOS.Tables(0)
                formato_grid.grillaCargos(grillaCargos)
                Utilitarios.AjustarColumnasGrilla(grillaCargos)
            End If
        Finally
            grillaCargos.ResumeLayout(False)
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub grillaCargos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaCargos.CellDoubleClick
        If e.RowIndex < 0 OrElse e.RowIndex >= grillaCargos.RowCount Then Exit Sub
        Try
            Dim row = grillaCargos.Rows(e.RowIndex)
            If row Is Nothing OrElse row.IsNewRow OrElse grillaCargos.Columns.Count < 2 Then Exit Sub
            txtCodCargo.Text = If(row.Cells(0).Value Is Nothing OrElse IsDBNull(row.Cells(0).Value), String.Empty, row.Cells(0).Value.ToString().Trim())
            txtDescCargo.Text = If(row.Cells(1).Value Is Nothing OrElse IsDBNull(row.Cells(1).Value), String.Empty, row.Cells(1).Value.ToString().Trim())
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargos (Grilla Cargos)", True, Me)
        End Try
    End Sub
End Class
