Public Class FormatoGrillas2

    Private Sub AplicarEstilo(ByVal grilla As DataGridView)
        Dim fg As New FormatoGrillas()
        fg.AplicarEstiloModerno(grilla)
    End Sub

    Public Sub grillasOT(ByVal grilla As DataGridView)
        Select Case grilla.Name
            Case Is = "grillaPersonalOt"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 80
                grilla.Columns(2).Width = 395
                grilla.Columns(0).ReadOnly = True
                grilla.Columns(1).ReadOnly = True
                AplicarEstilo(grilla)

            Case Is = "grillaOtExternas"
                grilla.Columns(0).Width = 120
                grilla.Columns(1).Width = 435
                AplicarEstilo(grilla)

            Case Is = "grillaInsumosOt"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 100
                grilla.Columns(2).Width = 220
                grilla.Columns(3).Width = 65
                grilla.Columns(4).Width = 80
                grilla.Columns(5).Width = 102
                AplicarEstilo(grilla)

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
                AplicarEstilo(grilla)

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
                AplicarEstilo(grilla)

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
                AplicarEstilo(grilla)
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
                AplicarEstilo(grilla)

            Case Is = "DGVBUSCAR"
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 70
                grilla.Columns(2).Width = 100
                grilla.Columns(3).Width = 100
                grilla.Columns(4).Width = 70
                grilla.Columns(5).Width = 400
                AplicarEstilo(grilla)

        End Select
    End Sub

    Public Sub grillasMp(ByVal grilla As DataGridView)
        Select Case grilla.Name
            Case Is = "grillaInfMant"
                grilla.Columns(0).Width = 60
                grilla.Columns(1).Width = 80
                grilla.Columns(2).Width = 120
                grilla.Columns(5).Width = 80
                AplicarEstilo(grilla)

            Case Is = "grillaDetalleCicloMp"
                grilla.Columns(0).Width = 60
                grilla.Columns(2).Width = 120
                grilla.Columns(3).Width = 70
                grilla.Columns(5).Width = 70
                AplicarEstilo(grilla)

            Case Is = "grillaTareasInfMp"
                grilla.Columns(0).Width = 90
                grilla.Columns(2).Width = 90
                AplicarEstilo(grilla)

            Case Is = "grillaTareasCicloMp"
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 85
                grilla.Columns(1).ReadOnly = True
                grilla.Columns(2).Width = 170
                grilla.Columns(2).ReadOnly = True
                grilla.Columns(3).Width = 50
                grilla.Columns(4).Width = 140
                AplicarEstilo(grilla)

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
                AplicarEstilo(grilla)

            Case Is = "grillaBuscarMp"
                grilla.Columns(0).Width = 65
                grilla.Columns(1).Width = 70
                grilla.Columns(1).ReadOnly = True
                grilla.Columns(2).Width = 100
                grilla.Columns(2).ReadOnly = True
                grilla.Columns(3).Width = 50
                grilla.Columns(4).Width = 110
                grilla.Columns(5).Width = 80
                AplicarEstilo(grilla)

            Case Is = "grillaBuscarCiclo"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 70
                grilla.Columns(2).Width = 70
                grilla.Columns(3).Width = 70
                grilla.Columns(4).Width = 70
                grilla.Columns(5).Width = 70
                grilla.Columns(6).Width = 200
                grilla.Columns(7).Width = 70
                AplicarEstilo(grilla)

            Case Is = "grillaPersonalMp"
                grilla.Columns(0).Width = 70
                grilla.Columns(1).Width = 140
                grilla.Columns(0).ReadOnly = True
                grilla.Columns(1).ReadOnly = True
                AplicarEstilo(grilla)

            Case Is = "grillaInsumos"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 90
                grilla.Columns(2).Width = 300
                grilla.Columns(3).Width = 50
                grilla.Columns(0).ReadOnly = True
                grilla.Columns(1).ReadOnly = True
                AplicarEstilo(grilla)

            Case Is = "grillaPersonalInfMp"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 150
                grilla.Columns(2).Width = 150
                AplicarEstilo(grilla)

            Case Is = "grillaInsumosInfMp"
                grilla.Columns(0).Width = 80
                grilla.Columns(1).Width = 260
                grilla.Columns(2).Width = 80
                grilla.Columns(3).Width = 80
                grilla.Columns(4).Width = 90
                AplicarEstilo(grilla)

            Case Is = "grillaTareasPendInfMp"
                AplicarEstilo(grilla)

        End Select
    End Sub
End Class
