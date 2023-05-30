Imports System.Net

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents RTB As System.Windows.Forms.RichTextBox
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuOpen As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNew As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSyntax As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents OpenDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuWordWrap As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuColor As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.RTB = New System.Windows.Forms.RichTextBox
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.mnuMain = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.mnuNew = New System.Windows.Forms.MenuItem
        Me.mnuOpen = New System.Windows.Forms.MenuItem
        Me.mnuSave = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuExit = New System.Windows.Forms.MenuItem
        Me.mnuSyntax = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.OpenDialog = New System.Windows.Forms.OpenFileDialog
        Me.SaveDialog = New System.Windows.Forms.SaveFileDialog
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.mnuWordWrap = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.mnuColor = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'RTB
        '
        Me.RTB.AcceptsTab = True
        Me.RTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RTB.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTB.Location = New System.Drawing.Point(0, 0)
        Me.RTB.Name = "RTB"
        Me.RTB.Size = New System.Drawing.Size(376, 312)
        Me.RTB.TabIndex = 0
        Me.RTB.Text = ""
        Me.RTB.WordWrap = False
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 312)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(376, 22)
        Me.StatusBar1.TabIndex = 7
        Me.StatusBar1.Text = "StatusBar1"
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.mnuSyntax})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNew, Me.mnuOpen, Me.mnuSave, Me.MenuItem2, Me.mnuExit})
        Me.MenuItem1.Text = "&File"
        '
        'mnuNew
        '
        Me.mnuNew.Index = 0
        Me.mnuNew.Text = "&New"
        '
        'mnuOpen
        '
        Me.mnuOpen.Index = 1
        Me.mnuOpen.Text = "&Open"
        '
        'mnuSave
        '
        Me.mnuSave.Index = 2
        Me.mnuSave.Text = "&Save"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 3
        Me.MenuItem2.Text = "-"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 4
        Me.mnuExit.Text = "&Exit"
        '
        'mnuSyntax
        '
        Me.mnuSyntax.Index = 1
        Me.mnuSyntax.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem3, Me.MenuItem4, Me.MenuItem5, Me.mnuWordWrap, Me.MenuItem6, Me.mnuColor})
        Me.mnuSyntax.Text = "&View"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 0
        Me.MenuItem3.Text = "&Debug View"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 1
        Me.MenuItem4.Text = "&Syntax View"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 2
        Me.MenuItem5.Text = "-"
        '
        'mnuWordWrap
        '
        Me.mnuWordWrap.Index = 3
        Me.mnuWordWrap.Text = "Word Wrap"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 4
        Me.MenuItem6.Text = "-"
        '
        'mnuColor
        '
        Me.mnuColor.Index = 5
        Me.mnuColor.Text = "&Color Document"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(376, 334)
        Me.Controls.Add(Me.RTB)
        Me.Controls.Add(Me.StatusBar1)
        Me.Menu = Me.mnuMain
        Me.Name = "Form1"
        Me.Text = "RTB Wrapper, Take 4.3"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents RTBWrapper As New cRTBWrapper

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With RTBWrapper
            .bind(RTB)
            .rtfSyntax.add("<span.*?>", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("<p.*>", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("<a.*?>", True, True, Color.Blue.ToArgb)
            .rtfSyntax.add("<table.*?>", True, True, Color.Tan.ToArgb)
            .rtfSyntax.add("<tr.*?>", True, True, Color.Brown.ToArgb)
            .rtfSyntax.add("<td.*?>", True, True, Color.Brown.ToArgb)
            .rtfSyntax.add("<img.*?>", True, True, Color.Red.ToArgb)
        End With
    End Sub

    Private Sub RTBWrapper_position(ByVal PositionInfo As cRTBWrapper.cPosition) Handles RTBWrapper.position
        StatusBar1.Text = "Cursor: " & PositionInfo.Cursor & ",  Line: " & PositionInfo.CurrentLine & ", Position: " & PositionInfo.LinePosition
    End Sub

    Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpen.Click
        If OpenDialog.ShowDialog Then
            RTB.LoadFile(OpenDialog.FileName, RichTextBoxStreamType.PlainText)
            RTBWrapper.colorDocument()
        End If
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        sender.checked = RTBWrapper.toggleDebug()
    End Sub

    Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
        If SaveDialog.ShowDialog Then
            RTB.SaveFile(SaveDialog.FileName, RichTextBoxStreamType.PlainText)
        End If
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        RTB.Text = ""
        RTB.Rtf = ""
    End Sub

    Private Sub mnuWordWrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWordWrap.Click
        RTB.WordWrap = Not RTB.WordWrap
        sender.checked = RTB.WordWrap
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Dim syntaxView As New cRTFSyntax
        syntaxView.colSyntax = RTBWrapper.rtfSyntax

        If syntaxView.ShowDialog = DialogResult.OK Then
            RTBWrapper.rtfSyntax = syntaxView.colSyntax
        End If

        RTBWrapper.colorDocument()
    End Sub

    Private Sub mnuColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuColor.Click
        RTBWrapper.colorDocument()
    End Sub
End Class
