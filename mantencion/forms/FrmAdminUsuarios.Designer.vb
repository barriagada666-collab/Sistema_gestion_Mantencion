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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tblPrincipal = New System.Windows.Forms.TableLayoutPanel
        Me.GrpUsuarios = New System.Windows.Forms.GroupBox
        Me.grpOperUsuario = New System.Windows.Forms.GroupBox
        Me.btnSalirUser = New System.Windows.Forms.Button
        Me.btnLimpiarUser = New System.Windows.Forms.Button
        Me.btnDelUsuario = New System.Windows.Forms.Button
        Me.btnActUsuario = New System.Windows.Forms.Button
        Me.btnIngUsuario = New System.Windows.Forms.Button
        Me.grillaUsuarios = New System.Windows.Forms.DataGridView
        Me.grpActivo = New System.Windows.Forms.GroupBox
        Me.opcActivoNo = New System.Windows.Forms.RadioButton
        Me.opcActivoSi = New System.Windows.Forms.RadioButton
        Me.lblBuscarUsuario = New System.Windows.Forms.Label
        Me.txtBuscarUsuario = New System.Windows.Forms.TextBox
        Me.btnGestionPerfiles = New System.Windows.Forms.Button
        Me.lblPerfil = New System.Windows.Forms.Label
        Me.cmbPerfil1 = New System.Windows.Forms.ComboBox
        Me.chkVerClave = New System.Windows.Forms.CheckBox
        Me.lblPass = New System.Windows.Forms.Label
        Me.txtClave = New System.Windows.Forms.TextBox
        Me.lblNomUsuario = New System.Windows.Forms.Label
        Me.txtNomUsuario = New System.Windows.Forms.TextBox
        Me.lblUsuario = New System.Windows.Forms.Label
        Me.txtRutUsuario = New System.Windows.Forms.TextBox
        Me.grpPermisos = New System.Windows.Forms.GroupBox
        Me.tblContenedorPermisos = New System.Windows.Forms.TableLayoutPanel
        Me.pnlAccionesPermisos = New System.Windows.Forms.Panel
        Me.lblModoUsuario = New System.Windows.Forms.Label
        Me.btnAplicarPlantilla = New System.Windows.Forms.Button
        Me.btnMarcarTodosPerm = New System.Windows.Forms.Button
        Me.btnDesmarcarTodosPerm = New System.Windows.Forms.Button
        Me.tblPermisos = New System.Windows.Forms.TableLayoutPanel
        Me.grpModulos = New System.Windows.Forms.GroupBox
        Me.grillaPerModulos = New System.Windows.Forms.DataGridView
        Me.grpModOt = New System.Windows.Forms.GroupBox
        Me.grillaModOt = New System.Windows.Forms.DataGridView
        Me.grpModMp = New System.Windows.Forms.GroupBox
        Me.grillaPerMp = New System.Windows.Forms.DataGridView
        Me.grpMantenedores = New System.Windows.Forms.GroupBox
        Me.grillaPerMantenedores = New System.Windows.Forms.DataGridView
        Me.ToolTipIngresar = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipActualizar = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipEliminar = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipLimpiar = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipSalir = New System.Windows.Forms.ToolTip(Me.components)
        Me.tblPrincipal.SuspendLayout()
        Me.GrpUsuarios.SuspendLayout()
        Me.grpOperUsuario.SuspendLayout()
        CType(Me.grillaUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpActivo.SuspendLayout()
        Me.grpPermisos.SuspendLayout()
        Me.tblContenedorPermisos.SuspendLayout()
        Me.pnlAccionesPermisos.SuspendLayout()
        Me.tblPermisos.SuspendLayout()
        Me.grpModulos.SuspendLayout()
        CType(Me.grillaPerModulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpModOt.SuspendLayout()
        CType(Me.grillaModOt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpModMp.SuspendLayout()
        CType(Me.grillaPerMp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMantenedores.SuspendLayout()
        CType(Me.grillaPerMantenedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tblPrincipal
        '
        Me.tblPrincipal.ColumnCount = 1
        Me.tblPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPrincipal.Controls.Add(Me.GrpUsuarios, 0, 0)
        Me.tblPrincipal.Controls.Add(Me.grpPermisos, 0, 1)
        Me.tblPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tblPrincipal.Name = "tblPrincipal"
        Me.tblPrincipal.Padding = New System.Windows.Forms.Padding(8, 6, 8, 8)
        Me.tblPrincipal.RowCount = 2
        Me.tblPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.0!))
        Me.tblPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.0!))
        Me.tblPrincipal.Size = New System.Drawing.Size(1040, 680)
        Me.tblPrincipal.TabIndex = 0
        '
        'GrpUsuarios
        '
        Me.GrpUsuarios.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.GrpUsuarios.Controls.Add(Me.grpOperUsuario)
        Me.GrpUsuarios.Controls.Add(Me.grillaUsuarios)
        Me.GrpUsuarios.Controls.Add(Me.lblBuscarUsuario)
        Me.GrpUsuarios.Controls.Add(Me.txtBuscarUsuario)
        Me.GrpUsuarios.Controls.Add(Me.grpActivo)
        Me.GrpUsuarios.Controls.Add(Me.btnGestionPerfiles)
        Me.GrpUsuarios.Controls.Add(Me.lblPerfil)
        Me.GrpUsuarios.Controls.Add(Me.cmbPerfil1)
        Me.GrpUsuarios.Controls.Add(Me.chkVerClave)
        Me.GrpUsuarios.Controls.Add(Me.lblPass)
        Me.GrpUsuarios.Controls.Add(Me.txtClave)
        Me.GrpUsuarios.Controls.Add(Me.lblNomUsuario)
        Me.GrpUsuarios.Controls.Add(Me.txtNomUsuario)
        Me.GrpUsuarios.Controls.Add(Me.lblUsuario)
        Me.GrpUsuarios.Controls.Add(Me.txtRutUsuario)
        Me.GrpUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpUsuarios.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpUsuarios.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.GrpUsuarios.Location = New System.Drawing.Point(11, 9)
        Me.GrpUsuarios.Name = "GrpUsuarios"
        Me.GrpUsuarios.Size = New System.Drawing.Size(1018, 306)
        Me.GrpUsuarios.TabIndex = 0
        Me.GrpUsuarios.TabStop = False
        Me.GrpUsuarios.Text = "Información de Usuarios"
        '
        'grpOperUsuario
        '
        Me.grpOperUsuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpOperUsuario.Controls.Add(Me.btnSalirUser)
        Me.grpOperUsuario.Controls.Add(Me.btnLimpiarUser)
        Me.grpOperUsuario.Controls.Add(Me.btnDelUsuario)
        Me.grpOperUsuario.Controls.Add(Me.btnActUsuario)
        Me.grpOperUsuario.Controls.Add(Me.btnIngUsuario)
        Me.grpOperUsuario.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpOperUsuario.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpOperUsuario.Location = New System.Drawing.Point(822, 13)
        Me.grpOperUsuario.Name = "grpOperUsuario"
        Me.grpOperUsuario.Size = New System.Drawing.Size(188, 52)
        Me.grpOperUsuario.TabIndex = 5
        Me.grpOperUsuario.TabStop = False
        Me.grpOperUsuario.Text = "Operaciones"
        '
        'btnSalirUser
        '
        Me.btnSalirUser.BackgroundImage = Global.mantencion.My.Resources.Resources.salir
        Me.btnSalirUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalirUser.Location = New System.Drawing.Point(148, 17)
        Me.btnSalirUser.Name = "btnSalirUser"
        Me.btnSalirUser.Size = New System.Drawing.Size(30, 28)
        Me.btnSalirUser.TabIndex = 4
        Me.ToolTipSalir.SetToolTip(Me.btnSalirUser, "Cerrar Formulario")
        Me.btnSalirUser.UseVisualStyleBackColor = True
        '
        'btnLimpiarUser
        '
        Me.btnLimpiarUser.BackColor = System.Drawing.Color.White
        Me.btnLimpiarUser.BackgroundImage = Global.mantencion.My.Resources.Resources.clear
        Me.btnLimpiarUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiarUser.Location = New System.Drawing.Point(113, 17)
        Me.btnLimpiarUser.Name = "btnLimpiarUser"
        Me.btnLimpiarUser.Size = New System.Drawing.Size(30, 28)
        Me.btnLimpiarUser.TabIndex = 3
        Me.ToolTipLimpiar.SetToolTip(Me.btnLimpiarUser, "Limpiar Campos")
        Me.btnLimpiarUser.UseVisualStyleBackColor = True
        '
        'btnDelUsuario
        '
        Me.btnDelUsuario.BackColor = System.Drawing.Color.White
        Me.btnDelUsuario.BackgroundImage = Global.mantencion.My.Resources.Resources.eliminar
        Me.btnDelUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDelUsuario.Location = New System.Drawing.Point(78, 17)
        Me.btnDelUsuario.Name = "btnDelUsuario"
        Me.btnDelUsuario.Size = New System.Drawing.Size(30, 28)
        Me.btnDelUsuario.TabIndex = 2
        Me.ToolTipEliminar.SetToolTip(Me.btnDelUsuario, "Eliminar")
        Me.btnDelUsuario.UseVisualStyleBackColor = True
        '
        'btnActUsuario
        '
        Me.btnActUsuario.BackColor = System.Drawing.Color.White
        Me.btnActUsuario.BackgroundImage = Global.mantencion.My.Resources.Resources.guardar
        Me.btnActUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnActUsuario.Location = New System.Drawing.Point(43, 17)
        Me.btnActUsuario.Name = "btnActUsuario"
        Me.btnActUsuario.Size = New System.Drawing.Size(30, 28)
        Me.btnActUsuario.TabIndex = 1
        Me.ToolTipActualizar.SetToolTip(Me.btnActUsuario, "Actualizar")
        Me.btnActUsuario.UseVisualStyleBackColor = True
        '
        'btnIngUsuario
        '
        Me.btnIngUsuario.BackColor = System.Drawing.Color.White
        Me.btnIngUsuario.BackgroundImage = Global.mantencion.My.Resources.Resources.icono_escritura
        Me.btnIngUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnIngUsuario.Location = New System.Drawing.Point(8, 17)
        Me.btnIngUsuario.Name = "btnIngUsuario"
        Me.btnIngUsuario.Size = New System.Drawing.Size(30, 28)
        Me.btnIngUsuario.TabIndex = 0
        Me.ToolTipIngresar.SetToolTip(Me.btnIngUsuario, "Ingresar")
        Me.btnIngUsuario.UseVisualStyleBackColor = True
        '
        'grillaUsuarios
        '
        Me.grillaUsuarios.AllowUserToAddRows = False
        Me.grillaUsuarios.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaUsuarios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grillaUsuarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grillaUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grillaUsuarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grillaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaUsuarios.EnableHeadersVisualStyles = False
        Me.grillaUsuarios.Location = New System.Drawing.Point(8, 70)
        Me.grillaUsuarios.MultiSelect = False
        Me.grillaUsuarios.Name = "grillaUsuarios"
        Me.grillaUsuarios.ReadOnly = True
        Me.grillaUsuarios.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.grillaUsuarios.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grillaUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grillaUsuarios.Size = New System.Drawing.Size(1002, 228)
        Me.grillaUsuarios.TabIndex = 6
        '
        'grpActivo
        '
        Me.grpActivo.Controls.Add(Me.opcActivoNo)
        Me.grpActivo.Controls.Add(Me.opcActivoSi)
        Me.grpActivo.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpActivo.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpActivo.Location = New System.Drawing.Point(514, 17)
        Me.grpActivo.Name = "grpActivo"
        Me.grpActivo.Size = New System.Drawing.Size(112, 48)
        Me.grpActivo.TabIndex = 4
        Me.grpActivo.TabStop = False
        Me.grpActivo.Text = "Activo SI / NO"
        '
        'lblBuscarUsuario
        '
        Me.lblBuscarUsuario.AutoSize = True
        Me.lblBuscarUsuario.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscarUsuario.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblBuscarUsuario.Location = New System.Drawing.Point(634, 19)
        Me.lblBuscarUsuario.Name = "lblBuscarUsuario"
        Me.lblBuscarUsuario.Size = New System.Drawing.Size(145, 14)
        Me.lblBuscarUsuario.TabIndex = 5
        Me.lblBuscarUsuario.Text = "Buscar (RUT / Usuario / Perfil)"
        '
        'txtBuscarUsuario
        '
        Me.txtBuscarUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuscarUsuario.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscarUsuario.Location = New System.Drawing.Point(634, 37)
        Me.txtBuscarUsuario.MaxLength = 40
        Me.txtBuscarUsuario.Name = "txtBuscarUsuario"
        Me.txtBuscarUsuario.Size = New System.Drawing.Size(180, 22)
        Me.txtBuscarUsuario.TabIndex = 5
        '
        'opcActivoNo
        '
        Me.opcActivoNo.AutoSize = True
        Me.opcActivoNo.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opcActivoNo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.opcActivoNo.Location = New System.Drawing.Point(58, 20)
        Me.opcActivoNo.Name = "opcActivoNo"
        Me.opcActivoNo.Size = New System.Drawing.Size(40, 17)
        Me.opcActivoNo.TabIndex = 1
        Me.opcActivoNo.TabStop = True
        Me.opcActivoNo.Text = "NO"
        Me.opcActivoNo.UseVisualStyleBackColor = True
        '
        'opcActivoSi
        '
        Me.opcActivoSi.AutoSize = True
        Me.opcActivoSi.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opcActivoSi.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.opcActivoSi.Location = New System.Drawing.Point(10, 20)
        Me.opcActivoSi.Name = "opcActivoSi"
        Me.opcActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.opcActivoSi.TabIndex = 0
        Me.opcActivoSi.TabStop = True
        Me.opcActivoSi.Text = "SI"
        Me.opcActivoSi.UseVisualStyleBackColor = True
        '
        'lblPerfil
        '
        Me.lblPerfil.AutoSize = True
        Me.lblPerfil.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPerfil.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblPerfil.Location = New System.Drawing.Point(344, 19)
        Me.lblPerfil.Name = "lblPerfil"
        Me.lblPerfil.Size = New System.Drawing.Size(32, 14)
        Me.lblPerfil.TabIndex = 3
        Me.lblPerfil.Text = "Perfil"
        '
        'cmbPerfil1
        '
        Me.cmbPerfil1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPerfil1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPerfil1.FormattingEnabled = True
        Me.cmbPerfil1.Location = New System.Drawing.Point(344, 37)
        Me.cmbPerfil1.Name = "cmbPerfil1"
        Me.cmbPerfil1.Size = New System.Drawing.Size(132, 22)
        Me.cmbPerfil1.TabIndex = 3
        '
        'btnGestionPerfiles
        '
        Me.btnGestionPerfiles.BackColor = System.Drawing.Color.White
        Me.btnGestionPerfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGestionPerfiles.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGestionPerfiles.Location = New System.Drawing.Point(478, 36)
        Me.btnGestionPerfiles.Name = "btnGestionPerfiles"
        Me.btnGestionPerfiles.Size = New System.Drawing.Size(28, 24)
        Me.btnGestionPerfiles.TabIndex = 3
        Me.btnGestionPerfiles.Text = "..."
        Me.ToolTipLimpiar.SetToolTip(Me.btnGestionPerfiles, "Gestionar Perfiles (Crear / Renombrar / Eliminar)")
        Me.btnGestionPerfiles.UseVisualStyleBackColor = True
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPass.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblPass.Location = New System.Drawing.Point(242, 19)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(63, 14)
        Me.lblPass.TabIndex = 2
        Me.lblPass.Text = "Contraseña"
        '
        'chkVerClave
        '
        Me.chkVerClave.AutoSize = True
        Me.chkVerClave.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVerClave.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        Me.chkVerClave.Location = New System.Drawing.Point(306, 18)
        Me.chkVerClave.Name = "chkVerClave"
        Me.chkVerClave.Size = New System.Drawing.Size(37, 17)
        Me.chkVerClave.TabIndex = 2
        Me.chkVerClave.Text = "Ver"
        Me.chkVerClave.UseVisualStyleBackColor = True
        '
        'txtClave
        '
        Me.txtClave.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClave.Location = New System.Drawing.Point(242, 37)
        Me.txtClave.MaxLength = 10
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(94, 22)
        Me.txtClave.TabIndex = 2
        Me.txtClave.UseSystemPasswordChar = True
        '
        'lblNomUsuario
        '
        Me.lblNomUsuario.AutoSize = True
        Me.lblNomUsuario.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomUsuario.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblNomUsuario.Location = New System.Drawing.Point(108, 19)
        Me.lblNomUsuario.Name = "lblNomUsuario"
        Me.lblNomUsuario.Size = New System.Drawing.Size(103, 14)
        Me.lblNomUsuario.TabIndex = 1
        Me.lblNomUsuario.Text = "Nombre de Usuario"
        '
        'txtNomUsuario
        '
        Me.txtNomUsuario.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomUsuario.Location = New System.Drawing.Point(108, 37)
        Me.txtNomUsuario.MaxLength = 15
        Me.txtNomUsuario.Name = "txtNomUsuario"
        Me.txtNomUsuario.Size = New System.Drawing.Size(126, 22)
        Me.txtNomUsuario.TabIndex = 1
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblUsuario.Location = New System.Drawing.Point(12, 19)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(24, 14)
        Me.lblUsuario.TabIndex = 0
        Me.lblUsuario.Text = "Rut"
        '
        'txtRutUsuario
        '
        Me.txtRutUsuario.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRutUsuario.Location = New System.Drawing.Point(12, 37)
        Me.txtRutUsuario.MaxLength = 8
        Me.txtRutUsuario.Name = "txtRutUsuario"
        Me.txtRutUsuario.Size = New System.Drawing.Size(88, 22)
        Me.txtRutUsuario.TabIndex = 0
        '
        'grpPermisos
        '
        Me.grpPermisos.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.grpPermisos.Controls.Add(Me.tblContenedorPermisos)
        Me.grpPermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpPermisos.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPermisos.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpPermisos.Location = New System.Drawing.Point(11, 324)
        Me.grpPermisos.Name = "grpPermisos"
        Me.grpPermisos.Padding = New System.Windows.Forms.Padding(6, 4, 6, 6)
        Me.grpPermisos.Size = New System.Drawing.Size(1018, 345)
        Me.grpPermisos.TabIndex = 1
        Me.grpPermisos.TabStop = False
        Me.grpPermisos.Text = "Permisos de Usuario"
        '
        'tblContenedorPermisos
        '
        Me.tblContenedorPermisos.ColumnCount = 1
        Me.tblContenedorPermisos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblContenedorPermisos.Controls.Add(Me.pnlAccionesPermisos, 0, 0)
        Me.tblContenedorPermisos.Controls.Add(Me.tblPermisos, 0, 1)
        Me.tblContenedorPermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblContenedorPermisos.Location = New System.Drawing.Point(6, 20)
        Me.tblContenedorPermisos.Name = "tblContenedorPermisos"
        Me.tblContenedorPermisos.RowCount = 2
        Me.tblContenedorPermisos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.tblContenedorPermisos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblContenedorPermisos.Size = New System.Drawing.Size(1006, 319)
        Me.tblContenedorPermisos.TabIndex = 0
        '
        'pnlAccionesPermisos
        '
        Me.pnlAccionesPermisos.Controls.Add(Me.lblModoUsuario)
        Me.pnlAccionesPermisos.Controls.Add(Me.btnAplicarPlantilla)
        Me.pnlAccionesPermisos.Controls.Add(Me.btnMarcarTodosPerm)
        Me.pnlAccionesPermisos.Controls.Add(Me.btnDesmarcarTodosPerm)
        Me.pnlAccionesPermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAccionesPermisos.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesPermisos.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAccionesPermisos.Name = "pnlAccionesPermisos"
        Me.pnlAccionesPermisos.Size = New System.Drawing.Size(1006, 32)
        Me.pnlAccionesPermisos.TabIndex = 0
        '
        'lblModoUsuario
        '
        Me.lblModoUsuario.AutoSize = True
        Me.lblModoUsuario.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModoUsuario.ForeColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.lblModoUsuario.Location = New System.Drawing.Point(6, 8)
        Me.lblModoUsuario.Name = "lblModoUsuario"
        Me.lblModoUsuario.Size = New System.Drawing.Size(198, 14)
        Me.lblModoUsuario.TabIndex = 0
        Me.lblModoUsuario.Text = "Modo: Nuevo usuario (ingrese datos)"
        '
        'btnAplicarPlantilla
        '
        Me.btnAplicarPlantilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicarPlantilla.Font = New System.Drawing.Font("Calibri", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicarPlantilla.Location = New System.Drawing.Point(568, 3)
        Me.btnAplicarPlantilla.Name = "btnAplicarPlantilla"
        Me.btnAplicarPlantilla.Size = New System.Drawing.Size(176, 25)
        Me.btnAplicarPlantilla.TabIndex = 1
        Me.btnAplicarPlantilla.Text = "Aplicar Plantilla de Perfil"
        Me.btnAplicarPlantilla.UseVisualStyleBackColor = True
        '
        'btnMarcarTodosPerm
        '
        Me.btnMarcarTodosPerm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMarcarTodosPerm.Font = New System.Drawing.Font("Calibri", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMarcarTodosPerm.Location = New System.Drawing.Point(750, 3)
        Me.btnMarcarTodosPerm.Name = "btnMarcarTodosPerm"
        Me.btnMarcarTodosPerm.Size = New System.Drawing.Size(116, 25)
        Me.btnMarcarTodosPerm.TabIndex = 2
        Me.btnMarcarTodosPerm.Text = "Marcar Todos"
        Me.btnMarcarTodosPerm.UseVisualStyleBackColor = True
        '
        'btnDesmarcarTodosPerm
        '
        Me.btnDesmarcarTodosPerm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDesmarcarTodosPerm.Font = New System.Drawing.Font("Calibri", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesmarcarTodosPerm.Location = New System.Drawing.Point(872, 3)
        Me.btnDesmarcarTodosPerm.Name = "btnDesmarcarTodosPerm"
        Me.btnDesmarcarTodosPerm.Size = New System.Drawing.Size(128, 25)
        Me.btnDesmarcarTodosPerm.TabIndex = 3
        Me.btnDesmarcarTodosPerm.Text = "Desmarcar Todos"
        Me.btnDesmarcarTodosPerm.UseVisualStyleBackColor = True
        '
        'tblPermisos
        '
        Me.tblPermisos.ColumnCount = 4
        Me.tblPermisos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tblPermisos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tblPermisos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tblPermisos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tblPermisos.Controls.Add(Me.grpModulos, 0, 0)
        Me.tblPermisos.Controls.Add(Me.grpModOt, 1, 0)
        Me.tblPermisos.Controls.Add(Me.grpModMp, 2, 0)
        Me.tblPermisos.Controls.Add(Me.grpMantenedores, 3, 0)
        Me.tblPermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPermisos.Location = New System.Drawing.Point(0, 32)
        Me.tblPermisos.Margin = New System.Windows.Forms.Padding(0)
        Me.tblPermisos.Name = "tblPermisos"
        Me.tblPermisos.RowCount = 1
        Me.tblPermisos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPermisos.Size = New System.Drawing.Size(1006, 287)
        Me.tblPermisos.TabIndex = 1
        '
        'grpModulos
        '
        Me.grpModulos.Controls.Add(Me.grillaPerModulos)
        Me.grpModulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpModulos.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpModulos.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpModulos.Location = New System.Drawing.Point(3, 3)
        Me.grpModulos.Name = "grpModulos"
        Me.grpModulos.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpModulos.Size = New System.Drawing.Size(245, 313)
        Me.grpModulos.TabIndex = 0
        Me.grpModulos.TabStop = False
        Me.grpModulos.Text = "Acceso a Módulos"
        '
        'grillaPerModulos
        '
        Me.grillaPerModulos.AllowUserToAddRows = False
        Me.grillaPerModulos.AllowUserToDeleteRows = False
        Me.grillaPerModulos.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaPerModulos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grillaPerModulos.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaPerModulos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grillaPerModulos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grillaPerModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaPerModulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaPerModulos.EnableHeadersVisualStyles = False
        Me.grillaPerModulos.Location = New System.Drawing.Point(4, 19)
        Me.grillaPerModulos.Name = "grillaPerModulos"
        Me.grillaPerModulos.RowHeadersVisible = False
        Me.grillaPerModulos.Size = New System.Drawing.Size(237, 290)
        Me.grillaPerModulos.TabIndex = 0
        '
        'grpModOt
        '
        Me.grpModOt.Controls.Add(Me.grillaModOt)
        Me.grpModOt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpModOt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpModOt.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpModOt.Location = New System.Drawing.Point(254, 3)
        Me.grpModOt.Name = "grpModOt"
        Me.grpModOt.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpModOt.Size = New System.Drawing.Size(245, 313)
        Me.grpModOt.TabIndex = 1
        Me.grpModOt.TabStop = False
        Me.grpModOt.Text = "Módulo Orden de Trabajo"
        '
        'grillaModOt
        '
        Me.grillaModOt.AllowUserToAddRows = False
        Me.grillaModOt.AllowUserToDeleteRows = False
        Me.grillaModOt.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaModOt.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.grillaModOt.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaModOt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grillaModOt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grillaModOt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaModOt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaModOt.EnableHeadersVisualStyles = False
        Me.grillaModOt.Location = New System.Drawing.Point(4, 19)
        Me.grillaModOt.Name = "grillaModOt"
        Me.grillaModOt.RowHeadersVisible = False
        Me.grillaModOt.Size = New System.Drawing.Size(237, 290)
        Me.grillaModOt.TabIndex = 0
        '
        'grpModMp
        '
        Me.grpModMp.Controls.Add(Me.grillaPerMp)
        Me.grpModMp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpModMp.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpModMp.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpModMp.Location = New System.Drawing.Point(505, 3)
        Me.grpModMp.Name = "grpModMp"
        Me.grpModMp.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpModMp.Size = New System.Drawing.Size(245, 313)
        Me.grpModMp.TabIndex = 2
        Me.grpModMp.TabStop = False
        Me.grpModMp.Text = "Módulo Mantención Preventiva"
        '
        'grillaPerMp
        '
        Me.grillaPerMp.AllowUserToAddRows = False
        Me.grillaPerMp.AllowUserToDeleteRows = False
        Me.grillaPerMp.AllowUserToResizeRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaPerMp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.grillaPerMp.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaPerMp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grillaPerMp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.grillaPerMp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaPerMp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaPerMp.EnableHeadersVisualStyles = False
        Me.grillaPerMp.Location = New System.Drawing.Point(4, 19)
        Me.grillaPerMp.Name = "grillaPerMp"
        Me.grillaPerMp.RowHeadersVisible = False
        Me.grillaPerMp.Size = New System.Drawing.Size(237, 290)
        Me.grillaPerMp.TabIndex = 0
        '
        'grpMantenedores
        '
        Me.grpMantenedores.Controls.Add(Me.grillaPerMantenedores)
        Me.grpMantenedores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpMantenedores.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMantenedores.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.grpMantenedores.Location = New System.Drawing.Point(756, 3)
        Me.grpMantenedores.Name = "grpMantenedores"
        Me.grpMantenedores.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpMantenedores.Size = New System.Drawing.Size(247, 313)
        Me.grpMantenedores.TabIndex = 3
        Me.grpMantenedores.TabStop = False
        Me.grpMantenedores.Text = "Módulo Mantenedores"
        '
        'grillaPerMantenedores
        '
        Me.grillaPerMantenedores.AllowUserToAddRows = False
        Me.grillaPerMantenedores.AllowUserToDeleteRows = False
        Me.grillaPerMantenedores.AllowUserToResizeRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaPerMantenedores.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.grillaPerMantenedores.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        Me.grillaPerMantenedores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grillaPerMantenedores.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grillaPerMantenedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaPerMantenedores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grillaPerMantenedores.EnableHeadersVisualStyles = False
        Me.grillaPerMantenedores.Location = New System.Drawing.Point(4, 19)
        Me.grillaPerMantenedores.Name = "grillaPerMantenedores"
        Me.grillaPerMantenedores.RowHeadersVisible = False
        Me.grillaPerMantenedores.Size = New System.Drawing.Size(239, 290)
        Me.grillaPerMantenedores.TabIndex = 0
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
        'FrmAdminUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(1040, 680)
        Me.ControlBox = False
        Me.Controls.Add(Me.tblPrincipal)
        Me.MinimumSize = New System.Drawing.Size(900, 560)
        Me.Name = "FrmAdminUsuarios"
        Me.Text = "Administración de Usuarios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.tblPrincipal.ResumeLayout(False)
        Me.GrpUsuarios.ResumeLayout(False)
        Me.GrpUsuarios.PerformLayout()
        Me.grpOperUsuario.ResumeLayout(False)
        CType(Me.grillaUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpActivo.ResumeLayout(False)
        Me.grpActivo.PerformLayout()
        Me.grpPermisos.ResumeLayout(False)
        Me.tblContenedorPermisos.ResumeLayout(False)
        Me.pnlAccionesPermisos.ResumeLayout(False)
        Me.pnlAccionesPermisos.PerformLayout()
        Me.tblPermisos.ResumeLayout(False)
        Me.grpModulos.ResumeLayout(False)
        CType(Me.grillaPerModulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpModOt.ResumeLayout(False)
        CType(Me.grillaModOt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpModMp.ResumeLayout(False)
        CType(Me.grillaPerMp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMantenedores.ResumeLayout(False)
        CType(Me.grillaPerMantenedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tblPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GrpUsuarios As System.Windows.Forms.GroupBox
    Friend WithEvents grpOperUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents btnSalirUser As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarUser As System.Windows.Forms.Button
    Friend WithEvents btnDelUsuario As System.Windows.Forms.Button
    Friend WithEvents btnActUsuario As System.Windows.Forms.Button
    Friend WithEvents btnIngUsuario As System.Windows.Forms.Button
    Friend WithEvents grillaUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents grpActivo As System.Windows.Forms.GroupBox
    Friend WithEvents opcActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents opcActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblBuscarUsuario As System.Windows.Forms.Label
    Friend WithEvents txtBuscarUsuario As System.Windows.Forms.TextBox
    Friend WithEvents btnGestionPerfiles As System.Windows.Forms.Button
    Friend WithEvents lblPerfil As System.Windows.Forms.Label
    Friend WithEvents cmbPerfil1 As System.Windows.Forms.ComboBox
    Friend WithEvents chkVerClave As System.Windows.Forms.CheckBox
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents lblNomUsuario As System.Windows.Forms.Label
    Friend WithEvents txtNomUsuario As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents txtRutUsuario As System.Windows.Forms.TextBox
    Friend WithEvents grpPermisos As System.Windows.Forms.GroupBox
    Friend WithEvents tblContenedorPermisos As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlAccionesPermisos As System.Windows.Forms.Panel
    Friend WithEvents lblModoUsuario As System.Windows.Forms.Label
    Friend WithEvents btnAplicarPlantilla As System.Windows.Forms.Button
    Friend WithEvents btnMarcarTodosPerm As System.Windows.Forms.Button
    Friend WithEvents btnDesmarcarTodosPerm As System.Windows.Forms.Button
    Friend WithEvents tblPermisos As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpModulos As System.Windows.Forms.GroupBox
    Friend WithEvents grillaPerModulos As System.Windows.Forms.DataGridView
    Friend WithEvents grpModOt As System.Windows.Forms.GroupBox
    Friend WithEvents grillaModOt As System.Windows.Forms.DataGridView
    Friend WithEvents grpModMp As System.Windows.Forms.GroupBox
    Friend WithEvents grillaPerMp As System.Windows.Forms.DataGridView
    Friend WithEvents grpMantenedores As System.Windows.Forms.GroupBox
    Friend WithEvents grillaPerMantenedores As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTipIngresar As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipActualizar As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipEliminar As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipLimpiar As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipSalir As System.Windows.Forms.ToolTip
End Class
