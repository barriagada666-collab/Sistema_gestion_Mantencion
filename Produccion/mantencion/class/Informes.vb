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
            For i = 0 To .grillaDetalleCicloMp.RowCount - 1
                FrmCartaGantt.grillaInfoGantt.Rows.Add()
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(0).Value = .grillaDetalleCicloMp.Rows(i).Cells(0).Value
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(1).Value = .grillaDetalleCicloMp.Rows(i).Cells(2).Value
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(2).Value = .grillaDetalleCicloMp.Rows(i).Cells(3).Value
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(3).Value = .grillaDetalleCicloMp.Rows(i).Cells(4).Value
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(4).Value = .grillaDetalleCicloMp.Rows(i).Cells(5).Value
                FrmCartaGantt.grillaInfoGantt.Rows(fila).Cells(5).Value = .grillaDetalleCicloMp.Rows(i).Cells(6).Value
                fila = fila + 1
            Next

            

            fecha_inicio = FormatDateTime(.grillaDetalleCicloMp.Rows(0).Cells(1).Value, DateFormat.ShortDate)
            fecha_fin = FormatDateTime(.grillaDetalleCicloMp.Rows(.grillaDetalleCicloMp.RowCount - 1).Cells(2).Value, DateFormat.ShortDate)
            fecha = Format(fecha_inicio, "dd-MM-yy")

            While fecha <= fecha_fin
                FrmCartaGantt.grillaGraficoGantt.Columns.Add(fecha, fecha.ToString("dd-MM-yy"))
                fecha = DateAdd(DateInterval.Day, 1, fecha)
            End While

            For i = 0 To FrmCartaGantt.grillaInfoGantt.RowCount - 1
                FrmCartaGantt.grillaGraficoGantt.Rows.Add()
                fecha_ini = FormatDateTime(FrmCartaGantt.grillaInfoGantt.Rows(i).Cells(2).Value, DateFormat.ShortDate)
                num_mant = DateDiff(DateInterval.Day, FrmCartaGantt.grillaInfoGantt.Rows(i).Cells(2).Value, FrmCartaGantt.grillaInfoGantt.Rows(i).Cells(3).Value) + 1

                For j = 0 To FrmCartaGantt.grillaGraficoGantt.Columns.Count - 1
                    If fecha_ini = FrmCartaGantt.grillaGraficoGantt.Columns(j).Name Then
                        FrmCartaGantt.grillaGraficoGantt.Rows(i).Cells(j).Style.BackColor = Color.Red
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

            fecha_inicio = FormatDateTime(.grillaCiclosMaquinas.Rows(0).Cells(4).Value, DateFormat.ShortDate)
            fecha_fin = FormatDateTime(.grillaCiclosMaquinas.Rows(.grillaCiclosMaquinas.RowCount - 1).Cells(5).Value, DateFormat.ShortDate)
            fecha = Format(fecha_inicio, "dd-MM-yy")

            While fecha <= fecha_fin
                FrmCartaGantt.grillaGraficoGantt.Columns.Add(fecha, fecha.ToString("dd-MM-yy"))
                FrmCartaGantt.grillaGraficoGantt.Columns(CStr(fecha)).Width = 55
                fecha = DateAdd(DateInterval.Day, 1, fecha)
            End While

            For i = 0 To FrmCartaGantt.grillaInfoGantt.RowCount - 1
                FrmCartaGantt.grillaGraficoGantt.Rows.Add()
                fecha_ini = FormatDateTime(FrmCartaGantt.grillaInfoGantt.Rows(i).Cells(3).Value, DateFormat.ShortDate)
                num_mant = DateDiff(DateInterval.Day, FrmCartaGantt.grillaInfoGantt.Rows(i).Cells(3).Value, FrmCartaGantt.grillaInfoGantt.Rows(i).Cells(4).Value) + 1

                For j = 0 To FrmCartaGantt.grillaGraficoGantt.Columns.Count - 1
                    If fecha_ini = FrmCartaGantt.grillaGraficoGantt.Columns(j).Name Then
                        FrmCartaGantt.grillaGraficoGantt.Rows(i).Cells(j).Style.BackColor = Color.Red
                        cont_celda_pintada = cont_celda_pintada + 1
                        If cont_celda_pintada < num_mant Then
                            fecha_ini = DateAdd(DateInterval.Day, 1, fecha_ini)
                        End If
                    End If
                Next
                cont_celda_pintada = 0
            Next

            Dim fecha_fds As DateTime
            Dim dia As String = ""
            For i = 0 To FrmCartaGantt.grillaGraficoGantt.Columns.Count - 1
                fecha_fds = FormatDateTime(FrmCartaGantt.grillaGraficoGantt.Columns(i).Name, DateFormat.ShortDate)
                dia = fecha_fds.DayOfWeek.ToString

                If dia = "Saturday" Or dia = "Sunday" Then
                    For j = 0 To FrmCartaGantt.grillaGraficoGantt.RowCount - 1
                        FrmCartaGantt.grillaGraficoGantt.Rows(j).Cells(i).Style.BackColor = Color.PowderBlue
                    Next
                End If
            Next
        End With
    End Sub

    Public Sub expInfGantt(ByVal grilla_info_mp As DataGridView, ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet
        Dim num_mant As Integer = 0

        excelApp = New Excel.Application
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

        Dim rango As Excel.Range
        '------------- llenado de tareas realizadas --------------------------------------------
        For i = 0 To grilla_ciclos_mp.RowCount - 1
            worksheet_1.Cells(filaexcel, 1) = grilla_ciclos_mp.Rows(i).Cells(0).Value
            worksheet_1.Cells(filaexcel, 2) = grilla_ciclos_mp.Rows(i).Cells(1).Value
            worksheet_1.Cells(filaexcel, 5) = grilla_ciclos_mp.Rows(i).Cells(2).Value
            worksheet_1.Cells(filaexcel, 6) = grilla_ciclos_mp.Rows(i).Cells(3).Value
            worksheet_1.Cells(filaexcel, 7) = grilla_ciclos_mp.Rows(i).Cells(4).Value
            rango = worksheet_1.Range("B" & filaexcel & ":D" & filaexcel)
            rango.MergeCells = True
            filaexcel = filaexcel + 1
        Next
        '--------------------------------------------------------------------------------------
        worksheet_1.Activate()
        MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
        excelApp.Visible = True
    End Sub

    Public Sub expInfGraficoGantt(ByVal grilla_info_mp As DataGridView, ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
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

        excelApp = New Excel.Application
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

        fecha_inicio = FormatDateTime(grilla_ciclos_mp.Rows(0).Cells(2).Value, DateFormat.ShortDate)
        fecha_fin = FormatDateTime(grilla_ciclos_mp.Rows(grilla_ciclos_mp.RowCount - 1).Cells(3).Value, DateFormat.ShortDate)
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
            fecha_ini = FormatDateTime(grilla_ciclos_mp.Rows(i).Cells(2).Value, DateFormat.ShortDate)
            num_mant = DateDiff(DateInterval.Day, grilla_ciclos_mp.Rows(i).Cells(2).Value, grilla_ciclos_mp.Rows(i).Cells(3).Value) + 1

            For j = 0 To grilla_grafico.Columns.Count - 1
                If fecha_ini = grilla_grafico.Columns(j).Name Then
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
        MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
        excelApp.Visible = True
    End Sub

    Public Sub expInfGanttTodo(ByVal grilla_info_mp As DataGridView, ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item As String)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
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

        excelApp = New Excel.Application
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

        Dim rango As Excel.Range
        '------------- llenado de tareas realizadas --------------------------------------------
        For i = 0 To grilla_ciclos_mp.RowCount - 1
            worksheet_1.Cells(filaexcel, 1) = grilla_ciclos_mp.Rows(i).Cells(0).Value
            worksheet_1.Cells(filaexcel, 2) = grilla_ciclos_mp.Rows(i).Cells(1).Value
            worksheet_1.Cells(filaexcel, 5) = grilla_ciclos_mp.Rows(i).Cells(2).Value
            worksheet_1.Cells(filaexcel, 6) = grilla_ciclos_mp.Rows(i).Cells(3).Value
            worksheet_1.Cells(filaexcel, 7) = grilla_ciclos_mp.Rows(i).Cells(4).Value
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

        fecha_inicio = FormatDateTime(grilla_ciclos_mp.Rows(0).Cells(2).Value, DateFormat.ShortDate)
        fecha_fin = FormatDateTime(grilla_ciclos_mp.Rows(grilla_ciclos_mp.RowCount - 1).Cells(3).Value, DateFormat.ShortDate)
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
            fecha_ini = FormatDateTime(grilla_ciclos_mp.Rows(i).Cells(2).Value, DateFormat.ShortDate)
            num_mant = DateDiff(DateInterval.Day, grilla_ciclos_mp.Rows(i).Cells(2).Value, grilla_ciclos_mp.Rows(i).Cells(3).Value) + 1

            For j = 0 To grilla_grafico.Columns.Count - 1
                If fecha_ini = grilla_grafico.Columns(j).Name Then
                    worksheet_2.Cells(cont_fila, cont_col) = 1
                    cont_celda_pintada = cont_celda_pintada + 1
                    If cont_celda_pintada < num_mant Then
                        fecha_ini = DateAdd(DateInterval.Day, 1, fecha_ini)
                    End If
                ElseIf CDate(grilla_grafico.Columns(j).Name.ToString).DayOfWeek.ToString = "Saturday" Or CDate(grilla_grafico.Columns(j).Name.ToString).DayOfWeek.ToString = "Sunday" Then
                    worksheet_2.Cells(cont_fila, cont_col) = 2
                End If
                cont_col = cont_col + 1
            Next
            cont_celda_pintada = 0
            cont_fila = cont_fila + 1
            cont_col = 5
        Next
        worksheet_1.Activate()
        MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
        excelApp.Visible = True
    End Sub

    Public Sub expInfGraficoGanttVariasMaq(ByVal grilla_ciclos_mp As DataGridView, ByVal grilla_grafico As DataGridView, ByVal item_gantt As String, ByVal fecha_desde As String, ByVal fecha_hasta As String)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
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

        excelApp = New Excel.Application
        workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "infGantt.xls")
        worksheet_1 = workbook.Sheets(1)
        worksheet_2 = workbook.Sheets(2)
        worksheet_3 = workbook.Sheets(3)
        worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_2.Visible = Excel.XlSheetVisibility.xlSheetHidden
        worksheet_3.Visible = Excel.XlSheetVisibility.xlSheetVisible

        Dim filaexcel As Integer = 10

        worksheet_3.Cells(1, 4) = "Calendario gantt mantención preventiva " & item_gantt
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

        fecha_inicio = FormatDateTime(grilla_ciclos_mp.Rows(0).Cells(3).Value, DateFormat.ShortDate)
        fecha_fin = FormatDateTime(grilla_ciclos_mp.Rows(grilla_ciclos_mp.RowCount - 1).Cells(4).Value, DateFormat.ShortDate)
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
            fecha_ini = FormatDateTime(grilla_ciclos_mp.Rows(i).Cells(3).Value, DateFormat.ShortDate)
            num_mant = DateDiff(DateInterval.Day, grilla_ciclos_mp.Rows(i).Cells(3).Value, grilla_ciclos_mp.Rows(i).Cells(4).Value) + 1

            For j = 0 To grilla_grafico.Columns.Count - 1
                If fecha_ini = grilla_grafico.Columns(j).Name Then
                    worksheet_3.Cells(cont_fila, cont_col) = 1
                    cont_celda_pintada = cont_celda_pintada + 1
                    If cont_celda_pintada < num_mant Then
                        fecha_ini = DateAdd(DateInterval.Day, 1, fecha_ini)
                    End If
                ElseIf CDate(grilla_grafico.Columns(j).Name.ToString).DayOfWeek.ToString = "Saturday" Or CDate(grilla_grafico.Columns(j).Name.ToString).DayOfWeek.ToString = "Sunday" Then
                    worksheet_3.Cells(cont_fila, cont_col) = 2
                End If
                cont_col = cont_col + 1
            Next
            cont_celda_pintada = 0
            cont_fila = cont_fila + 1
            cont_col = 6
        Next

        worksheet_3.Activate()
        MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
        excelApp.Visible = True
    End Sub

    Public Sub expInfAuditoria(ByVal grilla_auditoria As DataGridView, ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet_1 As Excel.Worksheet


        excelApp = New Excel.Application
        workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_auditoria.xls")
        worksheet_1 = workbook.Sheets(1)
        worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetVisible


        '---------------------- impresion fecha inicio y fecha fin ----------------
        worksheet_1.Cells(5, 6) = FormatDateTime(fecha_inicio, DateFormat.ShortDate)
        worksheet_1.Cells(6, 6) = FormatDateTime(fecha_fin, DateFormat.ShortDate)
        '---------------------------------------------------------------------------------------

        Dim filaexcel As Integer = 10

        '------------- llenado de operaciones realizadas --------------------------------------------
        With grilla_auditoria
            For i = 0 To .RowCount - 1
                worksheet_1.Cells(filaexcel, 3) = .Rows(i).Cells(0).Value
                worksheet_1.Cells(filaexcel, 4) = .Rows(i).Cells(1).Value
                worksheet_1.Cells(filaexcel, 5) = .Rows(i).Cells(2).Value
                worksheet_1.Cells(filaexcel, 6) = .Rows(i).Cells(3).Value
                worksheet_1.Cells(filaexcel, 7) = .Rows(i).Cells(4).Value
                worksheet_1.Cells(filaexcel, 8) = .Rows(i).Cells(5).Value
                worksheet_1.Cells(filaexcel, 9) = .Rows(i).Cells(6).Value
                worksheet_1.Cells(filaexcel, 10) = .Rows(i).Cells(7).Value
                filaexcel = filaexcel + 1
            Next
        End With

        '--------------------------------------------------------------------------------------
        worksheet_1.Activate()
        MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
        excelApp.Visible = True
    End Sub

    Public Sub expInfEstadistica(ByVal fecha_inicio As DateTime, ByVal fecha_fin As DateTime)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet As Excel.Worksheet
        Dim opcion As Integer = 0

        excelApp = New Excel.Application
        workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_estadistico.xls")
        worksheet = workbook.Sheets(1)
        worksheet.Visible = Excel.XlSheetVisibility.xlSheetVisible


        '---------------------- impresion fecha inicio y fecha fin ----------------
        worksheet.Cells(4, 7) = FormatDateTime(fecha_inicio, DateFormat.ShortDate)
        worksheet.Cells(5, 7) = FormatDateTime(fecha_fin, DateFormat.ShortDate)
        '---------------------------------------------------------------------------------------

        Dim filaexcel As Integer = 14
        opcion = grilla_num_filas_mayor()
        '------------- llenado de operaciones realizadas --------------------------------------------

        If opcion = 1 Then
            With FrmResumenes.grillaOtPorTurno
                For i = 0 To .RowCount - 1
                    worksheet.Rows(filaexcel + 1).Insert()
                    worksheet.Cells(filaexcel, 2) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 3) = .Rows(i).Cells(1).Value
                    filaexcel = filaexcel + 1
                Next
            End With

            With FrmResumenes.grillaOtPorDia
                filaexcel = 14
                For i = 0 To .RowCount - 1
                    worksheet.Cells(filaexcel, 5) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 6) = .Rows(i).Cells(1).Value
                    filaexcel = filaexcel + 1
                Next
            End With

            If FrmResumenes.grillaTotalesPeriodo.Visible Then
                With FrmResumenes.grillaTotalesPeriodo
                    filaexcel = 14
                    For i = 0 To .RowCount - 1
                        worksheet.Cells(filaexcel, 8) = .Rows(i).Cells(0).Value
                        worksheet.Cells(filaexcel, 9) = .Rows(i).Cells(1).Value
                        filaexcel = filaexcel + 1
                    Next
                End With

            ElseIf FrmResumenes.grillaOtPorMes.Visible Then
                With FrmResumenes.grillaOtPorMes
                    filaexcel = 14
                    For i = 0 To .RowCount - 1
                        worksheet.Cells(filaexcel, 8) = .Rows(i).Cells(0).Value
                        worksheet.Cells(filaexcel, 9) = .Rows(i).Cells(1).Value
                        filaexcel = filaexcel + 1
                    Next
                End With
            End If

        ElseIf opcion = 2 Then
            With FrmResumenes.grillaOtPorDia
                For i = 0 To .RowCount - 1
                    worksheet.Rows(filaexcel + 1).Insert()
                    worksheet.Cells(filaexcel, 5) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 6) = .Rows(i).Cells(1).Value
                    filaexcel = filaexcel + 1
                Next
            End With

            With FrmResumenes.grillaOtPorTurno
                filaexcel = 14
                For i = 0 To .RowCount - 1
                    worksheet.Cells(filaexcel, 2) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 3) = .Rows(i).Cells(1).Value
                    filaexcel = filaexcel + 1
                Next
            End With

            If FrmResumenes.grillaTotalesPeriodo.Visible Then
                With FrmResumenes.grillaTotalesPeriodo
                    filaexcel = 14
                    For i = 0 To .RowCount - 1
                        worksheet.Cells(filaexcel, 8) = .Rows(i).Cells(0).Value
                        worksheet.Cells(filaexcel, 9) = .Rows(i).Cells(1).Value
                        filaexcel = filaexcel + 1
                    Next
                End With

            ElseIf FrmResumenes.grillaOtPorMes.Visible Then
                With FrmResumenes.grillaOtPorMes
                    filaexcel = 14
                    For i = 0 To .RowCount - 1
                        worksheet.Cells(filaexcel, 8) = .Rows(i).Cells(0).Value
                        worksheet.Cells(filaexcel, 9) = .Rows(i).Cells(1).Value
                        filaexcel = filaexcel + 1
                    Next
                End With
            End If
            
        ElseIf opcion = 3 Then
            If FrmResumenes.grillaOtPorMes.Visible Then
                With FrmResumenes.grillaOtPorMes
                    For i = 0 To .RowCount - 1
                        worksheet.Rows(filaexcel + 1).Insert()
                        worksheet.Cells(filaexcel, 8) = .Rows(i).Cells(0).Value
                        worksheet.Cells(filaexcel, 9) = .Rows(i).Cells(1).Value
                        filaexcel = filaexcel + 1
                    Next
                End With
            ElseIf FrmResumenes.grillaTotalesPeriodo.Visible Then
                With FrmResumenes.grillaTotalesPeriodo
                    For i = 0 To .RowCount - 1
                        worksheet.Rows(filaexcel + 1).Insert()
                        worksheet.Cells(filaexcel, 8) = .Rows(i).Cells(0).Value
                        worksheet.Cells(filaexcel, 9) = .Rows(i).Cells(1).Value
                        filaexcel = filaexcel + 1
                    Next
                End With
            End If

            With FrmResumenes.grillaOtPorTurno
                filaexcel = 14
                For i = 0 To .RowCount - 1
                    worksheet.Cells(filaexcel, 2) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 3) = .Rows(i).Cells(1).Value
                    filaexcel = filaexcel + 1
                Next
            End With

            With FrmResumenes.grillaOtPorDia
                filaexcel = 14
                For i = 0 To .RowCount - 1
                    worksheet.Cells(filaexcel, 5) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 6) = .Rows(i).Cells(1).Value
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
                    worksheet.Cells(filaexcel, 2) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 3) = .Rows(i).Cells(1).Value
                    filaexcel = filaexcel + 1
                Next
            End With

            With FrmResumenes.grillaOtCerradaPorTec
                filaexcel = 9
                For i = 0 To .RowCount - 1
                    worksheet.Cells(filaexcel, 5) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 6) = .Rows(i).Cells(1).Value
                    filaexcel = filaexcel + 1
                Next
            End With

            With FrmResumenes.grillaOtPorTipoFalla
                filaexcel = 9
                For i = 0 To .RowCount - 1
                    worksheet.Cells(filaexcel, 8) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 9) = .Rows(i).Cells(1).Value
                    filaexcel = filaexcel + 1
                Next
            End With

        ElseIf opcion = 2 Then
            With FrmResumenes.grillaOtCerradaPorTec

                For i = 0 To .RowCount - 1
                    worksheet.Rows(filaexcel + 1).Insert()
                    worksheet.Cells(filaexcel, 5) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 6) = .Rows(i).Cells(1).Value
                    filaexcel = filaexcel + 1
                Next
            End With

            With FrmResumenes.grillaOtRecibidaPor
                filaexcel = 9
                For i = 0 To .RowCount - 1
                    worksheet.Cells(filaexcel, 2) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 3) = .Rows(i).Cells(1).Value
                    filaexcel = filaexcel + 1
                Next
            End With

            With FrmResumenes.grillaOtPorTipoFalla
                filaexcel = 9
                For i = 0 To .RowCount - 1
                    worksheet.Cells(filaexcel, 8) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 9) = .Rows(i).Cells(1).Value
                    filaexcel = filaexcel + 1
                Next
            End With

        ElseIf opcion = 3 Then
            With FrmResumenes.grillaOtPorTipoFalla
                For i = 0 To .RowCount - 1
                    worksheet.Rows(filaexcel + 1).Insert()
                    worksheet.Cells(filaexcel, 8) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 9) = .Rows(i).Cells(1).Value
                    filaexcel = filaexcel + 1
                Next
            End With

            With FrmResumenes.grillaOtRecibidaPor
                filaexcel = 9
                For i = 0 To .RowCount - 1
                    worksheet.Cells(filaexcel, 2) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 3) = .Rows(i).Cells(1).Value
                    filaexcel = filaexcel + 1
                Next
            End With

            With FrmResumenes.grillaOtCerradaPorTec
                filaexcel = 9
                For i = 0 To .RowCount - 1
                    worksheet.Cells(filaexcel, 5) = .Rows(i).Cells(0).Value
                    worksheet.Cells(filaexcel, 6) = .Rows(i).Cells(1).Value
                    filaexcel = filaexcel + 1
                Next
            End With
        End If

        '--------------------------------------------------------------------------------------
        worksheet.Activate()
        MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
        excelApp.Visible = True
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
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet_1 As Excel.Worksheet
        Dim worksheet_2 As Excel.Worksheet
        Dim worksheet_3 As Excel.Worksheet

        excelApp = New Excel.Application
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
            MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)
            excelApp.Visible = True
        End If
        
    End Sub

    Public Sub expInfListadoCiclo(ByVal grilla_ciclos_mp As DataGridView, ByVal fecha_desde As DateTime, ByVal fecha_hasta As DateTime)
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet_1 As Excel.Worksheet
        Dim num_mant As Integer = 0

        excelApp = New Excel.Application
        workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_listado_ciclo_mp.xls")
        worksheet_1 = workbook.Sheets(1)
        worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetVisible

        worksheet_1.Cells(6, 4) = fecha_desde
        worksheet_1.Cells(7, 4) = fecha_hasta

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
        MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information, "Exportación a excel")
        excelApp.Visible = True
    End Sub
End Class
