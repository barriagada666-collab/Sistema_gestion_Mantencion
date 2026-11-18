Public Class FrmBuscarCiclo

    Private Sub FrmBuscarCiclo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Dim mant_prev As New MantPreventiva
            Dim DS As New DataSet
            Dim grillas As New FormatoGrillas

            mant_prev.CrgCicloMp(FrmMp.txtIdMant.Text, DS)
            If DS.Tables.Count > 0 Then
                grillaBuscarCiclo.DataSource = DS.Tables(0)
                grillas.grillasMp(grillaBuscarCiclo)
                Utilitarios.AjustarColumnasGrilla(grillaBuscarCiclo)
            End If
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Ciclo MP", True, Me)
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub grillaBuscarCiclo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles grillaBuscarCiclo.KeyDown
        If e.KeyCode = Keys.Enter AndAlso grillaBuscarCiclo.CurrentRow IsNot Nothing Then
            e.Handled = True
            e.SuppressKeyPress = True
            grillaBuscarCiclo_CellDoubleClick(grillaBuscarCiclo, New DataGridViewCellEventArgs(0, grillaBuscarCiclo.CurrentRow.Index))
        End If
    End Sub

    Private Sub grillaBuscarCiclo_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaBuscarCiclo.CellDoubleClick
        If e.RowIndex < 0 OrElse e.RowIndex >= grillaBuscarCiclo.RowCount OrElse grillaBuscarCiclo.Rows(e.RowIndex).IsNewRow Then Exit Sub
        Dim rowSel As DataGridViewRow = grillaBuscarCiclo.Rows(e.RowIndex)
        Dim DST3 As New DataSet
        Dim mant_prev As New MantPreventiva
        Dim formato_grid As New FormatoGrillas
        Dim hrs_transcurridas As Double = 0

        Try
            Dim valCell = Function(idx As Integer) As String
                              If idx < 0 OrElse idx >= rowSel.Cells.Count OrElse rowSel.Cells(idx).Value Is Nothing OrElse IsDBNull(rowSel.Cells(idx).Value) Then
                                  Return String.Empty
                              End If
                              Return rowSel.Cells(idx).Value.ToString()
                          End Function

            With FrmMp
                .del_index_tareas.Clear()
                .del_index_personal.Clear()
                .grillaInsumosMp.Rows.Clear()

                If String.IsNullOrWhiteSpace(.id_nodo_select) Then
                    Dim nodoResuelto As String = mant_prev.ObtenerIdNodoMp(.txtIdMant.Text)
                    .id_nodo_select = If(String.IsNullOrWhiteSpace(nodoResuelto), "1", nodoResuelto)
                    If .arbol1.Nodes.Count > 0 Then
                        Nodo.SeleccionarNodoPorId(.arbol1, .id_nodo_select, .id_nodo_select)
                    End If
                End If

                .txtIdCiclo.Text = valCell(0)
                Dim fIni As DateTime
                If DateTime.TryParse(valCell(1), fIni) Then .FechaIniCiclo.Value = fIni
                Dim hIni As String = valCell(2)
                If Not String.IsNullOrWhiteSpace(hIni) Then .HrInicioCiclo.Text = hIni
                Dim fFin As DateTime
                If DateTime.TryParse(valCell(3), fFin) Then .fechaFinCicloMp.Value = fFin
                Dim hFin As String = valCell(4)
                If Not String.IsNullOrWhiteSpace(hFin) Then .HrFinCiclo.Text = hFin
                .txtDuracionCiclo.Text = valCell(5)
                .txtObsCiclo.Text = valCell(6)
                .cmbEstadoCiclo.Text = valCell(7)
            End With

            '################################# CARGA DE TAREAS CICLO ######################################################
            FrmMp.DST_TAREAS.Tables.Clear()
            mant_prev.CrgTareasCicloMp(FrmMp.txtIdMant.Text, FrmMp.txtIdCiclo.Text, FrmMp.id_nodo_select, FrmMp.DST_TAREAS)
            If FrmMp.DST_TAREAS.Tables.Count > 0 Then
                FrmMp.grillaTareasCicloMp.DataSource = FrmMp.DST_TAREAS.Tables(0)
                formato_grid.grillasMp(FrmMp.grillaTareasCicloMp)

                With FrmMp.grillaTareasCicloMp
                    For i = 0 To .Rows.Count - 1
                        If .Rows(i).IsNewRow Then Continue For
                        Dim valT As Object = .Rows(i).Cells(5).Value
                        If valT IsNot Nothing AndAlso Not IsDBNull(valT) AndAlso IsNumeric(valT) AndAlso Convert.ToDouble(valT) > 0 Then
                            .Rows(i).Cells(0).Value = True
                        End If
                    Next
                End With
            Else
                FrmMp.grillaTareasCicloMp.DataSource = Nothing
            End If
            '###############################################################################################################

            '################################## CARGA DE PERSONAL MP #######################################################
            If FrmMp.DS2.Tables.Count > 0 Then
                FrmMp.DS2.Tables.Clear()
            End If

            mant_prev.CrgPersonalCicloMp(FrmMp.txtIdMant.Text, FrmMp.txtIdCiclo.Text, FrmMp.DS2)

            If FrmMp.DS2.Tables.Count > 0 Then
                If FrmMp.grillaPersonalMp.Columns.Contains("rut_personal") Then FrmMp.grillaPersonalMp.Columns.Remove("rut_personal")
                If FrmMp.grillaPersonalMp.Columns.Contains("nombre_personal") Then FrmMp.grillaPersonalMp.Columns.Remove("nombre_personal")
                FrmMp.grillaPersonalMp.DataSource = FrmMp.DS2.Tables(0)
                formato_grid.grillasMp(FrmMp.grillaPersonalMp)
            End If
            FrmMp.btnIngMp.Enabled = False
            '###############################################################################################################

            '################################## CARGA DE INSUMOS MP ########################################################
            mant_prev.CrgInsumosCicloMp(FrmMp.txtIdMant.Text, FrmMp.txtIdCiclo.Text, DST3)
            If DST3.Tables.Count > 0 AndAlso DST3.Tables(0).Rows.Count > 0 Then
                Dim j As Integer = 0
                For i = 0 To DST3.Tables(0).Rows.Count - 1
                    FrmMp.grillaInsumosMp.Rows.Add()
                    For c As Integer = 0 To Math.Min(5, DST3.Tables(0).Columns.Count - 1)
                        Dim vObj As Object = DST3.Tables(0).Rows(i).Item(c)
                        FrmMp.grillaInsumosMp.Rows(j).Cells(c).Value = If(IsDBNull(vObj), String.Empty, vObj.ToString())
                    Next
                    j += 1
                Next
            End If
            '###############################################################################################################

            FrmMp.btn_plan_ciclos.Enabled = True
            hrs_transcurridas = mant_prev.hrsTranscurridasCicloMp(FrmMp.txtIdMant.Text, FrmMp.txtIdCiclo.Text)

            If hrs_transcurridas <> 0 Then
                With FrmMp
                    .hrsCiclo.Text = hrs_transcurridas.ToString()
                    .lblHrsCiclo.Visible = True
                    .hrsCiclo.Visible = True
                End With
            Else
                With FrmMp
                    .lblHrsCiclo.Visible = False
                    .hrsCiclo.Text = "0"
                    .hrsCiclo.Visible = False
                End With
            End If
            FrmMp.btnGuardarMp.Text = "    Actualizar"
            FrmMp.btnGuardarMp.Enabled = Usuario.PermisoGuardarMp
            Me.Close()
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Ciclo MP (Grilla Buscar Ciclo)", True, Me)
        End Try
    End Sub
End Class