<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscarDatosTecnicos
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
        Me.grillaDatosTecnicos = New System.Windows.Forms.DataGridView
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.chkSelTodo = New System.Windows.Forms.CheckBox
        Me.btnCambiarEstado = New System.Windows.Forms.Button
        CType(Me.grillaDatosTecnicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grillaDatosTecnicos
        '
        Me.grillaDatosTecnicos.AllowUserToAddRows = False
        Me.grillaDatosTecnicos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grillaDatosTecnicos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grillaDatosTecnicos.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaDatosTecnicos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grillaDatosTecnicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaDatosTecnicos.EnableHeadersVisualStyles = False
        Me.grillaDatosTecnicos.Location = New System.Drawing.Point(12, 53)
        Me.grillaDatosTecnicos.Name = "grillaDatosTecnicos"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaDatosTecnicos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grillaDatosTecnicos.RowHeadersWidth = 20
        Me.grillaDatosTecnicos.Size = New System.Drawing.Size(307, 201)
        Me.grillaDatosTecnicos.TabIndex = 0
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(260, 24)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(59, 23)
        Me.btnAgregar.TabIndex = 1
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'chkSelTodo
        '
        Me.chkSelTodo.AutoSize = True
        Me.chkSelTodo.Location = New System.Drawing.Point(12, 30)
        Me.chkSelTodo.Name = "chkSelTodo"
        Me.chkSelTodo.Size = New System.Drawing.Size(110, 17)
        Me.chkSelTodo.TabIndex = 2
        Me.chkSelTodo.Text = "Seleccionar Todo"
        Me.chkSelTodo.UseVisualStyleBackColor = True
        '
        'btnCambiarEstado
        '
        Me.btnCambiarEstado.Location = New System.Drawing.Point(164, 24)
        Me.btnCambiarEstado.Name = "btnCambiarEstado"
        Me.btnCambiarEstado.Size = New System.Drawing.Size(91, 23)
        Me.btnCambiarEstado.TabIndex = 3
        Me.btnCambiarEstado.Text = "Cambiar Estado"
        Me.btnCambiarEstado.UseVisualStyleBackColor = True
        '
        'FrmBuscarDatosTecnicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(331, 266)
        Me.Controls.Add(Me.btnCambiarEstado)
        Me.Controls.Add(Me.chkSelTodo)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.grillaDatosTecnicos)
        Me.MaximizeBox = False
        Me.Name = "FrmBuscarDatosTecnicos"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Datos Técnicos"
        CType(Me.grillaDatosTecnicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grillaDatosTecnicos As System.Windows.Forms.DataGridView
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents chkSelTodo As System.Windows.Forms.CheckBox
    Friend WithEvents btnCambiarEstado As System.Windows.Forms.Button
End Class
