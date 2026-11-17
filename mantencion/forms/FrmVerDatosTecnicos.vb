Public Class FrmVerDatosTecnicos
    Public DST_DATOS_TECNICOS As New DataSet
    Public id_nodo As String = String.Empty
    Public nivel As Integer = 3

    Private Sub FrmVerDatosTecnicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.SuspendLayout()
        Dim datos_tecnicos As New DatosTecnicos
        Dim formato_grid As New FormatoGrillas

        Try
            grillaDatosTecnicosAsoc.SuspendLayout()
            DST_DATOS_TECNICOS.Tables.Clear()
            If Not String.IsNullOrWhiteSpace(id_nodo) Then
                datos_tecnicos.CrgDatosTecnicosNodo(id_nodo, nivel, DST_DATOS_TECNICOS)
                If DST_DATOS_TECNICOS.Tables.Count > 0 Then
                    grillaDatosTecnicosAsoc.DataSource = DST_DATOS_TECNICOS.Tables(0)
                    formato_grid.grillaDatosTecnicos(grillaDatosTecnicosAsoc)
                    Utilitarios.AjustarColumnasGrilla(grillaDatosTecnicosAsoc)
                End If
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
