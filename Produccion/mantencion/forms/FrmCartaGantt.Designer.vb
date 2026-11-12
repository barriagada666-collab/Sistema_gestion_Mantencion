<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCartaGantt
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grillaInfoGantt = New System.Windows.Forms.DataGridView
        Me.id_ciclo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.item = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.obs_ciclo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha_inicio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha_termino = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.duracion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grillaGraficoGantt = New System.Windows.Forms.DataGridView
        Me.btnExpExcel = New System.Windows.Forms.Button
        Me.btnSalirGantt = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblTituloGantt = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblDesdeGantt = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblHastaGantt = New System.Windows.Forms.Label
        CType(Me.grillaInfoGantt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grillaGraficoGantt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grillaInfoGantt
        '
        Me.grillaInfoGantt.AllowUserToAddRows = False
        Me.grillaInfoGantt.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grillaInfoGantt.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.grillaInfoGantt.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaInfoGantt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.grillaInfoGantt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaInfoGantt.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_ciclo, Me.item, Me.obs_ciclo, Me.fecha_inicio, Me.fecha_termino, Me.duracion})
        Me.grillaInfoGantt.EnableHeadersVisualStyles = False
        Me.grillaInfoGantt.Location = New System.Drawing.Point(12, 77)
        Me.grillaInfoGantt.Name = "grillaInfoGantt"
        Me.grillaInfoGantt.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaInfoGantt.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.grillaInfoGantt.RowHeadersWidth = 20
        Me.grillaInfoGantt.Size = New System.Drawing.Size(283, 572)
        Me.grillaInfoGantt.TabIndex = 0
        '
        'id_ciclo
        '
        Me.id_ciclo.HeaderText = "ID CICLO"
        Me.id_ciclo.Name = "id_ciclo"
        Me.id_ciclo.ReadOnly = True
        Me.id_ciclo.Width = 45
        '
        'item
        '
        Me.item.HeaderText = "Item / Maquina"
        Me.item.Name = "item"
        Me.item.ReadOnly = True
        '
        'obs_ciclo
        '
        Me.obs_ciclo.HeaderText = "Observacion Ciclo"
        Me.obs_ciclo.Name = "obs_ciclo"
        Me.obs_ciclo.ReadOnly = True
        '
        'fecha_inicio
        '
        Me.fecha_inicio.HeaderText = "Fecha Inicio"
        Me.fecha_inicio.Name = "fecha_inicio"
        Me.fecha_inicio.ReadOnly = True
        '
        'fecha_termino
        '
        Me.fecha_termino.HeaderText = "Fecha Término"
        Me.fecha_termino.Name = "fecha_termino"
        Me.fecha_termino.ReadOnly = True
        '
        'duracion
        '
        Me.duracion.HeaderText = "Duracion (Hrs)"
        Me.duracion.Name = "duracion"
        Me.duracion.ReadOnly = True
        Me.duracion.Width = 60
        '
        'grillaGraficoGantt
        '
        Me.grillaGraficoGantt.AllowUserToAddRows = False
        Me.grillaGraficoGantt.AllowUserToDeleteRows = False
        Me.grillaGraficoGantt.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaGraficoGantt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.grillaGraficoGantt.ColumnHeadersHeight = 35
        Me.grillaGraficoGantt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grillaGraficoGantt.EnableHeadersVisualStyles = False
        Me.grillaGraficoGantt.Location = New System.Drawing.Point(301, 77)
        Me.grillaGraficoGantt.Name = "grillaGraficoGantt"
        Me.grillaGraficoGantt.ReadOnly = True
        Me.grillaGraficoGantt.RowHeadersVisible = False
        Me.grillaGraficoGantt.RowHeadersWidth = 20
        Me.grillaGraficoGantt.Size = New System.Drawing.Size(703, 572)
        Me.grillaGraficoGantt.TabIndex = 1
        '
        'btnExpExcel
        '
        Me.btnExpExcel.BackgroundImage = Global.Mantencion.My.Resources.Resources.icono_excel1
        Me.btnExpExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnExpExcel.Location = New System.Drawing.Point(938, 24)
        Me.btnExpExcel.Name = "btnExpExcel"
        Me.btnExpExcel.Size = New System.Drawing.Size(30, 30)
        Me.btnExpExcel.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnExpExcel, "Exportar a Excel")
        Me.btnExpExcel.UseVisualStyleBackColor = True
        '
        'btnSalirGantt
        '
        Me.btnSalirGantt.BackgroundImage = Global.Mantencion.My.Resources.Resources.salir
        Me.btnSalirGantt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalirGantt.Location = New System.Drawing.Point(974, 24)
        Me.btnSalirGantt.Name = "btnSalirGantt"
        Me.btnSalirGantt.Size = New System.Drawing.Size(30, 30)
        Me.btnSalirGantt.TabIndex = 3
        Me.ToolTip2.SetToolTip(Me.btnSalirGantt, "Volver")
        Me.btnSalirGantt.UseVisualStyleBackColor = True
        '
        'lblTituloGantt
        '
        Me.lblTituloGantt.AutoSize = True
        Me.lblTituloGantt.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloGantt.Location = New System.Drawing.Point(304, 9)
        Me.lblTituloGantt.Name = "lblTituloGantt"
        Me.lblTituloGantt.Size = New System.Drawing.Size(119, 23)
        Me.lblTituloGantt.TabIndex = 4
        Me.lblTituloGantt.Text = "Informe gantt"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(305, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Desde:"
        '
        'lblDesdeGantt
        '
        Me.lblDesdeGantt.AutoSize = True
        Me.lblDesdeGantt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesdeGantt.Location = New System.Drawing.Point(354, 48)
        Me.lblDesdeGantt.Name = "lblDesdeGantt"
        Me.lblDesdeGantt.Size = New System.Drawing.Size(75, 15)
        Me.lblDesdeGantt.TabIndex = 6
        Me.lblDesdeGantt.Text = "fecha_desde"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(539, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Hasta:"
        '
        'lblHastaGantt
        '
        Me.lblHastaGantt.AutoSize = True
        Me.lblHastaGantt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHastaGantt.Location = New System.Drawing.Point(587, 48)
        Me.lblHastaGantt.Name = "lblHastaGantt"
        Me.lblHastaGantt.Size = New System.Drawing.Size(71, 15)
        Me.lblHastaGantt.TabIndex = 8
        Me.lblHastaGantt.Text = "fecha_hasta"
        '
        'FrmCartaGantt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(1016, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblHastaGantt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblDesdeGantt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTituloGantt)
        Me.Controls.Add(Me.btnSalirGantt)
        Me.Controls.Add(Me.btnExpExcel)
        Me.Controls.Add(Me.grillaGraficoGantt)
        Me.Controls.Add(Me.grillaInfoGantt)
        Me.Name = "FrmCartaGantt"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Visualización de Informe Gantt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grillaInfoGantt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grillaGraficoGantt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grillaInfoGantt As System.Windows.Forms.DataGridView
    Friend WithEvents grillaGraficoGantt As System.Windows.Forms.DataGridView
    Friend WithEvents btnExpExcel As System.Windows.Forms.Button
    Friend WithEvents btnSalirGantt As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents id_ciclo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents obs_ciclo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha_inicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha_termino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents duracion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTituloGantt As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDesdeGantt As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblHastaGantt As System.Windows.Forms.Label
End Class
