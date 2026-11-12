Public Class FrmDetalleOt
    Public num_ot As String

    Private Function FormatearFechaHora(ByVal fechaObj As Object, ByVal horaObj As Object, Optional ByVal fallback As String = "Sin Fecha") As String
        If fechaObj Is Nothing OrElse IsDBNull(fechaObj) Then Return fallback
        Dim fStr As String = fechaObj.ToString().Trim()
        If String.IsNullOrEmpty(fStr) Then Return fallback
        Dim fDate As DateTime
        If Not DateTime.TryParse(fStr, fDate) Then Return fallback

        Dim hStr As String = If(horaObj IsNot Nothing AndAlso Not IsDBNull(horaObj), horaObj.ToString().Trim(), "")
        Dim hDate As DateTime
        If Not String.IsNullOrEmpty(hStr) AndAlso DateTime.TryParse(hStr, hDate) Then
            Return fDate.ToString("dd-MM-yyyy") & " " & hDate.ToString("HH:mm")
        End If
        Return fDate.ToString("dd-MM-yyyy")
    End Function

    Private Sub FrmDetalleOt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim OT As New OT
        Dim DST_ORDEN_TRABAJO As New DataSet
        Dim DST_PERSONAL_OT As New DataSet
        Dim DST_INSUMOS_OT As New DataSet
        Dim DST_OT_EXTERNA As New DataSet

        Utilitarios.AplicarTemaModerno(Me)

        Dim formato As New FormatoGrillas()
        formato.grillasOT(grillaPersonalDetalleOt)
        formato.grillasOT(grillaInsumosOt)
        formato.grillasOT(GrillaOtExternasDetalle)

        Try
            If FrmInfOT.grillaInfOt.CurrentRow IsNot Nothing Then
                With FrmInfOT.grillaInfOt
                    OT.CrgOrdenTrabajo(.Rows(.CurrentRow.Index).Cells(0).Value.ToString(), DST_ORDEN_TRABAJO)
                End With
            End If

            If DST_ORDEN_TRABAJO.Tables.Count > 0 AndAlso DST_ORDEN_TRABAJO.Tables(0).Rows.Count > 0 Then
                Dim row0 As DataRow = DST_ORDEN_TRABAJO.Tables(0).Rows(0)
                lblNumOt.Text = If(IsDBNull(row0("num_ot")), "", row0("num_ot").ToString())
                lblFechaRecepcion.Text = FormatearFechaHora(row0("fecha_recepcion"), row0("hora_recepcion"))
                lblFechaInicio.Text = FormatearFechaHora(row0("fecha_inicio_ot"), row0("hora_inicio_ot"))
                lblDetencion.Text = If(IsDBNull(row0("detencion")), "", row0("detencion").ToString())
                lblTipoDet.Text = If(IsDBNull(row0("desc_intervencion")), "", row0("desc_intervencion").ToString())
                lblTipoFalla.Text = If(IsDBNull(row0("desc_tipo_falla")), "", row0("desc_tipo_falla").ToString())
                lblSintomaFalla.Text = If(IsDBNull(row0("desc_sintoma")), "", row0("desc_sintoma").ToString())
                lblRecibidoPor.Text = If(IsDBNull(row0("per_recepcion")), "", row0("per_recepcion").ToString())
                lblSolicitadoPor.Text = If(IsDBNull(row0("per_solicita")), "", row0("per_solicita").ToString())
                lblDescBreve.Text = If(IsDBNull(row0("desc_breve")), "", row0("desc_breve").ToString())
                lblEstadoOt.Text = If(IsDBNull(row0("estado")), "", row0("estado").ToString())

                lblFechaTermino.Text = FormatearFechaHora(row0("fecha_fin_ot"), row0("hora_fin_ot"), "Sin Fecha")
                lblFechaCierre.Text = FormatearFechaHora(row0("fecha_entrega"), row0("hora_entrega"), "Sin Fecha")

                lblDuracion.Text = If(IsDBNull(row0("tiempo_detencion")), "", row0("tiempo_detencion").ToString())
                lblCerradoPor.Text = If(IsDBNull(row0("per_cierre")), "", row0("per_cierre").ToString())
                lblFalla.Text = If(IsDBNull(row0("desc_modo_falla")), "", row0("desc_modo_falla").ToString())
                lblDescTecnica.Text = If(IsDBNull(row0("desc_tecnica")), "", row0("desc_tecnica").ToString())

                OT.CrgPersonalOt(num_ot, DST_PERSONAL_OT)
                OT.CrgInsumosOt(num_ot, DST_INSUMOS_OT)
                OT.CrgOtExterna(num_ot, DST_OT_EXTERNA)

                If DST_PERSONAL_OT.Tables.Count > 0 Then grillaPersonalDetalleOt.DataSource = DST_PERSONAL_OT.Tables(0)
                If DST_INSUMOS_OT.Tables.Count > 0 Then grillaInsumosOt.DataSource = DST_INSUMOS_OT.Tables(0)
                If DST_OT_EXTERNA.Tables.Count > 0 Then GrillaOtExternasDetalle.DataSource = DST_OT_EXTERNA.Tables(0)

                Utilitarios.AjustarColumnasGrilla(grillaPersonalDetalleOt)
                Utilitarios.AjustarColumnasGrilla(grillaInsumosOt)
                Utilitarios.AjustarColumnasGrilla(GrillaOtExternasDetalle)

                If FrmInfOT.grillaInfOt.CurrentRow IsNot Nothing Then
                    lblItem.Text = FrmInfOT.grillaInfOt.Rows(FrmInfOT.grillaInfOt.CurrentRow.Index).Cells(1).Value & "/" & FrmInfOT.grillaInfOt.Rows(FrmInfOT.grillaInfOt.CurrentRow.Index).Cells(2).Value
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub
End Class