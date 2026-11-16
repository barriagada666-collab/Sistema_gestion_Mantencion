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
        Me.BackColor = Utilitarios.ColorFondoPanel
        UsernameLabel.BackColor = Utilitarios.ColorFondoPanel
        PasswordLabel.BackColor = Utilitarios.ColorFondoPanel
    End Sub

    Private Sub pnlLateral_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlLateral.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        Using br As New System.Drawing.Drawing2D.LinearGradientBrush(
            pnlLateral.ClientRectangle,
            Utilitarios.ColorPrimario,
            Utilitarios.ColorSecundario,
            System.Drawing.Drawing2D.LinearGradientMode.Vertical)
            g.FillRectangle(br, pnlLateral.ClientRectangle)
        End Using

        Dim cx As Integer = pnlLateral.Width \ 2
        Dim cy As Integer = 74
        Dim r As Integer = 28
        Dim rectCirc As New Rectangle(cx - r, cy - r, r * 2, r * 2)
        Using brBadge As New SolidBrush(Color.FromArgb(34, 255, 255, 255))
            g.FillEllipse(brBadge, rectCirc)
        End Using
        Using pCirc As New Pen(Color.FromArgb(225, 255, 255, 255), 2.0F)
            g.DrawEllipse(pCirc, rectCirc)
        End Using

        ' Icono vectorial de usuario corporativo (cabeza + hombros) recortado suavemente dentro del círculo
        Using gpClip As New System.Drawing.Drawing2D.GraphicsPath()
            gpClip.AddEllipse(cx - r + 2, cy - r + 2, (r - 2) * 2, (r - 2) * 2)
            Dim state As System.Drawing.Drawing2D.GraphicsState = g.Save()
            g.SetClip(gpClip)
            Using brAvatar As New SolidBrush(Color.White)
                g.FillEllipse(brAvatar, cx - 8, cy - 16, 16, 16)
                g.FillEllipse(brAvatar, cx - 18, cy + 4, 36, 30)
            End Using
            g.Restore(state)
        End Using

        Using fSub As New Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
              sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near}
            g.DrawString("Acceso" & Environment.NewLine & "Autorizado", fSub, Brushes.White, New RectangleF(8, cy + r + 12, pnlLateral.Width - 16, 48), sf)
        End Using
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
