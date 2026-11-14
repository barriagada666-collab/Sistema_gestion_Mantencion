Public Class FrmBuscarMp

    Private Sub FrmBuscarMp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Dim mant_prev As New MantPreventiva
            Dim DS As New DataSet

            mant_prev.CrgMpNodo(FrmMp.id_nodo_select, FrmMp.cmbTipoMp.Text, DS)
            If DS.Tables.Count > 0 AndAlso DS.Tables(0).Rows.Count > 0 Then
                grillaBuscarMp.DataSource = DS.Tables(0)
                Dim grillas As New FormatoGrillas
                grillas.grillasMp(grillaBuscarMp)
                Utilitarios.AjustarColumnasGrilla(grillaBuscarMp)
                Utilitarios.AplicarTemaModerno(Me)
            Else
                MsgBox("No hay datos para mostrar!!!", MsgBoxStyle.Exclamation, "Validación")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub grillaBuscarMp_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaBuscarMp.CellContentDoubleClick
        If e.RowIndex < 0 OrElse grillaBuscarMp.CurrentRow Is Nothing Then Exit Sub
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