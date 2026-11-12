Public Class FrmResumenes
    Public id_nodo_res_select As String
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Private Sub FrmResumenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nodoRaiz As New TreeNode
        Dim nd As New Nodo
        Dim width As Double = Screen.PrimaryScreen.Bounds.Width
        Dim heigh As Double = Screen.PrimaryScreen.Bounds.Height

        Me.Width = width
        Me.Height = heigh

        nodoRaiz.Name = "1"
        nodoRaiz.Text = "Cambiaso Hnos S.A."
        nd.CRG_NODO_HIJO(nodoRaiz)
        arbol7.Nodes.Add(nodoRaiz)
        grillaOtPorMes.Visible = False
        grpDesglose.Enabled = False
    End Sub

    Private Sub btnBuscarRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarRes.Click
        Dim OT As New OT
        Dim DST_RES_POR As New DataSet
        Dim DST_CERRADA_X_TEC As New DataSet
        Dim DST_OT_X_DIA As New DataSet
        Dim DST_OT_X_MES As New DataSet
        Dim DST_OT_X_TURNO As New DataSet
        Dim DST_OT_X_TIPO_FALLA As New DataSet
        Dim DST_OT_X_ESTADO As New DataSet
        Dim total_ot As Integer = 0


        If id_nodo_res_select = "" Then
            MsgBox("Debe seleccionar un item antes de buscar", MsgBoxStyle.Exclamation, "Validación")
        Else
            OT.infOtResRecibidaPor(id_nodo_res_select, fecha_ini_resumen.Value, fecha_fin_resumen.Value, DST_RES_POR)
            OT.infOtResCerradaPorTecnico(id_nodo_res_select, fecha_ini_resumen.Value, fecha_fin_resumen.Value, DST_CERRADA_X_TEC)
            OT.infOtResPorDia(id_nodo_res_select, fecha_ini_resumen.Value, fecha_fin_resumen.Value, DST_OT_X_DIA)
            OT.infOtResPorMes(id_nodo_res_select, fecha_ini_resumen.Value, fecha_fin_resumen.Value, DST_OT_X_MES)
            OT.infOtResPorTurno(id_nodo_res_select, fecha_ini_resumen.Value, fecha_fin_resumen.Value, DST_OT_X_TURNO)
            OT.infOtPorTipoFalla(id_nodo_res_select, fecha_ini_resumen.Value, fecha_fin_resumen.Value, DST_OT_X_TIPO_FALLA)
            OT.infOtPorEstado(id_nodo_res_select, fecha_ini_resumen.Value, fecha_fin_resumen.Value, DST_OT_X_ESTADO)
            Try
                grillaOtRecibidaPor.DataSource = DST_RES_POR.Tables(0)
                grillaOtRecibidaPor.Columns(1).Width = 50
                grillaOtCerradaPorTec.DataSource = DST_CERRADA_X_TEC.Tables(0)
                grillaOtCerradaPorTec.Columns(1).Width = 50
                grillaOtPorDia.DataSource = DST_OT_X_DIA.Tables(0)
                grillaOtPorDia.Columns(1).Width = 50
                grillaOtPorMes.DataSource = DST_OT_X_MES.Tables(0)
                grillaOtPorMes.Columns(1).Width = 50
                grillaOtPorTurno.DataSource = DST_OT_X_TURNO.Tables(0)
                grillaOtPorTurno.Columns(1).Width = 50
                grillaOtPorTipoFalla.DataSource = DST_OT_X_TIPO_FALLA.Tables(0)
                grillaOtPorTipoFalla.Columns(1).Width = 50
                grillaTotalesPeriodo.DataSource = DST_OT_X_ESTADO.Tables(0)
                grillaTotalesPeriodo.Columns(1).Width = 50
                Label6.Text = "OT Totales Desde " & FormatDateTime(fecha_ini_resumen.Value, DateFormat.ShortDate) & Chr(13) & " Hasta " & FormatDateTime(fecha_fin_resumen.Value, DateFormat.ShortDate)
                grpDesglose.Enabled = True

                '------------------------------------ calculo de total totales por periodo ---------------------------------
                For Each row As DataGridViewRow In grillaTotalesPeriodo.Rows
                    total_ot = total_ot + CInt(row.Cells(1).Value)
                Next

                Dim fila_total As DataRow = DST_OT_X_ESTADO.Tables(0).NewRow
                fila_total.Item(0) = "Total OT"
                fila_total.Item(1) = total_ot
                DST_OT_X_ESTADO.Tables(0).Rows.Add(fila_total)
                grillaTotalesPeriodo.Update()
                grillaTotalesPeriodo.Rows(grillaTotalesPeriodo.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGray
                '-----------------------------------------------------------------------------------------------------------
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
            
        End If
    End Sub

    Private Sub btnSalirRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirRes.Click
        Me.Close()
    End Sub

    Private Sub arbol7_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles arbol7.AfterSelect

        id_nodo_res_select = arbol7.SelectedNode.Name
        nodo_anterior2 = id_nodo_res_select
        arbol7.SelectedNode.BackColor = Color.GreenYellow
    End Sub

    Private Sub txtBuscarNodo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarNodo.KeyUp
        Dim nodo_find() As TreeNode
        Dim nodo As New Nodo
        Dim texto As String = txtBuscarNodo.Text & "%"
        Dim id_nodo As String = ""

        If texto <> "" And texto <> "%" Then
            If nodo_anterior <> "" Then
                nodo.limpiar_arbol(nodo_anterior, arbol7)
            End If

            id_nodo = nodo.BuscarIdNodoLike(texto, 2)
            nodo_anterior = id_nodo
            If id_nodo = "" Then
                MsgBox("No se encontró el item", MsgBoxStyle.Exclamation, "Información")
                txtBuscarNodo.Text = ""
            Else
                nodo_find = arbol7.Nodes.Find(id_nodo, True)
                arbol7.SelectedNode = nodo_find(0)
                arbol7.SelectedNode.BackColor = Color.GreenYellow
            End If
        End If
    End Sub

    Private Sub arbol7_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles arbol7.BeforeSelect
        If nodo_anterior2 <> "" Then
            Dim nodo_finded() As TreeNode = arbol7.Nodes.Find(nodo_anterior2, True)
            arbol7.SelectedNode = nodo_finded(0)
            arbol7.SelectedNode.BackColor = Color.White
        End If
    End Sub

    Private Sub btn_exp_excel_res_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exp_excel_res.Click
        Dim informe As New Informes

        Try
            informe.expInfEstadistica(fecha_ini_resumen.Value, fecha_fin_resumen.Value)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grillaOtRecibidaPor_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaOtRecibidaPor.CellContentDoubleClick
        If grillaOtRecibidaPor.RowCount = 0 Then
            MsgBox("Debe buscar datos antes de ver el detalle", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Try
            FrmDetalleOtPendientes.personal = grillaOtRecibidaPor.Rows(grillaOtRecibidaPor.CurrentRow.Index).Cells(0).Value
            FrmDetalleOtPendientes.fecha_inicio = fecha_ini_resumen.Value
            FrmDetalleOtPendientes.fecha_termino = fecha_fin_resumen.Value
            FrmDetalleOtPendientes.opcion = 1
            FrmDetalleOtPendientes.nodo_padre = id_nodo_res_select
            FrmDetalleOtPendientes.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
       
    End Sub

    Private Sub opc_totales_estado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opc_totales_estado.CheckedChanged
        If opc_totales_estado.Checked Then
            grillaTotalesPeriodo.Visible = True
            grillaOtPorMes.Visible = False
            If grillaTotalesPeriodo.RowCount > 0 Then
                Label6.Text = "OT Totales Desde " & FormatDateTime(fecha_ini_resumen.Value, DateFormat.ShortDate) & Chr(13) & " Hasta " & FormatDateTime(fecha_fin_resumen.Value, DateFormat.ShortDate)
            End If
        Else
            grillaTotalesPeriodo.Visible = False
            grillaOtPorMes.Visible = True
            Label6.Text = "OT Desglosadas Por Mes"
        End If
    End Sub

    Private Sub grillaOtCerradaPorTec_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaOtCerradaPorTec.CellContentDoubleClick
        If grillaOtCerradaPorTec.RowCount = 0 Then
            MsgBox("Debe buscar datos antes de ver el detalle", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Try
            FrmDetalleOTPorTecnico.personal = grillaOtCerradaPorTec.Rows(grillaOtCerradaPorTec.CurrentRow.Index).Cells(0).Value
            FrmDetalleOTPorTecnico.fecha_inicio = fecha_ini_resumen.Value
            FrmDetalleOTPorTecnico.fecha_termino = fecha_fin_resumen.Value
            FrmDetalleOTPorTecnico.opcion = 2
            FrmDetalleOTPorTecnico.nodo_padre = id_nodo_res_select
            FrmDetalleOTPorTecnico.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grillaOtPorTipoFalla_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaOtPorTipoFalla.CellContentDoubleClick
        If grillaOtPorTipoFalla.RowCount = 0 Then
            MsgBox("Debe buscar datos antes de ver el detalle", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Try
            FrmDetalleOtTipoFalla.tipo_falla = grillaOtPorTipoFalla.Rows(grillaOtPorTipoFalla.CurrentRow.Index).Cells(0).Value
            FrmDetalleOtTipoFalla.fecha_inicio = fecha_ini_resumen.Value
            FrmDetalleOtTipoFalla.fecha_termino = fecha_fin_resumen.Value
            FrmDetalleOtTipoFalla.opcion = 3
            FrmDetalleOtTipoFalla.nodo_padre = id_nodo_res_select
            FrmDetalleOtTipoFalla.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grillaOtPorTurno_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaOtPorTurno.CellContentDoubleClick
        If grillaOtPorTurno.RowCount = 0 Then
            MsgBox("Debe buscar datos antes de ver el detalle", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Try
            FrmDetalleOtTurno.turno = grillaOtPorTurno.Rows(grillaOtPorTurno.CurrentRow.Index).Cells(0).Value
            FrmDetalleOtTurno.fecha_inicio = fecha_ini_resumen.Value
            FrmDetalleOtTurno.fecha_termino = fecha_fin_resumen.Value
            FrmDetalleOtTurno.opcion = 4
            FrmDetalleOtTurno.nodo_padre = id_nodo_res_select
            FrmDetalleOtTurno.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grillaOtPorDia_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaOtPorDia.CellContentDoubleClick
        If grillaOtPorDia.RowCount = 0 Then
            MsgBox("Debe buscar datos antes de ver el detalle", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Try
            FrmDetalleOTDia.fecha_inicio = fecha_ini_resumen.Value
            FrmDetalleOTDia.fecha_termino = fecha_fin_resumen.Value
            FrmDetalleOTDia.fecha = grillaOtPorDia.Rows(grillaOtPorDia.CurrentRow.Index).Cells(0).Value
            FrmDetalleOTDia.opcion = 5
            FrmDetalleOTDia.nodo_padre = id_nodo_res_select
            FrmDetalleOTDia.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grillaTotalesPeriodo_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaTotalesPeriodo.CellContentDoubleClick
        If grillaTotalesPeriodo.RowCount = 0 Then
            MsgBox("Debe buscar datos antes de ver el detalle", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Try
            If grillaTotalesPeriodo.Rows(grillaTotalesPeriodo.CurrentRow.Index).Cells(0).Value <> "Total OT" Then
                FrmDetalleOtEstado.fecha_inicio = fecha_ini_resumen.Value
                FrmDetalleOtEstado.fecha_termino = fecha_fin_resumen.Value
                FrmDetalleOtEstado.estado = grillaTotalesPeriodo.Rows(grillaTotalesPeriodo.CurrentRow.Index).Cells(0).Value
                FrmDetalleOtEstado.opcion = 6
                FrmDetalleOtEstado.nodo_padre = id_nodo_res_select
                FrmDetalleOtEstado.Show()
            End If
            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grillaOtRecibidaPor_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaOtRecibidaPor.CellContentClick

    End Sub

    Private Sub grillaOtCerradaPorTec_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaOtCerradaPorTec.CellContentClick

    End Sub
End Class