Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ8101
    Inherits JBD.Gjs.Win.FormM

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
        Dim DateEraYearDisplayField1 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateLiteralDisplayField1 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateMonthDisplayField1 As GrapeCity.Win.Editors.Fields.DateMonthDisplayField = New GrapeCity.Win.Editors.Fields.DateMonthDisplayField()
        Dim DateLiteralDisplayField2 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateDayDisplayField1 As GrapeCity.Win.Editors.Fields.DateDayDisplayField = New GrapeCity.Win.Editors.Fields.DateDayDisplayField()
        Dim DateEraField1 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField1 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField1 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField2 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField1 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateEraYearField2 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraDisplayField2 As GrapeCity.Win.Editors.Fields.DateEraDisplayField = New GrapeCity.Win.Editors.Fields.DateEraDisplayField()
        Dim DateEraYearDisplayField2 As GrapeCity.Win.Editors.Fields.DateEraYearDisplayField = New GrapeCity.Win.Editors.Fields.DateEraYearDisplayField()
        Dim DateLiteralDisplayField3 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateMonthDisplayField2 As GrapeCity.Win.Editors.Fields.DateMonthDisplayField = New GrapeCity.Win.Editors.Fields.DateMonthDisplayField()
        Dim DateLiteralDisplayField4 As GrapeCity.Win.Editors.Fields.DateLiteralDisplayField = New GrapeCity.Win.Editors.Fields.DateLiteralDisplayField()
        Dim DateDayDisplayField2 As GrapeCity.Win.Editors.Fields.DateDayDisplayField = New GrapeCity.Win.Editors.Fields.DateDayDisplayField()
        Dim DateEraField2 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField3 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField2 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField4 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField2 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KenCdFm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.date_TAX_DATE_FROM = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.date_TAX_DATE_TO = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.num_TAX_RITU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.cob_KenCdFm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_TAX_DATE_FROM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.date_TAX_DATE_TO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_TAX_RITU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = "消費税率マスタメンテナンス"
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdSave)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSave, 0)
        '
        'lblLOGONUSER
        '
        Me.lblLOGONUSER.Text = "さん"
        '
        'lblSysdate
        '
        Me.lblSysdate.Text = "2023年7月28日（金）"
        '
        'cmdEnd
        '
        Me.cmdEnd.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(111, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "■適用開始日"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(111, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 15)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "■適用終了日"
        '
        'cob_KenCdFm
        '
        Me.cob_KenCdFm.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_KenCdFm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KenCdFm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KenCdFm.Format = "9"
        Me.cob_KenCdFm.HighlightText = True
        Me.cob_KenCdFm.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_KenCdFm.ListHeaderPane.Height = 22
        Me.cob_KenCdFm.Location = New System.Drawing.Point(280, 135)
        Me.cob_KenCdFm.MaxLength = 2
        Me.cob_KenCdFm.Name = "cob_KenCdFm"
        Me.GcShortcut1.SetShortcuts(Me.cob_KenCdFm, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.cob_KenCdFm, Object), CType(Me.cob_KenCdFm, Object)}, New String() {"ShortcutClear", "ApplyRecommendedValue"}))
        Me.cob_KenCdFm.Size = New System.Drawing.Size(36, 22)
        Me.cob_KenCdFm.TabIndex = 872
        Me.cob_KenCdFm.Text = "00"
        '
        'date_TAX_DATE_FROM
        '
        Me.date_TAX_DATE_FROM.DefaultActiveField = DateEraYearField1
        DateEraYearDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField1.Text = "/"
        DateMonthDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField2.Text = "/"
        DateDayDisplayField1.ShowLeadingZero = True
        Me.date_TAX_DATE_FROM.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField1, DateEraYearDisplayField1, DateLiteralDisplayField1, DateMonthDisplayField1, DateLiteralDisplayField2, DateDayDisplayField1})
        DateLiteralField1.Text = "/"
        DateLiteralField2.Text = "/"
        Me.date_TAX_DATE_FROM.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateEraYearField1, DateLiteralField1, DateMonthField1, DateLiteralField2, DateDayField1})
        Me.date_TAX_DATE_FROM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_TAX_DATE_FROM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_TAX_DATE_FROM.InputCheck = True
        Me.date_TAX_DATE_FROM.Location = New System.Drawing.Point(247, 136)
        Me.date_TAX_DATE_FROM.Name = "date_TAX_DATE_FROM"
        Me.GcShortcut1.SetShortcuts(Me.date_TAX_DATE_FROM, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.date_TAX_DATE_FROM, Object), CType(Me.date_TAX_DATE_FROM, Object), CType(Me.date_TAX_DATE_FROM, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.date_TAX_DATE_FROM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.date_TAX_DATE_FROM.Size = New System.Drawing.Size(117, 21)
        Me.date_TAX_DATE_FROM.Spin.AllowSpin = False
        Me.date_TAX_DATE_FROM.TabIndex = 1
        Me.date_TAX_DATE_FROM.Value = New Date(2023, 7, 28, 0, 0, 0, 0)
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'date_TAX_DATE_TO
        '
        Me.date_TAX_DATE_TO.DefaultActiveField = DateEraYearField2
        DateEraYearDisplayField2.ShowLeadingZero = True
        DateLiteralDisplayField3.Text = "/"
        DateMonthDisplayField2.ShowLeadingZero = True
        DateLiteralDisplayField4.Text = "/"
        DateDayDisplayField2.ShowLeadingZero = True
        Me.date_TAX_DATE_TO.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField2, DateEraYearDisplayField2, DateLiteralDisplayField3, DateMonthDisplayField2, DateLiteralDisplayField4, DateDayDisplayField2})
        DateLiteralField3.Text = "/"
        DateLiteralField4.Text = "/"
        Me.date_TAX_DATE_TO.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateEraYearField2, DateLiteralField3, DateMonthField2, DateLiteralField4, DateDayField2})
        Me.date_TAX_DATE_TO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_TAX_DATE_TO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_TAX_DATE_TO.InputCheck = True
        Me.date_TAX_DATE_TO.Location = New System.Drawing.Point(247, 191)
        Me.date_TAX_DATE_TO.Name = "date_TAX_DATE_TO"
        Me.GcShortcut1.SetShortcuts(Me.date_TAX_DATE_TO, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.date_TAX_DATE_TO, Object), CType(Me.date_TAX_DATE_TO, Object), CType(Me.date_TAX_DATE_TO, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.date_TAX_DATE_TO.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.date_TAX_DATE_TO.Size = New System.Drawing.Size(117, 21)
        Me.date_TAX_DATE_TO.Spin.AllowSpin = False
        Me.date_TAX_DATE_TO.TabIndex = 2
        Me.date_TAX_DATE_TO.Value = New Date(2024, 12, 31, 0, 0, 0, 0)
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'num_TAX_RITU
        '
        Me.num_TAX_RITU.AllowDeleteToNull = True
        Me.num_TAX_RITU.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_TAX_RITU.DropDown.AllowDrop = False
        Me.num_TAX_RITU.Fields.DecimalPart.MaxDigits = 0
        Me.num_TAX_RITU.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_TAX_RITU.Fields.IntegerPart.MaxDigits = 2
        Me.num_TAX_RITU.Fields.IntegerPart.MinDigits = 1
        Me.num_TAX_RITU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_TAX_RITU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.num_TAX_RITU.HighlightText = True
        Me.num_TAX_RITU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_TAX_RITU.InputCheck = True
        Me.num_TAX_RITU.Location = New System.Drawing.Point(247, 246)
        Me.num_TAX_RITU.Name = "num_TAX_RITU"
        Me.num_TAX_RITU.NegativeColor = System.Drawing.Color.Black
        Me.GcShortcut1.SetShortcuts(Me.num_TAX_RITU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_TAX_RITU, Object), CType(Me.num_TAX_RITU, Object), CType(Me.num_TAX_RITU, Object), CType(Me.num_TAX_RITU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_TAX_RITU.Size = New System.Drawing.Size(39, 22)
        Me.num_TAX_RITU.Spin.Increment = 0
        Me.num_TAX_RITU.TabIndex = 3
        Me.num_TAX_RITU.Value = New Decimal(New Integer() {99, 0, 0, 0})
        Me.num_TAX_RITU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(29, 5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 44)
        Me.cmdSave.TabIndex = 4
        Me.cmdSave.Text = "保存"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(111, 249)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 15)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "■消費税率（%）"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(286, 249)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 871
        Me.Label2.Text = "%"
        '
        'frmGJ8101
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(794, 572)
        Me.Controls.Add(Me.num_TAX_RITU)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.date_TAX_DATE_TO)
        Me.Controls.Add(Me.date_TAX_DATE_FROM)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmGJ8101"
        Me.Text = "(GJ8101)消費税率マスタメンテナンス"
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.date_TAX_DATE_FROM, 0)
        Me.Controls.SetChildIndex(Me.date_TAX_DATE_TO, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.num_TAX_RITU, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.cob_KenCdFm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_TAX_DATE_FROM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.date_TAX_DATE_TO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_TAX_RITU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KenCdFm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents cmdSave As JBD.Gjs.Win.JButton
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents date_TAX_DATE_FROM As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents date_TAX_DATE_TO As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents num_TAX_RITU As JBD.Gjs.Win.GcNumber
    'Friend WithEvents num_TAX_RITU As JBD.Gjs.Win.GcTextBox
End Class
