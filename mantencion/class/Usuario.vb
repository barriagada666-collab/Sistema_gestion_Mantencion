Imports System.Data.SqlClient
Public Class Usuario
    Public Shared PermisoGuardarOt As Boolean = True
    Public Shared PermisoEliminarOt As Boolean = True
    Public Shared PermisoIngMp As Boolean = True
    Public Shared PermisoGuardarMp As Boolean = True
    Public Shared PermisoEliminarCicloMp As Boolean = True
    Public Shared PermisoEliminarMp As Boolean = True
    Public Shared PermisoCambiarTareasMp As Boolean = False
    Public Shared PermisoCambiarIdModTareas As Boolean = False

    Public Sub buscarUsuario(ByVal usuario As String, ByVal pass As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("buscarUsuario", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim par1 As New SqlClient.SqlParameter("@user", SqlDbType.VarChar, 15)
                Dim par2 As New SqlClient.SqlParameter("@pass", SqlDbType.VarChar, 10)

                par1.Value = usuario
                par2.Value = pass

                com.Parameters.Add(par1)
                com.Parameters.Add(par2)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(IsDBNull(DR(1)), "", DR(1).ToString())
                    End If
                End Using
            End Using

        Catch ex As Exception
            cod_resp = -1
            resp = ex.Message
            RegistroErrores.MostrarYRegistrar(ex, "Inicio de Sesión", True, Form.ActiveForm, True)
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub ingUsuario(ByVal rut As String, ByVal id_perfil As String, ByVal usuario As String, ByVal clave As String, ByVal estado As Boolean, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Dim activo As Char = ""

        Try
            If estado Then
                activo = "A"
            Else
                activo = "D"
            End If
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_USUARIO", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
                Dim p_perfil As SqlParameter = com.Parameters.AddWithValue("@id_perfil", CInt(id_perfil))
                Dim p_usuario As SqlParameter = com.Parameters.AddWithValue("@usuario", usuario)
                Dim p_clave As SqlParameter = com.Parameters.AddWithValue("@clave", clave)
                Dim p_estado As SqlParameter = com.Parameters.AddWithValue("@estado", activo)
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(IsDBNull(DR(1)), "", DR(1).ToString())
                    End If
                End Using
            End Using

        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Usuario")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub ingPermisoUsuario(ByVal rut As String, ByVal id_permiso As String, ByVal estado As Boolean)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("ING_PERMISOS_USUARIO", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim p_id_permiso As SqlParameter = com.Parameters.AddWithValue("@id_permiso", CInt(id_permiso))
                Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
                Dim p_estado As SqlParameter = com.Parameters.AddWithValue("@estado", estado)

                com.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Guardar Permisos de Usuario")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub UpdUsuario(ByVal rut As String, ByVal id_perfil As String, ByVal usuario As String, ByVal clave As String, ByVal estado As Boolean, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Dim activo As Char = ""

        Try
            If estado Then
                activo = "A"
            Else
                activo = "D"
            End If
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_USUARIO", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
                Dim p_perfil As SqlParameter = com.Parameters.AddWithValue("@perfil", CInt(id_perfil))
                Dim p_usuario As SqlParameter = com.Parameters.AddWithValue("@user", usuario)
                Dim p_clave As SqlParameter = com.Parameters.AddWithValue("@clave", clave)
                Dim p_estado As SqlParameter = com.Parameters.AddWithValue("@estado", activo)
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(IsDBNull(DR(1)), "", DR(1).ToString())
                    End If
                End Using
            End Using

        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Usuario")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub UpdPermisosUsuario(ByVal rut As String, ByVal id_permiso As String, ByVal estado As Boolean)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("UPD_PERMISOS_USUARIO", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim p_id_permiso As SqlParameter = com.Parameters.AddWithValue("@id_permiso", CInt(id_permiso))
                Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
                Dim p_estado As SqlParameter = com.Parameters.AddWithValue("@estado", estado)

                com.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Permisos de Usuario")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub DelUsuario(ByVal rut As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Using com As New SqlCommand("DEL_USUARIO", cnx)
                com.CommandType = CommandType.StoredProcedure

                Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
                Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
                Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                Using DR As SqlDataReader = com.ExecuteReader
                    If DR.Read() Then
                        cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                        resp = If(IsDBNull(DR(1)), "", DR(1).ToString())
                    End If
                End Using
            End Using

        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Usuario")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgCmbPerfil(ByRef combo As ComboBox)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_CMB_PERFILES", cnx)
                Dim DS As New DataSet
                DA.Fill(DS)
                If DS.Tables.Count > 0 Then
                    combo.DataSource = DS.Tables(0)
                    combo.DisplayMember = "desc_perfil"
                    combo.ValueMember = "idperfil"
                End If
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Perfiles de Usuario")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgUsuarios(ByRef DS As DataSet)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_USUARIOS", cnx)
                DA.Fill(DS)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Listado de Usuarios")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgPermisosUsuarioLogin(ByVal usuario As String, ByVal clave As String, ByVal rut As String)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Dim DS As New DataSet
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_PERMISOS_USUARIO", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim p_rut As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@rut", rut)
                Dim p_usuario As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@usuario", usuario)
                Dim p_clave As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@clave", clave)

                DA.Fill(DS)
            End Using

            '------- Carga los permisos de usuario de forma segura (sin instanciar formularios hijos en el login) ---------------------------------
            Dim dtPerm As DataTable = If(DS.Tables.Count > 0, DS.Tables(0), Nothing)
            principal.OrdenesDeTrabajoToolStripMenuItem.Enabled = ObtenerPermisoSeguro(dtPerm, 0, True)
            principal.MantPreventivaToolStripMenuItem.Enabled = ObtenerPermisoSeguro(dtPerm, 1, True)
            principal.InformesToolStripMenuItem.Enabled = ObtenerPermisoSeguro(dtPerm, 2, True)
            principal.MantenedorToolStripMenuItem.Enabled = ObtenerPermisoSeguro(dtPerm, 3, True)
            PermisoGuardarOt = ObtenerPermisoSeguro(dtPerm, 4, True) OrElse ObtenerPermisoSeguro(dtPerm, 5, True)
            PermisoEliminarOt = ObtenerPermisoSeguro(dtPerm, 6, True)
            PermisoIngMp = ObtenerPermisoSeguro(dtPerm, 8, True)
            PermisoGuardarMp = ObtenerPermisoSeguro(dtPerm, 9, True)
            PermisoEliminarCicloMp = ObtenerPermisoSeguro(dtPerm, 10, True)
            PermisoEliminarMp = ObtenerPermisoSeguro(dtPerm, 11, True)
            principal.NodosToolStripMenuItem.Enabled = ObtenerPermisoSeguro(dtPerm, 12, True)
            principal.PersonalToolStripMenuItem.Enabled = ObtenerPermisoSeguro(dtPerm, 13, True)
            principal.ItemsToolStripMenuItem.Enabled = ObtenerPermisoSeguro(dtPerm, 14, True)
            principal.UsuariosToolStripMenuItem.Enabled = ObtenerPermisoSeguro(dtPerm, 15, True)
            principal.TareasMaquinasToolStripMenuItem.Enabled = ObtenerPermisoSeguro(dtPerm, 16, True)
            principal.InformeResumenOrdenDeTrabajoToolStripMenuItem.Enabled = ObtenerPermisoSeguro(dtPerm, 17, True)
            principal.AuditoriaToolStripMenuItem.Enabled = ObtenerPermisoSeguro(dtPerm, 18, True)
            PermisoCambiarTareasMp = ObtenerPermisoSeguro(dtPerm, 19, False)
            PermisoCambiarIdModTareas = ObtenerPermisoSeguro(dtPerm, 20, False)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Permisos de Sesión")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgPermisosPerfil(ByVal DST_PER As DataSet, ByVal id_perfil As String)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_PERMISOS_PERFIL", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim p_id_perfil As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_perfil", CInt(id_perfil))

                DA.Fill(DST_PER)
            End Using

        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Permisos de Perfil")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgPermisosUsuario(ByVal usuario As String, ByVal clave As String, ByVal rut As String, ByRef DST_PER As DataSet)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_PERMISOS_USUARIO", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim p_rut As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@rut", rut)
                Dim p_usuario As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@usuario", usuario)
                Dim p_clave As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@clave", clave)

                DA.Fill(DST_PER)
            End Using

        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Permisos de Usuario")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgPermisos(ByRef DST_PER As DataSet, ByRef grupo_permiso As String)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_PERMISOS", cnx)
                DA.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim p_rut As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@grupo", grupo_permiso)

                DA.Fill(DST_PER)
            End Using

        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Grupo de Permisos")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub

    Public Sub CrgPermisosFormUsuario(ByRef grilla_modulos As DataGridView, ByRef grilla_mod_ot As DataGridView, ByRef grilla_mod_mp As DataGridView, ByRef grilla_mantenedores As DataGridView)
        Dim DST_PER As New DataSet

        CrgPermisos(DST_PER, "modulos")
        If DST_PER.Tables.Count > 0 Then
            ConfigurarGrillaPermisosIndividual(grilla_modulos, DST_PER.Tables(0))
        End If

        DST_PER.Tables.Clear()
        CrgPermisos(DST_PER, "OT")
        If DST_PER.Tables.Count > 0 Then
            ConfigurarGrillaPermisosIndividual(grilla_mod_ot, DST_PER.Tables(0))
        End If

        DST_PER.Tables.Clear()
        CrgPermisos(DST_PER, "MP")
        If DST_PER.Tables.Count > 0 Then
            ConfigurarGrillaPermisosIndividual(grilla_mod_mp, DST_PER.Tables(0))
        End If

        DST_PER.Tables.Clear()
        CrgPermisos(DST_PER, "mantenedores")
        If DST_PER.Tables.Count > 0 Then
            ConfigurarGrillaPermisosIndividual(grilla_mantenedores, DST_PER.Tables(0))
        End If
    End Sub

    Private Sub ConfigurarGrillaPermisosIndividual(ByVal grilla As DataGridView, ByVal dt As DataTable)
        If grilla Is Nothing Then Exit Sub
        grilla.DataSource = dt
        If grilla.Columns.Count >= 3 Then
            grilla.Columns(0).Visible = False
            With grilla.Columns(1)
                .HeaderText = "Descripción"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            With grilla.Columns(2)
                .HeaderText = "Estado"
                .Width = 55
                .Tag = "Fijo"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        End If
        grilla.RowHeadersVisible = False
        grilla.AllowUserToAddRows = False
        grilla.AllowUserToDeleteRows = False
        grilla.AllowUserToResizeRows = False
        grilla.RowTemplate.Height = 24
        grilla.SelectionMode = DataGridViewSelectionMode.CellSelect
        Utilitarios.AjustarColumnasGrilla(grilla)
    End Sub

    Public Sub LimpiarFrmUsuario()
        Dim DST_USUARIO As New DataSet

        With FrmAdminUsuarios
            .txtRutUsuario.Text = ""
            .txtNomUsuario.Text = ""
            .txtClave.Text = ""
            If .txtRutUsuario.Enabled = False Then
                .txtRutUsuario.Enabled = True
            End If

            CrgUsuarios(DST_USUARIO)
            If DST_USUARIO.Tables.Count > 0 Then
                .grillaUsuarios.DataSource = DST_USUARIO.Tables(0)
                .filtro.Table = DST_USUARIO.Tables(0)
                .ConfigurarEstiloGrillaUsuarios()
                Utilitarios.AjustarColumnasGrilla(.grillaUsuarios)
            End If
        End With

    End Sub

    Public Function ValidarIngUser(ByRef resp As String)
        Dim valida As Boolean = True

        With FrmAdminUsuarios
            If .txtRutUsuario.Text = "" Then
                valida = False
                resp = "Debe Ingresar el rut del usuario" & Chr(13)
            End If

            If .txtNomUsuario.Text = "" Then
                valida = False
                resp = resp & "Debe Ingresar el nombre de usuario" & Chr(13)
            End If

            If .txtClave.Text = "" Then
                valida = False
                resp = resp & "Debe Ingresar un contraseña" & Chr(13)
            End If

            If .cmbPerfil1.Text = "" Then
                valida = False
                resp = resp & "Debe seleccionar un perfil de usuario" & Chr(13)
            End If

        End With

        Return valida
    End Function

    Public Function ValidarRut(ByRef rut As String, ByRef digito As String) As Boolean

        Dim rutLimpio As String = rut
        Dim suma As Integer
        Dim contador As Integer = 2
        Dim valida As Boolean = True
        Dim retorno As Boolean = False
        Dim i As Integer


        For i = rutLimpio.Length - 1 To 0 Step -1
            If contador > 7 Then
                contador = 2
            End If

            Try
                suma += Integer.Parse(rutLimpio(i).ToString()) * contador
                contador += 1
            Catch ex As Exception
                valida = False
            End Try
        Next

        If valida Then
            Dim dv As Integer = 11 - (suma Mod 11)
            Dim DigVer As String = dv.ToString()

            If DigVer = "10" Then
                DigVer = "K"
            End If

            If DigVer = "11" Then
                DigVer = "0"
            End If

            If DigVer = digito.ToUpper Then
                retorno = True
            Else
                retorno = False
            End If
        End If

        Return retorno
    End Function

    Private Shared Function ObtenerPermisoSeguro(ByVal dt As DataTable, ByVal index As Integer, Optional ByVal def As Boolean = False) As Boolean
        If dt IsNot Nothing AndAlso index >= 0 AndAlso index < dt.Rows.Count Then
            If Not IsDBNull(dt.Rows(index).Item(1)) Then
                Dim valStr As String = dt.Rows(index).Item(1).ToString().Trim()
                Dim boolVal As Boolean = False
                If Boolean.TryParse(valStr, boolVal) Then Return boolVal
                Return (valStr = "1" OrElse valStr.Equals("true", StringComparison.OrdinalIgnoreCase))
            End If
        End If
        Return def
    End Function
End Class
