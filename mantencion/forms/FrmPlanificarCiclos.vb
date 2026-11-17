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
        Try
            Dim fecha_inicio As DateTime
            Dim hora_inicio As TimeSpan
            Dim hora_fin As TimeSpan
            Dim num_ciclos As Integer = 0
            Dim ciclo As Integer = 0
            Dim frecuenciaHoras As Double = 0
            Dim duracionHoras As Double = 0
            Dim cont_ciclos As Integer = 1

            If Not Integer.TryParse(cmbNumCiclos.Text.Trim(), num_ciclos) OrElse num_ciclos <= 0 OrElse
               Not Integer.TryParse(txtUltimoCiclo.Text.Trim(), ciclo) OrElse
               Not Double.TryParse(txtFrecuenciaPlan.Text.Trim(), frecuenciaHoras) OrElse frecuenciaHoras <= 0 OrElse
               Not Double.TryParse(txtDuracionPlan.Text.Trim(), duracionHoras) OrElse duracionHoras < 0 Then
                MsgBox("Verifique los valores numéricos de planificación (frecuencia > 0 y duración >= 0).", MsgBoxStyle.Exclamation, "Validación")
                Exit Sub
            End If

            grillaVistaPrevia.Rows.Clear()

            fecha_inicio = fecha_inicio_ult_ciclo.Value.Date
            hora_inicio = New TimeSpan(fecha_inicio_ult_ciclo.Value.Hour, fecha_inicio_ult_ciclo.Value.Minute, 0)
            hora_fin = New TimeSpan(fecha_fin_ult_ciclo.Value.Hour, fecha_fin_ult_ciclo.Value.Minute, 0)

            While cont_ciclos <= num_ciclos
                Dim dtIniCompleta As DateTime = fecha_inicio.Add(hora_inicio).AddHours(frecuenciaHoras)
                Dim dtFinCompleta As DateTime = dtIniCompleta.AddHours(duracionHoras)
                If hora_fin > hora_inicio AndAlso duracionHoras = 0 Then
                    dtFinCompleta = dtIniCompleta.Date.Add(hora_fin)
                End If
                ciclo += 1
                With grillaVistaPrevia
                    .Rows.Add()
                    .Rows(.RowCount - 1).Cells(0).Value = ciclo
                    .Rows(.RowCount - 1).Cells(1).Value = dtIniCompleta.ToString("dd-MM-yyyy HH:mm")
                    .Rows(.RowCount - 1).Cells(2).Value = dtFinCompleta.ToString("dd-MM-yyyy HH:mm")
                    .Rows(.RowCount - 1).Cells(3).Value = duracionHoras.ToString("0.0")
                End With
                fecha_inicio = dtFinCompleta.Date
                cont_ciclos += 1
            End While

            Utilitarios.AjustarColumnasGrilla(grillaVistaPrevia)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Planificar Ciclos (Vista Previa)", True, Me)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnCrearCiclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearCiclos.Click
        If Not Usuario.PermisoIngMp AndAlso Not Usuario.PermisoGuardarMp Then
            MsgBox("No tiene permisos para crear ciclos de mantención preventiva.", MsgBoxStyle.Exclamation, "Seguridad")
            Exit Sub
        End If

        If grillaVistaPrevia.RowCount = 0 Then
            MsgBox("Debe generar primero la vista previa de ciclos.", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        If FrmMp.grillaTareasCicloMp.RowCount = 0 Then
            MsgBox("No se pueden crear los ciclos sin tareas " & Chr(13) & "Vuelva a desplegar el último ciclo y agregue tareas", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Dim mant_preventiva As New MantPreventiva
        Dim dt_ini As DateTime
        Dim dt_fin As DateTime
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim cultura As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture

        Try
            With grillaVistaPrevia
                For i = 0 To .RowCount - 1
                    If .Rows(i).IsNewRow Then Continue For
                    Dim sIni As String = If(.Rows(i).Cells(1).Value Is Nothing, String.Empty, .Rows(i).Cells(1).Value.ToString())
                    Dim sFin As String = If(.Rows(i).Cells(2).Value Is Nothing, String.Empty, .Rows(i).Cells(2).Value.ToString())
                    If Not DateTime.TryParseExact(sIni, "dd-MM-yyyy HH:mm", cultura, Globalization.DateTimeStyles.None, dt_ini) AndAlso
                       Not DateTime.TryParse(sIni, dt_ini) Then
                        MsgBox("Fecha de inicio inválida en fila " & (i + 1), MsgBoxStyle.Exclamation, "Validación")
                        Exit Sub
                    End If
                    If Not DateTime.TryParseExact(sFin, "dd-MM-yyyy HH:mm", cultura, Globalization.DateTimeStyles.None, dt_fin) AndAlso
                       Not DateTime.TryParse(sFin, dt_fin) Then
                        MsgBox("Fecha de término inválida en fila " & (i + 1), MsgBoxStyle.Exclamation, "Validación")
                        Exit Sub
                    End If

                    Dim idCicloTxt As String = If(.Rows(i).Cells(0).Value Is Nothing, "0", .Rows(i).Cells(0).Value.ToString())
                    Dim durTxt As String = If(.Rows(i).Cells(3).Value Is Nothing, "0", .Rows(i).Cells(3).Value.ToString())
                    mant_preventiva.IngCicloMp(FrmMp.txtIdMant.Text, idCicloTxt, dt_ini.Date, dt_ini, dt_fin.Date, dt_fin, durTxt, "Ciclo Planificado", "Pendiente", principal.lblUsuario.Text, cod_resp, resp)

                    Dim id_ciclo As Integer = 0
                    If Integer.TryParse(idCicloTxt, id_ciclo) Then
                        For j = 0 To FrmMp.grillaTareasCicloMp.Rows.Count - 1
                            Dim tRow As DataGridViewRow = FrmMp.grillaTareasCicloMp.Rows(j)
                            If tRow.IsNewRow Then Continue For
                            Dim idTareaTxt As String = If(tRow.Cells(1).Value Is Nothing, String.Empty, tRow.Cells(1).Value.ToString())
                            Dim idNodoTxt As String = If(tRow.Cells(2).Value Is Nothing, String.Empty, tRow.Cells(2).Value.ToString())
                            If Not String.IsNullOrEmpty(idTareaTxt) AndAlso Not String.IsNullOrEmpty(idNodoTxt) Then
                                mant_preventiva.IngTareasCicloMp(FrmMp.txtIdMant.Text, id_ciclo.ToString(), idTareaTxt, idNodoTxt, "0", String.Empty)
                            End If
                        Next
                    End If
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
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Planificar Ciclos (Crear Ciclos)", True, Me)
        End Try
    End Sub
End Class
