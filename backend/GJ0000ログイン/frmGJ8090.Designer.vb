Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ8090
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
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.NOJO_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOJO_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.txt_NOJO_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_KI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_NOJO_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KEIYAKUSYA_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEIYAKUSYA_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.pnlButton.SuspendLayout()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txt_NOJO_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txt_NOJO_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKUSYA_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdDel)
        Me.pnlButton.Controls.Add(Me.cmdUpd)
        Me.pnlButton.Controls.Add(Me.cmdIns)
        Me.pnlButton.Size = New System.Drawing.Size(1091, 55)
        Me.pnlButton.TabIndex = 900
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdIns, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdUpd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdDel, 0)
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
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NOJO_CD, Me.NOJO_NAME, Me.ADDR})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(28, 285)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(1030, 445)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 40
        '
        'NOJO_CD
        '
        Me.NOJO_CD.DataPropertyName = "NOJO_CD"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NOJO_CD.DefaultCellStyle = DataGridViewCellStyle1
        Me.NOJO_CD.Frozen = True
        Me.NOJO_CD.HeaderText = "農場コード"
        Me.NOJO_CD.Name = "NOJO_CD"
        Me.NOJO_CD.ReadOnly = True
        Me.NOJO_CD.Width = 90
        '
        'NOJO_NAME
        '
        Me.NOJO_NAME.DataPropertyName = "NOJO_NAME"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NOJO_NAME.DefaultCellStyle = DataGridViewCellStyle2
        Me.NOJO_NAME.Frozen = True
        Me.NOJO_NAME.HeaderText = "農場名"
        Me.NOJO_NAME.Name = "NOJO_NAME"
        Me.NOJO_NAME.ReadOnly = True
        Me.NOJO_NAME.Width = 320
        '
        'ADDR
        '
        Me.ADDR.DataPropertyName = "ADDR"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR.DefaultCellStyle = DataGridViewCellStyle3
        Me.ADDR.HeaderText = "住所"
        Me.ADDR.Name = "ADDR"
        Me.ADDR.ReadOnly = True
        Me.ADDR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ADDR.Width = 600
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(1024, 252)
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
        Me.lblCOUNT.Location = New System.Drawing.Point(967, 252)
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
        Me.Label11.Location = New System.Drawing.Point(896, 252)
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
        Me.cmdCan.Location = New System.Drawing.Point(777, 242)
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
        Me.cmdSearch.Location = New System.Drawing.Point(665, 242)
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
        Me.GroupBox1.Location = New System.Drawing.Point(161, 229)
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
        Me.Label19.Location = New System.Drawing.Point(34, 242)
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
        'txt_NOJO_CD
        '
        Me.txt_NOJO_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_NOJO_CD.DropDown.AllowDrop = False
        Me.txt_NOJO_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_NOJO_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_NOJO_CD.Format = "9"
        Me.txt_NOJO_CD.HighlightText = True
        Me.txt_NOJO_CD.Location = New System.Drawing.Point(132, 68)
        Me.txt_NOJO_CD.MaxLength = 3
        Me.txt_NOJO_CD.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_NOJO_CD.Name = "txt_NOJO_CD"
        Me.GcShortcut1.SetShortcuts(Me.txt_NOJO_CD, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_NOJO_CD, Object)}, New String() {"ShortcutClear"}))
        Me.txt_NOJO_CD.Size = New System.Drawing.Size(36, 20)
        Me.txt_NOJO_CD.TabIndex = 3
        Me.txt_NOJO_CD.Text = "999"
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
        Me.txt_KI.Location = New System.Drawing.Point(131, 12)
        Me.txt_KI.MaxLength = 2
        Me.txt_KI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KI.Name = "txt_KI"
        Me.GcShortcut1.SetShortcuts(Me.txt_KI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_KI, Object)}, New String() {"ShortcutClear"}))
        Me.txt_KI.Size = New System.Drawing.Size(36, 20)
        Me.txt_KI.TabIndex = 0
        Me.txt_KI.Text = "99"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txt_KI)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txt_NOJO_CD)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txt_NOJO_NAME)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cob_KEIYAKUSYA_CD)
        Me.Panel1.Controls.Add(Me.cob_KEIYAKUSYA_NM)
        Me.Panel1.Location = New System.Drawing.Point(28, 89)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1030, 130)
        Me.Panel1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(39, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 939
        Me.Label5.Text = "■期"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(39, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 937
        Me.Label3.Text = "□農場番号"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(458, 100)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 15)
        Me.Label15.TabIndex = 936
        Me.Label15.Text = "(部分一致)"
        '
        'txt_NOJO_NAME
        '
        Me.txt_NOJO_NAME.AllowSpace = GrapeCity.Win.Editors.AllowSpace.Wide
        Me.txt_NOJO_NAME.DropDown.AllowDrop = False
        Me.txt_NOJO_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_NOJO_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_NOJO_NAME.Format = "Ｚ"
        Me.txt_NOJO_NAME.HighlightText = True
        Me.txt_NOJO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_NOJO_NAME.Location = New System.Drawing.Point(132, 97)
        Me.txt_NOJO_NAME.MaxLength = 40
        Me.txt_NOJO_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_NOJO_NAME.Name = "txt_NOJO_NAME"
        Me.txt_NOJO_NAME.Size = New System.Drawing.Size(320, 20)
        Me.txt_NOJO_NAME.TabIndex = 4
        Me.txt_NOJO_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(39, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 935
        Me.Label4.Text = "□農場名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(39, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 934
        Me.Label2.Text = "■契約者"
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
        Me.cob_KEIYAKUSYA_CD.Location = New System.Drawing.Point(131, 39)
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
        Me.cob_KEIYAKUSYA_NM.Location = New System.Drawing.Point(188, 39)
        Me.cob_KEIYAKUSYA_NM.Name = "cob_KEIYAKUSYA_NM"
        Me.cob_KEIYAKUSYA_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cob_KEIYAKUSYA_NM.Size = New System.Drawing.Size(561, 22)
        Me.cob_KEIYAKUSYA_NM.TabIndex = 2
        Me.cob_KEIYAKUSYA_NM.TabStop = False
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'frmGJ8090
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
        Me.Name = "frmGJ8090"
        Me.Text = "(GJ8090)契約者農場一覧"
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
        CType(Me.txt_NOJO_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txt_NOJO_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKUSYA_NM, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_KI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents txt_NOJO_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents txt_NOJO_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KEIYAKUSYA_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEIYAKUSYA_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents NOJO_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOJO_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
