<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(principal))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.OrdenesDeTrabajoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IngresarOtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MantPreventivaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IngresarMpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TareasMaquinasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InformesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InformeOrdenesDeTrabajoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InformeResumenOrdenDeTrabajoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InformeMantenciónPreventivaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PorMaquinaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VariasMaquinasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MantenedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MantenedorItemsMaquinasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GestiónDatosTécnicosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AsocDatosTécnicosItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PersonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PlantaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SeccionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CargosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AdministraciónUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AuditoriaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AuditoriaDeOperacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparatorMantenedor = New System.Windows.Forms.ToolStripSeparator
        Me.ConfigurarServidorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VerRegistroErroresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CerrarSesiónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.lblStatusStrip = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblUsuario = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.Color.FromArgb(15, 45, 68)
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OrdenesDeTrabajoToolStripMenuItem, Me.MantPreventivaToolStripMenuItem, Me.InformesToolStripMenuItem, Me.MantenedorToolStripMenuItem, Me.AuditoriaToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(6, 4, 0, 4)
        Me.MenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip.Size = New System.Drawing.Size(1027, 32)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'OrdenesDeTrabajoToolStripMenuItem
        '
        Me.OrdenesDeTrabajoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IngresarOtToolStripMenuItem})
        Me.OrdenesDeTrabajoToolStripMenuItem.Name = "OrdenesDeTrabajoToolStripMenuItem"
        Me.OrdenesDeTrabajoToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.OrdenesDeTrabajoToolStripMenuItem.Text = "Órdenes de Trabajo"
        '
        'IngresarOtToolStripMenuItem
        '
        Me.IngresarOtToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.notas
        Me.IngresarOtToolStripMenuItem.Name = "IngresarOtToolStripMenuItem"
        Me.IngresarOtToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.IngresarOtToolStripMenuItem.Size = New System.Drawing.Size(270, 22)
        Me.IngresarOtToolStripMenuItem.Text = "Gestión Órdenes de Trabajo"
        '
        'MantPreventivaToolStripMenuItem
        '
        Me.MantPreventivaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IngresarMpToolStripMenuItem, Me.TareasMaquinasToolStripMenuItem})
        Me.MantPreventivaToolStripMenuItem.Name = "MantPreventivaToolStripMenuItem"
        Me.MantPreventivaToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.MantPreventivaToolStripMenuItem.Text = "Mant. Preventiva"
        '
        'IngresarMpToolStripMenuItem
        '
        Me.IngresarMpToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.checklist
        Me.IngresarMpToolStripMenuItem.Name = "IngresarMpToolStripMenuItem"
        Me.IngresarMpToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.IngresarMpToolStripMenuItem.Size = New System.Drawing.Size(290, 22)
        Me.IngresarMpToolStripMenuItem.Text = "Gestión Mant. Preventivas"
        '
        'TareasMaquinasToolStripMenuItem
        '
        Me.TareasMaquinasToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources._15tareas
        Me.TareasMaquinasToolStripMenuItem.Name = "TareasMaquinasToolStripMenuItem"
        Me.TareasMaquinasToolStripMenuItem.Size = New System.Drawing.Size(290, 22)
        Me.TareasMaquinasToolStripMenuItem.Text = "Gestión Tareas Ítem / Máquinas"
        '
        'InformesToolStripMenuItem
        '
        Me.InformesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InformeOrdenesDeTrabajoToolStripMenuItem, Me.InformeResumenOrdenDeTrabajoToolStripMenuItem, Me.InformeMantenciónPreventivaToolStripMenuItem})
        Me.InformesToolStripMenuItem.Name = "InformesToolStripMenuItem"
        Me.InformesToolStripMenuItem.Size = New System.Drawing.Size(80, 22)
        Me.InformesToolStripMenuItem.Text = "Informes"
        '
        'InformeOrdenesDeTrabajoToolStripMenuItem
        '
        Me.InformeOrdenesDeTrabajoToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.informe
        Me.InformeOrdenesDeTrabajoToolStripMenuItem.Name = "InformeOrdenesDeTrabajoToolStripMenuItem"
        Me.InformeOrdenesDeTrabajoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.InformeOrdenesDeTrabajoToolStripMenuItem.Size = New System.Drawing.Size(320, 22)
        Me.InformeOrdenesDeTrabajoToolStripMenuItem.Text = "Informe Órdenes de Trabajo"
        '
        'InformeResumenOrdenDeTrabajoToolStripMenuItem
        '
        Me.InformeResumenOrdenDeTrabajoToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.informe
        Me.InformeResumenOrdenDeTrabajoToolStripMenuItem.Name = "InformeResumenOrdenDeTrabajoToolStripMenuItem"
        Me.InformeResumenOrdenDeTrabajoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.InformeResumenOrdenDeTrabajoToolStripMenuItem.Size = New System.Drawing.Size(320, 22)
        Me.InformeResumenOrdenDeTrabajoToolStripMenuItem.Text = "Informe Estadístico Orden de Trabajo"
        '
        'InformeMantenciónPreventivaToolStripMenuItem
        '
        Me.InformeMantenciónPreventivaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PorMaquinaToolStripMenuItem, Me.VariasMaquinasToolStripMenuItem})
        Me.InformeMantenciónPreventivaToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.informe
        Me.InformeMantenciónPreventivaToolStripMenuItem.Name = "InformeMantenciónPreventivaToolStripMenuItem"
        Me.InformeMantenciónPreventivaToolStripMenuItem.Size = New System.Drawing.Size(320, 22)
        Me.InformeMantenciónPreventivaToolStripMenuItem.Text = "Informe Mantención Preventiva"
        '
        'PorMaquinaToolStripMenuItem
        '
        Me.PorMaquinaToolStripMenuItem.Name = "PorMaquinaToolStripMenuItem"
        Me.PorMaquinaToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.PorMaquinaToolStripMenuItem.Text = "Máquina Individual"
        '
        'VariasMaquinasToolStripMenuItem
        '
        Me.VariasMaquinasToolStripMenuItem.Name = "VariasMaquinasToolStripMenuItem"
        Me.VariasMaquinasToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.VariasMaquinasToolStripMenuItem.Text = "Varias Máquinas"
        '
        'MantenedorToolStripMenuItem
        '
        Me.MantenedorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NodosToolStripMenuItem, Me.PersonalToolStripMenuItem, Me.ItemsToolStripMenuItem, Me.UsuariosToolStripMenuItem, Me.ToolStripSeparatorMantenedor, Me.ConfigurarServidorToolStripMenuItem})
        Me.MantenedorToolStripMenuItem.Name = "MantenedorToolStripMenuItem"
        Me.MantenedorToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.MantenedorToolStripMenuItem.Text = "Mantenedores"
        '
        'ToolStripSeparatorMantenedor
        '
        Me.ToolStripSeparatorMantenedor.Name = "ToolStripSeparatorMantenedor"
        Me.ToolStripSeparatorMantenedor.Size = New System.Drawing.Size(257, 6)
        '
        'ConfigurarServidorToolStripMenuItem
        '
        Me.ConfigurarServidorToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.operations
        Me.ConfigurarServidorToolStripMenuItem.Name = "ConfigurarServidorToolStripMenuItem"
        Me.ConfigurarServidorToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.ConfigurarServidorToolStripMenuItem.Text = "Configurar Servidor BD..."
        '
        'NodosToolStripMenuItem
        '
        Me.NodosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MantenedorItemsMaquinasToolStripMenuItem, Me.GestiónDatosTécnicosToolStripMenuItem, Me.AsocDatosTécnicosItemsToolStripMenuItem})
        Me.NodosToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.icono_dock_bol_museo
        Me.NodosToolStripMenuItem.Name = "NodosToolStripMenuItem"
        Me.NodosToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.NodosToolStripMenuItem.Text = "Nodos / Máquinas"
        '
        'MantenedorItemsMaquinasToolStripMenuItem
        '
        Me.MantenedorItemsMaquinasToolStripMenuItem.Name = "MantenedorItemsMaquinasToolStripMenuItem"
        Me.MantenedorItemsMaquinasToolStripMenuItem.Size = New System.Drawing.Size(280, 22)
        Me.MantenedorItemsMaquinasToolStripMenuItem.Text = "Mantenedor Nodos / Máquinas"
        '
        'GestiónDatosTécnicosToolStripMenuItem
        '
        Me.GestiónDatosTécnicosToolStripMenuItem.Name = "GestiónDatosTécnicosToolStripMenuItem"
        Me.GestiónDatosTécnicosToolStripMenuItem.Size = New System.Drawing.Size(280, 22)
        Me.GestiónDatosTécnicosToolStripMenuItem.Text = "Gestión Datos Técnicos"
        '
        'AsocDatosTécnicosItemsToolStripMenuItem
        '
        Me.AsocDatosTécnicosItemsToolStripMenuItem.Name = "AsocDatosTécnicosItemsToolStripMenuItem"
        Me.AsocDatosTécnicosItemsToolStripMenuItem.Size = New System.Drawing.Size(280, 22)
        Me.AsocDatosTécnicosItemsToolStripMenuItem.Text = "Asociar Datos Técnicos / Nodos"
        '
        'PersonalToolStripMenuItem
        '
        Me.PersonalToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.personal_icono_5904_96
        Me.PersonalToolStripMenuItem.Name = "PersonalToolStripMenuItem"
        Me.PersonalToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.PersonalToolStripMenuItem.Text = "Personal"
        '
        'ItemsToolStripMenuItem
        '
        Me.ItemsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlantaToolStripMenuItem, Me.SeccionesToolStripMenuItem, Me.CargosToolStripMenuItem})
        Me.ItemsToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.items
        Me.ItemsToolStripMenuItem.Name = "ItemsToolStripMenuItem"
        Me.ItemsToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.ItemsToolStripMenuItem.Text = "Ítems"
        '
        'PlantaToolStripMenuItem
        '
        Me.PlantaToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.icono_fabrica_ezg_2
        Me.PlantaToolStripMenuItem.Name = "PlantaToolStripMenuItem"
        Me.PlantaToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.PlantaToolStripMenuItem.Text = "Planta"
        '
        'SeccionesToolStripMenuItem
        '
        Me.SeccionesToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.icono_seccion
        Me.SeccionesToolStripMenuItem.Name = "SeccionesToolStripMenuItem"
        Me.SeccionesToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.SeccionesToolStripMenuItem.Text = "Secciones"
        '
        'CargosToolStripMenuItem
        '
        Me.CargosToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.puesto_trabajo
        Me.CargosToolStripMenuItem.Name = "CargosToolStripMenuItem"
        Me.CargosToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.CargosToolStripMenuItem.Text = "Cargos"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdministraciónUsuariosToolStripMenuItem})
        Me.UsuariosToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.icono_usuarios
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.UsuariosToolStripMenuItem.Text = "Usuarios"
        '
        'AdministraciónUsuariosToolStripMenuItem
        '
        Me.AdministraciónUsuariosToolStripMenuItem.Name = "AdministraciónUsuariosToolStripMenuItem"
        Me.AdministraciónUsuariosToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.AdministraciónUsuariosToolStripMenuItem.Text = "Administración Usuarios"
        '
        'AuditoriaToolStripMenuItem
        '
        Me.AuditoriaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AuditoriaDeOperacionesToolStripMenuItem})
        Me.AuditoriaToolStripMenuItem.Name = "AuditoriaToolStripMenuItem"
        Me.AuditoriaToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.AuditoriaToolStripMenuItem.Text = "Control de Eventos"
        '
        'AuditoriaDeOperacionesToolStripMenuItem
        '
        Me.AuditoriaDeOperacionesToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.operations
        Me.AuditoriaDeOperacionesToolStripMenuItem.Name = "AuditoriaDeOperacionesToolStripMenuItem"
        Me.AuditoriaDeOperacionesToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.AuditoriaDeOperacionesToolStripMenuItem.Text = "Auditoría de Operaciones"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CerrarSesiónToolStripMenuItem, Me.SalirToolStripMenuItem1})
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(50, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'CerrarSesiónToolStripMenuItem
        '
        Me.CerrarSesiónToolStripMenuItem.Image = Global.mantencion.My.Resources.Resources.cerrar_sesion
        Me.CerrarSesiónToolStripMenuItem.Name = "CerrarSesiónToolStripMenuItem"
        Me.CerrarSesiónToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.CerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión"
        '
        'SalirToolStripMenuItem1
        '
        Me.SalirToolStripMenuItem1.Image = Global.mantencion.My.Resources.Resources.salir
        Me.SalirToolStripMenuItem1.Name = "SalirToolStripMenuItem1"
        Me.SalirToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem1.Size = New System.Drawing.Size(190, 22)
        Me.SalirToolStripMenuItem1.Text = "Salir"
        '
        'StatusStrip
        '
        Me.StatusStrip.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatusStrip, Me.StatusLabel2, Me.lblUsuario})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 463)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1027, 23)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'lblStatusStrip
        '
        Me.lblStatusStrip.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusStrip.ForeColor = System.Drawing.Color.White
        Me.lblStatusStrip.Name = "lblStatusStrip"
        Me.lblStatusStrip.Size = New System.Drawing.Size(105, 18)
        Me.lblStatusStrip.Text = "Sesión activa:"
        '
        'StatusLabel2
        '
        Me.StatusLabel2.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusLabel2.ForeColor = System.Drawing.Color.White
        Me.StatusLabel2.Name = "StatusLabel2"
        Me.StatusLabel2.Size = New System.Drawing.Size(0, 18)
        Me.StatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUsuario
        '
        Me.lblUsuario.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.ForeColor = System.Drawing.Color.White
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(55, 18)
        Me.lblUsuario.Text = "Usuario"
        '
        'principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(221, 231, 232)
        Me.ClientSize = New System.Drawing.Size(1027, 486)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú Principal — Sistema de Gestión de Mantención"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblStatusStrip As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents OrdenesDeTrabajoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantPreventivaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NodosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresarOtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlantaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeccionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresarMpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TareasMaquinasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdministraciónUsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformeMantenciónPreventivaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformeOrdenesDeTrabajoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformeResumenOrdenDeTrabajoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PorMaquinaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VariasMaquinasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarSesiónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PersonalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AuditoriaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AuditoriaDeOperacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenedorItemsMaquinasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GestiónDatosTécnicosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsocDatosTécnicosItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparatorMantenedor As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ConfigurarServidorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerRegistroErroresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
