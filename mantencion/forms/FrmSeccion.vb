Public Class FrmSeccion

    Private Sub btnIngSeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngSeccion.Click
        Dim seccion As New Seccion
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        seccion.IngSeccion(txtCodSeccion.Text, txtDescSeccion.Text, principal.lblUsuario.Text, cod_resp, resp)
        If cod_resp = 1 Then
            MsgBox(resp, MsgBoxStyle.Information, "Validación")
            seccion.LimpiarFrmSeccion()
        Else
            MsgBox(resp, MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub btnUpdSeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdSeccion.Click
        Dim seccion As New Seccion
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        seccion.UpdSeccion(txtCodSeccion.Text, txtDescSeccion.Text, principal.lblUsuario.Text, cod_resp, resp)
        If cod_resp = 1 Then
            MsgBox(resp, MsgBoxStyle.Information, "Validación")
            seccion.LimpiarFrmSeccion()
        Else
            MsgBox(resp, MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub btnDelSeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelSeccion.Click
        Dim seccion As New Seccion
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        seccion.DelSeccion(txtCodSeccion.Text, principal.lblUsuario.Text, cod_resp, resp)

        If cod_resp = 1 Then
            MsgBox(resp, MsgBoxStyle.Information, "Validación")
            seccion.LimpiarFrmSeccion()
        Else
            MsgBox(resp, MsgBoxStyle.Critical, "Validación")
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