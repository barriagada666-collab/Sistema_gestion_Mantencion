<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCartaGantt
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

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim styleAltGantt As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim styleHeaderGantt As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim styleRowHdrGantt As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim styleHeaderGrafico As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

        Me.pnlCardHeaderGantt = New System.Windows.Forms.Panel()
        Me.lblTituloGantt = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDesdeGantt = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblHastaGantt = New System.Windows.Forms.Label()
        Me.lblResumenGantt = New System.Windows.Forms.Label()
        Me.btnFiltrarMarcados = New System.Windows.Forms.Button()
        Me.btnExpPdf = New System.Windows.Forms.Button()
        Me.btnExpExcel = New System.Windows.Forms.Button()
        Me.btnSalirGantt = New System.Windows.Forms.Button()

        Me.pnlCardFiltrosGantt = New System.Windows.Forms.Panel()
        Me.lblBuscarNumMp = New System.Windows.Forms.Label()
        Me.txtBuscarNumMp = New System.Windows.Forms.TextBox()
        Me.lblBuscarIdCiclo = New System.Windows.Forms.Label()
        Me.txtBuscarIdCiclo = New System.Windows.Forms.TextBox()
        Me.lblBuscarGantt = New System.Windows.Forms.Label()
        Me.txtBuscarGantt = New System.Windows.Forms.TextBox()
        Me.lblFiltroEstado = New System.Windows.Forms.Label()
        Me.cmbFiltroEstado = New System.Windows.Forms.ComboBox()
        Me.lblZoomGantt = New System.Windows.Forms.Label()
        Me.cmbZoomGantt = New System.Windows.Forms.ComboBox()
        Me.btnBuscarGantt = New System.Windows.Forms.Button()
        Me.btnLimpiarGantt = New System.Windows.Forms.Button()
        Me.btnToggleDetalle = New System.Windows.Forms.Button()
        Me.pnlLeyendaGantt = New System.Windows.Forms.Panel()
        Me.lblKpiLeyPendiente = New System.Windows.Forms.Label()
        Me.lblKpiLeyTerminado = New System.Windows.Forms.Label()
        Me.lblKpiLeyVencido = New System.Windows.Forms.Label()

        Me.pnlBodyGantt = New System.Windows.Forms.Panel()
        Me.pnlGanttTopArea = New System.Windows.Forms.Panel()
        Me.pnlGanttLeft = New System.Windows.Forms.Panel()
        Me.pnlGanttRight = New System.Windows.Forms.Panel()
        Me.splitterMain = New System.Windows.Forms.Splitter()
        Me.splitterDetalle = New System.Windows.Forms.Splitter()

        Me.grillaInfoGantt = New System.Windows.Forms.DataGridView()
        Me.id_ciclo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.obs_ciclo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_inicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_termino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.duracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIdMant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSeccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipoMp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIdNodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grillaGraficoGantt = New System.Windows.Forms.DataGridView()

        Me.pnlCardDetalleGantt = New System.Windows.Forms.Panel()
        Me.pnlDetalleMeta = New System.Windows.Forms.Panel()
        Me.lblDetalleCicloTitulo = New System.Windows.Forms.Label()
        Me.lblDetalleObsCompleta = New System.Windows.Forms.Label()
        Me.dgvTareasCicloDetalle = New System.Windows.Forms.DataGridView()

        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)

        Me.pnlCardHeaderGantt.SuspendLayout()
        Me.pnlCardFiltrosGantt.SuspendLayout()
        Me.pnlLeyendaGantt.SuspendLayout()
        Me.pnlBodyGantt.SuspendLayout()
        Me.pnlGanttTopArea.SuspendLayout()
        Me.pnlGanttLeft.SuspendLayout()
        Me.pnlGanttRight.SuspendLayout()
        Me.pnlCardDetalleGantt.SuspendLayout()
        Me.pnlDetalleMeta.SuspendLayout()
        CType(Me.grillaInfoGantt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grillaGraficoGantt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTareasCicloDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        '
        'pnlCardHeaderGantt
        '
        Me.pnlCardHeaderGantt.BackColor = System.Drawing.Color.White
        Me.pnlCardHeaderGantt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCardHeaderGantt.Controls.Add(Me.btnSalirGantt)
        Me.pnlCardHeaderGantt.Controls.Add(Me.btnExpExcel)
        Me.pnlCardHeaderGantt.Controls.Add(Me.btnExpPdf)
        Me.pnlCardHeaderGantt.Controls.Add(Me.btnFiltrarMarcados)
        Me.pnlCardHeaderGantt.Controls.Add(Me.lblResumenGantt)
        Me.pnlCardHeaderGantt.Controls.Add(Me.lblHastaGantt)
        Me.pnlCardHeaderGantt.Controls.Add(Me.Label3)
        Me.pnlCardHeaderGantt.Controls.Add(Me.lblDesdeGantt)
        Me.pnlCardHeaderGantt.Controls.Add(Me.Label2)
        Me.pnlCardHeaderGantt.Controls.Add(Me.lblTituloGantt)
        Me.pnlCardHeaderGantt.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCardHeaderGantt.Location = New System.Drawing.Point(0, 0)
        Me.pnlCardHeaderGantt.Name = "pnlCardHeaderGantt"
        Me.pnlCardHeaderGantt.Size = New System.Drawing.Size(1280, 58)
        Me.pnlCardHeaderGantt.TabIndex = 0

        Me.lblTituloGantt.AutoSize = True
        Me.lblTituloGantt.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloGantt.ForeColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.lblTituloGantt.Location = New System.Drawing.Point(12, 6)
        Me.lblTituloGantt.Name = "lblTituloGantt"
        Me.lblTituloGantt.Size = New System.Drawing.Size(220, 25)
        Me.lblTituloGantt.TabIndex = 0
        Me.lblTituloGantt.Text = "Carta Gantt de Mantención"

        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label2.Location = New System.Drawing.Point(13, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Desde:"

        Me.lblDesdeGantt.AutoSize = True
        Me.lblDesdeGantt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDesdeGantt.Location = New System.Drawing.Point(60, 33)
        Me.lblDesdeGantt.Name = "lblDesdeGantt"
        Me.lblDesdeGantt.Size = New System.Drawing.Size(76, 15)
        Me.lblDesdeGantt.TabIndex = 2
        Me.lblDesdeGantt.Text = "-"

        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label3.Location = New System.Drawing.Point(152, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Hasta:"

        Me.lblHastaGantt.AutoSize = True
        Me.lblHastaGantt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblHastaGantt.Location = New System.Drawing.Point(198, 33)
        Me.lblHastaGantt.Name = "lblHastaGantt"
        Me.lblHastaGantt.Size = New System.Drawing.Size(76, 15)
        Me.lblHastaGantt.TabIndex = 4
        Me.lblHastaGantt.Text = "-"

        Me.lblResumenGantt.AutoSize = True
        Me.lblResumenGantt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblResumenGantt.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblResumenGantt.Location = New System.Drawing.Point(296, 33)
        Me.lblResumenGantt.Name = "lblResumenGantt"
        Me.lblResumenGantt.Size = New System.Drawing.Size(180, 15)
        Me.lblResumenGantt.TabIndex = 5
        Me.lblResumenGantt.Text = "0 ciclos cargados"

        Me.btnFiltrarMarcados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltrarMarcados.Image = Global.mantencion.My.Resources.Resources.checklist
        Me.btnFiltrarMarcados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFiltrarMarcados.Location = New System.Drawing.Point(786, 13)
        Me.btnFiltrarMarcados.Name = "btnFiltrarMarcados"
        Me.btnFiltrarMarcados.Size = New System.Drawing.Size(126, 30)
        Me.btnFiltrarMarcados.TabIndex = 5
        Me.btnFiltrarMarcados.Text = "Solo Marcados"
        Me.btnFiltrarMarcados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnFiltrarMarcados, "Mostrar en la Carta Gantt únicamente los ciclos marcados con casilla en 'Sel.'")
        Me.btnFiltrarMarcados.UseVisualStyleBackColor = True

        Me.btnExpPdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExpPdf.Image = Global.mantencion.My.Resources.Resources.icono_pdf
        Me.btnExpPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExpPdf.Location = New System.Drawing.Point(918, 13)
        Me.btnExpPdf.Name = "btnExpPdf"
        Me.btnExpPdf.Size = New System.Drawing.Size(116, 30)
        Me.btnExpPdf.TabIndex = 6
        Me.btnExpPdf.Text = "Exportar PDF"
        Me.btnExpPdf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnExpPdf, "Exportar Carta Gantt a PDF Horizontal")
        Me.btnExpPdf.UseVisualStyleBackColor = True

        Me.btnExpExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExpExcel.Image = Global.mantencion.My.Resources.Resources.icono_excel1
        Me.btnExpExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExpExcel.Location = New System.Drawing.Point(1040, 13)
        Me.btnExpExcel.Name = "btnExpExcel"
        Me.btnExpExcel.Size = New System.Drawing.Size(126, 30)
        Me.btnExpExcel.TabIndex = 7
        Me.btnExpExcel.Text = "Exportar Excel"
        Me.btnExpExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnExpExcel, "Exportar Carta Gantt a Excel")
        Me.btnExpExcel.UseVisualStyleBackColor = True

        Me.btnSalirGantt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalirGantt.Image = Global.mantencion.My.Resources.Resources.salir
        Me.btnSalirGantt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalirGantt.Location = New System.Drawing.Point(1172, 13)
        Me.btnSalirGantt.Name = "btnSalirGantt"
        Me.btnSalirGantt.Size = New System.Drawing.Size(92, 30)
        Me.btnSalirGantt.TabIndex = 8
        Me.btnSalirGantt.Text = "Volver"
        Me.btnSalirGantt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip2.SetToolTip(Me.btnSalirGantt, "Cerrar Carta Gantt")
        Me.btnSalirGantt.UseVisualStyleBackColor = True

        '
        'pnlCardFiltrosGantt
        '
        Me.pnlCardFiltrosGantt.BackColor = System.Drawing.Color.White
        Me.pnlCardFiltrosGantt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCardFiltrosGantt.Controls.Add(Me.pnlLeyendaGantt)
        Me.pnlCardFiltrosGantt.Controls.Add(Me.btnToggleDetalle)
        Me.pnlCardFiltrosGantt.Controls.Add(Me.btnLimpiarGantt)
        Me.pnlCardFiltrosGantt.Controls.Add(Me.btnBuscarGantt)
        Me.pnlCardFiltrosGantt.Controls.Add(Me.cmbZoomGantt)
        Me.pnlCardFiltrosGantt.Controls.Add(Me.lblZoomGantt)
        Me.pnlCardFiltrosGantt.Controls.Add(Me.cmbFiltroEstado)
        Me.pnlCardFiltrosGantt.Controls.Add(Me.lblFiltroEstado)
        Me.pnlCardFiltrosGantt.Controls.Add(Me.txtBuscarGantt)
        Me.pnlCardFiltrosGantt.Controls.Add(Me.lblBuscarGantt)
        Me.pnlCardFiltrosGantt.Controls.Add(Me.txtBuscarIdCiclo)
        Me.pnlCardFiltrosGantt.Controls.Add(Me.lblBuscarIdCiclo)
        Me.pnlCardFiltrosGantt.Controls.Add(Me.txtBuscarNumMp)
        Me.pnlCardFiltrosGantt.Controls.Add(Me.lblBuscarNumMp)
        Me.pnlCardFiltrosGantt.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCardFiltrosGantt.Location = New System.Drawing.Point(0, 58)
        Me.pnlCardFiltrosGantt.Name = "pnlCardFiltrosGantt"
        Me.pnlCardFiltrosGantt.Size = New System.Drawing.Size(1280, 50)
        Me.pnlCardFiltrosGantt.TabIndex = 1

        Me.lblBuscarNumMp.AutoSize = True
        Me.lblBuscarNumMp.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Bold)
        Me.lblBuscarNumMp.Location = New System.Drawing.Point(10, 16)
        Me.lblBuscarNumMp.Name = "lblBuscarNumMp"
        Me.lblBuscarNumMp.Size = New System.Drawing.Size(45, 15)
        Me.lblBuscarNumMp.TabIndex = 0
        Me.lblBuscarNumMp.Text = "N° MP:"

        Me.txtBuscarNumMp.Location = New System.Drawing.Point(58, 13)
        Me.txtBuscarNumMp.MaxLength = 10
        Me.txtBuscarNumMp.Name = "txtBuscarNumMp"
        Me.txtBuscarNumMp.PlaceholderText = "Ej: 1351"
        Me.txtBuscarNumMp.Size = New System.Drawing.Size(66, 23)
        Me.txtBuscarNumMp.TabIndex = 1

        Me.lblBuscarIdCiclo.AutoSize = True
        Me.lblBuscarIdCiclo.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Bold)
        Me.lblBuscarIdCiclo.Location = New System.Drawing.Point(132, 16)
        Me.lblBuscarIdCiclo.Name = "lblBuscarIdCiclo"
        Me.lblBuscarIdCiclo.Size = New System.Drawing.Size(55, 15)
        Me.lblBuscarIdCiclo.TabIndex = 2
        Me.lblBuscarIdCiclo.Text = "ID Ciclo:"

        Me.txtBuscarIdCiclo.Location = New System.Drawing.Point(190, 13)
        Me.txtBuscarIdCiclo.MaxLength = 10
        Me.txtBuscarIdCiclo.Name = "txtBuscarIdCiclo"
        Me.txtBuscarIdCiclo.PlaceholderText = "Ej: 9"
        Me.txtBuscarIdCiclo.Size = New System.Drawing.Size(60, 23)
        Me.txtBuscarIdCiclo.TabIndex = 3

        Me.lblBuscarGantt.AutoSize = True
        Me.lblBuscarGantt.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Bold)
        Me.lblBuscarGantt.Location = New System.Drawing.Point(258, 16)
        Me.lblBuscarGantt.Name = "lblBuscarGantt"
        Me.lblBuscarGantt.Size = New System.Drawing.Size(48, 15)
        Me.lblBuscarGantt.TabIndex = 4
        Me.lblBuscarGantt.Text = "Buscar:"

        Me.txtBuscarGantt.Location = New System.Drawing.Point(310, 13)
        Me.txtBuscarGantt.MaxLength = 80
        Me.txtBuscarGantt.Name = "txtBuscarGantt"
        Me.txtBuscarGantt.PlaceholderText = "Máquina, sección o obs..."
        Me.txtBuscarGantt.Size = New System.Drawing.Size(148, 23)
        Me.txtBuscarGantt.TabIndex = 5

        Me.lblFiltroEstado.AutoSize = True
        Me.lblFiltroEstado.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Bold)
        Me.lblFiltroEstado.Location = New System.Drawing.Point(466, 16)
        Me.lblFiltroEstado.Name = "lblFiltroEstado"
        Me.lblFiltroEstado.Size = New System.Drawing.Size(48, 15)
        Me.lblFiltroEstado.TabIndex = 6
        Me.lblFiltroEstado.Text = "Estado:"

        Me.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFiltroEstado.FormattingEnabled = True
        Me.cmbFiltroEstado.Location = New System.Drawing.Point(516, 13)
        Me.cmbFiltroEstado.Name = "cmbFiltroEstado"
        Me.cmbFiltroEstado.Size = New System.Drawing.Size(96, 23)
        Me.cmbFiltroEstado.TabIndex = 7

        Me.lblZoomGantt.AutoSize = True
        Me.lblZoomGantt.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Bold)
        Me.lblZoomGantt.Location = New System.Drawing.Point(620, 16)
        Me.lblZoomGantt.Name = "lblZoomGantt"
        Me.lblZoomGantt.Size = New System.Drawing.Size(42, 15)
        Me.lblZoomGantt.TabIndex = 8
        Me.lblZoomGantt.Text = "Escala:"

        Me.cmbZoomGantt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZoomGantt.FormattingEnabled = True
        Me.cmbZoomGantt.Location = New System.Drawing.Point(665, 13)
        Me.cmbZoomGantt.Name = "cmbZoomGantt"
        Me.cmbZoomGantt.Size = New System.Drawing.Size(94, 23)
        Me.cmbZoomGantt.TabIndex = 9

        Me.btnBuscarGantt.Image = Global.mantencion.My.Resources.Resources._16__Find_
        Me.btnBuscarGantt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarGantt.Location = New System.Drawing.Point(766, 10)
        Me.btnBuscarGantt.Name = "btnBuscarGantt"
        Me.btnBuscarGantt.Size = New System.Drawing.Size(86, 30)
        Me.btnBuscarGantt.TabIndex = 10
        Me.btnBuscarGantt.Text = "Buscar"
        Me.btnBuscarGantt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnBuscarGantt, "Buscar y consultar en BD por N° Mantención o ID Ciclo")
        Me.btnBuscarGantt.UseVisualStyleBackColor = True

        Me.btnLimpiarGantt.Image = Global.mantencion.My.Resources.Resources._16__Clear_
        Me.btnLimpiarGantt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarGantt.Location = New System.Drawing.Point(858, 10)
        Me.btnLimpiarGantt.Name = "btnLimpiarGantt"
        Me.btnLimpiarGantt.Size = New System.Drawing.Size(88, 30)
        Me.btnLimpiarGantt.TabIndex = 11
        Me.btnLimpiarGantt.Text = "Limpiar"
        Me.btnLimpiarGantt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnLimpiarGantt, "Restablecer filtros y mostrar todos los ciclos")
        Me.btnLimpiarGantt.UseVisualStyleBackColor = True

        Me.btnToggleDetalle.Image = Global.mantencion.My.Resources.Resources.notas
        Me.btnToggleDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnToggleDetalle.Location = New System.Drawing.Point(952, 10)
        Me.btnToggleDetalle.Name = "btnToggleDetalle"
        Me.btnToggleDetalle.Size = New System.Drawing.Size(128, 30)
        Me.btnToggleDetalle.TabIndex = 12
        Me.btnToggleDetalle.Text = "Ocultar Detalle"
        Me.btnToggleDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnToggleDetalle, "Mostrar u ocultar el panel inferior de tareas del ciclo")
        Me.btnToggleDetalle.UseVisualStyleBackColor = True

        Me.pnlLeyendaGantt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlLeyendaGantt.Controls.Add(Me.lblKpiLeyVencido)
        Me.pnlLeyendaGantt.Controls.Add(Me.lblKpiLeyTerminado)
        Me.pnlLeyendaGantt.Controls.Add(Me.lblKpiLeyPendiente)
        Me.pnlLeyendaGantt.Location = New System.Drawing.Point(1082, 13)
        Me.pnlLeyendaGantt.Name = "pnlLeyendaGantt"
        Me.pnlLeyendaGantt.Size = New System.Drawing.Size(188, 24)
        Me.pnlLeyendaGantt.TabIndex = 13

        Me.lblKpiLeyPendiente.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblKpiLeyPendiente.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Bold)
        Me.lblKpiLeyPendiente.ForeColor = System.Drawing.Color.White
        Me.lblKpiLeyPendiente.Location = New System.Drawing.Point(2, 2)
        Me.lblKpiLeyPendiente.Name = "lblKpiLeyPendiente"
        Me.lblKpiLeyPendiente.Size = New System.Drawing.Size(58, 20)
        Me.lblKpiLeyPendiente.TabIndex = 0
        Me.lblKpiLeyPendiente.Text = "Pend."
        Me.lblKpiLeyPendiente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        Me.lblKpiLeyTerminado.BackColor = System.Drawing.Color.FromArgb(21, 128, 61)
        Me.lblKpiLeyTerminado.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Bold)
        Me.lblKpiLeyTerminado.ForeColor = System.Drawing.Color.White
        Me.lblKpiLeyTerminado.Location = New System.Drawing.Point(64, 2)
        Me.lblKpiLeyTerminado.Name = "lblKpiLeyTerminado"
        Me.lblKpiLeyTerminado.Size = New System.Drawing.Size(58, 20)
        Me.lblKpiLeyTerminado.TabIndex = 1
        Me.lblKpiLeyTerminado.Text = "Term."
        Me.lblKpiLeyTerminado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        Me.lblKpiLeyVencido.BackColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.lblKpiLeyVencido.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Bold)
        Me.lblKpiLeyVencido.ForeColor = System.Drawing.Color.White
        Me.lblKpiLeyVencido.Location = New System.Drawing.Point(126, 2)
        Me.lblKpiLeyVencido.Name = "lblKpiLeyVencido"
        Me.lblKpiLeyVencido.Size = New System.Drawing.Size(58, 20)
        Me.lblKpiLeyVencido.TabIndex = 2
        Me.lblKpiLeyVencido.Text = "Venc."
        Me.lblKpiLeyVencido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        '
        'pnlBodyGantt (Fill) -> contains pnlGanttTopArea (Fill), splitterDetalle (Bottom), pnlCardDetalleGantt (Bottom)
        '
        Me.pnlBodyGantt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBodyGantt.Padding = New System.Windows.Forms.Padding(8)
        Me.pnlBodyGantt.Location = New System.Drawing.Point(0, 108)
        Me.pnlBodyGantt.Name = "pnlBodyGantt"
        Me.pnlBodyGantt.Size = New System.Drawing.Size(1280, 652)
        Me.pnlBodyGantt.TabIndex = 2
        Me.pnlBodyGantt.Controls.Add(Me.pnlGanttTopArea)
        Me.pnlBodyGantt.Controls.Add(Me.splitterDetalle)
        Me.pnlBodyGantt.Controls.Add(Me.pnlCardDetalleGantt)

        '
        'pnlGanttTopArea (Fill) -> contains pnlGanttRight (Fill), splitterMain (Left), pnlGanttLeft (Left)
        '
        Me.pnlGanttTopArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGanttTopArea.Name = "pnlGanttTopArea"
        Me.pnlGanttTopArea.TabIndex = 0
        Me.pnlGanttTopArea.Controls.Add(Me.pnlGanttRight)
        Me.pnlGanttTopArea.Controls.Add(Me.splitterMain)
        Me.pnlGanttTopArea.Controls.Add(Me.pnlGanttLeft)

        Me.pnlGanttLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGanttLeft.Name = "pnlGanttLeft"
        Me.pnlGanttLeft.Size = New System.Drawing.Size(720, 440)
        Me.pnlGanttLeft.TabIndex = 0
        Me.pnlGanttLeft.Controls.Add(Me.grillaInfoGantt)

        Me.splitterMain.Dock = System.Windows.Forms.DockStyle.Left
        Me.splitterMain.BackColor = System.Drawing.Color.FromArgb(200, 218, 223)
        Me.splitterMain.MinExtra = 240
        Me.splitterMain.MinSize = 260
        Me.splitterMain.Name = "splitterMain"
        Me.splitterMain.Size = New System.Drawing.Size(6, 440)
        Me.splitterMain.TabIndex = 1
        Me.splitterMain.TabStop = False

        Me.pnlGanttRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGanttRight.Name = "pnlGanttRight"
        Me.pnlGanttRight.TabIndex = 2
        Me.pnlGanttRight.Controls.Add(Me.grillaGraficoGantt)

        Me.splitterDetalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.splitterDetalle.BackColor = System.Drawing.Color.FromArgb(200, 218, 223)
        Me.splitterDetalle.MinExtra = 180
        Me.splitterDetalle.MinSize = 100
        Me.splitterDetalle.Name = "splitterDetalle"
        Me.splitterDetalle.Size = New System.Drawing.Size(1264, 6)
        Me.splitterDetalle.TabIndex = 1
        Me.splitterDetalle.TabStop = False

        '
        'grillaInfoGantt
        '
        Me.grillaInfoGantt.AllowUserToAddRows = False
        Me.grillaInfoGantt.AllowUserToDeleteRows = False
        Me.grillaInfoGantt.AllowUserToResizeRows = False
        styleAltGantt.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaInfoGantt.AlternatingRowsDefaultCellStyle = styleAltGantt
        Me.grillaInfoGantt.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaInfoGantt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        styleHeaderGantt.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        styleHeaderGantt.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        styleHeaderGantt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        styleHeaderGantt.ForeColor = System.Drawing.Color.White
        styleHeaderGantt.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        styleHeaderGantt.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        styleHeaderGantt.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grillaInfoGantt.ColumnHeadersDefaultCellStyle = styleHeaderGantt
        Me.grillaInfoGantt.ColumnHeadersHeight = 36
        Me.grillaInfoGantt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grillaInfoGantt.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_ciclo, Me.item, Me.obs_ciclo, Me.fecha_inicio, Me.fecha_termino, Me.duracion, Me.colIdMant, Me.colSeccion, Me.colEstado, Me.colTipoMp, Me.colIdNodo})
        Me.grillaInfoGantt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaInfoGantt.EnableHeadersVisualStyles = False
        Me.grillaInfoGantt.Location = New System.Drawing.Point(0, 0)
        Me.grillaInfoGantt.MultiSelect = False
        Me.grillaInfoGantt.Name = "grillaInfoGantt"
        Me.grillaInfoGantt.ReadOnly = True
        styleRowHdrGantt.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        styleRowHdrGantt.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        styleRowHdrGantt.ForeColor = System.Drawing.Color.White
        styleRowHdrGantt.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        styleRowHdrGantt.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.grillaInfoGantt.RowHeadersDefaultCellStyle = styleRowHdrGantt
        Me.grillaInfoGantt.RowHeadersVisible = False
        Me.grillaInfoGantt.RowTemplate.Height = 28
        Me.grillaInfoGantt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grillaInfoGantt.Size = New System.Drawing.Size(720, 440)
        Me.grillaInfoGantt.TabIndex = 0

        Me.id_ciclo.HeaderText = "ID Ciclo"
        Me.id_ciclo.Name = "id_ciclo"
        Me.id_ciclo.ReadOnly = True
        Me.id_ciclo.Width = 64

        Me.item.HeaderText = "Item / Máquina"
        Me.item.Name = "item"
        Me.item.ReadOnly = True
        Me.item.Width = 185

        Me.obs_ciclo.HeaderText = "Observación Ciclo"
        Me.obs_ciclo.Name = "obs_ciclo"
        Me.obs_ciclo.ReadOnly = True
        Me.obs_ciclo.Width = 215

        Me.fecha_inicio.HeaderText = "Fecha Inicio"
        Me.fecha_inicio.Name = "fecha_inicio"
        Me.fecha_inicio.ReadOnly = True
        Me.fecha_inicio.Width = 120

        Me.fecha_termino.HeaderText = "Fecha Término"
        Me.fecha_termino.Name = "fecha_termino"
        Me.fecha_termino.ReadOnly = True
        Me.fecha_termino.Width = 120

        Me.duracion.HeaderText = "Duración (Hrs)"
        Me.duracion.Name = "duracion"
        Me.duracion.ReadOnly = True
        Me.duracion.Width = 84

        Me.colIdMant.HeaderText = "N° MP"
        Me.colIdMant.Name = "colIdMant"
        Me.colIdMant.ReadOnly = True
        Me.colIdMant.Width = 68

        Me.colSeccion.HeaderText = "Sección"
        Me.colSeccion.Name = "colSeccion"
        Me.colSeccion.ReadOnly = True
        Me.colSeccion.Width = 135

        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        Me.colEstado.Width = 86

        Me.colTipoMp.HeaderText = "Tipo MP"
        Me.colTipoMp.Name = "colTipoMp"
        Me.colTipoMp.ReadOnly = True
        Me.colTipoMp.Width = 84

        Me.colIdNodo.HeaderText = "ID Nodo"
        Me.colIdNodo.Name = "colIdNodo"
        Me.colIdNodo.ReadOnly = True
        Me.colIdNodo.Visible = False
        Me.colIdNodo.Width = 50

        '
        'grillaGraficoGantt
        '
        Me.grillaGraficoGantt.AllowUserToAddRows = False
        Me.grillaGraficoGantt.AllowUserToDeleteRows = False
        Me.grillaGraficoGantt.AllowUserToResizeRows = False
        Me.grillaGraficoGantt.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaGraficoGantt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        styleHeaderGrafico.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        styleHeaderGrafico.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        styleHeaderGrafico.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        styleHeaderGrafico.ForeColor = System.Drawing.Color.White
        styleHeaderGrafico.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        styleHeaderGrafico.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        styleHeaderGrafico.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaGraficoGantt.ColumnHeadersDefaultCellStyle = styleHeaderGrafico
        Me.grillaGraficoGantt.ColumnHeadersHeight = 36
        Me.grillaGraficoGantt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grillaGraficoGantt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaGraficoGantt.EnableHeadersVisualStyles = False
        Me.grillaGraficoGantt.Location = New System.Drawing.Point(0, 0)
        Me.grillaGraficoGantt.MultiSelect = False
        Me.grillaGraficoGantt.Name = "grillaGraficoGantt"
        Me.grillaGraficoGantt.ReadOnly = True
        Me.grillaGraficoGantt.RowHeadersVisible = False
        Me.grillaGraficoGantt.RowTemplate.Height = 28
        Me.grillaGraficoGantt.Size = New System.Drawing.Size(538, 440)
        Me.grillaGraficoGantt.TabIndex = 1

        '
        'pnlCardDetalleGantt
        '
        Me.pnlCardDetalleGantt.BackColor = System.Drawing.Color.White
        Me.pnlCardDetalleGantt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCardDetalleGantt.Controls.Add(Me.dgvTareasCicloDetalle)
        Me.pnlCardDetalleGantt.Controls.Add(Me.pnlDetalleMeta)
        Me.pnlCardDetalleGantt.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCardDetalleGantt.Name = "pnlCardDetalleGantt"
        Me.pnlCardDetalleGantt.Size = New System.Drawing.Size(1264, 190)
        Me.pnlCardDetalleGantt.TabIndex = 2

        Me.pnlDetalleMeta.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.pnlDetalleMeta.Controls.Add(Me.lblDetalleObsCompleta)
        Me.pnlDetalleMeta.Controls.Add(Me.lblDetalleCicloTitulo)
        Me.pnlDetalleMeta.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetalleMeta.Location = New System.Drawing.Point(0, 0)
        Me.pnlDetalleMeta.Name = "pnlDetalleMeta"
        Me.pnlDetalleMeta.Size = New System.Drawing.Size(1262, 46)
        Me.pnlDetalleMeta.TabIndex = 0

        Me.lblDetalleCicloTitulo.AutoSize = True
        Me.lblDetalleCicloTitulo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblDetalleCicloTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.lblDetalleCicloTitulo.Location = New System.Drawing.Point(10, 4)
        Me.lblDetalleCicloTitulo.Name = "lblDetalleCicloTitulo"
        Me.lblDetalleCicloTitulo.Size = New System.Drawing.Size(340, 17)
        Me.lblDetalleCicloTitulo.TabIndex = 0
        Me.lblDetalleCicloTitulo.Text = "Seleccione una fila o barra para inspeccionar su detalle y tareas"

        Me.lblDetalleObsCompleta.AutoSize = True
        Me.lblDetalleObsCompleta.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Regular)
        Me.lblDetalleObsCompleta.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
        Me.lblDetalleObsCompleta.Location = New System.Drawing.Point(10, 24)
        Me.lblDetalleObsCompleta.Name = "lblDetalleObsCompleta"
        Me.lblDetalleObsCompleta.Size = New System.Drawing.Size(260, 15)
        Me.lblDetalleObsCompleta.TabIndex = 1
        Me.lblDetalleObsCompleta.Text = "Observación completa del ciclo seleccionado"

        Me.dgvTareasCicloDetalle.AllowUserToAddRows = False
        Me.dgvTareasCicloDetalle.AllowUserToDeleteRows = False
        Me.dgvTareasCicloDetalle.AllowUserToResizeRows = False
        Me.dgvTareasCicloDetalle.BackgroundColor = System.Drawing.Color.White
        Me.dgvTareasCicloDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTareasCicloDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTareasCicloDetalle.EnableHeadersVisualStyles = False
        Me.dgvTareasCicloDetalle.Location = New System.Drawing.Point(0, 46)
        Me.dgvTareasCicloDetalle.MultiSelect = False
        Me.dgvTareasCicloDetalle.Name = "dgvTareasCicloDetalle"
        Me.dgvTareasCicloDetalle.ReadOnly = True
        Me.dgvTareasCicloDetalle.RowHeadersVisible = False
        Me.dgvTareasCicloDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTareasCicloDetalle.Size = New System.Drawing.Size(1262, 142)
        Me.dgvTareasCicloDetalle.TabIndex = 1

        '
        'FrmCartaGantt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(1280, 760)
        Me.MinimumSize = New System.Drawing.Size(1160, 620)
        Me.ControlBox = True
        Me.Controls.Add(Me.pnlBodyGantt)
        Me.Controls.Add(Me.pnlCardFiltrosGantt)
        Me.Controls.Add(Me.pnlCardHeaderGantt)
        Me.MaximizeBox = True
        Me.MinimizeBox = True
        Me.Name = "FrmCartaGantt"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visualización de Informe Carta Gantt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized

        Me.pnlCardHeaderGantt.ResumeLayout(False)
        Me.pnlCardHeaderGantt.PerformLayout()
        Me.pnlCardFiltrosGantt.ResumeLayout(False)
        Me.pnlCardFiltrosGantt.PerformLayout()
        Me.pnlLeyendaGantt.ResumeLayout(False)
        Me.pnlBodyGantt.ResumeLayout(False)
        Me.pnlGanttTopArea.ResumeLayout(False)
        Me.pnlGanttLeft.ResumeLayout(False)
        Me.pnlGanttRight.ResumeLayout(False)
        Me.pnlCardDetalleGantt.ResumeLayout(False)
        Me.pnlDetalleMeta.ResumeLayout(False)
        Me.pnlDetalleMeta.PerformLayout()
        CType(Me.grillaInfoGantt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grillaGraficoGantt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTareasCicloDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents pnlCardHeaderGantt As System.Windows.Forms.Panel
    Friend WithEvents pnlCardFiltrosGantt As System.Windows.Forms.Panel
    Friend WithEvents pnlLeyendaGantt As System.Windows.Forms.Panel
    Friend WithEvents lblKpiLeyPendiente As System.Windows.Forms.Label
    Friend WithEvents lblKpiLeyTerminado As System.Windows.Forms.Label
    Friend WithEvents lblKpiLeyVencido As System.Windows.Forms.Label
    Friend WithEvents lblTituloGantt As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDesdeGantt As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblHastaGantt As System.Windows.Forms.Label
    Friend WithEvents lblResumenGantt As System.Windows.Forms.Label
    Friend WithEvents btnFiltrarMarcados As System.Windows.Forms.Button
    Friend WithEvents btnExpPdf As System.Windows.Forms.Button
    Friend WithEvents btnExpExcel As System.Windows.Forms.Button
    Friend WithEvents btnSalirGantt As System.Windows.Forms.Button
    Friend WithEvents lblBuscarNumMp As System.Windows.Forms.Label
    Friend WithEvents txtBuscarNumMp As System.Windows.Forms.TextBox
    Friend WithEvents lblBuscarIdCiclo As System.Windows.Forms.Label
    Friend WithEvents txtBuscarIdCiclo As System.Windows.Forms.TextBox
    Friend WithEvents lblBuscarGantt As System.Windows.Forms.Label
    Friend WithEvents txtBuscarGantt As System.Windows.Forms.TextBox
    Friend WithEvents lblFiltroEstado As System.Windows.Forms.Label
    Friend WithEvents cmbFiltroEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblZoomGantt As System.Windows.Forms.Label
    Friend WithEvents cmbZoomGantt As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscarGantt As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarGantt As System.Windows.Forms.Button
    Friend WithEvents btnToggleDetalle As System.Windows.Forms.Button
    Friend WithEvents pnlBodyGantt As System.Windows.Forms.Panel
    Friend WithEvents pnlGanttTopArea As System.Windows.Forms.Panel
    Friend WithEvents pnlGanttLeft As System.Windows.Forms.Panel
    Friend WithEvents pnlGanttRight As System.Windows.Forms.Panel
    Friend WithEvents splitterMain As System.Windows.Forms.Splitter
    Friend WithEvents splitterDetalle As System.Windows.Forms.Splitter
    Friend WithEvents grillaInfoGantt As System.Windows.Forms.DataGridView
    Friend WithEvents grillaGraficoGantt As System.Windows.Forms.DataGridView
    Friend WithEvents id_ciclo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents obs_ciclo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha_inicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha_termino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents duracion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIdMant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSeccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipoMp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIdNodo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlCardDetalleGantt As System.Windows.Forms.Panel
    Friend WithEvents pnlDetalleMeta As System.Windows.Forms.Panel
    Friend WithEvents lblDetalleCicloTitulo As System.Windows.Forms.Label
    Friend WithEvents lblDetalleObsCompleta As System.Windows.Forms.Label
    Friend WithEvents dgvTareasCicloDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
End Class
