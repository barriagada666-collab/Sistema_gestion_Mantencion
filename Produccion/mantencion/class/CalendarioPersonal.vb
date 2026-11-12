Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class CalendarioPersonal
    Public Sub agregarPersonalCalendario(ByVal personal As String, ByVal fecha_desde_turno As DateTime, ByVal fecha_hasta_turno As DateTime, ByVal turno As String)
        Dim fecha_inicio As DateTime = Now
        Dim fecha_termino As DateTime = Now
        Dim fecha As DateTime = Now
        Dim dias As Integer = 0
        Dim cont_celda As Integer = 0

        With FrmCalendarioTurno
            .grillaPersonalTurno.Rows.Add()

            .grillaPersonalTurno.Rows(.grillaPersonalTurno.RowCount - 1).Cells(0).Value = personal
            .grillaPersonalTurno.Rows(.grillaPersonalTurno.RowCount - 1).Cells(1).Value = FormatDateTime(fecha_desde_turno, DateFormat.ShortDate)
            .grillaPersonalTurno.Rows(.grillaPersonalTurno.RowCount - 1).Cells(2).Value = FormatDateTime(fecha_hasta_turno, DateFormat.ShortDate)
            .grillaPersonalTurno.Rows(.grillaPersonalTurno.RowCount - 1).Cells(3).Value = turno


            fecha = FormatDateTime(fecha_desde_turno, DateFormat.ShortDate)
            dias = DateDiff(DateInterval.Day, fecha_desde_turno, fecha_hasta_turno) + 1
            .grillaCalendarioTurno.Rows.Add()

            With FrmCalendarioTurno.grillaCalendarioTurno
                For i = 0 To .ColumnCount - 1
                    If fecha = .Columns(i).Name Then
                        If turno = "Noche" Then
                            .Rows(.RowCount - 1).Cells(i).Style.BackColor = Color.YellowGreen
                            .Rows(.RowCount - 1).Cells(i).Value = "N"
                        ElseIf turno = "Mañana" Then
                            .Rows(.RowCount - 1).Cells(i).Style.BackColor = Color.Orange
                            .Rows(.RowCount - 1).Cells(i).Value = "M"
                        ElseIf turno = "Tarde" Then
                            .Rows(.RowCount - 1).Cells(i).Style.BackColor = Color.PaleTurquoise
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
            .cmbTurno.Text = .cmbTurno.Items(0)
        End With
    End Sub
End Class
