Public NotInheritable Class Inicio

    Private Sub Inicio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DoubleBuffered = True
        Conexion.PrecalentarPool()

        If My.Application.Info.Title <> "" Then
            lbl1.Text = My.Application.Info.Title
        Else
            lbl1.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        Version.Text = "Versión 2026.1"
        Copyright.Text = My.Application.Info.Copyright
    End Sub

End Class
