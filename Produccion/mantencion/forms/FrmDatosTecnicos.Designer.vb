<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDatosTecnicos
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnBuscarDatos = New System.Windows.Forms.Button
        Me.btnNuevoDato = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.opcDatoDesactivado = New System.Windows.Forms.RadioButton
        Me.opcDatoActivado = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDescDatoTecnico = New System.Windows.Forms.TextBox
        Me.txtIdDatoTecnico = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip4 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.ToolTip5 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnBuscarDatos)
        Me.Panel1.Controls.Add(Me.btnNuevoDato)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtDescDatoTecnico)
        Me.Panel1.Controls.Add(Me.txtIdDatoTecnico)
        Me.Panel1.Location = New System.Drawing.Point(12, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(577, 73)
        Me.Panel1.TabIndex = 0
        '
        'btnBuscarDatos
        '
        Me.btnBuscarDatos.Image = Global.Mantencion.My.Resources.Resources.icono_buscar1
        Me.btnBuscarDatos.Location = New System.Drawing.Point(533, 14)
        Me.btnBuscarDatos.Name = "btnBuscarDatos"
        Me.btnBuscarDatos.Size = New System.Drawing.Size(29, 29)
        Me.btnBuscarDatos.TabIndex = 7
        Me.ToolTip5.SetToolTip(Me.btnBuscarDatos, "Buscar Datos Técnicos")
        Me.btnBuscarDatos.UseVisualStyleBackColor = True
        '
        'btnNuevoDato
        '
        Me.btnNuevoDato.Image = Global.Mantencion.My.Resources.Resources.nuevo_documento_24x24
        Me.btnNuevoDato.Location = New System.Drawing.Point(497, 14)
        Me.btnNuevoDato.Name = "btnNuevoDato"
        Me.btnNuevoDato.Size = New System.Drawing.Size(29, 29)
        Me.btnNuevoDato.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.btnNuevoDato, "Nuevo Dato Técnico")
        Me.btnNuevoDato.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(339, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Estado"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.opcDatoDesactivado)
        Me.Panel3.Controls.Add(Me.opcDatoActivado)
        Me.Panel3.Location = New System.Drawing.Point(334, 14)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(157, 46)
        Me.Panel3.TabIndex = 4
        '
        'opcDatoDesactivado
        '
        Me.opcDatoDesactivado.AutoSize = True
        Me.opcDatoDesactivado.Location = New System.Drawing.Point(66, 15)
        Me.opcDatoDesactivado.Name = "opcDatoDesactivado"
        Me.opcDatoDesactivado.Size = New System.Drawing.Size(85, 17)
        Me.opcDatoDesactivado.TabIndex = 1
        Me.opcDatoDesactivado.Text = "Desactivado"
        Me.opcDatoDesactivado.UseVisualStyleBackColor = True
        '
        'opcDatoActivado
        '
        Me.opcDatoActivado.AutoSize = True
        Me.opcDatoActivado.Checked = True
        Me.opcDatoActivado.Location = New System.Drawing.Point(4, 15)
        Me.opcDatoActivado.Name = "opcDatoActivado"
        Me.opcDatoActivado.Size = New System.Drawing.Size(55, 17)
        Me.opcDatoActivado.TabIndex = 0
        Me.opcDatoActivado.TabStop = True
        Me.opcDatoActivado.Text = "Activo"
        Me.opcDatoActivado.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripción"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Código"
        '
        'txtDescDatoTecnico
        '
        Me.txtDescDatoTecnico.Location = New System.Drawing.Point(88, 40)
        Me.txtDescDatoTecnico.Name = "txtDescDatoTecnico"
        Me.txtDescDatoTecnico.Size = New System.Drawing.Size(222, 20)
        Me.txtDescDatoTecnico.TabIndex = 1
        '
        'txtIdDatoTecnico
        '
        Me.txtIdDatoTecnico.BackColor = System.Drawing.Color.White
        Me.txtIdDatoTecnico.Enabled = False
        Me.txtIdDatoTecnico.Location = New System.Drawing.Point(4, 40)
        Me.txtIdDatoTecnico.Name = "txtIdDatoTecnico"
        Me.txtIdDatoTecnico.Size = New System.Drawing.Size(63, 20)
        Me.txtIdDatoTecnico.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnSalir)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Location = New System.Drawing.Point(12, 119)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(126, 74)
        Me.Panel2.TabIndex = 1
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Mantencion.My.Resources.Resources.salir
        Me.btnSalir.Location = New System.Drawing.Point(78, 22)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(29, 29)
        Me.btnSalir.TabIndex = 2
        Me.ToolTip4.SetToolTip(Me.btnSalir, "Salir")
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Mantencion.My.Resources.Resources.clear
        Me.btnLimpiar.Location = New System.Drawing.Point(42, 22)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(29, 29)
        Me.btnLimpiar.TabIndex = 1
        Me.ToolTip3.SetToolTip(Me.btnLimpiar, "Limpiar Campos")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Mantencion.My.Resources.Resources.guardar
        Me.btnGuardar.Location = New System.Drawing.Point(7, 22)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(29, 29)
        Me.btnGuardar.TabIndex = 0
        Me.ToolTip2.SetToolTip(Me.btnGuardar, "Guardar")
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Información Datos Técnicos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 15)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Operaciones"
        '
        'FrmDatosTecnicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(1020, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmDatosTecnicos"
        Me.ShowIcon = False
        Me.Text = "Gestión Datos Técnicos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtIdDatoTecnico As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents opcDatoActivado As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescDatoTecnico As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents opcDatoDesactivado As System.Windows.Forms.RadioButton
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnNuevoDato As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip4 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarDatos As System.Windows.Forms.Button
    Friend WithEvents ToolTip5 As System.Windows.Forms.ToolTip
End Class
