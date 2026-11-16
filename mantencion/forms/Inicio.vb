Public NotInheritable Class Inicio

    Private Sub Inicio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DoubleBuffered = True
        Conexion.PrecalentarPool()

        lbl1.Text = "Sistema de Gestión"
        lblSubtitulo.Text = "Departamento Mantención"
        Version.Text = "Versión 2026.1 LTS"
        Copyright.Text = "Copyright © Cambiaso Hnos. S.A.C. 2026"

        Utilitarios.HabilitarDobleBuffer(pnlDerecho)
        Utilitarios.HabilitarDobleBuffer(pnlProgresoFondo)
    End Sub

    Private Shared Function CrearRutaCapsula(ByVal r As RectangleF) As System.Drawing.Drawing2D.GraphicsPath
        Dim gp As New System.Drawing.Drawing2D.GraphicsPath()
        Dim d As Single = Math.Max(2.0F, Math.Min(r.Height, r.Width))
        gp.AddArc(r.X, r.Y, d, d, 90, 180)
        gp.AddArc(r.Right - d, r.Y, d, d, 270, 180)
        gp.CloseFigure()
        Return gp
    End Function

    Private Sub pnlProgresoFondo_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlProgresoFondo.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim rOuter As New RectangleF(0.5F, 0.5F, pnlProgresoFondo.Width - 1.5F, pnlProgresoFondo.Height - 1.5F)
        Using gpOuter As System.Drawing.Drawing2D.GraphicsPath = CrearRutaCapsula(rOuter),
              brTrack As New SolidBrush(Color.White),
              pBorder As New Pen(Utilitarios.ColorPrimario, 1.1F)
            g.FillPath(brTrack, gpOuter)
            g.DrawPath(pBorder, gpOuter)
        End Using

        Dim fillW As Single = Math.Max(14.0F, Math.Min(pnlProgresoFondo.Width - 3.0F, pnlProgresoRelleno.Width))
        Dim rFill As New RectangleF(1.5F, 1.5F, fillW, pnlProgresoFondo.Height - 3.0F)
        Using gpFill As System.Drawing.Drawing2D.GraphicsPath = CrearRutaCapsula(rFill),
              brFill As New System.Drawing.Drawing2D.LinearGradientBrush(
                  New RectangleF(0, 0, Math.Max(20.0F, fillW + 2.0F), pnlProgresoFondo.Height),
                  Utilitarios.ColorDeepNavy,
                  Utilitarios.ColorSecundario,
                  System.Drawing.Drawing2D.LinearGradientMode.Horizontal)
            g.FillPath(brFill, gpFill)
        End Using
    End Sub

End Class
