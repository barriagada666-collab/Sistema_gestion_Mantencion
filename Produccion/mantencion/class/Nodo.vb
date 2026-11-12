Imports System.Data.SqlClient
Public Class Nodo
    Public Function CRG_NODO(ByVal id_nodo As Integer) As DataSet
        Dim ds_result As New DataSet
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        conexion.Conectar(cnx)
        Dim da As New SqlDataAdapter("CRG_NODOS_ACTIVOS " & id_nodo, cnx)
        da.Fill(ds_result, "nodo")
        conexion.Desconectar(cnx)
        da.Dispose()
        Return ds_result
    End Function

    Public Function CRG_NODO_2(ByVal id_nodo As Integer) As DataSet
        Dim ds_result As New DataSet
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        conexion.Conectar(cnx)
        Dim da As New SqlDataAdapter("CRG_NODOS_MANT_SI", cnx)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim p_nodo_padre As SqlParameter = da.SelectCommand.Parameters.AddWithValue("@nodo_padre", id_nodo)

        da.Fill(ds_result, "nodo")
        conexion.Desconectar(cnx)
        da.Dispose()
        Return ds_result
    End Function

    Public Sub CRG_NODO_HIJO(ByRef nodo As TreeNode)
        Dim dst As New DataSet

        Dim i As Integer = 0
        dst = CRG_NODO(nodo.Name)
        For i = 1 To dst.Tables("nodo").Rows.Count
            Dim nodo1 As New TreeNode()
            nodo1.Text = dst.Tables("nodo").Rows(i - 1)("desc_nodo").ToString()
            nodo1.Name = dst.Tables("nodo").Rows(i - 1)("idnodo").ToString()
            nodo.Nodes.Add(nodo1)
            CRG_NODO_HIJO(nodo1)
        Next
    End Sub

    Public Sub CRG_TAREAS_MP(ByVal nodo_padre As String, ByVal tipo_mp As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_TAREAS_NODO_MP", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))
            Dim p_tipo_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_mp", tipo_mp)

            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()
            cnx.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub CRG_NODO_HIJO_2(ByRef nodo As TreeNode)
        Dim dst As New DataSet

        Dim i As Integer = 0
        dst = CRG_NODO(nodo.Name)
        For i = 1 To dst.Tables("nodo").Rows.Count
            Dim nodo1 As New TreeNode()
            nodo1.Text = dst.Tables("nodo").Rows(i - 1)("desc_nodo").ToString()
            nodo1.Name = dst.Tables("nodo").Rows(i - 1)("idnodo").ToString()
            nodo.Nodes.Add(nodo1)
        Next
    End Sub

    Public Function CRG_NODOS_DST() As DataSet
        Dim ds_result As New DataSet
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        conexion.Conectar(cnx)
        Dim da As New SqlDataAdapter("CRG_NODOS_DST", cnx)
        da.Fill(ds_result)
        conexion.Desconectar(cnx)
        da.Dispose()

        Return ds_result
    End Function

    Public Function CRG_NODOS_TODOS(ByVal id_nodo As Integer) As DataSet
        Dim ds_result As New DataSet
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        conexion.Conectar(cnx)
        Dim da As New SqlDataAdapter("CRG_NODOS_TODOS " & id_nodo, cnx)
        da.Fill(ds_result, "nodo")
        conexion.Desconectar(cnx)
        da.Dispose()
        Return ds_result
    End Function

    Public Sub CRG_NODO_HIJO_TODOS(ByRef nodo As TreeNode)
        Dim dst As New DataSet

        Dim i As Integer = 0
        dst = CRG_NODOS_TODOS(nodo.Name)
        For i = 1 To dst.Tables("nodo").Rows.Count
            Dim nodo1 As New TreeNode()
            nodo1.Text = dst.Tables("nodo").Rows(i - 1)("desc_nodo").ToString()
            nodo1.Name = dst.Tables("nodo").Rows(i - 1)("idnodo").ToString()
            nodo.Nodes.Add(nodo1)
            CRG_NODO_HIJO_TODOS(nodo1)
        Next
    End Sub

    Public Sub CRG_NODO_MANT_SI(ByRef nodo As TreeNode)
        Dim dst As New DataSet

        Dim i As Integer = 0
        dst = CRG_NODO_2(nodo.Name)
        For i = 1 To dst.Tables("nodo").Rows.Count
            Dim nodo1 As New TreeNode()
            nodo1.Text = dst.Tables("nodo").Rows(i - 1)("desc_nodo").ToString()
            nodo1.Name = dst.Tables("nodo").Rows(i - 1)("idnodo").ToString()
            nodo.Nodes.Add(nodo1)
            CRG_NODO_MANT_SI(nodo1)
        Next
    End Sub

    Public Sub CrgArbol(ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_ARBOL_COMPLETO", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure

            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Sub CRG_TAREAS_NODO(ByVal id_nodo_padre As String, ByVal tipo_mp As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_TAREAS_NODO", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_nodo As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(id_nodo_padre))
            Dim p_tipo_mp As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@tipo_mp", tipo_mp)

            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()
            cnx.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Function BuscarIdNodo(ByVal desc_nodo As String) As String
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim id_nodo As String = ""
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("BUSCAR_NODO_X_NOMBRE", cnx)
            com.CommandType = CommandType.StoredProcedure
            Dim p_desc_nodo As SqlParameter = com.Parameters.AddWithValue("@nombre_nodo", desc_nodo)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                id_nodo = DR(0)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try

        Return id_nodo
    End Function

    Public Function NUEVO_ID_NODO()
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim id_nodo As String = ""
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("NUEVO_ID_NODO", cnx)
            com.CommandType = CommandType.StoredProcedure
            Dim DR As SqlDataReader = com.ExecuteReader

            If DR.Read() Then
                id_nodo = DR(0)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If

        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try

        Return id_nodo
    End Function

    Public Sub IngNodo(ByVal id_nodo As String, ByVal nodo_padre As String, ByVal desc_nodo As String, ByVal nivel As String, ByVal estado_nodo As Boolean, ByVal cod_rmes As String, ByVal sesion As String, ByVal fecha_instalacion As DateTime, ByVal prioridad As String, ByVal cod_sap As String, ByVal aplica_mant As Boolean, ByVal grupo As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_NODO", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
            Dim p_nodo_padre As SqlParameter = com.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))
            Dim p_desc_nodo As SqlParameter = com.Parameters.AddWithValue("@desc_nodo", desc_nodo)
            Dim p_nivel As SqlParameter = com.Parameters.AddWithValue("@nivel", CInt(nivel))
            Dim p_estado_nodo As SqlParameter = com.Parameters.AddWithValue("@estado_nodo", estado_nodo)
            Dim p_cod_rmes As SqlParameter = com.Parameters.AddWithValue("@cod_rmes", cod_rmes)
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
            Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
            Dim p_fecha_instalacion As SqlParameter = com.Parameters.AddWithValue("@fecha_instalacion", Format(fecha_instalacion, "MM/dd/yyyy"))
            Dim p_fecha_creacion As SqlParameter = com.Parameters.AddWithValue("@fecha_creacion", Format(Now, "MM/dd/yyyy"))
            Dim p_prioridad As SqlParameter = com.Parameters.AddWithValue("@prioridad", CInt(prioridad))
            Dim p_cod_sap As SqlParameter = com.Parameters.AddWithValue("@codigo_sap", cod_sap)
            Dim p_aplica_mantencion As SqlParameter = com.Parameters.AddWithValue("@aplica_mantencion", aplica_mant)
            Dim p_grupo As SqlParameter = com.Parameters.AddWithValue("@grupo", grupo)

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

    Public Sub LimpiarFormNodos()
        With FrmAdminNodos
            .txtIDNodoSel.ResetText()
            .txtDescNodoSel.ResetText()
            .txtIDNuevoNodo.ResetText()
            .txtDescNuevoNodo.ResetText()
            .nivel_nodo_padre = 0
            .txtCodRmes.ResetText()
            .txtCodRmesNodoNuevo.ResetText()
            .txtPrioridad.Text = 0
            .txtPrioridad2.Text = 0
            .txtCodSap.ResetText()
            .txtCodSap2.ResetText()
            .fecha_instalacion.Value = Now
            .fecha_instalacion2.Value = Now
            .GrpInfoNuevoNodo.Enabled = False
            .form_limpio = True
            If .GrpNodoPadre.Enabled = False Then
                .GrpNodoPadre.Enabled = True
            End If
            .chkModPadre.Checked = False
        End With
    End Sub

    Public Function BuscarNodo(ByVal id_nodo As String) As String
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim resp As String = ""
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("BUSCAR_NODO", cnx)
            com.CommandType = CommandType.StoredProcedure
            Dim p_desc_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", id_nodo)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                If DR(0) = 1 Then
                    resp = DR(1)
                End If
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try

        Return resp
    End Function

    Public Sub UpdNodo(ByVal id_nodo As String, ByVal nodo_padre As String, ByVal desc_nodo As String, ByVal nivel As String, ByVal estado_nodo As Boolean, ByVal cod_rmes As String, ByVal sesion As String, ByVal fecha_instalacion As DateTime, ByVal prioridad As String, ByVal cod_sap As String, ByVal aplica_mant As Boolean, ByVal grupo As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_NODO", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
            Dim p_nodo_padre As SqlParameter = com.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))
            Dim p_desc_nodo As SqlParameter = com.Parameters.AddWithValue("@desc_nodo", desc_nodo)
            Dim p_nivel As SqlParameter = com.Parameters.AddWithValue("@nivel", CInt(nivel))
            Dim p_estado_nodo As SqlParameter = com.Parameters.AddWithValue("@estado_nodo", estado_nodo)
            Dim p_cod_rmes As SqlParameter = com.Parameters.AddWithValue("@cod_rmes", cod_rmes)
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
            Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
            Dim p_fecha_instalacion As SqlParameter = com.Parameters.AddWithValue("@fecha_instalacion", Format(fecha_instalacion, "MM/dd/yyyy"))
            Dim p_prioridad As SqlParameter = com.Parameters.AddWithValue("@prioridad", CInt(prioridad))
            Dim p_cod_sap As SqlParameter = com.Parameters.AddWithValue("@codigo_sap", cod_sap)
            Dim p_aplica_mantencion As SqlParameter = com.Parameters.AddWithValue("@aplica_mantencion", aplica_mant)
            Dim p_grupo As SqlParameter = com.Parameters.AddWithValue("@grupo", grupo)

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

    Public Function ValidarIngresoNodo()
        Dim respuesta As String = ""

        With FrmAdminNodos
            If .txtIDNodoSel.Text = "" Then
                respuesta = "Debe Seleccionar un nodo Padre" & Chr(13)
            End If

            If .txtIDNuevoNodo.Text = "" Then
                respuesta = respuesta & "Debe crear un ID para el nuevo nodo" & Chr(13)
            End If

            If .txtDescNuevoNodo.Text = "" Then
                respuesta = respuesta & "Debe ingresar una descripción para el nuevo nodo" & Chr(13)
            End If
        End With

        Return respuesta
    End Function

    Public Function ValidarActualizacionNodo()
        Dim respuesta As String = ""

        With FrmAdminNodos
            If .txtIDNodoSel.Text = "" Then
                respuesta = "Debe Seleccionar un nodo en el arbol" & Chr(13)
            End If

            If .txtDescNodoSel.Text = "" Then
                respuesta = "Debe agregar una descripción del nodo" & Chr(13)
            End If

            If .id_nodo_padre = "" Then
                respuesta = respuesta & "Debe seleccionar el nodo a modificar en el arbol para obtener el ID del Padre" & Chr(13)
            End If
        End With

        Return respuesta
    End Function

    Public Sub AutocompletadoArbol(ByRef txt_desc_nodo As TextBox)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("AUTOCOMPLETAR_ARBOL", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim DR As SqlDataReader = com.ExecuteReader
            With txt_desc_nodo
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.CustomSource
            End With

            While DR.Read
                txt_desc_nodo.AutoCompleteCustomSource.Add(DR(0).ToString)
            End While
            conexion.Desconectar(cnx)

            DR.Close()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try
    End Sub

    Public Function NuevoIdTareaNodo() As Integer
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Dim id_tarea As Integer = 0

        Try
            conexion.Conectar(cnx)
            Dim DR As SqlDataReader
            Dim com As New SqlCommand("NUEVO_ID_TAREA_NODO", cnx)
            com.CommandType = CommandType.StoredProcedure

            DR = com.ExecuteReader
            If DR.Read() Then
                id_tarea = DR(0)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
            Return id_tarea
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try
    End Function

    Public Sub IngTareaNodo(ByVal id_tarea As String, ByVal id_nodo As String, ByVal desc_tarea As String, ByVal tipo_mantencion As String, ByVal orden_despliegue As Integer, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_TAREA_NODO", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_tarea As SqlParameter = com.Parameters.AddWithValue("@id_tarea", CInt(id_tarea))
            Dim p_nodo_padre As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
            Dim p_desc_tarea As SqlParameter = com.Parameters.AddWithValue("@desc_tarea", desc_tarea)
            Dim p_tipo_mantencion As SqlParameter = com.Parameters.AddWithValue("@tipo_mantencion", tipo_mantencion)
            Dim p_orden_despliegue As SqlParameter = com.Parameters.AddWithValue("@orden_despliegue", orden_despliegue)
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

    Public Sub DelTareaNodo(ByVal id_tarea As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("DEL_TAREA_NODO", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_tarea As SqlParameter = com.Parameters.AddWithValue("@id_tarea", CInt(id_tarea))
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

    Public Sub limpiar_arbol(ByVal id_nodo As String, ByRef arbol As TreeView)

        If id_nodo <> "0" Then
            Dim nodo_find() As TreeNode = arbol.Nodes.Find(id_nodo, True)
            arbol.SelectedNode = nodo_find(0)
            arbol.SelectedNode.BackColor = Color.White
        End If

    End Sub

    Public Function BuscarIdNodoLike(ByVal desc_nodo As String, ByVal opcion As Integer) As String
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_nodo As String = ""
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("BUSCAR_NODO_LIKE", cnx)
            com.CommandType = CommandType.StoredProcedure
            Dim p_desc_nodo As SqlParameter = com.Parameters.AddWithValue("@nombre_nodo", desc_nodo)
            Dim p_opcion As SqlParameter = com.Parameters.AddWithValue("@opcion", opcion)

            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                cod_nodo = DR(0)
                conexion.Desconectar(cnx)
                com.Dispose()
                cnx.Dispose()
            End If

        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try

        Return cod_nodo
    End Function

End Class
