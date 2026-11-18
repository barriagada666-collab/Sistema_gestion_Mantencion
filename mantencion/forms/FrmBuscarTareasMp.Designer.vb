<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscarTareasMp
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grillaTareasNodoMp = New System.Windows.Forms.DataGridView
        Me.seleccion_tarea = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.txtFiltroTarea = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAgrTareas = New System.Windows.Forms.Button
        CType(Me.grillaTareasNodoMp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grillaTareasNodoMp
        '
        Me.grillaTareasNodoMp.AllowUserToAddRows = False
        Me.grillaTareasNodoMp.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaTareasNodoMp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.grillaTareasNodoMp.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaTareasNodoMp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grillaTareasNodoMp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.grillaTareasNodoMp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaTareasNodoMp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.seleccion_tarea})
        Me.grillaTareasNodoMp.EnableHeadersVisualStyles = False
        Me.grillaTareasNodoMp.Location = New System.Drawing.Point(12, 67)
        Me.grillaTareasNodoMp.Name = "grillaTareasNodoMp"
        Me.grillaTareasNodoMp.RowHeadersVisible = False
        Me.grillaTareasNodoMp.Size = New System.Drawing.Size(668, 227)
        Me.grillaTareasNodoMp.TabIndex = 0
        '
        'seleccion_tarea
        '
        Me.seleccion_tarea.HeaderText = "Sel."
        Me.seleccion_tarea.Name = "seleccion_tarea"
        Me.seleccion_tarea.Width = 30
        '
        'txtFiltroTarea
        '
        Me.txtFiltroTarea.Location = New System.Drawing.Point(12, 31)
        Me.txtFiltroTarea.MaxLength = 250
        Me.txtFiltroTarea.Name = "txtFiltroTarea"
        Me.txtFiltroTarea.Size = New System.Drawing.Size(264, 20)
        Me.txtFiltroTarea.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(229, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ingrese el nombre de la tarea para filtrar"
        '
        'btnAgrTareas
        '
        Me.btnAgrTareas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgrTareas.Image = Global.mantencion.My.Resources.Resources.add
        Me.btnAgrTareas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgrTareas.Location = New System.Drawing.Point(555, 34)
        Me.btnAgrTareas.Name = "btnAgrTareas"
        Me.btnAgrTareas.Size = New System.Drawing.Size(125, 26)
        Me.btnAgrTareas.TabIndex = 3
        Me.btnAgrTareas.Text = "Agregar Tareas"
        Me.btnAgrTareas.UseVisualStyleBackColor = True
        '
        'FrmBuscarTareasMp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(692, 306)
        Me.Controls.Add(Me.btnAgrTareas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFiltroTarea)
        Me.Controls.Add(Me.grillaTareasNodoMp)
        Me.MaximizeBox = False
        Me.Name = "FrmBuscarTareasMp"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Tareas Mantención Preventiva"
        CType(Me.grillaTareasNodoMp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grillaTareasNodoMp As System.Windows.Forms.DataGridView
    Friend WithEvents seleccion_tarea As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents txtFiltroTarea As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAgrTareas As System.Windows.Forms.Button
End Class
