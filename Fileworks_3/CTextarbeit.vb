Public Class CTextarbeit
    Private _dateiinhalt As String
    Private _dateiname As String
    Private _dateipfad As String
    Private _programmnummer As String
    Private _kommandozeile() As String
    Private _dateizeilenweise As New List(Of String)


    Public Property DateiZeilen As List(Of String)
        Get
            Return _dateizeilenweise
        End Get
        Set(value As List(Of String))
            Dim builder As New System.Text.StringBuilder
            _dateizeilenweise = value
            ' _dateiinhalt = _dateizeilenweise.ToString
            For Each line In _dateizeilenweise
                builder.Append(line & vbCrLf)
            Next
            _dateiinhalt = builder.ToString
        End Set
    End Property


    Public Function LeseFile(datei As String) As String
        Dim builder As New System.Text.StringBuilder

        _dateiinhalt = Nothing

        _dateizeilenweise.Clear()
        _dateizeilenweise.AddRange(IO.File.ReadAllLines(datei))

        _dateiname = datei

        For Each line In _dateizeilenweise
            builder.Append(line & vbCrLf)
        Next
        _dateiinhalt = builder.ToString
        Return _dateiinhalt
    End Function

    Public Property KommandoArgument As String()
        Get
            Return _kommandozeile
        End Get
        Set(value As String())
            If value.Length > 1 Then _dateiname = value(1)
            _kommandozeile = value
        End Set
    End Property

    Public Property Dateiinhalt() As String
        Get
            Return _dateiinhalt
        End Get
        Set(value As String)
            _dateiinhalt = value

        End Set
    End Property

    Public Property Dateiname As String
        Get
            Return _dateiname
        End Get
        Set(value As String)
            _dateiname = value

        End Set
    End Property

    Public Property Dateipfad As String
        Get
            ' Nul Exception fangen
            If _dateiname <> Nothing Then
                ' Backslash am Ende sichern
                _dateipfad = New IO.FileInfo(_dateiname).DirectoryName
                If Not _dateipfad.EndsWith("\") Then _dateipfad &= "\"
            End If
            Return _dateipfad
        End Get
        Set(value As String)
            'If value <> Nothing Then ' Nul Exception fangen
            ' Backslash am Ende sichern
            'If Not value.EndsWith("\") Then value = value & "\"
            'End If
            _dateipfad = value
        End Set
    End Property

    Public Property Programmnummer As String
        Get
            Return _programmnummer
        End Get
        Set(value As String)
            _programmnummer = value
        End Set
    End Property
End Class
