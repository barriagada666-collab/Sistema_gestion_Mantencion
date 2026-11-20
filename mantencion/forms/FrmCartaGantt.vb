Public Class FrmCartaGantt
    Public form As String
    Public item_gantt As String

    Public Class RegistroCicloGantt
        Public Property IdMant As Integer
        Public Property IdCiclo As Integer
        Public Property IdNodo As Integer
        Public Property Seccion As String = String.Empty
        Public Property ItemMaquina As String = String.Empty
        Public Property TipoMp As String = String.Empty
        Public Property Estado As String = String.Empty
        Public Property Observacion As String = String.Empty
        Public Property FechaInicio As DateTime
        Public Property FechaTermino As DateTime
        Public Property Duracion As Double
    End Class

    Private _todosLosCiclos As New List(Of RegistroCicloGantt)()
    Private _registrosVisibles As New List(Of RegistroCicloGantt)()
    Private ReadOnly _cacheTareas As New Dictionary(Of String, DataTable)(StringComparer.Ordinal)
    Private _sincronizandoScroll As Boolean = False
    Private _sincronizandoSeleccion As Boolean = False
    Private _cargandoControles As Boolean = False
    Private _escalaDiaPx As Integer = 56
    Private _idNodoContexto As Integer = 1
    Private _fechaBaseDesde As DateTime = DateTime.Today
    Private _fechaBaseHasta As DateTime = DateTime.Today
    Private _ultimoTituloBase As String = "Carta Gantt de Mantención"

    Private Sub FrmCartaGantt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Dim informes As New Informes()

        Try
            grillaInfoGantt.SuspendLayout()
            grillaGraficoGantt.SuspendLayout()
            Utilitarios.HabilitarDobleBuffer(grillaInfoGantt)
            Utilitarios.HabilitarDobleBuffer(grillaGraficoGantt)
            Utilitarios.HabilitarDobleBuffer(dgvTareasCicloDetalle)

            Utilitarios.AplicarTemaModerno(Me)
            AplicarEstilosLeyendaYDetalle()
            ConfigurarOrdenColumnasInfo()
            Utilitarios.AsegurarColumnaSeleccionGantt(grillaInfoGantt)

            _cargandoControles = True
            cmbZoomGantt.Items.Clear()
            cmbZoomGantt.Items.Add("Compacta")
            cmbZoomGantt.Items.Add("Normal")
            cmbZoomGantt.Items.Add("Detallada")
            cmbZoomGantt.SelectedIndex = 1
            _escalaDiaPx = 56

            cmbFiltroEstado.Items.Clear()
            cmbFiltroEstado.Items.Add("Todos")
            cmbFiltroEstado.SelectedIndex = 0
            _cargandoControles = False

            If form = "FrmInfMantPrev" Then
                RecargarDesdeOrigen()
            ElseIf form = "FrmInfMantPrevCiclosMaq" Then
                RecargarDesdeOrigen()
            Else
                RecargarDesdeOrigen()
            End If

            AjustarProporcionSplitters()
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Carta Gantt", True, Me)
        Finally
            _cargandoControles = False
            grillaGraficoGantt.ResumeLayout(False)
            grillaInfoGantt.ResumeLayout(False)
            Me.ResumeLayout(True)
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Public Sub RecargarDesdeOrigen()
        Dim informes As New Informes()
        If form = "FrmInfMantPrev" Then
            _idNodoContexto = Math.Max(1, Utilitarios.SafeInt(FrmInfMantPrev.id_nodo_select, 1))
            _fechaBaseDesde = FrmInfMantPrev.f_ini_inf_mp.Value.Date
            _fechaBaseHasta = FrmInfMantPrev.f_fin_inf_mp.Value.Date
            lblDesdeGantt.Text = _fechaBaseDesde.ToString("dd-MM-yyyy")
            lblHastaGantt.Text = _fechaBaseHasta.ToString("dd-MM-yyyy")
            _ultimoTituloBase = If(Not String.IsNullOrEmpty(item_gantt), "Carta Gantt - " & item_gantt, "Carta Gantt - Mantención Preventiva")
            lblTituloGantt.Text = _ultimoTituloBase
            informes.CrgInfGanttCiclosMaq()
        ElseIf form = "FrmInfMantPrevCiclosMaq" Then
            _idNodoContexto = Math.Max(1, Utilitarios.SafeInt(FrmInfMantPrevCiclosMaq.id_nodo_mp_select, 1))
            _fechaBaseDesde = FrmInfMantPrevCiclosMaq.fecha_ini_inf_mp.Value.Date
            _fechaBaseHasta = FrmInfMantPrevCiclosMaq.fecha_fin_inf_mp.Value.Date
            lblDesdeGantt.Text = _fechaBaseDesde.ToString("dd-MM-yyyy")
            lblHastaGantt.Text = _fechaBaseHasta.ToString("dd-MM-yyyy")
            If FrmInfMantPrevCiclosMaq.Arbol7.SelectedNode IsNot Nothing Then
                _ultimoTituloBase = "Carta Gantt - " & FrmInfMantPrevCiclosMaq.Arbol7.SelectedNode.Text
            ElseIf Not String.IsNullOrEmpty(item_gantt) Then
                _ultimoTituloBase = "Carta Gantt - " & item_gantt
            Else
                _ultimoTituloBase = "Carta Gantt - Varias Máquinas"
            End If
            lblTituloGantt.Text = _ultimoTituloBase
            informes.CrgInfGanttCiclosVariasMaq()
        Else
            _idNodoContexto = 1
            _fechaBaseDesde = DateTime.Today.AddDays(-1)
            _fechaBaseHasta = DateTime.Today
            lblDesdeGantt.Text = _fechaBaseDesde.ToString("dd-MM-yyyy")
            lblHastaGantt.Text = _fechaBaseHasta.ToString("dd-MM-yyyy")
            lblTituloGantt.Text = _ultimoTituloBase
            LimpiarDetalleInferior()
        End If
    End Sub

    Private Sub FrmCartaGantt_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        AjustarProporcionSplitters()
        AjustarAnchosInfoGantt()
    End Sub

    Private Sub FrmCartaGantt_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
        If Not Me.IsHandleCreated OrElse Me.WindowState = FormWindowState.Minimized Then Exit Sub
        AjustarProporcionSplitters()
    End Sub

    Private Sub AplicarEstilosLeyendaYDetalle()
        lblKpiLeyPendiente.BackColor = Utilitarios.ColorPrimario
        lblKpiLeyPendiente.ForeColor = Color.White
        lblKpiLeyTerminado.BackColor = Color.FromArgb(21, 128, 61)
        lblKpiLeyTerminado.ForeColor = Color.White
        lblKpiLeyVencido.BackColor = Utilitarios.ColorGanttBarra
        lblKpiLeyVencido.ForeColor = Color.White

        pnlBodyGantt.BackColor = Utilitarios.ColorFondoForm
        pnlGanttTopArea.BackColor = Utilitarios.ColorFondoForm
        splitterMain.BackColor = Utilitarios.ColorBordeGrilla
        splitterDetalle.BackColor = Utilitarios.ColorBordeGrilla
        pnlDetalleMeta.BackColor = Utilitarios.ColorFilaAlterna
        lblDetalleCicloTitulo.BackColor = Utilitarios.ColorFilaAlterna
        lblDetalleCicloTitulo.ForeColor = Utilitarios.ColorDeepNavy
        lblDetalleObsCompleta.BackColor = Utilitarios.ColorFilaAlterna
        lblDetalleObsCompleta.ForeColor = Color.FromArgb(51, 65, 85)
        lblResumenGantt.ForeColor = Utilitarios.ColorPrimario
    End Sub

    Private Sub ConfigurarOrdenColumnasInfo()
        colIdMant.DisplayIndex = 0
        id_ciclo.DisplayIndex = 1
        colSeccion.DisplayIndex = 2
        item.DisplayIndex = 3
        colEstado.DisplayIndex = 4
        obs_ciclo.DisplayIndex = 5
        fecha_inicio.DisplayIndex = 6
        fecha_termino.DisplayIndex = 7
        duracion.DisplayIndex = 8
        colTipoMp.DisplayIndex = 9

        colIdMant.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        id_ciclo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colEstado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        duracion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colTipoMp.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub AjustarProporcionSplitters()
        Try
            Dim wTop As Integer = pnlGanttTopArea.ClientSize.Width
            If wTop > 540 Then
                Dim wLeft As Integer = Math.Max(320, Math.Min(wTop - 260, CInt(wTop * 0.56)))
                pnlGanttLeft.Width = wLeft
            End If
        Catch
        End Try
    End Sub

    Public Sub EstablecerDatosGantt(ByVal registros As List(Of RegistroCicloGantt), Optional ByVal idNodoContexto As Integer = 1)
        _todosLosCiclos = If(registros IsNot Nothing, registros, New List(Of RegistroCicloGantt)())
        If idNodoContexto > 0 Then _idNodoContexto = idNodoContexto
        _cacheTareas.Clear()

        _cargandoControles = True
        Try
            Dim selPrev As String = If(cmbFiltroEstado.SelectedItem IsNot Nothing, cmbFiltroEstado.SelectedItem.ToString(), "Todos")
            Dim estados As New SortedSet(Of String)(StringComparer.OrdinalIgnoreCase)
            For Each reg In _todosLosCiclos
                If Not String.IsNullOrWhiteSpace(reg.Estado) Then
                    estados.Add(reg.Estado.Trim())
                End If
            Next
            cmbFiltroEstado.Items.Clear()
            cmbFiltroEstado.Items.Add("Todos")
            For Each est As String In estados
                cmbFiltroEstado.Items.Add(est)
            Next
            If cmbFiltroEstado.Items.Contains(selPrev) Then
                cmbFiltroEstado.SelectedItem = selPrev
            Else
                cmbFiltroEstado.SelectedIndex = 0
            End If
        Finally
            _cargandoControles = False
        End Try

        AplicarFiltrosYRenderizar()
    End Sub

    Private Sub AplicarFiltrosYRenderizar()
        Dim idMantBuscado As String = If(txtBuscarNumMp.Text, String.Empty).Trim()
        Dim idCicloBuscado As String = If(txtBuscarIdCiclo.Text, String.Empty).Trim()
        Dim txtBuscado As String = If(txtBuscarGantt.Text, String.Empty).Trim()
        Dim estadoFiltro As String = If(cmbFiltroEstado.SelectedItem IsNot Nothing, cmbFiltroEstado.SelectedItem.ToString(), "Todos")

        Dim filtrados As New List(Of RegistroCicloGantt)(_todosLosCiclos.Count)
        For Each reg In _todosLosCiclos
            If Not String.IsNullOrEmpty(idMantBuscado) Then
                Dim idMInt As Integer
                If Integer.TryParse(idMantBuscado, idMInt) Then
                    If reg.IdMant <> idMInt Then Continue For
                ElseIf reg.IdMant.ToString().IndexOf(idMantBuscado, StringComparison.OrdinalIgnoreCase) < 0 Then
                    Continue For
                End If
            End If

            If Not String.IsNullOrEmpty(idCicloBuscado) Then
                Dim idCInt As Integer
                If Integer.TryParse(idCicloBuscado, idCInt) Then
                    If reg.IdCiclo <> idCInt Then Continue For
                ElseIf reg.IdCiclo.ToString().IndexOf(idCicloBuscado, StringComparison.OrdinalIgnoreCase) < 0 Then
                    Continue For
                End If
            End If

            If Not String.Equals(estadoFiltro, "Todos", StringComparison.OrdinalIgnoreCase) Then
                If Not String.Equals(If(reg.Estado, "").Trim(), estadoFiltro, StringComparison.OrdinalIgnoreCase) Then
                    Continue For
                End If
            End If

            If Not String.IsNullOrEmpty(txtBuscado) Then
                Dim coincideTexto As Boolean =
                    (reg.ItemMaquina.IndexOf(txtBuscado, StringComparison.OrdinalIgnoreCase) >= 0) OrElse
                    (reg.Seccion.IndexOf(txtBuscado, StringComparison.OrdinalIgnoreCase) >= 0) OrElse
                    (reg.Observacion.IndexOf(txtBuscado, StringComparison.OrdinalIgnoreCase) >= 0) OrElse
                    (reg.TipoMp.IndexOf(txtBuscado, StringComparison.OrdinalIgnoreCase) >= 0) OrElse
                    (reg.IdMant.ToString().IndexOf(txtBuscado, StringComparison.OrdinalIgnoreCase) >= 0) OrElse
                    (reg.IdCiclo.ToString().IndexOf(txtBuscado, StringComparison.OrdinalIgnoreCase) >= 0)
                If Not coincideTexto Then Continue For
            End If

            filtrados.Add(reg)
        Next

        RenderizarGrillas(filtrados)
    End Sub

    Private Sub RenderizarGrillas(ByVal lista As List(Of RegistroCicloGantt))
        _registrosVisibles = lista
        _sincronizandoSeleccion = True
        grillaInfoGantt.SuspendLayout()
        grillaGraficoGantt.SuspendLayout()

        Try
            grillaInfoGantt.Rows.Clear()
            grillaGraficoGantt.Rows.Clear()
            grillaGraficoGantt.Columns.Clear()

            If lista Is Nothing OrElse lista.Count = 0 Then
                lblResumenGantt.Text = String.Format("0 de {0} ciclos visibles", _todosLosCiclos.Count)
                LimpiarDetalleInferior()
                Exit Sub
            End If

            Dim fechaIni As DateTime = DateTime.MaxValue
            Dim fechaFin As DateTime = DateTime.MinValue
            Dim hrsTotales As Double = 0
            Dim pendCount As Integer = 0
            Dim termCount As Integer = 0
            Dim maquinasUnicas As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

            For Each reg In lista
                Dim d1 As DateTime = Utilitarios.SafeSqlDateTime(reg.FechaInicio).Date
                Dim d2 As DateTime = Utilitarios.SafeSqlDateTime(reg.FechaTermino).Date
                If d2 < d1 Then d2 = d1
                If d1 < fechaIni Then fechaIni = d1
                If d2 > fechaFin Then fechaFin = d2
                hrsTotales += reg.Duracion
                If Not String.IsNullOrWhiteSpace(reg.ItemMaquina) Then maquinasUnicas.Add(reg.ItemMaquina)
                If String.Equals(reg.Estado, "Terminado", StringComparison.OrdinalIgnoreCase) Then
                    termCount += 1
                Else
                    pendCount += 1
                End If
            Next

            If fechaIni = DateTime.MaxValue OrElse fechaFin = DateTime.MinValue OrElse fechaIni > fechaFin Then
                fechaIni = _fechaBaseDesde
                fechaFin = _fechaBaseHasta
            End If

            ' Resguarda rangos extremos para no saturar columnas de DataGridView (máx. 1100 días, priorizando los más recientes)
            Const maxDiasGantt As Integer = 1100
            If DateDiff(DateInterval.Day, fechaIni, fechaFin) > maxDiasGantt Then
                fechaIni = fechaFin.AddDays(-maxDiasGantt)
            End If

            lblDesdeGantt.Text = fechaIni.ToString("dd-MM-yyyy")
            lblHastaGantt.Text = fechaFin.ToString("dd-MM-yyyy")
            lblResumenGantt.Text = String.Format("{0} de {1} ciclos  ·  {2} máquinas  ·  {3:N1} hrs  ·  {4} Pend.  ·  {5} Term.",
                                                 lista.Count, _todosLosCiclos.Count, maquinasUnicas.Count, hrsTotales, pendCount, termCount)

            Dim colPorFecha As New Dictionary(Of DateTime, Integer)()
            Dim colsFds As New List(Of Integer)()
            Dim idxColHoy As Integer = -1
            Dim hoy As DateTime = DateTime.Today
            Dim diaCursor As DateTime = fechaIni
            Dim esCulture As New Globalization.CultureInfo("es-CL")
            Dim totalDiasCols As Integer = CInt(DateDiff(DateInterval.Day, fechaIni, fechaFin)) + 1
            Dim colsGantt As New List(Of DataGridViewColumn)(Math.Max(1, totalDiasCols))
            Dim fntCeldaGantt As New Font("Segoe UI", 8.0F, FontStyle.Bold)
            Dim fntEstado As New Font("Segoe UI", 8.5F, FontStyle.Bold)

            While diaCursor <= fechaFin
                Dim diaSem As String = ObtenerAbrevDia(diaCursor.DayOfWeek)
                Dim tituloCol As String = diaSem & Environment.NewLine & diaCursor.ToString("dd/MM/yy", esCulture)
                Dim colKey As String = diaCursor.ToString("yyyyMMdd")
                Dim colIdx As Integer = colsGantt.Count
                Dim colG As New DataGridViewTextBoxColumn With {
                    .Name = colKey,
                    .HeaderText = tituloCol,
                    .FillWeight = 1.0F,
                    .MinimumWidth = 10,
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    .Width = _escalaDiaPx,
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                }
                colG.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                colG.DefaultCellStyle.Font = fntCeldaGantt

                colsGantt.Add(colG)
                colPorFecha(diaCursor.Date) = colIdx
                If diaCursor.DayOfWeek = DayOfWeek.Saturday OrElse diaCursor.DayOfWeek = DayOfWeek.Sunday Then
                    colsFds.Add(colIdx)
                ElseIf diaCursor.Date = hoy Then
                    idxColHoy = colIdx
                End If
                diaCursor = diaCursor.AddDays(1)
            End While

            grillaGraficoGantt.Columns.AddRange(colsGantt.ToArray())

            Dim colorFds As Color = Utilitarios.ColorFondoSoloLectura
            Dim colorHoyFondo As Color = Color.FromArgb(254, 249, 195)
            Dim colorPendiente As Color = Utilitarios.ColorPrimario
            Dim colorTerminado As Color = Color.FromArgb(21, 128, 61)
            Dim colorVencido As Color = Utilitarios.ColorGanttBarra
            Dim colorFdsSel As Color = Color.FromArgb(160, 197, 207)

            For Each jFds As Integer In colsFds
                Dim cFds As DataGridViewColumn = grillaGraficoGantt.Columns(jFds)
                cFds.HeaderCell.Style.BackColor = Color.FromArgb(15, 45, 68)
                cFds.DefaultCellStyle.BackColor = colorFds
                cFds.DefaultCellStyle.SelectionBackColor = colorFdsSel
            Next
            If idxColHoy >= 0 AndAlso Not colsFds.Contains(idxColHoy) Then
                Dim cHoy As DataGridViewColumn = grillaGraficoGantt.Columns(idxColHoy)
                cHoy.HeaderCell.Style.BackColor = Utilitarios.ColorSecundario
                cHoy.DefaultCellStyle.BackColor = colorHoyFondo
            ElseIf idxColHoy >= 0 Then
                grillaGraficoGantt.Columns(idxColHoy).HeaderCell.Style.BackColor = Utilitarios.ColorSecundario
            End If

            For i As Integer = 0 To lista.Count - 1
                Dim reg As RegistroCicloGantt = lista(i)
                Dim rIdx As Integer = grillaInfoGantt.Rows.Add()
                Dim rowInfo As DataGridViewRow = grillaInfoGantt.Rows(rIdx)
                rowInfo.Height = 28

                rowInfo.Cells(0).Value = reg.IdCiclo
                rowInfo.Cells(1).Value = reg.ItemMaquina
                rowInfo.Cells(2).Value = reg.Observacion
                rowInfo.Cells(3).Value = FormatearFechaTabla(reg.FechaInicio)
                rowInfo.Cells(4).Value = FormatearFechaTabla(reg.FechaTermino)
                rowInfo.Cells(5).Value = If(reg.Duracion = Math.Truncate(reg.Duracion), reg.Duracion.ToString("N0"), reg.Duracion.ToString("N1"))
                rowInfo.Cells(6).Value = reg.IdMant
                rowInfo.Cells(7).Value = reg.Seccion
                rowInfo.Cells(8).Value = reg.Estado
                rowInfo.Cells(9).Value = reg.TipoMp
                rowInfo.Cells(10).Value = reg.IdNodo
                If grillaInfoGantt.Columns.Contains("colSelGantt") Then
                    rowInfo.Cells("colSelGantt").Value = False
                End If

                Dim esTerm As Boolean = String.Equals(reg.Estado, "Terminado", StringComparison.OrdinalIgnoreCase)
                Dim esVencido As Boolean = (Not esTerm) AndAlso (reg.FechaTermino.Date < hoy)
                Dim colorBarra As Color = If(esTerm, colorTerminado, If(esVencido, colorVencido, colorPendiente))

                rowInfo.Cells(8).Style.Font = fntEstado
                If esTerm Then
                    rowInfo.Cells(8).Style.ForeColor = colorTerminado
                ElseIf esVencido Then
                    rowInfo.Cells(8).Style.ForeColor = colorVencido
                Else
                    rowInfo.Cells(8).Style.ForeColor = Utilitarios.ColorPrimario
                End If

                Dim tipTexto As String = String.Format("MP #{0} · Ciclo #{1} ({2}){3}Sección: {4} | Máquina: {5}{3}Inicio: {6:dd-MM-yyyy HH:mm} | Término: {7:dd-MM-yyyy HH:mm} ({8:N1} hrs){3}Obs: {9}",
                                                       reg.IdMant, reg.IdCiclo, reg.Estado, Environment.NewLine,
                                                       reg.Seccion, reg.ItemMaquina, reg.FechaInicio, reg.FechaTermino, reg.Duracion, reg.Observacion)
                For Each cellInf As DataGridViewCell In rowInfo.Cells
                    cellInf.ToolTipText = tipTexto
                Next

                Dim rGrafIdx As Integer = grillaGraficoGantt.Rows.Add()
                Dim rowGraf As DataGridViewRow = grillaGraficoGantt.Rows(rGrafIdx)
                rowGraf.Height = 28

                Dim dStart As DateTime = Utilitarios.SafeSqlDateTime(reg.FechaInicio).Date
                Dim dEnd As DateTime = Utilitarios.SafeSqlDateTime(reg.FechaTermino).Date
                If dEnd < dStart Then dEnd = dStart

                If dEnd >= fechaIni AndAlso dStart <= fechaFin Then
                    Dim dCur As DateTime = If(dStart < fechaIni, fechaIni, dStart)
                    Dim dLim As DateTime = If(dEnd > fechaFin, fechaFin, dEnd)
                    While dCur <= dLim
                        Dim jBar As Integer
                        If colPorFecha.TryGetValue(dCur, jBar) Then
                            Dim celBar As DataGridViewCell = rowGraf.Cells(jBar)
                            celBar.Style.BackColor = colorBarra
                            celBar.Style.ForeColor = Color.White
                            celBar.Style.SelectionBackColor = colorBarra
                            celBar.Style.SelectionForeColor = Color.White
                            celBar.ToolTipText = tipTexto
                            celBar.Value = String.Empty
                        End If
                        dCur = dCur.AddDays(1)
                    End While
                End If
            Next

            AjustarAnchosInfoGantt()

            If grillaInfoGantt.RowCount > 0 Then
                grillaInfoGantt.ClearSelection()
                grillaInfoGantt.Rows(0).Selected = True
                grillaInfoGantt.CurrentCell = grillaInfoGantt.Rows(0).Cells(6)
                If grillaGraficoGantt.RowCount > 0 AndAlso grillaGraficoGantt.ColumnCount > 0 Then
                    grillaGraficoGantt.ClearSelection()
                    grillaGraficoGantt.Rows(0).Selected = True
                End If
                MostrarDetalleFila(0)
            End If
        Finally
            grillaGraficoGantt.ResumeLayout(False)
            grillaInfoGantt.ResumeLayout(False)
            _sincronizandoSeleccion = False
        End Try
    End Sub

    Private Shared Function ObtenerAbrevDia(ByVal d As DayOfWeek) As String
        Select Case d
            Case DayOfWeek.Monday : Return "Lu"
            Case DayOfWeek.Tuesday : Return "Ma"
            Case DayOfWeek.Wednesday : Return "Mi"
            Case DayOfWeek.Thursday : Return "Ju"
            Case DayOfWeek.Friday : Return "Vi"
            Case DayOfWeek.Saturday : Return "Sá"
            Case Else : Return "Do"
        End Select
    End Function

    Private Shared Function FormatearFechaTabla(ByVal dt As DateTime) As String
        If dt.TimeOfDay.TotalSeconds > 0 Then
            Return dt.ToString("dd-MM-yyyy HH:mm")
        End If
        Return dt.ToString("dd-MM-yyyy")
    End Function

    Private Sub AjustarAnchosInfoGantt()
        If grillaInfoGantt.Columns.Count = 0 Then Exit Sub
        Dim limitesMin As New Dictionary(Of String, Integer) From {
            {"colIdMant", 62}, {"id_ciclo", 62}, {"colSeccion", 110}, {"item", 145},
            {"colEstado", 82}, {"obs_ciclo", 160}, {"fecha_inicio", 115}, {"fecha_termino", 115},
            {"duracion", 82}, {"colTipoMp", 78}
        }
        Dim limitesMax As New Dictionary(Of String, Integer) From {
            {"colIdMant", 85}, {"id_ciclo", 85}, {"colSeccion", 200}, {"item", 260},
            {"colEstado", 110}, {"obs_ciclo", 280}, {"fecha_inicio", 145}, {"fecha_termino", 145},
            {"duracion", 105}, {"colTipoMp", 115}
        }
        For Each col As DataGridViewColumn In grillaInfoGantt.Columns
            If Not col.Visible Then Continue For
            If String.Equals(col.Name, "colSelGantt", StringComparison.OrdinalIgnoreCase) Then
                col.Width = 40
                col.DisplayIndex = 0
                Continue For
            End If
            Dim wPref As Integer = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, True)
            Dim wHdr As Integer = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, True)
            Dim wMin As Integer = If(limitesMin.ContainsKey(col.Name), limitesMin(col.Name), 70)
            Dim wMax As Integer = If(limitesMax.ContainsKey(col.Name), limitesMax(col.Name), 240)
            col.Width = Math.Max(wMin, Math.Min(wMax, Math.Max(wPref, wHdr) + 6))
        Next
    End Sub

    Private Sub LimpiarDetalleInferior()
        lblDetalleCicloTitulo.Text = "Sin ciclos coincidentes con el filtro actual."
        lblDetalleObsCompleta.Text = "Presione 'Buscar' con un N° de Mantención o ID de Ciclo para consultar en la base de datos o presione 'Limpiar'."
        dgvTareasCicloDetalle.DataSource = Nothing
    End Sub

    Private Sub MostrarDetalleFila(ByVal rowIdx As Integer)
        If rowIdx < 0 OrElse rowIdx >= _registrosVisibles.Count Then
            LimpiarDetalleInferior()
            Exit Sub
        End If

        Dim reg As RegistroCicloGantt = _registrosVisibles(rowIdx)
        lblDetalleCicloTitulo.Text = String.Format("MP #{0}  ·  Ciclo #{1}  ·  Estado: {2}  ·  Tipo: {3}  |  {4}  /  {5}  |  Del {6:dd-MM-yyyy HH:mm} al {7:dd-MM-yyyy HH:mm} ({8:N1} hrs)",
                                                   reg.IdMant, reg.IdCiclo,
                                                   If(String.IsNullOrWhiteSpace(reg.Estado), "-", reg.Estado),
                                                   If(String.IsNullOrWhiteSpace(reg.TipoMp), "-", reg.TipoMp),
                                                   If(String.IsNullOrWhiteSpace(reg.Seccion), "General", reg.Seccion),
                                                   reg.ItemMaquina,
                                                   reg.FechaInicio, reg.FechaTermino, reg.Duracion)
        lblDetalleObsCompleta.Text = "Observación: " & If(String.IsNullOrWhiteSpace(reg.Observacion), "(Sin observación registrada)", reg.Observacion)

        If reg.IdMant <= 0 OrElse reg.IdCiclo <= 0 Then
            dgvTareasCicloDetalle.DataSource = Nothing
            Exit Sub
        End If

        Dim key As String = reg.IdMant.ToString() & "|" & reg.IdCiclo.ToString() & "|" & reg.IdNodo.ToString()
        Dim dtTareas As DataTable = Nothing
        If Not _cacheTareas.TryGetValue(key, dtTareas) Then
            Dim mpSvc As New MantPreventiva()
            Dim ds As New DataSet()
            mpSvc.CrgTareasCicloMp(reg.IdMant.ToString(), reg.IdCiclo.ToString(), If(reg.IdNodo > 0, reg.IdNodo.ToString(), String.Empty), ds)
            If ds.Tables.Count > 0 Then
                dtTareas = ds.Tables(0)
            Else
                dtTareas = New DataTable()
            End If
            _cacheTareas(key) = dtTareas
        End If

        dgvTareasCicloDetalle.DataSource = dtTareas
        FormatoGrillas.AplicarEstiloModerno(dgvTareasCicloDetalle)
        Utilitarios.AjustarColumnasGrilla(dgvTareasCicloDetalle)
    End Sub

    Private Sub EnfocarBarraHorizontalCiclo(ByVal rowIdx As Integer)
        If rowIdx < 0 OrElse rowIdx >= _registrosVisibles.Count OrElse grillaGraficoGantt.ColumnCount = 0 Then Exit Sub
        Dim claveCol As String = _registrosVisibles(rowIdx).FechaInicio.ToString("yyyyMMdd")
        If grillaGraficoGantt.Columns.Contains(claveCol) Then
            Dim cIdx As Integer = grillaGraficoGantt.Columns(claveCol).Index
            If cIdx >= 0 AndAlso cIdx < grillaGraficoGantt.ColumnCount Then
                Try
                    grillaGraficoGantt.FirstDisplayedScrollingColumnIndex = Math.Max(0, cIdx - 1)
                Catch
                End Try
            End If
        End If
    End Sub

    Private Sub SincronizarSeleccionDesdeInfo(ByVal rowIdx As Integer)
        If _sincronizandoSeleccion OrElse rowIdx < 0 OrElse rowIdx >= grillaInfoGantt.RowCount Then Exit Sub
        _sincronizandoSeleccion = True
        Try
            If rowIdx < grillaGraficoGantt.RowCount Then
                grillaGraficoGantt.ClearSelection()
                grillaGraficoGantt.Rows(rowIdx).Selected = True
                If grillaGraficoGantt.ColumnCount > 0 Then
                    grillaGraficoGantt.CurrentCell = grillaGraficoGantt.Rows(rowIdx).Cells(0)
                End If
                EnfocarBarraHorizontalCiclo(rowIdx)
            End If
            MostrarDetalleFila(rowIdx)
        Finally
            _sincronizandoSeleccion = False
        End Try
    End Sub

    Private Sub SincronizarSeleccionDesdeGrafico(ByVal rowIdx As Integer)
        If _sincronizandoSeleccion OrElse rowIdx < 0 OrElse rowIdx >= grillaGraficoGantt.RowCount Then Exit Sub
        _sincronizandoSeleccion = True
        Try
            If rowIdx < grillaInfoGantt.RowCount Then
                grillaInfoGantt.ClearSelection()
                grillaInfoGantt.Rows(rowIdx).Selected = True
                grillaInfoGantt.CurrentCell = grillaInfoGantt.Rows(rowIdx).Cells(6)
            End If
            MostrarDetalleFila(rowIdx)
        Finally
            _sincronizandoSeleccion = False
        End Try
    End Sub

    Private Sub grillaInfoGantt_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grillaInfoGantt.SelectionChanged
        If _sincronizandoSeleccion OrElse grillaInfoGantt.CurrentRow Is Nothing Then Exit Sub
        SincronizarSeleccionDesdeInfo(grillaInfoGantt.CurrentRow.Index)
    End Sub

    Private Sub grillaGraficoGantt_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grillaGraficoGantt.SelectionChanged
        If _sincronizandoSeleccion OrElse grillaGraficoGantt.CurrentRow Is Nothing Then Exit Sub
        SincronizarSeleccionDesdeGrafico(grillaGraficoGantt.CurrentRow.Index)
    End Sub

    Private Sub grillaInfoGantt_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles grillaInfoGantt.Scroll
        If _sincronizandoScroll OrElse e.ScrollOrientation <> ScrollOrientation.VerticalScroll Then Exit Sub
        _sincronizandoScroll = True
        Try
            If e.NewValue >= 0 AndAlso e.NewValue < grillaGraficoGantt.RowCount Then
                grillaGraficoGantt.FirstDisplayedScrollingRowIndex = e.NewValue
            End If
        Catch
        Finally
            _sincronizandoScroll = False
        End Try
    End Sub

    Private Sub grillaGraficoGantt_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles grillaGraficoGantt.Scroll
        If _sincronizandoScroll OrElse e.ScrollOrientation <> ScrollOrientation.VerticalScroll Then Exit Sub
        _sincronizandoScroll = True
        Try
            If e.NewValue >= 0 AndAlso e.NewValue < grillaInfoGantt.RowCount Then
                grillaInfoGantt.FirstDisplayedScrollingRowIndex = e.NewValue
            End If
        Catch
        Finally
            _sincronizandoScroll = False
        End Try
    End Sub

    Private Sub txtBuscarNumMp_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtBuscarNumMp.TextChanged
        If _cargandoControles Then Exit Sub
        AplicarFiltrosYRenderizar()
    End Sub

    Private Sub txtBuscarIdCiclo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtBuscarIdCiclo.TextChanged
        If _cargandoControles Then Exit Sub
        AplicarFiltrosYRenderizar()
    End Sub

    Private Sub txtBuscarGantt_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtBuscarGantt.TextChanged
        If _cargandoControles Then Exit Sub
        AplicarFiltrosYRenderizar()
    End Sub

    Private Sub cmbFiltroEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFiltroEstado.SelectedIndexChanged
        If _cargandoControles Then Exit Sub
        AplicarFiltrosYRenderizar()
    End Sub

    Private Sub cmbZoomGantt_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbZoomGantt.SelectedIndexChanged
        If _cargandoControles Then Exit Sub
        Select Case cmbZoomGantt.SelectedIndex
            Case 0 : _escalaDiaPx = 38
            Case 2 : _escalaDiaPx = 82
            Case Else : _escalaDiaPx = 56
        End Select
        grillaGraficoGantt.SuspendLayout()
        Try
            For Each col As DataGridViewColumn In grillaGraficoGantt.Columns
                col.Width = _escalaDiaPx
            Next
        Finally
            grillaGraficoGantt.ResumeLayout(False)
        End Try
    End Sub

    Private Sub Filtros_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtBuscarNumMp.KeyDown, txtBuscarIdCiclo.KeyDown, txtBuscarGantt.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            EjecutarBusquedaConRespaldoBd()
        End If
    End Sub

    Private Sub SoloDigitos_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtBuscarNumMp.KeyPress, txtBuscarIdCiclo.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnBuscarGantt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarGantt.Click
        EjecutarBusquedaConRespaldoBd()
    End Sub

    Public Sub EjecutarBusquedaConRespaldoBd()
        AplicarFiltrosYRenderizar()

        Dim idM As Integer = Utilitarios.SafeInt(txtBuscarNumMp.Text, 0)
        Dim idC As Integer = Utilitarios.SafeInt(txtBuscarIdCiclo.Text, 0)
        If (idM > 0 OrElse idC > 0) AndAlso _registrosVisibles.Count = 0 Then
            Cursor = Cursors.WaitCursor
            Try
                Dim mpSvc As New MantPreventiva()
                Dim dtBd As DataTable = mpSvc.CrgDatosGanttDetallado(_idNodoContexto, _fechaBaseDesde, _fechaBaseHasta, String.Empty, idM, idC, True)

                If dtBd IsNot Nothing AndAlso dtBd.Rows.Count > 0 Then
                    Dim nuevos As List(Of RegistroCicloGantt) = Informes.ConvertirTablaARegistrosGantt(dtBd)
                    lblTituloGantt.Text = _ultimoTituloBase & "  (Consulta directa en BD)"
                    EstablecerDatosGantt(nuevos, _idNodoContexto)
                Else
                    MessageBox.Show(Me, "No se encontraron ciclos para el N° de Mantención / ID de Ciclo especificado.", "Búsqueda Carta Gantt", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub btnLimpiarGantt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLimpiarGantt.Click
        _cargandoControles = True
        Try
            txtBuscarNumMp.Clear()
            txtBuscarIdCiclo.Clear()
            txtBuscarGantt.Clear()
            If cmbFiltroEstado.Items.Count > 0 Then cmbFiltroEstado.SelectedIndex = 0
        Finally
            _cargandoControles = False
        End Try

        lblTituloGantt.Text = _ultimoTituloBase
        If form = "FrmInfMantPrevCiclosMaq" Then
            Dim inf As New Informes()
            inf.CrgInfGanttCiclosVariasMaq()
        ElseIf form = "FrmInfMantPrev" Then
            Dim inf As New Informes()
            inf.CrgInfGanttCiclosMaq()
        Else
            AplicarFiltrosYRenderizar()
        End If
    End Sub

    Private Sub btnToggleDetalle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnToggleDetalle.Click
        Dim mostrar As Boolean = Not pnlCardDetalleGantt.Visible
        pnlCardDetalleGantt.Visible = mostrar
        splitterDetalle.Visible = mostrar
        btnToggleDetalle.Text = If(mostrar, "Ocultar Detalle", "Ver Detalle")
    End Sub

    Private Sub btnFiltrarMarcados_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFiltrarMarcados.Click
        Dim marcados As List(Of DataGridViewRow) = Utilitarios.ObtenerFilasMarcadas(grillaInfoGantt)
        If marcados.Count = 0 Then
            MessageBox.Show(Me, "Marque uno o más ciclos en la columna 'Sel.' (por ejemplo: 8, 7, 6, 5) para filtrar o exportar únicamente esos ciclos.", "Selección de Ciclos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim filtrados As New List(Of RegistroCicloGantt)(marcados.Count)
        For Each r As DataGridViewRow In marcados
            If r.Index >= 0 AndAlso r.Index < _registrosVisibles.Count Then
                filtrados.Add(_registrosVisibles(r.Index))
            End If
        Next
        If filtrados.Count > 0 Then
            RenderizarGrillas(filtrados)
        End If
    End Sub

    Public Function ObtenerRegistrosVisiblesParaExportar() As List(Of RegistroCicloGantt)
        Dim marcados As List(Of DataGridViewRow) = Utilitarios.ObtenerFilasMarcadas(grillaInfoGantt)
        If marcados.Count > 0 Then
            Dim listaSel As New List(Of RegistroCicloGantt)(marcados.Count)
            For Each r As DataGridViewRow In marcados
                If r.Index >= 0 AndAlso r.Index < _registrosVisibles.Count Then
                    listaSel.Add(_registrosVisibles(r.Index))
                End If
            Next
            If listaSel.Count > 0 Then Return listaSel
        End If
        If _registrosVisibles IsNot Nothing AndAlso _registrosVisibles.Count > 0 Then
            Return New List(Of RegistroCicloGantt)(_registrosVisibles)
        End If
        Return New List(Of RegistroCicloGantt)()
    End Function

    Private Sub btnExpPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpPdf.Click
        Dim registros As List(Of RegistroCicloGantt) = ObtenerRegistrosVisiblesParaExportar()
        If registros.Count = 0 OrElse grillaInfoGantt.RowCount = 0 Then
            MsgBox("Debe buscar los ciclos antes de exportar a PDF.", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Dim sufijo As String = If(String.IsNullOrWhiteSpace(item_gantt), "Gantt", item_gantt)
        Dim rutaPdf As String = Utilitarios.SolicitarRutaGuardadoPdf("Informe_Gantt_" & sufijo)
        If String.IsNullOrEmpty(rutaPdf) Then Exit Sub

        Try
            Dim informes As New Informes()
            Dim infoMp As DataGridView = If(form = "FrmInfMantPrev", FrmInfMantPrev.grillaInfMant, Nothing)
            informes.ExportarCartaGanttPdf(registros, infoMp, item_gantt, lblDesdeGantt.Text, lblHastaGantt.Text, rutaPdf, False)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Carta Gantt (Exportar PDF)", True, Me)
        End Try
    End Sub

    Private Sub btnExpExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpExcel.Click
        Dim registros As List(Of RegistroCicloGantt) = ObtenerRegistrosVisiblesParaExportar()
        If registros.Count = 0 OrElse grillaInfoGantt.RowCount = 0 OrElse grillaGraficoGantt.RowCount = 0 Then
            MsgBox("Debe buscar los ciclos antes de exportar a Excel.", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Try
            Dim informes As New Informes()
            Dim infoMp As DataGridView = If(form = "FrmInfMantPrev", FrmInfMantPrev.grillaInfMant, Nothing)
            informes.ExportarCartaGanttExcel(registros, infoMp, item_gantt, lblDesdeGantt.Text, lblHastaGantt.Text, False)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Carta Gantt (Exportar Excel)", True, Me)
        End Try
    End Sub

    Private Sub btnSalirGantt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirGantt.Click
        Me.Close()
    End Sub
End Class
