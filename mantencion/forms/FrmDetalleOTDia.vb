Public Class FrmDetalleOTDia
    Public personal As String = ""
    Public fecha_inicio As DateTime
    Public fecha_termino As DateTime
    Public opcion As Integer = 0
    Public tipo_falla As String = ""
    Public turno As String = ""
    Public fecha As DateTime
    Public estado As String = ""
    Public nodo_padre As String = ""
    Private Sub FrmDetalleOTDia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim OT As New OT
        Dim formato_grid As New FormatoGrillas
        Dim DST_OT_DIA As New DataSet

        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Me.Cursor = Cursors.WaitCursor
            grillaOtDetalleDia.SuspendLayout()
            Utilitarios.AplicarTemaModerno(Me)
            OT.CrgDetalleResumenOt(personal, fecha_inicio, fecha_termino, opcion, tipo_falla, turno, fecha, estado, nodo_padre, DST_OT_DIA)
            If DST_OT_DIA.Tables.Count > 0 Then
                grillaOtDetalleDia.DataSource = DST_OT_DIA.Tables(0)
                formato_grid.grillasOT(grillaOtDetalleDia)
                Utilitarios.AjustarColumnasGrilla(grillaOtDetalleDia)
            End If
            Label1.Text = "OT Recibidas En : " & fecha
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Detalle OT por Día", True, Me)
        Finally
            grillaOtDetalleDia.ResumeLayout(False)
            Me.Cursor = Cursors.Default
            Me.ResumeLayout(True)
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub
End Class