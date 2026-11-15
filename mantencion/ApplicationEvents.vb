Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My

    ' Los siguientes eventos están disponibles para MyApplication:
    '
    ' Inicio (Startup): se desencadena antes de crear el formulario principal.
    ' UnhandledException: se desencadena si la aplicación detecta una excepción no controlada.
    Partial Friend Class MyApplication

        Private Shared _manejadoresGlobalesRegistrados As Boolean = False

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As StartupEventArgs) Handles Me.Startup
            If Not _manejadoresGlobalesRegistrados Then
                _manejadoresGlobalesRegistrados = True
                Try
                    System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)
                    AddHandler System.Windows.Forms.Application.ThreadException, AddressOf OnUiThreadException
                    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf OnDomainUnhandledException
                Catch
                End Try
            End If
        End Sub

        Private Sub OnUiThreadException(ByVal sender As Object, ByVal e As ThreadExceptionEventArgs)
            If e IsNot Nothing AndAlso e.Exception IsNot Nothing Then
                RegistroErrores.MostrarYRegistrar(e.Exception, "Interfaz de Usuario (Hilo UI)")
            End If
        End Sub

        Private Sub OnDomainUnhandledException(ByVal sender As Object, ByVal e As System.UnhandledExceptionEventArgs)
            Dim ex = TryCast(If(e IsNot Nothing, e.ExceptionObject, Nothing), Exception)
            If ex IsNot Nothing Then
                RegistroErrores.RegistrarError(ex, "Dominio de Aplicación (No Controlado)")
            End If
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Try
                If e IsNot Nothing AndAlso e.Exception IsNot Nothing Then
                    RegistroErrores.MostrarYRegistrar(e.Exception, "Aplicación General")
                    e.ExitApplication = False
                End If
            Catch
            End Try
        End Sub

    End Class

End Namespace
