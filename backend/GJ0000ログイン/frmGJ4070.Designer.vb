Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ4070
    Inherits JBD.Gjs.Win.FormL
    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub
    Public Sub New(ByVal pPFSINI_Array As pGJSINI)
        MyBase.New(pPFSINI_Array)
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
        Dim ValueProcess1 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange1 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.numKI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.numHasseiKaisuFrom = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numHasseiKaisuTo = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.cmdPreview = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdCancel = New JBD.Gjs.Win.JButton(Me.components)
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.chkTori = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.chkUzura = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.chkOutput = New JBD.Gjs.Win.CheckBox(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHasseiKaisuFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHasseiKaisuTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdCancel)
        Me.pnlButton.Controls.Add(Me.cmdPreview)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdPreview, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCancel, 0)
        '
        'cmdEnd
        '
        Me.cmdEnd.TabIndex = 99
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(108, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 957
        Me.Label5.Text = "■対象期"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(311, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 15)
        Me.Label6.TabIndex = 958
        Me.Label6.Text = "期"
        '
        'numKI
        '
        Me.numKI.AllowDeleteToNull = True
        Me.numKI.ContentAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.numKI.DropDown.AllowDrop = False
        Me.numKI.Fields.DecimalPart.MaxDigits = 0
        Me.numKI.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKI.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKI.Fields.IntegerPart.MaxDigits = 2
        Me.numKI.Fields.IntegerPart.MinDigits = 1
        Me.numKI.Fields.SignPrefix.NegativePattern = ""
        Me.numKI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKI.HighlightText = True
        Me.numKI.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKI.InputCheck = True
        Me.numKI.Location = New System.Drawing.Point(266, 138)
        Me.numKI.Name = "numKI"
        Me.GcShortcut1.SetShortcuts(Me.numKI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKI, Object), CType(Me.numKI, Object), CType(Me.numKI, Object), CType(Me.numKI, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKI.Size = New System.Drawing.Size(39, 20)
        Me.numKI.Spin.Increment = 0
        Me.numKI.TabIndex = 0
        ValueProcess1.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKI).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess1})
        InvalidRange1.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        InvalidRange1.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKI).AddRange(New Object() {InvalidRange1})
        Me.numKI.Value = New Decimal(New Integer() {99, 0, 0, 0})
        Me.numKI.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        Me.numKI.ZeroSuppress = True
        '
        'numHasseiKaisuFrom
        '
        Me.numHasseiKaisuFrom.AllowDeleteToNull = True
        Me.numHasseiKaisuFrom.ContentAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.numHasseiKaisuFrom.DropDown.AllowDrop = False
        Me.numHasseiKaisuFrom.Fields.DecimalPart.MaxDigits = 3
        Me.numHasseiKaisuFrom.Fields.IntegerPart.MaxDigits = 3
        Me.numHasseiKaisuFrom.Fields.IntegerPart.MinDigits = 1
        Me.numHasseiKaisuFrom.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numHasseiKaisuFrom.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.numHasseiKaisuFrom.HighlightText = True
        Me.numHasseiKaisuFrom.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numHasseiKaisuFrom.InputCheck = True
        Me.numHasseiKaisuFrom.Location = New System.Drawing.Point(237, 191)
        Me.numHasseiKaisuFrom.Name = "numHasseiKaisuFrom"
        Me.GcShortcut1.SetShortcuts(Me.numHasseiKaisuFrom, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numHasseiKaisuFrom, Object), CType(Me.numHasseiKaisuFrom, Object), CType(Me.numHasseiKaisuFrom, Object), CType(Me.numHasseiKaisuFrom, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numHasseiKaisuFrom.Size = New System.Drawing.Size(56, 20)
        Me.numHasseiKaisuFrom.Spin.AllowSpin = False
        Me.numHasseiKaisuFrom.Spin.Increment = 0
        Me.numHasseiKaisuFrom.Spin.SpinOnKeys = False
        Me.numHasseiKaisuFrom.Spin.Wrap = False
        Me.numHasseiKaisuFrom.TabIndex = 1
        Me.numHasseiKaisuFrom.Value = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numHasseiKaisuFrom.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numHasseiKaisuTo
        '
        Me.numHasseiKaisuTo.AllowDeleteToNull = True
        Me.numHasseiKaisuTo.ContentAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.numHasseiKaisuTo.DropDown.AllowDrop = False
        Me.numHasseiKaisuTo.Fields.DecimalPart.MaxDigits = 3
        Me.numHasseiKaisuTo.Fields.IntegerPart.MaxDigits = 3
        Me.numHasseiKaisuTo.Fields.IntegerPart.MinDigits = 1
        Me.numHasseiKaisuTo.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numHasseiKaisuTo.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.numHasseiKaisuTo.HighlightText = True
        Me.numHasseiKaisuTo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numHasseiKaisuTo.InputCheck = True
        Me.numHasseiKaisuTo.Location = New System.Drawing.Point(338, 191)
        Me.numHasseiKaisuTo.Name = "numHasseiKaisuTo"
        Me.GcShortcut1.SetShortcuts(Me.numHasseiKaisuTo, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numHasseiKaisuTo, Object), CType(Me.numHasseiKaisuTo, Object), CType(Me.numHasseiKaisuTo, Object), CType(Me.numHasseiKaisuTo, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numHasseiKaisuTo.Size = New System.Drawing.Size(56, 20)
        Me.numHasseiKaisuTo.Spin.AllowSpin = False
        Me.numHasseiKaisuTo.Spin.Increment = 0
        Me.numHasseiKaisuTo.Spin.SpinOnKeys = False
        Me.numHasseiKaisuTo.Spin.Wrap = False
        Me.numHasseiKaisuTo.TabIndex = 2
        Me.numHasseiKaisuTo.Value = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numHasseiKaisuTo.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'cmdPreview
        '
        Me.cmdPreview.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdPreview.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPreview.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdPreview.Location = New System.Drawing.Point(17, 6)
        Me.cmdPreview.Name = "cmdPreview"
        Me.cmdPreview.Size = New System.Drawing.Size(92, 44)
        Me.cmdPreview.TabIndex = 1
        Me.cmdPreview.Text = "プレビュー"
        Me.cmdPreview.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdCancel.Location = New System.Drawing.Point(213, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(92, 44)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(237, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 15)
        Me.Label2.TabIndex = 965
        Me.Label2.Text = "第"
        '
        'chkTori
        '
        Me.chkTori.AutoSize = True
        Me.chkTori.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkTori.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkTori.Location = New System.Drawing.Point(237, 239)
        Me.chkTori.Name = "chkTori"
        Me.chkTori.Size = New System.Drawing.Size(113, 20)
        Me.chkTori.TabIndex = 3
        Me.chkTori.Text = "鶏以外を除く"
        Me.chkTori.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(108, 242)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 15)
        Me.Label7.TabIndex = 969
        Me.Label7.Text = "■集計区分"
        '
        'chkUzura
        '
        Me.chkUzura.AutoSize = True
        Me.chkUzura.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkUzura.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkUzura.Location = New System.Drawing.Point(395, 239)
        Me.chkUzura.Name = "chkUzura"
        Me.chkUzura.Size = New System.Drawing.Size(77, 20)
        Me.chkUzura.TabIndex = 4
        Me.chkUzura.Text = "鶏以外"
        Me.chkUzura.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(108, 194)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 15)
        Me.Label15.TabIndex = 988
        Me.Label15.Text = "■認定回数"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(305, 194)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(22, 15)
        Me.Label14.TabIndex = 989
        Me.Label14.Text = "～"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(108, 289)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 991
        Me.Label3.Text = "□出力区分"
        '
        'chkOutput
        '
        Me.chkOutput.AutoSize = True
        Me.chkOutput.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkOutput.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.chkOutput.Location = New System.Drawing.Point(237, 286)
        Me.chkOutput.Name = "chkOutput"
        Me.chkOutput.Size = New System.Drawing.Size(245, 20)
        Me.chkOutput.TabIndex = 5
        Me.chkOutput.Text = "発生しない鶏の種類は印字しない"
        Me.chkOutput.UseVisualStyleBackColor = True
        '
        'frmGJ4070
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkOutput)
        Me.Controls.Add(Me.numHasseiKaisuTo)
        Me.Controls.Add(Me.numHasseiKaisuFrom)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.chkUzura)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkTori)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numKI)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmGJ4070"
        Me.Text = "(GJ4070)互助金交付集計表"
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.numKI, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.chkTori, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.chkUzura, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.numHasseiKaisuFrom, 0)
        Me.Controls.SetChildIndex(Me.numHasseiKaisuTo, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.chkOutput, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHasseiKaisuFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHasseiKaisuTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents numKI As JBD.Gjs.Win.GcNumber
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents cmdCancel As JBD.Gjs.Win.JButton
    Friend WithEvents cmdPreview As JBD.Gjs.Win.JButton
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GcDateValidator1 As GrapeCity.Win.Editors.GcDateValidator
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents chkUzura As JBD.Gjs.Win.CheckBox
    Friend WithEvents chkTori As JBD.Gjs.Win.CheckBox
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents numHasseiKaisuFrom As JBD.Gjs.Win.GcNumber
    Friend WithEvents numHasseiKaisuTo As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents chkOutput As JBD.Gjs.Win.CheckBox

End Class
