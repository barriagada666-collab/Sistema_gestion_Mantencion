Public Class FrmInfMantPrevCiclosMaq
    Public id_nodo_mp_select As String = ""
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Private _cargando As Boolean = False
    Private _buscando As Boolean = False

    Private Sub FrmInfMantPrevCiclosMaq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        _cargando = True
        Dim nd As New Nodo
        Dim nodoRaiz As New TreeNode
        Dim mant_preventiva As New MantPreventiva
        Try
            Arbol7.BeginUpdate()
            nodoRaiz.Name = "1"
            nodoRaiz.Text = "Cambiaso Hnos S.A."
            nd.CRG_NODO_HIJO(nodoRaiz)
            Arbol7.Nodes.Add(nodoRaiz)
            cmbTipoMpGantt.DropDownStyle = ComboBoxStyle.DropDownList
            mant_preventiva.CrgCmbTipoMpGantt(cmbTipoMpGantt)
            Utilitarios.InicializarRangoMesActual(fecha_ini_inf_mp, fecha_fin_inf_mp)
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Ciclos MP Varias Máquinas (Carga)", True, Me)
        Finally
            _cargando = False
            Arbol7.EndUpdate()
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub Arbol7_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Arbol7.AfterSelect
        If Arbol7.SelectedNode Is Nothing Then Exit Sub
        id_nodo_mp_select = Arbol7.SelectedNode.Name
        nodo_anterior2 = id_nodo_mp_select
        Arbol7.SelectedNode.BackColor = Utilitarios.ColorSeleccion

        If Not _cargando AndAlso Not String.IsNullOrEmpty(id_nodo_mp_select) AndAlso id_nodo_mp_select <> "1" Then
            If fecha_ini_inf_mp.Value.Date <= fecha_fin_inf_mp.Value.Date Then
                EjecutarBusquedaCiclos(False)
            End If
        End If
    End Sub

    Private Sub Filtros_Changed(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTipoMpGantt.SelectedIndexChanged, fecha_ini_inf_mp.ValueChanged, fecha_fin_inf_mp.ValueChanged
        If _cargando OrElse String.IsNullOrEmpty(id_nodo_mp_select) OrElse id_nodo_mp_select = "0" Then Exit Sub
        If fecha_ini_inf_mp.Value.Date <= fecha_fin_inf_mp.Value.Date Then
            EjecutarBusquedaCiclos(False)
        End If
    End Sub

    Private Sub btnSalirInfMp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirInfMp.Click
        Me.Close()
    End Sub

    Private Sub btnBuscarCiclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCiclos.Click
        EjecutarBusquedaCiclos(True)
    End Sub

    Private Sub EjecutarBusquedaCiclos(ByVal mostrarValidaciones As Boolean)
        If _buscando Then Exit Sub
        If String.IsNullOrEmpty(id_nodo_mp_select) OrElse id_nodo_mp_select = "0" Then
            If mostrarValidaciones Then
                MsgBox("Debe elegir un item para buscar los ciclos", MsgBoxStyle.Exclamation, "Validación")
            End If
            Exit Sub
        End If
        If Not Utilitarios.ValidarRangoFechas(fecha_ini_inf_mp, fecha_fin_inf_mp, mostrarValidaciones) Then
            Exit Sub
        End If

        Dim mant_prev As New MantPreventiva
        Dim DS_CICLOS As New DataSet
        Dim formato_grid As New FormatoGrillas

        _buscando = True
        Cursor = Cursors.WaitCursor
        grillaCiclosMaquinas.SuspendLayout()
        Try
            mant_prev.InfCiclosMaquinasMp(id_nodo_mp_select, fecha_ini_inf_mp.Value, fecha_fin_inf_mp.Value, cmbTipoMpGantt.Text, DS_CICLOS)
            If DS_CICLOS.Tables.Count > 0 AndAlso DS_CICLOS.Tables(0).Rows.Count > 0 Then
                grillaCiclosMaquinas.DataSource = DS_CICLOS.Tables(0)
                formato_grid.grillasMp(grillaCiclosMaquinas)
                Utilitarios.AjustarColumnasGrilla(grillaCiclosMaquinas)
                Utilitarios.AsegurarColumnaSeleccionGantt(grillaCiclosMaquinas)
            Else
                grillaCiclosMaquinas.DataSource = Nothing
                Utilitarios.QuitarColumnaSeleccionGantt(grillaCiclosMaquinas)
                If mostrarValidaciones Then
                    MsgBox("No se encontraron ciclos para el período seleccionado.", MsgBoxStyle.Information, "Validación")
                End If
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Ciclos MP Varias Máquinas (Buscar Ciclos)", True, Me)
        Finally
            grillaCiclosMaquinas.ResumeLayout(False)
            Cursor = Cursors.Default
            _buscando = False
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Sub btnExpGantt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpGantt.Click
        If grillaCiclosMaquinas.RowCount > 0 Then
            FrmCartaGantt.form = Me.Name
            If Arbol7.SelectedNode IsNot Nothing Then
                FrmCartaGantt.item_gantt = Arbol7.SelectedNode.Text
            End If
            If FrmCartaGantt.Visible Then
                FrmCartaGantt.RecargarDesdeOrigen()
                FrmCartaGantt.BringToFront()
            Else
                FrmCartaGantt.Show()
            End If
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
            ElseIf Not Utilitarios.ValidarRangoFechas(fecha_ini_inf_mp, fecha_fin_inf_mp) Then
                Exit Sub
            Else
                informe.expInfListadoCiclo(grillaCiclosMaquinas, fecha_ini_inf_mp.Value, fecha_fin_inf_mp.Value)
            End If

        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Ciclos MP Varias Máquinas (Exportar Listado)", True, Me)
        End Try
    End Sub

    Private Sub btnExpPdfListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpPdfListado.Click
        If grillaCiclosMaquinas.RowCount = 0 Then
            MsgBox("Debe realizar una búsqueda antes de exportar a PDF.", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If
        If Not Utilitarios.ValidarRangoFechas(fecha_ini_inf_mp, fecha_fin_inf_mp) Then Exit Sub

        Dim itemNombre As String = If(Arbol7.SelectedNode IsNot Nothing, Arbol7.SelectedNode.Text, "Ciclos MP")
        Dim rutaPdf As String = Utilitarios.SolicitarRutaGuardadoPdf("Listado_Ciclos_MP_" & itemNombre)
        If String.IsNullOrEmpty(rutaPdf) Then Exit Sub

        Dim subtitulo As String = String.Format("Ítem: {0}   |   Período: {1} al {2}   |   Tipo: {3}",
                                                itemNombre,
                                                fecha_ini_inf_mp.Value.ToString("dd-MM-yyyy"),
                                                fecha_fin_inf_mp.Value.ToString("dd-MM-yyyy"),
                                                cmbTipoMpGantt.Text)
        If Utilitarios.ExportarGrillaAPdf(grillaCiclosMaquinas, rutaPdf, "INFORME CICLOS MANTENCIÓN PREVENTIVA", subtitulo) Then
            If MessageBox.Show("Archivo PDF generado exitosamente en:" & Environment.NewLine & rutaPdf & Environment.NewLine & Environment.NewLine & "¿Desea abrir el documento PDF ahora?", "Exportación PDF Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Utilitarios.AbrirDocumento(rutaPdf)
            End If
        Else
            MsgBox("No fue posible generar el archivo PDF.", MsgBoxStyle.Critical, "Exportar PDF")
        End If
    End Sub
End Class
