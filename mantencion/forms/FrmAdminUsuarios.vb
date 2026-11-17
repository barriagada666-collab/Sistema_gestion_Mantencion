Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmAdminUsuarios
    Public filtro As New DataView
    Private _modoEdicion As Boolean = False
    Private _cargando As Boolean = False

    Private ReadOnly Property GrillasPermisos As DataGridView()
        Get
            Return New DataGridView() {grillaPerModulos, grillaModOt, grillaPerMp, grillaPerMantenedores}
        End Get
    End Property

    Private Sub FrmAdminUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        _cargando = True
        Try
            Dim usuario As New Usuario
            usuario.CrgCmbPerfil(cmbPerfil1)
            opcActivoSi.Checked = True
            usuario.CrgPermisosFormUsuario(grillaPerModulos, grillaModOt, grillaPerMp, grillaPerMantenedores)
            RecargarGrillaUsuarios(usuario)
            EstablecerModoNuevo()
            If cmbPerfil1.SelectedIndex >= 0 Then
                AplicarPlantillaPerfilActual()
            End If
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Administración de Usuarios", True, Me)
        Finally
            _cargando = False
            Me.ResumeLayout(True)
        End Try
    End Sub

    Public Sub PrepararNuevoUsuario(ByVal rut As String, ByVal nombreUsuario As String)
        EstablecerModoNuevo()
        txtRutUsuario.Text = If(rut, String.Empty).Trim()
        txtNomUsuario.Text = If(nombreUsuario, String.Empty).Trim()
        txtClave.Text = String.Empty
        opcActivoSi.Checked = True
        If cmbPerfil1.SelectedIndex >= 0 Then
            AplicarPlantillaPerfilActual()
        End If
        txtClave.Focus()
    End Sub

    Private Sub RecargarGrillaUsuarios(Optional ByVal usuarioSvc As Usuario = Nothing)
        Dim svc As Usuario = If(usuarioSvc, New Usuario())
        Dim DS As New DataSet
        svc.CrgUsuarios(DS)
        grillaUsuarios.SuspendLayout()
        Try
            If DS.Tables.Count > 0 Then
                Dim tabla As DataTable = DS.Tables(0)
                filtro = New DataView(tabla)
                AplicarFiltroActualSinExcepcion()
                grillaUsuarios.DataSource = filtro
                ConfigurarEstiloGrillaUsuarios()
            End If
        Finally
            grillaUsuarios.ResumeLayout(False)
        End Try
        Utilitarios.AjustarColumnasGrilla(grillaUsuarios)
    End Sub

    Private Sub EstablecerModoNuevo()
        _modoEdicion = False
        txtRutUsuario.Enabled = True
        btnIngUsuario.Enabled = True
        btnActUsuario.Enabled = False
        btnDelUsuario.Enabled = False
        If lblModoUsuario IsNot Nothing Then
            lblModoUsuario.Text = "Modo: Nuevo usuario (ingrese datos o doble clic en tabla para editar)"
            lblModoUsuario.ForeColor = Utilitarios.ColorDeepNavy
        End If
    End Sub

    Private Sub EstablecerModoEdicion(ByVal rut As String, ByVal nombreUsuario As String)
        _modoEdicion = True
        txtRutUsuario.Enabled = False
        btnIngUsuario.Enabled = False
        btnActUsuario.Enabled = True
        btnDelUsuario.Enabled = True
        If lblModoUsuario IsNot Nothing Then
            lblModoUsuario.Text = String.Format("Modo: Editando usuario '{0}' (RUT {1})", nombreUsuario, rut)
            lblModoUsuario.ForeColor = Utilitarios.ColorPrimario
        End If
    End Sub

    Private Sub ConfirmarEdicionGrillasPermisos()
        For Each grilla In GrillasPermisos
            If grilla IsNot Nothing AndAlso grilla.IsCurrentCellInEditMode Then
                grilla.EndEdit()
            End If
        Next
    End Sub

    Private Function RecolectarPermisosGrillas() As Dictionary(Of Integer, Boolean)
        ConfirmarEdicionGrillasPermisos()
        Dim mapa As New Dictionary(Of Integer, Boolean)()
        For Each grilla In GrillasPermisos
            If grilla Is Nothing Then Continue For
            For i As Integer = 0 To grilla.RowCount - 1
                Dim row = grilla.Rows(i)
                If row.IsNewRow Then Continue For
                Dim idPerm As Integer
                If row.Cells(0).Value IsNot Nothing AndAlso Not IsDBNull(row.Cells(0).Value) AndAlso
                   Integer.TryParse(row.Cells(0).Value.ToString().Trim(), idPerm) Then
                    Dim valObj As Object = row.Cells(2).Value
                    Dim activo As Boolean = (valObj IsNot Nothing AndAlso Not IsDBNull(valObj) AndAlso Convert.ToBoolean(valObj))
                    mapa(idPerm) = activo
                End If
            Next
        Next
        Return mapa
    End Function

    Private Sub AplicarMapaPermisosAGrillas(ByVal mapa As Dictionary(Of Integer, Boolean))
        For Each grilla In GrillasPermisos
            If grilla Is Nothing OrElse grilla.Columns.Count < 3 Then Continue For
            For i As Integer = 0 To grilla.RowCount - 1
                Dim row = grilla.Rows(i)
                If row.IsNewRow Then Continue For
                Dim idPerm As Integer
                If row.Cells(0).Value IsNot Nothing AndAlso Not IsDBNull(row.Cells(0).Value) AndAlso
                   Integer.TryParse(row.Cells(0).Value.ToString().Trim(), idPerm) Then
                    Dim estado As Boolean = False
                    If mapa IsNot Nothing Then mapa.TryGetValue(idPerm, estado)
                    row.Cells(2).Value = estado
                Else
                    row.Cells(2).Value = False
                End If
            Next
            grilla.RefreshEdit()
        Next
    End Sub

    Private Sub MarcarTodosLosPermisos(ByVal estado As Boolean)
        For Each grilla In GrillasPermisos
            If grilla Is Nothing OrElse grilla.Columns.Count < 3 Then Continue For
            For i As Integer = 0 To grilla.RowCount - 1
                Dim row = grilla.Rows(i)
                If Not row.IsNewRow Then
                    row.Cells(2).Value = estado
                End If
            Next
            grilla.RefreshEdit()
        Next
    End Sub

    Private Sub AplicarPlantillaPerfilActual()
        If cmbPerfil1.SelectedValue Is Nothing OrElse TypeOf cmbPerfil1.SelectedValue Is DataRowView Then Exit Sub
        Dim idPerfil As Integer
        If Not Integer.TryParse(cmbPerfil1.SelectedValue.ToString(), idPerfil) Then Exit Sub
        Dim usuario As New Usuario
        Dim plantilla = usuario.ObtenerPlantillaPermisosPerfil(idPerfil, cmbPerfil1.Text)
        AplicarMapaPermisosAGrillas(plantilla)
    End Sub

    Private Sub btnIngUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngUsuario.Click
        Try
            Dim usuario As New Usuario
            Dim cod_resp As Integer = 0
            Dim resp As String = ""

            If Not usuario.ValidarIngUser(resp) Then
                MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim permisos = RecolectarPermisosGrillas()
            Dim idPerfilStr As String = If(cmbPerfil1.SelectedValue IsNot Nothing, cmbPerfil1.SelectedValue.ToString(), String.Empty)

            usuario.GuardarUsuarioCompleto(True, txtRutUsuario.Text.Trim(), idPerfilStr, txtNomUsuario.Text.Trim(), txtClave.Text.Trim(), opcActivoSi.Checked, permisos, principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MessageBox.Show(Me, resp, "Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarFormularioCompleto(usuario)
            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Usuario", True, Me)
        End Try
    End Sub

    Private Sub btnActUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActUsuario.Click
        Try
            If Not _modoEdicion Then
                MessageBox.Show(Me, "Seleccione un usuario con doble clic desde la tabla antes de actualizar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim usuario As New Usuario
            Dim cod_resp As Integer = 0
            Dim resp As String = ""

            If Not usuario.ValidarIngUser(resp) Then
                MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim permisos = RecolectarPermisosGrillas()
            Dim idPerfilStr As String = If(cmbPerfil1.SelectedValue IsNot Nothing, cmbPerfil1.SelectedValue.ToString(), String.Empty)
            Dim rutEditado As String = txtRutUsuario.Text.Trim()
            Dim nomEditado As String = txtNomUsuario.Text.Trim()
            Dim claveEditada As String = txtClave.Text.Trim()

            usuario.GuardarUsuarioCompleto(False, rutEditado, idPerfilStr, nomEditado, claveEditada, opcActivoSi.Checked, permisos, principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                ' Si el usuario modificado corresponde a la sesión activa, refrescar permisos en caliente
                If String.Equals(rutEditado, Usuario.RutUsuarioActual, StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(nomEditado, Usuario.NombreUsuarioActual, StringComparison.OrdinalIgnoreCase) Then
                    usuario.CrgPermisosUsuarioLogin("0", claveEditada, rutEditado)
                    principal.lblUsuario.Text = UCase(nomEditado)
                End If
                MessageBox.Show(Me, resp, "Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarFormularioCompleto(usuario)
            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Usuario", True, Me)
        End Try
    End Sub

    Private Sub btnDelUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelUsuario.Click
        Try
            Dim rutSel As String = txtRutUsuario.Text.Trim()
            Dim nomSel As String = txtNomUsuario.Text.Trim()
            If Not _modoEdicion OrElse String.IsNullOrEmpty(rutSel) Then
                MessageBox.Show(Me, "Seleccione un usuario con doble clic desde la tabla antes de eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If MessageBox.Show(Me, String.Format("¿Está seguro que desea eliminar permanentemente al usuario '{0}' (RUT {1}) del sistema?", UCase(nomSel), rutSel), "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim usuario As New Usuario
                Dim cod_resp As Integer = 0
                Dim resp As String = ""

                usuario.DelUsuario(rutSel, principal.lblUsuario.Text, cod_resp, resp)

                If cod_resp = 1 Then
                    MessageBox.Show(Me, resp, "Administración de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LimpiarFormularioCompleto(usuario)
                ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                    MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Usuario", True, Me)
        End Try
    End Sub

    Private Sub LimpiarFormularioCompleto(Optional ByVal usuarioSvc As Usuario = Nothing)
        Dim usuario As Usuario = If(usuarioSvc, New Usuario())
        _cargando = True
        Try
            txtRutUsuario.Text = String.Empty
            txtNomUsuario.Text = String.Empty
            txtClave.Text = String.Empty
            opcActivoSi.Checked = True
            EstablecerModoNuevo()
            RecargarGrillaUsuarios(usuario)
            usuario.CrgPermisosFormUsuario(grillaPerModulos, grillaModOt, grillaPerMp, grillaPerMantenedores)
            If cmbPerfil1.SelectedIndex >= 0 Then
                AplicarPlantillaPerfilActual()
            End If
        Finally
            _cargando = False
        End Try
    End Sub

    Public Sub ConfigurarEstiloGrillaUsuarios()
        If grillaUsuarios Is Nothing OrElse grillaUsuarios.Columns.Count < 5 Then Exit Sub
        With grillaUsuarios
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .RowTemplate.Height = 24

            If .Columns.Count > 0 Then
                With .Columns(0)
                    .HeaderText = "RUT"
                    .Width = 95
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Tag = "Fijo"
                End With
            End If

            If .Columns.Count > 1 Then
                With .Columns(1)
                    .HeaderText = "Nombre de Usuario"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
            End If

            If .Columns.Count > 2 Then
                With .Columns(2)
                    .HeaderText = "Contraseña"
                    .Width = 110
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Tag = "Fijo"
                End With
            End If

            If .Columns.Count > 3 Then
                With .Columns(3)
                    .HeaderText = "Perfil"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
            End If

            If .Columns.Count > 4 Then
                With .Columns(4)
                    .HeaderText = "Estado"
                    .Width = 70
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Tag = "Fijo"
                End With
            End If
        End With
    End Sub

    Private Sub btnLimpiarUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarUser.Click
        txtBuscarUsuario.Text = String.Empty
        LimpiarFormularioCompleto()
        txtRutUsuario.Focus()
    End Sub

    Private Sub btnSalirUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirUser.Click
        Me.Close()
    End Sub

    Private Sub grillaUsuarios_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaUsuarios.CellDoubleClick, grillaUsuarios.CellContentDoubleClick
        If e.RowIndex < 0 OrElse e.RowIndex >= grillaUsuarios.RowCount Then Exit Sub
        Try
            Dim row As DataGridViewRow = grillaUsuarios.Rows(e.RowIndex)
            If row Is Nothing OrElse row.IsNewRow Then Exit Sub

            Dim rutVal As String = If(row.Cells(0).Value Is Nothing OrElse IsDBNull(row.Cells(0).Value), String.Empty, row.Cells(0).Value.ToString().Trim())
            Dim nomVal As String = If(row.Cells(1).Value Is Nothing OrElse IsDBNull(row.Cells(1).Value), String.Empty, row.Cells(1).Value.ToString().Trim())
            Dim claveVal As String = If(row.Cells(2).Value Is Nothing OrElse IsDBNull(row.Cells(2).Value), String.Empty, row.Cells(2).Value.ToString().Trim())
            Dim perfilVal As String = If(row.Cells(3).Value Is Nothing OrElse IsDBNull(row.Cells(3).Value), String.Empty, row.Cells(3).Value.ToString().Trim())
            Dim estadoVal As String = If(row.Cells(4).Value Is Nothing OrElse IsDBNull(row.Cells(4).Value), String.Empty, row.Cells(4).Value.ToString().Trim())

            _cargando = True
            Try
                txtRutUsuario.Text = rutVal
                txtNomUsuario.Text = nomVal
                txtClave.Text = claveVal
                If Not String.IsNullOrEmpty(perfilVal) Then
                    cmbPerfil1.Text = perfilVal
                End If
                If String.Equals(estadoVal, "A", StringComparison.OrdinalIgnoreCase) Then
                    opcActivoSi.Checked = True
                Else
                    opcActivoNo.Checked = True
                End If
                EstablecerModoEdicion(rutVal, nomVal)

                Dim usuario As New Usuario
                Dim mapaPermisos = usuario.ObtenerMapaPermisosUsuario(rutVal)
                AplicarMapaPermisosAGrillas(mapaPermisos)
            Finally
                _cargando = False
            End Try
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Datos y Permisos de Usuario", True, Me)
        End Try
    End Sub

    Private Sub txtBuscarUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarUsuario.TextChanged
        AplicarFiltroActualSinExcepcion()
        ConfigurarEstiloGrillaUsuarios()
        Utilitarios.AjustarColumnasGrilla(grillaUsuarios)
    End Sub

    Private Sub AplicarFiltroActualSinExcepcion()
        If filtro Is Nothing OrElse filtro.Table Is Nothing Then Exit Sub
        Try
            Dim q As String = Utilitarios.EscaparLike(txtBuscarUsuario.Text.Trim())
            If String.IsNullOrEmpty(q) Then
                filtro.RowFilter = String.Empty
            Else
                filtro.RowFilter = String.Format("RUT LIKE '%{0}%' OR NOMBRE LIKE '%{0}%' OR PERFIL LIKE '%{0}%' OR ESTADO LIKE '%{0}%'", q)
            End If
        Catch
            filtro.RowFilter = String.Empty
        End Try
    End Sub

    Private Sub txtRutUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRutUsuario.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub chkVerClave_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVerClave.CheckedChanged
        txtClave.UseSystemPasswordChar = Not chkVerClave.Checked
    End Sub

    Private Sub cmbPerfil1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPerfil1.SelectedIndexChanged
        If _cargando OrElse _modoEdicion Then Exit Sub
        AplicarPlantillaPerfilActual()
    End Sub

    Private Sub btnAplicarPlantilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicarPlantilla.Click
        AplicarPlantillaPerfilActual()
    End Sub

    Private Sub btnMarcarTodosPerm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarcarTodosPerm.Click
        MarcarTodosLosPermisos(True)
    End Sub

    Private Sub btnDesmarcarTodosPerm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesmarcarTodosPerm.Click
        MarcarTodosLosPermisos(False)
    End Sub

    Private Sub GrillaPermisos_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grillaPerModulos.CurrentCellDirtyStateChanged, grillaModOt.CurrentCellDirtyStateChanged, grillaPerMp.CurrentCellDirtyStateChanged, grillaPerMantenedores.CurrentCellDirtyStateChanged
        Dim dgv = TryCast(sender, DataGridView)
        If dgv IsNot Nothing AndAlso dgv.IsCurrentCellDirty Then
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub grillaUsuarios_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles grillaUsuarios.CellFormatting
        ' Enmascarar visualmente contraseñas en la grilla principal salvo si el usuario activó "Ver"
        If e.ColumnIndex = 2 AndAlso e.Value IsNot Nothing AndAlso Not IsDBNull(e.Value) AndAlso Not chkVerClave.Checked Then
            Dim len As Integer = Math.Max(4, e.Value.ToString().Length)
            e.Value = New String("*"c, Math.Min(len, 10))
            e.FormattingApplied = True
        End If
    End Sub

    Private Sub chkVerClave_RefreshGrid(ByVal sender As Object, ByVal e As EventArgs) Handles chkVerClave.CheckedChanged
        If grillaUsuarios IsNot Nothing Then
            grillaUsuarios.InvalidateColumn(2)
        End If
    End Sub

    Private Sub btnGestionPerfiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGestionPerfiles.Click
        MostrarDialogoGestionPerfiles()
    End Sub

    ''' <summary>
    ''' Cuadro modal corporativo para crear, renombrar o eliminar perfiles de usuario (perfiles_usuario).
    ''' </summary>
    Private Sub MostrarDialogoGestionPerfiles()
        Dim perfilSeleccionadoAnterior As String = cmbPerfil1.Text
        Dim usuarioSvc As New Usuario()

        Using dlg As New Form()
            dlg.Text = "Gestión de Perfiles de Usuario"
            dlg.StartPosition = FormStartPosition.CenterParent
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog
            dlg.MaximizeBox = False
            dlg.MinimizeBox = False
            dlg.ClientSize = New Size(470, 360)
            dlg.BackColor = Utilitarios.ColorFondoPanel

            Dim lblTitulo As New Label() With {
                .Text = "Administrar Perfiles (Crear, Renombrar y Eliminar)",
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .ForeColor = Utilitarios.ColorPrimario,
                .Location = New Point(14, 12),
                .AutoSize = True
            }

            Dim lblNombre As New Label() With {
                .Text = "Nombre del Perfil:",
                .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
                .ForeColor = Utilitarios.ColorTextoPrincipal,
                .Location = New Point(14, 44),
                .AutoSize = True
            }

            Dim txtNombrePerfil As New TextBox() With {
                .Location = New Point(14, 65),
                .Size = New Size(290, 24),
                .MaxLength = 50
            }

            Dim btnCrear As New Button() With {
                .Text = "Agregar",
                .Location = New Point(312, 63),
                .Size = New Size(70, 27)
            }
            Dim btnGuardarNombre As New Button() With {
                .Text = "Renombrar",
                .Location = New Point(386, 63),
                .Size = New Size(72, 27),
                .Enabled = False
            }

            Dim dgvPerfiles As New DataGridView() With {
                .Location = New Point(14, 100),
                .Size = New Size(444, 204),
                .ReadOnly = True,
                .AllowUserToAddRows = False,
                .AllowUserToDeleteRows = False,
                .AllowUserToResizeRows = False,
                .MultiSelect = False,
                .RowHeadersVisible = False,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            }

            Dim btnEliminar As New Button() With {
                .Text = "Eliminar Seleccionado",
                .Location = New Point(14, 316),
                .Size = New Size(165, 30),
                .Enabled = False
            }
            Dim btnLimpiarPerfil As New Button() With {
                .Text = "Limpiar",
                .Location = New Point(187, 316),
                .Size = New Size(85, 30)
            }
            Dim btnCerrar As New Button() With {
                .Text = "Cerrar",
                .Location = New Point(373, 316),
                .Size = New Size(85, 30),
                .DialogResult = DialogResult.OK
            }

            Dim idSeleccionado As Integer = 0

            Dim recargarLista As Action =
                Sub()
                    Dim dt As DataTable = Nothing
                    usuarioSvc.ObtenerPerfiles(dt)
                    dgvPerfiles.DataSource = dt
                    If dgvPerfiles.Columns.Count >= 3 Then
                        dgvPerfiles.Columns(0).HeaderText = "ID"
                        dgvPerfiles.Columns(0).FillWeight = 20
                        dgvPerfiles.Columns(1).HeaderText = "Nombre de Perfil"
                        dgvPerfiles.Columns(1).FillWeight = 55
                        dgvPerfiles.Columns(2).HeaderText = "Usuarios"
                        dgvPerfiles.Columns(2).FillWeight = 25
                    End If
                    idSeleccionado = 0
                    txtNombrePerfil.Text = String.Empty
                    btnGuardarNombre.Enabled = False
                    btnEliminar.Enabled = False
                End Sub

            AddHandler dgvPerfiles.SelectionChanged,
                Sub(s2, e2)
                    If dgvPerfiles.SelectedRows.Count = 0 Then Exit Sub
                    Dim row = dgvPerfiles.SelectedRows(0)
                    If row.Cells(0).Value IsNot Nothing AndAlso Integer.TryParse(row.Cells(0).Value.ToString(), idSeleccionado) Then
                        txtNombrePerfil.Text = If(row.Cells(1).Value, String.Empty).ToString().Trim()
                        Dim esAdmin As Boolean = (idSeleccionado = 100 OrElse Usuario.EsPerfilAdministrador(txtNombrePerfil.Text))
                        btnGuardarNombre.Enabled = Not esAdmin
                        btnEliminar.Enabled = Not esAdmin
                    End If
                End Sub

            AddHandler btnLimpiarPerfil.Click,
                Sub(s2, e2)
                    dgvPerfiles.ClearSelection()
                    idSeleccionado = 0
                    txtNombrePerfil.Text = String.Empty
                    btnGuardarNombre.Enabled = False
                    btnEliminar.Enabled = False
                    txtNombrePerfil.Focus()
                End Sub

            AddHandler btnCrear.Click,
                Sub(s2, e2)
                    Dim cod As Integer = 0
                    Dim msg As String = String.Empty
                    usuarioSvc.IngPerfil(txtNombrePerfil.Text, principal.lblUsuario.Text, cod, msg)
                    If cod = 1 Then
                        MessageBox.Show(dlg, msg, "Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        recargarLista()
                    ElseIf Not String.IsNullOrWhiteSpace(msg) Then
                        MessageBox.Show(dlg, msg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Sub

            AddHandler btnGuardarNombre.Click,
                Sub(s2, e2)
                    Dim cod As Integer = 0
                    Dim msg As String = String.Empty
                    usuarioSvc.UpdPerfil(idSeleccionado, txtNombrePerfil.Text, principal.lblUsuario.Text, cod, msg)
                    If cod = 1 Then
                        MessageBox.Show(dlg, msg, "Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        recargarLista()
                    ElseIf Not String.IsNullOrWhiteSpace(msg) Then
                        MessageBox.Show(dlg, msg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Sub

            AddHandler btnEliminar.Click,
                Sub(s2, e2)
                    If idSeleccionado <= 0 Then Exit Sub
                    If MessageBox.Show(dlg, "¿Desea eliminar el perfil '" & txtNombrePerfil.Text.Trim() & "'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
                        Exit Sub
                    End If
                    Dim cod As Integer = 0
                    Dim msg As String = String.Empty
                    usuarioSvc.DelPerfil(idSeleccionado, principal.lblUsuario.Text, cod, msg)
                    If cod = 1 Then
                        MessageBox.Show(dlg, msg, "Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        recargarLista()
                    ElseIf Not String.IsNullOrWhiteSpace(msg) Then
                        MessageBox.Show(dlg, msg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Sub

            dlg.Controls.AddRange(New Control() {lblTitulo, lblNombre, txtNombrePerfil, btnCrear, btnGuardarNombre, dgvPerfiles, btnEliminar, btnLimpiarPerfil, btnCerrar})
            recargarLista()
            Utilitarios.AplicarTemaModerno(dlg)
            dlg.ShowDialog(Me)
        End Using

        ' Refrescar combo y grilla principal con los perfiles actualizados
        _cargando = True
        Try
            usuarioSvc.CrgCmbPerfil(cmbPerfil1)
            If Not String.IsNullOrWhiteSpace(perfilSeleccionadoAnterior) Then
                cmbPerfil1.Text = perfilSeleccionadoAnterior
            End If
            RecargarGrillaUsuarios(usuarioSvc)
        Finally
            _cargando = False
        End Try
    End Sub
End Class
