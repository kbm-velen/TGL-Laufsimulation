Option Explicit On
Imports System.IO

Public Class Form1
    Dim projektname As String
    Dim allWett As New ArrayList
    Dim Wettbewerbszahl As Byte
    Dim m_Points As New List(Of Point)
    Private m_Backbuffer As Bitmap
    Dim faktor(20) As Double
    Dim walker As New ArrayList
    Dim simFaktor As Double
    Dim takt As Byte
    Dim zeitpfad As String
    Dim iniz As New INIDatei(zeitpfad)
    Dim wwwPfad As String   'für Zeiten-Datei
    'Dim cssPfad As String   'für CSS-Datei

    '-----------------------------------------------------------------------------------
    ' Strecke aufzeichnen und zeichnen
    '-----------------------------------------------------------------------------------
    Private Sub DrawStrecke(ByVal Polygon As Point(), _
        ByVal Color As Color, _
        ByVal Clear As Boolean, _
        Optional ByVal Size As Integer = 1)

        Dim posx As Integer
        Dim posy As Integer

        posy = PictureBox1.Height
        posx = PictureBox1.Width
        If Clear Then m_Backbuffer = New Bitmap(posx, posy)
        posx = 10
        posy = 10
        Using g = Graphics.FromImage(m_Backbuffer), Pen = New Pen(Color, Size)
            'g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            'g.DrawImage(PictureBox1.Image, posx, posy, PictureBox1.Width, PictureBox1.Height)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Pen.LineJoin = Drawing2D.LineJoin.Bevel
            If Polygon.Length >= 2 Then Call g.DrawLines(Pen, Polygon)

        End Using
    
      

        Call PictureBox1.Invalidate()
    End Sub

    '------------------------------------------------------------------------------------
    Public Function PicResizeByPercent(ByVal SourceImage As String, ByVal Percent As Short) As Bitmap
        Dim InputBitmap As New Bitmap(SourceImage)
        Dim NewWidth As Integer = ((Percent / 100) * InputBitmap.Width)
        Dim SizeFactor As Decimal = NewWidth / InputBitmap.Width
        Dim NewHeigth As Integer = SizeFactor * InputBitmap.Height
        Dim OutputBitmap As New Bitmap(System.Drawing.Image.FromFile(SourceImage), NewWidth, NewHeigth)
        PicResizeByPercent = OutputBitmap
        InputBitmap.Dispose()
        OutputBitmap.Dispose()
    End Function

    Public Function NewRatio(ByVal Width As Integer, ByVal Heigth As Integer, ByVal NewWidth As Integer)
        Dim SizeFactor As Decimal = NewWidth / Width
        Dim NewHeigth As Integer = Heigth * SizeFactor
        Return NewHeigth
    End Function
    '------------------------------------------------------------------------------------

    Private Sub PictureBox1_Paint(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.PaintEventArgs)

        Call e.Graphics.DrawImage(m_Backbuffer, New Point(0, 0))

        ' zeichnen der Läuferpositionen
        Dim farbe As New SolidBrush(Color.AliceBlue)
        Dim font1 As New Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Point)
        e.Graphics.DrawString(DTP_Zeit.Text, font1, Brushes.Black, PictureBox1.Width / 2, 10)
        If (TabControl1.SelectedIndex = 2) And (Timer1.Enabled = True) Then
            'schnellster und langsamster
            For z = 0 To 40 'Wettbewerbszahl - 1
                farbe.Color = walker(z).PFarbe
                e.Graphics.FillEllipse(farbe, walker(z).PposX, walker(z).PposY, walker(z).Pgroesse, walker(z).Pgroesse)
            Next
            'Kreis für schnellste Frau
            Dim stift As New Pen(Color.Red)
            stift.Width = 2
            For z = 41 To 60 'Wettbewerbszahl - 1
                stift.Color = walker(z).PFarbe
                e.Graphics.DrawEllipse(stift, walker(z).PposX, walker(z).PposY, walker(z).Pgroesse, walker(z).Pgroesse)
            Next
            stift.Dispose()
        End If
    End Sub

    Private Sub PictureBox1_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If CheckBox1.Checked = True Then
            m_Points.Add(e.Location)
            Call DrawStrecke(m_Points.ToArray(), Color.FromArgb(150, Color.Red), True, 3)
            lblNumPoints.Text = String.Format("Strecke: {0} Punkt(e)", m_Points.Count)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        'aufzeichnung einer Strecke starten und stoppen
        'false: aufzeichnung beendet
        'true: Aufzeichnung starten
        If CheckBox1.Checked = True Then
            CheckBox1.Text = "Aufzeichnung stoppen"
            m_Points.Clear()
            m_Backbuffer = New Bitmap(PictureBox1.Width, PictureBox1.Height)
            lblNumPoints.Text = ""
            lblNumPoints.Visible = True
        Else
            'Points speichern
            ' die StreckenPoint speichern in projektname_1.weg
            If m_Points.Count = 0 Then
                MsgBox("Keine Punkte zu speichern!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Warnung")
                CheckBox1.Text = "Strecke erstellen"
                Exit Sub
            End If

            Dim sr As StreamWriter

            lblNumPoints.Visible = False
            SaveFileDialog1.InitialDirectory = Path.GetDirectoryName(projektname)
            SaveFileDialog1.Filter = "Laufsimulation-Dateien (*.weg)|*.weg"
            If (SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                sr = File.CreateText(SaveFileDialog1.FileName)
                For Each Punkt As Point In m_Points
                    sr.WriteLine(Punkt)
                Next
                ListBox2.Items.Add(Path.GetFileName(SaveFileDialog1.FileName))
                cmb_Strecken.Items.Add(Path.GetFileName(SaveFileDialog1.FileName))
                sr.Flush()
                sr.Close()
            End If
            CheckBox1.Text = "Strecke erstellen"
        End If
    End Sub

    '-----------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------

    Public Function App_Path() As String
        'Return System.IO.Path.GetDirectoryName( _
        '   System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        Return System.IO.Path.GetDirectoryName( _
            System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
    End Function


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x As Integer
        Dim converter As System.ComponentModel.TypeConverter = _
        System.ComponentModel.TypeDescriptor.GetConverter(GetType(Point))

        TabControl1.Width = 800 'Me.Width - 10
        TabControl1.Height = 700 'Me.Height - 60
        PictureBox1.Location = CType(Converter.ConvertFromString("188;96"), Point)
        PictureBox1.Width = 600
        PictureBox1.Height = 600
        ListBox1.Height = TabControl1.Height - 160
        ListBox2.Height = TabControl1.Height - 160
        GroupBox2.Height = ListBox1.Height + 20
        'TabControl1.SelectedIndex = 2

        For x = 0 To 20
            allWett.Add(New clsWettbewerb)
        Next
        For x = 0 To 60
            walker.Add(New clsWalker)
        Next
        m_Backbuffer = New Bitmap(PictureBox1.Width, PictureBox1.Height)

    End Sub

    Private Sub MNU_V_neu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_V_neu.Click
        'Speicherort vom User festlegenlassen
        'dort Datei anlegen um darin alle Daten zu sammeln
        SaveFileDialog1.Filter = "Laufsimulation-Dateien (*.lsi)|*.lsi"

        If (SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            projektname = SaveFileDialog1.FileName
            IO.File.Create(projektname)

            'MNU_V_Speichern.Enabled = True
            TabControl1.Visible = True

            Me.Text = "Laufveranstaltung Simulator: " & SaveFileDialog1.FileName
            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            ' *.weg anzeigen, falls vorhanden
            Call weg_listen()
            Wettbewerbszahl = 0
        End If
    End Sub

    Private Sub weg_listen()
        Dim pfad As String
        pfad = Path.GetDirectoryName(projektname)
        'Strecken in CMB_Strecken auflisten
        'Strecken in Listbox2 auflisten
        Dim i As Int32
        Try
            Dim arrAllFiles() As String = Directory.GetFiles(pfad, "*.weg")

            cmb_Strecken.Items.Clear()
            ListBox2.Items.Clear()
            For i = 0 To arrAllFiles.Length - 1
                pfad = Path.GetFileName(arrAllFiles(i))
                cmb_Strecken.Items.Add(pfad)
                ListBox2.Items.Add(pfad)
            Next
            'Label1.Text = CStr(arrAllFiles.Length)
        Catch Except As Exception
            MsgBox(Except.Message & vbNewLine & _
                    "Möglicherweise ist die Pfadangabe falsch.", _
                    MsgBoxStyle.Exclamation)
            cmb_Strecken.Items.Clear()
            'Label1.Text = CStr(0)
        End Try

    End Sub

    Private Sub MNU_V_öffnen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_V_öffnen.Click
        'LSI-Datei laden
        'bmp-Datei laden

        Dim returnValue As String

        returnValue = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        OpenFileDialog1.InitialDirectory = returnValue & "\laufsimulation"
        OpenFileDialog1.FileName = ""

        OpenFileDialog1.Filter = "Laufsimulation-Dateien (*.lsi)|*.lsi"
        If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            projektname = OpenFileDialog1.FileName
            Me.Text = "Laufveranstaltung Simulator: " & OpenFileDialog1.FileName
            
            Call weg_listen()
            'Bild-Datei laden
            Try
                PictureBox1.Image = Image.FromFile(projektname.Replace(".lsi", ".jpg"))
            Catch
            End Try
            
            'Datei einlesen und in Listbox anzeigen und in clsWettbewerbe eintragen
            'alleWettbewerbe(20)
            ' Open the file to read from.
            Dim sr As StreamReader = File.OpenText(projektname)
            Dim s As String
            Dim t(7) As String
            Dim Zeit(2) As String
            Dim ZeitA As String

            Wettbewerbszahl = 0
            ListBox1.Items.Clear()
            Do While sr.Peek() >= 0
                s = sr.ReadLine()
                t = s.Split(";")
                With allWett(Wettbewerbszahl)
                    .PName = t(0)
                    .PStartzeit = t(1)
                    .Pzeit = t(1)
                    .PZeitL = t(2)
                    .PZeitSM = t(3)
                    .PZeitSW = t(4)
                    .Plaenge = t(5)
                    .PFarbe = Color.FromArgb(Integer.Parse(t(6)))
                    .PStrecke = t(7)
                End With
                ListBox1.Items.Add(allWett(Wettbewerbszahl).ausgabe)
                Wettbewerbszahl += 1
            Loop
            sr.Close()
            
            ZeitA = allWett(0).PStartzeit
            Zeit = ZeitA.Split(":")
            DTP_Zeit.Value = New DateTime(2001, 10, 20, Zeit(0), Zeit(1), 0)

            PictureBox1.Visible = False

            TabControl1.SelectedIndex = 1
            TabControl1.Visible = True
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Value >= NumericUpDown2.Value Then
            NumericUpDown1.Value = NumericUpDown2.Value - 1
        End If
    End Sub

    Private Sub NumericUpDown5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown5.ValueChanged
        If NumericUpDown5.Value >= NumericUpDown2.Value Then
            NumericUpDown5.Value = NumericUpDown2.Value - 1
        End If
    End Sub


    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown2.ValueChanged
        If NumericUpDown2.Value <= NumericUpDown1.Value Then
            NumericUpDown2.Value = NumericUpDown1.Value + 1
        End If
    End Sub


    Private Sub Btn_Farbe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Farbe.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Btn_Farbe.BackColor = ColorDialog1.Color
            'MsgBox(ColorDialog1.Color.ToArgb)
        End If
    End Sub


    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        'Klick in  Liste soll die Daten nach oben übertragen zum editieren
        Dim zeit As New DateTime(2009, 3, 28)
        Dim start As String
        Dim provider As IFormatProvider

        If ListBox1.SelectedIndex = -1 Then
            Exit Sub
            btn_Wettb_edit.Enabled = False
            btn_wettb_delete.Enabled = False
        End If
        btn_Wettb_edit.Enabled = True
        btn_wettb_delete.Enabled = True
        txt_Wettbewerb.Text = allWett(ListBox1.SelectedIndex).PName

        start = allWett(ListBox1.SelectedIndex).PStartzeit
        zeit = CType(start, IConvertible).ToDateTime(provider)
        DateTimePicker1.Value = zeit

        NumericUpDown1.Value = allWett(ListBox1.SelectedIndex).PZeitSM
        NumericUpDown5.Value = allWett(ListBox1.SelectedIndex).PZeitSW
        NumericUpDown2.Value = allWett(ListBox1.SelectedIndex).PZeitL

        NumericUpDown3.Value = allWett(ListBox1.SelectedIndex).Plaenge
        Btn_Farbe.BackColor = allWett(ListBox1.SelectedIndex).PFarbe

        'Prüfen ob Dateiname im Pfad vorhanden ist
        cmb_Strecken.Text = allWett(ListBox1.SelectedIndex).PStrecke

        Call Strecke_Zeichnen(cmb_Strecken.Text, Btn_Farbe.BackColor)
    End Sub


    Private Sub btn_Wettb_hinzu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Wettb_hinzu.Click
        ' Daten speichern

        If Wettbewerbszahl > 19 Then
            MessageBox.Show("max. 20 Wettbewerbe sind möglich", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        If cmb_Strecken.Text = "Strecke zuordnen" Then
            MessageBox.Show("Bitte Strecke zuordnen!", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        'Daten in Listbox anzeigen
        With allWett(Wettbewerbszahl)
            .PName = txt_Wettbewerb.Text
            .PStartzeit = DateTimePicker1.Value.ToString("H:mm")
            .PZeitSM = NumericUpDown1.Value
            .PZeitSW = NumericUpDown5.Value
            .PZeitL = NumericUpDown2.Value
            .Plaenge = NumericUpDown3.Value
            .PFarbe = Btn_Farbe.BackColor
            .pStrecke = cmb_Strecken.Text
        End With

        ListBox1.Items.Add(allWett(Wettbewerbszahl).ausgabe)

        Dim sw As StreamWriter
        'Speichern der Daten in projektname.lsi
        sw = File.AppendText(projektname)
        sw.WriteLine(allWett(Wettbewerbszahl).ausgabeDatei)
        sw.Flush()
        sw.Close()
        Wettbewerbszahl = Wettbewerbszahl + 1
    End Sub

    Private Sub btn_Wettb_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Wettb_edit.Click
        ' Daten speichern

        ' die StreckenPoint speichern in projektname_1.weg
        Dim zeile As Byte

        zeile = ListBox1.SelectedIndex
        'Daten in Listbox anzeigen
        With allWett(zeile)
            .PName = txt_Wettbewerb.Text
            .PStartzeit = DateTimePicker1.Value.ToString("H:mm")
            .PZeitSM = NumericUpDown1.Value
            .PZeitSW = NumericUpDown5.Value
            .PZeitL = NumericUpDown2.Value
            .Plaenge = NumericUpDown3.Value
            .PFarbe = Btn_Farbe.BackColor
            .pStrecke = cmb_Strecken.Text
        End With

        ListBox1.Items.RemoveAt(zeile)
        ListBox1.Items.Insert(zeile, allWett(zeile).ausgabe)
        ListBox1.SelectedIndex = zeile
        Call DatenSpeichern()
    End Sub

    Private Sub DatenSpeichern()
        Dim sw As StreamWriter
        'Speichern der Daten in projektname.lsi
        'Datei überschreiben mit allen Daten
        sw = File.CreateText(projektname)
        For x = 0 To Wettbewerbszahl - 1
            sw.WriteLine(allWett(x).ausgabeDatei)
        Next
        sw.Flush()
        sw.Close()

    End Sub

    Private Sub btn_wettb_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_wettb_delete.Click
        'wettbewerb löschen
        Dim sw As StreamWriter
        Dim zeile As Byte

        zeile = ListBox1.SelectedIndex

        ListBox1.Items.RemoveAt(zeile)
        allWett.RemoveAt(zeile)
        Try
            ListBox1.SelectedIndex = zeile
        Catch
            ListBox1.SelectedIndex = zeile - 1
        End Try
        Wettbewerbszahl = Wettbewerbszahl - 1

        'Speichern der Daten in projektname.lsi
        'Datei überschreiben mit allen Daten
        sw = File.CreateText(projektname)
        For x = 0 To Wettbewerbszahl - 1
            sw.WriteLine(allWett(x).ausgabeDatei)
        Next

        sw.Flush()
        sw.Close()
    End Sub


    Private Sub Strecke_Zeichnen(ByVal wegDatei As String, ByVal farbe As Color)
        Dim sr As StreamReader
        Dim punkt1 As String

        'Pfad vorhanden? nein, nie, also anfügen
        wegDatei = Path.GetDirectoryName(projektname) & "\" & wegDatei

        ' Create the PointConverter.
        Dim converter As System.ComponentModel.TypeConverter = _
        System.ComponentModel.TypeDescriptor.GetConverter(GetType(Point))

        m_Points.Clear()
        sr = File.OpenText(wegDatei)
        While Not sr.EndOfStream
            punkt1 = sr.ReadLine()
            '{X=109,Y=241}
            punkt1 = punkt1.Replace(",", ";")
            punkt1 = punkt1.Replace("{X=", "")
            punkt1 = punkt1.Replace("Y=", "")
            punkt1 = punkt1.Replace("}", "")
            m_Points.Add(CType(converter.ConvertFromString(punkt1), Point))
        End While

        Call DrawStrecke(m_Points.ToArray(), Color.FromArgb(200, farbe), True, 3)

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        'angeklickte Strecke (markierter Eintrag) anzeigen im Bild
        If ListBox2.SelectedIndex = -1 Then Exit Sub

        Call Strecke_Zeichnen(ListBox2.SelectedItem.ToString(), Color.Red)

    End Sub

    'Kartengrafik laden und anzeigen und zur Projektdatei kopieren
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim bildOriginal As String
        Dim bildkopie As String

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "bmp-Dateien (*.bmp)|*.bmp|jpg-Dateien (*.jpg)|*.jpg|gif-Dateien (*.gif)|*.gif"

        If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            'Bild zur *.lsi-Datei speichern
            bildOriginal = OpenFileDialog1.FileName
            bildkopie = projektname.Replace(".lsi", ".jpg")
            Try
                PictureBox1.Image.Save(bildkopie)
            Catch
                MsgBox("Bild konnte nicht gespeichert werden!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Hinweis")
            End Try
        End If
    End Sub

    Private Sub Btn_BildSpeichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BildSpeichern.Click
        'Bild mit Strecke Speichern
        SaveFileDialog2.FileName = "strecke.jpg"
        SaveFileDialog2.Filter = "bmp-Dateien (*.bmp)|*.bmp|jpg-Dateien (*.jpg)|*.jpg|gif-Dateien (*.gif)|*.gif"


        If SaveFileDialog2.ShowDialog() = DialogResult.OK Then
            'PictureBox1.Image.Save(SaveFileDialog2.FileName, Imaging.ImageFormat.Bmp)
            'g.Save(SaveFileDialog2.FileName, Imaging.ImageFormat.Bmp)
            m_Backbuffer.Save(SaveFileDialog2.FileName, Imaging.ImageFormat.Bmp)

        End If
        'If ds.ShowDialog() = DialogResult.OK Then _
        'grafik.Save(ds.FileName, Imaging.ImageFormat.Bmp)

    End Sub

    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        'MsgBox("tab click" & TabControl1.SelectedTab.Text)
        'MsgBox("tab click " & TabControl1.SelectedIndex)
        Dim converter As System.ComponentModel.TypeConverter = _
        System.ComponentModel.TypeDescriptor.GetConverter(GetType(Point))

        Select Case TabControl1.SelectedIndex
            Case 0
                Timer1.Enabled = False
                ChB_Simulation.Checked = False
                ChB_Simulation.Text = "Simulation starten"

                PictureBox1.Location = CType(converter.ConvertFromString("188;96"), Point)
                PictureBox1.Width = 600
                PictureBox1.Height = 600
                PictureBox1.Visible = True
                'temporäre Dateien löschen??
            Case 1
                Timer1.Enabled = False
                ChB_Simulation.Checked = False
                ChB_Simulation.Text = "Simulation starten"

                PictureBox1.Location = CType(converter.ConvertFromString("198;160"), Point)
                PictureBox1.Width = 600
                PictureBox1.Height = 600
                If ChB_Karte.Checked = False Then
                    PictureBox1.Visible = False
                End If
                ListBox1.Refresh()


                'temporäre Dateien löschen??
            Case 2
                'temporäre Dateien schreiben
                '- *.weg enthält nur point, die x/y-Werte müssen um die Distanz ergänzt werden
                Call TMP_Dateien()
                m_Points.Clear()
                m_Backbuffer = New Bitmap(PictureBox1.Width, PictureBox1.Height)

                PictureBox1.Location = CType(converter.ConvertFromString("196;25"), Point)
                'width und height auf größtmögliches Quadrat vergrößern
                Dim breite, hoehe As Double
                breite = Me.Width - PictureBox1.Left - 20
                hoehe = Me.Height - PictureBox1.Top - 35
                If hoehe > breite Then
                    hoehe = breite
                Else
                    breite = hoehe
                End If
                simFaktor = 600 / breite
                PictureBox1.Width = breite
                PictureBox1.Height = hoehe

                PictureBox1.Refresh()
                PictureBox1.Visible = True
        End Select

    End Sub


    Private Sub ChB_Karte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_Karte.CheckedChanged
        PictureBox1.Top = ChB_Karte.Location.Y + ChB_Karte.Size.Height
        PictureBox1.Visible = ChB_Karte.Checked
        ListBox1.Refresh()
    End Sub
    '----------------------------------------------------------
    '----------------------------------------------------------
    '----------------------------------------------------------
    'TAB3
    '----------------------------------------------------------
    '----------------------------------------------------------
    '----------------------------------------------------------


    Private Sub DTP_Zeit_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' neu zeichnen
        PictureBox1.Refresh()
    End Sub


    Private Sub ChB_Simulation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_Simulation.CheckedChanged
        If ChB_Simulation.Checked = True Then
            ChB_Simulation.Text = "Simulation stoppen"
        Else
            ChB_Simulation.Text = "Simulation starten"
        End If
        Timer1.Enabled = ChB_Simulation.Checked
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim zeit As String
        Dim z As Byte
        Dim min1 As Integer
        Dim sek1 As Integer
        Dim std1 As Integer
        Dim Zeit1() As String
        Dim min2 As Integer
        'Dim sek2 As Integer
        Dim std2 As Integer
        Dim Zeit2() As String
        Dim diff As Long
        Dim min As Integer
        Dim sek As Integer
        Dim std As Integer
        Dim Wettbewerbsname As String
        sek = DTP_Zeit.Value.Second
        min = DTP_Zeit.Value.Minute
        std = DTP_Zeit.Value.Hour

        sek = sek + takt

        If sek >= 60 Then
            sek = 0
            min = min + 1
        End If
        If min >= 60 Then
            min = 0
            std = std + 1
        End If
        If std >= 24 Then
            std = 0
        End If
        DTP_Zeit.Value = New DateTime(2001, 10, 20, std, min, sek)
        'lesen der Startzeit aus Laufuhr   --------------------------------------
        If ChB_Live.Checked Then
            'zeit.ini
            zeit = allWett(1).PStartzeit
            'max. 20 Wettbewerbe
            For z = 0 To 20
                Try         ' wegen iniz.WertLesen
                    Wettbewerbsname = allWett(z).pname
                    If Wettbewerbsname.Contains("Schüler") Then
                        zeit = iniz.WertLesen("Start", "Schüler")
                        Zeit1 = zeit.Split(":")
                        'zeit=14:38:31.4
                        std1 = Zeit1(0)
                        min1 = Zeit1(1)
                        sek1 = Zeit1(2)
                        Dim t1 As New TimeSpan(std1, min1, 0)

                        Zeit2 = allWett(z).Pzeit().Split(":")
                        std2 = Zeit2(0)
                        min2 = Zeit2(1)
                        'sek2 = Zeit2(2)
                        Dim t2 As New TimeSpan(std2, min2, 0)
                        'diff = DateDiff("s", t1, t2)
                        diff = t1.TotalSeconds - t2.TotalSeconds
                        If (diff > -180) And (diff < 900) Then
                            zeit = iniz.WertLesen("Start", "Schüler")
                        Else
                            zeit = 0
                        End If
                    Else
                        zeit = iniz.WertLesen("Start", allWett(z).Pname)
                    End If

                Catch ex As Exception
                    zeit = "1:10"
                End Try
                If zeit.Length <= 2 Then zeit = "1:10"

                allWett(z).PStartzeit = zeit
            Next
        End If

        Call Walker_zeichnen_Triathlon()
        PictureBox1.Refresh()
        If ChB_Endlos.Checked Then
            'DateTimePicker für startzeit und Endezeit der Endlos-Simulation
            If std = DTP_Endlos_Ende.Value.Hour And min > DTP_Endlos_Ende.Value.Minute Then
                std = DTP_Endlos.Value.Hour
                min = DTP_Endlos.Value.Minute
                ' DTP_Zeit.Value.Hour = 11
                ' DTP_Zeit.Value.AddHours(-5)
                DTP_Zeit.Value = New DateTime(2001, 10, 20, std, min, sek)
            End If
        End If
    End Sub


    'Liste mit Wettbewerbsname und Farbpunkt
    Private Sub PictureBox2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox2.Paint
        Dim stift As New Pen(Brushes.DeepSkyBlue)
        Dim farbe As New SolidBrush(Color.AliceBlue)

        stift.Width = 3
        For z = 0 To Wettbewerbszahl - 1
            stift.Color = allWett(z).PFarbe
            farbe.Color = allWett(z).PFarbe
            e.Graphics.DrawString(allWett(z).PName, Me.Font, Brushes.Black, 20, (10 + z * 20))
            e.Graphics.FillEllipse(farbe, 5, (12 + z * 20), 10, 10)
        Next
        stift.Dispose()
        farbe.Dispose()
    End Sub

    Private Sub TMP_Dateien()
        'temporäre Dateien schreiben
        '- *.weg enthält nur point, die x/y-Werte müssen um die Distanz ergänzt werden
        Dim z As Byte
        Dim x1, y1, x2, y2, dist As Double
        Dim a, b, c As Double
        Dim DateiTemp As String
        Dim DateiWeg As String
        Dim punkt1 As String
        Dim punkt(2) As String
        ' Create the PointConverter.
        Dim converter As System.ComponentModel.TypeConverter = _
        System.ComponentModel.TypeDescriptor.GetConverter(GetType(Point))
        Dim srTemp As StreamWriter
        Dim sr As StreamReader

        For z = 0 To Wettbewerbszahl - 1
            DateiWeg = allWett(z).pstrecke
            DateiTemp = Replace(allWett(z).pstrecke, ".weg", ".tmp")

            'Pfad vorhanden? nein, nie, also anfügen
            DateiWeg = Path.GetDirectoryName(projektname) & "\" & DateiWeg
            DateiTemp = Path.GetDirectoryName(projektname) & "\" & DateiTemp

            srTemp = File.CreateText(DateiTemp)

            sr = File.OpenText(DateiWeg)
            punkt1 = sr.ReadLine()
            '{X=109,Y=241}
            punkt1 = punkt1.Replace(",", ";")
            punkt1 = punkt1.Replace("{X=", "")
            punkt1 = punkt1.Replace("Y=", "")
            punkt1 = punkt1.Replace("}", "")
            '109;241
            punkt = punkt1.Split(";") '
            x1 = punkt(0)
            y1 = punkt(1)
            dist = 0
            srTemp.WriteLine(x1.ToString & ";" & y1.ToString & ";" & dist.ToString)

            While Not sr.EndOfStream
                x2 = x1
                y2 = y1
                punkt1 = sr.ReadLine()
                '{X=109,Y=241}
                punkt1 = punkt1.Replace(",", ";")
                punkt1 = punkt1.Replace("{X=", "")
                punkt1 = punkt1.Replace("Y=", "")
                punkt1 = punkt1.Replace("}", "")
                '109;241
                punkt = punkt1.Split(";") '
                x1 = punkt(0)
                y1 = punkt(1)
                'entfernung in pixel berechnen
                a = Math.Abs(x1 - x2)
                b = Math.Abs(y1 - y2)
                a = a * a
                b = b * b
                c = Math.Sqrt(a + b)
                dist = dist + c
                srTemp.WriteLine(x1.ToString & ";" & y1.ToString & ";" & dist.ToString)
            End While
            srTemp.Flush()
            srTemp.Close()
            faktor(z) = allWett(z).PLaenge / dist
            'Faktor geht von 26 bis 40
            'Faktor entspricht: meter je pixel
            'MsgBox(faktor(z) & "=" & allWett(z).PLaenge & "/" & dist)
        Next
    End Sub

    Private Sub Walker_zeichnen_ALT()
        Dim Zeit(2) As String
        Dim ZeitA As String
        Dim sek As Integer
        Dim meterSM, meterSW, meterL As Double
        Dim DateiWeg As String
        Dim sr As StreamReader
        Dim distsumP2 As Double
        Dim distsumP1 As Double
        Dim DistP1P2 As Double
        Dim x1, y1, x2, y2, x3, y3, x4, y4 As Integer
        Dim xp, yp As Integer
        Dim aktZeit As Integer
        Dim ProzentWeg(3, 20) As Integer 'Pozentzahl des zurüchgelegten Weges

        Dim ZeitModerator As String
      
        ' Create the PointConverter.
        Dim converter As System.ComponentModel.TypeConverter = _
        System.ComponentModel.TypeDescriptor.GetConverter(GetType(Point))

        ZeitA = DTP_Zeit.Text
        Zeit = ZeitA.Split(":")
        aktZeit = Zeit(0) * 60 * 60 + Zeit(1) * 60 + Zeit(2)

        For z = 0 To 60
            walker(z).PposX = -10
            walker(z).PposY = -10
        Next
        ' in m_backbuffer wird die Verteilung der Läufer gezeichnet
        m_Backbuffer = New Bitmap(PictureBox1.Width, PictureBox1.Height)

    

        'Position Läufer
        For z = 0 To Wettbewerbszahl - 1
            'Startzeit in sekunden umrechnen    "10:15"
            ZeitA = allWett(z).PStartzeit
            Zeit = ZeitA.Split(":")
            sek = Zeit(0) * 60 * 60 + Zeit(1) * 60 'Startzeit
            'Verteilung: Punkte in liste m_points aufnehmen
            m_Points.Clear()

            'langsamser Läufer, schnellster Läufer und Punkte dazwischen
            If (aktZeit >= sek) And (aktZeit <= sek + allWett(z).PZeitL * 60) Then
                'Uhrzeit ist größer als Startzeit und kleiner als Startzeit + ZeitL
                meterSM = aktZeit - sek                      'gelaufene Zeit in sekunden
                meterSM = meterSM / (allWett(z).PZeitSM * 60)  'geteilt durch gesamtzeit
                meterSM = meterSM * (allWett(z).PLaenge)      '=zurückgelegte Meter seit Start
                ProzentWeg(0, z) = 100 / allWett(z).PLaenge * meterSM
                meterSM = meterSM / faktor(z)                 ' umrechnen in Pixel

                meterSW = aktZeit - sek                      'gelaufene Zeit in sekunden
                meterSW = meterSW / (allWett(z).PZeitSW * 60)  'geteilt durch gesamtzeit
                meterSW = meterSW * (allWett(z).PLaenge)      '=zurückgelegte Meter seit Start
                ProzentWeg(1, z) = 100 / allWett(z).PLaenge * meterSW
                meterSW = meterSW / faktor(z)                 ' umrechnen in Pixel

                meterL = aktZeit - sek                      'gelaufene Zeit in sekunden
                meterL = meterL / (allWett(z).PZeitL * 60)  'geteilt durch gesamtzeit
                meterL = meterL * (allWett(z).PLaenge)      '=zurückgelegte Meter seit Start
                ProzentWeg(2, z) = 100 / allWett(z).PLaenge * meterL
                meterL = meterL / faktor(z)                 ' umrechnen in Pixel

                'Prozentzahl des zurückgelegten Weges berechnen
                'schreiben in posg.css für Moderator-Info
                If ProzentWeg(0, z) > 100 Then ProzentWeg(0, z) = 100
                If ProzentWeg(1, z) > 100 Then ProzentWeg(1, z) = 100
                'Label7.Text = ProzentWeg(0, z) & "-" & ProzentWeg(1, z) & "-" & allWett(z).PName

                'aktuell gelaufene Zeit in laufZ.txt speichern
                'für Moderator-Info
                x1 = aktZeit - sek
                x2 = Fix(x1 / (60 * 60)) 'Stunden
                If Len(x2.ToString) = 1 Then
                    ZeitModerator = "0" & x2.ToString & ":"
                Else
                    ZeitModerator = x2.ToString & ":"
                End If
                x1 = x1 - (x2 * 60 * 60)
                x2 = Fix(x1 / 60) 'Minuten
                If Len(x2.ToString) = 1 Then
                    ZeitModerator = ZeitModerator & "0" & x2.ToString & ":"
                Else
                    ZeitModerator = ZeitModerator & x2.ToString & ":"
                End If
                x1 = x1 - (x2 * 60)
                x2 = x1 '/ 60 'Sekunden
                If Len(x2.ToString) = 1 Then
                    ZeitModerator = ZeitModerator & "0" & x2.ToString
                Else
                    ZeitModerator = ZeitModerator & x2.ToString
                End If
                'Label7.Text = ZeitModerator
                '00:00:25 <a href="lauf2.html"> Schüler</a><br>
                ZeitModerator = ZeitModerator & " <a href='lauf" & z + 1 & ".html'>"
                ZeitModerator = ZeitModerator & allWett(z).PName
                ZeitModerator = ZeitModerator & "</a><br>"
                'Label7.Text = ZeitModerator
                'File.WriteAllText("D:\xampp\htdocs\mod\lauf" & z + 1 & ".txt", ZeitModerator)









                'MsgBox(meterL & " / " & meterS)
                DateiWeg = Replace(allWett(z).pstrecke, ".weg", ".tmp")
                DateiWeg = Path.GetDirectoryName(projektname) & "\" & DateiWeg

                sr = File.OpenText(DateiWeg)
                distsumP2 = 0
                x2 = 0
                y2 = 0
                Do
                    x1 = x2
                    y1 = y2
                    distsumP1 = distsumP2
                    ZeitA = sr.ReadLine()
                    Zeit = ZeitA.Split(";")
                    x2 = Zeit(0)
                    y2 = Zeit(1)
                    distsumP2 = Zeit(2)
                Loop While (meterL > distsumP2) And Not sr.EndOfStream

                'Differenz zukünftiger Pos. zur letzten Pos. in der Datei
                x3 = x2 - x1
                y3 = y2 - y1
                DistP1P2 = distsumP2 - distsumP1

                'langsamster Läufer
                If distsumP2 = 0 Then
                    'Startposition
                    walker(z + 20).PFarbe = allWett(z).PFarbe
                    walker(z + 20).PposX = x1 / simFaktor - 5
                    walker(z + 20).PposY = y1 / simFaktor - 5
                    walker(z + 20).Pgroesse = 10
                    xp = x1 / simFaktor
                    yp = y1 / simFaktor
                    m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                Else
                    x4 = x3 * ((meterL - distsumP1) / DistP1P2)
                    y4 = y3 * ((meterL - distsumP1) / DistP1P2)
                    ' nur wenn Laufzeit+Startzeit noch kleiner als aktuelle Zeit
                    walker(z + 20).PFarbe = allWett(z).PFarbe
                    walker(z + 20).PposX = (x1 + x4) / simFaktor - 5
                    walker(z + 20).PposY = (y1 + y4) / simFaktor - 5
                    walker(z + 20).Pgroesse = 10
                    'erster Point in Liste m_Point
                    xp = walker(z + 20).PposX + 5
                    yp = walker(z + 20).PposY + 5
                    m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                End If
                xp = x2 / simFaktor
                yp = y2 / simFaktor
                m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))

                'schnellste Frau - immer langsamer als der schnellste Mann!!!!!
                Do While (meterSW > distsumP2) And Not sr.EndOfStream
                    x1 = x2
                    y1 = y2
                    distsumP1 = distsumP2
                    ZeitA = sr.ReadLine()
                    Zeit = ZeitA.Split(";")
                    x2 = Zeit(0)
                    y2 = Zeit(1)
                    distsumP2 = Zeit(2)
                    xp = x2 / simFaktor
                    yp = y2 / simFaktor
                    m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                Loop

                x3 = x2 - x1
                y3 = y2 - y1
                DistP1P2 = distsumP2 - distsumP1
                If (aktZeit >= sek) And (aktZeit <= sek + allWett(z).PZeitSW * 60) Then
                    m_Points.RemoveAt(m_Points.Count - 1)
                    'If distsumP2 = 0 Then
                    'Startposition
                    'walker(z + 40).PFarbe = allWett(z).PFarbe
                    'walker(z + 40).PposX = x1 / simFaktor - 6
                    'walker(z + 40).PposY = y1 / simFaktor - 6
                    'walker(z + 40).Pgroesse = 12

                    'xp = walker(z + 40).PposX + 6
                    'yp = walker(z + 40).PposY + 6
                    'm_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                    'Else
                    'x4 = x3 * ((meterSW - distsumP1) / DistP1P2)
                    'y4 = y3 * ((meterSW - distsumP1) / DistP1P2)
                    ' nur wenn Laufzeit+Startzeit noch kleiner als aktuelle Zeit
                    'walker(z + 40).PFarbe = allWett(z).PFarbe
                    'walker(z + 40).PposX = (x1 + x4) / simFaktor - 6
                    'walker(z + 40).PposY = (y1 + y4) / simFaktor - 6
                    'walker(z + 40).Pgroesse = 12
                    '   m_Points.RemoveAt(m_Points.Count - 1)
                    'xp = walker(z + 40).PposX + 6
                    'yp = walker(z + 40).PposY + 6
                    'm_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                    'End If
                End If
                xp = x2 / simFaktor
                yp = y2 / simFaktor
                m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))

                '------------------------------------------------------
                'schnellster Mann
                Do While (meterSM > distsumP2) And Not sr.EndOfStream
                    x1 = x2
                    y1 = y2
                    distsumP1 = distsumP2
                    ZeitA = sr.ReadLine()
                    Zeit = ZeitA.Split(";")
                    x2 = Zeit(0)
                    y2 = Zeit(1)
                    distsumP2 = Zeit(2)
                    xp = x2 / simFaktor
                    yp = y2 / simFaktor
                    m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                Loop

                x3 = x2 - x1
                y3 = y2 - y1
                DistP1P2 = distsumP2 - distsumP1
                'Strecke zwischen schnelster Mann und schnellste Frau
                If (aktZeit >= sek) And (aktZeit <= sek + allWett(z).PZeitSM * 60) Then
                    If distsumP2 = 0 Then
                        'Startposition
                        walker(z).PFarbe = allWett(z).PFarbe
                        walker(z).PposX = x1 / simFaktor - 6
                        walker(z).PposY = y1 / simFaktor - 6
                        walker(z).Pgroesse = 12
                        m_Points.RemoveAt(m_Points.Count - 1)

                        xp = walker(z).PposX + 6
                        yp = walker(z).PposY + 6
                        m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                    Else
                        x4 = x3 * ((meterSM - distsumP1) / DistP1P2)
                        y4 = y3 * ((meterSM - distsumP1) / DistP1P2)
                        ' nur wenn Laufzeit+Startzeit noch kleiner als aktuelle Zeit
                        walker(z).PFarbe = allWett(z).PFarbe
                        walker(z).PposX = (x1 + x4) / simFaktor - 6
                        walker(z).PposY = (y1 + y4) / simFaktor - 6
                        walker(z).Pgroesse = 12
                        m_Points.RemoveAt(m_Points.Count - 1)
                        xp = walker(z).PposX + 6
                        yp = walker(z).PposY + 6
                        m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                    End If
                End If
                '------------------------------------------------------

                'pos.css KARTE
                'walker(z + 20): langsamster
                'walker(z + 40).PposY: schnellste Frau
                'walker(z).PposX: schnellster Mann
                '#A3 {
                'position:absolute;
                'left:130px;
                'top:460px;
                'color:rgb(0,173,238);
                'font-size:1.2em;
                '}
                'diffx = -180
                'diffy = 55
                'srpos.WriteLine("#A" & z + 1 & " {")
                'srpos.WriteLine("position:absolute;")
                'srpos.WriteLine("left:" & CInt((walker(z).PposX + 0) / simFaktor) + diffx & "px;")
                'srpos.WriteLine("top:" & CInt((walker(z).PposY) / simFaktor) + diffy & "px;")
                'farbe = System.String.Format("#{0:X2}{1:X2}{2:X2}", walker(z).PFarbe.R, walker(z).PFarbe.G, walker(z).PFarbe.B)
                'srpos.WriteLine("color:" & farbe & ";")
                'srpos.WriteLine("font-weight:bold;font-size:1.2em;")
                'srpos.WriteLine("}")
                'srpos.WriteLine(" ")

                'srpos.WriteLine("#B" & z + 1 & " {")
                'srpos.WriteLine("position:absolute;")
                'srpos.WriteLine("left:" & CInt((walker(z + 40).PposX + 0) / simFaktor) + diffx & "px;")
                'srpos.WriteLine("top:" & CInt((walker(z + 40).PposY) / simFaktor) + diffy & "px;")
                'srpos.WriteLine("color:" & farbe & ";")
                'srpos.WriteLine("font-weight:bold;font-size:1.2em;")
                'srpos.WriteLine("}")
                'srpos.WriteLine(" ")

                'srpos.WriteLine("#C" & z + 1 & " {")
                'srpos.WriteLine("position:absolute;")
                'srpos.WriteLine("left:" & CInt((walker(z + 20).PposX + 0) / simFaktor) + diffx & "px;")
                'srpos.WriteLine("top:" & CInt((walker(z + 20).PposY) / simFaktor) + diffy & "px;")
                'srpos.WriteLine("color:" & farbe & ";")
                'srpos.WriteLine("font-weight:bold;font-size:1.2em;")
                'srpos.WriteLine("}")
                'srpos.WriteLine(" ")



                'posg.css   GRAFIK
                '#A1g {
                'position:absolute;
                'left:70px;
                'top:120px;
                'color:blue;
                'font-size:1.2em;
                'z-index:1;
                '}
                'srpos.WriteLine("#M1" & z + 1 & "{")
                'srpos.WriteLine("left:" & ProzentWeg(0, z) * 4 & "px")
                'srpos.WriteLine("}")
                'srpos.WriteLine("#M2" & z + 1 & "{")
                'srpos.WriteLine("left:" & ProzentWeg(1, z) * 4 & "px")
                'srpos.WriteLine("}")






                '------------------------------------------------------
                If ChB_Verteilung.Checked Then
                    Call DrawStrecke(m_Points.ToArray(), Color.FromArgb(180, walker(z).PFarbe), False, 4)
                End If

            End If

        Next

    End Sub

    Private Sub Walker_zeichnen_Triathlon()
        Dim Zeit(2) As String
        Dim ZeitA As String
        Dim sek, sekL As Integer
        Dim meterSM, meterSW, meterL As Double
        Dim DateiWeg As String
        Dim sr As StreamReader
        Dim distsumP2 As Double
        Dim distsumP1 As Double
        Dim DistP1P2 As Double
        Dim x1, y1, x2, y2, x3, y3, x4, y4 As Integer
        Dim xp, yp As Integer
        Dim aktZeit As Integer

        'alle walker auf Startposition
        For z = 0 To 60
            walker(z).PposX = -10
            walker(z).PposY = -10
        Next

        ' Create the PointConverter.
        Dim converter As System.ComponentModel.TypeConverter = _
        System.ComponentModel.TypeDescriptor.GetConverter(GetType(Point))

        ' in m_backbuffer wird die Verteilung der Läufer gezeichnet
        m_Backbuffer = New Bitmap(PictureBox1.Width, PictureBox1.Height)

        ZeitA = DTP_Zeit.Text
        Zeit = ZeitA.Split(":")
        aktZeit = Zeit(0) * 60 * 60 + Zeit(1) * 60 + Zeit(2)

        'Position Läufer
        For z = 0 To Wettbewerbszahl - 1
            'Startzeit in sekunden umrechnen    "10:15"
            sek = 0
            sekL = 0
            ZeitA = allWett(z).PStartzeit
            If ZeitA = "0:00" Then
                ZeitA = allWett(z - 1).PStartzeit
                sek = allWett(z - 1).PZeitSM * 60
                sekL = allWett(z - 1).PZeitL * 60 '+ allWett(z - 1).PZeitL * 60
                If ZeitA = "0:00" Then
                    ZeitA = allWett(z - 2).PStartzeit
                    sek = allWett(z - 2).PZeitSM * 60 + allWett(z - 1).PZeitSM * 60
                    sekL = allWett(z - 2).PZeitL * 60 + allWett(z - 1).PZeitL * 60 '+ allWett(z - 2).PZeitL * 60
                    If ZeitA = "0:00" Then
                        ZeitA = allWett(z - 3).PStartzeit
                        sek = allWett(z - 3).PZeitSM * 60 + allWett(z - 2).PZeitSM * 60
                        sekL = allWett(z - 3).PZeitL * 60 + allWett(z - 2).PZeitL * 60 '+ allWett(z - 2).PZeitL * 60
                    End If
                End If
            End If
            Zeit = ZeitA.Split(":")
            sek = sek + Zeit(0) * 60 * 60 + Zeit(1) * 60
            sekL = sekL + Zeit(0) * 60 * 60 + Zeit(1) * 60

            'Verteilung: Punkte in liste m_points aufnehmen
            m_Points.Clear()

            'langsamser Läufer, schnellster Läufer und Punkte dazwischen
            'If (aktZeit >= sek) And (aktZeit <= sekL) Then
            If (aktZeit >= sek) And (aktZeit <= sekL + allWett(z).PZeitL * 60) Then
                'Uhrzeit ist größer als Startzeit und kleiner als Startzeit + ZeitL
                meterSM = aktZeit - sek                        'gelaufene Zeit in sekunden
                meterSM = meterSM / (allWett(z).PZeitSM * 60)  'geteilt durch gesamtzeit
                meterSM = meterSM * (allWett(z).PLaenge)       '=zurückgelegte Meter seit Start
                meterSM = meterSM / faktor(z)                  ' umrechnen in Pixel

                meterSW = aktZeit - sek                        'gelaufene Zeit in sekunden
                meterSW = meterSW / (allWett(z).PZeitSW * 60)  'geteilt durch gesamtzeit
                meterSW = meterSW * (allWett(z).PLaenge)       '=zurückgelegte Meter seit Start
                meterSW = meterSW / faktor(z)                  ' umrechnen in Pixel

                meterL = aktZeit - sekL                      'gelaufene Zeit in sekunden
                meterL = meterL / (allWett(z).PZeitL * 60)  'geteilt durch gesamtzeit
                meterL = meterL * (allWett(z).PLaenge)      '=zurückgelegte Meter seit Start
                meterL = meterL / faktor(z)                 ' umrechnen in Pixel

                'MsgBox(meterL & " / " & meterS)
                DateiWeg = Replace(allWett(z).pstrecke, ".weg", ".tmp")
                DateiWeg = Path.GetDirectoryName(projektname) & "\" & DateiWeg

                sr = File.OpenText(DateiWeg)
                distsumP2 = 0
                x2 = 0
                y2 = 0
                Do
                    x1 = x2
                    y1 = y2
                    distsumP1 = distsumP2
                    ZeitA = sr.ReadLine()
                    Zeit = ZeitA.Split(";")
                    x2 = Zeit(0)
                    y2 = Zeit(1)
                    distsumP2 = Zeit(2)
                Loop While (meterL > distsumP2) And Not sr.EndOfStream

                'Differenz zukünftiger Pos. zur letzten Pos. in der Datei
                x3 = x2 - x1
                y3 = y2 - y1
                DistP1P2 = distsumP2 - distsumP1

                'langsamster Läufer
                If distsumP2 = 0 Then
                    'Startposition
                    walker(z + 20).PFarbe = allWett(z).PFarbe
                    walker(z + 20).PposX = x1 / simFaktor - 5
                    walker(z + 20).PposY = y1 / simFaktor - 5
                    walker(z + 20).Pgroesse = 10
                    xp = x1 / simFaktor
                    yp = y1 / simFaktor
                    If xp >= 10 Then m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                Else
                    x4 = x3 * ((meterL - distsumP1) / DistP1P2)
                    y4 = y3 * ((meterL - distsumP1) / DistP1P2)
                    ' nur wenn Laufzeit+Startzeit noch kleiner als aktuelle Zeit
                    walker(z + 20).PFarbe = allWett(z).PFarbe
                    walker(z + 20).PposX = (x1 + x4) / simFaktor - 5
                    walker(z + 20).PposY = (y1 + y4) / simFaktor - 5
                    walker(z + 20).Pgroesse = 10
                    'erster Point in Liste m_Point
                    '
                    xp = walker(z + 20).PposX + 5
                    yp = walker(z + 20).PposY + 5
                    If xp >= 10 Then m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                End If
                xp = x2 / simFaktor
                yp = y2 / simFaktor
                If xp >= 10 Then m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))

                'schnellste Frau - immer langsamer als der schnellste Mann!!!!!
                'Strecke zwischen langsamsten und Frau
                Do While (meterSW > distsumP2) And Not sr.EndOfStream
                    x1 = x2
                    y1 = y2
                    distsumP1 = distsumP2
                    ZeitA = sr.ReadLine()
                    Zeit = ZeitA.Split(";")
                    x2 = Zeit(0)
                    y2 = Zeit(1)
                    distsumP2 = Zeit(2)
                    xp = x2 / simFaktor
                    yp = y2 / simFaktor
                    If xp >= 0 Then m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                Loop

                x3 = x2 - x1
                y3 = y2 - y1
                DistP1P2 = distsumP2 - distsumP1
                'Position schnellste Frau 
                If (aktZeit >= sek) And (aktZeit <= sek + allWett(z).PZeitSW * 60) Then
                    If distsumP2 = 0 Then
                        'Startposition
                        walker(z + 40).PFarbe = allWett(z).PFarbe
                        walker(z + 40).PposX = x1 / simFaktor - 6
                        walker(z + 40).PposY = y1 / simFaktor - 6
                        walker(z + 40).Pgroesse = 12

                        xp = walker(z + 40).PposX + 6
                        yp = walker(z + 40).PposY + 6
                        If xp >= 10 Then m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                    Else
                        x4 = x3 * ((meterSW - distsumP1) / DistP1P2)
                        y4 = y3 * ((meterSW - distsumP1) / DistP1P2)
                        ' nur wenn Laufzeit+Startzeit noch kleiner als aktuelle Zeit
                        walker(z + 40).PFarbe = allWett(z).PFarbe
                        walker(z + 40).PposX = (x1 + x4) / simFaktor - 6
                        walker(z + 40).PposY = (y1 + y4) / simFaktor - 6
                        walker(z + 40).Pgroesse = 12
                        m_Points.RemoveAt(m_Points.Count - 1)
                        xp = walker(z + 40).PposX + 6
                        yp = walker(z + 40).PposY + 6
                        If xp >= 10 Then m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                    End If

                End If

                xp = x2 / simFaktor
                yp = y2 / simFaktor
                m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))

                '------------------------------------------------------
                'schnellster Mann
                Do While (meterSM > distsumP2) And Not sr.EndOfStream
                    x1 = x2
                    y1 = y2
                    distsumP1 = distsumP2
                    ZeitA = sr.ReadLine()
                    Zeit = ZeitA.Split(";")
                    x2 = Zeit(0)
                    y2 = Zeit(1)
                    distsumP2 = Zeit(2)
                    xp = x2 / simFaktor
                    yp = y2 / simFaktor
                    If xp >= 10 Then m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                Loop

                x3 = x2 - x1
                y3 = y2 - y1
                DistP1P2 = distsumP2 - distsumP1
                'Strecke zwischen schnelster Mann und schnellste Frau
                If (aktZeit >= sek) And (aktZeit <= sek + allWett(z).PZeitSM * 60) Then
                    If distsumP2 = 0 Then
                        'Startposition
                        walker(z).PFarbe = allWett(z).PFarbe
                        walker(z).PposX = x1 / simFaktor - 6
                        walker(z).PposY = y1 / simFaktor - 6
                        walker(z).Pgroesse = 12
                        m_Points.RemoveAt(m_Points.Count - 1)
                        xp = walker(z).PposX + 6
                        yp = walker(z).PposY + 6
                        If xp >= 10 Then m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                    Else
                        x4 = x3 * ((meterSM - distsumP1) / DistP1P2)
                        y4 = y3 * ((meterSM - distsumP1) / DistP1P2)
                        ' nur wenn Laufzeit+Startzeit noch kleiner als aktuelle Zeit
                        walker(z).PFarbe = allWett(z).PFarbe
                        walker(z).PposX = (x1 + x4) / simFaktor - 6
                        walker(z).PposY = (y1 + y4) / simFaktor - 6
                        walker(z).Pgroesse = 12
                        m_Points.RemoveAt(m_Points.Count - 1)
                        xp = walker(z).PposX + 6
                        yp = walker(z).PposY + 6
                        If xp >= 10 Then m_Points.Add(CType(converter.ConvertFromString(xp & ";" & yp), Point))
                    End If
                End If

                If ChB_Verteilung.Checked Then
                    Call DrawStrecke(m_Points.ToArray(), Color.FromArgb(180, walker(z).PFarbe), False, 4)
                End If
            End If
        Next

    End Sub
   

    Private Sub Btn_PCZeit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PCZeit.Click
        DTP_Zeit.Value = Now
    End Sub

    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown4.ValueChanged
        Select Case NumericUpDown4.Value
            Case 1
                Timer1.Interval = 1000
                takt = 1
            Case 2
                Timer1.Interval = 500
                takt = 1
            Case 3
                Timer1.Interval = 200
                takt = 1
            Case 4
                Timer1.Interval = 100
                takt = 1
            Case 5
                Timer1.Interval = 100
                takt = 2
            Case 6
                Timer1.Interval = 100
                takt = 5
            Case 7
                Timer1.Interval = 100
                takt = 10
            Case 8
                Timer1.Interval = 100
                takt = 20

        End Select
    End Sub




    Private Sub WwwtiergartenlaufdeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WwwtiergartenlaufdeToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.tiergartenlauf.de")
    End Sub

    Private Sub WwwmeyervelendeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WwwmeyervelendeToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.meyer-velen.de")
    End Sub

    Private Sub BeendenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeendenToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub WwwopenstreetmaporgToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WwwopenstreetmaporgToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.openstreetmap.org")
    End Sub

    Private Sub ChB_Live_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_Live.CheckedChanged
        'Live-Modus:
        '-lesen der Startzeit aus zeit.ini von Laufuhr
        '   in regelmäßigen abständen wiederholen  
        '   allWett(z).PStartzeit
        '-PC-Zeitübernehmen
        '-Tempo=1
        'Problem: Laufuhr hat nur 6 Zeiten, der Tiergartenlauf aber 13 Wettbewerbe
        '-Laufbezeichnungen müssen übereinstimmen in Laufuhr und Laufsimulation
        '-
        '
        '

        If ChB_Live.Checked = True Then
            TabControl1.Enabled = False

            ChB_Simulation.Checked = False
            Panel1.Enabled = False
            NumericUpDown4.Value = 1
            Call Btn_PCZeit_Click(sender, e)
            Call ChB_Simulation_CheckedChanged(sender, e)
            'lesen der Startzeit aus zeit.ini von Laufuhr muss im timer passieren
            'sichern der originalen Zeiten? nicht nötig
            FolderBrowserDialog1.ShowDialog()
            zeitpfad = FolderBrowserDialog1.SelectedPath
            iniz.Pfad = zeitpfad & "\zeit.ini"
            If File.Exists(iniz.Pfad) = False Then
                ChB_Live.Checked = False
                MsgBox("zeit.ini nicht gefunden!", MsgBoxStyle.Exclamation, "Achtung!")
                ChB_Live.Checked = False
            Else
                ChB_Simulation.Checked = True
            End If
        End If
        If ChB_Live.Checked = False Then
            'lesen der originalen Zeiten
            For x = 1 To Wettbewerbszahl - 1
                allWett(x).PStartzeit = allWett(x).Pzeit
            Next
            Panel1.Enabled = True
            TabControl1.Enabled = True
        End If
        LiveModusAusToolStripMenuItem.Enabled = ChB_Live.Checked
    End Sub

    Private Sub LiveModusAusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiveModusAusToolStripMenuItem.Click
        ChB_Live.Checked = False
    End Sub

    'Ablauf der Simulation in Endlosschleife, auf großem Monitor prasentieren
    'Startzeit und Endzeit im Formular abfragen
    '
    Private Sub ChB_Endlos_CheckedChanged(sender As Object, e As EventArgs) Handles ChB_Endlos.CheckedChanged
        If ChB_Endlos.Checked = True Then
            ChB_Simulation.Text = "Simulation stoppen"

        Else
            ChB_Simulation.Text = "Simulation starten"
        End If
        'Timer1.Enabled = ChB_Endlos.Checked
        ChB_Simulation.Checked = ChB_Endlos.Checked
        NumericUpDown4.Value = 7
        DTP_Endlos.Visible = ChB_Endlos.Checked
        DTP_Endlos_Ende.Visible = ChB_Endlos.Checked
    End Sub
End Class
