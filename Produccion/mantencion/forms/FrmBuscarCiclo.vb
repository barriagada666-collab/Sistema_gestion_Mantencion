Public Class FrmBuscarCiclo

    Private Sub FrmBuscarCiclo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mant_prev As New MantPreventiva
        Dim DS As New DataSet
        Dim grillas As New FormatoGrillas

        mant_prev.CrgCicloMp(FrmMp.txtIdMant.Text, DS)
        Try
            grillaBuscarCiclo.DataSource = DS.Tables(0)
            grillas.grillasMp(grillaBuscarCiclo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub grillaBuscarCiclo_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaBuscarCiclo.CellContentDoubleClick
        Dim nodo As New Nodo
        Dim DS As New DataSet
        Dim DST As New DataSet
        Dim DST2 As New DataSet
        Dim DST3 As New DataSet
        Dim j As Integer
        Dim mant_prev As New MantPreventiva
        Dim grillas As New FormatoGrillas
        Dim formato_grid As New FormatoGrillas
        Dim hrs_transcurridas As Double = 0

        Try
            With FrmMp
                .txtIdCiclo.Text = grillaBuscarCiclo.Rows(e.RowIndex).Cells(0).Value
                .FechaIniCiclo.Value = grillaBuscarCiclo.Rows(e.RowIndex).Cells(1).Value
                .HrInicioCiclo.Text = grillaBuscarCiclo.Rows(e.RowIndex).Cells(2).Value
                .fechaFinCicloMp.Value = grillaBuscarCiclo.Rows(e.RowIndex).Cells(3).Value
                .HrFinCiclo.Text = grillaBuscarCiclo.Rows(e.RowIndex).Cells(4).Value
                .txtDuracionCiclo.Text = grillaBuscarCiclo.Rows(e.RowIndex).Cells(5).Value
                .txtObsCiclo.Text = grillaBuscarCiclo.Rows(e.RowIndex).Cells(6).Value
                .cmbEstadoCiclo.Text = grillaBuscarCiclo.Rows(e.RowIndex).Cells(7).Value
            End With
            '################################# CARGA DE TAREAS CICLO ######################################################
            FrmMp.DST_TAREAS.Tables.Clear()
            mant_prev.CrgTareasCicloMp(FrmMp.txtIdMant.Text, FrmMp.txtIdCiclo.Text, FrmMp.id_nodo_select, FrmMp.DST_TAREAS)
            FrmMp.grillaTareasCicloMp.DataSource = FrmMp.DST_TAREAS.Tables(0)
            formato_grid.grillasMp(FrmMp.grillaTareasCicloMp)

            With FrmMp.grillaTareasCicloMp
                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Cells(5).Value > 0 Then
                        .Rows(i).Cells(0).Value = True
                    End If
                Next
            End With
            '###############################################################################################################

            '################################## CARGA DE PERSONAL MP #######################################################
            If FrmMp.DS2.Tables.Count > 0 Then
                FrmMp.DS2.Clear()
            End If

            mant_prev.CrgPersonalCicloMp(FrmMp.txtIdMant.Text, FrmMp.txtIdCiclo.Text, FrmMp.DS2)

            If FrmMp.grillaPersonalMp.DataSource IsNot Nothing Then
                FrmMp.grillaPersonalMp.DataSource = FrmMp.DS2.Tables(0)
                grillas.grillasMp(FrmMp.grillaPersonalMp)
            Else
                FrmMp.grillaPersonalMp.Columns.Remove("rut_personal")
                FrmMp.grillaPersonalMp.Columns.Remove("nombre_personal")
                FrmMp.grillaPersonalMp.DataSource = FrmMp.DS2.Tables(0)
                grillas.grillasMp(FrmMp.grillaPersonalMp)
            End If
            FrmMp.btnIngMp.Enabled = False
            '###############################################################################################################

            '################################## CARGA DE INSUMOS MP ########################################################
            mant_prev.CrgInsumosCicloMp(FrmMp.txtIdMant.Text, FrmMp.txtIdCiclo.Text, DST3)
            If DST3.Tables(0).Rows.Count > 0 Then
                j = 0
                For i = 0 To DST3.Tables(0).Rows.Count - 1
                    FrmMp.grillaInsumosMp.Rows.Add()
                    FrmMp.grillaInsumosMp.Rows(j).Cells(0).Value = DST3.Tables(0).Rows(i).Item(0).ToString
                    FrmMp.grillaInsumosMp.Rows(j).Cells(1).Value = DST3.Tables(0).Rows(i).Item(1).ToString
                    FrmMp.grillaInsumosMp.Rows(j).Cells(2).Value = DST3.Tables(0).Rows(i).Item(2).ToString
                    FrmMp.grillaInsumosMp.Rows(j).Cells(3).Value = DST3.Tables(0).Rows(i).Item(3).ToString
                    FrmMp.grillaInsumosMp.Rows(j).Cells(4).Value = DST3.Tables(0).Rows(i).Item(4).ToString
                    FrmMp.grillaInsumosMp.Rows(j).Cells(5).Value = DST3.Tables(0).Rows(i).Item(5).ToString
                    j = j + 1
                Next
            End If
            '###############################################################################################################

            FrmMp.btn_plan_ciclos.Enabled = True
            hrs_transcurridas = mant_prev.hrsTranscurridasCicloMp(FrmMp.txtIdMant.Text, FrmMp.txtIdCiclo.Text)

            If hrs_transcurridas <> 0 Then
                With FrmMp
                    .hrsCiclo.Text = hrs_transcurridas
                    .lblHrsCiclo.Visible = True
                    .hrsCiclo.Visible = True
                End With
            Else
                With FrmMp
                    .lblHrsCiclo.Visible = False
                    .hrsCiclo.Text = 0
                    .hrsCiclo.Visible = False
                End With
            End If
            With FrmMp
                .btnGuardarMp.Text = "    Actualizar"
            End With
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        
    End Sub

    Private Sub grillaBuscarCiclo_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaBuscarCiclo.CellContentClick

    End Sub
End Class