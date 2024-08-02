Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ6030
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
        Dim ValueProcess1 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange1 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.numSyori = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.cmdExec = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdCancel = New JBD.Gjs.Win.JButton(Me.components)
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblJimuKensu = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblKeiyakuKensu = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblNojoKensu = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblKI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblJimuKi = New JBD.Gjs.Win.Label(Me.components)
        Me.lblKeiyakuKi = New JBD.Gjs.Win.Label(Me.components)
        Me.lblNojoKi = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.numSyori, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdCancel)
        Me.pnlButton.Controls.Add(Me.cmdExec)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdExec, 0)
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
        Me.Label5.Location = New System.Drawing.Point(86, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 15)
        Me.Label5.TabIndex = 957
        Me.Label5.Text = "■対象期（前期）"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(341, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 15)
        Me.Label6.TabIndex = 958
        Me.Label6.Text = "期"
        '
        'numSyori
        '
        Me.numSyori.AllowDeleteToNull = True
        Me.numSyori.ContentAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.numSyori.DropDown.AllowDrop = False
        Me.numSyori.Fields.DecimalPart.MaxDigits = 0
        Me.numSyori.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSyori.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numSyori.Fields.IntegerPart.MaxDigits = 1
        Me.numSyori.Fields.IntegerPart.MinDigits = 1
        Me.numSyori.Fields.SignPrefix.NegativePattern = ""
        Me.numSyori.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSyori.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSyori.HighlightText = True
        Me.numSyori.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSyori.InputCheck = True
        Me.numSyori.Location = New System.Drawing.Point(272, 129)
        Me.numSyori.Name = "numSyori"
        Me.GcShortcut1.SetShortcuts(Me.numSyori, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSyori, Object), CType(Me.numSyori, Object), CType(Me.numSyori, Object), CType(Me.numSyori, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSyori.Size = New System.Drawing.Size(26, 20)
        Me.numSyori.Spin.Increment = 0
        Me.numSyori.TabIndex = 0
        ValueProcess1.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSyori).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess1})
        InvalidRange1.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        InvalidRange1.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSyori).AddRange(New Object() {InvalidRange1})
        Me.numSyori.Value = New Decimal(New Integer() {9, 0, 0, 0})
        Me.numSyori.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        Me.numSyori.ZeroSuppress = True
        '
        'cmdExec
        '
        Me.cmdExec.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdExec.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdExec.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdExec.Location = New System.Drawing.Point(17, 6)
        Me.cmdExec.Name = "cmdExec"
        Me.cmdExec.Size = New System.Drawing.Size(92, 44)
        Me.cmdExec.TabIndex = 0
        Me.cmdExec.Text = "実行"
        Me.cmdExec.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdCancel.Location = New System.Drawing.Point(213, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(92, 44)
        Me.cmdCancel.TabIndex = 1
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
        Me.Label2.Location = New System.Drawing.Point(268, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 15)
        Me.Label2.TabIndex = 965
        Me.Label2.Text = "第"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(307, 132)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(555, 15)
        Me.Label10.TabIndex = 989
        Me.Label10.Text = "１：事務委託先マスタコピー処理　２：契約者マスタコピー処理　３：農場マスタコピー処理"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(86, 132)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 15)
        Me.Label11.TabIndex = 988
        Me.Label11.Text = "■マスタ選択"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(268, 263)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(196, 15)
        Me.Label14.TabIndex = 1006
        Me.Label14.Text = "□事務委託先マスタ処理件数"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(268, 302)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(166, 15)
        Me.Label16.TabIndex = 1009
        Me.Label16.Text = "□契約者マスタ処理件数"
        '
        'lblJimuKensu
        '
        Me.lblJimuKensu.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblJimuKensu.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblJimuKensu.Location = New System.Drawing.Point(528, 260)
        Me.lblJimuKensu.Name = "lblJimuKensu"
        Me.lblJimuKensu.Size = New System.Drawing.Size(60, 20)
        Me.lblJimuKensu.TabIndex = 1011
        Me.lblJimuKensu.Text = "9,999"
        Me.lblJimuKensu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblKeiyakuKensu
        '
        Me.lblKeiyakuKensu.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblKeiyakuKensu.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKeiyakuKensu.Location = New System.Drawing.Point(528, 299)
        Me.lblKeiyakuKensu.Name = "lblKeiyakuKensu"
        Me.lblKeiyakuKensu.Size = New System.Drawing.Size(60, 20)
        Me.lblKeiyakuKensu.TabIndex = 1012
        Me.lblKeiyakuKensu.Text = "9,999"
        Me.lblKeiyakuKensu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNojoKensu
        '
        Me.lblNojoKensu.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblNojoKensu.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNojoKensu.Location = New System.Drawing.Point(528, 338)
        Me.lblNojoKensu.Name = "lblNojoKensu"
        Me.lblNojoKensu.Size = New System.Drawing.Size(60, 20)
        Me.lblNojoKensu.TabIndex = 1014
        Me.lblNojoKensu.Text = "9,999"
        Me.lblNojoKensu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(268, 341)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(151, 15)
        Me.Label17.TabIndex = 1013
        Me.Label17.Text = "□農場マスタ処理件数"
        '
        'lblKI
        '
        Me.lblKI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKI.Location = New System.Drawing.Point(294, 183)
        Me.lblKI.Name = "lblKI"
        Me.lblKI.Size = New System.Drawing.Size(41, 20)
        Me.lblKI.TabIndex = 1015
        Me.lblKI.Text = "99"
        Me.lblKI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblJimuKi
        '
        Me.lblJimuKi.AutoSize = True
        Me.lblJimuKi.BackColor = System.Drawing.Color.Transparent
        Me.lblJimuKi.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblJimuKi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblJimuKi.Location = New System.Drawing.Point(464, 263)
        Me.lblJimuKi.Name = "lblJimuKi"
        Me.lblJimuKi.Size = New System.Drawing.Size(54, 15)
        Me.lblJimuKi.TabIndex = 1016
        Me.lblJimuKi.Text = "（99期）"
        '
        'lblKeiyakuKi
        '
        Me.lblKeiyakuKi.AutoSize = True
        Me.lblKeiyakuKi.BackColor = System.Drawing.Color.Transparent
        Me.lblKeiyakuKi.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKeiyakuKi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblKeiyakuKi.Location = New System.Drawing.Point(434, 302)
        Me.lblKeiyakuKi.Name = "lblKeiyakuKi"
        Me.lblKeiyakuKi.Size = New System.Drawing.Size(54, 15)
        Me.lblKeiyakuKi.TabIndex = 1017
        Me.lblKeiyakuKi.Text = "（99期）"
        '
        'lblNojoKi
        '
        Me.lblNojoKi.AutoSize = True
        Me.lblNojoKi.BackColor = System.Drawing.Color.Transparent
        Me.lblNojoKi.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNojoKi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNojoKi.Location = New System.Drawing.Point(421, 341)
        Me.lblNojoKi.Name = "lblNojoKi"
        Me.lblNojoKi.Size = New System.Drawing.Size(54, 15)
        Me.lblNojoKi.TabIndex = 1018
        Me.lblNojoKi.Text = "（99期）"
        '
        'frmGJ6030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.lblNojoKi)
        Me.Controls.Add(Me.lblKeiyakuKi)
        Me.Controls.Add(Me.lblJimuKi)
        Me.Controls.Add(Me.lblKI)
        Me.Controls.Add(Me.lblNojoKensu)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lblKeiyakuKensu)
        Me.Controls.Add(Me.lblJimuKensu)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.numSyori)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmGJ6030"
        Me.Text = "(GJ6030)各種マスタの次期対応コピー処理"
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.numSyori, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.lblJimuKensu, 0)
        Me.Controls.SetChildIndex(Me.lblKeiyakuKensu, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.lblNojoKensu, 0)
        Me.Controls.SetChildIndex(Me.lblKI, 0)
        Me.Controls.SetChildIndex(Me.lblJimuKi, 0)
        Me.Controls.SetChildIndex(Me.lblKeiyakuKi, 0)
        Me.Controls.SetChildIndex(Me.lblNojoKi, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.numSyori, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents cmdCancel As JBD.Gjs.Win.JButton
    Friend WithEvents cmdExec As JBD.Gjs.Win.JButton
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GcDateValidator1 As GrapeCity.Win.Editors.GcDateValidator
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents numSyori As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents lblJimuKensu As JBD.Gjs.Win.JLabel
    Friend WithEvents lblKeiyakuKensu As JBD.Gjs.Win.JLabel
    Friend WithEvents lblNojoKensu As JBD.Gjs.Win.JLabel
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents lblKI As JBD.Gjs.Win.JLabel
    Friend WithEvents lblJimuKi As JBD.Gjs.Win.Label
    Friend WithEvents lblKeiyakuKi As JBD.Gjs.Win.Label
    Friend WithEvents lblNojoKi As JBD.Gjs.Win.Label

End Class
