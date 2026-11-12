Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class OT

    Public Sub IngOtAbierta(ByVal N_OT As String, ByVal id_nodo As String, ByVal id_sintoma As String, ByVal id_modo_falla As String, ByVal fecha_r As DateTime, ByVal hr_r As DateTime, ByVal fecha_ini As DateTime, ByVal hr_ini As DateTime, ByVal tipo_det As String, ByVal detencion As String, ByVal desc_falla As String, ByVal solicitado_por As String, ByVal recibido_por As String, ByVal tipo_trab As String, ByVal sesion As String, ByVal desc_tecnica As String, ByVal mant_interna As Boolean, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_OT_ABIERTA", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@n_ot", CInt(N_OT))
            Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
            Dim p_tipo_det As SqlParameter = com.Parameters.AddWithValue("@id_tipo", tipo_det)
            Dim p_tipo_trab As SqlParameter = com.Parameters.AddWithValue("@tipo_trabajo", tipo_trab)
            Dim p_id_sintoma As SqlParameter = com.Parameters.AddWithValue("@id_sintoma", id_sintoma)
            Dim p_id_modo_falla As SqlParameter = com.Parameters.AddWithValue("@id_modo_falla", id_modo_falla)
            Dim p_fecha_r As SqlParameter = com.Parameters.AddWithValue("@fecha_recep", Format(fecha_r, "MM/dd/yyyy"))
            Dim p_hr_r As SqlParameter = com.Parameters.AddWithValue("@hr_recep", Format(hr_r, "HH:mm:ss"))
            Dim p_fecha_ini As SqlParameter = com.Parameters.AddWithValue("@fecha_ini", Format(fecha_ini, "MM/dd/yyyy"))
            Dim p_hr_ini As SqlParameter = com.Parameters.AddWithValue("@hr_ini", Format(hr_ini, "HH:mm:ss"))
            Dim p_detencion As SqlParameter = com.Parameters.AddWithValue("@detencion", detencion)
            Dim p_desc_falla As SqlParameter = com.Parameters.AddWithValue("@desc_breve", desc_falla)
            Dim p_solitado_por As SqlParameter = com.Parameters.AddWithValue("@per_solicita", solicitado_por)
            Dim p_recibido_por As SqlParameter = com.Parameters.AddWithValue("@per_recepcion", recibido_por)
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
            Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
            Dim p_desc_tecnica As SqlParameter = com.Parameters.AddWithValue("@desc_tecnica", desc_tecnica)
            Dim p_mant_interna As SqlParameter = com.Parameters.AddWithValue("@mant_interna", mant_interna)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub IngOtCerrada(ByVal N_OT As String, ByVal id_nodo As String, ByVal id_sintoma As String, ByVal id_modo_falla As String, ByVal fecha_r As DateTime, ByVal hr_r As DateTime, ByVal fecha_ini As DateTime, ByVal hr_ini As DateTime, ByVal fecha_fin As DateTime, ByVal hora_fin As DateTime, ByVal fecha_entrega As DateTime, ByVal hora_entrega As DateTime, ByVal duracion As String, ByVal tipo_det As String, ByVal detencion As String, ByVal desc_falla As String, ByVal desc_tecnica As String, ByVal solicitado_por As String, ByVal recibido_por As String, ByVal cerrada_por As String, ByVal tipo_trab As String, ByVal sesion As String, ByVal estado_ot As String, ByVal mant_interna As Boolean, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_OT_CERRADA", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@n_ot", CInt(N_OT))
            Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
            Dim p_tipo_det As SqlParameter = com.Parameters.AddWithValue("@id_tipo", tipo_det)
            Dim p_tipo_trab As SqlParameter = com.Parameters.AddWithValue("@tipo_trab", tipo_trab)
            Dim p_id_sintoma As SqlParameter = com.Parameters.AddWithValue("@id_sintoma", id_sintoma)
            Dim p_id_modo_falla As SqlParameter = com.Parameters.AddWithValue("@id_modo_falla", id_modo_falla)
            Dim p_fecha_r As SqlParameter = com.Parameters.AddWithValue("@fecha_recep", Format(fecha_r, "MM/dd/yyyy"))
            Dim p_hr_r As SqlParameter = com.Parameters.AddWithValue("@hora_recep", Format(hr_r, "HH:mm:ss"))
            Dim p_fecha_ini As SqlParameter = com.Parameters.AddWithValue("@fecha_ini_ot", Format(fecha_ini, "MM/dd/yyyy"))
            Dim p_hr_ini As SqlParameter = com.Parameters.AddWithValue("@hora_ini_ot", Format(hr_ini, "HH:mm:ss"))
            Dim p_fecha_fin As SqlParameter = com.Parameters.AddWithValue("@fecha_fin_ot", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_hr_fin As SqlParameter = com.Parameters.AddWithValue("@hora_fin_ot", Format(hora_fin, "HH:mm:ss"))
            Dim p_fecha_ent As SqlParameter = com.Parameters.AddWithValue("@fecha_entrega", Format(fecha_entrega, "MM/dd/yyyy"))
            Dim p_hr_ent As SqlParameter = com.Parameters.AddWithValue("@hora_entrega", Format(hora_entrega, "HH:mm:ss"))
            Dim p_detencion As SqlParameter = com.Parameters.AddWithValue("@detencion", detencion)
            Dim p_desc_falla As SqlParameter = com.Parameters.AddWithValue("@desc_breve", desc_falla)
            Dim p_desc_tecnica As SqlParameter = com.Parameters.AddWithValue("@desc_tecnica", desc_tecnica)
            Dim p_tiempo_ot As SqlParameter = com.Parameters.AddWithValue("@tiempo_det", CDbl(duracion))
            Dim p_solitado_por As SqlParameter = com.Parameters.AddWithValue("@per_solicita", solicitado_por)
            Dim p_recibido_por As SqlParameter = com.Parameters.AddWithValue("@per_recepcion", recibido_por)
            Dim p_cerrada_por As SqlParameter = com.Parameters.AddWithValue("@per_cierre", cerrada_por)
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
            Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
            Dim p_estado_ot As SqlParameter = com.Parameters.AddWithValue("@estado_ot", estado_ot)
            Dim p_mant_interna As SqlParameter = com.Parameters.AddWithValue("@mant_interna", mant_interna)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub IngPersonalOt(ByVal rut As String, ByVal id_ot As String, ByRef obs_personal As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            If obs_personal = "" Then
                obs_personal = ""
            End If
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_PERSONAL_OT", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_num_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", CInt(id_ot))
            Dim p_rut_per As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
            Dim p_obs_per As SqlParameter = com.Parameters.AddWithValue("@obs_personal", obs_personal)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub IngOtExterna(ByVal num_ot As String, ByVal num_ot_ext As String, ByVal obs_ot_ext As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_OT_EXTERNA_OT", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_num_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", CInt(num_ot))
            Dim p_num_ot_ext As SqlParameter = com.Parameters.AddWithValue("@num_ot_ext", CInt(num_ot_ext))
            Dim p_obs_ot_ext As SqlParameter = com.Parameters.AddWithValue("@obs_ot_ext", obs_ot_ext)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub IngInsumosOt(ByVal num_ot As String, ByVal id_insumo As String, ByVal cantidad As String, ByVal unid_medida As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_INSUMOS_OT", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_num_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", CInt(num_ot))
            Dim p_id_insumo As SqlParameter = com.Parameters.AddWithValue("@idinsumo", CInt(id_insumo))
            Dim p_cantidad As SqlParameter = com.Parameters.AddWithValue("@cantidad", CInt(cantidad))
            Dim p_unid_medida As SqlParameter = com.Parameters.AddWithValue("@unid_medida", unid_medida)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub UpdOtAbierta(ByVal N_OT As String, ByVal id_nodo As String, ByVal id_sintoma As String, ByVal id_modo_falla As String, ByVal fecha_r As DateTime, ByVal hr_r As DateTime, ByVal fecha_ini As DateTime, ByVal hr_ini As DateTime, ByVal tipo_det As String, ByVal detencion As String, ByVal desc_falla As String, ByVal solicitado_por As String, ByVal recibido_por As String, ByVal tipo_trab As String, ByVal sesion As String, ByVal mant_interna As Boolean, ByVal desc_tecnica As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_OT_ABIERTA", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@n_ot", CInt(N_OT))
            Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
            Dim p_tipo_det As SqlParameter = com.Parameters.AddWithValue("@id_tipo", tipo_det)
            Dim p_tipo_trab As SqlParameter = com.Parameters.AddWithValue("@tipo_trabajo", tipo_trab)
            Dim p_id_sintoma As SqlParameter = com.Parameters.AddWithValue("@id_sintoma", id_sintoma)
            Dim p_id_modo_falla As SqlParameter = com.Parameters.AddWithValue("@id_modo_falla", id_modo_falla)
            Dim p_fecha_r As SqlParameter = com.Parameters.AddWithValue("@fecha_recep", Format(fecha_r, "MM/dd/yyyy"))
            Dim p_hr_r As SqlParameter = com.Parameters.AddWithValue("@hr_recep", Format(hr_r, "HH:mm:ss"))
            Dim p_fecha_ini As SqlParameter = com.Parameters.AddWithValue("@fecha_ini", Format(fecha_ini, "MM/dd/yyyy"))
            Dim p_hr_ini As SqlParameter = com.Parameters.AddWithValue("@hr_ini", Format(hr_ini, "HH:mm:ss"))
            Dim p_detencion As SqlParameter = com.Parameters.AddWithValue("@detencion", detencion)
            Dim p_desc_falla As SqlParameter = com.Parameters.AddWithValue("@desc_breve", desc_falla)
            Dim p_solitado_por As SqlParameter = com.Parameters.AddWithValue("@per_solicita", solicitado_por)
            Dim p_recibido_por As SqlParameter = com.Parameters.AddWithValue("@per_recepcion", recibido_por)
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
            Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
            Dim p_desc_tecnica As SqlParameter = com.Parameters.AddWithValue("@desc_tecnica", desc_tecnica)
            Dim p_mant_interna As SqlParameter = com.Parameters.AddWithValue("@mant_interna", mant_interna)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub UpdOtCerrada(ByVal N_OT As String, ByVal id_nodo As String, ByVal id_sintoma As String, ByVal id_modo_falla As String, ByVal fecha_r As DateTime, ByVal hr_r As DateTime, ByVal fecha_ini As DateTime, ByVal hr_ini As DateTime, ByVal fecha_fin As DateTime, ByVal hora_fin As DateTime, ByVal fecha_entrega As DateTime, ByVal hora_entrega As DateTime, ByVal duracion As String, ByVal tipo_det As String, ByVal detencion As String, ByVal desc_falla As String, ByVal desc_tecnica As String, ByVal solicitado_por As String, ByVal recibido_por As String, ByVal cerrada_por As String, ByVal tipo_trab As String, ByVal sesion As String, ByVal estado_ot As String, ByVal mant_interna As Boolean, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_OT_CERRADA", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@n_ot", CInt(N_OT))
            Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
            Dim p_tipo_det As SqlParameter = com.Parameters.AddWithValue("@id_tipo", tipo_det)
            Dim p_tipo_trab As SqlParameter = com.Parameters.AddWithValue("@tipo_trabajo", tipo_trab)
            Dim p_id_sintoma As SqlParameter = com.Parameters.AddWithValue("@id_sintoma", id_sintoma)
            Dim p_id_modo_falla As SqlParameter = com.Parameters.AddWithValue("@id_modo_falla", id_modo_falla)
            Dim p_fecha_r As SqlParameter = com.Parameters.AddWithValue("@fecha_recep", Format(fecha_r, "MM/dd/yyyy"))
            Dim p_hr_r As SqlParameter = com.Parameters.AddWithValue("@hora_recep", Format(hr_r, "HH:mm:ss"))
            Dim p_fecha_ini As SqlParameter = com.Parameters.AddWithValue("@fecha_ini_ot", Format(fecha_ini, "MM/dd/yyyy"))
            Dim p_hr_ini As SqlParameter = com.Parameters.AddWithValue("@hora_ini_ot", Format(hr_ini, "HH:mm:ss"))
            Dim p_fecha_fin As SqlParameter = com.Parameters.AddWithValue("@fecha_fin_ot", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_hr_fin As SqlParameter = com.Parameters.AddWithValue("@hora_fin_ot", Format(hora_fin, "HH:mm:ss"))
            Dim p_fecha_ent As SqlParameter = com.Parameters.AddWithValue("@fecha_entrega", Format(fecha_entrega, "MM/dd/yyyy"))
            Dim p_hr_ent As SqlParameter = com.Parameters.AddWithValue("@hora_entrega", Format(hora_entrega, "HH:mm:ss"))
            Dim p_detencion As SqlParameter = com.Parameters.AddWithValue("@detencion", detencion)
            Dim p_desc_falla As SqlParameter = com.Parameters.AddWithValue("@desc_breve", desc_falla)
            Dim p_desc_tecnica As SqlParameter = com.Parameters.AddWithValue("@desc_tecnica", desc_tecnica)
            Dim p_tiempo_ot As SqlParameter = com.Parameters.AddWithValue("@tiempo_det", CDbl(duracion))
            Dim p_solitado_por As SqlParameter = com.Parameters.AddWithValue("@per_solicita", solicitado_por)
            Dim p_recibido_por As SqlParameter = com.Parameters.AddWithValue("@per_recepcion", recibido_por)
            Dim p_cerrada_por As SqlParameter = com.Parameters.AddWithValue("@per_cierre", cerrada_por)
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
            Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
            Dim p_estado_ot As SqlParameter = com.Parameters.AddWithValue("@estado_ot", estado_ot)
            Dim p_mant_interna As SqlParameter = com.Parameters.AddWithValue("@mant_interna", mant_interna)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub UpdPersonalOt(ByVal N_OT As String, ByVal rut As String, ByVal obs_personal As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_PERSONAL_OT", cnx)
            com.CommandType = CommandType.StoredProcedure
            If obs_personal Is Nothing Then
                obs_personal = ""
            End If
            Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", CInt(N_OT))
            Dim p_rut_per As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
            Dim p_obs_personal As SqlParameter = com.Parameters.AddWithValue("@obs_personal", obs_personal)

            Dim DR As SqlDataReader = com.ExecuteReader

            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub UpdInsumosOt(ByVal N_OT As String, ByVal id_insumo As String, ByVal cantidad As String, ByVal unid_medida As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_INSUMOS_OT", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", CInt(N_OT))
            Dim p_id_insumo As SqlParameter = com.Parameters.AddWithValue("@id_insumo", CInt(id_insumo))
            Dim p_cantidad As SqlParameter = com.Parameters.AddWithValue("@cantidad", CInt(cantidad))
            Dim p_unid_medida As SqlParameter = com.Parameters.AddWithValue("@unid_medida", unid_medida)

            Dim DR As SqlDataReader = com.ExecuteReader
            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub UpdOtExterna(ByVal N_OT As String, ByVal num_ot_ext As String, ByVal obs_ot_ext As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_OT_EXTERNA_OT", cnx)
            com.CommandType = CommandType.StoredProcedure
            If obs_ot_ext Is Nothing Then
                obs_ot_ext = ""
            End If
            Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", CInt(N_OT))
            Dim p_n_ot_ext As SqlParameter = com.Parameters.AddWithValue("@num_ot_ext", CInt(num_ot_ext))
            Dim p_obs_ot_ext As SqlParameter = com.Parameters.AddWithValue("@obs_ot_ext", obs_ot_ext)

            Dim DR As SqlDataReader = com.ExecuteReader
            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub CrgCmbDetencion(ByRef combo As ComboBox)
        With combo
            .Items.Add("SI")
            .Items.Add("NO")
            .Text = .Items(0)
        End With
    End Sub

    Public Sub CrgCmbTipoDet(ByRef combo As ComboBox)
        With combo
            .Items.Add("Mecánica")
            .Items.Add("Eléctrica")
            .Items.Add("Electrónica")
            .Items.Add("Soldadura")
            .Items.Add("Servicios Generales")
            .Text = .Items(0)
        End With
    End Sub

    Public Sub CrgOrdenTrabajo(ByVal num_ot As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_ORDEN_TRABAJO", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_num_ot As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@num_ot", CInt(num_ot))

            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub CrgPersonalOt(ByVal num_ot As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_PERSONAL_OT", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_num_ot As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@num_ot", CInt(num_ot))

            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub CrgOtExterna(ByVal num_ot As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_OT_EXTERNA_OT", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_num_ot As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@num_ot", CInt(num_ot))

            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub CrgInsumosOt(ByVal num_ot As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_INSUMOS_OT", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_num_ot As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@num_ot", CInt(num_ot))

            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
            .txtDescTrab.Clear()
            .txtCerradoPor.Clear()
            .txtBuscarNodo.Clear()
            .chkOtCierre.Checked = False
            .cmbEstadoOt.Text = .cmbEstadoOt.Items(0)
            .cmbEstadoOt.Enabled = False
            .chkOtMpInterna.Checked = False
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
                i = .grillaInsumosOt.RowCount - 1
                While .grillaInsumosOt.RowCount > 0
                    .grillaInsumosOt.Rows.Remove(.grillaInsumosOt.Rows(i))
                    i = i - 1
                End While
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
            If .id_nodo_ot_select <> "" Then
                Dim nodo_finded() As TreeNode = .arbol3.Nodes.Find(.id_nodo_ot_select, True)
                .arbol3.SelectedNode = nodo_finded(0)
                .arbol3.SelectedNode.BackColor = Color.White
                .arbol3.Nodes(0).Collapse()
                .id_nodo_ot_select = ""
                .nodo_anterior = ""
                .nodo_anterior2 = ""
            End If

            '------------------------------------------------------------------------------------------------------------
            .form_limpio = True
        End With
    End Sub

    Public Function BuscarNumOt(ByVal num_ot As String) As String
        Dim encontrado As Boolean = False
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_error As Integer = 0
        Dim resp As String = ""
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("BUSCAR_NUM_OT", cnx)
            com.CommandType = CommandType.StoredProcedure
            Dim p_num_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", CInt(num_ot))

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read Then
                If DR(0) = 1 Then
                    resp = DR(1)
                Else
                    resp = ""
                End If
            End If
            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
        Return resp
    End Function

    Public Sub DelOrdenTrabajo(ByVal N_OT As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("DEL_ORDEN_TRABAJO", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", CInt(N_OT))
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
            Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub DelPersonalOt(ByVal N_OT As String, ByVal rut As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("DEL_PERSONAL_OT", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", CInt(N_OT))
            Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub DelOtExterna(ByVal N_OT As String, ByVal num_ot_ext As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("DEL_OT_EXTERNA_OT", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", CInt(N_OT))
            Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@num_ot_ext", CInt(num_ot_ext))

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub DelInsumoOt(ByVal N_OT As String, ByVal id_insumo As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("DEL_INSUMO_OT", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", CInt(N_OT))
            Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@id_insumo", CInt(id_insumo))

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub autocompletar_personal(ByRef textbox As TextBox)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim coleccion As New AutoCompleteStringCollection
        Dim DST As New DataSet
        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("AUTOCOMPLETAR_PERSONAL", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            DA.Fill(DST)
            conexion.Desconectar(cnx)

            For i = 0 To DST.Tables(0).Rows.Count - 1
                coleccion.Add(DST.Tables(0).Rows(i).Item(1).ToString)
            Next

            textbox.AutoCompleteMode = AutoCompleteMode.Suggest
            textbox.AutoCompleteSource = AutoCompleteSource.CustomSource
            textbox.AutoCompleteCustomSource = coleccion

        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
            fecha_hora_recepcion = FormatDateTime(.dt_fecha_rec.Value, DateFormat.ShortDate) & " " & FormatDateTime(.dt_hr_rec.Value, DateFormat.ShortTime)
            fecha_hora_inicio = FormatDateTime(.dt_fecha_ini.Value, DateFormat.ShortDate) & " " & FormatDateTime(.dt_hr_ini.Value, DateFormat.ShortTime)
            fecha_hora_termino = FormatDateTime(.dt_fecha_ter.Value, DateFormat.ShortDate) & " " & FormatDateTime(.dt_hr_ter.Value, DateFormat.ShortTime)
            fecha_hora_cierre = FormatDateTime(.dt_fecha_cierre.Value, DateFormat.ShortDate) & " " & FormatDateTime(.dt_hr_cierre.Value, DateFormat.ShortTime)

            If .id_nodo_ot_select = "" Then
                resp = "Debe seleccionar un nodo del arbol" & Chr(13)
            End If

            If .txtNot.Text = "" Then
                resp = "Debe ingresar un numero de orden de trabajo" & Chr(13)
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

            If CDbl(.txtDuracionOt.Text) <= 0 Then
                resp = resp & "El tiempo de duración debe ser mayor a cero"
            End If

            With frm_OT.grillaPersonalOt
                For i = 0 To .RowCount - 1
                    If .Rows(i).Cells(0).Value.ToString = "" Then
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
            num_ot = 0
        End If

        If estado = "" Then
            estado = "cerrada"
        End If

        If detencion = "" Then
            detencion = "no"
        End If
        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_OT_2", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))
            Dim p_num_ot As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@num_ot", CInt(num_ot))
            Dim p_fecha_ini As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio_ot", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_fecha_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin_ot", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_estado As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@estado", estado)
            Dim p_detencion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@detencion", detencion)
            Dim p_opcion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@opcion", CInt(opcion))
            Dim p_tipo_trabajo As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_trabajo", tipo_trabajo)
            Dim p_tipo_detencion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_detencion", tipo_detencion)

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub infOtHistorico(ByVal nodo_padre As String, ByVal num_ot As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByVal estado As String, ByVal detencion As String, ByRef opcion As Integer, ByVal tipo_trabajo As String, ByVal tipo_detencion As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        If num_ot = "" Then
            num_ot = 0
        End If
        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_OT_HISTORICO", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))
            Dim p_num_ot As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@num_ot", CInt(num_ot))
            Dim p_fecha_ini As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio_ot", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_fecha_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin_ot", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_estado As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@estado", estado)
            Dim p_detencion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@detencion", detencion)
            Dim p_opcion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@opcion", CInt(opcion))
            Dim p_tipo_trabajo As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_trabajo", tipo_trabajo)
            Dim p_tipo_detencion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_detencion", tipo_detencion)

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub infOtResRecibidaPor(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_OT_PENDIENTES_X_RECEPCION", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_fecha_inicio As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_fecha_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(id_nodo_padre))

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub infOtResCerradaPorTecnico(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_OT_CERRADA_X_TECNICO", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_fecha_inicio As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_fecha_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(id_nodo_padre))

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub infOtResPorDia(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_OT_X_DIA", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_fecha_inicio As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_fecha_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(id_nodo_padre))

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub infOtResPorMes(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_OT_X_MES", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_fecha_inicio As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_fecha_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(id_nodo_padre))

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub infOtResPorTurno(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_OT_X_TURNO", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_fecha_inicio As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_fecha_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(id_nodo_padre))

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub infOtPorTipoFalla(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_OT_X_TIPO_FALLA", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_fecha_inicio As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_fecha_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(id_nodo_padre))

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub infOtPorEstado(ByVal id_nodo_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_OT_X_ESTADO", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_fecha_inicio As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_fecha_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(id_nodo_padre))

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
    End Function

    Public Sub AnularOt(ByVal N_OT As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ANULAR_OT", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_n_ot As SqlParameter = com.Parameters.AddWithValue("@num_ot", CInt(N_OT))

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub infPersonalOt(ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_PERSONAL_OT", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim p_fecha_ini As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio_ot", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_fecha_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin_ot", Format(fecha_fin, "MM/dd/yyyy"))

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub exportarInfOtExcel(ByRef grilla As DataGridView, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByVal planta As String)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet As Excel.Worksheet

        excelApp = New Excel.Application
        workbook = excelApp.Workbooks.Open(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_ot.xls")
        worksheet = workbook.Sheets(1)
        worksheet.Visible = Excel.XlSheetVisibility.xlSheetVisible
        worksheet.Activate()

        worksheet.Cells(5, 6) = FormatDateTime(fecha_inicio, DateFormat.ShortDate)
        worksheet.Cells(6, 6) = FormatDateTime(fecha_fin, DateFormat.ShortDate)
        worksheet.Cells(1, 4) = worksheet.Cells(1, 4).value & " " & planta

        Dim filaexcel As Integer = 10
        Dim col_excel As Integer = 1
        Dim rango As Excel.Range

        For i = 0 To grilla.RowCount - 1
            worksheet.Rows(filaexcel + 1).Insert()
            worksheet.Cells(filaexcel, 1) = grilla.Rows(i).Cells(0).Value   'N° OT
            worksheet.Cells(filaexcel, 2) = grilla.Rows(i).Cells(1).Value   'Seccion
            worksheet.Cells(filaexcel, 3) = grilla.Rows(i).Cells(2).Value   'Item
            worksheet.Cells(filaexcel, 4) = grilla.Rows(i).Cells(3).Value   'Fecha / Hora Inicio
            worksheet.Cells(filaexcel, 5) = grilla.Rows(i).Cells(4).Value   'Fecha / Hora Fin
            worksheet.Cells(filaexcel, 6) = grilla.Rows(i).Cells(5).Value   'Tiempo Det.(Hrs)
            worksheet.Cells(filaexcel, 7) = grilla.Rows(i).Cells(6).Value   'Detencion 
            worksheet.Cells(filaexcel, 8) = grilla.Rows(i).Cells(7).Value   'Descripcion Breve
            worksheet.Cells(filaexcel, 9) = grilla.Rows(i).Cells(8).Value   'Tipo Trabajo
            worksheet.Cells(filaexcel, 10) = grilla.Rows(i).Cells(9).Value  'Solicitado Por
            worksheet.Cells(filaexcel, 11) = grilla.Rows(i).Cells(10).Value  'Recibido Por
            worksheet.Cells(filaexcel, 12) = grilla.Rows(i).Cells(11).Value 'Cerrada Por
            worksheet.Cells(filaexcel, 13) = grilla.Rows(i).Cells(12).Value 'Personal 1
            worksheet.Cells(filaexcel, 14) = grilla.Rows(i).Cells(13).Value 'Personal 2
            worksheet.Cells(filaexcel, 15) = grilla.Rows(i).Cells(14).Value 'Personal 3
            filaexcel = filaexcel + 1
        Next

        rango = worksheet.Range("A10:N" & filaexcel)
        rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
        excelApp.Visible = True
    End Sub

    Public Sub exportarInfOtPDF(ByRef grilla As DataGridView, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet As Excel.Worksheet

        excelApp = New Excel.Application
        workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_ot.xls")
        worksheet = workbook.Sheets(1)
        worksheet.Visible = Excel.XlSheetVisibility.xlSheetVisible
        worksheet.Activate()

        worksheet.Cells(5, 6) = FormatDateTime(fecha_inicio, DateFormat.ShortDate)
        worksheet.Cells(6, 6) = FormatDateTime(fecha_fin, DateFormat.ShortDate)
        Dim filaexcel As Integer = 10
        Dim col_excel As Integer = 1
        Dim rango As Excel.Range
        For i = 0 To grilla.RowCount - 1
            For j = 0 To grilla.ColumnCount - 1
                worksheet.Cells(filaexcel, col_excel) = grilla.Rows(i).Cells(j).Value
                col_excel = col_excel + 1
            Next
            filaexcel = filaexcel + 1
            col_excel = 1
        Next

        rango = worksheet.Range("A10:R" & filaexcel)
        rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        workbook.PrintOutEx(ActivePrinter:="doPDF v7")
        workbook.Close(False)
        excelApp.Quit()
    End Sub

    Public Sub CrgDetalleResumenOt(ByVal personal As String, ByVal fecha_inicio As DateTime, ByVal fecha_termino As DateTime, ByVal opcion As Integer, ByVal tipo_falla As String, ByVal turno As String, ByVal fecha As DateTime, ByVal estado As String, ByVal nodo_padre As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_DETALLE_RESUMEN_OT", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_personal As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@personal", personal)
            Dim p_fecha_inicio As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_fecha_termino As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_termino", Format(fecha_termino, "MM/dd/yyyy"))
            Dim p_opcion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@opcion", opcion)
            Dim p_tipo_falla As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_falla", tipo_falla)
            Dim p_turno As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@turno", turno)
            Dim p_fecha As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha", Format(fecha, "MM/dd/yyyy"))
            Dim p_estado As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@estado", estado)
            Dim p_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))

            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

End Class
