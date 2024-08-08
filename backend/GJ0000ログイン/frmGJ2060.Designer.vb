Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ2060
    Inherits JBD.Gjs.Win.FormX

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub
    Public Sub New(ByVal pGJSINI_Array As pGJSINI)
        MyBase.New(pGJSINI_Array)
        InitializeComponent()
    End Sub

    'Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DateEraYearField1 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraField1 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField1 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateLiteralField2 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField1 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField3 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField1 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateEraField2 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField4 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField2 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField5 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField2 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField6 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField2 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateEraYearField3 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraDisplayField1 As GrapeCity.Win.Editors.Fields.DateEraDisplayField = New GrapeCity.Win.Editors.Fields.DateEraDisplayField()
        Dim DateLiteralDisplayField1 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateEraYearDisplayField1 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateLiteralDisplayField2 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateMonthDisplayField1 As GrapeCity.Win.Editors.Fields.DateMonthDisplayField = New GrapeCity.Win.Editors.Fields.DateMonthDisplayField()
        Dim DateLiteralDisplayField3 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateDayDisplayField1 As GrapeCity.Win.Editors.Fields.DateDayDisplayField = New GrapeCity.Win.Editors.Fields.DateDayDisplayField()
        Dim DateEraField3 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField7 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateLiteralField8 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField3 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField9 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField3 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.date_KIGEN_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton10 = New GrapeCity.Win.Editors.DropDownButton()
        Me.date_SEIKYU_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton6 = New GrapeCity.Win.Editors.DropDownButton()
        Me.date_SEIKYU_HAKKO_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton7 = New GrapeCity.Win.Editors.DropDownButton()
        Me.txt_KI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_SEIKYU_KAISU = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.cmdCan = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.cbo_KOFU_TUMI_SITEN_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.grpDATAKBN = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_SYORI_KBN3 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_SYORI_KBN2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_SYORI_KBN1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.cbo_JIMUITAKU_CD_T = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cbo_JIMUITAKU_NM_T = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cbo_JIMUITAKU_CD_F = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cbo_JIMUITAKU_NM_F = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton5 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_SEIKYU_HAKKO_NO_NEN = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_SEIKYU_HAKKO_NO_RENBAN = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.lbl_HAKKO_NO_KANJI = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.cbo_KEIYAKUSYA_CD_T = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cbo_KEIYAKUSYA_NM_T = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton11 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.cbo_KEIYAKUSYA_CD_F = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cbo_KEIYAKUSYA_NM_F = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton12 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cmdPreview = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.rbtn_SYORI_KBN0 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.date_KIGEN_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_SEIKYU_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_SEIKYU_HAKKO_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SEIKYU_KAISU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KOFU_TUMI_SITEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDATAKBN.SuspendLayout()
        CType(Me.cbo_JIMUITAKU_CD_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_JIMUITAKU_NM_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_JIMUITAKU_CD_F, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_JIMUITAKU_NM_F, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SEIKYU_HAKKO_NO_NEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SEIKYU_HAKKO_NO_RENBAN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KEIYAKUSYA_CD_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KEIYAKUSYA_NM_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KEIYAKUSYA_CD_F, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KEIYAKUSYA_NM_F, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdPreview)
        Me.pnlButton.Controls.Add(Me.cmdCan)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCan, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdPreview, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        '
        'lblLOGONUSER
        '
        Me.lblLOGONUSER.Text = "さん"
        '
        'lblSysdate
        '
        Me.lblSysdate.Text = "2010年8月26日（木）"
        '
        'cmdEnd
        '
        Me.cmdEnd.TabIndex = 9
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'date_KIGEN_DATE
        '
        Me.date_KIGEN_DATE.DefaultActiveField = DateEraYearField1
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.date_KIGEN_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.date_KIGEN_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_KIGEN_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_KIGEN_DATE.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.date_KIGEN_DATE.InputCheck = True
        Me.date_KIGEN_DATE.Location = New System.Drawing.Point(163, 285)
        Me.date_KIGEN_DATE.Name = "date_KIGEN_DATE"
        Me.GcShortcut1.SetShortcuts(Me.date_KIGEN_DATE, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.date_KIGEN_DATE, Object), CType(Me.date_KIGEN_DATE, Object), CType(Me.date_KIGEN_DATE, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.date_KIGEN_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton10})
        Me.date_KIGEN_DATE.Size = New System.Drawing.Size(129, 21)
        Me.date_KIGEN_DATE.Spin.AllowSpin = False
        Me.date_KIGEN_DATE.TabIndex = 8
        Me.date_KIGEN_DATE.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        '
        'DropDownButton10
        '
        Me.DropDownButton10.Name = "DropDownButton10"
        '
        'date_SEIKYU_DATE
        '
        Me.date_SEIKYU_DATE.Enabled = False
        DateLiteralField5.Text = "/"
        DateLiteralField6.Text = "/"
        Me.date_SEIKYU_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateLiteralField4, DateEraYearField2, DateLiteralField5, DateMonthField2, DateLiteralField6, DateDayField2})
        Me.date_SEIKYU_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_SEIKYU_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_SEIKYU_DATE.HighlightText = GrapeCity.Win.Editors.HighlightText.Field
        Me.date_SEIKYU_DATE.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.date_SEIKYU_DATE.InputCheck = True
        Me.date_SEIKYU_DATE.Location = New System.Drawing.Point(163, 239)
        Me.date_SEIKYU_DATE.Name = "date_SEIKYU_DATE"
        Me.GcShortcut1.SetShortcuts(Me.date_SEIKYU_DATE, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.date_SEIKYU_DATE, Object), CType(Me.date_SEIKYU_DATE, Object), CType(Me.date_SEIKYU_DATE, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.date_SEIKYU_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.date_SEIKYU_DATE.Size = New System.Drawing.Size(129, 21)
        Me.date_SEIKYU_DATE.Spin.AllowSpin = False
        Me.date_SEIKYU_DATE.TabIndex = 7
        Me.date_SEIKYU_DATE.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        '
        'DropDownButton6
        '
        Me.DropDownButton6.Name = "DropDownButton6"
        '
        'date_SEIKYU_HAKKO_DATE
        '
        Me.date_SEIKYU_HAKKO_DATE.DefaultActiveField = DateEraYearField3
        DateEraYearDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField2.Text = "/"
        DateMonthDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField3.Text = "/"
        DateDayDisplayField1.ShowLeadingZero = True
        Me.date_SEIKYU_HAKKO_DATE.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField1, DateLiteralDisplayField1, DateEraYearDisplayField1, DateLiteralDisplayField2, DateMonthDisplayField1, DateLiteralDisplayField3, DateDayDisplayField1})
        DateLiteralField8.Text = "/"
        DateLiteralField9.Text = "/"
        Me.date_SEIKYU_HAKKO_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField3, DateLiteralField7, DateEraYearField3, DateLiteralField8, DateMonthField3, DateLiteralField9, DateDayField3})
        Me.date_SEIKYU_HAKKO_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_SEIKYU_HAKKO_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_SEIKYU_HAKKO_DATE.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.date_SEIKYU_HAKKO_DATE.InputCheck = True
        Me.date_SEIKYU_HAKKO_DATE.Location = New System.Drawing.Point(163, 328)
        Me.date_SEIKYU_HAKKO_DATE.Name = "date_SEIKYU_HAKKO_DATE"
        Me.GcShortcut1.SetShortcuts(Me.date_SEIKYU_HAKKO_DATE, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.date_SEIKYU_HAKKO_DATE, Object), CType(Me.date_SEIKYU_HAKKO_DATE, Object), CType(Me.date_SEIKYU_HAKKO_DATE, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.date_SEIKYU_HAKKO_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton7})
        Me.date_SEIKYU_HAKKO_DATE.Size = New System.Drawing.Size(129, 21)
        Me.date_SEIKYU_HAKKO_DATE.Spin.AllowSpin = False
        Me.date_SEIKYU_HAKKO_DATE.TabIndex = 9
        Me.date_SEIKYU_HAKKO_DATE.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        '
        'DropDownButton7
        '
        Me.DropDownButton7.Name = "DropDownButton7"
        '
        'txt_KI
        '
        Me.txt_KI.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_KI.DropDown.AllowDrop = False
        Me.txt_KI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_KI.Format = "9"
        Me.txt_KI.HighlightText = True
        Me.txt_KI.InputCheck = True
        Me.txt_KI.Location = New System.Drawing.Point(188, 145)
        Me.txt_KI.MaxLength = 2
        Me.txt_KI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KI.Name = "txt_KI"
        Me.GcShortcut1.SetShortcuts(Me.txt_KI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_KI, Object)}, New String() {"ShortcutClear"}))
        Me.txt_KI.Size = New System.Drawing.Size(26, 20)
        Me.txt_KI.TabIndex = 1
        Me.txt_KI.Text = "99"
        '
        'txt_SEIKYU_KAISU
        '
        Me.txt_SEIKYU_KAISU.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_SEIKYU_KAISU.DropDown.AllowDrop = False
        Me.txt_SEIKYU_KAISU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_SEIKYU_KAISU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_SEIKYU_KAISU.Format = "9"
        Me.txt_SEIKYU_KAISU.HighlightText = True
        Me.txt_SEIKYU_KAISU.InputCheck = True
        Me.txt_SEIKYU_KAISU.Location = New System.Drawing.Point(163, 190)
        Me.txt_SEIKYU_KAISU.MaxLength = 3
        Me.txt_SEIKYU_KAISU.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_SEIKYU_KAISU.Name = "txt_SEIKYU_KAISU"
        Me.GcShortcut1.SetShortcuts(Me.txt_SEIKYU_KAISU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_SEIKYU_KAISU, Object)}, New String() {"ShortcutClear"}))
        Me.txt_SEIKYU_KAISU.Size = New System.Drawing.Size(35, 20)
        Me.txt_SEIKYU_KAISU.TabIndex = 2
        Me.txt_SEIKYU_KAISU.Text = "999"
        '
        'cmdCan
        '
        Me.cmdCan.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCan.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCan.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCan.Location = New System.Drawing.Point(140, 6)
        Me.cmdCan.Name = "cmdCan"
        Me.cmdCan.Size = New System.Drawing.Size(92, 44)
        Me.cmdCan.TabIndex = 1
        Me.cmdCan.Text = "キャンセル"
        Me.cmdCan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(27, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 872
        Me.Label2.Text = "□出力区分"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(27, 193)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 15)
        Me.Label8.TabIndex = 882
        Me.Label8.Text = "■請求(返還)回数"
        '
        'cbo_KOFU_TUMI_SITEN_CD
        '
        Me.cbo_KOFU_TUMI_SITEN_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cbo_KOFU_TUMI_SITEN_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_KOFU_TUMI_SITEN_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_KOFU_TUMI_SITEN_CD.Format = "9"
        Me.cbo_KOFU_TUMI_SITEN_CD.HighlightText = True
        Me.cbo_KOFU_TUMI_SITEN_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_KOFU_TUMI_SITEN_CD.ListHeaderPane.Height = 22
        Me.cbo_KOFU_TUMI_SITEN_CD.Location = New System.Drawing.Point(560, 689)
        Me.cbo_KOFU_TUMI_SITEN_CD.MaxLength = 3
        Me.cbo_KOFU_TUMI_SITEN_CD.Name = "cbo_KOFU_TUMI_SITEN_CD"
        Me.cbo_KOFU_TUMI_SITEN_CD.Size = New System.Drawing.Size(40, 22)
        Me.cbo_KOFU_TUMI_SITEN_CD.TabIndex = 927
        Me.cbo_KOFU_TUMI_SITEN_CD.Text = "000"
        '
        'grpDATAKBN
        '
        Me.grpDATAKBN.Controls.Add(Me.rbtn_SYORI_KBN0)
        Me.grpDATAKBN.Controls.Add(Me.rbtn_SYORI_KBN3)
        Me.grpDATAKBN.Controls.Add(Me.rbtn_SYORI_KBN2)
        Me.grpDATAKBN.Controls.Add(Me.rbtn_SYORI_KBN1)
        Me.grpDATAKBN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grpDATAKBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpDATAKBN.Location = New System.Drawing.Point(163, 77)
        Me.grpDATAKBN.Name = "grpDATAKBN"
        Me.grpDATAKBN.Size = New System.Drawing.Size(777, 38)
        Me.grpDATAKBN.TabIndex = 0
        Me.grpDATAKBN.TabStop = False
        '
        'rbtn_SYORI_KBN3
        '
        Me.rbtn_SYORI_KBN3.AutoSize = True
        Me.rbtn_SYORI_KBN3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_SYORI_KBN3.Location = New System.Drawing.Point(425, 12)
        Me.rbtn_SYORI_KBN3.Name = "rbtn_SYORI_KBN3"
        Me.rbtn_SYORI_KBN3.Size = New System.Drawing.Size(346, 20)
        Me.rbtn_SYORI_KBN3.TabIndex = 3
        Me.rbtn_SYORI_KBN3.Text = "修正発行(返還期限、発行日、発信番号変更可能)"
        Me.rbtn_SYORI_KBN3.UseVisualStyleBackColor = True
        '
        'rbtn_SYORI_KBN2
        '
        Me.rbtn_SYORI_KBN2.AutoSize = True
        Me.rbtn_SYORI_KBN2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_SYORI_KBN2.Location = New System.Drawing.Point(237, 12)
        Me.rbtn_SYORI_KBN2.Name = "rbtn_SYORI_KBN2"
        Me.rbtn_SYORI_KBN2.Size = New System.Drawing.Size(172, 20)
        Me.rbtn_SYORI_KBN2.TabIndex = 2
        Me.rbtn_SYORI_KBN2.Text = "再発行(初回と同内容)"
        Me.rbtn_SYORI_KBN2.UseVisualStyleBackColor = True
        '
        'rbtn_SYORI_KBN1
        '
        Me.rbtn_SYORI_KBN1.AutoSize = True
        Me.rbtn_SYORI_KBN1.Checked = True
        Me.rbtn_SYORI_KBN1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_SYORI_KBN1.Location = New System.Drawing.Point(120, 12)
        Me.rbtn_SYORI_KBN1.Name = "rbtn_SYORI_KBN1"
        Me.rbtn_SYORI_KBN1.Size = New System.Drawing.Size(91, 20)
        Me.rbtn_SYORI_KBN1.TabIndex = 1
        Me.rbtn_SYORI_KBN1.TabStop = True
        Me.rbtn_SYORI_KBN1.Text = "初回発行"
        Me.rbtn_SYORI_KBN1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(27, 285)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 15)
        Me.Label10.TabIndex = 976
        Me.Label10.Text = "■返還期限"
        '
        'cbo_JIMUITAKU_CD_T
        '
        Me.cbo_JIMUITAKU_CD_T.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cbo_JIMUITAKU_CD_T.DropDown.AllowDrop = False
        Me.cbo_JIMUITAKU_CD_T.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_JIMUITAKU_CD_T.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_JIMUITAKU_CD_T.Format = "9"
        Me.cbo_JIMUITAKU_CD_T.HighlightText = True
        Me.cbo_JIMUITAKU_CD_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_JIMUITAKU_CD_T.ListHeaderPane.Height = 22
        Me.cbo_JIMUITAKU_CD_T.Location = New System.Drawing.Point(618, 423)
        Me.cbo_JIMUITAKU_CD_T.MaxLength = 3
        Me.cbo_JIMUITAKU_CD_T.Name = "cbo_JIMUITAKU_CD_T"
        Me.cbo_JIMUITAKU_CD_T.Size = New System.Drawing.Size(38, 22)
        Me.cbo_JIMUITAKU_CD_T.Spin.AllowSpin = False
        Me.cbo_JIMUITAKU_CD_T.TabIndex = 23
        Me.cbo_JIMUITAKU_CD_T.Tag = "事務委託先"
        Me.cbo_JIMUITAKU_CD_T.Text = "999"
        '
        'cbo_JIMUITAKU_NM_T
        '
        Me.cbo_JIMUITAKU_NM_T.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_JIMUITAKU_NM_T.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_JIMUITAKU_NM_T.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_JIMUITAKU_NM_T.ListHeaderPane.Height = 22
        Me.cbo_JIMUITAKU_NM_T.ListHeaderPane.Visible = False
        Me.cbo_JIMUITAKU_NM_T.Location = New System.Drawing.Point(664, 423)
        Me.cbo_JIMUITAKU_NM_T.Name = "cbo_JIMUITAKU_NM_T"
        Me.cbo_JIMUITAKU_NM_T.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.cbo_JIMUITAKU_NM_T.Size = New System.Drawing.Size(372, 22)
        Me.cbo_JIMUITAKU_NM_T.TabIndex = 24
        Me.cbo_JIMUITAKU_NM_T.TabStop = False
        Me.cbo_JIMUITAKU_NM_T.Tag = "都道府県"
        '
        'DropDownButton3
        '
        Me.DropDownButton3.Name = "DropDownButton3"
        '
        'cbo_JIMUITAKU_CD_F
        '
        Me.cbo_JIMUITAKU_CD_F.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cbo_JIMUITAKU_CD_F.DropDown.AllowDrop = False
        Me.cbo_JIMUITAKU_CD_F.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_JIMUITAKU_CD_F.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_JIMUITAKU_CD_F.Format = "9"
        Me.cbo_JIMUITAKU_CD_F.HighlightText = True
        Me.cbo_JIMUITAKU_CD_F.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_JIMUITAKU_CD_F.ListHeaderPane.Height = 22
        Me.cbo_JIMUITAKU_CD_F.Location = New System.Drawing.Point(163, 420)
        Me.cbo_JIMUITAKU_CD_F.MaxLength = 3
        Me.cbo_JIMUITAKU_CD_F.Name = "cbo_JIMUITAKU_CD_F"
        Me.cbo_JIMUITAKU_CD_F.Size = New System.Drawing.Size(38, 22)
        Me.cbo_JIMUITAKU_CD_F.Spin.AllowSpin = False
        Me.cbo_JIMUITAKU_CD_F.TabIndex = 21
        Me.cbo_JIMUITAKU_CD_F.Tag = "事務委託先"
        Me.cbo_JIMUITAKU_CD_F.Text = "000"
        '
        'cbo_JIMUITAKU_NM_F
        '
        Me.cbo_JIMUITAKU_NM_F.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_JIMUITAKU_NM_F.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_JIMUITAKU_NM_F.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_JIMUITAKU_NM_F.ListHeaderPane.Height = 22
        Me.cbo_JIMUITAKU_NM_F.ListHeaderPane.Visible = False
        Me.cbo_JIMUITAKU_NM_F.Location = New System.Drawing.Point(205, 420)
        Me.cbo_JIMUITAKU_NM_F.Name = "cbo_JIMUITAKU_NM_F"
        Me.cbo_JIMUITAKU_NM_F.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.cbo_JIMUITAKU_NM_F.Size = New System.Drawing.Size(372, 22)
        Me.cbo_JIMUITAKU_NM_F.TabIndex = 22
        Me.cbo_JIMUITAKU_NM_F.TabStop = False
        Me.cbo_JIMUITAKU_NM_F.Tag = "都道府県名"
        '
        'DropDownButton5
        '
        Me.DropDownButton5.Name = "DropDownButton5"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(27, 242)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 15)
        Me.Label9.TabIndex = 983
        Me.Label9.Text = "■返還年月日"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(27, 328)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 15)
        Me.Label12.TabIndex = 985
        Me.Label12.Text = "■発行日"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(27, 377)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 15)
        Me.Label13.TabIndex = 986
        Me.Label13.Text = "■発信番号"
        '
        'txt_SEIKYU_HAKKO_NO_NEN
        '
        Me.txt_SEIKYU_HAKKO_NO_NEN.DropDown.AllowDrop = False
        Me.txt_SEIKYU_HAKKO_NO_NEN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_SEIKYU_HAKKO_NO_NEN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_SEIKYU_HAKKO_NO_NEN.Format = "9"
        Me.txt_SEIKYU_HAKKO_NO_NEN.HighlightText = True
        Me.txt_SEIKYU_HAKKO_NO_NEN.InputCheck = True
        Me.txt_SEIKYU_HAKKO_NO_NEN.Location = New System.Drawing.Point(206, 374)
        Me.txt_SEIKYU_HAKKO_NO_NEN.MaxLength = 2
        Me.txt_SEIKYU_HAKKO_NO_NEN.Name = "txt_SEIKYU_HAKKO_NO_NEN"
        Me.txt_SEIKYU_HAKKO_NO_NEN.Size = New System.Drawing.Size(28, 22)
        Me.txt_SEIKYU_HAKKO_NO_NEN.TabIndex = 10
        Me.txt_SEIKYU_HAKKO_NO_NEN.Text = "00"
        '
        'txt_SEIKYU_HAKKO_NO_RENBAN
        '
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.DropDown.AllowDrop = False
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.Format = "9"
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.HighlightText = True
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.InputCheck = True
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.Location = New System.Drawing.Point(282, 374)
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.MaxLength = 4
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.Name = "txt_SEIKYU_HAKKO_NO_RENBAN"
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.Size = New System.Drawing.Size(45, 22)
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.TabIndex = 11
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.Text = "0000"
        '
        'lbl_HAKKO_NO_KANJI
        '
        Me.lbl_HAKKO_NO_KANJI.AutoSize = True
        Me.lbl_HAKKO_NO_KANJI.BackColor = System.Drawing.Color.Transparent
        Me.lbl_HAKKO_NO_KANJI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_HAKKO_NO_KANJI.Location = New System.Drawing.Point(163, 377)
        Me.lbl_HAKKO_NO_KANJI.Name = "lbl_HAKKO_NO_KANJI"
        Me.lbl_HAKKO_NO_KANJI.Size = New System.Drawing.Size(37, 15)
        Me.lbl_HAKKO_NO_KANJI.TabIndex = 989
        Me.lbl_HAKKO_NO_KANJI.Text = "＠＠"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(27, 423)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(97, 15)
        Me.Label15.TabIndex = 990
        Me.Label15.Text = "□事務委託先"
        '
        'cbo_KEIYAKUSYA_CD_T
        '
        Me.cbo_KEIYAKUSYA_CD_T.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cbo_KEIYAKUSYA_CD_T.DropDown.AllowDrop = False
        Me.cbo_KEIYAKUSYA_CD_T.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_KEIYAKUSYA_CD_T.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_KEIYAKUSYA_CD_T.Format = "9"
        Me.cbo_KEIYAKUSYA_CD_T.HighlightText = True
        Me.cbo_KEIYAKUSYA_CD_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_KEIYAKUSYA_CD_T.ListHeaderPane.Height = 22
        Me.cbo_KEIYAKUSYA_CD_T.Location = New System.Drawing.Point(618, 470)
        Me.cbo_KEIYAKUSYA_CD_T.MaxLength = 5
        Me.cbo_KEIYAKUSYA_CD_T.Name = "cbo_KEIYAKUSYA_CD_T"
        Me.cbo_KEIYAKUSYA_CD_T.Size = New System.Drawing.Size(50, 22)
        Me.cbo_KEIYAKUSYA_CD_T.Spin.AllowSpin = False
        Me.cbo_KEIYAKUSYA_CD_T.TabIndex = 27
        Me.cbo_KEIYAKUSYA_CD_T.Tag = "生産者番号"
        Me.cbo_KEIYAKUSYA_CD_T.Text = "00000"
        '
        'cbo_KEIYAKUSYA_NM_T
        '
        Me.cbo_KEIYAKUSYA_NM_T.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_KEIYAKUSYA_NM_T.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_KEIYAKUSYA_NM_T.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_KEIYAKUSYA_NM_T.ListHeaderPane.Height = 22
        Me.cbo_KEIYAKUSYA_NM_T.ListHeaderPane.Visible = False
        Me.cbo_KEIYAKUSYA_NM_T.Location = New System.Drawing.Point(676, 470)
        Me.cbo_KEIYAKUSYA_NM_T.Name = "cbo_KEIYAKUSYA_NM_T"
        Me.cbo_KEIYAKUSYA_NM_T.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton11})
        Me.cbo_KEIYAKUSYA_NM_T.Size = New System.Drawing.Size(360, 22)
        Me.cbo_KEIYAKUSYA_NM_T.TabIndex = 28
        Me.cbo_KEIYAKUSYA_NM_T.TabStop = False
        Me.cbo_KEIYAKUSYA_NM_T.Tag = "生産者"
        '
        'DropDownButton11
        '
        Me.DropDownButton11.Name = "DropDownButton11"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(27, 474)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(97, 15)
        Me.Label16.TabIndex = 995
        Me.Label16.Text = "□契約者番号"
        '
        'cbo_KEIYAKUSYA_CD_F
        '
        Me.cbo_KEIYAKUSYA_CD_F.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cbo_KEIYAKUSYA_CD_F.DropDown.AllowDrop = False
        Me.cbo_KEIYAKUSYA_CD_F.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_KEIYAKUSYA_CD_F.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_KEIYAKUSYA_CD_F.Format = "9"
        Me.cbo_KEIYAKUSYA_CD_F.HighlightText = True
        Me.cbo_KEIYAKUSYA_CD_F.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_KEIYAKUSYA_CD_F.ListHeaderPane.Height = 22
        Me.cbo_KEIYAKUSYA_CD_F.Location = New System.Drawing.Point(163, 470)
        Me.cbo_KEIYAKUSYA_CD_F.MaxLength = 5
        Me.cbo_KEIYAKUSYA_CD_F.Name = "cbo_KEIYAKUSYA_CD_F"
        Me.cbo_KEIYAKUSYA_CD_F.Size = New System.Drawing.Size(50, 22)
        Me.cbo_KEIYAKUSYA_CD_F.Spin.AllowSpin = False
        Me.cbo_KEIYAKUSYA_CD_F.TabIndex = 25
        Me.cbo_KEIYAKUSYA_CD_F.Tag = "生産者番号"
        Me.cbo_KEIYAKUSYA_CD_F.Text = "00000"
        '
        'cbo_KEIYAKUSYA_NM_F
        '
        Me.cbo_KEIYAKUSYA_NM_F.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_KEIYAKUSYA_NM_F.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_KEIYAKUSYA_NM_F.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_KEIYAKUSYA_NM_F.ListHeaderPane.Height = 22
        Me.cbo_KEIYAKUSYA_NM_F.ListHeaderPane.Visible = False
        Me.cbo_KEIYAKUSYA_NM_F.Location = New System.Drawing.Point(219, 471)
        Me.cbo_KEIYAKUSYA_NM_F.Name = "cbo_KEIYAKUSYA_NM_F"
        Me.cbo_KEIYAKUSYA_NM_F.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton12})
        Me.cbo_KEIYAKUSYA_NM_F.Size = New System.Drawing.Size(360, 22)
        Me.cbo_KEIYAKUSYA_NM_F.TabIndex = 26
        Me.cbo_KEIYAKUSYA_NM_F.TabStop = False
        Me.cbo_KEIYAKUSYA_NM_F.Tag = "生産者"
        '
        'DropDownButton12
        '
        Me.DropDownButton12.Name = "DropDownButton12"
        '
        'cmdPreview
        '
        Me.cmdPreview.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdPreview.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPreview.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdPreview.Location = New System.Drawing.Point(32, 6)
        Me.cmdPreview.Name = "cmdPreview"
        Me.cmdPreview.Size = New System.Drawing.Size(92, 44)
        Me.cmdPreview.TabIndex = 0
        Me.cmdPreview.Text = "プレビュー"
        Me.cmdPreview.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(590, 426)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(22, 15)
        Me.Label18.TabIndex = 997
        Me.Label18.Text = "～"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(590, 474)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(22, 15)
        Me.Label19.TabIndex = 998
        Me.Label19.Text = "～"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(333, 377)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(22, 15)
        Me.Label14.TabIndex = 1000
        Me.Label14.Text = "号"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(238, 377)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 15)
        Me.Label4.TabIndex = 1004
        Me.Label4.Text = "発"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(260, 377)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 15)
        Me.Label7.TabIndex = 1005
        Me.Label7.Text = "第"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(27, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 1108
        Me.Label6.Text = "■対象期"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(163, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 15)
        Me.Label3.TabIndex = 1109
        Me.Label3.Text = "第"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(218, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 15)
        Me.Label5.TabIndex = 1110
        Me.Label5.Text = "期"
        '
        'rbtn_SYORI_KBN0
        '
        Me.rbtn_SYORI_KBN0.AutoSize = True
        Me.rbtn_SYORI_KBN0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_SYORI_KBN0.Location = New System.Drawing.Point(21, 12)
        Me.rbtn_SYORI_KBN0.Name = "rbtn_SYORI_KBN0"
        Me.rbtn_SYORI_KBN0.Size = New System.Drawing.Size(76, 20)
        Me.rbtn_SYORI_KBN0.TabIndex = 6
        Me.rbtn_SYORI_KBN0.Text = "仮発行"
        Me.rbtn_SYORI_KBN0.UseVisualStyleBackColor = True
        '
        'frmGJ2060
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.txt_SEIKYU_KAISU)
        Me.Controls.Add(Me.txt_KI)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_SEIKYU_HAKKO_NO_NEN)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txt_SEIKYU_HAKKO_NO_RENBAN)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cbo_KEIYAKUSYA_CD_T)
        Me.Controls.Add(Me.cbo_KEIYAKUSYA_NM_T)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cbo_KEIYAKUSYA_CD_F)
        Me.Controls.Add(Me.cbo_KEIYAKUSYA_NM_F)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lbl_HAKKO_NO_KANJI)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.date_SEIKYU_HAKKO_DATE)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.date_SEIKYU_DATE)
        Me.Controls.Add(Me.cbo_JIMUITAKU_CD_F)
        Me.Controls.Add(Me.cbo_JIMUITAKU_NM_F)
        Me.Controls.Add(Me.cbo_JIMUITAKU_CD_T)
        Me.Controls.Add(Me.cbo_JIMUITAKU_NM_T)
        Me.Controls.Add(Me.date_KIGEN_DATE)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.grpDATAKBN)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmGJ2060"
        Me.Text = "(mX)"
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.grpDATAKBN, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.date_KIGEN_DATE, 0)
        Me.Controls.SetChildIndex(Me.cbo_JIMUITAKU_NM_T, 0)
        Me.Controls.SetChildIndex(Me.cbo_JIMUITAKU_CD_T, 0)
        Me.Controls.SetChildIndex(Me.cbo_JIMUITAKU_NM_F, 0)
        Me.Controls.SetChildIndex(Me.cbo_JIMUITAKU_CD_F, 0)
        Me.Controls.SetChildIndex(Me.date_SEIKYU_DATE, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.date_SEIKYU_HAKKO_DATE, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.lbl_HAKKO_NO_KANJI, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.cbo_KEIYAKUSYA_NM_F, 0)
        Me.Controls.SetChildIndex(Me.cbo_KEIYAKUSYA_CD_F, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.cbo_KEIYAKUSYA_NM_T, 0)
        Me.Controls.SetChildIndex(Me.cbo_KEIYAKUSYA_CD_T, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.txt_SEIKYU_HAKKO_NO_RENBAN, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txt_SEIKYU_HAKKO_NO_NEN, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txt_KI, 0)
        Me.Controls.SetChildIndex(Me.txt_SEIKYU_KAISU, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.date_KIGEN_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_SEIKYU_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_SEIKYU_HAKKO_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SEIKYU_KAISU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KOFU_TUMI_SITEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDATAKBN.ResumeLayout(False)
        Me.grpDATAKBN.PerformLayout()
        CType(Me.cbo_JIMUITAKU_CD_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_JIMUITAKU_NM_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_JIMUITAKU_CD_F, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_JIMUITAKU_NM_F, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SEIKYU_HAKKO_NO_NEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SEIKYU_HAKKO_NO_RENBAN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KEIYAKUSYA_CD_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KEIYAKUSYA_NM_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KEIYAKUSYA_CD_F, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KEIYAKUSYA_NM_F, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents cmdCan As JBD.Gjs.Win.JButton
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents cbo_KOFU_TUMI_SITEN_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents grpDATAKBN As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtn_SYORI_KBN2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_SYORI_KBN1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents date_KIGEN_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton10 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents rbtn_SYORI_KBN3 As JBD.Gjs.Win.RadioButton
    Friend WithEvents cbo_JIMUITAKU_CD_T As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cbo_JIMUITAKU_NM_T As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cbo_JIMUITAKU_CD_F As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cbo_JIMUITAKU_NM_F As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton5 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents date_SEIKYU_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton6 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents date_SEIKYU_HAKKO_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton7 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents txt_SEIKYU_HAKKO_NO_NEN As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_SEIKYU_HAKKO_NO_RENBAN As JBD.Gjs.Win.GcTextBox
    Friend WithEvents lbl_HAKKO_NO_KANJI As JBD.Gjs.Win.Label
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents cbo_KEIYAKUSYA_CD_T As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cbo_KEIYAKUSYA_NM_T As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton11 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents cbo_KEIYAKUSYA_CD_F As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cbo_KEIYAKUSYA_NM_F As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton12 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cmdPreview As JBD.Gjs.Win.JButton
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents txt_SEIKYU_KAISU As JBD.Gjs.Win.GcTextBox
    Friend WithEvents rbtn_SYORI_KBN0 As JBD.Gjs.Win.RadioButton
End Class
