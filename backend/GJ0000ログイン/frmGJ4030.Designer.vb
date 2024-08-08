Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ4030
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
        Dim DateEraYearField1 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraField1 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField1 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateLiteralField2 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField1 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField3 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField1 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.date_FURI_YOTEI_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton10 = New GrapeCity.Win.Editors.DropDownButton()
        Me.txt_KI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.cmdSav = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdCan = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.cbo_KOFU_TUMI_SITEN_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.grpDATAKBN = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_SYORI_KBN2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_SYORI_KBN1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_KEISAN_KAISU = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.txt_HASSEI_KAISU = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KEIYAKUSYA_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEIYAKUSYA_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton5 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.SEIKYU_NENGETU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HASSEI_KAISU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEISAN_KAISU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYORI_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FURI_YOTEI_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TAISYO_SYASU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIEI_KINGAKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYOKYAKU_KINGAKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KOFU_KINGAKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlButton.SuspendLayout()
        CType(Me.date_FURI_YOTEI_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KOFU_TUMI_SITEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDATAKBN.SuspendLayout()
        CType(Me.txt_KEISAN_KAISU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_HASSEI_KAISU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKUSYA_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdCan)
        Me.pnlButton.Controls.Add(Me.cmdSav)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSav, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCan, 0)
        '
        'lblLOGONUSER
        '
        Me.lblLOGONUSER.Text = "さん"
        '
        'lblSysdate
        '
        Me.lblSysdate.Text = "2010年8月26日（木）"
        '
        'cmdEnd
        '
        Me.cmdEnd.TabIndex = 12
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'date_FURI_YOTEI_DATE
        '
        Me.date_FURI_YOTEI_DATE.DefaultActiveField = DateEraYearField1
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.date_FURI_YOTEI_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.date_FURI_YOTEI_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_FURI_YOTEI_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_FURI_YOTEI_DATE.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.date_FURI_YOTEI_DATE.InputCheck = True
        Me.date_FURI_YOTEI_DATE.Location = New System.Drawing.Point(236, 208)
        Me.date_FURI_YOTEI_DATE.Name = "date_FURI_YOTEI_DATE"
        Me.GcShortcut1.SetShortcuts(Me.date_FURI_YOTEI_DATE, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.date_FURI_YOTEI_DATE, Object), CType(Me.date_FURI_YOTEI_DATE, Object), CType(Me.date_FURI_YOTEI_DATE, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.date_FURI_YOTEI_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton10})
        Me.date_FURI_YOTEI_DATE.Size = New System.Drawing.Size(129, 21)
        Me.date_FURI_YOTEI_DATE.Spin.AllowSpin = False
        Me.date_FURI_YOTEI_DATE.TabIndex = 6
        Me.date_FURI_YOTEI_DATE.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        '
        'DropDownButton10
        '
        Me.DropDownButton10.Name = "DropDownButton10"
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
        Me.txt_KI.Location = New System.Drawing.Point(236, 117)
        Me.txt_KI.MaxLength = 2
        Me.txt_KI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KI.Name = "txt_KI"
        Me.GcShortcut1.SetShortcuts(Me.txt_KI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_KI, Object)}, New String() {"ShortcutClear"}))
        Me.txt_KI.Size = New System.Drawing.Size(31, 20)
        Me.txt_KI.TabIndex = 1
        Me.txt_KI.Text = "99"
        '
        'cmdSav
        '
        Me.cmdSav.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSav.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSav.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSav.Location = New System.Drawing.Point(36, 6)
        Me.cmdSav.Name = "cmdSav"
        Me.cmdSav.Size = New System.Drawing.Size(92, 44)
        Me.cmdSav.TabIndex = 10
        Me.cmdSav.Text = "実行"
        Me.cmdSav.UseVisualStyleBackColor = True
        '
        'cmdCan
        '
        Me.cmdCan.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCan.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCan.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCan.Location = New System.Drawing.Point(150, 6)
        Me.cmdCan.Name = "cmdCan"
        Me.cmdCan.Size = New System.Drawing.Size(92, 44)
        Me.cmdCan.TabIndex = 11
        Me.cmdCan.Text = "キャンセル"
        Me.cmdCan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(110, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 872
        Me.Label2.Text = "■処理区分"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(110, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 874
        Me.Label3.Text = "■対象期"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(140, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 15)
        Me.Label8.TabIndex = 882
        Me.Label8.Text = "計算回数"
        '
        'cbo_KOFU_TUMI_SITEN_CD
        '
        Me.cbo_KOFU_TUMI_SITEN_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cbo_KOFU_TUMI_SITEN_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_KOFU_TUMI_SITEN_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_KOFU_TUMI_SITEN_CD.Format = "9"
        Me.cbo_KOFU_TUMI_SITEN_CD.HighlightText = True
        Me.cbo_KOFU_TUMI_SITEN_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_KOFU_TUMI_SITEN_CD.ListHeaderPane.Height = 22
        Me.cbo_KOFU_TUMI_SITEN_CD.Location = New System.Drawing.Point(560, 689)
        Me.cbo_KOFU_TUMI_SITEN_CD.MaxLength = 3
        Me.cbo_KOFU_TUMI_SITEN_CD.Name = "cbo_KOFU_TUMI_SITEN_CD"
        Me.cbo_KOFU_TUMI_SITEN_CD.Size = New System.Drawing.Size(40, 22)
        Me.cbo_KOFU_TUMI_SITEN_CD.TabIndex = 927
        Me.cbo_KOFU_TUMI_SITEN_CD.Text = "000"
        '
        'grpDATAKBN
        '
        Me.grpDATAKBN.Controls.Add(Me.rbtn_SYORI_KBN2)
        Me.grpDATAKBN.Controls.Add(Me.rbtn_SYORI_KBN1)
        Me.grpDATAKBN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grpDATAKBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpDATAKBN.Location = New System.Drawing.Point(236, 60)
        Me.grpDATAKBN.Name = "grpDATAKBN"
        Me.grpDATAKBN.Size = New System.Drawing.Size(626, 38)
        Me.grpDATAKBN.TabIndex = 0
        Me.grpDATAKBN.TabStop = False
        '
        'rbtn_SYORI_KBN2
        '
        Me.rbtn_SYORI_KBN2.AutoSize = True
        Me.rbtn_SYORI_KBN2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_SYORI_KBN2.Location = New System.Drawing.Point(108, 12)
        Me.rbtn_SYORI_KBN2.Name = "rbtn_SYORI_KBN2"
        Me.rbtn_SYORI_KBN2.Size = New System.Drawing.Size(498, 20)
        Me.rbtn_SYORI_KBN2.TabIndex = 2
        Me.rbtn_SYORI_KBN2.Text = "計算取消処理　（取消対象に補填金支払済が存在する場合は、取消不可）"
        Me.rbtn_SYORI_KBN2.UseVisualStyleBackColor = True
        '
        'rbtn_SYORI_KBN1
        '
        Me.rbtn_SYORI_KBN1.AutoSize = True
        Me.rbtn_SYORI_KBN1.Checked = True
        Me.rbtn_SYORI_KBN1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_SYORI_KBN1.Location = New System.Drawing.Point(10, 12)
        Me.rbtn_SYORI_KBN1.Name = "rbtn_SYORI_KBN1"
        Me.rbtn_SYORI_KBN1.Size = New System.Drawing.Size(91, 20)
        Me.rbtn_SYORI_KBN1.TabIndex = 0
        Me.rbtn_SYORI_KBN1.TabStop = True
        Me.rbtn_SYORI_KBN1.Text = "計算処理"
        Me.rbtn_SYORI_KBN1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(273, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 15)
        Me.Label6.TabIndex = 972
        Me.Label6.Text = "(表示＆入力)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(273, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 15)
        Me.Label7.TabIndex = 973
        Me.Label7.Text = "(表示＆入力)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(110, 208)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 15)
        Me.Label10.TabIndex = 976
        Me.Label10.Text = "■振込予定日"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(110, 260)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 15)
        Me.Label11.TabIndex = 977
        Me.Label11.Text = "□契約者番号"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(110, 301)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(215, 15)
        Me.Label12.TabIndex = 979
        Me.Label12.Text = "互助交付金計算処理履歴一覧"
        '
        'txt_KEISAN_KAISU
        '
        Me.txt_KEISAN_KAISU.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_KEISAN_KAISU.DropDown.AllowDrop = False
        Me.txt_KEISAN_KAISU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KEISAN_KAISU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_KEISAN_KAISU.Format = "9"
        Me.txt_KEISAN_KAISU.HighlightText = True
        Me.txt_KEISAN_KAISU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_KEISAN_KAISU.InputCheck = True
        Me.txt_KEISAN_KAISU.ListHeaderPane.Height = 22
        Me.txt_KEISAN_KAISU.Location = New System.Drawing.Point(236, 158)
        Me.txt_KEISAN_KAISU.MaxLength = 2
        Me.txt_KEISAN_KAISU.Name = "txt_KEISAN_KAISU"
        Me.txt_KEISAN_KAISU.Size = New System.Drawing.Size(31, 22)
        Me.txt_KEISAN_KAISU.TabIndex = 5
        Me.txt_KEISAN_KAISU.Text = "00"
        '
        'txt_HASSEI_KAISU
        '
        Me.txt_HASSEI_KAISU.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_HASSEI_KAISU.DropDown.AllowDrop = False
        Me.txt_HASSEI_KAISU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_HASSEI_KAISU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_HASSEI_KAISU.Format = "9"
        Me.txt_HASSEI_KAISU.HighlightText = True
        Me.txt_HASSEI_KAISU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_HASSEI_KAISU.InputCheck = True
        Me.txt_HASSEI_KAISU.ListHeaderPane.Height = 22
        Me.txt_HASSEI_KAISU.Location = New System.Drawing.Point(476, 117)
        Me.txt_HASSEI_KAISU.MaxLength = 2
        Me.txt_HASSEI_KAISU.Name = "txt_HASSEI_KAISU"
        Me.txt_HASSEI_KAISU.Size = New System.Drawing.Size(26, 22)
        Me.txt_HASSEI_KAISU.TabIndex = 4
        Me.txt_HASSEI_KAISU.Text = "00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(403, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 1031
        Me.Label4.Text = "認定回数"
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
        Me.cob_KEIYAKUSYA_CD.ListHeaderPane.Height = 22
        Me.cob_KEIYAKUSYA_CD.Location = New System.Drawing.Point(236, 257)
        Me.cob_KEIYAKUSYA_CD.MaxLength = 5
        Me.cob_KEIYAKUSYA_CD.Name = "cob_KEIYAKUSYA_CD"
        Me.cob_KEIYAKUSYA_CD.Size = New System.Drawing.Size(51, 22)
        Me.cob_KEIYAKUSYA_CD.Spin.AllowSpin = False
        Me.cob_KEIYAKUSYA_CD.TabIndex = 11
        Me.cob_KEIYAKUSYA_CD.Tag = "都道府県"
        Me.cob_KEIYAKUSYA_CD.Text = "00000"
        '
        'cob_KEIYAKUSYA_NM
        '
        Me.cob_KEIYAKUSYA_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_KEIYAKUSYA_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKUSYA_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKUSYA_NM.ListHeaderPane.Height = 22
        Me.cob_KEIYAKUSYA_NM.ListHeaderPane.Visible = False
        Me.cob_KEIYAKUSYA_NM.Location = New System.Drawing.Point(293, 257)
        Me.cob_KEIYAKUSYA_NM.Name = "cob_KEIYAKUSYA_NM"
        Me.cob_KEIYAKUSYA_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.cob_KEIYAKUSYA_NM.Size = New System.Drawing.Size(415, 22)
        Me.cob_KEIYAKUSYA_NM.TabIndex = 12
        Me.cob_KEIYAKUSYA_NM.TabStop = False
        '
        'DropDownButton5
        '
        Me.DropDownButton5.Name = "DropDownButton5"
        '
        'dgv_Search
        '
        Me.dgv_Search.AllowUserToAddRows = False
        Me.dgv_Search.AllowUserToDeleteRows = False
        Me.dgv_Search.AllowUserToResizeRows = False
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SEIKYU_NENGETU, Me.HASSEI_KAISU, Me.KEISAN_KAISU, Me.SYORI_DATE, Me.FURI_YOTEI_DATE, Me.TAISYO_SYASU, Me.KEIEI_KINGAKU, Me.SYOKYAKU_KINGAKU, Me.KOFU_KINGAKU})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(59, 327)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(970, 403)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 20
        Me.dgv_Search.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(508, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 15)
        Me.Label5.TabIndex = 1032
        Me.Label5.Text = "(表示＆入力)"
        '
        'SEIKYU_NENGETU
        '
        Me.SEIKYU_NENGETU.DataPropertyName = "KI"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEIKYU_NENGETU.DefaultCellStyle = DataGridViewCellStyle1
        Me.SEIKYU_NENGETU.FillWeight = 90.0!
        Me.SEIKYU_NENGETU.Frozen = True
        Me.SEIKYU_NENGETU.HeaderText = "対象期  "
        Me.SEIKYU_NENGETU.Name = "SEIKYU_NENGETU"
        Me.SEIKYU_NENGETU.ReadOnly = True
        Me.SEIKYU_NENGETU.Width = 60
        '
        'HASSEI_KAISU
        '
        Me.HASSEI_KAISU.DataPropertyName = "HASSEI_KAISU"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.HASSEI_KAISU.DefaultCellStyle = DataGridViewCellStyle2
        Me.HASSEI_KAISU.Frozen = True
        Me.HASSEI_KAISU.HeaderText = "認定回数"
        Me.HASSEI_KAISU.Name = "HASSEI_KAISU"
        Me.HASSEI_KAISU.ReadOnly = True
        Me.HASSEI_KAISU.Width = 80
        '
        'KEISAN_KAISU
        '
        Me.KEISAN_KAISU.DataPropertyName = "KEISAN_KAISU"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEISAN_KAISU.DefaultCellStyle = DataGridViewCellStyle3
        Me.KEISAN_KAISU.Frozen = True
        Me.KEISAN_KAISU.HeaderText = "計算回数"
        Me.KEISAN_KAISU.Name = "KEISAN_KAISU"
        Me.KEISAN_KAISU.ReadOnly = True
        Me.KEISAN_KAISU.Width = 80
        '
        'SYORI_DATE
        '
        Me.SYORI_DATE.DataPropertyName = "SYORI_DATE"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYORI_DATE.DefaultCellStyle = DataGridViewCellStyle4
        Me.SYORI_DATE.HeaderText = "   処理日"
        Me.SYORI_DATE.Name = "SYORI_DATE"
        Me.SYORI_DATE.ReadOnly = True
        Me.SYORI_DATE.Width = 90
        '
        'FURI_YOTEI_DATE
        '
        Me.FURI_YOTEI_DATE.DataPropertyName = "FURI_YOTEI_DATE"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FURI_YOTEI_DATE.DefaultCellStyle = DataGridViewCellStyle5
        Me.FURI_YOTEI_DATE.HeaderText = "振込予定日"
        Me.FURI_YOTEI_DATE.Name = "FURI_YOTEI_DATE"
        Me.FURI_YOTEI_DATE.ReadOnly = True
        Me.FURI_YOTEI_DATE.Width = 90
        '
        'TAISYO_SYASU
        '
        Me.TAISYO_SYASU.DataPropertyName = "TAISYO_SYASU"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TAISYO_SYASU.DefaultCellStyle = DataGridViewCellStyle6
        Me.TAISYO_SYASU.HeaderText = "　対象者数"
        Me.TAISYO_SYASU.Name = "TAISYO_SYASU"
        Me.TAISYO_SYASU.ReadOnly = True
        '
        'KEIEI_KINGAKU
        '
        Me.KEIEI_KINGAKU.DataPropertyName = "KEIEI_KINGAKU"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIEI_KINGAKU.DefaultCellStyle = DataGridViewCellStyle7
        Me.KEIEI_KINGAKU.HeaderText = "経営支援金額"
        Me.KEIEI_KINGAKU.Name = "KEIEI_KINGAKU"
        Me.KEIEI_KINGAKU.ReadOnly = True
        Me.KEIEI_KINGAKU.Width = 150
        '
        'SYOKYAKU_KINGAKU
        '
        Me.SYOKYAKU_KINGAKU.DataPropertyName = "SYOKYAKU_KINGAKU"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.SYOKYAKU_KINGAKU.DefaultCellStyle = DataGridViewCellStyle8
        Me.SYOKYAKU_KINGAKU.HeaderText = "焼却・埋却金額"
        Me.SYOKYAKU_KINGAKU.Name = "SYOKYAKU_KINGAKU"
        Me.SYOKYAKU_KINGAKU.ReadOnly = True
        Me.SYOKYAKU_KINGAKU.Width = 150
        '
        'KOFU_KINGAKU
        '
        Me.KOFU_KINGAKU.DataPropertyName = "KOFU_KINGAKU"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.KOFU_KINGAKU.DefaultCellStyle = DataGridViewCellStyle9
        Me.KOFU_KINGAKU.HeaderText = "合計交付金額"
        Me.KOFU_KINGAKU.Name = "KOFU_KINGAKU"
        Me.KOFU_KINGAKU.ReadOnly = True
        Me.KOFU_KINGAKU.Width = 150
        '
        'frmGJ4030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgv_Search)
        Me.Controls.Add(Me.txt_KI)
        Me.Controls.Add(Me.cob_KEIYAKUSYA_CD)
        Me.Controls.Add(Me.cob_KEIYAKUSYA_NM)
        Me.Controls.Add(Me.txt_HASSEI_KAISU)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_KEISAN_KAISU)
        Me.Controls.Add(Me.date_FURI_YOTEI_DATE)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.grpDATAKBN)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmGJ4030"
        Me.Text = "(mX)"
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.grpDATAKBN, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.date_FURI_YOTEI_DATE, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.txt_KEISAN_KAISU, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txt_HASSEI_KAISU, 0)
        Me.Controls.SetChildIndex(Me.cob_KEIYAKUSYA_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_KEIYAKUSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.txt_KI, 0)
        Me.Controls.SetChildIndex(Me.dgv_Search, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.date_FURI_YOTEI_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KOFU_TUMI_SITEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDATAKBN.ResumeLayout(False)
        Me.grpDATAKBN.PerformLayout()
        CType(Me.txt_KEISAN_KAISU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_HASSEI_KAISU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKUSYA_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents cmdSav As JBD.Gjs.Win.JButton
    Friend WithEvents cmdCan As JBD.Gjs.Win.JButton
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents cbo_KOFU_TUMI_SITEN_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents grpDATAKBN As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtn_SYORI_KBN2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_SYORI_KBN1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents date_FURI_YOTEI_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton10 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KEISAN_KAISU As JBD.Gjs.Win.GcComboBox
    Friend WithEvents txt_HASSEI_KAISU As JBD.Gjs.Win.GcComboBox
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KEIYAKUSYA_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEIYAKUSYA_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton5 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents txt_KI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents dgv_Search As JBD.Gjs.Win.DataGridView
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents SEIKYU_NENGETU As DataGridViewTextBoxColumn
    Friend WithEvents HASSEI_KAISU As DataGridViewTextBoxColumn
    Friend WithEvents KEISAN_KAISU As DataGridViewTextBoxColumn
    Friend WithEvents SYORI_DATE As DataGridViewTextBoxColumn
    Friend WithEvents FURI_YOTEI_DATE As DataGridViewTextBoxColumn
    Friend WithEvents TAISYO_SYASU As DataGridViewTextBoxColumn
    Friend WithEvents KEIEI_KINGAKU As DataGridViewTextBoxColumn
    Friend WithEvents SYOKYAKU_KINGAKU As DataGridViewTextBoxColumn
    Friend WithEvents KOFU_KINGAKU As DataGridViewTextBoxColumn
End Class
