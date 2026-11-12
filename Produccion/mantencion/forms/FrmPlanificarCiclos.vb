Public Class FrmPlanificarCiclos

    Private Sub FrmPlanificarCiclos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fecha_inicio_ult_ciclo.Value = FormatDateTime(FrmMp.FechaIniCiclo.Value, DateFormat.ShortDate) & " " & FormatDateTime(FrmMp.HrInicioCiclo.Value, DateFormat.ShortTime)
        fecha_fin_ult_ciclo.Value = FormatDateTime(FrmMp.fechaFinCicloMp.Value, DateFormat.ShortDate) & " " & FormatDateTime(FrmMp.HrFinCiclo.Value, DateFormat.ShortTime)
        txtUltimoCiclo.Text = FrmMp.txtIdCiclo.Text
        txtFrecuenciaPlan.Text = FrmMp.txtFrecuenciaMp.Text
        txtDuracionPlan.Text = FrmMp.txtDuracionCiclo.Text
        cmbNumCiclos.Text = cmbNumCiclos.Items(0)
    End Sub

    Private Sub btnCrearVistaPrevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearVistaPrevia.Click
        Dim fecha_inicio As DateTime
        Dim fecha_fin As DateTime
        Dim hora_inicio As DateTime
        Dim hora_fin As DateTime
        Dim num_ciclos As Integer = 0
        Dim ciclo As Integer = 0
        Dim cont_ciclos As Integer = 1

        num_ciclos = CInt(cmbNumCiclos.Text)
        ciclo = CInt(txtUltimoCiclo.Text)
        fecha_inicio = FormatDateTime(fecha_inicio_ult_ciclo.Value, DateFormat.ShortDate)
        hora_inicio = FormatDateTime(fecha_inicio_ult_ciclo.Value, DateFormat.ShortTime)
        hora_fin = FormatDateTime(fecha_fin_ult_ciclo.Value, DateFormat.ShortTime)
        While cont_ciclos <= num_ciclos
            fecha_inicio = FormatDateTime(fecha_inicio.AddHours(CDbl(txtFrecuenciaPlan.Text)), DateFormat.ShortDate)
            fecha_fin = FormatDateTime(fecha_inicio.AddHours(CDbl(txtDuracionPlan.Text)), DateFormat.ShortDate)
            ciclo = ciclo + 1
            With grillaVistaPrevia
                .Rows.Add()
                .Rows(.RowCount - 1).Cells(0).Value = ciclo
                .Rows(.RowCount - 1).Cells(1).Value = FormatDateTime(fecha_inicio, DateFormat.ShortDate) & " " & FormatDateTime(hora_inicio, DateFormat.ShortTime)
                .Rows(.RowCount - 1).Cells(2).Value = FormatDateTime(fecha_fin, DateFormat.ShortDate) & " " & FormatDateTime(hora_fin, DateFormat.ShortTime)
                .Rows(.RowCount - 1).Cells(3).Value = txtDuracionPlan.Text
            End With
            fecha_inicio = FormatDateTime(fecha_fin, DateFormat.ShortDate) & " " & FormatDateTime(hora_inicio, DateFormat.ShortTime)
            cont_ciclos = cont_ciclos + 1
        End While

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnCrearCiclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearCiclos.Click
        Dim mant_preventiva As New MantPreventiva
        Dim fecha_inicio As DateTime
        Dim hora_inicio As DateTime
        Dim fecha_fin As DateTime
        Dim hora_fin As DateTime
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        If FrmMp.grillaTareasCicloMp.RowCount = 0 Then
            MsgBox("No se pueden crear los ciclos sin tareas " & Chr(13) & "Vuelva a desplegar el último ciclo y agregue tareas", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        With grillaVistaPrevia
            For i = 0 To .RowCount - 1
                fecha_inicio = FormatDateTime(.Rows(i).Cells(1).Value, DateFormat.ShortDate)
                hora_inicio = FormatDateTime(.Rows(i).Cells(1).Value, DateFormat.ShortTime)
                fecha_fin = FormatDateTime(.Rows(i).Cells(2).Value, DateFormat.ShortDate)
                hora_fin = FormatDateTime(.Rows(i).Cells(2).Value, DateFormat.ShortTime)

                mant_preventiva.IngCicloMp(FrmMp.txtIdMant.Text, .Rows(i).Cells(0).Value, fecha_inicio, hora_inicio, fecha_fin, hora_fin, .Rows(i).Cells(3).Value, "Ciclo Planificado", "Pendiente", principal.lblUsuario.Text, cod_resp, resp)

                With FrmMp.grillaTareasCicloMp
                    Dim id_ciclo As Integer = 0

                    For j = 0 To .Rows.Count - 1
                        If .RowCount > 0 Then
                            id_ciclo = grillaVistaPrevia.Rows(i).Cells(0).Value
                            mant_preventiva.IngTareasCicloMp(FrmMp.txtIdMant.Text, id_ciclo, .Rows(j).Cells(1).Value, .Rows(j).Cells(2).Value, 0, "")

                        End If
                    Next
                End With
            Next
        End With

        If cod_resp = 1 Then
            MsgBox(resp, MsgBoxStyle.Information, "Validación")
            mant_preventiva.LimpiarFrmMp()
            Me.Close()
        Else
            MsgBox(resp, MsgBoxStyle.Critical, "Error")
            mant_preventiva.LimpiarFrmMp()
            Me.Close()
        End If
    End Sub
End Class