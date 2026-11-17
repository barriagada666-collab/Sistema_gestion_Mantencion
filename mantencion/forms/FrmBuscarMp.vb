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
                Me.BeginInvoke(New Action(AddressOf Me.Close))
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Mantención Preventiva", True, Me)
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub grillaBuscarMp_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaBuscarMp.CellContentDoubleClick
        If e.RowIndex < 0 OrElse grillaBuscarMp.Rows(e.RowIndex).IsNewRow Then Exit Sub
        Try
            Dim row As DataGridViewRow = grillaBuscarMp.Rows(e.RowIndex)
            Dim valCell = Function(idx As Integer) As String
                              If idx < 0 OrElse idx >= row.Cells.Count OrElse row.Cells(idx).Value Is Nothing OrElse IsDBNull(row.Cells(idx).Value) Then
                                  Return String.Empty
                              End If
                              Return row.Cells(idx).Value.ToString()
                          End Function
            Dim mp As New MantPreventiva
            mp.LimpiarFrmMp()
            With FrmMp
                .txtIdMant.Text = valCell(0)
                .txtFrecuenciaMp.Text = valCell(1)
                .txtTiempoAviso.Text = valCell(2)
                .cmbEstadoMp.Text = valCell(3)
                .cmbTipoMp.Text = valCell(5)
                .txtObsMant.Text = valCell(6)
            End With
            Me.Close()
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Mantención Preventiva (Grilla Buscar MP)", True, Me)
        End Try
    End Sub
End Class