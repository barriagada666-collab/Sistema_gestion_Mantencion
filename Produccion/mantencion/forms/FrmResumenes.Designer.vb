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

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grillaOtRecibidaPor = New System.Windows.Forms.DataGridView
        Me.grillaOtCerradaPorTec = New System.Windows.Forms.DataGridView
        Me.grillaOtPorDia = New System.Windows.Forms.DataGridView
        Me.grillaOtPorMes = New System.Windows.Forms.DataGridView
        Me.grillaOtPorTurno = New System.Windows.Forms.DataGridView
        Me.fecha_ini_resumen = New System.Windows.Forms.DateTimePicker
        Me.fecha_fin_resumen = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.arbol7 = New System.Windows.Forms.TreeView
        Me.grillaOtPorTipoFalla = New System.Windows.Forms.DataGridView
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btn_exp_excel_res = New System.Windows.Forms.Button
        Me.btnBuscarRes = New System.Windows.Forms.Button
        Me.btnSalirRes = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtBuscarNodo = New System.Windows.Forms.TextBox
        Me.grillaTotalesPeriodo = New System.Windows.Forms.DataGridView
        Me.opc_por_mes = New System.Windows.Forms.RadioButton
        Me.grpDesglose = New System.Windows.Forms.Panel
        Me.opc_totales_estado = New System.Windows.Forms.RadioButton
        CType(Me.grillaOtRecibidaPor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grillaOtCerradaPorTec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grillaOtPorDia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grillaOtPorMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grillaOtPorTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grillaOtPorTipoFalla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grillaTotalesPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDesglose.SuspendLayout()
        Me.SuspendLayout()
        '
        'grillaOtRecibidaPor
        '
        Me.grillaOtRecibidaPor.AllowUserToAddRows = False
        Me.grillaOtRecibidaPor.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grillaOtRecibidaPor.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grillaOtRecibidaPor.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaOtRecibidaPor.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grillaOtRecibidaPor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaOtRecibidaPor.EnableHeadersVisualStyles = False
        Me.grillaOtRecibidaPor.Location = New System.Drawing.Point(278, 117)
        Me.grillaOtRecibidaPor.Name = "grillaOtRecibidaPor"
        Me.grillaOtRecibidaPor.ReadOnly = True
        Me.grillaOtRecibidaPor.RowHeadersVisible = False
        Me.grillaOtRecibidaPor.Size = New System.Drawing.Size(170, 250)
        Me.grillaOtRecibidaPor.TabIndex = 0
        '
        'grillaOtCerradaPorTec
        '
        Me.grillaOtCerradaPorTec.AllowUserToAddRows = False
        Me.grillaOtCerradaPorTec.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grillaOtCerradaPorTec.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grillaOtCerradaPorTec.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaOtCerradaPorTec.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grillaOtCerradaPorTec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaOtCerradaPorTec.EnableHeadersVisualStyles = False
        Me.grillaOtCerradaPorTec.Location = New System.Drawing.Point(465, 117)
        Me.grillaOtCerradaPorTec.Name = "grillaOtCerradaPorTec"
        Me.grillaOtCerradaPorTec.ReadOnly = True
        Me.grillaOtCerradaPorTec.RowHeadersVisible = False
        Me.grillaOtCerradaPorTec.Size = New System.Drawing.Size(170, 250)
        Me.grillaOtCerradaPorTec.TabIndex = 1
        '
        'grillaOtPorDia
        '
        Me.grillaOtPorDia.AllowUserToAddRows = False
        Me.grillaOtPorDia.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grillaOtPorDia.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.grillaOtPorDia.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaOtPorDia.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grillaOtPorDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaOtPorDia.EnableHeadersVisualStyles = False
        Me.grillaOtPorDia.Location = New System.Drawing.Point(465, 399)
        Me.grillaOtPorDia.Name = "grillaOtPorDia"
        Me.grillaOtPorDia.ReadOnly = True
        Me.grillaOtPorDia.RowHeadersVisible = False
        Me.grillaOtPorDia.Size = New System.Drawing.Size(170, 250)
        Me.grillaOtPorDia.TabIndex = 2
        '
        'grillaOtPorMes
        '
        Me.grillaOtPorMes.AllowUserToAddRows = False
        Me.grillaOtPorMes.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grillaOtPorMes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.grillaOtPorMes.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaOtPorMes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.grillaOtPorMes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaOtPorMes.EnableHeadersVisualStyles = False
        Me.grillaOtPorMes.Location = New System.Drawing.Point(651, 399)
        Me.grillaOtPorMes.Name = "grillaOtPorMes"
        Me.grillaOtPorMes.ReadOnly = True
        Me.grillaOtPorMes.RowHeadersVisible = False
        Me.grillaOtPorMes.Size = New System.Drawing.Size(170, 250)
        Me.grillaOtPorMes.TabIndex = 3
        '
        'grillaOtPorTurno
        '
        Me.grillaOtPorTurno.AllowUserToAddRows = False
        Me.grillaOtPorTurno.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grillaOtPorTurno.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.grillaOtPorTurno.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaOtPorTurno.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.grillaOtPorTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaOtPorTurno.EnableHeadersVisualStyles = False
        Me.grillaOtPorTurno.Location = New System.Drawing.Point(278, 399)
        Me.grillaOtPorTurno.Name = "grillaOtPorTurno"
        Me.grillaOtPorTurno.ReadOnly = True
        Me.grillaOtPorTurno.RowHeadersVisible = False
        Me.grillaOtPorTurno.Size = New System.Drawing.Size(170, 110)
        Me.grillaOtPorTurno.TabIndex = 4
        '
        'fecha_ini_resumen
        '
        Me.fecha_ini_resumen.CalendarTitleBackColor = System.Drawing.Color.Green
        Me.fecha_ini_resumen.CalendarTrailingForeColor = System.Drawing.Color.White
        Me.fecha_ini_resumen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_ini_resumen.Location = New System.Drawing.Point(5, 29)
        Me.fecha_ini_resumen.Name = "fecha_ini_resumen"
        Me.fecha_ini_resumen.Size = New System.Drawing.Size(84, 20)
        Me.fecha_ini_resumen.TabIndex = 5
        '
        'fecha_fin_resumen
        '
        Me.fecha_fin_resumen.CalendarTitleBackColor = System.Drawing.Color.Green
        Me.fecha_fin_resumen.CalendarTrailingForeColor = System.Drawing.Color.White
        Me.fecha_fin_resumen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_fin_resumen.Location = New System.Drawing.Point(107, 29)
        Me.fecha_fin_resumen.Name = "fecha_fin_resumen"
        Me.fecha_fin_resumen.Size = New System.Drawing.Size(84, 20)
        Me.fecha_fin_resumen.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Fecha Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(104, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Fecha Hasta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(275, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "OT Recibidas Pendientes  "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(462, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "OT Ejecutadas Por Técnico"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(462, 383)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "OT Recibidas Por Día"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(651, 371)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(170, 27)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "OT Totales"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(275, 383)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 15)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "OT Recibidas Por Turno"
        '
        'arbol7
        '
        Me.arbol7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.arbol7.Location = New System.Drawing.Point(12, 39)
        Me.arbol7.Name = "arbol7"
        Me.arbol7.Size = New System.Drawing.Size(220, 610)
        Me.arbol7.TabIndex = 16
        '
        'grillaOtPorTipoFalla
        '
        Me.grillaOtPorTipoFalla.AllowUserToAddRows = False
        Me.grillaOtPorTipoFalla.AllowUserToDeleteRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grillaOtPorTipoFalla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.grillaOtPorTipoFalla.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaOtPorTipoFalla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.grillaOtPorTipoFalla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaOtPorTipoFalla.EnableHeadersVisualStyles = False
        Me.grillaOtPorTipoFalla.Location = New System.Drawing.Point(651, 117)
        Me.grillaOtPorTipoFalla.Name = "grillaOtPorTipoFalla"
        Me.grillaOtPorTipoFalla.ReadOnly = True
        Me.grillaOtPorTipoFalla.RowHeadersVisible = False
        Me.grillaOtPorTipoFalla.Size = New System.Drawing.Size(190, 180)
        Me.grillaOtPorTipoFalla.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(651, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 15)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "OT Por Tipo de Trabajo"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.fecha_ini_resumen)
        Me.Panel1.Controls.Add(Me.fecha_fin_resumen)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(278, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(205, 60)
        Me.Panel1.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(283, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 15)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Rango de Fechas"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btn_exp_excel_res)
        Me.Panel2.Controls.Add(Me.btnBuscarRes)
        Me.Panel2.Controls.Add(Me.btnSalirRes)
        Me.Panel2.Location = New System.Drawing.Point(728, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(125, 50)
        Me.Panel2.TabIndex = 21
        '
        'btn_exp_excel_res
        '
        Me.btn_exp_excel_res.Image = Global.Mantencion.My.Resources.Resources.icono_excel1
        Me.btn_exp_excel_res.Location = New System.Drawing.Point(48, 14)
        Me.btn_exp_excel_res.Name = "btn_exp_excel_res"
        Me.btn_exp_excel_res.Size = New System.Drawing.Size(29, 29)
        Me.btn_exp_excel_res.TabIndex = 16
        Me.btn_exp_excel_res.UseVisualStyleBackColor = True
        '
        'btnBuscarRes
        '
        Me.btnBuscarRes.BackgroundImage = Global.Mantencion.My.Resources.Resources.icono_buscar1
        Me.btnBuscarRes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscarRes.Location = New System.Drawing.Point(13, 14)
        Me.btnBuscarRes.Name = "btnBuscarRes"
        Me.btnBuscarRes.Size = New System.Drawing.Size(29, 29)
        Me.btnBuscarRes.TabIndex = 14
        Me.btnBuscarRes.UseVisualStyleBackColor = True
        '
        'btnSalirRes
        '
        Me.btnSalirRes.BackgroundImage = Global.Mantencion.My.Resources.Resources.salir
        Me.btnSalirRes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalirRes.Location = New System.Drawing.Point(83, 14)
        Me.btnSalirRes.Name = "btnSalirRes"
        Me.btnSalirRes.Size = New System.Drawing.Size(29, 29)
        Me.btnSalirRes.TabIndex = 15
        Me.btnSalirRes.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(733, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 15)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Operaciones"
        '
        'txtBuscarNodo
        '
        Me.txtBuscarNodo.Location = New System.Drawing.Point(12, 12)
        Me.txtBuscarNodo.Name = "txtBuscarNodo"
        Me.txtBuscarNodo.Size = New System.Drawing.Size(220, 20)
        Me.txtBuscarNodo.TabIndex = 23
        '
        'grillaTotalesPeriodo
        '
        Me.grillaTotalesPeriodo.AllowUserToAddRows = False
        Me.grillaTotalesPeriodo.AllowUserToDeleteRows = False
        Me.grillaTotalesPeriodo.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaTotalesPeriodo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.grillaTotalesPeriodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaTotalesPeriodo.EnableHeadersVisualStyles = False
        Me.grillaTotalesPeriodo.Location = New System.Drawing.Point(651, 399)
        Me.grillaTotalesPeriodo.Name = "grillaTotalesPeriodo"
        Me.grillaTotalesPeriodo.ReadOnly = True
        Me.grillaTotalesPeriodo.RowHeadersVisible = False
        Me.grillaTotalesPeriodo.Size = New System.Drawing.Size(170, 217)
        Me.grillaTotalesPeriodo.TabIndex = 24
        '
        'opc_por_mes
        '
        Me.opc_por_mes.AutoSize = True
        Me.opc_por_mes.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opc_por_mes.Location = New System.Drawing.Point(3, 14)
        Me.opc_por_mes.Name = "opc_por_mes"
        Me.opc_por_mes.Size = New System.Drawing.Size(119, 19)
        Me.opc_por_mes.TabIndex = 25
        Me.opc_por_mes.TabStop = True
        Me.opc_por_mes.Text = "Desglose Por Mes"
        Me.opc_por_mes.UseVisualStyleBackColor = True
        '
        'grpDesglose
        '
        Me.grpDesglose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grpDesglose.Controls.Add(Me.opc_totales_estado)
        Me.grpDesglose.Controls.Add(Me.opc_por_mes)
        Me.grpDesglose.Location = New System.Drawing.Point(489, 25)
        Me.grpDesglose.Name = "grpDesglose"
        Me.grpDesglose.Size = New System.Drawing.Size(146, 60)
        Me.grpDesglose.TabIndex = 26
        '
        'opc_totales_estado
        '
        Me.opc_totales_estado.AutoSize = True
        Me.opc_totales_estado.Checked = True
        Me.opc_totales_estado.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opc_totales_estado.Location = New System.Drawing.Point(4, 38)
        Me.opc_totales_estado.Name = "opc_totales_estado"
        Me.opc_totales_estado.Size = New System.Drawing.Size(132, 19)
        Me.opc_totales_estado.TabIndex = 26
        Me.opc_totales_estado.TabStop = True
        Me.opc_totales_estado.Text = "Totales Del Periodo "
        Me.opc_totales_estado.UseVisualStyleBackColor = True
        '
        'FrmResumenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1020, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpDesglose)
        Me.Controls.Add(Me.grillaTotalesPeriodo)
        Me.Controls.Add(Me.txtBuscarNodo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.grillaOtPorTipoFalla)
        Me.Controls.Add(Me.arbol7)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grillaOtPorTurno)
        Me.Controls.Add(Me.grillaOtPorMes)
        Me.Controls.Add(Me.grillaOtPorDia)
        Me.Controls.Add(Me.grillaOtCerradaPorTec)
        Me.Controls.Add(Me.grillaOtRecibidaPor)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "FrmResumenes"
        Me.ShowIcon = False
        Me.Text = "Informe Estadístico Ordenes de Trabajo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grillaOtRecibidaPor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grillaOtCerradaPorTec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grillaOtPorDia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grillaOtPorMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grillaOtPorTurno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grillaOtPorTipoFalla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grillaTotalesPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDesglose.ResumeLayout(False)
        Me.grpDesglose.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grillaOtRecibidaPor As System.Windows.Forms.DataGridView
    Friend WithEvents grillaOtCerradaPorTec As System.Windows.Forms.DataGridView
    Friend WithEvents grillaOtPorDia As System.Windows.Forms.DataGridView
    Friend WithEvents grillaOtPorMes As System.Windows.Forms.DataGridView
    Friend WithEvents grillaOtPorTurno As System.Windows.Forms.DataGridView
    Friend WithEvents fecha_ini_resumen As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecha_fin_resumen As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarRes As System.Windows.Forms.Button
    Friend WithEvents btnSalirRes As System.Windows.Forms.Button
    Friend WithEvents arbol7 As System.Windows.Forms.TreeView
    Friend WithEvents grillaOtPorTipoFalla As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBuscarNodo As System.Windows.Forms.TextBox
    Friend WithEvents btn_exp_excel_res As System.Windows.Forms.Button
    Friend WithEvents grillaTotalesPeriodo As System.Windows.Forms.DataGridView
    Friend WithEvents opc_por_mes As System.Windows.Forms.RadioButton
    Friend WithEvents grpDesglose As System.Windows.Forms.Panel
    Friend WithEvents opc_totales_estado As System.Windows.Forms.RadioButton
End Class
