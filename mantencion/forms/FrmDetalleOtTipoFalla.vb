Public Class FrmDetalleOtTipoFalla
    Public personal As String = ""
    Public fecha_inicio As DateTime = DateTime.Today.AddDays(-30)
    Public fecha_termino As DateTime = DateTime.Today
    Public opcion As Integer = 0
    Public tipo_falla As String = ""
    Public turno As String = ""
    Public fecha As DateTime = Now
    Public estado As String = ""
    Public nodo_padre As String = ""
    Private Sub FrmDetalleOtTipoFalla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim OT As New OT
        Dim formato_grid As New FormatoGrillas
        Dim DST_OT_TIPO_FALLA As New DataSet

        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Me.Cursor = Cursors.WaitCursor
            grillaOtTipoFalla.SuspendLayout()
            Utilitarios.AplicarTemaModerno(Me)
            If opcion > 0 Then
                OT.CrgDetalleResumenOt(personal, fecha_inicio, fecha_termino, opcion, tipo_falla, turno, fecha, estado, nodo_padre, DST_OT_TIPO_FALLA)
            End If
            If DST_OT_TIPO_FALLA.Tables.Count > 0 Then
                grillaOtTipoFalla.DataSource = DST_OT_TIPO_FALLA.Tables(0)
                formato_grid.grillasOT(grillaOtTipoFalla)
                Utilitarios.AjustarColumnasGrilla(grillaOtTipoFalla)
            End If
            Label1.Text = "OT Recibidas : " & tipo_falla
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Detalle OT por Tipo de Falla", True, Me)
        Finally
            grillaOtTipoFalla.ResumeLayout(False)
            Me.Cursor = Cursors.Default
            Me.ResumeLayout(True)
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub
End Class