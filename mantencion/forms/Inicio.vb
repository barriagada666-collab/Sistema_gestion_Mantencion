Public NotInheritable Class Inicio

    Private Sub Inicio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DoubleBuffered = True
        Conexion.PrecalentarPool()

        lblKicker.Text = "CMMS · CAMBIASO HNOS. S.A.C."
        lbl1.Text = "Sistema de Gestión" & Environment.NewLine & "Departamento" & Environment.NewLine & "Mantención"
        Version.Text = "Versión 2026.1 LTS · Placilla, Valparaíso"
        Copyright.Text = "Copyright © Cambiaso Hnos. S.A.C. 2026"

        AplicarRegionRedondeada(pnlDerecho, 14)
        Utilitarios.HabilitarDobleBuffer(pnlDerecho)
    End Sub

    Private Shared Function CrearRutaRedondeada(ByVal r As Rectangle, ByVal radio As Integer) As System.Drawing.Drawing2D.GraphicsPath
        Dim gp As New System.Drawing.Drawing2D.GraphicsPath()
        Dim d As Integer = radio * 2
        gp.AddArc(r.X, r.Y, d, d, 180, 90)
        gp.AddArc(r.Right - d, r.Y, d, d, 270, 90)
        gp.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90)
        gp.AddArc(r.X, r.Bottom - d, d, d, 90, 90)
        gp.CloseFigure()
        Return gp
    End Function

    Private Shared Sub AplicarRegionRedondeada(ByVal ctrl As Control, ByVal radio As Integer)
        If ctrl Is Nothing OrElse ctrl.Width <= 0 OrElse ctrl.Height <= 0 Then Exit Sub
        Using gp As System.Drawing.Drawing2D.GraphicsPath = CrearRutaRedondeada(New Rectangle(0, 0, ctrl.Width, ctrl.Height), radio)
            ctrl.Region = New Region(gp)
        End Using
    End Sub

    Private Sub Inicio_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        ' Sombra suave bajo la tarjeta flotante pnlDerecho
        Dim sr As New Rectangle(pnlDerecho.Left + 3, pnlDerecho.Top + 5, pnlDerecho.Width, pnlDerecho.Height)
        Using gpSombra As System.Drawing.Drawing2D.GraphicsPath = CrearRutaRedondeada(sr, 14),
              brSombra As New SolidBrush(Color.FromArgb(75, 5, 18, 30))
            g.FillPath(brSombra, gpSombra)
        End Using
    End Sub

    Private Sub pnlProgresoRelleno_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlProgresoRelleno.Paint
        If pnlProgresoRelleno.Width <= 0 OrElse pnlProgresoRelleno.Height <= 0 Then Exit Sub
        Using br As New System.Drawing.Drawing2D.LinearGradientBrush(
            pnlProgresoRelleno.ClientRectangle,
            System.Drawing.Color.FromArgb(1, 145, 179),
            System.Drawing.Color.FromArgb(102, 201, 211),
            System.Drawing.Drawing2D.LinearGradientMode.Horizontal)
            e.Graphics.FillRectangle(br, pnlProgresoRelleno.ClientRectangle)
        End Using
    End Sub

End Class
