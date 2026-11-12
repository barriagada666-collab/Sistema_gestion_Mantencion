Imports System.Data.SqlClient
Public Class FrmInfMantPrev
    Public id_nodo_select As String
    Public nombre_nodo_select As String
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Private Sub FrmInfMantPrev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mantPrev As New MantPreventiva
        Dim nd As New Nodo
        Dim nodoRaiz As New TreeNode
        Dim width As Double = Screen.PrimaryScreen.Bounds.Width
        Dim heigh As Double = Screen.PrimaryScreen.Bounds.Height

        Me.Width = width
        Me.Height = heigh

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
    End Sub

    Private Sub Arbol2_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Arbol2.AfterSelect

        id_nodo_select = Arbol2.SelectedNode.Name
        nodo_anterior2 = id_nodo_select
        Arbol2.SelectedNode.BackColor = Color.GreenYellow
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

        If opcFechas.Checked Then
            opcion = 1
            mant_prev.InfMpFechas(id_nodo_select, f_ini_inf_mp.Value, f_fin_inf_mp.Value, CmbTipoMp.Text, opcion, DST)
            grillaInfMant.DataSource = DST.Tables(0)
            formato_grid.grillasMp(grillaInfMant)
        ElseIf opcTipoMp.Checked Then
            opcion = 2
            mant_prev.InfMpFechas(id_nodo_select, f_ini_inf_mp.Value, f_fin_inf_mp.Value, CmbTipoMp.Text, opcion, DST)
            grillaInfMant.DataSource = DST.Tables(0)
            formato_grid.grillasMp(grillaInfMant)
        ElseIf opcTodos.Checked Then
            opcion = 3
            mant_prev.InfMpTodos(id_nodo_select, Now, Now, CmbTipoMp.Text, opcion, DST)
            grillaInfMant.DataSource = DST.Tables(0)
            formato_grid.grillasMp(grillaInfMant)

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
            TabDetalleCicloMp.SelectedTab = TabDetalleCicloMp.TabPages(1)
        End If
    End Sub

    Private Sub grillaInfMant_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaInfMant.CellContentDoubleClick
        Dim mant_prev As New MantPreventiva
        Dim formato_grid As New FormatoGrillas
        Try
            Dim DST As New DataSet
            mant_prev.InfCicloMp(grillaInfMant.Rows(e.RowIndex).Cells(0).Value, DST)
            grillaDetalleCicloMp.DataSource = DST.Tables(0)
            formato_grid.grillasMp(grillaDetalleCicloMp)
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
            mant_prev.InfTareasCicloMp(grillaInfMant.Rows(grillaInfMant.CurrentRow.Index).Cells(0).Value, grillaDetalleCicloMp.Rows(grillaDetalleCicloMp.CurrentRow.Index).Cells(0).Value, id_nodo_select, DST2)
            mant_prev.InfTareasPendCicloMp(grillaInfMant.Rows(grillaInfMant.CurrentRow.Index).Cells(0).Value, grillaDetalleCicloMp.Rows(grillaDetalleCicloMp.CurrentRow.Index).Cells(0).Value, id_nodo_select, DST5)
            mant_prev.InfPersonalCicloMp(grillaInfMant.Rows(grillaInfMant.CurrentRow.Index).Cells(0).Value, grillaDetalleCicloMp.Rows(grillaDetalleCicloMp.CurrentRow.Index).Cells(0).Value, DST3)
            mant_prev.InfInsumosCicloMp(grillaInfMant.Rows(grillaInfMant.CurrentRow.Index).Cells(0).Value, grillaDetalleCicloMp.Rows(grillaDetalleCicloMp.CurrentRow.Index).Cells(0).Value, DST4)

            If DST2.Tables.Count > 0 Then
                grillaTareasInfMp.DataSource = DST2.Tables(0)
                formato_grid.grillasMp(grillaTareasInfMp)
            End If

            If DST3.Tables.Count > 0 Then
                grillaPersonalInfMp.DataSource = DST3.Tables(0)
                formato_grid.grillasMp(grillaPersonalInfMp)
            End If

            If DST4.Tables.Count > 0 Then
                grillaInsumosInfMp.DataSource = DST4.Tables(0)
                formato_grid.grillasMp(grillaInsumosInfMp)
            End If

            If DST5.Tables.Count > 0 Then
                grillaTareasPendInfMp.DataSource = DST5.Tables(0)
                formato_grid.grillasMp(grillaTareasPendInfMp)
            End If
            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
        
    End Sub

    Private Sub btnSalirInfMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirInfMp.Click
        Me.Close()
    End Sub

    Private Sub GrpFiltroInf_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrpFiltroInf.Enter

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

    Private Sub tareasCicloMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tareasCicloMp.Click

    End Sub

    Private Sub TabDetalleCicloMp_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabDetalleCicloMp.Selecting

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

    Private Sub grillaInfMant_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles grillaInfMant.CellValueNeeded
     
    End Sub

    Private Sub btnGantt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGantt.Click
        'Dim MP As New MantPreventiva

        'If grillaInfMant.RowCount = 0 And grillaDetalleCicloMp.RowCount = 0 Then
        '    MsgBox("Debe desplegar una mantencion y los ciclos para generar la carta gantt", MsgBoxStyle.Exclamation, "Validación")
        'Else
        '    Try
        '        MP.expInfGantt(grillaDetalleCicloMp, nombre_nodo_select)
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        '    End Try
        'End If
        FrmCartaGantt.form = Me.Name
        FrmCartaGantt.Show()
    End Sub

    Private Sub btnExpPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MP As New MantPreventiva
        If opcfiltroTareas.Checked Then
            If opcfiltroTareas.Checked And OpcTareasPend.Checked Then
                MP.expInfMpPDFSoloPend(grillaTareasPendInfMp, nombre_nodo_select)
            ElseIf opcfiltroTareas.Checked And OpcTareasOk.Checked Then
                MP.expInfMpPDFSoloRealizadas(grillaTareasInfMp, nombre_nodo_select)
            End If
        Else
            If nombre_nodo_select = "" Or grillaInfMant.RowCount = 0 Or grillaDetalleCicloMp.RowCount = 0 Then
                MsgBox("Debe seleccionar un nodo y buscar la MP antes de exportar a excel", MsgBoxStyle.Critical, "Validación")
            Else
                MP.exportarInfMpPDF(grillaInfMant, grillaDetalleCicloMp, grillaTareasInfMp, grillaPersonalInfMp, grillaTareasPendInfMp, grillaInsumosInfMp, nombre_nodo_select)
            End If
        End If
    End Sub

    Private Sub Arbol2_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles Arbol2.BeforeSelect
        If nodo_anterior2 <> "" Then
            Dim nodo_finded() As TreeNode = Arbol2.Nodes.Find(nodo_anterior2, True)
            Arbol2.SelectedNode = nodo_finded(0)
            Arbol2.SelectedNode.BackColor = Color.White
        End If
    End Sub

    Private Sub Arbol2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Arbol2.Click

    End Sub

    Private Sub txtBuscarNodo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarNodo.KeyUp
        Dim nodo_find() As TreeNode
        Dim nodo As New Nodo
        Dim texto As String = txtBuscarNodo.Text & "%"
        Dim id_nodo As String = ""

        If texto <> "" And texto <> "%" Then
            If nodo_anterior <> "" Then
                nodo.limpiar_arbol(nodo_anterior, Arbol2)
            End If

            id_nodo = nodo.BuscarIdNodoLike(texto, 2)
            nodo_anterior = id_nodo
            If id_nodo = "" Then
                MsgBox("No se encontró el item", MsgBoxStyle.Exclamation, "Información")
            Else
                nodo_find = Arbol2.Nodes.Find(id_nodo, True)
                Arbol2.SelectedNode = nodo_find(0)
                Arbol2.SelectedNode.BackColor = Color.GreenYellow
            End If
        End If
    End Sub

    Private Sub txtBuscarNodo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarNodo.TextChanged

    End Sub

    Private Sub grillaDetalleCicloMp_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaDetalleCicloMp.CellContentClick

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