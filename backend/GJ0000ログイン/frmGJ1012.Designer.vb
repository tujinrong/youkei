Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ1012
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.num_KEIYAKU_HASU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_HASU01 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_HASU02 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_HASU04 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_HASU03 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_HASU05 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_HASU00 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_HASU11 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_HASU10 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_HASU09 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_HASU08 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_HASU07 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_HASU06 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.Label30 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_Biko = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.DropDownButton14 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton15 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton16 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton17 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton18 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton19 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.MEISAI_NO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEQNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOJO_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOJO_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TORI_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TORI_KBN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_HASU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BIKO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_DATE_FROM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_DATE_TO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_POST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdDel = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdUpd = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdIns = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label23 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label26 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label29 = New JBD.Gjs.Win.Label(Me.components)
        Me.date_KEIYAKU_DATE_FROM = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label28 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdCansel = New JBD.Gjs.Win.JButton(Me.components)
        Me.lbl_KEIYAKUSYA_CD = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKUSYA_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_MEISAI_NO = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_POST = New JBD.Gjs.Win.JLabel(Me.components)
        Me.cob_NOJO_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_NOJO_nm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.lbl_ADDR_1 = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_2 = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_4 = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_3 = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_TORI_KBN = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_TORI_KBN_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cmd_NOJO_INS = New JBD.Gjs.Win.JButton(Me.components)
        Me.date_KEIYAKU_DATE_TO = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label20 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label22 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_SEQNO = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdCopy = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label25 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_KENSU = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label27 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label32 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label33 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label34 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label35 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label36 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label21 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.num_KEIYAKU_HASU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_HASU01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_HASU02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_HASU04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_HASU03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_HASU05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_HASU00, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_HASU11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_HASU10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_HASU09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_HASU08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_HASU07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_HASU06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Biko, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_KEIYAKU_DATE_FROM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_NOJO_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_NOJO_nm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_TORI_KBN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_TORI_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_KEIYAKU_DATE_TO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdCopy)
        Me.pnlButton.Controls.Add(Me.cmdCansel)
        Me.pnlButton.Controls.Add(Me.cmdSave)
        Me.pnlButton.TabIndex = 101
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSave, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCansel, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCopy, 0)
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
        Me.cmdEnd.Location = New System.Drawing.Point(989, 3)
        Me.cmdEnd.TabIndex = 2
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(191, 3)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 44)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Text = "保存"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'num_KEIYAKU_HASU
        '
        Me.num_KEIYAKU_HASU.DropDown.AllowDrop = False
        Me.num_KEIYAKU_HASU.Fields.DecimalPart.MaxDigits = 0
        Me.num_KEIYAKU_HASU.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KEIYAKU_HASU.Fields.IntegerPart.MaxDigits = 8
        Me.num_KEIYAKU_HASU.Fields.IntegerPart.MinDigits = 1
        Me.num_KEIYAKU_HASU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KEIYAKU_HASU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KEIYAKU_HASU.HighlightText = True
        Me.num_KEIYAKU_HASU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KEIYAKU_HASU.InputCheck = True
        Me.num_KEIYAKU_HASU.Location = New System.Drawing.Point(199, 653)
        Me.num_KEIYAKU_HASU.Name = "num_KEIYAKU_HASU"
        Me.num_KEIYAKU_HASU.NegativeColor = System.Drawing.Color.Black
        Me.GcShortcut1.SetShortcuts(Me.num_KEIYAKU_HASU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KEIYAKU_HASU, Object), CType(Me.num_KEIYAKU_HASU, Object), CType(Me.num_KEIYAKU_HASU, Object), CType(Me.num_KEIYAKU_HASU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KEIYAKU_HASU.Size = New System.Drawing.Size(85, 22)
        Me.num_KEIYAKU_HASU.Spin.Increment = 0
        Me.num_KEIYAKU_HASU.TabIndex = 23
        Me.num_KEIYAKU_HASU.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_KEIYAKU_HASU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_HASU01
        '
        Me.num_HASU01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_HASU01.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_HASU01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_HASU01.DropDown.AllowDrop = False
        Me.num_HASU01.Enabled = False
        Me.num_HASU01.Fields.DecimalPart.MaxDigits = 0
        Me.num_HASU01.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_HASU01.Fields.IntegerPart.MaxDigits = 8
        Me.num_HASU01.Fields.IntegerPart.MinDigits = 1
        Me.num_HASU01.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_HASU01.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_HASU01.HighlightText = True
        Me.num_HASU01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_HASU01.Location = New System.Drawing.Point(214, 349)
        Me.num_HASU01.Name = "num_HASU01"
        Me.num_HASU01.NegativeColor = System.Drawing.Color.Black
        Me.num_HASU01.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_HASU01, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_HASU01, Object), CType(Me.num_HASU01, Object), CType(Me.num_HASU01, Object), CType(Me.num_HASU01, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_HASU01.Size = New System.Drawing.Size(124, 22)
        Me.num_HASU01.Spin.Increment = 0
        Me.num_HASU01.TabIndex = 1086
        Me.num_HASU01.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_HASU01.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_HASU02
        '
        Me.num_HASU02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_HASU02.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_HASU02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_HASU02.DropDown.AllowDrop = False
        Me.num_HASU02.Enabled = False
        Me.num_HASU02.Fields.DecimalPart.MaxDigits = 0
        Me.num_HASU02.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_HASU02.Fields.IntegerPart.MaxDigits = 8
        Me.num_HASU02.Fields.IntegerPart.MinDigits = 1
        Me.num_HASU02.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_HASU02.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_HASU02.HighlightText = True
        Me.num_HASU02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_HASU02.Location = New System.Drawing.Point(337, 349)
        Me.num_HASU02.Name = "num_HASU02"
        Me.num_HASU02.NegativeColor = System.Drawing.Color.Black
        Me.num_HASU02.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_HASU02, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_HASU02, Object), CType(Me.num_HASU02, Object), CType(Me.num_HASU02, Object), CType(Me.num_HASU02, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_HASU02.Size = New System.Drawing.Size(124, 22)
        Me.num_HASU02.Spin.Increment = 0
        Me.num_HASU02.TabIndex = 1088
        Me.num_HASU02.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_HASU02.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_HASU04
        '
        Me.num_HASU04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_HASU04.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_HASU04.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_HASU04.DropDown.AllowDrop = False
        Me.num_HASU04.Enabled = False
        Me.num_HASU04.Fields.DecimalPart.MaxDigits = 0
        Me.num_HASU04.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_HASU04.Fields.IntegerPart.MaxDigits = 8
        Me.num_HASU04.Fields.IntegerPart.MinDigits = 1
        Me.num_HASU04.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_HASU04.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_HASU04.HighlightText = True
        Me.num_HASU04.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_HASU04.Location = New System.Drawing.Point(582, 349)
        Me.num_HASU04.Name = "num_HASU04"
        Me.num_HASU04.NegativeColor = System.Drawing.Color.Black
        Me.num_HASU04.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_HASU04, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_HASU04, Object), CType(Me.num_HASU04, Object), CType(Me.num_HASU04, Object), CType(Me.num_HASU04, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_HASU04.Size = New System.Drawing.Size(124, 22)
        Me.num_HASU04.Spin.Increment = 0
        Me.num_HASU04.TabIndex = 1092
        Me.num_HASU04.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_HASU04.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_HASU03
        '
        Me.num_HASU03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_HASU03.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_HASU03.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_HASU03.DropDown.AllowDrop = False
        Me.num_HASU03.Enabled = False
        Me.num_HASU03.Fields.DecimalPart.MaxDigits = 0
        Me.num_HASU03.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_HASU03.Fields.IntegerPart.MaxDigits = 8
        Me.num_HASU03.Fields.IntegerPart.MinDigits = 1
        Me.num_HASU03.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_HASU03.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_HASU03.HighlightText = True
        Me.num_HASU03.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_HASU03.Location = New System.Drawing.Point(459, 349)
        Me.num_HASU03.Name = "num_HASU03"
        Me.num_HASU03.NegativeColor = System.Drawing.Color.Black
        Me.num_HASU03.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_HASU03, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_HASU03, Object), CType(Me.num_HASU03, Object), CType(Me.num_HASU03, Object), CType(Me.num_HASU03, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_HASU03.Size = New System.Drawing.Size(124, 22)
        Me.num_HASU03.Spin.Increment = 0
        Me.num_HASU03.TabIndex = 1090
        Me.num_HASU03.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_HASU03.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_HASU05
        '
        Me.num_HASU05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_HASU05.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_HASU05.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_HASU05.DropDown.AllowDrop = False
        Me.num_HASU05.Enabled = False
        Me.num_HASU05.Fields.DecimalPart.MaxDigits = 0
        Me.num_HASU05.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_HASU05.Fields.IntegerPart.MaxDigits = 8
        Me.num_HASU05.Fields.IntegerPart.MinDigits = 1
        Me.num_HASU05.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_HASU05.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_HASU05.HighlightText = True
        Me.num_HASU05.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_HASU05.Location = New System.Drawing.Point(705, 349)
        Me.num_HASU05.Name = "num_HASU05"
        Me.num_HASU05.NegativeColor = System.Drawing.Color.Black
        Me.num_HASU05.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_HASU05, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_HASU05, Object), CType(Me.num_HASU05, Object), CType(Me.num_HASU05, Object), CType(Me.num_HASU05, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_HASU05.Size = New System.Drawing.Size(124, 22)
        Me.num_HASU05.Spin.Increment = 0
        Me.num_HASU05.TabIndex = 1094
        Me.num_HASU05.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_HASU05.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_HASU00
        '
        Me.num_HASU00.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_HASU00.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_HASU00.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_HASU00.DropDown.AllowDrop = False
        Me.num_HASU00.Enabled = False
        Me.num_HASU00.Fields.DecimalPart.MaxDigits = 0
        Me.num_HASU00.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_HASU00.Fields.IntegerPart.MaxDigits = 8
        Me.num_HASU00.Fields.IntegerPart.MinDigits = 1
        Me.num_HASU00.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_HASU00.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_HASU00.HighlightText = True
        Me.num_HASU00.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_HASU00.Location = New System.Drawing.Point(828, 394)
        Me.num_HASU00.Name = "num_HASU00"
        Me.num_HASU00.NegativeColor = System.Drawing.Color.Black
        Me.num_HASU00.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_HASU00, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_HASU00, Object), CType(Me.num_HASU00, Object), CType(Me.num_HASU00, Object), CType(Me.num_HASU00, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_HASU00.Size = New System.Drawing.Size(124, 22)
        Me.num_HASU00.Spin.Increment = 0
        Me.num_HASU00.TabIndex = 1098
        Me.num_HASU00.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_HASU00.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_HASU11
        '
        Me.num_HASU11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_HASU11.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_HASU11.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_HASU11.DropDown.AllowDrop = False
        Me.num_HASU11.Enabled = False
        Me.num_HASU11.Fields.DecimalPart.MaxDigits = 0
        Me.num_HASU11.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_HASU11.Fields.IntegerPart.MaxDigits = 8
        Me.num_HASU11.Fields.IntegerPart.MinDigits = 1
        Me.num_HASU11.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_HASU11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_HASU11.HighlightText = True
        Me.num_HASU11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_HASU11.Location = New System.Drawing.Point(705, 394)
        Me.num_HASU11.Name = "num_HASU11"
        Me.num_HASU11.NegativeColor = System.Drawing.Color.Black
        Me.num_HASU11.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_HASU11, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_HASU11, Object), CType(Me.num_HASU11, Object), CType(Me.num_HASU11, Object), CType(Me.num_HASU11, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_HASU11.Size = New System.Drawing.Size(124, 22)
        Me.num_HASU11.Spin.Increment = 0
        Me.num_HASU11.TabIndex = 1117
        Me.num_HASU11.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_HASU11.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_HASU10
        '
        Me.num_HASU10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_HASU10.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_HASU10.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_HASU10.DropDown.AllowDrop = False
        Me.num_HASU10.Enabled = False
        Me.num_HASU10.Fields.DecimalPart.MaxDigits = 0
        Me.num_HASU10.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_HASU10.Fields.IntegerPart.MaxDigits = 8
        Me.num_HASU10.Fields.IntegerPart.MinDigits = 1
        Me.num_HASU10.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_HASU10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_HASU10.HighlightText = True
        Me.num_HASU10.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_HASU10.Location = New System.Drawing.Point(582, 394)
        Me.num_HASU10.Name = "num_HASU10"
        Me.num_HASU10.NegativeColor = System.Drawing.Color.Black
        Me.num_HASU10.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_HASU10, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_HASU10, Object), CType(Me.num_HASU10, Object), CType(Me.num_HASU10, Object), CType(Me.num_HASU10, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_HASU10.Size = New System.Drawing.Size(124, 22)
        Me.num_HASU10.Spin.Increment = 0
        Me.num_HASU10.TabIndex = 1115
        Me.num_HASU10.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_HASU10.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_HASU09
        '
        Me.num_HASU09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_HASU09.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_HASU09.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_HASU09.DropDown.AllowDrop = False
        Me.num_HASU09.Enabled = False
        Me.num_HASU09.Fields.DecimalPart.MaxDigits = 0
        Me.num_HASU09.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_HASU09.Fields.IntegerPart.MaxDigits = 8
        Me.num_HASU09.Fields.IntegerPart.MinDigits = 1
        Me.num_HASU09.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_HASU09.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_HASU09.HighlightText = True
        Me.num_HASU09.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_HASU09.Location = New System.Drawing.Point(459, 394)
        Me.num_HASU09.Name = "num_HASU09"
        Me.num_HASU09.NegativeColor = System.Drawing.Color.Black
        Me.num_HASU09.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_HASU09, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_HASU09, Object), CType(Me.num_HASU09, Object), CType(Me.num_HASU09, Object), CType(Me.num_HASU09, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_HASU09.Size = New System.Drawing.Size(124, 22)
        Me.num_HASU09.Spin.Increment = 0
        Me.num_HASU09.TabIndex = 1113
        Me.num_HASU09.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_HASU09.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_HASU08
        '
        Me.num_HASU08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_HASU08.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_HASU08.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_HASU08.DropDown.AllowDrop = False
        Me.num_HASU08.Enabled = False
        Me.num_HASU08.Fields.DecimalPart.MaxDigits = 0
        Me.num_HASU08.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_HASU08.Fields.IntegerPart.MaxDigits = 8
        Me.num_HASU08.Fields.IntegerPart.MinDigits = 1
        Me.num_HASU08.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_HASU08.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_HASU08.HighlightText = True
        Me.num_HASU08.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_HASU08.Location = New System.Drawing.Point(337, 394)
        Me.num_HASU08.Name = "num_HASU08"
        Me.num_HASU08.NegativeColor = System.Drawing.Color.Black
        Me.num_HASU08.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_HASU08, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_HASU08, Object), CType(Me.num_HASU08, Object), CType(Me.num_HASU08, Object), CType(Me.num_HASU08, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_HASU08.Size = New System.Drawing.Size(124, 22)
        Me.num_HASU08.Spin.Increment = 0
        Me.num_HASU08.TabIndex = 1111
        Me.num_HASU08.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_HASU08.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_HASU07
        '
        Me.num_HASU07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_HASU07.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_HASU07.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_HASU07.DropDown.AllowDrop = False
        Me.num_HASU07.Enabled = False
        Me.num_HASU07.Fields.DecimalPart.MaxDigits = 0
        Me.num_HASU07.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_HASU07.Fields.IntegerPart.MaxDigits = 8
        Me.num_HASU07.Fields.IntegerPart.MinDigits = 1
        Me.num_HASU07.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_HASU07.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_HASU07.HighlightText = True
        Me.num_HASU07.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_HASU07.Location = New System.Drawing.Point(214, 394)
        Me.num_HASU07.Name = "num_HASU07"
        Me.num_HASU07.NegativeColor = System.Drawing.Color.Black
        Me.num_HASU07.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_HASU07, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_HASU07, Object), CType(Me.num_HASU07, Object), CType(Me.num_HASU07, Object), CType(Me.num_HASU07, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_HASU07.Size = New System.Drawing.Size(124, 22)
        Me.num_HASU07.Spin.Increment = 0
        Me.num_HASU07.TabIndex = 1109
        Me.num_HASU07.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_HASU07.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_HASU06
        '
        Me.num_HASU06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_HASU06.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_HASU06.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_HASU06.DropDown.AllowDrop = False
        Me.num_HASU06.Enabled = False
        Me.num_HASU06.Fields.DecimalPart.MaxDigits = 0
        Me.num_HASU06.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_HASU06.Fields.IntegerPart.MaxDigits = 8
        Me.num_HASU06.Fields.IntegerPart.MinDigits = 1
        Me.num_HASU06.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_HASU06.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_HASU06.HighlightText = True
        Me.num_HASU06.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_HASU06.Location = New System.Drawing.Point(91, 394)
        Me.num_HASU06.Name = "num_HASU06"
        Me.num_HASU06.NegativeColor = System.Drawing.Color.Black
        Me.num_HASU06.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_HASU06, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_HASU06, Object), CType(Me.num_HASU06, Object), CType(Me.num_HASU06, Object), CType(Me.num_HASU06, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_HASU06.Size = New System.Drawing.Size(124, 22)
        Me.num_HASU06.Spin.Increment = 0
        Me.num_HASU06.TabIndex = 1096
        Me.num_HASU06.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_HASU06.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(70, 714)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(52, 15)
        Me.Label30.TabIndex = 67
        Me.Label30.Text = "□備考"
        '
        'txt_Biko
        '
        Me.txt_Biko.DropDown.AllowDrop = False
        Me.txt_Biko.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_Biko.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_Biko.Format = "Ｚ"
        Me.txt_Biko.HighlightText = True
        Me.txt_Biko.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_Biko.Location = New System.Drawing.Point(199, 711)
        Me.txt_Biko.MaxLength = 80
        Me.txt_Biko.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_Biko.Name = "txt_Biko"
        Me.txt_Biko.Size = New System.Drawing.Size(618, 20)
        Me.txt_Biko.TabIndex = 26
        Me.txt_Biko.Text = "ＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺ"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(70, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "契約者"
        '
        'dgv_Search
        '
        Me.dgv_Search.AllowUserToAddRows = False
        Me.dgv_Search.AllowUserToDeleteRows = False
        Me.dgv_Search.AllowUserToResizeRows = False
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MEISAI_NO, Me.SEQNO, Me.NOJO_CD, Me.NOJO_NM, Me.ADDR, Me.TORI_KBN, Me.TORI_KBN_NM, Me.KEIYAKU_HASU, Me.BIKO, Me.KEIYAKU_DATE_FROM, Me.KEIYAKU_DATE_TO, Me.ADDR_POST, Me.ADDR_1, Me.ADDR_2, Me.ADDR_3, Me.ADDR_4})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(13, 137)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(1069, 172)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 0
        '
        'MEISAI_NO
        '
        Me.MEISAI_NO.DataPropertyName = "MEISAI_NO"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEISAI_NO.DefaultCellStyle = DataGridViewCellStyle1
        Me.MEISAI_NO.Frozen = True
        Me.MEISAI_NO.HeaderText = "明細番号"
        Me.MEISAI_NO.Name = "MEISAI_NO"
        Me.MEISAI_NO.ReadOnly = True
        Me.MEISAI_NO.Width = 80
        '
        'SEQNO
        '
        Me.SEQNO.DataPropertyName = "SEQNO"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.SEQNO.DefaultCellStyle = DataGridViewCellStyle2
        Me.SEQNO.Frozen = True
        Me.SEQNO.HeaderText = "SEQNO"
        Me.SEQNO.Name = "SEQNO"
        Me.SEQNO.ReadOnly = True
        Me.SEQNO.Visible = False
        '
        'NOJO_CD
        '
        Me.NOJO_CD.DataPropertyName = "NOJO_CD"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.NOJO_CD.DefaultCellStyle = DataGridViewCellStyle3
        Me.NOJO_CD.Frozen = True
        Me.NOJO_CD.HeaderText = "農場コード"
        Me.NOJO_CD.Name = "NOJO_CD"
        Me.NOJO_CD.ReadOnly = True
        Me.NOJO_CD.Visible = False
        '
        'NOJO_NM
        '
        Me.NOJO_NM.DataPropertyName = "NOJO_NM"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NOJO_NM.DefaultCellStyle = DataGridViewCellStyle4
        Me.NOJO_NM.Frozen = True
        Me.NOJO_NM.HeaderText = "農場名"
        Me.NOJO_NM.Name = "NOJO_NM"
        Me.NOJO_NM.ReadOnly = True
        Me.NOJO_NM.Width = 270
        '
        'ADDR
        '
        Me.ADDR.DataPropertyName = "ADDR"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR.DefaultCellStyle = DataGridViewCellStyle5
        Me.ADDR.Frozen = True
        Me.ADDR.HeaderText = "農場住所"
        Me.ADDR.Name = "ADDR"
        Me.ADDR.ReadOnly = True
        Me.ADDR.Width = 320
        '
        'TORI_KBN
        '
        Me.TORI_KBN.DataPropertyName = "TORI_KBN"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.TORI_KBN.DefaultCellStyle = DataGridViewCellStyle6
        Me.TORI_KBN.Frozen = True
        Me.TORI_KBN.HeaderText = "鳥の種類コード"
        Me.TORI_KBN.Name = "TORI_KBN"
        Me.TORI_KBN.ReadOnly = True
        Me.TORI_KBN.Visible = False
        Me.TORI_KBN.Width = 20
        '
        'TORI_KBN_NM
        '
        Me.TORI_KBN_NM.DataPropertyName = "TORI_KBN_NM"
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.TORI_KBN_NM.DefaultCellStyle = DataGridViewCellStyle7
        Me.TORI_KBN_NM.Frozen = True
        Me.TORI_KBN_NM.HeaderText = "鳥の種類"
        Me.TORI_KBN_NM.Name = "TORI_KBN_NM"
        Me.TORI_KBN_NM.ReadOnly = True
        Me.TORI_KBN_NM.Width = 90
        '
        'KEIYAKU_HASU
        '
        Me.KEIYAKU_HASU.DataPropertyName = "KEIYAKU_HASU"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.KEIYAKU_HASU.DefaultCellStyle = DataGridViewCellStyle8
        Me.KEIYAKU_HASU.Frozen = True
        Me.KEIYAKU_HASU.HeaderText = "契約羽数"
        Me.KEIYAKU_HASU.Name = "KEIYAKU_HASU"
        Me.KEIYAKU_HASU.ReadOnly = True
        Me.KEIYAKU_HASU.Width = 90
        '
        'BIKO
        '
        Me.BIKO.DataPropertyName = "BIKO"
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.BIKO.DefaultCellStyle = DataGridViewCellStyle9
        Me.BIKO.Frozen = True
        Me.BIKO.HeaderText = "備考"
        Me.BIKO.Name = "BIKO"
        Me.BIKO.ReadOnly = True
        Me.BIKO.Width = 200
        '
        'KEIYAKU_DATE_FROM
        '
        Me.KEIYAKU_DATE_FROM.DataPropertyName = "KEIYAKU_DATE_FROM"
        DataGridViewCellStyle10.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKU_DATE_FROM.DefaultCellStyle = DataGridViewCellStyle10
        Me.KEIYAKU_DATE_FROM.Frozen = True
        Me.KEIYAKU_DATE_FROM.HeaderText = "契約開始日"
        Me.KEIYAKU_DATE_FROM.Name = "KEIYAKU_DATE_FROM"
        Me.KEIYAKU_DATE_FROM.ReadOnly = True
        Me.KEIYAKU_DATE_FROM.Visible = False
        '
        'KEIYAKU_DATE_TO
        '
        Me.KEIYAKU_DATE_TO.DataPropertyName = "KEIYAKU_DATE_TO"
        DataGridViewCellStyle11.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKU_DATE_TO.DefaultCellStyle = DataGridViewCellStyle11
        Me.KEIYAKU_DATE_TO.Frozen = True
        Me.KEIYAKU_DATE_TO.HeaderText = "契約終了日"
        Me.KEIYAKU_DATE_TO.Name = "KEIYAKU_DATE_TO"
        Me.KEIYAKU_DATE_TO.ReadOnly = True
        Me.KEIYAKU_DATE_TO.Visible = False
        '
        'ADDR_POST
        '
        Me.ADDR_POST.DataPropertyName = "ADDR_POST"
        Me.ADDR_POST.Frozen = True
        Me.ADDR_POST.HeaderText = "郵便番号"
        Me.ADDR_POST.Name = "ADDR_POST"
        Me.ADDR_POST.ReadOnly = True
        Me.ADDR_POST.Visible = False
        '
        'ADDR_1
        '
        Me.ADDR_1.DataPropertyName = "ADDR_1"
        DataGridViewCellStyle12.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_1.DefaultCellStyle = DataGridViewCellStyle12
        Me.ADDR_1.Frozen = True
        Me.ADDR_1.HeaderText = "住所1"
        Me.ADDR_1.Name = "ADDR_1"
        Me.ADDR_1.ReadOnly = True
        Me.ADDR_1.Visible = False
        '
        'ADDR_2
        '
        Me.ADDR_2.DataPropertyName = "ADDR_2"
        DataGridViewCellStyle13.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_2.DefaultCellStyle = DataGridViewCellStyle13
        Me.ADDR_2.Frozen = True
        Me.ADDR_2.HeaderText = "住所2"
        Me.ADDR_2.Name = "ADDR_2"
        Me.ADDR_2.ReadOnly = True
        Me.ADDR_2.Visible = False
        '
        'ADDR_3
        '
        Me.ADDR_3.DataPropertyName = "ADDR_3"
        DataGridViewCellStyle14.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_3.DefaultCellStyle = DataGridViewCellStyle14
        Me.ADDR_3.Frozen = True
        Me.ADDR_3.HeaderText = "住所3"
        Me.ADDR_3.Name = "ADDR_3"
        Me.ADDR_3.ReadOnly = True
        Me.ADDR_3.Visible = False
        '
        'ADDR_4
        '
        Me.ADDR_4.DataPropertyName = "ADDR_4"
        DataGridViewCellStyle15.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_4.DefaultCellStyle = DataGridViewCellStyle15
        Me.ADDR_4.Frozen = True
        Me.ADDR_4.HeaderText = "住所4"
        Me.ADDR_4.Name = "ADDR_4"
        Me.ADDR_4.ReadOnly = True
        Me.ADDR_4.Visible = False
        '
        'cmdDel
        '
        Me.cmdDel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDel.Location = New System.Drawing.Point(876, 426)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(92, 44)
        Me.cmdDel.TabIndex = 3
        Me.cmdDel.Text = "削除"
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdUpd
        '
        Me.cmdUpd.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdUpd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUpd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdUpd.Location = New System.Drawing.Point(256, 426)
        Me.cmdUpd.Name = "cmdUpd"
        Me.cmdUpd.Size = New System.Drawing.Size(92, 44)
        Me.cmdUpd.TabIndex = 2
        Me.cmdUpd.Text = "変更(表示)"
        Me.cmdUpd.UseVisualStyleBackColor = True
        '
        'cmdIns
        '
        Me.cmdIns.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdIns.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdIns.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIns.Location = New System.Drawing.Point(149, 426)
        Me.cmdIns.Name = "cmdIns"
        Me.cmdIns.Size = New System.Drawing.Size(92, 44)
        Me.cmdIns.TabIndex = 1
        Me.cmdIns.Text = "新規登録"
        Me.cmdIns.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(70, 513)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 15)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "明細番号"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(70, 541)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 15)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "■農場"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(70, 572)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 15)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "   住所"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(70, 656)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(82, 15)
        Me.Label23.TabIndex = 52
        Me.Label23.Text = "■契約羽数"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(70, 628)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(82, 15)
        Me.Label26.TabIndex = 58
        Me.Label26.Text = "■鶏の種類"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label29.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(330, 685)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(22, 15)
        Me.Label29.TabIndex = 65
        Me.Label29.Text = "～"
        '
        'date_KEIYAKU_DATE_FROM
        '
        Me.date_KEIYAKU_DATE_FROM.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.date_KEIYAKU_DATE_FROM.DefaultActiveField = DateEraYearField1
        DateEraYearDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField2.Text = "/"
        DateMonthDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField3.Text = "/"
        DateDayDisplayField1.ShowLeadingZero = True
        Me.date_KEIYAKU_DATE_FROM.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField1, DateLiteralDisplayField1, DateEraYearDisplayField1, DateLiteralDisplayField2, DateMonthDisplayField1, DateLiteralDisplayField3, DateDayDisplayField1})
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.date_KEIYAKU_DATE_FROM.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.date_KEIYAKU_DATE_FROM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_KEIYAKU_DATE_FROM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_KEIYAKU_DATE_FROM.InputCheck = True
        Me.date_KEIYAKU_DATE_FROM.Location = New System.Drawing.Point(199, 682)
        Me.date_KEIYAKU_DATE_FROM.Name = "date_KEIYAKU_DATE_FROM"
        Me.date_KEIYAKU_DATE_FROM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.date_KEIYAKU_DATE_FROM.Size = New System.Drawing.Size(125, 21)
        Me.date_KEIYAKU_DATE_FROM.Spin.AllowSpin = False
        Me.date_KEIYAKU_DATE_FROM.TabIndex = 24
        Me.date_KEIYAKU_DATE_FROM.Value = New Date(2010, 8, 28, 11, 12, 38, 0)
        '
        'DropDownButton3
        '
        Me.DropDownButton3.Name = "DropDownButton3"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(70, 682)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(97, 15)
        Me.Label28.TabIndex = 63
        Me.Label28.Text = "■契約年月日"
        '
        'cmdCansel
        '
        Me.cmdCansel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCansel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCansel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCansel.Location = New System.Drawing.Point(298, 3)
        Me.cmdCansel.Name = "cmdCansel"
        Me.cmdCansel.Size = New System.Drawing.Size(92, 44)
        Me.cmdCansel.TabIndex = 1
        Me.cmdCansel.Text = "キャンセル"
        Me.cmdCansel.UseVisualStyleBackColor = True
        '
        'lbl_KEIYAKUSYA_CD
        '
        Me.lbl_KEIYAKUSYA_CD.AutoSize = True
        Me.lbl_KEIYAKUSYA_CD.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKUSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKUSYA_CD.Location = New System.Drawing.Point(134, 109)
        Me.lbl_KEIYAKUSYA_CD.Name = "lbl_KEIYAKUSYA_CD"
        Me.lbl_KEIYAKUSYA_CD.Size = New System.Drawing.Size(47, 15)
        Me.lbl_KEIYAKUSYA_CD.TabIndex = 1059
        Me.lbl_KEIYAKUSYA_CD.Text = "99999"
        '
        'lbl_KEIYAKUSYA_NM
        '
        Me.lbl_KEIYAKUSYA_NM.AutoSize = True
        Me.lbl_KEIYAKUSYA_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKUSYA_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKUSYA_NM.Location = New System.Drawing.Point(199, 109)
        Me.lbl_KEIYAKUSYA_NM.Name = "lbl_KEIYAKUSYA_NM"
        Me.lbl_KEIYAKUSYA_NM.Size = New System.Drawing.Size(157, 15)
        Me.lbl_KEIYAKUSYA_NM.TabIndex = 1060
        Me.lbl_KEIYAKUSYA_NM.Text = "＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_KI
        '
        Me.lbl_KI.AutoSize = True
        Me.lbl_KI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KI.Location = New System.Drawing.Point(28, 54)
        Me.lbl_KI.Name = "lbl_KI"
        Me.lbl_KI.Size = New System.Drawing.Size(53, 15)
        Me.lbl_KI.TabIndex = 1061
        Me.lbl_KI.Text = "第99期"
        '
        'lbl_MEISAI_NO
        '
        Me.lbl_MEISAI_NO.AutoSize = True
        Me.lbl_MEISAI_NO.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_MEISAI_NO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_MEISAI_NO.Location = New System.Drawing.Point(199, 513)
        Me.lbl_MEISAI_NO.Name = "lbl_MEISAI_NO"
        Me.lbl_MEISAI_NO.Size = New System.Drawing.Size(31, 15)
        Me.lbl_MEISAI_NO.TabIndex = 1062
        Me.lbl_MEISAI_NO.Text = "999"
        '
        'lbl_ADDR_POST
        '
        Me.lbl_ADDR_POST.AutoSize = True
        Me.lbl_ADDR_POST.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_POST.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_POST.Location = New System.Drawing.Point(228, 572)
        Me.lbl_ADDR_POST.Name = "lbl_ADDR_POST"
        Me.lbl_ADDR_POST.Size = New System.Drawing.Size(71, 15)
        Me.lbl_ADDR_POST.TabIndex = 1063
        Me.lbl_ADDR_POST.Text = "999-9999"
        '
        'cob_NOJO_CD
        '
        Me.cob_NOJO_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_NOJO_CD.DropDown.AllowDrop = False
        Me.cob_NOJO_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_NOJO_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_NOJO_CD.Format = "9"
        Me.cob_NOJO_CD.HighlightText = True
        Me.cob_NOJO_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_NOJO_CD.InputCheck = True
        Me.cob_NOJO_CD.ListHeaderPane.Height = 22
        Me.cob_NOJO_CD.Location = New System.Drawing.Point(199, 538)
        Me.cob_NOJO_CD.MaxLength = 3
        Me.cob_NOJO_CD.Name = "cob_NOJO_CD"
        Me.cob_NOJO_CD.Size = New System.Drawing.Size(39, 22)
        Me.cob_NOJO_CD.Spin.AllowSpin = False
        Me.cob_NOJO_CD.TabIndex = 11
        Me.cob_NOJO_CD.Tag = "生産者番号"
        Me.cob_NOJO_CD.Text = "000"
        '
        'cob_NOJO_nm
        '
        Me.cob_NOJO_nm.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_NOJO_nm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_NOJO_nm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_NOJO_nm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_NOJO_nm.InputCheck = True
        Me.cob_NOJO_nm.ListHeaderPane.Height = 22
        Me.cob_NOJO_nm.ListHeaderPane.Visible = False
        Me.cob_NOJO_nm.Location = New System.Drawing.Point(242, 538)
        Me.cob_NOJO_nm.Name = "cob_NOJO_nm"
        Me.cob_NOJO_nm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.cob_NOJO_nm.Size = New System.Drawing.Size(494, 22)
        Me.cob_NOJO_nm.TabIndex = 12
        Me.cob_NOJO_nm.TabStop = False
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'lbl_ADDR_1
        '
        Me.lbl_ADDR_1.AccessibleDescription = ""
        Me.lbl_ADDR_1.AutoSize = True
        Me.lbl_ADDR_1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_1.Location = New System.Drawing.Point(364, 572)
        Me.lbl_ADDR_1.Name = "lbl_ADDR_1"
        Me.lbl_ADDR_1.Size = New System.Drawing.Size(67, 15)
        Me.lbl_ADDR_1.TabIndex = 1066
        Me.lbl_ADDR_1.Text = "＠＠＠＠"
        '
        'lbl_ADDR_2
        '
        Me.lbl_ADDR_2.AccessibleDescription = "v"
        Me.lbl_ADDR_2.AutoSize = True
        Me.lbl_ADDR_2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_2.Location = New System.Drawing.Point(494, 572)
        Me.lbl_ADDR_2.Name = "lbl_ADDR_2"
        Me.lbl_ADDR_2.Size = New System.Drawing.Size(232, 15)
        Me.lbl_ADDR_2.TabIndex = 1067
        Me.lbl_ADDR_2.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_ADDR_4
        '
        Me.lbl_ADDR_4.AutoSize = True
        Me.lbl_ADDR_4.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_4.Location = New System.Drawing.Point(656, 602)
        Me.lbl_ADDR_4.Name = "lbl_ADDR_4"
        Me.lbl_ADDR_4.Size = New System.Drawing.Size(307, 15)
        Me.lbl_ADDR_4.TabIndex = 1069
        Me.lbl_ADDR_4.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_ADDR_3
        '
        Me.lbl_ADDR_3.AutoSize = True
        Me.lbl_ADDR_3.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_3.Location = New System.Drawing.Point(361, 602)
        Me.lbl_ADDR_3.Name = "lbl_ADDR_3"
        Me.lbl_ADDR_3.Size = New System.Drawing.Size(232, 15)
        Me.lbl_ADDR_3.TabIndex = 1068
        Me.lbl_ADDR_3.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(199, 572)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 15)
        Me.Label3.TabIndex = 1070
        Me.Label3.Text = "〒"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(305, 572)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 1071
        Me.Label5.Text = "(住所１)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(434, 572)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 1072
        Me.Label6.Text = "(住所２)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(304, 602)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 15)
        Me.Label7.TabIndex = 1073
        Me.Label7.Text = "(住所3)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(596, 602)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 15)
        Me.Label8.TabIndex = 1074
        Me.Label8.Text = "(住所４)"
        '
        'cob_TORI_KBN
        '
        Me.cob_TORI_KBN.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_TORI_KBN.DropDown.AllowDrop = False
        Me.cob_TORI_KBN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_TORI_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_TORI_KBN.Format = "9"
        Me.cob_TORI_KBN.HighlightText = True
        Me.cob_TORI_KBN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_TORI_KBN.InputCheck = True
        Me.cob_TORI_KBN.ListHeaderPane.Height = 22
        Me.cob_TORI_KBN.Location = New System.Drawing.Point(199, 625)
        Me.cob_TORI_KBN.MaxLength = 2
        Me.cob_TORI_KBN.Name = "cob_TORI_KBN"
        Me.cob_TORI_KBN.Size = New System.Drawing.Size(23, 22)
        Me.cob_TORI_KBN.Spin.AllowSpin = False
        Me.cob_TORI_KBN.TabIndex = 21
        Me.cob_TORI_KBN.Text = "00"
        '
        'cob_TORI_KBN_NM
        '
        Me.cob_TORI_KBN_NM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_TORI_KBN_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_TORI_KBN_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_TORI_KBN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_TORI_KBN_NM.InputCheck = True
        Me.cob_TORI_KBN_NM.ListHeaderPane.Height = 22
        Me.cob_TORI_KBN_NM.ListHeaderPane.Visible = False
        Me.cob_TORI_KBN_NM.Location = New System.Drawing.Point(228, 625)
        Me.cob_TORI_KBN_NM.Name = "cob_TORI_KBN_NM"
        Me.cob_TORI_KBN_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton4})
        Me.cob_TORI_KBN_NM.Size = New System.Drawing.Size(119, 22)
        Me.cob_TORI_KBN_NM.TabIndex = 22
        Me.cob_TORI_KBN_NM.TabStop = False
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'cmd_NOJO_INS
        '
        Me.cmd_NOJO_INS.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmd_NOJO_INS.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmd_NOJO_INS.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmd_NOJO_INS.Location = New System.Drawing.Point(770, 526)
        Me.cmd_NOJO_INS.Name = "cmd_NOJO_INS"
        Me.cmd_NOJO_INS.Size = New System.Drawing.Size(92, 44)
        Me.cmd_NOJO_INS.TabIndex = 13
        Me.cmd_NOJO_INS.TabStop = False
        Me.cmd_NOJO_INS.Text = "農場登録"
        Me.cmd_NOJO_INS.UseVisualStyleBackColor = True
        '
        'date_KEIYAKU_DATE_TO
        '
        Me.date_KEIYAKU_DATE_TO.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.date_KEIYAKU_DATE_TO.DefaultActiveField = DateEraYearField2
        DateEraYearDisplayField2.ShowLeadingZero = True
        DateLiteralDisplayField5.Text = "/"
        DateMonthDisplayField2.ShowLeadingZero = True
        DateLiteralDisplayField6.Text = "/"
        DateDayDisplayField2.ShowLeadingZero = True
        Me.date_KEIYAKU_DATE_TO.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField2, DateLiteralDisplayField4, DateEraYearDisplayField2, DateLiteralDisplayField5, DateMonthDisplayField2, DateLiteralDisplayField6, DateDayDisplayField2})
        Me.date_KEIYAKU_DATE_TO.Enabled = False
        DateLiteralField5.Text = "/"
        DateLiteralField6.Text = "/"
        Me.date_KEIYAKU_DATE_TO.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateLiteralField4, DateEraYearField2, DateLiteralField5, DateMonthField2, DateLiteralField6, DateDayField2})
        Me.date_KEIYAKU_DATE_TO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_KEIYAKU_DATE_TO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_KEIYAKU_DATE_TO.Location = New System.Drawing.Point(348, 682)
        Me.date_KEIYAKU_DATE_TO.Name = "date_KEIYAKU_DATE_TO"
        Me.date_KEIYAKU_DATE_TO.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.date_KEIYAKU_DATE_TO.Size = New System.Drawing.Size(125, 21)
        Me.date_KEIYAKU_DATE_TO.Spin.AllowSpin = False
        Me.date_KEIYAKU_DATE_TO.TabIndex = 25
        Me.date_KEIYAKU_DATE_TO.Value = New Date(2010, 8, 28, 11, 12, 38, 0)
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Location = New System.Drawing.Point(26, 75)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(994, 25)
        Me.Panel2.TabIndex = 1076
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(29, 2)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(279, 19)
        Me.Label10.TabIndex = 1059
        Me.Label10.Text = "１．契約農場別明細情報（表示）"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(26, 480)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(994, 25)
        Me.Panel1.TabIndex = 1077
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(29, 2)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(319, 19)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "２．契約農場別登録明細情報（入力）"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(91, 325)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 26)
        Me.Label2.TabIndex = 1078
        Me.Label2.Text = "鶏の種類"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(91, 349)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 22)
        Me.Label9.TabIndex = 1079
        Me.Label9.Text = "契約羽数合計"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(214, 325)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 26)
        Me.Label16.TabIndex = 1084
        Me.Label16.Text = "採卵鶏(成鶏)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(337, 325)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 26)
        Me.Label15.TabIndex = 1087
        Me.Label15.Text = "採卵鶏(育成鶏)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(582, 325)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(124, 26)
        Me.Label19.TabIndex = 1091
        Me.Label19.Text = "種鶏(成鶏)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(459, 325)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(124, 26)
        Me.Label20.TabIndex = 1089
        Me.Label20.Text = "肉用鶏"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(705, 325)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(124, 26)
        Me.Label22.TabIndex = 1093
        Me.Label22.Text = "種鶏(育成鶏)"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(828, 370)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(124, 26)
        Me.Label24.TabIndex = 1097
        Me.Label24.Text = "合計"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_SEQNO
        '
        Me.lbl_SEQNO.AutoSize = True
        Me.lbl_SEQNO.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_SEQNO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_SEQNO.Location = New System.Drawing.Point(373, 513)
        Me.lbl_SEQNO.Name = "lbl_SEQNO"
        Me.lbl_SEQNO.Size = New System.Drawing.Size(31, 15)
        Me.lbl_SEQNO.TabIndex = 1099
        Me.lbl_SEQNO.Text = "999"
        Me.lbl_SEQNO.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(304, 513)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 15)
        Me.Label17.TabIndex = 1101
        Me.Label17.Text = "SEQNO"
        Me.Label17.Visible = False
        '
        'cmdCopy
        '
        Me.cmdCopy.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCopy.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(25, 3)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(137, 44)
        Me.cmdCopy.TabIndex = 3
        Me.cmdCopy.TabStop = False
        Me.cmdCopy.Text = "前期データコピー"
        Me.cmdCopy.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(353, 628)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(554, 30)
        Me.Label18.TabIndex = 1102
        Me.Label18.Text = "（1：採卵鶏「成鶏」、2：採卵鶏「育成鶏」、3：肉用鶏、4：種鶏「成鶏」、5：種鶏「育成鶏」、" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　6：うずら、7：あひる、8：きじ、9：ほろほろ鳥、10：七面鳥" & _
            "、11：だちょう）"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(494, 685)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(278, 15)
        Me.Label25.TabIndex = 1103
        Me.Label25.Text = "(契約日を入力することで単価を取得します)"
        '
        'lbl_KENSU
        '
        Me.lbl_KENSU.AutoSize = True
        Me.lbl_KENSU.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KENSU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KENSU.Location = New System.Drawing.Point(1032, 119)
        Me.lbl_KENSU.Name = "lbl_KENSU"
        Me.lbl_KENSU.Size = New System.Drawing.Size(47, 15)
        Me.lbl_KENSU.TabIndex = 1105
        Me.lbl_KENSU.Text = "99999"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(993, 119)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(40, 15)
        Me.Label27.TabIndex = 1104
        Me.Label27.Text = "件数:"
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(705, 370)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(124, 26)
        Me.Label32.TabIndex = 1116
        Me.Label32.Text = "だちょう"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(582, 370)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(124, 26)
        Me.Label33.TabIndex = 1114
        Me.Label33.Text = "七面鳥"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(459, 370)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(124, 26)
        Me.Label34.TabIndex = 1112
        Me.Label34.Text = "ほろほろ鳥"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(337, 370)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(124, 26)
        Me.Label35.TabIndex = 1110
        Me.Label35.Text = "きじ"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(214, 370)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(124, 26)
        Me.Label36.TabIndex = 1108
        Me.Label36.Text = "あひる"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(91, 370)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(124, 26)
        Me.Label21.TabIndex = 1095
        Me.Label21.Text = "うずら"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmGJ1012
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.num_HASU11)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.num_HASU10)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.num_HASU09)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.num_HASU08)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.num_HASU07)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.lbl_KENSU)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lbl_SEQNO)
        Me.Controls.Add(Me.num_HASU00)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.num_HASU06)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.num_HASU05)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.num_HASU04)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.num_HASU03)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.num_HASU02)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.num_HASU01)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.date_KEIYAKU_DATE_TO)
        Me.Controls.Add(Me.cmd_NOJO_INS)
        Me.Controls.Add(Me.cob_TORI_KBN)
        Me.Controls.Add(Me.cob_TORI_KBN_NM)
        Me.Controls.Add(Me.lbl_ADDR_4)
        Me.Controls.Add(Me.lbl_ADDR_3)
        Me.Controls.Add(Me.lbl_ADDR_2)
        Me.Controls.Add(Me.lbl_ADDR_1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cob_NOJO_CD)
        Me.Controls.Add(Me.cob_NOJO_nm)
        Me.Controls.Add(Me.lbl_ADDR_POST)
        Me.Controls.Add(Me.lbl_MEISAI_NO)
        Me.Controls.Add(Me.lbl_KI)
        Me.Controls.Add(Me.lbl_KEIYAKUSYA_NM)
        Me.Controls.Add(Me.lbl_KEIYAKUSYA_CD)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.date_KEIYAKU_DATE_FROM)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.num_KEIYAKU_HASU)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdUpd)
        Me.Controls.Add(Me.cmdIns)
        Me.Controls.Add(Me.dgv_Search)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_Biko)
        Me.Controls.Add(Me.Label30)
        Me.Name = "frmGJ1012"
        Me.Text = "(GJ1012)互助基金契マスタメンテンテナンス(契約情報)"
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.txt_Biko, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dgv_Search, 0)
        Me.Controls.SetChildIndex(Me.cmdIns, 0)
        Me.Controls.SetChildIndex(Me.cmdUpd, 0)
        Me.Controls.SetChildIndex(Me.cmdDel, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.num_KEIYAKU_HASU, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.date_KEIYAKU_DATE_FROM, 0)
        Me.Controls.SetChildIndex(Me.Label29, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKUSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKUSYA_NM, 0)
        Me.Controls.SetChildIndex(Me.lbl_KI, 0)
        Me.Controls.SetChildIndex(Me.lbl_MEISAI_NO, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_POST, 0)
        Me.Controls.SetChildIndex(Me.cob_NOJO_nm, 0)
        Me.Controls.SetChildIndex(Me.cob_NOJO_CD, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_1, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_2, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_3, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_4, 0)
        Me.Controls.SetChildIndex(Me.cob_TORI_KBN_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_TORI_KBN, 0)
        Me.Controls.SetChildIndex(Me.cmd_NOJO_INS, 0)
        Me.Controls.SetChildIndex(Me.date_KEIYAKU_DATE_TO, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.num_HASU01, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.num_HASU02, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.num_HASU03, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.num_HASU04, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.num_HASU05, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.num_HASU06, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.num_HASU00, 0)
        Me.Controls.SetChildIndex(Me.lbl_SEQNO, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.lbl_KENSU, 0)
        Me.Controls.SetChildIndex(Me.Label36, 0)
        Me.Controls.SetChildIndex(Me.num_HASU07, 0)
        Me.Controls.SetChildIndex(Me.Label35, 0)
        Me.Controls.SetChildIndex(Me.num_HASU08, 0)
        Me.Controls.SetChildIndex(Me.Label34, 0)
        Me.Controls.SetChildIndex(Me.num_HASU09, 0)
        Me.Controls.SetChildIndex(Me.Label33, 0)
        Me.Controls.SetChildIndex(Me.num_HASU10, 0)
        Me.Controls.SetChildIndex(Me.Label32, 0)
        Me.Controls.SetChildIndex(Me.num_HASU11, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.num_KEIYAKU_HASU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_HASU01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_HASU02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_HASU04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_HASU03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_HASU05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_HASU00, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_HASU11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_HASU10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_HASU09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_HASU08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_HASU07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_HASU06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Biko, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_KEIYAKU_DATE_FROM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_NOJO_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_NOJO_nm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_TORI_KBN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_TORI_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_KEIYAKU_DATE_TO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSave As JBD.Gjs.Win.JButton
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents GcDateValidator1 As GrapeCity.Win.Editors.GcDateValidator
    Friend WithEvents Label30 As JBD.Gjs.Win.Label
    Friend WithEvents txt_Biko As JBD.Gjs.Win.GcTextBox
    Friend WithEvents DropDownButton14 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton15 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton16 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton17 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton18 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton19 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents dgv_Search As JBD.Gjs.Win.DataGridView
    Friend WithEvents cmdDel As JBD.Gjs.Win.JButton
    Friend WithEvents cmdUpd As JBD.Gjs.Win.JButton
    Friend WithEvents cmdIns As JBD.Gjs.Win.JButton
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents num_KEIYAKU_HASU As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label23 As JBD.Gjs.Win.Label
    Friend WithEvents Label26 As JBD.Gjs.Win.Label
    Friend WithEvents Label29 As JBD.Gjs.Win.Label
    Friend WithEvents date_KEIYAKU_DATE_FROM As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label28 As JBD.Gjs.Win.Label
    Friend WithEvents cmdCansel As JBD.Gjs.Win.JButton
    Friend WithEvents lbl_KEIYAKUSYA_CD As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKUSYA_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KI As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_MEISAI_NO As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_POST As JBD.Gjs.Win.JLabel
    Friend WithEvents cob_NOJO_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_NOJO_nm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents lbl_ADDR_1 As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_2 As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_4 As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_3 As JBD.Gjs.Win.JLabel
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents cob_TORI_KBN As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_TORI_KBN_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cmd_NOJO_INS As JBD.Gjs.Win.JButton
    Friend WithEvents date_KEIYAKU_DATE_TO As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents num_HASU01 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_HASU02 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents num_HASU04 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents num_HASU03 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label20 As JBD.Gjs.Win.Label
    Friend WithEvents num_HASU05 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label22 As JBD.Gjs.Win.Label
    Friend WithEvents num_HASU00 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_SEQNO As JBD.Gjs.Win.JLabel
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents cmdCopy As JBD.Gjs.Win.JButton
    Friend WithEvents MEISAI_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEQNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOJO_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOJO_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TORI_KBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TORI_KBN_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_HASU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BIKO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_DATE_FROM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_DATE_TO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR_POST As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR_3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR_4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents Label25 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_KENSU As JBD.Gjs.Win.JLabel
    Friend WithEvents Label27 As JBD.Gjs.Win.Label
    Friend WithEvents num_HASU11 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label32 As JBD.Gjs.Win.Label
    Friend WithEvents num_HASU10 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label33 As JBD.Gjs.Win.Label
    Friend WithEvents num_HASU09 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label34 As JBD.Gjs.Win.Label
    Friend WithEvents num_HASU08 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label35 As JBD.Gjs.Win.Label
    Friend WithEvents num_HASU07 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label36 As JBD.Gjs.Win.Label
    Friend WithEvents num_HASU06 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label21 As JBD.Gjs.Win.Label

End Class
