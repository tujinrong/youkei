Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ1040
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
        Dim DateEraField2 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField4 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField2 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField5 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField2 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField6 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField2 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateEraField3 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField7 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField3 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField8 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField3 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField9 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField3 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateEraField4 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField10 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField4 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField11 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField4 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField12 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField4 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateEraField5 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField13 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField5 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField14 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField5 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField15 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField5 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateEraField6 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField16 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField6 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField17 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField6 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField18 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField6 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.numKI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.dateNYURYOKU_Ymd_Fm = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dateNYURYOKU_Ymd_To = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton8 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dateKOSHIN_Ymd_To = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton12 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dateKOSHIN_Ymd_Fm = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton13 = New GrapeCity.Win.Editors.DropDownButton()
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
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.chkNYURYOKU_CYU = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.chkNYURYOKU_KAKUTEI = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.cboUSER_Cd_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboUSER_Nm_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton10 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cboUSER_Cd_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboUSER_Nm_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton11 = New GrapeCity.Win.Editors.DropDownButton()
        Me.rdoKOSHIN_HANI = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rdoTOROKU_HANI = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkKEIYAKUDATENASHI = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.chkKEIYAKUDATEARI = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.dateKEIYAKU_Ymd_To = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton16 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dateKEIYAKU_Ymd_Fm = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton17 = New GrapeCity.Win.Editors.DropDownButton()
        Me.pnlButton.SuspendLayout()
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateNYURYOKU_Ymd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateNYURYOKU_Ymd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateKOSHIN_Ymd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateKOSHIN_Ymd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.cboUSER_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUSER_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUSER_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUSER_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateKEIYAKU_Ymd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateKEIYAKU_Ymd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label5.Location = New System.Drawing.Point(45, 76)
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
        Me.Label6.Location = New System.Drawing.Point(233, 76)
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
        Me.Label8.Location = New System.Drawing.Point(45, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 15)
        Me.Label8.TabIndex = 964
        Me.Label8.Text = "■"
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
        Me.numKI.Location = New System.Drawing.Point(188, 73)
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
        'dateNYURYOKU_Ymd_Fm
        '
        Me.dateNYURYOKU_Ymd_Fm.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.dateNYURYOKU_Ymd_Fm.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.dateNYURYOKU_Ymd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateNYURYOKU_Ymd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateNYURYOKU_Ymd_Fm.InputCheck = True
        Me.dateNYURYOKU_Ymd_Fm.Location = New System.Drawing.Point(189, 121)
        Me.dateNYURYOKU_Ymd_Fm.Name = "dateNYURYOKU_Ymd_Fm"
        Me.GcShortcut1.SetShortcuts(Me.dateNYURYOKU_Ymd_Fm, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateNYURYOKU_Ymd_Fm, Object), CType(Me.dateNYURYOKU_Ymd_Fm, Object), CType(Me.dateNYURYOKU_Ymd_Fm, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateNYURYOKU_Ymd_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.dateNYURYOKU_Ymd_Fm.Size = New System.Drawing.Size(124, 20)
        Me.dateNYURYOKU_Ymd_Fm.Spin.AllowSpin = False
        Me.dateNYURYOKU_Ymd_Fm.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateNYURYOKU_Ymd_Fm.TabIndex = 3
        Me.dateNYURYOKU_Ymd_Fm.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'dateNYURYOKU_Ymd_To
        '
        Me.dateNYURYOKU_Ymd_To.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField5.Text = "/"
        DateLiteralField6.Text = "/"
        Me.dateNYURYOKU_Ymd_To.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateLiteralField4, DateEraYearField2, DateLiteralField5, DateMonthField2, DateLiteralField6, DateDayField2})
        Me.dateNYURYOKU_Ymd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateNYURYOKU_Ymd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateNYURYOKU_Ymd_To.InputCheck = True
        Me.dateNYURYOKU_Ymd_To.Location = New System.Drawing.Point(347, 121)
        Me.dateNYURYOKU_Ymd_To.Name = "dateNYURYOKU_Ymd_To"
        Me.GcShortcut1.SetShortcuts(Me.dateNYURYOKU_Ymd_To, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateNYURYOKU_Ymd_To, Object), CType(Me.dateNYURYOKU_Ymd_To, Object), CType(Me.dateNYURYOKU_Ymd_To, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateNYURYOKU_Ymd_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton8})
        Me.dateNYURYOKU_Ymd_To.Size = New System.Drawing.Size(124, 20)
        Me.dateNYURYOKU_Ymd_To.Spin.AllowSpin = False
        Me.dateNYURYOKU_Ymd_To.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateNYURYOKU_Ymd_To.TabIndex = 4
        Me.dateNYURYOKU_Ymd_To.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton8
        '
        Me.DropDownButton8.Name = "DropDownButton8"
        '
        'dateKOSHIN_Ymd_To
        '
        Me.dateKOSHIN_Ymd_To.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField8.Text = "/"
        DateLiteralField9.Text = "/"
        Me.dateKOSHIN_Ymd_To.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField3, DateLiteralField7, DateEraYearField3, DateLiteralField8, DateMonthField3, DateLiteralField9, DateDayField3})
        Me.dateKOSHIN_Ymd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateKOSHIN_Ymd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateKOSHIN_Ymd_To.InputCheck = True
        Me.dateKOSHIN_Ymd_To.Location = New System.Drawing.Point(347, 158)
        Me.dateKOSHIN_Ymd_To.Name = "dateKOSHIN_Ymd_To"
        Me.GcShortcut1.SetShortcuts(Me.dateKOSHIN_Ymd_To, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateKOSHIN_Ymd_To, Object), CType(Me.dateKOSHIN_Ymd_To, Object), CType(Me.dateKOSHIN_Ymd_To, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateKOSHIN_Ymd_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton12})
        Me.dateKOSHIN_Ymd_To.Size = New System.Drawing.Size(124, 20)
        Me.dateKOSHIN_Ymd_To.Spin.AllowSpin = False
        Me.dateKOSHIN_Ymd_To.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateKOSHIN_Ymd_To.TabIndex = 7
        Me.dateKOSHIN_Ymd_To.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton12
        '
        Me.DropDownButton12.Name = "DropDownButton12"
        '
        'dateKOSHIN_Ymd_Fm
        '
        Me.dateKOSHIN_Ymd_Fm.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField11.Text = "/"
        DateLiteralField12.Text = "/"
        Me.dateKOSHIN_Ymd_Fm.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField4, DateLiteralField10, DateEraYearField4, DateLiteralField11, DateMonthField4, DateLiteralField12, DateDayField4})
        Me.dateKOSHIN_Ymd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateKOSHIN_Ymd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateKOSHIN_Ymd_Fm.InputCheck = True
        Me.dateKOSHIN_Ymd_Fm.Location = New System.Drawing.Point(189, 158)
        Me.dateKOSHIN_Ymd_Fm.Name = "dateKOSHIN_Ymd_Fm"
        Me.GcShortcut1.SetShortcuts(Me.dateKOSHIN_Ymd_Fm, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateKOSHIN_Ymd_Fm, Object), CType(Me.dateKOSHIN_Ymd_Fm, Object), CType(Me.dateKOSHIN_Ymd_Fm, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateKOSHIN_Ymd_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton13})
        Me.dateKOSHIN_Ymd_Fm.Size = New System.Drawing.Size(124, 20)
        Me.dateKOSHIN_Ymd_Fm.Spin.AllowSpin = False
        Me.dateKOSHIN_Ymd_Fm.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateKOSHIN_Ymd_Fm.TabIndex = 6
        Me.dateKOSHIN_Ymd_Fm.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton13
        '
        Me.DropDownButton13.Name = "DropDownButton13"
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
        Me.Label2.Location = New System.Drawing.Point(160, 76)
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
        Me.Label3.Location = New System.Drawing.Point(45, 211)
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
        Me.cboKEIYAKU_KBN_Cd_Fm.Location = New System.Drawing.Point(164, 208)
        Me.cboKEIYAKU_KBN_Cd_Fm.MaxLength = 1
        Me.cboKEIYAKU_KBN_Cd_Fm.Name = "cboKEIYAKU_KBN_Cd_Fm"
        Me.cboKEIYAKU_KBN_Cd_Fm.Size = New System.Drawing.Size(26, 22)
        Me.cboKEIYAKU_KBN_Cd_Fm.Spin.AllowSpin = False
        Me.cboKEIYAKU_KBN_Cd_Fm.TabIndex = 8
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
        Me.cboKEIYAKU_KBN_Nm_Fm.Location = New System.Drawing.Point(199, 208)
        Me.cboKEIYAKU_KBN_Nm_Fm.MaxLength = 8
        Me.cboKEIYAKU_KBN_Nm_Fm.Name = "cboKEIYAKU_KBN_Nm_Fm"
        Me.cboKEIYAKU_KBN_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton9})
        Me.cboKEIYAKU_KBN_Nm_Fm.Size = New System.Drawing.Size(106, 22)
        Me.cboKEIYAKU_KBN_Nm_Fm.TabIndex = 9
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
        Me.Label4.Location = New System.Drawing.Point(311, 211)
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
        Me.cboKEIYAKU_KBN_Cd_To.Location = New System.Drawing.Point(342, 208)
        Me.cboKEIYAKU_KBN_Cd_To.MaxLength = 1
        Me.cboKEIYAKU_KBN_Cd_To.Name = "cboKEIYAKU_KBN_Cd_To"
        Me.cboKEIYAKU_KBN_Cd_To.Size = New System.Drawing.Size(26, 22)
        Me.cboKEIYAKU_KBN_Cd_To.Spin.AllowSpin = False
        Me.cboKEIYAKU_KBN_Cd_To.TabIndex = 10
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
        Me.cboKEIYAKU_KBN_Nm_To.Location = New System.Drawing.Point(377, 208)
        Me.cboKEIYAKU_KBN_Nm_To.MaxLength = 8
        Me.cboKEIYAKU_KBN_Nm_To.Name = "cboKEIYAKU_KBN_Nm_To"
        Me.cboKEIYAKU_KBN_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cboKEIYAKU_KBN_Nm_To.Size = New System.Drawing.Size(106, 22)
        Me.cboKEIYAKU_KBN_Nm_To.TabIndex = 11
        Me.cboKEIYAKU_KBN_Nm_To.TabStop = False
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
        Me.chkSINKI.Location = New System.Drawing.Point(163, 260)
        Me.chkSINKI.Name = "chkSINKI"
        Me.chkSINKI.Size = New System.Drawing.Size(107, 20)
        Me.chkSINKI.TabIndex = 12
        Me.chkSINKI.Text = "新規契約者"
        Me.chkSINKI.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(45, 262)
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
        Me.chkKEIZOKU.Location = New System.Drawing.Point(264, 260)
        Me.chkKEIZOKU.Name = "chkKEIZOKU"
        Me.chkKEIZOKU.Size = New System.Drawing.Size(107, 20)
        Me.chkKEIZOKU.TabIndex = 13
        Me.chkKEIZOKU.Text = "継続契約者"
        Me.chkKEIZOKU.UseVisualStyleBackColor = True
        '
        'chkCYUSI
        '
        Me.chkCYUSI.AutoSize = True
        Me.chkCYUSI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkCYUSI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkCYUSI.Location = New System.Drawing.Point(367, 260)
        Me.chkCYUSI.Name = "chkCYUSI"
        Me.chkCYUSI.Size = New System.Drawing.Size(77, 20)
        Me.chkCYUSI.TabIndex = 14
        Me.chkCYUSI.Text = "中止者"
        Me.chkCYUSI.UseVisualStyleBackColor = True
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
        Me.cboKEIYAKUSYA_Cd_To.Location = New System.Drawing.Point(477, 596)
        Me.cboKEIYAKUSYA_Cd_To.MaxLength = 5
        Me.cboKEIYAKUSYA_Cd_To.Name = "cboKEIYAKUSYA_Cd_To"
        Me.cboKEIYAKUSYA_Cd_To.Size = New System.Drawing.Size(53, 22)
        Me.cboKEIYAKUSYA_Cd_To.Spin.AllowSpin = False
        Me.cboKEIYAKUSYA_Cd_To.TabIndex = 31
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
        Me.cboKEIYAKUSYA_Nm_To.Location = New System.Drawing.Point(537, 597)
        Me.cboKEIYAKUSYA_Nm_To.MaxLength = 50
        Me.cboKEIYAKUSYA_Nm_To.Name = "cboKEIYAKUSYA_Nm_To"
        Me.cboKEIYAKUSYA_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.cboKEIYAKUSYA_Nm_To.Size = New System.Drawing.Size(390, 22)
        Me.cboKEIYAKUSYA_Nm_To.TabIndex = 32
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
        Me.Label9.Location = New System.Drawing.Point(449, 603)
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
        Me.cboKEIYAKUSYA_Cd_Fm.Location = New System.Drawing.Point(163, 569)
        Me.cboKEIYAKUSYA_Cd_Fm.MaxLength = 5
        Me.cboKEIYAKUSYA_Cd_Fm.Name = "cboKEIYAKUSYA_Cd_Fm"
        Me.cboKEIYAKUSYA_Cd_Fm.Size = New System.Drawing.Size(51, 22)
        Me.cboKEIYAKUSYA_Cd_Fm.Spin.AllowSpin = False
        Me.cboKEIYAKUSYA_Cd_Fm.TabIndex = 29
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
        Me.cboKEIYAKUSYA_Nm_Fm.Location = New System.Drawing.Point(223, 569)
        Me.cboKEIYAKUSYA_Nm_Fm.MaxLength = 50
        Me.cboKEIYAKUSYA_Nm_Fm.Name = "cboKEIYAKUSYA_Nm_Fm"
        Me.cboKEIYAKUSYA_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.cboKEIYAKUSYA_Nm_Fm.Size = New System.Drawing.Size(391, 22)
        Me.cboKEIYAKUSYA_Nm_Fm.TabIndex = 30
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
        Me.Label10.Location = New System.Drawing.Point(45, 572)
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
        Me.cboITAKU_Cd_To.Location = New System.Drawing.Point(478, 530)
        Me.cboITAKU_Cd_To.MaxLength = 3
        Me.cboITAKU_Cd_To.Name = "cboITAKU_Cd_To"
        Me.cboITAKU_Cd_To.Size = New System.Drawing.Size(53, 22)
        Me.cboITAKU_Cd_To.Spin.AllowSpin = False
        Me.cboITAKU_Cd_To.TabIndex = 27
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
        Me.cboITAKU_Nm_To.Location = New System.Drawing.Point(537, 530)
        Me.cboITAKU_Nm_To.MaxLength = 50
        Me.cboITAKU_Nm_To.Name = "cboITAKU_Nm_To"
        Me.cboITAKU_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.cboITAKU_Nm_To.Size = New System.Drawing.Size(391, 22)
        Me.cboITAKU_Nm_To.TabIndex = 28
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
        Me.Label11.Location = New System.Drawing.Point(450, 533)
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
        Me.cboITAKU_Cd_Fm.Location = New System.Drawing.Point(163, 500)
        Me.cboITAKU_Cd_Fm.MaxLength = 3
        Me.cboITAKU_Cd_Fm.Name = "cboITAKU_Cd_Fm"
        Me.cboITAKU_Cd_Fm.Size = New System.Drawing.Size(51, 22)
        Me.cboITAKU_Cd_Fm.Spin.AllowSpin = False
        Me.cboITAKU_Cd_Fm.TabIndex = 25
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
        Me.cboITAKU_Nm_Fm.Location = New System.Drawing.Point(223, 500)
        Me.cboITAKU_Nm_Fm.MaxLength = 50
        Me.cboITAKU_Nm_Fm.Name = "cboITAKU_Nm_Fm"
        Me.cboITAKU_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton7})
        Me.cboITAKU_Nm_Fm.Size = New System.Drawing.Size(391, 22)
        Me.cboITAKU_Nm_Fm.TabIndex = 26
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
        Me.Label12.Location = New System.Drawing.Point(45, 503)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 15)
        Me.Label12.TabIndex = 980
        Me.Label12.Text = "□事務委託先"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(319, 124)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 15)
        Me.Label13.TabIndex = 982
        Me.Label13.Text = "～"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(45, 451)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 15)
        Me.Label14.TabIndex = 983
        Me.Label14.Text = "□入力者"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(537, 451)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(22, 15)
        Me.Label15.TabIndex = 985
        Me.Label15.Text = "～"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(45, 311)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 15)
        Me.Label16.TabIndex = 986
        Me.Label16.Text = "■入力状況"
        '
        'chkNYURYOKU_CYU
        '
        Me.chkNYURYOKU_CYU.AutoSize = True
        Me.chkNYURYOKU_CYU.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkNYURYOKU_CYU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkNYURYOKU_CYU.Location = New System.Drawing.Point(163, 309)
        Me.chkNYURYOKU_CYU.Name = "chkNYURYOKU_CYU"
        Me.chkNYURYOKU_CYU.Size = New System.Drawing.Size(77, 20)
        Me.chkNYURYOKU_CYU.TabIndex = 15
        Me.chkNYURYOKU_CYU.Text = "入力中"
        Me.chkNYURYOKU_CYU.UseVisualStyleBackColor = True
        '
        'chkNYURYOKU_KAKUTEI
        '
        Me.chkNYURYOKU_KAKUTEI.AutoSize = True
        Me.chkNYURYOKU_KAKUTEI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkNYURYOKU_KAKUTEI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkNYURYOKU_KAKUTEI.Location = New System.Drawing.Point(264, 309)
        Me.chkNYURYOKU_KAKUTEI.Name = "chkNYURYOKU_KAKUTEI"
        Me.chkNYURYOKU_KAKUTEI.Size = New System.Drawing.Size(92, 20)
        Me.chkNYURYOKU_KAKUTEI.TabIndex = 16
        Me.chkNYURYOKU_KAKUTEI.Text = "入力確定"
        Me.chkNYURYOKU_KAKUTEI.UseVisualStyleBackColor = True
        '
        'cboUSER_Cd_Fm
        '
        Me.cboUSER_Cd_Fm.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cboUSER_Cd_Fm.DropDown.AllowDrop = False
        Me.cboUSER_Cd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboUSER_Cd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboUSER_Cd_Fm.HighlightText = True
        Me.cboUSER_Cd_Fm.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboUSER_Cd_Fm.ListHeaderPane.Height = 22
        Me.cboUSER_Cd_Fm.Location = New System.Drawing.Point(162, 448)
        Me.cboUSER_Cd_Fm.MaxLength = 10
        Me.cboUSER_Cd_Fm.Name = "cboUSER_Cd_Fm"
        Me.cboUSER_Cd_Fm.Size = New System.Drawing.Size(93, 22)
        Me.cboUSER_Cd_Fm.Spin.AllowSpin = False
        Me.cboUSER_Cd_Fm.TabIndex = 21
        Me.cboUSER_Cd_Fm.Tag = "入力者"
        Me.cboUSER_Cd_Fm.Text = "9999999999"
        '
        'cboUSER_Nm_Fm
        '
        Me.cboUSER_Nm_Fm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUSER_Nm_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboUSER_Nm_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboUSER_Nm_Fm.ListHeaderPane.Height = 22
        Me.cboUSER_Nm_Fm.ListHeaderPane.Visible = False
        Me.cboUSER_Nm_Fm.Location = New System.Drawing.Point(260, 448)
        Me.cboUSER_Nm_Fm.MaxLength = 20
        Me.cboUSER_Nm_Fm.Name = "cboUSER_Nm_Fm"
        Me.cboUSER_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton10})
        Me.cboUSER_Nm_Fm.Size = New System.Drawing.Size(264, 22)
        Me.cboUSER_Nm_Fm.TabIndex = 22
        Me.cboUSER_Nm_Fm.TabStop = False
        Me.cboUSER_Nm_Fm.Tag = "入力者名"
        '
        'DropDownButton10
        '
        Me.DropDownButton10.Name = "DropDownButton10"
        '
        'cboUSER_Cd_To
        '
        Me.cboUSER_Cd_To.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cboUSER_Cd_To.DropDown.AllowDrop = False
        Me.cboUSER_Cd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboUSER_Cd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboUSER_Cd_To.HighlightText = True
        Me.cboUSER_Cd_To.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboUSER_Cd_To.ListHeaderPane.Height = 22
        Me.cboUSER_Cd_To.Location = New System.Drawing.Point(568, 448)
        Me.cboUSER_Cd_To.MaxLength = 10
        Me.cboUSER_Cd_To.Name = "cboUSER_Cd_To"
        Me.cboUSER_Cd_To.Size = New System.Drawing.Size(93, 22)
        Me.cboUSER_Cd_To.Spin.AllowSpin = False
        Me.cboUSER_Cd_To.TabIndex = 23
        Me.cboUSER_Cd_To.Tag = "入力者"
        Me.cboUSER_Cd_To.Text = "9999999999"
        '
        'cboUSER_Nm_To
        '
        Me.cboUSER_Nm_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUSER_Nm_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboUSER_Nm_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboUSER_Nm_To.ListHeaderPane.Height = 22
        Me.cboUSER_Nm_To.ListHeaderPane.Visible = False
        Me.cboUSER_Nm_To.Location = New System.Drawing.Point(667, 448)
        Me.cboUSER_Nm_To.MaxLength = 20
        Me.cboUSER_Nm_To.Name = "cboUSER_Nm_To"
        Me.cboUSER_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton11})
        Me.cboUSER_Nm_To.Size = New System.Drawing.Size(264, 22)
        Me.cboUSER_Nm_To.TabIndex = 24
        Me.cboUSER_Nm_To.TabStop = False
        Me.cboUSER_Nm_To.Tag = "入力者名"
        '
        'DropDownButton11
        '
        Me.DropDownButton11.Name = "DropDownButton11"
        '
        'rdoKOSHIN_HANI
        '
        Me.rdoKOSHIN_HANI.AutoSize = True
        Me.rdoKOSHIN_HANI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoKOSHIN_HANI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoKOSHIN_HANI.Location = New System.Drawing.Point(83, 156)
        Me.rdoKOSHIN_HANI.Name = "rdoKOSHIN_HANI"
        Me.rdoKOSHIN_HANI.Size = New System.Drawing.Size(106, 20)
        Me.rdoKOSHIN_HANI.TabIndex = 5
        Me.rdoKOSHIN_HANI.TabStop = True
        Me.rdoKOSHIN_HANI.Text = "更新日範囲"
        Me.rdoKOSHIN_HANI.UseVisualStyleBackColor = True
        '
        'rdoTOROKU_HANI
        '
        Me.rdoTOROKU_HANI.AutoSize = True
        Me.rdoTOROKU_HANI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoTOROKU_HANI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoTOROKU_HANI.Location = New System.Drawing.Point(83, 122)
        Me.rdoTOROKU_HANI.Name = "rdoTOROKU_HANI"
        Me.rdoTOROKU_HANI.Size = New System.Drawing.Size(106, 20)
        Me.rdoTOROKU_HANI.TabIndex = 2
        Me.rdoTOROKU_HANI.TabStop = True
        Me.rdoTOROKU_HANI.Text = "登録日範囲"
        Me.rdoTOROKU_HANI.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(319, 161)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(22, 15)
        Me.Label17.TabIndex = 991
        Me.Label17.Text = "～"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(70, 106)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 83)
        Me.GroupBox1.TabIndex = 992
        Me.GroupBox1.TabStop = False
        '
        'chkKEIYAKUDATENASHI
        '
        Me.chkKEIYAKUDATENASHI.AutoSize = True
        Me.chkKEIYAKUDATENASHI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkKEIYAKUDATENASHI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkKEIYAKUDATENASHI.Location = New System.Drawing.Point(264, 362)
        Me.chkKEIYAKUDATENASHI.Name = "chkKEIYAKUDATENASHI"
        Me.chkKEIYAKUDATENASHI.Size = New System.Drawing.Size(107, 20)
        Me.chkKEIYAKUDATENASHI.TabIndex = 18
        Me.chkKEIYAKUDATENASHI.Text = "未入力のみ"
        Me.chkKEIYAKUDATENASHI.UseVisualStyleBackColor = True
        '
        'chkKEIYAKUDATEARI
        '
        Me.chkKEIYAKUDATEARI.AutoSize = True
        Me.chkKEIYAKUDATEARI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkKEIYAKUDATEARI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkKEIYAKUDATEARI.Location = New System.Drawing.Point(163, 362)
        Me.chkKEIYAKUDATEARI.Name = "chkKEIYAKUDATEARI"
        Me.chkKEIYAKUDATEARI.Size = New System.Drawing.Size(92, 20)
        Me.chkKEIYAKUDATEARI.TabIndex = 17
        Me.chkKEIYAKUDATEARI.Text = "入力のみ"
        Me.chkKEIYAKUDATEARI.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(45, 374)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 15)
        Me.Label18.TabIndex = 995
        Me.Label18.Text = "■契約日"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(290, 393)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(22, 15)
        Me.Label19.TabIndex = 998
        Me.Label19.Text = "～"
        '
        'dateKEIYAKU_Ymd_To
        '
        Me.dateKEIYAKU_Ymd_To.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField14.Text = "/"
        DateLiteralField15.Text = "/"
        Me.dateKEIYAKU_Ymd_To.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField5, DateLiteralField13, DateEraYearField5, DateLiteralField14, DateMonthField5, DateLiteralField15, DateDayField5})
        Me.dateKEIYAKU_Ymd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateKEIYAKU_Ymd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateKEIYAKU_Ymd_To.Location = New System.Drawing.Point(314, 390)
        Me.dateKEIYAKU_Ymd_To.Name = "dateKEIYAKU_Ymd_To"
        Me.GcShortcut1.SetShortcuts(Me.dateKEIYAKU_Ymd_To, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateKEIYAKU_Ymd_To, Object), CType(Me.dateKEIYAKU_Ymd_To, Object), CType(Me.dateKEIYAKU_Ymd_To, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateKEIYAKU_Ymd_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton16})
        Me.dateKEIYAKU_Ymd_To.Size = New System.Drawing.Size(124, 20)
        Me.dateKEIYAKU_Ymd_To.Spin.AllowSpin = False
        Me.dateKEIYAKU_Ymd_To.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateKEIYAKU_Ymd_To.TabIndex = 20
        Me.dateKEIYAKU_Ymd_To.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton16
        '
        Me.DropDownButton16.Name = "DropDownButton16"
        '
        'dateKEIYAKU_Ymd_Fm
        '
        Me.dateKEIYAKU_Ymd_Fm.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField17.Text = "/"
        DateLiteralField18.Text = "/"
        Me.dateKEIYAKU_Ymd_Fm.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField6, DateLiteralField16, DateEraYearField6, DateLiteralField17, DateMonthField6, DateLiteralField18, DateDayField6})
        Me.dateKEIYAKU_Ymd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateKEIYAKU_Ymd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateKEIYAKU_Ymd_Fm.Location = New System.Drawing.Point(162, 390)
        Me.dateKEIYAKU_Ymd_Fm.Name = "dateKEIYAKU_Ymd_Fm"
        Me.GcShortcut1.SetShortcuts(Me.dateKEIYAKU_Ymd_Fm, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateKEIYAKU_Ymd_Fm, Object), CType(Me.dateKEIYAKU_Ymd_Fm, Object), CType(Me.dateKEIYAKU_Ymd_Fm, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateKEIYAKU_Ymd_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton17})
        Me.dateKEIYAKU_Ymd_Fm.Size = New System.Drawing.Size(124, 20)
        Me.dateKEIYAKU_Ymd_Fm.Spin.AllowSpin = False
        Me.dateKEIYAKU_Ymd_Fm.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateKEIYAKU_Ymd_Fm.TabIndex = 19
        Me.dateKEIYAKU_Ymd_Fm.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton17
        '
        Me.DropDownButton17.Name = "DropDownButton17"
        '
        'frmGJ1040
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.dateKEIYAKU_Ymd_To)
        Me.Controls.Add(Me.dateKEIYAKU_Ymd_Fm)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.chkKEIYAKUDATENASHI)
        Me.Controls.Add(Me.chkKEIYAKUDATEARI)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.dateKOSHIN_Ymd_To)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.dateKOSHIN_Ymd_Fm)
        Me.Controls.Add(Me.rdoKOSHIN_HANI)
        Me.Controls.Add(Me.rdoTOROKU_HANI)
        Me.Controls.Add(Me.cboUSER_Cd_To)
        Me.Controls.Add(Me.cboUSER_Nm_To)
        Me.Controls.Add(Me.cboUSER_Cd_Fm)
        Me.Controls.Add(Me.cboUSER_Nm_Fm)
        Me.Controls.Add(Me.chkNYURYOKU_KAKUTEI)
        Me.Controls.Add(Me.chkNYURYOKU_CYU)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.dateNYURYOKU_Ymd_To)
        Me.Controls.Add(Me.Label13)
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
        Me.Controls.Add(Me.dateNYURYOKU_Ymd_Fm)
        Me.Controls.Add(Me.numKI)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmGJ1040"
        Me.Text = "(GJ1040)契約者別契約情報入力確認チェックリスト作成処理（農場別等）"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.numKI, 0)
        Me.Controls.SetChildIndex(Me.dateNYURYOKU_Ymd_Fm, 0)
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
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.dateNYURYOKU_Ymd_To, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.chkNYURYOKU_CYU, 0)
        Me.Controls.SetChildIndex(Me.chkNYURYOKU_KAKUTEI, 0)
        Me.Controls.SetChildIndex(Me.cboUSER_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboUSER_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboUSER_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.cboUSER_Cd_To, 0)
        Me.Controls.SetChildIndex(Me.rdoTOROKU_HANI, 0)
        Me.Controls.SetChildIndex(Me.rdoKOSHIN_HANI, 0)
        Me.Controls.SetChildIndex(Me.dateKOSHIN_Ymd_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.dateKOSHIN_Ymd_To, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.chkKEIYAKUDATEARI, 0)
        Me.Controls.SetChildIndex(Me.chkKEIYAKUDATENASHI, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.dateKEIYAKU_Ymd_Fm, 0)
        Me.Controls.SetChildIndex(Me.dateKEIYAKU_Ymd_To, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateNYURYOKU_Ymd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateNYURYOKU_Ymd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateKOSHIN_Ymd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateKOSHIN_Ymd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.cboUSER_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUSER_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUSER_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUSER_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateKEIYAKU_Ymd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateKEIYAKU_Ymd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents numKI As JBD.Gjs.Win.GcNumber
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents dateNYURYOKU_Ymd_Fm As JBD.Gjs.Win.GcDate
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
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents dateNYURYOKU_Ymd_To As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton8 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents chkNYURYOKU_CYU As JBD.Gjs.Win.CheckBox
    Friend WithEvents chkNYURYOKU_KAKUTEI As JBD.Gjs.Win.CheckBox
    Friend WithEvents cboUSER_Cd_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboUSER_Nm_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton10 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cboUSER_Cd_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboUSER_Nm_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton11 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents rdoKOSHIN_HANI As JBD.Gjs.Win.RadioButton
    Friend WithEvents rdoTOROKU_HANI As JBD.Gjs.Win.RadioButton
    Friend WithEvents dateKOSHIN_Ymd_To As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton12 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents dateKOSHIN_Ymd_Fm As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton13 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkKEIYAKUDATENASHI As JBD.Gjs.Win.CheckBox
    Friend WithEvents chkKEIYAKUDATEARI As JBD.Gjs.Win.CheckBox
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents dateKEIYAKU_Ymd_To As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton16 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents dateKEIYAKU_Ymd_Fm As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton17 As GrapeCity.Win.Editors.DropDownButton
End Class
