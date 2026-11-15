Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Microsoft.Win32
Imports Excel = Microsoft.Office.Interop.Excel

Public Class Utilitarios

    ' Paleta corporativa: #025E87 · #0191B3 · #A0C5CF · #E5EBEB · #66C9D3 (con tintes derivados para contraste)
    Public Shared ReadOnly ColorPrimario As Color = Color.FromArgb(2, 94, 135)            ' Azul petróleo (#025E87) - encabezados, barra de estado
    Public Shared ReadOnly ColorSecundario As Color = Color.FromArgb(1, 145, 179)         ' Azul cian (#0191B3) - acentos y bordes
    Public Shared ReadOnly ColorAcento As Color = Color.FromArgb(102, 201, 211)           ' Turquesa (#66C9D3)
    Public Shared ReadOnly ColorGrisAzulado As Color = Color.FromArgb(160, 197, 207)      ' Gris azulado (#A0C5CF) - menú
    Public Shared ReadOnly ColorFondoForm As Color = Color.FromArgb(229, 235, 235)        ' Gris niebla (#E5EBEB) - fondo formularios
    Public Shared ReadOnly ColorFondoPanel As Color = Color.FromArgb(242, 246, 246)       ' Superficie clara para pestañas (#F2F6F6)
    Public Shared ReadOnly ColorFondoInput As Color = Color.White                         ' Campos editables (#FFFFFF)
    Public Shared ReadOnly ColorFondoFoco As Color = Color.FromArgb(224, 244, 246)        ' Tinte turquesa al enfocar (#E0F4F6)
    Public Shared ReadOnly ColorFondoSoloLectura As Color = Color.FromArgb(215, 230, 234) ' Tinte gris azulado solo lectura (#D7E6EA)
    Public Shared ReadOnly ColorTextoPrincipal As Color = Color.FromArgb(15, 23, 42)      ' Texto principal alto contraste (#0F172A)
    Public Shared ReadOnly ColorTextoDestacado As Color = Color.FromArgb(185, 28, 28)     ' Rojo legible para alertas (#B91C1C)
    Public Shared ReadOnly ColorFilaAlterna As Color = Color.FromArgb(234, 243, 245)      ' Zebra suave (#EAF3F5)
    Public Shared ReadOnly ColorSeleccion As Color = Color.FromArgb(160, 197, 207)        ' Selección (#A0C5CF)
    Public Shared ReadOnly ColorTextoSeleccion As Color = Color.FromArgb(15, 23, 42)      ' Texto sobre selección (#0F172A)
    Public Shared ReadOnly ColorNodoActivo As Color = Color.FromArgb(179, 228, 233)       ' Tinte turquesa para nodo activo (#B3E4E9)
    Public Shared ReadOnly ColorBotonHover As Color = Color.FromArgb(217, 241, 244)       ' Hover de botones (#D9F1F4)

    ' Colores semánticos centralizados (eliminación de valores hardcodeados en todo el proyecto)
    Public Shared ReadOnly ColorBordeGrilla As Color = Color.FromArgb(200, 218, 223)      ' Bordes de celdas en DataGridView (#C8DEDF)
    Public Shared ReadOnly ColorGanttBarra As Color = Color.FromArgb(220, 38, 38)         ' Barra de actividades en Carta Gantt (#DC2626)
    Public Shared ReadOnly ColorErrorInput As Color = Color.FromArgb(255, 232, 232)       ' Resaltado de búsqueda no encontrada (#FFE8E8)
    Public Shared ReadOnly ColorTextoAtenuado As Color = Color.FromArgb(120, 140, 150)    ' Texto secundario / leyendas (#788C96)
    Public Shared ReadOnly ColorTurnoNocheFondo As Color = Color.FromArgb(186, 230, 253)  ' Fondo Turno Noche (#BAE6FD)
    Public Shared ReadOnly ColorTurnoNocheTexto As Color = Color.FromArgb(12, 74, 110)    ' Texto Turno Noche (#0C4A6E)
    Public Shared ReadOnly ColorTurnoMananaFondo As Color = Color.FromArgb(187, 247, 208) ' Fondo Turno Mañana (#BBF7D0)
    Public Shared ReadOnly ColorTurnoMananaTexto As Color = Color.FromArgb(20, 83, 45)    ' Texto Turno Mañana (#14532D)
    Public Shared ReadOnly ColorTurnoTardeFondo As Color = Color.FromArgb(254, 215, 170)  ' Fondo Turno Tarde (#FED7AA)
    Public Shared ReadOnly ColorTurnoTardeTexto As Color = Color.FromArgb(124, 45, 18)    ' Texto Turno Tarde (#7C2D12)

    ''' <summary>
    ''' Escapa un texto para usarlo dentro de un LIKE de DataView.RowFilter.
    ''' </summary>
    Public Shared Function EscaparLike(ByVal texto As String) As String
        If String.IsNullOrEmpty(texto) Then Return ""
        Dim sb As New System.Text.StringBuilder(texto.Length + 8)
        For Each c As Char In texto
            Select Case c
                Case "'"c : sb.Append("''")
                Case "["c, "]"c, "*"c, "%"c : sb.Append("[").Append(c).Append("]")
                Case Else : sb.Append(c)
            End Select
        Next
        Return sb.ToString()
    End Function

    ''' <summary>
    ''' Solicita al usuario la ruta donde guardar el archivo PDF antes de iniciar la exportación.
    ''' </summary>
    Public Shared Function SolicitarRutaGuardadoPdf(Optional ByVal prefijoNombre As String = "Informe_Mantencion") As String
        Using sfd As New SaveFileDialog()
            sfd.Title = "Guardar Informe en PDF"
            sfd.Filter = "Documento PDF (*.pdf)|*.pdf"
            sfd.DefaultExt = "pdf"
            sfd.AddExtension = True
            sfd.OverwritePrompt = True
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            Dim limpio As String = prefijoNombre
            For Each c As Char In Path.GetInvalidFileNameChars()
                limpio = limpio.Replace(c, "_"c)
            Next
            sfd.FileName = limpio & "_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".pdf"

            If sfd.ShowDialog() = DialogResult.OK Then
                Return sfd.FileName
            End If
        End Using
        Return String.Empty
    End Function

    ''' <summary>
    ''' Localiza de forma determinista la ruta física de una plantilla Excel (.xls)
    ''' buscando en el subdirectorio plantillas, directorio base y rutas de instalación (con tolerancia a mayúsculas/minúsculas).
    ''' </summary>
    Public Shared Function ObtenerRutaPlantilla(ByVal nombrePlantilla As String) As String
        If String.IsNullOrWhiteSpace(nombrePlantilla) Then Return String.Empty

        Dim soloNombre As String = Path.GetFileName(nombrePlantilla)
        Dim baseDir As String = AppDomain.CurrentDomain.BaseDirectory
        Dim appDir As String = Application.StartupPath

        Dim candidatos As String() = {
            Path.Combine(baseDir, "plantillas", soloNombre),
            Path.Combine(appDir, "plantillas", soloNombre),
            Path.Combine(baseDir, soloNombre),
            Path.Combine(appDir, soloNombre),
            Path.Combine(baseDir, "..\..\plantillas", soloNombre)
        }

        For Each ruta In candidatos
            If File.Exists(ruta) Then Return Path.GetFullPath(ruta)
        Next

        ' Respaldo insensible a mayúsculas/minúsculas para sistemas de archivos case-sensitive (macOS/Wine/Linux)
        Dim carpetas As String() = {
            Path.Combine(baseDir, "plantillas"),
            Path.Combine(appDir, "plantillas"),
            baseDir,
            appDir
        }
        For Each carpeta In carpetas
            Try
                If Directory.Exists(carpeta) Then
                    For Each archivo As String In Directory.GetFiles(carpeta, "*.xls")
                        If String.Equals(Path.GetFileName(archivo), soloNombre, StringComparison.OrdinalIgnoreCase) Then
                            Return Path.GetFullPath(archivo)
                        End If
                    Next
                End If
            Catch
            End Try
        Next

        Return String.Empty
    End Function

    ''' <summary>
    ''' Inicializa un par de DateTimePicker al rango por defecto del mes en curso (día 1 hasta hoy).
    ''' </summary>
    Public Shared Sub InicializarRangoMesActual(ByVal dtpDesde As DateTimePicker, ByVal dtpHasta As DateTimePicker)
        Dim hoy As DateTime = DateTime.Today
        Dim inicioMes As New DateTime(hoy.Year, hoy.Month, 1)
        If dtpDesde IsNot Nothing Then dtpDesde.Value = inicioMes
        If dtpHasta IsNot Nothing Then dtpHasta.Value = hoy
    End Sub

    ''' <summary>
    ''' Verifica que la fecha Desde sea menor o igual que la fecha Hasta.
    ''' </summary>
    Public Shared Function ValidarRangoFechas(ByVal dtpDesde As DateTimePicker, ByVal dtpHasta As DateTimePicker, Optional ByVal mostrarAviso As Boolean = True) As Boolean
        If dtpDesde Is Nothing OrElse dtpHasta Is Nothing Then Return True
        If dtpDesde.Value.Date > dtpHasta.Value.Date Then
            If mostrarAviso Then
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'." & Environment.NewLine & "Corrija el rango de fechas antes de consultar o exportar.", "Rango de Fechas Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            dtpDesde.Focus()
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Abre o crea un libro de Excel a partir de una plantilla o de un libro en blanco si la plantilla no existe.
    ''' </summary>
    Public Shared Function CrearLibroDesdePlantilla(ByVal excelApp As Excel.Application, ByVal nombrePlantilla As String) As Excel.Workbook
        If excelApp Is Nothing Then Return Nothing
        Dim ruta As String = ObtenerRutaPlantilla(nombrePlantilla)
        If Not String.IsNullOrEmpty(ruta) AndAlso File.Exists(ruta) Then
            Return excelApp.Workbooks.Add(ruta)
        Else
            Return excelApp.Workbooks.Add()
        End If
    End Function

    ''' <summary>
    ''' Activa o restaura el modo de alto rendimiento en una instancia de Excel para acelerar la escritura de celdas.
    ''' </summary>
    Public Shared Sub ConfigurarModoRapidoExcel(ByVal excelApp As Excel.Application, ByVal modoRapido As Boolean)
        If excelApp Is Nothing Then Exit Sub
        Try
            excelApp.ScreenUpdating = Not modoRapido
            excelApp.DisplayAlerts = Not modoRapido
            excelApp.EnableEvents = Not modoRapido
            If modoRapido Then
                excelApp.Calculation = Excel.XlCalculation.xlCalculationManual
            Else
                excelApp.Calculation = Excel.XlCalculation.xlCalculationAutomatic
            End If
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' Busca el nombre exacto con puerto de la impresora nativa "Microsoft Print to PDF" en Windows 10 y 11.
    ''' </summary>
    Public Shared Function ActivarImpresoraPdfNativa(ByVal excelApp As Excel.Application) As String
        Const nombreImpresora As String = "Microsoft Print to PDF"
        Dim candidatos As New List(Of String)()

        Try
            Using regKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion\Devices", False)
                If regKey IsNot Nothing Then
                    For Each valueName As String In regKey.GetValueNames()
                        If String.Equals(valueName, nombreImpresora, StringComparison.OrdinalIgnoreCase) Then
                            Dim rawVal As String = Convert.ToString(regKey.GetValue(valueName))
                            If Not String.IsNullOrEmpty(rawVal) AndAlso rawVal.Contains(",") Then
                                Dim puerto As String = rawVal.Split(","c)(1).Trim()
                                candidatos.Add(valueName & " en " & puerto)
                                candidatos.Add(valueName & " on " & puerto)
                            End If
                        End If
                    Next
                End If
            End Using
        Catch
        End Try

        For i As Integer = 0 To 15
            Dim puerto As String = "Ne" & i.ToString("00") & ":"
            candidatos.Add(nombreImpresora & " en " & puerto)
            candidatos.Add(nombreImpresora & " on " & puerto)
        Next
        candidatos.Add(nombreImpresora)

        If excelApp IsNot Nothing Then
            For Each candidato As String In candidatos
                Try
                    excelApp.ActivePrinter = candidato
                    Return excelApp.ActivePrinter
                Catch
                End Try
            Next
        End If

        Return nombreImpresora
    End Function

    ''' <summary>
    ''' Exporta y guarda un libro de Excel directamente a un archivo PDF en Windows 10 y 11.
    ''' Muestra el cuadro de diálogo Guardar como, genera el PDF nativamente (o mediante Microsoft Print to PDF) y ofrece abrirlo.
    ''' </summary>
    Public Shared Sub ImprimirLibroAPdfWindows(ByVal excelApp As Excel.Application, ByVal workbook As Excel.Workbook, Optional ByVal rutaArchivoDestino As String = "", Optional ByVal prefijoNombre As String = "Informe_Mantencion")
        If workbook Is Nothing Then Exit Sub

        Dim rutaPdf As String = rutaArchivoDestino
        If String.IsNullOrEmpty(rutaPdf) Then
            rutaPdf = SolicitarRutaGuardadoPdf(prefijoNombre)
        End If

        If String.IsNullOrEmpty(rutaPdf) Then
            Exit Sub
        End If

        If File.Exists(rutaPdf) Then
            Try
                File.Delete(rutaPdf)
            Catch ex As Exception
                RegistroErrores.MostrarYRegistrar(ex, "Exportar a PDF")
                Exit Sub
            End Try
        End If

        Dim exportadoOk As Boolean = False

        ' 1. Exportación directa nativa a PDF de alta velocidad (Excel.XlFixedFormatType.xlTypePDF = 0)
        Try
            Dim objWorkbook As Object = workbook
            objWorkbook.ExportAsFixedFormat(0, rutaPdf, 0, True, False, Type.Missing, Type.Missing, False)
            exportadoOk = File.Exists(rutaPdf)
        Catch
            exportadoOk = False
        End Try

        ' 2. Respaldo mediante impresora nativa "Microsoft Print to PDF" de Windows 10/11 hacia archivo
        If Not exportadoOk Then
            Try
                Dim impresoraPdf As String = ActivarImpresoraPdfNativa(excelApp)
                If Not String.IsNullOrEmpty(impresoraPdf) Then
                    workbook.PrintOutEx(From:=Type.Missing, [To]:=Type.Missing, Copies:=1, Preview:=False, ActivePrinter:=impresoraPdf, PrintToFile:=True, Collate:=True, PrToFileName:=rutaPdf)
                    exportadoOk = File.Exists(rutaPdf)
                End If
            Catch ex As Exception
                exportadoOk = False
            End Try
        End If

        If Not exportadoOk Then
            MessageBox.Show("No fue posible generar el archivo PDF mediante Excel ni la impresora de sistema." & Environment.NewLine & "Compruebe que el destino sea escribible o use la exportación directa a PDF.", "Exportar a PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If exportadoOk AndAlso File.Exists(rutaPdf) Then
            If MessageBox.Show("Archivo PDF guardado exitosamente en:" & Environment.NewLine & rutaPdf & Environment.NewLine & Environment.NewLine & "¿Desea abrir el documento PDF ahora?", "Exportación PDF Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                AbrirDocumento(rutaPdf)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Abre un documento o archivo con la aplicación predeterminada de Windows en .NET 8 (UseShellExecute = True).
    ''' </summary>
    Public Shared Sub AbrirDocumento(ByVal ruta As String)
        If String.IsNullOrEmpty(ruta) OrElse Not File.Exists(ruta) Then Exit Sub
        Try
            Dim psi As New ProcessStartInfo(ruta) With {.UseShellExecute = True}
            Process.Start(psi)
        Catch
            Try
                Dim psi As New ProcessStartInfo("explorer.exe", """" & ruta & """") With {.UseShellExecute = True}
                Process.Start(psi)
            Catch
            End Try
        End Try
    End Sub

    ''' <summary>
    ''' Exporta el contenido visible de un DataGridView directamente a un archivo PDF utilizando iTextSharp.
    ''' Solución 100% nativa que no requiere Excel ni controladores de impresora virtual, garantizando cero bloqueos o diálogos modales.
    ''' </summary>
    Public Shared Function ExportarGrillaAPdf(ByVal grilla As DataGridView, ByVal rutaArchivo As String, ByVal titulo As String, Optional ByVal subtitulo As String = "") As Boolean
        If grilla Is Nothing OrElse grilla.Columns.Count = 0 OrElse String.IsNullOrEmpty(rutaArchivo) Then Return False

        Dim columnasVisibles As New List(Of DataGridViewColumn)()
        For Each col As DataGridViewColumn In grilla.Columns
            If col.Visible Then columnasVisibles.Add(col)
        Next
        If columnasVisibles.Count = 0 Then Return False

        Try
            If File.Exists(rutaArchivo) Then
                Try
                    File.Delete(rutaArchivo)
                Catch
                    Return False
                End Try
            End If

            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER.Rotate(), 20.0F, 20.0F, 25.0F, 25.0F)
            Using fs As New FileStream(rutaArchivo, FileMode.Create, FileAccess.Write, FileShare.None)
                Dim writer As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs)
                doc.Open()

                Dim fontTitulo As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 13.0F, iTextSharp.text.BaseColor.DarkGray)
                Dim fontSub As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 8.5F, iTextSharp.text.BaseColor.Gray)
                Dim fontHeader As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 7.2F, iTextSharp.text.BaseColor.White)
                Dim fontCell As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 6.8F, iTextSharp.text.BaseColor.Black)

                Dim pTitulo As New iTextSharp.text.Paragraph(titulo, fontTitulo)
                pTitulo.SpacingAfter = 3.0F
                doc.Add(pTitulo)

                Dim meta As String = "Generado el: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                If Not String.IsNullOrEmpty(subtitulo) Then meta &= "   |   " & subtitulo
                Dim pMeta As New iTextSharp.text.Paragraph(meta, fontSub)
                pMeta.SpacingAfter = 10.0F
                doc.Add(pMeta)

                Dim tabla As New iTextSharp.text.pdf.PdfPTable(columnasVisibles.Count)
                tabla.WidthPercentage = 100.0F
                tabla.HeaderRows = 1

                Dim bgHeader As New iTextSharp.text.BaseColor(ColorPrimario.R, ColorPrimario.G, ColorPrimario.B)
                Dim bgRowAlt As New iTextSharp.text.BaseColor(ColorFilaAlterna.R, ColorFilaAlterna.G, ColorFilaAlterna.B)

                For Each col As DataGridViewColumn In columnasVisibles
                    Dim celdaEncabezado As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(col.HeaderText, fontHeader))
                    celdaEncabezado.BackgroundColor = bgHeader
                    celdaEncabezado.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    celdaEncabezado.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                    celdaEncabezado.Padding = 4.0F
                    tabla.AddCell(celdaEncabezado)
                Next

                Dim rowIndex As Integer = 0
                For i As Integer = 0 To grilla.RowCount - 1
                    If grilla.Rows(i).IsNewRow Then Continue For
                    Dim isAlt As Boolean = (rowIndex Mod 2 = 1)
                    For Each col As DataGridViewColumn In columnasVisibles
                        Dim val As Object = grilla.Rows(i).Cells(col.Index).Value
                        Dim texto As String = If(val Is Nothing OrElse IsDBNull(val), "", val.ToString())
                        Dim celdaDato As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(texto, fontCell))
                        If isAlt Then celdaDato.BackgroundColor = bgRowAlt
                        celdaDato.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
                        celdaDato.Padding = 3.0F
                        tabla.AddCell(celdaDato)
                    Next
                    rowIndex += 1
                Next

                doc.Add(tabla)

                Dim pTotal As New iTextSharp.text.Paragraph("Total de registros: " & rowIndex.ToString(), fontSub)
                pTotal.Alignment = iTextSharp.text.Element.ALIGN_RIGHT
                pTotal.SpacingBefore = 8.0F
                doc.Add(pTotal)

                doc.Close()
            End Using
            Return File.Exists(rutaArchivo)
        Catch ex As Exception
            RegistroErrores.RegistrarError(ex, "Exportar Grilla a PDF Nativo")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Exporta múltiples grillas (DataGridView + subtítulo de sección) en un solo documento PDF corporativo usando iTextSharp.
    ''' </summary>
    Public Shared Function ExportarGrillasAPdfNativo(ByVal secciones As IEnumerable(Of KeyValuePair(Of String, DataGridView)), ByVal rutaArchivo As String, ByVal titulo As String, Optional ByVal subtituloGeneral As String = "") As Boolean
        If secciones Is Nothing OrElse String.IsNullOrEmpty(rutaArchivo) Then Return False
        Try
            If File.Exists(rutaArchivo) Then
                Try
                    File.Delete(rutaArchivo)
                Catch
                    Return False
                End Try
            End If

            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER.Rotate(), 20.0F, 20.0F, 25.0F, 25.0F)
            Dim tablasAgregadas As Integer = 0

            Using fs As New FileStream(rutaArchivo, FileMode.Create, FileAccess.Write, FileShare.None)
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs)
                doc.Open()

                Dim fontTitulo As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 13.0F, iTextSharp.text.BaseColor.DarkGray)
                Dim fontSub As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 8.5F, iTextSharp.text.BaseColor.Gray)
                Dim fontSeccion As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 10.0F, New iTextSharp.text.BaseColor(ColorPrimario.R, ColorPrimario.G, ColorPrimario.B))
                Dim fontHeader As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 7.2F, iTextSharp.text.BaseColor.White)
                Dim fontCell As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 6.8F, iTextSharp.text.BaseColor.Black)

                Dim pTitulo As New iTextSharp.text.Paragraph(titulo, fontTitulo)
                pTitulo.SpacingAfter = 3.0F
                doc.Add(pTitulo)

                Dim meta As String = "Generado el: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                If Not String.IsNullOrEmpty(subtituloGeneral) Then meta &= "   |   " & subtituloGeneral
                Dim pMeta As New iTextSharp.text.Paragraph(meta, fontSub)
                pMeta.SpacingAfter = 8.0F
                doc.Add(pMeta)

                Dim bgHeader As New iTextSharp.text.BaseColor(ColorPrimario.R, ColorPrimario.G, ColorPrimario.B)
                Dim bgRowAlt As New iTextSharp.text.BaseColor(ColorFilaAlterna.R, ColorFilaAlterna.G, ColorFilaAlterna.B)

                For Each sec As KeyValuePair(Of String, DataGridView) In secciones
                    Dim grilla As DataGridView = sec.Value
                    If grilla Is Nothing OrElse grilla.Columns.Count = 0 Then Continue For

                    Dim colsVis As New List(Of DataGridViewColumn)()
                    For Each col As DataGridViewColumn In grilla.Columns
                        If col.Visible Then colsVis.Add(col)
                    Next
                    If colsVis.Count = 0 Then Continue For

                    If Not String.IsNullOrWhiteSpace(sec.Key) Then
                        Dim pSec As New iTextSharp.text.Paragraph(sec.Key, fontSeccion)
                        pSec.SpacingBefore = 8.0F
                        pSec.SpacingAfter = 4.0F
                        doc.Add(pSec)
                    End If

                    Dim tabla As New iTextSharp.text.pdf.PdfPTable(colsVis.Count)
                    tabla.WidthPercentage = 100.0F
                    tabla.HeaderRows = 1
                    tabla.SpacingAfter = 6.0F

                    For Each col As DataGridViewColumn In colsVis
                        Dim celdaEnc As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(col.HeaderText, fontHeader))
                        celdaEnc.BackgroundColor = bgHeader
                        celdaEnc.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                        celdaEnc.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                        celdaEnc.Padding = 3.5F
                        tabla.AddCell(celdaEnc)
                    Next

                    Dim rowCount As Integer = 0
                    For i As Integer = 0 To grilla.RowCount - 1
                        If grilla.Rows(i).IsNewRow Then Continue For
                        Dim isAlt As Boolean = (rowCount Mod 2 = 1)
                        For Each col As DataGridViewColumn In colsVis
                            Dim val As Object = grilla.Rows(i).Cells(col.Index).Value
                            Dim texto As String = If(val Is Nothing OrElse IsDBNull(val), "", val.ToString())
                            Dim celdaDato As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(texto, fontCell))
                            If isAlt Then celdaDato.BackgroundColor = bgRowAlt
                            celdaDato.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
                            celdaDato.Padding = 2.8F
                            tabla.AddCell(celdaDato)
                        Next
                        rowCount += 1
                    Next

                    doc.Add(tabla)
                    tablasAgregadas += 1
                Next

                doc.Close()
            End Using

            Return tablasAgregadas > 0 AndAlso File.Exists(rutaArchivo)
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Solicita al usuario la ruta donde guardar un archivo Excel nativo (.xls).
    ''' </summary>
    Public Shared Function SolicitarRutaGuardadoExcel(Optional ByVal prefijoNombre As String = "Informe_Mantencion") As String
        Using sfd As New SaveFileDialog()
            sfd.Title = "Guardar Informe en Excel"
            sfd.Filter = "Libro Excel (*.xls)|*.xls"
            sfd.DefaultExt = "xls"
            sfd.AddExtension = True
            sfd.OverwritePrompt = True
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            Dim limpio As String = prefijoNombre
            For Each c As Char In Path.GetInvalidFileNameChars()
                limpio = limpio.Replace(c, "_"c)
            Next
            sfd.FileName = limpio & "_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".xls"
            If sfd.ShowDialog() = DialogResult.OK Then
                Return sfd.FileName
            End If
        End Using
        Return String.Empty
    End Function

    ''' <summary>
    ''' Respaldo 100% libre de dependencias para exportar una o más tablas/grillas a Excel (SpreadsheetML .xls)
    ''' cuando Microsoft Excel COM no está instalado (macOS/Whisky o PCs Windows sin Office).
    ''' </summary>
    Public Shared Function ExportarGrillasAExcelNativo(ByVal hojas As IEnumerable(Of KeyValuePair(Of String, DataGridView)), ByVal prefijoNombre As String, ByVal tituloInforme As String, Optional ByVal subtitulo As String = "") As Boolean
        If hojas Is Nothing Then Return False
        Dim ruta As String = SolicitarRutaGuardadoExcel(prefijoNombre)
        If String.IsNullOrEmpty(ruta) Then Return False

        Try
            Dim sb As New System.Text.StringBuilder(8192)
            sb.AppendLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            sb.AppendLine("<?mso-application progid=""Excel.Sheet""?>")
            sb.AppendLine("<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"">")
            sb.AppendLine(" <Styles>")
            sb.AppendLine("  <Style ss:ID=""Titulo""><Font ss:FontName=""Segoe UI"" ss:Size=""13"" ss:Bold=""1"" ss:Color=""#025E87""/></Style>")
            sb.AppendLine("  <Style ss:ID=""Subtitulo""><Font ss:FontName=""Segoe UI"" ss:Size=""9"" ss:Italic=""1"" ss:Color=""#475569""/></Style>")
            sb.AppendLine("  <Style ss:ID=""Header""><Font ss:FontName=""Segoe UI"" ss:Size=""9"" ss:Bold=""1"" ss:Color=""#FFFFFF""/><Interior ss:Color=""#025E87"" ss:Pattern=""Solid""/><Alignment ss:Horizontal=""Center"" ss:Vertical=""Center""/></Style>")
            sb.AppendLine("  <Style ss:ID=""Cell""><Font ss:FontName=""Segoe UI"" ss:Size=""9"" ss:Color=""#0F172A""/><Borders><Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#C8DEDF""/></Borders></Style>")
            sb.AppendLine("  <Style ss:ID=""CellAlt""><Font ss:FontName=""Segoe UI"" ss:Size=""9"" ss:Color=""#0F172A""/><Interior ss:Color=""#EAF3F5"" ss:Pattern=""Solid""/><Borders><Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#C8DEDF""/></Borders></Style>")
            sb.AppendLine(" </Styles>")

            Dim idxHoja As Integer = 1
            Dim usados As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
            For Each hoja In hojas
                Dim g As DataGridView = hoja.Value
                If g Is Nothing OrElse g.Columns.Count = 0 Then Continue For

                Dim colsVis As New List(Of DataGridViewColumn)()
                For Each col As DataGridViewColumn In g.Columns
                    If col.Visible Then colsVis.Add(col)
                Next
                If colsVis.Count = 0 Then Continue For

                Dim nombreHoja As String = If(String.IsNullOrWhiteSpace(hoja.Key), "Hoja" & idxHoja, hoja.Key)
                For Each bad As Char In New Char() {"\"c, "/"c, "?"c, "*"c, "["c, "]"c, ":"c}
                    nombreHoja = nombreHoja.Replace(bad, " "c)
                Next
                nombreHoja = nombreHoja.Trim()
                If nombreHoja.Length > 28 Then nombreHoja = nombreHoja.Substring(0, 28)
                If String.IsNullOrEmpty(nombreHoja) Then nombreHoja = "Hoja" & idxHoja
                While usados.Contains(nombreHoja)
                    nombreHoja = nombreHoja.Substring(0, Math.Min(25, nombreHoja.Length)) & "_" & idxHoja
                    idxHoja += 1
                End While
                usados.Add(nombreHoja)

                sb.Append(" <Worksheet ss:Name=""").Append(System.Security.SecurityElement.Escape(nombreHoja)).AppendLine(""">")
                sb.AppendLine("  <Table>")
                For Each col As DataGridViewColumn In colsVis
                    Dim w As Integer = Math.Max(75, Math.Min(280, col.Width))
                    sb.Append("   <Column ss:Width=""").Append(w).AppendLine("""/>")
                Next

                sb.Append("   <Row><Cell ss:StyleID=""Titulo""><Data ss:Type=""String"">").Append(System.Security.SecurityElement.Escape(tituloInforme)).AppendLine("</Data></Cell></Row>")
                Dim meta As String = "Generado el " & DateTime.Now.ToString("dd-MM-yyyy HH:mm")
                If Not String.IsNullOrWhiteSpace(subtitulo) Then meta &= " | " & subtitulo
                sb.Append("   <Row><Cell ss:StyleID=""Subtitulo""><Data ss:Type=""String"">").Append(System.Security.SecurityElement.Escape(meta)).AppendLine("</Data></Cell></Row>")
                sb.AppendLine("   <Row/>")

                sb.Append("   <Row>")
                For Each col As DataGridViewColumn In colsVis
                    sb.Append("<Cell ss:StyleID=""Header""><Data ss:Type=""String"">").Append(System.Security.SecurityElement.Escape(col.HeaderText)).Append("</Data></Cell>")
                Next
                sb.AppendLine("</Row>")

                Dim filaIdx As Integer = 0
                For r As Integer = 0 To g.RowCount - 1
                    If g.Rows(r).IsNewRow Then Continue For
                    Dim st As String = If(filaIdx Mod 2 = 1, "CellAlt", "Cell")
                    sb.Append("   <Row>")
                    For Each col As DataGridViewColumn In colsVis
                        Dim val As Object = g.Rows(r).Cells(col.Index).Value
                        Dim txt As String = If(val Is Nothing OrElse IsDBNull(val), "", val.ToString())
                        sb.Append("<Cell ss:StyleID=""").Append(st).Append("""><Data ss:Type=""String"">").Append(System.Security.SecurityElement.Escape(txt)).Append("</Data></Cell>")
                    Next
                    sb.AppendLine("</Row>")
                    filaIdx += 1
                Next

                sb.AppendLine("  </Table>")
                sb.AppendLine(" </Worksheet>")
                idxHoja += 1
            Next

            sb.AppendLine("</Workbook>")
            File.WriteAllText(ruta, sb.ToString(), System.Text.Encoding.UTF8)

            If File.Exists(ruta) Then
                If MessageBox.Show("Libro Excel generado sin dependencias en:" & Environment.NewLine & ruta & Environment.NewLine & Environment.NewLine & "¿Desea abrir el archivo ahora?", "Exportación Excel Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    AbrirDocumento(ruta)
                End If
                Return True
            End If
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Exportar Libro Excel Nativo")
        End Try
        Return False
    End Function

    Public Shared Function ExportarGrillaAExcelNativo(ByVal grilla As DataGridView, ByVal prefijoNombre As String, ByVal tituloInforme As String, Optional ByVal subtitulo As String = "") As Boolean
        If grilla Is Nothing Then Return False
        Dim hojas As New List(Of KeyValuePair(Of String, DataGridView)) From {
            New KeyValuePair(Of String, DataGridView)("Informe", grilla)
        }
        Return ExportarGrillasAExcelNativo(hojas, prefijoNombre, tituloInforme, subtitulo)
    End Function

    Public Shared Function ExportarDataTableAExcelNativo(ByVal dt As DataTable, ByVal prefijoNombre As String, ByVal tituloInforme As String, Optional ByVal subtitulo As String = "") As Boolean
        If dt Is Nothing Then Return False
        Using dgvTemp As New DataGridView()
            For Each col As DataColumn In dt.Columns
                dgvTemp.Columns.Add(col.ColumnName, col.ColumnName)
            Next
            For Each row As DataRow In dt.Rows
                dgvTemp.Rows.Add(row.ItemArray)
            Next
            Return ExportarGrillaAExcelNativo(dgvTemp, prefijoNombre, tituloInforme, subtitulo)
        End Using
    End Function

    ''' <summary>
    ''' Cierra y libera de forma segura los objetos COM de Excel para no dejar procesos EXCEL.EXE en segundo plano.
    ''' </summary>
    Public Shared Sub LiberarExcel(ByRef workbook As Excel.Workbook, ByRef excelApp As Excel.Application)
        Try
            If workbook IsNot Nothing Then
                Try
                    workbook.Close(False)
                Catch
                End Try
                LiberarObjetoCom(workbook)
                workbook = Nothing
            End If
        Catch
        End Try
        Try
            If excelApp IsNot Nothing Then
                Try
                    excelApp.ScreenUpdating = True
                    excelApp.DisplayAlerts = False
                    excelApp.Quit()
                Catch
                End Try
                LiberarObjetoCom(excelApp)
                excelApp = Nothing
            End If
        Catch
        End Try
        OptimizarMemoria()
    End Sub

    ''' <summary>
    ''' Activa DoubleBuffering en controles (DataGridView, TreeView, Panel) para eliminar el parpadeo y acelerar el renderizado.
    ''' </summary>
    Public Shared Sub HabilitarDobleBuffer(ByVal ctrl As Control)
        If ctrl Is Nothing Then Exit Sub
        Try
            Dim prop As PropertyInfo = ctrl.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
            If prop IsNot Nothing Then
                prop.SetValue(ctrl, True, Nothing)
            End If
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' Configura un TreeView con estilos visuales modernos acordes a la paleta corporativa:
    ''' doble búfer, selección persistente sin atenuación y renderizado nativo 100% perfecto
    ''' para casillas de verificación (CheckBoxes), sangría y espacios.
    ''' </summary>
    Public Shared Sub ConfigurarTreeViewModerno(ByVal tv As TreeView)
        If tv Is Nothing Then Exit Sub
        HabilitarDobleBuffer(tv)
        tv.HideSelection = False
        tv.DrawMode = TreeViewDrawMode.Normal
        tv.BackColor = Color.White
        tv.ForeColor = ColorTextoPrincipal
        tv.LineColor = ColorSecundario
    End Sub

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
        If grilla Is Nothing Then Exit Sub
        For i As Integer = 0 To grilla.RowCount - 1
            grilla.Rows(i).HeaderCell.Value = (i + 1).ToString()
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

    Public Sub crgComboTurnos(ByRef cmb As ComboBox)
        cmb.Items.Add("Noche")
        cmb.Items.Add("Mañana")
        cmb.Items.Add("Tarde")
        cmb.Text = cmb.Items(0)
    End Sub

    Public Sub ValidarPersonalOT(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case e.KeyChar
            Case ChrW(Keys.Space), "."c, ","c, "-"c, "_"c, "+"c, "*"c, "/"c, "$"c, "#"c, "%"c, "&"c, "?"c, "¿"c, "!"c, "¡"c
                e.Handled = True
        End Select
    End Sub

    Private Shared ReadOnly _camposSoloLectura As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {
        "text_turno", "txtDuracionOt", "txtIDNuevoNodo", "txtIDNodoSel",
        "txtIdTarea", "txtIdModulo", "txtIdDatoTecnico", "txtIdMant",
        "txtIdCiclo", "txtDuracionCiclo", "txtFrecuenciaPlan",
        "txtUltimoCiclo", "txtDuracionPlan"
    }

    Private Shared ReadOnly _formulariosConTema As New HashSet(Of Form)()
    Private Shared ReadOnly _menuRenderer As New MenuCorporativoRenderer()
    Private Shared ReadOnly _cacheFuentes As New Dictionary(Of String, Font)(StringComparer.Ordinal)
    Private Shared _temaGlobalRegistrado As Boolean = False

    Public Shared Sub RegistrarTemaGlobal()
        If _temaGlobalRegistrado Then Exit Sub
        _temaGlobalRegistrado = True
        AddHandler Application.Idle, AddressOf AlEstarInactivoAplicacion
    End Sub

    Private Shared Sub AlEstarInactivoAplicacion(ByVal sender As Object, ByVal e As EventArgs)
        Try
            For Each frm As Form In Application.OpenForms
                If frm IsNot Nothing AndAlso Not frm.IsDisposed AndAlso frm.IsHandleCreated AndAlso Not _formulariosConTema.Contains(frm) Then
                    If TypeOf frm Is Inicio OrElse TypeOf frm Is FrmConfiguracionServidor Then
                        _formulariosConTema.Add(frm)
                        Continue For
                    End If
                    AplicarTemaModerno(frm)
                End If
            Next
        Catch
        End Try
    End Sub

    Private Shared Sub AlCerrarFormularioTema(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        Dim frm As Form = TryCast(sender, Form)
        If frm Is Nothing Then Exit Sub
        _formulariosConTema.Remove(frm)
        RemoveHandler frm.FormClosed, AddressOf AlCerrarFormularioTema
    End Sub

    Private Shared Sub UnificarFuenteCorporativa(ByVal ctrl As Control)
        If ctrl Is Nothing OrElse ctrl.Font Is Nothing Then Exit Sub
        Dim fam As String = ctrl.Font.FontFamily.Name
        If String.Equals(fam, "Segoe UI", StringComparison.OrdinalIgnoreCase) OrElse
           String.Equals(fam, "Consolas", StringComparison.OrdinalIgnoreCase) Then
            Exit Sub
        End If
        If fam.Equals("Calibri", StringComparison.OrdinalIgnoreCase) OrElse
           fam.Equals("Microsoft Sans Serif", StringComparison.OrdinalIgnoreCase) OrElse
           fam.Equals("Tahoma", StringComparison.OrdinalIgnoreCase) OrElse
           fam.Equals("Corbel", StringComparison.OrdinalIgnoreCase) OrElse
           fam.Equals("Arial", StringComparison.OrdinalIgnoreCase) Then
            Dim sizePt As Single = ctrl.Font.SizeInPoints
            If fam.Equals("Calibri", StringComparison.OrdinalIgnoreCase) AndAlso sizePt >= 10.5F AndAlso sizePt <= 12.0F Then
                sizePt = 9.5F
            ElseIf fam.Equals("Calibri", StringComparison.OrdinalIgnoreCase) AndAlso sizePt >= 9.0F AndAlso sizePt < 10.5F Then
                sizePt = 8.75F
            End If
            Dim st As FontStyle = ctrl.Font.Style
            Dim key As String = sizePt.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture) & "|" & CInt(st).ToString()
            Dim cached As Font = Nothing
            If Not _cacheFuentes.TryGetValue(key, cached) Then
                cached = New Font("Segoe UI", sizePt, st, GraphicsUnit.Point)
                _cacheFuentes(key) = cached
            End If
            ctrl.Font = cached
        End If
    End Sub

    ''' <summary>
    ''' Aplica recursivamente la paleta de colores corporativa con alto contraste a un formulario y todos sus controles.
    ''' </summary>
    Public Shared Sub AplicarTemaModerno(ByVal controlRaiz As Control, Optional ByVal forzar As Boolean = False)
        If controlRaiz Is Nothing OrElse controlRaiz.IsDisposed Then Exit Sub

        If TypeOf controlRaiz Is Form Then
            Dim frm As Form = DirectCast(controlRaiz, Form)
            If Not forzar AndAlso _formulariosConTema.Contains(frm) Then Exit Sub
            _formulariosConTema.Add(frm)
            RemoveHandler frm.FormClosed, AddressOf AlCerrarFormularioTema
            AddHandler frm.FormClosed, AddressOf AlCerrarFormularioTema
            If Not frm.IsMdiContainer Then
                frm.BackColor = ColorFondoForm
            End If
            frm.ForeColor = ColorTextoPrincipal
            UnificarFuenteCorporativa(frm)
            HabilitarDobleBuffer(frm)
        End If

        controlRaiz.SuspendLayout()
        Try
            AplicarTemaControlesHijos(controlRaiz.Controls)
        Finally
            controlRaiz.ResumeLayout(False)
        End Try
    End Sub

    Private Shared Function EsColorRojo(ByVal c As Color) As Boolean
        Return c.R > 150 AndAlso c.G < 90 AndAlso c.B < 90
    End Function

    Private Shared Sub AplicarTemaControlesHijos(ByVal controles As Control.ControlCollection)
        If controles Is Nothing Then Exit Sub

        For Each ctrl As Control In controles
            If TypeOf ctrl Is DataGridView Then
                Dim dgv As DataGridView = DirectCast(ctrl, DataGridView)
                FormatoGrillas.AplicarEstiloModerno(dgv)
                HabilitarAutoAjusteGrilla(dgv)
                Continue For

            ElseIf TypeOf ctrl Is TextBox Then
                Dim txt As TextBox = DirectCast(ctrl, TextBox)
                UnificarFuenteCorporativa(txt)
                txt.ForeColor = ColorTextoPrincipal
                If txt.ReadOnly OrElse _camposSoloLectura.Contains(txt.Name) Then
                    txt.ReadOnly = True
                    txt.Enabled = True
                    txt.TabStop = False
                    txt.BackColor = ColorFondoSoloLectura
                Else
                    txt.BackColor = ColorFondoInput
                End If

            ElseIf TypeOf ctrl Is ComboBox Then
                Dim cmb As ComboBox = DirectCast(ctrl, ComboBox)
                UnificarFuenteCorporativa(cmb)
                cmb.BackColor = ColorFondoInput
                cmb.ForeColor = ColorTextoPrincipal

            ElseIf TypeOf ctrl Is TreeView Then
                Dim tv As TreeView = DirectCast(ctrl, TreeView)
                UnificarFuenteCorporativa(tv)
                ConfigurarTreeViewModerno(tv)

            ElseIf TypeOf ctrl Is MenuStrip Then
                Dim ms As MenuStrip = DirectCast(ctrl, MenuStrip)
                ms.Renderer = _menuRenderer
                ms.BackColor = Color.FromArgb(15, 45, 68)
                ms.ForeColor = Color.White

            ElseIf TypeOf ctrl Is StatusStrip Then
                Dim ss As StatusStrip = DirectCast(ctrl, StatusStrip)
                ss.Renderer = _menuRenderer
                ss.BackColor = ColorPrimario
                ss.ForeColor = Color.White

            ElseIf TypeOf ctrl Is DateTimePicker Then
                Dim dtp As DateTimePicker = DirectCast(ctrl, DateTimePicker)
                UnificarFuenteCorporativa(dtp)
                dtp.CalendarTitleBackColor = ColorPrimario
                dtp.CalendarTitleForeColor = Color.White
                dtp.CalendarForeColor = ColorTextoPrincipal
                dtp.CalendarMonthBackground = Color.White
                dtp.CalendarTrailingForeColor = ColorTextoAtenuado

            ElseIf TypeOf ctrl Is TabPage Then
                Dim tp As TabPage = DirectCast(ctrl, TabPage)
                UnificarFuenteCorporativa(tp)
                tp.UseVisualStyleBackColor = False
                tp.BackColor = ColorFondoPanel
                tp.ForeColor = ColorTextoPrincipal

            ElseIf TypeOf ctrl Is GroupBox Then
                UnificarFuenteCorporativa(ctrl)
                ctrl.ForeColor = ColorPrimario
                ctrl.BackColor = ColorFondoForm
                HabilitarDobleBuffer(ctrl)

            ElseIf TypeOf ctrl Is Panel Then
                UnificarFuenteCorporativa(ctrl)
                ctrl.ForeColor = ColorTextoPrincipal
                If TypeOf ctrl.Parent Is TabPage Then
                    ctrl.BackColor = ColorFondoPanel
                Else
                    ctrl.BackColor = ColorFondoForm
                End If
                HabilitarDobleBuffer(ctrl)

            ElseIf TypeOf ctrl Is Button Then
                Dim btn As Button = DirectCast(ctrl, Button)
                UnificarFuenteCorporativa(btn)
                btn.UseVisualStyleBackColor = False
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderColor = ColorSecundario
                btn.FlatAppearance.BorderSize = 1
                btn.FlatAppearance.MouseOverBackColor = ColorBotonHover
                btn.FlatAppearance.MouseDownBackColor = ColorGrisAzulado
                btn.BackColor = Color.White
                btn.ForeColor = ColorPrimario
                btn.Cursor = Cursors.Hand

            ElseIf TypeOf ctrl Is CheckBox Then
                Dim chk As CheckBox = DirectCast(ctrl, CheckBox)
                UnificarFuenteCorporativa(chk)
                If EsColorRojo(chk.ForeColor) Then
                    chk.ForeColor = ColorTextoDestacado
                Else
                    chk.ForeColor = ColorTextoPrincipal
                End If
                chk.UseVisualStyleBackColor = True
                If Not chk.AutoSize AndAlso chk.Width < chk.PreferredSize.Width Then
                    chk.Width = chk.PreferredSize.Width + 6
                End If
                If chk.BackColor = Color.Transparent Then
                    If chk.Parent IsNot Nothing AndAlso chk.Parent.BackgroundImage IsNot Nothing Then
                        chk.BackColor = Color.Transparent
                    ElseIf chk.Parent IsNot Nothing AndAlso chk.Parent.BackColor <> Color.Transparent Then
                        chk.BackColor = chk.Parent.BackColor
                    Else
                        chk.BackColor = ColorFondoForm
                    End If
                End If

            ElseIf TypeOf ctrl Is RadioButton Then
                Dim rdo As RadioButton = DirectCast(ctrl, RadioButton)
                UnificarFuenteCorporativa(rdo)
                If EsColorRojo(rdo.ForeColor) Then
                    rdo.ForeColor = ColorTextoDestacado
                Else
                    rdo.ForeColor = ColorTextoPrincipal
                End If
                rdo.UseVisualStyleBackColor = True
                If Not rdo.AutoSize AndAlso rdo.Width < rdo.PreferredSize.Width Then
                    rdo.Width = rdo.PreferredSize.Width + 6
                End If
                If rdo.BackColor = Color.Transparent Then
                    If rdo.Parent IsNot Nothing AndAlso rdo.Parent.BackgroundImage IsNot Nothing Then
                        rdo.BackColor = Color.Transparent
                    ElseIf rdo.Parent IsNot Nothing AndAlso rdo.Parent.BackColor <> Color.Transparent Then
                        rdo.BackColor = rdo.Parent.BackColor
                    Else
                        rdo.BackColor = ColorFondoForm
                    End If
                End If

            ElseIf TypeOf ctrl Is Label Then
                UnificarFuenteCorporativa(ctrl)
                If EsColorRojo(ctrl.ForeColor) Then
                    ctrl.ForeColor = ColorTextoDestacado
                Else
                    ctrl.ForeColor = ColorTextoPrincipal
                End If
                If ctrl.BackColor = Color.Transparent Then
                    If ctrl.Parent IsNot Nothing AndAlso ctrl.Parent.BackgroundImage IsNot Nothing Then
                        ctrl.BackColor = Color.Transparent
                    ElseIf ctrl.Parent IsNot Nothing AndAlso ctrl.Parent.BackColor <> Color.Transparent Then
                        ctrl.BackColor = ctrl.Parent.BackColor
                    Else
                        ctrl.BackColor = ColorFondoForm
                    End If
                End If

            ElseIf TypeOf ctrl Is ToolStrip Then
                Dim ts As ToolStrip = DirectCast(ctrl, ToolStrip)
                ts.Renderer = _menuRenderer
                ts.BackColor = ColorPrimario
                ts.ForeColor = Color.White
            End If

            If ctrl.HasChildren AndAlso Not TypeOf ctrl Is NumericUpDown AndAlso Not TypeOf ctrl Is UserControl Then
                AplicarTemaControlesHijos(ctrl.Controls)
            End If
        Next
    End Sub

    ' ==========================================================================================
    '  AUTOAJUSTE DE FORMULARIOS Y DOBLE BUFFER
    ' ==========================================================================================
    ''' <summary>
    ''' Habilita doble buffer y optimización de renderizado en el formulario para maximizaciones y transiciones fluidas.
    ''' </summary>
    Public Shared Sub HabilitarAutoAjuste(ByVal frm As Form)
        If frm Is Nothing OrElse frm.IsDisposed OrElse frm.IsMdiContainer Then Exit Sub
        HabilitarDobleBuffer(frm)
    End Sub

    ' ==========================================================================================
    '  AUTOAJUSTE DE COLUMNAS DE GRILLAS (al cargar datos y al redimensionar)
    ' ==========================================================================================
    Private Shared ReadOnly _grillasPendientes As New HashSet(Of DataGridView)()

    Private Shared Function GrillaExcluidaAutoAjuste(ByVal g As DataGridView) As Boolean
        Dim n As String = If(g.Name, "")
        Return n.IndexOf("Gantt", StringComparison.OrdinalIgnoreCase) >= 0 OrElse n.IndexOf("Calendario", StringComparison.OrdinalIgnoreCase) >= 0
    End Function

    Public Shared Sub HabilitarAutoAjusteGrilla(ByVal g As DataGridView)
        If g Is Nothing OrElse GrillaExcluidaAutoAjuste(g) Then Exit Sub
        RemoveHandler g.DataBindingComplete, AddressOf AlCambiarGrilla
        RemoveHandler g.Resize, AddressOf AlCambiarGrilla
        RemoveHandler g.RowsAdded, AddressOf AlCambiarGrilla
        RemoveHandler g.ColumnAdded, AddressOf AlCambiarGrilla
        AddHandler g.DataBindingComplete, AddressOf AlCambiarGrilla
        AddHandler g.Resize, AddressOf AlCambiarGrilla
        AddHandler g.RowsAdded, AddressOf AlCambiarGrilla
        AddHandler g.ColumnAdded, AddressOf AlCambiarGrilla
        ProgramarAjusteGrilla(g)
    End Sub

    Private Shared Sub AlCambiarGrilla(ByVal sender As Object, ByVal e As EventArgs)
        ProgramarAjusteGrilla(TryCast(sender, DataGridView))
    End Sub

    Private Shared Sub ProgramarAjusteGrilla(ByVal g As DataGridView)
        If g Is Nothing OrElse g.IsDisposed OrElse Not g.IsHandleCreated Then
            If g IsNot Nothing AndAlso Not g.IsDisposed AndAlso Not g.IsHandleCreated Then
                RemoveHandler g.HandleCreated, AddressOf AlCambiarGrilla
                AddHandler g.HandleCreated, AddressOf AlCambiarGrilla
            End If
            Exit Sub
        End If
        If Not _grillasPendientes.Add(g) Then Exit Sub
        Try
            g.BeginInvoke(New Action(Sub()
                                         _grillasPendientes.Remove(g)
                                         AjustarColumnasGrilla(g)
                                     End Sub))
        Catch
            _grillasPendientes.Remove(g)
        End Try
    End Sub

    ''' <summary>
    ''' Ajusta el ancho de las columnas al contenido visible y reparte el espacio sobrante para ocupar todo el ancho de la grilla.
    ''' </summary>
    Public Shared Sub AjustarColumnasGrilla(ByVal g As DataGridView)
        If g Is Nothing OrElse g.IsDisposed OrElse g.Columns.Count = 0 OrElse g.ClientSize.Width <= 0 Then Exit Sub
        If GrillaExcluidaAutoAjuste(g) Then Exit Sub
        If g.IsCurrentCellInEditMode Then Exit Sub

        Try
            If g.AutoSizeColumnsMode <> DataGridViewAutoSizeColumnsMode.None Then
                g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            End If

            Dim visibles As New List(Of DataGridViewColumn)()
            For Each col As DataGridViewColumn In g.Columns
                If col.Visible Then
                    If col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                    End If
                    visibles.Add(col)
                End If
            Next
            If visibles.Count = 0 Then Exit Sub

            ' Ajuste al contenido visible (rápido aun con muchas filas)
            For Each col As DataGridViewColumn In visibles
                If col.Tag?.ToString() = "Fijo" AndAlso col.Width > 0 Then
                    ' Mantiene el ancho fijo configurado explícitamente
                    Continue For
                End If
                Dim preferido As Integer = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, True)
                Dim encabezado As Integer = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, True)
                col.Width = Math.Max(40, Math.Min(380, Math.Max(preferido, encabezado)))
            Next

            Dim total As Integer = 0
            For Each col As DataGridViewColumn In visibles
                total += col.Width
            Next

            Dim disponible As Integer = g.ClientSize.Width - 3
            If g.RowHeadersVisible Then disponible -= g.RowHeadersWidth
            For Each c As Control In g.Controls
                If TypeOf c Is VScrollBar AndAlso c.Visible Then disponible -= c.Width
            Next

            If total < disponible Then
                Dim extra As Integer = disponible - total

                ' Identificar columnas elásticas que deben absorber el espacio adicional
                Dim elasticas As New List(Of DataGridViewColumn)()
                Dim totalElasticas As Integer = 0
                For Each col As DataGridViewColumn In visibles
                    Dim esFija As Boolean = (col.Tag?.ToString() = "Fijo") OrElse
                                            TypeOf col Is DataGridViewCheckBoxColumn OrElse
                                            col.ValueType Is GetType(Boolean) OrElse
                                            col.HeaderText.Equals("ESTADO", StringComparison.OrdinalIgnoreCase) OrElse
                                            col.HeaderText.Equals("Activo", StringComparison.OrdinalIgnoreCase) OrElse
                                            col.HeaderText.Equals("ID", StringComparison.OrdinalIgnoreCase) OrElse
                                            col.HeaderText.Equals("N°", StringComparison.OrdinalIgnoreCase)
                    If Not esFija Then
                        elasticas.Add(col)
                        totalElasticas += col.Width
                    End If
                Next

                Dim destinos As List(Of DataGridViewColumn) = If(elasticas.Count > 0, elasticas, visibles)
                Dim baseTotal As Integer = If(elasticas.Count > 0, totalElasticas, total)
                If baseTotal <= 0 Then baseTotal = 1

                Dim asignado As Integer = 0
                For i As Integer = 0 To destinos.Count - 1
                    Dim incremento As Integer
                    If i = destinos.Count - 1 Then
                        incremento = extra - asignado
                    Else
                        incremento = CInt(Math.Floor(extra * (destinos(i).Width / CDbl(baseTotal))))
                    End If
                    destinos(i).Width += incremento
                    asignado += incremento
                Next
            End If
        Catch
        End Try
    End Sub

    <DllImport("kernel32.dll", EntryPoint:="SetProcessWorkingSetSize", ExactSpelling:=True, CharSet:=CharSet.Ansi, SetLastError:=True)>
    Private Shared Function SetProcessWorkingSetSize(ByVal hProcess As IntPtr, ByVal dwMinimumWorkingSetSize As Integer, ByVal dwMaximumWorkingSetSize As Integer) As Integer
    End Function

    ''' <summary>
    ''' Asigna de forma segura un valor proveniente de base de datos a un DateTimePicker de Windows Forms,
    ''' evitando excepciones NullReferenceException o InvalidCastException cuando el campo es DBNull o cadena vacía.
    ''' </summary>
    Public Shared Sub AsignarFechaSegura(ByVal dtp As DateTimePicker, ByVal valor As Object, Optional ByVal fechaFallback As DateTime? = Nothing)
        Try
            If valor Is Nothing OrElse IsDBNull(valor) Then
                If fechaFallback.HasValue Then dtp.Value = fechaFallback.Value
                Exit Sub
            End If
            Dim strVal As String = valor.ToString().Trim()
            If String.IsNullOrEmpty(strVal) Then
                If fechaFallback.HasValue Then dtp.Value = fechaFallback.Value
                Exit Sub
            End If
            Dim d As DateTime
            If DateTime.TryParse(strVal, d) Then
                dtp.Value = d
            ElseIf fechaFallback.HasValue Then
                dtp.Value = fechaFallback.Value
            End If
        Catch
            If fechaFallback.HasValue Then
                Try
                    dtp.Value = fechaFallback.Value
                Catch
                End Try
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Fuerza la recolección de basura del Garbage Collector y reduce el conjunto de trabajo (Working Set)
    ''' del proceso en memoria RAM al mínimo indispensable. Ideal al cerrar formularios, cambiar de ambiente o tras exportaciones grandes.
    ''' </summary>
    Public Shared Sub OptimizarMemoria()
        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            If Environment.OSVersion.Platform = PlatformID.Win32NT Then
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
            End If
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' Libera de forma segura un objeto COM de Excel para evitar procesos huérfanos EXCEL.EXE en segundo plano.
    ''' </summary>
    Public Shared Sub LiberarObjetoCom(ByVal obj As Object)
        Try
            If obj IsNot Nothing AndAlso Marshal.IsComObject(obj) Then
                Marshal.FinalReleaseComObject(obj)
            End If
        Catch
        Finally
            obj = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' Cierra y libera de manera segura una aplicación de Excel en caso de error para no saturar memoria RAM.
    ''' </summary>
    Public Shared Sub CerrarExcelEnError(ByRef excelApp As Excel.Application, Optional ByRef workbook As Excel.Workbook = Nothing)
        Try
            If workbook IsNot Nothing Then
                Try
                    workbook.Close(False)
                Catch
                End Try
                LiberarObjetoCom(workbook)
                workbook = Nothing
            End If
            If excelApp IsNot Nothing Then
                Try
                    excelApp.ScreenUpdating = True
                    excelApp.DisplayAlerts = False
                    excelApp.Quit()
                Catch
                End Try
                LiberarObjetoCom(excelApp)
                excelApp = Nothing
            End If
            OptimizarMemoria()
        Catch
        End Try
    End Sub
End Class
