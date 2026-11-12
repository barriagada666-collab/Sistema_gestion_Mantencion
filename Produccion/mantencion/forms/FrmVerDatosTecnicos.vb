Public Class FrmVerDatosTecnicos
    Public DST_DATOS_TECNICOS As New DataSet
    Public id_nodo As String
    Public nivel As Integer
    Private Sub FrmVerDatosTecnicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim datos_tecnicos As New DatosTecnicos
        Dim formato_grid As New FormatoGrillas

        datos_tecnicos.CrgDatosTecnicosNodo(id_nodo, nivel, DST_DATOS_TECNICOS)

        Try
            grillaDatosTecnicosAsoc.DataSource = DST_DATOS_TECNICOS.Tables(0)
            formato_grid.grillaDatosTecnicos(grillaDatosTecnicosAsoc)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class