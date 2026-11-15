Imports System.Data.SqlClient
Public Class Personal

    Public Sub IngPersonal(ByVal rut As String, ByRef dv As String, ByVal cod_int As String, ByVal nombres As String, ByVal ap_paterno As String, ByVal ap_materno As String, ByVal alias_personal As String, ByVal fecha_nac As DateTime, ByVal fono As String, ByVal email As String, ByVal planta As String, ByVal seccion As String, ByVal cargo As String, ByVal sesion As String, ByVal activo As Boolean, ByVal direccion As String, ByVal fecha_ingreso As DateTime, ByVal celular As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        If cod_int = "" OrElse Not IsNumeric(cod_int) Then
            cod_int = "0"
        End If

        If fono = "" OrElse Not IsNumeric(fono) Then
            fono = "0"
        End If

        If celular = "" OrElse Not IsNumeric(celular) Then
            celular = "0"
        End If

        If email = "" Then
            email = ""
        End If


        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_PERSONAL", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
                Dim p_dv As SqlParameter = com.Parameters.AddWithValue("@dv", dv)
                Dim p_cod_interno As SqlParameter = com.Parameters.AddWithValue("@cod_interno", CInt(cod_int))
                Dim p_nombres As SqlParameter = com.Parameters.AddWithValue("@nombres", nombres)
                Dim p_ap_paterno As SqlParameter = com.Parameters.AddWithValue("@ap_paterno", ap_paterno)
                Dim p_ap_materno As SqlParameter = com.Parameters.AddWithValue("@ap_materno", ap_materno)
                Dim p_fecha_nac As SqlParameter = com.Parameters.AddWithValue("@fecha_nacimiento", fecha_nac.ToString("yyyyMMdd"))
                Dim p_fono As SqlClient.SqlParameter = com.Parameters.AddWithValue("@fono", CInt(fono))
                Dim p_email As SqlParameter = com.Parameters.AddWithValue("@email", email)
                Dim p_id_centro As SqlClient.SqlParameter = com.Parameters.AddWithValue("@idcentro", CInt(planta))
                Dim p_id_seccion As SqlClient.SqlParameter = com.Parameters.AddWithValue("@idseccion", seccion)
                Dim p_id_cargo As SqlClient.SqlParameter = com.Parameters.AddWithValue("@idcargo", cargo)
                Dim p_alias As SqlClient.SqlParameter = com.Parameters.AddWithValue("@alias", alias_personal)
                Dim p_sesion As SqlClient.SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
                Dim p_activo As SqlClient.SqlParameter = com.Parameters.AddWithValue("@activo", activo)
                Dim p_direccion As SqlClient.SqlParameter = com.Parameters.AddWithValue("@direccion", direccion)
                Dim p_fecha_ing As SqlClient.SqlParameter = com.Parameters.AddWithValue("@fecha_ingreso", fecha_ingreso.ToString("yyyyMMdd"))
                Dim p_celular As SqlClient.SqlParameter = com.Parameters.AddWithValue("@celular", CInt(celular))
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                        If cod_resp = 1 Then OT.InvalidarCachePersonal()
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Personal")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub UpdPersonal(ByVal rut As String, ByRef dv As String, ByVal cod_int As String, ByVal nombres As String, ByVal ap_paterno As String, ByVal ap_materno As String, ByVal alias_personal As String, ByVal fecha_nac As Date, ByVal fono As String, ByVal email As String, ByVal planta As String, ByVal seccion As String, ByVal cargo As String, ByVal sesion As String, ByVal activo As Boolean, ByVal direccion As String, ByVal fecha_ingreso As DateTime, ByVal celular As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        If cod_int = "" OrElse Not IsNumeric(cod_int) Then
            cod_int = "0"
        End If

        If fono = "" OrElse Not IsNumeric(fono) Then
            fono = "0"
        End If

        If celular = "" OrElse Not IsNumeric(celular) Then
            celular = "0"
        End If

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_PERSONAL", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
                Dim p_dv As SqlParameter = com.Parameters.AddWithValue("@dv", dv)
                Dim p_cod_interno As SqlParameter = com.Parameters.AddWithValue("@cod_interno", CInt(cod_int))
                Dim p_nombres As SqlParameter = com.Parameters.AddWithValue("@nombres", nombres)
                Dim p_ap_paterno As SqlParameter = com.Parameters.AddWithValue("@ap_paterno", ap_paterno)
                Dim p_ap_materno As SqlParameter = com.Parameters.AddWithValue("@ap_materno", ap_materno)
                Dim p_fecha_nac As SqlParameter = com.Parameters.AddWithValue("@fecha_nacimiento", fecha_nac.ToString("yyyyMMdd"))
                Dim p_fono As SqlClient.SqlParameter = com.Parameters.AddWithValue("@fono", CInt(fono))
                Dim p_email As SqlParameter = com.Parameters.AddWithValue("@email", email)
                Dim p_id_centro As SqlClient.SqlParameter = com.Parameters.AddWithValue("@idcentro", CInt(planta))
                Dim p_id_seccion As SqlClient.SqlParameter = com.Parameters.AddWithValue("@idseccion", CInt(seccion))
                Dim p_id_cargo As SqlClient.SqlParameter = com.Parameters.AddWithValue("@idcargo", CInt(cargo))
                Dim p_alias As SqlClient.SqlParameter = com.Parameters.AddWithValue("@alias", alias_personal)
                Dim p_sesion As SqlClient.SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
                Dim p_activo As SqlClient.SqlParameter = com.Parameters.AddWithValue("@activo", activo)
                Dim p_direccion As SqlClient.SqlParameter = com.Parameters.AddWithValue("@direccion", direccion)
                Dim p_fecha_ing As SqlClient.SqlParameter = com.Parameters.AddWithValue("@fecha_ingreso", fecha_ingreso.ToString("yyyyMMdd"))
                Dim p_celular As SqlClient.SqlParameter = com.Parameters.AddWithValue("@celular", CInt(celular))
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                        If cod_resp = 1 Then OT.InvalidarCachePersonal()
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Personal")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub limpiarFormPersonal(ByRef form As FrmPersonal)
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
            .btnIngresar.Visible = True
            .btnActualizar.Visible = False
        End With
    End Sub

    Public Sub CrgPersonal(ByRef DS As DataSet)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_PERSONAL_2", cnx)
                DA.Fill(DS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Personal")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub buscarPersonalRut(ByVal rut As Integer)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("BUSCAR_PERSONAL_RUT", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure

                Dim p_rut As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@rut", CInt(rut))

                Dim DST As New DataSet
                DA.Fill(DST)
                If DST.Tables.Count > 0 AndAlso DST.Tables(0).Rows.Count > 0 Then
                    With FrmPersonal
                        .txtRut.Text = DST.Tables(0).Rows(0).Item(0).ToString
                        .txtDv.Text = DST.Tables(0).Rows(0).Item(1).ToString
                        .cmbPlanta.Text = DST.Tables(0).Rows(0).Item(2).ToString
                        .cmbSeccion.Text = DST.Tables(0).Rows(0).Item(3).ToString
                        .cmbCargo.Text = DST.Tables(0).Rows(0).Item(4).ToString
                        .txtCodInt.Text = DST.Tables(0).Rows(0).Item(8).ToString
                        .txtNombres.Text = DST.Tables(0).Rows(0).Item(5).ToString
                        .txtApPaterno.Text = DST.Tables(0).Rows(0).Item(6).ToString
                        .txtApMaterno.Text = DST.Tables(0).Rows(0).Item(7).ToString
                        ' Asignación segura de fecha de nacimiento y fecha de ingreso con fallback para evitar caídas por valores nulos
                        Utilitarios.AsignarFechaSegura(.fecha_nac, DST.Tables(0).Rows(0).Item(9), DateTime.Today)
                        .txtfono.Text = DST.Tables(0).Rows(0).Item(10).ToString
                        .txtEmail.Text = DST.Tables(0).Rows(0).Item(11).ToString
                        .txtAlias.Text = DST.Tables(0).Rows(0).Item(12).ToString
                        If DST.Tables(0).Rows(0).Item(13).ToString = "True" Then
                            .opc_activo_si.Checked = True
                        Else
                            .opc_activo_no.Checked = True
                        End If
                        .txtDireccion.Text = DST.Tables(0).Rows(0).Item(14).ToString
                        Utilitarios.AsignarFechaSegura(.fecha_ingreso, DST.Tables(0).Rows(0).Item(15), DateTime.Today)
                        .txtCelular.Text = DST.Tables(0).Rows(0).Item(16).ToString
                        .btnActualizar.Visible = True
                        .btnIngresar.Visible = False
                    End With
                End If
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Personal RUT")
        Finally
            conexion.Desconectar(cnx)
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
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Dim datos As New AutoCompleteStringCollection
        Try
            conexion.Conectar(cnx)

            Using DA As New SqlDataAdapter("AUTOCOMPLETAR_PERSONAL", cnx)
                DA.Fill(DS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Personal MP 2")
        Finally
            conexion.Desconectar(cnx)
        End Try

    End Sub
End Class
