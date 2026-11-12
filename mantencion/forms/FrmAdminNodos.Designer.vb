<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdminNodos
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
        Me.arbol4 = New System.Windows.Forms.TreeView
        Me.GrpInfoNuevoNodo = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbGrupoNodo = New System.Windows.Forms.ComboBox
        Me.grpAplicaMant = New System.Windows.Forms.GroupBox
        Me.opcAplicaMantNo = New System.Windows.Forms.RadioButton
        Me.opcAplicaMantSi = New System.Windows.Forms.RadioButton
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtCodSap = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPrioridad = New System.Windows.Forms.TextBox
        Me.fecha_instalacion = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCodRmesNodoNuevo = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.opcNuevoNodoDesac = New System.Windows.Forms.RadioButton
        Me.opcNuevoNodoAct = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDescNuevoNodo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtIDNuevoNodo = New System.Windows.Forms.TextBox
        Me.GrpNodoPadre = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbGrupoNodo2 = New System.Windows.Forms.ComboBox
        Me.grpAplicaMant2 = New System.Windows.Forms.GroupBox
        Me.opcAplicaMantNo2 = New System.Windows.Forms.RadioButton
        Me.opcAplicaMantSi2 = New System.Windows.Forms.RadioButton
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtCodSap2 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtPrioridad2 = New System.Windows.Forms.TextBox
        Me.fecha_instalacion2 = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCodRmes = New System.Windows.Forms.TextBox
        Me.chkModPadre = New System.Windows.Forms.CheckBox
        Me.btnNuevoNodo = New System.Windows.Forms.Button
        Me.GrpEstadoNodo = New System.Windows.Forms.GroupBox
        Me.opcDesactivado = New System.Windows.Forms.RadioButton
        Me.opcActivado = New System.Windows.Forms.RadioButton
        Me.txtDescNodoSel = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtIDNodoSel = New System.Windows.Forms.TextBox
        Me.GrpOperNodos = New System.Windows.Forms.GroupBox
        Me.txtBuscarNodoNd = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnDatosTecnicos = New System.Windows.Forms.Button
        Me.btnLimpiarNodo = New System.Windows.Forms.Button
        Me.btnSalirNodos = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.GrpInfoNuevoNodo.SuspendLayout()
        Me.grpAplicaMant.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GrpNodoPadre.SuspendLayout()
        Me.grpAplicaMant2.SuspendLayout()
        Me.GrpEstadoNodo.SuspendLayout()
        Me.GrpOperNodos.SuspendLayout()
        Me.SuspendLayout()
        '
        'arbol4
        '
        Me.arbol4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.arbol4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.arbol4.Location = New System.Drawing.Point(12, 29)
        Me.arbol4.Name = "arbol4"
        Me.arbol4.Size = New System.Drawing.Size(221, 620)
        Me.arbol4.TabIndex = 0
        '
        'GrpInfoNuevoNodo
        '
        Me.GrpInfoNuevoNodo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpInfoNuevoNodo.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.Label9)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.cmbGrupoNodo)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.grpAplicaMant)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.Label16)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.txtCodSap)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.Label10)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.txtPrioridad)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.fecha_instalacion)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.Label7)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.Label6)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.txtCodRmesNodoNuevo)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.GroupBox1)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.Label2)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.txtDescNuevoNodo)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.Label1)
        Me.GrpInfoNuevoNodo.Controls.Add(Me.txtIDNuevoNodo)
        Me.GrpInfoNuevoNodo.Location = New System.Drawing.Point(257, 225)
        Me.GrpInfoNuevoNodo.Name = "GrpInfoNuevoNodo"
        Me.GrpInfoNuevoNodo.Size = New System.Drawing.Size(751, 144)
        Me.GrpInfoNuevoNodo.TabIndex = 1
        Me.GrpInfoNuevoNodo.TabStop = False
        Me.GrpInfoNuevoNodo.Text = "Información Nodo Hijo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(393, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 15)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Grupo"
        '
        'cmbGrupoNodo
        '
        Me.cmbGrupoNodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupoNodo.FormattingEnabled = True
        Me.cmbGrupoNodo.Items.AddRange(New Object() {"Planta", "Seccion", "Maquina", "Modulo", "Item", "Otros"})
        Me.cmbGrupoNodo.Location = New System.Drawing.Point(394, 95)
        Me.cmbGrupoNodo.Name = "cmbGrupoNodo"
        Me.cmbGrupoNodo.Size = New System.Drawing.Size(151, 21)
        Me.cmbGrupoNodo.TabIndex = 20
        '
        'grpAplicaMant
        '
        Me.grpAplicaMant.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAplicaMant.Controls.Add(Me.opcAplicaMantNo)
        Me.grpAplicaMant.Controls.Add(Me.opcAplicaMantSi)
        Me.grpAplicaMant.Location = New System.Drawing.Point(590, 72)
        Me.grpAplicaMant.Name = "grpAplicaMant"
        Me.grpAplicaMant.Size = New System.Drawing.Size(155, 45)
        Me.grpAplicaMant.TabIndex = 19
        Me.grpAplicaMant.TabStop = False
        Me.grpAplicaMant.Text = "Aplica Mant.Preventiva"
        '
        'opcAplicaMantNo
        '
        Me.opcAplicaMantNo.AutoSize = True
        Me.opcAplicaMantNo.Location = New System.Drawing.Point(64, 20)
        Me.opcAplicaMantNo.Name = "opcAplicaMantNo"
        Me.opcAplicaMantNo.Size = New System.Drawing.Size(39, 17)
        Me.opcAplicaMantNo.TabIndex = 1
        Me.opcAplicaMantNo.TabStop = True
        Me.opcAplicaMantNo.Text = "No"
        Me.opcAplicaMantNo.UseVisualStyleBackColor = True
        '
        'opcAplicaMantSi
        '
        Me.opcAplicaMantSi.AutoSize = True
        Me.opcAplicaMantSi.Checked = True
        Me.opcAplicaMantSi.Location = New System.Drawing.Point(7, 20)
        Me.opcAplicaMantSi.Name = "opcAplicaMantSi"
        Me.opcAplicaMantSi.Size = New System.Drawing.Size(36, 17)
        Me.opcAplicaMantSi.TabIndex = 0
        Me.opcAplicaMantSi.TabStop = True
        Me.opcAplicaMantSi.Text = "Sí"
        Me.opcAplicaMantSi.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 79)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 15)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Código SAP"
        '
        'txtCodSap
        '
        Me.txtCodSap.Location = New System.Drawing.Point(6, 96)
        Me.txtCodSap.Name = "txtCodSap"
        Me.txtCodSap.Size = New System.Drawing.Size(155, 20)
        Me.txtCodSap.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(294, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 15)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Prioridad"
        '
        'txtPrioridad
        '
        Me.txtPrioridad.Location = New System.Drawing.Point(297, 96)
        Me.txtPrioridad.Name = "txtPrioridad"
        Me.txtPrioridad.Size = New System.Drawing.Size(63, 20)
        Me.txtPrioridad.TabIndex = 13
        Me.txtPrioridad.Text = "0"
        '
        'fecha_instalacion
        '
        Me.fecha_instalacion.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_instalacion.CalendarTitleForeColor = System.Drawing.Color.White
        Me.fecha_instalacion.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_instalacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_instalacion.Location = New System.Drawing.Point(178, 96)
        Me.fecha_instalacion.Name = "fecha_instalacion"
        Me.fecha_instalacion.Size = New System.Drawing.Size(86, 20)
        Me.fecha_instalacion.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(175, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 15)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Fecha Instalación"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(391, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Código RMES"
        '
        'txtCodRmesNodoNuevo
        '
        Me.txtCodRmesNodoNuevo.Location = New System.Drawing.Point(394, 42)
        Me.txtCodRmesNodoNuevo.MaxLength = 20
        Me.txtCodRmesNodoNuevo.Name = "txtCodRmesNodoNuevo"
        Me.txtCodRmesNodoNuevo.Size = New System.Drawing.Size(167, 20)
        Me.txtCodRmesNodoNuevo.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.opcNuevoNodoDesac)
        Me.GroupBox1.Controls.Add(Me.opcNuevoNodoAct)
        Me.GroupBox1.Location = New System.Drawing.Point(590, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(155, 43)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado Nodo Hijo"
        '
        'opcNuevoNodoDesac
        '
        Me.opcNuevoNodoDesac.AutoSize = True
        Me.opcNuevoNodoDesac.Location = New System.Drawing.Point(64, 20)
        Me.opcNuevoNodoDesac.Name = "opcNuevoNodoDesac"
        Me.opcNuevoNodoDesac.Size = New System.Drawing.Size(85, 17)
        Me.opcNuevoNodoDesac.TabIndex = 1
        Me.opcNuevoNodoDesac.Text = "Desactivado"
        Me.opcNuevoNodoDesac.UseVisualStyleBackColor = True
        '
        'opcNuevoNodoAct
        '
        Me.opcNuevoNodoAct.AutoSize = True
        Me.opcNuevoNodoAct.Checked = True
        Me.opcNuevoNodoAct.Location = New System.Drawing.Point(7, 20)
        Me.opcNuevoNodoAct.Name = "opcNuevoNodoAct"
        Me.opcNuevoNodoAct.Size = New System.Drawing.Size(55, 17)
        Me.opcNuevoNodoAct.TabIndex = 0
        Me.opcNuevoNodoAct.TabStop = True
        Me.opcNuevoNodoAct.Text = "Activo"
        Me.opcNuevoNodoAct.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripción Nodo"
        '
        'txtDescNuevoNodo
        '
        Me.txtDescNuevoNodo.Location = New System.Drawing.Point(88, 42)
        Me.txtDescNuevoNodo.MaxLength = 50
        Me.txtDescNuevoNodo.Name = "txtDescNuevoNodo"
        Me.txtDescNuevoNodo.Size = New System.Drawing.Size(274, 20)
        Me.txtDescNuevoNodo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ID Nodo"
        '
        'txtIDNuevoNodo
        '
        Me.txtIDNuevoNodo.BackColor = System.Drawing.Color.FromArgb(215, 230, 234)
        Me.txtIDNuevoNodo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.txtIDNuevoNodo.ReadOnly = True
        Me.txtIDNuevoNodo.Location = New System.Drawing.Point(9, 42)
        Me.txtIDNuevoNodo.Name = "txtIDNuevoNodo"
        Me.txtIDNuevoNodo.Size = New System.Drawing.Size(62, 20)
        Me.txtIDNuevoNodo.TabIndex = 0
        '
        'GrpNodoPadre
        '
        Me.GrpNodoPadre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpNodoPadre.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.GrpNodoPadre.Controls.Add(Me.btnDatosTecnicos)
        Me.GrpNodoPadre.Controls.Add(Me.Label8)
        Me.GrpNodoPadre.Controls.Add(Me.cmbGrupoNodo2)
        Me.GrpNodoPadre.Controls.Add(Me.grpAplicaMant2)
        Me.GrpNodoPadre.Controls.Add(Me.Label15)
        Me.GrpNodoPadre.Controls.Add(Me.txtCodSap2)
        Me.GrpNodoPadre.Controls.Add(Me.Label14)
        Me.GrpNodoPadre.Controls.Add(Me.Label13)
        Me.GrpNodoPadre.Controls.Add(Me.txtPrioridad2)
        Me.GrpNodoPadre.Controls.Add(Me.fecha_instalacion2)
        Me.GrpNodoPadre.Controls.Add(Me.Label5)
        Me.GrpNodoPadre.Controls.Add(Me.txtCodRmes)
        Me.GrpNodoPadre.Controls.Add(Me.chkModPadre)
        Me.GrpNodoPadre.Controls.Add(Me.btnNuevoNodo)
        Me.GrpNodoPadre.Controls.Add(Me.GrpEstadoNodo)
        Me.GrpNodoPadre.Controls.Add(Me.txtDescNodoSel)
        Me.GrpNodoPadre.Controls.Add(Me.Label4)
        Me.GrpNodoPadre.Controls.Add(Me.Label3)
        Me.GrpNodoPadre.Controls.Add(Me.txtIDNodoSel)
        Me.GrpNodoPadre.Location = New System.Drawing.Point(257, 29)
        Me.GrpNodoPadre.Name = "GrpNodoPadre"
        Me.GrpNodoPadre.Size = New System.Drawing.Size(751, 180)
        Me.GrpNodoPadre.TabIndex = 2
        Me.GrpNodoPadre.TabStop = False
        Me.GrpNodoPadre.Text = "Información Nodo Padre"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(391, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 15)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Grupo"
        '
        'cmbGrupoNodo2
        '
        Me.cmbGrupoNodo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupoNodo2.FormattingEnabled = True
        Me.cmbGrupoNodo2.Items.AddRange(New Object() {"Planta", "Seccion", "Maquina", "Modulo", "Item", "Otros"})
        Me.cmbGrupoNodo2.Location = New System.Drawing.Point(394, 103)
        Me.cmbGrupoNodo2.Name = "cmbGrupoNodo2"
        Me.cmbGrupoNodo2.Size = New System.Drawing.Size(151, 21)
        Me.cmbGrupoNodo2.TabIndex = 22
        '
        'grpAplicaMant2
        '
        Me.grpAplicaMant2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAplicaMant2.Controls.Add(Me.opcAplicaMantNo2)
        Me.grpAplicaMant2.Controls.Add(Me.opcAplicaMantSi2)
        Me.grpAplicaMant2.Location = New System.Drawing.Point(590, 75)
        Me.grpAplicaMant2.Name = "grpAplicaMant2"
        Me.grpAplicaMant2.Size = New System.Drawing.Size(155, 49)
        Me.grpAplicaMant2.TabIndex = 21
        Me.grpAplicaMant2.TabStop = False
        Me.grpAplicaMant2.Text = "Aplica Mant.Preventiva"
        '
        'opcAplicaMantNo2
        '
        Me.opcAplicaMantNo2.AutoSize = True
        Me.opcAplicaMantNo2.Location = New System.Drawing.Point(64, 20)
        Me.opcAplicaMantNo2.Name = "opcAplicaMantNo2"
        Me.opcAplicaMantNo2.Size = New System.Drawing.Size(39, 17)
        Me.opcAplicaMantNo2.TabIndex = 1
        Me.opcAplicaMantNo2.Text = "No"
        Me.opcAplicaMantNo2.UseVisualStyleBackColor = True
        '
        'opcAplicaMantSi2
        '
        Me.opcAplicaMantSi2.AutoSize = True
        Me.opcAplicaMantSi2.Checked = True
        Me.opcAplicaMantSi2.Location = New System.Drawing.Point(7, 20)
        Me.opcAplicaMantSi2.Name = "opcAplicaMantSi2"
        Me.opcAplicaMantSi2.Size = New System.Drawing.Size(36, 17)
        Me.opcAplicaMantSi2.TabIndex = 0
        Me.opcAplicaMantSi2.TabStop = True
        Me.opcAplicaMantSi2.Text = "Sí"
        Me.opcAplicaMantSi2.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 86)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 15)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Código SAP"
        '
        'txtCodSap2
        '
        Me.txtCodSap2.Location = New System.Drawing.Point(9, 102)
        Me.txtCodSap2.Name = "txtCodSap2"
        Me.txtCodSap2.Size = New System.Drawing.Size(155, 20)
        Me.txtCodSap2.TabIndex = 17
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(184, 86)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 15)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Fecha Instalación"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(296, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 15)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Prioridad"
        '
        'txtPrioridad2
        '
        Me.txtPrioridad2.Location = New System.Drawing.Point(299, 104)
        Me.txtPrioridad2.Name = "txtPrioridad2"
        Me.txtPrioridad2.Size = New System.Drawing.Size(63, 20)
        Me.txtPrioridad2.TabIndex = 14
        Me.txtPrioridad2.Text = "0"
        '
        'fecha_instalacion2
        '
        Me.fecha_instalacion2.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_instalacion2.CalendarTitleForeColor = System.Drawing.Color.White
        Me.fecha_instalacion2.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_instalacion2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_instalacion2.Location = New System.Drawing.Point(187, 104)
        Me.fecha_instalacion2.Name = "fecha_instalacion2"
        Me.fecha_instalacion2.Size = New System.Drawing.Size(86, 20)
        Me.fecha_instalacion2.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(391, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Código RMES"
        '
        'txtCodRmes
        '
        Me.txtCodRmes.Location = New System.Drawing.Point(394, 48)
        Me.txtCodRmes.MaxLength = 20
        Me.txtCodRmes.Name = "txtCodRmes"
        Me.txtCodRmes.Size = New System.Drawing.Size(167, 20)
        Me.txtCodRmes.TabIndex = 7
        '
        'chkModPadre
        '
        Me.chkModPadre.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkModPadre.AutoSize = True
        Me.chkModPadre.Location = New System.Drawing.Point(529, 152)
        Me.chkModPadre.Name = "chkModPadre"
        Me.chkModPadre.Size = New System.Drawing.Size(122, 17)
        Me.chkModPadre.TabIndex = 5
        Me.chkModPadre.Text = "Cambiar nodo Padre"
        Me.chkModPadre.UseVisualStyleBackColor = True
        '
        'btnNuevoNodo
        '
        Me.btnNuevoNodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevoNodo.Location = New System.Drawing.Point(667, 146)
        Me.btnNuevoNodo.Name = "btnNuevoNodo"
        Me.btnNuevoNodo.Size = New System.Drawing.Size(78, 23)
        Me.btnNuevoNodo.TabIndex = 6
        Me.btnNuevoNodo.Text = "Nuevo Nodo"
        Me.btnNuevoNodo.UseVisualStyleBackColor = True
        '
        'GrpEstadoNodo
        '
        Me.GrpEstadoNodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpEstadoNodo.Controls.Add(Me.opcDesactivado)
        Me.GrpEstadoNodo.Controls.Add(Me.opcActivado)
        Me.GrpEstadoNodo.Location = New System.Drawing.Point(590, 19)
        Me.GrpEstadoNodo.Name = "GrpEstadoNodo"
        Me.GrpEstadoNodo.Size = New System.Drawing.Size(155, 49)
        Me.GrpEstadoNodo.TabIndex = 5
        Me.GrpEstadoNodo.TabStop = False
        Me.GrpEstadoNodo.Text = "Estado Nodo"
        '
        'opcDesactivado
        '
        Me.opcDesactivado.AutoSize = True
        Me.opcDesactivado.Location = New System.Drawing.Point(64, 19)
        Me.opcDesactivado.Name = "opcDesactivado"
        Me.opcDesactivado.Size = New System.Drawing.Size(85, 17)
        Me.opcDesactivado.TabIndex = 5
        Me.opcDesactivado.Text = "Desactivado"
        Me.opcDesactivado.UseVisualStyleBackColor = True
        '
        'opcActivado
        '
        Me.opcActivado.AutoSize = True
        Me.opcActivado.Checked = True
        Me.opcActivado.Location = New System.Drawing.Point(6, 19)
        Me.opcActivado.Name = "opcActivado"
        Me.opcActivado.Size = New System.Drawing.Size(55, 17)
        Me.opcActivado.TabIndex = 4
        Me.opcActivado.TabStop = True
        Me.opcActivado.Text = "Activo"
        Me.opcActivado.UseVisualStyleBackColor = True
        '
        'txtDescNodoSel
        '
        Me.txtDescNodoSel.Location = New System.Drawing.Point(88, 48)
        Me.txtDescNodoSel.MaxLength = 50
        Me.txtDescNodoSel.Name = "txtDescNodoSel"
        Me.txtDescNodoSel.Size = New System.Drawing.Size(274, 20)
        Me.txtDescNodoSel.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(85, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Descripción Nodo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "ID Nodo"
        '
        'txtIDNodoSel
        '
        Me.txtIDNodoSel.BackColor = System.Drawing.Color.FromArgb(215, 230, 234)
        Me.txtIDNodoSel.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.txtIDNodoSel.ReadOnly = True
        Me.txtIDNodoSel.Location = New System.Drawing.Point(9, 48)
        Me.txtIDNodoSel.Name = "txtIDNodoSel"
        Me.txtIDNodoSel.Size = New System.Drawing.Size(59, 20)
        Me.txtIDNodoSel.TabIndex = 0
        '
        'GrpOperNodos
        '
        Me.GrpOperNodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpOperNodos.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.GrpOperNodos.Controls.Add(Me.btnLimpiarNodo)
        Me.GrpOperNodos.Controls.Add(Me.btnSalirNodos)
        Me.GrpOperNodos.Controls.Add(Me.btnGuardar)
        Me.GrpOperNodos.Location = New System.Drawing.Point(885, 387)
        Me.GrpOperNodos.Name = "GrpOperNodos"
        Me.GrpOperNodos.Size = New System.Drawing.Size(123, 79)
        Me.GrpOperNodos.TabIndex = 3
        Me.GrpOperNodos.TabStop = False
        Me.GrpOperNodos.Text = "Operaciones"
        '
        'txtBuscarNodoNd
        '
        Me.txtBuscarNodoNd.Location = New System.Drawing.Point(13, 3)
        Me.txtBuscarNodoNd.Name = "txtBuscarNodoNd"
        Me.txtBuscarNodoNd.Size = New System.Drawing.Size(220, 20)
        Me.txtBuscarNodoNd.TabIndex = 4
        '
        'btnDatosTecnicos
        '
        Me.btnDatosTecnicos.Location = New System.Drawing.Point(9, 146)
        Me.btnDatosTecnicos.Name = "btnDatosTecnicos"
        Me.btnDatosTecnicos.Size = New System.Drawing.Size(112, 23)
        Me.btnDatosTecnicos.TabIndex = 24
        Me.btnDatosTecnicos.Text = "Ver Datos Técnicos"
        Me.btnDatosTecnicos.UseVisualStyleBackColor = True
        '
        'btnLimpiarNodo
        '
        Me.btnLimpiarNodo.Image = Global.mantencion.My.Resources.Resources.clear
        Me.btnLimpiarNodo.Location = New System.Drawing.Point(42, 33)
        Me.btnLimpiarNodo.Name = "btnLimpiarNodo"
        Me.btnLimpiarNodo.Size = New System.Drawing.Size(29, 29)
        Me.btnLimpiarNodo.TabIndex = 2
        Me.ToolTip2.SetToolTip(Me.btnLimpiarNodo, "Limpiar")
        Me.btnLimpiarNodo.UseVisualStyleBackColor = True
        '
        'btnSalirNodos
        '
        Me.btnSalirNodos.Image = Global.mantencion.My.Resources.Resources.salir
        Me.btnSalirNodos.Location = New System.Drawing.Point(77, 33)
        Me.btnSalirNodos.Name = "btnSalirNodos"
        Me.btnSalirNodos.Size = New System.Drawing.Size(29, 29)
        Me.btnSalirNodos.TabIndex = 1
        Me.ToolTip3.SetToolTip(Me.btnSalirNodos, "Salir")
        Me.btnSalirNodos.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.mantencion.My.Resources.Resources.guardar
        Me.btnGuardar.Location = New System.Drawing.Point(7, 33)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(29, 29)
        Me.btnGuardar.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Guardar")
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'FrmAdminNodos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(1020, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtBuscarNodoNd)
        Me.Controls.Add(Me.GrpOperNodos)
        Me.Controls.Add(Me.GrpNodoPadre)
        Me.Controls.Add(Me.GrpInfoNuevoNodo)
        Me.Controls.Add(Me.arbol4)
        Me.Name = "FrmAdminNodos"
        Me.Text = "Mantenedor de Nodos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.GrpInfoNuevoNodo.ResumeLayout(False)
        Me.GrpInfoNuevoNodo.PerformLayout()
        Me.grpAplicaMant.ResumeLayout(False)
        Me.grpAplicaMant.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrpNodoPadre.ResumeLayout(False)
        Me.GrpNodoPadre.PerformLayout()
        Me.grpAplicaMant2.ResumeLayout(False)
        Me.grpAplicaMant2.PerformLayout()
        Me.GrpEstadoNodo.ResumeLayout(False)
        Me.GrpEstadoNodo.PerformLayout()
        Me.GrpOperNodos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents arbol4 As System.Windows.Forms.TreeView
    Friend WithEvents GrpInfoNuevoNodo As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIDNuevoNodo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescNuevoNodo As System.Windows.Forms.TextBox
    Friend WithEvents GrpNodoPadre As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtIDNodoSel As System.Windows.Forms.TextBox
    Friend WithEvents txtDescNodoSel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GrpEstadoNodo As System.Windows.Forms.GroupBox
    Friend WithEvents opcDesactivado As System.Windows.Forms.RadioButton
    Friend WithEvents opcActivado As System.Windows.Forms.RadioButton
    Friend WithEvents btnNuevoNodo As System.Windows.Forms.Button
    Friend WithEvents GrpOperNodos As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnSalirNodos As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents opcNuevoNodoDesac As System.Windows.Forms.RadioButton
    Friend WithEvents opcNuevoNodoAct As System.Windows.Forms.RadioButton
    Friend WithEvents btnLimpiarNodo As System.Windows.Forms.Button
    Friend WithEvents chkModPadre As System.Windows.Forms.CheckBox
    Friend WithEvents txtCodRmes As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodRmesNodoNuevo As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscarNodoNd As System.Windows.Forms.TextBox
    Friend WithEvents fecha_instalacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPrioridad As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPrioridad2 As System.Windows.Forms.TextBox
    Friend WithEvents fecha_instalacion2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCodSap2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCodSap As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents grpAplicaMant2 As System.Windows.Forms.GroupBox
    Friend WithEvents opcAplicaMantNo2 As System.Windows.Forms.RadioButton
    Friend WithEvents opcAplicaMantSi2 As System.Windows.Forms.RadioButton
    Friend WithEvents grpAplicaMant As System.Windows.Forms.GroupBox
    Friend WithEvents opcAplicaMantNo As System.Windows.Forms.RadioButton
    Friend WithEvents opcAplicaMantSi As System.Windows.Forms.RadioButton
    Friend WithEvents cmbGrupoNodo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGrupoNodo2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnDatosTecnicos As System.Windows.Forms.Button
End Class
