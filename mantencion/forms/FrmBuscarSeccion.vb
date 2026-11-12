Public Class FrmBuscarSeccion

    Private Sub FrmBuscarSeccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DST As New DataSet
        Dim seccion As New Seccion

        seccion.crgSeccion(DST)
        Try
            grilla_buscar_seccion.DataSource = DST.Tables(0)
            Utilitarios.AjustarColumnasGrilla(grilla_buscar_seccion)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grilla_buscar_seccion_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_buscar_seccion.CellContentClick
       
    End Sub

    Private Sub grilla_buscar_seccion_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_buscar_seccion.CellContentDoubleClick
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