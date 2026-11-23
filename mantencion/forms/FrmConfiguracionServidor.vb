Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class FrmConfiguracionServidor
    Inherits Form

    Private panHeader As Panel
    Private lblTituloHeader As Label
    Private lblSubtituloHeader As Label

    Private pnlEstadoConexionActual As Panel
    Private picFarolConexion As PictureBox
    Private lblConexionActual As Label

    Private _srvInicial As String = String.Empty
    Private _bdInicial As String = String.Empty
    Private _usrInicial As String = String.Empty
    Private _pwdInicial As String = String.Empty
    Private _timeoutInicial As Integer = 15

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
        Me.Size = New Size(640, 565)
        Me.MinimumSize = New Size(640, 565)
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

        ' 1b. Banda de estado actual con farol verde/rojo
        pnlEstadoConexionActual = New Panel()
        pnlEstadoConexionActual.Location = New Point(16, 74)
        pnlEstadoConexionActual.Size = New Size(592, 34)
        pnlEstadoConexionActual.BackColor = Color.White
        pnlEstadoConexionActual.BorderStyle = BorderStyle.FixedSingle

        picFarolConexion = New PictureBox()
        picFarolConexion.Location = New Point(12, 8)
        picFarolConexion.Size = New Size(16, 16)
        picFarolConexion.SizeMode = PictureBoxSizeMode.CenterImage
        picFarolConexion.BackColor = Color.Transparent
        picFarolConexion.Image = Utilitarios.ObtenerIconoFarolEstado(True, 14)

        lblConexionActual = New Label()
        lblConexionActual.Location = New Point(34, 6)
        lblConexionActual.Size = New Size(546, 20)
        lblConexionActual.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        lblConexionActual.ForeColor = Utilitarios.ColorDeepNavy
        lblConexionActual.TextAlign = ContentAlignment.MiddleLeft
        lblConexionActual.AutoEllipsis = True
        lblConexionActual.Text = "Conectado a Servidor: SrvMagicInfo - BD: mantencion"

        pnlEstadoConexionActual.Controls.Add(picFarolConexion)
        pnlEstadoConexionActual.Controls.Add(lblConexionActual)

        ' 2. GroupBox Parámetros
        grpParametros = New GroupBox()
        grpParametros.Text = " Parámetros de Conexión SQL Server "
        grpParametros.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point)
        grpParametros.ForeColor = Utilitarios.ColorPrimario
        grpParametros.Location = New Point(16, 114)
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
        lblEstado.Location = New Point(16, 402)
        lblEstado.Size = New Size(592, 48)
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
        btnProbar.Text = "Probar Conexión"
        btnProbar.Image = Global.mantencion.My.Resources.Resources._16__Find_
        btnProbar.Location = New Point(12, 14)
        btnProbar.Size = New Size(138, 36)
        btnProbar.Font = New Font("Segoe UI", 8.75F, FontStyle.Bold)

        btnRestaurar = New Button()
        btnRestaurar.Text = "Original"
        btnRestaurar.Image = Global.mantencion.My.Resources.Resources._16__Clear_
        btnRestaurar.Location = New Point(156, 14)
        btnRestaurar.Size = New Size(94, 36)
        btnRestaurar.Font = New Font("Segoe UI", 8.75F)

        btnVerLogs = New Button()
        btnVerLogs.Text = "Ver Logs"
        btnVerLogs.Image = Global.mantencion.My.Resources.Resources.notas
        btnVerLogs.Location = New Point(256, 14)
        btnVerLogs.Size = New Size(96, 36)
        btnVerLogs.Font = New Font("Segoe UI", 8.75F)

        btnGuardar = New Button()
        btnGuardar.Text = "Guardar y Aplicar"
        btnGuardar.Image = Global.mantencion.My.Resources.Resources.guardar_16x16
        btnGuardar.Location = New Point(360, 14)
        btnGuardar.Size = New Size(150, 36)
        btnGuardar.Font = New Font("Segoe UI", 8.75F, FontStyle.Bold)

        btnCancelar = New Button()
        btnCancelar.Text = "Cancelar"
        btnCancelar.Image = Global.mantencion.My.Resources.Resources._16__Exit_
        btnCancelar.Location = New Point(516, 14)
        btnCancelar.Size = New Size(96, 36)
        btnCancelar.Font = New Font("Segoe UI", 8.75F)

        For Each bBtn As Button In New Button() {btnProbar, btnRestaurar, btnVerLogs, btnGuardar, btnCancelar}
            bBtn.ImageAlign = ContentAlignment.MiddleLeft
            bBtn.TextAlign = ContentAlignment.MiddleCenter
            bBtn.TextImageRelation = TextImageRelation.ImageBeforeText
            Utilitarios.AplicarEstiloBoton(bBtn)
        Next

        panBotones.Controls.AddRange(New Control() {btnProbar, btnRestaurar, btnVerLogs, btnGuardar, btnCancelar})

        Me.Controls.AddRange(New Control() {panHeader, pnlEstadoConexionActual, grpParametros, lblEstado, panBotones})

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
            Try
                Dim defBuilder As New SqlConnectionStringBuilder(Conexion.CadenaPredeterminadaOriginal)
                txtServidor.Text = defBuilder.DataSource
                txtCatalogo.Text = defBuilder.InitialCatalog
                txtUsuario.Text = defBuilder.UserID
                txtPassword.Text = defBuilder.Password
                numTimeout.Value = If(defBuilder.ConnectTimeout >= numTimeout.Minimum AndAlso defBuilder.ConnectTimeout <= numTimeout.Maximum, defBuilder.ConnectTimeout, 15)
            Catch
                txtServidor.Text = String.Empty
                txtCatalogo.Text = String.Empty
                txtUsuario.Text = String.Empty
                txtPassword.Text = String.Empty
                numTimeout.Value = 15
            End Try
        End Try

        _srvInicial = txtServidor.Text.Trim()
        _bdInicial = txtCatalogo.Text.Trim()
        _usrInicial = txtUsuario.Text.Trim()
        _pwdInicial = txtPassword.Text
        _timeoutInicial = CInt(numTimeout.Value)

        ActualizarPreview(Nothing, EventArgs.Empty)
        Dim estCache = Conexion.ObtenerEstadoConexionActual(False)
        ActualizarBandaEstadoConexion(estCache.Servidor, estCache.BaseDatos, estCache.Conectado)

        System.Threading.ThreadPool.QueueUserWorkItem(Sub()
                                                         Try
                                                             Dim est = Conexion.ObtenerEstadoConexionActual(True)
                                                             Me.BeginInvoke(New Action(Sub()
                                                                                           If Me.IsDisposed Then Exit Sub
                                                                                           ActualizarBandaEstadoConexion(est.Servidor, est.BaseDatos, est.Conectado)
                                                                                       End Sub))
                                                         Catch
                                                         End Try
                                                     End Sub)
    End Sub

    Private Sub ActualizarBandaEstadoConexion(ByVal servidor As String, ByVal baseDatos As String, ByVal conectado As Boolean)
        If picFarolConexion Is Nothing OrElse lblConexionActual Is Nothing Then Exit Sub
        picFarolConexion.Image = Utilitarios.ObtenerIconoFarolEstado(conectado, 14)
        lblConexionActual.Text = Conexion.FormatearEstadoConexion(servidor, baseDatos, conectado)
        lblConexionActual.ForeColor = If(conectado, Utilitarios.ColorDeepNavy, Utilitarios.ColorTextoDestacado)
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
        btnProbar.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim cadena As String = ConstruirCadena()
            Dim resultado = Conexion.ProbarConexion(cadena)

            If resultado.Exito Then
                lblEstado.Text = " [OK] " & resultado.Mensaje
                lblEstado.BackColor = Color.FromArgb(220, 252, 231)
                lblEstado.ForeColor = Color.FromArgb(22, 101, 52)
                ActualizarBandaEstadoConexion(txtServidor.Text.Trim(), txtCatalogo.Text.Trim(), True)
            Else
                lblEstado.Text = " [ERROR] " & resultado.Mensaje
                lblEstado.BackColor = Color.FromArgb(254, 226, 226)
                lblEstado.ForeColor = Color.FromArgb(153, 27, 27)
                ActualizarBandaEstadoConexion(txtServidor.Text.Trim(), txtCatalogo.Text.Trim(), False)
            End If
        Catch ex As Exception
            lblEstado.Text = " [ERROR] Parámetros de conexión inválidos: " & ex.Message
            lblEstado.BackColor = Color.FromArgb(254, 226, 226)
            lblEstado.ForeColor = Color.FromArgb(153, 27, 27)
            ActualizarBandaEstadoConexion(txtServidor.Text.Trim(), txtCatalogo.Text.Trim(), False)
        Finally
            btnProbar.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnRestaurar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRestaurar.Click
        Dim resp = MessageBox.Show("¿Desea restablecer los valores de conexión originales de fábrica (SrvMagicInfo)?",
                                   "Restaurar Conexión Original", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = DialogResult.Yes Then
            Dim defBuilder As New SqlConnectionStringBuilder(Conexion.CadenaPredeterminadaOriginal)
            txtServidor.Text = defBuilder.DataSource
            txtCatalogo.Text = defBuilder.InitialCatalog
            txtUsuario.Text = defBuilder.UserID
            txtPassword.Text = defBuilder.Password
            numTimeout.Value = If(defBuilder.ConnectTimeout >= numTimeout.Minimum AndAlso defBuilder.ConnectTimeout <= numTimeout.Maximum, defBuilder.ConnectTimeout, 15)
            ActualizarPreview(Nothing, EventArgs.Empty)
            lblEstado.Text = " Se cargaron los valores de fábrica. Presione 'Guardar y Aplicar' para confirmar."
            lblEstado.BackColor = Color.FromArgb(224, 244, 246)
            lblEstado.ForeColor = Utilitarios.ColorPrimario
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGuardar.Click
        If Usuario.UsuarioAutenticado AndAlso Not Usuario.EsAdministrador Then
            MessageBox.Show(Me, "Solo los usuarios con perfil Administrador pueden modificar la configuración del servidor.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

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

        Dim srvNuevo As String = txtServidor.Text.Trim()
        Dim bdNuevo As String = txtCatalogo.Text.Trim()
        Dim usrNuevo As String = txtUsuario.Text.Trim()
        Dim pwdNuevo As String = txtPassword.Text
        Dim timeoutNuevo As Integer = CInt(numTimeout.Value)

        Dim huboCambios As Boolean =
            Not String.Equals(_srvInicial, srvNuevo, StringComparison.OrdinalIgnoreCase) OrElse
            Not String.Equals(_bdInicial, bdNuevo, StringComparison.OrdinalIgnoreCase) OrElse
            Not String.Equals(_usrInicial, usrNuevo, StringComparison.OrdinalIgnoreCase) OrElse
            Not String.Equals(_pwdInicial, pwdNuevo, StringComparison.Ordinal) OrElse
            (_timeoutInicial <> timeoutNuevo)

        Dim mensajeConfirm As String
        If huboCambios Then
            mensajeConfirm = "Se actualizará la configuración de conexión del sistema." & vbCrLf & vbCrLf &
                             "Se creará una copia de seguridad automática de la configuración original y la aplicación se reiniciará para iniciar con los nuevos datos de conexión." & vbCrLf & vbCrLf &
                             "¿Desea guardar, aplicar y reiniciar ahora?"
        Else
            mensajeConfirm = "No se detectaron cambios en los parámetros actuales." & vbCrLf & vbCrLf &
                             "¿Desea confirmar y cerrar esta ventana?"
        End If

        Dim confirm = MessageBox.Show(mensajeConfirm, "Confirmar Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Exit Sub

        Dim nuevaCadena As String = ConstruirCadena()
        Dim resultado = Conexion.GuardarNuevaConexion(nuevaCadena)

        If resultado.Exito Then
            If huboCambios Then
                MessageBox.Show("La configuración de conexión ha sido actualizada exitosamente." & vbCrLf & vbCrLf &
                                "Servidor: " & srvNuevo & vbCrLf &
                                "Base de Datos: " & bdNuevo & vbCrLf &
                                "Usuario: " & usrNuevo & vbCrLf & vbCrLf &
                                "La aplicación se reiniciará ahora para aplicar los nuevos cambios.",
                                "Configuración Guardada — Reiniciando", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
                Utilitarios.ReiniciarAplicacion()
            Else
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
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
