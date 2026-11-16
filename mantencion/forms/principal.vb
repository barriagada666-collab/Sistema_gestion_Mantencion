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
        If clientCtrl Is Nothing OrElse clientCtrl.ClientSize.Width < 520 OrElse clientCtrl.ClientSize.Height < 340 Then Exit Sub

        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim cardW As Integer = Math.Min(780, clientCtrl.ClientSize.Width - 64)
        Dim cardH As Integer = Math.Min(330, clientCtrl.ClientSize.Height - 48)
        Dim cardX As Integer = (clientCtrl.ClientSize.Width - cardW) \ 2
        Dim cardY As Integer = (clientCtrl.ClientSize.Height - cardH) \ 2
        Dim cardRect As New Rectangle(cardX, cardY, cardW, cardH)

        Using brSombra As New SolidBrush(Color.FromArgb(18, 15, 45, 68))
            g.FillRectangle(brSombra, cardX + 3, cardY + 4, cardW, cardH)
        End Using
        Using brCard As New SolidBrush(Color.White)
            g.FillRectangle(brCard, cardRect)
        End Using
        Using pBorde As New Pen(Color.FromArgb(203, 213, 225), 1)
            g.DrawRectangle(pBorde, cardRect)
        End Using

        Dim padX As Integer = cardX + 28
        Dim curY As Integer = cardY + 22
        Using fKicker As New Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point),
              brKicker As New SolidBrush(Utilitarios.ColorSecundario)
            g.DrawString("ESCRITORIO MDI · 40 FORMULARIOS INTEGRADOS", fKicker, brKicker, padX, curY)
        End Using
        Using fTitulo As New Font("Segoe UI", 14.5F, FontStyle.Bold, GraphicsUnit.Point),
              brTitulo As New SolidBrush(Utilitarios.ColorDeepNavy)
            g.DrawString("Sistema de Gestión Departamento Mantención", fTitulo, brTitulo, padX, curY + 18)
        End Using

        Try
            Dim logo As Image = My.Resources.Resources.cambiaso_logo_nuevo
            If logo IsNot Nothing Then
                Dim logoH As Integer = 36
                Dim logoW As Integer = CInt(logo.Width * (CDbl(logoH) / logo.Height))
                g.DrawImage(logo, New Rectangle(cardX + cardW - 28 - logoW, curY + 4, logoW, logoH))
            End If
        Catch
        End Try

        Dim lineY As Integer = curY + 54
        Using pLinea As New Pen(Utilitarios.ColorPrimario, 2)
            g.DrawLine(pLinea, padX, lineY, cardX + cardW - 28, lineY)
        End Using

        Dim modulos As String(,) = {
            {"Órdenes de Trabajo", "Ingreso, fallas, tiempos, repuestos y cierre (frm_OT)."},
            {"Mant. Preventiva", "Pautas MP, tareas nodo y planificador de ciclos."},
            {"Informes & Gantt", "Rango de fechas obligatorio, PDF vectorial y Excel nativo."},
            {"Estadísticas KPIs", "Rankings por máquina, técnico, falla, turno y drill-down."},
            {"Mantenedores", "Nodos, datos técnicos, personal, turnos, plantas y cargos."},
            {"Seguridad & Auditoría", "Permisos de usuario, auditoría BD y asistente SQL."}
        }

        Dim cols As Integer = 3
        Dim gapX As Integer = 14
        Dim gapY As Integer = 12
        Dim areaW As Integer = cardW - 56
        Dim boxW As Integer = (areaW - (gapX * (cols - 1))) \ cols
        Dim boxH As Integer = Math.Max(68, (cardY + cardH - lineY - 36 - gapY) \ 2)
        Dim startY As Integer = lineY + 16

        Using brBox As New SolidBrush(Color.FromArgb(239, 243, 244)),
              pBox As New Pen(Color.FromArgb(215, 230, 234), 1),
              brStripe As New SolidBrush(Utilitarios.ColorSecundario),
              fModTit As New Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
              fModDesc As New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point),
              brModTit As New SolidBrush(Utilitarios.ColorPrimario),
              brModDesc As New SolidBrush(Color.FromArgb(71, 85, 105))
            For i As Integer = 0 To 5
                Dim c As Integer = i Mod cols
                Dim r As Integer = i \ cols
                Dim bx As Integer = padX + c * (boxW + gapX)
                Dim by As Integer = startY + r * (boxH + gapY)
                Dim boxRect As New Rectangle(bx, by, boxW, boxH)
                g.FillRectangle(brBox, boxRect)
                g.DrawRectangle(pBox, boxRect)
                g.FillRectangle(brStripe, bx, by, 4, boxH)
                g.DrawString(modulos(i, 0), fModTit, brModTit, New RectangleF(bx + 12, by + 10, boxW - 18, 20))
                g.DrawString(modulos(i, 1), fModDesc, brModDesc, New RectangleF(bx + 12, by + 32, boxW - 18, boxH - 38))
            Next
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
        Try
            Using frm As New FrmConfiguracionServidor()
                frm.ShowDialog(Me)
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Configurar Servidor BD", True, Me, False)
        End Try
    End Sub

    Private Sub VerRegistroErroresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerRegistroErroresToolStripMenuItem.Click
        RegistroErrores.AbrirCarpetaLogs()
    End Sub
End Class
