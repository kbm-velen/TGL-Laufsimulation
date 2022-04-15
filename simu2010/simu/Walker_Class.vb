Option Explicit On
Public Class clsWalker
    Dim posX As Integer
    Dim posY As Integer
    Dim Farbe As Color = Color.FromArgb(Integer.Parse(45700))
    Dim groesse As Byte

    Property Pgroesse() As Byte
        Get
            Return groesse
        End Get
        Set(ByVal wert As Byte)
            groesse = wert
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

    Property PposX() As Integer
        Get
            Return posX
        End Get
        Set(ByVal wert As Integer)
            posX = wert
        End Set
    End Property

    Property PposY() As Integer
        Get
            Return posY
        End Get
        Set(ByVal wert As Integer)
            posY = wert
        End Set
    End Property

    Sub New()
        posX = -10
        posY = -10
        Farbe = Color.Black
        groesse = 3
    End Sub



End Class
