Imports System.Data.SqlClient
Public Class Cargo

    Public Sub crgCmbCargo(ByRef combo As ComboBox)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_CMB_CARGO", cnx)
            Dim DS As New DataSet

            DA.Fill(DS)
            combo.DataSource = DS.Tables(0)
            combo.DisplayMember = "desc_cargo"
            combo.ValueMember = "idcargo"
            conexion.Desconectar(cnx)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub crgTipoInter(ByRef combo As ComboBox)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_CMB_INTER", cnx)
            Dim DS As New DataSet

            DA.Fill(DS)
            combo.DataSource = DS.Tables(0)
            combo.DisplayMember = "desc_intervencion"
            combo.ValueMember = "idtipo"
        Catch ex As Exception

        End Try
    End Sub

    Public Sub DelCargo(ByVal cod_cargo As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("DEL_CARGO", cnx)
            com.CommandType = CommandType.StoredProcedure
            Dim p_id_centro As SqlParameter = com.Parameters.AddWithValue("@id_cargo", CInt(cod_cargo))
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

    Public Sub LimpiarFrmCargo()
        With FrmCargo
            .txtCodCargo.ResetText()
            .txtDescCargo.ResetText()
            .grillaCargos.DataSource = Nothing
        End With
    End Sub

    Public Sub IngCargo(ByVal cod_cargo As String, ByVal desc_cargo As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_CARGO", cnx)
            com.CommandType = CommandType.StoredProcedure
            Dim p_id_cargo As SqlParameter = com.Parameters.AddWithValue("@id_cargo", CInt(cod_cargo))
            Dim p_desc_cargo As SqlParameter = com.Parameters.AddWithValue("@desc_cargo", desc_cargo)
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

    Public Function BuscarCargo(ByVal id_cargo As String) As Integer
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Dim respuesta As Integer

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("BUSCAR_CARGO", cnx)
            com.CommandType = CommandType.StoredProcedure
            Dim p_id_centro As SqlParameter = com.Parameters.AddWithValue("@id_cargo", CInt(id_cargo))


            Dim DR As SqlDataReader = com.ExecuteReader
            If DR.Read() Then
                respuesta = DR(0)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        End Try

        Return respuesta
    End Function

    Public Sub UpdCargo(ByVal cod_cargo As String, ByVal desc_cargo As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_CARGO", cnx)
            com.CommandType = CommandType.StoredProcedure
            Dim p_id_cargo As SqlParameter = com.Parameters.AddWithValue("@id_cargo", CInt(cod_cargo))
            Dim p_desc_cargo As SqlParameter = com.Parameters.AddWithValue("@desc_cargo", desc_cargo)
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

    Public Sub CrgCargos(ByRef DST_CARGOS As DataSet)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_CARGOS", cnx)
            DA.Fill(DST_CARGOS)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            conexion.Desconectar(cnx)
        End Try
    End Sub
End Class
