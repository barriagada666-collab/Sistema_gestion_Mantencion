Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class Nodo

    Private Shared _cacheRaizActivos As TreeNode = Nothing
    Private Shared _cacheRaizTodos As TreeNode = Nothing
    Private Shared _cacheRaizMantSi As TreeNode = Nothing
    Private Shared _cacheAutocompletado As AutoCompleteStringCollection = Nothing

    Public Shared Sub InvalidarCacheNodos()
        _cacheRaizActivos = Nothing
        _cacheRaizTodos = Nothing
        _cacheRaizMantSi = Nothing
        _cacheAutocompletado = Nothing
    End Sub

    Private Shared Sub CopiarHijos(ByVal origen As TreeNode, ByVal destino As TreeNode)
        destino.Nodes.Clear()
        Dim listaHijos As New List(Of TreeNode)(origen.Nodes.Count)
        For Each hijo As TreeNode In origen.Nodes
            listaHijos.Add(DirectCast(hijo.Clone(), TreeNode))
        Next
        destino.Nodes.AddRange(listaHijos.ToArray())
    End Sub

    Public Function CRG_NODO(ByVal id_nodo As Integer) As DataSet
        Dim ds_result As New DataSet
        Dim conexion As New Conexion

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using da As New SqlDataAdapter("CRG_NODOS_ACTIVOS", cnx)
                    da.SelectCommand.CommandType = CommandType.StoredProcedure
                    da.SelectCommand.Parameters.AddWithValue("@nodo_padre", id_nodo)
                    da.Fill(ds_result, "nodo")
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Nodo")
        End Try
        Return ds_result
    End Function

    Public Function CRG_NODO_2(ByVal id_nodo As Integer) As DataSet
        Dim ds_result As New DataSet
        Dim conexion As New Conexion

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using da As New SqlDataAdapter("CRG_NODOS_MANT_SI", cnx)
                    da.SelectCommand.CommandType = CommandType.StoredProcedure
                    da.SelectCommand.Parameters.AddWithValue("@nodo_padre", id_nodo)
                    da.Fill(ds_result, "nodo")
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Nodos con Mantención")
        End Try
        Return ds_result
    End Function

    Public Sub CRG_NODO_HIJO(ByRef nodo As TreeNode)
        If nodo Is Nothing Then Exit Sub

        If nodo.Name = "1" AndAlso _cacheRaizActivos IsNot Nothing Then
            CopiarHijos(_cacheRaizActivos, nodo)
            Exit Sub
        End If

        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Dim visitados As New HashSet(Of Integer)()
                CargarHijosConConexion(nodo, cnx, 1, visitados)
                If nodo.Name = "1" Then
                    _cacheRaizActivos = DirectCast(nodo.Clone(), TreeNode)
                End If
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Hijos de Nodo")
        End Try
    End Sub

    Private Sub CargarHijosConConexion(ByVal nodoPadre As TreeNode, ByVal cnx As SqlConnection, ByVal modo As Integer, ByVal visitados As HashSet(Of Integer))
        If nodoPadre Is Nothing Then Exit Sub
        Dim idPadre As Integer = 0
        If Not Integer.TryParse(If(nodoPadre.Name, String.Empty).Trim(), idPadre) Then Exit Sub
        If visitados IsNot Nothing AndAlso Not visitados.Add(idPadre) Then Exit Sub

        Dim spName As String = "CRG_NODOS_ACTIVOS"
        If modo = 2 Then
            spName = "CRG_NODOS_TODOS"
        ElseIf modo = 3 Then
            spName = "CRG_NODOS_MANT_SI"
        End If

        Dim hijos As New List(Of (Id As String, Desc As String))()
        Using cmd As New SqlCommand(spName, cnx)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@nodo_padre", idPadre)
            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    hijos.Add((dr("idnodo").ToString().Trim(), dr("desc_nodo").ToString()))
                End While
            End Using
        End Using

        Dim listaNodosHijos As New List(Of TreeNode)(hijos.Count)
        For Each h In hijos
            Dim nodoHijo As New TreeNode()
            nodoHijo.Text = h.Desc
            nodoHijo.Name = h.Id
            listaNodosHijos.Add(nodoHijo)
            CargarHijosConConexion(nodoHijo, cnx, modo, visitados)
        Next
        nodoPadre.Nodes.AddRange(listaNodosHijos.ToArray())
    End Sub

    Public Sub CRG_TAREAS_MP(ByVal nodo_padre As String, ByVal tipo_mp As String, ByRef DS As DataSet)
        If DS Is Nothing Then DS = New DataSet()
        Dim idNodoPadre As Integer = 0
        If Not Integer.TryParse(If(nodo_padre, String.Empty).Trim(), idNodoPadre) Then Exit Sub
        Dim conexion As New Conexion

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_TAREAS_NODO_MP", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", idNodoPadre)
                    DA.SelectCommand.Parameters.AddWithValue("@tipo_mp", If(tipo_mp, String.Empty))
                    DA.Fill(DS)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cr Tarea MP")
        End Try
    End Sub

    Public Sub CRG_NODO_HIJO_2(ByRef nodo As TreeNode)
        If nodo Is Nothing Then Exit Sub
        Dim idNodo As Integer = 0
        If Not Integer.TryParse(If(nodo.Name, String.Empty).Trim(), idNodo) Then Exit Sub
        Dim dst As DataSet = CRG_NODO(idNodo)
        If dst Is Nothing OrElse Not dst.Tables.Contains("nodo") Then Exit Sub
        For i As Integer = 0 To dst.Tables("nodo").Rows.Count - 1
            Dim nodo1 As New TreeNode()
            nodo1.Text = dst.Tables("nodo").Rows(i)("desc_nodo").ToString()
            nodo1.Name = dst.Tables("nodo").Rows(i)("idnodo").ToString()
            nodo.Nodes.Add(nodo1)
        Next
    End Sub

    Public Function CRG_NODOS_DST() As DataSet
        Dim ds_result As New DataSet
        Dim conexion As New Conexion

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using da As New SqlDataAdapter("CRG_NODOS_DST", cnx)
                    da.SelectCommand.CommandType = CommandType.StoredProcedure
                    da.Fill(ds_result)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Dataset de Nodos")
        End Try

        Return ds_result
    End Function

    Public Function CRG_NODOS_TODOS(ByVal id_nodo As Integer) As DataSet
        Dim ds_result As New DataSet
        Dim conexion As New Conexion

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using da As New SqlDataAdapter("CRG_NODOS_TODOS", cnx)
                    da.SelectCommand.CommandType = CommandType.StoredProcedure
                    da.SelectCommand.Parameters.AddWithValue("@nodo_padre", id_nodo)
                    da.Fill(ds_result, "nodo")
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Todos los Nodos")
        End Try
        Return ds_result
    End Function

    Public Sub CRG_NODO_HIJO_TODOS(ByRef nodo As TreeNode)
        If nodo Is Nothing Then Exit Sub

        If nodo.Name = "1" AndAlso _cacheRaizTodos IsNot Nothing Then
            CopiarHijos(_cacheRaizTodos, nodo)
            Exit Sub
        End If

        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Dim visitados As New HashSet(Of Integer)()
                CargarHijosConConexion(nodo, cnx, 2, visitados)
                If nodo.Name = "1" Then
                    _cacheRaizTodos = DirectCast(nodo.Clone(), TreeNode)
                End If
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Hijos Todos los Nodos")
        End Try
    End Sub

    Public Sub CRG_NODO_MANT_SI(ByRef nodo As TreeNode)
        If nodo Is Nothing Then Exit Sub

        If nodo.Name = "1" AndAlso _cacheRaizMantSi IsNot Nothing Then
            CopiarHijos(_cacheRaizMantSi, nodo)
            Exit Sub
        End If

        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Dim visitados As New HashSet(Of Integer)()
                CargarHijosConConexion(nodo, cnx, 3, visitados)
                If nodo.Name = "1" Then
                    _cacheRaizMantSi = DirectCast(nodo.Clone(), TreeNode)
                End If
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Hijos con Mantención")
        End Try
    End Sub

    Public Sub CrgArbol(ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_ARBOL_COMPLETO", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.Fill(DS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Arbol")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CRG_TAREAS_NODO(ByVal id_nodo_padre As String, ByVal tipo_mp As String, ByRef DS As DataSet)
        Dim conexion As New Conexion
        Dim idPadreInt As Integer = 0
        If Not Integer.TryParse(If(id_nodo_padre, String.Empty).Trim(), idPadreInt) Then Return

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_TAREAS_NODO", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", idPadreInt)
                    DA.SelectCommand.Parameters.AddWithValue("@tipo_mp", If(tipo_mp, String.Empty))

                    DA.Fill(DS)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cr Tarea Nodo")
        End Try
    End Sub

    Public Function BuscarIdNodo(ByVal desc_nodo As String) As String
        Dim conexion As New Conexion
        Dim id_nodo As String = ""
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("BUSCAR_NODO_X_NOMBRE", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@nombre_nodo", If(desc_nodo, String.Empty))

                    Using DR As SqlDataReader = com.ExecuteReader
                        If DR.Read() AndAlso Not IsDBNull(DR(0)) Then
                            id_nodo = DR(0).ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar ID Nodo")
        End Try

        Return id_nodo
    End Function

    Public Function NUEVO_ID_NODO() As String
        Dim conexion As New Conexion
        Dim id_nodo As String = ""
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("NUEVO_ID_NODO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    Using DR As SqlDataReader = com.ExecuteReader
                        If DR.Read() AndAlso Not IsDBNull(DR(0)) Then
                            id_nodo = DR(0).ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Nuev I Nodo")
        End Try

        Return id_nodo
    End Function

    Public Sub IngNodo(ByVal id_nodo As String, ByVal nodo_padre As String, ByVal desc_nodo As String, ByVal nivel As String, ByVal estado_nodo As Boolean, ByVal cod_rmes As String, ByVal sesion As String, ByVal fecha_instalacion As DateTime, ByVal prioridad As String, ByVal cod_sap As String, ByVal aplica_mant As Boolean, ByVal grupo As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty
        Dim idNodoInt, nodoPadreInt, nivelInt, prioInt As Integer
        If Not Integer.TryParse(If(id_nodo, String.Empty).Trim(), idNodoInt) OrElse
           Not Integer.TryParse(If(nodo_padre, String.Empty).Trim(), nodoPadreInt) OrElse
           Not Integer.TryParse(If(nivel, String.Empty).Trim(), nivelInt) Then
            cod_resp = -1
            resp = "Identificadores de nodo o nivel no válidos."
            Return
        End If
        If Not Integer.TryParse(If(prioridad, String.Empty).Trim(), prioInt) Then
            prioInt = 0
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("ING_NODO", cnx)
                    com.CommandType = CommandType.StoredProcedure

                    com.Parameters.AddWithValue("@id_nodo", idNodoInt)
                    com.Parameters.AddWithValue("@nodo_padre", nodoPadreInt)
                    com.Parameters.AddWithValue("@desc_nodo", If(desc_nodo, String.Empty))
                    com.Parameters.AddWithValue("@nivel", nivelInt)
                    com.Parameters.AddWithValue("@estado_nodo", estado_nodo)
                    com.Parameters.AddWithValue("@cod_rmes", If(cod_rmes, String.Empty))
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty))
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
                    com.Parameters.AddWithValue("@fecha_instalacion", fecha_instalacion)
                    com.Parameters.AddWithValue("@fecha_creacion", Now.ToString("yyyyMMdd"))
                    com.Parameters.AddWithValue("@prioridad", prioInt)
                    com.Parameters.AddWithValue("@codigo_sap", If(cod_sap, String.Empty))
                    com.Parameters.AddWithValue("@aplica_mantencion", aplica_mant)
                    com.Parameters.AddWithValue("@grupo", If(grupo, String.Empty))

                    Using DR As SqlDataReader = com.ExecuteReader
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), 0, Convert.ToInt32(DR(0)))
                            resp = If(DR.FieldCount > 1 AndAlso Not IsDBNull(DR(1)), DR(1).ToString(), String.Empty)
                        End If
                    End Using
                End Using
            End Using
            InvalidarCacheNodos()
        Catch ex As Exception
            cod_resp = -1
            resp = ex.Message
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Nodo")
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
            .txtPrioridad.Text = "0"
            .txtPrioridad2.Text = "0"
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
        Dim conexion As New Conexion
        Dim resp As String = ""
        Dim idNodoInt As Integer = 0
        If Not Integer.TryParse(If(id_nodo, String.Empty).Trim(), idNodoInt) Then Return String.Empty
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("BUSCAR_NODO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_nodo", idNodoInt)

                    Using DR As SqlDataReader = com.ExecuteReader
                        If DR.Read() AndAlso Not IsDBNull(DR(0)) Then
                            If Convert.ToInt32(DR(0)) = 1 AndAlso Not IsDBNull(DR(1)) Then
                                resp = DR(1).ToString()
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Nodo")
        End Try

        Return resp
    End Function

    Public Sub UpdNodo(ByVal id_nodo As String, ByVal nodo_padre As String, ByVal desc_nodo As String, ByVal nivel As String, ByVal estado_nodo As Boolean, ByVal cod_rmes As String, ByVal sesion As String, ByVal fecha_instalacion As DateTime, ByVal prioridad As String, ByVal cod_sap As String, ByVal aplica_mant As Boolean, ByVal grupo As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty
        Dim idNodoInt, nodoPadreInt, nivelInt, prioInt As Integer
        If Not Integer.TryParse(If(id_nodo, String.Empty).Trim(), idNodoInt) OrElse
           Not Integer.TryParse(If(nodo_padre, String.Empty).Trim(), nodoPadreInt) OrElse
           Not Integer.TryParse(If(nivel, String.Empty).Trim(), nivelInt) Then
            resp = "Datos numéricos del nodo o nodo padre inválidos."
            Exit Sub
        End If
        Integer.TryParse(If(prioridad, String.Empty).Trim(), prioInt)

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("UPD_NODO", cnx)
                    com.CommandType = CommandType.StoredProcedure

                    com.Parameters.AddWithValue("@id_nodo", idNodoInt)
                    com.Parameters.AddWithValue("@nodo_padre", nodoPadreInt)
                    com.Parameters.AddWithValue("@desc_nodo", If(desc_nodo, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nivel", nivelInt)
                    com.Parameters.AddWithValue("@estado_nodo", estado_nodo)
                    com.Parameters.AddWithValue("@cod_rmes", If(cod_rmes, String.Empty).Trim())
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
                    com.Parameters.AddWithValue("@fecha_instalacion", fecha_instalacion)
                    com.Parameters.AddWithValue("@prioridad", prioInt)
                    com.Parameters.AddWithValue("@codigo_sap", If(cod_sap, String.Empty).Trim())
                    com.Parameters.AddWithValue("@aplica_mantencion", aplica_mant)
                    com.Parameters.AddWithValue("@grupo", If(grupo, String.Empty).Trim())

                    Using DR As SqlDataReader = com.ExecuteReader
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                        End If
                    End Using
                End Using
            End Using
            InvalidarCacheNodos()
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Nodo")
        End Try
    End Sub

    Public Function ValidarIngresoNodo() As String
        Dim respuesta As String = ""

        With FrmAdminNodos
            If String.IsNullOrWhiteSpace(.txtIDNodoSel.Text) Then
                respuesta = "Debe seleccionar un nodo padre." & Environment.NewLine
            End If

            If String.IsNullOrWhiteSpace(.txtIDNuevoNodo.Text) Then
                respuesta &= "Debe crear un ID para el nuevo nodo." & Environment.NewLine
            End If

            If String.IsNullOrWhiteSpace(.txtDescNuevoNodo.Text) Then
                respuesta &= "Debe ingresar una descripción para el nuevo nodo." & Environment.NewLine
            End If
        End With

        Return respuesta
    End Function

    Public Function ValidarActualizacionNodo() As String
        Dim respuesta As String = ""

        With FrmAdminNodos
            If String.IsNullOrWhiteSpace(.txtIDNodoSel.Text) Then
                respuesta = "Debe seleccionar un nodo en el árbol." & Environment.NewLine
            End If

            If String.IsNullOrWhiteSpace(.txtDescNodoSel.Text) Then
                respuesta &= "Debe agregar una descripción del nodo." & Environment.NewLine
            End If

            If String.IsNullOrWhiteSpace(.id_nodo_padre) Then
                respuesta &= "Debe seleccionar el nodo a modificar en el árbol para obtener el ID del Padre." & Environment.NewLine
            End If
        End With

        Return respuesta
    End Function

    Public Sub AutocompletadoArbol(ByRef txt_desc_nodo As TextBox)
        If txt_desc_nodo Is Nothing Then Exit Sub

        If _cacheAutocompletado Is Nothing Then
            Dim conexion As New Conexion
            Dim cnx As New SqlConnection
            Dim datos As New AutoCompleteStringCollection

            Try
                conexion.Conectar(cnx)
                Using com As New SqlCommand("AUTOCOMPLETAR_ARBOL", cnx)
                    com.CommandType = CommandType.StoredProcedure

                    Using DR As SqlDataReader = com.ExecuteReader
                        While DR.Read
                            datos.Add(DR(0).ToString)
                        End While
                    End Using
                End Using
                _cacheAutocompletado = datos
            Catch ex As Exception
                RegistroErrores.MostrarYRegistrar(ex, "Autocompletado Arbol")
                Exit Sub
            Finally
                conexion.Desconectar(cnx)
            End Try
        End If

        With txt_desc_nodo
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .AutoCompleteCustomSource = _cacheAutocompletado
        End With
    End Sub

    Public Function NuevoIdTareaNodo() As Integer
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Dim id_tarea As Integer = 0

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("NUEVO_ID_TAREA_NODO", cnx)
                com.CommandType = CommandType.StoredProcedure

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        id_tarea = DR(0)
                    End If
                End Using
            End Using
            Return id_tarea
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Nuevo ID Tarea Nodo")
            Return id_tarea
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Function

    Public Sub IngTareaNodo(ByVal id_tarea As String, ByVal id_nodo As String, ByVal desc_tarea As String, ByVal tipo_mantencion As String, ByVal orden_despliegue As Integer, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty
        Dim idTareaInt, idNodoInt As Integer
        If Not Integer.TryParse(If(id_tarea, String.Empty).Trim(), idTareaInt) OrElse
           Not Integer.TryParse(If(id_nodo, String.Empty).Trim(), idNodoInt) Then
            cod_resp = -1
            resp = "Identificadores de tarea o nodo no válidos."
            Return
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("ING_TAREA_NODO", cnx)
                    com.CommandType = CommandType.StoredProcedure

                    com.Parameters.AddWithValue("@id_tarea", idTareaInt)
                    com.Parameters.AddWithValue("@id_nodo", idNodoInt)
                    com.Parameters.AddWithValue("@desc_tarea", If(desc_tarea, String.Empty))
                    com.Parameters.AddWithValue("@tipo_mantencion", If(tipo_mantencion, String.Empty))
                    com.Parameters.AddWithValue("@orden_despliegue", orden_despliegue)
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty))
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader
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
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Tarea Nodo")
        End Try
    End Sub

    Public Sub DelTareaNodo(ByVal id_tarea As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty
        Dim idTareaInt As Integer
        If Not Integer.TryParse(If(id_tarea, String.Empty).Trim(), idTareaInt) Then
            cod_resp = -1
            resp = "Identificador de tarea no válido."
            Return
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("DEL_TAREA_NODO", cnx)
                    com.CommandType = CommandType.StoredProcedure

                    com.Parameters.AddWithValue("@id_tarea", idTareaInt)
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty))
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader
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
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Tarea Nodo")
        End Try
    End Sub

    Public Sub limpiar_arbol(ByVal id_nodo As String, ByRef arbol As TreeView)
        If arbol Is Nothing Then Exit Sub
        If id_nodo <> "0" AndAlso id_nodo <> "" Then
            Dim nodo_find() As TreeNode = arbol.Nodes.Find(id_nodo, True)
            If nodo_find.Length > 0 Then
                For Each n As TreeNode In nodo_find
                    n.BackColor = Color.White
                Next
            End If
        End If
    End Sub

    Public Shared Sub LimpiarResaltadoNodos(ByVal nodos As TreeNodeCollection)
        If nodos Is Nothing Then Exit Sub
        For Each n As TreeNode In nodos
            If n.BackColor <> Color.Empty Then
                n.BackColor = Color.Empty
            End If
            If n.ForeColor <> Color.Empty Then
                n.ForeColor = Color.Empty
            End If
            If n.Nodes.Count > 0 Then
                LimpiarResaltadoNodos(n.Nodes)
            End If
        Next
    End Sub

    Public Shared Sub SeleccionarNodoPorId(ByVal arbol As TreeView, ByVal idNodo As String, ByRef idNodoSelect As String)
        If arbol Is Nothing OrElse String.IsNullOrEmpty(idNodo) Then Exit Sub
        Dim nodo_finded() As TreeNode = arbol.Nodes.Find(idNodo, True)
        If nodo_finded IsNot Nothing AndAlso nodo_finded.Length > 0 Then
            Dim objetivo As TreeNode = nodo_finded(0)
            LimpiarResaltadoNodos(arbol.Nodes)
            objetivo.EnsureVisible()
            arbol.SelectedNode = objetivo
            objetivo.BackColor = Utilitarios.ColorPrimario
            objetivo.ForeColor = Color.White
            idNodoSelect = idNodo

            If arbol.IsHandleCreated Then
                Dim aplicar As MethodInvoker = Sub()
                                                   If Not arbol.IsDisposed AndAlso objetivo.TreeView Is arbol Then
                                                       LimpiarResaltadoNodos(arbol.Nodes)
                                                       objetivo.EnsureVisible()
                                                       arbol.SelectedNode = objetivo
                                                       objetivo.BackColor = Utilitarios.ColorPrimario
                                                       objetivo.ForeColor = Color.White
                                                       arbol.Invalidate()
                                                   End If
                                               End Sub
                arbol.BeginInvoke(aplicar)
            End If
        End If
    End Sub

    Private Shared Sub BuscarNodosCoincidentes(ByVal nodos As TreeNodeCollection, ByVal termino As String, ByVal prefijos As List(Of TreeNode), ByVal contenidos As List(Of TreeNode))
        If nodos Is Nothing Then Exit Sub
        Dim comp As Globalization.CompareInfo = Globalization.CultureInfo.CurrentCulture.CompareInfo
        Dim opts As Globalization.CompareOptions = Globalization.CompareOptions.IgnoreCase Or Globalization.CompareOptions.IgnoreNonSpace

        For Each n As TreeNode In nodos
            If n.Name <> "1" Then
                Dim idx As Integer = comp.IndexOf(n.Text, termino, opts)
                If idx = 0 Then
                    prefijos.Add(n)
                ElseIf idx > 0 OrElse String.Equals(n.Name, termino, StringComparison.OrdinalIgnoreCase) Then
                    contenidos.Add(n)
                End If
            End If
            If n.Nodes.Count > 0 Then
                BuscarNodosCoincidentes(n.Nodes, termino, prefijos, contenidos)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Busca en tiempo real en el TreeView por prefijo o contenido (insensible a mayúsculas y tildes),
    ''' expande la rama encontrada, permite avanzar entre coincidencias con Enter/Flecha Abajo y limpia el resaltado al borrar.
    ''' </summary>
    Public Sub BuscarYSeleccionarNodoArbol(ByVal arbol As TreeView, ByVal txtBuscar As TextBox, ByVal e As KeyEventArgs, ByRef idNodoSelect As String, ByRef nodoAnterior As String, Optional ByVal opcionSql As Integer = 2)
        If arbol Is Nothing OrElse txtBuscar Is Nothing Then Exit Sub

        If e IsNot Nothing Then
            Select Case e.KeyCode
                Case Keys.ShiftKey, Keys.ControlKey, Keys.Menu, Keys.CapsLock, Keys.Tab, Keys.Left, Keys.Right, Keys.Up, Keys.Home, Keys.End
                    Exit Sub
                Case Keys.Escape
                    txtBuscar.Clear()
            End Select
        End If

        Dim termino As String = txtBuscar.Text.Trim()
        If String.IsNullOrEmpty(termino) Then
            txtBuscar.BackColor = Color.White
            txtBuscar.ForeColor = Utilitarios.ColorTextoPrincipal
            LimpiarResaltadoNodos(arbol.Nodes)
            arbol.SelectedNode = Nothing
            idNodoSelect = ""
            nodoAnterior = ""
            arbol.Invalidate()
            Exit Sub
        End If

        Dim prefijos As New List(Of TreeNode)()
        Dim contenidos As New List(Of TreeNode)()
        BuscarNodosCoincidentes(arbol.Nodes, termino, prefijos, contenidos)

        Dim coincidencias As New List(Of TreeNode)(prefijos.Count + contenidos.Count)
        coincidencias.AddRange(prefijos)
        coincidencias.AddRange(contenidos)

        ' Respaldo por base de datos si se busca por código RMES/SAP
        If coincidencias.Count = 0 Then
            Dim idSql As String = BuscarIdNodoLike(termino & "%", opcionSql)
            If Not String.IsNullOrEmpty(idSql) Then
                Dim encontrados() As TreeNode = arbol.Nodes.Find(idSql, True)
                If encontrados.Length > 0 Then
                    coincidencias.AddRange(encontrados)
                End If
            End If
        End If

        If coincidencias.Count > 0 Then
            ' Fondo verde/cian muy suave indicando coincidencia encontrada
            txtBuscar.BackColor = Color.FromArgb(240, 253, 250)
            txtBuscar.ForeColor = Utilitarios.ColorTextoPrincipal
            Dim elegido As TreeNode = coincidencias(0)

            If e IsNot Nothing AndAlso (e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Down) AndAlso arbol.SelectedNode IsNot Nothing Then
                Dim idxActual As Integer = coincidencias.IndexOf(arbol.SelectedNode)
                If idxActual >= 0 Then
                    elegido = coincidencias((idxActual + 1) Mod coincidencias.Count)
                End If
            End If

            ' Limpiar resaltados anteriores
            LimpiarResaltadoNodos(arbol.Nodes)

            ' 1. Resaltar TODAS las ramas/nodos coincidentes con el tono turquesa suave de la paleta
            For Each cNode As TreeNode In coincidencias
                cNode.BackColor = Color.FromArgb(217, 241, 244) ' Turquesa suave (#D9F1F4)
                cNode.ForeColor = Color.FromArgb(2, 94, 135)    ' Azul petróleo (#025E87)
            Next

            ' 2. Destacar prominentemente el nodo ACTIVO seleccionado con el color principal de la paleta
            elegido.EnsureVisible()
            arbol.SelectedNode = elegido
            elegido.BackColor = Color.FromArgb(2, 94, 135)       ' Azul petróleo corporativo (#025E87)
            elegido.ForeColor = Color.White                      ' Texto blanco alto contraste
            idNodoSelect = elegido.Name
            nodoAnterior = elegido.Name

            ' Asegurar selección robusta mediante BeginInvoke cuando el árbol tiene foco o procesa eventos de mouse
            If arbol.IsHandleCreated Then
                Dim targetNode As TreeNode = elegido
                Dim todasCoincidencias As New List(Of TreeNode)(coincidencias)
                Dim aplicar As MethodInvoker = Sub()
                                                   If Not arbol.IsDisposed AndAlso targetNode IsNot Nothing AndAlso targetNode.TreeView Is arbol Then
                                                       LimpiarResaltadoNodos(arbol.Nodes)
                                                       For Each cNode As TreeNode In todasCoincidencias
                                                           If cNode.TreeView Is arbol Then
                                                               cNode.BackColor = Color.FromArgb(217, 241, 244)
                                                               cNode.ForeColor = Color.FromArgb(2, 94, 135)
                                                           End If
                                                       Next
                                                       targetNode.EnsureVisible()
                                                       arbol.SelectedNode = targetNode
                                                       targetNode.BackColor = Color.FromArgb(2, 94, 135)
                                                       targetNode.ForeColor = Color.White
                                                       arbol.Invalidate()
                                                   End If
                                               End Sub
                arbol.BeginInvoke(aplicar)
            End If
        Else
            LimpiarResaltadoNodos(arbol.Nodes)
            txtBuscar.BackColor = Utilitarios.ColorErrorInput
            arbol.Invalidate()
            If e IsNot Nothing AndAlso e.KeyCode = Keys.Enter Then
                MsgBox("No se encontró el ítem '" & termino & "'", MsgBoxStyle.Exclamation, "Información")
                txtBuscar.SelectAll()
            End If
        End If
    End Sub

    Public Function BuscarIdNodoLike(ByVal desc_nodo As String, ByVal opcion As Integer) As String
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim cod_nodo As String = ""
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("BUSCAR_NODO_LIKE", cnx)
                com.CommandType = CommandType.StoredProcedure
                com.Parameters.AddWithValue("@nombre_nodo", desc_nodo)
                com.Parameters.AddWithValue("@opcion", opcion)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_nodo = DR(0).ToString()
                    End If
                End Using
            End Using

        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar ID Nodo Like")
        Finally
            conexion.Desconectar(cnx)
        End Try

        Return cod_nodo
    End Function

End Class
