Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ2020
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
        Dim DateEraYearField2 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraField2 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField4 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateLiteralField5 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField2 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField6 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField2 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateEraYearField3 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraField3 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField7 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateLiteralField8 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField3 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField9 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField3 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
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
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.date_SEIKYU_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton11 = New GrapeCity.Win.Editors.DropDownButton()
        Me.date_NOFUKIGEN_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton10 = New GrapeCity.Win.Editors.DropDownButton()
        Me.txt_KI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.date_FURIKOMI_YOTEI_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.txt_SEIKYU_KAISU = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.cmdSav = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdCan = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.cbo_KOFU_TUMI_SITEN_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.grpDATAKBN = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_SYORI_KBN2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_SYORI_KBN1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.SEIKYU_NENGETU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEIKYU_KAISU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYORI_DATE_X = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_HENKO_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_HENKO_KBN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEIKYU_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KIGEN_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FURIKOMI_YOTEI_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEIKYU_TAISYO_SYASU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TUMITATE_KINGAKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CYOSYU_KINGAKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HENKAN_KINGAKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_TESURYO_RITU = New JBD.Gjs.Win.JLabel(Me.components)
        Me.GroupBox1 = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.chk_SEIKYU_HENKAN_KBN4 = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.chk_SEIKYU_HENKAN_KBN3 = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.chk_SEIKYU_HENKAN_KBN2 = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.chk_SEIKYU_HENKAN_KBN1 = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KEIYAKUSYA_CD1 = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEIYAKUSYA_NM1 = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton5 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.date_SEIKYU_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_NOFUKIGEN_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_FURIKOMI_YOTEI_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SEIKYU_KAISU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KOFU_TUMI_SITEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDATAKBN.SuspendLayout()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cob_KEIYAKUSYA_CD1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKUSYA_NM1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cmdEnd.TabIndex = 2
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'date_SEIKYU_DATE
        '
        Me.date_SEIKYU_DATE.DefaultActiveField = DateEraYearField1
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.date_SEIKYU_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.date_SEIKYU_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_SEIKYU_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_SEIKYU_DATE.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.date_SEIKYU_DATE.InputCheck = True
        Me.date_SEIKYU_DATE.Location = New System.Drawing.Point(208, 186)
        Me.date_SEIKYU_DATE.Name = "date_SEIKYU_DATE"
        Me.GcShortcut1.SetShortcuts(Me.date_SEIKYU_DATE, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.date_SEIKYU_DATE, Object), CType(Me.date_SEIKYU_DATE, Object), CType(Me.date_SEIKYU_DATE, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.date_SEIKYU_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton11})
        Me.date_SEIKYU_DATE.Size = New System.Drawing.Size(129, 21)
        Me.date_SEIKYU_DATE.Spin.AllowSpin = False
        Me.date_SEIKYU_DATE.TabIndex = 8
        Me.date_SEIKYU_DATE.Value = New Date(2010, 8, 28, 11, 12, 38, 0)
        '
        'DropDownButton11
        '
        Me.DropDownButton11.Name = "DropDownButton11"
        '
        'date_NOFUKIGEN_DATE
        '
        Me.date_NOFUKIGEN_DATE.DefaultActiveField = DateEraYearField2
        DateLiteralField5.Text = "/"
        DateLiteralField6.Text = "/"
        Me.date_NOFUKIGEN_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateLiteralField4, DateEraYearField2, DateLiteralField5, DateMonthField2, DateLiteralField6, DateDayField2})
        Me.date_NOFUKIGEN_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_NOFUKIGEN_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_NOFUKIGEN_DATE.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.date_NOFUKIGEN_DATE.InputCheck = True
        Me.date_NOFUKIGEN_DATE.Location = New System.Drawing.Point(208, 224)
        Me.date_NOFUKIGEN_DATE.Name = "date_NOFUKIGEN_DATE"
        Me.GcShortcut1.SetShortcuts(Me.date_NOFUKIGEN_DATE, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.date_NOFUKIGEN_DATE, Object), CType(Me.date_NOFUKIGEN_DATE, Object), CType(Me.date_NOFUKIGEN_DATE, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.date_NOFUKIGEN_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton10})
        Me.date_NOFUKIGEN_DATE.Size = New System.Drawing.Size(129, 21)
        Me.date_NOFUKIGEN_DATE.Spin.AllowSpin = False
        Me.date_NOFUKIGEN_DATE.TabIndex = 10
        Me.date_NOFUKIGEN_DATE.Value = New Date(2010, 8, 28, 11, 12, 38, 0)
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
        Me.txt_KI.Location = New System.Drawing.Point(208, 101)
        Me.txt_KI.MaxLength = 2
        Me.txt_KI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KI.Name = "txt_KI"
        Me.GcShortcut1.SetShortcuts(Me.txt_KI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_KI, Object)}, New String() {"ShortcutClear"}))
        Me.txt_KI.Size = New System.Drawing.Size(31, 20)
        Me.txt_KI.TabIndex = 2
        Me.txt_KI.Text = "99"
        '
        'date_FURIKOMI_YOTEI_DATE
        '
        Me.date_FURIKOMI_YOTEI_DATE.DefaultActiveField = DateEraYearField3
        DateLiteralField8.Text = "/"
        DateLiteralField9.Text = "/"
        Me.date_FURIKOMI_YOTEI_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField3, DateLiteralField7, DateEraYearField3, DateLiteralField8, DateMonthField3, DateLiteralField9, DateDayField3})
        Me.date_FURIKOMI_YOTEI_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_FURIKOMI_YOTEI_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_FURIKOMI_YOTEI_DATE.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.date_FURIKOMI_YOTEI_DATE.InputCheck = True
        Me.date_FURIKOMI_YOTEI_DATE.Location = New System.Drawing.Point(521, 224)
        Me.date_FURIKOMI_YOTEI_DATE.Name = "date_FURIKOMI_YOTEI_DATE"
        Me.GcShortcut1.SetShortcuts(Me.date_FURIKOMI_YOTEI_DATE, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.date_FURIKOMI_YOTEI_DATE, Object), CType(Me.date_FURIKOMI_YOTEI_DATE, Object), CType(Me.date_FURIKOMI_YOTEI_DATE, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.date_FURIKOMI_YOTEI_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton3})
        Me.date_FURIKOMI_YOTEI_DATE.Size = New System.Drawing.Size(129, 21)
        Me.date_FURIKOMI_YOTEI_DATE.Spin.AllowSpin = False
        Me.date_FURIKOMI_YOTEI_DATE.TabIndex = 12
        Me.date_FURIKOMI_YOTEI_DATE.Value = New Date(2010, 8, 28, 11, 12, 38, 0)
        '
        'DropDownButton3
        '
        Me.DropDownButton3.Name = "DropDownButton3"
        '
        'txt_SEIKYU_KAISU
        '
        Me.txt_SEIKYU_KAISU.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_SEIKYU_KAISU.DropDown.AllowDrop = False
        Me.txt_SEIKYU_KAISU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_SEIKYU_KAISU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_SEIKYU_KAISU.Format = "9"
        Me.txt_SEIKYU_KAISU.HighlightText = True
        Me.txt_SEIKYU_KAISU.InputCheck = True
        Me.txt_SEIKYU_KAISU.Location = New System.Drawing.Point(392, 101)
        Me.txt_SEIKYU_KAISU.MaxLength = 3
        Me.txt_SEIKYU_KAISU.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_SEIKYU_KAISU.Name = "txt_SEIKYU_KAISU"
        Me.GcShortcut1.SetShortcuts(Me.txt_SEIKYU_KAISU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_SEIKYU_KAISU, Object)}, New String() {"ShortcutClear"}))
        Me.txt_SEIKYU_KAISU.Size = New System.Drawing.Size(38, 20)
        Me.txt_SEIKYU_KAISU.TabIndex = 4
        Me.txt_SEIKYU_KAISU.Text = "999"
        '
        'cmdSav
        '
        Me.cmdSav.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSav.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSav.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSav.Location = New System.Drawing.Point(36, 6)
        Me.cmdSav.Name = "cmdSav"
        Me.cmdSav.Size = New System.Drawing.Size(92, 44)
        Me.cmdSav.TabIndex = 0
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
        Me.cmdCan.TabIndex = 1
        Me.cmdCan.Text = "キャンセル"
        Me.cmdCan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(52, 65)
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
        Me.Label3.Location = New System.Drawing.Point(52, 104)
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
        Me.Label8.Location = New System.Drawing.Point(281, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 15)
        Me.Label8.TabIndex = 882
        Me.Label8.Text = "請求・返還回数"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(52, 189)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 15)
        Me.Label9.TabIndex = 889
        Me.Label9.Text = "■請求・返還年月日"
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
        Me.grpDATAKBN.Location = New System.Drawing.Point(208, 51)
        Me.grpDATAKBN.Name = "grpDATAKBN"
        Me.grpDATAKBN.Size = New System.Drawing.Size(662, 38)
        Me.grpDATAKBN.TabIndex = 0
        Me.grpDATAKBN.TabStop = False
        '
        'rbtn_SYORI_KBN2
        '
        Me.rbtn_SYORI_KBN2.AutoSize = True
        Me.rbtn_SYORI_KBN2.BackColor = System.Drawing.Color.Transparent
        Me.rbtn_SYORI_KBN2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_SYORI_KBN2.Location = New System.Drawing.Point(155, 12)
        Me.rbtn_SYORI_KBN2.Name = "rbtn_SYORI_KBN2"
        Me.rbtn_SYORI_KBN2.Size = New System.Drawing.Size(491, 20)
        Me.rbtn_SYORI_KBN2.TabIndex = 1
        Me.rbtn_SYORI_KBN2.Text = "請求・返還取消処理　（取消対象に入金済が存在する場合は、取消不可）"
        Me.rbtn_SYORI_KBN2.UseVisualStyleBackColor = False
        '
        'rbtn_SYORI_KBN1
        '
        Me.rbtn_SYORI_KBN1.AutoSize = True
        Me.rbtn_SYORI_KBN1.BackColor = System.Drawing.Color.Transparent
        Me.rbtn_SYORI_KBN1.Checked = True
        Me.rbtn_SYORI_KBN1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_SYORI_KBN1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_SYORI_KBN1.Location = New System.Drawing.Point(10, 12)
        Me.rbtn_SYORI_KBN1.Name = "rbtn_SYORI_KBN1"
        Me.rbtn_SYORI_KBN1.Size = New System.Drawing.Size(129, 20)
        Me.rbtn_SYORI_KBN1.TabIndex = 0
        Me.rbtn_SYORI_KBN1.TabStop = True
        Me.rbtn_SYORI_KBN1.Text = "請求・返還処理"
        Me.rbtn_SYORI_KBN1.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(436, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 15)
        Me.Label6.TabIndex = 972
        Me.Label6.Text = "(入力＆表示)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(52, 224)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 15)
        Me.Label10.TabIndex = 976
        Me.Label10.Text = "■納付期限"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(52, 263)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 15)
        Me.Label11.TabIndex = 977
        Me.Label11.Text = "□契約番号"
        '
        'dgv_Search
        '
        Me.dgv_Search.AllowUserToAddRows = False
        Me.dgv_Search.AllowUserToDeleteRows = False
        Me.dgv_Search.AllowUserToResizeRows = False
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SEIKYU_NENGETU, Me.SEIKYU_KAISU, Me.SYORI_DATE_X, Me.KEIYAKU_HENKO_KBN, Me.KEIYAKU_HENKO_KBN_NM, Me.SEIKYU_DATE, Me.KIGEN_DATE, Me.FURIKOMI_YOTEI_DATE, Me.SEIKYU_TAISYO_SYASU, Me.TUMITATE_KINGAKU, Me.CYOSYU_KINGAKU, Me.HENKAN_KINGAKU})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(27, 319)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(1042, 403)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 20
        Me.dgv_Search.TabStop = False
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
        'SEIKYU_KAISU
        '
        Me.SEIKYU_KAISU.DataPropertyName = "SEIKYU_KAISU"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEIKYU_KAISU.DefaultCellStyle = DataGridViewCellStyle2
        Me.SEIKYU_KAISU.Frozen = True
        Me.SEIKYU_KAISU.HeaderText = " 回数"
        Me.SEIKYU_KAISU.Name = "SEIKYU_KAISU"
        Me.SEIKYU_KAISU.ReadOnly = True
        Me.SEIKYU_KAISU.Width = 40
        '
        'SYORI_DATE_X
        '
        Me.SYORI_DATE_X.DataPropertyName = "SYORI_DATE_X"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SYORI_DATE_X.DefaultCellStyle = DataGridViewCellStyle3
        Me.SYORI_DATE_X.Frozen = True
        Me.SYORI_DATE_X.HeaderText = "   処理日"
        Me.SYORI_DATE_X.Name = "SYORI_DATE_X"
        Me.SYORI_DATE_X.ReadOnly = True
        Me.SYORI_DATE_X.Width = 90
        '
        'KEIYAKU_HENKO_KBN
        '
        Me.KEIYAKU_HENKO_KBN.DataPropertyName = "KEIYAKU_HENKO_KBN"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKU_HENKO_KBN.DefaultCellStyle = DataGridViewCellStyle4
        Me.KEIYAKU_HENKO_KBN.Frozen = True
        Me.KEIYAKU_HENKO_KBN.HeaderText = "契約変更区分コード"
        Me.KEIYAKU_HENKO_KBN.Name = "KEIYAKU_HENKO_KBN"
        Me.KEIYAKU_HENKO_KBN.ReadOnly = True
        Me.KEIYAKU_HENKO_KBN.Visible = False
        '
        'KEIYAKU_HENKO_KBN_NM
        '
        Me.KEIYAKU_HENKO_KBN_NM.DataPropertyName = "KEIYAKU_HENKO_KBN_NM"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KEIYAKU_HENKO_KBN_NM.DefaultCellStyle = DataGridViewCellStyle5
        Me.KEIYAKU_HENKO_KBN_NM.Frozen = True
        Me.KEIYAKU_HENKO_KBN_NM.HeaderText = "  計算区分"
        Me.KEIYAKU_HENKO_KBN_NM.Name = "KEIYAKU_HENKO_KBN_NM"
        Me.KEIYAKU_HENKO_KBN_NM.ReadOnly = True
        '
        'SEIKYU_DATE
        '
        Me.SEIKYU_DATE.DataPropertyName = "SEIKYU_DATE"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEIKYU_DATE.DefaultCellStyle = DataGridViewCellStyle6
        Me.SEIKYU_DATE.Frozen = True
        Me.SEIKYU_DATE.HeaderText = "請求・返還日"
        Me.SEIKYU_DATE.Name = "SEIKYU_DATE"
        Me.SEIKYU_DATE.ReadOnly = True
        Me.SEIKYU_DATE.Width = 90
        '
        'KIGEN_DATE
        '
        Me.KIGEN_DATE.DataPropertyName = "KIGEN_DATE"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KIGEN_DATE.DefaultCellStyle = DataGridViewCellStyle7
        Me.KIGEN_DATE.HeaderText = "納付期限"
        Me.KIGEN_DATE.Name = "KIGEN_DATE"
        Me.KIGEN_DATE.ReadOnly = True
        Me.KIGEN_DATE.Width = 90
        '
        'FURIKOMI_YOTEI_DATE
        '
        Me.FURIKOMI_YOTEI_DATE.DataPropertyName = "FURIKOMI_YOTEI_DATE"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FURIKOMI_YOTEI_DATE.DefaultCellStyle = DataGridViewCellStyle8
        Me.FURIKOMI_YOTEI_DATE.HeaderText = "振込予定日"
        Me.FURIKOMI_YOTEI_DATE.Name = "FURIKOMI_YOTEI_DATE"
        Me.FURIKOMI_YOTEI_DATE.ReadOnly = True
        Me.FURIKOMI_YOTEI_DATE.Width = 90
        '
        'SEIKYU_TAISYO_SYASU
        '
        Me.SEIKYU_TAISYO_SYASU.DataPropertyName = "SEIKYU_TAISYO_SYASU"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SEIKYU_TAISYO_SYASU.DefaultCellStyle = DataGridViewCellStyle9
        Me.SEIKYU_TAISYO_SYASU.HeaderText = "　対象者数"
        Me.SEIKYU_TAISYO_SYASU.Name = "SEIKYU_TAISYO_SYASU"
        Me.SEIKYU_TAISYO_SYASU.ReadOnly = True
        '
        'TUMITATE_KINGAKU
        '
        Me.TUMITATE_KINGAKU.DataPropertyName = "TUMITATE_KINGAKU"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TUMITATE_KINGAKU.DefaultCellStyle = DataGridViewCellStyle10
        Me.TUMITATE_KINGAKU.HeaderText = " 積立金等総額"
        Me.TUMITATE_KINGAKU.Name = "TUMITATE_KINGAKU"
        Me.TUMITATE_KINGAKU.ReadOnly = True
        Me.TUMITATE_KINGAKU.Width = 120
        '
        'CYOSYU_KINGAKU
        '
        Me.CYOSYU_KINGAKU.DataPropertyName = "CYOSYU_KINGAKU"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.CYOSYU_KINGAKU.DefaultCellStyle = DataGridViewCellStyle11
        Me.CYOSYU_KINGAKU.HeaderText = "    徴収金額"
        Me.CYOSYU_KINGAKU.Name = "CYOSYU_KINGAKU"
        Me.CYOSYU_KINGAKU.ReadOnly = True
        Me.CYOSYU_KINGAKU.Width = 120
        '
        'HENKAN_KINGAKU
        '
        Me.HENKAN_KINGAKU.DataPropertyName = "HENKAN_KINGAKU"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.HENKAN_KINGAKU.DefaultCellStyle = DataGridViewCellStyle12
        Me.HENKAN_KINGAKU.HeaderText = "    返還金額"
        Me.HENKAN_KINGAKU.Name = "HENKAN_KINGAKU"
        Me.HENKAN_KINGAKU.ReadOnly = True
        Me.HENKAN_KINGAKU.Width = 120
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(52, 296)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(176, 15)
        Me.Label12.TabIndex = 979
        Me.Label12.Text = "請求・返還処理履歴一覧"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(703, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 1028
        Me.Label5.Text = "手数料率"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(802, 107)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(22, 15)
        Me.Label14.TabIndex = 1031
        Me.Label14.Text = "％"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_TESURYO_RITU
        '
        Me.lbl_TESURYO_RITU.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_TESURYO_RITU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_TESURYO_RITU.Location = New System.Drawing.Point(772, 107)
        Me.lbl_TESURYO_RITU.Name = "lbl_TESURYO_RITU"
        Me.lbl_TESURYO_RITU.Size = New System.Drawing.Size(23, 15)
        Me.lbl_TESURYO_RITU.TabIndex = 1039
        Me.lbl_TESURYO_RITU.Text = "99"
        Me.lbl_TESURYO_RITU.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_SEIKYU_HENKAN_KBN4)
        Me.GroupBox1.Controls.Add(Me.chk_SEIKYU_HENKAN_KBN3)
        Me.GroupBox1.Controls.Add(Me.chk_SEIKYU_HENKAN_KBN2)
        Me.GroupBox1.Controls.Add(Me.chk_SEIKYU_HENKAN_KBN1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(208, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(575, 38)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'chk_SEIKYU_HENKAN_KBN4
        '
        Me.chk_SEIKYU_HENKAN_KBN4.AutoSize = True
        Me.chk_SEIKYU_HENKAN_KBN4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_SEIKYU_HENKAN_KBN4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chk_SEIKYU_HENKAN_KBN4.Location = New System.Drawing.Point(469, 12)
        Me.chk_SEIKYU_HENKAN_KBN4.Name = "chk_SEIKYU_HENKAN_KBN4"
        Me.chk_SEIKYU_HENKAN_KBN4.Size = New System.Drawing.Size(92, 20)
        Me.chk_SEIKYU_HENKAN_KBN4.TabIndex = 3
        Me.chk_SEIKYU_HENKAN_KBN4.Text = "全額返還"
        Me.chk_SEIKYU_HENKAN_KBN4.UseVisualStyleBackColor = True
        '
        'chk_SEIKYU_HENKAN_KBN3
        '
        Me.chk_SEIKYU_HENKAN_KBN3.AutoSize = True
        Me.chk_SEIKYU_HENKAN_KBN3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_SEIKYU_HENKAN_KBN3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chk_SEIKYU_HENKAN_KBN3.Location = New System.Drawing.Point(301, 12)
        Me.chk_SEIKYU_HENKAN_KBN3.Name = "chk_SEIKYU_HENKAN_KBN3"
        Me.chk_SEIKYU_HENKAN_KBN3.Size = New System.Drawing.Size(153, 20)
        Me.chk_SEIKYU_HENKAN_KBN3.TabIndex = 2
        Me.chk_SEIKYU_HENKAN_KBN3.Text = "請求兼返還（返還）"
        Me.chk_SEIKYU_HENKAN_KBN3.UseVisualStyleBackColor = True
        '
        'chk_SEIKYU_HENKAN_KBN2
        '
        Me.chk_SEIKYU_HENKAN_KBN2.AutoSize = True
        Me.chk_SEIKYU_HENKAN_KBN2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_SEIKYU_HENKAN_KBN2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chk_SEIKYU_HENKAN_KBN2.Location = New System.Drawing.Point(133, 12)
        Me.chk_SEIKYU_HENKAN_KBN2.Name = "chk_SEIKYU_HENKAN_KBN2"
        Me.chk_SEIKYU_HENKAN_KBN2.Size = New System.Drawing.Size(153, 20)
        Me.chk_SEIKYU_HENKAN_KBN2.TabIndex = 1
        Me.chk_SEIKYU_HENKAN_KBN2.Text = "請求兼返還（徴収）"
        Me.chk_SEIKYU_HENKAN_KBN2.UseVisualStyleBackColor = True
        '
        'chk_SEIKYU_HENKAN_KBN1
        '
        Me.chk_SEIKYU_HENKAN_KBN1.AutoSize = True
        Me.chk_SEIKYU_HENKAN_KBN1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_SEIKYU_HENKAN_KBN1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chk_SEIKYU_HENKAN_KBN1.Location = New System.Drawing.Point(10, 12)
        Me.chk_SEIKYU_HENKAN_KBN1.Name = "chk_SEIKYU_HENKAN_KBN1"
        Me.chk_SEIKYU_HENKAN_KBN1.Size = New System.Drawing.Size(108, 20)
        Me.chk_SEIKYU_HENKAN_KBN1.TabIndex = 0
        Me.chk_SEIKYU_HENKAN_KBN1.Text = "請求（新規）"
        Me.chk_SEIKYU_HENKAN_KBN1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(405, 227)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 15)
        Me.Label4.TabIndex = 1042
        Me.Label4.Text = "■振込予定日"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(52, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 15)
        Me.Label7.TabIndex = 1044
        Me.Label7.Text = "■徴収・返還区分"
        '
        'cob_KEIYAKUSYA_CD1
        '
        Me.cob_KEIYAKUSYA_CD1.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_KEIYAKUSYA_CD1.DropDown.AllowDrop = False
        Me.cob_KEIYAKUSYA_CD1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKUSYA_CD1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKUSYA_CD1.Format = "9"
        Me.cob_KEIYAKUSYA_CD1.HighlightText = True
        Me.cob_KEIYAKUSYA_CD1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_KEIYAKUSYA_CD1.ListHeaderPane.Height = 22
        Me.cob_KEIYAKUSYA_CD1.Location = New System.Drawing.Point(208, 260)
        Me.cob_KEIYAKUSYA_CD1.MaxLength = 5
        Me.cob_KEIYAKUSYA_CD1.Name = "cob_KEIYAKUSYA_CD1"
        Me.cob_KEIYAKUSYA_CD1.Size = New System.Drawing.Size(51, 22)
        Me.cob_KEIYAKUSYA_CD1.Spin.AllowSpin = False
        Me.cob_KEIYAKUSYA_CD1.TabIndex = 14
        Me.cob_KEIYAKUSYA_CD1.Tag = "都道府県"
        Me.cob_KEIYAKUSYA_CD1.Text = "00000"
        '
        'cob_KEIYAKUSYA_NM1
        '
        Me.cob_KEIYAKUSYA_NM1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_KEIYAKUSYA_NM1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKUSYA_NM1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKUSYA_NM1.ListHeaderPane.Height = 22
        Me.cob_KEIYAKUSYA_NM1.ListHeaderPane.Visible = False
        Me.cob_KEIYAKUSYA_NM1.Location = New System.Drawing.Point(265, 260)
        Me.cob_KEIYAKUSYA_NM1.Name = "cob_KEIYAKUSYA_NM1"
        Me.cob_KEIYAKUSYA_NM1.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.cob_KEIYAKUSYA_NM1.Size = New System.Drawing.Size(415, 22)
        Me.cob_KEIYAKUSYA_NM1.TabIndex = 15
        Me.cob_KEIYAKUSYA_NM1.TabStop = False
        '
        'DropDownButton5
        '
        Me.DropDownButton5.Name = "DropDownButton5"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(802, 143)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(237, 15)
        Me.Label13.TabIndex = 1045
        Me.Label13.Text = "※廃業していない契約者が対象です"
        '
        'frmGJ2020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cob_KEIYAKUSYA_CD1)
        Me.Controls.Add(Me.cob_KEIYAKUSYA_NM1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_SEIKYU_KAISU)
        Me.Controls.Add(Me.date_FURIKOMI_YOTEI_DATE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_TESURYO_RITU)
        Me.Controls.Add(Me.txt_KI)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.date_NOFUKIGEN_DATE)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.date_SEIKYU_DATE)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.grpDATAKBN)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgv_Search)
        Me.Name = "frmGJ2020"
        Me.Text = "(mX)"
        Me.Controls.SetChildIndex(Me.dgv_Search, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.grpDATAKBN, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.date_SEIKYU_DATE, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.date_NOFUKIGEN_DATE, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.txt_KI, 0)
        Me.Controls.SetChildIndex(Me.lbl_TESURYO_RITU, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.date_FURIKOMI_YOTEI_DATE, 0)
        Me.Controls.SetChildIndex(Me.txt_SEIKYU_KAISU, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.cob_KEIYAKUSYA_NM1, 0)
        Me.Controls.SetChildIndex(Me.cob_KEIYAKUSYA_CD1, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.date_SEIKYU_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_NOFUKIGEN_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_FURIKOMI_YOTEI_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SEIKYU_KAISU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KOFU_TUMI_SITEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDATAKBN.ResumeLayout(False)
        Me.grpDATAKBN.PerformLayout()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cob_KEIYAKUSYA_CD1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKUSYA_NM1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents cbo_KOFU_TUMI_SITEN_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents grpDATAKBN As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtn_SYORI_KBN2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_SYORI_KBN1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents date_SEIKYU_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton11 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents date_NOFUKIGEN_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton10 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents dgv_Search As JBD.Gjs.Win.DataGridView
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents lbl_TESURYO_RITU As JBD.Gjs.Win.JLabel
    Friend WithEvents GroupBox1 As JBD.Gjs.Win.GroupBox
    Friend WithEvents chk_SEIKYU_HENKAN_KBN3 As JBD.Gjs.Win.CheckBox
    Friend WithEvents chk_SEIKYU_HENKAN_KBN2 As JBD.Gjs.Win.CheckBox
    Friend WithEvents chk_SEIKYU_HENKAN_KBN1 As JBD.Gjs.Win.CheckBox
    Friend WithEvents chk_SEIKYU_HENKAN_KBN4 As JBD.Gjs.Win.CheckBox
    Friend WithEvents date_FURIKOMI_YOTEI_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents txt_SEIKYU_KAISU As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KEIYAKUSYA_CD1 As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEIYAKUSYA_NM1 As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton5 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents SEIKYU_NENGETU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEIKYU_KAISU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SYORI_DATE_X As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_HENKO_KBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_HENKO_KBN_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEIKYU_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KIGEN_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FURIKOMI_YOTEI_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEIKYU_TAISYO_SYASU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TUMITATE_KINGAKU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CYOSYU_KINGAKU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HENKAN_KINGAKU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label13 As JBD.Gjs.Win.Label

End Class
