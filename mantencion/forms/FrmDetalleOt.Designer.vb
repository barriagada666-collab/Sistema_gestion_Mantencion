<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetalleOt
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblNumOt = New System.Windows.Forms.Label
        Me.grpInfoBase = New System.Windows.Forms.Panel
        Me.lblEstadoOt = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblDescBreve = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblSolicitadoPor = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblRecibidoPor = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblSintomaFalla = New System.Windows.Forms.Label
        Me.lblTipoFalla = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblTipoDet = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblDetencion = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblFechaInicio = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblFechaRecepcion = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblDescTecnica = New System.Windows.Forms.Label
        Me.lblFalla = New System.Windows.Forms.Label
        Me.lblCerradoPor = New System.Windows.Forms.Label
        Me.lblDuracion = New System.Windows.Forms.Label
        Me.lblFechaCierre = New System.Windows.Forms.Label
        Me.lblFechaTermino = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TabDetalleInfOt = New System.Windows.Forms.TabControl
        Me.TabPersonal = New System.Windows.Forms.TabPage
        Me.grillaPersonalDetalleOt = New System.Windows.Forms.DataGridView
        Me.TabInsumos = New System.Windows.Forms.TabPage
        Me.grillaInsumosOt = New System.Windows.Forms.DataGridView
        Me.TabOtExterna = New System.Windows.Forms.TabPage
        Me.GrillaOtExternasDetalle = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblItem = New System.Windows.Forms.Label
        Me.grpInfoBase.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabDetalleInfOt.SuspendLayout()
        Me.TabPersonal.SuspendLayout()
        CType(Me.grillaPersonalDetalleOt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabInsumos.SuspendLayout()
        CType(Me.grillaInsumosOt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabOtExterna.SuspendLayout()
        CType(Me.GrillaOtExternasDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "N°OT:"
        '
        'lblNumOt
        '
        Me.lblNumOt.AutoSize = True
        Me.lblNumOt.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumOt.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28)
        Me.lblNumOt.Location = New System.Drawing.Point(58, 12)
        Me.lblNumOt.Name = "lblNumOt"
        Me.lblNumOt.Size = New System.Drawing.Size(50, 16)
        Me.lblNumOt.TabIndex = 1
        Me.lblNumOt.Text = "Label2"
        '
        'grpInfoBase
        '
        Me.grpInfoBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grpInfoBase.Controls.Add(Me.lblEstadoOt)
        Me.grpInfoBase.Controls.Add(Me.Label12)
        Me.grpInfoBase.Controls.Add(Me.lblDescBreve)
        Me.grpInfoBase.Controls.Add(Me.Label11)
        Me.grpInfoBase.Controls.Add(Me.lblSolicitadoPor)
        Me.grpInfoBase.Controls.Add(Me.Label10)
        Me.grpInfoBase.Controls.Add(Me.lblRecibidoPor)
        Me.grpInfoBase.Controls.Add(Me.Label9)
        Me.grpInfoBase.Controls.Add(Me.lblSintomaFalla)
        Me.grpInfoBase.Controls.Add(Me.lblTipoFalla)
        Me.grpInfoBase.Controls.Add(Me.Label8)
        Me.grpInfoBase.Controls.Add(Me.Label7)
        Me.grpInfoBase.Controls.Add(Me.lblTipoDet)
        Me.grpInfoBase.Controls.Add(Me.Label6)
        Me.grpInfoBase.Controls.Add(Me.lblDetencion)
        Me.grpInfoBase.Controls.Add(Me.Label4)
        Me.grpInfoBase.Controls.Add(Me.lblFechaInicio)
        Me.grpInfoBase.Controls.Add(Me.Label5)
        Me.grpInfoBase.Controls.Add(Me.lblFechaRecepcion)
        Me.grpInfoBase.Controls.Add(Me.Label3)
        Me.grpInfoBase.Location = New System.Drawing.Point(13, 31)
        Me.grpInfoBase.Name = "grpInfoBase"
        Me.grpInfoBase.Size = New System.Drawing.Size(677, 140)
        Me.grpInfoBase.TabIndex = 2
        '
        'lblEstadoOt
        '
        Me.lblEstadoOt.AutoSize = True
        Me.lblEstadoOt.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoOt.Location = New System.Drawing.Point(76, 109)
        Me.lblEstadoOt.Name = "lblEstadoOt"
        Me.lblEstadoOt.Size = New System.Drawing.Size(58, 16)
        Me.lblEstadoOt.TabIndex = 19
        Me.lblEstadoOt.Text = "Label13"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 110)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 15)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Estado OT:"
        '
        'lblDescBreve
        '
        Me.lblDescBreve.AutoSize = True
        Me.lblDescBreve.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescBreve.Location = New System.Drawing.Point(218, 75)
        Me.lblDescBreve.Name = "lblDescBreve"
        Me.lblDescBreve.Size = New System.Drawing.Size(58, 16)
        Me.lblDescBreve.TabIndex = 17
        Me.lblDescBreve.Text = "Label12"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(218, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 15)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Descripción Breve"
        '
        'lblSolicitadoPor
        '
        Me.lblSolicitadoPor.AutoSize = True
        Me.lblSolicitadoPor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSolicitadoPor.Location = New System.Drawing.Point(106, 75)
        Me.lblSolicitadoPor.Name = "lblSolicitadoPor"
        Me.lblSolicitadoPor.Size = New System.Drawing.Size(58, 16)
        Me.lblSolicitadoPor.TabIndex = 15
        Me.lblSolicitadoPor.Text = "Label11"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(106, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 15)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Solicitado Por"
        '
        'lblRecibidoPor
        '
        Me.lblRecibidoPor.AutoSize = True
        Me.lblRecibidoPor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecibidoPor.Location = New System.Drawing.Point(7, 75)
        Me.lblRecibidoPor.Name = "lblRecibidoPor"
        Me.lblRecibidoPor.Size = New System.Drawing.Size(58, 16)
        Me.lblRecibidoPor.TabIndex = 13
        Me.lblRecibidoPor.Text = "Label10"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 15)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Recibido Por"
        '
        'lblSintomaFalla
        '
        Me.lblSintomaFalla.AutoSize = True
        Me.lblSintomaFalla.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSintomaFalla.Location = New System.Drawing.Point(545, 23)
        Me.lblSintomaFalla.Name = "lblSintomaFalla"
        Me.lblSintomaFalla.Size = New System.Drawing.Size(50, 16)
        Me.lblSintomaFalla.TabIndex = 11
        Me.lblSintomaFalla.Text = "Label9"
        '
        'lblTipoFalla
        '
        Me.lblTipoFalla.AutoSize = True
        Me.lblTipoFalla.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoFalla.Location = New System.Drawing.Point(452, 25)
        Me.lblTipoFalla.Name = "lblTipoFalla"
        Me.lblTipoFalla.Size = New System.Drawing.Size(50, 16)
        Me.lblTipoFalla.TabIndex = 10
        Me.lblTipoFalla.Text = "Label9"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(545, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 15)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Síntoma de Falla"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(452, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 15)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Tipo De Falla"
        '
        'lblTipoDet
        '
        Me.lblTipoDet.AutoSize = True
        Me.lblTipoDet.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDet.Location = New System.Drawing.Point(348, 23)
        Me.lblTipoDet.Name = "lblTipoDet"
        Me.lblTipoDet.Size = New System.Drawing.Size(50, 16)
        Me.lblTipoDet.TabIndex = 7
        Me.lblTipoDet.Text = "Label7"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(346, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Tipo Detención"
        '
        'lblDetencion
        '
        Me.lblDetencion.AutoSize = True
        Me.lblDetencion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetencion.Location = New System.Drawing.Point(281, 23)
        Me.lblDetencion.Name = "lblDetencion"
        Me.lblDetencion.Size = New System.Drawing.Size(50, 16)
        Me.lblDetencion.TabIndex = 5
        Me.lblDetencion.Text = "Label6"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(269, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Detención"
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicio.Location = New System.Drawing.Point(150, 23)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(50, 16)
        Me.lblFechaInicio.TabIndex = 3
        Me.lblFechaInicio.Text = "Label6"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(150, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 15)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Fecha/Hora Inicio"
        '
        'lblFechaRecepcion
        '
        Me.lblFechaRecepcion.AutoSize = True
        Me.lblFechaRecepcion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaRecepcion.Location = New System.Drawing.Point(7, 23)
        Me.lblFechaRecepcion.Name = "lblFechaRecepcion"
        Me.lblFechaRecepcion.Size = New System.Drawing.Size(50, 16)
        Me.lblFechaRecepcion.TabIndex = 1
        Me.lblFechaRecepcion.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Fecha /Hora Recepción"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblDescTecnica)
        Me.Panel1.Controls.Add(Me.lblFalla)
        Me.Panel1.Controls.Add(Me.lblCerradoPor)
        Me.Panel1.Controls.Add(Me.lblDuracion)
        Me.Panel1.Controls.Add(Me.lblFechaCierre)
        Me.Panel1.Controls.Add(Me.lblFechaTermino)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Location = New System.Drawing.Point(13, 196)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(677, 117)
        Me.Panel1.TabIndex = 3
        '
        'lblDescTecnica
        '
        Me.lblDescTecnica.AutoSize = True
        Me.lblDescTecnica.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescTecnica.Location = New System.Drawing.Point(7, 83)
        Me.lblDescTecnica.Name = "lblDescTecnica"
        Me.lblDescTecnica.Size = New System.Drawing.Size(58, 16)
        Me.lblDescTecnica.TabIndex = 11
        Me.lblDescTecnica.Text = "Label19"
        '
        'lblFalla
        '
        Me.lblFalla.AutoSize = True
        Me.lblFalla.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFalla.Location = New System.Drawing.Point(469, 26)
        Me.lblFalla.Name = "lblFalla"
        Me.lblFalla.Size = New System.Drawing.Size(58, 16)
        Me.lblFalla.TabIndex = 10
        Me.lblFalla.Text = "Label19"
        '
        'lblCerradoPor
        '
        Me.lblCerradoPor.AutoSize = True
        Me.lblCerradoPor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCerradoPor.Location = New System.Drawing.Point(375, 26)
        Me.lblCerradoPor.Name = "lblCerradoPor"
        Me.lblCerradoPor.Size = New System.Drawing.Size(58, 16)
        Me.lblCerradoPor.TabIndex = 9
        Me.lblCerradoPor.Text = "Label19"
        '
        'lblDuracion
        '
        Me.lblDuracion.AutoSize = True
        Me.lblDuracion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDuracion.Location = New System.Drawing.Point(284, 26)
        Me.lblDuracion.Name = "lblDuracion"
        Me.lblDuracion.Size = New System.Drawing.Size(58, 16)
        Me.lblDuracion.TabIndex = 8
        Me.lblDuracion.Text = "Label19"
        '
        'lblFechaCierre
        '
        Me.lblFechaCierre.AutoSize = True
        Me.lblFechaCierre.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaCierre.Location = New System.Drawing.Point(150, 26)
        Me.lblFechaCierre.Name = "lblFechaCierre"
        Me.lblFechaCierre.Size = New System.Drawing.Size(58, 16)
        Me.lblFechaCierre.TabIndex = 7
        Me.lblFechaCierre.Text = "Label19"
        '
        'lblFechaTermino
        '
        Me.lblFechaTermino.AutoSize = True
        Me.lblFechaTermino.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaTermino.Location = New System.Drawing.Point(7, 26)
        Me.lblFechaTermino.Name = "lblFechaTermino"
        Me.lblFechaTermino.Size = New System.Drawing.Size(58, 16)
        Me.lblFechaTermino.TabIndex = 6
        Me.lblFechaTermino.Text = "Label19"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(7, 58)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(110, 15)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Descripción Técnica"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(469, 6)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(33, 15)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Falla"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(375, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 15)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Cerrado Por"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(284, 6)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 15)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Duración"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(150, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 15)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Fecha/Hora Cierre"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(4, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(118, 15)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Fecha/Hora Término"
        '
        'TabDetalleInfOt
        '
        Me.TabDetalleInfOt.Controls.Add(Me.TabPersonal)
        Me.TabDetalleInfOt.Controls.Add(Me.TabInsumos)
        Me.TabDetalleInfOt.Controls.Add(Me.TabOtExterna)
        Me.TabDetalleInfOt.Location = New System.Drawing.Point(13, 343)
        Me.TabDetalleInfOt.Name = "TabDetalleInfOt"
        Me.TabDetalleInfOt.SelectedIndex = 0
        Me.TabDetalleInfOt.Size = New System.Drawing.Size(677, 173)
        Me.TabDetalleInfOt.TabIndex = 0
        '
        'TabPersonal
        '
        Me.TabPersonal.Controls.Add(Me.grillaPersonalDetalleOt)
        Me.TabPersonal.Location = New System.Drawing.Point(4, 22)
        Me.TabPersonal.Name = "TabPersonal"
        Me.TabPersonal.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPersonal.Size = New System.Drawing.Size(669, 147)
        Me.TabPersonal.TabIndex = 0
        Me.TabPersonal.Text = "Personal Asociado"
        Me.TabPersonal.UseVisualStyleBackColor = True
        '
        'grillaPersonalDetalleOt
        '
        Me.grillaPersonalDetalleOt.AllowUserToAddRows = False
        Me.grillaPersonalDetalleOt.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaPersonalDetalleOt.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grillaPersonalDetalleOt.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaPersonalDetalleOt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grillaPersonalDetalleOt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaPersonalDetalleOt.EnableHeadersVisualStyles = False
        Me.grillaPersonalDetalleOt.Location = New System.Drawing.Point(4, 7)
        Me.grillaPersonalDetalleOt.Name = "grillaPersonalDetalleOt"
        Me.grillaPersonalDetalleOt.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaPersonalDetalleOt.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grillaPersonalDetalleOt.RowHeadersWidth = 20
        Me.grillaPersonalDetalleOt.Size = New System.Drawing.Size(479, 134)
        Me.grillaPersonalDetalleOt.TabIndex = 0
        '
        'TabInsumos
        '
        Me.TabInsumos.Controls.Add(Me.grillaInsumosOt)
        Me.TabInsumos.Location = New System.Drawing.Point(4, 22)
        Me.TabInsumos.Name = "TabInsumos"
        Me.TabInsumos.Padding = New System.Windows.Forms.Padding(3)
        Me.TabInsumos.Size = New System.Drawing.Size(669, 147)
        Me.TabInsumos.TabIndex = 1
        Me.TabInsumos.Text = "Insumos Utilizados"
        Me.TabInsumos.UseVisualStyleBackColor = True
        '
        'grillaInsumosOt
        '
        Me.grillaInsumosOt.AllowUserToAddRows = False
        Me.grillaInsumosOt.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.grillaInsumosOt.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grillaInsumosOt.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaInsumosOt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grillaInsumosOt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaInsumosOt.EnableHeadersVisualStyles = False
        Me.grillaInsumosOt.Location = New System.Drawing.Point(4, 7)
        Me.grillaInsumosOt.Name = "grillaInsumosOt"
        Me.grillaInsumosOt.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grillaInsumosOt.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grillaInsumosOt.RowHeadersWidth = 20
        Me.grillaInsumosOt.Size = New System.Drawing.Size(659, 134)
        Me.grillaInsumosOt.TabIndex = 0
        '
        'TabOtExterna
        '
        Me.TabOtExterna.Controls.Add(Me.GrillaOtExternasDetalle)
        Me.TabOtExterna.Location = New System.Drawing.Point(4, 22)
        Me.TabOtExterna.Name = "TabOtExterna"
        Me.TabOtExterna.Size = New System.Drawing.Size(669, 147)
        Me.TabOtExterna.TabIndex = 2
        Me.TabOtExterna.Text = "Ordenes Externas"
        Me.TabOtExterna.UseVisualStyleBackColor = True
        '
        'GrillaOtExternasDetalle
        '
        Me.GrillaOtExternasDetalle.AllowUserToAddRows = False
        Me.GrillaOtExternasDetalle.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(234, 243, 245)
        Me.GrillaOtExternasDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.GrillaOtExternasDetalle.BackgroundColor = System.Drawing.Color.FromArgb(242, 246, 246)
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaOtExternasDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.GrillaOtExternasDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaOtExternasDetalle.EnableHeadersVisualStyles = False
        Me.GrillaOtExternasDetalle.Location = New System.Drawing.Point(4, 4)
        Me.GrillaOtExternasDetalle.Name = "GrillaOtExternasDetalle"
        Me.GrillaOtExternasDetalle.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(2, 94, 135)
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(160, 197, 207)
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaOtExternasDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.GrillaOtExternasDetalle.RowHeadersWidth = 20
        Me.GrillaOtExternasDetalle.Size = New System.Drawing.Size(662, 140)
        Me.GrillaOtExternasDetalle.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(139, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Item / Maquina :"
        '
        'lblItem
        '
        Me.lblItem.AutoSize = True
        Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItem.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28)
        Me.lblItem.Location = New System.Drawing.Point(244, 12)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(58, 16)
        Me.lblItem.TabIndex = 5
        Me.lblItem.Text = "Label19"
        '
        'FrmDetalleOt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(229, 235, 235)
        Me.ClientSize = New System.Drawing.Size(702, 528)
        Me.Controls.Add(Me.lblItem)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TabDetalleInfOt)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grpInfoBase)
        Me.Controls.Add(Me.lblNumOt)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDetalleOt"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Orden de Trabajo"
        Me.grpInfoBase.ResumeLayout(False)
        Me.grpInfoBase.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabDetalleInfOt.ResumeLayout(False)
        Me.TabPersonal.ResumeLayout(False)
        CType(Me.grillaPersonalDetalleOt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabInsumos.ResumeLayout(False)
        CType(Me.grillaInsumosOt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabOtExterna.ResumeLayout(False)
        CType(Me.GrillaOtExternasDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNumOt As System.Windows.Forms.Label
    Friend WithEvents grpInfoBase As System.Windows.Forms.Panel
    Friend WithEvents lblFechaRecepcion As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDetencion As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTipoDet As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSintomaFalla As System.Windows.Forms.Label
    Friend WithEvents lblTipoFalla As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblRecibidoPor As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblSolicitadoPor As System.Windows.Forms.Label
    Friend WithEvents lblDescBreve As System.Windows.Forms.Label
    Friend WithEvents lblEstadoOt As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TabDetalleInfOt As System.Windows.Forms.TabControl
    Friend WithEvents TabPersonal As System.Windows.Forms.TabPage
    Friend WithEvents TabInsumos As System.Windows.Forms.TabPage
    Friend WithEvents grillaPersonalDetalleOt As System.Windows.Forms.DataGridView
    Friend WithEvents TabOtExterna As System.Windows.Forms.TabPage
    Friend WithEvents grillaInsumosOt As System.Windows.Forms.DataGridView
    Friend WithEvents lblFechaCierre As System.Windows.Forms.Label
    Friend WithEvents lblFechaTermino As System.Windows.Forms.Label
    Friend WithEvents lblDescTecnica As System.Windows.Forms.Label
    Friend WithEvents lblFalla As System.Windows.Forms.Label
    Friend WithEvents lblCerradoPor As System.Windows.Forms.Label
    Friend WithEvents lblDuracion As System.Windows.Forms.Label
    Friend WithEvents GrillaOtExternasDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblItem As System.Windows.Forms.Label
End Class
