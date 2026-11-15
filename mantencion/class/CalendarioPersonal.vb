Imports System.Data.SqlClient
Public Class CalendarioPersonal
    Public Sub agregarPersonalCalendario(ByVal personal As String, ByVal fecha_desde_turno As DateTime, ByVal fecha_hasta_turno As DateTime, ByVal turno As String)
        Dim fecha As DateTime = fecha_desde_turno.Date
        Dim dias As Integer = 0
        Dim cont_celda As Integer = 0

        With FrmCalendarioTurno
            .grillaPersonalTurno.Rows.Add()

            .grillaPersonalTurno.Rows(.grillaPersonalTurno.RowCount - 1).Cells(0).Value = personal
            .grillaPersonalTurno.Rows(.grillaPersonalTurno.RowCount - 1).Cells(1).Value = fecha_desde_turno.ToString("dd-MM-yyyy")
            .grillaPersonalTurno.Rows(.grillaPersonalTurno.RowCount - 1).Cells(2).Value = fecha_hasta_turno.ToString("dd-MM-yyyy")
            .grillaPersonalTurno.Rows(.grillaPersonalTurno.RowCount - 1).Cells(3).Value = turno

            dias = DateDiff(DateInterval.Day, fecha_desde_turno.Date, fecha_hasta_turno.Date) + 1
            .grillaCalendarioTurno.Rows.Add()

            With FrmCalendarioTurno.grillaCalendarioTurno
                For i = 0 To .ColumnCount - 1
                    If fecha.ToString("yyyyMMdd") = .Columns(i).Name Then
                        If turno = "Noche" Then
                            .Rows(.RowCount - 1).Cells(i).Style.BackColor = Utilitarios.ColorTurnoNocheFondo
                            .Rows(.RowCount - 1).Cells(i).Style.ForeColor = Utilitarios.ColorTurnoNocheTexto
                            .Rows(.RowCount - 1).Cells(i).Value = "N"
                        ElseIf turno = "Mañana" Then
                            .Rows(.RowCount - 1).Cells(i).Style.BackColor = Utilitarios.ColorTurnoMananaFondo
                            .Rows(.RowCount - 1).Cells(i).Style.ForeColor = Utilitarios.ColorTurnoMananaTexto
                            .Rows(.RowCount - 1).Cells(i).Value = "M"
                        ElseIf turno = "Tarde" Then
                            .Rows(.RowCount - 1).Cells(i).Style.BackColor = Utilitarios.ColorTurnoTardeFondo
                            .Rows(.RowCount - 1).Cells(i).Style.ForeColor = Utilitarios.ColorTurnoTardeTexto
                            .Rows(.RowCount - 1).Cells(i).Value = "T"
                        End If

                        cont_celda = cont_celda + 1
                        If cont_celda < dias Then
                            fecha = DateAdd(DateInterval.Day, 1, fecha)
                        End If
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
