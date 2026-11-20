Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Linq

Public Class FrmAdminAuditoria

    Private _dtAuditoriaOriginal As DataTable = Nothing
    Private _dvAuditoria As DataView = Nothing
    Private _cargandoFiltros As Boolean = False

    ' Nombres dinámicos de columnas detectados en la tabla de auditoría
    Private _colId As String = ""
    Private _colSesion As String = ""
    Private _colOperacion As String = ""
    Private _colFecha As String = ""
    Private _colHora As String = ""
    Private _colTabla As String = ""
    Private _colClave As String = ""
    Private _colPc As String = ""

    ' Tablas de estadísticas calculadas
    Private _dtStatSesion As DataTable = Nothing
    Private _dtStatOperacion As DataTable = Nothing
    Private _dtStatPc As DataTable = Nothing
    Private _dtStatTabla As DataTable = Nothing
    Private _dtStatFecha As DataTable = Nothing

    Private Sub FrmAdminAuditoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Try
            Dim formato As New FormatoGrillas()
            formato.grillasOT(grillaAuditoria)

            ' Estilo moderno a todas las grillas estadísticas
            FormatoGrillas.AplicarEstiloModerno(grillaStatSesion)
            FormatoGrillas.AplicarEstiloModerno(grillaStatOperacion)
            FormatoGrillas.AplicarEstiloModerno(grillaStatPc)
            FormatoGrillas.AplicarEstiloModerno(grillaStatTabla)
            FormatoGrillas.AplicarEstiloModerno(grillaStatFecha)

            InicializarCombosFiltro()
            Utilitarios.InicializarRangoMesActual(fecha_ini_aud, fecha_fin_aud)
            Utilitarios.AplicarTemaModerno(Me)
            ActualizarBarraEstado(0, 0, 0)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Auditoría de Operaciones (Carga)", True, Me)
        Finally
            Me.ResumeLayout(True)
        End Try
    End Sub

    Private Sub InicializarCombosFiltro()
        _cargandoFiltros = True
        Try
            cboFiltroSesion.Items.Clear()
            cboFiltroSesion.Items.Add("[Todos]")
            cboFiltroSesion.SelectedIndex = 0

            cboFiltroOperacion.Items.Clear()
            cboFiltroOperacion.Items.Add("[Todas]")
            cboFiltroOperacion.SelectedIndex = 0

            cboFiltroPc.Items.Clear()
            cboFiltroPc.Items.Add("[Todas]")
            cboFiltroPc.SelectedIndex = 0

            cboFiltroTabla.Items.Clear()
            cboFiltroTabla.Items.Add("[Todas]")
            cboFiltroTabla.SelectedIndex = 0
        Finally
            _cargandoFiltros = False
        End Try
    End Sub

    ''' <summary>
    ''' Carga un DataTable de auditoría, detecta columnas, inicializa filtros y calcula estadísticas.
    ''' </summary>
    Public Sub CargarDatosAuditoria(ByVal dt As DataTable)
        If dt IsNot Nothing Then
            _dtAuditoriaOriginal = dt
            DetectarColumnas(_dtAuditoriaOriginal)
            CargarValoresFiltrosDesdeDatos()

            _dvAuditoria = New DataView(_dtAuditoriaOriginal)
            grillaAuditoria.DataSource = _dvAuditoria

            Utilitarios.AjustarColumnasGrilla(grillaAuditoria)
            AplicarFiltrosYEstadisticas()
        End If
    End Sub

    Private Sub btn_buscar_aud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_aud.Click
        If Not Utilitarios.ValidarRangoFechas(fecha_ini_aud, fecha_fin_aud) Then Exit Sub

        Dim auditoria As New Auditoria
        Dim DST_AUD As New DataSet

        Cursor = Cursors.WaitCursor
        Try
            auditoria.CrgInfAuditoria(fecha_ini_aud.Value, fecha_fin_aud.Value, DST_AUD)
            If DST_AUD.Tables.Count > 0 AndAlso DST_AUD.Tables(0) IsNot Nothing AndAlso DST_AUD.Tables(0).Rows.Count > 0 Then
                CargarDatosAuditoria(DST_AUD.Tables(0))
            Else
                _dtAuditoriaOriginal = Nothing
                _dvAuditoria = Nothing
                grillaAuditoria.DataSource = Nothing
                LimpiarEstadisticas()
                ActualizarBarraEstado(0, 0, 0)
                MsgBox("No se encontraron registros de auditoría para el rango de fechas seleccionado.", MsgBoxStyle.Information, "Auditoría de Operaciones")
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Auditoría de Operaciones (Buscar Aud)", True, Me)
        Finally
            DST_AUD.Dispose()
            Cursor = Cursors.Default
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Sub DetectarColumnas(ByVal dt As DataTable)
        If dt Is Nothing OrElse dt.Columns.Count = 0 Then Exit Sub

        _colId = DetectarCol(dt, New String() {"id_operacion", "id_auditoria", "id", "id operación"}, 0)
        _colSesion = DetectarCol(dt, New String() {"sesión", "sesion", "usuario", "login", "nombre_usuario"}, 1)
        _colOperacion = DetectarCol(dt, New String() {"operación", "operacion", "tipo_operacion", "accion"}, 2)
        _colFecha = DetectarCol(dt, New String() {"fecha operación", "fecha_operacion", "fecha"}, 3)
        _colHora = DetectarCol(dt, New String() {"hora operación", "hora_operacion", "hora"}, 4)
        _colTabla = DetectarCol(dt, New String() {"tabla", "tabla_afectada"}, 5)
        _colClave = DetectarCol(dt, New String() {"clave afectada", "clave_afectada", "clave"}, 6)
        _colPc = DetectarCol(dt, New String() {"nombre pc", "nombre_pc", "pc", "equipo", "estacion"}, 7)
    End Sub

    Private Function DetectarCol(ByVal dt As DataTable, ByVal posiblesNombres As String(), ByVal indiceFallback As Integer) As String
        For Each col As DataColumn In dt.Columns
            For Each pos As String In posiblesNombres
                If col.ColumnName.Trim().Equals(pos, StringComparison.OrdinalIgnoreCase) Then
                    Return col.ColumnName
                End If
            Next
        Next
        If indiceFallback >= 0 AndAlso indiceFallback < dt.Columns.Count Then
            Return dt.Columns(indiceFallback).ColumnName
        End If
        Return If(dt.Columns.Count > 0, dt.Columns(0).ColumnName, "")
    End Function

    Private Sub CargarValoresFiltrosDesdeDatos()
        If _dtAuditoriaOriginal Is Nothing Then Exit Sub

        _cargandoFiltros = True
        Try
            Dim selSesion As String = cboFiltroSesion.Text
            Dim selOperacion As String = cboFiltroOperacion.Text
            Dim selPc As String = cboFiltroPc.Text
            Dim selTabla As String = cboFiltroTabla.Text

            ' Sesión
            cboFiltroSesion.Items.Clear()
            cboFiltroSesion.Items.Add("[Todos]")
            If Not String.IsNullOrEmpty(_colSesion) AndAlso _dtAuditoriaOriginal.Columns.Contains(_colSesion) Then
                Dim sesiones = (From r In _dtAuditoriaOriginal.AsEnumerable()
                                Where Not r.IsNull(_colSesion) AndAlso Not String.IsNullOrWhiteSpace(r.Field(Of Object)(_colSesion).ToString())
                                Select r.Field(Of Object)(_colSesion).ToString().Trim()).Distinct().OrderBy(Function(s) s)
                For Each s In sesiones
                    cboFiltroSesion.Items.Add(s)
                Next
            End If

            ' Operación
            cboFiltroOperacion.Items.Clear()
            cboFiltroOperacion.Items.Add("[Todas]")
            If Not String.IsNullOrEmpty(_colOperacion) AndAlso _dtAuditoriaOriginal.Columns.Contains(_colOperacion) Then
                Dim ops = (From r In _dtAuditoriaOriginal.AsEnumerable()
                           Where Not r.IsNull(_colOperacion) AndAlso Not String.IsNullOrWhiteSpace(r.Field(Of Object)(_colOperacion).ToString())
                           Select r.Field(Of Object)(_colOperacion).ToString().Trim().ToUpperInvariant()).Distinct().OrderBy(Function(o) o)
                For Each o In ops
                    cboFiltroOperacion.Items.Add(o)
                Next
            End If

            ' PC
            cboFiltroPc.Items.Clear()
            cboFiltroPc.Items.Add("[Todas]")
            If Not String.IsNullOrEmpty(_colPc) AndAlso _dtAuditoriaOriginal.Columns.Contains(_colPc) Then
                Dim pcs = (From r In _dtAuditoriaOriginal.AsEnumerable()
                           Where Not r.IsNull(_colPc) AndAlso Not String.IsNullOrWhiteSpace(r.Field(Of Object)(_colPc).ToString())
                           Select r.Field(Of Object)(_colPc).ToString().Trim().ToUpperInvariant()).Distinct().OrderBy(Function(p) p)
                For Each p In pcs
                    cboFiltroPc.Items.Add(p)
                Next
            End If

            ' Tabla
            cboFiltroTabla.Items.Clear()
            cboFiltroTabla.Items.Add("[Todas]")
            If Not String.IsNullOrEmpty(_colTabla) AndAlso _dtAuditoriaOriginal.Columns.Contains(_colTabla) Then
                Dim tablas = (From r In _dtAuditoriaOriginal.AsEnumerable()
                              Where Not r.IsNull(_colTabla) AndAlso Not String.IsNullOrWhiteSpace(r.Field(Of Object)(_colTabla).ToString())
                              Select r.Field(Of Object)(_colTabla).ToString().Trim()).Distinct().OrderBy(Function(t) t)
                For Each t In tablas
                    cboFiltroTabla.Items.Add(t)
                Next
            End If

            ' Restaurar selecciones si aún existen en la lista
            RestaurarSeleccionCombo(cboFiltroSesion, selSesion)
            RestaurarSeleccionCombo(cboFiltroOperacion, selOperacion)
            RestaurarSeleccionCombo(cboFiltroPc, selPc)
            RestaurarSeleccionCombo(cboFiltroTabla, selTabla)
        Finally
            _cargandoFiltros = False
        End Try
    End Sub

    Private Sub RestaurarSeleccionCombo(ByVal cbo As ComboBox, ByVal valor As String)
        If String.IsNullOrEmpty(valor) Then
            cbo.SelectedIndex = 0
            Exit Sub
        End If
        Dim idx As Integer = cbo.FindStringExact(valor)
        If idx >= 0 Then
            cbo.SelectedIndex = idx
        Else
            cbo.SelectedIndex = 0
        End If
    End Sub

    ' Manejadores de cambios en filtros
    Private Sub cboFiltroSesion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboFiltroSesion.SelectedIndexChanged
        If Not _cargandoFiltros Then AplicarFiltrosYEstadisticas()
    End Sub

    Private Sub cboFiltroOperacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboFiltroOperacion.SelectedIndexChanged
        If Not _cargandoFiltros Then AplicarFiltrosYEstadisticas()
    End Sub

    Private Sub cboFiltroPc_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboFiltroPc.SelectedIndexChanged
        If Not _cargandoFiltros Then AplicarFiltrosYEstadisticas()
    End Sub

    Private Sub cboFiltroTabla_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboFiltroTabla.SelectedIndexChanged
        If Not _cargandoFiltros Then AplicarFiltrosYEstadisticas()
    End Sub

    Private Sub txtBusquedaRapida_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtBusquedaRapida.TextChanged
        If Not _cargandoFiltros Then AplicarFiltrosYEstadisticas()
    End Sub

    Private Sub btnLimpiarFiltros_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiarFiltros.Click
        _cargandoFiltros = True
        Try
            Utilitarios.InicializarRangoPorDefecto(fecha_ini_aud, fecha_fin_aud)
            cboFiltroSesion.SelectedIndex = 0
            cboFiltroOperacion.SelectedIndex = 0
            cboFiltroPc.SelectedIndex = 0
            cboFiltroTabla.SelectedIndex = 0
            txtBusquedaRapida.Text = ""
        Finally
            _cargandoFiltros = False
        End Try
        AplicarFiltrosYEstadisticas()
    End Sub

    Private Sub AplicarFiltrosYEstadisticas()
        If _dtAuditoriaOriginal Is Nothing OrElse _dvAuditoria Is Nothing Then Exit Sub

        Dim condiciones As New List(Of String)

        ' Filtro Sesión
        If cboFiltroSesion.SelectedIndex > 0 AndAlso Not String.IsNullOrEmpty(_colSesion) Then
            Dim valSesion As String = cboFiltroSesion.Text.Replace("'", "''")
            condiciones.Add(String.Format("[{0}] = '{1}'", _colSesion, valSesion))
        End If

        ' Filtro Operación
        If cboFiltroOperacion.SelectedIndex > 0 AndAlso Not String.IsNullOrEmpty(_colOperacion) Then
            Dim valOp As String = cboFiltroOperacion.Text.Replace("'", "''")
            condiciones.Add(String.Format("[{0}] = '{1}'", _colOperacion, valOp))
        End If

        ' Filtro PC
        If cboFiltroPc.SelectedIndex > 0 AndAlso Not String.IsNullOrEmpty(_colPc) Then
            Dim valPc As String = cboFiltroPc.Text.Replace("'", "''")
            condiciones.Add(String.Format("[{0}] = '{1}'", _colPc, valPc))
        End If

        ' Filtro Tabla
        If cboFiltroTabla.SelectedIndex > 0 AndAlso Not String.IsNullOrEmpty(_colTabla) Then
            Dim valTabla As String = cboFiltroTabla.Text.Replace("'", "''")
            condiciones.Add(String.Format("[{0}] = '{1}'", _colTabla, valTabla))
        End If

        ' Búsqueda Rápida de Texto
        Dim busqueda As String = Utilitarios.EscaparLike(txtBusquedaRapida.Text.Trim())
        If Not String.IsNullOrEmpty(busqueda) Then
            Dim orConds As New List(Of String)
            If Not String.IsNullOrEmpty(_colClave) Then orConds.Add(String.Format("CONVERT([{0}], 'System.String') LIKE '%{1}%'", _colClave, busqueda))
            If Not String.IsNullOrEmpty(_colId) Then orConds.Add(String.Format("CONVERT([{0}], 'System.String') LIKE '%{1}%'", _colId, busqueda))
            If Not String.IsNullOrEmpty(_colSesion) Then orConds.Add(String.Format("CONVERT([{0}], 'System.String') LIKE '%{1}%'", _colSesion, busqueda))
            If Not String.IsNullOrEmpty(_colOperacion) Then orConds.Add(String.Format("CONVERT([{0}], 'System.String') LIKE '%{1}%'", _colOperacion, busqueda))
            If Not String.IsNullOrEmpty(_colPc) Then orConds.Add(String.Format("CONVERT([{0}], 'System.String') LIKE '%{1}%'", _colPc, busqueda))
            If Not String.IsNullOrEmpty(_colTabla) Then orConds.Add(String.Format("CONVERT([{0}], 'System.String') LIKE '%{1}%'", _colTabla, busqueda))

            If orConds.Count > 0 Then
                condiciones.Add("(" & String.Join(" OR ", orConds) & ")")
            End If
        End If

        Dim filtroFinal As String = String.Join(" AND ", condiciones)
        _dvAuditoria.RowFilter = filtroFinal

        ' Recalcular métricas y tablas estadísticas sobre la vista filtrada
        CalcularEstadisticas()
        ActualizarBarraEstado(_dvAuditoria.Count, _dtAuditoriaOriginal.Rows.Count, grillaAuditoria.SelectedRows.Count)
    End Sub

    Private Class StatUsuario
        Public Property Total As Integer = 0
        Public Property Inserciones As Integer = 0
        Public Property Actualizaciones As Integer = 0
        Public Property Eliminaciones As Integer = 0
        Public Property Otras As Integer = 0
    End Class

    Private Sub CalcularEstadisticas()
        If _dvAuditoria Is Nothing Then
            LimpiarEstadisticas()
            Exit Sub
        End If

        Dim totalFilas As Integer = _dvAuditoria.Count
        If totalFilas = 0 Then
            LimpiarEstadisticas()
            lblKpiTotalOps.Text = "0 ops (0%)"
            lblKpiInserciones.Text = "0 (0%)"
            lblKpiActualizaciones.Text = "0 (0%)"
            lblKpiEliminaciones.Text = "0 (0%)"
            lblKpiTopUsuario.Text = "-"
            lblKpiTopPc.Text = "-"
            Exit Sub
        End If

        Dim dictSesion As New Dictionary(Of String, StatUsuario)(StringComparer.OrdinalIgnoreCase)
        Dim dictOperacion As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
        Dim dictPc As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
        Dim dictTabla As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
        Dim dictFecha As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)

        Dim totalIns As Integer = 0
        Dim totalUpd As Integer = 0
        Dim totalDel As Integer = 0

        For Each rowView As DataRowView In _dvAuditoria
            Dim sesion As String = If(Not String.IsNullOrEmpty(_colSesion) AndAlso Not IsDBNull(rowView(_colSesion)), rowView(_colSesion).ToString().Trim(), "DESCONOCIDO")
            Dim operacion As String = If(Not String.IsNullOrEmpty(_colOperacion) AndAlso Not IsDBNull(rowView(_colOperacion)), rowView(_colOperacion).ToString().Trim().ToUpperInvariant(), "OTRA")
            Dim pc As String = If(Not String.IsNullOrEmpty(_colPc) AndAlso Not IsDBNull(rowView(_colPc)), rowView(_colPc).ToString().Trim().ToUpperInvariant(), "DESCONOCIDO")
            Dim tabla As String = If(Not String.IsNullOrEmpty(_colTabla) AndAlso Not IsDBNull(rowView(_colTabla)), rowView(_colTabla).ToString().Trim(), "DESCONOCIDA")
            Dim fechaRaw As Object = If(Not String.IsNullOrEmpty(_colFecha), rowView(_colFecha), Nothing)
            Dim fecha As String = ""

            If fechaRaw IsNot Nothing AndAlso Not IsDBNull(fechaRaw) Then
                If TypeOf fechaRaw Is DateTime Then
                    fecha = DirectCast(fechaRaw, DateTime).ToString("dd-MM-yyyy")
                Else
                    Dim dtParsed As DateTime
                    If DateTime.TryParse(fechaRaw.ToString(), dtParsed) Then
                        fecha = dtParsed.ToString("dd-MM-yyyy")
                    Else
                        fecha = fechaRaw.ToString().Trim()
                    End If
                End If
            Else
                fecha = "SIN FECHA"
            End If

            ' Conteo por Operación
            If operacion.Contains("INSER") Then
                totalIns += 1
            ElseIf operacion.Contains("ACTUAL") OrElse operacion.Contains("MODIF") Then
                totalUpd += 1
            ElseIf operacion.Contains("ELIM") OrElse operacion.Contains("BORR") Then
                totalDel += 1
            End If

            If Not dictOperacion.ContainsKey(operacion) Then dictOperacion(operacion) = 0
            dictOperacion(operacion) += 1

            ' Conteo por Sesión
            If Not dictSesion.ContainsKey(sesion) Then dictSesion(sesion) = New StatUsuario()
            Dim sStat = dictSesion(sesion)
            sStat.Total += 1
            If operacion.Contains("INSER") Then
                sStat.Inserciones += 1
            ElseIf operacion.Contains("ACTUAL") OrElse operacion.Contains("MODIF") Then
                sStat.Actualizaciones += 1
            ElseIf operacion.Contains("ELIM") OrElse operacion.Contains("BORR") Then
                sStat.Eliminaciones += 1
            Else
                sStat.Otras += 1
            End If

            ' Conteo por PC
            If Not dictPc.ContainsKey(pc) Then dictPc(pc) = 0
            dictPc(pc) += 1

            ' Conteo por Tabla
            If Not dictTabla.ContainsKey(tabla) Then dictTabla(tabla) = 0
            dictTabla(tabla) += 1

            ' Conteo por Fecha
            If Not dictFecha.ContainsKey(fecha) Then dictFecha(fecha) = 0
            dictFecha(fecha) += 1
        Next

        ' 1. Tabla Estadística por Sesión
        _dtStatSesion = New DataTable("Sesión")
        _dtStatSesion.Columns.Add("Sesión / Usuario", GetType(String))
        _dtStatSesion.Columns.Add("Total Operaciones", GetType(Integer))
        _dtStatSesion.Columns.Add("% Participación", GetType(String))
        _dtStatSesion.Columns.Add("Inserciones", GetType(Integer))
        _dtStatSesion.Columns.Add("Actualizaciones", GetType(Integer))
        _dtStatSesion.Columns.Add("Eliminaciones", GetType(Integer))

        Dim listaSesion = dictSesion.OrderByDescending(Function(kvp) kvp.Value.Total).ToList()
        For Each kvp In listaSesion
            Dim pct As Double = Math.Round((kvp.Value.Total * 100.0) / totalFilas, 1)
            _dtStatSesion.Rows.Add(kvp.Key, kvp.Value.Total, pct.ToString("0.0") & "%", kvp.Value.Inserciones, kvp.Value.Actualizaciones, kvp.Value.Eliminaciones)
        Next
        grillaStatSesion.DataSource = _dtStatSesion
        Utilitarios.AjustarColumnasGrilla(grillaStatSesion)

        ' 2. Tabla Estadística por Operación
        _dtStatOperacion = New DataTable("Operación")
        _dtStatOperacion.Columns.Add("Tipo de Operación", GetType(String))
        _dtStatOperacion.Columns.Add("Total Operaciones", GetType(Integer))
        _dtStatOperacion.Columns.Add("% Participación", GetType(String))

        Dim listaOp = dictOperacion.OrderByDescending(Function(kvp) kvp.Value).ToList()
        For Each kvp In listaOp
            Dim pct As Double = Math.Round((kvp.Value * 100.0) / totalFilas, 1)
            _dtStatOperacion.Rows.Add(kvp.Key, kvp.Value, pct.ToString("0.0") & "%")
        Next
        grillaStatOperacion.DataSource = _dtStatOperacion
        Utilitarios.AjustarColumnasGrilla(grillaStatOperacion)

        ' 3. Tabla Estadística por PC
        _dtStatPc = New DataTable("Estación PC")
        _dtStatPc.Columns.Add("Nombre de PC", GetType(String))
        _dtStatPc.Columns.Add("Total Operaciones", GetType(Integer))
        _dtStatPc.Columns.Add("% Participación", GetType(String))

        Dim listaPc = dictPc.OrderByDescending(Function(kvp) kvp.Value).ToList()
        For Each kvp In listaPc
            Dim pct As Double = Math.Round((kvp.Value * 100.0) / totalFilas, 1)
            _dtStatPc.Rows.Add(kvp.Key, kvp.Value, pct.ToString("0.0") & "%")
        Next
        grillaStatPc.DataSource = _dtStatPc
        Utilitarios.AjustarColumnasGrilla(grillaStatPc)

        ' 4. Tabla Estadística por Tabla
        _dtStatTabla = New DataTable("Tabla")
        _dtStatTabla.Columns.Add("Tabla Afectada", GetType(String))
        _dtStatTabla.Columns.Add("Total Operaciones", GetType(Integer))
        _dtStatTabla.Columns.Add("% Participación", GetType(String))

        Dim listaTabla = dictTabla.OrderByDescending(Function(kvp) kvp.Value).ToList()
        For Each kvp In listaTabla
            Dim pct As Double = Math.Round((kvp.Value * 100.0) / totalFilas, 1)
            _dtStatTabla.Rows.Add(kvp.Key, kvp.Value, pct.ToString("0.0") & "%")
        Next
        grillaStatTabla.DataSource = _dtStatTabla
        Utilitarios.AjustarColumnasGrilla(grillaStatTabla)

        ' 5. Tabla Estadística por Fecha
        _dtStatFecha = New DataTable("Fecha")
        _dtStatFecha.Columns.Add("Fecha Operación", GetType(String))
        _dtStatFecha.Columns.Add("Total Operaciones", GetType(Integer))
        _dtStatFecha.Columns.Add("% Participación", GetType(String))

        Dim listaFecha = dictFecha.OrderByDescending(Function(kvp) kvp.Value).ToList()
        For Each kvp In listaFecha
            Dim pct As Double = Math.Round((kvp.Value * 100.0) / totalFilas, 1)
            _dtStatFecha.Rows.Add(kvp.Key, kvp.Value, pct.ToString("0.0") & "%")
        Next
        grillaStatFecha.DataSource = _dtStatFecha
        Utilitarios.AjustarColumnasGrilla(grillaStatFecha)

        ' Actualizar Tarjetas KPI
        Dim pctFiltrado As Double = If(_dtAuditoriaOriginal IsNot Nothing AndAlso _dtAuditoriaOriginal.Rows.Count > 0, Math.Round((totalFilas * 100.0) / _dtAuditoriaOriginal.Rows.Count, 1), 100.0)
        lblKpiTotalOps.Text = String.Format("{0:N0} ops ({1:0.0}%)", totalFilas, pctFiltrado)
        lblKpiInserciones.Text = String.Format("{0:N0} ({1:0.0}%)", totalIns, (totalIns * 100.0) / totalFilas)
        lblKpiActualizaciones.Text = String.Format("{0:N0} ({1:0.0}%)", totalUpd, (totalUpd * 100.0) / totalFilas)
        lblKpiEliminaciones.Text = String.Format("{0:N0} ({1:0.0}%)", totalDel, (totalDel * 100.0) / totalFilas)

        If listaSesion.Count > 0 Then
            lblKpiTopUsuario.Text = String.Format("{0} ({1} ops)", listaSesion(0).Key, listaSesion(0).Value.Total)
        Else
            lblKpiTopUsuario.Text = "-"
        End If

        If listaPc.Count > 0 Then
            lblKpiTopPc.Text = String.Format("{0} ({1} ops)", listaPc(0).Key, listaPc(0).Value)
        Else
            lblKpiTopPc.Text = "-"
        End If
    End Sub

    Private Sub LimpiarEstadisticas()
        grillaStatSesion.DataSource = Nothing
        grillaStatOperacion.DataSource = Nothing
        grillaStatPc.DataSource = Nothing
        grillaStatTabla.DataSource = Nothing
        grillaStatFecha.DataSource = Nothing

        _dtStatSesion = Nothing
        _dtStatOperacion = Nothing
        _dtStatPc = Nothing
        _dtStatTabla = Nothing
        _dtStatFecha = Nothing
    End Sub

    Private Sub ActualizarBarraEstado(ByVal visibles As Integer, ByVal totales As Integer, ByVal seleccionadas As Integer)
        lblEstadoRegistros.Text = String.Format("Mostrando {0:N0} de {1:N0} operaciones cargadas", visibles, totales)
        If seleccionadas > 1 Then
            lblEstadoSeleccion.Text = String.Format("{0:N0} filas seleccionadas para exportar", seleccionadas)
            lblEstadoSeleccion.ForeColor = Utilitarios.ColorTextoDestacado
        Else
            lblEstadoSeleccion.Text = "Exportación: todos los registros visibles filtrados"
            lblEstadoSeleccion.ForeColor = Utilitarios.ColorPrimario
        End If
    End Sub

    Private Sub grillaAuditoria_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grillaAuditoria.SelectionChanged
        If _dtAuditoriaOriginal Is Nothing Then Exit Sub
        Dim selCount As Integer = grillaAuditoria.SelectedRows.Count
        If selCount = 0 AndAlso grillaAuditoria.SelectedCells.Count > 1 Then
            Dim rowsHashSet As New HashSet(Of Integer)
            For Each cell As DataGridViewCell In grillaAuditoria.SelectedCells
                rowsHashSet.Add(cell.RowIndex)
            Next
            selCount = rowsHashSet.Count
        End If
        ActualizarBarraEstado(If(_dvAuditoria IsNot Nothing, _dvAuditoria.Count, 0), If(_dtAuditoriaOriginal IsNot Nothing, _dtAuditoriaOriginal.Rows.Count, 0), selCount)
    End Sub

    ' Doble clic interactivo en estadísticas para filtrar la grilla principal
    Private Sub grillaStatSesion_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles grillaStatSesion.CellDoubleClick
        If e.RowIndex < 0 OrElse e.RowIndex >= grillaStatSesion.RowCount OrElse grillaStatSesion.Rows(e.RowIndex).IsNewRow Then Exit Sub
        Dim val As String = Utilitarios.CeldaTexto(grillaStatSesion.Rows(e.RowIndex), 0)
        If Not String.IsNullOrEmpty(val) Then
            cboFiltroSesion.Text = val
            tabAuditoria.SelectedTab = tabDetalle
        End If
    End Sub

    Private Sub grillaStatOperacion_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles grillaStatOperacion.CellDoubleClick
        If e.RowIndex < 0 OrElse e.RowIndex >= grillaStatOperacion.RowCount OrElse grillaStatOperacion.Rows(e.RowIndex).IsNewRow Then Exit Sub
        Dim val As String = Utilitarios.CeldaTexto(grillaStatOperacion.Rows(e.RowIndex), 0)
        If Not String.IsNullOrEmpty(val) Then
            cboFiltroOperacion.Text = val
            tabAuditoria.SelectedTab = tabDetalle
        End If
    End Sub

    Private Sub grillaStatPc_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles grillaStatPc.CellDoubleClick
        If e.RowIndex < 0 OrElse e.RowIndex >= grillaStatPc.RowCount OrElse grillaStatPc.Rows(e.RowIndex).IsNewRow Then Exit Sub
        Dim val As String = Utilitarios.CeldaTexto(grillaStatPc.Rows(e.RowIndex), 0)
        If Not String.IsNullOrEmpty(val) Then
            cboFiltroPc.Text = val
            tabAuditoria.SelectedTab = tabDetalle
        End If
    End Sub

    Private Sub grillaStatTabla_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles grillaStatTabla.CellDoubleClick
        If e.RowIndex < 0 OrElse e.RowIndex >= grillaStatTabla.RowCount OrElse grillaStatTabla.Rows(e.RowIndex).IsNewRow Then Exit Sub
        Dim val As String = Utilitarios.CeldaTexto(grillaStatTabla.Rows(e.RowIndex), 0)
        If Not String.IsNullOrEmpty(val) Then
            cboFiltroTabla.Text = val
            tabAuditoria.SelectedTab = tabDetalle
        End If
    End Sub

    ' Exportación Inteligente
    Private Sub btn_exp_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exp_excel.Click
        If grillaAuditoria.RowCount = 0 Then
            MsgBox("No hay registros en la grilla para exportar.", MsgBoxStyle.Information, "Exportar Auditoría")
            Exit Sub
        End If

        Dim filasSeleccionadas As New List(Of DataGridViewRow)

        If grillaAuditoria.SelectedRows.Count > 1 Then
            For Each r As DataGridViewRow In grillaAuditoria.SelectedRows
                filasSeleccionadas.Add(r)
            Next
            filasSeleccionadas.Reverse()
        ElseIf grillaAuditoria.SelectedCells.Count > 1 Then
            Dim hashFilas As New HashSet(Of Integer)
            For Each c As DataGridViewCell In grillaAuditoria.SelectedCells
                hashFilas.Add(c.RowIndex)
            Next
            If hashFilas.Count > 1 Then
                Dim listaOrdenada = hashFilas.OrderBy(Function(x) x).ToList()
                For Each idx In listaOrdenada
                    filasSeleccionadas.Add(grillaAuditoria.Rows(idx))
                Next
            End If
        End If

        Dim exportarSoloSeleccion As Boolean = False

        If filasSeleccionadas.Count > 1 Then
            Dim mensaje As String = String.Format("Ha seleccionado {0} filas en la grilla.{1}{1}" &
                                                  "¿Desea exportar únicamente las {0} filas seleccionadas?{1}{1}" &
                                                  "• Presione [Sí] para exportar SOLO las {0} filas seleccionadas.{1}" &
                                                  "• Presione [No] para exportar TODOS los {2} registros visibles filtrados.{1}" &
                                                  "• Presione [Cancelar] para anular la exportación.",
                                                  filasSeleccionadas.Count, vbCrLf, grillaAuditoria.RowCount)

            Dim resp As DialogResult = MessageBox.Show(mensaje, "Opciones de Exportación a Excel", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If resp = DialogResult.Cancel Then
                Exit Sub
            ElseIf resp = DialogResult.Yes Then
                exportarSoloSeleccion = True
            Else
                exportarSoloSeleccion = False
            End If
        End If

        Cursor = Cursors.WaitCursor
        Dim dsStats As DataSet = Nothing
        Try
            Dim informes As New Informes
            Dim filasAExportar As IList(Of DataGridViewRow) = If(exportarSoloSeleccion, filasSeleccionadas, Nothing)
            dsStats = ObtenerDataSetEstadisticas()

            informes.expInfAuditoria(grillaAuditoria, fecha_ini_aud.Value, fecha_fin_aud.Value, filasAExportar, True, dsStats)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Auditoría de Operaciones (Exportar Excel)", True, Me)
        Finally
            If dsStats IsNot Nothing Then dsStats.Dispose()
            Cursor = Cursors.Default
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Sub btnExpEstadisticas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExpEstadisticas.Click
        Dim dsStats As DataSet = ObtenerDataSetEstadisticas()
        If dsStats Is Nothing OrElse dsStats.Tables.Count = 0 Then
            If dsStats IsNot Nothing Then dsStats.Dispose()
            MsgBox("No hay datos estadísticos para exportar. Por favor realice una consulta primero.", MsgBoxStyle.Information, "Estadísticas")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Try
            Dim informes As New Informes
            Dim totalOps As Integer = If(_dvAuditoria IsNot Nothing, _dvAuditoria.Count, 0)
            informes.expSoloEstadisticasAuditoria(dsStats, fecha_ini_aud.Value, fecha_fin_aud.Value, totalOps)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Auditoría de Operaciones (Exportar Estadísticas)", True, Me)
        Finally
            dsStats.Dispose()
            Cursor = Cursors.Default
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Function ObtenerDataSetEstadisticas() As DataSet
        Dim ds As New DataSet("EstadisticasAuditoria")
        If _dtStatOperacion IsNot Nothing Then ds.Tables.Add(_dtStatOperacion.Copy())
        If _dtStatSesion IsNot Nothing Then ds.Tables.Add(_dtStatSesion.Copy())
        If _dtStatPc IsNot Nothing Then ds.Tables.Add(_dtStatPc.Copy())
        If _dtStatTabla IsNot Nothing Then ds.Tables.Add(_dtStatTabla.Copy())
        If _dtStatFecha IsNot Nothing Then ds.Tables.Add(_dtStatFecha.Copy())
        Return ds
    End Function

    Private Sub btn_exp_pdf_aud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exp_pdf_aud.Click
        If grillaAuditoria.RowCount = 0 Then
            MsgBox("No hay registros visibles para exportar a PDF.", MsgBoxStyle.Exclamation, "Auditoría de Operaciones")
            Exit Sub
        End If

        Dim rutaPdf As String = Utilitarios.SolicitarRutaGuardadoPdf("Auditoria_Operaciones")
        If String.IsNullOrEmpty(rutaPdf) Then Exit Sub

        Dim subtitulo As String = String.Format("Período: {0} al {1}   |   Registros: {2:N0}",
                                                fecha_ini_aud.Value.ToString("dd-MM-yyyy"),
                                                fecha_fin_aud.Value.ToString("dd-MM-yyyy"),
                                                grillaAuditoria.RowCount)
        If Utilitarios.ExportarGrillaAPdf(grillaAuditoria, rutaPdf, "INFORME DE AUDITORÍA DE OPERACIONES", subtitulo) Then
            If MessageBox.Show("Archivo PDF generado exitosamente en:" & Environment.NewLine & rutaPdf & Environment.NewLine & Environment.NewLine & "¿Desea abrir el documento PDF ahora?", "Exportación PDF Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Utilitarios.AbrirDocumento(rutaPdf)
            End If
        Else
            MsgBox("No fue posible generar el archivo PDF.", MsgBoxStyle.Critical, "Exportar PDF")
        End If
    End Sub

    Private Sub btn_salir_aud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir_aud.Click
        Me.Close()
    End Sub
End Class
