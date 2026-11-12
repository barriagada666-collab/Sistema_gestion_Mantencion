Public Class FrmAdminUsuarios
    Public filtro As New DataView
    Private Sub btnIngUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngUsuario.Click
        Dim usuario As New Usuario
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim valida As Boolean = False

        valida = usuario.ValidarIngUser(resp)

        If valida Then
            usuario.ingUsuario(txtRutUsuario.Text, cmbPerfil1.SelectedValue, txtNomUsuario.Text, txtClave.Text, opcActivoSi.Checked, principal.lblUsuario.Text, cod_resp, resp)
            With grillaPerModulos
                For i = 0 To .RowCount - 1
                    usuario.ingPermisoUsuario(txtRutUsuario.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
                Next
            End With

            With grillaModOt
                For i = 0 To .RowCount - 1
                    usuario.ingPermisoUsuario(txtRutUsuario.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
                Next
            End With

            With grillaPerMp
                For i = 0 To .RowCount - 1
                    usuario.ingPermisoUsuario(txtRutUsuario.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
                Next
            End With

            With grillaPerMantenedores
                For i = 0 To .RowCount - 1
                    usuario.ingPermisoUsuario(txtRutUsuario.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
                Next
            End With
            If cod_resp = 1 Then
                MsgBox(resp, MsgBoxStyle.Information, "Validación")
            Else
                MsgBox(resp, MsgBoxStyle.Critical, "Validación")
            End If
            usuario.LimpiarFrmUsuario()
            usuario.CrgPermisosFormUsuario(grillaPerModulos, grillaModOt, grillaPerMp, grillaPerMantenedores)
        Else
            MsgBox(resp, MsgBoxStyle.Exclamation, "Validación")
        End If

    End Sub

    Private Sub FrmAdminUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim usuario As New Usuario
        Dim DST_PER As New DataSet
        Dim DS As New DataSet
        Dim width As Double = Screen.PrimaryScreen.Bounds.Width
        Dim heigh As Double = Screen.PrimaryScreen.Bounds.Height

        Me.Width = width
        Me.Height = heigh
        usuario.CrgCmbPerfil(cmbPerfil1)
        opcActivoSi.Checked = True
        usuario.CrgPermisosFormUsuario(grillaPerModulos, grillaModOt, grillaPerMp, grillaPerMantenedores)
        usuario.CrgUsuarios(DS)
        grillaUsuarios.DataSource = DS.Tables(0)
        filtro.Table = DS.Tables(0)
    End Sub

    Private Sub btnLimpiarUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarUser.Click
        Dim usuario As New Usuario

        usuario.LimpiarFrmUsuario()
        usuario.CrgPermisosFormUsuario(grillaPerModulos, grillaModOt, grillaPerMp, grillaPerMantenedores)
    End Sub

    Private Sub tabAdmin_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        grillaUsuarios.DataSource = Nothing
        grillaUsuarios.Visible = False
    End Sub

    Private Sub btnActUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActUsuario.Click
        Dim usuario As New Usuario
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        usuario.UpdUsuario(txtRutUsuario.Text, cmbPerfil1.SelectedValue, txtNomUsuario.Text, txtClave.Text, opcActivoSi.Checked, principal.lblUsuario.Text, cod_resp, resp)
        With grillaPerModulos
            For i = 0 To .RowCount - 1
                usuario.UpdPermisosUsuario(txtRutUsuario.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
            Next
        End With

        With grillaModOt
            For i = 0 To .RowCount - 1
                usuario.UpdPermisosUsuario(txtRutUsuario.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
            Next
        End With

        With grillaPerMp
            For i = 0 To .RowCount - 1
                usuario.UpdPermisosUsuario(txtRutUsuario.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
            Next
        End With

        With grillaPerMantenedores
            For i = 0 To .RowCount - 1
                usuario.UpdPermisosUsuario(txtRutUsuario.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
            Next
        End With
        If cod_resp = 1 Then
            MsgBox(resp, MsgBoxStyle.Information, "Validación")
            usuario.LimpiarFrmUsuario()
            usuario.CrgPermisosFormUsuario(grillaPerModulos, grillaModOt, grillaPerMp, grillaPerMantenedores)
        Else
            MsgBox(resp, MsgBoxStyle.Critical, "Validación")
        End If

    End Sub

    Private Sub btnDelUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelUsuario.Click
        If MsgBox("¿ Esta seguro que desea eliminar el usuario " & UCase(txtNomUsuario.Text) & " del sistema ?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
            Dim usuario As New Usuario
            Dim cod_resp As Integer = 0
            Dim resp As String = ""

            usuario.DelUsuario(txtRutUsuario.Text, principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MsgBox(resp, MsgBoxStyle.Information, "Validación")
                usuario.LimpiarFrmUsuario()
            Else
                MsgBox(resp, MsgBoxStyle.Critical, "Validación")
            End If
        End If

    End Sub

    Private Sub btnSalirUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirUser.Click
        Me.Close()
    End Sub

    Private Sub grillaUsuarios_CellContentDoubleClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaUsuarios.CellContentDoubleClick
        With grillaUsuarios
            Try
                txtRutUsuario.Text = .Rows(.CurrentRow.Index).Cells(0).Value.ToString
                txtNomUsuario.Text = .Rows(.CurrentRow.Index).Cells(1).Value.ToString
                txtClave.Text = .Rows(.CurrentRow.Index).Cells(2).Value.ToString
                cmbPerfil1.Text = .Rows(.CurrentRow.Index).Cells(3).Value
                If .Rows(.CurrentRow.Index).Cells(4).Value = "A" Then
                    opcActivoSi.Checked = True
                Else
                    opcActivoNo.Checked = True
                End If
                txtRutUsuario.Enabled = False

                Dim usuario As New Usuario
                Dim DST_PER_USR As New DataSet
                DST_PER_USR.Tables.Clear()
                usuario.CrgPermisosUsuario(0, .Rows(.CurrentRow.Index).Cells(2).Value.ToString, .Rows(.CurrentRow.Index).Cells(0).Value.ToString, DST_PER_USR)

                With grillaPerModulos
                    .Rows(0).Cells(2).Value = DST_PER_USR.Tables(0).Rows(0).Item(1).ToString
                    .Rows(1).Cells(2).Value = DST_PER_USR.Tables(0).Rows(1).Item(1).ToString
                    .Rows(2).Cells(2).Value = DST_PER_USR.Tables(0).Rows(2).Item(1).ToString
                    .Rows(3).Cells(2).Value = DST_PER_USR.Tables(0).Rows(3).Item(1).ToString
                    .Rows(4).Cells(2).Value = DST_PER_USR.Tables(0).Rows(18).Item(1).ToString
                End With

                With grillaModOt
                    .Rows(0).Cells(2).Value = DST_PER_USR.Tables(0).Rows(4).Item(1).ToString
                    .Rows(1).Cells(2).Value = DST_PER_USR.Tables(0).Rows(5).Item(1).ToString
                    .Rows(2).Cells(2).Value = DST_PER_USR.Tables(0).Rows(6).Item(1).ToString
                    .Rows(3).Cells(2).Value = DST_PER_USR.Tables(0).Rows(7).Item(1).ToString
                    .Rows(4).Cells(2).Value = DST_PER_USR.Tables(0).Rows(17).Item(1).ToString
                End With

                With grillaPerMp
                    .Rows(0).Cells(2).Value = DST_PER_USR.Tables(0).Rows(8).Item(1).ToString
                    .Rows(1).Cells(2).Value = DST_PER_USR.Tables(0).Rows(9).Item(1).ToString
                    .Rows(2).Cells(2).Value = DST_PER_USR.Tables(0).Rows(10).Item(1).ToString
                    .Rows(3).Cells(2).Value = DST_PER_USR.Tables(0).Rows(11).Item(1).ToString
                    .Rows(4).Cells(2).Value = DST_PER_USR.Tables(0).Rows(16).Item(1).ToString
                    .Rows(5).Cells(2).Value = DST_PER_USR.Tables(0).Rows(19).Item(1).ToString
                    .Rows(6).Cells(2).Value = DST_PER_USR.Tables(0).Rows(20).Item(1).ToString
                End With

                With grillaPerMantenedores
                    .Rows(0).Cells(2).Value = DST_PER_USR.Tables(0).Rows(12).Item(1).ToString
                    .Rows(1).Cells(2).Value = DST_PER_USR.Tables(0).Rows(13).Item(1).ToString
                    .Rows(2).Cells(2).Value = DST_PER_USR.Tables(0).Rows(14).Item(1).ToString
                    .Rows(3).Cells(2).Value = DST_PER_USR.Tables(0).Rows(15).Item(1).ToString
                End With
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Validación")
            End Try
            
        End With
    End Sub

    Private Sub txtNomUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomUsuario.TextChanged
        filtro.RowFilter = "NOMBRE like '%" & txtNomUsuario.Text & "%' "
        grillaUsuarios.DataSource = filtro
        grillaUsuarios.Update()
    End Sub

    Private Sub grillaUsuarios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaUsuarios.CellContentClick

    End Sub
End Class