Public Class FrmBuscarMp

    Private Sub FrmBuscarMp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Dim mant_prev As New MantPreventiva
            Dim DS As New DataSet

            Dim idNodoBusq As String = If(String.IsNullOrWhiteSpace(FrmMp.id_nodo_select), "1", FrmMp.id_nodo_select)
            Dim tipoMpBusq As String = If(String.IsNullOrWhiteSpace(FrmMp.cmbTipoMp.Text), "Todos", FrmMp.cmbTipoMp.Text)
            mant_prev.CrgMpNodo(idNodoBusq, tipoMpBusq, DS)
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

    Private Sub SeleccionarMpFila(ByVal rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= grillaBuscarMp.RowCount OrElse grillaBuscarMp.Rows(rowIndex).IsNewRow Then Exit Sub
        Try
            Dim row As DataGridViewRow = grillaBuscarMp.Rows(rowIndex)
            Dim valCell = Function(idx As Integer) As String
                              If idx < 0 OrElse idx >= row.Cells.Count OrElse row.Cells(idx).Value Is Nothing OrElse IsDBNull(row.Cells(idx).Value) Then
                                  Return String.Empty
                              End If
                              Return row.Cells(idx).Value.ToString()
                          End Function
            Dim idMpSel As String = valCell(0).Trim()
            Dim idNodoPrev As String = FrmMp.id_nodo_select
            Dim mp As New MantPreventiva
            mp.LimpiarFrmMp()

            Dim idNodoReal As String = mp.ObtenerIdNodoMp(idMpSel)
            If String.IsNullOrWhiteSpace(idNodoReal) Then
                idNodoReal = If(String.IsNullOrWhiteSpace(idNodoPrev), "1", idNodoPrev)
            End If

            With FrmMp
                .txtIdMant.Text = idMpSel
                .txtFrecuenciaMp.Text = valCell(1)
                .txtTiempoAviso.Text = valCell(2)
                .cmbEstadoMp.Text = valCell(3)
                .cmbTipoMp.Text = valCell(5)
                .txtObsMant.Text = valCell(6)
                .id_nodo_padre = idNodoReal
                .id_nodo_select = idNodoReal
                If .arbol1.Nodes.Count > 0 Then
                    Nodo.SeleccionarNodoPorId(.arbol1, idNodoReal, .id_nodo_select)
                End If
            End With
            Me.Close()
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Mantención Preventiva (Grilla Buscar MP)", True, Me)
        End Try
    End Sub

    Private Sub grillaBuscarMp_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaBuscarMp.CellDoubleClick
        SeleccionarMpFila(e.RowIndex)
    End Sub

    Private Sub grillaBuscarMp_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles grillaBuscarMp.KeyDown
        If e.KeyCode = Keys.Enter AndAlso grillaBuscarMp.CurrentRow IsNot Nothing Then
            e.Handled = True
            e.SuppressKeyPress = True
            SeleccionarMpFila(grillaBuscarMp.CurrentRow.Index)
        End If
    End Sub
End Class