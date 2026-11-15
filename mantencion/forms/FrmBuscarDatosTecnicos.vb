Public Class FrmBuscarDatosTecnicos
    Public nombre_form As String

    Private Sub FrmBuscarDatosTecnicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Dim datos_tecnicos As New DatosTecnicos
            Dim formato_grid As New FormatoGrillas
            Dim DST_DATOS_TECNICOS As New DataSet

            grillaDatosTecnicos.SuspendLayout()
            Try
                If nombre_form = "FrmDatosTecnicos" Then
                    datos_tecnicos.CrgDatosTecnicos(DST_DATOS_TECNICOS)
                    If DST_DATOS_TECNICOS.Tables.Count > 0 Then
                        grillaDatosTecnicos.DataSource = DST_DATOS_TECNICOS.Tables(0)
                        formato_grid.grillaDatosTecnicos(grillaDatosTecnicos)
                    End If
                    btnAgregar.Visible = False
                    chkSelTodo.Visible = False
                ElseIf nombre_form = "FrmDatosTecnicosNodo" Then
                    Dim columnaCheckBox As New DataGridViewCheckBoxColumn
                    datos_tecnicos.CrgDatosTecnicos(DST_DATOS_TECNICOS)
                    columnaCheckBox.Name = "sel_datos"
                    columnaCheckBox.HeaderText = "Sel."
                    grillaDatosTecnicos.Columns.Add(columnaCheckBox)
                    If DST_DATOS_TECNICOS.Tables.Count > 0 Then
                        grillaDatosTecnicos.DataSource = DST_DATOS_TECNICOS.Tables(0)
                        formato_grid.grillaDatosTecnicos(grillaDatosTecnicos)
                    End If
                    btnAgregar.Visible = True
                    btnCambiarEstado.Visible = False
                End If
            Catch ex As Exception
                RegistroErrores.MostrarYRegistrar(ex, "Buscar Datos Técnicos", True, Me)
            Finally
                grillaDatosTecnicos.ResumeLayout(False)
            End Try
            Utilitarios.AjustarColumnasGrilla(grillaDatosTecnicos)
            Utilitarios.AplicarTemaModerno(Me)
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub grillaDatosTecnicos_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaDatosTecnicos.CellContentDoubleClick
        If e.RowIndex < 0 OrElse grillaDatosTecnicos.CurrentRow Is Nothing Then Exit Sub
        Try
            If nombre_form = "FrmDatosTecnicos" Then
                With FrmDatosTecnicos
                    .txtIdDatoTecnico.Text = grillaDatosTecnicos.Rows(grillaDatosTecnicos.CurrentRow.Index).Cells(0).Value
                    .txtDescDatoTecnico.Text = grillaDatosTecnicos.Rows(grillaDatosTecnicos.CurrentRow.Index).Cells(1).Value
                    If grillaDatosTecnicos.Rows(grillaDatosTecnicos.CurrentRow.Index).Cells(2).Value Then
                        .opcDatoActivado.Checked = True
                    Else
                        .opcDatoDesactivado.Checked = True
                    End If
                End With

                Me.Close()
            End If
           
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Datos Técnicos (Grilla Datos Técnicos)", True, Me)
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If nombre_form = "FrmDatosTecnicosNodo" Then
            Try
                If FrmDatosTecnicosNodo.DST_DATOS_TECNICOS_NODO.Tables.Count > 0 Then

                    Dim datos_tecnicos As New DatosTecnicos
                    Dim msje As String = ""

                    For i = 0 To grillaDatosTecnicos.RowCount - 1
                        With FrmDatosTecnicosNodo.grillaDatosTecnicosNodo
                            If grillaDatosTecnicos.Rows(i).Cells(0).Value Then
                                msje = ""
                                datos_tecnicos.BuscarDatoTecnicoNodoGrilla(msje, grillaDatosTecnicos.Rows(i).Cells(1).Value, FrmDatosTecnicosNodo.id_nodo_select)

                                If msje = "" Then

                                    If FrmDatosTecnicosNodo.nivel >= 3 Then
                                        Dim fila As DataRow = FrmDatosTecnicosNodo.DST_DATOS_TECNICOS_NODO.Tables(0).NewRow

                                        fila(0) = grillaDatosTecnicos.Rows(i).Cells(1).Value
                                        fila(1) = FrmDatosTecnicosNodo.id_nodo_select
                                        fila(2) = FrmDatosTecnicosNodo.arbol9.SelectedNode.Text
                                        fila(3) = grillaDatosTecnicos.Rows(i).Cells(2).Value
                                        FrmDatosTecnicosNodo.DST_DATOS_TECNICOS_NODO.Tables(0).Rows.Add(fila)
                                        FrmDatosTecnicosNodo.grillaDatosTecnicosNodo.Update()

                                    ElseIf FrmDatosTecnicosNodo.nivel = 2 Then
                                        Dim fila As DataRow = FrmDatosTecnicosNodo.DST_DATOS_TECNICOS_NODO.Tables(0).NewRow

                                        fila(0) = grillaDatosTecnicos.Rows(i).Cells(1).Value
                                        fila(1) = FrmDatosTecnicosNodo.id_nodo_select
                                        fila(2) = FrmDatosTecnicosNodo.arbol9.SelectedNode.Parent.Text
                                        fila(3) = FrmDatosTecnicosNodo.arbol9.SelectedNode.Text
                                        fila(4) = grillaDatosTecnicos.Rows(i).Cells(2).Value
                                        FrmDatosTecnicosNodo.DST_DATOS_TECNICOS_NODO.Tables(0).Rows.Add(fila)
                                        FrmDatosTecnicosNodo.grillaDatosTecnicosNodo.Update()

                                    ElseIf FrmDatosTecnicosNodo.nivel = 1 Then
                                        Dim fila As DataRow = FrmDatosTecnicosNodo.DST_DATOS_TECNICOS_NODO.Tables(0).NewRow

                                        fila(0) = grillaDatosTecnicos.Rows(i).Cells(1).Value
                                        fila(1) = FrmDatosTecnicosNodo.id_nodo_select
                                        fila(2) = "RAÍZ"
                                        fila(3) = FrmDatosTecnicosNodo.arbol9.SelectedNode.Parent.Text
                                        fila(4) = FrmDatosTecnicosNodo.arbol9.SelectedNode.Text
                                        fila(5) = grillaDatosTecnicos.Rows(i).Cells(2).Value
                                        FrmDatosTecnicosNodo.DST_DATOS_TECNICOS_NODO.Tables(0).Rows.Add(fila)
                                        FrmDatosTecnicosNodo.grillaDatosTecnicosNodo.Update()
                                    End If
                                    
                                End If

                            End If
                        End With
                    Next

                    Me.Close()
                Else
                    For i = 0 To grillaDatosTecnicos.RowCount - 1
                        With FrmDatosTecnicosNodo.grillaDatosTecnicosNodo
                            If grillaDatosTecnicos.Rows(i).Cells(0).Value Then
                                .Rows.Add()
                                .Rows(.RowCount - 1).Cells(0).Value = grillaDatosTecnicos.Rows(i).Cells(1).Value
                                .Rows(.RowCount - 1).Cells(1).Value = FrmDatosTecnicosNodo.id_nodo_select
                                .Rows(.RowCount - 1).Cells(2).Value = FrmDatosTecnicosNodo.arbol9.SelectedNode.Text
                                .Rows(.RowCount - 1).Cells(3).Value = grillaDatosTecnicos.Rows(i).Cells(2).Value
                            End If
                        End With
                    Next

                    Me.Close()
                End If
            Catch ex As Exception
                RegistroErrores.MostrarYRegistrar(ex, "Buscar Datos Técnicos (Agregar)", True, Me)
            End Try
        End If
    End Sub

    Private Sub chkSelTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelTodo.CheckedChanged
        Try
            If chkSelTodo.Checked Then
                For i = 0 To grillaDatosTecnicos.RowCount - 1
                    grillaDatosTecnicos.Rows(i).Cells(0).Value = True
                Next
            Else
                For i = 0 To grillaDatosTecnicos.RowCount - 1
                    grillaDatosTecnicos.Rows(i).Cells(0).Value = False
                Next
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Datos Técnicos (Seleccionar Todo)", True, Me)
        End Try

    End Sub

    Private Sub btnCambiarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiarEstado.Click
        Dim datos_tecnicos As New DatosTecnicos
        Dim estado As Boolean = False
        Dim cod_resp As Integer = 0
        Dim respuesta As String = ""

        Try
            With grillaDatosTecnicos
                For i = 0 To .RowCount - 1
                    If .Rows(i).Cells(2).Value Then
                        estado = True
                    Else
                        estado = False
                    End If

                    datos_tecnicos.UpdDatoTecnico(.Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, estado, principal.lblUsuario.Text, cod_resp, respuesta)

                Next
            End With

            If cod_resp = 1 Then
                MsgBox(respuesta, MsgBoxStyle.Information, "Confirmación Actualización")
            ElseIf cod_resp <> -1 AndAlso Not String.IsNullOrWhiteSpace(respuesta) Then
                MsgBox(respuesta, MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Datos Técnicos (Cambiar Estado)", True, Me)
        End Try
        
    End Sub
End Class