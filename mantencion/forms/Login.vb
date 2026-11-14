Public Class Login

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim usuario As New Usuario
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        usuario.buscarUsuario(User.Text, Password.Text, cod_resp, resp)

        If cod_resp = 1 Then
            usuario.CrgPermisosUsuarioLogin(User.Text, Password.Text, 0)
            principal.Show()
            principal.lblUsuario.Text = UCase(User.Text)
            Me.Close()
        Else
            MsgBox(resp, MsgBoxStyle.Critical, "Validación")
            Password.Text = ""
            User.Focus()
        End If

    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Conexion.PrecalentarPool()
        Utilitarios.RegistrarTemaGlobal()
        Utilitarios.AplicarTemaModerno(Me)
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
