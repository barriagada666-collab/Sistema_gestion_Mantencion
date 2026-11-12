Imports System.IO
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

    Private Sub txtBuscarNodo5_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarNodo5.KeyUp
        Dim nodo_find() As TreeNode
        Dim nodo As New Nodo
        Dim texto As String = txtBuscarNodo5.Text & "%"
        Dim id_nodo As String = ""

        If texto <> "" And texto <> "%" Then
            If nodo_anterior <> "" Then
                nodo.limpiar_arbol(nodo_anterior, arbol5)
            End If

            id_nodo = nodo.BuscarIdNodoLike(texto, 2)
            nodo_anterior = id_nodo
            If id_nodo = "" Then
                MsgBox("No se encontró el item", MsgBoxStyle.Exclamation, "Información")
                txtBuscarNodo5.Text = ""
            Else
                nodo_find = arbol5.Nodes.Find(id_nodo, True)
                arbol5.SelectedNode = nodo_find(0)
                arbol5.SelectedNode.BackColor = Color.GreenYellow
            End If
        End If
    End Sub

    Private Sub FrmInfOT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nd As New Nodo
        Dim nodoRaiz As New TreeNode
        Dim OT As New OT
        Dim cargo As New Cargo
        Dim modo_falla As New ModoFalla
        Dim width As Double = Screen.PrimaryScreen.Bounds.Width
        Dim heigh As Double = Screen.PrimaryScreen.Bounds.Height

        Me.Width = width
        Me.Height = heigh

        nodoRaiz.Name = "1"
        nodoRaiz.Text = "Cambiaso Hnos S.A."
        nd.CRG_NODO_HIJO(nodoRaiz)
        arbol5.Nodes.Add(nodoRaiz)
        modo_falla.crgTipoFalla(cmbTipoTrabajoInfOt)
        cargo.crgTipoInter(cmbTipoDetencion)

        GrpFiltroFechas.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        cmbTipoTrabajoInfOt.Visible = False
        cmbTipoDetencion.Visible = False
        PanPlantas.Visible = False
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
        Dim col As Integer = 0
        Dim formato_grid As New FormatoGrillas
        Dim fecha_comp As Date = "31/12/2011"
        Dim fecha_comp_2 As Date = "01/01/2012"
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
        If opcFechasOt.Checked Then
            'Informe ordenes de trabajo por rango de fechas mas filtros de búsqueda
            '======================================================================================================================================================
            Try
                If id_nodo_select = "" Then
                    MsgBox("Debe seleccionar un item del árbol antes de buscar", MsgBoxStyle.Exclamation, "Validación")
                Else
                    If FormatDateTime(fecha_ini_inf_ot.Value, DateFormat.ShortDate) > fecha_comp Then
                        DST_OT.Tables.Clear()
                        DST_PER.Tables.Clear()

                        If array_plantas(0) > 0 Or array_plantas(1) > 0 Or array_plantas(2) > 0 Then
                            Dim DST_PL_2 As New DataSet
                            Dim DST_PL_4 As New DataSet
                            Dim DST_PL_3 As New DataSet

                            If array_plantas(0) = 2 Then
                                OT.infOt(array_plantas(0).ToString, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_PL_2)
                                OT.infPersonalOt(fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, DST_PER)
                            End If

                            If array_plantas(1) = 4 Then
                                Dim DST_PER_TE As New DataSet

                                OT.infOt(array_plantas(1).ToString, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_PL_4)
                                OT.infPersonalOt(fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, DST_PER_TE)

                                If DST_PER_TE.Tables.Count > 0 Then
                                    If DST_PER_TE.Tables(0).Rows.Count > 0 Then
                                        DST_PER.Merge(DST_PER_TE)
                                    End If
                                End If
                            End If

                            If array_plantas(2) = 3 Then
                                Dim DST_PER_CD As New DataSet

                                OT.infOt(array_plantas(2).ToString, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_PL_3)
                                OT.infPersonalOt(fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, DST_PER_CD)

                                If DST_PER_CD.Tables.Count > 0 Then
                                    If DST_PER_CD.Tables(0).Rows.Count > 0 Then
                                        DST_PER.Merge(DST_PER_CD)
                                    End If
                                End If
                            End If

                            If DST_PL_4.Tables.Count > 0 Then
                                If DST_PL_4.Tables(0).Rows.Count > 0 Then
                                    DST_PL_2.Merge(DST_PL_4)
                                End If
                            End If

                            If DST_PL_3.Tables.Count > 0 Then
                                If DST_PL_3.Tables(0).Rows.Count > 0 Then
                                    DST_PL_2.Merge(DST_PL_3)
                                End If
                            End If

                            If DST_PL_2.Tables.Count > 0 Then
                                If DST_PL_2.Tables(0).Rows.Count > 0 Then
                                    grillaInfOt.DataSource = DST_PL_2.Tables(0)
                                    grillaInfOt.Columns.Add("Personal_1", "Personal_1")
                                    grillaInfOt.Columns.Add("Personal_2", "Personal_2")
                                    grillaInfOt.Columns.Add("Personal_3", "Personal_3")
                                    formato_grid.grillasOT(grillaInfOt)

                                    If DST_PER.Tables.Count > 0 Then
                                        For i = 0 To grillaInfOt.RowCount - 1
                                            For j = 0 To DST_PER.Tables(0).Rows.Count - 1
                                                If grillaInfOt.Rows(i).Cells(0).Value = DST_PER.Tables(0).Rows(j).Item(0).ToString Then
                                                    If col < 3 Then
                                                        grillaInfOt.Rows(i).Cells(col + 12).Value = DST_PER.Tables(0).Rows(j).Item(2).ToString
                                                        col = col + 1
                                                    End If
                                                End If
                                            Next
                                            col = 0
                                        Next
                                    End If
                                Else
                                    MsgBox("No se encontraron registros", MsgBoxStyle.Exclamation, "Validación")
                                End If
                            Else
                                MsgBox("No se encontraron registros", MsgBoxStyle.Exclamation, "Validación")
                            End If

                            DST_PL_2.Dispose()
                            DST_PL_3.Dispose()
                            DST_PL_4.Dispose()
                            DST_PER.Dispose()
                        Else
                            OT.infOt(id_nodo_select, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_OT)
                            OT.infPersonalOt(fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, DST_PER)
                            grillaInfOt.DataSource = DST_OT.Tables(0)

                            grillaInfOt.Columns.Add("Personal_1", "Personal_1")
                            grillaInfOt.Columns.Add("Personal_2", "Personal_2")
                            grillaInfOt.Columns.Add("Personal_3", "Personal_3")
                            formato_grid.grillasOT(grillaInfOt)

                            If DST_PER.Tables.Count > 0 Then
                                For i = 0 To grillaInfOt.RowCount - 1
                                    For j = 0 To DST_PER.Tables(0).Rows.Count - 1
                                        If grillaInfOt.Rows(i).Cells(0).Value = DST_PER.Tables(0).Rows(j).Item(0).ToString Then
                                            If col < 3 Then
                                                grillaInfOt.Rows(i).Cells(col + 12).Value = DST_PER.Tables(0).Rows(j).Item(2).ToString
                                                col = col + 1
                                            End If
                                        End If
                                    Next
                                    col = 0
                                Next
                            End If
                        End If


                    ElseIf FormatDateTime(fecha_ini_inf_ot.Value, DateFormat.ShortDate) < fecha_comp_2 And FormatDateTime(fecha_fin_inf_ot.Value, DateFormat.ShortDate) > fecha_comp Then
                        Dim DST_OT_HIST As New DataSet

                        DST_OT.Tables.Clear()
                        DST_OT_HIST.Tables.Clear()
                        DST_PER.Tables.Clear()

                        OT.infOt(id_nodo_select, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_OT)
                        OT.infOtHistorico(id_nodo_select, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_OT_HIST)

                        If DST_OT_HIST.Tables.Count > 0 Then
                            If DST_OT_HIST.Tables(0).Rows.Count > 0 Then
                                DST_OT.Merge(DST_OT_HIST)
                            End If
                        End If

                        DST_OT.Tables(0).DefaultView.Sort = "Fecha/Hora_Inicio ASC"
                        grillaInfOt.DataSource = DST_OT.Tables(0)
                        grillaInfOt.Columns.Add("Personal_1", "Personal_1")
                        grillaInfOt.Columns.Add("Personal_2", "Personal_2")
                        grillaInfOt.Columns.Add("Personal_3", "Personal_3")
                        formato_grid.grillasOT(grillaInfOt)

                        OT.infPersonalOt(fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, DST_PER)
                        If DST_PER.Tables.Count > 0 Then
                            For i = 0 To grillaInfOt.RowCount - 1
                                For j = 0 To DST_PER.Tables(0).Rows.Count - 1
                                    If grillaInfOt.Rows(i).Cells(0).Value = DST_PER.Tables(0).Rows(j).Item(0).ToString Then
                                        If col < 3 Then
                                            grillaInfOt.Rows(i).Cells(col + 12).Value = DST_PER.Tables(0).Rows(j).Item(2).ToString
                                            col = col + 1
                                        End If
                                    End If
                                Next
                                col = 0
                            Next
                        End If

                    ElseIf FormatDateTime(fecha_fin_inf_ot.Value, DateFormat.ShortDate) <= FormatDateTime("31/12/2011", DateFormat.ShortDate) Then
                        DST_OT.Tables.Clear()
                        OT.infOtHistorico(id_nodo_select, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_OT)
                        DST_PER.Tables.Clear()
                        OT.infPersonalOt(fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, DST_PER)
                        grillaInfOt.DataSource = DST_OT.Tables(0)
                        grillaInfOt.Columns.Add("Personal_1", "Personal_1")
                        grillaInfOt.Columns.Add("Personal_2", "Personal_2")
                        grillaInfOt.Columns.Add("Personal_3", "Personal_3")
                        formato_grid.grillasOT(grillaInfOt)

                        If DST_PER.Tables.Count > 0 Then
                            For i = 0 To grillaInfOt.RowCount - 1
                                For j = 0 To DST_PER.Tables(0).Rows.Count - 1
                                    If grillaInfOt.Rows(i).Cells(0).Value = DST_PER.Tables(0).Rows(j).Item(0).ToString Then
                                        If col < 3 Then
                                            grillaInfOt.Rows(i).Cells(col + 12).Value = DST_PER.Tables(0).Rows(j).Item(2).ToString
                                            col = col + 1
                                        End If
                                    End If
                                Next
                                col = 0
                            Next
                        End If
                    End If

                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
            '======================================================================================================================================================
        Else
            'Informe ordenes de trabajo por numero de orden
            '================================================================================================
            If txtNumOtInfOt.Text = "" Then
                MsgBox("Debe ingresar el N° de OT antes de buscar", MsgBoxStyle.Exclamation, "Validación")
                txtNumOtInfOt.Focus()
            Else
                Try
                    OT.infOt(id_nodo_select, txtNumOtInfOt.Text, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, estado_ot, detencion, opcion, cmbTipoTrabajoInfOt.Text, cmbTipoDetencion.Text, DST_OT)
                    OT.infPersonalOt(fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value, DST_PER)
                    grillaInfOt.DataSource = DST_OT.Tables(0)
                    grillaInfOt.Columns.Add("Personal_1", "Personal_1")
                    grillaInfOt.Columns.Add("Personal_2", "Personal_2")
                    grillaInfOt.Columns.Add("Personal_3", "Personal_3")

                    If DST_PER.Tables.Count > 0 Then
                        For i = 0 To grillaInfOt.RowCount - 1
                            For j = 0 To DST_PER.Tables(0).Rows.Count - 1
                                If grillaInfOt.Rows(i).Cells(0).Value = DST_PER.Tables(0).Rows(j).Item(0).ToString Then
                                    If col < 3 Then
                                        grillaInfOt.Rows(i).Cells(col + 12).Value = DST_PER.Tables(0).Rows(j).Item(2).ToString
                                        col = col + 1
                                    End If
                                End If
                            Next
                            col = 0
                        Next
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                End Try

            End If
            '=================================================================================================
        End If
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

        id_nodo_select = arbol5.SelectedNode.Name
        nodo_anterior2 = id_nodo_select
        arbol5.SelectedNode.BackColor = Color.GreenYellow
    End Sub

    Private Sub btnSalirInfOt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirInfOt.Click
        Me.Close()
    End Sub

    Private Sub btnExcExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcExcel.Click
        Dim OT As New OT
        Dim planta As String = ""

        'Dim report As New InfOt

        'Dim tablaInfOt2 As DataTable = New DataTable
        'Dim grilla2 As DataGridView = New DataGridView


        'Dim ds As New DataSet

        'Try
        '    Dim filaNueva As DataRow
        '    Dim numCols As Integer
        '    numCols = grillaInfOt.ColumnCount
        '    Dim colNueva As DataColumn

        '    ' Replicamos las columnas del DataGridView en el DataTable nuevo
        '    For Each dataGridViewCol As DataGridViewColumn In grillaInfOt.Columns
        '        colNueva = New DataColumn(dataGridViewCol.Name, dataGridViewCol.ValueType)
        '        tablaInfOt2.Columns.Add(colNueva)
        '    Next
        '    ' Rellenamos los valores del DataTable nuevo con los valores de las celdas del DataGridView
        '    For Each filaDatos As DataGridViewRow In grillaInfOt.Rows
        '        filaNueva = tablaInfOt2.NewRow()
        '        For i As Integer = 0 To numCols - 1
        '            filaNueva(i) = filaDatos.Cells(i).Value
        '        Next
        '        tablaInfOt2.Rows.Add(filaNueva)
        '    Next

        'Catch ex As Exception
        '    tablaInfOt2 = New DataTable
        'End Try
        ''grilla2.DataSource = tablaInfOt2
        ''Dim tablaInfOt As DataTable = DirectCast(grilla2.DataSource, DataTable)
        'report.SetDataSource(tablaInfOt2)

        'FrmInfOtCR.CRV_INF_OT.ReportSource = report
        'FrmInfOtCR.Show()
        planta = arbol5.SelectedNode.Text

        If pl_2.Checked Then
            planta = pl_2.Text

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

        Try
            OT.exportarInfOtPDF(grillaInfOt, fecha_ini_inf_ot.Value, fecha_fin_inf_ot.Value)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub txtNumOtInfOt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumOtInfOt.KeyPress
        Dim utilitarios As New Utilitarios

        utilitarios.solonumeros(e)
    End Sub

    Private Sub arbol5_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles arbol5.BeforeSelect
        If nodo_anterior2 <> "" Then
            Dim nodo_finded() As TreeNode = arbol5.Nodes.Find(nodo_anterior2, True)
            arbol5.SelectedNode = nodo_finded(0)
            arbol5.SelectedNode.BackColor = Color.White
        End If
    End Sub

    Private Sub grillaInfOt_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaInfOt.CellContentDoubleClick
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

    Private Sub GrpFiltroInfOt2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GrpFiltroInfOt2.Paint

    End Sub

    Private Sub grillaInfOt_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaInfOt.CellContentClick

    End Sub
End Class