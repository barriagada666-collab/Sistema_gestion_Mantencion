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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
                com.Parameters.AddWithValue("@frecuencia", CInt(frecuencia))
                com.Parameters.AddWithValue("@tiempo_aviso", CInt(tiempo_aviso_previo))
                com.Parameters.AddWithValue("@estado_mp", estado_mp)
                com.Parameters.AddWithValue("@fecha_creacion", Now.ToString("yyyyMMdd"))
                com.Parameters.AddWithValue("@tipo_mantencion", tipo_mp)
                com.Parameters.AddWithValue("@sesion", sesion)
                com.Parameters.AddWithValue("@obs_mantencion", obs_mantencion)
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                com.Parameters.AddWithValue("@rut", rut)

                com.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                com.Parameters.AddWithValue("@id_tarea", CInt(id_tarea))
                com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
                com.Parameters.AddWithValue("@tiempo_tarea", CDbl(tiempo_tarea))
                com.Parameters.AddWithValue("@obs_tarea", obs_tarea)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                com.Parameters.AddWithValue("@fecha_ini", fecha_ini_ciclo.ToString("yyyyMMdd"))
                com.Parameters.AddWithValue("@hora_ini", hr_ini_ciclo.ToString("HH:mm"))
                com.Parameters.AddWithValue("@fecha_fin", fecha_fin_ciclo.ToString("yyyyMMdd"))
                com.Parameters.AddWithValue("@hora_fin", hr_fin_ciclo.ToString("HH:mm"))
                com.Parameters.AddWithValue("@duracion", CDbl(duracion))
                com.Parameters.AddWithValue("@obs_ciclo", obs_ciclo)
                com.Parameters.AddWithValue("@estado_ciclo", estado_ciclo)
                com.Parameters.AddWithValue("@sesion", sesion)
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                com.Parameters.AddWithValue("@id_tarea", CInt(id_tarea))
                com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
                com.Parameters.AddWithValue("@obs_tarea", obs_tarea)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                com.Parameters.AddWithValue("@id_insumo", CInt(id_insumo))
                com.Parameters.AddWithValue("@cantidad", CInt(cantidad))
                com.Parameters.AddWithValue("@unid_medida", unid_medida)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
                com.Parameters.AddWithValue("@frecuencia", CInt(frecuencia))
                com.Parameters.AddWithValue("@tiempo_aviso_mp", CInt(tiempo_aviso_previo))
                com.Parameters.AddWithValue("@estado_mp", estado_mp)
                com.Parameters.AddWithValue("@tipo_mantencion", tipo_mp)
                com.Parameters.AddWithValue("@sesion", sesion)
                com.Parameters.AddWithValue("@obs_mantencion", obs_mantencion)
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                com.Parameters.AddWithValue("@id_tarea", CInt(id_tarea))
                com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
                com.Parameters.AddWithValue("@tiempo_tarea", CDbl(tiempo_tarea))
                com.Parameters.AddWithValue("@obs_tarea", obs_tarea)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                com.Parameters.AddWithValue("@id_insumo", CInt(id_insumo))
                com.Parameters.AddWithValue("@cantidad", CInt(cantidad))
                com.Parameters.AddWithValue("@unid_medida", unid_medida)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                com.Parameters.AddWithValue("@fecha_inicio", fecha_ini_ciclo.ToString("yyyyMMdd"))
                com.Parameters.AddWithValue("@hora_inicio", hr_ini_ciclo.ToString("HH:mm"))
                com.Parameters.AddWithValue("@fecha_termino", fecha_fin_ciclo.ToString("yyyyMMdd"))
                com.Parameters.AddWithValue("@hora_termino", hr_fin_ciclo.ToString("HH:mm"))
                com.Parameters.AddWithValue("@duracion", CDbl(duracion))
                com.Parameters.AddWithValue("@obs_ciclo", obs_ciclo)
                com.Parameters.AddWithValue("@estado_ciclo", estado_ciclo)
                com.Parameters.AddWithValue("@sesion", sesion)
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                com.Parameters.AddWithValue("@rut", rut)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
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
        combo.Items.Add("Mecanica Mayor")
        combo.Items.Add("Electrica")
        combo.Items.Add("Electrica Mayor")
        combo.Items.Add("Electronica")
        combo.Text = combo.Items(0)
    End Sub

    Public Sub CrgCmbTipoMpGantt(ByRef combo As ComboBox)
        combo.Items.Add("Mecanica")
        combo.Items.Add("Mecanica Mayor")
        combo.Items.Add("Electrica")
        combo.Items.Add("Electrica Mayor")
        combo.Items.Add("Electronica")
        combo.Items.Add("Todos")
        combo.Text = combo.Items(0)
    End Sub

    Public Sub CrgMpNodo(ByVal id_nodo As String, ByVal tipo_mp As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_MP_NODO", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.SelectCommand.Parameters.AddWithValue("@id_nodo", id_nodo)
                DA.SelectCommand.Parameters.AddWithValue("@tipo_mantencion", tipo_mp)
                DA.Fill(DS)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                DA.Fill(DS)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo_mp", CInt(id_ciclo_mp))
                DA.Fill(DS)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgTareasCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal nodo_padre As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_TAREAS_CICLO_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", id_ciclo)
                DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                Dim DS As New DataSet

                DA.Fill(DS)
                combo.DataSource = DS.Tables(0)
                combo.DisplayMember = "idciclo"
                combo.ValueMember = "idciclo"
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
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
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
                DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))
                DA.Fill(DS)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
                    If DR.Read() Then
                        id_mp = DR(0)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
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
                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        id_ciclo = DR(0)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
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
                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        If DR(0) = 1 Then
                            encontrado = True
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo_mp", CInt(id_ciclo))

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        If DR(0) = 1 Then
                            encontrado = True
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        If DR(0).ToString = "True" Then
                            encontrado = True
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
            Using com As New SqlCommand("DEL_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                com.Parameters.AddWithValue("@sesion", sesion)
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@sesion", sesion)
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                com.Parameters.AddWithValue("@id_insumo", CInt(id_insumo))

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                com.Parameters.AddWithValue("@rut", rut)

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                com.Parameters.AddWithValue("@id_tarea", CInt(id_tarea))

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Function ValidarIngresoMp(ByRef Form As FrmMp, ByRef resp As String) As Boolean
        Dim valida As Boolean = True
        Dim fecha_hr_ini As DateTime
        Dim fecha_hr_fin As DateTime

        fecha_hr_ini = Form.FechaIniCiclo.Value.Date.Add(New TimeSpan(Form.HrInicioCiclo.Value.Hour, Form.HrInicioCiclo.Value.Minute, 0))
        fecha_hr_fin = Form.fechaFinCicloMp.Value.Date.Add(New TimeSpan(Form.HrFinCiclo.Value.Hour, Form.HrFinCiclo.Value.Minute, 0))

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
                    Dim tVal As String = If(FrmMp.grillaTareasCicloMp.Rows(i).Cells(3).Value Is Nothing, "", FrmMp.grillaTareasCicloMp.Rows(i).Cells(3).Value.ToString())
                    Dim obsVal As String = If(FrmMp.grillaTareasCicloMp.Rows(i).Cells(4).Value Is Nothing, "", FrmMp.grillaTareasCicloMp.Rows(i).Cells(4).Value.ToString())
                    Dim chkVal As Boolean = CBool(FrmMp.grillaTareasCicloMp.Rows(i).Cells(0).Value)
                    If tVal = "" AndAlso chkVal = True Then
                        valida = False
                        resp = resp & "Debe ingresar el tiempo de la tarea realizada: Fila N°" & i + 1 & Chr(13)
                    ElseIf chkVal = False AndAlso obsVal = "" Then
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
                    If FrmMp.grillaPersonalMp.Rows(i).Cells(0).Value Is Nothing OrElse FrmMp.grillaPersonalMp.Rows(i).Cells(0).Value.ToString = "" Then
                        valida = False
                        resp = resp & "Debe ingresar agregar una persona: Fila N°" & i + 1 & Chr(13)
                    End If
                Next
            End If

            If FrmMp.grillaInsumosMp.Rows.Count > 0 Then
                For i = 0 To FrmMp.grillaInsumosMp.RowCount - 1
                    If FrmMp.grillaInsumosMp.Rows(i).Cells(3).Value Is Nothing OrElse FrmMp.grillaInsumosMp.Rows(i).Cells(3).Value.ToString = "" Then
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
            Using DA As New SqlDataAdapter("INF_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.SelectCommand.Parameters.AddWithValue("@id_nodo", id_nodo)
                DA.SelectCommand.Parameters.AddWithValue("@fecha_ini", fecha_inicio.ToString("yyyyMMdd"))
                DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", fecha_fin.ToString("yyyyMMdd"))
                DA.SelectCommand.Parameters.AddWithValue("@tipo_mp", tipo_mp)
                DA.SelectCommand.Parameters.AddWithValue("@opcion", opcion)

                DA.Fill(DST)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub InfCicloMp(ByVal id_mp As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_CICLO_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub InfTareasCicloMp(ByVal id_mp As String, ByVal id_ciclo As String, ByVal nodo_padre As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_TAREAS_CICLO_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
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
            Using DA As New SqlDataAdapter("INF_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.SelectCommand.Parameters.AddWithValue("@id_nodo", id_nodo)
                DA.SelectCommand.Parameters.AddWithValue("@fecha_ini", fecha_inicio.ToString("yyyyMMdd"))
                DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", fecha_fin.ToString("yyyyMMdd"))
                DA.SelectCommand.Parameters.AddWithValue("@tipo_mp", tipo_mp)
                DA.SelectCommand.Parameters.AddWithValue("@opcion", opcion)

                DA.Fill(DST)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
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
            Using DA As New SqlDataAdapter("INF_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.SelectCommand.Parameters.AddWithValue("@id_nodo", id_nodo)
                DA.SelectCommand.Parameters.AddWithValue("@fecha_ini", fecha_inicio.ToString("yyyyMMdd"))
                DA.SelectCommand.Parameters.AddWithValue("@fecha_fin", fecha_fin.ToString("yyyyMMdd"))
                DA.SelectCommand.Parameters.AddWithValue("@tipo_mp", tipo_mp)
                DA.SelectCommand.Parameters.AddWithValue("@opcion", opcion)

                DA.Fill(DST)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub InfSoloTareasMp(ByVal opcion As String, ByVal id_nodo As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_SOLO_TAREAS_INF_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.SelectCommand.Parameters.AddWithValue("@opcion", CInt(opcion))
                DA.SelectCommand.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
                DA.SelectCommand.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                DA.SelectCommand.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub InfCiclosMaquinasMp(ByVal id_padre As String, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, ByVal tipo_mantencion As String, ByRef DST As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("INF_CICLOS_MP_MAQUINAS", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(id_padre))
                DA.SelectCommand.Parameters.AddWithValue("@fecha_inicio_ciclo", fecha_inicio.ToString("yyyyMMdd"))
                DA.SelectCommand.Parameters.AddWithValue("@fecha_fin_ciclo", fecha_fin.ToString("yyyyMMdd"))
                DA.SelectCommand.Parameters.AddWithValue("@tipo_mantencion", tipo_mantencion)
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub exportarInfMpExcel(ByRef grilla_mp As DataGridView, ByRef grilla_ciclo As DataGridView, ByRef grilla_tareas_r As DataGridView, ByVal grilla_personal As DataGridView, ByVal grilla_tareas_pend As DataGridView, ByVal grilla_insumos As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim worksheet_4 As Excel.Worksheet
        Dim worksheet_5 As Excel.Worksheet

        Try
            excelApp = New Excel.Application
            excelApp.ScreenUpdating = False
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
            excelApp.ScreenUpdating = True
            MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Excel")
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar Excel")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Public Sub expInfMpExcelSoloRealizadas(ByVal grilla_tareas_realizadas As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim worksheet_4 As Excel.Worksheet
        Dim worksheet_5 As Excel.Worksheet
        Dim filaexcel As Integer = 11
        Dim rango As Excel.Range

        Try
            excelApp = New Excel.Application
            excelApp.ScreenUpdating = False
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

            If filaexcel > 11 Then
                rango = worksheet_5.Range("A11:L" & filaexcel - 1)
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            End If
            excelApp.ScreenUpdating = True
            MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Excel")
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar Excel")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Public Sub expInfMpExcelSoloPend(ByVal grilla_tareas_pend As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim worksheet_4 As Excel.Worksheet
        Dim worksheet_5 As Excel.Worksheet
        Dim filaexcel As Integer = 11
        Dim rango As Excel.Range

        Try
            excelApp = New Excel.Application
            excelApp.ScreenUpdating = False
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

            If filaexcel > 11 Then
                rango = worksheet_4.Range("A11:K" & filaexcel - 1)
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            End If
            excelApp.ScreenUpdating = True
            MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Excel")
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar Excel")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Public Sub expInfGanttTodo(ByVal grilla_info_mp As DataGridView, ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
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

        If grilla_ciclos_mp.RowCount = 0 Then Return

        Try
            excelApp = New Excel.Application
            excelApp.ScreenUpdating = False
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
            Dim colIniIdx As Integer = If(IsDate(grilla_ciclos_mp.Rows(0).Cells(2).Value), 2, 3)
            Dim colFinIdx As Integer = colIniIdx + 1

            Dim rango As Excel.Range
            '------------- llenado de tareas realizadas --------------------------------------------
            For i = 0 To grilla_ciclos_mp.RowCount - 1
                worksheet_1.Cells(filaexcel, 1) = grilla_ciclos_mp.Rows(i).Cells(0).Value
                worksheet_1.Cells(filaexcel, 2) = grilla_ciclos_mp.Rows(i).Cells(1).Value
                worksheet_1.Cells(filaexcel, 5) = grilla_ciclos_mp.Rows(i).Cells(colIniIdx).Value
                worksheet_1.Cells(filaexcel, 6) = grilla_ciclos_mp.Rows(i).Cells(colFinIdx).Value
                worksheet_1.Cells(filaexcel, 7) = grilla_ciclos_mp.Rows(i).Cells(colFinIdx + 1).Value
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

            fecha_inicio = CDate(grilla_ciclos_mp.Rows(0).Cells(colIniIdx).Value).Date
            fecha_fin = CDate(grilla_ciclos_mp.Rows(grilla_ciclos_mp.RowCount - 1).Cells(colFinIdx).Value).Date
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
                fecha_ini = CDate(grilla_ciclos_mp.Rows(i).Cells(colIniIdx).Value).Date
                num_mant = DateDiff(DateInterval.Day, fecha_ini, CDate(grilla_ciclos_mp.Rows(i).Cells(colFinIdx).Value).Date) + 1

                For j = 0 To grilla_grafico.Columns.Count - 1
                    If fecha_ini.ToString("yyyyMMdd") = grilla_grafico.Columns(j).Name OrElse fecha_ini.ToString("dd-MM-yy") = grilla_grafico.Columns(j).Name Then
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
            excelApp.ScreenUpdating = True
            MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Excel")
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar Excel")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Public Sub exportarInfMpPDF(ByRef grilla_mp As DataGridView, ByRef grilla_ciclo As DataGridView, ByRef grilla_tareas_r As DataGridView, ByVal grilla_personal As DataGridView, ByVal grilla_tareas_pend As DataGridView, ByVal grilla_insumos As DataGridView, ByVal item As String)
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
                Dim grillaPrincipal As DataGridView = If(grilla_tareas_r IsNot Nothing AndAlso grilla_tareas_r.RowCount > 0, grilla_tareas_r, grilla_tareas_pend)
                If grillaPrincipal IsNot Nothing AndAlso Utilitarios.ExportarGrillaAPdf(grillaPrincipal, rutaPdf, "INFORME DE MANTENCIÓN PREVENTIVA", "Ítem / Máquina: " & item) Then
                    If MessageBox.Show("Archivo PDF generado exitosamente mediante motor nativo en:" & Environment.NewLine & rutaPdf & Environment.NewLine & Environment.NewLine & "¿Desea abrir el documento PDF ahora?", "Exportación PDF Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                        Utilitarios.AbrirDocumento(rutaPdf)
                    End If
                    Exit Sub
                End If
            Catch
            End Try
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar PDF")
        Finally
            Utilitarios.LiberarExcel(workbook, excelApp)
        End Try
    End Sub

    Public Sub expInfMpPDFSoloRealizadas(ByVal grilla_tareas_realizadas As DataGridView, ByVal item As String)
        If grilla_tareas_realizadas Is Nothing OrElse grilla_tareas_realizadas.RowCount = 0 Then
            MsgBox("No hay tareas realizadas para exportar a PDF.", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Dim rutaPdf As String = Utilitarios.SolicitarRutaGuardadoPdf("Informe_MP_Realizadas_" & item)
        If String.IsNullOrEmpty(rutaPdf) Then Exit Sub

        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim worksheet_4 As Excel.Worksheet
        Dim worksheet_5 As Excel.Worksheet
        Dim filaexcel As Integer = 11
        Dim rango As Excel.Range

        Try
            excelApp = New Excel.Application
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, True)
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

            If filaexcel > 11 Then
                rango = worksheet_5.Range("A11:L" & filaexcel - 1)
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            End If

            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            Utilitarios.ImprimirLibroAPdfWindows(excelApp, workbook, rutaPdf, "Informe_MP_Realizadas_" & item)
        Catch ex As Exception
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            ' Respaldo 100% nativo con iTextSharp si Excel no está disponible o falla
            Try
                If Utilitarios.ExportarGrillaAPdf(grilla_tareas_realizadas, rutaPdf, "INFORME DE MANTENCIÓN PREVENTIVA - TAREAS REALIZADAS", "Ítem / Máquina: " & item) Then
                    If MessageBox.Show("Archivo PDF generado exitosamente mediante motor nativo en:" & Environment.NewLine & rutaPdf & Environment.NewLine & Environment.NewLine & "¿Desea abrir el documento PDF ahora?", "Exportación PDF Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                        Utilitarios.AbrirDocumento(rutaPdf)
                    End If
                    Exit Sub
                End If
            Catch
            End Try
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar PDF")
        Finally
            Utilitarios.LiberarExcel(workbook, excelApp)
        End Try
    End Sub

    Public Sub expInfMpPDFSoloPend(ByVal grilla_tareas_pend As DataGridView, ByVal item As String)
        If grilla_tareas_pend Is Nothing OrElse grilla_tareas_pend.RowCount = 0 Then
            MsgBox("No hay tareas pendientes para exportar a PDF.", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Dim rutaPdf As String = Utilitarios.SolicitarRutaGuardadoPdf("Informe_MP_Pendientes_" & item)
        If String.IsNullOrEmpty(rutaPdf) Then Exit Sub

        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim worksheet_4 As Excel.Worksheet
        Dim worksheet_5 As Excel.Worksheet
        Dim filaexcel As Integer = 11
        Dim rango As Excel.Range

        Try
            excelApp = New Excel.Application
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, True)
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

            If filaexcel > 11 Then
                rango = worksheet_4.Range("A11:K" & filaexcel - 1)
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            End If

            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            Utilitarios.ImprimirLibroAPdfWindows(excelApp, workbook, rutaPdf, "Informe_MP_Pendientes_" & item)
        Catch ex As Exception
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            ' Respaldo 100% nativo con iTextSharp si Excel no está disponible o falla
            Try
                If Utilitarios.ExportarGrillaAPdf(grilla_tareas_pend, rutaPdf, "INFORME DE MANTENCIÓN PREVENTIVA - TAREAS PENDIENTES", "Ítem / Máquina: " & item) Then
                    If MessageBox.Show("Archivo PDF generado exitosamente mediante motor nativo en:" & Environment.NewLine & rutaPdf & Environment.NewLine & Environment.NewLine & "¿Desea abrir el documento PDF ahora?", "Exportación PDF Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                        Utilitarios.AbrirDocumento(rutaPdf)
                    End If
                    Exit Sub
                End If
            Catch
            End Try
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar PDF")
        Finally
            Utilitarios.LiberarExcel(workbook, excelApp)
        End Try
    End Sub

    Public Function ValidarMP() As String
        Dim msje_error As String = ""
        Dim fecha_hora_inicio As DateTime
        Dim fecha_hora_fin As DateTime

        With FrmMp
            fecha_hora_inicio = .FechaIniCiclo.Value.Date.Add(New TimeSpan(.HrInicioCiclo.Value.Hour, .HrInicioCiclo.Value.Minute, 0))
            fecha_hora_fin = .fechaFinCicloMp.Value.Date.Add(New TimeSpan(.HrFinCiclo.Value.Hour, .HrFinCiclo.Value.Minute, 0))

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
                    tiempo_tarea = If(.grillaTareasCicloMp.Rows(i).Cells(3).Value Is Nothing, "", .grillaTareasCicloMp.Rows(i).Cells(3).Value.ToString())
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
            Using com As New SqlCommand("UPD_ID_NODO_TAREAS_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))
                com.Parameters.AddWithValue("@id_tarea", CInt(id_tarea))
                com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Function hrsTranscurridasCicloMp(ByVal id_mp As String, ByVal id_ciclo As String) As Double
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim hrs_trans As Double = 0

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("CRG_HRS_TRANS_CICLO_MP", cnx)
                com.CommandType = CommandType.StoredProcedure

                com.Parameters.AddWithValue("@id_mp", CInt(id_mp))
                com.Parameters.AddWithValue("@id_ciclo", CInt(id_ciclo))

                Using DR As SqlDataReader = com.ExecuteReader()
                    If DR.Read() Then
                        hrs_trans = CDbl(DR(0).ToString)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
        Return hrs_trans
    End Function
End Class
