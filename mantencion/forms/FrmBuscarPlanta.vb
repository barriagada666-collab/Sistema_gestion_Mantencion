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
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Planta", True, Me)
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub grillaPlanta_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaPlanta.CellContentDoubleClick
        If e.RowIndex < 0 OrElse grillaPlanta.Rows(e.RowIndex).IsNewRow OrElse grillaPlanta.ColumnCount < 2 Then Exit Sub
        Try
            FrmPlantas.txtCodPlanta.Text = Convert.ToString(grillaPlanta.Rows(e.RowIndex).Cells(0).Value)
            FrmPlantas.txtNomPlanta.Text = Convert.ToString(grillaPlanta.Rows(e.RowIndex).Cells(1).Value)
            Me.Close()
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Planta (Grilla Planta)", True, Me)
        End Try
    End Sub
End Class