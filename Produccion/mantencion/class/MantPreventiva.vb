Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class MantPreventiva

    Public Sub IngMantPreventiva(ByVal id_mp As String, ByVal id_nodo As String, ByVal frecuencia As String, ByVal tiempo_aviso_previo As String, ByVal estado_mp As String, ByVal tipo_mp As String, ByVal sesion As String, ByVal obs_mantencion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_MANT_PREVENTIVA", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
            Dim p_frecuencia As SqlParameter = com.Parameters.AddWithValue("@frecuencia", CInt(frecuencia))
            Dim p_tiempo_aviso_prev As SqlParameter = com.Parameters.AddWithValue("@tiempo_aviso", CInt(tiempo_aviso_previo))
            Dim p_estado_mp As SqlParameter = com.Parameters.AddWithValue("@estado_mp", estado_mp)
            Dim p_fecha_creacion As SqlParameter = com.Parameters.AddWithValue("@fecha_creacion", Format(Now, "MM/dd/yyyy"))
            Dim p_tipo_mp As SqlParameter = com.Parameters.AddWithValue("@tipo_mantencion", tipo_mp)
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
            Dim p_obs_mantencion As SqlParameter = com.Parameters.AddWithValue("@obs_mantencion", obs_mantencion)
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

    Public Sub IngPersonalCicloMp(ByVal rut As String, ByVal id_mp As String, ByVal id_ciclo As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_PERSONAL_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)

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

    Public Sub IngTareasCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_tarea As String, ByVal id_nodo As String, ByVal tiempo_tarea As String, ByVal obs_tarea As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_resp As Integer

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_TAREAS_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_id_tarea As SqlParameter = com.Parameters.AddWithValue("@id_tarea", CInt(id_tarea))
            Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
            Dim p_tiempo As SqlParameter = com.Parameters.AddWithValue("@tiempo_tarea", CDbl(tiempo_tarea))
            Dim p_obs_tarea As SqlParameter = com.Parameters.AddWithValue("@obs_tarea", obs_tarea)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
            End If
            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub IngCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal fecha_ini_ciclo As DateTime, ByVal hr_ini_ciclo As DateTime, ByVal fecha_fin_ciclo As DateTime, ByVal hr_fin_ciclo As DateTime, ByVal duracion As String, ByVal obs_ciclo As String, ByVal estado_ciclo As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_fecha_ini As SqlParameter = com.Parameters.AddWithValue("@fecha_ini", Format(fecha_ini_ciclo, "MM/dd/yyyy"))
            Dim p_hora_ini As SqlParameter = com.Parameters.AddWithValue("@hora_ini", Format(hr_ini_ciclo, "HH:mm:ss"))
            Dim p_fecha_fin As SqlParameter = com.Parameters.AddWithValue("@fecha_fin", Format(fecha_fin_ciclo, "MM/dd/yyyy"))
            Dim p_hora_fin As SqlParameter = com.Parameters.AddWithValue("@hora_fin", Format(hr_fin_ciclo, "HH:mm:ss"))
            Dim p_duracion As SqlParameter = com.Parameters.AddWithValue("@duracion", CDbl(duracion))
            Dim p_obs_ciclo As SqlParameter = com.Parameters.AddWithValue("@obs_ciclo", obs_ciclo)
            Dim p_estado_ciclo As SqlParameter = com.Parameters.AddWithValue("@estado_ciclo", estado_ciclo)
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

    Public Sub IngTareasPendCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_tarea As String, ByVal id_nodo As String, ByVal obs_tarea As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_resp As Integer

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_TAREAS_PEND_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_id_tarea As SqlParameter = com.Parameters.AddWithValue("@id_tarea", CInt(id_tarea))
            Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
            Dim p_obs_tarea As SqlParameter = com.Parameters.AddWithValue("@obs_tarea", obs_tarea)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
            End If
            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub IngInsumosMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_insumo As String, ByVal cantidad As String, ByVal unid_medida As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_resp As Integer

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_INSUMOS_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_id_insumo As SqlParameter = com.Parameters.AddWithValue("@id_insumo", CInt(id_insumo))
            Dim p_cantidad As SqlParameter = com.Parameters.AddWithValue("@cantidad", CInt(cantidad))
            Dim p_unid_medida As SqlParameter = com.Parameters.AddWithValue("@unid_medida", unid_medida)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
            End If
            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub UpdMantPreventiva(ByVal id_mp As String, ByVal id_nodo As String, ByVal frecuencia As String, ByVal tiempo_aviso_previo As String, ByVal estado_mp As String, ByVal tipo_mp As String, ByVal sesion As String, ByVal obs_mantencion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_MANT_PREVENTIVA", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
            Dim p_frecuencia As SqlParameter = com.Parameters.AddWithValue("@frecuencia", CInt(frecuencia))
            Dim p_tiempo_aviso_prev As SqlParameter = com.Parameters.AddWithValue("@tiempo_aviso_mp", CInt(tiempo_aviso_previo))
            Dim p_estado_mp As SqlParameter = com.Parameters.AddWithValue("@estado_mp", estado_mp)
            Dim p_tipo_mp As SqlParameter = com.Parameters.AddWithValue("@tipo_mantencion", tipo_mp)
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
            Dim p_obs_mantencion As SqlParameter = com.Parameters.AddWithValue("@obs_mantencion", obs_mantencion)
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

    Public Sub UpdTareasCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_tarea As String, ByVal id_nodo As String, ByVal tiempo_tarea As String, ByVal obs_tarea As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_resp As Integer = 0
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_TAREAS_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_id_tarea As SqlParameter = com.Parameters.AddWithValue("@id_tarea", CInt(id_tarea))
            Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
            Dim p_tiempo As SqlParameter = com.Parameters.AddWithValue("@tiempo_tarea", CDbl(tiempo_tarea))
            Dim p_obs_tarea As SqlParameter = com.Parameters.AddWithValue("@obs_tarea", obs_tarea)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
            End If
            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub UpdInsumosCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_insumo As String, ByVal cantidad As String, ByVal unid_medida As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_resp As Integer = 0
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_INSUMOS_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_id_insumo As SqlParameter = com.Parameters.AddWithValue("@id_insumo", CInt(id_insumo))
            Dim p_cant_insumo As SqlParameter = com.Parameters.AddWithValue("@cantidad", CInt(cantidad))
            Dim p_unid_medida As SqlParameter = com.Parameters.AddWithValue("@unid_medida", unid_medida)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
            End If
            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub UpdCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal fecha_ini_ciclo As DateTime, ByVal hr_ini_ciclo As DateTime, ByVal fecha_fin_ciclo As DateTime, ByVal hr_fin_ciclo As DateTime, ByVal duracion As String, ByVal obs_ciclo As String, ByVal estado_ciclo As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_fecha_ini As SqlParameter = com.Parameters.AddWithValue("@fecha_inicio", Format(fecha_ini_ciclo, "MM/dd/yyyy"))
            Dim p_hora_ini As SqlParameter = com.Parameters.AddWithValue("@hora_inicio", Format(hr_ini_ciclo, "hh:mm:ss"))
            Dim p_fecha_fin As SqlParameter = com.Parameters.AddWithValue("@fecha_termino", Format(fecha_fin_ciclo, "MM/dd/yyyy"))
            Dim p_hora_fin As SqlParameter = com.Parameters.AddWithValue("@hora_termino", Format(hr_fin_ciclo, "hh:mm:ss"))
            Dim p_duracion As SqlParameter = com.Parameters.AddWithValue("@duracion", CDbl(duracion))
            Dim p_obs_ciclo As SqlParameter = com.Parameters.AddWithValue("@obs_ciclo", obs_ciclo)
            Dim p_estado_ciclo As SqlParameter = com.Parameters.AddWithValue("@estado_ciclo", estado_ciclo)
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

    Public Sub UpdPersonalCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal rut As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_resp As Integer = 0
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_PERSONAL_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
            End If
            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub CrgCmbEstadoCiclo(ByRef combo As ComboBox)
        combo.Items.Add("Terminado")
        combo.Items.Add("Pendiente")
        combo.Text = combo.Items(0)
    End Sub

    Public Sub CrgCmbEstadoMp(ByRef combo As ComboBox)
        combo.Items.Add("Activa")
        combo.Items.Add("Cerrada")
        combo.Text = combo.Items(0)
    End Sub

    Public Sub CrgCmbTipoMp(ByRef combo As ComboBox)
        combo.Items.Add("Mecanica")
        combo.Items.Add("Electrica")
        combo.Items.Add("Electronica")
        combo.Text = combo.Items(0)
    End Sub

    Public Sub CrgCmbTipoMpGantt(ByRef combo As ComboBox)
        combo.Items.Add("Mecanica")
        combo.Items.Add("Electrica")
        combo.Items.Add("Electronica")
        combo.Items.Add("Todos")
        combo.Text = combo.Items(0)
    End Sub

    Public Sub CrgMpNodo(ByVal id_nodo As String, ByVal tipo_mp As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_MP_NODO", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim p_id_nodo As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_nodo", id_nodo)
            Dim p_tipo As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_mantencion", tipo_mp)

            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub CrgCicloMp(ByVal id_mp As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_CICLOS_MP_NODO", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub CrgPersonalCicloMp(ByVal id_mp As String, ByVal id_ciclo_mp As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_PERSONAL_CICLO_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_ciclo_mp", CInt(id_ciclo_mp))
            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub CrgTareasCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal nodo_padre As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_TAREAS_CICLO_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", id_ciclo)
            Dim p_id_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub CrgTareasPendCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_TAREAS_PEND_CICLO_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub CrgCmbCicloMp(ByRef combo As ComboBox, ByVal id_mp As String)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_CMB_CICLOS_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim DS As New DataSet

            DA.Fill(DS)
            combo.DataSource = DS.Tables(0)
            combo.DisplayMember = "idciclo"
            combo.ValueMember = "idciclo"
            conexion.Desconectar(cnx)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub CrgInsumosCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_INSUMOS_CICLO_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub CrgTareasNodoTodas(ByRef DST_TAREAS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_TAREAS_TODAS", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure

            DA.Fill(DST_TAREAS)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub CrgNodosHijosMp(ByVal nodo_padre As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_NODOS_HIJOS_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim p_id_nodo As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))
            
            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Function NuevoIdMp() As Integer
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Dim id_mp As Integer = 0

        Try
            conexion.Conectar(cnx)
            Dim DR As SqlDataReader
            Dim com As New SqlCommand("NUEVO_ID_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            DR = com.ExecuteReader
            If DR.Read() Then
                id_mp = DR(0)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
            Return id_mp
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function NuevoIdCicloMp(ByVal id_mp As String) As Integer
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Dim id_ciclo As Integer = 0

        Try
            conexion.Conectar(cnx)
            Dim DR As SqlDataReader
            Dim com As New SqlCommand("NUEVO_ID_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim par_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))

            DR = com.ExecuteReader
            If DR.Read() Then
                id_ciclo = DR(0)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
            Return id_ciclo
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function BuscarMp(ByVal id_mp As String) As Boolean
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim encontrado As Boolean = False

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("BUSCAR_MANT_PREVENTIVA", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            
            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                If DR(0) = 1 Then
                    encontrado = True
                    conexion.Desconectar(cnx)
                    com.Dispose()
                    Return encontrado
                Else
                    conexion.Desconectar(cnx)
                    com.Dispose()
                    Return encontrado
                End If
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Function

    Public Function BuscarCicloMp(ByVal id_mp As String, ByVal id_ciclo As String) As Boolean
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim encontrado As Boolean = False

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("BUSCAR_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo_mp As SqlParameter = com.Parameters.AddWithValue("@id_ciclo_mp", CInt(id_ciclo))

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                If DR(0) = 1 Then
                    encontrado = True
                    conexion.Desconectar(cnx)
                    com.Dispose()
                    Return encontrado
                Else
                    conexion.Desconectar(cnx)
                    com.Dispose()
                    Return encontrado
                End If
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Function

    Public Function BuscarUltimoCicloMp(ByVal id_mp As String, ByVal id_ciclo As String) As Boolean
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim encontrado As Boolean = False

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("BUSCAR_ULTIMO_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo_mp As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                If DR(0).ToString = "True" Then
                    encontrado = True
                    conexion.Desconectar(cnx)
                    com.Dispose()
                    Return encontrado
                Else
                    conexion.Desconectar(cnx)
                    com.Dispose()
                    Return encontrado
                End If
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Function

    Public Sub LimpiarFrmMp()
        With FrmMp
            .txtIdMant.ResetText()
            .txtFrecuenciaMp.ResetText()
            .txtTiempoAviso.ResetText()
            .txtIdCiclo.ResetText()
            .FechaIniCiclo.Value = Now
            .HrInicioCiclo.Value = Now
            .fechaFinCicloMp.Value = Now
            .HrFinCiclo.Value = Now
            .txtDuracionCiclo.ResetText()
            .txtObsCiclo.ResetText()
            .grillaTareasCicloMp.DataSource = Nothing
            .id_nodo_select = ""
            .txtObsMant.ResetText()

            'Limpia el origen de datos,la grilla personal mp y crea las columnas nuevamente
            '------------------------------------------------------------------------------
            .DS2.Tables.Clear()
            .DST_TAREAS.Tables.Clear()
            .grillaPersonalMp.DataSource = Nothing
            .grillaPersonalMp.Columns.Clear()
            .grillaPersonalMp.Columns.Add("rut_personal", "RUT")
            .grillaPersonalMp.Columns.Add("nombre_personal", "ALIAS PERSONAL")
            '------------------------------------------------------------------------------

            .grillaInsumosMp.Rows.Clear()

            If .btnGuardarMp.Enabled = False Then
                .btnGuardarMp.Enabled = True
            End If

            If .btnGuardarComoNuevoCiclo.Enabled = False Then
                .btnGuardarComoNuevoCiclo.Enabled = True
            End If

            If .btnNuevoCiclo.Enabled = False Then
                .btnNuevoCiclo.Enabled = True
            End If

            If .btnIngMp.Enabled = False Then
                .btnIngMp.Enabled = True
            End If
            .form_limpio = True
            .lblHrsCiclo.Visible = False
            .hrsCiclo.Visible = False
            .hrsCiclo.Text = 0
            .btnGuardarMp.Text = "   Guardar"
            .btn_plan_ciclos.Enabled = False
            .del_index_personal.Clear()
            .del_index_tareas.Clear()
        End With
    End Sub

    Public Sub DelCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("DEL_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
            Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
            End If
            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub DelMantPreventiva(ByVal id_mp As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("DEL_MANT_PREV", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
            Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
            End If
            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub DelInsumoCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_insumo As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("DEL_INSUMO_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_id_insumo As SqlParameter = com.Parameters.AddWithValue("@id_insumo", CInt(id_insumo))

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
            End If
            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub DelPersonalCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal rut As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("DEL_PERSONAL_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
            End If
            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub DelTareaCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_tarea As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("DEL_TAREA_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_id_tarea As SqlParameter = com.Parameters.AddWithValue("@id_tarea", CInt(id_tarea))

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
            End If
            conexion.Desconectar(cnx)
            com.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Function ValidarIngresoMp(ByRef Form As FrmMp, ByRef resp As String) As Boolean
        Dim valida As Boolean = True
        Dim fecha_hr_ini As DateTime
        Dim fecha_hr_fin As DateTime

        fecha_hr_ini = FormatDateTime(Form.FechaIniCiclo.Value, DateFormat.ShortDate) & " " & FormatDateTime(Form.HrInicioCiclo.Value, DateFormat.ShortTime)
        fecha_hr_fin = FormatDateTime(Form.fechaFinCicloMp.Value, DateFormat.ShortDate) & " " & FormatDateTime(Form.HrFinCiclo.Value, DateFormat.ShortTime)

        With Form
            If .txtIdMant.Text = "" Then
                valida = False
                resp = "El campo N°Mant. no puede estar vacío" & Chr(13)
            End If
            If .txtFrecuenciaMp.Text = "" Then
                valida = False
                resp = resp & "Ingrese la Frecuencia en horas" & Chr(13)
            End If

            If .txtTiempoAviso.Text = "" Then
                valida = False
                resp = resp & "Ingrese el tiempo de aviso en horas" & Chr(13)
            End If

            If .cmbEstadoMp.Text = "" Then
                valida = False
                resp = resp & "Ingrese el estado de la mantención" & Chr(13)
            End If

            If .cmbTipoMp.Text = "" Then
                valida = False
                resp = resp & "Ingrese el tipo de mantención" & Chr(13)
            End If

            If .txtIdCiclo.Text = "" Then
                valida = False
                resp = resp & "Debe crear un ciclo antes de ingresar la mantencion" & Chr(13)
            End If

            If fecha_hr_ini > fecha_hr_fin Then
                valida = False
                resp = resp & "La Fecha y hora de inicio no puede ser mayor a Fecha y hora de fin de ciclo" & Chr(13)
            End If

            If .txtDuracionCiclo.Text = "" Then
                valida = False
                resp = resp & "debe calcular la duracion del ciclo" & Chr(13)
            End If

            If FrmMp.grillaTareasCicloMp.Rows.Count > 0 Then
                For i = 0 To FrmMp.grillaTareasCicloMp.RowCount - 1
                    If FrmMp.grillaTareasCicloMp.Rows(i).Cells(3).Value.ToString = "" And FrmMp.grillaTareasCicloMp.Rows(i).Cells(0).Value = True Then
                        valida = False
                        resp = resp & "Debe ingresar el tiempo de la tarea realizada: Fila N°" & i + 1 & Chr(13)
                    ElseIf FrmMp.grillaTareasCicloMp.Rows(i).Cells(0).Value = False And FrmMp.grillaTareasCicloMp.Rows(i).Cells(4).Value.ToString = "" Then
                        valida = False
                        resp = resp & "Para las tareas pendientes debe ingresar una observacion" & Chr(13)
                    End If
                Next
            ElseIf FrmMp.grillaTareasCicloMp.RowCount = 0 Then
                valida = False
                resp = resp & "Debe ingresar al menos una tarea para el ciclo"
            End If

            If FrmMp.grillaPersonalMp.Rows.Count > 0 Then
                For i = 0 To FrmMp.grillaPersonalMp.RowCount - 1
                    If FrmMp.grillaPersonalMp.Rows(i).Cells(0).Value.ToString = "" Then
                        valida = False
                        resp = resp & "Debe ingresar agregar una persona: Fila N°" & i + 1 & Chr(13)
                    End If
                Next
            End If

            If FrmMp.grillaInsumosMp.Rows.Count > 0 Then
                For i = 0 To FrmMp.grillaInsumosMp.RowCount - 1
                    If FrmMp.grillaInsumosMp.Rows(i).Cells(3).Value = "" Then
                        valida = False
                        resp = resp & "Debe ingresar la cantidad de insumos: Fila N°" & i + 1 & Chr(13)
                    End If
                Next
            End If
            Return valida
        End With
    End Function

    Public Sub InfMpTodos(ByVal id_nodo As String, ByRef fecha_inicio As DateTime, ByRef fecha_fin As DateTime, ByRef tipo_mp As String, ByVal opcion As Integer, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            If tipo_mp = "" Then
                tipo_mp = "Todos"
            End If
            Dim DA As New SqlDataAdapter("INF_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_nodo As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_nodo", id_nodo)
            Dim p_f_ini As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_ini", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_f_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_tipo_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_mp", tipo_mp)
            Dim p_f_opcion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@opcion", opcion)

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub InfCicloMp(ByVal id_mp As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_CICLO_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub InfTareasCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal nodo_padre As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_TAREAS_CICLO_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub InfMpFechas(ByVal id_nodo As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByVal tipo_mp As String, ByVal opcion As Integer, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            If tipo_mp = "" Then
                tipo_mp = "Todos"
            End If
            Dim DA As New SqlDataAdapter("INF_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_nodo As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_nodo", id_nodo)
            Dim p_f_ini As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_ini", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_f_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_tipo_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_mp", tipo_mp)
            Dim p_f_opcion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@opcion", opcion)

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub InfMpTipoMp(ByVal id_nodo As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByVal tipo_mp As String, ByVal opcion As Integer, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            If tipo_mp = "" Then
                tipo_mp = "Todos"
            End If
            Dim DA As New SqlDataAdapter("INF_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_nodo As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_nodo", id_nodo)
            Dim p_f_ini As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_ini", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_f_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_tipo_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_mp", tipo_mp)
            Dim p_f_opcion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@opcion", opcion)

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub InfSoloTareasMp(ByVal opcion As String, ByVal id_nodo As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_SOLO_TAREAS_INF_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@opcion", CInt(opcion))
            Dim p_id_ciclo_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub InfPersonalCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_PERSONAL_CICLO_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub InfInsumosCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_INSUMOS_CICLO_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub InfTareasPendCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal nodo_padre As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_TAREAS_PEND_CICLO_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub InfCiclosMaquinasMp(ByVal id_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByVal tipo_mantencion As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("INF_CICLOS_MP_MAQUINAS", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(id_padre))
            Dim p_fecha_inicio As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio_ciclo", Format(fecha_inicio, "MM/dd/yyyy"))
            Dim p_fecha_fin As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@fecha_fin_ciclo", Format(fecha_fin, "MM/dd/yyyy"))
            Dim p_tipo_mantencion As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_mantencion", tipo_mantencion)

            DA.Fill(DST)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub exportarInfMpExcel(ByRef grilla_mp As DataGridView, ByRef grilla_ciclo As DataGridView, ByRef grilla_tareas_r As DataGridView, ByVal grilla_personal As DataGridView, ByVal grilla_tareas_pend As DataGridView, ByVal grilla_insumos As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim worksheet_4 As Excel.Worksheet
        Dim worksheet_5 As Excel.Worksheet

        excelApp = New Excel.Application
        workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_mp.xls")
        worksheet = workbook.Sheets(1)
        worksheet_2 = workbook.Sheets(2)
        worksheet_3 = workbook.Sheets(3)
        worksheet_4 = workbook.Sheets(4)
        worksheet_5 = workbook.Sheets(5)
        worksheet.Visible = Excel.XlSheetVisibility.xlSheetVisible
        worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_4.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_5.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet.Activate()

        '---------------------- impresion información base mantencion preventiva----------------
        worksheet.Cells(5, 2) = item 'nombre item o maquina
        worksheet.Cells(6, 2) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(0).Value ' id mantencion
        worksheet.Cells(5, 6) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(1).Value ' frecuencia mp
        worksheet.Cells(6, 6) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(2).Value ' tiempo aviso previo
        worksheet.Cells(5, 12) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(3).Value ' estado
        worksheet.Cells(5, 9) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(4).Value ' fecha creacion
        worksheet.Cells(6, 9) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(5).Value ' tipo de mantencion
        '---------------------------------------------------------------------------------------

        '----------------------- impresión información del ciclo de acuerdo a la mantencion seleccionada 
        worksheet.Cells(9, 2) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(0).Value ' n° ciclo
        worksheet.Cells(9, 5) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(1).Value ' fecha / hora inicio 
        worksheet.Cells(9, 8) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(2).Value ' fecha / hora termino
        worksheet.Cells(9, 10) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(3).Value ' duracion
        worksheet.Cells(10, 2) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(4).Value ' observacion ciclo
        worksheet.Cells(9, 12) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(5).Value ' estado ciclo
        '---------------------------------------------------------------------------------------

        Dim filaexcel As Integer = 18
        Dim col_excel As Integer = 1
        Dim rango As Excel.Range

        '------------- llenado de tareas realizadas --------------------------------------------
        For i = 0 To grilla_tareas_r.RowCount - 1
            worksheet.Rows(filaexcel + 1).Insert()
            worksheet.Cells(filaexcel, 1) = grilla_tareas_r.Rows(i).Cells(0).Value
            worksheet.Cells(filaexcel, 2) = grilla_tareas_r.Rows(i).Cells(1).Value
            worksheet.Cells(filaexcel, 8) = grilla_tareas_r.Rows(i).Cells(2).Value
            worksheet.Cells(filaexcel, 9) = grilla_tareas_r.Rows(i).Cells(3).Value
            rango = worksheet.Range("B" & filaexcel & ":G" & filaexcel)
            rango.MergeCells = True
            rango = worksheet.Range("I" & filaexcel & ":L" & filaexcel)
            rango.MergeCells = True
            filaexcel = filaexcel + 1
        Next

        Dim filaexcel_2 As Integer = 13
        '------------- llenado de informacion personal asociado al ciclo mp
        If grilla_personal.RowCount > 0 Then
            Dim col As Integer = 2
            For i = 0 To grilla_personal.RowCount - 1
                If i <= 3 Then
                    worksheet.Cells(filaexcel_2, col) = grilla_personal.Rows(i).Cells(1).Value & " " & grilla_personal.Rows(i).Cells(2).Value
                    col = col + 3
                End If
            Next
        End If

        
        '---------- llenado de tareas pendientes del ciclo ----------------------------------
        If grilla_tareas_pend.RowCount > 0 Then
            worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetVisible

            '---------------------- impresion información base mantencion preventiva hoja tareas pendientes ----------------
            worksheet_2.Cells(5, 2) = item 'nombre item o maquina
            worksheet_2.Cells(6, 2) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(0).Value ' id mantencion
            worksheet_2.Cells(5, 6) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(1).Value ' frecuencia mp
            worksheet_2.Cells(6, 6) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(2).Value ' tiempo aviso previo
            worksheet_2.Cells(5, 12) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(3).Value ' estado
            worksheet_2.Cells(5, 9) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(4).Value ' fecha creacion
            worksheet_2.Cells(6, 9) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(5).Value ' tipo de mantencion
            '---------------------------------------------------------------------------------------

            '----------------------- impresión información del ciclo de acuerdo a la mantencion seleccionada 
            worksheet_2.Cells(9, 2) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(0).Value ' n° ciclo
            worksheet_2.Cells(9, 5) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(1).Value ' fecha / hora inicio 
            worksheet_2.Cells(9, 8) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(2).Value ' fecha / hora termino
            worksheet_2.Cells(9, 10) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(3).Value ' duracion
            worksheet_2.Cells(10, 2) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(4).Value ' observacion ciclo
            worksheet_2.Cells(9, 12) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(5).Value ' estado ciclo
            '---------------------------------------------------------------------------------------

            If grilla_personal.RowCount > 0 Then
                filaexcel_2 = 13
                Dim col As Integer = 2
                For i = 0 To grilla_personal.RowCount - 1
                    If i <= 3 Then
                        worksheet_2.Cells(filaexcel_2, col) = grilla_personal.Rows(i).Cells(1).Value & " " & grilla_personal.Rows(i).Cells(2).Value
                        col = col + 3
                    End If
                Next
            End If

            filaexcel_2 = 18
            
            For i = 0 To grilla_tareas_pend.RowCount - 1
                worksheet_2.Rows(filaexcel_2 + 1).Insert()
                worksheet_2.Cells(filaexcel_2, 1) = grilla_tareas_pend.Rows(i).Cells(0).Value
                worksheet_2.Cells(filaexcel_2, 2) = grilla_tareas_pend.Rows(i).Cells(1).Value
                worksheet_2.Cells(filaexcel_2, 8) = grilla_tareas_pend.Rows(i).Cells(2).Value
                rango = worksheet_2.Range("B" & filaexcel_2 & ":G" & filaexcel_2)
                rango.MergeCells = True
                rango = worksheet_2.Range("H" & filaexcel_2 & ":L" & filaexcel_2)
                rango.MergeCells = True
                filaexcel_2 = filaexcel_2 + 1
            Next
            'rango = worksheet_2.Range("A11:J" & filaexcel_2 - 1)
            'rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        End If
        '-------------------------------------------------------------------------------------
        '-------------------- llenado de insumos asociados al ciclo --------------------------
        filaexcel_2 = 11
        If grilla_insumos.RowCount > 0 Then
            worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetVisible
            worksheet_3.Cells(6, 3) = worksheet.Cells(7, 3)
            worksheet_3.Cells(7, 3) = worksheet.Cells(10, 2)
            worksheet_3.Cells(6, 6) = item
            For i = 0 To grilla_insumos.RowCount - 1
                worksheet_3.Cells(filaexcel_2, 1) = grilla_insumos.Rows(i).Cells(0).Value
                worksheet_3.Cells(filaexcel_2, 2) = grilla_insumos.Rows(i).Cells(1).Value
                worksheet_3.Cells(filaexcel_2, 8) = grilla_insumos.Rows(i).Cells(2).Value
                worksheet_3.Cells(filaexcel_2, 9) = grilla_insumos.Rows(i).Cells(3).Value
                worksheet_3.Cells(filaexcel_2, 10) = grilla_insumos.Rows(i).Cells(4).Value
                rango = worksheet_3.Range("B" & filaexcel_2 & ":G" & filaexcel_2)
                rango.MergeCells = True
                filaexcel_2 = filaexcel_2 + 1
            Next
            rango = worksheet_3.Range("A11:J" & filaexcel_2 - 1)
            rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        End If
        '--------------------------------------------------------------------------------------
        MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Excel")
        excelApp.Visible = True
    End Sub

    Public Sub expInfMpExcelSoloRealizadas(ByVal grilla_tareas_realizadas As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim worksheet_4 As Excel.Worksheet
        Dim worksheet_5 As Excel.Worksheet
        Dim filaexcel As Integer = 11
        Dim rango As Excel.Range

        excelApp = New Excel.Application
        workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_mp.xls")
        worksheet_1 = workbook.Sheets(1)
        worksheet_2 = workbook.Sheets(2)
        worksheet_3 = workbook.Sheets(3)
        worksheet_4 = workbook.Sheets(4)
        worksheet_5 = workbook.Sheets(5)
        worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_4.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_5.Visible = Excel.XlSheetVisibility.xlSheetVisible
        worksheet_5.Activate()

        worksheet_5.Cells(6, 3) = item

        For i = 0 To grilla_tareas_realizadas.RowCount - 1
            worksheet_5.Cells(filaexcel, 1) = grilla_tareas_realizadas.Rows(i).Cells(0).Value
            worksheet_5.Cells(filaexcel, 2) = grilla_tareas_realizadas.Rows(i).Cells(1).Value
            worksheet_5.Cells(filaexcel, 3) = grilla_tareas_realizadas.Rows(i).Cells(2).Value
            worksheet_5.Cells(filaexcel, 4) = grilla_tareas_realizadas.Rows(i).Cells(3).Value
            worksheet_5.Cells(filaexcel, 8) = grilla_tareas_realizadas.Rows(i).Cells(4).Value
            worksheet_5.Cells(filaexcel, 9) = grilla_tareas_realizadas.Rows(i).Cells(5).Value
            rango = worksheet_5.Range("D" & filaexcel & ":G" & filaexcel)
            rango.MergeCells = True
            rango = worksheet_5.Range("I" & filaexcel & ":L" & filaexcel)
            rango.MergeCells = True
            filaexcel = filaexcel + 1
        Next

        rango = worksheet_5.Range("A11:L" & filaexcel - 1)
        rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Excel")
        excelApp.Visible = True
    End Sub

    Public Sub expInfMpExcelSoloPend(ByVal grilla_tareas_pend As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim worksheet_4 As Excel.Worksheet
        Dim worksheet_5 As Excel.Worksheet
        Dim filaexcel As Integer = 11
        Dim rango As Excel.Range

        excelApp = New Excel.Application
        workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_mp.xls")
        worksheet_1 = workbook.Sheets(1)
        worksheet_2 = workbook.Sheets(2)
        worksheet_3 = workbook.Sheets(3)
        worksheet_4 = workbook.Sheets(4)
        worksheet_5 = workbook.Sheets(5)
        worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_4.Visible = Excel.XlSheetVisibility.xlSheetVisible
        worksheet_5.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_4.Activate()

        worksheet_4.Cells(6, 3) = item
       
        For i = 0 To grilla_tareas_pend.RowCount - 1
            worksheet_4.Cells(filaexcel, 1) = grilla_tareas_pend.Rows(i).Cells(0).Value
            worksheet_4.Cells(filaexcel, 2) = grilla_tareas_pend.Rows(i).Cells(1).Value
            worksheet_4.Cells(filaexcel, 3) = grilla_tareas_pend.Rows(i).Cells(2).Value
            worksheet_4.Cells(filaexcel, 4) = grilla_tareas_pend.Rows(i).Cells(3).Value
            worksheet_4.Cells(filaexcel, 8) = grilla_tareas_pend.Rows(i).Cells(4).Value
            rango = worksheet_4.Range("D" & filaexcel & ":G" & filaexcel)
            rango.MergeCells = True
            rango = worksheet_4.Range("H" & filaexcel & ":K" & filaexcel)
            rango.MergeCells = True
            filaexcel = filaexcel + 1
        Next

        rango = worksheet_4.Range("A11:K" & filaexcel - 1)
        rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Excel")
        excelApp.Visible = True
    End Sub

    Public Sub expInfGanttTodo(ByVal grilla_info_mp As DataGridView, ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim num_mant As Integer = 0
        Dim fecha_inicio As DateTime
        Dim fecha_fin As DateTime
        Dim fecha As DateTime
        Dim fecha_ini As DateTime
        Dim cont_celda_pintada As Integer = 0
        Dim cont_fila As Integer = 0
        Dim cont_col As Integer = 0

        excelApp = New Excel.Application
        workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "infGantt.xls")
        worksheet_1 = workbook.Sheets(1)
        worksheet_2 = workbook.Sheets(2)
        worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetVisible
        worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetVisible

        '---------------------- impresion información base mantencion preventiva----------------
        worksheet_1.Cells(6, 3) = item 'nombre item o maquina
        worksheet_1.Cells(7, 3) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(0).Value ' id mantencion
        worksheet_1.Cells(6, 6) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(1).Value & " Hrs" ' frecuencia mp
        worksheet_1.Cells(7, 6) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(2).Value & " Hrs" ' tiempo aviso previo
        worksheet_1.Cells(6, 12) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(3).Value ' estado
        worksheet_1.Cells(6, 9) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(4).Value ' fecha creacion
        worksheet_1.Cells(7, 9) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(5).Value ' tipo de mantencion
        '---------------------------------------------------------------------------------------

        Dim filaexcel As Integer = 12

        Dim rango As Excel.Range
        '------------- llenado de tareas realizadas --------------------------------------------
        For i = 0 To grilla_ciclos_mp.RowCount - 1
            worksheet_1.Cells(filaexcel, 1) = grilla_ciclos_mp.Rows(i).Cells(0).Value
            worksheet_1.Cells(filaexcel, 2) = grilla_ciclos_mp.Rows(i).Cells(1).Value
            worksheet_1.Cells(filaexcel, 5) = grilla_ciclos_mp.Rows(i).Cells(2).Value
            worksheet_1.Cells(filaexcel, 6) = grilla_ciclos_mp.Rows(i).Cells(3).Value
            worksheet_1.Cells(filaexcel, 7) = grilla_ciclos_mp.Rows(i).Cells(4).Value
            rango = worksheet_1.Range("B" & filaexcel & ":D" & filaexcel)
            rango.MergeCells = True
            filaexcel = filaexcel + 1
        Next
        '--------------------------------------------------------------------------------------

        '---------------------- impresion información base mantencion preventiva----------------
        worksheet_2.Cells(6, 3) = item 'nombre item o maquina
        worksheet_2.Cells(7, 3) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(0).Value ' id mantencion
        worksheet_2.Cells(6, 7) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(1).Value & " Hrs" ' frecuencia mp
        worksheet_2.Cells(7, 7) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(2).Value & " Hrs" ' tiempo aviso previo
        worksheet_2.Cells(6, 14) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(3).Value ' estado
        worksheet_2.Cells(6, 10) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(4).Value ' fecha creacion
        worksheet_2.Cells(7, 10) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(5).Value ' tipo de mantencion
        '---------------------------------------------------------------------------------------

        filaexcel = 11

        '------------- llenado de tareas realizadas --------------------------------------------
        For i = 0 To grilla_ciclos_mp.RowCount - 1
            worksheet_2.Cells(filaexcel, 1) = grilla_ciclos_mp.Rows(i).Cells(0).Value
            worksheet_2.Cells(filaexcel, 2) = grilla_ciclos_mp.Rows(i).Cells(1).Value
            rango = worksheet_2.Range("B" & filaexcel & ":D" & filaexcel)
            rango.MergeCells = True
            filaexcel = filaexcel + 1
        Next
        '---------------------------------------------------------------------------------------

        fecha_inicio = FormatDateTime(grilla_ciclos_mp.Rows(0).Cells(2).Value, DateFormat.ShortDate)
        fecha_fin = FormatDateTime(grilla_ciclos_mp.Rows(grilla_ciclos_mp.RowCount - 1).Cells(3).Value, DateFormat.ShortDate)
        fecha = fecha_inicio

        Dim col_excel As Integer = 5

        While fecha <= fecha_fin
            worksheet_2.Cells(10, col_excel) = fecha
            fecha = DateAdd(DateInterval.Day, 1, fecha)
            col_excel = col_excel + 1
        End While

        cont_col = 5
        cont_fila = 11

        For i = 0 To grilla_ciclos_mp.RowCount - 1
            fecha_ini = FormatDateTime(grilla_ciclos_mp.Rows(i).Cells(2).Value, DateFormat.ShortDate)
            num_mant = DateDiff(DateInterval.Day, grilla_ciclos_mp.Rows(i).Cells(2).Value, grilla_ciclos_mp.Rows(i).Cells(3).Value) + 1

            For j = 0 To grilla_grafico.Columns.Count - 1
                If fecha_ini = grilla_grafico.Columns(j).Name Then
                    worksheet_2.Cells(cont_fila, cont_col) = 1
                    cont_celda_pintada = cont_celda_pintada + 1
                    If cont_celda_pintada < num_mant Then
                        fecha_ini = DateAdd(DateInterval.Day, 1, fecha_ini)
                    End If

                End If
                cont_col = cont_col + 1
            Next
            cont_celda_pintada = 0
            cont_fila = cont_fila + 1
            cont_col = 5
        Next

        worksheet_1.Activate()
        MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Excel")
        excelApp.Visible = True
    End Sub

    Public Sub exportarInfMpPDF(ByRef grilla_mp As DataGridView, ByRef grilla_ciclo As DataGridView, ByRef grilla_tareas_r As DataGridView, ByVal grilla_personal As DataGridView, ByVal grilla_tareas_pend As DataGridView, ByVal grilla_insumos As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim worksheet_4 As Excel.Worksheet
        Dim worksheet_5 As Excel.Worksheet

        excelApp = New Excel.Application
        workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_mp.xls")
        worksheet = workbook.Sheets(1)
        worksheet_2 = workbook.Sheets(2)
        worksheet_3 = workbook.Sheets(3)
        worksheet_4 = workbook.Sheets(4)
        worksheet_5 = workbook.Sheets(5)
        worksheet.Visible = Excel.XlSheetVisibility.xlSheetVisible
        worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_4.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_5.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet.Activate()
        '---------------------- impresion información base mantencion preventiva----------------
        worksheet.Cells(6, 3) = item 'nombre item o maquina
        worksheet.Cells(7, 3) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(0).Value ' id mantencion
        worksheet.Cells(6, 6) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(1).Value ' frecuencia mp
        worksheet.Cells(7, 6) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(2).Value ' tiempo aviso previo
        worksheet.Cells(6, 11) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(3).Value ' estado
        worksheet.Cells(6, 9) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(4).Value ' fecha creacion
        worksheet.Cells(7, 9) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(5).Value ' tipo de mantencion
        '---------------------------------------------------------------------------------------

        '----------------------- impresión información del ciclo de acuerdo a la mantencion seleccionada 
        worksheet.Cells(10, 2) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(0).Value ' n° ciclo
        worksheet.Cells(10, 5) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(1).Value ' fecha / hora inicio 
        worksheet.Cells(11, 5) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(2).Value ' fecha / hora termino
        worksheet.Cells(10, 7) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(3).Value ' duracion
        worksheet.Cells(13, 3) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(4).Value ' observacion ciclo
        worksheet.Cells(11, 7) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(5).Value ' estado ciclo
        '---------------------------------------------------------------------------------------
        Dim filaexcel As Integer = 23
        Dim col_excel As Integer = 1
        Dim rango As Excel.Range
        '------------- llenado de tareas realizadas --------------------------------------------
        For i = 0 To grilla_tareas_r.RowCount - 1
            worksheet.Cells(filaexcel, 1) = grilla_tareas_r.Rows(i).Cells(0).Value
            worksheet.Cells(filaexcel, 2) = grilla_tareas_r.Rows(i).Cells(1).Value
            worksheet.Cells(filaexcel, 6) = grilla_tareas_r.Rows(i).Cells(2).Value
            worksheet.Cells(filaexcel, 7) = grilla_tareas_r.Rows(i).Cells(3).Value
            rango = worksheet.Range("B" & filaexcel & ":E" & filaexcel)
            rango.MergeCells = True
            rango = worksheet.Range("G" & filaexcel & ":J" & filaexcel)
            rango.MergeCells = True
            filaexcel = filaexcel + 1
        Next
        rango = worksheet.Range("A23:J" & filaexcel - 1)
        rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        Dim filaexcel_2 As Integer = 16
        '------------- llenado de informacion personal asociado al ciclo mp
        If grilla_personal.RowCount > 0 Then

            For i = 0 To grilla_personal.RowCount - 1
                If i <= 2 Then
                    worksheet.Cells(filaexcel_2, 3) = grilla_personal.Rows(i).Cells(1).Value & " " & grilla_personal.Rows(i).Cells(2).Value
                ElseIf i > 2 And i <= 5 Then
                    If i = 3 Then
                        filaexcel_2 = 16
                    End If
                    worksheet.Cells(filaexcel_2, 6) = grilla_personal.Rows(i).Cells(1).Value & " " & grilla_personal.Rows(i).Cells(2).Value
                ElseIf i > 5 And i <= 8 Then
                    If i = 6 Then
                        filaexcel_2 = 16
                    End If
                    worksheet.Cells(filaexcel_2, 9) = grilla_personal.Rows(i).Cells(1).Value & " " & grilla_personal.Rows(i).Cells(2).Value
                End If
                filaexcel_2 = filaexcel_2 + 1
            Next
        End If

        '---------- llenado de tareas pendientes del ciclo ----------------------------------
        If grilla_tareas_pend.RowCount > 0 Then
            filaexcel_2 = 11
            worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetVisible
            worksheet_2.Cells(6, 3) = worksheet.Cells(7, 3)
            worksheet_2.Cells(7, 3) = worksheet.Cells(10, 2)
            worksheet_2.Cells(6, 6) = item
            For i = 0 To grilla_tareas_pend.RowCount - 1
                worksheet_2.Cells(filaexcel_2, 1) = grilla_tareas_pend.Rows(i).Cells(0).Value
                worksheet_2.Cells(filaexcel_2, 2) = grilla_tareas_pend.Rows(i).Cells(1).Value
                worksheet_2.Cells(filaexcel_2, 6) = grilla_tareas_pend.Rows(i).Cells(2).Value
                rango = worksheet_2.Range("B" & filaexcel_2 & ":E" & filaexcel_2)
                rango.MergeCells = True
                rango = worksheet_2.Range("F" & filaexcel_2 & ":J" & filaexcel_2)
                rango.MergeCells = True
                filaexcel_2 = filaexcel_2 + 1
            Next
            rango = worksheet_2.Range("A11:J" & filaexcel_2 - 1)
            rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        End If
        '-------------------------------------------------------------------------------------
        '-------------------- llenado de insumos asociados al ciclo --------------------------
        filaexcel_2 = 11
        If grilla_insumos.RowCount > 0 Then
            worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetVisible
            worksheet_3.Cells(6, 3) = worksheet.Cells(7, 3)
            worksheet_3.Cells(7, 3) = worksheet.Cells(10, 2)
            worksheet_3.Cells(6, 6) = item
            For i = 0 To grilla_insumos.RowCount - 1
                worksheet_3.Cells(filaexcel_2, 1) = grilla_insumos.Rows(i).Cells(0).Value
                worksheet_3.Cells(filaexcel_2, 2) = grilla_insumos.Rows(i).Cells(1).Value
                worksheet_3.Cells(filaexcel_2, 8) = grilla_insumos.Rows(i).Cells(2).Value
                worksheet_3.Cells(filaexcel_2, 9) = grilla_insumos.Rows(i).Cells(3).Value
                worksheet_3.Cells(filaexcel_2, 10) = grilla_insumos.Rows(i).Cells(4).Value
                rango = worksheet_3.Range("B" & filaexcel_2 & ":G" & filaexcel_2)
                rango.MergeCells = True
                filaexcel_2 = filaexcel_2 + 1
            Next
            rango = worksheet_3.Range("A11:J" & filaexcel_2 - 1)
            rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        End If
        '--------------------------------------------------------------------------------------
        workbook.PrintOutEx(ActivePrinter:="doPDF v7")
        workbook.Close(False)
        excelApp.Quit()
    End Sub

    Public Sub expInfMpPDFSoloRealizadas(ByVal grilla_tareas_realizadas As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim worksheet_4 As Excel.Worksheet
        Dim worksheet_5 As Excel.Worksheet
        Dim filaexcel As Integer = 11
        Dim rango As Excel.Range

        excelApp = New Excel.Application
        workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_mp.xls")
        worksheet_1 = workbook.Sheets(1)
        worksheet_2 = workbook.Sheets(2)
        worksheet_3 = workbook.Sheets(3)
        worksheet_4 = workbook.Sheets(4)
        worksheet_5 = workbook.Sheets(5)
        worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_4.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_5.Visible = Excel.XlSheetVisibility.xlSheetVisible
        worksheet_5.Activate()

        worksheet_5.Cells(6, 3) = item

        For i = 0 To grilla_tareas_realizadas.RowCount - 1
            worksheet_5.Cells(filaexcel, 1) = grilla_tareas_realizadas.Rows(i).Cells(0).Value
            worksheet_5.Cells(filaexcel, 2) = grilla_tareas_realizadas.Rows(i).Cells(1).Value
            worksheet_5.Cells(filaexcel, 3) = grilla_tareas_realizadas.Rows(i).Cells(2).Value
            worksheet_5.Cells(filaexcel, 4) = grilla_tareas_realizadas.Rows(i).Cells(3).Value
            worksheet_5.Cells(filaexcel, 8) = grilla_tareas_realizadas.Rows(i).Cells(4).Value
            worksheet_5.Cells(filaexcel, 9) = grilla_tareas_realizadas.Rows(i).Cells(5).Value
            rango = worksheet_5.Range("D" & filaexcel & ":G" & filaexcel)
            rango.MergeCells = True
            rango = worksheet_5.Range("I" & filaexcel & ":L" & filaexcel)
            rango.MergeCells = True
            filaexcel = filaexcel + 1
        Next

        rango = worksheet_5.Range("A11:L" & filaexcel - 1)
        rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous

        workbook.PrintOutEx(ActivePrinter:="doPDF v7")
        workbook.Close(False)
        excelApp.Quit()
    End Sub

    Public Sub expInfMpPDFSoloPend(ByVal grilla_tareas_pend As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim worksheet_4 As Excel.Worksheet
        Dim worksheet_5 As Excel.Worksheet
        Dim filaexcel As Integer = 11
        Dim rango As Excel.Range

        excelApp = New Excel.Application
        workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_mp.xls")
        worksheet_1 = workbook.Sheets(1)
        worksheet_2 = workbook.Sheets(2)
        worksheet_3 = workbook.Sheets(3)
        worksheet_4 = workbook.Sheets(4)
        worksheet_5 = workbook.Sheets(5)
        worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_4.Visible = Excel.XlSheetVisibility.xlSheetVisible
        worksheet_5.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_4.Activate()

        worksheet_4.Cells(6, 3) = item

        For i = 0 To grilla_tareas_pend.RowCount - 1
            worksheet_4.Cells(filaexcel, 1) = grilla_tareas_pend.Rows(i).Cells(0).Value
            worksheet_4.Cells(filaexcel, 2) = grilla_tareas_pend.Rows(i).Cells(1).Value
            worksheet_4.Cells(filaexcel, 3) = grilla_tareas_pend.Rows(i).Cells(2).Value
            worksheet_4.Cells(filaexcel, 4) = grilla_tareas_pend.Rows(i).Cells(3).Value
            worksheet_4.Cells(filaexcel, 8) = grilla_tareas_pend.Rows(i).Cells(4).Value
            rango = worksheet_4.Range("D" & filaexcel & ":G" & filaexcel)
            rango.MergeCells = True
            rango = worksheet_4.Range("H" & filaexcel & ":K" & filaexcel)
            rango.MergeCells = True
            filaexcel = filaexcel + 1
        Next

        rango = worksheet_4.Range("A11:K" & filaexcel - 1)
        rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous

        workbook.PrintOutEx(ActivePrinter:="doPDF v7")
        workbook.Close(False)
        excelApp.Quit()
    End Sub

    Public Function ValidarMP() As String
        Dim msje_error As String = ""
        Dim fecha_hora_inicio As DateTime
        Dim fecha_hora_fin As DateTime

        With FrmMp
            fecha_hora_inicio = FormatDateTime(.FechaIniCiclo.Value, DateFormat.ShortDate) & " " & FormatDateTime(.HrInicioCiclo.Value, DateFormat.ShortTime)
            fecha_hora_fin = FormatDateTime(.fechaFinCicloMp.Value, DateFormat.ShortDate) & " " & FormatDateTime(.HrFinCiclo.Value, DateFormat.ShortTime)

            If .txtIdMant.Text = "" Then
                msje_error = "Debe buscar una mantencion" & Chr(13)
            End If

            If .txtIdCiclo.Text = "" Then
                msje_error = msje_error & "Debe buscar un ciclo" & Chr(13)
            End If

            If .txtFrecuenciaMp.Text = "" Then
                msje_error = msje_error & "La frecuencia de la MP es incorrecta" & Chr(13)
            End If

            If .txtTiempoAviso.Text = "" Then
                msje_error = msje_error & "El tiempo de aviso es incorrecto" & Chr(13)
            End If

            If fecha_hora_inicio > fecha_hora_fin Then
                msje_error = msje_error & "La fecha y hora de ciclo es incorrecta" & Chr(13)
            End If

            If .grillaTareasCicloMp.RowCount = 0 Then
                msje_error = msje_error & "Debe agregar al menos una tarea para el ciclo" & Chr(13)
            End If

            If .grillaTareasCicloMp.RowCount > 0 Then
                Dim tiempo_tarea As String

                For i = 0 To .grillaTareasCicloMp.RowCount - 1
                    tiempo_tarea = .grillaTareasCicloMp.Rows(i).Cells(3).Value.ToString
                    If tiempo_tarea = "" Then
                        msje_error = msje_error & "el tiempo de la tarea :" & .grillaTareasCicloMp.Rows(i).Cells(1).Value & " es incorrecto" & Chr(13)
                    End If
                Next

            End If
        End With

        Return msje_error
    End Function

    Public Sub UpdIdNodoTareasMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_tarea As String, ByVal id_nodo As String, ByVal cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_ID_NODO_TAREAS_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
            Dim p_id_tarea As SqlParameter = com.Parameters.AddWithValue("@id_tarea", CInt(id_tarea))
            Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
            
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

    Public Function hrsTranscurridasCicloMp(ByVal id_mp As String, ByVal id_ciclo As String) As Double
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim hrs_trans As Double = 0

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("CRG_HRS_TRANS_CICLO_MP", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_mp As SqlParameter = com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
            Dim p_id_ciclo_mp As SqlParameter = com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                hrs_trans = CDbl(DR(0).ToString)
                conexion.Desconectar(cnx)
                com.Dispose()
                Return hrs_trans
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Function
End Class
