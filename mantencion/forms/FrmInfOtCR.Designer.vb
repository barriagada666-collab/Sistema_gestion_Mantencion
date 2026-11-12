<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfOtCR
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
        Me.CRV_INF_OT = New NativeReportViewer()
        Me.SuspendLayout()
        '
        'CRV_INF_OT
        '
        Me.CRV_INF_OT.ActiveViewIndex = -1
        Me.CRV_INF_OT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRV_INF_OT.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRV_INF_OT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRV_INF_OT.Location = New System.Drawing.Point(0, 0)
        Me.CRV_INF_OT.Name = "CRV_INF_OT"
        Me.CRV_INF_OT.Size = New System.Drawing.Size(966, 513)
        Me.CRV_INF_OT.TabIndex = 0
        '
        'FrmInfOtCR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 513)
        Me.Controls.Add(Me.CRV_INF_OT)
        Me.Name = "FrmInfOtCR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visor de Informes OT"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRV_INF_OT As NativeReportViewer
End Class
