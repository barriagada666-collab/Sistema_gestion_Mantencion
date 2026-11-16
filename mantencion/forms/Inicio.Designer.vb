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
        Me.pnlIzquierdo = New System.Windows.Forms.Panel()
        Me.pnlLogoCard = New System.Windows.Forms.Panel()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.lblSubModulo = New System.Windows.Forms.Label()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.pnlDerecho = New System.Windows.Forms.Panel()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.pnlProgresoFondo = New System.Windows.Forms.Panel()
        Me.pnlProgresoRelleno = New System.Windows.Forms.Panel()
        Me.lblEstadoCarga = New System.Windows.Forms.Label()
        Me.pnlSeparador = New System.Windows.Forms.Panel()
        Me.Version = New System.Windows.Forms.Label()
        Me.Copyright = New System.Windows.Forms.Label()
        Me.pnlIzquierdo.SuspendLayout()
        Me.pnlLogoCard.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDerecho.SuspendLayout()
        Me.pnlProgresoFondo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlIzquierdo
        '
        Me.pnlIzquierdo.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.pnlIzquierdo.Controls.Add(Me.lblUbicacion)
        Me.pnlIzquierdo.Controls.Add(Me.lblSubModulo)
        Me.pnlIzquierdo.Controls.Add(Me.lblDivision)
        Me.pnlIzquierdo.Controls.Add(Me.pnlLogoCard)
        Me.pnlIzquierdo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlIzquierdo.Location = New System.Drawing.Point(0, 0)
        Me.pnlIzquierdo.Name = "pnlIzquierdo"
        Me.pnlIzquierdo.Size = New System.Drawing.Size(192, 303)
        Me.pnlIzquierdo.TabIndex = 0
        '
        'pnlLogoCard
        '
        Me.pnlLogoCard.BackColor = System.Drawing.Color.White
        Me.pnlLogoCard.Controls.Add(Me.picLogo)
        Me.pnlLogoCard.Location = New System.Drawing.Point(18, 22)
        Me.pnlLogoCard.Name = "pnlLogoCard"
        Me.pnlLogoCard.Padding = New System.Windows.Forms.Padding(8)
        Me.pnlLogoCard.Size = New System.Drawing.Size(156, 66)
        Me.pnlLogoCard.TabIndex = 0
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.Color.White
        Me.picLogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picLogo.Image = Global.mantencion.My.Resources.Resources.cambiaso_logo_nuevo
        Me.picLogo.Location = New System.Drawing.Point(8, 8)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(140, 50)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 0
        Me.picLogo.TabStop = False
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.BackColor = System.Drawing.Color.Transparent
        Me.lblDivision.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivision.ForeColor = System.Drawing.Color.FromArgb(186, 230, 253)
        Me.lblDivision.Location = New System.Drawing.Point(18, 108)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(134, 15)
        Me.lblDivision.TabIndex = 1
        Me.lblDivision.Text = "DIVISIÓN INDUSTRIAL"
        '
        'lblSubModulo
        '
        Me.lblSubModulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubModulo.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubModulo.ForeColor = System.Drawing.Color.FromArgb(224, 244, 246)
        Me.lblSubModulo.Location = New System.Drawing.Point(18, 130)
        Me.lblSubModulo.Name = "lblSubModulo"
        Me.lblSubModulo.Size = New System.Drawing.Size(156, 38)
        Me.lblSubModulo.TabIndex = 2
        Me.lblSubModulo.Text = "Gestión de Activos, OT y MP"
        '
        'lblUbicacion
        '
        Me.lblUbicacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblUbicacion.AutoSize = True
        Me.lblUbicacion.BackColor = System.Drawing.Color.Transparent
        Me.lblUbicacion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbicacion.ForeColor = System.Drawing.Color.FromArgb(186, 230, 253)
        Me.lblUbicacion.Location = New System.Drawing.Point(18, 266)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(108, 13)
        Me.lblUbicacion.TabIndex = 3
        Me.lblUbicacion.Text = "Placilla, Valparaíso"
        '
        'pnlDerecho
        '
        Me.pnlDerecho.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.pnlDerecho.Controls.Add(Me.Copyright)
        Me.pnlDerecho.Controls.Add(Me.Version)
        Me.pnlDerecho.Controls.Add(Me.pnlSeparador)
        Me.pnlDerecho.Controls.Add(Me.lblEstadoCarga)
        Me.pnlDerecho.Controls.Add(Me.pnlProgresoFondo)
        Me.pnlDerecho.Controls.Add(Me.lbl1)
        Me.pnlDerecho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDerecho.Location = New System.Drawing.Point(192, 0)
        Me.pnlDerecho.Name = "pnlDerecho"
        Me.pnlDerecho.Size = New System.Drawing.Size(328, 303)
        Me.pnlDerecho.TabIndex = 1
        '
        'lbl1
        '
        Me.lbl1.BackColor = System.Drawing.Color.Transparent
        Me.lbl1.Font = New System.Drawing.Font("Segoe UI", 14.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.lbl1.Location = New System.Drawing.Point(24, 34)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(280, 88)
        Me.lbl1.TabIndex = 0
        Me.lbl1.Text = "Sistema de Gestión" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Departamento Mantención"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlProgresoFondo
        '
        Me.pnlProgresoFondo.BackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.pnlProgresoFondo.Controls.Add(Me.pnlProgresoRelleno)
        Me.pnlProgresoFondo.Location = New System.Drawing.Point(24, 146)
        Me.pnlProgresoFondo.Name = "pnlProgresoFondo"
        Me.pnlProgresoFondo.Size = New System.Drawing.Size(276, 6)
        Me.pnlProgresoFondo.TabIndex = 1
        '
        'pnlProgresoRelleno
        '
        Me.pnlProgresoRelleno.BackColor = System.Drawing.Color.FromArgb(1, 145, 179)
        Me.pnlProgresoRelleno.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlProgresoRelleno.Location = New System.Drawing.Point(0, 0)
        Me.pnlProgresoRelleno.Name = "pnlProgresoRelleno"
        Me.pnlProgresoRelleno.Size = New System.Drawing.Size(210, 6)
        Me.pnlProgresoRelleno.TabIndex = 0
        '
        'lblEstadoCarga
        '
        Me.lblEstadoCarga.BackColor = System.Drawing.Color.Transparent
        Me.lblEstadoCarga.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoCarga.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblEstadoCarga.Location = New System.Drawing.Point(24, 160)
        Me.lblEstadoCarga.Name = "lblEstadoCarga"
        Me.lblEstadoCarga.Size = New System.Drawing.Size(276, 34)
        Me.lblEstadoCarga.TabIndex = 2
        Me.lblEstadoCarga.Text = "Inicializando servicios y pool de base de datos..."
        '
        'pnlSeparador
        '
        Me.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.pnlSeparador.Location = New System.Drawing.Point(24, 224)
        Me.pnlSeparador.Name = "pnlSeparador"
        Me.pnlSeparador.Size = New System.Drawing.Size(276, 1)
        Me.pnlSeparador.TabIndex = 3
        '
        'Version
        '
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.ForeColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.Version.Location = New System.Drawing.Point(24, 238)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(276, 20)
        Me.Version.TabIndex = 4
        Me.Version.Text = "Versión 2026.1"
        '
        'Copyright
        '
        Me.Copyright.BackColor = System.Drawing.Color.Transparent
        Me.Copyright.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.Copyright.Location = New System.Drawing.Point(24, 258)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(276, 30)
        Me.Copyright.TabIndex = 5
        Me.Copyright.Text = "Copyright © Cambiaso Hnos. S.A.C. 2026"
        '
        'Inicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.ClientSize = New System.Drawing.Size(520, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlDerecho)
        Me.Controls.Add(Me.pnlIzquierdo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Inicio"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlIzquierdo.ResumeLayout(False)
        Me.pnlIzquierdo.PerformLayout()
        Me.pnlLogoCard.ResumeLayout(False)
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDerecho.ResumeLayout(False)
        Me.pnlProgresoFondo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents pnlIzquierdo As System.Windows.Forms.Panel
    Friend WithEvents pnlLogoCard As System.Windows.Forms.Panel
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblDivision As System.Windows.Forms.Label
    Friend WithEvents lblSubModulo As System.Windows.Forms.Label
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents pnlDerecho As System.Windows.Forms.Panel
    Friend WithEvents pnlProgresoFondo As System.Windows.Forms.Panel
    Friend WithEvents pnlProgresoRelleno As System.Windows.Forms.Panel
    Friend WithEvents lblEstadoCarga As System.Windows.Forms.Label
    Friend WithEvents pnlSeparador As System.Windows.Forms.Panel
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents Copyright As System.Windows.Forms.Label

End Class
