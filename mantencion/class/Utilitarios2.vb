Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class Utilitarios2
    Public excelApp As Excel.Application
    Public workbook As Excel.Workbook
    Public worksheet_1 As Excel.Worksheet

    Public Sub solonumeros(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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
        Dim util As New Utilitarios()
        util.Exportar_grilla_factura(grilla_tareas_pend, item)
    End Sub

End Class
