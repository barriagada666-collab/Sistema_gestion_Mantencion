Public Class FrmBuscarInsumo
    Public filtro_insumos As New DataView
    Public nombre_form As String
    Private Sub FrmBuscarInsumo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Dim INSUMOS As New Insumo
            Dim DS As New DataSet
            Dim grillas As New FormatoGrillas

            INSUMOS.CrgInsumosMp(DS)
            If DS.Tables.Count > 0 Then
                grillaInsumos.DataSource = DS.Tables(0)
                filtro_insumos.Table = DS.Tables(0)
                grillas.grillasMp(grillaInsumos)
                Utilitarios.AjustarColumnasGrilla(grillaInsumos)
            End If
            Utilitarios.AplicarTemaModerno(Me)
            opcCodSap.Checked = True
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Insumo (Carga)", True, Me)
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub AplicarFiltroInsumos()
        If filtro_insumos.Table Is Nothing Then Exit Sub
        Try
            Dim valorLimpio As String = Utilitarios.EscaparLike(txtFiltro.Text.Trim())
            If opcCodSap.Checked Then
                filtro_insumos.RowFilter = "Codigo_SAP like '%" & valorLimpio & "%' "
            ElseIf opcDesc.Checked Then
                filtro_insumos.RowFilter = "Descripción like '%" & valorLimpio & "%' "
            End If
            grillaInsumos.DataSource = filtro_insumos
            Utilitarios.AjustarColumnasGrilla(grillaInsumos)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Insumo (Filtro)", True, Me)
        End Try
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        AplicarFiltroInsumos()
    End Sub

    Private Sub opcFiltroInsumos_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles opcCodSap.CheckedChanged, opcDesc.CheckedChanged
        AplicarFiltroInsumos()
    End Sub

    Private Sub grillaInsumos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaInsumos.CellDoubleClick
        If e.RowIndex < 0 OrElse grillaInsumos.Rows(e.RowIndex).IsNewRow OrElse grillaInsumos.ColumnCount < 4 Then Exit Sub
        Try
            Dim row As DataGridViewRow = grillaInsumos.Rows(e.RowIndex)
            Select Case nombre_form
                Case "MP"
                    If FrmMp.grillaInsumosMp.CurrentRow Is Nothing OrElse FrmMp.grillaInsumosMp.ColumnCount < 6 Then Exit Sub
                    Dim fila_mp As Integer = FrmMp.grillaInsumosMp.CurrentRow.Index
                    FrmMp.grillaInsumosMp.Rows(fila_mp).Cells(0).Value = row.Cells(0).Value
                    FrmMp.grillaInsumosMp.Rows(fila_mp).Cells(1).Value = row.Cells(1).Value
                    FrmMp.grillaInsumosMp.Rows(fila_mp).Cells(2).Value = row.Cells(2).Value
                    FrmMp.grillaInsumosMp.Rows(fila_mp).Cells(5).Value = row.Cells(3).Value
                    Me.Close()
                Case "OT"
                    If frm_OT.grillaInsumosOt.CurrentRow Is Nothing OrElse frm_OT.grillaInsumosOt.ColumnCount < 6 Then Exit Sub
                    Dim fila_ot As Integer = frm_OT.grillaInsumosOt.CurrentRow.Index
                    frm_OT.grillaInsumosOt.Rows(fila_ot).Cells(0).Value = row.Cells(0).Value
                    frm_OT.grillaInsumosOt.Rows(fila_ot).Cells(1).Value = row.Cells(1).Value
                    frm_OT.grillaInsumosOt.Rows(fila_ot).Cells(2).Value = row.Cells(2).Value
                    frm_OT.grillaInsumosOt.Rows(fila_ot).Cells(5).Value = row.Cells(3).Value
                    Me.Close()
            End Select
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Insumo (Seleccionar)", True, Me)
        End Try
    End Sub
End Class