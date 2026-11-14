Imports System.Data.SqlClient
Public Class frm_OT
    Dim utilitario As New Utilitarios
    Public id_nodo_ot_select As String
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Public DST_ARBOL As New DataSet
    Public DSPOT As New DataSet
    Public DSIOT As New DataSet
    Public DSOEXOT As New DataSet
    Public form_limpio As Boolean = False
    Public ot_cargada_actual As String = ""

    Private Function CeldaStr(ByVal row As DataGridViewRow, ByVal colIndex As Integer) As String
        If row Is Nothing OrElse colIndex < 0 OrElse colIndex >= row.Cells.Count Then Return ""
        Dim val = row.Cells(colIndex).Value
        If val Is Nothing OrElse IsDBNull(val) Then Return ""
        Return val.ToString().Trim()
    End Function

    Private Sub frm_OT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Dim mantPrev As New MantPreventiva
            Dim nd As New Nodo
            Dim nodoRaiz As New TreeNode
            Dim Cargo As New Cargo
            Dim OT As New OT
            Dim falla As New ModoFalla
            Dim sintoma As New Sintoma

            Cargo.crgTipoInter(cmb_Tipo_Det)
            sintoma.crgCmbSintoma(cmbSintoma)
            nodoRaiz.Name = "1"
            nodoRaiz.Text = "Cambiaso Hnos S.A."
            nd.CRG_NODO_HIJO(nodoRaiz)
            arbol3.BeginUpdate()
            arbol3.Nodes.Clear()
            arbol3.Nodes.Add(nodoRaiz)
            arbol3.EndUpdate()
            OT.CrgCmbDetencion(cmb_det)
            OT.autocompletar_personal(txtRecibidoPor, txtSolicitadoPor, txtCerradoPor)
            falla.crgTipoFalla(cmb_Tipo_trab)
            falla.crgModoFalla(cmbFalla)
            PanFechaCierreOt.Enabled = False
            cmbEstadoOt.Text = cmbEstadoOt.Items(0)
            cmbEstadoOt.Enabled = False
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim existe_ot As String = ""
        Dim OT As New OT
        Dim respuesta As String = ""
        Dim resp_ot_abierta As String = ""
        Dim estado_ot As String = ""
        Dim mant_interna As Boolean = False

        If chkOtCierre.Checked Then

            respuesta = OT.validarOtCerrada
            If respuesta = "" Then
                existe_ot = OT.BuscarNumOt(txtNot.Text)
                If existe_ot = "" Then

                    If cmbEstadoOt.Text = "CERRADA" Then
                        estado_ot = "cerrada"
                    ElseIf cmbEstadoOt.Text = "NULA" Then
                        estado_ot = "nula"
                    ElseIf cmbEstadoOt.Text = "ABIERTA" And txtDuracionOt.Text = "" And txtCerradoPor.Text = "" Then
                        MsgBox("Debe Seleccionar la opcion 'OT CERRADA',si no desea cerrar la OT Presione Limpiar", MsgBoxStyle.Exclamation, "Validación")
                        Exit Sub
                    End If

                    If chkOtMpInterna.Checked Then
                        mant_interna = True
                    End If

                    OT.IngOtCerrada(txtNot.Text, id_nodo_ot_select, cmbSintoma.SelectedValue, cmbFalla.SelectedValue, dt_fecha_rec.Value, dt_hr_rec.Value, dt_fecha_ini.Value, dt_hr_ini.Value, dt_fecha_ter.Value, dt_hr_ter.Value, dt_fecha_cierre.Value, dt_hr_cierre.Value, txtDuracionOt.Text, cmb_Tipo_Det.SelectedValue, cmb_det.Text, text_des_falla.Text, txtDescTrab.Text, txtSolicitadoPor.Text, txtRecibidoPor.Text, txtCerradoPor.Text, cmb_Tipo_trab.SelectedValue, principal.lblUsuario.Text, estado_ot, mant_interna, cod_resp, resp)
                    If grillaPersonalOt.RowCount > 0 Then
                        For i = 0 To grillaPersonalOt.RowCount - 1
                            OT.IngPersonalOt(grillaPersonalOt.Rows(i).Cells(0).Value, txtNot.Text, CeldaStr(grillaPersonalOt.Rows(i), 2))
                        Next
                    End If

                    If grillaInsumosOt.RowCount > 0 Then
                        For i = 0 To grillaInsumosOt.RowCount - 1
                            Dim codIns As String = CeldaStr(grillaInsumosOt.Rows(i), 0)
                            If Not String.IsNullOrEmpty(codIns) Then
                                OT.IngInsumosOt(txtNot.Text, codIns, CeldaStr(grillaInsumosOt.Rows(i), 3), CeldaStr(grillaInsumosOt.Rows(i), 4))
                            End If
                        Next
                    End If

                    If grillaOtExternas.RowCount > 0 Then
                        For i = 0 To grillaOtExternas.RowCount - 1
                            Dim codExt As String = CeldaStr(grillaOtExternas.Rows(i), 0)
                            If Not String.IsNullOrEmpty(codExt) Then
                                OT.IngOtExterna(txtNot.Text, codExt, CeldaStr(grillaOtExternas.Rows(i), 1))
                            End If
                        Next
                    End If

                    If cod_resp = 1 Then
                        MsgBox(resp, MsgBoxStyle.Information, "Validación")
                        OT.LimpiarFrmOt()
                    Else
                        MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                    End If
                Else

                    If cmbEstadoOt.Text = "CERRADA" Then
                        estado_ot = "cerrada"

                    ElseIf cmbEstadoOt.Text = "NULA" Then
                        If MsgBox("¿Esta seguro de anular la OT " & txtNot.Text & " ?", MsgBoxStyle.YesNo, "Anular Orden De Trabajo") = MsgBoxResult.Yes Then
                            estado_ot = "nula"
                        Else
                            Exit Sub
                        End If

                    ElseIf cmbEstadoOt.Text = "ABIERTA" And txtDuracionOt.Text = "" And txtCerradoPor.Text = "" Then
                        MsgBox("Opcion Inválida, debe ser OT CERRADA O OT NULA", MsgBoxStyle.Exclamation, "Validación")
                        Exit Sub
                    End If

                    If chkOtMpInterna.Checked Then
                        mant_interna = True
                    End If

                    OT.UpdOtCerrada(txtNot.Text, id_nodo_ot_select, cmbSintoma.SelectedValue, cmbFalla.SelectedValue, dt_fecha_rec.Value, dt_hr_rec.Value, dt_fecha_ini.Value, dt_hr_ini.Value, dt_fecha_ter.Value, dt_hr_ter.Value, dt_fecha_cierre.Value, dt_hr_cierre.Value, txtDuracionOt.Text, cmb_Tipo_Det.SelectedValue, cmb_det.Text, text_des_falla.Text, txtDescTrab.Text, txtSolicitadoPor.Text, txtRecibidoPor.Text, txtCerradoPor.Text, cmb_Tipo_trab.SelectedValue, principal.lblUsuario.Text, estado_ot, mant_interna, cod_resp, resp)

                    If grillaPersonalOt.RowCount > 0 Then
                        For i = 0 To grillaPersonalOt.RowCount - 1
                            OT.UpdPersonalOt(txtNot.Text, grillaPersonalOt.Rows(i).Cells(0).Value, CeldaStr(grillaPersonalOt.Rows(i), 2))
                        Next
                    End If

                    If grillaInsumosOt.RowCount > 0 Then
                        For i = 0 To grillaInsumosOt.RowCount - 1
                            Dim codIns As String = CeldaStr(grillaInsumosOt.Rows(i), 0)
                            If Not String.IsNullOrEmpty(codIns) Then
                                OT.UpdInsumosOt(txtNot.Text, codIns, CeldaStr(grillaInsumosOt.Rows(i), 3), CeldaStr(grillaInsumosOt.Rows(i), 4))
                            End If
                        Next
                    End If

                    If grillaOtExternas.RowCount > 0 Then
                        For i = 0 To grillaOtExternas.RowCount - 1
                            Dim codExt As String = CeldaStr(grillaOtExternas.Rows(i), 0)
                            If Not String.IsNullOrEmpty(codExt) Then
                                OT.UpdOtExterna(txtNot.Text, codExt, CeldaStr(grillaOtExternas.Rows(i), 1))
                            End If
                        Next
                    End If

                    If cod_resp = 1 Then
                        MsgBox(resp, MsgBoxStyle.Information, "Validación")
                        OT.LimpiarFrmOt()
                    Else
                        MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                    End If
                End If
            Else
                MsgBox(respuesta, MsgBoxStyle.Exclamation, "Validación")
            End If
        Else

            resp_ot_abierta = OT.validarOtAbierta
            If resp_ot_abierta = "" Then
                existe_ot = OT.BuscarNumOt(txtNot.Text)
                If existe_ot = "" Then

                    If chkOtMpInterna.Checked Then
                        mant_interna = True
                    End If

                    OT.IngOtAbierta(txtNot.Text, id_nodo_ot_select, cmbSintoma.SelectedValue, cmbFalla.SelectedValue, dt_fecha_rec.Value, dt_hr_rec.Value, dt_fecha_ini.Value, dt_hr_ini.Value, cmb_Tipo_Det.SelectedValue, cmb_det.Text, text_des_falla.Text, txtSolicitadoPor.Text, txtRecibidoPor.Text, cmb_Tipo_trab.SelectedValue, principal.lblUsuario.Text, txtDescTrab.Text, mant_interna, cod_resp, resp)

                    If grillaPersonalOt.RowCount > 0 Then
                        For i = 0 To grillaPersonalOt.RowCount - 1
                            OT.IngPersonalOt(grillaPersonalOt.Rows(i).Cells(0).Value, txtNot.Text, CeldaStr(grillaPersonalOt.Rows(i), 2))
                        Next
                    End If

                    If grillaInsumosOt.RowCount > 0 Then
                        For i = 0 To grillaInsumosOt.RowCount - 1
                            Dim codIns As String = CeldaStr(grillaInsumosOt.Rows(i), 0)
                            If Not String.IsNullOrEmpty(codIns) Then
                                OT.IngInsumosOt(txtNot.Text, codIns, CeldaStr(grillaInsumosOt.Rows(i), 3), CeldaStr(grillaInsumosOt.Rows(i), 4))
                            End If
                        Next
                    End If

                    If grillaOtExternas.RowCount > 0 Then
                        For i = 0 To grillaOtExternas.RowCount - 1
                            Dim codExt As String = CeldaStr(grillaOtExternas.Rows(i), 0)
                            If Not String.IsNullOrEmpty(codExt) Then
                                OT.IngOtExterna(txtNot.Text, codExt, CeldaStr(grillaOtExternas.Rows(i), 1))
                            End If
                        Next
                    End If

                    If cod_resp = 1 Then
                        MsgBox(resp, MsgBoxStyle.Information, "Validación")
                        OT.LimpiarFrmOt()
                    Else
                        MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                    End If
                Else
                    If chkOtMpInterna.Checked Then
                        mant_interna = True
                    End If

                    OT.UpdOtAbierta(txtNot.Text, id_nodo_ot_select, cmbSintoma.SelectedValue, cmbFalla.SelectedValue, dt_fecha_rec.Value, dt_hr_rec.Value, dt_fecha_ini.Value, dt_hr_ini.Value, cmb_Tipo_Det.SelectedValue, cmb_det.Text, text_des_falla.Text, txtSolicitadoPor.Text, txtRecibidoPor.Text, cmb_Tipo_trab.SelectedValue, principal.lblUsuario.Text, mant_interna, txtDescTrab.Text, cod_resp, resp)

                    If grillaPersonalOt.RowCount > 0 Then
                        For i = 0 To grillaPersonalOt.RowCount - 1
                            OT.UpdPersonalOt(txtNot.Text, grillaPersonalOt.Rows(i).Cells(0).Value, CeldaStr(grillaPersonalOt.Rows(i), 2))
                        Next
                    End If

                    If grillaInsumosOt.RowCount > 0 Then
                        For i = 0 To grillaInsumosOt.RowCount - 1
                            Dim codIns As String = CeldaStr(grillaInsumosOt.Rows(i), 0)
                            If Not String.IsNullOrEmpty(codIns) Then
                                OT.UpdInsumosOt(txtNot.Text, codIns, CeldaStr(grillaInsumosOt.Rows(i), 3), CeldaStr(grillaInsumosOt.Rows(i), 4))
                            End If
                        Next
                    End If

                    If grillaOtExternas.RowCount > 0 Then
                        For i = 0 To grillaOtExternas.RowCount - 1
                            Dim codExt As String = CeldaStr(grillaOtExternas.Rows(i), 0)
                            If Not String.IsNullOrEmpty(codExt) Then
                                OT.UpdOtExterna(txtNot.Text, codExt, CeldaStr(grillaOtExternas.Rows(i), 1))
                            End If
                        Next
                    End If

                    If cod_resp = 1 Then
                        MsgBox(resp, MsgBoxStyle.Information, "Validación")
                        OT.LimpiarFrmOt()
                    Else
                        MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                    End If
                End If
            Else
                MsgBox(resp_ot_abierta, MsgBoxStyle.Exclamation, "Validación")
            End If
        End If
    End Sub

    Private Sub dt_hr_rec_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_hr_rec.ValueChanged
        tipo_turno()
        dt_hr_ini.Value = dt_hr_rec.Value
    End Sub

    Private Sub tipo_turno()
        Dim totalMinutos As Integer = dt_hr_rec.Value.Hour * 60 + dt_hr_rec.Value.Minute
        If totalMinutos >= 15 * 60 Then
            text_turno.Text = "TT"
        ElseIf totalMinutos >= 7 * 60 + 30 Then
            text_turno.Text = "TM"
        Else
            text_turno.Text = "TN"
        End If
    End Sub

    Private Sub CalcularDuracionOt()
        Dim f_inicio As DateTime = dt_fecha_ini.Value.Date.Add(New TimeSpan(dt_hr_ini.Value.Hour, dt_hr_ini.Value.Minute, 0))
        Dim f_termino As DateTime = dt_fecha_ter.Value.Date.Add(New TimeSpan(dt_hr_ter.Value.Hour, dt_hr_ter.Value.Minute, 0))
        txtDuracionOt.Text = FormatNumber(DateDiff(DateInterval.Minute, f_inicio, f_termino) / 60, 1)
    End Sub

    Private Sub text_not_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNot.KeyPress
        utilitario.solonumeros(e)
    End Sub

    Private Sub text_prio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        utilitario.solonumeros(e)
    End Sub

    Private Sub btn_limpiar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim OT As New OT
        OT.LimpiarFrmOt()
    End Sub

    Private Sub btn_salir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub arbol3_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles arbol3.AfterSelect
        If arbol3.SelectedNode Is Nothing Then Exit Sub
        id_nodo_ot_select = arbol3.SelectedNode.Name
        nodo_anterior2 = id_nodo_ot_select
        arbol3.SelectedNode.BackColor = Utilitarios.ColorSeleccion
    End Sub

    Private Sub txtBuscarNodo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarNodo.KeyUp
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(arbol3, txtBuscarNodo, e, id_nodo_ot_select, nodo_anterior, 2)
    End Sub

    Private Sub txtBuscarNodo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarNodo.TextChanged
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(arbol3, txtBuscarNodo, Nothing, id_nodo_ot_select, nodo_anterior, 2)
    End Sub

    Private Sub chkOtCierre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOtCierre.CheckedChanged
        If chkOtCierre.Checked Then
            PanFechaCierreOt.Enabled = True
            Dim OT As New OT
            OT.autocompletar_personal(txtCerradoPor)
            cmbEstadoOt.Enabled = True
            cmbEstadoOt.Text = cmbEstadoOt.Items(1)
        Else
            PanFechaCierreOt.Enabled = False
        End If
    End Sub

    Private Sub dt_hr_ter_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_hr_ter.ValueChanged
        CalcularDuracionOt()
        dt_hr_cierre.Value = dt_hr_ter.Value
    End Sub

    Private Sub btnAgrfilaOt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgrfilaOt.Click
        Try
            Select Case TabOt.SelectedTab.Text

                Case "Insumos, Repuestos"
                    Try
                        grillaInsumosOt.Rows.Add()
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    End Try

                Case "OT Externas"
                    Try
                        If DSOEXOT.Tables.Count > 0 Then
                            Dim fila As DataRow = DSOEXOT.Tables(0).NewRow
                            DSOEXOT.Tables(0).Rows.Add(fila)
                        Else
                            grillaOtExternas.Rows.Add()
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    End Try

            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub grillaPersonalOt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grillaPersonalOt.KeyDown
        If grillaPersonalOt.CurrentCell IsNot Nothing AndAlso grillaPersonalOt.CurrentCell.ColumnIndex = 1 Then
            If e.KeyCode = Keys.Enter Then
                FrmBuscarPersonal.nombre_form = "frm_OT"
                FrmBuscarPersonal.Show()
            End If
        End If
    End Sub

    Private Sub txtNot_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNot.LostFocus
        If principal.CambiandoAmbiente OrElse Not Me.Visible OrElse Me.Disposing Then Exit Sub
        If btn_salir.Focused OrElse btn_limpiar.Focused Then Exit Sub

        Dim numOtActual As String = txtNot.Text.Trim()
        If numOtActual = "" Then
            ot_cargada_actual = ""
            Exit Sub
        End If

        If String.Equals(numOtActual, ot_cargada_actual, StringComparison.OrdinalIgnoreCase) Then
            Exit Sub
        End If

        If txtNot.Text <> "" Then
            Dim OT As New OT
            Dim resp_num_ot As String = ""
            Dim DST_OT As New DataSet
            Dim id_nodo As String = ""
            Dim fecha_inicio As DateTime

            resp_num_ot = OT.BuscarNumOt(txtNot.Text)
            If resp_num_ot <> "" Then
                If (MsgBox(resp_num_ot & Chr(13) & "¿ Desea Modificarla ?", MsgBoxStyle.YesNo, "Validacion")) = MsgBoxResult.Yes Then
                    If DSIOT.Tables.Count > 0 Then
                        DSIOT.Tables.Clear()
                    End If

                    If DSPOT.Tables.Count > 0 Then
                        DSPOT.Tables.Clear()
                    End If

                    If DSOEXOT.Tables.Count > 0 Then
                        DSOEXOT.Tables.Clear()
                    End If

                    OT.CrgOrdenTrabajo(txtNot.Text, DST_OT)
                    If DST_OT.Tables.Count = 0 OrElse DST_OT.Tables(0).Rows.Count = 0 Then Exit Sub
                    OT.LimpiarFrmOt()

                    ' Conversión segura de fecha_inicio para evitar caídas si el registro contiene valores nulos
                    fecha_inicio = DateTime.Today
                    If Not IsDBNull(DST_OT.Tables(0).Rows(0).Item(8)) Then
                        DateTime.TryParse(DST_OT.Tables(0).Rows(0).Item(8).ToString(), fecha_inicio)
                    End If

                    If DST_OT.Tables(0).Rows(0).Item(17).ToString = "abierta" Then
                        txtNot.Text = DST_OT.Tables(0).Rows(0).Item(0).ToString
                        cmb_Tipo_Det.Text = DST_OT.Tables(0).Rows(0).Item(5).ToString
                        cmbSintoma.Text = DST_OT.Tables(0).Rows(0).Item(3).ToString
                        cmbFalla.Text = DST_OT.Tables(0).Rows(0).Item(4).ToString
                        ' Asignaciones seguras a DateTimePicker para evitar NullReferenceException
                        Utilitarios.AsignarFechaSegura(dt_fecha_rec, DST_OT.Tables(0).Rows(0).Item(6), DateTime.Today)
                        Utilitarios.AsignarFechaSegura(dt_hr_rec, DST_OT.Tables(0).Rows(0).Item(7), DateTime.Now)
                        Utilitarios.AsignarFechaSegura(dt_fecha_ini, DST_OT.Tables(0).Rows(0).Item(8), DateTime.Today)
                        Utilitarios.AsignarFechaSegura(dt_hr_ini, DST_OT.Tables(0).Rows(0).Item(9), DateTime.Now)
                        cmb_det.Text = DST_OT.Tables(0).Rows(0).Item(14).ToString
                        text_des_falla.Text = DST_OT.Tables(0).Rows(0).Item(15).ToString
                        cmb_Tipo_trab.Text = DST_OT.Tables(0).Rows(0).Item(2).ToString
                        txtRecibidoPor.Text = DST_OT.Tables(0).Rows(0).Item(19).ToString
                        txtSolicitadoPor.Text = DST_OT.Tables(0).Rows(0).Item(20).ToString
                        chkOtMpInterna.Checked = (DST_OT.Tables(0).Rows(0).Item(22).ToString().ToLower() = "true" OrElse DST_OT.Tables(0).Rows(0).Item(22).ToString() = "1")
                        txtDescTrab.Text = DST_OT.Tables(0).Rows(0).Item(16).ToString
                        id_nodo = DST_OT.Tables(0).Rows(0).Item(1).ToString
                        Nodo.SeleccionarNodoPorId(arbol3, id_nodo, id_nodo_ot_select)
                        cmbEstadoOt.Text = cmbEstadoOt.Items(0)

                        Dim formato_grid As New FormatoGrillas

                        If DSPOT.Tables.Count = 0 Then
                            grillaPersonalOt.Columns.Clear()

                            OT.CrgPersonalOt(txtNot.Text, DSPOT)
                            grillaPersonalOt.DataSource = DSPOT.Tables(0)
                            formato_grid.grillasOT(grillaPersonalOt)
                        End If

                    ElseIf DST_OT.Tables(0).Rows(0).Item(17).ToString = "cerrada" Then
                        chkOtCierre.Checked = True
                        chkOtCierre.Enabled = False
                        cmbEstadoOt.Enabled = True

                        If fecha_inicio < New DateTime(2012, 1, 1) Then
                            MsgBox("La orden esta en modo de solo lectura " & Chr(13) & "pertenece al histórico y no puede ser modificada", MsgBoxStyle.Information, "Validación")
                            btn_guardar.Enabled = False
                            btn_eliminar.Enabled = False
                        End If
                        txtNot.Text = DST_OT.Tables(0).Rows(0).Item(0).ToString
                        cmb_Tipo_Det.Text = DST_OT.Tables(0).Rows(0).Item(5).ToString
                        cmbSintoma.Text = DST_OT.Tables(0).Rows(0).Item(3).ToString
                        cmbFalla.Text = DST_OT.Tables(0).Rows(0).Item(4).ToString
                        ' Asignaciones seguras a DateTimePicker para evitar NullReferenceException
                        Utilitarios.AsignarFechaSegura(dt_fecha_rec, DST_OT.Tables(0).Rows(0).Item(6), DateTime.Today)
                        Utilitarios.AsignarFechaSegura(dt_hr_rec, DST_OT.Tables(0).Rows(0).Item(7), DateTime.Now)
                        Utilitarios.AsignarFechaSegura(dt_fecha_ini, DST_OT.Tables(0).Rows(0).Item(8), DateTime.Today)
                        Utilitarios.AsignarFechaSegura(dt_hr_ini, DST_OT.Tables(0).Rows(0).Item(9), DateTime.Now)
                        cmb_det.Text = DST_OT.Tables(0).Rows(0).Item(14).ToString
                        text_des_falla.Text = DST_OT.Tables(0).Rows(0).Item(15).ToString
                        cmb_Tipo_trab.Text = DST_OT.Tables(0).Rows(0).Item(2).ToString
                        txtRecibidoPor.Text = DST_OT.Tables(0).Rows(0).Item(19).ToString
                        txtSolicitadoPor.Text = DST_OT.Tables(0).Rows(0).Item(20).ToString
                        cmbEstadoOt.Text = cmbEstadoOt.Items(1)
                        chkOtMpInterna.Checked = (DST_OT.Tables(0).Rows(0).Item(22).ToString().ToLower() = "true" OrElse DST_OT.Tables(0).Rows(0).Item(22).ToString() = "1")

                        ' Fechas y horas de término y cierre con protección contra nulos (previene el error en línea 461)
                        Utilitarios.AsignarFechaSegura(dt_fecha_ter, DST_OT.Tables(0).Rows(0).Item(10), dt_fecha_ini.Value)
                        Utilitarios.AsignarFechaSegura(dt_hr_ter, DST_OT.Tables(0).Rows(0).Item(11), dt_hr_ini.Value)
                        txtDuracionOt.Text = DST_OT.Tables(0).Rows(0).Item(18).ToString
                        Utilitarios.AsignarFechaSegura(dt_fecha_cierre, DST_OT.Tables(0).Rows(0).Item(12), dt_fecha_ter.Value)
                        Utilitarios.AsignarFechaSegura(dt_hr_cierre, DST_OT.Tables(0).Rows(0).Item(13), dt_hr_ter.Value)
                        txtCerradoPor.Text = DST_OT.Tables(0).Rows(0).Item(21).ToString
                        txtDescTrab.Text = DST_OT.Tables(0).Rows(0).Item(16).ToString

                        id_nodo = DST_OT.Tables(0).Rows(0).Item(1).ToString
                        Nodo.SeleccionarNodoPorId(arbol3, id_nodo, id_nodo_ot_select)

                        Dim formato_grid As New FormatoGrillas

                        If DSPOT.Tables.Count = 0 Then
                            grillaPersonalOt.Columns.Clear()

                            OT.CrgPersonalOt(txtNot.Text, DSPOT)
                            grillaPersonalOt.DataSource = DSPOT.Tables(0)
                            formato_grid.grillasOT(grillaPersonalOt)
                        End If

                        If DSIOT.Tables.Count = 0 Then
                            OT.CrgInsumosOt(txtNot.Text, DSIOT)
                            If DSIOT.Tables(0).Rows.Count > 0 Then
                                Dim j As Integer = 0
                                For i = 0 To DSIOT.Tables(0).Rows.Count - 1
                                    grillaInsumosOt.Rows.Add()
                                    grillaInsumosOt.Rows(j).Cells(0).Value = DSIOT.Tables(0).Rows(i).Item(0).ToString
                                    grillaInsumosOt.Rows(j).Cells(1).Value = DSIOT.Tables(0).Rows(i).Item(1).ToString
                                    grillaInsumosOt.Rows(j).Cells(2).Value = DSIOT.Tables(0).Rows(i).Item(2).ToString
                                    grillaInsumosOt.Rows(j).Cells(3).Value = DSIOT.Tables(0).Rows(i).Item(3).ToString
                                    grillaInsumosOt.Rows(j).Cells(4).Value = DSIOT.Tables(0).Rows(i).Item(4).ToString
                                    grillaInsumosOt.Rows(j).Cells(5).Value = DSIOT.Tables(0).Rows(i).Item(5).ToString
                                    j = j + 1
                                Next
                            End If
                            formato_grid.grillasOT(grillaInsumosOt)
                        End If

                        If DSOEXOT.Tables.Count = 0 Then
                            OT.CrgOtExterna(txtNot.Text, DSOEXOT)
                            grillaOtExternas.Columns.Clear()
                            grillaOtExternas.DataSource = DSOEXOT.Tables(0)
                            formato_grid.grillasOT(grillaOtExternas)
                        End If
                    ElseIf DST_OT.Tables(0).Rows(0).Item(17).ToString = "nula" Then
                        cmbEstadoOt.Enabled = True
                        chkOtCierre.Enabled = True
                        chkOtCierre.Checked = True

                        If fecha_inicio < New DateTime(2012, 1, 1) Then
                            MsgBox("La orden esta en modo de solo lectura " & Chr(13) & "pertenece al histórico y no puede ser modificada", MsgBoxStyle.Information, "Validación")
                            btn_guardar.Enabled = False
                            btn_eliminar.Enabled = False
                        End If

                        txtNot.Text = DST_OT.Tables(0).Rows(0).Item(0).ToString
                        cmb_Tipo_Det.Text = DST_OT.Tables(0).Rows(0).Item(5).ToString
                        cmbSintoma.Text = DST_OT.Tables(0).Rows(0).Item(3).ToString
                        cmbFalla.Text = DST_OT.Tables(0).Rows(0).Item(4).ToString
                        ' Asignaciones seguras a DateTimePicker para evitar NullReferenceException
                        Utilitarios.AsignarFechaSegura(dt_fecha_rec, DST_OT.Tables(0).Rows(0).Item(6), DateTime.Today)
                        Utilitarios.AsignarFechaSegura(dt_hr_rec, DST_OT.Tables(0).Rows(0).Item(7), DateTime.Now)
                        Utilitarios.AsignarFechaSegura(dt_fecha_ini, DST_OT.Tables(0).Rows(0).Item(8), DateTime.Today)
                        Utilitarios.AsignarFechaSegura(dt_hr_ini, DST_OT.Tables(0).Rows(0).Item(9), DateTime.Now)
                        cmb_det.Text = DST_OT.Tables(0).Rows(0).Item(14).ToString
                        text_des_falla.Text = DST_OT.Tables(0).Rows(0).Item(15).ToString
                        cmb_Tipo_trab.Text = DST_OT.Tables(0).Rows(0).Item(2).ToString
                        txtRecibidoPor.Text = DST_OT.Tables(0).Rows(0).Item(19).ToString
                        txtSolicitadoPor.Text = DST_OT.Tables(0).Rows(0).Item(20).ToString
                        cmbEstadoOt.Text = cmbEstadoOt.Items(2)
                        chkOtMpInterna.Checked = (DST_OT.Tables(0).Rows(0).Item(22).ToString().ToLower() = "true" OrElse DST_OT.Tables(0).Rows(0).Item(22).ToString() = "1")

                        ' Fechas y horas de término y cierre seguras
                        Utilitarios.AsignarFechaSegura(dt_fecha_ter, DST_OT.Tables(0).Rows(0).Item(10), dt_fecha_ini.Value)
                        Utilitarios.AsignarFechaSegura(dt_hr_ter, DST_OT.Tables(0).Rows(0).Item(11), dt_hr_ini.Value)
                        txtDuracionOt.Text = DST_OT.Tables(0).Rows(0).Item(18).ToString
                        Utilitarios.AsignarFechaSegura(dt_fecha_cierre, DST_OT.Tables(0).Rows(0).Item(12), dt_fecha_ter.Value)
                        Utilitarios.AsignarFechaSegura(dt_hr_cierre, DST_OT.Tables(0).Rows(0).Item(13), dt_hr_ter.Value)
                        txtCerradoPor.Text = DST_OT.Tables(0).Rows(0).Item(21).ToString
                        txtDescTrab.Text = DST_OT.Tables(0).Rows(0).Item(16).ToString

                        id_nodo = DST_OT.Tables(0).Rows(0).Item(1).ToString
                        Nodo.SeleccionarNodoPorId(arbol3, id_nodo, id_nodo_ot_select)

                        Dim formato_grid As New FormatoGrillas

                        If DSPOT.Tables.Count = 0 Then
                            grillaPersonalOt.Columns.Clear()

                            OT.CrgPersonalOt(txtNot.Text, DSPOT)
                            grillaPersonalOt.DataSource = DSPOT.Tables(0)
                            formato_grid.grillasOT(grillaPersonalOt)
                        End If

                        If DSIOT.Tables.Count = 0 Then
                            OT.CrgInsumosOt(txtNot.Text, DSIOT)
                            If DSIOT.Tables(0).Rows.Count > 0 Then
                                Dim j As Integer = 0
                                For i = 0 To DSIOT.Tables(0).Rows.Count - 1
                                    grillaInsumosOt.Rows.Add()
                                    grillaInsumosOt.Rows(j).Cells(0).Value = DSIOT.Tables(0).Rows(i).Item(0).ToString
                                    grillaInsumosOt.Rows(j).Cells(1).Value = DSIOT.Tables(0).Rows(i).Item(1).ToString
                                    grillaInsumosOt.Rows(j).Cells(2).Value = DSIOT.Tables(0).Rows(i).Item(2).ToString
                                    grillaInsumosOt.Rows(j).Cells(3).Value = DSIOT.Tables(0).Rows(i).Item(3).ToString
                                    grillaInsumosOt.Rows(j).Cells(4).Value = DSIOT.Tables(0).Rows(i).Item(4).ToString
                                    grillaInsumosOt.Rows(j).Cells(5).Value = DSIOT.Tables(0).Rows(i).Item(5).ToString
                                    j = j + 1
                                Next
                            End If
                            formato_grid.grillasOT(grillaInsumosOt)
                        End If

                        If DSOEXOT.Tables.Count = 0 Then
                            OT.CrgOtExterna(txtNot.Text, DSOEXOT)
                            grillaOtExternas.Columns.Clear()
                            grillaOtExternas.DataSource = DSOEXOT.Tables(0)
                            formato_grid.grillasOT(grillaOtExternas)
                        End If
                    End If
                    ot_cargada_actual = txtNot.Text.Trim()
                Else
                    ot_cargada_actual = ""
                    txtNot.ResetText()
                    txtNot.Focus()
                End If
            Else
                ot_cargada_actual = numOtActual
            End If
        End If
    End Sub

    Private Sub arbol3_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles arbol3.BeforeSelect
        Nodo.LimpiarResaltadoNodos(arbol3.Nodes)
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        If txtNot.Text = "" Then
            MsgBox("Debe ingresar un N° de OT antes de eliminar", MsgBoxStyle.Exclamation, "Validación")
        Else
            If MsgBox("¿Esta seguro que desea eliminar la orden N° " & txtNot.Text & "?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                Dim ot As New OT
                Dim cod_resp As Integer = 0
                Dim resp As String = ""

                ot.DelOrdenTrabajo(txtNot.Text, principal.lblUsuario.Text, cod_resp, resp)

                If cod_resp = 1 Then
                    MsgBox(resp, MsgBoxStyle.Information, "Validación")
                    ot.LimpiarFrmOt()
                    Exit Sub
                Else
                    MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                    Exit Sub
                End If
            End If
        End If

    End Sub

    Private Sub btnDelFilaOt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelFilaOt.Click
        Dim OT As New OT

        Try
            Select Case TabOt.SelectedTab.Text
                Case "Personal"
                    If DSPOT.Tables.Count > 0 Then
                        With grillaPersonalOt
                            If .CurrentRow Is Nothing Then Exit Sub
                            If .CurrentRow.Cells(0).Value Is Nothing OrElse .CurrentRow.Cells(0).Value.ToString = "" Then
                                .Rows.Remove(.CurrentRow)
                                Exit Sub
                            End If
                        End With

                        If grillaPersonalOt.CurrentRow.Cells(0).Value.ToString <> "" Then
                            If MsgBox("Esta seguro que desea eliminar el personal :" & grillaPersonalOt.CurrentRow.Cells(1).Value, MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then

                                Dim cod_resp As Integer = 0
                                Dim resp As String = ""
                                Dim ind As Integer = 0

                                OT.DelPersonalOt(txtNot.Text, grillaPersonalOt.CurrentRow.Cells(0).Value, cod_resp, resp)

                                If cod_resp = 1 Then
                                    MsgBox(resp, MsgBoxStyle.Information, "Validación")
                                    grillaPersonalOt.Rows.Remove(grillaPersonalOt.CurrentRow)
                                    Exit Sub
                                Else
                                    MsgBox(resp, MsgBoxStyle.Exclamation, "Validación")
                                    Exit Sub
                                End If
                            End If
                        End If
                    Else
                        With grillaPersonalOt
                            If .RowCount = 0 OrElse .CurrentRow Is Nothing Then
                                MsgBox("No se pueden eliminar mas filas !!!", MsgBoxStyle.Exclamation, "Validación")
                                Exit Sub
                            End If
                            If .CurrentRow.Cells(0).Value Is Nothing OrElse .CurrentRow.Cells(0).Value.ToString = "" Then
                                .Rows.Remove(.CurrentRow)
                                Exit Sub
                            End If
                        End With

                        If grillaPersonalOt.RowCount > 0 Then
                            grillaPersonalOt.Rows.Remove(grillaPersonalOt.CurrentRow)
                        End If
                    End If

                Case "Insumos, Repuestos"
                    With grillaInsumosOt
                        If .RowCount = 0 OrElse .CurrentRow Is Nothing Then
                            MsgBox("No se pueden eliminar mas filas !!!", MsgBoxStyle.Exclamation, "Validación")
                            Exit Sub
                        ElseIf .CurrentRow.Cells(3).Value Is Nothing OrElse .CurrentRow.Cells(3).Value.ToString = "" OrElse .CurrentRow.Cells(4).Value Is Nothing OrElse .CurrentRow.Cells(4).Value.ToString = "" Then
                            .Rows.Remove(.CurrentRow)
                            Exit Sub
                        Else
                            If MsgBox("¿Esta seguro de eliminar el insumo seleccionado?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                                Dim cod_resp As Integer = 0
                                Dim resp As String = ""

                                OT.DelInsumoOt(txtNot.Text, grillaInsumosOt.Rows(grillaInsumosOt.CurrentRow.Index).Cells(0).Value, cod_resp, resp)

                                If cod_resp = 1 Then
                                    MsgBox(resp, MsgBoxStyle.Information, "Validación")
                                    grillaInsumosOt.Rows.Remove(grillaInsumosOt.CurrentRow)
                                Else
                                    MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                                End If
                            End If
                        End If
                    End With

                Case "OT Externas"
                    If DSOEXOT.Tables.Count > 0 Then
                        With grillaOtExternas
                            If .CurrentRow Is Nothing Then Exit Sub
                            If .CurrentRow.Cells(0).Value Is Nothing OrElse .CurrentRow.Cells(0).Value.ToString = "" Then
                                .Rows.Remove(.CurrentRow)
                                Exit Sub
                            End If
                        End With

                        If MsgBox("¿Esta seguro de eliminar la orden externa? :" & grillaOtExternas.CurrentRow.Cells(0).Value, MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                            Dim cod_resp As Integer = 0
                            Dim resp As String = ""

                            OT.DelOtExterna(txtNot.Text, grillaOtExternas.CurrentRow.Cells(0).Value, cod_resp, resp)
                            If cod_resp = 1 Then
                                MsgBox(resp, MsgBoxStyle.Information, "Validación")
                                grillaOtExternas.Rows.Remove(grillaOtExternas.CurrentRow)
                            Else
                                MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                            End If
                        End If
                    Else
                        With grillaOtExternas
                            If .RowCount = 0 OrElse .CurrentRow Is Nothing Then
                                MsgBox("No se pueden eliminar mas filas !!!", MsgBoxStyle.Exclamation, "Validación")
                                Exit Sub
                            ElseIf .Rows(.CurrentRow.Index).Cells(0).Value Is Nothing OrElse .Rows(.CurrentRow.Index).Cells(0).Value.ToString = "" OrElse .Rows(.CurrentRow.Index).Cells(1).Value Is Nothing OrElse .Rows(.CurrentRow.Index).Cells(1).Value.ToString = "" Then
                                .Rows.Remove(.CurrentRow)
                                Exit Sub

                            End If

                        End With
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub grillaInsumosOt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grillaInsumosOt.KeyDown
        If e.KeyCode = Keys.Enter Then
            FrmBuscarInsumo.nombre_form = "OT"
            FrmBuscarInsumo.Show()
        End If
    End Sub

    Private Sub dt_hr_ini_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dt_hr_ini.LostFocus
        Dim fecha_hora_rec As DateTime
        Dim fecha_hora_ini As DateTime

        fecha_hora_rec = dt_fecha_rec.Value.Date.Add(New TimeSpan(dt_hr_rec.Value.Hour, dt_hr_rec.Value.Minute, 0))
        fecha_hora_ini = dt_fecha_ini.Value.Date.Add(New TimeSpan(dt_hr_ini.Value.Hour, dt_hr_ini.Value.Minute, 0))

        If fecha_hora_rec > fecha_hora_ini Then
            MsgBox("La fecha de recepción debe ser mayor o igual a la fecha de inicio", MsgBoxStyle.Critical, "Validación")
            dt_fecha_rec.Focus()
        End If
    End Sub

    Private Sub dt_fecha_rec_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_fecha_rec.ValueChanged
        dt_fecha_ini.Value = dt_fecha_rec.Value
    End Sub

    Private Sub dt_fecha_ini_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_fecha_ini.ValueChanged
        If chkOtCierre.Checked Then
            CalcularDuracionOt()
        End If
    End Sub

    Private Sub dt_hr_ini_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_hr_ini.ValueChanged
        If chkOtCierre.Checked Then
            CalcularDuracionOt()
        End If
    End Sub

    Private Sub dt_fecha_ter_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_fecha_ter.ValueChanged
        CalcularDuracionOt()
        dt_fecha_cierre.Value = dt_fecha_ter.Value
    End Sub

    Private Sub dt_fecha_cierre_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_fecha_cierre.ValueChanged
        CalcularDuracionOt()
    End Sub

    Private Sub btn_buscar_per_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_per.Click
        FrmBuscarPersonal.nombre_form = "frm_OT"
        FrmBuscarPersonal.Show()
    End Sub

    Private Sub arbol3_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles arbol3.Enter
        If form_limpio AndAlso arbol3.SelectedNode IsNot Nothing Then
            id_nodo_ot_select = arbol3.SelectedNode.Name
            nodo_anterior2 = id_nodo_ot_select
            arbol3.SelectedNode.BackColor = Utilitarios.ColorSeleccion
        End If
    End Sub

    Private Sub txtRecibidoPor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecibidoPor.KeyPress
        utilitario.ValidarPersonalOT(e)
    End Sub

    Private Sub txtRecibidoPor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRecibidoPor.LostFocus
        Dim recibido_por As String = ""
        Dim texto_invalido As Boolean = False

        recibido_por = txtRecibidoPor.Text

        For i = 0 To recibido_por.Length - 1
            If recibido_por(i).ToString = " " Then
                texto_invalido = True
            ElseIf recibido_por(i).ToString = "." Then
                texto_invalido = True
            End If
        Next

        If texto_invalido Then
            MsgBox("Ingreso de Texto incorrecto, debe ser en este formato" & Chr(13) & "Ejemplo : ADIAZ, sin espacios ni puntos", MsgBoxStyle.Exclamation, "Validación Personal Recibido")
            txtRecibidoPor.ResetText()
            txtRecibidoPor.Focus()
        Else
            txtRecibidoPor.Text = UCase(Trim(txtRecibidoPor.Text))
        End If
    End Sub

    Private Sub txtSolicitadoPor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSolicitadoPor.KeyPress
        utilitario.ValidarPersonalOT(e)
    End Sub

    Private Sub txtSolicitadoPor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSolicitadoPor.LostFocus
        Dim solicitado_por As String = ""
        Dim texto_invalido As Boolean = False

        solicitado_por = txtSolicitadoPor.Text

        For i = 0 To solicitado_por.Length - 1
            If solicitado_por(i).ToString = " " Then
                texto_invalido = True
            ElseIf solicitado_por(i).ToString = "." Then
                texto_invalido = True
            End If
        Next

        If texto_invalido Then
            MsgBox("Ingreso de Texto incorrecto, debe ser en este formato" & Chr(13) & "Ejemplo : ADIAZ, sin espacios ni puntos", MsgBoxStyle.Exclamation, "Validación Personal Solicitado")
            txtSolicitadoPor.ResetText()
            txtSolicitadoPor.Focus()
        Else
            txtSolicitadoPor.Text = UCase(Trim(txtSolicitadoPor.Text))
        End If
    End Sub

    Private Sub txtCerradoPor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCerradoPor.KeyPress
        utilitario.ValidarPersonalOT(e)
    End Sub

    Private Sub txtCerradoPor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCerradoPor.LostFocus
        Dim cerrado_por As String = ""
        Dim texto_invalido As Boolean = False

        cerrado_por = txtCerradoPor.Text

        For i = 0 To cerrado_por.Length - 1
            If cerrado_por(i).ToString = " " Then
                texto_invalido = True
            ElseIf cerrado_por(i).ToString = "." Then
                texto_invalido = True
            End If
        Next

        If texto_invalido Then
            MsgBox("Ingreso de Texto incorrecto, debe ser en este formato" & Chr(13) & "Ejemplo : ADIAZ, sin espacios ni puntos", MsgBoxStyle.Exclamation, "Validación Personal de Cierre")
            txtCerradoPor.ResetText()
            txtCerradoPor.Focus()
        Else
            txtCerradoPor.Text = UCase(Trim(txtCerradoPor.Text))
        End If
    End Sub
End Class
