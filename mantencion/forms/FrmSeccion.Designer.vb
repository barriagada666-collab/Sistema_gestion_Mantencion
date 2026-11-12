<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeccion
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
        Me.GrpSeccion = New System.Windows.Forms.GroupBox
        Me.btnBuscarSeccion = New System.Windows.Forms.Button
        Me.lblDescSeccion = New System.Windows.Forms.Label
        Me.txtDescSeccion = New System.Windows.Forms.TextBox
        Me.lblCodSeccion = New System.Windows.Forms.Label
        Me.txtCodSeccion = New System.Windows.Forms.TextBox
        Me.GrpOperaciones = New System.Windows.Forms.GroupBox
        Me.btn_salir_seccion = New System.Windows.Forms.Button
        Me.btnLimpiarSeccion = New System.Windows.Forms.Button
        Me.btnDelSeccion = New System.Windows.Forms.Button
        Me.btnUpdSeccion = New System.Windows.Forms.Button
        Me.btnIngSeccion = New System.Windows.Forms.Button
        Me.GrpSeccion.SuspendLayout()
        Me.GrpOperaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpSeccion
        '
        Me.GrpSeccion.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.GrpSeccion.Controls.Add(Me.btnBuscarSeccion)
        Me.GrpSeccion.Controls.Add(Me.lblDescSeccion)
        Me.GrpSeccion.Controls.Add(Me.txtDescSeccion)
        Me.GrpSeccion.Controls.Add(Me.lblCodSeccion)
        Me.GrpSeccion.Controls.Add(Me.txtCodSeccion)
        Me.GrpSeccion.Location = New System.Drawing.Point(13, 22)
        Me.GrpSeccion.Name = "GrpSeccion"
        Me.GrpSeccion.Size = New System.Drawing.Size(407, 100)
        Me.GrpSeccion.TabIndex = 0
        Me.GrpSeccion.TabStop = False
        Me.GrpSeccion.Text = "Información de Secciones"
        '
        'btnBuscarSeccion
        '
        Me.btnBuscarSeccion.Location = New System.Drawing.Point(326, 44)
        Me.btnBuscarSeccion.Name = "btnBuscarSeccion"
        Me.btnBuscarSeccion.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscarSeccion.TabIndex = 4
        Me.btnBuscarSeccion.Text = "Buscar"
        Me.btnBuscarSeccion.UseVisualStyleBackColor = True
        '
        'lblDescSeccion
        '
        Me.lblDescSeccion.AutoSize = True
        Me.lblDescSeccion.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescSeccion.Location = New System.Drawing.Point(140, 29)
        Me.lblDescSeccion.Name = "lblDescSeccion"
        Me.lblDescSeccion.Size = New System.Drawing.Size(51, 15)
        Me.lblDescSeccion.TabIndex = 3
        Me.lblDescSeccion.Text = "Nombre"
        '
        'txtDescSeccion
        '
        Me.txtDescSeccion.Location = New System.Drawing.Point(140, 46)
        Me.txtDescSeccion.Name = "txtDescSeccion"
        Me.txtDescSeccion.Size = New System.Drawing.Size(157, 20)
        Me.txtDescSeccion.TabIndex = 2
        '
        'lblCodSeccion
        '
        Me.lblCodSeccion.AutoSize = True
        Me.lblCodSeccion.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodSeccion.Location = New System.Drawing.Point(6, 30)
        Me.lblCodSeccion.Name = "lblCodSeccion"
        Me.lblCodSeccion.Size = New System.Drawing.Size(45, 15)
        Me.lblCodSeccion.TabIndex = 1
        Me.lblCodSeccion.Text = "Código"
        '
        'txtCodSeccion
        '
        Me.txtCodSeccion.Location = New System.Drawing.Point(6, 46)
        Me.txtCodSeccion.Name = "txtCodSeccion"
        Me.txtCodSeccion.Size = New System.Drawing.Size(100, 20)
        Me.txtCodSeccion.TabIndex = 0
        '
        'GrpOperaciones
        '
        Me.GrpOperaciones.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.GrpOperaciones.Controls.Add(Me.btn_salir_seccion)
        Me.GrpOperaciones.Controls.Add(Me.btnLimpiarSeccion)
        Me.GrpOperaciones.Controls.Add(Me.btnDelSeccion)
        Me.GrpOperaciones.Controls.Add(Me.btnUpdSeccion)
        Me.GrpOperaciones.Controls.Add(Me.btnIngSeccion)
        Me.GrpOperaciones.Location = New System.Drawing.Point(13, 135)
        Me.GrpOperaciones.Name = "GrpOperaciones"
        Me.GrpOperaciones.Size = New System.Drawing.Size(183, 71)
        Me.GrpOperaciones.TabIndex = 1
        Me.GrpOperaciones.TabStop = False
        Me.GrpOperaciones.Text = "Operaciones"
        '
        'btn_salir_seccion
        '
        Me.btn_salir_seccion.Image = Global.mantencion.My.Resources.Resources.salir
        Me.btn_salir_seccion.Location = New System.Drawing.Point(143, 24)
        Me.btn_salir_seccion.Name = "btn_salir_seccion"
        Me.btn_salir_seccion.Size = New System.Drawing.Size(29, 29)
        Me.btn_salir_seccion.TabIndex = 4
        Me.btn_salir_seccion.UseVisualStyleBackColor = True
        '
        'btnLimpiarSeccion
        '
        Me.btnLimpiarSeccion.Image = Global.mantencion.My.Resources.Resources.clear
        Me.btnLimpiarSeccion.Location = New System.Drawing.Point(107, 24)
        Me.btnLimpiarSeccion.Name = "btnLimpiarSeccion"
        Me.btnLimpiarSeccion.Size = New System.Drawing.Size(29, 29)
        Me.btnLimpiarSeccion.TabIndex = 3
        Me.btnLimpiarSeccion.UseVisualStyleBackColor = True
        '
        'btnDelSeccion
        '
        Me.btnDelSeccion.Image = Global.mantencion.My.Resources.Resources.eliminar
        Me.btnDelSeccion.Location = New System.Drawing.Point(72, 24)
        Me.btnDelSeccion.Name = "btnDelSeccion"
        Me.btnDelSeccion.Size = New System.Drawing.Size(29, 29)
        Me.btnDelSeccion.TabIndex = 2
        Me.btnDelSeccion.UseVisualStyleBackColor = True
        '
        'btnUpdSeccion
        '
        Me.btnUpdSeccion.Image = Global.mantencion.My.Resources.Resources.guardar
        Me.btnUpdSeccion.Location = New System.Drawing.Point(37, 24)
        Me.btnUpdSeccion.Name = "btnUpdSeccion"
        Me.btnUpdSeccion.Size = New System.Drawing.Size(29, 29)
        Me.btnUpdSeccion.TabIndex = 1
        Me.btnUpdSeccion.UseVisualStyleBackColor = True
        '
        'btnIngSeccion
        '
        Me.btnIngSeccion.Image = Global.mantencion.My.Resources.Resources.icono_escritura
        Me.btnIngSeccion.Location = New System.Drawing.Point(2, 24)
        Me.btnIngSeccion.Name = "btnIngSeccion"
        Me.btnIngSeccion.Size = New System.Drawing.Size(29, 29)
        Me.btnIngSeccion.TabIndex = 0
        Me.btnIngSeccion.UseVisualStyleBackColor = True
        '
        'FrmSeccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(1020, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpOperaciones)
        Me.Controls.Add(Me.GrpSeccion)
        Me.Name = "FrmSeccion"
        Me.ShowIcon = False
        Me.Text = "Mantenedor de Secciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.GrpSeccion.ResumeLayout(False)
        Me.GrpSeccion.PerformLayout()
        Me.GrpOperaciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpSeccion As System.Windows.Forms.GroupBox
    Friend WithEvents lblDescSeccion As System.Windows.Forms.Label
    Friend WithEvents txtDescSeccion As System.Windows.Forms.TextBox
    Friend WithEvents lblCodSeccion As System.Windows.Forms.Label
    Friend WithEvents txtCodSeccion As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarSeccion As System.Windows.Forms.Button
    Friend WithEvents GrpOperaciones As System.Windows.Forms.GroupBox
    Friend WithEvents btnLimpiarSeccion As System.Windows.Forms.Button
    Friend WithEvents btnDelSeccion As System.Windows.Forms.Button
    Friend WithEvents btnUpdSeccion As System.Windows.Forms.Button
    Friend WithEvents btnIngSeccion As System.Windows.Forms.Button
    Friend WithEvents btn_salir_seccion As System.Windows.Forms.Button
End Class
