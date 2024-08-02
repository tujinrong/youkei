Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ1030
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
        Me.dateTAISYOBI_Ymd = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cmdPreview = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdCancel = New JBD.Gjs.Win.JButton(Me.components)
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboKEIYAKU_KBN_Cd_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboKEIYAKU_KBN_Nm_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton9 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboKEIYAKU_KBN_Cd_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboKEIYAKU_KBN_Nm_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.chkSINKI = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.chkKEIZOKU = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.chkCYUSI = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.chkHAIGYO = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.cboKEIYAKUSYA_Cd_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboKEIYAKUSYA_Nm_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboKEIYAKUSYA_Cd_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboKEIYAKUSYA_Nm_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton5 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboITAKU_Cd_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboITAKU_Nm_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton6 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboITAKU_Cd_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboITAKU_Nm_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton7 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateTAISYOBI_Ymd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_KBN_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_KBN_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_KBN_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_KBN_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboITAKU_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboITAKU_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboITAKU_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboITAKU_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label5.Location = New System.Drawing.Point(45, 97)
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
        Me.Label6.Location = New System.Drawing.Point(236, 100)
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
        Me.Label8.Location = New System.Drawing.Point(45, 166)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 15)
        Me.Label8.TabIndex = 964
        Me.Label8.Text = "■対象日（現在）"
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
        Me.numKI.Location = New System.Drawing.Point(191, 97)
        Me.numKI.Name = "numKI"
        Me.GcShortcut1.SetShortcuts(Me.numKI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKI, Object), CType(Me.numKI, Object), CType(Me.numKI, Object), CType(Me.numKI, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKI.Size = New System.Drawing.Size(39, 20)
        Me.numKI.Spin.Increment = 0
        Me.numKI.TabIndex = 1
        ValueProcess1.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKI).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess1})
        InvalidRange1.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        InvalidRange1.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKI).AddRange(New Object() {InvalidRange1})
        Me.numKI.Value = New Decimal(New Integer() {99, 0, 0, 0})
        Me.numKI.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        Me.numKI.ZeroSuppress = True
        '
        'dateTAISYOBI_Ymd
        '
        Me.dateTAISYOBI_Ymd.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.dateTAISYOBI_Ymd.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.dateTAISYOBI_Ymd.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateTAISYOBI_Ymd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateTAISYOBI_Ymd.InputCheck = True
        Me.dateTAISYOBI_Ymd.Location = New System.Drawing.Point(166, 163)
        Me.dateTAISYOBI_Ymd.Name = "dateTAISYOBI_Ymd"
        Me.GcShortcut1.SetShortcuts(Me.dateTAISYOBI_Ymd, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateTAISYOBI_Ymd, Object), CType(Me.dateTAISYOBI_Ymd, Object), CType(Me.dateTAISYOBI_Ymd, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateTAISYOBI_Ymd.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.dateTAISYOBI_Ymd.Size = New System.Drawing.Size(124, 20)
        Me.dateTAISYOBI_Ymd.Spin.AllowSpin = False
        Me.dateTAISYOBI_Ymd.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateTAISYOBI_Ymd.TabIndex = 2
        Me.dateTAISYOBI_Ymd.Value = New Date(2015, 1, 15, 16, 13, 23, 0)
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'cmdPreview
        '
        Me.cmdPreview.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdPreview.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPreview.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdPreview.Location = New System.Drawing.Point(12, 6)
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
        Me.cmdCancel.Location = New System.Drawing.Point(119, 6)
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
        Me.Label2.Location = New System.Drawing.Point(163, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 15)
        Me.Label2.TabIndex = 965
        Me.Label2.Text = "第"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(45, 235)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 966
        Me.Label3.Text = "□契約区分"
        '
        'cboKEIYAKU_KBN_Cd_Fm
        '
        Me.cboKEIYAKU_KBN_Cd_Fm.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cboKEIYAKU_KBN_Cd_Fm.DropDown.AllowDrop = False
        Me.cboKEIYAKU_KBN_Cd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEIYAKU_KBN_Cd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEIYAKU_KBN_Cd_Fm.Format = "9"
        Me.cboKEIYAKU_KBN_Cd_Fm.HighlightText = True
        Me.cboKEIYAKU_KBN_Cd_Fm.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboKEIYAKU_KBN_Cd_Fm.ListHeaderPane.Height = 22
        Me.cboKEIYAKU_KBN_Cd_Fm.Location = New System.Drawing.Point(164, 232)
        Me.cboKEIYAKU_KBN_Cd_Fm.MaxLength = 1
        Me.cboKEIYAKU_KBN_Cd_Fm.Name = "cboKEIYAKU_KBN_Cd_Fm"
        Me.cboKEIYAKU_KBN_Cd_Fm.Size = New System.Drawing.Size(26, 22)
        Me.cboKEIYAKU_KBN_Cd_Fm.Spin.AllowSpin = False
        Me.cboKEIYAKU_KBN_Cd_Fm.TabIndex = 3
        Me.cboKEIYAKU_KBN_Cd_Fm.Tag = "契約区分"
        Me.cboKEIYAKU_KBN_Cd_Fm.Text = "9"
        '
        'cboKEIYAKU_KBN_Nm_Fm
        '
        Me.cboKEIYAKU_KBN_Nm_Fm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKEIYAKU_KBN_Nm_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEIYAKU_KBN_Nm_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEIYAKU_KBN_Nm_Fm.ListHeaderPane.Height = 22
        Me.cboKEIYAKU_KBN_Nm_Fm.ListHeaderPane.Visible = False
        Me.cboKEIYAKU_KBN_Nm_Fm.Location = New System.Drawing.Point(199, 232)
        Me.cboKEIYAKU_KBN_Nm_Fm.MaxLength = 8
        Me.cboKEIYAKU_KBN_Nm_Fm.Name = "cboKEIYAKU_KBN_Nm_Fm"
        Me.cboKEIYAKU_KBN_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton9})
        Me.cboKEIYAKU_KBN_Nm_Fm.Size = New System.Drawing.Size(106, 22)
        Me.cboKEIYAKU_KBN_Nm_Fm.TabIndex = 4
        Me.cboKEIYAKU_KBN_Nm_Fm.TabStop = False
        Me.cboKEIYAKU_KBN_Nm_Fm.Tag = "契約区分名"
        '
        'DropDownButton9
        '
        Me.DropDownButton9.Name = "DropDownButton9"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(311, 235)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 15)
        Me.Label4.TabIndex = 967
        Me.Label4.Text = "～"
        '
        'cboKEIYAKU_KBN_Cd_To
        '
        Me.cboKEIYAKU_KBN_Cd_To.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cboKEIYAKU_KBN_Cd_To.DropDown.AllowDrop = False
        Me.cboKEIYAKU_KBN_Cd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEIYAKU_KBN_Cd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEIYAKU_KBN_Cd_To.Format = "9"
        Me.cboKEIYAKU_KBN_Cd_To.HighlightText = True
        Me.cboKEIYAKU_KBN_Cd_To.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboKEIYAKU_KBN_Cd_To.ListHeaderPane.Height = 22
        Me.cboKEIYAKU_KBN_Cd_To.Location = New System.Drawing.Point(342, 232)
        Me.cboKEIYAKU_KBN_Cd_To.MaxLength = 1
        Me.cboKEIYAKU_KBN_Cd_To.Name = "cboKEIYAKU_KBN_Cd_To"
        Me.cboKEIYAKU_KBN_Cd_To.Size = New System.Drawing.Size(26, 22)
        Me.cboKEIYAKU_KBN_Cd_To.Spin.AllowSpin = False
        Me.cboKEIYAKU_KBN_Cd_To.TabIndex = 5
        Me.cboKEIYAKU_KBN_Cd_To.Tag = "契約区分"
        Me.cboKEIYAKU_KBN_Cd_To.Text = "9"
        '
        'cboKEIYAKU_KBN_Nm_To
        '
        Me.cboKEIYAKU_KBN_Nm_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKEIYAKU_KBN_Nm_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEIYAKU_KBN_Nm_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEIYAKU_KBN_Nm_To.ListHeaderPane.Height = 22
        Me.cboKEIYAKU_KBN_Nm_To.ListHeaderPane.Visible = False
        Me.cboKEIYAKU_KBN_Nm_To.Location = New System.Drawing.Point(377, 232)
        Me.cboKEIYAKU_KBN_Nm_To.MaxLength = 8
        Me.cboKEIYAKU_KBN_Nm_To.Name = "cboKEIYAKU_KBN_Nm_To"
        Me.cboKEIYAKU_KBN_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cboKEIYAKU_KBN_Nm_To.Size = New System.Drawing.Size(106, 22)
        Me.cboKEIYAKU_KBN_Nm_To.TabIndex = 6
        Me.cboKEIYAKU_KBN_Nm_To.TabStop = False
        Me.cboKEIYAKU_KBN_Nm_To.Tag = "契約区分名"
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'chkSINKI
        '
        Me.chkSINKI.AutoSize = True
        Me.chkSINKI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkSINKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkSINKI.Location = New System.Drawing.Point(166, 302)
        Me.chkSINKI.Name = "chkSINKI"
        Me.chkSINKI.Size = New System.Drawing.Size(107, 20)
        Me.chkSINKI.TabIndex = 7
        Me.chkSINKI.Text = "新規契約者"
        Me.chkSINKI.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(45, 304)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 15)
        Me.Label7.TabIndex = 969
        Me.Label7.Text = "■契約状況"
        '
        'chkKEIZOKU
        '
        Me.chkKEIZOKU.AutoSize = True
        Me.chkKEIZOKU.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkKEIZOKU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkKEIZOKU.Location = New System.Drawing.Point(267, 302)
        Me.chkKEIZOKU.Name = "chkKEIZOKU"
        Me.chkKEIZOKU.Size = New System.Drawing.Size(107, 20)
        Me.chkKEIZOKU.TabIndex = 8
        Me.chkKEIZOKU.Text = "継続契約者"
        Me.chkKEIZOKU.UseVisualStyleBackColor = True
        '
        'chkCYUSI
        '
        Me.chkCYUSI.AutoSize = True
        Me.chkCYUSI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkCYUSI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkCYUSI.Location = New System.Drawing.Point(365, 304)
        Me.chkCYUSI.Name = "chkCYUSI"
        Me.chkCYUSI.Size = New System.Drawing.Size(77, 20)
        Me.chkCYUSI.TabIndex = 9
        Me.chkCYUSI.Text = "中止者"
        Me.chkCYUSI.UseVisualStyleBackColor = True
        '
        'chkHAIGYO
        '
        Me.chkHAIGYO.AutoSize = True
        Me.chkHAIGYO.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkHAIGYO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkHAIGYO.Location = New System.Drawing.Point(435, 304)
        Me.chkHAIGYO.Name = "chkHAIGYO"
        Me.chkHAIGYO.Size = New System.Drawing.Size(77, 20)
        Me.chkHAIGYO.TabIndex = 10
        Me.chkHAIGYO.Text = "廃業者"
        Me.chkHAIGYO.UseVisualStyleBackColor = True
        '
        'cboKEIYAKUSYA_Cd_To
        '
        Me.cboKEIYAKUSYA_Cd_To.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cboKEIYAKUSYA_Cd_To.DropDown.AllowDrop = False
        Me.cboKEIYAKUSYA_Cd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEIYAKUSYA_Cd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEIYAKUSYA_Cd_To.Format = "9"
        Me.cboKEIYAKUSYA_Cd_To.HighlightText = True
        Me.cboKEIYAKUSYA_Cd_To.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboKEIYAKUSYA_Cd_To.ListHeaderPane.Height = 22
        Me.cboKEIYAKUSYA_Cd_To.Location = New System.Drawing.Point(477, 466)
        Me.cboKEIYAKUSYA_Cd_To.MaxLength = 5
        Me.cboKEIYAKUSYA_Cd_To.Name = "cboKEIYAKUSYA_Cd_To"
        Me.cboKEIYAKUSYA_Cd_To.Size = New System.Drawing.Size(53, 22)
        Me.cboKEIYAKUSYA_Cd_To.Spin.AllowSpin = False
        Me.cboKEIYAKUSYA_Cd_To.TabIndex = 17
        Me.cboKEIYAKUSYA_Cd_To.Tag = "契約者番号"
        Me.cboKEIYAKUSYA_Cd_To.Text = "99999"
        '
        'cboKEIYAKUSYA_Nm_To
        '
        Me.cboKEIYAKUSYA_Nm_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKEIYAKUSYA_Nm_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEIYAKUSYA_Nm_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEIYAKUSYA_Nm_To.ListHeaderPane.Height = 22
        Me.cboKEIYAKUSYA_Nm_To.ListHeaderPane.Visible = False
        Me.cboKEIYAKUSYA_Nm_To.Location = New System.Drawing.Point(537, 467)
        Me.cboKEIYAKUSYA_Nm_To.MaxLength = 50
        Me.cboKEIYAKUSYA_Nm_To.Name = "cboKEIYAKUSYA_Nm_To"
        Me.cboKEIYAKUSYA_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.cboKEIYAKUSYA_Nm_To.Size = New System.Drawing.Size(390, 22)
        Me.cboKEIYAKUSYA_Nm_To.TabIndex = 18
        Me.cboKEIYAKUSYA_Nm_To.TabStop = False
        Me.cboKEIYAKUSYA_Nm_To.Tag = "契約者名"
        '
        'DropDownButton3
        '
        Me.DropDownButton3.Name = "DropDownButton3"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(449, 473)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 15)
        Me.Label9.TabIndex = 975
        Me.Label9.Text = "～"
        '
        'cboKEIYAKUSYA_Cd_Fm
        '
        Me.cboKEIYAKUSYA_Cd_Fm.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cboKEIYAKUSYA_Cd_Fm.DropDown.AllowDrop = False
        Me.cboKEIYAKUSYA_Cd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEIYAKUSYA_Cd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEIYAKUSYA_Cd_Fm.Format = "9"
        Me.cboKEIYAKUSYA_Cd_Fm.HighlightText = True
        Me.cboKEIYAKUSYA_Cd_Fm.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboKEIYAKUSYA_Cd_Fm.ListHeaderPane.Height = 22
        Me.cboKEIYAKUSYA_Cd_Fm.Location = New System.Drawing.Point(163, 439)
        Me.cboKEIYAKUSYA_Cd_Fm.MaxLength = 5
        Me.cboKEIYAKUSYA_Cd_Fm.Name = "cboKEIYAKUSYA_Cd_Fm"
        Me.cboKEIYAKUSYA_Cd_Fm.Size = New System.Drawing.Size(51, 22)
        Me.cboKEIYAKUSYA_Cd_Fm.Spin.AllowSpin = False
        Me.cboKEIYAKUSYA_Cd_Fm.TabIndex = 15
        Me.cboKEIYAKUSYA_Cd_Fm.Tag = "契約者番号"
        Me.cboKEIYAKUSYA_Cd_Fm.Text = "99999"
        '
        'cboKEIYAKUSYA_Nm_Fm
        '
        Me.cboKEIYAKUSYA_Nm_Fm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKEIYAKUSYA_Nm_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEIYAKUSYA_Nm_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEIYAKUSYA_Nm_Fm.ListHeaderPane.Height = 22
        Me.cboKEIYAKUSYA_Nm_Fm.ListHeaderPane.Visible = False
        Me.cboKEIYAKUSYA_Nm_Fm.Location = New System.Drawing.Point(223, 439)
        Me.cboKEIYAKUSYA_Nm_Fm.MaxLength = 50
        Me.cboKEIYAKUSYA_Nm_Fm.Name = "cboKEIYAKUSYA_Nm_Fm"
        Me.cboKEIYAKUSYA_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.cboKEIYAKUSYA_Nm_Fm.Size = New System.Drawing.Size(391, 22)
        Me.cboKEIYAKUSYA_Nm_Fm.TabIndex = 16
        Me.cboKEIYAKUSYA_Nm_Fm.TabStop = False
        Me.cboKEIYAKUSYA_Nm_Fm.Tag = "契約者名"
        '
        'DropDownButton5
        '
        Me.DropDownButton5.Name = "DropDownButton5"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(45, 442)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 15)
        Me.Label10.TabIndex = 974
        Me.Label10.Text = "□契約者番号"
        '
        'cboITAKU_Cd_To
        '
        Me.cboITAKU_Cd_To.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cboITAKU_Cd_To.DropDown.AllowDrop = False
        Me.cboITAKU_Cd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboITAKU_Cd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboITAKU_Cd_To.Format = "9"
        Me.cboITAKU_Cd_To.HighlightText = True
        Me.cboITAKU_Cd_To.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboITAKU_Cd_To.ListHeaderPane.Height = 22
        Me.cboITAKU_Cd_To.Location = New System.Drawing.Point(478, 399)
        Me.cboITAKU_Cd_To.MaxLength = 3
        Me.cboITAKU_Cd_To.Name = "cboITAKU_Cd_To"
        Me.cboITAKU_Cd_To.Size = New System.Drawing.Size(53, 22)
        Me.cboITAKU_Cd_To.Spin.AllowSpin = False
        Me.cboITAKU_Cd_To.TabIndex = 13
        Me.cboITAKU_Cd_To.Tag = "事務委託先"
        Me.cboITAKU_Cd_To.Text = "999"
        '
        'cboITAKU_Nm_To
        '
        Me.cboITAKU_Nm_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboITAKU_Nm_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboITAKU_Nm_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboITAKU_Nm_To.ListHeaderPane.Height = 22
        Me.cboITAKU_Nm_To.ListHeaderPane.Visible = False
        Me.cboITAKU_Nm_To.Location = New System.Drawing.Point(537, 399)
        Me.cboITAKU_Nm_To.MaxLength = 50
        Me.cboITAKU_Nm_To.Name = "cboITAKU_Nm_To"
        Me.cboITAKU_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.cboITAKU_Nm_To.Size = New System.Drawing.Size(391, 22)
        Me.cboITAKU_Nm_To.TabIndex = 14
        Me.cboITAKU_Nm_To.TabStop = False
        Me.cboITAKU_Nm_To.Tag = "事務委託先名"
        '
        'DropDownButton6
        '
        Me.DropDownButton6.Name = "DropDownButton6"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(450, 402)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 15)
        Me.Label11.TabIndex = 981
        Me.Label11.Text = "～"
        '
        'cboITAKU_Cd_Fm
        '
        Me.cboITAKU_Cd_Fm.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cboITAKU_Cd_Fm.DropDown.AllowDrop = False
        Me.cboITAKU_Cd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboITAKU_Cd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboITAKU_Cd_Fm.Format = "9"
        Me.cboITAKU_Cd_Fm.HighlightText = True
        Me.cboITAKU_Cd_Fm.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboITAKU_Cd_Fm.ListHeaderPane.Height = 22
        Me.cboITAKU_Cd_Fm.Location = New System.Drawing.Point(163, 370)
        Me.cboITAKU_Cd_Fm.MaxLength = 3
        Me.cboITAKU_Cd_Fm.Name = "cboITAKU_Cd_Fm"
        Me.cboITAKU_Cd_Fm.Size = New System.Drawing.Size(51, 22)
        Me.cboITAKU_Cd_Fm.Spin.AllowSpin = False
        Me.cboITAKU_Cd_Fm.TabIndex = 11
        Me.cboITAKU_Cd_Fm.Tag = "事務委託先"
        Me.cboITAKU_Cd_Fm.Text = "999"
        '
        'cboITAKU_Nm_Fm
        '
        Me.cboITAKU_Nm_Fm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboITAKU_Nm_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboITAKU_Nm_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboITAKU_Nm_Fm.ListHeaderPane.Height = 22
        Me.cboITAKU_Nm_Fm.ListHeaderPane.Visible = False
        Me.cboITAKU_Nm_Fm.Location = New System.Drawing.Point(223, 370)
        Me.cboITAKU_Nm_Fm.MaxLength = 50
        Me.cboITAKU_Nm_Fm.Name = "cboITAKU_Nm_Fm"
        Me.cboITAKU_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton7})
        Me.cboITAKU_Nm_Fm.Size = New System.Drawing.Size(391, 22)
        Me.cboITAKU_Nm_Fm.TabIndex = 12
        Me.cboITAKU_Nm_Fm.TabStop = False
        Me.cboITAKU_Nm_Fm.Tag = "事務委託先名"
        '
        'DropDownButton7
        '
        Me.DropDownButton7.Name = "DropDownButton7"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(45, 373)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 15)
        Me.Label12.TabIndex = 980
        Me.Label12.Text = "□事務委託先"
        '
        'frmGJ1030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.cboITAKU_Cd_To)
        Me.Controls.Add(Me.cboITAKU_Nm_To)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cboITAKU_Cd_Fm)
        Me.Controls.Add(Me.cboITAKU_Nm_Fm)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cboKEIYAKUSYA_Cd_To)
        Me.Controls.Add(Me.cboKEIYAKUSYA_Nm_To)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboKEIYAKUSYA_Cd_Fm)
        Me.Controls.Add(Me.cboKEIYAKUSYA_Nm_Fm)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.chkHAIGYO)
        Me.Controls.Add(Me.chkCYUSI)
        Me.Controls.Add(Me.chkKEIZOKU)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkSINKI)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Cd_To)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Nm_To)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Cd_Fm)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Nm_Fm)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dateTAISYOBI_Ymd)
        Me.Controls.Add(Me.numKI)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmGJ1030"
        Me.Text = "(GJ1030)契約者一覧（連絡用）"
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.numKI, 0)
        Me.Controls.SetChildIndex(Me.dateTAISYOBI_Ymd, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Cd_To, 0)
        Me.Controls.SetChildIndex(Me.chkSINKI, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.chkKEIZOKU, 0)
        Me.Controls.SetChildIndex(Me.chkCYUSI, 0)
        Me.Controls.SetChildIndex(Me.chkHAIGYO, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKUSYA_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKUSYA_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKUSYA_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKUSYA_Cd_To, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.cboITAKU_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboITAKU_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.cboITAKU_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.cboITAKU_Cd_To, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateTAISYOBI_Ymd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_KBN_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_KBN_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_KBN_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_KBN_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboITAKU_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboITAKU_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboITAKU_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboITAKU_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents numKI As JBD.Gjs.Win.GcNumber
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents dateTAISYOBI_Ymd As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cmdCancel As JBD.Gjs.Win.JButton
    Friend WithEvents cmdPreview As JBD.Gjs.Win.JButton
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GcDateValidator1 As GrapeCity.Win.Editors.GcDateValidator
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents cboKEIYAKU_KBN_Cd_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEIYAKU_KBN_Nm_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton9 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents cboKEIYAKU_KBN_Cd_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEIYAKU_KBN_Nm_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents chkSINKI As JBD.Gjs.Win.CheckBox
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents chkKEIZOKU As JBD.Gjs.Win.CheckBox
    Friend WithEvents chkCYUSI As JBD.Gjs.Win.CheckBox
    Friend WithEvents chkHAIGYO As JBD.Gjs.Win.CheckBox
    Friend WithEvents cboKEIYAKUSYA_Cd_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEIYAKUSYA_Nm_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents cboKEIYAKUSYA_Cd_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEIYAKUSYA_Nm_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton5 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents cboITAKU_Cd_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboITAKU_Nm_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton6 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents cboITAKU_Cd_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboITAKU_Nm_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton7 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label12 As JBD.Gjs.Win.Label

End Class
