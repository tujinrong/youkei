Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ8061
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
        Me.txt_ITAKU_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_ADDR_E_MAIL = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_MATOMESAKI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_LABELHAKKO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_JYOGAI_FLG = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.Label29 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label34 = New JBD.Gjs.Win.Label(Me.components)
        Me.msk_ADDR_POST = New JBD.Gjs.Win.GcMask(Me.components)
        Me.txt_ADDR_2 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_ADDR_1 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_NYUKINHOHO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_DAIHYO_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_ITAKU_RYAKU = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_ITAKU_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.DropDownButton14 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton15 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton16 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton17 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton18 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton19 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label56 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_ADDR_FAX = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_ADDR_TEL = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_TANTO_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_ADDR_4 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_ADDR_3 = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.GroupBox1 = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_BANK_INJI_KBN2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_BANK_INJI_KBN1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_MOSIKOMISYORUI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_SEIKYUSYO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_BIKO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.lbl_KI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label32 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.cob_KEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Now, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ITAKU_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_E_MAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_MATOMESAKI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_LABELHAKKO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_JYOGAI_FLG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.msk_ADDR_POST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_NYUKINHOHO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_DAIHYO_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ITAKU_RYAKU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ITAKU_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_FAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_TEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TANTO_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ADDR_3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txt_MOSIKOMISYORUI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SEIKYUSYO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_BIKO, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label2.Location = New System.Drawing.Point(84, 165)
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
        Me.cob_KEN_CD.Location = New System.Drawing.Point(284, 162)
        Me.cob_KEN_CD.MaxLength = 2
        Me.cob_KEN_CD.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.cob_KEN_CD.Name = "cob_KEN_CD"
        Me.cob_KEN_CD.Size = New System.Drawing.Size(36, 22)
        Me.cob_KEN_CD.Spin.AllowSpin = False
        Me.cob_KEN_CD.TabIndex = 1
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
        Me.cob_KEN_NM.Location = New System.Drawing.Point(326, 162)
        Me.cob_KEN_NM.Name = "cob_KEN_NM"
        Me.cob_KEN_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton2})
        Me.cob_KEN_NM.Size = New System.Drawing.Size(119, 22)
        Me.cob_KEN_NM.TabIndex = 2
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
        'txt_ITAKU_CD
        '
        Me.txt_ITAKU_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_ITAKU_CD.DropDown.AllowDrop = False
        Me.txt_ITAKU_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ITAKU_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_ITAKU_CD.Format = "9"
        Me.txt_ITAKU_CD.HighlightText = True
        Me.txt_ITAKU_CD.InputCheck = True
        Me.txt_ITAKU_CD.Location = New System.Drawing.Point(284, 136)
        Me.txt_ITAKU_CD.MaxLength = 3
        Me.txt_ITAKU_CD.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ITAKU_CD.Name = "txt_ITAKU_CD"
        Me.GcShortcut1.SetShortcuts(Me.txt_ITAKU_CD, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_ITAKU_CD, Object)}, New String() {"ShortcutClear"}))
        Me.txt_ITAKU_CD.Size = New System.Drawing.Size(36, 20)
        Me.txt_ITAKU_CD.TabIndex = 0
        Me.txt_ITAKU_CD.Text = "999"
        '
        'txt_ADDR_E_MAIL
        '
        Me.txt_ADDR_E_MAIL.DropDown.AllowDrop = False
        Me.txt_ADDR_E_MAIL.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_E_MAIL.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_E_MAIL.Format = "Aa#@"
        Me.txt_ADDR_E_MAIL.HighlightText = True
        Me.txt_ADDR_E_MAIL.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_ADDR_E_MAIL.Location = New System.Drawing.Point(284, 403)
        Me.txt_ADDR_E_MAIL.MaxLength = 50
        Me.txt_ADDR_E_MAIL.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_E_MAIL.Name = "txt_ADDR_E_MAIL"
        Me.GcShortcut1.SetShortcuts(Me.txt_ADDR_E_MAIL, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_ADDR_E_MAIL, Object)}, New String() {"ShortcutClear"}))
        Me.txt_ADDR_E_MAIL.Size = New System.Drawing.Size(512, 21)
        Me.txt_ADDR_E_MAIL.TabIndex = 28
        Me.txt_ADDR_E_MAIL.Text = "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
        '
        'txt_MATOMESAKI
        '
        Me.txt_MATOMESAKI.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_MATOMESAKI.DropDown.AllowDrop = False
        Me.txt_MATOMESAKI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_MATOMESAKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_MATOMESAKI.Format = "9"
        Me.txt_MATOMESAKI.HighlightText = True
        Me.txt_MATOMESAKI.Location = New System.Drawing.Point(284, 472)
        Me.txt_MATOMESAKI.MaxLength = 1
        Me.txt_MATOMESAKI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_MATOMESAKI.Name = "txt_MATOMESAKI"
        Me.GcShortcut1.SetShortcuts(Me.txt_MATOMESAKI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_MATOMESAKI, Object)}, New String() {"ShortcutClear"}))
        Me.txt_MATOMESAKI.Size = New System.Drawing.Size(23, 20)
        Me.txt_MATOMESAKI.TabIndex = 32
        Me.txt_MATOMESAKI.Text = "9"
        '
        'txt_LABELHAKKO
        '
        Me.txt_LABELHAKKO.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_LABELHAKKO.DropDown.AllowDrop = False
        Me.txt_LABELHAKKO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_LABELHAKKO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_LABELHAKKO.Format = "9"
        Me.txt_LABELHAKKO.HighlightText = True
        Me.txt_LABELHAKKO.Location = New System.Drawing.Point(284, 583)
        Me.txt_LABELHAKKO.MaxLength = 1
        Me.txt_LABELHAKKO.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_LABELHAKKO.Name = "txt_LABELHAKKO"
        Me.GcShortcut1.SetShortcuts(Me.txt_LABELHAKKO, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_LABELHAKKO, Object)}, New String() {"ShortcutClear"}))
        Me.txt_LABELHAKKO.Size = New System.Drawing.Size(23, 20)
        Me.txt_LABELHAKKO.TabIndex = 41
        Me.txt_LABELHAKKO.Text = "9"
        '
        'txt_JYOGAI_FLG
        '
        Me.txt_JYOGAI_FLG.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_JYOGAI_FLG.DropDown.AllowDrop = False
        Me.txt_JYOGAI_FLG.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_JYOGAI_FLG.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_JYOGAI_FLG.Format = "9"
        Me.txt_JYOGAI_FLG.HighlightText = True
        Me.txt_JYOGAI_FLG.Location = New System.Drawing.Point(284, 612)
        Me.txt_JYOGAI_FLG.MaxLength = 2
        Me.txt_JYOGAI_FLG.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_JYOGAI_FLG.Name = "txt_JYOGAI_FLG"
        Me.GcShortcut1.SetShortcuts(Me.txt_JYOGAI_FLG, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_JYOGAI_FLG, Object)}, New String() {"ShortcutClear"}))
        Me.txt_JYOGAI_FLG.Size = New System.Drawing.Size(34, 20)
        Me.txt_JYOGAI_FLG.TabIndex = 42
        Me.txt_JYOGAI_FLG.Text = "99"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(84, 378)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(67, 15)
        Me.Label29.TabIndex = 58
        Me.Label29.Text = "■連絡先"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(84, 244)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(97, 15)
        Me.Label34.TabIndex = 44
        Me.Label34.Text = "□代表者氏名"
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
        Me.msk_ADDR_POST.Location = New System.Drawing.Point(284, 294)
        Me.msk_ADDR_POST.Name = "msk_ADDR_POST"
        Me.msk_ADDR_POST.Size = New System.Drawing.Size(101, 21)
        Me.msk_ADDR_POST.TabIndex = 21
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
        Me.txt_ADDR_2.Location = New System.Drawing.Point(474, 294)
        Me.txt_ADDR_2.MaxLength = 30
        Me.txt_ADDR_2.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_2.Name = "txt_ADDR_2"
        Me.txt_ADDR_2.Size = New System.Drawing.Size(243, 20)
        Me.txt_ADDR_2.TabIndex = 23
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
        Me.txt_ADDR_1.Location = New System.Drawing.Point(391, 294)
        Me.txt_ADDR_1.MaxLength = 8
        Me.txt_ADDR_1.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_1.Name = "txt_ADDR_1"
        Me.txt_ADDR_1.Size = New System.Drawing.Size(77, 20)
        Me.txt_ADDR_1.TabIndex = 22
        Me.txt_ADDR_1.Text = "＠＠＠＠"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(84, 300)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 15)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "■住所"
        '
        'txt_NYUKINHOHO
        '
        Me.txt_NYUKINHOHO.DropDown.AllowDrop = False
        Me.txt_NYUKINHOHO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_NYUKINHOHO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_NYUKINHOHO.HighlightText = True
        Me.txt_NYUKINHOHO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_NYUKINHOHO.Location = New System.Drawing.Point(284, 555)
        Me.txt_NYUKINHOHO.MaxLength = 70
        Me.txt_NYUKINHOHO.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_NYUKINHOHO.Name = "txt_NYUKINHOHO"
        Me.txt_NYUKINHOHO.Size = New System.Drawing.Size(711, 20)
        Me.txt_NYUKINHOHO.TabIndex = 35
        Me.txt_NYUKINHOHO.Text = "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(84, 558)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 15)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "□入金方法"
        '
        'txt_DAIHYO_NAME
        '
        Me.txt_DAIHYO_NAME.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.txt_DAIHYO_NAME.DropDown.AllowDrop = False
        Me.txt_DAIHYO_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_DAIHYO_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_DAIHYO_NAME.Format = "Ｚ"
        Me.txt_DAIHYO_NAME.HighlightText = True
        Me.txt_DAIHYO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_DAIHYO_NAME.Location = New System.Drawing.Point(284, 241)
        Me.txt_DAIHYO_NAME.MaxLength = 50
        Me.txt_DAIHYO_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_DAIHYO_NAME.Name = "txt_DAIHYO_NAME"
        Me.txt_DAIHYO_NAME.Size = New System.Drawing.Size(399, 20)
        Me.txt_DAIHYO_NAME.TabIndex = 11
        Me.txt_DAIHYO_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(84, 195)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(127, 15)
        Me.Label24.TabIndex = 73
        Me.Label24.Text = "■事務委託先名称"
        '
        'txt_ITAKU_RYAKU
        '
        Me.txt_ITAKU_RYAKU.DropDown.AllowDrop = False
        Me.txt_ITAKU_RYAKU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ITAKU_RYAKU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ITAKU_RYAKU.Format = "Ｚ"
        Me.txt_ITAKU_RYAKU.HighlightText = True
        Me.txt_ITAKU_RYAKU.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ITAKU_RYAKU.InputCheck = True
        Me.txt_ITAKU_RYAKU.Location = New System.Drawing.Point(284, 216)
        Me.txt_ITAKU_RYAKU.MaxLength = 30
        Me.txt_ITAKU_RYAKU.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ITAKU_RYAKU.Name = "txt_ITAKU_RYAKU"
        Me.txt_ITAKU_RYAKU.Size = New System.Drawing.Size(252, 20)
        Me.txt_ITAKU_RYAKU.TabIndex = 4
        Me.txt_ITAKU_RYAKU.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'txt_ITAKU_NAME
        '
        Me.txt_ITAKU_NAME.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.txt_ITAKU_NAME.DropDown.AllowDrop = False
        Me.txt_ITAKU_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ITAKU_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ITAKU_NAME.Format = "Ｚ"
        Me.txt_ITAKU_NAME.HighlightText = True
        Me.txt_ITAKU_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ITAKU_NAME.InputCheck = True
        Me.txt_ITAKU_NAME.Location = New System.Drawing.Point(284, 190)
        Me.txt_ITAKU_NAME.MaxLength = 50
        Me.txt_ITAKU_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ITAKU_NAME.Name = "txt_ITAKU_NAME"
        Me.txt_ITAKU_NAME.Size = New System.Drawing.Size(399, 20)
        Me.txt_ITAKU_NAME.TabIndex = 3
        Me.txt_ITAKU_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
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
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label56.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label56.Location = New System.Drawing.Point(244, 193)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(37, 15)
        Me.Label56.TabIndex = 997
        Me.Label56.Text = "正式"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(84, 136)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 15)
        Me.Label13.TabIndex = 1000
        Me.Label13.Text = "■事務委託先"
        '
        'txt_ADDR_FAX
        '
        Me.txt_ADDR_FAX.DropDown.AllowDrop = False
        Me.txt_ADDR_FAX.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_FAX.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_FAX.Format = "9-"
        Me.txt_ADDR_FAX.HighlightText = True
        Me.txt_ADDR_FAX.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_ADDR_FAX.Location = New System.Drawing.Point(512, 375)
        Me.txt_ADDR_FAX.MaxLength = 14
        Me.txt_ADDR_FAX.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_FAX.Name = "txt_ADDR_FAX"
        Me.txt_ADDR_FAX.Size = New System.Drawing.Size(122, 20)
        Me.txt_ADDR_FAX.TabIndex = 27
        Me.txt_ADDR_FAX.Text = "9999-9999-9999"
        '
        'txt_ADDR_TEL
        '
        Me.txt_ADDR_TEL.DropDown.AllowDrop = False
        Me.txt_ADDR_TEL.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_TEL.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_TEL.Format = "9-"
        Me.txt_ADDR_TEL.HighlightText = True
        Me.txt_ADDR_TEL.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_ADDR_TEL.InputCheck = True
        Me.txt_ADDR_TEL.Location = New System.Drawing.Point(326, 375)
        Me.txt_ADDR_TEL.MaxLength = 14
        Me.txt_ADDR_TEL.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_TEL.Name = "txt_ADDR_TEL"
        Me.txt_ADDR_TEL.Size = New System.Drawing.Size(122, 20)
        Me.txt_ADDR_TEL.TabIndex = 26
        Me.txt_ADDR_TEL.Text = "9999-9999-9999"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(473, 378)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 15)
        Me.Label11.TabIndex = 1005
        Me.Label11.Text = "FAX"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(284, 378)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 15)
        Me.Label7.TabIndex = 1003
        Me.Label7.Text = "電話"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(244, 219)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 1007
        Me.Label3.Text = "略称"
        '
        'txt_TANTO_NAME
        '
        Me.txt_TANTO_NAME.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.txt_TANTO_NAME.DropDown.AllowDrop = False
        Me.txt_TANTO_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_TANTO_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_TANTO_NAME.Format = "Ｚ"
        Me.txt_TANTO_NAME.HighlightText = True
        Me.txt_TANTO_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_TANTO_NAME.Location = New System.Drawing.Point(284, 267)
        Me.txt_TANTO_NAME.MaxLength = 50
        Me.txt_TANTO_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_TANTO_NAME.Name = "txt_TANTO_NAME"
        Me.txt_TANTO_NAME.Size = New System.Drawing.Size(399, 20)
        Me.txt_TANTO_NAME.TabIndex = 12
        Me.txt_TANTO_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(84, 270)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 15)
        Me.Label4.TabIndex = 1009
        Me.Label4.Text = "□担当者氏名"
        '
        'txt_ADDR_4
        '
        Me.txt_ADDR_4.DropDown.AllowDrop = False
        Me.txt_ADDR_4.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_ADDR_4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_ADDR_4.Format = "Ｚ"
        Me.txt_ADDR_4.HighlightText = True
        Me.txt_ADDR_4.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_ADDR_4.Location = New System.Drawing.Point(284, 346)
        Me.txt_ADDR_4.MaxLength = 40
        Me.txt_ADDR_4.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_4.Name = "txt_ADDR_4"
        Me.txt_ADDR_4.Size = New System.Drawing.Size(325, 20)
        Me.txt_ADDR_4.TabIndex = 25
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
        Me.txt_ADDR_3.Location = New System.Drawing.Point(284, 320)
        Me.txt_ADDR_3.MaxLength = 30
        Me.txt_ADDR_3.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_ADDR_3.Name = "txt_ADDR_3"
        Me.txt_ADDR_3.Size = New System.Drawing.Size(243, 20)
        Me.txt_ADDR_3.TabIndex = 24
        Me.txt_ADDR_3.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(84, 406)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(113, 15)
        Me.Label12.TabIndex = 1013
        Me.Label12.Text = "□メールアドレス"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtn_BANK_INJI_KBN2)
        Me.GroupBox1.Controls.Add(Me.rbtn_BANK_INJI_KBN1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(284, 426)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(123, 38)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'rbtn_BANK_INJI_KBN2
        '
        Me.rbtn_BANK_INJI_KBN2.AutoSize = True
        Me.rbtn_BANK_INJI_KBN2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_BANK_INJI_KBN2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtn_BANK_INJI_KBN2.Location = New System.Drawing.Point(77, 12)
        Me.rbtn_BANK_INJI_KBN2.Name = "rbtn_BANK_INJI_KBN2"
        Me.rbtn_BANK_INJI_KBN2.Size = New System.Drawing.Size(46, 20)
        Me.rbtn_BANK_INJI_KBN2.TabIndex = 1
        Me.rbtn_BANK_INJI_KBN2.TabStop = True
        Me.rbtn_BANK_INJI_KBN2.Text = "無"
        Me.rbtn_BANK_INJI_KBN2.UseVisualStyleBackColor = True
        '
        'rbtn_BANK_INJI_KBN1
        '
        Me.rbtn_BANK_INJI_KBN1.AutoSize = True
        Me.rbtn_BANK_INJI_KBN1.Checked = True
        Me.rbtn_BANK_INJI_KBN1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_BANK_INJI_KBN1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbtn_BANK_INJI_KBN1.Location = New System.Drawing.Point(6, 12)
        Me.rbtn_BANK_INJI_KBN1.Name = "rbtn_BANK_INJI_KBN1"
        Me.rbtn_BANK_INJI_KBN1.Size = New System.Drawing.Size(46, 20)
        Me.rbtn_BANK_INJI_KBN1.TabIndex = 0
        Me.rbtn_BANK_INJI_KBN1.TabStop = True
        Me.rbtn_BANK_INJI_KBN1.Text = "有"
        Me.rbtn_BANK_INJI_KBN1.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(84, 440)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(172, 15)
        Me.Label19.TabIndex = 1015
        Me.Label19.Text = "■金融機関情報印字有無"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(84, 475)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 15)
        Me.Label5.TabIndex = 1017
        Me.Label5.Text = "□まとめ先"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(84, 503)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 15)
        Me.Label8.TabIndex = 1019
        Me.Label8.Text = "□申込書類"
        '
        'txt_MOSIKOMISYORUI
        '
        Me.txt_MOSIKOMISYORUI.DropDown.AllowDrop = False
        Me.txt_MOSIKOMISYORUI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_MOSIKOMISYORUI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_MOSIKOMISYORUI.HighlightText = True
        Me.txt_MOSIKOMISYORUI.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_MOSIKOMISYORUI.Location = New System.Drawing.Point(284, 500)
        Me.txt_MOSIKOMISYORUI.MaxLength = 70
        Me.txt_MOSIKOMISYORUI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_MOSIKOMISYORUI.Name = "txt_MOSIKOMISYORUI"
        Me.txt_MOSIKOMISYORUI.Size = New System.Drawing.Size(711, 20)
        Me.txt_MOSIKOMISYORUI.TabIndex = 33
        Me.txt_MOSIKOMISYORUI.Text = "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(84, 530)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 15)
        Me.Label9.TabIndex = 1021
        Me.Label9.Text = "□請求書・契約書"
        '
        'txt_SEIKYUSYO
        '
        Me.txt_SEIKYUSYO.DropDown.AllowDrop = False
        Me.txt_SEIKYUSYO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_SEIKYUSYO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_SEIKYUSYO.HighlightText = True
        Me.txt_SEIKYUSYO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_SEIKYUSYO.Location = New System.Drawing.Point(284, 527)
        Me.txt_SEIKYUSYO.MaxLength = 15
        Me.txt_SEIKYUSYO.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_SEIKYUSYO.Name = "txt_SEIKYUSYO"
        Me.txt_SEIKYUSYO.Size = New System.Drawing.Size(165, 20)
        Me.txt_SEIKYUSYO.TabIndex = 34
        Me.txt_SEIKYUSYO.Text = "@@@@@@@@@@@@@@@"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(84, 586)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 15)
        Me.Label10.TabIndex = 1023
        Me.Label10.Text = "□ラベル発行"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(84, 615)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 15)
        Me.Label15.TabIndex = 1025
        Me.Label15.Text = "□除外フラグ"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(84, 641)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 15)
        Me.Label16.TabIndex = 1027
        Me.Label16.Text = "□備考"
        '
        'txt_BIKO
        '
        Me.txt_BIKO.DropDown.AllowDrop = False
        Me.txt_BIKO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_BIKO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_BIKO.Format = "Ｚ"
        Me.txt_BIKO.HighlightText = True
        Me.txt_BIKO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_BIKO.Location = New System.Drawing.Point(284, 638)
        Me.txt_BIKO.MaxLength = 255
        Me.txt_BIKO.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_BIKO.Multiline = True
        Me.txt_BIKO.Name = "txt_BIKO"
        Me.txt_BIKO.Size = New System.Drawing.Size(711, 52)
        Me.txt_BIKO.TabIndex = 43
        Me.txt_BIKO.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠" & _
            "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_KI
        '
        Me.lbl_KI.AutoSize = True
        Me.lbl_KI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KI.Location = New System.Drawing.Point(54, 61)
        Me.lbl_KI.Name = "lbl_KI"
        Me.lbl_KI.Size = New System.Drawing.Size(56, 15)
        Me.lbl_KI.TabIndex = 1032
        Me.lbl_KI.Text = "JLabel1"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label32)
        Me.Panel1.Location = New System.Drawing.Point(53, 92)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(994, 25)
        Me.Panel1.TabIndex = 1033
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(16, 2)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(229, 19)
        Me.Label32.TabIndex = 988
        Me.Label32.Text = "事務委託先基本登録項目"
        '
        'frmGJ8061
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbl_KI)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txt_BIKO)
        Me.Controls.Add(Me.txt_JYOGAI_FLG)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txt_LABELHAKKO)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_SEIKYUSYO)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_MOSIKOMISYORUI)
        Me.Controls.Add(Me.txt_MATOMESAKI)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txt_ADDR_E_MAIL)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txt_ADDR_4)
        Me.Controls.Add(Me.txt_ADDR_3)
        Me.Controls.Add(Me.txt_TANTO_NAME)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_ITAKU_CD)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_ITAKU_RYAKU)
        Me.Controls.Add(Me.txt_ITAKU_NAME)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txt_DAIHYO_NAME)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.txt_ADDR_2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txt_ADDR_1)
        Me.Controls.Add(Me.msk_ADDR_POST)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_NYUKINHOHO)
        Me.Controls.Add(Me.txt_ADDR_FAX)
        Me.Controls.Add(Me.txt_ADDR_TEL)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cob_KEN_CD)
        Me.Controls.Add(Me.cob_KEN_NM)
        Me.Name = "frmGJ8061"
        Me.Text = "(GJ8061)事務委託先マスタメンテナンス"
        Me.Controls.SetChildIndex(Me.cob_KEN_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_KEN_CD, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label56, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_TEL, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_FAX, 0)
        Me.Controls.SetChildIndex(Me.txt_NYUKINHOHO, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label29, 0)
        Me.Controls.SetChildIndex(Me.msk_ADDR_POST, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_1, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_2, 0)
        Me.Controls.SetChildIndex(Me.Label34, 0)
        Me.Controls.SetChildIndex(Me.txt_DAIHYO_NAME, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.txt_ITAKU_NAME, 0)
        Me.Controls.SetChildIndex(Me.txt_ITAKU_RYAKU, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txt_ITAKU_CD, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txt_TANTO_NAME, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_3, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_4, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.txt_ADDR_E_MAIL, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txt_MATOMESAKI, 0)
        Me.Controls.SetChildIndex(Me.txt_MOSIKOMISYORUI, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txt_SEIKYUSYO, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.txt_LABELHAKKO, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.txt_JYOGAI_FLG, 0)
        Me.Controls.SetChildIndex(Me.txt_BIKO, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.lbl_KI, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.pnlButton.ResumeLayout(False)
        Me.pnlButton.PerformLayout()
        CType(Me.cob_KEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Now, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ITAKU_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_E_MAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_MATOMESAKI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_LABELHAKKO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_JYOGAI_FLG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.msk_ADDR_POST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_NYUKINHOHO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_DAIHYO_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ITAKU_RYAKU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ITAKU_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_FAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_TEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TANTO_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ADDR_3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txt_MOSIKOMISYORUI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SEIKYUSYO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_BIKO, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label29 As JBD.Gjs.Win.Label
    Friend WithEvents Label34 As JBD.Gjs.Win.Label
    Friend WithEvents msk_ADDR_POST As JBD.Gjs.Win.GcMask
    Friend WithEvents txt_ADDR_2 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_ADDR_1 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents txt_NYUKINHOHO As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents txt_DAIHYO_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents DropDownButton14 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton15 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton16 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton17 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton18 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton19 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents txt_ITAKU_RYAKU As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_ITAKU_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label56 As JBD.Gjs.Win.Label
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents txt_ADDR_FAX As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_ADDR_TEL As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents txt_ITAKU_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_TANTO_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents txt_ADDR_4 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_ADDR_3 As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_ADDR_E_MAIL As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents GroupBox1 As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtn_BANK_INJI_KBN2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_BANK_INJI_KBN1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents txt_MATOMESAKI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents txt_MOSIKOMISYORUI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents txt_SEIKYUSYO As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_LABELHAKKO As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents txt_JYOGAI_FLG As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents txt_BIKO As JBD.Gjs.Win.GcTextBox
    Friend WithEvents lbl_KI As JBD.Gjs.Win.JLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label32 As JBD.Gjs.Win.Label

End Class
