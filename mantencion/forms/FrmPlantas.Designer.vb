<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlantas
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
        Me.GrpInfoPlanta = New System.Windows.Forms.GroupBox
        Me.btnBuscarPlanta = New System.Windows.Forms.Button
        Me.LblNomPlanta = New System.Windows.Forms.Label
        Me.txtNomPlanta = New System.Windows.Forms.TextBox
        Me.LblCodPlanta = New System.Windows.Forms.Label
        Me.txtCodPlanta = New System.Windows.Forms.TextBox
        Me.GrpOperaciones = New System.Windows.Forms.GroupBox
        Me.btnLimpiarFrmPlanta = New System.Windows.Forms.Button
        Me.btnDelPlanta = New System.Windows.Forms.Button
        Me.btnActPlanta = New System.Windows.Forms.Button
        Me.btnIngPlanta = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.GrpInfoPlanta.SuspendLayout()
        Me.GrpOperaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpInfoPlanta
        '
        Me.GrpInfoPlanta.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.GrpInfoPlanta.Controls.Add(Me.btnBuscarPlanta)
        Me.GrpInfoPlanta.Controls.Add(Me.LblNomPlanta)
        Me.GrpInfoPlanta.Controls.Add(Me.txtNomPlanta)
        Me.GrpInfoPlanta.Controls.Add(Me.LblCodPlanta)
        Me.GrpInfoPlanta.Controls.Add(Me.txtCodPlanta)
        Me.GrpInfoPlanta.Location = New System.Drawing.Point(12, 12)
        Me.GrpInfoPlanta.Name = "GrpInfoPlanta"
        Me.GrpInfoPlanta.Size = New System.Drawing.Size(468, 77)
        Me.GrpInfoPlanta.TabIndex = 0
        Me.GrpInfoPlanta.TabStop = False
        Me.GrpInfoPlanta.Text = "Información Planta"
        '
        'btnBuscarPlanta
        '
        Me.btnBuscarPlanta.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarPlanta.Image = Global.mantencion.My.Resources.Resources._16__Find_
        Me.btnBuscarPlanta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarPlanta.Location = New System.Drawing.Point(362, 34)
        Me.btnBuscarPlanta.Name = "btnBuscarPlanta"
        Me.btnBuscarPlanta.Size = New System.Drawing.Size(92, 26)
        Me.btnBuscarPlanta.TabIndex = 2
        Me.btnBuscarPlanta.Text = "Buscar"
        Me.btnBuscarPlanta.UseVisualStyleBackColor = True
        '
        'LblNomPlanta
        '
        Me.LblNomPlanta.AutoSize = True
        Me.LblNomPlanta.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNomPlanta.Location = New System.Drawing.Point(171, 20)
        Me.LblNomPlanta.Name = "LblNomPlanta"
        Me.LblNomPlanta.Size = New System.Drawing.Size(73, 15)
        Me.LblNomPlanta.TabIndex = 3
        Me.LblNomPlanta.Text = "Descripción"
        '
        'txtNomPlanta
        '
        Me.txtNomPlanta.BackColor = System.Drawing.Color.White
        Me.txtNomPlanta.Location = New System.Drawing.Point(171, 39)
        Me.txtNomPlanta.MaxLength = 20
        Me.txtNomPlanta.Name = "txtNomPlanta"
        Me.txtNomPlanta.Size = New System.Drawing.Size(179, 20)
        Me.txtNomPlanta.TabIndex = 2
        '
        'LblCodPlanta
        '
        Me.LblCodPlanta.AutoSize = True
        Me.LblCodPlanta.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodPlanta.Location = New System.Drawing.Point(7, 20)
        Me.LblCodPlanta.Name = "LblCodPlanta"
        Me.LblCodPlanta.Size = New System.Drawing.Size(45, 15)
        Me.LblCodPlanta.TabIndex = 1
        Me.LblCodPlanta.Text = "Código"
        '
        'txtCodPlanta
        '
        Me.txtCodPlanta.BackColor = System.Drawing.Color.White
        Me.txtCodPlanta.Location = New System.Drawing.Point(7, 39)
        Me.txtCodPlanta.Name = "txtCodPlanta"
        Me.txtCodPlanta.Size = New System.Drawing.Size(127, 20)
        Me.txtCodPlanta.TabIndex = 0
        '
        'GrpOperaciones
        '
        Me.GrpOperaciones.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.GrpOperaciones.Controls.Add(Me.btn_salir)
        Me.GrpOperaciones.Controls.Add(Me.btnLimpiarFrmPlanta)
        Me.GrpOperaciones.Controls.Add(Me.btnDelPlanta)
        Me.GrpOperaciones.Controls.Add(Me.btnActPlanta)
        Me.GrpOperaciones.Controls.Add(Me.btnIngPlanta)
        Me.GrpOperaciones.Location = New System.Drawing.Point(12, 100)
        Me.GrpOperaciones.Name = "GrpOperaciones"
        Me.GrpOperaciones.Size = New System.Drawing.Size(514, 64)
        Me.GrpOperaciones.TabIndex = 1
        Me.GrpOperaciones.TabStop = False
        Me.GrpOperaciones.Text = "Operaciones"
        '
        'btnLimpiarFrmPlanta
        '
        Me.btnLimpiarFrmPlanta.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFrmPlanta.Image = Global.mantencion.My.Resources.Resources._16__Clear_
        Me.btnLimpiarFrmPlanta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarFrmPlanta.Location = New System.Drawing.Point(318, 25)
        Me.btnLimpiarFrmPlanta.Name = "btnLimpiarFrmPlanta"
        Me.btnLimpiarFrmPlanta.Size = New System.Drawing.Size(92, 27)
        Me.btnLimpiarFrmPlanta.TabIndex = 3
        Me.btnLimpiarFrmPlanta.Text = "Limpiar"
        Me.btnLimpiarFrmPlanta.UseVisualStyleBackColor = True
        '
        'btnDelPlanta
        '
        Me.btnDelPlanta.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelPlanta.Image = Global.mantencion.My.Resources.Resources._16__Delete_
        Me.btnDelPlanta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelPlanta.Location = New System.Drawing.Point(216, 25)
        Me.btnDelPlanta.Name = "btnDelPlanta"
        Me.btnDelPlanta.Size = New System.Drawing.Size(94, 27)
        Me.btnDelPlanta.TabIndex = 2
        Me.btnDelPlanta.Text = "Eliminar"
        Me.btnDelPlanta.UseVisualStyleBackColor = True
        '
        'btnActPlanta
        '
        Me.btnActPlanta.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActPlanta.Image = Global.mantencion.My.Resources.Resources.icono_escritura_2
        Me.btnActPlanta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActPlanta.Location = New System.Drawing.Point(108, 25)
        Me.btnActPlanta.Name = "btnActPlanta"
        Me.btnActPlanta.Size = New System.Drawing.Size(100, 27)
        Me.btnActPlanta.TabIndex = 1
        Me.btnActPlanta.Text = "Actualizar"
        Me.btnActPlanta.UseVisualStyleBackColor = True
        '
        'btnIngPlanta
        '
        Me.btnIngPlanta.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngPlanta.Image = Global.mantencion.My.Resources.Resources.guardar_16x16
        Me.btnIngPlanta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngPlanta.Location = New System.Drawing.Point(8, 25)
        Me.btnIngPlanta.Name = "btnIngPlanta"
        Me.btnIngPlanta.Size = New System.Drawing.Size(94, 27)
        Me.btnIngPlanta.TabIndex = 0
        Me.btnIngPlanta.Text = "Ingresar"
        Me.btnIngPlanta.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = Global.mantencion.My.Resources.Resources._16__Exit_
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salir.Location = New System.Drawing.Point(418, 25)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(86, 27)
        Me.btn_salir.TabIndex = 4
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'FrmPlantas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(1020, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpOperaciones)
        Me.Controls.Add(Me.GrpInfoPlanta)
        Me.Name = "FrmPlantas"
        Me.ShowIcon = False
        Me.Text = "Mantenedor de Plantas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.GrpInfoPlanta.ResumeLayout(False)
        Me.GrpInfoPlanta.PerformLayout()
        Me.GrpOperaciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpInfoPlanta As System.Windows.Forms.GroupBox
    Friend WithEvents txtNomPlanta As System.Windows.Forms.TextBox
    Friend WithEvents LblCodPlanta As System.Windows.Forms.Label
    Friend WithEvents txtCodPlanta As System.Windows.Forms.TextBox
    Friend WithEvents LblNomPlanta As System.Windows.Forms.Label
    Friend WithEvents GrpOperaciones As System.Windows.Forms.GroupBox
    Friend WithEvents btnLimpiarFrmPlanta As System.Windows.Forms.Button
    Friend WithEvents btnDelPlanta As System.Windows.Forms.Button
    Friend WithEvents btnActPlanta As System.Windows.Forms.Button
    Friend WithEvents btnIngPlanta As System.Windows.Forms.Button
    Friend WithEvents btnBuscarPlanta As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
End Class
