<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlanificarCiclos
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
        Me.txtFrecuenciaPlan = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbNumCiclos = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtUltimoCiclo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.fecha_inicio_ult_ciclo = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnCrearCiclos = New System.Windows.Forms.Button
        Me.grillaVistaPrevia = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnCrearVistaPrevia = New System.Windows.Forms.Button
        Me.txtDuracionPlan = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.num_ciclo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha_inicio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha_fin = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.duracion_ciclo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha_fin_ult_ciclo = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.grillaVistaPrevia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFrecuenciaPlan
        '
        Me.txtFrecuenciaPlan.BackColor = System.Drawing.Color.FromArgb(215, 230, 234)
        Me.txtFrecuenciaPlan.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.txtFrecuenciaPlan.ReadOnly = True
        Me.txtFrecuenciaPlan.Location = New System.Drawing.Point(121, 33)
        Me.txtFrecuenciaPlan.Name = "txtFrecuenciaPlan"
        Me.txtFrecuenciaPlan.Size = New System.Drawing.Size(89, 20)
        Me.txtFrecuenciaPlan.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(120, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Frecuencia(Hrs)"
        '
        'cmbNumCiclos
        '
        Me.cmbNumCiclos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNumCiclos.FormattingEnabled = True
        Me.cmbNumCiclos.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbNumCiclos.Location = New System.Drawing.Point(337, 34)
        Me.cmbNumCiclos.Name = "cmbNumCiclos"
        Me.cmbNumCiclos.Size = New System.Drawing.Size(90, 21)
        Me.cmbNumCiclos.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(334, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "N° Ciclos a Planificar"
        '
        'txtUltimoCiclo
        '
        Me.txtUltimoCiclo.BackColor = System.Drawing.Color.FromArgb(215, 230, 234)
        Me.txtUltimoCiclo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.txtUltimoCiclo.ReadOnly = True
        Me.txtUltimoCiclo.Location = New System.Drawing.Point(15, 33)
        Me.txtUltimoCiclo.Name = "txtUltimoCiclo"
        Me.txtUltimoCiclo.Size = New System.Drawing.Size(77, 20)
        Me.txtUltimoCiclo.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "N° Último Ciclo"
        '
        'fecha_inicio_ult_ciclo
        '
        Me.fecha_inicio_ult_ciclo.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_inicio_ult_ciclo.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_inicio_ult_ciclo.CustomFormat = "dd-MM-yyyy HH:mm"
        Me.fecha_inicio_ult_ciclo.Enabled = False
        Me.fecha_inicio_ult_ciclo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fecha_inicio_ult_ciclo.Location = New System.Drawing.Point(15, 95)
        Me.fecha_inicio_ult_ciclo.Name = "fecha_inicio_ult_ciclo"
        Me.fecha_inicio_ult_ciclo.Size = New System.Drawing.Size(112, 20)
        Me.fecha_inicio_ult_ciclo.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 30)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Fecha/Hora Inicio " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Último Ciclo"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Image = Global.mantencion.My.Resources.Resources._16__Delete_
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(375, 452)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(90, 23)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "   Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnCrearCiclos
        '
        Me.btnCrearCiclos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCrearCiclos.Image = Global.mantencion.My.Resources.Resources.add
        Me.btnCrearCiclos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCrearCiclos.Location = New System.Drawing.Point(279, 452)
        Me.btnCrearCiclos.Name = "btnCrearCiclos"
        Me.btnCrearCiclos.Size = New System.Drawing.Size(90, 23)
        Me.btnCrearCiclos.TabIndex = 8
        Me.btnCrearCiclos.Text = "     Crear Ciclos"
        Me.btnCrearCiclos.UseVisualStyleBackColor = True
        '
        'grillaVistaPrevia
        '
        Me.grillaVistaPrevia.AllowUserToAddRows = False
        Me.grillaVistaPrevia.AllowUserToDeleteRows = False
        Me.grillaVistaPrevia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grillaVistaPrevia.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaVistaPrevia.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grillaVistaPrevia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaVistaPrevia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.num_ciclo, Me.fecha_inicio, Me.fecha_fin, Me.duracion_ciclo})
        Me.grillaVistaPrevia.EnableHeadersVisualStyles = False
        Me.grillaVistaPrevia.Location = New System.Drawing.Point(12, 160)
        Me.grillaVistaPrevia.Name = "grillaVistaPrevia"
        Me.grillaVistaPrevia.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaVistaPrevia.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.grillaVistaPrevia.RowHeadersWidth = 20
        Me.grillaVistaPrevia.Size = New System.Drawing.Size(454, 276)
        Me.grillaVistaPrevia.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Vista Previa"
        '
        'btnCrearVistaPrevia
        '
        Me.btnCrearVistaPrevia.Location = New System.Drawing.Point(362, 131)
        Me.btnCrearVistaPrevia.Name = "btnCrearVistaPrevia"
        Me.btnCrearVistaPrevia.Size = New System.Drawing.Size(103, 23)
        Me.btnCrearVistaPrevia.TabIndex = 12
        Me.btnCrearVistaPrevia.Text = "Crear Vista Previa"
        Me.btnCrearVistaPrevia.UseVisualStyleBackColor = True
        '
        'txtDuracionPlan
        '
        Me.txtDuracionPlan.BackColor = System.Drawing.Color.FromArgb(215, 230, 234)
        Me.txtDuracionPlan.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.txtDuracionPlan.ReadOnly = True
        Me.txtDuracionPlan.Location = New System.Drawing.Point(234, 33)
        Me.txtDuracionPlan.Name = "txtDuracionPlan"
        Me.txtDuracionPlan.Size = New System.Drawing.Size(79, 20)
        Me.txtDuracionPlan.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(231, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 15)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Duración(Hrs)"
        '
        'num_ciclo
        '
        Me.num_ciclo.HeaderText = "N°Ciclo"
        Me.num_ciclo.Name = "num_ciclo"
        Me.num_ciclo.ReadOnly = True
        Me.num_ciclo.Width = 60
        '
        'fecha_inicio
        '
        Me.fecha_inicio.HeaderText = "Fecha Inicio"
        Me.fecha_inicio.Name = "fecha_inicio"
        Me.fecha_inicio.ReadOnly = True
        Me.fecha_inicio.Width = 120
        '
        'fecha_fin
        '
        Me.fecha_fin.HeaderText = "Fecha Fin"
        Me.fecha_fin.Name = "fecha_fin"
        Me.fecha_fin.ReadOnly = True
        Me.fecha_fin.Width = 120
        '
        'duracion_ciclo
        '
        Me.duracion_ciclo.HeaderText = "Duración(Hrs)"
        Me.duracion_ciclo.Name = "duracion_ciclo"
        Me.duracion_ciclo.ReadOnly = True
        '
        'fecha_fin_ult_ciclo
        '
        Me.fecha_fin_ult_ciclo.CustomFormat = "dd-MM-yyyy HH:mm"
        Me.fecha_fin_ult_ciclo.Enabled = False
        Me.fecha_fin_ult_ciclo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fecha_fin_ult_ciclo.Location = New System.Drawing.Point(162, 95)
        Me.fecha_fin_ult_ciclo.Name = "fecha_fin_ult_ciclo"
        Me.fecha_fin_ult_ciclo.Size = New System.Drawing.Size(114, 20)
        Me.fecha_fin_ult_ciclo.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(159, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 30)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Fecha/Hora Fin" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Último Ciclo"
        '
        'FrmPlanificarCiclos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(478, 487)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.fecha_fin_ult_ciclo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDuracionPlan)
        Me.Controls.Add(Me.btnCrearVistaPrevia)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.grillaVistaPrevia)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnCrearCiclos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.fecha_inicio_ult_ciclo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtUltimoCiclo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbNumCiclos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFrecuenciaPlan)
        Me.MaximizeBox = False
        Me.Name = "FrmPlanificarCiclos"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planificación de Ciclos Mantenciones Preventivas"
        CType(Me.grillaVistaPrevia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFrecuenciaPlan As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbNumCiclos As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUltimoCiclo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents fecha_inicio_ult_ciclo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCrearCiclos As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents grillaVistaPrevia As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCrearVistaPrevia As System.Windows.Forms.Button
    Friend WithEvents txtDuracionPlan As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents num_ciclo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha_inicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha_fin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents duracion_ciclo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha_fin_ult_ciclo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
