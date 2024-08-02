Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ8091
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
        Dim MaskLiteralField1 As GrapeCity.Win.Editors.Fields.MaskLiteralField = New GrapeCity.Win.Editors.Fields.MaskLiteralField()
        Dim MaskPatternField1 As GrapeCity.Win.Editors.Fields.MaskPatternField = New GrapeCity.Win.Editors.Fields.MaskPatternField()
        Dim MaskLiteralField2 As GrapeCity.Win.Editors.Fields.MaskLiteralField = New GrapeCity.Win.Editors.Fields.MaskLiteralField()
        Dim MaskPatternField2 As GrapeCity.Win.Editors.Fields.MaskPatternField = New GrapeCity.Win.Editors.Fields.MaskPatternField()
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KEN_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEN_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.lblTotal = New JBD.Gjs.Win.Label(Me.components)
        Me.Label26 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_Now = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.cmdLast = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdNext = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdBef = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdTop = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.txt_NOJO_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_MEISAI_NO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.msk_ADDR_POST = New JBD.Gjs.Win.GcMask(Me.components)
        Me.txt_ADDR_2 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_ADDR_1 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_NOJO_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.DropDownButton14 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton15 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton16 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton17 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton18 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton19 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_ADDR_4 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_ADDR_3 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_KI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKUSYA_CD = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKUSYA_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.cob_KEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Now, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_NOJO_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_MEISAI_NO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.msk_ADDR_POST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_NOJO_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.lblTotal)
        Me.pnlButton.Controls.Add(Me.Label26)
        Me.pnlButton.Controls.Add(Me.txt_Now)
        Me.pnlButton.Controls.Add(Me.cmdLast)
        Me.pnlButton.Controls.Add(Me.cmdNext)
        Me.pnlButton.Controls.Add(Me.cmdBef)
        Me.pnlButton.Controls.Add(Me.cmdTop)
        Me.pnlButton.Controls.Add(Me.cmdSave)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSave, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdTop, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdBef, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdNext, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdLast, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.txt_Now, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.Label26, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.lblTotal, 0)
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
        Me.cmdEnd.Location = New System.Drawing.Point(989, 6)
        Me.cmdEnd.TabIndex = 152
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(91, 258)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 17
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
        Me.cob_KEN_CD.Location = New System.Drawing.Point(289, 255)
        Me.cob_KEN_CD.MaxLength = 2
        Me.cob_KEN_CD.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.cob_KEN_CD.Name = "cob_KEN_CD"
        Me.cob_KEN_CD.Size = New System.Drawing.Size(36, 22)
        Me.cob_KEN_CD.Spin.AllowSpin = False
        Me.cob_KEN_CD.TabIndex = 5
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
        Me.cob_KEN_NM.Location = New System.Drawing.Point(331, 255)
        Me.cob_KEN_NM.Name = "cob_KEN_NM"
        Me.cob_KEN_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cob_KEN_NM.Size = New System.Drawing.Size(119, 22)
        Me.cob_KEN_NM.TabIndex = 6
        Me.cob_KEN_NM.TabStop = False
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(412, 21)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(47, 15)
        Me.lblTotal.TabIndex = 147
        Me.lblTotal.Text = "99999"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label26.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.Location = New System.Drawing.Point(396, 21)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(15, 15)
        Me.Label26.TabIndex = 146
        Me.Label26.Text = "/"
        '
        'txt_Now
        '
        Me.txt_Now.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.txt_Now.DropDown.AllowDrop = False
        Me.txt_Now.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_Now.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_Now.Format = "9"
        Me.txt_Now.HighlightText = True
        Me.txt_Now.Location = New System.Drawing.Point(341, 16)
        Me.txt_Now.MaxLength = 9
        Me.txt_Now.Name = "txt_Now"
        Me.txt_Now.Size = New System.Drawing.Size(51, 25)
        Me.txt_Now.TabIndex = 3
        Me.txt_Now.TabStop = False
        Me.txt_Now.Text = "99999"
        '
        'cmdLast
        '
        Me.cmdLast.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdLast.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLast.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(514, 16)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 25)
        Me.cmdLast.TabIndex = 5
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = "≫"
        Me.cmdLast.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNext.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(466, 16)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 25)
        Me.cmdNext.TabIndex = 4
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = ">"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdBef
        '
        Me.cmdBef.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdBef.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdBef.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdBef.Location = New System.Drawing.Point(288, 16)
        Me.cmdBef.Name = "cmdBef"
        Me.cmdBef.Size = New System.Drawing.Size(40, 25)
        Me.cmdBef.TabIndex = 2
        Me.cmdBef.TabStop = False
        Me.cmdBef.Text = "<"
        Me.cmdBef.UseVisualStyleBackColor = True
        '
        'cmdTop
        '
        Me.cmdTop.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdTop.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTop.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdTop.Location = New System.Drawing.Point(240, 16)
        Me.cmdTop.Name = "cmdTop"
        Me.cmdTop.Size = New System.Drawing.Size(40, 25)
        Me.cmdTop.TabIndex = 1
        Me.cmdTop.TabStop = False
        Me.cmdTop.Text = "≪"
        Me.cmdTop.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(12, 6)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 44)
        Me.cmdSave.TabIndex = 6
        Me.cmdSave.Text = "保存"
        Me.cmdSave.UseVisualStyleBackColor = True
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
        Me.txt_NOJO_CD.Location = New System.Drawing.Point(289, 191)
        Me.txt_NOJO_CD.MaxLength = 3
        Me.txt_NOJO_CD.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_NOJO_CD.Name = "txt_NOJO_CD"
        Me.GcShortcut1.SetShortcuts(Me.txt_NOJO_CD, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_NOJO_CD, Object)}, New String() {"ShortcutClear"}))
        Me.txt_NOJO_CD.Size = New System.Drawing.Size(36, 20)
        Me.txt_NOJO_CD.TabIndex = 0
        Me.txt_NOJO_CD.Text = "999"
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
        Me.txt_MEISAI_NO.Location = New System.Drawing.Point(289, 374)
        Me.txt_MEISAI_NO.MaxLength = 3
        Me.txt_MEISAI_NO.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_MEISAI_NO.Name = "txt_MEISAI_NO"
        Me.GcShortcut1.SetShortcuts(Me.txt_MEISAI_NO, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_MEISAI_NO, Object)}, New String() {"ShortcutClear"}))
        Me.txt_MEISAI_NO.Size = New System.Drawing.Size(34, 20)
        Me.txt_MEISAI_NO.TabIndex = 21
        Me.txt_MEISAI_NO.Text = "999"
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
        Me.msk_ADDR_POST.Location = New System.Drawing.Point(289, 289)
        Me.msk_ADDR_POST.Name = "msk_ADDR_POST"
        Me.msk_ADDR_POST.Size = New System.Drawing.Size(101, 21)
        Me.msk_ADDR_POST.TabIndex = 7
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
        Me.txt_ADDR_2.Location = New System.Drawing.Point(479, 289)
        Me.txt_ADDR_2.MaxLength = 30
        Me.txt_ADDR_2.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_2.Name = "txt_ADDR_2"
        Me.txt_ADDR_2.Size = New System.Drawing.Size(243, 20)
        Me.txt_ADDR_2.TabIndex = 9
        Me.txt_ADDR_2.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
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
        Me.txt_ADDR_1.Location = New System.Drawing.Point(396, 289)
        Me.txt_ADDR_1.MaxLength = 8
        Me.txt_ADDR_1.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_1.Name = "txt_ADDR_1"
        Me.txt_ADDR_1.Size = New System.Drawing.Size(77, 20)
        Me.txt_ADDR_1.TabIndex = 8
        Me.txt_ADDR_1.Text = "＠＠＠＠"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(91, 295)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 15)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "■住所"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(91, 226)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(82, 15)
        Me.Label24.TabIndex = 73
        Me.Label24.Text = "■農場名称"
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
        Me.txt_NOJO_NAME.Location = New System.Drawing.Point(289, 223)
        Me.txt_NOJO_NAME.MaxLength = 40
        Me.txt_NOJO_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_NOJO_NAME.Name = "txt_NOJO_NAME"
        Me.txt_NOJO_NAME.Size = New System.Drawing.Size(325, 20)
        Me.txt_NOJO_NAME.TabIndex = 3
        Me.txt_NOJO_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
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
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(89, 191)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 15)
        Me.Label13.TabIndex = 1000
        Me.Label13.Text = "■契約者農場"
        '
        'txt_ADDR_4
        '
        Me.txt_ADDR_4.DropDown.AllowDrop = False
        Me.txt_ADDR_4.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_4.Format = "Ｚ"
        Me.txt_ADDR_4.HighlightText = True
        Me.txt_ADDR_4.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ADDR_4.Location = New System.Drawing.Point(289, 341)
        Me.txt_ADDR_4.MaxLength = 40
        Me.txt_ADDR_4.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_4.Name = "txt_ADDR_4"
        Me.txt_ADDR_4.Size = New System.Drawing.Size(325, 20)
        Me.txt_ADDR_4.TabIndex = 11
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
        Me.txt_ADDR_3.Location = New System.Drawing.Point(289, 315)
        Me.txt_ADDR_3.MaxLength = 30
        Me.txt_ADDR_3.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_3.Name = "txt_ADDR_3"
        Me.txt_ADDR_3.Size = New System.Drawing.Size(243, 20)
        Me.txt_ADDR_3.TabIndex = 10
        Me.txt_ADDR_3.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(91, 377)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 15)
        Me.Label15.TabIndex = 1025
        Me.Label15.Text = "■明細番号"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(55, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 1030
        Me.Label5.Text = "契約者"
        '
        'lbl_KI
        '
        Me.lbl_KI.AutoSize = True
        Me.lbl_KI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KI.Location = New System.Drawing.Point(55, 76)
        Me.lbl_KI.Name = "lbl_KI"
        Me.lbl_KI.Size = New System.Drawing.Size(56, 15)
        Me.lbl_KI.TabIndex = 1031
        Me.lbl_KI.Text = "JLabel1"
        '
        'lbl_KEIYAKUSYA_CD
        '
        Me.lbl_KEIYAKUSYA_CD.AutoSize = True
        Me.lbl_KEIYAKUSYA_CD.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKUSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKUSYA_CD.Location = New System.Drawing.Point(115, 110)
        Me.lbl_KEIYAKUSYA_CD.Name = "lbl_KEIYAKUSYA_CD"
        Me.lbl_KEIYAKUSYA_CD.Size = New System.Drawing.Size(47, 15)
        Me.lbl_KEIYAKUSYA_CD.TabIndex = 1032
        Me.lbl_KEIYAKUSYA_CD.Text = "99999"
        '
        'lbl_KEIYAKUSYA_NM
        '
        Me.lbl_KEIYAKUSYA_NM.AutoSize = True
        Me.lbl_KEIYAKUSYA_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKUSYA_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKUSYA_NM.Location = New System.Drawing.Point(167, 110)
        Me.lbl_KEIYAKUSYA_NM.Name = "lbl_KEIYAKUSYA_NM"
        Me.lbl_KEIYAKUSYA_NM.Size = New System.Drawing.Size(382, 15)
        Me.lbl_KEIYAKUSYA_NM.TabIndex = 1033
        Me.lbl_KEIYAKUSYA_NM.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(15, 146)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(994, 25)
        Me.Panel1.TabIndex = 1034
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(38, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(229, 19)
        Me.Label3.TabIndex = 988
        Me.Label3.Text = "契約者農場基本登録項目"
        '
        'frmGJ8091
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbl_KEIYAKUSYA_NM)
        Me.Controls.Add(Me.lbl_KEIYAKUSYA_CD)
        Me.Controls.Add(Me.lbl_KI)
        Me.Controls.Add(Me.Label5)
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
        Me.Name = "frmGJ8091"
        Me.Text = "(GJ8091)契約者農場マスタメンテナンス"
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
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lbl_KI, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKUSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKUSYA_NM, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.pnlButton.ResumeLayout(False)
        Me.pnlButton.PerformLayout()
        CType(Me.cob_KEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Now, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_NOJO_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_MEISAI_NO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.msk_ADDR_POST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_NOJO_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents cob_KEN_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEN_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents lblTotal As JBD.Gjs.Win.Label
    Friend WithEvents Label26 As JBD.Gjs.Win.Label
    Friend WithEvents txt_Now As JBD.Gjs.Win.GcTextBox
    Friend WithEvents cmdLast As JBD.Gjs.Win.JButton
    Friend WithEvents cmdNext As JBD.Gjs.Win.JButton
    Friend WithEvents cmdBef As JBD.Gjs.Win.JButton
    Friend WithEvents cmdTop As JBD.Gjs.Win.JButton
    Friend WithEvents cmdSave As JBD.Gjs.Win.JButton
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents GcDateValidator1 As GrapeCity.Win.Editors.GcDateValidator
    Friend WithEvents msk_ADDR_POST As JBD.Gjs.Win.GcMask
    Friend WithEvents txt_ADDR_2 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_ADDR_1 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents DropDownButton14 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton15 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton16 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton17 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton18 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton19 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents txt_NOJO_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents txt_NOJO_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_ADDR_4 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_ADDR_3 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_MEISAI_NO As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_KI As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKUSYA_CD As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKUSYA_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As JBD.Gjs.Win.Label

End Class
