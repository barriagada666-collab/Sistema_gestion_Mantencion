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

    ' Paleta corporativa unificada con los mockups oficiales:
    ' #0F2D44 · #025E87 · #0191B3 · #66C9D3 · #A0C5CF · #DDE7E8 · #E5EBEB · #F2F6F6
    Public Shared ReadOnly ColorDeepNavy As Color = Color.FromArgb(15, 45, 68)             ' Azul marino profundo (#0F2D44) - barra superior y títulos
    Public Shared ReadOnly ColorPrimario As Color = Color.FromArgb(2, 94, 135)            ' Azul petróleo (#025E87) - botones primarios, encabezados, estado
    Public Shared ReadOnly ColorSecundario As Color = Color.FromArgb(1, 145, 179)         ' Azul cian (#0191B3) - acentos, bordes y hover primario
    Public Shared ReadOnly ColorAcento As Color = Color.FromArgb(102, 201, 211)           ' Turquesa (#66C9D3) - destacados en barra oscura
    Public Shared ReadOnly ColorGrisAzulado As Color = Color.FromArgb(160, 197, 207)      ' Gris azulado (#A0C5CF)
    Public Shared ReadOnly ColorMdiFondo As Color = Color.FromArgb(221, 231, 232)         ' Fondo limpio del escritorio MDI (#DDE7E8)
    Public Shared ReadOnly ColorFondoForm As Color = Color.FromArgb(229, 235, 235)        ' Gris niebla (#E5EBEB) - fondo formularios y GroupBox
    Public Shared ReadOnly ColorFondoPanel As Color = Color.FromArgb(242, 246, 246)       ' Superficie clara para pestañas y tarjetas (#F2F6F6)
    Public Shared ReadOnly ColorFondoInput As Color = Color.White                         ' Campos editables (#FFFFFF)
    Public Shared ReadOnly ColorFondoFoco As Color = Color.FromArgb(224, 244, 246)        ' Tinte turquesa al enfocar (#E0F4F6)
    Public Shared ReadOnly ColorFondoSoloLectura As Color = Color.FromArgb(215, 230, 234) ' Tinte gris azulado solo lectura (#D7E6EA)
    Public Shared ReadOnly ColorTextoPrincipal As Color = Color.FromArgb(15, 23, 42)      ' Texto principal alto contraste (#0F172A)
    Public Shared ReadOnly ColorTextoDestacado As Color = Color.FromArgb(185, 28, 28)     ' Rojo legible para alertas y eliminar (#B91C1C)
    Public Shared ReadOnly ColorFilaAlterna As Color = Color.FromArgb(234, 243, 245)      ' Zebra suave (#EAF3F5)
    Public Shared ReadOnly ColorSeleccion As Color = Color.FromArgb(160, 197, 207)        ' Selección (#A0C5CF)
    Public Shared ReadOnly ColorTextoSeleccion As Color = Color.FromArgb(15, 23, 42)      ' Texto sobre selección (#0F172A)
    Public Shared ReadOnly ColorNodoActivo As Color = Color.FromArgb(179, 228, 233)       ' Tinte turquesa para nodo activo (#B3E4E9)
    Public Shared ReadOnly ColorBotonHover As Color = Color.FromArgb(217, 241, 244)       ' Hover de botones secundarios (#D9F1F4)
    Public Shared ReadOnly ColorBotonSecundarioBorde As Color = Color.FromArgb(148, 184, 196) ' Borde sutil secundario (#94B8C4)
    Public Shared ReadOnly ColorBotonEliminarFondo As Color = Color.FromArgb(255, 241, 242)   ' Fondo suave destructivo (#FFF1F2)
    Public Shared ReadOnly ColorBotonEliminarBorde As Color = Color.FromArgb(244, 63, 94)    ' Borde destructivo (#F43F5E)
    Public Shared ReadOnly ColorBotonEliminarHover As Color = Color.FromArgb(255, 228, 230)   ' Hover destructivo (#FFE4E6)

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
        Dim asmLoc As String = GetType(Utilitarios).Assembly.Location
        Dim asmDir As String = If(String.IsNullOrEmpty(asmLoc), AppContext.BaseDirectory, Path.GetDirectoryName(asmLoc))
        Dim baseDir As String = AppDomain.CurrentDomain.BaseDirectory
        Dim appDir As String = Application.StartupPath
        Dim curDir As String = Environment.CurrentDirectory

        Dim candidatos As String() = {
            Path.Combine(asmDir, "plantillas", soloNombre),
            Path.Combine(baseDir, "plantillas", soloNombre),
            Path.Combine(appDir, "plantillas", soloNombre),
            Path.Combine(curDir, "plantillas", soloNombre),
            Path.Combine(curDir, "mantencion", "plantillas", soloNombre),
            Path.Combine(asmDir, soloNombre),
            Path.Combine(baseDir, soloNombre),
            Path.Combine(appDir, soloNombre),
            Path.Combine(asmDir, "..\..\plantillas", soloNombre),
            Path.Combine(baseDir, "..\..\plantillas", soloNombre)
        }

        For Each ruta In candidatos
            If Not String.IsNullOrEmpty(ruta) AndAlso File.Exists(ruta) Then Return Path.GetFullPath(ruta)
        Next

        ' Respaldo insensible a mayúsculas/minúsculas en búsqueda de plantillas locales
        Dim carpetas As String() = {
            Path.Combine(asmDir, "plantillas"),
            Path.Combine(baseDir, "plantillas"),
            Path.Combine(appDir, "plantillas"),
            Path.Combine(curDir, "plantillas"),
            Path.Combine(curDir, "mantencion", "plantillas"),
            asmDir,
            baseDir,
            appDir
        }
        For Each carpeta In carpetas
            Try
                If Not String.IsNullOrEmpty(carpeta) AndAlso Directory.Exists(carpeta) Then
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
    ''' Inicializa un par de DateTimePicker al rango por defecto del sistema: ayer (hoy - 1 día) hasta hoy.
    ''' </summary>
    Public Shared Sub InicializarRangoPorDefecto(ByVal dtpDesde As DateTimePicker, ByVal dtpHasta As DateTimePicker)
        Dim hoy As DateTime = DateTime.Today
        Dim ayer As DateTime = hoy.AddDays(-1)
        If dtpHasta IsNot Nothing Then
            Dim fFin As DateTime = hoy
            If fFin < dtpHasta.MinDate Then fFin = dtpHasta.MinDate
            If fFin > dtpHasta.MaxDate Then fFin = dtpHasta.MaxDate
            dtpHasta.Value = fFin
        End If
        If dtpDesde IsNot Nothing Then
            Dim fIni As DateTime = ayer
            If fIni < dtpDesde.MinDate Then fIni = dtpDesde.MinDate
            If fIni > dtpDesde.MaxDate Then fIni = dtpDesde.MaxDate
            dtpDesde.Value = fIni
        End If
    End Sub

    ''' <summary>
    ''' Alias compatible que inicializa un par de DateTimePicker en [Hoy - 1 día .. Hoy].
    ''' </summary>
    Public Shared Sub InicializarRangoMesActual(ByVal dtpDesde As DateTimePicker, ByVal dtpHasta As DateTimePicker)
        InicializarRangoPorDefecto(dtpDesde, dtpHasta)
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
    ''' Convierte un libro abierto desde plantilla .xls a un libro .xlsx en memoria para superar el límite de 256 columnas (p. ej. Carta Gantt extensa).
    ''' </summary>
    Public Shared Function ConvertirLibroAXlsxTempParaAmpliarColumnas(ByVal excelApp As Excel.Application, ByVal workbook As Excel.Workbook) As Excel.Workbook
        If excelApp Is Nothing OrElse workbook Is Nothing Then Return workbook
        Dim tmpXlsx As String = Path.Combine(Path.GetTempPath(), "sardu_gantt_" & Guid.NewGuid().ToString("N") & ".xlsx")
        Try
            If Not workbook.Excel8CompatibilityMode Then Return workbook
            workbook.SaveAs(Filename:=tmpXlsx, FileFormat:=Excel.XlFileFormat.xlOpenXMLWorkbook)
            workbook.Close(SaveChanges:=False)
            Runtime.InteropServices.Marshal.ReleaseComObject(workbook)
            Dim wbNuevo As Excel.Workbook = excelApp.Workbooks.Add(tmpXlsx)
            Try
                If File.Exists(tmpXlsx) Then File.Delete(tmpXlsx)
            Catch
            End Try
            Return wbNuevo
        Catch
            Try
                If File.Exists(tmpXlsx) Then File.Delete(tmpXlsx)
            Catch
            End Try
            Return workbook
        End Try
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
    Public Shared Sub ImprimirLibroAPdfWindows(ByVal excelApp As Excel.Application, ByVal workbook As Excel.Workbook, Optional ByVal rutaArchivoDestino As String = "", Optional ByVal prefijoNombre As String = "Informe_Mantencion", Optional ByVal respetarFitExistente As Boolean = False, Optional ByVal silencioso As Boolean = False)
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

        ConfigurarImpresionHorizontalAjustada(workbook, respetarFitExistente)

        ' 1. Exportación directa nativa a PDF de alta velocidad (Excel.XlFixedFormatType.xlTypePDF)
        Try
            workbook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, rutaPdf, Excel.XlFixedFormatQuality.xlQualityStandard, True, False, Type.Missing, Type.Missing, False)
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
                RegistroErrores.RegistrarError(ex, "Imprimir Libro a PDF Windows")
            End Try
        End If

        If Not exportadoOk Then
            MessageBox.Show("No fue posible generar el archivo PDF mediante Excel ni la impresora de sistema." & Environment.NewLine & "Compruebe que el destino sea escribible o use la exportación directa a PDF.", "Exportar a PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If exportadoOk AndAlso File.Exists(rutaPdf) Then
            If Not silencioso AndAlso MessageBox.Show("Archivo PDF guardado exitosamente en:" & Environment.NewLine & rutaPdf & Environment.NewLine & Environment.NewLine & "¿Desea abrir el documento PDF ahora?", "Exportación PDF Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
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
    ''' Fuerza orientación horizontal y ajuste automático al 100% del ancho de página (1 página de ancho x N páginas de alto)
    ''' en todas las hojas visibles de un libro Excel para evitar cortes horizontales al exportar PDF con muchos registros.
    ''' </summary>
    Public Shared Sub ConfigurarImpresionHorizontalAjustada(ByVal workbook As Excel.Workbook, Optional ByVal respetarFitExistente As Boolean = False)
        If workbook Is Nothing Then Exit Sub
        Dim excelApp As Excel.Application = Nothing
        Try
            excelApp = TryCast(workbook.Application, Excel.Application)
            If excelApp IsNot Nothing Then
                Try
                    excelApp.PrintCommunication = False
                Catch
                End Try
            End If
            For Each sh As Object In workbook.Worksheets
                Dim ws As Excel.Worksheet = TryCast(sh, Excel.Worksheet)
                If ws Is Nothing Then Continue For
                Try
                    If ws.Visible = Excel.XlSheetVisibility.xlSheetVisible Then
                        Dim ps As Excel.PageSetup = ws.PageSetup
                        ps.Orientation = Excel.XlPageOrientation.xlLandscape
                        ps.PaperSize = Excel.XlPaperSize.xlPaperLetter
                        If Not respetarFitExistente Then
                            ps.Zoom = False
                            ps.FitToPagesWide = 1
                            ps.FitToPagesTall = False
                        End If
                        ps.CenterHorizontally = True
                        ps.LeftMargin = 14
                        ps.RightMargin = 14
                        ps.TopMargin = 20
                        ps.BottomMargin = 20
                        ps.HeaderMargin = 10
                        ps.FooterMargin = 10
                    End If
                Catch
                End Try
            Next
        Catch
        Finally
            If excelApp IsNot Nothing Then
                Try
                    excelApp.PrintCommunication = True
                Catch
                End Try
            End If
        End Try
    End Sub

    Private Shared Function CalcularPesosColumnasPdf(ByVal colsVis As List(Of DataGridViewColumn), ByVal grilla As DataGridView) As Single()
        Dim n As Integer = colsVis.Count
        Dim pesos(n - 1) As Single
        Dim muestraMax As Integer = Math.Min(grilla.RowCount - 1, 80)

        For c As Integer = 0 To n - 1
            Dim col As DataGridViewColumn = colsVis(c)
            Dim headerLen As Integer = If(col.HeaderText, "").Trim().Length
            Dim maxDataLen As Integer = headerLen
            For r As Integer = 0 To muestraMax
                If grilla.Rows(r).IsNewRow Then Continue For
                Dim v As Object = grilla.Rows(r).Cells(col.Index).Value
                If v IsNot Nothing AndAlso Not IsDBNull(v) Then
                    Dim l As Integer = v.ToString().Trim().Length
                    If l > maxDataLen Then maxDataLen = l
                End If
            Next

            Dim anchoBase As Single = Math.Max(32.0F, Math.Min(260.0F, CSng(col.Width)))
            Dim pesoContenido As Single = Math.Max(6.0F, Math.Min(42.0F, headerLen * 1.1F + Math.Min(maxDataLen, 45) * 0.65F))
            pesos(c) = Math.Max(22.0F, Math.Min(220.0F, (anchoBase * 0.55F) + (pesoContenido * 2.2F)))
        Next
        Return pesos
    End Function

    ''' <summary>
    ''' Exporta el contenido visible de un DataGridView directamente a un archivo PDF utilizando iTextSharp.
    ''' Solución 100% nativa con ajuste completo a ancho horizontal en hoja Carta/Letter Landscape.
    ''' </summary>
    Private Shared Function ObtenerColumnasVisiblesOrdenadas(ByVal grilla As DataGridView) As List(Of DataGridViewColumn)
        Dim colsVis As New List(Of DataGridViewColumn)()
        If grilla Is Nothing Then Return colsVis
        For Each col As DataGridViewColumn In grilla.Columns
            If col.Visible AndAlso Not String.Equals(col.Name, "colSelGantt", StringComparison.OrdinalIgnoreCase) Then colsVis.Add(col)
        Next
        colsVis.Sort(Function(a, b) a.DisplayIndex.CompareTo(b.DisplayIndex))
        Return colsVis
    End Function

    ''' <summary>
    ''' Exporta cualquier DataGridView directamente a un archivo PDF corporativo usando iTextSharp, sin dependencias externas.
    ''' </summary>
    Public Shared Function ExportarGrillaAPdf(ByVal grilla As DataGridView, ByVal rutaArchivo As String, ByVal titulo As String, Optional ByVal subtitulo As String = "") As Boolean
        If grilla Is Nothing OrElse grilla.Columns.Count = 0 OrElse String.IsNullOrEmpty(rutaArchivo) Then Return False

        Dim columnasVisibles As List(Of DataGridViewColumn) = ObtenerColumnasVisiblesOrdenadas(grilla)
        If columnasVisibles.Count = 0 Then Return False

        Try
            If File.Exists(rutaArchivo) Then
                Try
                    File.Delete(rutaArchivo)
                Catch
                    Return False
                End Try
            End If

            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER.Rotate(), 14.0F, 14.0F, 20.0F, 20.0F)
            Using fs As New FileStream(rutaArchivo, FileMode.Create, FileAccess.Write, FileShare.None)
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs)
                doc.Open()
                Try
                    Dim colCount As Integer = columnasVisibles.Count
                    Dim tamHeader As Single = If(colCount >= 13, 6.2F, If(colCount >= 9, 6.8F, 7.4F))
                    Dim tamCell As Single = If(colCount >= 13, 5.8F, If(colCount >= 9, 6.4F, 6.9F))
                    Dim cDeep As New iTextSharp.text.BaseColor(ColorDeepNavy.R, ColorDeepNavy.G, ColorDeepNavy.B)
                    Dim cSec As New iTextSharp.text.BaseColor(ColorSecundario.R, ColorSecundario.G, ColorSecundario.B)
                    Dim cText As New iTextSharp.text.BaseColor(ColorTextoPrincipal.R, ColorTextoPrincipal.G, ColorTextoPrincipal.B)
                    Dim cBorder As New iTextSharp.text.BaseColor(ColorBordeGrilla.R, ColorBordeGrilla.G, ColorBordeGrilla.B)

                    Dim fontTitulo As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 12.5F, cDeep)
                    Dim fontSub As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 8.2F, cSec)
                    Dim fontHeader As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, tamHeader, iTextSharp.text.BaseColor.White)
                    Dim fontCell As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, tamCell, cText)

                    Dim pTitulo As New iTextSharp.text.Paragraph(titulo, fontTitulo)
                    pTitulo.SpacingAfter = 2.5F
                    doc.Add(pTitulo)

                    Dim meta As String = "Generado el: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                    If Not String.IsNullOrEmpty(subtitulo) Then meta &= "   |   " & subtitulo
                    Dim pMeta As New iTextSharp.text.Paragraph(meta, fontSub)
                    pMeta.SpacingAfter = 8.0F
                    doc.Add(pMeta)

                    Dim tabla As New iTextSharp.text.pdf.PdfPTable(colCount)
                    tabla.WidthPercentage = 100.0F
                    tabla.HeaderRows = 1
                    tabla.SplitLate = False
                    tabla.SplitRows = True
                    tabla.SetWidths(CalcularPesosColumnasPdf(columnasVisibles, grilla))

                    Dim bgHeader As New iTextSharp.text.BaseColor(ColorPrimario.R, ColorPrimario.G, ColorPrimario.B)
                    Dim bgRowAlt As New iTextSharp.text.BaseColor(ColorFilaAlterna.R, ColorFilaAlterna.G, ColorFilaAlterna.B)

                    For Each col As DataGridViewColumn In columnasVisibles
                        Dim celdaEncabezado As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(col.HeaderText, fontHeader))
                        celdaEncabezado.BackgroundColor = bgHeader
                        celdaEncabezado.BorderColor = cDeep
                        celdaEncabezado.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                        celdaEncabezado.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                        celdaEncabezado.Padding = If(colCount >= 13, 2.8F, 3.6F)
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
                            celdaDato.BorderColor = cBorder
                            celdaDato.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
                            celdaDato.Padding = If(colCount >= 13, 2.2F, 2.8F)
                            tabla.AddCell(celdaDato)
                        Next
                        rowIndex += 1
                    Next

                    doc.Add(tabla)

                    Dim pTotal As New iTextSharp.text.Paragraph("Total de registros: " & rowIndex.ToString(), fontSub)
                    pTotal.Alignment = iTextSharp.text.Element.ALIGN_RIGHT
                    pTotal.SpacingBefore = 6.0F
                    doc.Add(pTotal)
                Finally
                    If doc.IsOpen() Then doc.Close()
                End Try
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

            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER.Rotate(), 14.0F, 14.0F, 20.0F, 20.0F)
            Dim tablasAgregadas As Integer = 0

            Using fs As New FileStream(rutaArchivo, FileMode.Create, FileAccess.Write, FileShare.None)
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs)
                doc.Open()
                Try
                    Dim cDeep As New iTextSharp.text.BaseColor(ColorDeepNavy.R, ColorDeepNavy.G, ColorDeepNavy.B)
                    Dim cSec As New iTextSharp.text.BaseColor(ColorSecundario.R, ColorSecundario.G, ColorSecundario.B)
                    Dim cText As New iTextSharp.text.BaseColor(ColorTextoPrincipal.R, ColorTextoPrincipal.G, ColorTextoPrincipal.B)
                    Dim cBorder As New iTextSharp.text.BaseColor(ColorBordeGrilla.R, ColorBordeGrilla.G, ColorBordeGrilla.B)

                    Dim fontTitulo As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 12.5F, cDeep)
                    Dim fontSub As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 8.2F, cSec)
                    Dim fontSeccion As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 9.5F, cSec)

                    Dim pTitulo As New iTextSharp.text.Paragraph(titulo, fontTitulo)
                    pTitulo.SpacingAfter = 2.5F
                    doc.Add(pTitulo)

                    Dim meta As String = "Generado el: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                    If Not String.IsNullOrEmpty(subtituloGeneral) Then meta &= "   |   " & subtituloGeneral
                    Dim pMeta As New iTextSharp.text.Paragraph(meta, fontSub)
                    pMeta.SpacingAfter = 6.0F
                    doc.Add(pMeta)

                    Dim bgHeader As New iTextSharp.text.BaseColor(ColorPrimario.R, ColorPrimario.G, ColorPrimario.B)
                    Dim bgRowAlt As New iTextSharp.text.BaseColor(ColorFilaAlterna.R, ColorFilaAlterna.G, ColorFilaAlterna.B)

                    For Each sec As KeyValuePair(Of String, DataGridView) In secciones
                        Dim grilla As DataGridView = sec.Value
                        If grilla Is Nothing OrElse grilla.Columns.Count = 0 Then Continue For

                        Dim colsVis As List(Of DataGridViewColumn) = ObtenerColumnasVisiblesOrdenadas(grilla)
                        If colsVis.Count = 0 Then Continue For

                        Dim colCount As Integer = colsVis.Count
                        Dim tamHeader As Single = If(colCount >= 13, 6.2F, If(colCount >= 9, 6.8F, 7.2F))
                        Dim tamCell As Single = If(colCount >= 13, 5.8F, If(colCount >= 9, 6.4F, 6.8F))
                        Dim fontHeader As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, tamHeader, iTextSharp.text.BaseColor.White)
                        Dim fontCell As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, tamCell, cText)

                        If Not String.IsNullOrWhiteSpace(sec.Key) Then
                            Dim pSec As New iTextSharp.text.Paragraph(sec.Key, fontSeccion)
                            pSec.SpacingBefore = 7.0F
                            pSec.SpacingAfter = 3.5F
                            doc.Add(pSec)
                        End If

                        Dim tabla As New iTextSharp.text.pdf.PdfPTable(colCount)
                        tabla.WidthPercentage = 100.0F
                        tabla.HeaderRows = 1
                        tabla.SplitLate = False
                        tabla.SplitRows = True
                        tabla.SpacingAfter = 6.0F
                        tabla.SetWidths(CalcularPesosColumnasPdf(colsVis, grilla))

                        For Each col As DataGridViewColumn In colsVis
                            Dim celdaEnc As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(col.HeaderText, fontHeader))
                            celdaEnc.BackgroundColor = bgHeader
                            celdaEnc.BorderColor = cDeep
                            celdaEnc.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            celdaEnc.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                            celdaEnc.Padding = If(colCount >= 13, 2.8F, 3.4F)
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
                                celdaDato.BorderColor = cBorder
                                celdaDato.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
                                celdaDato.Padding = If(colCount >= 13, 2.2F, 2.8F)
                                tabla.AddCell(celdaDato)
                            Next
                            rowCount += 1
                        Next

                        doc.Add(tabla)
                        tablasAgregadas += 1
                    Next
                Finally
                    If doc.IsOpen() Then doc.Close()
                End Try
            End Using

            Return tablasAgregadas > 0 AndAlso File.Exists(rutaArchivo)
        Catch ex As Exception
            RegistroErrores.RegistrarError(ex, "Exportar Grillas a PDF Nativo")
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
    ''' cuando Microsoft Excel no está instalado en el equipo Windows.
    ''' </summary>
    Public Shared UltimaExportacionCancelada As Boolean = False

    Public Shared Function ExportarGrillasAExcelNativo(ByVal hojas As IEnumerable(Of KeyValuePair(Of String, DataGridView)), ByVal prefijoNombre As String, ByVal tituloInforme As String, Optional ByVal subtitulo As String = "") As Boolean
        UltimaExportacionCancelada = False
        If hojas Is Nothing Then Return False
        Dim ruta As String = SolicitarRutaGuardadoExcel(prefijoNombre)
        If String.IsNullOrEmpty(ruta) Then
            UltimaExportacionCancelada = True
            Return False
        End If

        Try
            Dim sb As New System.Text.StringBuilder(8192)
            sb.AppendLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            sb.AppendLine("<?mso-application progid=""Excel.Sheet""?>")
            sb.AppendLine("<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:x=""urn:schemas-microsoft-com:office:excel"">")
            sb.AppendLine(" <Styles>")
            sb.AppendLine("  <Style ss:ID=""Titulo""><Font ss:FontName=""Segoe UI"" ss:Size=""13"" ss:Bold=""1"" ss:Color=""#0F2D44""/></Style>")
            sb.AppendLine("  <Style ss:ID=""Subtitulo""><Font ss:FontName=""Segoe UI"" ss:Size=""9"" ss:Italic=""1"" ss:Color=""#475569""/></Style>")
            sb.AppendLine("  <Style ss:ID=""Header""><Font ss:FontName=""Segoe UI"" ss:Size=""9"" ss:Bold=""1"" ss:Color=""#FFFFFF""/><Interior ss:Color=""#025E87"" ss:Pattern=""Solid""/><Alignment ss:Horizontal=""Center"" ss:Vertical=""Center"" ss:WrapText=""1""/></Style>")
            sb.AppendLine("  <Style ss:ID=""Cell""><Font ss:FontName=""Segoe UI"" ss:Size=""9"" ss:Color=""#0F172A""/><Alignment ss:Vertical=""Top"" ss:WrapText=""1""/><Borders><Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#C8DEDF""/></Borders></Style>")
            sb.AppendLine("  <Style ss:ID=""CellAlt""><Font ss:FontName=""Segoe UI"" ss:Size=""9"" ss:Color=""#0F172A""/><Interior ss:Color=""#EAF3F5"" ss:Pattern=""Solid""/><Alignment ss:Vertical=""Top"" ss:WrapText=""1""/><Borders><Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#C8DEDF""/></Borders></Style>")
            sb.AppendLine(" </Styles>")

            Dim idxHoja As Integer = 1
            Dim usados As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
            For Each hoja In hojas
                Dim g As DataGridView = hoja.Value
                If g Is Nothing OrElse g.Columns.Count = 0 Then Continue For

                Dim colsVis As List(Of DataGridViewColumn) = ObtenerColumnasVisiblesOrdenadas(g)
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
                sb.AppendLine("  <WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">")
                sb.AppendLine("   <PageSetup>")
                sb.AppendLine("    <Layout x:Orientation=""Landscape""/>")
                sb.AppendLine("    <PageMargins x:Bottom=""0.4"" x:Left=""0.25"" x:Right=""0.25"" x:Top=""0.4""/>")
                sb.AppendLine("   </PageSetup>")
                sb.AppendLine("   <FitToPage/>")
                sb.AppendLine("   <Print>")
                sb.AppendLine("    <ValidPrinterInfo/>")
                sb.AppendLine("    <FitWidth>1</FitWidth>")
                sb.AppendLine("    <FitHeight>0</FitHeight>")
                sb.AppendLine("   </Print>")
                sb.AppendLine("  </WorksheetOptions>")
                sb.AppendLine(" </Worksheet>")
                idxHoja += 1
            Next

            If idxHoja = 1 Then
                Return False
            End If

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

    Public Shared Function ExcelCelda(ByVal ws As Excel.Worksheet, ByVal fila As Integer, ByVal col As Integer) As Excel.Range
        Return CType(ws.Cells(fila, col), Excel.Range)
    End Function

    Public Shared Function ExcelFila(ByVal ws As Excel.Worksheet, ByVal fila As Integer) As Excel.Range
        Return CType(ws.Rows(fila), Excel.Range)
    End Function

    Public Shared Function ExcelColumna(ByVal ws As Excel.Worksheet, ByVal col As String) As Excel.Range
        Return CType(ws.Columns(col), Excel.Range)
    End Function

    Public Shared Function ValorCeldaStr(ByVal grilla As DataGridView, ByVal fila As Integer, ByVal col As Integer) As String
        If grilla Is Nothing OrElse fila < 0 OrElse fila >= grilla.RowCount OrElse col < 0 OrElse col >= grilla.ColumnCount Then Return String.Empty
        Dim v As Object = grilla.Rows(fila).Cells(col).Value
        Return If(v Is Nothing OrElse IsDBNull(v), String.Empty, v.ToString().Trim())
    End Function

    Public Sub solonumeros(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) Then
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
        If cmb Is Nothing Then Exit Sub
        cmb.Items.Clear()
        cmb.Items.Add("Noche")
        cmb.Items.Add("Mañana")
        cmb.Items.Add("Tarde")
        If cmb.Items.Count > 0 Then cmb.SelectedIndex = 0
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
    Private Shared ReadOnly _cacheIconos As New Dictionary(Of String, Bitmap)(StringComparer.Ordinal)
    Private Shared ReadOnly _imagenesOriginales As New Dictionary(Of Button, Image)()
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

    ''' <summary>
    ''' Genera un icono circular nítido de estado (farol verde si está conectado, rojo si no hay conexión).
    ''' </summary>
    Public Shared Function ObtenerIconoFarolEstado(ByVal conectado As Boolean, Optional ByVal tam As Integer = 14) As Bitmap
        Dim sizePx As Integer = Math.Max(10, Math.Min(32, tam))
        Dim key As String = "farol|" & If(conectado, "1", "0") & "|" & sizePx.ToString()
        Dim cached As Bitmap = Nothing
        If _cacheIconos.TryGetValue(key, cached) AndAlso cached IsNot Nothing Then
            Return cached
        End If

        Dim bmp As New Bitmap(sizePx, sizePx, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
            g.Clear(Color.Transparent)

            Dim haloColor As Color = If(conectado, Color.FromArgb(95, 34, 197, 94), Color.FromArgb(90, 239, 68, 68))
            Using brHalo As New SolidBrush(haloColor)
                g.FillEllipse(brHalo, 0.5F, 0.5F, sizePx - 1.0F, sizePx - 1.0F)
            End Using

            Dim pad As Single = Math.Max(2.0F, sizePx * 0.16F)
            Dim rectDot As New RectangleF(pad, pad, sizePx - pad * 2.0F, sizePx - pad * 2.0F)
            Dim cTop As Color = If(conectado, Color.FromArgb(74, 222, 128), Color.FromArgb(248, 113, 113))
            Dim cBot As Color = If(conectado, Color.FromArgb(22, 163, 74), Color.FromArgb(185, 28, 28))
            Dim cRim As Color = If(conectado, Color.FromArgb(20, 83, 45), Color.FromArgb(127, 29, 29))

            Using brDot As New System.Drawing.Drawing2D.LinearGradientBrush(rectDot, cTop, cBot, System.Drawing.Drawing2D.LinearGradientMode.Vertical),
                  pRim As New Pen(cRim, 1.0F)
                g.FillEllipse(brDot, rectDot)
                g.DrawEllipse(pRim, rectDot)
            End Using

            Dim rShine As New RectangleF(rectDot.X + rectDot.Width * 0.22F, rectDot.Y + rectDot.Height * 0.16F,
                                         Math.Max(2.0F, rectDot.Width * 0.34F), Math.Max(2.0F, rectDot.Height * 0.28F))
            Using brShine As New SolidBrush(Color.FromArgb(190, 255, 255, 255))
                g.FillEllipse(brShine, rShine)
            End Using
        End Using

        _cacheIconos(key) = bmp
        Return bmp
    End Function

    ''' <summary>
    ''' Reinicia completamente la aplicación para que recargue la configuración y datos de conexión desde cero.
    ''' </summary>
    Public Shared Sub ReiniciarAplicacion()
        Try
            SqlConnection.ClearAllPools()
        Catch
        End Try
        Try
            Application.Restart()
            Environment.Exit(0)
        Catch
            Try
                Dim exePath As String = Application.ExecutablePath
                If Not String.IsNullOrWhiteSpace(exePath) AndAlso File.Exists(exePath) Then
                    Process.Start(New ProcessStartInfo() With {
                        .FileName = exePath,
                        .WorkingDirectory = Path.GetDirectoryName(exePath),
                        .UseShellExecute = True
                    })
                End If
            Catch
            End Try
            Environment.Exit(0)
        End Try
    End Sub

    Private Shared Function EscalarIconoSiExcede(ByVal img As Image, ByVal maxDim As Integer) As Image
        If img Is Nothing OrElse maxDim <= 0 Then Return img
        If img.Width <= maxDim AndAlso img.Height <= maxDim Then Return img

        Dim escala As Double = Math.Min(CDbl(maxDim) / img.Width, CDbl(maxDim) / img.Height)
        Dim targetW As Integer = Math.Max(1, CInt(Math.Round(img.Width * escala)))
        Dim targetH As Integer = Math.Max(1, CInt(Math.Round(img.Height * escala)))
        Dim key As String = System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(img).ToString() & "|" &
                            img.Width.ToString() & "x" & img.Height.ToString() & "->" &
                            targetW.ToString() & "x" & targetH.ToString()

        Dim cached As Bitmap = Nothing
        If _cacheIconos.TryGetValue(key, cached) Then
            Return cached
        End If

        Dim bmp As New Bitmap(targetW, targetH, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.Transparent)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            g.DrawImage(img, New Rectangle(0, 0, targetW, targetH))
        End Using

        _cacheIconos(key) = bmp
        Return bmp
    End Function

    Private Shared Function TintarIconoBlanco(ByVal img As Image) As Image
        If img Is Nothing Then Return Nothing
        Try
            Dim key As String = "white|" & System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(img).ToString() & "|" & img.Width.ToString() & "x" & img.Height.ToString()
            Dim cached As Bitmap = Nothing
            If _cacheIconos.TryGetValue(key, cached) Then
                Return cached
            End If

            Dim bmp As New Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            Using src As New Bitmap(img)
                For y As Integer = 0 To src.Height - 1
                    For x As Integer = 0 To src.Width - 1
                        Dim px As Color = src.GetPixel(x, y)
                        If px.A > 10 Then
                            bmp.SetPixel(x, y, Color.FromArgb(px.A, 255, 255, 255))
                        Else
                            bmp.SetPixel(x, y, Color.Transparent)
                        End If
                    Next
                Next
            End Using

            _cacheIconos(key) = bmp
            Return bmp
        Catch
            Return img
        End Try
    End Function

    Private Shared Function EsBotonPrimario(ByVal btn As Button) As Boolean
        Dim txt As String = If(btn.Text, "").Replace("&", "").Trim()
        If String.IsNullOrEmpty(txt) Then Return False
        Dim n As String = If(btn.Name, "")
        Return txt.Equals("Guardar", StringComparison.OrdinalIgnoreCase) OrElse
               (n.Equals("btnGuardarMp", StringComparison.OrdinalIgnoreCase) AndAlso txt.Equals("Actualizar", StringComparison.OrdinalIgnoreCase)) OrElse
               txt.Equals("Ingresar", StringComparison.OrdinalIgnoreCase) OrElse
               txt.Equals("Ingresar MP", StringComparison.OrdinalIgnoreCase) OrElse
               txt.Equals("Aceptar", StringComparison.OrdinalIgnoreCase) OrElse
               txt.Equals("Planificar Ciclos", StringComparison.OrdinalIgnoreCase) OrElse
               txt.Equals("Crear Ciclos", StringComparison.OrdinalIgnoreCase) OrElse
               txt.Equals("Consultar BD", StringComparison.OrdinalIgnoreCase) OrElse
               txt.Equals("Generar", StringComparison.OrdinalIgnoreCase) OrElse
               txt.Equals("Actualizar Gantt", StringComparison.OrdinalIgnoreCase) OrElse
               txt.Equals("Guardar y Aplicar", StringComparison.OrdinalIgnoreCase) OrElse
               n.Equals("OK", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Shared Function EsBotonDestructivo(ByVal btn As Button) As Boolean
        Dim txt As String = If(btn.Text, "").Replace("&", "").Trim()
        If String.IsNullOrEmpty(txt) Then Return False
        Return txt.IndexOf("Eliminar", StringComparison.OrdinalIgnoreCase) >= 0
    End Function

    Private Shared Sub AplicarColoresEstadoBotonPrimario(ByVal btn As Button)
        If btn Is Nothing OrElse btn.IsDisposed Then Exit Sub
        Dim imgOriginal As Image = Nothing
        _imagenesOriginales.TryGetValue(btn, imgOriginal)
        If btn.Enabled Then
            btn.BackColor = ColorPrimario
            btn.ForeColor = Color.White
            btn.FlatAppearance.BorderColor = ColorPrimario
            btn.FlatAppearance.MouseOverBackColor = ColorSecundario
            btn.FlatAppearance.MouseDownBackColor = ColorDeepNavy
            If imgOriginal IsNot Nothing Then
                btn.Image = TintarIconoBlanco(imgOriginal)
            End If
        Else
            btn.BackColor = ColorFondoSoloLectura
            btn.ForeColor = ColorTextoAtenuado
            btn.FlatAppearance.BorderColor = ColorBotonSecundarioBorde
            If imgOriginal IsNot Nothing Then
                btn.Image = imgOriginal
            End If
        End If
    End Sub

    Private Shared ReadOnly _ajustandoTextoBoton As New HashSet(Of Button)()

    Private Shared Sub AlCambiarTextoBotonCorporativo(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = TryCast(sender, Button)
        If btn Is Nothing OrElse btn.IsDisposed OrElse _ajustandoTextoBoton.Contains(btn) Then Exit Sub
        _ajustandoTextoBoton.Add(btn)
        Try
            NormalizarIconoBoton(btn)
            AplicarEstiloBotonCorporativo(btn)
        Finally
            _ajustandoTextoBoton.Remove(btn)
        End Try
    End Sub

    Private Shared Sub AlDisponerBotonPrimario(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = TryCast(sender, Button)
        If btn IsNot Nothing Then
            _imagenesOriginales.Remove(btn)
            _ajustandoTextoBoton.Remove(btn)
        End If
    End Sub

    Private Shared Sub AlCambiarHabilitacionBotonPrimario(ByVal sender As Object, ByVal e As EventArgs)
        AplicarColoresEstadoBotonPrimario(TryCast(sender, Button))
    End Sub

    ''' <summary>
    ''' Aplica fuente, alineación de icono y estilo corporativo a un botón individual (útil en diálogos con cabecera propia).
    ''' </summary>
    Public Shared Sub AplicarEstiloBoton(ByVal btn As Button)
        If btn Is Nothing OrElse btn.IsDisposed Then Exit Sub
        UnificarFuenteCorporativa(btn)
        NormalizarIconoBoton(btn)
        AplicarEstiloBotonCorporativo(btn)
        NormalizarIconoBoton(btn)
    End Sub

    Private Shared Sub AplicarEstiloBotonCorporativo(ByVal btn As Button)
        If btn Is Nothing OrElse btn.IsDisposed Then Exit Sub
        btn.UseVisualStyleBackColor = False
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 1
        btn.Cursor = Cursors.Hand
        btn.AutoEllipsis = False
        RemoveHandler btn.TextChanged, AddressOf AlCambiarTextoBotonCorporativo
        AddHandler btn.TextChanged, AddressOf AlCambiarTextoBotonCorporativo

        If EsBotonPrimario(btn) Then
            If btn.Image IsNot Nothing AndAlso Not _imagenesOriginales.ContainsKey(btn) Then
                _imagenesOriginales(btn) = btn.Image
                AddHandler btn.Disposed, AddressOf AlDisponerBotonPrimario
            End If
            RemoveHandler btn.EnabledChanged, AddressOf AlCambiarHabilitacionBotonPrimario
            AddHandler btn.EnabledChanged, AddressOf AlCambiarHabilitacionBotonPrimario
            AplicarColoresEstadoBotonPrimario(btn)
            If btn.Font IsNot Nothing AndAlso Not btn.Font.Bold Then
                Dim key As String = btn.Font.SizeInPoints.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture) & "|" & CInt(btn.Font.Style Or FontStyle.Bold).ToString()
                Dim fBold As Font = Nothing
                If Not _cacheFuentes.TryGetValue(key, fBold) Then
                    fBold = New Font(btn.Font.FontFamily, btn.Font.SizeInPoints, btn.Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
                    _cacheFuentes(key) = fBold
                End If
                Dim prevFont As Font = btn.Font
                btn.Font = fBold
                If btn.PreferredSize.Width > btn.Width Then
                    btn.Font = prevFont
                End If
            End If
        ElseIf EsBotonDestructivo(btn) Then
            btn.BackColor = ColorBotonEliminarFondo
            btn.ForeColor = ColorTextoDestacado
            btn.FlatAppearance.BorderColor = ColorBotonEliminarBorde
            btn.FlatAppearance.MouseOverBackColor = ColorBotonEliminarHover
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(254, 205, 211)
        Else
            btn.BackColor = Color.White
            btn.ForeColor = ColorDeepNavy
            btn.FlatAppearance.BorderColor = ColorSecundario
            btn.FlatAppearance.MouseOverBackColor = ColorBotonHover
            btn.FlatAppearance.MouseDownBackColor = ColorGrisAzulado
        End If
    End Sub

    Private Shared Sub NormalizarIconoBoton(ByVal btn As Button)
        If btn Is Nothing OrElse btn.IsDisposed Then Exit Sub

        If btn.Image IsNot Nothing Then
            Dim tieneTexto As Boolean = Not String.IsNullOrWhiteSpace(btn.Text)
            If tieneTexto Then
                Dim textoLimpio As String = btn.Text.Trim()
                If btn.Text <> textoLimpio Then
                    btn.Text = textoLimpio
                End If
                Dim maxIcono As Integer = If(btn.Height >= 30, Math.Min(20, Math.Max(16, btn.Height - 10)), 16)
                btn.Image = EscalarIconoSiExcede(btn.Image, maxIcono)
                If _imagenesOriginales.ContainsKey(btn) Then
                    _imagenesOriginales(btn) = btn.Image
                End If
                btn.ImageAlign = ContentAlignment.MiddleLeft
                btn.TextAlign = ContentAlignment.MiddleCenter
                btn.TextImageRelation = TextImageRelation.ImageBeforeText
                btn.Padding = New Padding(4, 0, 4, 0)
                Dim tamTxt As Size = TextRenderer.MeasureText(textoLimpio.Replace("&", ""), btn.Font)
                Dim pref As Size = btn.GetPreferredSize(Size.Empty)
                Dim anchoMin As Integer = Math.Max(btn.Image.Width + tamTxt.Width + 16, pref.Width)
                If btn.Width < anchoMin Then
                    btn.Width = anchoMin
                End If
                If btn.Height < pref.Height AndAlso pref.Height <= 36 Then
                    btn.Height = pref.Height
                End If
            Else
                Dim maxIcono As Integer = Math.Max(12, Math.Min(btn.ClientSize.Width, btn.ClientSize.Height) - 6)
                btn.Image = EscalarIconoSiExcede(btn.Image, maxIcono)
                btn.ImageAlign = ContentAlignment.MiddleCenter
            End If
        End If

        If btn.BackgroundImage IsNot Nothing Then
            Dim maxFondo As Integer = Math.Max(12, Math.Min(btn.ClientSize.Width, btn.ClientSize.Height) - 6)
            btn.BackgroundImage = EscalarIconoSiExcede(btn.BackgroundImage, maxFondo)
            btn.BackgroundImageLayout = ImageLayout.Center
        End If
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
                Dim nomPanel As String = If(ctrl.Name, "")
                If nomPanel.StartsWith("pnlCard", StringComparison.OrdinalIgnoreCase) OrElse
                   nomPanel.StartsWith("pnlKpi", StringComparison.OrdinalIgnoreCase) Then
                    ctrl.BackColor = Color.White
                ElseIf TypeOf ctrl.Parent Is TabPage Then
                    ctrl.BackColor = ColorFondoPanel
                Else
                    ctrl.BackColor = ColorFondoForm
                End If
                HabilitarDobleBuffer(ctrl)

            ElseIf TypeOf ctrl Is Button Then
                Dim btn As Button = DirectCast(ctrl, Button)
                AplicarEstiloBoton(btn)

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
                Dim nomLbl As String = If(ctrl.Name, "")
                If EsColorRojo(ctrl.ForeColor) Then
                    ctrl.ForeColor = ColorTextoDestacado
                ElseIf nomLbl.StartsWith("lblTitKpi", StringComparison.OrdinalIgnoreCase) OrElse
                       nomLbl.StartsWith("lblKpi", StringComparison.OrdinalIgnoreCase) Then
                    ' Preserva los colores semánticos de tarjetas KPI (azul/verde/rojo)
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
    Private Shared Function SetProcessWorkingSetSize(ByVal hProcess As IntPtr, ByVal dwMinimumWorkingSetSize As IntPtr, ByVal dwMaximumWorkingSetSize As IntPtr) As Boolean
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
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, New IntPtr(-1), New IntPtr(-1))
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

    ''' <summary>
    ''' Intenta convertir de forma segura un objeto o texto a Entero (sin excepciones por cadenas vacías o nulas).
    ''' </summary>
    Public Shared Function TrySafeInt(ByVal valor As Object, ByRef resultado As Integer) As Boolean
        resultado = 0
        If valor Is Nothing OrElse IsDBNull(valor) Then Return False
        If TypeOf valor Is Integer Then
            resultado = DirectCast(valor, Integer)
            Return True
        End If
        Dim s As String = valor.ToString().Trim()
        If String.IsNullOrEmpty(s) Then Return False
        If Integer.TryParse(s, Globalization.NumberStyles.Integer, Globalization.CultureInfo.CurrentCulture, resultado) Then
            Return True
        End If
        Dim estiloDec As Globalization.NumberStyles = Globalization.NumberStyles.AllowLeadingSign Or Globalization.NumberStyles.AllowDecimalPoint
        Dim dec As Decimal
        If (Decimal.TryParse(s, estiloDec, Globalization.CultureInfo.CurrentCulture, dec) OrElse
            Decimal.TryParse(s, estiloDec, Globalization.CultureInfo.InvariantCulture, dec)) AndAlso
           dec >= Integer.MinValue AndAlso dec <= Integer.MaxValue AndAlso dec = Math.Truncate(dec) Then
            resultado = Convert.ToInt32(dec)
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' Convierte de forma segura un objeto o texto a Entero devolviendo el valor por defecto si es inválido.
    ''' </summary>
    Public Shared Function SafeInt(ByVal valor As Object, Optional ByVal defecto As Integer = 0) As Integer
        Dim res As Integer = 0
        If TrySafeInt(valor, res) Then Return res
        Return defecto
    End Function

    ''' <summary>
    ''' Intenta convertir de forma segura un objeto o texto a Double admitiendo cultura local e invariante.
    ''' </summary>
    Public Shared Function TrySafeDouble(ByVal valor As Object, ByRef resultado As Double) As Boolean
        resultado = 0.0
        If valor Is Nothing OrElse IsDBNull(valor) Then Return False
        If TypeOf valor Is Double Then
            resultado = DirectCast(valor, Double)
            Return True
        End If
        If TypeOf valor Is Decimal Then
            resultado = Convert.ToDouble(DirectCast(valor, Decimal))
            Return True
        End If
        If TypeOf valor Is Integer Then
            resultado = Convert.ToDouble(DirectCast(valor, Integer))
            Return True
        End If
        Dim s As String = valor.ToString().Trim()
        If String.IsNullOrEmpty(s) Then Return False
        If Double.TryParse(s, Globalization.NumberStyles.Any, Globalization.CultureInfo.CurrentCulture, resultado) Then Return True
        Return Double.TryParse(s, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, resultado)
    End Function

    ''' <summary>
    ''' Convierte de forma segura un objeto o texto a Double devolviendo el valor por defecto si es inválido.
    ''' </summary>
    Public Shared Function SafeDouble(ByVal valor As Object, Optional ByVal defecto As Double = 0.0) As Double
        Dim res As Double = 0.0
        If TrySafeDouble(valor, res) Then Return res
        Return defecto
    End Function

    ''' <summary>
    ''' Acota un DateTime al rango válido de SQL Server DATETIME (>= 1753-01-01).
    ''' </summary>
    Public Shared Function SafeSqlDateTime(ByVal fecha As DateTime) As DateTime
        Dim sqlMin As New DateTime(1753, 1, 1)
        If fecha < sqlMin Then Return DateTime.Today
        Return fecha
    End Function

    ''' <summary>
    ''' Devuelve el inicio del día (00:00:00) dentro del rango válido de SQL Server DATETIME.
    ''' </summary>
    Public Shared Function SafeSqlDateStart(ByVal fecha As DateTime) As DateTime
        Return SafeSqlDateTime(fecha).Date
    End Function

    ''' <summary>
    ''' Devuelve el fin del día (23:59:59) dentro del rango válido de SQL Server DATETIME.
    ''' </summary>
    Public Shared Function SafeSqlDateEnd(ByVal fecha As DateTime) As DateTime
        Return SafeSqlDateTime(fecha).Date.AddHours(23).AddMinutes(59).AddSeconds(59)
    End Function

    ''' <summary>
    ''' Normaliza un componente horario a la fecha base SQL Server 1900-01-01 para columnas de hora.
    ''' </summary>
    Public Shared Function SafeSqlTime(ByVal hora As DateTime) As DateTime
        Return New DateTime(1900, 1, 1, hora.Hour, hora.Minute, hora.Second)
    End Function

    ''' <summary>
    ''' Agrega un parámetro SqlDbType.DateTime tipado y acotado al rango SQL válido (>= 1753-01-01).
    ''' Evita errores de conversión NVARCHAR -> DATETIME dependientes del idioma/DATEFORMAT.
    ''' </summary>
    Public Shared Sub AgregarParametroFecha(ByVal cmd As SqlCommand, ByVal nombre As String, ByVal valor As DateTime)
        If cmd Is Nothing OrElse String.IsNullOrEmpty(nombre) Then Exit Sub
        Dim par As New SqlParameter(nombre, SqlDbType.DateTime)
        par.Value = SafeSqlDateTime(valor)
        cmd.Parameters.Add(par)
    End Sub

    ''' <summary>
    ''' Parsea de forma segura un DateTime desde objetos/cadenas/DataRowView sin lanzar InvalidCastException.
    ''' </summary>
    Public Shared Function ObtenerFechaSegura(ByVal valor As Object, Optional ByVal defecto As DateTime = Nothing) As DateTime
        Dim fallback As DateTime = If(defecto = DateTime.MinValue, DateTime.Today, SafeSqlDateTime(defecto))
        If valor Is Nothing OrElse IsDBNull(valor) Then Return fallback
        If TypeOf valor Is DateTime Then Return SafeSqlDateTime(DirectCast(valor, DateTime))
        Dim parsed As DateTime
        If DateTime.TryParse(valor.ToString().Trim(), Globalization.CultureInfo.CurrentCulture, Globalization.DateTimeStyles.None, parsed) Then
            Return SafeSqlDateTime(parsed)
        End If
        If DateTime.TryParse(valor.ToString().Trim(), Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, parsed) Then
            Return SafeSqlDateTime(parsed)
        End If
        Return fallback
    End Function

    ''' <summary>
    ''' Lee el texto recortado de una celda de DataGridView tolerando índices fuera de rango, Nothing y DBNull.
    ''' </summary>
    Public Shared Function CeldaTexto(ByVal fila As DataGridViewRow, ByVal indiceCol As Integer) As String
        If fila Is Nothing OrElse fila.IsNewRow OrElse indiceCol < 0 OrElse indiceCol >= fila.Cells.Count Then
            Return String.Empty
        End If
        Dim v As Object = fila.Cells(indiceCol).Value
        If v Is Nothing OrElse IsDBNull(v) Then Return String.Empty
        Return v.ToString().Trim()
    End Function

    Private Shared ReadOnly _grillasConSelectorGantt As New HashSet(Of Integer)()

    ''' <summary>
    ''' Agrega o sincroniza la columna checkbox "colSelGantt" (mostrada primero por DisplayIndex = 0 sin alterar los índices 0..N de las columnas existentes)
    ''' y habilita clic directo en celda y clic en encabezado "Sel." para marcar/desmarcar ciclos.
    ''' </summary>
    Public Shared Sub AsegurarColumnaSeleccionGantt(ByVal dgv As DataGridView)
        If dgv Is Nothing OrElse dgv.IsDisposed Then Exit Sub

        If dgv.Columns.Contains("colSelGantt") AndAlso dgv.Columns("colSelGantt").Index < dgv.Columns.Count - 1 Then
            dgv.Columns.Remove("colSelGantt")
        End If

        Dim colSel As DataGridViewCheckBoxColumn
        If Not dgv.Columns.Contains("colSelGantt") Then
            colSel = New DataGridViewCheckBoxColumn With {
                .Name = "colSelGantt",
                .HeaderText = "Sel.",
                .Width = 40,
                .MinimumWidth = 36,
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                .SortMode = DataGridViewColumnSortMode.NotSortable,
                .FillWeight = 20.0F,
                .ReadOnly = True,
                .ThreeState = False,
                .ToolTipText = "Marque uno o varios ciclos para Carta Gantt (clic en 'Sel.' marca/desmarca todos)"
            }
            colSel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.Columns.Add(colSel)
        Else
            colSel = TryCast(dgv.Columns("colSelGantt"), DataGridViewCheckBoxColumn)
        End If

        If colSel IsNot Nothing Then
            colSel.DisplayIndex = 0
            colSel.Width = 40
            colSel.ReadOnly = True
            For Each r As DataGridViewRow In dgv.Rows
                If r.IsNewRow Then Continue For
                Dim curVal As Object = r.Cells(colSel.Index).Value
                If curVal Is Nothing OrElse IsDBNull(curVal) Then
                    r.Cells(colSel.Index).Value = False
                End If
            Next
        End If

        Dim keyHash As Integer = Runtime.CompilerServices.RuntimeHelpers.GetHashCode(dgv)
        If Not _grillasConSelectorGantt.Contains(keyHash) Then
            _grillasConSelectorGantt.Add(keyHash)
            AddHandler dgv.CellClick, Sub(sender, e)
                                          If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub
                                          Dim g As DataGridView = DirectCast(sender, DataGridView)
                                          If g.Columns(e.ColumnIndex).Name <> "colSelGantt" Then Exit Sub
                                          Dim r As DataGridViewRow = g.Rows(e.RowIndex)
                                          If r.IsNewRow Then Exit Sub
                                          Dim actual As Boolean = False
                                          Dim v As Object = r.Cells(e.ColumnIndex).Value
                                          If v IsNot Nothing AndAlso Not IsDBNull(v) Then Boolean.TryParse(v.ToString(), actual)
                                          r.Cells(e.ColumnIndex).Value = Not actual
                                          g.InvalidateCell(e.ColumnIndex, e.RowIndex)
                                      End Sub
            AddHandler dgv.ColumnHeaderMouseClick, Sub(sender, e)
                                                       If e.ColumnIndex < 0 Then Exit Sub
                                                       Dim g As DataGridView = DirectCast(sender, DataGridView)
                                                       If g.Columns(e.ColumnIndex).Name <> "colSelGantt" OrElse g.RowCount = 0 Then Exit Sub
                                                       Dim haySinMarcar As Boolean = False
                                                       For Each r As DataGridViewRow In g.Rows
                                                           If r.IsNewRow Then Continue For
                                                           Dim marc As Boolean = False
                                                           Dim v As Object = r.Cells(e.ColumnIndex).Value
                                                           If v IsNot Nothing AndAlso Not IsDBNull(v) Then Boolean.TryParse(v.ToString(), marc)
                                                           If Not marc Then
                                                               haySinMarcar = True
                                                               Exit For
                                                           End If
                                                       Next
                                                       For Each r As DataGridViewRow In g.Rows
                                                           If Not r.IsNewRow Then r.Cells(e.ColumnIndex).Value = haySinMarcar
                                                       Next
                                                       g.Refresh()
                                                   End Sub
            AddHandler dgv.DataError, Sub(sender, e)
                                          e.ThrowException = False
                                      End Sub
            AddHandler dgv.Disposed, Sub(sender, e)
                                         _grillasConSelectorGantt.Remove(Runtime.CompilerServices.RuntimeHelpers.GetHashCode(sender))
                                     End Sub
        End If
    End Sub

    ''' <summary>
    ''' Elimina la columna checkbox "colSelGantt" al limpiar una grilla para no dejar encabezados huérfanos sin datos.
    ''' </summary>
    Public Shared Sub QuitarColumnaSeleccionGantt(ByVal dgv As DataGridView)
        If dgv Is Nothing OrElse dgv.IsDisposed Then Exit Sub
        If dgv.Columns.Contains("colSelGantt") Then
            dgv.Columns.Remove("colSelGantt")
        End If
    End Sub

    ''' <summary>
    ''' Devuelve únicamente las filas con la casilla "colSelGantt" marcada en verdadero.
    ''' </summary>
    Public Shared Function ObtenerFilasMarcadas(ByVal dgv As DataGridView) As List(Of DataGridViewRow)
        Dim lista As New List(Of DataGridViewRow)()
        If dgv Is Nothing OrElse Not dgv.Columns.Contains("colSelGantt") Then Return lista
        Dim idxSel As Integer = dgv.Columns("colSelGantt").Index
        For Each r As DataGridViewRow In dgv.Rows
            If r.IsNewRow Then Continue For
            Dim v As Object = r.Cells(idxSel).Value
            Dim marc As Boolean = False
            If v IsNot Nothing AndAlso Not IsDBNull(v) Then Boolean.TryParse(v.ToString(), marc)
            If marc Then lista.Add(r)
        Next
        Return lista
    End Function

    ''' <summary>
    ''' Devuelve las filas marcadas con checkbox; si ninguna está marcada y "soloFilaActualSiNoHayMarcadas" es True,
    ''' devuelve las filas seleccionadas o la fila actual; de lo contrario devuelve todas las filas.
    ''' </summary>
    Public Shared Function ObtenerFilasMarcadasOSeleccionadas(ByVal dgv As DataGridView, ByVal soloFilaActualSiNoHayMarcadas As Boolean) As List(Of DataGridViewRow)
        Dim lista As List(Of DataGridViewRow) = ObtenerFilasMarcadas(dgv)
        If lista.Count > 0 OrElse dgv Is Nothing OrElse dgv.RowCount = 0 Then Return lista

        If soloFilaActualSiNoHayMarcadas Then
            If dgv.SelectedRows.Count > 0 Then
                For Each r As DataGridViewRow In dgv.Rows
                    If Not r.IsNewRow AndAlso r.Selected Then lista.Add(r)
                Next
            ElseIf dgv.CurrentRow IsNot Nothing AndAlso Not dgv.CurrentRow.IsNewRow Then
                lista.Add(dgv.CurrentRow)
            End If
        End If

        If lista.Count = 0 Then
            For Each r As DataGridViewRow In dgv.Rows
                If Not r.IsNewRow Then lista.Add(r)
            Next
        End If
        Return lista
    End Function

    Public Structure InformacionInstalacion
        Public Version As String
        Public VersionArchivo As String
        Public FechaHoraInstalacion As String
        Public OrigenRegistro As String
        Public RutaInstalacion As String
    End Structure

    Private Shared Function LeerValorRegistro(ByVal root As RegistryKey, ByVal subKeyPath As String, ByVal valueName As String) As String
        If root Is Nothing OrElse String.IsNullOrWhiteSpace(subKeyPath) Then Return String.Empty
        Try
            Using k As RegistryKey = root.OpenSubKey(subKeyPath, False)
                If k IsNot Nothing Then
                    Dim v As Object = k.GetValue(valueName)
                    If v IsNot Nothing Then
                        Dim s As String = v.ToString().Trim()
                        If Not String.IsNullOrWhiteSpace(s) Then Return s
                    End If
                End If
            End Using
        Catch
        End Try
        Return String.Empty
    End Function

    Private Shared Function LeerValorRegistroMultiVista(ByVal hive As RegistryHive, ByVal subKeyPath As String, ByVal valueName As String) As String
        For Each vista As RegistryView In New RegistryView() {RegistryView.Registry64, RegistryView.Registry32, RegistryView.Default}
            Try
                Using baseKey As RegistryKey = RegistryKey.OpenBaseKey(hive, vista)
                    Dim val As String = LeerValorRegistro(baseKey, subKeyPath, valueName)
                    If Not String.IsNullOrWhiteSpace(val) Then Return val
                End Using
            Catch
            End Try
        Next
        Return String.Empty
    End Function

    ''' <summary>
    ''' Devuelve la versión semántica de la aplicación definida centralizadamente en VERSION.txt.
    ''' </summary>
    Public Shared Function ObtenerVersionAplicacion() As String
        Try
            Dim asm As Assembly = Assembly.GetExecutingAssembly()
            Dim infoAttr = asm.GetCustomAttribute(Of AssemblyInformationalVersionAttribute)()
            If infoAttr IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(infoAttr.InformationalVersion) Then
                Dim verTxt As String = infoAttr.InformationalVersion.Split("+"c)(0).Trim()
                If Not String.IsNullOrWhiteSpace(verTxt) Then Return verTxt
            End If

            Dim v As Version = asm.GetName().Version
            If v IsNot Nothing Then
                Return String.Format("{0}.{1}.{2}", v.Major, v.Minor, Math.Max(0, v.Build))
            End If
        Catch
        End Try
        Return "2026.2.0"
    End Function

    ''' <summary>
    ''' Devuelve versión, compilación, ruta y día/hora exacta de instalación (desde Registro Windows o marca temporal del ejecutable).
    ''' </summary>
    Public Shared Function ObtenerInformacionInstalacion() As InformacionInstalacion
        Dim info As New InformacionInstalacion()
        info.Version = ObtenerVersionAplicacion()
        Try
            Dim v As Version = Assembly.GetExecutingAssembly().GetName().Version
            info.VersionArchivo = If(v IsNot Nothing, v.ToString(), info.Version & ".0")
        Catch
            info.VersionArchivo = info.Version & ".0"
        End Try

        Dim rutaExe As String = String.Empty
        Try
            rutaExe = Environment.ProcessPath
        Catch
        End Try
        If String.IsNullOrWhiteSpace(rutaExe) Then
            Try
                rutaExe = Application.ExecutablePath
            Catch
            End Try
        End If
        Dim rutaAsmDir As String = String.Empty
        Try
            Dim loc As String = Assembly.GetExecutingAssembly().Location
            If Not String.IsNullOrWhiteSpace(loc) Then rutaAsmDir = Path.GetDirectoryName(loc)
        Catch
        End Try
        info.RutaInstalacion = If(Not String.IsNullOrWhiteSpace(rutaAsmDir), rutaAsmDir, Application.StartupPath)

        Const subKeyApp As String = "Software\Cambiaso\SistemaMantencion"
        Const subKeyUninst As String = "Software\Microsoft\Windows\CurrentVersion\Uninstall\{81543D95-46BE-4730-8A08-A163B21205D7}_is1"

        Dim fechaReg As String = LeerValorRegistroMultiVista(RegistryHive.CurrentUser, subKeyApp, "InstallDate")
        If String.IsNullOrWhiteSpace(fechaReg) Then
            fechaReg = LeerValorRegistroMultiVista(RegistryHive.LocalMachine, subKeyApp, "InstallDate")
        End If
        If Not String.IsNullOrWhiteSpace(fechaReg) Then
            info.FechaHoraInstalacion = fechaReg
            info.OrigenRegistro = "Registro de instalación Windows"
            Dim rutaReg As String = LeerValorRegistroMultiVista(RegistryHive.CurrentUser, subKeyApp, "InstallDir")
            If String.IsNullOrWhiteSpace(rutaReg) Then
                rutaReg = LeerValorRegistroMultiVista(RegistryHive.LocalMachine, subKeyApp, "InstallDir")
            End If
            If Not String.IsNullOrWhiteSpace(rutaReg) Then info.RutaInstalacion = rutaReg
            Return info
        End If

        Dim fechaUninst As String = LeerValorRegistroMultiVista(RegistryHive.CurrentUser, subKeyUninst, "InstallDate")
        If String.IsNullOrWhiteSpace(fechaUninst) Then
            fechaUninst = LeerValorRegistroMultiVista(RegistryHive.LocalMachine, subKeyUninst, "InstallDate")
        End If
        Dim dtFile As DateTime = DateTime.Now
        If Not String.IsNullOrWhiteSpace(rutaExe) AndAlso File.Exists(rutaExe) Then
            dtFile = File.GetLastWriteTime(rutaExe)
        End If

        Dim dtParsed As DateTime
        If Not String.IsNullOrWhiteSpace(fechaUninst) AndAlso DateTime.TryParseExact(fechaUninst, "yyyyMMdd", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, dtParsed) Then
            info.FechaHoraInstalacion = New DateTime(dtParsed.Year, dtParsed.Month, dtParsed.Day, dtFile.Hour, dtFile.Minute, dtFile.Second).ToString("dd-MM-yyyy HH:mm:ss")
            info.OrigenRegistro = "Registro de instalador del sistema"
            Return info
        End If

        info.FechaHoraInstalacion = dtFile.ToString("dd-MM-yyyy HH:mm:ss")
        info.OrigenRegistro = "Marca temporal de compilación / ejecutable"
        Return info
    End Function
End Class
