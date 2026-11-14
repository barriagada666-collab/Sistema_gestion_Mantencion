Public Class FrmVerDatosTecnicos
    Public DST_DATOS_TECNICOS As New DataSet
    Public id_nodo As String
    Public nivel As Integer
    Private Sub FrmVerDatosTecnicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Dim datos_tecnicos As New DatosTecnicos
        Dim formato_grid As New FormatoGrillas

        Try
            grillaDatosTecnicosAsoc.SuspendLayout()
            datos_tecnicos.CrgDatosTecnicosNodo(id_nodo, nivel, DST_DATOS_TECNICOS)
            grillaDatosTecnicosAsoc.DataSource = DST_DATOS_TECNICOS.Tables(0)
            formato_grid.grillaDatosTecnicos(grillaDatosTecnicosAsoc)
            Utilitarios.AjustarColumnasGrilla(grillaDatosTecnicosAsoc)
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            grillaDatosTecnicosAsoc.ResumeLayout(False)
            Me.ResumeLayout(True)
        End Try
    End Sub
End Class