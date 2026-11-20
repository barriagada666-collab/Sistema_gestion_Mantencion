Imports System.Runtime.InteropServices

Public Class FrmAcercaDe

    Private Sub FrmAcercaDe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Try
            Try
                Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath)
            Catch
            End Try

            Utilitarios.AplicarTemaModerno(Me)

            ' Reafirmar cabecera corporativa oscura y jerarquía tipográfica tras el tema general
            pnlHeaderAcerca.BackColor = Utilitarios.ColorDeepNavy
            pnlLogoAcerca.BackColor = Color.White
            lblAppTitulo.BackColor = Utilitarios.ColorDeepNavy
            lblAppTitulo.ForeColor = Color.White
            lblAppTitulo.Font = New Font("Segoe UI", 13.5!, FontStyle.Bold)
            lblEmpresaAcerca.BackColor = Utilitarios.ColorDeepNavy
            lblEmpresaAcerca.ForeColor = Utilitarios.ColorAcento
            lblEmpresaAcerca.Font = New Font("Segoe UI", 9.75!, FontStyle.Regular)

            pnlCardDetalle.BackColor = Color.White
            For Each ctl As Control In pnlCardDetalle.Controls
                If TypeOf ctl Is Label Then ctl.BackColor = Color.White
            Next
            lblCopyrightAcerca.BackColor = Color.Transparent
            lblTitVersion.ForeColor = Utilitarios.ColorTextoAtenuado
            lblTitVersion.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
            lblValorVersion.ForeColor = Utilitarios.ColorPrimario
            lblValorVersion.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)

            lblTitInstalacion.ForeColor = Utilitarios.ColorTextoAtenuado
            lblTitInstalacion.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
            lblValorFechaInstalacion.ForeColor = Utilitarios.ColorDeepNavy
            lblValorFechaInstalacion.Font = New Font("Segoe UI", 10.25!, FontStyle.Bold)

            lblTitCompilacion.ForeColor = Utilitarios.ColorTextoAtenuado
            lblTitCompilacion.Font = New Font("Segoe UI", 9.25!, FontStyle.Bold)
            lblTitOrigen.ForeColor = Utilitarios.ColorTextoAtenuado
            lblTitOrigen.Font = New Font("Segoe UI", 9.25!, FontStyle.Bold)
            lblTitRuta.ForeColor = Utilitarios.ColorTextoAtenuado
            lblTitRuta.Font = New Font("Segoe UI", 9.25!, FontStyle.Bold)

            lblValorRuta.ForeColor = Utilitarios.ColorTextoAtenuado
            lblCopyrightAcerca.ForeColor = Utilitarios.ColorTextoAtenuado

            CargarDatosAcercaDe()
        Catch ex As Exception
            RegistroErrores.RegistrarError(ex, "Cargar ventana Acerca de")
        End Try
    End Sub

    Public Sub CargarDatosAcercaDe()
        Dim info As Utilitarios.InformacionInstalacion = Utilitarios.ObtenerInformacionInstalacion()
        Dim arq As String = RuntimeInformation.ProcessArchitecture.ToString().ToLowerInvariant()
        lblValorVersion.Text = "v" & info.Version & " LTS"
        lblValorFechaInstalacion.Text = info.FechaHoraInstalacion
        lblValorCompilacion.Text = String.Format("{0} ({1} · {2})", info.VersionArchivo, RuntimeInformation.FrameworkDescription, arq)
        lblValorOrigen.Text = info.OrigenRegistro
        lblValorRuta.Text = info.RutaInstalacion
        toolTipAcerca.SetToolTip(lblValorRuta, info.RutaInstalacion)
        lblCopyrightAcerca.Text = String.Format("Copyright © {0} Cambiaso Hnos. S.A.C. — Todos los derechos reservados", Math.Max(2026, DateTime.Today.Year))
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class
