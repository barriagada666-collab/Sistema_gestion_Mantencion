Public Class FrmDetalleOt
    Public num_ot As String
    Private Sub FrmDetalleOt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim OT As New OT
        Dim DST_ORDEN_TRABAJO As New DataSet
        Dim DST_PERSONAL_OT As New DataSet
        Dim DST_INSUMOS_OT As New DataSet
        Dim DST_OT_EXTERNA As New DataSet

        With FrmInfOT.grillaInfOt
            OT.CrgOrdenTrabajo(.Rows(.CurrentRow.Index).Cells(0).Value, DST_ORDEN_TRABAJO)
        End With

        Try
            If DST_ORDEN_TRABAJO.Tables.Count > 0 Then
                lblNumOt.Text = DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("num_ot").ToString
                lblFechaRecepcion.Text = FormatDateTime(DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("fecha_recepcion").ToString, DateFormat.ShortDate) & " " & FormatDateTime(DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("hora_recepcion").ToString, DateFormat.ShortTime)
                lblFechaInicio.Text = FormatDateTime(DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("fecha_inicio_ot").ToString, DateFormat.ShortDate) & " " & FormatDateTime(DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("hora_inicio_ot").ToString, DateFormat.ShortTime)
                lblDetencion.Text = DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("detencion").ToString
                lblTipoDet.Text = DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("desc_intervencion").ToString
                lblTipoFalla.Text = DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("desc_tipo_falla").ToString
                lblSintomaFalla.Text = DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("desc_sintoma").ToString
                lblRecibidoPor.Text = DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("per_recepcion").ToString
                lblSolicitadoPor.Text = DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("per_solicita").ToString
                lblDescBreve.Text = DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("desc_breve").ToString
                lblEstadoOt.Text = DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("estado").ToString

                If DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("fecha_fin_ot").ToString <> "" Then
                    lblFechaTermino.Text = FormatDateTime(DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("fecha_fin_ot").ToString, DateFormat.ShortDate) & " " & FormatDateTime(DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("hora_fin_ot").ToString, DateFormat.ShortTime)
                    lblFechaCierre.Text = FormatDateTime(DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("fecha_entrega").ToString, DateFormat.ShortDate) & " " & FormatDateTime(DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("hora_entrega").ToString, DateFormat.ShortTime)
                Else
                    lblFechaTermino.Text = "Sin Fecha"
                    lblFechaCierre.Text = "Sin Fecha"
                End If

                lblDuracion.Text = DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("tiempo_detencion").ToString
                lblCerradoPor.Text = DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("per_cierre").ToString
                lblFalla.Text = DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("desc_modo_falla").ToString
                lblDescTecnica.Text = DST_ORDEN_TRABAJO.Tables(0).Rows(0).Item("desc_tecnica").ToString

                OT.CrgPersonalOt(num_ot, DST_PERSONAL_OT)
                OT.CrgInsumosOt(num_ot, DST_INSUMOS_OT)
                OT.CrgOtExterna(num_ot, DST_OT_EXTERNA)

                grillaPersonalDetalleOt.DataSource = DST_PERSONAL_OT.Tables(0)
                grillaInsumosOt.DataSource = DST_INSUMOS_OT.Tables(0)
                GrillaOtExternasDetalle.DataSource = DST_OT_EXTERNA.Tables(0)

                lblItem.Text = FrmInfOT.grillaInfOt.Rows(FrmInfOT.grillaInfOt.CurrentRow.Index).Cells(1).Value & "/" & FrmInfOT.grillaInfOt.Rows(FrmInfOT.grillaInfOt.CurrentRow.Index).Cells(2).Value
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        
    End Sub
End Class