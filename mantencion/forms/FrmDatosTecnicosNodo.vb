Public Class FrmDatosTecnicosNodo
    Public id_nodo_select As String = String.Empty
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Public nivel As Integer = 0
    Public form_limpio As Boolean = False
    Public DST_DATOS_TECNICOS_NODO As New DataSet
    Public DST_NODOS As New DataSet
    Public filtro_datos_tecnicos As New DataView
    Public del_dato_tecnico(200, 2) As Integer
    Public fila_del_dato_tecnico As Integer = 0
    Public fila As DataRow
    Private ReadOnly _colaEliminaciones As New List(Of Tuple(Of Integer, Integer))()

    Public Sub LimpiarColaEliminaciones()
        _colaEliminaciones.Clear()
    End Sub

    Private Shared Function CeldaTextoSeguro(ByVal cell As DataGridViewCell) As String
        If cell Is Nothing OrElse cell.Value Is Nothing OrElse IsDBNull(cell.Value) Then Return String.Empty
        Return cell.Value.ToString().Trim()
    End Function

    Private Sub FrmDatosTecnicosNodo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Dim nodo As New Nodo
        Dim formato_grid As New FormatoGrillas
        Dim nodoRaiz As New TreeNode

        Try
            arbol9.BeginUpdate()
            nodoRaiz.Name = "1"
            nodoRaiz.Text = "Cambiaso Hnos S.A."
            nodo.CRG_NODO_HIJO(nodoRaiz)
            arbol9.Nodes.Add(nodoRaiz)
            nivel = 3
            formato_grid.grillaDatosTecnicos(grillaDatosTecnicosNodo)
            grpFiltroDatosTecnicos.Enabled = False
            DST_NODOS = nodo.CRG_NODOS_DST()
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Datos Técnicos por Nodo (Carga Inicial)", True, Me)
        Finally
            arbol9.EndUpdate()
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub arbol9_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles arbol9.AfterSelect
        If arbol9.SelectedNode Is Nothing Then Exit Sub
        id_nodo_select = arbol9.SelectedNode.Name
        nodo_anterior2 = id_nodo_select
        arbol9.SelectedNode.BackColor = Utilitarios.ColorSeleccion
    End Sub

    Private Sub arbol9_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles arbol9.BeforeSelect
        Nodo.LimpiarResaltadoNodos(arbol9.Nodes)
    End Sub

    Private Sub arbol9_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles arbol9.Enter
        If form_limpio AndAlso arbol9.SelectedNode IsNot Nothing Then
            id_nodo_select = arbol9.SelectedNode.Name
            nodo_anterior2 = id_nodo_select
            arbol9.SelectedNode.BackColor = Utilitarios.ColorSeleccion
        End If
    End Sub

    Private Sub txtBuscarArbol_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarArbol.KeyUp
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(arbol9, txtBuscarArbol, e, id_nodo_select, nodo_anterior, 2)
    End Sub

    Private Sub btnGuardarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDatos.Click
        If String.IsNullOrWhiteSpace(id_nodo_select) Then
            MessageBox.Show(Me, "Debe seleccionar un ítem del árbol antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If grillaDatosTecnicosNodo.IsCurrentCellInEditMode Then
            grillaDatosTecnicosNodo.EndEdit()
        End If

        Dim datos_tecnicos As New DatosTecnicos
        Dim respValid As String = ""
        datos_tecnicos.ValidarIngDatosTecnicosNodo(respValid)
        If Not String.IsNullOrEmpty(respValid) Then
            MessageBox.Show(Me, respValid, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Try
            Dim cont_ing As Integer = 0
            Dim cont_upd As Integer = 0
            Dim cont_del As Integer = 0
            Dim ultimaRespError As String = String.Empty
            Dim huboError As Boolean = False
            Dim colValor As Integer = If(nivel >= 3, 4, If(nivel = 2, 5, 6))

            With grillaDatosTecnicosNodo
                For i As Integer = 0 To .RowCount - 1
                    Dim row = .Rows(i)
                    If row.IsNewRow Then Continue For
                    Dim idDt As String = CeldaTextoSeguro(row.Cells(0))
                    Dim idNd As String = CeldaTextoSeguro(row.Cells(1))
                    Dim valorDt As String = If(.Columns.Count > colValor, CeldaTextoSeguro(row.Cells(colValor)), String.Empty)
                    If String.IsNullOrEmpty(idDt) OrElse String.IsNullOrEmpty(idNd) Then Continue For

                    Dim cod_resp As Integer = 0
                    Dim resp As String = ""
                    Dim existe As Integer = datos_tecnicos.BuscarIdDatoTecnicoNodo(idDt, idNd)
                    If existe = 0 Then
                        datos_tecnicos.IngDatoTecnicoNodo(idDt, idNd, valorDt, principal.lblUsuario.Text, cod_resp, resp)
                        If cod_resp = 1 Then cont_ing += 1 Else huboError = True : ultimaRespError = resp
                    Else
                        datos_tecnicos.UpdDatoTecnicoNodo(idDt, idNd, valorDt, principal.lblUsuario.Text, cod_resp, resp)
                        If cod_resp = 1 Then cont_upd += 1 Else huboError = True : ultimaRespError = resp
                    End If
                Next
            End With

            If _colaEliminaciones.Count > 0 Then
                For Each item In _colaEliminaciones
                    Dim codDel As Integer = 0
                    Dim respDel As String = ""
                    datos_tecnicos.DelDatoTecnicoNodo(item.Item1.ToString(), item.Item2.ToString(), principal.lblUsuario.Text, codDel, respDel)
                    If codDel = 1 Then cont_del += 1 Else huboError = True : ultimaRespError = respDel
                Next
            ElseIf del_dato_tecnico IsNot Nothing AndAlso del_dato_tecnico.Length > 0 Then
                For i As Integer = 0 To del_dato_tecnico.GetUpperBound(0)
                    If del_dato_tecnico(i, 0) <> 0 Then
                        Dim codDel As Integer = 0
                        Dim respDel As String = ""
                        datos_tecnicos.DelDatoTecnicoNodo(CStr(del_dato_tecnico(i, 0)), CStr(del_dato_tecnico(i, 1)), principal.lblUsuario.Text, codDel, respDel)
                        If codDel = 1 Then cont_del += 1 Else huboError = True : ultimaRespError = respDel
                    Else
                        Exit For
                    End If
                Next
            End If

            If Not huboError AndAlso (cont_ing + cont_upd + cont_del) > 0 Then
                MessageBox.Show(Me, String.Format("Registros Ingresados: {0}{3}Registros Modificados: {1}{3}Registros Eliminados: {2}", cont_ing, cont_upd, cont_del, Environment.NewLine), "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                datos_tecnicos.LimpiarFrmDatosTecnicosNodo()
            ElseIf huboError AndAlso Not String.IsNullOrWhiteSpace(ultimaRespError) Then
                MessageBox.Show(Me, ultimaRespError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf (cont_ing + cont_upd + cont_del) = 0 Then
                MessageBox.Show(Me, "No hay cambios para guardar en el nodo seleccionado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Datos Técnicos por Nodo (Guardar Datos)", True, Me)
        End Try
    End Sub

    Private Sub btnBuscarDatoTecnico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDatoTecnico.Click
        If String.IsNullOrWhiteSpace(id_nodo_select) OrElse arbol9.SelectedNode Is Nothing Then
            MessageBox.Show(Me, "Debe seleccionar un ítem del árbol antes de buscar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Try
            Dim datos_tecnicos As New DatosTecnicos
            Dim formato_grid As New FormatoGrillas

            nivel = arbol9.SelectedNode.Level
            DST_DATOS_TECNICOS_NODO.Tables.Clear()
            datos_tecnicos.CrgDatosTecnicosNodo(id_nodo_select, nivel, DST_DATOS_TECNICOS_NODO)

            grillaDatosTecnicosNodo.SuspendLayout()
            Try
                grillaDatosTecnicosNodo.Columns.Clear()
                If DST_DATOS_TECNICOS_NODO.Tables.Count > 0 Then
                    filtro_datos_tecnicos = New DataView(DST_DATOS_TECNICOS_NODO.Tables(0))
                    grillaDatosTecnicosNodo.DataSource = filtro_datos_tecnicos
                    formato_grid.grillaDatosTecnicos(grillaDatosTecnicosNodo)
                    Utilitarios.AjustarColumnasGrilla(grillaDatosTecnicosNodo)
                    lblGrillaDatosTecnicos.Text = "Datos Técnicos Asociados a " & arbol9.SelectedNode.Text
                    grpFiltroDatosTecnicos.Enabled = True
                End If
            Finally
                grillaDatosTecnicosNodo.ResumeLayout(False)
            End Try
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Datos Técnicos por Nodo (Buscar Dato Técnico)", True, Me)
        End Try
    End Sub

    Private Sub btnSalirDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirDatos.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarDatos.Click
        Dim datos_tecnicos As New DatosTecnicos
        datos_tecnicos.LimpiarFrmDatosTecnicosNodo()
    End Sub

    Private Sub btnAgrDatosTecnicos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgrDatosTecnicos.Click
        If String.IsNullOrWhiteSpace(id_nodo_select) OrElse arbol9.SelectedNode Is Nothing Then
            MessageBox.Show(Me, "Seleccione un nodo del árbol y presione Buscar antes de agregar datos técnicos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        FrmBuscarDatosTecnicos.nombre_form = Me.Name
        FrmBuscarDatosTecnicos.Show()
    End Sub

    Private Sub btnEliminarDatoTecnico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarDatoTecnico.Click
        With grillaDatosTecnicosNodo
            If .CurrentRow Is Nothing OrElse .CurrentRow.IsNewRow Then
                MessageBox.Show(Me, "Debe seleccionar una fila válida antes de eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Dim descCol As String = If(.Columns.Count > 3, CeldaTextoSeguro(.CurrentRow.Cells(3)), String.Empty)
            If MessageBox.Show(Me, "¿Está seguro de eliminar el dato técnico '" & descCol & "'?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try
                    Dim id_dato_tecnico As Integer = 0
                    Dim id_nodo As Integer = 0
                    Integer.TryParse(CeldaTextoSeguro(.CurrentRow.Cells(0)), id_dato_tecnico)
                    Integer.TryParse(CeldaTextoSeguro(.CurrentRow.Cells(1)), id_nodo)

                    If id_dato_tecnico > 0 AndAlso id_nodo > 0 Then
                        _colaEliminaciones.Add(Tuple.Create(id_dato_tecnico, id_nodo))
                        If fila_del_dato_tecnico <= del_dato_tecnico.GetUpperBound(0) Then
                            del_dato_tecnico(fila_del_dato_tecnico, 0) = id_dato_tecnico
                            del_dato_tecnico(fila_del_dato_tecnico, 1) = id_nodo
                            fila_del_dato_tecnico += 1
                        End If
                    End If
                    .Rows.Remove(.CurrentRow)
                Catch ex As Exception
                    RegistroErrores.MostrarYRegistrar(ex, "Datos Técnicos por Nodo (Eliminar Dato Técnico)", True, Me)
                End Try
            End If
        End With
    End Sub

    Private Sub AplicarFiltrosDatosTecnicos()
        If filtro_datos_tecnicos Is Nothing OrElse filtro_datos_tecnicos.Table Is Nothing Then Exit Sub
        Dim colDescIdx As Integer = If(nivel >= 3, 3, If(nivel = 2, 4, 5))
        Dim colGrupoIdx As Integer = If(nivel >= 3, 5, If(nivel = 2, 6, 7))
        If grillaDatosTecnicosNodo.Columns.Count <= Math.Max(colDescIdx, colGrupoIdx) Then Exit Sub

        Dim partes As New List(Of String)()
        Dim qDesc As String = Utilitarios.EscaparLike(txtFiltroDescDatoTecnico.Text.Trim())
        If Not String.IsNullOrEmpty(qDesc) Then
            partes.Add("[" & grillaDatosTecnicosNodo.Columns(colDescIdx).Name & "] LIKE '%" & qDesc & "%'")
        End If
        Dim qGrupo As String = Utilitarios.EscaparLike(cmbGrupoDatoTecnico.Text.Trim())
        If Not String.IsNullOrEmpty(qGrupo) AndAlso Not qGrupo.Equals("Todos", StringComparison.OrdinalIgnoreCase) Then
            partes.Add("[" & grillaDatosTecnicosNodo.Columns(colGrupoIdx).Name & "] LIKE '%" & qGrupo & "%'")
        End If

        filtro_datos_tecnicos.RowFilter = String.Join(" AND ", partes)
        grillaDatosTecnicosNodo.DataSource = filtro_datos_tecnicos
        Utilitarios.AjustarColumnasGrilla(grillaDatosTecnicosNodo)
    End Sub

    Private Sub txtFiltroDescDatoTecnico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltroDescDatoTecnico.TextChanged
        Try
            AplicarFiltrosDatosTecnicos()
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Datos Técnicos por Nodo (Filtro Descripción Dato Técnico)", True, Me)
        End Try
    End Sub

    Private Sub btnExpotarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpotarExcel.Click
        Dim informes As New Informes
        Try
            informes.expInfDatosTecnicos(grillaDatosTecnicosNodo)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Datos Técnicos por Nodo (Exportar Excel)", True, Me)
        End Try
    End Sub

    Private Sub cmbGrupoDatoTecnico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrupoDatoTecnico.SelectedIndexChanged
        Try
            AplicarFiltrosDatosTecnicos()
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Datos Técnicos por Nodo (Combo Grupo Dato Técnico)", True, Me)
        End Try
    End Sub
End Class
