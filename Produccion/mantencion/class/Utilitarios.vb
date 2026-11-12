Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class Utilitarios

    Public Sub solonumeros(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub numero_fila_grilla(ByRef grilla As DataGridView)
        For i = 0 To grilla.RowCount - 1
            grilla.Rows(i).HeaderCell.Value = i + 1
        Next
    End Sub

    Public Sub mensajes(ByVal mensajes As String)
        MsgBox(mensajes, MsgBoxStyle.Information, "Programa de mantención")
    End Sub

    Public Sub busca_combo(ByVal cmb As ComboBox)
        With cmb
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With
    End Sub

    Public Sub Exportar_grilla_factura(ByVal grilla_tareas_pend As DataGridView, ByVal item As String)

        Dim filaexcel As Integer = 11
        Dim rango As Excel.Range
        Dim excelApp As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet_1 As Excel.Worksheet
        excelApp = New Excel.Application
        workbook = excelApp.Workbooks.Add(System.AppDomain.CurrentDomain.BaseDirectory() & "inf_fac.xls")
        worksheet_1 = workbook.Sheets(1)
        worksheet_1.Visible = Excel.XlSheetVisibility.xlSheetVisible
        worksheet_1.Activate()
        For i = 0 To grilla_tareas_pend.RowCount - 1
            worksheet_1.Cells(filaexcel, 1) = grilla_tareas_pend.Rows(i).Cells(0).Value
            worksheet_1.Cells(filaexcel, 2) = grilla_tareas_pend.Rows(i).Cells(1).Value
            worksheet_1.Cells(filaexcel, 3) = grilla_tareas_pend.Rows(i).Cells(2).Value
            worksheet_1.Cells(filaexcel, 4) = grilla_tareas_pend.Rows(i).Cells(3).Value
            worksheet_1.Cells(filaexcel, 5) = grilla_tareas_pend.Rows(i).Cells(4).Value
            'worksheet_1.Cells(filaexcel, 6) = grilla_tareas_pend.Rows(i).Cells(5).Value
            'rango = worksheet_1.Range("D" & filaexcel & ":G" & filaexcel)
            'rango.MergeCells = True
            'rango = worksheet_1.Range("H" & filaexcel & ":K" & filaexcel)
            'rango.MergeCells = True
            filaexcel = filaexcel + 1
        Next

        rango = worksheet_1.Range("A11:f" & filaexcel - 1) '-- seleccionar un rango para despues marcar las celdas
        rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous ' aca marcas las lineas de la hoja en negro según el rango seleccionado 
        MsgBox("Archivo Exportado Exitosamente", MsgBoxStyle.Information)

        If item = "imprimir_directo" Then
            workbook.PrintOut(ActivePrinter:="doPDF v7")
            workbook.Close(False) ' ->cerrar el libro no guardando los cambios
            excelApp.Quit() '-> eliminar el objeto excel de memoria
        Else
            excelApp.Visible = True
        End If

    End Sub

    Public Sub crgComboTurnos(ByRef cmb As ComboBox)
        cmb.Items.Add("Noche")
        cmb.Items.Add("Mañana")
        cmb.Items.Add("Tarde")
        cmb.Text = cmb.Items(0)
    End Sub

    Public Sub ValidarPersonalOT(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Space) Then
            e.Handled = True

        ElseIf e.KeyChar = "." Then
            e.Handled = True

        ElseIf e.KeyChar = "," Then
            e.Handled = True

        ElseIf e.KeyChar = "-" Then
            e.Handled = True

        ElseIf e.KeyChar = "_" Then
            e.Handled = True

        ElseIf e.KeyChar = "+" Then
            e.Handled = True

        ElseIf e.KeyChar = "*" Then
            e.Handled = True

        ElseIf e.KeyChar = "/" Then
            e.Handled = True

        ElseIf e.KeyChar = "$" Then
            e.Handled = True

        ElseIf e.KeyChar = "#" Then
            e.Handled = True

        ElseIf e.KeyChar = "%" Then
            e.Handled = True

        ElseIf e.KeyChar = "&" Then
            e.Handled = True

        ElseIf e.KeyChar = "?" Then
            e.Handled = True

        ElseIf e.KeyChar = "¿" Then
            e.Handled = True

        ElseIf e.KeyChar = "!" Then
            e.Handled = True

        ElseIf e.KeyChar = "¡" Then
            e.Handled = True

        End If

    End Sub
End Class
