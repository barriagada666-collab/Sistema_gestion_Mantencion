Public Class Login

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim nombreUsuario As String = User.Text.Trim()
        Dim clave As String = Password.Text

        If String.IsNullOrEmpty(nombreUsuario) Then
            MessageBox.Show(Me, "Debe ingresar su nombre de usuario.", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            User.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(clave) Then
            MessageBox.Show(Me, "Debe ingresar su contraseña.", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Password.Focus()
            Exit Sub
        End If

        Dim usuario As New Usuario
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        Me.Cursor = Cursors.WaitCursor
        OK.Enabled = False
        Try
            usuario.buscarUsuario(nombreUsuario, clave, cod_resp, resp)
        Finally
            OK.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

        If cod_resp = 1 Then
            usuario.CrgPermisosUsuarioLogin(nombreUsuario, clave, 0)
            principal.Show()
            principal.lblUsuario.Text = UCase(nombreUsuario)
            Me.Close()
        ElseIf cod_resp = -1 Then
            ' El error técnico/red ya fue capturado, guardado en disco y explicado al usuario por RegistroErrores.
            Password.Focus()
        Else
            Dim msgValidacion As String = If(String.IsNullOrWhiteSpace(resp), "Usuario o contraseña incorrectos.", resp)
            MessageBox.Show(Me, msgValidacion, "Validación de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
