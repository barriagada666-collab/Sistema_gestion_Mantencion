Public Class FrmDetalleOtTurno
    Public personal As String = ""
    Public fecha_inicio As DateTime
    Public fecha_termino As DateTime
    Public opcion As Integer = 0
    Public tipo_falla As String = ""
    Public turno As String = ""
    Public fecha As DateTime = Now
    Public estado As String = ""
    Public nodo_padre As String = ""
    Private Sub FrmDetalleOtTurno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim OT As New OT
        Dim formato_grid As New FormatoGrillas
        Dim DST_OT_TURNO As New DataSet

        Try
            OT.CrgDetalleResumenOt(personal, fecha_inicio, fecha_termino, opcion, tipo_falla, turno, fecha, estado, nodo_padre, DST_OT_TURNO)
            grillaOtDetalleTurno.DataSource = DST_OT_TURNO.Tables(0)
            formato_grid.grillasOT(grillaOtDetalleTurno)
            Label1.Text = "OT Recibidas En : " & turno
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class