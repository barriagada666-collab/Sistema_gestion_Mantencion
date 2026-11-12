Public Class FrmAdminAuditoria

    Private Sub btn_buscar_aud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_aud.Click
        Dim auditoria As New Auditoria
        Dim DST_AUD As New DataSet

        Cursor = Cursors.WaitCursor
        Try
            auditoria.CrgInfAuditoria(fecha_ini_aud.Value, fecha_fin_aud.Value, DST_AUD)
            If DST_AUD.Tables.Count > 0 Then
                grillaAuditoria.DataSource = DST_AUD.Tables(0)
                Utilitarios.AjustarColumnasGrilla(grillaAuditoria)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Cursor = Cursors.Default
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Sub btn_salir_aud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir_aud.Click
        Me.Close()
    End Sub

    Private Sub FrmAdminAuditoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim formato As New FormatoGrillas()
        formato.grillasOT(grillaAuditoria)
        Utilitarios.AplicarTemaModerno(Me)
    End Sub

    Private Sub btn_exp_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exp_excel.Click
        Dim informes As New Informes

        Try
            informes.expInfAuditoria(grillaAuditoria, fecha_ini_aud.Value, fecha_fin_aud.Value)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class