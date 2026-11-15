Public Class FrmDetalleOTPorTecnico
    Public personal As String = ""
    Public fecha_inicio As DateTime
    Public fecha_termino As DateTime
    Public opcion As Integer = 0
    Public tipo_falla As String = ""
    Public turno As String = ""
    Public fecha As DateTime = Now
    Public estado As String = ""
    Public nodo_padre As String = ""
    Private Sub FrmDetalleOTPorTecnico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim OT As New OT
        Dim formato_grid As New FormatoGrillas
        Dim DST_OT_TECNICOS As New DataSet

        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Me.Cursor = Cursors.WaitCursor
            grillaDetalleOtTecnicos.SuspendLayout()
            Utilitarios.AplicarTemaModerno(Me)
            OT.CrgDetalleResumenOt(personal, fecha_inicio, fecha_termino, opcion, tipo_falla, turno, fecha, estado, nodo_padre, DST_OT_TECNICOS)
            grillaDetalleOtTecnicos.DataSource = DST_OT_TECNICOS.Tables(0)
            formato_grid.grillasOT(grillaDetalleOtTecnicos)
            Utilitarios.AjustarColumnasGrilla(grillaDetalleOtTecnicos)
            Label1.Text = "OT Ejecutadas de " & personal
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Detalle OT por Técnico", True, Me)
        Finally
            grillaDetalleOtTecnicos.ResumeLayout(False)
            Me.Cursor = Cursors.Default
            Me.ResumeLayout(True)
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub
End Class