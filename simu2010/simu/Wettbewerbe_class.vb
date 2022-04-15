Option Explicit On
Public Class clsWettbewerb

    Dim name As String
    Dim Startzeit As String
    Dim zeit As String
    Dim ZeitL As Integer
    Dim ZeitSM As Integer
    Dim ZeitSW As Integer
    Dim Farbe As Color = Color.FromArgb(Integer.Parse(45700))
    Dim laenge As Integer
    Dim strecke As String

    Function ausgabe() As String
        Dim namelang As String

        namelang = name
        While namelang.Length < 30
            namelang = namelang & " "
        End While
        namelang = namelang & " "

        ausgabe = namelang & vbTab & " " & Startzeit & " | " & vbTab & ZeitL & " min | " & vbTab & ZeitSM & "/" & ZeitSW & " min | " _
         & vbTab & laenge & " m " & vbTab & strecke
    End Function

    Function ausgabeDatei() As String
        'MsgBox(ColorDialog1.Color.ToArgb)
        ausgabeDatei = name & ";" & Startzeit & ";" & ZeitL & ";" & ZeitSM & ";" & ZeitSW & ";" & laenge & ";" & Farbe.ToArgb & ";" & strecke
    End Function

    Sub New()
        name = "Mini-Marathon"
        Startzeit = "10:15"
        zeit = "10:15"
        ZeitL = 6
        ZeitSM = 3 'schnellster Mann
        ZeitSW = 3 'schnellste Frau
        Farbe = Color.Black
        laenge = 491
        strecke = ""
    End Sub

    Property PStartzeit() As String
        Get
            Return Startzeit
        End Get
        Set(ByVal wert As String)
            Startzeit = wert
        End Set
    End Property

    Property Pzeit() As String
        Get
            Return zeit
        End Get
        Set(ByVal wert As String)
            zeit = wert
        End Set
    End Property

    Property Plaenge() As Integer
        Get
            Return laenge
        End Get
        Set(ByVal wert As Integer)
            If wert < 1 Then
                wert = 1
            End If
            laenge = wert
        End Set
    End Property

    Property PFarbe() As Color
        Get
            Return Farbe
        End Get
        Set(ByVal wert As Color)
            Farbe = wert
        End Set
    End Property

    Property PZeitSM() As Integer
        Get
            Return ZeitSM
        End Get
        Set(ByVal wert As Integer)
            If wert < 1 Then
                wert = 1
            End If
            ZeitSM = wert
        End Set
    End Property

    Property PZeitSW() As Integer
        Get
            Return ZeitSW
        End Get
        Set(ByVal wert As Integer)
            If wert < 1 Then
                wert = 1
            End If
            ZeitSW = wert
        End Set
    End Property

    Property PZeitL() As Integer
        Get
            Return ZeitL
        End Get
        Set(ByVal wert As Integer)
            If wert < 1 Then
                wert = 1
            End If
            ZeitL = wert
        End Set
    End Property

    Property PName() As String
        Get
            Return name
        End Get
        Set(ByVal wert As String)
            name = wert
        End Set
    End Property

    Property PStrecke() As String
        Get
            Return strecke
        End Get
        Set(ByVal wert As String)
            strecke = wert
        End Set
    End Property
End Class
