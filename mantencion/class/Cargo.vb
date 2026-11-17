Imports System.Data.SqlClient

Public Class Cargo
    Public Sub crgCmbCargo(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        Try
            combo.BeginUpdate()
            Dim dt As DataTable = Conexion.ObtenerCatalogoEnCache("CRG_CMB_CARGO", Function()
                Dim conexion As New Conexion
                Using cnx As New SqlConnection
                    conexion.Conectar(cnx)
                    Using DA As New SqlDataAdapter("CRG_CMB_CARGO", cnx)
                        DA.SelectCommand.CommandType = CommandType.StoredProcedure
                        Dim t As New DataTable()
                        DA.Fill(t)
                        Return t
                    End Using
                End Using
            End Function)
            If dt IsNot Nothing Then
                combo.DisplayMember = "desc_cargo"
                combo.ValueMember = "idcargo"
                combo.DataSource = dt
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Cargos")
        Finally
            combo.EndUpdate()
        End Try
    End Sub

    Public Sub crgTipoInter(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        Try
            combo.BeginUpdate()
            Dim dt As DataTable = Conexion.ObtenerCatalogoEnCache("CRG_CMB_INTER", Function()
                Dim conexion As New Conexion
                Using cnx As New SqlConnection
                    conexion.Conectar(cnx)
                    Using DA As New SqlDataAdapter("CRG_CMB_INTER", cnx)
                        DA.SelectCommand.CommandType = CommandType.StoredProcedure
                        Dim t As New DataTable()
                        DA.Fill(t)
                        Return t
                    End Using
                End Using
            End Function)
            If dt IsNot Nothing Then
                combo.DisplayMember = "desc_intervencion"
                combo.ValueMember = "idtipo"
                combo.DataSource = dt
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Tipos de Intervención")
        Finally
            combo.EndUpdate()
        End Try
    End Sub

    Public Sub DelCargo(ByVal cod_cargo As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty
        Dim idCargo As Integer = 0
        If Not Integer.TryParse(If(cod_cargo, String.Empty).Trim(), idCargo) Then
            resp = "El código de cargo debe ser numérico."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("DEL_CARGO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_cargo", idCargo)
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                            If cod_resp = 1 Then Conexion.InvalidarCacheCatalogos("CRG_CMB_CARGO")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Cargo")
        End Try
    End Sub

    Public Sub LimpiarFrmCargo()
        With FrmCargo
            .txtCodCargo.ResetText()
            .txtDescCargo.ResetText()
            .grillaCargos.DataSource = Nothing
            .txtCodCargo.Focus()
        End With
    End Sub

    Public Sub IngCargo(ByVal cod_cargo As String, ByVal desc_cargo As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty
        Dim idCargo As Integer = 0
        Dim descLimpia As String = If(desc_cargo, String.Empty).Trim()

        If Not Integer.TryParse(If(cod_cargo, String.Empty).Trim(), idCargo) Then
            resp = "El código de cargo debe ser numérico."
            Exit Sub
        End If
        If String.IsNullOrEmpty(descLimpia) Then
            resp = "Debe ingresar la descripción del cargo."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("ING_CARGO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_cargo", idCargo)
                    com.Parameters.AddWithValue("@desc_cargo", descLimpia)
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                            If cod_resp = 1 Then Conexion.InvalidarCacheCatalogos("CRG_CMB_CARGO")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Cargo")
        End Try
    End Sub

    Public Function BuscarCargo(ByVal id_cargo As String) As Integer
        Dim conexion As New Conexion
        Dim respuesta As Integer = 0
        Dim idCargo As Integer = 0
        If Not Integer.TryParse(If(id_cargo, String.Empty).Trim(), idCargo) Then
            Return -2
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("BUSCAR_CARGO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_cargo", idCargo)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            respuesta = If(IsDBNull(DR(0)), 0, Convert.ToInt32(DR(0)))
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            respuesta = -1
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Cargo")
        End Try

        Return respuesta
    End Function

    Public Sub UpdCargo(ByVal cod_cargo As String, ByVal desc_cargo As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty
        Dim idCargo As Integer = 0
        Dim descLimpia As String = If(desc_cargo, String.Empty).Trim()

        If Not Integer.TryParse(If(cod_cargo, String.Empty).Trim(), idCargo) Then
            resp = "El código de cargo debe ser numérico."
            Exit Sub
        End If
        If String.IsNullOrEmpty(descLimpia) Then
            resp = "Debe ingresar la descripción del cargo."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("UPD_CARGO", cnx)
                    com.CommandType = CommandType.StoredProcedure
                    com.Parameters.AddWithValue("@id_cargo", idCargo)
                    com.Parameters.AddWithValue("@desc_cargo", descLimpia)
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                            If cod_resp = 1 Then Conexion.InvalidarCacheCatalogos("CRG_CMB_CARGO")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Cargo")
        End Try
    End Sub

    Public Sub CrgCargos(ByRef DST_CARGOS As DataSet)
        If DST_CARGOS Is Nothing Then DST_CARGOS = New DataSet()
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_CARGOS", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.Fill(DST_CARGOS)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Cargos")
        End Try
    End Sub
End Class
