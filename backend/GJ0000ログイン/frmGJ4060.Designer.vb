Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ4060
    Inherits JBD.Gjs.Win.FormL
    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub
    Public Sub New(ByVal pPFSINI_Array As pGJSINI)
        MyBase.New(pPFSINI_Array)
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
        Dim ValueProcess1 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange1 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim DateEraField1 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField1 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField1 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField2 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField1 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField3 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField1 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.numKI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.dateFurikomiYmd = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.numHasseiKaisuFrom = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numHasseiKaisuTo = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKeisanKaisuTo = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKeisanKaisuFrom = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.cmdPreview = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdCancel = New JBD.Gjs.Win.JButton(Me.components)
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.chkIchiHen = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.chkHenkan = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.chkGojo = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.grpTumi = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rdoSyusei = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rdoSyokai = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateFurikomiYmd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHasseiKaisuFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHasseiKaisuTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKeisanKaisuTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKeisanKaisuFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTumi.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdCancel)
        Me.pnlButton.Controls.Add(Me.cmdPreview)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdPreview, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCancel, 0)
        '
        'cmdEnd
        '
        Me.cmdEnd.TabIndex = 99
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(45, 230)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 957
        Me.Label5.Text = "■対象期"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(248, 230)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 15)
        Me.Label6.TabIndex = 958
        Me.Label6.Text = "期"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(45, 389)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 15)
        Me.Label8.TabIndex = 964
        Me.Label8.Text = "■振込予定日"
        '
        'numKI
        '
        Me.numKI.AllowDeleteToNull = True
        Me.numKI.ContentAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.numKI.DropDown.AllowDrop = False
        Me.numKI.Fields.DecimalPart.MaxDigits = 0
        Me.numKI.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKI.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKI.Fields.IntegerPart.MaxDigits = 2
        Me.numKI.Fields.IntegerPart.MinDigits = 1
        Me.numKI.Fields.SignPrefix.NegativePattern = ""
        Me.numKI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKI.HighlightText = True
        Me.numKI.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKI.InputCheck = True
        Me.numKI.Location = New System.Drawing.Point(203, 227)
        Me.numKI.Name = "numKI"
        Me.GcShortcut1.SetShortcuts(Me.numKI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKI, Object), CType(Me.numKI, Object), CType(Me.numKI, Object), CType(Me.numKI, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKI.Size = New System.Drawing.Size(39, 20)
        Me.numKI.Spin.Increment = 0
        Me.numKI.TabIndex = 4
        ValueProcess1.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKI).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess1})
        InvalidRange1.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        InvalidRange1.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKI).AddRange(New Object() {InvalidRange1})
        Me.numKI.Value = New Decimal(New Integer() {99, 0, 0, 0})
        Me.numKI.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        Me.numKI.ZeroSuppress = True
        '
        'dateFurikomiYmd
        '
        Me.dateFurikomiYmd.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.dateFurikomiYmd.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.dateFurikomiYmd.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateFurikomiYmd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateFurikomiYmd.InputCheck = True
        Me.dateFurikomiYmd.Location = New System.Drawing.Point(174, 386)
        Me.dateFurikomiYmd.Name = "dateFurikomiYmd"
        Me.GcShortcut1.SetShortcuts(Me.dateFurikomiYmd, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateFurikomiYmd, Object), CType(Me.dateFurikomiYmd, Object), CType(Me.dateFurikomiYmd, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateFurikomiYmd.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.dateFurikomiYmd.Size = New System.Drawing.Size(124, 20)
        Me.dateFurikomiYmd.Spin.AllowSpin = False
        Me.dateFurikomiYmd.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateFurikomiYmd.TabIndex = 9
        Me.dateFurikomiYmd.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'numHasseiKaisuFrom
        '
        Me.numHasseiKaisuFrom.AllowDeleteToNull = True
        Me.numHasseiKaisuFrom.ContentAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.numHasseiKaisuFrom.DropDown.AllowDrop = False
        Me.numHasseiKaisuFrom.Fields.DecimalPart.MaxDigits = 3
        Me.numHasseiKaisuFrom.Fields.IntegerPart.MaxDigits = 3
        Me.numHasseiKaisuFrom.Fields.IntegerPart.MinDigits = 1
        Me.numHasseiKaisuFrom.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numHasseiKaisuFrom.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.numHasseiKaisuFrom.HighlightText = True
        Me.numHasseiKaisuFrom.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numHasseiKaisuFrom.InputCheck = True
        Me.numHasseiKaisuFrom.Location = New System.Drawing.Point(174, 280)
        Me.numHasseiKaisuFrom.Name = "numHasseiKaisuFrom"
        Me.GcShortcut1.SetShortcuts(Me.numHasseiKaisuFrom, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numHasseiKaisuFrom, Object), CType(Me.numHasseiKaisuFrom, Object), CType(Me.numHasseiKaisuFrom, Object), CType(Me.numHasseiKaisuFrom, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numHasseiKaisuFrom.Size = New System.Drawing.Size(56, 20)
        Me.numHasseiKaisuFrom.Spin.AllowSpin = False
        Me.numHasseiKaisuFrom.Spin.Increment = 0
        Me.numHasseiKaisuFrom.Spin.SpinOnKeys = False
        Me.numHasseiKaisuFrom.Spin.Wrap = False
        Me.numHasseiKaisuFrom.TabIndex = 5
        Me.numHasseiKaisuFrom.Value = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numHasseiKaisuFrom.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numHasseiKaisuTo
        '
        Me.numHasseiKaisuTo.AllowDeleteToNull = True
        Me.numHasseiKaisuTo.ContentAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.numHasseiKaisuTo.DropDown.AllowDrop = False
        Me.numHasseiKaisuTo.Fields.DecimalPart.MaxDigits = 3
        Me.numHasseiKaisuTo.Fields.IntegerPart.MaxDigits = 3
        Me.numHasseiKaisuTo.Fields.IntegerPart.MinDigits = 1
        Me.numHasseiKaisuTo.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numHasseiKaisuTo.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.numHasseiKaisuTo.HighlightText = True
        Me.numHasseiKaisuTo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numHasseiKaisuTo.InputCheck = True
        Me.numHasseiKaisuTo.Location = New System.Drawing.Point(275, 280)
        Me.numHasseiKaisuTo.Name = "numHasseiKaisuTo"
        Me.GcShortcut1.SetShortcuts(Me.numHasseiKaisuTo, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numHasseiKaisuTo, Object), CType(Me.numHasseiKaisuTo, Object), CType(Me.numHasseiKaisuTo, Object), CType(Me.numHasseiKaisuTo, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numHasseiKaisuTo.Size = New System.Drawing.Size(56, 20)
        Me.numHasseiKaisuTo.Spin.AllowSpin = False
        Me.numHasseiKaisuTo.Spin.Increment = 0
        Me.numHasseiKaisuTo.Spin.SpinOnKeys = False
        Me.numHasseiKaisuTo.Spin.Wrap = False
        Me.numHasseiKaisuTo.TabIndex = 6
        Me.numHasseiKaisuTo.Value = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numHasseiKaisuTo.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKeisanKaisuTo
        '
        Me.numKeisanKaisuTo.AllowDeleteToNull = True
        Me.numKeisanKaisuTo.ContentAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.numKeisanKaisuTo.DropDown.AllowDrop = False
        Me.numKeisanKaisuTo.Fields.DecimalPart.MaxDigits = 3
        Me.numKeisanKaisuTo.Fields.IntegerPart.MaxDigits = 3
        Me.numKeisanKaisuTo.Fields.IntegerPart.MinDigits = 1
        Me.numKeisanKaisuTo.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKeisanKaisuTo.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.numKeisanKaisuTo.HighlightText = True
        Me.numKeisanKaisuTo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKeisanKaisuTo.InputCheck = True
        Me.numKeisanKaisuTo.Location = New System.Drawing.Point(275, 333)
        Me.numKeisanKaisuTo.Name = "numKeisanKaisuTo"
        Me.GcShortcut1.SetShortcuts(Me.numKeisanKaisuTo, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKeisanKaisuTo, Object), CType(Me.numKeisanKaisuTo, Object), CType(Me.numKeisanKaisuTo, Object), CType(Me.numKeisanKaisuTo, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKeisanKaisuTo.Size = New System.Drawing.Size(56, 20)
        Me.numKeisanKaisuTo.Spin.AllowSpin = False
        Me.numKeisanKaisuTo.Spin.Increment = 0
        Me.numKeisanKaisuTo.Spin.SpinOnKeys = False
        Me.numKeisanKaisuTo.Spin.Wrap = False
        Me.numKeisanKaisuTo.TabIndex = 8
        Me.numKeisanKaisuTo.Value = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numKeisanKaisuTo.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKeisanKaisuFrom
        '
        Me.numKeisanKaisuFrom.AllowDeleteToNull = True
        Me.numKeisanKaisuFrom.ContentAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.numKeisanKaisuFrom.DropDown.AllowDrop = False
        Me.numKeisanKaisuFrom.Fields.DecimalPart.MaxDigits = 3
        Me.numKeisanKaisuFrom.Fields.IntegerPart.MaxDigits = 3
        Me.numKeisanKaisuFrom.Fields.IntegerPart.MinDigits = 1
        Me.numKeisanKaisuFrom.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKeisanKaisuFrom.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.numKeisanKaisuFrom.HighlightText = True
        Me.numKeisanKaisuFrom.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKeisanKaisuFrom.InputCheck = True
        Me.numKeisanKaisuFrom.Location = New System.Drawing.Point(174, 333)
        Me.numKeisanKaisuFrom.Name = "numKeisanKaisuFrom"
        Me.GcShortcut1.SetShortcuts(Me.numKeisanKaisuFrom, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKeisanKaisuFrom, Object), CType(Me.numKeisanKaisuFrom, Object), CType(Me.numKeisanKaisuFrom, Object), CType(Me.numKeisanKaisuFrom, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKeisanKaisuFrom.Size = New System.Drawing.Size(56, 20)
        Me.numKeisanKaisuFrom.Spin.AllowSpin = False
        Me.numKeisanKaisuFrom.Spin.Increment = 0
        Me.numKeisanKaisuFrom.Spin.SpinOnKeys = False
        Me.numKeisanKaisuFrom.Spin.Wrap = False
        Me.numKeisanKaisuFrom.TabIndex = 7
        Me.numKeisanKaisuFrom.Value = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numKeisanKaisuFrom.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'cmdPreview
        '
        Me.cmdPreview.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdPreview.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPreview.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdPreview.Location = New System.Drawing.Point(17, 6)
        Me.cmdPreview.Name = "cmdPreview"
        Me.cmdPreview.Size = New System.Drawing.Size(92, 44)
        Me.cmdPreview.TabIndex = 1
        Me.cmdPreview.Text = "プレビュー"
        Me.cmdPreview.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdCancel.Location = New System.Drawing.Point(213, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(92, 44)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(174, 230)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 15)
        Me.Label2.TabIndex = 965
        Me.Label2.Text = "第"
        '
        'chkIchiHen
        '
        Me.chkIchiHen.AutoSize = True
        Me.chkIchiHen.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkIchiHen.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkIchiHen.Location = New System.Drawing.Point(174, 174)
        Me.chkIchiHen.Name = "chkIchiHen"
        Me.chkIchiHen.Size = New System.Drawing.Size(153, 20)
        Me.chkIchiHen.TabIndex = 1
        Me.chkIchiHen.Text = "一部返還（積立金）"
        Me.chkIchiHen.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(45, 177)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 15)
        Me.Label7.TabIndex = 969
        Me.Label7.Text = "■対象データ"
        '
        'chkHenkan
        '
        Me.chkHenkan.AutoSize = True
        Me.chkHenkan.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkHenkan.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkHenkan.Location = New System.Drawing.Point(332, 174)
        Me.chkHenkan.Name = "chkHenkan"
        Me.chkHenkan.Size = New System.Drawing.Size(168, 20)
        Me.chkHenkan.TabIndex = 2
        Me.chkHenkan.Text = "全額返還（未継続者）"
        Me.chkHenkan.UseVisualStyleBackColor = True
        '
        'chkGojo
        '
        Me.chkGojo.AutoSize = True
        Me.chkGojo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkGojo.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkGojo.Location = New System.Drawing.Point(505, 174)
        Me.chkGojo.Name = "chkGojo"
        Me.chkGojo.Size = New System.Drawing.Size(239, 20)
        Me.chkGojo.TabIndex = 3
        Me.chkGojo.Text = "互助金支払（返還と同時は不可）"
        Me.chkGojo.UseVisualStyleBackColor = True
        '
        'grpTumi
        '
        Me.grpTumi.Controls.Add(Me.rdoSyusei)
        Me.grpTumi.Controls.Add(Me.rdoSyokai)
        Me.grpTumi.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpTumi.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpTumi.Location = New System.Drawing.Point(174, 111)
        Me.grpTumi.Name = "grpTumi"
        Me.grpTumi.Size = New System.Drawing.Size(275, 41)
        Me.grpTumi.TabIndex = 0
        Me.grpTumi.TabStop = False
        '
        'rdoSyusei
        '
        Me.rdoSyusei.AutoSize = True
        Me.rdoSyusei.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoSyusei.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoSyusei.Location = New System.Drawing.Point(142, 14)
        Me.rdoSyusei.Name = "rdoSyusei"
        Me.rdoSyusei.Size = New System.Drawing.Size(91, 20)
        Me.rdoSyusei.TabIndex = 1
        Me.rdoSyusei.Text = "修正発行"
        Me.rdoSyusei.UseVisualStyleBackColor = True
        '
        'rdoSyokai
        '
        Me.rdoSyokai.AutoSize = True
        Me.rdoSyokai.Checked = True
        Me.rdoSyokai.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoSyokai.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoSyokai.Location = New System.Drawing.Point(12, 14)
        Me.rdoSyokai.Name = "rdoSyokai"
        Me.rdoSyokai.Size = New System.Drawing.Size(91, 20)
        Me.rdoSyokai.TabIndex = 0
        Me.rdoSyokai.TabStop = True
        Me.rdoSyokai.Text = "初回発行"
        Me.rdoSyokai.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(45, 124)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 15)
        Me.Label18.TabIndex = 994
        Me.Label18.Text = "■出力区分"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(45, 283)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 15)
        Me.Label15.TabIndex = 988
        Me.Label15.Text = "■認定回数"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(242, 283)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(22, 15)
        Me.Label14.TabIndex = 989
        Me.Label14.Text = "～"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(242, 336)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 15)
        Me.Label3.TabIndex = 998
        Me.Label3.Text = "～"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(45, 336)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 997
        Me.Label4.Text = "■計算回数"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(316, 389)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(226, 15)
        Me.Label9.TabIndex = 999
        Me.Label9.Text = "（振込明細表に印字する日を入力）"
        '
        'frmGJ4060
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.numKeisanKaisuTo)
        Me.Controls.Add(Me.numKeisanKaisuFrom)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.grpTumi)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.numHasseiKaisuTo)
        Me.Controls.Add(Me.numHasseiKaisuFrom)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.chkGojo)
        Me.Controls.Add(Me.chkHenkan)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkIchiHen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dateFurikomiYmd)
        Me.Controls.Add(Me.numKI)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmGJ4060"
        Me.Text = "(GJ4060)互助金交付金融機関別振込明細表"
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.numKI, 0)
        Me.Controls.SetChildIndex(Me.dateFurikomiYmd, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.chkIchiHen, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.chkHenkan, 0)
        Me.Controls.SetChildIndex(Me.chkGojo, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.numHasseiKaisuFrom, 0)
        Me.Controls.SetChildIndex(Me.numHasseiKaisuTo, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.grpTumi, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.numKeisanKaisuFrom, 0)
        Me.Controls.SetChildIndex(Me.numKeisanKaisuTo, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateFurikomiYmd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHasseiKaisuFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHasseiKaisuTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKeisanKaisuTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKeisanKaisuFrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTumi.ResumeLayout(False)
        Me.grpTumi.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents numKI As JBD.Gjs.Win.GcNumber
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents dateFurikomiYmd As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cmdCancel As JBD.Gjs.Win.JButton
    Friend WithEvents cmdPreview As JBD.Gjs.Win.JButton
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GcDateValidator1 As GrapeCity.Win.Editors.GcDateValidator
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents chkHenkan As JBD.Gjs.Win.CheckBox
    Friend WithEvents chkGojo As JBD.Gjs.Win.CheckBox
    Friend WithEvents chkIchiHen As JBD.Gjs.Win.CheckBox
    Friend WithEvents grpTumi As JBD.Gjs.Win.GroupBox
    Friend WithEvents rdoSyusei As JBD.Gjs.Win.RadioButton
    Friend WithEvents rdoSyokai As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents numHasseiKaisuFrom As JBD.Gjs.Win.GcNumber
    Friend WithEvents numHasseiKaisuTo As JBD.Gjs.Win.GcNumber
    Friend WithEvents numKeisanKaisuTo As JBD.Gjs.Win.GcNumber
    Friend WithEvents numKeisanKaisuFrom As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents Label9 As JBD.Gjs.Win.Label

End Class
