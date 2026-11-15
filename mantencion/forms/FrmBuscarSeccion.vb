Public Class FrmBuscarSeccion

    Private Sub FrmBuscarSeccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Dim DST As New DataSet
        Dim seccion As New Seccion

        Try
            grilla_buscar_seccion.SuspendLayout()
            seccion.crgSeccion(DST)
            grilla_buscar_seccion.DataSource = DST.Tables(0)
            Utilitarios.AjustarColumnasGrilla(grilla_buscar_seccion)
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            grilla_buscar_seccion.ResumeLayout(False)
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub grilla_buscar_seccion_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_buscar_seccion.CellContentDoubleClick
        If e.RowIndex < 0 OrElse grilla_buscar_seccion.CurrentRow Is Nothing Then Exit Sub
        Try
            With FrmSeccion
                .txtCodSeccion.Text = grilla_buscar_seccion.Rows(grilla_buscar_seccion.CurrentRow.Index).Cells(0).Value
                .txtDescSeccion.Text = grilla_buscar_seccion.Rows(grilla_buscar_seccion.CurrentRow.Index).Cells(1).Value
            End With
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class