Public Class FrmPlantas

    Private Sub btnIngPlanta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngPlanta.Click
        Dim planta As New Planta
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        planta.IngPlanta(txtCodPlanta.Text, txtNomPlanta.Text, principal.lblUsuario.Text, cod_resp, resp)
        If cod_resp = 1 Then
            MsgBox(resp, MsgBoxStyle.Information, "Validación")
            planta.LimpiarFrmPlanta()
        ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
            MsgBox(resp, MsgBoxStyle.Critical, "Validación")
            txtCodPlanta.Focus()
        End If
    End Sub

    Private Sub btnLimpiarFrmPlanta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarFrmPlanta.Click
        Dim planta As New Planta

        planta.LimpiarFrmPlanta()
    End Sub

    Private Sub btnActPlanta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActPlanta.Click
        Dim planta As New Planta
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        planta.UpdPlanta(txtCodPlanta.Text, txtNomPlanta.Text, cod_resp, resp)

        If cod_resp = 1 Then
            MsgBox(resp, MsgBoxStyle.Information, "Validación")
        ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
            MsgBox(resp, MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub btnDelPlanta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelPlanta.Click
        Dim planta As New Planta
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        If MsgBox("¿Esta seguro que desea eliminar la planta del sistema?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
            planta.DelPlanta(txtCodPlanta.Text, principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MsgBox(resp, MsgBoxStyle.Information, "Validación")
                planta.LimpiarFrmPlanta()
            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                MsgBox(resp, MsgBoxStyle.Critical, "Validación")
            End If
        End If
        
    End Sub

    Private Sub txtCodPlanta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodPlanta.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
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