Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class MantPreventiva

    Public Sub IngMantPreventiva(ByVal id_mp As String, ByVal id_nodo As String, ByVal frecuencia As String, ByVal tiempo_aviso_previo As String, ByVal estado_mp As String, ByVal tipo_mp As String, ByVal sesion As String, ByVal obs_mantencion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_MANT_PREVENTIVA", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idNodoInt, frecInt, avisoInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse
                   Not Utilitarios.TrySafeInt(id_nodo, idNodoInt) OrElse
                   Not Utilitarios.TrySafeInt(frecuencia, frecInt) OrElse
                   Not Utilitarios.TrySafeInt(tiempo_aviso_previo, avisoInt) Then
                    cod_resp = 0
                    resp = "Los identificadores y valores numéricos de MP, frecuencia y aviso deben ser válidos."
                    Exit Sub
                End If
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_nodo", idNodoInt)
                com.Parameters.AddWithValue("@frecuencia", frecInt)
                com.Parameters.AddWithValue("@tiempo_aviso", avisoInt)
                com.Parameters.AddWithValue("@estado_mp", If(estado_mp, String.Empty))
                Utilitarios.AgregarParametroFecha(com, "@fecha_creacion", DateTime.Today)
                com.Parameters.AddWithValue("@tipo_mantencion", If(tipo_mp, String.Empty))
                com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty))
                com.Parameters.AddWithValue("@obs_mantencion", If(obs_mantencion, String.Empty))
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Mantención Preventiva")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub IngPersonalCicloMp(ByVal rut As String, ByVal id_mp As String, ByVal id_ciclo As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_PERSONAL_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then Exit Sub
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                com.Parameters.AddWithValue("@rut", If(rut, String.Empty).Trim())

                com.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Personal Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub IngTareasCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_tarea As String, ByVal id_nodo As String, ByVal tiempo_tarea As String, ByVal obs_tarea As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_resp As Integer

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_TAREAS_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idCicloInt, idTareaInt, idNodoInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse
                   Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) OrElse
                   Not Utilitarios.TrySafeInt(id_tarea, idTareaInt) OrElse
                   Not Utilitarios.TrySafeInt(id_nodo, idNodoInt) Then
                    Exit Sub
                End If
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                com.Parameters.AddWithValue("@id_tarea", idTareaInt)
                com.Parameters.AddWithValue("@id_nodo", idNodoInt)
                com.Parameters.AddWithValue("@tiempo_tarea", Utilitarios.SafeDouble(tiempo_tarea, 0.0))
                com.Parameters.AddWithValue("@obs_tarea", If(obs_tarea, String.Empty))

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), 0, Convert.ToInt32(DR(0)))
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Tareas Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub IngCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal fecha_ini_ciclo As DateTime, ByVal hr_ini_ciclo As DateTime, ByVal fecha_fin_ciclo As DateTime, ByVal hr_fin_ciclo As DateTime, ByVal duracion As String, ByVal obs_ciclo As String, ByVal estado_ciclo As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then
                    cod_resp = 0
                    resp = "Identificador de MP o ciclo no válido."
                    Exit Sub
                End If
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                Utilitarios.AgregarParametroFecha(com, "@fecha_ini", Utilitarios.SafeSqlDateStart(fecha_ini_ciclo))
                Utilitarios.AgregarParametroFecha(com, "@hora_ini", Utilitarios.SafeSqlTime(hr_ini_ciclo))
                Utilitarios.AgregarParametroFecha(com, "@fecha_fin", Utilitarios.SafeSqlDateStart(fecha_fin_ciclo))
                Utilitarios.AgregarParametroFecha(com, "@hora_fin", Utilitarios.SafeSqlTime(hr_fin_ciclo))
                com.Parameters.AddWithValue("@duracion", Utilitarios.SafeDouble(duracion, 0.0))
                com.Parameters.AddWithValue("@obs_ciclo", If(obs_ciclo, String.Empty))
                com.Parameters.AddWithValue("@estado_ciclo", If(estado_ciclo, String.Empty))
                com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty))
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub IngTareasPendCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_tarea As String, ByVal id_nodo As String, ByVal obs_tarea As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_resp As Integer

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_TAREAS_PEND_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idCicloInt, idTareaInt, idNodoInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse
                   Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) OrElse
                   Not Utilitarios.TrySafeInt(id_tarea, idTareaInt) OrElse
                   Not Utilitarios.TrySafeInt(id_nodo, idNodoInt) Then
                    Exit Sub
                End If
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                com.Parameters.AddWithValue("@id_tarea", idTareaInt)
                com.Parameters.AddWithValue("@id_nodo", idNodoInt)
                com.Parameters.AddWithValue("@obs_tarea", If(obs_tarea, String.Empty))

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), 0, Convert.ToInt32(DR(0)))
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Tareas Pendientes Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub IngInsumosMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_insumo As String, ByVal cantidad As String, ByVal unid_medida As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_resp As Integer

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_INSUMOS_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idCicloInt, idInsInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse
                   Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) OrElse
                   Not Utilitarios.TrySafeInt(id_insumo, idInsInt) Then
                    Exit Sub
                End If
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                com.Parameters.AddWithValue("@id_insumo", idInsInt)
                com.Parameters.AddWithValue("@cantidad", Utilitarios.SafeInt(cantidad, 0))
                com.Parameters.AddWithValue("@unid_medida", If(unid_medida, String.Empty))

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), 0, Convert.ToInt32(DR(0)))
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Insumos MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub UpdMantPreventiva(ByVal id_mp As String, ByVal id_nodo As String, ByVal frecuencia As String, ByVal tiempo_aviso_previo As String, ByVal estado_mp As String, ByVal tipo_mp As String, ByVal sesion As String, ByVal obs_mantencion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_MANT_PREVENTIVA", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idNodoInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_nodo, idNodoInt) Then
                    cod_resp = 0
                    resp = "El ID de mantención preventiva o nodo no es válido."
                    Exit Sub
                End If
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_nodo", idNodoInt)
                com.Parameters.AddWithValue("@frecuencia", Utilitarios.SafeInt(frecuencia, 0))
                com.Parameters.AddWithValue("@tiempo_aviso_mp", Utilitarios.SafeInt(tiempo_aviso_previo, 0))
                com.Parameters.AddWithValue("@estado_mp", estado_mp)
                com.Parameters.AddWithValue("@tipo_mantencion", tipo_mp)
                com.Parameters.AddWithValue("@sesion", sesion)
                com.Parameters.AddWithValue("@obs_mantencion", obs_mantencion)
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Mantención Preventiva")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub UpdTareasCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_tarea As String, ByVal id_nodo As String, ByVal tiempo_tarea As String, ByVal obs_tarea As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_resp As Integer = 0
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_TAREAS_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idCicloInt, idTareaInt, idNodoInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse
                   Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) OrElse
                   Not Utilitarios.TrySafeInt(id_tarea, idTareaInt) OrElse
                   Not Utilitarios.TrySafeInt(id_nodo, idNodoInt) Then
                    Exit Sub
                End If
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                com.Parameters.AddWithValue("@id_tarea", idTareaInt)
                com.Parameters.AddWithValue("@id_nodo", idNodoInt)
                com.Parameters.AddWithValue("@tiempo_tarea", Utilitarios.SafeDouble(tiempo_tarea, 0.0))
                com.Parameters.AddWithValue("@obs_tarea", If(obs_tarea, String.Empty))

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), 0, Convert.ToInt32(DR(0)))
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Tareas Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub UpdInsumosCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_insumo As String, ByVal cantidad As String, ByVal unid_medida As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_resp As Integer = 0
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_INSUMOS_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idCicloInt, idInsInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse
                   Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) OrElse
                   Not Utilitarios.TrySafeInt(id_insumo, idInsInt) Then
                    Exit Sub
                End If
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                com.Parameters.AddWithValue("@id_insumo", idInsInt)
                com.Parameters.AddWithValue("@cantidad", Utilitarios.SafeInt(cantidad, 0))
                com.Parameters.AddWithValue("@unid_medida", If(unid_medida, String.Empty))

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), 0, Convert.ToInt32(DR(0)))
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Insumos Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub UpdCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal fecha_ini_ciclo As DateTime, ByVal hr_ini_ciclo As DateTime, ByVal fecha_fin_ciclo As DateTime, ByVal hr_fin_ciclo As DateTime, ByVal duracion As String, ByVal obs_ciclo As String, ByVal estado_ciclo As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then
                    cod_resp = 0
                    resp = "Identificador de MP o ciclo no válido."
                    Exit Sub
                End If
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                Utilitarios.AgregarParametroFecha(com, "@fecha_inicio", Utilitarios.SafeSqlDateStart(fecha_ini_ciclo))
                Utilitarios.AgregarParametroFecha(com, "@hora_inicio", Utilitarios.SafeSqlTime(hr_ini_ciclo))
                Utilitarios.AgregarParametroFecha(com, "@fecha_termino", Utilitarios.SafeSqlDateStart(fecha_fin_ciclo))
                Utilitarios.AgregarParametroFecha(com, "@hora_termino", Utilitarios.SafeSqlTime(hr_fin_ciclo))
                com.Parameters.AddWithValue("@duracion", Utilitarios.SafeDouble(duracion, 0.0))
                com.Parameters.AddWithValue("@obs_ciclo", If(obs_ciclo, String.Empty))
                com.Parameters.AddWithValue("@estado_ciclo", If(estado_ciclo, String.Empty))
                com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty))
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub UpdPersonalCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal rut As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_resp As Integer = 0
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_PERSONAL_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then Exit Sub
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                com.Parameters.AddWithValue("@rut", If(rut, String.Empty).Trim())

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Personal Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgCmbEstadoCiclo(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        combo.BeginUpdate()
        Try
            combo.Items.Clear()
            combo.Items.Add("Terminado")
            combo.Items.Add("Pendiente")
            If combo.Items.Count > 0 Then combo.Text = combo.Items(0).ToString()
        Finally
            combo.EndUpdate()
        End Try
    End Sub

    Public Sub CrgCmbEstadoMp(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        combo.BeginUpdate()
        Try
            combo.Items.Clear()
            combo.Items.Add("Activa")
            combo.Items.Add("Cerrada")
            If combo.Items.Count > 0 Then combo.Text = combo.Items(0).ToString()
        Finally
            combo.EndUpdate()
        End Try
    End Sub

    Public Sub CrgCmbTipoMp(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        combo.BeginUpdate()
        Try
            combo.Items.Clear()
            combo.Items.Add("Mecanica")
            combo.Items.Add("Mecanica Mayor")
            combo.Items.Add("Electrica")
            combo.Items.Add("Electrica Mayor")
            combo.Items.Add("Electronica")
            If combo.Items.Count > 0 Then combo.Text = combo.Items(0).ToString()
        Finally
            combo.EndUpdate()
        End Try
    End Sub

    Public Sub CrgCmbTipoMpGantt(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        combo.BeginUpdate()
        Try
            combo.Items.Clear()
            combo.Items.Add("Mecanica")
            combo.Items.Add("Mecanica Mayor")
            combo.Items.Add("Electrica")
            combo.Items.Add("Electrica Mayor")
            combo.Items.Add("Electronica")
            combo.Items.Add("Todos")
            If combo.Items.Count > 0 Then combo.Text = combo.Items(0).ToString()
        Finally
            combo.EndUpdate()
        End Try
    End Sub

    Public Sub CrgMpNodo(ByVal id_nodo As String, ByVal tipo_mp As String, ByRef DS As DataSet)
        If DS Is Nothing Then DS = New DataSet()
        Dim idNodoInt As Integer = Utilitarios.SafeInt(id_nodo, 1)
        If idNodoInt <= 0 Then idNodoInt = 1
        Dim tipoLimpio As String = If(String.IsNullOrWhiteSpace(tipo_mp), "Todos", tipo_mp.Trim())

        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_MP_NODO", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.SelectCommand.Parameters.AddWithValue("@id_nodo", idNodoInt)
                DA.SelectCommand.Parameters.AddWithValue("@tipo_mantencion", tipoLimpio)
                DA.Fill(DS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar MP Nodo")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgCicloMp(ByVal id_mp As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_CICLOS_MP_NODO", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim idMpInt As Integer = 0
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) Then Exit Sub
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", idMpInt)
                DA.Fill(DS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgPersonalCicloMp(ByVal id_mp As String, ByVal id_ciclo_mp As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_PERSONAL_CICLO_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo_mp, idCicloInt) Then Exit Sub
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", idMpInt)
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo_mp", idCicloInt)
                DA.Fill(DS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Personal Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene el identificador del nodo asociado a una mantención preventiva desde SQL Server.
    ''' </summary>
    Public Function ObtenerIdNodoMp(ByVal id_mp As String) As String
        Dim idMpInt As Integer = 0
        If Not Utilitarios.TrySafeInt(id_mp, idMpInt) Then Return String.Empty
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("SELECT TOP 1 idnodo FROM mant_preventiva WHERE idmant = @id_mp", cnx)
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                Dim res As Object = com.ExecuteScalar()
                If res IsNot Nothing AndAlso Not IsDBNull(res) Then
                    Return res.ToString().Trim()
                End If
            End Using
        Catch ex As Exception
            RegistroErrores.RegistrarError(ex, "Obtener Nodo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
        Return String.Empty
    End Function

    Public Sub CrgTareasCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal nodo_padre As String, ByRef DST As DataSet)
        If DST Is Nothing Then DST = New DataSet()
        Dim idMpInt, idCicloInt As Integer
        If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then Exit Sub

        Dim nodoPadreInt As Integer = 0
        If Not Utilitarios.TrySafeInt(nodo_padre, nodoPadreInt) OrElse nodoPadreInt <= 0 Then
            Dim idResuelto As String = ObtenerIdNodoMp(idMpInt.ToString())
            nodoPadreInt = Utilitarios.SafeInt(idResuelto, 1)
            If nodoPadreInt <= 0 Then nodoPadreInt = 1
        End If

        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_TAREAS_CICLO_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", idMpInt)
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", nodoPadreInt)
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Tareas Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgTareasPendCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_TAREAS_PEND_CICLO_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then Exit Sub
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", idMpInt)
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Tareas Pendientes Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgCmbCicloMp(ByRef combo As ComboBox, ByVal id_mp As String)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_CMB_CICLOS_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim idMpInt As Integer = 0
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) Then Exit Sub
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", idMpInt)
                Dim DS As New DataSet

                DA.Fill(DS)
                If DS.Tables.Count > 0 Then
                    combo.DataSource = DS.Tables(0)
                    combo.DisplayMember = "idciclo"
                    combo.ValueMember = "idciclo"
                End If
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Combo Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgInsumosCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_INSUMOS_CICLO_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then Exit Sub
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", idMpInt)
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Insumos Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgTareasNodoTodas(ByRef DST_TAREAS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_TAREAS_TODAS", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.Fill(DST_TAREAS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Tareas Nodo Todas")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgNodosHijosMp(ByVal nodo_padre As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_NODOS_HIJOS_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim nodoPadreInt As Integer = Utilitarios.SafeInt(nodo_padre, 1)
                If nodoPadreInt <= 0 Then nodoPadreInt = 1
                DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", nodoPadreInt)
                DA.Fill(DS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Nodos Hijos MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Function NuevoIdMp() As Integer
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Dim id_mp As Integer = 0

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("NUEVO_ID_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() AndAlso Not IsDBNull(DR(0)) Then
                        id_mp = Convert.ToInt32(DR(0))
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Nuevo ID MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
        Return id_mp
    End Function

    Public Function NuevoIdCicloMp(ByVal id_mp As String) As Integer
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Dim id_ciclo As Integer = 0

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("NUEVO_ID_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure
                Dim idMpInt As Integer = 0
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) Then Return 0
                com.Parameters.AddWithValue("@id_mp", idMpInt)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() AndAlso Not IsDBNull(DR(0)) Then
                        id_ciclo = Convert.ToInt32(DR(0))
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Nuevo ID Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
        Return id_ciclo
    End Function

    Public Function BuscarMp(ByVal id_mp As String) As Boolean
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim encontrado As Boolean = False

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("BUSCAR_MANT_PREVENTIVA", cnx)
                com.CommandType = CommandType.StoredProcedure
                Dim idMpInt As Integer = 0
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) Then Return False
                com.Parameters.AddWithValue("@id_mp", idMpInt)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() AndAlso Not IsDBNull(DR(0)) Then
                        If Convert.ToInt32(DR(0)) = 1 Then
                            encontrado = True
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
        Return encontrado
    End Function

    Public Function BuscarCicloMp(ByVal id_mp As String, ByVal id_ciclo As String) As Boolean
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim encontrado As Boolean = False

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("BUSCAR_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure
                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then Return False
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo_mp", idCicloInt)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() AndAlso Not IsDBNull(DR(0)) Then
                        If Convert.ToInt32(DR(0)) = 1 Then
                            encontrado = True
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
        Return encontrado
    End Function

    Public Function BuscarUltimoCicloMp(ByVal id_mp As String, ByVal id_ciclo As String) As Boolean
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim encontrado As Boolean = False

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("BUSCAR_ULTIMO_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure
                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then Return False
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo", idCicloInt)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() AndAlso Not IsDBNull(DR(0)) Then
                        If DR(0).ToString().Equals("True", StringComparison.OrdinalIgnoreCase) OrElse DR(0).ToString().Trim() = "1" Then
                            encontrado = True
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Ultimo Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
        Return encontrado
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

            .btnGuardarMp.Enabled = Usuario.PermisoGuardarMp
            .btnGuardarComoNuevoCiclo.Enabled = Usuario.PermisoIngMp OrElse Usuario.PermisoGuardarMp
            .btnNuevoCiclo.Enabled = Usuario.PermisoIngMp OrElse Usuario.PermisoGuardarMp
            .btnIngMp.Enabled = Usuario.PermisoIngMp
            .btnEliminarCiclo.Enabled = Usuario.PermisoEliminarCicloMp
            .btnEliminarMp.Enabled = Usuario.PermisoEliminarMp
            .form_limpio = True
            .lblHrsCiclo.Visible = False
            .hrsCiclo.Visible = False
            .hrsCiclo.Text = "0"
            .btnGuardarMp.Text = "Guardar"
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
            Using com As New SqlCommand("DEL_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then Exit Sub
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty))
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub DelMantPreventiva(ByVal id_mp As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("DEL_MANT_PREV", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt As Integer = 0
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) Then Exit Sub
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty))
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Mantención Preventiva")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub DelInsumoCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_insumo As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("DEL_INSUMO_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idCicloInt, idInsInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse
                   Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) OrElse
                   Not Utilitarios.TrySafeInt(id_insumo, idInsInt) Then
                    Exit Sub
                End If
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                com.Parameters.AddWithValue("@id_insumo", idInsInt)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Insumo Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub DelPersonalCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal rut As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("DEL_PERSONAL_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then Exit Sub
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                com.Parameters.AddWithValue("@rut", If(rut, String.Empty).Trim())

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Personal Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub DelTareaCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_tarea As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("DEL_TAREA_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim idMpInt, idCicloInt, idTareaInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse
                   Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) OrElse
                   Not Utilitarios.TrySafeInt(id_tarea, idTareaInt) Then
                    Exit Sub
                End If
                com.Parameters.AddWithValue("@id_mp", idMpInt)
                com.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                com.Parameters.AddWithValue("@id_tarea", idTareaInt)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Tarea Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Function ValidarIngresoMp(ByRef Form As FrmMp, ByRef resp As String) As Boolean
        Dim valida As Boolean = True
        Dim fecha_hr_ini As DateTime
        Dim fecha_hr_fin As DateTime
        resp = String.Empty

        fecha_hr_ini = Form.FechaIniCiclo.Value.Date.Add(New TimeSpan(Form.HrInicioCiclo.Value.Hour, Form.HrInicioCiclo.Value.Minute, 0))
        fecha_hr_fin = Form.fechaFinCicloMp.Value.Date.Add(New TimeSpan(Form.HrFinCiclo.Value.Hour, Form.HrFinCiclo.Value.Minute, 0))

        With Form
            If String.IsNullOrWhiteSpace(.id_nodo_select) Then
                valida = False
                resp &= "Debe seleccionar una máquina o nodo en el árbol." & Chr(13)
            End If
            If String.IsNullOrWhiteSpace(.txtIdMant.Text) Then
                valida = False
                resp &= "El campo N°Mant. no puede estar vacío" & Chr(13)
            End If
            If String.IsNullOrWhiteSpace(.txtFrecuenciaMp.Text) Then
                valida = False
                resp &= "Ingrese la Frecuencia en horas" & Chr(13)
            End If

            If String.IsNullOrWhiteSpace(.txtTiempoAviso.Text) Then
                valida = False
                resp &= "Ingrese el tiempo de aviso en horas" & Chr(13)
            End If

            If String.IsNullOrWhiteSpace(.cmbEstadoMp.Text) Then
                valida = False
                resp &= "Ingrese el estado de la mantención" & Chr(13)
            End If

            If String.IsNullOrWhiteSpace(.cmbTipoMp.Text) Then
                valida = False
                resp &= "Ingrese el tipo de mantención" & Chr(13)
            End If

            If String.IsNullOrWhiteSpace(.txtIdCiclo.Text) Then
                valida = False
                resp &= "Debe crear un ciclo antes de ingresar la mantención" & Chr(13)
            End If

            If fecha_hr_ini > fecha_hr_fin Then
                valida = False
                resp &= "La Fecha y hora de inicio no puede ser mayor a Fecha y hora de fin de ciclo" & Chr(13)
            End If

            If String.IsNullOrWhiteSpace(.txtDuracionCiclo.Text) Then
                valida = False
                resp &= "Debe calcular la duración del ciclo" & Chr(13)
            End If

            If .grillaTareasCicloMp.Rows.Count > 0 Then
                For i = 0 To .grillaTareasCicloMp.RowCount - 1
                    Dim row As DataGridViewRow = .grillaTareasCicloMp.Rows(i)
                    If row.IsNewRow Then Continue For
                    Dim chkVal As Boolean = False
                    Dim rawChk As Object = row.Cells(0).Value
                    If rawChk IsNot Nothing AndAlso Not IsDBNull(rawChk) Then
                        chkVal = True.Equals(rawChk) OrElse String.Equals(rawChk.ToString(), "True", StringComparison.OrdinalIgnoreCase)
                    End If
                    Dim tVal As String = If(row.Cells.Count > 5 AndAlso row.Cells(5).Value IsNot Nothing AndAlso Not IsDBNull(row.Cells(5).Value), row.Cells(5).Value.ToString().Trim(), String.Empty)
                    Dim obsVal As String = If(row.Cells.Count > 6 AndAlso row.Cells(6).Value IsNot Nothing AndAlso Not IsDBNull(row.Cells(6).Value), row.Cells(6).Value.ToString().Trim(), String.Empty)
                    Dim tiempoNum As Double = 0
                    If chkVal AndAlso (String.IsNullOrEmpty(tVal) OrElse Not Double.TryParse(tVal, tiempoNum) OrElse tiempoNum < 0) Then
                        valida = False
                        resp &= "Debe ingresar un tiempo válido para la tarea realizada: Fila N°" & (i + 1) & Chr(13)
                    ElseIf Not chkVal AndAlso String.IsNullOrEmpty(obsVal) Then
                        valida = False
                        resp &= "Para las tareas pendientes debe ingresar una observación (Fila N°" & (i + 1) & ")" & Chr(13)
                    End If
                Next
            Else
                valida = False
                resp &= "Debe ingresar al menos una tarea para el ciclo"
            End If

            If .grillaPersonalMp.Rows.Count > 0 Then
                For i = 0 To .grillaPersonalMp.RowCount - 1
                    Dim row As DataGridViewRow = .grillaPersonalMp.Rows(i)
                    If row.IsNewRow Then Continue For
                    If row.Cells(0).Value Is Nothing OrElse IsDBNull(row.Cells(0).Value) OrElse String.IsNullOrWhiteSpace(row.Cells(0).Value.ToString()) Then
                        valida = False
                        resp &= "Debe ingresar agregar una persona: Fila N°" & (i + 1) & Chr(13)
                    End If
                Next
            End If

            If .grillaInsumosMp.Rows.Count > 0 Then
                For i = 0 To .grillaInsumosMp.RowCount - 1
                    Dim row As DataGridViewRow = .grillaInsumosMp.Rows(i)
                    If row.IsNewRow Then Continue For
                    If row.Cells(3).Value Is Nothing OrElse IsDBNull(row.Cells(3).Value) OrElse String.IsNullOrWhiteSpace(row.Cells(3).Value.ToString()) Then
                        valida = False
                        resp &= "Debe ingresar la cantidad de insumos: Fila N°" & (i + 1) & Chr(13)
                    End If
                Next
            End If
            Return valida
        End With
    End Function

    Private Sub EjecutarConsultaInfMp(ByVal id_nodo As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByVal tipo_mp As String, ByVal opcion As Integer, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim idNodoInt As Integer = Math.Max(1, Utilitarios.SafeInt(id_nodo, 1))
            Dim tipoLimpio As String = If(String.IsNullOrWhiteSpace(tipo_mp), "Todos", tipo_mp.Trim())
            Dim filtroExtra As String = String.Empty

            If opcion = 1 Then
                filtroExtra = " AND (EXISTS (SELECT 1 FROM ciclo_mp cmp WHERE cmp.idmant = mp.idmant AND cmp.fecha_inicio BETWEEN @fecha_ini AND @fecha_fin) " &
                              " OR (mp.fecha_creacion BETWEEN @fecha_ini AND @fecha_fin AND NOT EXISTS (SELECT 1 FROM ciclo_mp cmp0 WHERE cmp0.idmant = mp.idmant))) "
            ElseIf opcion = 2 AndAlso Not String.Equals(tipoLimpio, "Todos", StringComparison.OrdinalIgnoreCase) Then
                filtroExtra = " AND mp.tipo_mantencion = @tipo_mp "
            End If

            Dim sql As String = "SELECT mp.idmant AS 'ID MP', mp.frecuencia AS 'Frecuencia(Hrs)', mp.tiempo_aviso AS 'Tiempo Aviso(Hrs)', " &
                                "mp.estado AS 'Estado', CONVERT(varchar(15), mp.fecha_creacion, 105) + ' ' + CONVERT(varchar(15), mp.fecha_creacion, 108) AS 'Fecha Creación', " &
                                "mp.tipo_mantencion AS 'Tipo' " &
                                "FROM mant_preventiva mp " &
                                "WHERE mp.idnodo = @id_nodo " & filtroExtra &
                                "ORDER BY mp.fecha_creacion DESC, mp.idmant DESC"

            Using DA As New SqlDataAdapter(sql, cnx)
                DA.SelectCommand.Parameters.AddWithValue("@id_nodo", idNodoInt)
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_ini", Utilitarios.SafeSqlDateStart(fecha_inicio))
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_fin", Utilitarios.SafeSqlDateEnd(fecha_fin))
                DA.SelectCommand.Parameters.AddWithValue("@tipo_mp", tipoLimpio)
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Mantención Preventiva")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub InfMpTodos(ByVal id_nodo As String, ByRef fecha_inicio As DateTime, ByRef fecha_fin As DateTime, ByRef tipo_mp As String, ByVal opcion As Integer, ByRef DST As DataSet)
        EjecutarConsultaInfMp(id_nodo, fecha_inicio, fecha_fin, tipo_mp, 3, DST)
    End Sub

    Public Sub InfCicloMp(ByVal id_mp As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim idMpInt As Integer = 0
            If Not Utilitarios.TrySafeInt(id_mp, idMpInt) Then Exit Sub

            Const sql As String = "SELECT idciclo AS 'ID Ciclo', " &
                                  "CONVERT(varchar(10), fecha_inicio, 105) + ' ' + CONVERT(varchar(10), hora_inicio, 108) AS 'Fecha / Hora Inicio', " &
                                  "CONVERT(varchar(10), fecha_termino, 105) + ' ' + CONVERT(varchar(10), hora_termino, 108) AS 'Fecha / Hora Termino', " &
                                  "duracion AS 'Duración(Hrs)', obs_ciclo AS 'Observación', estado_ciclo AS 'Estado' " &
                                  "FROM ciclo_mp " &
                                  "WHERE idmant = @id_mp " &
                                  "ORDER BY fecha_inicio DESC, idciclo DESC"

            Using DA As New SqlDataAdapter(sql, cnx)
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", idMpInt)
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub InfCicloMpPorRango(ByVal id_mp As String, ByVal fecha_ini As DateTime, ByVal fecha_fin As DateTime, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim idMpInt As Integer = 0
            If Not Utilitarios.TrySafeInt(id_mp, idMpInt) Then Exit Sub

            Const sql As String = "SELECT idciclo AS 'ID Ciclo', " &
                                  "CONVERT(varchar(10), fecha_inicio, 105) + ' ' + CONVERT(varchar(10), hora_inicio, 108) AS 'Fecha / Hora Inicio', " &
                                  "CONVERT(varchar(10), fecha_termino, 105) + ' ' + CONVERT(varchar(10), hora_termino, 108) AS 'Fecha / Hora Termino', " &
                                  "duracion AS 'Duración(Hrs)', obs_ciclo AS 'Observación', estado_ciclo AS 'Estado' " &
                                  "FROM ciclo_mp " &
                                  "WHERE idmant = @id_mp " &
                                  "AND fecha_inicio BETWEEN @fecha_ini AND @fecha_fin " &
                                  "ORDER BY fecha_inicio DESC, idciclo DESC"

            Using DA As New SqlDataAdapter(sql, cnx)
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", idMpInt)
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_ini", Utilitarios.SafeSqlDateStart(fecha_ini))
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_fin", Utilitarios.SafeSqlDateEnd(fecha_fin))
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Ciclo MP Por Rango")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Function ObtenerCabeceraMp(ByVal id_mp As Integer) As DataRow
        If id_mp <= 0 Then Return Nothing
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Const sql As String = "SELECT mp.idmant, mp.idnodo, ISNULL(n.desc_nodo, '') AS desc_nodo, " &
                                  "mp.frecuencia, mp.tiempo_aviso, mp.estado, " &
                                  "CONVERT(varchar(15), mp.fecha_creacion, 105) + ' ' + CONVERT(varchar(15), mp.fecha_creacion, 108) AS fecha_creacion, " &
                                  "mp.tipo_mantencion " &
                                  "FROM mant_preventiva mp " &
                                  "LEFT JOIN nodo n ON n.idnodo = mp.idnodo " &
                                  "WHERE mp.idmant = @id_mp"
            Using DA As New SqlDataAdapter(sql, cnx)
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", id_mp)
                Dim dt As New DataTable()
                DA.Fill(dt)
                If dt.Rows.Count > 0 Then Return dt.Rows(0)
            End Using
        Catch ex As Exception
            RegistroErrores.RegistrarError(ex, "Obtener Cabecera MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
        Return Nothing
    End Function

    Public Sub InfTareasCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal nodo_padre As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_TAREAS_CICLO_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then Exit Sub
                Dim nodoPadreInt As Integer = Utilitarios.SafeInt(nodo_padre, 0)
                If nodoPadreInt <= 0 Then nodoPadreInt = Utilitarios.SafeInt(ObtenerIdNodoMp(idMpInt.ToString()), 1)
                If nodoPadreInt <= 0 Then nodoPadreInt = 1
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", idMpInt)
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", nodoPadreInt)
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Tareas Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub InfMpFechas(ByVal id_nodo As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByVal tipo_mp As String, ByVal opcion As Integer, ByRef DST As DataSet)
        EjecutarConsultaInfMp(id_nodo, fecha_inicio, fecha_fin, tipo_mp, 1, DST)
    End Sub

    Public Sub InfMpTipoMp(ByVal id_nodo As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByVal tipo_mp As String, ByVal opcion As Integer, ByRef DST As DataSet)
        EjecutarConsultaInfMp(id_nodo, fecha_inicio, fecha_fin, tipo_mp, 2, DST)
    End Sub

    Public Sub InfSoloTareasMp(ByVal opcion As String, ByVal id_nodo As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim opcInt As Integer = Utilitarios.SafeInt(opcion, 0)
            Dim nodoInt As Integer = Math.Max(1, Utilitarios.SafeInt(id_nodo, 1))

            Dim sql As String
            If opcInt = 1 Then
                sql = "WITH NODOS AS ( " &
                      "    SELECT n.nodo_padre, n.idnodo FROM nodo n WHERE n.idnodo = @id_nodo " &
                      "    UNION ALL " &
                      "    SELECT n.nodo_padre, n.idnodo FROM nodo n INNER JOIN NODOS nds ON n.nodo_padre = nds.idnodo " &
                      ") " &
                      "SELECT cmpt.idmant AS [ID MP], cmpt.idciclo AS [ID Ciclo], cmpt.idtarea AS [ID Tarea], " &
                      "       tn.desc_tarea AS [Descripcion Tarea], CAST(cmpt.tiempo_tarea AS varchar(30)) AS [Tiempo Tarea], cmpt.obs_tarea AS [Observacion Tarea] " &
                      "FROM NODOS nds " &
                      "INNER JOIN ciclomp_tareas cmpt ON cmpt.id_nodo = nds.idnodo " &
                      "INNER JOIN tareas_nodo tn ON cmpt.idtarea = tn.idtarea " &
                      "UNION ALL " &
                      "SELECT h.id_mant AS [ID MP], h.id_ciclo AS [ID Ciclo], h.id_tarea AS [ID Tarea], " &
                      "       h.desc_tarea AS [Descripcion Tarea], CAST(h.duracion AS varchar(30)) AS [Tiempo Tarea], h.obs_tarea AS [Observacion Tarea] " &
                      "FROM NODOS nds " &
                      "INNER JOIN ciclo_mp_tareas_historico h ON h.id_nodo = nds.idnodo " &
                      "WHERE NOT EXISTS (SELECT 1 FROM ciclomp_tareas c2 WHERE c2.idmant = h.id_mant AND c2.idciclo = h.id_ciclo AND c2.idtarea = h.id_tarea AND c2.id_nodo = h.id_nodo) " &
                      "ORDER BY [ID MP] DESC, [ID Ciclo] DESC, [ID Tarea] ASC"
            Else
                sql = "WITH NODOS AS ( " &
                      "    SELECT n.nodo_padre, n.idnodo FROM nodo n WHERE n.idnodo = @id_nodo " &
                      "    UNION ALL " &
                      "    SELECT n.nodo_padre, n.idnodo FROM nodo n INNER JOIN NODOS nds ON n.nodo_padre = nds.idnodo " &
                      ") " &
                      "SELECT cmptp.idmant AS [ID MP], cmptp.idciclo AS [ID Ciclo], cmptp.idtarea AS [ID Tarea], " &
                      "       tn.desc_tarea AS [Descripcion Tarea], cmptp.obs_tarea AS [Observacion Tarea] " &
                      "FROM NODOS nds " &
                      "INNER JOIN ciclo_mp_tareas_pendientes cmptp ON cmptp.id_nodo = nds.idnodo " &
                      "INNER JOIN tareas_nodo tn ON cmptp.idtarea = tn.idtarea " &
                      "ORDER BY [ID MP] DESC, [ID Ciclo] DESC, [ID Tarea] ASC"
            End If

            Using DA As New SqlDataAdapter(sql, cnx)
                DA.SelectCommand.Parameters.AddWithValue("@id_nodo", nodoInt)
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Solo Tareas MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub InfPersonalCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_PERSONAL_CICLO_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then Exit Sub
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", idMpInt)
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Personal Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub InfInsumosCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_INSUMOS_CICLO_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then Exit Sub
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", idMpInt)
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Insumos Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub InfTareasPendCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal nodo_padre As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_TAREAS_PEND_CICLO_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim idMpInt, idCicloInt As Integer
                If Not Utilitarios.TrySafeInt(id_mp, idMpInt) OrElse Not Utilitarios.TrySafeInt(id_ciclo, idCicloInt) Then Exit Sub
                Dim nodoPadreInt As Integer = Utilitarios.SafeInt(nodo_padre, 0)
                If nodoPadreInt <= 0 Then nodoPadreInt = Utilitarios.SafeInt(ObtenerIdNodoMp(idMpInt.ToString()), 1)
                If nodoPadreInt <= 0 Then nodoPadreInt = 1
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", idMpInt)
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", nodoPadreInt)
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Tareas Pendientes Ciclo MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub InfCiclosMaquinasMp(ByVal id_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByVal tipo_mantencion As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim idPadreInt As Integer = Math.Max(1, Utilitarios.SafeInt(id_padre, 1))
            Dim tipoLimpio As String = If(tipo_mantencion, String.Empty).Trim()

            Const sql As String =
                "WITH NODOS AS (" &
                "  SELECT n.nodo_padre, n.idnodo, n.desc_nodo FROM nodo n WHERE n.idnodo = @nodo_padre " &
                "  UNION ALL " &
                "  SELECT n.nodo_padre, n.idnodo, n.desc_nodo FROM nodo n INNER JOIN NODOS nds ON n.nodo_padre = nds.idnodo" &
                ") " &
                "SELECT cmp.idciclo AS 'ID Ciclo', " &
                "       ISNULL((SELECT TOP 1 p.desc_nodo FROM nodo p WHERE p.idnodo = nds.nodo_padre), '') AS 'Sección', " &
                "       nds.desc_nodo AS 'Item / Máquina', " &
                "       cmp.obs_ciclo AS 'Observación', " &
                "       CONVERT(varchar(10), cmp.fecha_inicio, 105) AS 'Fecha Inicio', " &
                "       CONVERT(varchar(10), cmp.fecha_termino, 105) AS 'Fecha Termino', " &
                "       cmp.duracion AS 'Duración(Hrs)', " &
                "       mp.idmant AS 'ID MP', " &
                "       ISNULL(cmp.estado_ciclo, '') AS 'Estado', " &
                "       ISNULL(mp.tipo_mantencion, '') AS 'Tipo', " &
                "       CONVERT(varchar(10), mp.fecha_creacion, 105) AS 'Fecha Creación' " &
                "FROM NODOS nds " &
                "INNER JOIN mant_preventiva mp ON nds.idnodo = mp.idnodo " &
                "INNER JOIN ciclo_mp cmp ON mp.idmant = cmp.idmant " &
                "WHERE cmp.fecha_inicio BETWEEN @fecha_inicio_ciclo AND @fecha_fin_ciclo " &
                "  AND (@tipo_mantencion = '' OR @tipo_mantencion = 'Todos' OR mp.tipo_mantencion = @tipo_mantencion) " &
                "ORDER BY mp.fecha_creacion DESC, mp.idmant DESC, cmp.fecha_inicio DESC, cmp.idciclo DESC"

            Using DA As New SqlDataAdapter(sql, cnx)
                DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", idPadreInt)
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_inicio_ciclo", Utilitarios.SafeSqlDateStart(fecha_inicio))
                Utilitarios.AgregarParametroFecha(DA.SelectCommand, "@fecha_fin_ciclo", Utilitarios.SafeSqlDateEnd(fecha_fin))
                DA.SelectCommand.Parameters.AddWithValue("@tipo_mantencion", tipoLimpio)
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Informe Ciclos Maquinas MP")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub exportarInfMpExcel(ByRef grilla_mp As DataGridView, ByRef grilla_ciclo As DataGridView, ByRef grilla_tareas_r As DataGridView, ByVal grilla_personal As DataGridView, ByVal grilla_tareas_pend As DataGridView, ByVal grilla_insumos As DataGridView, ByVal item As String)
        If grilla_mp Is Nothing OrElse grilla_mp.CurrentRow Is Nothing OrElse grilla_ciclo Is Nothing OrElse grilla_ciclo.CurrentRow Is Nothing Then
            MsgBox("Debe seleccionar una mantención preventiva y un ciclo antes de exportar.", MsgBoxStyle.Exclamation, "Validación")
            Return
        End If
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim worksheet_4 As Excel.Worksheet
        Dim worksheet_5 As Excel.Worksheet

        Try
            excelApp = New Excel.Application
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, True)
            workbook = Utilitarios.CrearLibroDesdePlantilla(excelApp, "inf_MP.xls")
            worksheet = CType(workbook.Sheets(1), Excel.Worksheet)
            worksheet_2 = CType(workbook.Sheets(2), Excel.Worksheet)
            worksheet_3 = CType(workbook.Sheets(3), Excel.Worksheet)
            worksheet_4 = CType(workbook.Sheets(4), Excel.Worksheet)
            worksheet_5 = CType(workbook.Sheets(5), Excel.Worksheet)
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
            worksheet.Activate()
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Excel")
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            Dim hojas As New List(Of KeyValuePair(Of String, DataGridView))()
            If grilla_mp IsNot Nothing AndAlso grilla_mp.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Mantención", grilla_mp))
            If grilla_ciclo IsNot Nothing AndAlso grilla_ciclo.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Ciclos", grilla_ciclo))
            If grilla_tareas_r IsNot Nothing AndAlso grilla_tareas_r.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Tareas Realizadas", grilla_tareas_r))
            If grilla_tareas_pend IsNot Nothing AndAlso grilla_tareas_pend.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Tareas Pendientes", grilla_tareas_pend))
            If grilla_personal IsNot Nothing AndAlso grilla_personal.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Personal", grilla_personal))
            If grilla_insumos IsNot Nothing AndAlso grilla_insumos.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Insumos", grilla_insumos))
            If hojas.Count > 0 AndAlso (Utilitarios.ExportarGrillasAExcelNativo(hojas, "Informe_MP_" & item, "INFORME DE MANTENCIÓN PREVENTIVA", "Ítem / Máquina: " & item) OrElse Utilitarios.UltimaExportacionCancelada) Then
                Exit Sub
            End If
            RegistroErrores.MostrarYRegistrar(ex, "Exportar Informe MP Excel")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Sub ExportarSoloTareasInfMp(ByVal grilla As DataGridView, ByVal item As String, ByVal soloRealizadas As Boolean, ByVal esPdf As Boolean)
        Dim etiquetaTipo As String = If(soloRealizadas, "tareas realizadas", "tareas pendientes")
        If grilla Is Nothing OrElse grilla.RowCount = 0 Then
            MsgBox(String.Format("No hay {0} para exportar.", etiquetaTipo), MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Dim prefijo As String = If(soloRealizadas, "Informe_MP_Realizadas_", "Informe_MP_Pendientes_") & item
        Dim tituloDoc As String = "INFORME DE MANTENCIÓN PREVENTIVA - TAREAS " & If(soloRealizadas, "REALIZADAS", "PENDIENTES")
        Dim subtitulo As String = "Ítem / Máquina: " & item
        Dim rutaPdf As String = String.Empty
        If esPdf Then
            rutaPdf = Utilitarios.SolicitarRutaGuardadoPdf(prefijo)
            If String.IsNullOrEmpty(rutaPdf) Then Exit Sub
        End If

        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim wsTarget As Excel.Worksheet = Nothing

        Try
            excelApp = New Excel.Application
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, True)
            workbook = Utilitarios.CrearLibroDesdePlantilla(excelApp, "inf_MP.xls")

            For idx As Integer = 1 To workbook.Sheets.Count
                Dim ws As Excel.Worksheet = CType(workbook.Sheets(idx), Excel.Worksheet)
                Dim esDestino As Boolean = (soloRealizadas AndAlso idx = 5) OrElse ((Not soloRealizadas) AndAlso idx = 4)
                ws.Visible = If(esDestino, Excel.XlSheetVisibility.xlSheetVisible, Excel.XlSheetVisibility.xlSheetHidden)
                If esDestino Then wsTarget = ws
            Next

            wsTarget.Activate()
            wsTarget.Cells(6, 3) = item
            If soloRealizadas Then
                wsTarget.Cells(9, 1) = "Tareas Realizadas"
            End If

            Dim totalFilas As Integer = grilla.RowCount
            Dim filaInicio As Integer = 11
            Dim filaFin As Integer = filaInicio + totalFilas - 1
            Dim arrBase(totalFilas - 1, 3) As Object
            Dim arrExtra(totalFilas - 1, If(soloRealizadas, 1, 0)) As Object

            For i As Integer = 0 To totalFilas - 1
                arrBase(i, 0) = grilla.Rows(i).Cells(0).Value
                arrBase(i, 1) = grilla.Rows(i).Cells(1).Value
                arrBase(i, 2) = grilla.Rows(i).Cells(2).Value
                arrBase(i, 3) = grilla.Rows(i).Cells(3).Value
                If soloRealizadas Then
                    arrExtra(i, 0) = grilla.Rows(i).Cells(4).Value
                    arrExtra(i, 1) = If(grilla.ColumnCount > 5, grilla.Rows(i).Cells(5).Value, "")
                Else
                    arrExtra(i, 0) = If(grilla.ColumnCount > 4, grilla.Rows(i).Cells(4).Value, "")
                End If
            Next

            wsTarget.Range("A" & filaInicio & ":D" & filaFin).Value2 = arrBase
            Dim colExtraFin As String = If(soloRealizadas, "I", "H")
            wsTarget.Range("H" & filaInicio & ":" & colExtraFin & filaFin).Value2 = arrExtra

            Dim colUltima As String = If(soloRealizadas, "L", "K")
            For f As Integer = filaInicio To filaFin
                wsTarget.Range("D" & f & ":G" & f).MergeCells = True
                If soloRealizadas Then
                    wsTarget.Range("I" & f & ":L" & f).MergeCells = True
                Else
                    wsTarget.Range("H" & f & ":K" & f).MergeCells = True
                End If
            Next

            Dim rangoTabla As Excel.Range = wsTarget.Range("A11:" & colUltima & filaFin)
            rangoTabla.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            wsTarget.PageSetup.PrintArea = "$A$1:$" & colUltima & "$" & filaFin.ToString()

            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            If esPdf Then
                Utilitarios.ImprimirLibroAPdfWindows(excelApp, workbook, rutaPdf, prefijo)
            Else
                wsTarget.Activate()
                MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Excel")
                excelApp.Visible = True
            End If
        Catch ex As Exception
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            If Not esPdf Then Utilitarios.CerrarExcelEnError(excelApp, workbook)
            Try
                If esPdf Then
                    If Utilitarios.ExportarGrillaAPdf(grilla, rutaPdf, tituloDoc, subtitulo) Then
                        If MessageBox.Show("Archivo PDF generado exitosamente mediante motor nativo en:" & Environment.NewLine & rutaPdf & Environment.NewLine & Environment.NewLine & "¿Desea abrir el documento PDF ahora?", "Exportación PDF Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            Utilitarios.AbrirDocumento(rutaPdf)
                        End If
                        Exit Sub
                    End If
                Else
                    If Utilitarios.ExportarGrillaAExcelNativo(grilla, prefijo, tituloDoc, subtitulo) OrElse Utilitarios.UltimaExportacionCancelada Then
                        Exit Sub
                    End If
                End If
            Catch
            End Try
            RegistroErrores.MostrarYRegistrar(ex, If(esPdf, "Exportar Tareas MP a PDF", "Exportar Tareas MP a Excel"))
        Finally
            If esPdf Then Utilitarios.LiberarExcel(workbook, excelApp)
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Public Sub expInfMpExcelSoloRealizadas(ByVal grilla_tareas_realizadas As DataGridView, ByVal item As String)
        ExportarSoloTareasInfMp(grilla_tareas_realizadas, item, True, False)
    End Sub

    Public Sub expInfMpExcelSoloPend(ByVal grilla_tareas_pend As DataGridView, ByVal item As String)
        ExportarSoloTareasInfMp(grilla_tareas_pend, item, False, False)
    End Sub

    Public Sub expInfGanttTodo(ByVal grilla_info_mp As DataGridView, ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item As String)
        Dim inf As New Informes()
        inf.expInfGanttTodo(grilla_info_mp, grilla_ciclos_mp, grilla_grafico, item)
    End Sub

    Public Sub exportarInfMpPDF(ByRef grilla_mp As DataGridView, ByRef grilla_ciclo As DataGridView, ByRef grilla_tareas_r As DataGridView, ByVal grilla_personal As DataGridView, ByVal grilla_tareas_pend As DataGridView, ByVal grilla_insumos As DataGridView, ByVal item As String)
        If grilla_mp Is Nothing OrElse grilla_mp.CurrentRow Is Nothing OrElse grilla_ciclo Is Nothing OrElse grilla_ciclo.CurrentRow Is Nothing Then
            MsgBox("Debe seleccionar una mantención preventiva y un ciclo antes de exportar a PDF.", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If
        Dim rutaPdf As String = Utilitarios.SolicitarRutaGuardadoPdf("Informe_MP_" & item)
        If String.IsNullOrEmpty(rutaPdf) Then Exit Sub

        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim worksheet_4 As Excel.Worksheet
        Dim worksheet_5 As Excel.Worksheet

        Try
            excelApp = New Excel.Application
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, True)
            workbook = Utilitarios.CrearLibroDesdePlantilla(excelApp, "inf_MP.xls")
            worksheet = CType(workbook.Sheets(1), Excel.Worksheet)
            worksheet_2 = CType(workbook.Sheets(2), Excel.Worksheet)
            worksheet_3 = CType(workbook.Sheets(3), Excel.Worksheet)
            worksheet_4 = CType(workbook.Sheets(4), Excel.Worksheet)
            worksheet_5 = CType(workbook.Sheets(5), Excel.Worksheet)
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

                worksheet_2.Cells(5, 2) = item 'nombre item o maquina
                worksheet_2.Cells(6, 2) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(0).Value ' id mantencion
                worksheet_2.Cells(5, 6) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(1).Value ' frecuencia mp
                worksheet_2.Cells(6, 6) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(2).Value ' tiempo aviso previo
                worksheet_2.Cells(5, 12) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(3).Value ' estado
                worksheet_2.Cells(5, 9) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(4).Value ' fecha creacion
                worksheet_2.Cells(6, 9) = grilla_mp.Rows(grilla_mp.CurrentRow.Index).Cells(5).Value ' tipo de mantencion

                worksheet_2.Cells(9, 2) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(0).Value ' n° ciclo
                worksheet_2.Cells(9, 5) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(1).Value ' fecha / hora inicio 
                worksheet_2.Cells(9, 8) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(2).Value ' fecha / hora termino
                worksheet_2.Cells(9, 10) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(3).Value ' duracion
                worksheet_2.Cells(10, 2) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(4).Value ' observacion ciclo
                worksheet_2.Cells(9, 12) = grilla_ciclo.Rows(grilla_ciclo.CurrentRow.Index).Cells(5).Value ' estado ciclo

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
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            Utilitarios.ImprimirLibroAPdfWindows(excelApp, workbook, rutaPdf, "Informe_MP_" & item)
        Catch ex As Exception
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            ' Respaldo 100% nativo con iTextSharp si Excel no está disponible o falla
            Try
                Dim secciones As New List(Of KeyValuePair(Of String, DataGridView))()
                If grilla_mp IsNot Nothing AndAlso grilla_mp.RowCount > 0 Then secciones.Add(New KeyValuePair(Of String, DataGridView)("Mantenciones Preventivas", grilla_mp))
                If grilla_ciclo IsNot Nothing AndAlso grilla_ciclo.RowCount > 0 Then secciones.Add(New KeyValuePair(Of String, DataGridView)("Detalle de Ciclos", grilla_ciclo))
                If grilla_tareas_r IsNot Nothing AndAlso grilla_tareas_r.RowCount > 0 Then secciones.Add(New KeyValuePair(Of String, DataGridView)("Tareas Realizadas", grilla_tareas_r))
                If grilla_tareas_pend IsNot Nothing AndAlso grilla_tareas_pend.RowCount > 0 Then secciones.Add(New KeyValuePair(Of String, DataGridView)("Tareas Pendientes", grilla_tareas_pend))
                If grilla_personal IsNot Nothing AndAlso grilla_personal.RowCount > 0 Then secciones.Add(New KeyValuePair(Of String, DataGridView)("Personal Asignado", grilla_personal))
                If grilla_insumos IsNot Nothing AndAlso grilla_insumos.RowCount > 0 Then secciones.Add(New KeyValuePair(Of String, DataGridView)("Insumos Utilizados", grilla_insumos))
                If secciones.Count > 0 AndAlso Utilitarios.ExportarGrillasAPdfNativo(secciones, rutaPdf, "INFORME DE MANTENCIÓN PREVENTIVA", "Ítem / Máquina: " & item) Then
                    If MessageBox.Show("Archivo PDF generado exitosamente mediante motor nativo en:" & Environment.NewLine & rutaPdf & Environment.NewLine & Environment.NewLine & "¿Desea abrir el documento PDF ahora?", "Exportación PDF Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                        Utilitarios.AbrirDocumento(rutaPdf)
                    End If
                    Exit Sub
                End If
            Catch
            End Try
            RegistroErrores.MostrarYRegistrar(ex, "Exportar Informe MP a PDF")
        Finally
            Utilitarios.LiberarExcel(workbook, excelApp)
        End Try
    End Sub

    Public Sub expInfMpPDFSoloRealizadas(ByVal grilla_tareas_realizadas As DataGridView, ByVal item As String)
        ExportarSoloTareasInfMp(grilla_tareas_realizadas, item, True, True)
    End Sub

    Public Sub expInfMpPDFSoloPend(ByVal grilla_tareas_pend As DataGridView, ByVal item As String)
        ExportarSoloTareasInfMp(grilla_tareas_pend, item, False, True)
    End Sub

    Public Function ValidarMP() As String
        Dim msje_error As String = ""
        Dim fecha_hora_inicio As DateTime
        Dim fecha_hora_fin As DateTime

        With FrmMp
            fecha_hora_inicio = .FechaIniCiclo.Value.Date.Add(New TimeSpan(.HrInicioCiclo.Value.Hour, .HrInicioCiclo.Value.Minute, 0))
            fecha_hora_fin = .fechaFinCicloMp.Value.Date.Add(New TimeSpan(.HrFinCiclo.Value.Hour, .HrFinCiclo.Value.Minute, 0))

            If String.IsNullOrWhiteSpace(.txtIdMant.Text) Then
                msje_error = "Debe buscar una mantención" & Chr(13)
            End If

            If String.IsNullOrWhiteSpace(.txtIdCiclo.Text) Then
                msje_error &= "Debe buscar un ciclo" & Chr(13)
            End If

            If String.IsNullOrWhiteSpace(.txtFrecuenciaMp.Text) Then
                msje_error &= "La frecuencia de la MP es incorrecta" & Chr(13)
            End If

            If String.IsNullOrWhiteSpace(.txtTiempoAviso.Text) Then
                msje_error &= "El tiempo de aviso es incorrecto" & Chr(13)
            End If

            If fecha_hora_inicio > fecha_hora_fin Then
                msje_error &= "La fecha y hora de ciclo es incorrecta" & Chr(13)
            End If

            If .grillaTareasCicloMp.RowCount = 0 Then
                msje_error &= "Debe agregar al menos una tarea para el ciclo" & Chr(13)
            Else
                For i = 0 To .grillaTareasCicloMp.RowCount - 1
                    Dim row As DataGridViewRow = .grillaTareasCicloMp.Rows(i)
                    If row.IsNewRow Then Continue For
                    Dim descTarea As String = If(row.Cells.Count > 4 AndAlso row.Cells(4).Value IsNot Nothing AndAlso Not IsDBNull(row.Cells(4).Value), row.Cells(4).Value.ToString(), "Fila " & (i + 1))
                    Dim tiempo_tarea As String = If(row.Cells.Count > 5 AndAlso row.Cells(5).Value IsNot Nothing AndAlso Not IsDBNull(row.Cells(5).Value), row.Cells(5).Value.ToString().Trim(), String.Empty)
                    Dim tiempoNum As Double = 0
                    If String.IsNullOrEmpty(tiempo_tarea) OrElse Not Double.TryParse(tiempo_tarea, tiempoNum) OrElse tiempoNum < 0 Then
                        msje_error &= "El tiempo de la tarea: " & descTarea & " es incorrecto" & Chr(13)
                    End If
                Next
            End If
        End With

        Return msje_error
    End Function

    Public Sub UpdIdNodoTareasMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal id_tarea As String, ByVal id_nodo As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = -1
        resp = String.Empty
        Dim idMpInt, idCicloInt, idTareaInt, idNodoInt As Integer
        If Not Integer.TryParse(If(id_mp, String.Empty).Trim(), idMpInt) OrElse
           Not Integer.TryParse(If(id_ciclo, String.Empty).Trim(), idCicloInt) OrElse
           Not Integer.TryParse(If(id_tarea, String.Empty).Trim(), idTareaInt) OrElse
           Not Integer.TryParse(If(id_nodo, String.Empty).Trim(), idNodoInt) Then
            resp = "Identificadores inválidos para actualizar tareas de MP."
            Return
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("UPD_ID_NODO_TAREAS_CICLO_MP", cnx)
                    com.CommandType = CommandType.StoredProcedure

                    com.Parameters.AddWithValue("@id_mp", idMpInt)
                    com.Parameters.AddWithValue("@id_ciclo", idCicloInt)
                    com.Parameters.AddWithValue("@id_tarea", idTareaInt)
                    com.Parameters.AddWithValue("@id_nodo", idNodoInt)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), 0, Convert.ToInt32(DR(0)))
                            resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            resp = ex.Message
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar ID Nodo Tareas MP")
        End Try
    End Sub

    Public Function hrsTranscurridasCicloMp(ByVal id_mp As String, ByVal id_ciclo As String) As Double
        Dim conexion As New Conexion
        Dim hrs_trans As Double = 0
        Dim idMpInt, idCicloInt As Integer
        If Not Integer.TryParse(If(id_mp, String.Empty).Trim(), idMpInt) OrElse
           Not Integer.TryParse(If(id_ciclo, String.Empty).Trim(), idCicloInt) Then
            Return 0
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("CRG_HRS_TRANS_CICLO_MP", cnx)
                    com.CommandType = CommandType.StoredProcedure

                    com.Parameters.AddWithValue("@id_mp", idMpInt)
                    com.Parameters.AddWithValue("@id_ciclo", idCicloInt)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() AndAlso Not IsDBNull(DR(0)) Then
                            Double.TryParse(DR(0).ToString(), hrs_trans)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Horas Transcurridas Ciclo MP")
        End Try
        Return hrs_trans
    End Function

    ''' <summary>
    ''' Carga el detalle enriquecido de ciclos de mantención preventiva para Carta Gantt
    ''' (incluye N° Mantención, ID Ciclo, nodo, sección, máquina, tipo, estado, fechas y horas),
    ''' permitiendo filtrar por nodo padre, rango de fechas, tipo, N° Mantención e ID Ciclo.
    ''' </summary>
    Public Function CrgDatosGanttDetallado(ByVal idPadre As Integer,
                                           ByVal fechaInicio As DateTime,
                                           ByVal fechaFin As DateTime,
                                           ByVal tipoMp As String,
                                           Optional ByVal idMantFiltro As Integer = 0,
                                           Optional ByVal idCicloFiltro As Integer = 0,
                                           Optional ByVal ignorarFechasPorId As Boolean = False) As DataTable
        Dim dt As New DataTable("GanttDetallado")
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Dim sql As String =
                "WITH NODOS AS (" &
                "  SELECT n.nodo_padre, n.idnodo, n.desc_nodo FROM nodo n WHERE n.idnodo = @nodo_padre " &
                "  UNION ALL " &
                "  SELECT n.nodo_padre, n.idnodo, n.desc_nodo FROM nodo n INNER JOIN NODOS nds ON n.nodo_padre = nds.idnodo" &
                ") " &
                "SELECT mp.idmant AS id_mant, " &
                "       cmp.idciclo AS id_ciclo, " &
                "       mp.idnodo AS id_nodo, " &
                "       ISNULL((SELECT TOP 1 p.desc_nodo FROM nodo p WHERE p.idnodo = nds.nodo_padre), '') AS seccion, " &
                "       ISNULL(nds.desc_nodo, '') AS item_maquina, " &
                "       ISNULL(mp.tipo_mantencion, '') AS tipo_mp, " &
                "       ISNULL(cmp.estado_ciclo, '') AS estado_ciclo, " &
                "       ISNULL(cmp.obs_ciclo, '') AS obs_ciclo, " &
                "       cmp.fecha_inicio, " &
                "       cmp.hora_inicio, " &
                "       cmp.fecha_termino, " &
                "       cmp.hora_termino, " &
                "       ISNULL(cmp.duracion, 0) AS duracion " &
                "FROM NODOS nds " &
                "INNER JOIN mant_preventiva mp ON nds.idnodo = mp.idnodo " &
                "INNER JOIN ciclo_mp cmp ON mp.idmant = cmp.idmant " &
                "WHERE (@id_mant <= 0 OR mp.idmant = @id_mant) " &
                "  AND (@id_ciclo <= 0 OR cmp.idciclo = @id_ciclo) " &
                "  AND (@ignorar_fechas = 1 OR (cmp.fecha_inicio BETWEEN @fecha_inicio_ciclo AND @fecha_fin_ciclo)) " &
                "  AND (@tipo_mantencion = '' OR @tipo_mantencion = 'Todos' OR mp.tipo_mantencion = @tipo_mantencion) " &
                "ORDER BY mp.fecha_creacion DESC, mp.idmant DESC, cmp.fecha_inicio DESC, cmp.idciclo DESC"

            Using da As New SqlDataAdapter(sql, cnx)
                da.SelectCommand.CommandTimeout = 30
                da.SelectCommand.Parameters.AddWithValue("@nodo_padre", Math.Max(1, idPadre))
                da.SelectCommand.Parameters.AddWithValue("@id_mant", Math.Max(0, idMantFiltro))
                da.SelectCommand.Parameters.AddWithValue("@id_ciclo", Math.Max(0, idCicloFiltro))
                da.SelectCommand.Parameters.AddWithValue("@ignorar_fechas", If(ignorarFechasPorId AndAlso (idMantFiltro > 0 OrElse idCicloFiltro > 0), 1, 0))
                Utilitarios.AgregarParametroFecha(da.SelectCommand, "@fecha_inicio_ciclo", Utilitarios.SafeSqlDateStart(fechaInicio))
                Utilitarios.AgregarParametroFecha(da.SelectCommand, "@fecha_fin_ciclo", Utilitarios.SafeSqlDateEnd(fechaFin))
                da.SelectCommand.Parameters.AddWithValue("@tipo_mantencion", If(tipoMp, String.Empty).Trim())
                da.Fill(dt)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Datos Detallados Carta Gantt")
        Finally
            conexion.Desconectar(cnx)
        End Try
        Return dt
    End Function
End Class
