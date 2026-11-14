Public Class FrmBuscarTareasMp
    Public nodo_padre As String = ""
    Public tipo_mp As String = ""
    Public filtro_tareas As New DataView
    Public DST_TAREAS_MP As New DataSet

    Private Sub FrmBuscarTareasMp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Dim nodo As New Nodo
        Dim formato_grid As New FormatoGrillas

        Try
            grillaTareasNodoMp.SuspendLayout()
            nodo.CRG_TAREAS_MP(nodo_padre, tipo_mp, DST_TAREAS_MP)
            grillaTareasNodoMp.DataSource = DST_TAREAS_MP.Tables(0)
            filtro_tareas.Table = DST_TAREAS_MP.Tables(0)
            formato_grid.grillasMp(grillaTareasNodoMp)
            Utilitarios.AjustarColumnasGrilla(grillaTareasNodoMp)
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            grillaTareasNodoMp.ResumeLayout(False)
            Me.ResumeLayout(True)
        End Try
        
    End Sub

    Private Sub txtFiltroTarea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltroTarea.TextChanged
        Try
            Dim valorLimpio As String = Utilitarios.EscaparLike(txtFiltroTarea.Text.Trim())
            filtro_tareas.RowFilter = "Descripción like '%" & valorLimpio & "%' "
            grillaTareasNodoMp.DataSource = filtro_tareas
            Utilitarios.AjustarColumnasGrilla(grillaTareasNodoMp)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnAgrTareas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgrTareas.Click
        Dim formato_grid As New FormatoGrillas

        With FrmMp
            If .grillaTareasCicloMp.RowCount > 0 Then

                For i = 0 To grillaTareasNodoMp.RowCount - 1
                    If True.Equals(grillaTareasNodoMp.Rows(i).Cells(0).Value) Then
                        For j = 0 To .grillaTareasCicloMp.RowCount - 1
                            If .grillaTareasCicloMp.Rows(j).Cells(1).Value = grillaTareasNodoMp.Rows(i).Cells(1).Value Then
                                MsgBox("La tarea seleccionada ya se encuentra registrada en el ciclo, fila n° " & j + 1, MsgBoxStyle.Exclamation, "Validación")
                                Exit Sub
                            End If
                        Next
                        Dim fila As DataRow = .DST_TAREAS.Tables(0).NewRow

                        fila(0) = grillaTareasNodoMp.Rows(i).Cells(1).Value
                        fila(1) = grillaTareasNodoMp.Rows(i).Cells(2).Value
                        fila(2) = grillaTareasNodoMp.Rows(i).Cells(3).Value
                        fila(3) = grillaTareasNodoMp.Rows(i).Cells(4).Value
                        fila(4) = 0
                        .DST_TAREAS.Tables(0).Rows.Add(fila)
                    End If
                Next

                'deja todos los checkbox sin tickear
                For i = 0 To grillaTareasNodoMp.RowCount - 1
                    grillaTareasNodoMp.Rows(i).Cells(0).Value = False
                Next
            Else
                .DST_TAREAS = DST_TAREAS_MP.Clone
                .DST_TAREAS.Tables(0).Columns.Add("tiempo")
                .DST_TAREAS.Tables(0).Columns.Add("observacion_ciclo")

                For i = 0 To grillaTareasNodoMp.RowCount - 1
                    If True.Equals(grillaTareasNodoMp.Rows(i).Cells(0).Value) Then
                        Dim fila As DataRow = .DST_TAREAS.Tables(0).NewRow

                        fila(0) = grillaTareasNodoMp.Rows(i).Cells(1).Value
                        fila(1) = grillaTareasNodoMp.Rows(i).Cells(2).Value
                        fila(2) = grillaTareasNodoMp.Rows(i).Cells(3).Value
                        fila(3) = grillaTareasNodoMp.Rows(i).Cells(4).Value
                        fila(4) = 0
                        .DST_TAREAS.Tables(0).Rows.Add(fila)
                    End If
                Next

                .grillaTareasCicloMp.DataSource = .DST_TAREAS.Tables(0)
                formato_grid.grillasMp(.grillaTareasCicloMp)

                'deja todos los checkbox sin tickear
                For i = 0 To grillaTareasNodoMp.RowCount - 1
                    grillaTareasNodoMp.Rows(i).Cells(0).Value = False
                Next
            End If
        End With
    End Sub
End Class