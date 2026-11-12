Imports System.Data.SqlClient
Public Class DatosTecnicos
    Public Sub IngDatoTecnico(ByVal id_dato_tecnico As String, ByVal desc_dato_tecnico As String, ByVal estado_dato_tecnico As Boolean, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_DATO_TECNICO", cnx)
                com.CommandType = CommandType.StoredProcedure
                Dim p_id_dato_tecnico As SqlParameter = com.Parameters.AddWithValue("@id_dato_tecnico", CInt(id_dato_tecnico))
                Dim p_desc_dato_tecnico As SqlParameter = com.Parameters.AddWithValue("@desc_dato_tecnico", desc_dato_tecnico)
                Dim p_estado_dato_tecnico As SqlParameter = com.Parameters.AddWithValue("@estado_dato_tecnico", estado_dato_tecnico)
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

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

    Public Function NUEVO_ID_DATO_TECNICO() As Integer
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim id_nodo As String = "0"

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("NUEVO_ID_DATO_TECNICO", cnx)
                com.CommandType = CommandType.StoredProcedure
                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        id_nodo = DR(0)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try

        Return CInt(id_nodo)
    End Function

    Public Function BuscarIdDatoTecnico(ByVal id_dato_tecnico As String) As Integer
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim respuesta As String = "0"

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("BUSCAR_ID_DATO_TECNICO", cnx)
                com.CommandType = CommandType.StoredProcedure
                Dim p_desc_nodo As SqlParameter = com.Parameters.AddWithValue("@id_dato_tecnico", CInt(id_dato_tecnico))

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        respuesta = DR(0)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try

        Return CInt(respuesta)
    End Function

    Public Function BuscarIdDatoTecnicoNodo(ByVal id_dato_tecnico As String, ByVal id_nodo As String) As Integer
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim respuesta As String = "0"

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("BUSCAR_DATO_TECNICO_NODO", cnx)
                com.CommandType = CommandType.StoredProcedure
                Dim p_id_dato_tecnico As SqlParameter = com.Parameters.AddWithValue("@id_dato_tecnico", CInt(id_dato_tecnico))
                Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        respuesta = DR(0)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try

        Return CInt(respuesta)
    End Function

    Public Sub UpdDatoTecnico(ByVal id_dato_tecnico As String, ByVal desc_dato_tecnico As String, ByVal estado_dato_tecnico As Boolean, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_DATO_TECNICO", cnx)
                com.CommandType = CommandType.StoredProcedure
                Dim p_id_dato_tecnico As SqlParameter = com.Parameters.AddWithValue("@id_dato_tecnico", CInt(id_dato_tecnico))
                Dim p_desc_dato_tecnico As SqlParameter = com.Parameters.AddWithValue("@desc_dato_tecnico", desc_dato_tecnico)
                Dim p_estado_dato_tecnico As SqlParameter = com.Parameters.AddWithValue("@estado_dato_tecnico", estado_dato_tecnico)
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

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

    Public Sub CrgDatosTecnicos(ByRef DST_DATOS_TECNICOS As DataSet)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_DATOS_TECNICOS", cnx)
                DA.Fill(DST_DATOS_TECNICOS)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgDatosTecnicosNodo(ByVal nodo_padre As String, ByVal nivel As Integer, ByRef DST_DATOS_TECNICOS As DataSet)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_DATOS_TECNICOS_NODO", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure

                Dim p_nodo_padre As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nodo_padre", CInt(nodo_padre))
                Dim p_nivel As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@nivel", nivel)

                DA.Fill(DST_DATOS_TECNICOS)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub crgCmbDatosTecnicos(ByRef combo As ComboBox)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_CMB_DATOS_TECNICOS", cnx)
                Dim DS As New DataSet
                DA.Fill(DS)
                combo.DataSource = DS.Tables(0)
                combo.DisplayMember = "desc_dato_tecnico"
                combo.ValueMember = "id_dato_tecnico"
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub IngDatoTecnicoNodo(ByVal id_dato_tecnico As String, ByVal id_nodo As String, ByVal valor As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_DATO_TECNICO_NODO", cnx)
                com.CommandType = CommandType.StoredProcedure
                Dim p_id_dato_tecnico As SqlParameter = com.Parameters.AddWithValue("@id_dato_tecnico", CInt(id_dato_tecnico))
                Dim p_desc_dato_tecnico As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
                Dim p_estado_dato_tecnico As SqlParameter = com.Parameters.AddWithValue("@valor_dato_tecnico", valor)
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

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

    Public Sub UpdDatoTecnicoNodo(ByVal id_dato_tecnico As String, ByVal id_nodo As String, ByVal valor As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_DATO_TECNICO_NODO", cnx)
                com.CommandType = CommandType.StoredProcedure
                Dim p_id_dato_tecnico As SqlParameter = com.Parameters.AddWithValue("@id_dato_tecnico", CInt(id_dato_tecnico))
                Dim p_desc_dato_tecnico As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
                Dim p_estado_dato_tecnico As SqlParameter = com.Parameters.AddWithValue("@valor_dato_tecnico", valor)
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

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

    Public Sub ValidarIngDatosTecnicosNodo(ByRef msje As String)
        With FrmDatosTecnicosNodo
            For i = 0 To .grillaDatosTecnicosNodo.RowCount - 1
                If .grillaDatosTecnicosNodo.Rows(i).Cells(4).Value = "" Then
                    If msje = "" Then
                        msje = "Debe ingresar un valor para el dato tecnico, Fila :" & i + 1 & Chr(13)
                    Else
                        msje = msje & "Debe ingresar un valor para el dato tecnico, Fila :" & i + 1 & Chr(13)
                    End If

                End If
            Next
        End With
    End Sub

    Public Sub BuscarDatoTecnicoNodoGrilla(ByRef msje As String, ByVal id_dato_tecnico_frm As String, ByVal id_modulo_frm As String)
        Dim id_dato_tecnico As String = ""
        Dim id_modulo As String = ""

        With FrmDatosTecnicosNodo.grillaDatosTecnicosNodo
            For i = 0 To .RowCount - 1
                id_dato_tecnico = .Rows(i).Cells(0).Value
                id_modulo = .Rows(i).Cells(1).Value

                If id_dato_tecnico = id_dato_tecnico_frm And id_modulo = id_modulo_frm Then
                    msje = "El Dato Tecnico ya esta asociado al Item, no se puede agregar"
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
                    .grillaDatosTecnicosNodo.DataSource = Nothing
                    .grillaDatosTecnicosNodo.Columns.Add("id_dato_tecnico", "ID_Dato_Tecnico")
                    .grillaDatosTecnicosNodo.Columns.Add("id_modulo", "ID_Modulo")
                    .grillaDatosTecnicosNodo.Columns.Add("desc_modulo", "Módulo/Máquina")
                    .grillaDatosTecnicosNodo.Columns.Add("desc_dato_tecnico", "Descripción_Dato_Técnico")
                    .grillaDatosTecnicosNodo.Columns.Add("valor_dato_tecnico", "Valor_Dato_Tecnico")
                    .grillaDatosTecnicosNodo.Columns.Add("grupo_dato_tecnico", "Grupo")
                    formato_grid.grillaDatosTecnicos(.grillaDatosTecnicosNodo)
                    .id_nodo_select = ""
                    .form_limpio = True
                    If .del_dato_tecnico.Length > 0 Then
                        For i = 0 To .del_dato_tecnico.GetUpperBound(0)
                            If .del_dato_tecnico(i, 0) <> 0 Then
                                .del_dato_tecnico(i, 0) = 0
                                .del_dato_tecnico(i, 1) = 0
                            Else
                                Exit For
                            End If
                        Next
                    End If

                    .fila_del_dato_tecnico = 0
                Else
                    .grillaDatosTecnicosNodo.Rows.Clear()

                    If .del_dato_tecnico.Length > 0 Then
                        For i = 0 To .del_dato_tecnico.GetUpperBound(0)
                            If .del_dato_tecnico(i, 0) <> 0 Then
                                .del_dato_tecnico(i, 0) = 0
                                .del_dato_tecnico(i, 1) = 0
                            Else
                                Exit For
                            End If
                        Next
                    End If

                    .fila_del_dato_tecnico = 0
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End With


    End Sub

    Public Sub DelDatoTecnicoNodo(ByVal id_dato_tecnico As String, ByVal id_nodo As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("DEL_DATO_TECNICO_NODO", cnx)
                com.CommandType = CommandType.StoredProcedure
                Dim p_id_dato_tecnico As SqlParameter = com.Parameters.AddWithValue("@id_dato_tecnico", CInt(id_dato_tecnico))
                Dim p_id_nodo As SqlParameter = com.Parameters.AddWithValue("@id_nodo", CInt(id_nodo))
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

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
End Class
