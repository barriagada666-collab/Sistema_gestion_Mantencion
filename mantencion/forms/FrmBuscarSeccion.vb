Public Class FrmBuscarSeccion

    Private Sub FrmBuscarSeccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Dim DST As New DataSet
        Dim seccion As New Seccion

        Try
            grilla_buscar_seccion.SuspendLayout()
            seccion.crgSeccion(DST)
            If DST.Tables.Count > 0 Then
                grilla_buscar_seccion.DataSource = DST.Tables(0)
                Utilitarios.AjustarColumnasGrilla(grilla_buscar_seccion)
            End If
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Sección", True, Me)
        Finally
            grilla_buscar_seccion.ResumeLayout(False)
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub grilla_buscar_seccion_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_buscar_seccion.CellDoubleClick
        If e.RowIndex < 0 OrElse grilla_buscar_seccion.Rows(e.RowIndex).IsNewRow OrElse grilla_buscar_seccion.ColumnCount < 2 Then Exit Sub
        Try
            Dim row As DataGridViewRow = grilla_buscar_seccion.Rows(e.RowIndex)
            With FrmSeccion
                .txtCodSeccion.Text = Convert.ToString(row.Cells(0).Value)
                .txtDescSeccion.Text = Convert.ToString(row.Cells(1).Value)
            End With
            Me.Close()
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Sección", True, Me)
        End Try
    End Sub
End Class