Public Class FrmPersonal

    Private Const ColNombreSel As String = "colSelPersonal"

    Private _dtPersonalOriginal As DataTable
    Private _dvPersonal As DataView
    Private _cargandoFiltros As Boolean = False
    Private _sincronizandoCheckTodos As Boolean = False
    Private _modoEdicion As Boolean = False
    Private _fontEstadoBold As Font
    Private ReadOnly _rutsMarcados As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

    Private Function TienePermisoPersonal() As Boolean
        If Not Usuario.UsuarioAutenticado OrElse Usuario.EsAdministrador Then Return True
        Try
            If principal IsNot Nothing AndAlso principal.PersonalToolStripMenuItem IsNot Nothing AndAlso Not principal.PersonalToolStripMenuItem.Enabled Then
                MessageBox.Show(Me, "No posee permisos para modificar registros en el módulo de Personal.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Catch
        End Try
        Return True
    End Function

    Private Sub FrmPersonal_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        If _fontEstadoBold IsNot Nothing Then
            _fontEstadoBold.Dispose()
            _fontEstadoBold = Nothing
        End If
    End Sub

    Private Function ObtenerUsuarioSesion() As String
        Try
            If principal IsNot Nothing AndAlso principal.lblUsuario IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(principal.lblUsuario.Text) Then
                Return principal.lblUsuario.Text.Trim()
            End If
        Catch
        End Try
        Return "SISTEMA"
    End Function

    Private Function ValidarCamposObligatorios(ByRef mensajeError As String) As Boolean
        Dim rutLimpio As String = txtRut.Text.Trim()
        Dim dvLimpio As String = txtDv.Text.Trim().ToUpperInvariant()

        If String.IsNullOrEmpty(rutLimpio) OrElse String.IsNullOrEmpty(dvLimpio) Then
            mensajeError = "Debe ingresar el RUT y dígito verificador."
            txtRut.Focus()
            Return False
        End If

        Dim uSvc As New Usuario()
        If Not uSvc.ValidarRut(rutLimpio, dvLimpio) Then
            mensajeError = "El RUT y dígito verificador ingresados no son válidos."
            txtRut.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtNombres.Text) OrElse String.IsNullOrWhiteSpace(txtApPaterno.Text) OrElse String.IsNullOrWhiteSpace(txtAlias.Text) Then
            mensajeError = "Debe ingresar Nombres, Apellido Paterno y Alias."
            If String.IsNullOrWhiteSpace(txtNombres.Text) Then
                txtNombres.Focus()
            ElseIf String.IsNullOrWhiteSpace(txtApPaterno.Text) Then
                txtApPaterno.Focus()
            Else
                txtAlias.Focus()
            End If
            Return False
        End If

        If cmbPlanta.SelectedValue Is Nothing OrElse TypeOf cmbPlanta.SelectedValue Is DataRowView OrElse
           cmbSeccion.SelectedValue Is Nothing OrElse TypeOf cmbSeccion.SelectedValue Is DataRowView OrElse
           cmbCargo.SelectedValue Is Nothing OrElse TypeOf cmbCargo.SelectedValue Is DataRowView Then
            mensajeError = "Debe seleccionar Planta, Sección y Cargo."
            Return False
        End If

        Return True
    End Function

    Public Sub ActualizarEstadoModoEdicion(ByVal enEdicion As Boolean, ByVal descripcion As String)
        _modoEdicion = enEdicion
        If lblModoEdicion Is Nothing Then Exit Sub
        If enEdicion Then
            lblModoEdicion.Text = "Editando: " & descripcion
            lblModoEdicion.ForeColor = Utilitarios.ColorDeepNavy
        Else
            lblModoEdicion.Text = "Modo: Nuevo trabajador (clic en una fila para editar)"
            lblModoEdicion.ForeColor = Utilitarios.ColorPrimario
        End If
    End Sub

    Public Sub SeleccionarFilaPorRut(ByVal rut As String)
        If dgvPersonal Is Nothing OrElse dgvPersonal.RowCount = 0 OrElse String.IsNullOrWhiteSpace(rut) Then Exit Sub
        If Not dgvPersonal.Columns.Contains("RUT") Then Exit Sub
        Dim rutBusc As String = rut.Trim()
        For Each r As DataGridViewRow In dgvPersonal.Rows
            If r.IsNewRow Then Continue For
            If String.Equals(Convert.ToString(r.Cells("RUT").Value).Trim(), rutBusc, StringComparison.OrdinalIgnoreCase) Then
                dgvPersonal.ClearSelection()
                r.Selected = True
                Try
                    dgvPersonal.CurrentCell = r.Cells("RUT")
                    dgvPersonal.FirstDisplayedScrollingRowIndex = Math.Max(0, r.Index)
                Catch
                End Try
                Exit For
            End If
        Next
    End Sub

    Private Sub IngPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        _cargandoFiltros = True
        Try
            Dim planta As New Planta
            Dim seccion As New Seccion
            Dim cargo As New Cargo

            planta.crgPlanta(cmbPlanta)
            seccion.crgCmbSeccion(cmbSeccion)
            cargo.crgCmbCargo(cmbCargo)

            btnCrearUsuario.Enabled = principal.UsuariosToolStripMenuItem.Enabled

            cmbFiltroEstado.Items.Clear()
            cmbFiltroEstado.Items.AddRange(New Object() {"Todos", "Activos", "Inactivos"})
            cmbFiltroEstado.SelectedIndex = 0

            Utilitarios.AplicarTemaModerno(Me)
            AplicarEstiloPersonalizadoPaneles()

            Dim personalSvc As New Personal()
            personalSvc.limpiarFormPersonal(Me)
            CargarPadronPersonal(False)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Gestión de Personal (Carga)", True, Me)
        Finally
            _cargandoFiltros = False
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub AplicarEstiloPersonalizadoPaneles()
        pnlLotePersonal.BackColor = Color.FromArgb(224, 244, 246)
        chkSelTodosPersonal.BackColor = pnlLotePersonal.BackColor
        lblSeleccionLote.BackColor = pnlLotePersonal.BackColor
        lblSeleccionLote.ForeColor = Utilitarios.ColorPrimario
        lblResumenListado.BackColor = pnlLotePersonal.BackColor
        lblResumenListado.ForeColor = Utilitarios.ColorDeepNavy

        Utilitarios.HabilitarDobleBuffer(dgvPersonal)
        FormatoGrillas.AplicarEstiloModerno(dgvPersonal)
        dgvPersonal.MultiSelect = True
        dgvPersonal.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPersonal.RowTemplate.Height = 26
    End Sub

    Public Sub CargarPadronPersonal(Optional ByVal preservarFiltros As Boolean = True, Optional ByVal rutSeleccionar As String = "")
        Dim textoPrev As String = If(preservarFiltros, txtFiltroPersonal.Text, String.Empty)
        Dim estadoPrev As String = If(preservarFiltros AndAlso cmbFiltroEstado.SelectedItem IsNot Nothing, cmbFiltroEstado.SelectedItem.ToString(), "Todos")
        Dim plantaPrev As String = If(preservarFiltros AndAlso cmbFiltroPlanta.SelectedItem IsNot Nothing, cmbFiltroPlanta.SelectedItem.ToString(), "Todas")
        Dim seccionPrev As String = If(preservarFiltros AndAlso cmbFiltroSeccion.SelectedItem IsNot Nothing, cmbFiltroSeccion.SelectedItem.ToString(), "Todas")
        Dim cargoPrev As String = If(preservarFiltros AndAlso cmbFiltroCargo.SelectedItem IsNot Nothing, cmbFiltroCargo.SelectedItem.ToString(), "Todos")

        Dim personalSvc As New Personal()
        _dtPersonalOriginal = personalSvc.CrgPersonalCompleto()

        ' Limpiar RUTs marcados que ya no existan en el padrón
        If _rutsMarcados.Count > 0 AndAlso _dtPersonalOriginal IsNot Nothing Then
            Dim existentes As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
            For Each dr As DataRow In _dtPersonalOriginal.Rows
                existentes.Add(Convert.ToString(dr("RUT")).Trim())
            Next
            _rutsMarcados.RemoveWhere(Function(r) Not existentes.Contains(r))
        End If

        _cargandoFiltros = True
        Try
            PoblarComboFiltroUnico(cmbFiltroPlanta, "Planta", "Todas", plantaPrev)
            PoblarComboFiltroUnico(cmbFiltroSeccion, "Sección", "Todas", seccionPrev)
            PoblarComboFiltroUnico(cmbFiltroCargo, "Cargo", "Todos", cargoPrev)

            Dim idxEst As Integer = cmbFiltroEstado.Items.IndexOf(estadoPrev)
            cmbFiltroEstado.SelectedIndex = If(idxEst >= 0, idxEst, 0)
            txtFiltroPersonal.Text = textoPrev
        Finally
            _cargandoFiltros = False
        End Try

        AplicarFiltrosListado()
        If Not String.IsNullOrWhiteSpace(rutSeleccionar) Then
            SeleccionarFilaPorRut(rutSeleccionar)
        End If
    End Sub

    Private Sub PoblarComboFiltroUnico(ByVal cmb As ComboBox, ByVal colNombre As String, ByVal etiquetaTodos As String, ByVal valorPrevio As String)
        cmb.Items.Clear()
        cmb.Items.Add(etiquetaTodos)
        If _dtPersonalOriginal IsNot Nothing AndAlso _dtPersonalOriginal.Columns.Contains(colNombre) Then
            Dim unicos As New SortedSet(Of String)(StringComparer.OrdinalIgnoreCase)
            For Each dr As DataRow In _dtPersonalOriginal.Rows
                Dim val As String = Convert.ToString(dr(colNombre)).Trim()
                If Not String.IsNullOrEmpty(val) Then unicos.Add(val)
            Next
            For Each u As String In unicos
                cmb.Items.Add(u)
            Next
        End If
        Dim idx As Integer = cmb.Items.IndexOf(valorPrevio)
        cmb.SelectedIndex = If(idx >= 0, idx, 0)
    End Sub

    Private Sub AplicarFiltrosListado()
        If _dtPersonalOriginal Is Nothing Then Exit Sub

        Dim condiciones As New List(Of String)()

        If cmbFiltroEstado.SelectedIndex = 1 Then
            condiciones.Add("[Estado] = 'Activo'")
        ElseIf cmbFiltroEstado.SelectedIndex = 2 Then
            condiciones.Add("[Estado] = 'Inactivo'")
        End If

        If cmbFiltroPlanta.SelectedIndex > 0 AndAlso cmbFiltroPlanta.SelectedItem IsNot Nothing Then
            condiciones.Add(String.Format("[Planta] = '{0}'", cmbFiltroPlanta.SelectedItem.ToString().Replace("'", "''")))
        End If

        If cmbFiltroSeccion.SelectedIndex > 0 AndAlso cmbFiltroSeccion.SelectedItem IsNot Nothing Then
            condiciones.Add(String.Format("[Sección] = '{0}'", cmbFiltroSeccion.SelectedItem.ToString().Replace("'", "''")))
        End If

        If cmbFiltroCargo.SelectedIndex > 0 AndAlso cmbFiltroCargo.SelectedItem IsNot Nothing Then
            condiciones.Add(String.Format("[Cargo] = '{0}'", cmbFiltroCargo.SelectedItem.ToString().Replace("'", "''")))
        End If

        Dim q As String = txtFiltroPersonal.Text.Trim()
        If Not String.IsNullOrEmpty(q) Then
            Dim esc As String = Utilitarios.EscaparLike(q)
            condiciones.Add(String.Format(
                "([RUT] LIKE '%{0}%' OR [Nombres] LIKE '%{0}%' OR [Ap. Paterno] LIKE '%{0}%' OR [Ap. Materno] LIKE '%{0}%' OR [Alias] LIKE '%{0}%' OR [Correo] LIKE '%{0}%' OR [Planta] LIKE '%{0}%' OR [Sección] LIKE '%{0}%' OR [Cargo] LIKE '%{0}%' OR CONVERT([Código], 'System.String') LIKE '%{0}%')",
                esc))
        End If

        _dvPersonal = New DataView(_dtPersonalOriginal)
        _dvPersonal.RowFilter = String.Join(" AND ", condiciones.ToArray())

        dgvPersonal.SuspendLayout()
        Try
            If dgvPersonal.Columns.Contains(ColNombreSel) Then
                dgvPersonal.Columns.Remove(ColNombreSel)
            End If
            dgvPersonal.DataSource = _dvPersonal
            ConfigurarColumnasGrillaPersonal()
            AsegurarColumnaCheckboxPersonal()
            SincronizarCheckboxesDesdeMemoria()
            ActualizarIndicadoresLoteYResumen()
        Finally
            dgvPersonal.ResumeLayout(True)
        End Try
    End Sub

    Private Sub ConfigurarColumnasGrillaPersonal()
        FormatoGrillas.AplicarEstiloModerno(dgvPersonal)

        Dim ocultar As String() = {"fecha_nacimiento", "direccion", "activo", "idcentro", "idseccion", "idcargo"}
        For Each colName As String In ocultar
            If dgvPersonal.Columns.Contains(colName) Then
                dgvPersonal.Columns(colName).Visible = False
            End If
        Next

        Dim anchos As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase) From {
            {"RUT", 84},
            {"DV", 34},
            {"Código", 62},
            {"Nombres", 125},
            {"Ap. Paterno", 118},
            {"Ap. Materno", 118},
            {"Alias", 104},
            {"Planta", 116},
            {"Sección", 124},
            {"Cargo", 116},
            {"Estado", 74},
            {"Usuario", 62},
            {"Fono", 80},
            {"Celular", 86},
            {"Correo", 160},
            {"Fecha Ingreso", 94}
        }

        For Each col As DataGridViewColumn In dgvPersonal.Columns
            If Not col.Visible Then Continue For
            col.ReadOnly = True
            col.SortMode = DataGridViewColumnSortMode.Automatic
            Dim w As Integer
            If anchos.TryGetValue(col.Name, w) Then
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                col.Width = w
            End If
        Next

        If dgvPersonal.Columns.Contains("DV") Then dgvPersonal.Columns("DV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        If dgvPersonal.Columns.Contains("Código") Then dgvPersonal.Columns("Código").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If dgvPersonal.Columns.Contains("Estado") Then dgvPersonal.Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        If dgvPersonal.Columns.Contains("Usuario") Then dgvPersonal.Columns("Usuario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        If dgvPersonal.Columns.Contains("Fecha Ingreso") Then
            dgvPersonal.Columns("Fecha Ingreso").DefaultCellStyle.Format = "dd-MM-yyyy"
            dgvPersonal.Columns("Fecha Ingreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

    Private Sub AsegurarColumnaCheckboxPersonal()
        If dgvPersonal.Columns.Contains(ColNombreSel) Then
            dgvPersonal.Columns.Remove(ColNombreSel)
        End If
        Dim colSel As New DataGridViewCheckBoxColumn With {
            .Name = ColNombreSel,
            .HeaderText = "Sel.",
            .Width = 42,
            .MinimumWidth = 38,
            .ReadOnly = True,
            .SortMode = DataGridViewColumnSortMode.NotSortable,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            .Resizable = DataGridViewTriState.False,
            .FalseValue = False,
            .TrueValue = True
        }
        colSel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPersonal.Columns.Add(colSel)
        colSel.DisplayIndex = 0
    End Sub

    Private Sub SincronizarCheckboxesDesdeMemoria()
        If Not dgvPersonal.Columns.Contains(ColNombreSel) OrElse Not dgvPersonal.Columns.Contains("RUT") Then Exit Sub
        Dim idxSel As Integer = dgvPersonal.Columns(ColNombreSel).Index
        Dim idxRut As Integer = dgvPersonal.Columns("RUT").Index
        For Each r As DataGridViewRow In dgvPersonal.Rows
            If r.IsNewRow Then Continue For
            Dim rutVal As String = Convert.ToString(r.Cells(idxRut).Value).Trim()
            r.Cells(idxSel).Value = _rutsMarcados.Contains(rutVal)
        Next
    End Sub

    Private Sub ActualizarIndicadoresLoteYResumen()
        Dim totalMarcados As Integer = _rutsMarcados.Count
        lblSeleccionLote.Text = If(totalMarcados = 1, "1 marcado", String.Format("{0} marcados", totalMarcados))

        Dim hayMarcados As Boolean = (totalMarcados > 0)
        btnLoteActivar.Enabled = hayMarcados
        btnLoteDesactivar.Enabled = hayMarcados
        btnLoteReasignar.Enabled = hayMarcados
        btnLoteEliminar.Enabled = hayMarcados
        btnLoteDesmarcar.Enabled = hayMarcados

        ' Sincronizar estado de chkSelTodosPersonal con filas visibles
        Dim visibles As Integer = dgvPersonal.RowCount
        Dim visiblesMarcados As Integer = 0
        If visibles > 0 AndAlso dgvPersonal.Columns.Contains("RUT") Then
            Dim idxRut As Integer = dgvPersonal.Columns("RUT").Index
            For Each r As DataGridViewRow In dgvPersonal.Rows
                If r.IsNewRow Then Continue For
                If _rutsMarcados.Contains(Convert.ToString(r.Cells(idxRut).Value).Trim()) Then
                    visiblesMarcados += 1
                End If
            Next
        End If

        _sincronizandoCheckTodos = True
        Try
            chkSelTodosPersonal.Checked = (visibles > 0 AndAlso visiblesMarcados = visibles)
        Finally
            _sincronizandoCheckTodos = False
        End Try

        Dim totalPadron As Integer = If(_dtPersonalOriginal IsNot Nothing, _dtPersonalOriginal.Rows.Count, 0)
        Dim activosPadron As Integer = 0
        If _dtPersonalOriginal IsNot Nothing Then
            For Each dr As DataRow In _dtPersonalOriginal.Rows
                If Convert.ToString(dr("Estado")).Equals("Activo", StringComparison.OrdinalIgnoreCase) Then
                    activosPadron += 1
                End If
            Next
        End If
        Dim inactivosPadron As Integer = Math.Max(0, totalPadron - activosPadron)
        lblResumenListado.Text = String.Format("{0}/{1} · {2} act. · {3} inact.", visibles, totalPadron, activosPadron, inactivosPadron)
    End Sub

    Private Sub CargarTrabajadorDesdeFila(ByVal row As DataGridViewRow)
        If row Is Nothing OrElse row.IsNewRow OrElse Not dgvPersonal.Columns.Contains("RUT") Then Exit Sub
        Dim rutTxt As String = Convert.ToString(row.Cells("RUT").Value).Trim()
        Dim dvTxt As String = Convert.ToString(row.Cells("DV").Value).Trim().ToUpperInvariant()

        txtRut.Text = rutTxt
        txtDv.Text = dvTxt
        txtRut.ReadOnly = True
        txtDv.ReadOnly = True
        txtCodInt.Text = Convert.ToString(row.Cells("Código").Value).Trim()
        txtNombres.Text = Convert.ToString(row.Cells("Nombres").Value).Trim()
        txtApPaterno.Text = Convert.ToString(row.Cells("Ap. Paterno").Value).Trim()
        txtApMaterno.Text = Convert.ToString(row.Cells("Ap. Materno").Value).Trim()
        txtAlias.Text = Convert.ToString(row.Cells("Alias").Value).Trim()
        txtfono.Text = Convert.ToString(row.Cells("Fono").Value).Trim()
        txtCelular.Text = Convert.ToString(row.Cells("Celular").Value).Trim()
        txtEmail.Text = Convert.ToString(row.Cells("Correo").Value).Trim()
        txtDireccion.Text = If(dgvPersonal.Columns.Contains("direccion"), Convert.ToString(row.Cells("direccion").Value).Trim(), String.Empty)

        If dgvPersonal.Columns.Contains("fecha_nacimiento") Then
            Utilitarios.AsignarFechaSegura(fecha_nac, row.Cells("fecha_nacimiento").Value, DateTime.Today)
        End If
        Utilitarios.AsignarFechaSegura(fecha_ingreso, row.Cells("Fecha Ingreso").Value, DateTime.Today)

        Dim esActivo As Boolean = Convert.ToString(row.Cells("Estado").Value).Equals("Activo", StringComparison.OrdinalIgnoreCase)
        opc_activo_si.Checked = esActivo
        opc_activo_no.Checked = Not esActivo

        SeleccionarComboPorValorOTexto(cmbPlanta,
                                       If(dgvPersonal.Columns.Contains("idcentro"), row.Cells("idcentro").Value, Nothing),
                                       Convert.ToString(row.Cells("Planta").Value).Trim())
        SeleccionarComboPorValorOTexto(cmbSeccion,
                                       If(dgvPersonal.Columns.Contains("idseccion"), row.Cells("idseccion").Value, Nothing),
                                       Convert.ToString(row.Cells("Sección").Value).Trim())
        SeleccionarComboPorValorOTexto(cmbCargo,
                                       If(dgvPersonal.Columns.Contains("idcargo"), row.Cells("idcargo").Value, Nothing),
                                       Convert.ToString(row.Cells("Cargo").Value).Trim())

        btnIngresar.Visible = True
        btnIngresar.Enabled = False
        btnActualizar.Visible = True
        btnActualizar.Enabled = True
        btnEliminar.Enabled = True
        ActualizarEstadoModoEdicion(True, String.Format("{0}-{1} · {2} {3}", rutTxt, dvTxt, txtNombres.Text.Trim(), txtApPaterno.Text.Trim()))
    End Sub

    Private Shared Sub SeleccionarComboPorValorOTexto(ByVal cmb As ComboBox, ByVal idVal As Object, ByVal texto As String)
        If cmb Is Nothing OrElse cmb.Items.Count = 0 Then Exit Sub
        Try
            If idVal IsNot Nothing AndAlso Not IsDBNull(idVal) Then
                cmb.SelectedValue = idVal
                If cmb.SelectedIndex >= 0 Then Exit Sub
            End If
        Catch
        End Try
        If Not String.IsNullOrEmpty(texto) Then
            Dim idx As Integer = cmb.FindStringExact(texto)
            If idx >= 0 Then cmb.SelectedIndex = idx
        End If
    End Sub

    Private Sub dgvPersonal_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvPersonal.CellClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse e.RowIndex >= dgvPersonal.RowCount Then Exit Sub
        Dim row As DataGridViewRow = dgvPersonal.Rows(e.RowIndex)
        If row.IsNewRow Then Exit Sub

        If dgvPersonal.Columns(e.ColumnIndex).Name = ColNombreSel Then
            AlternarMarcaFila(row)
        Else
            CargarTrabajadorDesdeFila(row)
        End If
    End Sub

    Private Sub dgvPersonal_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvPersonal.CellDoubleClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse e.RowIndex >= dgvPersonal.RowCount Then Exit Sub
        If dgvPersonal.Columns(e.ColumnIndex).Name = ColNombreSel Then Exit Sub
        CargarTrabajadorDesdeFila(dgvPersonal.Rows(e.RowIndex))
        txtNombres.Focus()
    End Sub

    Private Sub dgvPersonal_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvPersonal.ColumnHeaderMouseClick
        If e.ColumnIndex < 0 OrElse dgvPersonal.RowCount = 0 Then Exit Sub
        If dgvPersonal.Columns(e.ColumnIndex).Name = ColNombreSel Then
            AlternarSeleccionVisibles(Not chkSelTodosPersonal.Checked)
        End If
    End Sub

    Private Sub dgvPersonal_Sorted(ByVal sender As Object, ByVal e As EventArgs) Handles dgvPersonal.Sorted
        SincronizarCheckboxesDesdeMemoria()
        ActualizarIndicadoresLoteYResumen()
    End Sub

    Private Sub dgvPersonal_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles dgvPersonal.CellFormatting
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub
        Dim colName As String = dgvPersonal.Columns(e.ColumnIndex).Name
        If colName = "Estado" AndAlso e.Value IsNot Nothing Then
            If _fontEstadoBold Is Nothing Then
                _fontEstadoBold = New Font(dgvPersonal.Font, FontStyle.Bold)
            End If
            Dim est As String = e.Value.ToString().Trim()
            e.CellStyle.ForeColor = If(est.Equals("Activo", StringComparison.OrdinalIgnoreCase), Color.FromArgb(21, 128, 61), Color.FromArgb(185, 28, 28))
            e.CellStyle.Font = _fontEstadoBold
        End If
    End Sub

    Private Sub dgvPersonal_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgvPersonal.KeyDown
        If dgvPersonal.RowCount = 0 Then Exit Sub
        If e.KeyCode = Keys.Space Then
            e.Handled = True
            If dgvPersonal.SelectedRows.Count > 0 Then
                For Each r As DataGridViewRow In dgvPersonal.SelectedRows
                    If Not r.IsNewRow Then AlternarMarcaFila(r)
                Next
            ElseIf dgvPersonal.CurrentRow IsNot Nothing AndAlso Not dgvPersonal.CurrentRow.IsNewRow Then
                AlternarMarcaFila(dgvPersonal.CurrentRow)
            End If
        ElseIf e.KeyCode = Keys.Enter AndAlso dgvPersonal.CurrentRow IsNot Nothing Then
            e.Handled = True
            CargarTrabajadorDesdeFila(dgvPersonal.CurrentRow)
            txtNombres.Focus()
        End If
    End Sub

    Private Sub dgvPersonal_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles dgvPersonal.DataError
        e.ThrowException = False
    End Sub

    Private Sub AlternarMarcaFila(ByVal row As DataGridViewRow)
        If row Is Nothing OrElse row.IsNewRow OrElse Not dgvPersonal.Columns.Contains(ColNombreSel) OrElse Not dgvPersonal.Columns.Contains("RUT") Then Exit Sub
        Dim rutVal As String = Convert.ToString(row.Cells("RUT").Value).Trim()
        If String.IsNullOrEmpty(rutVal) Then Exit Sub

        If _rutsMarcados.Contains(rutVal) Then
            _rutsMarcados.Remove(rutVal)
            row.Cells(ColNombreSel).Value = False
        Else
            _rutsMarcados.Add(rutVal)
            row.Cells(ColNombreSel).Value = True
        End If
        dgvPersonal.InvalidateCell(dgvPersonal.Columns(ColNombreSel).Index, row.Index)
        ActualizarIndicadoresLoteYResumen()
    End Sub

    Private Sub AlternarSeleccionVisibles(ByVal marcar As Boolean)
        If Not dgvPersonal.Columns.Contains(ColNombreSel) OrElse Not dgvPersonal.Columns.Contains("RUT") Then Exit Sub
        Dim idxSel As Integer = dgvPersonal.Columns(ColNombreSel).Index
        Dim idxRut As Integer = dgvPersonal.Columns("RUT").Index
        For Each r As DataGridViewRow In dgvPersonal.Rows
            If r.IsNewRow Then Continue For
            Dim rutVal As String = Convert.ToString(r.Cells(idxRut).Value).Trim()
            If String.IsNullOrEmpty(rutVal) Then Continue For
            If marcar Then
                _rutsMarcados.Add(rutVal)
                r.Cells(idxSel).Value = True
            Else
                _rutsMarcados.Remove(rutVal)
                r.Cells(idxSel).Value = False
            End If
        Next
        dgvPersonal.Refresh()
        ActualizarIndicadoresLoteYResumen()
    End Sub

    Private Sub chkSelTodosPersonal_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkSelTodosPersonal.CheckedChanged
        If _sincronizandoCheckTodos Then Exit Sub
        AlternarSeleccionVisibles(chkSelTodosPersonal.Checked)
    End Sub

    Private Sub FiltrosListado_Changed(ByVal sender As Object, ByVal e As EventArgs) Handles txtFiltroPersonal.TextChanged, cmbFiltroEstado.SelectedIndexChanged, cmbFiltroPlanta.SelectedIndexChanged, cmbFiltroSeccion.SelectedIndexChanged, cmbFiltroCargo.SelectedIndexChanged
        If _cargandoFiltros Then Exit Sub
        AplicarFiltrosListado()
    End Sub

    Private Sub btnRefrescarLista_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRefrescarLista.Click
        CargarPadronPersonal(False)
    End Sub

    ' ==============================================================================
    ' OPERACIONES CRUD INDIVIDUALES
    ' ==============================================================================
    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        If Not TienePermisoPersonal() Then Exit Sub
        Dim err As String = String.Empty
        If Not ValidarCamposObligatorios(err) Then
            MessageBox.Show(Me, err, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim personal As New Personal
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim rutNuevo As String = txtRut.Text.Trim()
        Dim dv As String = txtDv.Text.Trim().ToUpperInvariant()

        personal.IngPersonal(rutNuevo, dv, txtCodInt.Text.Trim(), txtNombres.Text.Trim(), txtApPaterno.Text.Trim(), txtApMaterno.Text.Trim(), txtAlias.Text.Trim(), fecha_nac.Value, txtfono.Text.Trim(), txtEmail.Text.Trim(), cmbPlanta.SelectedValue.ToString(), cmbSeccion.SelectedValue.ToString(), cmbCargo.SelectedValue.ToString(), ObtenerUsuarioSesion(), opc_activo_si.Checked, txtDireccion.Text.Trim(), fecha_ingreso.Value, txtCelular.Text.Trim(), cod_resp, resp)

        If cod_resp = 1 Then
            MessageBox.Show(Me, resp, "Personal", MessageBoxButtons.OK, MessageBoxIcon.Information)
            personal.limpiarFormPersonal(Me)
            CargarPadronPersonal(True, rutNuevo)
        ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
            MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        If Not TienePermisoPersonal() Then Exit Sub
        Dim err As String = String.Empty
        If Not ValidarCamposObligatorios(err) Then
            MessageBox.Show(Me, err, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If MessageBox.Show(Me, "¿Está seguro que desea actualizar los datos del trabajador?", "Confirmar Actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim personal As New Personal
            Dim cod_resp As Integer = 0
            Dim resp As String = ""
            Dim rutEdit As String = txtRut.Text.Trim()
            Dim dv As String = txtDv.Text.Trim().ToUpperInvariant()

            personal.UpdPersonal(rutEdit, dv, txtCodInt.Text.Trim(), txtNombres.Text.Trim(), txtApPaterno.Text.Trim(), txtApMaterno.Text.Trim(), txtAlias.Text.Trim(), fecha_nac.Value, txtfono.Text.Trim(), txtEmail.Text.Trim(), cmbPlanta.SelectedValue.ToString(), cmbSeccion.SelectedValue.ToString(), cmbCargo.SelectedValue.ToString(), ObtenerUsuarioSesion(), opc_activo_si.Checked, txtDireccion.Text.Trim(), fecha_ingreso.Value, txtCelular.Text.Trim(), cod_resp, resp)

            If cod_resp = 1 Then
                MessageBox.Show(Me, resp, "Personal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                personal.limpiarFormPersonal(Me)
                CargarPadronPersonal(True, rutEdit)
            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Not TienePermisoPersonal() Then Exit Sub
        Dim rutLimpio As String = txtRut.Text.Trim()
        If String.IsNullOrEmpty(rutLimpio) Then
            MessageBox.Show(Me, "Debe buscar y seleccionar un trabajador antes de eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If MessageBox.Show(Me, "¿Está seguro que desea eliminar permanentemente al trabajador RUT " & rutLimpio & "?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Dim personal As New Personal
            Dim cod_resp As Integer = 0
            Dim resp As String = ""
            personal.DelPersonal(rutLimpio, ObtenerUsuarioSesion(), cod_resp, resp)

            If cod_resp = 1 Then
                _rutsMarcados.Remove(rutLimpio)
                MessageBox.Show(Me, resp, "Personal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                personal.limpiarFormPersonal(Me)
                CargarPadronPersonal(True)
            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                MessageBox.Show(Me, resp, "Personal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Dim personal As New Personal
        personal.limpiarFormPersonal(Me)
        dgvPersonal.ClearSelection()
        txtRut.Focus()
    End Sub

    Private Sub btnBuscarPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersonal.Click
        FrmBuscarPersonal.nombre_form = "personal"
        FrmBuscarPersonal.Show()
    End Sub

    Private Sub btnCrearUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearUsuario.Click
        If Not principal.UsuariosToolStripMenuItem.Enabled Then
            MessageBox.Show(Me, "No posee permisos para acceder al módulo de gestión de usuarios.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txtRut.Text.Trim() <> "" AndAlso txtAlias.Text.Trim() <> "" Then
            principal.AbrirAmbienteMdi(FrmAdminUsuarios)
            FrmAdminUsuarios.PrepararNuevoUsuario(txtRut.Text.Trim(), txtAlias.Text.Trim())
        Else
            MessageBox.Show(Me, "Para crear el usuario debe ingresar o seleccionar un trabajador con RUT y Alias.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRut.Focus()
        End If
    End Sub

    Private Sub btnExportarExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExportarExcel.Click
        If dgvPersonal.RowCount = 0 AndAlso _rutsMarcados.Count = 0 Then
            MessageBox.Show(Me, "No hay trabajadores visibles o marcados para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim dtExp As DataTable = ConstruirTablaExportacionPersonal()
        If dtExp.Rows.Count = 0 Then
            MessageBox.Show(Me, "No hay registros disponibles para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Using dgvTmp As DataGridView = ConstruirGrillaDesdeTabla(dtExp)
            Dim hojas As New List(Of KeyValuePair(Of String, DataGridView)) From {
                New KeyValuePair(Of String, DataGridView)("Padrón Personal", dgvTmp)
            }
            Utilitarios.ExportarGrillasAExcelNativo(hojas, "Padron_Personal", "PADRÓN DE PERSONAL — MANTENCIÓN", ConstruirSubtituloExportacion())
        End Using
    End Sub

    Private Sub btnExportarPdf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExportarPdf.Click
        If dgvPersonal.RowCount = 0 AndAlso _rutsMarcados.Count = 0 Then
            MessageBox.Show(Me, "No hay trabajadores visibles o marcados para exportar.", "Exportar PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim dtExp As DataTable = ConstruirTablaExportacionPersonal()
        If dtExp.Rows.Count = 0 Then
            MessageBox.Show(Me, "No hay registros disponibles para exportar.", "Exportar PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim rutaPdf As String = Utilitarios.SolicitarRutaGuardadoPdf("Padron_Personal")
        If String.IsNullOrEmpty(rutaPdf) Then Exit Sub

        Using dgvTmp As DataGridView = ConstruirGrillaDesdeTabla(dtExp)
            If Utilitarios.ExportarGrillaAPdf(dgvTmp, rutaPdf, "PADRÓN DE PERSONAL — MANTENCIÓN", ConstruirSubtituloExportacion()) Then
                If MessageBox.Show(Me, "Archivo PDF generado exitosamente en:" & Environment.NewLine & rutaPdf & Environment.NewLine & Environment.NewLine & "¿Desea abrir el documento PDF ahora?", "Exportación PDF Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    Utilitarios.AbrirDocumento(rutaPdf)
                End If
            Else
                MessageBox.Show(Me, "No fue posible generar el archivo PDF.", "Exportar PDF", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Public Shared Function ConstruirGrillaDesdeTabla(ByVal dt As DataTable) As DataGridView
        Dim dgvTmp As New DataGridView With {
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False
        }
        If dt Is Nothing Then Return dgvTmp
        For Each col As DataColumn In dt.Columns
            dgvTmp.Columns.Add(col.ColumnName, col.ColumnName)
        Next
        For Each row As DataRow In dt.Rows
            dgvTmp.Rows.Add(row.ItemArray)
        Next
        Return dgvTmp
    End Function

    Public Function ConstruirSubtituloExportacion() As String
        Dim alcance As String = If(_rutsMarcados.Count > 0, String.Format("Lote seleccionado ({0} trabajador(es))", _rutsMarcados.Count), String.Format("Listado filtrado ({0} trabajador(es))", dgvPersonal.RowCount))
        Return String.Format("{0}   |   Estado: {1}   |   Planta: {2}   |   Sección: {3}   |   Cargo: {4}",
                             alcance,
                             If(cmbFiltroEstado.SelectedItem, "Todos"),
                             If(cmbFiltroPlanta.SelectedItem, "Todas"),
                             If(cmbFiltroSeccion.SelectedItem, "Todas"),
                             If(cmbFiltroCargo.SelectedItem, "Todos"))
    End Function

    Public Function ConstruirTablaExportacionPersonal() As DataTable
        Dim dt As New DataTable("PersonalExport")
        Dim colsExport As String() = {"RUT", "DV", "Código", "Nombres", "Ap. Paterno", "Ap. Materno", "Alias", "Planta", "Sección", "Cargo", "Estado", "Usuario", "Fono", "Celular", "Correo", "Fecha Ingreso"}

        Dim soloMarcados As Boolean = (_rutsMarcados.Count > 0 AndAlso _dtPersonalOriginal IsNot Nothing)
        If soloMarcados Then
            For Each cn As String In colsExport
                If _dtPersonalOriginal.Columns.Contains(cn) Then dt.Columns.Add(cn)
            Next
            For Each srcRow As DataRow In _dtPersonalOriginal.Rows
                Dim rutVal As String = Convert.ToString(srcRow("RUT")).Trim()
                If Not _rutsMarcados.Contains(rutVal) Then Continue For
                Dim dr As DataRow = dt.NewRow()
                For Each dc As DataColumn In dt.Columns
                    Dim rawVal As Object = srcRow(dc.ColumnName)
                    If dc.ColumnName = "Fecha Ingreso" AndAlso rawVal IsNot Nothing AndAlso Not IsDBNull(rawVal) Then
                        Dim fParsed As DateTime
                        dr(dc.ColumnName) = If(DateTime.TryParse(rawVal.ToString(), fParsed), fParsed.ToString("dd-MM-yyyy"), rawVal.ToString())
                    Else
                        dr(dc.ColumnName) = If(rawVal Is Nothing OrElse IsDBNull(rawVal), String.Empty, rawVal.ToString().Trim())
                    End If
                Next
                dt.Rows.Add(dr)
            Next
            Return dt
        End If

        For Each cn As String In colsExport
            If dgvPersonal.Columns.Contains(cn) Then dt.Columns.Add(cn)
        Next
        For Each r As DataGridViewRow In dgvPersonal.Rows
            If r.IsNewRow Then Continue For
            Dim dr As DataRow = dt.NewRow()
            For Each dc As DataColumn In dt.Columns
                Dim rawVal As Object = r.Cells(dc.ColumnName).Value
                If dc.ColumnName = "Fecha Ingreso" AndAlso rawVal IsNot Nothing AndAlso Not IsDBNull(rawVal) Then
                    Dim fParsed As DateTime
                    dr(dc.ColumnName) = If(DateTime.TryParse(rawVal.ToString(), fParsed), fParsed.ToString("dd-MM-yyyy"), rawVal.ToString())
                Else
                    dr(dc.ColumnName) = If(rawVal Is Nothing OrElse IsDBNull(rawVal), String.Empty, rawVal.ToString().Trim())
                End If
            Next
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    ' ==============================================================================
    ' OPERACIONES POR LOTES (CHECKBOXES)
    ' ==============================================================================
    Public Function ObtenerRutsMarcados() As List(Of String)
        Return _rutsMarcados.ToList()
    End Function

    Private Sub btnLoteDesmarcar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoteDesmarcar.Click
        _rutsMarcados.Clear()
        SincronizarCheckboxesDesdeMemoria()
        dgvPersonal.Refresh()
        ActualizarIndicadoresLoteYResumen()
    End Sub

    Private Sub btnLoteActivar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoteActivar.Click
        EjecutarCambioEstadoLote(True)
    End Sub

    Private Sub btnLoteDesactivar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoteDesactivar.Click
        EjecutarCambioEstadoLote(False)
    End Sub

    Private Sub EjecutarCambioEstadoLote(ByVal nuevoEstado As Boolean)
        If Not TienePermisoPersonal() Then Exit Sub
        Dim ruts As List(Of String) = ObtenerRutsMarcados()
        If ruts.Count = 0 Then
            MessageBox.Show(Me, "Marque al menos un trabajador en la columna 'Sel.' para aplicar la acción por lotes.", "Gestión por Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim verbo As String = If(nuevoEstado, "ACTIVAR", "DESACTIVAR")
        If MessageBox.Show(Me, String.Format("¿Confirma {0} a los {1} trabajador(es) marcados?", verbo, ruts.Count), "Confirmar Gestión por Lotes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If

        Dim svc As New Personal()
        Dim afectados As Integer = 0
        Dim msg As String = String.Empty
        Dim ok As Boolean = svc.ActualizarEstadoLote(ruts, nuevoEstado, ObtenerUsuarioSesion(), afectados, msg)
        MessageBox.Show(Me, msg, "Gestión por Lotes", MessageBoxButtons.OK, If(ok, MessageBoxIcon.Information, MessageBoxIcon.Warning))

        If ok Then
            _rutsMarcados.Clear()
            svc.limpiarFormPersonal(Me)
            CargarPadronPersonal(True)
        End If
    End Sub

    Private Sub btnLoteReasignar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoteReasignar.Click
        If Not TienePermisoPersonal() Then Exit Sub
        Dim ruts As List(Of String) = ObtenerRutsMarcados()
        If ruts.Count = 0 Then
            MessageBox.Show(Me, "Marque al menos un trabajador en la columna 'Sel.' para reasignar Planta, Sección o Cargo.", "Gestión por Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim idPlanta As Integer? = Nothing
        Dim idSeccion As Integer? = Nothing
        Dim idCargo As Integer? = Nothing
        If Not MostrarDialogoReasignarLote(ruts.Count, idPlanta, idSeccion, idCargo) Then Exit Sub

        Dim svc As New Personal()
        Dim afectados As Integer = 0
        Dim msg As String = String.Empty
        Dim ok As Boolean = svc.ReasignarLaboralLote(ruts, idPlanta, idSeccion, idCargo, ObtenerUsuarioSesion(), afectados, msg)
        MessageBox.Show(Me, msg, "Reasignación por Lotes", MessageBoxButtons.OK, If(ok, MessageBoxIcon.Information, MessageBoxIcon.Warning))

        If ok Then
            _rutsMarcados.Clear()
            svc.limpiarFormPersonal(Me)
            CargarPadronPersonal(True)
        End If
    End Sub

    Private Function MostrarDialogoReasignarLote(ByVal cantidad As Integer, ByRef idPlanta As Integer?, ByRef idSeccion As Integer?, ByRef idCargo As Integer?) As Boolean
        idPlanta = Nothing
        idSeccion = Nothing
        idCargo = Nothing

        Using dlg As New Form()
            dlg.Text = "Reasignar Datos Laborales por Lote"
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog
            dlg.StartPosition = FormStartPosition.CenterParent
            dlg.MaximizeBox = False
            dlg.MinimizeBox = False
            dlg.ShowInTaskbar = False
            dlg.ClientSize = New Size(440, 268)

            Dim lblInfo As New Label With {
                .Text = String.Format("Aplicar cambios a {0} trabajador(es) marcados. Deje '— Sin cambios —' en los campos que no desea modificar:", cantidad),
                .Location = New Point(16, 14),
                .Size = New Size(408, 36)
            }

            Dim lblP As New Label With {.Text = "Nueva Planta:", .Location = New Point(16, 62), .AutoSize = True}
            Dim cmbP As New ComboBox With {.DropDownStyle = ComboBoxStyle.DropDownList, .Location = New Point(136, 58), .Size = New Size(288, 24)}

            Dim lblS As New Label With {.Text = "Nueva Sección:", .Location = New Point(16, 102), .AutoSize = True}
            Dim cmbS As New ComboBox With {.DropDownStyle = ComboBoxStyle.DropDownList, .Location = New Point(136, 98), .Size = New Size(288, 24)}

            Dim lblC As New Label With {.Text = "Nuevo Cargo:", .Location = New Point(16, 142), .AutoSize = True}
            Dim cmbC As New ComboBox With {.DropDownStyle = ComboBoxStyle.DropDownList, .Location = New Point(136, 138), .Size = New Size(288, 24)}

            PoblarComboConSinCambios(cmbP, cmbPlanta)
            PoblarComboConSinCambios(cmbS, cmbSeccion)
            PoblarComboConSinCambios(cmbC, cmbCargo)

            Dim btnAplicar As New Button With {
                .Text = "Aplicar Lote",
                .Image = My.Resources.Resources.guardar,
                .ImageAlign = ContentAlignment.MiddleLeft,
                .TextImageRelation = TextImageRelation.ImageBeforeText,
                .Location = New Point(182, 212),
                .Size = New Size(124, 34),
                .Cursor = Cursors.Hand
            }
            Dim btnCancelar As New Button With {
                .Text = "Cancelar",
                .Image = My.Resources.Resources.salir,
                .ImageAlign = ContentAlignment.MiddleLeft,
                .TextImageRelation = TextImageRelation.ImageBeforeText,
                .Location = New Point(314, 212),
                .Size = New Size(110, 34),
                .DialogResult = DialogResult.Cancel,
                .Cursor = Cursors.Hand
            }

            Dim resP As Integer? = Nothing
            Dim resS As Integer? = Nothing
            Dim resC As Integer? = Nothing

            AddHandler btnAplicar.Click, Sub()
                                             resP = ObtenerIdComboOpcional(cmbP)
                                             resS = ObtenerIdComboOpcional(cmbS)
                                             resC = ObtenerIdComboOpcional(cmbC)
                                             If Not resP.HasValue AndAlso Not resS.HasValue AndAlso Not resC.HasValue Then
                                                 MessageBox.Show(dlg, "Seleccione al menos una Planta, Sección o Cargo para aplicar al lote.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                                 Exit Sub
                                             End If
                                             dlg.DialogResult = DialogResult.OK
                                             dlg.Close()
                                         End Sub

            dlg.Controls.AddRange(New Control() {lblInfo, lblP, cmbP, lblS, cmbS, lblC, cmbC, btnAplicar, btnCancelar})
            dlg.AcceptButton = btnAplicar
            dlg.CancelButton = btnCancelar
            Utilitarios.AplicarTemaModerno(dlg)

            If dlg.ShowDialog(Me) = DialogResult.OK Then
                idPlanta = resP
                idSeccion = resS
                idCargo = resC
                Return True
            End If
        End Using
        Return False
    End Function

    Private Shared Sub PoblarComboConSinCambios(ByVal destino As ComboBox, ByVal origen As ComboBox)
        Dim dt As New DataTable()
        dt.Columns.Add("Id", GetType(Integer))
        dt.Columns.Add("Nombre", GetType(String))
        dt.Rows.Add(0, "— Sin cambios —")

        Dim dtSrc As DataTable = TryCast(origen.DataSource, DataTable)
        If dtSrc IsNot Nothing AndAlso Not String.IsNullOrEmpty(origen.ValueMember) AndAlso Not String.IsNullOrEmpty(origen.DisplayMember) Then
            For Each r As DataRow In dtSrc.Rows
                Dim idNum As Integer = Utilitarios.SafeInt(r(origen.ValueMember), 0)
                Dim nom As String = Convert.ToString(r(origen.DisplayMember)).Trim()
                If idNum > 0 Then dt.Rows.Add(idNum, nom)
            Next
        End If
        destino.DisplayMember = "Nombre"
        destino.ValueMember = "Id"
        destino.DataSource = dt
        destino.SelectedIndex = 0
    End Sub

    Private Shared Function ObtenerIdComboOpcional(ByVal cmb As ComboBox) As Integer?
        If cmb Is Nothing OrElse cmb.SelectedValue Is Nothing OrElse TypeOf cmb.SelectedValue Is DataRowView Then Return Nothing
        Dim v As Integer = Utilitarios.SafeInt(cmb.SelectedValue, 0)
        Return If(v > 0, CType(v, Integer?), Nothing)
    End Function

    Private Sub btnLoteEliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoteEliminar.Click
        If Not TienePermisoPersonal() Then Exit Sub
        Dim ruts As List(Of String) = ObtenerRutsMarcados()
        If ruts.Count = 0 Then
            MessageBox.Show(Me, "Marque al menos un trabajador en la columna 'Sel.' para eliminar por lotes.", "Gestión por Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show(Me, String.Format("¿Está seguro que desea eliminar por lotes a {0} trabajador(es) marcados?" & Environment.NewLine & "(Los trabajadores con historial en OT, Mantenciones Preventivas o Usuario se omitirán automáticamente para preservar la integridad).", ruts.Count), "Confirmar Eliminación por Lotes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
            Exit Sub
        End If

        Dim svc As New Personal()
        Dim eliminados As Integer = 0
        Dim omitidos As List(Of String) = Nothing
        Dim msg As String = String.Empty
        Dim ok As Boolean = svc.EliminarPersonalLote(ruts, ObtenerUsuarioSesion(), eliminados, omitidos, msg)

        If ok AndAlso omitidos IsNot Nothing AndAlso omitidos.Count > 0 Then
            Dim respDesact As DialogResult = MessageBox.Show(Me, msg & Environment.NewLine & Environment.NewLine & String.Format("¿Desea marcar como INACTIVOS a los {0} trabajador(es) que no pudieron eliminarse por tener historial?", omitidos.Count), "Omitidos por Historial", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respDesact = DialogResult.Yes Then
                Dim afDes As Integer = 0
                Dim msgDes As String = String.Empty
                svc.ActualizarEstadoLote(omitidos, False, ObtenerUsuarioSesion(), afDes, msgDes)
                MessageBox.Show(Me, msgDes, "Desactivación por Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show(Me, msg, "Eliminación por Lotes", MessageBoxButtons.OK, If(ok, MessageBoxIcon.Information, MessageBoxIcon.Warning))
        End If

        _rutsMarcados.Clear()
        svc.limpiarFormPersonal(Me)
        CargarPadronPersonal(True)
    End Sub

    Private Sub txtRut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRut.KeyPress, txtfono.KeyPress, txtCelular.KeyPress, txtCodInt.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnSalirPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirPersonal.Click
        Me.Close()
    End Sub
End Class
