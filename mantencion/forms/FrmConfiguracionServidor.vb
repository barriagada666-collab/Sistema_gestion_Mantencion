Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class FrmConfiguracionServidor
    Inherits Form

    Private panHeader As Panel
    Private lblTituloHeader As Label
    Private lblSubtituloHeader As Label

    Private grpParametros As GroupBox
    Private lblServidor As Label
    Private txtServidor As TextBox
    Private lblCatalogo As Label
    Private txtCatalogo As TextBox
    Private lblUsuario As Label
    Private txtUsuario As TextBox
    Private lblPassword As Label
    Private txtPassword As TextBox
    Private chkMostrarPassword As CheckBox
    Private lblTimeout As Label
    Private numTimeout As NumericUpDown

    Private lblPreview As Label
    Private txtPreview As TextBox

    Private lblEstado As Label
    Private panBotones As Panel
    Private WithEvents btnProbar As Button
    Private WithEvents btnRestaurar As Button
    Private WithEvents btnVerLogs As Button
    Private WithEvents btnGuardar As Button
    Private WithEvents btnCancelar As Button

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Configuración de Servidor de Base de Datos"
        Me.Size = New Size(640, 575)
        Me.MinimumSize = New Size(640, 575)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterParent
        Me.DoubleBuffered = True
        Me.BackColor = Utilitarios.ColorFondoForm
        Me.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point)

        ' 1. Header Banner
        panHeader = New Panel()
        panHeader.Dock = DockStyle.Top
        panHeader.Height = 65
        panHeader.BackColor = Utilitarios.ColorPrimario

        lblTituloHeader = New Label()
        lblTituloHeader.Text = "Servidor de Base de Datos - Cambiaso Hnos. S.A.C."
        lblTituloHeader.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
        lblTituloHeader.ForeColor = Color.White
        lblTituloHeader.Location = New Point(16, 10)
        lblTituloHeader.AutoSize = True

        lblSubtituloHeader = New Label()
        lblSubtituloHeader.Text = "Ajuste el servidor y credenciales SQL. Se creará un respaldo automático antes de guardar."
        lblSubtituloHeader.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point)
        lblSubtituloHeader.ForeColor = Color.FromArgb(224, 244, 246)
        lblSubtituloHeader.Location = New Point(17, 36)
        lblSubtituloHeader.AutoSize = True

        panHeader.Controls.Add(lblTituloHeader)
        panHeader.Controls.Add(lblSubtituloHeader)

        ' 2. GroupBox Parámetros
        grpParametros = New GroupBox()
        grpParametros.Text = " Parámetros de Conexión SQL Server "
        grpParametros.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point)
        grpParametros.ForeColor = Utilitarios.ColorPrimario
        grpParametros.Location = New Point(16, 75)
        grpParametros.Size = New Size(592, 280)
        grpParametros.BackColor = Color.White

        ' Servidor
        lblServidor = New Label()
        lblServidor.Text = "Servidor / Host:"
        lblServidor.Location = New Point(20, 32)
        lblServidor.Size = New Size(140, 20)
        lblServidor.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblServidor.ForeColor = Utilitarios.ColorTextoPrincipal

        txtServidor = New TextBox()
        txtServidor.Location = New Point(165, 29)
        txtServidor.Size = New Size(400, 24)
        txtServidor.Font = New Font("Segoe UI", 9.0F)

        ' Catálogo / BD
        lblCatalogo = New Label()
        lblCatalogo.Text = "Base de Datos:"
        lblCatalogo.Location = New Point(20, 68)
        lblCatalogo.Size = New Size(140, 20)
        lblCatalogo.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblCatalogo.ForeColor = Utilitarios.ColorTextoPrincipal

        txtCatalogo = New TextBox()
        txtCatalogo.Location = New Point(165, 65)
        txtCatalogo.Size = New Size(400, 24)
        txtCatalogo.Font = New Font("Segoe UI", 9.0F)

        ' Usuario
        lblUsuario = New Label()
        lblUsuario.Text = "Usuario SQL:"
        lblUsuario.Location = New Point(20, 104)
        lblUsuario.Size = New Size(140, 20)
        lblUsuario.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblUsuario.ForeColor = Utilitarios.ColorTextoPrincipal

        txtUsuario = New TextBox()
        txtUsuario.Location = New Point(165, 101)
        txtUsuario.Size = New Size(400, 24)
        txtUsuario.Font = New Font("Segoe UI", 9.0F)

        ' Contraseña
        lblPassword = New Label()
        lblPassword.Text = "Contraseña SQL:"
        lblPassword.Location = New Point(20, 140)
        lblPassword.Size = New Size(140, 20)
        lblPassword.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblPassword.ForeColor = Utilitarios.ColorTextoPrincipal

        txtPassword = New TextBox()
        txtPassword.Location = New Point(165, 137)
        txtPassword.Size = New Size(250, 24)
        txtPassword.Font = New Font("Segoe UI", 9.0F)
        txtPassword.PasswordChar = "*"c

        chkMostrarPassword = New CheckBox()
        chkMostrarPassword.Text = "Mostrar"
        chkMostrarPassword.Location = New Point(425, 138)
        chkMostrarPassword.Size = New Size(80, 22)
        chkMostrarPassword.Font = New Font("Segoe UI", 8.5F)
        chkMostrarPassword.ForeColor = Utilitarios.ColorTextoPrincipal

        ' Timeout
        lblTimeout = New Label()
        lblTimeout.Text = "Timeout (segundos):"
        lblTimeout.Location = New Point(20, 176)
        lblTimeout.Size = New Size(140, 20)
        lblTimeout.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblTimeout.ForeColor = Utilitarios.ColorTextoPrincipal

        numTimeout = New NumericUpDown()
        numTimeout.Location = New Point(165, 173)
        numTimeout.Size = New Size(80, 24)
        numTimeout.Minimum = 5
        numTimeout.Maximum = 120
        numTimeout.Value = 15
        numTimeout.Font = New Font("Segoe UI", 9.0F)

        ' Preview de cadena
        lblPreview = New Label()
        lblPreview.Text = "Cadena Resultante:"
        lblPreview.Location = New Point(20, 210)
        lblPreview.Size = New Size(140, 20)
        lblPreview.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular)
        lblPreview.ForeColor = Utilitarios.ColorTextoAtenuado

        txtPreview = New TextBox()
        txtPreview.Location = New Point(20, 232)
        txtPreview.Size = New Size(545, 36)
        txtPreview.Multiline = True
        txtPreview.ReadOnly = True
        txtPreview.Font = New Font("Consolas", 8.0F)
        txtPreview.BackColor = Utilitarios.ColorFondoSoloLectura
        txtPreview.ForeColor = Utilitarios.ColorTextoPrincipal

        grpParametros.Controls.AddRange(New Control() {
            lblServidor, txtServidor,
            lblCatalogo, txtCatalogo,
            lblUsuario, txtUsuario,
            lblPassword, txtPassword, chkMostrarPassword,
            lblTimeout, numTimeout,
            lblPreview, txtPreview
        })

        ' 3. Estado de conexión
        lblEstado = New Label()
        lblEstado.Location = New Point(16, 362)
        lblEstado.Size = New Size(592, 52)
        lblEstado.Padding = New Padding(6, 4, 6, 4)
        lblEstado.Font = New Font("Segoe UI", 8.75F, FontStyle.Bold)
        lblEstado.TextAlign = ContentAlignment.MiddleLeft
        lblEstado.AutoEllipsis = True
        lblEstado.BackColor = Color.White
        lblEstado.BorderStyle = BorderStyle.FixedSingle
        lblEstado.Text = "Ingrese los datos del servidor y presione 'Probar Conexión' o 'Guardar'."
        lblEstado.ForeColor = Utilitarios.ColorTextoPrincipal

        ' 4. Panel de botones
        panBotones = New Panel()
        panBotones.Dock = DockStyle.Bottom
        panBotones.Height = 65
        panBotones.BackColor = Color.FromArgb(242, 246, 246)

        btnProbar = New Button()
        btnProbar.Text = "⚡ Probar Conexión"
        btnProbar.Location = New Point(16, 14)
        btnProbar.Size = New Size(134, 36)
        btnProbar.Font = New Font("Segoe UI", 8.75F, FontStyle.Bold)

        btnRestaurar = New Button()
        btnRestaurar.Text = "↺ Original"
        btnRestaurar.Location = New Point(156, 14)
        btnRestaurar.Size = New Size(96, 36)
        btnRestaurar.Font = New Font("Segoe UI", 8.75F)

        btnVerLogs = New Button()
        btnVerLogs.Text = "📋 Logs"
        btnVerLogs.Location = New Point(258, 14)
        btnVerLogs.Size = New Size(86, 36)
        btnVerLogs.Font = New Font("Segoe UI", 8.75F)

        btnGuardar = New Button()
        btnGuardar.Text = "💾 Guardar y Aplicar"
        btnGuardar.Location = New Point(358, 14)
        btnGuardar.Size = New Size(148, 36)
        btnGuardar.Font = New Font("Segoe UI", 8.75F, FontStyle.Bold)
        btnGuardar.BackColor = Utilitarios.ColorPrimario
        btnGuardar.ForeColor = Color.White

        btnCancelar = New Button()
        btnCancelar.Text = "Cancelar"
        btnCancelar.Location = New Point(512, 14)
        btnCancelar.Size = New Size(96, 36)
        btnCancelar.Font = New Font("Segoe UI", 8.75F)

        panBotones.Controls.AddRange(New Control() {btnProbar, btnRestaurar, btnVerLogs, btnGuardar, btnCancelar})

        Me.Controls.AddRange(New Control() {panHeader, grpParametros, lblEstado, panBotones})

        ' Eventos de actualización en tiempo real
        AddHandler txtServidor.TextChanged, AddressOf ActualizarPreview
        AddHandler txtCatalogo.TextChanged, AddressOf ActualizarPreview
        AddHandler txtUsuario.TextChanged, AddressOf ActualizarPreview
        AddHandler txtPassword.TextChanged, AddressOf ActualizarPreview
        AddHandler numTimeout.ValueChanged, AddressOf ActualizarPreview
        AddHandler chkMostrarPassword.CheckedChanged, Sub() txtPassword.PasswordChar = If(chkMostrarPassword.Checked, ControlChars.NullChar, "*"c)
        AddHandler Me.Load, AddressOf FrmConfiguracionServidor_Load
    End Sub

    Private Sub FrmConfiguracionServidor_Load(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim builder As SqlConnectionStringBuilder = Conexion.ObtenerParametrosActuales()
            txtServidor.Text = builder.DataSource
            txtCatalogo.Text = builder.InitialCatalog
            txtUsuario.Text = builder.UserID
            txtPassword.Text = builder.Password
            If builder.ConnectTimeout >= numTimeout.Minimum AndAlso builder.ConnectTimeout <= numTimeout.Maximum Then
                numTimeout.Value = builder.ConnectTimeout
            Else
                numTimeout.Value = 15
            End If
        Catch
            txtServidor.Text = "SrvMagicInfo"
            txtCatalogo.Text = "mantencion"
            txtUsuario.Text = "mantencion"
            txtPassword.Text = "cambiaso"
            numTimeout.Value = 15
        End Try
        ActualizarPreview(Nothing, EventArgs.Empty)
    End Sub

    Private Function ConstruirCadena() As String
        Dim sb As New SqlConnectionStringBuilder()
        sb.DataSource = txtServidor.Text.Trim()
        sb.InitialCatalog = txtCatalogo.Text.Trim()
        sb.UserID = txtUsuario.Text.Trim()
        sb.Password = txtPassword.Text
        sb.ConnectTimeout = CInt(numTimeout.Value)
        sb.Pooling = True
        sb.ApplicationName = "Sistema de Gestion Mantencion"
        Return sb.ConnectionString
    End Function

    Private Sub ActualizarPreview(ByVal sender As Object, ByVal e As EventArgs)
        Try
            txtPreview.Text = ConstruirCadena()
        Catch ex As Exception
            txtPreview.Text = "Error en parámetros: " & ex.Message
        End Try
    End Sub

    Private Sub btnProbar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnProbar.Click
        lblEstado.Text = " Probando conexión con el servidor SQL..."
        lblEstado.BackColor = Color.FromArgb(254, 243, 199)
        lblEstado.ForeColor = Color.FromArgb(146, 64, 14)
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Dim cadena As String = ConstruirCadena()
        Dim resultado = Conexion.ProbarConexion(cadena)

        Me.Cursor = Cursors.Default
        If resultado.Exito Then
            lblEstado.Text = " ✓ " & resultado.Mensaje
            lblEstado.BackColor = Color.FromArgb(220, 252, 231)
            lblEstado.ForeColor = Color.FromArgb(22, 101, 52)
        Else
            lblEstado.Text = " ✗ Error de conexión: " & resultado.Mensaje
            lblEstado.BackColor = Color.FromArgb(254, 226, 226)
            lblEstado.ForeColor = Color.FromArgb(153, 27, 27)
        End If
    End Sub

    Private Sub btnRestaurar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRestaurar.Click
        Dim resp = MessageBox.Show("¿Desea restablecer los valores de conexión originales de fábrica (SrvMagicInfo)?",
                                   "Restaurar Conexión Original", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = DialogResult.Yes Then
            txtServidor.Text = "SrvMagicInfo"
            txtCatalogo.Text = "mantencion"
            txtUsuario.Text = "mantencion"
            txtPassword.Text = "cambiaso"
            numTimeout.Value = 15
            ActualizarPreview(Nothing, EventArgs.Empty)
            lblEstado.Text = " Se cargaron los valores de fábrica. Presione 'Guardar y Aplicar' para confirmar."
            lblEstado.BackColor = Color.FromArgb(224, 244, 246)
            lblEstado.ForeColor = Utilitarios.ColorPrimario
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGuardar.Click
        If String.IsNullOrWhiteSpace(txtServidor.Text) Then
            MessageBox.Show("Debe especificar el Servidor / Host de SQL Server.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtServidor.Focus()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtCatalogo.Text) Then
            MessageBox.Show("Debe especificar la Base de Datos / Catálogo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCatalogo.Focus()
            Exit Sub
        End If

        Dim confirm = MessageBox.Show("Se actualizará la configuración de conexión del sistema." & vbCrLf & vbCrLf &
                                      "Se creará una copia de seguridad automática de la configuración original." & vbCrLf & vbCrLf &
                                      "¿Desea guardar y aplicar los cambios ahora?",
                                      "Confirmar Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Exit Sub

        Dim nuevaCadena As String = ConstruirCadena()
        Dim resultado = Conexion.GuardarNuevaConexion(nuevaCadena)

        If resultado.Exito Then
            MessageBox.Show("La configuración de conexión ha sido actualizada exitosamente." & vbCrLf & vbCrLf &
                            "Servidor: " & txtServidor.Text.Trim() & vbCrLf &
                            "Base de Datos: " & txtCatalogo.Text.Trim() & vbCrLf &
                            "Usuario: " & txtUsuario.Text.Trim() & vbCrLf & vbCrLf &
                            "Los respaldos se almacenaron en la carpeta de la aplicación.",
                            "Configuración Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show(resultado.Mensaje, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnVerLogs_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVerLogs.Click
        RegistroErrores.AbrirCarpetaLogs()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
