<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmResumenes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle

        Me.txtBuscarNodo = New System.Windows.Forms.TextBox
        Me.arbol7 = New System.Windows.Forms.TreeView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.fecha_ini_resumen = New System.Windows.Forms.DateTimePicker
        Me.fecha_fin_resumen = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.grpDesglose = New System.Windows.Forms.Panel
        Me.opc_totales_estado = New System.Windows.Forms.RadioButton
        Me.opc_por_mes = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnBuscarRes = New System.Windows.Forms.Button
        Me.btn_exp_excel_res = New System.Windows.Forms.Button
        Me.btn_exp_pdf_res = New System.Windows.Forms.Button
        Me.btnSalirRes = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label

        ' Panel de KPIs
        Me.pnlKpis = New System.Windows.Forms.Panel
        Me.tblKpis = New System.Windows.Forms.TableLayoutPanel
        Me.pnlCard1 = New System.Windows.Forms.Panel
        Me.lblTitKpi1 = New System.Windows.Forms.Label
        Me.lblKpiTotal = New System.Windows.Forms.Label
        Me.pnlCard2 = New System.Windows.Forms.Panel
        Me.lblTitKpi2 = New System.Windows.Forms.Label
        Me.lblKpiCerradas = New System.Windows.Forms.Label
        Me.pnlCard3 = New System.Windows.Forms.Panel
        Me.lblTitKpi3 = New System.Windows.Forms.Label
        Me.lblKpiAbiertas = New System.Windows.Forms.Label
        Me.pnlCard4 = New System.Windows.Forms.Panel
        Me.lblTitKpi4 = New System.Windows.Forms.Label
        Me.lblKpiTopMaquina = New System.Windows.Forms.Label
        Me.pnlCard5 = New System.Windows.Forms.Panel
        Me.lblTitKpi5 = New System.Windows.Forms.Label
        Me.lblKpiTopComponente = New System.Windows.Forms.Label
        Me.pnlCard6 = New System.Windows.Forms.Panel
        Me.lblTitKpi6 = New System.Windows.Forms.Label
        Me.lblKpiTopTecnico = New System.Windows.Forms.Label

        ' TabControl y Pestañas
        Me.tabResumenes = New System.Windows.Forms.TabControl
        Me.tabTopEquipos = New System.Windows.Forms.TabPage
        Me.tblEquipos = New System.Windows.Forms.TableLayoutPanel
        Me.grpTopMaquinas = New System.Windows.Forms.GroupBox
        Me.grillaTopMaquinas = New System.Windows.Forms.DataGridView
        Me.grpTopComponentes = New System.Windows.Forms.GroupBox
        Me.grillaTopComponentes = New System.Windows.Forms.DataGridView

        Me.tabPersonal = New System.Windows.Forms.TabPage
        Me.tblPersonal = New System.Windows.Forms.TableLayoutPanel
        Me.grpCerradaPorTec = New System.Windows.Forms.GroupBox
        Me.grillaOtCerradaPorTec = New System.Windows.Forms.DataGridView
        Me.grpRecibidaPor = New System.Windows.Forms.GroupBox
        Me.grillaOtRecibidaPor = New System.Windows.Forms.DataGridView

        Me.tabOperacional = New System.Windows.Forms.TabPage
        Me.tblOperacional = New System.Windows.Forms.TableLayoutPanel
        Me.grpTipoFalla = New System.Windows.Forms.GroupBox
        Me.grillaOtPorTipoFalla = New System.Windows.Forms.DataGridView
        Me.grpTurno = New System.Windows.Forms.GroupBox
        Me.grillaOtPorTurno = New System.Windows.Forms.DataGridView
        Me.grpTotales = New System.Windows.Forms.GroupBox
        Me.grillaTotalesPeriodo = New System.Windows.Forms.DataGridView

        Me.tabTemporal = New System.Windows.Forms.TabPage
        Me.tblTemporal = New System.Windows.Forms.TableLayoutPanel
        Me.grpDia = New System.Windows.Forms.GroupBox
        Me.grillaOtPorDia = New System.Windows.Forms.DataGridView
        Me.grpMes = New System.Windows.Forms.GroupBox
        Me.grillaOtPorMes = New System.Windows.Forms.DataGridView

        ' Labels de compatibilidad
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label

        Me.Panel1.SuspendLayout()
        Me.grpDesglose.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlKpis.SuspendLayout()
        Me.tblKpis.SuspendLayout()
        Me.pnlCard1.SuspendLayout()
        Me.pnlCard2.SuspendLayout()
        Me.pnlCard3.SuspendLayout()
        Me.pnlCard4.SuspendLayout()
        Me.pnlCard5.SuspendLayout()
        Me.pnlCard6.SuspendLayout()
        Me.tabResumenes.SuspendLayout()
        Me.tabTopEquipos.SuspendLayout()
        Me.tblEquipos.SuspendLayout()
        Me.grpTopMaquinas.SuspendLayout()
        CType(Me.grillaTopMaquinas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTopComponentes.SuspendLayout()
        CType(Me.grillaTopComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPersonal.SuspendLayout()
        Me.tblPersonal.SuspendLayout()
        Me.grpCerradaPorTec.SuspendLayout()
        CType(Me.grillaOtCerradaPorTec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpRecibidaPor.SuspendLayout()
        CType(Me.grillaOtRecibidaPor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabOperacional.SuspendLayout()
        Me.tblOperacional.SuspendLayout()
        Me.grpTipoFalla.SuspendLayout()
        CType(Me.grillaOtPorTipoFalla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTurno.SuspendLayout()
        CType(Me.grillaOtPorTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTotales.SuspendLayout()
        CType(Me.grillaTotalesPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTemporal.SuspendLayout()
        Me.tblTemporal.SuspendLayout()
        Me.grpDia.SuspendLayout()
        CType(Me.grillaOtPorDia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMes.SuspendLayout()
        CType(Me.grillaOtPorMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBuscarNodo
        '
        Me.txtBuscarNodo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscarNodo.Location = New System.Drawing.Point(12, 12)
        Me.txtBuscarNodo.Name = "txtBuscarNodo"
        Me.txtBuscarNodo.Size = New System.Drawing.Size(225, 23)
        Me.txtBuscarNodo.TabIndex = 0
        '
        'arbol7
        '
        Me.arbol7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.arbol7.CheckBoxes = True
        Me.arbol7.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.arbol7.Location = New System.Drawing.Point(12, 40)
        Me.arbol7.Name = "arbol7"
        Me.arbol7.Size = New System.Drawing.Size(225, 630)
        Me.arbol7.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.fecha_ini_resumen)
        Me.Panel1.Controls.Add(Me.fecha_fin_resumen)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(245, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(236, 58)
        Me.Panel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Desde"
        '
        'fecha_ini_resumen
        '
        Me.fecha_ini_resumen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_ini_resumen.Location = New System.Drawing.Point(6, 27)
        Me.fecha_ini_resumen.Name = "fecha_ini_resumen"
        Me.fecha_ini_resumen.Size = New System.Drawing.Size(106, 23)
        Me.fecha_ini_resumen.TabIndex = 1
        '
        'fecha_fin_resumen
        '
        Me.fecha_fin_resumen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_fin_resumen.Location = New System.Drawing.Point(120, 27)
        Me.fecha_fin_resumen.Name = "fecha_fin_resumen"
        Me.fecha_fin_resumen.Size = New System.Drawing.Size(106, 23)
        Me.fecha_fin_resumen.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(120, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha Hasta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(252, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 14)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Rango de Fechas"
        '
        'grpDesglose
        '
        Me.grpDesglose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grpDesglose.Controls.Add(Me.opc_totales_estado)
        Me.grpDesglose.Controls.Add(Me.opc_por_mes)
        Me.grpDesglose.Location = New System.Drawing.Point(489, 12)
        Me.grpDesglose.Name = "grpDesglose"
        Me.grpDesglose.Size = New System.Drawing.Size(155, 58)
        Me.grpDesglose.TabIndex = 4
        '
        'opc_totales_estado
        '
        Me.opc_totales_estado.AutoSize = True
        Me.opc_totales_estado.Checked = True
        Me.opc_totales_estado.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opc_totales_estado.Location = New System.Drawing.Point(6, 9)
        Me.opc_totales_estado.Name = "opc_totales_estado"
        Me.opc_totales_estado.Size = New System.Drawing.Size(124, 18)
        Me.opc_totales_estado.TabIndex = 0
        Me.opc_totales_estado.TabStop = True
        Me.opc_totales_estado.Text = "Totales del Período"
        Me.opc_totales_estado.UseVisualStyleBackColor = True
        '
        'opc_por_mes
        '
        Me.opc_por_mes.AutoSize = True
        Me.opc_por_mes.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opc_por_mes.Location = New System.Drawing.Point(6, 31)
        Me.opc_por_mes.Name = "opc_por_mes"
        Me.opc_por_mes.Size = New System.Drawing.Size(117, 18)
        Me.opc_por_mes.TabIndex = 1
        Me.opc_por_mes.Text = "Desglose por Mes"
        Me.opc_por_mes.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnBuscarRes)
        Me.Panel2.Controls.Add(Me.btn_exp_excel_res)
        Me.Panel2.Controls.Add(Me.btn_exp_pdf_res)
        Me.Panel2.Controls.Add(Me.btnSalirRes)
        Me.Panel2.Location = New System.Drawing.Point(652, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(168, 58)
        Me.Panel2.TabIndex = 5
        '
        'btnBuscarRes
        '
        Me.btnBuscarRes.BackgroundImage = Global.mantencion.My.Resources.Resources.icono_buscar1
        Me.btnBuscarRes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscarRes.Location = New System.Drawing.Point(8, 12)
        Me.btnBuscarRes.Name = "btnBuscarRes"
        Me.btnBuscarRes.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscarRes.TabIndex = 0
        Me.btnBuscarRes.UseVisualStyleBackColor = True
        '
        'btn_exp_excel_res
        '
        Me.btn_exp_excel_res.Image = Global.mantencion.My.Resources.Resources.icono_excel1
        Me.btn_exp_excel_res.Location = New System.Drawing.Point(48, 12)
        Me.btn_exp_excel_res.Name = "btn_exp_excel_res"
        Me.btn_exp_excel_res.Size = New System.Drawing.Size(32, 32)
        Me.btn_exp_excel_res.TabIndex = 1
        Me.btn_exp_excel_res.UseVisualStyleBackColor = True
        '
        'btn_exp_pdf_res
        '
        Me.btn_exp_pdf_res.BackgroundImage = Global.mantencion.My.Resources.Resources.icono_pdf
        Me.btn_exp_pdf_res.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_exp_pdf_res.Location = New System.Drawing.Point(88, 12)
        Me.btn_exp_pdf_res.Name = "btn_exp_pdf_res"
        Me.btn_exp_pdf_res.Size = New System.Drawing.Size(32, 32)
        Me.btn_exp_pdf_res.TabIndex = 2
        Me.btn_exp_pdf_res.UseVisualStyleBackColor = True
        '
        'btnSalirRes
        '
        Me.btnSalirRes.BackgroundImage = Global.mantencion.My.Resources.Resources.salir
        Me.btnSalirRes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalirRes.Location = New System.Drawing.Point(128, 12)
        Me.btnSalirRes.Name = "btnSalirRes"
        Me.btnSalirRes.Size = New System.Drawing.Size(32, 32)
        Me.btnSalirRes.TabIndex = 3
        Me.btnSalirRes.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(659, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 14)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Operaciones"
        '
        'pnlKpis
        '
        Me.pnlKpis.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlKpis.BackColor = System.Drawing.Color.White
        Me.pnlKpis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlKpis.Controls.Add(Me.tblKpis)
        Me.pnlKpis.Location = New System.Drawing.Point(245, 76)
        Me.pnlKpis.Name = "pnlKpis"
        Me.pnlKpis.Size = New System.Drawing.Size(765, 68)
        Me.pnlKpis.TabIndex = 7
        '
        'tblKpis
        '
        Me.tblKpis.ColumnCount = 6
        Me.tblKpis.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tblKpis.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.0!))
        Me.tblKpis.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.0!))
        Me.tblKpis.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.tblKpis.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.tblKpis.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
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
        Me.tblKpis.Size = New System.Drawing.Size(763, 66)
        Me.tblKpis.TabIndex = 0
        '
        'pnlCard1
        '
        Me.pnlCard1.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlCard1.Controls.Add(Me.lblKpiTotal)
        Me.pnlCard1.Controls.Add(Me.lblTitKpi1)
        Me.pnlCard1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard1.Location = New System.Drawing.Point(3, 3)
        Me.pnlCard1.Margin = New System.Windows.Forms.Padding(3)
        Me.pnlCard1.Name = "pnlCard1"
        Me.pnlCard1.Size = New System.Drawing.Size(108, 60)
        Me.pnlCard1.TabIndex = 0
        '
        'lblTitKpi1
        '
        Me.lblTitKpi1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitKpi1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitKpi1.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblTitKpi1.Location = New System.Drawing.Point(0, 0)
        Me.lblTitKpi1.Name = "lblTitKpi1"
        Me.lblTitKpi1.Size = New System.Drawing.Size(108, 16)
        Me.lblTitKpi1.TabIndex = 0
        Me.lblTitKpi1.Text = "TOTAL ÓRDENES"
        Me.lblTitKpi1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKpiTotal
        '
        Me.lblKpiTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKpiTotal.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKpiTotal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.lblKpiTotal.Location = New System.Drawing.Point(0, 16)
        Me.lblKpiTotal.Name = "lblKpiTotal"
        Me.lblKpiTotal.Size = New System.Drawing.Size(108, 44)
        Me.lblKpiTotal.TabIndex = 1
        Me.lblKpiTotal.Text = "0"
        Me.lblKpiTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCard2
        '
        Me.pnlCard2.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlCard2.Controls.Add(Me.lblKpiCerradas)
        Me.pnlCard2.Controls.Add(Me.lblTitKpi2)
        Me.pnlCard2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard2.Location = New System.Drawing.Point(117, 3)
        Me.pnlCard2.Margin = New System.Windows.Forms.Padding(3)
        Me.pnlCard2.Name = "pnlCard2"
        Me.pnlCard2.Size = New System.Drawing.Size(123, 60)
        Me.pnlCard2.TabIndex = 1
        '
        'lblTitKpi2
        '
        Me.lblTitKpi2.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitKpi2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitKpi2.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblTitKpi2.Location = New System.Drawing.Point(0, 0)
        Me.lblTitKpi2.Name = "lblTitKpi2"
        Me.lblTitKpi2.Size = New System.Drawing.Size(123, 16)
        Me.lblTitKpi2.TabIndex = 0
        Me.lblTitKpi2.Text = "OTs CERRADAS"
        Me.lblTitKpi2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKpiCerradas
        '
        Me.lblKpiCerradas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKpiCerradas.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKpiCerradas.ForeColor = System.Drawing.Color.FromArgb(16, 120, 60)
        Me.lblKpiCerradas.Location = New System.Drawing.Point(0, 16)
        Me.lblKpiCerradas.Name = "lblKpiCerradas"
        Me.lblKpiCerradas.Size = New System.Drawing.Size(123, 44)
        Me.lblKpiCerradas.TabIndex = 1
        Me.lblKpiCerradas.Text = "0 (0%)"
        Me.lblKpiCerradas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCard3
        '
        Me.pnlCard3.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlCard3.Controls.Add(Me.lblKpiAbiertas)
        Me.pnlCard3.Controls.Add(Me.lblTitKpi3)
        Me.pnlCard3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard3.Location = New System.Drawing.Point(246, 3)
        Me.pnlCard3.Margin = New System.Windows.Forms.Padding(3)
        Me.pnlCard3.Name = "pnlCard3"
        Me.pnlCard3.Size = New System.Drawing.Size(123, 60)
        Me.pnlCard3.TabIndex = 2
        '
        'lblTitKpi3
        '
        Me.lblTitKpi3.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitKpi3.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitKpi3.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblTitKpi3.Location = New System.Drawing.Point(0, 0)
        Me.lblTitKpi3.Name = "lblTitKpi3"
        Me.lblTitKpi3.Size = New System.Drawing.Size(123, 16)
        Me.lblTitKpi3.TabIndex = 0
        Me.lblTitKpi3.Text = "OTs ABIERTAS"
        Me.lblTitKpi3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKpiAbiertas
        '
        Me.lblKpiAbiertas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKpiAbiertas.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKpiAbiertas.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28)
        Me.lblKpiAbiertas.Location = New System.Drawing.Point(0, 16)
        Me.lblKpiAbiertas.Name = "lblKpiAbiertas"
        Me.lblKpiAbiertas.Size = New System.Drawing.Size(123, 44)
        Me.lblKpiAbiertas.TabIndex = 1
        Me.lblKpiAbiertas.Text = "0 (0%)"
        Me.lblKpiAbiertas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCard4
        '
        Me.pnlCard4.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlCard4.Controls.Add(Me.lblKpiTopMaquina)
        Me.pnlCard4.Controls.Add(Me.lblTitKpi4)
        Me.pnlCard4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard4.Location = New System.Drawing.Point(375, 3)
        Me.pnlCard4.Margin = New System.Windows.Forms.Padding(3)
        Me.pnlCard4.Name = "pnlCard4"
        Me.pnlCard4.Size = New System.Drawing.Size(131, 60)
        Me.pnlCard4.TabIndex = 3
        '
        'lblTitKpi4
        '
        Me.lblTitKpi4.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitKpi4.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitKpi4.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblTitKpi4.Location = New System.Drawing.Point(0, 0)
        Me.lblTitKpi4.Name = "lblTitKpi4"
        Me.lblTitKpi4.Size = New System.Drawing.Size(131, 16)
        Me.lblTitKpi4.TabIndex = 0
        Me.lblTitKpi4.Text = "MÁQUINA CRÍTICA"
        Me.lblTitKpi4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKpiTopMaquina
        '
        Me.lblKpiTopMaquina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKpiTopMaquina.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKpiTopMaquina.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.lblKpiTopMaquina.Location = New System.Drawing.Point(0, 16)
        Me.lblKpiTopMaquina.Name = "lblKpiTopMaquina"
        Me.lblKpiTopMaquina.Size = New System.Drawing.Size(131, 44)
        Me.lblKpiTopMaquina.TabIndex = 1
        Me.lblKpiTopMaquina.Text = "-"
        Me.lblKpiTopMaquina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCard5
        '
        Me.pnlCard5.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlCard5.Controls.Add(Me.lblKpiTopComponente)
        Me.pnlCard5.Controls.Add(Me.lblTitKpi5)
        Me.pnlCard5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard5.Location = New System.Drawing.Point(512, 3)
        Me.pnlCard5.Margin = New System.Windows.Forms.Padding(3)
        Me.pnlCard5.Name = "pnlCard5"
        Me.pnlCard5.Size = New System.Drawing.Size(131, 60)
        Me.pnlCard5.TabIndex = 4
        '
        'lblTitKpi5
        '
        Me.lblTitKpi5.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitKpi5.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitKpi5.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblTitKpi5.Location = New System.Drawing.Point(0, 0)
        Me.lblTitKpi5.Name = "lblTitKpi5"
        Me.lblTitKpi5.Size = New System.Drawing.Size(131, 16)
        Me.lblTitKpi5.TabIndex = 0
        Me.lblTitKpi5.Text = "COMPONENTE CRÍTICO"
        Me.lblTitKpi5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKpiTopComponente
        '
        Me.lblKpiTopComponente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKpiTopComponente.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKpiTopComponente.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.lblKpiTopComponente.Location = New System.Drawing.Point(0, 16)
        Me.lblKpiTopComponente.Name = "lblKpiTopComponente"
        Me.lblKpiTopComponente.Size = New System.Drawing.Size(131, 44)
        Me.lblKpiTopComponente.TabIndex = 1
        Me.lblKpiTopComponente.Text = "-"
        Me.lblKpiTopComponente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCard6
        '
        Me.pnlCard6.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlCard6.Controls.Add(Me.lblKpiTopTecnico)
        Me.pnlCard6.Controls.Add(Me.lblTitKpi6)
        Me.pnlCard6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard6.Location = New System.Drawing.Point(649, 3)
        Me.pnlCard6.Margin = New System.Windows.Forms.Padding(3)
        Me.pnlCard6.Name = "pnlCard6"
        Me.pnlCard6.Size = New System.Drawing.Size(111, 60)
        Me.pnlCard6.TabIndex = 5
        '
        'lblTitKpi6
        '
        Me.lblTitKpi6.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitKpi6.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitKpi6.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblTitKpi6.Location = New System.Drawing.Point(0, 0)
        Me.lblTitKpi6.Name = "lblTitKpi6"
        Me.lblTitKpi6.Size = New System.Drawing.Size(111, 16)
        Me.lblTitKpi6.TabIndex = 0
        Me.lblTitKpi6.Text = "TÉCNICO LÍDER"
        Me.lblTitKpi6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKpiTopTecnico
        '
        Me.lblKpiTopTecnico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblKpiTopTecnico.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKpiTopTecnico.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.lblKpiTopTecnico.Location = New System.Drawing.Point(0, 16)
        Me.lblKpiTopTecnico.Name = "lblKpiTopTecnico"
        Me.lblKpiTopTecnico.Size = New System.Drawing.Size(111, 44)
        Me.lblKpiTopTecnico.TabIndex = 1
        Me.lblKpiTopTecnico.Text = "-"
        Me.lblKpiTopTecnico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabResumenes
        '
        Me.tabResumenes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabResumenes.Controls.Add(Me.tabTopEquipos)
        Me.tabResumenes.Controls.Add(Me.tabPersonal)
        Me.tabResumenes.Controls.Add(Me.tabOperacional)
        Me.tabResumenes.Controls.Add(Me.tabTemporal)
        Me.tabResumenes.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabResumenes.Location = New System.Drawing.Point(245, 148)
        Me.tabResumenes.Name = "tabResumenes"
        Me.tabResumenes.SelectedIndex = 0
        Me.tabResumenes.Size = New System.Drawing.Size(765, 522)
        Me.tabResumenes.TabIndex = 8
        '
        'tabTopEquipos
        '
        Me.tabTopEquipos.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.tabTopEquipos.Controls.Add(Me.tblEquipos)
        Me.tabTopEquipos.Location = New System.Drawing.Point(4, 24)
        Me.tabTopEquipos.Name = "tabTopEquipos"
        Me.tabTopEquipos.Padding = New System.Windows.Forms.Padding(6)
        Me.tabTopEquipos.Size = New System.Drawing.Size(757, 494)
        Me.tabTopEquipos.TabIndex = 0
        Me.tabTopEquipos.Text = "  Top Máquinas y Componentes  "
        '
        'tblEquipos
        '
        Me.tblEquipos.ColumnCount = 2
        Me.tblEquipos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblEquipos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblEquipos.Controls.Add(Me.grpTopMaquinas, 0, 0)
        Me.tblEquipos.Controls.Add(Me.grpTopComponentes, 1, 0)
        Me.tblEquipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblEquipos.Location = New System.Drawing.Point(6, 6)
        Me.tblEquipos.Name = "tblEquipos"
        Me.tblEquipos.RowCount = 1
        Me.tblEquipos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblEquipos.Size = New System.Drawing.Size(745, 482)
        Me.tblEquipos.TabIndex = 0
        '
        'grpTopMaquinas
        '
        Me.grpTopMaquinas.Controls.Add(Me.grillaTopMaquinas)
        Me.grpTopMaquinas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpTopMaquinas.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTopMaquinas.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpTopMaquinas.Location = New System.Drawing.Point(3, 3)
        Me.grpTopMaquinas.Name = "grpTopMaquinas"
        Me.grpTopMaquinas.Size = New System.Drawing.Size(366, 476)
        Me.grpTopMaquinas.TabIndex = 0
        Me.grpTopMaquinas.TabStop = False
        Me.grpTopMaquinas.Text = "Máquinas con Más Órdenes de Trabajo"
        '
        'grillaTopMaquinas
        '
        Me.grillaTopMaquinas.AllowUserToAddRows = False
        Me.grillaTopMaquinas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaTopMaquinas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grillaTopMaquinas.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaTopMaquinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaTopMaquinas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaTopMaquinas.EnableHeadersVisualStyles = False
        Me.grillaTopMaquinas.Location = New System.Drawing.Point(3, 19)
        Me.grillaTopMaquinas.Name = "grillaTopMaquinas"
        Me.grillaTopMaquinas.ReadOnly = True
        Me.grillaTopMaquinas.RowHeadersVisible = False
        Me.grillaTopMaquinas.Size = New System.Drawing.Size(360, 454)
        Me.grillaTopMaquinas.TabIndex = 0
        '
        'grpTopComponentes
        '
        Me.grpTopComponentes.Controls.Add(Me.grillaTopComponentes)
        Me.grpTopComponentes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpTopComponentes.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTopComponentes.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpTopComponentes.Location = New System.Drawing.Point(375, 3)
        Me.grpTopComponentes.Name = "grpTopComponentes"
        Me.grpTopComponentes.Size = New System.Drawing.Size(367, 476)
        Me.grpTopComponentes.TabIndex = 1
        Me.grpTopComponentes.TabStop = False
        Me.grpTopComponentes.Text = "Componentes / Partes con Más Órdenes"
        '
        'grillaTopComponentes
        '
        Me.grillaTopComponentes.AllowUserToAddRows = False
        Me.grillaTopComponentes.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaTopComponentes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grillaTopComponentes.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaTopComponentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaTopComponentes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaTopComponentes.EnableHeadersVisualStyles = False
        Me.grillaTopComponentes.Location = New System.Drawing.Point(3, 19)
        Me.grillaTopComponentes.Name = "grillaTopComponentes"
        Me.grillaTopComponentes.ReadOnly = True
        Me.grillaTopComponentes.RowHeadersVisible = False
        Me.grillaTopComponentes.Size = New System.Drawing.Size(361, 454)
        Me.grillaTopComponentes.TabIndex = 0
        '
        'tabPersonal
        '
        Me.tabPersonal.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.tabPersonal.Controls.Add(Me.tblPersonal)
        Me.tabPersonal.Location = New System.Drawing.Point(4, 24)
        Me.tabPersonal.Name = "tabPersonal"
        Me.tabPersonal.Padding = New System.Windows.Forms.Padding(6)
        Me.tabPersonal.Size = New System.Drawing.Size(757, 494)
        Me.tabPersonal.TabIndex = 1
        Me.tabPersonal.Text = "  Personal y Rendimiento  "
        '
        'tblPersonal
        '
        Me.tblPersonal.ColumnCount = 2
        Me.tblPersonal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblPersonal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblPersonal.Controls.Add(Me.grpCerradaPorTec, 0, 0)
        Me.tblPersonal.Controls.Add(Me.grpRecibidaPor, 1, 0)
        Me.tblPersonal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPersonal.Location = New System.Drawing.Point(6, 6)
        Me.tblPersonal.Name = "tblPersonal"
        Me.tblPersonal.RowCount = 1
        Me.tblPersonal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPersonal.Size = New System.Drawing.Size(745, 482)
        Me.tblPersonal.TabIndex = 0
        '
        'grpCerradaPorTec
        '
        Me.grpCerradaPorTec.Controls.Add(Me.grillaOtCerradaPorTec)
        Me.grpCerradaPorTec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCerradaPorTec.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCerradaPorTec.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpCerradaPorTec.Location = New System.Drawing.Point(3, 3)
        Me.grpCerradaPorTec.Name = "grpCerradaPorTec"
        Me.grpCerradaPorTec.Size = New System.Drawing.Size(366, 476)
        Me.grpCerradaPorTec.TabIndex = 0
        Me.grpCerradaPorTec.TabStop = False
        Me.grpCerradaPorTec.Text = "Personal con Más Órdenes Cerradas (Técnicos)"
        '
        'grillaOtCerradaPorTec
        '
        Me.grillaOtCerradaPorTec.AllowUserToAddRows = False
        Me.grillaOtCerradaPorTec.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaOtCerradaPorTec.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grillaOtCerradaPorTec.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaOtCerradaPorTec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaOtCerradaPorTec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaOtCerradaPorTec.EnableHeadersVisualStyles = False
        Me.grillaOtCerradaPorTec.Location = New System.Drawing.Point(3, 19)
        Me.grillaOtCerradaPorTec.Name = "grillaOtCerradaPorTec"
        Me.grillaOtCerradaPorTec.ReadOnly = True
        Me.grillaOtCerradaPorTec.RowHeadersVisible = False
        Me.grillaOtCerradaPorTec.Size = New System.Drawing.Size(360, 454)
        Me.grillaOtCerradaPorTec.TabIndex = 0
        '
        'grpRecibidaPor
        '
        Me.grpRecibidaPor.Controls.Add(Me.grillaOtRecibidaPor)
        Me.grpRecibidaPor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpRecibidaPor.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpRecibidaPor.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpRecibidaPor.Location = New System.Drawing.Point(375, 3)
        Me.grpRecibidaPor.Name = "grpRecibidaPor"
        Me.grpRecibidaPor.Size = New System.Drawing.Size(367, 476)
        Me.grpRecibidaPor.TabIndex = 1
        Me.grpRecibidaPor.TabStop = False
        Me.grpRecibidaPor.Text = "Personal que Recibió Órdenes (Recepción / Solicitud)"
        '
        'grillaOtRecibidaPor
        '
        Me.grillaOtRecibidaPor.AllowUserToAddRows = False
        Me.grillaOtRecibidaPor.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaOtRecibidaPor.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grillaOtRecibidaPor.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaOtRecibidaPor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaOtRecibidaPor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaOtRecibidaPor.EnableHeadersVisualStyles = False
        Me.grillaOtRecibidaPor.Location = New System.Drawing.Point(3, 19)
        Me.grillaOtRecibidaPor.Name = "grillaOtRecibidaPor"
        Me.grillaOtRecibidaPor.ReadOnly = True
        Me.grillaOtRecibidaPor.RowHeadersVisible = False
        Me.grillaOtRecibidaPor.Size = New System.Drawing.Size(361, 454)
        Me.grillaOtRecibidaPor.TabIndex = 0
        '
        'tabOperacional
        '
        Me.tabOperacional.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.tabOperacional.Controls.Add(Me.tblOperacional)
        Me.tabOperacional.Location = New System.Drawing.Point(4, 24)
        Me.tabOperacional.Name = "tabOperacional"
        Me.tabOperacional.Padding = New System.Windows.Forms.Padding(6)
        Me.tabOperacional.Size = New System.Drawing.Size(757, 494)
        Me.tabOperacional.TabIndex = 2
        Me.tabOperacional.Text = "  Desglose por Fallas y Turnos  "
        '
        'tblOperacional
        '
        Me.tblOperacional.ColumnCount = 3
        Me.tblOperacional.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.0!))
        Me.tblOperacional.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.tblOperacional.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.tblOperacional.Controls.Add(Me.grpTipoFalla, 0, 0)
        Me.tblOperacional.Controls.Add(Me.grpTurno, 1, 0)
        Me.tblOperacional.Controls.Add(Me.grpTotales, 2, 0)
        Me.tblOperacional.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblOperacional.Location = New System.Drawing.Point(6, 6)
        Me.tblOperacional.Name = "tblOperacional"
        Me.tblOperacional.RowCount = 1
        Me.tblOperacional.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblOperacional.Size = New System.Drawing.Size(745, 482)
        Me.tblOperacional.TabIndex = 0
        '
        'grpTipoFalla
        '
        Me.grpTipoFalla.Controls.Add(Me.grillaOtPorTipoFalla)
        Me.grpTipoFalla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpTipoFalla.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTipoFalla.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpTipoFalla.Location = New System.Drawing.Point(3, 3)
        Me.grpTipoFalla.Name = "grpTipoFalla"
        Me.grpTipoFalla.Size = New System.Drawing.Size(262, 476)
        Me.grpTipoFalla.TabIndex = 0
        Me.grpTipoFalla.TabStop = False
        Me.grpTipoFalla.Text = "Órdenes por Tipo de Trabajo / Falla"
        '
        'grillaOtPorTipoFalla
        '
        Me.grillaOtPorTipoFalla.AllowUserToAddRows = False
        Me.grillaOtPorTipoFalla.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaOtPorTipoFalla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.grillaOtPorTipoFalla.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaOtPorTipoFalla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaOtPorTipoFalla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaOtPorTipoFalla.EnableHeadersVisualStyles = False
        Me.grillaOtPorTipoFalla.Location = New System.Drawing.Point(3, 19)
        Me.grillaOtPorTipoFalla.Name = "grillaOtPorTipoFalla"
        Me.grillaOtPorTipoFalla.ReadOnly = True
        Me.grillaOtPorTipoFalla.RowHeadersVisible = False
        Me.grillaOtPorTipoFalla.Size = New System.Drawing.Size(256, 454)
        Me.grillaOtPorTipoFalla.TabIndex = 0
        '
        'grpTurno
        '
        Me.grpTurno.Controls.Add(Me.grillaOtPorTurno)
        Me.grpTurno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpTurno.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTurno.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpTurno.Location = New System.Drawing.Point(271, 3)
        Me.grpTurno.Name = "grpTurno"
        Me.grpTurno.Size = New System.Drawing.Size(232, 476)
        Me.grpTurno.TabIndex = 1
        Me.grpTurno.TabStop = False
        Me.grpTurno.Text = "Órdenes por Turno"
        '
        'grillaOtPorTurno
        '
        Me.grillaOtPorTurno.AllowUserToAddRows = False
        Me.grillaOtPorTurno.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaOtPorTurno.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.grillaOtPorTurno.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaOtPorTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaOtPorTurno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaOtPorTurno.EnableHeadersVisualStyles = False
        Me.grillaOtPorTurno.Location = New System.Drawing.Point(3, 19)
        Me.grillaOtPorTurno.Name = "grillaOtPorTurno"
        Me.grillaOtPorTurno.ReadOnly = True
        Me.grillaOtPorTurno.RowHeadersVisible = False
        Me.grillaOtPorTurno.Size = New System.Drawing.Size(226, 454)
        Me.grillaOtPorTurno.TabIndex = 0
        '
        'grpTotales
        '
        Me.grpTotales.Controls.Add(Me.grillaTotalesPeriodo)
        Me.grpTotales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpTotales.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTotales.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpTotales.Location = New System.Drawing.Point(509, 3)
        Me.grpTotales.Name = "grpTotales"
        Me.grpTotales.Size = New System.Drawing.Size(233, 476)
        Me.grpTotales.TabIndex = 2
        Me.grpTotales.TabStop = False
        Me.grpTotales.Text = "Totales por Estado del Período"
        '
        'grillaTotalesPeriodo
        '
        Me.grillaTotalesPeriodo.AllowUserToAddRows = False
        Me.grillaTotalesPeriodo.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaTotalesPeriodo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.grillaTotalesPeriodo.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaTotalesPeriodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaTotalesPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaTotalesPeriodo.EnableHeadersVisualStyles = False
        Me.grillaTotalesPeriodo.Location = New System.Drawing.Point(3, 19)
        Me.grillaTotalesPeriodo.Name = "grillaTotalesPeriodo"
        Me.grillaTotalesPeriodo.ReadOnly = True
        Me.grillaTotalesPeriodo.RowHeadersVisible = False
        Me.grillaTotalesPeriodo.Size = New System.Drawing.Size(227, 454)
        Me.grillaTotalesPeriodo.TabIndex = 0
        '
        'tabTemporal
        '
        Me.tabTemporal.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.tabTemporal.Controls.Add(Me.tblTemporal)
        Me.tabTemporal.Location = New System.Drawing.Point(4, 24)
        Me.tabTemporal.Name = "tabTemporal"
        Me.tabTemporal.Padding = New System.Windows.Forms.Padding(6)
        Me.tabTemporal.Size = New System.Drawing.Size(757, 494)
        Me.tabTemporal.TabIndex = 3
        Me.tabTemporal.Text = "  Tendencia por Día y Mes  "
        '
        'tblTemporal
        '
        Me.tblTemporal.ColumnCount = 2
        Me.tblTemporal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblTemporal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblTemporal.Controls.Add(Me.grpDia, 0, 0)
        Me.tblTemporal.Controls.Add(Me.grpMes, 1, 0)
        Me.tblTemporal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTemporal.Location = New System.Drawing.Point(6, 6)
        Me.tblTemporal.Name = "tblTemporal"
        Me.tblTemporal.RowCount = 1
        Me.tblTemporal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblTemporal.Size = New System.Drawing.Size(745, 482)
        Me.tblTemporal.TabIndex = 0
        '
        'grpDia
        '
        Me.grpDia.Controls.Add(Me.grillaOtPorDia)
        Me.grpDia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDia.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDia.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpDia.Location = New System.Drawing.Point(3, 3)
        Me.grpDia.Name = "grpDia"
        Me.grpDia.Size = New System.Drawing.Size(366, 476)
        Me.grpDia.TabIndex = 0
        Me.grpDia.TabStop = False
        Me.grpDia.Text = "Órdenes Recibidas por Día"
        '
        'grillaOtPorDia
        '
        Me.grillaOtPorDia.AllowUserToAddRows = False
        Me.grillaOtPorDia.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaOtPorDia.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.grillaOtPorDia.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaOtPorDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaOtPorDia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaOtPorDia.EnableHeadersVisualStyles = False
        Me.grillaOtPorDia.Location = New System.Drawing.Point(3, 19)
        Me.grillaOtPorDia.Name = "grillaOtPorDia"
        Me.grillaOtPorDia.ReadOnly = True
        Me.grillaOtPorDia.RowHeadersVisible = False
        Me.grillaOtPorDia.Size = New System.Drawing.Size(360, 454)
        Me.grillaOtPorDia.TabIndex = 0
        '
        'grpMes
        '
        Me.grpMes.Controls.Add(Me.grillaOtPorMes)
        Me.grpMes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpMes.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMes.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpMes.Location = New System.Drawing.Point(375, 3)
        Me.grpMes.Name = "grpMes"
        Me.grpMes.Size = New System.Drawing.Size(367, 476)
        Me.grpMes.TabIndex = 1
        Me.grpMes.TabStop = False
        Me.grpMes.Text = "Órdenes Desglosadas por Mes"
        '
        'grillaOtPorMes
        '
        Me.grillaOtPorMes.AllowUserToAddRows = False
        Me.grillaOtPorMes.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaOtPorMes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.grillaOtPorMes.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaOtPorMes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaOtPorMes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaOtPorMes.EnableHeadersVisualStyles = False
        Me.grillaOtPorMes.Location = New System.Drawing.Point(3, 19)
        Me.grillaOtPorMes.Name = "grillaOtPorMes"
        Me.grillaOtPorMes.ReadOnly = True
        Me.grillaOtPorMes.RowHeadersVisible = False
        Me.grillaOtPorMes.Size = New System.Drawing.Size(361, 454)
        Me.grillaOtPorMes.TabIndex = 0
        '
        'Labels invisibles para mantener compatibilidad
        '
        Me.Label3.Visible = False
        Me.Label4.Visible = False
        Me.Label5.Visible = False
        Me.Label6.Visible = False
        Me.Label7.Visible = False
        Me.Label8.Visible = False
        '
        'FrmResumenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(1020, 680)
        Me.ControlBox = False
        Me.Controls.Add(Me.tabResumenes)
        Me.Controls.Add(Me.pnlKpis)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.grpDesglose)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.arbol7)
        Me.Controls.Add(Me.txtBuscarNodo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Name = "FrmResumenes"
        Me.ShowIcon = False
        Me.Text = "Informe Estadístico - Gestión de Órdenes de Trabajo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpDesglose.ResumeLayout(False)
        Me.grpDesglose.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlKpis.ResumeLayout(False)
        Me.tblKpis.ResumeLayout(False)
        Me.pnlCard1.ResumeLayout(False)
        Me.pnlCard2.ResumeLayout(False)
        Me.pnlCard3.ResumeLayout(False)
        Me.pnlCard4.ResumeLayout(False)
        Me.pnlCard5.ResumeLayout(False)
        Me.pnlCard6.ResumeLayout(False)
        Me.tabResumenes.ResumeLayout(False)
        Me.tabTopEquipos.ResumeLayout(False)
        Me.tblEquipos.ResumeLayout(False)
        Me.grpTopMaquinas.ResumeLayout(False)
        CType(Me.grillaTopMaquinas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTopComponentes.ResumeLayout(False)
        CType(Me.grillaTopComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPersonal.ResumeLayout(False)
        Me.tblPersonal.ResumeLayout(False)
        Me.grpCerradaPorTec.ResumeLayout(False)
        CType(Me.grillaOtCerradaPorTec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpRecibidaPor.ResumeLayout(False)
        CType(Me.grillaOtRecibidaPor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabOperacional.ResumeLayout(False)
        Me.tblOperacional.ResumeLayout(False)
        Me.grpTipoFalla.ResumeLayout(False)
        CType(Me.grillaOtPorTipoFalla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTurno.ResumeLayout(False)
        CType(Me.grillaOtPorTurno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTotales.ResumeLayout(False)
        CType(Me.grillaTotalesPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTemporal.ResumeLayout(False)
        Me.tblTemporal.ResumeLayout(False)
        Me.grpDia.ResumeLayout(False)
        CType(Me.grillaOtPorDia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMes.ResumeLayout(False)
        CType(Me.grillaOtPorMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtBuscarNodo As System.Windows.Forms.TextBox
    Friend WithEvents arbol7 As System.Windows.Forms.TreeView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fecha_ini_resumen As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecha_fin_resumen As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grpDesglose As System.Windows.Forms.Panel
    Friend WithEvents opc_totales_estado As System.Windows.Forms.RadioButton
    Friend WithEvents opc_por_mes As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnBuscarRes As System.Windows.Forms.Button
    Friend WithEvents btn_exp_excel_res As System.Windows.Forms.Button
    Friend WithEvents btn_exp_pdf_res As System.Windows.Forms.Button
    Friend WithEvents btnSalirRes As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label

    ' KPIs
    Friend WithEvents pnlKpis As System.Windows.Forms.Panel
    Friend WithEvents tblKpis As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlCard1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitKpi1 As System.Windows.Forms.Label
    Friend WithEvents lblKpiTotal As System.Windows.Forms.Label
    Friend WithEvents pnlCard2 As System.Windows.Forms.Panel
    Friend WithEvents lblTitKpi2 As System.Windows.Forms.Label
    Friend WithEvents lblKpiCerradas As System.Windows.Forms.Label
    Friend WithEvents pnlCard3 As System.Windows.Forms.Panel
    Friend WithEvents lblTitKpi3 As System.Windows.Forms.Label
    Friend WithEvents lblKpiAbiertas As System.Windows.Forms.Label
    Friend WithEvents pnlCard4 As System.Windows.Forms.Panel
    Friend WithEvents lblTitKpi4 As System.Windows.Forms.Label
    Friend WithEvents lblKpiTopMaquina As System.Windows.Forms.Label
    Friend WithEvents pnlCard5 As System.Windows.Forms.Panel
    Friend WithEvents lblTitKpi5 As System.Windows.Forms.Label
    Friend WithEvents lblKpiTopComponente As System.Windows.Forms.Label
    Friend WithEvents pnlCard6 As System.Windows.Forms.Panel
    Friend WithEvents lblTitKpi6 As System.Windows.Forms.Label
    Friend WithEvents lblKpiTopTecnico As System.Windows.Forms.Label

    ' TabControl
    Friend WithEvents tabResumenes As System.Windows.Forms.TabControl
    Friend WithEvents tabTopEquipos As System.Windows.Forms.TabPage
    Friend WithEvents tblEquipos As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpTopMaquinas As System.Windows.Forms.GroupBox
    Friend WithEvents grillaTopMaquinas As System.Windows.Forms.DataGridView
    Friend WithEvents grpTopComponentes As System.Windows.Forms.GroupBox
    Friend WithEvents grillaTopComponentes As System.Windows.Forms.DataGridView

    Friend WithEvents tabPersonal As System.Windows.Forms.TabPage
    Friend WithEvents tblPersonal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpCerradaPorTec As System.Windows.Forms.GroupBox
    Friend WithEvents grillaOtCerradaPorTec As System.Windows.Forms.DataGridView
    Friend WithEvents grpRecibidaPor As System.Windows.Forms.GroupBox
    Friend WithEvents grillaOtRecibidaPor As System.Windows.Forms.DataGridView

    Friend WithEvents tabOperacional As System.Windows.Forms.TabPage
    Friend WithEvents tblOperacional As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpTipoFalla As System.Windows.Forms.GroupBox
    Friend WithEvents grillaOtPorTipoFalla As System.Windows.Forms.DataGridView
    Friend WithEvents grpTurno As System.Windows.Forms.GroupBox
    Friend WithEvents grillaOtPorTurno As System.Windows.Forms.DataGridView
    Friend WithEvents grpTotales As System.Windows.Forms.GroupBox
    Friend WithEvents grillaTotalesPeriodo As System.Windows.Forms.DataGridView

    Friend WithEvents tabTemporal As System.Windows.Forms.TabPage
    Friend WithEvents tblTemporal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpDia As System.Windows.Forms.GroupBox
    Friend WithEvents grillaOtPorDia As System.Windows.Forms.DataGridView
    Friend WithEvents grpMes As System.Windows.Forms.GroupBox
    Friend WithEvents grillaOtPorMes As System.Windows.Forms.DataGridView

    ' Labels de compatibilidad
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
