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
        Me.lblSubtitulo = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.pnlProgresoFondo = New System.Windows.Forms.Panel()
        Me.pnlProgresoRelleno = New System.Windows.Forms.Panel()
        Me.lblEstadoCarga = New System.Windows.Forms.Label()
        Me.Version = New System.Windows.Forms.Label()
        Me.Copyright = New System.Windows.Forms.Label()
        Me.pnlDerecho.SuspendLayout()
        Me.pnlProgresoFondo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDerecho (Panel transparente Opción 2 sobre fondo corporativo claro con planos)
        '
        Me.pnlDerecho.BackColor = System.Drawing.Color.Transparent
        Me.pnlDerecho.Controls.Add(Me.Copyright)
        Me.pnlDerecho.Controls.Add(Me.Version)
        Me.pnlDerecho.Controls.Add(Me.lblEstadoCarga)
        Me.pnlDerecho.Controls.Add(Me.pnlProgresoFondo)
        Me.pnlDerecho.Controls.Add(Me.lblSubtitulo)
        Me.pnlDerecho.Controls.Add(Me.lbl1)
        Me.pnlDerecho.Location = New System.Drawing.Point(286, 0)
        Me.pnlDerecho.Name = "pnlDerecho"
        Me.pnlDerecho.Size = New System.Drawing.Size(274, 312)
        Me.pnlDerecho.TabIndex = 1
        '
        'lbl1
        '
        Me.lbl1.BackColor = System.Drawing.Color.Transparent
        Me.lbl1.Font = New System.Drawing.Font("Segoe UI", 16.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.lbl1.Location = New System.Drawing.Point(16, 84)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(246, 32)
        Me.lbl1.TabIndex = 0
        Me.lbl1.Text = "Sistema de Gestión"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblSubtitulo
        '
        Me.lblSubtitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubtitulo.Font = New System.Drawing.Font("Segoe UI", 11.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.lblSubtitulo.Location = New System.Drawing.Point(17, 116)
        Me.lblSubtitulo.Name = "lblSubtitulo"
        Me.lblSubtitulo.Size = New System.Drawing.Size(244, 24)
        Me.lblSubtitulo.TabIndex = 1
        Me.lblSubtitulo.Text = "Departamento Mantención"
        Me.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'pnlProgresoFondo
        '
        Me.pnlProgresoFondo.BackColor = System.Drawing.Color.Transparent
        Me.pnlProgresoFondo.Controls.Add(Me.pnlProgresoRelleno)
        Me.pnlProgresoFondo.Location = New System.Drawing.Point(18, 160)
        Me.pnlProgresoFondo.Name = "pnlProgresoFondo"
        Me.pnlProgresoFondo.Padding = New System.Windows.Forms.Padding(1)
        Me.pnlProgresoFondo.Size = New System.Drawing.Size(236, 13)
        Me.pnlProgresoFondo.TabIndex = 2
        '
        'pnlProgresoRelleno
        '
        Me.pnlProgresoRelleno.BackColor = System.Drawing.Color.Transparent
        Me.pnlProgresoRelleno.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlProgresoRelleno.Location = New System.Drawing.Point(1, 1)
        Me.pnlProgresoRelleno.Name = "pnlProgresoRelleno"
        Me.pnlProgresoRelleno.Size = New System.Drawing.Size(154, 11)
        Me.pnlProgresoRelleno.TabIndex = 0
        '
        'lblEstadoCarga
        '
        Me.lblEstadoCarga.BackColor = System.Drawing.Color.Transparent
        Me.lblEstadoCarga.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoCarga.ForeColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.lblEstadoCarga.Location = New System.Drawing.Point(18, 179)
        Me.lblEstadoCarga.Name = "lblEstadoCarga"
        Me.lblEstadoCarga.Size = New System.Drawing.Size(242, 30)
        Me.lblEstadoCarga.TabIndex = 3
        Me.lblEstadoCarga.Text = "Inicializando servicios y pool de base de datos..."
        '
        'Version
        '
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.Version.Location = New System.Drawing.Point(14, 266)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(244, 16)
        Me.Version.TabIndex = 4
        Me.Version.Text = "Versión 2026.1 LTS"
        Me.Version.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Copyright
        '
        Me.Copyright.BackColor = System.Drawing.Color.Transparent
        Me.Copyright.Font = New System.Drawing.Font("Segoe UI", 7.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.Copyright.Location = New System.Drawing.Point(14, 284)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(244, 16)
        Me.Copyright.TabIndex = 5
        Me.Copyright.Text = "Copyright © Cambiaso Hnos. S.A.C. 2026"
        Me.Copyright.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Inicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(242, 246, 248)
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
        Me.pnlProgresoFondo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents lblSubtitulo As System.Windows.Forms.Label
    Friend WithEvents pnlDerecho As System.Windows.Forms.Panel
    Friend WithEvents pnlProgresoFondo As System.Windows.Forms.Panel
    Friend WithEvents pnlProgresoRelleno As System.Windows.Forms.Panel
    Friend WithEvents lblEstadoCarga As System.Windows.Forms.Label
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents Copyright As System.Windows.Forms.Label

End Class
