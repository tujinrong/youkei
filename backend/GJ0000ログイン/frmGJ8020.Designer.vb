Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ8020
    Inherits JBD.Gjs.Win.FormL
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
        Dim DateEraDisplayField1 As GrapeCity.Win.Editors.Fields.DateEraDisplayField = New GrapeCity.Win.Editors.Fields.DateEraDisplayField()
        Dim DateLiteralDisplayField1 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateEraYearDisplayField1 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateEraField1 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField1 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField2 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraDisplayField2 As GrapeCity.Win.Editors.Fields.DateEraDisplayField = New GrapeCity.Win.Editors.Fields.DateEraDisplayField()
        Dim DateLiteralDisplayField2 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateEraYearDisplayField2 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateEraField2 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField2 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField3 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraDisplayField3 As GrapeCity.Win.Editors.Fields.DateEraDisplayField = New GrapeCity.Win.Editors.Fields.DateEraDisplayField()
        Dim DateLiteralDisplayField3 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateEraYearDisplayField3 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateEraField3 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField3 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField4 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraDisplayField4 As GrapeCity.Win.Editors.Fields.DateEraDisplayField = New GrapeCity.Win.Editors.Fields.DateEraDisplayField()
        Dim DateLiteralDisplayField4 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateEraYearDisplayField4 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateLiteralDisplayField5 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateMonthDisplayField1 As GrapeCity.Win.Editors.Fields.DateMonthDisplayField = New GrapeCity.Win.Editors.Fields.DateMonthDisplayField()
        Dim DateLiteralDisplayField6 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateDayDisplayField1 As GrapeCity.Win.Editors.Fields.DateDayDisplayField = New GrapeCity.Win.Editors.Fields.DateDayDisplayField()
        Dim DateEraField4 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField4 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateLiteralField5 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField1 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField6 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField1 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Me.Label28 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdCancel = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdSav = New JBD.Gjs.Win.JButton(Me.components)
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.date_JIGYO_NENDO = New JBD.Gjs.Win.GcDate(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.date_JIGYO_SYURYO_NENDO = New JBD.Gjs.Win.GcDate(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.date_TAISYO_NENDO = New JBD.Gjs.Win.GcDate(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.date_NOFU_KIGEN = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton5 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.num_KI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_HASSEI_KAISU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_BIKO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label20 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label21 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_ZENKI_TUMITATE_DATE = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ZENKI_KOFU_DATE = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_HENKAN_KEISAN_DATE = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_HENKAN_NINZU = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_HENKAN_GOKEI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_HENKAN_RITU = New JBD.Gjs.Win.JLabel(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.date_JIGYO_NENDO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_JIGYO_SYURYO_NENDO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_TAISYO_NENDO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_NOFU_KIGEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_HASSEI_KAISU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_BIKO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdCancel)
        Me.pnlButton.Controls.Add(Me.cmdSav)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSav, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCancel, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        '
        'cmdEnd
        '
        Me.cmdEnd.TabIndex = 99
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(110, 96)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(135, 15)
        Me.Label28.TabIndex = 939
        Me.Label28.Text = "■事業対象期・年度"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(228, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(92, 44)
        Me.cmdCancel.TabIndex = 53
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSav
        '
        Me.cmdSav.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSav.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSav.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSav.Location = New System.Drawing.Point(32, 6)
        Me.cmdSav.Name = "cmdSav"
        Me.cmdSav.Size = New System.Drawing.Size(92, 44)
        Me.cmdSav.TabIndex = 51
        Me.cmdSav.Text = "保存"
        Me.cmdSav.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(131, 330)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 15)
        Me.Label2.TabIndex = 939
        Me.Label2.Text = "前期積立金返還率"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(110, 429)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(187, 15)
        Me.Label3.TabIndex = 939
        Me.Label3.Text = "□当初対象積立金納付期限"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(110, 472)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 15)
        Me.Label4.TabIndex = 941
        Me.Label4.Text = "□現在の認定回数"
        '
        'date_JIGYO_NENDO
        '
        Me.date_JIGYO_NENDO.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.date_JIGYO_NENDO.DefaultActiveField = DateEraYearField1
        DateEraYearDisplayField1.ShowLeadingZero = True
        Me.date_JIGYO_NENDO.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField1, DateLiteralDisplayField1, DateEraYearDisplayField1})
        Me.date_JIGYO_NENDO.DropDownCalendar.CalendarType = GrapeCity.Win.Editors.CalendarType.YearMonth
        Me.date_JIGYO_NENDO.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1})
        Me.date_JIGYO_NENDO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_JIGYO_NENDO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_JIGYO_NENDO.InputCheck = True
        Me.date_JIGYO_NENDO.Location = New System.Drawing.Point(371, 93)
        Me.date_JIGYO_NENDO.Name = "date_JIGYO_NENDO"
        Me.date_JIGYO_NENDO.Size = New System.Drawing.Size(59, 21)
        Me.date_JIGYO_NENDO.Spin.AllowSpin = False
        Me.date_JIGYO_NENDO.TabIndex = 1
        Me.date_JIGYO_NENDO.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(435, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 943
        Me.Label5.Text = "年度"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(474, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 15)
        Me.Label6.TabIndex = 999
        Me.Label6.Text = "～"
        '
        'date_JIGYO_SYURYO_NENDO
        '
        Me.date_JIGYO_SYURYO_NENDO.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.date_JIGYO_SYURYO_NENDO.DefaultActiveField = DateEraYearField2
        DateEraYearDisplayField2.ShowLeadingZero = True
        Me.date_JIGYO_SYURYO_NENDO.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField2, DateLiteralDisplayField2, DateEraYearDisplayField2})
        Me.date_JIGYO_SYURYO_NENDO.DropDownCalendar.CalendarType = GrapeCity.Win.Editors.CalendarType.YearMonth
        Me.date_JIGYO_SYURYO_NENDO.Enabled = False
        Me.date_JIGYO_SYURYO_NENDO.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateLiteralField2, DateEraYearField2})
        Me.date_JIGYO_SYURYO_NENDO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_JIGYO_SYURYO_NENDO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_JIGYO_SYURYO_NENDO.InputCheck = True
        Me.date_JIGYO_SYURYO_NENDO.Location = New System.Drawing.Point(502, 93)
        Me.date_JIGYO_SYURYO_NENDO.Name = "date_JIGYO_SYURYO_NENDO"
        Me.date_JIGYO_SYURYO_NENDO.Size = New System.Drawing.Size(59, 21)
        Me.date_JIGYO_SYURYO_NENDO.Spin.AllowSpin = False
        Me.date_JIGYO_SYURYO_NENDO.TabIndex = 2
        Me.date_JIGYO_SYURYO_NENDO.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(567, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 15)
        Me.Label7.TabIndex = 1001
        Me.Label7.Text = "年度"
        '
        'date_TAISYO_NENDO
        '
        Me.date_TAISYO_NENDO.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.date_TAISYO_NENDO.DefaultActiveField = DateEraYearField3
        DateEraYearDisplayField3.ShowLeadingZero = True
        Me.date_TAISYO_NENDO.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField3, DateLiteralDisplayField3, DateEraYearDisplayField3})
        Me.date_TAISYO_NENDO.DropDownCalendar.CalendarType = GrapeCity.Win.Editors.CalendarType.YearMonth
        Me.date_TAISYO_NENDO.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField3, DateLiteralField3, DateEraYearField3})
        Me.date_TAISYO_NENDO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_TAISYO_NENDO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_TAISYO_NENDO.InputCheck = True
        Me.date_TAISYO_NENDO.Location = New System.Drawing.Point(311, 383)
        Me.date_TAISYO_NENDO.Name = "date_TAISYO_NENDO"
        Me.date_TAISYO_NENDO.Size = New System.Drawing.Size(59, 21)
        Me.date_TAISYO_NENDO.Spin.AllowSpin = False
        Me.date_TAISYO_NENDO.TabIndex = 21
        Me.date_TAISYO_NENDO.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(376, 386)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 15)
        Me.Label8.TabIndex = 1003
        Me.Label8.Text = "年度"
        '
        'date_NOFU_KIGEN
        '
        Me.date_NOFU_KIGEN.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.date_NOFU_KIGEN.DefaultActiveField = DateEraYearField4
        DateEraYearDisplayField4.ShowLeadingZero = True
        DateLiteralDisplayField5.Text = "/"
        DateMonthDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField6.Text = "/"
        DateDayDisplayField1.ShowLeadingZero = True
        Me.date_NOFU_KIGEN.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField4, DateLiteralDisplayField4, DateEraYearDisplayField4, DateLiteralDisplayField5, DateMonthDisplayField1, DateLiteralDisplayField6, DateDayDisplayField1})
        Me.date_NOFU_KIGEN.DropDownCalendar.CalendarType = GrapeCity.Win.Editors.CalendarType.YearMonth
        Me.date_NOFU_KIGEN.DropDownCalendar.SelectedDate = Nothing
        DateLiteralField5.Text = "/"
        DateLiteralField6.Text = "/"
        Me.date_NOFU_KIGEN.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField4, DateLiteralField4, DateEraYearField4, DateLiteralField5, DateMonthField1, DateLiteralField6, DateDayField1})
        Me.date_NOFU_KIGEN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_NOFU_KIGEN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_NOFU_KIGEN.Location = New System.Drawing.Point(311, 426)
        Me.date_NOFU_KIGEN.Name = "date_NOFU_KIGEN"
        Me.date_NOFU_KIGEN.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.date_NOFU_KIGEN.Size = New System.Drawing.Size(125, 21)
        Me.date_NOFU_KIGEN.Spin.AllowSpin = False
        Me.date_NOFU_KIGEN.TabIndex = 22
        Me.date_NOFU_KIGEN.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        '
        'DropDownButton5
        '
        Me.DropDownButton5.Name = "DropDownButton5"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(131, 252)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 15)
        Me.Label10.TabIndex = 1017
        Me.Label10.Text = "積立金返還人数"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(131, 291)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 15)
        Me.Label11.TabIndex = 1018
        Me.Label11.Text = "積立金返還額合計"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(110, 386)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(173, 15)
        Me.Label12.TabIndex = 1019
        Me.Label12.Text = "■対象年度（現在処理中）"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(110, 515)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 15)
        Me.Label13.TabIndex = 1020
        Me.Label13.Text = "□備考"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(344, 96)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(22, 15)
        Me.Label14.TabIndex = 1021
        Me.Label14.Text = "期"
        '
        'num_KI
        '
        Me.num_KI.AllowDeleteToNull = True
        Me.num_KI.DropDown.AllowDrop = False
        Me.num_KI.Fields.DecimalPart.MaxDigits = 0
        Me.num_KI.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.num_KI.Fields.IntegerPart.MaxDigits = 2
        Me.num_KI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KI.HighlightText = True
        Me.num_KI.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KI.InputCheck = True
        Me.num_KI.Location = New System.Drawing.Point(311, 93)
        Me.num_KI.Name = "num_KI"
        Me.GcShortcut1.SetShortcuts(Me.num_KI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KI, Object), CType(Me.num_KI, Object), CType(Me.num_KI, Object), CType(Me.num_KI, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KI.Size = New System.Drawing.Size(27, 22)
        Me.num_KI.Spin.Increment = 0
        Me.num_KI.TabIndex = 0
        Me.num_KI.Value = New Decimal(New Integer() {99, 0, 0, 0})
        Me.num_KI.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_HASSEI_KAISU
        '
        Me.num_HASSEI_KAISU.AllowDeleteToNull = True
        Me.num_HASSEI_KAISU.DropDown.AllowDrop = False
        Me.num_HASSEI_KAISU.Fields.DecimalPart.MaxDigits = 0
        Me.num_HASSEI_KAISU.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.num_HASSEI_KAISU.Fields.IntegerPart.MaxDigits = 2
        Me.num_HASSEI_KAISU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_HASSEI_KAISU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_HASSEI_KAISU.HighlightText = True
        Me.num_HASSEI_KAISU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_HASSEI_KAISU.Location = New System.Drawing.Point(311, 469)
        Me.num_HASSEI_KAISU.Name = "num_HASSEI_KAISU"
        Me.GcShortcut1.SetShortcuts(Me.num_HASSEI_KAISU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_HASSEI_KAISU, Object), CType(Me.num_HASSEI_KAISU, Object), CType(Me.num_HASSEI_KAISU, Object), CType(Me.num_HASSEI_KAISU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_HASSEI_KAISU.Size = New System.Drawing.Size(27, 22)
        Me.num_HASSEI_KAISU.Spin.Increment = 0
        Me.num_HASSEI_KAISU.TabIndex = 23
        Me.num_HASSEI_KAISU.Value = New Decimal(New Integer() {99, 0, 0, 0})
        Me.num_HASSEI_KAISU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(376, 252)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 15)
        Me.Label15.TabIndex = 1026
        Me.Label15.Text = "(人)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(410, 291)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 15)
        Me.Label16.TabIndex = 1027
        Me.Label16.Text = "(円)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(459, 291)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(384, 15)
        Me.Label17.TabIndex = 1028
        Me.Label17.Text = "（左記項目は積立金返還処理で算定した結果を保存、表示）"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(459, 429)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(397, 15)
        Me.Label9.TabIndex = 1029
        Me.Label9.Text = "（左記期限までに入金済みの時は、契約日は４月１日となる。）"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(344, 472)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(22, 15)
        Me.Label18.TabIndex = 1031
        Me.Label18.Text = "回"
        '
        'txt_BIKO
        '
        Me.txt_BIKO.DropDown.AllowDrop = False
        Me.txt_BIKO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_BIKO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_BIKO.Format = "Ｚ"
        Me.txt_BIKO.HighlightText = True
        Me.txt_BIKO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_BIKO.Location = New System.Drawing.Point(311, 512)
        Me.txt_BIKO.MaxLength = 80
        Me.txt_BIKO.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_BIKO.Name = "txt_BIKO"
        Me.txt_BIKO.Size = New System.Drawing.Size(609, 20)
        Me.txt_BIKO.TabIndex = 24
        Me.txt_BIKO.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(131, 135)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(147, 15)
        Me.Label19.TabIndex = 1033
        Me.Label19.Text = "１．前期積立金取込日"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(131, 174)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(147, 15)
        Me.Label20.TabIndex = 1035
        Me.Label20.Text = "２．前期交付金取込日"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(131, 213)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(117, 15)
        Me.Label21.TabIndex = 1037
        Me.Label21.Text = "３．返還金計算日"
        '
        'lbl_ZENKI_TUMITATE_DATE
        '
        Me.lbl_ZENKI_TUMITATE_DATE.AutoSize = True
        Me.lbl_ZENKI_TUMITATE_DATE.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ZENKI_TUMITATE_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ZENKI_TUMITATE_DATE.Location = New System.Drawing.Point(308, 135)
        Me.lbl_ZENKI_TUMITATE_DATE.Name = "lbl_ZENKI_TUMITATE_DATE"
        Me.lbl_ZENKI_TUMITATE_DATE.Size = New System.Drawing.Size(101, 15)
        Me.lbl_ZENKI_TUMITATE_DATE.TabIndex = 1038
        Me.lbl_ZENKI_TUMITATE_DATE.Text = "平成99/99/99"
        '
        'lbl_ZENKI_KOFU_DATE
        '
        Me.lbl_ZENKI_KOFU_DATE.AutoSize = True
        Me.lbl_ZENKI_KOFU_DATE.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ZENKI_KOFU_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ZENKI_KOFU_DATE.Location = New System.Drawing.Point(308, 174)
        Me.lbl_ZENKI_KOFU_DATE.Name = "lbl_ZENKI_KOFU_DATE"
        Me.lbl_ZENKI_KOFU_DATE.Size = New System.Drawing.Size(101, 15)
        Me.lbl_ZENKI_KOFU_DATE.TabIndex = 1039
        Me.lbl_ZENKI_KOFU_DATE.Text = "平成99/99/99"
        '
        'lbl_HENKAN_KEISAN_DATE
        '
        Me.lbl_HENKAN_KEISAN_DATE.AutoSize = True
        Me.lbl_HENKAN_KEISAN_DATE.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_HENKAN_KEISAN_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_HENKAN_KEISAN_DATE.Location = New System.Drawing.Point(308, 213)
        Me.lbl_HENKAN_KEISAN_DATE.Name = "lbl_HENKAN_KEISAN_DATE"
        Me.lbl_HENKAN_KEISAN_DATE.Size = New System.Drawing.Size(101, 15)
        Me.lbl_HENKAN_KEISAN_DATE.TabIndex = 1040
        Me.lbl_HENKAN_KEISAN_DATE.Text = "平成99/99/99"
        '
        'lbl_HENKAN_NINZU
        '
        Me.lbl_HENKAN_NINZU.AutoSize = True
        Me.lbl_HENKAN_NINZU.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_HENKAN_NINZU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_HENKAN_NINZU.Location = New System.Drawing.Point(308, 252)
        Me.lbl_HENKAN_NINZU.Name = "lbl_HENKAN_NINZU"
        Me.lbl_HENKAN_NINZU.Size = New System.Drawing.Size(42, 15)
        Me.lbl_HENKAN_NINZU.TabIndex = 1041
        Me.lbl_HENKAN_NINZU.Text = "9,999"
        '
        'lbl_HENKAN_GOKEI
        '
        Me.lbl_HENKAN_GOKEI.AutoSize = True
        Me.lbl_HENKAN_GOKEI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_HENKAN_GOKEI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_HENKAN_GOKEI.Location = New System.Drawing.Point(308, 291)
        Me.lbl_HENKAN_GOKEI.Name = "lbl_HENKAN_GOKEI"
        Me.lbl_HENKAN_GOKEI.Size = New System.Drawing.Size(85, 15)
        Me.lbl_HENKAN_GOKEI.TabIndex = 1042
        Me.lbl_HENKAN_GOKEI.Text = "999,999,999"
        '
        'lbl_HENKAN_RITU
        '
        Me.lbl_HENKAN_RITU.AutoSize = True
        Me.lbl_HENKAN_RITU.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_HENKAN_RITU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_HENKAN_RITU.Location = New System.Drawing.Point(308, 330)
        Me.lbl_HENKAN_RITU.Name = "lbl_HENKAN_RITU"
        Me.lbl_HENKAN_RITU.Size = New System.Drawing.Size(82, 15)
        Me.lbl_HENKAN_RITU.TabIndex = 1043
        Me.lbl_HENKAN_RITU.Text = "99.1234567"
        '
        'frmGJ8020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.lbl_HENKAN_RITU)
        Me.Controls.Add(Me.lbl_HENKAN_GOKEI)
        Me.Controls.Add(Me.lbl_HENKAN_NINZU)
        Me.Controls.Add(Me.lbl_HENKAN_KEISAN_DATE)
        Me.Controls.Add(Me.lbl_ZENKI_KOFU_DATE)
        Me.Controls.Add(Me.lbl_ZENKI_TUMITATE_DATE)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txt_BIKO)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.num_HASSEI_KAISU)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.num_KI)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.date_NOFU_KIGEN)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.date_TAISYO_NENDO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.date_JIGYO_SYURYO_NENDO)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.date_JIGYO_NENDO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label28)
        Me.Name = "frmGJ8020"
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.date_JIGYO_NENDO, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.date_JIGYO_SYURYO_NENDO, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.date_TAISYO_NENDO, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.date_NOFU_KIGEN, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.num_KI, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.num_HASSEI_KAISU, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.txt_BIKO, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.lbl_ZENKI_TUMITATE_DATE, 0)
        Me.Controls.SetChildIndex(Me.lbl_ZENKI_KOFU_DATE, 0)
        Me.Controls.SetChildIndex(Me.lbl_HENKAN_KEISAN_DATE, 0)
        Me.Controls.SetChildIndex(Me.lbl_HENKAN_NINZU, 0)
        Me.Controls.SetChildIndex(Me.lbl_HENKAN_GOKEI, 0)
        Me.Controls.SetChildIndex(Me.lbl_HENKAN_RITU, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.date_JIGYO_NENDO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_JIGYO_SYURYO_NENDO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_TAISYO_NENDO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_NOFU_KIGEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_HASSEI_KAISU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_BIKO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label28 As JBD.Gjs.Win.Label
    Friend WithEvents cmdCancel As JBD.Gjs.Win.JButton
    Friend WithEvents cmdSav As JBD.Gjs.Win.JButton
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents date_JIGYO_NENDO As JBD.Gjs.Win.GcDate
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents date_JIGYO_SYURYO_NENDO As JBD.Gjs.Win.GcDate
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents date_TAISYO_NENDO As JBD.Gjs.Win.GcDate
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents date_NOFU_KIGEN As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton5 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents num_KI As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents num_HASSEI_KAISU As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents txt_BIKO As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents Label20 As JBD.Gjs.Win.Label
    Friend WithEvents Label21 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_ZENKI_TUMITATE_DATE As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ZENKI_KOFU_DATE As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_HENKAN_KEISAN_DATE As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_HENKAN_NINZU As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_HENKAN_GOKEI As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_HENKAN_RITU As JBD.Gjs.Win.JLabel

End Class
