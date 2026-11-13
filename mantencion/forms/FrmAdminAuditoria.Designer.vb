<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdminAuditoria
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelSuperior = New System.Windows.Forms.Panel()
        Me.grpRangoFechas = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fecha_ini_aud = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.fecha_fin_aud = New System.Windows.Forms.DateTimePicker()
        Me.btn_buscar_aud = New System.Windows.Forms.Button()
        Me.grpFiltrosEnVivo = New System.Windows.Forms.GroupBox()
        Me.LabelSesion = New System.Windows.Forms.Label()
        Me.cboFiltroSesion = New System.Windows.Forms.ComboBox()
        Me.LabelOperacion = New System.Windows.Forms.Label()
        Me.cboFiltroOperacion = New System.Windows.Forms.ComboBox()
        Me.LabelPc = New System.Windows.Forms.Label()
        Me.cboFiltroPc = New System.Windows.Forms.ComboBox()
        Me.LabelTabla = New System.Windows.Forms.Label()
        Me.cboFiltroTabla = New System.Windows.Forms.ComboBox()
        Me.LabelBuscar = New System.Windows.Forms.Label()
        Me.txtBusquedaRapida = New System.Windows.Forms.TextBox()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.grpAcciones = New System.Windows.Forms.GroupBox()
        Me.btn_exp_excel = New System.Windows.Forms.Button()
        Me.btn_salir_aud = New System.Windows.Forms.Button()
        Me.pnlKpis = New System.Windows.Forms.Panel()
        Me.tblKpis = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlCard1 = New System.Windows.Forms.Panel()
        Me.lblTitKpi1 = New System.Windows.Forms.Label()
        Me.lblKpiTotalOps = New System.Windows.Forms.Label()
        Me.pnlCard2 = New System.Windows.Forms.Panel()
        Me.lblTitKpi2 = New System.Windows.Forms.Label()
        Me.lblKpiInserciones = New System.Windows.Forms.Label()
        Me.pnlCard3 = New System.Windows.Forms.Panel()
        Me.lblTitKpi3 = New System.Windows.Forms.Label()
        Me.lblKpiActualizaciones = New System.Windows.Forms.Label()
        Me.pnlCard4 = New System.Windows.Forms.Panel()
        Me.lblTitKpi4 = New System.Windows.Forms.Label()
        Me.lblKpiEliminaciones = New System.Windows.Forms.Label()
        Me.pnlCard5 = New System.Windows.Forms.Panel()
        Me.lblTitKpi5 = New System.Windows.Forms.Label()
        Me.lblKpiTopUsuario = New System.Windows.Forms.Label()
        Me.pnlCard6 = New System.Windows.Forms.Panel()
        Me.lblTitKpi6 = New System.Windows.Forms.Label()
        Me.lblKpiTopPc = New System.Windows.Forms.Label()
        Me.tabAuditoria = New System.Windows.Forms.TabControl()
        Me.tabDetalle = New System.Windows.Forms.TabPage()
        Me.grillaAuditoria = New System.Windows.Forms.DataGridView()
        Me.pnlStatusAuditoria = New System.Windows.Forms.Panel()
        Me.lblEstadoRegistros = New System.Windows.Forms.Label()
        Me.lblEstadoSeleccion = New System.Windows.Forms.Label()
        Me.tabEstadisticas = New System.Windows.Forms.TabPage()
        Me.tabSubEstadisticas = New System.Windows.Forms.TabControl()
        Me.tabSubSesion = New System.Windows.Forms.TabPage()
        Me.grillaStatSesion = New System.Windows.Forms.DataGridView()
        Me.tabSubOperacion = New System.Windows.Forms.TabPage()
        Me.grillaStatOperacion = New System.Windows.Forms.DataGridView()
        Me.tabSubPc = New System.Windows.Forms.TabPage()
        Me.grillaStatPc = New System.Windows.Forms.DataGridView()
        Me.tabSubTabla = New System.Windows.Forms.TabPage()
        Me.grillaStatTabla = New System.Windows.Forms.DataGridView()
        Me.tabSubFecha = New System.Windows.Forms.TabPage()
        Me.grillaStatFecha = New System.Windows.Forms.DataGridView()
        Me.pnlHeaderStats = New System.Windows.Forms.Panel()
        Me.lblTitEstadisticas = New System.Windows.Forms.Label()
        Me.lblTipStats = New System.Windows.Forms.Label()
        Me.btnExpEstadisticas = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PanelSuperior.SuspendLayout()
        Me.grpRangoFechas.SuspendLayout()
        Me.grpFiltrosEnVivo.SuspendLayout()
        Me.grpAcciones.SuspendLayout()
        Me.pnlKpis.SuspendLayout()
        Me.tblKpis.SuspendLayout()
        Me.pnlCard1.SuspendLayout()
        Me.pnlCard2.SuspendLayout()
        Me.pnlCard3.SuspendLayout()
        Me.pnlCard4.SuspendLayout()
        Me.pnlCard5.SuspendLayout()
        Me.pnlCard6.SuspendLayout()
        Me.tabAuditoria.SuspendLayout()
        Me.tabDetalle.SuspendLayout()
        CType(Me.grillaAuditoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStatusAuditoria.SuspendLayout()
        Me.tabEstadisticas.SuspendLayout()
        Me.tabSubEstadisticas.SuspendLayout()
        Me.tabSubSesion.SuspendLayout()
        CType(Me.grillaStatSesion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSubOperacion.SuspendLayout()
        CType(Me.grillaStatOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSubPc.SuspendLayout()
        CType(Me.grillaStatPc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSubTabla.SuspendLayout()
        CType(Me.grillaStatTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSubFecha.SuspendLayout()
        CType(Me.grillaStatFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeaderStats.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelSuperior.Controls.Add(Me.grpRangoFechas)
        Me.PanelSuperior.Controls.Add(Me.grpFiltrosEnVivo)
        Me.PanelSuperior.Controls.Add(Me.grpAcciones)
        Me.PanelSuperior.Location = New System.Drawing.Point(10, 5)
        Me.PanelSuperior.Name = "PanelSuperior"
        Me.PanelSuperior.Size = New System.Drawing.Size(1160, 96)
        Me.PanelSuperior.TabIndex = 0
        '
        'grpRangoFechas
        '
        Me.grpRangoFechas.Controls.Add(Me.Label1)
        Me.grpRangoFechas.Controls.Add(Me.fecha_ini_aud)
        Me.grpRangoFechas.Controls.Add(Me.Label2)
        Me.grpRangoFechas.Controls.Add(Me.fecha_fin_aud)
        Me.grpRangoFechas.Controls.Add(Me.btn_buscar_aud)
        Me.grpRangoFechas.Font = New System.Drawing.Font("Calibri", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpRangoFechas.Location = New System.Drawing.Point(3, 1)
        Me.grpRangoFechas.Name = "grpRangoFechas"
        Me.grpRangoFechas.Size = New System.Drawing.Size(225, 92)
        Me.grpRangoFechas.TabIndex = 0
        Me.grpRangoFechas.TabStop = False
        Me.grpRangoFechas.Text = "1. Rango de Fechas (BD)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Inicio:"
        '
        'fecha_ini_aud
        '
        Me.fecha_ini_aud.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_ini_aud.Location = New System.Drawing.Point(8, 33)
        Me.fecha_ini_aud.Name = "fecha_ini_aud"
        Me.fecha_ini_aud.Size = New System.Drawing.Size(98, 21)
        Me.fecha_ini_aud.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(115, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Término:"
        '
        'fecha_fin_aud
        '
        Me.fecha_fin_aud.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_fin_aud.Location = New System.Drawing.Point(115, 33)
        Me.fecha_fin_aud.Name = "fecha_fin_aud"
        Me.fecha_fin_aud.Size = New System.Drawing.Size(98, 21)
        Me.fecha_fin_aud.TabIndex = 3
        '
        'btn_buscar_aud
        '
        Me.btn_buscar_aud.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.btn_buscar_aud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_buscar_aud.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_buscar_aud.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar_aud.ForeColor = System.Drawing.Color.White
        Me.btn_buscar_aud.Image = Global.mantencion.My.Resources.Resources.icono_buscar1
        Me.btn_buscar_aud.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar_aud.Location = New System.Drawing.Point(8, 59)
        Me.btn_buscar_aud.Name = "btn_buscar_aud"
        Me.btn_buscar_aud.Size = New System.Drawing.Size(205, 26)
        Me.btn_buscar_aud.TabIndex = 4
        Me.btn_buscar_aud.Text = "  Consultar BD"
        Me.btn_buscar_aud.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btn_buscar_aud, "Consultar operaciones en la base de datos por rango de fechas")
        Me.btn_buscar_aud.UseVisualStyleBackColor = False
        '
        'grpFiltrosEnVivo
        '
        Me.grpFiltrosEnVivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFiltrosEnVivo.Controls.Add(Me.LabelSesion)
        Me.grpFiltrosEnVivo.Controls.Add(Me.cboFiltroSesion)
        Me.grpFiltrosEnVivo.Controls.Add(Me.LabelOperacion)
        Me.grpFiltrosEnVivo.Controls.Add(Me.cboFiltroOperacion)
        Me.grpFiltrosEnVivo.Controls.Add(Me.LabelPc)
        Me.grpFiltrosEnVivo.Controls.Add(Me.cboFiltroPc)
        Me.grpFiltrosEnVivo.Controls.Add(Me.LabelTabla)
        Me.grpFiltrosEnVivo.Controls.Add(Me.cboFiltroTabla)
        Me.grpFiltrosEnVivo.Controls.Add(Me.LabelBuscar)
        Me.grpFiltrosEnVivo.Controls.Add(Me.txtBusquedaRapida)
        Me.grpFiltrosEnVivo.Controls.Add(Me.btnLimpiarFiltros)
        Me.grpFiltrosEnVivo.Font = New System.Drawing.Font("Calibri", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFiltrosEnVivo.Location = New System.Drawing.Point(234, 1)
        Me.grpFiltrosEnVivo.Name = "grpFiltrosEnVivo"
        Me.grpFiltrosEnVivo.Size = New System.Drawing.Size(745, 92)
        Me.grpFiltrosEnVivo.TabIndex = 1
        Me.grpFiltrosEnVivo.TabStop = False
        Me.grpFiltrosEnVivo.Text = "2. Filtros Dinámicos en Vivo y Búsqueda"
        '
        'LabelSesion
        '
        Me.LabelSesion.AutoSize = True
        Me.LabelSesion.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSesion.Location = New System.Drawing.Point(8, 17)
        Me.LabelSesion.Name = "LabelSesion"
        Me.LabelSesion.Size = New System.Drawing.Size(89, 13)
        Me.LabelSesion.TabIndex = 0
        Me.LabelSesion.Text = "Sesión / Usuario:"
        '
        'cboFiltroSesion
        '
        Me.cboFiltroSesion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFiltroSesion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFiltroSesion.FormattingEnabled = True
        Me.cboFiltroSesion.Location = New System.Drawing.Point(8, 33)
        Me.cboFiltroSesion.Name = "cboFiltroSesion"
        Me.cboFiltroSesion.Size = New System.Drawing.Size(125, 21)
        Me.cboFiltroSesion.TabIndex = 1
        '
        'LabelOperacion
        '
        Me.LabelOperacion.AutoSize = True
        Me.LabelOperacion.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelOperacion.Location = New System.Drawing.Point(139, 17)
        Me.LabelOperacion.Name = "LabelOperacion"
        Me.LabelOperacion.Size = New System.Drawing.Size(59, 13)
        Me.LabelOperacion.TabIndex = 2
        Me.LabelOperacion.Text = "Operación:"
        '
        'cboFiltroOperacion
        '
        Me.cboFiltroOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFiltroOperacion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFiltroOperacion.FormattingEnabled = True
        Me.cboFiltroOperacion.Location = New System.Drawing.Point(139, 33)
        Me.cboFiltroOperacion.Name = "cboFiltroOperacion"
        Me.cboFiltroOperacion.Size = New System.Drawing.Size(120, 21)
        Me.cboFiltroOperacion.TabIndex = 3
        '
        'LabelPc
        '
        Me.LabelPc.AutoSize = True
        Me.LabelPc.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPc.Location = New System.Drawing.Point(265, 17)
        Me.LabelPc.Name = "LabelPc"
        Me.LabelPc.Size = New System.Drawing.Size(63, 13)
        Me.LabelPc.TabIndex = 4
        Me.LabelPc.Text = "Nombre PC:"
        '
        'cboFiltroPc
        '
        Me.cboFiltroPc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFiltroPc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFiltroPc.FormattingEnabled = True
        Me.cboFiltroPc.Location = New System.Drawing.Point(265, 33)
        Me.cboFiltroPc.Name = "cboFiltroPc"
        Me.cboFiltroPc.Size = New System.Drawing.Size(140, 21)
        Me.cboFiltroPc.TabIndex = 5
        '
        'LabelTabla
        '
        Me.LabelTabla.AutoSize = True
        Me.LabelTabla.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTabla.Location = New System.Drawing.Point(411, 17)
        Me.LabelTabla.Name = "LabelTabla"
        Me.LabelTabla.Size = New System.Drawing.Size(35, 13)
        Me.LabelTabla.TabIndex = 6
        Me.LabelTabla.Text = "Tabla:"
        '
        'cboFiltroTabla
        '
        Me.cboFiltroTabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFiltroTabla.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFiltroTabla.FormattingEnabled = True
        Me.cboFiltroTabla.Location = New System.Drawing.Point(411, 33)
        Me.cboFiltroTabla.Name = "cboFiltroTabla"
        Me.cboFiltroTabla.Size = New System.Drawing.Size(155, 21)
        Me.cboFiltroTabla.TabIndex = 7
        '
        'LabelBuscar
        '
        Me.LabelBuscar.AutoSize = True
        Me.LabelBuscar.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBuscar.Location = New System.Drawing.Point(8, 64)
        Me.LabelBuscar.Name = "LabelBuscar"
        Me.LabelBuscar.Size = New System.Drawing.Size(91, 13)
        Me.LabelBuscar.TabIndex = 8
        Me.LabelBuscar.Text = "Búsqueda Rápida:"
        '
        'txtBusquedaRapida
        '
        Me.txtBusquedaRapida.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusquedaRapida.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusquedaRapida.Location = New System.Drawing.Point(105, 60)
        Me.txtBusquedaRapida.Name = "txtBusquedaRapida"
        Me.txtBusquedaRapida.Size = New System.Drawing.Size(481, 23)
        Me.txtBusquedaRapida.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.txtBusquedaRapida, "Filtre en tiempo real por Clave Afectada, ID Operación o texto libre")
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.btnLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiarFiltros.Font = New System.Drawing.Font("Calibri", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltros.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(595, 58)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(140, 26)
        Me.btnLimpiarFiltros.TabIndex = 10
        Me.btnLimpiarFiltros.Text = "Limpiar Filtros"
        Me.ToolTip1.SetToolTip(Me.btnLimpiarFiltros, "Restablece todos los filtros para mostrar todos los datos cargados")
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = False
        '
        'grpAcciones
        '
        Me.grpAcciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAcciones.Controls.Add(Me.btn_exp_excel)
        Me.grpAcciones.Controls.Add(Me.btn_salir_aud)
        Me.grpAcciones.Font = New System.Drawing.Font("Calibri", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAcciones.Location = New System.Drawing.Point(985, 1)
        Me.grpAcciones.Name = "grpAcciones"
        Me.grpAcciones.Size = New System.Drawing.Size(172, 92)
        Me.grpAcciones.TabIndex = 2
        Me.grpAcciones.TabStop = False
        Me.grpAcciones.Text = "Acciones"
        '
        'btn_exp_excel
        '
        Me.btn_exp_excel.BackColor = System.Drawing.Color.FromArgb(16, 120, 80)
        Me.btn_exp_excel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_exp_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exp_excel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exp_excel.ForeColor = System.Drawing.Color.White
        Me.btn_exp_excel.Image = Global.mantencion.My.Resources.Resources.icono_excel1
        Me.btn_exp_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_exp_excel.Location = New System.Drawing.Point(10, 20)
        Me.btn_exp_excel.Name = "btn_exp_excel"
        Me.btn_exp_excel.Size = New System.Drawing.Size(152, 30)
        Me.btn_exp_excel.TabIndex = 0
        Me.btn_exp_excel.Text = "  Exportar Excel"
        Me.btn_exp_excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btn_exp_excel, "Exportar registros filtrados o seleccionados a Excel")
        Me.btn_exp_excel.UseVisualStyleBackColor = False
        '
        'btn_salir_aud
        '
        Me.btn_salir_aud.BackColor = System.Drawing.Color.FromArgb(185, 28, 28)
        Me.btn_salir_aud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_salir_aud.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir_aud.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir_aud.ForeColor = System.Drawing.Color.White
        Me.btn_salir_aud.Image = Global.mantencion.My.Resources.Resources.salir
        Me.btn_salir_aud.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salir_aud.Location = New System.Drawing.Point(10, 55)
        Me.btn_salir_aud.Name = "btn_salir_aud"
        Me.btn_salir_aud.Size = New System.Drawing.Size(152, 28)
        Me.btn_salir_aud.TabIndex = 1
        Me.btn_salir_aud.Text = "  Cerrar"
        Me.btn_salir_aud.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btn_salir_aud, "Cerrar ventana de auditoría")
        Me.btn_salir_aud.UseVisualStyleBackColor = False
        '
        'pnlKpis
        '
        Me.pnlKpis.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlKpis.BackColor = System.Drawing.Color.White
        Me.pnlKpis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlKpis.Controls.Add(Me.tblKpis)
        Me.pnlKpis.Location = New System.Drawing.Point(10, 104)
        Me.pnlKpis.Name = "pnlKpis"
        Me.pnlKpis.Size = New System.Drawing.Size(1160, 62)
        Me.pnlKpis.TabIndex = 1
        '
        'tblKpis
        '
        Me.tblKpis.ColumnCount = 6
        Me.tblKpis.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.0!))
        Me.tblKpis.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tblKpis.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.0!))
        Me.tblKpis.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tblKpis.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.0!))
        Me.tblKpis.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.0!))
        Me.tblKpis.Controls.Add(Me.pnlCard1, 0, 0)
        Me.tblKpis.Controls.Add(Me.pnlCard2, 1, 0)
        Me.tblKpis.Controls.Add(Me.pnlCard3, 2, 0)
        Me.tblKpis.Controls.Add(Me.pnlCard4, 3, 0)
        Me.tblKpis.Controls.Add(Me.pnlCard5, 4, 0)
        Me.tblKpis.Controls.Add(Me.pnlCard6, 5, 0)
        Me.tblKpis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblKpis.Location = New System.Drawing.Point(0, 0)
        Me.tblKpis.Name = "tblKpis"
        Me.tblKpis.RowCount = 1
        Me.tblKpis.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblKpis.Size = New System.Drawing.Size(1158, 60)
        Me.tblKpis.TabIndex = 0
        '
        'pnlCard1
        '
        Me.pnlCard1.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlCard1.Controls.Add(Me.lblTitKpi1)
        Me.pnlCard1.Controls.Add(Me.lblKpiTotalOps)
        Me.pnlCard1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard1.Location = New System.Drawing.Point(2, 2)
        Me.pnlCard1.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlCard1.Name = "pnlCard1"
        Me.pnlCard1.Size = New System.Drawing.Size(192, 56)
        Me.pnlCard1.TabIndex = 0
        '
        'lblTitKpi1
        '
        Me.lblTitKpi1.AutoSize = True
        Me.lblTitKpi1.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitKpi1.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblTitKpi1.Location = New System.Drawing.Point(6, 4)
        Me.lblTitKpi1.Name = "lblTitKpi1"
        Me.lblTitKpi1.Size = New System.Drawing.Size(107, 13)
        Me.lblTitKpi1.TabIndex = 0
        Me.lblTitKpi1.Text = "TOTAL OPERACIONES"
        '
        'lblKpiTotalOps
        '
        Me.lblKpiTotalOps.AutoSize = True
        Me.lblKpiTotalOps.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKpiTotalOps.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.lblKpiTotalOps.Location = New System.Drawing.Point(6, 23)
        Me.lblKpiTotalOps.Name = "lblKpiTotalOps"
        Me.lblKpiTotalOps.Size = New System.Drawing.Size(43, 19)
        Me.lblKpiTotalOps.TabIndex = 1
        Me.lblKpiTotalOps.Text = "0 ops"
        '
        'pnlCard2
        '
        Me.pnlCard2.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlCard2.Controls.Add(Me.lblTitKpi2)
        Me.pnlCard2.Controls.Add(Me.lblKpiInserciones)
        Me.pnlCard2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard2.Location = New System.Drawing.Point(198, 2)
        Me.pnlCard2.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlCard2.Name = "pnlCard2"
        Me.pnlCard2.Size = New System.Drawing.Size(181, 56)
        Me.pnlCard2.TabIndex = 1
        '
        'lblTitKpi2
        '
        Me.lblTitKpi2.AutoSize = True
        Me.lblTitKpi2.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitKpi2.ForeColor = System.Drawing.Color.FromArgb(16, 120, 80)
        Me.lblTitKpi2.Location = New System.Drawing.Point(6, 4)
        Me.lblTitKpi2.Name = "lblTitKpi2"
        Me.lblTitKpi2.Size = New System.Drawing.Size(76, 13)
        Me.lblTitKpi2.TabIndex = 0
        Me.lblTitKpi2.Text = "INSERCIONES"
        '
        'lblKpiInserciones
        '
        Me.lblKpiInserciones.AutoSize = True
        Me.lblKpiInserciones.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKpiInserciones.ForeColor = System.Drawing.Color.FromArgb(16, 120, 80)
        Me.lblKpiInserciones.Location = New System.Drawing.Point(6, 23)
        Me.lblKpiInserciones.Name = "lblKpiInserciones"
        Me.lblKpiInserciones.Size = New System.Drawing.Size(52, 19)
        Me.lblKpiInserciones.TabIndex = 1
        Me.lblKpiInserciones.Text = "0 (0%)"
        '
        'pnlCard3
        '
        Me.pnlCard3.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlCard3.Controls.Add(Me.lblTitKpi3)
        Me.pnlCard3.Controls.Add(Me.lblKpiActualizaciones)
        Me.pnlCard3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard3.Location = New System.Drawing.Point(383, 2)
        Me.pnlCard3.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlCard3.Name = "pnlCard3"
        Me.pnlCard3.Size = New System.Drawing.Size(192, 56)
        Me.pnlCard3.TabIndex = 2
        '
        'lblTitKpi3
        '
        Me.lblTitKpi3.AutoSize = True
        Me.lblTitKpi3.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitKpi3.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblTitKpi3.Location = New System.Drawing.Point(6, 4)
        Me.lblTitKpi3.Name = "lblTitKpi3"
        Me.lblTitKpi3.Size = New System.Drawing.Size(107, 13)
        Me.lblTitKpi3.TabIndex = 0
        Me.lblTitKpi3.Text = "ACTUALIZACIONES"
        '
        'lblKpiActualizaciones
        '
        Me.lblKpiActualizaciones.AutoSize = True
        Me.lblKpiActualizaciones.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKpiActualizaciones.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblKpiActualizaciones.Location = New System.Drawing.Point(6, 23)
        Me.lblKpiActualizaciones.Name = "lblKpiActualizaciones"
        Me.lblKpiActualizaciones.Size = New System.Drawing.Size(52, 19)
        Me.lblKpiActualizaciones.TabIndex = 1
        Me.lblKpiActualizaciones.Text = "0 (0%)"
        '
        'pnlCard4
        '
        Me.pnlCard4.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlCard4.Controls.Add(Me.lblTitKpi4)
        Me.pnlCard4.Controls.Add(Me.lblKpiEliminaciones)
        Me.pnlCard4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard4.Location = New System.Drawing.Point(579, 2)
        Me.pnlCard4.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlCard4.Name = "pnlCard4"
        Me.pnlCard4.Size = New System.Drawing.Size(181, 56)
        Me.pnlCard4.TabIndex = 3
        '
        'lblTitKpi4
        '
        Me.lblTitKpi4.AutoSize = True
        Me.lblTitKpi4.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitKpi4.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28)
        Me.lblTitKpi4.Location = New System.Drawing.Point(6, 4)
        Me.lblTitKpi4.Name = "lblTitKpi4"
        Me.lblTitKpi4.Size = New System.Drawing.Size(91, 13)
        Me.lblTitKpi4.TabIndex = 0
        Me.lblTitKpi4.Text = "ELIMINACIONES"
        '
        'lblKpiEliminaciones
        '
        Me.lblKpiEliminaciones.AutoSize = True
        Me.lblKpiEliminaciones.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKpiEliminaciones.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28)
        Me.lblKpiEliminaciones.Location = New System.Drawing.Point(6, 23)
        Me.lblKpiEliminaciones.Name = "lblKpiEliminaciones"
        Me.lblKpiEliminaciones.Size = New System.Drawing.Size(52, 19)
        Me.lblKpiEliminaciones.TabIndex = 1
        Me.lblKpiEliminaciones.Text = "0 (0%)"
        '
        'pnlCard5
        '
        Me.pnlCard5.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlCard5.Controls.Add(Me.lblTitKpi5)
        Me.pnlCard5.Controls.Add(Me.lblKpiTopUsuario)
        Me.pnlCard5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard5.Location = New System.Drawing.Point(764, 2)
        Me.pnlCard5.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlCard5.Name = "pnlCard5"
        Me.pnlCard5.Size = New System.Drawing.Size(192, 56)
        Me.pnlCard5.TabIndex = 4
        '
        'lblTitKpi5
        '
        Me.lblTitKpi5.AutoSize = True
        Me.lblTitKpi5.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitKpi5.ForeColor = System.Drawing.Color.FromArgb(1, 145, 179)
        Me.lblTitKpi5.Location = New System.Drawing.Point(6, 4)
        Me.lblTitKpi5.Name = "lblTitKpi5"
        Me.lblTitKpi5.Size = New System.Drawing.Size(117, 13)
        Me.lblTitKpi5.TabIndex = 0
        Me.lblTitKpi5.Text = "TOP USUARIO / SESION"
        '
        'lblKpiTopUsuario
        '
        Me.lblKpiTopUsuario.AutoSize = True
        Me.lblKpiTopUsuario.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKpiTopUsuario.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.lblKpiTopUsuario.Location = New System.Drawing.Point(6, 24)
        Me.lblKpiTopUsuario.Name = "lblKpiTopUsuario"
        Me.lblKpiTopUsuario.Size = New System.Drawing.Size(13, 18)
        Me.lblKpiTopUsuario.TabIndex = 1
        Me.lblKpiTopUsuario.Text = "-"
        '
        'pnlCard6
        '
        Me.pnlCard6.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlCard6.Controls.Add(Me.lblTitKpi6)
        Me.pnlCard6.Controls.Add(Me.lblKpiTopPc)
        Me.pnlCard6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard6.Location = New System.Drawing.Point(960, 2)
        Me.pnlCard6.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlCard6.Name = "pnlCard6"
        Me.pnlCard6.Size = New System.Drawing.Size(196, 56)
        Me.pnlCard6.TabIndex = 5
        '
        'lblTitKpi6
        '
        Me.lblTitKpi6.AutoSize = True
        Me.lblTitKpi6.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitKpi6.ForeColor = System.Drawing.Color.FromArgb(1, 145, 179)
        Me.lblTitKpi6.Location = New System.Drawing.Point(6, 4)
        Me.lblTitKpi6.Name = "lblTitKpi6"
        Me.lblTitKpi6.Size = New System.Drawing.Size(117, 13)
        Me.lblTitKpi6.TabIndex = 0
        Me.lblTitKpi6.Text = "TOP TERMINAL / PC"
        '
        'lblKpiTopPc
        '
        Me.lblKpiTopPc.AutoSize = True
        Me.lblKpiTopPc.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKpiTopPc.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.lblKpiTopPc.Location = New System.Drawing.Point(6, 24)
        Me.lblKpiTopPc.Name = "lblKpiTopPc"
        Me.lblKpiTopPc.Size = New System.Drawing.Size(13, 18)
        Me.lblKpiTopPc.TabIndex = 1
        Me.lblKpiTopPc.Text = "-"
        '
        'tabAuditoria
        '
        Me.tabAuditoria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabAuditoria.Controls.Add(Me.tabDetalle)
        Me.tabAuditoria.Controls.Add(Me.tabEstadisticas)
        Me.tabAuditoria.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabAuditoria.Location = New System.Drawing.Point(10, 170)
        Me.tabAuditoria.Name = "tabAuditoria"
        Me.tabAuditoria.SelectedIndex = 0
        Me.tabAuditoria.Size = New System.Drawing.Size(1160, 540)
        Me.tabAuditoria.TabIndex = 2
        '
        'tabDetalle
        '
        Me.tabDetalle.Controls.Add(Me.grillaAuditoria)
        Me.tabDetalle.Controls.Add(Me.pnlStatusAuditoria)
        Me.tabDetalle.Location = New System.Drawing.Point(4, 24)
        Me.tabDetalle.Name = "tabDetalle"
        Me.tabDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetalle.Size = New System.Drawing.Size(1152, 512)
        Me.tabDetalle.TabIndex = 0
        Me.tabDetalle.Text = "Detalle de Operaciones"
        Me.tabDetalle.UseVisualStyleBackColor = True
        '
        'grillaAuditoria
        '
        Me.grillaAuditoria.AllowUserToAddRows = False
        Me.grillaAuditoria.AllowUserToDeleteRows = False
        Me.grillaAuditoria.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaAuditoria.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grillaAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaAuditoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaAuditoria.EnableHeadersVisualStyles = False
        Me.grillaAuditoria.Location = New System.Drawing.Point(3, 3)
        Me.grillaAuditoria.Name = "grillaAuditoria"
        Me.grillaAuditoria.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaAuditoria.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grillaAuditoria.RowHeadersWidth = 24
        Me.grillaAuditoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grillaAuditoria.Size = New System.Drawing.Size(1146, 481)
        Me.grillaAuditoria.TabIndex = 0
        '
        'pnlStatusAuditoria
        '
        Me.pnlStatusAuditoria.BackColor = System.Drawing.Color.FromArgb(235, 240, 242)
        Me.pnlStatusAuditoria.Controls.Add(Me.lblEstadoRegistros)
        Me.pnlStatusAuditoria.Controls.Add(Me.lblEstadoSeleccion)
        Me.pnlStatusAuditoria.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlStatusAuditoria.Location = New System.Drawing.Point(3, 484)
        Me.pnlStatusAuditoria.Name = "pnlStatusAuditoria"
        Me.pnlStatusAuditoria.Size = New System.Drawing.Size(1146, 25)
        Me.pnlStatusAuditoria.TabIndex = 1
        '
        'lblEstadoRegistros
        '
        Me.lblEstadoRegistros.AutoSize = True
        Me.lblEstadoRegistros.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoRegistros.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.lblEstadoRegistros.Location = New System.Drawing.Point(8, 5)
        Me.lblEstadoRegistros.Name = "lblEstadoRegistros"
        Me.lblEstadoRegistros.Size = New System.Drawing.Size(176, 15)
        Me.lblEstadoRegistros.TabIndex = 0
        Me.lblEstadoRegistros.Text = "Mostrando 0 de 0 operaciones"
        '
        'lblEstadoSeleccion
        '
        Me.lblEstadoSeleccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEstadoSeleccion.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoSeleccion.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblEstadoSeleccion.Location = New System.Drawing.Point(740, 5)
        Me.lblEstadoSeleccion.Name = "lblEstadoSeleccion"
        Me.lblEstadoSeleccion.Size = New System.Drawing.Size(395, 15)
        Me.lblEstadoSeleccion.TabIndex = 1
        Me.lblEstadoSeleccion.Text = "0 filas seleccionadas"
        Me.lblEstadoSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabEstadisticas
        '
        Me.tabEstadisticas.Controls.Add(Me.tabSubEstadisticas)
        Me.tabEstadisticas.Controls.Add(Me.pnlHeaderStats)
        Me.tabEstadisticas.Location = New System.Drawing.Point(4, 24)
        Me.tabEstadisticas.Name = "tabEstadisticas"
        Me.tabEstadisticas.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEstadisticas.Size = New System.Drawing.Size(1152, 512)
        Me.tabEstadisticas.TabIndex = 1
        Me.tabEstadisticas.Text = "Métricas y Estadísticas"
        Me.tabEstadisticas.UseVisualStyleBackColor = True
        '
        'tabSubEstadisticas
        '
        Me.tabSubEstadisticas.Controls.Add(Me.tabSubSesion)
        Me.tabSubEstadisticas.Controls.Add(Me.tabSubOperacion)
        Me.tabSubEstadisticas.Controls.Add(Me.tabSubPc)
        Me.tabSubEstadisticas.Controls.Add(Me.tabSubTabla)
        Me.tabSubEstadisticas.Controls.Add(Me.tabSubFecha)
        Me.tabSubEstadisticas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabSubEstadisticas.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSubEstadisticas.Location = New System.Drawing.Point(3, 41)
        Me.tabSubEstadisticas.Name = "tabSubEstadisticas"
        Me.tabSubEstadisticas.SelectedIndex = 0
        Me.tabSubEstadisticas.Size = New System.Drawing.Size(1146, 468)
        Me.tabSubEstadisticas.TabIndex = 1
        '
        'tabSubSesion
        '
        Me.tabSubSesion.Controls.Add(Me.grillaStatSesion)
        Me.tabSubSesion.Location = New System.Drawing.Point(4, 22)
        Me.tabSubSesion.Name = "tabSubSesion"
        Me.tabSubSesion.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSubSesion.Size = New System.Drawing.Size(1138, 442)
        Me.tabSubSesion.TabIndex = 0
        Me.tabSubSesion.Text = "Por Sesión / Usuario"
        Me.tabSubSesion.UseVisualStyleBackColor = True
        '
        'grillaStatSesion
        '
        Me.grillaStatSesion.AllowUserToAddRows = False
        Me.grillaStatSesion.AllowUserToDeleteRows = False
        Me.grillaStatSesion.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaStatSesion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaStatSesion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaStatSesion.Location = New System.Drawing.Point(3, 3)
        Me.grillaStatSesion.MultiSelect = False
        Me.grillaStatSesion.Name = "grillaStatSesion"
        Me.grillaStatSesion.ReadOnly = True
        Me.grillaStatSesion.RowHeadersWidth = 24
        Me.grillaStatSesion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grillaStatSesion.Size = New System.Drawing.Size(1132, 436)
        Me.grillaStatSesion.TabIndex = 0
        '
        'tabSubOperacion
        '
        Me.tabSubOperacion.Controls.Add(Me.grillaStatOperacion)
        Me.tabSubOperacion.Location = New System.Drawing.Point(4, 22)
        Me.tabSubOperacion.Name = "tabSubOperacion"
        Me.tabSubOperacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSubOperacion.Size = New System.Drawing.Size(1138, 442)
        Me.tabSubOperacion.TabIndex = 1
        Me.tabSubOperacion.Text = "Por Tipo de Operación"
        Me.tabSubOperacion.UseVisualStyleBackColor = True
        '
        'grillaStatOperacion
        '
        Me.grillaStatOperacion.AllowUserToAddRows = False
        Me.grillaStatOperacion.AllowUserToDeleteRows = False
        Me.grillaStatOperacion.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaStatOperacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaStatOperacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaStatOperacion.Location = New System.Drawing.Point(3, 3)
        Me.grillaStatOperacion.MultiSelect = False
        Me.grillaStatOperacion.Name = "grillaStatOperacion"
        Me.grillaStatOperacion.ReadOnly = True
        Me.grillaStatOperacion.RowHeadersWidth = 24
        Me.grillaStatOperacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grillaStatOperacion.Size = New System.Drawing.Size(1132, 436)
        Me.grillaStatOperacion.TabIndex = 0
        '
        'tabSubPc
        '
        Me.tabSubPc.Controls.Add(Me.grillaStatPc)
        Me.tabSubPc.Location = New System.Drawing.Point(4, 22)
        Me.tabSubPc.Name = "tabSubPc"
        Me.tabSubPc.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSubPc.Size = New System.Drawing.Size(1138, 442)
        Me.tabSubPc.TabIndex = 2
        Me.tabSubPc.Text = "Por Nombre de PC"
        Me.tabSubPc.UseVisualStyleBackColor = True
        '
        'grillaStatPc
        '
        Me.grillaStatPc.AllowUserToAddRows = False
        Me.grillaStatPc.AllowUserToDeleteRows = False
        Me.grillaStatPc.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaStatPc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaStatPc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaStatPc.Location = New System.Drawing.Point(3, 3)
        Me.grillaStatPc.MultiSelect = False
        Me.grillaStatPc.Name = "grillaStatPc"
        Me.grillaStatPc.ReadOnly = True
        Me.grillaStatPc.RowHeadersWidth = 24
        Me.grillaStatPc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grillaStatPc.Size = New System.Drawing.Size(1132, 436)
        Me.grillaStatPc.TabIndex = 0
        '
        'tabSubTabla
        '
        Me.tabSubTabla.Controls.Add(Me.grillaStatTabla)
        Me.tabSubTabla.Location = New System.Drawing.Point(4, 22)
        Me.tabSubTabla.Name = "tabSubTabla"
        Me.tabSubTabla.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSubTabla.Size = New System.Drawing.Size(1138, 442)
        Me.tabSubTabla.TabIndex = 3
        Me.tabSubTabla.Text = "Por Tabla Afectada"
        Me.tabSubTabla.UseVisualStyleBackColor = True
        '
        'grillaStatTabla
        '
        Me.grillaStatTabla.AllowUserToAddRows = False
        Me.grillaStatTabla.AllowUserToDeleteRows = False
        Me.grillaStatTabla.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaStatTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaStatTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaStatTabla.Location = New System.Drawing.Point(3, 3)
        Me.grillaStatTabla.MultiSelect = False
        Me.grillaStatTabla.Name = "grillaStatTabla"
        Me.grillaStatTabla.ReadOnly = True
        Me.grillaStatTabla.RowHeadersWidth = 24
        Me.grillaStatTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grillaStatTabla.Size = New System.Drawing.Size(1132, 436)
        Me.grillaStatTabla.TabIndex = 0
        '
        'tabSubFecha
        '
        Me.tabSubFecha.Controls.Add(Me.grillaStatFecha)
        Me.tabSubFecha.Location = New System.Drawing.Point(4, 22)
        Me.tabSubFecha.Name = "tabSubFecha"
        Me.tabSubFecha.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSubFecha.Size = New System.Drawing.Size(1138, 442)
        Me.tabSubFecha.TabIndex = 4
        Me.tabSubFecha.Text = "Por Fecha"
        Me.tabSubFecha.UseVisualStyleBackColor = True
        '
        'grillaStatFecha
        '
        Me.grillaStatFecha.AllowUserToAddRows = False
        Me.grillaStatFecha.AllowUserToDeleteRows = False
        Me.grillaStatFecha.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaStatFecha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaStatFecha.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaStatFecha.Location = New System.Drawing.Point(3, 3)
        Me.grillaStatFecha.MultiSelect = False
        Me.grillaStatFecha.Name = "grillaStatFecha"
        Me.grillaStatFecha.ReadOnly = True
        Me.grillaStatFecha.RowHeadersWidth = 24
        Me.grillaStatFecha.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grillaStatFecha.Size = New System.Drawing.Size(1132, 436)
        Me.grillaStatFecha.TabIndex = 0
        '
        'pnlHeaderStats
        '
        Me.pnlHeaderStats.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlHeaderStats.Controls.Add(Me.lblTitEstadisticas)
        Me.pnlHeaderStats.Controls.Add(Me.lblTipStats)
        Me.pnlHeaderStats.Controls.Add(Me.btnExpEstadisticas)
        Me.pnlHeaderStats.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderStats.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeaderStats.Name = "pnlHeaderStats"
        Me.pnlHeaderStats.Size = New System.Drawing.Size(1146, 38)
        Me.pnlHeaderStats.TabIndex = 0
        '
        'lblTitEstadisticas
        '
        Me.lblTitEstadisticas.AutoSize = True
        Me.lblTitEstadisticas.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitEstadisticas.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblTitEstadisticas.Location = New System.Drawing.Point(8, 10)
        Me.lblTitEstadisticas.Name = "lblTitEstadisticas"
        Me.lblTitEstadisticas.Size = New System.Drawing.Size(300, 17)
        Me.lblTitEstadisticas.TabIndex = 0
        Me.lblTitEstadisticas.Text = "Tablero de Métricas y Estadísticas de Auditoría"
        '
        'lblTipStats
        '
        Me.lblTipStats.AutoSize = True
        Me.lblTipStats.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipStats.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblTipStats.Location = New System.Drawing.Point(320, 12)
        Me.lblTipStats.Name = "lblTipStats"
        Me.lblTipStats.Size = New System.Drawing.Size(370, 13)
        Me.lblTipStats.TabIndex = 1
        Me.lblTipStats.Text = "Tip: Haga doble clic en cualquier fila para filtrar automáticamente la grilla principal."
        '
        'btnExpEstadisticas
        '
        Me.btnExpEstadisticas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExpEstadisticas.BackColor = System.Drawing.Color.FromArgb(16, 120, 80)
        Me.btnExpEstadisticas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExpEstadisticas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExpEstadisticas.Font = New System.Drawing.Font("Calibri", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpEstadisticas.ForeColor = System.Drawing.Color.White
        Me.btnExpEstadisticas.Image = Global.mantencion.My.Resources.Resources.icono_excel1
        Me.btnExpEstadisticas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExpEstadisticas.Location = New System.Drawing.Point(920, 5)
        Me.btnExpEstadisticas.Name = "btnExpEstadisticas"
        Me.btnExpEstadisticas.Size = New System.Drawing.Size(220, 28)
        Me.btnExpEstadisticas.TabIndex = 2
        Me.btnExpEstadisticas.Text = "  Exportar Estadísticas a Excel"
        Me.btnExpEstadisticas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnExpEstadisticas, "Exporta un informe exclusivo en Excel con todas las métricas y resúmenes estadísticos")
        Me.btnExpEstadisticas.UseVisualStyleBackColor = False
        '
        'FrmAdminAuditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(1180, 720)
        Me.Controls.Add(Me.tabAuditoria)
        Me.Controls.Add(Me.pnlKpis)
        Me.Controls.Add(Me.PanelSuperior)
        Me.MinimumSize = New System.Drawing.Size(980, 620)
        Me.Name = "FrmAdminAuditoria"
        Me.ShowIcon = False
        Me.Text = "Auditoría de Operaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.PanelSuperior.ResumeLayout(False)
        Me.grpRangoFechas.ResumeLayout(False)
        Me.grpRangoFechas.PerformLayout()
        Me.grpFiltrosEnVivo.ResumeLayout(False)
        Me.grpFiltrosEnVivo.PerformLayout()
        Me.grpAcciones.ResumeLayout(False)
        Me.pnlKpis.ResumeLayout(False)
        Me.tblKpis.ResumeLayout(False)
        Me.pnlCard1.ResumeLayout(False)
        Me.pnlCard1.PerformLayout()
        Me.pnlCard2.ResumeLayout(False)
        Me.pnlCard2.PerformLayout()
        Me.pnlCard3.ResumeLayout(False)
        Me.pnlCard3.PerformLayout()
        Me.pnlCard4.ResumeLayout(False)
        Me.pnlCard4.PerformLayout()
        Me.pnlCard5.ResumeLayout(False)
        Me.pnlCard5.PerformLayout()
        Me.pnlCard6.ResumeLayout(False)
        Me.pnlCard6.PerformLayout()
        Me.tabAuditoria.ResumeLayout(False)
        Me.tabDetalle.ResumeLayout(False)
        CType(Me.grillaAuditoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStatusAuditoria.ResumeLayout(False)
        Me.pnlStatusAuditoria.PerformLayout()
        Me.tabEstadisticas.ResumeLayout(False)
        Me.tabSubEstadisticas.ResumeLayout(False)
        Me.tabSubSesion.ResumeLayout(False)
        CType(Me.grillaStatSesion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSubOperacion.ResumeLayout(False)
        CType(Me.grillaStatOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSubPc.ResumeLayout(False)
        CType(Me.grillaStatPc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSubTabla.ResumeLayout(False)
        CType(Me.grillaStatTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSubFecha.ResumeLayout(False)
        CType(Me.grillaStatFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeaderStats.ResumeLayout(False)
        Me.pnlHeaderStats.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSuperior As System.Windows.Forms.Panel
    Friend WithEvents grpRangoFechas As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fecha_ini_aud As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents fecha_fin_aud As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_buscar_aud As System.Windows.Forms.Button

    Friend WithEvents grpFiltrosEnVivo As System.Windows.Forms.GroupBox
    Friend WithEvents LabelSesion As System.Windows.Forms.Label
    Friend WithEvents cboFiltroSesion As System.Windows.Forms.ComboBox
    Friend WithEvents LabelOperacion As System.Windows.Forms.Label
    Friend WithEvents cboFiltroOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents LabelPc As System.Windows.Forms.Label
    Friend WithEvents cboFiltroPc As System.Windows.Forms.ComboBox
    Friend WithEvents LabelTabla As System.Windows.Forms.Label
    Friend WithEvents cboFiltroTabla As System.Windows.Forms.ComboBox
    Friend WithEvents LabelBuscar As System.Windows.Forms.Label
    Friend WithEvents txtBusquedaRapida As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiarFiltros As System.Windows.Forms.Button

    Friend WithEvents grpAcciones As System.Windows.Forms.GroupBox
    Friend WithEvents btn_exp_excel As System.Windows.Forms.Button
    Friend WithEvents btn_salir_aud As System.Windows.Forms.Button

    Friend WithEvents pnlKpis As System.Windows.Forms.Panel
    Friend WithEvents tblKpis As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlCard1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitKpi1 As System.Windows.Forms.Label
    Friend WithEvents lblKpiTotalOps As System.Windows.Forms.Label
    Friend WithEvents pnlCard2 As System.Windows.Forms.Panel
    Friend WithEvents lblTitKpi2 As System.Windows.Forms.Label
    Friend WithEvents lblKpiInserciones As System.Windows.Forms.Label
    Friend WithEvents pnlCard3 As System.Windows.Forms.Panel
    Friend WithEvents lblTitKpi3 As System.Windows.Forms.Label
    Friend WithEvents lblKpiActualizaciones As System.Windows.Forms.Label
    Friend WithEvents pnlCard4 As System.Windows.Forms.Panel
    Friend WithEvents lblTitKpi4 As System.Windows.Forms.Label
    Friend WithEvents lblKpiEliminaciones As System.Windows.Forms.Label
    Friend WithEvents pnlCard5 As System.Windows.Forms.Panel
    Friend WithEvents lblTitKpi5 As System.Windows.Forms.Label
    Friend WithEvents lblKpiTopUsuario As System.Windows.Forms.Label
    Friend WithEvents pnlCard6 As System.Windows.Forms.Panel
    Friend WithEvents lblTitKpi6 As System.Windows.Forms.Label
    Friend WithEvents lblKpiTopPc As System.Windows.Forms.Label

    Friend WithEvents tabAuditoria As System.Windows.Forms.TabControl
    Friend WithEvents tabDetalle As System.Windows.Forms.TabPage
    Friend WithEvents grillaAuditoria As System.Windows.Forms.DataGridView
    Friend WithEvents pnlStatusAuditoria As System.Windows.Forms.Panel
    Friend WithEvents lblEstadoRegistros As System.Windows.Forms.Label
    Friend WithEvents lblEstadoSeleccion As System.Windows.Forms.Label

    Friend WithEvents tabEstadisticas As System.Windows.Forms.TabPage
    Friend WithEvents pnlHeaderStats As System.Windows.Forms.Panel
    Friend WithEvents lblTitEstadisticas As System.Windows.Forms.Label
    Friend WithEvents lblTipStats As System.Windows.Forms.Label
    Friend WithEvents btnExpEstadisticas As System.Windows.Forms.Button
    Friend WithEvents tabSubEstadisticas As System.Windows.Forms.TabControl
    Friend WithEvents tabSubSesion As System.Windows.Forms.TabPage
    Friend WithEvents grillaStatSesion As System.Windows.Forms.DataGridView
    Friend WithEvents tabSubOperacion As System.Windows.Forms.TabPage
    Friend WithEvents grillaStatOperacion As System.Windows.Forms.DataGridView
    Friend WithEvents tabSubPc As System.Windows.Forms.TabPage
    Friend WithEvents grillaStatPc As System.Windows.Forms.DataGridView
    Friend WithEvents tabSubTabla As System.Windows.Forms.TabPage
    Friend WithEvents grillaStatTabla As System.Windows.Forms.DataGridView
    Friend WithEvents tabSubFecha As System.Windows.Forms.TabPage
    Friend WithEvents grillaStatFecha As System.Windows.Forms.DataGridView

    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
