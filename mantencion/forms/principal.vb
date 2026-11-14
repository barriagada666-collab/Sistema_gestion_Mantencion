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

            ' 4. Configurar y desplegar el nuevo formulario destino maximizado ocupando toda el área MDI
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
            Utilitarios.AplicarTemaModerno(formularioDestino)
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
            formularioDestino.PerformLayout()
            formularioDestino.Invalidate(True)
            formularioDestino.Update()
            CambiandoAmbiente = False

            ' 6. Optimización de memoria RAM desacoplada del hilo de renderizado (no congela la transición de UI)
            Me.BeginInvoke(New Action(AddressOf Utilitarios.OptimizarMemoria))
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
        Try
            If Me.BackgroundImage IsNot Nothing Then
                Dim screenBounds As Rectangle = Screen.PrimaryScreen.Bounds
                Dim bmpOpt As New Bitmap(screenBounds.Width, screenBounds.Height, Imaging.PixelFormat.Format32bppPArgb)
                Using g As Graphics = Graphics.FromImage(bmpOpt)
                    g.InterpolationMode = Drawing2D.InterpolationMode.Bilinear
                    g.DrawImage(Me.BackgroundImage, 0, 0, screenBounds.Width, screenBounds.Height)
                End Using
                Me.BackgroundImageLayout = ImageLayout.None
                Me.BackgroundImage = bmpOpt
            End If
        Catch
        End Try
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is MdiClient Then
                ctrl.BackColor = Utilitarios.ColorFondoForm
                Utilitarios.HabilitarDobleBuffer(ctrl)
            End If
        Next
        Utilitarios.RegistrarTemaGlobal()
        Utilitarios.AplicarTemaModerno(Me)
        Try
            Me.MenuStrip.Renderer = New MenuCorporativoRenderer()
            Me.StatusStrip.Renderer = New MenuCorporativoRenderer()
        Catch
        End Try
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
        Using frm As New FrmConfiguracionServidor()
            frm.ShowDialog(Me)
        End Using
    End Sub
End Class
