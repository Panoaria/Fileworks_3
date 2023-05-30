
Imports Microsoft.VisualBasic.ApplicationServices
Imports Fileworks
Namespace My
    ' Für MyApplication sind folgende Ereignisse verfügbar:
    ' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgelöst.
    ' Shutdown: Wird nach dem Schließen aller Anwendungsformulare ausgelöst. Dieses Ereignis wird nicht ausgelöst, wenn die Anwendung mit einem Fehler beendet wird.
    ' UnhandledException: Wird bei einem Ausnahmefehler ausgelöst.
    ' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgelöst, wenn die Anwendung bereits aktiv ist. 
    ' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgelöst.
    Partial Friend Class MyApplication



        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup

        End Sub

        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As StartupNextInstanceEventArgs) Handles Me.StartupNextInstance

            'For anzahl As Integer = 0 To e.CommandLine.Count - 1

            If e.CommandLine.Count > 0 Then
                Dim frm = CType(Application.OpenForms(0), Form1)  ' Instanz Deiner Form holen
                frm.NewData(e.CommandLine(0))  ' Datei reinreichen

            End If
            'Next
        End Sub
    End Class
End Namespace
