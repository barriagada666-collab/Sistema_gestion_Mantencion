Namespace My

    ' Los siguientes eventos están disponibles para MyApplication:
    ' 
    ' Inicio: se desencadena cuando se inicia la aplicación, antes de que se cree el formulario de inicio.
    ' Apagado: se desencadena después de cerrar todos los formularios de la aplicación. Este evento no se desencadena si la aplicación se termina de forma anómala.
    ' UnhandledException: se desencadena si la aplicación detecta una excepción no controlada.
    ' StartupNextInstance: se desencadena cuando se inicia una aplicación de instancia única y ya hay una activa. 
    ' NetworkAvailabilityChanged: se desencadena cuando se conecta o desconecta la conexión de red.
    Partial Friend Class MyApplication

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Try
                Dim msg As String = String.Format("[{0:yyyy-MM-dd HH:mm:ss}] ERROR: {1}{2}{3}{2}{2}",
                                                  DateTime.Now,
                                                  If(e.Exception IsNot Nothing, e.Exception.Message, "Desconocido"),
                                                  Environment.NewLine,
                                                  If(e.Exception IsNot Nothing, e.Exception.StackTrace, ""))
                Dim logPath As String = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "error_runtime.log")
                Try
                    System.IO.File.AppendAllText(logPath, msg)
                Catch
                    Dim appDataDir As String = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SistemaMantencion")
                    System.IO.Directory.CreateDirectory(appDataDir)
                    System.IO.File.AppendAllText(System.IO.Path.Combine(appDataDir, "error_runtime.log"), msg)
                End Try
            Catch
            End Try
        End Sub

    End Class

End Namespace
