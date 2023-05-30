<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.FileSelectButton = New System.Windows.Forms.Button()
        Me.RecoButton = New System.Windows.Forms.Button()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.ToolnumberButton = New System.Windows.Forms.Button()
        Me.GenerateNumberButton = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.WkzSaveButton = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.HelpButtons = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'FileSelectButton
        '
        Me.FileSelectButton.Location = New System.Drawing.Point(27, 27)
        Me.FileSelectButton.Name = "FileSelectButton"
        Me.FileSelectButton.Size = New System.Drawing.Size(156, 28)
        Me.FileSelectButton.TabIndex = 0
        Me.FileSelectButton.Text = "Datei öffnen"
        Me.FileSelectButton.UseVisualStyleBackColor = True
        '
        'RecoButton
        '
        Me.RecoButton.Enabled = False
        Me.RecoButton.Location = New System.Drawing.Point(27, 61)
        Me.RecoButton.Name = "RecoButton"
        Me.RecoButton.Size = New System.Drawing.Size(156, 28)
        Me.RecoButton.TabIndex = 2
        Me.RecoButton.Text = "Gliederung + Sichern"
        Me.RecoButton.UseVisualStyleBackColor = True
        '
        'ResetButton
        '
        Me.ResetButton.Enabled = False
        Me.ResetButton.Location = New System.Drawing.Point(27, 284)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(156, 29)
        Me.ResetButton.TabIndex = 3
        Me.ResetButton.Text = "Reset"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'ToolnumberButton
        '
        Me.ToolnumberButton.Enabled = False
        Me.ToolnumberButton.Location = New System.Drawing.Point(27, 95)
        Me.ToolnumberButton.Name = "ToolnumberButton"
        Me.ToolnumberButton.Size = New System.Drawing.Size(156, 28)
        Me.ToolnumberButton.TabIndex = 4
        Me.ToolnumberButton.Text = "Wkz+Nummer extrahieren"
        Me.ToolnumberButton.UseVisualStyleBackColor = True
        '
        'GenerateNumberButton
        '
        Me.GenerateNumberButton.Location = New System.Drawing.Point(27, 404)
        Me.GenerateNumberButton.Name = "GenerateNumberButton"
        Me.GenerateNumberButton.Size = New System.Drawing.Size(200, 38)
        Me.GenerateNumberButton.TabIndex = 5
        Me.GenerateNumberButton.Text = "Programmnummerngenerator"
        Me.GenerateNumberButton.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Axa6", "Axa5", "Axa4"})
        Me.ComboBox1.Location = New System.Drawing.Point(27, 377)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(200, 21)
        Me.ComboBox1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 357)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Maschine auswählen"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.MenuText
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.Info
        Me.TextBox1.Location = New System.Drawing.Point(248, 27)
        Me.TextBox1.MaxLength = 9999999
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(459, 480)
        Me.TextBox1.TabIndex = 8
        Me.TextBox1.Tag = ""
        '
        'WkzSaveButton
        '
        Me.WkzSaveButton.Location = New System.Drawing.Point(27, 219)
        Me.WkzSaveButton.Name = "WkzSaveButton"
        Me.WkzSaveButton.Size = New System.Drawing.Size(156, 27)
        Me.WkzSaveButton.TabIndex = 9
        Me.WkzSaveButton.Text = "Werkzeuge speichern"
        Me.WkzSaveButton.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.MenuText
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Fuchsia
        Me.TextBox2.Location = New System.Drawing.Point(723, 27)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox2.Size = New System.Drawing.Size(170, 480)
        Me.TextBox2.TabIndex = 10
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.InfoText
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.Yellow
        Me.TextBox3.Location = New System.Drawing.Point(912, 27)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox3.Size = New System.Drawing.Size(177, 480)
        Me.TextBox3.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(261, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Programm"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(733, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Werkzeugliste"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(925, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Werkzeugnummern"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(27, 252)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(156, 26)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Nummern speichern"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(27, 466)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(200, 20)
        Me.TextBox4.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 445)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 17)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Ausgabe"
        '
        'HelpButtons
        '
        Me.HelpButtons.Location = New System.Drawing.Point(27, 319)
        Me.HelpButtons.Name = "HelpButtons"
        Me.HelpButtons.Size = New System.Drawing.Size(156, 25)
        Me.HelpButtons.TabIndex = 18
        Me.HelpButtons.Text = "HILFE"
        Me.HelpButtons.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1150, 570)
        Me.Controls.Add(Me.HelpButtons)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.WkzSaveButton)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.GenerateNumberButton)
        Me.Controls.Add(Me.ToolnumberButton)
        Me.Controls.Add(Me.ResetButton)
        Me.Controls.Add(Me.RecoButton)
        Me.Controls.Add(Me.FileSelectButton)
        Me.Name = "Form1"
        Me.Text = "Fileworks"
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
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents WkzSaveButton As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents HelpButtons As Button
End Class
