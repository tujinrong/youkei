Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ8041
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
        Dim DateEraYearField1 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraDisplayField1 As GrapeCity.Win.Editors.Fields.DateEraDisplayField = New GrapeCity.Win.Editors.Fields.DateEraDisplayField()
        Dim DateEraYearDisplayField1 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateLiteralDisplayField1 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateMonthDisplayField1 As GrapeCity.Win.Editors.Fields.DateMonthDisplayField = New GrapeCity.Win.Editors.Fields.DateMonthDisplayField()
        Dim DateLiteralDisplayField2 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateDayDisplayField1 As GrapeCity.Win.Editors.Fields.DateDayDisplayField = New GrapeCity.Win.Editors.Fields.DateDayDisplayField()
        Dim DateEraField1 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField1 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField1 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField2 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField1 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateEraDisplayField2 As GrapeCity.Win.Editors.Fields.DateEraDisplayField = New GrapeCity.Win.Editors.Fields.DateEraDisplayField()
        Dim DateEraYearDisplayField2 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateLiteralDisplayField3 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateMonthDisplayField2 As GrapeCity.Win.Editors.Fields.DateMonthDisplayField = New GrapeCity.Win.Editors.Fields.DateMonthDisplayField()
        Dim DateLiteralDisplayField4 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateDayDisplayField2 As GrapeCity.Win.Editors.Fields.DateDayDisplayField = New GrapeCity.Win.Editors.Fields.DateDayDisplayField()
        Dim DateEraField2 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateEraYearField2 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField3 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField2 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField4 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField2 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Me.txt_USER_ID = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_USER_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_PASS = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KenCdFm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.date_TEISI_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.date_REG_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.date_PASS_KIGEN_DATE = New JBD.Gjs.Win.JLabel(Me.components)
        Me.date_PASS_UP_DATE = New JBD.Gjs.Win.JLabel(Me.components)
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.cbo_SIYO_KBN = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.txt_TEISI_RIYU = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.cbo_SIYO_KBN_NAME = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton8 = New GrapeCity.Win.Editors.DropDownButton()
        Me.pnlButton.SuspendLayout()
        CType(Me.txt_USER_ID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_USER_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PASS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KenCdFm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_TEISI_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_REG_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_SIYO_KBN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TEISI_RIYU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_SIYO_KBN_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdSave)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSave, 0)
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
        Me.cmdEnd.TabIndex = 15
        '
        'txt_USER_ID
        '
        Me.txt_USER_ID.DropDown.AllowDrop = False
        Me.txt_USER_ID.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_USER_ID.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_USER_ID.Format = "H"
        Me.txt_USER_ID.HighlightText = True
        Me.txt_USER_ID.InputCheck = True
        Me.txt_USER_ID.Location = New System.Drawing.Point(302, 135)
        Me.txt_USER_ID.MaxLength = 10
        Me.txt_USER_ID.Name = "txt_USER_ID"
        Me.txt_USER_ID.Size = New System.Drawing.Size(101, 22)
        Me.txt_USER_ID.TabIndex = 0
        Me.txt_USER_ID.Text = "XXXXXXXXXX"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(111, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "■ユーザーID"
        '
        'txt_USER_NAME
        '
        Me.txt_USER_NAME.DropDown.AllowDrop = False
        Me.txt_USER_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_USER_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_USER_NAME.HighlightText = True
        Me.txt_USER_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_USER_NAME.InputCheck = True
        Me.txt_USER_NAME.Location = New System.Drawing.Point(302, 191)
        Me.txt_USER_NAME.MaxLength = 20
        Me.txt_USER_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_USER_NAME.Name = "txt_USER_NAME"
        Me.txt_USER_NAME.Size = New System.Drawing.Size(166, 20)
        Me.txt_USER_NAME.TabIndex = 1
        Me.txt_USER_NAME.Text = "＠＠＠＠＠＠＠＠＠＠"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(111, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 15)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "■ユーザー名"
        '
        'txt_PASS
        '
        Me.txt_PASS.DropDown.AllowDrop = False
        Me.txt_PASS.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_PASS.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_PASS.HighlightText = True
        Me.txt_PASS.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_PASS.InputCheck = True
        Me.txt_PASS.Location = New System.Drawing.Point(302, 246)
        Me.txt_PASS.MaxLength = 20
        Me.txt_PASS.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_PASS.Name = "txt_PASS"
        Me.txt_PASS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_PASS.Size = New System.Drawing.Size(166, 20)
        Me.txt_PASS.TabIndex = 2
        Me.txt_PASS.Text = "XXXXXXXXXXXXXXXXXXXX"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(111, 249)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 15)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "■パスワード"
        '
        'cob_KenCdFm
        '
        Me.cob_KenCdFm.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_KenCdFm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KenCdFm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KenCdFm.Format = "9"
        Me.cob_KenCdFm.HighlightText = True
        Me.cob_KenCdFm.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_KenCdFm.ListHeaderPane.Height = 22
        Me.cob_KenCdFm.Location = New System.Drawing.Point(280, 135)
        Me.cob_KenCdFm.MaxLength = 2
        Me.cob_KenCdFm.Name = "cob_KenCdFm"
        Me.GcShortcut1.SetShortcuts(Me.cob_KenCdFm, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.cob_KenCdFm, Object), CType(Me.cob_KenCdFm, Object)}, New String() {"ShortcutClear", "ApplyRecommendedValue"}))
        Me.cob_KenCdFm.Size = New System.Drawing.Size(36, 22)
        Me.cob_KenCdFm.TabIndex = 872
        Me.cob_KenCdFm.Text = "00"
        '
        'date_TEISI_DATE
        '
        Me.date_TEISI_DATE.DefaultActiveField = DateEraYearField1
        DateEraYearDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField1.Text = "/"
        DateMonthDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField2.Text = "/"
        DateDayDisplayField1.ShowLeadingZero = True
        Me.date_TEISI_DATE.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField1, DateEraYearDisplayField1, DateLiteralDisplayField1, DateMonthDisplayField1, DateLiteralDisplayField2, DateDayDisplayField1})
        DateLiteralField1.Text = "/"
        DateLiteralField2.Text = "/"
        Me.date_TEISI_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateEraYearField1, DateLiteralField1, DateMonthField1, DateLiteralField2, DateDayField1})
        Me.date_TEISI_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_TEISI_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_TEISI_DATE.Location = New System.Drawing.Point(302, 466)
        Me.date_TEISI_DATE.Name = "date_TEISI_DATE"
        Me.GcShortcut1.SetShortcuts(Me.date_TEISI_DATE, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.date_TEISI_DATE, Object), CType(Me.date_TEISI_DATE, Object), CType(Me.date_TEISI_DATE, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.date_TEISI_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.date_TEISI_DATE.Size = New System.Drawing.Size(117, 21)
        Me.date_TEISI_DATE.Spin.AllowSpin = False
        Me.date_TEISI_DATE.TabIndex = 7
        Me.date_TEISI_DATE.Value = New Date(2010, 8, 28, 11, 12, 38, 0)
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'date_REG_DATE
        '
        DateEraYearDisplayField2.ShowLeadingZero = True
        DateLiteralDisplayField3.Text = "/"
        DateMonthDisplayField2.ShowLeadingZero = True
        DateLiteralDisplayField4.Text = "/"
        DateDayDisplayField2.ShowLeadingZero = True
        Me.date_REG_DATE.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField2, DateEraYearDisplayField2, DateLiteralDisplayField3, DateMonthDisplayField2, DateLiteralDisplayField4, DateDayDisplayField2})
        DateLiteralField3.Text = "/"
        DateLiteralField4.Text = "/"
        Me.date_REG_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateEraYearField2, DateLiteralField3, DateMonthField2, DateLiteralField4, DateDayField2})
        Me.date_REG_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_REG_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_REG_DATE.Location = New System.Drawing.Point(509, 466)
        Me.date_REG_DATE.Name = "date_REG_DATE"
        Me.GcShortcut1.SetShortcuts(Me.date_REG_DATE, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.date_REG_DATE, Object), CType(Me.date_REG_DATE, Object), CType(Me.date_REG_DATE, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.date_REG_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.date_REG_DATE.Size = New System.Drawing.Size(117, 21)
        Me.date_REG_DATE.Spin.AllowSpin = False
        Me.date_REG_DATE.TabIndex = 870
        Me.date_REG_DATE.Value = New Date(2010, 8, 28, 11, 12, 38, 0)
        Me.date_REG_DATE.Visible = False
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'date_PASS_KIGEN_DATE
        '
        Me.date_PASS_KIGEN_DATE.BackColor = System.Drawing.Color.CornflowerBlue
        Me.date_PASS_KIGEN_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_PASS_KIGEN_DATE.Location = New System.Drawing.Point(302, 301)
        Me.date_PASS_KIGEN_DATE.Name = "date_PASS_KIGEN_DATE"
        Me.date_PASS_KIGEN_DATE.Size = New System.Drawing.Size(117, 21)
        Me.date_PASS_KIGEN_DATE.TabIndex = 870
        Me.date_PASS_KIGEN_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'date_PASS_UP_DATE
        '
        Me.date_PASS_UP_DATE.BackColor = System.Drawing.Color.CornflowerBlue
        Me.date_PASS_UP_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_PASS_UP_DATE.Location = New System.Drawing.Point(302, 355)
        Me.date_PASS_UP_DATE.Name = "date_PASS_UP_DATE"
        Me.date_PASS_UP_DATE.Size = New System.Drawing.Size(117, 21)
        Me.date_PASS_UP_DATE.TabIndex = 869
        Me.date_PASS_UP_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(29, 5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 44)
        Me.cmdSave.TabIndex = 9
        Me.cmdSave.Text = "保存"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(111, 469)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 15)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "□使用停止日"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(111, 524)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 15)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "□使用停止理由"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(111, 414)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 15)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "■使用区分"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(145, 304)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(135, 15)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "パスワード有効期限"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(145, 359)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 15)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "パスワード変更日"
        '
        'cbo_SIYO_KBN
        '
        Me.cbo_SIYO_KBN.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cbo_SIYO_KBN.DropDown.AllowDrop = False
        Me.cbo_SIYO_KBN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_SIYO_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_SIYO_KBN.Format = "9"
        Me.cbo_SIYO_KBN.HighlightText = True
        Me.cbo_SIYO_KBN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_SIYO_KBN.InputCheck = True
        Me.cbo_SIYO_KBN.ListHeaderPane.Height = 22
        Me.cbo_SIYO_KBN.Location = New System.Drawing.Point(303, 410)
        Me.cbo_SIYO_KBN.MaxLength = 2
        Me.cbo_SIYO_KBN.Name = "cbo_SIYO_KBN"
        Me.cbo_SIYO_KBN.Size = New System.Drawing.Size(27, 22)
        Me.cbo_SIYO_KBN.Spin.AllowSpin = False
        Me.cbo_SIYO_KBN.TabIndex = 5
        Me.cbo_SIYO_KBN.Tag = "使用区分"
        Me.cbo_SIYO_KBN.Text = "00"
        '
        'txt_TEISI_RIYU
        '
        Me.txt_TEISI_RIYU.DropDown.AllowDrop = False
        Me.txt_TEISI_RIYU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_TEISI_RIYU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_TEISI_RIYU.HighlightText = True
        Me.txt_TEISI_RIYU.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_TEISI_RIYU.Location = New System.Drawing.Point(302, 521)
        Me.txt_TEISI_RIYU.MaxLength = 40
        Me.txt_TEISI_RIYU.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_TEISI_RIYU.Name = "txt_TEISI_RIYU"
        Me.txt_TEISI_RIYU.Size = New System.Drawing.Size(311, 20)
        Me.txt_TEISI_RIYU.TabIndex = 8
        Me.txt_TEISI_RIYU.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'cbo_SIYO_KBN_NAME
        '
        Me.cbo_SIYO_KBN_NAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbo_SIYO_KBN_NAME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_SIYO_KBN_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_SIYO_KBN_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_SIYO_KBN_NAME.InputCheck = True
        Me.cbo_SIYO_KBN_NAME.ListHeaderPane.Height = 22
        Me.cbo_SIYO_KBN_NAME.ListHeaderPane.Visible = False
        Me.cbo_SIYO_KBN_NAME.Location = New System.Drawing.Point(336, 410)
        Me.cbo_SIYO_KBN_NAME.MaxLength = 10
        Me.cbo_SIYO_KBN_NAME.Name = "cbo_SIYO_KBN_NAME"
        Me.cbo_SIYO_KBN_NAME.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton8})
        Me.cbo_SIYO_KBN_NAME.Size = New System.Drawing.Size(119, 22)
        Me.cbo_SIYO_KBN_NAME.TabIndex = 6
        Me.cbo_SIYO_KBN_NAME.TabStop = False
        Me.cbo_SIYO_KBN_NAME.Tag = "使用区分名"
        '
        'DropDownButton8
        '
        Me.DropDownButton8.Name = "DropDownButton8"
        '
        'frmGJ8041
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.cbo_SIYO_KBN_NAME)
        Me.Controls.Add(Me.date_PASS_KIGEN_DATE)
        Me.Controls.Add(Me.date_REG_DATE)
        Me.Controls.Add(Me.txt_TEISI_RIYU)
        Me.Controls.Add(Me.cbo_SIYO_KBN)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.date_TEISI_DATE)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_PASS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_USER_NAME)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_USER_ID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.date_PASS_UP_DATE)
        Me.Name = "frmGJ8041"
        Me.Text = "(GJ8041)使用者マスタメンテナンス"
        Me.Controls.SetChildIndex(Me.date_PASS_UP_DATE, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txt_USER_ID, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txt_USER_NAME, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txt_PASS, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.date_TEISI_DATE, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.cbo_SIYO_KBN, 0)
        Me.Controls.SetChildIndex(Me.txt_TEISI_RIYU, 0)
        Me.Controls.SetChildIndex(Me.date_REG_DATE, 0)
        Me.Controls.SetChildIndex(Me.date_PASS_KIGEN_DATE, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.cbo_SIYO_KBN_NAME, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.txt_USER_ID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_USER_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PASS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KenCdFm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_TEISI_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_REG_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_SIYO_KBN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TEISI_RIYU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_SIYO_KBN_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_USER_ID As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents txt_USER_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents txt_PASS As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KenCdFm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents cmdSave As JBD.Gjs.Win.JButton
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents date_TEISI_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents cbo_SIYO_KBN As JBD.Gjs.Win.GcComboBox
    Friend WithEvents txt_TEISI_RIYU As JBD.Gjs.Win.GcTextBox
    Friend WithEvents date_PASS_KIGEN_DATE As JBD.Gjs.Win.JLabel
    Friend WithEvents date_PASS_UP_DATE As JBD.Gjs.Win.JLabel
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents date_REG_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents cbo_SIYO_KBN_NAME As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton8 As GrapeCity.Win.Editors.DropDownButton

End Class
