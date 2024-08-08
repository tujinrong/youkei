Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ3020
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
        Me.KEIYAKU_KBN_MAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_KBN_MAE_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_KBN_ATO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_KBN_ATO_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYORI_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYORI_KBN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEIKYU_KAISU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdDel = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdUpd = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdIns = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.date_KEIYAKU_DATE_FROM = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label28 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdCansel = New JBD.Gjs.Win.JButton(Me.components)
        Me.lbl_KEIYAKU_KBN_MAE = New JBD.Gjs.Win.JLabel(Me.components)
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
        Me.pnl_SYORI_KBN = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_SYORI_KBN2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_SYORI_KBN1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_KEIYAKU_KBN_ATO = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdSearchClr = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdSearch = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdSeikyu = New JBD.Gjs.Win.JButton(Me.components)
        Me.lbl_SEIKYU_KBN_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKU_KBN_NOW = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_KEIYAKU_KBN_MAE_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKU_KBN_ATO_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKU_KBN_NOW_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_KEIYAKU_DATE_FROM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cob_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKUSYA_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_SYORI_KBN.SuspendLayout()
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
        Me.txt_KI.Location = New System.Drawing.Point(146, 52)
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
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KEIYAKU_DATE_FROM_X, Me.KEIYAKU_DATE_FROM, Me.KEIYAKU_KBN_MAE, Me.KEIYAKU_KBN_MAE_NM, Me.KEIYAKU_KBN_ATO, Me.KEIYAKU_KBN_ATO_NM, Me.SYORI_KBN, Me.SYORI_KBN_NM, Me.SEIKYU_KAISU})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(146, 159)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(632, 323)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 11
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
        'KEIYAKU_KBN_MAE
        '
        Me.KEIYAKU_KBN_MAE.DataPropertyName = "KEIYAKU_KBN_MAE"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKU_KBN_MAE.DefaultCellStyle = DataGridViewCellStyle3
        Me.KEIYAKU_KBN_MAE.HeaderText = "契約区分CD(変更前)"
        Me.KEIYAKU_KBN_MAE.Name = "KEIYAKU_KBN_MAE"
        Me.KEIYAKU_KBN_MAE.ReadOnly = True
        Me.KEIYAKU_KBN_MAE.Visible = False
        '
        'KEIYAKU_KBN_MAE_NM
        '
        Me.KEIYAKU_KBN_MAE_NM.DataPropertyName = "KEIYAKU_KBN_MAE_NM"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.KEIYAKU_KBN_MAE_NM.DefaultCellStyle = DataGridViewCellStyle4
        Me.KEIYAKU_KBN_MAE_NM.HeaderText = "契約区分(変更前)"
        Me.KEIYAKU_KBN_MAE_NM.Name = "KEIYAKU_KBN_MAE_NM"
        Me.KEIYAKU_KBN_MAE_NM.ReadOnly = True
        Me.KEIYAKU_KBN_MAE_NM.Width = 150
        '
        'KEIYAKU_KBN_ATO
        '
        Me.KEIYAKU_KBN_ATO.DataPropertyName = "KEIYAKU_KBN_ATO"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.KEIYAKU_KBN_ATO.DefaultCellStyle = DataGridViewCellStyle5
        Me.KEIYAKU_KBN_ATO.HeaderText = "契約区分CD(変更後)"
        Me.KEIYAKU_KBN_ATO.Name = "KEIYAKU_KBN_ATO"
        Me.KEIYAKU_KBN_ATO.ReadOnly = True
        Me.KEIYAKU_KBN_ATO.Visible = False
        '
        'KEIYAKU_KBN_ATO_NM
        '
        Me.KEIYAKU_KBN_ATO_NM.DataPropertyName = "KEIYAKU_KBN_ATO_NM"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.KEIYAKU_KBN_ATO_NM.DefaultCellStyle = DataGridViewCellStyle6
        Me.KEIYAKU_KBN_ATO_NM.HeaderText = "契約区分(変更後)"
        Me.KEIYAKU_KBN_ATO_NM.Name = "KEIYAKU_KBN_ATO_NM"
        Me.KEIYAKU_KBN_ATO_NM.ReadOnly = True
        Me.KEIYAKU_KBN_ATO_NM.Width = 150
        '
        'SYORI_KBN
        '
        Me.SYORI_KBN.DataPropertyName = "SYORI_KBN"
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYORI_KBN.DefaultCellStyle = DataGridViewCellStyle7
        Me.SYORI_KBN.HeaderText = "処理区分CD"
        Me.SYORI_KBN.Name = "SYORI_KBN"
        Me.SYORI_KBN.ReadOnly = True
        Me.SYORI_KBN.Visible = False
        '
        'SYORI_KBN_NM
        '
        Me.SYORI_KBN_NM.DataPropertyName = "SYORI_KBN_NM"
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYORI_KBN_NM.DefaultCellStyle = DataGridViewCellStyle8
        Me.SYORI_KBN_NM.HeaderText = "処理状況"
        Me.SYORI_KBN_NM.Name = "SYORI_KBN_NM"
        Me.SYORI_KBN_NM.ReadOnly = True
        Me.SYORI_KBN_NM.Width = 90
        '
        'SEIKYU_KAISU
        '
        Me.SEIKYU_KAISU.DataPropertyName = "SEIKYU_KAISU"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEIKYU_KAISU.DefaultCellStyle = DataGridViewCellStyle9
        Me.SEIKYU_KAISU.HeaderText = "請求回数"
        Me.SEIKYU_KAISU.Name = "SEIKYU_KAISU"
        Me.SEIKYU_KAISU.ReadOnly = True
        '
        'cmdDel
        '
        Me.cmdDel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDel.Location = New System.Drawing.Point(644, 497)
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
        Me.cmdUpd.Location = New System.Drawing.Point(253, 497)
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
        Me.cmdIns.Location = New System.Drawing.Point(146, 497)
        Me.cmdIns.Name = "cmdIns"
        Me.cmdIns.Size = New System.Drawing.Size(92, 44)
        Me.cmdIns.TabIndex = 12
        Me.cmdIns.Text = "新規登録"
        Me.cmdIns.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(116, 641)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 15)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "契約区分(変更前)"
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
        Me.date_KEIYAKU_DATE_FROM.Location = New System.Drawing.Point(199, 603)
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
        Me.Label28.Location = New System.Drawing.Point(70, 603)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(97, 15)
        Me.Label28.TabIndex = 63
        Me.Label28.Text = "■変更年月日"
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
        'lbl_KEIYAKU_KBN_MAE
        '
        Me.lbl_KEIYAKU_KBN_MAE.AutoSize = True
        Me.lbl_KEIYAKU_KBN_MAE.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_KBN_MAE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_KBN_MAE.Location = New System.Drawing.Point(250, 641)
        Me.lbl_KEIYAKU_KBN_MAE.Name = "lbl_KEIYAKU_KBN_MAE"
        Me.lbl_KEIYAKU_KBN_MAE.Size = New System.Drawing.Size(15, 15)
        Me.lbl_KEIYAKU_KBN_MAE.TabIndex = 1062
        Me.lbl_KEIYAKU_KBN_MAE.Text = "9"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label29)
        Me.Panel2.Controls.Add(Me.lblCOUNT)
        Me.Panel2.Controls.Add(Me.Label27)
        Me.Panel2.Location = New System.Drawing.Point(26, 117)
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
        Me.Label10.Size = New System.Drawing.Size(219, 19)
        Me.Label10.TabIndex = 1059
        Me.Label10.Text = "１．契約区分情報（表示）"
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
        Me.Panel1.Location = New System.Drawing.Point(14, 557)
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
        Me.Label11.Size = New System.Drawing.Size(219, 19)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "２．契約区分情報（入力）"
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
        Me.cob_KEIYAKUSYA_CD.Location = New System.Drawing.Point(146, 77)
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
        Me.cob_KEIYAKUSYA_NM.Location = New System.Drawing.Point(203, 77)
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
        'pnl_SYORI_KBN
        '
        Me.pnl_SYORI_KBN.Controls.Add(Me.rbtn_SYORI_KBN2)
        Me.pnl_SYORI_KBN.Controls.Add(Me.rbtn_SYORI_KBN1)
        Me.pnl_SYORI_KBN.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.pnl_SYORI_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.pnl_SYORI_KBN.Location = New System.Drawing.Point(197, 684)
        Me.pnl_SYORI_KBN.Name = "pnl_SYORI_KBN"
        Me.pnl_SYORI_KBN.Size = New System.Drawing.Size(207, 38)
        Me.pnl_SYORI_KBN.TabIndex = 32
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
        Me.Label19.Location = New System.Drawing.Point(70, 698)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 15)
        Me.Label19.TabIndex = 1108
        Me.Label19.Text = "■入力確認有無"
        '
        'lbl_KEIYAKU_KBN_ATO
        '
        Me.lbl_KEIYAKU_KBN_ATO.AutoSize = True
        Me.lbl_KEIYAKU_KBN_ATO.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_KBN_ATO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_KBN_ATO.Location = New System.Drawing.Point(250, 664)
        Me.lbl_KEIYAKU_KBN_ATO.Name = "lbl_KEIYAKU_KBN_ATO"
        Me.lbl_KEIYAKU_KBN_ATO.Size = New System.Drawing.Size(15, 15)
        Me.lbl_KEIYAKU_KBN_ATO.TabIndex = 1110
        Me.lbl_KEIYAKU_KBN_ATO.Text = "9"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(116, 664)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 15)
        Me.Label2.TabIndex = 1109
        Me.Label2.Text = "契約区分(変更後)"
        '
        'cmdSearchClr
        '
        Me.cmdSearchClr.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSearchClr.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearchClr.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSearchClr.Location = New System.Drawing.Point(754, 67)
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
        Me.cmdSearch.Location = New System.Drawing.Point(642, 67)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(94, 35)
        Me.cmdSearch.TabIndex = 3
        Me.cmdSearch.Text = "検索"
        Me.cmdSearch.UseVisualStyleBackColor = True
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
        Me.lbl_SEIKYU_KBN_NM.Location = New System.Drawing.Point(414, 698)
        Me.lbl_SEIKYU_KBN_NM.Name = "lbl_SEIKYU_KBN_NM"
        Me.lbl_SEIKYU_KBN_NM.Size = New System.Drawing.Size(97, 15)
        Me.lbl_SEIKYU_KBN_NM.TabIndex = 1139
        Me.lbl_SEIKYU_KBN_NM.Text = "請求書発行済"
        '
        'lbl_KEIYAKU_KBN_NOW
        '
        Me.lbl_KEIYAKU_KBN_NOW.AutoSize = True
        Me.lbl_KEIYAKU_KBN_NOW.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_KBN_NOW.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_KBN_NOW.Location = New System.Drawing.Point(382, 55)
        Me.lbl_KEIYAKU_KBN_NOW.Name = "lbl_KEIYAKU_KBN_NOW"
        Me.lbl_KEIYAKU_KBN_NOW.Size = New System.Drawing.Size(15, 15)
        Me.lbl_KEIYAKU_KBN_NOW.TabIndex = 1141
        Me.lbl_KEIYAKU_KBN_NOW.Text = "9"
        Me.lbl_KEIYAKU_KBN_NOW.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(295, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 1140
        Me.Label3.Text = "契約区分"
        Me.Label3.Visible = False
        '
        'lbl_KEIYAKU_KBN_MAE_NM
        '
        Me.lbl_KEIYAKU_KBN_MAE_NM.AutoSize = True
        Me.lbl_KEIYAKU_KBN_MAE_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_KBN_MAE_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_KBN_MAE_NM.Location = New System.Drawing.Point(280, 641)
        Me.lbl_KEIYAKU_KBN_MAE_NM.Name = "lbl_KEIYAKU_KBN_MAE_NM"
        Me.lbl_KEIYAKU_KBN_MAE_NM.Size = New System.Drawing.Size(43, 15)
        Me.lbl_KEIYAKU_KBN_MAE_NM.TabIndex = 1142
        Me.lbl_KEIYAKU_KBN_MAE_NM.Text = "ＮＮＮ"
        '
        'lbl_KEIYAKU_KBN_ATO_NM
        '
        Me.lbl_KEIYAKU_KBN_ATO_NM.AutoSize = True
        Me.lbl_KEIYAKU_KBN_ATO_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_KBN_ATO_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_KBN_ATO_NM.Location = New System.Drawing.Point(280, 664)
        Me.lbl_KEIYAKU_KBN_ATO_NM.Name = "lbl_KEIYAKU_KBN_ATO_NM"
        Me.lbl_KEIYAKU_KBN_ATO_NM.Size = New System.Drawing.Size(43, 15)
        Me.lbl_KEIYAKU_KBN_ATO_NM.TabIndex = 1143
        Me.lbl_KEIYAKU_KBN_ATO_NM.Text = "ＮＮＮ"
        '
        'lbl_KEIYAKU_KBN_NOW_NM
        '
        Me.lbl_KEIYAKU_KBN_NOW_NM.AutoSize = True
        Me.lbl_KEIYAKU_KBN_NOW_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_KBN_NOW_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_KBN_NOW_NM.Location = New System.Drawing.Point(403, 55)
        Me.lbl_KEIYAKU_KBN_NOW_NM.Name = "lbl_KEIYAKU_KBN_NOW_NM"
        Me.lbl_KEIYAKU_KBN_NOW_NM.Size = New System.Drawing.Size(43, 15)
        Me.lbl_KEIYAKU_KBN_NOW_NM.TabIndex = 1144
        Me.lbl_KEIYAKU_KBN_NOW_NM.Text = "ＮＮＮ"
        Me.lbl_KEIYAKU_KBN_NOW_NM.Visible = False
        '
        'frmGJ3020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.lbl_KEIYAKU_KBN_NOW_NM)
        Me.Controls.Add(Me.lbl_KEIYAKU_KBN_ATO_NM)
        Me.Controls.Add(Me.lbl_KEIYAKU_KBN_MAE_NM)
        Me.Controls.Add(Me.lbl_KEIYAKU_KBN_NOW)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_SEIKYU_KBN_NM)
        Me.Controls.Add(Me.cmdSearchClr)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.lbl_KEIYAKU_KBN_ATO)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pnl_SYORI_KBN)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txt_KI)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cob_KEIYAKUSYA_CD)
        Me.Controls.Add(Me.cob_KEIYAKUSYA_NM)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lbl_KEIYAKU_KBN_MAE)
        Me.Controls.Add(Me.date_KEIYAKU_DATE_FROM)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdUpd)
        Me.Controls.Add(Me.cmdIns)
        Me.Controls.Add(Me.dgv_Search)
        Me.Name = "frmGJ3020"
        Me.Text = "(GJ3020)互助基金契約者情報変更（契約区分変更）"
        Me.Controls.SetChildIndex(Me.dgv_Search, 0)
        Me.Controls.SetChildIndex(Me.cmdIns, 0)
        Me.Controls.SetChildIndex(Me.cmdUpd, 0)
        Me.Controls.SetChildIndex(Me.cmdDel, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.date_KEIYAKU_DATE_FROM, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_KBN_MAE, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.cob_KEIYAKUSYA_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_KEIYAKUSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txt_KI, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.pnl_SYORI_KBN, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_KBN_ATO, 0)
        Me.Controls.SetChildIndex(Me.cmdSearch, 0)
        Me.Controls.SetChildIndex(Me.cmdSearchClr, 0)
        Me.Controls.SetChildIndex(Me.lbl_SEIKYU_KBN_NM, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_KBN_NOW, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_KBN_MAE_NM, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_KBN_ATO_NM, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_KBN_NOW_NM, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_KEIYAKU_DATE_FROM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cob_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKUSYA_NM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_SYORI_KBN.ResumeLayout(False)
        Me.pnl_SYORI_KBN.PerformLayout()
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
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents date_KEIYAKU_DATE_FROM As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label28 As JBD.Gjs.Win.Label
    Friend WithEvents cmdCansel As JBD.Gjs.Win.JButton
    Friend WithEvents lbl_KEIYAKU_KBN_MAE As JBD.Gjs.Win.JLabel
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
    Friend WithEvents pnl_SYORI_KBN As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtn_SYORI_KBN2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_SYORI_KBN1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_KEIYAKU_KBN_ATO As JBD.Gjs.Win.JLabel
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents cmdSearchClr As JBD.Gjs.Win.JButton
    Friend WithEvents cmdSearch As JBD.Gjs.Win.JButton
    Friend WithEvents Label29 As JBD.Gjs.Win.Label
    Friend WithEvents lblCOUNT As JBD.Gjs.Win.Label
    Friend WithEvents Label27 As JBD.Gjs.Win.Label
    Friend WithEvents cmdSeikyu As JBD.Gjs.Win.JButton
    Friend WithEvents lbl_SEIKYU_KBN_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKU_KBN_NOW As JBD.Gjs.Win.JLabel
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_KEIYAKU_KBN_MAE_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKU_KBN_ATO_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKU_KBN_NOW_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents KEIYAKU_DATE_FROM_X As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_DATE_FROM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_KBN_MAE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_KBN_MAE_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_KBN_ATO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_KBN_ATO_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SYORI_KBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SYORI_KBN_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEIKYU_KAISU As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
