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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Btn_BildSpeichern = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.lblNumPoints = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown5 = New System.Windows.Forms.NumericUpDown()
        Me.ChB_Karte = New System.Windows.Forms.CheckBox()
        Me.cmb_Strecken = New System.Windows.Forms.ComboBox()
        Me.btn_wettb_delete = New System.Windows.Forms.Button()
        Me.btn_Wettb_edit = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Wettb_hinzu = New System.Windows.Forms.Button()
        Me.Btn_Farbe = New System.Windows.Forms.Button()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.txt_Wettbewerb = New System.Windows.Forms.TextBox()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.DTP_Endlos_Ende = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Endlos = New System.Windows.Forms.DateTimePicker()
        Me.ChB_Endlos = New System.Windows.Forms.CheckBox()
        Me.ChB_Live = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NumericUpDown4 = New System.Windows.Forms.NumericUpDown()
        Me.Btn_PCZeit = New System.Windows.Forms.Button()
        Me.ChB_Simulation = New System.Windows.Forms.CheckBox()
        Me.DTP_Zeit = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ChB_Verteilung = New System.Windows.Forms.CheckBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProgrammToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNU_V_neu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNU_V_öffnen = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiveModusAusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LinksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WwwtiergartenlaufdeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WwwmeyervelendeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WwwopenstreetmaporgToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TabControl1.Location = New System.Drawing.Point(1, 25)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(677, 519)
        Me.TabControl1.TabIndex = 1
        Me.TabControl1.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Btn_BildSpeichern)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.ListBox2)
        Me.TabPage1.Controls.Add(Me.lblNumPoints)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(669, 493)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Strecken"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Btn_BildSpeichern
        '
        Me.Btn_BildSpeichern.Location = New System.Drawing.Point(545, 8)
        Me.Btn_BildSpeichern.Name = "Btn_BildSpeichern"
        Me.Btn_BildSpeichern.Size = New System.Drawing.Size(99, 22)
        Me.Btn_BildSpeichern.TabIndex = 32
        Me.Btn_BildSpeichern.Text = "Bild speichern"
        Me.Btn_BildSpeichern.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(360, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 22)
        Me.Button1.TabIndex = 31
        Me.Button1.Text = "Karte laden"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(18, 9)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(96, 23)
        Me.CheckBox1.TabIndex = 30
        Me.CheckBox1.Text = "Strecke erstellen"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(18, 48)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(149, 56)
        Me.ListBox2.TabIndex = 29
        '
        'lblNumPoints
        '
        Me.lblNumPoints.AutoSize = True
        Me.lblNumPoints.Location = New System.Drawing.Point(161, 14)
        Me.lblNumPoints.Name = "lblNumPoints"
        Me.lblNumPoints.Size = New System.Drawing.Size(39, 13)
        Me.lblNumPoints.TabIndex = 26
        Me.lblNumPoints.Text = "Label6"
        Me.lblNumPoints.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(669, 493)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "Wettbewerbe"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ListBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 107)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(712, 118)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Wettbewerbe"
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 19
        Me.ListBox1.Location = New System.Drawing.Point(6, 19)
        Me.ListBox1.MultiColumn = True
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(701, 61)
        Me.ListBox1.TabIndex = 19
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NumericUpDown5)
        Me.GroupBox1.Controls.Add(Me.ChB_Karte)
        Me.GroupBox1.Controls.Add(Me.cmb_Strecken)
        Me.GroupBox1.Controls.Add(Me.btn_wettb_delete)
        Me.GroupBox1.Controls.Add(Me.btn_Wettb_edit)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btn_Wettb_hinzu)
        Me.GroupBox1.Controls.Add(Me.Btn_Farbe)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Me.txt_Wettbewerb)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown3)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(633, 95)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "neuer Wettbewerb"
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.Location = New System.Drawing.Point(311, 67)
        Me.NumericUpDown5.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.NumericUpDown5.Name = "NumericUpDown5"
        Me.NumericUpDown5.Size = New System.Drawing.Size(52, 20)
        Me.NumericUpDown5.TabIndex = 29
        Me.ToolTip1.SetToolTip(Me.NumericUpDown5, "Zeit der schnellsten weiblichen Läuferin")
        Me.NumericUpDown5.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'ChB_Karte
        '
        Me.ChB_Karte.AutoSize = True
        Me.ChB_Karte.Location = New System.Drawing.Point(493, 72)
        Me.ChB_Karte.Name = "ChB_Karte"
        Me.ChB_Karte.Size = New System.Drawing.Size(97, 17)
        Me.ChB_Karte.TabIndex = 28
        Me.ChB_Karte.Text = "Karte anzeigen"
        Me.ChB_Karte.UseVisualStyleBackColor = True
        '
        'cmb_Strecken
        '
        Me.cmb_Strecken.FormattingEnabled = True
        Me.cmb_Strecken.Location = New System.Drawing.Point(493, 40)
        Me.cmb_Strecken.Name = "cmb_Strecken"
        Me.cmb_Strecken.Size = New System.Drawing.Size(110, 21)
        Me.cmb_Strecken.TabIndex = 27
        Me.cmb_Strecken.Text = "Strecke zuordnen"
        '
        'btn_wettb_delete
        '
        Me.btn_wettb_delete.Enabled = False
        Me.btn_wettb_delete.Location = New System.Drawing.Point(158, 69)
        Me.btn_wettb_delete.Name = "btn_wettb_delete"
        Me.btn_wettb_delete.Size = New System.Drawing.Size(69, 21)
        Me.btn_wettb_delete.TabIndex = 26
        Me.btn_wettb_delete.Text = "löschen"
        Me.btn_wettb_delete.UseVisualStyleBackColor = True
        '
        'btn_Wettb_edit
        '
        Me.btn_Wettb_edit.Enabled = False
        Me.btn_Wettb_edit.Location = New System.Drawing.Point(84, 69)
        Me.btn_Wettb_edit.Name = "btn_Wettb_edit"
        Me.btn_Wettb_edit.Size = New System.Drawing.Size(69, 21)
        Me.btn_Wettb_edit.TabIndex = 24
        Me.btn_Wettb_edit.Text = "ändern"
        Me.btn_Wettb_edit.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(366, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Streckenlänge"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(252, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "max      "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(308, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "min     "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(183, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Startzeit      "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Bezeichnung      "
        '
        'btn_Wettb_hinzu
        '
        Me.btn_Wettb_hinzu.Location = New System.Drawing.Point(10, 69)
        Me.btn_Wettb_hinzu.Name = "btn_Wettb_hinzu"
        Me.btn_Wettb_hinzu.Size = New System.Drawing.Size(69, 21)
        Me.btn_Wettb_hinzu.TabIndex = 18
        Me.btn_Wettb_hinzu.Text = "hinzufügen"
        Me.btn_Wettb_hinzu.UseVisualStyleBackColor = True
        '
        'Btn_Farbe
        '
        Me.Btn_Farbe.Location = New System.Drawing.Point(441, 40)
        Me.Btn_Farbe.Name = "Btn_Farbe"
        Me.Btn_Farbe.Size = New System.Drawing.Size(46, 20)
        Me.Btn_Farbe.TabIndex = 13
        Me.Btn_Farbe.Text = "Farbe"
        Me.ToolTip1.SetToolTip(Me.Btn_Farbe, "Farbe diese Laufs in der Karte")
        Me.Btn_Farbe.UseVisualStyleBackColor = True
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(311, 41)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(52, 20)
        Me.NumericUpDown1.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.NumericUpDown1, "Zeit des schnellsten männlichen Läufers")
        Me.NumericUpDown1.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'txt_Wettbewerb
        '
        Me.txt_Wettbewerb.Location = New System.Drawing.Point(10, 41)
        Me.txt_Wettbewerb.MaxLength = 30
        Me.txt_Wettbewerb.Name = "txt_Wettbewerb"
        Me.txt_Wettbewerb.Size = New System.Drawing.Size(165, 20)
        Me.txt_Wettbewerb.TabIndex = 9
        Me.txt_Wettbewerb.Text = "10 km Jedermannlauf"
        Me.ToolTip1.SetToolTip(Me.txt_Wettbewerb, "Name des Laufs")
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(253, 41)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown2.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.NumericUpDown2, "Zeit des langsamsten Läufer")
        Me.NumericUpDown2.Value = New Decimal(New Integer() {17, 0, 0, 0})
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.NumericUpDown3.Location = New System.Drawing.Point(369, 41)
        Me.NumericUpDown3.Maximum = New Decimal(New Integer() {500000, 0, 0, 0})
        Me.NumericUpDown3.Minimum = New Decimal(New Integer() {40, 0, 0, 0})
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(66, 20)
        Me.NumericUpDown3.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.NumericUpDown3, "Streckenlänge im Meter")
        Me.NumericUpDown3.Value = New Decimal(New Integer() {400, 0, 0, 0})
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "H:mm"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(181, 41)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(65, 20)
        Me.DateTimePicker1.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.DateTimePicker1, "Uhrzeit in H:mm")
        Me.DateTimePicker1.Value = New Date(2009, 3, 28, 10, 30, 0, 0)
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.DTP_Endlos_Ende)
        Me.TabPage3.Controls.Add(Me.DTP_Endlos)
        Me.TabPage3.Controls.Add(Me.ChB_Endlos)
        Me.TabPage3.Controls.Add(Me.ChB_Live)
        Me.TabPage3.Controls.Add(Me.Panel1)
        Me.TabPage3.Controls.Add(Me.PictureBox2)
        Me.TabPage3.Controls.Add(Me.ChB_Verteilung)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(669, 493)
        Me.TabPage3.TabIndex = 1
        Me.TabPage3.Text = "Simulation"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'DTP_Endlos_Ende
        '
        Me.DTP_Endlos_Ende.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Endlos_Ende.CustomFormat = "H:mm"
        Me.DTP_Endlos_Ende.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Endlos_Ende.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Endlos_Ende.Location = New System.Drawing.Point(71, 164)
        Me.DTP_Endlos_Ende.Name = "DTP_Endlos_Ende"
        Me.DTP_Endlos_Ende.ShowUpDown = True
        Me.DTP_Endlos_Ende.Size = New System.Drawing.Size(114, 22)
        Me.DTP_Endlos_Ende.TabIndex = 52
        Me.ToolTip1.SetToolTip(Me.DTP_Endlos_Ende, "Ende-Zeit in H:mm")
        Me.DTP_Endlos_Ende.Value = New Date(2009, 3, 28, 16, 30, 0, 0)
        '
        'DTP_Endlos
        '
        Me.DTP_Endlos.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Endlos.CustomFormat = "H:mm"
        Me.DTP_Endlos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Endlos.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Endlos.Location = New System.Drawing.Point(71, 136)
        Me.DTP_Endlos.Name = "DTP_Endlos"
        Me.DTP_Endlos.ShowUpDown = True
        Me.DTP_Endlos.Size = New System.Drawing.Size(114, 22)
        Me.DTP_Endlos.TabIndex = 51
        Me.ToolTip1.SetToolTip(Me.DTP_Endlos, "Begin-Zeit in H:mm")
        Me.DTP_Endlos.Value = New Date(2009, 3, 28, 10, 30, 0, 0)
        '
        'ChB_Endlos
        '
        Me.ChB_Endlos.AutoSize = True
        Me.ChB_Endlos.Location = New System.Drawing.Point(7, 145)
        Me.ChB_Endlos.Name = "ChB_Endlos"
        Me.ChB_Endlos.Size = New System.Drawing.Size(58, 17)
        Me.ChB_Endlos.TabIndex = 50
        Me.ChB_Endlos.Text = "Endlos"
        Me.ChB_Endlos.UseVisualStyleBackColor = True
        '
        'ChB_Live
        '
        Me.ChB_Live.AutoSize = True
        Me.ChB_Live.Location = New System.Drawing.Point(124, 193)
        Me.ChB_Live.Name = "ChB_Live"
        Me.ChB_Live.Size = New System.Drawing.Size(81, 17)
        Me.ChB_Live.TabIndex = 48
        Me.ChB_Live.Text = "Live-Modus"
        Me.ChB_Live.UseVisualStyleBackColor = True
        Me.ChB_Live.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.NumericUpDown4)
        Me.Panel1.Controls.Add(Me.Btn_PCZeit)
        Me.Panel1.Controls.Add(Me.ChB_Simulation)
        Me.Panel1.Controls.Add(Me.DTP_Zeit)
        Me.Panel1.Location = New System.Drawing.Point(10, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(166, 136)
        Me.Panel1.TabIndex = 48
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 15)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Simulationstempo:"
        '
        'NumericUpDown4
        '
        Me.NumericUpDown4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown4.Location = New System.Drawing.Point(120, 97)
        Me.NumericUpDown4.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.NumericUpDown4.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown4.Name = "NumericUpDown4"
        Me.NumericUpDown4.Size = New System.Drawing.Size(38, 26)
        Me.NumericUpDown4.TabIndex = 49
        Me.NumericUpDown4.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Btn_PCZeit
        '
        Me.Btn_PCZeit.Location = New System.Drawing.Point(3, 4)
        Me.Btn_PCZeit.Name = "Btn_PCZeit"
        Me.Btn_PCZeit.Size = New System.Drawing.Size(115, 23)
        Me.Btn_PCZeit.TabIndex = 48
        Me.Btn_PCZeit.Text = "PC-Zeit übernehmen"
        Me.Btn_PCZeit.UseVisualStyleBackColor = True
        '
        'ChB_Simulation
        '
        Me.ChB_Simulation.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChB_Simulation.AutoSize = True
        Me.ChB_Simulation.Location = New System.Drawing.Point(3, 71)
        Me.ChB_Simulation.Name = "ChB_Simulation"
        Me.ChB_Simulation.Size = New System.Drawing.Size(100, 23)
        Me.ChB_Simulation.TabIndex = 47
        Me.ChB_Simulation.Text = "Simulation starten"
        Me.ChB_Simulation.UseVisualStyleBackColor = True
        '
        'DTP_Zeit
        '
        Me.DTP_Zeit.CustomFormat = "H:mm"
        Me.DTP_Zeit.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Zeit.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Zeit.Location = New System.Drawing.Point(4, 30)
        Me.DTP_Zeit.Name = "DTP_Zeit"
        Me.DTP_Zeit.ShowUpDown = True
        Me.DTP_Zeit.Size = New System.Drawing.Size(114, 32)
        Me.DTP_Zeit.TabIndex = 46
        Me.ToolTip1.SetToolTip(Me.DTP_Zeit, "Uhrzeit in H:mm")
        Me.DTP_Zeit.Value = New Date(2009, 3, 28, 10, 30, 0, 0)
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(6, 216)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(199, 371)
        Me.PictureBox2.TabIndex = 39
        Me.PictureBox2.TabStop = False
        '
        'ChB_Verteilung
        '
        Me.ChB_Verteilung.AutoSize = True
        Me.ChB_Verteilung.Checked = True
        Me.ChB_Verteilung.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChB_Verteilung.Location = New System.Drawing.Point(7, 193)
        Me.ChB_Verteilung.Name = "ChB_Verteilung"
        Me.ChB_Verteilung.Size = New System.Drawing.Size(119, 17)
        Me.ChB_Verteilung.TabIndex = 33
        Me.ChB_Verteilung.Text = "Verteilung anzeigen"
        Me.ChB_Verteilung.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Timer1
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgrammToolStripMenuItem, Me.ToolStripMenuItem1, Me.LinksToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(972, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProgrammToolStripMenuItem
        '
        Me.ProgrammToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeendenToolStripMenuItem})
        Me.ProgrammToolStripMenuItem.Name = "ProgrammToolStripMenuItem"
        Me.ProgrammToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.ProgrammToolStripMenuItem.Text = "Programm"
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.BeendenToolStripMenuItem.Text = "Beenden"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MNU_V_neu, Me.MNU_V_öffnen, Me.LiveModusAusToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(92, 20)
        Me.ToolStripMenuItem1.Text = "Veranstaltung"
        '
        'MNU_V_neu
        '
        Me.MNU_V_neu.Name = "MNU_V_neu"
        Me.MNU_V_neu.Size = New System.Drawing.Size(160, 22)
        Me.MNU_V_neu.Text = "&Neu"
        '
        'MNU_V_öffnen
        '
        Me.MNU_V_öffnen.Name = "MNU_V_öffnen"
        Me.MNU_V_öffnen.Size = New System.Drawing.Size(160, 22)
        Me.MNU_V_öffnen.Text = "Ö&ffnen"
        '
        'LiveModusAusToolStripMenuItem
        '
        Me.LiveModusAusToolStripMenuItem.Enabled = False
        Me.LiveModusAusToolStripMenuItem.Name = "LiveModusAusToolStripMenuItem"
        Me.LiveModusAusToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.LiveModusAusToolStripMenuItem.Text = "Live-Modus Aus"
        Me.LiveModusAusToolStripMenuItem.Visible = False
        '
        'LinksToolStripMenuItem
        '
        Me.LinksToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WwwtiergartenlaufdeToolStripMenuItem, Me.WwwmeyervelendeToolStripMenuItem, Me.WwwopenstreetmaporgToolStripMenuItem})
        Me.LinksToolStripMenuItem.Name = "LinksToolStripMenuItem"
        Me.LinksToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.LinksToolStripMenuItem.Text = "Links"
        '
        'WwwtiergartenlaufdeToolStripMenuItem
        '
        Me.WwwtiergartenlaufdeToolStripMenuItem.Name = "WwwtiergartenlaufdeToolStripMenuItem"
        Me.WwwtiergartenlaufdeToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.WwwtiergartenlaufdeToolStripMenuItem.Text = "www.tiergartenlauf.de"
        '
        'WwwmeyervelendeToolStripMenuItem
        '
        Me.WwwmeyervelendeToolStripMenuItem.Name = "WwwmeyervelendeToolStripMenuItem"
        Me.WwwmeyervelendeToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.WwwmeyervelendeToolStripMenuItem.Text = "www.meyer-velen.de"
        '
        'WwwopenstreetmaporgToolStripMenuItem
        '
        Me.WwwopenstreetmaporgToolStripMenuItem.Name = "WwwopenstreetmaporgToolStripMenuItem"
        Me.WwwopenstreetmaporgToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.WwwopenstreetmaporgToolStripMenuItem.Text = "www.openstreetmap.org"
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Speicherort von zeit.ini wählen"
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.simu.My.Resources.Resources.intro
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(497, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(452, 413)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 54
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(972, 491)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Laufveranstaltung Simulator"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNU_V_öffnen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNU_V_neu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Farbe As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txt_Wettbewerb As System.Windows.Forms.TextBox
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_Wettb_hinzu As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_Wettb_edit As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btn_wettb_delete As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lblNumPoints As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents cmb_Strecken As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ChB_Karte As System.Windows.Forms.CheckBox
    Friend WithEvents ChB_Verteilung As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LinksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WwwtiergartenlaufdeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WwwmeyervelendeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgrammToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WwwopenstreetmaporgToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Btn_PCZeit As System.Windows.Forms.Button
    Friend WithEvents ChB_Simulation As System.Windows.Forms.CheckBox
    Friend WithEvents DTP_Zeit As System.Windows.Forms.DateTimePicker
    Friend WithEvents NumericUpDown5 As System.Windows.Forms.NumericUpDown
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Btn_BildSpeichern As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog2 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ChB_Live As System.Windows.Forms.CheckBox
    Friend WithEvents LiveModusAusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChB_Endlos As System.Windows.Forms.CheckBox
    Friend WithEvents DTP_Endlos As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_Endlos_Ende As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
