<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdminUsuarios
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grpOperUsuario = New System.Windows.Forms.GroupBox
        Me.btnSalirUser = New System.Windows.Forms.Button
        Me.btnLimpiarUser = New System.Windows.Forms.Button
        Me.btnDelUsuario = New System.Windows.Forms.Button
        Me.btnActUsuario = New System.Windows.Forms.Button
        Me.btnIngUsuario = New System.Windows.Forms.Button
        Me.ToolTipIngresar = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipActualizar = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipEliminar = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipLimpiar = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipSalir = New System.Windows.Forms.ToolTip(Me.components)
        Me.GrpUsuarios = New System.Windows.Forms.GroupBox
        Me.grillaUsuarios = New System.Windows.Forms.DataGridView
        Me.grpActivo = New System.Windows.Forms.GroupBox
        Me.opcActivoNo = New System.Windows.Forms.RadioButton
        Me.opcActivoSi = New System.Windows.Forms.RadioButton
        Me.lblPerfil = New System.Windows.Forms.Label
        Me.cmbPerfil1 = New System.Windows.Forms.ComboBox
        Me.lblPass = New System.Windows.Forms.Label
        Me.txtClave = New System.Windows.Forms.TextBox
        Me.lblNomUsuario = New System.Windows.Forms.Label
        Me.txtNomUsuario = New System.Windows.Forms.TextBox
        Me.lblUsuario = New System.Windows.Forms.Label
        Me.txtRutUsuario = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.PanelModulos = New System.Windows.Forms.Panel
        Me.grillaPerModulos = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.PanelModuloOt = New System.Windows.Forms.Panel
        Me.grillaModOt = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.PanelModuloMp = New System.Windows.Forms.Panel
        Me.grillaPerMp = New System.Windows.Forms.DataGridView
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.grillaPerMantenedores = New System.Windows.Forms.DataGridView
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpOperUsuario.SuspendLayout()
        Me.GrpUsuarios.SuspendLayout()
        CType(Me.grillaUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpActivo.SuspendLayout()
        Me.PanelModulos.SuspendLayout()
        CType(Me.grillaPerModulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelModuloOt.SuspendLayout()
        CType(Me.grillaModOt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelModuloMp.SuspendLayout()
        CType(Me.grillaPerMp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grillaPerMantenedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpOperUsuario
        '
        Me.grpOperUsuario.Controls.Add(Me.btnSalirUser)
        Me.grpOperUsuario.Controls.Add(Me.btnLimpiarUser)
        Me.grpOperUsuario.Controls.Add(Me.btnDelUsuario)
        Me.grpOperUsuario.Controls.Add(Me.btnActUsuario)
        Me.grpOperUsuario.Controls.Add(Me.btnIngUsuario)
        Me.grpOperUsuario.Location = New System.Drawing.Point(530, 111)
        Me.grpOperUsuario.Name = "grpOperUsuario"
        Me.grpOperUsuario.Size = New System.Drawing.Size(188, 65)
        Me.grpOperUsuario.TabIndex = 1
        Me.grpOperUsuario.TabStop = False
        Me.grpOperUsuario.Text = "Operaciones"
        '
        'btnSalirUser
        '
        Me.btnSalirUser.BackgroundImage = Global.Mantencion.My.Resources.Resources.salir
        Me.btnSalirUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalirUser.Location = New System.Drawing.Point(147, 31)
        Me.btnSalirUser.Name = "btnSalirUser"
        Me.btnSalirUser.Size = New System.Drawing.Size(29, 29)
        Me.btnSalirUser.TabIndex = 4
        Me.ToolTipSalir.SetToolTip(Me.btnSalirUser, "Cerrar Formulario")
        Me.btnSalirUser.UseVisualStyleBackColor = True
        '
        'btnLimpiarUser
        '
        Me.btnLimpiarUser.BackColor = System.Drawing.Color.Transparent
        Me.btnLimpiarUser.BackgroundImage = Global.Mantencion.My.Resources.Resources.clear
        Me.btnLimpiarUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiarUser.Location = New System.Drawing.Point(112, 31)
        Me.btnLimpiarUser.Name = "btnLimpiarUser"
        Me.btnLimpiarUser.Size = New System.Drawing.Size(29, 29)
        Me.btnLimpiarUser.TabIndex = 3
        Me.ToolTipLimpiar.SetToolTip(Me.btnLimpiarUser, "Limpiar Campos")
        Me.btnLimpiarUser.UseVisualStyleBackColor = False
        '
        'btnDelUsuario
        '
        Me.btnDelUsuario.BackColor = System.Drawing.Color.Transparent
        Me.btnDelUsuario.BackgroundImage = Global.Mantencion.My.Resources.Resources.eliminar
        Me.btnDelUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDelUsuario.Location = New System.Drawing.Point(77, 31)
        Me.btnDelUsuario.Name = "btnDelUsuario"
        Me.btnDelUsuario.Size = New System.Drawing.Size(29, 29)
        Me.btnDelUsuario.TabIndex = 2
        Me.ToolTipEliminar.SetToolTip(Me.btnDelUsuario, "Eliminar")
        Me.btnDelUsuario.UseVisualStyleBackColor = False
        '
        'btnActUsuario
        '
        Me.btnActUsuario.BackColor = System.Drawing.Color.Transparent
        Me.btnActUsuario.BackgroundImage = Global.Mantencion.My.Resources.Resources.guardar
        Me.btnActUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnActUsuario.Location = New System.Drawing.Point(42, 31)
        Me.btnActUsuario.Name = "btnActUsuario"
        Me.btnActUsuario.Size = New System.Drawing.Size(29, 29)
        Me.btnActUsuario.TabIndex = 1
        Me.ToolTipActualizar.SetToolTip(Me.btnActUsuario, "Actualizar")
        Me.btnActUsuario.UseVisualStyleBackColor = False
        '
        'btnIngUsuario
        '
        Me.btnIngUsuario.BackColor = System.Drawing.Color.Transparent
        Me.btnIngUsuario.BackgroundImage = Global.Mantencion.My.Resources.Resources.icono_escritura
        Me.btnIngUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnIngUsuario.Location = New System.Drawing.Point(7, 31)
        Me.btnIngUsuario.Name = "btnIngUsuario"
        Me.btnIngUsuario.Size = New System.Drawing.Size(29, 29)
        Me.btnIngUsuario.TabIndex = 0
        Me.ToolTipIngresar.SetToolTip(Me.btnIngUsuario, "Ingresar")
        Me.btnIngUsuario.UseVisualStyleBackColor = False
        '
        'ToolTipIngresar
        '
        Me.ToolTipIngresar.IsBalloon = True
        '
        'ToolTipActualizar
        '
        Me.ToolTipActualizar.IsBalloon = True
        '
        'ToolTipEliminar
        '
        Me.ToolTipEliminar.IsBalloon = True
        '
        'ToolTipLimpiar
        '
        Me.ToolTipLimpiar.IsBalloon = True
        '
        'ToolTipSalir
        '
        Me.ToolTipSalir.IsBalloon = True
        '
        'GrpUsuarios
        '
        Me.GrpUsuarios.BackColor = System.Drawing.Color.Transparent
        Me.GrpUsuarios.Controls.Add(Me.grpOperUsuario)
        Me.GrpUsuarios.Controls.Add(Me.grillaUsuarios)
        Me.GrpUsuarios.Controls.Add(Me.grpActivo)
        Me.GrpUsuarios.Controls.Add(Me.lblPerfil)
        Me.GrpUsuarios.Controls.Add(Me.cmbPerfil1)
        Me.GrpUsuarios.Controls.Add(Me.lblPass)
        Me.GrpUsuarios.Controls.Add(Me.txtClave)
        Me.GrpUsuarios.Controls.Add(Me.lblNomUsuario)
        Me.GrpUsuarios.Controls.Add(Me.txtNomUsuario)
        Me.GrpUsuarios.Controls.Add(Me.lblUsuario)
        Me.GrpUsuarios.Controls.Add(Me.txtRutUsuario)
        Me.GrpUsuarios.Location = New System.Drawing.Point(12, 12)
        Me.GrpUsuarios.Name = "GrpUsuarios"
        Me.GrpUsuarios.Size = New System.Drawing.Size(730, 299)
        Me.GrpUsuarios.TabIndex = 2
        Me.GrpUsuarios.TabStop = False
        Me.GrpUsuarios.Text = "Información de Usuarios"
        '
        'grillaUsuarios
        '
        Me.grillaUsuarios.AllowUserToAddRows = False
        Me.grillaUsuarios.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grillaUsuarios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grillaUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grillaUsuarios.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaUsuarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grillaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaUsuarios.EnableHeadersVisualStyles = False
        Me.grillaUsuarios.Location = New System.Drawing.Point(6, 111)
        Me.grillaUsuarios.Name = "grillaUsuarios"
        Me.grillaUsuarios.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaUsuarios.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grillaUsuarios.Size = New System.Drawing.Size(479, 176)
        Me.grillaUsuarios.TabIndex = 2
        '
        'grpActivo
        '
        Me.grpActivo.Controls.Add(Me.opcActivoNo)
        Me.grpActivo.Controls.Add(Me.opcActivoSi)
        Me.grpActivo.Location = New System.Drawing.Point(530, 20)
        Me.grpActivo.Name = "grpActivo"
        Me.grpActivo.Size = New System.Drawing.Size(102, 45)
        Me.grpActivo.TabIndex = 1
        Me.grpActivo.TabStop = False
        Me.grpActivo.Text = "Activo SI / NO"
        '
        'opcActivoNo
        '
        Me.opcActivoNo.AutoSize = True
        Me.opcActivoNo.Location = New System.Drawing.Point(55, 19)
        Me.opcActivoNo.Name = "opcActivoNo"
        Me.opcActivoNo.Size = New System.Drawing.Size(41, 17)
        Me.opcActivoNo.TabIndex = 9
        Me.opcActivoNo.TabStop = True
        Me.opcActivoNo.Text = "NO"
        Me.opcActivoNo.UseVisualStyleBackColor = True
        '
        'opcActivoSi
        '
        Me.opcActivoSi.AutoSize = True
        Me.opcActivoSi.Location = New System.Drawing.Point(6, 19)
        Me.opcActivoSi.Name = "opcActivoSi"
        Me.opcActivoSi.Size = New System.Drawing.Size(35, 17)
        Me.opcActivoSi.TabIndex = 8
        Me.opcActivoSi.TabStop = True
        Me.opcActivoSi.Text = "SI"
        Me.opcActivoSi.UseVisualStyleBackColor = True
        '
        'lblPerfil
        '
        Me.lblPerfil.AutoSize = True
        Me.lblPerfil.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPerfil.Location = New System.Drawing.Point(374, 19)
        Me.lblPerfil.Name = "lblPerfil"
        Me.lblPerfil.Size = New System.Drawing.Size(36, 15)
        Me.lblPerfil.TabIndex = 7
        Me.lblPerfil.Text = "Perfil"
        '
        'cmbPerfil1
        '
        Me.cmbPerfil1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPerfil1.FormattingEnabled = True
        Me.cmbPerfil1.Location = New System.Drawing.Point(377, 38)
        Me.cmbPerfil1.Name = "cmbPerfil1"
        Me.cmbPerfil1.Size = New System.Drawing.Size(147, 21)
        Me.cmbPerfil1.TabIndex = 6
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPass.Location = New System.Drawing.Point(255, 19)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(69, 15)
        Me.lblPass.TabIndex = 5
        Me.lblPass.Text = "Contraseña"
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(258, 38)
        Me.txtClave.MaxLength = 10
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(100, 20)
        Me.txtClave.TabIndex = 4
        '
        'lblNomUsuario
        '
        Me.lblNomUsuario.AutoSize = True
        Me.lblNomUsuario.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomUsuario.Location = New System.Drawing.Point(124, 19)
        Me.lblNomUsuario.Name = "lblNomUsuario"
        Me.lblNomUsuario.Size = New System.Drawing.Size(114, 15)
        Me.lblNomUsuario.TabIndex = 3
        Me.lblNomUsuario.Text = "Nombre de Usuario"
        '
        'txtNomUsuario
        '
        Me.txtNomUsuario.Location = New System.Drawing.Point(127, 38)
        Me.txtNomUsuario.MaxLength = 15
        Me.txtNomUsuario.Name = "txtNomUsuario"
        Me.txtNomUsuario.Size = New System.Drawing.Size(100, 20)
        Me.txtNomUsuario.TabIndex = 2
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(7, 20)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(26, 15)
        Me.lblUsuario.TabIndex = 1
        Me.lblUsuario.Text = "Rut"
        '
        'txtRutUsuario
        '
        Me.txtRutUsuario.Location = New System.Drawing.Point(6, 38)
        Me.txtRutUsuario.MaxLength = 8
        Me.txtRutUsuario.Name = "txtRutUsuario"
        Me.txtRutUsuario.Size = New System.Drawing.Size(89, 20)
        Me.txtRutUsuario.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Acceso a Módulos"
        '
        'PanelModulos
        '
        Me.PanelModulos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelModulos.Controls.Add(Me.grillaPerModulos)
        Me.PanelModulos.Location = New System.Drawing.Point(10, 18)
        Me.PanelModulos.Name = "PanelModulos"
        Me.PanelModulos.Size = New System.Drawing.Size(271, 139)
        Me.PanelModulos.TabIndex = 12
        '
        'grillaPerModulos
        '
        Me.grillaPerModulos.AllowUserToAddRows = False
        Me.grillaPerModulos.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.grillaPerModulos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grillaPerModulos.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaPerModulos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grillaPerModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaPerModulos.EnableHeadersVisualStyles = False
        Me.grillaPerModulos.Location = New System.Drawing.Point(7, 10)
        Me.grillaPerModulos.Name = "grillaPerModulos"
        Me.grillaPerModulos.RowHeadersVisible = False
        Me.grillaPerModulos.Size = New System.Drawing.Size(259, 126)
        Me.grillaPerModulos.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(317, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Módulo Orden de Trabajo"
        '
        'PanelModuloOt
        '
        Me.PanelModuloOt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelModuloOt.Controls.Add(Me.grillaModOt)
        Me.PanelModuloOt.Location = New System.Drawing.Point(312, 18)
        Me.PanelModuloOt.Name = "PanelModuloOt"
        Me.PanelModuloOt.Size = New System.Drawing.Size(271, 139)
        Me.PanelModuloOt.TabIndex = 15
        '
        'grillaModOt
        '
        Me.grillaModOt.AllowUserToAddRows = False
        Me.grillaModOt.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaModOt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grillaModOt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaModOt.EnableHeadersVisualStyles = False
        Me.grillaModOt.Location = New System.Drawing.Point(6, 10)
        Me.grillaModOt.Name = "grillaModOt"
        Me.grillaModOt.RowHeadersVisible = False
        Me.grillaModOt.Size = New System.Drawing.Size(259, 126)
        Me.grillaModOt.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(155, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Módulo Mantención Preventiva"
        '
        'PanelModuloMp
        '
        Me.PanelModuloMp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelModuloMp.Controls.Add(Me.grillaPerMp)
        Me.PanelModuloMp.Location = New System.Drawing.Point(10, 167)
        Me.PanelModuloMp.Name = "PanelModuloMp"
        Me.PanelModuloMp.Size = New System.Drawing.Size(271, 145)
        Me.PanelModuloMp.TabIndex = 17
        '
        'grillaPerMp
        '
        Me.grillaPerMp.AllowUserToAddRows = False
        Me.grillaPerMp.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaPerMp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grillaPerMp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaPerMp.EnableHeadersVisualStyles = False
        Me.grillaPerMp.Location = New System.Drawing.Point(6, 10)
        Me.grillaPerMp.Name = "grillaPerMp"
        Me.grillaPerMp.RowHeadersVisible = False
        Me.grillaPerMp.Size = New System.Drawing.Size(260, 126)
        Me.grillaPerMp.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(318, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Módulo Mantenedores"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.grillaPerMantenedores)
        Me.Panel1.Location = New System.Drawing.Point(312, 167)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(271, 143)
        Me.Panel1.TabIndex = 19
        '
        'grillaPerMantenedores
        '
        Me.grillaPerMantenedores.AllowUserToAddRows = False
        Me.grillaPerMantenedores.AllowUserToDeleteRows = False
        Me.grillaPerMantenedores.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaPerMantenedores.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.grillaPerMantenedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaPerMantenedores.EnableHeadersVisualStyles = False
        Me.grillaPerMantenedores.Location = New System.Drawing.Point(8, 10)
        Me.grillaPerMantenedores.Name = "grillaPerMantenedores"
        Me.grillaPerMantenedores.RowHeadersVisible = False
        Me.grillaPerMantenedores.Size = New System.Drawing.Size(260, 126)
        Me.grillaPerMantenedores.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.PanelModulos)
        Me.Panel2.Controls.Add(Me.PanelModuloMp)
        Me.Panel2.Controls.Add(Me.PanelModuloOt)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Location = New System.Drawing.Point(12, 334)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1000, 315)
        Me.Panel2.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 325)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 15)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Permisos de Usuario"
        '
        'FrmAdminUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(1020, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GrpUsuarios)
        Me.Name = "FrmAdminUsuarios"
        Me.Text = "Administración de Usuarios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpOperUsuario.ResumeLayout(False)
        Me.GrpUsuarios.ResumeLayout(False)
        Me.GrpUsuarios.PerformLayout()
        CType(Me.grillaUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpActivo.ResumeLayout(False)
        Me.grpActivo.PerformLayout()
        Me.PanelModulos.ResumeLayout(False)
        CType(Me.grillaPerModulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelModuloOt.ResumeLayout(False)
        CType(Me.grillaModOt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelModuloMp.ResumeLayout(False)
        CType(Me.grillaPerMp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grillaPerMantenedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpOperUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelUsuario As System.Windows.Forms.Button
    Friend WithEvents btnActUsuario As System.Windows.Forms.Button
    Friend WithEvents btnIngUsuario As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarUser As System.Windows.Forms.Button
    Friend WithEvents btnSalirUser As System.Windows.Forms.Button
    Friend WithEvents ToolTipIngresar As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipLimpiar As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipEliminar As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipActualizar As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipSalir As System.Windows.Forms.ToolTip
    Friend WithEvents GrpUsuarios As System.Windows.Forms.GroupBox
    Friend WithEvents PanelModuloOt As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grillaModOt As System.Windows.Forms.DataGridView
    Friend WithEvents PanelModuloMp As System.Windows.Forms.Panel
    Friend WithEvents grillaPerMp As System.Windows.Forms.DataGridView
    Friend WithEvents grillaUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents grpActivo As System.Windows.Forms.GroupBox
    Friend WithEvents opcActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents opcActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblPerfil As System.Windows.Forms.Label
    Friend WithEvents cmbPerfil1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents lblNomUsuario As System.Windows.Forms.Label
    Friend WithEvents txtNomUsuario As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents txtRutUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PanelModulos As System.Windows.Forms.Panel
    Friend WithEvents grillaPerModulos As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grillaPerMantenedores As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
