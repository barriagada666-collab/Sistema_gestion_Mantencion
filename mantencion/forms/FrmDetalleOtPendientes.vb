Public Class FrmDetalleOtPendientes
    Public personal As String = ""
    Public fecha_inicio As DateTime
    Public fecha_termino As DateTime
    Public opcion As Integer = 0
    Public tipo_falla As String = ""
    Public turno As String = ""
    Public fecha As DateTime = Now
    Public estado As String = ""
    Public nodo_padre As String = ""

    Private Sub FrmDetalleOtPendientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim OT As New OT
        Dim formato_grid As New FormatoGrillas
        Dim DST_OT_PEND As New DataSet
        Try
            Me.Cursor = Cursors.WaitCursor
            Utilitarios.AplicarTemaModerno(Me)
            OT.CrgDetalleResumenOt(personal, fecha_inicio, fecha_termino, opcion, tipo_falla, turno, fecha, estado, nodo_padre, DST_OT_PEND)
            grillaDetalleOtPend.DataSource = DST_OT_PEND.Tables(0)
            formato_grid.grillasOT(grillaDetalleOtPend)
            Utilitarios.AjustarColumnasGrilla(grillaDetalleOtPend)
            Label1.Text = "OT Recibidas Pendientes de " & personal
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Me.Cursor = Cursors.Default
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub
End Class