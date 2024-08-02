Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ1070
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
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.numKI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.cmdExcel = New JBD.Gjs.Win.JButton(Me.components)
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
        Me.cboTORI_KBN_Cd_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboTORI_KBN_Nm_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton6 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboTORI_KBN_Cd_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboTORI_KBN_Nm_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton7 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.PrgBar = New System.Windows.Forms.ProgressBar()
        Me.pnlButton.SuspendLayout()
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_KBN_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_KBN_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_KBN_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_KBN_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEN_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEN_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEN_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEN_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTORI_KBN_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTORI_KBN_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTORI_KBN_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTORI_KBN_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label5.Location = New System.Drawing.Point(45, 129)
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
        Me.Label6.Location = New System.Drawing.Point(283, 129)
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
        Me.numKI.Location = New System.Drawing.Point(238, 126)
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
        Me.Label2.Location = New System.Drawing.Point(214, 129)
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
        Me.Label3.Location = New System.Drawing.Point(45, 194)
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
        Me.cboKEIYAKU_KBN_Cd_Fm.Location = New System.Drawing.Point(217, 191)
        Me.cboKEIYAKU_KBN_Cd_Fm.MaxLength = 1
        Me.cboKEIYAKU_KBN_Cd_Fm.Name = "cboKEIYAKU_KBN_Cd_Fm"
        Me.cboKEIYAKU_KBN_Cd_Fm.Size = New System.Drawing.Size(26, 22)
        Me.cboKEIYAKU_KBN_Cd_Fm.Spin.AllowSpin = False
        Me.cboKEIYAKU_KBN_Cd_Fm.TabIndex = 2
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
        Me.cboKEIYAKU_KBN_Nm_Fm.Location = New System.Drawing.Point(249, 191)
        Me.cboKEIYAKU_KBN_Nm_Fm.MaxLength = 50
        Me.cboKEIYAKU_KBN_Nm_Fm.Name = "cboKEIYAKU_KBN_Nm_Fm"
        Me.cboKEIYAKU_KBN_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton9})
        Me.cboKEIYAKU_KBN_Nm_Fm.Size = New System.Drawing.Size(106, 22)
        Me.cboKEIYAKU_KBN_Nm_Fm.TabIndex = 3
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
        Me.Label4.Location = New System.Drawing.Point(367, 194)
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
        Me.cboKEIYAKU_KBN_Cd_To.Location = New System.Drawing.Point(398, 191)
        Me.cboKEIYAKU_KBN_Cd_To.MaxLength = 1
        Me.cboKEIYAKU_KBN_Cd_To.Name = "cboKEIYAKU_KBN_Cd_To"
        Me.cboKEIYAKU_KBN_Cd_To.Size = New System.Drawing.Size(26, 22)
        Me.cboKEIYAKU_KBN_Cd_To.Spin.AllowSpin = False
        Me.cboKEIYAKU_KBN_Cd_To.TabIndex = 4
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
        Me.cboKEIYAKU_KBN_Nm_To.Location = New System.Drawing.Point(433, 191)
        Me.cboKEIYAKU_KBN_Nm_To.MaxLength = 8
        Me.cboKEIYAKU_KBN_Nm_To.Name = "cboKEIYAKU_KBN_Nm_To"
        Me.cboKEIYAKU_KBN_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cboKEIYAKU_KBN_Nm_To.Size = New System.Drawing.Size(106, 22)
        Me.cboKEIYAKU_KBN_Nm_To.TabIndex = 5
        Me.cboKEIYAKU_KBN_Nm_To.TabStop = False
        Me.cboKEIYAKU_KBN_Nm_To.Tag = "契約区分名"
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
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
        Me.cboKEIYAKUSYA_Cd_To.Location = New System.Drawing.Point(478, 445)
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
        Me.cboKEIYAKUSYA_Nm_To.Location = New System.Drawing.Point(538, 446)
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
        Me.Label9.Location = New System.Drawing.Point(450, 448)
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
        Me.cboKEIYAKUSYA_Cd_Fm.Location = New System.Drawing.Point(217, 409)
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
        Me.cboKEIYAKUSYA_Nm_Fm.Location = New System.Drawing.Point(277, 409)
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
        Me.Label10.Location = New System.Drawing.Point(45, 412)
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
        Me.cboKEN_Cd_To.Location = New System.Drawing.Point(401, 332)
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
        Me.cboKEN_Nm_To.Location = New System.Drawing.Point(433, 332)
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
        Me.Label8.Location = New System.Drawing.Point(367, 335)
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
        Me.cboKEN_Cd_Fm.Location = New System.Drawing.Point(217, 332)
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
        Me.cboKEN_Nm_Fm.Location = New System.Drawing.Point(249, 332)
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
        Me.Label13.Location = New System.Drawing.Point(45, 335)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 15)
        Me.Label13.TabIndex = 991
        Me.Label13.Text = "□都道府県"
        '
        'cboTORI_KBN_Cd_To
        '
        Me.cboTORI_KBN_Cd_To.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cboTORI_KBN_Cd_To.DropDown.AllowDrop = False
        Me.cboTORI_KBN_Cd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboTORI_KBN_Cd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboTORI_KBN_Cd_To.Format = "9"
        Me.cboTORI_KBN_Cd_To.HighlightText = True
        Me.cboTORI_KBN_Cd_To.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboTORI_KBN_Cd_To.ListHeaderPane.Height = 22
        Me.cboTORI_KBN_Cd_To.Location = New System.Drawing.Point(398, 259)
        Me.cboTORI_KBN_Cd_To.MaxLength = 2
        Me.cboTORI_KBN_Cd_To.Name = "cboTORI_KBN_Cd_To"
        Me.cboTORI_KBN_Cd_To.Size = New System.Drawing.Size(26, 22)
        Me.cboTORI_KBN_Cd_To.Spin.AllowSpin = False
        Me.cboTORI_KBN_Cd_To.TabIndex = 8
        Me.cboTORI_KBN_Cd_To.Tag = "鶏の種類"
        Me.cboTORI_KBN_Cd_To.Text = "99"
        '
        'cboTORI_KBN_Nm_To
        '
        Me.cboTORI_KBN_Nm_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTORI_KBN_Nm_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboTORI_KBN_Nm_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboTORI_KBN_Nm_To.ListHeaderPane.Height = 22
        Me.cboTORI_KBN_Nm_To.ListHeaderPane.Visible = False
        Me.cboTORI_KBN_Nm_To.Location = New System.Drawing.Point(433, 259)
        Me.cboTORI_KBN_Nm_To.MaxLength = 50
        Me.cboTORI_KBN_Nm_To.Name = "cboTORI_KBN_Nm_To"
        Me.cboTORI_KBN_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.cboTORI_KBN_Nm_To.Size = New System.Drawing.Size(106, 22)
        Me.cboTORI_KBN_Nm_To.TabIndex = 9
        Me.cboTORI_KBN_Nm_To.TabStop = False
        Me.cboTORI_KBN_Nm_To.Tag = "鶏の種類名"
        '
        'DropDownButton6
        '
        Me.DropDownButton6.Name = "DropDownButton6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(367, 262)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 15)
        Me.Label7.TabIndex = 998
        Me.Label7.Text = "～"
        '
        'cboTORI_KBN_Cd_Fm
        '
        Me.cboTORI_KBN_Cd_Fm.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cboTORI_KBN_Cd_Fm.DropDown.AllowDrop = False
        Me.cboTORI_KBN_Cd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboTORI_KBN_Cd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboTORI_KBN_Cd_Fm.Format = "9"
        Me.cboTORI_KBN_Cd_Fm.HighlightText = True
        Me.cboTORI_KBN_Cd_Fm.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboTORI_KBN_Cd_Fm.ListHeaderPane.Height = 22
        Me.cboTORI_KBN_Cd_Fm.Location = New System.Drawing.Point(217, 259)
        Me.cboTORI_KBN_Cd_Fm.MaxLength = 2
        Me.cboTORI_KBN_Cd_Fm.Name = "cboTORI_KBN_Cd_Fm"
        Me.cboTORI_KBN_Cd_Fm.Size = New System.Drawing.Size(26, 22)
        Me.cboTORI_KBN_Cd_Fm.Spin.AllowSpin = False
        Me.cboTORI_KBN_Cd_Fm.TabIndex = 6
        Me.cboTORI_KBN_Cd_Fm.Tag = "鶏の種類"
        Me.cboTORI_KBN_Cd_Fm.Text = "99"
        '
        'cboTORI_KBN_Nm_Fm
        '
        Me.cboTORI_KBN_Nm_Fm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTORI_KBN_Nm_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboTORI_KBN_Nm_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboTORI_KBN_Nm_Fm.ListHeaderPane.Height = 22
        Me.cboTORI_KBN_Nm_Fm.ListHeaderPane.Visible = False
        Me.cboTORI_KBN_Nm_Fm.Location = New System.Drawing.Point(249, 259)
        Me.cboTORI_KBN_Nm_Fm.MaxLength = 50
        Me.cboTORI_KBN_Nm_Fm.Name = "cboTORI_KBN_Nm_Fm"
        Me.cboTORI_KBN_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton7})
        Me.cboTORI_KBN_Nm_Fm.Size = New System.Drawing.Size(106, 22)
        Me.cboTORI_KBN_Nm_Fm.TabIndex = 7
        Me.cboTORI_KBN_Nm_Fm.TabStop = False
        Me.cboTORI_KBN_Nm_Fm.Tag = "鶏の種類名"
        '
        'DropDownButton7
        '
        Me.DropDownButton7.Name = "DropDownButton7"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(45, 262)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 15)
        Me.Label11.TabIndex = 997
        Me.Label11.Text = "□鳥の種類"
        '
        'PrgBar
        '
        Me.PrgBar.Location = New System.Drawing.Point(9, 620)
        Me.PrgBar.Name = "PrgBar"
        Me.PrgBar.Size = New System.Drawing.Size(980, 10)
        Me.PrgBar.TabIndex = 1003
        '
        'frmGJ1070
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.PrgBar)
        Me.Controls.Add(Me.cboTORI_KBN_Cd_To)
        Me.Controls.Add(Me.cboTORI_KBN_Nm_To)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboTORI_KBN_Cd_Fm)
        Me.Controls.Add(Me.cboTORI_KBN_Nm_Fm)
        Me.Controls.Add(Me.Label11)
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
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Cd_To)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Nm_To)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Cd_Fm)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Nm_Fm)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numKI)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmGJ1070"
        Me.Text = "(GJ1070)事業加入状況表作成処理(農場別リスト)"
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.numKI, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Cd_To, 0)
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
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.cboTORI_KBN_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboTORI_KBN_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cboTORI_KBN_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.cboTORI_KBN_Cd_To, 0)
        Me.Controls.SetChildIndex(Me.PrgBar, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_KBN_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_KBN_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_KBN_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_KBN_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEN_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEN_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEN_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEN_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTORI_KBN_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTORI_KBN_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTORI_KBN_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTORI_KBN_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cboKEIYAKU_KBN_Cd_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEIYAKU_KBN_Nm_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton9 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents cboKEIYAKU_KBN_Cd_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEIYAKU_KBN_Nm_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
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
    Friend WithEvents cboTORI_KBN_Cd_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboTORI_KBN_Nm_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton6 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents cboTORI_KBN_Cd_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboTORI_KBN_Nm_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton7 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents PrgBar As System.Windows.Forms.ProgressBar

End Class
