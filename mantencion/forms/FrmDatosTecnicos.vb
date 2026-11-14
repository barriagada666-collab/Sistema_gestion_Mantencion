Public Class FrmDatosTecnicos

    Private Sub FrmDatosTecnicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Utilitarios.AplicarTemaModerno(Me)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()

    End Sub

    Private Sub btnNuevoDato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoDato.Click
        Dim datos_tecnicos As New DatosTecnicos

        txtIdDatoTecnico.Text = datos_tecnicos.NUEVO_ID_DATO_TECNICO
        txtDescDatoTecnico.ResetText()
        txtDescDatoTecnico.Focus()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Try
            txtIdDatoTecnico.ResetText()
            txtDescDatoTecnico.ResetText()
            opcDatoActivado.Checked = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim datos_tecnicos As New DatosTecnicos
        Dim respuesta As Integer
        Dim estado_dato_tecnico As Boolean = False
        Dim cod_resp As Integer = 0
        Dim resp As String = ""

        respuesta = datos_tecnicos.BuscarIdDatoTecnico(txtIdDatoTecnico.Text)

        If respuesta = 0 Then
            If opcDatoActivado.Checked Then
                estado_dato_tecnico = True
            End If

            datos_tecnicos.IngDatoTecnico(txtIdDatoTecnico.Text, txtDescDatoTecnico.Text, estado_dato_tecnico, principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MsgBox(resp, MsgBoxStyle.Information, "Validación")
                txtIdDatoTecnico.ResetText()
                txtDescDatoTecnico.ResetText()
                opcDatoActivado.Checked = True
            End If
        Else
            If opcDatoActivado.Checked Then
                estado_dato_tecnico = True
            End If

            datos_tecnicos.UpdDatoTecnico(txtIdDatoTecnico.Text, txtDescDatoTecnico.Text, estado_dato_tecnico, principal.lblUsuario.Text, cod_resp, resp)

            If cod_resp = 1 Then
                MsgBox(resp, MsgBoxStyle.Information, "Validación")
                txtIdDatoTecnico.ResetText()
                txtDescDatoTecnico.ResetText()
                opcDatoActivado.Checked = True
            End If
        End If
    End Sub

    Private Sub btnBuscarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDatos.Click
        FrmBuscarDatosTecnicos.nombre_form = Me.Name
        FrmBuscarDatosTecnicos.Show()
    End Sub
End Class