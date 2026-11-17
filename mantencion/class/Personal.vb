Imports System.Data.SqlClient

Public Class Personal

    Private Shared Function ParsearEnteroSeguro(ByVal valor As String, Optional ByVal valorDefecto As Integer = 0) As Integer
        Dim res As Integer
        If Integer.TryParse(If(valor, String.Empty).Trim(), res) Then
            Return res
        End If
        Return valorDefecto
    End Function

    Public Sub IngPersonal(ByVal rut As String, ByRef dv As String, ByVal cod_int As String, ByVal nombres As String, ByVal ap_paterno As String, ByVal ap_materno As String, ByVal alias_personal As String, ByVal fecha_nac As DateTime, ByVal fono As String, ByVal email As String, ByVal planta As String, ByVal seccion As String, ByVal cargo As String, ByVal sesion As String, ByVal activo As Boolean, ByVal direccion As String, ByVal fecha_ingreso As DateTime, ByVal celular As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty

        Dim codIntNum As Integer = ParsearEnteroSeguro(cod_int, 0)
        Dim fonoNum As Integer = 0
        If Not String.IsNullOrWhiteSpace(fono) AndAlso Not Integer.TryParse(fono.Trim(), fonoNum) Then
            resp = "El teléfono ingresado excede el límite numérico permitido (máx. 9 dígitos)."
            Exit Sub
        End If
        Dim celNum As Integer = 0
        If Not String.IsNullOrWhiteSpace(celular) AndAlso Not Integer.TryParse(celular.Trim(), celNum) Then
            resp = "El celular ingresado excede el límite numérico permitido (máx. 9 dígitos)."
            Exit Sub
        End If

        Dim idPlanta As Integer = ParsearEnteroSeguro(planta, 0)
        Dim idSeccion As Integer = ParsearEnteroSeguro(seccion, 0)
        Dim idCargo As Integer = ParsearEnteroSeguro(cargo, 0)
        If idPlanta <= 0 OrElse idSeccion <= 0 OrElse idCargo <= 0 Then
            resp = "Debe seleccionar Planta, Sección y Cargo válidos."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("ING_PERSONAL", cnx)
                    com.CommandType = CommandType.StoredProcedure

                    com.Parameters.AddWithValue("@rut", If(rut, String.Empty).Trim())
                    com.Parameters.AddWithValue("@dv", If(dv, String.Empty).Trim().ToUpperInvariant())
                    com.Parameters.AddWithValue("@cod_interno", codIntNum)
                    com.Parameters.AddWithValue("@nombres", If(nombres, String.Empty).Trim())
                    com.Parameters.AddWithValue("@ap_paterno", If(ap_paterno, String.Empty).Trim())
                    com.Parameters.AddWithValue("@ap_materno", If(ap_materno, String.Empty).Trim())
                    com.Parameters.AddWithValue("@fecha_nacimiento", fecha_nac.ToString("yyyyMMdd"))
                    com.Parameters.AddWithValue("@fono", fonoNum)
                    com.Parameters.AddWithValue("@email", If(email, String.Empty).Trim())
                    com.Parameters.AddWithValue("@idcentro", idPlanta)
                    com.Parameters.AddWithValue("@idseccion", idSeccion)
                    com.Parameters.AddWithValue("@idcargo", idCargo)
                    com.Parameters.AddWithValue("@alias", If(alias_personal, String.Empty).Trim())
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@activo", activo)
                    com.Parameters.AddWithValue("@direccion", If(direccion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@fecha_ingreso", fecha_ingreso.ToString("yyyyMMdd"))
                    com.Parameters.AddWithValue("@celular", celNum)
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                            If cod_resp = 1 Then OT.InvalidarCachePersonal()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Personal")
        End Try
    End Sub

    Public Sub UpdPersonal(ByVal rut As String, ByRef dv As String, ByVal cod_int As String, ByVal nombres As String, ByVal ap_paterno As String, ByVal ap_materno As String, ByVal alias_personal As String, ByVal fecha_nac As Date, ByVal fono As String, ByVal email As String, ByVal planta As String, ByVal seccion As String, ByVal cargo As String, ByVal sesion As String, ByVal activo As Boolean, ByVal direccion As String, ByVal fecha_ingreso As DateTime, ByVal celular As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty

        Dim codIntNum As Integer = ParsearEnteroSeguro(cod_int, 0)
        Dim fonoNum As Integer = 0
        If Not String.IsNullOrWhiteSpace(fono) AndAlso Not Integer.TryParse(fono.Trim(), fonoNum) Then
            resp = "El teléfono ingresado excede el límite numérico permitido (máx. 9 dígitos)."
            Exit Sub
        End If
        Dim celNum As Integer = 0
        If Not String.IsNullOrWhiteSpace(celular) AndAlso Not Integer.TryParse(celular.Trim(), celNum) Then
            resp = "El celular ingresado excede el límite numérico permitido (máx. 9 dígitos)."
            Exit Sub
        End If

        Dim idPlanta As Integer = ParsearEnteroSeguro(planta, 0)
        Dim idSeccion As Integer = ParsearEnteroSeguro(seccion, 0)
        Dim idCargo As Integer = ParsearEnteroSeguro(cargo, 0)
        If idPlanta <= 0 OrElse idSeccion <= 0 OrElse idCargo <= 0 Then
            resp = "Debe seleccionar Planta, Sección y Cargo válidos."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("UPD_PERSONAL", cnx)
                    com.CommandType = CommandType.StoredProcedure

                    com.Parameters.AddWithValue("@rut", If(rut, String.Empty).Trim())
                    com.Parameters.AddWithValue("@dv", If(dv, String.Empty).Trim().ToUpperInvariant())
                    com.Parameters.AddWithValue("@cod_interno", codIntNum)
                    com.Parameters.AddWithValue("@nombres", If(nombres, String.Empty).Trim())
                    com.Parameters.AddWithValue("@ap_paterno", If(ap_paterno, String.Empty).Trim())
                    com.Parameters.AddWithValue("@ap_materno", If(ap_materno, String.Empty).Trim())
                    com.Parameters.AddWithValue("@fecha_nacimiento", fecha_nac.ToString("yyyyMMdd"))
                    com.Parameters.AddWithValue("@fono", fonoNum)
                    com.Parameters.AddWithValue("@email", If(email, String.Empty).Trim())
                    com.Parameters.AddWithValue("@idcentro", idPlanta)
                    com.Parameters.AddWithValue("@idseccion", idSeccion)
                    com.Parameters.AddWithValue("@idcargo", idCargo)
                    com.Parameters.AddWithValue("@alias", If(alias_personal, String.Empty).Trim())
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@activo", activo)
                    com.Parameters.AddWithValue("@direccion", If(direccion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@fecha_ingreso", fecha_ingreso.ToString("yyyyMMdd"))
                    com.Parameters.AddWithValue("@celular", celNum)
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                            If cod_resp = 1 Then OT.InvalidarCachePersonal()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Personal")
        End Try
    End Sub

    Public Sub DelPersonal(ByVal rut As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty
        Dim rutLimpio As String = If(rut, String.Empty).Trim()
        If String.IsNullOrEmpty(rutLimpio) Then
            resp = "Debe buscar o seleccionar un trabajador antes de eliminar."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using tx As SqlTransaction = cnx.BeginTransaction()
                    Dim refs As Integer = 0
                    Using cmdRef As New SqlCommand(
                        "SELECT (SELECT COUNT(1) FROM personal_ot WHERE rut = @rut) + " &
                        "(SELECT COUNT(1) FROM personal_ot_historico WHERE rut = @rut) + " &
                        "(SELECT COUNT(1) FROM ciclo_mp_personal WHERE rut = @rut)", cnx, tx)
                        cmdRef.Parameters.AddWithValue("@rut", rutLimpio)
                        refs = Convert.ToInt32(cmdRef.ExecuteScalar())
                    End Using

                    If refs > 0 Then
                        tx.Rollback()
                        cod_resp = 0
                        resp = "No es posible eliminar a este trabajador porque posee registros históricos en OTs o Mantenciones Preventivas. Puede desactivarlo marcando 'Activo = NO' y presionando Actualizar."
                        Exit Sub
                    End If

                    Dim afectados As Integer
                    Using cmdDel As New SqlCommand("DELETE FROM personal WHERE rut = @rut", cnx, tx)
                        cmdDel.Parameters.AddWithValue("@rut", rutLimpio)
                        afectados = cmdDel.ExecuteNonQuery()
                    End Using

                    If afectados > 0 Then
                        Dim sesLimpia As String = If(String.IsNullOrWhiteSpace(sesion), "SISTEMA", sesion.Trim())
                        Using cmdAud As New SqlCommand("ING_OPERACION", cnx, tx)
                            cmdAud.CommandType = CommandType.StoredProcedure
                            cmdAud.Parameters.AddWithValue("@sesion", sesLimpia.Substring(0, Math.Min(15, sesLimpia.Length)))
                            cmdAud.Parameters.AddWithValue("@operacion", "ELIMINAR")
                            cmdAud.Parameters.AddWithValue("@tabla", "personal")
                            cmdAud.Parameters.AddWithValue("@reg_afectado", rutLimpio)
                            cmdAud.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
                            cmdAud.ExecuteNonQuery()
                        End Using
                        tx.Commit()
                        OT.InvalidarCachePersonal()
                        cod_resp = 1
                        resp = "Trabajador eliminado correctamente."
                    Else
                        tx.Rollback()
                        cod_resp = 0
                        resp = "No se encontró el RUT ingresado en la tabla de personal."
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Personal")
        End Try
    End Sub

    Public Sub limpiarFormPersonal(ByRef form As FrmPersonal)
        If form Is Nothing Then Exit Sub
        With form
            .txtRut.ResetText()
            .txtDv.ResetText()
            .txtCodInt.ResetText()
            .txtNombres.ResetText()
            .txtApPaterno.ResetText()
            .txtApMaterno.ResetText()
            .txtfono.ResetText()
            .txtEmail.ResetText()
            .txtAlias.ResetText()
            .fecha_nac.Value = Now
            .txtDireccion.ResetText()
            .fecha_ingreso.Value = Now
            .txtCelular.ResetText()
            .opc_activo_si.Checked = True
            .btnIngresar.Visible = True
            .btnActualizar.Visible = False
        End With
    End Sub

    Public Sub CrgPersonal(ByRef DS As DataSet)
        If DS Is Nothing Then DS = New DataSet()
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_PERSONAL_2", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.Fill(DS)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Personal")
        End Try
    End Sub

    Public Sub buscarPersonalRut(ByVal rut As Integer)
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("BUSCAR_PERSONAL_RUT", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.SelectCommand.Parameters.AddWithValue("@rut", rut)

                    Using DST As New DataSet
                        DA.Fill(DST)
                        If DST.Tables.Count > 0 AndAlso DST.Tables(0).Rows.Count > 0 Then
                            Dim dr As DataRow = DST.Tables(0).Rows(0)
                            With FrmPersonal
                                .txtRut.Text = dr.Item(0).ToString().Trim()
                                .txtDv.Text = dr.Item(1).ToString().Trim()
                                .cmbPlanta.Text = dr.Item(2).ToString().Trim()
                                .cmbSeccion.Text = dr.Item(3).ToString().Trim()
                                .cmbCargo.Text = dr.Item(4).ToString().Trim()
                                .txtCodInt.Text = dr.Item(8).ToString().Trim()
                                .txtNombres.Text = dr.Item(5).ToString().Trim()
                                .txtApPaterno.Text = dr.Item(6).ToString().Trim()
                                .txtApMaterno.Text = dr.Item(7).ToString().Trim()
                                Utilitarios.AsignarFechaSegura(.fecha_nac, dr.Item(9), DateTime.Today)
                                .txtfono.Text = dr.Item(10).ToString().Trim()
                                .txtEmail.Text = dr.Item(11).ToString().Trim()
                                .txtAlias.Text = dr.Item(12).ToString().Trim()
                                Dim actStr As String = If(IsDBNull(dr.Item(13)), String.Empty, dr.Item(13).ToString().Trim())
                                If actStr.Equals("True", StringComparison.OrdinalIgnoreCase) OrElse actStr = "1" Then
                                    .opc_activo_si.Checked = True
                                Else
                                    .opc_activo_no.Checked = True
                                End If
                                .txtDireccion.Text = dr.Item(14).ToString().Trim()
                                Utilitarios.AsignarFechaSegura(.fecha_ingreso, dr.Item(15), DateTime.Today)
                                .txtCelular.Text = dr.Item(16).ToString().Trim()
                                .btnActualizar.Visible = True
                                .btnIngresar.Visible = False
                            End With
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Personal RUT")
        End Try
    End Sub

    Public Sub BuscarPersonalMp(ByRef txt_alias As TextBox)
        If txt_alias Is Nothing Then Exit Sub
        Try
            Dim datos As AutoCompleteStringCollection = OT.ObtenerColeccionAutocompletarPersonal()
            With txt_alias
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .AutoCompleteCustomSource = datos
            End With
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Personal MP")
        End Try
    End Sub

    Public Sub BuscarPersonalMp2(ByRef DS As DataSet)
        If DS Is Nothing Then DS = New DataSet()
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("AUTOCOMPLETAR_PERSONAL", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.Fill(DS)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Personal MP 2")
        End Try
    End Sub
End Class
