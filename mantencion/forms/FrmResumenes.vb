Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmResumenes
    Public id_nodo_res_select As String
    Public nodo_anterior As String = ""
    Public nodo_anterior2 As String = ""
    Private _actualizandoChecks As Boolean = False

    ' Estructura interna para cálculo estadístico de equipos y componentes
    Private Class ItemEstadistico
        Public Property Nombre As String = ""
        Public Property Padre As String = ""
        Public Property Total As Integer = 0
        Public Property Cerradas As Integer = 0
        Public Property Abiertas As Integer = 0
    End Class

    ' Información de nodo para resolución dinámica en la jerarquía del árbol
    Private Class InfoNodoJerarquia
        Public Property Id As Integer
        Public Property PadreId As Integer
        Public Property Descripcion As String
        Public Property Nivel As Integer
    End Class

    Private Shared _dicJerarquiaNodosCache As Dictionary(Of Integer, InfoNodoJerarquia) = Nothing

    ''' <summary>
    ''' Carga y cachea la jerarquía completa de nodos desde la base de datos para una resolución ultra-rápida.
    ''' </summary>
    Private Shared Function ObtenerJerarquiaNodos() As Dictionary(Of Integer, InfoNodoJerarquia)
        If _dicJerarquiaNodosCache IsNot Nothing Then Return _dicJerarquiaNodosCache
        Dim dic As New Dictionary(Of Integer, InfoNodoJerarquia)
        Dim cnx As New SqlConnection
        Dim conexion As New Conexion
        Try
            conexion.Conectar(cnx)
            Using cmd As New SqlCommand("SELECT idnodo, nodo_padre, desc_nodo, nivel FROM nodo", cnx)
                cmd.CommandTimeout = 30
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        Dim id As Integer = Convert.ToInt32(dr(0))
                        Dim padre As Integer = If(IsDBNull(dr(1)), 0, Convert.ToInt32(dr(1)))
                        Dim desc As String = If(IsDBNull(dr(2)), "", dr(2).ToString().Trim())
                        Dim nivel As Integer = If(IsDBNull(dr(3)), 0, Convert.ToInt32(dr(3)))
                        dic(id) = New InfoNodoJerarquia With {
                            .Id = id,
                            .PadreId = padre,
                            .Descripcion = desc,
                            .Nivel = nivel
                        }
                    End While
                End Using
            End Using
            _dicJerarquiaNodosCache = dic
        Catch
            If _dicJerarquiaNodosCache IsNot Nothing Then Return _dicJerarquiaNodosCache
        Finally
            conexion.Desconectar(cnx)
        End Try
        Return dic
    End Function

    ''' <summary>
    ''' Resuelve dinámicamente la Máquina y el Componente de una OT respecto al nodo seleccionado en el árbol.
    ''' Ejemplo: si se selecciona EXTRUSION (padre), sub-nodo E-336-KI es la Máquina, y sub-nodo IBC es el Componente.
    ''' Si se selecciona directamente E-336-KI, la Máquina es E-336-KI y sus sub-nodos son los Componentes.
    ''' </summary>
    Private Sub ResolverMaquinaYComponente(ByVal dicJerarquia As Dictionary(Of Integer, InfoNodoJerarquia), _
                                          ByVal idNodoBase As Integer, _
                                          ByVal otIdNodo As Integer, _
                                          ByVal descNodoOT As String, _
                                          ByRef maquina As String, _
                                          ByRef componente As String)
        ' 1. Construir ruta de ancestros desde otIdNodo hacia arriba hasta idNodoBase
        Dim ruta As New List(Of InfoNodoJerarquia)
        Dim curId As Integer = otIdNodo

        While curId <> 0 AndAlso dicJerarquia.ContainsKey(curId)
            Dim nInfo As InfoNodoJerarquia = dicJerarquia(curId)
            ruta.Insert(0, nInfo)
            If curId = idNodoBase Then Exit While
            curId = nInfo.PadreId
        End While

        ' Si otIdNodo no conecta directamente con idNodoBase
        If ruta.Count = 0 OrElse ruta(0).Id <> idNodoBase Then
            Dim nodoNivel3 As InfoNodoJerarquia = ruta.Find(Function(x) x.Nivel = 3)
            If nodoNivel3 IsNot Nothing Then
                maquina = nodoNivel3.Descripcion
                If otIdNodo = nodoNivel3.Id Then
                    componente = "(General / Máquina)"
                Else
                    componente = If(ruta.Count > 0, ruta(ruta.Count - 1).Descripcion, descNodoOT)
                End If
            Else
                maquina = If(ruta.Count > 0, ruta(0).Descripcion, descNodoOT)
                componente = If(ruta.Count > 1, ruta(ruta.Count - 1).Descripcion, "(General)")
            End If
            Exit Sub
        End If

        ' 2. Analizar según la profundidad y nivel de idNodoBase
        Dim nodoBase As InfoNodoJerarquia = ruta(0)

        If nodoBase.Nivel <= 1 Then
            ' Raíz (nivel 1) o Planta: buscar el nodo de nivel 3 (máquina)
            Dim nodoMaq As InfoNodoJerarquia = ruta.Find(Function(x) x.Nivel = 3)
            If nodoMaq IsNot Nothing Then
                maquina = nodoMaq.Descripcion
                If otIdNodo = nodoMaq.Id Then
                    componente = "(General / Máquina)"
                Else
                    componente = ruta(ruta.Count - 1).Descripcion
                End If
            ElseIf ruta.Count >= 3 Then
                maquina = ruta(2).Descripcion
                componente = ruta(ruta.Count - 1).Descripcion
            ElseIf ruta.Count = 2 Then
                maquina = ruta(1).Descripcion
                componente = "(General / Máquina)"
            Else
                maquina = nodoBase.Descripcion
                componente = "(General)"
            End If

        ElseIf nodoBase.Nivel = 2 Then
            ' Sección (ej. EXTRUSIÓN, SELLADO):
            ' La máquina es el hijo directo bajo la sección (ej. E-336-KI)
            If ruta.Count = 1 Then
                maquina = nodoBase.Descripcion
                componente = "(General / Sección)"
            ElseIf ruta.Count = 2 Then
                maquina = ruta(1).Descripcion
                componente = "(General / Máquina)"
            Else
                maquina = ruta(1).Descripcion
                componente = ruta(ruta.Count - 1).Descripcion
            End If

        Else
            ' Máquina (Nivel >= 3, ej. E-336-KI) o sub-nodo
            maquina = nodoBase.Descripcion
            If ruta.Count = 1 Then
                componente = "(General / Máquina)"
            Else
                componente = ruta(ruta.Count - 1).Descripcion
            End If
        End If

        If String.IsNullOrEmpty(maquina) Then maquina = descNodoOT
        If String.IsNullOrEmpty(componente) Then componente = "(General)"
    End Sub

    Private Sub arbol7_AfterCheck(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles arbol7.AfterCheck
        If _actualizandoChecks Then Exit Sub
        Try
            _actualizandoChecks = True
            MarcarHijos(e.Node, e.Node.Checked)
        Finally
            _actualizandoChecks = False
        End Try
    End Sub

    Private Sub MarcarHijos(ByVal nodoPadre As TreeNode, ByVal estado As Boolean)
        If nodoPadre Is Nothing Then Exit Sub
        For Each hijo As TreeNode In nodoPadre.Nodes
            hijo.Checked = estado
            MarcarHijos(hijo, estado)
        Next
    End Sub

    Public Function ObtenerNodosObjetivo() As List(Of TreeNode)
        Dim lista As New List(Of TreeNode)()
        RecolectarNodosRaizCheckeados(arbol7.Nodes, lista)
        If lista.Count = 0 AndAlso arbol7.SelectedNode IsNot Nothing AndAlso Not String.IsNullOrEmpty(arbol7.SelectedNode.Name) Then
            lista.Add(arbol7.SelectedNode)
        End If
        Return lista
    End Function

    Private Sub RecolectarNodosRaizCheckeados(ByVal nodos As TreeNodeCollection, ByVal lista As List(Of TreeNode))
        If nodos Is Nothing Then Exit Sub
        For Each n As TreeNode In nodos
            If n.Checked Then
                lista.Add(n)
            Else
                RecolectarNodosRaizCheckeados(n.Nodes, lista)
            End If
        Next
    End Sub

    Private Sub SumarDataSetsResumen(ByVal dstDestino As DataSet, ByVal dstOrigen As DataSet)
        If dstOrigen Is Nothing OrElse dstOrigen.Tables.Count = 0 OrElse dstOrigen.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim dtOrigen As DataTable = dstOrigen.Tables(0)
        If dstDestino.Tables.Count = 0 Then
            dstDestino.Tables.Add(dtOrigen.Copy())
            Exit Sub
        End If
        Dim dtDestino As DataTable = dstDestino.Tables(0)

        Dim dict As New Dictionary(Of String, DataRow)(StringComparer.OrdinalIgnoreCase)
        For Each r As DataRow In dtDestino.Rows
            Dim k As String = r(0).ToString().Trim()
            If Not dict.ContainsKey(k) Then dict(k) = r
        Next

        For Each rOrg As DataRow In dtOrigen.Rows
            Dim k As String = rOrg(0).ToString().Trim()
            Dim cantidad As Integer = 0
            If Not IsDBNull(rOrg(1)) Then Integer.TryParse(rOrg(1).ToString(), cantidad)

            Dim rDest As DataRow = Nothing
            If dict.TryGetValue(k, rDest) Then
                Dim actual As Integer = 0
                If Not IsDBNull(rDest(1)) Then Integer.TryParse(rDest(1).ToString(), actual)
                rDest(1) = actual + cantidad
            Else
                Dim nueva As DataRow = dtDestino.NewRow()
                nueva(0) = rOrg(0)
                nueva(1) = cantidad
                dtDestino.Rows.Add(nueva)
                dict(k) = nueva
            End If
        Next
    End Sub

    Private Sub FusionarDataSetsOT(ByVal dstDestino As DataSet, ByVal dstOrigen As DataSet, ByVal otsExistentes As HashSet(Of String))
        If dstOrigen Is Nothing OrElse dstOrigen.Tables.Count = 0 OrElse dstOrigen.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim dtOrigen As DataTable = dstOrigen.Tables(0)
        If dstDestino.Tables.Count = 0 Then
            dstDestino.Tables.Add(dtOrigen.Clone())
        End If
        Dim dtDestino As DataTable = dstDestino.Tables(0)
        dtDestino.BeginLoadData()
        For Each fila As DataRow In dtOrigen.Rows
            Dim numOt As String = fila(0).ToString().Trim()
            If otsExistentes.Add(numOt) Then
                dtDestino.ImportRow(fila)
            End If
        Next
        dtDestino.EndLoadData()
    End Sub

    Private Sub FrmResumenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nodoRaiz As New TreeNode
        Dim nd As New Nodo

        nodoRaiz.Name = "1"
        nodoRaiz.Text = "Cambiaso Hnos S.A."
        nd.CRG_NODO_HIJO(nodoRaiz)
        arbol7.Nodes.Add(nodoRaiz)
        grpDesglose.Enabled = False

        ' Inicializar estilos modernos en grillas
        Dim formato As New FormatoGrillas()
        formato.grillasOT(grillaTopMaquinas)
        formato.grillasOT(grillaTopComponentes)
        formato.grillasOT(grillaOtCerradaPorTec)
        formato.grillasOT(grillaOtRecibidaPor)
        formato.grillasOT(grillaOtPorTipoFalla)
        formato.grillasOT(grillaOtPorTurno)
        formato.grillasOT(grillaTotalesPeriodo)
        formato.grillasOT(grillaOtPorDia)
        formato.grillasOT(grillaOtPorMes)
    End Sub

    Private Sub btnBuscarRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarRes.Click
        Dim OT As New OT
        Dim DST_RES_POR As New DataSet
        Dim DST_CERRADA_X_TEC As New DataSet
        Dim DST_OT_X_DIA As New DataSet
        Dim DST_OT_X_MES As New DataSet
        Dim DST_OT_X_TURNO As New DataSet
        Dim DST_OT_X_TIPO_FALLA As New DataSet
        Dim DST_OT_X_ESTADO As New DataSet
        Dim DST_TODAS_OT As New DataSet
        Dim otsExistentes As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        Dim nodosObjetivo As List(Of TreeNode) = ObtenerNodosObjetivo()
        If nodosObjetivo.Count = 0 Then
            MsgBox("Debe seleccionar uno o más ítems antes de buscar", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        id_nodo_res_select = nodosObjetivo(0).Name
        Cursor = Cursors.WaitCursor

        Try
            Dim dicJerarquia As Dictionary(Of Integer, InfoNodoJerarquia) = ObtenerJerarquiaNodos()
            Dim dicMaquinas As New Dictionary(Of String, ItemEstadistico)(StringComparer.OrdinalIgnoreCase)
            Dim dicComponentes As New Dictionary(Of String, ItemEstadistico)(StringComparer.OrdinalIgnoreCase)
            Dim dicComponentesGeneral As New Dictionary(Of String, ItemEstadistico)(StringComparer.OrdinalIgnoreCase)
            Dim totalOtDetalle As Integer = 0
            Dim totalCerradasDetalle As Integer = 0
            Dim totalAbiertasDetalle As Integer = 0

            For Each nd As TreeNode In nodosObjetivo
                Dim idNodoBase As Integer = 1
                Integer.TryParse(nd.Name, idNodoBase)

                Dim DST_TEMP_RES As New DataSet
                Dim DST_TEMP_CERR As New DataSet
                Dim DST_TEMP_DIA As New DataSet
                Dim DST_TEMP_MES As New DataSet
                Dim DST_TEMP_TURNO As New DataSet
                Dim DST_TEMP_FALLA As New DataSet
                Dim DST_TEMP_EST As New DataSet
                Dim dtNodosOT As New DataTable()

                ' Consultas agregadas del sistema
                OT.infOtResRecibidaPor(nd.Name, fecha_ini_resumen.Value, fecha_fin_resumen.Value, DST_TEMP_RES)
                OT.infOtResCerradaPorTecnico(nd.Name, fecha_ini_resumen.Value, fecha_fin_resumen.Value, DST_TEMP_CERR)
                OT.infOtResPorDia(nd.Name, fecha_ini_resumen.Value, fecha_fin_resumen.Value, DST_TEMP_DIA)
                OT.infOtResPorMes(nd.Name, fecha_ini_resumen.Value, fecha_fin_resumen.Value, DST_TEMP_MES)
                OT.infOtResPorTurno(nd.Name, fecha_ini_resumen.Value, fecha_fin_resumen.Value, DST_TEMP_TURNO)
                OT.infOtPorTipoFalla(nd.Name, fecha_ini_resumen.Value, fecha_fin_resumen.Value, DST_TEMP_FALLA)
                OT.infOtPorEstado(nd.Name, fecha_ini_resumen.Value, fecha_fin_resumen.Value, DST_TEMP_EST)

                ' Consulta recursiva precisa de OTs con idnodo y estado (activas e históricas)
                OT.infOtConNodos(nd.Name, fecha_ini_resumen.Value, fecha_fin_resumen.Value, dtNodosOT)

                For Each r As DataRow In dtNodosOT.Rows
                    Dim numOt As String = r("num_ot").ToString().Trim()
                    If otsExistentes.Add(numOt) Then
                        totalOtDetalle += 1
                        Dim otIdNodo As Integer = Convert.ToInt32(r("idnodo"))
                        Dim descNodoOT As String = If(IsDBNull(r("desc_nodo")), "", r("desc_nodo").ToString().Trim())
                        Dim estado As String = If(IsDBNull(r("estado")), "", r("estado").ToString().Trim().ToLower())
                        Dim isCerrada As Boolean = (estado = "cerrada")

                        If isCerrada Then
                            totalCerradasDetalle += 1
                        Else
                            totalAbiertasDetalle += 1
                        End If

                        ' Resolver dinámicamente la máquina y el componente según el nodo seleccionado
                        Dim maq As String = ""
                        Dim comp As String = ""
                        ResolverMaquinaYComponente(dicJerarquia, idNodoBase, otIdNodo, descNodoOT, maq, comp)

                        ' Acumular en máquina
                        Dim itemM As ItemEstadistico = Nothing
                        If Not dicMaquinas.TryGetValue(maq, itemM) Then
                            itemM = New ItemEstadistico With {.Nombre = maq}
                            dicMaquinas(maq) = itemM
                        End If
                        itemM.Total += 1
                        If isCerrada Then itemM.Cerradas += 1 Else itemM.Abiertas += 1

                        ' Acumular en componente
                        If Not comp.StartsWith("(General", StringComparison.OrdinalIgnoreCase) Then
                            Dim keyComp As String = comp & " [" & maq & "]"
                            Dim itemC As ItemEstadistico = Nothing
                            If Not dicComponentes.TryGetValue(keyComp, itemC) Then
                                itemC = New ItemEstadistico With {.Nombre = comp, .Padre = maq}
                                dicComponentes(keyComp) = itemC
                            End If
                            itemC.Total += 1
                            If isCerrada Then itemC.Cerradas += 1 Else itemC.Abiertas += 1
                        Else
                            Dim keyCompGen As String = comp & " [" & maq & "]"
                            Dim itemCG As ItemEstadistico = Nothing
                            If Not dicComponentesGeneral.TryGetValue(keyCompGen, itemCG) Then
                                itemCG = New ItemEstadistico With {.Nombre = comp, .Padre = maq}
                                dicComponentesGeneral(keyCompGen) = itemCG
                            End If
                            itemCG.Total += 1
                            If isCerrada Then itemCG.Cerradas += 1 Else itemCG.Abiertas += 1
                        End If
                    End If
                Next

                SumarDataSetsResumen(DST_RES_POR, DST_TEMP_RES)
                SumarDataSetsResumen(DST_CERRADA_X_TEC, DST_TEMP_CERR)
                SumarDataSetsResumen(DST_OT_X_DIA, DST_TEMP_DIA)
                SumarDataSetsResumen(DST_OT_X_MES, DST_TEMP_MES)
                SumarDataSetsResumen(DST_OT_X_TURNO, DST_TEMP_TURNO)
                SumarDataSetsResumen(DST_OT_X_TIPO_FALLA, DST_TEMP_FALLA)
                SumarDataSetsResumen(DST_OT_X_ESTADO, DST_TEMP_EST)

                DST_TEMP_RES.Dispose()
                DST_TEMP_CERR.Dispose()
                DST_TEMP_DIA.Dispose()
                DST_TEMP_MES.Dispose()
                DST_TEMP_TURNO.Dispose()
                DST_TEMP_FALLA.Dispose()
                DST_TEMP_EST.Dispose()
                dtNodosOT.Dispose()
            Next

            If dicComponentes.Count = 0 AndAlso dicComponentesGeneral.Count > 0 Then
                dicComponentes = dicComponentesGeneral
            End If

            ' Generar DataTable Top Máquinas
            Dim dtTopMaquinas As New DataTable("TopMaquinas")
            dtTopMaquinas.Columns.Add("Ranking", GetType(Integer))
            dtTopMaquinas.Columns.Add("Máquina / Equipo", GetType(String))
            dtTopMaquinas.Columns.Add("Total OTs", GetType(Integer))
            dtTopMaquinas.Columns.Add("% Participación", GetType(String))
            dtTopMaquinas.Columns.Add("OTs Cerradas", GetType(Integer))
            dtTopMaquinas.Columns.Add("OTs Abiertas", GetType(Integer))
            dtTopMaquinas.Columns.Add("% Resueltas", GetType(String))

            Dim listaMaq As New List(Of ItemEstadistico)(dicMaquinas.Values)
            listaMaq.Sort(Function(a, b) b.Total.CompareTo(a.Total))

            Dim rankM As Integer = 1
            For Each itm In listaMaq
                Dim pctPart As Double = If(totalOtDetalle > 0, Math.Round((itm.Total / CDbl(totalOtDetalle)) * 100, 1), 0)
                Dim pctEfic As Double = If(itm.Total > 0, Math.Round((itm.Cerradas / CDbl(itm.Total)) * 100, 1), 0)
                dtTopMaquinas.Rows.Add(rankM, itm.Nombre, itm.Total, pctPart.ToString("0.0") & " %", itm.Cerradas, itm.Abiertas, pctEfic.ToString("0.0") & " %")
                rankM += 1
            Next
            grillaTopMaquinas.DataSource = dtTopMaquinas

            ' Generar DataTable Top Componentes
            Dim dtTopComponentes As New DataTable("TopComponentes")
            dtTopComponentes.Columns.Add("Ranking", GetType(Integer))
            dtTopComponentes.Columns.Add("Componente / Parte", GetType(String))
            dtTopComponentes.Columns.Add("Máquina Asociada", GetType(String))
            dtTopComponentes.Columns.Add("Total OTs", GetType(Integer))
            dtTopComponentes.Columns.Add("% Participación", GetType(String))
            dtTopComponentes.Columns.Add("OTs Cerradas", GetType(Integer))
            dtTopComponentes.Columns.Add("OTs Abiertas", GetType(Integer))

            Dim listaComp As New List(Of ItemEstadistico)(dicComponentes.Values)
            listaComp.Sort(Function(a, b) b.Total.CompareTo(a.Total))

            Dim rankC As Integer = 1
            For Each itm In listaComp
                Dim pctPart As Double = If(totalOtDetalle > 0, Math.Round((itm.Total / CDbl(totalOtDetalle)) * 100, 1), 0)
                dtTopComponentes.Rows.Add(rankC, itm.Nombre, itm.Padre, itm.Total, pctPart.ToString("0.0") & " %", itm.Cerradas, itm.Abiertas)
                rankC += 1
            Next
            grillaTopComponentes.DataSource = dtTopComponentes

            ' -------------------------------------------------------------------------------------------------------
            ' 2. PERSONAL CON MÁS ÓRDENES CERRADAS (TÉCNICOS) CON RANKING Y PORCENTAJES
            ' -------------------------------------------------------------------------------------------------------
            Dim dtCerradasTec As New DataTable("CerradasPorTec")
            dtCerradasTec.Columns.Add("Ranking", GetType(Integer))
            dtCerradasTec.Columns.Add("Técnico / Personal", GetType(String))
            dtCerradasTec.Columns.Add("OTs Cerradas", GetType(Integer))
            dtCerradasTec.Columns.Add("% del Total Cerradas", GetType(String))

            Dim totalOtCerradasTec As Integer = 0
            If DST_CERRADA_X_TEC.Tables.Count > 0 Then
                For Each r As DataRow In DST_CERRADA_X_TEC.Tables(0).Rows
                    Dim cant As Integer = 0
                    If Not IsDBNull(r(1)) Then Integer.TryParse(r(1).ToString(), cant)
                    totalOtCerradasTec += cant
                Next

                Dim dvCerr As New DataView(DST_CERRADA_X_TEC.Tables(0))
                If dvCerr.Table.Columns.Count >= 2 Then
                    dvCerr.Sort = dvCerr.Table.Columns(1).ColumnName & " DESC"
                End If

                Dim rankT As Integer = 1
                For Each drv As DataRowView In dvCerr
                    Dim nom As String = drv(0).ToString().Trim()
                    Dim cant As Integer = 0
                    If Not IsDBNull(drv(1)) Then Integer.TryParse(drv(1).ToString(), cant)
                    Dim pct As Double = If(totalOtCerradasTec > 0, Math.Round((cant / CDbl(totalOtCerradasTec)) * 100, 1), 0)
                    dtCerradasTec.Rows.Add(rankT, nom, cant, pct.ToString("0.0") & " %")
                    rankT += 1
                Next
            End If
            grillaOtCerradaPorTec.DataSource = dtCerradasTec

            ' -------------------------------------------------------------------------------------------------------
            ' 3. PERSONAL QUE RECIBIÓ ÓRDENES CON RANKING Y PORCENTAJES
            ' -------------------------------------------------------------------------------------------------------
            Dim dtRecibidas As New DataTable("RecibidasPor")
            dtRecibidas.Columns.Add("Ranking", GetType(Integer))
            dtRecibidas.Columns.Add("Recibido Por", GetType(String))
            dtRecibidas.Columns.Add("Cantidad OTs", GetType(Integer))
            dtRecibidas.Columns.Add("% del Total", GetType(String))

            Dim totalRecibidas As Integer = 0
            If DST_RES_POR.Tables.Count > 0 Then
                For Each r As DataRow In DST_RES_POR.Tables(0).Rows
                    Dim cant As Integer = 0
                    If Not IsDBNull(r(1)) Then Integer.TryParse(r(1).ToString(), cant)
                    totalRecibidas += cant
                Next

                Dim dvRec As New DataView(DST_RES_POR.Tables(0))
                If dvRec.Table.Columns.Count >= 2 Then
                    dvRec.Sort = dvRec.Table.Columns(1).ColumnName & " DESC"
                End If

                Dim rankR As Integer = 1
                For Each drv As DataRowView In dvRec
                    Dim nom As String = drv(0).ToString().Trim()
                    Dim cant As Integer = 0
                    If Not IsDBNull(drv(1)) Then Integer.TryParse(drv(1).ToString(), cant)
                    Dim pct As Double = If(totalRecibidas > 0, Math.Round((cant / CDbl(totalRecibidas)) * 100, 1), 0)
                    dtRecibidas.Rows.Add(rankR, nom, cant, pct.ToString("0.0") & " %")
                    rankR += 1
                Next
            End If
            grillaOtRecibidaPor.DataSource = dtRecibidas

            ' -------------------------------------------------------------------------------------------------------
            ' 4. DESGLOSE OPERACIONAL (FALLAS, TURNOS Y ESTADOS) CON PORCENTAJES
            ' -------------------------------------------------------------------------------------------------------
            ' Tipo de Falla
            Dim dtTipoFalla As New DataTable("TipoFalla")
            dtTipoFalla.Columns.Add("Tipo de Trabajo / Falla", GetType(String))
            dtTipoFalla.Columns.Add("Cantidad OTs", GetType(Integer))
            dtTipoFalla.Columns.Add("% del Total", GetType(String))

            Dim totalFallas As Integer = 0
            If DST_OT_X_TIPO_FALLA.Tables.Count > 0 Then
                For Each r As DataRow In DST_OT_X_TIPO_FALLA.Tables(0).Rows
                    Dim cant As Integer = 0
                    If Not IsDBNull(r(1)) Then Integer.TryParse(r(1).ToString(), cant)
                    totalFallas += cant
                Next
                For Each r As DataRow In DST_OT_X_TIPO_FALLA.Tables(0).Rows
                    Dim nom As String = r(0).ToString().Trim()
                    Dim cant As Integer = 0
                    If Not IsDBNull(r(1)) Then Integer.TryParse(r(1).ToString(), cant)
                    Dim pct As Double = If(totalFallas > 0, Math.Round((cant / CDbl(totalFallas)) * 100, 1), 0)
                    dtTipoFalla.Rows.Add(nom, cant, pct.ToString("0.0") & " %")
                Next
            End If
            grillaOtPorTipoFalla.DataSource = dtTipoFalla

            ' Turnos
            Dim dtTurnos As New DataTable("Turnos")
            dtTurnos.Columns.Add("Turno", GetType(String))
            dtTurnos.Columns.Add("Cantidad OTs", GetType(Integer))
            dtTurnos.Columns.Add("% del Total", GetType(String))

            Dim totalTurnos As Integer = 0
            If DST_OT_X_TURNO.Tables.Count > 0 Then
                For Each r As DataRow In DST_OT_X_TURNO.Tables(0).Rows
                    Dim cant As Integer = 0
                    If Not IsDBNull(r(1)) Then Integer.TryParse(r(1).ToString(), cant)
                    totalTurnos += cant
                Next
                For Each r As DataRow In DST_OT_X_TURNO.Tables(0).Rows
                    Dim nom As String = r(0).ToString().Trim()
                    Dim cant As Integer = 0
                    If Not IsDBNull(r(1)) Then Integer.TryParse(r(1).ToString(), cant)
                    Dim pct As Double = If(totalTurnos > 0, Math.Round((cant / CDbl(totalTurnos)) * 100, 1), 0)
                    dtTurnos.Rows.Add(nom, cant, pct.ToString("0.0") & " %")
                Next
            End If
            grillaOtPorTurno.DataSource = dtTurnos

            ' Totales por Estado
            Dim dtEstados As New DataTable("Estados")
            dtEstados.Columns.Add("Estado", GetType(String))
            dtEstados.Columns.Add("Cantidad OTs", GetType(Integer))
            dtEstados.Columns.Add("% del Total", GetType(String))

            Dim totalOtEstado As Integer = 0
            If DST_OT_X_ESTADO.Tables.Count > 0 Then
                For Each r As DataRow In DST_OT_X_ESTADO.Tables(0).Rows
                    Dim cant As Integer = 0
                    If Not IsDBNull(r(1)) Then Integer.TryParse(r(1).ToString(), cant)
                    totalOtEstado += cant
                Next
                For Each r As DataRow In DST_OT_X_ESTADO.Tables(0).Rows
                    Dim nom As String = r(0).ToString().Trim()
                    Dim cant As Integer = 0
                    If Not IsDBNull(r(1)) Then Integer.TryParse(r(1).ToString(), cant)
                    Dim pct As Double = If(totalOtEstado > 0, Math.Round((cant / CDbl(totalOtEstado)) * 100, 1), 0)
                    dtEstados.Rows.Add(nom, cant, pct.ToString("0.0") & " %")
                Next
                ' Fila resumen total
                dtEstados.Rows.Add("Total General", totalOtEstado, "100.0 %")
            End If
            grillaTotalesPeriodo.DataSource = dtEstados
            If grillaTotalesPeriodo.RowCount > 0 Then
                grillaTotalesPeriodo.Rows(grillaTotalesPeriodo.RowCount - 1).DefaultCellStyle.BackColor = Utilitarios.ColorFondoSoloLectura
                grillaTotalesPeriodo.Rows(grillaTotalesPeriodo.RowCount - 1).DefaultCellStyle.Font = New Font("Calibri", 9.5F, FontStyle.Bold)
            End If

            ' -------------------------------------------------------------------------------------------------------
            ' 5. TENDENCIA TEMPORAL (DÍA Y MES) CON PORCENTAJES
            ' -------------------------------------------------------------------------------------------------------
            Dim dtDia As New DataTable("PorDia")
            dtDia.Columns.Add("Fecha", GetType(String))
            dtDia.Columns.Add("Cantidad OTs", GetType(Integer))
            dtDia.Columns.Add("% Período", GetType(String))

            Dim totalDias As Integer = 0
            If DST_OT_X_DIA.Tables.Count > 0 Then
                For Each r As DataRow In DST_OT_X_DIA.Tables(0).Rows
                    Dim cant As Integer = 0
                    If Not IsDBNull(r(1)) Then Integer.TryParse(r(1).ToString(), cant)
                    totalDias += cant
                Next
                For Each r As DataRow In DST_OT_X_DIA.Tables(0).Rows
                    Dim fechaStr As String = r(0).ToString().Trim()
                    Dim cant As Integer = 0
                    If Not IsDBNull(r(1)) Then Integer.TryParse(r(1).ToString(), cant)
                    Dim pct As Double = If(totalDias > 0, Math.Round((cant / CDbl(totalDias)) * 100, 1), 0)
                    dtDia.Rows.Add(fechaStr, cant, pct.ToString("0.0") & " %")
                Next
            End If
            grillaOtPorDia.DataSource = dtDia

            Dim dtMes As New DataTable("PorMes")
            dtMes.Columns.Add("Mes", GetType(String))
            dtMes.Columns.Add("Cantidad OTs", GetType(Integer))
            dtMes.Columns.Add("% Período", GetType(String))

            Dim totalMeses As Integer = 0
            If DST_OT_X_MES.Tables.Count > 0 Then
                For Each r As DataRow In DST_OT_X_MES.Tables(0).Rows
                    Dim cant As Integer = 0
                    If Not IsDBNull(r(1)) Then Integer.TryParse(r(1).ToString(), cant)
                    totalMeses += cant
                Next
                For Each r As DataRow In DST_OT_X_MES.Tables(0).Rows
                    Dim mesStr As String = r(0).ToString().Trim()
                    Dim cant As Integer = 0
                    If Not IsDBNull(r(1)) Then Integer.TryParse(r(1).ToString(), cant)
                    Dim pct As Double = If(totalMeses > 0, Math.Round((cant / CDbl(totalMeses)) * 100, 1), 0)
                    dtMes.Rows.Add(mesStr, cant, pct.ToString("0.0") & " %")
                Next
            End If
            grillaOtPorMes.DataSource = dtMes

            ' -------------------------------------------------------------------------------------------------------
            ' 6. ACTUALIZACIÓN DE TARJETAS KPI RESUMEN SUPERIOR
            ' -------------------------------------------------------------------------------------------------------
            Dim totalGeneralOts As Integer = Math.Max(totalOtDetalle, totalOtEstado)
            Dim totalCerradasFinal As Integer = Math.Max(totalCerradasDetalle, totalOtCerradasTec)
            Dim totalAbiertasFinal As Integer = Math.Max(0, totalGeneralOts - totalCerradasFinal)

            Dim pctCerradas As Double = If(totalGeneralOts > 0, Math.Round((totalCerradasFinal / CDbl(totalGeneralOts)) * 100, 1), 0)
            Dim pctAbiertas As Double = If(totalGeneralOts > 0, Math.Round((totalAbiertasFinal / CDbl(totalGeneralOts)) * 100, 1), 0)

            lblKpiTotal.Text = totalGeneralOts.ToString("N0") & " OTs"
            lblKpiCerradas.Text = totalCerradasFinal.ToString("N0") & " (" & pctCerradas.ToString("0.0") & "%)"
            lblKpiAbiertas.Text = totalAbiertasFinal.ToString("N0") & " (" & pctAbiertas.ToString("0.0") & "%)"

            If dtTopMaquinas.Rows.Count > 0 Then
                lblKpiTopMaquina.Text = dtTopMaquinas.Rows(0)("Máquina / Equipo").ToString() & " (" & dtTopMaquinas.Rows(0)("Total OTs").ToString() & " OTs)"
            Else
                lblKpiTopMaquina.Text = "-"
            End If

            If dtTopComponentes.Rows.Count > 0 Then
                lblKpiTopComponente.Text = dtTopComponentes.Rows(0)("Componente / Parte").ToString() & " [" & dtTopComponentes.Rows(0)("Máquina Asociada").ToString() & "] (" & dtTopComponentes.Rows(0)("Total OTs").ToString() & " OTs)"
            Else
                lblKpiTopComponente.Text = "-"
            End If

            If dtCerradasTec.Rows.Count > 0 Then
                lblKpiTopTecnico.Text = dtCerradasTec.Rows(0)("Técnico / Personal").ToString() & " (" & dtCerradasTec.Rows(0)("OTs Cerradas").ToString() & " OTs)"
            Else
                lblKpiTopTecnico.Text = "-"
            End If

            grpDesglose.Enabled = True

            ' Autoajuste de columnas en todas las grillas para presentación responsiva
            Utilitarios.AjustarColumnasGrilla(grillaTopMaquinas)
            Utilitarios.AjustarColumnasGrilla(grillaTopComponentes)
            Utilitarios.AjustarColumnasGrilla(grillaOtCerradaPorTec)
            Utilitarios.AjustarColumnasGrilla(grillaOtRecibidaPor)
            Utilitarios.AjustarColumnasGrilla(grillaOtPorTipoFalla)
            Utilitarios.AjustarColumnasGrilla(grillaOtPorTurno)
            Utilitarios.AjustarColumnasGrilla(grillaTotalesPeriodo)
            Utilitarios.AjustarColumnasGrilla(grillaOtPorDia)
            Utilitarios.AjustarColumnasGrilla(grillaOtPorMes)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Cursor = Cursors.Default
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Private Sub btnSalirRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirRes.Click
        Me.Close()
    End Sub

    Private Sub arbol7_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles arbol7.AfterSelect
        If arbol7.SelectedNode Is Nothing Then Exit Sub
        id_nodo_res_select = arbol7.SelectedNode.Name
        nodo_anterior2 = id_nodo_res_select
        arbol7.SelectedNode.BackColor = Utilitarios.ColorSeleccion
    End Sub

    Private Sub txtBuscarNodo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarNodo.KeyUp
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(arbol7, txtBuscarNodo, e, id_nodo_res_select, nodo_anterior, 2)
    End Sub

    Private Sub txtBuscarNodo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarNodo.TextChanged
        Dim nodo As New Nodo
        nodo.BuscarYSeleccionarNodoArbol(arbol7, txtBuscarNodo, Nothing, id_nodo_res_select, nodo_anterior, 2)
    End Sub

    Private Sub arbol7_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles arbol7.BeforeSelect
        Nodo.LimpiarResaltadoNodos(arbol7.Nodes)
    End Sub

    Private Sub btn_exp_excel_res_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exp_excel_res.Click
        Dim informe As New Informes
        Try
            informe.expInfEstadistica(fecha_ini_resumen.Value, fecha_fin_resumen.Value)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grillaOtRecibidaPor_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaOtRecibidaPor.CellContentDoubleClick
        If grillaOtRecibidaPor.RowCount = 0 Then
            MsgBox("Debe buscar datos antes de ver el detalle", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Try
            Dim colNom As Integer = If(grillaOtRecibidaPor.Columns.Contains("Recibido Por"), grillaOtRecibidaPor.Columns("Recibido Por").Index, 0)
            FrmDetalleOtPendientes.personal = grillaOtRecibidaPor.Rows(grillaOtRecibidaPor.CurrentRow.Index).Cells(colNom).Value
            FrmDetalleOtPendientes.fecha_inicio = fecha_ini_resumen.Value
            FrmDetalleOtPendientes.fecha_termino = fecha_fin_resumen.Value
            FrmDetalleOtPendientes.opcion = 1
            FrmDetalleOtPendientes.nodo_padre = id_nodo_res_select
            FrmDetalleOtPendientes.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub opc_totales_estado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opc_totales_estado.CheckedChanged, opc_por_mes.CheckedChanged
        If opc_totales_estado.Checked Then
            tabResumenes.SelectedTab = tabOperacional
        Else
            tabResumenes.SelectedTab = tabTemporal
        End If
    End Sub

    Private Sub grillaOtCerradaPorTec_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaOtCerradaPorTec.CellContentDoubleClick
        If grillaOtCerradaPorTec.RowCount = 0 Then
            MsgBox("Debe buscar datos antes de ver el detalle", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Try
            Dim colNom As Integer = If(grillaOtCerradaPorTec.Columns.Contains("Técnico / Personal"), grillaOtCerradaPorTec.Columns("Técnico / Personal").Index, 0)
            FrmDetalleOTPorTecnico.personal = grillaOtCerradaPorTec.Rows(grillaOtCerradaPorTec.CurrentRow.Index).Cells(colNom).Value
            FrmDetalleOTPorTecnico.fecha_inicio = fecha_ini_resumen.Value
            FrmDetalleOTPorTecnico.fecha_termino = fecha_fin_resumen.Value
            FrmDetalleOTPorTecnico.opcion = 2
            FrmDetalleOTPorTecnico.nodo_padre = id_nodo_res_select
            FrmDetalleOTPorTecnico.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grillaOtPorTipoFalla_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaOtPorTipoFalla.CellContentDoubleClick
        If grillaOtPorTipoFalla.RowCount = 0 Then
            MsgBox("Debe buscar datos antes de ver el detalle", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Try
            Dim colNom As Integer = If(grillaOtPorTipoFalla.Columns.Contains("Tipo de Trabajo / Falla"), grillaOtPorTipoFalla.Columns("Tipo de Trabajo / Falla").Index, 0)
            FrmDetalleOtTipoFalla.tipo_falla = grillaOtPorTipoFalla.Rows(grillaOtPorTipoFalla.CurrentRow.Index).Cells(colNom).Value
            FrmDetalleOtTipoFalla.fecha_inicio = fecha_ini_resumen.Value
            FrmDetalleOtTipoFalla.fecha_termino = fecha_fin_resumen.Value
            FrmDetalleOtTipoFalla.opcion = 3
            FrmDetalleOtTipoFalla.nodo_padre = id_nodo_res_select
            FrmDetalleOtTipoFalla.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grillaOtPorTurno_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaOtPorTurno.CellContentDoubleClick
        If grillaOtPorTurno.RowCount = 0 Then
            MsgBox("Debe buscar datos antes de ver el detalle", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Try
            Dim colNom As Integer = If(grillaOtPorTurno.Columns.Contains("Turno"), grillaOtPorTurno.Columns("Turno").Index, 0)
            FrmDetalleOtTurno.turno = grillaOtPorTurno.Rows(grillaOtPorTurno.CurrentRow.Index).Cells(colNom).Value
            FrmDetalleOtTurno.fecha_inicio = fecha_ini_resumen.Value
            FrmDetalleOtTurno.fecha_termino = fecha_fin_resumen.Value
            FrmDetalleOtTurno.opcion = 4
            FrmDetalleOtTurno.nodo_padre = id_nodo_res_select
            FrmDetalleOtTurno.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grillaOtPorDia_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaOtPorDia.CellContentDoubleClick
        If grillaOtPorDia.RowCount = 0 Then
            MsgBox("Debe buscar datos antes de ver el detalle", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Try
            Dim colNom As Integer = If(grillaOtPorDia.Columns.Contains("Fecha"), grillaOtPorDia.Columns("Fecha").Index, 0)
            FrmDetalleOTDia.fecha_inicio = fecha_ini_resumen.Value
            FrmDetalleOTDia.fecha_termino = fecha_fin_resumen.Value
            FrmDetalleOTDia.fecha = grillaOtPorDia.Rows(grillaOtPorDia.CurrentRow.Index).Cells(colNom).Value
            FrmDetalleOTDia.opcion = 5
            FrmDetalleOTDia.nodo_padre = id_nodo_res_select
            FrmDetalleOTDia.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub grillaTotalesPeriodo_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaTotalesPeriodo.CellContentDoubleClick
        If grillaTotalesPeriodo.RowCount = 0 Then
            MsgBox("Debe buscar datos antes de ver el detalle", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If

        Try
            Dim colNom As Integer = If(grillaTotalesPeriodo.Columns.Contains("Estado"), grillaTotalesPeriodo.Columns("Estado").Index, 0)
            Dim estadoVal As String = grillaTotalesPeriodo.Rows(grillaTotalesPeriodo.CurrentRow.Index).Cells(colNom).Value.ToString()
            If Not estadoVal.StartsWith("Total", StringComparison.OrdinalIgnoreCase) Then
                FrmDetalleOtEstado.fecha_inicio = fecha_ini_resumen.Value
                FrmDetalleOtEstado.fecha_termino = fecha_fin_resumen.Value
                FrmDetalleOtEstado.estado = estadoVal
                FrmDetalleOtEstado.opcion = 6
                FrmDetalleOtEstado.nodo_padre = id_nodo_res_select
                FrmDetalleOtEstado.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
