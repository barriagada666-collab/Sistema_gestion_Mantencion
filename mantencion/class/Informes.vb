Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class Informes
    Public Sub CrgInfGanttCiclosMaq()
        Dim fila As Integer = 0
        Dim fecha_inicio As DateTime
        Dim fecha_fin As DateTime
        Dim fecha As DateTime
        Dim fecha_ini As DateTime
        Dim num_mant As Integer
        Dim cont_celda_pintada As Integer

        With FrmInfMantPrev
            If .grillaDetalleCicloMp.RowCount = 0 Then Return

            FrmCartaGantt.grillaInfoGantt.Rows.Clear()
            FrmCartaGantt.grillaGraficoGantt.Rows.Clear()
            FrmCartaGantt.grillaGraficoGantt.Columns.Clear()

            For i = 0 To .grillaDetalleCicloMp.RowCount - 1
                FrmCartaGantt.grillaInfoGantt.Rows.Add()
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(0).Value = .grillaDetalleCicloMp.Rows(i).Cells(0).Value
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(1).Value = .nombre_nodo_select
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(2).Value = .grillaDetalleCicloMp.Rows(i).Cells(4).Value
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(3).Value = .grillaDetalleCicloMp.Rows(i).Cells(1).Value
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(4).Value = .grillaDetalleCicloMp.Rows(i).Cells(2).Value
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(5).Value = .grillaDetalleCicloMp.Rows(i).Cells(3).Value
                fila = fila + 1
            Next

            fecha_inicio = DateTime.MaxValue
            fecha_fin = DateTime.MinValue
            For i = 0 To .grillaDetalleCicloMp.RowCount - 1
                Dim f1 As DateTime, f2 As DateTime
                If DateTime.TryParse(Convert.ToString(.grillaDetalleCicloMp.Rows(i).Cells(1).Value), f1) Then
                    If f1.Date < fecha_inicio Then fecha_inicio = f1.Date
                End If
                If DateTime.TryParse(Convert.ToString(.grillaDetalleCicloMp.Rows(i).Cells(2).Value), f2) Then
                    If f2.Date > fecha_fin Then fecha_fin = f2.Date
                End If
            Next
            If fecha_inicio = DateTime.MaxValue OrElse fecha_fin = DateTime.MinValue OrElse fecha_inicio > fecha_fin Then
                fecha_inicio = Now.Date
                fecha_fin = Now.Date
            End If
            fecha = fecha_inicio

            While fecha <= fecha_fin
                Dim colKey As String = fecha.ToString("yyyyMMdd")
                FrmCartaGantt.grillaGraficoGantt.Columns.Add(colKey, fecha.ToString("dd-MM-yy"))
                FrmCartaGantt.grillaGraficoGantt.Columns(colKey).Width = 55
                fecha = DateAdd(DateInterval.Day, 1, fecha)
            End While

            For i = 0 To FrmCartaGantt.grillaInfoGantt.RowCount - 1
                FrmCartaGantt.grillaGraficoGantt.Rows.Add()
                fecha_ini = CDate(FrmCartaGantt.grillaInfoGantt.Rows(i).Cells(3).Value).Date
                num_mant = DateDiff(DateInterval.Day, fecha_ini, CDate(FrmCartaGantt.grillaInfoGantt.Rows(i).Cells(4).Value).Date) + 1

                For j = 0 To FrmCartaGantt.grillaGraficoGantt.Columns.Count - 1
                    If fecha_ini.ToString("yyyyMMdd") = FrmCartaGantt.grillaGraficoGantt.Columns(j).Name Then
                        FrmCartaGantt.grillaGraficoGantt.Rows(i).Cells(j).Style.BackColor = Utilitarios.ColorGanttBarra
                        FrmCartaGantt.grillaGraficoGantt.Rows(i).Cells(j).Style.ForeColor = Color.White
                        cont_celda_pintada = cont_celda_pintada + 1
                        If cont_celda_pintada < num_mant Then
                            fecha_ini = DateAdd(DateInterval.Day, 1, fecha_ini)
                        End If
                    End If
                Next
                cont_celda_pintada = 0
            Next
        End With
    End Sub

    Public Sub CrgInfGanttCiclosVariasMaq()
        Dim fila As Integer = 0
        Dim fecha_inicio As DateTime
        Dim fecha_fin As DateTime
        Dim fecha As DateTime
        Dim fecha_ini As DateTime
        Dim num_mant As Integer
        Dim cont_celda_pintada As Integer

        With FrmInfMantPrevCiclosMaq
            If .grillaCiclosMaquinas.RowCount = 0 Then Return

            FrmCartaGantt.grillaInfoGantt.Rows.Clear()
            FrmCartaGantt.grillaGraficoGantt.Rows.Clear()
            FrmCartaGantt.grillaGraficoGantt.Columns.Clear()

            For i = 0 To .grillaCiclosMaquinas.RowCount - 1
                FrmCartaGantt.grillaInfoGantt.Rows.Add()
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(0).Value = .grillaCiclosMaquinas.Rows(i).Cells(0).Value
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(1).Value = .grillaCiclosMaquinas.Rows(i).Cells(2).Value
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(2).Value = .grillaCiclosMaquinas.Rows(i).Cells(3).Value
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(3).Value = .grillaCiclosMaquinas.Rows(i).Cells(4).Value
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(4).Value = .grillaCiclosMaquinas.Rows(i).Cells(5).Value
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(5).Value = .grillaCiclosMaquinas.Rows(i).Cells(6).Value
                fila = fila + 1
            Next

            fecha_inicio = DateTime.MaxValue
            fecha_fin = DateTime.MinValue
            For i = 0 To .grillaCiclosMaquinas.RowCount - 1
                Dim f1 As DateTime, f2 As DateTime
                If DateTime.TryParse(Convert.ToString(.grillaCiclosMaquinas.Rows(i).Cells(4).Value), f1) Then
                    If f1.Date < fecha_inicio Then fecha_inicio = f1.Date
                End If
                If DateTime.TryParse(Convert.ToString(.grillaCiclosMaquinas.Rows(i).Cells(5).Value), f2) Then
                    If f2.Date > fecha_fin Then fecha_fin = f2.Date
                End If
            Next
            If fecha_inicio = DateTime.MaxValue OrElse fecha_fin = DateTime.MinValue OrElse fecha_inicio > fecha_fin Then
                fecha_inicio = Now.Date
                fecha_fin = Now.Date
            End If
            fecha = fecha_inicio

            While fecha <= fecha_fin
                Dim colKey As String = fecha.ToString("yyyyMMdd")
                FrmCartaGantt.grillaGraficoGantt.Columns.Add(colKey, fecha.ToString("dd-MM-yy"))
                FrmCartaGantt.grillaGraficoGantt.Columns(colKey).Width = 55
                fecha = DateAdd(DateInterval.Day, 1, fecha)
            End While

            For i = 0 To FrmCartaGantt.grillaInfoGantt.RowCount - 1
                FrmCartaGantt.grillaGraficoGantt.Rows.Add()
                fecha_ini = CDate(FrmCartaGantt.grillaInfoGantt.Rows(i).Cells(3).Value).Date
                num_mant = DateDiff(DateInterval.Day, fecha_ini, CDate(FrmCartaGantt.grillaInfoGantt.Rows(i).Cells(4).Value).Date) + 1

                For j = 0 To FrmCartaGantt.grillaGraficoGantt.Columns.Count - 1
                    If fecha_ini.ToString("yyyyMMdd") = FrmCartaGantt.grillaGraficoGantt.Columns(j).Name Then
                        FrmCartaGantt.grillaGraficoGantt.Rows(i).Cells(j).Style.BackColor = Utilitarios.ColorGanttBarra
                        FrmCartaGantt.grillaGraficoGantt.Rows(i).Cells(j).Style.ForeColor = Color.White
                        cont_celda_pintada = cont_celda_pintada + 1
                        If cont_celda_pintada < num_mant Then
                            fecha_ini = DateAdd(DateInterval.Day, 1, fecha_ini)
                        End If
                    End If
                Next
                cont_celda_pintada = 0
            Next

            Dim fecha_fds As DateTime
            Dim colorMant As Color = Utilitarios.ColorGanttBarra
            Dim colorFds As Color = Utilitarios.ColorFondoSoloLectura
            For i = 0 To FrmCartaGantt.grillaGraficoGantt.Columns.Count - 1
                fecha_fds = DateTime.ParseExact(FrmCartaGantt.grillaGraficoGantt.Columns(i).Name, "yyyyMMdd", Globalization.CultureInfo.InvariantCulture)

                If fecha_fds.DayOfWeek = DayOfWeek.Saturday OrElse fecha_fds.DayOfWeek = DayOfWeek.Sunday Then
                    For j = 0 To FrmCartaGantt.grillaGraficoGantt.RowCount - 1
                        If FrmCartaGantt.grillaGraficoGantt.Rows(j).Cells(i).Style.BackColor <> colorMant Then
                            FrmCartaGantt.grillaGraficoGantt.Rows(j).Cells(i).Style.BackColor = colorFds
                            FrmCartaGantt.grillaGraficoGantt.Rows(j).Cells(i).Style.ForeColor = Utilitarios.ColorTextoPrincipal
                        End If
                    Next
                End If
            Next
        End With
    End Sub

    Public Sub expInfGantt(ByVal grilla_info_mp As DataGridView, ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim num_mant As Integer = 0

        If grilla_ciclos_mp.RowCount = 0 Then Return

        Try
            excelApp = New Excel.Application
            excelApp.ScreenUpdating = False
            workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "infGantt.xls")
            worksheet_1 = workbook.Sheets(1)
            worksheet_2 = workbook.Sheets(2)
            worksheet_3 = workbook.Sheets(3)
            worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetVisible
            worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetHidden
            worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetHidden

            '---------------------- impresion información base mantencion preventiva----------------
            worksheet_1.Cells(6, 3) = item 'nombre item o maquina
            worksheet_1.Cells(7, 3) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(0).Value ' id mantencion
            worksheet_1.Cells(6, 6) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(1).Value & " Hrs" ' frecuencia mp
            worksheet_1.Cells(7, 6) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(2).Value & " Hrs" ' tiempo aviso previo
            worksheet_1.Cells(6, 12) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(3).Value ' estado
            worksheet_1.Cells(6, 9) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(4).Value ' fecha creacion
            worksheet_1.Cells(7, 9) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(5).Value ' tipo de mantencion
            '---------------------------------------------------------------------------------------

            Dim filaexcel As Integer = 12
            Dim colIniIdx As Integer = If(IsDate(grilla_ciclos_mp.Rows(0).Cells(2).Value), 2, 3)
            Dim colFinIdx As Integer = colIniIdx + 1

            Dim rango As Excel.Range
            '------------- llenado de tareas realizadas --------------------------------------------
            For i = 0 To grilla_ciclos_mp.RowCount - 1
                worksheet_1.Cells(filaexcel, 1) = grilla_ciclos_mp.Rows(i).Cells(0).Value
                worksheet_1.Cells(filaexcel, 2) = grilla_ciclos_mp.Rows(i).Cells(1).Value
                worksheet_1.Cells(filaexcel, 5) = grilla_ciclos_mp.Rows(i).Cells(colIniIdx).Value
                worksheet_1.Cells(filaexcel, 6) = grilla_ciclos_mp.Rows(i).Cells(colFinIdx).Value
                worksheet_1.Cells(filaexcel, 7) = grilla_ciclos_mp.Rows(i).Cells(colFinIdx + 1).Value
                rango = worksheet_1.Range("B" & filaexcel & ":D" & filaexcel)
                rango.MergeCells = True
                filaexcel = filaexcel + 1
            Next
            '--------------------------------------------------------------------------------------
            worksheet_1.Activate()
            excelApp.ScreenUpdating = True
            MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar Excel")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Public Sub expInfGraficoGantt(ByVal grilla_info_mp As DataGridView, ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim fecha_inicio As DateTime
        Dim fecha_fin As DateTime
        Dim fecha As DateTime
        Dim fecha_ini As DateTime
        Dim num_mant As Integer = 0
        Dim cont_celda_pintada As Integer = 0
        Dim cont_fila As Integer = 0
        Dim cont_col As Integer = 0

        If grilla_ciclos_mp.RowCount = 0 Then Return

        Try
            excelApp = New Excel.Application
            excelApp.ScreenUpdating = False
            workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "infGantt.xls")
            worksheet_1 = workbook.Sheets(1)
            worksheet_2 = workbook.Sheets(2)
            worksheet_3 = workbook.Sheets(3)
            worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetHidden
            worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetVisible
            worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetHidden

            '---------------------- impresion información base mantencion preventiva----------------
            worksheet_2.Cells(6, 3) = item 'nombre item o maquina
            worksheet_2.Cells(7, 3) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(0).Value ' id mantencion
            worksheet_2.Cells(6, 7) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(1).Value & " Hrs" ' frecuencia mp
            worksheet_2.Cells(7, 7) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(2).Value & " Hrs" ' tiempo aviso previo
            worksheet_2.Cells(6, 14) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(3).Value ' estado
            worksheet_2.Cells(6, 10) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(4).Value ' fecha creacion
            worksheet_2.Cells(7, 10) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(5).Value ' tipo de mantencion
            '---------------------------------------------------------------------------------------
            Dim filaexcel As Integer = 11
            Dim colIniIdx As Integer = If(IsDate(grilla_ciclos_mp.Rows(0).Cells(2).Value), 2, 3)
            Dim colFinIdx As Integer = colIniIdx + 1

            Dim rango As Excel.Range
            '------------- llenado de tareas realizadas --------------------------------------------
            For i = 0 To grilla_ciclos_mp.RowCount - 1
                worksheet_2.Cells(filaexcel, 1) = grilla_ciclos_mp.Rows(i).Cells(0).Value
                worksheet_2.Cells(filaexcel, 2) = grilla_ciclos_mp.Rows(i).Cells(1).Value
                rango = worksheet_2.Range("B" & filaexcel & ":D" & filaexcel)
                rango.MergeCells = True
                filaexcel = filaexcel + 1
            Next
            '---------------------------------------------------------------------------------------

            fecha_inicio = CDate(grilla_ciclos_mp.Rows(0).Cells(colIniIdx).Value).Date
            fecha_fin = CDate(grilla_ciclos_mp.Rows(grilla_ciclos_mp.RowCount - 1).Cells(colFinIdx).Value).Date
            fecha = fecha_inicio

            Dim col_excel As Integer = 5

            While fecha <= fecha_fin
                worksheet_2.Cells(10, col_excel) = fecha
                fecha = DateAdd(DateInterval.Day, 1, fecha)
                col_excel = col_excel + 1
            End While

            cont_col = 5
            cont_fila = 11

            For i = 0 To grilla_ciclos_mp.RowCount - 1
                fecha_ini = CDate(grilla_ciclos_mp.Rows(i).Cells(colIniIdx).Value).Date
                num_mant = DateDiff(DateInterval.Day, fecha_ini, CDate(grilla_ciclos_mp.Rows(i).Cells(colFinIdx).Value).Date) + 1

                For j = 0 To grilla_grafico.Columns.Count - 1
                    If fecha_ini.ToString("yyyyMMdd") = grilla_grafico.Columns(j).Name OrElse fecha_ini.ToString("dd-MM-yy") = grilla_grafico.Columns(j).Name Then
                        worksheet_2.Cells(cont_fila, cont_col) = 1
                        cont_celda_pintada = cont_celda_pintada + 1
                        If cont_celda_pintada < num_mant Then
                            fecha_ini = DateAdd(DateInterval.Day, 1, fecha_ini)
                        End If
                    End If
                    cont_col = cont_col + 1
                Next
                cont_celda_pintada = 0
                cont_fila = cont_fila + 1
                cont_col = 5
            Next

            worksheet_2.Activate()
            excelApp.ScreenUpdating = True
            MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar Excel")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Public Sub expInfGanttTodo(ByVal grilla_info_mp As DataGridView, ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim num_mant As Integer = 0
        Dim fecha_inicio As DateTime
        Dim fecha_fin As DateTime
        Dim fecha As DateTime
        Dim fecha_ini As DateTime
        Dim cont_celda_pintada As Integer = 0
        Dim cont_fila As Integer = 0
        Dim cont_col As Integer = 0

        If grilla_ciclos_mp.RowCount = 0 Then Return

        Try
            excelApp = New Excel.Application
            excelApp.ScreenUpdating = False
            workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "infGantt.xls")
            worksheet_1 = workbook.Sheets(1)
            worksheet_2 = workbook.Sheets(2)
            worksheet_3 = workbook.Sheets(3)
            worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetVisible
            worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetVisible
            worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetHidden

            '---------------------- impresion información base mantencion preventiva----------------
            worksheet_1.Cells(6, 3) = item 'nombre item o maquina
            worksheet_1.Cells(7, 3) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(0).Value ' id mantencion
            worksheet_1.Cells(6, 6) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(1).Value & " Hrs" ' frecuencia mp
            worksheet_1.Cells(7, 6) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(2).Value & " Hrs" ' tiempo aviso previo
            worksheet_1.Cells(6, 12) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(3).Value ' estado
            worksheet_1.Cells(6, 9) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(4).Value ' fecha creacion
            worksheet_1.Cells(7, 9) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(5).Value ' tipo de mantencion
            '---------------------------------------------------------------------------------------

            Dim filaexcel As Integer = 12
            Dim colIniIdx As Integer = If(IsDate(grilla_ciclos_mp.Rows(0).Cells(2).Value), 2, 3)
            Dim colFinIdx As Integer = colIniIdx + 1

            Dim rango As Excel.Range
            '------------- llenado de tareas realizadas --------------------------------------------
            For i = 0 To grilla_ciclos_mp.RowCount - 1
                worksheet_1.Cells(filaexcel, 1) = grilla_ciclos_mp.Rows(i).Cells(0).Value
                worksheet_1.Cells(filaexcel, 2) = grilla_ciclos_mp.Rows(i).Cells(1).Value
                worksheet_1.Cells(filaexcel, 5) = grilla_ciclos_mp.Rows(i).Cells(colIniIdx).Value
                worksheet_1.Cells(filaexcel, 6) = grilla_ciclos_mp.Rows(i).Cells(colFinIdx).Value
                worksheet_1.Cells(filaexcel, 7) = grilla_ciclos_mp.Rows(i).Cells(colFinIdx + 1).Value
                rango = worksheet_1.Range("B" & filaexcel & ":D" & filaexcel)
                rango.MergeCells = True
                filaexcel = filaexcel + 1
            Next
            '--------------------------------------------------------------------------------------

            '---------------------- impresion información base mantencion preventiva----------------
            worksheet_2.Cells(6, 3) = item 'nombre item o maquina
            worksheet_2.Cells(7, 3) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(0).Value ' id mantencion
            worksheet_2.Cells(6, 7) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(1).Value & " Hrs" ' frecuencia mp
            worksheet_2.Cells(7, 7) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(2).Value & " Hrs" ' tiempo aviso previo
            worksheet_2.Cells(6, 14) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(3).Value ' estado
            worksheet_2.Cells(6, 10) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(4).Value ' fecha creacion
            worksheet_2.Cells(7, 10) = grilla_info_mp.Rows(grilla_info_mp.CurrentRow.Index).Cells(5).Value ' tipo de mantencion
            '---------------------------------------------------------------------------------------

            filaexcel = 11

            '------------- llenado de tareas realizadas --------------------------------------------
            For i = 0 To grilla_ciclos_mp.RowCount - 1
                worksheet_2.Cells(filaexcel, 1) = grilla_ciclos_mp.Rows(i).Cells(0).Value
                worksheet_2.Cells(filaexcel, 2) = grilla_ciclos_mp.Rows(i).Cells(1).Value
                rango = worksheet_2.Range("B" & filaexcel & ":D" & filaexcel)
                rango.MergeCells = True
                filaexcel = filaexcel + 1
            Next
            '---------------------------------------------------------------------------------------

            fecha_inicio = CDate(grilla_ciclos_mp.Rows(0).Cells(colIniIdx).Value).Date
            fecha_fin = CDate(grilla_ciclos_mp.Rows(grilla_ciclos_mp.RowCount - 1).Cells(colFinIdx).Value).Date
            fecha = fecha_inicio

            Dim col_excel As Integer = 5

            While fecha <= fecha_fin
                worksheet_2.Cells(10, col_excel) = fecha
                fecha = DateAdd(DateInterval.Day, 1, fecha)
                col_excel = col_excel + 1
            End While

            cont_col = 5
            cont_fila = 11

            For i = 0 To grilla_ciclos_mp.RowCount - 1
                fecha_ini = CDate(grilla_ciclos_mp.Rows(i).Cells(colIniIdx).Value).Date
                num_mant = DateDiff(DateInterval.Day, fecha_ini, CDate(grilla_ciclos_mp.Rows(i).Cells(colFinIdx).Value).Date) + 1

                For j = 0 To grilla_grafico.Columns.Count - 1
                    Dim colDate As DateTime
                    If Not DateTime.TryParseExact(grilla_grafico.Columns(j).Name, "yyyyMMdd", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, colDate) Then
                        DateTime.TryParse(grilla_grafico.Columns(j).Name, colDate)
                    End If

                    If fecha_ini.Date = colDate.Date Then
                        worksheet_2.Cells(cont_fila, cont_col) = 1
                        cont_celda_pintada = cont_celda_pintada + 1
                        If cont_celda_pintada < num_mant Then
                            fecha_ini = DateAdd(DateInterval.Day, 1, fecha_ini)
                        End If
                    ElseIf colDate.DayOfWeek = DayOfWeek.Saturday OrElse colDate.DayOfWeek = DayOfWeek.Sunday Then
                        worksheet_2.Cells(cont_fila, cont_col) = 2
                    End If
                    cont_col = cont_col + 1
                Next
                cont_celda_pintada = 0
                cont_fila = cont_fila + 1
                cont_col = 5
            Next
            worksheet_1.Activate()
            excelApp.ScreenUpdating = True
            MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar Excel")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Public Sub expInfGraficoGanttVariasMaq(ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item_gantt As String, ByVal fecha_desde As String, ByVal fecha_hasta As String)
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim fecha_inicio As DateTime
        Dim fecha_fin As DateTime
        Dim fecha As DateTime
        Dim fecha_ini As DateTime
        Dim num_mant As Integer = 0
        Dim cont_celda_pintada As Integer = 0
        Dim cont_fila As Integer = 0
        Dim cont_col As Integer = 0

        If grilla_ciclos_mp.RowCount = 0 Then Return

        Try
            excelApp = New Excel.Application
            excelApp.ScreenUpdating = False
            workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "infGantt.xls")
            worksheet_1 = workbook.Sheets(1)
            worksheet_2 = workbook.Sheets(2)
            worksheet_3 = workbook.Sheets(3)
            worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetHidden
            worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetHidden
            worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetVisible

            Dim filaexcel As Integer = 10

            worksheet_3.Cells(1, 4) = "Calendario gantt mantención preventiva " & item_gantt
            worksheet_3.Cells(5, 3).NumberFormat = "@"
            worksheet_3.Cells(6, 3).NumberFormat = "@"
            worksheet_3.Cells(5, 3) = fecha_desde
            worksheet_3.Cells(6, 3) = fecha_hasta
            Dim rango As Excel.Range
            '------------- llenado de tareas realizadas --------------------------------------------
            For i = 0 To grilla_ciclos_mp.RowCount - 1
                worksheet_3.Cells(filaexcel, 1) = grilla_ciclos_mp.Rows(i).Cells(0).Value
                worksheet_3.Cells(filaexcel, 2) = grilla_ciclos_mp.Rows(i).Cells(1).Value
                worksheet_3.Cells(filaexcel, 3) = grilla_ciclos_mp.Rows(i).Cells(2).Value
                rango = worksheet_3.Range("C" & filaexcel & ":E" & filaexcel)
                rango.MergeCells = True
                filaexcel = filaexcel + 1
            Next
            '---------------------------------------------------------------------------------------

            fecha_inicio = CDate(grilla_ciclos_mp.Rows(0).Cells(3).Value).Date
            fecha_fin = CDate(grilla_ciclos_mp.Rows(grilla_ciclos_mp.RowCount - 1).Cells(4).Value).Date
            fecha = fecha_inicio

            Dim col_excel As Integer = 6

            While fecha <= fecha_fin
                worksheet_3.Cells(4, col_excel) = fecha
                fecha = DateAdd(DateInterval.Day, 1, fecha)
                col_excel = col_excel + 1
            End While

            cont_col = 6
            cont_fila = 10

            For i = 0 To grilla_ciclos_mp.RowCount - 1
                fecha_ini = CDate(grilla_ciclos_mp.Rows(i).Cells(3).Value).Date
                num_mant = DateDiff(DateInterval.Day, fecha_ini, CDate(grilla_ciclos_mp.Rows(i).Cells(4).Value).Date) + 1

                For j = 0 To grilla_grafico.Columns.Count - 1
                    Dim colDate As DateTime
                    If Not DateTime.TryParseExact(grilla_grafico.Columns(j).Name, "yyyyMMdd", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, colDate) Then
                        DateTime.TryParse(grilla_grafico.Columns(j).Name, colDate)
                    End If

                    If fecha_ini.Date = colDate.Date Then
                        worksheet_3.Cells(cont_fila, cont_col) = 1
                        cont_celda_pintada = cont_celda_pintada + 1
                        If cont_celda_pintada < num_mant Then
                            fecha_ini = DateAdd(DateInterval.Day, 1, fecha_ini)
                        End If
                    ElseIf colDate.DayOfWeek = DayOfWeek.Saturday OrElse colDate.DayOfWeek = DayOfWeek.Sunday Then
                        worksheet_3.Cells(cont_fila, cont_col) = 2
                    End If
                    cont_col = cont_col + 1
                Next
                cont_celda_pintada = 0
                cont_fila = cont_fila + 1
                cont_col = 6
            Next

            worksheet_3.Activate()
            excelApp.ScreenUpdating = True
            MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar Excel")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
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

            Dim rutaPlantilla As String = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory(), "inf_auditoria.xls")
            If Not System.IO.File.Exists(rutaPlantilla) Then
                rutaPlantilla = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory(), "plantillas", "inf_auditoria.xls")
            End If

            If System.IO.File.Exists(rutaPlantilla) Then
                workbook = excelApp.Workbooks.Add(rutaPlantilla)
            Else
                workbook = excelApp.Workbooks.Add()
            End If

            worksheet_1 = CType(workbook.Sheets(1), Excel.Worksheet)
            worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetVisible

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

                Dim rangoIni As Excel.Range = CType(worksheet_1.Cells(10, 3), Excel.Range)
                Dim rangoFin As Excel.Range = CType(worksheet_1.Cells(10 + totalFilas - 1, 3 + cantCols - 1), Excel.Range)
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
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar Excel")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

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
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar Estadísticas")
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
            excelApp.ScreenUpdating = False
            workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_estadistico.xls")
            worksheet = workbook.Sheets(1)
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

                wsTop.Cells(3, 2) = "Período: " & fecha_inicio.ToString("dd-MM-yyyy") & " al " & fecha_fin.ToString("dd-MM-yyyy")
                wsTop.Cells(3, 2).Font.Italic = True

                ' Top Máquinas
                Dim fRow As Integer = 5
                wsTop.Cells(fRow, 2) = "TOP MÁQUINAS CON MÁS ÓRDENES DE TRABAJO"
                wsTop.Cells(fRow, 2).Font.Bold = True

                fRow += 1
                Dim cabMaq() As String = {"Ranking", "Máquina / Equipo", "Total OTs", "% Participación", "OTs Cerradas", "OTs Abiertas", "% Resueltas"}
                For c As Integer = 0 To cabMaq.Length - 1
                    wsTop.Cells(fRow, c + 2) = cabMaq(c)
                    wsTop.Cells(fRow, c + 2).Font.Bold = True
                Next

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

                fRow += 1
                Dim cabComp() As String = {"Ranking", "Componente / Parte", "Máquina Asociada", "Total OTs", "% Participación", "OTs Cerradas", "OTs Abiertas"}
                For c As Integer = 0 To cabComp.Length - 1
                    wsTop.Cells(fRow, c + 2) = cabComp(c)
                    wsTop.Cells(fRow, c + 2).Font.Bold = True
                Next

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
            excelApp.ScreenUpdating = True
            MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar Excel")
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
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet

        Try
            excelApp = New Excel.Application
            excelApp.ScreenUpdating = False
            workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_datos_tecnicos.xls")
            worksheet_1 = workbook.Sheets(1)
            worksheet_2 = workbook.Sheets(2)
            worksheet_3 = workbook.Sheets(3)

            If FrmDatosTecnicosNodo.nivel >= 3 Then

                worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetVisible
                worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetHidden
                worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetHidden

                Dim filaexcel As Integer = 9

                '------------- llenado de operaciones realizadas --------------------------------------------
                With grilla_datos_tecnicos
                    For i = 0 To .RowCount - 1
                        worksheet_1.Rows(filaexcel + 1).Insert()
                        worksheet_1.Cells(filaexcel, 2) = .Rows(i).Cells(2).Value
                        worksheet_1.Cells(filaexcel, 3) = .Rows(i).Cells(3).Value
                        worksheet_1.Cells(filaexcel, 4) = .Rows(i).Cells(4).Value
                        filaexcel = filaexcel + 1
                    Next
                End With

                '--------------------------------------------------------------------------------------
                worksheet_1.Activate()
                excelApp.ScreenUpdating = True
                MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
                excelApp.Visible = True

            ElseIf FrmDatosTecnicosNodo.nivel = 2 Then

                worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetHidden
                worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetVisible
                worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetHidden

                Dim filaexcel As Integer = 9

                '------------- llenado de operaciones realizadas --------------------------------------------
                With grilla_datos_tecnicos
                    For i = 0 To .RowCount - 1
                        worksheet_2.Rows(filaexcel + 1).Insert()
                        worksheet_2.Cells(filaexcel, 2) = .Rows(i).Cells(2).Value
                        worksheet_2.Cells(filaexcel, 3) = .Rows(i).Cells(3).Value
                        worksheet_2.Cells(filaexcel, 4) = .Rows(i).Cells(4).Value
                        worksheet_2.Cells(filaexcel, 5) = .Rows(i).Cells(5).Value
                        filaexcel = filaexcel + 1
                    Next
                End With

                '--------------------------------------------------------------------------------------
                worksheet_2.Activate()
                excelApp.ScreenUpdating = True
                MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
                excelApp.Visible = True

            ElseIf FrmDatosTecnicosNodo.nivel = 1 Then

                worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetHidden
                worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetHidden
                worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetVisible

                Dim filaexcel As Integer = 9

                '------------- llenado de operaciones realizadas --------------------------------------------
                With grilla_datos_tecnicos
                    For i = 0 To .RowCount - 1
                        worksheet_3.Rows(filaexcel + 1).Insert()
                        worksheet_3.Cells(filaexcel, 2) = .Rows(i).Cells(2).Value
                        worksheet_3.Cells(filaexcel, 3) = .Rows(i).Cells(3).Value
                        worksheet_3.Cells(filaexcel, 4) = .Rows(i).Cells(4).Value
                        worksheet_3.Cells(filaexcel, 5) = .Rows(i).Cells(5).Value
                        worksheet_3.Cells(filaexcel, 6) = .Rows(i).Cells(6).Value
                        filaexcel = filaexcel + 1
                    Next
                End With

                '--------------------------------------------------------------------------------------
                worksheet_3.Activate()
                excelApp.ScreenUpdating = True
                MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
                excelApp.Visible = True
            Else
                excelApp.ScreenUpdating = True
            End If
        Catch ex As Exception
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar Excel")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub

    Public Sub expInfListadoCiclo(ByVal grilla_ciclos_mp As DataGridView, ByVal fecha_desde As DateTime, ByVal fecha_hasta As DateTime)
        Dim excelApp As Excel.Application = Nothing
        Dim workbook As Excel.Workbook = Nothing
        Dim worksheet_1 As Excel.Worksheet
        Dim num_mant As Integer = 0

        Try
            excelApp = New Excel.Application
            excelApp.ScreenUpdating = False
            workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_listado_ciclo_mp.xls")
            worksheet_1 = workbook.Sheets(1)
            worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetVisible

            worksheet_1.Cells(6, 4).NumberFormat = "@"
            worksheet_1.Cells(7, 4).NumberFormat = "@"
            worksheet_1.Cells(6, 4) = fecha_desde.ToString("dd-MM-yyyy")
            worksheet_1.Cells(7, 4) = fecha_hasta.ToString("dd-MM-yyyy")

            Dim filaexcel As Integer = 11

            For i = 0 To grilla_ciclos_mp.RowCount - 1
                worksheet_1.Rows(filaexcel + 1).Insert()
                worksheet_1.Cells(filaexcel, 2) = grilla_ciclos_mp.Rows(i).Cells(0).Value
                worksheet_1.Cells(filaexcel, 3) = grilla_ciclos_mp.Rows(i).Cells(1).Value
                worksheet_1.Cells(filaexcel, 4) = grilla_ciclos_mp.Rows(i).Cells(2).Value
                worksheet_1.Cells(filaexcel, 5) = grilla_ciclos_mp.Rows(i).Cells(3).Value
                worksheet_1.Cells(filaexcel, 6) = grilla_ciclos_mp.Rows(i).Cells(4).Value
                worksheet_1.Cells(filaexcel, 7) = grilla_ciclos_mp.Rows(i).Cells(5).Value
                worksheet_1.Cells(filaexcel, 8) = grilla_ciclos_mp.Rows(i).Cells(6).Value
                filaexcel = filaexcel + 1
            Next

            worksheet_1.Activate()
            excelApp.ScreenUpdating = True
            MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportación a excel")
            excelApp.Visible = True
        Catch ex As Exception
            Utilitarios.CerrarExcelEnError(excelApp, workbook)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Exportar Excel")
        Finally
            Utilitarios.OptimizarMemoria()
        End Try
    End Sub
End Class
