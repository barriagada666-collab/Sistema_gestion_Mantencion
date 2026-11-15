<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCalendarioTurno
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grpTurnosPersonal = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTurno = New System.Windows.Forms.Label
        Me.cmbTurno = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.fecha_hasta = New System.Windows.Forms.DateTimePicker
        Me.fecha_desde = New System.Windows.Forms.DateTimePicker
        Me.txtPersonalTurno = New System.Windows.Forms.TextBox
        Me.grillaPersonalTurno = New System.Windows.Forms.DataGridView
        Me.grillaCalendarioTurno = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.grpOperaciones = New System.Windows.Forms.Panel
        Me.btn_salir_turnos = New System.Windows.Forms.Button
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.btn_guardar_turno = New System.Windows.Forms.Button
        Me.grpFechasIniciales = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn_agregar_personal = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.fecha_desde_cal = New System.Windows.Forms.DateTimePicker
        Me.fecha_hasta_cal = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btn_crear_fechas = New System.Windows.Forms.Button
        Me.nom_personal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha_desde_personal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha_hasta_personal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turno_personal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grpTurnosPersonal.SuspendLayout()
        CType(Me.grillaPersonalTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grillaCalendarioTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOperaciones.SuspendLayout()
        Me.grpFechasIniciales.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpTurnosPersonal
        '
        Me.grpTurnosPersonal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grpTurnosPersonal.Controls.Add(Me.btn_agregar_personal)
        Me.grpTurnosPersonal.Controls.Add(Me.Label4)
        Me.grpTurnosPersonal.Controls.Add(Me.lblTurno)
        Me.grpTurnosPersonal.Controls.Add(Me.cmbTurno)
        Me.grpTurnosPersonal.Controls.Add(Me.Label2)
        Me.grpTurnosPersonal.Controls.Add(Me.Label1)
        Me.grpTurnosPersonal.Controls.Add(Me.fecha_hasta)
        Me.grpTurnosPersonal.Controls.Add(Me.fecha_desde)
        Me.grpTurnosPersonal.Controls.Add(Me.txtPersonalTurno)
        Me.grpTurnosPersonal.Location = New System.Drawing.Point(12, 110)
        Me.grpTurnosPersonal.Name = "grpTurnosPersonal"
        Me.grpTurnosPersonal.Size = New System.Drawing.Size(606, 88)
        Me.grpTurnosPersonal.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Personal"
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurno.Location = New System.Drawing.Point(405, 25)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(39, 15)
        Me.lblTurno.TabIndex = 6
        Me.lblTurno.Text = "Turno"
        '
        'cmbTurno
        '
        Me.cmbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurno.FormattingEnabled = True
        Me.cmbTurno.Location = New System.Drawing.Point(408, 40)
        Me.cmbTurno.Name = "cmbTurno"
        Me.cmbTurno.Size = New System.Drawing.Size(121, 21)
        Me.cmbTurno.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(286, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(166, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha Desde"
        '
        'fecha_hasta
        '
        Me.fecha_hasta.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_hasta.CalendarTitleForeColor = System.Drawing.Color.White
        Me.fecha_hasta.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_hasta.Location = New System.Drawing.Point(286, 39)
        Me.fecha_hasta.Name = "fecha_hasta"
        Me.fecha_hasta.Size = New System.Drawing.Size(106, 23)
        Me.fecha_hasta.TabIndex = 2
        '
        'fecha_desde
        '
        Me.fecha_desde.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_desde.CalendarTitleForeColor = System.Drawing.Color.White
        Me.fecha_desde.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_desde.Location = New System.Drawing.Point(169, 39)
        Me.fecha_desde.Name = "fecha_desde"
        Me.fecha_desde.Size = New System.Drawing.Size(106, 23)
        Me.fecha_desde.TabIndex = 1
        '
        'txtPersonalTurno
        '
        Me.txtPersonalTurno.Location = New System.Drawing.Point(7, 39)
        Me.txtPersonalTurno.Name = "txtPersonalTurno"
        Me.txtPersonalTurno.Size = New System.Drawing.Size(148, 20)
        Me.txtPersonalTurno.TabIndex = 0
        '
        'grillaPersonalTurno
        '
        Me.grillaPersonalTurno.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grillaPersonalTurno.AllowUserToAddRows = False
        Me.grillaPersonalTurno.AllowUserToDeleteRows = False
        Me.grillaPersonalTurno.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaPersonalTurno.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grillaPersonalTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaPersonalTurno.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nom_personal, Me.fecha_desde_personal, Me.fecha_hasta_personal, Me.turno_personal})
        Me.grillaPersonalTurno.EnableHeadersVisualStyles = False
        Me.grillaPersonalTurno.Location = New System.Drawing.Point(12, 219)
        Me.grillaPersonalTurno.Name = "grillaPersonalTurno"
        Me.grillaPersonalTurno.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaPersonalTurno.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grillaPersonalTurno.RowHeadersWidth = 20
        Me.grillaPersonalTurno.Size = New System.Drawing.Size(227, 430)
        Me.grillaPersonalTurno.TabIndex = 1
        '
        'grillaCalendarioTurno
        '
        Me.grillaCalendarioTurno.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grillaCalendarioTurno.AllowUserToAddRows = False
        Me.grillaCalendarioTurno.AllowUserToDeleteRows = False
        Me.grillaCalendarioTurno.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaCalendarioTurno.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grillaCalendarioTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaCalendarioTurno.EnableHeadersVisualStyles = False
        Me.grillaCalendarioTurno.Location = New System.Drawing.Point(245, 219)
        Me.grillaCalendarioTurno.Name = "grillaCalendarioTurno"
        Me.grillaCalendarioTurno.ReadOnly = True
        Me.grillaCalendarioTurno.RowHeadersVisible = False
        Me.grillaCalendarioTurno.RowHeadersWidth = 20
        Me.grillaCalendarioTurno.Size = New System.Drawing.Size(763, 430)
        Me.grillaCalendarioTurno.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(190, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Programacion de Turnos Personal"
        '
        'grpOperaciones
        '
        Me.grpOperaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpOperaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grpOperaciones.Controls.Add(Me.btn_salir_turnos)
        Me.grpOperaciones.Controls.Add(Me.btn_limpiar)
        Me.grpOperaciones.Controls.Add(Me.btn_guardar_turno)
        Me.grpOperaciones.Location = New System.Drawing.Point(872, 134)
        Me.grpOperaciones.Name = "grpOperaciones"
        Me.grpOperaciones.Size = New System.Drawing.Size(136, 64)
        Me.grpOperaciones.TabIndex = 4
        '
        'btn_salir_turnos
        '
        Me.btn_salir_turnos.Image = Global.mantencion.My.Resources.Resources.salir
        Me.btn_salir_turnos.Location = New System.Drawing.Point(86, 18)
        Me.btn_salir_turnos.Name = "btn_salir_turnos"
        Me.btn_salir_turnos.Size = New System.Drawing.Size(29, 29)
        Me.btn_salir_turnos.TabIndex = 2
        Me.btn_salir_turnos.UseVisualStyleBackColor = True
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Image = Global.mantencion.My.Resources.Resources.clear
        Me.btn_limpiar.Location = New System.Drawing.Point(51, 18)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(29, 29)
        Me.btn_limpiar.TabIndex = 1
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'btn_guardar_turno
        '
        Me.btn_guardar_turno.Image = Global.mantencion.My.Resources.Resources.guardar
        Me.btn_guardar_turno.Location = New System.Drawing.Point(16, 18)
        Me.btn_guardar_turno.Name = "btn_guardar_turno"
        Me.btn_guardar_turno.Size = New System.Drawing.Size(29, 29)
        Me.btn_guardar_turno.TabIndex = 0
        Me.btn_guardar_turno.UseVisualStyleBackColor = True
        '
        'grpFechasIniciales
        '
        Me.grpFechasIniciales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grpFechasIniciales.Controls.Add(Me.btn_crear_fechas)
        Me.grpFechasIniciales.Controls.Add(Me.Label8)
        Me.grpFechasIniciales.Controls.Add(Me.Label7)
        Me.grpFechasIniciales.Controls.Add(Me.fecha_hasta_cal)
        Me.grpFechasIniciales.Controls.Add(Me.fecha_desde_cal)
        Me.grpFechasIniciales.Location = New System.Drawing.Point(12, 13)
        Me.grpFechasIniciales.Name = "grpFechasIniciales"
        Me.grpFechasIniciales.Size = New System.Drawing.Size(372, 65)
        Me.grpFechasIniciales.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(265, 15)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Programación de Fechas Iniciales del Calendario"
        '
        'btn_agregar_personal
        '
        Me.btn_agregar_personal.Image = Global.mantencion.My.Resources.Resources.add
        Me.btn_agregar_personal.Location = New System.Drawing.Point(544, 38)
        Me.btn_agregar_personal.Name = "btn_agregar_personal"
        Me.btn_agregar_personal.Size = New System.Drawing.Size(23, 23)
        Me.btn_agregar_personal.TabIndex = 8
        Me.btn_agregar_personal.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(879, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Operaciones"
        '
        'fecha_desde_cal
        '
        Me.fecha_desde_cal.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_desde_cal.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_desde_cal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_desde_cal.Location = New System.Drawing.Point(10, 30)
        Me.fecha_desde_cal.Name = "fecha_desde_cal"
        Me.fecha_desde_cal.Size = New System.Drawing.Size(106, 23)
        Me.fecha_desde_cal.TabIndex = 0
        '
        'fecha_hasta_cal
        '
        Me.fecha_hasta_cal.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_hasta_cal.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_hasta_cal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_hasta_cal.Location = New System.Drawing.Point(126, 30)
        Me.fecha_hasta_cal.Name = "fecha_hasta_cal"
        Me.fecha_hasta_cal.Size = New System.Drawing.Size(106, 23)
        Me.fecha_hasta_cal.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 15)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Fecha Desde"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(123, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 15)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Fecha Hasta"
        '
        'btn_crear_fechas
        '
        Me.btn_crear_fechas.Location = New System.Drawing.Point(248, 27)
        Me.btn_crear_fechas.Name = "btn_crear_fechas"
        Me.btn_crear_fechas.Size = New System.Drawing.Size(90, 23)
        Me.btn_crear_fechas.TabIndex = 4
        Me.btn_crear_fechas.Text = "Crear"
        Me.btn_crear_fechas.UseVisualStyleBackColor = True
        '
        'nom_personal
        '
        Me.nom_personal.HeaderText = "Personal"
        Me.nom_personal.Name = "nom_personal"
        Me.nom_personal.ReadOnly = True
        Me.nom_personal.Width = 80
        '
        'fecha_desde_personal
        '
        Me.fecha_desde_personal.HeaderText = "Fecha Desde"
        Me.fecha_desde_personal.Name = "fecha_desde_personal"
        Me.fecha_desde_personal.ReadOnly = True
        '
        'fecha_hasta_personal
        '
        Me.fecha_hasta_personal.HeaderText = "Fecha Hasta"
        Me.fecha_hasta_personal.Name = "fecha_hasta_personal"
        Me.fecha_hasta_personal.ReadOnly = True
        '
        'turno_personal
        '
        Me.turno_personal.HeaderText = "Turno"
        Me.turno_personal.Name = "turno_personal"
        Me.turno_personal.ReadOnly = True
        Me.turno_personal.Width = 80
        '
        'FrmCalendarioTurno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(1020, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.grpFechasIniciales)
        Me.Controls.Add(Me.grpOperaciones)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grillaCalendarioTurno)
        Me.Controls.Add(Me.grillaPersonalTurno)
        Me.Controls.Add(Me.grpTurnosPersonal)
        Me.Name = "FrmCalendarioTurno"
        Me.ShowIcon = False
        Me.Text = "Programación de Turnos Departamento Mantención"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.grpTurnosPersonal.ResumeLayout(False)
        Me.grpTurnosPersonal.PerformLayout()
        CType(Me.grillaPersonalTurno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grillaCalendarioTurno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOperaciones.ResumeLayout(False)
        Me.grpFechasIniciales.ResumeLayout(False)
        Me.grpFechasIniciales.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpTurnosPersonal As System.Windows.Forms.Panel
    Friend WithEvents lblTurno As System.Windows.Forms.Label
    Friend WithEvents cmbTurno As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fecha_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecha_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPersonalTurno As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grillaPersonalTurno As System.Windows.Forms.DataGridView
    Friend WithEvents grillaCalendarioTurno As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpOperaciones As System.Windows.Forms.Panel
    Friend WithEvents btn_salir_turnos As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar_turno As System.Windows.Forms.Button
    Friend WithEvents btn_agregar_personal As System.Windows.Forms.Button
    Friend WithEvents grpFechasIniciales As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents fecha_hasta_cal As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecha_desde_cal As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_crear_fechas As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nom_personal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha_desde_personal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha_hasta_personal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turno_personal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
