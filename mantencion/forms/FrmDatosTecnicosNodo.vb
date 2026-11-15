Public Class FrmDatosTecnicosNodo
    Public id_nodo_select As String
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

    Private Sub FrmDatosTecnicosNodo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Dim nodo As New Nodo
        Dim datos_tecnicos As New DatosTecnicos
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
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(arbol9, txtBuscarArbol, e, id_nodo_select, nodo_anterior, 2)
    End Sub

    Private Sub btnGuardarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDatos.Click
        Dim datos_tecnicos As New DatosTecnicos
        Dim respuesta As Integer = 0
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim resp2 As String = ""
        Dim DST_DATOS_TECNICOS As New DataSet
        Dim formato_grid As New FormatoGrillas
        Dim cont_ing As Integer = 0
        Dim cont_upd As Integer = 0
        Dim cont_del As Integer = 0
        Dim resp3 As String = ""

        If id_nodo_select = "" Then
            MsgBox("Debe Seleccionar un item del arbol antes de guardar", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        'Validacion valor dato tecnico antes de guardar,si esta uno o varios en blanco entrega un mensaje
        datos_tecnicos.ValidarIngDatosTecnicosNodo(resp)

        If resp = "" Then
            With grillaDatosTecnicosNodo
                For i = 0 To .RowCount - 1
                    respuesta = datos_tecnicos.BuscarIdDatoTecnicoNodo(.Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value)
                    If respuesta = 0 Then
                        If nivel >= 3 Then
                            datos_tecnicos.IngDatoTecnicoNodo(.Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, Trim(.Rows(i).Cells(4).Value), principal.lblUsuario.Text, cod_resp, resp)
                            cont_ing = cont_ing + 1

                        ElseIf nivel = 2 Then
                            datos_tecnicos.IngDatoTecnicoNodo(.Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, Trim(.Rows(i).Cells(5).Value), principal.lblUsuario.Text, cod_resp, resp)
                            cont_ing = cont_ing + 1

                        ElseIf nivel = 1 Then
                            datos_tecnicos.IngDatoTecnicoNodo(.Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, Trim(.Rows(i).Cells(6).Value), principal.lblUsuario.Text, cod_resp, resp)
                            cont_ing = cont_ing + 1
                        End If
                       
                    ElseIf respuesta = 1 Then
                        If nivel >= 3 Then
                            datos_tecnicos.UpdDatoTecnicoNodo(.Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, Trim(.Rows(i).Cells(4).Value), principal.lblUsuario.Text, cod_resp, resp2)
                            cont_upd = cont_upd + 1

                        ElseIf nivel = 2 Then
                            datos_tecnicos.UpdDatoTecnicoNodo(.Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, Trim(.Rows(i).Cells(5).Value), principal.lblUsuario.Text, cod_resp, resp2)
                            cont_upd = cont_upd + 1

                        ElseIf nivel = 1 Then
                            datos_tecnicos.UpdDatoTecnicoNodo(.Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, Trim(.Rows(i).Cells(6).Value), principal.lblUsuario.Text, cod_resp, resp2)
                            cont_upd = cont_upd + 1

                        End If
                        
                    End If
                Next

                If del_dato_tecnico.Length > 0 Then
                    For i = 0 To del_dato_tecnico.GetUpperBound(0)
                        If del_dato_tecnico(i, 0) <> 0 Then
                            datos_tecnicos.DelDatoTecnicoNodo(CStr(del_dato_tecnico(i, 0)), CStr(del_dato_tecnico(i, 1)), principal.lblUsuario.Text, cod_resp, resp3)
                            cont_del = cont_del + 1
                        Else
                            Exit For
                        End If
                    Next
                End If
            End With

            If cod_resp = 1 Then
                Try
                    resp = "Registros Ingresados:"
                    resp2 = "Registros Modificados:"
                    resp3 = "Registros Eliminados:"
                    MsgBox(resp & " " & cont_ing & Chr(13) & resp2 & " " & cont_upd & Chr(13) & resp3 & " " & cont_del, MsgBoxStyle.Information, "Confirmación")
                    datos_tecnicos.LimpiarFrmDatosTecnicosNodo()
                    cont_del = 0
                    cont_ing = 0
                    cont_upd = 0
                Catch ex As Exception
                    RegistroErrores.MostrarYRegistrar(ex, "Datos Técnicos por Nodo (Guardar Datos)", True, Me)
                End Try

            Else
                MsgBox(resp, MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox(resp, MsgBoxStyle.Exclamation, "Validación")
        End If
       
    End Sub

    Private Sub btnBuscarDatoTecnico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDatoTecnico.Click
        Dim datos_tecnicos As New DatosTecnicos
        Dim formato_grid As New FormatoGrillas
        Dim columna_clave(0) As DataColumn

        If id_nodo_select = "" Then
            MsgBox("Debe seleccionar un item del arbol antes de buscar", MsgBoxStyle.Exclamation, "Validacion")
            Exit Sub
        End If

        If DST_NODOS.Tables.Count > 0 AndAlso DST_NODOS.Tables(0).Columns.Contains("idnodo") Then
            columna_clave(0) = DST_NODOS.Tables(0).Columns("idnodo")
            DST_NODOS.Tables(0).PrimaryKey = columna_clave
            fila = DST_NODOS.Tables(0).Rows.Find(id_nodo_select)
        End If

        nivel = arbol9.SelectedNode.Level
        DST_DATOS_TECNICOS_NODO.Tables.Clear()
        datos_tecnicos.CrgDatosTecnicosNodo(id_nodo_select, nivel, DST_DATOS_TECNICOS_NODO)

        Try
            grillaDatosTecnicosNodo.SuspendLayout()
            grillaDatosTecnicosNodo.Columns.Clear()
            If DST_DATOS_TECNICOS_NODO.Tables.Count > 0 Then
                grillaDatosTecnicosNodo.DataSource = DST_DATOS_TECNICOS_NODO.Tables(0)
                filtro_datos_tecnicos.Table = DST_DATOS_TECNICOS_NODO.Tables(0)
                formato_grid.grillaDatosTecnicos(grillaDatosTecnicosNodo)
                lblGrillaDatosTecnicos.Text = "Datos Técnicos Asociados a " & arbol9.SelectedNode.Text
                grpFiltroDatosTecnicos.Enabled = True
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Datos Técnicos por Nodo (Buscar Dato Técnico)", True, Me)
        Finally
            grillaDatosTecnicosNodo.ResumeLayout(False)
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
        FrmBuscarDatosTecnicos.nombre_form = Me.Name
        FrmBuscarDatosTecnicos.Show()
    End Sub

    Private Sub btnEliminarDatoTecnico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarDatoTecnico.Click
        Dim id_dato_tecnico As Integer = 0
        Dim id_nodo As Integer = 0

        With grillaDatosTecnicosNodo
            If .CurrentRow Is Nothing OrElse .CurrentRow.IsNewRow Then
                MsgBox("Debe seleccionar una fila válida antes de eliminar.", MsgBoxStyle.Exclamation, "Validación")
                Exit Sub
            End If
            If MsgBox("¿Esta seguro de eliminar el dato tecnico :" & Convert.ToString(.CurrentRow.Cells(3).Value) & " ?", MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                Try
                    id_dato_tecnico = CInt(.CurrentRow.Cells(0).Value)
                    id_nodo = CInt(.CurrentRow.Cells(1).Value)

                    If fila_del_dato_tecnico <= del_dato_tecnico.GetUpperBound(0) Then
                        del_dato_tecnico(fila_del_dato_tecnico, 0) = id_dato_tecnico
                        del_dato_tecnico(fila_del_dato_tecnico, 1) = id_nodo
                        fila_del_dato_tecnico = fila_del_dato_tecnico + 1
                    End If
                    .Rows.Remove(.CurrentRow)
                Catch ex As Exception
                    RegistroErrores.MostrarYRegistrar(ex, "Datos Técnicos por Nodo (Eliminar Dato Técnico)", True, Me)
                End Try

            End If
        End With

    End Sub

    Private Sub txtFiltroDescDatoTecnico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltroDescDatoTecnico.TextChanged
        Try
            Dim valorLimpio As String = Utilitarios.EscaparLike(txtFiltroDescDatoTecnico.Text.Trim())
            If nivel >= 3 Then
                filtro_datos_tecnicos.RowFilter = "[" & grillaDatosTecnicosNodo.Columns(3).Name & "] like '%" & valorLimpio & "%'"
            ElseIf nivel = 2 Then
                filtro_datos_tecnicos.RowFilter = "[" & grillaDatosTecnicosNodo.Columns(4).Name & "] like '%" & valorLimpio & "%'"
            ElseIf nivel = 1 Then
                filtro_datos_tecnicos.RowFilter = "[" & grillaDatosTecnicosNodo.Columns(5).Name & "] like '%" & valorLimpio & "%'"
            End If
            grillaDatosTecnicosNodo.DataSource = filtro_datos_tecnicos
            Utilitarios.AjustarColumnasGrilla(grillaDatosTecnicosNodo)
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
            Dim valorLimpio As String = Utilitarios.EscaparLike(cmbGrupoDatoTecnico.Text.Trim())
            If nivel >= 3 Then
                filtro_datos_tecnicos.RowFilter = "[" & grillaDatosTecnicosNodo.Columns(5).Name & "] like '%" & valorLimpio & "%'"
            ElseIf nivel = 2 Then
                filtro_datos_tecnicos.RowFilter = "[" & grillaDatosTecnicosNodo.Columns(6).Name & "] like '%" & valorLimpio & "%'"
            ElseIf nivel = 1 Then
                filtro_datos_tecnicos.RowFilter = "[" & grillaDatosTecnicosNodo.Columns(7).Name & "] like '%" & valorLimpio & "%'"
            End If
            grillaDatosTecnicosNodo.DataSource = filtro_datos_tecnicos
            Utilitarios.AjustarColumnasGrilla(grillaDatosTecnicosNodo)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Datos Técnicos por Nodo (Combo Grupo Dato Técnico)", True, Me)
        End Try
    End Sub
End Class