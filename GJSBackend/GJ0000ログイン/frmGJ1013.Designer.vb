Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ1013
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
        Dim MaskLiteralField1 As GrapeCity.Win.Editors.Fields.MaskLiteralField = New GrapeCity.Win.Editors.Fields.MaskLiteralField()
        Dim MaskPatternField1 As GrapeCity.Win.Editors.Fields.MaskPatternField = New GrapeCity.Win.Editors.Fields.MaskPatternField()
        Dim MaskLiteralField2 As GrapeCity.Win.Editors.Fields.MaskLiteralField = New GrapeCity.Win.Editors.Fields.MaskLiteralField()
        Dim MaskPatternField2 As GrapeCity.Win.Editors.Fields.MaskPatternField = New GrapeCity.Win.Editors.Fields.MaskPatternField()
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.txt_MEISAI_NO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_NOJO_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.DropDownButton14 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton15 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton16 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton17 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton18 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton19 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.NOJO_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOJO_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEN_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MEISAI_NO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_POST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl_KEIYAKUSYA_CD = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKUSYA_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_ADDR_4 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_ADDR_3 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_NOJO_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_ADDR_2 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_ADDR_1 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.msk_ADDR_POST = New JBD.Gjs.Win.GcMask(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KEN_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEN_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.pnlButton.SuspendLayout()
        CType(Me.txt_MEISAI_NO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_NOJO_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txt_ADDR_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_NOJO_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.msk_ADDR_POST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdSave)
        Me.pnlButton.TabIndex = 101
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSave, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
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
        Me.cmdSave.Location = New System.Drawing.Point(12, 6)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 44)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Text = "保存"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'txt_MEISAI_NO
        '
        Me.txt_MEISAI_NO.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_MEISAI_NO.DropDown.AllowDrop = False
        Me.txt_MEISAI_NO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_MEISAI_NO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_MEISAI_NO.Format = "9"
        Me.txt_MEISAI_NO.HighlightText = True
        Me.txt_MEISAI_NO.InputCheck = True
        Me.txt_MEISAI_NO.Location = New System.Drawing.Point(270, 709)
        Me.txt_MEISAI_NO.MaxLength = 3
        Me.txt_MEISAI_NO.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_MEISAI_NO.Name = "txt_MEISAI_NO"
        Me.GcShortcut1.SetShortcuts(Me.txt_MEISAI_NO, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_MEISAI_NO, Object)}, New String() {"ShortcutClear"}))
        Me.txt_MEISAI_NO.Size = New System.Drawing.Size(34, 20)
        Me.txt_MEISAI_NO.TabIndex = 20
        Me.txt_MEISAI_NO.Text = "999"
        '
        'txt_NOJO_CD
        '
        Me.txt_NOJO_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_NOJO_CD.DropDown.AllowDrop = False
        Me.txt_NOJO_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_NOJO_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_NOJO_CD.Format = "9"
        Me.txt_NOJO_CD.HighlightText = True
        Me.txt_NOJO_CD.InputCheck = True
        Me.txt_NOJO_CD.Location = New System.Drawing.Point(270, 526)
        Me.txt_NOJO_CD.MaxLength = 3
        Me.txt_NOJO_CD.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_NOJO_CD.Name = "txt_NOJO_CD"
        Me.GcShortcut1.SetShortcuts(Me.txt_NOJO_CD, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_NOJO_CD, Object)}, New String() {"ShortcutClear"}))
        Me.txt_NOJO_CD.Size = New System.Drawing.Size(36, 20)
        Me.txt_NOJO_CD.TabIndex = 11
        Me.txt_NOJO_CD.Text = "999"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(70, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "契約者"
        '
        'dgv_Search
        '
        Me.dgv_Search.AllowUserToAddRows = False
        Me.dgv_Search.AllowUserToDeleteRows = False
        Me.dgv_Search.AllowUserToResizeRows = False
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NOJO_CD, Me.NOJO_NM, Me.KEN_CD, Me.ADDR, Me.MEISAI_NO, Me.ADDR_POST, Me.ADDR_1, Me.ADDR_2, Me.ADDR_3, Me.ADDR_4})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(25, 137)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(1021, 319)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 30
        Me.dgv_Search.TabStop = False
        '
        'NOJO_CD
        '
        Me.NOJO_CD.DataPropertyName = "NOJO_CD"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.NOJO_CD.DefaultCellStyle = DataGridViewCellStyle1
        Me.NOJO_CD.Frozen = True
        Me.NOJO_CD.HeaderText = "農場番号"
        Me.NOJO_CD.Name = "NOJO_CD"
        Me.NOJO_CD.ReadOnly = True
        Me.NOJO_CD.Width = 80
        '
        'NOJO_NM
        '
        Me.NOJO_NM.DataPropertyName = "NOJO_NM"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NOJO_NM.DefaultCellStyle = DataGridViewCellStyle2
        Me.NOJO_NM.Frozen = True
        Me.NOJO_NM.HeaderText = "農場名"
        Me.NOJO_NM.Name = "NOJO_NM"
        Me.NOJO_NM.ReadOnly = True
        Me.NOJO_NM.Width = 270
        '
        'KEN_CD
        '
        Me.KEN_CD.DataPropertyName = "KEN_CD"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.KEN_CD.DefaultCellStyle = DataGridViewCellStyle3
        Me.KEN_CD.Frozen = True
        Me.KEN_CD.HeaderText = "県コード(隠)"
        Me.KEN_CD.Name = "KEN_CD"
        Me.KEN_CD.ReadOnly = True
        Me.KEN_CD.Visible = False
        Me.KEN_CD.Width = 20
        '
        'ADDR
        '
        Me.ADDR.DataPropertyName = "ADDR"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR.DefaultCellStyle = DataGridViewCellStyle4
        Me.ADDR.Frozen = True
        Me.ADDR.HeaderText = "農場住所"
        Me.ADDR.Name = "ADDR"
        Me.ADDR.ReadOnly = True
        Me.ADDR.Width = 650
        '
        'MEISAI_NO
        '
        Me.MEISAI_NO.DataPropertyName = "MEISAI_NO"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.MEISAI_NO.DefaultCellStyle = DataGridViewCellStyle5
        Me.MEISAI_NO.Frozen = True
        Me.MEISAI_NO.HeaderText = "明細番号(隠)"
        Me.MEISAI_NO.Name = "MEISAI_NO"
        Me.MEISAI_NO.ReadOnly = True
        Me.MEISAI_NO.Visible = False
        Me.MEISAI_NO.Width = 120
        '
        'ADDR_POST
        '
        Me.ADDR_POST.DataPropertyName = "ADDR_POST"
        Me.ADDR_POST.Frozen = True
        Me.ADDR_POST.HeaderText = "郵便番号(隠)"
        Me.ADDR_POST.Name = "ADDR_POST"
        Me.ADDR_POST.ReadOnly = True
        Me.ADDR_POST.Visible = False
        '
        'ADDR_1
        '
        Me.ADDR_1.DataPropertyName = "ADDR_1"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_1.DefaultCellStyle = DataGridViewCellStyle6
        Me.ADDR_1.Frozen = True
        Me.ADDR_1.HeaderText = "住所1(隠)"
        Me.ADDR_1.Name = "ADDR_1"
        Me.ADDR_1.ReadOnly = True
        Me.ADDR_1.Visible = False
        '
        'ADDR_2
        '
        Me.ADDR_2.DataPropertyName = "ADDR_2"
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_2.DefaultCellStyle = DataGridViewCellStyle7
        Me.ADDR_2.Frozen = True
        Me.ADDR_2.HeaderText = "住所2(隠)"
        Me.ADDR_2.Name = "ADDR_2"
        Me.ADDR_2.ReadOnly = True
        Me.ADDR_2.Visible = False
        '
        'ADDR_3
        '
        Me.ADDR_3.DataPropertyName = "ADDR_3"
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_3.DefaultCellStyle = DataGridViewCellStyle8
        Me.ADDR_3.Frozen = True
        Me.ADDR_3.HeaderText = "住所3(隠)"
        Me.ADDR_3.Name = "ADDR_3"
        Me.ADDR_3.ReadOnly = True
        Me.ADDR_3.Visible = False
        '
        'ADDR_4
        '
        Me.ADDR_4.DataPropertyName = "ADDR_4"
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_4.DefaultCellStyle = DataGridViewCellStyle9
        Me.ADDR_4.Frozen = True
        Me.ADDR_4.HeaderText = "住所4(隠)"
        Me.ADDR_4.Name = "ADDR_4"
        Me.ADDR_4.ReadOnly = True
        Me.ADDR_4.Visible = False
        '
        'lbl_KEIYAKUSYA_CD
        '
        Me.lbl_KEIYAKUSYA_CD.AutoSize = True
        Me.lbl_KEIYAKUSYA_CD.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKUSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKUSYA_CD.Location = New System.Drawing.Point(134, 109)
        Me.lbl_KEIYAKUSYA_CD.Name = "lbl_KEIYAKUSYA_CD"
        Me.lbl_KEIYAKUSYA_CD.Size = New System.Drawing.Size(47, 15)
        Me.lbl_KEIYAKUSYA_CD.TabIndex = 1059
        Me.lbl_KEIYAKUSYA_CD.Text = "99999"
        '
        'lbl_KEIYAKUSYA_NM
        '
        Me.lbl_KEIYAKUSYA_NM.AutoSize = True
        Me.lbl_KEIYAKUSYA_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKUSYA_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKUSYA_NM.Location = New System.Drawing.Point(199, 109)
        Me.lbl_KEIYAKUSYA_NM.Name = "lbl_KEIYAKUSYA_NM"
        Me.lbl_KEIYAKUSYA_NM.Size = New System.Drawing.Size(157, 15)
        Me.lbl_KEIYAKUSYA_NM.TabIndex = 1060
        Me.lbl_KEIYAKUSYA_NM.Text = "＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_KI
        '
        Me.lbl_KI.AutoSize = True
        Me.lbl_KI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KI.Location = New System.Drawing.Point(28, 54)
        Me.lbl_KI.Name = "lbl_KI"
        Me.lbl_KI.Size = New System.Drawing.Size(53, 15)
        Me.lbl_KI.TabIndex = 1061
        Me.lbl_KI.Text = "第99期"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Location = New System.Drawing.Point(26, 75)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(994, 25)
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
        Me.Label10.Size = New System.Drawing.Size(179, 19)
        Me.Label10.TabIndex = 1059
        Me.Label10.Text = "１．農場情報（表示）"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(26, 485)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(994, 25)
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
        Me.Label11.Size = New System.Drawing.Size(247, 19)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "　　２．農場登録情報（入力）"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(72, 712)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 15)
        Me.Label15.TabIndex = 1092
        Me.Label15.Text = "■明細番号"
        '
        'txt_ADDR_4
        '
        Me.txt_ADDR_4.DropDown.AllowDrop = False
        Me.txt_ADDR_4.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_4.Format = "Ｚ"
        Me.txt_ADDR_4.HighlightText = True
        Me.txt_ADDR_4.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ADDR_4.Location = New System.Drawing.Point(270, 676)
        Me.txt_ADDR_4.MaxLength = 40
        Me.txt_ADDR_4.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_4.Name = "txt_ADDR_4"
        Me.txt_ADDR_4.Size = New System.Drawing.Size(325, 20)
        Me.txt_ADDR_4.TabIndex = 19
        Me.txt_ADDR_4.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'txt_ADDR_3
        '
        Me.txt_ADDR_3.DropDown.AllowDrop = False
        Me.txt_ADDR_3.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_3.Format = "Ｚ"
        Me.txt_ADDR_3.HighlightText = True
        Me.txt_ADDR_3.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ADDR_3.Location = New System.Drawing.Point(270, 650)
        Me.txt_ADDR_3.MaxLength = 30
        Me.txt_ADDR_3.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_3.Name = "txt_ADDR_3"
        Me.txt_ADDR_3.Size = New System.Drawing.Size(243, 20)
        Me.txt_ADDR_3.TabIndex = 18
        Me.txt_ADDR_3.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'txt_NOJO_NAME
        '
        Me.txt_NOJO_NAME.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.txt_NOJO_NAME.DropDown.AllowDrop = False
        Me.txt_NOJO_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_NOJO_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_NOJO_NAME.Format = "Ｚ"
        Me.txt_NOJO_NAME.HighlightText = True
        Me.txt_NOJO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_NOJO_NAME.InputCheck = True
        Me.txt_NOJO_NAME.Location = New System.Drawing.Point(270, 558)
        Me.txt_NOJO_NAME.MaxLength = 40
        Me.txt_NOJO_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_NOJO_NAME.Name = "txt_NOJO_NAME"
        Me.txt_NOJO_NAME.Size = New System.Drawing.Size(325, 20)
        Me.txt_NOJO_NAME.TabIndex = 12
        Me.txt_NOJO_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(72, 561)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(67, 15)
        Me.Label24.TabIndex = 1090
        Me.Label24.Text = "■農場名"
        '
        'txt_ADDR_2
        '
        Me.txt_ADDR_2.DropDown.AllowDrop = False
        Me.txt_ADDR_2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_2.Format = "Ｚ"
        Me.txt_ADDR_2.HighlightText = True
        Me.txt_ADDR_2.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ADDR_2.InputCheck = True
        Me.txt_ADDR_2.Location = New System.Drawing.Point(460, 624)
        Me.txt_ADDR_2.MaxLength = 30
        Me.txt_ADDR_2.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_2.Name = "txt_ADDR_2"
        Me.txt_ADDR_2.Size = New System.Drawing.Size(243, 20)
        Me.txt_ADDR_2.TabIndex = 17
        Me.txt_ADDR_2.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(72, 630)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 15)
        Me.Label14.TabIndex = 1089
        Me.Label14.Text = "■住所"
        '
        'txt_ADDR_1
        '
        Me.txt_ADDR_1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txt_ADDR_1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_ADDR_1.DropDown.AllowDrop = False
        Me.txt_ADDR_1.Enabled = False
        Me.txt_ADDR_1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_1.Format = "Ｚ"
        Me.txt_ADDR_1.HighlightText = True
        Me.txt_ADDR_1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ADDR_1.InputCheck = True
        Me.txt_ADDR_1.Location = New System.Drawing.Point(377, 624)
        Me.txt_ADDR_1.MaxLength = 8
        Me.txt_ADDR_1.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_1.Name = "txt_ADDR_1"
        Me.txt_ADDR_1.Size = New System.Drawing.Size(77, 20)
        Me.txt_ADDR_1.TabIndex = 16
        Me.txt_ADDR_1.Text = "＠＠＠＠"
        '
        'msk_ADDR_POST
        '
        Me.msk_ADDR_POST.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        MaskLiteralField1.Text = "〒 "
        MaskPatternField1.MaxLength = 3
        MaskPatternField1.MinLength = 3
        MaskPatternField1.Pattern = "\D"
        MaskLiteralField2.Text = "-"
        MaskPatternField2.MaxLength = 4
        MaskPatternField2.MinLength = 4
        MaskPatternField2.Pattern = "\D"
        Me.msk_ADDR_POST.Fields.AddRange(New GrapeCity.Win.Editors.Fields.MaskField() {MaskLiteralField1, MaskPatternField1, MaskLiteralField2, MaskPatternField2})
        Me.msk_ADDR_POST.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.msk_ADDR_POST.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.msk_ADDR_POST.HighlightText = GrapeCity.Win.Editors.HighlightText.All
        Me.msk_ADDR_POST.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.msk_ADDR_POST.InputCheck = True
        Me.msk_ADDR_POST.Location = New System.Drawing.Point(270, 624)
        Me.msk_ADDR_POST.Name = "msk_ADDR_POST"
        Me.msk_ADDR_POST.Size = New System.Drawing.Size(101, 21)
        Me.msk_ADDR_POST.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(70, 526)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 15)
        Me.Label13.TabIndex = 1091
        Me.Label13.Text = "■農場番号"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(72, 593)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 1087
        Me.Label2.Text = "■都道府県"
        '
        'cob_KEN_CD
        '
        Me.cob_KEN_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_KEN_CD.DropDown.AllowDrop = False
        Me.cob_KEN_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEN_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEN_CD.Format = "9"
        Me.cob_KEN_CD.HighlightText = True
        Me.cob_KEN_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_KEN_CD.InputCheck = True
        Me.cob_KEN_CD.ListHeaderPane.Height = 22
        Me.cob_KEN_CD.Location = New System.Drawing.Point(270, 590)
        Me.cob_KEN_CD.MaxLength = 2
        Me.cob_KEN_CD.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.cob_KEN_CD.Name = "cob_KEN_CD"
        Me.cob_KEN_CD.Size = New System.Drawing.Size(36, 22)
        Me.cob_KEN_CD.Spin.AllowSpin = False
        Me.cob_KEN_CD.TabIndex = 13
        Me.cob_KEN_CD.Text = "99"
        '
        'cob_KEN_NM
        '
        Me.cob_KEN_NM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_KEN_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_KEN_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEN_NM.InputCheck = True
        Me.cob_KEN_NM.ListHeaderPane.Height = 22
        Me.cob_KEN_NM.ListHeaderPane.Visible = False
        Me.cob_KEN_NM.Location = New System.Drawing.Point(312, 590)
        Me.cob_KEN_NM.Name = "cob_KEN_NM"
        Me.cob_KEN_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cob_KEN_NM.Size = New System.Drawing.Size(119, 22)
        Me.cob_KEN_NM.TabIndex = 14
        Me.cob_KEN_NM.TabStop = False
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'frmGJ1013
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.txt_MEISAI_NO)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txt_ADDR_4)
        Me.Controls.Add(Me.txt_ADDR_3)
        Me.Controls.Add(Me.txt_NOJO_CD)
        Me.Controls.Add(Me.txt_NOJO_NAME)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txt_ADDR_2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txt_ADDR_1)
        Me.Controls.Add(Me.msk_ADDR_POST)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cob_KEN_CD)
        Me.Controls.Add(Me.cob_KEN_NM)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lbl_KI)
        Me.Controls.Add(Me.lbl_KEIYAKUSYA_NM)
        Me.Controls.Add(Me.lbl_KEIYAKUSYA_CD)
        Me.Controls.Add(Me.dgv_Search)
        Me.Controls.Add(Me.Label4)
        Me.Name = "frmGJ1013"
        Me.Text = "(GJ1013)互助基金契マスタメンテンテナンス(農場情報)"
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dgv_Search, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKUSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKUSYA_NM, 0)
        Me.Controls.SetChildIndex(Me.lbl_KI, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.cob_KEN_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_KEN_CD, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.msk_ADDR_POST, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_1, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_2, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.txt_NOJO_NAME, 0)
        Me.Controls.SetChildIndex(Me.txt_NOJO_CD, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_3, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_4, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.txt_MEISAI_NO, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.txt_MEISAI_NO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_NOJO_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txt_ADDR_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_NOJO_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.msk_ADDR_POST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEN_NM, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents dgv_Search As JBD.Gjs.Win.DataGridView
    Friend WithEvents lbl_KEIYAKUSYA_CD As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKUSYA_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KI As JBD.Gjs.Win.JLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents txt_MEISAI_NO As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents txt_ADDR_4 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_ADDR_3 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_NOJO_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_NOJO_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents txt_ADDR_2 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents txt_ADDR_1 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents msk_ADDR_POST As JBD.Gjs.Win.GcMask
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KEN_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEN_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents NOJO_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOJO_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEN_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MEISAI_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR_POST As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR_3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDR_4 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
