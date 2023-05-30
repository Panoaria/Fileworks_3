Option Strict On
Public Class Form1
    Dim dateiinhalt As String = Nothing
    Dim dateiname As String
    Dim dateipfad As String
    Dim hlpDlg As New Form

    Private Sub ClearBoxes()
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
    End Sub

    Private Function CalcYearNumber(tageszeit As String) As Object
        ' Ausgabe der 2. und 3. Stelle der Programmnummer 
        Dim jahrstr As String = Mid(tageszeit, 9, 2)
        Return jahrstr
    End Function

    Private Function CalcDayNumber(tageszeit As String) As Object
        ' Berechnen der 4.-6. Stelle der Programmnummer im Bereich 001 bis 365 als laufender Tag im Jahr
        Dim Jahr As Integer = Year(Now)
        Dim FoY As Date = Convert.ToDateTime("01.01." & Jahr)
        Dim aktTagStr As String = Convert.ToString(DateDiff("d", FoY, tageszeit) + 1)
        Dim aktTag As Integer = Convert.ToInt32(DateDiff("d", FoY, tageszeit) + 1)

        ' 3 Stellen absichern
        If aktTag < 100 Then aktTagStr = "0" + aktTag.ToString
        If aktTag < 10 Then aktTagStr = "00" + aktTag.ToString
        Return aktTagStr
    End Function

    Private Function CalcHourNumber(tageszeit As String) As Object
        ' Berechnen letzte 2 Stellen der Programmnummer im Bereich 00 bis 99 tageszeitabhängig
        Dim stunde As Integer = Convert.ToInt32(Val(Mid(tageszeit, 12, 2)))
        Dim minute As Integer = Convert.ToInt32(Val(Mid(tageszeit, 15, 2)))
        Dim lfdstr As String
        Dim lfd As Integer


        lfd = Convert.ToInt32(stunde / 24 * 99) + (minute / 60 / 24 * 99)
        ' 2 Stellen absichern
        If lfd < 10 Then lfdstr = "0" + lfd.ToString Else lfdstr = lfd
        Return lfdstr
    End Function

    Private Sub FileSelectButton_Click(sender As Object, e As EventArgs) Handles FileSelectButton.Click
        ' OpenFileDialog zum Auswählen einer Datei
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "Heidenhain Files|*.H"
        openFileDialog1.Title = "Wähle eine Heidenhain Datei"

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            ' Dateiinhalt in String dateiinhalt laden
            Dim sr As New IO.StreamReader(openFileDialog1.FileName)
            dateiinhalt = sr.ReadToEnd
            sr.Close()

            ' Dateiinhalt in Textbox1 ballern
            TextBox1.Text = dateiinhalt

            ' Pfad und Dateinamen lesen
            dateiname = openFileDialog1.FileName

            ' Pfad only
            dateipfad = New IO.FileInfo(openFileDialog1.FileName).DirectoryName
            MessageBox.Show(dateipfad)

            ' Rekonstruktionsbutton aktivieren
            RecoButton.Enabled = True
            ' Werkzeuglistenbutton aktivieren
            ResetButton.Enabled = True
            ' Werkzeugnummernbutton aktivieren
            ToolnumberButton.Enabled = True

        End If
    End Sub



    Private Sub RecoButton_Click(sender As Object, e As EventArgs) Handles RecoButton.Click


        If TextBox1.Text.Contains("; -") Then
            TextBox1.Text = TextBox1.Text.Replace("; -", "* -")
        End If
        If TextBox1.Text.Contains(";     -") Then
            TextBox1.Text = TextBox1.Text.Replace(";     -", "*     -")
        End If


        My.Computer.FileSystem.WriteAllText(dateiname, TextBox1.Text, False)
        Dim sr As New IO.StreamReader(dateiname)
        dateiinhalt = sr.ReadToEnd
        sr.Close()
    End Sub



    Private Sub GenerateNumberButton_Click(sender As Object, e As EventArgs) Handles GenerateNumberButton.Click
        Dim systemdatum As String = DateAndTime.Now
        Dim machinenumber As String

        machinenumber = ComboBox1.SelectedItem
        If machinenumber = "Axa6" Then machinenumber = 7
        If machinenumber = "Axa5" Then machinenumber = 8
        If machinenumber = "Axa4" Then machinenumber = 9
        If machinenumber = Nothing Then
            MessageBox.Show("Maschine auswählen!!!", "Eingabe nötig")
            Exit Sub
        End If

        TextBox4.Text = machinenumber & CalcYearNumber(systemdatum) & CalcDayNumber(systemdatum) & CalcHourNumber(systemdatum)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tooltiphelp As New ToolTip()
        tooltiphelp.SetToolTip(FileSelectButton, "Datei zum Bearbeiten auswählen")
        tooltiphelp.SetToolTip(RecoButton, "Gliederung wird wiederhergestellt und Änderungen sofort zurückgespeichert")
        tooltiphelp.SetToolTip(ResetButton, "Setzt Programm auf Anfang")
        tooltiphelp.SetToolTip(ToolnumberButton, "Werkzeugliste und Werkzeugnummern extrahieren")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub




    Private Sub ToolnumberButton_Click(sender As Object, e As EventArgs) Handles ToolnumberButton.Click
        Dim isoliert As String
        Dim wkznr As String
        Dim sternfund As Boolean = False
        Dim zeile() As String = IO.File.ReadAllLines(dateiname)
        Dim anzahlzeile As Integer = zeile.Length - 1
        Dim aktuell As Integer = -1


        ClearBoxes()

        For aktuell = aktuell + 1 To anzahlzeile
            If zeile(aktuell).Contains("* -") Then
                'If zeile(aktuell).Contains("* - *") Then Exit Sub

                ' Werkzeugnamen vom Rest des Strings trennen
                isoliert = zeile(aktuell).Substring(zeile(aktuell).LastIndexOf("* -") + 4)

                ' doppelte Aufzählung ausschließen, nach Werkzeugnamen
                If Not TextBox2.Text.Contains(isoliert) Then

                    ' Wehnerkoeffizienten ausblenden ;) Nur Gliederungspunkte erfassen, auf die ein TOOL CALL folgt,
                    ' in der nächsten oder übernächsten Zeile
                    ' nächste Zeile checken
                    If aktuell + 1 < anzahlzeile Then

                        If zeile(aktuell + 1).Contains("TOOL CALL") Then
                            wkznr = zeile(aktuell + 1).Remove(zeile(aktuell + 1).LastIndexOf(" Z"))
                            wkznr = wkznr.Substring(wkznr.LastIndexOf("LL ") + 3)

                            ' doppelte Aufzählung ausschließen, nach Werkzeugnummer
                            If Not TextBox3.Text.Contains(wkznr) Then

                                ' String nach * - in Textbox2 hämmern
                                ' vbCrLf ist CHR13-Konstante, für Zeilensprung
                                TextBox2.Text = TextBox2.Text + isoliert + vbCrLf

                                ' und die Nummer in Textbox3 drücken
                                TextBox3.Text = TextBox3.Text + wkznr + vbCrLf
                            End If
                        End If
                    End If
                    ' übernächste Zeile checken
                    If aktuell + 2 < anzahlzeile Then

                        If zeile(aktuell + 2).Contains("TOOL CALL") Then
                            wkznr = zeile(aktuell + 2).Remove(zeile(aktuell + 2).LastIndexOf(" Z"))
                            wkznr = wkznr.Substring(wkznr.LastIndexOf("LL ") + 3)
                            If Not TextBox3.Text.Contains(wkznr) Then
                                TextBox2.Text = TextBox2.Text + isoliert + vbCrLf
                                TextBox3.Text = TextBox3.Text + wkznr + vbCrLf
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
        dateiname = Nothing
        dateiinhalt = Nothing
        RecoButton.Enabled = False
        ResetButton.Enabled = False
        ToolnumberButton.Enabled = False
        ComboBox1.SelectedIndex = -1
    End Sub

    Private Sub HelpButtons_Click(sender As Object, e As EventArgs) Handles HelpButtons.Click
        MessageBox.Show("hier soll die Hilfe hin")

        hlpDlg.Focus()
        hlpDlg.Text = "H I L F E"
        hlpDlg.ShowDialog()

    End Sub
End Class
