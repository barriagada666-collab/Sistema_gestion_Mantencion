Imports System.Data.SqlClient
Public Class FrmBuscarPersonal
    Public nombre_form As String
    Public filtro As New DataView
    Private Sub FrmBuscarPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Personal As New Personal
        Dim formato_grid As New FormatoGrillas

        Select Case nombre_form

            Case Is = "personal"
                Dim ds As New DataSet
                Personal.CrgPersonal(ds)
                filtro.Table = ds.Tables(0)
                grillaPersonal.DataSource = ds.Tables(0)
                formato_grid.grillaPersonal(grillaPersonal)
            Case Is = "mp"
                Dim DS As New DataSet
                grilla_personal_2.Visible = True
                btn_agregar_personal.Visible = True
                btn_limpiar.Visible = True
                Personal.BuscarPersonalMp2(DS)
                grillaPersonal.DataSource = DS.Tables(0)
                filtro.Table = DS.Tables(0)
                formato_grid.grillaPersonal(grillaPersonal)

            Case Is = "frm_OT"
                grilla_personal_2.Visible = True
                btn_agregar_personal.Visible = True
                btn_limpiar.Visible = True
                Dim DS As New DataSet
                Personal.BuscarPersonalMp2(DS)
                grillaPersonal.DataSource = DS.Tables(0)
                filtro.Table = DS.Tables(0)
                formato_grid.grillaPersonal(grillaPersonal)
        End Select
        Utilitarios.AjustarColumnasGrilla(grillaPersonal)

    End Sub

    Private Sub grillaPersonal_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaPersonal.CellContentClick

    End Sub

    Private Sub grillaPersonal_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaPersonal.CellContentDoubleClick
        Dim personal As New Personal

        Select Case nombre_form
            Case Is = "personal"
                personal.buscarPersonalRut(CInt(grillaPersonal.Rows(e.RowIndex).Cells(0).Value.ToString()))
                nombre_form = ""
                Me.Close()

            Case Is = "mp"
                With grilla_personal_2
                    .Rows.Add()
                    .Rows(.RowCount - 1).Cells(0).Value = grillaPersonal.Rows(grillaPersonal.CurrentRow.Index).Cells(0).Value
                    .Rows(.RowCount - 1).Cells(1).Value = grillaPersonal.Rows(grillaPersonal.CurrentRow.Index).Cells(1).Value
                End With

            Case Is = "frm_OT"
                With grilla_personal_2
                    .Rows.Add()
                    .Rows(.RowCount - 1).Cells(0).Value = grillaPersonal.Rows(grillaPersonal.CurrentRow.Index).Cells(0).Value
                    .Rows(.RowCount - 1).Cells(1).Value = grillaPersonal.Rows(grillaPersonal.CurrentRow.Index).Cells(1).Value
                End With
        End Select


    End Sub

    Private Sub txtBuscarPersonal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarPersonal.TextChanged
        Dim valorLimpio As String = Utilitarios.EscaparLike(txtBuscarPersonal.Text.Trim())
        If nombre_form = "personal" Then
            filtro.RowFilter = "NOMBRE like '%" & valorLimpio & "%' "
        Else
            filtro.RowFilter = "ALIAS like '%" & valorLimpio & "%' "
        End If
        grillaPersonal.DataSource = filtro
        Utilitarios.AjustarColumnasGrilla(grillaPersonal)
    End Sub

    Private Sub btn_agregar_personal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_personal.Click
        Dim encontrado As Boolean = False


        If nombre_form = "frm_OT" Then

            With frm_OT.grillaPersonalOt
                If frm_OT.DSPOT.Tables.Count > 0 Then
                    For i = 0 To grilla_personal_2.RowCount - 1
                        If .RowCount > 0 Then
                            For j = 0 To .RowCount - 1
                                If .Rows(j).Cells(0).Value = grilla_personal_2.Rows(i).Cells(0).Value Then
                                    encontrado = True
                                    MsgBox("El personal " & grilla_personal_2.Rows(i).Cells(1).Value & " ya esta agregado", MsgBoxStyle.Exclamation, "Validación")
                                End If
                            Next
                        End If
                        If encontrado = False Then
                            Dim fila As DataRow = frm_OT.DSPOT.Tables(0).NewRow
                            fila(0) = grilla_personal_2.Rows(i).Cells(0).Value
                            fila(1) = grilla_personal_2.Rows(i).Cells(1).Value
                            fila(2) = ""
                            frm_OT.DSPOT.Tables(0).Rows.Add(fila)
                        End If
                        encontrado = False
                    Next
                Else
                    For i = 0 To grilla_personal_2.RowCount - 1
                        If .RowCount > 0 Then
                            For j = 0 To .RowCount - 1
                                If .Rows(j).Cells(0).Value = grilla_personal_2.Rows(i).Cells(0).Value Then
                                    encontrado = True
                                    MsgBox("El personal " & grilla_personal_2.Rows(i).Cells(1).Value & " ya esta agregado", MsgBoxStyle.Exclamation, "Validación")
                                End If
                            Next
                        End If
                        If encontrado = False Then
                            .Rows.Add()
                            .Rows(.RowCount - 1).Cells(0).Value = grilla_personal_2.Rows(i).Cells(0).Value
                            .Rows(.RowCount - 1).Cells(1).Value = grilla_personal_2.Rows(i).Cells(1).Value
                        End If
                        encontrado = False
                    Next
                End If

            End With

            Me.Close()

        ElseIf nombre_form = "mp" Then
            With FrmMp.grillaPersonalMp
                If FrmMp.DS2.Tables.Count > 0 Then
                    For i = 0 To grilla_personal_2.RowCount - 1
                        If .RowCount > 0 Then
                            For j = 0 To .RowCount - 1
                                If .Rows(j).Cells(0).Value = grilla_personal_2.Rows(i).Cells(0).Value Then
                                    encontrado = True
                                    MsgBox("El personal " & grilla_personal_2.Rows(i).Cells(1).Value & " ya esta agregado", MsgBoxStyle.Exclamation, "Validación")
                                End If
                            Next
                        End If
                        If encontrado = False Then
                            Dim fila As DataRow = FrmMp.DS2.Tables(0).NewRow
                            fila(0) = grilla_personal_2.Rows(i).Cells(0).Value
                            fila(1) = grilla_personal_2.Rows(i).Cells(1).Value
                            FrmMp.DS2.Tables(0).Rows.Add(fila)
                        End If
                        encontrado = False
                    Next
                Else
                    For i = 0 To grilla_personal_2.RowCount - 1
                        If .RowCount > 0 Then
                            For j = 0 To .RowCount - 1
                                If .Rows(j).Cells(0).Value = grilla_personal_2.Rows(i).Cells(0).Value Then
                                    encontrado = True
                                    MsgBox("El personal " & grilla_personal_2.Rows(i).Cells(1).Value & " ya esta agregado", MsgBoxStyle.Exclamation, "Validación")
                                End If
                            Next
                        End If
                        If encontrado = False Then
                            .Rows.Add()
                            .Rows(.RowCount - 1).Cells(0).Value = grilla_personal_2.Rows(i).Cells(0).Value
                            .Rows(.RowCount - 1).Cells(1).Value = grilla_personal_2.Rows(i).Cells(1).Value
                        End If
                        encontrado = False
                    Next
                End If

            End With

            Me.Close()
        End If
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        If grilla_personal_2.RowCount > 0 Then
            Dim selectedRowCount As Integer = grilla_personal_2.Rows.GetRowCount(DataGridViewElementStates.Selected)
            For I As Integer = 0 To selectedRowCount - 1
                grilla_personal_2.Rows.Remove(grilla_personal_2.SelectedRows(0))
            Next
        End If
    End Sub
End Class