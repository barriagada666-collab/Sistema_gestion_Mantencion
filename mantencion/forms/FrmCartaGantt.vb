Public Class FrmCartaGantt
    Public form As String
    Public item_gantt As String
    Private Sub FrmCartaGantt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Dim fila As Integer = 0
        Dim informes As New Informes

        Try
            grillaInfoGantt.SuspendLayout()
            grillaGraficoGantt.SuspendLayout()
            Utilitarios.AplicarTemaModerno(Me)
            If form = "FrmInfMantPrev" Then
                informes.CrgInfGanttCiclosMaq()
                lblDesdeGantt.Text = FrmInfMantPrev.f_ini_inf_mp.Value.ToString("dd-MM-yyyy")
                lblHastaGantt.Text = FrmInfMantPrev.f_fin_inf_mp.Value.ToString("dd-MM-yyyy")
                If Not String.IsNullOrEmpty(item_gantt) Then
                    lblTituloGantt.Text = "Carta Gantt - " & item_gantt
                End If
            ElseIf form = "FrmInfMantPrevCiclosMaq" Then
                informes.CrgInfGanttCiclosVariasMaq()
                lblDesdeGantt.Text = FrmInfMantPrevCiclosMaq.fecha_ini_inf_mp.Value.ToString("dd-MM-yyyy")
                lblHastaGantt.Text = FrmInfMantPrevCiclosMaq.fecha_fin_inf_mp.Value.ToString("dd-MM-yyyy")
                If FrmInfMantPrevCiclosMaq.Arbol7.SelectedNode IsNot Nothing Then
                    lblTituloGantt.Text = "Carta Gantt - " & FrmInfMantPrevCiclosMaq.Arbol7.SelectedNode.Text
                End If
            End If
            Utilitarios.AjustarColumnasGrilla(grillaInfoGantt)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Carta Gantt", True, Me)
        Finally
            grillaGraficoGantt.ResumeLayout(False)
            grillaInfoGantt.ResumeLayout(False)
            Me.ResumeLayout(True)
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Sub btnExpPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpPdf.Click
        If grillaInfoGantt.RowCount = 0 Then
            MsgBox("Debe buscar los ciclos antes de exportar a PDF", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Dim rutaPdf As String = Utilitarios.SolicitarRutaGuardadoPdf("Carta_Gantt_" & item_gantt)
        If String.IsNullOrEmpty(rutaPdf) Then Exit Sub

        Dim subtitulo As String = String.Format("Ítem: {0}   |   Desde: {1}   |   Hasta: {2}", item_gantt, lblDesdeGantt.Text, lblHastaGantt.Text)
        If Utilitarios.ExportarGrillaAPdf(grillaInfoGantt, rutaPdf, "INFORME CARTA GANTT - MANTENCIÓN PREVENTIVA", subtitulo) Then
            If MessageBox.Show("Archivo PDF generado exitosamente en:" & Environment.NewLine & rutaPdf & Environment.NewLine & Environment.NewLine & "¿Desea abrir el documento PDF ahora?", "Exportación PDF Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Utilitarios.AbrirDocumento(rutaPdf)
            End If
        Else
            MsgBox("No fue posible generar el archivo PDF.", MsgBoxStyle.Critical, "Exportar PDF")
        End If
    End Sub

    Private Sub btnExpExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpExcel.Click
        Dim informes As New Informes
        If grillaInfoGantt.RowCount > 0 And grillaGraficoGantt.RowCount > 0 Then
            Try
                informes.expInfGraficoGanttVariasMaq(grillaInfoGantt, grillaGraficoGantt, item_gantt, lblDesdeGantt.Text, lblHastaGantt.Text)
            Catch ex As Exception
                RegistroErrores.MostrarYRegistrar(ex, "Carta Gantt (Exportar Excel)", True, Me)
            End Try
        Else
            MsgBox("Debe buscar los ciclos antes de exportar a Excel", MsgBoxStyle.Exclamation, "Validación")
        End If

    End Sub

    Private Sub btnSalirGantt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirGantt.Click
        Me.Close()
    End Sub
End Class