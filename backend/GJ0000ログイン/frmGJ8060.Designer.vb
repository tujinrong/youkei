Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ8060
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
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.ITAKU_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITAKU_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_POST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.txt_ITAKU_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_KI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_MATOMESAKI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.cmdCSV = New JBD.Gjs.Win.JButton(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KEN_CD_T = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEN_NM_T = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_ITAKU_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KEN_CD_F = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEN_NM_F = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txt_ITAKU_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_MATOMESAKI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.cob_KEN_CD_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEN_NM_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ITAKU_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlButton.Controls.Add(Me.cmdCSV)
        Me.pnlButton.Controls.Add(Me.cmdDel)
        Me.pnlButton.Controls.Add(Me.cmdUpd)
        Me.pnlButton.Controls.Add(Me.cmdIns)
        Me.pnlButton.TabIndex = 900
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdIns, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdUpd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdDel, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCSV, 0)
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
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ITAKU_CD, Me.ITAKU_NAME, Me.ADDR_TEL, Me.ADDR_POST, Me.ADDR})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(28, 325)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(1040, 400)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 40
        '
        'ITAKU_CD
        '
        Me.ITAKU_CD.DataPropertyName = "ITAKU_CD"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ITAKU_CD.DefaultCellStyle = DataGridViewCellStyle1
        Me.ITAKU_CD.Frozen = True
        Me.ITAKU_CD.HeaderText = "事務委託先"
        Me.ITAKU_CD.Name = "ITAKU_CD"
        Me.ITAKU_CD.ReadOnly = True
        Me.ITAKU_CD.Width = 90
        '
        'ITAKU_NAME
        '
        Me.ITAKU_NAME.DataPropertyName = "ITAKU_NAME"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ITAKU_NAME.DefaultCellStyle = DataGridViewCellStyle2
        Me.ITAKU_NAME.Frozen = True
        Me.ITAKU_NAME.HeaderText = "事務委託先名"
        Me.ITAKU_NAME.Name = "ITAKU_NAME"
        Me.ITAKU_NAME.ReadOnly = True
        Me.ITAKU_NAME.Width = 300
        '
        'ADDR_TEL
        '
        Me.ADDR_TEL.DataPropertyName = "ADDR_TEL"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_TEL.DefaultCellStyle = DataGridViewCellStyle3
        Me.ADDR_TEL.Frozen = True
        Me.ADDR_TEL.HeaderText = "電話番号"
        Me.ADDR_TEL.Name = "ADDR_TEL"
        Me.ADDR_TEL.ReadOnly = True
        Me.ADDR_TEL.Width = 120
        '
        'ADDR_POST
        '
        Me.ADDR_POST.DataPropertyName = "ADDR_POST"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_POST.DefaultCellStyle = DataGridViewCellStyle4
        Me.ADDR_POST.Frozen = True
        Me.ADDR_POST.HeaderText = "郵便番号"
        Me.ADDR_POST.Name = "ADDR_POST"
        Me.ADDR_POST.ReadOnly = True
        Me.ADDR_POST.Width = 80
        '
        'ADDR
        '
        Me.ADDR.DataPropertyName = "ADDR"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR.DefaultCellStyle = DataGridViewCellStyle5
        Me.ADDR.HeaderText = "住所"
        Me.ADDR.Name = "ADDR"
        Me.ADDR.ReadOnly = True
        Me.ADDR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ADDR.Width = 430
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(1024, 289)
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
        Me.lblCOUNT.Location = New System.Drawing.Point(967, 289)
        Me.lblCOUNT.Name = "lblCOUNT"
        Me.lblCOUNT.Size = New System.Drawing.Size(55, 15)
        Me.lblCOUNT.TabIndex = 922
        Me.lblCOUNT.Text = "99999"
        Me.lblCOUNT.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(896, 289)
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
        Me.cmdCan.Location = New System.Drawing.Point(777, 279)
        Me.cmdCan.Name = "cmdCan"
        Me.cmdCan.Size = New System.Drawing.Size(94, 35)
        Me.cmdCan.TabIndex = 31
        Me.cmdCan.Text = "条件クリア"
        Me.cmdCan.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(665, 279)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(94, 35)
        Me.cmdSearch.TabIndex = 30
        Me.cmdSearch.Text = "検索"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtn_SearchOr)
        Me.GroupBox1.Controls.Add(Me.rbtn_SearchAnd)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(161, 266)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(339, 38)
        Me.GroupBox1.TabIndex = 20
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
        Me.Label19.Location = New System.Drawing.Point(34, 279)
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
        Me.cmdDel.TabIndex = 2
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
        Me.cmdUpd.TabIndex = 1
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
        Me.cmdIns.TabIndex = 0
        Me.cmdIns.Text = "新規登録"
        Me.cmdIns.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(33, 58)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(129, 19)
        Me.Label25.TabIndex = 925
        Me.Label25.Text = "検索条件入力"
        '
        'txt_ITAKU_CD
        '
        Me.txt_ITAKU_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_ITAKU_CD.DropDown.AllowDrop = False
        Me.txt_ITAKU_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ITAKU_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_ITAKU_CD.Format = "9"
        Me.txt_ITAKU_CD.Location = New System.Drawing.Point(193, 101)
        Me.txt_ITAKU_CD.MaxLength = 3
        Me.txt_ITAKU_CD.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ITAKU_CD.Name = "txt_ITAKU_CD"
        Me.GcShortcut1.SetShortcuts(Me.txt_ITAKU_CD, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_ITAKU_CD, Object)}, New String() {"ShortcutClear"}))
        Me.txt_ITAKU_CD.Size = New System.Drawing.Size(36, 20)
        Me.txt_ITAKU_CD.TabIndex = 6
        Me.txt_ITAKU_CD.Text = "999"
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
        Me.txt_KI.Location = New System.Drawing.Point(193, 12)
        Me.txt_KI.MaxLength = 2
        Me.txt_KI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KI.Name = "txt_KI"
        Me.GcShortcut1.SetShortcuts(Me.txt_KI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_KI, Object)}, New String() {"ShortcutClear"}))
        Me.txt_KI.Size = New System.Drawing.Size(36, 20)
        Me.txt_KI.TabIndex = 0
        Me.txt_KI.Text = "99"
        '
        'txt_MATOMESAKI
        '
        Me.txt_MATOMESAKI.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_MATOMESAKI.DropDown.AllowDrop = False
        Me.txt_MATOMESAKI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_MATOMESAKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_MATOMESAKI.Format = "9"
        Me.txt_MATOMESAKI.HighlightText = True
        Me.txt_MATOMESAKI.Location = New System.Drawing.Point(193, 132)
        Me.txt_MATOMESAKI.MaxLength = 1
        Me.txt_MATOMESAKI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_MATOMESAKI.Name = "txt_MATOMESAKI"
        Me.GcShortcut1.SetShortcuts(Me.txt_MATOMESAKI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_MATOMESAKI, Object)}, New String() {"ShortcutClear"}))
        Me.txt_MATOMESAKI.Size = New System.Drawing.Size(23, 20)
        Me.txt_MATOMESAKI.TabIndex = 7
        Me.txt_MATOMESAKI.Text = "9"
        '
        'cmdCSV
        '
        Me.cmdCSV.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCSV.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCSV.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCSV.Location = New System.Drawing.Point(502, 3)
        Me.cmdCSV.Name = "cmdCSV"
        Me.cmdCSV.Size = New System.Drawing.Size(92, 44)
        Me.cmdCSV.TabIndex = 3
        Me.cmdCSV.Text = "CSV出力"
        Me.cmdCSV.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txt_MATOMESAKI)
        Me.Panel1.Controls.Add(Me.txt_ITAKU_CD)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.cob_KEN_CD_T)
        Me.Panel1.Controls.Add(Me.cob_KEN_NM_T)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txt_ITAKU_NAME)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cob_KEN_CD_F)
        Me.Panel1.Controls.Add(Me.cob_KEN_NM_F)
        Me.Panel1.Controls.Add(Me.txt_KI)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(28, 89)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1030, 170)
        Me.Panel1.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(39, 135)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 15)
        Me.Label8.TabIndex = 954
        Me.Label8.Text = "□まとめ先"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(39, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 15)
        Me.Label3.TabIndex = 950
        Me.Label3.Text = "□事務委託先"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(620, 75)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 15)
        Me.Label15.TabIndex = 949
        Me.Label15.Text = "(部分一致)"
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
        Me.cob_KEN_CD_T.Location = New System.Drawing.Point(382, 40)
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
        Me.cob_KEN_NM_T.Location = New System.Drawing.Point(424, 40)
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
        Me.Label5.Location = New System.Drawing.Point(357, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 15)
        Me.Label5.TabIndex = 947
        Me.Label5.Text = "～"
        '
        'txt_ITAKU_NAME
        '
        Me.txt_ITAKU_NAME.AllowSpace = GrapeCity.Win.Editors.AllowSpace.Wide
        Me.txt_ITAKU_NAME.DropDown.AllowDrop = False
        Me.txt_ITAKU_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ITAKU_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ITAKU_NAME.Format = "Ｚ"
        Me.txt_ITAKU_NAME.HighlightText = True
        Me.txt_ITAKU_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ITAKU_NAME.Location = New System.Drawing.Point(193, 72)
        Me.txt_ITAKU_NAME.MaxLength = 50
        Me.txt_ITAKU_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ITAKU_NAME.Name = "txt_ITAKU_NAME"
        Me.txt_ITAKU_NAME.Size = New System.Drawing.Size(421, 20)
        Me.txt_ITAKU_NAME.TabIndex = 5
        Me.txt_ITAKU_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(39, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 15)
        Me.Label4.TabIndex = 948
        Me.Label4.Text = "□事務委託先名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(39, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 946
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
        Me.cob_KEN_CD_F.Location = New System.Drawing.Point(193, 40)
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
        Me.cob_KEN_NM_F.Location = New System.Drawing.Point(235, 40)
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(39, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 15)
        Me.Label6.TabIndex = 939
        Me.Label6.Text = "■期"
        '
        'frmGJ8060
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
        Me.Name = "frmGJ8060"
        Me.Text = "(GJ8060)事務委託先一覧"
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
        CType(Me.txt_ITAKU_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_MATOMESAKI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cob_KEN_CD_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEN_NM_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ITAKU_NAME, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdCSV As JBD.Gjs.Win.JButton
    Friend WithEvents ITAKU_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITAKU_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR_TEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR_POST As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_ITAKU_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KEN_CD_T As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEN_NM_T As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents txt_ITAKU_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KEN_CD_F As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEN_NM_F As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents txt_KI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents txt_MATOMESAKI As JBD.Gjs.Win.GcTextBox

End Class
