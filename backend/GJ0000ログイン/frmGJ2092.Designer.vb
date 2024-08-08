Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ2092
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
        Dim NumberIntegerPartDisplayField1 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim InvalidValue1 As GrapeCity.Win.Editors.GcNumberValidator.InvalidValue = New GrapeCity.Win.Editors.GcNumberValidator.InvalidValue()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DateEraYearField4 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraDisplayField4 As GrapeCity.Win.Editors.Fields.DateEraDisplayField = New GrapeCity.Win.Editors.Fields.DateEraDisplayField()
        Dim DateLiteralDisplayField10 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateEraYearDisplayField4 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateLiteralDisplayField11 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateMonthDisplayField4 As GrapeCity.Win.Editors.Fields.DateMonthDisplayField = New GrapeCity.Win.Editors.Fields.DateMonthDisplayField()
        Dim DateLiteralDisplayField12 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateDayDisplayField4 As GrapeCity.Win.Editors.Fields.DateDayDisplayField = New GrapeCity.Win.Editors.Fields.DateDayDisplayField()
        Dim DateEraField4 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField10 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateLiteralField11 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField4 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField12 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField4 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.numNYUKIN_GAKU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.Label30 = New JBD.Gjs.Win.Label(Me.components)
        Me.txtBiko = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.DropDownButton14 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton15 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton16 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton17 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton18 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton19 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.MEISAI_NO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NYUKIN_KAISU_MAX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NYUKIN_KAISU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NYUKIN_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NYUKIN_DATE_W = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NYUKIN_TUMITATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NYUKIN_TESU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOKEI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NYUKIN_GAKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NYUKIN_ZAN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BIKO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdDel = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdUpd = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdIns = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdCancel = New JBD.Gjs.Win.JButton(Me.components)
        Me.lblKEIYAKUSYA_NAME = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblSYORI_JOKYO_KBN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblKEN_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblKEIYAKUSYA_CD = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label65 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_HasuSeigen = New JBD.Gjs.Win.Label(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label32 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label33 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblSEIKYU_KIN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label31 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblTESURYO = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblTUMITATE_KIN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label25 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblSAGAKU_SEIKYU_KIN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label22 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblSEIKYU_KAISU = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label20 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblSEIKYU_DATE = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label27 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label34 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblKI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.dateNYUKIN_DATE_W = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton13 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label21 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblHENKAN_KIN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label35 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label23 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label26 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblNYUKIN_TUMITATE_KEI = New System.Windows.Forms.Label()
        Me.lblNYUKIN_TESU_KEI = New System.Windows.Forms.Label()
        Me.lblNYUKIN_GAKU_KEI = New System.Windows.Forms.Label()
        Me.lblNYUKIN_ZAN_KEI = New System.Windows.Forms.Label()
        Me.Label38 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label39 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblNYUKIN_TUMITATE = New System.Windows.Forms.Label()
        Me.lblNYUKIN_TESU = New System.Windows.Forms.Label()
        Me.lblNYUKIN_KAISU = New System.Windows.Forms.Label()
        Me.dateNYUKIN_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.lblMEISAI_NO = New System.Windows.Forms.Label()
        Me.lbl_KEIYAKU_HENKO_KBN = New System.Windows.Forms.Label()
        Me.dateKEIYAKU_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dateNYUHEN_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.pnlButton.SuspendLayout()
        CType(Me.numNYUKIN_GAKU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBiko, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dateNYUKIN_DATE_W, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateNYUKIN_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateKEIYAKU_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateNYUHEN_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdCancel)
        Me.pnlButton.Controls.Add(Me.cmdSave)
        Me.pnlButton.TabIndex = 101
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSave, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCancel, 0)
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
        Me.cmdEnd.Location = New System.Drawing.Point(967, 6)
        Me.cmdEnd.TabIndex = 2
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(12, 6)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 44)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Text = "保存"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'numNYUKIN_GAKU
        '
        Me.numNYUKIN_GAKU.AllowDeleteToNull = True
        NumberIntegerPartDisplayField1.GroupSizes = New Integer() {3}
        Me.numNYUKIN_GAKU.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField1})
        Me.numNYUKIN_GAKU.DropDown.AllowDrop = False
        Me.numNYUKIN_GAKU.Fields.DecimalPart.MaxDigits = 0
        Me.numNYUKIN_GAKU.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numNYUKIN_GAKU.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numNYUKIN_GAKU.Fields.IntegerPart.MaxDigits = 9
        Me.numNYUKIN_GAKU.Fields.IntegerPart.MinDigits = 1
        Me.numNYUKIN_GAKU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numNYUKIN_GAKU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numNYUKIN_GAKU.HighlightText = True
        Me.numNYUKIN_GAKU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numNYUKIN_GAKU.InputCheck = True
        Me.numNYUKIN_GAKU.Location = New System.Drawing.Point(415, 638)
        Me.numNYUKIN_GAKU.Name = "numNYUKIN_GAKU"
        Me.GcShortcut1.SetShortcuts(Me.numNYUKIN_GAKU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numNYUKIN_GAKU, Object), CType(Me.numNYUKIN_GAKU, Object), CType(Me.numNYUKIN_GAKU, Object), CType(Me.numNYUKIN_GAKU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numNYUKIN_GAKU.Size = New System.Drawing.Size(91, 20)
        Me.numNYUKIN_GAKU.Spin.Increment = 0
        Me.numNYUKIN_GAKU.TabIndex = 2
        Me.GcNumberValidator1.GetValidateItems(Me.numNYUKIN_GAKU).AddRange(New Object() {InvalidValue1})
        Me.numNYUKIN_GAKU.Value = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numNYUKIN_GAKU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        Me.numNYUKIN_GAKU.ZeroSuppress = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(57, 677)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(52, 15)
        Me.Label30.TabIndex = 67
        Me.Label30.Text = "□備考"
        '
        'txtBiko
        '
        Me.txtBiko.DropDown.AllowDrop = False
        Me.txtBiko.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txtBiko.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txtBiko.Format = "Ｚ"
        Me.txtBiko.HighlightText = True
        Me.txtBiko.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtBiko.Location = New System.Drawing.Point(173, 674)
        Me.txtBiko.MaxLength = 80
        Me.txtBiko.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txtBiko.Name = "txtBiko"
        Me.txtBiko.Size = New System.Drawing.Size(644, 20)
        Me.txtBiko.TabIndex = 26
        Me.txtBiko.Text = "ＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺＺ"
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
        'dgv_Search
        '
        Me.dgv_Search.AllowUserToAddRows = False
        Me.dgv_Search.AllowUserToDeleteRows = False
        Me.dgv_Search.AllowUserToResizeRows = False
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MEISAI_NO, Me.NYUKIN_KAISU_MAX, Me.NYUKIN_KAISU, Me.NYUKIN_DATE, Me.NYUKIN_DATE_W, Me.NYUKIN_TUMITATE, Me.NYUKIN_TESU, Me.GOKEI, Me.NYUKIN_GAKU, Me.NYUKIN_ZAN, Me.BIKO})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(25, 365)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(562, 88)
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
        Me.MEISAI_NO.HeaderText = "番号"
        Me.MEISAI_NO.Name = "MEISAI_NO"
        Me.MEISAI_NO.ReadOnly = True
        Me.MEISAI_NO.Width = 50
        '
        'NYUKIN_KAISU_MAX
        '
        Me.NYUKIN_KAISU_MAX.DataPropertyName = "NYUKIN_KAISU_MAX"
        Me.NYUKIN_KAISU_MAX.Frozen = True
        Me.NYUKIN_KAISU_MAX.HeaderText = "最大入金回数"
        Me.NYUKIN_KAISU_MAX.Name = "NYUKIN_KAISU_MAX"
        Me.NYUKIN_KAISU_MAX.ReadOnly = True
        Me.NYUKIN_KAISU_MAX.Visible = False
        '
        'NYUKIN_KAISU
        '
        Me.NYUKIN_KAISU.DataPropertyName = "NYUKIN_KAISU"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.NYUKIN_KAISU.DefaultCellStyle = DataGridViewCellStyle2
        Me.NYUKIN_KAISU.Frozen = True
        Me.NYUKIN_KAISU.HeaderText = "入金回数"
        Me.NYUKIN_KAISU.Name = "NYUKIN_KAISU"
        Me.NYUKIN_KAISU.ReadOnly = True
        Me.NYUKIN_KAISU.Visible = False
        '
        'NYUKIN_DATE
        '
        Me.NYUKIN_DATE.DataPropertyName = "NYUKIN_DATE"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NYUKIN_DATE.DefaultCellStyle = DataGridViewCellStyle3
        Me.NYUKIN_DATE.Frozen = True
        Me.NYUKIN_DATE.HeaderText = "入金日西暦"
        Me.NYUKIN_DATE.Name = "NYUKIN_DATE"
        Me.NYUKIN_DATE.ReadOnly = True
        Me.NYUKIN_DATE.Visible = False
        Me.NYUKIN_DATE.Width = 270
        '
        'NYUKIN_DATE_W
        '
        Me.NYUKIN_DATE_W.DataPropertyName = "NYUKIN_DATE_W"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NYUKIN_DATE_W.DefaultCellStyle = DataGridViewCellStyle4
        Me.NYUKIN_DATE_W.Frozen = True
        Me.NYUKIN_DATE_W.HeaderText = "入金日"
        Me.NYUKIN_DATE_W.Name = "NYUKIN_DATE_W"
        Me.NYUKIN_DATE_W.ReadOnly = True
        Me.NYUKIN_DATE_W.Width = 110
        '
        'NYUKIN_TUMITATE
        '
        Me.NYUKIN_TUMITATE.DataPropertyName = "NYUKIN_TUMITATE"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.NYUKIN_TUMITATE.DefaultCellStyle = DataGridViewCellStyle5
        Me.NYUKIN_TUMITATE.Frozen = True
        Me.NYUKIN_TUMITATE.HeaderText = "積立金額"
        Me.NYUKIN_TUMITATE.Name = "NYUKIN_TUMITATE"
        Me.NYUKIN_TUMITATE.ReadOnly = True
        '
        'NYUKIN_TESU
        '
        Me.NYUKIN_TESU.DataPropertyName = "NYUKIN_TESU"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.NYUKIN_TESU.DefaultCellStyle = DataGridViewCellStyle6
        Me.NYUKIN_TESU.Frozen = True
        Me.NYUKIN_TESU.HeaderText = "手数料額"
        Me.NYUKIN_TESU.Name = "NYUKIN_TESU"
        Me.NYUKIN_TESU.ReadOnly = True
        '
        'GOKEI
        '
        Me.GOKEI.DataPropertyName = "GOKEI"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.GOKEI.DefaultCellStyle = DataGridViewCellStyle7
        Me.GOKEI.Frozen = True
        Me.GOKEI.HeaderText = "合計額"
        Me.GOKEI.Name = "GOKEI"
        Me.GOKEI.ReadOnly = True
        '
        'NYUKIN_GAKU
        '
        Me.NYUKIN_GAKU.DataPropertyName = "NYUKIN_GAKU"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.NYUKIN_GAKU.DefaultCellStyle = DataGridViewCellStyle8
        Me.NYUKIN_GAKU.Frozen = True
        Me.NYUKIN_GAKU.HeaderText = "入金額"
        Me.NYUKIN_GAKU.Name = "NYUKIN_GAKU"
        Me.NYUKIN_GAKU.ReadOnly = True
        '
        'NYUKIN_ZAN
        '
        Me.NYUKIN_ZAN.DataPropertyName = "NYUKIN_ZAN"
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.NYUKIN_ZAN.DefaultCellStyle = DataGridViewCellStyle9
        Me.NYUKIN_ZAN.Frozen = True
        Me.NYUKIN_ZAN.HeaderText = "入金残"
        Me.NYUKIN_ZAN.Name = "NYUKIN_ZAN"
        Me.NYUKIN_ZAN.ReadOnly = True
        Me.NYUKIN_ZAN.Visible = False
        Me.NYUKIN_ZAN.Width = 200
        '
        'BIKO
        '
        Me.BIKO.DataPropertyName = "BIKO"
        Me.BIKO.HeaderText = "備考"
        Me.BIKO.Name = "BIKO"
        Me.BIKO.ReadOnly = True
        Me.BIKO.Visible = False
        '
        'cmdDel
        '
        Me.cmdDel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDel.Location = New System.Drawing.Point(379, 474)
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
        Me.cmdUpd.Location = New System.Drawing.Point(192, 474)
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
        Me.cmdIns.Location = New System.Drawing.Point(70, 474)
        Me.cmdIns.Name = "cmdIns"
        Me.cmdIns.Size = New System.Drawing.Size(92, 44)
        Me.cmdIns.TabIndex = 1
        Me.cmdIns.Text = "新規入金"
        Me.cmdIns.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(119, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(92, 44)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblKEIYAKUSYA_NAME
        '
        Me.lblKEIYAKUSYA_NAME.AutoSize = True
        Me.lblKEIYAKUSYA_NAME.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblKEIYAKUSYA_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblKEIYAKUSYA_NAME.Location = New System.Drawing.Point(205, 139)
        Me.lblKEIYAKUSYA_NAME.Name = "lblKEIYAKUSYA_NAME"
        Me.lblKEIYAKUSYA_NAME.Size = New System.Drawing.Size(87, 15)
        Me.lblKEIYAKUSYA_NAME.TabIndex = 1110
        Me.lblKEIYAKUSYA_NAME.Text = "NNNNNNNN"
        '
        'lblSYORI_JOKYO_KBN
        '
        Me.lblSYORI_JOKYO_KBN.AutoSize = True
        Me.lblSYORI_JOKYO_KBN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblSYORI_JOKYO_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblSYORI_JOKYO_KBN.Location = New System.Drawing.Point(608, 108)
        Me.lblSYORI_JOKYO_KBN.Name = "lblSYORI_JOKYO_KBN"
        Me.lblSYORI_JOKYO_KBN.Size = New System.Drawing.Size(67, 15)
        Me.lblSYORI_JOKYO_KBN.TabIndex = 1109
        Me.lblSYORI_JOKYO_KBN.Text = "NNNNNN"
        '
        'lblKEN_NM
        '
        Me.lblKEN_NM.AutoSize = True
        Me.lblKEN_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblKEN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblKEN_NM.Location = New System.Drawing.Point(413, 108)
        Me.lblKEN_NM.Name = "lblKEN_NM"
        Me.lblKEN_NM.Size = New System.Drawing.Size(47, 15)
        Me.lblKEN_NM.TabIndex = 1108
        Me.lblKEN_NM.Text = "NNNN"
        '
        'lblKEIYAKUSYA_CD
        '
        Me.lblKEIYAKUSYA_CD.AutoSize = True
        Me.lblKEIYAKUSYA_CD.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblKEIYAKUSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblKEIYAKUSYA_CD.Location = New System.Drawing.Point(205, 108)
        Me.lblKEIYAKUSYA_CD.Name = "lblKEIYAKUSYA_CD"
        Me.lblKEIYAKUSYA_CD.Size = New System.Drawing.Size(47, 15)
        Me.lblKEIYAKUSYA_CD.TabIndex = 1107
        Me.lblKEIYAKUSYA_CD.Text = "99999"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label65.Location = New System.Drawing.Point(84, 139)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(67, 15)
        Me.Label65.TabIndex = 1106
        Me.Label65.Text = "契約者名"
        '
        'lbl_HasuSeigen
        '
        Me.lbl_HasuSeigen.AutoSize = True
        Me.lbl_HasuSeigen.BackColor = System.Drawing.Color.Transparent
        Me.lbl_HasuSeigen.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_HasuSeigen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_HasuSeigen.Location = New System.Drawing.Point(520, 108)
        Me.lbl_HasuSeigen.Name = "lbl_HasuSeigen"
        Me.lbl_HasuSeigen.Size = New System.Drawing.Size(67, 15)
        Me.lbl_HasuSeigen.TabIndex = 1105
        Me.lbl_HasuSeigen.Text = "処理状況"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(333, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 1104
        Me.Label4.Text = "都道府県"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(84, 108)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 15)
        Me.Label10.TabIndex = 1103
        Me.Label10.Text = "契約者番号"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label32)
        Me.Panel2.Controls.Add(Me.Label33)
        Me.Panel2.Controls.Add(Me.lblSEIKYU_KIN)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label31)
        Me.Panel2.Controls.Add(Me.lblTESURYO)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.lblTUMITATE_KIN)
        Me.Panel2.Location = New System.Drawing.Point(334, 268)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(466, 76)
        Me.Panel2.TabIndex = 1126
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(426, 44)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(22, 15)
        Me.Label32.TabIndex = 1103
        Me.Label32.Text = "円"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(230, 44)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(97, 15)
        Me.Label33.TabIndex = 1101
        Me.Label33.Text = "積立金等総計"
        '
        'lblSEIKYU_KIN
        '
        Me.lblSEIKYU_KIN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblSEIKYU_KIN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblSEIKYU_KIN.Location = New System.Drawing.Point(335, 44)
        Me.lblSEIKYU_KIN.Name = "lblSEIKYU_KIN"
        Me.lblSEIKYU_KIN.Size = New System.Drawing.Size(85, 15)
        Me.lblSEIKYU_KIN.TabIndex = 1102
        Me.lblSEIKYU_KIN.Text = "999,999,999"
        Me.lblSEIKYU_KIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(426, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 15)
        Me.Label2.TabIndex = 1100
        Me.Label2.Text = "円"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(228, 11)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(52, 15)
        Me.Label31.TabIndex = 1098
        Me.Label31.Text = "手数料"
        '
        'lblTESURYO
        '
        Me.lblTESURYO.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblTESURYO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblTESURYO.Location = New System.Drawing.Point(335, 11)
        Me.lblTESURYO.Name = "lblTESURYO"
        Me.lblTESURYO.Size = New System.Drawing.Size(85, 15)
        Me.lblTESURYO.TabIndex = 1099
        Me.lblTESURYO.Text = "999,999,999"
        Me.lblTESURYO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(173, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 15)
        Me.Label9.TabIndex = 1097
        Me.Label9.Text = "円"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(9, 11)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 15)
        Me.Label15.TabIndex = 1095
        Me.Label15.Text = "積立金額"
        '
        'lblTUMITATE_KIN
        '
        Me.lblTUMITATE_KIN.AutoSize = True
        Me.lblTUMITATE_KIN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblTUMITATE_KIN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblTUMITATE_KIN.Location = New System.Drawing.Point(82, 11)
        Me.lblTUMITATE_KIN.Name = "lblTUMITATE_KIN"
        Me.lblTUMITATE_KIN.Size = New System.Drawing.Size(85, 15)
        Me.lblTUMITATE_KIN.TabIndex = 1096
        Me.lblTUMITATE_KIN.Text = "999,999,999"
        Me.lblTUMITATE_KIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(287, 280)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(22, 15)
        Me.Label25.TabIndex = 1125
        Me.Label25.Text = "円"
        '
        'lblSAGAKU_SEIKYU_KIN
        '
        Me.lblSAGAKU_SEIKYU_KIN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblSAGAKU_SEIKYU_KIN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblSAGAKU_SEIKYU_KIN.Location = New System.Drawing.Point(198, 280)
        Me.lblSAGAKU_SEIKYU_KIN.Name = "lblSAGAKU_SEIKYU_KIN"
        Me.lblSAGAKU_SEIKYU_KIN.Size = New System.Drawing.Size(85, 15)
        Me.lblSAGAKU_SEIKYU_KIN.TabIndex = 1124
        Me.lblSAGAKU_SEIKYU_KIN.Text = "999,999,999"
        Me.lblSAGAKU_SEIKYU_KIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(84, 280)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 15)
        Me.Label16.TabIndex = 1123
        Me.Label16.Text = "請求金額"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(57, 563)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(105, 15)
        Me.Label22.TabIndex = 1122
        Me.Label22.Text = "■入金・振込日"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(472, 238)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(22, 15)
        Me.Label19.TabIndex = 1119
        Me.Label19.Text = "回"
        '
        'lblSEIKYU_KAISU
        '
        Me.lblSEIKYU_KAISU.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblSEIKYU_KAISU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblSEIKYU_KAISU.Location = New System.Drawing.Point(435, 238)
        Me.lblSEIKYU_KAISU.Name = "lblSEIKYU_KAISU"
        Me.lblSEIKYU_KAISU.Size = New System.Drawing.Size(31, 15)
        Me.lblSEIKYU_KAISU.TabIndex = 1118
        Me.lblSEIKYU_KAISU.Text = "999"
        Me.lblSEIKYU_KAISU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(362, 238)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 15)
        Me.Label20.TabIndex = 1117
        Me.Label20.Text = "請求回数"
        '
        'lblSEIKYU_DATE
        '
        Me.lblSEIKYU_DATE.AutoSize = True
        Me.lblSEIKYU_DATE.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblSEIKYU_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblSEIKYU_DATE.Location = New System.Drawing.Point(198, 238)
        Me.lblSEIKYU_DATE.Name = "lblSEIKYU_DATE"
        Me.lblSEIKYU_DATE.Size = New System.Drawing.Size(101, 15)
        Me.lblSEIKYU_DATE.TabIndex = 1116
        Me.lblSEIKYU_DATE.Text = "平成99/99/99"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(84, 238)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(52, 15)
        Me.Label24.TabIndex = 1115
        Me.Label24.Text = "請求日"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(84, 211)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(52, 15)
        Me.Label27.TabIndex = 1114
        Me.Label27.Text = "対象期"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(60, 175)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(129, 19)
        Me.Label34.TabIndex = 1113
        Me.Label34.Text = "請求入金内容"
        '
        'lblKI
        '
        Me.lblKI.AutoSize = True
        Me.lblKI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblKI.Location = New System.Drawing.Point(198, 211)
        Me.lblKI.Name = "lblKI"
        Me.lblKI.Size = New System.Drawing.Size(23, 15)
        Me.lblKI.TabIndex = 1112
        Me.lblKI.Text = "99"
        Me.lblKI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dateNYUKIN_DATE_W
        '
        Me.dateNYUKIN_DATE_W.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.dateNYUKIN_DATE_W.DefaultActiveField = DateEraYearField1
        Me.dateNYUKIN_DATE_W.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.dateNYUKIN_DATE_W.DisabledForeColor = System.Drawing.SystemColors.WindowText
        DateEraYearDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField2.Text = "/"
        DateMonthDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField3.Text = "/"
        DateDayDisplayField1.ShowLeadingZero = True
        Me.dateNYUKIN_DATE_W.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField1, DateLiteralDisplayField1, DateEraYearDisplayField1, DateLiteralDisplayField2, DateMonthDisplayField1, DateLiteralDisplayField3, DateDayDisplayField1})
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.dateNYUKIN_DATE_W.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.dateNYUKIN_DATE_W.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateNYUKIN_DATE_W.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateNYUKIN_DATE_W.Location = New System.Drawing.Point(173, 560)
        Me.dateNYUKIN_DATE_W.Name = "dateNYUKIN_DATE_W"
        Me.dateNYUKIN_DATE_W.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton13})
        Me.dateNYUKIN_DATE_W.Size = New System.Drawing.Size(125, 21)
        Me.dateNYUKIN_DATE_W.Spin.AllowSpin = False
        Me.dateNYUKIN_DATE_W.TabIndex = 1
        Me.dateNYUKIN_DATE_W.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        '
        'DropDownButton13
        '
        Me.DropDownButton13.Name = "DropDownButton13"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(1012, 280)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(22, 15)
        Me.Label21.TabIndex = 1129
        Me.Label21.Text = "円"
        '
        'lblHENKAN_KIN
        '
        Me.lblHENKAN_KIN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblHENKAN_KIN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblHENKAN_KIN.Location = New System.Drawing.Point(921, 280)
        Me.lblHENKAN_KIN.Name = "lblHENKAN_KIN"
        Me.lblHENKAN_KIN.Size = New System.Drawing.Size(85, 15)
        Me.lblHENKAN_KIN.TabIndex = 1128
        Me.lblHENKAN_KIN.Text = "999,999,999"
        Me.lblHENKAN_KIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(838, 280)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(73, 30)
        Me.Label35.TabIndex = 1127
        Me.Label35.Text = "返還金額" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(預かり金)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(344, 563)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 1130
        Me.Label3.Text = "積立金額"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(512, 563)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 15)
        Me.Label5.TabIndex = 1104
        Me.Label5.Text = "円"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(512, 602)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 15)
        Me.Label6.TabIndex = 1132
        Me.Label6.Text = "円"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(344, 602)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 1133
        Me.Label7.Text = "手数料額"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(512, 641)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 15)
        Me.Label8.TabIndex = 1135
        Me.Label8.Text = "円"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(344, 641)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 15)
        Me.Label11.TabIndex = 1136
        Me.Label11.Text = "入金額"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(550, 563)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(235, 15)
        Me.Label12.TabIndex = 1138
        Me.Label12.Text = "（返還金額（預かり金）　＋　入金額）"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(793, 377)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 15)
        Me.Label13.TabIndex = 1141
        Me.Label13.Text = "円"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(613, 377)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 15)
        Me.Label14.TabIndex = 1139
        Me.Label14.Text = "積立金額計"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(793, 405)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(22, 15)
        Me.Label17.TabIndex = 1144
        Me.Label17.Text = "円"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(613, 405)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 15)
        Me.Label18.TabIndex = 1142
        Me.Label18.Text = "手数料額計"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(793, 432)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(22, 15)
        Me.Label23.TabIndex = 1147
        Me.Label23.Text = "円"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(613, 432)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(67, 15)
        Me.Label26.TabIndex = 1145
        Me.Label26.Text = "入金額計"
        '
        'lblNYUKIN_TUMITATE_KEI
        '
        Me.lblNYUKIN_TUMITATE_KEI.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNYUKIN_TUMITATE_KEI.Location = New System.Drawing.Point(702, 377)
        Me.lblNYUKIN_TUMITATE_KEI.Name = "lblNYUKIN_TUMITATE_KEI"
        Me.lblNYUKIN_TUMITATE_KEI.Size = New System.Drawing.Size(85, 15)
        Me.lblNYUKIN_TUMITATE_KEI.TabIndex = 1148
        Me.lblNYUKIN_TUMITATE_KEI.Text = "999,999,999"
        Me.lblNYUKIN_TUMITATE_KEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNYUKIN_TESU_KEI
        '
        Me.lblNYUKIN_TESU_KEI.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNYUKIN_TESU_KEI.Location = New System.Drawing.Point(702, 405)
        Me.lblNYUKIN_TESU_KEI.Name = "lblNYUKIN_TESU_KEI"
        Me.lblNYUKIN_TESU_KEI.Size = New System.Drawing.Size(85, 15)
        Me.lblNYUKIN_TESU_KEI.TabIndex = 1149
        Me.lblNYUKIN_TESU_KEI.Text = "999,999,999"
        Me.lblNYUKIN_TESU_KEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNYUKIN_GAKU_KEI
        '
        Me.lblNYUKIN_GAKU_KEI.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNYUKIN_GAKU_KEI.Location = New System.Drawing.Point(702, 432)
        Me.lblNYUKIN_GAKU_KEI.Name = "lblNYUKIN_GAKU_KEI"
        Me.lblNYUKIN_GAKU_KEI.Size = New System.Drawing.Size(85, 15)
        Me.lblNYUKIN_GAKU_KEI.TabIndex = 1150
        Me.lblNYUKIN_GAKU_KEI.Text = "999,999,999"
        Me.lblNYUKIN_GAKU_KEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNYUKIN_ZAN_KEI
        '
        Me.lblNYUKIN_ZAN_KEI.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNYUKIN_ZAN_KEI.Location = New System.Drawing.Point(917, 432)
        Me.lblNYUKIN_ZAN_KEI.Name = "lblNYUKIN_ZAN_KEI"
        Me.lblNYUKIN_ZAN_KEI.Size = New System.Drawing.Size(85, 15)
        Me.lblNYUKIN_ZAN_KEI.TabIndex = 1153
        Me.lblNYUKIN_ZAN_KEI.Text = "999,999,999"
        Me.lblNYUKIN_ZAN_KEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(1008, 432)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(22, 15)
        Me.Label38.TabIndex = 1152
        Me.Label38.Text = "円"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(832, 432)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(67, 15)
        Me.Label39.TabIndex = 1151
        Me.Label39.Text = "入金額残"
        '
        'lblNYUKIN_TUMITATE
        '
        Me.lblNYUKIN_TUMITATE.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNYUKIN_TUMITATE.Location = New System.Drawing.Point(423, 563)
        Me.lblNYUKIN_TUMITATE.Name = "lblNYUKIN_TUMITATE"
        Me.lblNYUKIN_TUMITATE.Size = New System.Drawing.Size(85, 15)
        Me.lblNYUKIN_TUMITATE.TabIndex = 1154
        Me.lblNYUKIN_TUMITATE.Text = "999,999,999"
        Me.lblNYUKIN_TUMITATE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNYUKIN_TESU
        '
        Me.lblNYUKIN_TESU.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNYUKIN_TESU.Location = New System.Drawing.Point(423, 602)
        Me.lblNYUKIN_TESU.Name = "lblNYUKIN_TESU"
        Me.lblNYUKIN_TESU.Size = New System.Drawing.Size(85, 15)
        Me.lblNYUKIN_TESU.TabIndex = 1155
        Me.lblNYUKIN_TESU.Text = "999,999,999"
        Me.lblNYUKIN_TESU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNYUKIN_KAISU
        '
        Me.lblNYUKIN_KAISU.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNYUKIN_KAISU.ForeColor = System.Drawing.Color.Red
        Me.lblNYUKIN_KAISU.Location = New System.Drawing.Point(50, 602)
        Me.lblNYUKIN_KAISU.Name = "lblNYUKIN_KAISU"
        Me.lblNYUKIN_KAISU.Size = New System.Drawing.Size(59, 15)
        Me.lblNYUKIN_KAISU.TabIndex = 1158
        Me.lblNYUKIN_KAISU.Text = "入金回数"
        Me.lblNYUKIN_KAISU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblNYUKIN_KAISU.Visible = False
        '
        'dateNYUKIN_DATE
        '
        Me.dateNYUKIN_DATE.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.dateNYUKIN_DATE.DefaultActiveField = DateEraYearField2
        Me.dateNYUKIN_DATE.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.dateNYUKIN_DATE.DisabledForeColor = System.Drawing.SystemColors.WindowText
        DateEraYearDisplayField2.ShowLeadingZero = True
        DateLiteralDisplayField5.Text = "/"
        DateMonthDisplayField2.ShowLeadingZero = True
        DateLiteralDisplayField6.Text = "/"
        DateDayDisplayField2.ShowLeadingZero = True
        Me.dateNYUKIN_DATE.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField2, DateLiteralDisplayField4, DateEraYearDisplayField2, DateLiteralDisplayField5, DateMonthDisplayField2, DateLiteralDisplayField6, DateDayDisplayField2})
        DateLiteralField5.Text = "/"
        DateLiteralField6.Text = "/"
        Me.dateNYUKIN_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateLiteralField4, DateEraYearField2, DateLiteralField5, DateMonthField2, DateLiteralField6, DateDayField2})
        Me.dateNYUKIN_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateNYUKIN_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateNYUKIN_DATE.ForeColor = System.Drawing.Color.Red
        Me.dateNYUKIN_DATE.Location = New System.Drawing.Point(180, 599)
        Me.dateNYUKIN_DATE.Name = "dateNYUKIN_DATE"
        Me.dateNYUKIN_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.dateNYUKIN_DATE.Size = New System.Drawing.Size(125, 21)
        Me.dateNYUKIN_DATE.Spin.AllowSpin = False
        Me.dateNYUKIN_DATE.TabIndex = 1159
        Me.dateNYUKIN_DATE.TabStop = False
        Me.dateNYUKIN_DATE.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        Me.dateNYUKIN_DATE.Visible = False
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'lblMEISAI_NO
        '
        Me.lblMEISAI_NO.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMEISAI_NO.ForeColor = System.Drawing.Color.Red
        Me.lblMEISAI_NO.Location = New System.Drawing.Point(107, 602)
        Me.lblMEISAI_NO.Name = "lblMEISAI_NO"
        Me.lblMEISAI_NO.Size = New System.Drawing.Size(59, 15)
        Me.lblMEISAI_NO.TabIndex = 1160
        Me.lblMEISAI_NO.Text = "明細番号"
        Me.lblMEISAI_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblMEISAI_NO.Visible = False
        '
        'lbl_KEIYAKU_HENKO_KBN
        '
        Me.lbl_KEIYAKU_HENKO_KBN.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_KEIYAKU_HENKO_KBN.ForeColor = System.Drawing.Color.Red
        Me.lbl_KEIYAKU_HENKO_KBN.Location = New System.Drawing.Point(57, 626)
        Me.lbl_KEIYAKU_HENKO_KBN.Name = "lbl_KEIYAKU_HENKO_KBN"
        Me.lbl_KEIYAKU_HENKO_KBN.Size = New System.Drawing.Size(59, 15)
        Me.lbl_KEIYAKU_HENKO_KBN.TabIndex = 1161
        Me.lbl_KEIYAKU_HENKO_KBN.Text = "契約変更区分"
        Me.lbl_KEIYAKU_HENKO_KBN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_KEIYAKU_HENKO_KBN.Visible = False
        '
        'dateKEIYAKU_DATE
        '
        Me.dateKEIYAKU_DATE.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.dateKEIYAKU_DATE.DefaultActiveField = DateEraYearField3
        Me.dateKEIYAKU_DATE.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.dateKEIYAKU_DATE.DisabledForeColor = System.Drawing.SystemColors.WindowText
        DateEraYearDisplayField3.ShowLeadingZero = True
        DateLiteralDisplayField8.Text = "/"
        DateMonthDisplayField3.ShowLeadingZero = True
        DateLiteralDisplayField9.Text = "/"
        DateDayDisplayField3.ShowLeadingZero = True
        Me.dateKEIYAKU_DATE.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField3, DateLiteralDisplayField7, DateEraYearDisplayField3, DateLiteralDisplayField8, DateMonthDisplayField3, DateLiteralDisplayField9, DateDayDisplayField3})
        DateLiteralField8.Text = "/"
        DateLiteralField9.Text = "/"
        Me.dateKEIYAKU_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField3, DateLiteralField7, DateEraYearField3, DateLiteralField8, DateMonthField3, DateLiteralField9, DateDayField3})
        Me.dateKEIYAKU_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateKEIYAKU_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateKEIYAKU_DATE.ForeColor = System.Drawing.Color.Red
        Me.dateKEIYAKU_DATE.Location = New System.Drawing.Point(180, 626)
        Me.dateKEIYAKU_DATE.Name = "dateKEIYAKU_DATE"
        Me.dateKEIYAKU_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.dateKEIYAKU_DATE.Size = New System.Drawing.Size(125, 21)
        Me.dateKEIYAKU_DATE.Spin.AllowSpin = False
        Me.dateKEIYAKU_DATE.TabIndex = 1162
        Me.dateKEIYAKU_DATE.TabStop = False
        Me.dateKEIYAKU_DATE.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        Me.dateKEIYAKU_DATE.Visible = False
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'dateNYUHEN_DATE
        '
        Me.dateNYUHEN_DATE.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.dateNYUHEN_DATE.DefaultActiveField = DateEraYearField4
        Me.dateNYUHEN_DATE.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.dateNYUHEN_DATE.DisabledForeColor = System.Drawing.SystemColors.WindowText
        DateEraYearDisplayField4.ShowLeadingZero = True
        DateLiteralDisplayField11.Text = "/"
        DateMonthDisplayField4.ShowLeadingZero = True
        DateLiteralDisplayField12.Text = "/"
        DateDayDisplayField4.ShowLeadingZero = True
        Me.dateNYUHEN_DATE.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField4, DateLiteralDisplayField10, DateEraYearDisplayField4, DateLiteralDisplayField11, DateMonthDisplayField4, DateLiteralDisplayField12, DateDayDisplayField4})
        DateLiteralField11.Text = "/"
        DateLiteralField12.Text = "/"
        Me.dateNYUHEN_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField4, DateLiteralField10, DateEraYearField4, DateLiteralField11, DateMonthField4, DateLiteralField12, DateDayField4})
        Me.dateNYUHEN_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateNYUHEN_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateNYUHEN_DATE.ForeColor = System.Drawing.Color.Red
        Me.dateNYUHEN_DATE.Location = New System.Drawing.Point(180, 649)
        Me.dateNYUHEN_DATE.Name = "dateNYUHEN_DATE"
        Me.dateNYUHEN_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.dateNYUHEN_DATE.Size = New System.Drawing.Size(125, 21)
        Me.dateNYUHEN_DATE.Spin.AllowSpin = False
        Me.dateNYUHEN_DATE.TabIndex = 1163
        Me.dateNYUHEN_DATE.TabStop = False
        Me.dateNYUHEN_DATE.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        Me.dateNYUHEN_DATE.Visible = False
        '
        'DropDownButton3
        '
        Me.DropDownButton3.Name = "DropDownButton3"
        '
        'frmGJ2092
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.dateNYUHEN_DATE)
        Me.Controls.Add(Me.dateKEIYAKU_DATE)
        Me.Controls.Add(Me.lbl_KEIYAKU_HENKO_KBN)
        Me.Controls.Add(Me.lblMEISAI_NO)
        Me.Controls.Add(Me.dateNYUKIN_DATE)
        Me.Controls.Add(Me.lblNYUKIN_KAISU)
        Me.Controls.Add(Me.numNYUKIN_GAKU)
        Me.Controls.Add(Me.lblNYUKIN_TESU)
        Me.Controls.Add(Me.lblNYUKIN_TUMITATE)
        Me.Controls.Add(Me.lblNYUKIN_ZAN_KEI)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.lblNYUKIN_GAKU_KEI)
        Me.Controls.Add(Me.lblNYUKIN_TESU_KEI)
        Me.Controls.Add(Me.lblNYUKIN_TUMITATE_KEI)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.lblHENKAN_KIN)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.lblSAGAKU_SEIKYU_KIN)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lblSEIKYU_KAISU)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lblSEIKYU_DATE)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.lblKI)
        Me.Controls.Add(Me.dateNYUKIN_DATE_W)
        Me.Controls.Add(Me.lblKEIYAKUSYA_NAME)
        Me.Controls.Add(Me.lblSYORI_JOKYO_KBN)
        Me.Controls.Add(Me.lblKEN_NM)
        Me.Controls.Add(Me.lblKEIYAKUSYA_CD)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.lbl_HasuSeigen)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdUpd)
        Me.Controls.Add(Me.cmdIns)
        Me.Controls.Add(Me.dgv_Search)
        Me.Controls.Add(Me.txtBiko)
        Me.Controls.Add(Me.Label30)
        Me.Name = "frmGJ2092"
        Me.Text = "(GJ2092)契約者積立金等分割入金確認"
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.txtBiko, 0)
        Me.Controls.SetChildIndex(Me.dgv_Search, 0)
        Me.Controls.SetChildIndex(Me.cmdIns, 0)
        Me.Controls.SetChildIndex(Me.cmdUpd, 0)
        Me.Controls.SetChildIndex(Me.cmdDel, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.lbl_HasuSeigen, 0)
        Me.Controls.SetChildIndex(Me.Label65, 0)
        Me.Controls.SetChildIndex(Me.lblKEIYAKUSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.lblKEN_NM, 0)
        Me.Controls.SetChildIndex(Me.lblSYORI_JOKYO_KBN, 0)
        Me.Controls.SetChildIndex(Me.lblKEIYAKUSYA_NAME, 0)
        Me.Controls.SetChildIndex(Me.dateNYUKIN_DATE_W, 0)
        Me.Controls.SetChildIndex(Me.lblKI, 0)
        Me.Controls.SetChildIndex(Me.Label34, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.lblSEIKYU_DATE, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.lblSEIKYU_KAISU, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.lblSAGAKU_SEIKYU_KIN, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Label35, 0)
        Me.Controls.SetChildIndex(Me.lblHENKAN_KIN, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.lblNYUKIN_TUMITATE_KEI, 0)
        Me.Controls.SetChildIndex(Me.lblNYUKIN_TESU_KEI, 0)
        Me.Controls.SetChildIndex(Me.lblNYUKIN_GAKU_KEI, 0)
        Me.Controls.SetChildIndex(Me.Label39, 0)
        Me.Controls.SetChildIndex(Me.Label38, 0)
        Me.Controls.SetChildIndex(Me.lblNYUKIN_ZAN_KEI, 0)
        Me.Controls.SetChildIndex(Me.lblNYUKIN_TUMITATE, 0)
        Me.Controls.SetChildIndex(Me.lblNYUKIN_TESU, 0)
        Me.Controls.SetChildIndex(Me.numNYUKIN_GAKU, 0)
        Me.Controls.SetChildIndex(Me.lblNYUKIN_KAISU, 0)
        Me.Controls.SetChildIndex(Me.dateNYUKIN_DATE, 0)
        Me.Controls.SetChildIndex(Me.lblMEISAI_NO, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_HENKO_KBN, 0)
        Me.Controls.SetChildIndex(Me.dateKEIYAKU_DATE, 0)
        Me.Controls.SetChildIndex(Me.dateNYUHEN_DATE, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.numNYUKIN_GAKU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBiko, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dateNYUKIN_DATE_W, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateNYUKIN_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateKEIYAKU_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateNYUHEN_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSave As JBD.Gjs.Win.JButton
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents GcDateValidator1 As GrapeCity.Win.Editors.GcDateValidator
    Friend WithEvents Label30 As JBD.Gjs.Win.Label
    Friend WithEvents txtBiko As JBD.Gjs.Win.GcTextBox
    Friend WithEvents DropDownButton14 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton15 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton16 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton17 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton18 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton19 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents dgv_Search As JBD.Gjs.Win.DataGridView
    Friend WithEvents cmdDel As JBD.Gjs.Win.JButton
    Friend WithEvents cmdUpd As JBD.Gjs.Win.JButton
    Friend WithEvents cmdIns As JBD.Gjs.Win.JButton
    Friend WithEvents cmdCancel As JBD.Gjs.Win.JButton
    Friend WithEvents lblKEIYAKUSYA_NAME As JBD.Gjs.Win.JLabel
    Friend WithEvents lblSYORI_JOKYO_KBN As JBD.Gjs.Win.JLabel
    Friend WithEvents lblKEN_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents lblKEIYAKUSYA_CD As JBD.Gjs.Win.JLabel
    Friend WithEvents Label65 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_HasuSeigen As JBD.Gjs.Win.Label
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label32 As JBD.Gjs.Win.Label
    Friend WithEvents Label33 As JBD.Gjs.Win.Label
    Friend WithEvents lblSEIKYU_KIN As JBD.Gjs.Win.JLabel
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents Label31 As JBD.Gjs.Win.Label
    Friend WithEvents lblTESURYO As JBD.Gjs.Win.JLabel
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents lblTUMITATE_KIN As JBD.Gjs.Win.JLabel
    Friend WithEvents Label25 As JBD.Gjs.Win.Label
    Friend WithEvents lblSAGAKU_SEIKYU_KIN As JBD.Gjs.Win.JLabel
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents Label22 As JBD.Gjs.Win.Label
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents lblSEIKYU_KAISU As JBD.Gjs.Win.JLabel
    Friend WithEvents Label20 As JBD.Gjs.Win.Label
    Friend WithEvents lblSEIKYU_DATE As JBD.Gjs.Win.JLabel
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents Label27 As JBD.Gjs.Win.Label
    Friend WithEvents Label34 As JBD.Gjs.Win.Label
    Friend WithEvents lblKI As JBD.Gjs.Win.JLabel
    Friend WithEvents dateNYUKIN_DATE_W As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton13 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label21 As JBD.Gjs.Win.Label
    Friend WithEvents lblHENKAN_KIN As JBD.Gjs.Win.JLabel
    Friend WithEvents Label35 As JBD.Gjs.Win.Label
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents Label23 As JBD.Gjs.Win.Label
    Friend WithEvents Label26 As JBD.Gjs.Win.Label
    Friend WithEvents lblNYUKIN_TUMITATE_KEI As System.Windows.Forms.Label
    Friend WithEvents lblNYUKIN_TESU_KEI As System.Windows.Forms.Label
    Friend WithEvents lblNYUKIN_GAKU_KEI As System.Windows.Forms.Label
    Friend WithEvents lblNYUKIN_ZAN_KEI As System.Windows.Forms.Label
    Friend WithEvents Label38 As JBD.Gjs.Win.Label
    Friend WithEvents Label39 As JBD.Gjs.Win.Label
    Friend WithEvents lblNYUKIN_TUMITATE As System.Windows.Forms.Label
    Friend WithEvents lblNYUKIN_TESU As System.Windows.Forms.Label
    Friend WithEvents numNYUKIN_GAKU As JBD.Gjs.Win.GcNumber
    Friend WithEvents lblNYUKIN_KAISU As System.Windows.Forms.Label
    Friend WithEvents dateNYUKIN_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents MEISAI_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NYUKIN_KAISU_MAX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NYUKIN_KAISU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NYUKIN_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NYUKIN_DATE_W As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NYUKIN_TUMITATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NYUKIN_TESU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GOKEI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NYUKIN_GAKU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NYUKIN_ZAN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BIKO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblMEISAI_NO As System.Windows.Forms.Label
    Friend WithEvents lbl_KEIYAKU_HENKO_KBN As System.Windows.Forms.Label
    Friend WithEvents dateKEIYAKU_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents dateNYUHEN_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
End Class
