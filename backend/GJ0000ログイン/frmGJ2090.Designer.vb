Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ2090
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
        Dim NumberIntegerPartDisplayField1 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField2 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
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
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.KEIYAKUSYA_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKUSYA_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKUSYA_KANA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYORI_JOKYO_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYORI_JOKYO_KBN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEIKYU_HENKAN_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEIKYU_HENKAN_KBN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEIKYU_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NYUKIN_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEIKYU_KINGAKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HEMKAN_KINGAKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEIKYU_KAISU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TUMITATE_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NYUKIN_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblCOUNT = New JBD.Gjs.Win.Label(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdClear = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdSearch = New JBD.Gjs.Win.JButton(Me.components)
        Me.GroupBox1 = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtnSearchOr = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtnSearchAnd = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdKakunin = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label25 = New JBD.Gjs.Win.Label(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.dateNYURYOKU_Ymd = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton7 = New GrapeCity.Win.Editors.DropDownButton()
        Me.numKI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSEIKYU_KAISU_From = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSEIKYU_KAISU_To = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSEIKYU_KIN_From = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSEIKYU_KIN_To = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.dateNYUKIN_Ymd_From = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dateNYUKIN_Ymd_To = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbtnALL = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtnMI = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtnSUMI = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtnNYUKIN = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtnHENKAN = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label29 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label28 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label27 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label23 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label22 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.cobJIMUITAKU_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cobJIMUITAKU_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton6 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label20 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label26 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.txtKEIYAKUSYA_KANA = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.txtKEIYAKUSYA_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.cobKEN_CD_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cobKEN_NM_To = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.txtKEIYAKUSYA_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.cobKEN_CD_From = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cobKEN_NM_From = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label21 = New JBD.Gjs.Win.Label(Me.components)
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.Label30 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dateNYURYOKU_Ymd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSEIKYU_KAISU_From, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSEIKYU_KAISU_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSEIKYU_KIN_From, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSEIKYU_KIN_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateNYUKIN_Ymd_From, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateNYUKIN_Ymd_To, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cobJIMUITAKU_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cobJIMUITAKU_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKEIYAKUSYA_KANA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cobKEN_CD_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cobKEN_NM_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cobKEN_CD_From, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cobKEN_NM_From, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdKakunin)
        Me.pnlButton.Size = New System.Drawing.Size(1091, 55)
        Me.pnlButton.TabIndex = 100
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdKakunin, 0)
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
        Me.cmdEnd.Location = New System.Drawing.Point(967, 6)
        Me.cmdEnd.TabIndex = 99
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
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KEIYAKUSYA_CD, Me.KEIYAKUSYA_NAME, Me.KEIYAKUSYA_KANA, Me.SYORI_JOKYO_KBN, Me.SYORI_JOKYO_KBN_NM, Me.SEIKYU_HENKAN_KBN, Me.SEIKYU_HENKAN_KBN_NM, Me.SEIKYU_DATE, Me.NYUKIN_DATE, Me.SEIKYU_KINGAKU, Me.HEMKAN_KINGAKU, Me.SEIKYU_KAISU, Me.TUMITATE_KBN, Me.NYUKIN_KBN})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(9, 482)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
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
        Me.dgv_Search.Size = New System.Drawing.Size(1052, 256)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 70
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
        Me.KEIYAKUSYA_NAME.Width = 165
        '
        'KEIYAKUSYA_KANA
        '
        Me.KEIYAKUSYA_KANA.DataPropertyName = "KEIYAKUSYA_KANA"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKUSYA_KANA.DefaultCellStyle = DataGridViewCellStyle4
        Me.KEIYAKUSYA_KANA.HeaderText = "フリガナ"
        Me.KEIYAKUSYA_KANA.Name = "KEIYAKUSYA_KANA"
        Me.KEIYAKUSYA_KANA.ReadOnly = True
        Me.KEIYAKUSYA_KANA.Width = 150
        '
        'SYORI_JOKYO_KBN
        '
        Me.SYORI_JOKYO_KBN.DataPropertyName = "SYORI_JOKYO_KBN"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.SYORI_JOKYO_KBN.DefaultCellStyle = DataGridViewCellStyle5
        Me.SYORI_JOKYO_KBN.HeaderText = "処理状況区分コード"
        Me.SYORI_JOKYO_KBN.Name = "SYORI_JOKYO_KBN"
        Me.SYORI_JOKYO_KBN.ReadOnly = True
        Me.SYORI_JOKYO_KBN.Visible = False
        Me.SYORI_JOKYO_KBN.Width = 65
        '
        'SYORI_JOKYO_KBN_NM
        '
        Me.SYORI_JOKYO_KBN_NM.DataPropertyName = "SYORI_JOKYO_KBN_NM"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYORI_JOKYO_KBN_NM.DefaultCellStyle = DataGridViewCellStyle6
        Me.SYORI_JOKYO_KBN_NM.HeaderText = "処理状況"
        Me.SYORI_JOKYO_KBN_NM.Name = "SYORI_JOKYO_KBN_NM"
        Me.SYORI_JOKYO_KBN_NM.ReadOnly = True
        Me.SYORI_JOKYO_KBN_NM.Width = 107
        '
        'SEIKYU_HENKAN_KBN
        '
        Me.SEIKYU_HENKAN_KBN.DataPropertyName = "SEIKYU_HENKAN_KBN"
        Me.SEIKYU_HENKAN_KBN.HeaderText = "請求・返還区分状況コード"
        Me.SEIKYU_HENKAN_KBN.Name = "SEIKYU_HENKAN_KBN"
        Me.SEIKYU_HENKAN_KBN.ReadOnly = True
        Me.SEIKYU_HENKAN_KBN.Visible = False
        '
        'SEIKYU_HENKAN_KBN_NM
        '
        Me.SEIKYU_HENKAN_KBN_NM.DataPropertyName = "SEIKYU_HENKAN_KBN_NM"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.SEIKYU_HENKAN_KBN_NM.DefaultCellStyle = DataGridViewCellStyle7
        Me.SEIKYU_HENKAN_KBN_NM.HeaderText = "請求・返還"
        Me.SEIKYU_HENKAN_KBN_NM.Name = "SEIKYU_HENKAN_KBN_NM"
        Me.SEIKYU_HENKAN_KBN_NM.ReadOnly = True
        '
        'SEIKYU_DATE
        '
        Me.SEIKYU_DATE.DataPropertyName = "SEIKYU_DATE"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SEIKYU_DATE.DefaultCellStyle = DataGridViewCellStyle8
        Me.SEIKYU_DATE.HeaderText = "請求・返還日"
        Me.SEIKYU_DATE.Name = "SEIKYU_DATE"
        Me.SEIKYU_DATE.ReadOnly = True
        Me.SEIKYU_DATE.Width = 105
        '
        'NYUKIN_DATE
        '
        Me.NYUKIN_DATE.DataPropertyName = "NYUKIN_DATE"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.NYUKIN_DATE.DefaultCellStyle = DataGridViewCellStyle9
        Me.NYUKIN_DATE.HeaderText = "入金・振込日"
        Me.NYUKIN_DATE.Name = "NYUKIN_DATE"
        Me.NYUKIN_DATE.ReadOnly = True
        Me.NYUKIN_DATE.Width = 105
        '
        'SEIKYU_KINGAKU
        '
        Me.SEIKYU_KINGAKU.DataPropertyName = "SEIKYU_KINGAKU"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.SEIKYU_KINGAKU.DefaultCellStyle = DataGridViewCellStyle10
        Me.SEIKYU_KINGAKU.HeaderText = "請求金額"
        Me.SEIKYU_KINGAKU.Name = "SEIKYU_KINGAKU"
        Me.SEIKYU_KINGAKU.ReadOnly = True
        Me.SEIKYU_KINGAKU.Width = 105
        '
        'HEMKAN_KINGAKU
        '
        Me.HEMKAN_KINGAKU.DataPropertyName = "HEMKAN_KINGAKU"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HEMKAN_KINGAKU.DefaultCellStyle = DataGridViewCellStyle11
        Me.HEMKAN_KINGAKU.HeaderText = "返還金額"
        Me.HEMKAN_KINGAKU.Name = "HEMKAN_KINGAKU"
        Me.HEMKAN_KINGAKU.ReadOnly = True
        Me.HEMKAN_KINGAKU.Width = 105
        '
        'SEIKYU_KAISU
        '
        Me.SEIKYU_KAISU.DataPropertyName = "SEIKYU_KAISU"
        Me.SEIKYU_KAISU.HeaderText = "請求回数"
        Me.SEIKYU_KAISU.Name = "SEIKYU_KAISU"
        Me.SEIKYU_KAISU.ReadOnly = True
        Me.SEIKYU_KAISU.Visible = False
        '
        'TUMITATE_KBN
        '
        Me.TUMITATE_KBN.DataPropertyName = "TUMITATE_KBN"
        Me.TUMITATE_KBN.HeaderText = "積立区分"
        Me.TUMITATE_KBN.Name = "TUMITATE_KBN"
        Me.TUMITATE_KBN.ReadOnly = True
        Me.TUMITATE_KBN.Visible = False
        '
        'NYUKIN_KBN
        '
        Me.NYUKIN_KBN.DataPropertyName = "NYUKIN_KBN"
        Me.NYUKIN_KBN.HeaderText = "積立金入金区分"
        Me.NYUKIN_KBN.Name = "NYUKIN_KBN"
        Me.NYUKIN_KBN.ReadOnly = True
        Me.NYUKIN_KBN.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(1054, 413)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 15)
        Me.Label7.TabIndex = 923
        Me.Label7.Text = "件"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCOUNT
        '
        Me.lblCOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblCOUNT.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCOUNT.Location = New System.Drawing.Point(990, 453)
        Me.lblCOUNT.Name = "lblCOUNT"
        Me.lblCOUNT.Size = New System.Drawing.Size(55, 15)
        Me.lblCOUNT.TabIndex = 922
        Me.lblCOUNT.Text = "99999"
        Me.lblCOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(911, 453)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 15)
        Me.Label11.TabIndex = 921
        Me.Label11.Text = "抽出件数："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(800, 435)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(94, 44)
        Me.cmdClear.TabIndex = 61
        Me.cmdClear.Text = "条件クリア"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(688, 435)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(94, 44)
        Me.cmdSearch.TabIndex = 60
        Me.cmdSearch.Text = "検索"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtnSearchOr)
        Me.GroupBox1.Controls.Add(Me.rbtnSearchAnd)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(155, 441)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(339, 38)
        Me.GroupBox1.TabIndex = 50
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
        Me.Label19.Location = New System.Drawing.Point(25, 453)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(82, 15)
        Me.Label19.TabIndex = 916
        Me.Label19.Text = "■検索方法"
        '
        'cmdKakunin
        '
        Me.cmdKakunin.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdKakunin.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdKakunin.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdKakunin.Location = New System.Drawing.Point(12, 6)
        Me.cmdKakunin.Name = "cmdKakunin"
        Me.cmdKakunin.Size = New System.Drawing.Size(92, 44)
        Me.cmdKakunin.TabIndex = 71
        Me.cmdKakunin.Text = "入金確認"
        Me.cmdKakunin.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(37, 92)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(129, 19)
        Me.Label25.TabIndex = 925
        Me.Label25.Text = "検索条件入力"
        '
        'dateNYURYOKU_Ymd
        '
        Me.dateNYURYOKU_Ymd.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.dateNYURYOKU_Ymd.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.dateNYURYOKU_Ymd.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateNYURYOKU_Ymd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateNYURYOKU_Ymd.Location = New System.Drawing.Point(937, 89)
        Me.dateNYURYOKU_Ymd.Name = "dateNYURYOKU_Ymd"
        Me.GcShortcut1.SetShortcuts(Me.dateNYURYOKU_Ymd, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateNYURYOKU_Ymd, Object), CType(Me.dateNYURYOKU_Ymd, Object), CType(Me.dateNYURYOKU_Ymd, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateNYURYOKU_Ymd.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton7})
        Me.dateNYURYOKU_Ymd.Size = New System.Drawing.Size(124, 20)
        Me.dateNYURYOKU_Ymd.Spin.AllowSpin = False
        Me.dateNYURYOKU_Ymd.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateNYURYOKU_Ymd.TabIndex = 101
        Me.dateNYURYOKU_Ymd.Value = New Date(2015, 1, 15, 16, 13, 23, 0)
        '
        'DropDownButton7
        '
        Me.DropDownButton7.Name = "DropDownButton7"
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
        Me.numKI.Location = New System.Drawing.Point(219, 6)
        Me.numKI.Name = "numKI"
        Me.GcShortcut1.SetShortcuts(Me.numKI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKI, Object), CType(Me.numKI, Object), CType(Me.numKI, Object), CType(Me.numKI, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKI.Size = New System.Drawing.Size(39, 20)
        Me.numKI.Spin.Increment = 0
        Me.numKI.TabIndex = 1
        Me.numKI.Value = New Decimal(New Integer() {99, 0, 0, 0})
        Me.numKI.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        Me.numKI.ZeroSuppress = True
        '
        'numSEIKYU_KAISU_From
        '
        Me.numSEIKYU_KAISU_From.AllowDeleteToNull = True
        Me.numSEIKYU_KAISU_From.DropDown.AllowDrop = False
        Me.numSEIKYU_KAISU_From.Fields.DecimalPart.MaxDigits = 0
        Me.numSEIKYU_KAISU_From.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSEIKYU_KAISU_From.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numSEIKYU_KAISU_From.Fields.IntegerPart.MaxDigits = 3
        Me.numSEIKYU_KAISU_From.Fields.IntegerPart.MinDigits = 1
        Me.numSEIKYU_KAISU_From.Fields.SignPrefix.NegativePattern = ""
        Me.numSEIKYU_KAISU_From.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSEIKYU_KAISU_From.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSEIKYU_KAISU_From.HighlightText = True
        Me.numSEIKYU_KAISU_From.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSEIKYU_KAISU_From.Location = New System.Drawing.Point(456, 6)
        Me.numSEIKYU_KAISU_From.Name = "numSEIKYU_KAISU_From"
        Me.GcShortcut1.SetShortcuts(Me.numSEIKYU_KAISU_From, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSEIKYU_KAISU_From, Object), CType(Me.numSEIKYU_KAISU_From, Object), CType(Me.numSEIKYU_KAISU_From, Object), CType(Me.numSEIKYU_KAISU_From, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSEIKYU_KAISU_From.Size = New System.Drawing.Size(39, 20)
        Me.numSEIKYU_KAISU_From.Spin.Increment = 0
        Me.numSEIKYU_KAISU_From.TabIndex = 2
        Me.numSEIKYU_KAISU_From.Value = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numSEIKYU_KAISU_From.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSEIKYU_KAISU_To
        '
        Me.numSEIKYU_KAISU_To.AllowDeleteToNull = True
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
        Me.numSEIKYU_KAISU_To.Location = New System.Drawing.Point(545, 7)
        Me.numSEIKYU_KAISU_To.Name = "numSEIKYU_KAISU_To"
        Me.GcShortcut1.SetShortcuts(Me.numSEIKYU_KAISU_To, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSEIKYU_KAISU_To, Object), CType(Me.numSEIKYU_KAISU_To, Object), CType(Me.numSEIKYU_KAISU_To, Object), CType(Me.numSEIKYU_KAISU_To, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSEIKYU_KAISU_To.Size = New System.Drawing.Size(39, 20)
        Me.numSEIKYU_KAISU_To.Spin.Increment = 0
        Me.numSEIKYU_KAISU_To.TabIndex = 3
        Me.numSEIKYU_KAISU_To.Value = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numSEIKYU_KAISU_To.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSEIKYU_KIN_From
        '
        Me.numSEIKYU_KIN_From.AllowDeleteToNull = True
        NumberIntegerPartDisplayField1.GroupSizes = New Integer() {3}
        Me.numSEIKYU_KIN_From.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField1})
        Me.numSEIKYU_KIN_From.DropDown.AllowDrop = False
        Me.numSEIKYU_KIN_From.Fields.DecimalPart.MaxDigits = 0
        Me.numSEIKYU_KIN_From.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSEIKYU_KIN_From.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSEIKYU_KIN_From.Fields.IntegerPart.MaxDigits = 9
        Me.numSEIKYU_KIN_From.Fields.IntegerPart.MinDigits = 1
        Me.numSEIKYU_KIN_From.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSEIKYU_KIN_From.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSEIKYU_KIN_From.HighlightText = True
        Me.numSEIKYU_KIN_From.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSEIKYU_KIN_From.Location = New System.Drawing.Point(219, 176)
        Me.numSEIKYU_KIN_From.Name = "numSEIKYU_KIN_From"
        Me.GcShortcut1.SetShortcuts(Me.numSEIKYU_KIN_From, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSEIKYU_KIN_From, Object), CType(Me.numSEIKYU_KIN_From, Object), CType(Me.numSEIKYU_KIN_From, Object), CType(Me.numSEIKYU_KIN_From, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSEIKYU_KIN_From.Size = New System.Drawing.Size(67, 20)
        Me.numSEIKYU_KIN_From.Spin.Increment = 0
        Me.numSEIKYU_KIN_From.TabIndex = 13
        Me.numSEIKYU_KIN_From.Value = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.numSEIKYU_KIN_From.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSEIKYU_KIN_To
        '
        Me.numSEIKYU_KIN_To.AllowDeleteToNull = True
        NumberIntegerPartDisplayField2.GroupSizes = New Integer() {3}
        Me.numSEIKYU_KIN_To.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField2})
        Me.numSEIKYU_KIN_To.DropDown.AllowDrop = False
        Me.numSEIKYU_KIN_To.Fields.DecimalPart.MaxDigits = 0
        Me.numSEIKYU_KIN_To.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSEIKYU_KIN_To.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSEIKYU_KIN_To.Fields.IntegerPart.MaxDigits = 6
        Me.numSEIKYU_KIN_To.Fields.IntegerPart.MinDigits = 1
        Me.numSEIKYU_KIN_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSEIKYU_KIN_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSEIKYU_KIN_To.HighlightText = True
        Me.numSEIKYU_KIN_To.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSEIKYU_KIN_To.Location = New System.Drawing.Point(348, 176)
        Me.numSEIKYU_KIN_To.Name = "numSEIKYU_KIN_To"
        Me.GcShortcut1.SetShortcuts(Me.numSEIKYU_KIN_To, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSEIKYU_KIN_To, Object), CType(Me.numSEIKYU_KIN_To, Object), CType(Me.numSEIKYU_KIN_To, Object), CType(Me.numSEIKYU_KIN_To, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSEIKYU_KIN_To.Size = New System.Drawing.Size(67, 20)
        Me.numSEIKYU_KIN_To.Spin.Increment = 0
        Me.numSEIKYU_KIN_To.TabIndex = 14
        Me.numSEIKYU_KIN_To.Value = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.numSEIKYU_KIN_To.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'dateNYUKIN_Ymd_From
        '
        Me.dateNYUKIN_Ymd_From.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField5.Text = "/"
        DateLiteralField6.Text = "/"
        Me.dateNYUKIN_Ymd_From.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateLiteralField4, DateEraYearField2, DateLiteralField5, DateMonthField2, DateLiteralField6, DateDayField2})
        Me.dateNYUKIN_Ymd_From.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateNYUKIN_Ymd_From.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateNYUKIN_Ymd_From.Location = New System.Drawing.Point(219, 275)
        Me.dateNYUKIN_Ymd_From.Name = "dateNYUKIN_Ymd_From"
        Me.GcShortcut1.SetShortcuts(Me.dateNYUKIN_Ymd_From, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateNYUKIN_Ymd_From, Object), CType(Me.dateNYUKIN_Ymd_From, Object), CType(Me.dateNYUKIN_Ymd_From, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateNYUKIN_Ymd_From.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.dateNYUKIN_Ymd_From.Size = New System.Drawing.Size(124, 20)
        Me.dateNYUKIN_Ymd_From.Spin.AllowSpin = False
        Me.dateNYUKIN_Ymd_From.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateNYUKIN_Ymd_From.TabIndex = 22
        Me.dateNYUKIN_Ymd_From.Value = New Date(2015, 1, 15, 16, 13, 23, 0)
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'dateNYUKIN_Ymd_To
        '
        Me.dateNYUKIN_Ymd_To.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField8.Text = "/"
        DateLiteralField9.Text = "/"
        Me.dateNYUKIN_Ymd_To.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField3, DateLiteralField7, DateEraYearField3, DateLiteralField8, DateMonthField3, DateLiteralField9, DateDayField3})
        Me.dateNYUKIN_Ymd_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateNYUKIN_Ymd_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateNYUKIN_Ymd_To.Location = New System.Drawing.Point(377, 275)
        Me.dateNYUKIN_Ymd_To.Name = "dateNYUKIN_Ymd_To"
        Me.GcShortcut1.SetShortcuts(Me.dateNYUKIN_Ymd_To, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateNYUKIN_Ymd_To, Object), CType(Me.dateNYUKIN_Ymd_To, Object), CType(Me.dateNYUKIN_Ymd_To, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateNYUKIN_Ymd_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton4})
        Me.dateNYUKIN_Ymd_To.Size = New System.Drawing.Size(124, 20)
        Me.dateNYUKIN_Ymd_To.Spin.AllowSpin = False
        Me.dateNYUKIN_Ymd_To.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateNYUKIN_Ymd_To.TabIndex = 23
        Me.dateNYUKIN_Ymd_To.Value = New Date(2015, 1, 15, 16, 13, 23, 0)
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dateNYUKIN_Ymd_To)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.dateNYUKIN_Ymd_From)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.numSEIKYU_KIN_To)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.numSEIKYU_KIN_From)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.numSEIKYU_KAISU_To)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.numSEIKYU_KAISU_From)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.numKI)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cobJIMUITAKU_CD)
        Me.Panel1.Controls.Add(Me.cobJIMUITAKU_NM)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtKEIYAKUSYA_KANA)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtKEIYAKUSYA_CD)
        Me.Panel1.Controls.Add(Me.cobKEN_CD_To)
        Me.Panel1.Controls.Add(Me.cobKEN_NM_To)
        Me.Panel1.Controls.Add(Me.txtKEIYAKUSYA_NAME)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cobKEN_CD_From)
        Me.Panel1.Controls.Add(Me.cobKEN_NM_From)
        Me.Panel1.Location = New System.Drawing.Point(28, 115)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1046, 317)
        Me.Panel1.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(349, 278)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(22, 15)
        Me.Label16.TabIndex = 1014
        Me.Label16.Text = "～"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbtnALL)
        Me.GroupBox3.Controls.Add(Me.rbtnMI)
        Me.GroupBox3.Controls.Add(Me.rbtnSUMI)
        Me.GroupBox3.Location = New System.Drawing.Point(218, 233)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(365, 31)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        '
        'rbtnALL
        '
        Me.rbtnALL.AutoSize = True
        Me.rbtnALL.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnALL.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtnALL.Location = New System.Drawing.Point(12, 7)
        Me.rbtnALL.Name = "rbtnALL"
        Me.rbtnALL.Size = New System.Drawing.Size(60, 20)
        Me.rbtnALL.TabIndex = 1
        Me.rbtnALL.TabStop = True
        Me.rbtnALL.Text = "全て"
        Me.rbtnALL.UseVisualStyleBackColor = True
        '
        'rbtnMI
        '
        Me.rbtnMI.AutoSize = True
        Me.rbtnMI.Checked = True
        Me.rbtnMI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnMI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtnMI.Location = New System.Drawing.Point(78, 7)
        Me.rbtnMI.Name = "rbtnMI"
        Me.rbtnMI.Size = New System.Drawing.Size(144, 20)
        Me.rbtnMI.TabIndex = 2
        Me.rbtnMI.TabStop = True
        Me.rbtnMI.Text = "未入金・未返還分"
        Me.rbtnMI.UseVisualStyleBackColor = True
        '
        'rbtnSUMI
        '
        Me.rbtnSUMI.AutoSize = True
        Me.rbtnSUMI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnSUMI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtnSUMI.Location = New System.Drawing.Point(229, 7)
        Me.rbtnSUMI.Name = "rbtnSUMI"
        Me.rbtnSUMI.Size = New System.Drawing.Size(129, 20)
        Me.rbtnSUMI.TabIndex = 3
        Me.rbtnSUMI.TabStop = True
        Me.rbtnSUMI.Text = "入金・返還済分"
        Me.rbtnSUMI.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtnNYUKIN)
        Me.GroupBox2.Controls.Add(Me.rbtnHENKAN)
        Me.GroupBox2.Location = New System.Drawing.Point(218, 200)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(140, 31)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        '
        'rbtnNYUKIN
        '
        Me.rbtnNYUKIN.AutoSize = True
        Me.rbtnNYUKIN.Checked = True
        Me.rbtnNYUKIN.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnNYUKIN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtnNYUKIN.Location = New System.Drawing.Point(13, 7)
        Me.rbtnNYUKIN.Name = "rbtnNYUKIN"
        Me.rbtnNYUKIN.Size = New System.Drawing.Size(61, 20)
        Me.rbtnNYUKIN.TabIndex = 1
        Me.rbtnNYUKIN.TabStop = True
        Me.rbtnNYUKIN.Text = "入金"
        Me.rbtnNYUKIN.UseVisualStyleBackColor = True
        '
        'rbtnHENKAN
        '
        Me.rbtnHENKAN.AutoSize = True
        Me.rbtnHENKAN.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnHENKAN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtnHENKAN.Location = New System.Drawing.Point(80, 7)
        Me.rbtnHENKAN.Name = "rbtnHENKAN"
        Me.rbtnHENKAN.Size = New System.Drawing.Size(61, 20)
        Me.rbtnHENKAN.TabIndex = 2
        Me.rbtnHENKAN.TabStop = True
        Me.rbtnHENKAN.Text = "返還"
        Me.rbtnHENKAN.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(21, 278)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(105, 15)
        Me.Label29.TabIndex = 1005
        Me.Label29.Text = "□入金・返還日"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(421, 179)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(22, 15)
        Me.Label17.TabIndex = 1004
        Me.Label17.Text = "円"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(320, 179)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(22, 15)
        Me.Label18.TabIndex = 1002
        Me.Label18.Text = "～"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(292, 179)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(22, 15)
        Me.Label28.TabIndex = 1001
        Me.Label28.Text = "円"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(21, 179)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(196, 15)
        Me.Label14.TabIndex = 999
        Me.Label14.Text = "□請求・返還金額（入金金額）"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(170, 146)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 15)
        Me.Label12.TabIndex = 998
        Me.Label12.Text = "(漢字)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(170, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 15)
        Me.Label5.TabIndex = 997
        Me.Label5.Text = "(カナ)"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(590, 9)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(22, 15)
        Me.Label27.TabIndex = 995
        Me.Label27.Text = "回"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(521, 9)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(22, 15)
        Me.Label24.TabIndex = 993
        Me.Label24.Text = "～"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(501, 9)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(22, 15)
        Me.Label23.TabIndex = 992
        Me.Label23.Text = "回"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(338, 9)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(120, 15)
        Me.Label22.TabIndex = 990
        Me.Label22.Text = "□請求・返還回数"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(381, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 15)
        Me.Label13.TabIndex = 988
        Me.Label13.Text = "～"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(21, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 15)
        Me.Label6.TabIndex = 986
        Me.Label6.Text = "□事務委託先"
        '
        'cobJIMUITAKU_CD
        '
        Me.cobJIMUITAKU_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cobJIMUITAKU_CD.DropDown.AllowDrop = False
        Me.cobJIMUITAKU_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cobJIMUITAKU_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cobJIMUITAKU_CD.Format = "9"
        Me.cobJIMUITAKU_CD.HighlightText = True
        Me.cobJIMUITAKU_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cobJIMUITAKU_CD.ListHeaderPane.Height = 22
        Me.cobJIMUITAKU_CD.Location = New System.Drawing.Point(218, 62)
        Me.cobJIMUITAKU_CD.MaxLength = 3
        Me.cobJIMUITAKU_CD.Name = "cobJIMUITAKU_CD"
        Me.cobJIMUITAKU_CD.Size = New System.Drawing.Size(36, 22)
        Me.cobJIMUITAKU_CD.Spin.AllowSpin = False
        Me.cobJIMUITAKU_CD.TabIndex = 8
        Me.cobJIMUITAKU_CD.Tag = "事務委託先"
        Me.cobJIMUITAKU_CD.Text = "000"
        '
        'cobJIMUITAKU_NM
        '
        Me.cobJIMUITAKU_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobJIMUITAKU_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cobJIMUITAKU_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cobJIMUITAKU_NM.ListHeaderPane.Height = 22
        Me.cobJIMUITAKU_NM.ListHeaderPane.Visible = False
        Me.cobJIMUITAKU_NM.Location = New System.Drawing.Point(258, 62)
        Me.cobJIMUITAKU_NM.Name = "cobJIMUITAKU_NM"
        Me.cobJIMUITAKU_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.cobJIMUITAKU_NM.Size = New System.Drawing.Size(513, 22)
        Me.cobJIMUITAKU_NM.TabIndex = 9
        Me.cobJIMUITAKU_NM.TabStop = False
        Me.cobJIMUITAKU_NM.Tag = "事務委託先名"
        '
        'DropDownButton6
        '
        Me.DropDownButton6.Name = "DropDownButton6"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(21, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 15)
        Me.Label20.TabIndex = 981
        Me.Label20.Text = "■対象期"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(738, 149)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(77, 15)
        Me.Label26.TabIndex = 974
        Me.Label26.Text = "(部分一致)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(738, 123)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 15)
        Me.Label15.TabIndex = 969
        Me.Label15.Text = "(部分一致)"
        '
        'txtKEIYAKUSYA_KANA
        '
        Me.txtKEIYAKUSYA_KANA.DropDown.AllowDrop = False
        Me.txtKEIYAKUSYA_KANA.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txtKEIYAKUSYA_KANA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txtKEIYAKUSYA_KANA.Format = "H"
        Me.txtKEIYAKUSYA_KANA.HighlightText = True
        Me.txtKEIYAKUSYA_KANA.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtKEIYAKUSYA_KANA.Location = New System.Drawing.Point(219, 120)
        Me.txtKEIYAKUSYA_KANA.MaxLength = 50
        Me.txtKEIYAKUSYA_KANA.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txtKEIYAKUSYA_KANA.Name = "txtKEIYAKUSYA_KANA"
        Me.txtKEIYAKUSYA_KANA.Size = New System.Drawing.Size(513, 20)
        Me.txtKEIYAKUSYA_KANA.TabIndex = 11
        Me.txtKEIYAKUSYA_KANA.Text = "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(21, 242)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 15)
        Me.Label10.TabIndex = 965
        Me.Label10.Text = "■処理状況"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(21, 209)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 15)
        Me.Label8.TabIndex = 963
        Me.Label8.Text = "■納付方法"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(21, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 15)
        Me.Label3.TabIndex = 962
        Me.Label3.Text = "□契約者番号"
        '
        'txtKEIYAKUSYA_CD
        '
        Me.txtKEIYAKUSYA_CD.DropDown.AllowDrop = False
        Me.txtKEIYAKUSYA_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txtKEIYAKUSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txtKEIYAKUSYA_CD.Format = "9"
        Me.txtKEIYAKUSYA_CD.HighlightText = True
        Me.txtKEIYAKUSYA_CD.Location = New System.Drawing.Point(219, 91)
        Me.txtKEIYAKUSYA_CD.MaxLength = 5
        Me.txtKEIYAKUSYA_CD.Name = "txtKEIYAKUSYA_CD"
        Me.txtKEIYAKUSYA_CD.Size = New System.Drawing.Size(50, 22)
        Me.txtKEIYAKUSYA_CD.TabIndex = 10
        Me.txtKEIYAKUSYA_CD.Text = "00000"
        '
        'cobKEN_CD_To
        '
        Me.cobKEN_CD_To.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cobKEN_CD_To.DropDown.AllowDrop = False
        Me.cobKEN_CD_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cobKEN_CD_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cobKEN_CD_To.Format = "9"
        Me.cobKEN_CD_To.HighlightText = True
        Me.cobKEN_CD_To.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cobKEN_CD_To.ListHeaderPane.Height = 22
        Me.cobKEN_CD_To.Location = New System.Drawing.Point(405, 33)
        Me.cobKEN_CD_To.MaxLength = 2
        Me.cobKEN_CD_To.Name = "cobKEN_CD_To"
        Me.cobKEN_CD_To.Size = New System.Drawing.Size(36, 22)
        Me.cobKEN_CD_To.Spin.AllowSpin = False
        Me.cobKEN_CD_To.TabIndex = 6
        Me.cobKEN_CD_To.Tag = "都道府県"
        Me.cobKEN_CD_To.Text = "00"
        '
        'cobKEN_NM_To
        '
        Me.cobKEN_NM_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobKEN_NM_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cobKEN_NM_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cobKEN_NM_To.ListHeaderPane.Height = 22
        Me.cobKEN_NM_To.ListHeaderPane.Visible = False
        Me.cobKEN_NM_To.Location = New System.Drawing.Point(445, 33)
        Me.cobKEN_NM_To.Name = "cobKEN_NM_To"
        Me.cobKEN_NM_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.cobKEN_NM_To.Size = New System.Drawing.Size(119, 22)
        Me.cobKEN_NM_To.TabIndex = 7
        Me.cobKEN_NM_To.TabStop = False
        Me.cobKEN_NM_To.Tag = "都道府県名"
        '
        'DropDownButton3
        '
        Me.DropDownButton3.Name = "DropDownButton3"
        '
        'txtKEIYAKUSYA_NAME
        '
        Me.txtKEIYAKUSYA_NAME.DropDown.AllowDrop = False
        Me.txtKEIYAKUSYA_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txtKEIYAKUSYA_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txtKEIYAKUSYA_NAME.Format = "Ｚ"
        Me.txtKEIYAKUSYA_NAME.HighlightText = True
        Me.txtKEIYAKUSYA_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtKEIYAKUSYA_NAME.Location = New System.Drawing.Point(219, 146)
        Me.txtKEIYAKUSYA_NAME.MaxLength = 50
        Me.txtKEIYAKUSYA_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txtKEIYAKUSYA_NAME.Name = "txtKEIYAKUSYA_NAME"
        Me.txtKEIYAKUSYA_NAME.Size = New System.Drawing.Size(513, 20)
        Me.txtKEIYAKUSYA_NAME.TabIndex = 12
        Me.txtKEIYAKUSYA_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(21, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 961
        Me.Label4.Text = "□契約者名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(21, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 959
        Me.Label2.Text = "□都道府県"
        '
        'cobKEN_CD_From
        '
        Me.cobKEN_CD_From.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cobKEN_CD_From.DropDown.AllowDrop = False
        Me.cobKEN_CD_From.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cobKEN_CD_From.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cobKEN_CD_From.Format = "9"
        Me.cobKEN_CD_From.HighlightText = True
        Me.cobKEN_CD_From.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cobKEN_CD_From.ListHeaderPane.Height = 22
        Me.cobKEN_CD_From.Location = New System.Drawing.Point(219, 33)
        Me.cobKEN_CD_From.MaxLength = 2
        Me.cobKEN_CD_From.Name = "cobKEN_CD_From"
        Me.cobKEN_CD_From.Size = New System.Drawing.Size(36, 22)
        Me.cobKEN_CD_From.Spin.AllowSpin = False
        Me.cobKEN_CD_From.TabIndex = 4
        Me.cobKEN_CD_From.Tag = "都道府県"
        Me.cobKEN_CD_From.Text = "00"
        '
        'cobKEN_NM_From
        '
        Me.cobKEN_NM_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobKEN_NM_From.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cobKEN_NM_From.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cobKEN_NM_From.ListHeaderPane.Height = 22
        Me.cobKEN_NM_From.ListHeaderPane.Visible = False
        Me.cobKEN_NM_From.Location = New System.Drawing.Point(258, 33)
        Me.cobKEN_NM_From.Name = "cobKEN_NM_From"
        Me.cobKEN_NM_From.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cobKEN_NM_From.Size = New System.Drawing.Size(119, 22)
        Me.cobKEN_NM_From.TabIndex = 5
        Me.cobKEN_NM_From.TabStop = False
        Me.cobKEN_NM_From.Tag = "都道府県名"
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(24, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(393, 19)
        Me.Label9.TabIndex = 926
        Me.Label9.Text = "契約者積立金　請求・返還　入金・振込　一覧"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(811, 92)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(120, 15)
        Me.Label21.TabIndex = 989
        Me.Label21.Text = "□入金日・振込日"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.Location = New System.Drawing.Point(1042, 453)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(22, 15)
        Me.Label30.TabIndex = 990
        Me.Label30.Text = "件"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmGJ2090
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.dateNYURYOKU_Ymd)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.dgv_Search)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblCOUNT)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label19)
        Me.Name = "frmGJ2090"
        Me.Text = "(GJ2090)契約者積立金等入金・返還入力"
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.cmdSearch, 0)
        Me.Controls.SetChildIndex(Me.cmdClear, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.lblCOUNT, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.dgv_Search, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.dateNYURYOKU_Ymd, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dateNYURYOKU_Ymd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSEIKYU_KAISU_From, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSEIKYU_KAISU_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSEIKYU_KIN_From, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSEIKYU_KIN_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateNYUKIN_Ymd_From, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateNYUKIN_Ymd_To, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cobJIMUITAKU_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cobJIMUITAKU_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKEIYAKUSYA_KANA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cobKEN_CD_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cobKEN_NM_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cobKEN_CD_From, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cobKEN_NM_From, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdKakunin As JBD.Gjs.Win.JButton
    Friend WithEvents dgv_Search As JBD.Gjs.Win.DataGridView
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents lblCOUNT As JBD.Gjs.Win.Label
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents cmdClear As JBD.Gjs.Win.JButton
    Friend WithEvents cmdSearch As JBD.Gjs.Win.JButton
    Friend WithEvents GroupBox1 As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtnSearchOr As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtnSearchAnd As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents Label25 As JBD.Gjs.Win.Label
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label20 As JBD.Gjs.Win.Label
    Friend WithEvents Label26 As JBD.Gjs.Win.Label
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents txtKEIYAKUSYA_KANA As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents cobKEN_CD_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cobKEN_NM_To As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents txtKEIYAKUSYA_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents cobKEN_CD_From As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cobKEN_NM_From As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents Label27 As JBD.Gjs.Win.Label
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents Label23 As JBD.Gjs.Win.Label
    Friend WithEvents numSEIKYU_KAISU_From As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label22 As JBD.Gjs.Win.Label
    Friend WithEvents numKI As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents txtKEIYAKUSYA_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents dateNYURYOKU_Ymd As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton7 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label21 As JBD.Gjs.Win.Label
    Friend WithEvents numSEIKYU_KAISU_To As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents cobJIMUITAKU_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cobJIMUITAKU_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton6 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents Label28 As JBD.Gjs.Win.Label
    Friend WithEvents numSEIKYU_KIN_From As JBD.Gjs.Win.GcNumber
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents numSEIKYU_KIN_To As JBD.Gjs.Win.GcNumber
    Friend WithEvents rbtnHENKAN As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtnNYUKIN As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label29 As JBD.Gjs.Win.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnALL As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtnMI As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtnSUMI As JBD.Gjs.Win.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dateNYUKIN_Ymd_To As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents dateNYUKIN_Ymd_From As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label30 As JBD.Gjs.Win.Label
    Friend WithEvents KEIYAKUSYA_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKUSYA_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKUSYA_KANA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SYORI_JOKYO_KBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SYORI_JOKYO_KBN_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEIKYU_HENKAN_KBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEIKYU_HENKAN_KBN_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEIKYU_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NYUKIN_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEIKYU_KINGAKU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HEMKAN_KINGAKU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEIKYU_KAISU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TUMITATE_KBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NYUKIN_KBN As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
