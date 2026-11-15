Imports System.Data.SqlClient
Public Class Proveedor
    Public Sub crgprovee(ByRef combo As ComboBox)
        Dim conexion As New Conexion
        Dim cnx As New SqlConnection
        Try
            conexion.Conectar(cnx)
            Using DA As New SqlDataAdapter("CRG_CMB_PROVEEDOR ", cnx)
                Dim DS As New DataSet
                DA.Fill(DS)
                If DS.Tables.Count > 0 Then
                    combo.DataSource = DS.Tables(0)
                    combo.DisplayMember = "nombre_prov"
                    combo.ValueMember = "idproveedor"
                End If
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Crgprovee")
        Finally
            conexion.Desconectar(cnx)
        End Try
    End Sub
End Class
