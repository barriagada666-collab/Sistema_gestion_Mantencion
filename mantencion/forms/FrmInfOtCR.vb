Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class FrmInfOtCR

    Private Sub FrmInfOtCR_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.CRV_INF_OT.RefreshReport()
    End Sub

End Class

''' <summary>
''' Control visor de informes nativo (.NET + iTextSharp) compatible con la interfaz de CrystalReportViewer.
''' </summary>
Public Class NativeReportViewer
    Inherits UserControl

    Private _toolStrip As ToolStrip
    Private _btnExportarPdf As ToolStripButton
    Private _btnVistaPrevia As ToolStripButton
    Private _btnImprimir As ToolStripButton
    Private _btnActualizar As ToolStripButton
    Private _lblEstado As ToolStripLabel
    Private _browser As WebBrowser
    Private _reportSource As Object
    Private _activeViewIndex As Integer = -1

    Public Sub New()
        MyBase.New()
        InicializarComponentesVisor()
    End Sub

    Private Sub InicializarComponentesVisor()
        _toolStrip = New ToolStrip()
        _toolStrip.GripStyle = ToolStripGripStyle.Hidden
        _toolStrip.Dock = DockStyle.Top
        _toolStrip.BackColor = Utilitarios.ColorGrisAzulado

        _btnExportarPdf = New ToolStripButton("Exportar a PDF")
        _btnExportarPdf.DisplayStyle = ToolStripItemDisplayStyle.Text
        _btnExportarPdf.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        _btnExportarPdf.ForeColor = Utilitarios.ColorPrimario
        AddHandler _btnExportarPdf.Click, AddressOf OnExportarPdfClick

        _btnVistaPrevia = New ToolStripButton("Vista Previa de Impresión")
        _btnVistaPrevia.DisplayStyle = ToolStripItemDisplayStyle.Text
        AddHandler _btnVistaPrevia.Click, AddressOf OnVistaPreviaClick

        _btnImprimir = New ToolStripButton("Imprimir...")
        _btnImprimir.DisplayStyle = ToolStripItemDisplayStyle.Text
        AddHandler _btnImprimir.Click, AddressOf OnImprimirClick

        _btnActualizar = New ToolStripButton("Actualizar")
        _btnActualizar.DisplayStyle = ToolStripItemDisplayStyle.Text
        AddHandler _btnActualizar.Click, AddressOf OnActualizarClick

        _lblEstado = New ToolStripLabel("")
        _lblEstado.Alignment = ToolStripItemAlignment.Right
        _lblEstado.ForeColor = Utilitarios.ColorTextoAtenuado

        _toolStrip.Items.Add(_btnExportarPdf)
        _toolStrip.Items.Add(New ToolStripSeparator())
        _toolStrip.Items.Add(_btnVistaPrevia)
        _toolStrip.Items.Add(_btnImprimir)
        _toolStrip.Items.Add(New ToolStripSeparator())
        _toolStrip.Items.Add(_btnActualizar)
        _toolStrip.Items.Add(_lblEstado)

        _browser = New WebBrowser()
        _browser.Dock = DockStyle.Fill
        _browser.AllowWebBrowserDrop = False
        _browser.IsWebBrowserContextMenuEnabled = True
        _browser.ScriptErrorsSuppressed = True

        Me.Controls.Add(_browser)
        Me.Controls.Add(_toolStrip)
    End Sub

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ActiveViewIndex() As Integer
        Get
            Return _activeViewIndex
        End Get
        Set(ByVal value As Integer)
            _activeViewIndex = value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ReportSource() As Object
        Get
            Return _reportSource
        End Get
        Set(ByVal value As Object)
            _reportSource = value
            RefreshReport()
        End Set
    End Property

    Public Sub RefreshReport()
        Dim rpt As InfOt = ObtenerInformeActual()
        If rpt IsNot Nothing Then
            _browser.DocumentText = rpt.GenerarHtml()
            Dim total As Integer = If(rpt.DataSource IsNot Nothing, rpt.DataSource.Rows.Count, 0)
            _lblEstado.Text = "Registros: " & total.ToString()
        Else
            Dim tempRpt As New InfOt()
            _browser.DocumentText = tempRpt.GenerarHtml()
            _lblEstado.Text = "Sin origen de datos"
        End If
    End Sub

    Private Function ObtenerInformeActual() As InfOt
        If _reportSource Is Nothing Then Return Nothing
        If TypeOf _reportSource Is InfOt Then
            Return DirectCast(_reportSource, InfOt)
        ElseIf TypeOf _reportSource Is DataTable Then
            Dim rpt As New InfOt()
            rpt.SetDataSource(DirectCast(_reportSource, DataTable))
            _reportSource = rpt
            Return rpt
        ElseIf TypeOf _reportSource Is DataSet Then
            Dim rpt As New InfOt()
            rpt.SetDataSource(DirectCast(_reportSource, DataSet))
            _reportSource = rpt
            Return rpt
        End If
        Return Nothing
    End Function

    Private Sub OnExportarPdfClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim rpt As InfOt = ObtenerInformeActual()
        If rpt Is Nothing OrElse rpt.DataSource Is Nothing OrElse rpt.DataSource.Rows.Count = 0 Then
            MessageBox.Show("No hay datos cargados en el informe para exportar.", "Exportar a PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using sfd As New SaveFileDialog()
            sfd.Title = "Guardar Informe en PDF"
            sfd.Filter = "Archivo PDF (*.pdf)|*.pdf"
            sfd.FileName = "Informe_OT_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".pdf"
            If sfd.ShowDialog(Me) = DialogResult.OK Then
                Try
                    rpt.ExportarPDF(sfd.FileName)
                    If MessageBox.Show("Informe PDF generado correctamente en:" & Environment.NewLine & sfd.FileName & Environment.NewLine & Environment.NewLine & "¿Desea abrir el archivo ahora?", "Exportación Exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                        Process.Start(sfd.FileName)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error al exportar a PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub OnVistaPreviaClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim rpt As InfOt = ObtenerInformeActual()
        If rpt Is Nothing Then Return
        Try
            Using pd As PrintDocument = rpt.CrearPrintDocument()
                Using ppd As New PrintPreviewDialog()
                    ppd.Document = pd
                    ppd.Width = 900
                    ppd.Height = 650
                    ppd.StartPosition = FormStartPosition.CenterParent
                    ppd.ShowDialog(Me)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al mostrar la vista previa: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnImprimirClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim rpt As InfOt = ObtenerInformeActual()
        If rpt Is Nothing Then Return
        Try
            Using pd As PrintDocument = rpt.CrearPrintDocument()
                Using dlg As New PrintDialog()
                    dlg.Document = pd
                    dlg.UseEXDialog = True
                    If dlg.ShowDialog(Me) = DialogResult.OK Then
                        pd.Print()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al imprimir: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnActualizarClick(ByVal sender As Object, ByVal e As EventArgs)
        RefreshReport()
    End Sub

End Class
