Option Strict On
Imports System.Text.RegularExpressions


Public Class Form1

    Private WithEvents RTBWrapper As New cRTBWrapper
    Private CText As New CTextarbeit
    Private rtb_SetFire As Boolean

    'nur Public für das Einreichen einer Datei vom Kommandoprompt.
    Public Sub NewData(file As String)
        DateiEinlesen(file)
    End Sub

    Private Sub DateiEinlesen(aktdatei As String)
        Dim Stoppuhr As New Stopwatch
        Dim zeitmarkierentxt As TimeSpan
        Dim zeitmarkierenregex As TimeSpan


        NC_Show_RTB.Clear()

        CText.LeseFile(aktdatei)



        Dim fi As New System.IO.FileInfo(CText.Dateiname)
        Dim ext = fi.Extension



        If ext = ".H" Or ext = ".h" Then

            rtb_SetFire = False
            NC_Show_RTB.Text = CText.Dateiinhalt
            rtb_SetFire = True

            'Stoppuhr.Start()
            'HighlightText()
            'Stoppuhr.Stop()
            'zeitmarkierenregex = Stoppuhr.Elapsed


            'Stoppuhr.Reset()
            'Stoppuhr.Start()
            Highlight()
            'Stoppuhr.Stop()
            'zeitmarkierentxt = Stoppuhr.Elapsed


            'MessageBox.Show("Markierzeit mit RegEx: " & zeitmarkierenregex.ToString & " Markierzeit mit Schleife: " & zeitmarkierentxt.ToString)


            ' Rekonstruktionsbutton aktivieren
            RecoButton.Enabled = True
            ' Werkzeugnummernbutton aktivieren
            ToolnumberButton.Enabled = True
            ' Checkbox aktivieren
            DoubleWkzCB.Enabled = True

            InsertToolDef.Enabled = True
            BtnDelToolDef.Enabled = True
            kplGliederungButton.Enabled = True

        Else
            PNTtoH.Enabled = True
            NC_Show_RTB.Text = CText.Dateiinhalt
        End If
        Me.Text = "Fileworks " & CText.Dateiname

        RTBWrapper.colorDocument()

    End Sub

    Private Sub DateiSchreiben(aktdatei As String)
        ' und zurücksichern in die neue Datei
        CText.Dateiinhalt = NC_Show_RTB.Text
        IO.File.WriteAllText(aktdatei, CText.Dateiinhalt)
    End Sub

    Private Sub ClearBoxes()

        ToolNameTB.Clear()
        ToolNumberTB.Clear()
    End Sub

    Private Sub HighlightShort() ' für manuelles Ändern optimiert, nur aktuelle Zeile prüfen und highlighten
        ' aktuelle Cursorposition ermitteln
        Dim pos As Integer = NC_Show_RTB.SelectionStart

        ' Zeilennummer ermitteln, obsolet
        Dim zeile As Integer = NC_Show_RTB.GetLineFromCharIndex(pos)
        'MessageBox.Show(zeile.ToString)
        ' Text der aktuellen Zeile lesen, noch unsicher, falls "weicher Umbruch" in RTB durch besonders lange Zeile ausgelöst wurde
        ' (will heisen, falsche Zeile wird dann geprüft und gehighlightet, derzeit dadurch gelöst, das weiche Umbrüche 
        ' durch RTB Eigenschaft NC_Show_RTB.WordWrap = False ausgeschaltet sind.)
        Dim zeilentext As String = NC_Show_RTB.Lines(NC_Show_RTB.GetLineFromCharIndex(NC_Show_RTB.SelectionStart))


        'MessageBox.Show(zeilentext)
        If zeilentext.Contains("TOOL CALL") Then
            '   MessageBox.Show(line.Contains("TOOL CALL").ToString)
            NC_Show_RTB.SelectionStart = NC_Show_RTB.Text.IndexOf(zeilentext) + zeilentext.IndexOf("TOOL")
            NC_Show_RTB.SelectionLength = zeilentext.Length - zeilentext.IndexOf("TOOL")
            NC_Show_RTB.SelectionColor = Color.YellowGreen
        ElseIf zeilentext.Contains("* -") OrElse zeilentext.Contains("*   -") Then
            NC_Show_RTB.SelectionStart = NC_Show_RTB.Text.IndexOf(zeilentext) + zeilentext.IndexOf("*")
            NC_Show_RTB.SelectionLength = zeilentext.Length - zeilentext.IndexOf("*")
            NC_Show_RTB.SelectionColor = Color.Red
        ElseIf Not zeilentext.Contains("TOOL CALL") And Not zeilentext.Contains("* -") And Not zeilentext.Contains("*   -") Then
            NC_Show_RTB.SelectionStart = NC_Show_RTB.Text.IndexOf(zeilentext)
            NC_Show_RTB.SelectionLength = zeilentext.Length
            NC_Show_RTB.SelectionColor = Color.White
        End If

        ' Cursor wieder an vorherige Position setzen
        NC_Show_RTB.SelectionLength = 0
        NC_Show_RTB.SelectionStart = pos
    End Sub

    Private Sub Highlight()
        ' Alte Cursorposition speichern, obsolet, da nur komplett gehighlighted wird, wenn Cursor auf Pos(0) steht.
        Dim pos As Integer = NC_Show_RTB.SelectionStart
        Dim lastFound As Integer = 0
        Dim lIndex As Integer


        ' Schauen, wofür es gut sein kann, evtl für Richtextbox, farbig Syntax hervorheben
        For Each line In NC_Show_RTB.Lines
            'MessageBox.Show(line)
            If line.Contains("TOOL CALL") Then
                '   MessageBox.Show(line.Contains("TOOL CALL").ToString)
                lIndex = line.IndexOf("TOOL")
                NC_Show_RTB.Select(NC_Show_RTB.Text.IndexOf(line, lastFound) + lIndex, line.Length - lIndex)
                'NC_Show_RTB.SelectionStart = NC_Show_RTB.Text.IndexOf(line, lastFound) + lIndex
                'NC_Show_RTB.SelectionLength = line.Length - lIndex
                NC_Show_RTB.SelectionColor = Color.YellowGreen
                lastFound = NC_Show_RTB.SelectionStart + NC_Show_RTB.SelectionLength
            ElseIf line.Contains("* -") OrElse line.Contains("*   -") Then
                lIndex = line.IndexOf("*")
                NC_Show_RTB.Select(NC_Show_RTB.Text.IndexOf(line, lastFound) + lIndex, line.Length - lIndex)
                'NC_Show_RTB.SelectionStart = NC_Show_RTB.Text.IndexOf(line, lastFound) + lIndex
                'NC_Show_RTB.SelectionLength = line.Length - lIndex
                NC_Show_RTB.SelectionColor = Color.Red
                lastFound = NC_Show_RTB.SelectionStart + NC_Show_RTB.SelectionLength
                'ElseIf Not line.Contains("TOOL CALL") And Not line.Contains("* -") And Not line.Contains("*   -") Then
                '    Dim suchtext As String = line
                '    NC_Show_RTB.SelectionStart = NC_Show_RTB.Text.IndexOf(suchtext)
                '    NC_Show_RTB.SelectionLength = suchtext.Length
                '    NC_Show_RTB.SelectionColor = Color.White
            End If
        Next
        ' Cursor wieder an vorherige Position setzen, obsolet, reicht, wenn er auf Pos(0) gesetzt wird.
        NC_Show_RTB.SelectionLength = 0
        NC_Show_RTB.SelectionStart = pos
    End Sub


    Private Sub HighlightRegEx()

        Dim reg As Regex = New Regex("TOOL CALL")
        Dim matches As MatchCollection = reg.Matches(NC_Show_RTB.Text)
        For Each match As Match In matches

            Dim zeilentext As String = NC_Show_RTB.Lines(NC_Show_RTB.GetLineFromCharIndex(match.Index))

            NC_Show_RTB.SelectionStart = match.Index
            NC_Show_RTB.SelectionLength = zeilentext.Length - zeilentext.IndexOf("TOOL")
            NC_Show_RTB.SelectionColor = Color.YellowGreen

        Next


        Dim reg2 As Regex = New Regex("(\*{1} \-)|(\*   \-)")
        Dim matches2 As MatchCollection = reg2.Matches(NC_Show_RTB.Text)
        For Each match As Match In matches2

            Dim zeilentext As String = NC_Show_RTB.Lines(NC_Show_RTB.GetLineFromCharIndex(match.Index))

            NC_Show_RTB.SelectionStart = match.Index
            NC_Show_RTB.SelectionLength = zeilentext.Length - zeilentext.IndexOf("*")
            NC_Show_RTB.SelectionColor = Color.Red

        Next



        ' Cursor wieder an vorherige Position setzen, obsolet, reicht, wenn er auf Pos(0) gesetzt wird.
        NC_Show_RTB.SelectionLength = 0
        NC_Show_RTB.SelectionStart = 0
    End Sub


    Private Function PGMNR(maschinennummer As String, zeit As String) As String
        Return maschinennummer & CalcYearNumber(zeit) & CalcDayNumber(zeit) & CalcHourNumber(zeit)
    End Function

    Private Function CalcYearNumber(tageszeit As String) As String
        ' Ausgabe der 2. und 3. Stelle der Programmnummer 
        Dim jahrstr As String = Mid(tageszeit, 9, 2)
        Return jahrstr
    End Function

    Private Function CalcDayNumber(tageszeit As String) As String
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

    Private Function CalcHourNumber(tageszeit As String) As String
        ' Berechnen letzte 2 Stellen der Programmnummer im Bereich 00 bis 99 tageszeitabhängig
        Dim stunde As Integer = Convert.ToInt32(Val(Mid(tageszeit, 12, 2)))
        Dim minute As Integer = Convert.ToInt32(Val(Mid(tageszeit, 15, 2)))
        Dim lfdstr As String
        Dim lfd As Integer

        lfd = Convert.ToInt32((stunde / 24 * 99) + (minute / 60 / 24 * 99))
        ' 2 Stellen absichern
        If lfd < 10 Then lfdstr = "0" + lfd.ToString Else lfdstr = Convert.ToString(lfd)
        Return lfdstr
    End Function

    Private Sub FileSelectButton_Click(sender As Object, e As EventArgs) Handles FileSelectButton.Click
        ' OpenFileDialog zum Auswählen einer Datei instanzieren.
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "Heidenhain Files|*.H; *.PNT"
        openFileDialog1.Title = "Wähle eine Heidenhain Datei"

        ' angezeigtes Verzeichnis des Dialogs steuern, falls bereits eine Datei vorher geöffnet wurde.
        If CText.Dateipfad <> Nothing Then openFileDialog1.InitialDirectory = CText.Dateipfad

        ' Dialog anzeigen, und bei positivem Resultat Datei öffnen.
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then DateiEinlesen(openFileDialog1.FileName)
    End Sub

    Private Sub RecoButton_Click(sender As Object, e As EventArgs) Handles RecoButton.Click
        ' Gliederung wiederherstellen, welche durch die Steuerung TNC410 geschreddert wurde. Eventuell später automatisch auslösen 
        ' bei NC_Show_RTB.TextChanged Event. Dann allerdings nur für die aktuelle Zeile. (soll Richtung IntelliSense gehen)
        If NC_Show_RTB.Text.Contains("; -") Then
            NC_Show_RTB.Text = NC_Show_RTB.Text.Replace("; -", "* -")
        End If
        If NC_Show_RTB.Text.Contains(";   -") Then
            NC_Show_RTB.Text = NC_Show_RTB.Text.Replace(";   -", "*   -")
        End If
        DateiSchreiben(CText.Dateiname)
    End Sub


    Private Sub GenerateNumberButton_Click(sender As Object, e As EventArgs) Handles GenerateNumberButton.Click
        Dim systemdatum As String = DateAndTime.Now.ToString
        Dim machinenumber As String

        machinenumber = Convert.ToString(ComboBox1.SelectedItem)
        If machinenumber = "Axa6" Then machinenumber = "7"
        If machinenumber = "Axa5" Then machinenumber = "8"
        If machinenumber = "Axa4" Then machinenumber = "9"
        If machinenumber = Nothing Then
            MessageBox.Show("Maschine auswählen!!!", "Eingabe nötig")
            Exit Sub
        End If
        TextBox4.Text = PGMNR(machinenumber, systemdatum)
        CText.Programmnummer = TextBox4.Text
    End Sub

    Private Sub InitHighLight()
        RTBWrapper.rtfSyntax.Add("TOOL DEF", False, True, Color.Yellow.ToArgb)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NC_Show_RTB.AllowDrop = True

        RTBWrapper.bind(NC_Show_RTB)
        InitHighLight()


        Dim tooltiphelp As New ToolTip()
        tooltiphelp.SetToolTip(FileSelectButton, "Datei zum Bearbeiten auswählen")
        tooltiphelp.SetToolTip(RecoButton, "Gliederung wird wiederhergestellt und Änderungen sofort zurückgespeichert")
        tooltiphelp.SetToolTip(ResetButton, "Setzt Programm auf Anfang")
        tooltiphelp.SetToolTip(ToolnumberButton, "Werkzeugliste und Werkzeugnummern extrahieren")
        tooltiphelp.SetToolTip(PgmNrInsertButton, "Erzeugte Programmnummer für aktives Programm verwenden")
        tooltiphelp.SetToolTip(kplGliederungButton, "Komplette Gliederungsansicht des Programmes anzeigen")

        DoubleWkzCB.CheckState = CheckState.Checked

        ' folgende Schleife ist obsolet, da SingleInstanceApplication. Code nur aufheben für andere Projekte.
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
            MsgBox("Die Anwendung wird bereits ausgeführt,  bitte Dateien per Drag&Drop zufügen!", MsgBoxStyle.Critical)
            End
        End If

        ' Kommandozeilenargumente auslesen, um Programm bereits mit geladener Datei zu starten.
        CText.KommandoArgument = System.Environment.GetCommandLineArgs
        If CText.Dateiname <> Nothing Then DateiEinlesen(CText.Dateiname)



        'Dim myCommand() As String = System.Environment.GetCommandLineArgs
        'Dim i As Integer
        'Dim s As String = myCommand.Length.ToString
        ' Dim s As String = CText.KommandoArgument.Length.ToString

        'With myCommand
        'For i = .GetLowerBound(0) + 1 To .GetUpperBound(0) '+1 damit nicht der Programmpfad mit ausgegeben wird
        ' MessageBox.Show(myCommand(i))
        'DateiEinlesen(myCommand(i)) 'steht erstmal nur da, um später weitere 
        'Next
        'End With

    End Sub


    Private Sub Rtb_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles NC_Show_RTB.DragEnter
        ' Absichern, das die RichTextBox nur Dateien akzeptiert und keine anderen Objekte.
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub Rtb_DragDrop(sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles NC_Show_RTB.DragDrop
        ' Beim Loslassen der Datei entsprechende Datei öffnen.
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            ' Dateinamen in Array packen
            Dim MyFiles() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            ' Wenn was sinnvolles kommt, öffnen... Wenn zuviel, Info
            If MyFiles.Length = 1 Then DateiEinlesen(MyFiles(0))
            If MyFiles.Length > 1 Then MessageBox.Show("Dateien bitte nur einzeln zufügen!")
        End If
    End Sub


    'Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles NC_Show_RTB.TextChanged
    '    ' Eventhandler für Syntax Highlight, später für IntelliSense
    '    If rtb_SetFire Then
    '        'If NC_Show_RTB.SelectionStart <> 0 Then HighlightShort() Else Highlight()
    '        'CText.Dateiinhalt = NC_Show_RTB.Text
    '    End If
    'End Sub

    Private Sub TextBox2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ToolNameTB.MouseDoubleClick
        ' komplette Werkzeugliste markieren per Doppelklick 
        ToolNameTB.SelectAll()
        Clipboard.SetDataObject(ToolNameTB.SelectedText, True)
    End Sub

    Private Sub TextBox3_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ToolNumberTB.MouseDoubleClick
        ' komplette Werkzeugnummernliste markieren per Doppelklick
        ToolNumberTB.SelectAll()
        Clipboard.SetDataObject(ToolNumberTB.SelectedText, True)
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub




    Private Sub ToolnumberButton_Click(sender As Object, e As EventArgs) Handles ToolnumberButton.Click

        Dim isoliert As String
        Dim wkznr As String
        Dim sternfund As Boolean = False

        Dim zeile() As String = NC_Show_RTB.Lines
        Dim anzahlzeile As Integer = zeile.Length - 1
        Dim aktuell As Integer = -1

        ' Versuch, Werkzeuglisten über mehrere Programme zu erstellen
        ' ClearBoxes()



        For aktuell = aktuell + 1 To anzahlzeile
            If zeile(aktuell).Contains("* -") Then
                'If zeile(aktuell).Contains("* - *") Then Exit Sub

                ' Werkzeugnamen vom Rest des Strings trennen
                isoliert = zeile(aktuell).Substring(zeile(aktuell).IndexOf("* -") + 4)

                ' doppelte Aufzählung ausschließen, nach Werkzeugnamen
                If Not ToolNameTB.Text.Contains(isoliert) And DoubleWkzCB.Checked = False Then

                    ' Wehnerkoeffizienten ausblenden ;) Nur Gliederungspunkte erfassen, auf die ein TOOL CALL folgt,
                    ' in der nächsten oder übernächsten Zeile
                    ' nächste Zeile checken
                    If aktuell + 1 < anzahlzeile Then

                        If zeile(aktuell + 1).Contains("TOOL CALL") Then
                            wkznr = zeile(aktuell + 1).Remove(zeile(aktuell + 1).IndexOf(" Z"))
                            wkznr = " " & wkznr.Substring(wkznr.IndexOf("LL ") + 3) & " "

                            ' doppelte Aufzählung ausschließen, nach Werkzeugnummer
                            If Not ToolNumberTB.Text.Contains(wkznr) Then

                                ' String nach * - in Textbox2 hämmern
                                ' vbCrLf ist CHR13-Konstante, für Zeilensprung
                                ToolNameTB.Text = ToolNameTB.Text + isoliert + vbCrLf

                                ' und die Nummer in Textbox3 drücken
                                ToolNumberTB.Text = ToolNumberTB.Text + wkznr + vbCrLf
                            End If
                        End If
                    End If
                    ' übernächste Zeile checken
                    If aktuell + 2 < anzahlzeile Then
                        If zeile(aktuell + 2).Contains("TOOL CALL") Then
                            wkznr = zeile(aktuell + 2).Remove(zeile(aktuell + 2).IndexOf(" Z"))
                            wkznr = " " & wkznr.Substring(wkznr.IndexOf("LL ") + 3) & " "
                            If Not ToolNumberTB.Text.Contains(wkznr) Then
                                ToolNameTB.Text = ToolNameTB.Text + isoliert + vbCrLf
                                ToolNumberTB.Text = ToolNumberTB.Text + wkznr + vbCrLf
                            End If
                        End If
                    End If
                ElseIf DoubleWkzCB.Checked = True Then
                    If aktuell + 1 < anzahlzeile Then
                        If zeile(aktuell + 1).Contains("TOOL CALL") Then
                            wkznr = zeile(aktuell + 1).Remove(zeile(aktuell + 1).IndexOf(" Z"))
                            wkznr = " " & wkznr.Substring(wkznr.IndexOf("LL ") + 3) & " "

                            If Not ToolNumberTB.Text.Contains(wkznr) Then
                                ToolNameTB.Text = ToolNameTB.Text + isoliert + vbCrLf
                                ToolNumberTB.Text = ToolNumberTB.Text + wkznr + vbCrLf
                            End If
                        End If
                    End If
                    If aktuell + 2 < anzahlzeile Then
                        If zeile(aktuell + 2).Contains("TOOL CALL") Then
                            wkznr = zeile(aktuell + 2).Remove(zeile(aktuell + 2).IndexOf(" Z"))
                            wkznr = " " & wkznr.Substring(wkznr.IndexOf("LL ") + 3) & " "
                            If Not ToolNumberTB.Text.Contains(wkznr) Then
                                ToolNameTB.Text = ToolNameTB.Text + isoliert + vbCrLf
                                ToolNumberTB.Text = ToolNumberTB.Text + wkznr + vbCrLf
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        NC_Show_RTB.Clear()
        ToolNameTB.Clear()
        ToolNumberTB.Clear()
        TextBox4.Clear()
        CText.Dateiname = Nothing
        CText.Dateiinhalt = Nothing
        CText.Dateipfad = Nothing
        RecoButton.Enabled = False
        ToolnumberButton.Enabled = False
        PgmNrInsertButton.Enabled = False
        ComboBox1.SelectedIndex = -1
        kplGliederungButton.Enabled = False
        CText.Programmnummer = Nothing
        DoubleWkzCB.Enabled = False
        InsertToolDef.Enabled = False
        BtnDelToolDef.Enabled = False
        PNTtoH.Enabled = False
        LBLSave.Enabled = False
        Me.Text = "Fileworks "
    End Sub

    Private Sub HelpButtons_Click(sender As Object, e As EventArgs) Handles HelpButtons.Click
        MessageBox.Show("hier soll die Hilfe hin")
        Dim hlpDlg As New Form
        Dim TextBox12 As New TextBox
        With TextBox12
            .Location = New System.Drawing.Point(10, 10)
            .Name = "txtNeu"
            .Size = New System.Drawing.Size(450, 450)
            .TabIndex = 0
            .Visible = True
            .Text = "das wird noch ausgefüllt"
            .Multiline = True

        End With
        With hlpDlg
            .Controls.Add(TextBox12)
            .Focus()
            .Width = 550
            .Height = 520
            .Text = "H I L F E"
            .ShowDialog()
        End With
    End Sub

    Private Sub PgmNrInsertButton_Click(sender As Object, e As EventArgs) Handles PgmNrInsertButton.Click
        Dim zeilennummer As String
        Dim aktzeile As Integer = 0


        If Not CText.Dateiname = Nothing And Not CText.Programmnummer = Nothing Then

            Dim lines() = Me.NC_Show_RTB.Lines

            zeilennummer = lines(lines.Length - 2).Remove(lines(lines.Length - 2).IndexOf(" END"))

            lines(0) = "0  BEGIN PGM " & CText.Programmnummer & " MM"
            lines(lines.Length - 2) = zeilennummer & " END PGM " & CText.Programmnummer & " MM"

            ' Globale Variablen aktualisieren
            CText.Dateiname = CText.Dateipfad & CText.Programmnummer & ".H"
            Me.Text = "Fileworks   " & CText.Dateiname

            ' TextBox aktualisieren
            UpdateRTB(lines)



            '    

            '    ' erste und letzte Zeile im array ersetzen (neubauen ist einfacher als extrahieren und ersetzen)
            '    zeile(0) = "0  BEGIN PGM " & CText.Programmnummer & " MM"
            '    zeilennummer = zeile(letztezeile).Remove(zeile(letztezeile).IndexOf(" END"))

            '    ' zeilennummer = Convert.ToString(letztezeile + 2)
            '    zeile(letztezeile) = zeilennummer & " END PGM " & CText.Programmnummer & " MM"

            '    ' altes raus...
            '    NC_Show_RTB.Clear()
            '    CText.Dateiinhalt = Nothing

            '    ' Textbox und globale String dateiinhalt mit neuem Leben füllen
            '    For aktzeile = 0 To letztezeile - 1 Step 1
            '        CText.Dateiinhalt = CText.Dateiinhalt & zeile(aktzeile) & vbCrLf
            '    Next
            '    CText.Dateiinhalt = CText.Dateiinhalt & zeile(letztezeile) & vbCr
            '    NC_Show_RTB.Text = CText.Dateiinhalt

            '   
            '   
            '   
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If Not CText.Dateiname = Nothing Then
            PgmNrInsertButton.Enabled = True
            CText.Programmnummer = TextBox4.Text
        End If
    End Sub

    Private Sub DruckFenster(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Using drucken As New PrintDialog
            drucken.Document = PrintDocument1
            drucken.ShowDialog()
            MessageBox.Show(DialogResult.ToString)
        End Using

    End Sub


    Private Sub kplGliederungButton_Click(sender As Object, e As EventArgs) Handles kplGliederungButton.Click
        Dim gliederungsFenster As New Form
        Dim bildschirm As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        Dim bhoehe As Integer = bildschirm.Height
        Dim bbreite As Integer = bildschirm.Width
        Dim TextBox12 As New TextBox
        Dim DruckDialogBtn As New Button
        Dim zeile() As String = IO.File.ReadAllLines(CText.Dateiname)
        Dim anzahlzeile As Integer = zeile.Length - 1
        Dim aktuell As Integer = -1
        Dim isoliert As String


        TextBox12.Clear()
        For aktuell = aktuell + 1 To anzahlzeile
            If zeile(aktuell).Contains("* ") Then

                isoliert = zeile(aktuell).Substring(zeile(aktuell).IndexOf("* ") + 4)
                TextBox12.Text = TextBox12.Text & isoliert & vbCrLf
            End If
        Next

        With DruckDialogBtn
            .Location = New System.Drawing.Point(470, 20)
            .Text = "Drucken"
            .Size = New System.Drawing.Size(80, 25)
            .Visible = True
            .Enabled = False
        End With

        AddHandler DruckDialogBtn.Click, AddressOf DruckFenster

        With TextBox12
            .Location = New System.Drawing.Point(10, 10)
            .Name = "txtNeu"
            .Size = New System.Drawing.Size(450, 450)
            .TabIndex = 0
            .Visible = True
            .Multiline = True
            .ScrollBars = ScrollBars.Vertical
            .BackColor = Color.Black
            .ForeColor = Color.AntiqueWhite
        End With

        With gliederungsFenster
            .Controls.Add(TextBox12)
            .Controls.Add(DruckDialogBtn)
            .Focus()
            .Width = 570
            .Height = 520
            .Text = "Gliederung komplett"
            .ShowDialog()
        End With

    End Sub

    Private Sub PNTtoH_Click(sender As Object, e As EventArgs) Handles PNTtoH.Click
        Dim zeile() As String = IO.File.ReadAllLines(CText.Dateiname)
        Dim zeiletext(zeile.Length + 4) As String
        Dim anzahlzeile As Integer = zeile.Length - 1
        Dim aktuell As Integer = 1
        Dim labelnummer As String
        Dim x As String
        Dim y As String

        ToolNameTB.Clear()

        labelnummer = CText.Dateiname.Substring(CText.Dateiname.LastIndexOf("\") + 1)
        labelnummer = labelnummer.Remove(labelnummer.LastIndexOf("."))

        zeiletext(0) = "0  BEGIN PGM " & labelnummer & " MM" & vbCrLf
        zeiletext(1) = "1  * - LBL " & labelnummer & vbCrLf
        zeiletext(2) = "2  LBL " & labelnummer & vbCrLf

        x = zeile(2).Substring(8, 10).Remove(zeile(2).Substring(8, 10).IndexOf(" "))
        y = zeile(2).Substring(20, 10).Remove(zeile(2).Substring(20, 10).IndexOf(" "))

        zeiletext(3) = "3  L X" & x & " Y" & y & " Z+20 R0 FMAX M3" & vbCrLf
        zeiletext(4) = "4  CYCL CALL" & vbCrLf
        ToolNameTB.Text = zeiletext(0) + zeiletext(1) + zeiletext(2) + zeiletext(3) + zeiletext(4)

        aktuell = 2

        For aktuell = aktuell + 1 To anzahlzeile - 1

            x = zeile(aktuell).Substring(8, 10).Remove(zeile(aktuell).Substring(8, 10).IndexOf(" "))
            y = zeile(aktuell).Substring(20, 10).Remove(zeile(aktuell).Substring(20, 10).IndexOf(" "))
            zeiletext(aktuell + 1) = Convert.ToString(aktuell + 2) & "  L X" & x & " Y" & y & " R0 FMAX M99" & vbCrLf

            ToolNameTB.Text = ToolNameTB.Text + zeiletext(aktuell + 1)
        Next
        zeiletext(zeiletext.Length - 2) = Convert.ToString(zeiletext.Length - 4) & " LBL 0 " & vbCrLf
        zeiletext(zeiletext.Length - 1) = Convert.ToString(zeiletext.Length - 3) & " END PGM " & labelnummer & " MM" & vbCrLf
        ToolNameTB.Text = ToolNameTB.Text + zeiletext(zeiletext.Length - 2) + zeiletext(zeiletext.Length - 1)
        LBLSave.Enabled = True
    End Sub

    Private Sub LBLSave_Click(sender As Object, e As EventArgs) Handles LBLSave.Click
        CText.Dateiname = CText.Dateiname.Remove(CText.Dateiname.LastIndexOf(".")) & ".H"
        CText.Dateiinhalt = ToolNameTB.Text
        IO.File.WriteAllText(CText.Dateiname, CText.Dateiinhalt)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub UpdateRTB(text As String())
        rtb_SetFire = False
        NC_Show_RTB.Lines = text
        rtb_SetFire = True
        Highlight()

        NC_Show_RTB.SelectionStart = 0
        DateiSchreiben(CText.Dateiname)
    End Sub

    Private Sub InsertToolDef_Click(sender As Object, e As EventArgs) Handles InsertToolDef.Click
        Dim wkznr As String
        Dim anzahlzeile As Integer
        Dim aktuell As Integer
        Dim zeilenfund As New List(Of String)
        Dim fundzeile As New List(Of Integer)
        Dim werkzeugnummer As New List(Of String)
        Dim programm As New List(Of String)
        ' Versuch, Tool Def´s einzufügen
        ' ClearBoxes()
        programm.AddRange(NC_Show_RTB.Lines)
        'programm.AddRange(IO.File.ReadAllLines(CText.Dateiname))
        anzahlzeile = programm.Count - 1
        For aktuell = 0 To anzahlzeile

            If programm(aktuell).Contains("* -") Then


                If aktuell + 2 < anzahlzeile Then

                    If programm(aktuell + 1).Contains("TOOL CALL") Then
                        wkznr = programm(aktuell + 1).Remove(programm(aktuell + 1).IndexOf(" Z"))
                        wkznr = " " & wkznr.Substring(wkznr.IndexOf("LL ") + 3)
                        zeilenfund.Add(programm(aktuell + 1))
                        fundzeile.Add(aktuell + 1)
                        werkzeugnummer.Add(wkznr)
                    ElseIf programm(aktuell + 2).Contains("TOOL CALL") Then
                        wkznr = programm(aktuell + 2).Remove(programm(aktuell + 2).IndexOf(" Z"))
                        wkznr = " " & wkznr.Substring(wkznr.IndexOf("LL ") + 3)
                        zeilenfund.Add(programm(aktuell + 2))
                        fundzeile.Add(aktuell + 2)
                        werkzeugnummer.Add(wkznr)
                    End If
                End If
            End If

        Next

        ' Werkzeugnummer des ersten Werkzeuges an das Ende der Liste hängen
        werkzeugnummer.Add(werkzeugnummer(0))

        ' erstes Vorkommen der ersten Werkzeugnummer aus Liste löschen, funktioniert, ist aber sachlich nicht ganz richtig: 
        ' werkzeugnummer.Remove(werkzeugnummer(0))

        'erstes Element der Liste löschen, sachlich richtiges Vorgehen:
        werkzeugnummer.RemoveAt(0)

        For i As Integer = 0 To zeilenfund.Count - 1
            Dim neuezeile As String
            Dim position As Integer
            Dim znr As Integer
            position = programm.IndexOf(zeilenfund(i))

            ' Tool Def zusammenbauen, wenn die Zeile komplett fehlt.
            If Not programm(position + 1).Contains("TOOL DEF") Then
                If Int32.TryParse(programm(position).Remove(programm(position).IndexOf(" ")), znr) Then
                    neuezeile = (znr + 1).ToString & " TOOL DEF" & werkzeugnummer(i)
                Else neuezeile = "1  TOOL DEF" & werkzeugnummer(i)
                End If
                'znr = Integer.Parse(programm(position).Remove(programm(position).IndexOf(" "))) + 1
                '    neuezeile = znr.ToString & " TOOL DEF" & werkzeugnummer(i)
                programm.Insert(position + 1, neuezeile)

                ' Nummer im Tool Def aktualisieren, wenn Werkzeugnummer nicht stimmt
            ElseIf Not programm(position + 1).Contains(werkzeugnummer(i)) Then
                programm(position + 1) = programm(position + 1).Remove(programm(position).IndexOf(" ")) & " TOOL DEF" & werkzeugnummer(i)
            End If
        Next


        UpdateRTB(programm.ToArray)


        'For aktuell = 0 To programm.Count - 1
        '    CText.Dateiinhalt = CText.Dateiinhalt & programm(aktuell) & vbCrLf
        'Next
        'rtb_SetFire = False
        'NC_Show_RTB.Text = CText.Dateiinhalt
        'NC_Show_RTB.SelectionStart = 0
        'rtb_SetFire = True

    End Sub


    Private Sub BtnDelToolDef_Click(sender As Object, e As EventArgs) Handles BtnDelToolDef.Click

        Dim aktuell As Integer
        Dim zeilenfund As New List(Of String)
        Dim programm As New List(Of String)
        ' Versuch, Tool Def´s zu löschen
        ' ClearBoxes()
        programm.AddRange(NC_Show_RTB.Lines)

        For aktuell = 0 To programm.Count - 1

            If programm(aktuell).Contains("TOOL DEF") Then
                zeilenfund.Add(programm(aktuell))
            End If
        Next

        For aktuell = 0 To zeilenfund.Count - 1
            programm.Remove(zeilenfund(aktuell))
        Next


        UpdateRTB(programm.ToArray)

    End Sub

    Private Sub BtnLineNumber_Click(sender As Object, e As EventArgs) Handles BtnLineNumber.Click

        Dim aktuell As Integer
        Dim znr As Integer
        Dim linenumber As Integer = 0

        Dim programm = NC_Show_RTB.Lines

        ' neu durchnummerieren des Programmes, dabei alle Zeilen ignorieren, welche nicht mit einer Zeilennummer beginnen (z.B. innerhalb von Zyklen)

        For aktuell = 0 To programm.Length - 2
            If Int32.TryParse(programm(aktuell).Remove(programm(aktuell).IndexOf(" ")), znr) Then

                If znr <> linenumber Then

                    programm(aktuell) = linenumber.ToString + programm(aktuell).Substring(programm(aktuell).IndexOf(" "))
                End If

                linenumber = linenumber + 1
            End If
        Next

        ' Anderer Versuch, aus  Listof(String) einen String zu bauen. Leider auf Umweg über Array. Sieht nicht schneller aus...
        'Dim arr() As String = programm.ToArray
        'CText.Dateiinhalt = String.Join(vbCrLf, arr)

        ' Dies ist zumindest die kürzeste Schreibweise, ich vermute jedoch 2 Schleifen dahinter (programm.ToArray - List in Array und String.Join - Array in String)


        ' Wie folgt, bin ich normalerweise vorgegangen, um aus Listof(String) einen String zu bauen. Lediglich eine Schleife nötig. Benchmark nötig für Beurteilung
        'CText.Dateiinhalt = ""
        'For aktuell = 0 To programm.Count - 1
        '    CText.Dateiinhalt = CText.Dateiinhalt & programm(aktuell) & vbCrLf
        'Next

        'NC_Show_RTB
        UpdateRTB(programm)



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim aktuell As Integer
        Dim znr As Integer
        Dim linenumber As Integer = 0





        For aktuell = 0 To NC_Show_RTB.Lines.Length - 2

            If Int32.TryParse(NC_Show_RTB.Lines(aktuell).Remove(NC_Show_RTB.Lines(aktuell).IndexOf(" ")), znr) Then

                If znr <> linenumber Then
                    'MessageBox.Show(znr.ToString + " " + linenumber.ToString)
                    NC_Show_RTB.Select(NC_Show_RTB.Text.IndexOf(NC_Show_RTB.Lines(aktuell)), NC_Show_RTB.Lines(aktuell).Length)
                    NC_Show_RTB.SelectedText = linenumber.ToString + NC_Show_RTB.Lines(aktuell).Substring(NC_Show_RTB.Lines(aktuell).IndexOf(" "))


                    ' NC_Show_RTB.Lines(aktuell) = linenumber.ToString + NC_Show_RTB.Lines(aktuell).Substring(NC_Show_RTB.Lines(aktuell).IndexOf(" "))
                    'NC_Show_RTB.Text = NC_Show_RTB.Text.Replace(NC_Show_RTB.Lines(aktuell), linenumber.ToString + NC_Show_RTB.Lines(aktuell).Substring(NC_Show_RTB.Lines(aktuell).IndexOf(" ")))

                End If

                ' NC_Show_RTB.Text = NC_Show_RTB.Text.Replace(NC_Show_RTB.Lines(aktuell), linenumber.ToString + NC_Show_RTB.Lines(aktuell).Substring(NC_Show_RTB.Lines(aktuell).IndexOf(" ")))

                linenumber = linenumber + 1
            End If
        Next


    End Sub
End Class
