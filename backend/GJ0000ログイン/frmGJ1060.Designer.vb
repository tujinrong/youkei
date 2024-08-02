Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ1060
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
        Me.numKI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.dateTAISYOBI_Ymd = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton6 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cmdExcel = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdCancel = New JBD.Gjs.Win.JButton(Me.components)
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboKEIYAKUSYA_Cd_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboKEIYAKUSYA_Nm_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboKEIYAKUSYA_Cd_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboKEIYAKUSYA_Nm_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton5 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboKEN_Cd_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboKEN_Nm_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboKEN_Cd_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboKEN_Nm_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton8 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.rdoKEIYAKU_KEI = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rdoKEI = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.PrgBar = New System.Windows.Forms.ProgressBar()
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.chkIGAI = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.chkKIGYOU = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.chkKAZOKU = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateTAISYOBI_Ymd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEN_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEN_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEN_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEN_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdCancel)
        Me.pnlButton.Controls.Add(Me.cmdExcel)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdExcel, 0)
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
        Me.Label5.Location = New System.Drawing.Point(45, 118)
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
        Me.Label6.Location = New System.Drawing.Point(283, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 15)
        Me.Label6.TabIndex = 958
        Me.Label6.Text = "期"
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
        Me.numKI.Location = New System.Drawing.Point(238, 115)
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
        Me.dateTAISYOBI_Ymd.Location = New System.Drawing.Point(217, 244)
        Me.dateTAISYOBI_Ymd.Name = "dateTAISYOBI_Ymd"
        Me.GcShortcut1.SetShortcuts(Me.dateTAISYOBI_Ymd, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateTAISYOBI_Ymd, Object), CType(Me.dateTAISYOBI_Ymd, Object), CType(Me.dateTAISYOBI_Ymd, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateTAISYOBI_Ymd.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.dateTAISYOBI_Ymd.Size = New System.Drawing.Size(124, 20)
        Me.dateTAISYOBI_Ymd.Spin.AllowSpin = False
        Me.dateTAISYOBI_Ymd.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateTAISYOBI_Ymd.TabIndex = 4
        Me.dateTAISYOBI_Ymd.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton6
        '
        Me.DropDownButton6.Name = "DropDownButton6"
        '
        'cmdExcel
        '
        Me.cmdExcel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdExcel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdExcel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdExcel.Location = New System.Drawing.Point(12, 6)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(92, 44)
        Me.cmdExcel.TabIndex = 1
        Me.cmdExcel.Text = "EXCEL出力"
        Me.cmdExcel.UseVisualStyleBackColor = False
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
        Me.Label2.Location = New System.Drawing.Point(214, 118)
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
        Me.Label3.Location = New System.Drawing.Point(45, 314)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 966
        Me.Label3.Text = "□契約区分"
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
        Me.cboKEIYAKUSYA_Cd_To.Location = New System.Drawing.Point(478, 489)
        Me.cboKEIYAKUSYA_Cd_To.MaxLength = 5
        Me.cboKEIYAKUSYA_Cd_To.Name = "cboKEIYAKUSYA_Cd_To"
        Me.cboKEIYAKUSYA_Cd_To.Size = New System.Drawing.Size(53, 22)
        Me.cboKEIYAKUSYA_Cd_To.Spin.AllowSpin = False
        Me.cboKEIYAKUSYA_Cd_To.TabIndex = 16
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
        Me.cboKEIYAKUSYA_Nm_To.Location = New System.Drawing.Point(538, 490)
        Me.cboKEIYAKUSYA_Nm_To.MaxLength = 50
        Me.cboKEIYAKUSYA_Nm_To.Name = "cboKEIYAKUSYA_Nm_To"
        Me.cboKEIYAKUSYA_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.cboKEIYAKUSYA_Nm_To.Size = New System.Drawing.Size(390, 22)
        Me.cboKEIYAKUSYA_Nm_To.TabIndex = 17
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
        Me.Label9.Location = New System.Drawing.Point(450, 496)
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
        Me.cboKEIYAKUSYA_Cd_Fm.Location = New System.Drawing.Point(217, 453)
        Me.cboKEIYAKUSYA_Cd_Fm.MaxLength = 5
        Me.cboKEIYAKUSYA_Cd_Fm.Name = "cboKEIYAKUSYA_Cd_Fm"
        Me.cboKEIYAKUSYA_Cd_Fm.Size = New System.Drawing.Size(51, 22)
        Me.cboKEIYAKUSYA_Cd_Fm.Spin.AllowSpin = False
        Me.cboKEIYAKUSYA_Cd_Fm.TabIndex = 14
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
        Me.cboKEIYAKUSYA_Nm_Fm.Location = New System.Drawing.Point(277, 453)
        Me.cboKEIYAKUSYA_Nm_Fm.MaxLength = 50
        Me.cboKEIYAKUSYA_Nm_Fm.Name = "cboKEIYAKUSYA_Nm_Fm"
        Me.cboKEIYAKUSYA_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.cboKEIYAKUSYA_Nm_Fm.Size = New System.Drawing.Size(391, 22)
        Me.cboKEIYAKUSYA_Nm_Fm.TabIndex = 15
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
        Me.Label10.Location = New System.Drawing.Point(45, 456)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 15)
        Me.Label10.TabIndex = 974
        Me.Label10.Text = "□契約者番号"
        '
        'cboKEN_Cd_To
        '
        Me.cboKEN_Cd_To.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cboKEN_Cd_To.DropDown.AllowDrop = False
        Me.cboKEN_Cd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEN_Cd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEN_Cd_To.Format = "9"
        Me.cboKEN_Cd_To.HighlightText = True
        Me.cboKEN_Cd_To.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboKEN_Cd_To.ListHeaderPane.Height = 22
        Me.cboKEN_Cd_To.Location = New System.Drawing.Point(398, 384)
        Me.cboKEN_Cd_To.MaxLength = 2
        Me.cboKEN_Cd_To.Name = "cboKEN_Cd_To"
        Me.cboKEN_Cd_To.Size = New System.Drawing.Size(26, 22)
        Me.cboKEN_Cd_To.Spin.AllowSpin = False
        Me.cboKEN_Cd_To.TabIndex = 12
        Me.cboKEN_Cd_To.Tag = "都道府県"
        Me.cboKEN_Cd_To.Text = "99"
        '
        'cboKEN_Nm_To
        '
        Me.cboKEN_Nm_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKEN_Nm_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEN_Nm_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEN_Nm_To.ListHeaderPane.Height = 22
        Me.cboKEN_Nm_To.ListHeaderPane.Visible = False
        Me.cboKEN_Nm_To.Location = New System.Drawing.Point(433, 384)
        Me.cboKEN_Nm_To.MaxLength = 8
        Me.cboKEN_Nm_To.Name = "cboKEN_Nm_To"
        Me.cboKEN_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.cboKEN_Nm_To.Size = New System.Drawing.Size(90, 22)
        Me.cboKEN_Nm_To.TabIndex = 13
        Me.cboKEN_Nm_To.TabStop = False
        Me.cboKEN_Nm_To.Tag = "都道府県名"
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(368, 387)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 15)
        Me.Label8.TabIndex = 992
        Me.Label8.Text = "～"
        '
        'cboKEN_Cd_Fm
        '
        Me.cboKEN_Cd_Fm.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cboKEN_Cd_Fm.DropDown.AllowDrop = False
        Me.cboKEN_Cd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEN_Cd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEN_Cd_Fm.Format = "9"
        Me.cboKEN_Cd_Fm.HighlightText = True
        Me.cboKEN_Cd_Fm.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboKEN_Cd_Fm.ListHeaderPane.Height = 22
        Me.cboKEN_Cd_Fm.Location = New System.Drawing.Point(217, 380)
        Me.cboKEN_Cd_Fm.MaxLength = 2
        Me.cboKEN_Cd_Fm.Name = "cboKEN_Cd_Fm"
        Me.cboKEN_Cd_Fm.Size = New System.Drawing.Size(26, 22)
        Me.cboKEN_Cd_Fm.Spin.AllowSpin = False
        Me.cboKEN_Cd_Fm.TabIndex = 10
        Me.cboKEN_Cd_Fm.Tag = "都道府県"
        Me.cboKEN_Cd_Fm.Text = "99"
        '
        'cboKEN_Nm_Fm
        '
        Me.cboKEN_Nm_Fm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKEN_Nm_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEN_Nm_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEN_Nm_Fm.ListHeaderPane.Height = 22
        Me.cboKEN_Nm_Fm.ListHeaderPane.Visible = False
        Me.cboKEN_Nm_Fm.Location = New System.Drawing.Point(249, 380)
        Me.cboKEN_Nm_Fm.MaxLength = 8
        Me.cboKEN_Nm_Fm.Name = "cboKEN_Nm_Fm"
        Me.cboKEN_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton8})
        Me.cboKEN_Nm_Fm.Size = New System.Drawing.Size(90, 22)
        Me.cboKEN_Nm_Fm.TabIndex = 11
        Me.cboKEN_Nm_Fm.TabStop = False
        Me.cboKEN_Nm_Fm.Tag = "都道府県名"
        '
        'DropDownButton8
        '
        Me.DropDownButton8.Name = "DropDownButton8"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(45, 383)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 15)
        Me.Label13.TabIndex = 991
        Me.Label13.Text = "□都道府県"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(45, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 15)
        Me.Label7.TabIndex = 993
        Me.Label7.Text = "■出力区分"
        '
        'rdoKEIYAKU_KEI
        '
        Me.rdoKEIYAKU_KEI.AutoSize = True
        Me.rdoKEIYAKU_KEI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoKEIYAKU_KEI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoKEIYAKU_KEI.Location = New System.Drawing.Point(217, 176)
        Me.rdoKEIYAKU_KEI.Name = "rdoKEIYAKU_KEI"
        Me.rdoKEIYAKU_KEI.Size = New System.Drawing.Size(121, 20)
        Me.rdoKEIYAKU_KEI.TabIndex = 2
        Me.rdoKEIYAKU_KEI.TabStop = True
        Me.rdoKEIYAKU_KEI.Text = "契約者＆合計"
        Me.rdoKEIYAKU_KEI.UseVisualStyleBackColor = True
        '
        'rdoKEI
        '
        Me.rdoKEI.AutoSize = True
        Me.rdoKEI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoKEI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoKEI.Location = New System.Drawing.Point(340, 176)
        Me.rdoKEI.Name = "rdoKEI"
        Me.rdoKEI.Size = New System.Drawing.Size(61, 20)
        Me.rdoKEI.TabIndex = 3
        Me.rdoKEI.TabStop = True
        Me.rdoKEI.Text = "合計"
        Me.rdoKEI.UseVisualStyleBackColor = True
        '
        'PrgBar
        '
        Me.PrgBar.Location = New System.Drawing.Point(9, 620)
        Me.PrgBar.Name = "PrgBar"
        Me.PrgBar.Size = New System.Drawing.Size(980, 10)
        Me.PrgBar.TabIndex = 1002
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(45, 247)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 15)
        Me.Label11.TabIndex = 1004
        Me.Label11.Text = "■指定日"
        '
        'chkIGAI
        '
        Me.chkIGAI.AutoSize = True
        Me.chkIGAI.Checked = True
        Me.chkIGAI.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIGAI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkIGAI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkIGAI.Location = New System.Drawing.Point(416, 313)
        Me.chkIGAI.Name = "chkIGAI"
        Me.chkIGAI.Size = New System.Drawing.Size(77, 20)
        Me.chkIGAI.TabIndex = 7
        Me.chkIGAI.Text = "鶏以外"
        Me.chkIGAI.UseVisualStyleBackColor = True
        '
        'chkKIGYOU
        '
        Me.chkKIGYOU.AutoSize = True
        Me.chkKIGYOU.Checked = True
        Me.chkKIGYOU.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkKIGYOU.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkKIGYOU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkKIGYOU.Location = New System.Drawing.Point(318, 312)
        Me.chkKIGYOU.Name = "chkKIGYOU"
        Me.chkKIGYOU.Size = New System.Drawing.Size(62, 20)
        Me.chkKIGYOU.TabIndex = 6
        Me.chkKIGYOU.Text = "企業"
        Me.chkKIGYOU.UseVisualStyleBackColor = True
        '
        'chkKAZOKU
        '
        Me.chkKAZOKU.AutoSize = True
        Me.chkKAZOKU.Checked = True
        Me.chkKAZOKU.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkKAZOKU.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkKAZOKU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkKAZOKU.Location = New System.Drawing.Point(217, 312)
        Me.chkKAZOKU.Name = "chkKAZOKU"
        Me.chkKAZOKU.Size = New System.Drawing.Size(62, 20)
        Me.chkKAZOKU.TabIndex = 5
        Me.chkKAZOKU.Text = "家族"
        Me.chkKAZOKU.UseVisualStyleBackColor = True
        '
        'frmGJ1060
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.chkIGAI)
        Me.Controls.Add(Me.chkKIGYOU)
        Me.Controls.Add(Me.chkKAZOKU)
        Me.Controls.Add(Me.dateTAISYOBI_Ymd)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.PrgBar)
        Me.Controls.Add(Me.rdoKEI)
        Me.Controls.Add(Me.rdoKEIYAKU_KEI)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboKEN_Cd_To)
        Me.Controls.Add(Me.cboKEN_Nm_To)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboKEN_Cd_Fm)
        Me.Controls.Add(Me.cboKEN_Nm_Fm)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cboKEIYAKUSYA_Cd_To)
        Me.Controls.Add(Me.cboKEIYAKUSYA_Nm_To)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboKEIYAKUSYA_Cd_Fm)
        Me.Controls.Add(Me.cboKEIYAKUSYA_Nm_Fm)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numKI)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmGJ1060"
        Me.Text = "(GJ1060)家畜防疫互助基金事業状況表作成処理"
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.numKI, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKUSYA_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKUSYA_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKUSYA_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKUSYA_Cd_To, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.cboKEN_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboKEN_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.cboKEN_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.cboKEN_Cd_To, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.rdoKEIYAKU_KEI, 0)
        Me.Controls.SetChildIndex(Me.rdoKEI, 0)
        Me.Controls.SetChildIndex(Me.PrgBar, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.dateTAISYOBI_Ymd, 0)
        Me.Controls.SetChildIndex(Me.chkKAZOKU, 0)
        Me.Controls.SetChildIndex(Me.chkKIGYOU, 0)
        Me.Controls.SetChildIndex(Me.chkIGAI, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateTAISYOBI_Ymd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEN_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEN_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEN_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEN_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents numKI As JBD.Gjs.Win.GcNumber
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents cmdCancel As JBD.Gjs.Win.JButton
    Friend WithEvents cmdExcel As JBD.Gjs.Win.JButton
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GcDateValidator1 As GrapeCity.Win.Editors.GcDateValidator
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents cboKEIYAKUSYA_Cd_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEIYAKUSYA_Nm_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents cboKEIYAKUSYA_Cd_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEIYAKUSYA_Nm_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton5 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents cboKEN_Cd_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEN_Nm_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents cboKEN_Cd_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEN_Nm_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton8 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents rdoKEIYAKU_KEI As JBD.Gjs.Win.RadioButton
    Friend WithEvents rdoKEI As JBD.Gjs.Win.RadioButton
    Friend WithEvents PrgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents dateTAISYOBI_Ymd As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton6 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents chkIGAI As JBD.Gjs.Win.CheckBox
    Friend WithEvents chkKIGYOU As JBD.Gjs.Win.CheckBox
    Friend WithEvents chkKAZOKU As JBD.Gjs.Win.CheckBox
End Class
