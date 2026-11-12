<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdminAuditoria
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
        Me.grillaAuditoria = New System.Windows.Forms.DataGridView
        Me.fecha_ini_aud = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.fecha_fin_aud = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_buscar_aud = New System.Windows.Forms.Button
        Me.btn_salir_aud = New System.Windows.Forms.Button
        Me.btn_exp_excel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.grillaAuditoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grillaAuditoria
        '
        Me.grillaAuditoria.AllowUserToAddRows = False
        Me.grillaAuditoria.AllowUserToDeleteRows = False
        Me.grillaAuditoria.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaAuditoria.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grillaAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaAuditoria.EnableHeadersVisualStyles = False
        Me.grillaAuditoria.Location = New System.Drawing.Point(12, 106)
        Me.grillaAuditoria.Name = "grillaAuditoria"
        Me.grillaAuditoria.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaAuditoria.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grillaAuditoria.RowHeadersWidth = 20
        Me.grillaAuditoria.Size = New System.Drawing.Size(843, 543)
        Me.grillaAuditoria.TabIndex = 0
        Me.grillaAuditoria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        'fecha_ini_aud
        '
        Me.fecha_ini_aud.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_ini_aud.CalendarTitleForeColor = System.Drawing.Color.White
        Me.fecha_ini_aud.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_ini_aud.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_ini_aud.Location = New System.Drawing.Point(12, 40)
        Me.fecha_ini_aud.Name = "fecha_ini_aud"
        Me.fecha_ini_aud.Size = New System.Drawing.Size(85, 20)
        Me.fecha_ini_aud.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha Inicio"
        '
        'fecha_fin_aud
        '
        Me.fecha_fin_aud.CalendarMonthBackground = System.Drawing.Color.White
        Me.fecha_fin_aud.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_fin_aud.CalendarTitleForeColor = System.Drawing.Color.White
        Me.fecha_fin_aud.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_fin_aud.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_fin_aud.Location = New System.Drawing.Point(115, 40)
        Me.fecha_fin_aud.Name = "fecha_fin_aud"
        Me.fecha_fin_aud.Size = New System.Drawing.Size(85, 20)
        Me.fecha_fin_aud.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(112, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha Término"
        '
        'btn_buscar_aud
        '
        Me.btn_buscar_aud.Image = Global.mantencion.My.Resources.Resources.icono_buscar1
        Me.btn_buscar_aud.Location = New System.Drawing.Point(26, 23)
        Me.btn_buscar_aud.Name = "btn_buscar_aud"
        Me.btn_buscar_aud.Size = New System.Drawing.Size(29, 29)
        Me.btn_buscar_aud.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btn_buscar_aud, "Buscar Datos")
        Me.btn_buscar_aud.UseVisualStyleBackColor = True
        '
        'btn_salir_aud
        '
        Me.btn_salir_aud.Image = Global.mantencion.My.Resources.Resources.salir
        Me.btn_salir_aud.Location = New System.Drawing.Point(96, 23)
        Me.btn_salir_aud.Name = "btn_salir_aud"
        Me.btn_salir_aud.Size = New System.Drawing.Size(29, 29)
        Me.btn_salir_aud.TabIndex = 6
        Me.ToolTip3.SetToolTip(Me.btn_salir_aud, "Salir")
        Me.btn_salir_aud.UseVisualStyleBackColor = True
        '
        'btn_exp_excel
        '
        Me.btn_exp_excel.Image = Global.mantencion.My.Resources.Resources.icono_excel1
        Me.btn_exp_excel.Location = New System.Drawing.Point(61, 23)
        Me.btn_exp_excel.Name = "btn_exp_excel"
        Me.btn_exp_excel.Size = New System.Drawing.Size(29, 29)
        Me.btn_exp_excel.TabIndex = 7
        Me.ToolTip2.SetToolTip(Me.btn_exp_excel, "Exportar a Excel")
        Me.btn_exp_excel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.fecha_ini_aud)
        Me.Panel1.Controls.Add(Me.fecha_fin_aud)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(12, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(216, 69)
        Me.Panel1.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Rango de Fechas"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btn_buscar_aud)
        Me.Panel2.Controls.Add(Me.btn_salir_aud)
        Me.Panel2.Controls.Add(Me.btn_exp_excel)
        Me.Panel2.Location = New System.Drawing.Point(705, 31)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(150, 69)
        Me.Panel2.TabIndex = 10
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(708, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 15)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Operaciones"
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        'FrmAdminAuditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(1016, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grillaAuditoria)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmAdminAuditoria"
        Me.ShowIcon = False
        Me.Text = "Auditoria de Operaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        CType(Me.grillaAuditoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grillaAuditoria As System.Windows.Forms.DataGridView
    Friend WithEvents fecha_ini_aud As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fecha_fin_aud As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_buscar_aud As System.Windows.Forms.Button
    Friend WithEvents btn_salir_aud As System.Windows.Forms.Button
    Friend WithEvents btn_exp_excel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
End Class
