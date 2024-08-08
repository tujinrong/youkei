Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ7010
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DateEraDisplayField1 As GrapeCity.Win.Editors.Fields.DateEraDisplayField = New GrapeCity.Win.Editors.Fields.DateEraDisplayField()
        Dim DateLiteralDisplayField1 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateEraYearDisplayField1 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateLiteralDisplayField2 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateMonthDisplayField1 As GrapeCity.Win.Editors.Fields.DateMonthDisplayField = New GrapeCity.Win.Editors.Fields.DateMonthDisplayField()
        Dim DateEraField3 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField7 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField3 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField8 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField3 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.KEIYAKUSYA_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKUSYA_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKUSYA_KANA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_KBN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_JYOKYO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_JYOKYO_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_TEL1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEN_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEN_CD_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JIMUITAKU_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITAKU_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COUNT_HED = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COUNT_DTL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblCOUNT_DTL = New JBD.Gjs.Win.Label(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdClear = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdSearch = New JBD.Gjs.Win.JButton(Me.components)
        Me.GroupBox1 = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtnSearchOr = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtnSearchAnd = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdCsv = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label25 = New JBD.Gjs.Win.Label(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.numKI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.dateKEIYAKU_Ymd_Fm = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dateKEIYAKU_Ymd_To = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dateTAISYO_Ym = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton5 = New GrapeCity.Win.Editors.DropDownButton()
        Me.rbtnOutKIHON = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtnOutMEISAI = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboTORI_KBN_Cd_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboTORI_KBN_Nm_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton14 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboTORI_KBN_Cd_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboTORI_KBN_Nm_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton15 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label23 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboKEIYAKU_JYOKYO_Cd_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboKEIYAKU_JYOKYO_Nm_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton12 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label21 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboKEIYAKU_JYOKYO_Cd_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboKEIYAKU_JYOKYO_Nm_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton13 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label22 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboITAKU_Cd_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboITAKU_Nm_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton6 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboITAKU_Cd_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboITAKU_Nm_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton11 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboKEIYAKU_KBN_Cd_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboKEIYAKU_KBN_Nm_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton9 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboKEIYAKU_KBN_Cd_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboKEIYAKU_KBN_Nm_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton10 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboKEIYAKUSYA_Cd_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboKEIYAKUSYA_Nm_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton7 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.cboKEIYAKUSYA_Cd_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cboKEIYAKUSYA_Nm_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton8 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label29 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label27 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label20 = New JBD.Gjs.Win.Label(Me.components)
        Me.cobKEN_Cd_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cobKEN_Nm_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.cobKEN_Cd_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cobKEN_Nm_Fm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblCOUNT_HED = New JBD.Gjs.Win.Label(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.GroupBox2 = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.grpMikeiyaku = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.chk_MikeiyakuNozoku = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
        Me.chk_MinyukinNozoku = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.GroupBox3 = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateKEIYAKU_Ymd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateKEIYAKU_Ymd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateTAISYO_Ym, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTORI_KBN_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTORI_KBN_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTORI_KBN_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTORI_KBN_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_JYOKYO_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_JYOKYO_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_JYOKYO_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_JYOKYO_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboITAKU_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboITAKU_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboITAKU_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboITAKU_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_KBN_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_KBN_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_KBN_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKU_KBN_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKEIYAKUSYA_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cobKEN_Cd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cobKEN_Nm_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cobKEN_Cd_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cobKEN_Nm_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.grpMikeiyaku.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdCsv)
        Me.pnlButton.Location = New System.Drawing.Point(0, 637)
        Me.pnlButton.TabIndex = 100
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCsv, 0)
        '
        'lblLOGONUSER
        '
        Me.lblLOGONUSER.Text = "さん"
        '
        'lblSysdate
        '
        Me.lblSysdate.Text = "2010年9月2日（木）"
        '
        'cmdEnd
        '
        Me.cmdEnd.TabIndex = 37
        '
        'dgv_Search
        '
        Me.dgv_Search.AllowUserToAddRows = False
        Me.dgv_Search.AllowUserToDeleteRows = False
        Me.dgv_Search.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Search.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KEIYAKUSYA_CD, Me.KEIYAKUSYA_NAME, Me.KEIYAKUSYA_KANA, Me.KEIYAKU_KBN, Me.KEIYAKU_KBN_NM, Me.KEIYAKU_JYOKYO, Me.KEIYAKU_JYOKYO_NM, Me.ADDR_TEL1, Me.KEN_CD, Me.KEN_CD_NM, Me.JIMUITAKU_CD, Me.ITAKU_NAME, Me.KI, Me.COUNT_HED, Me.COUNT_DTL})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(9, 476)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Search.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(973, 151)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 35
        '
        'KEIYAKUSYA_CD
        '
        Me.KEIYAKUSYA_CD.DataPropertyName = "KEIYAKUSYA_CD"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKUSYA_CD.DefaultCellStyle = DataGridViewCellStyle2
        Me.KEIYAKUSYA_CD.Frozen = True
        Me.KEIYAKUSYA_CD.HeaderText = "契約者番号"
        Me.KEIYAKUSYA_CD.Name = "KEIYAKUSYA_CD"
        Me.KEIYAKUSYA_CD.ReadOnly = True
        Me.KEIYAKUSYA_CD.Width = 90
        '
        'KEIYAKUSYA_NAME
        '
        Me.KEIYAKUSYA_NAME.DataPropertyName = "KEIYAKUSYA_NAME"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKUSYA_NAME.DefaultCellStyle = DataGridViewCellStyle3
        Me.KEIYAKUSYA_NAME.HeaderText = "契約者名"
        Me.KEIYAKUSYA_NAME.Name = "KEIYAKUSYA_NAME"
        Me.KEIYAKUSYA_NAME.ReadOnly = True
        Me.KEIYAKUSYA_NAME.Width = 188
        '
        'KEIYAKUSYA_KANA
        '
        Me.KEIYAKUSYA_KANA.DataPropertyName = "KEIYAKUSYA_KANA"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKUSYA_KANA.DefaultCellStyle = DataGridViewCellStyle4
        Me.KEIYAKUSYA_KANA.HeaderText = "フリガナ"
        Me.KEIYAKUSYA_KANA.Name = "KEIYAKUSYA_KANA"
        Me.KEIYAKUSYA_KANA.ReadOnly = True
        Me.KEIYAKUSYA_KANA.Width = 155
        '
        'KEIYAKU_KBN
        '
        Me.KEIYAKU_KBN.DataPropertyName = "KEIYAKU_KBN"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.KEIYAKU_KBN.DefaultCellStyle = DataGridViewCellStyle5
        Me.KEIYAKU_KBN.HeaderText = "契約区分コード"
        Me.KEIYAKU_KBN.Name = "KEIYAKU_KBN"
        Me.KEIYAKU_KBN.ReadOnly = True
        Me.KEIYAKU_KBN.Visible = False
        Me.KEIYAKU_KBN.Width = 65
        '
        'KEIYAKU_KBN_NM
        '
        Me.KEIYAKU_KBN_NM.DataPropertyName = "KEIYAKU_KBN_NM"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKU_KBN_NM.DefaultCellStyle = DataGridViewCellStyle6
        Me.KEIYAKU_KBN_NM.HeaderText = "契約区分"
        Me.KEIYAKU_KBN_NM.Name = "KEIYAKU_KBN_NM"
        Me.KEIYAKU_KBN_NM.ReadOnly = True
        Me.KEIYAKU_KBN_NM.Width = 75
        '
        'KEIYAKU_JYOKYO
        '
        Me.KEIYAKU_JYOKYO.DataPropertyName = "KEIYAKU_JYOKYO"
        Me.KEIYAKU_JYOKYO.HeaderText = "契約状況コード"
        Me.KEIYAKU_JYOKYO.Name = "KEIYAKU_JYOKYO"
        Me.KEIYAKU_JYOKYO.ReadOnly = True
        Me.KEIYAKU_JYOKYO.Visible = False
        '
        'KEIYAKU_JYOKYO_NM
        '
        Me.KEIYAKU_JYOKYO_NM.DataPropertyName = "KEIYAKU_JYOKYO_NM"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.KEIYAKU_JYOKYO_NM.DefaultCellStyle = DataGridViewCellStyle7
        Me.KEIYAKU_JYOKYO_NM.HeaderText = "契約状況"
        Me.KEIYAKU_JYOKYO_NM.Name = "KEIYAKU_JYOKYO_NM"
        Me.KEIYAKU_JYOKYO_NM.ReadOnly = True
        Me.KEIYAKU_JYOKYO_NM.Width = 95
        '
        'ADDR_TEL1
        '
        Me.ADDR_TEL1.DataPropertyName = "ADDR_TEL1"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ADDR_TEL1.DefaultCellStyle = DataGridViewCellStyle8
        Me.ADDR_TEL1.HeaderText = "電話番号"
        Me.ADDR_TEL1.Name = "ADDR_TEL1"
        Me.ADDR_TEL1.ReadOnly = True
        Me.ADDR_TEL1.Width = 120
        '
        'KEN_CD
        '
        Me.KEN_CD.DataPropertyName = "KEN_CD"
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.KEN_CD.DefaultCellStyle = DataGridViewCellStyle9
        Me.KEN_CD.HeaderText = "都道府県コード"
        Me.KEN_CD.Name = "KEN_CD"
        Me.KEN_CD.ReadOnly = True
        Me.KEN_CD.Visible = False
        Me.KEN_CD.Width = 105
        '
        'KEN_CD_NM
        '
        Me.KEN_CD_NM.DataPropertyName = "KEN_CD_NM"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.KEN_CD_NM.DefaultCellStyle = DataGridViewCellStyle10
        Me.KEN_CD_NM.HeaderText = "都道府県"
        Me.KEN_CD_NM.Name = "KEN_CD_NM"
        Me.KEN_CD_NM.ReadOnly = True
        Me.KEN_CD_NM.Width = 80
        '
        'JIMUITAKU_CD
        '
        Me.JIMUITAKU_CD.DataPropertyName = "JIMUITAKU_CD"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.JIMUITAKU_CD.DefaultCellStyle = DataGridViewCellStyle11
        Me.JIMUITAKU_CD.HeaderText = "事務委託先コード"
        Me.JIMUITAKU_CD.Name = "JIMUITAKU_CD"
        Me.JIMUITAKU_CD.ReadOnly = True
        Me.JIMUITAKU_CD.Visible = False
        Me.JIMUITAKU_CD.Width = 105
        '
        'ITAKU_NAME
        '
        Me.ITAKU_NAME.DataPropertyName = "ITAKU_NAME"
        Me.ITAKU_NAME.HeaderText = "事務委託先"
        Me.ITAKU_NAME.Name = "ITAKU_NAME"
        Me.ITAKU_NAME.ReadOnly = True
        Me.ITAKU_NAME.Width = 150
        '
        'KI
        '
        Me.KI.DataPropertyName = "KI"
        Me.KI.HeaderText = "期"
        Me.KI.Name = "KI"
        Me.KI.ReadOnly = True
        Me.KI.Visible = False
        '
        'COUNT_HED
        '
        Me.COUNT_HED.DataPropertyName = "COUNT_HED"
        Me.COUNT_HED.HeaderText = "件数"
        Me.COUNT_HED.Name = "COUNT_HED"
        Me.COUNT_HED.ReadOnly = True
        Me.COUNT_HED.Visible = False
        '
        'COUNT_DTL
        '
        Me.COUNT_DTL.DataPropertyName = "COUNT_DTL"
        Me.COUNT_DTL.HeaderText = "農場件数"
        Me.COUNT_DTL.Name = "COUNT_DTL"
        Me.COUNT_DTL.ReadOnly = True
        Me.COUNT_DTL.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(958, 448)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 15)
        Me.Label7.TabIndex = 923
        Me.Label7.Text = "件"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCOUNT_DTL
        '
        Me.lblCOUNT_DTL.BackColor = System.Drawing.Color.Transparent
        Me.lblCOUNT_DTL.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCOUNT_DTL.Location = New System.Drawing.Point(906, 448)
        Me.lblCOUNT_DTL.Name = "lblCOUNT_DTL"
        Me.lblCOUNT_DTL.Size = New System.Drawing.Size(55, 19)
        Me.lblCOUNT_DTL.TabIndex = 922
        Me.lblCOUNT_DTL.Text = "99999"
        Me.lblCOUNT_DTL.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(835, 448)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 15)
        Me.Label11.TabIndex = 921
        Me.Label11.Text = "農場件数："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(723, 427)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(94, 44)
        Me.cmdClear.TabIndex = 34
        Me.cmdClear.Text = "条件クリア"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(611, 427)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(94, 44)
        Me.cmdSearch.TabIndex = 33
        Me.cmdSearch.Text = "検索"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtnSearchOr)
        Me.GroupBox1.Controls.Add(Me.rbtnSearchAnd)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(159, 423)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(426, 38)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'rbtnSearchOr
        '
        Me.rbtnSearchOr.AutoSize = True
        Me.rbtnSearchOr.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnSearchOr.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtnSearchOr.Location = New System.Drawing.Point(166, 12)
        Me.rbtnSearchOr.Name = "rbtnSearchOr"
        Me.rbtnSearchOr.Size = New System.Drawing.Size(160, 20)
        Me.rbtnSearchOr.TabIndex = 1
        Me.rbtnSearchOr.TabStop = True
        Me.rbtnSearchOr.Text = "いずれかを含む(OR)"
        Me.rbtnSearchOr.UseVisualStyleBackColor = True
        '
        'rbtnSearchAnd
        '
        Me.rbtnSearchAnd.AutoSize = True
        Me.rbtnSearchAnd.Checked = True
        Me.rbtnSearchAnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnSearchAnd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtnSearchAnd.Location = New System.Drawing.Point(6, 12)
        Me.rbtnSearchAnd.Name = "rbtnSearchAnd"
        Me.rbtnSearchAnd.Size = New System.Drawing.Size(154, 20)
        Me.rbtnSearchAnd.TabIndex = 0
        Me.rbtnSearchAnd.TabStop = True
        Me.rbtnSearchAnd.Text = "すべてを含む(AND)"
        Me.rbtnSearchAnd.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(19, 438)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(82, 15)
        Me.Label19.TabIndex = 916
        Me.Label19.Text = "■検索方法"
        '
        'cmdCsv
        '
        Me.cmdCsv.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCsv.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCsv.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCsv.Location = New System.Drawing.Point(12, 6)
        Me.cmdCsv.Name = "cmdCsv"
        Me.cmdCsv.Size = New System.Drawing.Size(92, 44)
        Me.cmdCsv.TabIndex = 36
        Me.cmdCsv.Text = "ＣＳＶ出力"
        Me.cmdCsv.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(34, 51)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(129, 19)
        Me.Label25.TabIndex = 925
        Me.Label25.Text = "検索条件入力"
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
        Me.numKI.Location = New System.Drawing.Point(159, 76)
        Me.numKI.Name = "numKI"
        Me.GcShortcut1.SetShortcuts(Me.numKI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKI, Object), CType(Me.numKI, Object), CType(Me.numKI, Object), CType(Me.numKI, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKI.Size = New System.Drawing.Size(36, 20)
        Me.numKI.Spin.Increment = 0
        Me.numKI.TabIndex = 1
        Me.numKI.Value = New Decimal(New Integer() {99, 0, 0, 0})
        Me.numKI.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        Me.numKI.ZeroSuppress = True
        '
        'dateKEIYAKU_Ymd_Fm
        '
        Me.dateKEIYAKU_Ymd_Fm.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.dateKEIYAKU_Ymd_Fm.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.dateKEIYAKU_Ymd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateKEIYAKU_Ymd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateKEIYAKU_Ymd_Fm.Location = New System.Drawing.Point(159, 339)
        Me.dateKEIYAKU_Ymd_Fm.Name = "dateKEIYAKU_Ymd_Fm"
        Me.GcShortcut1.SetShortcuts(Me.dateKEIYAKU_Ymd_Fm, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateKEIYAKU_Ymd_Fm, Object), CType(Me.dateKEIYAKU_Ymd_Fm, Object), CType(Me.dateKEIYAKU_Ymd_Fm, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateKEIYAKU_Ymd_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.dateKEIYAKU_Ymd_Fm.Size = New System.Drawing.Size(124, 20)
        Me.dateKEIYAKU_Ymd_Fm.Spin.AllowSpin = False
        Me.dateKEIYAKU_Ymd_Fm.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateKEIYAKU_Ymd_Fm.TabIndex = 29
        Me.dateKEIYAKU_Ymd_Fm.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'dateKEIYAKU_Ymd_To
        '
        Me.dateKEIYAKU_Ymd_To.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField5.Text = "/"
        DateLiteralField6.Text = "/"
        Me.dateKEIYAKU_Ymd_To.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateLiteralField4, DateEraYearField2, DateLiteralField5, DateMonthField2, DateLiteralField6, DateDayField2})
        Me.dateKEIYAKU_Ymd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateKEIYAKU_Ymd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateKEIYAKU_Ymd_To.Location = New System.Drawing.Point(315, 339)
        Me.dateKEIYAKU_Ymd_To.Name = "dateKEIYAKU_Ymd_To"
        Me.GcShortcut1.SetShortcuts(Me.dateKEIYAKU_Ymd_To, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateKEIYAKU_Ymd_To, Object), CType(Me.dateKEIYAKU_Ymd_To, Object), CType(Me.dateKEIYAKU_Ymd_To, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateKEIYAKU_Ymd_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton4})
        Me.dateKEIYAKU_Ymd_To.Size = New System.Drawing.Size(124, 20)
        Me.dateKEIYAKU_Ymd_To.Spin.AllowSpin = False
        Me.dateKEIYAKU_Ymd_To.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateKEIYAKU_Ymd_To.TabIndex = 30
        Me.dateKEIYAKU_Ymd_To.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'dateTAISYO_Ym
        '
        Me.dateTAISYO_Ym.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateEraYearDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField2.Text = "/"
        DateMonthDisplayField1.ShowLeadingZero = True
        Me.dateTAISYO_Ym.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField1, DateLiteralDisplayField1, DateEraYearDisplayField1, DateLiteralDisplayField2, DateMonthDisplayField1})
        Me.dateTAISYO_Ym.DropDownCalendar.CalendarType = GrapeCity.Win.Editors.CalendarType.YearMonth
        DateLiteralField8.Text = "/"
        Me.dateTAISYO_Ym.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField3, DateLiteralField7, DateEraYearField3, DateLiteralField8, DateMonthField3})
        Me.dateTAISYO_Ym.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateTAISYO_Ym.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateTAISYO_Ym.InputCheck = True
        Me.dateTAISYO_Ym.Location = New System.Drawing.Point(286, 76)
        Me.dateTAISYO_Ym.Name = "dateTAISYO_Ym"
        Me.GcShortcut1.SetShortcuts(Me.dateTAISYO_Ym, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateTAISYO_Ym, Object), CType(Me.dateTAISYO_Ym, Object), CType(Me.dateTAISYO_Ym, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateTAISYO_Ym.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.dateTAISYO_Ym.Size = New System.Drawing.Size(103, 20)
        Me.dateTAISYO_Ym.Spin.AllowSpin = False
        Me.dateTAISYO_Ym.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateTAISYO_Ym.TabIndex = 2
        Me.dateTAISYO_Ym.Value = New Date(2015, 10, 7, 0, 0, 0, 0)
        '
        'DropDownButton5
        '
        Me.DropDownButton5.Name = "DropDownButton5"
        '
        'rbtnOutKIHON
        '
        Me.rbtnOutKIHON.AutoSize = True
        Me.rbtnOutKIHON.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnOutKIHON.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtnOutKIHON.Location = New System.Drawing.Point(166, 12)
        Me.rbtnOutKIHON.Name = "rbtnOutKIHON"
        Me.rbtnOutKIHON.Size = New System.Drawing.Size(238, 20)
        Me.rbtnOutKIHON.TabIndex = 2
        Me.rbtnOutKIHON.TabStop = True
        Me.rbtnOutKIHON.Text = "含まない（契約者基本情報のみ）"
        Me.rbtnOutKIHON.UseVisualStyleBackColor = True
        '
        'rbtnOutMEISAI
        '
        Me.rbtnOutMEISAI.AutoSize = True
        Me.rbtnOutMEISAI.Checked = True
        Me.rbtnOutMEISAI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnOutMEISAI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtnOutMEISAI.Location = New System.Drawing.Point(8, 10)
        Me.rbtnOutMEISAI.Name = "rbtnOutMEISAI"
        Me.rbtnOutMEISAI.Size = New System.Drawing.Size(132, 20)
        Me.rbtnOutMEISAI.TabIndex = 1
        Me.rbtnOutMEISAI.TabStop = True
        Me.rbtnOutMEISAI.Text = "農場明細を含む"
        Me.rbtnOutMEISAI.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(19, 377)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 15)
        Me.Label10.TabIndex = 1048
        Me.Label10.Text = "□出力項目選択"
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
        Me.cboTORI_KBN_Cd_To.Location = New System.Drawing.Point(340, 307)
        Me.cboTORI_KBN_Cd_To.MaxLength = 2
        Me.cboTORI_KBN_Cd_To.Name = "cboTORI_KBN_Cd_To"
        Me.cboTORI_KBN_Cd_To.Size = New System.Drawing.Size(31, 22)
        Me.cboTORI_KBN_Cd_To.Spin.AllowSpin = False
        Me.cboTORI_KBN_Cd_To.TabIndex = 27
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
        Me.cboTORI_KBN_Nm_To.Location = New System.Drawing.Point(379, 307)
        Me.cboTORI_KBN_Nm_To.MaxLength = 8
        Me.cboTORI_KBN_Nm_To.Name = "cboTORI_KBN_Nm_To"
        Me.cboTORI_KBN_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton14})
        Me.cboTORI_KBN_Nm_To.Size = New System.Drawing.Size(106, 22)
        Me.cboTORI_KBN_Nm_To.TabIndex = 28
        Me.cboTORI_KBN_Nm_To.TabStop = False
        Me.cboTORI_KBN_Nm_To.Tag = "鶏の種類名"
        '
        'DropDownButton14
        '
        Me.DropDownButton14.Name = "DropDownButton14"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(312, 312)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 15)
        Me.Label8.TabIndex = 1046
        Me.Label8.Text = "～"
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
        Me.cboTORI_KBN_Cd_Fm.Location = New System.Drawing.Point(159, 309)
        Me.cboTORI_KBN_Cd_Fm.MaxLength = 2
        Me.cboTORI_KBN_Cd_Fm.Name = "cboTORI_KBN_Cd_Fm"
        Me.cboTORI_KBN_Cd_Fm.Size = New System.Drawing.Size(30, 22)
        Me.cboTORI_KBN_Cd_Fm.Spin.AllowSpin = False
        Me.cboTORI_KBN_Cd_Fm.TabIndex = 25
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
        Me.cboTORI_KBN_Nm_Fm.Location = New System.Drawing.Point(200, 309)
        Me.cboTORI_KBN_Nm_Fm.MaxLength = 8
        Me.cboTORI_KBN_Nm_Fm.Name = "cboTORI_KBN_Nm_Fm"
        Me.cboTORI_KBN_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton15})
        Me.cboTORI_KBN_Nm_Fm.Size = New System.Drawing.Size(106, 22)
        Me.cboTORI_KBN_Nm_Fm.TabIndex = 26
        Me.cboTORI_KBN_Nm_Fm.TabStop = False
        Me.cboTORI_KBN_Nm_Fm.Tag = "鶏の種類名"
        '
        'DropDownButton15
        '
        Me.DropDownButton15.Name = "DropDownButton15"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(19, 312)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(82, 15)
        Me.Label23.TabIndex = 1045
        Me.Label23.Text = "□鶏の種類"
        '
        'cboKEIYAKU_JYOKYO_Cd_To
        '
        Me.cboKEIYAKU_JYOKYO_Cd_To.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cboKEIYAKU_JYOKYO_Cd_To.DropDown.AllowDrop = False
        Me.cboKEIYAKU_JYOKYO_Cd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEIYAKU_JYOKYO_Cd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEIYAKU_JYOKYO_Cd_To.Format = "9"
        Me.cboKEIYAKU_JYOKYO_Cd_To.HighlightText = True
        Me.cboKEIYAKU_JYOKYO_Cd_To.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboKEIYAKU_JYOKYO_Cd_To.ListHeaderPane.Height = 22
        Me.cboKEIYAKU_JYOKYO_Cd_To.Location = New System.Drawing.Point(341, 223)
        Me.cboKEIYAKU_JYOKYO_Cd_To.MaxLength = 1
        Me.cboKEIYAKU_JYOKYO_Cd_To.Name = "cboKEIYAKU_JYOKYO_Cd_To"
        Me.cboKEIYAKU_JYOKYO_Cd_To.Size = New System.Drawing.Size(30, 22)
        Me.cboKEIYAKU_JYOKYO_Cd_To.Spin.AllowSpin = False
        Me.cboKEIYAKU_JYOKYO_Cd_To.TabIndex = 19
        Me.cboKEIYAKU_JYOKYO_Cd_To.Tag = "契約状況"
        Me.cboKEIYAKU_JYOKYO_Cd_To.Text = "9"
        '
        'cboKEIYAKU_JYOKYO_Nm_To
        '
        Me.cboKEIYAKU_JYOKYO_Nm_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKEIYAKU_JYOKYO_Nm_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEIYAKU_JYOKYO_Nm_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEIYAKU_JYOKYO_Nm_To.ListHeaderPane.Height = 22
        Me.cboKEIYAKU_JYOKYO_Nm_To.ListHeaderPane.Visible = False
        Me.cboKEIYAKU_JYOKYO_Nm_To.Location = New System.Drawing.Point(379, 224)
        Me.cboKEIYAKU_JYOKYO_Nm_To.MaxLength = 8
        Me.cboKEIYAKU_JYOKYO_Nm_To.Name = "cboKEIYAKU_JYOKYO_Nm_To"
        Me.cboKEIYAKU_JYOKYO_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton12})
        Me.cboKEIYAKU_JYOKYO_Nm_To.Size = New System.Drawing.Size(106, 22)
        Me.cboKEIYAKU_JYOKYO_Nm_To.TabIndex = 20
        Me.cboKEIYAKU_JYOKYO_Nm_To.TabStop = False
        Me.cboKEIYAKU_JYOKYO_Nm_To.Tag = "契約状況名"
        '
        'DropDownButton12
        '
        Me.DropDownButton12.Name = "DropDownButton12"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(313, 227)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(22, 15)
        Me.Label21.TabIndex = 1040
        Me.Label21.Text = "～"
        '
        'cboKEIYAKU_JYOKYO_Cd_Fm
        '
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.DropDown.AllowDrop = False
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.Format = "9"
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.HighlightText = True
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.ListHeaderPane.Height = 22
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.Location = New System.Drawing.Point(159, 224)
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.MaxLength = 1
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.Name = "cboKEIYAKU_JYOKYO_Cd_Fm"
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.Size = New System.Drawing.Size(30, 22)
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.Spin.AllowSpin = False
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.TabIndex = 17
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.Tag = "契約状況"
        Me.cboKEIYAKU_JYOKYO_Cd_Fm.Text = "9"
        '
        'cboKEIYAKU_JYOKYO_Nm_Fm
        '
        Me.cboKEIYAKU_JYOKYO_Nm_Fm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKEIYAKU_JYOKYO_Nm_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cboKEIYAKU_JYOKYO_Nm_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cboKEIYAKU_JYOKYO_Nm_Fm.ListHeaderPane.Height = 22
        Me.cboKEIYAKU_JYOKYO_Nm_Fm.ListHeaderPane.Visible = False
        Me.cboKEIYAKU_JYOKYO_Nm_Fm.Location = New System.Drawing.Point(200, 224)
        Me.cboKEIYAKU_JYOKYO_Nm_Fm.MaxLength = 8
        Me.cboKEIYAKU_JYOKYO_Nm_Fm.Name = "cboKEIYAKU_JYOKYO_Nm_Fm"
        Me.cboKEIYAKU_JYOKYO_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton13})
        Me.cboKEIYAKU_JYOKYO_Nm_Fm.Size = New System.Drawing.Size(106, 22)
        Me.cboKEIYAKU_JYOKYO_Nm_Fm.TabIndex = 18
        Me.cboKEIYAKU_JYOKYO_Nm_Fm.TabStop = False
        Me.cboKEIYAKU_JYOKYO_Nm_Fm.Tag = "契約状況名"
        '
        'DropDownButton13
        '
        Me.DropDownButton13.Name = "DropDownButton13"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(19, 227)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(82, 15)
        Me.Label22.TabIndex = 1039
        Me.Label22.Text = "□契約状況"
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
        Me.cboITAKU_Cd_To.Location = New System.Drawing.Point(159, 279)
        Me.cboITAKU_Cd_To.MaxLength = 3
        Me.cboITAKU_Cd_To.Name = "cboITAKU_Cd_To"
        Me.cboITAKU_Cd_To.Size = New System.Drawing.Size(31, 22)
        Me.cboITAKU_Cd_To.Spin.AllowSpin = False
        Me.cboITAKU_Cd_To.TabIndex = 23
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
        Me.cboITAKU_Nm_To.Location = New System.Drawing.Point(200, 279)
        Me.cboITAKU_Nm_To.MaxLength = 50
        Me.cboITAKU_Nm_To.Name = "cboITAKU_Nm_To"
        Me.cboITAKU_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.cboITAKU_Nm_To.Size = New System.Drawing.Size(548, 22)
        Me.cboITAKU_Nm_To.TabIndex = 24
        Me.cboITAKU_Nm_To.TabStop = False
        Me.cboITAKU_Nm_To.Tag = "事務委託先名"
        '
        'DropDownButton6
        '
        Me.DropDownButton6.Name = "DropDownButton6"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(754, 256)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 15)
        Me.Label3.TabIndex = 1034
        Me.Label3.Text = "～"
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
        Me.cboITAKU_Cd_Fm.Location = New System.Drawing.Point(159, 253)
        Me.cboITAKU_Cd_Fm.MaxLength = 3
        Me.cboITAKU_Cd_Fm.Name = "cboITAKU_Cd_Fm"
        Me.cboITAKU_Cd_Fm.Size = New System.Drawing.Size(31, 22)
        Me.cboITAKU_Cd_Fm.Spin.AllowSpin = False
        Me.cboITAKU_Cd_Fm.TabIndex = 21
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
        Me.cboITAKU_Nm_Fm.Location = New System.Drawing.Point(200, 251)
        Me.cboITAKU_Nm_Fm.MaxLength = 50
        Me.cboITAKU_Nm_Fm.Name = "cboITAKU_Nm_Fm"
        Me.cboITAKU_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton11})
        Me.cboITAKU_Nm_Fm.Size = New System.Drawing.Size(548, 22)
        Me.cboITAKU_Nm_Fm.TabIndex = 22
        Me.cboITAKU_Nm_Fm.TabStop = False
        Me.cboITAKU_Nm_Fm.Tag = "事務委託先名"
        '
        'DropDownButton11
        '
        Me.DropDownButton11.Name = "DropDownButton11"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(19, 256)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 15)
        Me.Label6.TabIndex = 1033
        Me.Label6.Text = "□事務委託先"
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
        Me.cboKEIYAKU_KBN_Cd_To.Location = New System.Drawing.Point(341, 194)
        Me.cboKEIYAKU_KBN_Cd_To.MaxLength = 1
        Me.cboKEIYAKU_KBN_Cd_To.Name = "cboKEIYAKU_KBN_Cd_To"
        Me.cboKEIYAKU_KBN_Cd_To.Size = New System.Drawing.Size(30, 22)
        Me.cboKEIYAKU_KBN_Cd_To.Spin.AllowSpin = False
        Me.cboKEIYAKU_KBN_Cd_To.TabIndex = 15
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
        Me.cboKEIYAKU_KBN_Nm_To.Location = New System.Drawing.Point(379, 194)
        Me.cboKEIYAKU_KBN_Nm_To.MaxLength = 8
        Me.cboKEIYAKU_KBN_Nm_To.Name = "cboKEIYAKU_KBN_Nm_To"
        Me.cboKEIYAKU_KBN_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton9})
        Me.cboKEIYAKU_KBN_Nm_To.Size = New System.Drawing.Size(106, 22)
        Me.cboKEIYAKU_KBN_Nm_To.TabIndex = 16
        Me.cboKEIYAKU_KBN_Nm_To.TabStop = False
        Me.cboKEIYAKU_KBN_Nm_To.Tag = "契約区分名"
        '
        'DropDownButton9
        '
        Me.DropDownButton9.Name = "DropDownButton9"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(313, 197)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 15)
        Me.Label12.TabIndex = 1028
        Me.Label12.Text = "～"
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
        Me.cboKEIYAKU_KBN_Cd_Fm.Location = New System.Drawing.Point(160, 194)
        Me.cboKEIYAKU_KBN_Cd_Fm.MaxLength = 1
        Me.cboKEIYAKU_KBN_Cd_Fm.Name = "cboKEIYAKU_KBN_Cd_Fm"
        Me.cboKEIYAKU_KBN_Cd_Fm.Size = New System.Drawing.Size(30, 22)
        Me.cboKEIYAKU_KBN_Cd_Fm.Spin.AllowSpin = False
        Me.cboKEIYAKU_KBN_Cd_Fm.TabIndex = 13
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
        Me.cboKEIYAKU_KBN_Nm_Fm.Location = New System.Drawing.Point(200, 194)
        Me.cboKEIYAKU_KBN_Nm_Fm.MaxLength = 8
        Me.cboKEIYAKU_KBN_Nm_Fm.Name = "cboKEIYAKU_KBN_Nm_Fm"
        Me.cboKEIYAKU_KBN_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton10})
        Me.cboKEIYAKU_KBN_Nm_Fm.Size = New System.Drawing.Size(106, 22)
        Me.cboKEIYAKU_KBN_Nm_Fm.TabIndex = 14
        Me.cboKEIYAKU_KBN_Nm_Fm.TabStop = False
        Me.cboKEIYAKU_KBN_Nm_Fm.Tag = "契約区分名"
        '
        'DropDownButton10
        '
        Me.DropDownButton10.Name = "DropDownButton10"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(19, 197)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 15)
        Me.Label15.TabIndex = 1027
        Me.Label15.Text = "□契約区分"
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
        Me.cboKEIYAKUSYA_Cd_To.Location = New System.Drawing.Point(159, 163)
        Me.cboKEIYAKUSYA_Cd_To.MaxLength = 5
        Me.cboKEIYAKUSYA_Cd_To.Name = "cboKEIYAKUSYA_Cd_To"
        Me.cboKEIYAKUSYA_Cd_To.Size = New System.Drawing.Size(51, 22)
        Me.cboKEIYAKUSYA_Cd_To.Spin.AllowSpin = False
        Me.cboKEIYAKUSYA_Cd_To.TabIndex = 11
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
        Me.cboKEIYAKUSYA_Nm_To.Location = New System.Drawing.Point(216, 163)
        Me.cboKEIYAKUSYA_Nm_To.MaxLength = 50
        Me.cboKEIYAKUSYA_Nm_To.Name = "cboKEIYAKUSYA_Nm_To"
        Me.cboKEIYAKUSYA_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton7})
        Me.cboKEIYAKUSYA_Nm_To.Size = New System.Drawing.Size(411, 22)
        Me.cboKEIYAKUSYA_Nm_To.TabIndex = 12
        Me.cboKEIYAKUSYA_Nm_To.TabStop = False
        Me.cboKEIYAKUSYA_Nm_To.Tag = "契約者名"
        '
        'DropDownButton7
        '
        Me.DropDownButton7.Name = "DropDownButton7"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(633, 140)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 15)
        Me.Label9.TabIndex = 1022
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
        Me.cboKEIYAKUSYA_Cd_Fm.Location = New System.Drawing.Point(159, 137)
        Me.cboKEIYAKUSYA_Cd_Fm.MaxLength = 5
        Me.cboKEIYAKUSYA_Cd_Fm.Name = "cboKEIYAKUSYA_Cd_Fm"
        Me.cboKEIYAKUSYA_Cd_Fm.Size = New System.Drawing.Size(51, 22)
        Me.cboKEIYAKUSYA_Cd_Fm.Spin.AllowSpin = False
        Me.cboKEIYAKUSYA_Cd_Fm.TabIndex = 9
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
        Me.cboKEIYAKUSYA_Nm_Fm.Location = New System.Drawing.Point(216, 137)
        Me.cboKEIYAKUSYA_Nm_Fm.MaxLength = 50
        Me.cboKEIYAKUSYA_Nm_Fm.Name = "cboKEIYAKUSYA_Nm_Fm"
        Me.cboKEIYAKUSYA_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton8})
        Me.cboKEIYAKUSYA_Nm_Fm.Size = New System.Drawing.Size(411, 22)
        Me.cboKEIYAKUSYA_Nm_Fm.TabIndex = 10
        Me.cboKEIYAKUSYA_Nm_Fm.TabStop = False
        Me.cboKEIYAKUSYA_Nm_Fm.Tag = "契約者名"
        '
        'DropDownButton8
        '
        Me.DropDownButton8.Name = "DropDownButton8"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(19, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 15)
        Me.Label5.TabIndex = 1021
        Me.Label5.Text = "□契約者番号"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(201, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 15)
        Me.Label4.TabIndex = 1016
        Me.Label4.Text = "期"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(289, 342)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(22, 15)
        Me.Label16.TabIndex = 1014
        Me.Label16.Text = "～"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(19, 342)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(97, 15)
        Me.Label29.TabIndex = 1005
        Me.Label29.Text = "□契約年月日"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(397, 79)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(62, 15)
        Me.Label27.TabIndex = 995
        Me.Label27.Text = "末　現在"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(325, 109)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 15)
        Me.Label13.TabIndex = 988
        Me.Label13.Text = "～"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(19, 79)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 15)
        Me.Label20.TabIndex = 981
        Me.Label20.Text = "■対象期"
        '
        'cobKEN_Cd_To
        '
        Me.cobKEN_Cd_To.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cobKEN_Cd_To.DropDown.AllowDrop = False
        Me.cobKEN_Cd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cobKEN_Cd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cobKEN_Cd_To.Format = "9"
        Me.cobKEN_Cd_To.HighlightText = True
        Me.cobKEN_Cd_To.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cobKEN_Cd_To.ListHeaderPane.Height = 22
        Me.cobKEN_Cd_To.Location = New System.Drawing.Point(353, 107)
        Me.cobKEN_Cd_To.MaxLength = 2
        Me.cobKEN_Cd_To.Name = "cobKEN_Cd_To"
        Me.cobKEN_Cd_To.Size = New System.Drawing.Size(36, 22)
        Me.cobKEN_Cd_To.Spin.AllowSpin = False
        Me.cobKEN_Cd_To.TabIndex = 6
        Me.cobKEN_Cd_To.Tag = "都道府県"
        Me.cobKEN_Cd_To.Text = "00"
        '
        'cobKEN_Nm_To
        '
        Me.cobKEN_Nm_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobKEN_Nm_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cobKEN_Nm_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cobKEN_Nm_To.ListHeaderPane.Height = 22
        Me.cobKEN_Nm_To.ListHeaderPane.Visible = False
        Me.cobKEN_Nm_To.Location = New System.Drawing.Point(395, 107)
        Me.cobKEN_Nm_To.Name = "cobKEN_Nm_To"
        Me.cobKEN_Nm_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.cobKEN_Nm_To.Size = New System.Drawing.Size(119, 22)
        Me.cobKEN_Nm_To.TabIndex = 7
        Me.cobKEN_Nm_To.TabStop = False
        Me.cobKEN_Nm_To.Tag = "都道府県名"
        '
        'DropDownButton3
        '
        Me.DropDownButton3.Name = "DropDownButton3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(19, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 959
        Me.Label2.Text = "□都道府県"
        '
        'cobKEN_Cd_Fm
        '
        Me.cobKEN_Cd_Fm.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cobKEN_Cd_Fm.DropDown.AllowDrop = False
        Me.cobKEN_Cd_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cobKEN_Cd_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cobKEN_Cd_Fm.Format = "9"
        Me.cobKEN_Cd_Fm.HighlightText = True
        Me.cobKEN_Cd_Fm.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cobKEN_Cd_Fm.ListHeaderPane.Height = 22
        Me.cobKEN_Cd_Fm.Location = New System.Drawing.Point(159, 106)
        Me.cobKEN_Cd_Fm.MaxLength = 2
        Me.cobKEN_Cd_Fm.Name = "cobKEN_Cd_Fm"
        Me.cobKEN_Cd_Fm.Size = New System.Drawing.Size(36, 22)
        Me.cobKEN_Cd_Fm.Spin.AllowSpin = False
        Me.cobKEN_Cd_Fm.TabIndex = 4
        Me.cobKEN_Cd_Fm.Tag = "都道府県"
        Me.cobKEN_Cd_Fm.Text = "00"
        '
        'cobKEN_Nm_Fm
        '
        Me.cobKEN_Nm_Fm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobKEN_Nm_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cobKEN_Nm_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cobKEN_Nm_Fm.ListHeaderPane.Height = 22
        Me.cobKEN_Nm_Fm.ListHeaderPane.Visible = False
        Me.cobKEN_Nm_Fm.Location = New System.Drawing.Point(200, 107)
        Me.cobKEN_Nm_Fm.Name = "cobKEN_Nm_Fm"
        Me.cobKEN_Nm_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cobKEN_Nm_Fm.Size = New System.Drawing.Size(119, 22)
        Me.cobKEN_Nm_Fm.TabIndex = 5
        Me.cobKEN_Nm_Fm.TabStop = False
        Me.cobKEN_Nm_Fm.Tag = "都道府県名"
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(958, 429)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(20, 15)
        Me.Label14.TabIndex = 928
        Me.Label14.Text = "件"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCOUNT_HED
        '
        Me.lblCOUNT_HED.BackColor = System.Drawing.Color.Transparent
        Me.lblCOUNT_HED.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCOUNT_HED.Location = New System.Drawing.Point(906, 429)
        Me.lblCOUNT_HED.Name = "lblCOUNT_HED"
        Me.lblCOUNT_HED.Size = New System.Drawing.Size(55, 19)
        Me.lblCOUNT_HED.TabIndex = 927
        Me.lblCOUNT_HED.Text = "99999"
        Me.lblCOUNT_HED.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(835, 429)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 15)
        Me.Label18.TabIndex = 926
        Me.Label18.Text = "契約件数："
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtnOutMEISAI)
        Me.GroupBox2.Controls.Add(Me.rbtnOutKIHON)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(159, 362)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(426, 38)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        '
        'grpMikeiyaku
        '
        Me.grpMikeiyaku.Controls.Add(Me.chk_MikeiyakuNozoku)
        Me.grpMikeiyaku.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpMikeiyaku.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpMikeiyaku.Location = New System.Drawing.Point(675, 58)
        Me.grpMikeiyaku.Name = "grpMikeiyaku"
        Me.grpMikeiyaku.Size = New System.Drawing.Size(282, 38)
        Me.grpMikeiyaku.TabIndex = 3
        Me.grpMikeiyaku.TabStop = False
        '
        'chk_MikeiyakuNozoku
        '
        Me.chk_MikeiyakuNozoku.AutoSize = True
        Me.chk_MikeiyakuNozoku.Checked = True
        Me.chk_MikeiyakuNozoku.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_MikeiyakuNozoku.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_MikeiyakuNozoku.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chk_MikeiyakuNozoku.Location = New System.Drawing.Point(10, 12)
        Me.chk_MikeiyakuNozoku.Name = "chk_MikeiyakuNozoku"
        Me.chk_MikeiyakuNozoku.Size = New System.Drawing.Size(173, 20)
        Me.chk_MikeiyakuNozoku.TabIndex = 999
        Me.chk_MikeiyakuNozoku.Text = "契約日未入力者を除く"
        Me.chk_MikeiyakuNozoku.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(482, 79)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(137, 15)
        Me.Label17.TabIndex = 1049
        Me.Label17.Text = "(契約情報の契約日)"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(460, 342)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(161, 15)
        Me.Label24.TabIndex = 1050
        Me.Label24.Text = "(契約者マスタの契約日)"
        '
        'chk_MinyukinNozoku
        '
        Me.chk_MinyukinNozoku.AutoSize = True
        Me.chk_MinyukinNozoku.Checked = True
        Me.chk_MinyukinNozoku.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_MinyukinNozoku.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_MinyukinNozoku.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chk_MinyukinNozoku.Location = New System.Drawing.Point(9, 12)
        Me.chk_MinyukinNozoku.Name = "chk_MinyukinNozoku"
        Me.chk_MinyukinNozoku.Size = New System.Drawing.Size(211, 20)
        Me.chk_MinyukinNozoku.TabIndex = 990
        Me.chk_MinyukinNozoku.Text = "入金・返還日未入力者を除く"
        Me.chk_MinyukinNozoku.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chk_MinyukinNozoku)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(675, 92)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(282, 38)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        '
        'frmGJ7010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.grpMikeiyaku)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dateTAISYO_Ym)
        Me.Controls.Add(Me.cboKEIYAKUSYA_Cd_To)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.cboKEIYAKUSYA_Cd_Fm)
        Me.Controls.Add(Me.numKI)
        Me.Controls.Add(Me.cboKEIYAKUSYA_Nm_To)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cboKEIYAKUSYA_Nm_Fm)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Cd_To)
        Me.Controls.Add(Me.cobKEN_Cd_To)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cobKEN_Nm_To)
        Me.Controls.Add(Me.cboKEIYAKU_JYOKYO_Cd_To)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cobKEN_Cd_Fm)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Nm_To)
        Me.Controls.Add(Me.cobKEN_Nm_Fm)
        Me.Controls.Add(Me.cboTORI_KBN_Cd_To)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cboKEIYAKU_JYOKYO_Nm_To)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Cd_Fm)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboKEIYAKU_KBN_Nm_Fm)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cboTORI_KBN_Nm_To)
        Me.Controls.Add(Me.cboKEIYAKU_JYOKYO_Cd_Fm)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cboKEIYAKU_JYOKYO_Nm_Fm)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboITAKU_Cd_To)
        Me.Controls.Add(Me.cboITAKU_Cd_Fm)
        Me.Controls.Add(Me.cboITAKU_Nm_To)
        Me.Controls.Add(Me.cboITAKU_Nm_Fm)
        Me.Controls.Add(Me.cboTORI_KBN_Cd_Fm)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblCOUNT_HED)
        Me.Controls.Add(Me.cboTORI_KBN_Nm_Fm)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.dgv_Search)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblCOUNT_DTL)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.dateKEIYAKU_Ymd_Fm)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.dateKEIYAKU_Ymd_To)
        Me.Name = "frmGJ7010"
        Me.Text = "(GJ7010)互助基金契約者情報検索ＣＳＶデータ作成"
        Me.Controls.SetChildIndex(Me.dateKEIYAKU_Ymd_To, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.dateKEIYAKU_Ymd_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label29, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.cmdSearch, 0)
        Me.Controls.SetChildIndex(Me.cmdClear, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.lblCOUNT_DTL, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.dgv_Search, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.cboTORI_KBN_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.lblCOUNT_HED, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.cboTORI_KBN_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboITAKU_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboITAKU_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.cboITAKU_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboITAKU_Cd_To, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_JYOKYO_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_JYOKYO_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboTORI_KBN_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_JYOKYO_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.cboTORI_KBN_Cd_To, 0)
        Me.Controls.SetChildIndex(Me.cobKEN_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.cobKEN_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_JYOKYO_Cd_To, 0)
        Me.Controls.SetChildIndex(Me.cobKEN_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cobKEN_Cd_To, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKU_KBN_Cd_To, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKUSYA_Nm_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKUSYA_Nm_To, 0)
        Me.Controls.SetChildIndex(Me.numKI, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKUSYA_Cd_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.cboKEIYAKUSYA_Cd_To, 0)
        Me.Controls.SetChildIndex(Me.dateTAISYO_Ym, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.grpMikeiyaku, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateKEIYAKU_Ymd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateKEIYAKU_Ymd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateTAISYO_Ym, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTORI_KBN_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTORI_KBN_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTORI_KBN_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTORI_KBN_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_JYOKYO_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_JYOKYO_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_JYOKYO_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_JYOKYO_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboITAKU_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboITAKU_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboITAKU_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboITAKU_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_KBN_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_KBN_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_KBN_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKU_KBN_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKEIYAKUSYA_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cobKEN_Cd_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cobKEN_Nm_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cobKEN_Cd_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cobKEN_Nm_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpMikeiyaku.ResumeLayout(False)
        Me.grpMikeiyaku.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCsv As JBD.Gjs.Win.JButton
    Friend WithEvents dgv_Search As JBD.Gjs.Win.DataGridView
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents lblCOUNT_DTL As JBD.Gjs.Win.Label
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents cmdClear As JBD.Gjs.Win.JButton
    Friend WithEvents cmdSearch As JBD.Gjs.Win.JButton
    Friend WithEvents GroupBox1 As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtnSearchOr As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtnSearchAnd As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents Label25 As JBD.Gjs.Win.Label
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents Label20 As JBD.Gjs.Win.Label
    Friend WithEvents cobKEN_Cd_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cobKEN_Nm_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents cobKEN_Cd_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cobKEN_Nm_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents Label27 As JBD.Gjs.Win.Label
    Friend WithEvents numKI As JBD.Gjs.Win.GcNumber
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents Label29 As JBD.Gjs.Win.Label
    Friend WithEvents dateKEIYAKU_Ymd_To As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents dateKEIYAKU_Ymd_Fm As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents dateTAISYO_Ym As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton5 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cboTORI_KBN_Cd_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboTORI_KBN_Nm_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton14 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents cboTORI_KBN_Cd_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboTORI_KBN_Nm_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton15 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label23 As JBD.Gjs.Win.Label
    Friend WithEvents cboKEIYAKU_JYOKYO_Cd_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEIYAKU_JYOKYO_Nm_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton12 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label21 As JBD.Gjs.Win.Label
    Friend WithEvents cboKEIYAKU_JYOKYO_Cd_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEIYAKU_JYOKYO_Nm_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton13 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label22 As JBD.Gjs.Win.Label
    Friend WithEvents cboITAKU_Cd_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboITAKU_Nm_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton6 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents cboITAKU_Cd_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboITAKU_Nm_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton11 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents cboKEIYAKU_KBN_Cd_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEIYAKU_KBN_Nm_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton9 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents cboKEIYAKU_KBN_Cd_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEIYAKU_KBN_Nm_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton10 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents cboKEIYAKUSYA_Cd_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEIYAKUSYA_Nm_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton7 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents cboKEIYAKUSYA_Cd_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cboKEIYAKUSYA_Nm_Fm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton8 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents rbtnOutKIHON As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtnOutMEISAI As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents lblCOUNT_HED As JBD.Gjs.Win.Label
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents GroupBox2 As JBD.Gjs.Win.GroupBox
    Friend WithEvents KEIYAKUSYA_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKUSYA_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKUSYA_KANA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_KBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_KBN_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_JYOKYO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_JYOKYO_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR_TEL1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEN_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEN_CD_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JIMUITAKU_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITAKU_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COUNT_HED As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COUNT_DTL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grpMikeiyaku As JBD.Gjs.Win.GroupBox
    Friend WithEvents chk_MikeiyakuNozoku As JBD.Gjs.Win.CheckBox
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents chk_MinyukinNozoku As JBD.Gjs.Win.CheckBox
    Friend WithEvents GroupBox3 As JBD.Gjs.Win.GroupBox
End Class
