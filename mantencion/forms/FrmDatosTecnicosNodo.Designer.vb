<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDatosTecnicosNodo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.arbol9 = New System.Windows.Forms.TreeView
        Me.txtBuscarArbol = New System.Windows.Forms.TextBox
        Me.grillaDatosTecnicosNodo = New System.Windows.Forms.DataGridView
        Me.btnSalirDatos = New System.Windows.Forms.Button
        Me.btnLimpiarDatos = New System.Windows.Forms.Button
        Me.btnEliminarDatoTecnico = New System.Windows.Forms.Button
        Me.btnGuardarDatos = New System.Windows.Forms.Button
        Me.btnBuscarDatoTecnico = New System.Windows.Forms.Button
        Me.lblGrillaDatosTecnicos = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip4 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnExpotarExcel = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnAgrDatosTecnicos = New System.Windows.Forms.Button
        Me.ToolTip5 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip6 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtFiltroDescDatoTecnico = New System.Windows.Forms.TextBox
        Me.grpFiltroDatosTecnicos = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip7 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmbGrupoDatoTecnico = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.id_dato_tecnico = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id_modulo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc_modulo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc_dato_tecnico = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor_dato_tecnico = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grupo_dato_tecnico = New System.Windows.Forms.DataGridViewComboBoxColumn
        CType(Me.grillaDatosTecnicosNodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.grpFiltroDatosTecnicos.SuspendLayout()
        Me.SuspendLayout()
        '
        'arbol9
        '
        Me.arbol9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.arbol9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.arbol9.Location = New System.Drawing.Point(12, 38)
        Me.arbol9.Name = "arbol9"
        Me.arbol9.Size = New System.Drawing.Size(221, 611)
        Me.arbol9.TabIndex = 0
        '
        'txtBuscarArbol
        '
        Me.txtBuscarArbol.Location = New System.Drawing.Point(13, 12)
        Me.txtBuscarArbol.Name = "txtBuscarArbol"
        Me.txtBuscarArbol.Size = New System.Drawing.Size(220, 20)
        Me.txtBuscarArbol.TabIndex = 1
        '
        'grillaDatosTecnicosNodo
        '
        Me.grillaDatosTecnicosNodo.AllowUserToAddRows = False
        Me.grillaDatosTecnicosNodo.AllowUserToDeleteRows = False
        Me.grillaDatosTecnicosNodo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaDatosTecnicosNodo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grillaDatosTecnicosNodo.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaDatosTecnicosNodo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grillaDatosTecnicosNodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaDatosTecnicosNodo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_dato_tecnico, Me.id_modulo, Me.desc_modulo, Me.desc_dato_tecnico, Me.valor_dato_tecnico, Me.grupo_dato_tecnico})
        Me.grillaDatosTecnicosNodo.EnableHeadersVisualStyles = False
        Me.grillaDatosTecnicosNodo.Location = New System.Drawing.Point(254, 149)
        Me.grillaDatosTecnicosNodo.Name = "grillaDatosTecnicosNodo"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaDatosTecnicosNodo.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grillaDatosTecnicosNodo.RowHeadersWidth = 20
        Me.grillaDatosTecnicosNodo.Size = New System.Drawing.Size(599, 371)
        Me.grillaDatosTecnicosNodo.TabIndex = 2
        '
        'btnSalirDatos
        '
        Me.btnSalirDatos.Image = Global.mantencion.My.Resources.Resources.salir
        Me.btnSalirDatos.Location = New System.Drawing.Point(109, 15)
        Me.btnSalirDatos.Name = "btnSalirDatos"
        Me.btnSalirDatos.Size = New System.Drawing.Size(29, 29)
        Me.btnSalirDatos.TabIndex = 8
        Me.ToolTip2.SetToolTip(Me.btnSalirDatos, "Salir")
        Me.btnSalirDatos.UseVisualStyleBackColor = True
        '
        'btnLimpiarDatos
        '
        Me.btnLimpiarDatos.Image = Global.mantencion.My.Resources.Resources.clear
        Me.btnLimpiarDatos.Location = New System.Drawing.Point(74, 15)
        Me.btnLimpiarDatos.Name = "btnLimpiarDatos"
        Me.btnLimpiarDatos.Size = New System.Drawing.Size(29, 29)
        Me.btnLimpiarDatos.TabIndex = 7
        Me.ToolTip6.SetToolTip(Me.btnLimpiarDatos, "Limpiar Tabla")
        Me.btnLimpiarDatos.UseVisualStyleBackColor = True
        '
        'btnEliminarDatoTecnico
        '
        Me.btnEliminarDatoTecnico.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarDatoTecnico.Image = Global.mantencion.My.Resources.Resources.eliminar
        Me.btnEliminarDatoTecnico.Location = New System.Drawing.Point(858, 178)
        Me.btnEliminarDatoTecnico.Name = "btnEliminarDatoTecnico"
        Me.btnEliminarDatoTecnico.Size = New System.Drawing.Size(26, 26)
        Me.btnEliminarDatoTecnico.TabIndex = 6
        Me.ToolTip4.SetToolTip(Me.btnEliminarDatoTecnico, "Eliminar Dato Técnico")
        Me.btnEliminarDatoTecnico.UseVisualStyleBackColor = True
        '
        'btnGuardarDatos
        '
        Me.btnGuardarDatos.Image = Global.mantencion.My.Resources.Resources.guardar
        Me.btnGuardarDatos.Location = New System.Drawing.Point(39, 15)
        Me.btnGuardarDatos.Name = "btnGuardarDatos"
        Me.btnGuardarDatos.Size = New System.Drawing.Size(29, 29)
        Me.btnGuardarDatos.TabIndex = 5
        Me.ToolTip3.SetToolTip(Me.btnGuardarDatos, "Guardar")
        Me.btnGuardarDatos.UseVisualStyleBackColor = True
        '
        'btnBuscarDatoTecnico
        '
        Me.btnBuscarDatoTecnico.Image = Global.mantencion.My.Resources.Resources.icono_buscar1
        Me.btnBuscarDatoTecnico.Location = New System.Drawing.Point(3, 15)
        Me.btnBuscarDatoTecnico.Name = "btnBuscarDatoTecnico"
        Me.btnBuscarDatoTecnico.Size = New System.Drawing.Size(29, 29)
        Me.btnBuscarDatoTecnico.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.btnBuscarDatoTecnico, "Buscar Datos Técnicos")
        Me.btnBuscarDatoTecnico.UseVisualStyleBackColor = True
        '
        'lblGrillaDatosTecnicos
        '
        Me.lblGrillaDatosTecnicos.AutoSize = True
        Me.lblGrillaDatosTecnicos.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrillaDatosTecnicos.Location = New System.Drawing.Point(250, 127)
        Me.lblGrillaDatosTecnicos.Name = "lblGrillaDatosTecnicos"
        Me.lblGrillaDatosTecnicos.Size = New System.Drawing.Size(192, 19)
        Me.lblGrillaDatosTecnicos.TabIndex = 5
        Me.lblGrillaDatosTecnicos.Text = "Datos Técnicos Asociados a "
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnExpotarExcel)
        Me.Panel2.Controls.Add(Me.btnGuardarDatos)
        Me.Panel2.Controls.Add(Me.btnSalirDatos)
        Me.Panel2.Controls.Add(Me.btnBuscarDatoTecnico)
        Me.Panel2.Controls.Add(Me.btnLimpiarDatos)
        Me.Panel2.Location = New System.Drawing.Point(774, 46)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(184, 49)
        Me.Panel2.TabIndex = 6
        '
        'btnExpotarExcel
        '
        Me.btnExpotarExcel.Image = Global.mantencion.My.Resources.Resources.icono_excel1
        Me.btnExpotarExcel.Location = New System.Drawing.Point(144, 15)
        Me.btnExpotarExcel.Name = "btnExpotarExcel"
        Me.btnExpotarExcel.Size = New System.Drawing.Size(29, 29)
        Me.btnExpotarExcel.TabIndex = 12
        Me.ToolTip7.SetToolTip(Me.btnExpotarExcel, "Exportar a Excel")
        Me.btnExpotarExcel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(781, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Operaciones"
        '
        'btnAgrDatosTecnicos
        '
        Me.btnAgrDatosTecnicos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgrDatosTecnicos.Image = Global.mantencion.My.Resources.Resources.add
        Me.btnAgrDatosTecnicos.Location = New System.Drawing.Point(860, 149)
        Me.btnAgrDatosTecnicos.Name = "btnAgrDatosTecnicos"
        Me.btnAgrDatosTecnicos.Size = New System.Drawing.Size(24, 24)
        Me.btnAgrDatosTecnicos.TabIndex = 8
        Me.ToolTip5.SetToolTip(Me.btnAgrDatosTecnicos, "Agregar Datos Técnicos")
        Me.btnAgrDatosTecnicos.UseVisualStyleBackColor = True
        '
        'txtFiltroDescDatoTecnico
        '
        Me.txtFiltroDescDatoTecnico.Location = New System.Drawing.Point(8, 36)
        Me.txtFiltroDescDatoTecnico.Name = "txtFiltroDescDatoTecnico"
        Me.txtFiltroDescDatoTecnico.Size = New System.Drawing.Size(260, 20)
        Me.txtFiltroDescDatoTecnico.TabIndex = 9
        '
        'grpFiltroDatosTecnicos
        '
        Me.grpFiltroDatosTecnicos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grpFiltroDatosTecnicos.Controls.Add(Me.Label4)
        Me.grpFiltroDatosTecnicos.Controls.Add(Me.cmbGrupoDatoTecnico)
        Me.grpFiltroDatosTecnicos.Controls.Add(Me.Label2)
        Me.grpFiltroDatosTecnicos.Controls.Add(Me.txtFiltroDescDatoTecnico)
        Me.grpFiltroDatosTecnicos.Location = New System.Drawing.Point(254, 38)
        Me.grpFiltroDatosTecnicos.Name = "grpFiltroDatosTecnicos"
        Me.grpFiltroDatosTecnicos.Size = New System.Drawing.Size(429, 70)
        Me.grpFiltroDatosTecnicos.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(263, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Ingrese la Descripción del Dato Técnico a Buscar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(260, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(190, 15)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Filtro de Busqueda Datos Técnicos"
        '
        'cmbGrupoDatoTecnico
        '
        Me.cmbGrupoDatoTecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupoDatoTecnico.FormattingEnabled = True
        Me.cmbGrupoDatoTecnico.Items.AddRange(New Object() {"Planta", "Seccion", "Maquina", "Modulo", "Item", "Otros"})
        Me.cmbGrupoDatoTecnico.Location = New System.Drawing.Point(294, 35)
        Me.cmbGrupoDatoTecnico.Name = "cmbGrupoDatoTecnico"
        Me.cmbGrupoDatoTecnico.Size = New System.Drawing.Size(121, 21)
        Me.cmbGrupoDatoTecnico.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(291, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Grupo"
        '
        'id_dato_tecnico
        '
        Me.id_dato_tecnico.HeaderText = "ID_Dato_Tecnico"
        Me.id_dato_tecnico.Name = "id_dato_tecnico"
        '
        'id_modulo
        '
        Me.id_modulo.HeaderText = "ID_Modulo"
        Me.id_modulo.Name = "id_modulo"
        '
        'desc_modulo
        '
        Me.desc_modulo.HeaderText = "Módulo/Máquina"
        Me.desc_modulo.Name = "desc_modulo"
        Me.desc_modulo.Width = 150
        '
        'desc_dato_tecnico
        '
        Me.desc_dato_tecnico.HeaderText = "Descripcion_Dato_Tecnico"
        Me.desc_dato_tecnico.Name = "desc_dato_tecnico"
        Me.desc_dato_tecnico.Width = 250
        '
        'valor_dato_tecnico
        '
        Me.valor_dato_tecnico.HeaderText = "Valor"
        Me.valor_dato_tecnico.Name = "valor_dato_tecnico"
        Me.valor_dato_tecnico.Width = 150
        '
        'grupo_dato_tecnico
        '
        Me.grupo_dato_tecnico.HeaderText = "Grupo"
        Me.grupo_dato_tecnico.Name = "grupo_dato_tecnico"
        '
        'FrmDatosTecnicosNodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(1020, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grpFiltroDatosTecnicos)
        Me.Controls.Add(Me.btnAgrDatosTecnicos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnEliminarDatoTecnico)
        Me.Controls.Add(Me.lblGrillaDatosTecnicos)
        Me.Controls.Add(Me.grillaDatosTecnicosNodo)
        Me.Controls.Add(Me.txtBuscarArbol)
        Me.Controls.Add(Me.arbol9)
        Me.Name = "FrmDatosTecnicosNodo"
        Me.ShowIcon = False
        Me.Text = "Gestión Datos Técnicos Ítem / Máquina"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        CType(Me.grillaDatosTecnicosNodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.grpFiltroDatosTecnicos.ResumeLayout(False)
        Me.grpFiltroDatosTecnicos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents arbol9 As System.Windows.Forms.TreeView
    Friend WithEvents txtBuscarArbol As System.Windows.Forms.TextBox
    Friend WithEvents grillaDatosTecnicosNodo As System.Windows.Forms.DataGridView
    Friend WithEvents lblGrillaDatosTecnicos As System.Windows.Forms.Label
    Friend WithEvents btnBuscarDatoTecnico As System.Windows.Forms.Button
    Friend WithEvents btnGuardarDatos As System.Windows.Forms.Button
    Friend WithEvents btnEliminarDatoTecnico As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarDatos As System.Windows.Forms.Button
    Friend WithEvents btnSalirDatos As System.Windows.Forms.Button
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip4 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAgrDatosTecnicos As System.Windows.Forms.Button
    Friend WithEvents ToolTip5 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip6 As System.Windows.Forms.ToolTip
    Friend WithEvents txtFiltroDescDatoTecnico As System.Windows.Forms.TextBox
    Friend WithEvents grpFiltroDatosTecnicos As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnExpotarExcel As System.Windows.Forms.Button
    Friend WithEvents ToolTip7 As System.Windows.Forms.ToolTip
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbGrupoDatoTecnico As System.Windows.Forms.ComboBox
    Friend WithEvents id_dato_tecnico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_modulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc_modulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc_dato_tecnico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor_dato_tecnico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grupo_dato_tecnico As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
