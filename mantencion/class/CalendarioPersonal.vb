Public Class CalendarioPersonal
    Public Sub agregarPersonalCalendario(ByVal personal As String, ByVal fecha_desde_turno As DateTime, ByVal fecha_hasta_turno As DateTime, ByVal turno As String)
        If fecha_desde_turno.Date > fecha_hasta_turno.Date Then Exit Sub
        Dim fecha As DateTime = fecha_desde_turno.Date
        Dim dias As Integer = CInt(DateDiff(DateInterval.Day, fecha_desde_turno.Date, fecha_hasta_turno.Date)) + 1
        If dias <= 0 Then Exit Sub

        With FrmCalendarioTurno
            If .grillaPersonalTurno.Columns.Count < 4 OrElse .grillaCalendarioTurno.ColumnCount = 0 Then Exit Sub

            Dim idxPers As Integer = .grillaPersonalTurno.Rows.Add()
            .grillaPersonalTurno.Rows(idxPers).Cells(0).Value = personal
            .grillaPersonalTurno.Rows(idxPers).Cells(1).Value = fecha_desde_turno.ToString("dd-MM-yyyy")
            .grillaPersonalTurno.Rows(idxPers).Cells(2).Value = fecha_hasta_turno.ToString("dd-MM-yyyy")
            .grillaPersonalTurno.Rows(idxPers).Cells(3).Value = turno

            Dim idxCal As Integer = .grillaCalendarioTurno.Rows.Add()
            Dim cont_celda As Integer = 0

            With .grillaCalendarioTurno
                For i As Integer = 0 To .ColumnCount - 1
                    If fecha.ToString("yyyyMMdd") = .Columns(i).Name Then
                        If turno = "Noche" Then
                            .Rows(idxCal).Cells(i).Style.BackColor = Utilitarios.ColorTurnoNocheFondo
                            .Rows(idxCal).Cells(i).Style.ForeColor = Utilitarios.ColorTurnoNocheTexto
                            .Rows(idxCal).Cells(i).Value = "N"
                        ElseIf turno = "Mañana" Then
                            .Rows(idxCal).Cells(i).Style.BackColor = Utilitarios.ColorTurnoMananaFondo
                            .Rows(idxCal).Cells(i).Style.ForeColor = Utilitarios.ColorTurnoMananaTexto
                            .Rows(idxCal).Cells(i).Value = "M"
                        ElseIf turno = "Tarde" Then
                            .Rows(idxCal).Cells(i).Style.BackColor = Utilitarios.ColorTurnoTardeFondo
                            .Rows(idxCal).Cells(i).Style.ForeColor = Utilitarios.ColorTurnoTardeTexto
                            .Rows(idxCal).Cells(i).Value = "T"
                        End If

                        cont_celda += 1
                        If cont_celda >= dias Then Exit For
                        fecha = fecha.AddDays(1)
                    End If
                Next
            End With
        End With
    End Sub

    Public Sub limpiarProgramacionTurno()
        With FrmCalendarioTurno
            .txtPersonalTurno.ResetText()
            .fecha_desde.Value = Now
            .fecha_hasta.Value = Now
            If .cmbTurno.Items.Count > 0 Then
                .cmbTurno.SelectedIndex = 0
            End If
        End With
    End Sub
End Class
