Public Class FrmBuscarPlanta

    Private Sub FrmBuscarPlanta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Dim DS As New DataSet
            Dim planta As New Planta

            planta.CrgGrillaPlanta(DS)
            If DS.Tables.Count > 0 Then
                grillaPlanta.DataSource = DS.Tables(0)
                Utilitarios.AjustarColumnasGrilla(grillaPlanta)
            End If
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub grillaPlanta_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaPlanta.CellContentDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Try
            FrmPlantas.txtCodPlanta.Text = grillaPlanta.Rows(e.RowIndex).Cells(0).Value.ToString()
            FrmPlantas.txtNomPlanta.Text = grillaPlanta.Rows(e.RowIndex).Cells(1).Value.ToString()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        
    End Sub
End Class