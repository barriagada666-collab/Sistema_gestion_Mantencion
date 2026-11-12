<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVerDatosTecnicos
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grillaDatosTecnicosAsoc = New System.Windows.Forms.DataGridView
        CType(Me.grillaDatosTecnicosAsoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grillaDatosTecnicosAsoc
        '
        Me.grillaDatosTecnicosAsoc.AllowUserToAddRows = False
        Me.grillaDatosTecnicosAsoc.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaDatosTecnicosAsoc.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grillaDatosTecnicosAsoc.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaDatosTecnicosAsoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grillaDatosTecnicosAsoc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grillaDatosTecnicosAsoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaDatosTecnicosAsoc.EnableHeadersVisualStyles = False
        Me.grillaDatosTecnicosAsoc.Location = New System.Drawing.Point(13, 52)
        Me.grillaDatosTecnicosAsoc.Name = "grillaDatosTecnicosAsoc"
        Me.grillaDatosTecnicosAsoc.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaDatosTecnicosAsoc.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grillaDatosTecnicosAsoc.RowHeadersWidth = 20
        Me.grillaDatosTecnicosAsoc.Size = New System.Drawing.Size(526, 319)
        Me.grillaDatosTecnicosAsoc.TabIndex = 0
        '
        'FrmVerDatosTecnicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(551, 383)
        Me.Controls.Add(Me.grillaDatosTecnicosAsoc)
        Me.MaximizeBox = False
        Me.Name = "FrmVerDatosTecnicos"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos Técnicos Asociados"
        CType(Me.grillaDatosTecnicosAsoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grillaDatosTecnicosAsoc As System.Windows.Forms.DataGridView
End Class
