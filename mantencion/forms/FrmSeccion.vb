Public Class FrmSeccion

    Private Sub btnIngSeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngSeccion.Click
        Dim seccion As New Seccion
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        seccion.IngSeccion(txtCodSeccion.Text.Trim(), txtDescSeccion.Text.Trim(), principal.lblUsuario.Text, cod_resp, resp)
        If cod_resp = 1 Then
            MessageBox.Show(Me, resp, "Secciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
            seccion.LimpiarFrmSeccion()
        ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
            MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnUpdSeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdSeccion.Click
        Dim seccion As New Seccion
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        seccion.UpdSeccion(txtCodSeccion.Text.Trim(), txtDescSeccion.Text.Trim(), principal.lblUsuario.Text, cod_resp, resp)
        If cod_resp = 1 Then
            MessageBox.Show(Me, resp, "Secciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
            seccion.LimpiarFrmSeccion()
        ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
            MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnDelSeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelSeccion.Click
        If String.IsNullOrWhiteSpace(txtCodSeccion.Text) Then
            MessageBox.Show(Me, "Debe ingresar o seleccionar el código de sección antes de eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodSeccion.Focus()
            Exit Sub
        End If

        If MessageBox.Show(Me, "¿Está seguro que desea eliminar la sección seleccionada?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
            Exit Sub
        End If

        Dim seccion As New Seccion
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        seccion.DelSeccion(txtCodSeccion.Text.Trim(), principal.lblUsuario.Text, cod_resp, resp)

        If cod_resp = 1 Then
            MessageBox.Show(Me, resp, "Secciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
            seccion.LimpiarFrmSeccion()
        ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
            MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnLimpiarSeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarSeccion.Click
        Dim seccion As New Seccion
        seccion.LimpiarFrmSeccion()
    End Sub

    Private Sub txtCodSeccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodSeccion.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub FrmSeccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Utilitarios.AplicarTemaModerno(Me)
    End Sub

    Private Sub btn_salir_seccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir_seccion.Click
        Me.Close()
    End Sub

    Private Sub btnBuscarSeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarSeccion.Click
        FrmBuscarSeccion.Show()
    End Sub
End Class
