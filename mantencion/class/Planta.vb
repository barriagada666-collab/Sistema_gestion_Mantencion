Imports System.Data.SqlClient

Public Class Planta

    Public Sub crgPlanta(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        Try
            combo.BeginUpdate()
            Dim dt As DataTable = Conexion.ObtenerCatalogoEnCache("CRG_CMB_PLANTA", Function()
                Dim conexion As New Conexion
                Using cnx As New SqlConnection
                    conexion.Conectar(cnx)
                    Using DA As New SqlDataAdapter("CRG_CMB_PLANTA", cnx)
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
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Plantas")
        Finally
            combo.EndUpdate()
        End Try
    End Sub

    Public Sub IngPlanta(ByVal cod_planta As String, ByVal nombre_planta As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty

        Dim codLimpio As String = If(cod_planta, String.Empty).Trim()
        Dim nomLimpio As String = If(nombre_planta, String.Empty).Trim()
        Dim idCentro As Integer = 0

        If String.IsNullOrEmpty(codLimpio) Then
            resp = "Código de planta en blanco, favor ingresar."
            Exit Sub
        ElseIf Not Integer.TryParse(codLimpio, idCentro) Then
            resp = "El código de planta debe ser numérico."
            Exit Sub
        ElseIf String.IsNullOrEmpty(nomLimpio) Then
            resp = "Nombre de planta en blanco, favor ingresar."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("ING_CENTRO_TRABAJO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_centro", idCentro)
                    com.Parameters.AddWithValue("@desc_centro", nomLimpio)
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                            If cod_resp = 1 Then Conexion.InvalidarCacheCatalogos("CRG_CMB_PLANTA")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Planta")
        End Try
    End Sub

    Public Sub UpdPlanta(ByVal cod_planta As String, ByVal nombre_planta As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty

        Dim codLimpio As String = If(cod_planta, String.Empty).Trim()
        Dim nomLimpio As String = If(nombre_planta, String.Empty).Trim()
        Dim idCentro As Integer = 0

        If String.IsNullOrEmpty(codLimpio) Then
            resp = "Código de planta en blanco, favor ingresar."
            Exit Sub
        ElseIf Not Integer.TryParse(codLimpio, idCentro) Then
            resp = "El código de planta debe ser numérico."
            Exit Sub
        ElseIf String.IsNullOrEmpty(nomLimpio) Then
            resp = "Nombre de planta en blanco, favor ingresar."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("UPD_CENTRO_TRABAJO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_centro", idCentro)
                    com.Parameters.AddWithValue("@desc_centro", nomLimpio)
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                            If cod_resp = 1 Then Conexion.InvalidarCacheCatalogos("CRG_CMB_PLANTA")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Planta")
        End Try
    End Sub

    Public Sub DelPlanta(ByVal cod_planta As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty

        Dim codLimpio As String = If(cod_planta, String.Empty).Trim()
        Dim idCentro As Integer = 0

        If String.IsNullOrEmpty(codLimpio) Then
            resp = "Código de planta en blanco, favor ingresar."
            Exit Sub
        ElseIf Not Integer.TryParse(codLimpio, idCentro) Then
            resp = "El código de planta debe ser numérico."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("DEL_CENTRO_TRABAJO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_centro", idCentro)
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                            If cod_resp = 1 Then Conexion.InvalidarCacheCatalogos("CRG_CMB_PLANTA")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Planta")
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
        If DS Is Nothing Then DS = New DataSet()
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_CMB_PLANTA", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.Fill(DS)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Grilla Planta")
        End Try
    End Sub
End Class
