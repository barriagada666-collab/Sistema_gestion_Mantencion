Public Class FrmPlanificarCiclos

    Private Sub FrmPlanificarCiclos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            fecha_inicio_ult_ciclo.Value = FrmMp.FechaIniCiclo.Value.Date.Add(New TimeSpan(FrmMp.HrInicioCiclo.Value.Hour, FrmMp.HrInicioCiclo.Value.Minute, 0))
            fecha_fin_ult_ciclo.Value = FrmMp.fechaFinCicloMp.Value.Date.Add(New TimeSpan(FrmMp.HrFinCiclo.Value.Hour, FrmMp.HrFinCiclo.Value.Minute, 0))
            txtUltimoCiclo.Text = FrmMp.txtIdCiclo.Text
            txtFrecuenciaPlan.Text = FrmMp.txtFrecuenciaMp.Text
            txtDuracionPlan.Text = FrmMp.txtDuracionCiclo.Text
            If cmbNumCiclos.Items.Count > 0 Then cmbNumCiclos.SelectedIndex = 0

            Dim formato As New FormatoGrillas()
            formato.grillasOT(grillaVistaPrevia)
            Utilitarios.AplicarTemaModerno(Me)
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub btnCrearVistaPrevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearVistaPrevia.Click
        Dim fecha_inicio As DateTime
        Dim fecha_fin As DateTime
        Dim hora_inicio As TimeSpan
        Dim hora_fin As TimeSpan
        Dim num_ciclos As Integer = 0
        Dim ciclo As Integer = 0
        Dim cont_ciclos As Integer = 1

        If Not IsNumeric(cmbNumCiclos.Text) OrElse Not IsNumeric(txtUltimoCiclo.Text) OrElse Not IsNumeric(txtFrecuenciaPlan.Text) OrElse Not IsNumeric(txtDuracionPlan.Text) Then
            MsgBox("Verifique los valores numéricos de planificación", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        grillaVistaPrevia.Rows.Clear()

        num_ciclos = CInt(cmbNumCiclos.Text)
        ciclo = CInt(txtUltimoCiclo.Text)
        fecha_inicio = fecha_inicio_ult_ciclo.Value.Date
        hora_inicio = New TimeSpan(fecha_inicio_ult_ciclo.Value.Hour, fecha_inicio_ult_ciclo.Value.Minute, 0)
        hora_fin = New TimeSpan(fecha_fin_ult_ciclo.Value.Hour, fecha_fin_ult_ciclo.Value.Minute, 0)

        While cont_ciclos <= num_ciclos
            fecha_inicio = fecha_inicio.AddHours(CDbl(txtFrecuenciaPlan.Text)).Date
            fecha_fin = fecha_inicio.AddHours(CDbl(txtDuracionPlan.Text)).Date
            ciclo = ciclo + 1
            Dim dtIniCompleta As DateTime = fecha_inicio.Add(hora_inicio)
            Dim dtFinCompleta As DateTime = fecha_fin.Add(hora_fin)
            With grillaVistaPrevia
                .Rows.Add()
                .Rows(.RowCount - 1).Cells(0).Value = ciclo
                .Rows(.RowCount - 1).Cells(1).Value = dtIniCompleta.ToString("dd-MM-yyyy HH:mm")
                .Rows(.RowCount - 1).Cells(2).Value = dtFinCompleta.ToString("dd-MM-yyyy HH:mm")
                .Rows(.RowCount - 1).Cells(3).Value = txtDuracionPlan.Text
            End With
            fecha_inicio = dtFinCompleta.Date.Add(hora_inicio)
            cont_ciclos = cont_ciclos + 1
        End While

        Utilitarios.AjustarColumnasGrilla(grillaVistaPrevia)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnCrearCiclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearCiclos.Click
        Dim mant_preventiva As New MantPreventiva
        Dim dt_ini As DateTime
        Dim dt_fin As DateTime
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        If FrmMp.grillaTareasCicloMp.RowCount = 0 Then
            MsgBox("No se pueden crear los ciclos sin tareas " & Chr(13) & "Vuelva a desplegar el último ciclo y agregue tareas", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        With grillaVistaPrevia
            For i = 0 To .RowCount - 1
                dt_ini = CDate(.Rows(i).Cells(1).Value)
                dt_fin = CDate(.Rows(i).Cells(2).Value)

                mant_preventiva.IngCicloMp(FrmMp.txtIdMant.Text, .Rows(i).Cells(0).Value, dt_ini.Date, dt_ini, dt_fin.Date, dt_fin, .Rows(i).Cells(3).Value, "Ciclo Planificado", "Pendiente", principal.lblUsuario.Text, cod_resp, resp)

                With FrmMp.grillaTareasCicloMp
                    Dim id_ciclo As Integer = CInt(grillaVistaPrevia.Rows(i).Cells(0).Value)

                    For j = 0 To .Rows.Count - 1
                        mant_preventiva.IngTareasCicloMp(FrmMp.txtIdMant.Text, id_ciclo, .Rows(j).Cells(1).Value, .Rows(j).Cells(2).Value, 0, "")
                    Next
                End With
            Next
        End With

        If cod_resp = 1 Then
            MsgBox(resp, MsgBoxStyle.Information, "Validación")
            mant_preventiva.LimpiarFrmMp()
            Me.Close()
        ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
            MsgBox(resp, MsgBoxStyle.Critical, "Error")
            mant_preventiva.LimpiarFrmMp()
            Me.Close()
        End If
    End Sub
End Class
