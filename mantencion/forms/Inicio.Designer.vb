<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inicio
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

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlDerecho = New System.Windows.Forms.Panel()
        Me.lblKicker = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.pnlProgresoFondo = New System.Windows.Forms.Panel()
        Me.pnlProgresoRelleno = New System.Windows.Forms.Panel()
        Me.lblEstadoCarga = New System.Windows.Forms.Label()
        Me.pnlSeparador = New System.Windows.Forms.Panel()
        Me.Version = New System.Windows.Forms.Label()
        Me.Copyright = New System.Windows.Forms.Label()
        Me.pnlDerecho.SuspendLayout()
        Me.pnlProgresoFondo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDerecho (Tarjeta flotante clara sobre fondo panorámico Opción 3)
        '
        Me.pnlDerecho.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlDerecho.Controls.Add(Me.Copyright)
        Me.pnlDerecho.Controls.Add(Me.Version)
        Me.pnlDerecho.Controls.Add(Me.pnlSeparador)
        Me.pnlDerecho.Controls.Add(Me.lblEstadoCarga)
        Me.pnlDerecho.Controls.Add(Me.pnlProgresoFondo)
        Me.pnlDerecho.Controls.Add(Me.lbl1)
        Me.pnlDerecho.Controls.Add(Me.lblKicker)
        Me.pnlDerecho.Location = New System.Drawing.Point(278, 36)
        Me.pnlDerecho.Name = "pnlDerecho"
        Me.pnlDerecho.Size = New System.Drawing.Size(256, 240)
        Me.pnlDerecho.TabIndex = 1
        '
        'lblKicker
        '
        Me.lblKicker.AutoSize = True
        Me.lblKicker.BackColor = System.Drawing.Color.Transparent
        Me.lblKicker.Font = New System.Drawing.Font("Segoe UI", 7.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKicker.ForeColor = System.Drawing.Color.FromArgb(1, 145, 179)
        Me.lblKicker.Location = New System.Drawing.Point(22, 22)
        Me.lblKicker.Name = "lblKicker"
        Me.lblKicker.Size = New System.Drawing.Size(170, 13)
        Me.lblKicker.TabIndex = 0
        Me.lblKicker.Text = "CMMS · CAMBIASO HNOS. S.A.C."
        '
        'lbl1
        '
        Me.lbl1.BackColor = System.Drawing.Color.Transparent
        Me.lbl1.Font = New System.Drawing.Font("Segoe UI", 13.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.lbl1.Location = New System.Drawing.Point(20, 42)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(218, 78)
        Me.lbl1.TabIndex = 1
        Me.lbl1.Text = "Sistema de Gestión" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Departamento" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Mantención"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlProgresoFondo
        '
        Me.pnlProgresoFondo.BackColor = System.Drawing.Color.FromArgb(221, 231, 232)
        Me.pnlProgresoFondo.Controls.Add(Me.pnlProgresoRelleno)
        Me.pnlProgresoFondo.Location = New System.Drawing.Point(22, 132)
        Me.pnlProgresoFondo.Name = "pnlProgresoFondo"
        Me.pnlProgresoFondo.Size = New System.Drawing.Size(210, 5)
        Me.pnlProgresoFondo.TabIndex = 2
        '
        'pnlProgresoRelleno
        '
        Me.pnlProgresoRelleno.BackColor = System.Drawing.Color.FromArgb(1, 145, 179)
        Me.pnlProgresoRelleno.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlProgresoRelleno.Location = New System.Drawing.Point(0, 0)
        Me.pnlProgresoRelleno.Name = "pnlProgresoRelleno"
        Me.pnlProgresoRelleno.Size = New System.Drawing.Size(156, 5)
        Me.pnlProgresoRelleno.TabIndex = 0
        '
        'lblEstadoCarga
        '
        Me.lblEstadoCarga.BackColor = System.Drawing.Color.Transparent
        Me.lblEstadoCarga.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoCarga.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblEstadoCarga.Location = New System.Drawing.Point(22, 144)
        Me.lblEstadoCarga.Name = "lblEstadoCarga"
        Me.lblEstadoCarga.Size = New System.Drawing.Size(214, 32)
        Me.lblEstadoCarga.TabIndex = 3
        Me.lblEstadoCarga.Text = "Inicializando servicios y pool de base de datos..."
        '
        'pnlSeparador
        '
        Me.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.pnlSeparador.Location = New System.Drawing.Point(22, 182)
        Me.pnlSeparador.Name = "pnlSeparador"
        Me.pnlSeparador.Size = New System.Drawing.Size(210, 1)
        Me.pnlSeparador.TabIndex = 4
        '
        'Version
        '
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.ForeColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.Version.Location = New System.Drawing.Point(22, 192)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(214, 18)
        Me.Version.TabIndex = 5
        Me.Version.Text = "Versión 2026.1 LTS · Placilla, Valparaíso"
        '
        'Copyright
        '
        Me.Copyright.BackColor = System.Drawing.Color.Transparent
        Me.Copyright.Font = New System.Drawing.Font("Segoe UI", 7.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.Copyright.Location = New System.Drawing.Point(22, 210)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(214, 18)
        Me.Copyright.TabIndex = 6
        Me.Copyright.Text = "Copyright © Cambiaso Hnos. S.A.C. 2026"
        '
        'Inicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.BackgroundImage = Global.mantencion.My.Resources.Resources.inicio_gear_bg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(560, 312)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlDerecho)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Inicio"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlDerecho.ResumeLayout(False)
        Me.pnlDerecho.PerformLayout()
        Me.pnlProgresoFondo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents lblKicker As System.Windows.Forms.Label
    Friend WithEvents pnlDerecho As System.Windows.Forms.Panel
    Friend WithEvents pnlProgresoFondo As System.Windows.Forms.Panel
    Friend WithEvents pnlProgresoRelleno As System.Windows.Forms.Panel
    Friend WithEvents lblEstadoCarga As System.Windows.Forms.Label
    Friend WithEvents pnlSeparador As System.Windows.Forms.Panel
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents Copyright As System.Windows.Forms.Label

End Class
