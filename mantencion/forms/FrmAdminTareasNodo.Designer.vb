<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdminTareasNodo
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtIdModulo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtOrdenDespliegue = New System.Windows.Forms.TextBox
        Me.btnNuevaTarea = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbTipoMP = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDescTarea = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtIdTarea = New System.Windows.Forms.TextBox
        Me.arbol6 = New System.Windows.Forms.TreeView
        Me.Label4 = New System.Windows.Forms.Label
        Me.grillaTareasNodo = New System.Windows.Forms.DataGridView
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btn_buscar_tarea = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnElimTarea = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip4 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtBuscarNodoIt = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnCambiarIDMod = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.grillaTareasNodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtIdModulo)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtOrdenDespliegue)
        Me.Panel1.Controls.Add(Me.btnNuevaTarea)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmbTipoMP)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtDescTarea)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtIdTarea)
        Me.Panel1.Location = New System.Drawing.Point(254, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(754, 108)
        Me.Panel1.TabIndex = 0
        '
        'txtIdModulo
        '
        Me.txtIdModulo.Location = New System.Drawing.Point(5, 65)
        Me.txtIdModulo.Name = "txtIdModulo"
        Me.txtIdModulo.Size = New System.Drawing.Size(60, 20)
        Me.txtIdModulo.TabIndex = 9
        Me.txtIdModulo.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(488, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 30)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Orden " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Despliegue"
        '
        'txtOrdenDespliegue
        '
        Me.txtOrdenDespliegue.Location = New System.Drawing.Point(491, 38)
        Me.txtOrdenDespliegue.Name = "txtOrdenDespliegue"
        Me.txtOrdenDespliegue.Size = New System.Drawing.Size(61, 20)
        Me.txtOrdenDespliegue.TabIndex = 7
        '
        'btnNuevaTarea
        '
        Me.btnNuevaTarea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevaTarea.Image = Global.mantencion.My.Resources.Resources.add
        Me.btnNuevaTarea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevaTarea.Location = New System.Drawing.Point(640, 78)
        Me.btnNuevaTarea.Name = "btnNuevaTarea"
        Me.btnNuevaTarea.Size = New System.Drawing.Size(110, 26)
        Me.btnNuevaTarea.TabIndex = 6
        Me.btnNuevaTarea.Text = "Nueva Tarea"
        Me.btnNuevaTarea.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(566, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Tipo Mantención"
        '
        'cmbTipoMP
        '
        Me.cmbTipoMP.FormattingEnabled = True
        Me.cmbTipoMP.Location = New System.Drawing.Point(569, 38)
        Me.cmbTipoMP.Name = "cmbTipoMP"
        Me.cmbTipoMP.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipoMP.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(82, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripción Tarea"
        '
        'txtDescTarea
        '
        Me.txtDescTarea.Location = New System.Drawing.Point(85, 38)
        Me.txtDescTarea.MaxLength = 100
        Me.txtDescTarea.Multiline = True
        Me.txtDescTarea.Name = "txtDescTarea"
        Me.txtDescTarea.Size = New System.Drawing.Size(397, 54)
        Me.txtDescTarea.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ID Tarea"
        '
        'txtIdTarea
        '
        Me.txtIdTarea.BackColor = System.Drawing.Color.FromArgb(215, 230, 234)
        Me.txtIdTarea.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.txtIdTarea.ReadOnly = True
        Me.txtIdTarea.Location = New System.Drawing.Point(5, 38)
        Me.txtIdTarea.Name = "txtIdTarea"
        Me.txtIdTarea.Size = New System.Drawing.Size(60, 20)
        Me.txtIdTarea.TabIndex = 0
        '
        'arbol6
        '
        Me.arbol6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.arbol6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.arbol6.Location = New System.Drawing.Point(12, 28)
        Me.arbol6.Name = "arbol6"
        Me.arbol6.Size = New System.Drawing.Size(221, 621)
        Me.arbol6.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(260, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Información Tarea"
        '
        'grillaTareasNodo
        '
        Me.grillaTareasNodo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grillaTareasNodo.AllowUserToAddRows = False
        Me.grillaTareasNodo.AllowUserToDeleteRows = False
        Me.grillaTareasNodo.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaTareasNodo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grillaTareasNodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaTareasNodo.EnableHeadersVisualStyles = False
        Me.grillaTareasNodo.Location = New System.Drawing.Point(254, 221)
        Me.grillaTareasNodo.Name = "grillaTareasNodo"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaTareasNodo.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grillaTareasNodo.RowHeadersWidth = 20
        Me.grillaTareasNodo.Size = New System.Drawing.Size(754, 428)
        Me.grillaTareasNodo.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btn_buscar_tarea)
        Me.Panel2.Controls.Add(Me.btnSalir)
        Me.Panel2.Controls.Add(Me.btnElimTarea)
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Location = New System.Drawing.Point(865, 166)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(143, 47)
        Me.Panel2.TabIndex = 4
        '
        'btn_buscar_tarea
        '
        Me.btn_buscar_tarea.Image = Global.mantencion.My.Resources.Resources.icono_buscar1
        Me.btn_buscar_tarea.Location = New System.Drawing.Point(3, 8)
        Me.btn_buscar_tarea.Name = "btn_buscar_tarea"
        Me.btn_buscar_tarea.Size = New System.Drawing.Size(29, 29)
        Me.btn_buscar_tarea.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btn_buscar_tarea, "Buscar Tareas")
        Me.btn_buscar_tarea.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.mantencion.My.Resources.Resources.salir
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(108, 8)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(29, 29)
        Me.btnSalir.TabIndex = 2
        Me.ToolTip4.SetToolTip(Me.btnSalir, "Salir")
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnElimTarea
        '
        Me.btnElimTarea.BackgroundImage = Global.mantencion.My.Resources.Resources.eliminar
        Me.btnElimTarea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnElimTarea.Location = New System.Drawing.Point(73, 8)
        Me.btnElimTarea.Name = "btnElimTarea"
        Me.btnElimTarea.Size = New System.Drawing.Size(29, 29)
        Me.btnElimTarea.TabIndex = 1
        Me.ToolTip3.SetToolTip(Me.btnElimTarea, "Eliminar Tarea")
        Me.btnElimTarea.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.mantencion.My.Resources.Resources.guardar
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardar.Location = New System.Drawing.Point(38, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(29, 29)
        Me.btnGuardar.TabIndex = 0
        Me.ToolTip2.SetToolTip(Me.btnGuardar, "Guardar Tarea")
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.Label5.Location = New System.Drawing.Point(869, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Operaciones"
        '
        'txtBuscarNodoIt
        '
        Me.txtBuscarNodoIt.Location = New System.Drawing.Point(13, 2)
        Me.txtBuscarNodoIt.Name = "txtBuscarNodoIt"
        Me.txtBuscarNodoIt.Size = New System.Drawing.Size(220, 20)
        Me.txtBuscarNodoIt.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(260, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(211, 15)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Tareas Asociadas al item seleccionado"
        '
        'btnCambiarIDMod
        '
        Me.btnCambiarIDMod.Image = Global.mantencion.My.Resources.Resources.operations
        Me.btnCambiarIDMod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCambiarIDMod.Location = New System.Drawing.Point(718, 188)
        Me.btnCambiarIDMod.Name = "btnCambiarIDMod"
        Me.btnCambiarIDMod.Size = New System.Drawing.Size(140, 27)
        Me.btnCambiarIDMod.TabIndex = 8
        Me.btnCambiarIDMod.Text = "Cambiar ID Módulo"
        Me.btnCambiarIDMod.UseVisualStyleBackColor = True
        '
        'FrmAdminTareasNodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(1020, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCambiarIDMod)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtBuscarNodoIt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.grillaTareasNodo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.arbol6)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmAdminTareasNodo"
        Me.ShowIcon = False
        Me.Text = "Mantenedor Tareas Items / Maquinas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grillaTareasNodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents arbol6 As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIdTarea As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescTarea As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoMP As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnNuevaTarea As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grillaTareasNodo As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnElimTarea As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_buscar_tarea As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtOrdenDespliegue As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip4 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents txtBuscarNodoIt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtIdModulo As System.Windows.Forms.TextBox
    Friend WithEvents btnCambiarIDMod As System.Windows.Forms.Button
End Class
