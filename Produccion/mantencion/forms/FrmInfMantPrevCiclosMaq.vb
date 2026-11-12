Public Class FrmInfMantPrevCiclosMaq
    Public id_nodo_mp_select As String
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Private Sub FrmInfMantPrevCiclosMaq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nd As New Nodo
        Dim nodoRaiz As New TreeNode
        Dim width As Double = Screen.PrimaryScreen.Bounds.Width
        Dim heigh As Double = Screen.PrimaryScreen.Bounds.Height
        Dim mant_preventiva As New MantPreventiva

        Me.Width = width
        Me.Height = heigh
        nodoRaiz.Name = "1"
        nodoRaiz.Text = "Cambiaso Hnos S.A."
        nd.CRG_NODO_HIJO(nodoRaiz)
        Arbol7.Nodes.Add(nodoRaiz)
        mant_preventiva.CrgCmbTipoMpGantt(cmbTipoMpGantt)
    End Sub

    Private Sub Arbol7_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Arbol7.AfterSelect
        id_nodo_mp_select = Arbol7.SelectedNode.Name
        nodo_anterior2 = id_nodo_mp_select
        Arbol7.SelectedNode.BackColor = Color.GreenYellow
    End Sub

    Private Sub btnSalirInfMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirInfMp.Click
        Me.Close()
    End Sub

    Private Sub btnBuscarCiclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCiclos.Click
        Dim mant_prev As New MantPreventiva
        Dim DS_CICLOS As New DataSet
        Dim formato_grid As New FormatoGrillas

        If id_nodo_mp_select = 0 Then
            MsgBox("Debe elegir un item para buscar los ciclos", MsgBoxStyle.Exclamation, "Validación")
        Else
            mant_prev.InfCiclosMaquinasMp(id_nodo_mp_select, fecha_ini_inf_mp.Value, fecha_fin_inf_mp.Value, cmbTipoMpGantt.Text, DS_CICLOS)
            Try
                grillaCiclosMaquinas.DataSource = DS_CICLOS.Tables(0)
                formato_grid.grillasMp(grillaCiclosMaquinas)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If

    End Sub

    Private Sub btnExpGantt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpGantt.Click
        If grillaCiclosMaquinas.RowCount > 0 Then
            FrmCartaGantt.form = Me.Name
            FrmCartaGantt.item_gantt = Arbol7.SelectedNode.Text
            FrmCartaGantt.Show()
        Else
            MsgBox("Debe desplegar ciclos antes de exportar a informe gantt", MsgBoxStyle.Exclamation, "validación")
        End If

    End Sub

    Private Sub Arbol7_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles Arbol7.BeforeSelect
        If nodo_anterior2 <> "" Then
            Dim nodo_finded() As TreeNode = Arbol7.Nodes.Find(nodo_anterior2, True)
            Arbol7.SelectedNode = nodo_finded(0)
            Arbol7.SelectedNode.BackColor = Color.White
        End If
    End Sub

    Private Sub Arbol7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Arbol7.Click

    End Sub

    Private Sub txtBuscarNodo7_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarNodo7.KeyUp
        Dim nodo_find() As TreeNode
        Dim nodo As New Nodo
        Dim texto As String = txtBuscarNodo7.Text & "%"
        Dim id_nodo As String = ""

        If texto <> "" And texto <> "%" Then
            If nodo_anterior <> "" Then
                nodo.limpiar_arbol(nodo_anterior, Arbol7)
            End If

            id_nodo = nodo.BuscarIdNodoLike(texto, 2)
            nodo_anterior = id_nodo
            If id_nodo = "" Then
                MsgBox("No se encontró el item", MsgBoxStyle.Exclamation, "Información")
            Else
                nodo_find = Arbol7.Nodes.Find(id_nodo, True)
                Arbol7.SelectedNode = nodo_find(0)
                Arbol7.SelectedNode.BackColor = Color.GreenYellow
            End If
        End If
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