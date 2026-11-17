Imports System.Data.SqlClient

Public Class Proveedor
    Public Sub crgprovee(ByRef combo As ComboBox)
        If combo Is Nothing Then Exit Sub
        Dim conexion As New Conexion
        Try
            Using cnx As New SqlConnection
                conexion.Conectar(cnx)
                Using DA As New SqlDataAdapter("CRG_CMB_PROVEEDOR", cnx)
                    DA.SelectCommand.CommandType = CommandType.StoredProcedure
                    Dim dt As New DataTable()
                    DA.Fill(dt)
                    combo.DisplayMember = "nombre_prov"
                    combo.ValueMember = "idproveedor"
                    combo.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            RegistroErrores.MostrarYRegistrar(ex, "Cargar Proveedores")
        End Try
    End Sub
End Class
