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
        For Each hijo As TreeNode In origen.Nodes
            destino.Nodes.Add(DirectCast(hijo.Clone(), TreeNode))
        Next
    End Sub

    Public Function CRG_NODO(ByVal id_nodo As Integer) As DataSet
        Dim ds_result As New DataSet
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using da As New SqlDataAdapter("CRG_NODOS_ACTIVOS " & id_nodo, cnx)
                da.Fill(ds_result, "nodo")
            End Using
        Finally
            conexion.Desconectar(cnx)
        End Try
        Return ds_result
    End Function

    Public Function CRG_NODO_2(ByVal id_nodo As Integer) As DataSet
        Dim ds_result As New DataSet
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using da As New SqlDataAdapter("CRG_NODOS_MANT_SI", cnx)
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.AddWithValue("@nodo_padre", id_nodo)
                da.Fill(ds_result, "nodo")
            End Using
        Finally
            conexion.Desconectar(cnx)
        End Try
        Return ds_result
    End Function

    Public Sub CRG_NODO_HIJO(ByRef nodo As TreeNode)
        If nodo Is Nothing Then Exit Sub

        If nodo.Name = "1" AndAlso _cacheRaizActivos IsNot Nothing Then
            CopiarHijos(_cacheRaizActivos, nodo)
            Exit Sub
        End If

        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            CargarHijosConConexion(nodo, cnx, 1)
            If nodo.Name = "1" Then
                _cacheRaizActivos = DirectCast(nodo.Clone(), TreeNode)
            End If
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Private Sub CargarHijosConConexion(ByVal nodoPadre As TreeNode, ByVal cnx As SqlConnection, ByVal modo As Integer)
        Dim dt As New DataTable()
        Dim spName As String = "CRG_NODOS_ACTIVOS"
        If modo = 2 Then
            spName = "CRG_NODOS_TODOS"
        ElseIf modo = 3 Then
            spName = "CRG_NODOS_MANT_SI"
        End If

        Using da As New SqlDataAdapter()
            If modo = 3 Then
                da.SelectCommand = New SqlCommand(spName, cnx)
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodoPadre.Name))
            Else
                da.SelectCommand = New SqlCommand(spName & " " & CInt(nodoPadre.Name).ToString(), cnx)
            End If
            da.Fill(dt)
        End Using

        For Each row As DataRow In dt.Rows
            Dim nodoHijo As New TreeNode()
            nodoHijo.Text = row("desc_nodo").ToString()
            nodoHijo.Name = row("idnodo").ToString()
            nodoPadre.Nodes.Add(nodoHijo)
            CargarHijosConConexion(nodoHijo, cnx, modo)
        Next
    End Sub

    Public Sub CRG_TAREAS_MP(ByVal nodo_padre As String, ByVal tipo_mp As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_TAREAS_NODO_MP", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))
                DA.SelectCommand.Parameters.AddWithValue("@tipo_mp", tipo_mp)

                DA.Fill(DS)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CRG_NODO_HIJO_2(ByRef nodo As TreeNode)
        Dim dst As DataSet = CRG_NODO(CInt(nodo.Name))
        For i As Integer = 1 To dst.Tables("nodo").Rows.Count
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

        Try
            conexion.Conectar(cnx)
            Using da As New SqlDataAdapter("CRG_NODOS_DST", cnx)
                da.Fill(ds_result)
            End Using
        Finally
            conexion.Desconectar(cnx)
        End Try

        Return ds_result
    End Function

    Public Function CRG_NODOS_TODOS(ByVal id_nodo As Integer) As DataSet
        Dim ds_result As New DataSet
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using da As New SqlDataAdapter("CRG_NODOS_TODOS " & id_nodo, cnx)
                da.Fill(ds_result, "nodo")
            End Using
        Finally
            conexion.Desconectar(cnx)
        End Try
        Return ds_result
    End Function

    Public Sub CRG_NODO_HIJO_TODOS(ByRef nodo As TreeNode)
        If nodo Is Nothing Then Exit Sub

        If nodo.Name = "1" AndAlso _cacheRaizTodos IsNot Nothing Then
            CopiarHijos(_cacheRaizTodos, nodo)
            Exit Sub
        End If

        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            CargarHijosConConexion(nodo, cnx, 2)
            If nodo.Name = "1" Then
                _cacheRaizTodos = DirectCast(nodo.Clone(), TreeNode)
            End If
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CRG_NODO_MANT_SI(ByRef nodo As TreeNode)
        If nodo Is Nothing Then Exit Sub

        If nodo.Name = "1" AndAlso _cacheRaizMantSi IsNot Nothing Then
            CopiarHijos(_cacheRaizMantSi, nodo)
            Exit Sub
        End If

        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            CargarHijosConConexion(nodo, cnx, 3)
            If nodo.Name = "1" Then
                _cacheRaizMantSi = DirectCast(nodo.Clone(), TreeNode)
            End If
        Finally
            conexion.Desconectar(cnx)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CRG_TAREAS_NODO(ByVal id_nodo_padre As String, ByVal tipo_mp As String, ByRef DS As DataSet)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_TAREAS_NODO", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(id_nodo_padre))
                DA.SelectCommand.Parameters.AddWithValue("@tipo_mp", tipo_mp)

                DA.Fill(DS)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Function BuscarIdNodo(ByVal desc_nodo As String) As String
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim id_nodo As String = ""
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("BUSCAR_NODO_X_NOMBRE", cnx)
                com.CommandType = CommandType.StoredProcedure
                com.Parameters.AddWithValue("@nombre_nodo", desc_nodo)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        id_nodo = DR(0).ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try

        Return id_nodo
    End Function

    Public Function NUEVO_ID_NODO() As String
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim id_nodo As String = ""
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("NUEVO_ID_NODO", cnx)
                com.CommandType = CommandType.StoredProcedure
                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        id_nodo = DR(0).ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try

        Return id_nodo
    End Function

    Public Sub IngNodo(ByVal id_nodo As String, ByVal nodo_padre As String, ByVal desc_nodo As String, ByVal nivel As String, ByVal estado_nodo As Boolean, ByVal cod_rmes As String, ByVal sesion As String, ByVal fecha_instalacion As DateTime, ByVal prioridad As String, ByVal cod_sap As String, ByVal aplica_mant As Boolean, ByVal grupo As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_NODO", cnx)
                com.CommandType = CommandType.StoredProcedure

                com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
                com.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))
                com.Parameters.AddWithValue("@desc_nodo", desc_nodo)
                com.Parameters.AddWithValue("@nivel", CInt(nivel))
                com.Parameters.AddWithValue("@estado_nodo", estado_nodo)
                com.Parameters.AddWithValue("@cod_rmes", cod_rmes)
                com.Parameters.AddWithValue("@sesion", sesion)
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
                com.Parameters.AddWithValue("@fecha_instalacion", fecha_instalacion)
                com.Parameters.AddWithValue("@fecha_creacion", Now.ToString("yyyyMMdd"))
                com.Parameters.AddWithValue("@prioridad", CInt(prioridad))
                com.Parameters.AddWithValue("@codigo_sap", cod_sap)
                com.Parameters.AddWithValue("@aplica_mantencion", aplica_mant)
                com.Parameters.AddWithValue("@grupo", grupo)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                    End If
                End Using
            End Using
            InvalidarCacheNodos()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
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
            Using com As New SqlCommand("BUSCAR_NODO", cnx)
                com.CommandType = CommandType.StoredProcedure
                com.Parameters.AddWithValue("@id_nodo", id_nodo)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        If DR(0) = 1 Then
                            resp = DR(1).ToString()
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try

        Return resp
    End Function

    Public Sub UpdNodo(ByVal id_nodo As String, ByVal nodo_padre As String, ByVal desc_nodo As String, ByVal nivel As String, ByVal estado_nodo As Boolean, ByVal cod_rmes As String, ByVal sesion As String, ByVal fecha_instalacion As DateTime, ByVal prioridad As String, ByVal cod_sap As String, ByVal aplica_mant As Boolean, ByVal grupo As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_NODO", cnx)
                com.CommandType = CommandType.StoredProcedure

                com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
                com.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))
                com.Parameters.AddWithValue("@desc_nodo", desc_nodo)
                com.Parameters.AddWithValue("@nivel", CInt(nivel))
                com.Parameters.AddWithValue("@estado_nodo", estado_nodo)
                com.Parameters.AddWithValue("@cod_rmes", cod_rmes)
                com.Parameters.AddWithValue("@sesion", sesion)
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
                com.Parameters.AddWithValue("@fecha_instalacion", fecha_instalacion)
                com.Parameters.AddWithValue("@prioridad", CInt(prioridad))
                com.Parameters.AddWithValue("@codigo_sap", cod_sap)
                com.Parameters.AddWithValue("@aplica_mantencion", aplica_mant)
                com.Parameters.AddWithValue("@grupo", grupo)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                    End If
                End Using
            End Using
            InvalidarCacheNodos()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Function ValidarIngresoNodo() As String
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

    Public Function ValidarActualizacionNodo() As String
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
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
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
            MsgBox(ex.Message)
            Return id_tarea
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Function

    Public Sub IngTareaNodo(ByVal id_tarea As String, ByVal id_nodo As String, ByVal desc_tarea As String, ByVal tipo_mantencion As String, ByVal orden_despliegue As Integer, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_TAREA_NODO", cnx)
                com.CommandType = CommandType.StoredProcedure

                com.Parameters.AddWithValue("@id_tarea", CInt(id_tarea))
                com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
                com.Parameters.AddWithValue("@desc_tarea", desc_tarea)
                com.Parameters.AddWithValue("@tipo_mantencion", tipo_mantencion)
                com.Parameters.AddWithValue("@orden_despliegue", orden_despliegue)
                com.Parameters.AddWithValue("@sesion", sesion)
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader
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

    Public Sub DelTareaNodo(ByVal id_tarea As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("DEL_TAREA_NODO", cnx)
                com.CommandType = CommandType.StoredProcedure

                com.Parameters.AddWithValue("@id_tarea", CInt(id_tarea))
                com.Parameters.AddWithValue("@sesion", sesion)
                com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader
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
            If n.BackColor <> Color.Empty AndAlso n.BackColor <> Color.White Then
                n.BackColor = Color.White
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
            objetivo.BackColor = Utilitarios.ColorSeleccion
            idNodoSelect = idNodo

            If arbol.IsHandleCreated Then
                Dim aplicar As MethodInvoker = Sub()
                                                   If Not arbol.IsDisposed Then
                                                       LimpiarResaltadoNodos(arbol.Nodes)
                                                       objetivo.EnsureVisible()
                                                       arbol.SelectedNode = objetivo
                                                       objetivo.BackColor = Utilitarios.ColorSeleccion
                                                   End If
                                               End Sub
                arbol.BeginInvoke(aplicar)
            End If
        Else
            idNodoSelect = idNodo
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
            LimpiarResaltadoNodos(arbol.Nodes)
            arbol.SelectedNode = Nothing
            idNodoSelect = ""
            nodoAnterior = ""
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
            txtBuscar.BackColor = Utilitarios.ColorFondoInput
            Dim elegido As TreeNode = coincidencias(0)

            If e IsNot Nothing AndAlso (e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Down) AndAlso arbol.SelectedNode IsNot Nothing Then
                Dim idxActual As Integer = coincidencias.IndexOf(arbol.SelectedNode)
                If idxActual >= 0 Then
                    elegido = coincidencias((idxActual + 1) Mod coincidencias.Count)
                End If
            End If

            LimpiarResaltadoNodos(arbol.Nodes)
            elegido.EnsureVisible()
            arbol.SelectedNode = elegido
            elegido.BackColor = Utilitarios.ColorSeleccion
            idNodoSelect = elegido.Name
            nodoAnterior = elegido.Name

            ' Asegurar selección robusta mediante BeginInvoke cuando el árbol tiene foco o procesa eventos de mouse
            If arbol.IsHandleCreated Then
                Dim targetNode As TreeNode = elegido
                Dim aplicar As MethodInvoker = Sub()
                                                   If Not arbol.IsDisposed AndAlso targetNode IsNot Nothing Then
                                                       LimpiarResaltadoNodos(arbol.Nodes)
                                                       targetNode.EnsureVisible()
                                                       arbol.SelectedNode = targetNode
                                                       targetNode.BackColor = Utilitarios.ColorSeleccion
                                                   End If
                                               End Sub
                arbol.BeginInvoke(aplicar)
            End If
        Else
            LimpiarResaltadoNodos(arbol.Nodes)
            txtBuscar.BackColor = Utilitarios.ColorErrorInput
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try

        Return cod_nodo
    End Function

End Class
