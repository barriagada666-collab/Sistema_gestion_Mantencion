Public Class FrmCargo

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim cargo As New Cargo

        cargo.LimpiarFrmCargo()
    End Sub

    Private Sub btn_guardar_cargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_cargo.Click
        Dim cargo As New Cargo
        Dim resp As String = ""
        Dim cod_resp As String = 0

        cod_resp = cargo.BuscarCargo(txtCodCargo.Text)

        If cod_resp = 0 Then
            cod_resp = 0
            cargo.IngCargo(txtCodCargo.Text, txtDescCargo.Text, principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MsgBox(resp, MsgBoxStyle.Information, "Validación")
                cargo.LimpiarFrmCargo()
            Else
                MsgBox(resp, MsgBoxStyle.Critical, "Error")
            End If
        Else
            cod_resp = 0
            cargo.UpdCargo(txtCodCargo.Text, txtDescCargo.Text, principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MsgBox(resp, MsgBoxStyle.Information, "Validación")
                cargo.LimpiarFrmCargo()
            Else
                MsgBox(resp, MsgBoxStyle.Critical, "Error")
            End If
        End If
    End Sub

    Private Sub btn_eliminar_cargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_cargo.Click
        If MsgBox("¿Esta seguro de eliminar el cargo " & txtDescCargo.Text & " ?", MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
            Dim cargo As New Cargo
            Dim cod_resp As Integer = 0
            Dim resp As String = ""

            cargo.DelCargo(txtCodCargo.Text, principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MsgBox(resp, MsgBoxStyle.Information, "Validación")
                cargo.LimpiarFrmCargo()
            Else
                MsgBox(resp, MsgBoxStyle.Critical, "Error")
            End If
        End If
    End Sub

    Private Sub FrmCargo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim width As Double = Screen.PrimaryScreen.Bounds.Width
        Dim heigh As Double = Screen.PrimaryScreen.Bounds.Height

        Me.Width = width
        Me.Height = heigh
    End Sub

    Private Sub btn_buscar_cargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_cargo.Click
        Dim cargos As New Cargo
        Dim DST_CARGOS As New DataSet
        Dim formato_grid As New FormatoGrillas

        cargos.CrgCargos(DST_CARGOS)
        grillaCargos.DataSource = DST_CARGOS.Tables(0)
        formato_grid.grillaCargos(grillaCargos)
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub grillaCargos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaCargos.CellContentClick
       
    End Sub

    Private Sub grillaCargos_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaCargos.CellContentDoubleClick
        Try
            With grillaCargos
                txtCodCargo.Text = .Rows(.CurrentRow.Index).Cells(0).Value
                txtDescCargo.Text = .Rows(.CurrentRow.Index).Cells(1).Value
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class