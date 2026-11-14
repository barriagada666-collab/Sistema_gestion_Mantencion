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
            ElseIf form = "FrmInfMantPrevCiclosMaq" Then
                informes.CrgInfGanttCiclosVariasMaq()
                lblDesdeGantt.Text = FormatDateTime(FrmInfMantPrevCiclosMaq.fecha_ini_inf_mp.Value, DateFormat.ShortDate)
                lblHastaGantt.Text = FormatDateTime(FrmInfMantPrevCiclosMaq.fecha_fin_inf_mp.Value, DateFormat.ShortDate)
                lblTituloGantt.Text = lblTituloGantt.Text & " " & FrmInfMantPrevCiclosMaq.Arbol7.SelectedNode.Text
            End If
            Utilitarios.AjustarColumnasGrilla(grillaInfoGantt)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            grillaGraficoGantt.ResumeLayout(False)
            grillaInfoGantt.ResumeLayout(False)
            Me.ResumeLayout(True)
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Sub btnExpExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpExcel.Click
        Dim informes As New Informes
        If grillaInfoGantt.RowCount > 0 And grillaGraficoGantt.RowCount > 0 Then
            Try
                informes.expInfGraficoGanttVariasMaq(grillaInfoGantt, grillaGraficoGantt, item_gantt, lblDesdeGantt.Text, lblHastaGantt.Text)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "error")
            End Try
        Else
            MsgBox("Debe buscar los ciclos antes de exportar a Excel", MsgBoxStyle.Exclamation, "Validación")
        End If
        
    End Sub

    Private Sub btnSalirGantt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirGantt.Click
        Me.Close()
    End Sub
End Class