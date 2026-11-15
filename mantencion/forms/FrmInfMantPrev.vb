Imports System.Data.SqlClient
Public Class FrmInfMantPrev
    Public id_nodo_select As String = ""
    Public nombre_nodo_select As String = ""
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Private Sub FrmInfMantPrev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Dim mantPrev As New MantPreventiva
        Dim nd As New Nodo
        Dim nodoRaiz As New TreeNode

        Try
            Arbol2.BeginUpdate()
            nodoRaiz.Name = "1"
            nodoRaiz.Text = "Cambiaso Hnos S.A."
            nd.CRG_NODO_HIJO(nodoRaiz)
            Arbol2.Nodes.Add(nodoRaiz)
            mantPrev.CrgCmbTipoMp(CmbTipoMp)
            If CmbTipoMp.Items.Count > 0 Then
                CmbTipoMp.Text = CmbTipoMp.Items(0).ToString()
            End If
            Utilitarios.InicializarRangoMesActual(f_ini_inf_mp, f_fin_inf_mp)
            opcFechas.Checked = True
            ActualizarVisibilidadFiltros()
            Utilitarios.AplicarTemaModerno(Me)
        Finally
            Arbol2.EndUpdate()
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub ActualizarVisibilidadFiltros()
        ' El filtro por rango de fechas siempre permanece visible y habilitado en todos los modos
        lblFechaIniInfMp.Visible = True
        f_ini_inf_mp.Visible = True
        f_ini_inf_mp.Enabled = True
        lblFechaFinInfMp.Visible = True
        f_fin_inf_mp.Visible = True
        f_fin_inf_mp.Enabled = True

        Dim mostrarTipo As Boolean = opcTipoMp.Checked
        lbltipoMpInf.Visible = mostrarTipo
        CmbTipoMp.Visible = mostrarTipo
        CmbTipoMp.Enabled = mostrarTipo

        Dim mostrarTareas As Boolean = opcfiltroTareas.Checked
        GrpFiltroTareas.Visible = mostrarTareas
        If mostrarTareas AndAlso Not OpcTareasOk.Checked AndAlso Not OpcTareasPend.Checked Then
            OpcTareasOk.Checked = True
        End If
    End Sub

    Private Function FiltrarTablaPorRangoFechas(ByVal dt As DataTable, ByVal fechaDesde As DateTime, ByVal fechaHasta As DateTime) As DataTable
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return dt

        Dim colsFecha As New List(Of DataColumn)()
        For Each col As DataColumn In dt.Columns
            Dim nombreLower As String = col.ColumnName.ToLowerInvariant()
            If col.DataType Is GetType(DateTime) OrElse
               nombreLower.Contains("fecha") OrElse
               nombreLower.Contains("creacion") OrElse
               nombreLower.Contains("creación") OrElse
               nombreLower.Contains("inicio") OrElse
               nombreLower.Contains("termino") OrElse
               nombreLower.Contains("término") Then
                colsFecha.Add(col)
            End If
        Next
        If colsFecha.Count = 0 Then Return dt

        Dim desde As DateTime = fechaDesde.Date
        Dim hasta As DateTime = fechaHasta.Date
        Dim dtFiltrado As DataTable = dt.Clone()

        For Each fila As DataRow In dt.Rows
            Dim tieneAlgunaFechaValida As Boolean = False
            Dim coincideRango As Boolean = False

            For Each col As DataColumn In colsFecha
                Dim val As Object = fila(col)
                If val Is Nothing OrElse IsDBNull(val) Then Continue For
                Dim fechaFila As DateTime
                If TypeOf val Is DateTime Then
                    fechaFila = DirectCast(val, DateTime).Date
                    tieneAlgunaFechaValida = True
                ElseIf DateTime.TryParse(val.ToString(), fechaFila) Then
                    fechaFila = fechaFila.Date
                    tieneAlgunaFechaValida = True
                Else
                    Continue For
                End If

                If fechaFila >= desde AndAlso fechaFila <= hasta Then
                    coincideRango = True
                    Exit For
                End If
            Next

            If coincideRango OrElse Not tieneAlgunaFechaValida Then
                dtFiltrado.ImportRow(fila)
            End If
        Next

        Return dtFiltrado
    End Function

    Private Sub Arbol2_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Arbol2.AfterSelect
        If Arbol2.SelectedNode Is Nothing Then Exit Sub
        id_nodo_select = Arbol2.SelectedNode.Name
        nodo_anterior2 = id_nodo_select
        Arbol2.SelectedNode.BackColor = Utilitarios.ColorSeleccion
        nombre_nodo_select = Arbol2.SelectedNode.Text
    End Sub

    Private Sub opcFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcFechas.CheckedChanged
        If opcFechas.Checked Then ActualizarVisibilidadFiltros()
    End Sub

    Private Sub opcTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcTodos.CheckedChanged
        If opcTodos.Checked Then ActualizarVisibilidadFiltros()
    End Sub

    Private Sub btnBuscarMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMp.Click
        Dim mant_prev As New MantPreventiva
        Dim formato_grid As New FormatoGrillas
        Dim DST As New DataSet
        Dim opcion As Integer = 0
        Dim opcion_tareas As Integer = 0
        Dim utilitario As New Utilitarios

        If String.IsNullOrEmpty(id_nodo_select) Then
            MsgBox("Debe seleccionar un item del árbol antes de buscar", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        If Not Utilitarios.ValidarRangoFechas(f_ini_inf_mp, f_fin_inf_mp) Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        grillaInfMant.SuspendLayout()
        grillaDetalleCicloMp.SuspendLayout()
        grillaTareasInfMp.SuspendLayout()
        grillaTareasPendInfMp.SuspendLayout()
        Try
            If opcFechas.Checked Then
                opcion = 1
                mant_prev.InfMpFechas(id_nodo_select, f_ini_inf_mp.Value, f_fin_inf_mp.Value, CmbTipoMp.Text, opcion, DST)
                If DST.Tables.Count > 0 Then
                    grillaInfMant.DataSource = DST.Tables(0)
                    formato_grid.grillasMp(grillaInfMant)
                    Utilitarios.AjustarColumnasGrilla(grillaInfMant)
                End If
                btnGantt.Enabled = (grillaDetalleCicloMp.RowCount > 0)
            ElseIf opcTipoMp.Checked Then
                opcion = 2
                mant_prev.InfMpFechas(id_nodo_select, f_ini_inf_mp.Value, f_fin_inf_mp.Value, CmbTipoMp.Text, opcion, DST)
                If DST.Tables.Count > 0 Then
                    grillaInfMant.DataSource = FiltrarTablaPorRangoFechas(DST.Tables(0), f_ini_inf_mp.Value, f_fin_inf_mp.Value)
                    formato_grid.grillasMp(grillaInfMant)
                    Utilitarios.AjustarColumnasGrilla(grillaInfMant)
                End If
                btnGantt.Enabled = (grillaDetalleCicloMp.RowCount > 0)
            ElseIf opcTodos.Checked Then
                opcion = 3
                mant_prev.InfMpTodos(id_nodo_select, f_ini_inf_mp.Value, f_fin_inf_mp.Value, CmbTipoMp.Text, opcion, DST)
                If DST.Tables.Count > 0 Then
                    grillaInfMant.DataSource = FiltrarTablaPorRangoFechas(DST.Tables(0), f_ini_inf_mp.Value, f_fin_inf_mp.Value)
                    formato_grid.grillasMp(grillaInfMant)
                    Utilitarios.AjustarColumnasGrilla(grillaInfMant)
                End If
                btnGantt.Enabled = (grillaDetalleCicloMp.RowCount > 0)

            ElseIf OpcTareasOk.Checked Then
                If grillaInfMant.RowCount > 0 Then
                    grillaInfMant.DataSource = Nothing
                End If

                If grillaDetalleCicloMp.RowCount > 0 Then
                    grillaDetalleCicloMp.DataSource = Nothing
                End If

                If grillaTareasPendInfMp.RowCount > 0 Then
                    grillaTareasPendInfMp.DataSource = Nothing
                End If
                btnGantt.Enabled = False
                opcion_tareas = 1
                mant_prev.InfSoloTareasMp(opcion_tareas, id_nodo_select, DST)
                If DST.Tables.Count > 0 Then
                    grillaTareasInfMp.DataSource = FiltrarTablaPorRangoFechas(DST.Tables(0), f_ini_inf_mp.Value, f_fin_inf_mp.Value)
                    formato_grid.grillasMp(grillaTareasInfMp)
                    Utilitarios.AjustarColumnasGrilla(grillaTareasInfMp)
                End If
                TabDetalleCicloMp.SelectedTab = TabDetalleCicloMp.TabPages(0)

            ElseIf OpcTareasPend.Checked Then
                opcion_tareas = 2
                mant_prev.InfSoloTareasMp(opcion_tareas, id_nodo_select, DST)
                If grillaTareasInfMp.RowCount > 0 Then
                    grillaTareasInfMp.DataSource = Nothing
                End If

                If grillaInfMant.RowCount > 0 Then
                    grillaInfMant.DataSource = Nothing
                End If

                If grillaDetalleCicloMp.RowCount > 0 Then
                    grillaDetalleCicloMp.DataSource = Nothing
                End If
                btnGantt.Enabled = False
                If DST.Tables.Count > 0 Then
                    grillaTareasPendInfMp.DataSource = FiltrarTablaPorRangoFechas(DST.Tables(0), f_ini_inf_mp.Value, f_fin_inf_mp.Value)
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
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Sub grillaInfMant_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaInfMant.CellContentDoubleClick
        Dim mant_prev As New MantPreventiva
        Dim formato_grid As New FormatoGrillas
        Try
            If e.RowIndex < 0 Then Exit Sub
            Dim DST As New DataSet
            grillaDetalleCicloMp.SuspendLayout()
            mant_prev.InfCicloMp(grillaInfMant.Rows(e.RowIndex).Cells(0).Value, DST)
            If DST.Tables.Count > 0 Then
                grillaDetalleCicloMp.DataSource = DST.Tables(0)
                formato_grid.grillasMp(grillaDetalleCicloMp)
                Utilitarios.AjustarColumnasGrilla(grillaDetalleCicloMp)
            End If
            btnGantt.Enabled = (grillaDetalleCicloMp.RowCount > 0)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Mantención Preventiva (Grilla Informe Mantención)", True, Me)
        Finally
            grillaDetalleCicloMp.ResumeLayout(False)
        End Try

    End Sub

    Private Sub opcTipoMp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcTipoMp.CheckedChanged
        If opcTipoMp.Checked Then ActualizarVisibilidadFiltros()
    End Sub

    Private Sub grillaDetalleCicloMp_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaDetalleCicloMp.CellContentDoubleClick
        Dim mant_prev As New MantPreventiva
        Dim formato_grid As New FormatoGrillas
        Dim DST2 As New DataSet
        Dim DST3 As New DataSet
        Dim DST4 As New DataSet
        Dim DST5 As New DataSet
        Try
            If e.RowIndex < 0 OrElse grillaInfMant.CurrentRow Is Nothing OrElse grillaDetalleCicloMp.CurrentRow Is Nothing Then Exit Sub
            TabDetalleCicloMp.SuspendLayout()
            mant_prev.InfTareasCicloMp(grillaInfMant.Rows(grillaInfMant.CurrentRow.Index).Cells(0).Value, grillaDetalleCicloMp.Rows(grillaDetalleCicloMp.CurrentRow.Index).Cells(0).Value, id_nodo_select, DST2)
            mant_prev.InfTareasPendCicloMp(grillaInfMant.Rows(grillaInfMant.CurrentRow.Index).Cells(0).Value, grillaDetalleCicloMp.Rows(grillaDetalleCicloMp.CurrentRow.Index).Cells(0).Value, id_nodo_select, DST5)
            mant_prev.InfPersonalCicloMp(grillaInfMant.Rows(grillaInfMant.CurrentRow.Index).Cells(0).Value, grillaDetalleCicloMp.Rows(grillaDetalleCicloMp.CurrentRow.Index).Cells(0).Value, DST3)
            mant_prev.InfInsumosCicloMp(grillaInfMant.Rows(grillaInfMant.CurrentRow.Index).Cells(0).Value, grillaDetalleCicloMp.Rows(grillaDetalleCicloMp.CurrentRow.Index).Cells(0).Value, DST4)

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

            If grillaTareasInfMp.RowCount > 0 Then
                grillaTareasInfMp.DataSource = Nothing
            End If

            If grillaTareasPendInfMp.RowCount > 0 Then
                grillaTareasPendInfMp.DataSource = Nothing
            End If

            If grillaPersonalInfMp.RowCount > 0 Then
                grillaPersonalInfMp.DataSource = Nothing
            End If

            If grillaInsumosInfMp.RowCount > 0 Then
                grillaInsumosInfMp.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub btnExpExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpExcel.Click
        Dim MP As New MantPreventiva
        If Not Utilitarios.ValidarRangoFechas(f_ini_inf_mp, f_fin_inf_mp) Then Exit Sub
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
            FrmCartaGantt.Show()
        End If
    End Sub

    Private Sub btnExpPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpPdf.Click
        Dim MP As New MantPreventiva
        If Not Utilitarios.ValidarRangoFechas(f_ini_inf_mp, f_fin_inf_mp) Then Exit Sub
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
        If grillaInfMant.ColumnCount > 0 Then
            grillaInfMant.Columns.Clear()
        End If

        If grillaDetalleCicloMp.ColumnCount > 0 Then
            grillaDetalleCicloMp.Columns.Clear()
        End If

        If grillaTareasInfMp.ColumnCount > 0 Then
            grillaTareasInfMp.Columns.Clear()
        End If

        If grillaTareasPendInfMp.ColumnCount > 0 Then
            grillaTareasPendInfMp.Columns.Clear()
        End If

        If grillaPersonalInfMp.ColumnCount > 0 Then
            grillaPersonalInfMp.Columns.Clear()
        End If

        If grillaInsumosInfMp.ColumnCount > 0 Then
            grillaInsumosInfMp.Columns.Clear()
        End If

        btnGantt.Enabled = False
    End Sub
End Class
