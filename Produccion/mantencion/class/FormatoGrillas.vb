Public Class FormatoGrillas

    Public Sub grillasOT(ByVal grilla As DataGridView)
        Select Case grilla.Name
            Case Is = "grillaPersonalOt"
                If grilla.Columns.Count = 0 Then
                    frm_OT.grillaPersonalOt.Columns.Add("RUT", "Rut")
                    frm_OT.grillaPersonalOt.Columns.Add("Alias_personal", "Alias")
                    frm_OT.grillaPersonalOt.Columns.Add("observacion_ot", "Observación")
                End If
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 80
                grilla.Columns(2).Width = 395
                grilla.Columns(0).ReadOnly = True
                grilla.Columns(1).ReadOnly = True
                

            Case Is = "grillaOtExternas"
                If grilla.Columns.Count = 0 Then
                    frm_OT.grillaOtExternas.Columns.Add("n_ot_externa", "N°De OT Externa")
                    frm_OT.grillaOtExternas.Columns.Add("desc_ot_externa", "Descripción OT Externa")
                End If
                grilla.Columns(0).Width = 120
                grilla.Columns(1).Width = 435
                
            Case Is = "grillaInsumosOt"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 100
                grilla.Columns(2).Width = 220
                grilla.Columns(3).Width = 65
                grilla.Columns(4).Width = 80
                grilla.Columns(5).Width = 102

            Case Is = "grillaInfOt"
                grilla.Columns(0).Width = 70
                grilla.Columns(2).Width = 150
                grilla.Columns(3).Width = 120
                grilla.Columns(4).Width = 120
                grilla.Columns(5).Width = 100
                grilla.Columns(6).Width = 80
                grilla.Columns(7).Width = 200
                grilla.Columns(8).Width = 120
                grilla.Columns(9).Width = 120
                grilla.Columns(10).Width = 100

            Case Is = "grillaDetalleOtPend"
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 120
                grilla.Columns(2).Width = 120
                grilla.Columns(3).Width = 100
                grilla.Columns(4).Width = 120
                grilla.Columns(5).Width = 200

            Case Is = "grillaDetalleOtTecnicos"
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 120
                grilla.Columns(2).Width = 120
                grilla.Columns(3).Width = 100
                grilla.Columns(4).Width = 120
                grilla.Columns(5).Width = 120
                grilla.Columns(7).Width = 200

            Case Is = "grillaOtTipoFalla"
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 120
                grilla.Columns(2).Width = 120
                grilla.Columns(3).Width = 100
                grilla.Columns(4).Width = 120
                grilla.Columns(5).Width = 120
                grilla.Columns(7).Width = 200

            Case Is = "grillaOtDetalleTurno"
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 120
                grilla.Columns(2).Width = 120
                grilla.Columns(3).Width = 100
                grilla.Columns(4).Width = 120
                grilla.Columns(5).Width = 120
                grilla.Columns(8).Width = 200

            Case Is = "grillaOtDetalleDia"
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 120
                grilla.Columns(2).Width = 120
                grilla.Columns(3).Width = 100
                grilla.Columns(4).Width = 120
                grilla.Columns(5).Width = 120
                grilla.Columns(7).Width = 200

            Case Is = "grillaDetalleOtEstado"
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 120
                grilla.Columns(2).Width = 120
                grilla.Columns(3).Width = 100
                grilla.Columns(4).Width = 120
                grilla.Columns(5).Width = 120
                grilla.Columns(7).Width = 200
        End Select
                
    End Sub

    Public Sub grillasMp(ByVal grilla As DataGridView)
        Select Case grilla.Name
            Case Is = "grillaInfMant"
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 120
                grilla.Columns(2).Width = 130
                grilla.Columns(4).Width = 140
                grilla.Columns(5).Width = 80

            Case Is = "grillaDetalleCicloMp"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 120
                grilla.Columns(2).Width = 120
                grilla.Columns(3).Width = 100
                grilla.Columns(4).Width = 210
                grilla.Columns(5).Width = 70

            Case Is = "grillaTareasInfMp"
                grilla.Columns(0).Width = 120
                grilla.Columns(1).Width = 330
                grilla.Columns(2).Width = 90
                grilla.Columns(3).Width = 180

            Case Is = "grillaTareasCicloMp"
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Visible = False
                grilla.Columns(2).Visible = False
                grilla.Columns(3).Width = 120
                grilla.Columns(3).ReadOnly = True
                grilla.Columns(4).Width = 300
                grilla.Columns(4).ReadOnly = True
                grilla.Columns(5).Width = 50
                grilla.Columns(6).Width = 140

            Case Is = "grillaInsumosMp"
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 70
                grilla.Columns(1).ReadOnly = True
                grilla.Columns(2).Width = 50
                grilla.Columns(2).ReadOnly = True
                grilla.Columns(3).Width = 170
                grilla.Columns(4).Width = 50
                grilla.Columns(5).Width = 140
                grilla.Columns(0).ReadOnly = True
                grilla.Columns(1).ReadOnly = True
                grilla.Columns(2).ReadOnly = True
                grilla.EnableHeadersVisualStyles = False
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "grillaBuscarMp"

                grilla.Columns(0).Width = 65
                grilla.Columns(1).Width = 100
                grilla.Columns(2).Width = 130
                grilla.Columns(3).Width = 50
                grilla.Columns(4).Width = 120
                grilla.Columns(5).Width = 80
                grilla.Columns(6).Width = 200

            Case Is = "grillaBuscarCiclo"

                grilla.Columns(0).Width = 75
                grilla.Columns(1).Width = 70
                grilla.Columns(2).Width = 60
                grilla.Columns(3).Width = 70
                grilla.Columns(4).Width = 60
                grilla.Columns(5).Width = 90
                grilla.Columns(6).Width = 200
                grilla.Columns(7).Width = 70

            Case Is = "grillaPersonalMp"
                grilla.EnableHeadersVisualStyles = False
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 140
                grilla.Columns(0).ReadOnly = True
                grilla.Columns(1).ReadOnly = True

            Case Is = "grillaInsumos"

                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 90
                grilla.Columns(2).Width = 300
                grilla.Columns(3).Width = 50
                grilla.Columns(0).ReadOnly = True
                grilla.Columns(1).ReadOnly = True

            Case Is = "grillaPersonalInfMp"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 150
                grilla.Columns(2).Width = 150


            Case Is = "grillaInsumosInfMp"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 380
                grilla.Columns(2).Width = 80
                grilla.Columns(3).Width = 80
                grilla.Columns(4).Width = 60
                

            Case Is = "grillaTareasPendInfMp"

                If FrmInfMantPrev.opcfiltroTareas.Checked Then
                    grilla.Columns(0).Width = 70
                    grilla.Columns(1).Width = 70
                    grilla.Columns(2).Width = 70
                    grilla.Columns(3).Width = 300
                    grilla.Columns(4).Width = 300
                    
                Else
                    grilla.Columns(0).Width = 70
                    grilla.Columns(1).Width = 340
                    grilla.Columns(2).Width = 260
                    
                End If

            Case Is = "grillaTareasAdMp"

                grilla.Columns(1).Visible = False
                grilla.Columns(2).Visible = False
                grilla.Columns(3).Width = 120
                grilla.Columns(4).Width = 120
                grilla.Columns(5).Width = 340

            Case Is = "grillaCiclosMaquinas"

                grilla.Columns(0).Width = 80
                grilla.Columns(3).Width = 180
                grilla.Columns(4).Width = 80
                grilla.Columns(5).Width = 80
                grilla.Columns(6).Width = 90

            Case Is = "grillaTareasNodoMp"

                grilla.Columns(3).Width = 100
                grilla.Columns(4).Width = 530
                grilla.Columns(1).Visible = False
                grilla.Columns(2).Visible = False
                grilla.Columns(3).ReadOnly = True
                grilla.Columns(4).ReadOnly = True

        End Select
    End Sub

    Public Sub grillasTareasNodo(ByVal grilla As DataGridView)
        Select Case grilla.Name
            Case Is = "grillaTareasNodo"
                Dim col_chk As New DataGridViewCheckBoxColumn

                col_chk.HeaderText = "Sel."
                col_chk.Name = "sel_col"
                grilla.Columns.Add(col_chk)

                grilla.Columns(0).Visible = True
                grilla.Columns(1).Visible = False
                grilla.Columns(2).Width = 130
                grilla.Columns(3).Width = 420
                grilla.Columns(4).Width = 80
                grilla.Columns(5).Width = 80
                grilla.Columns(6).Width = 60

                grilla.Columns(0).ReadOnly = True
                grilla.Columns(1).ReadOnly = True
                grilla.Columns(2).ReadOnly = True
                grilla.Columns(3).ReadOnly = True
                grilla.Columns(4).ReadOnly = True
                grilla.Columns(5).ReadOnly = True
                grilla.Columns(6).ReadOnly = False
        End Select
    End Sub

    Public Sub grillaCargos(ByVal grilla As DataGridView)
        Select Case grilla.Name
            Case Is = "grillaCargos"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 200
               
        End Select
    End Sub

    Public Sub grillaPersonal(ByVal grilla As DataGridView)
        Select Case grilla.Name
            Case Is = "grillaPersonal"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 200

        End Select
    End Sub

    Public Sub grillaCalendario(ByVal grilla As DataGridView)
        Select Case grilla.Name
            Case Is = "grillaCalendarioTurno"
                For Each columna As DataGridViewColumn In grilla.Columns
                    columna.Width = 60
                Next

        End Select
    End Sub

    Public Sub grillaDatosTecnicos(ByVal grilla As DataGridView)
        Select Case grilla.Name
            Case Is = "grillaDatosTecnicosNodo"
                If FrmDatosTecnicosNodo.nivel >= 3 Then
                    grilla.Columns(0).Width = 80
                    grilla.Columns(1).Width = 80
                    grilla.Columns(2).Width = 150
                    grilla.Columns(3).Width = 180
                    grilla.Columns(4).Width = 200
                    grilla.Columns(5).Width = 100

                    grilla.Columns(0).Visible = False
                    grilla.Columns(1).Visible = False
                    grilla.Columns(5).Visible = False

                    grilla.Columns(2).ReadOnly = True
                    grilla.Columns(3).ReadOnly = True

                ElseIf FrmDatosTecnicosNodo.nivel = 2 Then
                    grilla.Columns(0).Width = 80
                    grilla.Columns(1).Width = 80
                    grilla.Columns(2).Width = 120
                    grilla.Columns(3).Width = 150
                    grilla.Columns(4).Width = 180
                    grilla.Columns(5).Width = 200
                    grilla.Columns(6).Width = 100

                    grilla.Columns(0).Visible = False
                    grilla.Columns(1).Visible = False
                    grilla.Columns(6).Visible = False

                    grilla.Columns(2).ReadOnly = True
                    grilla.Columns(3).ReadOnly = True
                    grilla.Columns(4).ReadOnly = True

                ElseIf FrmDatosTecnicosNodo.nivel = 1 Then
                    grilla.Columns(0).Width = 80
                    grilla.Columns(1).Width = 80
                    grilla.Columns(2).Width = 120
                    grilla.Columns(3).Width = 120
                    grilla.Columns(4).Width = 150
                    grilla.Columns(5).Width = 180
                    grilla.Columns(6).Width = 200
                    grilla.Columns(7).Width = 100

                    grilla.Columns(0).Visible = False
                    grilla.Columns(1).Visible = False
                    grilla.Columns(7).Visible = False

                    grilla.Columns(2).ReadOnly = True
                    grilla.Columns(3).ReadOnly = True
                    grilla.Columns(4).ReadOnly = True
                    grilla.Columns(5).ReadOnly = True
                End If
                
            Case Is = "grillaDatosTecnicos"

                If FrmBuscarDatosTecnicos.nombre_form = "FrmDatosTecnicos" Then
                    grilla.Columns(0).Width = 80
                    grilla.Columns(1).Width = 170
                    grilla.Columns(2).Width = 60

                    grilla.Columns(0).Visible = False

                ElseIf FrmBuscarDatosTecnicos.nombre_form = "FrmDatosTecnicosNodo" Then
                    grilla.Columns(0).Width = 40
                    grilla.Columns(1).Width = 80
                    grilla.Columns(2).Width = 170
                    grilla.Columns(3).Width = 60

                    grilla.Columns(2).ReadOnly = True
                    grilla.Columns(1).Visible = False
                    grilla.Columns(3).Visible = False
                End If

            Case Is = "grillaDatosTecnicosAsoc"
                If FrmVerDatosTecnicos.nivel >= 3 Then
                    grilla.Columns(0).Width = 80
                    grilla.Columns(1).Width = 80
                    grilla.Columns(2).Width = 150
                    grilla.Columns(3).Width = 180
                    grilla.Columns(4).Width = 200
                    grilla.Columns(5).Width = 100

                    grilla.Columns(0).Visible = False
                    grilla.Columns(1).Visible = False
                    grilla.Columns(5).Visible = False

                    grilla.Columns(2).ReadOnly = True
                    grilla.Columns(3).ReadOnly = True

                ElseIf FrmVerDatosTecnicos.nivel = 2 Then
                    grilla.Columns(0).Width = 80
                    grilla.Columns(1).Width = 80
                    grilla.Columns(2).Width = 120
                    grilla.Columns(3).Width = 150
                    grilla.Columns(4).Width = 180
                    grilla.Columns(5).Width = 200
                    grilla.Columns(6).Width = 100

                    grilla.Columns(0).Visible = False
                    grilla.Columns(1).Visible = False
                    grilla.Columns(6).Visible = False

                    grilla.Columns(2).ReadOnly = True
                    grilla.Columns(3).ReadOnly = True
                    grilla.Columns(4).ReadOnly = True

                ElseIf FrmVerDatosTecnicos.nivel = 1 Then
                    grilla.Columns(0).Width = 80
                    grilla.Columns(1).Width = 80
                    grilla.Columns(2).Width = 120
                    grilla.Columns(3).Width = 120
                    grilla.Columns(4).Width = 150
                    grilla.Columns(5).Width = 180
                    grilla.Columns(6).Width = 200
                    grilla.Columns(7).Width = 100

                    grilla.Columns(0).Visible = False
                    grilla.Columns(1).Visible = False
                    grilla.Columns(7).Visible = False

                    grilla.Columns(2).ReadOnly = True
                    grilla.Columns(3).ReadOnly = True
                    grilla.Columns(4).ReadOnly = True
                    grilla.Columns(5).ReadOnly = True
                End If

        End Select
    End Sub
End Class
