Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

''' <summary>
''' Tabla de colores profesional y moderna basada en la identidad corporativa de Cambiaso Hnos. S.A.C.
''' Reemplaza los colores planos/grises antiguos por una interfaz ejecutiva y nítida.
''' </summary>
Public Class MenuCorporativoColorTable
    Inherits ProfessionalColorTable

    ' Fondo degradado elegante para la barra superior del Menú Principal
    Public Overrides ReadOnly Property MenuStripGradientBegin As Color
        Get
            Return Color.FromArgb(15, 45, 68) ' Deep Navy (#0F2D44)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuStripGradientEnd As Color
        Get
            Return Color.FromArgb(2, 94, 135) ' Azul Petróleo Corporativo (#025E87)
        End Get
    End Property

    ' Hover de elemento en la barra principal
    Public Overrides ReadOnly Property MenuItemSelectedGradientBegin As Color
        Get
            Return Color.FromArgb(1, 145, 179) ' Azul cian (#0191B3)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelectedGradientEnd As Color
        Get
            Return Color.FromArgb(1, 145, 179)
        End Get
    End Property

    ' Elemento presionado / desplegado
    Public Overrides ReadOnly Property MenuItemPressedGradientBegin As Color
        Get
            Return Color.FromArgb(14, 116, 144) ' Cyan oscuro (#0E7490)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemPressedGradientEnd As Color
        Get
            Return Color.FromArgb(14, 116, 144)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemPressedGradientMiddle As Color
        Get
            Return Color.FromArgb(14, 116, 144)
        End Get
    End Property

    ' Borde de menús desplegables
    Public Overrides ReadOnly Property MenuBorder As Color
        Get
            Return Color.FromArgb(180, 205, 215) ' Borde suave y nítido
        End Get
    End Property

    ' Fondo general de los menús desplegables
    Public Overrides ReadOnly Property ToolStripDropDownBackground As Color
        Get
            Return Color.White
        End Get
    End Property

    ' Margen izquierdo de iconos (reemplaza la franja gris vintage por blanco suave)
    Public Overrides ReadOnly Property ImageMarginGradientBegin As Color
        Get
            Return Color.FromArgb(248, 250, 252)
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientMiddle As Color
        Get
            Return Color.FromArgb(248, 250, 252)
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientEnd As Color
        Get
            Return Color.FromArgb(248, 250, 252)
        End Get
    End Property

    ' Elemento seleccionado dentro del desplegable
    Public Overrides ReadOnly Property MenuItemSelected As Color
        Get
            Return Color.FromArgb(224, 244, 246) ' Turquesa suave (#E0F4F6)
        End Get
    End Property

    ' Separadores modernos
    Public Overrides ReadOnly Property SeparatorDark As Color
        Get
            Return Color.FromArgb(226, 232, 240) ' Línea gris suave (#E2E8F0)
        End Get
    End Property

    Public Overrides ReadOnly Property SeparatorLight As Color
        Get
            Return Color.White
        End Get
    End Property

    ' Barra de estado
    Public Overrides ReadOnly Property StatusStripGradientBegin As Color
        Get
            Return Color.FromArgb(2, 94, 135)
        End Get
    End Property

    Public Overrides ReadOnly Property StatusStripGradientEnd As Color
        Get
            Return Color.FromArgb(15, 45, 68)
        End Get
    End Property

End Class

''' <summary>
''' Renderizador profesional para ToolStrip, MenuStrip y ContextMenuStrip
''' </summary>
Public Class MenuCorporativoRenderer
    Inherits ToolStripProfessionalRenderer

    Private Shared ReadOnly _fontMenuTop As New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
    Private Shared ReadOnly _fontMenuItem As New Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point)
    Private Shared ReadOnly _colorTextoDeshabilitadoTop As Color = Color.FromArgb(148, 178, 194)

    Public Sub New()
        MyBase.New(New MenuCorporativoColorTable())
        Me.RoundedEdges = True
    End Sub

    Protected Overrides Sub OnRenderItemText(ByVal e As ToolStripItemTextRenderEventArgs)
        ' En la barra superior del MenuStrip y en StatusStrip, el texto siempre es blanco de alto contraste
        If TypeOf e.ToolStrip Is MenuStrip AndAlso Not e.Item.IsOnDropDown Then
            If Not e.Item.Enabled Then
                e.TextColor = _colorTextoDeshabilitadoTop
            ElseIf e.Item.Name = "ConfigurarServidorToolStripMenuItem" AndAlso Not e.Item.Selected AndAlso Not e.Item.Pressed Then
                e.TextColor = Utilitarios.ColorAcento
            Else
                e.TextColor = Color.White
            End If
            e.TextFont = _fontMenuTop
        ElseIf TypeOf e.ToolStrip Is StatusStrip Then
            e.TextColor = Color.White
            e.TextFont = _fontMenuItem
        Else
            e.TextColor = If(e.Item.Enabled, Utilitarios.ColorTextoPrincipal, Utilitarios.ColorTextoAtenuado)
            e.TextFont = _fontMenuItem
        End If
        MyBase.OnRenderItemText(e)
    End Sub

    Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As ToolStripItemRenderEventArgs)
        If Not e.Item.Enabled Then Exit Sub

        If TypeOf e.ToolStrip Is MenuStrip AndAlso Not e.Item.IsOnDropDown Then
            ' Botones superiores del Menú Principal
            If e.Item.Selected OrElse e.Item.Pressed Then
                Dim rect As New Rectangle(2, 2, e.Item.Width - 4, e.Item.Height - 4)
                Dim bg As Color = If(e.Item.Pressed, Color.FromArgb(14, 116, 144), Utilitarios.ColorSecundario)
                Using b As New SolidBrush(bg)
                    e.Graphics.FillRectangle(b, rect)
                End Using
                Using p As New Pen(Utilitarios.ColorAcento, 1)
                    e.Graphics.DrawRectangle(p, rect.X, rect.Y, rect.Width - 1, rect.Height - 1)
                End Using
            End If
        Else
            ' Ítems dentro de los desplegables
            If e.Item.Selected Then
                Dim rect As New Rectangle(2, 1, e.Item.Width - 4, e.Item.Height - 2)
                Using b As New SolidBrush(Utilitarios.ColorFondoFoco)
                    e.Graphics.FillRectangle(b, rect)
                End Using
                ' Indicador de acento lateral corporativo
                Using bAcento As New SolidBrush(Utilitarios.ColorSecundario)
                    e.Graphics.FillRectangle(bAcento, 2, 1, 4, e.Item.Height - 2)
                End Using
            Else
                MyBase.OnRenderMenuItemBackground(e)
            End If
        End If
    End Sub

    Protected Overrides Sub OnRenderSeparator(ByVal e As ToolStripSeparatorRenderEventArgs)
        If e.Item.IsOnDropDown Then
            Dim y As Integer = e.Item.Height \ 2
            Using p As New Pen(Color.FromArgb(226, 232, 240), 1)
                e.Graphics.DrawLine(p, 32, y, e.Item.Width - 8, y)
            End Using
        Else
            MyBase.OnRenderSeparator(e)
        End If
    End Sub

End Class
