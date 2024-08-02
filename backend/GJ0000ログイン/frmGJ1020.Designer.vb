Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ1020
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
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.num_IDO_HASU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.txt_KI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.DropDownButton14 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton15 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton16 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton17 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton18 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton19 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.KEIYAKU_DATE_FROM_X = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_DATE_FROM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TORI_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TORI_KBN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDO_HASU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOJO_CD_MOTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOJO_NM_MOTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_HASU_MOTO_MAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_HASU_MOTO_ATO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOJO_CD_SAKI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOJO_NM_SAKI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_HASU_SAKI_MAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_HASU_SAKI_ATO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYORI_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYORI_KBN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOTO_SEQNO_MAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOTO_SEQNO_ATO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SAKI_SEQNO_MAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SAKI_SEQNO_ATO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdDel = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdUpd = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdIns = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label23 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label26 = New JBD.Gjs.Win.Label(Me.components)
        Me.date_KEIYAKU_DATE_FROM = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label28 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdCansel = New JBD.Gjs.Win.JButton(Me.components)
        Me.lbl_KEIYAKU_HASU_MOTO_MAE = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_POST_MOTO = New JBD.Gjs.Win.JLabel(Me.components)
        Me.cob_NOJO_CD_MOTO = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_NOJO_NM_MOTO = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.lbl_ADDR_1_MOTO = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_2_MOTO = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_4_MOTO = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_3_MOTO = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_TORI_KBN = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_TORI_KBN_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.cmd_NOJO_INS = New JBD.Gjs.Win.JButton(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label29 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblCOUNT = New JBD.Gjs.Win.Label(Me.components)
        Me.Label27 = New JBD.Gjs.Win.Label(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KEIYAKUSYA_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEIYAKUSYA_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton5 = New GrapeCity.Win.Editors.DropDownButton()
        Me.pnl_SYORI_KBN2 = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_SYORI_KBN2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_SYORI_KBN1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_KEIYAKU_HASU_MOTO_ATO = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_KEIYAKU_HASU_SAKI_ATO = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_ADDR_4_SAKI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_3_SAKI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_2_SAKI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_1_SAKI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label20 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label21 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_NOJO_CD_SAKI = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_NOJO_NM_SAKI = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.lbl_ADDR_POST_SAKI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKU_HASU_SAKI_MAE = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label22 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label25 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdSearchClr = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdSearch = New JBD.Gjs.Win.JButton(Me.components)
        Me.lbl_MOTO_SEQNO_MAE = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_MOTO_SEQNO_ATO = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_SAKI_SEQNO_ATO = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_SAKI_SEQNO_MAE = New JBD.Gjs.Win.Label(Me.components)
        Me.Label31 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.num_IDO_HASU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_KEIYAKU_DATE_FROM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_NOJO_CD_MOTO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_NOJO_NM_MOTO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_TORI_KBN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_TORI_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cob_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKUSYA_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_SYORI_KBN2.SuspendLayout()
        CType(Me.cob_NOJO_CD_SAKI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_NOJO_NM_SAKI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdCansel)
        Me.pnlButton.Controls.Add(Me.cmdSave)
        Me.pnlButton.TabIndex = 101
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSave, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCansel, 0)
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
        Me.cmdSave.Location = New System.Drawing.Point(12, 3)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 44)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Text = "保存"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'num_IDO_HASU
        '
        Me.num_IDO_HASU.AllowDeleteToNull = True
        Me.num_IDO_HASU.DropDown.AllowDrop = False
        Me.num_IDO_HASU.Fields.DecimalPart.MaxDigits = 0
        Me.num_IDO_HASU.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_IDO_HASU.Fields.IntegerPart.MaxDigits = 8
        Me.num_IDO_HASU.Fields.IntegerPart.MinDigits = 1
        Me.num_IDO_HASU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_IDO_HASU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_IDO_HASU.HighlightText = True
        Me.num_IDO_HASU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_IDO_HASU.InputCheck = True
        Me.num_IDO_HASU.Location = New System.Drawing.Point(199, 419)
        Me.num_IDO_HASU.Name = "num_IDO_HASU"
        Me.num_IDO_HASU.NegativeColor = System.Drawing.Color.Black
        Me.GcShortcut1.SetShortcuts(Me.num_IDO_HASU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_IDO_HASU, Object), CType(Me.num_IDO_HASU, Object), CType(Me.num_IDO_HASU, Object), CType(Me.num_IDO_HASU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_IDO_HASU.Size = New System.Drawing.Size(85, 22)
        Me.num_IDO_HASU.Spin.Increment = 0
        Me.num_IDO_HASU.TabIndex = 13
        Me.num_IDO_HASU.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_IDO_HASU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'txt_KI
        '
        Me.txt_KI.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_KI.DropDown.AllowDrop = False
        Me.txt_KI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_KI.Format = "9"
        Me.txt_KI.HighlightText = True
        Me.txt_KI.InputCheck = True
        Me.txt_KI.Location = New System.Drawing.Point(136, 52)
        Me.txt_KI.MaxLength = 2
        Me.txt_KI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KI.Name = "txt_KI"
        Me.GcShortcut1.SetShortcuts(Me.txt_KI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_KI, Object)}, New String() {"ShortcutClear"}))
        Me.txt_KI.Size = New System.Drawing.Size(36, 20)
        Me.txt_KI.TabIndex = 0
        Me.txt_KI.Text = "99"
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
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KEIYAKU_DATE_FROM_X, Me.KEIYAKU_DATE_FROM, Me.TORI_KBN, Me.TORI_KBN_NM, Me.IDO_HASU, Me.NOJO_CD_MOTO, Me.NOJO_NM_MOTO, Me.KEIYAKU_HASU_MOTO_MAE, Me.KEIYAKU_HASU_MOTO_ATO, Me.NOJO_CD_SAKI, Me.NOJO_NM_SAKI, Me.KEIYAKU_HASU_SAKI_MAE, Me.KEIYAKU_HASU_SAKI_ATO, Me.SYORI_KBN, Me.SYORI_KBN_NM, Me.MOTO_SEQNO_MAE, Me.MOTO_SEQNO_ATO, Me.SAKI_SEQNO_MAE, Me.SAKI_SEQNO_ATO})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(13, 139)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(1070, 151)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 5
        '
        'KEIYAKU_DATE_FROM_X
        '
        Me.KEIYAKU_DATE_FROM_X.DataPropertyName = "KEIYAKU_DATE_FROM_X"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKU_DATE_FROM_X.DefaultCellStyle = DataGridViewCellStyle1
        Me.KEIYAKU_DATE_FROM_X.HeaderText = "移動開始日"
        Me.KEIYAKU_DATE_FROM_X.Name = "KEIYAKU_DATE_FROM_X"
        Me.KEIYAKU_DATE_FROM_X.ReadOnly = True
        Me.KEIYAKU_DATE_FROM_X.Width = 110
        '
        'KEIYAKU_DATE_FROM
        '
        Me.KEIYAKU_DATE_FROM.DataPropertyName = "KEIYAKU_DATE_FROM"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKU_DATE_FROM.DefaultCellStyle = DataGridViewCellStyle2
        Me.KEIYAKU_DATE_FROM.HeaderText = "移動開始日(西暦)"
        Me.KEIYAKU_DATE_FROM.Name = "KEIYAKU_DATE_FROM"
        Me.KEIYAKU_DATE_FROM.ReadOnly = True
        Me.KEIYAKU_DATE_FROM.Visible = False
        '
        'TORI_KBN
        '
        Me.TORI_KBN.DataPropertyName = "TORI_KBN"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.TORI_KBN.DefaultCellStyle = DataGridViewCellStyle3
        Me.TORI_KBN.HeaderText = "鳥の種類コード"
        Me.TORI_KBN.Name = "TORI_KBN"
        Me.TORI_KBN.ReadOnly = True
        Me.TORI_KBN.Visible = False
        Me.TORI_KBN.Width = 20
        '
        'TORI_KBN_NM
        '
        Me.TORI_KBN_NM.DataPropertyName = "TORI_KBN_NM"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.TORI_KBN_NM.DefaultCellStyle = DataGridViewCellStyle4
        Me.TORI_KBN_NM.HeaderText = "鳥の種類"
        Me.TORI_KBN_NM.Name = "TORI_KBN_NM"
        Me.TORI_KBN_NM.ReadOnly = True
        Me.TORI_KBN_NM.Width = 75
        '
        'IDO_HASU
        '
        Me.IDO_HASU.DataPropertyName = "IDO_HASU"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.IDO_HASU.DefaultCellStyle = DataGridViewCellStyle5
        Me.IDO_HASU.HeaderText = "移動羽数"
        Me.IDO_HASU.Name = "IDO_HASU"
        Me.IDO_HASU.ReadOnly = True
        Me.IDO_HASU.Width = 85
        '
        'NOJO_CD_MOTO
        '
        Me.NOJO_CD_MOTO.DataPropertyName = "NOJO_CD_MOTO"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NOJO_CD_MOTO.DefaultCellStyle = DataGridViewCellStyle6
        Me.NOJO_CD_MOTO.HeaderText = "農場CD(移動元)"
        Me.NOJO_CD_MOTO.Name = "NOJO_CD_MOTO"
        Me.NOJO_CD_MOTO.ReadOnly = True
        Me.NOJO_CD_MOTO.Visible = False
        '
        'NOJO_NM_MOTO
        '
        Me.NOJO_NM_MOTO.DataPropertyName = "NOJO_NM_MOTO"
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.NOJO_NM_MOTO.DefaultCellStyle = DataGridViewCellStyle7
        Me.NOJO_NM_MOTO.HeaderText = "農場名(移動元)"
        Me.NOJO_NM_MOTO.Name = "NOJO_NM_MOTO"
        Me.NOJO_NM_MOTO.ReadOnly = True
        Me.NOJO_NM_MOTO.Width = 220
        '
        'KEIYAKU_HASU_MOTO_MAE
        '
        Me.KEIYAKU_HASU_MOTO_MAE.DataPropertyName = "KEIYAKU_HASU_MOTO_MAE"
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.KEIYAKU_HASU_MOTO_MAE.DefaultCellStyle = DataGridViewCellStyle8
        Me.KEIYAKU_HASU_MOTO_MAE.HeaderText = "移動前羽数(移動元)"
        Me.KEIYAKU_HASU_MOTO_MAE.Name = "KEIYAKU_HASU_MOTO_MAE"
        Me.KEIYAKU_HASU_MOTO_MAE.ReadOnly = True
        Me.KEIYAKU_HASU_MOTO_MAE.Visible = False
        '
        'KEIYAKU_HASU_MOTO_ATO
        '
        Me.KEIYAKU_HASU_MOTO_ATO.DataPropertyName = "KEIYAKU_HASU_MOTO_ATO"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.KEIYAKU_HASU_MOTO_ATO.DefaultCellStyle = DataGridViewCellStyle9
        Me.KEIYAKU_HASU_MOTO_ATO.HeaderText = "契約羽数(移動元)"
        Me.KEIYAKU_HASU_MOTO_ATO.Name = "KEIYAKU_HASU_MOTO_ATO"
        Me.KEIYAKU_HASU_MOTO_ATO.ReadOnly = True
        Me.KEIYAKU_HASU_MOTO_ATO.Width = 130
        '
        'NOJO_CD_SAKI
        '
        Me.NOJO_CD_SAKI.DataPropertyName = "NOJO_CD_SAKI"
        DataGridViewCellStyle10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.NOJO_CD_SAKI.DefaultCellStyle = DataGridViewCellStyle10
        Me.NOJO_CD_SAKI.HeaderText = "農場CD(移動先)"
        Me.NOJO_CD_SAKI.Name = "NOJO_CD_SAKI"
        Me.NOJO_CD_SAKI.ReadOnly = True
        Me.NOJO_CD_SAKI.Visible = False
        '
        'NOJO_NM_SAKI
        '
        Me.NOJO_NM_SAKI.DataPropertyName = "NOJO_NM_SAKI"
        DataGridViewCellStyle11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NOJO_NM_SAKI.DefaultCellStyle = DataGridViewCellStyle11
        Me.NOJO_NM_SAKI.HeaderText = "農場名(移動先)"
        Me.NOJO_NM_SAKI.Name = "NOJO_NM_SAKI"
        Me.NOJO_NM_SAKI.ReadOnly = True
        Me.NOJO_NM_SAKI.Width = 220
        '
        'KEIYAKU_HASU_SAKI_MAE
        '
        Me.KEIYAKU_HASU_SAKI_MAE.DataPropertyName = "KEIYAKU_HASU_SAKI_MAE"
        DataGridViewCellStyle12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle12.Format = "N0"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.KEIYAKU_HASU_SAKI_MAE.DefaultCellStyle = DataGridViewCellStyle12
        Me.KEIYAKU_HASU_SAKI_MAE.HeaderText = "移動前羽数(移動先)"
        Me.KEIYAKU_HASU_SAKI_MAE.Name = "KEIYAKU_HASU_SAKI_MAE"
        Me.KEIYAKU_HASU_SAKI_MAE.ReadOnly = True
        Me.KEIYAKU_HASU_SAKI_MAE.Visible = False
        '
        'KEIYAKU_HASU_SAKI_ATO
        '
        Me.KEIYAKU_HASU_SAKI_ATO.DataPropertyName = "KEIYAKU_HASU_SAKI_ATO"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle13.Format = "N0"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.KEIYAKU_HASU_SAKI_ATO.DefaultCellStyle = DataGridViewCellStyle13
        Me.KEIYAKU_HASU_SAKI_ATO.HeaderText = "契約羽数(移動先)"
        Me.KEIYAKU_HASU_SAKI_ATO.Name = "KEIYAKU_HASU_SAKI_ATO"
        Me.KEIYAKU_HASU_SAKI_ATO.ReadOnly = True
        Me.KEIYAKU_HASU_SAKI_ATO.Width = 130
        '
        'SYORI_KBN
        '
        Me.SYORI_KBN.DataPropertyName = "SYORI_KBN"
        DataGridViewCellStyle14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYORI_KBN.DefaultCellStyle = DataGridViewCellStyle14
        Me.SYORI_KBN.HeaderText = "処理区分コード"
        Me.SYORI_KBN.Name = "SYORI_KBN"
        Me.SYORI_KBN.ReadOnly = True
        Me.SYORI_KBN.Visible = False
        '
        'SYORI_KBN_NM
        '
        Me.SYORI_KBN_NM.DataPropertyName = "SYORI_KBN_NM"
        DataGridViewCellStyle15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYORI_KBN_NM.DefaultCellStyle = DataGridViewCellStyle15
        Me.SYORI_KBN_NM.HeaderText = "処理区分"
        Me.SYORI_KBN_NM.Name = "SYORI_KBN_NM"
        Me.SYORI_KBN_NM.ReadOnly = True
        Me.SYORI_KBN_NM.Width = 80
        '
        'MOTO_SEQNO_MAE
        '
        Me.MOTO_SEQNO_MAE.DataPropertyName = "MOTO_SEQNO_MAE"
        DataGridViewCellStyle16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MOTO_SEQNO_MAE.DefaultCellStyle = DataGridViewCellStyle16
        Me.MOTO_SEQNO_MAE.HeaderText = "元SEQ(移動元移動前)"
        Me.MOTO_SEQNO_MAE.Name = "MOTO_SEQNO_MAE"
        Me.MOTO_SEQNO_MAE.ReadOnly = True
        Me.MOTO_SEQNO_MAE.Visible = False
        '
        'MOTO_SEQNO_ATO
        '
        Me.MOTO_SEQNO_ATO.DataPropertyName = "MOTO_SEQNO_ATO"
        DataGridViewCellStyle17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MOTO_SEQNO_ATO.DefaultCellStyle = DataGridViewCellStyle17
        Me.MOTO_SEQNO_ATO.HeaderText = "元SEQ(移動元移動後)"
        Me.MOTO_SEQNO_ATO.Name = "MOTO_SEQNO_ATO"
        Me.MOTO_SEQNO_ATO.ReadOnly = True
        Me.MOTO_SEQNO_ATO.Visible = False
        '
        'SAKI_SEQNO_MAE
        '
        Me.SAKI_SEQNO_MAE.DataPropertyName = "SAKI_SEQNO_MAE"
        DataGridViewCellStyle18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SAKI_SEQNO_MAE.DefaultCellStyle = DataGridViewCellStyle18
        Me.SAKI_SEQNO_MAE.HeaderText = "元SEQ(移動先移動前)"
        Me.SAKI_SEQNO_MAE.Name = "SAKI_SEQNO_MAE"
        Me.SAKI_SEQNO_MAE.ReadOnly = True
        Me.SAKI_SEQNO_MAE.Visible = False
        '
        'SAKI_SEQNO_ATO
        '
        Me.SAKI_SEQNO_ATO.DataPropertyName = "SAKI_SEQNO_ATO"
        DataGridViewCellStyle19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SAKI_SEQNO_ATO.DefaultCellStyle = DataGridViewCellStyle19
        Me.SAKI_SEQNO_ATO.HeaderText = "元SEQ(移動先移動後)"
        Me.SAKI_SEQNO_ATO.Name = "SAKI_SEQNO_ATO"
        Me.SAKI_SEQNO_ATO.ReadOnly = True
        Me.SAKI_SEQNO_ATO.Visible = False
        '
        'cmdDel
        '
        Me.cmdDel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDel.Location = New System.Drawing.Point(644, 300)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(92, 44)
        Me.cmdDel.TabIndex = 8
        Me.cmdDel.Text = "削除"
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdUpd
        '
        Me.cmdUpd.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdUpd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUpd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdUpd.Location = New System.Drawing.Point(253, 300)
        Me.cmdUpd.Name = "cmdUpd"
        Me.cmdUpd.Size = New System.Drawing.Size(92, 44)
        Me.cmdUpd.TabIndex = 7
        Me.cmdUpd.Text = "変更(表示)"
        Me.cmdUpd.UseVisualStyleBackColor = True
        '
        'cmdIns
        '
        Me.cmdIns.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdIns.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdIns.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIns.Location = New System.Drawing.Point(146, 300)
        Me.cmdIns.Name = "cmdIns"
        Me.cmdIns.Size = New System.Drawing.Size(92, 44)
        Me.cmdIns.TabIndex = 6
        Me.cmdIns.Text = "新規登録"
        Me.cmdIns.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(200, 532)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(122, 15)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "契約羽数(移動前)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(70, 453)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 15)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "■農場(移動元)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(70, 481)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 15)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "   農場住所"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(70, 422)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(82, 15)
        Me.Label23.TabIndex = 52
        Me.Label23.Text = "■移動羽数"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(70, 390)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(82, 15)
        Me.Label26.TabIndex = 58
        Me.Label26.Text = "■鶏の種類"
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
        Me.date_KEIYAKU_DATE_FROM.Location = New System.Drawing.Point(199, 673)
        Me.date_KEIYAKU_DATE_FROM.Name = "date_KEIYAKU_DATE_FROM"
        Me.date_KEIYAKU_DATE_FROM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.date_KEIYAKU_DATE_FROM.Size = New System.Drawing.Size(125, 21)
        Me.date_KEIYAKU_DATE_FROM.Spin.AllowSpin = False
        Me.date_KEIYAKU_DATE_FROM.TabIndex = 31
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
        Me.Label28.Location = New System.Drawing.Point(70, 673)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(97, 15)
        Me.Label28.TabIndex = 63
        Me.Label28.Text = "■移動年月日"
        '
        'cmdCansel
        '
        Me.cmdCansel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCansel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCansel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCansel.Location = New System.Drawing.Point(129, 3)
        Me.cmdCansel.Name = "cmdCansel"
        Me.cmdCansel.Size = New System.Drawing.Size(92, 44)
        Me.cmdCansel.TabIndex = 1
        Me.cmdCansel.Text = "キャンセル"
        Me.cmdCansel.UseVisualStyleBackColor = True
        '
        'lbl_KEIYAKU_HASU_MOTO_MAE
        '
        Me.lbl_KEIYAKU_HASU_MOTO_MAE.AutoSize = True
        Me.lbl_KEIYAKU_HASU_MOTO_MAE.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_HASU_MOTO_MAE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_HASU_MOTO_MAE.Location = New System.Drawing.Point(331, 531)
        Me.lbl_KEIYAKU_HASU_MOTO_MAE.Name = "lbl_KEIYAKU_HASU_MOTO_MAE"
        Me.lbl_KEIYAKU_HASU_MOTO_MAE.Size = New System.Drawing.Size(77, 15)
        Me.lbl_KEIYAKU_HASU_MOTO_MAE.TabIndex = 1062
        Me.lbl_KEIYAKU_HASU_MOTO_MAE.Text = "99,999,999"
        '
        'lbl_ADDR_POST_MOTO
        '
        Me.lbl_ADDR_POST_MOTO.AutoSize = True
        Me.lbl_ADDR_POST_MOTO.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_POST_MOTO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_POST_MOTO.Location = New System.Drawing.Point(228, 481)
        Me.lbl_ADDR_POST_MOTO.Name = "lbl_ADDR_POST_MOTO"
        Me.lbl_ADDR_POST_MOTO.Size = New System.Drawing.Size(71, 15)
        Me.lbl_ADDR_POST_MOTO.TabIndex = 1063
        Me.lbl_ADDR_POST_MOTO.Text = "999-9999"
        '
        'cob_NOJO_CD_MOTO
        '
        Me.cob_NOJO_CD_MOTO.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_NOJO_CD_MOTO.DropDown.AllowDrop = False
        Me.cob_NOJO_CD_MOTO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_NOJO_CD_MOTO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_NOJO_CD_MOTO.Format = "9"
        Me.cob_NOJO_CD_MOTO.HighlightText = True
        Me.cob_NOJO_CD_MOTO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_NOJO_CD_MOTO.InputCheck = True
        Me.cob_NOJO_CD_MOTO.ListHeaderPane.Height = 22
        Me.cob_NOJO_CD_MOTO.Location = New System.Drawing.Point(199, 450)
        Me.cob_NOJO_CD_MOTO.MaxLength = 3
        Me.cob_NOJO_CD_MOTO.Name = "cob_NOJO_CD_MOTO"
        Me.cob_NOJO_CD_MOTO.Size = New System.Drawing.Size(39, 22)
        Me.cob_NOJO_CD_MOTO.Spin.AllowSpin = False
        Me.cob_NOJO_CD_MOTO.TabIndex = 21
        Me.cob_NOJO_CD_MOTO.Tag = "生産者番号"
        Me.cob_NOJO_CD_MOTO.Text = "000"
        '
        'cob_NOJO_NM_MOTO
        '
        Me.cob_NOJO_NM_MOTO.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_NOJO_NM_MOTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_NOJO_NM_MOTO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_NOJO_NM_MOTO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_NOJO_NM_MOTO.InputCheck = True
        Me.cob_NOJO_NM_MOTO.ListHeaderPane.Height = 22
        Me.cob_NOJO_NM_MOTO.ListHeaderPane.Visible = False
        Me.cob_NOJO_NM_MOTO.Location = New System.Drawing.Point(242, 450)
        Me.cob_NOJO_NM_MOTO.Name = "cob_NOJO_NM_MOTO"
        Me.cob_NOJO_NM_MOTO.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.cob_NOJO_NM_MOTO.Size = New System.Drawing.Size(494, 22)
        Me.cob_NOJO_NM_MOTO.TabIndex = 22
        Me.cob_NOJO_NM_MOTO.TabStop = False
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'lbl_ADDR_1_MOTO
        '
        Me.lbl_ADDR_1_MOTO.AccessibleDescription = ""
        Me.lbl_ADDR_1_MOTO.AutoSize = True
        Me.lbl_ADDR_1_MOTO.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_1_MOTO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_1_MOTO.Location = New System.Drawing.Point(364, 481)
        Me.lbl_ADDR_1_MOTO.Name = "lbl_ADDR_1_MOTO"
        Me.lbl_ADDR_1_MOTO.Size = New System.Drawing.Size(67, 15)
        Me.lbl_ADDR_1_MOTO.TabIndex = 1066
        Me.lbl_ADDR_1_MOTO.Text = "＠＠＠＠"
        '
        'lbl_ADDR_2_MOTO
        '
        Me.lbl_ADDR_2_MOTO.AccessibleDescription = ""
        Me.lbl_ADDR_2_MOTO.AutoSize = True
        Me.lbl_ADDR_2_MOTO.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_2_MOTO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_2_MOTO.Location = New System.Drawing.Point(494, 481)
        Me.lbl_ADDR_2_MOTO.Name = "lbl_ADDR_2_MOTO"
        Me.lbl_ADDR_2_MOTO.Size = New System.Drawing.Size(232, 15)
        Me.lbl_ADDR_2_MOTO.TabIndex = 1067
        Me.lbl_ADDR_2_MOTO.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_ADDR_4_MOTO
        '
        Me.lbl_ADDR_4_MOTO.AutoSize = True
        Me.lbl_ADDR_4_MOTO.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_4_MOTO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_4_MOTO.Location = New System.Drawing.Point(660, 506)
        Me.lbl_ADDR_4_MOTO.Name = "lbl_ADDR_4_MOTO"
        Me.lbl_ADDR_4_MOTO.Size = New System.Drawing.Size(307, 15)
        Me.lbl_ADDR_4_MOTO.TabIndex = 1069
        Me.lbl_ADDR_4_MOTO.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_ADDR_3_MOTO
        '
        Me.lbl_ADDR_3_MOTO.AutoSize = True
        Me.lbl_ADDR_3_MOTO.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_3_MOTO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_3_MOTO.Location = New System.Drawing.Point(364, 506)
        Me.lbl_ADDR_3_MOTO.Name = "lbl_ADDR_3_MOTO"
        Me.lbl_ADDR_3_MOTO.Size = New System.Drawing.Size(232, 15)
        Me.lbl_ADDR_3_MOTO.TabIndex = 1068
        Me.lbl_ADDR_3_MOTO.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(199, 481)
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
        Me.Label5.Location = New System.Drawing.Point(305, 481)
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
        Me.Label6.Location = New System.Drawing.Point(434, 481)
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
        Me.Label7.Location = New System.Drawing.Point(305, 506)
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
        Me.Label8.Location = New System.Drawing.Point(600, 506)
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
        Me.cob_TORI_KBN.Location = New System.Drawing.Point(199, 387)
        Me.cob_TORI_KBN.MaxLength = 2
        Me.cob_TORI_KBN.Name = "cob_TORI_KBN"
        Me.cob_TORI_KBN.Size = New System.Drawing.Size(26, 22)
        Me.cob_TORI_KBN.Spin.AllowSpin = False
        Me.cob_TORI_KBN.TabIndex = 11
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
        Me.cob_TORI_KBN_NM.Location = New System.Drawing.Point(228, 387)
        Me.cob_TORI_KBN_NM.Name = "cob_TORI_KBN_NM"
        Me.cob_TORI_KBN_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton4})
        Me.cob_TORI_KBN_NM.Size = New System.Drawing.Size(119, 22)
        Me.cob_TORI_KBN_NM.TabIndex = 12
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
        Me.cmd_NOJO_INS.Location = New System.Drawing.Point(763, 554)
        Me.cmd_NOJO_INS.Name = "cmd_NOJO_INS"
        Me.cmd_NOJO_INS.Size = New System.Drawing.Size(92, 44)
        Me.cmd_NOJO_INS.TabIndex = 13
        Me.cmd_NOJO_INS.TabStop = False
        Me.cmd_NOJO_INS.Text = "農場登録"
        Me.cmd_NOJO_INS.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label29)
        Me.Panel2.Controls.Add(Me.lblCOUNT)
        Me.Panel2.Controls.Add(Me.Label27)
        Me.Panel2.Location = New System.Drawing.Point(13, 106)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1069, 25)
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
        Me.Label10.Size = New System.Drawing.Size(333, 19)
        Me.Label10.TabIndex = 1059
        Me.Label10.Text = "１．契約農場別明細　移動情報（表示）"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.Location = New System.Drawing.Point(902, 4)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(75, 15)
        Me.Label29.TabIndex = 1129
        Me.Label29.Text = "抽出件数："
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCOUNT
        '
        Me.lblCOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblCOUNT.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCOUNT.Location = New System.Drawing.Point(973, 4)
        Me.lblCOUNT.Name = "lblCOUNT"
        Me.lblCOUNT.Size = New System.Drawing.Size(55, 15)
        Me.lblCOUNT.TabIndex = 1130
        Me.lblCOUNT.Text = "99999"
        Me.lblCOUNT.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.Location = New System.Drawing.Point(1030, 4)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(20, 15)
        Me.Label27.TabIndex = 1131
        Me.Label27.Text = "件"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(13, 355)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1068, 25)
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
        Me.Label11.Size = New System.Drawing.Size(333, 19)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "２．契約農場別明細　移動情報（入力）"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(44, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 15)
        Me.Label4.TabIndex = 1106
        Me.Label4.Text = "■期"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(44, 80)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 15)
        Me.Label18.TabIndex = 1105
        Me.Label18.Text = "■契約者"
        '
        'cob_KEIYAKUSYA_CD
        '
        Me.cob_KEIYAKUSYA_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_KEIYAKUSYA_CD.DropDown.AllowDrop = False
        Me.cob_KEIYAKUSYA_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKUSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKUSYA_CD.Format = "9"
        Me.cob_KEIYAKUSYA_CD.HighlightText = True
        Me.cob_KEIYAKUSYA_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_KEIYAKUSYA_CD.InputCheck = True
        Me.cob_KEIYAKUSYA_CD.ListHeaderPane.Height = 22
        Me.cob_KEIYAKUSYA_CD.Location = New System.Drawing.Point(136, 77)
        Me.cob_KEIYAKUSYA_CD.MaxLength = 5
        Me.cob_KEIYAKUSYA_CD.Name = "cob_KEIYAKUSYA_CD"
        Me.cob_KEIYAKUSYA_CD.Size = New System.Drawing.Size(51, 22)
        Me.cob_KEIYAKUSYA_CD.Spin.AllowSpin = False
        Me.cob_KEIYAKUSYA_CD.TabIndex = 1
        Me.cob_KEIYAKUSYA_CD.Tag = "都道府県"
        Me.cob_KEIYAKUSYA_CD.Text = "00000"
        '
        'cob_KEIYAKUSYA_NM
        '
        Me.cob_KEIYAKUSYA_NM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_KEIYAKUSYA_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_KEIYAKUSYA_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKUSYA_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKUSYA_NM.InputCheck = True
        Me.cob_KEIYAKUSYA_NM.ListHeaderPane.Height = 22
        Me.cob_KEIYAKUSYA_NM.ListHeaderPane.Visible = False
        Me.cob_KEIYAKUSYA_NM.Location = New System.Drawing.Point(193, 77)
        Me.cob_KEIYAKUSYA_NM.Name = "cob_KEIYAKUSYA_NM"
        Me.cob_KEIYAKUSYA_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.cob_KEIYAKUSYA_NM.Size = New System.Drawing.Size(415, 22)
        Me.cob_KEIYAKUSYA_NM.TabIndex = 2
        Me.cob_KEIYAKUSYA_NM.TabStop = False
        '
        'DropDownButton5
        '
        Me.DropDownButton5.Name = "DropDownButton5"
        '
        'pnl_SYORI_KBN2
        '
        Me.pnl_SYORI_KBN2.Controls.Add(Me.rbtn_SYORI_KBN2)
        Me.pnl_SYORI_KBN2.Controls.Add(Me.rbtn_SYORI_KBN1)
        Me.pnl_SYORI_KBN2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.pnl_SYORI_KBN2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.pnl_SYORI_KBN2.Location = New System.Drawing.Point(197, 696)
        Me.pnl_SYORI_KBN2.Name = "pnl_SYORI_KBN2"
        Me.pnl_SYORI_KBN2.Size = New System.Drawing.Size(207, 38)
        Me.pnl_SYORI_KBN2.TabIndex = 32
        Me.pnl_SYORI_KBN2.TabStop = False
        '
        'rbtn_SYORI_KBN2
        '
        Me.rbtn_SYORI_KBN2.AutoSize = True
        Me.rbtn_SYORI_KBN2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtn_SYORI_KBN2.Location = New System.Drawing.Point(101, 12)
        Me.rbtn_SYORI_KBN2.Name = "rbtn_SYORI_KBN2"
        Me.rbtn_SYORI_KBN2.Size = New System.Drawing.Size(91, 20)
        Me.rbtn_SYORI_KBN2.TabIndex = 1
        Me.rbtn_SYORI_KBN2.TabStop = True
        Me.rbtn_SYORI_KBN2.Text = "入力確定"
        Me.rbtn_SYORI_KBN2.UseVisualStyleBackColor = True
        '
        'rbtn_SYORI_KBN1
        '
        Me.rbtn_SYORI_KBN1.AutoSize = True
        Me.rbtn_SYORI_KBN1.Checked = True
        Me.rbtn_SYORI_KBN1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtn_SYORI_KBN1.Location = New System.Drawing.Point(6, 12)
        Me.rbtn_SYORI_KBN1.Name = "rbtn_SYORI_KBN1"
        Me.rbtn_SYORI_KBN1.Size = New System.Drawing.Size(76, 20)
        Me.rbtn_SYORI_KBN1.TabIndex = 0
        Me.rbtn_SYORI_KBN1.TabStop = True
        Me.rbtn_SYORI_KBN1.Text = "入力中"
        Me.rbtn_SYORI_KBN1.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(70, 709)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 15)
        Me.Label19.TabIndex = 1108
        Me.Label19.Text = "■入力確認有無"
        '
        'lbl_KEIYAKU_HASU_MOTO_ATO
        '
        Me.lbl_KEIYAKU_HASU_MOTO_ATO.AutoSize = True
        Me.lbl_KEIYAKU_HASU_MOTO_ATO.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_HASU_MOTO_ATO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_HASU_MOTO_ATO.Location = New System.Drawing.Point(565, 531)
        Me.lbl_KEIYAKU_HASU_MOTO_ATO.Name = "lbl_KEIYAKU_HASU_MOTO_ATO"
        Me.lbl_KEIYAKU_HASU_MOTO_ATO.Size = New System.Drawing.Size(77, 15)
        Me.lbl_KEIYAKU_HASU_MOTO_ATO.TabIndex = 1110
        Me.lbl_KEIYAKU_HASU_MOTO_ATO.Text = "99,999,999"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(434, 532)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 15)
        Me.Label2.TabIndex = 1109
        Me.Label2.Text = "契約羽数(移動後)"
        '
        'lbl_KEIYAKU_HASU_SAKI_ATO
        '
        Me.lbl_KEIYAKU_HASU_SAKI_ATO.AutoSize = True
        Me.lbl_KEIYAKU_HASU_SAKI_ATO.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_HASU_SAKI_ATO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_HASU_SAKI_ATO.Location = New System.Drawing.Point(565, 642)
        Me.lbl_KEIYAKU_HASU_SAKI_ATO.Name = "lbl_KEIYAKU_HASU_SAKI_ATO"
        Me.lbl_KEIYAKU_HASU_SAKI_ATO.Size = New System.Drawing.Size(77, 15)
        Me.lbl_KEIYAKU_HASU_SAKI_ATO.TabIndex = 1128
        Me.lbl_KEIYAKU_HASU_SAKI_ATO.Text = "99,999,999"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(434, 643)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 15)
        Me.Label9.TabIndex = 1127
        Me.Label9.Text = "契約羽数(移動後)"
        '
        'lbl_ADDR_4_SAKI
        '
        Me.lbl_ADDR_4_SAKI.AutoSize = True
        Me.lbl_ADDR_4_SAKI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_4_SAKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_4_SAKI.Location = New System.Drawing.Point(660, 617)
        Me.lbl_ADDR_4_SAKI.Name = "lbl_ADDR_4_SAKI"
        Me.lbl_ADDR_4_SAKI.Size = New System.Drawing.Size(307, 15)
        Me.lbl_ADDR_4_SAKI.TabIndex = 1121
        Me.lbl_ADDR_4_SAKI.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_ADDR_3_SAKI
        '
        Me.lbl_ADDR_3_SAKI.AutoSize = True
        Me.lbl_ADDR_3_SAKI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_3_SAKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_3_SAKI.Location = New System.Drawing.Point(364, 617)
        Me.lbl_ADDR_3_SAKI.Name = "lbl_ADDR_3_SAKI"
        Me.lbl_ADDR_3_SAKI.Size = New System.Drawing.Size(232, 15)
        Me.lbl_ADDR_3_SAKI.TabIndex = 1120
        Me.lbl_ADDR_3_SAKI.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_ADDR_2_SAKI
        '
        Me.lbl_ADDR_2_SAKI.AccessibleDescription = "v"
        Me.lbl_ADDR_2_SAKI.AutoSize = True
        Me.lbl_ADDR_2_SAKI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_2_SAKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_2_SAKI.Location = New System.Drawing.Point(494, 592)
        Me.lbl_ADDR_2_SAKI.Name = "lbl_ADDR_2_SAKI"
        Me.lbl_ADDR_2_SAKI.Size = New System.Drawing.Size(232, 15)
        Me.lbl_ADDR_2_SAKI.TabIndex = 1119
        Me.lbl_ADDR_2_SAKI.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_ADDR_1_SAKI
        '
        Me.lbl_ADDR_1_SAKI.AccessibleDescription = ""
        Me.lbl_ADDR_1_SAKI.AutoSize = True
        Me.lbl_ADDR_1_SAKI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_1_SAKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_1_SAKI.Location = New System.Drawing.Point(364, 592)
        Me.lbl_ADDR_1_SAKI.Name = "lbl_ADDR_1_SAKI"
        Me.lbl_ADDR_1_SAKI.Size = New System.Drawing.Size(67, 15)
        Me.lbl_ADDR_1_SAKI.TabIndex = 1118
        Me.lbl_ADDR_1_SAKI.Text = "＠＠＠＠"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(600, 617)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 15)
        Me.Label15.TabIndex = 1126
        Me.Label15.Text = "(住所４)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(305, 617)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 15)
        Me.Label16.TabIndex = 1125
        Me.Label16.Text = "(住所3)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(434, 592)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 15)
        Me.Label17.TabIndex = 1124
        Me.Label17.Text = "(住所２)"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(305, 592)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(57, 15)
        Me.Label20.TabIndex = 1123
        Me.Label20.Text = "(住所１)"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(199, 592)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(22, 15)
        Me.Label21.TabIndex = 1122
        Me.Label21.Text = "〒"
        '
        'cob_NOJO_CD_SAKI
        '
        Me.cob_NOJO_CD_SAKI.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_NOJO_CD_SAKI.DropDown.AllowDrop = False
        Me.cob_NOJO_CD_SAKI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_NOJO_CD_SAKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_NOJO_CD_SAKI.Format = "9"
        Me.cob_NOJO_CD_SAKI.HighlightText = True
        Me.cob_NOJO_CD_SAKI.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_NOJO_CD_SAKI.InputCheck = True
        Me.cob_NOJO_CD_SAKI.ListHeaderPane.Height = 22
        Me.cob_NOJO_CD_SAKI.Location = New System.Drawing.Point(199, 561)
        Me.cob_NOJO_CD_SAKI.MaxLength = 3
        Me.cob_NOJO_CD_SAKI.Name = "cob_NOJO_CD_SAKI"
        Me.cob_NOJO_CD_SAKI.Size = New System.Drawing.Size(39, 22)
        Me.cob_NOJO_CD_SAKI.Spin.AllowSpin = False
        Me.cob_NOJO_CD_SAKI.TabIndex = 26
        Me.cob_NOJO_CD_SAKI.Tag = "生産者番号"
        Me.cob_NOJO_CD_SAKI.Text = "000"
        '
        'cob_NOJO_NM_SAKI
        '
        Me.cob_NOJO_NM_SAKI.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_NOJO_NM_SAKI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_NOJO_NM_SAKI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_NOJO_NM_SAKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_NOJO_NM_SAKI.InputCheck = True
        Me.cob_NOJO_NM_SAKI.ListHeaderPane.Height = 22
        Me.cob_NOJO_NM_SAKI.ListHeaderPane.Visible = False
        Me.cob_NOJO_NM_SAKI.Location = New System.Drawing.Point(242, 561)
        Me.cob_NOJO_NM_SAKI.Name = "cob_NOJO_NM_SAKI"
        Me.cob_NOJO_NM_SAKI.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cob_NOJO_NM_SAKI.Size = New System.Drawing.Size(494, 22)
        Me.cob_NOJO_NM_SAKI.TabIndex = 27
        Me.cob_NOJO_NM_SAKI.TabStop = False
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'lbl_ADDR_POST_SAKI
        '
        Me.lbl_ADDR_POST_SAKI.AutoSize = True
        Me.lbl_ADDR_POST_SAKI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_POST_SAKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_POST_SAKI.Location = New System.Drawing.Point(228, 592)
        Me.lbl_ADDR_POST_SAKI.Name = "lbl_ADDR_POST_SAKI"
        Me.lbl_ADDR_POST_SAKI.Size = New System.Drawing.Size(71, 15)
        Me.lbl_ADDR_POST_SAKI.TabIndex = 1117
        Me.lbl_ADDR_POST_SAKI.Text = "999-9999"
        '
        'lbl_KEIYAKU_HASU_SAKI_MAE
        '
        Me.lbl_KEIYAKU_HASU_SAKI_MAE.AutoSize = True
        Me.lbl_KEIYAKU_HASU_SAKI_MAE.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_HASU_SAKI_MAE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_HASU_SAKI_MAE.Location = New System.Drawing.Point(331, 642)
        Me.lbl_KEIYAKU_HASU_SAKI_MAE.Name = "lbl_KEIYAKU_HASU_SAKI_MAE"
        Me.lbl_KEIYAKU_HASU_SAKI_MAE.Size = New System.Drawing.Size(77, 15)
        Me.lbl_KEIYAKU_HASU_SAKI_MAE.TabIndex = 1116
        Me.lbl_KEIYAKU_HASU_SAKI_MAE.Text = "99,999,999"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(70, 592)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(82, 15)
        Me.Label22.TabIndex = 1115
        Me.Label22.Text = "   農場住所"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(70, 564)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(107, 15)
        Me.Label24.TabIndex = 1114
        Me.Label24.Text = "■農場(移動先)"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(200, 643)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(122, 15)
        Me.Label25.TabIndex = 1113
        Me.Label25.Text = "契約羽数(移動前)"
        '
        'cmdSearchClr
        '
        Me.cmdSearchClr.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSearchClr.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearchClr.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSearchClr.Location = New System.Drawing.Point(744, 67)
        Me.cmdSearchClr.Name = "cmdSearchClr"
        Me.cmdSearchClr.Size = New System.Drawing.Size(94, 35)
        Me.cmdSearchClr.TabIndex = 4
        Me.cmdSearchClr.TabStop = False
        Me.cmdSearchClr.Text = "条件クリア"
        Me.cmdSearchClr.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(632, 67)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(94, 35)
        Me.cmdSearch.TabIndex = 3
        Me.cmdSearch.Text = "検索"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'lbl_MOTO_SEQNO_MAE
        '
        Me.lbl_MOTO_SEQNO_MAE.AutoSize = True
        Me.lbl_MOTO_SEQNO_MAE.BackColor = System.Drawing.Color.Transparent
        Me.lbl_MOTO_SEQNO_MAE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_MOTO_SEQNO_MAE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_MOTO_SEQNO_MAE.Location = New System.Drawing.Point(660, 532)
        Me.lbl_MOTO_SEQNO_MAE.Name = "lbl_MOTO_SEQNO_MAE"
        Me.lbl_MOTO_SEQNO_MAE.Size = New System.Drawing.Size(136, 15)
        Me.lbl_MOTO_SEQNO_MAE.TabIndex = 1133
        Me.lbl_MOTO_SEQNO_MAE.Text = "MOTO_SEQNO_MAE"
        Me.lbl_MOTO_SEQNO_MAE.Visible = False
        '
        'lbl_MOTO_SEQNO_ATO
        '
        Me.lbl_MOTO_SEQNO_ATO.AutoSize = True
        Me.lbl_MOTO_SEQNO_ATO.BackColor = System.Drawing.Color.Transparent
        Me.lbl_MOTO_SEQNO_ATO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_MOTO_SEQNO_ATO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_MOTO_SEQNO_ATO.Location = New System.Drawing.Point(837, 531)
        Me.lbl_MOTO_SEQNO_ATO.Name = "lbl_MOTO_SEQNO_ATO"
        Me.lbl_MOTO_SEQNO_ATO.Size = New System.Drawing.Size(137, 15)
        Me.lbl_MOTO_SEQNO_ATO.TabIndex = 1134
        Me.lbl_MOTO_SEQNO_ATO.Text = "MOTO_SEQNO_ATO"
        Me.lbl_MOTO_SEQNO_ATO.Visible = False
        '
        'lbl_SAKI_SEQNO_ATO
        '
        Me.lbl_SAKI_SEQNO_ATO.AutoSize = True
        Me.lbl_SAKI_SEQNO_ATO.BackColor = System.Drawing.Color.Transparent
        Me.lbl_SAKI_SEQNO_ATO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_SAKI_SEQNO_ATO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_SAKI_SEQNO_ATO.Location = New System.Drawing.Point(837, 642)
        Me.lbl_SAKI_SEQNO_ATO.Name = "lbl_SAKI_SEQNO_ATO"
        Me.lbl_SAKI_SEQNO_ATO.Size = New System.Drawing.Size(126, 15)
        Me.lbl_SAKI_SEQNO_ATO.TabIndex = 1136
        Me.lbl_SAKI_SEQNO_ATO.Text = "SAKI_SEQNO_ATO"
        Me.lbl_SAKI_SEQNO_ATO.Visible = False
        '
        'lbl_SAKI_SEQNO_MAE
        '
        Me.lbl_SAKI_SEQNO_MAE.AutoSize = True
        Me.lbl_SAKI_SEQNO_MAE.BackColor = System.Drawing.Color.Transparent
        Me.lbl_SAKI_SEQNO_MAE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_SAKI_SEQNO_MAE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_SAKI_SEQNO_MAE.Location = New System.Drawing.Point(660, 643)
        Me.lbl_SAKI_SEQNO_MAE.Name = "lbl_SAKI_SEQNO_MAE"
        Me.lbl_SAKI_SEQNO_MAE.Size = New System.Drawing.Size(125, 15)
        Me.lbl_SAKI_SEQNO_MAE.TabIndex = 1135
        Me.lbl_SAKI_SEQNO_MAE.Text = "SAKI_SEQNO_MAE"
        Me.lbl_SAKI_SEQNO_MAE.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(364, 390)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(554, 30)
        Me.Label31.TabIndex = 1137
        Me.Label31.Text = "（1：採卵鶏「成鶏」、2：採卵鶏「育成鶏」、3：肉用鶏、4：種鶏「成鶏」、5：種鶏「育成鶏」、" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　6：うずら、7：あひる、8：きじ、9：ほろほろ鳥、10：七面鳥" & _
            "、11：だちょう）"
        '
        'frmGJ1020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.lbl_SAKI_SEQNO_ATO)
        Me.Controls.Add(Me.lbl_SAKI_SEQNO_MAE)
        Me.Controls.Add(Me.lbl_MOTO_SEQNO_ATO)
        Me.Controls.Add(Me.lbl_MOTO_SEQNO_MAE)
        Me.Controls.Add(Me.cmdSearchClr)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.lbl_KEIYAKU_HASU_SAKI_ATO)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lbl_ADDR_4_SAKI)
        Me.Controls.Add(Me.lbl_ADDR_3_SAKI)
        Me.Controls.Add(Me.lbl_ADDR_2_SAKI)
        Me.Controls.Add(Me.lbl_ADDR_1_SAKI)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cob_NOJO_CD_SAKI)
        Me.Controls.Add(Me.cob_NOJO_NM_SAKI)
        Me.Controls.Add(Me.lbl_ADDR_POST_SAKI)
        Me.Controls.Add(Me.lbl_KEIYAKU_HASU_SAKI_MAE)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.lbl_KEIYAKU_HASU_MOTO_ATO)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pnl_SYORI_KBN2)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txt_KI)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cob_KEIYAKUSYA_CD)
        Me.Controls.Add(Me.cob_KEIYAKUSYA_NM)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.cmd_NOJO_INS)
        Me.Controls.Add(Me.cob_TORI_KBN)
        Me.Controls.Add(Me.cob_TORI_KBN_NM)
        Me.Controls.Add(Me.lbl_ADDR_4_MOTO)
        Me.Controls.Add(Me.lbl_ADDR_3_MOTO)
        Me.Controls.Add(Me.lbl_ADDR_2_MOTO)
        Me.Controls.Add(Me.lbl_ADDR_1_MOTO)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cob_NOJO_CD_MOTO)
        Me.Controls.Add(Me.cob_NOJO_NM_MOTO)
        Me.Controls.Add(Me.lbl_ADDR_POST_MOTO)
        Me.Controls.Add(Me.lbl_KEIYAKU_HASU_MOTO_MAE)
        Me.Controls.Add(Me.date_KEIYAKU_DATE_FROM)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.num_IDO_HASU)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdUpd)
        Me.Controls.Add(Me.cmdIns)
        Me.Controls.Add(Me.dgv_Search)
        Me.Name = "frmGJ1020"
        Me.Text = "（GJ1020）互助基金契約者情報変更（移動）"
        Me.Controls.SetChildIndex(Me.dgv_Search, 0)
        Me.Controls.SetChildIndex(Me.cmdIns, 0)
        Me.Controls.SetChildIndex(Me.cmdUpd, 0)
        Me.Controls.SetChildIndex(Me.cmdDel, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.num_IDO_HASU, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.date_KEIYAKU_DATE_FROM, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_HASU_MOTO_MAE, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_POST_MOTO, 0)
        Me.Controls.SetChildIndex(Me.cob_NOJO_NM_MOTO, 0)
        Me.Controls.SetChildIndex(Me.cob_NOJO_CD_MOTO, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_1_MOTO, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_2_MOTO, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_3_MOTO, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_4_MOTO, 0)
        Me.Controls.SetChildIndex(Me.cob_TORI_KBN_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_TORI_KBN, 0)
        Me.Controls.SetChildIndex(Me.cmd_NOJO_INS, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.cob_KEIYAKUSYA_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_KEIYAKUSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txt_KI, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.pnl_SYORI_KBN2, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_HASU_MOTO_ATO, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_HASU_SAKI_MAE, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_POST_SAKI, 0)
        Me.Controls.SetChildIndex(Me.cob_NOJO_NM_SAKI, 0)
        Me.Controls.SetChildIndex(Me.cob_NOJO_CD_SAKI, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_1_SAKI, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_2_SAKI, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_3_SAKI, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_4_SAKI, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_HASU_SAKI_ATO, 0)
        Me.Controls.SetChildIndex(Me.cmdSearch, 0)
        Me.Controls.SetChildIndex(Me.cmdSearchClr, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.lbl_MOTO_SEQNO_MAE, 0)
        Me.Controls.SetChildIndex(Me.lbl_MOTO_SEQNO_ATO, 0)
        Me.Controls.SetChildIndex(Me.lbl_SAKI_SEQNO_MAE, 0)
        Me.Controls.SetChildIndex(Me.lbl_SAKI_SEQNO_ATO, 0)
        Me.Controls.SetChildIndex(Me.Label31, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.num_IDO_HASU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_KEIYAKU_DATE_FROM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_NOJO_CD_MOTO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_NOJO_NM_MOTO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_TORI_KBN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_TORI_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cob_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKUSYA_NM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_SYORI_KBN2.ResumeLayout(False)
        Me.pnl_SYORI_KBN2.PerformLayout()
        CType(Me.cob_NOJO_CD_SAKI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_NOJO_NM_SAKI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSave As JBD.Gjs.Win.JButton
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents GcDateValidator1 As GrapeCity.Win.Editors.GcDateValidator
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
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents num_IDO_HASU As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label23 As JBD.Gjs.Win.Label
    Friend WithEvents Label26 As JBD.Gjs.Win.Label
    Friend WithEvents date_KEIYAKU_DATE_FROM As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label28 As JBD.Gjs.Win.Label
    Friend WithEvents cmdCansel As JBD.Gjs.Win.JButton
    Friend WithEvents lbl_KEIYAKU_HASU_MOTO_MAE As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_POST_MOTO As JBD.Gjs.Win.JLabel
    Friend WithEvents cob_NOJO_CD_MOTO As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_NOJO_NM_MOTO As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents lbl_ADDR_1_MOTO As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_2_MOTO As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_4_MOTO As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_3_MOTO As JBD.Gjs.Win.JLabel
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents cob_TORI_KBN As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_TORI_KBN_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cmd_NOJO_INS As JBD.Gjs.Win.JButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KEIYAKUSYA_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEIYAKUSYA_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton5 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents pnl_SYORI_KBN2 As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtn_SYORI_KBN2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_SYORI_KBN1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_KEIYAKU_HASU_MOTO_ATO As JBD.Gjs.Win.JLabel
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_KEIYAKU_HASU_SAKI_ATO As JBD.Gjs.Win.JLabel
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_ADDR_4_SAKI As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_3_SAKI As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_2_SAKI As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_1_SAKI As JBD.Gjs.Win.JLabel
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents Label20 As JBD.Gjs.Win.Label
    Friend WithEvents Label21 As JBD.Gjs.Win.Label
    Friend WithEvents cob_NOJO_CD_SAKI As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_NOJO_NM_SAKI As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents lbl_ADDR_POST_SAKI As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKU_HASU_SAKI_MAE As JBD.Gjs.Win.JLabel
    Friend WithEvents Label22 As JBD.Gjs.Win.Label
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents Label25 As JBD.Gjs.Win.Label
    Friend WithEvents cmdSearchClr As JBD.Gjs.Win.JButton
    Friend WithEvents cmdSearch As JBD.Gjs.Win.JButton
    Friend WithEvents Label29 As JBD.Gjs.Win.Label
    Friend WithEvents lblCOUNT As JBD.Gjs.Win.Label
    Friend WithEvents Label27 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_MOTO_SEQNO_MAE As JBD.Gjs.Win.Label
    Friend WithEvents lbl_MOTO_SEQNO_ATO As JBD.Gjs.Win.Label
    Friend WithEvents lbl_SAKI_SEQNO_ATO As JBD.Gjs.Win.Label
    Friend WithEvents lbl_SAKI_SEQNO_MAE As JBD.Gjs.Win.Label
    Friend WithEvents Label31 As JBD.Gjs.Win.Label
    Friend WithEvents KEIYAKU_DATE_FROM_X As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_DATE_FROM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TORI_KBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TORI_KBN_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDO_HASU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOJO_CD_MOTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOJO_NM_MOTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_HASU_MOTO_MAE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_HASU_MOTO_ATO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOJO_CD_SAKI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOJO_NM_SAKI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_HASU_SAKI_MAE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_HASU_SAKI_ATO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SYORI_KBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SYORI_KBN_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOTO_SEQNO_MAE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOTO_SEQNO_ATO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SAKI_SEQNO_MAE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SAKI_SEQNO_ATO As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
