Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class principal
    Public Shared CambiandoAmbiente As Boolean = False

    Private Const WM_SETREDRAW As Integer = &HB

    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    Private Function ObtenerMdiClient() As MdiClient
        For Each c As Control In Me.Controls
            If TypeOf c Is MdiClient Then Return DirectCast(c, MdiClient)
        Next
        Return Nothing
    End Function

    Public Sub AbrirAmbienteMdi(ByVal formularioDestino As Form)
        If formularioDestino Is Nothing OrElse formularioDestino.IsDisposed Then Exit Sub

        Dim clientCtrl As MdiClient = ObtenerMdiClient()

        If Me.ActiveMdiChild Is formularioDestino AndAlso formularioDestino.Visible Then
            If clientCtrl IsNot Nothing AndAlso clientCtrl.ClientSize.Width > 100 Then
                formularioDestino.Bounds = New Rectangle(0, 0, clientCtrl.ClientSize.Width, clientCtrl.ClientSize.Height)
            End If
            If formularioDestino.WindowState <> FormWindowState.Maximized Then
                formularioDestino.WindowState = FormWindowState.Maximized
            End If
            formularioDestino.BringToFront()
            formularioDestino.Activate()
            Exit Sub
        End If

        Dim clientHwnd As IntPtr = If(clientCtrl IsNot Nothing, clientCtrl.Handle, Me.Handle)

        CambiandoAmbiente = True
        Try
            ' 1. Suspender redibujado a nivel de ventana Win32 (evita parpadeos de fondo o repintados parciales)
            SendMessage(clientHwnd, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero)
            Me.SuspendLayout()

            ' 2. Cerrar ventanas flotantes auxiliares de ambientes anteriores
            Dim abiertos As New List(Of Form)()
            For Each frm As Form In Application.OpenForms
                abiertos.Add(frm)
            Next
            For Each frm As Form In abiertos
                If frm IsNot Nothing AndAlso Not frm.IsDisposed AndAlso frm IsNot Me AndAlso frm IsNot formularioDestino AndAlso Not frm.IsMdiChild Then
                    If Not TypeOf frm Is Login Then
                        frm.Close()
                    End If
                End If
            Next

            ' 3. Ocultar formularios hijos anteriores antes de activar el nuevo (Hide-before-Show atómico bajo WM_SETREDRAW)
            For Each child As Form In Me.MdiChildren
                If child IsNot formularioDestino AndAlso child.Visible Then
                    child.Hide()
                End If
            Next

            ' 4. Aplicar tema antes de mostrar y desplegar el formulario destino maximizado
            Utilitarios.AplicarTemaModerno(formularioDestino)

            If formularioDestino.MdiParent IsNot Me Then
                formularioDestino.MdiParent = Me
            End If

            If clientCtrl IsNot Nothing AndAlso clientCtrl.ClientSize.Width > 100 Then
                formularioDestino.WindowState = FormWindowState.Normal
                formularioDestino.StartPosition = FormStartPosition.Manual
                formularioDestino.Bounds = New Rectangle(0, 0, clientCtrl.ClientSize.Width, clientCtrl.ClientSize.Height)
            End If

            If Not formularioDestino.Visible Then
                formularioDestino.Show()
            End If

            formularioDestino.WindowState = FormWindowState.Maximized
            If clientCtrl IsNot Nothing AndAlso clientCtrl.ClientSize.Width > 100 Then
                formularioDestino.Bounds = New Rectangle(0, 0, clientCtrl.ClientSize.Width, clientCtrl.ClientSize.Height)
            End If

            formularioDestino.BringToFront()
            formularioDestino.Activate()
        Finally
            Me.ResumeLayout(True)
            ' 5. Reanudar redibujado Win32 atómicamente y refrescar el área MDI limpia de una sola vez
            SendMessage(clientHwnd, WM_SETREDRAW, New IntPtr(1), IntPtr.Zero)
            If clientCtrl IsNot Nothing Then
                clientCtrl.Invalidate()
                clientCtrl.Update()
            Else
                Me.Refresh()
            End If
            If formularioDestino IsNot Nothing AndAlso Not formularioDestino.IsDisposed Then
                formularioDestino.PerformLayout()
                formularioDestino.Invalidate(True)
                formularioDestino.Update()
            End If
            CambiandoAmbiente = False

            ' 6. Optimización de memoria RAM desacoplada del hilo de renderizado (no congela la transición de UI)
            If Not Me.IsDisposed AndAlso Me.IsHandleCreated Then
                Me.BeginInvoke(New Action(AddressOf Utilitarios.OptimizarMemoria))
            End If
        End Try
    End Sub

    Private Sub IngresarOtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarOtToolStripMenuItem.Click
        AbrirAmbienteMdi(frm_OT)
    End Sub

    Private Sub principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Conexion.PrecalentarPool()
        Try
            Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        Catch
        End Try
        ConfigurarServidorToolStripMenuItem.ForeColor = Utilitarios.ColorAcento
        Dim clientCtrl As MdiClient = ObtenerMdiClient()
        If clientCtrl IsNot Nothing Then
            clientCtrl.BackColor = Utilitarios.ColorMdiFondo
            Utilitarios.HabilitarDobleBuffer(clientCtrl)
            RemoveHandler clientCtrl.Paint, AddressOf DibujarBienvenidaMdi
            RemoveHandler clientCtrl.Resize, AddressOf AlRedimensionarMdiClient
            AddHandler clientCtrl.Paint, AddressOf DibujarBienvenidaMdi
            AddHandler clientCtrl.Resize, AddressOf AlRedimensionarMdiClient
        End If
        Utilitarios.RegistrarTemaGlobal()
        Utilitarios.AplicarTemaModerno(Me)
        ActualizarIndicadorServidor()
        ActualizarIndicadorVersion()
        ActualizarPermisosMenuAdministrador()
    End Sub

    Public Sub ActualizarIndicadorVersion()
        If lblVersionEstado Is Nothing Then Exit Sub
        Dim info = Utilitarios.ObtenerInformacionInstalacion()
        lblVersionEstado.Text = "v" & info.Version
        lblVersionEstado.ToolTipText = String.Format("Versión {0} LTS · Instalado: {1} (clic para ver Acerca de)", info.Version, info.FechaHoraInstalacion)
    End Sub

    Private Sub AbrirAcercaDe()
        Try
            Using frm As New FrmAcercaDe()
                frm.ShowDialog(Me)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Acerca de", True, Me, False)
        End Try
    End Sub

    Public Sub ActualizarPermisosMenuAdministrador()
        Dim esAdmin As Boolean = Usuario.EsAdministrador
        If ConfigurarServidorToolStripMenuItem IsNot Nothing Then
            ConfigurarServidorToolStripMenuItem.Visible = esAdmin
            ConfigurarServidorToolStripMenuItem.Enabled = esAdmin
        End If
        If ToolStripSeparatorMantenedor IsNot Nothing Then
            ToolStripSeparatorMantenedor.Visible = esAdmin
        End If
    End Sub

    Public Sub ActualizarIndicadorServidor()
        If lblServidorEstado Is Nothing Then Exit Sub
        Try
            Dim estCache = Conexion.ObtenerEstadoConexionActual(False)
            lblServidorEstado.Image = Utilitarios.ObtenerIconoFarolEstado(estCache.Conectado, 14)
            lblServidorEstado.Text = Conexion.FormatearEstadoConexion(estCache.Servidor, estCache.BaseDatos, estCache.Conectado)
        Catch
        End Try

        System.Threading.ThreadPool.QueueUserWorkItem(Sub()
                                                         Try
                                                             Dim est = Conexion.ObtenerEstadoConexionActual(True)
                                                             Me.BeginInvoke(New Action(Sub()
                                                                                           If Me.IsDisposed OrElse lblServidorEstado Is Nothing Then Exit Sub
                                                                                           lblServidorEstado.Image = Utilitarios.ObtenerIconoFarolEstado(est.Conectado, 14)
                                                                                           lblServidorEstado.Text = Conexion.FormatearEstadoConexion(est.Servidor, est.BaseDatos, est.Conectado)
                                                                                       End Sub))
                                                         Catch
                                                         End Try
                                                     End Sub)
    End Sub

    Private Sub AlRedimensionarMdiClient(ByVal sender As Object, ByVal e As EventArgs)
        Dim clientCtrl As MdiClient = TryCast(sender, MdiClient)
        If clientCtrl IsNot Nothing Then clientCtrl.Invalidate()
    End Sub

    Private Sub DibujarBienvenidaMdi(ByVal sender As Object, ByVal e As PaintEventArgs)
        For Each child As Form In Me.MdiChildren
            If child IsNot Nothing AndAlso Not child.IsDisposed AndAlso child.Visible Then Exit Sub
        Next

        Dim clientCtrl As MdiClient = TryCast(sender, MdiClient)
        If clientCtrl Is Nothing OrElse clientCtrl.ClientSize.Width < 360 OrElse clientCtrl.ClientSize.Height < 220 Then Exit Sub

        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim logo As Image = Nothing
        Try
            logo = My.Resources.Resources.cambiaso_logo_nuevo
        Catch
        End Try

        Dim titulo As String = "Sistema de Gestión Departamento Mantención"
        Dim anchoMax As Integer = Math.Max(300, clientCtrl.ClientSize.Width - 64)

        Using fTitulo As New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point),
              sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near},
              brTitulo As New SolidBrush(Utilitarios.ColorDeepNavy)

            Dim logoH As Integer = 96
            Dim logoW As Integer = If(logo IsNot Nothing AndAlso logo.Height > 0, CInt(logo.Width * (CDbl(logoH) / logo.Height)), 0)
            Dim gapLogoTitulo As Integer = 18
            Dim tamTitulo As SizeF = g.MeasureString(titulo, fTitulo, anchoMax, sf)

            Dim totalH As Integer = If(logoW > 0, logoH + gapLogoTitulo, 0) + CInt(Math.Ceiling(tamTitulo.Height))
            Dim startY As Integer = Math.Max(24, (clientCtrl.ClientSize.Height - totalH) \ 2)

            If logo IsNot Nothing AndAlso logoW > 0 Then
                Dim logoX As Integer = (clientCtrl.ClientSize.Width - logoW) \ 2
                g.DrawImage(logo, New Rectangle(logoX, startY, logoW, logoH))
                startY += logoH + gapLogoTitulo
            End If

            Dim rectTitulo As New RectangleF(32, startY, anchoMax, tamTitulo.Height + 6)
            g.DrawString(titulo, fTitulo, brTitulo, rectTitulo, sf)
        End Using
    End Sub

    Private Sub principal_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate
        If CambiandoAmbiente Then Exit Sub
        If Me.ActiveMdiChild IsNot Nothing Then
            Dim clientCtrl As MdiClient = ObtenerMdiClient()
            If clientCtrl IsNot Nothing AndAlso clientCtrl.ClientSize.Width > 100 Then
                Me.ActiveMdiChild.Bounds = New Rectangle(0, 0, clientCtrl.ClientSize.Width, clientCtrl.ClientSize.Height)
            End If
            If Me.ActiveMdiChild.WindowState <> FormWindowState.Maximized Then
                Me.ActiveMdiChild.WindowState = FormWindowState.Maximized
            End If
            Utilitarios.AplicarTemaModerno(Me.ActiveMdiChild)
        End If
    End Sub

    Private Sub principal_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.ActiveMdiChild IsNot Nothing AndAlso Not CambiandoAmbiente Then
            Dim clientCtrl As MdiClient = ObtenerMdiClient()
            If clientCtrl IsNot Nothing AndAlso clientCtrl.ClientSize.Width > 100 Then
                Me.ActiveMdiChild.Bounds = New Rectangle(0, 0, clientCtrl.ClientSize.Width, clientCtrl.ClientSize.Height)
            End If
            If Me.ActiveMdiChild.WindowState <> FormWindowState.Maximized Then
                Me.ActiveMdiChild.WindowState = FormWindowState.Maximized
            End If
        End If
    End Sub

    Private Sub PersonalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonalToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmPersonal)
    End Sub

    Private Sub PlantaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlantaToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmPlantas)
    End Sub

    Private Sub SeccionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeccionesToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmSeccion)
    End Sub

    Private Sub IngresarMpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarMpToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmMp)
    End Sub

    Private Sub AdministraciónUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministraciónUsuariosToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmAdminUsuarios)
    End Sub

    Private Sub InformeOrdenesDeTrabajoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeOrdenesDeTrabajoToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmInfOT)
    End Sub

    Private Sub TareasMaquinasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TareasMaquinasToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmAdminTareasNodo)
    End Sub

    Private Sub InformeResumenOrdenDeTrabajoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeResumenOrdenDeTrabajoToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmResumenes)
    End Sub

    Private Sub PorMaquinaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorMaquinaToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmInfMantPrev)
    End Sub

    Private Sub VariasMaquinasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VariasMaquinasToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmInfMantPrevCiclosMaq)
    End Sub

    Private Sub SalirToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub CerrarSesiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSesiónToolStripMenuItem.Click
        For Each child As Form In Me.MdiChildren.ToArray()
            Try
                child.Close()
            Catch
            End Try
        Next
        ' Cerrar cualquier ventana flotante auxiliar abierta durante la sesión (p. ej. buscadores/detalles)
        For Each frm As Form In Application.OpenForms.Cast(Of Form)().ToArray()
            If frm IsNot Me AndAlso Not (TypeOf frm Is Login) AndAlso Not frm.IsDisposed Then
                Try
                    frm.Close()
                Catch
                End Try
            End If
        Next
        Usuario.LimpiarSesion()
        OT.InvalidarCachePersonal()
        Nodo.InvalidarCacheNodos()
        FrmResumenes.InvalidarCacheJerarquia()
        Conexion.InvalidarCacheCatalogos()
        Login.Show()
        Me.Close()
    End Sub

    Private Sub AuditoriaDeOperacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuditoriaDeOperacionesToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmAdminAuditoria)
    End Sub

    Private Sub CargosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargosToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmCargo)
    End Sub

    Private Sub MantenedorItemsMaquinasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenedorItemsMaquinasToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmAdminNodos)
    End Sub

    Private Sub GestiónDatosTécnicosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GestiónDatosTécnicosToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmDatosTecnicos)
    End Sub

    Private Sub AsocDatosTécnicosItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsocDatosTécnicosItemsToolStripMenuItem.Click
        AbrirAmbienteMdi(FrmDatosTecnicosNodo)
    End Sub

    Private Sub ConfigurarServidorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigurarServidorToolStripMenuItem.Click
        If Not Usuario.EsAdministrador Then
            MessageBox.Show("Solo los usuarios con perfil Administrador pueden configurar el servidor de base de datos.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ActualizarPermisosMenuAdministrador()
            Return
        End If
        Try
            Using frm As New FrmConfiguracionServidor()
                frm.ShowDialog(Me)
            End Using
            ActualizarIndicadorServidor()
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Configurar Servidor BD", True, Me, False)
        End Try
    End Sub

    Private Sub VerRegistroErroresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerRegistroErroresToolStripMenuItem.Click
        RegistroErrores.AbrirCarpetaLogs()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AbrirAcercaDe()
    End Sub

    Private Sub lblVersionEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblVersionEstado.Click
        AbrirAcercaDe()
    End Sub
End Class
