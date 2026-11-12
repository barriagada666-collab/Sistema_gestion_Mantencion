<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfOT
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.arbol5 = New System.Windows.Forms.TreeView
        Me.txtBuscarNodo5 = New System.Windows.Forms.TextBox
        Me.btnBuscarOt = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNumOtInfOt = New System.Windows.Forms.TextBox
        Me.fecha_fin_inf_ot = New System.Windows.Forms.DateTimePicker
        Me.lblfecha_fin = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.fecha_ini_inf_ot = New System.Windows.Forms.DateTimePicker
        Me.opcFechasOt = New System.Windows.Forms.RadioButton
        Me.opcNumOt = New System.Windows.Forms.RadioButton
        Me.grillaInfOt = New System.Windows.Forms.DataGridView
        Me.chkPendientes = New System.Windows.Forms.CheckBox
        Me.chkConDetencion = New System.Windows.Forms.CheckBox
        Me.chkTodasFechas = New System.Windows.Forms.CheckBox
        Me.GrpFiltroFechas = New System.Windows.Forms.Panel
        Me.PanPlantas = New System.Windows.Forms.Panel
        Me.pl_3 = New System.Windows.Forms.CheckBox
        Me.pl_4 = New System.Windows.Forms.CheckBox
        Me.pl_2 = New System.Windows.Forms.CheckBox
        Me.chkFiltroPlanta = New System.Windows.Forms.CheckBox
        Me.chkNulas = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbTipoDetencion = New System.Windows.Forms.ComboBox
        Me.chkTipoDetencion = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkTipoTrabajo = New System.Windows.Forms.CheckBox
        Me.cmbTipoTrabajoInfOt = New System.Windows.Forms.ComboBox
        Me.GrpFiltroInfOt2 = New System.Windows.Forms.Panel
        Me.btnPdf = New System.Windows.Forms.Button
        Me.btnSalirInfOt = New System.Windows.Forms.Button
        Me.btnExcExcel = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip4 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.grillaInfOt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpFiltroFechas.SuspendLayout()
        Me.PanPlantas.SuspendLayout()
        Me.GrpFiltroInfOt2.SuspendLayout()
        Me.SuspendLayout()
        '
        'arbol5
        '
        Me.arbol5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.arbol5.Location = New System.Drawing.Point(12, 36)
        Me.arbol5.Name = "arbol5"
        Me.arbol5.Size = New System.Drawing.Size(220, 613)
        Me.arbol5.TabIndex = 0
        '
        'txtBuscarNodo5
        '
        Me.txtBuscarNodo5.Location = New System.Drawing.Point(13, 10)
        Me.txtBuscarNodo5.Name = "txtBuscarNodo5"
        Me.txtBuscarNodo5.Size = New System.Drawing.Size(219, 20)
        Me.txtBuscarNodo5.TabIndex = 1
        '
        'btnBuscarOt
        '
        Me.btnBuscarOt.BackgroundImage = Global.Mantencion.My.Resources.Resources.icono_buscar1
        Me.btnBuscarOt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscarOt.Location = New System.Drawing.Point(719, 9)
        Me.btnBuscarOt.Name = "btnBuscarOt"
        Me.btnBuscarOt.Size = New System.Drawing.Size(29, 29)
        Me.btnBuscarOt.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btnBuscarOt, "Buscar OT")
        Me.btnBuscarOt.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "N° Orden"
        '
        'txtNumOtInfOt
        '
        Me.txtNumOtInfOt.Location = New System.Drawing.Point(6, 91)
        Me.txtNumOtInfOt.Name = "txtNumOtInfOt"
        Me.txtNumOtInfOt.Size = New System.Drawing.Size(82, 20)
        Me.txtNumOtInfOt.TabIndex = 3
        '
        'fecha_fin_inf_ot
        '
        Me.fecha_fin_inf_ot.CalendarTitleBackColor = System.Drawing.Color.Green
        Me.fecha_fin_inf_ot.CalendarTrailingForeColor = System.Drawing.Color.White
        Me.fecha_fin_inf_ot.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_fin_inf_ot.Location = New System.Drawing.Point(107, 31)
        Me.fecha_fin_inf_ot.Name = "fecha_fin_inf_ot"
        Me.fecha_fin_inf_ot.Size = New System.Drawing.Size(84, 20)
        Me.fecha_fin_inf_ot.TabIndex = 6
        '
        'lblfecha_fin
        '
        Me.lblfecha_fin.AutoSize = True
        Me.lblfecha_fin.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfecha_fin.Location = New System.Drawing.Point(104, 14)
        Me.lblfecha_fin.Name = "lblfecha_fin"
        Me.lblfecha_fin.Size = New System.Drawing.Size(87, 15)
        Me.lblfecha_fin.TabIndex = 5
        Me.lblfecha_fin.Text = "Fecha Término"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Fecha Inicio"
        '
        'fecha_ini_inf_ot
        '
        Me.fecha_ini_inf_ot.CalendarTitleBackColor = System.Drawing.Color.Green
        Me.fecha_ini_inf_ot.CalendarTrailingForeColor = System.Drawing.Color.White
        Me.fecha_ini_inf_ot.CustomFormat = ""
        Me.fecha_ini_inf_ot.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_ini_inf_ot.Location = New System.Drawing.Point(6, 31)
        Me.fecha_ini_inf_ot.Name = "fecha_ini_inf_ot"
        Me.fecha_ini_inf_ot.Size = New System.Drawing.Size(84, 20)
        Me.fecha_ini_inf_ot.TabIndex = 3
        '
        'opcFechasOt
        '
        Me.opcFechasOt.AutoSize = True
        Me.opcFechasOt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opcFechasOt.Location = New System.Drawing.Point(3, 34)
        Me.opcFechasOt.Name = "opcFechasOt"
        Me.opcFechasOt.Size = New System.Drawing.Size(114, 19)
        Me.opcFechasOt.TabIndex = 1
        Me.opcFechasOt.TabStop = True
        Me.opcFechasOt.Text = "Rango de Fechas"
        Me.opcFechasOt.UseVisualStyleBackColor = True
        '
        'opcNumOt
        '
        Me.opcNumOt.AutoSize = True
        Me.opcNumOt.Checked = True
        Me.opcNumOt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opcNumOt.Location = New System.Drawing.Point(3, 9)
        Me.opcNumOt.Name = "opcNumOt"
        Me.opcNumOt.Size = New System.Drawing.Size(93, 19)
        Me.opcNumOt.TabIndex = 0
        Me.opcNumOt.TabStop = True
        Me.opcNumOt.Text = "N° de Orden"
        Me.opcNumOt.UseVisualStyleBackColor = True
        '
        'grillaInfOt
        '
        Me.grillaInfOt.AllowUserToAddRows = False
        Me.grillaInfOt.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grillaInfOt.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.grillaInfOt.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.NullValue = "S/I"
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaInfOt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.grillaInfOt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaInfOt.EnableHeadersVisualStyles = False
        Me.grillaInfOt.Location = New System.Drawing.Point(255, 149)
        Me.grillaInfOt.Name = "grillaInfOt"
        Me.grillaInfOt.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaInfOt.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.grillaInfOt.RowHeadersWidth = 20
        Me.grillaInfOt.Size = New System.Drawing.Size(753, 500)
        Me.grillaInfOt.TabIndex = 3
        '
        'chkPendientes
        '
        Me.chkPendientes.AutoSize = True
        Me.chkPendientes.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPendientes.Location = New System.Drawing.Point(265, 3)
        Me.chkPendientes.Name = "chkPendientes"
        Me.chkPendientes.Size = New System.Drawing.Size(88, 19)
        Me.chkPendientes.TabIndex = 7
        Me.chkPendientes.Text = "Pendientes"
        Me.chkPendientes.UseVisualStyleBackColor = True
        '
        'chkConDetencion
        '
        Me.chkConDetencion.AutoSize = True
        Me.chkConDetencion.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkConDetencion.Location = New System.Drawing.Point(359, 3)
        Me.chkConDetencion.Name = "chkConDetencion"
        Me.chkConDetencion.Size = New System.Drawing.Size(106, 19)
        Me.chkConDetencion.TabIndex = 8
        Me.chkConDetencion.Text = "Con Detención"
        Me.chkConDetencion.UseVisualStyleBackColor = True
        '
        'chkTodasFechas
        '
        Me.chkTodasFechas.AutoSize = True
        Me.chkTodasFechas.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodasFechas.Location = New System.Drawing.Point(202, 3)
        Me.chkTodasFechas.Name = "chkTodasFechas"
        Me.chkTodasFechas.Size = New System.Drawing.Size(57, 19)
        Me.chkTodasFechas.TabIndex = 9
        Me.chkTodasFechas.Text = "Todas"
        Me.chkTodasFechas.UseVisualStyleBackColor = True
        '
        'GrpFiltroFechas
        '
        Me.GrpFiltroFechas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GrpFiltroFechas.Controls.Add(Me.PanPlantas)
        Me.GrpFiltroFechas.Controls.Add(Me.chkFiltroPlanta)
        Me.GrpFiltroFechas.Controls.Add(Me.chkNulas)
        Me.GrpFiltroFechas.Controls.Add(Me.Label6)
        Me.GrpFiltroFechas.Controls.Add(Me.cmbTipoDetencion)
        Me.GrpFiltroFechas.Controls.Add(Me.chkTipoDetencion)
        Me.GrpFiltroFechas.Controls.Add(Me.Label5)
        Me.GrpFiltroFechas.Controls.Add(Me.chkTipoTrabajo)
        Me.GrpFiltroFechas.Controls.Add(Me.cmbTipoTrabajoInfOt)
        Me.GrpFiltroFechas.Controls.Add(Me.chkTodasFechas)
        Me.GrpFiltroFechas.Controls.Add(Me.chkPendientes)
        Me.GrpFiltroFechas.Controls.Add(Me.chkConDetencion)
        Me.GrpFiltroFechas.Controls.Add(Me.lblfecha_fin)
        Me.GrpFiltroFechas.Controls.Add(Me.fecha_fin_inf_ot)
        Me.GrpFiltroFechas.Controls.Add(Me.fecha_ini_inf_ot)
        Me.GrpFiltroFechas.Controls.Add(Me.Label1)
        Me.GrpFiltroFechas.Location = New System.Drawing.Point(123, 12)
        Me.GrpFiltroFechas.Name = "GrpFiltroFechas"
        Me.GrpFiltroFechas.Size = New System.Drawing.Size(555, 109)
        Me.GrpFiltroFechas.TabIndex = 4
        '
        'PanPlantas
        '
        Me.PanPlantas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanPlantas.Controls.Add(Me.pl_3)
        Me.PanPlantas.Controls.Add(Me.pl_4)
        Me.PanPlantas.Controls.Add(Me.pl_2)
        Me.PanPlantas.Location = New System.Drawing.Point(270, 66)
        Me.PanPlantas.Name = "PanPlantas"
        Me.PanPlantas.Size = New System.Drawing.Size(280, 38)
        Me.PanPlantas.TabIndex = 18
        '
        'pl_3
        '
        Me.pl_3.AutoSize = True
        Me.pl_3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pl_3.Location = New System.Drawing.Point(169, 11)
        Me.pl_3.Name = "pl_3"
        Me.pl_3.Size = New System.Drawing.Size(106, 19)
        Me.pl_3.TabIndex = 2
        Me.pl_3.Text = "Centro Distrib."
        Me.pl_3.UseVisualStyleBackColor = True
        '
        'pl_4
        '
        Me.pl_4.AutoSize = True
        Me.pl_4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pl_4.Location = New System.Drawing.Point(88, 11)
        Me.pl_4.Name = "pl_4"
        Me.pl_4.Size = New System.Drawing.Size(75, 19)
        Me.pl_4.TabIndex = 1
        Me.pl_4.Text = "Planta TÉ"
        Me.pl_4.UseVisualStyleBackColor = True
        '
        'pl_2
        '
        Me.pl_2.AutoSize = True
        Me.pl_2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pl_2.Location = New System.Drawing.Point(6, 11)
        Me.pl_2.Name = "pl_2"
        Me.pl_2.Size = New System.Drawing.Size(76, 19)
        Me.pl_2.TabIndex = 0
        Me.pl_2.Text = "Planta PE"
        Me.pl_2.UseVisualStyleBackColor = True
        '
        'chkFiltroPlanta
        '
        Me.chkFiltroPlanta.AutoSize = True
        Me.chkFiltroPlanta.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFiltroPlanta.Location = New System.Drawing.Point(448, 28)
        Me.chkFiltroPlanta.Name = "chkFiltroPlanta"
        Me.chkFiltroPlanta.Size = New System.Drawing.Size(87, 19)
        Me.chkFiltroPlanta.TabIndex = 17
        Me.chkFiltroPlanta.Text = "Por Plantas"
        Me.chkFiltroPlanta.UseVisualStyleBackColor = True
        '
        'chkNulas
        '
        Me.chkNulas.AutoSize = True
        Me.chkNulas.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNulas.Location = New System.Drawing.Point(471, 3)
        Me.chkNulas.Name = "chkNulas"
        Me.chkNulas.Size = New System.Drawing.Size(74, 19)
        Me.chkNulas.TabIndex = 16
        Me.chkNulas.Text = "OT Nulas"
        Me.chkNulas.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(137, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 15)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Tipo Detención"
        '
        'cmbTipoDetencion
        '
        Me.cmbTipoDetencion.FormattingEnabled = True
        Me.cmbTipoDetencion.Location = New System.Drawing.Point(140, 78)
        Me.cmbTipoDetencion.Name = "cmbTipoDetencion"
        Me.cmbTipoDetencion.Size = New System.Drawing.Size(104, 21)
        Me.cmbTipoDetencion.TabIndex = 14
        '
        'chkTipoDetencion
        '
        Me.chkTipoDetencion.AutoSize = True
        Me.chkTipoDetencion.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTipoDetencion.Location = New System.Drawing.Point(317, 28)
        Me.chkTipoDetencion.Name = "chkTipoDetencion"
        Me.chkTipoDetencion.Size = New System.Drawing.Size(125, 19)
        Me.chkTipoDetencion.TabIndex = 13
        Me.chkTipoDetencion.Text = "Tipo de Detención"
        Me.chkTipoDetencion.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 15)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Tipo Trabajo"
        '
        'chkTipoTrabajo
        '
        Me.chkTipoTrabajo.AutoSize = True
        Me.chkTipoTrabajo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTipoTrabajo.Location = New System.Drawing.Point(202, 28)
        Me.chkTipoTrabajo.Name = "chkTipoTrabajo"
        Me.chkTipoTrabajo.Size = New System.Drawing.Size(109, 19)
        Me.chkTipoTrabajo.TabIndex = 11
        Me.chkTipoTrabajo.Text = "Tipo de Trabajo"
        Me.chkTipoTrabajo.UseVisualStyleBackColor = True
        '
        'cmbTipoTrabajoInfOt
        '
        Me.cmbTipoTrabajoInfOt.FormattingEnabled = True
        Me.cmbTipoTrabajoInfOt.Location = New System.Drawing.Point(6, 78)
        Me.cmbTipoTrabajoInfOt.Name = "cmbTipoTrabajoInfOt"
        Me.cmbTipoTrabajoInfOt.Size = New System.Drawing.Size(128, 21)
        Me.cmbTipoTrabajoInfOt.TabIndex = 10
        '
        'GrpFiltroInfOt2
        '
        Me.GrpFiltroInfOt2.BackColor = System.Drawing.Color.Transparent
        Me.GrpFiltroInfOt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GrpFiltroInfOt2.Controls.Add(Me.btnPdf)
        Me.GrpFiltroInfOt2.Controls.Add(Me.btnSalirInfOt)
        Me.GrpFiltroInfOt2.Controls.Add(Me.btnExcExcel)
        Me.GrpFiltroInfOt2.Controls.Add(Me.Label4)
        Me.GrpFiltroInfOt2.Controls.Add(Me.btnBuscarOt)
        Me.GrpFiltroInfOt2.Controls.Add(Me.GrpFiltroFechas)
        Me.GrpFiltroInfOt2.Controls.Add(Me.opcNumOt)
        Me.GrpFiltroInfOt2.Controls.Add(Me.opcFechasOt)
        Me.GrpFiltroInfOt2.Controls.Add(Me.Label2)
        Me.GrpFiltroInfOt2.Controls.Add(Me.txtNumOtInfOt)
        Me.GrpFiltroInfOt2.Location = New System.Drawing.Point(255, 12)
        Me.GrpFiltroInfOt2.Name = "GrpFiltroInfOt2"
        Me.GrpFiltroInfOt2.Size = New System.Drawing.Size(753, 126)
        Me.GrpFiltroInfOt2.TabIndex = 4
        '
        'btnPdf
        '
        Me.btnPdf.BackgroundImage = Global.Mantencion.My.Resources.Resources.icono_pdf
        Me.btnPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPdf.Enabled = False
        Me.btnPdf.Location = New System.Drawing.Point(684, 79)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(29, 29)
        Me.btnPdf.TabIndex = 9
        Me.ToolTip3.SetToolTip(Me.btnPdf, "Exportar a PDF")
        Me.btnPdf.UseVisualStyleBackColor = True
        Me.btnPdf.Visible = False
        '
        'btnSalirInfOt
        '
        Me.btnSalirInfOt.BackgroundImage = Global.Mantencion.My.Resources.Resources.salir
        Me.btnSalirInfOt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalirInfOt.Location = New System.Drawing.Point(719, 79)
        Me.btnSalirInfOt.Name = "btnSalirInfOt"
        Me.btnSalirInfOt.Size = New System.Drawing.Size(29, 29)
        Me.btnSalirInfOt.TabIndex = 8
        Me.ToolTip4.SetToolTip(Me.btnSalirInfOt, "Salir")
        Me.btnSalirInfOt.UseVisualStyleBackColor = True
        '
        'btnExcExcel
        '
        Me.btnExcExcel.BackgroundImage = Global.Mantencion.My.Resources.Resources.icono_excel1
        Me.btnExcExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnExcExcel.Location = New System.Drawing.Point(719, 44)
        Me.btnExcExcel.Name = "btnExcExcel"
        Me.btnExcExcel.Size = New System.Drawing.Size(29, 29)
        Me.btnExcExcel.TabIndex = 7
        Me.ToolTip2.SetToolTip(Me.btnExcExcel, "Exportar a Excel")
        Me.btnExcExcel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(127, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(167, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Opciones de Filtro Por Fechas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(259, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Filtrado Informe"
        '
        'FrmInfOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(1020, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grillaInfOt)
        Me.Controls.Add(Me.txtBuscarNodo5)
        Me.Controls.Add(Me.arbol5)
        Me.Controls.Add(Me.GrpFiltroInfOt2)
        Me.Name = "FrmInfOT"
        Me.Text = "Informe Ordenes de Trabajo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grillaInfOt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpFiltroFechas.ResumeLayout(False)
        Me.GrpFiltroFechas.PerformLayout()
        Me.PanPlantas.ResumeLayout(False)
        Me.PanPlantas.PerformLayout()
        Me.GrpFiltroInfOt2.ResumeLayout(False)
        Me.GrpFiltroInfOt2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents arbol5 As System.Windows.Forms.TreeView
    Friend WithEvents txtBuscarNodo5 As System.Windows.Forms.TextBox
    Friend WithEvents grillaInfOt As System.Windows.Forms.DataGridView
    Friend WithEvents opcNumOt As System.Windows.Forms.RadioButton
    Friend WithEvents opcFechasOt As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fecha_ini_inf_ot As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscarOt As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumOtInfOt As System.Windows.Forms.TextBox
    Friend WithEvents fecha_fin_inf_ot As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfecha_fin As System.Windows.Forms.Label
    Friend WithEvents chkConDetencion As System.Windows.Forms.CheckBox
    Friend WithEvents chkPendientes As System.Windows.Forms.CheckBox
    Friend WithEvents chkTodasFechas As System.Windows.Forms.CheckBox
    Friend WithEvents GrpFiltroFechas As System.Windows.Forms.Panel
    Friend WithEvents GrpFiltroInfOt2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkTipoDetencion As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkTipoTrabajo As System.Windows.Forms.CheckBox
    Friend WithEvents cmbTipoTrabajoInfOt As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDetencion As System.Windows.Forms.ComboBox
    Friend WithEvents chkNulas As System.Windows.Forms.CheckBox
    Friend WithEvents btnSalirInfOt As System.Windows.Forms.Button
    Friend WithEvents btnExcExcel As System.Windows.Forms.Button
    Friend WithEvents btnPdf As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip4 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents PanPlantas As System.Windows.Forms.Panel
    Friend WithEvents pl_2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFiltroPlanta As System.Windows.Forms.CheckBox
    Friend WithEvents pl_4 As System.Windows.Forms.CheckBox
    Friend WithEvents pl_3 As System.Windows.Forms.CheckBox
End Class
