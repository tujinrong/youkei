Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ6010
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
        Dim ValueProcess3 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange3 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
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
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblNinzu = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblGokei = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblRitu = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.grpTumi = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.lblTumiSumiYmd = New JBD.Gjs.Win.JLabel(Me.components)
        Me.rdoTumiCancel = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rdoTumiSumi = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rdoTumiTorikomi = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.grpKofu = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.lblKofuSumiYmd = New JBD.Gjs.Win.JLabel(Me.components)
        Me.rdoKofuCancel = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rdoKofuSumi = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rdoKofuTorikomi = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.grpSantei = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.lblSanteiSumiYmd = New JBD.Gjs.Win.JLabel(Me.components)
        Me.rdoSanteiCancel = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rdoSanteiSumi = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rdoSanteiTorikomi = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblKI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.numSyori, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTumi.SuspendLayout()
        Me.grpKofu.SuspendLayout()
        Me.grpSantei.SuspendLayout()
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
        Me.Label5.Location = New System.Drawing.Point(86, 151)
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
        Me.Label6.Location = New System.Drawing.Point(341, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 15)
        Me.Label6.TabIndex = 958
        Me.Label6.Text = "期"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(86, 209)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(137, 40)
        Me.Label8.TabIndex = 964
        Me.Label8.Text = "■１：前期積立金納　付額取込処理"
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
        Me.numSyori.Location = New System.Drawing.Point(272, 94)
        Me.numSyori.Name = "numSyori"
        Me.GcShortcut1.SetShortcuts(Me.numSyori, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSyori, Object), CType(Me.numSyori, Object), CType(Me.numSyori, Object), CType(Me.numSyori, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSyori.Size = New System.Drawing.Size(26, 20)
        Me.numSyori.Spin.Increment = 0
        Me.numSyori.TabIndex = 0
        ValueProcess3.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSyori).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess3})
        InvalidRange3.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        InvalidRange3.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSyori).AddRange(New Object() {InvalidRange3})
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
        Me.Label2.Location = New System.Drawing.Point(268, 151)
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
        Me.Label10.Location = New System.Drawing.Point(307, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(456, 15)
        Me.Label10.TabIndex = 989
        Me.Label10.Text = "１：積立金納付額取込処理　２：互助金交付額取込　３：繰越額算定処理"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(86, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 15)
        Me.Label11.TabIndex = 988
        Me.Label11.Text = "■処理選択"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(86, 273)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 40)
        Me.Label4.TabIndex = 994
        Me.Label4.Text = "■２：前期互助金交　付額取込処理"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(86, 337)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 40)
        Me.Label9.TabIndex = 1000
        Me.Label9.Text = "■３：前期積立金　　　繰越額算定処理"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(539, 394)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 15)
        Me.Label12.TabIndex = 1007
        Me.Label12.Text = "（人）"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(291, 395)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(157, 15)
        Me.Label14.TabIndex = 1006
        Me.Label14.Text = "□前期積立金返還人数"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(580, 426)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 15)
        Me.Label15.TabIndex = 1010
        Me.Label15.Text = "（円）"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(291, 426)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(172, 15)
        Me.Label16.TabIndex = 1009
        Me.Label16.Text = "□前期積立金返還金合計"
        '
        'lblNinzu
        '
        Me.lblNinzu.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblNinzu.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNinzu.Location = New System.Drawing.Point(476, 392)
        Me.lblNinzu.Name = "lblNinzu"
        Me.lblNinzu.Size = New System.Drawing.Size(60, 20)
        Me.lblNinzu.TabIndex = 1011
        Me.lblNinzu.Text = "9,999"
        Me.lblNinzu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGokei
        '
        Me.lblGokei.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblGokei.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGokei.Location = New System.Drawing.Point(476, 423)
        Me.lblGokei.Name = "lblGokei"
        Me.lblGokei.Size = New System.Drawing.Size(101, 20)
        Me.lblGokei.TabIndex = 1012
        Me.lblGokei.Text = "999,999,999"
        Me.lblGokei.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRitu
        '
        Me.lblRitu.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblRitu.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblRitu.Location = New System.Drawing.Point(476, 452)
        Me.lblRitu.Name = "lblRitu"
        Me.lblRitu.Size = New System.Drawing.Size(101, 20)
        Me.lblRitu.TabIndex = 1014
        Me.lblRitu.Text = "999.9999999"
        Me.lblRitu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(291, 455)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(142, 15)
        Me.Label17.TabIndex = 1013
        Me.Label17.Text = "□前期積立金返還率"
        '
        'grpTumi
        '
        Me.grpTumi.Controls.Add(Me.lblTumiSumiYmd)
        Me.grpTumi.Controls.Add(Me.rdoTumiCancel)
        Me.grpTumi.Controls.Add(Me.rdoTumiSumi)
        Me.grpTumi.Controls.Add(Me.rdoTumiTorikomi)
        Me.grpTumi.Controls.Add(Me.Label13)
        Me.grpTumi.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpTumi.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpTumi.Location = New System.Drawing.Point(265, 201)
        Me.grpTumi.Name = "grpTumi"
        Me.grpTumi.Size = New System.Drawing.Size(567, 41)
        Me.grpTumi.TabIndex = 2
        Me.grpTumi.TabStop = False
        '
        'lblTumiSumiYmd
        '
        Me.lblTumiSumiYmd.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblTumiSumiYmd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblTumiSumiYmd.Location = New System.Drawing.Point(273, 14)
        Me.lblTumiSumiYmd.Name = "lblTumiSumiYmd"
        Me.lblTumiSumiYmd.Size = New System.Drawing.Size(110, 20)
        Me.lblTumiSumiYmd.TabIndex = 996
        Me.lblTumiSumiYmd.Text = "平成 99/99/99"
        Me.lblTumiSumiYmd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoTumiCancel
        '
        Me.rdoTumiCancel.AutoSize = True
        Me.rdoTumiCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoTumiCancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoTumiCancel.Location = New System.Drawing.Point(417, 14)
        Me.rdoTumiCancel.Name = "rdoTumiCancel"
        Me.rdoTumiCancel.Size = New System.Drawing.Size(129, 20)
        Me.rdoTumiCancel.TabIndex = 3
        Me.rdoTumiCancel.Text = "処理キャンセル"
        Me.rdoTumiCancel.UseVisualStyleBackColor = True
        '
        'rdoTumiSumi
        '
        Me.rdoTumiSumi.AutoSize = True
        Me.rdoTumiSumi.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoTumiSumi.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoTumiSumi.Location = New System.Drawing.Point(171, 14)
        Me.rdoTumiSumi.Name = "rdoTumiSumi"
        Me.rdoTumiSumi.Size = New System.Drawing.Size(114, 20)
        Me.rdoTumiSumi.TabIndex = 1
        Me.rdoTumiSumi.Text = "取込処理済（"
        Me.rdoTumiSumi.UseVisualStyleBackColor = True
        '
        'rdoTumiTorikomi
        '
        Me.rdoTumiTorikomi.AutoSize = True
        Me.rdoTumiTorikomi.Checked = True
        Me.rdoTumiTorikomi.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoTumiTorikomi.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoTumiTorikomi.Location = New System.Drawing.Point(12, 14)
        Me.rdoTumiTorikomi.Name = "rdoTumiTorikomi"
        Me.rdoTumiTorikomi.Size = New System.Drawing.Size(152, 20)
        Me.rdoTumiTorikomi.TabIndex = 0
        Me.rdoTumiTorikomi.TabStop = True
        Me.rdoTumiTorikomi.Text = "取込処理（未処理）"
        Me.rdoTumiTorikomi.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(385, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 15)
        Me.Label13.TabIndex = 995
        Me.Label13.Text = "）"
        '
        'grpKofu
        '
        Me.grpKofu.Controls.Add(Me.lblKofuSumiYmd)
        Me.grpKofu.Controls.Add(Me.rdoKofuCancel)
        Me.grpKofu.Controls.Add(Me.rdoKofuSumi)
        Me.grpKofu.Controls.Add(Me.rdoKofuTorikomi)
        Me.grpKofu.Controls.Add(Me.Label3)
        Me.grpKofu.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpKofu.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpKofu.Location = New System.Drawing.Point(265, 264)
        Me.grpKofu.Name = "grpKofu"
        Me.grpKofu.Size = New System.Drawing.Size(567, 41)
        Me.grpKofu.TabIndex = 3
        Me.grpKofu.TabStop = False
        '
        'lblKofuSumiYmd
        '
        Me.lblKofuSumiYmd.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblKofuSumiYmd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblKofuSumiYmd.Location = New System.Drawing.Point(273, 14)
        Me.lblKofuSumiYmd.Name = "lblKofuSumiYmd"
        Me.lblKofuSumiYmd.Size = New System.Drawing.Size(110, 20)
        Me.lblKofuSumiYmd.TabIndex = 1001
        Me.lblKofuSumiYmd.Text = "平成 99/99/99"
        Me.lblKofuSumiYmd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoKofuCancel
        '
        Me.rdoKofuCancel.AutoSize = True
        Me.rdoKofuCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoKofuCancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoKofuCancel.Location = New System.Drawing.Point(417, 14)
        Me.rdoKofuCancel.Name = "rdoKofuCancel"
        Me.rdoKofuCancel.Size = New System.Drawing.Size(129, 20)
        Me.rdoKofuCancel.TabIndex = 3
        Me.rdoKofuCancel.Text = "処理キャンセル"
        Me.rdoKofuCancel.UseVisualStyleBackColor = True
        '
        'rdoKofuSumi
        '
        Me.rdoKofuSumi.AutoSize = True
        Me.rdoKofuSumi.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoKofuSumi.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoKofuSumi.Location = New System.Drawing.Point(171, 14)
        Me.rdoKofuSumi.Name = "rdoKofuSumi"
        Me.rdoKofuSumi.Size = New System.Drawing.Size(114, 20)
        Me.rdoKofuSumi.TabIndex = 1
        Me.rdoKofuSumi.Text = "取込処理済（"
        Me.rdoKofuSumi.UseVisualStyleBackColor = True
        '
        'rdoKofuTorikomi
        '
        Me.rdoKofuTorikomi.AutoSize = True
        Me.rdoKofuTorikomi.Checked = True
        Me.rdoKofuTorikomi.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoKofuTorikomi.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoKofuTorikomi.Location = New System.Drawing.Point(12, 14)
        Me.rdoKofuTorikomi.Name = "rdoKofuTorikomi"
        Me.rdoKofuTorikomi.Size = New System.Drawing.Size(152, 20)
        Me.rdoKofuTorikomi.TabIndex = 0
        Me.rdoKofuTorikomi.TabStop = True
        Me.rdoKofuTorikomi.Text = "取込処理（未処理）"
        Me.rdoKofuTorikomi.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(385, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 15)
        Me.Label3.TabIndex = 1000
        Me.Label3.Text = "）"
        '
        'grpSantei
        '
        Me.grpSantei.Controls.Add(Me.lblSanteiSumiYmd)
        Me.grpSantei.Controls.Add(Me.rdoSanteiCancel)
        Me.grpSantei.Controls.Add(Me.rdoSanteiSumi)
        Me.grpSantei.Controls.Add(Me.rdoSanteiTorikomi)
        Me.grpSantei.Controls.Add(Me.Label7)
        Me.grpSantei.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpSantei.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpSantei.Location = New System.Drawing.Point(265, 328)
        Me.grpSantei.Name = "grpSantei"
        Me.grpSantei.Size = New System.Drawing.Size(567, 41)
        Me.grpSantei.TabIndex = 4
        Me.grpSantei.TabStop = False
        '
        'lblSanteiSumiYmd
        '
        Me.lblSanteiSumiYmd.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblSanteiSumiYmd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblSanteiSumiYmd.Location = New System.Drawing.Point(273, 14)
        Me.lblSanteiSumiYmd.Name = "lblSanteiSumiYmd"
        Me.lblSanteiSumiYmd.Size = New System.Drawing.Size(110, 20)
        Me.lblSanteiSumiYmd.TabIndex = 1007
        Me.lblSanteiSumiYmd.Text = "平成 99/99/99"
        Me.lblSanteiSumiYmd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoSanteiCancel
        '
        Me.rdoSanteiCancel.AutoSize = True
        Me.rdoSanteiCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoSanteiCancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoSanteiCancel.Location = New System.Drawing.Point(417, 14)
        Me.rdoSanteiCancel.Name = "rdoSanteiCancel"
        Me.rdoSanteiCancel.Size = New System.Drawing.Size(129, 20)
        Me.rdoSanteiCancel.TabIndex = 3
        Me.rdoSanteiCancel.Text = "処理キャンセル"
        Me.rdoSanteiCancel.UseVisualStyleBackColor = True
        '
        'rdoSanteiSumi
        '
        Me.rdoSanteiSumi.AutoSize = True
        Me.rdoSanteiSumi.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoSanteiSumi.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoSanteiSumi.Location = New System.Drawing.Point(171, 14)
        Me.rdoSanteiSumi.Name = "rdoSanteiSumi"
        Me.rdoSanteiSumi.Size = New System.Drawing.Size(114, 20)
        Me.rdoSanteiSumi.TabIndex = 1
        Me.rdoSanteiSumi.Text = "取込処理済（"
        Me.rdoSanteiSumi.UseVisualStyleBackColor = True
        '
        'rdoSanteiTorikomi
        '
        Me.rdoSanteiTorikomi.AutoSize = True
        Me.rdoSanteiTorikomi.Checked = True
        Me.rdoSanteiTorikomi.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoSanteiTorikomi.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoSanteiTorikomi.Location = New System.Drawing.Point(12, 14)
        Me.rdoSanteiTorikomi.Name = "rdoSanteiTorikomi"
        Me.rdoSanteiTorikomi.Size = New System.Drawing.Size(152, 20)
        Me.rdoSanteiTorikomi.TabIndex = 0
        Me.rdoSanteiTorikomi.TabStop = True
        Me.rdoSanteiTorikomi.Text = "取込処理（未処理）"
        Me.rdoSanteiTorikomi.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(385, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 15)
        Me.Label7.TabIndex = 1006
        Me.Label7.Text = "）"
        '
        'lblKI
        '
        Me.lblKI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKI.Location = New System.Drawing.Point(294, 148)
        Me.lblKI.Name = "lblKI"
        Me.lblKI.Size = New System.Drawing.Size(41, 20)
        Me.lblKI.TabIndex = 1015
        Me.lblKI.Text = "99"
        Me.lblKI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmGJ6010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.lblKI)
        Me.Controls.Add(Me.grpSantei)
        Me.Controls.Add(Me.grpKofu)
        Me.Controls.Add(Me.grpTumi)
        Me.Controls.Add(Me.lblRitu)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lblGokei)
        Me.Controls.Add(Me.lblNinzu)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numSyori)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmGJ6010"
        Me.Text = "(GJ6010)生産者積立金返還金計算処理"
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.numSyori, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.lblNinzu, 0)
        Me.Controls.SetChildIndex(Me.lblGokei, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.lblRitu, 0)
        Me.Controls.SetChildIndex(Me.grpTumi, 0)
        Me.Controls.SetChildIndex(Me.grpKofu, 0)
        Me.Controls.SetChildIndex(Me.grpSantei, 0)
        Me.Controls.SetChildIndex(Me.lblKI, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.numSyori, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTumi.ResumeLayout(False)
        Me.grpTumi.PerformLayout()
        Me.grpKofu.ResumeLayout(False)
        Me.grpKofu.PerformLayout()
        Me.grpSantei.ResumeLayout(False)
        Me.grpSantei.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
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
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents lblNinzu As JBD.Gjs.Win.JLabel
    Friend WithEvents lblGokei As JBD.Gjs.Win.JLabel
    Friend WithEvents lblRitu As JBD.Gjs.Win.JLabel
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents grpTumi As JBD.Gjs.Win.GroupBox
    Friend WithEvents rdoTumiCancel As JBD.Gjs.Win.RadioButton
    Friend WithEvents rdoTumiSumi As JBD.Gjs.Win.RadioButton
    Friend WithEvents rdoTumiTorikomi As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents grpKofu As JBD.Gjs.Win.GroupBox
    Friend WithEvents rdoKofuCancel As JBD.Gjs.Win.RadioButton
    Friend WithEvents rdoKofuSumi As JBD.Gjs.Win.RadioButton
    Friend WithEvents rdoKofuTorikomi As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents grpSantei As JBD.Gjs.Win.GroupBox
    Friend WithEvents rdoSanteiCancel As JBD.Gjs.Win.RadioButton
    Friend WithEvents rdoSanteiSumi As JBD.Gjs.Win.RadioButton
    Friend WithEvents rdoSanteiTorikomi As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents lblTumiSumiYmd As JBD.Gjs.Win.JLabel
    Friend WithEvents lblKofuSumiYmd As JBD.Gjs.Win.JLabel
    Friend WithEvents lblSanteiSumiYmd As JBD.Gjs.Win.JLabel
    Friend WithEvents lblKI As JBD.Gjs.Win.JLabel

End Class
