Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ8030
    Inherits JBD.Gjs.Win.FormL

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
        Dim MaskLiteralField1 As GrapeCity.Win.Editors.Fields.MaskLiteralField = New GrapeCity.Win.Editors.Fields.MaskLiteralField()
        Dim MaskPatternField1 As GrapeCity.Win.Editors.Fields.MaskPatternField = New GrapeCity.Win.Editors.Fields.MaskPatternField()
        Dim MaskLiteralField2 As GrapeCity.Win.Editors.Fields.MaskLiteralField = New GrapeCity.Win.Editors.Fields.MaskLiteralField()
        Dim MaskPatternField2 As GrapeCity.Win.Editors.Fields.MaskPatternField = New GrapeCity.Win.Editors.Fields.MaskPatternField()
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.txt_YAKUMEI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_KAICHO_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_YOBI1 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_JIGYO_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.msk_POST = New JBD.Gjs.Win.GcMask(Me.components)
        Me.txt_E_MAIL1 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_E_MAIL2 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_KYOKAI_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_HAKKO_NO_KANJI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_HP_URL = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.cmdSav = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdCancel = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_ADDR2 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_ADDR1 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_TEL1 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_FAX1 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_TEL2 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_FAX2 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_KOFU_KAISYA_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_KOFU_KOZA_NO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.cbo_KOFU_KOZA_SYUBETU = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cbo_KOFU_KOZA_SYUBETU_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton6 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.cbo_KOFU_BANK_SITEN_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cbo_KOFU_BANK_SITEN_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton5 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label21 = New JBD.Gjs.Win.Label(Me.components)
        Me.cbo_KOFU_BANK_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cbo_KOFU_BANK_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label22 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
        Me.cbo_KOFU_TUMI_SITEN_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.Label38 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label25 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_KOFU_SYUBETU = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_FURI_SYUBETU = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_KOFU_CD_KBN = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label31 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_KOFU_KAISYA_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label32 = New JBD.Gjs.Win.Label(Me.components)
        Me.btnFIRST = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label33 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label37 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label20 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_FURI_KOZA_MEIGI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_FURI_KOZA_MEIGI_KANA = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label23 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label30 = New JBD.Gjs.Win.Label(Me.components)
        Me.DropDownButton11 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cbo_FURI_BANK_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cbo_FURI_BANK_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.Label29 = New JBD.Gjs.Win.Label(Me.components)
        Me.DropDownButton10 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cbo_FURI_BANK_SITEN_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cbo_FURI_BANK_SITEN_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.Label28 = New JBD.Gjs.Win.Label(Me.components)
        Me.DropDownButton9 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cbo_FURI_KOZA_SYUBETU_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cbo_FURI_KOZA_SYUBETU = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.Label27 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_FURI_KOZA_NO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label26 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_TOUROKU_NO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label34 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.txt_YAKUMEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KAICHO_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_YOBI1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_JIGYO_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.msk_POST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_E_MAIL1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_E_MAIL2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KYOKAI_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_HAKKO_NO_KANJI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_HP_URL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TEL1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FAX1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TEL2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FAX2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KOFU_KAISYA_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KOFU_KOZA_NO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KOFU_KOZA_SYUBETU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KOFU_KOZA_SYUBETU_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KOFU_BANK_SITEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KOFU_BANK_SITEN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KOFU_BANK_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KOFU_BANK_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KOFU_TUMI_SITEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KOFU_SYUBETU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FURI_SYUBETU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KOFU_CD_KBN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KOFU_KAISYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FURI_KOZA_MEIGI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FURI_KOZA_MEIGI_KANA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_FURI_BANK_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_FURI_BANK_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_FURI_BANK_SITEN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_FURI_BANK_SITEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_FURI_KOZA_SYUBETU_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_FURI_KOZA_SYUBETU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FURI_KOZA_NO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TOUROKU_NO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdCancel)
        Me.pnlButton.Controls.Add(Me.cmdSav)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSav, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCancel, 0)
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
        Me.cmdEnd.TabIndex = 2
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'txt_YAKUMEI
        '
        Me.txt_YAKUMEI.DropDown.AllowDrop = False
        Me.txt_YAKUMEI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_YAKUMEI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_YAKUMEI.HighlightText = True
        Me.txt_YAKUMEI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_YAKUMEI.InputCheck = True
        Me.txt_YAKUMEI.Location = New System.Drawing.Point(143, 97)
        Me.txt_YAKUMEI.MaxLength = 30
        Me.txt_YAKUMEI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_YAKUMEI.Name = "txt_YAKUMEI"
        Me.GcShortcut1.SetShortcuts(Me.txt_YAKUMEI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_YAKUMEI, Object)}, New String() {"ShortcutClear"}))
        Me.txt_YAKUMEI.Size = New System.Drawing.Size(278, 20)
        Me.txt_YAKUMEI.TabIndex = 1
        Me.txt_YAKUMEI.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'txt_KAICHO_NAME
        '
        Me.txt_KAICHO_NAME.DropDown.AllowDrop = False
        Me.txt_KAICHO_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KAICHO_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_KAICHO_NAME.HighlightText = True
        Me.txt_KAICHO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_KAICHO_NAME.InputCheck = True
        Me.txt_KAICHO_NAME.Location = New System.Drawing.Point(143, 124)
        Me.txt_KAICHO_NAME.MaxLength = 30
        Me.txt_KAICHO_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KAICHO_NAME.Name = "txt_KAICHO_NAME"
        Me.GcShortcut1.SetShortcuts(Me.txt_KAICHO_NAME, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_KAICHO_NAME, Object)}, New String() {"ShortcutClear"}))
        Me.txt_KAICHO_NAME.Size = New System.Drawing.Size(278, 20)
        Me.txt_KAICHO_NAME.TabIndex = 2
        Me.txt_KAICHO_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'txt_YOBI1
        '
        Me.txt_YOBI1.DropDown.AllowDrop = False
        Me.txt_YOBI1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_YOBI1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_YOBI1.HighlightText = True
        Me.txt_YOBI1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_YOBI1.Location = New System.Drawing.Point(634, 127)
        Me.txt_YOBI1.MaxLength = 30
        Me.txt_YOBI1.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_YOBI1.Name = "txt_YOBI1"
        Me.GcShortcut1.SetShortcuts(Me.txt_YOBI1, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_YOBI1, Object)}, New String() {"ShortcutClear"}))
        Me.txt_YOBI1.Size = New System.Drawing.Size(278, 20)
        Me.txt_YOBI1.TabIndex = 5
        Me.txt_YOBI1.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'txt_JIGYO_NAME
        '
        Me.txt_JIGYO_NAME.DropDown.AllowDrop = False
        Me.txt_JIGYO_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_JIGYO_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_JIGYO_NAME.HighlightText = True
        Me.txt_JIGYO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_JIGYO_NAME.InputCheck = True
        Me.txt_JIGYO_NAME.Location = New System.Drawing.Point(634, 74)
        Me.txt_JIGYO_NAME.MaxLength = 30
        Me.txt_JIGYO_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_JIGYO_NAME.Name = "txt_JIGYO_NAME"
        Me.GcShortcut1.SetShortcuts(Me.txt_JIGYO_NAME, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_JIGYO_NAME, Object)}, New String() {"ShortcutClear"}))
        Me.txt_JIGYO_NAME.Size = New System.Drawing.Size(278, 20)
        Me.txt_JIGYO_NAME.TabIndex = 3
        Me.txt_JIGYO_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'msk_POST
        '
        Me.msk_POST.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        MaskLiteralField1.Text = "〒 "
        MaskPatternField1.MaxLength = 3
        MaskPatternField1.MinLength = 3
        MaskPatternField1.Pattern = "\D"
        MaskLiteralField2.Text = "-"
        MaskPatternField2.MaxLength = 4
        MaskPatternField2.MinLength = 4
        MaskPatternField2.Pattern = "\D"
        Me.msk_POST.Fields.AddRange(New GrapeCity.Win.Editors.Fields.MaskField() {MaskLiteralField1, MaskPatternField1, MaskLiteralField2, MaskPatternField2})
        Me.msk_POST.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.msk_POST.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.msk_POST.HighlightText = GrapeCity.Win.Editors.HighlightText.All
        Me.msk_POST.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.msk_POST.InputCheck = True
        Me.msk_POST.Location = New System.Drawing.Point(143, 149)
        Me.msk_POST.Name = "msk_POST"
        Me.GcShortcut1.SetShortcuts(Me.msk_POST, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.msk_POST, Object), CType(Me.msk_POST, Object)}, New String() {"ShortcutClear", "ApplyRecommendedValue"}))
        Me.msk_POST.Size = New System.Drawing.Size(101, 21)
        Me.msk_POST.TabIndex = 6
        '
        'txt_E_MAIL1
        '
        Me.txt_E_MAIL1.DropDown.AllowDrop = False
        Me.txt_E_MAIL1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_E_MAIL1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_E_MAIL1.Format = "Aa#@"
        Me.txt_E_MAIL1.HighlightText = True
        Me.txt_E_MAIL1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_E_MAIL1.Location = New System.Drawing.Point(610, 234)
        Me.txt_E_MAIL1.MaxLength = 100
        Me.txt_E_MAIL1.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_E_MAIL1.Name = "txt_E_MAIL1"
        Me.GcShortcut1.SetShortcuts(Me.txt_E_MAIL1, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_E_MAIL1, Object)}, New String() {"ShortcutClear"}))
        Me.txt_E_MAIL1.Size = New System.Drawing.Size(302, 21)
        Me.txt_E_MAIL1.TabIndex = 12
        Me.txt_E_MAIL1.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'txt_E_MAIL2
        '
        Me.txt_E_MAIL2.DropDown.AllowDrop = False
        Me.txt_E_MAIL2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_E_MAIL2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_E_MAIL2.Format = "Aa#@"
        Me.txt_E_MAIL2.HighlightText = True
        Me.txt_E_MAIL2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_E_MAIL2.Location = New System.Drawing.Point(610, 259)
        Me.txt_E_MAIL2.MaxLength = 100
        Me.txt_E_MAIL2.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_E_MAIL2.Name = "txt_E_MAIL2"
        Me.GcShortcut1.SetShortcuts(Me.txt_E_MAIL2, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_E_MAIL2, Object)}, New String() {"ShortcutClear"}))
        Me.txt_E_MAIL2.Size = New System.Drawing.Size(302, 21)
        Me.txt_E_MAIL2.TabIndex = 15
        Me.txt_E_MAIL2.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'txt_KYOKAI_NAME
        '
        Me.txt_KYOKAI_NAME.DropDown.AllowDrop = False
        Me.txt_KYOKAI_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KYOKAI_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_KYOKAI_NAME.HighlightText = True
        Me.txt_KYOKAI_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_KYOKAI_NAME.InputCheck = True
        Me.txt_KYOKAI_NAME.Location = New System.Drawing.Point(143, 74)
        Me.txt_KYOKAI_NAME.MaxLength = 30
        Me.txt_KYOKAI_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KYOKAI_NAME.Name = "txt_KYOKAI_NAME"
        Me.GcShortcut1.SetShortcuts(Me.txt_KYOKAI_NAME, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_KYOKAI_NAME, Object)}, New String() {"ShortcutClear"}))
        Me.txt_KYOKAI_NAME.Size = New System.Drawing.Size(278, 20)
        Me.txt_KYOKAI_NAME.TabIndex = 0
        Me.txt_KYOKAI_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'txt_HAKKO_NO_KANJI
        '
        Me.txt_HAKKO_NO_KANJI.DropDown.AllowDrop = False
        Me.txt_HAKKO_NO_KANJI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_HAKKO_NO_KANJI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_HAKKO_NO_KANJI.Format = "Ｚ"
        Me.txt_HAKKO_NO_KANJI.HighlightText = True
        Me.txt_HAKKO_NO_KANJI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_HAKKO_NO_KANJI.InputCheck = True
        Me.txt_HAKKO_NO_KANJI.Location = New System.Drawing.Point(761, 207)
        Me.txt_HAKKO_NO_KANJI.MaxLength = 4
        Me.txt_HAKKO_NO_KANJI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_HAKKO_NO_KANJI.Name = "txt_HAKKO_NO_KANJI"
        Me.GcShortcut1.SetShortcuts(Me.txt_HAKKO_NO_KANJI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_HAKKO_NO_KANJI, Object)}, New String() {"ShortcutClear"}))
        Me.txt_HAKKO_NO_KANJI.Size = New System.Drawing.Size(50, 20)
        Me.txt_HAKKO_NO_KANJI.TabIndex = 9
        Me.txt_HAKKO_NO_KANJI.Text = "＠＠"
        '
        'txt_HP_URL
        '
        Me.txt_HP_URL.DropDown.AllowDrop = False
        Me.txt_HP_URL.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_HP_URL.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_HP_URL.Format = "Aa#@"
        Me.txt_HP_URL.HighlightText = True
        Me.txt_HP_URL.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_HP_URL.InputCheck = True
        Me.txt_HP_URL.Location = New System.Drawing.Point(174, 293)
        Me.txt_HP_URL.MaxLength = 50
        Me.txt_HP_URL.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_HP_URL.Name = "txt_HP_URL"
        Me.GcShortcut1.SetShortcuts(Me.txt_HP_URL, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_HP_URL, Object)}, New String() {"ShortcutClear"}))
        Me.txt_HP_URL.Size = New System.Drawing.Size(420, 21)
        Me.txt_HP_URL.TabIndex = 17
        Me.txt_HP_URL.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'cmdSav
        '
        Me.cmdSav.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSav.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSav.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSav.Location = New System.Drawing.Point(29, 6)
        Me.cmdSav.Name = "cmdSav"
        Me.cmdSav.Size = New System.Drawing.Size(92, 44)
        Me.cmdSav.TabIndex = 0
        Me.cmdSav.Text = "保存"
        Me.cmdSav.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(245, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(92, 44)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(39, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "■協会名称"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(39, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "■役職名"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(39, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "■会長名"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(527, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "□予備"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(527, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 15)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "■支援事業名"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(39, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 15)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "■住所"
        '
        'txt_ADDR2
        '
        Me.txt_ADDR2.DropDown.AllowDrop = False
        Me.txt_ADDR2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR2.HighlightText = True
        Me.txt_ADDR2.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ADDR2.Location = New System.Drawing.Point(143, 207)
        Me.txt_ADDR2.MaxLength = 40
        Me.txt_ADDR2.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR2.Name = "txt_ADDR2"
        Me.txt_ADDR2.Size = New System.Drawing.Size(455, 20)
        Me.txt_ADDR2.TabIndex = 8
        Me.txt_ADDR2.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'txt_ADDR1
        '
        Me.txt_ADDR1.DropDown.AllowDrop = False
        Me.txt_ADDR1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR1.HighlightText = True
        Me.txt_ADDR1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ADDR1.InputCheck = True
        Me.txt_ADDR1.Location = New System.Drawing.Point(143, 177)
        Me.txt_ADDR1.MaxLength = 40
        Me.txt_ADDR1.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR1.Name = "txt_ADDR1"
        Me.txt_ADDR1.Size = New System.Drawing.Size(455, 20)
        Me.txt_ADDR1.TabIndex = 7
        Me.txt_ADDR1.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(339, 237)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 15)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "■FAX１"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(143, 237)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 15)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "■電話１"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(39, 237)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 15)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "連絡先1"
        '
        'txt_TEL1
        '
        Me.txt_TEL1.AllowSpace = GrapeCity.Win.Editors.AllowSpace.Narrow
        Me.txt_TEL1.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt_TEL1.DropDown.AllowDrop = False
        Me.txt_TEL1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_TEL1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_TEL1.Format = "9-"
        Me.txt_TEL1.HighlightText = True
        Me.txt_TEL1.InputCheck = True
        Me.txt_TEL1.Location = New System.Drawing.Point(205, 233)
        Me.txt_TEL1.MaxLength = 14
        Me.txt_TEL1.Name = "txt_TEL1"
        Me.txt_TEL1.Size = New System.Drawing.Size(122, 22)
        Me.txt_TEL1.TabIndex = 10
        Me.txt_TEL1.Text = "000000000000"
        '
        'txt_FAX1
        '
        Me.txt_FAX1.AllowSpace = GrapeCity.Win.Editors.AllowSpace.Narrow
        Me.txt_FAX1.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt_FAX1.DropDown.AllowDrop = False
        Me.txt_FAX1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_FAX1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_FAX1.Format = "9-"
        Me.txt_FAX1.HighlightText = True
        Me.txt_FAX1.InputCheck = True
        Me.txt_FAX1.Location = New System.Drawing.Point(399, 233)
        Me.txt_FAX1.MaxLength = 14
        Me.txt_FAX1.Name = "txt_FAX1"
        Me.txt_FAX1.Size = New System.Drawing.Size(122, 22)
        Me.txt_FAX1.TabIndex = 11
        Me.txt_FAX1.Text = "000000000000"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(537, 237)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 15)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "□E-Mail１"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(537, 262)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 15)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "□E-Mail２"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(339, 262)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 15)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "□FAX２"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(143, 262)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 15)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "□電話２"
        '
        'txt_TEL2
        '
        Me.txt_TEL2.AllowSpace = GrapeCity.Win.Editors.AllowSpace.Narrow
        Me.txt_TEL2.DropDown.AllowDrop = False
        Me.txt_TEL2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_TEL2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_TEL2.Format = "9-"
        Me.txt_TEL2.HighlightText = True
        Me.txt_TEL2.Location = New System.Drawing.Point(205, 258)
        Me.txt_TEL2.MaxLength = 14
        Me.txt_TEL2.Name = "txt_TEL2"
        Me.txt_TEL2.Size = New System.Drawing.Size(122, 22)
        Me.txt_TEL2.TabIndex = 13
        Me.txt_TEL2.Text = "000000000000"
        '
        'txt_FAX2
        '
        Me.txt_FAX2.AllowSpace = GrapeCity.Win.Editors.AllowSpace.Narrow
        Me.txt_FAX2.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt_FAX2.DropDown.AllowDrop = False
        Me.txt_FAX2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_FAX2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_FAX2.Format = "9-"
        Me.txt_FAX2.HighlightText = True
        Me.txt_FAX2.Location = New System.Drawing.Point(399, 258)
        Me.txt_FAX2.MaxLength = 14
        Me.txt_FAX2.Name = "txt_FAX2"
        Me.txt_FAX2.Size = New System.Drawing.Size(122, 22)
        Me.txt_FAX2.TabIndex = 14
        Me.txt_FAX2.Text = "000000000000"
        '
        'txt_KOFU_KAISYA_NAME
        '
        Me.txt_KOFU_KAISYA_NAME.DropDown.AllowDrop = False
        Me.txt_KOFU_KAISYA_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KOFU_KAISYA_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_KOFU_KAISYA_NAME.Format = "AaK9@"
        Me.txt_KOFU_KAISYA_NAME.HighlightText = True
        Me.txt_KOFU_KAISYA_NAME.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_KOFU_KAISYA_NAME.Location = New System.Drawing.Point(508, 569)
        Me.txt_KOFU_KAISYA_NAME.MaxLength = 40
        Me.txt_KOFU_KAISYA_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KOFU_KAISYA_NAME.Name = "txt_KOFU_KAISYA_NAME"
        Me.txt_KOFU_KAISYA_NAME.Size = New System.Drawing.Size(414, 20)
        Me.txt_KOFU_KAISYA_NAME.TabIndex = 39
        Me.txt_KOFU_KAISYA_NAME.Text = "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(362, 572)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(143, 15)
        Me.Label17.TabIndex = 67
        Me.Label17.Text = "振込依頼人名(ﾌﾘｶﾞﾅ)"
        '
        'txt_KOFU_KOZA_NO
        '
        Me.txt_KOFU_KOZA_NO.DropDown.AllowDrop = False
        Me.txt_KOFU_KOZA_NO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KOFU_KOZA_NO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_KOFU_KOZA_NO.Format = "9"
        Me.txt_KOFU_KOZA_NO.HighlightText = True
        Me.txt_KOFU_KOZA_NO.Location = New System.Drawing.Point(490, 539)
        Me.txt_KOFU_KOZA_NO.MaxLength = 7
        Me.txt_KOFU_KOZA_NO.Name = "txt_KOFU_KOZA_NO"
        Me.txt_KOFU_KOZA_NO.Size = New System.Drawing.Size(66, 22)
        Me.txt_KOFU_KOZA_NO.TabIndex = 35
        Me.txt_KOFU_KOZA_NO.Text = "0000000"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(423, 543)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 15)
        Me.Label19.TabIndex = 59
        Me.Label19.Text = "口座番号"
        '
        'cbo_KOFU_KOZA_SYUBETU
        '
        Me.cbo_KOFU_KOZA_SYUBETU.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cbo_KOFU_KOZA_SYUBETU.DropDown.AllowDrop = False
        Me.cbo_KOFU_KOZA_SYUBETU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_KOFU_KOZA_SYUBETU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_KOFU_KOZA_SYUBETU.Format = "9"
        Me.cbo_KOFU_KOZA_SYUBETU.HighlightText = True
        Me.cbo_KOFU_KOZA_SYUBETU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_KOFU_KOZA_SYUBETU.ListHeaderPane.Height = 22
        Me.cbo_KOFU_KOZA_SYUBETU.Location = New System.Drawing.Point(238, 539)
        Me.cbo_KOFU_KOZA_SYUBETU.MaxLength = 2
        Me.cbo_KOFU_KOZA_SYUBETU.Name = "cbo_KOFU_KOZA_SYUBETU"
        Me.cbo_KOFU_KOZA_SYUBETU.Size = New System.Drawing.Size(26, 22)
        Me.cbo_KOFU_KOZA_SYUBETU.Spin.AllowSpin = False
        Me.cbo_KOFU_KOZA_SYUBETU.TabIndex = 33
        Me.cbo_KOFU_KOZA_SYUBETU.Text = "00"
        '
        'cbo_KOFU_KOZA_SYUBETU_NM
        '
        Me.cbo_KOFU_KOZA_SYUBETU_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_KOFU_KOZA_SYUBETU_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_KOFU_KOZA_SYUBETU_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_KOFU_KOZA_SYUBETU_NM.ListHeaderPane.Height = 22
        Me.cbo_KOFU_KOZA_SYUBETU_NM.ListHeaderPane.Visible = False
        Me.cbo_KOFU_KOZA_SYUBETU_NM.Location = New System.Drawing.Point(273, 539)
        Me.cbo_KOFU_KOZA_SYUBETU_NM.MaxLength = 8
        Me.cbo_KOFU_KOZA_SYUBETU_NM.Name = "cbo_KOFU_KOZA_SYUBETU_NM"
        Me.cbo_KOFU_KOZA_SYUBETU_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.cbo_KOFU_KOZA_SYUBETU_NM.Size = New System.Drawing.Size(119, 22)
        Me.cbo_KOFU_KOZA_SYUBETU_NM.TabIndex = 34
        Me.cbo_KOFU_KOZA_SYUBETU_NM.TabStop = False
        '
        'DropDownButton6
        '
        Me.DropDownButton6.Name = "DropDownButton6"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(156, 543)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 15)
        Me.Label18.TabIndex = 56
        Me.Label18.Text = "口座種別"
        '
        'cbo_KOFU_BANK_SITEN_CD
        '
        Me.cbo_KOFU_BANK_SITEN_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cbo_KOFU_BANK_SITEN_CD.DropDown.AllowDrop = False
        Me.cbo_KOFU_BANK_SITEN_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_KOFU_BANK_SITEN_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_KOFU_BANK_SITEN_CD.Format = "9"
        Me.cbo_KOFU_BANK_SITEN_CD.HighlightText = True
        Me.cbo_KOFU_BANK_SITEN_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_KOFU_BANK_SITEN_CD.ListHeaderPane.Height = 22
        Me.cbo_KOFU_BANK_SITEN_CD.Location = New System.Drawing.Point(607, 509)
        Me.cbo_KOFU_BANK_SITEN_CD.MaxLength = 3
        Me.cbo_KOFU_BANK_SITEN_CD.Name = "cbo_KOFU_BANK_SITEN_CD"
        Me.cbo_KOFU_BANK_SITEN_CD.Size = New System.Drawing.Size(35, 22)
        Me.cbo_KOFU_BANK_SITEN_CD.Spin.AllowSpin = False
        Me.cbo_KOFU_BANK_SITEN_CD.TabIndex = 31
        Me.cbo_KOFU_BANK_SITEN_CD.Text = "000"
        '
        'cbo_KOFU_BANK_SITEN_NM
        '
        Me.cbo_KOFU_BANK_SITEN_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_KOFU_BANK_SITEN_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_KOFU_BANK_SITEN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_KOFU_BANK_SITEN_NM.ListHeaderPane.Height = 22
        Me.cbo_KOFU_BANK_SITEN_NM.ListHeaderPane.Visible = False
        Me.cbo_KOFU_BANK_SITEN_NM.Location = New System.Drawing.Point(648, 509)
        Me.cbo_KOFU_BANK_SITEN_NM.MaxLength = 30
        Me.cbo_KOFU_BANK_SITEN_NM.Name = "cbo_KOFU_BANK_SITEN_NM"
        Me.cbo_KOFU_BANK_SITEN_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.cbo_KOFU_BANK_SITEN_NM.Size = New System.Drawing.Size(234, 22)
        Me.cbo_KOFU_BANK_SITEN_NM.TabIndex = 32
        Me.cbo_KOFU_BANK_SITEN_NM.TabStop = False
        '
        'DropDownButton5
        '
        Me.DropDownButton5.Name = "DropDownButton5"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(549, 513)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 15)
        Me.Label21.TabIndex = 53
        Me.Label21.Text = "本支店"
        '
        'cbo_KOFU_BANK_CD
        '
        Me.cbo_KOFU_BANK_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cbo_KOFU_BANK_CD.DropDown.AllowDrop = False
        Me.cbo_KOFU_BANK_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_KOFU_BANK_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_KOFU_BANK_CD.Format = "9"
        Me.cbo_KOFU_BANK_CD.HighlightText = True
        Me.cbo_KOFU_BANK_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_KOFU_BANK_CD.ListHeaderPane.Height = 22
        Me.cbo_KOFU_BANK_CD.Location = New System.Drawing.Point(232, 509)
        Me.cbo_KOFU_BANK_CD.MaxLength = 4
        Me.cbo_KOFU_BANK_CD.Name = "cbo_KOFU_BANK_CD"
        Me.cbo_KOFU_BANK_CD.Size = New System.Drawing.Size(50, 22)
        Me.cbo_KOFU_BANK_CD.Spin.AllowSpin = False
        Me.cbo_KOFU_BANK_CD.TabIndex = 29
        Me.cbo_KOFU_BANK_CD.Text = "0000"
        '
        'cbo_KOFU_BANK_NM
        '
        Me.cbo_KOFU_BANK_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_KOFU_BANK_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_KOFU_BANK_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_KOFU_BANK_NM.ListHeaderPane.Height = 22
        Me.cbo_KOFU_BANK_NM.ListHeaderPane.Visible = False
        Me.cbo_KOFU_BANK_NM.Location = New System.Drawing.Point(288, 509)
        Me.cbo_KOFU_BANK_NM.MaxLength = 30
        Me.cbo_KOFU_BANK_NM.Name = "cbo_KOFU_BANK_NM"
        Me.cbo_KOFU_BANK_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cbo_KOFU_BANK_NM.Size = New System.Drawing.Size(234, 22)
        Me.cbo_KOFU_BANK_NM.TabIndex = 30
        Me.cbo_KOFU_BANK_NM.TabStop = False
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(157, 513)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 15)
        Me.Label22.TabIndex = 50
        Me.Label22.Text = "金融機関"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(35, 513)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(119, 15)
        Me.Label24.TabIndex = 49
        Me.Label24.Text = "□支払口座情報"
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
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(39, 262)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(60, 15)
        Me.Label38.TabIndex = 24
        Me.Label38.Text = "連絡先2"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(604, 543)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(74, 15)
        Me.Label25.TabIndex = 61
        Me.Label25.Text = "種別コード"
        '
        'txt_KOFU_SYUBETU
        '
        Me.txt_KOFU_SYUBETU.DropDown.AllowDrop = False
        Me.txt_KOFU_SYUBETU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KOFU_SYUBETU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_KOFU_SYUBETU.Format = "9"
        Me.txt_KOFU_SYUBETU.HighlightText = True
        Me.txt_KOFU_SYUBETU.Location = New System.Drawing.Point(680, 539)
        Me.txt_KOFU_SYUBETU.MaxLength = 2
        Me.txt_KOFU_SYUBETU.Name = "txt_KOFU_SYUBETU"
        Me.txt_KOFU_SYUBETU.Size = New System.Drawing.Size(28, 22)
        Me.txt_KOFU_SYUBETU.TabIndex = 36
        Me.txt_KOFU_SYUBETU.Text = "00"
        '
        'txt_FURI_SYUBETU
        '
        Me.txt_FURI_SYUBETU.DropDown.AllowDrop = False
        Me.txt_FURI_SYUBETU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_FURI_SYUBETU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_FURI_SYUBETU.Format = "9"
        Me.txt_FURI_SYUBETU.HighlightText = True
        Me.txt_FURI_SYUBETU.InputCheck = True
        Me.txt_FURI_SYUBETU.Location = New System.Drawing.Point(680, 401)
        Me.txt_FURI_SYUBETU.MaxLength = 2
        Me.txt_FURI_SYUBETU.Name = "txt_FURI_SYUBETU"
        Me.txt_FURI_SYUBETU.Size = New System.Drawing.Size(28, 22)
        Me.txt_FURI_SYUBETU.TabIndex = 26
        Me.txt_FURI_SYUBETU.Text = "00"
        '
        'txt_KOFU_CD_KBN
        '
        Me.txt_KOFU_CD_KBN.DropDown.AllowDrop = False
        Me.txt_KOFU_CD_KBN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KOFU_CD_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_KOFU_CD_KBN.Format = "9"
        Me.txt_KOFU_CD_KBN.HighlightText = True
        Me.txt_KOFU_CD_KBN.Location = New System.Drawing.Point(821, 539)
        Me.txt_KOFU_CD_KBN.MaxLength = 1
        Me.txt_KOFU_CD_KBN.Name = "txt_KOFU_CD_KBN"
        Me.txt_KOFU_CD_KBN.Size = New System.Drawing.Size(28, 22)
        Me.txt_KOFU_CD_KBN.TabIndex = 37
        Me.txt_KOFU_CD_KBN.Text = "0"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(747, 543)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(74, 15)
        Me.Label31.TabIndex = 63
        Me.Label31.Text = "コード区分"
        '
        'txt_KOFU_KAISYA_CD
        '
        Me.txt_KOFU_KAISYA_CD.DropDown.AllowDrop = False
        Me.txt_KOFU_KAISYA_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KOFU_KAISYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_KOFU_KAISYA_CD.Format = "9"
        Me.txt_KOFU_KAISYA_CD.HighlightText = True
        Me.txt_KOFU_KAISYA_CD.Location = New System.Drawing.Point(254, 569)
        Me.txt_KOFU_KAISYA_CD.MaxLength = 10
        Me.txt_KOFU_KAISYA_CD.Name = "txt_KOFU_KAISYA_CD"
        Me.txt_KOFU_KAISYA_CD.Size = New System.Drawing.Size(89, 22)
        Me.txt_KOFU_KAISYA_CD.TabIndex = 38
        Me.txt_KOFU_KAISYA_CD.Text = "0000000000"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(156, 573)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(89, 15)
        Me.Label32.TabIndex = 65
        Me.Label32.Text = "依頼人コード"
        '
        'btnFIRST
        '
        Me.btnFIRST.AutoSize = True
        Me.btnFIRST.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFIRST.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.btnFIRST.Location = New System.Drawing.Point(146, 49)
        Me.btnFIRST.Name = "btnFIRST"
        Me.btnFIRST.Size = New System.Drawing.Size(117, 20)
        Me.btnFIRST.TabIndex = 0
        Me.btnFIRST.TabStop = True
        Me.btnFIRST.Text = "RadioButton1"
        Me.btnFIRST.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(624, 210)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(120, 15)
        Me.Label33.TabIndex = 869
        Me.Label33.Text = "■発行番号・漢字"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(35, 296)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(133, 15)
        Me.Label37.TabIndex = 875
        Me.Label37.Text = "■ホームページURL"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(157, 435)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(118, 15)
        Me.Label20.TabIndex = 45
        Me.Label20.Text = "口座名義人(カナ)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(157, 465)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(122, 15)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "口座名義人(漢字)"
        '
        'txt_FURI_KOZA_MEIGI
        '
        Me.txt_FURI_KOZA_MEIGI.DropDown.AllowDrop = False
        Me.txt_FURI_KOZA_MEIGI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_FURI_KOZA_MEIGI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_FURI_KOZA_MEIGI.Format = "Ｚ"
        Me.txt_FURI_KOZA_MEIGI.HighlightText = True
        Me.txt_FURI_KOZA_MEIGI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_FURI_KOZA_MEIGI.InputCheck = True
        Me.txt_FURI_KOZA_MEIGI.Location = New System.Drawing.Point(297, 462)
        Me.txt_FURI_KOZA_MEIGI.MaxLength = 80
        Me.txt_FURI_KOZA_MEIGI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_FURI_KOZA_MEIGI.Name = "txt_FURI_KOZA_MEIGI"
        Me.txt_FURI_KOZA_MEIGI.Size = New System.Drawing.Size(625, 20)
        Me.txt_FURI_KOZA_MEIGI.TabIndex = 28
        Me.txt_FURI_KOZA_MEIGI.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'txt_FURI_KOZA_MEIGI_KANA
        '
        Me.txt_FURI_KOZA_MEIGI_KANA.DropDown.AllowDrop = False
        Me.txt_FURI_KOZA_MEIGI_KANA.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_FURI_KOZA_MEIGI_KANA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_FURI_KOZA_MEIGI_KANA.Format = "AaK9@"
        Me.txt_FURI_KOZA_MEIGI_KANA.HighlightText = True
        Me.txt_FURI_KOZA_MEIGI_KANA.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_FURI_KOZA_MEIGI_KANA.InputCheck = True
        Me.txt_FURI_KOZA_MEIGI_KANA.Location = New System.Drawing.Point(297, 432)
        Me.txt_FURI_KOZA_MEIGI_KANA.MaxLength = 80
        Me.txt_FURI_KOZA_MEIGI_KANA.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_FURI_KOZA_MEIGI_KANA.Name = "txt_FURI_KOZA_MEIGI_KANA"
        Me.txt_FURI_KOZA_MEIGI_KANA.Size = New System.Drawing.Size(625, 20)
        Me.txt_FURI_KOZA_MEIGI_KANA.TabIndex = 27
        Me.txt_FURI_KOZA_MEIGI_KANA.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(35, 375)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(119, 15)
        Me.Label23.TabIndex = 31
        Me.Label23.Text = "■振込口座情報"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(157, 375)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(67, 15)
        Me.Label30.TabIndex = 32
        Me.Label30.Text = "金融機関"
        '
        'DropDownButton11
        '
        Me.DropDownButton11.Name = "DropDownButton11"
        '
        'cbo_FURI_BANK_NM
        '
        Me.cbo_FURI_BANK_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_FURI_BANK_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_FURI_BANK_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_FURI_BANK_NM.ListHeaderPane.Height = 22
        Me.cbo_FURI_BANK_NM.ListHeaderPane.Visible = False
        Me.cbo_FURI_BANK_NM.Location = New System.Drawing.Point(289, 371)
        Me.cbo_FURI_BANK_NM.MaxLength = 30
        Me.cbo_FURI_BANK_NM.Name = "cbo_FURI_BANK_NM"
        Me.cbo_FURI_BANK_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton11})
        Me.cbo_FURI_BANK_NM.Size = New System.Drawing.Size(233, 22)
        Me.cbo_FURI_BANK_NM.TabIndex = 20
        Me.cbo_FURI_BANK_NM.TabStop = False
        '
        'cbo_FURI_BANK_CD
        '
        Me.cbo_FURI_BANK_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cbo_FURI_BANK_CD.DropDown.AllowDrop = False
        Me.cbo_FURI_BANK_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_FURI_BANK_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_FURI_BANK_CD.Format = "9"
        Me.cbo_FURI_BANK_CD.HighlightText = True
        Me.cbo_FURI_BANK_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_FURI_BANK_CD.InputCheck = True
        Me.cbo_FURI_BANK_CD.ListHeaderPane.Height = 22
        Me.cbo_FURI_BANK_CD.Location = New System.Drawing.Point(234, 371)
        Me.cbo_FURI_BANK_CD.MaxLength = 4
        Me.cbo_FURI_BANK_CD.Name = "cbo_FURI_BANK_CD"
        Me.cbo_FURI_BANK_CD.Size = New System.Drawing.Size(50, 22)
        Me.cbo_FURI_BANK_CD.Spin.AllowSpin = False
        Me.cbo_FURI_BANK_CD.TabIndex = 19
        Me.cbo_FURI_BANK_CD.Text = "0000"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(550, 375)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(52, 15)
        Me.Label29.TabIndex = 35
        Me.Label29.Text = "本支店"
        '
        'DropDownButton10
        '
        Me.DropDownButton10.Name = "DropDownButton10"
        '
        'cbo_FURI_BANK_SITEN_NM
        '
        Me.cbo_FURI_BANK_SITEN_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_FURI_BANK_SITEN_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_FURI_BANK_SITEN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_FURI_BANK_SITEN_NM.ListHeaderPane.Height = 22
        Me.cbo_FURI_BANK_SITEN_NM.ListHeaderPane.Visible = False
        Me.cbo_FURI_BANK_SITEN_NM.Location = New System.Drawing.Point(649, 371)
        Me.cbo_FURI_BANK_SITEN_NM.MaxLength = 30
        Me.cbo_FURI_BANK_SITEN_NM.Name = "cbo_FURI_BANK_SITEN_NM"
        Me.cbo_FURI_BANK_SITEN_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton10})
        Me.cbo_FURI_BANK_SITEN_NM.Size = New System.Drawing.Size(233, 22)
        Me.cbo_FURI_BANK_SITEN_NM.TabIndex = 22
        Me.cbo_FURI_BANK_SITEN_NM.TabStop = False
        '
        'cbo_FURI_BANK_SITEN_CD
        '
        Me.cbo_FURI_BANK_SITEN_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cbo_FURI_BANK_SITEN_CD.DropDown.AllowDrop = False
        Me.cbo_FURI_BANK_SITEN_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_FURI_BANK_SITEN_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_FURI_BANK_SITEN_CD.Format = "9"
        Me.cbo_FURI_BANK_SITEN_CD.HighlightText = True
        Me.cbo_FURI_BANK_SITEN_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_FURI_BANK_SITEN_CD.InputCheck = True
        Me.cbo_FURI_BANK_SITEN_CD.ListHeaderPane.Height = 22
        Me.cbo_FURI_BANK_SITEN_CD.Location = New System.Drawing.Point(609, 371)
        Me.cbo_FURI_BANK_SITEN_CD.MaxLength = 3
        Me.cbo_FURI_BANK_SITEN_CD.Name = "cbo_FURI_BANK_SITEN_CD"
        Me.cbo_FURI_BANK_SITEN_CD.Size = New System.Drawing.Size(35, 22)
        Me.cbo_FURI_BANK_SITEN_CD.Spin.AllowSpin = False
        Me.cbo_FURI_BANK_SITEN_CD.TabIndex = 21
        Me.cbo_FURI_BANK_SITEN_CD.Text = "000"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(157, 405)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(67, 15)
        Me.Label28.TabIndex = 38
        Me.Label28.Text = "口座種別"
        '
        'DropDownButton9
        '
        Me.DropDownButton9.Name = "DropDownButton9"
        '
        'cbo_FURI_KOZA_SYUBETU_NM
        '
        Me.cbo_FURI_KOZA_SYUBETU_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_FURI_KOZA_SYUBETU_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_FURI_KOZA_SYUBETU_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_FURI_KOZA_SYUBETU_NM.ListHeaderPane.Height = 22
        Me.cbo_FURI_KOZA_SYUBETU_NM.ListHeaderPane.Visible = False
        Me.cbo_FURI_KOZA_SYUBETU_NM.Location = New System.Drawing.Point(274, 401)
        Me.cbo_FURI_KOZA_SYUBETU_NM.MaxLength = 8
        Me.cbo_FURI_KOZA_SYUBETU_NM.Name = "cbo_FURI_KOZA_SYUBETU_NM"
        Me.cbo_FURI_KOZA_SYUBETU_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton9})
        Me.cbo_FURI_KOZA_SYUBETU_NM.Size = New System.Drawing.Size(119, 22)
        Me.cbo_FURI_KOZA_SYUBETU_NM.TabIndex = 24
        Me.cbo_FURI_KOZA_SYUBETU_NM.TabStop = False
        '
        'cbo_FURI_KOZA_SYUBETU
        '
        Me.cbo_FURI_KOZA_SYUBETU.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cbo_FURI_KOZA_SYUBETU.DropDown.AllowDrop = False
        Me.cbo_FURI_KOZA_SYUBETU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_FURI_KOZA_SYUBETU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_FURI_KOZA_SYUBETU.Format = "9"
        Me.cbo_FURI_KOZA_SYUBETU.HighlightText = True
        Me.cbo_FURI_KOZA_SYUBETU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_FURI_KOZA_SYUBETU.InputCheck = True
        Me.cbo_FURI_KOZA_SYUBETU.ListHeaderPane.Height = 22
        Me.cbo_FURI_KOZA_SYUBETU.Location = New System.Drawing.Point(239, 401)
        Me.cbo_FURI_KOZA_SYUBETU.MaxLength = 2
        Me.cbo_FURI_KOZA_SYUBETU.Name = "cbo_FURI_KOZA_SYUBETU"
        Me.cbo_FURI_KOZA_SYUBETU.Size = New System.Drawing.Size(26, 22)
        Me.cbo_FURI_KOZA_SYUBETU.Spin.AllowSpin = False
        Me.cbo_FURI_KOZA_SYUBETU.TabIndex = 23
        Me.cbo_FURI_KOZA_SYUBETU.Text = "00"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(424, 405)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(67, 15)
        Me.Label27.TabIndex = 41
        Me.Label27.Text = "口座番号"
        '
        'txt_FURI_KOZA_NO
        '
        Me.txt_FURI_KOZA_NO.DropDown.AllowDrop = False
        Me.txt_FURI_KOZA_NO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_FURI_KOZA_NO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_FURI_KOZA_NO.Format = "9"
        Me.txt_FURI_KOZA_NO.HighlightText = True
        Me.txt_FURI_KOZA_NO.InputCheck = True
        Me.txt_FURI_KOZA_NO.Location = New System.Drawing.Point(492, 401)
        Me.txt_FURI_KOZA_NO.MaxLength = 7
        Me.txt_FURI_KOZA_NO.Name = "txt_FURI_KOZA_NO"
        Me.txt_FURI_KOZA_NO.Size = New System.Drawing.Size(66, 22)
        Me.txt_FURI_KOZA_NO.TabIndex = 25
        Me.txt_FURI_KOZA_NO.Text = "0000000"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(605, 405)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(74, 15)
        Me.Label26.TabIndex = 43
        Me.Label26.Text = "種別コード"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(37, 533)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 15)
        Me.Label6.TabIndex = 876
        Me.Label6.Text = "(全銀手順で使用)"
        '
        'txt_TOUROKU_NO
        '
        Me.txt_TOUROKU_NO.AllowSpace = GrapeCity.Win.Editors.AllowSpace.Narrow
        Me.txt_TOUROKU_NO.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt_TOUROKU_NO.DropDown.AllowDrop = False
        Me.txt_TOUROKU_NO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_TOUROKU_NO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_TOUROKU_NO.Format = "A9"
        Me.txt_TOUROKU_NO.HighlightText = True
        Me.txt_TOUROKU_NO.InputCheck = True
        Me.txt_TOUROKU_NO.Location = New System.Drawing.Point(712, 293)
        Me.txt_TOUROKU_NO.MaxLength = 14
        Me.txt_TOUROKU_NO.Name = "txt_TOUROKU_NO"
        Me.txt_TOUROKU_NO.Size = New System.Drawing.Size(170, 21)
        Me.txt_TOUROKU_NO.TabIndex = 18
        Me.txt_TOUROKU_NO.Text = "T0000000000000"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(624, 296)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(82, 15)
        Me.Label34.TabIndex = 878
        Me.Label34.Text = "■登録番号"
        '
        'frmGJ8030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.txt_TOUROKU_NO)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_KOFU_KAISYA_NAME)
        Me.Controls.Add(Me.txt_HP_URL)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.txt_HAKKO_NO_KANJI)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.btnFIRST)
        Me.Controls.Add(Me.txt_KYOKAI_NAME)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txt_KOFU_KAISYA_CD)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.txt_KOFU_CD_KBN)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txt_KOFU_SYUBETU)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txt_FURI_SYUBETU)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txt_FURI_KOZA_NO)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txt_KOFU_KOZA_NO)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cbo_KOFU_KOZA_SYUBETU)
        Me.Controls.Add(Me.cbo_KOFU_KOZA_SYUBETU_NM)
        Me.Controls.Add(Me.cbo_FURI_KOZA_SYUBETU)
        Me.Controls.Add(Me.cbo_FURI_KOZA_SYUBETU_NM)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.cbo_FURI_BANK_SITEN_CD)
        Me.Controls.Add(Me.cbo_FURI_BANK_SITEN_NM)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.cbo_FURI_BANK_CD)
        Me.Controls.Add(Me.cbo_FURI_BANK_NM)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txt_FURI_KOZA_MEIGI_KANA)
        Me.Controls.Add(Me.txt_E_MAIL2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cbo_KOFU_BANK_SITEN_CD)
        Me.Controls.Add(Me.cbo_KOFU_BANK_SITEN_NM)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cbo_KOFU_BANK_CD)
        Me.Controls.Add(Me.cbo_KOFU_BANK_NM)
        Me.Controls.Add(Me.txt_TEL2)
        Me.Controls.Add(Me.txt_FAX2)
        Me.Controls.Add(Me.txt_E_MAIL1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_FURI_KOZA_MEIGI)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txt_TEL1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txt_FAX1)
        Me.Controls.Add(Me.txt_ADDR2)
        Me.Controls.Add(Me.txt_ADDR1)
        Me.Controls.Add(Me.msk_POST)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_YOBI1)
        Me.Controls.Add(Me.txt_KAICHO_NAME)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_YAKUMEI)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_JIGYO_NAME)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Name = "frmGJ8030"
        Me.Text = "(GJ8030)日本養鶏協会マスタメンテナンス"
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txt_JIGYO_NAME, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txt_YAKUMEI, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txt_KAICHO_NAME, 0)
        Me.Controls.SetChildIndex(Me.txt_YOBI1, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.msk_POST, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR1, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR2, 0)
        Me.Controls.SetChildIndex(Me.txt_FAX1, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.txt_TEL1, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.txt_FURI_KOZA_MEIGI, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.txt_E_MAIL1, 0)
        Me.Controls.SetChildIndex(Me.txt_FAX2, 0)
        Me.Controls.SetChildIndex(Me.txt_TEL2, 0)
        Me.Controls.SetChildIndex(Me.cbo_KOFU_BANK_NM, 0)
        Me.Controls.SetChildIndex(Me.cbo_KOFU_BANK_CD, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.cbo_KOFU_BANK_SITEN_NM, 0)
        Me.Controls.SetChildIndex(Me.cbo_KOFU_BANK_SITEN_CD, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.txt_E_MAIL2, 0)
        Me.Controls.SetChildIndex(Me.txt_FURI_KOZA_MEIGI_KANA, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.cbo_FURI_BANK_NM, 0)
        Me.Controls.SetChildIndex(Me.cbo_FURI_BANK_CD, 0)
        Me.Controls.SetChildIndex(Me.Label29, 0)
        Me.Controls.SetChildIndex(Me.cbo_FURI_BANK_SITEN_NM, 0)
        Me.Controls.SetChildIndex(Me.cbo_FURI_BANK_SITEN_CD, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.cbo_FURI_KOZA_SYUBETU_NM, 0)
        Me.Controls.SetChildIndex(Me.cbo_FURI_KOZA_SYUBETU, 0)
        Me.Controls.SetChildIndex(Me.cbo_KOFU_KOZA_SYUBETU_NM, 0)
        Me.Controls.SetChildIndex(Me.cbo_KOFU_KOZA_SYUBETU, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.txt_KOFU_KOZA_NO, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.txt_FURI_KOZA_NO, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.txt_FURI_SYUBETU, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.txt_KOFU_SYUBETU, 0)
        Me.Controls.SetChildIndex(Me.Label31, 0)
        Me.Controls.SetChildIndex(Me.txt_KOFU_CD_KBN, 0)
        Me.Controls.SetChildIndex(Me.Label32, 0)
        Me.Controls.SetChildIndex(Me.txt_KOFU_KAISYA_CD, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.txt_KYOKAI_NAME, 0)
        Me.Controls.SetChildIndex(Me.btnFIRST, 0)
        Me.Controls.SetChildIndex(Me.Label38, 0)
        Me.Controls.SetChildIndex(Me.Label33, 0)
        Me.Controls.SetChildIndex(Me.txt_HAKKO_NO_KANJI, 0)
        Me.Controls.SetChildIndex(Me.Label37, 0)
        Me.Controls.SetChildIndex(Me.txt_HP_URL, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.txt_KOFU_KAISYA_NAME, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txt_TOUROKU_NO, 0)
        Me.Controls.SetChildIndex(Me.Label34, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.txt_YAKUMEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KAICHO_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_YOBI1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_JIGYO_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.msk_POST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_E_MAIL1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_E_MAIL2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KYOKAI_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_HAKKO_NO_KANJI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_HP_URL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TEL1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FAX1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TEL2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FAX2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KOFU_KAISYA_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KOFU_KOZA_NO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KOFU_KOZA_SYUBETU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KOFU_KOZA_SYUBETU_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KOFU_BANK_SITEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KOFU_BANK_SITEN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KOFU_BANK_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KOFU_BANK_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KOFU_TUMI_SITEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KOFU_SYUBETU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FURI_SYUBETU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KOFU_CD_KBN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KOFU_KAISYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FURI_KOZA_MEIGI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FURI_KOZA_MEIGI_KANA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_FURI_BANK_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_FURI_BANK_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_FURI_BANK_SITEN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_FURI_BANK_SITEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_FURI_KOZA_SYUBETU_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_FURI_KOZA_SYUBETU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FURI_KOZA_NO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TOUROKU_NO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents cmdSav As JBD.Gjs.Win.JButton
    Friend WithEvents cmdCancel As JBD.Gjs.Win.JButton
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents txt_YAKUMEI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KAICHO_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents txt_YOBI1 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents txt_JIGYO_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents txt_ADDR2 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_ADDR1 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents msk_POST As JBD.Gjs.Win.GcMask
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents txt_TEL1 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_FAX1 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents txt_E_MAIL1 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_E_MAIL2 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents txt_TEL2 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_FAX2 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_KOFU_KAISYA_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KOFU_KOZA_NO As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents cbo_KOFU_KOZA_SYUBETU As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cbo_KOFU_KOZA_SYUBETU_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton6 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents cbo_KOFU_BANK_SITEN_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cbo_KOFU_BANK_SITEN_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton5 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label21 As JBD.Gjs.Win.Label
    Friend WithEvents cbo_KOFU_BANK_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cbo_KOFU_BANK_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label22 As JBD.Gjs.Win.Label
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents cbo_KOFU_TUMI_SITEN_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents txt_KYOKAI_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label38 As JBD.Gjs.Win.Label
    Friend WithEvents Label25 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KOFU_SYUBETU As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_FURI_SYUBETU As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_KOFU_CD_KBN As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label31 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KOFU_KAISYA_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label32 As JBD.Gjs.Win.Label
    Friend WithEvents btnFIRST As JBD.Gjs.Win.RadioButton
    Friend WithEvents txt_HAKKO_NO_KANJI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label33 As JBD.Gjs.Win.Label
    Friend WithEvents Label37 As JBD.Gjs.Win.Label
    Friend WithEvents txt_HP_URL As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label20 As JBD.Gjs.Win.Label
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents txt_FURI_KOZA_MEIGI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_FURI_KOZA_MEIGI_KANA As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label23 As JBD.Gjs.Win.Label
    Friend WithEvents Label30 As JBD.Gjs.Win.Label
    Friend WithEvents DropDownButton11 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cbo_FURI_BANK_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cbo_FURI_BANK_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents Label29 As JBD.Gjs.Win.Label
    Friend WithEvents DropDownButton10 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cbo_FURI_BANK_SITEN_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cbo_FURI_BANK_SITEN_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents Label28 As JBD.Gjs.Win.Label
    Friend WithEvents DropDownButton9 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cbo_FURI_KOZA_SYUBETU_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cbo_FURI_KOZA_SYUBETU As JBD.Gjs.Win.GcComboBox
    Friend WithEvents Label27 As JBD.Gjs.Win.Label
    Friend WithEvents txt_FURI_KOZA_NO As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label26 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents txt_TOUROKU_NO As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label34 As JBD.Gjs.Win.Label
End Class
