<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscarPersonal
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grillaPersonal = New System.Windows.Forms.DataGridView
        Me.txtBuscarPersonal = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grilla_personal_2 = New System.Windows.Forms.DataGridView
        Me.btn_agregar_personal = New System.Windows.Forms.Button
        Me.rut_personal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.alias_personal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.grillaPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_personal_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grillaPersonal
        '
        Me.grillaPersonal.AllowUserToAddRows = False
        Me.grillaPersonal.AllowUserToDeleteRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaPersonal.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.grillaPersonal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grillaPersonal.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaPersonal.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.grillaPersonal.EnableHeadersVisualStyles = False
        Me.grillaPersonal.Location = New System.Drawing.Point(13, 53)
        Me.grillaPersonal.Name = "grillaPersonal"
        Me.grillaPersonal.ReadOnly = True
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaPersonal.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.grillaPersonal.RowHeadersWidth = 20
        Me.grillaPersonal.Size = New System.Drawing.Size(294, 201)
        Me.grillaPersonal.TabIndex = 0
        '
        'txtBuscarPersonal
        '
        Me.txtBuscarPersonal.Location = New System.Drawing.Point(13, 27)
        Me.txtBuscarPersonal.Name = "txtBuscarPersonal"
        Me.txtBuscarPersonal.Size = New System.Drawing.Size(294, 20)
        Me.txtBuscarPersonal.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ingrese el nombre a buscar"
        '
        'grilla_personal_2
        '
        Me.grilla_personal_2.AllowUserToAddRows = False
        Me.grilla_personal_2.AllowUserToDeleteRows = False
        Me.grilla_personal_2.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_personal_2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.grilla_personal_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_personal_2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rut_personal, Me.alias_personal})
        Me.grilla_personal_2.EnableHeadersVisualStyles = False
        Me.grilla_personal_2.Location = New System.Drawing.Point(325, 53)
        Me.grilla_personal_2.Name = "grilla_personal_2"
        Me.grilla_personal_2.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_personal_2.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.grilla_personal_2.RowHeadersWidth = 20
        Me.grilla_personal_2.Size = New System.Drawing.Size(203, 201)
        Me.grilla_personal_2.TabIndex = 3
        Me.grilla_personal_2.Visible = False
        '
        'btn_agregar_personal
        '
        Me.btn_agregar_personal.Image = Global.mantencion.My.Resources.Resources.add
        Me.btn_agregar_personal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_agregar_personal.Location = New System.Drawing.Point(440, 22)
        Me.btn_agregar_personal.Name = "btn_agregar_personal"
        Me.btn_agregar_personal.Size = New System.Drawing.Size(88, 26)
        Me.btn_agregar_personal.TabIndex = 4
        Me.btn_agregar_personal.Text = "Agregar"
        Me.btn_agregar_personal.UseVisualStyleBackColor = True
        Me.btn_agregar_personal.Visible = False
        '
        'rut_personal
        '
        Me.rut_personal.HeaderText = "Rut"
        Me.rut_personal.Name = "rut_personal"
        Me.rut_personal.ReadOnly = True
        Me.rut_personal.Width = 60
        '
        'alias_personal
        '
        Me.alias_personal.HeaderText = "Alias"
        Me.alias_personal.Name = "alias_personal"
        Me.alias_personal.ReadOnly = True
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Image = Global.mantencion.My.Resources.Resources.clear
        Me.btn_limpiar.Location = New System.Drawing.Point(534, 53)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(29, 29)
        Me.btn_limpiar.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btn_limpiar, "Eliminar Personal")
        Me.btn_limpiar.UseVisualStyleBackColor = True
        Me.btn_limpiar.Visible = False
        '
        'FrmBuscarPersonal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(565, 266)
        Me.Controls.Add(Me.btn_limpiar)
        Me.Controls.Add(Me.btn_agregar_personal)
        Me.Controls.Add(Me.grilla_personal_2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBuscarPersonal)
        Me.Controls.Add(Me.grillaPersonal)
        Me.MaximizeBox = False
        Me.Name = "FrmBuscarPersonal"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Personal"
        CType(Me.grillaPersonal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_personal_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grillaPersonal As System.Windows.Forms.DataGridView
    Friend WithEvents txtBuscarPersonal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grilla_personal_2 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_agregar_personal As System.Windows.Forms.Button
    Friend WithEvents rut_personal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents alias_personal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
