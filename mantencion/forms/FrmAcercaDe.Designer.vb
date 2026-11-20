<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAcercaDe
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlHeaderAcerca = New System.Windows.Forms.Panel()
        Me.pnlLogoAcerca = New System.Windows.Forms.Panel()
        Me.picLogoAcerca = New System.Windows.Forms.PictureBox()
        Me.lblAppTitulo = New System.Windows.Forms.Label()
        Me.lblEmpresaAcerca = New System.Windows.Forms.Label()
        Me.pnlCardDetalle = New System.Windows.Forms.Panel()
        Me.lblTitVersion = New System.Windows.Forms.Label()
        Me.lblValorVersion = New System.Windows.Forms.Label()
        Me.lblTitInstalacion = New System.Windows.Forms.Label()
        Me.lblValorFechaInstalacion = New System.Windows.Forms.Label()
        Me.lblTitCompilacion = New System.Windows.Forms.Label()
        Me.lblValorCompilacion = New System.Windows.Forms.Label()
        Me.lblTitOrigen = New System.Windows.Forms.Label()
        Me.lblValorOrigen = New System.Windows.Forms.Label()
        Me.lblTitRuta = New System.Windows.Forms.Label()
        Me.lblValorRuta = New System.Windows.Forms.Label()
        Me.lblCopyrightAcerca = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.toolTipAcerca = New System.Windows.Forms.ToolTip()
        Me.pnlHeaderAcerca.SuspendLayout()
        Me.pnlLogoAcerca.SuspendLayout()
        CType(Me.picLogoAcerca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCardDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeaderAcerca
        '
        Me.pnlHeaderAcerca.BackColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.pnlHeaderAcerca.Controls.Add(Me.lblEmpresaAcerca)
        Me.pnlHeaderAcerca.Controls.Add(Me.lblAppTitulo)
        Me.pnlHeaderAcerca.Controls.Add(Me.pnlLogoAcerca)
        Me.pnlHeaderAcerca.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeaderAcerca.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeaderAcerca.Name = "pnlHeaderAcerca"
        Me.pnlHeaderAcerca.Size = New System.Drawing.Size(548, 96)
        Me.pnlHeaderAcerca.TabIndex = 0
        '
        'pnlLogoAcerca
        '
        Me.pnlLogoAcerca.BackColor = System.Drawing.Color.White
        Me.pnlLogoAcerca.Controls.Add(Me.picLogoAcerca)
        Me.pnlLogoAcerca.Location = New System.Drawing.Point(18, 16)
        Me.pnlLogoAcerca.Name = "pnlLogoAcerca"
        Me.pnlLogoAcerca.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlLogoAcerca.Size = New System.Drawing.Size(64, 64)
        Me.pnlLogoAcerca.TabIndex = 0
        '
        'picLogoAcerca
        '
        Me.picLogoAcerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picLogoAcerca.Image = Global.mantencion.My.Resources.Resources.cambiaso_logo_nuevo
        Me.picLogoAcerca.Location = New System.Drawing.Point(4, 4)
        Me.picLogoAcerca.Name = "picLogoAcerca"
        Me.picLogoAcerca.Size = New System.Drawing.Size(56, 56)
        Me.picLogoAcerca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogoAcerca.TabIndex = 0
        Me.picLogoAcerca.TabStop = False
        '
        'lblAppTitulo
        '
        Me.lblAppTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblAppTitulo.Font = New System.Drawing.Font("Segoe UI", 13.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppTitulo.ForeColor = System.Drawing.Color.White
        Me.lblAppTitulo.Location = New System.Drawing.Point(96, 20)
        Me.lblAppTitulo.Name = "lblAppTitulo"
        Me.lblAppTitulo.Size = New System.Drawing.Size(436, 28)
        Me.lblAppTitulo.TabIndex = 1
        Me.lblAppTitulo.Text = "Sistema de Gestión Departamento Mantención"
        '
        'lblEmpresaAcerca
        '
        Me.lblEmpresaAcerca.BackColor = System.Drawing.Color.Transparent
        Me.lblEmpresaAcerca.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresaAcerca.ForeColor = System.Drawing.Color.FromArgb(102, 201, 211)
        Me.lblEmpresaAcerca.Location = New System.Drawing.Point(96, 50)
        Me.lblEmpresaAcerca.Name = "lblEmpresaAcerca"
        Me.lblEmpresaAcerca.Size = New System.Drawing.Size(436, 22)
        Me.lblEmpresaAcerca.TabIndex = 2
        Me.lblEmpresaAcerca.Text = "Cambiaso Hnos. S.A.C. — División de Mantención Industrial"
        '
        'pnlCardDetalle
        '
        Me.pnlCardDetalle.BackColor = System.Drawing.Color.White
        Me.pnlCardDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCardDetalle.Controls.Add(Me.lblValorRuta)
        Me.pnlCardDetalle.Controls.Add(Me.lblTitRuta)
        Me.pnlCardDetalle.Controls.Add(Me.lblValorOrigen)
        Me.pnlCardDetalle.Controls.Add(Me.lblTitOrigen)
        Me.pnlCardDetalle.Controls.Add(Me.lblValorCompilacion)
        Me.pnlCardDetalle.Controls.Add(Me.lblTitCompilacion)
        Me.pnlCardDetalle.Controls.Add(Me.lblValorFechaInstalacion)
        Me.pnlCardDetalle.Controls.Add(Me.lblTitInstalacion)
        Me.pnlCardDetalle.Controls.Add(Me.lblValorVersion)
        Me.pnlCardDetalle.Controls.Add(Me.lblTitVersion)
        Me.pnlCardDetalle.Location = New System.Drawing.Point(18, 114)
        Me.pnlCardDetalle.Name = "pnlCardDetalle"
        Me.pnlCardDetalle.Size = New System.Drawing.Size(512, 198)
        Me.pnlCardDetalle.TabIndex = 1
        '
        'lblTitVersion
        '
        Me.lblTitVersion.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitVersion.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblTitVersion.Location = New System.Drawing.Point(18, 18)
        Me.lblTitVersion.Name = "lblTitVersion"
        Me.lblTitVersion.Size = New System.Drawing.Size(172, 24)
        Me.lblTitVersion.TabIndex = 0
        Me.lblTitVersion.Text = "Versión instalada:"
        Me.lblTitVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValorVersion
        '
        Me.lblValorVersion.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorVersion.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblValorVersion.Location = New System.Drawing.Point(196, 17)
        Me.lblValorVersion.Name = "lblValorVersion"
        Me.lblValorVersion.Size = New System.Drawing.Size(300, 26)
        Me.lblValorVersion.TabIndex = 1
        Me.lblValorVersion.Text = "v2026.2.0 LTS"
        Me.lblValorVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitInstalacion
        '
        Me.lblTitInstalacion.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitInstalacion.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblTitInstalacion.Location = New System.Drawing.Point(18, 52)
        Me.lblTitInstalacion.Name = "lblTitInstalacion"
        Me.lblTitInstalacion.Size = New System.Drawing.Size(172, 24)
        Me.lblTitInstalacion.TabIndex = 2
        Me.lblTitInstalacion.Text = "Fecha y hora instalación:"
        Me.lblTitInstalacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValorFechaInstalacion
        '
        Me.lblValorFechaInstalacion.Font = New System.Drawing.Font("Segoe UI", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorFechaInstalacion.ForeColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.lblValorFechaInstalacion.Location = New System.Drawing.Point(196, 52)
        Me.lblValorFechaInstalacion.Name = "lblValorFechaInstalacion"
        Me.lblValorFechaInstalacion.Size = New System.Drawing.Size(300, 24)
        Me.lblValorFechaInstalacion.TabIndex = 3
        Me.lblValorFechaInstalacion.Text = "--"
        Me.lblValorFechaInstalacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitCompilacion
        '
        Me.lblTitCompilacion.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCompilacion.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblTitCompilacion.Location = New System.Drawing.Point(18, 86)
        Me.lblTitCompilacion.Name = "lblTitCompilacion"
        Me.lblTitCompilacion.Size = New System.Drawing.Size(172, 22)
        Me.lblTitCompilacion.TabIndex = 4
        Me.lblTitCompilacion.Text = "Compilación y entorno:"
        Me.lblTitCompilacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValorCompilacion
        '
        Me.lblValorCompilacion.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorCompilacion.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblValorCompilacion.Location = New System.Drawing.Point(196, 86)
        Me.lblValorCompilacion.Name = "lblValorCompilacion"
        Me.lblValorCompilacion.Size = New System.Drawing.Size(300, 22)
        Me.lblValorCompilacion.TabIndex = 5
        Me.lblValorCompilacion.Text = "2026.2.0.0 (.NET 8 Windows Desktop)"
        Me.lblValorCompilacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitOrigen
        '
        Me.lblTitOrigen.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitOrigen.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblTitOrigen.Location = New System.Drawing.Point(18, 118)
        Me.lblTitOrigen.Name = "lblTitOrigen"
        Me.lblTitOrigen.Size = New System.Drawing.Size(172, 22)
        Me.lblTitOrigen.TabIndex = 6
        Me.lblTitOrigen.Text = "Origen del registro:"
        Me.lblTitOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValorOrigen
        '
        Me.lblValorOrigen.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorOrigen.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.lblValorOrigen.Location = New System.Drawing.Point(196, 118)
        Me.lblValorOrigen.Name = "lblValorOrigen"
        Me.lblValorOrigen.Size = New System.Drawing.Size(300, 22)
        Me.lblValorOrigen.TabIndex = 7
        Me.lblValorOrigen.Text = "Registro de instalación Windows"
        Me.lblValorOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitRuta
        '
        Me.lblTitRuta.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitRuta.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblTitRuta.Location = New System.Drawing.Point(18, 150)
        Me.lblTitRuta.Name = "lblTitRuta"
        Me.lblTitRuta.Size = New System.Drawing.Size(172, 22)
        Me.lblTitRuta.TabIndex = 8
        Me.lblTitRuta.Text = "Ruta de ejecución:"
        Me.lblTitRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValorRuta
        '
        Me.lblValorRuta.AutoEllipsis = True
        Me.lblValorRuta.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorRuta.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblValorRuta.Location = New System.Drawing.Point(196, 150)
        Me.lblValorRuta.Name = "lblValorRuta"
        Me.lblValorRuta.Size = New System.Drawing.Size(300, 34)
        Me.lblValorRuta.TabIndex = 9
        Me.lblValorRuta.Text = "--"
        '
        'lblCopyrightAcerca
        '
        Me.lblCopyrightAcerca.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyrightAcerca.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.lblCopyrightAcerca.Location = New System.Drawing.Point(18, 332)
        Me.lblCopyrightAcerca.Name = "lblCopyrightAcerca"
        Me.lblCopyrightAcerca.Size = New System.Drawing.Size(382, 24)
        Me.lblCopyrightAcerca.TabIndex = 2
        Me.lblCopyrightAcerca.Text = "Copyright © 2026 Cambiaso Hnos. S.A.C. — Todos los derechos reservados"
        Me.lblCopyrightAcerca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCerrar
        '
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCerrar.Image = Global.mantencion.My.Resources.Resources.salir
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(410, 326)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(120, 36)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'FrmAcercaDe
        '
        Me.AcceptButton = Me.btnCerrar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(548, 378)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.lblCopyrightAcerca)
        Me.Controls.Add(Me.pnlCardDetalle)
        Me.Controls.Add(Me.pnlHeaderAcerca)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAcercaDe"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Acerca de — Sistema de Gestión de Mantención"
        Me.pnlHeaderAcerca.ResumeLayout(False)
        Me.pnlLogoAcerca.ResumeLayout(False)
        CType(Me.picLogoAcerca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCardDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeaderAcerca As System.Windows.Forms.Panel
    Friend WithEvents pnlLogoAcerca As System.Windows.Forms.Panel
    Friend WithEvents picLogoAcerca As System.Windows.Forms.PictureBox
    Friend WithEvents lblAppTitulo As System.Windows.Forms.Label
    Friend WithEvents lblEmpresaAcerca As System.Windows.Forms.Label
    Friend WithEvents pnlCardDetalle As System.Windows.Forms.Panel
    Friend WithEvents lblTitVersion As System.Windows.Forms.Label
    Friend WithEvents lblValorVersion As System.Windows.Forms.Label
    Friend WithEvents lblTitInstalacion As System.Windows.Forms.Label
    Friend WithEvents lblValorFechaInstalacion As System.Windows.Forms.Label
    Friend WithEvents lblTitCompilacion As System.Windows.Forms.Label
    Friend WithEvents lblValorCompilacion As System.Windows.Forms.Label
    Friend WithEvents lblTitOrigen As System.Windows.Forms.Label
    Friend WithEvents lblValorOrigen As System.Windows.Forms.Label
    Friend WithEvents lblTitRuta As System.Windows.Forms.Label
    Friend WithEvents lblValorRuta As System.Windows.Forms.Label
    Friend WithEvents lblCopyrightAcerca As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents toolTipAcerca As System.Windows.Forms.ToolTip

End Class
