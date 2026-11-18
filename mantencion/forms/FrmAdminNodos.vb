Public Class FrmAdminNodos
    Public nivel_nodo_padre As Integer = 0
    Public id_nodo_padre As String = ""
    Public id_nodo_select As String = ""
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Public ds_arbol As DataSet
    Public form_limpio As Boolean = False

    Private Shared Function FilaABooleanSeguro(ByVal val As Object) As Boolean
        If val Is Nothing OrElse IsDBNull(val) Then Return False
        Dim b As Boolean = False
        If Boolean.TryParse(val.ToString().Trim(), b) Then Return b
        Return val.ToString().Trim() = "1"
    End Function

    Private Sub PoblarDetalleNodoDesdeFila(ByVal fila As DataRow)
        If fila Is Nothing Then Exit Sub
        txtCodRmes.Text = If(IsDBNull(fila.Item("cod_rmes")), String.Empty, fila.Item("cod_rmes").ToString())
        If FilaABooleanSeguro(fila.Item("estado_nodo")) Then
            opcActivado.Checked = True
        Else
            opcDesactivado.Checked = True
        End If
        Utilitarios.AsignarFechaSegura(fecha_instalacion2, fila.Item("fecha_instalacion"), DateTime.Today)
        txtPrioridad2.Text = If(IsDBNull(fila.Item("prioridad")), "0", fila.Item("prioridad").ToString())
        txtCodSap2.Text = If(IsDBNull(fila.Item("codigo_sap")), String.Empty, fila.Item("codigo_sap").ToString())
        cmbGrupoNodo2.Text = If(IsDBNull(fila.Item("grupo")), String.Empty, fila.Item("grupo").ToString())

        If FilaABooleanSeguro(fila.Item("aplica_mantencion")) Then
            opcAplicaMantSi2.Checked = True
        Else
            opcAplicaMantNo2.Checked = True
        End If
    End Sub

    Private Sub FrmAdminNodos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Dim nd As New Nodo
            Dim nodoRaiz As New TreeNode

            GrpInfoNuevoNodo.Enabled = False
            ds_arbol = nd.CRG_NODOS_DST()
            If ds_arbol IsNot Nothing AndAlso ds_arbol.Tables.Count > 0 AndAlso ds_arbol.Tables(0).Columns.Contains("idnodo") Then
                ds_arbol.Tables(0).PrimaryKey = New DataColumn() {ds_arbol.Tables(0).Columns("idnodo")}
            End If
            arbol4.BeginUpdate()
            arbol4.Nodes.Clear()
            nodoRaiz.Name = "1"
            nodoRaiz.Text = "Cambiaso Hnos S.A."
            nd.CRG_NODO_HIJO_TODOS(nodoRaiz)
            arbol4.Nodes.Add(nodoRaiz)
            arbol4.EndUpdate()
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Administración de Nodos (Carga Inicial)", True, Me)
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub btnNuevoNodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoNodo.Click
        If String.IsNullOrWhiteSpace(txtIDNodoSel.Text) Then
            MessageBox.Show(Me, "Debe seleccionar un nodo padre para crear un nuevo nodo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            arbol4.Focus()
        Else
            If Not GrpInfoNuevoNodo.Enabled Then
                GrpInfoNuevoNodo.Enabled = True
                If cmbGrupoNodo.Items.Count > 0 Then cmbGrupoNodo.SelectedIndex = 0
            End If

            Dim NODO As New Nodo
            txtIDNuevoNodo.Text = NODO.NUEVO_ID_NODO.ToString()
            GrpNodoPadre.Enabled = False
        End If
    End Sub

    Private Sub arbol4_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles arbol4.AfterSelect
        If arbol4.SelectedNode Is Nothing Then Exit Sub
        If arbol4.SelectedNode.Name <> "1" AndAlso arbol4.SelectedNode.Parent IsNot Nothing Then
            id_nodo_padre = arbol4.SelectedNode.Parent.Name
        End If
        id_nodo_select = arbol4.SelectedNode.Name
        nodo_anterior2 = id_nodo_select
        arbol4.SelectedNode.BackColor = Utilitarios.ColorSeleccion

        txtIDNodoSel.Text = arbol4.SelectedNode.Name
        txtDescNodoSel.Text = arbol4.SelectedNode.Text
        nivel_nodo_padre = arbol4.SelectedNode.Level

        If ds_arbol IsNot Nothing AndAlso ds_arbol.Tables.Count > 0 AndAlso ds_arbol.Tables(0).PrimaryKey IsNot Nothing AndAlso ds_arbol.Tables(0).PrimaryKey.Length > 0 Then
            Dim pkType As Type = ds_arbol.Tables(0).PrimaryKey(0).DataType
            Dim claveBuscada As Object = txtIDNodoSel.Text
            If pkType Is GetType(Integer) Then
                Dim idInt As Integer = 0
                If Integer.TryParse(txtIDNodoSel.Text.Trim(), idInt) Then claveBuscada = idInt
            End If
            Dim fila As DataRow = ds_arbol.Tables(0).Rows.Find(claveBuscada)
            PoblarDetalleNodoDesdeFila(fila)
        End If
    End Sub

    Private Sub btnSalirNodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirNodos.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim nodo As New Nodo
            Dim cod_resp As Integer = 0
            Dim resp As String = ""

            If GrpInfoNuevoNodo.Enabled AndAlso Not chkModPadre.Checked Then
                Dim resp_ing_nodo As String = nodo.ValidarIngresoNodo()
                If String.IsNullOrEmpty(resp_ing_nodo) Then
                    Dim existe_nodo As String = nodo.BuscarNodo(txtIDNuevoNodo.Text.Trim())
                    If String.IsNullOrEmpty(existe_nodo) Then
                        Dim estado_nodo As Boolean = opcNuevoNodoAct.Checked
                        Dim aplica_mant As Boolean = opcAplicaMantSi.Checked
                        nodo.IngNodo(txtIDNuevoNodo.Text.Trim(), txtIDNodoSel.Text.Trim(), txtDescNuevoNodo.Text.Trim(), (nivel_nodo_padre + 1).ToString(), estado_nodo, txtCodRmesNodoNuevo.Text.Trim(), principal.lblUsuario.Text, fecha_instalacion.Value, txtPrioridad.Text.Trim(), txtCodSap.Text.Trim(), aplica_mant, cmbGrupoNodo.Text, cod_resp, resp)

                        If cod_resp = 1 Then
                            FrmResumenes.InvalidarCacheJerarquia()
                            MessageBox.Show(Me, resp, "Nodos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            nodo.LimpiarFormNodos()
                        ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                            MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show(Me, "El ID de nodo ya existe en el sistema: " & existe_nodo, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show(Me, resp_ing_nodo, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            ElseIf chkModPadre.Checked Then
                If String.IsNullOrWhiteSpace(txtIDNuevoNodo.Text) OrElse String.IsNullOrWhiteSpace(txtIDNodoSel.Text) OrElse String.IsNullOrWhiteSpace(txtDescNuevoNodo.Text) Then
                    MessageBox.Show(Me, "Debe seleccionar el nuevo nodo padre en el árbol antes de guardar el traslado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                Dim estado_nodo As Boolean = opcNuevoNodoAct.Checked
                Dim aplica_mant As Boolean = opcAplicaMantSi.Checked
                nodo.UpdNodo(txtIDNuevoNodo.Text.Trim(), txtIDNodoSel.Text.Trim(), txtDescNuevoNodo.Text.Trim(), (nivel_nodo_padre + 1).ToString(), estado_nodo, txtCodRmesNodoNuevo.Text.Trim(), principal.lblUsuario.Text, fecha_instalacion.Value, txtPrioridad.Text.Trim(), txtCodSap.Text.Trim(), aplica_mant, cmbGrupoNodo.Text, cod_resp, resp)

                If cod_resp = 1 Then
                    FrmResumenes.InvalidarCacheJerarquia()
                    MessageBox.Show(Me, resp, "Nodos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    nodo.LimpiarFormNodos()
                ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                    MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                Dim resp_act_nodo As String = nodo.ValidarActualizacionNodo()
                If String.IsNullOrEmpty(resp_act_nodo) Then
                    Dim estado_nodo As Boolean = opcActivado.Checked
                    Dim aplica_mant As Boolean = opcAplicaMantSi2.Checked
                    nodo.UpdNodo(txtIDNodoSel.Text.Trim(), id_nodo_padre, txtDescNodoSel.Text.Trim(), nivel_nodo_padre.ToString(), estado_nodo, txtCodRmes.Text.Trim(), principal.lblUsuario.Text, fecha_instalacion2.Value, txtPrioridad2.Text.Trim(), txtCodSap2.Text.Trim(), aplica_mant, cmbGrupoNodo2.Text, cod_resp, resp)

                    If cod_resp = 1 Then
                        FrmResumenes.InvalidarCacheJerarquia()
                        MessageBox.Show(Me, resp, "Nodos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        nodo.LimpiarFormNodos()
                    ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(resp) Then
                        MessageBox.Show(Me, resp, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show(Me, resp_act_nodo, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Administración de Nodos (Guardar)", True, Me)
        End Try
    End Sub

    Private Sub btnLimpiarNodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarNodo.Click
        Dim nodo As New Nodo
        nodo.LimpiarFormNodos()
    End Sub

    Private Sub chkModPadre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkModPadre.CheckedChanged
        If chkModPadre.Checked Then
            If Not String.IsNullOrWhiteSpace(txtIDNodoSel.Text) AndAlso Not String.IsNullOrWhiteSpace(txtDescNodoSel.Text) Then
                txtIDNuevoNodo.Text = txtIDNodoSel.Text
                txtIDNodoSel.ResetText()
                txtDescNuevoNodo.Text = txtDescNodoSel.Text
                txtDescNodoSel.ResetText()
                txtCodRmesNodoNuevo.Text = txtCodRmes.Text
                txtCodRmes.ResetText()
                fecha_instalacion.Value = fecha_instalacion2.Value
                txtPrioridad.Text = txtPrioridad2.Text
                txtPrioridad2.ResetText()
                txtCodSap.Text = txtCodSap2.Text
                txtCodSap2.ResetText()
                cmbGrupoNodo.Text = cmbGrupoNodo2.Text
                GrpInfoNuevoNodo.Enabled = False
                If opcActivado.Checked Then opcNuevoNodoAct.Checked = True Else opcNuevoNodoDesac.Checked = True
                If opcAplicaMantSi2.Checked Then opcAplicaMantSi.Checked = True Else opcAplicaMantNo.Checked = True
            End If
        ElseIf Not String.IsNullOrWhiteSpace(txtIDNuevoNodo.Text) Then
            txtIDNodoSel.Text = txtIDNuevoNodo.Text
            txtIDNuevoNodo.ResetText()
            txtDescNodoSel.Text = txtDescNuevoNodo.Text
            txtDescNuevoNodo.ResetText()
            txtCodRmes.Text = txtCodRmesNodoNuevo.Text
            txtCodRmesNodoNuevo.ResetText()
            fecha_instalacion2.Value = fecha_instalacion.Value
            txtPrioridad2.Text = txtPrioridad.Text
            txtPrioridad.ResetText()
            txtCodSap2.Text = txtCodSap.Text
            txtCodSap.ResetText()
            cmbGrupoNodo2.Text = cmbGrupoNodo.Text
            If opcNuevoNodoAct.Checked Then opcActivado.Checked = True Else opcDesactivado.Checked = True
            If opcAplicaMantSi.Checked Then opcAplicaMantSi2.Checked = True Else opcAplicaMantNo2.Checked = True
        End If
    End Sub

    Private Sub arbol4_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles arbol4.BeforeSelect
        Nodo.LimpiarResaltadoNodos(arbol4.Nodes)
    End Sub

    Private Sub arbol4_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles arbol4.Enter
        Try
            If form_limpio Then
                Dim nd As New Nodo
                ds_arbol = nd.CRG_NODOS_DST()
                If arbol4.SelectedNode IsNot Nothing Then
                    If arbol4.SelectedNode.Name <> "1" AndAlso arbol4.SelectedNode.Parent IsNot Nothing Then
                        id_nodo_padre = arbol4.SelectedNode.Parent.Name
                    End If
                    id_nodo_select = arbol4.SelectedNode.Name
                    nodo_anterior2 = id_nodo_select
                    arbol4.SelectedNode.BackColor = Utilitarios.ColorSeleccion

                    txtIDNodoSel.Text = arbol4.SelectedNode.Name
                    txtDescNodoSel.Text = arbol4.SelectedNode.Text
                    nivel_nodo_padre = arbol4.SelectedNode.Level

                    If ds_arbol IsNot Nothing AndAlso ds_arbol.Tables.Count > 0 AndAlso ds_arbol.Tables(0).Columns.Contains("idnodo") Then
                        Dim columna_clave(0) As DataColumn
                        columna_clave(0) = ds_arbol.Tables(0).Columns("idnodo")
                        ds_arbol.Tables(0).PrimaryKey = columna_clave
                        Dim fila As DataRow = ds_arbol.Tables(0).Rows.Find(txtIDNodoSel.Text)
                        PoblarDetalleNodoDesdeFila(fila)
                    End If
                End If
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Administración de Nodos (Refrescar Selección)", True, Me)
        End Try
    End Sub

    Private Sub txtBuscarNodoNd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarNodoNd.KeyUp
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(arbol4, txtBuscarNodoNd, e, id_nodo_select, nodo_anterior, 1)
    End Sub

    Private Sub txtBuscarNodoNd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarNodoNd.TextChanged
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(arbol4, txtBuscarNodoNd, Nothing, id_nodo_select, nodo_anterior, 1)
    End Sub

    Private Sub txtPrioridad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrioridad.KeyPress, txtPrioridad2.KeyPress
        Dim utilitario As New Utilitarios
        utilitario.solonumeros(e)
    End Sub

    Private Sub btnDatosTecnicos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatosTecnicos.Click
        If String.IsNullOrWhiteSpace(id_nodo_select) OrElse arbol4.SelectedNode Is Nothing Then
            MessageBox.Show(Me, "Debe seleccionar un ítem del árbol antes de ver los datos técnicos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            FrmVerDatosTecnicos.id_nodo = id_nodo_select
            FrmVerDatosTecnicos.nivel = arbol4.SelectedNode.Level
            FrmVerDatosTecnicos.Text = "Datos Técnicos - " & arbol4.SelectedNode.Text
            FrmVerDatosTecnicos.Show()
        End If
    End Sub
End Class
