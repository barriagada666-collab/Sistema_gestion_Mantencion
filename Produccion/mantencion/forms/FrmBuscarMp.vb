Public Class FrmBuscarMp

    Private Sub FrmBuscarMp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mant_prev As New MantPreventiva
        Dim DS As New DataSet

        mant_prev.CrgMpNodo(FrmMp.id_nodo_select, FrmMp.cmbTipoMp.Text, DS)
        Try
            If DS.Tables(0).Rows.Count > 0 Then
                grillaBuscarMp.DataSource = DS.Tables(0)
                Dim grillas As New FormatoGrillas
                grillas.grillasMp(grillaBuscarMp)
            Else
                MsgBox("No hay datos para mostrar!!!", MsgBoxStyle.Exclamation, "Validación")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        
    End Sub

    Private Sub grillaBuscarMp_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaBuscarMp.CellContentClick

    End Sub

    Private Sub grillaBuscarMp_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaBuscarMp.CellContentDoubleClick
        Try
            With FrmMp
                .txtIdMant.Text = grillaBuscarMp.Rows(grillaBuscarMp.CurrentRow.Index).Cells(0).Value
                .txtFrecuenciaMp.Text = grillaBuscarMp.Rows(grillaBuscarMp.CurrentRow.Index).Cells(1).Value
                .txtTiempoAviso.Text = grillaBuscarMp.Rows(grillaBuscarMp.CurrentRow.Index).Cells(2).Value
                .cmbEstadoMp.Text = grillaBuscarMp.Rows(grillaBuscarMp.CurrentRow.Index).Cells(3).Value
                .cmbTipoMp.Text = grillaBuscarMp.Rows(grillaBuscarMp.CurrentRow.Index).Cells(5).Value
                .txtObsMant.Text = grillaBuscarMp.Rows(grillaBuscarMp.CurrentRow.Index).Cells(6).Value
            End With
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        
    End Sub
End Class