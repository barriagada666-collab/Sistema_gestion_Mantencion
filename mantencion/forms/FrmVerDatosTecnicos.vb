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
            If DST_DATOS_TECNICOS.Tables.Count > 0 Then
                grillaDatosTecnicosAsoc.DataSource = DST_DATOS_TECNICOS.Tables(0)
                formato_grid.grillaDatosTecnicos(grillaDatosTecnicosAsoc)
                Utilitarios.AjustarColumnasGrilla(grillaDatosTecnicosAsoc)
            End If
            Utilitarios.AplicarTemaModerno(Me)
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Ver Datos Técnicos", True, Me)
        Finally
            grillaDatosTecnicosAsoc.ResumeLayout(False)
            Me.ResumeLayout(True)
        End Try
    End Sub
End Class