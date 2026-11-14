Public Class FrmAdminTareasNodo
    Public id_nodo_select As String
    Public nombre_nodo_select As String
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Public DST_TN As New DataSet
    Public form_limpio As Boolean = False
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
        Dim nodo As New Nodo
        txtIdTarea.Text = nodo.NuevoIdTareaNodo
        txtDescTarea.ResetText()
        txtOrdenDespliegue.ResetText()
        If cmbTipoMP.Items.Count > 0 Then cmbTipoMP.SelectedIndex = 0
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim nodo As New Nodo
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim formato_grid As New FormatoGrillas

        If txtIdTarea.Text = "" Or txtDescTarea.Text = "" Or txtOrdenDespliegue.Text = "" Or txtOrdenDespliegue.Text = "0" Then
            MsgBox("Debe generar el codigo de la tarea o ingresar la descripción", MsgBoxStyle.Exclamation, "Validación")
            txtDescTarea.Focus()
        ElseIf txtIdModulo.Text = "" Then
            MsgBox("Debe Seleccionar el modulo o la maquina antes de guardar", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        Else
            nodo.IngTareaNodo(txtIdTarea.Text, txtIdModulo.Text, txtDescTarea.Text, cmbTipoMP.Text, CInt(txtOrdenDespliegue.Text), principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MsgBox(resp, MsgBoxStyle.Information, "Validación")
                grillaTareasNodo.DataSource = Nothing
                grillaTareasNodo.Columns.Clear()
                DST_TN.Tables.Clear()
                nodo.CRG_TAREAS_NODO(id_nodo_select, cmbTipoMP.Text, DST_TN)
                grillaTareasNodo.DataSource = DST_TN.Tables(0)
                formato_grid.grillasTareasNodo(grillaTareasNodo)
                Utilitarios.AjustarColumnasGrilla(grillaTareasNodo)
                txtIdTarea.ResetText()
                txtDescTarea.ResetText()
                txtIdModulo.ResetText()
                txtOrdenDespliegue.ResetText()
                form_limpio = True
            Else
                MsgBox(resp, MsgBoxStyle.Critical, "Validación")
            End If
        End If
    End Sub

    Private Sub grillaTareasNodo_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaTareasNodo.CellContentDoubleClick
        If e.RowIndex < 0 OrElse grillaTareasNodo.CurrentRow Is Nothing Then Exit Sub
        Try
            With grillaTareasNodo
                txtIdTarea.Text = .Rows(e.RowIndex).Cells(0).Value
                txtDescTarea.Text = .Rows(e.RowIndex).Cells(3).Value
                txtOrdenDespliegue.Text = .Rows(e.RowIndex).Cells(5).Value
                cmbTipoMP.Text = .Rows(e.RowIndex).Cells(4).Value
                txtIdModulo.Text = .Rows(e.RowIndex).Cells(1).Value
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Validación")
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnElimTarea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnElimTarea.Click
        Dim nodo As New Nodo
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim formato_grid As New FormatoGrillas

        If txtIdTarea.Text = "" Then
            MsgBox("Debe desplegar una tarea en el recuadro antes de eliminar", MsgBoxStyle.Exclamation, "Validación")
        Else
            If MsgBox("¿Esta seguro de Elimnar la tarea: " & txtIdTarea.Text, MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
                nodo.DelTareaNodo(txtIdTarea.Text, principal.lblUsuario.Text, cod_resp, resp)

                If cod_resp = 1 Then
                    MsgBox(resp, MsgBoxStyle.Information, "Validación")
                    grillaTareasNodo.DataSource = Nothing
                    DST_TN.Tables.Clear()
                    nodo.CRG_TAREAS_NODO(id_nodo_select, cmbTipoMP.Text, DST_TN)
                    grillaTareasNodo.DataSource = DST_TN.Tables(0)
                    formato_grid.grillasTareasNodo(grillaTareasNodo)
                    Utilitarios.AjustarColumnasGrilla(grillaTareasNodo)
                    txtIdTarea.ResetText()
                    txtDescTarea.ResetText()
                    form_limpio = True
                Else
                    MsgBox(resp, MsgBoxStyle.Exclamation, "Validación")
                End If
            End If
        End If
        
    End Sub

    Private Sub btn_buscar_tarea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_tarea.Click
        Dim nodo As New Nodo
        Dim formato_grid As New FormatoGrillas

        DST_TN.Tables.Clear()
        grillaTareasNodo.DataSource = Nothing
        grillaTareasNodo.Columns.Clear()
        nodo.CRG_TAREAS_NODO(id_nodo_select, cmbTipoMP.Text, DST_TN)

        Try
            grillaTareasNodo.DataSource = DST_TN.Tables(0)
            formato_grid.grillasTareasNodo(grillaTareasNodo)
            Utilitarios.AjustarColumnasGrilla(grillaTareasNodo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
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
        Dim nodo As New Nodo
        Dim cod_resp As Integer
        Dim resp As String = ""

        With grillaTareasNodo
            If .RowCount > 0 Then

                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Cells(6).Value Then
                        nodo.IngTareaNodo(.Rows(i).Cells(0).Value, id_nodo_select, .Rows(i).Cells(3).Value, .Rows(i).Cells(4).Value, .Rows(i).Cells(5).Value, principal.lblUsuario.Text, cod_resp, resp)
                    End If

                Next
            End If

        End With

        If cod_resp = 1 Then
            MsgBox(resp, MsgBoxStyle.Information, "Validación")
        End If
    End Sub
End Class