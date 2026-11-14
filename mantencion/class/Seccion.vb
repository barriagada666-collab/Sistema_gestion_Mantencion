Imports System.Data.SqlClient
Public Class Seccion

    Public Sub crgCmbSeccion(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        Try
            combo.BeginUpdate()
            Dim dt As DataTable = Conexion.ObtenerCatalogoEnCache("CRG_CMB_SECCION", Function()
                Dim conexion As New Conexion
                Dim cnx As New SqlConnection
                Try
                    conexion.Conectar(cnx)
                    Using DA As New SqlDataAdapter("CRG_CMB_SECCION", cnx)
                        Dim t As New DataTable()
                        DA.Fill(t)
                        Return t
                    End Using
                Finally
                    conexion.Desconectar(cnx)
                End Try
            End Function)
            If dt IsNot Nothing Then
                combo.DataSource = dt
                combo.DisplayMember = "DESCRIPCION"
                combo.ValueMember = "CODIGO"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            combo.EndUpdate()
        End Try
    End Sub

    Public Sub IngSeccion(ByVal cod_seccion As String, ByVal nombre_seccion As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        If cod_seccion = "" Then
            resp = "Código de sección en blanco, Favor ingresar!!!"
            cod_resp = 0
            Exit Sub
        ElseIf nombre_seccion = "" Then
            resp = "Nombre de sección en blanco, Favor ingresar!!!"
            cod_resp = 0
            Exit Sub
        End If
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_SECCION", cnx)
                com.CommandType = CommandType.StoredProcedure
                Dim p_id_seccion As SqlParameter = com.Parameters.AddWithValue("@idseccion", CInt(cod_seccion))
                Dim p_desc_seccion As SqlParameter = com.Parameters.AddWithValue("@desc_seccion", nombre_seccion)
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                        If cod_resp = 1 Then Conexion.InvalidarCacheCatalogos("CRG_CMB_SECCION")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub UpdSeccion(ByVal cod_seccion As String, ByVal nombre_seccion As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        If cod_seccion = "" Then
            resp = "Código de sección en blanco, Favor ingresar!!!"
            cod_resp = 0
            Exit Sub
        ElseIf nombre_seccion = "" Then
            resp = "Nombre de sección en blanco, Favor ingresar!!!"
            cod_resp = 0
            Exit Sub
        End If
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_SECCION", cnx)
                com.CommandType = CommandType.StoredProcedure
                Dim p_id_seccion As SqlParameter = com.Parameters.AddWithValue("@id_seccion", CInt(cod_seccion))
                Dim p_desc_seccion As SqlParameter = com.Parameters.AddWithValue("@desc_seccion", nombre_seccion)
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                        If cod_resp = 1 Then Conexion.InvalidarCacheCatalogos("CRG_CMB_SECCION")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub DelSeccion(ByVal cod_seccion As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion

        If cod_seccion = "" Then
            resp = "Código de sección en blanco, Favor ingresar!!!"
            cod_resp = 0
            Exit Sub
        End If
        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("DEL_SECCION", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim p_id_seccion As SqlParameter = com.Parameters.AddWithValue("@idseccion", CInt(cod_seccion))
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = DR(0)
                        resp = DR(1)
                        If cod_resp = 1 Then Conexion.InvalidarCacheCatalogos("CRG_CMB_SECCION")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validación")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub LimpiarFrmSeccion()
        With FrmSeccion
            .txtCodSeccion.Text = ""
            .txtDescSeccion.Text = ""
        End With
    End Sub

    Public Sub crgSeccion(ByRef DST As DataSet)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_SECCION", cnx)
                DA.Fill(DST)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub
End Class
