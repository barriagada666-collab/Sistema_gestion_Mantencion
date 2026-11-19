Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class Informes
    Public Shared Function ConvertirTablaARegistrosGantt(ByVal dt As DataTable) As List(Of FrmCartaGantt.RegistroCicloGantt)
        Dim lista As New List(Of FrmCartaGantt.RegistroCicloGantt)()
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return lista

        For Each r As DataRow In dt.Rows
            Dim reg As New FrmCartaGantt.RegistroCicloGantt()
            reg.IdMant = Utilitarios.SafeInt(r("id_mant"), 0)
            reg.IdCiclo = Utilitarios.SafeInt(r("id_ciclo"), 0)
            reg.IdNodo = Utilitarios.SafeInt(r("id_nodo"), 0)
            reg.Seccion = Convert.ToString(r("seccion")).Trim()
            reg.ItemMaquina = Convert.ToString(r("item_maquina")).Trim()
            reg.TipoMp = Convert.ToString(r("tipo_mp")).Trim()
            reg.Estado = Convert.ToString(r("estado_ciclo")).Trim()
            reg.Observacion = Convert.ToString(r("obs_ciclo")).Trim()
            reg.Duracion = Utilitarios.SafeDouble(r("duracion"), 0.0)

            Dim fIni As DateTime = Utilitarios.ObtenerFechaSegura(r("fecha_inicio")).Date
            Dim hIni As DateTime
            If Not IsDBNull(r("hora_inicio")) AndAlso DateTime.TryParse(Convert.ToString(r("hora_inicio")), hIni) Then
                fIni = fIni.Add(hIni.TimeOfDay)
            End If
            Dim fFin As DateTime = Utilitarios.ObtenerFechaSegura(r("fecha_termino"), fIni).Date
            Dim hFin As DateTime
            If Not IsDBNull(r("hora_termino")) AndAlso DateTime.TryParse(Convert.ToString(r("hora_termino")), hFin) Then
                fFin = fFin.Add(hFin.TimeOfDay)
            End If
            reg.FechaInicio = fIni
            reg.FechaTermino = If(fFin < fIni.Date, fIni, fFin)
            lista.Add(reg)
        Next
        Return lista
    End Function

    Public Sub CrgInfGanttCiclosMaq()
        With FrmInfMantPrev
            If .grillaDetalleCicloMp.RowCount = 0 Then Return

            Dim idMantSel As Integer = If(.grillaInfMant.CurrentRow IsNot Nothing, Utilitarios.SafeInt(.grillaInfMant.CurrentRow.Cells(0).Value, 0), 0)
            Dim tipoSel As String = If(.grillaInfMant.CurrentRow IsNot Nothing AndAlso .grillaInfMant.Columns.Count > 5, Convert.ToString(.grillaInfMant.CurrentRow.Cells(5).Value).Trim(), String.Empty)
            Dim idNodoSel As Integer = Math.Max(1, Utilitarios.SafeInt(.id_nodo_select, 1))
            Dim seccionSel As String = If(.Arbol2.SelectedNode IsNot Nothing AndAlso .Arbol2.SelectedNode.Parent IsNot Nothing, .Arbol2.SelectedNode.Parent.Text, String.Empty)

            Dim soloSel As Boolean = (.chkSoloCicloGantt IsNot Nothing AndAlso .chkSoloCicloGantt.Checked)
            Dim filasOrigen As List(Of DataGridViewRow) = Utilitarios.ObtenerFilasMarcadasOSeleccionadas(.grillaDetalleCicloMp, soloSel)

            Dim lista As New List(Of FrmCartaGantt.RegistroCicloGantt)(filasOrigen.Count)
            For Each rowG As DataGridViewRow In filasOrigen
                Dim reg As New FrmCartaGantt.RegistroCicloGantt()
                reg.IdMant = idMantSel
                reg.IdCiclo = Utilitarios.SafeInt(rowG.Cells(0).Value, 0)
                reg.IdNodo = idNodoSel
                reg.Seccion = seccionSel
                reg.ItemMaquina = .nombre_nodo_select
                reg.TipoMp = tipoSel
                reg.FechaInicio = Utilitarios.ObtenerFechaSegura(rowG.Cells(1).Value)
                reg.FechaTermino = Utilitarios.ObtenerFechaSegura(rowG.Cells(2).Value, reg.FechaInicio)
                reg.Duracion = Utilitarios.SafeDouble(rowG.Cells(3).Value, 0.0)
                reg.Observacion = Convert.ToString(rowG.Cells(4).Value).Trim()
                reg.Estado = If(rowG.Cells.Count > 5, Convert.ToString(rowG.Cells(5).Value).Trim(), String.Empty)
                lista.Add(reg)
            Next
            FrmCartaGantt.EstablecerDatosGantt(lista, idNodoSel)
        End With
    End Sub

    Public Sub CrgInfGanttCiclosVariasMaq()
        With FrmInfMantPrevCiclosMaq
            Dim idPadre As Integer = Math.Max(1, Utilitarios.SafeInt(.id_nodo_mp_select, 1))
            Dim soloSel As Boolean = (.chkSoloCicloGantt IsNot Nothing AndAlso .chkSoloCicloGantt.Checked)

            Dim filasSel As List(Of DataGridViewRow) = Utilitarios.ObtenerFilasMarcadas(.grillaCiclosMaquinas)
            If filasSel.Count = 0 AndAlso soloSel AndAlso .grillaCiclosMaquinas.RowCount > 0 Then
                filasSel = Utilitarios.ObtenerFilasMarcadasOSeleccionadas(.grillaCiclosMaquinas, True)
            End If

            Dim filtrarSeleccion As Boolean = (filasSel.Count > 0)
            Dim filtrosSel As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
            For Each rowG As DataGridViewRow In filasSel
                Dim idCicSel As Integer = Utilitarios.SafeInt(rowG.Cells(0).Value, 0)
                Dim idMpSel As Integer = If(rowG.Cells.Count > 7, Utilitarios.SafeInt(rowG.Cells(7).Value, 0), 0)
                Dim maqSel As String = Convert.ToString(rowG.Cells(2).Value).Trim()
                filtrosSel.Add(String.Format("{0}|{1}|{2}", idMpSel, idCicSel, maqSel))
            Next

            Dim mpSvc As New MantPreventiva()
            Dim dt As DataTable = mpSvc.CrgDatosGanttDetallado(idPadre, .fecha_ini_inf_mp.Value, .fecha_fin_inf_mp.Value, .cmbTipoMpGantt.Text)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim listaDet As List(Of FrmCartaGantt.RegistroCicloGantt) = ConvertirTablaARegistrosGantt(dt)
                If filtrarSeleccion AndAlso filtrosSel.Count > 0 Then
                    Dim listaFiltrada As New List(Of FrmCartaGantt.RegistroCicloGantt)()
                    For Each reg In listaDet
                        Dim keyExact As String = String.Format("{0}|{1}|{2}", reg.IdMant, reg.IdCiclo, reg.ItemMaquina)
                        Dim keySinMp As String = String.Format("0|{0}|{1}", reg.IdCiclo, reg.ItemMaquina)
                        If filtrosSel.Contains(keyExact) OrElse filtrosSel.Contains(keySinMp) Then
                            listaFiltrada.Add(reg)
                        End If
                    Next
                    If listaFiltrada.Count > 0 Then listaDet = listaFiltrada
                End If
                FrmCartaGantt.EstablecerDatosGantt(listaDet, idPadre)
                Return
            End If

            If .grillaCiclosMaquinas.RowCount = 0 Then Return
            Dim filasFallback As List(Of DataGridViewRow) = If(filtrarSeleccion, filasSel, Utilitarios.ObtenerFilasMarcadasOSeleccionadas(.grillaCiclosMaquinas, soloSel))
            Dim lista As New List(Of FrmCartaGantt.RegistroCicloGantt)(filasFallback.Count)
            For Each rowG As DataGridViewRow In filasFallback
                If rowG.IsNewRow Then Continue For
                Dim reg As New FrmCartaGantt.RegistroCicloGantt()
                reg.IdCiclo = Utilitarios.SafeInt(rowG.Cells(0).Value, 0)
                reg.Seccion = Convert.ToString(rowG.Cells(1).Value).Trim()
                reg.ItemMaquina = Convert.ToString(rowG.Cells(2).Value).Trim()
                reg.Observacion = Convert.ToString(rowG.Cells(3).Value).Trim()
                reg.FechaInicio = Utilitarios.ObtenerFechaSegura(rowG.Cells(4).Value)
                reg.FechaTermino = Utilitarios.ObtenerFechaSegura(rowG.Cells(5).Value, reg.FechaInicio)
                reg.Duracion = Utilitarios.SafeDouble(rowG.Cells(6).Value, 0.0)
                reg.IdMant = If(rowG.Cells.Count > 7, Utilitarios.SafeInt(rowG.Cells(7).Value, 0), 0)
                reg.Estado = If(rowG.Cells.Count > 8, Convert.ToString(rowG.Cells(8).Value).Trim(), String.Empty)
                reg.TipoMp = If(rowG.Cells.Count > 9, Convert.ToString(rowG.Cells(9).Value).Trim(), .cmbTipoMpGantt.Text)
                lista.Add(reg)
            Next
            FrmCartaGantt.EstablecerDatosGantt(lista, idPadre)
        End With
    End Sub

    Private Shared Function ObtenerLetraColumnaExcel(ByVal colNum As Integer) As String
        Dim dividend As Integer = Math.Max(1, colNum)
        Dim colName As String = String.Empty
        While dividend > 0
            Dim modulo As Integer = (dividend - 1) Mod 26
            colName = ChrW(65 + modulo) & colName
            dividend = CInt((dividend - modulo) \ 26)
        End While
        Return colName
    End Function

    Private Shared Function ColorOleDesdeEstado(ByVal estado As String, ByVal fechaTermino As DateTime) As Integer
        If String.Equals(If(estado, "").Trim(), "Terminado", StringComparison.OrdinalIgnoreCase) Then
            Return System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(21, 128, 61))
        ElseIf fechaTermino.Date < DateTime.Today Then
            Return System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(220, 38, 38))
        Else
            Return System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(2, 94, 135))
        End If
    End Function

    Private Shared Function ConvertirGrillasARegistrosGantt(ByVal grilla_ciclos_mp As DataGridView, ByVal info_mp As DataGridView, ByVal itemDefecto As String) As List(Of FrmCartaGantt.RegistroCicloGantt)
        Dim lista As New List(Of FrmCartaGantt.RegistroCicloGantt)()
        If grilla_ciclos_mp Is Nothing OrElse grilla_ciclos_mp.RowCount = 0 Then Return lista

        Dim cols As DataGridViewColumnCollection = grilla_ciclos_mp.Columns
        Dim idMantCab As Integer = If(info_mp IsNot Nothing AndAlso info_mp.CurrentRow IsNot Nothing, Utilitarios.SafeInt(info_mp.CurrentRow.Cells(0).Value, 0), 0)
        Dim tipoCab As String = If(info_mp IsNot Nothing AndAlso info_mp.CurrentRow IsNot Nothing AndAlso info_mp.Columns.Count > 5, Convert.ToString(info_mp.CurrentRow.Cells(5).Value).Trim(), String.Empty)

        Dim idxIdCiclo As Integer = If(cols.Contains("id_ciclo"), cols("id_ciclo").Index, 0)
        Dim idxItem As Integer = If(cols.Contains("item"), cols("item").Index, If(cols.Count > 1, 1, -1))
        Dim idxObs As Integer = If(cols.Contains("obs_ciclo"), cols("obs_ciclo").Index, If(cols.Count > 2, 2, -1))
        Dim idxFIni As Integer = If(cols.Contains("fecha_inicio"), cols("fecha_inicio").Index, If(cols.Count > 3, 3, 1))
        Dim idxFFin As Integer = If(cols.Contains("fecha_termino"), cols("fecha_termino").Index, Math.Min(cols.Count - 1, idxFIni + 1))
        Dim idxDur As Integer = If(cols.Contains("duracion"), cols("duracion").Index, If(cols.Count > 5, 5, -1))
        Dim idxIdMant As Integer = If(cols.Contains("colIdMant"), cols("colIdMant").Index, -1)
        Dim idxSec As Integer = If(cols.Contains("colSeccion"), cols("colSeccion").Index, -1)
        Dim idxEst As Integer = If(cols.Contains("colEstado"), cols("colEstado").Index, -1)
        Dim idxTipo As Integer = If(cols.Contains("colTipoMp"), cols("colTipoMp").Index, -1)

        For Each rowG As DataGridViewRow In grilla_ciclos_mp.Rows
            If rowG.IsNewRow Then Continue For
            Dim reg As New FrmCartaGantt.RegistroCicloGantt()
            reg.IdCiclo = Utilitarios.SafeInt(rowG.Cells(idxIdCiclo).Value, 0)
            reg.IdMant = If(idxIdMant >= 0, Utilitarios.SafeInt(rowG.Cells(idxIdMant).Value, idMantCab), idMantCab)
            reg.Seccion = If(idxSec >= 0, Convert.ToString(rowG.Cells(idxSec).Value).Trim(), String.Empty)
            reg.ItemMaquina = If(idxItem >= 0 AndAlso Not IsDate(rowG.Cells(idxItem).Value), Convert.ToString(rowG.Cells(idxItem).Value).Trim(), itemDefecto)
            If String.IsNullOrWhiteSpace(reg.ItemMaquina) Then reg.ItemMaquina = itemDefecto
            reg.Observacion = If(idxObs >= 0, Convert.ToString(rowG.Cells(idxObs).Value).Trim(), String.Empty)
            reg.FechaInicio = Utilitarios.ObtenerFechaSegura(rowG.Cells(idxFIni).Value)
            reg.FechaTermino = Utilitarios.ObtenerFechaSegura(rowG.Cells(idxFFin).Value, reg.FechaInicio)
            If reg.FechaTermino < reg.FechaInicio Then reg.FechaTermino = reg.FechaInicio
            reg.Duracion = If(idxDur >= 0, Utilitarios.SafeDouble(rowG.Cells(idxDur).Value, 0.0), 0.0)
            reg.Estado = If(idxEst >= 0, Convert.ToString(rowG.Cells(idxEst).Value).Trim(), String.Empty)
            reg.TipoMp = If(idxTipo >= 0, Convert.ToString(rowG.Cells(idxTipo).Value).Trim(), tipoCab)
            lista.Add(reg)
        Next
        Return lista
    End Function

    Private Shared Sub ResolverCabeceraMpParaGantt(ByVal registros As List(Of FrmCartaGantt.RegistroCicloGantt),
                                                  ByVal grilla_info_mp As DataGridView,
                                                  ByVal itemTitulo As String,
                                                  ByRef idMantUnico As Integer,
                                                  ByRef esModoUnaMp As Boolean,
                                                  ByRef itemNombre As String,
                                                  ByRef idMpTexto As String,
                                                  ByRef frecuenciaTexto As String,
                                                  ByRef tiempoAvisoTexto As String,
                                                  ByRef fechaCreacionTexto As String,
                                                  ByRef tipoTexto As String,
                                                  ByRef estadoTexto As String)
        Dim mpsDistintos As New HashSet(Of Integer)()
        Dim maquinasDistintas As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each r In registros
            If r.IdMant > 0 Then mpsDistintos.Add(r.IdMant)
            If Not String.IsNullOrWhiteSpace(r.ItemMaquina) Then maquinasDistintas.Add(r.ItemMaquina.Trim())
        Next

        idMantUnico = If(mpsDistintos.Count = 1, mpsDistintos.First(), 0)
        esModoUnaMp = (idMantUnico > 0 AndAlso maquinasDistintas.Count <= 1)

        If esModoUnaMp Then
            Dim filaGrilla As DataGridViewRow = Nothing
            If grilla_info_mp IsNot Nothing AndAlso grilla_info_mp.CurrentRow IsNot Nothing Then
                Dim idGrilla As Integer = Utilitarios.SafeInt(grilla_info_mp.CurrentRow.Cells(0).Value, 0)
                If idGrilla = idMantUnico Then filaGrilla = grilla_info_mp.CurrentRow
            End If

            If filaGrilla IsNot Nothing Then
                itemNombre = If(String.IsNullOrWhiteSpace(itemTitulo), If(maquinasDistintas.Count > 0, maquinasDistintas.First(), "Máquina"), itemTitulo)
                idMpTexto = Convert.ToString(filaGrilla.Cells(0).Value).Trim()
                frecuenciaTexto = Convert.ToString(filaGrilla.Cells(1).Value).Trim() & " Hrs"
                tiempoAvisoTexto = Convert.ToString(filaGrilla.Cells(2).Value).Trim() & " Hrs"
                estadoTexto = Convert.ToString(filaGrilla.Cells(3).Value).Trim()
                fechaCreacionTexto = Utilitarios.ObtenerFechaSegura(filaGrilla.Cells(4).Value).ToString("dd-MM-yyyy")
                tipoTexto = Convert.ToString(filaGrilla.Cells(5).Value).Trim()
            Else
                Dim mpSvc As New MantPreventiva()
                Dim dr As DataRow = mpSvc.ObtenerCabeceraMp(idMantUnico)
                If dr IsNot Nothing Then
                    itemNombre = Convert.ToString(dr("desc_nodo")).Trim()
                    If String.IsNullOrWhiteSpace(itemNombre) Then itemNombre = itemTitulo
                    idMpTexto = Convert.ToString(dr("idmant")).Trim()
                    frecuenciaTexto = Convert.ToString(dr("frecuencia")).Trim() & " Hrs"
                    tiempoAvisoTexto = Convert.ToString(dr("tiempo_aviso")).Trim() & " Hrs"
                    estadoTexto = Convert.ToString(dr("estado")).Trim()
                    fechaCreacionTexto = Utilitarios.ObtenerFechaSegura(dr("fecha_creacion")).ToString("dd-MM-yyyy")
                    tipoTexto = Convert.ToString(dr("tipo_mantencion")).Trim()
                Else
                    itemNombre = If(String.IsNullOrWhiteSpace(itemTitulo), If(maquinasDistintas.Count > 0, maquinasDistintas.First(), "-"), itemTitulo)
                    idMpTexto = idMantUnico.ToString()
                    frecuenciaTexto = "-"
                    tiempoAvisoTexto = "-"
                    estadoTexto = "-"
                    fechaCreacionTexto = "-"
                    tipoTexto = If(String.IsNullOrWhiteSpace(registros(0).TipoMp), "-", registros(0).TipoMp)
                End If
            End If
        Else
            Dim hrsTot As Double = 0
            For Each r In registros
                hrsTot += r.Duracion
            Next
            itemNombre = If(String.IsNullOrWhiteSpace(itemTitulo), "Varios Equipos", itemTitulo)
            idMpTexto = If(mpsDistintos.Count > 0, String.Format("Varios ({0} MPs)", mpsDistintos.Count), "General")
            frecuenciaTexto = String.Format("{0} ciclos", registros.Count)
            tiempoAvisoTexto = String.Format("{0:N1} Hrs", hrsTot)
            estadoTexto = If(maquinasDistintas.Count = 1, "1 equipo", String.Format("{0} equipos", maquinasDistintas.Count))
            fechaCreacionTexto = DateTime.Today.ToString("dd-MM-yyyy")
            tipoTexto = "Consolidado"
        End If
    End Sub

    Private Shared Function ConstruirTablaGanttPlana(ByVal registros As List(Of FrmCartaGantt.RegistroCicloGantt)) As DataTable
        Dim dt As New DataTable("InformeGantt")
        dt.Columns.Add("N° MP")
        dt.Columns.Add("ID Ciclo")
        dt.Columns.Add("Sección")
        dt.Columns.Add("Item / Máquina")
        dt.Columns.Add("Estado")
        dt.Columns.Add("Observación Ciclo")
        dt.Columns.Add("Fecha Inicio")
        dt.Columns.Add("Fecha Término")
        dt.Columns.Add("Duración (Hrs)")
        dt.Columns.Add("Tipo")

        For Each reg In registros
            dt.Rows.Add(
                If(reg.IdMant > 0, reg.IdMant.ToString(), "-"),
                reg.IdCiclo.ToString(),
                reg.Seccion,
                reg.ItemMaquina,
                reg.Estado,
                reg.Observacion,
                reg.FechaInicio.ToString("dd-MM-yyyy HH:mm"),
                reg.FechaTermino.ToString("dd-MM-yyyy HH:mm"),
                reg.Duracion.ToString("N1"),
                reg.TipoMp)
        Next
        Return dt
    End Function

    Private Shared Sub PintarCalendarioGanttEnHoja(ByVal ws As Excel.Worksheet,
                                                    ByVal registros As List(Of FrmCartaGantt.RegistroCicloGantt),
                                                    ByVal fechaMin As DateTime,
                                                    ByVal totalDias As Integer,
                                                    ByVal colIniCal As Integer,
                                                    ByVal filaIni As Integer,
                                                    ByVal filaFin As Integer,
                                                    ByVal colorFinSemana As Integer,
                                                    ByVal colorBlanco As Integer)
        Dim colIniLetra As String = ObtenerLetraColumnaExcel(colIniCal)
        Dim colFinLetra As String = ObtenerLetraColumnaExcel(colIniCal + totalDias - 1)
        ws.Range(colIniLetra & filaIni & ":" & colFinLetra & filaFin).NumberFormat = "@"

        ' Sombreado de fines de semana agrupando Sábado+Domingo contiguos en una sola llamada COM por semana
        Dim dIdx As Integer = 0
        While dIdx < totalDias
            Dim dtDia As DateTime = fechaMin.AddDays(dIdx)
            If dtDia.DayOfWeek = DayOfWeek.Saturday Then
                Dim dEndIdx As Integer = If(dIdx + 1 < totalDias AndAlso fechaMin.AddDays(dIdx + 1).DayOfWeek = DayOfWeek.Sunday, dIdx + 1, dIdx)
                Dim cIniL As String = ObtenerLetraColumnaExcel(colIniCal + dIdx)
                Dim cFinL As String = ObtenerLetraColumnaExcel(colIniCal + dEndIdx)
                ws.Range(cIniL & filaIni.ToString() & ":" & cFinL & filaFin.ToString()).Interior.Color = colorFinSemana
                dIdx = dEndIdx + 1
            ElseIf dtDia.DayOfWeek = DayOfWeek.Sunday Then
                Dim colL As String = ObtenerLetraColumnaExcel(colIniCal + dIdx)
                ws.Range(colL & filaIni.ToString() & ":" & colL & filaFin.ToString()).Interior.Color = colorFinSemana
                dIdx += 1
            Else
                dIdx += 1
            End If
        End While

        Dim fechaMaxCal As DateTime = fechaMin.AddDays(totalDias - 1)
        For i As Integer = 0 To registros.Count - 1
            Dim reg As FrmCartaGantt.RegistroCicloGantt = registros(i)
            Dim rEx As Integer = filaIni + i
            Dim dIniRow As DateTime = reg.FechaInicio.Date
            Dim dFinRow As DateTime = If(reg.FechaTermino.Date < dIniRow, dIniRow, reg.FechaTermino.Date)
            If dFinRow < fechaMin OrElse dIniRow > fechaMaxCal Then Continue For

            Dim offsetIni As Integer = Math.Max(0, Math.Min(totalDias - 1, CInt((dIniRow - fechaMin).TotalDays)))
            Dim offsetFin As Integer = Math.Max(offsetIni, Math.Min(totalDias - 1, CInt((dFinRow - fechaMin).TotalDays)))

            Dim cStartL As String = ObtenerLetraColumnaExcel(colIniCal + offsetIni)
            Dim cEndL As String = ObtenerLetraColumnaExcel(colIniCal + offsetFin)
            ws.Range(cStartL & rEx & ":" & cEndL & rEx).Interior.Color = ColorOleDesdeEstado(reg.Estado, reg.FechaTermino)

            Dim cellIni As Excel.Range = CType(ws.Cells(rEx, colIniCal + offsetIni), Excel.Range)
            cellIni.Value = If(reg.Duracion > 0, String.Format("{0:N0}h", reg.Duracion), "#" & reg.IdCiclo.ToString())
            cellIni.Font.Color = colorBlanco
            cellIni.Font.Bold = True
            cellIni.Font.Size = 7.5
            cellIni.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Next
    End Sub

    Public Sub ExportarCartaGanttExcel(ByVal registros As List(Of FrmCartaGantt.RegistroCicloGantt),
                                        ByVal grilla_info_mp As DataGridView,
                                        ByVal itemTitulo As String,
                                        ByVal fechaDesdeTexto As String,
                                        ByVal fechaHastaTexto As String,
                                        Optional ByVal forzarModoVariasMaq As Boolean = False,
                                        Optional ByVal silencioso As Boolean = False)
        ExportarInfGanttInterno(registros, grilla_info_mp, itemTitulo, fechaDesdeTexto, fechaHastaTexto, False, String.Empty, forzarModoVariasMaq, silencioso)
    End Sub

    Public Sub ExportarCartaGanttPdf(ByVal registros As List(Of FrmCartaGantt.RegistroCicloGantt),
                                      ByVal grilla_info_mp As DataGridView,
                                      ByVal itemTitulo As String,
                                      ByVal fechaDesdeTexto As String,
                                      ByVal fechaHastaTexto As String,
                                      ByVal rutaPdf As String,
                                      Optional ByVal forzarModoVariasMaq As Boolean = False,
                                      Optional ByVal silencioso As Boolean = False)
        If String.IsNullOrWhiteSpace(rutaPdf) Then Exit Sub
        ExportarInfGanttInterno(registros, grilla_info_mp, itemTitulo, fechaDesdeTexto, fechaHastaTexto, True, rutaPdf, forzarModoVariasMaq, silencioso)
    End Sub

    Private Sub ExportarInfGanttInterno(ByVal registros As List(Of FrmCartaGantt.RegistroCicloGantt),
                                         ByVal grilla_info_mp As DataGridView,
                                         ByVal itemTitulo As String,
                                         ByVal fechaDesdeTexto As String,
                                         ByVal fechaHastaTexto As String,
                                         ByVal esPdf As Boolean,
                                         ByVal rutaPdf As String,
                                         ByVal forzarModoVariasMaq As Boolean,
                                         ByVal silencioso As Boolean)
        If registros Is Nothing OrElse registros.Count = 0 Then
            MsgBox("No hay ciclos visibles en la Carta Gantt para exportar.", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Dim idMantUnico As Integer = 0
        Dim esModoUnaMp As Boolean = False
        Dim itemNombre As String = String.Empty
        Dim idMpTexto As String = String.Empty
        Dim freqTexto As String = String.Empty
        Dim avisoTexto As String = String.Empty
        Dim fechaCreaTexto As String = String.Empty
        Dim tipoTexto As String = String.Empty
        Dim estadoTexto As String = String.Empty

        ResolverCabeceraMpParaGantt(registros, grilla_info_mp, itemTitulo, idMantUnico, esModoUnaMp, itemNombre, idMpTexto, freqTexto, avisoTexto, fechaCreaTexto, tipoTexto, estadoTexto)
        If forzarModoVariasMaq Then esModoUnaMp = False

        Dim fechaMin As DateTime = DateTime.MaxValue
        Dim fechaMax As DateTime = DateTime.MinValue
        For Each reg In registros
            Dim dIni As DateTime = reg.FechaInicio.Date
            Dim dFin As DateTime = If(reg.FechaTermino.Date < dIni, dIni, reg.FechaTermino.Date)
            If dIni < fechaMin Then fechaMin = dIni
            If dFin > fechaMax Then fechaMax = dFin
        Next
        If fechaMin = DateTime.MaxValue OrElse fechaMax = DateTime.MinValue OrElse fechaMin > fechaMax Then
            fechaMin = DateTime.Today
            fechaMax = DateTime.Today
        End If

        Dim totalDias As Integer = CInt((fechaMax - fechaMin).TotalDays) + 1
        Const maxDiasCalendario As Integer = 1100
        If totalDias > maxDiasCalendario Then
            fechaMin = fechaMax.AddDays(-(maxDiasCalendario - 1))
            totalDias = maxDiasCalendario
        End If

        Dim fDesdeFinal As String = If(String.IsNullOrWhiteSpace(fechaDesdeTexto), fechaMin.ToString("dd-MM-yyyy"), fechaDesdeTexto)
        Dim fHastaFinal As String = If(String.IsNullOrWhiteSpace(fechaHastaTexto), fechaMax.ToString("dd-MM-yyyy"), fechaHastaTexto)

        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing

        Try
            excelApp = New Excel.Application
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, True)
            Try
                excelApp.PrintCommunication = False
            Catch
            End Try
            workbook = Utilitarios.CrearLibroDesdePlantilla(excelApp, "InfGantt.xls")
            workbook = Utilitarios.ConvertirLibroAXlsxTempParaAmpliarColumnas(excelApp, workbook)

            Dim ws1 As Excel.Worksheet = CType(workbook.Sheets(1), Excel.Worksheet) ' Informe Gantt
            Dim ws2 As Excel.Worksheet = CType(workbook.Sheets(2), Excel.Worksheet) ' Calendario
            Dim ws3 As Excel.Worksheet = CType(workbook.Sheets(3), Excel.Worksheet) ' Calendario Varias Maquinas

            ws1.Visible = Excel.XlSheetVisibility.xlSheetVisible
            ws2.Visible = If(esModoUnaMp, Excel.XlSheetVisibility.xlSheetVisible, Excel.XlSheetVisibility.xlSheetHidden)
            ws3.Visible = If(esModoUnaMp, Excel.XlSheetVisibility.xlSheetHidden, Excel.XlSheetVisibility.xlSheetVisible)

            ' ==================================================================================
            ' HOJA 1: "Informe Gantt" (Siempre poblada con cabecera y tabla completa de ciclos)
            ' ==================================================================================
            ws1.Cells(6, 3) = itemNombre
            ws1.Cells(7, 3) = idMpTexto
            ws1.Cells(6, 6) = freqTexto
            ws1.Cells(7, 6) = avisoTexto
            ws1.Cells(6, 9) = fechaCreaTexto
            ws1.Cells(7, 9) = tipoTexto
            ws1.Cells(6, 12) = estadoTexto

            Try
                ws1.Range("H12:BZ220").FormatConditions.Delete()
            Catch
            End Try

            Try
                ws1.Range("G10:G11").Copy()
                ws1.Range("H10:H11").PasteSpecial(Excel.XlPasteType.xlPasteFormats)
                ws1.Range("I10:I11").PasteSpecial(Excel.XlPasteType.xlPasteFormats)
                excelApp.CutCopyMode = False
                ws1.Range("H10:H11").MergeCells = True
                ws1.Range("I10:I11").MergeCells = True
            Catch
            End Try
            ws1.Cells(10, 8) = "Estado"
            ws1.Cells(10, 9) = If(esModoUnaMp, "Tipo", "N° MP / Item")

            Dim fila1Ini As Integer = 12
            Dim fila1Fin As Integer = fila1Ini + registros.Count - 1
            ws1.Range("E" & fila1Ini.ToString() & ":F" & fila1Fin.ToString()).NumberFormat = "@"
            For i As Integer = 0 To registros.Count - 1
                Dim reg As FrmCartaGantt.RegistroCicloGantt = registros(i)
                Dim rEx As Integer = fila1Ini + i
                ws1.Cells(rEx, 1) = reg.IdCiclo
                Dim descTexto As String = If(esModoUnaMp, reg.Observacion, String.Format("[{0}] {1}", reg.ItemMaquina, reg.Observacion).Trim())
                ws1.Cells(rEx, 2) = descTexto
                ws1.Cells(rEx, 5) = reg.FechaInicio.ToString("dd-MM-yyyy HH:mm")
                ws1.Cells(rEx, 6) = reg.FechaTermino.ToString("dd-MM-yyyy HH:mm")
                ws1.Cells(rEx, 7) = reg.Duracion
                ws1.Cells(rEx, 8) = If(String.IsNullOrWhiteSpace(reg.Estado), "-", reg.Estado)
                ws1.Cells(rEx, 9) = If(esModoUnaMp, reg.TipoMp, String.Format("MP #{0} - {1}", reg.IdMant, reg.Seccion).Trim())

                Dim rMerge As Excel.Range = ws1.Range("B" & rEx & ":D" & rEx)
                rMerge.MergeCells = True
                ws1.Rows(rEx).RowHeight = 20

                Dim cEst As Excel.Range = CType(ws1.Cells(rEx, 8), Excel.Range)
                cEst.Font.Bold = True
                cEst.Font.Color = ColorOleDesdeEstado(reg.Estado, reg.FechaTermino)
            Next

            Dim rngTabla1 As Excel.Range = ws1.Range("A10:I" & fila1Fin)
            rngTabla1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            rngTabla1.Borders.Weight = Excel.XlBorderWeight.xlThin
            ws1.Range("I6:J6").NumberFormat = "@"
            ws1.Columns("E").ColumnWidth = 14
            ws1.Columns("F").ColumnWidth = 14
            ws1.Columns("G").ColumnWidth = 12
            ws1.Columns("H").ColumnWidth = 17
            ws1.Columns("I").ColumnWidth = 24
            ws1.Columns("J").ColumnWidth = 13
            ws1.Columns("K").ColumnWidth = 10
            ws1.Columns("L").ColumnWidth = 14
            ws1.PageSetup.PrintArea = "$A$1:$M$" & fila1Fin.ToString()
            ws1.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            ws1.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLetter
            ws1.PageSetup.Zoom = False
            ws1.PageSetup.FitToPagesWide = 1
            ws1.PageSetup.FitToPagesTall = False

            ' Matriz de fechas para calendario (1 día por columna)
            Dim arrFechas(0, totalDias - 1) As Object
            For d As Integer = 0 To totalDias - 1
                arrFechas(0, d) = fechaMin.AddDays(d).ToOADate()
            Next
            Dim colorFinSemana As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(232, 238, 242))
            Dim colorHeaderAzul As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(2, 94, 135))
            Dim colorBlanco As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

            ' ==================================================================================
            ' HOJA 2 ("Calendario") o HOJA 3 ("Calendario Varias Maquinas")
            ' ==================================================================================
            If esModoUnaMp Then
                Dim colIniCal As Integer = 5
                Dim colFinCal As Integer = colIniCal + totalDias - 1
                Dim letraFinCal As String = ObtenerLetraColumnaExcel(colFinCal)
                Dim fila2Ini As Integer = 11
                Dim fila2Fin As Integer = fila2Ini + registros.Count - 1

                Try
                    ws2.Range("E10:" & letraFinCal & (fila2Fin + 30).ToString()).FormatConditions.Delete()
                Catch
                End Try

                Dim rngHdrFechas As Excel.Range = ws2.Range("E10:" & letraFinCal & "10")
                rngHdrFechas.Value2 = arrFechas
                rngHdrFechas.NumberFormat = "dd-mm-yy"
                rngHdrFechas.Orientation = 90
                rngHdrFechas.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                rngHdrFechas.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                rngHdrFechas.Interior.Color = colorHeaderAzul
                rngHdrFechas.Font.Color = colorBlanco
                rngHdrFechas.Font.Bold = True
                rngHdrFechas.Font.Size = 8
                rngHdrFechas.ColumnWidth = 3.6
                ws2.Rows(10).RowHeight = 52

                ws2.Columns("A").ColumnWidth = 8
                ws2.Columns("B").ColumnWidth = 15
                ws2.Columns("C").ColumnWidth = 15
                ws2.Columns("D").ColumnWidth = 18

                ' Reordenar bloque superior de metadatos evitando recortes ("#######" / "cuencia :") sobre columnas angostas de 3.6
                ws2.Range("A5:D5").MergeCells = True
                ws2.Range("A6:B6").MergeCells = True
                ws2.Range("C6:D6").MergeCells = True
                ws2.Range("A7:B7").MergeCells = True
                ws2.Range("C7:D7").MergeCells = True
                ws2.Range("C6:D7").NumberFormat = "@"
                ws2.Cells(6, 3) = itemNombre
                ws2.Cells(7, 3) = idMpTexto

                ws2.Range("E6:AA7").UnMerge()
                ws2.Range("E6:AA7").ClearContents()
                ws2.Range("E6:AA7").WrapText = False
                Dim colorEtiquetaHdr As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(15, 45, 68))
                Dim colorTextoHdr As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(30, 41, 59))
                Dim bloquesHdr As String(,) = {
                    {"E6:H6", "Frecuencia :", "I6:K6", freqTexto},
                    {"L6:P6", "Fecha Creación :", "Q6:T6", fechaCreaTexto},
                    {"U6:W6", "Estado :", "X6:AA6", estadoTexto},
                    {"E7:H7", "Tiempo Aviso :", "I7:K7", avisoTexto},
                    {"L7:P7", "Tipo :", "Q7:AA7", tipoTexto}
                }
                For b As Integer = 0 To bloquesHdr.GetLength(0) - 1
                    Dim rLbl As Excel.Range = ws2.Range(bloquesHdr(b, 0))
                    rLbl.Merge()
                    rLbl.Value = bloquesHdr(b, 1)
                    rLbl.Font.Bold = True
                    rLbl.Font.Size = 9
                    rLbl.Font.Color = colorEtiquetaHdr
                    rLbl.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    rLbl.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

                    Dim rVal As Excel.Range = ws2.Range(bloquesHdr(b, 2))
                    rVal.Merge()
                    rVal.NumberFormat = "@"
                    rVal.Value = bloquesHdr(b, 3)
                    rVal.Font.Bold = False
                    rVal.Font.Size = 9
                    rVal.Font.Color = colorTextoHdr
                    rVal.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                    rVal.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Next
                Dim rngMeta2 As Excel.Range = ws2.Range("A6:AA7")
                rngMeta2.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                rngMeta2.Borders.Weight = Excel.XlBorderWeight.xlThin

                For i As Integer = 0 To registros.Count - 1
                    Dim reg As FrmCartaGantt.RegistroCicloGantt = registros(i)
                    Dim rEx As Integer = fila2Ini + i
                    ws2.Cells(rEx, 1) = reg.IdCiclo
                    ws2.Cells(rEx, 2) = reg.Observacion
                    ws2.Range("B" & rEx & ":D" & rEx).MergeCells = True
                    ws2.Rows(rEx).RowHeight = 20
                Next

                ' Sombreado de fines de semana y barras Gantt horizontales con color semántico por estado
                PintarCalendarioGanttEnHoja(ws2, registros, fechaMin, totalDias, colIniCal, fila2Ini, fila2Fin, colorFinSemana, colorBlanco)

                Dim rngGrid2 As Excel.Range = ws2.Range("A9:" & letraFinCal & fila2Fin.ToString())
                rngGrid2.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                rngGrid2.Borders.Weight = Excel.XlBorderWeight.xlThin
                Dim letraPrint2 As String = ObtenerLetraColumnaExcel(Math.Max(colFinCal, 27))
                ws2.PageSetup.PrintArea = "$A$1:$" & letraPrint2 & "$" & fila2Fin.ToString()
                ws2.PageSetup.PrintTitleColumns = "$A:$D"
                ws2.PageSetup.PrintTitleRows = "$1:$10"
                ws2.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                ws2.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLetter
                ws2.PageSetup.Zoom = False
                ws2.PageSetup.FitToPagesWide = Math.Max(1, Math.Min(20, CInt(Math.Ceiling(Math.Max(totalDias, 24) / 42.0))))
                ws2.PageSetup.FitToPagesTall = False
            Else
                ws3.Cells(1, 4) = "Calendario Gantt Mantención Preventiva - " & itemNombre
                ws3.Range("C5:D6").NumberFormat = "@"
                ws3.Cells(5, 3) = fDesdeFinal
                ws3.Cells(6, 3) = fHastaFinal
                ws3.Columns("A").ColumnWidth = 9
                ws3.Columns("B").ColumnWidth = 26
                ws3.Columns("C").ColumnWidth = 16
                ws3.Columns("D").ColumnWidth = 16
                ws3.Columns("E").ColumnWidth = 18

                Dim colIniCal3 As Integer = 6
                Dim colFinCal3 As Integer = colIniCal3 + totalDias - 1
                Dim letraFinCal3 As String = ObtenerLetraColumnaExcel(colFinCal3)
                Dim fila3Ini As Integer = 10
                Dim fila3Fin As Integer = fila3Ini + registros.Count - 1

                Try
                    ws3.Range("F4:" & letraFinCal3 & (fila3Fin + 30).ToString()).FormatConditions.Delete()
                Catch
                End Try

                ' Unificar y dar formato uniforme a encabezados verticales de fecha F4:F9.. en bloque COM
                Dim primerHdr3 As Excel.Range = ws3.Range("F4:F9")
                If IsDBNull(primerHdr3.MergeCells) OrElse Not CBool(primerHdr3.MergeCells) Then
                    primerHdr3.Merge()
                End If
                If totalDias > 1 Then
                    primerHdr3.Copy()
                    ws3.Range("F4:" & letraFinCal3 & "9").PasteSpecial(Excel.XlPasteType.xlPasteFormats)
                    excelApp.CutCopyMode = False
                End If
                ws3.Range("F4:" & letraFinCal3 & "4").Value2 = arrFechas
                Dim rngHdr3 As Excel.Range = ws3.Range("F4:" & letraFinCal3 & "9")
                rngHdr3.NumberFormat = "dd-mm-yy"
                rngHdr3.Orientation = 90
                rngHdr3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                rngHdr3.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                rngHdr3.Interior.Color = colorHeaderAzul
                rngHdr3.Font.Color = colorBlanco
                rngHdr3.Font.Bold = True
                rngHdr3.Font.Size = 8
                rngHdr3.ColumnWidth = 3.6

                For i As Integer = 0 To registros.Count - 1
                    Dim reg As FrmCartaGantt.RegistroCicloGantt = registros(i)
                    Dim rEx As Integer = fila3Ini + i
                    ws3.Cells(rEx, 1) = reg.IdCiclo
                    ws3.Cells(rEx, 2) = reg.ItemMaquina
                    ws3.Cells(rEx, 3) = If(reg.IdMant > 0, String.Format("MP #{0} · {1}", reg.IdMant, reg.Observacion).Trim(), reg.Observacion)
                    ws3.Range("C" & rEx & ":E" & rEx).MergeCells = True
                    ws3.Rows(rEx).RowHeight = 20
                Next

                PintarCalendarioGanttEnHoja(ws3, registros, fechaMin, totalDias, colIniCal3, fila3Ini, fila3Fin, colorFinSemana, colorBlanco)

                Dim rngGrid3 As Excel.Range = ws3.Range("A8:" & letraFinCal3 & fila3Fin.ToString())
                rngGrid3.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                rngGrid3.Borders.Weight = Excel.XlBorderWeight.xlThin
                ws3.PageSetup.PrintArea = "$A$1:$" & letraFinCal3 & "$" & fila3Fin.ToString()
                ws3.PageSetup.PrintTitleColumns = "$A:$E"
                ws3.PageSetup.PrintTitleRows = "$1:$9"
                ws3.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                ws3.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLetter
                ws3.PageSetup.Zoom = False
                ws3.PageSetup.FitToPagesWide = Math.Max(1, Math.Min(20, CInt(Math.Ceiling(totalDias / 42.0))))
                ws3.PageSetup.FitToPagesTall = False
            End If

            ws1.Activate()
            Try
                excelApp.PrintCommunication = True
            Catch
            End Try
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            If esPdf Then
                Utilitarios.ImprimirLibroAPdfWindows(excelApp, workbook, rutaPdf, "Carta_Gantt_" & itemNombre, True, silencioso)
            Else
                If Not silencioso Then
                    MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Carta Gantt")
                End If
                excelApp.Visible = True
            End If
        Catch ex As Exception
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            If Not esPdf Then Utilitarios.CerrarExcelEnError(excelApp, workbook)
            RegistroErrores.RegistrarError(ex, If(esPdf, "Exportar Carta Gantt PDF (Fallback Nativo)", "Exportar Carta Gantt Excel (Fallback Nativo)"))
            Try
                Dim dtPlana As DataTable = ConstruirTablaGanttPlana(registros)
                Dim dtCab As New DataTable("ResumenGantt")
                dtCab.Columns.Add("Concepto")
                dtCab.Columns.Add("Valor")
                dtCab.Rows.Add("Máquina / Ámbito", itemNombre)
                dtCab.Rows.Add("ID Mantención", idMpTexto)
                dtCab.Rows.Add("Frecuencia / Ciclos", freqTexto)
                dtCab.Rows.Add("Tiempo Aviso / Horas", avisoTexto)
                dtCab.Rows.Add("Período", fDesdeFinal & " al " & fHastaFinal)
                dtCab.Rows.Add("Tipo / Estado", tipoTexto & " · " & estadoTexto)

                If esPdf Then
                    Dim dgvCab As New DataGridView() : dgvCab.DataSource = dtCab : dgvCab.BindingContext = New BindingContext()
                    Dim dgvCic As New DataGridView() : dgvCic.DataSource = dtPlana : dgvCic.BindingContext = New BindingContext()
                    Dim secciones As New List(Of KeyValuePair(Of String, DataGridView)) From {
                        New KeyValuePair(Of String, DataGridView)("Información Mantención Preventiva", dgvCab),
                        New KeyValuePair(Of String, DataGridView)("Detalle de Ciclos Gantt", dgvCic)
                    }
                    If Utilitarios.ExportarGrillasAPdfNativo(secciones, rutaPdf, "INFORME CARTA GANTT - MANTENCIÓN PREVENTIVA", "Ítem: " & itemNombre & " | Período: " & fDesdeFinal & " al " & fHastaFinal) Then
                        If Not silencioso AndAlso MessageBox.Show("Archivo PDF generado exitosamente mediante motor nativo en:" & Environment.NewLine & rutaPdf & Environment.NewLine & Environment.NewLine & "¿Desea abrir el documento PDF ahora?", "Exportación PDF Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                            Utilitarios.AbrirDocumento(rutaPdf)
                        End If
                        Exit Sub
                    End If
                Else
                    Dim dgvCab As New DataGridView() : dgvCab.DataSource = dtCab : dgvCab.BindingContext = New BindingContext()
                    Dim dgvCic As New DataGridView() : dgvCic.DataSource = dtPlana : dgvCic.BindingContext = New BindingContext()
                    Dim hojas As New List(Of KeyValuePair(Of String, DataGridView)) From {
                        New KeyValuePair(Of String, DataGridView)("Información Gantt", dgvCab),
                        New KeyValuePair(Of String, DataGridView)("Informe Gantt", dgvCic)
                    }
                    If Utilitarios.ExportarGrillasAExcelNativo(hojas, "Informe_Gantt_" & itemNombre, "INFORME CARTA GANTT - MANTENCIÓN PREVENTIVA", "Ítem: " & itemNombre & " | Período: " & fDesdeFinal & " al " & fHastaFinal) OrElse Utilitarios.UltimaExportacionCancelada Then
                        Exit Sub
                    End If
                End If
            Catch
            End Try
            RegistroErrores.MostrarYRegistrar(ex, If(esPdf, "Exportar Carta Gantt a PDF", "Exportar Carta Gantt a Excel"))
        Finally
            If esPdf Then Utilitarios.LiberarExcel(workbook, excelApp)
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Public Sub expInfGantt(ByVal grilla_info_mp As DataGridView, ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item As String)
        Dim lista As List(Of FrmCartaGantt.RegistroCicloGantt) = ConvertirGrillasARegistrosGantt(grilla_ciclos_mp, grilla_info_mp, item)
        ExportarInfGanttInterno(lista, grilla_info_mp, item, String.Empty, String.Empty, False, String.Empty, False, False)
    End Sub

    Public Sub expInfGraficoGantt(ByVal grilla_info_mp As DataGridView, ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item As String)
        Dim lista As List(Of FrmCartaGantt.RegistroCicloGantt) = ConvertirGrillasARegistrosGantt(grilla_ciclos_mp, grilla_info_mp, item)
        ExportarInfGanttInterno(lista, grilla_info_mp, item, String.Empty, String.Empty, False, String.Empty, False, False)
    End Sub

    Public Sub expInfGanttTodo(ByVal grilla_info_mp As DataGridView, ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item As String)
        Dim lista As List(Of FrmCartaGantt.RegistroCicloGantt) = ConvertirGrillasARegistrosGantt(grilla_ciclos_mp, grilla_info_mp, item)
        ExportarInfGanttInterno(lista, grilla_info_mp, item, String.Empty, String.Empty, False, String.Empty, False, False)
    End Sub

    Public Sub expInfGraficoGanttVariasMaq(ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item_gantt As String, ByVal fecha_desde As String, ByVal fecha_hasta As String)
        Dim lista As List(Of FrmCartaGantt.RegistroCicloGantt) = ConvertirGrillasARegistrosGantt(grilla_ciclos_mp, Nothing, item_gantt)
        ExportarInfGanttInterno(lista, Nothing, item_gantt, fecha_desde, fecha_hasta, False, String.Empty, True, False)
    End Sub

    Public Sub expInfAuditoria(ByVal grilla_auditoria As DataGridView,
                               ByVal fecha_inicio As DateTime,
                               ByVal fecha_fin As DateTime,
                               Optional ByVal filasPersonalizadas As IList(Of DataGridViewRow) = Nothing,
                               Optional ByVal incluirEstadisticas As Boolean = True,
                               Optional ByVal dsEstadisticas As DataSet = Nothing)
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet_1 As Excel.Worksheet = Nothing

        Try
            excelApp = New Excel.Application
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, True)

            workbook = Utilitarios.CrearLibroDesdePlantilla(excelApp, "inf_auditoria.xls")
            worksheet_1 = CType(workbook.Sheets(1), Excel.Worksheet)
            worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetVisible

            ' Si la plantilla no tenía cabeceras (libro en blanco creado de respaldo), estructurarlo
            If worksheet_1.Cells(8, 3).Value Is Nothing OrElse String.IsNullOrEmpty(Convert.ToString(worksheet_1.Cells(8, 3).Value)) Then
                worksheet_1.Cells(1, 3) = "Informe Control de Eventos / Auditoría"
                worksheet_1.Cells(5, 5) = "Fecha Desde:"
                worksheet_1.Cells(6, 5) = "Fecha Hasta:"
                Dim cabeceras As String() = {"N° Operación", "Sesión", "Operación", "Fecha Operación", "Hora Operación", "Tabla", "Clave Afectada", "Nombre PC"}
                For c As Integer = 0 To cabeceras.Length - 1
                    worksheet_1.Cells(8, 3 + c) = cabeceras(c)
                Next
            End If

            ' Impresión fecha inicio y fecha fin
            worksheet_1.Cells(5, 6).NumberFormat = "@"
            worksheet_1.Cells(6, 6).NumberFormat = "@"
            worksheet_1.Cells(5, 6) = fecha_inicio.ToString("dd-MM-yyyy")
            worksheet_1.Cells(6, 6) = fecha_fin.ToString("dd-MM-yyyy")

            ' Determinación de filas a exportar (seleccionadas o todas las visibles filtradas)
            Dim filasAExportar As New List(Of DataGridViewRow)
            If filasPersonalizadas IsNot Nothing AndAlso filasPersonalizadas.Count > 0 Then
                filasAExportar.AddRange(filasPersonalizadas)
            Else
                For i As Integer = 0 To grilla_auditoria.RowCount - 1
                    filasAExportar.Add(grilla_auditoria.Rows(i))
                Next
            End If

            Dim totalFilas As Integer = filasAExportar.Count
            If totalFilas > 0 Then
                Dim cantCols As Integer = Math.Min(grilla_auditoria.ColumnCount, 8)
                Dim arrDatos(totalFilas - 1, cantCols - 1) As Object

                For r As Integer = 0 To totalFilas - 1
                    Dim row As DataGridViewRow = filasAExportar(r)
                    For c As Integer = 0 To cantCols - 1
                        Dim val As Object = row.Cells(c).Value
                        arrDatos(r, c) = If(val IsNot Nothing AndAlso Not IsDBNull(val), val.ToString(), "")
                    Next
                Next

                Dim filaInicioDatos As Integer = 9
                Dim rangoIni As Excel.Range = CType(worksheet_1.Cells(filaInicioDatos, 3), Excel.Range)
                Dim rangoFin As Excel.Range = CType(worksheet_1.Cells(filaInicioDatos + totalFilas - 1, 3 + cantCols - 1), Excel.Range)
                Dim rangoDestino As Excel.Range = worksheet_1.Range(rangoIni, rangoFin)
                rangoDestino.Value = arrDatos

                Try
                    rangoDestino.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                    rangoDestino.Borders.Weight = Excel.XlBorderWeight.xlThin
                Catch
                End Try
            End If

            ' Incorporar Hoja de Estadísticas si fue solicitado
            If incluirEstadisticas AndAlso dsEstadisticas IsNot Nothing AndAlso dsEstadisticas.Tables.Count > 0 Then
                Try
                    Dim wsStats As Excel.Worksheet = CType(workbook.Sheets.Add(After:=worksheet_1), Excel.Worksheet)
                    wsStats.Name = "Resumen Estadístico"
                    ConstruirHojaEstadisticasAuditoria(wsStats, dsEstadisticas, fecha_inicio, fecha_fin, totalFilas)
                Catch
                End Try
            End If

            worksheet_1.Activate()
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            MsgBox(String.Format("Auditoría exportada exitosamente a Excel.{0}Total de registros: {1:N0}", vbCrLf, totalFilas), MsgBoxStyle.Information, "Exportar Auditoría")
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            Dim hojas As New List(Of KeyValuePair(Of String, DataGridView))()
            Dim tempGrillas As New List(Of DataGridView)()
            Try
                If filasPersonalizadas IsNot Nothing AndAlso filasPersonalizadas.Count > 0 AndAlso grilla_auditoria IsNot Nothing Then
                    Dim dgvSel As New DataGridView()
                    For Each col As DataGridViewColumn In grilla_auditoria.Columns
                        If col.Visible Then dgvSel.Columns.Add(col.Name, col.HeaderText)
                    Next
                    For Each r As DataGridViewRow In filasPersonalizadas
                        Dim vals As New List(Of Object)()
                        For Each col As DataGridViewColumn In grilla_auditoria.Columns
                            If col.Visible Then vals.Add(r.Cells(col.Index).Value)
                        Next
                        dgvSel.Rows.Add(vals.ToArray())
                    Next
                    tempGrillas.Add(dgvSel)
                    hojas.Add(New KeyValuePair(Of String, DataGridView)("Auditoría", dgvSel))
                ElseIf grilla_auditoria IsNot Nothing AndAlso grilla_auditoria.RowCount > 0 Then
                    hojas.Add(New KeyValuePair(Of String, DataGridView)("Auditoría", grilla_auditoria))
                End If

                If incluirEstadisticas AndAlso dsEstadisticas IsNot Nothing Then
                    For Each dt As DataTable In dsEstadisticas.Tables
                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            Dim dgvStat As DataGridView = CrearGrillaDesdeDataTable(dt)
                            tempGrillas.Add(dgvStat)
                            hojas.Add(New KeyValuePair(Of String, DataGridView)(dt.TableName, dgvStat))
                        End If
                    Next
                End If

                If hojas.Count > 0 AndAlso (Utilitarios.ExportarGrillasAExcelNativo(hojas, "Auditoria_Operaciones", "INFORME AUDITORÍA DE OPERACIONES", "Período: " & fecha_inicio.ToString("dd-MM-yyyy") & " al " & fecha_fin.ToString("dd-MM-yyyy")) OrElse Utilitarios.UltimaExportacionCancelada) Then
                    Exit Sub
                End If
            Finally
                For Each tg In tempGrillas
                    tg.Dispose()
                Next
            End Try
            RegistroErrores.MostrarYRegistrar(ex, "Exportar Auditoría a Excel")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Function CrearGrillaDesdeDataTable(ByVal dt As DataTable) As DataGridView
        Dim dgv As New DataGridView()
        For Each col As DataColumn In dt.Columns
            dgv.Columns.Add(col.ColumnName, col.ColumnName)
        Next
        For Each row As DataRow In dt.Rows
            dgv.Rows.Add(row.ItemArray)
        Next
        Return dgv
    End Function

    Public Sub expSoloEstadisticasAuditoria(ByVal dsEstadisticas As DataSet, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime, Optional ByVal totalOps As Integer = 0)
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet_1 As Excel.Worksheet = Nothing

        Try
            If dsEstadisticas Is Nothing OrElse dsEstadisticas.Tables.Count = 0 Then
                MsgBox("No hay datos estadísticos para exportar.", MsgBoxStyle.Information, "Estadísticas")
                Exit Sub
            End If

            excelApp = New Excel.Application
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, True)
            workbook = excelApp.Workbooks.Add()
            worksheet_1 = CType(workbook.Sheets(1), Excel.Worksheet)
            worksheet_1.Name = "Métricas y Distribución"

            ConstruirHojaEstadisticasAuditoria(worksheet_1, dsEstadisticas, fecha_inicio, fecha_fin, totalOps)

            worksheet_1.Activate()
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            MsgBox("Reporte estadístico generado exitosamente.", MsgBoxStyle.Information, "Estadísticas Auditoría")
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            If dsEstadisticas IsNot Nothing AndAlso dsEstadisticas.Tables.Count > 0 Then
                Dim hojas As New List(Of KeyValuePair(Of String, DataGridView))()
                Dim tempGrillas As New List(Of DataGridView)()
                Try
                    For Each dt As DataTable In dsEstadisticas.Tables
                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            Dim dgvStat As DataGridView = CrearGrillaDesdeDataTable(dt)
                            tempGrillas.Add(dgvStat)
                            hojas.Add(New KeyValuePair(Of String, DataGridView)(dt.TableName, dgvStat))
                        End If
                    Next
                    If hojas.Count > 0 AndAlso (Utilitarios.ExportarGrillasAExcelNativo(hojas, "Estadisticas_Auditoria", "ESTADÍSTICAS DE AUDITORÍA", "Período: " & fecha_inicio.ToString("dd-MM-yyyy") & " al " & fecha_fin.ToString("dd-MM-yyyy") & " | Ops: " & totalOps.ToString("N0")) OrElse Utilitarios.UltimaExportacionCancelada) Then
                        Exit Sub
                    End If
                Finally
                    For Each tg In tempGrillas
                        tg.Dispose()
                    Next
                End Try
            End If
            RegistroErrores.MostrarYRegistrar(ex, "Exportar Estadísticas de Auditoría a Excel")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Sub ConstruirHojaEstadisticasAuditoria(ByVal ws As Excel.Worksheet, ByVal ds As DataSet, ByVal fIni As DateTime, ByVal fFin As DateTime, ByVal totalOps As Integer)
        If ws Is Nothing OrElse ds Is Nothing Then Exit Sub

        ' Títulos Principales
        ws.Cells(1, 1) = "CAMBIASO HNOS. S.A.C."
        ws.Cells(2, 1) = "DEPARTAMENTO DE MANTENCIÓN - REPORTE DE AUDITORÍA Y ESTADÍSTICAS"
        ws.Cells(3, 1) = String.Format("Período: {0} al {1} | Operaciones Analizadas: {2:N0} | Fecha Emisión: {3}",
                                       fIni.ToString("dd-MM-yyyy"), fFin.ToString("dd-MM-yyyy"), totalOps, DateTime.Now.ToString("dd-MM-yyyy HH:mm"))

        Dim rTit As Excel.Range = ws.Range(ws.Cells(1, 1), ws.Cells(3, 8))
        rTit.Font.Name = "Calibri"
        rTit.Font.Bold = True

        Dim filaActual As Integer = 5

        For Each dt As DataTable In ds.Tables
            If dt.Rows.Count = 0 Then Continue For

            ' Título de la Sección
            ws.Cells(filaActual, 1) = dt.TableName.ToUpperInvariant()
            Dim rSec As Excel.Range = CType(ws.Cells(filaActual, 1), Excel.Range)
            rSec.Font.Bold = True
            rSec.Font.Size = 11

            filaActual += 1

            ' Encabezados de Columna
            Dim cantCols As Integer = dt.Columns.Count
            For c As Integer = 0 To cantCols - 1
                ws.Cells(filaActual, c + 1) = dt.Columns(c).ColumnName
            Next

            Dim rEnc As Excel.Range = ws.Range(ws.Cells(filaActual, 1), ws.Cells(filaActual, cantCols))
            rEnc.Font.Bold = True
            rEnc.Interior.Color = System.Drawing.ColorTranslator.ToOle(Utilitarios.ColorPrimario)
            rEnc.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

            filaActual += 1

            ' Datos de la Tabla
            Dim cantFilas As Integer = dt.Rows.Count
            Dim matriz(cantFilas - 1, cantCols - 1) As Object

            For r As Integer = 0 To cantFilas - 1
                For c As Integer = 0 To cantCols - 1
                    Dim v As Object = dt.Rows(r)(c)
                    matriz(r, c) = If(v IsNot Nothing AndAlso Not IsDBNull(v), v.ToString(), "")
                Next
            Next

            Dim rDatosIni As Excel.Range = CType(ws.Cells(filaActual, 1), Excel.Range)
            Dim rDatosFin As Excel.Range = CType(ws.Cells(filaActual + cantFilas - 1, cantCols), Excel.Range)
            Dim rBloque As Excel.Range = ws.Range(rDatosIni, rDatosFin)
            rBloque.Value = matriz

            Try
                Dim rTablaEntera As Excel.Range = ws.Range(rEnc, rDatosFin)
                rTablaEntera.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                rTablaEntera.Borders.Weight = Excel.XlBorderWeight.xlThin
            Catch
            End Try

            filaActual += cantFilas + 2
        Next

        Try
            ws.Columns.AutoFit()
        Catch
        End Try
    End Sub

    Private Function ObtenerValorCelda(ByVal g As DataGridView, ByVal fila As Integer, ByVal colNombre As String, ByVal colFallback As Integer) As Object
        If g Is Nothing OrElse fila < 0 OrElse fila >= g.RowCount Then Return ""
        If g.Columns.Contains(colNombre) Then
            Return g.Rows(fila).Cells(colNombre).Value
        ElseIf colFallback >= 0 AndAlso colFallback < g.ColumnCount Then
            Return g.Rows(fila).Cells(colFallback).Value
        End If
        Return ""
    End Function

    Public Sub expInfEstadistica(ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime)
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet As Excel.Worksheet
        Dim opcion As Integer = 0

        Try
            excelApp = New Excel.Application
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, True)
            workbook = Utilitarios.CrearLibroDesdePlantilla(excelApp, "inf_estadistico.xls")
            worksheet = CType(workbook.Sheets(1), Excel.Worksheet)
            worksheet.Visible = Excel.XlSheetVisibility.xlSheetVisible

            '---------------------- impresion fecha inicio y fecha fin ----------------
            worksheet.Cells(4, 7).NumberFormat = "@"
            worksheet.Cells(5, 7).NumberFormat = "@"
            worksheet.Cells(4, 7) = fecha_inicio.ToString("dd-MM-yyyy")
            worksheet.Cells(5, 7) = fecha_fin.ToString("dd-MM-yyyy")
            '---------------------------------------------------------------------------------------

            Dim filaexcel As Integer = 14
            opcion = grilla_num_filas_mayor()
            '------------- llenado de operaciones realizadas --------------------------------------------

            If opcion = 1 Then
                With FrmResumenes.grillaOtPorTurno
                    For i = 0 To .RowCount - 1
                        worksheet.Rows(filaexcel + 1).Insert()
                        worksheet.Cells(filaexcel, 2) = ObtenerValorCelda(FrmResumenes.grillaOtPorTurno, i, "Turno", 0)
                        worksheet.Cells(filaexcel, 3) = ObtenerValorCelda(FrmResumenes.grillaOtPorTurno, i, "Cantidad OTs", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With

                With FrmResumenes.grillaOtPorDia
                    filaexcel = 14
                    For i = 0 To .RowCount - 1
                        worksheet.Cells(filaexcel, 5) = ObtenerValorCelda(FrmResumenes.grillaOtPorDia, i, "Fecha", 0)
                        worksheet.Cells(filaexcel, 6) = ObtenerValorCelda(FrmResumenes.grillaOtPorDia, i, "Cantidad OTs", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With

                If FrmResumenes.grillaTotalesPeriodo.Visible Then
                    With FrmResumenes.grillaTotalesPeriodo
                        filaexcel = 14
                        For i = 0 To .RowCount - 1
                            worksheet.Cells(filaexcel, 8) = ObtenerValorCelda(FrmResumenes.grillaTotalesPeriodo, i, "Estado", 0)
                            worksheet.Cells(filaexcel, 9) = ObtenerValorCelda(FrmResumenes.grillaTotalesPeriodo, i, "Cantidad OTs", 1)
                            filaexcel = filaexcel + 1
                        Next
                    End With

                ElseIf FrmResumenes.grillaOtPorMes.Visible Then
                    With FrmResumenes.grillaOtPorMes
                        filaexcel = 14
                        For i = 0 To .RowCount - 1
                            worksheet.Cells(filaexcel, 8) = ObtenerValorCelda(FrmResumenes.grillaOtPorMes, i, "Mes", 0)
                            worksheet.Cells(filaexcel, 9) = ObtenerValorCelda(FrmResumenes.grillaOtPorMes, i, "Cantidad OTs", 1)
                            filaexcel = filaexcel + 1
                        Next
                    End With
                End If

            ElseIf opcion = 2 Then
                With FrmResumenes.grillaOtPorDia
                    For i = 0 To .RowCount - 1
                        worksheet.Rows(filaexcel + 1).Insert()
                        worksheet.Cells(filaexcel, 5) = ObtenerValorCelda(FrmResumenes.grillaOtPorDia, i, "Fecha", 0)
                        worksheet.Cells(filaexcel, 6) = ObtenerValorCelda(FrmResumenes.grillaOtPorDia, i, "Cantidad OTs", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With

                With FrmResumenes.grillaOtPorTurno
                    filaexcel = 14
                    For i = 0 To .RowCount - 1
                        worksheet.Cells(filaexcel, 2) = ObtenerValorCelda(FrmResumenes.grillaOtPorTurno, i, "Turno", 0)
                        worksheet.Cells(filaexcel, 3) = ObtenerValorCelda(FrmResumenes.grillaOtPorTurno, i, "Cantidad OTs", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With

                If FrmResumenes.grillaTotalesPeriodo.Visible Then
                    With FrmResumenes.grillaTotalesPeriodo
                        filaexcel = 14
                        For i = 0 To .RowCount - 1
                            worksheet.Cells(filaexcel, 8) = ObtenerValorCelda(FrmResumenes.grillaTotalesPeriodo, i, "Estado", 0)
                            worksheet.Cells(filaexcel, 9) = ObtenerValorCelda(FrmResumenes.grillaTotalesPeriodo, i, "Cantidad OTs", 1)
                            filaexcel = filaexcel + 1
                        Next
                    End With

                ElseIf FrmResumenes.grillaOtPorMes.Visible Then
                    With FrmResumenes.grillaOtPorMes
                        filaexcel = 14
                        For i = 0 To .RowCount - 1
                            worksheet.Cells(filaexcel, 8) = ObtenerValorCelda(FrmResumenes.grillaOtPorMes, i, "Mes", 0)
                            worksheet.Cells(filaexcel, 9) = ObtenerValorCelda(FrmResumenes.grillaOtPorMes, i, "Cantidad OTs", 1)
                            filaexcel = filaexcel + 1
                        Next
                    End With
                End If

            ElseIf opcion = 3 Then
                If FrmResumenes.grillaOtPorMes.Visible Then
                    With FrmResumenes.grillaOtPorMes
                        For i = 0 To .RowCount - 1
                            worksheet.Rows(filaexcel + 1).Insert()
                            worksheet.Cells(filaexcel, 8) = ObtenerValorCelda(FrmResumenes.grillaOtPorMes, i, "Mes", 0)
                            worksheet.Cells(filaexcel, 9) = ObtenerValorCelda(FrmResumenes.grillaOtPorMes, i, "Cantidad OTs", 1)
                            filaexcel = filaexcel + 1
                        Next
                    End With
                ElseIf FrmResumenes.grillaTotalesPeriodo.Visible Then
                    With FrmResumenes.grillaTotalesPeriodo
                        For i = 0 To .RowCount - 1
                            worksheet.Rows(filaexcel + 1).Insert()
                            worksheet.Cells(filaexcel, 8) = ObtenerValorCelda(FrmResumenes.grillaTotalesPeriodo, i, "Estado", 0)
                            worksheet.Cells(filaexcel, 9) = ObtenerValorCelda(FrmResumenes.grillaTotalesPeriodo, i, "Cantidad OTs", 1)
                            filaexcel = filaexcel + 1
                        Next
                    End With
                End If

                With FrmResumenes.grillaOtPorTurno
                    filaexcel = 14
                    For i = 0 To .RowCount - 1
                        worksheet.Cells(filaexcel, 2) = ObtenerValorCelda(FrmResumenes.grillaOtPorTurno, i, "Turno", 0)
                        worksheet.Cells(filaexcel, 3) = ObtenerValorCelda(FrmResumenes.grillaOtPorTurno, i, "Cantidad OTs", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With

                With FrmResumenes.grillaOtPorDia
                    filaexcel = 14
                    For i = 0 To .RowCount - 1
                        worksheet.Cells(filaexcel, 5) = ObtenerValorCelda(FrmResumenes.grillaOtPorDia, i, "Fecha", 0)
                        worksheet.Cells(filaexcel, 6) = ObtenerValorCelda(FrmResumenes.grillaOtPorDia, i, "Cantidad OTs", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With
            End If

            opcion = grilla_num_filas_mayor_2()
            filaexcel = 9

            If opcion = 1 Then
                With FrmResumenes.grillaOtRecibidaPor
                    For i = 0 To .RowCount - 1
                        worksheet.Rows(filaexcel + 1).Insert()
                        worksheet.Cells(filaexcel, 2) = ObtenerValorCelda(FrmResumenes.grillaOtRecibidaPor, i, "Recibido Por", 0)
                        worksheet.Cells(filaexcel, 3) = ObtenerValorCelda(FrmResumenes.grillaOtRecibidaPor, i, "Cantidad OTs", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With

                With FrmResumenes.grillaOtCerradaPorTec
                    filaexcel = 9
                    For i = 0 To .RowCount - 1
                        worksheet.Cells(filaexcel, 5) = ObtenerValorCelda(FrmResumenes.grillaOtCerradaPorTec, i, "Técnico / Personal", 0)
                        worksheet.Cells(filaexcel, 6) = ObtenerValorCelda(FrmResumenes.grillaOtCerradaPorTec, i, "OTs Cerradas", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With

                With FrmResumenes.grillaOtPorTipoFalla
                    filaexcel = 9
                    For i = 0 To .RowCount - 1
                        worksheet.Cells(filaexcel, 8) = ObtenerValorCelda(FrmResumenes.grillaOtPorTipoFalla, i, "Tipo de Trabajo / Falla", 0)
                        worksheet.Cells(filaexcel, 9) = ObtenerValorCelda(FrmResumenes.grillaOtPorTipoFalla, i, "Cantidad OTs", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With

            ElseIf opcion = 2 Then
                With FrmResumenes.grillaOtCerradaPorTec
                    For i = 0 To .RowCount - 1
                        worksheet.Rows(filaexcel + 1).Insert()
                        worksheet.Cells(filaexcel, 5) = ObtenerValorCelda(FrmResumenes.grillaOtCerradaPorTec, i, "Técnico / Personal", 0)
                        worksheet.Cells(filaexcel, 6) = ObtenerValorCelda(FrmResumenes.grillaOtCerradaPorTec, i, "OTs Cerradas", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With

                With FrmResumenes.grillaOtRecibidaPor
                    filaexcel = 9
                    For i = 0 To .RowCount - 1
                        worksheet.Cells(filaexcel, 2) = ObtenerValorCelda(FrmResumenes.grillaOtRecibidaPor, i, "Recibido Por", 0)
                        worksheet.Cells(filaexcel, 3) = ObtenerValorCelda(FrmResumenes.grillaOtRecibidaPor, i, "Cantidad OTs", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With

                With FrmResumenes.grillaOtPorTipoFalla
                    filaexcel = 9
                    For i = 0 To .RowCount - 1
                        worksheet.Cells(filaexcel, 8) = ObtenerValorCelda(FrmResumenes.grillaOtPorTipoFalla, i, "Tipo de Trabajo / Falla", 0)
                        worksheet.Cells(filaexcel, 9) = ObtenerValorCelda(FrmResumenes.grillaOtPorTipoFalla, i, "Cantidad OTs", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With

            ElseIf opcion = 3 Then
                With FrmResumenes.grillaOtPorTipoFalla
                    For i = 0 To .RowCount - 1
                        worksheet.Rows(filaexcel + 1).Insert()
                        worksheet.Cells(filaexcel, 8) = ObtenerValorCelda(FrmResumenes.grillaOtPorTipoFalla, i, "Tipo de Trabajo / Falla", 0)
                        worksheet.Cells(filaexcel, 9) = ObtenerValorCelda(FrmResumenes.grillaOtPorTipoFalla, i, "Cantidad OTs", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With

                With FrmResumenes.grillaOtRecibidaPor
                    filaexcel = 9
                    For i = 0 To .RowCount - 1
                        worksheet.Cells(filaexcel, 2) = ObtenerValorCelda(FrmResumenes.grillaOtRecibidaPor, i, "Recibido Por", 0)
                        worksheet.Cells(filaexcel, 3) = ObtenerValorCelda(FrmResumenes.grillaOtRecibidaPor, i, "Cantidad OTs", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With

                With FrmResumenes.grillaOtCerradaPorTec
                    filaexcel = 9
                    For i = 0 To .RowCount - 1
                        worksheet.Cells(filaexcel, 5) = ObtenerValorCelda(FrmResumenes.grillaOtCerradaPorTec, i, "Técnico / Personal", 0)
                        worksheet.Cells(filaexcel, 6) = ObtenerValorCelda(FrmResumenes.grillaOtCerradaPorTec, i, "OTs Cerradas", 1)
                        filaexcel = filaexcel + 1
                    Next
                End With
            End If

            ' Exportar hoja adicional "Top Máquinas y Componentes"
            If FrmResumenes.grillaTopMaquinas.RowCount > 0 OrElse FrmResumenes.grillaTopComponentes.RowCount > 0 Then
                Dim wsTop As Excel.Worksheet = workbook.Sheets.Add(After:=worksheet)
                wsTop.Name = "Top Máquinas y Componentes"

                wsTop.Cells(2, 2) = "INFORME ESTADÍSTICO - TOP MÁQUINAS Y COMPONENTES"
                wsTop.Cells(2, 2).Font.Bold = True
                wsTop.Cells(2, 2).Font.Size = 13
                wsTop.Cells(2, 2).Font.Color = System.Drawing.ColorTranslator.ToOle(Utilitarios.ColorDeepNavy)

                wsTop.Cells(3, 2) = "Período: " & fecha_inicio.ToString("dd-MM-yyyy") & " al " & fecha_fin.ToString("dd-MM-yyyy")
                wsTop.Cells(3, 2).Font.Italic = True
                wsTop.Cells(3, 2).Font.Color = System.Drawing.ColorTranslator.ToOle(Utilitarios.ColorSecundario)

                ' Top Máquinas
                Dim fRow As Integer = 5
                wsTop.Cells(fRow, 2) = "TOP MÁQUINAS CON MÁS ÓRDENES DE TRABAJO"
                wsTop.Cells(fRow, 2).Font.Bold = True
                wsTop.Cells(fRow, 2).Font.Color = System.Drawing.ColorTranslator.ToOle(Utilitarios.ColorPrimario)

                fRow += 1
                Dim cabMaq() As String = {"Ranking", "Máquina / Equipo", "Total OTs", "% Participación", "OTs Cerradas", "OTs Abiertas", "% Resueltas"}
                For c As Integer = 0 To cabMaq.Length - 1
                    wsTop.Cells(fRow, c + 2) = cabMaq(c)
                Next
                Dim rCabMaq As Excel.Range = wsTop.Range(wsTop.Cells(fRow, 2), wsTop.Cells(fRow, cabMaq.Length + 1))
                rCabMaq.Font.Bold = True
                rCabMaq.Interior.Color = System.Drawing.ColorTranslator.ToOle(Utilitarios.ColorPrimario)
                rCabMaq.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                fRow += 1
                With FrmResumenes.grillaTopMaquinas
                    For i As Integer = 0 To .RowCount - 1
                        For c As Integer = 0 To Math.Min(.ColumnCount - 1, cabMaq.Length - 1)
                            wsTop.Cells(fRow, c + 2) = .Rows(i).Cells(c).Value
                        Next
                        fRow += 1
                    Next
                End With

                ' Top Componentes
                fRow += 2
                wsTop.Cells(fRow, 2) = "TOP COMPONENTES / PARTES CON MÁS ÓRDENES"
                wsTop.Cells(fRow, 2).Font.Bold = True
                wsTop.Cells(fRow, 2).Font.Color = System.Drawing.ColorTranslator.ToOle(Utilitarios.ColorPrimario)

                fRow += 1
                Dim cabComp() As String = {"Ranking", "Componente / Parte", "Máquina Asociada", "Total OTs", "% Participación", "OTs Cerradas", "OTs Abiertas"}
                For c As Integer = 0 To cabComp.Length - 1
                    wsTop.Cells(fRow, c + 2) = cabComp(c)
                Next
                Dim rCabComp As Excel.Range = wsTop.Range(wsTop.Cells(fRow, 2), wsTop.Cells(fRow, cabComp.Length + 1))
                rCabComp.Font.Bold = True
                rCabComp.Interior.Color = System.Drawing.ColorTranslator.ToOle(Utilitarios.ColorPrimario)
                rCabComp.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                fRow += 1
                With FrmResumenes.grillaTopComponentes
                    For i As Integer = 0 To .RowCount - 1
                        For c As Integer = 0 To Math.Min(.ColumnCount - 1, cabComp.Length - 1)
                            wsTop.Cells(fRow, c + 2) = .Rows(i).Cells(c).Value
                        Next
                        fRow += 1
                    Next
                End With

                wsTop.Columns.AutoFit()
            End If

            '--------------------------------------------------------------------------------------
            worksheet.Activate()
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            MsgBox("Informe Estadístico exportado exitosamente a Excel.", MsgBoxStyle.Information, "Exportar Resumen Estadístico")
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            With FrmResumenes
                Dim hojas As New List(Of KeyValuePair(Of String, DataGridView))()
                If .grillaTotalesPeriodo.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Totales Estado", .grillaTotalesPeriodo))
                If .grillaTopMaquinas.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Top Máquinas", .grillaTopMaquinas))
                If .grillaTopComponentes.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Top Componentes", .grillaTopComponentes))
                If .grillaOtCerradaPorTec.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Cerradas por Técnico", .grillaOtCerradaPorTec))
                If .grillaOtRecibidaPor.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Recibidas por", .grillaOtRecibidaPor))
                If .grillaOtPorTipoFalla.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Por Tipo Falla", .grillaOtPorTipoFalla))
                If .grillaOtPorTurno.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Por Turno", .grillaOtPorTurno))
                If .grillaOtPorDia.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Por Día", .grillaOtPorDia))
                If .grillaOtPorMes.RowCount > 0 Then hojas.Add(New KeyValuePair(Of String, DataGridView)("Por Mes", .grillaOtPorMes))
                If hojas.Count > 0 AndAlso (Utilitarios.ExportarGrillasAExcelNativo(hojas, "Informe_Estadistico_OT", "INFORME ESTADÍSTICO DE ÓRDENES DE TRABAJO", "Período: " & fecha_inicio.ToString("dd-MM-yyyy") & " al " & fecha_fin.ToString("dd-MM-yyyy")) OrElse Utilitarios.UltimaExportacionCancelada) Then
                    Exit Sub
                End If
            End With
            RegistroErrores.MostrarYRegistrar(ex, "Exportar Informe Estadística")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Public Function grilla_num_filas_mayor() As Integer
        Dim opcion As Integer = 0
        With FrmResumenes
            If .grillaOtPorTurno.RowCount >= .grillaOtPorDia.RowCount And .grillaOtPorTurno.RowCount >= .grillaOtPorMes.RowCount Then
                opcion = 1

            ElseIf .grillaOtPorDia.RowCount >= .grillaOtPorTurno.RowCount And .grillaOtPorDia.RowCount >= .grillaOtPorMes.RowCount Then
                opcion = 2

            ElseIf .grillaOtPorMes.RowCount >= .grillaOtPorTurno.RowCount And .grillaOtPorMes.RowCount >= .grillaOtPorDia.RowCount Then
                opcion = 3
            End If
        End With

        Return opcion
    End Function

    Public Function grilla_num_filas_mayor_2() As Integer
        Dim opcion As Integer = 0
        With FrmResumenes
            If .grillaOtRecibidaPor.RowCount >= .grillaOtCerradaPorTec.RowCount And .grillaOtRecibidaPor.RowCount >= .grillaOtPorTipoFalla.RowCount Then
                opcion = 1

            ElseIf .grillaOtCerradaPorTec.RowCount >= .grillaOtRecibidaPor.RowCount And .grillaOtCerradaPorTec.RowCount >= .grillaOtPorTipoFalla.RowCount Then
                opcion = 2

            ElseIf .grillaOtPorTipoFalla.RowCount >= .grillaOtRecibidaPor.RowCount And .grillaOtPorTipoFalla.RowCount >= .grillaOtCerradaPorTec.RowCount Then
                opcion = 3
            End If
        End With

        Return opcion
    End Function

    Public Sub expInfDatosTecnicos(ByVal grilla_datos_tecnicos As DataGridView)
        If grilla_datos_tecnicos Is Nothing OrElse grilla_datos_tecnicos.RowCount = 0 OrElse FrmDatosTecnicosNodo.nivel < 1 Then
            MsgBox("No hay datos técnicos válidos para exportar.", MsgBoxStyle.Exclamation, "Exportar Datos Técnicos")
            Return
        End If
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet

        Try
            excelApp = New Excel.Application
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, True)
            workbook = Utilitarios.CrearLibroDesdePlantilla(excelApp, "inf_datos_tecnicos.xls")
            worksheet_1 = CType(workbook.Sheets(1), Excel.Worksheet)
            worksheet_2 = CType(workbook.Sheets(2), Excel.Worksheet)
            worksheet_3 = CType(workbook.Sheets(3), Excel.Worksheet)

            If FrmDatosTecnicosNodo.nivel >= 3 Then

                worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetVisible
                worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetHidden
                worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetHidden

                Dim totalFilas As Integer = grilla_datos_tecnicos.RowCount
                If totalFilas > 0 Then
                    If totalFilas > 1 Then
                        Dim rangoInsert As Excel.Range = worksheet_1.Range("B10:D" & (8 + totalFilas).ToString())
                        rangoInsert.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
                    End If

                    Dim arrDatos(totalFilas - 1, 2) As Object
                    For i As Integer = 0 To totalFilas - 1
                        arrDatos(i, 0) = grilla_datos_tecnicos.Rows(i).Cells(2).Value
                        arrDatos(i, 1) = grilla_datos_tecnicos.Rows(i).Cells(3).Value
                        arrDatos(i, 2) = grilla_datos_tecnicos.Rows(i).Cells(4).Value
                    Next

                    Dim rangoDestino As Excel.Range = worksheet_1.Range("B9:D" & (9 + totalFilas - 1).ToString())
                    rangoDestino.Value2 = arrDatos
                    Try
                        rangoDestino.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                        rangoDestino.Borders.Weight = Excel.XlBorderWeight.xlThin
                    Catch
                    End Try
                End If

                worksheet_1.Activate()
                Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
                MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Datos Técnicos")
                excelApp.Visible = True

            ElseIf FrmDatosTecnicosNodo.nivel = 2 Then

                worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetHidden
                worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetVisible
                worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetHidden

                Dim totalFilas As Integer = grilla_datos_tecnicos.RowCount
                If totalFilas > 0 Then
                    If totalFilas > 1 Then
                        Dim rangoInsert As Excel.Range = worksheet_2.Range("B10:E" & (8 + totalFilas).ToString())
                        rangoInsert.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
                    End If

                    Dim arrDatos(totalFilas - 1, 3) As Object
                    For i As Integer = 0 To totalFilas - 1
                        arrDatos(i, 0) = grilla_datos_tecnicos.Rows(i).Cells(2).Value
                        arrDatos(i, 1) = grilla_datos_tecnicos.Rows(i).Cells(3).Value
                        arrDatos(i, 2) = grilla_datos_tecnicos.Rows(i).Cells(4).Value
                        arrDatos(i, 3) = grilla_datos_tecnicos.Rows(i).Cells(5).Value
                    Next

                    Dim rangoDestino As Excel.Range = worksheet_2.Range("B9:E" & (9 + totalFilas - 1).ToString())
                    rangoDestino.Value2 = arrDatos
                    Try
                        rangoDestino.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                        rangoDestino.Borders.Weight = Excel.XlBorderWeight.xlThin
                    Catch
                    End Try
                End If

                worksheet_2.Activate()
                Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
                MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Datos Técnicos")
                excelApp.Visible = True

            ElseIf FrmDatosTecnicosNodo.nivel = 1 Then

                worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetHidden
                worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetHidden
                worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetVisible

                Dim totalFilas As Integer = grilla_datos_tecnicos.RowCount
                If totalFilas > 0 Then
                    If totalFilas > 1 Then
                        Dim rangoInsert As Excel.Range = worksheet_3.Range("B10:F" & (8 + totalFilas).ToString())
                        rangoInsert.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
                    End If

                    Dim arrDatos(totalFilas - 1, 4) As Object
                    For i As Integer = 0 To totalFilas - 1
                        arrDatos(i, 0) = grilla_datos_tecnicos.Rows(i).Cells(2).Value
                        arrDatos(i, 1) = grilla_datos_tecnicos.Rows(i).Cells(3).Value
                        arrDatos(i, 2) = grilla_datos_tecnicos.Rows(i).Cells(4).Value
                        arrDatos(i, 3) = grilla_datos_tecnicos.Rows(i).Cells(5).Value
                        arrDatos(i, 4) = grilla_datos_tecnicos.Rows(i).Cells(6).Value
                    Next

                    Dim rangoDestino As Excel.Range = worksheet_3.Range("B9:F" & (9 + totalFilas - 1).ToString())
                    rangoDestino.Value2 = arrDatos
                    Try
                        rangoDestino.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                        rangoDestino.Borders.Weight = Excel.XlBorderWeight.xlThin
                    Catch
                    End Try
                End If

                worksheet_3.Activate()
                Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
                MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportar Datos Técnicos")
                excelApp.Visible = True
            Else
                Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
                Utilitarios.CerrarExcelEnError(excelApp, workbook)
            End If
        Catch ex As Exception
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            If grilla_datos_tecnicos IsNot Nothing AndAlso grilla_datos_tecnicos.RowCount > 0 AndAlso
               (Utilitarios.ExportarGrillaAExcelNativo(grilla_datos_tecnicos, "Datos_Tecnicos", "INFORME DE DATOS TÉCNICOS") OrElse Utilitarios.UltimaExportacionCancelada) Then
                Exit Sub
            End If
            RegistroErrores.MostrarYRegistrar(ex, "Exportar Informe Datos Técnicos")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Public Sub expInfListadoCiclo(ByVal grilla_ciclos_mp As DataGridView, ByVal fecha_desde As DateTime, ByVal fecha_hasta As DateTime)
        If grilla_ciclos_mp Is Nothing OrElse grilla_ciclos_mp.RowCount = 0 OrElse grilla_ciclos_mp.ColumnCount < 7 Then
            MsgBox("No hay ciclos válidos para exportar a Excel.", MsgBoxStyle.Exclamation, "Exportar Excel")
            Return
        End If
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet_1 As Excel.Worksheet = Nothing
        Dim num_mant As Integer = 0

        Try
            excelApp = New Excel.Application
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, True)
            workbook = Utilitarios.CrearLibroDesdePlantilla(excelApp, "inf_listado_ciclo_mp.xls")
            worksheet_1 = CType(workbook.Sheets(1), Excel.Worksheet)
            worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetVisible

            worksheet_1.Cells(6, 4).NumberFormat = "@"
            worksheet_1.Cells(7, 4).NumberFormat = "@"
            worksheet_1.Cells(6, 4) = fecha_desde.ToString("dd-MM-yyyy")
            worksheet_1.Cells(7, 4) = fecha_hasta.ToString("dd-MM-yyyy")

            Dim totalFilas As Integer = grilla_ciclos_mp.RowCount
            If totalFilas > 0 Then
                If totalFilas > 1 Then
                    Dim rangoInsert As Excel.Range = worksheet_1.Range("B12:H" & (10 + totalFilas).ToString())
                    rangoInsert.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown)
                End If

                Dim arrDatos(totalFilas - 1, 6) As Object
                For i As Integer = 0 To totalFilas - 1
                    For c As Integer = 0 To 6
                        Dim val As Object = grilla_ciclos_mp.Rows(i).Cells(c).Value
                        arrDatos(i, c) = If(val IsNot Nothing AndAlso Not IsDBNull(val), val.ToString(), "")
                    Next
                Next

                Dim rangoDestino As Excel.Range = worksheet_1.Range("B11:H" & (11 + totalFilas - 1).ToString())
                rangoDestino.Value2 = arrDatos
                Try
                    rangoDestino.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                    rangoDestino.Borders.Weight = Excel.XlBorderWeight.xlThin
                Catch
                End Try
            End If

            worksheet_1.Activate()
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            MsgBox(String.Format("Listado de Ciclos MP exportado exitosamente a Excel.{0}Total de registros: {1:N0}", vbCrLf, totalFilas), MsgBoxStyle.Information, "Exportación a Excel")
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.ConfigurarModoRapidoExcel(excelApp, False)
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            If grilla_ciclos_mp IsNot Nothing AndAlso grilla_ciclos_mp.RowCount > 0 AndAlso
               (Utilitarios.ExportarGrillaAExcelNativo(grilla_ciclos_mp, "Listado_Ciclos_MP", "LISTADO DE CICLOS MANTENCIÓN PREVENTIVA", "Período: " & fecha_desde.ToString("dd-MM-yyyy") & " al " & fecha_hasta.ToString("dd-MM-yyyy")) OrElse Utilitarios.UltimaExportacionCancelada) Then
                Exit Sub
            End If
            RegistroErrores.MostrarYRegistrar(ex, "Exportar Informe Listado Ciclo")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub
End Class
