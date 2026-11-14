Imports System.IO
Imports System.Collections.Generic
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Public Class FrmInfOT

    Public id_nodo_select As String = ""
    Public estado_ot As String = ""
    Public detencion As String = ""
    Public tipo_trabajo As String = ""
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Public array_plantas(3) As Integer
    Private _actualizandoChecks As Boolean = False

    Private Sub arbol5_AfterCheck(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles arbol5.AfterCheck
        If _actualizandoChecks Then Exit Sub
        Try
            _actualizandoChecks = True
            MarcarHijos(e.Node, e.Node.Checked)
        Finally
            _actualizandoChecks = False
        End Try
    End Sub

    Private Sub MarcarHijos(ByVal nodoPadre As TreeNode, ByVal estado As Boolean)
        If nodoPadre Is Nothing Then Exit Sub
        For Each hijo As TreeNode In nodoPadre.Nodes
            hijo.Checked = estado
            MarcarHijos(hijo, estado)
        Next
    End Sub

    Public Function ObtenerNodosObjetivo() As List(Of TreeNode)
        Dim lista As New List(Of TreeNode)()
        RecolectarNodosRaizCheckeados(arbol5.Nodes, lista)
        ' Si no hay casillas de verificación marcadas, usar el nodo seleccionado por click
        If lista.Count = 0 AndAlso arbol5.SelectedNode IsNot Nothing AndAlso Not String.IsNullOrEmpty(arbol5.SelectedNode.Name) Then
            lista.Add(arbol5.SelectedNode)
        End If
        Return lista
    End Function

    Private Sub RecolectarNodosRaizCheckeados(ByVal nodos As TreeNodeCollection, ByVal lista As List(Of TreeNode))
        If nodos Is Nothing Then Exit Sub
        For Each n As TreeNode In nodos
            If n.Checked Then
                lista.Add(n)
            Else
                RecolectarNodosRaizCheckeados(n.Nodes, lista)
            End If
        Next
    End Sub

    Private Sub FusionarDataSetsOT(ByVal dstDestino As DataSet, ByVal dstOrigen As DataSet, ByVal otsExistentes As HashSet(Of String))
        If dstOrigen Is Nothing OrElse dstOrigen.Tables.Count = 0 OrElse dstOrigen.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim dtOrigen As DataTable = dstOrigen.Tables(0)
        If dstDestino.Tables.Count = 0 Then
            dstDestino.Tables.Add(dtOrigen.Clone())
        End If
        Dim dtDestino As DataTable = dstDestino.Tables(0)
        dtDestino.BeginLoadData()
        For Each fila As DataRow In dtOrigen.Rows
            Dim numOt As String = fila(0).ToString().Trim()
            If otsExistentes.Add(numOt) Then
                dtDestino.ImportRow(fila)
            End If
        Next
        dtDestino.EndLoadData()
    End Sub

    Private Sub AsignarPersonalGrilla(ByVal DST_PER As DataSet)
        If DST_PER Is Nothing OrElse DST_PER.Tables.Count = 0 OrElse DST_PER.Tables(0).Rows.Count = 0 Then Return

        Dim personalPorOt As New Dictionary(Of String, List(Of String))(StringComparer.OrdinalIgnoreCase)
        For Each row As DataRow In DST_PER.Tables(0).Rows
            Dim numOt As String = row.Item(0).ToString().Trim()
            Dim nomPer As String = row.Item(2).ToString()
            Dim lista As List(Of String) = Nothing
            If Not personalPorOt.TryGetValue(numOt, lista) Then
                lista = New List(Of String)(3)
                personalPorOt(numOt) = lista
            End If
            If lista.Count < 3 AndAlso Not lista.Contains(nomPer) Then
                lista.Add(nomPer)
            End If
        Next

        For i As Integer = 0 To grillaInfOt.RowCount - 1
            Dim valOt As Object = grillaInfOt.Rows(i).Cells(0).Value
            If valOt IsNot Nothing Then
                Dim keyOt As String = valOt.ToString().Trim()
                Dim lista As List(Of String) = Nothing
                If personalPorOt.TryGetValue(keyOt, lista) Then
                    For col As Integer = 0 To lista.Count - 1
                        grillaInfOt.Rows(i).Cells(col + 12).Value = lista(col)
                    Next
                End If
            End If
        Next
    End Sub

    Private Sub txtBuscarNodo5_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarNodo5.KeyUp
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(arbol5, txtBuscarNodo5, e, id_nodo_select, nodo_anterior, 2)
    End Sub

    Private Sub txtBuscarNodo5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarNodo5.TextChanged
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(arbol5, txtBuscarNodo5, Nothing, id_nodo_select, nodo_anterior, 2)
    End Sub

    Private Sub FrmInfOT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Dim nd As New Nodo
        Dim nodoRaiz As New TreeNode
        Dim OT As New OT
        Dim cargo As New Cargo

        Try
            arbol5.BeginUpdate()
            nodoRaiz.Name = "1"
            nodoRaiz.Text = "Cambiaso Hnos S.A."
            nd.CRG_NODO_HIJO(nodoRaiz)
            arbol5.Nodes.Clear()
            arbol5.Nodes.Add(nodoRaiz)
            OT.CrgCmbTipoDet(cmbTipoTrabajoInfOt)
            cargo.crgTipoInter(cmbTipoDetencion)

            GrpFiltroFechas.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            cmbTipoTrabajoInfOt.Visible = False
            cmbTipoDetencion.Visible = False
            PanPlantas.Visible = False
            Utilitarios.AplicarTemaModerno(Me)
        Finally
            arbol5.EndUpdate()
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub OpcFechasOt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcFechasOt.CheckedChanged
        If opcFechasOt.Checked Then
            GrpFiltroFechas.Visible = True
            Label2.Visible = False
            txtNumOtInfOt.Visible = False
            txtNumOtInfOt.ResetText()
            chkTodasFechas.Checked = True
        Else
            GrpFiltroFechas.Visible = False
            Label2.Visible = True
            txtNumOtInfOt.Visible = True
        End If
    End Sub

    Private Sub btnBuscarOt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarOt.Click
        Dim OT As New OT
        Dim DST_OT As New DataSet
        Dim DST_PER As New DataSet
        Dim opcion As Integer
        Dim formato_grid As New FormatoGrillas
        Dim fecha_comp As New DateTime(2011, 12, 31)
        Dim fecha_comp_2 As New DateTime(2012, 1, 1)
        estado_ot = ""
        detencion = ""
        grillaInfOt.Columns.Clear()

        If chkPendientes.Checked Then
            estado_ot = "abierta"
        ElseIf chkNulas.Checked Then
            estado_ot = "nula"
        End If

        If chkConDetencion.Checked Then
            detencion = "SI"
        End If

        opcion = OT.opcion_inf_ot
        Cursor = Cursors.WaitCursor
        Try
            If opcFechasOt.Checked Then
                'Informe ordenes de trabajo por rango de fechas mas filtros de búsqueda (soporta múltiples ítems seleccionados)
                '======================================================================================================================================================
                Dim tienePlanta As Boolean = (array_plantas(0) > 0 OrElse array_plantas(1) > 0 OrElse array_plantas(2) > 0)
                Dim nodosObjetivo As List(Of TreeNode) = ObtenerNodosObjetivo()

                If nodosObjetivo.Count = 0 AndAlso Not tienePlanta Then
                    MsgBox("Debe seleccionar uno o más ítems del árbol antes de buscar", MsgBoxStyle.Exclamation, "Validación")
                    Exit Sub
                End If

                DST_OT.Tables.Clear()
                DST_PER.Tables.Clear()

                If tienePlanta Then
                    Dim DST_PL_2 As New DataSet
                    Dim DST_PL_4 As New DataSet
                    Dim DST_PL_3 As New DataSet

                    If array_plantas(0) = 2 Then
                        OT.infOt(array_plantas(0).ToString, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_PL_2)
                    End If

                    If array_plantas(1) = 4 Then
                        OT.infOt(array_plantas(1).ToString, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_PL_4)
                    End If

                    If array_plantas(2) = 3 Then
                        OT.infOt(array_plantas(2).ToString, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_PL_3)
                    End If

                    Dim otsPlantas As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
                    FusionarDataSetsOT(DST_OT, DST_PL_2, otsPlantas)
                    FusionarDataSetsOT(DST_OT, DST_PL_4, otsPlantas)
                    FusionarDataSetsOT(DST_OT, DST_PL_3, otsPlantas)

                    DST_PL_2.Dispose()
                    DST_PL_3.Dispose()
                    DST_PL_4.Dispose()
                Else
                    Dim otsExistentes As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
                    For Each nd As TreeNode In nodosObjetivo
                        Dim idNodoStr As String = nd.Name
                        Dim DST_TEMP As New DataSet

                        If fecha_ini_inf_ot.Value.Date > fecha_comp Then
                            OT.infOt(idNodoStr, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_TEMP)
                        ElseIf fecha_ini_inf_ot.Value.Date < fecha_comp_2 AndAlso fecha_fin_inf_ot.Value.Date > fecha_comp Then
                            Dim DST_HIST As New DataSet
                            OT.infOt(idNodoStr, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_TEMP)
                            OT.infOtHistorico(idNodoStr, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_HIST)
                            If DST_HIST.Tables.Count > 0 AndAlso DST_HIST.Tables(0).Rows.Count > 0 Then
                                DST_TEMP.Merge(DST_HIST)
                            End If
                            DST_HIST.Dispose()
                        Else
                            OT.infOtHistorico(idNodoStr, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_TEMP)
                        End If

                        FusionarDataSetsOT(DST_OT, DST_TEMP, otsExistentes)
                        DST_TEMP.Dispose()
                    Next
                End If

                OT.infPersonalOt(fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, DST_PER)

                If DST_OT.Tables.Count > 0 AndAlso DST_OT.Tables(0).Rows.Count > 0 Then
                    Try
                        DST_OT.Tables(0).DefaultView.Sort = "Fecha/Hora_Inicio ASC"
                    Catch
                    End Try
                    grillaInfOt.DataSource = DST_OT.Tables(0)
                    grillaInfOt.Columns.Add("Personal_1", "Personal_1")
                    grillaInfOt.Columns.Add("Personal_2", "Personal_2")
                    grillaInfOt.Columns.Add("Personal_3", "Personal_3")
                    formato_grid.grillasOT(grillaInfOt)
                    AsignarPersonalGrilla(DST_PER)
                    Utilitarios.AjustarColumnasGrilla(grillaInfOt)
                Else
                    MsgBox("No se encontraron registros", MsgBoxStyle.Exclamation, "Validación")
                End If

                DST_PER.Dispose()
                '======================================================================================================================================================
            Else
                'Informe ordenes de trabajo por numero de orden
                '================================================================================================
                If txtNumOtInfOt.Text = "" Then
                    MsgBox("Debe ingresar el N° de OT antes de buscar", MsgBoxStyle.Exclamation, "Validación")
                    txtNumOtInfOt.Focus()
                Else
                    Dim nodosObjetivo As List(Of TreeNode) = ObtenerNodosObjetivo()
                    Dim otsExistentes As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
                    DST_OT.Tables.Clear()
                    DST_PER.Tables.Clear()

                    If nodosObjetivo.Count > 0 Then
                        For Each nd As TreeNode In nodosObjetivo
                            Dim DST_TEMP As New DataSet
                            OT.infOt(nd.Name, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_TEMP)
                            FusionarDataSetsOT(DST_OT, DST_TEMP, otsExistentes)
                            DST_TEMP.Dispose()
                        Next
                    Else
                        OT.infOt(id_nodo_select, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_OT)
                    End If

                    OT.infPersonalOt(fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, DST_PER)

                    If DST_OT.Tables.Count > 0 AndAlso DST_OT.Tables(0).Rows.Count > 0 Then
                        grillaInfOt.DataSource = DST_OT.Tables(0)
                        grillaInfOt.Columns.Add("Personal_1", "Personal_1")
                        grillaInfOt.Columns.Add("Personal_2", "Personal_2")
                        grillaInfOt.Columns.Add("Personal_3", "Personal_3")
                        formato_grid.grillasOT(grillaInfOt)
                        AsignarPersonalGrilla(DST_PER)
                        Utilitarios.AjustarColumnasGrilla(grillaInfOt)
                    Else
                        MsgBox("No se encontraron registros para la OT N° " & txtNumOtInfOt.Text, MsgBoxStyle.Exclamation, "Validación")
                    End If

                    DST_PER.Dispose()
                End If
                '=================================================================================================
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Cursor = Cursors.Default
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Sub chkTipoTrabajo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTipoTrabajo.CheckedChanged
        If chkTipoTrabajo.Checked Then
            Label5.Visible = True
            cmbTipoTrabajoInfOt.Visible = True
        Else
            Label5.Visible = False
            cmbTipoTrabajoInfOt.Visible = False
        End If
    End Sub

    Private Sub chkTipoDetencion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTipoDetencion.CheckedChanged
        If chkTipoDetencion.Checked Then
            cmbTipoDetencion.Visible = True
        Else
            cmbTipoDetencion.Visible = False
        End If
    End Sub

    Private Sub chkTodasFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodasFechas.CheckedChanged
        If chkTodasFechas.Checked Then
            chkPendientes.Enabled = False
            chkConDetencion.Enabled = False
            chkTipoDetencion.Enabled = False
            chkTipoTrabajo.Enabled = False
            chkNulas.Enabled = False
        Else
            chkPendientes.Enabled = True
            chkConDetencion.Enabled = True
            chkTipoDetencion.Enabled = True
            chkTipoTrabajo.Enabled = True
            chkNulas.Enabled = True
        End If
    End Sub

    Private Sub arbol5_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles arbol5.AfterSelect
        If arbol5.SelectedNode Is Nothing Then Exit Sub
        id_nodo_select = arbol5.SelectedNode.Name
        nodo_anterior2 = id_nodo_select
        arbol5.SelectedNode.BackColor = Utilitarios.ColorSeleccion
    End Sub

    Private Sub btnSalirInfOt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirInfOt.Click
        Me.Close()
    End Sub

    Private Sub btnExcExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcExcel.Click
        Dim OT As New OT
        Dim planta As String = ""

        Dim nodos As List(Of TreeNode) = ObtenerNodosObjetivo()
        If nodos.Count > 0 Then
            Dim nombres As New List(Of String)()
            For Each nd As TreeNode In nodos
                nombres.Add(nd.Text.Trim())
            Next
            planta = String.Join(" - ", nombres.ToArray())
        End If

        If pl_2.Checked Then
            planta = pl_2.Text
        ElseIf pl_3.Checked Then
            planta = pl_3.Text
        ElseIf pl_4.Checked Then
            planta = pl_4.Text
        End If

        Try
            OT.exportarInfOtExcel(grillaInfOt, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, planta)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click
        Dim OT As New OT
        Dim planta As String = ""

        Dim nodos As List(Of TreeNode) = ObtenerNodosObjetivo()
        If nodos.Count > 0 Then
            Dim nombres As New List(Of String)()
            For Each nd As TreeNode In nodos
                nombres.Add(nd.Text.Trim())
            Next
            planta = String.Join(" - ", nombres.ToArray())
        End If

        If pl_2.Checked Then
            planta = pl_2.Text
        ElseIf pl_3.Checked Then
            planta = pl_3.Text
        ElseIf pl_4.Checked Then
            planta = pl_4.Text
        End If

        Try
            OT.exportarInfOtPDF(grillaInfOt, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, planta)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub txtNumOtInfOt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumOtInfOt.KeyPress
        Dim utilitarios As New Utilitarios

        utilitarios.solonumeros(e)
    End Sub

    Private Sub arbol5_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles arbol5.BeforeSelect
        Nodo.LimpiarResaltadoNodos(arbol5.Nodes)
    End Sub

    Private Sub grillaInfOt_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaInfOt.CellContentDoubleClick
        If e.RowIndex < 0 OrElse grillaInfOt.CurrentRow Is Nothing Then Exit Sub
        If grillaInfOt.RowCount > 0 Then
            FrmDetalleOt.num_ot = grillaInfOt.Rows(grillaInfOt.CurrentRow.Index).Cells(0).Value
            FrmDetalleOt.Show()
        End If

    End Sub

    Private Sub chkFiltroPlanta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFiltroPlanta.CheckedChanged
        If chkFiltroPlanta.Checked Then
            PanPlantas.Visible = True
            chkPendientes.Enabled = True
            arbol5.Enabled = False
            txtBuscarNodo5.Enabled = False
        Else
            pl_2.Checked = False
            pl_3.Checked = False
            pl_4.Checked = False
            PanPlantas.Visible = False
            arbol5.Enabled = True
            txtBuscarNodo5.Enabled = True
        End If
    End Sub

    Private Sub pl_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pl_2.CheckedChanged
        If pl_2.Checked Then
            array_plantas(0) = 2
        Else
            array_plantas(0) = 0
        End If
    End Sub

    Private Sub pl_4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pl_4.CheckedChanged
        If pl_4.Checked Then
            array_plantas(1) = 4
        Else
            array_plantas(1) = 0
        End If
    End Sub

    Private Sub pl_3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pl_3.CheckedChanged
        If pl_3.Checked Then
            array_plantas(2) = 3
        Else
            array_plantas(2) = 0
        End If
    End Sub
End Class
