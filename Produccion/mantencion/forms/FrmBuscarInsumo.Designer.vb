<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscarInsumo
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
        Me.grillaInsumos = New System.Windows.Forms.DataGridView
        Me.txtFiltro = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Grpfiltro = New System.Windows.Forms.GroupBox
        Me.opcDesc = New System.Windows.Forms.RadioButton
        Me.opcCodSap = New System.Windows.Forms.RadioButton
        CType(Me.grillaInsumos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grpfiltro.SuspendLayout()
        Me.SuspendLayout()
        '
        'grillaInsumos
        '
        Me.grillaInsumos.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grillaInsumos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grillaInsumos.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaInsumos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grillaInsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaInsumos.EnableHeadersVisualStyles = False
        Me.grillaInsumos.Location = New System.Drawing.Point(12, 61)
        Me.grillaInsumos.Name = "grillaInsumos"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaInsumos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grillaInsumos.Size = New System.Drawing.Size(570, 193)
        Me.grillaInsumos.TabIndex = 0
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(357, 35)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(225, 20)
        Me.txtFiltro.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(354, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ingrese palabra a buscar"
        '
        'Grpfiltro
        '
        Me.Grpfiltro.BackColor = System.Drawing.Color.Transparent
        Me.Grpfiltro.Controls.Add(Me.opcDesc)
        Me.Grpfiltro.Controls.Add(Me.opcCodSap)
        Me.Grpfiltro.Location = New System.Drawing.Point(12, 12)
        Me.Grpfiltro.Name = "Grpfiltro"
        Me.Grpfiltro.Size = New System.Drawing.Size(181, 43)
        Me.Grpfiltro.TabIndex = 3
        Me.Grpfiltro.TabStop = False
        Me.Grpfiltro.Text = "Opciones de Busqueda"
        '
        'opcDesc
        '
        Me.opcDesc.AutoSize = True
        Me.opcDesc.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opcDesc.Location = New System.Drawing.Point(93, 20)
        Me.opcDesc.Name = "opcDesc"
        Me.opcDesc.Size = New System.Drawing.Size(87, 19)
        Me.opcDesc.TabIndex = 1
        Me.opcDesc.TabStop = True
        Me.opcDesc.Text = "Descripción"
        Me.opcDesc.UseVisualStyleBackColor = True
        '
        'opcCodSap
        '
        Me.opcCodSap.AutoSize = True
        Me.opcCodSap.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opcCodSap.Location = New System.Drawing.Point(7, 20)
        Me.opcCodSap.Name = "opcCodSap"
        Me.opcCodSap.Size = New System.Drawing.Size(84, 19)
        Me.opcCodSap.TabIndex = 0
        Me.opcCodSap.TabStop = True
        Me.opcCodSap.Text = "Código Sap"
        Me.opcCodSap.UseVisualStyleBackColor = True
        '
        'FrmBuscarInsumo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(594, 266)
        Me.Controls.Add(Me.Grpfiltro)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.grillaInsumos)
        Me.Name = "FrmBuscarInsumo"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Insumos"
        CType(Me.grillaInsumos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grpfiltro.ResumeLayout(False)
        Me.Grpfiltro.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grillaInsumos As System.Windows.Forms.DataGridView
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Grpfiltro As System.Windows.Forms.GroupBox
    Friend WithEvents opcDesc As System.Windows.Forms.RadioButton
    Friend WithEvents opcCodSap As System.Windows.Forms.RadioButton
End Class
