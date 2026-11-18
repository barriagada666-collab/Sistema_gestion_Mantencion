Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class InfOt
    Inherits Component

    Private _dataSource As DataTable
    Private _titulo As String = "INFORME DE ÓRDENES DE TRABAJO (OT)"
    Private _subtitulo As String = ""
    Private _planta As String = ""
    Private _printRowIndex As Integer = 0

    Public Sub New()
        MyBase.New()
    End Sub

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DataSource() As DataTable
        Get
            Return _dataSource
        End Get
        Set(ByVal value As DataTable)
            _dataSource = value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Titulo() As String
        Get
            Return _titulo
        End Get
        Set(ByVal value As String)
            _titulo = value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Subtitulo() As String
        Get
            Return _subtitulo
        End Get
        Set(ByVal value As String)
            _subtitulo = value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Planta() As String
        Get
            Return _planta
        End Get
        Set(ByVal value As String)
            _planta = value
        End Set
    End Property

    Public Sub SetDataSource(ByVal dataTable As DataTable)
        _dataSource = dataTable
    End Sub

    Public Sub SetDataSource(ByVal dataSet As DataSet)
        If dataSet IsNot Nothing AndAlso dataSet.Tables.Count > 0 Then
            _dataSource = dataSet.Tables(0)
        End If
    End Sub

    Public Sub SetDataSource(ByVal dataSourceObj As Object)
        If TypeOf dataSourceObj Is DataTable Then
            _dataSource = DirectCast(dataSourceObj, DataTable)
        ElseIf TypeOf dataSourceObj Is DataSet Then
            Dim ds As DataSet = DirectCast(dataSourceObj, DataSet)
            If ds.Tables.Count > 0 Then
                _dataSource = ds.Tables(0)
            End If
        ElseIf TypeOf dataSourceObj Is DataView Then
            _dataSource = DirectCast(dataSourceObj, DataView).ToTable()
        End If
    End Sub

    ''' <summary>
    ''' Genera una vista HTML completa del informe para mostrar en el visor integrado.
    ''' </summary>
    Public Function GenerarHtml() As String
        Dim sb As New StringBuilder()
        sb.AppendLine("<!DOCTYPE html>")
        sb.AppendLine("<html><head><meta charset='utf-8'/>")
        sb.AppendLine("<style>")
        sb.AppendLine("body { font-family: 'Segoe UI', Arial, sans-serif; font-size: 11px; margin: 16px; color: #0f172a; background-color: #e5ebeb; }")
        sb.AppendLine(".page { background: #fff; padding: 20px; border: 1px solid #a0c5cf; box-shadow: 0 2px 6px rgba(2,94,135,0.12); }")
        sb.AppendLine(".header { border-bottom: 2px solid #025e87; padding-bottom: 10px; margin-bottom: 14px; display: flex; justify-content: space-between; align-items: baseline; }")
        sb.AppendLine("h1 { font-size: 16px; color: #025e87; margin: 0 0 4px 0; }")
        sb.AppendLine(".meta { font-size: 11px; color: #0191b3; margin-bottom: 10px; font-weight: 600; }")
        sb.AppendLine("table { width: 100%; border-collapse: collapse; table-layout: auto; }")
        sb.AppendLine("th { background-color: #025e87; color: #ffffff; font-weight: bold; text-align: left; padding: 6px 5px; border: 1px solid #0191b3; font-size: 10px; }")
        sb.AppendLine("td { padding: 5px; border: 1px solid #a0c5cf; font-size: 10px; vertical-align: top; word-wrap: break-word; color: #0f172a; }")
        sb.AppendLine("tr:nth-child(even) { background-color: #eaf3f5; }")
        sb.AppendLine("tr:hover { background-color: #d7e6ea; }")
        sb.AppendLine(".footer { margin-top: 12px; font-size: 10px; color: #025e87; font-weight: bold; text-align: right; }")
        sb.AppendLine(".empty { padding: 24px; text-align: center; color: #777; font-style: italic; }")
        sb.AppendLine("</style></head><body>")
        sb.AppendLine("<div class='page'>")
        sb.AppendLine("<div class='header'>")
        sb.AppendLine("<h1>" & HtmlEncode(_titulo) & "</h1>")
        Dim metaInfo As String = "Fecha de emisión: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm")
        If Not String.IsNullOrEmpty(_planta) Then
            metaInfo &= " | Planta: " & HtmlEncode(_planta)
        End If
        If Not String.IsNullOrEmpty(_subtitulo) Then
            metaInfo &= " | " & HtmlEncode(_subtitulo)
        End If
        sb.AppendLine("<div class='meta'>" & metaInfo & "</div>")
        sb.AppendLine("</div>")

        If _dataSource Is Nothing OrElse _dataSource.Columns.Count = 0 OrElse _dataSource.Rows.Count = 0 Then
            sb.AppendLine("<div class='empty'>No hay registros para mostrar en el informe.</div>")
        Else
            sb.AppendLine("<table>")
            sb.AppendLine("<thead><tr>")
            For Each col As DataColumn In _dataSource.Columns
                sb.AppendLine("<th>" & HtmlEncode(col.Caption) & "</th>")
            Next
            sb.AppendLine("</tr></thead>")
            sb.AppendLine("<tbody>")
            For Each row As DataRow In _dataSource.Rows
                sb.AppendLine("<tr>")
                For Each col As DataColumn In _dataSource.Columns
                    Dim val As Object = row(col)
                    Dim texto As String = If(val Is Nothing OrElse IsDBNull(val), "", val.ToString())
                    sb.AppendLine("<td>" & HtmlEncode(texto) & "</td>")
                Next
                sb.AppendLine("</tr>")
            Next
            sb.AppendLine("</tbody></table>")
            sb.AppendLine("<div class='footer'>Total de registros: " & _dataSource.Rows.Count.ToString() & "</div>")
        End If

        sb.AppendLine("</div></body></html>")
        Return sb.ToString()
    End Function

    ''' <summary>
    ''' Exporta el informe directamente a un archivo PDF utilizando iTextSharp (sin requerir Crystal Reports ni impresoras virtuales).
    ''' </summary>
    Public Sub ExportarPDF(ByVal rutaArchivo As String)
        If String.IsNullOrEmpty(rutaArchivo) Then
            Throw New ArgumentNullException("rutaArchivo")
        End If

        Dim doc As New Document(PageSize.LETTER.Rotate(), 14.0F, 14.0F, 20.0F, 20.0F)
        Using fs As New FileStream(rutaArchivo, FileMode.Create, FileAccess.Write, FileShare.None)
            PdfWriter.GetInstance(doc, fs)
            doc.Open()
            Try
                Dim cDeep As New BaseColor(Utilitarios.ColorDeepNavy.R, Utilitarios.ColorDeepNavy.G, Utilitarios.ColorDeepNavy.B)
                Dim cSec As New BaseColor(Utilitarios.ColorSecundario.R, Utilitarios.ColorSecundario.G, Utilitarios.ColorSecundario.B)
                Dim cText As New BaseColor(Utilitarios.ColorTextoPrincipal.R, Utilitarios.ColorTextoPrincipal.G, Utilitarios.ColorTextoPrincipal.B)
                Dim cBorder As New BaseColor(Utilitarios.ColorBordeGrilla.R, Utilitarios.ColorBordeGrilla.G, Utilitarios.ColorBordeGrilla.B)

                Dim colCount As Integer = If(_dataSource IsNot Nothing, _dataSource.Columns.Count, 1)
                Dim tamHeader As Single = If(colCount >= 13, 6.2F, If(colCount >= 9, 6.8F, 7.2F))
                Dim tamCell As Single = If(colCount >= 13, 5.8F, If(colCount >= 9, 6.3F, 6.8F))

                Dim fontTitulo As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12.5F, cDeep)
                Dim fontSub As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA, 8.2F, cSec)
                Dim fontHeader As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, tamHeader, BaseColor.White)
                Dim fontCell As iTextSharp.text.Font = FontFactory.GetFont(FontFactory.HELVETICA, tamCell, cText)

                Dim pTitulo As New Paragraph(_titulo, fontTitulo)
                pTitulo.SpacingAfter = 2.5F
                doc.Add(pTitulo)

                Dim meta As String = "Generado el: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                If Not String.IsNullOrEmpty(_planta) Then meta &= "   |   Planta: " & _planta
                If Not String.IsNullOrEmpty(_subtitulo) Then meta &= "   |   " & _subtitulo
                Dim pMeta As New Paragraph(meta, fontSub)
                pMeta.SpacingAfter = 8.0F
                doc.Add(pMeta)

                If _dataSource IsNot Nothing AndAlso _dataSource.Columns.Count > 0 Then
                    Dim tabla As New PdfPTable(colCount)
                    tabla.WidthPercentage = 100.0F
                    tabla.HeaderRows = 1
                    tabla.SplitLate = False
                    tabla.SplitRows = True

                    ' Pesos proporcionales según longitud de encabezado y muestra de datos (ajuste total 100% en horizontal)
                    Dim widths(colCount - 1) As Single
                    Dim sampleRows As Integer = Math.Min(_dataSource.Rows.Count - 1, 80)
                    For c As Integer = 0 To colCount - 1
                        Dim col As DataColumn = _dataSource.Columns(c)
                        Dim maxLen As Integer = If(col.Caption, col.ColumnName).Trim().Length
                        For r As Integer = 0 To sampleRows
                            Dim rv As Object = _dataSource.Rows(r)(col)
                            If rv IsNot Nothing AndAlso Not IsDBNull(rv) Then
                                Dim l As Integer = rv.ToString().Trim().Length
                                If l > maxLen Then maxLen = l
                            End If
                        Next
                        widths(c) = Math.Max(18.0F, Math.Min(160.0F, If(col.Caption, "").Length * 1.1F + Math.Min(maxLen, 45) * 1.4F))
                    Next
                    tabla.SetWidths(widths)

                    Dim bgHeader As New BaseColor(Utilitarios.ColorPrimario.R, Utilitarios.ColorPrimario.G, Utilitarios.ColorPrimario.B)
                    Dim bgRowAlt As New BaseColor(Utilitarios.ColorFilaAlterna.R, Utilitarios.ColorFilaAlterna.G, Utilitarios.ColorFilaAlterna.B)

                    For Each col As DataColumn In _dataSource.Columns
                        Dim cell As New PdfPCell(New Phrase(col.Caption, fontHeader))
                        cell.BackgroundColor = bgHeader
                        cell.BorderColor = cDeep
                        cell.HorizontalAlignment = Element.ALIGN_CENTER
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE
                        cell.Padding = If(colCount >= 13, 2.8F, 3.5F)
                        tabla.AddCell(cell)
                    Next

                    Dim rowIndex As Integer = 0
                    For Each row As DataRow In _dataSource.Rows
                        Dim isAlt As Boolean = (rowIndex Mod 2 = 1)
                        For Each col As DataColumn In _dataSource.Columns
                            Dim rawVal As Object = row(col)
                            Dim texto As String = If(rawVal Is Nothing OrElse IsDBNull(rawVal), "", rawVal.ToString())
                            Dim cell As New PdfPCell(New Phrase(texto, fontCell))
                            If isAlt Then cell.BackgroundColor = bgRowAlt
                            cell.BorderColor = cBorder
                            cell.VerticalAlignment = Element.ALIGN_TOP
                            cell.Padding = If(colCount >= 13, 2.2F, 2.8F)
                            tabla.AddCell(cell)
                        Next
                        rowIndex += 1
                    Next

                    doc.Add(tabla)

                    Dim pTotal As New Paragraph("Total de registros: " & _dataSource.Rows.Count.ToString(), fontSub)
                    pTotal.Alignment = Element.ALIGN_RIGHT
                    pTotal.SpacingBefore = 6.0F
                    doc.Add(pTotal)
                Else
                    doc.Add(New Paragraph("No hay datos disponibles para mostrar en el informe.", fontSub))
                End If

            Finally
                If doc.IsOpen() Then doc.Close()
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Crea un objeto PrintDocument nativo de .NET para imprimir o previsualizar el informe.
    ''' </summary>
    Public Function CrearPrintDocument() As PrintDocument
        Dim pd As New PrintDocument()
        pd.DocumentName = _titulo
        pd.DefaultPageSettings.Landscape = True
        AddHandler pd.BeginPrint, AddressOf OnBeginPrint
        AddHandler pd.PrintPage, AddressOf OnPrintPage
        Return pd
    End Function

    Private Sub OnBeginPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
        _printRowIndex = 0
    End Sub

    Private Sub OnPrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        Dim bounds As System.Drawing.Rectangle = e.MarginBounds
        Dim y As Single = bounds.Top

        Using fTitle As New System.Drawing.Font("Arial", 12.0F, FontStyle.Bold),
              fSub As New System.Drawing.Font("Arial", 8.0F, FontStyle.Regular),
              fHeader As New System.Drawing.Font("Arial", 7.0F, FontStyle.Bold),
              fCell As New System.Drawing.Font("Arial", 6.8F, FontStyle.Regular),
              brushHeaderBg As New SolidBrush(Color.FromArgb(2, 94, 135)),
              brushAltBg As New SolidBrush(Color.FromArgb(234, 243, 245)),
              penBorder As New Pen(Color.FromArgb(160, 197, 207), 0.5F),
              brushTitle As New SolidBrush(Color.FromArgb(2, 94, 135)),
              sfHeader As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center, .Trimming = StringTrimming.EllipsisCharacter},
              sfCell As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .Trimming = StringTrimming.EllipsisCharacter}

            If _printRowIndex = 0 Then
                g.DrawString(_titulo, fTitle, brushTitle, bounds.Left, y)
                y += fTitle.GetHeight(g) + 4.0F
                Dim meta As String = "Fecha: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                If Not String.IsNullOrEmpty(_planta) Then meta &= " | Planta: " & _planta
                If Not String.IsNullOrEmpty(_subtitulo) Then meta &= " | " & _subtitulo
                g.DrawString(meta, fSub, Brushes.DimGray, bounds.Left, y)
                y += fSub.GetHeight(g) + 8.0F
            End If

            If _dataSource Is Nothing OrElse _dataSource.Columns.Count = 0 Then
                g.DrawString("Sin datos para imprimir.", fSub, Brushes.Black, bounds.Left, y)
                e.HasMorePages = False
                Return
            End If

            Dim colCount As Integer = _dataSource.Columns.Count
            Dim colWidth As Single = bounds.Width / CSng(colCount)
            Dim headerHeight As Single = 22.0F
            Dim x As Single = bounds.Left

            For i As Integer = 0 To colCount - 1
                Dim rectHeader As New RectangleF(x, y, colWidth, headerHeight)
                g.FillRectangle(brushHeaderBg, rectHeader)
                g.DrawRectangle(penBorder, rectHeader.X, rectHeader.Y, rectHeader.Width, rectHeader.Height)
                g.DrawString(_dataSource.Columns(i).Caption, fHeader, Brushes.White, rectHeader, sfHeader)
                x += colWidth
            Next
            y += headerHeight

            Dim rowHeight As Single = 20.0F
            Dim filasEnPagina As Integer = 0
            While _printRowIndex < _dataSource.Rows.Count
                If y + rowHeight > bounds.Bottom AndAlso filasEnPagina > 0 Then
                    e.HasMorePages = True
                    Return
                End If

                Dim row As DataRow = _dataSource.Rows(_printRowIndex)
                x = bounds.Left
                For i As Integer = 0 To colCount - 1
                    Dim rectCell As New RectangleF(x, y, colWidth, rowHeight)
                    If _printRowIndex Mod 2 = 1 Then
                        g.FillRectangle(brushAltBg, rectCell)
                    End If
                    g.DrawRectangle(penBorder, rectCell.X, rectCell.Y, rectCell.Width, rectCell.Height)
                    Dim val As Object = row(i)
                    Dim txt As String = If(val Is Nothing OrElse IsDBNull(val), "", val.ToString())
                    g.DrawString(txt, fCell, Brushes.Black, rectCell, sfCell)
                    x += colWidth
                Next

                y += rowHeight
                _printRowIndex += 1
                filasEnPagina += 1
            End While

            e.HasMorePages = False
        End Using
    End Sub

    Private Shared Function HtmlEncode(ByVal text As String) As String
        If String.IsNullOrEmpty(text) Then Return ""
        Return text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("""", "&quot;").Replace("'", "&#39;")
    End Function
End Class

Public Class CachedInfOt
    Inherits Component

    Public Sub New()
        MyBase.New()
    End Sub

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overridable Property IsCacheable() As Boolean
        Get
            Return True
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overridable Property ShareDBLogonInfo() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overridable Property CacheTimeOut() As TimeSpan
        Get
            Return TimeSpan.FromMinutes(15)
        End Get
        Set(ByVal value As TimeSpan)
        End Set
    End Property

    Public Overridable Function CreateReport() As InfOt
        Return New InfOt()
    End Function
End Class
