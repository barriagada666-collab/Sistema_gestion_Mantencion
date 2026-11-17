Imports System.Data.SqlClient

Public Class Usuario
    Public Shared PermisoGuardarOt As Boolean = False
    Public Shared PermisoEliminarOt As Boolean = False
    Public Shared PermisoAnularOt As Boolean = False
    Public Shared PermisoIngMp As Boolean = False
    Public Shared PermisoGuardarMp As Boolean = False
    Public Shared PermisoEliminarCicloMp As Boolean = False
    Public Shared PermisoEliminarMp As Boolean = False
    Public Shared PermisoCambiarTareasMp As Boolean = False
    Public Shared PermisoCambiarIdModTareas As Boolean = False

    Public Shared Property UsuarioAutenticado As Boolean = False
    Public Shared Property NombreUsuarioActual As String = String.Empty
    Public Shared Property RutUsuarioActual As String = String.Empty
    Public Shared Property PerfilActual As String = String.Empty
    Public Shared Property EsAdministrador As Boolean = False

    Public Shared Sub LimpiarSesion()
        UsuarioAutenticado = False
        NombreUsuarioActual = String.Empty
        RutUsuarioActual = String.Empty
        PerfilActual = String.Empty
        EsAdministrador = False
        PermisoGuardarOt = False
        PermisoEliminarOt = False
        PermisoAnularOt = False
        PermisoIngMp = False
        PermisoGuardarMp = False
        PermisoEliminarCicloMp = False
        PermisoEliminarMp = False
        PermisoCambiarTareasMp = False
        PermisoCambiarIdModTareas = False
    End Sub

    Public Shared Function EsPerfilAdministrador(ByVal perfil As String) As Boolean
        If String.IsNullOrWhiteSpace(perfil) Then Return False
        Return String.Equals(perfil.Trim(), "Administrador", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Sub buscarUsuario(ByVal usuario As String, ByVal pass As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("buscarUsuario", cnx)
                    com.CommandType = CommandType.StoredProcedure

                    Dim par1 As New SqlParameter("@user", SqlDbType.VarChar, 15)
                    Dim par2 As New SqlParameter("@pass", SqlDbType.VarChar, 10)
                    par1.Value = If(usuario, String.Empty).Trim()
                    par2.Value = If(pass, String.Empty)

                    com.Parameters.Add(par1)
                    com.Parameters.Add(par2)

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
            resp = ex.Message
            RegistroErrores.MostrarYRegistrar(ex, "Inicio de Sesión", True, Form.ActiveForm, True)
        End Try
    End Sub

    Public Sub ingUsuario(ByVal rut As String, ByVal id_perfil As String, ByVal usuario As String, ByVal clave As String, ByVal estado As Boolean, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        GuardarUsuarioCompleto(True, rut, id_perfil, usuario, clave, estado, Nothing, sesion, cod_resp, resp)
    End Sub

    Public Sub ingPermisoUsuario(ByVal rut As String, ByVal id_permiso As String, ByVal estado As Boolean)
        UpdPermisosUsuario(rut, id_permiso, estado)
    End Sub

    Public Sub UpdUsuario(ByVal rut As String, ByVal id_perfil As String, ByVal usuario As String, ByVal clave As String, ByVal estado As Boolean, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        GuardarUsuarioCompleto(False, rut, id_perfil, usuario, clave, estado, Nothing, sesion, cod_resp, resp)
    End Sub

    Public Sub UpdPermisosUsuario(ByVal rut As String, ByVal id_permiso As String, ByVal estado As Boolean)
        Dim idPerm As Integer
        If Not Integer.TryParse(If(id_permiso, String.Empty).Trim(), idPerm) Then Exit Sub
        Dim rutLimpio As String = If(rut, String.Empty).Trim()
        If String.IsNullOrEmpty(rutLimpio) Then Exit Sub

        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Dim rutDb As String = ResolverRutAlmacenado(cnx, Nothing, rutLimpio)
                UpsertPermisoEnConexion(cnx, Nothing, rutDb, idPerm, estado)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Permisos de Usuario")
        End Try
    End Sub

    ''' <summary>
    ''' Inserta o actualiza un usuario junto con todos sus permisos en una única transacción atómica,
    ''' evitando duplicados de RUT/usuario, bloqueando autodesactivación y registrando auditoría.
    ''' </summary>
    Public Sub GuardarUsuarioCompleto(ByVal esNuevo As Boolean,
                                       ByVal rut As String,
                                       ByVal idPerfilStr As String,
                                       ByVal usuarioNom As String,
                                       ByVal clave As String,
                                       ByVal estado As Boolean,
                                       ByVal permisosPorId As Dictionary(Of Integer, Boolean),
                                       ByVal sesion As String,
                                       ByRef cod_resp As Integer,
                                       ByRef resp As String)
        cod_resp = 0
        resp = String.Empty

        Dim rutLimpio As String = If(rut, String.Empty).Trim()
        Dim userLimpio As String = If(usuarioNom, String.Empty).Trim()
        Dim claveLimpia As String = If(clave, String.Empty).Trim()
        Dim idPerfil As Integer = 0

        If String.IsNullOrEmpty(rutLimpio) Then
            resp = "Debe ingresar el RUT del usuario."
            Exit Sub
        End If
        If String.IsNullOrEmpty(userLimpio) Then
            resp = "Debe ingresar el nombre de usuario."
            Exit Sub
        End If
        If userLimpio.Length > 15 Then
            resp = "El nombre de usuario no puede superar los 15 caracteres."
            Exit Sub
        End If
        If String.IsNullOrEmpty(claveLimpia) Then
            resp = "Debe ingresar una contraseña."
            Exit Sub
        End If
        If claveLimpia.Length > 10 Then
            resp = "La contraseña no puede superar los 10 caracteres."
            Exit Sub
        End If
        If Not Integer.TryParse(If(idPerfilStr, String.Empty).Trim(), idPerfil) OrElse idPerfil <= 0 Then
            resp = "Debe seleccionar un perfil de usuario válido."
            Exit Sub
        End If

        Dim activoChar As String = If(estado, "A", "D")
        Dim sesionLimpia As String = If(sesion, String.Empty).Trim()
        If String.IsNullOrEmpty(sesionLimpia) Then sesionLimpia = "SISTEMA"
        Dim conexion As New Conexion

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using tx As SqlTransaction = cnx.BeginTransaction()
                    Try
                        If esNuevo Then
                            Using cmdDupRut As New SqlCommand("SELECT COUNT(1) FROM usuario WHERE LTRIM(RTRIM(rut)) = @rut", cnx, tx)
                                cmdDupRut.Parameters.AddWithValue("@rut", rutLimpio)
                                If Convert.ToInt32(cmdDupRut.ExecuteScalar()) > 0 Then
                                    tx.Rollback()
                                    cod_resp = 0
                                    resp = "Ya existe un usuario registrado con el RUT " & rutLimpio & "."
                                    Exit Sub
                                End If
                            End Using

                            Using cmdDupUser As New SqlCommand("SELECT COUNT(1) FROM usuario WHERE UPPER(LTRIM(RTRIM(usuario))) = UPPER(@usuario)", cnx, tx)
                                cmdDupUser.Parameters.AddWithValue("@usuario", userLimpio)
                                If Convert.ToInt32(cmdDupUser.ExecuteScalar()) > 0 Then
                                    tx.Rollback()
                                    cod_resp = 0
                                    resp = "El nombre de usuario '" & userLimpio & "' ya existe en el sistema."
                                    Exit Sub
                                End If
                            End Using

                            Using cmdIns As New SqlCommand("INSERT INTO usuario (rut, idperfil, usuario, clave, estado) VALUES (@rut, @id_perfil, @usuario, @clave, @estado)", cnx, tx)
                                cmdIns.Parameters.AddWithValue("@rut", rutLimpio)
                                cmdIns.Parameters.AddWithValue("@id_perfil", idPerfil)
                                cmdIns.Parameters.AddWithValue("@usuario", userLimpio)
                                cmdIns.Parameters.AddWithValue("@clave", claveLimpia)
                                cmdIns.Parameters.AddWithValue("@estado", activoChar)
                                cmdIns.ExecuteNonQuery()
                            End Using

                            If permisosPorId IsNot Nothing Then
                                For Each kv In permisosPorId
                                    UpsertPermisoEnConexion(cnx, tx, rutLimpio, kv.Key, kv.Value)
                                Next
                            End If

                            RegistrarOperacionAuditoria(cnx, tx, sesionLimpia, "INSERCION", "usuario", rutLimpio)
                            tx.Commit()
                            cod_resp = 1
                            resp = "Usuario '" & userLimpio & "' ingresado correctamente."
                        Else
                            Dim rutDb As String = ResolverRutAlmacenado(cnx, tx, rutLimpio)
                            Dim existeUsuario As Boolean = False
                            Using cmdExist As New SqlCommand("SELECT COUNT(1) FROM usuario WHERE rut = @rutDb", cnx, tx)
                                cmdExist.Parameters.AddWithValue("@rutDb", rutDb)
                                existeUsuario = (Convert.ToInt32(cmdExist.ExecuteScalar()) > 0)
                            End Using
                            If Not existeUsuario Then
                                tx.Rollback()
                                cod_resp = 0
                                resp = "No se encontró el usuario con RUT " & rutLimpio & " para actualizar."
                                Exit Sub
                            End If

                            ' Proteger sesión actual contra autodesactivación o pérdida del perfil Administrador
                            If EsUsuarioActual(rutLimpio, userLimpio) Then
                                If Not estado Then
                                    tx.Rollback()
                                    cod_resp = 0
                                    resp = "No puede desactivar el usuario de la sesión actualmente iniciada."
                                    Exit Sub
                                End If
                                If Not EsIdPerfilAdministrador(cnx, tx, idPerfil) Then
                                    tx.Rollback()
                                    cod_resp = 0
                                    resp = "No puede quitar el perfil Administrador al usuario de la sesión activa."
                                    Exit Sub
                                End If
                            End If

                            Using cmdDupUser As New SqlCommand("SELECT COUNT(1) FROM usuario WHERE UPPER(LTRIM(RTRIM(usuario))) = UPPER(@usuario) AND LTRIM(RTRIM(rut)) <> @rut", cnx, tx)
                                cmdDupUser.Parameters.AddWithValue("@usuario", userLimpio)
                                cmdDupUser.Parameters.AddWithValue("@rut", rutLimpio)
                                If Convert.ToInt32(cmdDupUser.ExecuteScalar()) > 0 Then
                                    tx.Rollback()
                                    cod_resp = 0
                                    resp = "El nombre de usuario '" & userLimpio & "' ya pertenece a otro usuario."
                                    Exit Sub
                                End If
                            End Using

                            Using cmdUpd As New SqlCommand("UPDATE usuario SET usuario = @usuario, clave = @clave, idperfil = @id_perfil, estado = @estado WHERE rut = @rutDb", cnx, tx)
                                cmdUpd.Parameters.AddWithValue("@usuario", userLimpio)
                                cmdUpd.Parameters.AddWithValue("@clave", claveLimpia)
                                cmdUpd.Parameters.AddWithValue("@id_perfil", idPerfil)
                                cmdUpd.Parameters.AddWithValue("@estado", activoChar)
                                cmdUpd.Parameters.AddWithValue("@rutDb", rutDb)
                                cmdUpd.ExecuteNonQuery()
                            End Using

                            If permisosPorId IsNot Nothing Then
                                For Each kv In permisosPorId
                                    UpsertPermisoEnConexion(cnx, tx, rutDb, kv.Key, kv.Value)
                                Next
                            End If

                            RegistrarOperacionAuditoria(cnx, tx, sesionLimpia, "ACTUALIZACION", "usuario", rutLimpio)
                            tx.Commit()
                            cod_resp = 1
                            resp = "Usuario '" & userLimpio & "' modificado correctamente."
                        End If
                    Catch exTx As Exception
                        Try
                            tx.Rollback()
                        Catch
                        End Try
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            resp = ex.Message
            RegistroErrores.MostrarYRegistrar(ex, If(esNuevo, "Ingresar Usuario", "Actualizar Usuario"))
        End Try
    End Sub

    Public Sub DelUsuario(ByVal rut As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        cod_resp = 0
        resp = String.Empty
        Dim rutLimpio As String = If(rut, String.Empty).Trim()
        If String.IsNullOrEmpty(rutLimpio) Then
            resp = "Debe seleccionar un usuario válido antes de eliminar."
            Exit Sub
        End If

        Dim sesionLimpia As String = If(sesion, String.Empty).Trim()
        If String.IsNullOrEmpty(sesionLimpia) Then sesionLimpia = "SISTEMA"
        Dim conexion As New Conexion

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using tx As SqlTransaction = cnx.BeginTransaction()
                    Try
                        Dim nombreObjetivo As String = String.Empty
                        Dim rutDb As String = ResolverRutAlmacenado(cnx, tx, rutLimpio)
                        Using cmdInfo As New SqlCommand("SELECT TOP 1 LTRIM(RTRIM(usuario)) FROM usuario WHERE rut = @rutDb", cnx, tx)
                            cmdInfo.Parameters.AddWithValue("@rutDb", rutDb)
                            Dim obj = cmdInfo.ExecuteScalar()
                            If obj Is Nothing OrElse IsDBNull(obj) Then
                                tx.Rollback()
                                cod_resp = 0
                                resp = "El usuario seleccionado ya no existe en el sistema."
                                Exit Sub
                            End If
                            nombreObjetivo = obj.ToString().Trim()
                        End Using

                        If EsUsuarioActual(rutLimpio, nombreObjetivo) OrElse
                           String.Equals(nombreObjetivo, sesionLimpia, StringComparison.OrdinalIgnoreCase) Then
                            tx.Rollback()
                            cod_resp = 0
                            resp = "No puede eliminar el usuario con el que mantiene la sesión iniciada."
                            Exit Sub
                        End If

                        Using cmdDelPerm As New SqlCommand("DELETE FROM permisos_usuario WHERE LTRIM(RTRIM(rut)) = @rut", cnx, tx)
                            cmdDelPerm.Parameters.AddWithValue("@rut", rutLimpio)
                            cmdDelPerm.ExecuteNonQuery()
                        End Using

                        Using cmdDelUsr As New SqlCommand("DELETE FROM usuario WHERE rut = @rutDb", cnx, tx)
                            cmdDelUsr.Parameters.AddWithValue("@rutDb", rutDb)
                            cmdDelUsr.ExecuteNonQuery()
                        End Using

                        RegistrarOperacionAuditoria(cnx, tx, sesionLimpia, "ELIMINAR", "usuario", rutLimpio)
                        tx.Commit()
                        cod_resp = 1
                        resp = "Usuario eliminado correctamente."
                    Catch exTx As Exception
                        Try
                            tx.Rollback()
                        Catch
                        End Try
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            resp = ex.Message
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Usuario")
        End Try
    End Sub

    Public Sub CrgCmbPerfil(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_CMB_PERFILES", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    Using DS As New DataSet
                        DA.Fill(DS)
                        If DS.Tables.Count > 0 Then
                            combo.DisplayMember = "desc_perfil"
                            combo.ValueMember = "idperfil"
                            combo.DataSource = DS.Tables(0).Copy()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Perfiles de Usuario")
        End Try
    End Sub

    Public Sub ObtenerPerfiles(ByRef dtOut As DataTable)
        dtOut = New DataTable()
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Const sql As String =
                    "SELECT p.idperfil AS ID, p.desc_perfil AS Perfil, " &
                    "(SELECT COUNT(1) FROM usuario u WHERE u.idperfil = p.idperfil) AS Usuarios " &
                    "FROM perfiles_usuario p ORDER BY p.idperfil"
                Using DA As New SqlDataAdapter(sql, cnx)
                    DA.Fill(dtOut)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Perfiles de Usuario")
        End Try
    End Sub

    Public Sub IngPerfil(ByVal descPerfil As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        cod_resp = 0
        resp = String.Empty
        Dim nomLimpio As String = If(descPerfil, String.Empty).Trim()
        If String.IsNullOrEmpty(nomLimpio) Then
            resp = "Debe ingresar un nombre para el perfil."
            Exit Sub
        End If
        If nomLimpio.Length > 50 Then
            resp = "El nombre del perfil no puede superar los 50 caracteres."
            Exit Sub
        End If

        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using tx As SqlTransaction = cnx.BeginTransaction()
                    Using cmdDup As New SqlCommand("SELECT COUNT(1) FROM perfiles_usuario WHERE UPPER(LTRIM(RTRIM(desc_perfil))) = UPPER(@desc)", cnx, tx)
                        cmdDup.Parameters.AddWithValue("@desc", nomLimpio)
                        If Convert.ToInt32(cmdDup.ExecuteScalar()) > 0 Then
                            tx.Rollback()
                            resp = "Ya existe un perfil llamado '" & nomLimpio & "'."
                            Exit Sub
                        End If
                    End Using

                    Dim nuevoId As Integer
                    Using cmdNext As New SqlCommand("SELECT ISNULL(MAX(idperfil), 99) + 1 FROM perfiles_usuario", cnx, tx)
                        nuevoId = Convert.ToInt32(cmdNext.ExecuteScalar())
                    End Using

                    Using cmdIns As New SqlCommand("INSERT INTO perfiles_usuario (idperfil, desc_perfil) VALUES (@id, @desc)", cnx, tx)
                        cmdIns.Parameters.AddWithValue("@id", nuevoId)
                        cmdIns.Parameters.AddWithValue("@desc", nomLimpio)
                        cmdIns.ExecuteNonQuery()
                    End Using

                    RegistrarOperacionAuditoria(cnx, tx, If(String.IsNullOrWhiteSpace(sesion), "SISTEMA", sesion.Trim()), "INSERCION", "perfiles_usuario", nuevoId.ToString())
                    tx.Commit()
                    cod_resp = 1
                    resp = "Perfil '" & nomLimpio & "' creado correctamente."
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            resp = ex.Message
            RegistroErrores.MostrarYRegistrar(ex, "Crear Perfil de Usuario")
        End Try
    End Sub

    Public Sub UpdPerfil(ByVal idPerfil As Integer, ByVal descPerfil As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        cod_resp = 0
        resp = String.Empty
        Dim nomLimpio As String = If(descPerfil, String.Empty).Trim()
        If idPerfil <= 0 Then
            resp = "Seleccione un perfil válido."
            Exit Sub
        End If
        If String.IsNullOrEmpty(nomLimpio) Then
            resp = "Debe ingresar el nuevo nombre del perfil."
            Exit Sub
        End If
        If nomLimpio.Length > 50 Then
            resp = "El nombre del perfil no puede superar los 50 caracteres."
            Exit Sub
        End If

        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using tx As SqlTransaction = cnx.BeginTransaction()
                    Dim nombreActual As String = String.Empty
                    Using cmdCur As New SqlCommand("SELECT LTRIM(RTRIM(desc_perfil)) FROM perfiles_usuario WHERE idperfil = @id", cnx, tx)
                        cmdCur.Parameters.AddWithValue("@id", idPerfil)
                        Dim obj = cmdCur.ExecuteScalar()
                        If obj Is Nothing OrElse IsDBNull(obj) Then
                            tx.Rollback()
                            resp = "El perfil seleccionado ya no existe."
                            Exit Sub
                        End If
                        nombreActual = obj.ToString().Trim()
                    End Using

                    If EsPerfilAdministrador(nombreActual) AndAlso Not EsPerfilAdministrador(nomLimpio) Then
                        tx.Rollback()
                        resp = "El perfil reservado 'Administrador' no puede cambiar de nombre."
                        Exit Sub
                    End If

                    Using cmdDup As New SqlCommand("SELECT COUNT(1) FROM perfiles_usuario WHERE UPPER(LTRIM(RTRIM(desc_perfil))) = UPPER(@desc) AND idperfil <> @id", cnx, tx)
                        cmdDup.Parameters.AddWithValue("@desc", nomLimpio)
                        cmdDup.Parameters.AddWithValue("@id", idPerfil)
                        If Convert.ToInt32(cmdDup.ExecuteScalar()) > 0 Then
                            tx.Rollback()
                            resp = "Ya existe otro perfil llamado '" & nomLimpio & "'."
                            Exit Sub
                        End If
                    End Using

                    Using cmdUpd As New SqlCommand("UPDATE perfiles_usuario SET desc_perfil = @desc WHERE idperfil = @id", cnx, tx)
                        cmdUpd.Parameters.AddWithValue("@desc", nomLimpio)
                        cmdUpd.Parameters.AddWithValue("@id", idPerfil)
                        cmdUpd.ExecuteNonQuery()
                    End Using

                    RegistrarOperacionAuditoria(cnx, tx, If(String.IsNullOrWhiteSpace(sesion), "SISTEMA", sesion.Trim()), "ACTUALIZACION", "perfiles_usuario", idPerfil.ToString())
                    tx.Commit()
                    cod_resp = 1
                    resp = "Perfil actualizado correctamente."
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            resp = ex.Message
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Perfil de Usuario")
        End Try
    End Sub

    Public Sub DelPerfil(ByVal idPerfil As Integer, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        cod_resp = 0
        resp = String.Empty
        If idPerfil <= 0 Then
            resp = "Seleccione un perfil válido para eliminar."
            Exit Sub
        End If

        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using tx As SqlTransaction = cnx.BeginTransaction()
                    Dim nombreActual As String = String.Empty
                    Using cmdCur As New SqlCommand("SELECT LTRIM(RTRIM(desc_perfil)) FROM perfiles_usuario WHERE idperfil = @id", cnx, tx)
                        cmdCur.Parameters.AddWithValue("@id", idPerfil)
                        Dim obj = cmdCur.ExecuteScalar()
                        If obj Is Nothing OrElse IsDBNull(obj) Then
                            tx.Rollback()
                            resp = "El perfil seleccionado ya no existe."
                            Exit Sub
                        End If
                        nombreActual = obj.ToString().Trim()
                    End Using

                    If idPerfil = 100 OrElse EsPerfilAdministrador(nombreActual) Then
                        tx.Rollback()
                        resp = "No es posible eliminar el perfil reservado 'Administrador'."
                        Exit Sub
                    End If

                    Using cmdUso As New SqlCommand("SELECT COUNT(1) FROM usuario WHERE idperfil = @id", cnx, tx)
                        cmdUso.Parameters.AddWithValue("@id", idPerfil)
                        Dim cant As Integer = Convert.ToInt32(cmdUso.ExecuteScalar())
                        If cant > 0 Then
                            tx.Rollback()
                            resp = String.Format("No se puede eliminar el perfil '{0}' porque tiene {1} usuario(s) asignado(s).", nombreActual, cant)
                            Exit Sub
                        End If
                    End Using

                    Using cmdDel As New SqlCommand("DELETE FROM perfiles_usuario WHERE idperfil = @id", cnx, tx)
                        cmdDel.Parameters.AddWithValue("@id", idPerfil)
                        cmdDel.ExecuteNonQuery()
                    End Using

                    RegistrarOperacionAuditoria(cnx, tx, If(String.IsNullOrWhiteSpace(sesion), "SISTEMA", sesion.Trim()), "ELIMINAR", "perfiles_usuario", idPerfil.ToString())
                    tx.Commit()
                    cod_resp = 1
                    resp = "Perfil '" & nombreActual & "' eliminado correctamente."
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            resp = ex.Message
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Perfil de Usuario")
        End Try
    End Sub

    ''' <summary>
    ''' Devuelve una plantilla de permisos por idpermiso según el perfil seleccionado.
    ''' Administrador recibe los 21 permisos activos; el resto usa el consenso mayoritario de usuarios de ese perfil.
    ''' </summary>
    Public Function ObtenerPlantillaPermisosPerfil(ByVal idPerfil As Integer, ByVal descPerfil As String) As Dictionary(Of Integer, Boolean)
        Dim mapa As New Dictionary(Of Integer, Boolean)()
        Dim esAdmin As Boolean = (idPerfil = 100 OrElse EsPerfilAdministrador(descPerfil))
        Dim conexion As New Conexion

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                If esAdmin Then
                    Using cmd As New SqlCommand("SELECT idpermiso FROM permisos ORDER BY idpermiso", cnx)
                        Using dr As SqlDataReader = cmd.ExecuteReader()
                            While dr.Read()
                                mapa(Convert.ToInt32(dr(0))) = True
                            End While
                        End Using
                    End Using
                    Return mapa
                End If

                Const sqlConsenso As String =
                    "SELECT p.idpermiso, " &
                    "SUM(CASE WHEN pu.estado = 1 THEN 1 ELSE 0 END) AS si_cnt, " &
                    "COUNT(pu.rut) AS tot_cnt " &
                    "FROM permisos p " &
                    "LEFT JOIN usuario u ON u.idperfil = @idPerfil " &
                    "LEFT JOIN permisos_usuario pu ON pu.rut = u.rut AND pu.idpermiso = p.idpermiso " &
                    "GROUP BY p.idpermiso ORDER BY p.idpermiso"
                Using cmd As New SqlCommand(sqlConsenso, cnx)
                    cmd.Parameters.AddWithValue("@idPerfil", idPerfil)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            Dim idPerm As Integer = Convert.ToInt32(dr(0))
                            Dim siCnt As Integer = If(IsDBNull(dr(1)), 0, Convert.ToInt32(dr(1)))
                            Dim totCnt As Integer = If(IsDBNull(dr(2)), 0, Convert.ToInt32(dr(2)))
                            If totCnt > 0 Then
                                mapa(idPerm) = (siCnt * 2 >= totCnt)
                            Else
                                mapa(idPerm) = (idPerm = 1 OrElse idPerm = 5 OrElse idPerm = 6)
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.RegistrarError(ex, "Obtener Plantilla de Permisos por Perfil")
        End Try
        Return mapa
    End Function

    Public Sub CrgUsuarios(ByRef DS As DataSet)
        If DS Is Nothing Then DS = New DataSet()
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_USUARIOS", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.Fill(DS)
                End Using
            End Using
            If DS.Tables.Count > 0 Then
                For Each row As DataRow In DS.Tables(0).Rows
                    If row.Table.Columns.Contains("RUT") AndAlso Not IsDBNull(row("RUT")) Then
                        row("RUT") = row("RUT").ToString().Trim()
                    End If
                    If row.Table.Columns.Contains("ESTADO") AndAlso Not IsDBNull(row("ESTADO")) Then
                        row("ESTADO") = row("ESTADO").ToString().Trim()
                    End If
                Next
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Listado de Usuarios")
        End Try
    End Sub

    Public Sub CrgPermisosUsuarioLogin(ByVal usuario As String, ByVal clave As String, ByVal rut As String)
        Dim conexion As New Conexion
        Dim DS As New DataSet
        LimpiarSesion()
        Try
            Dim userLimpio As String = If(usuario, String.Empty).Trim()
            Dim rutLimpio As String = If(rut, String.Empty).Trim()

            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_PERMISOS_USUARIO", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.SelectCommand.Parameters.AddWithValue("@rut", rutLimpio)
                    DA.SelectCommand.Parameters.AddWithValue("@usuario", userLimpio)
                    DA.SelectCommand.Parameters.AddWithValue("@clave", If(clave, String.Empty))
                    DA.Fill(DS)
                End Using

                Dim info = ObtenerPerfilYRutUsuario(cnx, userLimpio, clave, rutLimpio)
                UsuarioAutenticado = True
                NombreUsuarioActual = If(String.Equals(userLimpio, "0", StringComparison.Ordinal), info.NombreUsuario, userLimpio)
                RutUsuarioActual = info.Rut
                PerfilActual = info.Perfil
                EsAdministrador = EsPerfilAdministrador(info.Perfil)
            End Using

            '------- Carga los permisos de usuario mapeados por idpermiso (sin instanciar formularios hijos en el login) ---
            Dim dtPerm As DataTable = If(DS.Tables.Count > 0, DS.Tables(0), Nothing)
            Dim mapa As Dictionary(Of Integer, Boolean) = ConstruirMapaPermisos(dtPerm)

            principal.OrdenesDeTrabajoToolStripMenuItem.Enabled = ObtenerPermisoPorId(mapa, 1, False)
            principal.MantPreventivaToolStripMenuItem.Enabled = ObtenerPermisoPorId(mapa, 2, False)
            principal.InformesToolStripMenuItem.Enabled = ObtenerPermisoPorId(mapa, 3, False)
            principal.MantenedorToolStripMenuItem.Enabled = ObtenerPermisoPorId(mapa, 4, False)

            PermisoGuardarOt = ObtenerPermisoPorId(mapa, 5, False) OrElse ObtenerPermisoPorId(mapa, 6, False)
            PermisoEliminarOt = ObtenerPermisoPorId(mapa, 7, False)
            PermisoAnularOt = ObtenerPermisoPorId(mapa, 8, False)

            PermisoIngMp = ObtenerPermisoPorId(mapa, 9, False)
            PermisoGuardarMp = ObtenerPermisoPorId(mapa, 10, False)
            PermisoEliminarCicloMp = ObtenerPermisoPorId(mapa, 11, False)
            PermisoEliminarMp = ObtenerPermisoPorId(mapa, 12, False)

            principal.NodosToolStripMenuItem.Enabled = ObtenerPermisoPorId(mapa, 13, False)
            principal.PersonalToolStripMenuItem.Enabled = ObtenerPermisoPorId(mapa, 14, False)
            principal.ItemsToolStripMenuItem.Enabled = ObtenerPermisoPorId(mapa, 15, False)
            principal.UsuariosToolStripMenuItem.Enabled = ObtenerPermisoPorId(mapa, 16, False)
            principal.TareasMaquinasToolStripMenuItem.Enabled = ObtenerPermisoPorId(mapa, 17, False)
            principal.InformeResumenOrdenDeTrabajoToolStripMenuItem.Enabled = ObtenerPermisoPorId(mapa, 18, False)
            principal.AuditoriaToolStripMenuItem.Enabled = ObtenerPermisoPorId(mapa, 19, False)

            PermisoCambiarTareasMp = ObtenerPermisoPorId(mapa, 20, False)
            PermisoCambiarIdModTareas = ObtenerPermisoPorId(mapa, 21, False)
            principal.ActualizarPermisosMenuAdministrador()
        Catch ex As Exception
            LimpiarSesion()
            principal.ActualizarPermisosMenuAdministrador()
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Permisos de Sesión")
        End Try
    End Sub

    Private Shared Function ObtenerPerfilYRutUsuario(ByVal cnx As SqlConnection, ByVal usuario As String, ByVal clave As String, ByVal rut As String) As (Perfil As String, Rut As String, NombreUsuario As String)
        If cnx Is Nothing OrElse cnx.State <> ConnectionState.Open Then Return (String.Empty, String.Empty, String.Empty)
        Try
            Using cmd As New SqlCommand()
                cmd.Connection = cnx
                If String.Equals(usuario, "0", StringComparison.Ordinal) Then
                    cmd.CommandText = "SELECT TOP 1 p.desc_perfil, LTRIM(RTRIM(u.rut)), LTRIM(RTRIM(u.usuario)) FROM usuario u INNER JOIN perfiles_usuario p ON u.idperfil = p.idperfil WHERE LTRIM(RTRIM(u.rut)) = @rut"
                    cmd.Parameters.AddWithValue("@rut", If(rut, String.Empty).Trim())
                Else
                    cmd.CommandText = "SELECT TOP 1 p.desc_perfil, LTRIM(RTRIM(u.rut)), LTRIM(RTRIM(u.usuario)) FROM usuario u INNER JOIN perfiles_usuario p ON u.idperfil = p.idperfil WHERE u.usuario = @usuario AND u.clave = @clave"
                    cmd.Parameters.AddWithValue("@usuario", If(usuario, String.Empty).Trim())
                    cmd.Parameters.AddWithValue("@clave", If(clave, String.Empty))
                End If
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        Dim perf As String = If(IsDBNull(dr(0)), String.Empty, dr(0).ToString().Trim())
                        Dim r As String = If(IsDBNull(dr(1)), String.Empty, dr(1).ToString().Trim())
                        Dim nom As String = If(IsDBNull(dr(2)), String.Empty, dr(2).ToString().Trim())
                        Return (perf, r, nom)
                    End If
                End Using
            End Using
        Catch
        End Try
        Return (String.Empty, String.Empty, String.Empty)
    End Function

    Public Function ObtenerMapaPermisosUsuario(ByVal rut As String) As Dictionary(Of Integer, Boolean)
        Dim DS As New DataSet
        CrgPermisosUsuario("0", String.Empty, If(rut, String.Empty).Trim(), DS)
        Dim dt As DataTable = If(DS.Tables.Count > 0, DS.Tables(0), Nothing)
        Return ConstruirMapaPermisos(dt)
    End Function

    Public Sub CrgPermisosPerfil(ByVal DST_PER As DataSet, ByVal id_perfil As String)
        If DST_PER Is Nothing Then Exit Sub
        Dim idPerf As Integer
        If Not Integer.TryParse(If(id_perfil, String.Empty).Trim(), idPerf) Then Exit Sub

        Try
            Dim mapa = ObtenerPlantillaPermisosPerfil(idPerf, String.Empty)
            Dim dt As New DataTable("permisos_perfil")
            dt.Columns.Add("idpermiso", GetType(Integer))
            dt.Columns.Add("estado", GetType(Boolean))
            For Each kv In mapa
                dt.Rows.Add(kv.Key, kv.Value)
            Next
            DST_PER.Tables.Clear()
            DST_PER.Tables.Add(dt)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Permisos de Perfil")
        End Try
    End Sub

    Public Sub CrgPermisosUsuario(ByVal usuario As String, ByVal clave As String, ByVal rut As String, ByRef DST_PER As DataSet)
        If DST_PER Is Nothing Then DST_PER = New DataSet()
        Dim conexion As New Conexion
        Dim rutLimpio As String = If(rut, String.Empty).Trim()

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Dim rutDb As String = ResolverRutAlmacenado(cnx, Nothing, rutLimpio)
                Using DA As New SqlDataAdapter("CRG_PERMISOS_USUARIO", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.SelectCommand.Parameters.AddWithValue("@rut", rutDb)
                    DA.SelectCommand.Parameters.AddWithValue("@usuario", If(usuario, String.Empty))
                    DA.SelectCommand.Parameters.AddWithValue("@clave", If(clave, String.Empty))
                    DA.Fill(DST_PER)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Permisos de Usuario")
        End Try
    End Sub

    Public Sub CrgPermisos(ByRef DST_PER As DataSet, ByRef grupo_permiso As String)
        If DST_PER Is Nothing Then DST_PER = New DataSet()
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_PERMISOS", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.SelectCommand.Parameters.AddWithValue("@grupo", If(grupo_permiso, String.Empty))
                    DA.Fill(DST_PER)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Grupo de Permisos")
        End Try
    End Sub

    Public Sub CrgPermisosFormUsuario(ByRef grilla_modulos As DataGridView, ByRef grilla_mod_ot As DataGridView, ByRef grilla_mod_mp As DataGridView, ByRef grilla_mantenedores As DataGridView)
        Dim DST_PER As New DataSet

        CrgPermisos(DST_PER, "modulos")
        If DST_PER.Tables.Count > 0 Then
            ConfigurarGrillaPermisosIndividual(grilla_modulos, DST_PER.Tables(0).Copy())
        End If

        DST_PER.Tables.Clear()
        CrgPermisos(DST_PER, "OT")
        If DST_PER.Tables.Count > 0 Then
            ConfigurarGrillaPermisosIndividual(grilla_mod_ot, DST_PER.Tables(0).Copy())
        End If

        DST_PER.Tables.Clear()
        CrgPermisos(DST_PER, "MP")
        If DST_PER.Tables.Count > 0 Then
            ConfigurarGrillaPermisosIndividual(grilla_mod_mp, DST_PER.Tables(0).Copy())
        End If

        DST_PER.Tables.Clear()
        CrgPermisos(DST_PER, "mantenedores")
        If DST_PER.Tables.Count > 0 Then
            ConfigurarGrillaPermisosIndividual(grilla_mantenedores, DST_PER.Tables(0).Copy())
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
                .ReadOnly = False
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
            .txtRutUsuario.Enabled = True

            CrgUsuarios(DST_USUARIO)
            If DST_USUARIO.Tables.Count > 0 Then
                .grillaUsuarios.DataSource = DST_USUARIO.Tables(0)
                .filtro.Table = DST_USUARIO.Tables(0)
                .ConfigurarEstiloGrillaUsuarios()
                Utilitarios.AjustarColumnasGrilla(.grillaUsuarios)
            End If
        End With
    End Sub

    Public Function ValidarIngUser(ByRef resp As String) As Boolean
        Dim valida As Boolean = True
        resp = String.Empty

        With FrmAdminUsuarios
            Dim rutLimpio As String = .txtRutUsuario.Text.Trim()
            If String.IsNullOrEmpty(rutLimpio) Then
                valida = False
                resp &= "Debe ingresar el RUT del usuario." & Environment.NewLine
            ElseIf Not rutLimpio.All(Function(c) Char.IsDigit(c)) Then
                valida = False
                resp &= "El RUT del usuario debe contener solo dígitos (sin puntos ni dígito verificador)." & Environment.NewLine
            End If

            If String.IsNullOrWhiteSpace(.txtNomUsuario.Text) Then
                valida = False
                resp &= "Debe ingresar el nombre de usuario." & Environment.NewLine
            ElseIf .txtNomUsuario.Text.Trim().Length > 15 Then
                valida = False
                resp &= "El nombre de usuario no puede exceder los 15 caracteres." & Environment.NewLine
            End If

            If String.IsNullOrWhiteSpace(.txtClave.Text) Then
                valida = False
                resp &= "Debe ingresar una contraseña." & Environment.NewLine
            ElseIf .txtClave.Text.Trim().Length > 10 Then
                valida = False
                resp &= "La contraseña no puede exceder los 10 caracteres." & Environment.NewLine
            End If

            If .cmbPerfil1.SelectedIndex < 0 OrElse .cmbPerfil1.SelectedValue Is Nothing Then
                valida = False
                resp &= "Debe seleccionar un perfil de usuario." & Environment.NewLine
            End If
        End With

        Return valida
    End Function

    Public Function ValidarRut(ByRef rut As String, ByRef digito As String) As Boolean
        Dim rutLimpio As String = If(rut, String.Empty).Trim()
        Dim digLimpio As String = If(digito, String.Empty).Trim()
        If String.IsNullOrEmpty(rutLimpio) OrElse String.IsNullOrEmpty(digLimpio) Then Return False

        Dim suma As Integer = 0
        Dim contador As Integer = 2

        For i As Integer = rutLimpio.Length - 1 To 0 Step -1
            If contador > 7 Then contador = 2
            Dim num As Integer
            If Not Integer.TryParse(rutLimpio(i).ToString(), num) Then Return False
            suma += num * contador
            contador += 1
        Next

        Dim dv As Integer = 11 - (suma Mod 11)
        Dim digVer As String = dv.ToString()
        If digVer = "10" Then digVer = "K"
        If digVer = "11" Then digVer = "0"

        Return String.Equals(digVer, digLimpio.ToUpperInvariant(), StringComparison.OrdinalIgnoreCase)
    End Function

    Private Shared Function ResolverRutAlmacenado(ByVal cnx As SqlConnection, ByVal tx As SqlTransaction, ByVal rutLimpio As String) As String
        If String.IsNullOrWhiteSpace(rutLimpio) Then Return String.Empty
        Using cmd As New SqlCommand("SELECT TOP 1 rut FROM usuario WHERE LTRIM(RTRIM(rut)) = @rut", cnx, tx)
            cmd.Parameters.AddWithValue("@rut", rutLimpio.Trim())
            Dim obj = cmd.ExecuteScalar()
            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                Return obj.ToString()
            End If
        End Using
        Return rutLimpio.Trim()
    End Function

    Private Shared Sub UpsertPermisoEnConexion(ByVal cnx As SqlConnection, ByVal tx As SqlTransaction, ByVal rutDb As String, ByVal idPermiso As Integer, ByVal estado As Boolean)
        Using cmd As New SqlCommand("UPD_PERMISOS_USUARIO", cnx, tx)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@rut", rutDb)
            cmd.Parameters.AddWithValue("@id_permiso", idPermiso)
            cmd.Parameters.AddWithValue("@estado", estado)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Shared Sub RegistrarOperacionAuditoria(ByVal cnx As SqlConnection, ByVal tx As SqlTransaction, ByVal sesion As String, ByVal operacion As String, ByVal tabla As String, ByVal regAfectado As String)
        Using cmdAudit As New SqlCommand("ING_OPERACION", cnx, tx)
            cmdAudit.CommandType = CommandType.StoredProcedure
            cmdAudit.Parameters.AddWithValue("@sesion", If(sesion, "SISTEMA").Trim().Substring(0, Math.Min(15, If(sesion, "SISTEMA").Trim().Length)))
            cmdAudit.Parameters.AddWithValue("@operacion", operacion)
            cmdAudit.Parameters.AddWithValue("@tabla", tabla)
            cmdAudit.Parameters.AddWithValue("@reg_afectado", If(regAfectado, String.Empty))
            cmdAudit.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
            cmdAudit.ExecuteNonQuery()
        End Using
    End Sub

    Private Shared Function EsUsuarioActual(ByVal rutObjetivo As String, ByVal usuarioObjetivo As String) As Boolean
        If Not String.IsNullOrWhiteSpace(RutUsuarioActual) AndAlso
           String.Equals(RutUsuarioActual.Trim(), If(rutObjetivo, String.Empty).Trim(), StringComparison.OrdinalIgnoreCase) Then
            Return True
        End If
        If Not String.IsNullOrWhiteSpace(NombreUsuarioActual) AndAlso
           String.Equals(NombreUsuarioActual.Trim(), If(usuarioObjetivo, String.Empty).Trim(), StringComparison.OrdinalIgnoreCase) Then
            Return True
        End If
        Return False
    End Function

    Private Shared Function EsIdPerfilAdministrador(ByVal cnx As SqlConnection, ByVal tx As SqlTransaction, ByVal idPerfil As Integer) As Boolean
        Using cmd As New SqlCommand("SELECT TOP 1 desc_perfil FROM perfiles_usuario WHERE idperfil = @id", cnx, tx)
            cmd.Parameters.AddWithValue("@id", idPerfil)
            Dim obj = cmd.ExecuteScalar()
            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                Return EsPerfilAdministrador(obj.ToString())
            End If
        End Using
        Return False
    End Function

    Private Shared Function ConstruirMapaPermisos(ByVal dt As DataTable) As Dictionary(Of Integer, Boolean)
        Dim mapa As New Dictionary(Of Integer, Boolean)()
        If dt Is Nothing Then Return mapa

        For idx As Integer = 0 To dt.Rows.Count - 1
            Dim row As DataRow = dt.Rows(idx)
            Dim idPerm As Integer = idx + 1
            If dt.Columns.Count >= 2 Then
                If Not IsDBNull(row(0)) Then
                    Integer.TryParse(row(0).ToString().Trim(), idPerm)
                End If
                mapa(idPerm) = ConvertirABooleanSeguro(row(1))
            End If
        Next
        Return mapa
    End Function

    Private Shared Function ObtenerPermisoPorId(ByVal mapa As Dictionary(Of Integer, Boolean), ByVal idPermiso As Integer, Optional ByVal def As Boolean = False) As Boolean
        If mapa IsNot Nothing Then
            Dim val As Boolean = False
            If mapa.TryGetValue(idPermiso, val) Then
                Return val
            End If
        End If
        Return def
    End Function

    Private Shared Function ConvertirABooleanSeguro(ByVal valor As Object) As Boolean
        If valor Is Nothing OrElse IsDBNull(valor) Then Return False
        Dim valStr As String = valor.ToString().Trim()
        Dim boolVal As Boolean = False
        If Boolean.TryParse(valStr, boolVal) Then Return boolVal
        Return (valStr = "1" OrElse valStr.Equals("true", StringComparison.OrdinalIgnoreCase))
    End Function
End Class
