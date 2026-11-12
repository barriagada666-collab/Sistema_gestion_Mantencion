Public Class FrmBuscarPlanta

    Private Sub FrmBuscarPlanta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DS As New DataSet
        Dim planta As New Planta

        planta.CrgGrillaPlanta(DS)
        Try
            grillaPlanta.DataSource = DS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub grillaPlanta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaPlanta.CellContentClick

    End Sub

    Private Sub grillaPlanta_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaPlanta.CellContentDoubleClick
        Try
            FrmPlantas.txtCodPlanta.Text = grillaPlanta.Rows(e.RowIndex).Cells(0).Value.ToString()
            FrmPlantas.txtNomPlanta.Text = grillaPlanta.Rows(e.RowIndex).Cells(1).Value.ToString()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        
    End Sub
End Class