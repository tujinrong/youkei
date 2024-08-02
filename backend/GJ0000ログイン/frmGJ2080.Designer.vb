Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ2080
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
        Dim ValueProcess2 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange2 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim ValueProcess3 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange3 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
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
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.numKI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.numSEIKYU_KAISU_Fm = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSEIKYU_KAISU_To = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.dateSEIKYU_Ymd_Fm = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton10 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dateSEIKYU_Ymd_To = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton11 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dateNYUKIN_Ymd_Fm = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton12 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dateNYUKIN_Ymd_To = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton13 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dateSEIKYU_DATE_Ymd_Fm = New JBD.Gjs.Win.GcDate(Me.components)
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
        Me.chkSEIKYU_HENKAN_KBN_1 = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.chkSEIKYU_HENKAN_KBN_2 = New JBD.Gjs.Win.CheckBox(Me.components)
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
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.chkNYUKIN_KBN_1 = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.chkNYUKIN_KBN_2 = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.Label29 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.chkSEIKYU_HENKAN_KBN_3 = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.chkSEIKYU_HENKAN_KBN_4 = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.chkNYUKIN_KBN_3 = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.cmdExcel = New JBD.Gjs.Win.JButton(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSEIKYU_KAISU_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSEIKYU_KAISU_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateSEIKYU_Ymd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateSEIKYU_Ymd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateNYUKIN_Ymd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateNYUKIN_Ymd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateSEIKYU_DATE_Ymd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlButton.Controls.Add(Me.cmdExcel)
        Me.pnlButton.Controls.Add(Me.cmdCancel)
        Me.pnlButton.Controls.Add(Me.cmdPreview)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdPreview, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCancel, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdExcel, 0)
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
        Me.Label5.Location = New System.Drawing.Point(45, 102)
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
        Me.Label6.Location = New System.Drawing.Point(254, 102)
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
        Me.Label8.Location = New System.Drawing.Point(45, 148)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 15)
        Me.Label8.TabIndex = 964
        Me.Label8.Text = "■請求回数"
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
        Me.numKI.Location = New System.Drawing.Point(209, 99)
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
        'numSEIKYU_KAISU_Fm
        '
        Me.numSEIKYU_KAISU_Fm.AllowDeleteToNull = True
        Me.numSEIKYU_KAISU_Fm.ContentAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.numSEIKYU_KAISU_Fm.DropDown.AllowDrop = False
        Me.numSEIKYU_KAISU_Fm.Fields.DecimalPart.MaxDigits = 0
        Me.numSEIKYU_KAISU_Fm.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSEIKYU_KAISU_Fm.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numSEIKYU_KAISU_Fm.Fields.IntegerPart.MaxDigits = 3
        Me.numSEIKYU_KAISU_Fm.Fields.IntegerPart.MinDigits = 1
        Me.numSEIKYU_KAISU_Fm.Fields.SignPrefix.NegativePattern = ""
        Me.numSEIKYU_KAISU_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSEIKYU_KAISU_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSEIKYU_KAISU_Fm.HighlightText = True
        Me.numSEIKYU_KAISU_Fm.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSEIKYU_KAISU_Fm.InputCheck = True
        Me.numSEIKYU_KAISU_Fm.Location = New System.Drawing.Point(185, 145)
        Me.numSEIKYU_KAISU_Fm.Name = "numSEIKYU_KAISU_Fm"
        Me.GcShortcut1.SetShortcuts(Me.numSEIKYU_KAISU_Fm, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSEIKYU_KAISU_Fm, Object), CType(Me.numSEIKYU_KAISU_Fm, Object), CType(Me.numSEIKYU_KAISU_Fm, Object), CType(Me.numSEIKYU_KAISU_Fm, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSEIKYU_KAISU_Fm.Size = New System.Drawing.Size(39, 20)
        Me.numSEIKYU_KAISU_Fm.Spin.Increment = 0
        Me.numSEIKYU_KAISU_Fm.TabIndex = 2
        ValueProcess2.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSEIKYU_KAISU_Fm).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess2})
        InvalidRange2.MaxValue = New Decimal(New Integer() {999, 0, 0, 0})
        InvalidRange2.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSEIKYU_KAISU_Fm).AddRange(New Object() {InvalidRange2})
        Me.numSEIKYU_KAISU_Fm.Value = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numSEIKYU_KAISU_Fm.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        Me.numSEIKYU_KAISU_Fm.ZeroSuppress = True
        '
        'numSEIKYU_KAISU_To
        '
        Me.numSEIKYU_KAISU_To.AllowDeleteToNull = True
        Me.numSEIKYU_KAISU_To.ContentAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.numSEIKYU_KAISU_To.DropDown.AllowDrop = False
        Me.numSEIKYU_KAISU_To.Fields.DecimalPart.MaxDigits = 0
        Me.numSEIKYU_KAISU_To.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSEIKYU_KAISU_To.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numSEIKYU_KAISU_To.Fields.IntegerPart.MaxDigits = 3
        Me.numSEIKYU_KAISU_To.Fields.IntegerPart.MinDigits = 1
        Me.numSEIKYU_KAISU_To.Fields.SignPrefix.NegativePattern = ""
        Me.numSEIKYU_KAISU_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSEIKYU_KAISU_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSEIKYU_KAISU_To.HighlightText = True
        Me.numSEIKYU_KAISU_To.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSEIKYU_KAISU_To.InputCheck = True
        Me.numSEIKYU_KAISU_To.Location = New System.Drawing.Point(259, 145)
        Me.numSEIKYU_KAISU_To.Name = "numSEIKYU_KAISU_To"
        Me.GcShortcut1.SetShortcuts(Me.numSEIKYU_KAISU_To, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSEIKYU_KAISU_To, Object), CType(Me.numSEIKYU_KAISU_To, Object), CType(Me.numSEIKYU_KAISU_To, Object), CType(Me.numSEIKYU_KAISU_To, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSEIKYU_KAISU_To.Size = New System.Drawing.Size(39, 20)
        Me.numSEIKYU_KAISU_To.Spin.Increment = 0
        Me.numSEIKYU_KAISU_To.TabIndex = 3
        ValueProcess3.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSEIKYU_KAISU_To).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess3})
        InvalidRange3.MaxValue = New Decimal(New Integer() {999, 0, 0, 0})
        InvalidRange3.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSEIKYU_KAISU_To).AddRange(New Object() {InvalidRange3})
        Me.numSEIKYU_KAISU_To.Value = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numSEIKYU_KAISU_To.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        Me.numSEIKYU_KAISU_To.ZeroSuppress = True
        '
        'dateSEIKYU_Ymd_Fm
        '
        Me.dateSEIKYU_Ymd_Fm.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.dateSEIKYU_Ymd_Fm.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.dateSEIKYU_Ymd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateSEIKYU_Ymd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateSEIKYU_Ymd_Fm.InputCheck = True
        Me.dateSEIKYU_Ymd_Fm.Location = New System.Drawing.Point(185, 188)
        Me.dateSEIKYU_Ymd_Fm.Name = "dateSEIKYU_Ymd_Fm"
        Me.GcShortcut1.SetShortcuts(Me.dateSEIKYU_Ymd_Fm, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateSEIKYU_Ymd_Fm, Object), CType(Me.dateSEIKYU_Ymd_Fm, Object), CType(Me.dateSEIKYU_Ymd_Fm, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateSEIKYU_Ymd_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton10})
        Me.dateSEIKYU_Ymd_Fm.Size = New System.Drawing.Size(124, 20)
        Me.dateSEIKYU_Ymd_Fm.Spin.AllowSpin = False
        Me.dateSEIKYU_Ymd_Fm.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateSEIKYU_Ymd_Fm.TabIndex = 4
        Me.dateSEIKYU_Ymd_Fm.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton10
        '
        Me.DropDownButton10.Name = "DropDownButton10"
        '
        'dateSEIKYU_Ymd_To
        '
        Me.dateSEIKYU_Ymd_To.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField5.Text = "/"
        DateLiteralField6.Text = "/"
        Me.dateSEIKYU_Ymd_To.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateLiteralField4, DateEraYearField2, DateLiteralField5, DateMonthField2, DateLiteralField6, DateDayField2})
        Me.dateSEIKYU_Ymd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateSEIKYU_Ymd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateSEIKYU_Ymd_To.InputCheck = True
        Me.dateSEIKYU_Ymd_To.Location = New System.Drawing.Point(341, 188)
        Me.dateSEIKYU_Ymd_To.Name = "dateSEIKYU_Ymd_To"
        Me.GcShortcut1.SetShortcuts(Me.dateSEIKYU_Ymd_To, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateSEIKYU_Ymd_To, Object), CType(Me.dateSEIKYU_Ymd_To, Object), CType(Me.dateSEIKYU_Ymd_To, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateSEIKYU_Ymd_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton11})
        Me.dateSEIKYU_Ymd_To.Size = New System.Drawing.Size(124, 20)
        Me.dateSEIKYU_Ymd_To.Spin.AllowSpin = False
        Me.dateSEIKYU_Ymd_To.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateSEIKYU_Ymd_To.TabIndex = 5
        Me.dateSEIKYU_Ymd_To.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton11
        '
        Me.DropDownButton11.Name = "DropDownButton11"
        '
        'dateNYUKIN_Ymd_Fm
        '
        Me.dateNYUKIN_Ymd_Fm.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField8.Text = "/"
        DateLiteralField9.Text = "/"
        Me.dateNYUKIN_Ymd_Fm.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField3, DateLiteralField7, DateEraYearField3, DateLiteralField8, DateMonthField3, DateLiteralField9, DateDayField3})
        Me.dateNYUKIN_Ymd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateNYUKIN_Ymd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateNYUKIN_Ymd_Fm.InputCheck = True
        Me.dateNYUKIN_Ymd_Fm.Location = New System.Drawing.Point(185, 236)
        Me.dateNYUKIN_Ymd_Fm.Name = "dateNYUKIN_Ymd_Fm"
        Me.GcShortcut1.SetShortcuts(Me.dateNYUKIN_Ymd_Fm, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateNYUKIN_Ymd_Fm, Object), CType(Me.dateNYUKIN_Ymd_Fm, Object), CType(Me.dateNYUKIN_Ymd_Fm, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateNYUKIN_Ymd_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton12})
        Me.dateNYUKIN_Ymd_Fm.Size = New System.Drawing.Size(124, 20)
        Me.dateNYUKIN_Ymd_Fm.Spin.AllowSpin = False
        Me.dateNYUKIN_Ymd_Fm.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateNYUKIN_Ymd_Fm.TabIndex = 6
        Me.dateNYUKIN_Ymd_Fm.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton12
        '
        Me.DropDownButton12.Name = "DropDownButton12"
        '
        'dateNYUKIN_Ymd_To
        '
        Me.dateNYUKIN_Ymd_To.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField11.Text = "/"
        DateLiteralField12.Text = "/"
        Me.dateNYUKIN_Ymd_To.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField4, DateLiteralField10, DateEraYearField4, DateLiteralField11, DateMonthField4, DateLiteralField12, DateDayField4})
        Me.dateNYUKIN_Ymd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateNYUKIN_Ymd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateNYUKIN_Ymd_To.InputCheck = True
        Me.dateNYUKIN_Ymd_To.Location = New System.Drawing.Point(341, 236)
        Me.dateNYUKIN_Ymd_To.Name = "dateNYUKIN_Ymd_To"
        Me.GcShortcut1.SetShortcuts(Me.dateNYUKIN_Ymd_To, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateNYUKIN_Ymd_To, Object), CType(Me.dateNYUKIN_Ymd_To, Object), CType(Me.dateNYUKIN_Ymd_To, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateNYUKIN_Ymd_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton13})
        Me.dateNYUKIN_Ymd_To.Size = New System.Drawing.Size(124, 20)
        Me.dateNYUKIN_Ymd_To.Spin.AllowSpin = False
        Me.dateNYUKIN_Ymd_To.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateNYUKIN_Ymd_To.TabIndex = 7
        Me.dateNYUKIN_Ymd_To.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton13
        '
        Me.DropDownButton13.Name = "DropDownButton13"
        '
        'dateSEIKYU_DATE_Ymd_Fm
        '
        Me.dateSEIKYU_DATE_Ymd_Fm.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField14.Text = "/"
        DateLiteralField15.Text = "/"
        Me.dateSEIKYU_DATE_Ymd_Fm.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField5, DateLiteralField13, DateEraYearField5, DateLiteralField14, DateMonthField5, DateLiteralField15, DateDayField5})
        Me.dateSEIKYU_DATE_Ymd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateSEIKYU_DATE_Ymd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateSEIKYU_DATE_Ymd_Fm.Location = New System.Drawing.Point(185, 188)
        Me.dateSEIKYU_DATE_Ymd_Fm.Name = "dateSEIKYU_DATE_Ymd_Fm"
        Me.GcShortcut1.SetShortcuts(Me.dateSEIKYU_DATE_Ymd_Fm, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateSEIKYU_DATE_Ymd_Fm, Object), CType(Me.dateSEIKYU_DATE_Ymd_Fm, Object), CType(Me.dateSEIKYU_DATE_Ymd_Fm, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateSEIKYU_DATE_Ymd_Fm.Size = New System.Drawing.Size(124, 20)
        Me.dateSEIKYU_DATE_Ymd_Fm.Spin.AllowSpin = False
        Me.dateSEIKYU_DATE_Ymd_Fm.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateSEIKYU_DATE_Ymd_Fm.TabIndex = 4
        Me.dateSEIKYU_DATE_Ymd_Fm.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
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
        Me.Label2.Location = New System.Drawing.Point(181, 102)
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
        Me.Label3.Location = New System.Drawing.Point(45, 284)
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
        Me.cboKEIYAKU_KBN_Cd_Fm.Location = New System.Drawing.Point(185, 281)
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
        Me.cboKEIYAKU_KBN_Nm_Fm.Location = New System.Drawing.Point(220, 281)
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
        Me.Label4.Location = New System.Drawing.Point(332, 284)
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
        Me.cboKEIYAKU_KBN_Cd_To.Location = New System.Drawing.Point(363, 281)
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
        Me.cboKEIYAKU_KBN_Nm_To.Location = New System.Drawing.Point(398, 281)
        Me.cboKEIYAKU_KBN_Nm_To.MaxLength = 8
        Me.cboKEIYAKU_KBN_Nm_To.Name = "cboKEIYAKU_KBN_Nm_To"
        Me.cboKEIYAKU_KBN_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cboKEIYAKU_KBN_Nm_To.Size = New System.Drawing.Size(106, 22)
        Me.cboKEIYAKU_KBN_Nm_To.TabIndex = 11
        Me.cboKEIYAKU_KBN_Nm_To.TabStop = False
        Me.cboKEIYAKU_KBN_Nm_To.Tag = "契約区分名"
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'chkSEIKYU_HENKAN_KBN_1
        '
        Me.chkSEIKYU_HENKAN_KBN_1.AutoSize = True
        Me.chkSEIKYU_HENKAN_KBN_1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkSEIKYU_HENKAN_KBN_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkSEIKYU_HENKAN_KBN_1.Location = New System.Drawing.Point(184, 334)
        Me.chkSEIKYU_HENKAN_KBN_1.Name = "chkSEIKYU_HENKAN_KBN_1"
        Me.chkSEIKYU_HENKAN_KBN_1.Size = New System.Drawing.Size(108, 20)
        Me.chkSEIKYU_HENKAN_KBN_1.TabIndex = 12
        Me.chkSEIKYU_HENKAN_KBN_1.Text = "請求（新規）"
        Me.chkSEIKYU_HENKAN_KBN_1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(45, 336)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 15)
        Me.Label7.TabIndex = 969
        Me.Label7.Text = "■請求・返還区分"
        '
        'chkSEIKYU_HENKAN_KBN_2
        '
        Me.chkSEIKYU_HENKAN_KBN_2.AutoSize = True
        Me.chkSEIKYU_HENKAN_KBN_2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkSEIKYU_HENKAN_KBN_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkSEIKYU_HENKAN_KBN_2.Location = New System.Drawing.Point(303, 334)
        Me.chkSEIKYU_HENKAN_KBN_2.Name = "chkSEIKYU_HENKAN_KBN_2"
        Me.chkSEIKYU_HENKAN_KBN_2.Size = New System.Drawing.Size(92, 20)
        Me.chkSEIKYU_HENKAN_KBN_2.TabIndex = 13
        Me.chkSEIKYU_HENKAN_KBN_2.Text = "一部請求"
        Me.chkSEIKYU_HENKAN_KBN_2.UseVisualStyleBackColor = True
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
        Me.cboKEIYAKUSYA_Cd_To.Location = New System.Drawing.Point(477, 532)
        Me.cboKEIYAKUSYA_Cd_To.MaxLength = 5
        Me.cboKEIYAKUSYA_Cd_To.Name = "cboKEIYAKUSYA_Cd_To"
        Me.cboKEIYAKUSYA_Cd_To.Size = New System.Drawing.Size(53, 22)
        Me.cboKEIYAKUSYA_Cd_To.Spin.AllowSpin = False
        Me.cboKEIYAKUSYA_Cd_To.TabIndex = 26
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
        Me.cboKEIYAKUSYA_Nm_To.Location = New System.Drawing.Point(537, 533)
        Me.cboKEIYAKUSYA_Nm_To.MaxLength = 50
        Me.cboKEIYAKUSYA_Nm_To.Name = "cboKEIYAKUSYA_Nm_To"
        Me.cboKEIYAKUSYA_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.cboKEIYAKUSYA_Nm_To.Size = New System.Drawing.Size(390, 22)
        Me.cboKEIYAKUSYA_Nm_To.TabIndex = 27
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
        Me.Label9.Location = New System.Drawing.Point(449, 539)
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
        Me.cboKEIYAKUSYA_Cd_Fm.Location = New System.Drawing.Point(184, 505)
        Me.cboKEIYAKUSYA_Cd_Fm.MaxLength = 5
        Me.cboKEIYAKUSYA_Cd_Fm.Name = "cboKEIYAKUSYA_Cd_Fm"
        Me.cboKEIYAKUSYA_Cd_Fm.Size = New System.Drawing.Size(51, 22)
        Me.cboKEIYAKUSYA_Cd_Fm.Spin.AllowSpin = False
        Me.cboKEIYAKUSYA_Cd_Fm.TabIndex = 24
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
        Me.cboKEIYAKUSYA_Nm_Fm.Location = New System.Drawing.Point(243, 505)
        Me.cboKEIYAKUSYA_Nm_Fm.MaxLength = 50
        Me.cboKEIYAKUSYA_Nm_Fm.Name = "cboKEIYAKUSYA_Nm_Fm"
        Me.cboKEIYAKUSYA_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.cboKEIYAKUSYA_Nm_Fm.Size = New System.Drawing.Size(391, 22)
        Me.cboKEIYAKUSYA_Nm_Fm.TabIndex = 25
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
        Me.Label10.Location = New System.Drawing.Point(45, 508)
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
        Me.cboITAKU_Cd_To.Location = New System.Drawing.Point(478, 472)
        Me.cboITAKU_Cd_To.MaxLength = 3
        Me.cboITAKU_Cd_To.Name = "cboITAKU_Cd_To"
        Me.cboITAKU_Cd_To.Size = New System.Drawing.Size(53, 22)
        Me.cboITAKU_Cd_To.Spin.AllowSpin = False
        Me.cboITAKU_Cd_To.TabIndex = 22
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
        Me.cboITAKU_Nm_To.Location = New System.Drawing.Point(537, 472)
        Me.cboITAKU_Nm_To.MaxLength = 50
        Me.cboITAKU_Nm_To.Name = "cboITAKU_Nm_To"
        Me.cboITAKU_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.cboITAKU_Nm_To.Size = New System.Drawing.Size(391, 22)
        Me.cboITAKU_Nm_To.TabIndex = 23
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
        Me.Label11.Location = New System.Drawing.Point(450, 475)
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
        Me.cboITAKU_Cd_Fm.Location = New System.Drawing.Point(184, 442)
        Me.cboITAKU_Cd_Fm.MaxLength = 3
        Me.cboITAKU_Cd_Fm.Name = "cboITAKU_Cd_Fm"
        Me.cboITAKU_Cd_Fm.Size = New System.Drawing.Size(51, 22)
        Me.cboITAKU_Cd_Fm.Spin.AllowSpin = False
        Me.cboITAKU_Cd_Fm.TabIndex = 20
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
        Me.cboITAKU_Nm_Fm.Location = New System.Drawing.Point(243, 442)
        Me.cboITAKU_Nm_Fm.MaxLength = 50
        Me.cboITAKU_Nm_Fm.Name = "cboITAKU_Nm_Fm"
        Me.cboITAKU_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton7})
        Me.cboITAKU_Nm_Fm.Size = New System.Drawing.Size(391, 22)
        Me.cboITAKU_Nm_Fm.TabIndex = 21
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
        Me.Label12.Location = New System.Drawing.Point(45, 445)
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
        Me.Label13.Location = New System.Drawing.Point(231, 148)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 15)
        Me.Label13.TabIndex = 982
        Me.Label13.Text = "～"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(45, 387)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 15)
        Me.Label16.TabIndex = 986
        Me.Label16.Text = "■入金・振込状況"
        '
        'chkNYUKIN_KBN_1
        '
        Me.chkNYUKIN_KBN_1.AutoSize = True
        Me.chkNYUKIN_KBN_1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkNYUKIN_KBN_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkNYUKIN_KBN_1.Location = New System.Drawing.Point(184, 385)
        Me.chkNYUKIN_KBN_1.Name = "chkNYUKIN_KBN_1"
        Me.chkNYUKIN_KBN_1.Size = New System.Drawing.Size(115, 20)
        Me.chkNYUKIN_KBN_1.TabIndex = 16
        Me.chkNYUKIN_KBN_1.Text = "入金・振込済"
        Me.chkNYUKIN_KBN_1.UseVisualStyleBackColor = True
        '
        'chkNYUKIN_KBN_2
        '
        Me.chkNYUKIN_KBN_2.AutoSize = True
        Me.chkNYUKIN_KBN_2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkNYUKIN_KBN_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkNYUKIN_KBN_2.Location = New System.Drawing.Point(303, 385)
        Me.chkNYUKIN_KBN_2.Name = "chkNYUKIN_KBN_2"
        Me.chkNYUKIN_KBN_2.Size = New System.Drawing.Size(130, 20)
        Me.chkNYUKIN_KBN_2.TabIndex = 17
        Me.chkNYUKIN_KBN_2.Text = "未入金・未振込"
        Me.chkNYUKIN_KBN_2.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(45, 191)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(105, 15)
        Me.Label29.TabIndex = 1017
        Me.Label29.Text = "■請求・返還日"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(315, 191)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(22, 15)
        Me.Label17.TabIndex = 1018
        Me.Label17.Text = "～"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(45, 239)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(105, 15)
        Me.Label18.TabIndex = 1021
        Me.Label18.Text = "■入金・振込日"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(315, 239)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(22, 15)
        Me.Label19.TabIndex = 1022
        Me.Label19.Text = "～"
        '
        'chkSEIKYU_HENKAN_KBN_3
        '
        Me.chkSEIKYU_HENKAN_KBN_3.AutoSize = True
        Me.chkSEIKYU_HENKAN_KBN_3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkSEIKYU_HENKAN_KBN_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkSEIKYU_HENKAN_KBN_3.Location = New System.Drawing.Point(439, 334)
        Me.chkSEIKYU_HENKAN_KBN_3.Name = "chkSEIKYU_HENKAN_KBN_3"
        Me.chkSEIKYU_HENKAN_KBN_3.Size = New System.Drawing.Size(92, 20)
        Me.chkSEIKYU_HENKAN_KBN_3.TabIndex = 14
        Me.chkSEIKYU_HENKAN_KBN_3.Text = "一部返還"
        Me.chkSEIKYU_HENKAN_KBN_3.UseVisualStyleBackColor = True
        '
        'chkSEIKYU_HENKAN_KBN_4
        '
        Me.chkSEIKYU_HENKAN_KBN_4.AutoSize = True
        Me.chkSEIKYU_HENKAN_KBN_4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkSEIKYU_HENKAN_KBN_4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkSEIKYU_HENKAN_KBN_4.Location = New System.Drawing.Point(560, 334)
        Me.chkSEIKYU_HENKAN_KBN_4.Name = "chkSEIKYU_HENKAN_KBN_4"
        Me.chkSEIKYU_HENKAN_KBN_4.Size = New System.Drawing.Size(92, 20)
        Me.chkSEIKYU_HENKAN_KBN_4.TabIndex = 15
        Me.chkSEIKYU_HENKAN_KBN_4.Text = "全額返還"
        Me.chkSEIKYU_HENKAN_KBN_4.UseVisualStyleBackColor = True
        '
        'chkNYUKIN_KBN_3
        '
        Me.chkNYUKIN_KBN_3.AutoSize = True
        Me.chkNYUKIN_KBN_3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkNYUKIN_KBN_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkNYUKIN_KBN_3.Location = New System.Drawing.Point(439, 385)
        Me.chkNYUKIN_KBN_3.Name = "chkNYUKIN_KBN_3"
        Me.chkNYUKIN_KBN_3.Size = New System.Drawing.Size(92, 20)
        Me.chkNYUKIN_KBN_3.TabIndex = 18
        Me.chkNYUKIN_KBN_3.Text = "一部入金"
        Me.chkNYUKIN_KBN_3.UseVisualStyleBackColor = True
        '
        'cmdExcel
        '
        Me.cmdExcel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdExcel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdExcel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdExcel.Location = New System.Drawing.Point(451, 5)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(92, 44)
        Me.cmdExcel.TabIndex = 4
        Me.cmdExcel.Text = "EXCEL出力"
        Me.cmdExcel.UseVisualStyleBackColor = False
        '
        'frmGJ2080
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.chkNYUKIN_KBN_3)
        Me.Controls.Add(Me.chkSEIKYU_HENKAN_KBN_4)
        Me.Controls.Add(Me.chkSEIKYU_HENKAN_KBN_3)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.dateNYUKIN_Ymd_Fm)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.dateNYUKIN_Ymd_To)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.dateSEIKYU_Ymd_Fm)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.dateSEIKYU_Ymd_To)
        Me.Controls.Add(Me.chkNYUKIN_KBN_2)
        Me.Controls.Add(Me.numSEIKYU_KAISU_To)
        Me.Controls.Add(Me.numSEIKYU_KAISU_Fm)
        Me.Controls.Add(Me.chkNYUKIN_KBN_1)
        Me.Controls.Add(Me.Label16)
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
        Me.Controls.Add(Me.chkSEIKYU_HENKAN_KBN_2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkSEIKYU_HENKAN_KBN_1)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Cd_To)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Nm_To)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Cd_Fm)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Nm_Fm)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numKI)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmGJ2080"
        Me.Text = "(GJ2080)生産者積立請求・返還一覧表（確定処理・未処理）"
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.numKI, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Cd_To, 0)
        Me.Controls.SetChildIndex(Me.chkSEIKYU_HENKAN_KBN_1, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.chkSEIKYU_HENKAN_KBN_2, 0)
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
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.chkNYUKIN_KBN_1, 0)
        Me.Controls.SetChildIndex(Me.numSEIKYU_KAISU_Fm, 0)
        Me.Controls.SetChildIndex(Me.numSEIKYU_KAISU_To, 0)
        Me.Controls.SetChildIndex(Me.chkNYUKIN_KBN_2, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.dateSEIKYU_Ymd_To, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.dateSEIKYU_Ymd_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label29, 0)
        Me.Controls.SetChildIndex(Me.dateNYUKIN_Ymd_To, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.dateNYUKIN_Ymd_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.chkSEIKYU_HENKAN_KBN_3, 0)
        Me.Controls.SetChildIndex(Me.chkSEIKYU_HENKAN_KBN_4, 0)
        Me.Controls.SetChildIndex(Me.chkNYUKIN_KBN_3, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSEIKYU_KAISU_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSEIKYU_KAISU_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateSEIKYU_Ymd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateSEIKYU_Ymd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateNYUKIN_Ymd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateNYUKIN_Ymd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateSEIKYU_DATE_Ymd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents chkSEIKYU_HENKAN_KBN_1 As JBD.Gjs.Win.CheckBox
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents chkSEIKYU_HENKAN_KBN_2 As JBD.Gjs.Win.CheckBox
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
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents chkNYUKIN_KBN_1 As JBD.Gjs.Win.CheckBox
    Friend WithEvents numSEIKYU_KAISU_Fm As JBD.Gjs.Win.GcNumber
    Friend WithEvents numSEIKYU_KAISU_To As JBD.Gjs.Win.GcNumber
    Friend WithEvents chkNYUKIN_KBN_2 As JBD.Gjs.Win.CheckBox
    Friend WithEvents Label29 As JBD.Gjs.Win.Label
    Friend WithEvents dateSEIKYU_Ymd_Fm As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton10 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents dateSEIKYU_Ymd_To As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton11 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents dateNYUKIN_Ymd_Fm As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton12 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents dateNYUKIN_Ymd_To As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton13 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents chkSEIKYU_HENKAN_KBN_3 As JBD.Gjs.Win.CheckBox
    Friend WithEvents chkSEIKYU_HENKAN_KBN_4 As JBD.Gjs.Win.CheckBox
    Friend WithEvents chkNYUKIN_KBN_3 As JBD.Gjs.Win.CheckBox
    Friend WithEvents dateSEIKYU_DATE_Ymd_Fm As JBD.Gjs.Win.GcDate
    Friend WithEvents cmdExcel As JBD.Gjs.Win.JButton
End Class
