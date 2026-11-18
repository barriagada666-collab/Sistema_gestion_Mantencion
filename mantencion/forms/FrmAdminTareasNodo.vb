Public Class FrmAdminTareasNodo
    Public id_nodo_select As String = String.Empty
    Public nombre_nodo_select As String = String.Empty
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Public DST_TN As New DataSet
    Public form_limpio As Boolean = False

    Private Shared Function CeldaSeguro(ByVal cell As DataGridViewCell) As String
        If cell Is Nothing OrElse cell.Value Is Nothing OrElse IsDBNull(cell.Value) Then Return String.Empty
        Return cell.Value.ToString().Trim()
    End Function

    Private Sub FrmAdminTareasNodo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Dim nd As New Nodo
            Dim nodoRaiz As New TreeNode
            Dim MP As New MantPreventiva

            nodoRaiz.Name = "1"
            nodoRaiz.Text = "Cambiaso Hnos S.A."
            nd.CRG_NODO_HIJO(nodoRaiz)
            arbol6.BeginUpdate()
            arbol6.Nodes.Clear()
            arbol6.Nodes.Add(nodoRaiz)
            arbol6.EndUpdate()
            MP.CrgCmbTipoMp(cmbTipoMP)
            btnCambiarIDMod.Visible = Usuario.PermisoCambiarIdModTareas
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Tareas de Nodos/Máquinas (Carga Inicial)", True, Me)
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub arbol6_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles arbol6.AfterSelect
        If arbol6.SelectedNode Is Nothing Then Exit Sub
        id_nodo_select = arbol6.SelectedNode.Name
        nodo_anterior2 = id_nodo_select
        txtIdModulo.Text = id_nodo_select
        arbol6.SelectedNode.BackColor = Utilitarios.ColorSeleccion
    End Sub

    Private Sub btnNuevaTarea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaTarea.Click
        Try
            Dim nodo As New Nodo
            txtIdTarea.Text = nodo.NuevoIdTareaNodo.ToString()
            txtDescTarea.ResetText()
            txtOrdenDespliegue.ResetText()
            If cmbTipoMP.Items.Count > 0 Then cmbTipoMP.SelectedIndex = 0
            txtDescTarea.Focus()
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Tareas de Nodos/Máquinas (Nueva Tarea)", True, Me)
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim ordenDespliegue As Integer = 0
        If String.IsNullOrWhiteSpace(txtIdTarea.Text) OrElse String.IsNullOrWhiteSpace(txtDescTarea.Text) OrElse String.IsNullOrWhiteSpace(txtOrdenDespliegue.Text) Then
            MessageBox.Show(Me, "Debe generar el código de la tarea e ingresar su descripción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescTarea.Focus()
            Exit Sub
        ElseIf Not Integer.TryParse(txtOrdenDespliegue.Text.Trim(), ordenDespliegue) OrElse ordenDespliegue <= 0 Then
            MessageBox.Show(Me, "El orden de despliegue debe ser un número entero mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtOrdenDespliegue.Focus()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtIdModulo.Text) Then
            MessageBox.Show(Me, "Debe seleccionar el módulo o la máquina antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Try
            Dim nodo As New Nodo
            Dim cod_resp As Integer = 0
            Dim resp As String = ""
            Dim formato_grid As New FormatoGrillas

            nodo.IngTareaNodo(txtIdTarea.Text.Trim(), txtIdModulo.Text.Trim(), txtDescTarea.Text.Trim(), cmbTipoMP.Text, ordenDespliegue, principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MessageBox.Show(Me, resp, "Tareas Nodo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                grillaTareasNodo.DataSource = Nothing
                grillaTareasNodo.Columns.Clear()
                DST_TN.Tables.Clear()
                nodo.CRG_TAREAS_NODO(id_nodo_select, cmbTipoMP.Text, DST_TN)
                If DST_TN.Tables.Count > 0 Then
                    grillaTareasNodo.DataSource = DST_TN.Tables(0)
                    formato_grid.grillasTareasNodo(grillaTareasNodo)
                    Utilitarios.AjustarColumnasGrilla(grillaTareasNodo)
                End If
                txtIdTarea.ResetText()
                txtDescTarea.ResetText()
                txtIdModulo.ResetText()
                txtOrdenDespliegue.ResetText()
                form_limpio = True
            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Tareas de Nodos/Máquinas (Guardar)", True, Me)
        End Try
    End Sub

    Private Sub grillaTareasNodo_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaTareasNodo.CellDoubleClick
        If e.RowIndex < 0 OrElse e.RowIndex >= grillaTareasNodo.RowCount Then Exit Sub
        Try
            Dim row = grillaTareasNodo.Rows(e.RowIndex)
            If row Is Nothing OrElse row.IsNewRow OrElse grillaTareasNodo.Columns.Count < 6 Then Exit Sub
            txtIdTarea.Text = CeldaSeguro(row.Cells(0))
            txtIdModulo.Text = CeldaSeguro(row.Cells(1))
            txtDescTarea.Text = CeldaSeguro(row.Cells(3))
            cmbTipoMP.Text = CeldaSeguro(row.Cells(4))
            txtOrdenDespliegue.Text = CeldaSeguro(row.Cells(5))
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Tareas de Nodos/Máquinas (Grilla Tareas Nodo)", True, Me)
        End Try
    End Sub

    Private Sub grillaTareasNodo_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grillaTareasNodo.CurrentCellDirtyStateChanged
        If grillaTareasNodo.IsCurrentCellDirty Then
            grillaTareasNodo.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnElimTarea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnElimTarea.Click
        If String.IsNullOrWhiteSpace(txtIdTarea.Text) Then
            MessageBox.Show(Me, "Debe seleccionar una tarea antes de eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If MessageBox.Show(Me, "¿Está seguro de eliminar la tarea " & txtIdTarea.Text.Trim() & "?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
            Exit Sub
        End If

        Try
            Dim nodo As New Nodo
            Dim cod_resp As Integer = 0
            Dim resp As String = ""
            Dim formato_grid As New FormatoGrillas

            nodo.DelTareaNodo(txtIdTarea.Text.Trim(), principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MessageBox.Show(Me, resp, "Tareas Nodo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                grillaTareasNodo.DataSource = Nothing
                DST_TN.Tables.Clear()
                If Not String.IsNullOrWhiteSpace(id_nodo_select) Then
                    nodo.CRG_TAREAS_NODO(id_nodo_select, cmbTipoMP.Text, DST_TN)
                    If DST_TN.Tables.Count > 0 Then
                        grillaTareasNodo.DataSource = DST_TN.Tables(0)
                        formato_grid.grillasTareasNodo(grillaTareasNodo)
                        Utilitarios.AjustarColumnasGrilla(grillaTareasNodo)
                    End If
                End If
                txtIdTarea.ResetText()
                txtDescTarea.ResetText()
                form_limpio = True
            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Tareas de Nodos/Máquinas (Eliminar)", True, Me)
        End Try
    End Sub

    Private Sub btn_buscar_tarea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_tarea.Click
        If String.IsNullOrWhiteSpace(id_nodo_select) Then
            MessageBox.Show(Me, "Debe seleccionar un nodo o máquina del árbol antes de buscar tareas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Try
            Dim nodo As New Nodo
            Dim formato_grid As New FormatoGrillas

            DST_TN.Tables.Clear()
            grillaTareasNodo.DataSource = Nothing
            grillaTareasNodo.Columns.Clear()
            nodo.CRG_TAREAS_NODO(id_nodo_select, cmbTipoMP.Text, DST_TN)

            If DST_TN.Tables.Count > 0 Then
                grillaTareasNodo.DataSource = DST_TN.Tables(0)
                formato_grid.grillasTareasNodo(grillaTareasNodo)
                Utilitarios.AjustarColumnasGrilla(grillaTareasNodo)
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Tareas de Nodos/Máquinas (Buscar Tarea)", True, Me)
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Sub txtOrdenDespliegue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrdenDespliegue.KeyPress
        Dim utilitarios As New Utilitarios
        utilitarios.solonumeros(e)
    End Sub

    Private Sub txtBuscarNodoIt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarNodoIt.KeyUp
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(arbol6, txtBuscarNodoIt, e, id_nodo_select, nodo_anterior, 2)
    End Sub

    Private Sub txtBuscarNodoIt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarNodoIt.TextChanged
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(arbol6, txtBuscarNodoIt, Nothing, id_nodo_select, nodo_anterior, 2)
    End Sub

    Private Sub arbol6_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles arbol6.BeforeSelect
        Nodo.LimpiarResaltadoNodos(arbol6.Nodes)
    End Sub

    Private Sub arbol6_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles arbol6.Enter
        If form_limpio AndAlso arbol6.SelectedNode IsNot Nothing Then
            id_nodo_select = arbol6.SelectedNode.Name
            nodo_anterior2 = id_nodo_select
            arbol6.SelectedNode.BackColor = Utilitarios.ColorSeleccion
        End If
    End Sub

    Private Sub btnCambiarIDMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiarIDMod.Click
        If Not Usuario.PermisoCambiarIdModTareas Then
            MessageBox.Show(Me, "No tiene permisos para reasignar el módulo de tareas.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(id_nodo_select) Then
            MessageBox.Show(Me, "Debe seleccionar el nodo de destino antes de cambiar el módulo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If grillaTareasNodo.IsCurrentCellInEditMode Then
            grillaTareasNodo.EndEdit()
        End If

        Try
            Dim nodo As New Nodo
            Dim actualizadas As Integer = 0
            Dim huboError As Boolean = False
            Dim ultimoMsg As String = String.Empty

            With grillaTareasNodo
                If .RowCount > 0 AndAlso .Columns.Count >= 7 Then
                    For i As Integer = 0 To .Rows.Count - 1
                        Dim row = .Rows(i)
                        If row.IsNewRow Then Continue For
                        Dim selObj As Object = row.Cells(6).Value
                        If selObj Is Nothing OrElse IsDBNull(selObj) OrElse Not Convert.ToBoolean(selObj) Then Continue For

                        Dim idTarea As String = CeldaSeguro(row.Cells(0))
                        Dim descTarea As String = CeldaSeguro(row.Cells(3))
                        Dim tipoMp As String = CeldaSeguro(row.Cells(4))
                        Dim ordenVal As Integer = 0
                        Integer.TryParse(CeldaSeguro(row.Cells(5)), ordenVal)
                        Dim cod_resp As Integer = 0
                        Dim resp As String = ""

                        nodo.IngTareaNodo(idTarea, id_nodo_select, descTarea, tipoMp, ordenVal, principal.lblUsuario.Text, cod_resp, resp)
                        If cod_resp = 1 Then
                            actualizadas += 1
                            ultimoMsg = resp
                        Else
                            huboError = True
                            If Not String.IsNullOrWhiteSpace(resp) Then ultimoMsg = resp
                        End If
                    Next
                End If
            End With

            If actualizadas = 0 AndAlso Not huboError Then
                MessageBox.Show(Me, "Seleccione al menos una tarea marcando su casilla antes de aplicar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf Not huboError Then
                MessageBox.Show(Me, ultimoMsg, "Tareas Nodo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Not String.IsNullOrWhiteSpace(ultimoMsg) Then
                MessageBox.Show(Me, ultimoMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Tareas de Nodos/Máquinas (Cambiar Módulo)", True, Me)
        End Try
    End Sub
End Class
