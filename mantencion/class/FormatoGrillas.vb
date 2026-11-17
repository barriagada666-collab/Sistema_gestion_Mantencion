Imports System.Drawing
Imports System.Windows.Forms

Public Class FormatoGrillas

    Private Shared ReadOnly _fontHeader As New Font("Segoe UI", 8.75F, FontStyle.Bold)
    Private Shared ReadOnly _fontCelda As New Font("Segoe UI", 8.5F, FontStyle.Regular)

    ''' <summary>
    ''' Aplica paleta de colores moderna, encabezados estilizados, filas alternadas y doble buffer a cualquier DataGridView.
    ''' </summary>
    Public Shared Sub AplicarEstiloModerno(ByVal grilla As DataGridView)
        If grilla Is Nothing Then Exit Sub

        Utilitarios.HabilitarDobleBuffer(grilla)

        grilla.SuspendLayout()
        Try
            grilla.EnableHeadersVisualStyles = False
            grilla.BackgroundColor = Utilitarios.ColorFondoPanel
            grilla.BorderStyle = BorderStyle.FixedSingle
            grilla.GridColor = Utilitarios.ColorBordeGrilla
            grilla.CellBorderStyle = DataGridViewCellBorderStyle.Single

            grilla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            grilla.ColumnHeadersDefaultCellStyle.BackColor = Utilitarios.ColorPrimario
            grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            grilla.ColumnHeadersDefaultCellStyle.Font = _fontHeader
            grilla.ColumnHeadersDefaultCellStyle.SelectionBackColor = Utilitarios.ColorPrimario
            grilla.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White

            grilla.RowHeadersDefaultCellStyle.BackColor = Utilitarios.ColorFondoForm
            grilla.RowHeadersDefaultCellStyle.ForeColor = Utilitarios.ColorTextoSeleccion
            grilla.RowHeadersDefaultCellStyle.SelectionBackColor = Utilitarios.ColorSeleccion

            grilla.DefaultCellStyle.BackColor = Color.White
            grilla.DefaultCellStyle.ForeColor = Utilitarios.ColorTextoPrincipal
            grilla.DefaultCellStyle.Font = _fontCelda
            grilla.DefaultCellStyle.SelectionBackColor = Utilitarios.ColorSeleccion
            grilla.DefaultCellStyle.SelectionForeColor = Utilitarios.ColorTextoSeleccion

            grilla.RowsDefaultCellStyle.BackColor = Color.White
            grilla.AlternatingRowsDefaultCellStyle.BackColor = Utilitarios.ColorFilaAlterna
            grilla.AlternatingRowsDefaultCellStyle.ForeColor = Utilitarios.ColorTextoPrincipal
            grilla.AlternatingRowsDefaultCellStyle.SelectionBackColor = Utilitarios.ColorSeleccion
            grilla.AlternatingRowsDefaultCellStyle.SelectionForeColor = Utilitarios.ColorTextoSeleccion
        Finally
            grilla.ResumeLayout(False)
        End Try
    End Sub

    Private Shared Sub SetCol(ByVal grilla As DataGridView, ByVal index As Integer, Optional ByVal width As Integer = -1, Optional ByVal readOnlyCol As Boolean? = Nothing, Optional ByVal visibleCol As Boolean? = Nothing)
        If grilla Is Nothing OrElse index < 0 OrElse index >= grilla.Columns.Count Then Exit Sub
        Dim col As DataGridViewColumn = grilla.Columns(index)
        If width > 0 Then col.Width = width
        If readOnlyCol.HasValue Then col.ReadOnly = readOnlyCol.Value
        If visibleCol.HasValue Then col.Visible = visibleCol.Value
    End Sub

    Public Sub grillasOT(ByVal grilla As DataGridView)
        If grilla Is Nothing Then Exit Sub
        AplicarEstiloModerno(grilla)

        grilla.SuspendLayout()
        Try
            Select Case grilla.Name
                Case "grillaPersonalOt"
                    If grilla.Columns.Count = 0 Then
                        grilla.Columns.Add("RUT", "Rut")
                        grilla.Columns.Add("Alias_personal", "Alias")
                        grilla.Columns.Add("observacion_ot", "Observación")
                    End If
                    SetCol(grilla, 0, 80, True)
                    SetCol(grilla, 1, 80, True)
                    SetCol(grilla, 2, 395)

                Case "grillaOtExternas"
                    If grilla.Columns.Count = 0 Then
                        grilla.Columns.Add("n_ot_externa", "N°De OT Externa")
                        grilla.Columns.Add("desc_ot_externa", "Descripción OT Externa")
                    End If
                    SetCol(grilla, 0, 120)
                    SetCol(grilla, 1, 435)

            Case "grillaInsumosOt"
                SetCol(grilla, 0, 80)
                SetCol(grilla, 1, 100)
                SetCol(grilla, 2, 220)
                SetCol(grilla, 3, 65)
                SetCol(grilla, 4, 80)
                SetCol(grilla, 5, 102)

            Case "grillaInfOt"
                SetCol(grilla, 0, 70)
                SetCol(grilla, 2, 150)
                SetCol(grilla, 3, 120)
                SetCol(grilla, 4, 120)
                SetCol(grilla, 5, 100)
                SetCol(grilla, 6, 80)
                SetCol(grilla, 7, 200)
                SetCol(grilla, 8, 120)
                SetCol(grilla, 9, 120)
                SetCol(grilla, 10, 100)

            Case "grillaTopMaquinas"
                SetCol(grilla, 0, 60)
                SetCol(grilla, 1, 200)
                SetCol(grilla, 2, 85)
                SetCol(grilla, 3, 110)
                SetCol(grilla, 4, 85)
                SetCol(grilla, 5, 85)
                SetCol(grilla, 6, 95)

            Case "grillaTopComponentes"
                SetCol(grilla, 0, 60)
                SetCol(grilla, 1, 180)
                SetCol(grilla, 2, 160)
                SetCol(grilla, 3, 85)
                SetCol(grilla, 4, 110)
                SetCol(grilla, 5, 85)
                SetCol(grilla, 6, 85)

            Case "grillaOtCerradaPorTec", "grillaOtRecibidaPor"
                SetCol(grilla, 0, 60)
                SetCol(grilla, 1, 180)
                SetCol(grilla, 2, 100)
                SetCol(grilla, 3, 110)

            Case "grillaDetalleOtPend"
                SetCol(grilla, 0, 70)
                SetCol(grilla, 1, 120)
                SetCol(grilla, 2, 120)
                SetCol(grilla, 3, 100)
                SetCol(grilla, 4, 120)
                SetCol(grilla, 5, 200)

            Case "grillaDetalleOtTecnicos", "grillaOtTipoFalla", "grillaOtDetalleDia", "grillaDetalleOtEstado"
                SetCol(grilla, 0, 70)
                SetCol(grilla, 1, 120)
                SetCol(grilla, 2, 120)
                SetCol(grilla, 3, 100)
                SetCol(grilla, 4, 120)
                SetCol(grilla, 5, 120)
                SetCol(grilla, 7, 200)

            Case "grillaOtDetalleTurno"
                SetCol(grilla, 0, 70)
                SetCol(grilla, 1, 120)
                SetCol(grilla, 2, 120)
                SetCol(grilla, 3, 100)
                SetCol(grilla, 4, 120)
                SetCol(grilla, 5, 120)
                SetCol(grilla, 8, 200)
            End Select
        Finally
            grilla.ResumeLayout(False)
        End Try
    End Sub

    Public Sub grillasMp(ByVal grilla As DataGridView)
        If grilla Is Nothing Then Exit Sub
        AplicarEstiloModerno(grilla)

        grilla.SuspendLayout()
        Try
            Select Case grilla.Name
            Case "grillaInfMant"
                SetCol(grilla, 0, 70)
                SetCol(grilla, 1, 120)
                SetCol(grilla, 2, 130)
                SetCol(grilla, 4, 140)
                SetCol(grilla, 5, 80)

            Case "grillaDetalleCicloMp"
                SetCol(grilla, 0, 80)
                SetCol(grilla, 1, 120)
                SetCol(grilla, 2, 120)
                SetCol(grilla, 3, 100)
                SetCol(grilla, 4, 210)
                SetCol(grilla, 5, 70)

            Case "grillaTareasInfMp"
                SetCol(grilla, 0, 120)
                SetCol(grilla, 1, 330)
                SetCol(grilla, 2, 90)
                SetCol(grilla, 3, 180)

            Case "grillaTareasCicloMp"
                SetCol(grilla, 0, 70)
                SetCol(grilla, 1, -1, Nothing, False)
                SetCol(grilla, 2, -1, Nothing, False)
                SetCol(grilla, 3, 120, True)
                SetCol(grilla, 4, 300, True)
                SetCol(grilla, 5, 50)
                SetCol(grilla, 6, 140)

            Case "grillaInsumosMp"
                SetCol(grilla, 0, 70, True)
                SetCol(grilla, 1, 70, True)
                SetCol(grilla, 2, 50, True)
                SetCol(grilla, 3, 170)
                SetCol(grilla, 4, 50)
                SetCol(grilla, 5, 140)

            Case "grillaBuscarMp"
                SetCol(grilla, 0, 65)
                SetCol(grilla, 1, 100)
                SetCol(grilla, 2, 130)
                SetCol(grilla, 3, 50)
                SetCol(grilla, 4, 120)
                SetCol(grilla, 5, 80)
                SetCol(grilla, 6, 200)

            Case "grillaBuscarCiclo"
                SetCol(grilla, 0, 75)
                SetCol(grilla, 1, 70)
                SetCol(grilla, 2, 60)
                SetCol(grilla, 3, 70)
                SetCol(grilla, 4, 60)
                SetCol(grilla, 5, 90)
                SetCol(grilla, 6, 200)
                SetCol(grilla, 7, 70)

            Case "grillaPersonalMp"
                SetCol(grilla, 0, 70, True)
                SetCol(grilla, 1, 140, True)

            Case "grillaInsumos"
                SetCol(grilla, 0, 80, True)
                SetCol(grilla, 1, 90, True)
                SetCol(grilla, 2, 300)
                SetCol(grilla, 3, 50)

            Case "grillaPersonalInfMp"
                SetCol(grilla, 0, 80)
                SetCol(grilla, 1, 150)
                SetCol(grilla, 2, 150)

            Case "grillaInsumosInfMp"
                SetCol(grilla, 0, 80)
                SetCol(grilla, 1, 380)
                SetCol(grilla, 2, 80)
                SetCol(grilla, 3, 80)
                SetCol(grilla, 4, 60)

            Case "grillaTareasPendInfMp"
                If FrmInfMantPrev.opcfiltroTareas.Checked Then
                    SetCol(grilla, 0, 70)
                    SetCol(grilla, 1, 70)
                    SetCol(grilla, 2, 70)
                    SetCol(grilla, 3, 300)
                    SetCol(grilla, 4, 300)
                Else
                    SetCol(grilla, 0, 70)
                    SetCol(grilla, 1, 340)
                    SetCol(grilla, 2, 260)
                End If

            Case "grillaTareasAdMp"
                SetCol(grilla, 1, -1, Nothing, False)
                SetCol(grilla, 2, -1, Nothing, False)
                SetCol(grilla, 3, 120)
                SetCol(grilla, 4, 120)
                SetCol(grilla, 5, 340)

            Case "grillaCiclosMaquinas"
                SetCol(grilla, 0, 80)
                SetCol(grilla, 3, 180)
                SetCol(grilla, 4, 80)
                SetCol(grilla, 5, 80)
                SetCol(grilla, 6, 90)

            Case "grillaTareasNodoMp"
                SetCol(grilla, 1, -1, Nothing, False)
                SetCol(grilla, 2, -1, Nothing, False)
                SetCol(grilla, 3, 100, True)
                SetCol(grilla, 4, 530, True)
            End Select
        Finally
            grilla.ResumeLayout(False)
        End Try
    End Sub

    Public Sub grillasTareasNodo(ByVal grilla As DataGridView)
        If grilla Is Nothing Then Exit Sub
        AplicarEstiloModerno(grilla)

        grilla.SuspendLayout()
        Try
            Select Case grilla.Name
            Case "grillaTareasNodo"
                If Not grilla.Columns.Contains("sel_col") Then
                    Dim col_chk As New DataGridViewCheckBoxColumn
                    col_chk.HeaderText = "Sel."
                    col_chk.Name = "sel_col"
                    grilla.Columns.Add(col_chk)
                End If

                SetCol(grilla, 0, -1, True, True)
                SetCol(grilla, 1, -1, True, False)
                SetCol(grilla, 2, 130, True)
                SetCol(grilla, 3, 420, True)
                SetCol(grilla, 4, 80, True)
                SetCol(grilla, 5, 80, True)
                SetCol(grilla, 6, 60, False)
            End Select
        Finally
            grilla.ResumeLayout(False)
        End Try
    End Sub

    Public Sub grillaCargos(ByVal grilla As DataGridView)
        If grilla Is Nothing Then Exit Sub
        AplicarEstiloModerno(grilla)

        grilla.SuspendLayout()
        Try
            Select Case grilla.Name
                Case "grillaCargos"
                    SetCol(grilla, 0, 80)
                    SetCol(grilla, 1, 200)
            End Select
        Finally
            grilla.ResumeLayout(False)
        End Try
    End Sub

    Public Sub grillaPersonal(ByVal grilla As DataGridView)
        If grilla Is Nothing Then Exit Sub
        AplicarEstiloModerno(grilla)

        grilla.SuspendLayout()
        Try
            Select Case grilla.Name
                Case "grillaPersonal"
                    SetCol(grilla, 0, 80)
                    SetCol(grilla, 1, 200)
            End Select
        Finally
            grilla.ResumeLayout(False)
        End Try
    End Sub

    Public Sub grillaCalendario(ByVal grilla As DataGridView)
        If grilla Is Nothing Then Exit Sub
        AplicarEstiloModerno(grilla)

        grilla.SuspendLayout()
        Try
            Select Case grilla.Name
                Case "grillaCalendarioTurno"
                    For Each columna As DataGridViewColumn In grilla.Columns
                        columna.Width = 60
                    Next
            End Select
        Finally
            grilla.ResumeLayout(False)
        End Try
    End Sub

    Public Sub grillaDatosTecnicos(ByVal grilla As DataGridView)
        If grilla Is Nothing Then Exit Sub
        AplicarEstiloModerno(grilla)

        grilla.SuspendLayout()
        Try
            Select Case grilla.Name
                Case "grillaDatosTecnicosNodo"
                    AplicarColumnasDatosTecnicos(grilla, FrmDatosTecnicosNodo.nivel)

                Case "grillaDatosTecnicos"
                    If FrmBuscarDatosTecnicos.nombre_form = "FrmDatosTecnicos" Then
                        SetCol(grilla, 0, 80, Nothing, False)
                        SetCol(grilla, 1, 170)
                        SetCol(grilla, 2, 60)

                    ElseIf FrmBuscarDatosTecnicos.nombre_form = "FrmDatosTecnicosNodo" Then
                        SetCol(grilla, 0, 40)
                        SetCol(grilla, 1, 80, Nothing, False)
                        SetCol(grilla, 2, 170, True)
                        SetCol(grilla, 3, 60, Nothing, False)
                    End If

                Case "grillaDatosTecnicosAsoc"
                    AplicarColumnasDatosTecnicos(grilla, FrmVerDatosTecnicos.nivel)
            End Select
        Finally
            grilla.ResumeLayout(False)
        End Try
    End Sub

    Private Shared Sub AplicarColumnasDatosTecnicos(ByVal grilla As DataGridView, ByVal nivel As Integer)
        If nivel >= 3 Then
            SetCol(grilla, 0, 80, Nothing, False)
            SetCol(grilla, 1, 80, Nothing, False)
            SetCol(grilla, 2, 150, True)
            SetCol(grilla, 3, 180, True)
            SetCol(grilla, 4, 200)
            SetCol(grilla, 5, 100, Nothing, False)
        ElseIf nivel = 2 Then
            SetCol(grilla, 0, 80, Nothing, False)
            SetCol(grilla, 1, 80, Nothing, False)
            SetCol(grilla, 2, 120, True)
            SetCol(grilla, 3, 150, True)
            SetCol(grilla, 4, 180, True)
            SetCol(grilla, 5, 200)
            SetCol(grilla, 6, 100, Nothing, False)
        ElseIf nivel = 1 Then
            SetCol(grilla, 0, 80, Nothing, False)
            SetCol(grilla, 1, 80, Nothing, False)
            SetCol(grilla, 2, 120, True)
            SetCol(grilla, 3, 120, True)
            SetCol(grilla, 4, 150, True)
            SetCol(grilla, 5, 180, True)
            SetCol(grilla, 6, 200)
            SetCol(grilla, 7, 100, Nothing, False)
        End If
    End Sub
End Class
