Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class OT

    Public Sub IngOtAbierta(ByVal N_OT As String, ByVal id_nodo As String, ByVal id_sintoma As String, ByVal id_modo_falla As String, ByVal fecha_r As DateTime, ByVal hr_r As DateTime, ByVal fecha_ini As DateTime, ByVal hr_ini As DateTime, ByVal tipo_det As String, ByVal detencion As String, ByVal desc_falla As String, ByVal solicitado_por As String, ByVal recibido_por As String, ByVal tipo_trab As String, ByVal sesion As String, ByVal desc_tecnica As String, ByVal mant_interna As Boolean, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_OT_ABIERTA", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim nOtInt As Integer = 0
                Dim idNodoInt As Integer = 0
                If Not Utilitarios.TrySafeInt(N_OT, nOtInt) OrElse Not Utilitarios.TrySafeInt(id_nodo, idNodoInt) Then
                    cod_resp = 0
                    resp = "El número de OT y el nodo seleccionado deben ser numéricos válidos."
                    Exit Sub
                End If
                Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@n_ot", nOtInt)
                Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", idNodoInt)
                Dim p_tipo_det As SqlParameter = com.Parameters.AddWithValue("@id_tipo", tipo_det)
                Dim p_tipo_trab As SqlParameter = com.Parameters.AddWithValue("@tipo_trabajo", tipo_trab)
                Dim p_id_sintoma As SqlParameter = com.Parameters.AddWithValue("@id_sintoma", id_sintoma)
                Dim p_id_modo_falla As SqlParameter = com.Parameters.AddWithValue("@id_modo_falla", id_modo_falla)

                ' Reparación formato fecha y hora universal
                Utilitarios.AgregarParametroFecha(com, "@fecha_recep", Utilitarios.SafeSqlDateStart(fecha_r))
                Utilitarios.AgregarParametroFecha(com, "@hr_recep", Utilitarios.SafeSqlTime(hr_r))
                Utilitarios.AgregarParametroFecha(com, "@fecha_ini", Utilitarios.SafeSqlDateStart(fecha_ini))
                Utilitarios.AgregarParametroFecha(com, "@hr_ini", Utilitarios.SafeSqlTime(hr_ini))

                Dim p_detencion As SqlParameter = com.Parameters.AddWithValue("@detencion", If(detencion, String.Empty))
                Dim p_desc_falla As SqlParameter = com.Parameters.AddWithValue("@desc_breve", If(desc_falla, String.Empty))
                Dim p_solitado_por As SqlParameter = com.Parameters.AddWithValue("@per_solicita", If(solicitado_por, String.Empty))
                Dim p_recibido_por As SqlParameter = com.Parameters.AddWithValue("@per_recepcion", If(recibido_por, String.Empty))
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty))
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
                Dim p_desc_tecnica As SqlParameter = com.Parameters.AddWithValue("@desc_tecnica", If(desc_tecnica, String.Empty))
                Dim p_mant_interna As SqlParameter = com.Parameters.AddWithValue("@mant_interna", mant_interna)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar OT Abierta")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub IngOtCerrada(ByVal N_OT As String, ByVal id_nodo As String, ByVal id_sintoma As String, ByVal id_modo_falla As String, ByVal fecha_r As DateTime, ByVal hr_r As DateTime, ByVal fecha_ini As DateTime, ByVal hr_ini As DateTime, ByVal fecha_fin As DateTime, ByVal hora_fin As DateTime, ByVal fecha_entrega As DateTime, ByVal hora_entrega As DateTime, ByVal duracion As String, ByVal tipo_det As String, ByVal detencion As String, ByVal desc_falla As String, ByVal desc_tecnica As String, ByVal solicitado_por As String, ByVal recibido_por As String, ByVal cerrada_por As String, ByVal tipo_trab As String, ByVal sesion As String, ByVal estado_ot As String, ByVal mant_interna As Boolean, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_OT_CERRADA", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim nOtInt As Integer = 0
                Dim idNodoInt As Integer = 0
                If Not Utilitarios.TrySafeInt(N_OT, nOtInt) OrElse Not Utilitarios.TrySafeInt(id_nodo, idNodoInt) Then
                    cod_resp = 0
                    resp = "El número de OT y el nodo seleccionado deben ser numéricos válidos."
                    Exit Sub
                End If
                Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@n_ot", nOtInt)
                Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", idNodoInt)
                Dim p_tipo_det As SqlParameter = com.Parameters.AddWithValue("@id_tipo", tipo_det)
                Dim p_tipo_trab As SqlParameter = com.Parameters.AddWithValue("@tipo_trab", tipo_trab)
                Dim p_id_sintoma As SqlParameter = com.Parameters.AddWithValue("@id_sintoma", id_sintoma)
                Dim p_id_modo_falla As SqlParameter = com.Parameters.AddWithValue("@id_modo_falla", id_modo_falla)

                ' Reparación formato fecha y hora universal
                Utilitarios.AgregarParametroFecha(com, "@fecha_recep", Utilitarios.SafeSqlDateStart(fecha_r))
                Utilitarios.AgregarParametroFecha(com, "@hora_recep", Utilitarios.SafeSqlTime(hr_r))
                Utilitarios.AgregarParametroFecha(com, "@fecha_ini_ot", Utilitarios.SafeSqlDateStart(fecha_ini))
                Utilitarios.AgregarParametroFecha(com, "@hora_ini_ot", Utilitarios.SafeSqlTime(hr_ini))
                Utilitarios.AgregarParametroFecha(com, "@fecha_fin_ot", Utilitarios.SafeSqlDateStart(fecha_fin))
                Utilitarios.AgregarParametroFecha(com, "@hora_fin_ot", Utilitarios.SafeSqlTime(hora_fin))
                Utilitarios.AgregarParametroFecha(com, "@fecha_entrega", Utilitarios.SafeSqlDateStart(fecha_entrega))
                Utilitarios.AgregarParametroFecha(com, "@hora_entrega", Utilitarios.SafeSqlTime(hora_entrega))

                Dim p_detencion As SqlParameter = com.Parameters.AddWithValue("@detencion", If(detencion, String.Empty))
                Dim p_desc_falla As SqlParameter = com.Parameters.AddWithValue("@desc_breve", If(desc_falla, String.Empty))
                Dim p_desc_tecnica As SqlParameter = com.Parameters.AddWithValue("@desc_tecnica", If(desc_tecnica, String.Empty))
                Dim p_tiempo_ot As SqlParameter = com.Parameters.AddWithValue("@tiempo_det", Utilitarios.SafeDouble(duracion, 0.0))
                Dim p_solitado_por As SqlParameter = com.Parameters.AddWithValue("@per_solicita", If(solicitado_por, String.Empty))
                Dim p_recibido_por As SqlParameter = com.Parameters.AddWithValue("@per_recepcion", If(recibido_por, String.Empty))
                Dim p_cerrada_por As SqlParameter = com.Parameters.AddWithValue("@per_cierre", If(cerrada_por, String.Empty))
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty))
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
                Dim p_estado_ot As SqlParameter = com.Parameters.AddWithValue("@estado_ot", estado_ot)
                Dim p_mant_interna As SqlParameter = com.Parameters.AddWithValue("@mant_interna", mant_interna)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar OT Cerrada")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub IngPersonalOt(ByVal rut As String, ByVal id_ot As String, ByRef obs_personal As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            If obs_personal Is Nothing OrElse obs_personal = "" Then
                obs_personal = ""
            End If
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_PERSONAL_OT", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idOtInt As Integer = 0
                If Not Utilitarios.TrySafeInt(id_ot, idOtInt) Then Exit Sub
                Dim p_num_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", idOtInt)
                Dim p_rut_per As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
                Dim p_obs_per As SqlParameter = com.Parameters.AddWithValue("@obs_personal", obs_personal)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Personal OT")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub IngOtExterna(ByVal num_ot As String, ByVal num_ot_ext As String, ByVal obs_ot_ext As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            If obs_ot_ext Is Nothing Then
                obs_ot_ext = ""
            End If
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_OT_EXTERNA_OT", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim numOtInt As Integer = 0
                Dim numOtExtInt As Integer = 0
                If Not Utilitarios.TrySafeInt(num_ot, numOtInt) OrElse Not Utilitarios.TrySafeInt(num_ot_ext, numOtExtInt) Then Exit Sub
                Dim p_num_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", numOtInt)
                Dim p_num_ot_ext As SqlParameter = com.Parameters.AddWithValue("@num_ot_ext", numOtExtInt)
                Dim p_obs_ot_ext As SqlParameter = com.Parameters.AddWithValue("@obs_ot_ext", obs_ot_ext)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar OT Externa")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub IngInsumosOt(ByVal num_ot As String, ByVal id_insumo As String, ByVal cantidad As String, ByVal unid_medida As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_INSUMOS_OT", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim numOtInt As Integer = 0
                Dim idInsInt As Integer = 0
                If Not Utilitarios.TrySafeInt(num_ot, numOtInt) OrElse Not Utilitarios.TrySafeInt(id_insumo, idInsInt) Then Exit Sub
                Dim p_num_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", numOtInt)
                Dim p_id_insumo As SqlParameter = com.Parameters.AddWithValue("@idinsumo", idInsInt)
                Dim p_cantidad As SqlParameter = com.Parameters.AddWithValue("@cantidad", Utilitarios.SafeInt(cantidad, 0))
                Dim p_unid_medida As SqlParameter = com.Parameters.AddWithValue("@unid_medida", If(unid_medida, ""))

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Insumos OT")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub UpdOtAbierta(ByVal N_OT As String, ByVal id_nodo As String, ByVal id_sintoma As String, ByVal id_modo_falla As String, ByVal fecha_r As DateTime, ByVal hr_r As DateTime, ByVal fecha_ini As DateTime, ByVal hr_ini As DateTime, ByVal tipo_det As String, ByVal detencion As String, ByVal desc_falla As String, ByVal solicitado_por As String, ByVal recibido_por As String, ByVal tipo_trab As String, ByVal sesion As String, ByVal mant_interna As Boolean, ByVal desc_tecnica As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_OT_ABIERTA", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim nOtInt As Integer = 0
                Dim idNodoInt As Integer = 0
                If Not Utilitarios.TrySafeInt(N_OT, nOtInt) OrElse Not Utilitarios.TrySafeInt(id_nodo, idNodoInt) Then
                    cod_resp = 0
                    resp = "El número de OT y el nodo seleccionado deben ser numéricos válidos."
                    Exit Sub
                End If
                Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@n_ot", nOtInt)
                Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", idNodoInt)
                Dim p_tipo_det As SqlParameter = com.Parameters.AddWithValue("@id_tipo", tipo_det)
                Dim p_tipo_trab As SqlParameter = com.Parameters.AddWithValue("@tipo_trabajo", tipo_trab)
                Dim p_id_sintoma As SqlParameter = com.Parameters.AddWithValue("@id_sintoma", id_sintoma)
                Dim p_id_modo_falla As SqlParameter = com.Parameters.AddWithValue("@id_modo_falla", id_modo_falla)

                ' Reparación formato fecha y hora universal
                Utilitarios.AgregarParametroFecha(com, "@fecha_recep", Utilitarios.SafeSqlDateStart(fecha_r))
                Utilitarios.AgregarParametroFecha(com, "@hr_recep", Utilitarios.SafeSqlTime(hr_r))
                Utilitarios.AgregarParametroFecha(com, "@fecha_ini", Utilitarios.SafeSqlDateStart(fecha_ini))
                Utilitarios.AgregarParametroFecha(com, "@hr_ini", Utilitarios.SafeSqlTime(hr_ini))

                Dim p_detencion As SqlParameter = com.Parameters.AddWithValue("@detencion", If(detencion, String.Empty))
                Dim p_desc_falla As SqlParameter = com.Parameters.AddWithValue("@desc_breve", If(desc_falla, String.Empty))
                Dim p_solitado_por As SqlParameter = com.Parameters.AddWithValue("@per_solicita", If(solicitado_por, String.Empty))
                Dim p_recibido_por As SqlParameter = com.Parameters.AddWithValue("@per_recepcion", If(recibido_por, String.Empty))
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty))
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
                Dim p_desc_tecnica As SqlParameter = com.Parameters.AddWithValue("@desc_tecnica", If(desc_tecnica, String.Empty))
                Dim p_mant_interna As SqlParameter = com.Parameters.AddWithValue("@mant_interna", mant_interna)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar OT Abierta")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub UpdOtCerrada(ByVal N_OT As String, ByVal id_nodo As String, ByVal id_sintoma As String, ByVal id_modo_falla As String, ByVal fecha_r As DateTime, ByVal hr_r As DateTime, ByVal fecha_ini As DateTime, ByVal hr_ini As DateTime, ByVal fecha_fin As DateTime, ByVal hora_fin As DateTime, ByVal fecha_entrega As DateTime, ByVal hora_entrega As DateTime, ByVal duracion As String, ByVal tipo_det As String, ByVal detencion As String, ByVal desc_falla As String, ByVal desc_tecnica As String, ByVal solicitado_por As String, ByVal recibido_por As String, ByVal cerrada_por As String, ByVal tipo_trab As String, ByVal sesion As String, ByVal estado_ot As String, ByVal mant_interna As Boolean, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_OT_CERRADA", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim nOtInt As Integer = 0
                Dim idNodoInt As Integer = 0
                If Not Utilitarios.TrySafeInt(N_OT, nOtInt) OrElse Not Utilitarios.TrySafeInt(id_nodo, idNodoInt) Then
                    cod_resp = 0
                    resp = "El número de OT y el nodo seleccionado deben ser numéricos válidos."
                    Exit Sub
                End If
                Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@n_ot", nOtInt)
                Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", idNodoInt)
                Dim p_tipo_det As SqlParameter = com.Parameters.AddWithValue("@id_tipo", tipo_det)
                Dim p_tipo_trab As SqlParameter = com.Parameters.AddWithValue("@tipo_trabajo", tipo_trab)
                Dim p_id_sintoma As SqlParameter = com.Parameters.AddWithValue("@id_sintoma", id_sintoma)
                Dim p_id_modo_falla As SqlParameter = com.Parameters.AddWithValue("@id_modo_falla", id_modo_falla)

                ' Reparación formato fecha y hora universal
                Utilitarios.AgregarParametroFecha(com, "@fecha_recep", Utilitarios.SafeSqlDateStart(fecha_r))
                Utilitarios.AgregarParametroFecha(com, "@hora_recep", Utilitarios.SafeSqlTime(hr_r))
                Utilitarios.AgregarParametroFecha(com, "@fecha_ini_ot", Utilitarios.SafeSqlDateStart(fecha_ini))
                Utilitarios.AgregarParametroFecha(com, "@hora_ini_ot", Utilitarios.SafeSqlTime(hr_ini))
                Utilitarios.AgregarParametroFecha(com, "@fecha_fin_ot", Utilitarios.SafeSqlDateStart(fecha_fin))
                Utilitarios.AgregarParametroFecha(com, "@hora_fin_ot", Utilitarios.SafeSqlTime(hora_fin))
                Utilitarios.AgregarParametroFecha(com, "@fecha_entrega", Utilitarios.SafeSqlDateStart(fecha_entrega))
                Utilitarios.AgregarParametroFecha(com, "@hora_entrega", Utilitarios.SafeSqlTime(hora_entrega))

                Dim p_detencion As SqlParameter = com.Parameters.AddWithValue("@detencion", If(detencion, String.Empty))
                Dim p_desc_falla As SqlParameter = com.Parameters.AddWithValue("@desc_breve", If(desc_falla, String.Empty))
                Dim p_desc_tecnica As SqlParameter = com.Parameters.AddWithValue("@desc_tecnica", If(desc_tecnica, String.Empty))
                Dim p_tiempo_ot As SqlParameter = com.Parameters.AddWithValue("@tiempo_det", Utilitarios.SafeDouble(duracion, 0.0))
                Dim p_solitado_por As SqlParameter = com.Parameters.AddWithValue("@per_solicita", If(solicitado_por, String.Empty))
                Dim p_recibido_por As SqlParameter = com.Parameters.AddWithValue("@per_recepcion", If(recibido_por, String.Empty))
                Dim p_cerrada_por As SqlParameter = com.Parameters.AddWithValue("@per_cierre", If(cerrada_por, String.Empty))
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty))
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
                Dim p_estado_ot As SqlParameter = com.Parameters.AddWithValue("@estado_ot", estado_ot)
                Dim p_mant_interna As SqlParameter = com.Parameters.AddWithValue("@mant_interna", mant_interna)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar OT Cerrada")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub UpdPersonalOt(ByVal N_OT As String, ByVal rut As String, ByVal obs_personal As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_PERSONAL_OT", cnx)
                com.CommandType = CommandType.StoredProcedure
                If obs_personal Is Nothing Then
                    obs_personal = ""
                End If
                Dim nOtInt As Integer = 0
                If Not Utilitarios.TrySafeInt(N_OT, nOtInt) Then Exit Sub
                Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", nOtInt)
                Dim p_rut_per As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
                Dim p_obs_personal As SqlParameter = com.Parameters.AddWithValue("@obs_personal", obs_personal)

                com.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Personal OT")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub UpdInsumosOt(ByVal N_OT As String, ByVal id_insumo As String, ByVal cantidad As String, ByVal unid_medida As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_INSUMOS_OT", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim nOtInt As Integer = 0
                Dim idInsInt As Integer = 0
                If Not Utilitarios.TrySafeInt(N_OT, nOtInt) OrElse Not Utilitarios.TrySafeInt(id_insumo, idInsInt) Then Exit Sub
                Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", nOtInt)
                Dim p_id_insumo As SqlParameter = com.Parameters.AddWithValue("@id_insumo", idInsInt)
                Dim p_cantidad As SqlParameter = com.Parameters.AddWithValue("@cantidad", Utilitarios.SafeInt(cantidad, 0))
                Dim p_unid_medida As SqlParameter = com.Parameters.AddWithValue("@unid_medida", If(unid_medida, ""))

                com.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Insumos OT")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub UpdOtExterna(ByVal N_OT As String, ByVal num_ot_ext As String, ByVal obs_ot_ext As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_OT_EXTERNA_OT", cnx)
                com.CommandType = CommandType.StoredProcedure
                If obs_ot_ext Is Nothing Then
                    obs_ot_ext = ""
                End If
                Dim nOtInt As Integer = 0
                Dim numOtExtInt As Integer = 0
                If Not Utilitarios.TrySafeInt(N_OT, nOtInt) OrElse Not Utilitarios.TrySafeInt(num_ot_ext, numOtExtInt) Then Exit Sub
                Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", nOtInt)
                Dim p_n_ot_ext As SqlParameter = com.Parameters.AddWithValue("@num_ot_ext", numOtExtInt)
                Dim p_obs_ot_ext As SqlParameter = com.Parameters.AddWithValue("@obs_ot_ext", obs_ot_ext)

                com.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar OT Externa")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub CrgCmbDetencion(ByRef combo As ComboBox)
        With combo
            .Items.Clear()
            .Items.Add("SI")
            .Items.Add("NO")
            If .Items.Count > 0 Then .Text = .Items(0).ToString()
        End With
    End Sub

    Public Sub CrgCmbTipoDet(ByRef combo As ComboBox)
        With combo
            .Items.Clear()
            .Items.Add("Mecánica")
            .Items.Add("Eléctrica")
            .Items.Add("Electrónica")
            .Items.Add("Soldadura")
            .Items.Add("Servicios Generales")
            If .Items.Count > 0 Then .Text = .Items(0).ToString()
        End With
    End Sub

    Public Sub CrgOrdenTrabajo(ByVal num_ot As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_ORDEN_TRABAJO", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim numOtInt As Integer = 0
                If Not Utilitarios.TrySafeInt(num_ot, numOtInt) Then Exit Sub
                Dim p_num_ot As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@num_ot", numOtInt)

                DA.Fill(DS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Orden Trabajo")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub CrgPersonalOt(ByVal num_ot As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_PERSONAL_OT", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim numOtInt As Integer = 0
                If Not Utilitarios.TrySafeInt(num_ot, numOtInt) Then Exit Sub
                Dim p_num_ot As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@num_ot", numOtInt)

                DA.Fill(DS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Personal OT")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub CrgOtExterna(ByVal num_ot As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_OT_EXTERNA_OT", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim numOtInt As Integer = 0
                If Not Utilitarios.TrySafeInt(num_ot, numOtInt) Then Exit Sub
                Dim p_num_ot As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@num_ot", numOtInt)

                DA.Fill(DS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar OT Externa")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub CrgInsumosOt(ByVal num_ot As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_INSUMOS_OT", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim numOtInt As Integer = 0
                If Not Utilitarios.TrySafeInt(num_ot, numOtInt) Then Exit Sub
                Dim p_num_ot As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@num_ot", numOtInt)

                DA.Fill(DS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Insumos OT")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub LimpiarFrmOt()
        Dim formato_grid As New FormatoGrillas
        Dim i As Integer = 0

        With frm_OT
            .txtNot.Clear()
            .dt_fecha_rec.ResetText()
            .dt_hr_rec.ResetText()
            .dt_fecha_ini.ResetText()
            .dt_hr_ini.ResetText()
            .text_turno.Clear()
            .cmb_Tipo_Det.ResetText()
            .cmb_det.ResetText()
            .cmb_Tipo_trab.ResetText()
            .txtRecibidoPor.Clear()
            .txtSolicitadoPor.Clear()
            .text_des_falla.Clear()
            .dt_fecha_ter.ResetText()
            .dt_hr_ter.ResetText()
            .dt_fecha_cierre.ResetText()
            .dt_hr_cierre.ResetText()
            .txtDuracionOt.Clear()
            .txtDescTrab.Clear()
            .txtCerradoPor.Clear()
            .txtBuscarNodo.Clear()
            .chkOtCierre.Checked = False
            If .cmbEstadoOt.Items.Count > 0 Then .cmbEstadoOt.Text = .cmbEstadoOt.Items(0).ToString()
            .cmbEstadoOt.Enabled = False
            .chkOtMpInterna.Checked = False
            .btn_guardar.Enabled = Usuario.PermisoGuardarOt
            .btn_eliminar.Enabled = Usuario.PermisoEliminarOt
            ' -------------------- LIMPIA LAS GRILLAS Y LOS VINCULOS DE DATOS DEL FORMULARIO -------------------------

            If .grillaPersonalOt.RowCount > 0 Then
                .DSPOT.Tables.Clear()
                .grillaPersonalOt.DataSource = Nothing
                .grillaPersonalOt.Columns.Clear()
                formato_grid.grillasOT(.grillaPersonalOt)
            Else
                .grillaPersonalOt.DataSource = Nothing
                formato_grid.grillasOT(.grillaPersonalOt)
            End If

            If .grillaInsumosOt.RowCount > 0 Then
                .DSIOT.Tables.Clear()
                If .grillaInsumosOt.DataSource IsNot Nothing Then
                    .grillaInsumosOt.DataSource = Nothing
                Else
                    For idx As Integer = .grillaInsumosOt.RowCount - 1 To 0 Step -1
                        If Not .grillaInsumosOt.Rows(idx).IsNewRow Then
                            .grillaInsumosOt.Rows.RemoveAt(idx)
                        End If
                    Next
                End If
            End If

            If .grillaOtExternas.RowCount > 0 Then
                .DSOEXOT.Tables.Clear()
                .grillaOtExternas.DataSource = Nothing
                .grillaOtExternas.Columns.Clear()
                formato_grid.grillasOT(.grillaOtExternas)
            End If

            If .chkOtCierre.Enabled = False Then
                .chkOtCierre.Enabled = True
            End If
            '----------------------------------------------------------------------------------------------------------

            '----------------------- LIMPIA EL NODO SELECCIONADO Y REFRESCA EL ARBOL PARA LIMPIAR ---------------------
            Nodo.LimpiarResaltadoNodos(.arbol3.Nodes)
            .arbol3.SelectedNode = Nothing
            If .arbol3.Nodes.Count > 0 Then
                .arbol3.Nodes(0).Collapse()
            End If
            .id_nodo_ot_select = ""
            .nodo_anterior = ""
            .nodo_anterior2 = ""
            .ot_cargada_actual = ""

            '------------------------------------------------------------------------------------------------------------
            .form_limpio = True
        End With
    End Sub

    Public Function BuscarNumOt(ByVal num_ot As String) As String
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim resp As String = ""
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("BUSCAR_NUM_OT", cnx)
                com.CommandType = CommandType.StoredProcedure
                Dim numOtInt As Integer = 0
                If Not Utilitarios.TrySafeInt(num_ot, numOtInt) Then Return String.Empty
                Dim p_num_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", numOtInt)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read Then
                        If Not IsDBNull(DR(0)) AndAlso Convert.ToInt32(DR(0)) = 1 AndAlso DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)) Then
                            resp = DR(1).ToString()
                        Else
                            resp = ""
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar N° OT")
        Finally
            conexion.Desconectar(cnx)
        End Try
        Return resp
    End Function

    Public Sub DelOrdenTrabajo(ByVal N_OT As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("DEL_ORDEN_TRABAJO", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim nOtInt As Integer = 0
                If Not Utilitarios.TrySafeInt(N_OT, nOtInt) Then
                    cod_resp = 0
                    resp = "El número de OT debe ser un valor numérico válido."
                    Exit Sub
                End If
                Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", nOtInt)
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Orden Trabajo")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub DelPersonalOt(ByVal N_OT As String, ByVal rut As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("DEL_PERSONAL_OT", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim nOtInt As Integer = 0
                If Not Utilitarios.TrySafeInt(N_OT, nOtInt) Then Exit Sub
                Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", nOtInt)
                Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Personal OT")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub DelOtExterna(ByVal N_OT As String, ByVal num_ot_ext As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("DEL_OT_EXTERNA_OT", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim nOtInt As Integer = 0
                Dim numOtExtInt As Integer = 0
                If Not Utilitarios.TrySafeInt(N_OT, nOtInt) OrElse Not Utilitarios.TrySafeInt(num_ot_ext, numOtExtInt) Then Exit Sub
                Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", nOtInt)
                Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@num_ot_ext", numOtExtInt)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar OT Externa")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub DelInsumoOt(ByVal N_OT As String, ByVal id_insumo As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("DEL_INSUMO_OT", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim nOtInt As Integer = 0
                Dim idInsInt As Integer = 0
                If Not Utilitarios.TrySafeInt(N_OT, nOtInt) OrElse Not Utilitarios.TrySafeInt(id_insumo, idInsInt) Then Exit Sub
                Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", nOtInt)
                Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@id_insumo", idInsInt)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Insumo OT")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Private Shared _cacheAutocompletarPersonal As AutoCompleteStringCollection = Nothing
    Private Shared ReadOnly _cachePersonalLock As New Object()

    Public Shared Sub InvalidarCachePersonal()
        SyncLock _cachePersonalLock
            _cacheAutocompletarPersonal = Nothing
        End SyncLock
    End Sub

    Public Shared Function ObtenerColeccionAutocompletarPersonal() As AutoCompleteStringCollection
        SyncLock _cachePersonalLock
            If _cacheAutocompletarPersonal IsNot Nothing AndAlso _cacheAutocompletarPersonal.Count > 0 Then
                Return _cacheAutocompletarPersonal
            End If
        End SyncLock

        Dim coleccion As New AutoCompleteStringCollection
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("AUTOCOMPLETAR_PERSONAL", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    Using dr As SqlDataReader = com.ExecuteReader()
                        While dr.Read()
                            If dr.FieldCount > 1 AndAlso Not dr.IsDBNull(1) Then
                                coleccion.Add(dr(1).ToString())
                            End If
                        End While
                    End Using
                End Using
            End Using
            SyncLock _cachePersonalLock
                _cacheAutocompletarPersonal = coleccion
            End SyncLock
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Obtener Colección Autocompletar Personal")
        End Try
        Return coleccion
    End Function

    Public Sub autocompletar_personal(ByRef textbox As TextBox)
        If textbox Is Nothing Then Exit Sub
        Try
            Dim coleccion As AutoCompleteStringCollection = ObtenerColeccionAutocompletarPersonal()
            textbox.AutoCompleteMode = AutoCompleteMode.Suggest
            textbox.AutoCompleteSource = AutoCompleteSource.CustomSource
            textbox.AutoCompleteCustomSource = coleccion
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Autocompletar Personal")
        End Try
    End Sub

    Public Sub autocompletar_personal(ParamArray textboxes() As TextBox)
        If textboxes Is Nothing OrElse textboxes.Length = 0 Then Exit Sub
        Try
            Dim coleccion As AutoCompleteStringCollection = ObtenerColeccionAutocompletarPersonal()
            For Each txt In textboxes
                If txt IsNot Nothing Then
                    txt.AutoCompleteMode = AutoCompleteMode.Suggest
                    txt.AutoCompleteSource = AutoCompleteSource.CustomSource
                    txt.AutoCompleteCustomSource = coleccion
                End If
            Next
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Autocompletar Personal")
        End Try
    End Sub


    Public Function validarOtAbierta() As String
        Dim resp As String = ""

        With frm_OT
            If .id_nodo_ot_select = "" Then
                resp = "Debe seleccionar un nodo del arbol" & Chr(13)
            End If

            If .txtNot.Text = "" Then
                resp = resp & "Debe ingresar un numero de orden de trabajo" & Chr(13)
            End If

            If .txtRecibidoPor.Text = "" Then
                resp = resp & "Debe ingresar el personal que recibe la orden" & Chr(13)
            End If

            If .txtSolicitadoPor.Text = "" Then
                resp = resp & "Debe ingresar el personal que solicita la orden" & Chr(13)
            End If

            If .text_des_falla.Text = "" Then
                resp = resp & "Debe ingresar una descripción breve"
            End If
        End With

        Return resp
    End Function

    Public Function validarOtCerrada() As String
        Dim resp As String = ""
        Dim fecha_hora_recepcion As DateTime
        Dim fecha_hora_inicio As DateTime
        Dim fecha_hora_termino As DateTime
        Dim fecha_hora_cierre As DateTime

        With frm_OT
            fecha_hora_recepcion = .dt_fecha_rec.Value.Date.Add(New TimeSpan(.dt_hr_rec.Value.Hour, .dt_hr_rec.Value.Minute, 0))
            fecha_hora_inicio = .dt_fecha_ini.Value.Date.Add(New TimeSpan(.dt_hr_ini.Value.Hour, .dt_hr_ini.Value.Minute, 0))
            fecha_hora_termino = .dt_fecha_ter.Value.Date.Add(New TimeSpan(.dt_hr_ter.Value.Hour, .dt_hr_ter.Value.Minute, 0))
            fecha_hora_cierre = .dt_fecha_cierre.Value.Date.Add(New TimeSpan(.dt_hr_cierre.Value.Hour, .dt_hr_cierre.Value.Minute, 0))

            If .id_nodo_ot_select = "" Then
                resp = "Debe seleccionar un nodo del arbol" & Chr(13)
            End If

            If .txtNot.Text = "" Then
                resp = resp & "Debe ingresar un numero de orden de trabajo" & Chr(13)
            End If

            If .txtRecibidoPor.Text = "" Then
                resp = resp & "Debe ingresar el personal que recibe la orden" & Chr(13)
            End If

            If .txtSolicitadoPor.Text = "" Then
                resp = resp & "Debe ingresar el personal que solicita la orden" & Chr(13)
            End If

            If .text_des_falla.Text = "" Then
                resp = resp & "Debe ingresar una descripción breve" & Chr(13)
            End If

            If .txtCerradoPor.Text = "" Then
                resp = resp & "Debe ingresar la persona que cierra la orden de trabajo" & Chr(13)
            End If

            If fecha_hora_inicio > fecha_hora_termino Then
                resp = resp & "La fecha de inicio no puede ser mayor a la fecha de termino" & Chr(13)
            End If

            If fecha_hora_recepcion > fecha_hora_cierre Then
                resp = resp & "La fecha de recepcion no puede ser mayor a la fecha de cierre" & Chr(13)
            End If

            If Utilitarios.SafeDouble(.txtDuracionOt.Text, 0.0) <= 0 Then
                resp = resp & "El tiempo de duración debe ser mayor a cero" & Chr(13)
            End If

            With frm_OT.grillaPersonalOt
                For i = 0 To .RowCount - 1
                    If .Rows(i).IsNewRow Then Continue For
                    If .Rows(i).Cells(0).Value Is Nothing OrElse IsDBNull(.Rows(i).Cells(0).Value) OrElse String.IsNullOrWhiteSpace(.Rows(i).Cells(0).Value.ToString()) Then
                        resp = resp & "Debe ingresar una persona en la fila :" & i + 1 & Chr(13)
                    End If
                Next
            End With
        End With

        Return resp
    End Function

    Public Sub infOt(ByVal nodo_padre As String, ByVal num_ot As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByVal estado As String, ByVal detencion As String, ByRef opcion As Integer, ByVal tipo_trabajo As String, ByVal tipo_detencion As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        If num_ot = "" Then
            num_ot = "0"
        End If
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_OT_2", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim idNodoPadreInf As Integer = Utilitarios.SafeInt(nodo_padre, 1)
                If idNodoPadreInf <= 0 Then idNodoPadreInf = 1
                Dim p_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", idNodoPadreInf)
                Dim p_num_ot As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@num_ot", Utilitarios.SafeInt(num_ot, 0))

                ' Rango corregido para abarcar todo el día
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_inicio_ot", Utilitarios.SafeSqlDateStart(fecha_inicio))
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_fin_ot", Utilitarios.SafeSqlDateEnd(fecha_fin))

                Dim p_estado As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@estado", If(estado, String.Empty))
                Dim p_detencion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@detencion", If(detencion, String.Empty))
                Dim p_opcion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@opcion", opcion)
                Dim p_tipo_trabajo As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_trabajo", If(tipo_trabajo, String.Empty))
                Dim p_tipo_detencion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_detencion", If(tipo_detencion, String.Empty))

                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe OT")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub infOtHistorico(ByVal nodo_padre As String, ByVal num_ot As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByVal estado As String, ByVal detencion As String, ByRef opcion As Integer, ByVal tipo_trabajo As String, ByVal tipo_detencion As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        If num_ot = "" Then
            num_ot = "0"
        End If
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_OT_HISTORICO", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim idNodoPadreInf As Integer = Utilitarios.SafeInt(nodo_padre, 1)
                If idNodoPadreInf <= 0 Then idNodoPadreInf = 1
                Dim p_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", idNodoPadreInf)
                Dim p_num_ot As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@num_ot", Utilitarios.SafeInt(num_ot, 0))

                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_inicio_ot", Utilitarios.SafeSqlDateStart(fecha_inicio))
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_fin_ot", Utilitarios.SafeSqlDateEnd(fecha_fin))

                Dim p_estado As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@estado", If(estado, String.Empty))
                Dim p_detencion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@detencion", If(detencion, String.Empty))
                Dim p_opcion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@opcion", opcion)
                Dim p_tipo_trabajo As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_trabajo", If(tipo_trabajo, String.Empty))
                Dim p_tipo_detencion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_detencion", If(tipo_detencion, String.Empty))

                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe OT Historico")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene todas las órdenes de trabajo recursivas bajo un nodo padre específico (activas e históricas),
    ''' retornando idnodo, desc_nodo, nodo_padre y estado para resolución precisa de máquinas y componentes.
    ''' </summary>
    Public Sub infOtConNodos(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DT As DataTable)
        If DT Is Nothing Then DT = New DataTable()
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Dim sql As String = _
                "WITH NODOS AS (" & vbCrLf & _
                "    SELECT n.idnodo, n.nodo_padre, n.desc_nodo, 0 AS nivel_rel" & vbCrLf & _
                "    FROM nodo n WHERE n.idnodo = @nodo_padre" & vbCrLf & _
                "    UNION ALL" & vbCrLf & _
                "    SELECT n.idnodo, n.nodo_padre, n.desc_nodo, nds.nivel_rel + 1" & vbCrLf & _
                "    FROM nodo n INNER JOIN NODOS nds ON n.nodo_padre = nds.idnodo" & vbCrLf & _
                ")" & vbCrLf & _
                "SELECT ot.num_ot, ot.idnodo, nd.desc_nodo, nd.nodo_padre, ot.estado, ot.fecha_inicio_ot" & vbCrLf & _
                "FROM NODOS nds" & vbCrLf & _
                "INNER JOIN orden_trabajo ot ON nds.idnodo = ot.idnodo" & vbCrLf & _
                "INNER JOIN nodo nd ON ot.idnodo = nd.idnodo" & vbCrLf & _
                "WHERE ot.fecha_inicio_ot BETWEEN @fecha_inicio AND @fecha_fin" & vbCrLf & _
                "UNION ALL" & vbCrLf & _
                "SELECT ot.num_ot, ot.idnodo, nd.desc_nodo, nd.nodo_padre, ot.estado, ot.fecha_inicio_ot" & vbCrLf & _
                "FROM NODOS nds" & vbCrLf & _
                "INNER JOIN orden_trabajo_historico ot ON nds.idnodo = ot.idnodo" & vbCrLf & _
                "INNER JOIN nodo nd ON ot.idnodo = nd.idnodo" & vbCrLf & _
                "WHERE ot.fecha_inicio_ot BETWEEN @fecha_inicio AND @fecha_fin"

            Using cmd As New SqlCommand(sql, cnx)
                cmd.CommandTimeout = 60
                Dim idNodoPadreInt As Integer = Utilitarios.SafeInt(id_nodo_padre, 1)
                If idNodoPadreInt <= 0 Then idNodoPadreInt = 1
                cmd.Parameters.AddWithValue("@nodo_padre", idNodoPadreInt)
                Utilitarios.AgregarParametroFecha(cmd, "@fecha_inicio", Utilitarios.SafeSqlDateStart(fecha_inicio))
                Utilitarios.AgregarParametroFecha(cmd, "@fecha_fin", Utilitarios.SafeSqlDateEnd(fecha_fin))
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(DT)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe OT Con Nodos")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub infOtResRecibidaPor(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_OT_PENDIENTES_X_RECEPCION", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure

                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_inicio", Utilitarios.SafeSqlDateStart(fecha_inicio))
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_fin", Utilitarios.SafeSqlDateEnd(fecha_fin))
                Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", Utilitarios.SafeInt(id_nodo_padre, 1))

                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe OT Resumen Recibida Por")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub infOtResCerradaPorTecnico(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_OT_CERRADA_X_TECNICO", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure

                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_inicio", Utilitarios.SafeSqlDateStart(fecha_inicio))
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_fin", Utilitarios.SafeSqlDateEnd(fecha_fin))
                Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", Utilitarios.SafeInt(id_nodo_padre, 1))

                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe OT Resumen Cerrada Por Técnico")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub infOtResPorDia(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_OT_X_DIA", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure

                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_inicio", Utilitarios.SafeSqlDateStart(fecha_inicio))
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_fin", Utilitarios.SafeSqlDateEnd(fecha_fin))
                Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", Utilitarios.SafeInt(id_nodo_padre, 1))

                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe OT Resumen Por Día")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub infOtResPorMes(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_OT_X_MES", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure

                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_inicio", Utilitarios.SafeSqlDateStart(fecha_inicio))
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_fin", Utilitarios.SafeSqlDateEnd(fecha_fin))
                Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", Utilitarios.SafeInt(id_nodo_padre, 1))

                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe OT Resumen Por Mes")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub infOtResPorTurno(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_OT_X_TURNO", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure

                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_inicio", Utilitarios.SafeSqlDateStart(fecha_inicio))
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_fin", Utilitarios.SafeSqlDateEnd(fecha_fin))
                Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", Utilitarios.SafeInt(id_nodo_padre, 1))

                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe OT Resumen Por Turno")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub infOtPorTipoFalla(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_OT_X_TIPO_FALLA", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure

                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_inicio", Utilitarios.SafeSqlDateStart(fecha_inicio))
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_fin", Utilitarios.SafeSqlDateEnd(fecha_fin))
                Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", Utilitarios.SafeInt(id_nodo_padre, 1))

                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe OT Por Tipo Falla")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub infOtPorEstado(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_OT_X_ESTADO", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure

                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_inicio", Utilitarios.SafeSqlDateStart(fecha_inicio))
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_fin", Utilitarios.SafeSqlDateEnd(fecha_fin))
                Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", Utilitarios.SafeInt(id_nodo_padre, 1))

                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe OT Por Estado")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Function opcion_inf_ot() As Integer
        Dim opcion As Integer = 0

        With FrmInfOT
            If .opcNumOt.Checked = True Then
                'Filtro Por N° de orden de trabajo
                opcion = 1
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked And .chkPendientes.Checked And .chkConDetencion.Checked = False And .chkTipoDetencion.Checked = False And .chkTipoTrabajo.Checked = False And .chkNulas.Checked = False Then
                'Filtro por rango de fechas y pendientes
                opcion = 2
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked = True And .chkConDetencion.Checked And .chkPendientes.Checked = False And .chkTipoDetencion.Checked = False And .chkTipoTrabajo.Checked = False And .chkNulas.Checked = False Then
                'Filtro por rango de fechas y con detencion
                opcion = 3
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked And .chkTodasFechas.Checked And .chkConDetencion.Checked = False And .chkNulas.Checked = False And .chkPendientes.Checked = False And .chkTipoDetencion.Checked = False And .chkTipoTrabajo.Checked = False And .chkFiltroPlanta.Checked = False Then
                'Filtro solo por rango de fechas
                opcion = 4
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked = True And .estado_ot = "abierta" And .detencion = "SI" And .chkTipoTrabajo.Checked = False And .chkTipoDetencion.Checked = False Then
                'Filtro por rango de fechas, ordenes pendientes y con detencion
                opcion = 5
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked = True And .chkTipoTrabajo.Checked = True And .cmbTipoTrabajoInfOt.Text <> "" And .chkPendientes.Checked = False And .chkConDetencion.Checked = False And .chkTipoDetencion.Checked = False Then
                'Filtro por rango de fechas y por tipo de trabajo
                opcion = 6
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked = True And .chkTipoDetencion.Checked = True And .estado_ot = "" And .detencion = "" Then
                'filtro por rango de fechas y por tipo de detencion (correctiva, operativa, preventiva)
                opcion = 7
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked = True And .chkPendientes.Checked = True And .chkTipoTrabajo.Checked = True And .chkConDetencion.Checked = False Then
                'Filtro por rango de fechas, ordenes pendientes y por tipo de trabajo (mecanico, electrico, etc)
                opcion = 8
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked = True And .chkPendientes.Checked = True And .chkTipoTrabajo.Checked = True And .chkConDetencion.Checked = True Then
                'Filtro por rango de fechas, ordenes pendientes, tipo de trabajo (mecanico, electrico, etc) y con detencion
                opcion = 9
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked = True And .estado_ot <> "" And .chkTipoDetencion.Checked = True And .detencion = "" Then
                'Filtro por rango de fechas, ordenes pendientes, tipo de detencion (correctiva, operativa, preventiva)
                opcion = 10
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked = True And .estado_ot <> "" And .chkTipoDetencion.Checked = True And .detencion <> "" Then
                'Filtro por rango de fechas, ordenes pendientes, tipo de detencion (correctiva, operativa, preventiva) y con detencion
                opcion = 11
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked = True And .chkNulas.Checked = True Then
                'Filtro por rango de fechas y ordenes anuladas
                opcion = 12
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked And .chkTipoDetencion.Checked And .chkConDetencion.Checked And .chkNulas.Checked = False And .chkPendientes.Checked = False And .chkTipoTrabajo.Checked = False Then
                'Filtro por rango de fechas, tipo de detencion (correctiva, operativa, preventiva) y con detencion
                opcion = 13
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked And .chkTipoTrabajo.Checked And .chkTipoDetencion.Checked And .chkConDetencion.Checked And .chkNulas.Checked = False And .chkPendientes.Checked = False Then
                'Filtro por rango de fechas, tipo de detencion (correctiva, operativa, preventiva), con detencion y por tipo de trabajo (mecanica,electrica,etc)
                opcion = 14
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked And .chkTipoTrabajo.Checked And .chkTipoDetencion.Checked = False And .chkConDetencion.Checked And .chkNulas.Checked = False And .chkPendientes.Checked = False Then
                'Filtro por rango de fechas, con detencion y por tipo de trabajo (mecanica,electrica,etc)
                opcion = 15
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked And .chkTodasFechas.Checked And .chkFiltroPlanta.Checked And .chkConDetencion.Checked = False And .chkNulas.Checked = False And .chkPendientes.Checked = False And .chkTipoDetencion.Checked = False And .chkTipoTrabajo.Checked = False Then
                opcion = 4
                Return opcion
                Exit Function
            End If

            If .opcFechasOt.Checked And .chkTodasFechas.Checked And .chkFiltroPlanta.Checked And .chkConDetencion.Checked = False And .chkNulas.Checked = False And .chkPendientes.Checked And .chkTipoDetencion.Checked = False And .chkTipoTrabajo.Checked = False Then
                opcion = 2
                Return opcion
                Exit Function
            End If

        End With
        If opcion = 0 Then opcion = 4
        Return opcion
    End Function

    Public Sub AnularOt(ByVal N_OT As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ANULAR_OT", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim nOtInt As Integer = 0
                If Not Utilitarios.TrySafeInt(N_OT, nOtInt) Then
                    cod_resp = 0
                    resp = "El número de OT debe ser un valor numérico válido."
                    Exit Sub
                End If
                Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", nOtInt)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Anular OT")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Public Sub infPersonalOt(ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_PERSONAL_OT", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure

                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_inicio_ot", Utilitarios.SafeSqlDateStart(fecha_inicio))
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_fin_ot", Utilitarios.SafeSqlDateEnd(fecha_fin))

                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Personal OT")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


    Private Sub LlenarHojaInfOt(ByVal worksheet As Excel.Worksheet, ByVal grilla As DataGridView, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByVal planta As String)
        Utilitarios.ExcelCelda(worksheet, 5, 6).NumberFormat = "@"
        Utilitarios.ExcelCelda(worksheet, 6, 6).NumberFormat = "@"
        worksheet.Cells(5, 6) = fecha_inicio.ToString("dd-MM-yyyy")
        worksheet.Cells(6, 6) = fecha_fin.ToString("dd-MM-yyyy")

        If Not String.IsNullOrEmpty(planta) Then
            Dim encabezadoActual As String = Convert.ToString(Utilitarios.ExcelCelda(worksheet, 1, 4).Value)
            worksheet.Cells(1, 4) = encabezadoActual & " " & planta
        End If

        Dim totalFilas As Integer = grilla.RowCount
        If totalFilas <= 0 Then Exit Sub

        If totalFilas > 1 Then
            Dim rangoInsert As Excel.Range = worksheet.Range("A11:O" & (9 + totalFilas).ToString())
            rangoInsert.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
        End If

        Dim datos(totalFilas - 1, 14) As Object
        Dim maxCols As Integer = Math.Min(15, grilla.ColumnCount)
        For i As Integer = 0 To totalFilas - 1
            Dim row As DataGridViewRow = grilla.Rows(i)
            For c As Integer = 0 To maxCols - 1
                Dim val As Object = row.Cells(c).Value
                If TypeOf val Is DateTime Then
                    datos(i, c) = DirectCast(val, DateTime).ToString("dd-MM-yyyy HH:mm")
                Else
                    datos(i, c) = If(val Is Nothing OrElse IsDBNull(val), "", val)
                End If
            Next
        Next

        Dim filaFin As Integer = 10 + totalFilas - 1
        Dim rangoDatos As Excel.Range = worksheet.Range("A10:O" & filaFin.ToString())
        rangoDatos.Value2 = datos
        Try
            rangoDatos.WrapText = True
            rangoDatos.VerticalAlignment = Excel.XlVAlign.xlVAlignTop
            rangoDatos.Font.Color = System.Drawing.ColorTranslator.ToOle(Utilitarios.ColorTextoPrincipal)
        Catch
        End Try

        Dim rangoBordes As Excel.Range = worksheet.Range("A10:O" & (filaFin + 1).ToString())
        rangoBordes.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        Try
            rangoBordes.Borders.Color = System.Drawing.ColorTranslator.ToOle(Utilitarios.ColorBordeGrilla)
        Catch
        End Try

        ' Ajustar configuración horizontal para que exportaciones extensas ocupen 100% del ancho de página sin encoger verticalmente
        Try
            Dim ps As Excel.PageSetup = worksheet.PageSetup
            ps.Orientation = Excel.XlPageOrientation.xlLandscape
            ps.PaperSize = Excel.XlPaperSize.xlPaperLetter
            ps.Zoom = False
            ps.FitToPagesWide = 1
            ps.FitToPagesTall = False
            ps.CenterHorizontally = True
            ps.PrintTitleRows = "$1:$9"
        Catch
        End Try
    End Sub

    Public Sub exportarInfOtExcel(ByRef grilla As DataGridView, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByVal planta As String)
        If grilla Is Nothing OrElse grilla.RowCount = 0 Then
            MsgBox("No hay registros en la grilla para exportar a Excel.", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet As Excel.Worksheet = Nothing

        Try
            excelApp = New Excel.Application
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, True)
            workbook = Utilitarios.CrearLibroDesdePlantilla(excelApp, "inf_ot.xls")
            worksheet = CType(workbook.Sheets(1), Excel.Worksheet)
            worksheet.Visible = Excel.XlSheetVisibility.xlSheetVisible
            worksheet.Activate()

            LlenarHojaInfOt(worksheet, grilla, fecha_inicio, fecha_fin, planta)

            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Excel")
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            Dim subtitulo As String = "Período: " & fecha_inicio.ToString("dd-MM-yyyy") & " al " & fecha_fin.ToString("dd-MM-yyyy")
            If Not String.IsNullOrWhiteSpace(planta) Then subtitulo &= " | " & planta
            If Not Utilitarios.ExportarGrillaAExcelNativo(grilla, "Informe_OT", "INFORME DE ÓRDENES DE TRABAJO (OT)", subtitulo) AndAlso
               Not Utilitarios.UltimaExportacionCancelada Then
                RegistroErrores.MostrarYRegistrar(ex, "Exportar Informe OT a Excel")
            End If
        End Try
    End Sub


    Public Sub exportarInfOtPDF(ByRef grilla As DataGridView, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, Optional ByVal planta As String = "")
        If grilla Is Nothing OrElse grilla.RowCount = 0 Then
            MsgBox("No hay registros en la grilla para exportar a PDF.", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Dim rutaPdf As String = Utilitarios.SolicitarRutaGuardadoPdf("Informe_OT")
        If String.IsNullOrEmpty(rutaPdf) Then
            Exit Sub
        End If

        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet As Excel.Worksheet = Nothing

        Try
            excelApp = New Excel.Application
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, True)
            workbook = Utilitarios.CrearLibroDesdePlantilla(excelApp, "inf_ot.xls")
            worksheet = CType(workbook.Sheets(1), Excel.Worksheet)
            worksheet.Visible = Excel.XlSheetVisibility.xlSheetVisible
            worksheet.Activate()

            LlenarHojaInfOt(worksheet, grilla, fecha_inicio, fecha_fin, planta)

            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            Utilitarios.ImprimirLibroAPdfWindows(excelApp, workbook, rutaPdf, "Informe_OT")
        Catch ex As Exception
            ' Respaldo directo con iTextSharp si falla la automatización de Excel
            Try
                Dim dt As New DataTable("InformeOT")
                For j As Integer = 0 To grilla.ColumnCount - 1
                    If grilla.Columns(j).Visible Then
                        Dim dc As New DataColumn("Col_" & j.ToString(), GetType(String))
                        dc.Caption = grilla.Columns(j).HeaderText
                        dt.Columns.Add(dc)
                    End If
                Next
                For i As Integer = 0 To grilla.RowCount - 1
                    If grilla.Rows(i).IsNewRow Then Continue For
                    Dim dr As DataRow = dt.NewRow()
                    Dim colIdx As Integer = 0
                    For j As Integer = 0 To grilla.ColumnCount - 1
                        If grilla.Columns(j).Visible Then
                            Dim val As Object = grilla.Rows(i).Cells(j).Value
                            dr(colIdx) = If(val Is Nothing OrElse IsDBNull(val), "", val.ToString())
                            colIdx += 1
                        End If
                    Next
                    dt.Rows.Add(dr)
                Next
                Dim rpt As New InfOt()
                rpt.Titulo = "INFORME DE ÓRDENES DE TRABAJO (OT)"
                rpt.Subtitulo = "Periodo: " & fecha_inicio.ToString("dd-MM-yyyy") & " al " & fecha_fin.ToString("dd-MM-yyyy")
                rpt.Planta = planta
                rpt.SetDataSource(dt)
                rpt.ExportarPDF(rutaPdf)
                If MessageBox.Show("Archivo PDF guardado exitosamente en:" & Environment.NewLine & rutaPdf & Environment.NewLine & Environment.NewLine & "¿Desea abrir el documento PDF ahora?", "Exportación PDF Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    Utilitarios.AbrirDocumento(rutaPdf)
                End If
            Catch ex2 As Exception
                RegistroErrores.MostrarYRegistrar(ex2, "Exportar Informe OT PDF")
            End Try
        Finally
            Utilitarios.LiberarExcel(workbook, excelApp)
        End Try
    End Sub


    Public Sub CrgDetalleResumenOt(ByVal personal As String, ByVal fecha_inicio As DateTime, ByVal fecha_termino As DateTime, ByVal opcion As Integer, ByVal tipo_falla As String, ByVal turno As String, ByVal fecha As DateTime, ByVal estado As String, ByVal nodo_padre As String, ByRef DS As DataSet)
        If opcion <= 0 Then Exit Sub
        If DS Is Nothing Then DS = New DataSet()
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_DETALLE_RESUMEN_OT", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.SelectCommand.Parameters.AddWithValue("@personal", If(personal, String.Empty).Trim())

                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_inicio", Utilitarios.SafeSqlDateStart(fecha_inicio))
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_termino", Utilitarios.SafeSqlDateEnd(fecha_termino))
                DA.SelectCommand.Parameters.AddWithValue("@opcion", opcion)
                DA.SelectCommand.Parameters.AddWithValue("@tipo_falla", If(tipo_falla, String.Empty).Trim())
                DA.SelectCommand.Parameters.AddWithValue("@turno", If(turno, String.Empty).Trim())

                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha", Utilitarios.SafeSqlDateStart(fecha))
                DA.SelectCommand.Parameters.AddWithValue("@estado", If(estado, String.Empty).Trim())
                Dim idNodoPadre As Integer = Utilitarios.SafeInt(nodo_padre, 1)
                If idNodoPadre <= 0 Then idNodoPadre = 1
                DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", idNodoPadre)

                DA.Fill(DS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Detalle Resumen OT")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub


End Class
