Public Class FrmBuscarDatosTecnicos
    Public nombre_form As String = String.Empty

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

    Private Sub grillaDatosTecnicos_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grillaDatosTecnicos.CurrentCellDirtyStateChanged
        If grillaDatosTecnicos.IsCurrentCellDirty Then
            grillaDatosTecnicos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub grillaDatosTecnicos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaDatosTecnicos.CellDoubleClick
        If e.RowIndex < 0 OrElse e.RowIndex >= grillaDatosTecnicos.RowCount Then Exit Sub
        Try
            If nombre_form = "FrmDatosTecnicos" Then
                Dim row = grillaDatosTecnicos.Rows(e.RowIndex)
                If row Is Nothing OrElse row.IsNewRow OrElse grillaDatosTecnicos.Columns.Count < 3 Then Exit Sub
                With FrmDatosTecnicos
                    .txtIdDatoTecnico.Text = If(row.Cells(0).Value Is Nothing OrElse IsDBNull(row.Cells(0).Value), String.Empty, row.Cells(0).Value.ToString().Trim())
                    .txtDescDatoTecnico.Text = If(row.Cells(1).Value Is Nothing OrElse IsDBNull(row.Cells(1).Value), String.Empty, row.Cells(1).Value.ToString().Trim())
                    Dim activoObj As Object = row.Cells(2).Value
                    Dim activo As Boolean = (activoObj IsNot Nothing AndAlso Not IsDBNull(activoObj) AndAlso Convert.ToBoolean(activoObj))
                    If activo Then
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
        If nombre_form <> "FrmDatosTecnicosNodo" Then Exit Sub
        Try
            If grillaDatosTecnicos.IsCurrentCellInEditMode Then
                grillaDatosTecnicos.EndEdit()
            End If

            Dim selNode As TreeNode = FrmDatosTecnicosNodo.arbol9.SelectedNode
            If selNode Is Nothing Then
                MessageBox.Show(Me, "No hay ningún nodo seleccionado en Datos Técnicos por Nodo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If FrmDatosTecnicosNodo.DST_DATOS_TECNICOS_NODO.Tables.Count > 0 Then
                Dim datos_tecnicos As New DatosTecnicos
                Dim dtDestino As DataTable = FrmDatosTecnicosNodo.DST_DATOS_TECNICOS_NODO.Tables(0)
                Dim textoPadre As String = If(selNode.Parent IsNot Nothing, selNode.Parent.Text, "RAÍZ")

                For i As Integer = 0 To grillaDatosTecnicos.RowCount - 1
                    Dim row = grillaDatosTecnicos.Rows(i)
                    If row.IsNewRow Then Continue For
                    Dim chkObj As Object = row.Cells(0).Value
                    If chkObj Is Nothing OrElse IsDBNull(chkObj) OrElse Not Convert.ToBoolean(chkObj) Then Continue For

                    Dim idDato As Object = row.Cells(1).Value
                    Dim descDato As Object = row.Cells(2).Value
                    Dim msje As String = ""
                    datos_tecnicos.BuscarDatoTecnicoNodoGrilla(msje, Convert.ToString(idDato), FrmDatosTecnicosNodo.id_nodo_select)
                    If Not String.IsNullOrEmpty(msje) Then Continue For

                    Dim fila As DataRow = dtDestino.NewRow()
                    If FrmDatosTecnicosNodo.nivel >= 3 AndAlso dtDestino.Columns.Count >= 4 Then
                        fila(0) = idDato
                        fila(1) = FrmDatosTecnicosNodo.id_nodo_select
                        fila(2) = selNode.Text
                        fila(3) = descDato
                        dtDestino.Rows.Add(fila)
                    ElseIf FrmDatosTecnicosNodo.nivel = 2 AndAlso dtDestino.Columns.Count >= 5 Then
                        fila(0) = idDato
                        fila(1) = FrmDatosTecnicosNodo.id_nodo_select
                        fila(2) = textoPadre
                        fila(3) = selNode.Text
                        fila(4) = descDato
                        dtDestino.Rows.Add(fila)
                    ElseIf FrmDatosTecnicosNodo.nivel = 1 AndAlso dtDestino.Columns.Count >= 6 Then
                        fila(0) = idDato
                        fila(1) = FrmDatosTecnicosNodo.id_nodo_select
                        fila(2) = "RAÍZ"
                        fila(3) = textoPadre
                        fila(4) = selNode.Text
                        fila(5) = descDato
                        dtDestino.Rows.Add(fila)
                    End If
                Next
                FrmDatosTecnicosNodo.grillaDatosTecnicosNodo.Update()
                Me.Close()
            Else
                For i As Integer = 0 To grillaDatosTecnicos.RowCount - 1
                    Dim row = grillaDatosTecnicos.Rows(i)
                    If row.IsNewRow Then Continue For
                    Dim chkObj As Object = row.Cells(0).Value
                    If chkObj Is Nothing OrElse IsDBNull(chkObj) OrElse Not Convert.ToBoolean(chkObj) Then Continue For

                    With FrmDatosTecnicosNodo.grillaDatosTecnicosNodo
                        Dim idx As Integer = .Rows.Add()
                        .Rows(idx).Cells(0).Value = row.Cells(1).Value
                        .Rows(idx).Cells(1).Value = FrmDatosTecnicosNodo.id_nodo_select
                        .Rows(idx).Cells(2).Value = selNode.Text
                        .Rows(idx).Cells(3).Value = row.Cells(2).Value
                    End With
                Next
                Me.Close()
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Datos Técnicos (Agregar)", True, Me)
        End Try
    End Sub

    Private Sub chkSelTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelTodo.CheckedChanged
        Try
            For i As Integer = 0 To grillaDatosTecnicos.RowCount - 1
                If Not grillaDatosTecnicos.Rows(i).IsNewRow Then
                    grillaDatosTecnicos.Rows(i).Cells(0).Value = chkSelTodo.Checked
                End If
            Next
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Datos Técnicos (Seleccionar Todo)", True, Me)
        End Try
    End Sub

    Private Sub btnCambiarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiarEstado.Click
        If grillaDatosTecnicos.IsCurrentCellInEditMode Then
            grillaDatosTecnicos.EndEdit()
        End If
        Dim datos_tecnicos As New DatosTecnicos
        Dim huboError As Boolean = False
        Dim ultimoMensaje As String = String.Empty
        Dim actualizados As Integer = 0

        Try
            With grillaDatosTecnicos
                For i As Integer = 0 To .RowCount - 1
                    Dim row = .Rows(i)
                    If row.IsNewRow OrElse .Columns.Count < 3 Then Continue For
                    Dim estObj As Object = row.Cells(2).Value
                    Dim estado As Boolean = (estObj IsNot Nothing AndAlso Not IsDBNull(estObj) AndAlso Convert.ToBoolean(estObj))
                    Dim cod_resp As Integer = 0
                    Dim respuesta As String = ""

                    datos_tecnicos.UpdDatoTecnico(Convert.ToString(row.Cells(0).Value), Convert.ToString(row.Cells(1).Value), estado, principal.lblUsuario.Text, cod_resp, respuesta)
                    If cod_resp = 1 Then
                        actualizados += 1
                        ultimoMensaje = respuesta
                    Else
                        huboError = True
                        If Not String.IsNullOrWhiteSpace(respuesta) Then ultimoMensaje = respuesta
                    End If
                Next
            End With

            If Not huboError AndAlso actualizados > 0 Then
                MessageBox.Show(Me, If(String.IsNullOrWhiteSpace(ultimoMensaje), "Estados actualizados correctamente.", ultimoMensaje), "Confirmación Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf huboError AndAlso Not String.IsNullOrWhiteSpace(ultimoMensaje) Then
                MessageBox.Show(Me, ultimoMensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Datos Técnicos (Cambiar Estado)", True, Me)
        End Try
    End Sub
End Class
