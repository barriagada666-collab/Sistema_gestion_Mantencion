Public Class FrmAdminNodos
    Public nivel_nodo_padre As Integer = 0
    Public id_nodo_padre As String = ""
    Public id_nodo_select As String = ""
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Public ds_arbol As DataSet
    Public form_limpio As Boolean = False
    Private Sub FrmAdminNodos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nd As New Nodo
        Dim nodoRaiz As New TreeNode
        Dim grillas As New FormatoGrillas

        GrpInfoNuevoNodo.Enabled = False
        ds_arbol = nd.CRG_NODOS_DST()
        arbol4.BeginUpdate()
        nodoRaiz.Name = "1"
        nodoRaiz.Text = "Cambiaso Hnos S.A."
        nd.CRG_NODO_HIJO_TODOS(nodoRaiz)
        arbol4.Nodes.Add(nodoRaiz)
        arbol4.EndUpdate()
    End Sub

    Private Sub btnNuevoNodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoNodo.Click
        If txtIDNodoSel.Text = "" Then
            MsgBox("Debe Seleccionar un nodo padre para crear un nuevo nodo !!!", MsgBoxStyle.Exclamation, "Validación")
            arbol4.Focus()
        Else
            If GrpInfoNuevoNodo.Enabled = False Then
                GrpInfoNuevoNodo.Enabled = True
                cmbGrupoNodo.Text = cmbGrupoNodo.Items(0)
            End If

            Dim NODO As New Nodo
            txtIDNuevoNodo.Text = NODO.NUEVO_ID_NODO
            GrpNodoPadre.Enabled = False
        End If
    End Sub

    Private Sub arbol4_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles arbol4.AfterSelect
        If arbol4.SelectedNode Is Nothing Then Exit Sub
        Dim nodo As New Nodo
        Dim fila As DataRow
        Dim columna_clave(0) As DataColumn

        If arbol4.SelectedNode.Name <> 1 AndAlso arbol4.SelectedNode.Parent IsNot Nothing Then
            id_nodo_padre = arbol4.SelectedNode.Parent.Name
        End If
        id_nodo_select = arbol4.SelectedNode.Name
        nodo_anterior2 = id_nodo_select
        arbol4.SelectedNode.BackColor = Utilitarios.ColorSeleccion
        
        txtIDNodoSel.Text = arbol4.SelectedNode.Name
        txtDescNodoSel.Text = arbol4.SelectedNode.Text
        nivel_nodo_padre = arbol4.SelectedNode.Level

        If ds_arbol IsNot Nothing AndAlso ds_arbol.Tables.Count > 0 Then
            columna_clave(0) = ds_arbol.Tables(0).Columns("idnodo")
            ds_arbol.Tables(0).PrimaryKey = columna_clave
            fila = ds_arbol.Tables(0).Rows.Find(txtIDNodoSel.Text)
            If fila IsNot Nothing Then
                txtCodRmes.Text = fila.Item("cod_rmes").ToString
                If fila.Item("estado_nodo").ToString = True Then
                    opcActivado.Checked = True
                Else
                    opcDesactivado.Checked = True
                End If
                ' Asignación segura de fecha de instalación
                Utilitarios.AsignarFechaSegura(fecha_instalacion2, fila.Item("fecha_instalacion"), DateTime.Today)
                txtPrioridad2.Text = fila.Item("prioridad").ToString
                txtCodSap2.Text = fila.Item("codigo_sap").ToString
                cmbGrupoNodo2.Text = fila.Item("grupo").ToString

                If fila.Item("aplica_mantencion").ToString = True Then
                    opcAplicaMantSi2.Checked = True
                Else
                    opcAplicaMantNo2.Checked = True
                End If
            End If
        End If
        
    End Sub

    Private Sub btnSalirNodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirNodos.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim nodo As New Nodo
        Dim estado_nodo As Boolean = False
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim existe_nodo As String = ""
        Dim aplica_mant As Boolean = False

        If GrpInfoNuevoNodo.Enabled And chkModPadre.Checked = False Then
            Dim resp_ing_nodo As String = ""

            resp_ing_nodo = nodo.ValidarIngresoNodo
            If resp_ing_nodo = "" Then
                existe_nodo = nodo.BuscarNodo(txtIDNuevoNodo.Text)
                If existe_nodo = "" Then
                    If opcNuevoNodoAct.Checked Then
                        estado_nodo = True
                    End If

                    If opcAplicaMantSi.Checked Then
                        aplica_mant = True
                    End If
                    nodo.IngNodo(txtIDNuevoNodo.Text, txtIDNodoSel.Text, txtDescNuevoNodo.Text, nivel_nodo_padre + 1, estado_nodo, txtCodRmesNodoNuevo.Text, principal.lblUsuario.Text, fecha_instalacion.Value, txtPrioridad.Text, txtCodSap.Text, aplica_mant, cmbGrupoNodo.Text, cod_resp, resp)

                    If cod_resp = 1 Then
                        MsgBox(resp, MsgBoxStyle.Information, "Validación")
                        nodo.LimpiarFormNodos()
                    Else
                        MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                    End If
                End If
            Else
                MsgBox(resp_ing_nodo, MsgBoxStyle.Critical, "Validación")
            End If
            
        Else
            If chkModPadre.Checked = True Then
                If opcActivado.Checked Then
                    estado_nodo = True
                End If

                If opcAplicaMantSi.Checked Then
                    aplica_mant = True
                End If

                nodo.UpdNodo(txtIDNuevoNodo.Text, txtIDNodoSel.Text, txtDescNuevoNodo.Text, nivel_nodo_padre + 1, estado_nodo, txtCodRmesNodoNuevo.Text, principal.lblUsuario.Text, fecha_instalacion.Value, txtPrioridad.Text, txtCodSap.Text, aplica_mant, cmbGrupoNodo.Text, cod_resp, resp)

                If cod_resp = 1 Then
                    MsgBox(resp, MsgBoxStyle.Information, "Validación")
                    nodo.LimpiarFormNodos()
                Else
                    MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                End If
            Else
                Dim resp_act_nodo As String = ""
                resp_act_nodo = nodo.ValidarActualizacionNodo

                If resp_act_nodo = "" Then
                    If opcActivado.Checked Then
                        estado_nodo = True
                    End If

                    If opcAplicaMantSi2.Checked Then
                        aplica_mant = True
                    End If

                    nodo.UpdNodo(txtIDNodoSel.Text, id_nodo_padre, txtDescNodoSel.Text, nivel_nodo_padre, estado_nodo, txtCodRmes.Text, principal.lblUsuario.Text, fecha_instalacion2.Value, txtPrioridad2.Text, txtCodSap2.Text, aplica_mant, cmbGrupoNodo2.Text, cod_resp, resp)

                    If cod_resp = 1 Then
                        MsgBox(resp, MsgBoxStyle.Information, "Validación")
                        nodo.LimpiarFormNodos()
                    Else
                        MsgBox(resp, MsgBoxStyle.Critical, "Validación")
                    End If
                Else
                    MsgBox(resp_act_nodo, MsgBoxStyle.Critical, "Validación")
                End If
            End If
        End If
    End Sub

    Private Sub btnLimpiarNodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarNodo.Click
        Dim nodo As New Nodo
        nodo.LimpiarFormNodos()
    End Sub

    Private Sub chkModPadre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkModPadre.CheckedChanged
        If txtIDNodoSel.Text <> "" And txtDescNodoSel.Text <> "" Then
            If chkModPadre.Checked Then
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
                If opcActivado.Checked Then
                    opcNuevoNodoAct.Checked = True
                Else
                    opcNuevoNodoDesac.Checked = True
                End If
                If opcAplicaMantSi2.Checked Then
                    opcAplicaMantSi.Checked = True
                Else
                    opcAplicaMantNo.Checked = True
                End If
            Else
                txtIDNodoSel.Text = txtIDNuevoNodo.Text
                txtIDNuevoNodo.ResetText()
                txtDescNodoSel.Text = txtDescNuevoNodo.Text
                txtDescNuevoNodo.ResetText()
                txtCodRmes.Text = txtCodRmesNodoNuevo.Text
                txtCodRmesNodoNuevo.ResetText()
                If opcNuevoNodoAct.Checked Then
                    opcActivado.Checked = True
                Else
                    opcDesactivado.Checked = True
                End If
            End If
        End If
    End Sub

    Private Sub arbol4_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles arbol4.BeforeSelect
        Nodo.LimpiarResaltadoNodos(arbol4.Nodes)
    End Sub

    Private Sub arbol4_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles arbol4.Enter
        Dim nd As New Nodo

        ds_arbol = nd.CRG_NODOS_DST

        If form_limpio AndAlso arbol4.SelectedNode IsNot Nothing Then
            Dim nodo As New Nodo
            Dim fila As DataRow
            Dim columna_clave(0) As DataColumn

            If arbol4.SelectedNode.Name <> 1 AndAlso arbol4.SelectedNode.Parent IsNot Nothing Then
                id_nodo_padre = arbol4.SelectedNode.Parent.Name
            End If
            id_nodo_select = arbol4.SelectedNode.Name
            nodo_anterior2 = id_nodo_select
            arbol4.SelectedNode.BackColor = Utilitarios.ColorSeleccion

            txtIDNodoSel.Text = arbol4.SelectedNode.Name
            txtDescNodoSel.Text = arbol4.SelectedNode.Text
            nivel_nodo_padre = arbol4.SelectedNode.Level

            If ds_arbol IsNot Nothing AndAlso ds_arbol.Tables.Count > 0 Then
                columna_clave(0) = ds_arbol.Tables(0).Columns("idnodo")
                ds_arbol.Tables(0).PrimaryKey = columna_clave
                fila = ds_arbol.Tables(0).Rows.Find(txtIDNodoSel.Text)
                If fila IsNot Nothing Then
                    txtCodRmes.Text = fila.Item("cod_rmes").ToString

                    If fila.Item("estado_nodo").ToString = True Then
                        opcActivado.Checked = True
                    Else
                        opcDesactivado.Checked = True
                    End If

                    ' Asignación segura de fecha de instalación
                    Utilitarios.AsignarFechaSegura(fecha_instalacion2, fila.Item("fecha_instalacion"), DateTime.Today)
                    txtPrioridad2.Text = fila.Item("prioridad").ToString
                    txtCodSap2.Text = fila.Item("codigo_sap").ToString
                    cmbGrupoNodo2.Text = fila.Item("grupo").ToString

                    If fila.Item("aplica_mantencion").ToString = True Then
                        opcAplicaMantSi2.Checked = True
                    Else
                        opcAplicaMantNo2.Checked = True
                    End If
                End If
            End If
        End If
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

    Private Sub txtPrioridad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrioridad.KeyPress
        Dim utilitario As New Utilitarios
        utilitario.solonumeros(e)
    End Sub

    Private Sub txtPrioridad2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrioridad2.KeyPress
        Dim utilitario As New Utilitarios
        utilitario.solonumeros(e)
    End Sub

    Private Sub btnDatosTecnicos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatosTecnicos.Click
        If id_nodo_select = "" Then
            MsgBox("Debe seleccionar un item del arbol antes de ver los datos técnicos", MsgBoxStyle.Exclamation, "Validación")
        Else
            FrmVerDatosTecnicos.id_nodo = id_nodo_select
            FrmVerDatosTecnicos.nivel = arbol4.SelectedNode.Level
            FrmVerDatosTecnicos.Text = FrmVerDatosTecnicos.Text & " " & arbol4.SelectedNode.Text
            FrmVerDatosTecnicos.Show()
        End If
    End Sub
End Class