Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ3030
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.txt_KI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.DropDownButton14 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton15 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton16 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton17 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton18 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton19 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dgv_HdSearch = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.KEIYAKU_DATE_FROM_X = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_DATE_FROM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOTO_KEIYAKUSYA_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKUSYA_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYORI_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYORI_KBN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEIKYU_KAISU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdDel = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdUpd = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdIns = New JBD.Gjs.Win.JButton(Me.components)
        Me.date_KEIYAKU_DATE_FROM = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label28 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdCansel = New JBD.Gjs.Win.JButton(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label29 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblCOUNT = New JBD.Gjs.Win.Label(Me.components)
        Me.Label27 = New JBD.Gjs.Win.Label(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_SAKI_KEIYAKUSYA_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_SAKI_KEIYAKUSYA_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton5 = New GrapeCity.Win.Editors.DropDownButton()
        Me.pnl_SYORI_KBN = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_SYORI_KBN2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_SYORI_KBN1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdHdSearchClr = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdHdSearch = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdSeikyu = New JBD.Gjs.Win.JButton(Me.components)
        Me.lbl_SEIKYU_KBN_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_SAKI_KEIYAKU_KBN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.cmdDtlSearchClr = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdDtlSearch = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_MOTO_KEIYAKUSYA_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_MOTO_KEIYAKUSYA_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dgv_DtlSearch = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.CHK = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MOTO_NOJO_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOTO_NOJO_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOTO_NOJO_ADDR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TORI_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TORI_KBN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_HASU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOTO_SEQNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_KBN_MOTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdAllChk = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdNoChk = New JBD.Gjs.Win.JButton(Me.components)
        Me.lbl_MOTO_KEIYAKU_KBN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_HdSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_KEIYAKU_DATE_FROM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cob_SAKI_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_SAKI_KEIYAKUSYA_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_SYORI_KBN.SuspendLayout()
        CType(Me.cob_MOTO_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_MOTO_KEIYAKUSYA_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_DtlSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdSeikyu)
        Me.pnlButton.Controls.Add(Me.cmdCansel)
        Me.pnlButton.Controls.Add(Me.cmdSave)
        Me.pnlButton.TabIndex = 101
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSave, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCansel, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSeikyu, 0)
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
        Me.cmdEnd.Location = New System.Drawing.Point(989, 5)
        Me.cmdEnd.TabIndex = 99
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(12, 5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 44)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Text = "保存"
        Me.cmdSave.UseVisualStyleBackColor = True
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
        Me.txt_KI.Location = New System.Drawing.Point(176, 52)
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
        'dgv_HdSearch
        '
        Me.dgv_HdSearch.AllowUserToAddRows = False
        Me.dgv_HdSearch.AllowUserToDeleteRows = False
        Me.dgv_HdSearch.AllowUserToResizeRows = False
        Me.dgv_HdSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KEIYAKU_DATE_FROM_X, Me.KEIYAKU_DATE_FROM, Me.MOTO_KEIYAKUSYA_CD, Me.KEIYAKUSYA_NAME, Me.SYORI_KBN, Me.SYORI_KBN_NM, Me.SEIKYU_KAISU})
        Me.dgv_HdSearch.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_HdSearch.Location = New System.Drawing.Point(146, 143)
        Me.dgv_HdSearch.MultiSelect = False
        Me.dgv_HdSearch.Name = "dgv_HdSearch"
        Me.dgv_HdSearch.ReadOnly = True
        Me.dgv_HdSearch.RowHeadersVisible = False
        Me.dgv_HdSearch.RowTemplate.Height = 21
        Me.dgv_HdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_HdSearch.Size = New System.Drawing.Size(640, 132)
        Me.dgv_HdSearch.StandardTab = True
        Me.dgv_HdSearch.TabIndex = 11
        '
        'KEIYAKU_DATE_FROM_X
        '
        Me.KEIYAKU_DATE_FROM_X.DataPropertyName = "KEIYAKU_DATE_FROM_X"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKU_DATE_FROM_X.DefaultCellStyle = DataGridViewCellStyle1
        Me.KEIYAKU_DATE_FROM_X.HeaderText = "変更年月日"
        Me.KEIYAKU_DATE_FROM_X.Name = "KEIYAKU_DATE_FROM_X"
        Me.KEIYAKU_DATE_FROM_X.ReadOnly = True
        Me.KEIYAKU_DATE_FROM_X.Width = 120
        '
        'KEIYAKU_DATE_FROM
        '
        Me.KEIYAKU_DATE_FROM.DataPropertyName = "KEIYAKU_DATE_FROM"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKU_DATE_FROM.DefaultCellStyle = DataGridViewCellStyle2
        Me.KEIYAKU_DATE_FROM.HeaderText = "変更年月日(西暦)"
        Me.KEIYAKU_DATE_FROM.Name = "KEIYAKU_DATE_FROM"
        Me.KEIYAKU_DATE_FROM.ReadOnly = True
        Me.KEIYAKU_DATE_FROM.Visible = False
        '
        'MOTO_KEIYAKUSYA_CD
        '
        Me.MOTO_KEIYAKUSYA_CD.DataPropertyName = "MOTO_KEIYAKUSYA_CD"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MOTO_KEIYAKUSYA_CD.DefaultCellStyle = DataGridViewCellStyle3
        Me.MOTO_KEIYAKUSYA_CD.HeaderText = "元契約者コード"
        Me.MOTO_KEIYAKUSYA_CD.Name = "MOTO_KEIYAKUSYA_CD"
        Me.MOTO_KEIYAKUSYA_CD.ReadOnly = True
        Me.MOTO_KEIYAKUSYA_CD.Visible = False
        '
        'KEIYAKUSYA_NAME
        '
        Me.KEIYAKUSYA_NAME.DataPropertyName = "KEIYAKUSYA_NAME"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.KEIYAKUSYA_NAME.DefaultCellStyle = DataGridViewCellStyle4
        Me.KEIYAKUSYA_NAME.HeaderText = "契約者名(譲渡元)"
        Me.KEIYAKUSYA_NAME.Name = "KEIYAKUSYA_NAME"
        Me.KEIYAKUSYA_NAME.ReadOnly = True
        Me.KEIYAKUSYA_NAME.Width = 300
        '
        'SYORI_KBN
        '
        Me.SYORI_KBN.DataPropertyName = "SYORI_KBN"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYORI_KBN.DefaultCellStyle = DataGridViewCellStyle5
        Me.SYORI_KBN.HeaderText = "処理区分CD"
        Me.SYORI_KBN.Name = "SYORI_KBN"
        Me.SYORI_KBN.ReadOnly = True
        Me.SYORI_KBN.Visible = False
        '
        'SYORI_KBN_NM
        '
        Me.SYORI_KBN_NM.DataPropertyName = "SYORI_KBN_NM"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYORI_KBN_NM.DefaultCellStyle = DataGridViewCellStyle6
        Me.SYORI_KBN_NM.HeaderText = "処理状況"
        Me.SYORI_KBN_NM.Name = "SYORI_KBN_NM"
        Me.SYORI_KBN_NM.ReadOnly = True
        '
        'SEIKYU_KAISU
        '
        Me.SEIKYU_KAISU.DataPropertyName = "SEIKYU_KAISU"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEIKYU_KAISU.DefaultCellStyle = DataGridViewCellStyle7
        Me.SEIKYU_KAISU.HeaderText = "請求回数"
        Me.SEIKYU_KAISU.Name = "SEIKYU_KAISU"
        Me.SEIKYU_KAISU.ReadOnly = True
        '
        'cmdDel
        '
        Me.cmdDel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDel.Location = New System.Drawing.Point(644, 281)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(92, 44)
        Me.cmdDel.TabIndex = 14
        Me.cmdDel.Text = "削除"
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdUpd
        '
        Me.cmdUpd.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdUpd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUpd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdUpd.Location = New System.Drawing.Point(253, 281)
        Me.cmdUpd.Name = "cmdUpd"
        Me.cmdUpd.Size = New System.Drawing.Size(92, 44)
        Me.cmdUpd.TabIndex = 13
        Me.cmdUpd.Text = "変更(表示)"
        Me.cmdUpd.UseVisualStyleBackColor = True
        '
        'cmdIns
        '
        Me.cmdIns.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdIns.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdIns.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIns.Location = New System.Drawing.Point(146, 281)
        Me.cmdIns.Name = "cmdIns"
        Me.cmdIns.Size = New System.Drawing.Size(92, 44)
        Me.cmdIns.TabIndex = 12
        Me.cmdIns.Text = "新規登録"
        Me.cmdIns.UseVisualStyleBackColor = True
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
        Me.date_KEIYAKU_DATE_FROM.Location = New System.Drawing.Point(199, 669)
        Me.date_KEIYAKU_DATE_FROM.Name = "date_KEIYAKU_DATE_FROM"
        Me.date_KEIYAKU_DATE_FROM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.date_KEIYAKU_DATE_FROM.Size = New System.Drawing.Size(125, 21)
        Me.date_KEIYAKU_DATE_FROM.Spin.AllowSpin = False
        Me.date_KEIYAKU_DATE_FROM.TabIndex = 36
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
        Me.Label28.Location = New System.Drawing.Point(70, 669)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(97, 15)
        Me.Label28.TabIndex = 63
        Me.Label28.Text = "■譲渡年月日"
        '
        'cmdCansel
        '
        Me.cmdCansel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCansel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCansel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCansel.Location = New System.Drawing.Point(129, 5)
        Me.cmdCansel.Name = "cmdCansel"
        Me.cmdCansel.Size = New System.Drawing.Size(92, 44)
        Me.cmdCansel.TabIndex = 1
        Me.cmdCansel.Text = "キャンセル"
        Me.cmdCansel.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label29)
        Me.Panel2.Controls.Add(Me.lblCOUNT)
        Me.Panel2.Controls.Add(Me.Label27)
        Me.Panel2.Location = New System.Drawing.Point(26, 110)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1042, 25)
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
        Me.Label10.Text = "１．契約農場別明細　譲渡情報（表示）"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.Location = New System.Drawing.Point(599, 5)
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
        Me.lblCOUNT.Location = New System.Drawing.Point(670, 5)
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
        Me.Label27.Location = New System.Drawing.Point(727, 5)
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
        Me.Panel1.Location = New System.Drawing.Point(26, 334)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1042, 25)
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
        Me.Label11.Size = New System.Drawing.Size(353, 19)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "２．契約農場別明細　譲渡元情報（選択）"
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
        Me.Label18.Size = New System.Drawing.Size(122, 15)
        Me.Label18.TabIndex = 1105
        Me.Label18.Text = "■契約者(譲渡先)"
        '
        'cob_SAKI_KEIYAKUSYA_CD
        '
        Me.cob_SAKI_KEIYAKUSYA_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_SAKI_KEIYAKUSYA_CD.DropDown.AllowDrop = False
        Me.cob_SAKI_KEIYAKUSYA_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_SAKI_KEIYAKUSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_SAKI_KEIYAKUSYA_CD.Format = "9"
        Me.cob_SAKI_KEIYAKUSYA_CD.HighlightText = True
        Me.cob_SAKI_KEIYAKUSYA_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_SAKI_KEIYAKUSYA_CD.InputCheck = True
        Me.cob_SAKI_KEIYAKUSYA_CD.ListHeaderPane.Height = 22
        Me.cob_SAKI_KEIYAKUSYA_CD.Location = New System.Drawing.Point(176, 77)
        Me.cob_SAKI_KEIYAKUSYA_CD.MaxLength = 5
        Me.cob_SAKI_KEIYAKUSYA_CD.Name = "cob_SAKI_KEIYAKUSYA_CD"
        Me.cob_SAKI_KEIYAKUSYA_CD.Size = New System.Drawing.Size(51, 22)
        Me.cob_SAKI_KEIYAKUSYA_CD.Spin.AllowSpin = False
        Me.cob_SAKI_KEIYAKUSYA_CD.TabIndex = 1
        Me.cob_SAKI_KEIYAKUSYA_CD.Tag = "都道府県"
        Me.cob_SAKI_KEIYAKUSYA_CD.Text = "00000"
        '
        'cob_SAKI_KEIYAKUSYA_NM
        '
        Me.cob_SAKI_KEIYAKUSYA_NM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_SAKI_KEIYAKUSYA_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_SAKI_KEIYAKUSYA_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_SAKI_KEIYAKUSYA_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_SAKI_KEIYAKUSYA_NM.InputCheck = True
        Me.cob_SAKI_KEIYAKUSYA_NM.ListHeaderPane.Height = 22
        Me.cob_SAKI_KEIYAKUSYA_NM.ListHeaderPane.Visible = False
        Me.cob_SAKI_KEIYAKUSYA_NM.Location = New System.Drawing.Point(233, 77)
        Me.cob_SAKI_KEIYAKUSYA_NM.Name = "cob_SAKI_KEIYAKUSYA_NM"
        Me.cob_SAKI_KEIYAKUSYA_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.cob_SAKI_KEIYAKUSYA_NM.Size = New System.Drawing.Size(415, 22)
        Me.cob_SAKI_KEIYAKUSYA_NM.TabIndex = 2
        Me.cob_SAKI_KEIYAKUSYA_NM.TabStop = False
        '
        'DropDownButton5
        '
        Me.DropDownButton5.Name = "DropDownButton5"
        '
        'pnl_SYORI_KBN
        '
        Me.pnl_SYORI_KBN.Controls.Add(Me.rbtn_SYORI_KBN2)
        Me.pnl_SYORI_KBN.Controls.Add(Me.rbtn_SYORI_KBN1)
        Me.pnl_SYORI_KBN.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.pnl_SYORI_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.pnl_SYORI_KBN.Location = New System.Drawing.Point(197, 694)
        Me.pnl_SYORI_KBN.Name = "pnl_SYORI_KBN"
        Me.pnl_SYORI_KBN.Size = New System.Drawing.Size(207, 38)
        Me.pnl_SYORI_KBN.TabIndex = 37
        Me.pnl_SYORI_KBN.TabStop = False
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
        Me.Label19.Location = New System.Drawing.Point(70, 708)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 15)
        Me.Label19.TabIndex = 1108
        Me.Label19.Text = "■入力確認有無"
        '
        'cmdHdSearchClr
        '
        Me.cmdHdSearchClr.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdHdSearchClr.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHdSearchClr.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdHdSearchClr.Location = New System.Drawing.Point(784, 67)
        Me.cmdHdSearchClr.Name = "cmdHdSearchClr"
        Me.cmdHdSearchClr.Size = New System.Drawing.Size(94, 35)
        Me.cmdHdSearchClr.TabIndex = 4
        Me.cmdHdSearchClr.TabStop = False
        Me.cmdHdSearchClr.Text = "条件クリア"
        Me.cmdHdSearchClr.UseVisualStyleBackColor = True
        '
        'cmdHdSearch
        '
        Me.cmdHdSearch.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdHdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHdSearch.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdHdSearch.Location = New System.Drawing.Point(672, 67)
        Me.cmdHdSearch.Name = "cmdHdSearch"
        Me.cmdHdSearch.Size = New System.Drawing.Size(94, 35)
        Me.cmdHdSearch.TabIndex = 3
        Me.cmdHdSearch.Text = "検索"
        Me.cmdHdSearch.UseVisualStyleBackColor = True
        '
        'cmdSeikyu
        '
        Me.cmdSeikyu.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSeikyu.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSeikyu.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSeikyu.Location = New System.Drawing.Point(399, 5)
        Me.cmdSeikyu.Name = "cmdSeikyu"
        Me.cmdSeikyu.Size = New System.Drawing.Size(92, 44)
        Me.cmdSeikyu.TabIndex = 2
        Me.cmdSeikyu.Text = "通知書発行"
        Me.cmdSeikyu.UseVisualStyleBackColor = True
        '
        'lbl_SEIKYU_KBN_NM
        '
        Me.lbl_SEIKYU_KBN_NM.AutoSize = True
        Me.lbl_SEIKYU_KBN_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_SEIKYU_KBN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_SEIKYU_KBN_NM.Location = New System.Drawing.Point(414, 708)
        Me.lbl_SEIKYU_KBN_NM.Name = "lbl_SEIKYU_KBN_NM"
        Me.lbl_SEIKYU_KBN_NM.Size = New System.Drawing.Size(97, 15)
        Me.lbl_SEIKYU_KBN_NM.TabIndex = 1139
        Me.lbl_SEIKYU_KBN_NM.Text = "請求書発行済"
        '
        'lbl_SAKI_KEIYAKU_KBN
        '
        Me.lbl_SAKI_KEIYAKU_KBN.AutoSize = True
        Me.lbl_SAKI_KEIYAKU_KBN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_SAKI_KEIYAKU_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_SAKI_KEIYAKU_KBN.Location = New System.Drawing.Point(654, 80)
        Me.lbl_SAKI_KEIYAKU_KBN.Name = "lbl_SAKI_KEIYAKU_KBN"
        Me.lbl_SAKI_KEIYAKU_KBN.Size = New System.Drawing.Size(15, 15)
        Me.lbl_SAKI_KEIYAKU_KBN.TabIndex = 1141
        Me.lbl_SAKI_KEIYAKU_KBN.Text = "9"
        Me.lbl_SAKI_KEIYAKU_KBN.Visible = False
        '
        'cmdDtlSearchClr
        '
        Me.cmdDtlSearchClr.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdDtlSearchClr.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDtlSearchClr.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDtlSearchClr.Location = New System.Drawing.Point(784, 366)
        Me.cmdDtlSearchClr.Name = "cmdDtlSearchClr"
        Me.cmdDtlSearchClr.Size = New System.Drawing.Size(94, 35)
        Me.cmdDtlSearchClr.TabIndex = 24
        Me.cmdDtlSearchClr.TabStop = False
        Me.cmdDtlSearchClr.Text = "条件クリア"
        Me.cmdDtlSearchClr.UseVisualStyleBackColor = True
        '
        'cmdDtlSearch
        '
        Me.cmdDtlSearch.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdDtlSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDtlSearch.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDtlSearch.Location = New System.Drawing.Point(672, 366)
        Me.cmdDtlSearch.Name = "cmdDtlSearch"
        Me.cmdDtlSearch.Size = New System.Drawing.Size(94, 35)
        Me.cmdDtlSearch.TabIndex = 23
        Me.cmdDtlSearch.Text = "検索"
        Me.cmdDtlSearch.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(44, 376)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 1149
        Me.Label6.Text = "■契約者"
        '
        'cob_MOTO_KEIYAKUSYA_CD
        '
        Me.cob_MOTO_KEIYAKUSYA_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_MOTO_KEIYAKUSYA_CD.DropDown.AllowDrop = False
        Me.cob_MOTO_KEIYAKUSYA_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_MOTO_KEIYAKUSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_MOTO_KEIYAKUSYA_CD.Format = "9"
        Me.cob_MOTO_KEIYAKUSYA_CD.HighlightText = True
        Me.cob_MOTO_KEIYAKUSYA_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_MOTO_KEIYAKUSYA_CD.InputCheck = True
        Me.cob_MOTO_KEIYAKUSYA_CD.ListHeaderPane.Height = 22
        Me.cob_MOTO_KEIYAKUSYA_CD.Location = New System.Drawing.Point(176, 373)
        Me.cob_MOTO_KEIYAKUSYA_CD.MaxLength = 5
        Me.cob_MOTO_KEIYAKUSYA_CD.Name = "cob_MOTO_KEIYAKUSYA_CD"
        Me.cob_MOTO_KEIYAKUSYA_CD.Size = New System.Drawing.Size(51, 22)
        Me.cob_MOTO_KEIYAKUSYA_CD.Spin.AllowSpin = False
        Me.cob_MOTO_KEIYAKUSYA_CD.TabIndex = 21
        Me.cob_MOTO_KEIYAKUSYA_CD.Tag = "都道府県"
        Me.cob_MOTO_KEIYAKUSYA_CD.Text = "00000"
        '
        'cob_MOTO_KEIYAKUSYA_NM
        '
        Me.cob_MOTO_KEIYAKUSYA_NM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_MOTO_KEIYAKUSYA_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_MOTO_KEIYAKUSYA_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_MOTO_KEIYAKUSYA_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_MOTO_KEIYAKUSYA_NM.InputCheck = True
        Me.cob_MOTO_KEIYAKUSYA_NM.ListHeaderPane.Height = 22
        Me.cob_MOTO_KEIYAKUSYA_NM.ListHeaderPane.Visible = False
        Me.cob_MOTO_KEIYAKUSYA_NM.Location = New System.Drawing.Point(233, 373)
        Me.cob_MOTO_KEIYAKUSYA_NM.Name = "cob_MOTO_KEIYAKUSYA_NM"
        Me.cob_MOTO_KEIYAKUSYA_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.cob_MOTO_KEIYAKUSYA_NM.Size = New System.Drawing.Size(415, 22)
        Me.cob_MOTO_KEIYAKUSYA_NM.TabIndex = 22
        Me.cob_MOTO_KEIYAKUSYA_NM.TabStop = False
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'dgv_DtlSearch
        '
        Me.dgv_DtlSearch.AllowUserToAddRows = False
        Me.dgv_DtlSearch.AllowUserToDeleteRows = False
        Me.dgv_DtlSearch.AllowUserToResizeRows = False
        Me.dgv_DtlSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHK, Me.MOTO_NOJO_CD, Me.MOTO_NOJO_NM, Me.MOTO_NOJO_ADDR, Me.TORI_KBN, Me.TORI_KBN_NM, Me.KEIYAKU_HASU, Me.MOTO_SEQNO, Me.KEIYAKU_KBN_MOTO})
        Me.dgv_DtlSearch.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_DtlSearch.Location = New System.Drawing.Point(139, 408)
        Me.dgv_DtlSearch.MultiSelect = False
        Me.dgv_DtlSearch.Name = "dgv_DtlSearch"
        Me.dgv_DtlSearch.RowHeadersVisible = False
        Me.dgv_DtlSearch.RowTemplate.Height = 21
        Me.dgv_DtlSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_DtlSearch.Size = New System.Drawing.Size(942, 255)
        Me.dgv_DtlSearch.StandardTab = True
        Me.dgv_DtlSearch.TabIndex = 33
        '
        'CHK
        '
        Me.CHK.DataPropertyName = "CHK"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle8.NullValue = False
        Me.CHK.DefaultCellStyle = DataGridViewCellStyle8
        Me.CHK.FalseValue = "0"
        Me.CHK.HeaderText = "選択"
        Me.CHK.Name = "CHK"
        Me.CHK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CHK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CHK.TrueValue = "1"
        Me.CHK.Width = 50
        '
        'MOTO_NOJO_CD
        '
        Me.MOTO_NOJO_CD.DataPropertyName = "MOTO_NOJO_CD"
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MOTO_NOJO_CD.DefaultCellStyle = DataGridViewCellStyle9
        Me.MOTO_NOJO_CD.HeaderText = "農場CD(譲渡元)"
        Me.MOTO_NOJO_CD.Name = "MOTO_NOJO_CD"
        Me.MOTO_NOJO_CD.ReadOnly = True
        Me.MOTO_NOJO_CD.Visible = False
        '
        'MOTO_NOJO_NM
        '
        Me.MOTO_NOJO_NM.DataPropertyName = "MOTO_NOJO_NM"
        DataGridViewCellStyle10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.MOTO_NOJO_NM.DefaultCellStyle = DataGridViewCellStyle10
        Me.MOTO_NOJO_NM.HeaderText = "農場名(譲渡元)"
        Me.MOTO_NOJO_NM.Name = "MOTO_NOJO_NM"
        Me.MOTO_NOJO_NM.ReadOnly = True
        Me.MOTO_NOJO_NM.Width = 200
        '
        'MOTO_NOJO_ADDR
        '
        Me.MOTO_NOJO_ADDR.DataPropertyName = "MOTO_NOJO_ADDR"
        DataGridViewCellStyle11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MOTO_NOJO_ADDR.DefaultCellStyle = DataGridViewCellStyle11
        Me.MOTO_NOJO_ADDR.HeaderText = "農場住所"
        Me.MOTO_NOJO_ADDR.Name = "MOTO_NOJO_ADDR"
        Me.MOTO_NOJO_ADDR.ReadOnly = True
        Me.MOTO_NOJO_ADDR.Width = 450
        '
        'TORI_KBN
        '
        Me.TORI_KBN.DataPropertyName = "TORI_KBN"
        DataGridViewCellStyle12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TORI_KBN.DefaultCellStyle = DataGridViewCellStyle12
        Me.TORI_KBN.HeaderText = "鶏の種類CD"
        Me.TORI_KBN.Name = "TORI_KBN"
        Me.TORI_KBN.ReadOnly = True
        Me.TORI_KBN.Visible = False
        '
        'TORI_KBN_NM
        '
        Me.TORI_KBN_NM.DataPropertyName = "TORI_KBN_NM"
        DataGridViewCellStyle13.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TORI_KBN_NM.DefaultCellStyle = DataGridViewCellStyle13
        Me.TORI_KBN_NM.HeaderText = "鶏の種類"
        Me.TORI_KBN_NM.Name = "TORI_KBN_NM"
        Me.TORI_KBN_NM.ReadOnly = True
        Me.TORI_KBN_NM.Width = 120
        '
        'KEIYAKU_HASU
        '
        Me.KEIYAKU_HASU.DataPropertyName = "KEIYAKU_HASU"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKU_HASU.DefaultCellStyle = DataGridViewCellStyle14
        Me.KEIYAKU_HASU.HeaderText = "契約羽数"
        Me.KEIYAKU_HASU.Name = "KEIYAKU_HASU"
        Me.KEIYAKU_HASU.ReadOnly = True
        '
        'MOTO_SEQNO
        '
        Me.MOTO_SEQNO.DataPropertyName = "MOTO_SEQNO"
        DataGridViewCellStyle15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MOTO_SEQNO.DefaultCellStyle = DataGridViewCellStyle15
        Me.MOTO_SEQNO.HeaderText = "SEQNO(譲渡元)"
        Me.MOTO_SEQNO.Name = "MOTO_SEQNO"
        Me.MOTO_SEQNO.Visible = False
        '
        'KEIYAKU_KBN_MOTO
        '
        Me.KEIYAKU_KBN_MOTO.DataPropertyName = "KEIYAKU_KBN_MOTO"
        DataGridViewCellStyle16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        DataGridViewCellStyle16.Format = "N0"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.KEIYAKU_KBN_MOTO.DefaultCellStyle = DataGridViewCellStyle16
        Me.KEIYAKU_KBN_MOTO.HeaderText = "契約区分CD(変更前)"
        Me.KEIYAKU_KBN_MOTO.Name = "KEIYAKU_KBN_MOTO"
        Me.KEIYAKU_KBN_MOTO.ReadOnly = True
        Me.KEIYAKU_KBN_MOTO.Visible = False
        '
        'cmdAllChk
        '
        Me.cmdAllChk.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdAllChk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAllChk.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdAllChk.Location = New System.Drawing.Point(47, 408)
        Me.cmdAllChk.Name = "cmdAllChk"
        Me.cmdAllChk.Size = New System.Drawing.Size(73, 25)
        Me.cmdAllChk.TabIndex = 31
        Me.cmdAllChk.Text = "全選択"
        Me.cmdAllChk.UseVisualStyleBackColor = True
        '
        'cmdNoChk
        '
        Me.cmdNoChk.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdNoChk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNoChk.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdNoChk.Location = New System.Drawing.Point(47, 439)
        Me.cmdNoChk.Name = "cmdNoChk"
        Me.cmdNoChk.Size = New System.Drawing.Size(73, 25)
        Me.cmdNoChk.TabIndex = 32
        Me.cmdNoChk.Text = "全解除"
        Me.cmdNoChk.UseVisualStyleBackColor = True
        '
        'lbl_MOTO_KEIYAKU_KBN
        '
        Me.lbl_MOTO_KEIYAKU_KBN.AutoSize = True
        Me.lbl_MOTO_KEIYAKU_KBN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_MOTO_KEIYAKU_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_MOTO_KEIYAKU_KBN.Location = New System.Drawing.Point(654, 376)
        Me.lbl_MOTO_KEIYAKU_KBN.Name = "lbl_MOTO_KEIYAKU_KBN"
        Me.lbl_MOTO_KEIYAKU_KBN.Size = New System.Drawing.Size(15, 15)
        Me.lbl_MOTO_KEIYAKU_KBN.TabIndex = 1150
        Me.lbl_MOTO_KEIYAKU_KBN.Text = "9"
        Me.lbl_MOTO_KEIYAKU_KBN.Visible = False
        '
        'frmGJ3030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.lbl_MOTO_KEIYAKU_KBN)
        Me.Controls.Add(Me.cmdNoChk)
        Me.Controls.Add(Me.cmdAllChk)
        Me.Controls.Add(Me.dgv_DtlSearch)
        Me.Controls.Add(Me.cmdDtlSearchClr)
        Me.Controls.Add(Me.cmdDtlSearch)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cob_MOTO_KEIYAKUSYA_CD)
        Me.Controls.Add(Me.cob_MOTO_KEIYAKUSYA_NM)
        Me.Controls.Add(Me.lbl_SAKI_KEIYAKU_KBN)
        Me.Controls.Add(Me.lbl_SEIKYU_KBN_NM)
        Me.Controls.Add(Me.cmdHdSearchClr)
        Me.Controls.Add(Me.cmdHdSearch)
        Me.Controls.Add(Me.pnl_SYORI_KBN)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txt_KI)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cob_SAKI_KEIYAKUSYA_CD)
        Me.Controls.Add(Me.cob_SAKI_KEIYAKUSYA_NM)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.date_KEIYAKU_DATE_FROM)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdUpd)
        Me.Controls.Add(Me.cmdIns)
        Me.Controls.Add(Me.dgv_HdSearch)
        Me.Name = "frmGJ3030"
        Me.Text = "(GJ3030)互助基金契約者情報変更（譲渡）"
        Me.Controls.SetChildIndex(Me.dgv_HdSearch, 0)
        Me.Controls.SetChildIndex(Me.cmdIns, 0)
        Me.Controls.SetChildIndex(Me.cmdUpd, 0)
        Me.Controls.SetChildIndex(Me.cmdDel, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.date_KEIYAKU_DATE_FROM, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.cob_SAKI_KEIYAKUSYA_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_SAKI_KEIYAKUSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txt_KI, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.pnl_SYORI_KBN, 0)
        Me.Controls.SetChildIndex(Me.cmdHdSearch, 0)
        Me.Controls.SetChildIndex(Me.cmdHdSearchClr, 0)
        Me.Controls.SetChildIndex(Me.lbl_SEIKYU_KBN_NM, 0)
        Me.Controls.SetChildIndex(Me.lbl_SAKI_KEIYAKU_KBN, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.cob_MOTO_KEIYAKUSYA_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_MOTO_KEIYAKUSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.cmdDtlSearch, 0)
        Me.Controls.SetChildIndex(Me.cmdDtlSearchClr, 0)
        Me.Controls.SetChildIndex(Me.dgv_DtlSearch, 0)
        Me.Controls.SetChildIndex(Me.cmdAllChk, 0)
        Me.Controls.SetChildIndex(Me.cmdNoChk, 0)
        Me.Controls.SetChildIndex(Me.lbl_MOTO_KEIYAKU_KBN, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_HdSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_KEIYAKU_DATE_FROM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cob_SAKI_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_SAKI_KEIYAKUSYA_NM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_SYORI_KBN.ResumeLayout(False)
        Me.pnl_SYORI_KBN.PerformLayout()
        CType(Me.cob_MOTO_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_MOTO_KEIYAKUSYA_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_DtlSearch, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgv_HdSearch As JBD.Gjs.Win.DataGridView
    Friend WithEvents cmdDel As JBD.Gjs.Win.JButton
    Friend WithEvents cmdUpd As JBD.Gjs.Win.JButton
    Friend WithEvents cmdIns As JBD.Gjs.Win.JButton
    Friend WithEvents date_KEIYAKU_DATE_FROM As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label28 As JBD.Gjs.Win.Label
    Friend WithEvents cmdCansel As JBD.Gjs.Win.JButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents cob_SAKI_KEIYAKUSYA_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_SAKI_KEIYAKUSYA_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton5 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents pnl_SYORI_KBN As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtn_SYORI_KBN2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_SYORI_KBN1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents cmdHdSearchClr As JBD.Gjs.Win.JButton
    Friend WithEvents cmdHdSearch As JBD.Gjs.Win.JButton
    Friend WithEvents Label29 As JBD.Gjs.Win.Label
    Friend WithEvents lblCOUNT As JBD.Gjs.Win.Label
    Friend WithEvents Label27 As JBD.Gjs.Win.Label
    Friend WithEvents cmdSeikyu As JBD.Gjs.Win.JButton
    Friend WithEvents lbl_SEIKYU_KBN_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_SAKI_KEIYAKU_KBN As JBD.Gjs.Win.JLabel
    Friend WithEvents cmdDtlSearchClr As JBD.Gjs.Win.JButton
    Friend WithEvents cmdDtlSearch As JBD.Gjs.Win.JButton
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents cob_MOTO_KEIYAKUSYA_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_MOTO_KEIYAKUSYA_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents dgv_DtlSearch As JBD.Gjs.Win.DataGridView
    Friend WithEvents cmdAllChk As JBD.Gjs.Win.JButton
    Friend WithEvents cmdNoChk As JBD.Gjs.Win.JButton
    Friend WithEvents KEIYAKU_DATE_FROM_X As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_DATE_FROM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOTO_KEIYAKUSYA_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKUSYA_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SYORI_KBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SYORI_KBN_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEIKYU_KAISU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbl_MOTO_KEIYAKU_KBN As JBD.Gjs.Win.JLabel
    Friend WithEvents CHK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MOTO_NOJO_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOTO_NOJO_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOTO_NOJO_ADDR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TORI_KBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TORI_KBN_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_HASU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOTO_SEQNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_KBN_MOTO As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
