Imports System.Data.SqlClient
Public Class FrmBuscarPersonal
    Public nombre_form As String
    Public filtro As New DataView
    Private Sub FrmBuscarPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Dim Personal As New Personal
            Dim formato_grid As New FormatoGrillas

            Select Case nombre_form

                Case Is = "personal"
                    Dim ds As New DataSet
                    Personal.CrgPersonal(ds)
                    If ds.Tables.Count > 0 Then
                        filtro.Table = ds.Tables(0)
                        grillaPersonal.DataSource = ds.Tables(0)
                        formato_grid.grillaPersonal(grillaPersonal)
                    End If
                Case Is = "mp"
                    Dim DS As New DataSet
                    grilla_personal_2.Visible = True
                    btn_agregar_personal.Visible = True
                    btn_limpiar.Visible = True
                    Personal.BuscarPersonalMp2(DS)
                    If DS.Tables.Count > 0 Then
                        grillaPersonal.DataSource = DS.Tables(0)
                        filtro.Table = DS.Tables(0)
                        formato_grid.grillaPersonal(grillaPersonal)
                    End If

                Case Is = "frm_OT"
                    grilla_personal_2.Visible = True
                    btn_agregar_personal.Visible = True
                    btn_limpiar.Visible = True
                    Dim DS As New DataSet
                    Personal.BuscarPersonalMp2(DS)
                    If DS.Tables.Count > 0 Then
                        grillaPersonal.DataSource = DS.Tables(0)
                        filtro.Table = DS.Tables(0)
                        formato_grid.grillaPersonal(grillaPersonal)
                    End If
            End Select
            Utilitarios.AjustarColumnasGrilla(grillaPersonal)
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Personal (Carga)", True, Me)
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub FrmBuscarPersonal_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        nombre_form = ""
    End Sub

    Private Sub grillaPersonal_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaPersonal.CellContentDoubleClick
        If e.RowIndex < 0 OrElse grillaPersonal.Rows(e.RowIndex).IsNewRow Then Exit Sub
        Try
            Dim personal As New Personal
            Dim rutStr As String = Convert.ToString(grillaPersonal.Rows(e.RowIndex).Cells(0).Value).Trim()
            Dim nombreStr As String = Convert.ToString(grillaPersonal.Rows(e.RowIndex).Cells(1).Value)

            Select Case nombre_form
                Case "personal"
                    Dim rutInt As Integer = 0
                    If Integer.TryParse(rutStr, rutInt) Then
                        personal.buscarPersonalRut(rutInt)
                    End If
                    nombre_form = ""
                    Me.Close()

                Case "mp", "frm_OT"
                    For Each r As DataGridViewRow In grilla_personal_2.Rows
                        If String.Equals(Convert.ToString(r.Cells(0).Value).Trim(), rutStr, StringComparison.OrdinalIgnoreCase) Then
                            MsgBox("El personal " & nombreStr & " ya fue seleccionado en la lista.", MsgBoxStyle.Information, "Validación")
                            Exit Sub
                        End If
                    Next
                    With grilla_personal_2
                        .Rows.Add()
                        .Rows(.RowCount - 1).Cells(0).Value = rutStr
                        .Rows(.RowCount - 1).Cells(1).Value = nombreStr
                    End With
            End Select
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Personal (Seleccionar)", True, Me)
        End Try
    End Sub

    Private Sub txtBuscarPersonal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarPersonal.TextChanged
        Try
            If filtro.Table Is Nothing Then Exit Sub
            Dim valorLimpio As String = Utilitarios.EscaparLike(txtBuscarPersonal.Text.Trim())
            If nombre_form = "personal" Then
                filtro.RowFilter = "NOMBRE like '%" & valorLimpio & "%' "
            Else
                filtro.RowFilter = "ALIAS like '%" & valorLimpio & "%' "
            End If
            grillaPersonal.DataSource = filtro
            Utilitarios.AjustarColumnasGrilla(grillaPersonal)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Personal (Filtro)", True, Me)
        End Try
    End Sub

    Private Sub btn_agregar_personal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_personal.Click
        Try
            If nombre_form = "frm_OT" Then
                With frm_OT.grillaPersonalOt
                    If frm_OT.DSPOT.Tables.Count > 0 Then
                        For i = 0 To grilla_personal_2.RowCount - 1
                            If grilla_personal_2.Rows(i).IsNewRow Then Continue For
                            Dim rutStr As String = Convert.ToString(grilla_personal_2.Rows(i).Cells(0).Value).Trim()
                            Dim nomStr As String = Convert.ToString(grilla_personal_2.Rows(i).Cells(1).Value)
                            Dim encontrado As Boolean = False
                            For j = 0 To .RowCount - 1
                                If String.Equals(Convert.ToString(.Rows(j).Cells(0).Value).Trim(), rutStr, StringComparison.OrdinalIgnoreCase) Then
                                    encontrado = True
                                    MsgBox("El personal " & nomStr & " ya está agregado", MsgBoxStyle.Exclamation, "Validación")
                                    Exit For
                                End If
                            Next
                            If Not encontrado Then
                                Dim fila As DataRow = frm_OT.DSPOT.Tables(0).NewRow
                                fila(0) = rutStr
                                fila(1) = nomStr
                                fila(2) = ""
                                frm_OT.DSPOT.Tables(0).Rows.Add(fila)
                            End If
                        Next
                    Else
                        For i = 0 To grilla_personal_2.RowCount - 1
                            If grilla_personal_2.Rows(i).IsNewRow Then Continue For
                            Dim rutStr As String = Convert.ToString(grilla_personal_2.Rows(i).Cells(0).Value).Trim()
                            Dim nomStr As String = Convert.ToString(grilla_personal_2.Rows(i).Cells(1).Value)
                            Dim encontrado As Boolean = False
                            For j = 0 To .RowCount - 1
                                If String.Equals(Convert.ToString(.Rows(j).Cells(0).Value).Trim(), rutStr, StringComparison.OrdinalIgnoreCase) Then
                                    encontrado = True
                                    MsgBox("El personal " & nomStr & " ya está agregado", MsgBoxStyle.Exclamation, "Validación")
                                    Exit For
                                End If
                            Next
                            If Not encontrado Then
                                .Rows.Add()
                                .Rows(.RowCount - 1).Cells(0).Value = rutStr
                                .Rows(.RowCount - 1).Cells(1).Value = nomStr
                            End If
                        Next
                    End If
                End With
                Me.Close()

            ElseIf nombre_form = "mp" Then
                With FrmMp.grillaPersonalMp
                    If FrmMp.DS2.Tables.Count > 0 Then
                        For i = 0 To grilla_personal_2.RowCount - 1
                            If grilla_personal_2.Rows(i).IsNewRow Then Continue For
                            Dim rutStr As String = Convert.ToString(grilla_personal_2.Rows(i).Cells(0).Value).Trim()
                            Dim nomStr As String = Convert.ToString(grilla_personal_2.Rows(i).Cells(1).Value)
                            Dim encontrado As Boolean = False
                            For j = 0 To .RowCount - 1
                                If String.Equals(Convert.ToString(.Rows(j).Cells(0).Value).Trim(), rutStr, StringComparison.OrdinalIgnoreCase) Then
                                    encontrado = True
                                    MsgBox("El personal " & nomStr & " ya está agregado", MsgBoxStyle.Exclamation, "Validación")
                                    Exit For
                                End If
                            Next
                            If Not encontrado Then
                                Dim fila As DataRow = FrmMp.DS2.Tables(0).NewRow
                                fila(0) = rutStr
                                fila(1) = nomStr
                                FrmMp.DS2.Tables(0).Rows.Add(fila)
                            End If
                        Next
                    Else
                        For i = 0 To grilla_personal_2.RowCount - 1
                            If grilla_personal_2.Rows(i).IsNewRow Then Continue For
                            Dim rutStr As String = Convert.ToString(grilla_personal_2.Rows(i).Cells(0).Value).Trim()
                            Dim nomStr As String = Convert.ToString(grilla_personal_2.Rows(i).Cells(1).Value)
                            Dim encontrado As Boolean = False
                            For j = 0 To .RowCount - 1
                                If String.Equals(Convert.ToString(.Rows(j).Cells(0).Value).Trim(), rutStr, StringComparison.OrdinalIgnoreCase) Then
                                    encontrado = True
                                    MsgBox("El personal " & nomStr & " ya está agregado", MsgBoxStyle.Exclamation, "Validación")
                                    Exit For
                                End If
                            Next
                            If Not encontrado Then
                                .Rows.Add()
                                .Rows(.RowCount - 1).Cells(0).Value = rutStr
                                .Rows(.RowCount - 1).Cells(1).Value = nomStr
                            End If
                        Next
                    End If
                End With
                Me.Close()
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Personal (Agregar)", True, Me)
        End Try
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Try
            If grilla_personal_2.RowCount > 0 Then
                If grilla_personal_2.SelectedRows.Count > 0 Then
                    For i As Integer = grilla_personal_2.SelectedRows.Count - 1 To 0 Step -1
                        Dim row As DataGridViewRow = grilla_personal_2.SelectedRows(i)
                        If Not row.IsNewRow Then grilla_personal_2.Rows.Remove(row)
                    Next
                ElseIf grilla_personal_2.CurrentRow IsNot Nothing AndAlso Not grilla_personal_2.CurrentRow.IsNewRow Then
                    grilla_personal_2.Rows.Remove(grilla_personal_2.CurrentRow)
                End If
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Personal (Limpiar)", True, Me)
        End Try
    End Sub
End Class