Public Class FrmDetalleOtEstado
    Public personal As String = ""
    Public fecha_inicio As DateTime
    Public fecha_termino As DateTime
    Public opcion As Integer = 0
    Public tipo_falla As String = ""
    Public turno As String = ""
    Public fecha As DateTime = Now
    Public estado As String = ""
    Public nodo_padre As String = ""
    Private Sub FrmDetalleOtEstado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim OT As New OT
        Dim formato_grid As New FormatoGrillas
        Dim DST_OT_ESTADO As New DataSet

        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Me.Cursor = Cursors.WaitCursor
            grillaDetalleOtEstado.SuspendLayout()
            Utilitarios.AplicarTemaModerno(Me)
            OT.CrgDetalleResumenOt(personal, fecha_inicio, fecha_termino, opcion, tipo_falla, turno, fecha, estado, nodo_padre, DST_OT_ESTADO)
            grillaDetalleOtEstado.DataSource = DST_OT_ESTADO.Tables(0)
            formato_grid.grillasOT(grillaDetalleOtEstado)
            Utilitarios.AjustarColumnasGrilla(grillaDetalleOtEstado)
            Label1.Text = "OT " & estado
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            grillaDetalleOtEstado.ResumeLayout(False)
            Me.Cursor = Cursors.Default
            Me.ResumeLayout(True)
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub
End Class