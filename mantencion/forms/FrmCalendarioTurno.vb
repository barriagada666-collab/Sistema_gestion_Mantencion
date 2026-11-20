Public Class FrmCalendarioTurno

    Private Sub btn_salir_turnos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir_turnos.Click
        Me.Close()
    End Sub

    Private Sub FrmCalendarioTurno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Dim OT As New OT
        Dim utilitario As New Utilitarios

        Try
            Utilitarios.AplicarTemaModerno(Me)
            Utilitarios.InicializarRangoPorDefecto(fecha_desde_cal, fecha_hasta_cal)
            Utilitarios.InicializarRangoPorDefecto(fecha_desde, fecha_hasta)
            grpTurnosPersonal.Enabled = False
            grpOperaciones.Enabled = False
            OT.autocompletar_personal(txtPersonalTurno)
            utilitario.crgComboTurnos(cmbTurno)
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub btn_crear_fechas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_crear_fechas.Click
        Dim fecha_inicio As DateTime = fecha_desde_cal.Value.Date
        Dim fecha_fin As DateTime = fecha_hasta_cal.Value.Date
        Dim formato_grid As New FormatoGrillas

        If fecha_inicio > fecha_fin Then
            MessageBox.Show(Me, "La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (fecha_fin - fecha_inicio).TotalDays > 93 Then
            MessageBox.Show(Me, "El rango máximo permitido para el calendario de turnos es de 93 días.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Try
            grillaCalendarioTurno.SuspendLayout()
            If grillaCalendarioTurno.ColumnCount > 0 Then
                grillaCalendarioTurno.Columns.Clear()
            End If

            Dim fecha As DateTime = fecha_inicio
            While fecha <= fecha_fin
                grillaCalendarioTurno.Columns.Add(fecha.ToString("yyyyMMdd"), fecha.ToString("dd-MM-yy"))
                fecha = fecha.AddDays(1)
            End While
            formato_grid.grillaCalendario(grillaCalendarioTurno)
            grpTurnosPersonal.Enabled = (grillaCalendarioTurno.ColumnCount > 0)
            grpOperaciones.Enabled = (grillaCalendarioTurno.ColumnCount > 0)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Calendario de Turnos (Crear Fechas)", True, Me)
        Finally
            grillaCalendarioTurno.ResumeLayout(True)
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

            grpTurnosPersonal.Enabled = False
            grpOperaciones.Enabled = False
            Utilitarios.InicializarRangoPorDefecto(fecha_desde_cal, fecha_hasta_cal)
            Utilitarios.InicializarRangoPorDefecto(fecha_desde, fecha_hasta)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Calendario de Turnos (Limpiar)", True, Me)
        End Try
    End Sub

    Private Sub btn_agregar_personal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_personal.Click
        If grillaCalendarioTurno.ColumnCount = 0 Then
            MessageBox.Show(Me, "Primero genere las fechas del calendario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(txtPersonalTurno.Text) OrElse String.IsNullOrWhiteSpace(cmbTurno.Text) Then
            MessageBox.Show(Me, "Debe ingresar el técnico y seleccionar el turno.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPersonalTurno.Focus()
            Exit Sub
        End If
        If fecha_desde.Value.Date > fecha_hasta.Value.Date Then
            MessageBox.Show(Me, "La fecha 'Desde' del turno no puede ser mayor que la fecha 'Hasta'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim calendario_personal As New CalendarioPersonal
        Try
            calendario_personal.agregarPersonalCalendario(txtPersonalTurno.Text.Trim(), fecha_desde.Value, fecha_hasta.Value, cmbTurno.Text)
            calendario_personal.limpiarProgramacionTurno()
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Calendario de Turnos (Agregar Personal)", True, Me)
        End Try
    End Sub

    Private Sub btn_guardar_turno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_turno.Click
        If grillaPersonalTurno.RowCount = 0 OrElse grillaCalendarioTurno.ColumnCount = 0 Then
            MessageBox.Show(Me, "Debe agregar al menos una asignación de turno antes de exportar o guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Try
            Dim hojas As New List(Of KeyValuePair(Of String, DataGridView)) From {
                New KeyValuePair(Of String, DataGridView)("Asignaciones", grillaPersonalTurno),
                New KeyValuePair(Of String, DataGridView)("Calendario", grillaCalendarioTurno)
            }
            Utilitarios.ExportarGrillasAExcelNativo(hojas, "Calendario_Turnos", "Programación de Turnos de Personal")
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Calendario de Turnos (Guardar)", True, Me)
        End Try
    End Sub
End Class
