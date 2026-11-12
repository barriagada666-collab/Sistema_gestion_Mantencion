Imports System.Data.SqlClient
Public Class Planta

    Public Sub crgPlanta(ByRef combo As ComboBox)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_CMB_PLANTA", cnx)
            Dim DS As New DataSet

            DA.Fill(DS)
            combo.DataSource = DS.Tables(0)
            combo.DisplayMember = "DESCRIPCION"
            combo.ValueMember = "CODIGO"
            conexion.Desconectar(cnx)
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub IngPlanta(ByVal cod_planta As String, ByVal nombre_planta As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        If cod_planta = "" Then
            resp = "Código de planta en blanco, Favor ingresar!!!"
            cod_resp = 0
            Exit Sub
        ElseIf nombre_planta = "" Then
            resp = "Nombre de planta en blanco, Favor ingresar!!!"
            cod_resp = 0
            Exit Sub
        End If
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_CENTRO_TRABAJO", cnx)
            com.CommandType = CommandType.StoredProcedure
            Dim p_id_centro As SqlParameter = com.Parameters.AddWithValue("@id_centro", CInt(cod_planta))
            Dim p_desc_centro As SqlParameter = com.Parameters.AddWithValue("@desc_centro", nombre_planta)
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

    Public Sub UpdPlanta(ByVal cod_planta As String, ByVal nombre_planta As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_CENTRO_TRABAJO", cnx)
            com.CommandType = CommandType.StoredProcedure
            Dim p_id_centro As SqlParameter = com.Parameters.AddWithValue("@id_centro", CInt(cod_planta))
            Dim p_desc_centro As SqlParameter = com.Parameters.AddWithValue("@desc_centro", nombre_planta)
            Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", My.Computer.Name)

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

    Public Sub DelPlanta(ByVal cod_planta As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        If cod_planta = "" Then
            resp = "Código de planta en blanco, Favor ingresar!!!"
            cod_resp = 0
            Exit Sub
        End If
        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("DEL_CENTRO_TRABAJO", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_centro As SqlParameter = com.Parameters.AddWithValue("@id_centro", CInt(cod_planta))
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

    Public Sub LimpiarFrmPlanta()
        With FrmPlantas
            .txtCodPlanta.Text = ""
            .txtNomPlanta.Text = ""
            .txtCodPlanta.Focus()
        End With
    End Sub

    Public Sub CrgGrillaPlanta(ByRef DS As DataSet)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_CMB_PLANTA", cnx)

            DA.Fill(DS)
            conexion.Desconectar(cnx)
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
End Class
