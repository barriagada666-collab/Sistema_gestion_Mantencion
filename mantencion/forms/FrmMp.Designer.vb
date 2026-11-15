<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMp
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
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.arbol1 = New System.Windows.Forms.TreeView
        Me.txtBuscarNodo1 = New System.Windows.Forms.TextBox
        Me.GrpTareasNodo = New System.Windows.Forms.GroupBox
        Me.btn_plan_ciclos = New System.Windows.Forms.Button
        Me.btnActMp = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtObsMant = New System.Windows.Forms.TextBox
        Me.lblTipoMp = New System.Windows.Forms.Label
        Me.btnEliminarMp = New System.Windows.Forms.Button
        Me.cmbTipoMp = New System.Windows.Forms.ComboBox
        Me.btnNuevaMp = New System.Windows.Forms.Button
        Me.btnBuscarMp = New System.Windows.Forms.Button
        Me.lblEstadoMp = New System.Windows.Forms.Label
        Me.cmbEstadoMp = New System.Windows.Forms.ComboBox
        Me.lblTiempoAviso = New System.Windows.Forms.Label
        Me.txtTiempoAviso = New System.Windows.Forms.TextBox
        Me.lblfrecuencia = New System.Windows.Forms.Label
        Me.txtFrecuenciaMp = New System.Windows.Forms.TextBox
        Me.lblIdMant = New System.Windows.Forms.Label
        Me.txtIdMant = New System.Windows.Forms.TextBox
        Me.GrpOperTarea = New System.Windows.Forms.GroupBox
        Me.btnCambiarTareas = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnGuardarComoNuevoCiclo = New System.Windows.Forms.Button
        Me.btnLimpiarCiclo = New System.Windows.Forms.Button
        Me.btnGuardarMp = New System.Windows.Forms.Button
        Me.btnIngMp = New System.Windows.Forms.Button
        Me.GrpCiclosMp = New System.Windows.Forms.GroupBox
        Me.btnBuscarCiclo = New System.Windows.Forms.Button
        Me.txtIdCiclo = New System.Windows.Forms.TextBox
        Me.btnNuevoCiclo = New System.Windows.Forms.Button
        Me.btnEliminarCiclo = New System.Windows.Forms.Button
        Me.lblEstadoCiclo = New System.Windows.Forms.Label
        Me.cmbEstadoCiclo = New System.Windows.Forms.ComboBox
        Me.lblObsCiclo = New System.Windows.Forms.Label
        Me.txtObsCiclo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDuracionCiclo = New System.Windows.Forms.TextBox
        Me.lblHrFinCiclo = New System.Windows.Forms.Label
        Me.HrFinCiclo = New System.Windows.Forms.DateTimePicker
        Me.lblFechaFinCiclo = New System.Windows.Forms.Label
        Me.fechaFinCicloMp = New System.Windows.Forms.DateTimePicker
        Me.lblHrInicioCiclo = New System.Windows.Forms.Label
        Me.HrInicioCiclo = New System.Windows.Forms.DateTimePicker
        Me.lblFechaInicio = New System.Windows.Forms.Label
        Me.FechaIniCiclo = New System.Windows.Forms.DateTimePicker
        Me.lblIdCiclo = New System.Windows.Forms.Label
        Me.GrpInfAdicional = New System.Windows.Forms.GroupBox
        Me.hrsCiclo = New System.Windows.Forms.Label
        Me.lblHrsCiclo = New System.Windows.Forms.Label
        Me.btnDelFila = New System.Windows.Forms.Button
        Me.btnAgrFila = New System.Windows.Forms.Button
        Me.TabMp = New System.Windows.Forms.TabControl
        Me.TareasCicloMp = New System.Windows.Forms.TabPage
        Me.btn_Limpiar_tabla = New System.Windows.Forms.Button
        Me.chkSelTodo = New System.Windows.Forms.CheckBox
        Me.btn_agr_tareas = New System.Windows.Forms.Button
        Me.grillaTareasCicloMp = New System.Windows.Forms.DataGridView
        Me.realizada = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PerCicloMp = New System.Windows.Forms.TabPage
        Me.btn_buscar_personal_mp = New System.Windows.Forms.Button
        Me.grillaPersonalMp = New System.Windows.Forms.DataGridView
        Me.rut_personal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombre_personal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InsCicloMp = New System.Windows.Forms.TabPage
        Me.grillaInsumosMp = New System.Windows.Forms.DataGridView
        Me.id_insumo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cod_sap = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc_insumo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cant_insumo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.unid_medida = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.precio_unid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TareasAdMp = New System.Windows.Forms.TabPage
        Me.Opc_tareas_ele = New System.Windows.Forms.RadioButton
        Me.opc_tareas_mec = New System.Windows.Forms.RadioButton
        Me.lblFiltro = New System.Windows.Forms.Label
        Me.txtBuscarTarea = New System.Windows.Forms.TextBox
        Me.grillaTareasAdMp = New System.Windows.Forms.DataGridView
        Me.select_tarea = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.btnAgrTareas = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.opc_seccion = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.opc_mod_maq = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GrpTareasNodo.SuspendLayout()
        Me.GrpOperTarea.SuspendLayout()
        Me.GrpCiclosMp.SuspendLayout()
        Me.GrpInfAdicional.SuspendLayout()
        Me.TabMp.SuspendLayout()
        Me.TareasCicloMp.SuspendLayout()
        CType(Me.grillaTareasCicloMp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PerCicloMp.SuspendLayout()
        CType(Me.grillaPersonalMp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InsCicloMp.SuspendLayout()
        CType(Me.grillaInsumosMp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TareasAdMp.SuspendLayout()
        CType(Me.grillaTareasAdMp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'arbol1
        '
        Me.arbol1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.arbol1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.arbol1.Location = New System.Drawing.Point(12, 42)
        Me.arbol1.Name = "arbol1"
        Me.arbol1.Size = New System.Drawing.Size(220, 607)
        Me.arbol1.TabIndex = 0
        '
        'txtBuscarNodo1
        '
        Me.txtBuscarNodo1.Location = New System.Drawing.Point(12, 12)
        Me.txtBuscarNodo1.Name = "txtBuscarNodo1"
        Me.txtBuscarNodo1.Size = New System.Drawing.Size(220, 20)
        Me.txtBuscarNodo1.TabIndex = 1
        '
        'GrpTareasNodo
        '
        Me.GrpTareasNodo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTareasNodo.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.GrpTareasNodo.Controls.Add(Me.btn_plan_ciclos)
        Me.GrpTareasNodo.Controls.Add(Me.btnActMp)
        Me.GrpTareasNodo.Controls.Add(Me.Label3)
        Me.GrpTareasNodo.Controls.Add(Me.txtObsMant)
        Me.GrpTareasNodo.Controls.Add(Me.lblTipoMp)
        Me.GrpTareasNodo.Controls.Add(Me.btnEliminarMp)
        Me.GrpTareasNodo.Controls.Add(Me.cmbTipoMp)
        Me.GrpTareasNodo.Controls.Add(Me.btnNuevaMp)
        Me.GrpTareasNodo.Controls.Add(Me.btnBuscarMp)
        Me.GrpTareasNodo.Controls.Add(Me.lblEstadoMp)
        Me.GrpTareasNodo.Controls.Add(Me.cmbEstadoMp)
        Me.GrpTareasNodo.Controls.Add(Me.lblTiempoAviso)
        Me.GrpTareasNodo.Controls.Add(Me.txtTiempoAviso)
        Me.GrpTareasNodo.Controls.Add(Me.lblfrecuencia)
        Me.GrpTareasNodo.Controls.Add(Me.txtFrecuenciaMp)
        Me.GrpTareasNodo.Controls.Add(Me.lblIdMant)
        Me.GrpTareasNodo.Controls.Add(Me.txtIdMant)
        Me.GrpTareasNodo.Location = New System.Drawing.Point(262, 12)
        Me.GrpTareasNodo.Name = "GrpTareasNodo"
        Me.GrpTareasNodo.Size = New System.Drawing.Size(746, 131)
        Me.GrpTareasNodo.TabIndex = 2
        Me.GrpTareasNodo.TabStop = False
        Me.GrpTareasNodo.Text = "Información Base"
        '
        'btn_plan_ciclos
        '
        Me.btn_plan_ciclos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_plan_ciclos.Enabled = False
        Me.btn_plan_ciclos.Image = Global.mantencion.My.Resources.Resources.Plan_Ciclos_16x16
        Me.btn_plan_ciclos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_plan_ciclos.Location = New System.Drawing.Point(533, 102)
        Me.btn_plan_ciclos.Name = "btn_plan_ciclos"
        Me.btn_plan_ciclos.Size = New System.Drawing.Size(105, 23)
        Me.btn_plan_ciclos.TabIndex = 23
        Me.btn_plan_ciclos.Text = "     Planificar Ciclos"
        Me.btn_plan_ciclos.UseVisualStyleBackColor = True
        '
        'btnActMp
        '
        Me.btnActMp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActMp.Image = Global.mantencion.My.Resources.Resources.icono_escritura_2
        Me.btnActMp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActMp.Location = New System.Drawing.Point(644, 69)
        Me.btnActMp.Name = "btnActMp"
        Me.btnActMp.Size = New System.Drawing.Size(96, 23)
        Me.btnActMp.TabIndex = 22
        Me.btnActMp.Text = "     Actualizar MP"
        Me.btnActMp.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(199, 15)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Descripción Mantención Preventiva"
        '
        'txtObsMant
        '
        Me.txtObsMant.Location = New System.Drawing.Point(6, 83)
        Me.txtObsMant.MaxLength = 150
        Me.txtObsMant.Multiline = True
        Me.txtObsMant.Name = "txtObsMant"
        Me.txtObsMant.Size = New System.Drawing.Size(484, 42)
        Me.txtObsMant.TabIndex = 20
        '
        'lblTipoMp
        '
        Me.lblTipoMp.AutoSize = True
        Me.lblTipoMp.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoMp.Location = New System.Drawing.Point(392, 18)
        Me.lblTipoMp.Name = "lblTipoMp"
        Me.lblTipoMp.Size = New System.Drawing.Size(98, 15)
        Me.lblTipoMp.TabIndex = 11
        Me.lblTipoMp.Text = "Tipo Mantención"
        '
        'btnEliminarMp
        '
        Me.btnEliminarMp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarMp.Image = Global.mantencion.My.Resources.Resources._16__Delete_
        Me.btnEliminarMp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminarMp.Location = New System.Drawing.Point(644, 102)
        Me.btnEliminarMp.Name = "btnEliminarMp"
        Me.btnEliminarMp.Size = New System.Drawing.Size(96, 23)
        Me.btnEliminarMp.TabIndex = 19
        Me.btnEliminarMp.Text = "   Eliminar MP"
        Me.btnEliminarMp.UseVisualStyleBackColor = True
        '
        'cmbTipoMp
        '
        Me.cmbTipoMp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMp.FormattingEnabled = True
        Me.cmbTipoMp.Location = New System.Drawing.Point(395, 36)
        Me.cmbTipoMp.MaxDropDownItems = 50
        Me.cmbTipoMp.Name = "cmbTipoMp"
        Me.cmbTipoMp.Size = New System.Drawing.Size(98, 21)
        Me.cmbTipoMp.TabIndex = 4
        '
        'btnNuevaMp
        '
        Me.btnNuevaMp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevaMp.Image = Global.mantencion.My.Resources.Resources.add
        Me.btnNuevaMp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevaMp.Location = New System.Drawing.Point(644, 39)
        Me.btnNuevaMp.Name = "btnNuevaMp"
        Me.btnNuevaMp.Size = New System.Drawing.Size(96, 23)
        Me.btnNuevaMp.TabIndex = 9
        Me.btnNuevaMp.Text = "    Nueva MP"
        Me.btnNuevaMp.UseVisualStyleBackColor = True
        '
        'btnBuscarMp
        '
        Me.btnBuscarMp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscarMp.Image = Global.mantencion.My.Resources.Resources._16__Find_
        Me.btnBuscarMp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarMp.Location = New System.Drawing.Point(644, 10)
        Me.btnBuscarMp.Name = "btnBuscarMp"
        Me.btnBuscarMp.Size = New System.Drawing.Size(96, 23)
        Me.btnBuscarMp.TabIndex = 8
        Me.btnBuscarMp.Text = "   Buscar MP"
        Me.btnBuscarMp.UseVisualStyleBackColor = True
        '
        'lblEstadoMp
        '
        Me.lblEstadoMp.AutoSize = True
        Me.lblEstadoMp.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoMp.Location = New System.Drawing.Point(286, 18)
        Me.lblEstadoMp.Name = "lblEstadoMp"
        Me.lblEstadoMp.Size = New System.Drawing.Size(64, 15)
        Me.lblEstadoMp.TabIndex = 7
        Me.lblEstadoMp.Text = "Estado Mp"
        '
        'cmbEstadoMp
        '
        Me.cmbEstadoMp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoMp.FormattingEnabled = True
        Me.cmbEstadoMp.Location = New System.Drawing.Point(289, 36)
        Me.cmbEstadoMp.Name = "cmbEstadoMp"
        Me.cmbEstadoMp.Size = New System.Drawing.Size(90, 21)
        Me.cmbEstadoMp.TabIndex = 3
        '
        'lblTiempoAviso
        '
        Me.lblTiempoAviso.AutoSize = True
        Me.lblTiempoAviso.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiempoAviso.Location = New System.Drawing.Point(172, 18)
        Me.lblTiempoAviso.Name = "lblTiempoAviso"
        Me.lblTiempoAviso.Size = New System.Drawing.Size(108, 15)
        Me.lblTiempoAviso.TabIndex = 5
        Me.lblTiempoAviso.Text = "T.Aviso Previo(hrs)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTiempoAviso.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTiempoAviso
        '
        Me.txtTiempoAviso.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtTiempoAviso.Location = New System.Drawing.Point(175, 36)
        Me.txtTiempoAviso.MaxLength = 10
        Me.txtTiempoAviso.Name = "txtTiempoAviso"
        Me.txtTiempoAviso.Size = New System.Drawing.Size(105, 20)
        Me.txtTiempoAviso.TabIndex = 2
        '
        'lblfrecuencia
        '
        Me.lblfrecuencia.AutoSize = True
        Me.lblfrecuencia.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrecuencia.Location = New System.Drawing.Point(72, 18)
        Me.lblfrecuencia.Name = "lblfrecuencia"
        Me.lblfrecuencia.Size = New System.Drawing.Size(91, 15)
        Me.lblfrecuencia.TabIndex = 3
        Me.lblfrecuencia.Text = "Frecuencia(Hrs)"
        '
        'txtFrecuenciaMp
        '
        Me.txtFrecuenciaMp.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtFrecuenciaMp.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txtFrecuenciaMp.Location = New System.Drawing.Point(75, 36)
        Me.txtFrecuenciaMp.MaxLength = 10
        Me.txtFrecuenciaMp.Name = "txtFrecuenciaMp"
        Me.txtFrecuenciaMp.Size = New System.Drawing.Size(88, 20)
        Me.txtFrecuenciaMp.TabIndex = 1
        '
        'lblIdMant
        '
        Me.lblIdMant.AutoSize = True
        Me.lblIdMant.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.lblIdMant.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdMant.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblIdMant.Location = New System.Drawing.Point(6, 18)
        Me.lblIdMant.Name = "lblIdMant"
        Me.lblIdMant.Size = New System.Drawing.Size(55, 15)
        Me.lblIdMant.TabIndex = 1
        Me.lblIdMant.Text = "N° Mant."
        '
        'txtIdMant
        '
        Me.txtIdMant.BackColor = System.Drawing.Color.FromArgb(215, 230, 234)
        Me.txtIdMant.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.txtIdMant.ReadOnly = True
        Me.txtIdMant.Location = New System.Drawing.Point(7, 36)
        Me.txtIdMant.Name = "txtIdMant"
        Me.txtIdMant.Size = New System.Drawing.Size(54, 20)
        Me.txtIdMant.TabIndex = 0
        '
        'GrpOperTarea
        '
        Me.GrpOperTarea.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpOperTarea.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.GrpOperTarea.Controls.Add(Me.btnCambiarTareas)
        Me.GrpOperTarea.Controls.Add(Me.btnSalir)
        Me.GrpOperTarea.Controls.Add(Me.btnGuardarComoNuevoCiclo)
        Me.GrpOperTarea.Controls.Add(Me.btnLimpiarCiclo)
        Me.GrpOperTarea.Controls.Add(Me.btnGuardarMp)
        Me.GrpOperTarea.Controls.Add(Me.btnIngMp)
        Me.GrpOperTarea.Location = New System.Drawing.Point(303, 585)
        Me.GrpOperTarea.Name = "GrpOperTarea"
        Me.GrpOperTarea.Size = New System.Drawing.Size(654, 64)
        Me.GrpOperTarea.TabIndex = 3
        Me.GrpOperTarea.TabStop = False
        Me.GrpOperTarea.Text = "Operaciones"
        '
        'btnCambiarTareas
        '
        Me.btnCambiarTareas.Location = New System.Drawing.Point(571, 18)
        Me.btnCambiarTareas.Name = "btnCambiarTareas"
        Me.btnCambiarTareas.Size = New System.Drawing.Size(77, 36)
        Me.btnCambiarTareas.TabIndex = 6
        Me.btnCambiarTareas.Text = "Cambiar ID Modulos"
        Me.btnCambiarTareas.UseVisualStyleBackColor = True
        Me.btnCambiarTareas.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.mantencion.My.Resources.Resources._16__Exit_
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(477, 25)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 23)
        Me.btnSalir.TabIndex = 20
        Me.btnSalir.Text = "   Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGuardarComoNuevoCiclo
        '
        Me.btnGuardarComoNuevoCiclo.Image = Global.mantencion.My.Resources.Resources.add
        Me.btnGuardarComoNuevoCiclo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardarComoNuevoCiclo.Location = New System.Drawing.Point(138, 25)
        Me.btnGuardarComoNuevoCiclo.Name = "btnGuardarComoNuevoCiclo"
        Me.btnGuardarComoNuevoCiclo.Size = New System.Drawing.Size(161, 23)
        Me.btnGuardarComoNuevoCiclo.TabIndex = 18
        Me.btnGuardarComoNuevoCiclo.Text = "    Guardar Como Nuevo Ciclo"
        Me.btnGuardarComoNuevoCiclo.UseVisualStyleBackColor = True
        '
        'btnLimpiarCiclo
        '
        Me.btnLimpiarCiclo.Image = Global.mantencion.My.Resources.Resources._16__Clear_
        Me.btnLimpiarCiclo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarCiclo.Location = New System.Drawing.Point(391, 25)
        Me.btnLimpiarCiclo.Name = "btnLimpiarCiclo"
        Me.btnLimpiarCiclo.Size = New System.Drawing.Size(80, 23)
        Me.btnLimpiarCiclo.TabIndex = 16
        Me.btnLimpiarCiclo.Text = "    Limpiar"
        Me.btnLimpiarCiclo.UseVisualStyleBackColor = True
        '
        'btnGuardarMp
        '
        Me.btnGuardarMp.Image = Global.mantencion.My.Resources.Resources.icono_escritura_2
        Me.btnGuardarMp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardarMp.Location = New System.Drawing.Point(305, 25)
        Me.btnGuardarMp.Name = "btnGuardarMp"
        Me.btnGuardarMp.Size = New System.Drawing.Size(80, 23)
        Me.btnGuardarMp.TabIndex = 1
        Me.btnGuardarMp.Text = "    Guardar"
        Me.btnGuardarMp.UseVisualStyleBackColor = True
        '
        'btnIngMp
        '
        Me.btnIngMp.Image = Global.mantencion.My.Resources.Resources.guardar_16x16
        Me.btnIngMp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngMp.Location = New System.Drawing.Point(42, 25)
        Me.btnIngMp.Name = "btnIngMp"
        Me.btnIngMp.Size = New System.Drawing.Size(90, 23)
        Me.btnIngMp.TabIndex = 0
        Me.btnIngMp.Text = "     Ingresar MP"
        Me.btnIngMp.UseVisualStyleBackColor = True
        '
        'GrpCiclosMp
        '
        Me.GrpCiclosMp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCiclosMp.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.GrpCiclosMp.Controls.Add(Me.btnBuscarCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.txtIdCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.btnNuevoCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.btnEliminarCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.lblEstadoCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.cmbEstadoCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.lblObsCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.txtObsCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.Label1)
        Me.GrpCiclosMp.Controls.Add(Me.txtDuracionCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.lblHrFinCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.HrFinCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.lblFechaFinCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.fechaFinCicloMp)
        Me.GrpCiclosMp.Controls.Add(Me.lblHrInicioCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.HrInicioCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.lblFechaInicio)
        Me.GrpCiclosMp.Controls.Add(Me.FechaIniCiclo)
        Me.GrpCiclosMp.Controls.Add(Me.lblIdCiclo)
        Me.GrpCiclosMp.Location = New System.Drawing.Point(262, 149)
        Me.GrpCiclosMp.Name = "GrpCiclosMp"
        Me.GrpCiclosMp.Size = New System.Drawing.Size(746, 153)
        Me.GrpCiclosMp.TabIndex = 4
        Me.GrpCiclosMp.TabStop = False
        Me.GrpCiclosMp.Text = "Ciclos"
        '
        'btnBuscarCiclo
        '
        Me.btnBuscarCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscarCiclo.Image = Global.mantencion.My.Resources.Resources._16__Find_
        Me.btnBuscarCiclo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarCiclo.Location = New System.Drawing.Point(542, 121)
        Me.btnBuscarCiclo.Name = "btnBuscarCiclo"
        Me.btnBuscarCiclo.Size = New System.Drawing.Size(96, 23)
        Me.btnBuscarCiclo.TabIndex = 18
        Me.btnBuscarCiclo.Text = "     Buscar Ciclo"
        Me.btnBuscarCiclo.UseVisualStyleBackColor = True
        '
        'txtIdCiclo
        '
        Me.txtIdCiclo.BackColor = System.Drawing.Color.FromArgb(215, 230, 234)
        Me.txtIdCiclo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.txtIdCiclo.ReadOnly = True
        Me.txtIdCiclo.Location = New System.Drawing.Point(9, 45)
        Me.txtIdCiclo.Name = "txtIdCiclo"
        Me.txtIdCiclo.Size = New System.Drawing.Size(57, 20)
        Me.txtIdCiclo.TabIndex = 17
        '
        'btnNuevoCiclo
        '
        Me.btnNuevoCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevoCiclo.Image = Global.mantencion.My.Resources.Resources.add
        Me.btnNuevoCiclo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevoCiclo.Location = New System.Drawing.Point(644, 92)
        Me.btnNuevoCiclo.Name = "btnNuevoCiclo"
        Me.btnNuevoCiclo.Size = New System.Drawing.Size(96, 23)
        Me.btnNuevoCiclo.TabIndex = 16
        Me.btnNuevoCiclo.Text = "    Nuevo Ciclo"
        Me.btnNuevoCiclo.UseVisualStyleBackColor = True
        '
        'btnEliminarCiclo
        '
        Me.btnEliminarCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarCiclo.Image = Global.mantencion.My.Resources.Resources._16__Delete_
        Me.btnEliminarCiclo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminarCiclo.Location = New System.Drawing.Point(644, 121)
        Me.btnEliminarCiclo.Name = "btnEliminarCiclo"
        Me.btnEliminarCiclo.Size = New System.Drawing.Size(96, 23)
        Me.btnEliminarCiclo.TabIndex = 17
        Me.btnEliminarCiclo.Text = "     Eliminar Ciclo"
        Me.btnEliminarCiclo.UseVisualStyleBackColor = True
        '
        'lblEstadoCiclo
        '
        Me.lblEstadoCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEstadoCiclo.AutoSize = True
        Me.lblEstadoCiclo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoCiclo.Location = New System.Drawing.Point(530, 27)
        Me.lblEstadoCiclo.Name = "lblEstadoCiclo"
        Me.lblEstadoCiclo.Size = New System.Drawing.Size(71, 15)
        Me.lblEstadoCiclo.TabIndex = 15
        Me.lblEstadoCiclo.Text = "Estado Ciclo"
        '
        'cmbEstadoCiclo
        '
        Me.cmbEstadoCiclo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEstadoCiclo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoCiclo.FormattingEnabled = True
        Me.cmbEstadoCiclo.Location = New System.Drawing.Point(532, 43)
        Me.cmbEstadoCiclo.Name = "cmbEstadoCiclo"
        Me.cmbEstadoCiclo.Size = New System.Drawing.Size(108, 21)
        Me.cmbEstadoCiclo.TabIndex = 10
        '
        'lblObsCiclo
        '
        Me.lblObsCiclo.AutoSize = True
        Me.lblObsCiclo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObsCiclo.Location = New System.Drawing.Point(6, 76)
        Me.lblObsCiclo.Name = "lblObsCiclo"
        Me.lblObsCiclo.Size = New System.Drawing.Size(102, 15)
        Me.lblObsCiclo.TabIndex = 13
        Me.lblObsCiclo.Text = "Observación Ciclo"
        '
        'txtObsCiclo
        '
        Me.txtObsCiclo.Location = New System.Drawing.Point(9, 95)
        Me.txtObsCiclo.MaxLength = 300
        Me.txtObsCiclo.Multiline = True
        Me.txtObsCiclo.Name = "txtObsCiclo"
        Me.txtObsCiclo.Size = New System.Drawing.Size(476, 49)
        Me.txtObsCiclo.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(476, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Duración"
        '
        'txtDuracionCiclo
        '
        Me.txtDuracionCiclo.BackColor = System.Drawing.Color.FromArgb(215, 230, 234)
        Me.txtDuracionCiclo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.txtDuracionCiclo.ReadOnly = True
        Me.txtDuracionCiclo.Location = New System.Drawing.Point(478, 44)
        Me.txtDuracionCiclo.Name = "txtDuracionCiclo"
        Me.txtDuracionCiclo.Size = New System.Drawing.Size(44, 20)
        Me.txtDuracionCiclo.TabIndex = 10
        '
        'lblHrFinCiclo
        '
        Me.lblHrFinCiclo.AutoSize = True
        Me.lblHrFinCiclo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHrFinCiclo.Location = New System.Drawing.Point(398, 26)
        Me.lblHrFinCiclo.Name = "lblHrFinCiclo"
        Me.lblHrFinCiclo.Size = New System.Drawing.Size(82, 15)
        Me.lblHrFinCiclo.TabIndex = 9
        Me.lblHrFinCiclo.Text = "Hora Término"
        '
        'HrFinCiclo
        '
        Me.HrFinCiclo.CustomFormat = "HH:mm"
        Me.HrFinCiclo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.HrFinCiclo.Location = New System.Drawing.Point(400, 44)
        Me.HrFinCiclo.Name = "HrFinCiclo"
        Me.HrFinCiclo.ShowUpDown = True
        Me.HrFinCiclo.Size = New System.Drawing.Size(68, 23)
        Me.HrFinCiclo.TabIndex = 8
        Me.HrFinCiclo.Value = New Date(2012, 5, 30, 0, 0, 0, 0)
        '
        'lblFechaFinCiclo
        '
        Me.lblFechaFinCiclo.AutoSize = True
        Me.lblFechaFinCiclo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFinCiclo.Location = New System.Drawing.Point(279, 26)
        Me.lblFechaFinCiclo.Name = "lblFechaFinCiclo"
        Me.lblFechaFinCiclo.Size = New System.Drawing.Size(87, 15)
        Me.lblFechaFinCiclo.TabIndex = 7
        Me.lblFechaFinCiclo.Text = "Fecha Término"
        '
        'fechaFinCicloMp
        '
        Me.fechaFinCicloMp.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fechaFinCicloMp.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fechaFinCicloMp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechaFinCicloMp.Location = New System.Drawing.Point(282, 44)
        Me.fechaFinCicloMp.Name = "fechaFinCicloMp"
        Me.fechaFinCicloMp.Size = New System.Drawing.Size(108, 23)
        Me.fechaFinCicloMp.TabIndex = 7
        '
        'lblHrInicioCiclo
        '
        Me.lblHrInicioCiclo.AutoSize = True
        Me.lblHrInicioCiclo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHrInicioCiclo.Location = New System.Drawing.Point(199, 26)
        Me.lblHrInicioCiclo.Name = "lblHrInicioCiclo"
        Me.lblHrInicioCiclo.Size = New System.Drawing.Size(64, 15)
        Me.lblHrInicioCiclo.TabIndex = 5
        Me.lblHrInicioCiclo.Text = "Hora Inicio"
        '
        'HrInicioCiclo
        '
        Me.HrInicioCiclo.CustomFormat = "HH:mm"
        Me.HrInicioCiclo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.HrInicioCiclo.Location = New System.Drawing.Point(202, 44)
        Me.HrInicioCiclo.Name = "HrInicioCiclo"
        Me.HrInicioCiclo.ShowUpDown = True
        Me.HrInicioCiclo.Size = New System.Drawing.Size(68, 23)
        Me.HrInicioCiclo.TabIndex = 6
        Me.HrInicioCiclo.Value = New Date(2012, 5, 30, 0, 0, 0, 0)
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicio.Location = New System.Drawing.Point(81, 26)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(69, 15)
        Me.lblFechaInicio.TabIndex = 3
        Me.lblFechaInicio.Text = "Fecha Inicio"
        '
        'FechaIniCiclo
        '
        Me.FechaIniCiclo.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.FechaIniCiclo.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.FechaIniCiclo.CustomFormat = "dd-MM-yyyy"
        Me.FechaIniCiclo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FechaIniCiclo.Location = New System.Drawing.Point(84, 44)
        Me.FechaIniCiclo.Name = "FechaIniCiclo"
        Me.FechaIniCiclo.Size = New System.Drawing.Size(108, 23)
        Me.FechaIniCiclo.TabIndex = 5
        '
        'lblIdCiclo
        '
        Me.lblIdCiclo.AutoSize = True
        Me.lblIdCiclo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCiclo.Location = New System.Drawing.Point(6, 26)
        Me.lblIdCiclo.Name = "lblIdCiclo"
        Me.lblIdCiclo.Size = New System.Drawing.Size(48, 15)
        Me.lblIdCiclo.TabIndex = 1
        Me.lblIdCiclo.Text = "N° Ciclo"
        '
        'GrpInfAdicional
        '
        Me.GrpInfAdicional.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpInfAdicional.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.GrpInfAdicional.Controls.Add(Me.hrsCiclo)
        Me.GrpInfAdicional.Controls.Add(Me.lblHrsCiclo)
        Me.GrpInfAdicional.Controls.Add(Me.btnDelFila)
        Me.GrpInfAdicional.Controls.Add(Me.btnAgrFila)
        Me.GrpInfAdicional.Controls.Add(Me.TabMp)
        Me.GrpInfAdicional.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpInfAdicional.Location = New System.Drawing.Point(262, 308)
        Me.GrpInfAdicional.Name = "GrpInfAdicional"
        Me.GrpInfAdicional.Size = New System.Drawing.Size(746, 271)
        Me.GrpInfAdicional.TabIndex = 5
        Me.GrpInfAdicional.TabStop = False
        Me.GrpInfAdicional.Text = "Información Adicional"
        '
        'hrsCiclo
        '
        Me.hrsCiclo.AutoSize = True
        Me.hrsCiclo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hrsCiclo.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28)
        Me.hrsCiclo.Location = New System.Drawing.Point(587, 21)
        Me.hrsCiclo.Name = "hrsCiclo"
        Me.hrsCiclo.Size = New System.Drawing.Size(24, 15)
        Me.hrsCiclo.TabIndex = 17
        Me.hrsCiclo.Text = "hrs"
        '
        'lblHrsCiclo
        '
        Me.lblHrsCiclo.AutoSize = True
        Me.lblHrsCiclo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHrsCiclo.Location = New System.Drawing.Point(347, 21)
        Me.lblHrsCiclo.Name = "lblHrsCiclo"
        Me.lblHrsCiclo.Size = New System.Drawing.Size(234, 15)
        Me.lblHrsCiclo.TabIndex = 4
        Me.lblHrsCiclo.Text = "Horas Transcurridas desde el último ciclo :"
        '
        'btnDelFila
        '
        Me.btnDelFila.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelFila.Image = Global.mantencion.My.Resources.Resources.action_remove
        Me.btnDelFila.Location = New System.Drawing.Point(718, 68)
        Me.btnDelFila.Name = "btnDelFila"
        Me.btnDelFila.Size = New System.Drawing.Size(22, 22)
        Me.btnDelFila.TabIndex = 16
        Me.btnDelFila.UseVisualStyleBackColor = True
        '
        'btnAgrFila
        '
        Me.btnAgrFila.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgrFila.Image = Global.mantencion.My.Resources.Resources.add
        Me.btnAgrFila.Location = New System.Drawing.Point(718, 40)
        Me.btnAgrFila.Name = "btnAgrFila"
        Me.btnAgrFila.Size = New System.Drawing.Size(22, 22)
        Me.btnAgrFila.TabIndex = 1
        Me.btnAgrFila.UseVisualStyleBackColor = True
        '
        'TabMp
        '
        Me.TabMp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMp.Controls.Add(Me.TareasCicloMp)
        Me.TabMp.Controls.Add(Me.PerCicloMp)
        Me.TabMp.Controls.Add(Me.InsCicloMp)
        Me.TabMp.Controls.Add(Me.TareasAdMp)
        Me.TabMp.Location = New System.Drawing.Point(9, 20)
        Me.TabMp.Name = "TabMp"
        Me.TabMp.SelectedIndex = 0
        Me.TabMp.Size = New System.Drawing.Size(703, 245)
        Me.TabMp.TabIndex = 0
        '
        'TareasCicloMp
        '
        Me.TareasCicloMp.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.TareasCicloMp.Controls.Add(Me.btn_Limpiar_tabla)
        Me.TareasCicloMp.Controls.Add(Me.chkSelTodo)
        Me.TareasCicloMp.Controls.Add(Me.btn_agr_tareas)
        Me.TareasCicloMp.Controls.Add(Me.grillaTareasCicloMp)
        Me.TareasCicloMp.Location = New System.Drawing.Point(4, 22)
        Me.TareasCicloMp.Name = "TareasCicloMp"
        Me.TareasCicloMp.Size = New System.Drawing.Size(695, 219)
        Me.TareasCicloMp.TabIndex = 2
        Me.TareasCicloMp.Text = "Tareas"
        Me.TareasCicloMp.UseVisualStyleBackColor = True
        '
        'btn_Limpiar_tabla
        '
        Me.btn_Limpiar_tabla.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Limpiar_tabla.Image = Global.mantencion.My.Resources.Resources.clear
        Me.btn_Limpiar_tabla.Location = New System.Drawing.Point(663, 38)
        Me.btn_Limpiar_tabla.Name = "btn_Limpiar_tabla"
        Me.btn_Limpiar_tabla.Size = New System.Drawing.Size(29, 29)
        Me.btn_Limpiar_tabla.TabIndex = 3
        Me.ToolTip2.SetToolTip(Me.btn_Limpiar_tabla, "Limpiar Valores Tareas MP")
        Me.btn_Limpiar_tabla.UseVisualStyleBackColor = True
        '
        'chkSelTodo
        '
        Me.chkSelTodo.AutoSize = True
        Me.chkSelTodo.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.chkSelTodo.Location = New System.Drawing.Point(4, 4)
        Me.chkSelTodo.Name = "chkSelTodo"
        Me.chkSelTodo.Size = New System.Drawing.Size(69, 17)
        Me.chkSelTodo.TabIndex = 2
        Me.chkSelTodo.Text = "Sel.Todo"
        Me.chkSelTodo.UseVisualStyleBackColor = False
        '
        'btn_agr_tareas
        '
        Me.btn_agr_tareas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_agr_tareas.Image = Global.mantencion.My.Resources.Resources.agregar_tareas
        Me.btn_agr_tareas.Location = New System.Drawing.Point(663, 3)
        Me.btn_agr_tareas.Name = "btn_agr_tareas"
        Me.btn_agr_tareas.Size = New System.Drawing.Size(29, 29)
        Me.btn_agr_tareas.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.btn_agr_tareas, "Buscar Tareas Asociadas")
        Me.btn_agr_tareas.UseVisualStyleBackColor = True
        '
        'grillaTareasCicloMp
        '
        Me.grillaTareasCicloMp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grillaTareasCicloMp.AllowUserToAddRows = False
        DataGridViewCellStyle30.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaTareasCicloMp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle30
        Me.grillaTareasCicloMp.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle31.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle31.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaTareasCicloMp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle31
        Me.grillaTareasCicloMp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaTareasCicloMp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.realizada})
        Me.grillaTareasCicloMp.EnableHeadersVisualStyles = False
        Me.grillaTareasCicloMp.GridColor = System.Drawing.SystemColors.ControlText
        Me.grillaTareasCicloMp.Location = New System.Drawing.Point(3, 26)
        Me.grillaTareasCicloMp.Name = "grillaTareasCicloMp"
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle32.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle32.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaTareasCicloMp.RowHeadersDefaultCellStyle = DataGridViewCellStyle32
        Me.grillaTareasCicloMp.RowHeadersWidth = 20
        Me.grillaTareasCicloMp.Size = New System.Drawing.Size(654, 190)
        Me.grillaTareasCicloMp.TabIndex = 0
        '
        'realizada
        '
        Me.realizada.DividerWidth = 1
        Me.realizada.HeaderText = "Realizada"
        Me.realizada.Name = "realizada"
        Me.realizada.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.realizada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.realizada.Width = 70
        '
        'PerCicloMp
        '
        Me.PerCicloMp.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.PerCicloMp.Controls.Add(Me.btn_buscar_personal_mp)
        Me.PerCicloMp.Controls.Add(Me.grillaPersonalMp)
        Me.PerCicloMp.Location = New System.Drawing.Point(4, 22)
        Me.PerCicloMp.Name = "PerCicloMp"
        Me.PerCicloMp.Padding = New System.Windows.Forms.Padding(3)
        Me.PerCicloMp.Size = New System.Drawing.Size(695, 219)
        Me.PerCicloMp.TabIndex = 0
        Me.PerCicloMp.Text = "Personal"
        Me.PerCicloMp.UseVisualStyleBackColor = True
        '
        'btn_buscar_personal_mp
        '
        Me.btn_buscar_personal_mp.Image = Global.mantencion.My.Resources.Resources.icono_buscar1
        Me.btn_buscar_personal_mp.Location = New System.Drawing.Point(333, 6)
        Me.btn_buscar_personal_mp.Name = "btn_buscar_personal_mp"
        Me.btn_buscar_personal_mp.Size = New System.Drawing.Size(29, 29)
        Me.btn_buscar_personal_mp.TabIndex = 1
        Me.btn_buscar_personal_mp.UseVisualStyleBackColor = True
        '
        'grillaPersonalMp
        '
        Me.grillaPersonalMp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grillaPersonalMp.AllowUserToAddRows = False
        Me.grillaPersonalMp.AllowUserToDeleteRows = False
        Me.grillaPersonalMp.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle33.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaPersonalMp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle33
        Me.grillaPersonalMp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaPersonalMp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rut_personal, Me.nombre_personal})
        Me.grillaPersonalMp.EnableHeadersVisualStyles = False
        Me.grillaPersonalMp.Location = New System.Drawing.Point(3, 3)
        Me.grillaPersonalMp.Name = "grillaPersonalMp"
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle34.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle34.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaPersonalMp.RowHeadersDefaultCellStyle = DataGridViewCellStyle34
        Me.grillaPersonalMp.RowHeadersWidth = 20
        Me.grillaPersonalMp.Size = New System.Drawing.Size(324, 210)
        Me.grillaPersonalMp.TabIndex = 0
        '
        'rut_personal
        '
        Me.rut_personal.HeaderText = "Rut"
        Me.rut_personal.MaxInputLength = 10
        Me.rut_personal.Name = "rut_personal"
        Me.rut_personal.Width = 80
        '
        'nombre_personal
        '
        Me.nombre_personal.HeaderText = "Nombre"
        Me.nombre_personal.MaxInputLength = 30
        Me.nombre_personal.Name = "nombre_personal"
        Me.nombre_personal.Width = 200
        '
        'InsCicloMp
        '
        Me.InsCicloMp.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.InsCicloMp.Controls.Add(Me.grillaInsumosMp)
        Me.InsCicloMp.Location = New System.Drawing.Point(4, 22)
        Me.InsCicloMp.Name = "InsCicloMp"
        Me.InsCicloMp.Padding = New System.Windows.Forms.Padding(3)
        Me.InsCicloMp.Size = New System.Drawing.Size(695, 219)
        Me.InsCicloMp.TabIndex = 1
        Me.InsCicloMp.Text = "Insumos Utilizados"
        Me.InsCicloMp.UseVisualStyleBackColor = True
        '
        'grillaInsumosMp
        '
        Me.grillaInsumosMp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grillaInsumosMp.AllowUserToAddRows = False
        Me.grillaInsumosMp.AllowUserToDeleteRows = False
        Me.grillaInsumosMp.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle35.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle35.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaInsumosMp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle35
        Me.grillaInsumosMp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaInsumosMp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_insumo, Me.cod_sap, Me.desc_insumo, Me.cant_insumo, Me.unid_medida, Me.precio_unid})
        Me.grillaInsumosMp.EnableHeadersVisualStyles = False
        Me.grillaInsumosMp.Location = New System.Drawing.Point(3, 3)
        Me.grillaInsumosMp.Name = "grillaInsumosMp"
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle36.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle36.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaInsumosMp.RowHeadersDefaultCellStyle = DataGridViewCellStyle36
        Me.grillaInsumosMp.RowHeadersWidth = 20
        Me.grillaInsumosMp.Size = New System.Drawing.Size(686, 210)
        Me.grillaInsumosMp.TabIndex = 0
        '
        'id_insumo
        '
        Me.id_insumo.HeaderText = "ID Insumo"
        Me.id_insumo.MaxInputLength = 15
        Me.id_insumo.Name = "id_insumo"
        Me.id_insumo.ReadOnly = True
        Me.id_insumo.Width = 90
        '
        'cod_sap
        '
        Me.cod_sap.HeaderText = "Código SAP"
        Me.cod_sap.Name = "cod_sap"
        Me.cod_sap.ReadOnly = True
        '
        'desc_insumo
        '
        Me.desc_insumo.HeaderText = "Descripción"
        Me.desc_insumo.Name = "desc_insumo"
        Me.desc_insumo.ReadOnly = True
        Me.desc_insumo.Width = 400
        '
        'cant_insumo
        '
        Me.cant_insumo.HeaderText = "Cantidad"
        Me.cant_insumo.Name = "cant_insumo"
        Me.cant_insumo.Width = 60
        '
        'unid_medida
        '
        Me.unid_medida.HeaderText = "Unid.Medida"
        Me.unid_medida.Items.AddRange(New Object() {"Unid.", "Lote", "Kg.", "Gr.", "Pqt."})
        Me.unid_medida.Name = "unid_medida"
        Me.unid_medida.Width = 80
        '
        'precio_unid
        '
        Me.precio_unid.HeaderText = "Precio Unitario"
        Me.precio_unid.MaxInputLength = 12
        Me.precio_unid.Name = "precio_unid"
        Me.precio_unid.ReadOnly = True
        Me.precio_unid.Width = 120
        '
        'TareasAdMp
        '
        Me.TareasAdMp.Controls.Add(Me.Panel2)
        Me.TareasAdMp.Controls.Add(Me.Label4)
        Me.TareasAdMp.Controls.Add(Me.Panel1)
        Me.TareasAdMp.Controls.Add(Me.lblFiltro)
        Me.TareasAdMp.Controls.Add(Me.txtBuscarTarea)
        Me.TareasAdMp.Controls.Add(Me.grillaTareasAdMp)
        Me.TareasAdMp.Controls.Add(Me.btnAgrTareas)
        Me.TareasAdMp.Location = New System.Drawing.Point(4, 22)
        Me.TareasAdMp.Name = "TareasAdMp"
        Me.TareasAdMp.Padding = New System.Windows.Forms.Padding(3)
        Me.TareasAdMp.Size = New System.Drawing.Size(695, 219)
        Me.TareasAdMp.TabIndex = 3
        Me.TareasAdMp.Text = "Tareas Adicionales"
        Me.TareasAdMp.UseVisualStyleBackColor = True
        '
        'Opc_tareas_ele
        '
        Me.Opc_tareas_ele.AutoSize = True
        Me.Opc_tareas_ele.Location = New System.Drawing.Point(108, 15)
        Me.Opc_tareas_ele.Name = "Opc_tareas_ele"
        Me.Opc_tareas_ele.Size = New System.Drawing.Size(93, 17)
        Me.Opc_tareas_ele.TabIndex = 5
        Me.Opc_tareas_ele.Text = "Mant.Eléctrica"
        Me.Opc_tareas_ele.UseVisualStyleBackColor = True
        '
        'opc_tareas_mec
        '
        Me.opc_tareas_mec.AutoSize = True
        Me.opc_tareas_mec.Checked = True
        Me.opc_tareas_mec.Location = New System.Drawing.Point(3, 15)
        Me.opc_tareas_mec.Name = "opc_tareas_mec"
        Me.opc_tareas_mec.Size = New System.Drawing.Size(99, 17)
        Me.opc_tareas_mec.TabIndex = 4
        Me.opc_tareas_mec.TabStop = True
        Me.opc_tareas_mec.Text = "Mant.Mecánica"
        Me.opc_tareas_mec.UseVisualStyleBackColor = True
        '
        'lblFiltro
        '
        Me.lblFiltro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFiltro.AutoSize = True
        Me.lblFiltro.Location = New System.Drawing.Point(468, 6)
        Me.lblFiltro.Name = "lblFiltro"
        Me.lblFiltro.Size = New System.Drawing.Size(148, 13)
        Me.lblFiltro.TabIndex = 2
        Me.lblFiltro.Text = "Ingrese el nombre de la Tarea"
        '
        'txtBuscarTarea
        '
        Me.txtBuscarTarea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuscarTarea.Location = New System.Drawing.Point(469, 21)
        Me.txtBuscarTarea.Name = "txtBuscarTarea"
        Me.txtBuscarTarea.Size = New System.Drawing.Size(185, 20)
        Me.txtBuscarTarea.TabIndex = 1
        '
        'grillaTareasAdMp
        '
        Me.grillaTareasAdMp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grillaTareasAdMp.AllowUserToAddRows = False
        Me.grillaTareasAdMp.AllowUserToDeleteRows = False
        DataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaTareasAdMp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle28
        Me.grillaTareasAdMp.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaTareasAdMp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle29
        Me.grillaTareasAdMp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaTareasAdMp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.select_tarea})
        Me.grillaTareasAdMp.EnableHeadersVisualStyles = False
        Me.grillaTareasAdMp.Location = New System.Drawing.Point(6, 44)
        Me.grillaTareasAdMp.Name = "grillaTareasAdMp"
        Me.grillaTareasAdMp.RowHeadersVisible = False
        Me.grillaTareasAdMp.Size = New System.Drawing.Size(683, 169)
        Me.grillaTareasAdMp.TabIndex = 0
        '
        'select_tarea
        '
        Me.select_tarea.HeaderText = "Sel."
        Me.select_tarea.Name = "select_tarea"
        Me.select_tarea.Width = 30
        '
        'btnAgrTareas
        '
        Me.btnAgrTareas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgrTareas.BackgroundImage = Global.mantencion.My.Resources.Resources.agregar_tareas
        Me.btnAgrTareas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAgrTareas.Location = New System.Drawing.Point(660, 13)
        Me.btnAgrTareas.Name = "btnAgrTareas"
        Me.btnAgrTareas.Size = New System.Drawing.Size(29, 29)
        Me.btnAgrTareas.TabIndex = 3
        Me.btnAgrTareas.UseVisualStyleBackColor = True
        '
        'opc_seccion
        '
        Me.opc_seccion.AutoSize = True
        Me.opc_seccion.Checked = True
        Me.opc_seccion.Location = New System.Drawing.Point(3, 15)
        Me.opc_seccion.Name = "opc_seccion"
        Me.opc_seccion.Size = New System.Drawing.Size(64, 17)
        Me.opc_seccion.TabIndex = 6
        Me.opc_seccion.TabStop = True
        Me.opc_seccion.Text = "Sección"
        Me.opc_seccion.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.opc_tareas_mec)
        Me.Panel1.Controls.Add(Me.Opc_tareas_ele)
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(202, 35)
        Me.Panel1.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tipo de mantención"
        '
        'opc_mod_maq
        '
        Me.opc_mod_maq.AutoSize = True
        Me.opc_mod_maq.Location = New System.Drawing.Point(73, 15)
        Me.opc_mod_maq.Name = "opc_mod_maq"
        Me.opc_mod_maq.Size = New System.Drawing.Size(112, 17)
        Me.opc_mod_maq.TabIndex = 7
        Me.opc_mod_maq.TabStop = True
        Me.opc_mod_maq.Text = "Módulo / Máquina"
        Me.opc_mod_maq.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.opc_seccion)
        Me.Panel2.Controls.Add(Me.opc_mod_maq)
        Me.Panel2.Location = New System.Drawing.Point(215, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(184, 35)
        Me.Panel2.TabIndex = 9
        '
        'FrmMp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1020, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpInfAdicional)
        Me.Controls.Add(Me.GrpCiclosMp)
        Me.Controls.Add(Me.GrpOperTarea)
        Me.Controls.Add(Me.GrpTareasNodo)
        Me.Controls.Add(Me.txtBuscarNodo1)
        Me.Controls.Add(Me.arbol1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Gestión Mantención Preventiva"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.GrpTareasNodo.ResumeLayout(False)
        Me.GrpTareasNodo.PerformLayout()
        Me.GrpOperTarea.ResumeLayout(False)
        Me.GrpCiclosMp.ResumeLayout(False)
        Me.GrpCiclosMp.PerformLayout()
        Me.GrpInfAdicional.ResumeLayout(False)
        Me.GrpInfAdicional.PerformLayout()
        Me.TabMp.ResumeLayout(False)
        Me.TareasCicloMp.ResumeLayout(False)
        Me.TareasCicloMp.PerformLayout()
        CType(Me.grillaTareasCicloMp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PerCicloMp.ResumeLayout(False)
        CType(Me.grillaPersonalMp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InsCicloMp.ResumeLayout(False)
        CType(Me.grillaInsumosMp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TareasAdMp.ResumeLayout(False)
        Me.TareasAdMp.PerformLayout()
        CType(Me.grillaTareasAdMp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents arbol1 As System.Windows.Forms.TreeView
    Friend WithEvents txtBuscarNodo1 As System.Windows.Forms.TextBox
    Friend WithEvents GrpTareasNodo As System.Windows.Forms.GroupBox
    Friend WithEvents GrpOperTarea As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardarMp As System.Windows.Forms.Button
    Friend WithEvents btnIngMp As System.Windows.Forms.Button
    Friend WithEvents lblIdMant As System.Windows.Forms.Label
    Friend WithEvents txtIdMant As System.Windows.Forms.TextBox
    Friend WithEvents lblTiempoAviso As System.Windows.Forms.Label
    Friend WithEvents txtTiempoAviso As System.Windows.Forms.TextBox
    Friend WithEvents lblfrecuencia As System.Windows.Forms.Label
    Friend WithEvents txtFrecuenciaMp As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarMp As System.Windows.Forms.Button
    Friend WithEvents lblEstadoMp As System.Windows.Forms.Label
    Friend WithEvents cmbEstadoMp As System.Windows.Forms.ComboBox
    Friend WithEvents GrpCiclosMp As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents FechaIniCiclo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblIdCiclo As System.Windows.Forms.Label
    Friend WithEvents lblHrInicioCiclo As System.Windows.Forms.Label
    Friend WithEvents HrInicioCiclo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblHrFinCiclo As System.Windows.Forms.Label
    Friend WithEvents HrFinCiclo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaFinCiclo As System.Windows.Forms.Label
    Friend WithEvents fechaFinCicloMp As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEstadoCiclo As System.Windows.Forms.Label
    Friend WithEvents cmbEstadoCiclo As System.Windows.Forms.ComboBox
    Friend WithEvents lblObsCiclo As System.Windows.Forms.Label
    Friend WithEvents txtObsCiclo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDuracionCiclo As System.Windows.Forms.TextBox
    Friend WithEvents GrpInfAdicional As System.Windows.Forms.GroupBox
    Friend WithEvents TabMp As System.Windows.Forms.TabControl
    Friend WithEvents PerCicloMp As System.Windows.Forms.TabPage
    Friend WithEvents InsCicloMp As System.Windows.Forms.TabPage
    Friend WithEvents grillaPersonalMp As System.Windows.Forms.DataGridView
    Friend WithEvents btnAgrFila As System.Windows.Forms.Button
    Friend WithEvents btnDelFila As System.Windows.Forms.Button
    Friend WithEvents TareasCicloMp As System.Windows.Forms.TabPage
    Friend WithEvents grillaTareasCicloMp As System.Windows.Forms.DataGridView
    Friend WithEvents grillaInsumosMp As System.Windows.Forms.DataGridView
    Friend WithEvents btnNuevaMp As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarCiclo As System.Windows.Forms.Button
    Friend WithEvents btnEliminarCiclo As System.Windows.Forms.Button
    Friend WithEvents btnNuevoCiclo As System.Windows.Forms.Button
    Friend WithEvents lblTipoMp As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMp As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscarCiclo As System.Windows.Forms.Button
    Friend WithEvents txtIdCiclo As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardarComoNuevoCiclo As System.Windows.Forms.Button
    Friend WithEvents btnEliminarMp As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents realizada As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TareasAdMp As System.Windows.Forms.TabPage
    Friend WithEvents lblFiltro As System.Windows.Forms.Label
    Friend WithEvents txtBuscarTarea As System.Windows.Forms.TextBox
    Friend WithEvents grillaTareasAdMp As System.Windows.Forms.DataGridView
    Friend WithEvents btnAgrTareas As System.Windows.Forms.Button
    Friend WithEvents select_tarea As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents id_insumo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cod_sap As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc_insumo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cant_insumo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unid_medida As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents precio_unid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rut_personal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre_personal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_agr_tareas As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkSelTodo As System.Windows.Forms.CheckBox
    Friend WithEvents Opc_tareas_ele As System.Windows.Forms.RadioButton
    Friend WithEvents opc_tareas_mec As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtObsMant As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar_personal_mp As System.Windows.Forms.Button
    Friend WithEvents btnCambiarTareas As System.Windows.Forms.Button
    Friend WithEvents btn_Limpiar_tabla As System.Windows.Forms.Button
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents btnActMp As System.Windows.Forms.Button
    Friend WithEvents btn_plan_ciclos As System.Windows.Forms.Button
    Friend WithEvents hrsCiclo As System.Windows.Forms.Label
    Friend WithEvents lblHrsCiclo As System.Windows.Forms.Label
    Friend WithEvents opc_seccion As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents opc_mod_maq As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
