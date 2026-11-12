<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPersonal
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
        Me.grpBoxPersonal = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.fecha_ingreso = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtCelular = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.opc_activo_no = New System.Windows.Forms.RadioButton
        Me.opc_activo_si = New System.Windows.Forms.RadioButton
        Me.btnCrearUsuario = New System.Windows.Forms.Button
        Me.lblAlias = New System.Windows.Forms.Label
        Me.txtAlias = New System.Windows.Forms.TextBox
        Me.btnBuscarPersonal = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtfono = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.fecha_nac = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtApMaterno = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtApPaterno = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtNombres = New System.Windows.Forms.TextBox
        Me.txtCodInt = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDv = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtRut = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpBoxInfLaboral = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbCargo = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbSeccion = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbPlanta = New System.Windows.Forms.ComboBox
        Me.grpBoxOperaciones = New System.Windows.Forms.GroupBox
        Me.btnSalirPersonal = New System.Windows.Forms.Button
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnActualizar = New System.Windows.Forms.Button
        Me.btnIngresar = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpBoxPersonal.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpBoxInfLaboral.SuspendLayout()
        Me.grpBoxOperaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpBoxPersonal
        '
        Me.grpBoxPersonal.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.grpBoxPersonal.Controls.Add(Me.Label15)
        Me.grpBoxPersonal.Controls.Add(Me.fecha_ingreso)
        Me.grpBoxPersonal.Controls.Add(Me.Label14)
        Me.grpBoxPersonal.Controls.Add(Me.txtDireccion)
        Me.grpBoxPersonal.Controls.Add(Me.Label13)
        Me.grpBoxPersonal.Controls.Add(Me.txtCelular)
        Me.grpBoxPersonal.Controls.Add(Me.GroupBox1)
        Me.grpBoxPersonal.Controls.Add(Me.btnCrearUsuario)
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
        Me.grpBoxPersonal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBoxPersonal.Location = New System.Drawing.Point(12, 12)
        Me.grpBoxPersonal.Name = "grpBoxPersonal"
        Me.grpBoxPersonal.Size = New System.Drawing.Size(996, 198)
        Me.grpBoxPersonal.TabIndex = 0
        Me.grpBoxPersonal.TabStop = False
        Me.grpBoxPersonal.Text = "Información Personal"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(362, 140)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 15)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Fecha de Ingreso"
        '
        'fecha_ingreso
        '
        Me.fecha_ingreso.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_ingreso.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_ingreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_ingreso.Location = New System.Drawing.Point(362, 157)
        Me.fecha_ingreso.Name = "fecha_ingreso"
        Me.fecha_ingreso.Size = New System.Drawing.Size(97, 23)
        Me.fecha_ingreso.TabIndex = 24
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 139)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 15)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Dirección"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.White
        Me.txtDireccion.Location = New System.Drawing.Point(13, 157)
        Me.txtDireccion.MaxLength = 150
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(340, 23)
        Me.txtDireccion.TabIndex = 22
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(250, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 15)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Celular"
        '
        'txtCelular
        '
        Me.txtCelular.BackColor = System.Drawing.Color.White
        Me.txtCelular.Location = New System.Drawing.Point(253, 105)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(100, 23)
        Me.txtCelular.TabIndex = 20
        Me.txtCelular.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.opc_activo_no)
        Me.GroupBox1.Controls.Add(Me.opc_activo_si)
        Me.GroupBox1.Location = New System.Drawing.Point(714, 88)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(103, 53)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Activo"
        '
        'opc_activo_no
        '
        Me.opc_activo_no.AutoSize = True
        Me.opc_activo_no.Location = New System.Drawing.Point(57, 20)
        Me.opc_activo_no.Name = "opc_activo_no"
        Me.opc_activo_no.Size = New System.Drawing.Size(40, 19)
        Me.opc_activo_no.TabIndex = 21
        Me.opc_activo_no.Text = "No"
        Me.opc_activo_no.UseVisualStyleBackColor = True
        '
        'opc_activo_si
        '
        Me.opc_activo_si.AutoSize = True
        Me.opc_activo_si.Checked = True
        Me.opc_activo_si.Location = New System.Drawing.Point(6, 20)
        Me.opc_activo_si.Name = "opc_activo_si"
        Me.opc_activo_si.Size = New System.Drawing.Size(35, 19)
        Me.opc_activo_si.TabIndex = 20
        Me.opc_activo_si.TabStop = True
        Me.opc_activo_si.Text = "Si"
        Me.opc_activo_si.UseVisualStyleBackColor = True
        '
        'btnCrearUsuario
        '
        Me.btnCrearUsuario.BackgroundImage = Global.mantencion.My.Resources.Resources.Nuevo_Usuario
        Me.btnCrearUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCrearUsuario.Location = New System.Drawing.Point(856, 99)
        Me.btnCrearUsuario.Name = "btnCrearUsuario"
        Me.btnCrearUsuario.Size = New System.Drawing.Size(29, 33)
        Me.btnCrearUsuario.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btnCrearUsuario, "Crear Usuario")
        Me.btnCrearUsuario.UseVisualStyleBackColor = True
        '
        'lblAlias
        '
        Me.lblAlias.AutoSize = True
        Me.lblAlias.Location = New System.Drawing.Point(903, 29)
        Me.lblAlias.Name = "lblAlias"
        Me.lblAlias.Size = New System.Drawing.Size(35, 15)
        Me.lblAlias.TabIndex = 19
        Me.lblAlias.Text = "Alias"
        '
        'txtAlias
        '
        Me.txtAlias.BackColor = System.Drawing.Color.White
        Me.txtAlias.Location = New System.Drawing.Point(905, 47)
        Me.txtAlias.MaxLength = 15
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Size = New System.Drawing.Size(76, 23)
        Me.txtAlias.TabIndex = 18
        '
        'btnBuscarPersonal
        '
        Me.btnBuscarPersonal.Image = Global.mantencion.My.Resources.Resources._16__Find_
        Me.btnBuscarPersonal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarPersonal.Location = New System.Drawing.Point(152, 46)
        Me.btnBuscarPersonal.Name = "btnBuscarPersonal"
        Me.btnBuscarPersonal.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscarPersonal.TabIndex = 3
        Me.btnBuscarPersonal.Text = "     Buscar"
        Me.btnBuscarPersonal.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(359, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 15)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Correo Electrónico"
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.White
        Me.txtEmail.Location = New System.Drawing.Point(362, 105)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(337, 23)
        Me.txtEmail.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(135, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 15)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Fono"
        '
        'txtfono
        '
        Me.txtfono.BackColor = System.Drawing.Color.White
        Me.txtfono.Location = New System.Drawing.Point(138, 104)
        Me.txtfono.MaxLength = 20
        Me.txtfono.Name = "txtfono"
        Me.txtfono.Size = New System.Drawing.Size(100, 23)
        Me.txtfono.TabIndex = 14
        Me.txtfono.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 30)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Fecha " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nacimiento"
        '
        'fecha_nac
        '
        Me.fecha_nac.CalendarTitleBackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.fecha_nac.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(120, 140, 150)
        Me.fecha_nac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_nac.Location = New System.Drawing.Point(13, 104)
        Me.fecha_nac.Name = "fecha_nac"
        Me.fecha_nac.Size = New System.Drawing.Size(94, 23)
        Me.fecha_nac.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(714, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Apellido Materno"
        '
        'txtApMaterno
        '
        Me.txtApMaterno.BackColor = System.Drawing.Color.White
        Me.txtApMaterno.Location = New System.Drawing.Point(714, 46)
        Me.txtApMaterno.Name = "txtApMaterno"
        Me.txtApMaterno.Size = New System.Drawing.Size(171, 23)
        Me.txtApMaterno.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(532, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Apellido Paterno"
        '
        'txtApPaterno
        '
        Me.txtApPaterno.BackColor = System.Drawing.Color.White
        Me.txtApPaterno.Location = New System.Drawing.Point(535, 46)
        Me.txtApPaterno.Name = "txtApPaterno"
        Me.txtApPaterno.Size = New System.Drawing.Size(164, 23)
        Me.txtApPaterno.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(359, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Nombres"
        '
        'txtNombres
        '
        Me.txtNombres.BackColor = System.Drawing.Color.White
        Me.txtNombres.Location = New System.Drawing.Point(362, 46)
        Me.txtNombres.MaxLength = 30
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(155, 23)
        Me.txtNombres.TabIndex = 6
        '
        'txtCodInt
        '
        Me.txtCodInt.BackColor = System.Drawing.Color.White
        Me.txtCodInt.Location = New System.Drawing.Point(253, 46)
        Me.txtCodInt.MaxLength = 10
        Me.txtCodInt.Name = "txtCodInt"
        Me.txtCodInt.Size = New System.Drawing.Size(73, 23)
        Me.txtCodInt.TabIndex = 5
        Me.txtCodInt.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(250, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 30)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Codigo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Interno"
        '
        'txtDv
        '
        Me.txtDv.BackColor = System.Drawing.Color.White
        Me.txtDv.Location = New System.Drawing.Point(110, 46)
        Me.txtDv.MaxLength = 1
        Me.txtDv.Name = "txtDv"
        Me.txtDv.Size = New System.Drawing.Size(20, 23)
        Me.txtDv.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(94, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "-"
        '
        'txtRut
        '
        Me.txtRut.BackColor = System.Drawing.Color.White
        Me.txtRut.Location = New System.Drawing.Point(10, 46)
        Me.txtRut.MaxLength = 8
        Me.txtRut.Name = "txtRut"
        Me.txtRut.Size = New System.Drawing.Size(78, 23)
        Me.txtRut.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(7, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Rut"
        '
        'grpBoxInfLaboral
        '
        Me.grpBoxInfLaboral.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.grpBoxInfLaboral.Controls.Add(Me.Label12)
        Me.grpBoxInfLaboral.Controls.Add(Me.cmbCargo)
        Me.grpBoxInfLaboral.Controls.Add(Me.Label11)
        Me.grpBoxInfLaboral.Controls.Add(Me.cmbSeccion)
        Me.grpBoxInfLaboral.Controls.Add(Me.Label10)
        Me.grpBoxInfLaboral.Controls.Add(Me.cmbPlanta)
        Me.grpBoxInfLaboral.Location = New System.Drawing.Point(12, 227)
        Me.grpBoxInfLaboral.Name = "grpBoxInfLaboral"
        Me.grpBoxInfLaboral.Size = New System.Drawing.Size(572, 89)
        Me.grpBoxInfLaboral.TabIndex = 1
        Me.grpBoxInfLaboral.TabStop = False
        Me.grpBoxInfLaboral.Text = "Información Laboral"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(333, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 15)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Cargo"
        '
        'cmbCargo
        '
        Me.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCargo.FormattingEnabled = True
        Me.cmbCargo.Location = New System.Drawing.Point(336, 48)
        Me.cmbCargo.Name = "cmbCargo"
        Me.cmbCargo.Size = New System.Drawing.Size(181, 21)
        Me.cmbCargo.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(165, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 15)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Sección"
        '
        'cmbSeccion
        '
        Me.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeccion.FormattingEnabled = True
        Me.cmbSeccion.Location = New System.Drawing.Point(168, 48)
        Me.cmbSeccion.Name = "cmbSeccion"
        Me.cmbSeccion.Size = New System.Drawing.Size(157, 21)
        Me.cmbSeccion.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 15)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Planta"
        '
        'cmbPlanta
        '
        Me.cmbPlanta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlanta.FormattingEnabled = True
        Me.cmbPlanta.Location = New System.Drawing.Point(10, 48)
        Me.cmbPlanta.Name = "cmbPlanta"
        Me.cmbPlanta.Size = New System.Drawing.Size(140, 21)
        Me.cmbPlanta.TabIndex = 0
        '
        'grpBoxOperaciones
        '
        Me.grpBoxOperaciones.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.grpBoxOperaciones.Controls.Add(Me.btnSalirPersonal)
        Me.grpBoxOperaciones.Controls.Add(Me.btnLimpiar)
        Me.grpBoxOperaciones.Controls.Add(Me.btnEliminar)
        Me.grpBoxOperaciones.Controls.Add(Me.btnActualizar)
        Me.grpBoxOperaciones.Controls.Add(Me.btnIngresar)
        Me.grpBoxOperaciones.Location = New System.Drawing.Point(706, 227)
        Me.grpBoxOperaciones.Name = "grpBoxOperaciones"
        Me.grpBoxOperaciones.Size = New System.Drawing.Size(191, 59)
        Me.grpBoxOperaciones.TabIndex = 2
        Me.grpBoxOperaciones.TabStop = False
        Me.grpBoxOperaciones.Text = "Operaciones"
        '
        'btnSalirPersonal
        '
        Me.btnSalirPersonal.BackgroundImage = Global.mantencion.My.Resources.Resources.salir
        Me.btnSalirPersonal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalirPersonal.Location = New System.Drawing.Point(147, 19)
        Me.btnSalirPersonal.Name = "btnSalirPersonal"
        Me.btnSalirPersonal.Size = New System.Drawing.Size(29, 29)
        Me.btnSalirPersonal.TabIndex = 4
        Me.btnSalirPersonal.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.mantencion.My.Resources.Resources.clear
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiar.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Location = New System.Drawing.Point(112, 19)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(29, 29)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.BackgroundImage = Global.mantencion.My.Resources.Resources.eliminar
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(77, 19)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(29, 29)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.BackgroundImage = Global.mantencion.My.Resources.Resources.guardar
        Me.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnActualizar.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizar.Location = New System.Drawing.Point(41, 19)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(29, 29)
        Me.btnActualizar.TabIndex = 1
        Me.ToolTip3.SetToolTip(Me.btnActualizar, "Actualizar Personal")
        Me.btnActualizar.UseVisualStyleBackColor = True
        Me.btnActualizar.Visible = False
        '
        'btnIngresar
        '
        Me.btnIngresar.BackgroundImage = Global.mantencion.My.Resources.Resources.icono_escritura
        Me.btnIngresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnIngresar.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresar.Location = New System.Drawing.Point(6, 19)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(29, 29)
        Me.btnIngresar.TabIndex = 0
        Me.ToolTip2.SetToolTip(Me.btnIngresar, "Ingresar Personal")
        Me.btnIngresar.UseVisualStyleBackColor = True
        '
        'FrmPersonal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(1020, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpBoxOperaciones)
        Me.Controls.Add(Me.grpBoxInfLaboral)
        Me.Controls.Add(Me.grpBoxPersonal)
        Me.Name = "FrmPersonal"
        Me.Text = "Gestión de Personal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.grpBoxPersonal.ResumeLayout(False)
        Me.grpBoxPersonal.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpBoxInfLaboral.ResumeLayout(False)
        Me.grpBoxInfLaboral.PerformLayout()
        Me.grpBoxOperaciones.ResumeLayout(False)
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
    Friend WithEvents opc_activo_si As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents opc_activo_no As System.Windows.Forms.RadioButton
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
