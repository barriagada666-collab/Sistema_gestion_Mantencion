Imports System.Data.SqlClient
Public Class Usuario

    Public Sub buscarUsuario(ByVal usuario As String, ByVal pass As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Dim DR As SqlDataReader
            Dim com As New SqlCommand("buscarUsuario", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_usuario As SqlParameter = com.Parameters.AddWithValue("@user", usuario)
            Dim p_pass As SqlParameter = com.Parameters.AddWithValue("@pass", pass)

            DR = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If

        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
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
            Dim DR As SqlDataReader
            Dim com As New SqlCommand("ING_USUARIO", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
            Dim p_perfil As SqlParameter = com.Parameters.AddWithValue("@id_perfil", CInt(id_perfil))
            Dim p_usuario As SqlParameter = com.Parameters.AddWithValue("@usuario", usuario)
            Dim p_clave As SqlParameter = com.Parameters.AddWithValue("@clave", clave)
            Dim p_estado As SqlParameter = com.Parameters.AddWithValue("@estado", activo)
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
            Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

            DR = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If

        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ingPermisoUsuario(ByVal rut As String, ByVal id_permiso As String, ByVal estado As Boolean)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Dim activo As Char = ""

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("ING_PERMISOS_USUARIO", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_permiso As SqlParameter = com.Parameters.AddWithValue("@id_permiso", CInt(id_permiso))
            Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
            Dim p_estado As SqlParameter = com.Parameters.AddWithValue("@estado", estado)

            Dim DR As SqlDataReader = com.ExecuteReader
            conexion.Desconectar(cnx)
            com.Dispose()

        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
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
            Dim DR As SqlDataReader
            Dim com As New SqlCommand("UPD_USUARIO", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
            Dim p_perfil As SqlParameter = com.Parameters.AddWithValue("@perfil", CInt(id_perfil))
            Dim p_usuario As SqlParameter = com.Parameters.AddWithValue("@user", usuario)
            Dim p_clave As SqlParameter = com.Parameters.AddWithValue("@clave", clave)
            Dim p_estado As SqlParameter = com.Parameters.AddWithValue("@estado", activo)
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
            Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

            DR = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If

        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UpdPermisosUsuario(ByVal rut As String, ByVal id_permiso As String, ByVal estado As Boolean)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Dim activo As Char = ""

        Try
            conexion.Conectar(cnx)
            Dim com As New SqlCommand("UPD_PERMISOS_USUARIO", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_id_permiso As SqlParameter = com.Parameters.AddWithValue("@id_permiso", CInt(id_permiso))
            Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
            Dim p_estado As SqlParameter = com.Parameters.AddWithValue("@estado", estado)

            Dim DR As SqlDataReader = com.ExecuteReader
            conexion.Desconectar(cnx)
            com.Dispose()

        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub DelUsuario(ByVal rut As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Dim activo As Char = ""

        Try
            conexion.Conectar(cnx)
            Dim DR As SqlDataReader
            Dim com As New SqlCommand("DEL_USUARIO", cnx)
            com.CommandType = CommandType.StoredProcedure

            Dim p_rut As SqlParameter = com.Parameters.AddWithValue("@rut", rut)
            Dim p_sesion As SqlParameter = com.Parameters.AddWithValue("@sesion", sesion)
            Dim p_nombre_pc As SqlParameter = com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

            DR = com.ExecuteReader
            If DR.Read() Then
                cod_resp = DR(0)
                resp = DR(1)
                conexion.Desconectar(cnx)
                com.Dispose()
            End If

        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub CrgCmbPerfil(ByRef combo As ComboBox)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_CMB_PERFILES", cnx)
            Dim DS As New DataSet

            DA.Fill(DS)
            combo.DataSource = DS.Tables(0)
            combo.DisplayMember = "desc_perfil"
            combo.ValueMember = "idperfil"
            conexion.Desconectar(cnx)
            DA.Dispose()
            DS.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub CrgUsuarios(ByRef DS As DataSet)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_USUARIOS", cnx)
            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub CrgPermisosUsuarioLogin(ByVal usuario As String, ByVal clave As String, ByVal rut As String)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Dim DS As New DataSet
        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_PERMISOS_USUARIO", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_rut As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@rut", rut)
            Dim p_usuario As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@usuario", usuario)
            Dim p_clave As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@clave", clave)

            DA.Fill(DS)
            conexion.Desconectar(cnx)
            DA.Dispose()

            '------- Carga los permisos se usuario ---------------------------------
            principal.OrdenesDeTrabajoToolStripMenuItem.Enabled = DS.Tables(0).Rows(0).Item(1).ToString '-- modulo ordenes de trabajo
            principal.MantPreventivaToolStripMenuItem.Enabled = DS.Tables(0).Rows(1).Item(1).ToString   '-- modulo mantenciones preventivas
            principal.InformesToolStripMenuItem.Enabled = DS.Tables(0).Rows(2).Item(1).ToString         '-- modulo informes
            principal.MantenedorToolStripMenuItem.Enabled = DS.Tables(0).Rows(3).Item(1).ToString       '-- modulo mantenedores
            frm_OT.btn_guardar.Enabled = DS.Tables(0).Rows(4).Item(1).ToString                          '-- guardar orden de trabajo
            frm_OT.btn_guardar.Enabled = DS.Tables(0).Rows(5).Item(1).ToString                          '-- actualizar orden de trabajo
            frm_OT.btn_eliminar.Enabled = DS.Tables(0).Rows(6).Item(1).ToString                         '-- eliminar orden de trabajo     
            'frm_OT.btnAnularOt.Enabled = DS.Tables(0).Rows(7).Item(1).ToString                          '-- anular orden de trabajo
            FrmMp.btnIngMp.Enabled = DS.Tables(0).Rows(8).Item(1).ToString                              '-- ingresar mantencion preventiva
            FrmMp.btnGuardarMp.Enabled = DS.Tables(0).Rows(9).Item(1).ToString                          '-- actualizar mp 
            FrmMp.btnEliminarCiclo.Enabled = DS.Tables(0).Rows(10).Item(1).ToString                     '-- eliminar ciclo mp
            FrmMp.btnEliminarMp.Enabled = DS.Tables(0).Rows(11).Item(1).ToString                        '-- eliminar mp
            principal.NodosToolStripMenuItem.Enabled = DS.Tables(0).Rows(12).Item(1).ToString           '-- modulo nodos
            principal.PersonalToolStripMenuItem.Enabled = DS.Tables(0).Rows(13).Item(1).ToString        '-- modulo personal
            principal.ItemsToolStripMenuItem.Enabled = DS.Tables(0).Rows(14).Item(1).ToString           '-- modulo items / secciones 
            principal.UsuariosToolStripMenuItem.Enabled = DS.Tables(0).Rows(15).Item(1).ToString        '-- modulo gestion de usuario
            principal.TareasMaquinasToolStripMenuItem.Enabled = DS.Tables(0).Rows(16).Item(1).ToString  '-- modulo Tareas Maquinas / Nodos 
            principal.InformeResumenOrdenDeTrabajoToolStripMenuItem.Enabled = DS.Tables(0).Rows(17).Item(1).ToString  '-- modulo informe resumen OT
            principal.AuditoriaToolStripMenuItem.Enabled = DS.Tables(0).Rows(18).Item(1).ToString       '-- modulo auditoria
            FrmMp.btnCambiarTareas.Visible = DS.Tables(0).Rows(19).Item(1).ToString                     '-- Boton Cambiar ID Modulo Gestion MP
            FrmAdminTareasNodo.btnCambiarIDMod.Visible = DS.Tables(0).Rows(20).Item(1).ToString         '-- Boton Cambiar ID Modulo Gestion Tareas Nodo
        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub CrgPermisosPerfil(ByVal DST_PER As DataSet, ByVal id_perfil As String)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_PERMISOS_PERFIL", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_id_perfil As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@id_perfil", CInt(id_perfil))

            DA.Fill(DST_PER)
            conexion.Desconectar(cnx)
            DA.Dispose()

        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub CrgPermisosUsuario(ByVal usuario As String, ByVal clave As String, ByVal rut As String, ByRef DST_PER As DataSet)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_PERMISOS_USUARIO", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_rut As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@rut", rut)
            Dim p_usuario As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@usuario", usuario)
            Dim p_clave As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@clave", clave)

            DA.Fill(DST_PER)
            conexion.Desconectar(cnx)
            DA.Dispose()

        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub CrgPermisos(ByRef DST_PER As DataSet, ByRef grupo_permiso As String)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection

        Try
            conexion.Conectar(cnx)
            Dim DA As New SqlDataAdapter("CRG_PERMISOS", cnx)
            DA.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p_rut As SqlParameter = DA.SelectCommand.Parameters.AddWithValue("@grupo", grupo_permiso)


            DA.Fill(DST_PER)
            conexion.Desconectar(cnx)
            DA.Dispose()

        Catch ex As Exception
            conexion.Desconectar(cnx)
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub CrgPermisosFormUsuario(ByRef grilla_modulos As DataGridView, ByRef grilla_mod_ot As DataGridView, ByRef grilla_mod_mp As DataGridView, ByRef grilla_mantenedores As DataGridView)
        Dim DST_PER As New DataSet

        CrgPermisos(DST_PER, "modulos")
        grilla_modulos.DataSource = DST_PER.Tables(0)
        grilla_modulos.Columns(0).Visible = False
        grilla_modulos.Columns(1).Width = 180
        grilla_modulos.Columns(1).ReadOnly = True
        grilla_modulos.Columns(2).Width = 50

        DST_PER.Tables.Clear()
        CrgPermisos(DST_PER, "OT")
        grilla_mod_ot.DataSource = DST_PER.Tables(0)
        grilla_mod_ot.Columns(0).Visible = False
        grilla_mod_ot.Columns(1).Width = 180
        grilla_mod_ot.Columns(1).ReadOnly = True
        grilla_mod_ot.Columns(2).Width = 50

        DST_PER.Tables.Clear()
        CrgPermisos(DST_PER, "MP")
        grilla_mod_mp.DataSource = DST_PER.Tables(0)
        grilla_mod_mp.Columns(0).Visible = False
        grilla_mod_mp.Columns(1).Width = 180
        grilla_mod_mp.Columns(1).ReadOnly = True
        grilla_mod_mp.Columns(2).Width = 50

        DST_PER.Tables.Clear()
        CrgPermisos(DST_PER, "mantenedores")
        grilla_mantenedores.DataSource = DST_PER.Tables(0)
        grilla_mantenedores.Columns(0).Visible = False
        grilla_mantenedores.Columns(1).Width = 180
        grilla_mantenedores.Columns(1).ReadOnly = True
        grilla_mantenedores.Columns(2).Width = 50
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
            .grillaUsuarios.DataSource = DST_USUARIO.Tables(0)
            .filtro.Table = DST_USUARIO.Tables(0)
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
End Class
