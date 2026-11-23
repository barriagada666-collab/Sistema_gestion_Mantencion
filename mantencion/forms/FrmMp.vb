Imports System.Data.SqlClient
Public Class FrmMp
    Public DS2 As New DataSet
    Public DST_TAREAS As New DataSet
    Public id_nodo_select As String = "1"
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Public filtro_tareas As New DataView
    Public del_index_tareas As New Collection
    Public del_index_personal As New Collection
    Public form_limpio As Boolean = False
    Public DST_NODOS_HIJOS As New DataSet
    Public id_nodo_padre As String = "1"

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
            arbol1.SelectedNode = nodoRaiz
            id_nodo_select = "1"
            arbol1.EndUpdate()
            mantPrev.CrgCmbEstadoCiclo(cmbEstadoCiclo)
            mantPrev.CrgCmbEstadoMp(cmbEstadoMp)
            mantPrev.CrgCmbTipoMp(cmbTipoMp)

            If btnNuevoCiclo.Enabled = False Then
                btnNuevoCiclo.Enabled = True
            End If

            lblHrsCiclo.Visible = False
            hrsCiclo.Visible = False
            btnIngMp.Enabled = Usuario.PermisoIngMp
            btnGuardarMp.Enabled = Usuario.PermisoGuardarMp
            btnEliminarCiclo.Enabled = Usuario.PermisoEliminarCicloMp
            btnEliminarMp.Enabled = Usuario.PermisoEliminarMp
            btnCambiarTareas.Visible = Usuario.PermisoCambiarTareasMp
            Utilitarios.AplicarTemaModerno(Me)
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
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Agregar Fila)", True, Me)
        End Try

    End Sub

    Private Sub btnDelFila_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelFila.Click
        Dim ind As Integer = 0

        Try
            Select Case TabMp.SelectedTab.Text
                Case "Tareas"
                    With grillaTareasCicloMp
                        If .RowCount > 0 AndAlso .CurrentRow IsNot Nothing Then
                            Dim descTarea As String = If(.CurrentRow.Cells(4).Value Is Nothing OrElse IsDBNull(.CurrentRow.Cells(4).Value), String.Empty, .CurrentRow.Cells(4).Value.ToString())
                            If MsgBox("¿Está seguro de eliminar la tarea: " & descTarea & "?", MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                                Dim idTareaVal As Object = .CurrentRow.Cells(1).Value
                                If idTareaVal IsNot Nothing AndAlso Not IsDBNull(idTareaVal) Then
                                    del_index_tareas.Add(idTareaVal.ToString())
                                End If
                                .Rows.Remove(.CurrentRow)
                                Exit Sub
                            End If
                        ElseIf .RowCount = 0 Then
                            MsgBox("No se pueden eliminar más filas !!!", MsgBoxStyle.Exclamation, "Validación")
                            Exit Sub
                        End If
                    End With

                Case "Personal"
                    With grillaPersonalMp
                        If .RowCount = 0 OrElse .CurrentRow Is Nothing Then
                            MsgBox("No se pueden eliminar más filas !!!", MsgBoxStyle.Exclamation, "Validación")
                            Exit Sub
                        End If
                        If .CurrentRow.Cells(0).Value Is Nothing OrElse IsDBNull(.CurrentRow.Cells(0).Value) OrElse String.IsNullOrWhiteSpace(.CurrentRow.Cells(0).Value.ToString()) Then
                            .Rows.Remove(.CurrentRow)
                            Exit Sub
                        End If
                    End With

                    Dim nomPer As String = If(grillaPersonalMp.CurrentRow.Cells(1).Value Is Nothing OrElse IsDBNull(grillaPersonalMp.CurrentRow.Cells(1).Value), String.Empty, grillaPersonalMp.CurrentRow.Cells(1).Value.ToString())
                    If MsgBox("¿Está seguro que desea eliminar al personal " & nomPer & "?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                        If DS2.Tables.Count > 0 Then
                            Dim rutStr As String = If(grillaPersonalMp.CurrentRow.Cells(0).Value Is Nothing, String.Empty, grillaPersonalMp.CurrentRow.Cells(0).Value.ToString())
                            If rutStr <> "" Then
                                del_index_personal.Add(rutStr)
                                grillaPersonalMp.Rows.Remove(grillaPersonalMp.CurrentRow)
                            End If
                        Else
                            If grillaPersonalMp.RowCount > 0 AndAlso grillaPersonalMp.CurrentRow IsNot Nothing Then
                                grillaPersonalMp.Rows.Remove(grillaPersonalMp.CurrentRow)
                            End If
                        End If
                    End If

                Case "Insumos Utilizados"
                    If grillaInsumosMp.RowCount > 0 AndAlso grillaInsumosMp.CurrentRow IsNot Nothing Then
                        With grillaInsumosMp
                            If .CurrentRow.Cells(3).Value Is Nothing OrElse IsDBNull(.CurrentRow.Cells(3).Value) OrElse String.IsNullOrWhiteSpace(.CurrentRow.Cells(3).Value.ToString()) OrElse
                               .CurrentRow.Cells(4).Value Is Nothing OrElse IsDBNull(.CurrentRow.Cells(4).Value) OrElse String.IsNullOrWhiteSpace(.CurrentRow.Cells(4).Value.ToString()) Then
                                .Rows.Remove(.CurrentRow)
                                Exit Sub
                            End If
                        End With
                        Dim nomIns As String = If(grillaInsumosMp.CurrentRow.Cells(1).Value Is Nothing OrElse IsDBNull(grillaInsumosMp.CurrentRow.Cells(1).Value), String.Empty, grillaInsumosMp.CurrentRow.Cells(1).Value.ToString())
                        If MsgBox("¿Está seguro de eliminar el insumo " & nomIns & "?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                            Dim mant_prev As New MantPreventiva
                            Dim cod_resp As Integer = 0
                            Dim resp As String = ""

                            Dim idInsumo As String = If(grillaInsumosMp.CurrentRow.Cells(0).Value Is Nothing, String.Empty, grillaInsumosMp.CurrentRow.Cells(0).Value.ToString())
                            mant_prev.DelInsumoCicloMp(txtIdMant.Text, txtIdCiclo.Text, idInsumo, cod_resp, resp)

                            If cod_resp = 1 Then
                                MsgBox(resp, MsgBoxStyle.Information, "Validación")
                                grillaInsumosMp.Rows.Remove(grillaInsumosMp.CurrentRow)
                            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                                MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                            End If
                        End If
                    Else
                        MsgBox("No se pueden eliminar más filas !!!", MsgBoxStyle.Exclamation, "Validación")
                    End If
            End Select
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Eliminar Fila)", True, Me)
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
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Nueva MP)", True, Me)
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
        If Not Usuario.PermisoIngMp AndAlso Not Usuario.PermisoGuardarMp Then
            MsgBox("No tiene permisos para crear ciclos.", MsgBoxStyle.Exclamation, "Seguridad")
            Exit Sub
        End If
        Try
            Dim mant_prev As New MantPreventiva
            Dim id_ciclo As Integer = 0

            If String.IsNullOrWhiteSpace(txtIdMant.Text) Then
                MsgBox("Debe buscar una mantención preventiva antes de crear un nuevo ciclo", MsgBoxStyle.Critical, "Validación")
            Else
                id_ciclo = mant_prev.NuevoIdCicloMp(txtIdMant.Text)
                txtIdCiclo.Text = id_ciclo.ToString()
                btnIngMp.Enabled = False
                btnGuardarComoNuevoCiclo.Enabled = False
                txtDuracionCiclo.Text = "0"
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Nuevo Ciclo)", True, Me)
        End Try
    End Sub

    Private Sub btnGuardarMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarMp.Click
        If Not Usuario.PermisoGuardarMp Then
            MsgBox("No tiene permisos para modificar mantenciones preventivas.", MsgBoxStyle.Exclamation, "Seguridad")
            Exit Sub
        End If

        grillaTareasCicloMp.EndEdit()
        grillaPersonalMp.EndEdit()
        grillaInsumosMp.EndEdit()

        Dim mant_prev As New MantPreventiva
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim existe_ciclo_mp As Boolean = False
        Dim resp2 As String = ""
        Dim valida As String = ""

        Try
            valida = mant_prev.ValidarMP()

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
                        For i = 0 To .Rows.Count - 1
                            If .Rows(i).IsNewRow Then Continue For
                            Dim obs_tarea As String = If(.Rows(i).Cells(6).Value Is Nothing OrElse IsDBNull(.Rows(i).Cells(6).Value), "", .Rows(i).Cells(6).Value.ToString())
                            Dim tiempo_tarea As String = If(.Rows(i).Cells(5).Value Is Nothing OrElse IsDBNull(.Rows(i).Cells(5).Value), "0", .Rows(i).Cells(5).Value.ToString())
                            mant_prev.UpdTareasCicloMp(txtIdMant.Text, txtIdCiclo.Text, Convert.ToString(.Rows(i).Cells(1).Value), Convert.ToString(.Rows(i).Cells(2).Value), tiempo_tarea, obs_tarea)
                        Next
                    End If
                End With

                With grillaPersonalMp
                    If .RowCount > 0 Then
                        For i = 0 To .Rows.Count - 1
                            If .Rows(i).IsNewRow Then Continue For
                            Dim rutPer As String = Convert.ToString(.Rows(i).Cells(0).Value)
                            If Not String.IsNullOrWhiteSpace(rutPer) Then
                                mant_prev.UpdPersonalCicloMp(txtIdMant.Text, txtIdCiclo.Text, rutPer)
                            End If
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
                            If .Rows(i).IsNewRow Then Continue For
                            Dim idIns As String = Convert.ToString(.Rows(i).Cells(0).Value)
                            If Not String.IsNullOrWhiteSpace(idIns) Then
                                mant_prev.UpdInsumosCicloMp(txtIdMant.Text, txtIdCiclo.Text, idIns, Convert.ToString(.Rows(i).Cells(3).Value), Convert.ToString(.Rows(i).Cells(4).Value))
                            End If
                        Next
                    End If
                End With

                If cod_resp = 1 Then
                    MsgBox(resp, MsgBoxStyle.Information, "Validación")
                    mant_prev.LimpiarFrmMp()
                ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                    MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                End If
            Else
                MsgBox(valida, MsgBoxStyle.Exclamation, "Validación")
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Guardar)", True, Me)
        End Try
    End Sub

    Private Sub btnBuscarMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMp.Click
        Dim mant_preventiva As New MantPreventiva

        Try
            If id_nodo_select = "" Then
                MsgBox("No se ha seleccionado ningún ítem.", MsgBoxStyle.Exclamation, "Validación")
            Else
                id_nodo_padre = id_nodo_select
                mant_preventiva.CrgNodosHijosMp(id_nodo_padre, DST_NODOS_HIJOS)
                FrmBuscarMp.Show()
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Buscar MP)", True, Me)
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
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Buscar Ciclo)", True, Me)
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
        If Not Usuario.PermisoIngMp Then
            MsgBox("No tiene permisos para ingresar mantenciones preventivas.", MsgBoxStyle.Exclamation, "Seguridad")
            Exit Sub
        End If

        grillaTareasCicloMp.EndEdit()
        grillaPersonalMp.EndEdit()
        grillaInsumosMp.EndEdit()

        Dim mant_prev As New MantPreventiva
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim resp_2 As String = ""
        Dim existe_mp As Boolean = False
        Dim validarForm As Boolean = False

        Try
            validarForm = mant_prev.ValidarIngresoMp(Me, resp)

            If validarForm Then
                existe_mp = mant_prev.BuscarMp(txtIdMant.Text)
                If existe_mp Then
                    MsgBox("La mantención ya existe; para guardar cambios presione Guardar.", MsgBoxStyle.Information, "Validación")
                    Exit Sub
                Else
                    mant_prev.IngMantPreventiva(txtIdMant.Text, id_nodo_select, txtFrecuenciaMp.Text, txtTiempoAviso.Text, cmbEstadoMp.Text, cmbTipoMp.Text, principal.lblUsuario.Text, txtObsMant.Text, cod_resp, resp)
                    If cod_resp <> 1 Then
                        If cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                            MsgBox(resp, MsgBoxStyle.Critical, "Error")
                        End If
                        Exit Sub
                    End If

                    Dim codRespCiclo As Integer = 0
                    mant_prev.IngCicloMp(txtIdMant.Text, txtIdCiclo.Text, FechaIniCiclo.Value, HrInicioCiclo.Value, fechaFinCicloMp.Value, HrFinCiclo.Value, txtDuracionCiclo.Text, txtObsCiclo.Text, cmbEstadoCiclo.Text, principal.lblUsuario.Text, codRespCiclo, resp_2)

                    If grillaPersonalMp.Rows.Count > 0 Then
                        With grillaPersonalMp
                            For i = 0 To .Rows.Count - 1
                                If .Rows(i).IsNewRow Then Continue For
                                Dim rutPer As String = Convert.ToString(.Rows(i).Cells(0).Value)
                                If Not String.IsNullOrWhiteSpace(rutPer) Then
                                    mant_prev.IngPersonalCicloMp(rutPer, txtIdMant.Text, txtIdCiclo.Text)
                                End If
                            Next
                        End With
                    End If

                    If grillaTareasCicloMp.Rows.Count > 0 Then
                        With grillaTareasCicloMp
                            For i = 0 To .Rows.Count - 1
                                If .Rows(i).IsNewRow Then Continue For
                                Dim obs_tarea As String = If(.Rows(i).Cells(6).Value Is Nothing OrElse IsDBNull(.Rows(i).Cells(6).Value), "", .Rows(i).Cells(6).Value.ToString())
                                Dim tiempo_tarea As String = If(.Rows(i).Cells(5).Value Is Nothing OrElse IsDBNull(.Rows(i).Cells(5).Value), "0", .Rows(i).Cells(5).Value.ToString())

                                If True.Equals(.Rows(i).Cells(0).Value) Then
                                    mant_prev.IngTareasCicloMp(txtIdMant.Text, txtIdCiclo.Text, Convert.ToString(.Rows(i).Cells(1).Value), Convert.ToString(.Rows(i).Cells(2).Value), tiempo_tarea, obs_tarea)
                                Else
                                    mant_prev.IngTareasPendCicloMp(txtIdMant.Text, txtIdCiclo.Text, Convert.ToString(.Rows(i).Cells(1).Value), Convert.ToString(.Rows(i).Cells(2).Value), obs_tarea)
                                End If
                            Next
                        End With
                    End If

                    If grillaInsumosMp.RowCount > 0 Then
                        For i = 0 To grillaInsumosMp.RowCount - 1
                            If grillaInsumosMp.Rows(i).IsNewRow Then Continue For
                            Dim idIns As String = Convert.ToString(grillaInsumosMp.Rows(i).Cells(0).Value)
                            If Not String.IsNullOrWhiteSpace(idIns) Then
                                mant_prev.IngInsumosMp(txtIdMant.Text, txtIdCiclo.Text, idIns, Convert.ToString(grillaInsumosMp.Rows(i).Cells(3).Value), Convert.ToString(grillaInsumosMp.Rows(i).Cells(4).Value))
                            End If
                        Next
                    End If

                    If codRespCiclo = 1 Then
                        MsgBox(resp & Chr(13) & resp_2, MsgBoxStyle.Information, "Validación")
                        mant_prev.LimpiarFrmMp()
                    ElseIf codRespCiclo <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp_2) Then
                        MsgBox(resp_2, MsgBoxStyle.Critical, "Error")
                    Else
                        MsgBox(resp, MsgBoxStyle.Information, "Validación")
                        mant_prev.LimpiarFrmMp()
                    End If
                End If
            ElseIf Not String.IsNullOrWhiteSpace(resp) Then
                MsgBox(resp, MsgBoxStyle.Exclamation, "Validación")
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Ingresar MP)", True, Me)
        End Try
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
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Limpiar Ciclo)", True, Me)
        End Try

    End Sub

    Private Sub btnNewCiclo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarComoNuevoCiclo.Click
        If Not Usuario.PermisoIngMp AndAlso Not Usuario.PermisoGuardarMp Then
            MsgBox("No tiene permisos para guardar nuevos ciclos.", MsgBoxStyle.Exclamation, "Seguridad")
            Exit Sub
        End If

        grillaTareasCicloMp.EndEdit()
        grillaPersonalMp.EndEdit()
        grillaInsumosMp.EndEdit()

        Dim mant_prev As New MantPreventiva
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim id_nuevo_ciclo As Integer = 0
        Dim valida As String = ""

        valida = mant_prev.ValidarMP

        If valida = "" Then
            Try
                id_nuevo_ciclo = mant_prev.NuevoIdCicloMp(txtIdMant.Text)
                If id_nuevo_ciclo <= 0 Then
                    MsgBox("No fue posible obtener un identificador para el nuevo ciclo.", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End If

                mant_prev.IngCicloMp(txtIdMant.Text, CStr(id_nuevo_ciclo), FechaIniCiclo.Value, HrInicioCiclo.Value, fechaFinCicloMp.Value, HrFinCiclo.Value, txtDuracionCiclo.Text, txtObsCiclo.Text, cmbEstadoCiclo.Text, principal.lblUsuario.Text, cod_resp, resp)

                If grillaPersonalMp.Rows.Count > 0 Then
                    With grillaPersonalMp
                        For i = 0 To .Rows.Count - 1
                            If .Rows(i).IsNewRow Then Continue For
                            Dim rutPer As String = Convert.ToString(.Rows(i).Cells(0).Value)
                            If Not String.IsNullOrWhiteSpace(rutPer) Then
                                mant_prev.IngPersonalCicloMp(rutPer, txtIdMant.Text, CStr(id_nuevo_ciclo))
                            End If
                        Next
                    End With
                End If

                If grillaTareasCicloMp.Rows.Count > 0 Then
                    With grillaTareasCicloMp
                        For i = 0 To .Rows.Count - 1
                            If .Rows(i).IsNewRow Then Continue For
                            Dim obs_tarea As String = If(.Rows(i).Cells(6).Value Is Nothing OrElse IsDBNull(.Rows(i).Cells(6).Value), "", .Rows(i).Cells(6).Value.ToString())
                            Dim tiempo_tarea As String = If(.Rows(i).Cells(5).Value Is Nothing OrElse IsDBNull(.Rows(i).Cells(5).Value), "0", .Rows(i).Cells(5).Value.ToString())
                            If True.Equals(.Rows(i).Cells(0).Value) Then
                                mant_prev.IngTareasCicloMp(txtIdMant.Text, CStr(id_nuevo_ciclo), Convert.ToString(.Rows(i).Cells(1).Value), Convert.ToString(.Rows(i).Cells(2).Value), tiempo_tarea, obs_tarea)
                            Else
                                mant_prev.IngTareasPendCicloMp(txtIdMant.Text, CStr(id_nuevo_ciclo), Convert.ToString(.Rows(i).Cells(1).Value), Convert.ToString(.Rows(i).Cells(2).Value), obs_tarea)
                            End If
                        Next
                    End With
                End If

                If grillaInsumosMp.RowCount > 0 Then
                    For i = 0 To grillaInsumosMp.RowCount - 1
                        If grillaInsumosMp.Rows(i).IsNewRow Then Continue For
                        Dim idIns As String = Convert.ToString(grillaInsumosMp.Rows(i).Cells(0).Value)
                        If Not String.IsNullOrWhiteSpace(idIns) Then
                            mant_prev.IngInsumosMp(txtIdMant.Text, CStr(id_nuevo_ciclo), idIns, Convert.ToString(grillaInsumosMp.Rows(i).Cells(3).Value), Convert.ToString(grillaInsumosMp.Rows(i).Cells(4).Value))
                        End If
                    Next
                End If

                If cod_resp = 1 Then
                    MsgBox(resp, MsgBoxStyle.Information, "Validación")
                    mant_prev.LimpiarFrmMp()
                ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                    MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                End If
            Catch ex As Exception
                RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Nuevo Ciclo)", True, Me)
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
        If Not Usuario.PermisoEliminarCicloMp Then
            MsgBox("No tiene permisos para eliminar ciclos.", MsgBoxStyle.Exclamation, "Seguridad")
            Exit Sub
        End If
        Try
            If String.IsNullOrWhiteSpace(txtIdMant.Text) OrElse String.IsNullOrWhiteSpace(txtIdCiclo.Text) Then
                MsgBox("Debe desplegar una mantención y un ciclo para eliminar", MsgBoxStyle.Exclamation, "Validación")
                Exit Sub
            End If
            If MsgBox("¿Está seguro que desea eliminar el ciclo N°" & txtIdCiclo.Text & "?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                Dim mant_prev As New MantPreventiva
                Dim cod_resp As Integer = 0
                Dim resp As String = ""

                mant_prev.DelCicloMp(txtIdMant.Text, txtIdCiclo.Text, principal.lblUsuario.Text, cod_resp, resp)

                If cod_resp = 1 Then
                    MsgBox(resp, MsgBoxStyle.Information, "Validación")
                    mant_prev.LimpiarFrmMp()
                ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                    MsgBox(resp, MsgBoxStyle.Critical, "Error")
                End If
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Eliminar Ciclo)", True, Me)
        End Try
    End Sub

    Private Sub btnEliminarMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarMp.Click
        If Not Usuario.PermisoEliminarMp Then
            MsgBox("No tiene permisos para eliminar mantenciones preventivas.", MsgBoxStyle.Exclamation, "Seguridad")
            Exit Sub
        End If
        Try
            If String.IsNullOrWhiteSpace(txtIdMant.Text) Then
                MsgBox("Debe desplegar una mantención preventiva antes de eliminar", MsgBoxStyle.Exclamation, "Validación")
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar la Mantención Preventiva?" & Chr(13) & "Nota: Se eliminará toda la información relacionada con esta mantención." & Chr(13) & "¿Desea continuar?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                Dim mant_prev As New MantPreventiva
                Dim cod_resp As Integer = 0
                Dim resp As String = ""

                mant_prev.DelMantPreventiva(txtIdMant.Text, principal.lblUsuario.Text, cod_resp, resp)

                If cod_resp = 1 Then
                    MsgBox(resp, MsgBoxStyle.Information, "Validación")
                    mant_prev.LimpiarFrmMp()
                ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                    MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                End If
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Eliminar MP)", True, Me)
        End Try
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
                    If Not True.Equals(.Rows(.CurrentRow.Index).Cells(0).Value) Then
                        .Rows(.CurrentRow.Index).Cells(5).Value = 0
                    End If
                End If
            End With
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Grilla Tareas Ciclo MP)", True, Me)
        End Try

    End Sub

    Private Sub GrillasCheck_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grillaTareasCicloMp.CurrentCellDirtyStateChanged, grillaTareasAdMp.CurrentCellDirtyStateChanged
        Dim grilla As DataGridView = TryCast(sender, DataGridView)
        If grilla IsNot Nothing AndAlso grilla.IsCurrentCellDirty Then
            grilla.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub TareasAdMp_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TareasAdMp.Enter
        Try
            If grillaTareasAdMp.DataSource Is Nothing OrElse grillaTareasAdMp.RowCount = 0 Then
                Dim MP As New MantPreventiva
                Dim formato_grid As New FormatoGrillas
                Dim dsTodas As New DataSet

                MP.CrgTareasNodoTodas(dsTodas)
                If dsTodas.Tables.Count > 0 Then
                    grillaTareasAdMp.DataSource = dsTodas.Tables(0)
                    formato_grid.grillasMp(grillaTareasAdMp)
                    filtro_tareas.Table = dsTodas.Tables(0)
                    filtro_tareas.RowFilter = String.Empty
                End If
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Cargar Tareas Adicionales)", True, Me)
        End Try
    End Sub

    Private Sub txtBuscarTarea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarTarea.TextChanged
        Try
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
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Filtrar Tareas)", True, Me)
        End Try
    End Sub

    Private Sub btnAgrTareas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgrTareas.Click
        Try
            grillaTareasAdMp.EndEdit()
            If String.IsNullOrWhiteSpace(id_nodo_select) Then
                MsgBox("Debe seleccionar primero una máquina o nodo en el árbol.", MsgBoxStyle.Exclamation, "Validación")
                Exit Sub
            End If

            Dim seleccionadas As Integer = 0
            For i = 0 To grillaTareasAdMp.RowCount - 1
                If True.Equals(grillaTareasAdMp.Rows(i).Cells(0).Value) Then
                    seleccionadas += 1
                End If
            Next
            If seleccionadas = 0 Then
                MsgBox("Debe marcar al menos una tarea para agregar.", MsgBoxStyle.Exclamation, "Validación")
                Exit Sub
            End If

            If DST_TAREAS.Tables.Count = 0 Then
                Dim grillas As New FormatoGrillas

                Dim dtEsquema As New DataTable("TareasCiclo")
                dtEsquema.Columns.Add("ID Tarea", GetType(Integer))
                dtEsquema.Columns.Add("ID Modulo", GetType(Integer))
                dtEsquema.Columns.Add("Modulo", GetType(String))
                dtEsquema.Columns.Add("Descripcion", GetType(String))
                dtEsquema.Columns.Add("Tiempo Tarea(Min)", GetType(Decimal))
                dtEsquema.Columns.Add("Observación", GetType(String))

                DST_TAREAS.Tables.Clear()
                DST_TAREAS.Tables.Add(dtEsquema)
                grillaTareasCicloMp.DataSource = DST_TAREAS.Tables(0)
                grillas.grillasMp(grillaTareasCicloMp)
            End If

            With grillaTareasAdMp
                For i = 0 To .RowCount - 1
                    If True.Equals(.Rows(i).Cells(0).Value) Then
                        Dim idTareaInt As Integer = Utilitarios.SafeInt(.Rows(i).Cells(1).Value, 0)
                        Dim idModuloInt As Integer = Math.Max(1, Utilitarios.SafeInt(id_nodo_select, 1))
                        If idTareaInt <= 0 Then Continue For

                        Dim existe As Boolean = False
                        For Each rExist As DataRow In DST_TAREAS.Tables(0).Rows
                            If rExist.RowState <> DataRowState.Deleted AndAlso Convert.ToString(rExist(0)) = idTareaInt.ToString() AndAlso Convert.ToString(rExist(1)) = idModuloInt.ToString() Then
                                existe = True
                                Exit For
                            End If
                        Next
                        If existe Then Continue For

                        Dim fila As DataRow = DST_TAREAS.Tables(0).NewRow
                        fila(0) = idTareaInt
                        fila(1) = idModuloInt
                        fila(2) = If(arbol1.SelectedNode IsNot Nothing, arbol1.SelectedNode.Text, "")
                        fila(3) = Utilitarios.CeldaTexto(.Rows(i), 5)
                        fila(4) = 0D
                        fila(5) = String.Empty
                        DST_TAREAS.Tables(0).Rows.Add(fila)
                    End If
                Next
            End With

            MsgBox("Tareas ingresadas", MsgBoxStyle.Information, "Confirmación")
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Agregar Tareas)", True, Me)
        End Try
    End Sub

    Private Sub btn_agr_tareas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agr_tareas.Click
        If id_nodo_select = "" Then
            MsgBox("Debe seleccionar un ítem para buscar las tareas.", MsgBoxStyle.Exclamation, "Validación")
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
        If opc_tareas_mec.Checked AndAlso filtro_tareas.Table IsNot Nothing Then
            filtro_tareas.RowFilter = "Tipo_Mantención = 'Mecanica' "
            grillaTareasAdMp.DataSource = filtro_tareas
            grillaTareasAdMp.Update()
            lblFiltro.Text = "Ingrese el nombre de la tarea"
        End If
    End Sub

    Private Sub Opc_tareas_ele_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Opc_tareas_ele.CheckedChanged
        If Opc_tareas_ele.Checked AndAlso filtro_tareas.Table IsNot Nothing Then
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
        If Not Usuario.PermisoCambiarTareasMp Then
            MsgBox("No tiene permisos para reasignar tareas de MP.", MsgBoxStyle.Exclamation, "Seguridad")
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(id_nodo_select) Then
            MsgBox("Debe seleccionar el nodo de destino en el árbol.", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        grillaTareasCicloMp.EndEdit()

        Try
            Dim mant_prev As New MantPreventiva
            Dim cod_resp As Integer = -1
            Dim resp As String = ""
            Dim procesadas As Integer = 0

            With grillaTareasCicloMp
                If .RowCount > 0 Then
                    For i = 0 To .Rows.Count - 1
                        If .Rows(i).IsNewRow Then Continue For
                        If True.Equals(.Rows(i).Cells(0).Value) Then
                            mant_prev.UpdIdNodoTareasMp(txtIdMant.Text, txtIdCiclo.Text, Convert.ToString(.Rows(i).Cells(1).Value), id_nodo_select, cod_resp, resp)
                            procesadas += 1
                        End If
                    Next
                End If
            End With

            If procesadas = 0 Then
                MsgBox("Debe marcar al menos una tarea para cambiar su ID de nodo.", MsgBoxStyle.Exclamation, "Validación")
            ElseIf cod_resp = 1 OrElse cod_resp = 0 Then
                MsgBox(If(String.IsNullOrWhiteSpace(resp), "Tareas actualizadas correctamente.", resp), MsgBoxStyle.Information, "Validación")
            ElseIf Not String.IsNullOrWhiteSpace(resp) Then
                MsgBox(resp, MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Cambiar Tareas)", True, Me)
        End Try
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
        If Not Usuario.PermisoGuardarMp Then
            MsgBox("No tiene permisos para actualizar mantenciones preventivas.", MsgBoxStyle.Exclamation, "Seguridad")
            Exit Sub
        End If

        Try
            Dim existe_mp As Boolean = False
            Dim mant_prev As New MantPreventiva
            Dim cod_resp As Integer = 0
            Dim resp As String = ""

            If String.IsNullOrWhiteSpace(txtIdMant.Text) Then
                MsgBox("Faltan campos por completar, revise la información de la MP", MsgBoxStyle.Exclamation, "Validación")
                Exit Sub
            End If
            If String.IsNullOrWhiteSpace(id_nodo_select) Then
                MsgBox("Debe seleccionar un nodo o máquina válido en el árbol.", MsgBoxStyle.Exclamation, "Validación")
                Exit Sub
            End If

            existe_mp = mant_prev.BuscarMp(txtIdMant.Text)
            If existe_mp Then
                If txtIdMant.Text <> "" AndAlso txtFrecuenciaMp.Text <> "" AndAlso txtTiempoAviso.Text <> "" Then
                    mant_prev.UpdMantPreventiva(txtIdMant.Text, id_nodo_select, txtFrecuenciaMp.Text, txtTiempoAviso.Text, cmbEstadoMp.Text, cmbTipoMp.Text, principal.lblUsuario.Text, txtObsMant.Text, cod_resp, resp)
                    If cod_resp = 1 Then
                        MsgBox(resp, MsgBoxStyle.Information, "Validación")
                        mant_prev.LimpiarFrmMp()
                    ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                        MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                    End If
                Else
                    MsgBox("Faltan campos por completar, revise la información de la MP", MsgBoxStyle.Exclamation, "Validación")
                End If
            Else
                MsgBox("La mantención preventiva indicada no existe en la base de datos.", MsgBoxStyle.Exclamation, "Validación")
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Actualizar MP)", True, Me)
        End Try
    End Sub

    Private Sub btn_plan_ciclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_plan_ciclos.Click
        Try
            If txtIdMant.Text <> "" AndAlso txtIdCiclo.Text <> "" Then
                Dim mant_preventiva As New MantPreventiva
                Dim ultimo_ciclo As Boolean = mant_preventiva.BuscarUltimoCicloMp(txtIdMant.Text, txtIdCiclo.Text)

                If ultimo_ciclo Then
                    FrmPlanificarCiclos.Show()
                Else
                    MsgBox("Debe desplegar el último ciclo para planificar", MsgBoxStyle.Exclamation, "Validación")
                End If
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Mantención Preventiva (Planificar Ciclos)", True, Me)
        End Try
    End Sub

    Private Sub opc_seccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opc_seccion.CheckedChanged
        lblFiltro.Text = "Ingrese el nombre de la sección"
    End Sub

    Private Sub opc_mod_maq_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opc_mod_maq.CheckedChanged
        lblFiltro.Text = "Ingrese el nombre de la máquina"
    End Sub
End Class
