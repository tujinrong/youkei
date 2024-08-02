Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ1011
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
        Dim DateEraDisplayField1 As GrapeCity.Win.Editors.Fields.DateEraDisplayField = New GrapeCity.Win.Editors.Fields.DateEraDisplayField()
        Dim DateLiteralDisplayField1 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateEraYearDisplayField1 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateLiteralDisplayField2 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateMonthDisplayField1 As GrapeCity.Win.Editors.Fields.DateMonthDisplayField = New GrapeCity.Win.Editors.Fields.DateMonthDisplayField()
        Dim DateLiteralDisplayField3 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateDayDisplayField1 As GrapeCity.Win.Editors.Fields.DateDayDisplayField = New GrapeCity.Win.Editors.Fields.DateDayDisplayField()
        Dim DateEraField1 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField1 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateLiteralField2 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField1 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField3 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField1 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim MaskLiteralField1 As GrapeCity.Win.Editors.Fields.MaskLiteralField = New GrapeCity.Win.Editors.Fields.MaskLiteralField()
        Dim MaskPatternField1 As GrapeCity.Win.Editors.Fields.MaskPatternField = New GrapeCity.Win.Editors.Fields.MaskPatternField()
        Dim MaskLiteralField2 As GrapeCity.Win.Editors.Fields.MaskLiteralField = New GrapeCity.Win.Editors.Fields.MaskLiteralField()
        Dim MaskPatternField2 As GrapeCity.Win.Editors.Fields.MaskPatternField = New GrapeCity.Win.Editors.Fields.MaskPatternField()
        Dim DateEraYearField2 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraDisplayField2 As GrapeCity.Win.Editors.Fields.DateEraDisplayField = New GrapeCity.Win.Editors.Fields.DateEraDisplayField()
        Dim DateLiteralDisplayField4 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateEraYearDisplayField2 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateLiteralDisplayField5 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateMonthDisplayField2 As GrapeCity.Win.Editors.Fields.DateMonthDisplayField = New GrapeCity.Win.Editors.Fields.DateMonthDisplayField()
        Dim DateLiteralDisplayField6 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateDayDisplayField2 As GrapeCity.Win.Editors.Fields.DateDayDisplayField = New GrapeCity.Win.Editors.Fields.DateDayDisplayField()
        Dim DateEraField2 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField4 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateLiteralField5 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField2 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField6 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField2 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateEraYearField3 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraDisplayField3 As GrapeCity.Win.Editors.Fields.DateEraDisplayField = New GrapeCity.Win.Editors.Fields.DateEraDisplayField()
        Dim DateLiteralDisplayField7 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateEraYearDisplayField3 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateLiteralDisplayField8 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateMonthDisplayField3 As GrapeCity.Win.Editors.Fields.DateMonthDisplayField = New GrapeCity.Win.Editors.Fields.DateMonthDisplayField()
        Dim DateLiteralDisplayField9 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateDayDisplayField3 As GrapeCity.Win.Editors.Fields.DateDayDisplayField = New GrapeCity.Win.Editors.Fields.DateDayDisplayField()
        Dim DateEraField3 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField7 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateLiteralField8 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField3 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField9 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField3 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_KEIYAKUSYA_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KEN_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEN_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label20 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KEIYAKU_KBN = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEIYAKU_KBN_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label21 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label22 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label23 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_FURI_BANK_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_FURI_BANK_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton8 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cob_FURI_BANK_SITEN_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_FURI_BANK_SITEN_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton9 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cob_FURI_KOZA_SYUBETU = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_FURI_KOZA_SYUBETU_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton10 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label25 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_FURI_KOZA_NO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_FURI_KOZA_MEIGI_KANA = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_FURI_KOZA_MEIGI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.lblTotal = New JBD.Gjs.Win.Label(Me.components)
        Me.Label26 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_Now = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.cmdLast = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdNext = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdBef = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdTop = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.date_NYUHEN_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton13 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label30 = New JBD.Gjs.Win.Label(Me.components)
        Me.DropDownButton14 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton15 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton16 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton17 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton18 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton19 = New GrapeCity.Win.Editors.DropDownButton()
        Me.txt_BIKO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.GroupBox4 = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_BANK_NASI = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_BANK_ARI = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_JIMUITAKU_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_JIMUITAKU_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton21 = New GrapeCity.Win.Editors.DropDownButton()
        Me.txt_ADDR_E_MAIL = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label63 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_ADDR_TEL2 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label64 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label65 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_ADDR_FAX = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_ADDR_TEL1 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label66 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label67 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label68 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_DAIHYO_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label69 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_KEIYAKUSYA_KANA = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_KEIYAKUSYA_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label70 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_KI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.txt_ADDR_4 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_ADDR_3 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_ADDR_2 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_ADDR_1 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.msk_ADDR_POST = New JBD.Gjs.Win.GcMask(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.GroupBox1 = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_NYURYOKU_JYOKYO2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_NYURYOKU_JYOKYO1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.lbl_HasuSeigen = New JBD.Gjs.Win.Label(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cob_KEIYAKU_JYOKYO_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEIYAKU_JYOKYO = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.txt_SEISANSYA_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_NIKKEIKYO_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label32 = New JBD.Gjs.Win.Label(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.date_HAIGYO_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.date_KEIYAKU_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton6 = New GrapeCity.Win.Editors.DropDownButton()
        Me.pnlButton.SuspendLayout()
        CType(Me.txt_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKU_KBN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKU_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_FURI_BANK_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_FURI_BANK_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_FURI_BANK_SITEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_FURI_BANK_SITEN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_FURI_KOZA_SYUBETU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_FURI_KOZA_SYUBETU_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FURI_KOZA_NO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FURI_KOZA_MEIGI_KANA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FURI_KOZA_MEIGI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Now, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_NYUHEN_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_BIKO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.cob_JIMUITAKU_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_JIMUITAKU_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_E_MAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_TEL2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_FAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_TEL1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_DAIHYO_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KEIYAKUSYA_KANA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.msk_ADDR_POST, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cob_KEIYAKU_JYOKYO_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKU_JYOKYO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SEISANSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_NIKKEIKYO_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.date_HAIGYO_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_KEIYAKU_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.lblTotal)
        Me.pnlButton.Controls.Add(Me.Label26)
        Me.pnlButton.Controls.Add(Me.txt_Now)
        Me.pnlButton.Controls.Add(Me.cmdLast)
        Me.pnlButton.Controls.Add(Me.cmdNext)
        Me.pnlButton.Controls.Add(Me.cmdBef)
        Me.pnlButton.Controls.Add(Me.cmdTop)
        Me.pnlButton.Controls.Add(Me.cmdSave)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSave, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdTop, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdBef, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdNext, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdLast, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.txt_Now, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.Label26, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.lblTotal, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        '
        'lblLOGONUSER
        '
        Me.lblLOGONUSER.Text = "さん"
        '
        'lblSysdate
        '
        Me.lblSysdate.Text = "2010年9月6日（月）"
        '
        'cmdEnd
        '
        Me.cmdEnd.Location = New System.Drawing.Point(989, 6)
        Me.cmdEnd.TabIndex = 152
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(44, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "■契約者番号"
        '
        'txt_KEIYAKUSYA_CD
        '
        Me.txt_KEIYAKUSYA_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_KEIYAKUSYA_CD.DropDown.AllowDrop = False
        Me.txt_KEIYAKUSYA_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KEIYAKUSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_KEIYAKUSYA_CD.Format = "9"
        Me.txt_KEIYAKUSYA_CD.HighlightText = True
        Me.txt_KEIYAKUSYA_CD.InputCheck = True
        Me.txt_KEIYAKUSYA_CD.Location = New System.Drawing.Point(157, 101)
        Me.txt_KEIYAKUSYA_CD.MaxLength = 5
        Me.txt_KEIYAKUSYA_CD.Name = "txt_KEIYAKUSYA_CD"
        Me.txt_KEIYAKUSYA_CD.Size = New System.Drawing.Size(50, 22)
        Me.txt_KEIYAKUSYA_CD.TabIndex = 0
        Me.txt_KEIYAKUSYA_CD.Text = "00000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(44, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "■都道府県"
        '
        'cob_KEN_CD
        '
        Me.cob_KEN_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_KEN_CD.DropDown.AllowDrop = False
        Me.cob_KEN_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEN_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEN_CD.Format = "9"
        Me.cob_KEN_CD.HighlightText = True
        Me.cob_KEN_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_KEN_CD.InputCheck = True
        Me.cob_KEN_CD.ListHeaderPane.Height = 22
        Me.cob_KEN_CD.Location = New System.Drawing.Point(157, 126)
        Me.cob_KEN_CD.MaxLength = 2
        Me.cob_KEN_CD.Name = "cob_KEN_CD"
        Me.cob_KEN_CD.Size = New System.Drawing.Size(36, 22)
        Me.cob_KEN_CD.Spin.AllowSpin = False
        Me.cob_KEN_CD.TabIndex = 1
        Me.cob_KEN_CD.Text = "00"
        '
        'cob_KEN_NM
        '
        Me.cob_KEN_NM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_KEN_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_KEN_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEN_NM.InputCheck = True
        Me.cob_KEN_NM.ListHeaderPane.Height = 22
        Me.cob_KEN_NM.ListHeaderPane.Visible = False
        Me.cob_KEN_NM.Location = New System.Drawing.Point(198, 126)
        Me.cob_KEN_NM.Name = "cob_KEN_NM"
        Me.cob_KEN_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cob_KEN_NM.Size = New System.Drawing.Size(119, 22)
        Me.cob_KEN_NM.TabIndex = 2
        Me.cob_KEN_NM.TabStop = False
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(44, 680)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 15)
        Me.Label20.TabIndex = 24
        Me.Label20.Text = "□廃業日"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(44, 155)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 15)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "■契約区分"
        '
        'cob_KEIYAKU_KBN
        '
        Me.cob_KEIYAKU_KBN.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_KEIYAKU_KBN.DropDown.AllowDrop = False
        Me.cob_KEIYAKU_KBN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKU_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKU_KBN.Format = "9"
        Me.cob_KEIYAKU_KBN.HighlightText = True
        Me.cob_KEIYAKU_KBN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_KEIYAKU_KBN.InputCheck = True
        Me.cob_KEIYAKU_KBN.ListHeaderPane.Height = 22
        Me.cob_KEIYAKU_KBN.Location = New System.Drawing.Point(157, 152)
        Me.cob_KEIYAKU_KBN.MaxLength = 1
        Me.cob_KEIYAKU_KBN.Name = "cob_KEIYAKU_KBN"
        Me.cob_KEIYAKU_KBN.Size = New System.Drawing.Size(26, 22)
        Me.cob_KEIYAKU_KBN.Spin.AllowSpin = False
        Me.cob_KEIYAKU_KBN.TabIndex = 3
        Me.cob_KEIYAKU_KBN.Text = "0"
        '
        'cob_KEIYAKU_KBN_NM
        '
        Me.cob_KEIYAKU_KBN_NM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_KEIYAKU_KBN_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_KEIYAKU_KBN_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKU_KBN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKU_KBN_NM.InputCheck = True
        Me.cob_KEIYAKU_KBN_NM.ListHeaderPane.Height = 22
        Me.cob_KEIYAKU_KBN_NM.ListHeaderPane.Visible = False
        Me.cob_KEIYAKU_KBN_NM.Location = New System.Drawing.Point(186, 152)
        Me.cob_KEIYAKU_KBN_NM.Name = "cob_KEIYAKU_KBN_NM"
        Me.cob_KEIYAKU_KBN_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton4})
        Me.cob_KEIYAKU_KBN_NM.Size = New System.Drawing.Size(119, 22)
        Me.cob_KEIYAKU_KBN_NM.TabIndex = 4
        Me.cob_KEIYAKU_KBN_NM.TabStop = False
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(44, 520)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(82, 15)
        Me.Label19.TabIndex = 112
        Me.Label19.Text = "■金融機関"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(44, 545)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 15)
        Me.Label21.TabIndex = 115
        Me.Label21.Text = "■本支店"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(44, 570)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(82, 15)
        Me.Label22.TabIndex = 118
        Me.Label22.Text = "■口座種別"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(44, 598)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(97, 15)
        Me.Label23.TabIndex = 123
        Me.Label23.Text = "■口座名義人"
        '
        'cob_FURI_BANK_CD
        '
        Me.cob_FURI_BANK_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_FURI_BANK_CD.DropDown.AllowDrop = False
        Me.cob_FURI_BANK_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_FURI_BANK_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_FURI_BANK_CD.Format = "9"
        Me.cob_FURI_BANK_CD.HighlightText = True
        Me.cob_FURI_BANK_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_FURI_BANK_CD.InputCheck = True
        Me.cob_FURI_BANK_CD.ListHeaderPane.Height = 22
        Me.cob_FURI_BANK_CD.Location = New System.Drawing.Point(225, 517)
        Me.cob_FURI_BANK_CD.MaxLength = 4
        Me.cob_FURI_BANK_CD.Name = "cob_FURI_BANK_CD"
        Me.cob_FURI_BANK_CD.Size = New System.Drawing.Size(45, 22)
        Me.cob_FURI_BANK_CD.Spin.AllowSpin = False
        Me.cob_FURI_BANK_CD.TabIndex = 42
        Me.cob_FURI_BANK_CD.Text = "0000"
        '
        'cob_FURI_BANK_NM
        '
        Me.cob_FURI_BANK_NM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_FURI_BANK_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_FURI_BANK_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_FURI_BANK_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_FURI_BANK_NM.InputCheck = True
        Me.cob_FURI_BANK_NM.ListHeaderPane.Height = 22
        Me.cob_FURI_BANK_NM.ListHeaderPane.Visible = False
        Me.cob_FURI_BANK_NM.Location = New System.Drawing.Point(272, 517)
        Me.cob_FURI_BANK_NM.Name = "cob_FURI_BANK_NM"
        Me.cob_FURI_BANK_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton8})
        Me.cob_FURI_BANK_NM.Size = New System.Drawing.Size(274, 22)
        Me.cob_FURI_BANK_NM.TabIndex = 43
        Me.cob_FURI_BANK_NM.TabStop = False
        '
        'DropDownButton8
        '
        Me.DropDownButton8.Name = "DropDownButton8"
        '
        'cob_FURI_BANK_SITEN_CD
        '
        Me.cob_FURI_BANK_SITEN_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_FURI_BANK_SITEN_CD.DropDown.AllowDrop = False
        Me.cob_FURI_BANK_SITEN_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_FURI_BANK_SITEN_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_FURI_BANK_SITEN_CD.Format = "9"
        Me.cob_FURI_BANK_SITEN_CD.HighlightText = True
        Me.cob_FURI_BANK_SITEN_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_FURI_BANK_SITEN_CD.InputCheck = True
        Me.cob_FURI_BANK_SITEN_CD.ListHeaderPane.Height = 22
        Me.cob_FURI_BANK_SITEN_CD.Location = New System.Drawing.Point(225, 542)
        Me.cob_FURI_BANK_SITEN_CD.MaxLength = 3
        Me.cob_FURI_BANK_SITEN_CD.Name = "cob_FURI_BANK_SITEN_CD"
        Me.cob_FURI_BANK_SITEN_CD.Size = New System.Drawing.Size(36, 22)
        Me.cob_FURI_BANK_SITEN_CD.Spin.AllowSpin = False
        Me.cob_FURI_BANK_SITEN_CD.TabIndex = 44
        Me.cob_FURI_BANK_SITEN_CD.Text = "000"
        '
        'cob_FURI_BANK_SITEN_NM
        '
        Me.cob_FURI_BANK_SITEN_NM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_FURI_BANK_SITEN_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_FURI_BANK_SITEN_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_FURI_BANK_SITEN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_FURI_BANK_SITEN_NM.InputCheck = True
        Me.cob_FURI_BANK_SITEN_NM.ListHeaderPane.Height = 22
        Me.cob_FURI_BANK_SITEN_NM.ListHeaderPane.Visible = False
        Me.cob_FURI_BANK_SITEN_NM.Location = New System.Drawing.Point(266, 542)
        Me.cob_FURI_BANK_SITEN_NM.Name = "cob_FURI_BANK_SITEN_NM"
        Me.cob_FURI_BANK_SITEN_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton9})
        Me.cob_FURI_BANK_SITEN_NM.Size = New System.Drawing.Size(285, 22)
        Me.cob_FURI_BANK_SITEN_NM.TabIndex = 45
        Me.cob_FURI_BANK_SITEN_NM.TabStop = False
        '
        'DropDownButton9
        '
        Me.DropDownButton9.Name = "DropDownButton9"
        '
        'cob_FURI_KOZA_SYUBETU
        '
        Me.cob_FURI_KOZA_SYUBETU.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_FURI_KOZA_SYUBETU.DropDown.AllowDrop = False
        Me.cob_FURI_KOZA_SYUBETU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_FURI_KOZA_SYUBETU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_FURI_KOZA_SYUBETU.Format = "9"
        Me.cob_FURI_KOZA_SYUBETU.HighlightText = True
        Me.cob_FURI_KOZA_SYUBETU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_FURI_KOZA_SYUBETU.InputCheck = True
        Me.cob_FURI_KOZA_SYUBETU.ListHeaderPane.Height = 22
        Me.cob_FURI_KOZA_SYUBETU.Location = New System.Drawing.Point(225, 567)
        Me.cob_FURI_KOZA_SYUBETU.MaxLength = 2
        Me.cob_FURI_KOZA_SYUBETU.Name = "cob_FURI_KOZA_SYUBETU"
        Me.cob_FURI_KOZA_SYUBETU.Size = New System.Drawing.Size(36, 22)
        Me.cob_FURI_KOZA_SYUBETU.Spin.AllowSpin = False
        Me.cob_FURI_KOZA_SYUBETU.TabIndex = 46
        Me.cob_FURI_KOZA_SYUBETU.Text = "00"
        '
        'cob_FURI_KOZA_SYUBETU_NM
        '
        Me.cob_FURI_KOZA_SYUBETU_NM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_FURI_KOZA_SYUBETU_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_FURI_KOZA_SYUBETU_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_FURI_KOZA_SYUBETU_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_FURI_KOZA_SYUBETU_NM.InputCheck = True
        Me.cob_FURI_KOZA_SYUBETU_NM.ListHeaderPane.Height = 22
        Me.cob_FURI_KOZA_SYUBETU_NM.ListHeaderPane.Visible = False
        Me.cob_FURI_KOZA_SYUBETU_NM.Location = New System.Drawing.Point(263, 567)
        Me.cob_FURI_KOZA_SYUBETU_NM.Name = "cob_FURI_KOZA_SYUBETU_NM"
        Me.cob_FURI_KOZA_SYUBETU_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton10})
        Me.cob_FURI_KOZA_SYUBETU_NM.Size = New System.Drawing.Size(119, 22)
        Me.cob_FURI_KOZA_SYUBETU_NM.TabIndex = 47
        Me.cob_FURI_KOZA_SYUBETU_NM.TabStop = False
        '
        'DropDownButton10
        '
        Me.DropDownButton10.Name = "DropDownButton10"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(453, 570)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(67, 15)
        Me.Label25.TabIndex = 121
        Me.Label25.Text = "口座番号"
        '
        'txt_FURI_KOZA_NO
        '
        Me.txt_FURI_KOZA_NO.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_FURI_KOZA_NO.DropDown.AllowDrop = False
        Me.txt_FURI_KOZA_NO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_FURI_KOZA_NO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_FURI_KOZA_NO.Format = "9"
        Me.txt_FURI_KOZA_NO.HighlightText = True
        Me.txt_FURI_KOZA_NO.InputCheck = True
        Me.txt_FURI_KOZA_NO.Location = New System.Drawing.Point(526, 567)
        Me.txt_FURI_KOZA_NO.MaxLength = 7
        Me.txt_FURI_KOZA_NO.Name = "txt_FURI_KOZA_NO"
        Me.txt_FURI_KOZA_NO.Size = New System.Drawing.Size(67, 22)
        Me.txt_FURI_KOZA_NO.TabIndex = 48
        Me.txt_FURI_KOZA_NO.Text = "0000000"
        '
        'txt_FURI_KOZA_MEIGI_KANA
        '
        Me.txt_FURI_KOZA_MEIGI_KANA.DropDown.AllowDrop = False
        Me.txt_FURI_KOZA_MEIGI_KANA.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_FURI_KOZA_MEIGI_KANA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_FURI_KOZA_MEIGI_KANA.Format = "H"
        Me.txt_FURI_KOZA_MEIGI_KANA.HighlightText = True
        Me.txt_FURI_KOZA_MEIGI_KANA.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_FURI_KOZA_MEIGI_KANA.InputCheck = True
        Me.txt_FURI_KOZA_MEIGI_KANA.Location = New System.Drawing.Point(225, 593)
        Me.txt_FURI_KOZA_MEIGI_KANA.MaxLength = 80
        Me.txt_FURI_KOZA_MEIGI_KANA.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_FURI_KOZA_MEIGI_KANA.Name = "txt_FURI_KOZA_MEIGI_KANA"
        Me.txt_FURI_KOZA_MEIGI_KANA.Size = New System.Drawing.Size(651, 20)
        Me.txt_FURI_KOZA_MEIGI_KANA.TabIndex = 51
        Me.txt_FURI_KOZA_MEIGI_KANA.Text = "HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH"
        '
        'txt_FURI_KOZA_MEIGI
        '
        Me.txt_FURI_KOZA_MEIGI.AllowSpace = GrapeCity.Win.Editors.AllowSpace.Wide
        Me.txt_FURI_KOZA_MEIGI.DropDown.AllowDrop = False
        Me.txt_FURI_KOZA_MEIGI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_FURI_KOZA_MEIGI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_FURI_KOZA_MEIGI.Format = "Ｚ"
        Me.txt_FURI_KOZA_MEIGI.HighlightText = True
        Me.txt_FURI_KOZA_MEIGI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_FURI_KOZA_MEIGI.InputCheck = True
        Me.txt_FURI_KOZA_MEIGI.Location = New System.Drawing.Point(225, 616)
        Me.txt_FURI_KOZA_MEIGI.MaxLength = 80
        Me.txt_FURI_KOZA_MEIGI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_FURI_KOZA_MEIGI.Name = "txt_FURI_KOZA_MEIGI"
        Me.txt_FURI_KOZA_MEIGI.Size = New System.Drawing.Size(651, 20)
        Me.txt_FURI_KOZA_MEIGI.TabIndex = 52
        Me.txt_FURI_KOZA_MEIGI.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblTotal.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(412, 21)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(47, 15)
        Me.lblTotal.TabIndex = 147
        Me.lblTotal.Text = "99999"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.Location = New System.Drawing.Point(396, 21)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(15, 15)
        Me.Label26.TabIndex = 146
        Me.Label26.Text = "/"
        '
        'txt_Now
        '
        Me.txt_Now.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.txt_Now.DropDown.AllowDrop = False
        Me.txt_Now.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_Now.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_Now.Format = "9"
        Me.txt_Now.HighlightText = True
        Me.txt_Now.Location = New System.Drawing.Point(341, 16)
        Me.txt_Now.MaxLength = 9
        Me.txt_Now.Name = "txt_Now"
        Me.txt_Now.Size = New System.Drawing.Size(51, 25)
        Me.txt_Now.TabIndex = 145
        Me.txt_Now.TabStop = False
        Me.txt_Now.Text = "99999"
        '
        'cmdLast
        '
        Me.cmdLast.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdLast.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLast.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(514, 16)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 25)
        Me.cmdLast.TabIndex = 144
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = "≫"
        Me.cmdLast.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNext.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(466, 16)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 25)
        Me.cmdNext.TabIndex = 143
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = ">"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdBef
        '
        Me.cmdBef.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdBef.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdBef.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdBef.Location = New System.Drawing.Point(288, 16)
        Me.cmdBef.Name = "cmdBef"
        Me.cmdBef.Size = New System.Drawing.Size(40, 25)
        Me.cmdBef.TabIndex = 142
        Me.cmdBef.TabStop = False
        Me.cmdBef.Text = "<"
        Me.cmdBef.UseVisualStyleBackColor = True
        '
        'cmdTop
        '
        Me.cmdTop.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdTop.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTop.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdTop.Location = New System.Drawing.Point(240, 16)
        Me.cmdTop.Name = "cmdTop"
        Me.cmdTop.Size = New System.Drawing.Size(40, 25)
        Me.cmdTop.TabIndex = 141
        Me.cmdTop.TabStop = False
        Me.cmdTop.Text = "≪"
        Me.cmdTop.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(12, 6)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 44)
        Me.cmdSave.TabIndex = 151
        Me.cmdSave.Text = "保存"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'date_NYUHEN_DATE
        '
        Me.date_NYUHEN_DATE.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.date_NYUHEN_DATE.DefaultActiveField = DateEraYearField1
        Me.date_NYUHEN_DATE.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.date_NYUHEN_DATE.DisabledForeColor = System.Drawing.SystemColors.WindowText
        DateEraYearDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField2.Text = "/"
        DateMonthDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField3.Text = "/"
        DateDayDisplayField1.ShowLeadingZero = True
        Me.date_NYUHEN_DATE.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField1, DateLiteralDisplayField1, DateEraYearDisplayField1, DateLiteralDisplayField2, DateMonthDisplayField1, DateLiteralDisplayField3, DateDayDisplayField1})
        Me.date_NYUHEN_DATE.Enabled = False
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.date_NYUHEN_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.date_NYUHEN_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_NYUHEN_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_NYUHEN_DATE.Location = New System.Drawing.Point(713, 180)
        Me.date_NYUHEN_DATE.Name = "date_NYUHEN_DATE"
        Me.date_NYUHEN_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton13})
        Me.date_NYUHEN_DATE.Size = New System.Drawing.Size(125, 21)
        Me.date_NYUHEN_DATE.Spin.AllowSpin = False
        Me.date_NYUHEN_DATE.TabIndex = 7
        Me.date_NYUHEN_DATE.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        '
        'DropDownButton13
        '
        Me.DropDownButton13.Name = "DropDownButton13"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(604, 180)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(107, 15)
        Me.Label30.TabIndex = 26
        Me.Label30.Text = "入金日、返還日"
        '
        'DropDownButton14
        '
        Me.DropDownButton14.Name = "DropDownButton14"
        '
        'DropDownButton15
        '
        Me.DropDownButton15.Name = "DropDownButton15"
        '
        'DropDownButton16
        '
        Me.DropDownButton16.Name = "DropDownButton16"
        '
        'DropDownButton17
        '
        Me.DropDownButton17.Name = "DropDownButton17"
        '
        'DropDownButton18
        '
        Me.DropDownButton18.Name = "DropDownButton18"
        '
        'DropDownButton19
        '
        Me.DropDownButton19.Name = "DropDownButton19"
        '
        'txt_BIKO
        '
        Me.txt_BIKO.DropDown.AllowDrop = False
        Me.txt_BIKO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_BIKO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_BIKO.Format = "Ｚ"
        Me.txt_BIKO.HighlightText = True
        Me.txt_BIKO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_BIKO.Location = New System.Drawing.Point(422, 645)
        Me.txt_BIKO.MaxLength = 400
        Me.txt_BIKO.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_BIKO.Multiline = True
        Me.txt_BIKO.Name = "txt_BIKO"
        Me.txt_BIKO.Size = New System.Drawing.Size(662, 81)
        Me.txt_BIKO.TabIndex = 57
        Me.txt_BIKO.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠" &
    "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠" &
    "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(364, 645)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 15)
        Me.Label15.TabIndex = 126
        Me.Label15.Text = "□備考"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbtn_BANK_NASI)
        Me.GroupBox4.Controls.Add(Me.rbtn_BANK_ARI)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.GroupBox4.Location = New System.Drawing.Point(225, 477)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(127, 37)
        Me.GroupBox4.TabIndex = 41
        Me.GroupBox4.TabStop = False
        '
        'rbtn_BANK_NASI
        '
        Me.rbtn_BANK_NASI.AutoSize = True
        Me.rbtn_BANK_NASI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_BANK_NASI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtn_BANK_NASI.Location = New System.Drawing.Point(69, 11)
        Me.rbtn_BANK_NASI.Name = "rbtn_BANK_NASI"
        Me.rbtn_BANK_NASI.Size = New System.Drawing.Size(46, 20)
        Me.rbtn_BANK_NASI.TabIndex = 1
        Me.rbtn_BANK_NASI.Text = "無"
        Me.rbtn_BANK_NASI.UseVisualStyleBackColor = True
        '
        'rbtn_BANK_ARI
        '
        Me.rbtn_BANK_ARI.AutoSize = True
        Me.rbtn_BANK_ARI.Checked = True
        Me.rbtn_BANK_ARI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_BANK_ARI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtn_BANK_ARI.Location = New System.Drawing.Point(7, 11)
        Me.rbtn_BANK_ARI.Name = "rbtn_BANK_ARI"
        Me.rbtn_BANK_ARI.Size = New System.Drawing.Size(46, 20)
        Me.rbtn_BANK_ARI.TabIndex = 0
        Me.rbtn_BANK_ARI.TabStop = True
        Me.rbtn_BANK_ARI.Text = "有"
        Me.rbtn_BANK_ARI.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(44, 490)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(157, 15)
        Me.Label16.TabIndex = 128
        Me.Label16.Text = "金融機関情報入力有無"
        '
        'cob_JIMUITAKU_CD
        '
        Me.cob_JIMUITAKU_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_JIMUITAKU_CD.DropDown.AllowDrop = False
        Me.cob_JIMUITAKU_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_JIMUITAKU_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_JIMUITAKU_CD.Format = "9"
        Me.cob_JIMUITAKU_CD.HighlightText = True
        Me.cob_JIMUITAKU_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_JIMUITAKU_CD.InputCheck = True
        Me.cob_JIMUITAKU_CD.ListHeaderPane.Height = 22
        Me.cob_JIMUITAKU_CD.Location = New System.Drawing.Point(225, 425)
        Me.cob_JIMUITAKU_CD.MaxLength = 3
        Me.cob_JIMUITAKU_CD.Name = "cob_JIMUITAKU_CD"
        Me.cob_JIMUITAKU_CD.Size = New System.Drawing.Size(36, 22)
        Me.cob_JIMUITAKU_CD.Spin.AllowSpin = False
        Me.cob_JIMUITAKU_CD.TabIndex = 35
        Me.cob_JIMUITAKU_CD.Text = "000"
        '
        'cob_JIMUITAKU_NM
        '
        Me.cob_JIMUITAKU_NM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_JIMUITAKU_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_JIMUITAKU_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_JIMUITAKU_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_JIMUITAKU_NM.InputCheck = True
        Me.cob_JIMUITAKU_NM.ListHeaderPane.Height = 22
        Me.cob_JIMUITAKU_NM.ListHeaderPane.Visible = False
        Me.cob_JIMUITAKU_NM.Location = New System.Drawing.Point(267, 425)
        Me.cob_JIMUITAKU_NM.Name = "cob_JIMUITAKU_NM"
        Me.cob_JIMUITAKU_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton21})
        Me.cob_JIMUITAKU_NM.Size = New System.Drawing.Size(436, 22)
        Me.cob_JIMUITAKU_NM.TabIndex = 36
        Me.cob_JIMUITAKU_NM.TabStop = False
        '
        'DropDownButton21
        '
        Me.DropDownButton21.Name = "DropDownButton21"
        '
        'txt_ADDR_E_MAIL
        '
        Me.txt_ADDR_E_MAIL.DropDown.AllowDrop = False
        Me.txt_ADDR_E_MAIL.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_E_MAIL.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_E_MAIL.Format = "Aa9#@"
        Me.txt_ADDR_E_MAIL.HighlightText = True
        Me.txt_ADDR_E_MAIL.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_ADDR_E_MAIL.Location = New System.Drawing.Point(363, 399)
        Me.txt_ADDR_E_MAIL.MaxLength = 50
        Me.txt_ADDR_E_MAIL.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_E_MAIL.Name = "txt_ADDR_E_MAIL"
        Me.txt_ADDR_E_MAIL.Size = New System.Drawing.Size(513, 22)
        Me.txt_ADDR_E_MAIL.TabIndex = 34
        Me.txt_ADDR_E_MAIL.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label63.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label63.Location = New System.Drawing.Point(225, 402)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(113, 15)
        Me.Label63.TabIndex = 1019
        Me.Label63.Text = "□メールアドレス"
        '
        'txt_ADDR_TEL2
        '
        Me.txt_ADDR_TEL2.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_ADDR_TEL2.DropDown.AllowDrop = False
        Me.txt_ADDR_TEL2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_TEL2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_TEL2.Format = "9-"
        Me.txt_ADDR_TEL2.HighlightText = True
        Me.txt_ADDR_TEL2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_ADDR_TEL2.Location = New System.Drawing.Point(519, 376)
        Me.txt_ADDR_TEL2.MaxLength = 14
        Me.txt_ADDR_TEL2.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_TEL2.Name = "txt_ADDR_TEL2"
        Me.txt_ADDR_TEL2.Size = New System.Drawing.Size(122, 20)
        Me.txt_ADDR_TEL2.TabIndex = 32
        Me.txt_ADDR_TEL2.Text = "9999-9999-9999"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.BackColor = System.Drawing.Color.Transparent
        Me.Label64.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label64.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label64.Location = New System.Drawing.Point(453, 379)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(60, 15)
        Me.Label64.TabIndex = 1015
        Me.Label64.Text = "□電話2"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label65.Location = New System.Drawing.Point(44, 265)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(160, 15)
        Me.Label65.TabIndex = 1003
        Me.Label65.Text = "■申込者名(個人・団体)"
        '
        'txt_ADDR_FAX
        '
        Me.txt_ADDR_FAX.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_ADDR_FAX.DropDown.AllowDrop = False
        Me.txt_ADDR_FAX.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_FAX.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_FAX.Format = "9-"
        Me.txt_ADDR_FAX.HighlightText = True
        Me.txt_ADDR_FAX.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_ADDR_FAX.Location = New System.Drawing.Point(732, 377)
        Me.txt_ADDR_FAX.MaxLength = 14
        Me.txt_ADDR_FAX.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_FAX.Name = "txt_ADDR_FAX"
        Me.txt_ADDR_FAX.Size = New System.Drawing.Size(122, 20)
        Me.txt_ADDR_FAX.TabIndex = 33
        Me.txt_ADDR_FAX.Text = "9999-9999-9999"
        '
        'txt_ADDR_TEL1
        '
        Me.txt_ADDR_TEL1.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_ADDR_TEL1.DropDown.AllowDrop = False
        Me.txt_ADDR_TEL1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_TEL1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_TEL1.Format = "9-"
        Me.txt_ADDR_TEL1.HighlightText = True
        Me.txt_ADDR_TEL1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_ADDR_TEL1.InputCheck = True
        Me.txt_ADDR_TEL1.Location = New System.Drawing.Point(294, 375)
        Me.txt_ADDR_TEL1.MaxLength = 14
        Me.txt_ADDR_TEL1.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_TEL1.Name = "txt_ADDR_TEL1"
        Me.txt_ADDR_TEL1.Size = New System.Drawing.Size(122, 20)
        Me.txt_ADDR_TEL1.TabIndex = 31
        Me.txt_ADDR_TEL1.Text = "9999-9999-9999"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label66.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label66.Location = New System.Drawing.Point(678, 380)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(48, 15)
        Me.Label66.TabIndex = 1017
        Me.Label66.Text = "□FAX"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label67.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label67.Location = New System.Drawing.Point(223, 378)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(52, 15)
        Me.Label67.TabIndex = 1013
        Me.Label67.Text = "■電話"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.Color.Transparent
        Me.Label68.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label68.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label68.Location = New System.Drawing.Point(44, 311)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(52, 15)
        Me.Label68.TabIndex = 1008
        Me.Label68.Text = "■住所"
        '
        'txt_DAIHYO_NAME
        '
        Me.txt_DAIHYO_NAME.AllowSpace = GrapeCity.Win.Editors.AllowSpace.Wide
        Me.txt_DAIHYO_NAME.DropDown.AllowDrop = False
        Me.txt_DAIHYO_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_DAIHYO_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_DAIHYO_NAME.Format = "Ｚ"
        Me.txt_DAIHYO_NAME.HighlightText = True
        Me.txt_DAIHYO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_DAIHYO_NAME.Location = New System.Drawing.Point(225, 285)
        Me.txt_DAIHYO_NAME.MaxLength = 50
        Me.txt_DAIHYO_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_DAIHYO_NAME.Name = "txt_DAIHYO_NAME"
        Me.txt_DAIHYO_NAME.Size = New System.Drawing.Size(513, 20)
        Me.txt_DAIHYO_NAME.TabIndex = 23
        Me.txt_DAIHYO_NAME.Text = "ＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺ"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.BackColor = System.Drawing.Color.Transparent
        Me.Label69.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label69.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label69.Location = New System.Drawing.Point(44, 288)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(122, 15)
        Me.Label69.TabIndex = 1005
        Me.Label69.Text = "□代表者名(団体)"
        '
        'txt_KEIYAKUSYA_KANA
        '
        Me.txt_KEIYAKUSYA_KANA.DropDown.AllowDrop = False
        Me.txt_KEIYAKUSYA_KANA.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KEIYAKUSYA_KANA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_KEIYAKUSYA_KANA.Format = "H"
        Me.txt_KEIYAKUSYA_KANA.HighlightText = True
        Me.txt_KEIYAKUSYA_KANA.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_KEIYAKUSYA_KANA.InputCheck = True
        Me.txt_KEIYAKUSYA_KANA.Location = New System.Drawing.Point(225, 238)
        Me.txt_KEIYAKUSYA_KANA.MaxLength = 50
        Me.txt_KEIYAKUSYA_KANA.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KEIYAKUSYA_KANA.Name = "txt_KEIYAKUSYA_KANA"
        Me.txt_KEIYAKUSYA_KANA.Size = New System.Drawing.Size(513, 20)
        Me.txt_KEIYAKUSYA_KANA.TabIndex = 21
        Me.txt_KEIYAKUSYA_KANA.Text = "HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH"
        '
        'txt_KEIYAKUSYA_NAME
        '
        Me.txt_KEIYAKUSYA_NAME.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.txt_KEIYAKUSYA_NAME.AllowSpace = GrapeCity.Win.Editors.AllowSpace.Wide
        Me.txt_KEIYAKUSYA_NAME.DropDown.AllowDrop = False
        Me.txt_KEIYAKUSYA_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KEIYAKUSYA_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_KEIYAKUSYA_NAME.Format = "Ｚ"
        Me.txt_KEIYAKUSYA_NAME.HighlightText = True
        Me.txt_KEIYAKUSYA_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_KEIYAKUSYA_NAME.InputCheck = True
        Me.txt_KEIYAKUSYA_NAME.Location = New System.Drawing.Point(225, 262)
        Me.txt_KEIYAKUSYA_NAME.MaxLength = 50
        Me.txt_KEIYAKUSYA_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KEIYAKUSYA_NAME.Name = "txt_KEIYAKUSYA_NAME"
        Me.txt_KEIYAKUSYA_NAME.Size = New System.Drawing.Size(513, 20)
        Me.txt_KEIYAKUSYA_NAME.TabIndex = 22
        Me.txt_KEIYAKUSYA_NAME.Text = "ＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺ"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.BackColor = System.Drawing.Color.Transparent
        Me.Label70.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label70.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label70.Location = New System.Drawing.Point(44, 241)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(128, 15)
        Me.Label70.TabIndex = 1001
        Me.Label70.Text = "■申込者名(ﾌﾘｶﾞﾅ)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lbl_KI
        '
        Me.lbl_KI.AutoSize = True
        Me.lbl_KI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KI.Location = New System.Drawing.Point(24, 51)
        Me.lbl_KI.Name = "lbl_KI"
        Me.lbl_KI.Size = New System.Drawing.Size(53, 15)
        Me.lbl_KI.TabIndex = 1032
        Me.lbl_KI.Text = "第99期"
        '
        'txt_ADDR_4
        '
        Me.txt_ADDR_4.AllowSpace = GrapeCity.Win.Editors.AllowSpace.Wide
        Me.txt_ADDR_4.DropDown.AllowDrop = False
        Me.txt_ADDR_4.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_4.Format = "Ｚ"
        Me.txt_ADDR_4.HighlightText = True
        Me.txt_ADDR_4.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ADDR_4.Location = New System.Drawing.Point(333, 352)
        Me.txt_ADDR_4.MaxLength = 40
        Me.txt_ADDR_4.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_4.Name = "txt_ADDR_4"
        Me.txt_ADDR_4.Size = New System.Drawing.Size(325, 20)
        Me.txt_ADDR_4.TabIndex = 28
        Me.txt_ADDR_4.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'txt_ADDR_3
        '
        Me.txt_ADDR_3.AllowSpace = GrapeCity.Win.Editors.AllowSpace.Wide
        Me.txt_ADDR_3.DropDown.AllowDrop = False
        Me.txt_ADDR_3.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_3.Format = "Ｚ"
        Me.txt_ADDR_3.HighlightText = True
        Me.txt_ADDR_3.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ADDR_3.Location = New System.Drawing.Point(333, 330)
        Me.txt_ADDR_3.MaxLength = 30
        Me.txt_ADDR_3.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_3.Name = "txt_ADDR_3"
        Me.txt_ADDR_3.Size = New System.Drawing.Size(243, 20)
        Me.txt_ADDR_3.TabIndex = 27
        Me.txt_ADDR_3.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'txt_ADDR_2
        '
        Me.txt_ADDR_2.AllowSpace = GrapeCity.Win.Editors.AllowSpace.Wide
        Me.txt_ADDR_2.DropDown.AllowDrop = False
        Me.txt_ADDR_2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_2.Format = "Ｚ"
        Me.txt_ADDR_2.HighlightText = True
        Me.txt_ADDR_2.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ADDR_2.InputCheck = True
        Me.txt_ADDR_2.Location = New System.Drawing.Point(416, 308)
        Me.txt_ADDR_2.MaxLength = 30
        Me.txt_ADDR_2.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_2.Name = "txt_ADDR_2"
        Me.txt_ADDR_2.Size = New System.Drawing.Size(243, 20)
        Me.txt_ADDR_2.TabIndex = 26
        Me.txt_ADDR_2.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'txt_ADDR_1
        '
        Me.txt_ADDR_1.AllowSpace = GrapeCity.Win.Editors.AllowSpace.Wide
        Me.txt_ADDR_1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txt_ADDR_1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_ADDR_1.DropDown.AllowDrop = False
        Me.txt_ADDR_1.Enabled = False
        Me.txt_ADDR_1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_1.Format = "Ｚ"
        Me.txt_ADDR_1.HighlightText = True
        Me.txt_ADDR_1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ADDR_1.InputCheck = True
        Me.txt_ADDR_1.Location = New System.Drawing.Point(333, 308)
        Me.txt_ADDR_1.MaxLength = 8
        Me.txt_ADDR_1.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_1.Name = "txt_ADDR_1"
        Me.txt_ADDR_1.Size = New System.Drawing.Size(77, 20)
        Me.txt_ADDR_1.TabIndex = 25
        Me.txt_ADDR_1.Text = "＠＠＠＠"
        '
        'msk_ADDR_POST
        '
        Me.msk_ADDR_POST.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        MaskLiteralField1.Text = "〒 "
        MaskPatternField1.MaxLength = 3
        MaskPatternField1.MinLength = 3
        MaskPatternField1.Pattern = "\D"
        MaskLiteralField2.Text = "-"
        MaskPatternField2.MaxLength = 4
        MaskPatternField2.MinLength = 4
        MaskPatternField2.Pattern = "\D"
        Me.msk_ADDR_POST.Fields.AddRange(New GrapeCity.Win.Editors.Fields.MaskField() {MaskLiteralField1, MaskPatternField1, MaskLiteralField2, MaskPatternField2})
        Me.msk_ADDR_POST.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.msk_ADDR_POST.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.msk_ADDR_POST.HighlightText = GrapeCity.Win.Editors.HighlightText.All
        Me.msk_ADDR_POST.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.msk_ADDR_POST.InputCheck = True
        Me.msk_ADDR_POST.Location = New System.Drawing.Point(225, 308)
        Me.msk_ADDR_POST.Name = "msk_ADDR_POST"
        Me.msk_ADDR_POST.Size = New System.Drawing.Size(101, 21)
        Me.msk_ADDR_POST.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(44, 378)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 1039
        Me.Label6.Text = "■連絡先"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(44, 428)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 15)
        Me.Label7.TabIndex = 1040
        Me.Label7.Text = "■事務委託先"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(360, 490)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(222, 15)
        Me.Label11.TabIndex = 1042
        Me.Label11.Text = "(有の時、下記の項目は必須入力)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(44, 647)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 15)
        Me.Label9.TabIndex = 1043
        Me.Label9.Text = "■入力確認有無"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtn_NYURYOKU_JYOKYO2)
        Me.GroupBox1.Controls.Add(Me.rbtn_NYURYOKU_JYOKYO1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(225, 634)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(127, 37)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        '
        'rbtn_NYURYOKU_JYOKYO2
        '
        Me.rbtn_NYURYOKU_JYOKYO2.AutoSize = True
        Me.rbtn_NYURYOKU_JYOKYO2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_NYURYOKU_JYOKYO2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtn_NYURYOKU_JYOKYO2.Location = New System.Drawing.Point(69, 11)
        Me.rbtn_NYURYOKU_JYOKYO2.Name = "rbtn_NYURYOKU_JYOKYO2"
        Me.rbtn_NYURYOKU_JYOKYO2.Size = New System.Drawing.Size(46, 20)
        Me.rbtn_NYURYOKU_JYOKYO2.TabIndex = 1
        Me.rbtn_NYURYOKU_JYOKYO2.Text = "無"
        Me.rbtn_NYURYOKU_JYOKYO2.UseVisualStyleBackColor = True
        '
        'rbtn_NYURYOKU_JYOKYO1
        '
        Me.rbtn_NYURYOKU_JYOKYO1.AutoSize = True
        Me.rbtn_NYURYOKU_JYOKYO1.Checked = True
        Me.rbtn_NYURYOKU_JYOKYO1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_NYURYOKU_JYOKYO1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtn_NYURYOKU_JYOKYO1.Location = New System.Drawing.Point(7, 11)
        Me.rbtn_NYURYOKU_JYOKYO1.Name = "rbtn_NYURYOKU_JYOKYO1"
        Me.rbtn_NYURYOKU_JYOKYO1.Size = New System.Drawing.Size(46, 20)
        Me.rbtn_NYURYOKU_JYOKYO1.TabIndex = 0
        Me.rbtn_NYURYOKU_JYOKYO1.TabStop = True
        Me.rbtn_NYURYOKU_JYOKYO1.Text = "有"
        Me.rbtn_NYURYOKU_JYOKYO1.UseVisualStyleBackColor = True
        '
        'lbl_HasuSeigen
        '
        Me.lbl_HasuSeigen.AutoSize = True
        Me.lbl_HasuSeigen.BackColor = System.Drawing.Color.Transparent
        Me.lbl_HasuSeigen.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_HasuSeigen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_HasuSeigen.Location = New System.Drawing.Point(44, 181)
        Me.lbl_HasuSeigen.Name = "lbl_HasuSeigen"
        Me.lbl_HasuSeigen.Size = New System.Drawing.Size(82, 15)
        Me.lbl_HasuSeigen.TabIndex = 998
        Me.lbl_HasuSeigen.Text = "■契約状況"
        '
        'DropDownButton3
        '
        Me.DropDownButton3.Name = "DropDownButton3"
        '
        'cob_KEIYAKU_JYOKYO_NM
        '
        Me.cob_KEIYAKU_JYOKYO_NM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_KEIYAKU_JYOKYO_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_KEIYAKU_JYOKYO_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKU_JYOKYO_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKU_JYOKYO_NM.InputCheck = True
        Me.cob_KEIYAKU_JYOKYO_NM.ListHeaderPane.Height = 22
        Me.cob_KEIYAKU_JYOKYO_NM.ListHeaderPane.Visible = False
        Me.cob_KEIYAKU_JYOKYO_NM.Location = New System.Drawing.Point(186, 178)
        Me.cob_KEIYAKU_JYOKYO_NM.Name = "cob_KEIYAKU_JYOKYO_NM"
        Me.cob_KEIYAKU_JYOKYO_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.cob_KEIYAKU_JYOKYO_NM.Size = New System.Drawing.Size(119, 22)
        Me.cob_KEIYAKU_JYOKYO_NM.TabIndex = 6
        Me.cob_KEIYAKU_JYOKYO_NM.TabStop = False
        '
        'cob_KEIYAKU_JYOKYO
        '
        Me.cob_KEIYAKU_JYOKYO.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_KEIYAKU_JYOKYO.DropDown.AllowDrop = False
        Me.cob_KEIYAKU_JYOKYO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKU_JYOKYO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKU_JYOKYO.Format = "9"
        Me.cob_KEIYAKU_JYOKYO.HighlightText = True
        Me.cob_KEIYAKU_JYOKYO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_KEIYAKU_JYOKYO.InputCheck = True
        Me.cob_KEIYAKU_JYOKYO.ListHeaderPane.Height = 22
        Me.cob_KEIYAKU_JYOKYO.Location = New System.Drawing.Point(157, 178)
        Me.cob_KEIYAKU_JYOKYO.MaxLength = 1
        Me.cob_KEIYAKU_JYOKYO.Name = "cob_KEIYAKU_JYOKYO"
        Me.cob_KEIYAKU_JYOKYO.Size = New System.Drawing.Size(23, 22)
        Me.cob_KEIYAKU_JYOKYO.Spin.AllowSpin = False
        Me.cob_KEIYAKU_JYOKYO.TabIndex = 5
        Me.cob_KEIYAKU_JYOKYO.Text = "0"
        '
        'txt_SEISANSYA_CD
        '
        Me.txt_SEISANSYA_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_SEISANSYA_CD.DropDown.AllowDrop = False
        Me.txt_SEISANSYA_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_SEISANSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_SEISANSYA_CD.Format = "9"
        Me.txt_SEISANSYA_CD.HighlightText = True
        Me.txt_SEISANSYA_CD.Location = New System.Drawing.Point(813, 101)
        Me.txt_SEISANSYA_CD.MaxLength = 5
        Me.txt_SEISANSYA_CD.Name = "txt_SEISANSYA_CD"
        Me.txt_SEISANSYA_CD.Size = New System.Drawing.Size(50, 22)
        Me.txt_SEISANSYA_CD.TabIndex = 8
        Me.txt_SEISANSYA_CD.Text = "00000"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(589, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(217, 15)
        Me.Label4.TabIndex = 1046
        Me.Label4.Text = "□経営安定対策事業生産者番号"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(589, 129)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 15)
        Me.Label12.TabIndex = 1048
        Me.Label12.Text = "□日鶏協番号"
        '
        'txt_NIKKEIKYO_CD
        '
        Me.txt_NIKKEIKYO_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_NIKKEIKYO_CD.DropDown.AllowDrop = False
        Me.txt_NIKKEIKYO_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_NIKKEIKYO_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_NIKKEIKYO_CD.Format = "9"
        Me.txt_NIKKEIKYO_CD.HighlightText = True
        Me.txt_NIKKEIKYO_CD.Location = New System.Drawing.Point(813, 126)
        Me.txt_NIKKEIKYO_CD.MaxLength = 5
        Me.txt_NIKKEIKYO_CD.Name = "txt_NIKKEIKYO_CD"
        Me.txt_NIKKEIKYO_CD.Size = New System.Drawing.Size(50, 22)
        Me.txt_NIKKEIKYO_CD.TabIndex = 9
        Me.txt_NIKKEIKYO_CD.Text = "00000"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(844, 181)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 15)
        Me.Label14.TabIndex = 1050
        Me.Label14.Text = "(入金完了時)"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(12, 207)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(994, 25)
        Me.Panel1.TabIndex = 1051
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(20, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 19)
        Me.Label5.TabIndex = 1034
        Me.Label5.Text = "申請者基本情報2"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label32)
        Me.Panel2.Location = New System.Drawing.Point(12, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(994, 25)
        Me.Panel2.TabIndex = 1052
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(20, 2)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(160, 19)
        Me.Label32.TabIndex = 988
        Me.Label32.Text = "申請者基本情報1"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Location = New System.Drawing.Point(12, 453)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(994, 25)
        Me.Panel3.TabIndex = 1052
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(20, 2)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(160, 19)
        Me.Label10.TabIndex = 1042
        Me.Label10.Text = "申請者基本情報3"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(316, 155)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(178, 15)
        Me.Label13.TabIndex = 1053
        Me.Label13.Text = "（家族型、企業型、鶏以外）"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(316, 181)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(223, 15)
        Me.Label17.TabIndex = 1054
        Me.Label17.Text = "（継続契約、新規契約、未継続者）"
        '
        'date_HAIGYO_DATE
        '
        Me.date_HAIGYO_DATE.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.date_HAIGYO_DATE.DefaultActiveField = DateEraYearField2
        DateEraYearDisplayField2.ShowLeadingZero = True
        DateLiteralDisplayField5.Text = "/"
        DateMonthDisplayField2.ShowLeadingZero = True
        DateLiteralDisplayField6.Text = "/"
        DateDayDisplayField2.ShowLeadingZero = True
        Me.date_HAIGYO_DATE.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField2, DateLiteralDisplayField4, DateEraYearDisplayField2, DateLiteralDisplayField5, DateMonthDisplayField2, DateLiteralDisplayField6, DateDayDisplayField2})
        DateLiteralField5.Text = "/"
        DateLiteralField6.Text = "/"
        Me.date_HAIGYO_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateLiteralField4, DateEraYearField2, DateLiteralField5, DateMonthField2, DateLiteralField6, DateDayField2})
        Me.date_HAIGYO_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_HAIGYO_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_HAIGYO_DATE.Location = New System.Drawing.Point(225, 680)
        Me.date_HAIGYO_DATE.Name = "date_HAIGYO_DATE"
        Me.date_HAIGYO_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.date_HAIGYO_DATE.Size = New System.Drawing.Size(125, 21)
        Me.date_HAIGYO_DATE.Spin.AllowSpin = False
        Me.date_HAIGYO_DATE.TabIndex = 55
        Me.date_HAIGYO_DATE.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(589, 155)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 15)
        Me.Label18.TabIndex = 1055
        Me.Label18.Text = "□契約日"
        '
        'date_KEIYAKU_DATE
        '
        Me.date_KEIYAKU_DATE.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.date_KEIYAKU_DATE.DefaultActiveField = DateEraYearField3
        DateEraYearDisplayField3.ShowLeadingZero = True
        DateLiteralDisplayField8.Text = "/"
        DateMonthDisplayField3.ShowLeadingZero = True
        DateLiteralDisplayField9.Text = "/"
        DateDayDisplayField3.ShowLeadingZero = True
        Me.date_KEIYAKU_DATE.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField3, DateLiteralDisplayField7, DateEraYearDisplayField3, DateLiteralDisplayField8, DateMonthDisplayField3, DateLiteralDisplayField9, DateDayDisplayField3})
        DateLiteralField8.Text = "/"
        DateLiteralField9.Text = "/"
        Me.date_KEIYAKU_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField3, DateLiteralField7, DateEraYearField3, DateLiteralField8, DateMonthField3, DateLiteralField9, DateDayField3})
        Me.date_KEIYAKU_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_KEIYAKU_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_KEIYAKU_DATE.Location = New System.Drawing.Point(713, 153)
        Me.date_KEIYAKU_DATE.Name = "date_KEIYAKU_DATE"
        Me.date_KEIYAKU_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.date_KEIYAKU_DATE.Size = New System.Drawing.Size(125, 21)
        Me.date_KEIYAKU_DATE.Spin.AllowSpin = False
        Me.date_KEIYAKU_DATE.TabIndex = 10
        Me.date_KEIYAKU_DATE.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        '
        'DropDownButton6
        '
        Me.DropDownButton6.Name = "DropDownButton6"
        '
        'frmGJ1011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.date_KEIYAKU_DATE)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.date_HAIGYO_DATE)
        Me.Controls.Add(Me.txt_FURI_KOZA_MEIGI)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txt_NIKKEIKYO_CD)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_SEISANSYA_CD)
        Me.Controls.Add(Me.txt_BIKO)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_ADDR_4)
        Me.Controls.Add(Me.txt_ADDR_3)
        Me.Controls.Add(Me.txt_ADDR_2)
        Me.Controls.Add(Me.txt_ADDR_1)
        Me.Controls.Add(Me.msk_ADDR_POST)
        Me.Controls.Add(Me.lbl_KI)
        Me.Controls.Add(Me.txt_ADDR_E_MAIL)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.txt_ADDR_TEL2)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.txt_ADDR_FAX)
        Me.Controls.Add(Me.txt_ADDR_TEL1)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.txt_DAIHYO_NAME)
        Me.Controls.Add(Me.Label69)
        Me.Controls.Add(Me.txt_KEIYAKUSYA_KANA)
        Me.Controls.Add(Me.txt_KEIYAKUSYA_NAME)
        Me.Controls.Add(Me.Label70)
        Me.Controls.Add(Me.cob_KEIYAKU_JYOKYO)
        Me.Controls.Add(Me.cob_KEIYAKU_JYOKYO_NM)
        Me.Controls.Add(Me.lbl_HasuSeigen)
        Me.Controls.Add(Me.cob_JIMUITAKU_CD)
        Me.Controls.Add(Me.cob_JIMUITAKU_NM)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.date_NYUHEN_DATE)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txt_FURI_KOZA_MEIGI_KANA)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txt_FURI_KOZA_NO)
        Me.Controls.Add(Me.cob_FURI_KOZA_SYUBETU)
        Me.Controls.Add(Me.cob_FURI_KOZA_SYUBETU_NM)
        Me.Controls.Add(Me.cob_FURI_BANK_SITEN_CD)
        Me.Controls.Add(Me.cob_FURI_BANK_SITEN_NM)
        Me.Controls.Add(Me.cob_FURI_BANK_CD)
        Me.Controls.Add(Me.cob_FURI_BANK_NM)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cob_KEIYAKU_KBN)
        Me.Controls.Add(Me.cob_KEIYAKU_KBN_NM)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cob_KEN_CD)
        Me.Controls.Add(Me.cob_KEN_NM)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_KEIYAKUSYA_CD)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "frmGJ1011"
        Me.Text = "(GJ1011)契約者マスタメンテナンス"
        Me.Controls.SetChildIndex(Me.GroupBox4, 0)
        Me.Controls.SetChildIndex(Me.txt_KEIYAKUSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cob_KEN_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_KEN_CD, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.cob_KEIYAKU_KBN_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_KEIYAKU_KBN, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.cob_FURI_BANK_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_FURI_BANK_CD, 0)
        Me.Controls.SetChildIndex(Me.cob_FURI_BANK_SITEN_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_FURI_BANK_SITEN_CD, 0)
        Me.Controls.SetChildIndex(Me.cob_FURI_KOZA_SYUBETU_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_FURI_KOZA_SYUBETU, 0)
        Me.Controls.SetChildIndex(Me.txt_FURI_KOZA_NO, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.txt_FURI_KOZA_MEIGI_KANA, 0)
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.date_NYUHEN_DATE, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.cob_JIMUITAKU_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_JIMUITAKU_CD, 0)
        Me.Controls.SetChildIndex(Me.lbl_HasuSeigen, 0)
        Me.Controls.SetChildIndex(Me.cob_KEIYAKU_JYOKYO_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_KEIYAKU_JYOKYO, 0)
        Me.Controls.SetChildIndex(Me.Label70, 0)
        Me.Controls.SetChildIndex(Me.txt_KEIYAKUSYA_NAME, 0)
        Me.Controls.SetChildIndex(Me.txt_KEIYAKUSYA_KANA, 0)
        Me.Controls.SetChildIndex(Me.Label69, 0)
        Me.Controls.SetChildIndex(Me.txt_DAIHYO_NAME, 0)
        Me.Controls.SetChildIndex(Me.Label68, 0)
        Me.Controls.SetChildIndex(Me.Label67, 0)
        Me.Controls.SetChildIndex(Me.Label66, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_TEL1, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_FAX, 0)
        Me.Controls.SetChildIndex(Me.Label65, 0)
        Me.Controls.SetChildIndex(Me.Label64, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_TEL2, 0)
        Me.Controls.SetChildIndex(Me.Label63, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_E_MAIL, 0)
        Me.Controls.SetChildIndex(Me.lbl_KI, 0)
        Me.Controls.SetChildIndex(Me.msk_ADDR_POST, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_1, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_2, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_3, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_4, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.txt_BIKO, 0)
        Me.Controls.SetChildIndex(Me.txt_SEISANSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txt_NIKKEIKYO_CD, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.txt_FURI_KOZA_MEIGI, 0)
        Me.Controls.SetChildIndex(Me.date_HAIGYO_DATE, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.date_KEIYAKU_DATE, 0)
        Me.pnlButton.ResumeLayout(False)
        Me.pnlButton.PerformLayout()
        CType(Me.txt_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKU_KBN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKU_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_FURI_BANK_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_FURI_BANK_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_FURI_BANK_SITEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_FURI_BANK_SITEN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_FURI_KOZA_SYUBETU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_FURI_KOZA_SYUBETU_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FURI_KOZA_NO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FURI_KOZA_MEIGI_KANA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FURI_KOZA_MEIGI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Now, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_NYUHEN_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_BIKO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.cob_JIMUITAKU_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_JIMUITAKU_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_E_MAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_TEL2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_FAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_TEL1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_DAIHYO_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KEIYAKUSYA_KANA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.msk_ADDR_POST, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cob_KEIYAKU_JYOKYO_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKU_JYOKYO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SEISANSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_NIKKEIKYO_CD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.date_HAIGYO_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_KEIYAKU_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KEIYAKUSYA_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KEN_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEN_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label20 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KEIYAKU_KBN As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEIYAKU_KBN_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents Label21 As JBD.Gjs.Win.Label
    Friend WithEvents Label22 As JBD.Gjs.Win.Label
    Friend WithEvents Label23 As JBD.Gjs.Win.Label
    Friend WithEvents cob_FURI_BANK_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_FURI_BANK_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton8 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cob_FURI_BANK_SITEN_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_FURI_BANK_SITEN_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton9 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cob_FURI_KOZA_SYUBETU As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_FURI_KOZA_SYUBETU_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton10 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label25 As JBD.Gjs.Win.Label
    Friend WithEvents txt_FURI_KOZA_NO As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_FURI_KOZA_MEIGI_KANA As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_FURI_KOZA_MEIGI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents lblTotal As JBD.Gjs.Win.Label
    Friend WithEvents Label26 As JBD.Gjs.Win.Label
    Friend WithEvents txt_Now As JBD.Gjs.Win.GcTextBox
    Friend WithEvents cmdLast As JBD.Gjs.Win.JButton
    Friend WithEvents cmdNext As JBD.Gjs.Win.JButton
    Friend WithEvents cmdBef As JBD.Gjs.Win.JButton
    Friend WithEvents cmdTop As JBD.Gjs.Win.JButton
    Friend WithEvents cmdSave As JBD.Gjs.Win.JButton
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents GcDateValidator1 As GrapeCity.Win.Editors.GcDateValidator
    Friend WithEvents date_NYUHEN_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton13 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label30 As JBD.Gjs.Win.Label
    Friend WithEvents DropDownButton14 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton15 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton16 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton17 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton18 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton19 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents txt_BIKO As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents GroupBox4 As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtn_BANK_NASI As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_BANK_ARI As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents cob_JIMUITAKU_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_JIMUITAKU_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton21 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents txt_ADDR_E_MAIL As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label63 As JBD.Gjs.Win.Label
    Friend WithEvents txt_ADDR_TEL2 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label64 As JBD.Gjs.Win.Label
    Friend WithEvents Label65 As JBD.Gjs.Win.Label
    Friend WithEvents txt_ADDR_FAX As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_ADDR_TEL1 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label66 As JBD.Gjs.Win.Label
    Friend WithEvents Label67 As JBD.Gjs.Win.Label
    Friend WithEvents Label68 As JBD.Gjs.Win.Label
    Friend WithEvents txt_DAIHYO_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label69 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KEIYAKUSYA_KANA As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_KEIYAKUSYA_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label70 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_KI As JBD.Gjs.Win.JLabel
    Friend WithEvents txt_ADDR_4 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_ADDR_3 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_ADDR_2 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_ADDR_1 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents msk_ADDR_POST As JBD.Gjs.Win.GcMask
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents GroupBox1 As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtn_NYURYOKU_JYOKYO2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_NYURYOKU_JYOKYO1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents lbl_HasuSeigen As JBD.Gjs.Win.Label
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cob_KEIYAKU_JYOKYO_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEIYAKU_JYOKYO As JBD.Gjs.Win.GcComboBox
    Friend WithEvents txt_SEISANSYA_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents txt_NIKKEIKYO_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label32 As JBD.Gjs.Win.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents date_HAIGYO_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents date_KEIYAKU_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton6 As GrapeCity.Win.Editors.DropDownButton
End Class
