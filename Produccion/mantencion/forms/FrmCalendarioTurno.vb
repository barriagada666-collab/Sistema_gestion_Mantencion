Public Class FrmCalendarioTurno

    Private Sub btn_salir_turnos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir_turnos.Click
        Me.Close()
    End Sub

    Private Sub FrmCalendarioTurno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim width As Double = Screen.PrimaryScreen.Bounds.Width
        Dim heigh As Double = Screen.PrimaryScreen.Bounds.Height
        Dim OT As New OT
        Dim utilitario As New Utilitarios

        Me.Width = width
        Me.Height = heigh

        grpTurnosPersonal.Enabled = False
        grpOperaciones.Enabled = False
        OT.autocompletar_personal(txtPersonalTurno)
        utilitario.crgComboTurnos(cmbTurno)
    End Sub

    Private Sub btn_crear_fechas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_crear_fechas.Click
        Dim fecha_inicio As DateTime
        Dim fecha_fin As DateTime
        Dim fecha As DateTime
        Dim formato_grid As New FormatoGrillas

        Try
            fecha_inicio = FormatDateTime(fecha_desde_cal.Value, DateFormat.ShortDate)
            fecha_fin = FormatDateTime(fecha_hasta_cal.Value, DateFormat.ShortDate)
            fecha = Format(fecha_inicio, "dd-MM-yy")

            If grillaCalendarioTurno.ColumnCount > 0 Then
                grillaCalendarioTurno.Columns.Clear()
            End If

            While fecha <= fecha_fin
                grillaCalendarioTurno.Columns.Add(fecha, fecha.ToString("dd-MM-yy"))
                fecha = DateAdd(DateInterval.Day, 1, fecha)
            End While
            formato_grid.grillaCalendario(grillaCalendarioTurno)
            grpTurnosPersonal.Enabled = True
            grpOperaciones.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Try
            If grillaCalendarioTurno.ColumnCount > 0 Then
                grillaCalendarioTurno.Columns.Clear()
            End If

            If grillaPersonalTurno.RowCount > 0 Then
                grillaPersonalTurno.Rows.Clear()
            End If

            fecha_desde_cal.Value = Now
            fecha_hasta_cal.Value = Now
            fecha_desde.Value = Now
            fecha_hasta.Value = Now
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub btn_agregar_personal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_personal.Click
        Dim calendario_personal As New CalendarioPersonal

        Try
            calendario_personal.agregarPersonalCalendario(txtPersonalTurno.Text, fecha_desde.Value, fecha_hasta.Value, cmbTurno.Text)
            calendario_personal.limpiarProgramacionTurno()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        
    End Sub
End Class