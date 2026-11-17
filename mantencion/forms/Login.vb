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
            If Not Usuario.UsuarioAutenticado Then
                MessageBox.Show(Me, "No fue posible cargar los permisos del usuario. Revise la conexión SQL.", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Password.Focus()
                Exit Sub
            End If
            principal.lblUsuario.Text = UCase(nombreUsuario)
            principal.Show()
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
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Using br As New System.Drawing.Drawing2D.LinearGradientBrush(
            pnlLateral.ClientRectangle,
            Utilitarios.ColorPrimario,
            Utilitarios.ColorSecundario,
            System.Drawing.Drawing2D.LinearGradientMode.Vertical)
            g.FillRectangle(br, pnlLateral.ClientRectangle)
        End Using

        ' Tarjeta blanca redondeada con el logotipo institucional de Cambiaso
        Dim cardW As Integer = Math.Max(80, pnlLateral.Width - 28)
        Dim cardH As Integer = 64
        Dim cardX As Integer = (pnlLateral.Width - cardW) \ 2
        Dim cardY As Integer = 34
        Dim rad As Integer = 10
        Dim d As Integer = rad * 2

        Using gpShadow As New System.Drawing.Drawing2D.GraphicsPath()
            gpShadow.AddArc(cardX + 2, cardY + 3, d, d, 180, 90)
            gpShadow.AddArc(cardX + 2 + cardW - d, cardY + 3, d, d, 270, 90)
            gpShadow.AddArc(cardX + 2 + cardW - d, cardY + 3 + cardH - d, d, d, 0, 90)
            gpShadow.AddArc(cardX + 2, cardY + 3 + cardH - d, d, d, 90, 90)
            gpShadow.CloseFigure()
            Using brShadow As New SolidBrush(Color.FromArgb(45, 0, 0, 0))
                g.FillPath(brShadow, gpShadow)
            End Using
        End Using

        Using gpCard As New System.Drawing.Drawing2D.GraphicsPath()
            gpCard.AddArc(cardX, cardY, d, d, 180, 90)
            gpCard.AddArc(cardX + cardW - d, cardY, d, d, 270, 90)
            gpCard.AddArc(cardX + cardW - d, cardY + cardH - d, d, d, 0, 90)
            gpCard.AddArc(cardX, cardY + cardH - d, d, d, 90, 90)
            gpCard.CloseFigure()
            Using brCard As New SolidBrush(Color.White)
                g.FillPath(brCard, gpCard)
            End Using
        End Using

        Try
            Dim logo As Image = My.Resources.Resources.cambiaso_logo_nuevo
            If logo IsNot Nothing AndAlso logo.Height > 0 Then
                Dim maxW As Integer = cardW - 18
                Dim maxH As Integer = cardH - 14
                Dim ratio As Double = Math.Min(CDbl(maxW) / logo.Width, CDbl(maxH) / logo.Height)
                Dim drawW As Integer = CInt(Math.Round(logo.Width * ratio))
                Dim drawH As Integer = CInt(Math.Round(logo.Height * ratio))
                Dim drawX As Integer = cardX + (cardW - drawW) \ 2
                Dim drawY As Integer = cardY + (cardH - drawH) \ 2
                g.DrawImage(logo, New Rectangle(drawX, drawY, drawW, drawH))
            End If
        Catch
        End Try

        Using fSub As New Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
              sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near}
            g.DrawString("Acceso" & Environment.NewLine & "Autorizado", fSub, Brushes.White, New RectangleF(8, cardY + cardH + 18, pnlLateral.Width - 16, 48), sf)
        End Using
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
