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
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim valorLimpio As String = Utilitarios.EscaparLike(txtFiltro.Text.Trim())
        If opcCodSap.Checked Then
            filtro_insumos.RowFilter = "Codigo_SAP like '%" & valorLimpio & "%' "
        ElseIf opcDesc.Checked Then
            filtro_insumos.RowFilter = "Descripción like '%" & valorLimpio & "%' "
        End If
        grillaInsumos.DataSource = filtro_insumos
        Utilitarios.AjustarColumnasGrilla(grillaInsumos)
    End Sub

    Private Sub grillaInsumos_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaInsumos.CellContentDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Select Case nombre_form
            Case "MP"
                Dim fila_mp As Integer = 0
                fila_mp = FrmMp.grillaInsumosMp.CurrentRow.Index
                FrmMp.grillaInsumosMp.Rows(fila_mp).Cells(0).Value = grillaInsumos.Rows(e.RowIndex).Cells(0).Value
                FrmMp.grillaInsumosMp.Rows(fila_mp).Cells(1).Value = grillaInsumos.Rows(e.RowIndex).Cells(1).Value
                FrmMp.grillaInsumosMp.Rows(fila_mp).Cells(2).Value = grillaInsumos.Rows(e.RowIndex).Cells(2).Value
                FrmMp.grillaInsumosMp.Rows(fila_mp).Cells(5).Value = grillaInsumos.Rows(e.RowIndex).Cells(3).Value

                Me.Close()
            Case "OT"
                Dim fila_ot As Integer = 0
                fila_ot = frm_OT.grillaInsumosOt.CurrentRow.Index
                frm_OT.grillaInsumosOt.Rows(fila_ot).Cells(0).Value = grillaInsumos.Rows(e.RowIndex).Cells(0).Value
                frm_OT.grillaInsumosOt.Rows(fila_ot).Cells(1).Value = grillaInsumos.Rows(e.RowIndex).Cells(1).Value
                frm_OT.grillaInsumosOt.Rows(fila_ot).Cells(2).Value = grillaInsumos.Rows(e.RowIndex).Cells(2).Value
                frm_OT.grillaInsumosOt.Rows(fila_ot).Cells(5).Value = grillaInsumos.Rows(e.RowIndex).Cells(3).Value
                Me.Close()
        End Select
    End Sub
End Class