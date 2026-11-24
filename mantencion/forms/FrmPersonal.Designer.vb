<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPersonal
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
        Me.components = New System.ComponentModel.Container()
        Me.grpBoxPersonal = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.fecha_ingreso = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.lblAlias = New System.Windows.Forms.Label()
        Me.txtAlias = New System.Windows.Forms.TextBox()
        Me.btnBuscarPersonal = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtfono = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.fecha_nac = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtApMaterno = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtApPaterno = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.txtCodInt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDv = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRut = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpBoxInfLaboral = New System.Windows.Forms.GroupBox()
        Me.lblModoEdicion = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.opc_activo_no = New System.Windows.Forms.RadioButton()
        Me.opc_activo_si = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbCargo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbSeccion = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbPlanta = New System.Windows.Forms.ComboBox()
        Me.grpBoxOperaciones = New System.Windows.Forms.GroupBox()
        Me.btnExportarPdf = New System.Windows.Forms.Button()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.btnCrearUsuario = New System.Windows.Forms.Button()
        Me.btnSalirPersonal = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.grpListadoPersonal = New System.Windows.Forms.GroupBox()
        Me.lblFiltroBuscar = New System.Windows.Forms.Label()
        Me.txtFiltroPersonal = New System.Windows.Forms.TextBox()
        Me.lblFiltroEstado = New System.Windows.Forms.Label()
        Me.cmbFiltroEstado = New System.Windows.Forms.ComboBox()
        Me.lblFiltroPlanta = New System.Windows.Forms.Label()
        Me.cmbFiltroPlanta = New System.Windows.Forms.ComboBox()
        Me.lblFiltroSeccion = New System.Windows.Forms.Label()
        Me.cmbFiltroSeccion = New System.Windows.Forms.ComboBox()
        Me.lblFiltroCargo = New System.Windows.Forms.Label()
        Me.cmbFiltroCargo = New System.Windows.Forms.ComboBox()
        Me.btnRefrescarLista = New System.Windows.Forms.Button()
        Me.pnlLotePersonal = New System.Windows.Forms.Panel()
        Me.chkSelTodosPersonal = New System.Windows.Forms.CheckBox()
        Me.lblSeleccionLote = New System.Windows.Forms.Label()
        Me.btnLoteActivar = New System.Windows.Forms.Button()
        Me.btnLoteDesactivar = New System.Windows.Forms.Button()
        Me.btnLoteReasignar = New System.Windows.Forms.Button()
        Me.btnLoteEliminar = New System.Windows.Forms.Button()
        Me.btnLoteDesmarcar = New System.Windows.Forms.Button()
        Me.lblResumenListado = New System.Windows.Forms.Label()
        Me.dgvPersonal = New System.Windows.Forms.DataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpBoxPersonal.SuspendLayout()
        Me.grpBoxInfLaboral.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpBoxOperaciones.SuspendLayout()
        Me.grpListadoPersonal.SuspendLayout()
        Me.pnlLotePersonal.SuspendLayout()
        CType(Me.dgvPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBoxPersonal
        '
        Me.grpBoxPersonal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpBoxPersonal.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.grpBoxPersonal.Controls.Add(Me.Label15)
        Me.grpBoxPersonal.Controls.Add(Me.fecha_ingreso)
        Me.grpBoxPersonal.Controls.Add(Me.Label14)
        Me.grpBoxPersonal.Controls.Add(Me.txtDireccion)
        Me.grpBoxPersonal.Controls.Add(Me.Label13)
        Me.grpBoxPersonal.Controls.Add(Me.txtCelular)
        Me.grpBoxPersonal.Controls.Add(Me.lblAlias)
        Me.grpBoxPersonal.Controls.Add(Me.txtAlias)
        Me.grpBoxPersonal.Controls.Add(Me.btnBuscarPersonal)
        Me.grpBoxPersonal.Controls.Add(Me.Label9)
        Me.grpBoxPersonal.Controls.Add(Me.txtEmail)
        Me.grpBoxPersonal.Controls.Add(Me.Label8)
        Me.grpBoxPersonal.Controls.Add(Me.txtfono)
        Me.grpBoxPersonal.Controls.Add(Me.Label7)
        Me.grpBoxPersonal.Controls.Add(Me.fecha_nac)
        Me.grpBoxPersonal.Controls.Add(Me.Label6)
        Me.grpBoxPersonal.Controls.Add(Me.txtApMaterno)
        Me.grpBoxPersonal.Controls.Add(Me.Label5)
        Me.grpBoxPersonal.Controls.Add(Me.txtApPaterno)
        Me.grpBoxPersonal.Controls.Add(Me.Label4)
        Me.grpBoxPersonal.Controls.Add(Me.txtNombres)
        Me.grpBoxPersonal.Controls.Add(Me.txtCodInt)
        Me.grpBoxPersonal.Controls.Add(Me.Label3)
        Me.grpBoxPersonal.Controls.Add(Me.txtDv)
        Me.grpBoxPersonal.Controls.Add(Me.Label2)
        Me.grpBoxPersonal.Controls.Add(Me.txtRut)
        Me.grpBoxPersonal.Controls.Add(Me.Label1)
        Me.grpBoxPersonal.Location = New System.Drawing.Point(12, 8)
        Me.grpBoxPersonal.Name = "grpBoxPersonal"
        Me.grpBoxPersonal.Size = New System.Drawing.Size(1136, 130)
        Me.grpBoxPersonal.TabIndex = 0
        Me.grpBoxPersonal.TabStop = False
        Me.grpBoxPersonal.Text = "Información Personal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RUT"
        '
        'txtRut
        '
        Me.txtRut.BackColor = System.Drawing.Color.White
        Me.txtRut.Location = New System.Drawing.Point(12, 37)
        Me.txtRut.MaxLength = 10
        Me.txtRut.Name = "txtRut"
        Me.txtRut.Size = New System.Drawing.Size(86, 23)
        Me.txtRut.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(101, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "-"
        '
        'txtDv
        '
        Me.txtDv.BackColor = System.Drawing.Color.White
        Me.txtDv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDv.Location = New System.Drawing.Point(114, 37)
        Me.txtDv.MaxLength = 1
        Me.txtDv.Name = "txtDv"
        Me.txtDv.Size = New System.Drawing.Size(24, 23)
        Me.txtDv.TabIndex = 3
        '
        'btnBuscarPersonal
        '
        Me.btnBuscarPersonal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarPersonal.Image = Global.mantencion.My.Resources.Resources._16__Find_
        Me.btnBuscarPersonal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarPersonal.Location = New System.Drawing.Point(144, 34)
        Me.btnBuscarPersonal.Name = "btnBuscarPersonal"
        Me.btnBuscarPersonal.Size = New System.Drawing.Size(88, 28)
        Me.btnBuscarPersonal.TabIndex = 4
        Me.btnBuscarPersonal.Text = "Buscar"
        Me.btnBuscarPersonal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnBuscarPersonal, "Abrir buscador clásico de personal")
        Me.btnBuscarPersonal.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(242, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Cód. Interno"
        '
        'txtCodInt
        '
        Me.txtCodInt.BackColor = System.Drawing.Color.White
        Me.txtCodInt.Location = New System.Drawing.Point(242, 37)
        Me.txtCodInt.MaxLength = 10
        Me.txtCodInt.Name = "txtCodInt"
        Me.txtCodInt.Size = New System.Drawing.Size(82, 23)
        Me.txtCodInt.TabIndex = 6
        Me.txtCodInt.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(334, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Nombres"
        '
        'txtNombres
        '
        Me.txtNombres.BackColor = System.Drawing.Color.White
        Me.txtNombres.Location = New System.Drawing.Point(334, 37)
        Me.txtNombres.MaxLength = 30
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(185, 23)
        Me.txtNombres.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(529, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Apellido Paterno"
        '
        'txtApPaterno
        '
        Me.txtApPaterno.BackColor = System.Drawing.Color.White
        Me.txtApPaterno.Location = New System.Drawing.Point(529, 37)
        Me.txtApPaterno.MaxLength = 30
        Me.txtApPaterno.Name = "txtApPaterno"
        Me.txtApPaterno.Size = New System.Drawing.Size(185, 23)
        Me.txtApPaterno.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(724, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Apellido Materno"
        '
        'txtApMaterno
        '
        Me.txtApMaterno.BackColor = System.Drawing.Color.White
        Me.txtApMaterno.Location = New System.Drawing.Point(724, 37)
        Me.txtApMaterno.MaxLength = 30
        Me.txtApMaterno.Name = "txtApMaterno"
        Me.txtApMaterno.Size = New System.Drawing.Size(185, 23)
        Me.txtApMaterno.TabIndex = 12
        '
        'lblAlias
        '
        Me.lblAlias.AutoSize = True
        Me.lblAlias.Location = New System.Drawing.Point(919, 19)
        Me.lblAlias.Name = "lblAlias"
        Me.lblAlias.Size = New System.Drawing.Size(34, 15)
        Me.lblAlias.TabIndex = 13
        Me.lblAlias.Text = "Alias"
        '
        'txtAlias
        '
        Me.txtAlias.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAlias.BackColor = System.Drawing.Color.White
        Me.txtAlias.Location = New System.Drawing.Point(919, 37)
        Me.txtAlias.MaxLength = 15
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Size = New System.Drawing.Size(205, 23)
        Me.txtAlias.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 15)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Fecha Nacimiento"
        '
        'fecha_nac
        '
        Me.fecha_nac.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_nac.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_nac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_nac.Location = New System.Drawing.Point(12, 89)
        Me.fecha_nac.Name = "fecha_nac"
        Me.fecha_nac.Size = New System.Drawing.Size(118, 23)
        Me.fecha_nac.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(140, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 15)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Fono"
        '
        'txtfono
        '
        Me.txtfono.BackColor = System.Drawing.Color.White
        Me.txtfono.Location = New System.Drawing.Point(140, 89)
        Me.txtfono.MaxLength = 9
        Me.txtfono.Name = "txtfono"
        Me.txtfono.Size = New System.Drawing.Size(104, 23)
        Me.txtfono.TabIndex = 18
        Me.txtfono.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(254, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 15)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Celular"
        '
        'txtCelular
        '
        Me.txtCelular.BackColor = System.Drawing.Color.White
        Me.txtCelular.Location = New System.Drawing.Point(254, 89)
        Me.txtCelular.MaxLength = 9
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(104, 23)
        Me.txtCelular.TabIndex = 20
        Me.txtCelular.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(368, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 15)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Correo Electrónico"
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.White
        Me.txtEmail.Location = New System.Drawing.Point(368, 89)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(276, 23)
        Me.txtEmail.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(654, 71)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 15)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Dirección"
        '
        'txtDireccion
        '
        Me.txtDireccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDireccion.BackColor = System.Drawing.Color.White
        Me.txtDireccion.Location = New System.Drawing.Point(654, 89)
        Me.txtDireccion.MaxLength = 150
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(336, 23)
        Me.txtDireccion.TabIndex = 24
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(1002, 71)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 15)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Fecha de Ingreso"
        '
        'fecha_ingreso
        '
        Me.fecha_ingreso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fecha_ingreso.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_ingreso.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_ingreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_ingreso.Location = New System.Drawing.Point(1002, 89)
        Me.fecha_ingreso.Name = "fecha_ingreso"
        Me.fecha_ingreso.Size = New System.Drawing.Size(122, 23)
        Me.fecha_ingreso.TabIndex = 26
        '
        'grpBoxInfLaboral
        '
        Me.grpBoxInfLaboral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpBoxInfLaboral.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.grpBoxInfLaboral.Controls.Add(Me.lblModoEdicion)
        Me.grpBoxInfLaboral.Controls.Add(Me.GroupBox1)
        Me.grpBoxInfLaboral.Controls.Add(Me.Label12)
        Me.grpBoxInfLaboral.Controls.Add(Me.cmbCargo)
        Me.grpBoxInfLaboral.Controls.Add(Me.Label11)
        Me.grpBoxInfLaboral.Controls.Add(Me.cmbSeccion)
        Me.grpBoxInfLaboral.Controls.Add(Me.Label10)
        Me.grpBoxInfLaboral.Controls.Add(Me.cmbPlanta)
        Me.grpBoxInfLaboral.Location = New System.Drawing.Point(12, 142)
        Me.grpBoxInfLaboral.Name = "grpBoxInfLaboral"
        Me.grpBoxInfLaboral.Size = New System.Drawing.Size(1136, 66)
        Me.grpBoxInfLaboral.TabIndex = 1
        Me.grpBoxInfLaboral.TabStop = False
        Me.grpBoxInfLaboral.Text = "Información Laboral y Estado"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 15)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Planta"
        '
        'cmbPlanta
        '
        Me.cmbPlanta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlanta.FormattingEnabled = True
        Me.cmbPlanta.Location = New System.Drawing.Point(12, 34)
        Me.cmbPlanta.Name = "cmbPlanta"
        Me.cmbPlanta.Size = New System.Drawing.Size(198, 23)
        Me.cmbPlanta.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(220, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 15)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Sección"
        '
        'cmbSeccion
        '
        Me.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeccion.FormattingEnabled = True
        Me.cmbSeccion.Location = New System.Drawing.Point(220, 34)
        Me.cmbSeccion.Name = "cmbSeccion"
        Me.cmbSeccion.Size = New System.Drawing.Size(198, 23)
        Me.cmbSeccion.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(428, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 15)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Cargo"
        '
        'cmbCargo
        '
        Me.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCargo.FormattingEnabled = True
        Me.cmbCargo.Location = New System.Drawing.Point(428, 34)
        Me.cmbCargo.Name = "cmbCargo"
        Me.cmbCargo.Size = New System.Drawing.Size(198, 23)
        Me.cmbCargo.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.opc_activo_no)
        Me.GroupBox1.Controls.Add(Me.opc_activo_si)
        Me.GroupBox1.Location = New System.Drawing.Point(638, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(134, 48)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Activo"
        '
        'opc_activo_si
        '
        Me.opc_activo_si.AutoSize = True
        Me.opc_activo_si.Checked = True
        Me.opc_activo_si.Location = New System.Drawing.Point(14, 20)
        Me.opc_activo_si.Name = "opc_activo_si"
        Me.opc_activo_si.Size = New System.Drawing.Size(37, 19)
        Me.opc_activo_si.TabIndex = 0
        Me.opc_activo_si.TabStop = True
        Me.opc_activo_si.Text = "Sí"
        Me.opc_activo_si.UseVisualStyleBackColor = True
        '
        'opc_activo_no
        '
        Me.opc_activo_no.AutoSize = True
        Me.opc_activo_no.Location = New System.Drawing.Point(72, 20)
        Me.opc_activo_no.Name = "opc_activo_no"
        Me.opc_activo_no.Size = New System.Drawing.Size(42, 19)
        Me.opc_activo_no.TabIndex = 1
        Me.opc_activo_no.Text = "No"
        Me.opc_activo_no.UseVisualStyleBackColor = True
        '
        'lblModoEdicion
        '
        Me.lblModoEdicion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModoEdicion.AutoEllipsis = True
        Me.lblModoEdicion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblModoEdicion.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblModoEdicion.Location = New System.Drawing.Point(784, 20)
        Me.lblModoEdicion.Name = "lblModoEdicion"
        Me.lblModoEdicion.Size = New System.Drawing.Size(340, 38)
        Me.lblModoEdicion.TabIndex = 7
        Me.lblModoEdicion.Text = "Modo: Nuevo trabajador (haga clic en una fila para editar)"
        Me.lblModoEdicion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpBoxOperaciones
        '
        Me.grpBoxOperaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpBoxOperaciones.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.grpBoxOperaciones.Controls.Add(Me.btnSalirPersonal)
        Me.grpBoxOperaciones.Controls.Add(Me.btnExportarPdf)
        Me.grpBoxOperaciones.Controls.Add(Me.btnExportarExcel)
        Me.grpBoxOperaciones.Controls.Add(Me.btnCrearUsuario)
        Me.grpBoxOperaciones.Controls.Add(Me.btnLimpiar)
        Me.grpBoxOperaciones.Controls.Add(Me.btnEliminar)
        Me.grpBoxOperaciones.Controls.Add(Me.btnActualizar)
        Me.grpBoxOperaciones.Controls.Add(Me.btnIngresar)
        Me.grpBoxOperaciones.Location = New System.Drawing.Point(12, 212)
        Me.grpBoxOperaciones.Name = "grpBoxOperaciones"
        Me.grpBoxOperaciones.Size = New System.Drawing.Size(1136, 56)
        Me.grpBoxOperaciones.TabIndex = 2
        Me.grpBoxOperaciones.TabStop = False
        Me.grpBoxOperaciones.Text = "Operaciones CRUD"
        '
        'btnIngresar
        '
        Me.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIngresar.Image = Global.mantencion.My.Resources.Resources.add
        Me.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngresar.Location = New System.Drawing.Point(12, 18)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(106, 32)
        Me.btnIngresar.TabIndex = 0
        Me.btnIngresar.Text = "Ingresar"
        Me.btnIngresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip2.SetToolTip(Me.btnIngresar, "Registrar nuevo trabajador")
        Me.btnIngresar.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActualizar.Enabled = False
        Me.btnActualizar.Image = Global.mantencion.My.Resources.Resources.guardar
        Me.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizar.Location = New System.Drawing.Point(124, 18)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(116, 32)
        Me.btnActualizar.TabIndex = 1
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip3.SetToolTip(Me.btnActualizar, "Guardar cambios del trabajador seleccionado")
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = Global.mantencion.My.Resources.Resources.eliminar
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(246, 18)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(104, 32)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnEliminar, "Eliminar trabajador seleccionado (sin historial asociado)")
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Image = Global.mantencion.My.Resources.Resources.clear
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(356, 18)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(140, 32)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.Text = "Nuevo / Limpiar"
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar formulario para crear un nuevo trabajador")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCrearUsuario
        '
        Me.btnCrearUsuario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCrearUsuario.Image = Global.mantencion.My.Resources.Resources.Nuevo_Usuario
        Me.btnCrearUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCrearUsuario.Location = New System.Drawing.Point(508, 18)
        Me.btnCrearUsuario.Name = "btnCrearUsuario"
        Me.btnCrearUsuario.Size = New System.Drawing.Size(134, 32)
        Me.btnCrearUsuario.TabIndex = 4
        Me.btnCrearUsuario.Text = "Crear Usuario"
        Me.btnCrearUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnCrearUsuario, "Crear cuenta de acceso para el trabajador cargado")
        Me.btnCrearUsuario.UseVisualStyleBackColor = True
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportarExcel.Image = Global.mantencion.My.Resources.Resources.icono_excel1
        Me.btnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportarExcel.Location = New System.Drawing.Point(654, 18)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(92, 32)
        Me.btnExportarExcel.TabIndex = 5
        Me.btnExportarExcel.Text = "Excel"
        Me.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnExportarExcel, "Exportar listado filtrado de personal a Excel")
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'btnExportarPdf
        '
        Me.btnExportarPdf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportarPdf.Image = Global.mantencion.My.Resources.Resources.icono_pdf
        Me.btnExportarPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportarPdf.Location = New System.Drawing.Point(752, 18)
        Me.btnExportarPdf.Name = "btnExportarPdf"
        Me.btnExportarPdf.Size = New System.Drawing.Size(84, 32)
        Me.btnExportarPdf.TabIndex = 6
        Me.btnExportarPdf.Text = "PDF"
        Me.btnExportarPdf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnExportarPdf, "Exportar listado filtrado de personal a PDF horizontal")
        Me.btnExportarPdf.UseVisualStyleBackColor = True
        '
        'btnSalirPersonal
        '
        Me.btnSalirPersonal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalirPersonal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalirPersonal.Image = Global.mantencion.My.Resources.Resources.salir
        Me.btnSalirPersonal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalirPersonal.Location = New System.Drawing.Point(1036, 18)
        Me.btnSalirPersonal.Name = "btnSalirPersonal"
        Me.btnSalirPersonal.Size = New System.Drawing.Size(88, 32)
        Me.btnSalirPersonal.TabIndex = 7
        Me.btnSalirPersonal.Text = "Salir"
        Me.btnSalirPersonal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnSalirPersonal, "Cerrar Gestión de Personal")
        Me.btnSalirPersonal.UseVisualStyleBackColor = True
        '
        'grpListadoPersonal
        '
        Me.grpListadoPersonal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpListadoPersonal.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.grpListadoPersonal.Controls.Add(Me.dgvPersonal)
        Me.grpListadoPersonal.Controls.Add(Me.pnlLotePersonal)
        Me.grpListadoPersonal.Controls.Add(Me.btnRefrescarLista)
        Me.grpListadoPersonal.Controls.Add(Me.cmbFiltroCargo)
        Me.grpListadoPersonal.Controls.Add(Me.lblFiltroCargo)
        Me.grpListadoPersonal.Controls.Add(Me.cmbFiltroSeccion)
        Me.grpListadoPersonal.Controls.Add(Me.lblFiltroSeccion)
        Me.grpListadoPersonal.Controls.Add(Me.cmbFiltroPlanta)
        Me.grpListadoPersonal.Controls.Add(Me.lblFiltroPlanta)
        Me.grpListadoPersonal.Controls.Add(Me.cmbFiltroEstado)
        Me.grpListadoPersonal.Controls.Add(Me.lblFiltroEstado)
        Me.grpListadoPersonal.Controls.Add(Me.txtFiltroPersonal)
        Me.grpListadoPersonal.Controls.Add(Me.lblFiltroBuscar)
        Me.grpListadoPersonal.Location = New System.Drawing.Point(12, 272)
        Me.grpListadoPersonal.Name = "grpListadoPersonal"
        Me.grpListadoPersonal.Size = New System.Drawing.Size(1136, 416)
        Me.grpListadoPersonal.TabIndex = 3
        Me.grpListadoPersonal.TabStop = False
        Me.grpListadoPersonal.Text = "Padrón Completo de Personal y Gestión por Lotes"
        '
        'lblFiltroBuscar
        '
        Me.lblFiltroBuscar.AutoSize = True
        Me.lblFiltroBuscar.Location = New System.Drawing.Point(12, 24)
        Me.lblFiltroBuscar.Name = "lblFiltroBuscar"
        Me.lblFiltroBuscar.Size = New System.Drawing.Size(44, 15)
        Me.lblFiltroBuscar.TabIndex = 0
        Me.lblFiltroBuscar.Text = "Buscar:"
        '
        'txtFiltroPersonal
        '
        Me.txtFiltroPersonal.BackColor = System.Drawing.Color.White
        Me.txtFiltroPersonal.Location = New System.Drawing.Point(60, 21)
        Me.txtFiltroPersonal.Name = "txtFiltroPersonal"
        Me.txtFiltroPersonal.PlaceholderText = "RUT, nombre, alias, código o correo..."
        Me.txtFiltroPersonal.Size = New System.Drawing.Size(200, 23)
        Me.txtFiltroPersonal.TabIndex = 1
        '
        'lblFiltroEstado
        '
        Me.lblFiltroEstado.AutoSize = True
        Me.lblFiltroEstado.Location = New System.Drawing.Point(268, 24)
        Me.lblFiltroEstado.Name = "lblFiltroEstado"
        Me.lblFiltroEstado.Size = New System.Drawing.Size(44, 15)
        Me.lblFiltroEstado.TabIndex = 2
        Me.lblFiltroEstado.Text = "Estado:"
        '
        'cmbFiltroEstado
        '
        Me.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFiltroEstado.FormattingEnabled = True
        Me.cmbFiltroEstado.Location = New System.Drawing.Point(314, 21)
        Me.cmbFiltroEstado.Name = "cmbFiltroEstado"
        Me.cmbFiltroEstado.Size = New System.Drawing.Size(88, 23)
        Me.cmbFiltroEstado.TabIndex = 3
        '
        'lblFiltroPlanta
        '
        Me.lblFiltroPlanta.AutoSize = True
        Me.lblFiltroPlanta.Location = New System.Drawing.Point(410, 24)
        Me.lblFiltroPlanta.Name = "lblFiltroPlanta"
        Me.lblFiltroPlanta.Size = New System.Drawing.Size(42, 15)
        Me.lblFiltroPlanta.TabIndex = 4
        Me.lblFiltroPlanta.Text = "Planta:"
        '
        'cmbFiltroPlanta
        '
        Me.cmbFiltroPlanta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFiltroPlanta.FormattingEnabled = True
        Me.cmbFiltroPlanta.Location = New System.Drawing.Point(454, 21)
        Me.cmbFiltroPlanta.Name = "cmbFiltroPlanta"
        Me.cmbFiltroPlanta.Size = New System.Drawing.Size(140, 23)
        Me.cmbFiltroPlanta.TabIndex = 5
        '
        'lblFiltroSeccion
        '
        Me.lblFiltroSeccion.AutoSize = True
        Me.lblFiltroSeccion.Location = New System.Drawing.Point(602, 24)
        Me.lblFiltroSeccion.Name = "lblFiltroSeccion"
        Me.lblFiltroSeccion.Size = New System.Drawing.Size(50, 15)
        Me.lblFiltroSeccion.TabIndex = 6
        Me.lblFiltroSeccion.Text = "Sección:"
        '
        'cmbFiltroSeccion
        '
        Me.cmbFiltroSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFiltroSeccion.FormattingEnabled = True
        Me.cmbFiltroSeccion.Location = New System.Drawing.Point(654, 21)
        Me.cmbFiltroSeccion.Name = "cmbFiltroSeccion"
        Me.cmbFiltroSeccion.Size = New System.Drawing.Size(140, 23)
        Me.cmbFiltroSeccion.TabIndex = 7
        '
        'lblFiltroCargo
        '
        Me.lblFiltroCargo.AutoSize = True
        Me.lblFiltroCargo.Location = New System.Drawing.Point(802, 24)
        Me.lblFiltroCargo.Name = "lblFiltroCargo"
        Me.lblFiltroCargo.Size = New System.Drawing.Size(40, 15)
        Me.lblFiltroCargo.TabIndex = 8
        Me.lblFiltroCargo.Text = "Cargo:"
        '
        'cmbFiltroCargo
        '
        Me.cmbFiltroCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFiltroCargo.FormattingEnabled = True
        Me.cmbFiltroCargo.Location = New System.Drawing.Point(844, 21)
        Me.cmbFiltroCargo.Name = "cmbFiltroCargo"
        Me.cmbFiltroCargo.Size = New System.Drawing.Size(140, 23)
        Me.cmbFiltroCargo.TabIndex = 9
        '
        'btnRefrescarLista
        '
        Me.btnRefrescarLista.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefrescarLista.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefrescarLista.Image = Global.mantencion.My.Resources.Resources.clear
        Me.btnRefrescarLista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefrescarLista.Location = New System.Drawing.Point(1008, 18)
        Me.btnRefrescarLista.Name = "btnRefrescarLista"
        Me.btnRefrescarLista.Size = New System.Drawing.Size(116, 28)
        Me.btnRefrescarLista.TabIndex = 10
        Me.btnRefrescarLista.Text = "Refrescar"
        Me.btnRefrescarLista.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnRefrescarLista, "Recargar listado completo desde base de datos y limpiar filtros")
        Me.btnRefrescarLista.UseVisualStyleBackColor = True
        '
        'pnlLotePersonal
        '
        Me.pnlLotePersonal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlLotePersonal.BackColor = System.Drawing.Color.FromArgb(224, 244, 246)
        Me.pnlLotePersonal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLotePersonal.Controls.Add(Me.lblResumenListado)
        Me.pnlLotePersonal.Controls.Add(Me.btnLoteDesmarcar)
        Me.pnlLotePersonal.Controls.Add(Me.btnLoteEliminar)
        Me.pnlLotePersonal.Controls.Add(Me.btnLoteReasignar)
        Me.pnlLotePersonal.Controls.Add(Me.btnLoteDesactivar)
        Me.pnlLotePersonal.Controls.Add(Me.btnLoteActivar)
        Me.pnlLotePersonal.Controls.Add(Me.lblSeleccionLote)
        Me.pnlLotePersonal.Controls.Add(Me.chkSelTodosPersonal)
        Me.pnlLotePersonal.Location = New System.Drawing.Point(10, 52)
        Me.pnlLotePersonal.Name = "pnlLotePersonal"
        Me.pnlLotePersonal.Size = New System.Drawing.Size(1114, 42)
        Me.pnlLotePersonal.TabIndex = 11
        '
        'chkSelTodosPersonal
        '
        Me.chkSelTodosPersonal.AutoSize = True
        Me.chkSelTodosPersonal.Location = New System.Drawing.Point(10, 11)
        Me.chkSelTodosPersonal.Name = "chkSelTodosPersonal"
        Me.chkSelTodosPersonal.Size = New System.Drawing.Size(86, 19)
        Me.chkSelTodosPersonal.TabIndex = 0
        Me.chkSelTodosPersonal.Text = "Sel. visibles"
        Me.chkSelTodosPersonal.UseVisualStyleBackColor = True
        '
        'lblSeleccionLote
        '
        Me.lblSeleccionLote.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSeleccionLote.ForeColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.lblSeleccionLote.Location = New System.Drawing.Point(102, 11)
        Me.lblSeleccionLote.Name = "lblSeleccionLote"
        Me.lblSeleccionLote.Size = New System.Drawing.Size(96, 18)
        Me.lblSeleccionLote.TabIndex = 1
        Me.lblSeleccionLote.Text = "0 marcados"
        Me.lblSeleccionLote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLoteActivar
        '
        Me.btnLoteActivar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoteActivar.Enabled = False
        Me.btnLoteActivar.Image = Global.mantencion.My.Resources.Resources.checklist
        Me.btnLoteActivar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoteActivar.Location = New System.Drawing.Point(202, 5)
        Me.btnLoteActivar.Name = "btnLoteActivar"
        Me.btnLoteActivar.Size = New System.Drawing.Size(122, 30)
        Me.btnLoteActivar.TabIndex = 2
        Me.btnLoteActivar.Text = "Activar Lote"
        Me.btnLoteActivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnLoteActivar, "Marcar como Activos a todos los trabajadores seleccionados")
        Me.btnLoteActivar.UseVisualStyleBackColor = True
        '
        'btnLoteDesactivar
        '
        Me.btnLoteDesactivar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoteDesactivar.Enabled = False
        Me.btnLoteDesactivar.Image = Global.mantencion.My.Resources.Resources.action_remove
        Me.btnLoteDesactivar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoteDesactivar.Location = New System.Drawing.Point(330, 5)
        Me.btnLoteDesactivar.Name = "btnLoteDesactivar"
        Me.btnLoteDesactivar.Size = New System.Drawing.Size(140, 30)
        Me.btnLoteDesactivar.TabIndex = 3
        Me.btnLoteDesactivar.Text = "Desactivar Lote"
        Me.btnLoteDesactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnLoteDesactivar, "Marcar como Inactivos a todos los trabajadores seleccionados")
        Me.btnLoteDesactivar.UseVisualStyleBackColor = True
        '
        'btnLoteReasignar
        '
        Me.btnLoteReasignar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoteReasignar.Enabled = False
        Me.btnLoteReasignar.Image = Global.mantencion.My.Resources.Resources.icono_escritura_2
        Me.btnLoteReasignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoteReasignar.Location = New System.Drawing.Point(476, 5)
        Me.btnLoteReasignar.Name = "btnLoteReasignar"
        Me.btnLoteReasignar.Size = New System.Drawing.Size(156, 30)
        Me.btnLoteReasignar.TabIndex = 4
        Me.btnLoteReasignar.Text = "Reasignar Laboral"
        Me.btnLoteReasignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnLoteReasignar, "Cambiar Planta, Sección y/o Cargo a todos los trabajadores marcados")
        Me.btnLoteReasignar.UseVisualStyleBackColor = True
        '
        'btnLoteEliminar
        '
        Me.btnLoteEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoteEliminar.Enabled = False
        Me.btnLoteEliminar.Image = Global.mantencion.My.Resources.Resources.eliminar
        Me.btnLoteEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoteEliminar.Location = New System.Drawing.Point(638, 5)
        Me.btnLoteEliminar.Name = "btnLoteEliminar"
        Me.btnLoteEliminar.Size = New System.Drawing.Size(126, 30)
        Me.btnLoteEliminar.TabIndex = 5
        Me.btnLoteEliminar.Text = "Eliminar Lote"
        Me.btnLoteEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnLoteEliminar, "Eliminar en lote los trabajadores marcados sin historial asociado")
        Me.btnLoteEliminar.UseVisualStyleBackColor = True
        '
        'btnLoteDesmarcar
        '
        Me.btnLoteDesmarcar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoteDesmarcar.Enabled = False
        Me.btnLoteDesmarcar.Image = Global.mantencion.My.Resources.Resources.clear
        Me.btnLoteDesmarcar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoteDesmarcar.Location = New System.Drawing.Point(770, 5)
        Me.btnLoteDesmarcar.Name = "btnLoteDesmarcar"
        Me.btnLoteDesmarcar.Size = New System.Drawing.Size(118, 30)
        Me.btnLoteDesmarcar.TabIndex = 6
        Me.btnLoteDesmarcar.Text = "Limpiar Sel."
        Me.btnLoteDesmarcar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnLoteDesmarcar, "Desmarcar todas las casillas seleccionadas")
        Me.btnLoteDesmarcar.UseVisualStyleBackColor = True
        '
        'lblResumenListado
        '
        Me.lblResumenListado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResumenListado.AutoEllipsis = True
        Me.lblResumenListado.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular)
        Me.lblResumenListado.ForeColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.lblResumenListado.Location = New System.Drawing.Point(894, 11)
        Me.lblResumenListado.Name = "lblResumenListado"
        Me.lblResumenListado.Size = New System.Drawing.Size(212, 18)
        Me.lblResumenListado.TabIndex = 7
        Me.lblResumenListado.Text = "0 registros"
        Me.lblResumenListado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvPersonal
        '
        Me.dgvPersonal.AllowUserToAddRows = False
        Me.dgvPersonal.AllowUserToDeleteRows = False
        Me.dgvPersonal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPersonal.BackgroundColor = System.Drawing.Color.White
        Me.dgvPersonal.Location = New System.Drawing.Point(10, 98)
        Me.dgvPersonal.MultiSelect = True
        Me.dgvPersonal.Name = "dgvPersonal"
        Me.dgvPersonal.ReadOnly = True
        Me.dgvPersonal.RowHeadersVisible = False
        Me.dgvPersonal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPersonal.Size = New System.Drawing.Size(1114, 308)
        Me.dgvPersonal.TabIndex = 12
        '
        'FrmPersonal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(1160, 700)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpListadoPersonal)
        Me.Controls.Add(Me.grpBoxOperaciones)
        Me.Controls.Add(Me.grpBoxInfLaboral)
        Me.Controls.Add(Me.grpBoxPersonal)
        Me.Name = "FrmPersonal"
        Me.Text = "Gestión de Personal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.grpBoxPersonal.ResumeLayout(False)
        Me.grpBoxPersonal.PerformLayout()
        Me.grpBoxInfLaboral.ResumeLayout(False)
        Me.grpBoxInfLaboral.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpBoxOperaciones.ResumeLayout(False)
        Me.grpListadoPersonal.ResumeLayout(False)
        Me.grpListadoPersonal.PerformLayout()
        Me.pnlLotePersonal.ResumeLayout(False)
        Me.pnlLotePersonal.PerformLayout()
        CType(Me.dgvPersonal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents grpBoxPersonal As System.Windows.Forms.GroupBox
    Friend WithEvents txtDv As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRut As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents txtCodInt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtApPaterno As System.Windows.Forms.TextBox
    Friend WithEvents txtApMaterno As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtfono As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents fecha_nac As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpBoxInfLaboral As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbPlanta As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSeccion As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbCargo As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents grpBoxOperaciones As System.Windows.Forms.GroupBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
    Friend WithEvents btnBuscarPersonal As System.Windows.Forms.Button
    Friend WithEvents lblAlias As System.Windows.Forms.Label
    Friend WithEvents txtAlias As System.Windows.Forms.TextBox
    Friend WithEvents btnSalirPersonal As System.Windows.Forms.Button
    Friend WithEvents btnCrearUsuario As System.Windows.Forms.Button
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents btnExportarPdf As System.Windows.Forms.Button
    Friend WithEvents opc_activo_si As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents opc_activo_no As System.Windows.Forms.RadioButton
    Friend WithEvents lblModoEdicion As System.Windows.Forms.Label
    Friend WithEvents grpListadoPersonal As System.Windows.Forms.GroupBox
    Friend WithEvents lblFiltroBuscar As System.Windows.Forms.Label
    Friend WithEvents txtFiltroPersonal As System.Windows.Forms.TextBox
    Friend WithEvents lblFiltroEstado As System.Windows.Forms.Label
    Friend WithEvents cmbFiltroEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblFiltroPlanta As System.Windows.Forms.Label
    Friend WithEvents cmbFiltroPlanta As System.Windows.Forms.ComboBox
    Friend WithEvents lblFiltroSeccion As System.Windows.Forms.Label
    Friend WithEvents cmbFiltroSeccion As System.Windows.Forms.ComboBox
    Friend WithEvents lblFiltroCargo As System.Windows.Forms.Label
    Friend WithEvents cmbFiltroCargo As System.Windows.Forms.ComboBox
    Friend WithEvents btnRefrescarLista As System.Windows.Forms.Button
    Friend WithEvents pnlLotePersonal As System.Windows.Forms.Panel
    Friend WithEvents chkSelTodosPersonal As System.Windows.Forms.CheckBox
    Friend WithEvents lblSeleccionLote As System.Windows.Forms.Label
    Friend WithEvents btnLoteActivar As System.Windows.Forms.Button
    Friend WithEvents btnLoteDesactivar As System.Windows.Forms.Button
    Friend WithEvents btnLoteReasignar As System.Windows.Forms.Button
    Friend WithEvents btnLoteEliminar As System.Windows.Forms.Button
    Friend WithEvents btnLoteDesmarcar As System.Windows.Forms.Button
    Friend WithEvents lblResumenListado As System.Windows.Forms.Label
    Friend WithEvents dgvPersonal As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents fecha_ingreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
End Class
