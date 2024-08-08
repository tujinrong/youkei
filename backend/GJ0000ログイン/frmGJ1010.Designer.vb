Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGJ1010
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
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
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
        Me.KEN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JIMUITAKU_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITAKU_RYAKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NYURYOKU_JYOKYO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblCOUNT = New JBD.Gjs.Win.Label(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdCan = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdSearch = New JBD.Gjs.Win.JButton(Me.components)
        Me.GroupBox1 = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_SearchOr = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_SearchAnd = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdDel = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdUpd = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdIns = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label25 = New JBD.Gjs.Win.Label(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.txt_KI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.cmdKihon = New JBD.Gjs.Win.JButton(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpMikeiyaku = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.chk_Mikeiyaku = New JBD.Gjs.Win.CheckBox(Me.components)
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
        Me.pnlButton.SuspendLayout()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.grpMikeiyaku.SuspendLayout()
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
        Me.pnlButton.Controls.Add(Me.cmdKihon)
        Me.pnlButton.Controls.Add(Me.cmdDel)
        Me.pnlButton.Controls.Add(Me.cmdUpd)
        Me.pnlButton.Controls.Add(Me.cmdIns)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdIns, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdUpd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdDel, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdKihon, 0)
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
        Me.cmdEnd.Location = New System.Drawing.Point(995, 3)
        Me.cmdEnd.TabIndex = 99
        '
        'dgv_Search
        '
        Me.dgv_Search.AllowUserToAddRows = False
        Me.dgv_Search.AllowUserToDeleteRows = False
        Me.dgv_Search.AllowUserToResizeRows = False
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KEIYAKUSYA_CD, Me.KEIYAKUSYA_NAME, Me.KEIYAKUSYA_KANA, Me.KEIYAKU_KBN, Me.KEIYAKU_KBN_NM, Me.KEIYAKU_JYOKYO, Me.KEIYAKU_JYOKYO_NM, Me.ADDR_TEL1, Me.KEN_CD, Me.KEN_NM, Me.JIMUITAKU_CD, Me.ITAKU_RYAKU, Me.NYURYOKU_JYOKYO})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(13, 445)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(1065, 277)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 70
        '
        'KEIYAKUSYA_CD
        '
        Me.KEIYAKUSYA_CD.DataPropertyName = "KEIYAKUSYA_CD"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKUSYA_CD.DefaultCellStyle = DataGridViewCellStyle1
        Me.KEIYAKUSYA_CD.Frozen = True
        Me.KEIYAKUSYA_CD.HeaderText = "契約者番号"
        Me.KEIYAKUSYA_CD.Name = "KEIYAKUSYA_CD"
        Me.KEIYAKUSYA_CD.ReadOnly = True
        Me.KEIYAKUSYA_CD.Width = 90
        '
        'KEIYAKUSYA_NAME
        '
        Me.KEIYAKUSYA_NAME.DataPropertyName = "KEIYAKUSYA_NAME"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKUSYA_NAME.DefaultCellStyle = DataGridViewCellStyle2
        Me.KEIYAKUSYA_NAME.HeaderText = "契約者名"
        Me.KEIYAKUSYA_NAME.Name = "KEIYAKUSYA_NAME"
        Me.KEIYAKUSYA_NAME.ReadOnly = True
        Me.KEIYAKUSYA_NAME.Width = 200
        '
        'KEIYAKUSYA_KANA
        '
        Me.KEIYAKUSYA_KANA.DataPropertyName = "KEIYAKUSYA_KANA"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKUSYA_KANA.DefaultCellStyle = DataGridViewCellStyle3
        Me.KEIYAKUSYA_KANA.HeaderText = "フリガナ"
        Me.KEIYAKUSYA_KANA.Name = "KEIYAKUSYA_KANA"
        Me.KEIYAKUSYA_KANA.ReadOnly = True
        Me.KEIYAKUSYA_KANA.Width = 190
        '
        'KEIYAKU_KBN
        '
        Me.KEIYAKU_KBN.DataPropertyName = "KEIYAKU_KBN"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.KEIYAKU_KBN.DefaultCellStyle = DataGridViewCellStyle4
        Me.KEIYAKU_KBN.HeaderText = "契約区分コード"
        Me.KEIYAKU_KBN.Name = "KEIYAKU_KBN"
        Me.KEIYAKU_KBN.ReadOnly = True
        Me.KEIYAKU_KBN.Visible = False
        Me.KEIYAKU_KBN.Width = 65
        '
        'KEIYAKU_KBN_NM
        '
        Me.KEIYAKU_KBN_NM.DataPropertyName = "KEIYAKU_KBN_NM"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKU_KBN_NM.DefaultCellStyle = DataGridViewCellStyle5
        Me.KEIYAKU_KBN_NM.HeaderText = "契約区分"
        Me.KEIYAKU_KBN_NM.Name = "KEIYAKU_KBN_NM"
        Me.KEIYAKU_KBN_NM.ReadOnly = True
        Me.KEIYAKU_KBN_NM.Width = 80
        '
        'KEIYAKU_JYOKYO
        '
        Me.KEIYAKU_JYOKYO.DataPropertyName = "KEIYAKU_JYOKYO"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKU_JYOKYO.DefaultCellStyle = DataGridViewCellStyle6
        Me.KEIYAKU_JYOKYO.HeaderText = "契約状況コード"
        Me.KEIYAKU_JYOKYO.Name = "KEIYAKU_JYOKYO"
        Me.KEIYAKU_JYOKYO.ReadOnly = True
        Me.KEIYAKU_JYOKYO.Visible = False
        '
        'KEIYAKU_JYOKYO_NM
        '
        Me.KEIYAKU_JYOKYO_NM.DataPropertyName = "KEIYAKU_JYOKYO_NM"
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.KEIYAKU_JYOKYO_NM.DefaultCellStyle = DataGridViewCellStyle7
        Me.KEIYAKU_JYOKYO_NM.HeaderText = "契約状況"
        Me.KEIYAKU_JYOKYO_NM.Name = "KEIYAKU_JYOKYO_NM"
        Me.KEIYAKU_JYOKYO_NM.ReadOnly = True
        Me.KEIYAKU_JYOKYO_NM.Width = 90
        '
        'ADDR_TEL1
        '
        Me.ADDR_TEL1.DataPropertyName = "ADDR_TEL1"
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.KEN_CD.HeaderText = "県コード"
        Me.KEN_CD.Name = "KEN_CD"
        Me.KEN_CD.ReadOnly = True
        Me.KEN_CD.Visible = False
        Me.KEN_CD.Width = 70
        '
        'KEN_NM
        '
        Me.KEN_NM.DataPropertyName = "KEN_NM"
        DataGridViewCellStyle10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.KEN_NM.DefaultCellStyle = DataGridViewCellStyle10
        Me.KEN_NM.HeaderText = "都道府県"
        Me.KEN_NM.Name = "KEN_NM"
        Me.KEN_NM.ReadOnly = True
        Me.KEN_NM.Width = 80
        '
        'JIMUITAKU_CD
        '
        Me.JIMUITAKU_CD.DataPropertyName = "JIMUITAKU_CD"
        DataGridViewCellStyle11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.JIMUITAKU_CD.DefaultCellStyle = DataGridViewCellStyle11
        Me.JIMUITAKU_CD.HeaderText = "委託先コード"
        Me.JIMUITAKU_CD.Name = "JIMUITAKU_CD"
        Me.JIMUITAKU_CD.ReadOnly = True
        Me.JIMUITAKU_CD.Visible = False
        Me.JIMUITAKU_CD.Width = 75
        '
        'ITAKU_RYAKU
        '
        Me.ITAKU_RYAKU.DataPropertyName = "ITAKU_RYAKU"
        DataGridViewCellStyle12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ITAKU_RYAKU.DefaultCellStyle = DataGridViewCellStyle12
        Me.ITAKU_RYAKU.HeaderText = "事務委託先"
        Me.ITAKU_RYAKU.Name = "ITAKU_RYAKU"
        Me.ITAKU_RYAKU.ReadOnly = True
        Me.ITAKU_RYAKU.Width = 195
        '
        'NYURYOKU_JYOKYO
        '
        Me.NYURYOKU_JYOKYO.DataPropertyName = "NYURYOKU_JYOKYO"
        DataGridViewCellStyle13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NYURYOKU_JYOKYO.DefaultCellStyle = DataGridViewCellStyle13
        Me.NYURYOKU_JYOKYO.HeaderText = "入力状況"
        Me.NYURYOKU_JYOKYO.Name = "NYURYOKU_JYOKYO"
        Me.NYURYOKU_JYOKYO.ReadOnly = True
        Me.NYURYOKU_JYOKYO.Visible = False
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
        Me.lblCOUNT.Location = New System.Drawing.Point(992, 413)
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
        Me.Label11.Location = New System.Drawing.Point(919, 413)
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
        Me.cmdCan.Location = New System.Drawing.Point(800, 403)
        Me.cmdCan.Name = "cmdCan"
        Me.cmdCan.Size = New System.Drawing.Size(94, 35)
        Me.cmdCan.TabIndex = 61
        Me.cmdCan.Text = "条件クリア"
        Me.cmdCan.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(688, 403)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(94, 35)
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
        Me.GroupBox1.Location = New System.Drawing.Point(155, 401)
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
        Me.Label19.Location = New System.Drawing.Point(25, 415)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(82, 15)
        Me.Label19.TabIndex = 916
        Me.Label19.Text = "■検索方法"
        '
        'cmdDel
        '
        Me.cmdDel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDel.Location = New System.Drawing.Point(236, 3)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(92, 44)
        Me.cmdDel.TabIndex = 73
        Me.cmdDel.Text = "削除"
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdUpd
        '
        Me.cmdUpd.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdUpd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUpd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdUpd.Location = New System.Drawing.Point(127, 3)
        Me.cmdUpd.Name = "cmdUpd"
        Me.cmdUpd.Size = New System.Drawing.Size(92, 44)
        Me.cmdUpd.TabIndex = 72
        Me.cmdUpd.Text = "変更(表示)"
        Me.cmdUpd.UseVisualStyleBackColor = True
        '
        'cmdIns
        '
        Me.cmdIns.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdIns.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdIns.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIns.Location = New System.Drawing.Point(20, 3)
        Me.cmdIns.Name = "cmdIns"
        Me.cmdIns.Size = New System.Drawing.Size(92, 44)
        Me.cmdIns.TabIndex = 71
        Me.cmdIns.Text = "新規登録"
        Me.cmdIns.UseVisualStyleBackColor = True
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
        'cmdKihon
        '
        Me.cmdKihon.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdKihon.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdKihon.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdKihon.Location = New System.Drawing.Point(711, 3)
        Me.cmdKihon.Name = "cmdKihon"
        Me.cmdKihon.Size = New System.Drawing.Size(121, 44)
        Me.cmdKihon.TabIndex = 75
        Me.cmdKihon.Text = "契約情報登録"
        Me.cmdKihon.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.grpMikeiyaku)
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
        Me.Panel1.Size = New System.Drawing.Size(1046, 317)
        Me.Panel1.TabIndex = 0
        '
        'grpMikeiyaku
        '
        Me.grpMikeiyaku.Controls.Add(Me.chk_Mikeiyaku)
        Me.grpMikeiyaku.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpMikeiyaku.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpMikeiyaku.Location = New System.Drawing.Point(591, 19)
        Me.grpMikeiyaku.Name = "grpMikeiyaku"
        Me.grpMikeiyaku.Size = New System.Drawing.Size(198, 38)
        Me.grpMikeiyaku.TabIndex = 5
        Me.grpMikeiyaku.TabStop = False
        '
        'chk_Mikeiyaku
        '
        Me.chk_Mikeiyaku.AutoSize = True
        Me.chk_Mikeiyaku.Checked = True
        Me.chk_Mikeiyaku.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_Mikeiyaku.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_Mikeiyaku.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chk_Mikeiyaku.Location = New System.Drawing.Point(10, 13)
        Me.chk_Mikeiyaku.Name = "chk_Mikeiyaku"
        Me.chk_Mikeiyaku.Size = New System.Drawing.Size(181, 20)
        Me.chk_Mikeiyaku.TabIndex = 990
        Me.chk_Mikeiyaku.Text = "未継続・未契約者を除く"
        Me.chk_Mikeiyaku.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(317, 37)
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
        Me.cob_JIMUITAKU_CD_T.Location = New System.Drawing.Point(155, 277)
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
        Me.cob_JIMUITAKU_NM_T.Location = New System.Drawing.Point(195, 277)
        Me.cob_JIMUITAKU_NM_T.Name = "cob_JIMUITAKU_NM_T"
        Me.cob_JIMUITAKU_NM_T.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.cob_JIMUITAKU_NM_T.Size = New System.Drawing.Size(513, 22)
        Me.cob_JIMUITAKU_NM_T.TabIndex = 24
        Me.cob_JIMUITAKU_NM_T.TabStop = False
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
        Me.Label6.Location = New System.Drawing.Point(22, 252)
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
        Me.cob_JIMUITAKU_CD_F.Location = New System.Drawing.Point(155, 249)
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
        Me.cob_JIMUITAKU_NM_F.Location = New System.Drawing.Point(195, 249)
        Me.cob_JIMUITAKU_NM_F.Name = "cob_JIMUITAKU_NM_F"
        Me.cob_JIMUITAKU_NM_F.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.cob_JIMUITAKU_NM_F.Size = New System.Drawing.Size(513, 22)
        Me.cob_JIMUITAKU_NM_F.TabIndex = 22
        Me.cob_JIMUITAKU_NM_F.TabStop = False
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
        Me.Label26.Location = New System.Drawing.Point(673, 171)
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
        Me.Label18.Location = New System.Drawing.Point(282, 225)
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
        Me.Label17.Location = New System.Drawing.Point(21, 225)
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
        Me.txt_ADDR_TEL1.Location = New System.Drawing.Point(155, 222)
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
        Me.Label16.Location = New System.Drawing.Point(963, 198)
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
        Me.Label15.Location = New System.Drawing.Point(673, 144)
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
        Me.txt_ADDR.Location = New System.Drawing.Point(155, 195)
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
        Me.Label14.Location = New System.Drawing.Point(21, 198)
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
        Me.txt_KEIYAKUSYA_KANA.Location = New System.Drawing.Point(155, 168)
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
        Me.Label12.Location = New System.Drawing.Point(21, 171)
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
        Me.Label10.Location = New System.Drawing.Point(21, 117)
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
        Me.cob_KEIYAKU_JYOKYO.Location = New System.Drawing.Point(155, 114)
        Me.cob_KEIYAKU_JYOKYO.MaxLength = 1
        Me.cob_KEIYAKU_JYOKYO.Name = "cob_KEIYAKU_JYOKYO"
        Me.cob_KEIYAKU_JYOKYO.Size = New System.Drawing.Size(17, 22)
        Me.cob_KEIYAKU_JYOKYO.Spin.AllowSpin = False
        Me.cob_KEIYAKU_JYOKYO.TabIndex = 13
        Me.cob_KEIYAKU_JYOKYO.Text = "0"
        '
        'cob_KEIYAKU_JYOKYO_NM
        '
        Me.cob_KEIYAKU_JYOKYO_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_KEIYAKU_JYOKYO_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKU_JYOKYO_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKU_JYOKYO_NM.ListHeaderPane.Height = 22
        Me.cob_KEIYAKU_JYOKYO_NM.ListHeaderPane.Visible = False
        Me.cob_KEIYAKU_JYOKYO_NM.Location = New System.Drawing.Point(179, 114)
        Me.cob_KEIYAKU_JYOKYO_NM.Name = "cob_KEIYAKU_JYOKYO_NM"
        Me.cob_KEIYAKU_JYOKYO_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.cob_KEIYAKU_JYOKYO_NM.Size = New System.Drawing.Size(119, 22)
        Me.cob_KEIYAKU_JYOKYO_NM.TabIndex = 14
        Me.cob_KEIYAKU_JYOKYO_NM.TabStop = False
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
        Me.Label8.Location = New System.Drawing.Point(21, 90)
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
        Me.cob_KEIYAKU_KBN.Location = New System.Drawing.Point(155, 87)
        Me.cob_KEIYAKU_KBN.MaxLength = 1
        Me.cob_KEIYAKU_KBN.Name = "cob_KEIYAKU_KBN"
        Me.cob_KEIYAKU_KBN.Size = New System.Drawing.Size(18, 22)
        Me.cob_KEIYAKU_KBN.Spin.AllowSpin = False
        Me.cob_KEIYAKU_KBN.TabIndex = 11
        Me.cob_KEIYAKU_KBN.Text = "0"
        '
        'cob_KEIYAKU_KBN_NM
        '
        Me.cob_KEIYAKU_KBN_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_KEIYAKU_KBN_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKU_KBN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKU_KBN_NM.ListHeaderPane.Height = 22
        Me.cob_KEIYAKU_KBN_NM.ListHeaderPane.Visible = False
        Me.cob_KEIYAKU_KBN_NM.Location = New System.Drawing.Point(179, 87)
        Me.cob_KEIYAKU_KBN_NM.Name = "cob_KEIYAKU_KBN_NM"
        Me.cob_KEIYAKU_KBN_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton4})
        Me.cob_KEIYAKU_KBN_NM.Size = New System.Drawing.Size(119, 22)
        Me.cob_KEIYAKU_KBN_NM.TabIndex = 12
        Me.cob_KEIYAKU_KBN_NM.TabStop = False
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
        Me.Label3.Location = New System.Drawing.Point(21, 63)
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
        Me.txt_KEIYAKUSYA_CD.Location = New System.Drawing.Point(155, 60)
        Me.txt_KEIYAKUSYA_CD.MaxLength = 5
        Me.txt_KEIYAKUSYA_CD.Name = "txt_KEIYAKUSYA_CD"
        Me.txt_KEIYAKUSYA_CD.Size = New System.Drawing.Size(50, 22)
        Me.txt_KEIYAKUSYA_CD.TabIndex = 6
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
        Me.cob_KEN_CD_T.Location = New System.Drawing.Point(341, 33)
        Me.cob_KEN_CD_T.MaxLength = 2
        Me.cob_KEN_CD_T.Name = "cob_KEN_CD_T"
        Me.cob_KEN_CD_T.Size = New System.Drawing.Size(36, 22)
        Me.cob_KEN_CD_T.Spin.AllowSpin = False
        Me.cob_KEN_CD_T.TabIndex = 3
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
        Me.cob_KEN_NM_T.Location = New System.Drawing.Point(381, 33)
        Me.cob_KEN_NM_T.Name = "cob_KEN_NM_T"
        Me.cob_KEN_NM_T.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.cob_KEN_NM_T.Size = New System.Drawing.Size(119, 22)
        Me.cob_KEN_NM_T.TabIndex = 4
        Me.cob_KEN_NM_T.TabStop = False
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
        Me.Label5.Location = New System.Drawing.Point(714, 252)
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
        Me.txt_KEIYAKUSYA_NAME.Location = New System.Drawing.Point(155, 141)
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
        Me.Label4.Location = New System.Drawing.Point(21, 144)
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
        Me.cob_KEN_CD_F.Location = New System.Drawing.Point(155, 33)
        Me.cob_KEN_CD_F.MaxLength = 2
        Me.cob_KEN_CD_F.Name = "cob_KEN_CD_F"
        Me.cob_KEN_CD_F.Size = New System.Drawing.Size(36, 22)
        Me.cob_KEN_CD_F.Spin.AllowSpin = False
        Me.cob_KEN_CD_F.TabIndex = 1
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
        Me.cob_KEN_NM_F.Location = New System.Drawing.Point(194, 33)
        Me.cob_KEN_NM_F.Name = "cob_KEN_NM_F"
        Me.cob_KEN_NM_F.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cob_KEN_NM_F.Size = New System.Drawing.Size(119, 22)
        Me.cob_KEN_NM_F.TabIndex = 2
        Me.cob_KEN_NM_F.TabStop = False
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'frmGJ1010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
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
        Me.Name = "frmGJ1010"
        Me.Text = "(GJ1010)契約者マスタ一覧"
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
        Me.pnlButton.ResumeLayout(False)
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpMikeiyaku.ResumeLayout(False)
        Me.grpMikeiyaku.PerformLayout()
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
    Friend WithEvents cmdDel As JBD.Gjs.Win.JButton
    Friend WithEvents cmdUpd As JBD.Gjs.Win.JButton
    Friend WithEvents cmdIns As JBD.Gjs.Win.JButton
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
    Friend WithEvents cmdKihon As JBD.Gjs.Win.JButton
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
    Friend WithEvents KEIYAKUSYA_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKUSYA_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKUSYA_KANA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_KBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_KBN_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_JYOKYO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_JYOKYO_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR_TEL1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEN_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEN_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JIMUITAKU_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITAKU_RYAKU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NYURYOKU_JYOKYO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grpMikeiyaku As JBD.Gjs.Win.GroupBox
    Friend WithEvents chk_Mikeiyaku As JBD.Gjs.Win.CheckBox
End Class
