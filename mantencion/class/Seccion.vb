Imports System.Data.SqlClient

Public Class Seccion

    Public Sub crgCmbSeccion(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        Try
            combo.BeginUpdate()
            Dim dt As DataTable = Conexion.ObtenerCatalogoEnCache("CRG_CMB_SECCION", Function()
                Dim conexion As New Conexion
                Using cnx As New SqlConnection
                    conexion.Conectar(cnx)
                    Using DA As New SqlDataAdapter("CRG_CMB_SECCION", cnx)
                        DA.SelectCommand.CommandType = CommandType.StoredProcedure
                        Dim t As New DataTable()
                        DA.Fill(t)
                        Return t
                    End Using
                End Using
            End Function)
            If dt IsNot Nothing Then
                combo.DisplayMember = "DESCRIPCION"
                combo.ValueMember = "CODIGO"
                combo.DataSource = dt
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Secciones")
        Finally
            combo.EndUpdate()
        End Try
    End Sub

    Public Sub IngSeccion(ByVal cod_seccion As String, ByVal nombre_seccion As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty

        Dim codLimpio As String = If(cod_seccion, String.Empty).Trim()
        Dim nomLimpio As String = If(nombre_seccion, String.Empty).Trim()
        Dim idSeccion As Integer = 0

        If String.IsNullOrEmpty(codLimpio) Then
            resp = "Código de sección en blanco, favor ingresar."
            Exit Sub
        ElseIf Not Integer.TryParse(codLimpio, idSeccion) Then
            resp = "El código de sección debe ser numérico."
            Exit Sub
        ElseIf String.IsNullOrEmpty(nomLimpio) Then
            resp = "Nombre de sección en blanco, favor ingresar."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("ING_SECCION", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@idseccion", idSeccion)
                    com.Parameters.AddWithValue("@desc_seccion", nomLimpio)
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                            If cod_resp = 1 Then Conexion.InvalidarCacheCatalogos("CRG_CMB_SECCION")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Sección")
        End Try
    End Sub

    Public Sub UpdSeccion(ByVal cod_seccion As String, ByVal nombre_seccion As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty

        Dim codLimpio As String = If(cod_seccion, String.Empty).Trim()
        Dim nomLimpio As String = If(nombre_seccion, String.Empty).Trim()
        Dim idSeccion As Integer = 0

        If String.IsNullOrEmpty(codLimpio) Then
            resp = "Código de sección en blanco, favor ingresar."
            Exit Sub
        ElseIf Not Integer.TryParse(codLimpio, idSeccion) Then
            resp = "El código de sección debe ser numérico."
            Exit Sub
        ElseIf String.IsNullOrEmpty(nomLimpio) Then
            resp = "Nombre de sección en blanco, favor ingresar."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("UPD_SECCION", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_seccion", idSeccion)
                    com.Parameters.AddWithValue("@desc_seccion", nomLimpio)
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                            If cod_resp = 1 Then Conexion.InvalidarCacheCatalogos("CRG_CMB_SECCION")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Sección")
        End Try
    End Sub

    Public Sub DelSeccion(ByVal cod_seccion As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty

        Dim codLimpio As String = If(cod_seccion, String.Empty).Trim()
        Dim idSeccion As Integer = 0

        If String.IsNullOrEmpty(codLimpio) Then
            resp = "Código de sección en blanco, favor ingresar."
            Exit Sub
        ElseIf Not Integer.TryParse(codLimpio, idSeccion) Then
            resp = "El código de sección debe ser numérico."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("DEL_SECCION", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@idseccion", idSeccion)
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                            If cod_resp = 1 Then Conexion.InvalidarCacheCatalogos("CRG_CMB_SECCION")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Sección")
        End Try
    End Sub

    Public Sub LimpiarFrmSeccion()
        With FrmSeccion
            .txtCodSeccion.Text = ""
            .txtDescSeccion.Text = ""
            .txtCodSeccion.Focus()
        End With
    End Sub

    Public Sub crgSeccion(ByRef DST As DataSet)
        If DST Is Nothing Then DST = New DataSet()
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_SECCION", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.Fill(DST)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Sección")
        End Try
    End Sub
End Class
