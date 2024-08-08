Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ3021
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
        Dim DateEraYearField3 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraField3 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField7 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateLiteralField8 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField3 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField9 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField3 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateEraYearField4 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraDisplayField2 As GrapeCity.Win.Editors.Fields.DateEraDisplayField = New GrapeCity.Win.Editors.Fields.DateEraDisplayField()
        Dim DateLiteralDisplayField4 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateEraYearDisplayField2 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateLiteralDisplayField5 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateMonthDisplayField2 As GrapeCity.Win.Editors.Fields.DateMonthDisplayField = New GrapeCity.Win.Editors.Fields.DateMonthDisplayField()
        Dim DateLiteralDisplayField6 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateDayDisplayField2 As GrapeCity.Win.Editors.Fields.DateDayDisplayField = New GrapeCity.Win.Editors.Fields.DateDayDisplayField()
        Dim DateEraField4 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField10 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateLiteralField11 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField4 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField12 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField4 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.date_KIGEN_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton10 = New GrapeCity.Win.Editors.DropDownButton()
        Me.date_HAKKO_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton7 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cmdCan = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.cbo_KOFU_TUMI_SITEN_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.grpDATAKBN = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_SYORI_KBN4 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_SYORI_KBN1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_SYORI_KBN3 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_SYORI_KBN2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_SYORI_KBN0 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.lbl_KIGEN_DATE = New JBD.Gjs.Win.Label(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_SEIKYU_HAKKO_NO_NEN = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_SEIKYU_HAKKO_NO_RENBAN = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.lbl_HAKKO_NO_KANJI = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdPreview = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdTorikesi = New JBD.Gjs.Win.JButton(Me.components)
        Me.lbl_KI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKUSYA_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKUSYA_CD = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_SEIKYU_KAISU = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_SEIKYU_KAISU_HD = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_SEIKYU_KAISU_FT = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_KEIYAKU_DATE_FROM_X = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_SYORI_JOKYO_KBN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKU_KBN_MAE_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKU_KBN_MAE = New JBD.Gjs.Win.JLabel(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.date_KIGEN_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_HAKKO_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KOFU_TUMI_SITEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDATAKBN.SuspendLayout()
        CType(Me.txt_SEIKYU_HAKKO_NO_NEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SEIKYU_HAKKO_NO_RENBAN, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlButton.Controls.Add(Me.cmdTorikesi)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdTorikesi, 0)
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
        Me.cmdEnd.TabIndex = 25
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
        Me.date_KIGEN_DATE.DefaultActiveField = DateEraYearField3
        DateLiteralField8.Text = "/"
        DateLiteralField9.Text = "/"
        Me.date_KIGEN_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField3, DateLiteralField7, DateEraYearField3, DateLiteralField8, DateMonthField3, DateLiteralField9, DateDayField3})
        Me.date_KIGEN_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_KIGEN_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_KIGEN_DATE.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.date_KIGEN_DATE.InputCheck = True
        Me.date_KIGEN_DATE.Location = New System.Drawing.Point(155, 241)
        Me.date_KIGEN_DATE.Name = "date_KIGEN_DATE"
        Me.GcShortcut1.SetShortcuts(Me.date_KIGEN_DATE, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.date_KIGEN_DATE, Object), CType(Me.date_KIGEN_DATE, Object), CType(Me.date_KIGEN_DATE, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.date_KIGEN_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton10})
        Me.date_KIGEN_DATE.Size = New System.Drawing.Size(129, 21)
        Me.date_KIGEN_DATE.Spin.AllowSpin = False
        Me.date_KIGEN_DATE.TabIndex = 2
        Me.date_KIGEN_DATE.Value = New Date(2010, 8, 28, 11, 12, 38, 0)
        '
        'DropDownButton10
        '
        Me.DropDownButton10.Name = "DropDownButton10"
        '
        'date_HAKKO_DATE
        '
        Me.date_HAKKO_DATE.DefaultActiveField = DateEraYearField4
        DateEraYearDisplayField2.ShowLeadingZero = True
        DateLiteralDisplayField5.Text = "/"
        DateMonthDisplayField2.ShowLeadingZero = True
        DateLiteralDisplayField6.Text = "/"
        DateDayDisplayField2.ShowLeadingZero = True
        Me.date_HAKKO_DATE.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField2, DateLiteralDisplayField4, DateEraYearDisplayField2, DateLiteralDisplayField5, DateMonthDisplayField2, DateLiteralDisplayField6, DateDayDisplayField2})
        DateLiteralField11.Text = "/"
        DateLiteralField12.Text = "/"
        Me.date_HAKKO_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField4, DateLiteralField10, DateEraYearField4, DateLiteralField11, DateMonthField4, DateLiteralField12, DateDayField4})
        Me.date_HAKKO_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_HAKKO_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_HAKKO_DATE.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.date_HAKKO_DATE.InputCheck = True
        Me.date_HAKKO_DATE.Location = New System.Drawing.Point(155, 284)
        Me.date_HAKKO_DATE.Name = "date_HAKKO_DATE"
        Me.GcShortcut1.SetShortcuts(Me.date_HAKKO_DATE, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.date_HAKKO_DATE, Object), CType(Me.date_HAKKO_DATE, Object), CType(Me.date_HAKKO_DATE, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.date_HAKKO_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton7})
        Me.date_HAKKO_DATE.Size = New System.Drawing.Size(129, 21)
        Me.date_HAKKO_DATE.Spin.AllowSpin = False
        Me.date_HAKKO_DATE.TabIndex = 4
        Me.date_HAKKO_DATE.Value = New Date(2010, 8, 28, 11, 12, 38, 0)
        '
        'DropDownButton7
        '
        Me.DropDownButton7.Name = "DropDownButton7"
        '
        'cmdCan
        '
        Me.cmdCan.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCan.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCan.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCan.Location = New System.Drawing.Point(292, 6)
        Me.cmdCan.Name = "cmdCan"
        Me.cmdCan.Size = New System.Drawing.Size(92, 44)
        Me.cmdCan.TabIndex = 2
        Me.cmdCan.Text = "キャンセル"
        Me.cmdCan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(58, 191)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 872
        Me.Label2.Text = "□出力区分"
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
        Me.grpDATAKBN.Controls.Add(Me.rbtn_SYORI_KBN4)
        Me.grpDATAKBN.Controls.Add(Me.rbtn_SYORI_KBN1)
        Me.grpDATAKBN.Controls.Add(Me.rbtn_SYORI_KBN3)
        Me.grpDATAKBN.Controls.Add(Me.rbtn_SYORI_KBN2)
        Me.grpDATAKBN.Controls.Add(Me.rbtn_SYORI_KBN0)
        Me.grpDATAKBN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grpDATAKBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpDATAKBN.Location = New System.Drawing.Point(155, 177)
        Me.grpDATAKBN.Name = "grpDATAKBN"
        Me.grpDATAKBN.Size = New System.Drawing.Size(860, 38)
        Me.grpDATAKBN.TabIndex = 0
        Me.grpDATAKBN.TabStop = False
        '
        'rbtn_SYORI_KBN4
        '
        Me.rbtn_SYORI_KBN4.AutoSize = True
        Me.rbtn_SYORI_KBN4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_SYORI_KBN4.Location = New System.Drawing.Point(732, 12)
        Me.rbtn_SYORI_KBN4.Name = "rbtn_SYORI_KBN4"
        Me.rbtn_SYORI_KBN4.Size = New System.Drawing.Size(106, 20)
        Me.rbtn_SYORI_KBN4.TabIndex = 5
        Me.rbtn_SYORI_KBN4.Text = "通知書取消"
        Me.rbtn_SYORI_KBN4.UseVisualStyleBackColor = True
        '
        'rbtn_SYORI_KBN1
        '
        Me.rbtn_SYORI_KBN1.AutoSize = True
        Me.rbtn_SYORI_KBN1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_SYORI_KBN1.Location = New System.Drawing.Point(93, 12)
        Me.rbtn_SYORI_KBN1.Name = "rbtn_SYORI_KBN1"
        Me.rbtn_SYORI_KBN1.Size = New System.Drawing.Size(91, 20)
        Me.rbtn_SYORI_KBN1.TabIndex = 2
        Me.rbtn_SYORI_KBN1.Text = "初回発行"
        Me.rbtn_SYORI_KBN1.UseVisualStyleBackColor = True
        '
        'rbtn_SYORI_KBN3
        '
        Me.rbtn_SYORI_KBN3.AutoSize = True
        Me.rbtn_SYORI_KBN3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_SYORI_KBN3.Location = New System.Drawing.Point(374, 12)
        Me.rbtn_SYORI_KBN3.Name = "rbtn_SYORI_KBN3"
        Me.rbtn_SYORI_KBN3.Size = New System.Drawing.Size(352, 20)
        Me.rbtn_SYORI_KBN3.TabIndex = 4
        Me.rbtn_SYORI_KBN3.Text = "修正発行（納付期限、発行日、発信番号変更可能）"
        Me.rbtn_SYORI_KBN3.UseVisualStyleBackColor = True
        '
        'rbtn_SYORI_KBN2
        '
        Me.rbtn_SYORI_KBN2.AutoSize = True
        Me.rbtn_SYORI_KBN2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_SYORI_KBN2.Location = New System.Drawing.Point(190, 12)
        Me.rbtn_SYORI_KBN2.Name = "rbtn_SYORI_KBN2"
        Me.rbtn_SYORI_KBN2.Size = New System.Drawing.Size(178, 20)
        Me.rbtn_SYORI_KBN2.TabIndex = 3
        Me.rbtn_SYORI_KBN2.Text = "再発行（初回と同内容）"
        Me.rbtn_SYORI_KBN2.UseVisualStyleBackColor = True
        '
        'rbtn_SYORI_KBN0
        '
        Me.rbtn_SYORI_KBN0.AutoSize = True
        Me.rbtn_SYORI_KBN0.Checked = True
        Me.rbtn_SYORI_KBN0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_SYORI_KBN0.Location = New System.Drawing.Point(11, 12)
        Me.rbtn_SYORI_KBN0.Name = "rbtn_SYORI_KBN0"
        Me.rbtn_SYORI_KBN0.Size = New System.Drawing.Size(76, 20)
        Me.rbtn_SYORI_KBN0.TabIndex = 1
        Me.rbtn_SYORI_KBN0.TabStop = True
        Me.rbtn_SYORI_KBN0.Text = "仮発行"
        Me.rbtn_SYORI_KBN0.UseVisualStyleBackColor = True
        '
        'lbl_KIGEN_DATE
        '
        Me.lbl_KIGEN_DATE.AutoSize = True
        Me.lbl_KIGEN_DATE.BackColor = System.Drawing.Color.Transparent
        Me.lbl_KIGEN_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_KIGEN_DATE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_KIGEN_DATE.Location = New System.Drawing.Point(58, 244)
        Me.lbl_KIGEN_DATE.Name = "lbl_KIGEN_DATE"
        Me.lbl_KIGEN_DATE.Size = New System.Drawing.Size(82, 15)
        Me.lbl_KIGEN_DATE.TabIndex = 976
        Me.lbl_KIGEN_DATE.Text = "■納付期限"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(58, 287)
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
        Me.Label13.Location = New System.Drawing.Point(58, 336)
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
        Me.txt_SEIKYU_HAKKO_NO_NEN.Location = New System.Drawing.Point(190, 333)
        Me.txt_SEIKYU_HAKKO_NO_NEN.MaxLength = 2
        Me.txt_SEIKYU_HAKKO_NO_NEN.Name = "txt_SEIKYU_HAKKO_NO_NEN"
        Me.txt_SEIKYU_HAKKO_NO_NEN.Size = New System.Drawing.Size(28, 22)
        Me.txt_SEIKYU_HAKKO_NO_NEN.TabIndex = 6
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
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.Location = New System.Drawing.Point(278, 333)
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.MaxLength = 4
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.Name = "txt_SEIKYU_HAKKO_NO_RENBAN"
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.Size = New System.Drawing.Size(45, 22)
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.TabIndex = 8
        Me.txt_SEIKYU_HAKKO_NO_RENBAN.Text = "0000"
        '
        'lbl_HAKKO_NO_KANJI
        '
        Me.lbl_HAKKO_NO_KANJI.AutoSize = True
        Me.lbl_HAKKO_NO_KANJI.BackColor = System.Drawing.Color.Transparent
        Me.lbl_HAKKO_NO_KANJI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_HAKKO_NO_KANJI.Location = New System.Drawing.Point(152, 336)
        Me.lbl_HAKKO_NO_KANJI.Name = "lbl_HAKKO_NO_KANJI"
        Me.lbl_HAKKO_NO_KANJI.Size = New System.Drawing.Size(37, 15)
        Me.lbl_HAKKO_NO_KANJI.TabIndex = 989
        Me.lbl_HAKKO_NO_KANJI.Text = "＠＠"
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
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(329, 336)
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
        Me.Label4.Location = New System.Drawing.Point(222, 336)
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
        Me.Label7.Location = New System.Drawing.Point(256, 336)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 15)
        Me.Label7.TabIndex = 1005
        Me.Label7.Text = "第"
        '
        'cmdTorikesi
        '
        Me.cmdTorikesi.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdTorikesi.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTorikesi.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdTorikesi.Location = New System.Drawing.Point(140, 6)
        Me.cmdTorikesi.Name = "cmdTorikesi"
        Me.cmdTorikesi.Size = New System.Drawing.Size(92, 44)
        Me.cmdTorikesi.TabIndex = 1
        Me.cmdTorikesi.Text = "通知書取消"
        Me.cmdTorikesi.UseVisualStyleBackColor = True
        '
        'lbl_KI
        '
        Me.lbl_KI.AutoSize = True
        Me.lbl_KI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KI.Location = New System.Drawing.Point(58, 77)
        Me.lbl_KI.Name = "lbl_KI"
        Me.lbl_KI.Size = New System.Drawing.Size(53, 15)
        Me.lbl_KI.TabIndex = 1065
        Me.lbl_KI.Text = "第99期"
        '
        'lbl_KEIYAKUSYA_NM
        '
        Me.lbl_KEIYAKUSYA_NM.AutoSize = True
        Me.lbl_KEIYAKUSYA_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKUSYA_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKUSYA_NM.Location = New System.Drawing.Point(210, 116)
        Me.lbl_KEIYAKUSYA_NM.Name = "lbl_KEIYAKUSYA_NM"
        Me.lbl_KEIYAKUSYA_NM.Size = New System.Drawing.Size(382, 15)
        Me.lbl_KEIYAKUSYA_NM.TabIndex = 1064
        Me.lbl_KEIYAKUSYA_NM.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_KEIYAKUSYA_CD
        '
        Me.lbl_KEIYAKUSYA_CD.AutoSize = True
        Me.lbl_KEIYAKUSYA_CD.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKUSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKUSYA_CD.Location = New System.Drawing.Point(151, 116)
        Me.lbl_KEIYAKUSYA_CD.Name = "lbl_KEIYAKUSYA_CD"
        Me.lbl_KEIYAKUSYA_CD.Size = New System.Drawing.Size(47, 15)
        Me.lbl_KEIYAKUSYA_CD.TabIndex = 1063
        Me.lbl_KEIYAKUSYA_CD.Text = "99999"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(92, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 15)
        Me.Label6.TabIndex = 1062
        Me.Label6.Text = "契約者"
        '
        'lbl_SEIKYU_KAISU
        '
        Me.lbl_SEIKYU_KAISU.AutoSize = True
        Me.lbl_SEIKYU_KAISU.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_SEIKYU_KAISU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_SEIKYU_KAISU.ForeColor = System.Drawing.Color.Fuchsia
        Me.lbl_SEIKYU_KAISU.Location = New System.Drawing.Point(947, 116)
        Me.lbl_SEIKYU_KAISU.Name = "lbl_SEIKYU_KAISU"
        Me.lbl_SEIKYU_KAISU.Size = New System.Drawing.Size(31, 15)
        Me.lbl_SEIKYU_KAISU.TabIndex = 1067
        Me.lbl_SEIKYU_KAISU.Text = "999"
        Me.lbl_SEIKYU_KAISU.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lbl_SEIKYU_KAISU.Visible = False
        '
        'lbl_SEIKYU_KAISU_HD
        '
        Me.lbl_SEIKYU_KAISU_HD.AutoSize = True
        Me.lbl_SEIKYU_KAISU_HD.BackColor = System.Drawing.Color.Transparent
        Me.lbl_SEIKYU_KAISU_HD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_SEIKYU_KAISU_HD.ForeColor = System.Drawing.Color.Fuchsia
        Me.lbl_SEIKYU_KAISU_HD.Location = New System.Drawing.Point(901, 116)
        Me.lbl_SEIKYU_KAISU_HD.Name = "lbl_SEIKYU_KAISU_HD"
        Me.lbl_SEIKYU_KAISU_HD.Size = New System.Drawing.Size(45, 15)
        Me.lbl_SEIKYU_KAISU_HD.TabIndex = 1066
        Me.lbl_SEIKYU_KAISU_HD.Text = "請求："
        Me.lbl_SEIKYU_KAISU_HD.Visible = False
        '
        'lbl_SEIKYU_KAISU_FT
        '
        Me.lbl_SEIKYU_KAISU_FT.AutoSize = True
        Me.lbl_SEIKYU_KAISU_FT.BackColor = System.Drawing.Color.Transparent
        Me.lbl_SEIKYU_KAISU_FT.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_SEIKYU_KAISU_FT.ForeColor = System.Drawing.Color.Fuchsia
        Me.lbl_SEIKYU_KAISU_FT.Location = New System.Drawing.Point(978, 116)
        Me.lbl_SEIKYU_KAISU_FT.Name = "lbl_SEIKYU_KAISU_FT"
        Me.lbl_SEIKYU_KAISU_FT.Size = New System.Drawing.Size(22, 15)
        Me.lbl_SEIKYU_KAISU_FT.TabIndex = 1068
        Me.lbl_SEIKYU_KAISU_FT.Text = "回"
        Me.lbl_SEIKYU_KAISU_FT.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Fuchsia
        Me.Label3.Location = New System.Drawing.Point(648, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 15)
        Me.Label3.TabIndex = 1069
        Me.Label3.Text = "変更年月日："
        Me.Label3.Visible = False
        '
        'lbl_KEIYAKU_DATE_FROM_X
        '
        Me.lbl_KEIYAKU_DATE_FROM_X.AutoSize = True
        Me.lbl_KEIYAKU_DATE_FROM_X.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_DATE_FROM_X.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_DATE_FROM_X.ForeColor = System.Drawing.Color.Fuchsia
        Me.lbl_KEIYAKU_DATE_FROM_X.Location = New System.Drawing.Point(738, 116)
        Me.lbl_KEIYAKU_DATE_FROM_X.Name = "lbl_KEIYAKU_DATE_FROM_X"
        Me.lbl_KEIYAKU_DATE_FROM_X.Size = New System.Drawing.Size(130, 15)
        Me.lbl_KEIYAKU_DATE_FROM_X.TabIndex = 1070
        Me.lbl_KEIYAKU_DATE_FROM_X.Text = "平成99年99月99日"
        Me.lbl_KEIYAKU_DATE_FROM_X.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lbl_KEIYAKU_DATE_FROM_X.Visible = False
        '
        'lbl_SYORI_JOKYO_KBN
        '
        Me.lbl_SYORI_JOKYO_KBN.AutoSize = True
        Me.lbl_SYORI_JOKYO_KBN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_SYORI_JOKYO_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_SYORI_JOKYO_KBN.Location = New System.Drawing.Point(381, 336)
        Me.lbl_SYORI_JOKYO_KBN.Name = "lbl_SYORI_JOKYO_KBN"
        Me.lbl_SYORI_JOKYO_KBN.Size = New System.Drawing.Size(15, 15)
        Me.lbl_SYORI_JOKYO_KBN.TabIndex = 1071
        Me.lbl_SYORI_JOKYO_KBN.Text = "9"
        Me.lbl_SYORI_JOKYO_KBN.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lbl_SYORI_JOKYO_KBN.Visible = False
        '
        'lbl_KEIYAKU_KBN_MAE_NM
        '
        Me.lbl_KEIYAKU_KBN_MAE_NM.AutoSize = True
        Me.lbl_KEIYAKU_KBN_MAE_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_KBN_MAE_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_KBN_MAE_NM.Location = New System.Drawing.Point(211, 143)
        Me.lbl_KEIYAKU_KBN_MAE_NM.Name = "lbl_KEIYAKU_KBN_MAE_NM"
        Me.lbl_KEIYAKU_KBN_MAE_NM.Size = New System.Drawing.Size(43, 15)
        Me.lbl_KEIYAKU_KBN_MAE_NM.TabIndex = 1144
        Me.lbl_KEIYAKU_KBN_MAE_NM.Text = "ＮＮＮ"
        '
        'lbl_KEIYAKU_KBN_MAE
        '
        Me.lbl_KEIYAKU_KBN_MAE.AutoSize = True
        Me.lbl_KEIYAKU_KBN_MAE.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_KBN_MAE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_KBN_MAE.Location = New System.Drawing.Point(151, 143)
        Me.lbl_KEIYAKU_KBN_MAE.Name = "lbl_KEIYAKU_KBN_MAE"
        Me.lbl_KEIYAKU_KBN_MAE.Size = New System.Drawing.Size(15, 15)
        Me.lbl_KEIYAKU_KBN_MAE.TabIndex = 1143
        Me.lbl_KEIYAKU_KBN_MAE.Text = "9"
        '
        'frmGJ3021
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.lbl_KEIYAKU_KBN_MAE_NM)
        Me.Controls.Add(Me.lbl_KEIYAKU_KBN_MAE)
        Me.Controls.Add(Me.lbl_SYORI_JOKYO_KBN)
        Me.Controls.Add(Me.lbl_SEIKYU_KAISU)
        Me.Controls.Add(Me.lbl_KEIYAKU_DATE_FROM_X)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_SEIKYU_KAISU_FT)
        Me.Controls.Add(Me.lbl_SEIKYU_KAISU_HD)
        Me.Controls.Add(Me.lbl_KI)
        Me.Controls.Add(Me.lbl_KEIYAKUSYA_NM)
        Me.Controls.Add(Me.lbl_KEIYAKUSYA_CD)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_SEIKYU_HAKKO_NO_NEN)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txt_SEIKYU_HAKKO_NO_RENBAN)
        Me.Controls.Add(Me.lbl_HAKKO_NO_KANJI)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.date_HAKKO_DATE)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.date_KIGEN_DATE)
        Me.Controls.Add(Me.lbl_KIGEN_DATE)
        Me.Controls.Add(Me.grpDATAKBN)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmGJ3021"
        Me.Text = "(GJ3020)互助基金契約者情報変更（契約区分変更）通知書発行"
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.grpDATAKBN, 0)
        Me.Controls.SetChildIndex(Me.lbl_KIGEN_DATE, 0)
        Me.Controls.SetChildIndex(Me.date_KIGEN_DATE, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.date_HAKKO_DATE, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.lbl_HAKKO_NO_KANJI, 0)
        Me.Controls.SetChildIndex(Me.txt_SEIKYU_HAKKO_NO_RENBAN, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txt_SEIKYU_HAKKO_NO_NEN, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKUSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKUSYA_NM, 0)
        Me.Controls.SetChildIndex(Me.lbl_KI, 0)
        Me.Controls.SetChildIndex(Me.lbl_SEIKYU_KAISU_HD, 0)
        Me.Controls.SetChildIndex(Me.lbl_SEIKYU_KAISU_FT, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_DATE_FROM_X, 0)
        Me.Controls.SetChildIndex(Me.lbl_SEIKYU_KAISU, 0)
        Me.Controls.SetChildIndex(Me.lbl_SYORI_JOKYO_KBN, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_KBN_MAE, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_KBN_MAE_NM, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.date_KIGEN_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_HAKKO_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KOFU_TUMI_SITEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDATAKBN.ResumeLayout(False)
        Me.grpDATAKBN.PerformLayout()
        CType(Me.txt_SEIKYU_HAKKO_NO_NEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SEIKYU_HAKKO_NO_RENBAN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents cmdCan As JBD.Gjs.Win.JButton
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents cbo_KOFU_TUMI_SITEN_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents grpDATAKBN As JBD.Gjs.Win.GroupBox
    Friend WithEvents lbl_KIGEN_DATE As JBD.Gjs.Win.Label
    Friend WithEvents date_KIGEN_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton10 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents date_HAKKO_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton7 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents txt_SEIKYU_HAKKO_NO_NEN As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_SEIKYU_HAKKO_NO_RENBAN As JBD.Gjs.Win.GcTextBox
    Friend WithEvents lbl_HAKKO_NO_KANJI As JBD.Gjs.Win.Label
    Friend WithEvents cmdPreview As JBD.Gjs.Win.JButton
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents cmdTorikesi As JBD.Gjs.Win.JButton
    Friend WithEvents lbl_KI As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKUSYA_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKUSYA_CD As JBD.Gjs.Win.JLabel
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents rbtn_SYORI_KBN4 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_SYORI_KBN1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_SYORI_KBN3 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_SYORI_KBN2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_SYORI_KBN0 As JBD.Gjs.Win.RadioButton
    Friend WithEvents lbl_SEIKYU_KAISU As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_SEIKYU_KAISU_HD As JBD.Gjs.Win.Label
    Friend WithEvents lbl_SEIKYU_KAISU_FT As JBD.Gjs.Win.Label
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_KEIYAKU_DATE_FROM_X As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_SYORI_JOKYO_KBN As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKU_KBN_MAE_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKU_KBN_MAE As JBD.Gjs.Win.JLabel

End Class
