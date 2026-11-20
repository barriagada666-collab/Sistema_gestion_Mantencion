Imports System.Data.SqlClient
Public Class FrmInfMantPrev
    Public id_nodo_select As String = ""
    Public nombre_nodo_select As String = ""
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Private _cargandoFiltros As Boolean = False
    Private _buscando As Boolean = False
    Private _ultimoIdMpCargado As String = ""
    Friend WithEvents chkSoloCicloGantt As CheckBox

    Private Sub FrmInfMantPrev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        _cargandoFiltros = True
        Dim mantPrev As New MantPreventiva
        Dim nd As New Nodo
        Dim nodoRaiz As New TreeNode

        Try
            If chkSoloCicloGantt Is Nothing Then
                chkSoloCicloGantt = New CheckBox() With {
                    .Name = "chkSoloCicloGantt",
                    .Text = "Solo ciclo selecc.",
                    .AutoSize = True,
                    .Font = New Font("Calibri", 9.25!, FontStyle.Bold),
                    .Location = New Point(Math.Max(480, GrpFiltroInf.ClientSize.Width - 265), 84),
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                    .Cursor = Cursors.Hand
                }
                GrpFiltroInf.Controls.Add(chkSoloCicloGantt)
                ToolTip2.SetToolTip(chkSoloCicloGantt, "Si está marcado, la Carta Gantt se genera únicamente para el ciclo seleccionado")
            End If

            Arbol2.BeginUpdate()
            nodoRaiz.Name = "1"
            nodoRaiz.Text = "Cambiaso Hnos S.A."
            nd.CRG_NODO_HIJO(nodoRaiz)
            Arbol2.Nodes.Add(nodoRaiz)
            CmbTipoMp.DropDownStyle = ComboBoxStyle.DropDownList
            mantPrev.CrgCmbTipoMp(CmbTipoMp)
            If CmbTipoMp.Items.Count > 0 Then
                CmbTipoMp.SelectedIndex = 0
            End If
            Utilitarios.InicializarRangoMesActual(f_ini_inf_mp, f_fin_inf_mp)
            opcFechas.Checked = True
            ActualizarVisibilidadFiltros()
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Mantención Preventiva (Carga)", True, Me)
        Finally
            _cargandoFiltros = False
            Arbol2.EndUpdate()
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub ActualizarVisibilidadFiltros()
        Dim mostrarFechas As Boolean = opcFechas.Checked
        lblFechaIniInfMp.Visible = mostrarFechas
        f_ini_inf_mp.Visible = mostrarFechas
        f_ini_inf_mp.Enabled = mostrarFechas
        lblFechaFinInfMp.Visible = mostrarFechas
        f_fin_inf_mp.Visible = mostrarFechas
        f_fin_inf_mp.Enabled = mostrarFechas

        Dim mostrarTipo As Boolean = opcTipoMp.Checked
        lbltipoMpInf.Visible = mostrarTipo
        CmbTipoMp.Visible = mostrarTipo
        CmbTipoMp.Enabled = mostrarTipo

        Dim mostrarTareas As Boolean = opcfiltroTareas.Checked
        GrpFiltroTareas.Visible = mostrarTareas
        If chkSoloCicloGantt IsNot Nothing Then
            chkSoloCicloGantt.Visible = Not mostrarTareas
        End If
        If mostrarTareas AndAlso Not OpcTareasOk.Checked AndAlso Not OpcTareasPend.Checked Then
            OpcTareasOk.Checked = True
        End If
    End Sub

    Private Sub Arbol2_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Arbol2.AfterSelect
        If Arbol2.SelectedNode Is Nothing Then Exit Sub
        id_nodo_select = Arbol2.SelectedNode.Name
        nodo_anterior2 = id_nodo_select
        Arbol2.SelectedNode.BackColor = Utilitarios.ColorSeleccion
        nombre_nodo_select = Arbol2.SelectedNode.Text

        If Not _cargandoFiltros AndAlso Not String.IsNullOrEmpty(id_nodo_select) Then
            EjecutarBusqueda(False)
        End If
    End Sub

    Private Sub opcFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcFechas.CheckedChanged
        If opcFechas.Checked Then
            ActualizarVisibilidadFiltros()
            If Not _cargandoFiltros AndAlso Not String.IsNullOrEmpty(id_nodo_select) Then
                EjecutarBusqueda(False)
            End If
        End If
    End Sub

    Private Sub FechasFiltro_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f_ini_inf_mp.ValueChanged, f_fin_inf_mp.ValueChanged
        If Not _cargandoFiltros AndAlso opcFechas.Checked AndAlso Not String.IsNullOrEmpty(id_nodo_select) Then
            If f_ini_inf_mp.Value.Date <= f_fin_inf_mp.Value.Date Then
                EjecutarBusqueda(False)
            End If
        End If
    End Sub

    Private Sub opcTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcTodos.CheckedChanged
        If opcTodos.Checked Then
            ActualizarVisibilidadFiltros()
            If Not _cargandoFiltros AndAlso Not String.IsNullOrEmpty(id_nodo_select) Then
                EjecutarBusqueda(False)
            End If
        End If
    End Sub

    Private Sub opcTipoMp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcTipoMp.CheckedChanged
        If opcTipoMp.Checked Then
            ActualizarVisibilidadFiltros()
            If Not _cargandoFiltros AndAlso Not String.IsNullOrEmpty(id_nodo_select) Then
                EjecutarBusqueda(False)
            End If
        End If
    End Sub

    Private Sub CmbTipoMp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipoMp.SelectedIndexChanged
        If Not _cargandoFiltros AndAlso opcTipoMp.Checked AndAlso Not String.IsNullOrEmpty(id_nodo_select) Then
            EjecutarBusqueda(False)
        End If
    End Sub

    Private Sub OpcTareasOk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcTareasOk.CheckedChanged
        If Not _cargandoFiltros AndAlso opcfiltroTareas.Checked AndAlso OpcTareasOk.Checked AndAlso Not String.IsNullOrEmpty(id_nodo_select) Then
            EjecutarBusqueda(False)
        End If
    End Sub

    Private Sub OpcTareasPend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcTareasPend.CheckedChanged
        If Not _cargandoFiltros AndAlso opcfiltroTareas.Checked AndAlso OpcTareasPend.Checked AndAlso Not String.IsNullOrEmpty(id_nodo_select) Then
            EjecutarBusqueda(False)
        End If
    End Sub

    Private Sub btnBuscarMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMp.Click
        EjecutarBusqueda(True)
    End Sub

    Private Sub LimpiarDetalleCiclo()
        grillaTareasInfMp.DataSource = Nothing
        grillaTareasPendInfMp.DataSource = Nothing
        grillaPersonalInfMp.DataSource = Nothing
        grillaInsumosInfMp.DataSource = Nothing
    End Sub

    Private Sub LimpiarGrillasResultados()
        _ultimoIdMpCargado = ""
        grillaInfMant.DataSource = Nothing
        grillaDetalleCicloMp.DataSource = Nothing
        Utilitarios.QuitarColumnaSeleccionGantt(grillaDetalleCicloMp)
        LimpiarDetalleCiclo()
        btnGantt.Enabled = False
    End Sub

    Private Sub CargarGrillaMantenciones(ByVal dst As DataSet, ByVal formatoGrid As FormatoGrillas)
        If dst IsNot Nothing AndAlso dst.Tables.Count > 0 Then
            grillaInfMant.DataSource = dst.Tables(0)
            formatoGrid.grillasMp(grillaInfMant)
            Utilitarios.AjustarColumnasGrilla(grillaInfMant)
        End If

        If grillaInfMant.RowCount > 0 Then
            grillaInfMant.ClearSelection()
            grillaInfMant.Rows(0).Selected = True
            If grillaInfMant.Columns.Count > 0 AndAlso grillaInfMant.Columns(0).Visible Then
                grillaInfMant.CurrentCell = grillaInfMant.Rows(0).Cells(0)
            End If
            CargarCiclosDeMpFila(0)
        Else
            _ultimoIdMpCargado = ""
            btnGantt.Enabled = False
        End If
    End Sub

    Private Sub CargarCiclosDeMpFila(ByVal rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= grillaInfMant.Rows.Count OrElse grillaInfMant.Rows(rowIndex).IsNewRow Then Exit Sub
        Dim valIdMp As Object = grillaInfMant.Rows(rowIndex).Cells(0).Value
        If valIdMp Is Nothing OrElse IsDBNull(valIdMp) OrElse String.IsNullOrWhiteSpace(valIdMp.ToString()) Then Exit Sub

        Dim idMpStr As String = valIdMp.ToString().Trim()
        If idMpStr <> _ultimoIdMpCargado Then
            LimpiarDetalleCiclo()
        End If
        _ultimoIdMpCargado = idMpStr

        Dim mant_prev As New MantPreventiva
        Dim formato_grid As New FormatoGrillas
        Dim DST As New DataSet
        grillaDetalleCicloMp.SuspendLayout()
        Try
            If opcFechas.Checked Then
                mant_prev.InfCicloMpPorRango(idMpStr, f_ini_inf_mp.Value, f_fin_inf_mp.Value, DST)
                If DST.Tables.Count = 0 OrElse DST.Tables(0).Rows.Count = 0 Then
                    DST.Clear()
                    DST.Tables.Clear()
                    mant_prev.InfCicloMp(idMpStr, DST)
                End If
            Else
                mant_prev.InfCicloMp(idMpStr, DST)
            End If
            Utilitarios.QuitarColumnaSeleccionGantt(grillaDetalleCicloMp)
            If DST.Tables.Count > 0 Then
                grillaDetalleCicloMp.DataSource = DST.Tables(0)
                formato_grid.grillasMp(grillaDetalleCicloMp)
                Utilitarios.AjustarColumnasGrilla(grillaDetalleCicloMp)
                Utilitarios.AsegurarColumnaSeleccionGantt(grillaDetalleCicloMp)
            Else
                grillaDetalleCicloMp.DataSource = Nothing
            End If
            btnGantt.Enabled = (grillaDetalleCicloMp.RowCount > 0)
        Finally
            grillaDetalleCicloMp.ResumeLayout(False)
        End Try
    End Sub

    Private Sub EjecutarBusqueda(ByVal mostrarValidaciones As Boolean)
        If _buscando Then Exit Sub

        If String.IsNullOrEmpty(id_nodo_select) Then
            If mostrarValidaciones Then
                MsgBox("Debe seleccionar un item del árbol antes de buscar", MsgBoxStyle.Exclamation, "Validación")
            End If
            Exit Sub
        End If

        If opcFechas.Checked AndAlso Not Utilitarios.ValidarRangoFechas(f_ini_inf_mp, f_fin_inf_mp) Then
            Exit Sub
        End If

        Dim mant_prev As New MantPreventiva
        Dim formato_grid As New FormatoGrillas
        Dim DST As New DataSet
        Dim utilitario As New Utilitarios

        _buscando = True
        Cursor = Cursors.WaitCursor
        grillaInfMant.SuspendLayout()
        grillaDetalleCicloMp.SuspendLayout()
        grillaTareasInfMp.SuspendLayout()
        grillaTareasPendInfMp.SuspendLayout()
        Try
            LimpiarGrillasResultados()

            If opcFechas.Checked Then
                mant_prev.InfMpFechas(id_nodo_select, f_ini_inf_mp.Value, f_fin_inf_mp.Value, CmbTipoMp.Text, 1, DST)
                CargarGrillaMantenciones(DST, formato_grid)
            ElseIf opcTipoMp.Checked Then
                mant_prev.InfMpTipoMp(id_nodo_select, f_ini_inf_mp.Value, f_fin_inf_mp.Value, CmbTipoMp.Text, 2, DST)
                CargarGrillaMantenciones(DST, formato_grid)
            ElseIf opcTodos.Checked Then
                mant_prev.InfMpTodos(id_nodo_select, f_ini_inf_mp.Value, f_fin_inf_mp.Value, CmbTipoMp.Text, 3, DST)
                CargarGrillaMantenciones(DST, formato_grid)
            ElseIf OpcTareasOk.Checked Then
                mant_prev.InfSoloTareasMp("1", id_nodo_select, DST)
                If DST.Tables.Count > 0 Then
                    grillaTareasInfMp.DataSource = DST.Tables(0)
                    formato_grid.grillasMp(grillaTareasInfMp)
                    Utilitarios.AjustarColumnasGrilla(grillaTareasInfMp)
                End If
                TabDetalleCicloMp.SelectedTab = TabDetalleCicloMp.TabPages(0)
            ElseIf OpcTareasPend.Checked Then
                mant_prev.InfSoloTareasMp("2", id_nodo_select, DST)
                If DST.Tables.Count > 0 Then
                    grillaTareasPendInfMp.DataSource = DST.Tables(0)
                    formato_grid.grillasMp(grillaTareasPendInfMp)
                    utilitario.numero_fila_grilla(grillaTareasPendInfMp)
                    Utilitarios.AjustarColumnasGrilla(grillaTareasPendInfMp)
                End If
                TabDetalleCicloMp.SelectedTab = TabDetalleCicloMp.TabPages(1)
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Mantención Preventiva (Buscar MP)", True, Me)
        Finally
            grillaTareasPendInfMp.ResumeLayout(False)
            grillaTareasInfMp.ResumeLayout(False)
            grillaDetalleCicloMp.ResumeLayout(False)
            grillaInfMant.ResumeLayout(False)
            Cursor = Cursors.Default
            _buscando = False
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Sub grillaInfMant_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grillaInfMant.SelectionChanged
        If _buscando OrElse _cargandoFiltros OrElse grillaInfMant.CurrentRow Is Nothing Then Exit Sub
        Dim valIdMp As Object = grillaInfMant.CurrentRow.Cells(0).Value
        If valIdMp Is Nothing OrElse IsDBNull(valIdMp) Then Exit Sub
        Dim idMpStr As String = valIdMp.ToString().Trim()
        If String.IsNullOrEmpty(idMpStr) OrElse idMpStr = _ultimoIdMpCargado Then Exit Sub
        Try
            CargarCiclosDeMpFila(grillaInfMant.CurrentRow.Index)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Mantención Preventiva (Selección MP)", True, Me)
        End Try
    End Sub

    Private Sub grillaInfMant_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaInfMant.CellDoubleClick
        Try
            CargarCiclosDeMpFila(e.RowIndex)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Mantención Preventiva (Grilla Informe Mantención)", True, Me)
        End Try
    End Sub

    Private Sub grillaDetalleCicloMp_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaDetalleCicloMp.CellDoubleClick
        Dim mant_prev As New MantPreventiva
        Dim formato_grid As New FormatoGrillas
        Dim DST2 As New DataSet
        Dim DST3 As New DataSet
        Dim DST4 As New DataSet
        Dim DST5 As New DataSet
        Try
            If e.RowIndex < 0 OrElse grillaDetalleCicloMp.Rows(e.RowIndex).IsNewRow Then Exit Sub
            If e.ColumnIndex >= 0 AndAlso grillaDetalleCicloMp.Columns(e.ColumnIndex).Name = "colSelGantt" Then Exit Sub
            Dim filaMp As DataGridViewRow = If(grillaInfMant.CurrentRow, If(grillaInfMant.SelectedRows.Count > 0, grillaInfMant.SelectedRows(0), Nothing))
            If filaMp Is Nothing Then Exit Sub
            Dim idMpObj As Object = filaMp.Cells(0).Value
            Dim idCicloObj As Object = grillaDetalleCicloMp.Rows(e.RowIndex).Cells(0).Value
            If idMpObj Is Nothing OrElse IsDBNull(idMpObj) OrElse idCicloObj Is Nothing OrElse IsDBNull(idCicloObj) Then Exit Sub
            Dim idMpStr As String = idMpObj.ToString()
            Dim idCicloStr As String = idCicloObj.ToString()

            TabDetalleCicloMp.SuspendLayout()
            mant_prev.InfTareasCicloMp(idMpStr, idCicloStr, id_nodo_select, DST2)
            mant_prev.InfTareasPendCicloMp(idMpStr, idCicloStr, id_nodo_select, DST5)
            mant_prev.InfPersonalCicloMp(idMpStr, idCicloStr, DST3)
            mant_prev.InfInsumosCicloMp(idMpStr, idCicloStr, DST4)

            If DST2.Tables.Count > 0 Then
                grillaTareasInfMp.DataSource = DST2.Tables(0)
                formato_grid.grillasMp(grillaTareasInfMp)
                Utilitarios.AjustarColumnasGrilla(grillaTareasInfMp)
            End If

            If DST3.Tables.Count > 0 Then
                grillaPersonalInfMp.DataSource = DST3.Tables(0)
                formato_grid.grillasMp(grillaPersonalInfMp)
                Utilitarios.AjustarColumnasGrilla(grillaPersonalInfMp)
            End If

            If DST4.Tables.Count > 0 Then
                grillaInsumosInfMp.DataSource = DST4.Tables(0)
                formato_grid.grillasMp(grillaInsumosInfMp)
                Utilitarios.AjustarColumnasGrilla(grillaInsumosInfMp)
            End If

            If DST5.Tables.Count > 0 Then
                grillaTareasPendInfMp.DataSource = DST5.Tables(0)
                formato_grid.grillasMp(grillaTareasPendInfMp)
                Utilitarios.AjustarColumnasGrilla(grillaTareasPendInfMp)
            End If

        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Mantención Preventiva (Grilla Detalle Ciclo MP)", True, Me)
        Finally
            TabDetalleCicloMp.ResumeLayout(False)
            Utilitarios.OptimizarMemoria()
        End Try

    End Sub

    Private Sub btnSalirInfMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirInfMp.Click
        Me.Close()
    End Sub

    Private Sub opcfiltroTareas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcfiltroTareas.CheckedChanged
        If opcfiltroTareas.Checked Then
            ActualizarVisibilidadFiltros()
            LimpiarGrillasResultados()
            If Not _cargandoFiltros AndAlso Not String.IsNullOrEmpty(id_nodo_select) Then
                EjecutarBusqueda(False)
            End If
        End If
    End Sub

    Private Sub btnExpExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpExcel.Click
        Dim MP As New MantPreventiva
        If opcFechas.Checked AndAlso Not Utilitarios.ValidarRangoFechas(f_ini_inf_mp, f_fin_inf_mp) Then Exit Sub
        If opcfiltroTareas.Checked Then
            If OpcTareasPend.Checked Then
                MP.expInfMpExcelSoloPend(grillaTareasPendInfMp, nombre_nodo_select)
            ElseIf OpcTareasOk.Checked Then
                MP.expInfMpExcelSoloRealizadas(grillaTareasInfMp, nombre_nodo_select)
            Else
                MsgBox("Seleccione si desea exportar tareas realizadas o pendientes.", MsgBoxStyle.Exclamation, "Validación")
            End If
        Else
            If nombre_nodo_select = "" Or grillaInfMant.RowCount = 0 Or grillaDetalleCicloMp.RowCount = 0 Then
                MsgBox("Debe seleccionar un nodo y buscar la MP antes de exportar a excel", MsgBoxStyle.Critical, "Validación")
            Else
                MP.exportarInfMpExcel(grillaInfMant, grillaDetalleCicloMp, grillaTareasInfMp, grillaPersonalInfMp, grillaTareasPendInfMp, grillaInsumosInfMp, nombre_nodo_select)
            End If
        End If
    End Sub

    Private Sub btnGantt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGantt.Click
        If grillaDetalleCicloMp.RowCount = 0 Then
            MsgBox("Debe desplegar una mantencion y los ciclos para generar la carta gantt", MsgBoxStyle.Exclamation, "Validación")
        Else
            FrmCartaGantt.form = Me.Name
            FrmCartaGantt.item_gantt = nombre_nodo_select
            If FrmCartaGantt.Visible Then
                FrmCartaGantt.RecargarDesdeOrigen()
                FrmCartaGantt.BringToFront()
            Else
                FrmCartaGantt.Show()
            End If
        End If
    End Sub

    Private Sub btnExpPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpPdf.Click
        Dim MP As New MantPreventiva
        If opcFechas.Checked AndAlso Not Utilitarios.ValidarRangoFechas(f_ini_inf_mp, f_fin_inf_mp) Then Exit Sub
        If opcfiltroTareas.Checked Then
            If OpcTareasPend.Checked Then
                MP.expInfMpPDFSoloPend(grillaTareasPendInfMp, nombre_nodo_select)
            ElseIf OpcTareasOk.Checked Then
                MP.expInfMpPDFSoloRealizadas(grillaTareasInfMp, nombre_nodo_select)
            Else
                MsgBox("Seleccione si desea exportar tareas realizadas o pendientes.", MsgBoxStyle.Exclamation, "Validación")
            End If
        Else
            If nombre_nodo_select = "" Or grillaInfMant.RowCount = 0 Or grillaDetalleCicloMp.RowCount = 0 Then
                MsgBox("Debe seleccionar un nodo y buscar la MP antes de exportar a PDF", MsgBoxStyle.Critical, "Validación")
            Else
                MP.exportarInfMpPDF(grillaInfMant, grillaDetalleCicloMp, grillaTareasInfMp, grillaPersonalInfMp, grillaTareasPendInfMp, grillaInsumosInfMp, nombre_nodo_select)
            End If
        End If
    End Sub

    Private Sub Arbol2_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles Arbol2.BeforeSelect
        Nodo.LimpiarResaltadoNodos(Arbol2.Nodes)
    End Sub

    Private Sub txtBuscarNodo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarNodo.KeyUp
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(Arbol2, txtBuscarNodo, e, id_nodo_select, nodo_anterior, 2)
        If Arbol2.SelectedNode IsNot Nothing Then
            nombre_nodo_select = Arbol2.SelectedNode.Text
        End If
    End Sub

    Private Sub txtBuscarNodo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarNodo.TextChanged
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(Arbol2, txtBuscarNodo, Nothing, id_nodo_select, nodo_anterior, 2)
        If Arbol2.SelectedNode IsNot Nothing Then
            nombre_nodo_select = Arbol2.SelectedNode.Text
        End If
    End Sub

    Private Sub btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Limpiar.Click
        LimpiarGrillasResultados()
        nombre_nodo_select = ""
        Utilitarios.InicializarRangoPorDefecto(f_ini_inf_mp, f_fin_inf_mp)
    End Sub
End Class
