Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ8050
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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_BANK_KANA = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_BANK_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_BANK_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.grpDATAKBN = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_DATA_KBN2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_DATA_KBN1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.lbl_BANK_NAME = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_BANK_KANA = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_BANK_CD = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_DATA_KBN1 = New JBD.Gjs.Win.Label(Me.components)
        Me.rbtn_Search1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_Search2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdSearch = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdCan = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdIns = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdUpd = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdDel = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdPreview = New JBD.Gjs.Win.JButton(Me.components)
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.DATA_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEN_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEN_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KIKINKYOKAI_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblCOUNT = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.grpSEARCH = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdPreview2 = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdDel2 = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdUpd2 = New JBD.Gjs.Win.JButton(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txt_SITEN_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_SITEN_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_SITEN_KANA = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.grpDATAKBN2 = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_DATA_KBN4 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_DATA_KBN3 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.lbl_SITEN_NAME = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_SITEN_KANA = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_SITEN_CD = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_DATA_KBN3 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdIns2 = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdCan2 = New JBD.Gjs.Win.JButton(Me.components)
        Me.lblCOUNT2 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdSearch2 = New JBD.Gjs.Win.JButton(Me.components)
        Me.dgv_Search2 = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.grpSEARCH2 = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_Search4 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_Search3 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label1 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txt_BANK_KANA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_BANK_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_BANK_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDATAKBN.SuspendLayout()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSEARCH.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.txt_SITEN_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SITEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SITEN_KANA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDATAKBN2.SuspendLayout()
        CType(Me.dgv_Search2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSEARCH2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = "金融機関マスタ保守一覧"
        '
        'pnlButton
        '
        Me.pnlButton.Location = New System.Drawing.Point(0, 744)
        '
        'cmdEnd
        '
        Me.cmdEnd.TabIndex = 26
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.CausesValidation = False
        Me.Panel1.Controls.Add(Me.txt_BANK_KANA)
        Me.Panel1.Controls.Add(Me.txt_BANK_NAME)
        Me.Panel1.Controls.Add(Me.txt_BANK_CD)
        Me.Panel1.Controls.Add(Me.grpDATAKBN)
        Me.Panel1.Controls.Add(Me.lbl_BANK_NAME)
        Me.Panel1.Controls.Add(Me.lbl_BANK_KANA)
        Me.Panel1.Controls.Add(Me.lbl_BANK_CD)
        Me.Panel1.Controls.Add(Me.lbl_DATA_KBN1)
        Me.Panel1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Panel1.Location = New System.Drawing.Point(30, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1038, 105)
        Me.Panel1.TabIndex = 0
        '
        'txt_BANK_KANA
        '
        Me.txt_BANK_KANA.DropDown.AllowDrop = False
        Me.txt_BANK_KANA.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_BANK_KANA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_BANK_KANA.Format = "AaK9@"
        Me.txt_BANK_KANA.HighlightText = True
        Me.txt_BANK_KANA.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_BANK_KANA.Location = New System.Drawing.Point(176, 40)
        Me.txt_BANK_KANA.MaxLength = 60
        Me.txt_BANK_KANA.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_BANK_KANA.Name = "txt_BANK_KANA"
        Me.txt_BANK_KANA.Size = New System.Drawing.Size(632, 22)
        Me.txt_BANK_KANA.TabIndex = 3
        Me.txt_BANK_KANA.Text = "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
        '
        'txt_BANK_NAME
        '
        Me.txt_BANK_NAME.DropDown.AllowDrop = False
        Me.txt_BANK_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_BANK_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_BANK_NAME.HighlightText = True
        Me.txt_BANK_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_BANK_NAME.Location = New System.Drawing.Point(176, 68)
        Me.txt_BANK_NAME.MaxLength = 30
        Me.txt_BANK_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_BANK_NAME.Name = "txt_BANK_NAME"
        Me.txt_BANK_NAME.Size = New System.Drawing.Size(331, 22)
        Me.txt_BANK_NAME.TabIndex = 4
        Me.txt_BANK_NAME.Text = "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
        '
        'txt_BANK_CD
        '
        Me.txt_BANK_CD.DropDown.AllowDrop = False
        Me.txt_BANK_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_BANK_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_BANK_CD.Format = "#"
        Me.txt_BANK_CD.HighlightText = True
        Me.txt_BANK_CD.Location = New System.Drawing.Point(176, 12)
        Me.txt_BANK_CD.MaxLength = 4
        Me.txt_BANK_CD.Name = "txt_BANK_CD"
        Me.txt_BANK_CD.Size = New System.Drawing.Size(45, 22)
        Me.txt_BANK_CD.TabIndex = 2
        Me.txt_BANK_CD.Text = "0000"
        '
        'grpDATAKBN
        '
        Me.grpDATAKBN.Controls.Add(Me.rbtn_DATA_KBN2)
        Me.grpDATAKBN.Controls.Add(Me.rbtn_DATA_KBN1)
        Me.grpDATAKBN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grpDATAKBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpDATAKBN.Location = New System.Drawing.Point(843, 3)
        Me.grpDATAKBN.Name = "grpDATAKBN"
        Me.grpDATAKBN.Size = New System.Drawing.Size(159, 38)
        Me.grpDATAKBN.TabIndex = 0
        Me.grpDATAKBN.TabStop = False
        Me.grpDATAKBN.Visible = False
        '
        'rbtn_DATA_KBN2
        '
        Me.rbtn_DATA_KBN2.AutoSize = True
        Me.rbtn_DATA_KBN2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_DATA_KBN2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_DATA_KBN2.Location = New System.Drawing.Point(83, 12)
        Me.rbtn_DATA_KBN2.Name = "rbtn_DATA_KBN2"
        Me.rbtn_DATA_KBN2.Size = New System.Drawing.Size(61, 20)
        Me.rbtn_DATA_KBN2.TabIndex = 1
        Me.rbtn_DATA_KBN2.Text = "無効"
        Me.rbtn_DATA_KBN2.UseVisualStyleBackColor = True
        '
        'rbtn_DATA_KBN1
        '
        Me.rbtn_DATA_KBN1.AutoSize = True
        Me.rbtn_DATA_KBN1.Checked = True
        Me.rbtn_DATA_KBN1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_DATA_KBN1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_DATA_KBN1.Location = New System.Drawing.Point(6, 12)
        Me.rbtn_DATA_KBN1.Name = "rbtn_DATA_KBN1"
        Me.rbtn_DATA_KBN1.Size = New System.Drawing.Size(61, 20)
        Me.rbtn_DATA_KBN1.TabIndex = 0
        Me.rbtn_DATA_KBN1.TabStop = True
        Me.rbtn_DATA_KBN1.Text = "有効"
        Me.rbtn_DATA_KBN1.UseVisualStyleBackColor = True
        '
        'lbl_BANK_NAME
        '
        Me.lbl_BANK_NAME.AutoSize = True
        Me.lbl_BANK_NAME.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_BANK_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_BANK_NAME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_BANK_NAME.Location = New System.Drawing.Point(20, 68)
        Me.lbl_BANK_NAME.Name = "lbl_BANK_NAME"
        Me.lbl_BANK_NAME.Size = New System.Drawing.Size(143, 15)
        Me.lbl_BANK_NAME.TabIndex = 906
        Me.lbl_BANK_NAME.Text = "□金融機関名（漢字）"
        '
        'lbl_BANK_KANA
        '
        Me.lbl_BANK_KANA.AutoSize = True
        Me.lbl_BANK_KANA.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_BANK_KANA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_BANK_KANA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_BANK_KANA.Location = New System.Drawing.Point(20, 42)
        Me.lbl_BANK_KANA.Name = "lbl_BANK_KANA"
        Me.lbl_BANK_KANA.Size = New System.Drawing.Size(130, 15)
        Me.lbl_BANK_KANA.TabIndex = 894
        Me.lbl_BANK_KANA.Text = "□金融機関名（ｶﾅ）"
        '
        'lbl_BANK_CD
        '
        Me.lbl_BANK_CD.AutoSize = True
        Me.lbl_BANK_CD.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_BANK_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_BANK_CD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_BANK_CD.Location = New System.Drawing.Point(20, 15)
        Me.lbl_BANK_CD.Name = "lbl_BANK_CD"
        Me.lbl_BANK_CD.Size = New System.Drawing.Size(119, 15)
        Me.lbl_BANK_CD.TabIndex = 887
        Me.lbl_BANK_CD.Text = "□金融機関コード"
        '
        'lbl_DATA_KBN1
        '
        Me.lbl_DATA_KBN1.AutoSize = True
        Me.lbl_DATA_KBN1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_DATA_KBN1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_DATA_KBN1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_DATA_KBN1.Location = New System.Drawing.Point(746, 16)
        Me.lbl_DATA_KBN1.Name = "lbl_DATA_KBN1"
        Me.lbl_DATA_KBN1.Size = New System.Drawing.Size(91, 15)
        Me.lbl_DATA_KBN1.TabIndex = 884
        Me.lbl_DATA_KBN1.Text = "■データ区分"
        Me.lbl_DATA_KBN1.Visible = False
        '
        'rbtn_Search1
        '
        Me.rbtn_Search1.AutoSize = True
        Me.rbtn_Search1.Checked = True
        Me.rbtn_Search1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_Search1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtn_Search1.Location = New System.Drawing.Point(6, 12)
        Me.rbtn_Search1.Name = "rbtn_Search1"
        Me.rbtn_Search1.Size = New System.Drawing.Size(154, 20)
        Me.rbtn_Search1.TabIndex = 5
        Me.rbtn_Search1.TabStop = True
        Me.rbtn_Search1.Text = "すべてを含む(AND)"
        Me.rbtn_Search1.UseVisualStyleBackColor = True
        '
        'rbtn_Search2
        '
        Me.rbtn_Search2.AutoSize = True
        Me.rbtn_Search2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_Search2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtn_Search2.Location = New System.Drawing.Point(166, 12)
        Me.rbtn_Search2.Name = "rbtn_Search2"
        Me.rbtn_Search2.Size = New System.Drawing.Size(160, 20)
        Me.rbtn_Search2.TabIndex = 6
        Me.rbtn_Search2.Text = "いずれかを含む(OR)"
        Me.rbtn_Search2.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(47, 193)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 15)
        Me.Label15.TabIndex = 918
        Me.Label15.Text = "■検索方法"
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(564, 183)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(94, 35)
        Me.cmdSearch.TabIndex = 7
        Me.cmdSearch.Text = "検索"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'cmdCan
        '
        Me.cmdCan.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCan.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCan.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCan.Location = New System.Drawing.Point(671, 183)
        Me.cmdCan.Name = "cmdCan"
        Me.cmdCan.Size = New System.Drawing.Size(94, 35)
        Me.cmdCan.TabIndex = 8
        Me.cmdCan.Text = "条件クリア"
        Me.cmdCan.UseVisualStyleBackColor = True
        '
        'cmdIns
        '
        Me.cmdIns.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdIns.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdIns.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIns.Location = New System.Drawing.Point(990, 183)
        Me.cmdIns.Name = "cmdIns"
        Me.cmdIns.Size = New System.Drawing.Size(92, 44)
        Me.cmdIns.TabIndex = 9
        Me.cmdIns.Text = "新規登録"
        Me.cmdIns.UseVisualStyleBackColor = True
        '
        'cmdUpd
        '
        Me.cmdUpd.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdUpd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUpd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdUpd.Location = New System.Drawing.Point(990, 233)
        Me.cmdUpd.Name = "cmdUpd"
        Me.cmdUpd.Size = New System.Drawing.Size(92, 44)
        Me.cmdUpd.TabIndex = 10
        Me.cmdUpd.Text = "変更(表示)"
        Me.cmdUpd.UseVisualStyleBackColor = True
        '
        'cmdDel
        '
        Me.cmdDel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDel.Location = New System.Drawing.Point(990, 283)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(92, 44)
        Me.cmdDel.TabIndex = 11
        Me.cmdDel.Text = "削除"
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdPreview
        '
        Me.cmdPreview.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdPreview.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPreview.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdPreview.Location = New System.Drawing.Point(990, 333)
        Me.cmdPreview.Name = "cmdPreview"
        Me.cmdPreview.Size = New System.Drawing.Size(92, 44)
        Me.cmdPreview.TabIndex = 12
        Me.cmdPreview.Text = "プレビュー"
        Me.cmdPreview.UseVisualStyleBackColor = True
        '
        'dgv_Search
        '
        Me.dgv_Search.AllowUserToAddRows = False
        Me.dgv_Search.AllowUserToDeleteRows = False
        Me.dgv_Search.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Search.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DATA_KBN, Me.KEN_CD, Me.KEN_NAME, Me.KIKINKYOKAI_NM})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(30, 226)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowHeadersWidth = 20
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(946, 151)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 7
        '
        'DATA_KBN
        '
        Me.DATA_KBN.DataPropertyName = "DATA_KBN"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DATA_KBN.DefaultCellStyle = DataGridViewCellStyle2
        Me.DATA_KBN.Frozen = True
        Me.DATA_KBN.HeaderText = "区分"
        Me.DATA_KBN.Name = "DATA_KBN"
        Me.DATA_KBN.ReadOnly = True
        Me.DATA_KBN.Visible = False
        Me.DATA_KBN.Width = 5
        '
        'KEN_CD
        '
        Me.KEN_CD.DataPropertyName = "BANK_CD"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEN_CD.DefaultCellStyle = DataGridViewCellStyle3
        Me.KEN_CD.Frozen = True
        Me.KEN_CD.HeaderText = "金融機関ｺｰﾄﾞ"
        Me.KEN_CD.Name = "KEN_CD"
        Me.KEN_CD.ReadOnly = True
        '
        'KEN_NAME
        '
        Me.KEN_NAME.DataPropertyName = "BANK_KANA"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEN_NAME.DefaultCellStyle = DataGridViewCellStyle4
        Me.KEN_NAME.Frozen = True
        Me.KEN_NAME.HeaderText = "金融機関名（ｶﾅ）"
        Me.KEN_NAME.Name = "KEN_NAME"
        Me.KEN_NAME.ReadOnly = True
        Me.KEN_NAME.Width = 595
        '
        'KIKINKYOKAI_NM
        '
        Me.KIKINKYOKAI_NM.DataPropertyName = "BANK_NAME"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KIKINKYOKAI_NM.DefaultCellStyle = DataGridViewCellStyle5
        Me.KIKINKYOKAI_NM.Frozen = True
        Me.KIKINKYOKAI_NM.HeaderText = "金融機関名（漢字）"
        Me.KIKINKYOKAI_NM.Name = "KIKINKYOKAI_NM"
        Me.KIKINKYOKAI_NM.ReadOnly = True
        Me.KIKINKYOKAI_NM.Width = 250
        '
        'lblCOUNT
        '
        Me.lblCOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblCOUNT.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCOUNT.Location = New System.Drawing.Point(867, 200)
        Me.lblCOUNT.Name = "lblCOUNT"
        Me.lblCOUNT.Size = New System.Drawing.Size(55, 23)
        Me.lblCOUNT.TabIndex = 919
        Me.lblCOUNT.Text = "99999"
        Me.lblCOUNT.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(791, 200)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 15)
        Me.Label16.TabIndex = 920
        Me.Label16.Text = "抽出件数："
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(926, 200)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(20, 23)
        Me.Label17.TabIndex = 921
        Me.Label17.Text = "件"
        '
        'grpSEARCH
        '
        Me.grpSEARCH.Controls.Add(Me.rbtn_Search2)
        Me.grpSEARCH.Controls.Add(Me.rbtn_Search1)
        Me.grpSEARCH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grpSEARCH.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpSEARCH.Location = New System.Drawing.Point(161, 177)
        Me.grpSEARCH.Name = "grpSEARCH"
        Me.grpSEARCH.Size = New System.Drawing.Size(339, 38)
        Me.grpSEARCH.TabIndex = 4
        Me.grpSEARCH.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.CausesValidation = False
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.cmdPreview2)
        Me.Panel3.Controls.Add(Me.cmdDel2)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.cmdUpd2)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.cmdIns2)
        Me.Panel3.Controls.Add(Me.cmdCan2)
        Me.Panel3.Controls.Add(Me.lblCOUNT2)
        Me.Panel3.Controls.Add(Me.cmdSearch2)
        Me.Panel3.Controls.Add(Me.dgv_Search2)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.grpSEARCH2)
        Me.Panel3.Location = New System.Drawing.Point(3, 395)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1092, 341)
        Me.Panel3.TabIndex = 933
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(927, 151)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 23)
        Me.Label11.TabIndex = 934
        Me.Label11.Text = "件"
        '
        'cmdPreview2
        '
        Me.cmdPreview2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdPreview2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPreview2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdPreview2.Location = New System.Drawing.Point(988, 284)
        Me.cmdPreview2.Name = "cmdPreview2"
        Me.cmdPreview2.Size = New System.Drawing.Size(92, 44)
        Me.cmdPreview2.TabIndex = 25
        Me.cmdPreview2.Text = "プレビュー"
        Me.cmdPreview2.UseVisualStyleBackColor = True
        '
        'cmdDel2
        '
        Me.cmdDel2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdDel2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDel2.Location = New System.Drawing.Point(988, 234)
        Me.cmdDel2.Name = "cmdDel2"
        Me.cmdDel2.Size = New System.Drawing.Size(92, 44)
        Me.cmdDel2.TabIndex = 24
        Me.cmdDel2.Text = "削除"
        Me.cmdDel2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(790, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 943
        Me.Label2.Text = "抽出件数："
        '
        'cmdUpd2
        '
        Me.cmdUpd2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdUpd2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUpd2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdUpd2.Location = New System.Drawing.Point(988, 184)
        Me.cmdUpd2.Name = "cmdUpd2"
        Me.cmdUpd2.Size = New System.Drawing.Size(92, 44)
        Me.cmdUpd2.TabIndex = 23
        Me.cmdUpd2.Text = "変更(表示)"
        Me.cmdUpd2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.CausesValidation = False
        Me.Panel2.Controls.Add(Me.txt_SITEN_NAME)
        Me.Panel2.Controls.Add(Me.txt_SITEN_CD)
        Me.Panel2.Controls.Add(Me.txt_SITEN_KANA)
        Me.Panel2.Controls.Add(Me.grpDATAKBN2)
        Me.Panel2.Controls.Add(Me.lbl_SITEN_NAME)
        Me.Panel2.Controls.Add(Me.lbl_SITEN_KANA)
        Me.Panel2.Controls.Add(Me.lbl_SITEN_CD)
        Me.Panel2.Controls.Add(Me.lbl_DATA_KBN3)
        Me.Panel2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Panel2.Location = New System.Drawing.Point(28, 13)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1038, 105)
        Me.Panel2.TabIndex = 940
        '
        'txt_SITEN_NAME
        '
        Me.txt_SITEN_NAME.DropDown.AllowDrop = False
        Me.txt_SITEN_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_SITEN_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_SITEN_NAME.HighlightText = True
        Me.txt_SITEN_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_SITEN_NAME.Location = New System.Drawing.Point(178, 69)
        Me.txt_SITEN_NAME.MaxLength = 30
        Me.txt_SITEN_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_SITEN_NAME.Name = "txt_SITEN_NAME"
        Me.txt_SITEN_NAME.Size = New System.Drawing.Size(330, 22)
        Me.txt_SITEN_NAME.TabIndex = 17
        Me.txt_SITEN_NAME.Text = "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
        '
        'txt_SITEN_CD
        '
        Me.txt_SITEN_CD.DropDown.AllowDrop = False
        Me.txt_SITEN_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_SITEN_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_SITEN_CD.Format = "#"
        Me.txt_SITEN_CD.HighlightText = True
        Me.txt_SITEN_CD.Location = New System.Drawing.Point(178, 13)
        Me.txt_SITEN_CD.MaxLength = 3
        Me.txt_SITEN_CD.Name = "txt_SITEN_CD"
        Me.txt_SITEN_CD.Size = New System.Drawing.Size(44, 22)
        Me.txt_SITEN_CD.TabIndex = 15
        Me.txt_SITEN_CD.Text = "000"
        '
        'txt_SITEN_KANA
        '
        Me.txt_SITEN_KANA.DropDown.AllowDrop = False
        Me.txt_SITEN_KANA.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_SITEN_KANA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_SITEN_KANA.Format = "AaK9@"
        Me.txt_SITEN_KANA.HighlightText = True
        Me.txt_SITEN_KANA.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_SITEN_KANA.Location = New System.Drawing.Point(178, 41)
        Me.txt_SITEN_KANA.MaxLength = 60
        Me.txt_SITEN_KANA.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_SITEN_KANA.Name = "txt_SITEN_KANA"
        Me.txt_SITEN_KANA.Size = New System.Drawing.Size(631, 22)
        Me.txt_SITEN_KANA.TabIndex = 16
        Me.txt_SITEN_KANA.Text = "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
        '
        'grpDATAKBN2
        '
        Me.grpDATAKBN2.Controls.Add(Me.rbtn_DATA_KBN4)
        Me.grpDATAKBN2.Controls.Add(Me.rbtn_DATA_KBN3)
        Me.grpDATAKBN2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grpDATAKBN2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpDATAKBN2.Location = New System.Drawing.Point(842, 3)
        Me.grpDATAKBN2.Name = "grpDATAKBN2"
        Me.grpDATAKBN2.Size = New System.Drawing.Size(159, 38)
        Me.grpDATAKBN2.TabIndex = 12
        Me.grpDATAKBN2.TabStop = False
        Me.grpDATAKBN2.Visible = False
        '
        'rbtn_DATA_KBN4
        '
        Me.rbtn_DATA_KBN4.AutoSize = True
        Me.rbtn_DATA_KBN4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_DATA_KBN4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_DATA_KBN4.Location = New System.Drawing.Point(83, 12)
        Me.rbtn_DATA_KBN4.Name = "rbtn_DATA_KBN4"
        Me.rbtn_DATA_KBN4.Size = New System.Drawing.Size(61, 20)
        Me.rbtn_DATA_KBN4.TabIndex = 14
        Me.rbtn_DATA_KBN4.Text = "無効"
        Me.rbtn_DATA_KBN4.UseVisualStyleBackColor = True
        '
        'rbtn_DATA_KBN3
        '
        Me.rbtn_DATA_KBN3.AutoSize = True
        Me.rbtn_DATA_KBN3.Checked = True
        Me.rbtn_DATA_KBN3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_DATA_KBN3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_DATA_KBN3.Location = New System.Drawing.Point(10, 12)
        Me.rbtn_DATA_KBN3.Name = "rbtn_DATA_KBN3"
        Me.rbtn_DATA_KBN3.Size = New System.Drawing.Size(61, 20)
        Me.rbtn_DATA_KBN3.TabIndex = 13
        Me.rbtn_DATA_KBN3.TabStop = True
        Me.rbtn_DATA_KBN3.Text = "有効"
        Me.rbtn_DATA_KBN3.UseVisualStyleBackColor = True
        '
        'lbl_SITEN_NAME
        '
        Me.lbl_SITEN_NAME.AutoSize = True
        Me.lbl_SITEN_NAME.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_SITEN_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_SITEN_NAME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_SITEN_NAME.Location = New System.Drawing.Point(21, 70)
        Me.lbl_SITEN_NAME.Name = "lbl_SITEN_NAME"
        Me.lbl_SITEN_NAME.Size = New System.Drawing.Size(113, 15)
        Me.lbl_SITEN_NAME.TabIndex = 906
        Me.lbl_SITEN_NAME.Text = "□支店名（漢字）"
        '
        'lbl_SITEN_KANA
        '
        Me.lbl_SITEN_KANA.AutoSize = True
        Me.lbl_SITEN_KANA.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_SITEN_KANA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_SITEN_KANA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_SITEN_KANA.Location = New System.Drawing.Point(21, 44)
        Me.lbl_SITEN_KANA.Name = "lbl_SITEN_KANA"
        Me.lbl_SITEN_KANA.Size = New System.Drawing.Size(100, 15)
        Me.lbl_SITEN_KANA.TabIndex = 894
        Me.lbl_SITEN_KANA.Text = "□支店名（ｶﾅ）"
        '
        'lbl_SITEN_CD
        '
        Me.lbl_SITEN_CD.AutoSize = True
        Me.lbl_SITEN_CD.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_SITEN_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_SITEN_CD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_SITEN_CD.Location = New System.Drawing.Point(21, 17)
        Me.lbl_SITEN_CD.Name = "lbl_SITEN_CD"
        Me.lbl_SITEN_CD.Size = New System.Drawing.Size(89, 15)
        Me.lbl_SITEN_CD.TabIndex = 887
        Me.lbl_SITEN_CD.Text = "□支店コード"
        '
        'lbl_DATA_KBN3
        '
        Me.lbl_DATA_KBN3.AutoSize = True
        Me.lbl_DATA_KBN3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_DATA_KBN3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_DATA_KBN3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_DATA_KBN3.Location = New System.Drawing.Point(746, 17)
        Me.lbl_DATA_KBN3.Name = "lbl_DATA_KBN3"
        Me.lbl_DATA_KBN3.Size = New System.Drawing.Size(91, 15)
        Me.lbl_DATA_KBN3.TabIndex = 884
        Me.lbl_DATA_KBN3.Text = "■データ区分"
        Me.lbl_DATA_KBN3.Visible = False
        '
        'cmdIns2
        '
        Me.cmdIns2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdIns2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdIns2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIns2.Location = New System.Drawing.Point(988, 134)
        Me.cmdIns2.Name = "cmdIns2"
        Me.cmdIns2.Size = New System.Drawing.Size(92, 44)
        Me.cmdIns2.TabIndex = 22
        Me.cmdIns2.Text = "新規登録"
        Me.cmdIns2.UseVisualStyleBackColor = True
        '
        'cmdCan2
        '
        Me.cmdCan2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCan2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCan2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCan2.Location = New System.Drawing.Point(670, 131)
        Me.cmdCan2.Name = "cmdCan2"
        Me.cmdCan2.Size = New System.Drawing.Size(94, 35)
        Me.cmdCan2.TabIndex = 21
        Me.cmdCan2.Text = "条件クリア"
        Me.cmdCan2.UseVisualStyleBackColor = True
        '
        'lblCOUNT2
        '
        Me.lblCOUNT2.BackColor = System.Drawing.Color.Transparent
        Me.lblCOUNT2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCOUNT2.Location = New System.Drawing.Point(866, 151)
        Me.lblCOUNT2.Name = "lblCOUNT2"
        Me.lblCOUNT2.Size = New System.Drawing.Size(55, 23)
        Me.lblCOUNT2.TabIndex = 942
        Me.lblCOUNT2.Text = "99999"
        Me.lblCOUNT2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdSearch2
        '
        Me.cmdSearch2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSearch2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSearch2.Location = New System.Drawing.Point(563, 131)
        Me.cmdSearch2.Name = "cmdSearch2"
        Me.cmdSearch2.Size = New System.Drawing.Size(94, 35)
        Me.cmdSearch2.TabIndex = 20
        Me.cmdSearch2.Text = "検索"
        Me.cmdSearch2.UseVisualStyleBackColor = True
        '
        'dgv_Search2
        '
        Me.dgv_Search2.AllowUserToAddRows = False
        Me.dgv_Search2.AllowUserToDeleteRows = False
        Me.dgv_Search2.AllowUserToResizeRows = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Search2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_Search2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.dgv_Search2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search2.Location = New System.Drawing.Point(27, 177)
        Me.dgv_Search2.MultiSelect = False
        Me.dgv_Search2.Name = "dgv_Search2"
        Me.dgv_Search2.ReadOnly = True
        Me.dgv_Search2.RowHeadersVisible = False
        Me.dgv_Search2.RowHeadersWidth = 20
        Me.dgv_Search2.RowTemplate.Height = 21
        Me.dgv_Search2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search2.Size = New System.Drawing.Size(946, 151)
        Me.dgv_Search2.StandardTab = True
        Me.dgv_Search2.TabIndex = 19
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DATA_KBN"
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "区分"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 5
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "BANK_CD"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "金融機関ｺｰﾄﾞ"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "SITEN_CD"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "支店ｺｰﾄﾞ"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 70
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "SITEN_KANA"
        DataGridViewCellStyle10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn4.Frozen = True
        Me.DataGridViewTextBoxColumn4.HeaderText = "支店名（ｶﾅ）"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 525
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "SITEN_NAME"
        DataGridViewCellStyle11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn5.Frozen = True
        Me.DataGridViewTextBoxColumn5.HeaderText = "支店名（漢字）"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 250
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(46, 138)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 15)
        Me.Label12.TabIndex = 941
        Me.Label12.Text = "■検索方法"
        '
        'grpSEARCH2
        '
        Me.grpSEARCH2.Controls.Add(Me.rbtn_Search4)
        Me.grpSEARCH2.Controls.Add(Me.rbtn_Search3)
        Me.grpSEARCH2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grpSEARCH2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpSEARCH2.Location = New System.Drawing.Point(160, 124)
        Me.grpSEARCH2.Name = "grpSEARCH2"
        Me.grpSEARCH2.Size = New System.Drawing.Size(339, 38)
        Me.grpSEARCH2.TabIndex = 16
        Me.grpSEARCH2.TabStop = False
        '
        'rbtn_Search4
        '
        Me.rbtn_Search4.AutoSize = True
        Me.rbtn_Search4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_Search4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtn_Search4.Location = New System.Drawing.Point(166, 12)
        Me.rbtn_Search4.Name = "rbtn_Search4"
        Me.rbtn_Search4.Size = New System.Drawing.Size(160, 20)
        Me.rbtn_Search4.TabIndex = 19
        Me.rbtn_Search4.Text = "いずれかを含む(OR)"
        Me.rbtn_Search4.UseVisualStyleBackColor = True
        '
        'rbtn_Search3
        '
        Me.rbtn_Search3.AutoSize = True
        Me.rbtn_Search3.Checked = True
        Me.rbtn_Search3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_Search3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtn_Search3.Location = New System.Drawing.Point(6, 12)
        Me.rbtn_Search3.Name = "rbtn_Search3"
        Me.rbtn_Search3.Size = New System.Drawing.Size(154, 20)
        Me.rbtn_Search3.TabIndex = 18
        Me.rbtn_Search3.TabStop = True
        Me.rbtn_Search3.Text = "すべてを含む(AND)"
        Me.rbtn_Search3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(919, 172)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 23)
        Me.Label1.TabIndex = 944
        Me.Label1.Text = "件"
        '
        'frmGJ8050
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grpSEARCH)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblCOUNT)
        Me.Controls.Add(Me.cmdIns)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cmdCan)
        Me.Controls.Add(Me.cmdUpd)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cmdPreview)
        Me.Controls.Add(Me.dgv_Search)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "frmGJ8050"
        Me.Text = "(GJ8050)金融機関マスタ保守一覧"
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.dgv_Search, 0)
        Me.Controls.SetChildIndex(Me.cmdPreview, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.cmdDel, 0)
        Me.Controls.SetChildIndex(Me.cmdUpd, 0)
        Me.Controls.SetChildIndex(Me.cmdCan, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.cmdSearch, 0)
        Me.Controls.SetChildIndex(Me.cmdIns, 0)
        Me.Controls.SetChildIndex(Me.lblCOUNT, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.grpSEARCH, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.pnlButton.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txt_BANK_KANA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_BANK_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_BANK_CD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDATAKBN.ResumeLayout(False)
        Me.grpDATAKBN.PerformLayout()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSEARCH.ResumeLayout(False)
        Me.grpSEARCH.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.txt_SITEN_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SITEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SITEN_KANA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDATAKBN2.ResumeLayout(False)
        Me.grpDATAKBN2.PerformLayout()
        CType(Me.dgv_Search2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSEARCH2.ResumeLayout(False)
        Me.grpSEARCH2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_BANK_NAME As JBD.Gjs.Win.Label
    Friend WithEvents txt_BANK_KANA As JBD.Gjs.Win.GcTextBox
    Friend WithEvents rbtn_DATA_KBN1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_DATA_KBN2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents lbl_BANK_KANA As JBD.Gjs.Win.Label
    Friend WithEvents lbl_BANK_CD As JBD.Gjs.Win.Label
    Friend WithEvents lbl_DATA_KBN1 As JBD.Gjs.Win.Label
    Friend WithEvents rbtn_Search1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_Search2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents cmdSearch As JBD.Gjs.Win.JButton
    Friend WithEvents cmdCan As JBD.Gjs.Win.JButton
    Friend WithEvents cmdIns As JBD.Gjs.Win.JButton
    Friend WithEvents cmdPreview As JBD.Gjs.Win.JButton
    Friend WithEvents cmdDel As JBD.Gjs.Win.JButton
    Friend WithEvents cmdUpd As JBD.Gjs.Win.JButton
    Friend WithEvents dgv_Search As JBD.Gjs.Win.DataGridView
    Friend WithEvents lblCOUNT As JBD.Gjs.Win.Label
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents grpDATAKBN As JBD.Gjs.Win.GroupBox
    Friend WithEvents grpSEARCH As JBD.Gjs.Win.GroupBox
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents txt_BANK_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_BANK_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmdDel2 As JBD.Gjs.Win.JButton
    Friend WithEvents Label1 As JBD.Gjs.Win.Label
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents cmdUpd2 As JBD.Gjs.Win.JButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txt_SITEN_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_SITEN_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_SITEN_KANA As JBD.Gjs.Win.GcTextBox
    Friend WithEvents grpDATAKBN2 As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtn_DATA_KBN4 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_DATA_KBN3 As JBD.Gjs.Win.RadioButton
    Friend WithEvents lbl_SITEN_NAME As JBD.Gjs.Win.Label
    Friend WithEvents lbl_SITEN_KANA As JBD.Gjs.Win.Label
    Friend WithEvents lbl_SITEN_CD As JBD.Gjs.Win.Label
    Friend WithEvents lbl_DATA_KBN3 As JBD.Gjs.Win.Label
    Friend WithEvents cmdIns2 As JBD.Gjs.Win.JButton
    Friend WithEvents cmdCan2 As JBD.Gjs.Win.JButton
    Friend WithEvents lblCOUNT2 As JBD.Gjs.Win.Label
    Friend WithEvents cmdSearch2 As JBD.Gjs.Win.JButton
    Friend WithEvents dgv_Search2 As JBD.Gjs.Win.DataGridView
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents grpSEARCH2 As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtn_Search4 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_Search3 As JBD.Gjs.Win.RadioButton
    Friend WithEvents cmdPreview2 As JBD.Gjs.Win.JButton
    Friend WithEvents DATA_KBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEN_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEN_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KIKINKYOKAI_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label11 As JBD.Gjs.Win.Label

End Class
