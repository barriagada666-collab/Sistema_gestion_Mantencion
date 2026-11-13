Imports System.Data
Imports System.Windows.Forms

Public Class FrmAdminUsuarios
    Public filtro As New DataView

    Private Sub btnIngUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngUsuario.Click
        Dim usuario As New Usuario
        Dim cod_resp As Integer = 0
        Dim resp As String = ""
        Dim valida As Boolean = False

        valida = usuario.ValidarIngUser(resp)

        If valida Then
            usuario.ingUsuario(txtRutUsuario.Text.Trim(), cmbPerfil1.SelectedValue, txtNomUsuario.Text.Trim(), txtClave.Text.Trim(), opcActivoSi.Checked, principal.lblUsuario.Text, cod_resp, resp)
            With grillaPerModulos
                For i = 0 To .RowCount - 1
                    usuario.ingPermisoUsuario(txtRutUsuario.Text.Trim(), .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
                Next
            End With

            With grillaModOt
                For i = 0 To .RowCount - 1
                    usuario.ingPermisoUsuario(txtRutUsuario.Text.Trim(), .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
                Next
            End With

            With grillaPerMp
                For i = 0 To .RowCount - 1
                    usuario.ingPermisoUsuario(txtRutUsuario.Text.Trim(), .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
                Next
            End With

            With grillaPerMantenedores
                For i = 0 To .RowCount - 1
                    usuario.ingPermisoUsuario(txtRutUsuario.Text.Trim(), .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
                Next
            End With

            If cod_resp = 1 Then
                MsgBox(resp, MsgBoxStyle.Information, "Validación")
            Else
                MsgBox(resp, MsgBoxStyle.Critical, "Validación")
            End If
            usuario.LimpiarFrmUsuario()
            usuario.CrgPermisosFormUsuario(grillaPerModulos, grillaModOt, grillaPerMp, grillaPerMantenedores)
            ConfigurarEstiloGrillaUsuarios()
            Utilitarios.AjustarColumnasGrilla(grillaUsuarios)
        Else
            MsgBox(resp, MsgBoxStyle.Exclamation, "Validación")
        End If
    End Sub

    Private Sub FrmAdminUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim usuario As New Usuario
        Dim DS As New DataSet

        usuario.CrgCmbPerfil(cmbPerfil1)
        opcActivoSi.Checked = True
        usuario.CrgPermisosFormUsuario(grillaPerModulos, grillaModOt, grillaPerMp, grillaPerMantenedores)
        usuario.CrgUsuarios(DS)
        grillaUsuarios.DataSource = DS.Tables(0)
        filtro.Table = DS.Tables(0)
        ConfigurarEstiloGrillaUsuarios()
        Utilitarios.AjustarColumnasGrilla(grillaUsuarios)
    End Sub

    Public Sub ConfigurarEstiloGrillaUsuarios()
        If grillaUsuarios Is Nothing OrElse grillaUsuarios.Columns.Count < 5 Then Exit Sub
        With grillaUsuarios
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .RowTemplate.Height = 24

            If .Columns.Count > 0 Then
                With .Columns(0)
                    .HeaderText = "RUT"
                    .Width = 95
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Tag = "Fijo"
                End With
            End If

            If .Columns.Count > 1 Then
                With .Columns(1)
                    .HeaderText = "Nombre de Usuario"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
            End If

            If .Columns.Count > 2 Then
                With .Columns(2)
                    .HeaderText = "Contraseña"
                    .Width = 110
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Tag = "Fijo"
                End With
            End If

            If .Columns.Count > 3 Then
                With .Columns(3)
                    .HeaderText = "Perfil"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
            End If

            If .Columns.Count > 4 Then
                With .Columns(4)
                    .HeaderText = "Estado"
                    .Width = 70
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Tag = "Fijo"
                End With
            End If
        End With
    End Sub

    Private Sub btnLimpiarUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarUser.Click
        Dim usuario As New Usuario

        usuario.LimpiarFrmUsuario()
        usuario.CrgPermisosFormUsuario(grillaPerModulos, grillaModOt, grillaPerMp, grillaPerMantenedores)
        ConfigurarEstiloGrillaUsuarios()
        Utilitarios.AjustarColumnasGrilla(grillaUsuarios)
    End Sub

    Private Sub tabAdmin_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        grillaUsuarios.DataSource = Nothing
        grillaUsuarios.Visible = False
    End Sub

    Private Sub btnActUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActUsuario.Click
        Dim usuario As New Usuario
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        usuario.UpdUsuario(txtRutUsuario.Text.Trim(), cmbPerfil1.SelectedValue, txtNomUsuario.Text.Trim(), txtClave.Text.Trim(), opcActivoSi.Checked, principal.lblUsuario.Text, cod_resp, resp)
        With grillaPerModulos
            For i = 0 To .RowCount - 1
                usuario.UpdPermisosUsuario(txtRutUsuario.Text.Trim(), .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
            Next
        End With

        With grillaModOt
            For i = 0 To .RowCount - 1
                usuario.UpdPermisosUsuario(txtRutUsuario.Text.Trim(), .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
            Next
        End With

        With grillaPerMp
            For i = 0 To .RowCount - 1
                usuario.UpdPermisosUsuario(txtRutUsuario.Text.Trim(), .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
            Next
        End With

        With grillaPerMantenedores
            For i = 0 To .RowCount - 1
                usuario.UpdPermisosUsuario(txtRutUsuario.Text.Trim(), .Rows(i).Cells(0).Value, .Rows(i).Cells(2).Value)
            Next
        End With

        If cod_resp = 1 Then
            MsgBox(resp, MsgBoxStyle.Information, "Validación")
            usuario.LimpiarFrmUsuario()
            usuario.CrgPermisosFormUsuario(grillaPerModulos, grillaModOt, grillaPerMp, grillaPerMantenedores)
            ConfigurarEstiloGrillaUsuarios()
            Utilitarios.AjustarColumnasGrilla(grillaUsuarios)
        Else
            MsgBox(resp, MsgBoxStyle.Critical, "Validación")
        End If
    End Sub

    Private Sub btnDelUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelUsuario.Click
        If MsgBox("¿ Está seguro que desea eliminar el usuario " & UCase(txtNomUsuario.Text.Trim()) & " del sistema ?", MsgBoxStyle.YesNo, "Validación") = MsgBoxResult.Yes Then
            Dim usuario As New Usuario
            Dim cod_resp As Integer = 0
            Dim resp As String = ""

            usuario.DelUsuario(txtRutUsuario.Text.Trim(), principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MsgBox(resp, MsgBoxStyle.Information, "Validación")
                usuario.LimpiarFrmUsuario()
                ConfigurarEstiloGrillaUsuarios()
                Utilitarios.AjustarColumnasGrilla(grillaUsuarios)
            Else
                MsgBox(resp, MsgBoxStyle.Critical, "Validación")
            End If
        End If
    End Sub

    Private Sub btnSalirUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirUser.Click
        Me.Close()
    End Sub

    Private Sub grillaUsuarios_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaUsuarios.CellDoubleClick, grillaUsuarios.CellContentDoubleClick
        If e.RowIndex < 0 OrElse grillaUsuarios.CurrentRow Is Nothing Then Exit Sub
        With grillaUsuarios
            Try
                Dim rowIdx As Integer = .CurrentRow.Index
                txtRutUsuario.Text = .Rows(rowIdx).Cells(0).Value.ToString()
                txtNomUsuario.Text = .Rows(rowIdx).Cells(1).Value.ToString()
                txtClave.Text = .Rows(rowIdx).Cells(2).Value.ToString()
                cmbPerfil1.Text = .Rows(rowIdx).Cells(3).Value.ToString()
                If .Rows(rowIdx).Cells(4).Value.ToString() = "A" Then
                    opcActivoSi.Checked = True
                Else
                    opcActivoNo.Checked = True
                End If
                txtRutUsuario.Enabled = False

                Dim usuario As New Usuario
                Dim DST_PER_USR As New DataSet
                DST_PER_USR.Tables.Clear()
                usuario.CrgPermisosUsuario(0, .Rows(rowIdx).Cells(2).Value.ToString(), .Rows(rowIdx).Cells(0).Value.ToString(), DST_PER_USR)

                If DST_PER_USR.Tables.Count > 0 AndAlso DST_PER_USR.Tables(0).Rows.Count > 0 Then
                    Dim dtUsr As DataTable = DST_PER_USR.Tables(0)
                    Dim asignarPermiso As Action(Of DataGridView, Integer, Integer) =
                        Sub(dgv, filaGrid, filaDt)
                            If dgv.RowCount > filaGrid AndAlso dtUsr.Rows.Count > filaDt Then
                                Dim val As Object = dtUsr.Rows(filaDt).Item(1)
                                dgv.Rows(filaGrid).Cells(2).Value = If(val IsNot Nothing AndAlso Not IsDBNull(val), Convert.ToBoolean(val), False)
                            End If
                        End Sub

                    asignarPermiso(grillaPerModulos, 0, 0)
                    asignarPermiso(grillaPerModulos, 1, 1)
                    asignarPermiso(grillaPerModulos, 2, 2)
                    asignarPermiso(grillaPerModulos, 3, 3)
                    asignarPermiso(grillaPerModulos, 4, 18)

                    asignarPermiso(grillaModOt, 0, 4)
                    asignarPermiso(grillaModOt, 1, 5)
                    asignarPermiso(grillaModOt, 2, 6)
                    asignarPermiso(grillaModOt, 3, 7)
                    asignarPermiso(grillaModOt, 4, 17)

                    asignarPermiso(grillaPerMp, 0, 8)
                    asignarPermiso(grillaPerMp, 1, 9)
                    asignarPermiso(grillaPerMp, 2, 10)
                    asignarPermiso(grillaPerMp, 3, 11)
                    asignarPermiso(grillaPerMp, 4, 16)
                    asignarPermiso(grillaPerMp, 5, 19)
                    asignarPermiso(grillaPerMp, 6, 20)

                    asignarPermiso(grillaPerMantenedores, 0, 12)
                    asignarPermiso(grillaPerMantenedores, 1, 13)
                    asignarPermiso(grillaPerMantenedores, 2, 14)
                    asignarPermiso(grillaPerMantenedores, 3, 15)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Validación")
            End Try
        End With
    End Sub

    Private Sub txtNomUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomUsuario.TextChanged
        Dim valorLimpio As String = Utilitarios.EscaparLike(txtNomUsuario.Text.Trim())
        filtro.RowFilter = "NOMBRE like '%" & valorLimpio & "%' "
        grillaUsuarios.DataSource = filtro
        ConfigurarEstiloGrillaUsuarios()
        Utilitarios.AjustarColumnasGrilla(grillaUsuarios)
    End Sub

    Private Sub grillaUsuarios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaUsuarios.CellContentClick
    End Sub
End Class
