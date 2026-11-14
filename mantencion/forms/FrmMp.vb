Imports System.Data.SqlClient
Public Class FrmMp
    Public DS2 As New DataSet
    Public DST_TAREAS As New DataSet
    Public id_nodo_select As String
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Public filtro_tareas As New DataView
    Public del_index_tareas As New Collection
    Public del_index_personal As New Collection
    Public form_limpio As Boolean = False
    Public DST_NODOS_HIJOS As New DataSet
    Public id_nodo_padre As String

    Private Sub FrmMp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Dim mantPrev As New MantPreventiva
            Dim nd As New Nodo
            Dim nodoRaiz As New TreeNode
            Dim grillas As New FormatoGrillas

            nodoRaiz.Name = "1"
            nodoRaiz.Text = "Cambiaso Hnos S.A."
            nd.CRG_NODO_MANT_SI(nodoRaiz)
            arbol1.BeginUpdate()
            arbol1.Nodes.Clear()
            arbol1.Nodes.Add(nodoRaiz)
            arbol1.EndUpdate()
            mantPrev.CrgCmbEstadoCiclo(cmbEstadoCiclo)
            mantPrev.CrgCmbEstadoMp(cmbEstadoMp)
            mantPrev.CrgCmbTipoMp(cmbTipoMp)

            If btnNuevoCiclo.Enabled = False Then
                btnNuevoCiclo.Enabled = True
            End If

            lblHrsCiclo.Visible = False
            hrsCiclo.Visible = False
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub AgrFila_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgrFila.Click
        Try
            Select Case TabMp.SelectedTab.Text
                Case "Insumos Utilizados"
                    grillaInsumosMp.Rows.Add()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub btnDelFila_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelFila.Click
        Dim ind As Integer = 0

        Try
            Select Case TabMp.SelectedTab.Text
                Case "Tareas"
                    With grillaTareasCicloMp
                        If .RowCount > 0 AndAlso .CurrentRow IsNot Nothing Then
                            If MsgBox("¿ Esta seguro de eliminar la tarea :" & .Rows(.CurrentRow.Index).Cells(4).Value & " ?", MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                                del_index_tareas.Add(.Rows(.CurrentRow.Index).Cells(1).Value)
                                .Rows.Remove(.CurrentRow)
                                Exit Sub
                            End If
                        ElseIf .RowCount = 0 Then
                            MsgBox("No se pueden eliminar mas filas !!!", MsgBoxStyle.Exclamation, "Validación")
                            Exit Sub
                        End If
                    End With

                Case "Personal"
                    With grillaPersonalMp
                        If .RowCount = 0 OrElse .CurrentRow Is Nothing Then
                            MsgBox("No se pueden eliminar mas filas !!!", MsgBoxStyle.Exclamation, "Validación")
                            Exit Sub
                        End If
                        If .CurrentRow.Cells(0).Value Is Nothing OrElse .CurrentRow.Cells(0).Value.ToString = "" Then
                            .Rows.Remove(grillaPersonalMp.CurrentRow)
                            Exit Sub
                        End If
                    End With

                    If MsgBox("¿Está seguro que desea eliminar el personal " & grillaPersonalMp.CurrentRow.Cells(1).Value & "?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                        If DS2.Tables.Count > 0 Then
                            If grillaPersonalMp.CurrentRow.Cells(0).Value.ToString <> "" Then
                                Dim mant_prev As New MantPreventiva
                                Dim cod_resp As Integer = 0
                                Dim resp As String = ""

                                del_index_personal.Add(grillaPersonalMp.Rows(grillaPersonalMp.CurrentRow.Index).Cells(0).Value)
                                grillaPersonalMp.Rows.Remove(grillaPersonalMp.CurrentRow)

                            End If
                        Else
                            If grillaPersonalMp.RowCount > 0 Then
                                grillaPersonalMp.Rows.Remove(grillaPersonalMp.CurrentRow)
                            End If
                        End If
                    End If

                Case "Insumos Utilizados"
                    If grillaInsumosMp.RowCount > 0 AndAlso grillaInsumosMp.CurrentRow IsNot Nothing Then
                        With grillaInsumosMp
                            If .Rows(.CurrentRow.Index).Cells(3).Value Is Nothing OrElse .Rows(.CurrentRow.Index).Cells(3).Value.ToString = "" OrElse .Rows(.CurrentRow.Index).Cells(4).Value Is Nothing OrElse .Rows(.CurrentRow.Index).Cells(4).Value.ToString = "" Then
                                .Rows.Remove(.CurrentRow)
                                Exit Sub
                            End If
                        End With
                        If MsgBox("¿Esta seguro de eliminar el insumo " & grillaInsumosMp.Rows(grillaInsumosMp.CurrentRow.Index).Cells(1).Value & " ?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                            Dim mant_prev As New MantPreventiva
                            Dim cod_resp As Integer = 0
                            Dim resp As String = ""

                            ind = grillaInsumosMp.CurrentRow.Index
                            mant_prev.DelInsumoCicloMp(txtIdMant.Text, txtIdCiclo.Text, grillaInsumosMp.Rows(grillaInsumosMp.CurrentRow.Index).Cells(0).Value, cod_resp, resp)

                            If cod_resp = 1 Then
                                MsgBox(resp, MsgBoxStyle.Information, "Validación")
                                grillaInsumosMp.Rows.Remove(grillaInsumosMp.CurrentRow)
                            Else
                                MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                            End If
                        End If
                    Else
                        MsgBox("No se pueden eliminar mas filas !!!", MsgBoxStyle.Exclamation, "Validación")
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub btnNuevaMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaMp.Click
        Dim mant_prev As New MantPreventiva
        Dim nodo As New Nodo

        Try
            txtIdMant.Text = mant_prev.NuevoIdMp()
            txtIdCiclo.Text = 1
            txtFrecuenciaMp.Focus()
            btnNuevoCiclo.Enabled = False
            btnGuardarComoNuevoCiclo.Enabled = False
            btnGuardarMp.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub arbol1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles arbol1.AfterSelect
        If arbol1.SelectedNode Is Nothing Then Exit Sub
        id_nodo_select = arbol1.SelectedNode.Name
        nodo_anterior2 = id_nodo_select
        arbol1.SelectedNode.BackColor = Utilitarios.ColorSeleccion
    End Sub

    Private Sub arbol1_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles arbol1.BeforeSelect
        Nodo.LimpiarResaltadoNodos(arbol1.Nodes)
    End Sub

    Private Sub btnNuevoCiclo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoCiclo.Click
        Dim mant_prev As New MantPreventiva
        Dim nodo As New Nodo
        Dim id_ciclo As Integer = 0
        Dim DS As New DataSet

        If txtIdMant.Text = "" Then
            MsgBox("Debe Buscar una mantencion preventiva antes de crear un nuevo ciclo", MsgBoxStyle.Critical, "Validación")
        Else
            id_ciclo = mant_prev.NuevoIdCicloMp(txtIdMant.Text)
            txtIdCiclo.Text = id_ciclo
            btnIngMp.Enabled = False
            btnGuardarComoNuevoCiclo.Enabled = False
            txtDuracionCiclo.Text = 0
        End If

    End Sub

    Private Sub btnGuardarMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarMp.Click
        Dim mant_prev As New MantPreventiva
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        Dim existe_ciclo_mp As Boolean = False
        Dim resp2 As String = ""
        Dim valida As String = ""

        valida = mant_prev.ValidarMP

        If valida = "" Then
            existe_ciclo_mp = mant_prev.BuscarCicloMp(txtIdMant.Text, txtIdCiclo.Text)
            If existe_ciclo_mp Then
                mant_prev.UpdCicloMp(txtIdMant.Text, txtIdCiclo.Text, FechaIniCiclo.Value, HrInicioCiclo.Value, fechaFinCicloMp.Value, HrFinCiclo.Value, txtDuracionCiclo.Text, txtObsCiclo.Text, cmbEstadoCiclo.Text, principal.lblUsuario.Text, cod_resp, resp)
            Else
                mant_prev.IngCicloMp(txtIdMant.Text, txtIdCiclo.Text, FechaIniCiclo.Value, HrInicioCiclo.Value, fechaFinCicloMp.Value, HrFinCiclo.Value, txtDuracionCiclo.Text, txtObsCiclo.Text, cmbEstadoCiclo.Text, principal.lblUsuario.Text, cod_resp, resp)
            End If

            If del_index_tareas.Count > 0 Then
                For i = 1 To del_index_tareas.Count
                    mant_prev.DelTareaCicloMp(txtIdMant.Text, txtIdCiclo.Text, del_index_tareas.Item(i).ToString, cod_resp, resp2)
                Next
            End If

            With grillaTareasCicloMp
                If .RowCount > 0 Then
                    Dim obs_tarea As String

                    For i = 0 To .Rows.Count - 1
                        obs_tarea = If(.Rows(i).Cells(6).Value Is Nothing, "", .Rows(i).Cells(6).Value.ToString())
                        mant_prev.UpdTareasCicloMp(txtIdMant.Text, txtIdCiclo.Text, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(5).Value, obs_tarea)
                    Next
                End If

            End With

            With grillaPersonalMp
                If .RowCount > 0 Then
                    For i = 0 To .Rows.Count - 1
                        mant_prev.UpdPersonalCicloMp(txtIdMant.Text, txtIdCiclo.Text, .Rows(i).Cells(0).Value)
                    Next
                End If

                Dim resp3 As String = ""
                Dim codresp3 As Integer = 0
                If del_index_personal.Count > 0 Then
                    For i = 1 To del_index_personal.Count
                        mant_prev.DelPersonalCicloMp(txtIdMant.Text, txtIdCiclo.Text, del_index_personal.Item(i).ToString, codresp3, resp3)
                    Next

                End If
            End With

            With grillaInsumosMp
                If .RowCount > 0 Then
                    For i = 0 To .RowCount - 1
                        mant_prev.UpdInsumosCicloMp(txtIdMant.Text, txtIdCiclo.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(3).Value, .Rows(i).Cells(4).Value)
                    Next
                End If
            End With

            If cod_resp = 1 Then
                MsgBox(resp, MsgBoxStyle.Information, "Validación")
                mant_prev.LimpiarFrmMp()
            Else
                MsgBox(resp, MsgBoxStyle.Critical, "Validación")
            End If
        Else
            MsgBox(valida, MsgBoxStyle.Exclamation, "Validación")
        End If

    End Sub

    Private Sub btnBuscarMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMp.Click
        Dim mant_preventiva As New MantPreventiva

        Try
            If id_nodo_select = "" Then
                MsgBox("No se ha seleccionado ningun item!!!", MsgBoxStyle.Exclamation, "Validación")
            Else
                id_nodo_padre = id_nodo_select
                mant_preventiva.CrgNodosHijosMp(id_nodo_padre, DST_NODOS_HIJOS)
                FrmBuscarMp.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try


    End Sub

    Private Sub btnBuscarCiclo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCiclo.Click
        Try
            If txtIdMant.Text = "" Then
                MsgBox("Debe buscar una mantención preventiva antes de buscar un ciclo!!!", MsgBoxStyle.Critical, "Validación")
            Else
                FrmBuscarCiclo.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub grillaPersonalMp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grillaPersonalMp.KeyDown
        If grillaPersonalMp.CurrentCell IsNot Nothing AndAlso grillaPersonalMp.CurrentCell.ColumnIndex = 1 Then
            If e.KeyCode = Keys.Enter Then
                FrmBuscarPersonal.nombre_form = "mp"
                FrmBuscarPersonal.Show()
            End If
        End If
    End Sub

    Private Sub btnIngCicloMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngMp.Click
        Dim mant_prev As New MantPreventiva
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim resp_2 As String = ""
        Dim existe_mp As Boolean = False
        Dim existe_ciclo_mp As Boolean = False
        Dim validarForm As Boolean = False

        validarForm = mant_prev.ValidarIngresoMp(Me, resp)

        If validarForm Then
            existe_mp = mant_prev.BuscarMp(txtIdMant.Text)
            If existe_mp Then
                MsgBox("La mantención ya existe,para guardar presione Actualizar")
                Exit Sub
            Else
                mant_prev.IngMantPreventiva(txtIdMant.Text, id_nodo_select, txtFrecuenciaMp.Text, txtTiempoAviso.Text, cmbEstadoMp.Text, cmbTipoMp.Text, principal.lblUsuario.Text, txtObsMant.Text, cod_resp, resp)

                mant_prev.IngCicloMp(txtIdMant.Text, txtIdCiclo.Text, FechaIniCiclo.Value, HrInicioCiclo.Value, fechaFinCicloMp.Value, HrFinCiclo.Value, txtDuracionCiclo.Text, txtObsCiclo.Text, cmbEstadoCiclo.Text, principal.lblUsuario.Text, cod_resp, resp_2)

                If grillaPersonalMp.Rows.Count > 0 Then
                    With grillaPersonalMp
                        For i = 0 To .Rows.Count - 1
                            mant_prev.IngPersonalCicloMp(.Rows(i).Cells(0).Value, txtIdMant.Text, txtIdCiclo.Text)
                        Next
                    End With
                End If

                If grillaTareasCicloMp.Rows.Count > 0 Then
                    With grillaTareasCicloMp
                        For i = 0 To .Rows.Count - 1
                            Dim obs_tarea As String = If(.Rows(i).Cells(6).Value Is Nothing, "", .Rows(i).Cells(6).Value.ToString())

                            If CBool(.Rows(i).Cells(0).Value) Then
                                mant_prev.IngTareasCicloMp(txtIdMant.Text, txtIdCiclo.Text, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(5).Value, obs_tarea)
                            Else
                                mant_prev.IngTareasPendCicloMp(txtIdMant.Text, txtIdCiclo.Text, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, obs_tarea)
                            End If
                        Next
                    End With
                End If

                If grillaInsumosMp.RowCount > 0 Then
                    For i = 0 To grillaInsumosMp.RowCount - 1
                        mant_prev.IngInsumosMp(txtIdMant.Text, txtIdCiclo.Text, grillaInsumosMp.Rows(i).Cells(0).Value, grillaInsumosMp.Rows(i).Cells(3).Value, grillaInsumosMp.Rows(i).Cells(4).Value)
                    Next
                End If

                If cod_resp = 1 Then
                    MsgBox(resp & Chr(13) & resp_2, MsgBoxStyle.Information, "Validación")
                Else
                    MsgBox(resp, MsgBoxStyle.Critical, "Error")
                End If
            End If

            mant_prev.LimpiarFrmMp()
        Else
            MsgBox(resp, MsgBoxStyle.Exclamation, "Validación")
        End If

    End Sub

    Private Sub txtFrecuenciaMp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrecuenciaMp.GotFocus
        txtFrecuenciaMp.BackColor = Utilitarios.ColorFondoFoco
    End Sub

    Private Sub txtFrecuenciaMp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFrecuenciaMp.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtFrecuenciaMp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrecuenciaMp.LostFocus
        txtFrecuenciaMp.BackColor = Utilitarios.ColorFondoInput
    End Sub

    Private Sub txtObsCiclo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObsCiclo.GotFocus
        txtObsCiclo.BackColor = Utilitarios.ColorFondoFoco
    End Sub

    Private Sub txtObsCiclo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObsCiclo.LostFocus
        txtObsCiclo.BackColor = Utilitarios.ColorFondoInput
    End Sub

    Private Sub txtTiempoAviso_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTiempoAviso.GotFocus
        txtTiempoAviso.BackColor = Utilitarios.ColorFondoFoco
    End Sub

    Private Sub txtTiempoAviso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTiempoAviso.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtTiempoAviso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTiempoAviso.LostFocus
        txtTiempoAviso.BackColor = Utilitarios.ColorFondoInput
    End Sub

    Private Sub cmbEstadoMp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEstadoMp.GotFocus
        cmbEstadoMp.BackColor = Utilitarios.ColorFondoFoco
    End Sub

    Private Sub cmbEstadoMp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEstadoMp.LostFocus
        cmbEstadoMp.BackColor = Utilitarios.ColorFondoInput
    End Sub

    Private Sub btnLimpiarCiclo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarCiclo.Click
        Dim mant_prev As New MantPreventiva
        Try
            mant_prev.LimpiarFrmMp()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub btnNewCiclo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarComoNuevoCiclo.Click
        Dim mant_prev As New MantPreventiva
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim id_nuevo_ciclo As Integer = 0
        Dim valida As String = ""

        valida = mant_prev.ValidarMP

        If valida = "" Then
            id_nuevo_ciclo = mant_prev.NuevoIdCicloMp(txtIdMant.Text)

            mant_prev.IngCicloMp(txtIdMant.Text, CStr(id_nuevo_ciclo), FechaIniCiclo.Value, HrInicioCiclo.Value, fechaFinCicloMp.Value, HrFinCiclo.Value, txtDuracionCiclo.Text, txtObsCiclo.Text, cmbEstadoCiclo.Text, principal.lblUsuario.Text, cod_resp, resp)

            Try
                If grillaPersonalMp.Rows.Count > 0 Then
                    With grillaPersonalMp
                        For i = 0 To .Rows.Count - 1
                            mant_prev.IngPersonalCicloMp(.Rows(i).Cells(0).Value, txtIdMant.Text, CStr(id_nuevo_ciclo))
                        Next
                    End With
                End If

                If grillaTareasCicloMp.Rows.Count > 0 Then
                    With grillaTareasCicloMp
                        Dim obs_tarea As String

                        For i = 0 To .Rows.Count - 1
                            obs_tarea = If(.Rows(i).Cells(6).Value Is Nothing, "", .Rows(i).Cells(6).Value.ToString())
                            If CBool(.Rows(i).Cells(0).Value) Then
                                mant_prev.IngTareasCicloMp(txtIdMant.Text, CStr(id_nuevo_ciclo), .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(5).Value, obs_tarea)
                            Else
                                mant_prev.IngTareasPendCicloMp(txtIdMant.Text, CStr(id_nuevo_ciclo), .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, obs_tarea)
                            End If
                        Next
                    End With
                End If

                If grillaInsumosMp.RowCount > 0 Then
                    For i = 0 To grillaInsumosMp.RowCount - 1
                        mant_prev.IngInsumosMp(txtIdMant.Text, CStr(id_nuevo_ciclo), grillaInsumosMp.Rows(i).Cells(0).Value, grillaInsumosMp.Rows(i).Cells(3).Value, grillaInsumosMp.Rows(i).Cells(4).Value)
                    Next
                End If

                If cod_resp = 1 Then
                    MsgBox(resp, MsgBoxStyle.Information, "Validación")
                Else
                    MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                End If

                If btnNuevoCiclo.Enabled = False Then
                    btnNuevoCiclo.Enabled = True
                End If

                mant_prev.LimpiarFrmMp()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        Else
            MsgBox(valida, MsgBoxStyle.Exclamation, "Validación")
        End If

    End Sub

    Private Sub txtBuscarNodo1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarNodo1.KeyUp
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(arbol1, txtBuscarNodo1, e, id_nodo_select, nodo_anterior, 3)
    End Sub

    Private Sub txtBuscarNodo1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarNodo1.TextChanged
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(arbol1, txtBuscarNodo1, Nothing, id_nodo_select, nodo_anterior, 3)
    End Sub

    Private Sub btnEliminarCiclo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarCiclo.Click
        If txtIdMant.Text = "" Or txtIdCiclo.Text = "" Then
            MsgBox("Debe desplegar una mantención y un ciclo para eliminar", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        Else
            If MsgBox("¿ Esta Seguro que desea eliminar el ciclo N°" & txtIdCiclo.Text & " ?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                Dim mant_prev As New MantPreventiva
                Dim cod_resp As Integer = 0
                Dim resp As String = ""

                mant_prev.DelCicloMp(txtIdMant.Text, txtIdCiclo.Text, principal.lblUsuario.Text, cod_resp, resp)

                If cod_resp = 1 Then
                    MsgBox(resp, MsgBoxStyle.Information, "Validación")
                    mant_prev.LimpiarFrmMp()
                Else
                    MsgBox(resp, MsgBoxStyle.Critical, "Error")
                End If
            End If
        End If
    End Sub

    Private Sub btnEliminarMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarMp.Click
        If txtIdMant.Text = "" Then
            MsgBox("Debe desplegar una mantencion preventiva antes de eliminar", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        Else
            If MsgBox("¿ Esta Seguro de Eliminar la Mantencion Preventiva ?" & Chr(13) & "Nota : Se eliminará toda la información relacionada con esta mantención" & Chr(13) & "¿ Desea Continuar ?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                Dim mant_prev As New MantPreventiva
                Dim cod_resp As Integer = 0
                Dim resp As String = ""

                mant_prev.DelMantPreventiva(txtIdMant.Text, principal.lblUsuario.Text, cod_resp, resp)

                If cod_resp = 1 Then
                    MsgBox(resp, MsgBoxStyle.Information, "Validación")
                    mant_prev.LimpiarFrmMp()
                Else
                    MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                End If
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub grillaInsumosMp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grillaInsumosMp.KeyDown
        If grillaInsumosMp.CurrentCell IsNot Nothing AndAlso grillaInsumosMp.CurrentCell.ColumnIndex = 1 Then
            If e.KeyCode = Keys.Enter Then
                FrmBuscarInsumo.nombre_form = "MP"
                FrmBuscarInsumo.Show()
            End If
        End If
    End Sub

    Private Sub grillaTareasCicloMp_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaTareasCicloMp.CellEndEdit
        Try
            With grillaTareasCicloMp
                If .CurrentCell IsNot Nothing AndAlso .CurrentCell.ColumnIndex = 0 Then
                    If CBool(.Rows(.CurrentRow.Index).Cells(0).Value) = False Then
                        .Rows(.CurrentRow.Index).Cells(5).Value = 0
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub TareasAdMp_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TareasAdMp.Enter
        If grillaTareasAdMp.DataSource Is Nothing Or grillaTareasAdMp.RowCount = 0 Then
            Dim MP As New MantPreventiva
            Dim formato_grid As New FormatoGrillas
            Dim DST_TAREAS As New DataSet

            MP.CrgTareasNodoTodas(DST_TAREAS)
            grillaTareasAdMp.DataSource = DST_TAREAS.Tables(0)
            formato_grid.grillasMp(grillaTareasAdMp)
            filtro_tareas.Table = DST_TAREAS.Tables(0)
        End If
    End Sub

    Private Sub txtBuscarTarea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarTarea.TextChanged
        If filtro_tareas.Table Is Nothing OrElse grillaTareasAdMp.ColumnCount < 5 Then Exit Sub
        Dim tipo_tarea As String = ""
        Dim textoFiltro As String = Utilitarios.EscaparLike(txtBuscarTarea.Text)

        If Opc_tareas_ele.Checked And opc_seccion.Checked Then
            tipo_tarea = "Electrica"
            filtro_tareas.RowFilter = "[" & grillaTareasAdMp.Columns(3).Name & "] like '%" & textoFiltro & "%' and Tipo_Mantención = '" & tipo_tarea & "' "
            grillaTareasAdMp.DataSource = filtro_tareas
            grillaTareasAdMp.Update()

        ElseIf Opc_tareas_ele.Checked And opc_mod_maq.Checked Then
            tipo_tarea = "Electrica"
            filtro_tareas.RowFilter = "[" & grillaTareasAdMp.Columns(4).Name & "] like '%" & textoFiltro & "%' and Tipo_Mantención = '" & tipo_tarea & "' "
            grillaTareasAdMp.DataSource = filtro_tareas
            grillaTareasAdMp.Update()

        ElseIf opc_tareas_mec.Checked And opc_seccion.Checked Then
            tipo_tarea = "Mecanica"
            filtro_tareas.RowFilter = "[" & grillaTareasAdMp.Columns(3).Name & "] like '%" & textoFiltro & "%' and Tipo_Mantención = '" & tipo_tarea & "' "
            grillaTareasAdMp.DataSource = filtro_tareas
            grillaTareasAdMp.Update()

        ElseIf opc_tareas_mec.Checked And opc_mod_maq.Checked Then
            tipo_tarea = "Mecanica"
            filtro_tareas.RowFilter = "[" & grillaTareasAdMp.Columns(4).Name & "] like '%" & textoFiltro & "%' and Tipo_Mantención = '" & tipo_tarea & "' "
            grillaTareasAdMp.DataSource = filtro_tareas
            grillaTareasAdMp.Update()

        End If


    End Sub

    Private Sub btnAgrTareas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgrTareas.Click

        Try
            If DST_TAREAS.Tables.Count > 0 Then
                With grillaTareasAdMp
                    For i = 0 To .RowCount - 1
                        If CBool(.Rows(i).Cells(0).Value) = True Then
                            Dim fila As DataRow = DST_TAREAS.Tables(0).NewRow

                            fila(1) = id_nodo_select            'ID Nodo seleccionado
                            fila(0) = .Rows(i).Cells(1).Value   'ID Tarea
                            fila(2) = arbol1.SelectedNode.Text  'Nombre Modulo seleccionado
                            fila(3) = .Rows(i).Cells(5).Value   'Descripcion Tarea seleccionada
                            fila(4) = 0                         'Tiempo Tarea
                            DST_TAREAS.Tables(0).Rows.Add(fila)
                        End If
                    Next
                End With

                MsgBox("Tareas Ingresadas", MsgBoxStyle.Information, "Confirmación")

            Else
                Dim mant_prev As New MantPreventiva
                Dim grillas As New FormatoGrillas

                DST_TAREAS.Tables.Clear()
                mant_prev.CrgTareasCicloMp(73, 1, 2, DST_TAREAS)
                grillaTareasCicloMp.DataSource = DST_TAREAS.Tables(0)
                DST_TAREAS.Tables(0).Rows.Clear()
                grillas.grillasMp(grillaTareasCicloMp)

                With grillaTareasAdMp
                    For i = 0 To .RowCount - 1
                        If CBool(.Rows(i).Cells(0).Value) = True Then
                            Dim fila As DataRow = DST_TAREAS.Tables(0).NewRow

                            fila(1) = id_nodo_select            'ID Nodo seleccionado
                            fila(0) = .Rows(i).Cells(1).Value   'ID Tarea
                            fila(2) = arbol1.SelectedNode.Text  'Nombre Modulo seleccionado
                            fila(3) = .Rows(i).Cells(5).Value   'Descripcion Tarea seleccionada
                            fila(4) = 0                         'Tiempo Tarea
                            DST_TAREAS.Tables(0).Rows.Add(fila)
                        End If
                    Next
                End With

                MsgBox("Tareas Ingresadas", MsgBoxStyle.Information, "Confirmación")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub btn_agr_tareas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agr_tareas.Click
        If id_nodo_select = "" Then
            MsgBox("Debe seleccionar un item para buscar las tareas", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        Else
            FrmBuscarTareasMp.nodo_padre = id_nodo_select
            FrmBuscarTareasMp.tipo_mp = cmbTipoMp.Text
            FrmBuscarTareasMp.Show()
        End If

    End Sub

    Private Sub chkSelTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelTodo.CheckedChanged
        If chkSelTodo.Checked Then
            If grillaTareasCicloMp.RowCount > 0 Then
                For i = 0 To grillaTareasCicloMp.RowCount - 1
                    grillaTareasCicloMp.Rows(i).Cells(0).Value = True
                Next
            End If
        Else
            If grillaTareasCicloMp.RowCount > 0 Then
                For i = 0 To grillaTareasCicloMp.RowCount - 1
                    grillaTareasCicloMp.Rows(i).Cells(0).Value = False
                    grillaTareasCicloMp.Rows(i).Cells(5).Value = 0
                Next
            End If
        End If
    End Sub

    Private Sub opc_tareas_mec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opc_tareas_mec.CheckedChanged
        If opc_tareas_mec.Checked And grillaTareasAdMp.RowCount > 0 Then
            filtro_tareas.RowFilter = "Tipo_Mantención = 'Mecanica' "
            grillaTareasAdMp.DataSource = filtro_tareas
            grillaTareasAdMp.Update()
            lblFiltro.Text = "Ingrese el nombre de la tarea"
        End If

    End Sub

    Private Sub Opc_tareas_ele_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Opc_tareas_ele.CheckedChanged
        If Opc_tareas_ele.Checked And grillaTareasAdMp.RowCount > 0 Then
            filtro_tareas.RowFilter = "Tipo_Mantención = 'Electrica' "
            grillaTareasAdMp.DataSource = filtro_tareas
            grillaTareasAdMp.Update()
            lblFiltro.Text = "Ingrese el nombre de la tarea"
        End If
    End Sub

    Private Sub btn_buscar_personal_mp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_personal_mp.Click
        FrmBuscarPersonal.nombre_form = "mp"
        FrmBuscarPersonal.Show()
    End Sub

    Private Sub CalcularDuracionCiclo()
        Dim f_inicio As DateTime = FechaIniCiclo.Value.Date.Add(New TimeSpan(HrInicioCiclo.Value.Hour, HrInicioCiclo.Value.Minute, 0))
        Dim f_termino As DateTime = fechaFinCicloMp.Value.Date.Add(New TimeSpan(HrFinCiclo.Value.Hour, HrFinCiclo.Value.Minute, 0))
        txtDuracionCiclo.Text = FormatNumber(DateDiff(DateInterval.Minute, f_inicio, f_termino) / 60, 1)
    End Sub

    Private Sub FechaIniCiclo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FechaIniCiclo.ValueChanged
        CalcularDuracionCiclo()
    End Sub

    Private Sub fechaFinCicloMp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fechaFinCicloMp.ValueChanged
        CalcularDuracionCiclo()
    End Sub

    Private Sub HrInicioCiclo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HrInicioCiclo.ValueChanged
        CalcularDuracionCiclo()
    End Sub

    Private Sub HrFinCiclo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HrFinCiclo.ValueChanged
        CalcularDuracionCiclo()
    End Sub

    Private Sub arbol1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles arbol1.Enter
        If form_limpio AndAlso arbol1.SelectedNode IsNot Nothing Then
            id_nodo_select = arbol1.SelectedNode.Name
            nodo_anterior2 = id_nodo_select
            arbol1.SelectedNode.BackColor = Utilitarios.ColorSeleccion
        End If
    End Sub

    Private Sub btnCambiarTareas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiarTareas.Click
        Dim mant_prev As New MantPreventiva
        Dim cod_resp As Integer
        Dim resp As String = ""

        With grillaTareasCicloMp
            If .RowCount > 0 Then
                Dim obs_tarea As String

                For i = 0 To .Rows.Count - 1
                    If CBool(.Rows(i).Cells(0).Value) Then
                        obs_tarea = If(.Rows(i).Cells(6).Value Is Nothing, "", .Rows(i).Cells(6).Value.ToString())
                        mant_prev.UpdIdNodoTareasMp(txtIdMant.Text, txtIdCiclo.Text, .Rows(i).Cells(1).Value, id_nodo_select, cod_resp, resp)
                    End If

                Next
            End If

        End With

        If cod_resp = 0 Then
            MsgBox(resp, MsgBoxStyle.Information, "Validación")
        End If
    End Sub

    Private Sub btn_Limpiar_tabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Limpiar_tabla.Click
        If grillaTareasCicloMp.RowCount > 0 Then
            For i = 0 To grillaTareasCicloMp.RowCount - 1
                grillaTareasCicloMp.Rows(i).Cells(0).Value = False
                grillaTareasCicloMp.Rows(i).Cells(5).Value = 0
                grillaTareasCicloMp.Rows(i).Cells(6).Value = ""
            Next
        End If
    End Sub

    Private Sub btnActMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActMp.Click
        Dim existe_mp As Boolean = False
        Dim mant_prev As New MantPreventiva
        Dim cod_resp As Integer
        Dim resp As String = ""

        If txtIdMant.Text = "" Then
            MsgBox("Faltan campos por completar,revise la informacion de la MP", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        existe_mp = mant_prev.BuscarMp(txtIdMant.Text)
        If existe_mp Then
            If txtIdMant.Text <> "" AndAlso txtFrecuenciaMp.Text <> "" AndAlso txtTiempoAviso.Text <> "" Then
                mant_prev.UpdMantPreventiva(txtIdMant.Text, id_nodo_select, txtFrecuenciaMp.Text, txtTiempoAviso.Text, cmbEstadoMp.Text, cmbTipoMp.Text, principal.lblUsuario.Text, txtObsMant.Text, cod_resp, resp)
                If cod_resp = 1 Then
                    MsgBox(resp, MsgBoxStyle.Information, "Validación")
                    mant_prev.LimpiarFrmMp()
                Else
                    MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                End If
            Else
                MsgBox("Faltan campos por completar,revise la informacion de la MP", MsgBoxStyle.Exclamation, "Validación")
            End If
        End If
    End Sub

    Private Sub btn_plan_ciclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_plan_ciclos.Click
        Dim ultimo_ciclo As Boolean = False

        If txtIdMant.Text <> "" And txtIdCiclo.Text <> "" Then
            Dim mant_preventiva As New MantPreventiva

            ultimo_ciclo = mant_preventiva.BuscarUltimoCicloMp(txtIdMant.Text, txtIdCiclo.Text)

            If ultimo_ciclo Then
                FrmPlanificarCiclos.Show()
            Else
                MsgBox("Debe desplegar el ultimo ciclo para planificar", MsgBoxStyle.Exclamation, "Validación")
            End If

        End If
    End Sub

    Private Sub opc_seccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opc_seccion.CheckedChanged
        lblFiltro.Text = "Ingrese el nombre de la sección"
    End Sub

    Private Sub opc_mod_maq_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opc_mod_maq.CheckedChanged
        lblFiltro.Text = "Ingrese el nombre de la máquina"
    End Sub
End Class
