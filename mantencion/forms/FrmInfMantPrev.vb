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
            CmbTipoMp.Text = CmbTipoMp.Items(0)
            lblFechaIniInfMp.Visible = False
            f_ini_inf_mp.Visible = False
            lblFechaFinInfMp.Visible = False
            f_fin_inf_mp.Visible = False
            lbltipoMpInf.Visible = False
            CmbTipoMp.Visible = False
            GrpFiltroTareas.Visible = False
            Utilitarios.AplicarTemaModerno(Me)
        Finally
            Arbol2.EndUpdate()
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub Arbol2_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Arbol2.AfterSelect
        If Arbol2.SelectedNode Is Nothing Then Exit Sub
        id_nodo_select = Arbol2.SelectedNode.Name
        nodo_anterior2 = id_nodo_select
        Arbol2.SelectedNode.BackColor = Utilitarios.ColorSeleccion
        nombre_nodo_select = Arbol2.SelectedNode.Text
    End Sub

    Private Sub opcFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcFechas.CheckedChanged
        If opcFechas.Checked Then
            lblFechaIniInfMp.Visible = True
            f_ini_inf_mp.Visible = True
            lblFechaFinInfMp.Visible = True
            f_fin_inf_mp.Visible = True
        Else
            lblFechaIniInfMp.Visible = False
            f_ini_inf_mp.Visible = False
            lblFechaFinInfMp.Visible = False
            f_fin_inf_mp.Visible = False
        End If
    End Sub

    Private Sub opcTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcTodos.CheckedChanged
        If opcTodos.Checked Then
            lblFechaIniInfMp.Visible = False
            f_ini_inf_mp.Visible = False
            lblFechaFinInfMp.Visible = False
            f_fin_inf_mp.Visible = False
            lbltipoMpInf.Visible = False
            CmbTipoMp.Visible = False
            GrpFiltroTareas.Visible = False
        Else
            lblFechaIniInfMp.Visible = False
            f_ini_inf_mp.Visible = False
            lblFechaFinInfMp.Visible = False
            f_fin_inf_mp.Visible = False
            lbltipoMpInf.Visible = False
            CmbTipoMp.Visible = False
        End If
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

        Cursor = Cursors.WaitCursor
        Try
            If opcFechas.Checked Then
                opcion = 1
                mant_prev.InfMpFechas(id_nodo_select, f_ini_inf_mp.Value, f_fin_inf_mp.Value, CmbTipoMp.Text, opcion, DST)
                grillaInfMant.DataSource = DST.Tables(0)
                formato_grid.grillasMp(grillaInfMant)
                Utilitarios.AjustarColumnasGrilla(grillaInfMant)
            ElseIf opcTipoMp.Checked Then
                opcion = 2
                mant_prev.InfMpFechas(id_nodo_select, f_ini_inf_mp.Value, f_fin_inf_mp.Value, CmbTipoMp.Text, opcion, DST)
                grillaInfMant.DataSource = DST.Tables(0)
                formato_grid.grillasMp(grillaInfMant)
                Utilitarios.AjustarColumnasGrilla(grillaInfMant)
            ElseIf opcTodos.Checked Then
                opcion = 3
                mant_prev.InfMpTodos(id_nodo_select, Now, Now, CmbTipoMp.Text, opcion, DST)
                grillaInfMant.DataSource = DST.Tables(0)
                formato_grid.grillasMp(grillaInfMant)
                Utilitarios.AjustarColumnasGrilla(grillaInfMant)

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
                opcion_tareas = 1
                mant_prev.InfSoloTareasMp(opcion_tareas, id_nodo_select, DST)
                grillaTareasInfMp.DataSource = DST.Tables(0)
                formato_grid.grillasMp(grillaTareasInfMp)
                Utilitarios.AjustarColumnasGrilla(grillaTareasInfMp)

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
                grillaTareasPendInfMp.DataSource = DST.Tables(0)
                formato_grid.grillasMp(grillaTareasPendInfMp)
                utilitario.numero_fila_grilla(grillaTareasPendInfMp)
                Utilitarios.AjustarColumnasGrilla(grillaTareasPendInfMp)
                TabDetalleCicloMp.SelectedTab = TabDetalleCicloMp.TabPages(1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
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
            mant_prev.InfCicloMp(grillaInfMant.Rows(e.RowIndex).Cells(0).Value, DST)
            grillaDetalleCicloMp.DataSource = DST.Tables(0)
            formato_grid.grillasMp(grillaDetalleCicloMp)
            Utilitarios.AjustarColumnasGrilla(grillaDetalleCicloMp)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub opcTipoMp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcTipoMp.CheckedChanged
        If opcTipoMp.Checked Then
            lblFechaIniInfMp.Visible = False
            f_ini_inf_mp.Visible = False
            lblFechaFinInfMp.Visible = False
            f_fin_inf_mp.Visible = False
            GrpFiltroTareas.Visible = False
            lbltipoMpInf.Visible = True
            CmbTipoMp.Visible = True
        Else
            lblFechaIniInfMp.Visible = False
            f_ini_inf_mp.Visible = False
            lblFechaFinInfMp.Visible = False
            f_fin_inf_mp.Visible = False
            lbltipoMpInf.Visible = False
            CmbTipoMp.Visible = False
        End If
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try

    End Sub

    Private Sub btnSalirInfMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirInfMp.Click
        Me.Close()
    End Sub

    Private Sub opcfiltroTareas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcfiltroTareas.CheckedChanged
        If opcfiltroTareas.Checked Then
            GrpFiltroTareas.Visible = True
            lblFechaIniInfMp.Visible = False
            f_ini_inf_mp.Visible = False
            lblFechaFinInfMp.Visible = False
            f_fin_inf_mp.Visible = False
            lbltipoMpInf.Visible = False
            CmbTipoMp.Visible = False

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
        If opcfiltroTareas.Checked Then
            If opcfiltroTareas.Checked And OpcTareasPend.Checked Then
                MP.expInfMpExcelSoloPend(grillaTareasPendInfMp, nombre_nodo_select)
            ElseIf opcfiltroTareas.Checked And OpcTareasOk.Checked Then
                MP.expInfMpExcelSoloRealizadas(grillaTareasInfMp, nombre_nodo_select)
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
        If opcfiltroTareas.Checked Then
            If opcfiltroTareas.Checked And OpcTareasPend.Checked Then
                MP.expInfMpPDFSoloPend(grillaTareasPendInfMp, nombre_nodo_select)
            ElseIf opcfiltroTareas.Checked And OpcTareasOk.Checked Then
                MP.expInfMpPDFSoloRealizadas(grillaTareasInfMp, nombre_nodo_select)
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
        Dim formato_grid As New FormatoGrillas

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

    End Sub
End Class
