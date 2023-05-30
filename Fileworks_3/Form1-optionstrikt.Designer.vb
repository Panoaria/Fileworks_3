<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.FileSelectButton = New System.Windows.Forms.Button()
        Me.RecoButton = New System.Windows.Forms.Button()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.ToolnumberButton = New System.Windows.Forms.Button()
        Me.GenerateNumberButton = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.WkzSaveButton = New System.Windows.Forms.Button()
        Me.ToolNameTB = New System.Windows.Forms.TextBox()
        Me.ToolNumberTB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.HelpButtons = New System.Windows.Forms.Button()
        Me.PgmNrInsertButton = New System.Windows.Forms.Button()
        Me.DoubleWkzCB = New System.Windows.Forms.CheckBox()
        Me.NC_Show_RTB = New System.Windows.Forms.RichTextBox()
        Me.kplGliederungButton = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PNTtoH = New System.Windows.Forms.Button()
        Me.LBLSave = New System.Windows.Forms.Button()
        Me.InsertToolDef = New System.Windows.Forms.Button()
        Me.BtnDelToolDef = New System.Windows.Forms.Button()
        Me.BtnLineNumber = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FileSelectButton
        '
        Me.FileSelectButton.Location = New System.Drawing.Point(3, 12)
        Me.FileSelectButton.Name = "FileSelectButton"
        Me.FileSelectButton.Size = New System.Drawing.Size(156, 28)
        Me.FileSelectButton.TabIndex = 0
        Me.FileSelectButton.Text = "Datei öffnen"
        Me.FileSelectButton.UseVisualStyleBackColor = True
        '
        'RecoButton
        '
        Me.RecoButton.Enabled = False
        Me.RecoButton.ForeColor = System.Drawing.Color.Red
        Me.RecoButton.Location = New System.Drawing.Point(4, 46)
        Me.RecoButton.Name = "RecoButton"
        Me.RecoButton.Size = New System.Drawing.Size(156, 28)
        Me.RecoButton.TabIndex = 1
        Me.RecoButton.Text = "Gliederung + Sichern"
        Me.RecoButton.UseVisualStyleBackColor = True
        '
        'ResetButton
        '
        Me.ResetButton.Location = New System.Drawing.Point(4, 250)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(156, 29)
        Me.ResetButton.TabIndex = 5
        Me.ResetButton.Text = "Reset"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'ToolnumberButton
        '
        Me.ToolnumberButton.Enabled = False
        Me.ToolnumberButton.Location = New System.Drawing.Point(4, 80)
        Me.ToolnumberButton.Name = "ToolnumberButton"
        Me.ToolnumberButton.Size = New System.Drawing.Size(156, 28)
        Me.ToolnumberButton.TabIndex = 2
        Me.ToolnumberButton.Text = "Wkz+Nummer extrahieren"
        Me.ToolnumberButton.UseVisualStyleBackColor = True
        '
        'GenerateNumberButton
        '
        Me.GenerateNumberButton.Location = New System.Drawing.Point(3, 360)
        Me.GenerateNumberButton.Name = "GenerateNumberButton"
        Me.GenerateNumberButton.Size = New System.Drawing.Size(156, 26)
        Me.GenerateNumberButton.TabIndex = 8
        Me.GenerateNumberButton.Text = "Programmnummerngenerator"
        Me.GenerateNumberButton.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Axa6", "Axa5", "Axa4"})
        Me.ComboBox1.Location = New System.Drawing.Point(3, 333)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(156, 21)
        Me.ComboBox1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 313)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Maschine auswählen"
        '
        'WkzSaveButton
        '
        Me.WkzSaveButton.Enabled = False
        Me.WkzSaveButton.Location = New System.Drawing.Point(4, 171)
        Me.WkzSaveButton.Name = "WkzSaveButton"
        Me.WkzSaveButton.Size = New System.Drawing.Size(156, 27)
        Me.WkzSaveButton.TabIndex = 9
        Me.WkzSaveButton.Text = "Werkzeuge speichern"
        Me.WkzSaveButton.UseVisualStyleBackColor = True
        '
        'ToolNameTB
        '
        Me.ToolNameTB.AllowDrop = True
        Me.ToolNameTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ToolNameTB.BackColor = System.Drawing.SystemColors.MenuText
        Me.ToolNameTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolNameTB.ForeColor = System.Drawing.Color.Fuchsia
        Me.ToolNameTB.Location = New System.Drawing.Point(618, 24)
        Me.ToolNameTB.Multiline = True
        Me.ToolNameTB.Name = "ToolNameTB"
        Me.ToolNameTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ToolNameTB.Size = New System.Drawing.Size(283, 650)
        Me.ToolNameTB.TabIndex = 10
        '
        'ToolNumberTB
        '
        Me.ToolNumberTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ToolNumberTB.BackColor = System.Drawing.SystemColors.InfoText
        Me.ToolNumberTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolNumberTB.ForeColor = System.Drawing.Color.Yellow
        Me.ToolNumberTB.Location = New System.Drawing.Point(907, 24)
        Me.ToolNumberTB.Multiline = True
        Me.ToolNumberTB.Name = "ToolNumberTB"
        Me.ToolNumberTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ToolNumberTB.Size = New System.Drawing.Size(141, 650)
        Me.ToolNumberTB.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(175, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Programm"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(615, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Werkzeugliste"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(904, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Werkzeugnummern"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(4, 204)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(156, 26)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Nummern speichern"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(4, 407)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(156, 20)
        Me.TextBox4.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 389)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Programmnummer"
        '
        'HelpButtons
        '
        Me.HelpButtons.Location = New System.Drawing.Point(4, 285)
        Me.HelpButtons.Name = "HelpButtons"
        Me.HelpButtons.Size = New System.Drawing.Size(156, 25)
        Me.HelpButtons.TabIndex = 6
        Me.HelpButtons.Text = "HILFE"
        Me.HelpButtons.UseVisualStyleBackColor = True
        '
        'PgmNrInsertButton
        '
        Me.PgmNrInsertButton.Enabled = False
        Me.PgmNrInsertButton.Location = New System.Drawing.Point(4, 433)
        Me.PgmNrInsertButton.Name = "PgmNrInsertButton"
        Me.PgmNrInsertButton.Size = New System.Drawing.Size(156, 27)
        Me.PgmNrInsertButton.TabIndex = 9
        Me.PgmNrInsertButton.Text = "Nummer in PGM übernehmen"
        Me.PgmNrInsertButton.UseVisualStyleBackColor = True
        '
        'DoubleWkzCB
        '
        Me.DoubleWkzCB.AutoSize = True
        Me.DoubleWkzCB.Enabled = False
        Me.DoubleWkzCB.Location = New System.Drawing.Point(0, 114)
        Me.DoubleWkzCB.Name = "DoubleWkzCB"
        Me.DoubleWkzCB.Size = New System.Drawing.Size(169, 17)
        Me.DoubleWkzCB.TabIndex = 3
        Me.DoubleWkzCB.Text = "doppelte Werkzeuge zulassen"
        Me.DoubleWkzCB.UseVisualStyleBackColor = True
        '
        'NC_Show_RTB
        '
        Me.NC_Show_RTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NC_Show_RTB.BackColor = System.Drawing.SystemColors.InfoText
        Me.NC_Show_RTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NC_Show_RTB.ForeColor = System.Drawing.SystemColors.Window
        Me.NC_Show_RTB.Location = New System.Drawing.Point(169, 25)
        Me.NC_Show_RTB.Name = "NC_Show_RTB"
        Me.NC_Show_RTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.NC_Show_RTB.Size = New System.Drawing.Size(443, 650)
        Me.NC_Show_RTB.TabIndex = 22
        Me.NC_Show_RTB.Text = ""
        Me.NC_Show_RTB.WordWrap = False
        '
        'kplGliederungButton
        '
        Me.kplGliederungButton.Enabled = False
        Me.kplGliederungButton.Location = New System.Drawing.Point(4, 137)
        Me.kplGliederungButton.Name = "kplGliederungButton"
        Me.kplGliederungButton.Size = New System.Drawing.Size(156, 28)
        Me.kplGliederungButton.TabIndex = 4
        Me.kplGliederungButton.Text = "Gliederung komplett"
        Me.kplGliederungButton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.FileSelectButton)
        Me.Panel1.Controls.Add(Me.RecoButton)
        Me.Panel1.Controls.Add(Me.kplGliederungButton)
        Me.Panel1.Controls.Add(Me.PgmNrInsertButton)
        Me.Panel1.Controls.Add(Me.ToolnumberButton)
        Me.Panel1.Controls.Add(Me.TextBox4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.HelpButtons)
        Me.Panel1.Controls.Add(Me.DoubleWkzCB)
        Me.Panel1.Controls.Add(Me.WkzSaveButton)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.ResetButton)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.GenerateNumberButton)
        Me.Panel1.Location = New System.Drawing.Point(3, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(166, 470)
        Me.Panel1.TabIndex = 25
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PNTtoH
        '
        Me.PNTtoH.Enabled = False
        Me.PNTtoH.Location = New System.Drawing.Point(7, 516)
        Me.PNTtoH.Name = "PNTtoH"
        Me.PNTtoH.Size = New System.Drawing.Size(156, 23)
        Me.PNTtoH.TabIndex = 26
        Me.PNTtoH.Text = "PNT konvertieren"
        Me.PNTtoH.UseVisualStyleBackColor = True
        '
        'LBLSave
        '
        Me.LBLSave.Enabled = False
        Me.LBLSave.Location = New System.Drawing.Point(7, 488)
        Me.LBLSave.Name = "LBLSave"
        Me.LBLSave.Size = New System.Drawing.Size(156, 22)
        Me.LBLSave.TabIndex = 27
        Me.LBLSave.Text = "Label speichern"
        Me.LBLSave.UseVisualStyleBackColor = True
        '
        'InsertToolDef
        '
        Me.InsertToolDef.Enabled = False
        Me.InsertToolDef.Location = New System.Drawing.Point(6, 545)
        Me.InsertToolDef.Name = "InsertToolDef"
        Me.InsertToolDef.Size = New System.Drawing.Size(156, 39)
        Me.InsertToolDef.TabIndex = 28
        Me.InsertToolDef.Text = "Tool Def einfügen"
        Me.InsertToolDef.UseVisualStyleBackColor = True
        '
        'BtnDelToolDef
        '
        Me.BtnDelToolDef.Enabled = False
        Me.BtnDelToolDef.Location = New System.Drawing.Point(7, 590)
        Me.BtnDelToolDef.Name = "BtnDelToolDef"
        Me.BtnDelToolDef.Size = New System.Drawing.Size(155, 21)
        Me.BtnDelToolDef.TabIndex = 29
        Me.BtnDelToolDef.Text = "Tool Def löschen"
        Me.BtnDelToolDef.UseVisualStyleBackColor = True
        '
        'BtnLineNumber
        '
        Me.BtnLineNumber.Location = New System.Drawing.Point(7, 617)
        Me.BtnLineNumber.Name = "BtnLineNumber"
        Me.BtnLineNumber.Size = New System.Drawing.Size(155, 23)
        Me.BtnLineNumber.TabIndex = 30
        Me.BtnLineNumber.Text = "Neu nummerieren"
        Me.BtnLineNumber.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 646)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1050, 689)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.BtnLineNumber)
        Me.Controls.Add(Me.BtnDelToolDef)
        Me.Controls.Add(Me.InsertToolDef)
        Me.Controls.Add(Me.LBLSave)
        Me.Controls.Add(Me.PNTtoH)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.NC_Show_RTB)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolNumberTB)
        Me.Controls.Add(Me.ToolNameTB)
        Me.Name = "Form1"
        Me.Text = "Fileworks"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FileSelectButton As Button
    Friend WithEvents RecoButton As Button
    Friend WithEvents ResetButton As Button
    Friend WithEvents ToolnumberButton As Button
    Friend WithEvents GenerateNumberButton As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents WkzSaveButton As Button
    Friend WithEvents ToolNameTB As TextBox
    Friend WithEvents ToolNumberTB As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents HelpButtons As Button
    Friend WithEvents PgmNrInsertButton As Button
    Friend WithEvents DoubleWkzCB As CheckBox
    Friend WithEvents NC_Show_RTB As RichTextBox
    Friend WithEvents kplGliederungButton As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents PNTtoH As Button
    Friend WithEvents LBLSave As Button
    Friend WithEvents InsertToolDef As Button
    Friend WithEvents BtnDelToolDef As Button
    Friend WithEvents BtnLineNumber As Button
    Friend WithEvents Button2 As Button
End Class
