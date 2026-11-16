Public NotInheritable Class Inicio

    Private Sub Inicio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DoubleBuffered = True
        Conexion.PrecalentarPool()

        lbl1.Text = "Sistema de Gestión" & Environment.NewLine & "Departamento" & Environment.NewLine & "Mantención"
        Version.Text = "Versión 2026.1"
        Copyright.Text = "Copyright © Cambiaso Hnos. S.A.C. 2026"
    End Sub

    Private Sub pnlIzquierdo_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlIzquierdo.Paint
        Using br As New System.Drawing.Drawing2D.LinearGradientBrush(
            pnlIzquierdo.ClientRectangle,
            System.Drawing.Color.FromArgb(2, 94, 135),
            System.Drawing.Color.FromArgb(1, 68, 102),
            System.Drawing.Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(br, pnlIzquierdo.ClientRectangle)
        End Using
    End Sub

End Class
