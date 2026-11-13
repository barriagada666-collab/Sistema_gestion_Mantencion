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
                MessageBox.Show("El archivo PDF de destino está abierto en otro programa. Ciérrelo e intente nuevamente." & Environment.NewLine & ex.Message, "Exportar a PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                Try
                    Process.Start(rutaPdf)
                Catch
                End Try
            End If
        End If
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
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Cierra y libera de forma segura los objetos COM de Excel para no dejar procesos EXCEL.EXE en segundo plano.
    ''' </summary>
    Public Shared Sub LiberarExcel(ByRef workbook As Excel.Workbook, ByRef excelApp As Excel.Application)
        Try
            If workbook IsNot Nothing Then
                workbook.Close(False)
                Marshal.ReleaseComObject(workbook)
                workbook = Nothing
            End If
        Catch
        End Try
        Try
            If excelApp IsNot Nothing Then
                excelApp.Quit()
                Marshal.ReleaseComObject(excelApp)
                excelApp = Nothing
            End If
        Catch
        End Try
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
    ''' Aplica recursivamente la paleta de colores corporativa con alto contraste a un formulario y todos sus controles.
    ''' </summary>
    Public Shared Sub AplicarTemaModerno(ByVal controlRaiz As Control)
        If controlRaiz Is Nothing OrElse controlRaiz.IsDisposed Then Exit Sub

        If TypeOf controlRaiz Is Form Then
            Dim frm As Form = DirectCast(controlRaiz, Form)
            _formulariosConTema.Add(frm)
            RemoveHandler frm.FormClosed, AddressOf AlCerrarFormularioTema
            AddHandler frm.FormClosed, AddressOf AlCerrarFormularioTema
            If Not frm.IsMdiContainer Then
                frm.BackColor = ColorFondoForm
            End If
            frm.ForeColor = ColorTextoPrincipal
            HabilitarDobleBuffer(frm)
        End If

        AplicarTemaControlesHijos(controlRaiz.Controls)
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
                cmb.BackColor = ColorFondoInput
                cmb.ForeColor = ColorTextoPrincipal

            ElseIf TypeOf ctrl Is TreeView Then
                Dim tv As TreeView = DirectCast(ctrl, TreeView)
                HabilitarDobleBuffer(tv)
                tv.HideSelection = False
                tv.BackColor = Color.White
                tv.ForeColor = ColorTextoPrincipal
                tv.LineColor = ColorSecundario

            ElseIf TypeOf ctrl Is DateTimePicker Then
                Dim dtp As DateTimePicker = DirectCast(ctrl, DateTimePicker)
                dtp.CalendarTitleBackColor = ColorPrimario
                dtp.CalendarTitleForeColor = Color.White
                dtp.CalendarForeColor = ColorTextoPrincipal
                dtp.CalendarMonthBackground = Color.White
                dtp.CalendarTrailingForeColor = ColorTextoAtenuado

            ElseIf TypeOf ctrl Is TabPage Then
                Dim tp As TabPage = DirectCast(ctrl, TabPage)
                tp.UseVisualStyleBackColor = False
                tp.BackColor = ColorFondoPanel
                tp.ForeColor = ColorTextoPrincipal

            ElseIf TypeOf ctrl Is GroupBox Then
                ctrl.ForeColor = ColorPrimario
                ctrl.BackColor = ColorFondoForm
                HabilitarDobleBuffer(ctrl)

            ElseIf TypeOf ctrl Is Panel Then
                ctrl.ForeColor = ColorTextoPrincipal
                If TypeOf ctrl.Parent Is TabPage Then
                    ctrl.BackColor = ColorFondoPanel
                Else
                    ctrl.BackColor = ColorFondoForm
                End If
                HabilitarDobleBuffer(ctrl)

            ElseIf TypeOf ctrl Is Button Then
                Dim btn As Button = DirectCast(ctrl, Button)
                btn.UseVisualStyleBackColor = False
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderColor = ColorSecundario
                btn.FlatAppearance.BorderSize = 1
                btn.FlatAppearance.MouseOverBackColor = ColorBotonHover
                btn.FlatAppearance.MouseDownBackColor = ColorGrisAzulado
                btn.BackColor = Color.White
                btn.ForeColor = ColorPrimario
                btn.Cursor = Cursors.Hand

            ElseIf TypeOf ctrl Is Label OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton Then
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

            ElseIf TypeOf ctrl Is MenuStrip Then
                Dim ms As MenuStrip = DirectCast(ctrl, MenuStrip)
                ms.BackColor = ColorGrisAzulado
                ms.ForeColor = ColorTextoPrincipal
                ms.Renderer = New ToolStripProfessionalRenderer(New ModernColorTable())
                ms.Font = New Font("Calibri", 12.5F, FontStyle.Bold)
                For Each item As ToolStripItem In ms.Items
                    item.Font = New Font("Calibri", 12.5F, FontStyle.Bold)
                    item.ForeColor = ColorTextoPrincipal
                    ConfigurarSubMenuItems(item)
                Next

            ElseIf TypeOf ctrl Is StatusStrip Then
                Dim ss As StatusStrip = DirectCast(ctrl, StatusStrip)
                ss.BackColor = ColorPrimario
                ss.ForeColor = Color.White
                ss.Renderer = New ToolStripProfessionalRenderer(New ModernColorTable())
                For Each item As ToolStripItem In ss.Items
                    item.ForeColor = Color.White
                Next

            ElseIf TypeOf ctrl Is ToolStrip Then
                Dim ts As ToolStrip = DirectCast(ctrl, ToolStrip)
                ts.BackColor = ColorGrisAzulado
                ts.ForeColor = ColorTextoPrincipal
                ts.Renderer = New ToolStripProfessionalRenderer(New ModernColorTable())
            End If

            If ctrl.HasChildren AndAlso Not TypeOf ctrl Is NumericUpDown AndAlso Not TypeOf ctrl Is UserControl Then
                AplicarTemaControlesHijos(ctrl.Controls)
            End If
        Next
    End Sub

    Private Shared Sub ConfigurarSubMenuItems(ByVal item As ToolStripItem)
        If TypeOf item Is ToolStripDropDownItem Then
            Dim ddi As ToolStripDropDownItem = DirectCast(item, ToolStripDropDownItem)
            For Each subItem As ToolStripItem In ddi.DropDownItems
                subItem.Font = New Font("Calibri", 11.0F, FontStyle.Regular)
                subItem.ForeColor = ColorTextoPrincipal
                ConfigurarSubMenuItems(subItem)
            Next
        End If
    End Sub

    Private Class ModernColorTable
        Inherits ProfessionalColorTable

        Public Overrides ReadOnly Property MenuStripGradientBegin As Color
            Get
                Return ColorGrisAzulado
            End Get
        End Property

        Public Overrides ReadOnly Property MenuStripGradientEnd As Color
            Get
                Return ColorGrisAzulado
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemSelected As Color
            Get
                Return ColorAcento
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemSelectedGradientBegin As Color
            Get
                Return ColorAcento
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemSelectedGradientEnd As Color
            Get
                Return ColorAcento
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemPressedGradientBegin As Color
            Get
                Return ColorSecundario
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemPressedGradientEnd As Color
            Get
                Return ColorSecundario
            End Get
        End Property

        Public Overrides ReadOnly Property ToolStripDropDownBackground As Color
            Get
                Return Color.White
            End Get
        End Property

        Public Overrides ReadOnly Property ImageMarginGradientBegin As Color
            Get
                Return ColorFondoForm
            End Get
        End Property

        Public Overrides ReadOnly Property ImageMarginGradientMiddle As Color
            Get
                Return ColorFondoForm
            End Get
        End Property

        Public Overrides ReadOnly Property ImageMarginGradientEnd As Color
            Get
                Return ColorFondoForm
            End Get
        End Property

        Public Overrides ReadOnly Property MenuBorder As Color
            Get
                Return ColorSecundario
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemBorder As Color
            Get
                Return ColorSecundario
            End Get
        End Property

        Public Overrides ReadOnly Property StatusStripGradientBegin As Color
            Get
                Return ColorPrimario
            End Get
        End Property

        Public Overrides ReadOnly Property StatusStripGradientEnd As Color
            Get
                Return ColorPrimario
            End Get
        End Property
    End Class

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
                Dim asignado As Integer = 0
                For i As Integer = 0 To visibles.Count - 1
                    Dim incremento As Integer
                    If i = visibles.Count - 1 Then
                        incremento = extra - asignado
                    Else
                        incremento = CInt(Math.Floor(extra * (visibles(i).Width / CDbl(total))))
                    End If
                    visibles(i).Width += incremento
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
