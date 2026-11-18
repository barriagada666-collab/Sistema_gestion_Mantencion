<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfMantPrevCiclosMaq
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Arbol7 = New System.Windows.Forms.TreeView
        Me.txtBuscarNodo7 = New System.Windows.Forms.TextBox
        Me.grillaCiclosMaquinas = New System.Windows.Forms.DataGridView
        Me.fecha_ini_inf_mp = New System.Windows.Forms.DateTimePicker
        Me.fecha_fin_inf_mp = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnBuscarCiclos = New System.Windows.Forms.Button
        Me.btnSalirInfMp = New System.Windows.Forms.Button
        Me.btnExpGantt = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnExpPdfListado = New System.Windows.Forms.Button
        Me.btnExpListado = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip4 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmbTipoMpGantt = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.grillaCiclosMaquinas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Arbol7
        '
        Me.Arbol7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Arbol7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Arbol7.Location = New System.Drawing.Point(12, 33)
        Me.Arbol7.Name = "Arbol7"
        Me.Arbol7.Size = New System.Drawing.Size(220, 616)
        Me.Arbol7.TabIndex = 0
        '
        'txtBuscarNodo7
        '
        Me.txtBuscarNodo7.Location = New System.Drawing.Point(13, 8)
        Me.txtBuscarNodo7.Name = "txtBuscarNodo7"
        Me.txtBuscarNodo7.Size = New System.Drawing.Size(219, 20)
        Me.txtBuscarNodo7.TabIndex = 1
        '
        'grillaCiclosMaquinas
        '
        Me.grillaCiclosMaquinas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grillaCiclosMaquinas.AllowUserToAddRows = False
        Me.grillaCiclosMaquinas.AllowUserToDeleteRows = False
        Me.grillaCiclosMaquinas.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaCiclosMaquinas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grillaCiclosMaquinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaCiclosMaquinas.EnableHeadersVisualStyles = False
        Me.grillaCiclosMaquinas.Location = New System.Drawing.Point(259, 86)
        Me.grillaCiclosMaquinas.Name = "grillaCiclosMaquinas"
        Me.grillaCiclosMaquinas.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaCiclosMaquinas.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grillaCiclosMaquinas.RowHeadersWidth = 20
        Me.grillaCiclosMaquinas.Size = New System.Drawing.Size(749, 563)
        Me.grillaCiclosMaquinas.TabIndex = 2
        '
        'fecha_ini_inf_mp
        '
        Me.fecha_ini_inf_mp.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_ini_inf_mp.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_ini_inf_mp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_ini_inf_mp.Location = New System.Drawing.Point(6, 35)
        Me.fecha_ini_inf_mp.Name = "fecha_ini_inf_mp"
        Me.fecha_ini_inf_mp.Size = New System.Drawing.Size(106, 23)
        Me.fecha_ini_inf_mp.TabIndex = 3
        '
        'fecha_fin_inf_mp
        '
        Me.fecha_fin_inf_mp.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_fin_inf_mp.CalendarTitleForeColor = System.Drawing.Color.White
        Me.fecha_fin_inf_mp.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_fin_inf_mp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_fin_inf_mp.Location = New System.Drawing.Point(120, 35)
        Me.fecha_fin_inf_mp.Name = "fecha_fin_inf_mp"
        Me.fecha_fin_inf_mp.Size = New System.Drawing.Size(106, 23)
        Me.fecha_fin_inf_mp.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Fecha Inicio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(117, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Fecha Fin"
        '
        'btnBuscarCiclos
        '
        Me.btnBuscarCiclos.Image = Global.mantencion.My.Resources.Resources.icono_buscar1
        Me.btnBuscarCiclos.Location = New System.Drawing.Point(4, 17)
        Me.btnBuscarCiclos.Name = "btnBuscarCiclos"
        Me.btnBuscarCiclos.Size = New System.Drawing.Size(30, 30)
        Me.btnBuscarCiclos.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btnBuscarCiclos, "Buscar Ciclos")
        Me.btnBuscarCiclos.UseVisualStyleBackColor = True
        '
        'btnSalirInfMp
        '
        Me.btnSalirInfMp.BackgroundImage = Global.mantencion.My.Resources.Resources.salir
        Me.btnSalirInfMp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalirInfMp.Location = New System.Drawing.Point(148, 17)
        Me.btnSalirInfMp.Name = "btnSalirInfMp"
        Me.btnSalirInfMp.Size = New System.Drawing.Size(30, 30)
        Me.btnSalirInfMp.TabIndex = 8
        Me.ToolTip3.SetToolTip(Me.btnSalirInfMp, "Salir")
        Me.btnSalirInfMp.UseVisualStyleBackColor = True
        '
        'btnExpGantt
        '
        Me.btnExpGantt.BackgroundImage = Global.mantencion.My.Resources.Resources.Ícono__Gantt
        Me.btnExpGantt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnExpGantt.Location = New System.Drawing.Point(112, 17)
        Me.btnExpGantt.Name = "btnExpGantt"
        Me.btnExpGantt.Size = New System.Drawing.Size(30, 30)
        Me.btnExpGantt.TabIndex = 9
        Me.ToolTip2.SetToolTip(Me.btnExpGantt, "Reporte Y Gráfico Gantt")
        Me.btnExpGantt.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnExpPdfListado)
        Me.Panel1.Controls.Add(Me.btnExpListado)
        Me.Panel1.Controls.Add(Me.btnSalirInfMp)
        Me.Panel1.Controls.Add(Me.btnExpGantt)
        Me.Panel1.Controls.Add(Me.btnBuscarCiclos)
        Me.Panel1.Location = New System.Drawing.Point(824, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(184, 52)
        Me.Panel1.TabIndex = 10
        '
        'btnExpPdfListado
        '
        Me.btnExpPdfListado.BackgroundImage = Global.mantencion.My.Resources.Resources.icono_pdf
        Me.btnExpPdfListado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnExpPdfListado.Location = New System.Drawing.Point(76, 17)
        Me.btnExpPdfListado.Name = "btnExpPdfListado"
        Me.btnExpPdfListado.Size = New System.Drawing.Size(30, 30)
        Me.btnExpPdfListado.TabIndex = 11
        Me.ToolTip4.SetToolTip(Me.btnExpPdfListado, "Exportar listado de ciclos a PDF")
        Me.btnExpPdfListado.UseVisualStyleBackColor = True
        '
        'btnExpListado
        '
        Me.btnExpListado.Image = Global.mantencion.My.Resources.Resources.icono_excel1
        Me.btnExpListado.Location = New System.Drawing.Point(40, 17)
        Me.btnExpListado.Name = "btnExpListado"
        Me.btnExpListado.Size = New System.Drawing.Size(30, 30)
        Me.btnExpListado.TabIndex = 10
        Me.ToolTip4.SetToolTip(Me.btnExpListado, "Exportar listado de ciclos")
        Me.btnExpListado.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.cmbTipoMpGantt)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.fecha_ini_inf_mp)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.fecha_fin_inf_mp)
        Me.Panel2.Location = New System.Drawing.Point(259, 15)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(388, 65)
        Me.Panel2.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(827, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Operaciones"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(265, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Rango de Fechas"
        '
        'cmbTipoMpGantt
        '
        Me.cmbTipoMpGantt.FormattingEnabled = True
        Me.cmbTipoMpGantt.Location = New System.Drawing.Point(236, 35)
        Me.cmbTipoMpGantt.Name = "cmbTipoMpGantt"
        Me.cmbTipoMpGantt.Size = New System.Drawing.Size(140, 23)
        Me.cmbTipoMpGantt.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(233, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Tipo de mantención"
        '
        'FrmInfMantPrevCiclosMaq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(1020, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.grillaCiclosMaquinas)
        Me.Controls.Add(Me.txtBuscarNodo7)
        Me.Controls.Add(Me.Arbol7)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmInfMantPrevCiclosMaq"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Informe Ciclos Mantención Preventiva"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        CType(Me.grillaCiclosMaquinas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Arbol7 As System.Windows.Forms.TreeView
    Friend WithEvents txtBuscarNodo7 As System.Windows.Forms.TextBox
    Friend WithEvents grillaCiclosMaquinas As System.Windows.Forms.DataGridView
    Friend WithEvents fecha_ini_inf_mp As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecha_fin_inf_mp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCiclos As System.Windows.Forms.Button
    Friend WithEvents btnSalirInfMp As System.Windows.Forms.Button
    Friend WithEvents btnExpGantt As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents btnExpListado As System.Windows.Forms.Button
    Friend WithEvents btnExpPdfListado As System.Windows.Forms.Button
    Friend WithEvents ToolTip4 As System.Windows.Forms.ToolTip
    Friend WithEvents cmbTipoMpGantt As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
