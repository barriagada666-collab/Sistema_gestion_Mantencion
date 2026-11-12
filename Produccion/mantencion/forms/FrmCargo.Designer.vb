<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCargo
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtCodCargo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDescCargo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_buscar_cargo = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_guardar_cargo = New System.Windows.Forms.Button
        Me.btn_eliminar_cargo = New System.Windows.Forms.Button
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.grillaCargos = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grillaCargos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_buscar_cargo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtDescCargo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtCodCargo)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 92)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información Cargo"
        '
        'txtCodCargo
        '
        Me.txtCodCargo.Location = New System.Drawing.Point(7, 40)
        Me.txtCodCargo.Name = "txtCodCargo"
        Me.txtCodCargo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodCargo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Código"
        '
        'txtDescCargo
        '
        Me.txtDescCargo.Location = New System.Drawing.Point(139, 39)
        Me.txtDescCargo.MaxLength = 100
        Me.txtDescCargo.Name = "txtDescCargo"
        Me.txtDescCargo.Size = New System.Drawing.Size(199, 20)
        Me.txtDescCargo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(136, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripción"
        '
        'btn_buscar_cargo
        '
        Me.btn_buscar_cargo.Location = New System.Drawing.Point(367, 36)
        Me.btn_buscar_cargo.Name = "btn_buscar_cargo"
        Me.btn_buscar_cargo.Size = New System.Drawing.Size(75, 23)
        Me.btn_buscar_cargo.TabIndex = 4
        Me.btn_buscar_cargo.Text = "Buscar"
        Me.btn_buscar_cargo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_salir)
        Me.GroupBox2.Controls.Add(Me.btn_limpiar)
        Me.GroupBox2.Controls.Add(Me.btn_eliminar_cargo)
        Me.GroupBox2.Controls.Add(Me.btn_guardar_cargo)
        Me.GroupBox2.Location = New System.Drawing.Point(313, 147)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(158, 63)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Operaciones"
        '
        'btn_guardar_cargo
        '
        Me.btn_guardar_cargo.Image = Global.Mantencion.My.Resources.Resources.guardar
        Me.btn_guardar_cargo.Location = New System.Drawing.Point(9, 28)
        Me.btn_guardar_cargo.Name = "btn_guardar_cargo"
        Me.btn_guardar_cargo.Size = New System.Drawing.Size(29, 29)
        Me.btn_guardar_cargo.TabIndex = 0
        Me.btn_guardar_cargo.UseVisualStyleBackColor = True
        '
        'btn_eliminar_cargo
        '
        Me.btn_eliminar_cargo.Image = Global.Mantencion.My.Resources.Resources.eliminar
        Me.btn_eliminar_cargo.Location = New System.Drawing.Point(44, 28)
        Me.btn_eliminar_cargo.Name = "btn_eliminar_cargo"
        Me.btn_eliminar_cargo.Size = New System.Drawing.Size(29, 29)
        Me.btn_eliminar_cargo.TabIndex = 1
        Me.btn_eliminar_cargo.UseVisualStyleBackColor = True
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Image = Global.Mantencion.My.Resources.Resources.clear
        Me.btn_limpiar.Location = New System.Drawing.Point(80, 28)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(29, 29)
        Me.btn_limpiar.TabIndex = 2
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Image = Global.Mantencion.My.Resources.Resources.salir
        Me.btn_salir.Location = New System.Drawing.Point(115, 28)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(29, 29)
        Me.btn_salir.TabIndex = 3
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'grillaCargos
        '
        Me.grillaCargos.AllowUserToAddRows = False
        Me.grillaCargos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grillaCargos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grillaCargos.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaCargos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grillaCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaCargos.EnableHeadersVisualStyles = False
        Me.grillaCargos.Location = New System.Drawing.Point(13, 253)
        Me.grillaCargos.Name = "grillaCargos"
        Me.grillaCargos.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaCargos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grillaCargos.RowHeadersWidth = 20
        Me.grillaCargos.Size = New System.Drawing.Size(338, 243)
        Me.grillaCargos.TabIndex = 2
        '
        'FrmCargo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(1020, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.grillaCargos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmCargo"
        Me.ShowIcon = False
        Me.Text = "Administración de Cargos Personal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grillaCargos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_buscar_cargo As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescCargo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodCargo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar_cargo As System.Windows.Forms.Button
    Friend WithEvents btn_guardar_cargo As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents grillaCargos As System.Windows.Forms.DataGridView
End Class
