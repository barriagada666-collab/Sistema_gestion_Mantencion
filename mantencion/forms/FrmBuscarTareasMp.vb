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
            If DST_TAREAS_MP.Tables.Count > 0 Then
                grillaTareasNodoMp.DataSource = DST_TAREAS_MP.Tables(0)
                filtro_tareas.Table = DST_TAREAS_MP.Tables(0)
                formato_grid.grillasMp(grillaTareasNodoMp)
                Utilitarios.AjustarColumnasGrilla(grillaTareasNodoMp)
            End If
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Tareas MP", True, Me)
        Finally
            grillaTareasNodoMp.ResumeLayout(False)
            Me.ResumeLayout(True)
        End Try
        
    End Sub

    Private Sub txtFiltroTarea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltroTarea.TextChanged
        If filtro_tareas.Table Is Nothing Then Exit Sub
        Try
            Dim valorLimpio As String = Utilitarios.EscaparLike(txtFiltroTarea.Text.Trim())
            filtro_tareas.RowFilter = "Descripción like '%" & valorLimpio & "%' "
            grillaTareasNodoMp.DataSource = filtro_tareas
            Utilitarios.AjustarColumnasGrilla(grillaTareasNodoMp)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Tareas MP (Filtro Tarea)", True, Me)
        End Try
    End Sub

    Private Sub btnAgrTareas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgrTareas.Click
        Try
            grillaTareasNodoMp.EndEdit()
            Dim formato_grid As New FormatoGrillas
            Dim agregadas As Integer = 0
            Dim omitidas As Integer = 0

            With FrmMp
                If .grillaTareasCicloMp.RowCount > 0 Then
                    If .DST_TAREAS.Tables.Count = 0 Then Exit Sub
                    For i = 0 To grillaTareasNodoMp.RowCount - 1
                        If grillaTareasNodoMp.Rows(i).IsNewRow Then Continue For
                        If True.Equals(grillaTareasNodoMp.Rows(i).Cells(0).Value) Then
                            Dim idTareaNueva As String = Convert.ToString(grillaTareasNodoMp.Rows(i).Cells(1).Value)
                            Dim yaExiste As Boolean = False
                            For j = 0 To .grillaTareasCicloMp.RowCount - 1
                                If String.Equals(Convert.ToString(.grillaTareasCicloMp.Rows(j).Cells(1).Value), idTareaNueva, StringComparison.OrdinalIgnoreCase) Then
                                    yaExiste = True
                                    omitidas += 1
                                    Exit For
                                End If
                            Next
                            If yaExiste Then Continue For

                            Dim fila As DataRow = .DST_TAREAS.Tables(0).NewRow
                            fila(0) = grillaTareasNodoMp.Rows(i).Cells(1).Value
                            fila(1) = grillaTareasNodoMp.Rows(i).Cells(2).Value
                            fila(2) = grillaTareasNodoMp.Rows(i).Cells(3).Value
                            fila(3) = grillaTareasNodoMp.Rows(i).Cells(4).Value
                            fila(4) = 0
                            .DST_TAREAS.Tables(0).Rows.Add(fila)
                            agregadas += 1
                        End If
                    Next
                Else
                    If DST_TAREAS_MP.Tables.Count = 0 Then Exit Sub
                    .DST_TAREAS = DST_TAREAS_MP.Clone
                    .DST_TAREAS.Tables(0).Columns.Add("tiempo")
                    .DST_TAREAS.Tables(0).Columns.Add("observacion_ciclo")

                    For i = 0 To grillaTareasNodoMp.RowCount - 1
                        If grillaTareasNodoMp.Rows(i).IsNewRow Then Continue For
                        If True.Equals(grillaTareasNodoMp.Rows(i).Cells(0).Value) Then
                            Dim fila As DataRow = .DST_TAREAS.Tables(0).NewRow
                            fila(0) = grillaTareasNodoMp.Rows(i).Cells(1).Value
                            fila(1) = grillaTareasNodoMp.Rows(i).Cells(2).Value
                            fila(2) = grillaTareasNodoMp.Rows(i).Cells(3).Value
                            fila(3) = grillaTareasNodoMp.Rows(i).Cells(4).Value
                            fila(4) = 0
                            .DST_TAREAS.Tables(0).Rows.Add(fila)
                            agregadas += 1
                        End If
                    Next

                    .grillaTareasCicloMp.DataSource = .DST_TAREAS.Tables(0)
                    formato_grid.grillasMp(.grillaTareasCicloMp)
                End If
            End With

            For i = 0 To grillaTareasNodoMp.RowCount - 1
                grillaTareasNodoMp.Rows(i).Cells(0).Value = False
            Next

            If agregadas = 0 AndAlso omitidas = 0 Then
                MsgBox("Debe seleccionar al menos una tarea para agregar.", MsgBoxStyle.Exclamation, "Validación")
            ElseIf omitidas > 0 Then
                MsgBox(String.Format("Se agregaron {0} tarea(s). Se omitieron {1} que ya existían en el ciclo.", agregadas, omitidas), MsgBoxStyle.Information, "Validación")
            Else
                MsgBox(String.Format("Se agregaron {0} tarea(s) al ciclo.", agregadas), MsgBoxStyle.Information, "Confirmación")
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Tareas MP (Agregar Tareas)", True, Me)
        End Try
    End Sub
End Class