Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ4010
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
        Dim DateEraField1 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField1 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField1 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField2 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField1 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField3 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField1 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.KEIYAKUSYA_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKUSYA_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_KBN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_TEL1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEN_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JIMUITAKU_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITAKU_RYAKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HAIGYO_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NYU_HEN_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblCOUNT = New JBD.Gjs.Win.Label(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdCan = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdSearch = New JBD.Gjs.Win.JButton(Me.components)
        Me.GroupBox1 = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_SearchOr = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_SearchAnd = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdSyoukyaku = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdKeieisien = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label25 = New JBD.Gjs.Win.Label(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.txt_KI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_HASSEI_KAISU_Fm = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_KEISAN_KAISU_Fm = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_KEISAN_KAISU_To = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_HASSEI_KAISU_To = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.dateTANKA_MST_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton7 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label23 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label22 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label21 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_JIMUITAKU_CD_T = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_JIMUITAKU_NM_T = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_JIMUITAKU_CD_F = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_JIMUITAKU_NM_F = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton6 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label20 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label26 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_ADDR_TEL1 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_ADDR = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_KEIYAKUSYA_KANA = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KEIYAKU_JYOKYO = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEIYAKU_JYOKYO_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton5 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KEIYAKU_KBN = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEIYAKU_KBN_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_KEIYAKUSYA_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.cob_KEN_CD_T = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEN_NM_T = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_KEIYAKUSYA_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KEN_CD_F = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEN_NM_F = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_HASSEI_KAISU_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KEISAN_KAISU_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KEISAN_KAISU_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_HASSEI_KAISU_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateTANKA_MST_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.cob_JIMUITAKU_CD_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_JIMUITAKU_NM_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_JIMUITAKU_CD_F, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_JIMUITAKU_NM_F, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_TEL1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KEIYAKUSYA_KANA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKU_JYOKYO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKU_JYOKYO_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKU_KBN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKU_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEN_CD_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEN_NM_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEN_CD_F, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEN_NM_F, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdSyoukyaku)
        Me.pnlButton.Controls.Add(Me.cmdKeieisien)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdKeieisien, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSyoukyaku, 0)
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
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KEIYAKUSYA_CD, Me.KEIYAKUSYA_NAME, Me.ADDR, Me.KEIYAKU_KBN, Me.KEIYAKU_KBN_NM, Me.ADDR_TEL1, Me.KEN_CD, Me.KEN_NM, Me.JIMUITAKU_CD, Me.ITAKU_RYAKU, Me.KEIYAKU_DATE, Me.HAIGYO_DATE, Me.NYU_HEN_DATE})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(13, 491)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(1065, 235)
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
        Me.KEIYAKUSYA_NAME.Width = 220
        '
        'ADDR
        '
        Me.ADDR.DataPropertyName = "ADDR"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR.DefaultCellStyle = DataGridViewCellStyle4
        Me.ADDR.HeaderText = "住所"
        Me.ADDR.Name = "ADDR"
        Me.ADDR.ReadOnly = True
        Me.ADDR.Width = 250
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
        Me.KEIYAKU_KBN_NM.Width = 80
        '
        'ADDR_TEL1
        '
        Me.ADDR_TEL1.DataPropertyName = "ADDR_TEL1"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_TEL1.DefaultCellStyle = DataGridViewCellStyle7
        Me.ADDR_TEL1.HeaderText = "電話番号"
        Me.ADDR_TEL1.Name = "ADDR_TEL1"
        Me.ADDR_TEL1.ReadOnly = True
        Me.ADDR_TEL1.Width = 120
        '
        'KEN_CD
        '
        Me.KEN_CD.DataPropertyName = "KEN_CD"
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.KEN_CD.DefaultCellStyle = DataGridViewCellStyle8
        Me.KEN_CD.HeaderText = "県コード"
        Me.KEN_CD.Name = "KEN_CD"
        Me.KEN_CD.ReadOnly = True
        Me.KEN_CD.Visible = False
        Me.KEN_CD.Width = 70
        '
        'KEN_NM
        '
        Me.KEN_NM.DataPropertyName = "KEN_NM"
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.KEN_NM.DefaultCellStyle = DataGridViewCellStyle9
        Me.KEN_NM.HeaderText = "都道府県"
        Me.KEN_NM.Name = "KEN_NM"
        Me.KEN_NM.ReadOnly = True
        Me.KEN_NM.Width = 80
        '
        'JIMUITAKU_CD
        '
        Me.JIMUITAKU_CD.DataPropertyName = "JIMUITAKU_CD"
        DataGridViewCellStyle10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.JIMUITAKU_CD.DefaultCellStyle = DataGridViewCellStyle10
        Me.JIMUITAKU_CD.HeaderText = "委託先コード"
        Me.JIMUITAKU_CD.Name = "JIMUITAKU_CD"
        Me.JIMUITAKU_CD.ReadOnly = True
        Me.JIMUITAKU_CD.Visible = False
        Me.JIMUITAKU_CD.Width = 75
        '
        'ITAKU_RYAKU
        '
        Me.ITAKU_RYAKU.DataPropertyName = "ITAKU_RYAKU"
        DataGridViewCellStyle11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ITAKU_RYAKU.DefaultCellStyle = DataGridViewCellStyle11
        Me.ITAKU_RYAKU.HeaderText = "事務委託先"
        Me.ITAKU_RYAKU.Name = "ITAKU_RYAKU"
        Me.ITAKU_RYAKU.ReadOnly = True
        Me.ITAKU_RYAKU.Width = 205
        '
        'KEIYAKU_DATE
        '
        Me.KEIYAKU_DATE.DataPropertyName = "KEIYAKU_DATE"
        Me.KEIYAKU_DATE.HeaderText = "契約日"
        Me.KEIYAKU_DATE.Name = "KEIYAKU_DATE"
        Me.KEIYAKU_DATE.ReadOnly = True
        Me.KEIYAKU_DATE.Visible = False
        '
        'HAIGYO_DATE
        '
        Me.HAIGYO_DATE.DataPropertyName = "HAIGYO_DATE"
        Me.HAIGYO_DATE.HeaderText = "廃業日"
        Me.HAIGYO_DATE.Name = "HAIGYO_DATE"
        Me.HAIGYO_DATE.ReadOnly = True
        Me.HAIGYO_DATE.Visible = False
        '
        'NYU_HEN_DATE
        '
        Me.NYU_HEN_DATE.DataPropertyName = "NYU_HEN_DATE"
        Me.NYU_HEN_DATE.HeaderText = "入金返還日"
        Me.NYU_HEN_DATE.Name = "NYU_HEN_DATE"
        Me.NYU_HEN_DATE.ReadOnly = True
        Me.NYU_HEN_DATE.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(1054, 456)
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
        Me.lblCOUNT.Location = New System.Drawing.Point(992, 456)
        Me.lblCOUNT.Name = "lblCOUNT"
        Me.lblCOUNT.Size = New System.Drawing.Size(55, 15)
        Me.lblCOUNT.TabIndex = 922
        Me.lblCOUNT.Text = "99999"
        Me.lblCOUNT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(919, 456)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 15)
        Me.Label11.TabIndex = 921
        Me.Label11.Text = "抽出件数："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdCan
        '
        Me.cmdCan.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCan.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCan.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCan.Location = New System.Drawing.Point(800, 443)
        Me.cmdCan.Name = "cmdCan"
        Me.cmdCan.Size = New System.Drawing.Size(94, 44)
        Me.cmdCan.TabIndex = 61
        Me.cmdCan.Text = "条件クリア"
        Me.cmdCan.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(688, 443)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(94, 44)
        Me.cmdSearch.TabIndex = 60
        Me.cmdSearch.Text = "検索"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtn_SearchOr)
        Me.GroupBox1.Controls.Add(Me.rbtn_SearchAnd)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(155, 443)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(339, 38)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        '
        'rbtn_SearchOr
        '
        Me.rbtn_SearchOr.AutoSize = True
        Me.rbtn_SearchOr.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SearchOr.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtn_SearchOr.Location = New System.Drawing.Point(166, 12)
        Me.rbtn_SearchOr.Name = "rbtn_SearchOr"
        Me.rbtn_SearchOr.Size = New System.Drawing.Size(160, 20)
        Me.rbtn_SearchOr.TabIndex = 1
        Me.rbtn_SearchOr.TabStop = True
        Me.rbtn_SearchOr.Text = "いずれかを含む(OR)"
        Me.rbtn_SearchOr.UseVisualStyleBackColor = True
        '
        'rbtn_SearchAnd
        '
        Me.rbtn_SearchAnd.AutoSize = True
        Me.rbtn_SearchAnd.Checked = True
        Me.rbtn_SearchAnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SearchAnd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtn_SearchAnd.Location = New System.Drawing.Point(6, 12)
        Me.rbtn_SearchAnd.Name = "rbtn_SearchAnd"
        Me.rbtn_SearchAnd.Size = New System.Drawing.Size(154, 20)
        Me.rbtn_SearchAnd.TabIndex = 0
        Me.rbtn_SearchAnd.TabStop = True
        Me.rbtn_SearchAnd.Text = "すべてを含む(AND)"
        Me.rbtn_SearchAnd.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(25, 457)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(82, 15)
        Me.Label19.TabIndex = 916
        Me.Label19.Text = "■検索方法"
        '
        'cmdSyoukyaku
        '
        Me.cmdSyoukyaku.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSyoukyaku.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSyoukyaku.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSyoukyaku.Location = New System.Drawing.Point(149, 6)
        Me.cmdSyoukyaku.Name = "cmdSyoukyaku"
        Me.cmdSyoukyaku.Size = New System.Drawing.Size(122, 44)
        Me.cmdSyoukyaku.TabIndex = 72
        Me.cmdSyoukyaku.Text = "焼却・埋却登録"
        Me.cmdSyoukyaku.UseVisualStyleBackColor = True
        '
        'cmdKeieisien
        '
        Me.cmdKeieisien.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdKeieisien.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdKeieisien.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdKeieisien.Location = New System.Drawing.Point(12, 6)
        Me.cmdKeieisien.Name = "cmdKeieisien"
        Me.cmdKeieisien.Size = New System.Drawing.Size(122, 44)
        Me.cmdKeieisien.TabIndex = 71
        Me.cmdKeieisien.Text = "経営支援登録"
        Me.cmdKeieisien.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(33, 53)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(129, 19)
        Me.Label25.TabIndex = 925
        Me.Label25.Text = "検索条件入力"
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
        Me.txt_KI.Location = New System.Drawing.Point(155, 6)
        Me.txt_KI.MaxLength = 2
        Me.txt_KI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KI.Name = "txt_KI"
        Me.GcShortcut1.SetShortcuts(Me.txt_KI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_KI, Object)}, New String() {"ShortcutClear"}))
        Me.txt_KI.Size = New System.Drawing.Size(36, 20)
        Me.txt_KI.TabIndex = 0
        Me.txt_KI.Text = "99"
        '
        'txt_HASSEI_KAISU_Fm
        '
        Me.txt_HASSEI_KAISU_Fm.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_HASSEI_KAISU_Fm.DropDown.AllowDrop = False
        Me.txt_HASSEI_KAISU_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_HASSEI_KAISU_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_HASSEI_KAISU_Fm.Format = "9"
        Me.txt_HASSEI_KAISU_Fm.HighlightText = True
        Me.txt_HASSEI_KAISU_Fm.Location = New System.Drawing.Point(155, 32)
        Me.txt_HASSEI_KAISU_Fm.MaxLength = 2
        Me.txt_HASSEI_KAISU_Fm.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_HASSEI_KAISU_Fm.Name = "txt_HASSEI_KAISU_Fm"
        Me.GcShortcut1.SetShortcuts(Me.txt_HASSEI_KAISU_Fm, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_HASSEI_KAISU_Fm, Object)}, New String() {"ShortcutClear"}))
        Me.txt_HASSEI_KAISU_Fm.Size = New System.Drawing.Size(36, 20)
        Me.txt_HASSEI_KAISU_Fm.TabIndex = 1
        Me.txt_HASSEI_KAISU_Fm.Text = "99"
        '
        'txt_KEISAN_KAISU_Fm
        '
        Me.txt_KEISAN_KAISU_Fm.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_KEISAN_KAISU_Fm.DropDown.AllowDrop = False
        Me.txt_KEISAN_KAISU_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KEISAN_KAISU_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_KEISAN_KAISU_Fm.Format = "9"
        Me.txt_KEISAN_KAISU_Fm.HighlightText = True
        Me.txt_KEISAN_KAISU_Fm.Location = New System.Drawing.Point(155, 56)
        Me.txt_KEISAN_KAISU_Fm.MaxLength = 3
        Me.txt_KEISAN_KAISU_Fm.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KEISAN_KAISU_Fm.Name = "txt_KEISAN_KAISU_Fm"
        Me.GcShortcut1.SetShortcuts(Me.txt_KEISAN_KAISU_Fm, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_KEISAN_KAISU_Fm, Object)}, New String() {"ShortcutClear"}))
        Me.txt_KEISAN_KAISU_Fm.Size = New System.Drawing.Size(36, 20)
        Me.txt_KEISAN_KAISU_Fm.TabIndex = 3
        Me.txt_KEISAN_KAISU_Fm.Text = "999"
        '
        'txt_KEISAN_KAISU_To
        '
        Me.txt_KEISAN_KAISU_To.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_KEISAN_KAISU_To.DropDown.AllowDrop = False
        Me.txt_KEISAN_KAISU_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KEISAN_KAISU_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_KEISAN_KAISU_To.Format = "9"
        Me.txt_KEISAN_KAISU_To.HighlightText = True
        Me.txt_KEISAN_KAISU_To.Location = New System.Drawing.Point(232, 56)
        Me.txt_KEISAN_KAISU_To.MaxLength = 3
        Me.txt_KEISAN_KAISU_To.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KEISAN_KAISU_To.Name = "txt_KEISAN_KAISU_To"
        Me.GcShortcut1.SetShortcuts(Me.txt_KEISAN_KAISU_To, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_KEISAN_KAISU_To, Object)}, New String() {"ShortcutClear"}))
        Me.txt_KEISAN_KAISU_To.Size = New System.Drawing.Size(36, 20)
        Me.txt_KEISAN_KAISU_To.TabIndex = 4
        Me.txt_KEISAN_KAISU_To.Text = "999"
        '
        'txt_HASSEI_KAISU_To
        '
        Me.txt_HASSEI_KAISU_To.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_HASSEI_KAISU_To.DropDown.AllowDrop = False
        Me.txt_HASSEI_KAISU_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_HASSEI_KAISU_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_HASSEI_KAISU_To.Format = "9"
        Me.txt_HASSEI_KAISU_To.HighlightText = True
        Me.txt_HASSEI_KAISU_To.Location = New System.Drawing.Point(232, 32)
        Me.txt_HASSEI_KAISU_To.MaxLength = 2
        Me.txt_HASSEI_KAISU_To.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_HASSEI_KAISU_To.Name = "txt_HASSEI_KAISU_To"
        Me.GcShortcut1.SetShortcuts(Me.txt_HASSEI_KAISU_To, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_HASSEI_KAISU_To, Object)}, New String() {"ShortcutClear"}))
        Me.txt_HASSEI_KAISU_To.Size = New System.Drawing.Size(36, 20)
        Me.txt_HASSEI_KAISU_To.TabIndex = 2
        Me.txt_HASSEI_KAISU_To.Text = "99"
        '
        'dateTANKA_MST_DATE
        '
        Me.dateTANKA_MST_DATE.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.dateTANKA_MST_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.dateTANKA_MST_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateTANKA_MST_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateTANKA_MST_DATE.InputCheck = True
        Me.dateTANKA_MST_DATE.Location = New System.Drawing.Point(935, 55)
        Me.dateTANKA_MST_DATE.Name = "dateTANKA_MST_DATE"
        Me.GcShortcut1.SetShortcuts(Me.dateTANKA_MST_DATE, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateTANKA_MST_DATE, Object), CType(Me.dateTANKA_MST_DATE, Object), CType(Me.dateTANKA_MST_DATE, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateTANKA_MST_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton7})
        Me.dateTANKA_MST_DATE.Size = New System.Drawing.Size(124, 20)
        Me.dateTANKA_MST_DATE.Spin.AllowSpin = False
        Me.dateTANKA_MST_DATE.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateTANKA_MST_DATE.TabIndex = 983
        Me.dateTANKA_MST_DATE.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton7
        '
        Me.DropDownButton7.Name = "DropDownButton7"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txt_KEISAN_KAISU_To)
        Me.Panel1.Controls.Add(Me.txt_HASSEI_KAISU_To)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.txt_KEISAN_KAISU_Fm)
        Me.Panel1.Controls.Add(Me.txt_HASSEI_KAISU_Fm)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.cob_JIMUITAKU_CD_T)
        Me.Panel1.Controls.Add(Me.cob_JIMUITAKU_NM_T)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cob_JIMUITAKU_CD_F)
        Me.Panel1.Controls.Add(Me.cob_JIMUITAKU_NM_F)
        Me.Panel1.Controls.Add(Me.txt_KI)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txt_ADDR_TEL1)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txt_ADDR)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txt_KEIYAKUSYA_KANA)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.cob_KEIYAKU_JYOKYO)
        Me.Panel1.Controls.Add(Me.cob_KEIYAKU_JYOKYO_NM)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.cob_KEIYAKU_KBN)
        Me.Panel1.Controls.Add(Me.cob_KEIYAKU_KBN_NM)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txt_KEIYAKUSYA_CD)
        Me.Panel1.Controls.Add(Me.cob_KEN_CD_T)
        Me.Panel1.Controls.Add(Me.cob_KEN_NM_T)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txt_KEIYAKUSYA_NAME)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cob_KEN_CD_F)
        Me.Panel1.Controls.Add(Me.cob_KEN_NM_F)
        Me.Panel1.Location = New System.Drawing.Point(28, 78)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1046, 362)
        Me.Panel1.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(204, 59)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(22, 15)
        Me.Label23.TabIndex = 994
        Me.Label23.Text = "～"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(204, 35)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(22, 15)
        Me.Label22.TabIndex = 993
        Me.Label22.Text = "～"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(21, 61)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(82, 15)
        Me.Label21.TabIndex = 990
        Me.Label21.Text = "□計算回数"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(21, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 15)
        Me.Label9.TabIndex = 989
        Me.Label9.Text = "□認定回数"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(317, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 15)
        Me.Label13.TabIndex = 988
        Me.Label13.Text = "～"
        '
        'cob_JIMUITAKU_CD_T
        '
        Me.cob_JIMUITAKU_CD_T.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_JIMUITAKU_CD_T.DropDown.AllowDrop = False
        Me.cob_JIMUITAKU_CD_T.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_JIMUITAKU_CD_T.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_JIMUITAKU_CD_T.Format = "9"
        Me.cob_JIMUITAKU_CD_T.HighlightText = True
        Me.cob_JIMUITAKU_CD_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_JIMUITAKU_CD_T.ListHeaderPane.Height = 22
        Me.cob_JIMUITAKU_CD_T.Location = New System.Drawing.Point(155, 327)
        Me.cob_JIMUITAKU_CD_T.MaxLength = 3
        Me.cob_JIMUITAKU_CD_T.Name = "cob_JIMUITAKU_CD_T"
        Me.cob_JIMUITAKU_CD_T.Size = New System.Drawing.Size(36, 22)
        Me.cob_JIMUITAKU_CD_T.Spin.AllowSpin = False
        Me.cob_JIMUITAKU_CD_T.TabIndex = 23
        Me.cob_JIMUITAKU_CD_T.Tag = "事務委託先"
        Me.cob_JIMUITAKU_CD_T.Text = "000"
        '
        'cob_JIMUITAKU_NM_T
        '
        Me.cob_JIMUITAKU_NM_T.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_JIMUITAKU_NM_T.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_JIMUITAKU_NM_T.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_JIMUITAKU_NM_T.ListHeaderPane.Height = 22
        Me.cob_JIMUITAKU_NM_T.ListHeaderPane.Visible = False
        Me.cob_JIMUITAKU_NM_T.Location = New System.Drawing.Point(195, 327)
        Me.cob_JIMUITAKU_NM_T.Name = "cob_JIMUITAKU_NM_T"
        Me.cob_JIMUITAKU_NM_T.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.cob_JIMUITAKU_NM_T.Size = New System.Drawing.Size(513, 22)
        Me.cob_JIMUITAKU_NM_T.TabIndex = 24
        Me.cob_JIMUITAKU_NM_T.TabStop = False
        Me.cob_JIMUITAKU_NM_T.Tag = "事務委託先名"
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(22, 302)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 15)
        Me.Label6.TabIndex = 986
        Me.Label6.Text = "□事務委託先"
        '
        'cob_JIMUITAKU_CD_F
        '
        Me.cob_JIMUITAKU_CD_F.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_JIMUITAKU_CD_F.DropDown.AllowDrop = False
        Me.cob_JIMUITAKU_CD_F.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_JIMUITAKU_CD_F.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_JIMUITAKU_CD_F.Format = "9"
        Me.cob_JIMUITAKU_CD_F.HighlightText = True
        Me.cob_JIMUITAKU_CD_F.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_JIMUITAKU_CD_F.ListHeaderPane.Height = 22
        Me.cob_JIMUITAKU_CD_F.Location = New System.Drawing.Point(155, 299)
        Me.cob_JIMUITAKU_CD_F.MaxLength = 3
        Me.cob_JIMUITAKU_CD_F.Name = "cob_JIMUITAKU_CD_F"
        Me.cob_JIMUITAKU_CD_F.Size = New System.Drawing.Size(36, 22)
        Me.cob_JIMUITAKU_CD_F.Spin.AllowSpin = False
        Me.cob_JIMUITAKU_CD_F.TabIndex = 21
        Me.cob_JIMUITAKU_CD_F.Tag = "事務委託先"
        Me.cob_JIMUITAKU_CD_F.Text = "000"
        '
        'cob_JIMUITAKU_NM_F
        '
        Me.cob_JIMUITAKU_NM_F.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_JIMUITAKU_NM_F.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_JIMUITAKU_NM_F.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_JIMUITAKU_NM_F.ListHeaderPane.Height = 22
        Me.cob_JIMUITAKU_NM_F.ListHeaderPane.Visible = False
        Me.cob_JIMUITAKU_NM_F.Location = New System.Drawing.Point(195, 299)
        Me.cob_JIMUITAKU_NM_F.Name = "cob_JIMUITAKU_NM_F"
        Me.cob_JIMUITAKU_NM_F.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.cob_JIMUITAKU_NM_F.Size = New System.Drawing.Size(513, 22)
        Me.cob_JIMUITAKU_NM_F.TabIndex = 22
        Me.cob_JIMUITAKU_NM_F.TabStop = False
        Me.cob_JIMUITAKU_NM_F.Tag = "事務委託先名"
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
        Me.Label20.Location = New System.Drawing.Point(22, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(37, 15)
        Me.Label20.TabIndex = 981
        Me.Label20.Text = "■期"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(673, 221)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(77, 15)
        Me.Label26.TabIndex = 974
        Me.Label26.Text = "(部分一致)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(282, 275)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 15)
        Me.Label18.TabIndex = 972
        Me.Label18.Text = "(全一致)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(22, 275)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(82, 15)
        Me.Label17.TabIndex = 971
        Me.Label17.Text = "□電話番号"
        '
        'txt_ADDR_TEL1
        '
        Me.txt_ADDR_TEL1.DropDown.AllowDrop = False
        Me.txt_ADDR_TEL1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_TEL1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_TEL1.Format = "9"
        Me.txt_ADDR_TEL1.HighlightText = True
        Me.txt_ADDR_TEL1.Location = New System.Drawing.Point(155, 272)
        Me.txt_ADDR_TEL1.MaxLength = 14
        Me.txt_ADDR_TEL1.Name = "txt_ADDR_TEL1"
        Me.txt_ADDR_TEL1.Size = New System.Drawing.Size(122, 22)
        Me.txt_ADDR_TEL1.TabIndex = 18
        Me.txt_ADDR_TEL1.Text = "00000000000000"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(963, 246)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 15)
        Me.Label16.TabIndex = 970
        Me.Label16.Text = "(部分一致)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(673, 194)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 15)
        Me.Label15.TabIndex = 969
        Me.Label15.Text = "(部分一致)"
        '
        'txt_ADDR
        '
        Me.txt_ADDR.DropDown.AllowDrop = False
        Me.txt_ADDR.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR.Format = "Ｚ"
        Me.txt_ADDR.HighlightText = True
        Me.txt_ADDR.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ADDR.Location = New System.Drawing.Point(155, 245)
        Me.txt_ADDR.MaxLength = 108
        Me.txt_ADDR.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR.Name = "txt_ADDR"
        Me.txt_ADDR.Size = New System.Drawing.Size(802, 20)
        Me.txt_ADDR.TabIndex = 17
        Me.txt_ADDR.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(22, 248)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 15)
        Me.Label14.TabIndex = 968
        Me.Label14.Text = "□住所"
        '
        'txt_KEIYAKUSYA_KANA
        '
        Me.txt_KEIYAKUSYA_KANA.DropDown.AllowDrop = False
        Me.txt_KEIYAKUSYA_KANA.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KEIYAKUSYA_KANA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_KEIYAKUSYA_KANA.Format = "H"
        Me.txt_KEIYAKUSYA_KANA.HighlightText = True
        Me.txt_KEIYAKUSYA_KANA.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_KEIYAKUSYA_KANA.Location = New System.Drawing.Point(155, 218)
        Me.txt_KEIYAKUSYA_KANA.MaxLength = 50
        Me.txt_KEIYAKUSYA_KANA.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KEIYAKUSYA_KANA.Name = "txt_KEIYAKUSYA_KANA"
        Me.txt_KEIYAKUSYA_KANA.Size = New System.Drawing.Size(513, 20)
        Me.txt_KEIYAKUSYA_KANA.TabIndex = 16
        Me.txt_KEIYAKUSYA_KANA.Text = "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(21, 221)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 15)
        Me.Label12.TabIndex = 966
        Me.Label12.Text = "□契約者名(ﾌﾘｶﾞﾅ)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(21, 167)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 15)
        Me.Label10.TabIndex = 965
        Me.Label10.Text = "□契約状況"
        '
        'cob_KEIYAKU_JYOKYO
        '
        Me.cob_KEIYAKU_JYOKYO.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_KEIYAKU_JYOKYO.DropDown.AllowDrop = False
        Me.cob_KEIYAKU_JYOKYO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKU_JYOKYO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKU_JYOKYO.Format = "9"
        Me.cob_KEIYAKU_JYOKYO.HighlightText = True
        Me.cob_KEIYAKU_JYOKYO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_KEIYAKU_JYOKYO.ListHeaderPane.Height = 22
        Me.cob_KEIYAKU_JYOKYO.Location = New System.Drawing.Point(155, 164)
        Me.cob_KEIYAKU_JYOKYO.MaxLength = 1
        Me.cob_KEIYAKU_JYOKYO.Name = "cob_KEIYAKU_JYOKYO"
        Me.cob_KEIYAKU_JYOKYO.Size = New System.Drawing.Size(18, 22)
        Me.cob_KEIYAKU_JYOKYO.Spin.AllowSpin = False
        Me.cob_KEIYAKU_JYOKYO.TabIndex = 12
        Me.cob_KEIYAKU_JYOKYO.Tag = "契約状況"
        Me.cob_KEIYAKU_JYOKYO.Text = "0"
        '
        'cob_KEIYAKU_JYOKYO_NM
        '
        Me.cob_KEIYAKU_JYOKYO_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_KEIYAKU_JYOKYO_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKU_JYOKYO_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKU_JYOKYO_NM.ListHeaderPane.Height = 22
        Me.cob_KEIYAKU_JYOKYO_NM.ListHeaderPane.Visible = False
        Me.cob_KEIYAKU_JYOKYO_NM.Location = New System.Drawing.Point(179, 164)
        Me.cob_KEIYAKU_JYOKYO_NM.Name = "cob_KEIYAKU_JYOKYO_NM"
        Me.cob_KEIYAKU_JYOKYO_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.cob_KEIYAKU_JYOKYO_NM.Size = New System.Drawing.Size(119, 22)
        Me.cob_KEIYAKU_JYOKYO_NM.TabIndex = 13
        Me.cob_KEIYAKU_JYOKYO_NM.TabStop = False
        Me.cob_KEIYAKU_JYOKYO_NM.Tag = "契約状況名"
        '
        'DropDownButton5
        '
        Me.DropDownButton5.Name = "DropDownButton5"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(21, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 15)
        Me.Label8.TabIndex = 963
        Me.Label8.Text = "□契約区分"
        '
        'cob_KEIYAKU_KBN
        '
        Me.cob_KEIYAKU_KBN.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_KEIYAKU_KBN.DropDown.AllowDrop = False
        Me.cob_KEIYAKU_KBN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKU_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKU_KBN.Format = "9"
        Me.cob_KEIYAKU_KBN.HighlightText = True
        Me.cob_KEIYAKU_KBN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_KEIYAKU_KBN.ListHeaderPane.Height = 22
        Me.cob_KEIYAKU_KBN.Location = New System.Drawing.Point(155, 137)
        Me.cob_KEIYAKU_KBN.MaxLength = 1
        Me.cob_KEIYAKU_KBN.Name = "cob_KEIYAKU_KBN"
        Me.cob_KEIYAKU_KBN.Size = New System.Drawing.Size(18, 22)
        Me.cob_KEIYAKU_KBN.Spin.AllowSpin = False
        Me.cob_KEIYAKU_KBN.TabIndex = 10
        Me.cob_KEIYAKU_KBN.Tag = "契約区分"
        Me.cob_KEIYAKU_KBN.Text = "0"
        '
        'cob_KEIYAKU_KBN_NM
        '
        Me.cob_KEIYAKU_KBN_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_KEIYAKU_KBN_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKU_KBN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKU_KBN_NM.ListHeaderPane.Height = 22
        Me.cob_KEIYAKU_KBN_NM.ListHeaderPane.Visible = False
        Me.cob_KEIYAKU_KBN_NM.Location = New System.Drawing.Point(179, 137)
        Me.cob_KEIYAKU_KBN_NM.Name = "cob_KEIYAKU_KBN_NM"
        Me.cob_KEIYAKU_KBN_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton4})
        Me.cob_KEIYAKU_KBN_NM.Size = New System.Drawing.Size(119, 22)
        Me.cob_KEIYAKU_KBN_NM.TabIndex = 11
        Me.cob_KEIYAKU_KBN_NM.TabStop = False
        Me.cob_KEIYAKU_KBN_NM.Tag = "契約区分名"
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(21, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 15)
        Me.Label3.TabIndex = 962
        Me.Label3.Text = "□契約者番号"
        '
        'txt_KEIYAKUSYA_CD
        '
        Me.txt_KEIYAKUSYA_CD.DropDown.AllowDrop = False
        Me.txt_KEIYAKUSYA_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KEIYAKUSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_KEIYAKUSYA_CD.Format = "9"
        Me.txt_KEIYAKUSYA_CD.HighlightText = True
        Me.txt_KEIYAKUSYA_CD.Location = New System.Drawing.Point(155, 110)
        Me.txt_KEIYAKUSYA_CD.MaxLength = 5
        Me.txt_KEIYAKUSYA_CD.Name = "txt_KEIYAKUSYA_CD"
        Me.txt_KEIYAKUSYA_CD.Size = New System.Drawing.Size(50, 22)
        Me.txt_KEIYAKUSYA_CD.TabIndex = 9
        Me.txt_KEIYAKUSYA_CD.Text = "00000"
        '
        'cob_KEN_CD_T
        '
        Me.cob_KEN_CD_T.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_KEN_CD_T.DropDown.AllowDrop = False
        Me.cob_KEN_CD_T.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEN_CD_T.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEN_CD_T.Format = "9"
        Me.cob_KEN_CD_T.HighlightText = True
        Me.cob_KEN_CD_T.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_KEN_CD_T.ListHeaderPane.Height = 22
        Me.cob_KEN_CD_T.Location = New System.Drawing.Point(341, 83)
        Me.cob_KEN_CD_T.MaxLength = 2
        Me.cob_KEN_CD_T.Name = "cob_KEN_CD_T"
        Me.cob_KEN_CD_T.Size = New System.Drawing.Size(36, 22)
        Me.cob_KEN_CD_T.Spin.AllowSpin = False
        Me.cob_KEN_CD_T.TabIndex = 7
        Me.cob_KEN_CD_T.Tag = "都道府県"
        Me.cob_KEN_CD_T.Text = "00"
        '
        'cob_KEN_NM_T
        '
        Me.cob_KEN_NM_T.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_KEN_NM_T.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEN_NM_T.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEN_NM_T.ListHeaderPane.Height = 22
        Me.cob_KEN_NM_T.ListHeaderPane.Visible = False
        Me.cob_KEN_NM_T.Location = New System.Drawing.Point(381, 83)
        Me.cob_KEN_NM_T.Name = "cob_KEN_NM_T"
        Me.cob_KEN_NM_T.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.cob_KEN_NM_T.Size = New System.Drawing.Size(119, 22)
        Me.cob_KEN_NM_T.TabIndex = 8
        Me.cob_KEN_NM_T.TabStop = False
        Me.cob_KEN_NM_T.Tag = "都道府県名"
        '
        'DropDownButton3
        '
        Me.DropDownButton3.Name = "DropDownButton3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(714, 302)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 15)
        Me.Label5.TabIndex = 960
        Me.Label5.Text = "～"
        '
        'txt_KEIYAKUSYA_NAME
        '
        Me.txt_KEIYAKUSYA_NAME.DropDown.AllowDrop = False
        Me.txt_KEIYAKUSYA_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KEIYAKUSYA_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_KEIYAKUSYA_NAME.Format = "Ｚ"
        Me.txt_KEIYAKUSYA_NAME.HighlightText = True
        Me.txt_KEIYAKUSYA_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_KEIYAKUSYA_NAME.Location = New System.Drawing.Point(155, 191)
        Me.txt_KEIYAKUSYA_NAME.MaxLength = 50
        Me.txt_KEIYAKUSYA_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KEIYAKUSYA_NAME.Name = "txt_KEIYAKUSYA_NAME"
        Me.txt_KEIYAKUSYA_NAME.Size = New System.Drawing.Size(513, 20)
        Me.txt_KEIYAKUSYA_NAME.TabIndex = 15
        Me.txt_KEIYAKUSYA_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(21, 194)
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
        Me.Label2.Location = New System.Drawing.Point(21, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 959
        Me.Label2.Text = "□都道府県"
        '
        'cob_KEN_CD_F
        '
        Me.cob_KEN_CD_F.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_KEN_CD_F.DropDown.AllowDrop = False
        Me.cob_KEN_CD_F.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEN_CD_F.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEN_CD_F.Format = "9"
        Me.cob_KEN_CD_F.HighlightText = True
        Me.cob_KEN_CD_F.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_KEN_CD_F.ListHeaderPane.Height = 22
        Me.cob_KEN_CD_F.Location = New System.Drawing.Point(155, 83)
        Me.cob_KEN_CD_F.MaxLength = 2
        Me.cob_KEN_CD_F.Name = "cob_KEN_CD_F"
        Me.cob_KEN_CD_F.Size = New System.Drawing.Size(36, 22)
        Me.cob_KEN_CD_F.Spin.AllowSpin = False
        Me.cob_KEN_CD_F.TabIndex = 5
        Me.cob_KEN_CD_F.Tag = "都道府県"
        Me.cob_KEN_CD_F.Text = "00"
        '
        'cob_KEN_NM_F
        '
        Me.cob_KEN_NM_F.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_KEN_NM_F.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEN_NM_F.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEN_NM_F.ListHeaderPane.Height = 22
        Me.cob_KEN_NM_F.ListHeaderPane.Visible = False
        Me.cob_KEN_NM_F.Location = New System.Drawing.Point(194, 83)
        Me.cob_KEN_NM_F.Name = "cob_KEN_NM_F"
        Me.cob_KEN_NM_F.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cob_KEN_NM_F.Size = New System.Drawing.Size(119, 22)
        Me.cob_KEN_NM_F.TabIndex = 6
        Me.cob_KEN_NM_F.TabStop = False
        Me.cob_KEN_NM_F.Tag = "都道府県名"
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(738, 58)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(191, 15)
        Me.Label24.TabIndex = 982
        Me.Label24.Text = "■互助金単価マスタ　参照日"
        '
        'frmGJ4010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.dateTANKA_MST_DATE)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.dgv_Search)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblCOUNT)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmdCan)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label19)
        Me.Name = "frmGJ4010"
        Me.Text = "(GJ4010)互助金申請情報一覧"
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.cmdSearch, 0)
        Me.Controls.SetChildIndex(Me.cmdCan, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.lblCOUNT, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.dgv_Search, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.dateTANKA_MST_DATE, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_HASSEI_KAISU_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KEISAN_KAISU_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KEISAN_KAISU_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_HASSEI_KAISU_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateTANKA_MST_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cob_JIMUITAKU_CD_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_JIMUITAKU_NM_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_JIMUITAKU_CD_F, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_JIMUITAKU_NM_F, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_TEL1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KEIYAKUSYA_KANA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKU_JYOKYO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKU_JYOKYO_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKU_KBN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKU_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEN_CD_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEN_NM_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEN_CD_F, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEN_NM_F, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSyoukyaku As JBD.Gjs.Win.JButton
    Friend WithEvents cmdKeieisien As JBD.Gjs.Win.JButton
    Friend WithEvents dgv_Search As JBD.Gjs.Win.DataGridView
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents lblCOUNT As JBD.Gjs.Win.Label
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents cmdCan As JBD.Gjs.Win.JButton
    Friend WithEvents cmdSearch As JBD.Gjs.Win.JButton
    Friend WithEvents GroupBox1 As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtn_SearchOr As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_SearchAnd As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents Label25 As JBD.Gjs.Win.Label
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_KI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label20 As JBD.Gjs.Win.Label
    Friend WithEvents Label26 As JBD.Gjs.Win.Label
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents txt_ADDR_TEL1 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents txt_ADDR As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KEIYAKUSYA_KANA As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KEIYAKU_JYOKYO As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEIYAKU_JYOKYO_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton5 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KEIYAKU_KBN As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEIYAKU_KBN_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KEIYAKUSYA_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents cob_KEN_CD_T As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEN_NM_T As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KEIYAKUSYA_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KEN_CD_F As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEN_NM_F As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents cob_JIMUITAKU_CD_T As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_JIMUITAKU_NM_T As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents cob_JIMUITAKU_CD_F As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_JIMUITAKU_NM_F As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton6 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KEISAN_KAISU_To As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_HASSEI_KAISU_To As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label23 As JBD.Gjs.Win.Label
    Friend WithEvents Label22 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KEISAN_KAISU_Fm As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_HASSEI_KAISU_Fm As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label21 As JBD.Gjs.Win.Label
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents dateTANKA_MST_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton7 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents KEIYAKUSYA_CD As DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKUSYA_NAME As DataGridViewTextBoxColumn
    Friend WithEvents ADDR As DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_KBN As DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_KBN_NM As DataGridViewTextBoxColumn
    Friend WithEvents ADDR_TEL1 As DataGridViewTextBoxColumn
    Friend WithEvents KEN_CD As DataGridViewTextBoxColumn
    Friend WithEvents KEN_NM As DataGridViewTextBoxColumn
    Friend WithEvents JIMUITAKU_CD As DataGridViewTextBoxColumn
    Friend WithEvents ITAKU_RYAKU As DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_DATE As DataGridViewTextBoxColumn
    Friend WithEvents HAIGYO_DATE As DataGridViewTextBoxColumn
    Friend WithEvents NYU_HEN_DATE As DataGridViewTextBoxColumn
End Class
