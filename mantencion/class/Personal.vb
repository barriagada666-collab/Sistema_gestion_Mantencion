Imports System.Data.SqlClient

Public Class Personal

    Private Shared Function ParsearEnteroSeguro(ByVal valor As String, Optional ByVal valorDefecto As Integer = 0) As Integer
        Dim res As Integer
        If Integer.TryParse(If(valor, String.Empty).Trim(), res) Then
            Return res
        End If
        Return valorDefecto
    End Function

    Private Shared Sub RegistrarAuditoriaTx(ByVal cnx As SqlConnection, ByVal tx As SqlTransaction, ByVal sesion As String, ByVal operacion As String, ByVal regAfectado As String)
        Dim sesLimpia As String = If(String.IsNullOrWhiteSpace(sesion), "SISTEMA", sesion.Trim())
        Dim regLimpio As String = If(regAfectado, String.Empty).Trim()
        If regLimpio.Length > 50 Then regLimpio = regLimpio.Substring(0, 50)
        Using cmdAud As New SqlCommand("ING_OPERACION", cnx, tx)
            cmdAud.CommandType = CommandType.StoredProcedure
            cmdAud.Parameters.AddWithValue("@sesion", sesLimpia.Substring(0, Math.Min(15, sesLimpia.Length)))
            cmdAud.Parameters.AddWithValue("@operacion", operacion)
            cmdAud.Parameters.AddWithValue("@tabla", "personal")
            cmdAud.Parameters.AddWithValue("@reg_afectado", regLimpio)
            cmdAud.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)
            cmdAud.ExecuteNonQuery()
        End Using
    End Sub

    Private Shared Function ContarDependenciasTx(ByVal cnx As SqlConnection, ByVal tx As SqlTransaction, ByVal rutLimpio As String) As Integer
        Using cmdRef As New SqlCommand(
            "SELECT " &
            "(SELECT COUNT(1) FROM personal_ot WHERE LTRIM(RTRIM(rut)) = @rut) + " &
            "(SELECT COUNT(1) FROM personal_ot_historico WHERE LTRIM(RTRIM(rut)) = @rut) + " &
            "(SELECT COUNT(1) FROM ciclo_mp_personal WHERE LTRIM(RTRIM(rut)) = @rut) + " &
            "(SELECT COUNT(1) FROM usuario WHERE LTRIM(RTRIM(rut)) = @rut)", cnx, tx)
            cmdRef.Parameters.AddWithValue("@rut", rutLimpio)
            Return Convert.ToInt32(cmdRef.ExecuteScalar())
        End Using
    End Function

    ''' <summary>
    ''' Carga el padrón completo de personal (activos e inactivos) con sus relaciones de Planta, Sección, Cargo y cuenta de usuario.
    ''' </summary>
    Public Function CrgPersonalCompleto() As DataTable
        Dim dt As New DataTable("personal")
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Const sql As String =
                    "SELECT " &
                    "  LTRIM(RTRIM(p.rut)) AS [RUT], " &
                    "  UPPER(LTRIM(RTRIM(ISNULL(p.dv, '')))) AS [DV], " &
                    "  ISNULL(p.cod_interno, 0) AS [Código], " &
                    "  LTRIM(RTRIM(ISNULL(p.nombres, ''))) AS [Nombres], " &
                    "  LTRIM(RTRIM(ISNULL(p.ap_paterno, ''))) AS [Ap. Paterno], " &
                    "  LTRIM(RTRIM(ISNULL(p.ap_materno, ''))) AS [Ap. Materno], " &
                    "  LTRIM(RTRIM(ISNULL(p.alias, ''))) AS [Alias], " &
                    "  LTRIM(RTRIM(ISNULL(cen.desc_centro, ''))) AS [Planta], " &
                    "  LTRIM(RTRIM(ISNULL(s.desc_seccion, ''))) AS [Sección], " &
                    "  LTRIM(RTRIM(ISNULL(c.desc_cargo, ''))) AS [Cargo], " &
                    "  CASE WHEN p.activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS [Estado], " &
                    "  CASE WHEN EXISTS (SELECT 1 FROM usuario u WHERE LTRIM(RTRIM(u.rut)) = LTRIM(RTRIM(p.rut))) THEN 'Sí' ELSE 'No' END AS [Usuario], " &
                    "  ISNULL(p.fono, 0) AS [Fono], " &
                    "  ISNULL(p.celular, 0) AS [Celular], " &
                    "  LTRIM(RTRIM(ISNULL(p.email, ''))) AS [Correo], " &
                    "  p.fecha_ingreso AS [Fecha Ingreso], " &
                    "  p.fecha_nacimiento AS [fecha_nacimiento], " &
                    "  LTRIM(RTRIM(ISNULL(p.direccion, ''))) AS [direccion], " &
                    "  p.activo AS [activo], " &
                    "  p.idcentro AS [idcentro], " &
                    "  p.idseccion AS [idseccion], " &
                    "  p.idcargo AS [idcargo] " &
                    "FROM personal p " &
                    "LEFT JOIN centro_trabajo cen ON cen.idcentro = p.idcentro " &
                    "LEFT JOIN seccion s ON s.idseccion = p.idseccion " &
                    "LEFT JOIN cargos c ON c.idcargo = p.idcargo " &
                    "ORDER BY p.activo DESC, p.ap_paterno ASC, p.ap_materno ASC, p.nombres ASC"
                Using DA As New SqlDataAdapter(sql, cnx)
                    DA.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Listado Completo de Personal")
        End Try
        Return dt
    End Function

    Public Sub IngPersonal(ByVal rut As String, ByRef dv As String, ByVal cod_int As String, ByVal nombres As String, ByVal ap_paterno As String, ByVal ap_materno As String, ByVal alias_personal As String, ByVal fecha_nac As DateTime, ByVal fono As String, ByVal email As String, ByVal planta As String, ByVal seccion As String, ByVal cargo As String, ByVal sesion As String, ByVal activo As Boolean, ByVal direccion As String, ByVal fecha_ingreso As DateTime, ByVal celular As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty

        Dim rutLimpio As String = If(rut, String.Empty).Trim()
        Dim dvLimpio As String = If(dv, String.Empty).Trim().ToUpperInvariant()
        If String.IsNullOrEmpty(rutLimpio) OrElse String.IsNullOrEmpty(dvLimpio) Then
            resp = "Debe ingresar RUT y dígito verificador válidos."
            Exit Sub
        End If

        Dim codIntNum As Integer = ParsearEnteroSeguro(cod_int, 0)
        Dim fonoNum As Integer = 0
        If Not String.IsNullOrWhiteSpace(fono) AndAlso Not Integer.TryParse(fono.Trim(), fonoNum) Then
            resp = "El teléfono ingresado excede el límite numérico permitido (máx. 9 dígitos)."
            Exit Sub
        End If
        Dim celNum As Integer = 0
        If Not String.IsNullOrWhiteSpace(celular) AndAlso Not Integer.TryParse(celular.Trim(), celNum) Then
            resp = "El celular ingresado excede el límite numérico permitido (máx. 9 dígitos)."
            Exit Sub
        End If

        Dim idPlanta As Integer = ParsearEnteroSeguro(planta, 0)
        Dim idSeccion As Integer = ParsearEnteroSeguro(seccion, 0)
        Dim idCargo As Integer = ParsearEnteroSeguro(cargo, 0)
        If idPlanta <= 0 OrElse idSeccion <= 0 OrElse idCargo <= 0 Then
            resp = "Debe seleccionar Planta, Sección y Cargo válidos."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using com As New SqlCommand("ING_PERSONAL", cnx)
                    com.CommandType = CommandType.StoredProcedure

                    com.Parameters.AddWithValue("@rut", rutLimpio)
                    com.Parameters.AddWithValue("@dv", dvLimpio)
                    com.Parameters.AddWithValue("@cod_interno", codIntNum)
                    com.Parameters.AddWithValue("@nombres", If(nombres, String.Empty).Trim())
                    com.Parameters.AddWithValue("@ap_paterno", If(ap_paterno, String.Empty).Trim())
                    com.Parameters.AddWithValue("@ap_materno", If(ap_materno, String.Empty).Trim())
                    Utilitarios.AgregarParametroFecha(com, "@fecha_nacimiento", Utilitarios.SafeSqlDateStart(fecha_nac))
                    com.Parameters.AddWithValue("@fono", fonoNum)
                    com.Parameters.AddWithValue("@email", If(email, String.Empty).Trim())
                    com.Parameters.AddWithValue("@idcentro", idPlanta)
                    com.Parameters.AddWithValue("@idseccion", idSeccion)
                    com.Parameters.AddWithValue("@idcargo", idCargo)
                    com.Parameters.AddWithValue("@alias", If(alias_personal, String.Empty).Trim())
                    com.Parameters.AddWithValue("@sesion", If(sesion, String.Empty).Trim())
                    com.Parameters.AddWithValue("@activo", activo)
                    com.Parameters.AddWithValue("@direccion", If(direccion, String.Empty).Trim())
                    Utilitarios.AgregarParametroFecha(com, "@fecha_ingreso", Utilitarios.SafeSqlDateStart(fecha_ingreso))
                    com.Parameters.AddWithValue("@celular", celNum)
                    com.Parameters.AddWithValue("@nombre_pc", My.Computer.Name)

                    Using DR As SqlDataReader = com.ExecuteReader()
                        If DR.Read() Then
                            cod_resp = If(IsDBNull(DR(0)), -1, Convert.ToInt32(DR(0)))
                            resp = If(IsDBNull(DR(1)), String.Empty, DR(1).ToString())
                            If cod_resp = 1 Then OT.InvalidarCachePersonal()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Ingresar Personal")
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza los datos de un trabajador de forma transaccional y segura (compatible con DV 'K' y auditoría ING_OPERACION).
    ''' </summary>
    Public Sub UpdPersonal(ByVal rut As String, ByRef dv As String, ByVal cod_int As String, ByVal nombres As String, ByVal ap_paterno As String, ByVal ap_materno As String, ByVal alias_personal As String, ByVal fecha_nac As Date, ByVal fono As String, ByVal email As String, ByVal planta As String, ByVal seccion As String, ByVal cargo As String, ByVal sesion As String, ByVal activo As Boolean, ByVal direccion As String, ByVal fecha_ingreso As DateTime, ByVal celular As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty

        Dim rutLimpio As String = If(rut, String.Empty).Trim()
        Dim dvLimpio As String = If(dv, String.Empty).Trim().ToUpperInvariant()
        If String.IsNullOrEmpty(rutLimpio) OrElse String.IsNullOrEmpty(dvLimpio) Then
            resp = "Debe seleccionar un trabajador válido antes de actualizar."
            Exit Sub
        End If

        Dim codIntNum As Integer = ParsearEnteroSeguro(cod_int, 0)
        Dim fonoNum As Integer = 0
        If Not String.IsNullOrWhiteSpace(fono) AndAlso Not Integer.TryParse(fono.Trim(), fonoNum) Then
            resp = "El teléfono ingresado excede el límite numérico permitido (máx. 9 dígitos)."
            Exit Sub
        End If
        Dim celNum As Integer = 0
        If Not String.IsNullOrWhiteSpace(celular) AndAlso Not Integer.TryParse(celular.Trim(), celNum) Then
            resp = "El celular ingresado excede el límite numérico permitido (máx. 9 dígitos)."
            Exit Sub
        End If

        Dim idPlanta As Integer = ParsearEnteroSeguro(planta, 0)
        Dim idSeccion As Integer = ParsearEnteroSeguro(seccion, 0)
        Dim idCargo As Integer = ParsearEnteroSeguro(cargo, 0)
        If idPlanta <= 0 OrElse idSeccion <= 0 OrElse idCargo <= 0 Then
            resp = "Debe seleccionar Planta, Sección y Cargo válidos."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using tx As SqlTransaction = cnx.BeginTransaction()
                    Const sqlUpd As String =
                        "UPDATE personal SET " &
                        "  idcargo = @idcargo, idseccion = @idseccion, idcentro = @idcentro, " &
                        "  dv = @dv, cod_interno = @cod_interno, nombres = @nombres, " &
                        "  ap_paterno = @ap_paterno, ap_materno = @ap_materno, " &
                        "  fecha_nacimiento = @fecha_nacimiento, fono = @fono, email = @email, " &
                        "  alias = @alias, activo = @activo, direccion = @direccion, " &
                        "  fecha_ingreso = @fecha_ingreso, celular = @celular " &
                        "WHERE LTRIM(RTRIM(rut)) = @rut"

                    Dim afectados As Integer
                    Using com As New SqlCommand(sqlUpd, cnx, tx)
                        com.Parameters.AddWithValue("@rut", rutLimpio)
                        com.Parameters.AddWithValue("@dv", dvLimpio)
                        com.Parameters.AddWithValue("@cod_interno", codIntNum)
                        com.Parameters.AddWithValue("@nombres", If(nombres, String.Empty).Trim())
                        com.Parameters.AddWithValue("@ap_paterno", If(ap_paterno, String.Empty).Trim())
                        com.Parameters.AddWithValue("@ap_materno", If(ap_materno, String.Empty).Trim())
                        Utilitarios.AgregarParametroFecha(com, "@fecha_nacimiento", Utilitarios.SafeSqlDateStart(fecha_nac))
                        com.Parameters.AddWithValue("@fono", fonoNum)
                        com.Parameters.AddWithValue("@email", If(email, String.Empty).Trim())
                        com.Parameters.AddWithValue("@idcentro", idPlanta)
                        com.Parameters.AddWithValue("@idseccion", idSeccion)
                        com.Parameters.AddWithValue("@idcargo", idCargo)
                        com.Parameters.AddWithValue("@alias", If(alias_personal, String.Empty).Trim())
                        com.Parameters.AddWithValue("@activo", activo)
                        com.Parameters.AddWithValue("@direccion", If(direccion, String.Empty).Trim())
                        Utilitarios.AgregarParametroFecha(com, "@fecha_ingreso", Utilitarios.SafeSqlDateStart(fecha_ingreso))
                        com.Parameters.AddWithValue("@celular", celNum)
                        afectados = com.ExecuteNonQuery()
                    End Using

                    If afectados > 0 Then
                        RegistrarAuditoriaTx(cnx, tx, sesion, "ACTUALIZACION", rutLimpio)
                        tx.Commit()
                        OT.InvalidarCachePersonal()
                        cod_resp = 1
                        resp = "Datos del trabajador actualizados correctamente."
                    Else
                        tx.Rollback()
                        cod_resp = 0
                        resp = "No se encontró el RUT ingresado en la tabla de personal."
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Personal")
        End Try
    End Sub

    Public Sub DelPersonal(ByVal rut As String, ByVal sesion As String, ByRef cod_resp As Integer, ByRef resp As String)
        Dim conexion As New Conexion
        cod_resp = 0
        resp = String.Empty
        Dim rutLimpio As String = If(rut, String.Empty).Trim()
        If String.IsNullOrEmpty(rutLimpio) Then
            resp = "Debe buscar o seleccionar un trabajador antes de eliminar."
            Exit Sub
        End If

        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using tx As SqlTransaction = cnx.BeginTransaction()
                    Dim refs As Integer = ContarDependenciasTx(cnx, tx, rutLimpio)
                    If refs > 0 Then
                        tx.Rollback()
                        cod_resp = 0
                        resp = "No es posible eliminar a este trabajador porque posee registros asociados (OTs, Mantenciones Preventivas o cuenta de Usuario). Puede desactivarlo marcando 'Activo = No' y presionando Actualizar."
                        Exit Sub
                    End If

                    Dim afectados As Integer
                    Using cmdDel As New SqlCommand("DELETE FROM personal WHERE LTRIM(RTRIM(rut)) = @rut", cnx, tx)
                        cmdDel.Parameters.AddWithValue("@rut", rutLimpio)
                        afectados = cmdDel.ExecuteNonQuery()
                    End Using

                    If afectados > 0 Then
                        RegistrarAuditoriaTx(cnx, tx, sesion, "ELIMINAR", rutLimpio)
                        tx.Commit()
                        OT.InvalidarCachePersonal()
                        cod_resp = 1
                        resp = "Trabajador eliminado correctamente."
                    Else
                        tx.Rollback()
                        cod_resp = 0
                        resp = "No se encontró el RUT ingresado en la tabla de personal."
                    End If
                End Using
            End Using
        Catch ex As Exception
            cod_resp = -1
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Personal")
        End Try
    End Sub

    ''' <summary>
    ''' Activa o desactiva por lotes a todos los RUT indicados dentro de una única transacción auditada.
    ''' </summary>
    Public Function ActualizarEstadoLote(ByVal ruts As IEnumerable(Of String), ByVal activo As Boolean, ByVal sesion As String, ByRef afectados As Integer, ByRef resp As String) As Boolean
        afectados = 0
        resp = String.Empty
        Dim listaRuts As List(Of String) = NormalizarListaRuts(ruts)
        If listaRuts.Count = 0 Then
            resp = "Debe marcar al menos un trabajador mediante la casilla 'Sel.'."
            Return False
        End If

        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using tx As SqlTransaction = cnx.BeginTransaction()
                    Using cmd As New SqlCommand("UPDATE personal SET activo = @activo WHERE LTRIM(RTRIM(rut)) = @rut", cnx, tx)
                        Dim pAct As SqlParameter = cmd.Parameters.Add("@activo", SqlDbType.Bit)
                        Dim pRut As SqlParameter = cmd.Parameters.Add("@rut", SqlDbType.VarChar, 20)
                        pAct.Value = activo
                        For Each rutItem As String In listaRuts
                            pRut.Value = rutItem
                            Dim n As Integer = cmd.ExecuteNonQuery()
                            If n > 0 Then
                                afectados += n
                                RegistrarAuditoriaTx(cnx, tx, sesion, "ACTUALIZACION", rutItem)
                            End If
                        Next
                    End Using
                    tx.Commit()
                End Using
            End Using

            If afectados > 0 Then OT.InvalidarCachePersonal()
            Dim accionTxt As String = If(activo, "activados", "desactivados")
            resp = String.Format("Operación por lotes completada: {0} de {1} trabajador(es) {2}.", afectados, listaRuts.Count, accionTxt)
            Return afectados > 0
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Actualizar Estado Personal por Lote")
            resp = "Error al actualizar el estado por lotes: " & ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Reasigna Planta, Sección y/o Cargo por lotes a todos los trabajadores marcados en una única transacción auditada.
    ''' </summary>
    Public Function ReasignarLaboralLote(ByVal ruts As IEnumerable(Of String), ByVal idPlanta As Integer?, ByVal idSeccion As Integer?, ByVal idCargo As Integer?, ByVal sesion As String, ByRef afectados As Integer, ByRef resp As String) As Boolean
        afectados = 0
        resp = String.Empty
        Dim listaRuts As List(Of String) = NormalizarListaRuts(ruts)
        If listaRuts.Count = 0 Then
            resp = "Debe marcar al menos un trabajador mediante la casilla 'Sel.'."
            Return False
        End If
        If Not idPlanta.HasValue AndAlso Not idSeccion.HasValue AndAlso Not idCargo.HasValue Then
            resp = "Debe elegir al menos un campo laboral (Planta, Sección o Cargo) para reasignar."
            Return False
        End If

        Dim setParts As New List(Of String)()
        If idPlanta.HasValue Then setParts.Add("idcentro = @idcentro")
        If idSeccion.HasValue Then setParts.Add("idseccion = @idseccion")
        If idCargo.HasValue Then setParts.Add("idcargo = @idcargo")

        Dim sql As String = "UPDATE personal SET " & String.Join(", ", setParts.ToArray()) & " WHERE LTRIM(RTRIM(rut)) = @rut"
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using tx As SqlTransaction = cnx.BeginTransaction()
                    Using cmd As New SqlCommand(sql, cnx, tx)
                        If idPlanta.HasValue Then cmd.Parameters.AddWithValue("@idcentro", idPlanta.Value)
                        If idSeccion.HasValue Then cmd.Parameters.AddWithValue("@idseccion", idSeccion.Value)
                        If idCargo.HasValue Then cmd.Parameters.AddWithValue("@idcargo", idCargo.Value)
                        Dim pRut As SqlParameter = cmd.Parameters.Add("@rut", SqlDbType.VarChar, 20)
                        For Each rutItem As String In listaRuts
                            pRut.Value = rutItem
                            Dim n As Integer = cmd.ExecuteNonQuery()
                            If n > 0 Then
                                afectados += n
                                RegistrarAuditoriaTx(cnx, tx, sesion, "ACTUALIZACION", rutItem)
                            End If
                        Next
                    End Using
                    tx.Commit()
                End Using
            End Using

            If afectados > 0 Then OT.InvalidarCachePersonal()
            resp = String.Format("Reasignación laboral completada: {0} de {1} trabajador(es) actualizados.", afectados, listaRuts.Count)
            Return afectados > 0
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Reasignar Datos Laborales por Lote")
            resp = "Error al reasignar datos laborales por lotes: " & ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Elimina por lotes a los trabajadores marcados sin dependencias históricas, devolviendo los omitidos por historial para ofrecer desactivación.
    ''' </summary>
    Public Function EliminarPersonalLote(ByVal ruts As IEnumerable(Of String), ByVal sesion As String, ByRef eliminados As Integer, ByRef omitidosPorHistorial As List(Of String), ByRef resp As String) As Boolean
        eliminados = 0
        omitidosPorHistorial = New List(Of String)()
        resp = String.Empty
        Dim listaRuts As List(Of String) = NormalizarListaRuts(ruts)
        If listaRuts.Count = 0 Then
            resp = "Debe marcar al menos un trabajador mediante la casilla 'Sel.'."
            Return False
        End If

        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using tx As SqlTransaction = cnx.BeginTransaction()
                    Using cmdDel As New SqlCommand("DELETE FROM personal WHERE LTRIM(RTRIM(rut)) = @rut", cnx, tx)
                        Dim pRut As SqlParameter = cmdDel.Parameters.Add("@rut", SqlDbType.VarChar, 20)
                        For Each rutItem As String In listaRuts
                            If ContarDependenciasTx(cnx, tx, rutItem) > 0 Then
                                omitidosPorHistorial.Add(rutItem)
                                Continue For
                            End If
                            pRut.Value = rutItem
                            Dim n As Integer = cmdDel.ExecuteNonQuery()
                            If n > 0 Then
                                eliminados += n
                                RegistrarAuditoriaTx(cnx, tx, sesion, "ELIMINAR", rutItem)
                            End If
                        Next
                    End Using
                    tx.Commit()
                End Using
            End Using

            If eliminados > 0 Then OT.InvalidarCachePersonal()
            resp = String.Format("Eliminación por lotes finalizada: {0} eliminado(s), {1} omitido(s) por poseer historial en OT/MP/Usuario.", eliminados, omitidosPorHistorial.Count)
            Return True
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Eliminar Personal por Lote")
            resp = "Error al eliminar personal por lotes: " & ex.Message
            Return False
        End Try
    End Function

    Private Shared Function NormalizarListaRuts(ByVal ruts As IEnumerable(Of String)) As List(Of String)
        Dim resultado As New List(Of String)()
        If ruts Is Nothing Then Return resultado
        Dim vistos As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each r As String In ruts
            Dim limpio As String = If(r, String.Empty).Trim()
            If Not String.IsNullOrEmpty(limpio) AndAlso vistos.Add(limpio) Then
                resultado.Add(limpio)
            End If
        Next
        Return resultado
    End Function

    Public Sub limpiarFormPersonal(ByRef form As FrmPersonal)
        If form Is Nothing Then Exit Sub
        With form
            .txtRut.ReadOnly = False
            .txtDv.ReadOnly = False
            .txtRut.ResetText()
            .txtDv.ResetText()
            .txtCodInt.Text = "0"
            .txtNombres.ResetText()
            .txtApPaterno.ResetText()
            .txtApMaterno.ResetText()
            .txtfono.Text = "0"
            .txtEmail.ResetText()
            .txtAlias.ResetText()
            .fecha_nac.Value = DateTime.Today
            .txtDireccion.ResetText()
            .fecha_ingreso.Value = DateTime.Today
            .txtCelular.Text = "0"
            .opc_activo_si.Checked = True
            .btnIngresar.Visible = True
            .btnIngresar.Enabled = True
            .btnActualizar.Visible = True
            .btnActualizar.Enabled = False
            .btnEliminar.Enabled = False
            .ActualizarEstadoModoEdicion(False, String.Empty)
        End With
    End Sub

    Public Sub CrgPersonal(ByRef DS As DataSet)
        If DS Is Nothing Then DS = New DataSet()
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_PERSONAL_2", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.Fill(DS)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Personal")
        End Try
    End Sub

    Public Sub buscarPersonalRut(ByVal rut As Integer)
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("BUSCAR_PERSONAL_RUT", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.SelectCommand.Parameters.AddWithValue("@rut", rut)

                    Using DST As New DataSet
                        DA.Fill(DST)
                        If DST.Tables.Count > 0 AndAlso DST.Tables(0).Rows.Count > 0 Then
                            Dim dr As DataRow = DST.Tables(0).Rows(0)
                            With FrmPersonal
                                Dim rutTxt As String = If(IsDBNull(dr.Item(0)), String.Empty, dr.Item(0).ToString().Trim())
                                Dim dvTxt As String = If(IsDBNull(dr.Item(1)), String.Empty, dr.Item(1).ToString().Trim().ToUpperInvariant())
                                .txtRut.Text = rutTxt
                                .txtDv.Text = dvTxt
                                .txtRut.ReadOnly = True
                                .txtDv.ReadOnly = True
                                .cmbPlanta.Text = If(IsDBNull(dr.Item(2)), String.Empty, dr.Item(2).ToString().Trim())
                                .cmbSeccion.Text = If(IsDBNull(dr.Item(3)), String.Empty, dr.Item(3).ToString().Trim())
                                .cmbCargo.Text = If(IsDBNull(dr.Item(4)), String.Empty, dr.Item(4).ToString().Trim())
                                .txtCodInt.Text = If(IsDBNull(dr.Item(8)), "0", dr.Item(8).ToString().Trim())
                                .txtNombres.Text = If(IsDBNull(dr.Item(5)), String.Empty, dr.Item(5).ToString().Trim())
                                .txtApPaterno.Text = If(IsDBNull(dr.Item(6)), String.Empty, dr.Item(6).ToString().Trim())
                                .txtApMaterno.Text = If(IsDBNull(dr.Item(7)), String.Empty, dr.Item(7).ToString().Trim())
                                Utilitarios.AsignarFechaSegura(.fecha_nac, dr.Item(9), DateTime.Today)
                                .txtfono.Text = If(IsDBNull(dr.Item(10)), "0", dr.Item(10).ToString().Trim())
                                .txtEmail.Text = If(IsDBNull(dr.Item(11)), String.Empty, dr.Item(11).ToString().Trim())
                                .txtAlias.Text = If(IsDBNull(dr.Item(12)), String.Empty, dr.Item(12).ToString().Trim())
                                Dim actStr As String = If(IsDBNull(dr.Item(13)), String.Empty, dr.Item(13).ToString().Trim())
                                If actStr.Equals("True", StringComparison.OrdinalIgnoreCase) OrElse actStr = "1" Then
                                    .opc_activo_si.Checked = True
                                Else
                                    .opc_activo_no.Checked = True
                                End If
                                .txtDireccion.Text = If(IsDBNull(dr.Item(14)), String.Empty, dr.Item(14).ToString().Trim())
                                Utilitarios.AsignarFechaSegura(.fecha_ingreso, dr.Item(15), DateTime.Today)
                                .txtCelular.Text = If(IsDBNull(dr.Item(16)), "0", dr.Item(16).ToString().Trim())
                                .btnIngresar.Visible = True
                                .btnIngresar.Enabled = False
                                .btnActualizar.Visible = True
                                .btnActualizar.Enabled = True
                                .btnEliminar.Enabled = True
                                .ActualizarEstadoModoEdicion(True, String.Format("{0}-{1} · {2} {3}", rutTxt, dvTxt, .txtNombres.Text.Trim(), .txtApPaterno.Text.Trim()))
                                .SeleccionarFilaPorRut(rutTxt)
                            End With
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Personal RUT")
        End Try
    End Sub

    Public Sub BuscarPersonalMp(ByRef txt_alias As TextBox)
        If txt_alias Is Nothing Then Exit Sub
        Try
            Dim datos As AutoCompleteStringCollection = OT.ObtenerColeccionAutocompletarPersonal()
            With txt_alias
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .AutoCompleteCustomSource = datos
            End With
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Personal MP")
        End Try
    End Sub

    Public Sub BuscarPersonalMp2(ByRef DS As DataSet)
        If DS Is Nothing Then DS = New DataSet()
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("AUTOCOMPLETAR_PERSONAL", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    DA.Fill(DS)
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Buscar Personal MP 2")
        End Try
    End Sub
End Class
