Public Class FormatoGrillas2

    Public Sub grillasOT(ByVal grilla As DataGridView)
        Select Case grilla.Name
            Case Is = "grillaPersonalOt"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 80
                grilla.Columns(2).Width = 395
                grilla.Columns(0).ReadOnly = True
                grilla.Columns(1).ReadOnly = True
                grilla.EnableHeadersVisualStyles = False
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "grillaOtExternas"
                grilla.Columns(0).Width = 120
                grilla.Columns(1).Width = 435
                grilla.EnableHeadersVisualStyles = False
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "grillaInsumosOt"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 100
                grilla.Columns(2).Width = 220
                grilla.Columns(3).Width = 65
                grilla.Columns(4).Width = 80
                grilla.Columns(5).Width = 102
                grilla.EnableHeadersVisualStyles = False
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

        End Select
    End Sub

    Public Sub grillas_facturas(ByVal grilla As DataGridView)
        Select Case grilla.Name
            Case Is = "DGVBUSCAR_FAC"
                grilla.Columns(0).Visible = True
                grilla.Columns(0).Width = 65
                grilla.Columns(1).Width = 95
                grilla.Columns(2).Width = 100
                grilla.Columns(3).Width = 70
                grilla.Columns(4).Width = 70
                grilla.Columns(5).Width = 150
                grilla.EnableHeadersVisualStyles = False
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "DGVFAC"
                If grilla.ColumnCount = 0 Then
                    grilla.Columns.Add("IDOT", "ID OT")
                    grilla.Columns.Add("IDOT", "ID Detalle")
                    grilla.Columns.Add("NOT", "N° OT")
                    grilla.Columns.Add("prov", "Proveedor")
                    grilla.Columns.Add("Valor", "Valor")
                    grilla.Columns.Add("Detalle", "Detalle de trabajo")
                    grilla.Columns.Add("Estado", "Estado")
                End If
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 80
                grilla.Columns(2).Width = 80
                grilla.Columns(3).Width = 90
                grilla.Columns(4).Width = 100
                grilla.Columns(5).Width = 310
                grilla.Columns(6).Width = 90
                grilla.Columns(0).Visible = False
                grilla.Columns(1).Visible = False

                grilla.EnableHeadersVisualStyles = False
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "DGVBUSCAR"
                If grilla.ColumnCount = 0 Then
                    grilla.Columns.Add("nombre_prov", "Proveedor")
                    grilla.Columns.Add("num_factura", "N°de factura")
                    grilla.Columns.Add("fecha_factura", "Fecha de recepción")
                    grilla.Columns.Add("total_facturado", "Total")
                    grilla.Columns.Add("detalle_fac", "Detalle")
                    'grilla.Columns.Add("desc_nodo", "Centro de costo")
                End If
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 100
                grilla.Columns(2).Width = 130
                grilla.Columns(3).Width = 90
                grilla.Columns(4).Width = 400
                'grilla.Columns(5).Width = 100

                grilla.EnableHeadersVisualStyles = False
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue
        End Select

    End Sub

    Public Sub grillas_OtExt(ByVal grilla As DataGridView)

        Select Case grilla.Name
            Case Is = "dgvOT"
                If grilla.ColumnCount = 0 Then
                    grilla.Columns.Add("id_detalle_ot", "id_detalle_ot")
                    grilla.Columns.Add("n_ot", "N°OT")
                    grilla.Columns.Add("CANTIDAD", "CANTIDAD")
                    grilla.Columns.Add("DETALLE", "DETALLE")
                    grilla.Columns.Add("ESTADO", "ESTADO")
                End If

                grilla.Columns(1).Width = 80
                grilla.Columns(2).Width = 120
                grilla.Columns(3).Width = 350
                grilla.Columns(4).Width = 100
                grilla.Columns(0).Visible = False
                grilla.EnableHeadersVisualStyles = False
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "DGVBUSCAR"
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 70
                grilla.Columns(2).Width = 100
                grilla.Columns(3).Width = 100
                grilla.Columns(4).Width = 70
                grilla.Columns(5).Width = 400
                grilla.EnableHeadersVisualStyles = False
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue



        End Select
    End Sub

    Public Sub grillasMp(ByVal grilla As DataGridView)
        Select Case grilla.Name
            Case Is = "grillaInfMant"
                grilla.Columns(0).Width = 60
                grilla.Columns(1).Width = 80
                grilla.Columns(2).Width = 120
                grilla.Columns(5).Width = 80
                grilla.EnableHeadersVisualStyles = False
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "grillaDetalleCicloMp"
                grilla.Columns(0).Width = 60
                grilla.Columns(2).Width = 120
                grilla.Columns(3).Width = 70
                grilla.Columns(5).Width = 70
                grilla.EnableHeadersVisualStyles = False
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "grillaTareasInfMp"
                grilla.Columns(0).Width = 90
                grilla.Columns(2).Width = 90
                grilla.EnableHeadersVisualStyles = False
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "grillaTareasCicloMp"
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 85
                grilla.Columns(1).ReadOnly = True
                grilla.Columns(2).Width = 170
                grilla.Columns(2).ReadOnly = True
                grilla.Columns(3).Width = 50
                grilla.Columns(4).Width = 140
                grilla.EnableHeadersVisualStyles = False
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

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
                grilla.EnableHeadersVisualStyles = False
                grilla.Columns(0).Width = 65
                grilla.Columns(1).Width = 70
                grilla.Columns(1).ReadOnly = True
                grilla.Columns(2).Width = 100
                grilla.Columns(2).ReadOnly = True
                grilla.Columns(3).Width = 50
                grilla.Columns(4).Width = 110
                grilla.Columns(5).Width = 80

                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "grillaBuscarCiclo"
                grilla.EnableHeadersVisualStyles = False
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 70
                grilla.Columns(2).Width = 70
                grilla.Columns(3).Width = 70
                grilla.Columns(4).Width = 70
                grilla.Columns(5).Width = 70
                grilla.Columns(6).Width = 200
                grilla.Columns(7).Width = 70
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "grillaPersonalMp"
                grilla.EnableHeadersVisualStyles = False
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 140
                grilla.Columns(0).ReadOnly = True
                grilla.Columns(1).ReadOnly = True
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "grillaInsumos"
                grilla.EnableHeadersVisualStyles = False
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 90
                grilla.Columns(2).Width = 300
                grilla.Columns(3).Width = 50
                grilla.Columns(0).ReadOnly = True
                grilla.Columns(1).ReadOnly = True
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "grillaPersonalInfMp"
                grilla.EnableHeadersVisualStyles = False
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 150
                grilla.Columns(2).Width = 150
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "grillaInsumosInfMp"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 260
                grilla.Columns(2).Width = 80
                grilla.Columns(3).Width = 80
                grilla.Columns(4).Width = 90
                grilla.EnableHeadersVisualStyles = False
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                grilla.RowsDefaultCellStyle.BackColor = Color.White
                grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue

            Case Is = "grillaTareasPendInfMp"

                'If FrmInfMantPrev.opcfiltroTareas.Checked Then
                '    grilla.Columns(0).Width = 70
                '    grilla.Columns(1).Width = 70
                '    grilla.Columns(2).Width = 75
                '    grilla.Columns(3).Width = 190
                '    grilla.Columns(4).Width = 190
                '    grilla.EnableHeadersVisualStyles = False
                '    grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                '    grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                '    grilla.RowsDefaultCellStyle.BackColor = Color.White
                '    grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue
                'Else
                '    grilla.Columns(0).Width = 90
                '    grilla.Columns(1).Width = 250
                '    grilla.Columns(2).Width = 250
                '    grilla.EnableHeadersVisualStyles = False
                '    grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
                '    grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                '    grilla.RowsDefaultCellStyle.BackColor = Color.White
                '    grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue
                'End If


        End Select
    End Sub
End Class
