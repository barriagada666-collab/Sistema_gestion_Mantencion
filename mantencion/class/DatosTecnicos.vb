Imports System.Data.SqlClient

Public Class DatosTecnicos
    Private Shared Function ParsearIdSeguro(ByVal valor As String, ByRef id As Integer) As Boolean
        Return Integer.TryParse(If(valor, String.Empty).Trim(), id)
    End Function

    Public Sub IngDatoTecnico(ByVal id_dato_tecnico As String, ByVal desc_dato_tecnico As String, ByVal estado_dato_tecnico As Boolean, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty
        Dim idDato As Integer = 0
        If Not ParsearIdSeguro(id_dato_tecnico, idDato) Then
            resp = "El ID del dato técnico debe ser numérico."
            Exit Sub
        End If
        Dim descLimpia As String = If(desc_dato_tecnico, String.Empty).Trim()
        If String.IsNullOrEmpty(descLimpia) Then
            resp = "Debe ingresar la descripción del dato técnico."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("ING_DATO_TECNICO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_dato_tecnico", idDato)
                    com.Parameters.AddWithValue("@desc_dato_tecnico", descLimpia)
                    com.Parameters.AddWithValue("@estado_dato_tecnico", estado_dato_tecnico)
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Dato Técnico")
        End Try
    End Sub

    Public Function NUEVO_ID_DATO_TECNICO() As Integer
        Dim conexion As New Conexion
        Dim idNuevo As Integer = 0

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("NUEVO_ID_DATO_TECNICO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() AndAlso Not IsDBNull(DR(0)) Then
                            Integer.TryParse(DR(0).ToString().Trim(), idNuevo)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Nuevo ID Dato Técnico")
        End Try

        Return idNuevo
    End Function

    Public Function BuscarIdDatoTecnico(ByVal id_dato_tecnico As String) As Integer
        Dim conexion As New Conexion
        Dim respuesta As Integer = 0
        Dim idDato As Integer = 0
        If Not ParsearIdSeguro(id_dato_tecnico, idDato) Then Return 0

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("BUSCAR_ID_DATO_TECNICO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_dato_tecnico", idDato)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() AndAlso Not IsDBNull(DR(0)) Then
                            Integer.TryParse(DR(0).ToString().Trim(), respuesta)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar ID Dato Técnico")
        End Try

        Return respuesta
    End Function

    Public Function BuscarIdDatoTecnicoNodo(ByVal id_dato_tecnico As String, ByVal id_nodo As String) As Integer
        Dim conexion As New Conexion
        Dim respuesta As Integer = 0
        Dim idDato As Integer = 0
        Dim idNodo As Integer = 0
        If Not ParsearIdSeguro(id_dato_tecnico, idDato) OrElse Not ParsearIdSeguro(id_nodo, idNodo) Then Return 0

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("BUSCAR_DATO_TECNICO_NODO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_dato_tecnico", idDato)
                    com.Parameters.AddWithValue("@id_nodo", idNodo)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() AndAlso Not IsDBNull(DR(0)) Then
                            Integer.TryParse(DR(0).ToString().Trim(), respuesta)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar ID Dato Técnico Nodo")
        End Try

        Return respuesta
    End Function

    Public Sub UpdDatoTecnico(ByVal id_dato_tecnico As String, ByVal desc_dato_tecnico As String, ByVal estado_dato_tecnico As Boolean, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty
        Dim idDato As Integer = 0
        If Not ParsearIdSeguro(id_dato_tecnico, idDato) Then
            resp = "El ID del dato técnico debe ser numérico."
            Exit Sub
        End If
        Dim descLimpia As String = If(desc_dato_tecnico, String.Empty).Trim()
        If String.IsNullOrEmpty(descLimpia) Then
            resp = "Debe ingresar la descripción del dato técnico."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("UPD_DATO_TECNICO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_dato_tecnico", idDato)
                    com.Parameters.AddWithValue("@desc_dato_tecnico", descLimpia)
                    com.Parameters.AddWithValue("@estado_dato_tecnico", estado_dato_tecnico)
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Dato Técnico")
        End Try
    End Sub

    Public Sub CrgDatosTecnicos(ByRef DST_DATOS_TECNICOS As DataSet)
        If DST_DATOS_TECNICOS Is Nothing Then DST_DATOS_TECNICOS = New DataSet()
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_DATOS_TECNICOS", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.Fill(DST_DATOS_TECNICOS)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Datos Técnicos")
        End Try
    End Sub

    Public Sub CrgDatosTecnicosNodo(ByVal nodo_padre As String, ByVal nivel As Integer, ByRef DST_DATOS_TECNICOS As DataSet)
        If DST_DATOS_TECNICOS Is Nothing Then DST_DATOS_TECNICOS = New DataSet()
        Dim idNodoPadre As Integer = 0
        If Not ParsearIdSeguro(nodo_padre, idNodoPadre) Then Exit Sub
        Dim conexion As New Conexion

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_DATOS_TECNICOS_NODO", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", idNodoPadre)
                    DA.SelectCommand.Parameters.AddWithValue("@nivel", nivel)
                    DA.Fill(DST_DATOS_TECNICOS)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Datos Técnicos Nodo")
        End Try
    End Sub

    Public Sub crgCmbDatosTecnicos(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_CMB_DATOS_TECNICOS", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    Using DS As New DataSet
                        DA.Fill(DS)
                        If DS.Tables.Count > 0 Then
                            combo.DisplayMember = "desc_dato_tecnico"
                            combo.ValueMember = "id_dato_tecnico"
                            combo.DataSource = DS.Tables(0).Copy()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Combo Datos Técnicos")
        End Try
    End Sub

    Public Sub IngDatoTecnicoNodo(ByVal id_dato_tecnico As String, ByVal id_nodo As String, ByVal valor As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty
        Dim idDato As Integer = 0
        Dim idNodo As Integer = 0
        If Not ParsearIdSeguro(id_dato_tecnico, idDato) OrElse Not ParsearIdSeguro(id_nodo, idNodo) Then
            resp = "ID de dato técnico o nodo inválido."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("ING_DATO_TECNICO_NODO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_dato_tecnico", idDato)
                    com.Parameters.AddWithValue("@id_nodo", idNodo)
                    com.Parameters.AddWithValue("@valor_dato_tecnico", If(valor, String.Empty).Trim())
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Dato Técnico Nodo")
        End Try
    End Sub

    Public Sub UpdDatoTecnicoNodo(ByVal id_dato_tecnico As String, ByVal id_nodo As String, ByVal valor As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty
        Dim idDato As Integer = 0
        Dim idNodo As Integer = 0
        If Not ParsearIdSeguro(id_dato_tecnico, idDato) OrElse Not ParsearIdSeguro(id_nodo, idNodo) Then
            resp = "ID de dato técnico o nodo inválido."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("UPD_DATO_TECNICO_NODO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_dato_tecnico", idDato)
                    com.Parameters.AddWithValue("@id_nodo", idNodo)
                    com.Parameters.AddWithValue("@valor_dato_tecnico", If(valor, String.Empty).Trim())
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Dato Técnico Nodo")
        End Try
    End Sub

    Public Sub ValidarIngDatosTecnicosNodo(ByRef msje As String)
        msje = String.Empty
        With FrmDatosTecnicosNodo
            Dim colValor As Integer = If(.nivel >= 3, 4, If(.nivel = 2, 5, 6))
            If .grillaDatosTecnicosNodo.Columns.Count <= colValor Then Exit Sub
            For i As Integer = 0 To .grillaDatosTecnicosNodo.RowCount - 1
                Dim row = .grillaDatosTecnicosNodo.Rows(i)
                If row.IsNewRow Then Continue For
                Dim vObj As Object = row.Cells(colValor).Value
                Dim valStr As String = If(vObj Is Nothing OrElse IsDBNull(vObj), String.Empty, vObj.ToString().Trim())
                If String.IsNullOrEmpty(valStr) Then
                    msje &= "Debe ingresar un valor para el dato técnico, Fila: " & (i + 1) & Environment.NewLine
                End If
            Next
        End With
    End Sub

    Public Sub BuscarDatoTecnicoNodoGrilla(ByRef msje As String, ByVal id_dato_tecnico_frm As String, ByVal id_modulo_frm As String)
        Dim dtTarget As String = If(id_dato_tecnico_frm, String.Empty).Trim()
        Dim modTarget As String = If(id_modulo_frm, String.Empty).Trim()

        With FrmDatosTecnicosNodo.grillaDatosTecnicosNodo
            If .Columns.Count < 2 Then Exit Sub
            For i As Integer = 0 To .RowCount - 1
                Dim row = .Rows(i)
                If row.IsNewRow Then Continue For
                Dim id_dato_tecnico As String = If(row.Cells(0).Value Is Nothing OrElse IsDBNull(row.Cells(0).Value), String.Empty, row.Cells(0).Value.ToString().Trim())
                Dim id_modulo As String = If(row.Cells(1).Value Is Nothing OrElse IsDBNull(row.Cells(1).Value), String.Empty, row.Cells(1).Value.ToString().Trim())

                If id_dato_tecnico = dtTarget AndAlso id_modulo = modTarget Then
                    msje = "El Dato Técnico ya está asociado al ítem, no se puede agregar."
                    Exit Sub
                End If
            Next
        End With
    End Sub

    Public Sub LimpiarFrmDatosTecnicosNodo()
        With FrmDatosTecnicosNodo
            Try
                If .DST_DATOS_TECNICOS_NODO.Tables.Count > 0 Then
                    Dim formato_grid As New FormatoGrillas
                    .nivel = 3
                    .DST_DATOS_TECNICOS_NODO.Tables.Clear()
                    .filtro_datos_tecnicos = New DataView()
                    .grillaDatosTecnicosNodo.DataSource = Nothing
                    .grillaDatosTecnicosNodo.Columns.Clear()
                    .grillaDatosTecnicosNodo.Columns.Add("id_dato_tecnico", "ID_Dato_Tecnico")
                    .grillaDatosTecnicosNodo.Columns.Add("id_modulo", "ID_Modulo")
                    .grillaDatosTecnicosNodo.Columns.Add("desc_modulo", "Módulo/Máquina")
                    .grillaDatosTecnicosNodo.Columns.Add("desc_dato_tecnico", "Descripción_Dato_Técnico")
                    .grillaDatosTecnicosNodo.Columns.Add("valor_dato_tecnico", "Valor_Dato_Tecnico")
                    .grillaDatosTecnicosNodo.Columns.Add("grupo_dato_tecnico", "Grupo")
                    formato_grid.grillaDatosTecnicos(.grillaDatosTecnicosNodo)
                    .id_nodo_select = ""
                    .form_limpio = True
                Else
                    .grillaDatosTecnicosNodo.Rows.Clear()
                End If

                If .del_dato_tecnico IsNot Nothing AndAlso .del_dato_tecnico.Length > 0 Then
                    Array.Clear(.del_dato_tecnico, 0, .del_dato_tecnico.Length)
                End If
                .LimpiarColaEliminaciones()
                .fila_del_dato_tecnico = 0
                .lblGrillaDatosTecnicos.Text = "Datos Técnicos Asociados"
                .grpFiltroDatosTecnicos.Enabled = False
            Catch ex As Exception
                RegistroErrores.MostrarYRegistrar(ex, "Limpiar Formulario Datos Técnicos Nodo")
            End Try
        End With
    End Sub

    Public Sub DelDatoTecnicoNodo(ByVal id_dato_tecnico As String, ByVal id_nodo As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty
        Dim idDato As Integer = 0
        Dim idNodo As Integer = 0
        If Not ParsearIdSeguro(id_dato_tecnico, idDato) OrElse Not ParsearIdSeguro(id_nodo, idNodo) Then
            resp = "ID de dato técnico o nodo inválido."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("DEL_DATO_TECNICO_NODO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_dato_tecnico", idDato)
                    com.Parameters.AddWithValue("@id_nodo", idNodo)
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Dato Técnico Nodo")
        End Try
    End Sub
End Class
