Imports System.Windows.Forms

Public Class principal
    Public sesion As String
    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Cree una nueva instancia del formulario secundario.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Conviértalo en un elemento secundario de este formulario MDI antes de mostrarlo.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Ventana " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: agregue código aquí para abrir el archivo.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: agregue código aquí para guardar el contenido actual del formulario en un archivo.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Utilice My.Computer.Clipboard.GetText() o My.Computer.Clipboard.GetData para recuperar la información del Portapapeles.
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Cierre todos los formularios secundarios del principal.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub IngresarOtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarOtToolStripMenuItem.Click
        frm_OT.MdiParent = Me
        frm_OT.Show()
    End Sub

    Private Sub principal_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter

    End Sub

    Private Sub principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PersonalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonalToolStripMenuItem.Click
        FrmPersonal.MdiParent = Me
        FrmPersonal.Show()
    End Sub

    Private Sub PlantaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlantaToolStripMenuItem.Click
        FrmPlantas.MdiParent = Me
        FrmPlantas.Show()
    End Sub

    Private Sub SeccionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeccionesToolStripMenuItem.Click
        FrmSeccion.MdiParent = Me
        FrmSeccion.Show()
    End Sub

    Private Sub TareasMaquinaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub IngresarMpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarMpToolStripMenuItem.Click
        FrmMp.MdiParent = Me
        FrmMp.Show()
    End Sub

    Private Sub AdministraciónUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministraciónUsuariosToolStripMenuItem.Click
        FrmAdminUsuarios.MdiParent = Me
        FrmAdminUsuarios.Show()
    End Sub

    Private Sub InformeMantenciónPreventivaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeMantenciónPreventivaToolStripMenuItem.Click
        
    End Sub

    Private Sub Bw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)

    End Sub

    Private Sub Bw1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)

    End Sub

    Private Sub NodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NodosToolStripMenuItem.Click
        
    End Sub

    Private Sub InformeOrdenesDeTrabajoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeOrdenesDeTrabajoToolStripMenuItem.Click
        FrmInfOT.MdiParent = Me
        FrmInfOT.Show()
    End Sub

    Private Sub TareasMaquinasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TareasMaquinasToolStripMenuItem.Click
        FrmAdminTareasNodo.MdiParent = Me
        FrmAdminTareasNodo.Show()
    End Sub

    Private Sub InformeResumenOrdenDeTrabajoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeResumenOrdenDeTrabajoToolStripMenuItem.Click
        FrmResumenes.MdiParent = Me
        FrmResumenes.Show()
    End Sub

    Private Sub PorMaquinaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorMaquinaToolStripMenuItem.Click
        FrmInfMantPrev.MdiParent = Me
        FrmInfMantPrev.Show()
    End Sub

    Private Sub VariasMaquinasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VariasMaquinasToolStripMenuItem.Click
        FrmInfMantPrevCiclosMaq.MdiParent = Me
        FrmInfMantPrevCiclosMaq.Show()
    End Sub

    Private Sub OrdenesExternasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub OTExternasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub SalirToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub CerrarSesiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSesiónToolStripMenuItem.Click
        Login.Show()
        Me.Close()
    End Sub

    Private Sub AuditoriaDeOperacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuditoriaDeOperacionesToolStripMenuItem.Click
        FrmAdminAuditoria.MdiParent = Me
        FrmAdminAuditoria.Show()
    End Sub

    Private Sub CargosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargosToolStripMenuItem.Click
        FrmCargo.MdiParent = Me
        FrmCargo.Show()
    End Sub

    Private Sub ProgramaciónDeTurnosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmCalendarioTurno.MdiParent = Me
        FrmCalendarioTurno.Show()
    End Sub

    Private Sub CAMBIODETAREASMPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MantenedorItemsMaquinasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenedorItemsMaquinasToolStripMenuItem.Click
        FrmAdminNodos.MdiParent = Me
        FrmAdminNodos.Show()
    End Sub

    Private Sub GestiónDatosTécnicosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GestiónDatosTécnicosToolStripMenuItem.Click
        FrmDatosTecnicos.MdiParent = Me
        FrmDatosTecnicos.Show()
    End Sub

    Private Sub AsocDatosTécnicosItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsocDatosTécnicosItemsToolStripMenuItem.Click
        FrmDatosTecnicosNodo.MdiParent = Me
        FrmDatosTecnicosNodo.Show()
    End Sub
End Class
