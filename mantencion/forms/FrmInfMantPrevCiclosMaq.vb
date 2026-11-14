Public Class FrmInfMantPrevCiclosMaq
    Public id_nodo_mp_select As String = ""
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Private Sub FrmInfMantPrevCiclosMaq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Dim nd As New Nodo
        Dim nodoRaiz As New TreeNode
        Dim mant_preventiva As New MantPreventiva
        Try
            Arbol7.BeginUpdate()
            nodoRaiz.Name = "1"
            nodoRaiz.Text = "Cambiaso Hnos S.A."
            nd.CRG_NODO_HIJO(nodoRaiz)
            Arbol7.Nodes.Add(nodoRaiz)
            mant_preventiva.CrgCmbTipoMpGantt(cmbTipoMpGantt)
            Utilitarios.AplicarTemaModerno(Me)
        Finally
            Arbol7.EndUpdate()
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub Arbol7_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Arbol7.AfterSelect
        If Arbol7.SelectedNode Is Nothing Then Exit Sub
        id_nodo_mp_select = Arbol7.SelectedNode.Name
        nodo_anterior2 = id_nodo_mp_select
        Arbol7.SelectedNode.BackColor = Utilitarios.ColorSeleccion
    End Sub

    Private Sub btnSalirInfMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirInfMp.Click
        Me.Close()
    End Sub

    Private Sub btnBuscarCiclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCiclos.Click
        Dim mant_prev As New MantPreventiva
        Dim DS_CICLOS As New DataSet
        Dim formato_grid As New FormatoGrillas

        If String.IsNullOrEmpty(id_nodo_mp_select) OrElse id_nodo_mp_select = "0" Then
            MsgBox("Debe elegir un item para buscar los ciclos", MsgBoxStyle.Exclamation, "Validación")
        Else
            Cursor = Cursors.WaitCursor
            Try
                mant_prev.InfCiclosMaquinasMp(id_nodo_mp_select, fecha_ini_inf_mp.Value, fecha_fin_inf_mp.Value, cmbTipoMpGantt.Text, DS_CICLOS)
                If DS_CICLOS.Tables.Count > 0 Then
                    grillaCiclosMaquinas.DataSource = DS_CICLOS.Tables(0)
                    formato_grid.grillasMp(grillaCiclosMaquinas)
                    Utilitarios.AjustarColumnasGrilla(grillaCiclosMaquinas)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Finally
                Cursor = Cursors.Default
                Utilitarios.OptimizarMemoria()
            End Try
        End If
    End Sub

    Private Sub btnExpGantt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpGantt.Click
        If grillaCiclosMaquinas.RowCount > 0 Then
            FrmCartaGantt.form = Me.Name
            If Arbol7.SelectedNode IsNot Nothing Then
                FrmCartaGantt.item_gantt = Arbol7.SelectedNode.Text
            End If
            FrmCartaGantt.Show()
        Else
            MsgBox("Debe desplegar ciclos antes de exportar a informe gantt", MsgBoxStyle.Exclamation, "validación")
        End If

    End Sub

    Private Sub Arbol7_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles Arbol7.BeforeSelect
        Nodo.LimpiarResaltadoNodos(Arbol7.Nodes)
    End Sub

    Private Sub txtBuscarNodo7_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarNodo7.KeyUp
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(Arbol7, txtBuscarNodo7, e, id_nodo_mp_select, nodo_anterior, 2)
    End Sub

    Private Sub txtBuscarNodo7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarNodo7.TextChanged
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(Arbol7, txtBuscarNodo7, Nothing, id_nodo_mp_select, nodo_anterior, 2)
    End Sub

    Private Sub btnExpListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpListado.Click
        Dim informe As New Informes

        Try
            If grillaCiclosMaquinas.RowCount = 0 Then
                MsgBox("Debe realizar una búsqueda antes de exportar!!!", MsgBoxStyle.Exclamation, "Validación")
            Else
                informe.expInfListadoCiclo(grillaCiclosMaquinas, fecha_ini_inf_mp.Value, fecha_fin_inf_mp.Value)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
