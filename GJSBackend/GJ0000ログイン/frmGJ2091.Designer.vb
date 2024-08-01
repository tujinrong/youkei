Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ2091
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
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.dateNYUKIN_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton13 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton14 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton15 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton16 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton17 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton18 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton19 = New GrapeCity.Win.Editors.DropDownButton()
        Me.txtBIKO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label65 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label68 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblKI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_HasuSeigen = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdTorikesi = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdBunkatu = New JBD.Gjs.Win.JButton(Me.components)
        Me.lblKEIYAKUSYA_CD = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblKEN_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblSYORI_JOKYO_KBN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblKEIYAKUSYA_NAME = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblKEIYAKUSYA_KANA = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblADDR_POST = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblADDR = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblADDR_TEL1 = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblADDR_TEL2 = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblADDR_FAX = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblFURI_BANK_NAME = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lblFURI_KOZA_NO = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblFURI_BANK_SITEN_NAME = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblFURI_KOZA_SYUBETU_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label26 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblFURI_KOZA_MEIGI_KANA = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label27 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblJIMUITAKU_CD = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblJIMUITAKU_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblSEIKYU_DATE = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblSEIKYU_KAISU = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label21 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblSEIKYU_HENKAN_KBN_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label22 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label23 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblSAGAKU_SEIKYU_KIN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label25 = New JBD.Gjs.Win.Label(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label32 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label33 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblSEIKYU_KIN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label30 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label31 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblTESURYO = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label28 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label29 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblTUMITATE_KIN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKU_HENKO_KBN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.dateNYUKIN_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBIKO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdBunkatu)
        Me.pnlButton.Controls.Add(Me.cmdTorikesi)
        Me.pnlButton.Controls.Add(Me.cmdSave)
        Me.pnlButton.Size = New System.Drawing.Size(1070, 55)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSave, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdTorikesi, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdBunkatu, 0)
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
        Me.cmdEnd.Location = New System.Drawing.Point(967, 6)
        Me.cmdEnd.TabIndex = 99
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(90, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "契約者番号"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(354, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "都道府県"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(247, 262)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 15)
        Me.Label19.TabIndex = 112
        Me.Label19.Text = "金融機関"
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(12, 6)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 44)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "入金登録"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'dateNYUKIN_DATE
        '
        Me.dateNYUKIN_DATE.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.dateNYUKIN_DATE.DefaultActiveField = DateEraYearField1
        Me.dateNYUKIN_DATE.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.dateNYUKIN_DATE.DisabledForeColor = System.Drawing.SystemColors.WindowText
        DateEraYearDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField2.Text = "/"
        DateMonthDisplayField1.ShowLeadingZero = True
        DateLiteralDisplayField3.Text = "/"
        DateDayDisplayField1.ShowLeadingZero = True
        Me.dateNYUKIN_DATE.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.DateDisplayField() {DateEraDisplayField1, DateLiteralDisplayField1, DateEraYearDisplayField1, DateLiteralDisplayField2, DateMonthDisplayField1, DateLiteralDisplayField3, DateDayDisplayField1})
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.dateNYUKIN_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.dateNYUKIN_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateNYUKIN_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateNYUKIN_DATE.InputCheck = True
        Me.dateNYUKIN_DATE.Location = New System.Drawing.Point(250, 526)
        Me.dateNYUKIN_DATE.Name = "dateNYUKIN_DATE"
        Me.dateNYUKIN_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton13})
        Me.dateNYUKIN_DATE.Size = New System.Drawing.Size(125, 21)
        Me.dateNYUKIN_DATE.Spin.AllowSpin = False
        Me.dateNYUKIN_DATE.TabIndex = 1
        Me.dateNYUKIN_DATE.Value = New Date(2010, 8, 28, 11, 12, 38, 0)
        '
        'DropDownButton13
        '
        Me.DropDownButton13.Name = "DropDownButton13"
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
        'txtBIKO
        '
        Me.txtBIKO.DropDown.AllowDrop = False
        Me.txtBIKO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txtBIKO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txtBIKO.Format = "Ｚ"
        Me.txtBIKO.HighlightText = True
        Me.txtBIKO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtBIKO.Location = New System.Drawing.Point(250, 636)
        Me.txtBIKO.MaxLength = 80
        Me.txtBIKO.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txtBIKO.Name = "txtBIKO"
        Me.txtBIKO.Size = New System.Drawing.Size(651, 20)
        Me.txtBIKO.TabIndex = 2
        Me.txtBIKO.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(77, 639)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 15)
        Me.Label15.TabIndex = 126
        Me.Label15.Text = "□備考"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label65.Location = New System.Drawing.Point(90, 133)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(67, 15)
        Me.Label65.TabIndex = 1003
        Me.Label65.Text = "契約者名"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.Color.Transparent
        Me.Label68.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label68.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label68.Location = New System.Drawing.Point(90, 179)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(37, 15)
        Me.Label68.TabIndex = 1008
        Me.Label68.Text = "住所"
        '
        'lblKI
        '
        Me.lblKI.AutoSize = True
        Me.lblKI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblKI.Location = New System.Drawing.Point(249, 471)
        Me.lblKI.Name = "lblKI"
        Me.lblKI.Size = New System.Drawing.Size(23, 15)
        Me.lblKI.TabIndex = 1032
        Me.lblKI.Text = "99"
        Me.lblKI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(90, 228)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 15)
        Me.Label6.TabIndex = 1039
        Me.Label6.Text = "連絡先"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(90, 345)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 15)
        Me.Label7.TabIndex = 1040
        Me.Label7.Text = "事務委託先"
        '
        'lbl_HasuSeigen
        '
        Me.lbl_HasuSeigen.AutoSize = True
        Me.lbl_HasuSeigen.BackColor = System.Drawing.Color.Transparent
        Me.lbl_HasuSeigen.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_HasuSeigen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_HasuSeigen.Location = New System.Drawing.Point(541, 102)
        Me.lbl_HasuSeigen.Name = "lbl_HasuSeigen"
        Me.lbl_HasuSeigen.Size = New System.Drawing.Size(67, 15)
        Me.lbl_HasuSeigen.TabIndex = 998
        Me.lbl_HasuSeigen.Text = "処理状況"
        '
        'cmdTorikesi
        '
        Me.cmdTorikesi.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdTorikesi.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTorikesi.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdTorikesi.Location = New System.Drawing.Point(119, 6)
        Me.cmdTorikesi.Name = "cmdTorikesi"
        Me.cmdTorikesi.Size = New System.Drawing.Size(92, 44)
        Me.cmdTorikesi.TabIndex = 2
        Me.cmdTorikesi.Text = "入金取消"
        Me.cmdTorikesi.UseVisualStyleBackColor = True
        '
        'cmdBunkatu
        '
        Me.cmdBunkatu.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdBunkatu.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdBunkatu.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdBunkatu.Location = New System.Drawing.Point(226, 6)
        Me.cmdBunkatu.Name = "cmdBunkatu"
        Me.cmdBunkatu.Size = New System.Drawing.Size(92, 44)
        Me.cmdBunkatu.TabIndex = 3
        Me.cmdBunkatu.Text = "分割入金"
        Me.cmdBunkatu.UseVisualStyleBackColor = True
        '
        'lblKEIYAKUSYA_CD
        '
        Me.lblKEIYAKUSYA_CD.AutoSize = True
        Me.lblKEIYAKUSYA_CD.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblKEIYAKUSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblKEIYAKUSYA_CD.Location = New System.Drawing.Point(247, 102)
        Me.lblKEIYAKUSYA_CD.Name = "lblKEIYAKUSYA_CD"
        Me.lblKEIYAKUSYA_CD.Size = New System.Drawing.Size(47, 15)
        Me.lblKEIYAKUSYA_CD.TabIndex = 1055
        Me.lblKEIYAKUSYA_CD.Text = "99999"
        '
        'lblKEN_NM
        '
        Me.lblKEN_NM.AutoSize = True
        Me.lblKEN_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblKEN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblKEN_NM.Location = New System.Drawing.Point(434, 102)
        Me.lblKEN_NM.Name = "lblKEN_NM"
        Me.lblKEN_NM.Size = New System.Drawing.Size(47, 15)
        Me.lblKEN_NM.TabIndex = 1056
        Me.lblKEN_NM.Text = "NNNN"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(75, 444)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 19)
        Me.Label5.TabIndex = 1057
        Me.Label5.Text = "請求入金内容"
        '
        'lblSYORI_JOKYO_KBN
        '
        Me.lblSYORI_JOKYO_KBN.AutoSize = True
        Me.lblSYORI_JOKYO_KBN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblSYORI_JOKYO_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblSYORI_JOKYO_KBN.Location = New System.Drawing.Point(629, 102)
        Me.lblSYORI_JOKYO_KBN.Name = "lblSYORI_JOKYO_KBN"
        Me.lblSYORI_JOKYO_KBN.Size = New System.Drawing.Size(67, 15)
        Me.lblSYORI_JOKYO_KBN.TabIndex = 1058
        Me.lblSYORI_JOKYO_KBN.Text = "NNNNNN"
        '
        'lblKEIYAKUSYA_NAME
        '
        Me.lblKEIYAKUSYA_NAME.AutoSize = True
        Me.lblKEIYAKUSYA_NAME.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblKEIYAKUSYA_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblKEIYAKUSYA_NAME.Location = New System.Drawing.Point(247, 133)
        Me.lblKEIYAKUSYA_NAME.Name = "lblKEIYAKUSYA_NAME"
        Me.lblKEIYAKUSYA_NAME.Size = New System.Drawing.Size(87, 15)
        Me.lblKEIYAKUSYA_NAME.TabIndex = 1059
        Me.lblKEIYAKUSYA_NAME.Text = "NNNNNNNN"
        '
        'lblKEIYAKUSYA_KANA
        '
        Me.lblKEIYAKUSYA_KANA.AutoSize = True
        Me.lblKEIYAKUSYA_KANA.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblKEIYAKUSYA_KANA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblKEIYAKUSYA_KANA.Location = New System.Drawing.Point(247, 154)
        Me.lblKEIYAKUSYA_KANA.Name = "lblKEIYAKUSYA_KANA"
        Me.lblKEIYAKUSYA_KANA.Size = New System.Drawing.Size(87, 15)
        Me.lblKEIYAKUSYA_KANA.TabIndex = 1060
        Me.lblKEIYAKUSYA_KANA.Text = "NNNNNNNN"
        '
        'lblADDR_POST
        '
        Me.lblADDR_POST.AutoSize = True
        Me.lblADDR_POST.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblADDR_POST.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblADDR_POST.Location = New System.Drawing.Point(247, 179)
        Me.lblADDR_POST.Name = "lblADDR_POST"
        Me.lblADDR_POST.Size = New System.Drawing.Size(86, 15)
        Me.lblADDR_POST.TabIndex = 1061
        Me.lblADDR_POST.Text = "〒999-9999"
        '
        'lblADDR
        '
        Me.lblADDR.AutoSize = True
        Me.lblADDR.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblADDR.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblADDR.Location = New System.Drawing.Point(247, 200)
        Me.lblADDR.Name = "lblADDR"
        Me.lblADDR.Size = New System.Drawing.Size(87, 15)
        Me.lblADDR.TabIndex = 1062
        Me.lblADDR.Text = "NNNNNNNN"
        '
        'lblADDR_TEL1
        '
        Me.lblADDR_TEL1.AutoSize = True
        Me.lblADDR_TEL1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblADDR_TEL1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblADDR_TEL1.Location = New System.Drawing.Point(300, 228)
        Me.lblADDR_TEL1.Name = "lblADDR_TEL1"
        Me.lblADDR_TEL1.Size = New System.Drawing.Size(111, 15)
        Me.lblADDR_TEL1.TabIndex = 1063
        Me.lblADDR_TEL1.Text = "999-9999-9999"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(247, 228)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 15)
        Me.Label4.TabIndex = 1064
        Me.Label4.Text = "電話１"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(431, 228)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 15)
        Me.Label10.TabIndex = 1066
        Me.Label10.Text = "電話２"
        '
        'lblADDR_TEL2
        '
        Me.lblADDR_TEL2.AutoSize = True
        Me.lblADDR_TEL2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblADDR_TEL2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblADDR_TEL2.Location = New System.Drawing.Point(484, 228)
        Me.lblADDR_TEL2.Name = "lblADDR_TEL2"
        Me.lblADDR_TEL2.Size = New System.Drawing.Size(111, 15)
        Me.lblADDR_TEL2.TabIndex = 1065
        Me.lblADDR_TEL2.Text = "999-9999-9999"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(617, 228)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 15)
        Me.Label12.TabIndex = 1068
        Me.Label12.Text = "ＦＡＸ"
        '
        'lblADDR_FAX
        '
        Me.lblADDR_FAX.AutoSize = True
        Me.lblADDR_FAX.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblADDR_FAX.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblADDR_FAX.Location = New System.Drawing.Point(670, 228)
        Me.lblADDR_FAX.Name = "lblADDR_FAX"
        Me.lblADDR_FAX.Size = New System.Drawing.Size(111, 15)
        Me.lblADDR_FAX.TabIndex = 1067
        Me.lblADDR_FAX.Text = "999-9999-9999"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(90, 262)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(135, 15)
        Me.Label14.TabIndex = 1069
        Me.Label14.Text = "振込・返還口座情報"
        '
        'lblFURI_BANK_NAME
        '
        Me.lblFURI_BANK_NAME.AutoSize = True
        Me.lblFURI_BANK_NAME.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblFURI_BANK_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblFURI_BANK_NAME.Location = New System.Drawing.Point(320, 262)
        Me.lblFURI_BANK_NAME.Name = "lblFURI_BANK_NAME"
        Me.lblFURI_BANK_NAME.Size = New System.Drawing.Size(287, 15)
        Me.lblFURI_BANK_NAME.TabIndex = 1070
        Me.lblFURI_BANK_NAME.Text = "NNNNNNNNNNNNNNNNNNNNNNNNNNNN"
        '
        'lblFURI_KOZA_NO
        '
        Me.lblFURI_KOZA_NO.AutoSize = True
        Me.lblFURI_KOZA_NO.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblFURI_KOZA_NO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblFURI_KOZA_NO.Location = New System.Drawing.Point(504, 288)
        Me.lblFURI_KOZA_NO.Name = "lblFURI_KOZA_NO"
        Me.lblFURI_KOZA_NO.Size = New System.Drawing.Size(71, 15)
        Me.lblFURI_KOZA_NO.TabIndex = 1072
        Me.lblFURI_KOZA_NO.Text = "99999999"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(431, 288)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 15)
        Me.Label18.TabIndex = 1071
        Me.Label18.Text = "口座番号"
        '
        'lblFURI_BANK_SITEN_NAME
        '
        Me.lblFURI_BANK_SITEN_NAME.AutoSize = True
        Me.lblFURI_BANK_SITEN_NAME.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblFURI_BANK_SITEN_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblFURI_BANK_SITEN_NAME.Location = New System.Drawing.Point(670, 262)
        Me.lblFURI_BANK_SITEN_NAME.Name = "lblFURI_BANK_SITEN_NAME"
        Me.lblFURI_BANK_SITEN_NAME.Size = New System.Drawing.Size(287, 15)
        Me.lblFURI_BANK_SITEN_NAME.TabIndex = 1074
        Me.lblFURI_BANK_SITEN_NAME.Text = "NNNNNNNNNNNNNNNNNNNNNNNNNNNN"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(617, 262)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(37, 15)
        Me.Label24.TabIndex = 1073
        Me.Label24.Text = "支店"
        '
        'lblFURI_KOZA_SYUBETU_NM
        '
        Me.lblFURI_KOZA_SYUBETU_NM.AutoSize = True
        Me.lblFURI_KOZA_SYUBETU_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblFURI_KOZA_SYUBETU_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblFURI_KOZA_SYUBETU_NM.Location = New System.Drawing.Point(322, 288)
        Me.lblFURI_KOZA_SYUBETU_NM.Name = "lblFURI_KOZA_SYUBETU_NM"
        Me.lblFURI_KOZA_SYUBETU_NM.Size = New System.Drawing.Size(71, 15)
        Me.lblFURI_KOZA_SYUBETU_NM.TabIndex = 1076
        Me.lblFURI_KOZA_SYUBETU_NM.Text = "99999999"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(249, 288)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(67, 15)
        Me.Label26.TabIndex = 1075
        Me.Label26.Text = "口座種別"
        '
        'lblFURI_KOZA_MEIGI_KANA
        '
        Me.lblFURI_KOZA_MEIGI_KANA.AutoSize = True
        Me.lblFURI_KOZA_MEIGI_KANA.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblFURI_KOZA_MEIGI_KANA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblFURI_KOZA_MEIGI_KANA.Location = New System.Drawing.Point(373, 315)
        Me.lblFURI_KOZA_MEIGI_KANA.Name = "lblFURI_KOZA_MEIGI_KANA"
        Me.lblFURI_KOZA_MEIGI_KANA.Size = New System.Drawing.Size(487, 15)
        Me.lblFURI_KOZA_MEIGI_KANA.TabIndex = 1078
        Me.lblFURI_KOZA_MEIGI_KANA.Text = "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(249, 315)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(118, 15)
        Me.Label27.TabIndex = 1077
        Me.Label27.Text = "口座名義人(カナ)"
        '
        'lblJIMUITAKU_CD
        '
        Me.lblJIMUITAKU_CD.AutoSize = True
        Me.lblJIMUITAKU_CD.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblJIMUITAKU_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblJIMUITAKU_CD.Location = New System.Drawing.Point(247, 345)
        Me.lblJIMUITAKU_CD.Name = "lblJIMUITAKU_CD"
        Me.lblJIMUITAKU_CD.Size = New System.Drawing.Size(71, 15)
        Me.lblJIMUITAKU_CD.TabIndex = 1079
        Me.lblJIMUITAKU_CD.Text = "99999999"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(90, 370)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 15)
        Me.Label8.TabIndex = 1080
        Me.Label8.Text = "事務委託先名"
        '
        'lblJIMUITAKU_NM
        '
        Me.lblJIMUITAKU_NM.AutoSize = True
        Me.lblJIMUITAKU_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblJIMUITAKU_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblJIMUITAKU_NM.Location = New System.Drawing.Point(247, 369)
        Me.lblJIMUITAKU_NM.Name = "lblJIMUITAKU_NM"
        Me.lblJIMUITAKU_NM.Size = New System.Drawing.Size(487, 15)
        Me.lblJIMUITAKU_NM.TabIndex = 1081
        Me.lblJIMUITAKU_NM.Text = "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(92, 471)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 15)
        Me.Label11.TabIndex = 1082
        Me.Label11.Text = "対象期"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(92, 498)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 15)
        Me.Label13.TabIndex = 1083
        Me.Label13.Text = "請求・返還日"
        '
        'lblSEIKYU_DATE
        '
        Me.lblSEIKYU_DATE.AutoSize = True
        Me.lblSEIKYU_DATE.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblSEIKYU_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblSEIKYU_DATE.Location = New System.Drawing.Point(249, 498)
        Me.lblSEIKYU_DATE.Name = "lblSEIKYU_DATE"
        Me.lblSEIKYU_DATE.Size = New System.Drawing.Size(101, 15)
        Me.lblSEIKYU_DATE.TabIndex = 1084
        Me.lblSEIKYU_DATE.Text = "平成99/99/99"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(375, 498)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(105, 15)
        Me.Label16.TabIndex = 1085
        Me.Label16.Text = "請求・返還回数"
        '
        'lblSEIKYU_KAISU
        '
        Me.lblSEIKYU_KAISU.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblSEIKYU_KAISU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblSEIKYU_KAISU.Location = New System.Drawing.Point(486, 498)
        Me.lblSEIKYU_KAISU.Name = "lblSEIKYU_KAISU"
        Me.lblSEIKYU_KAISU.Size = New System.Drawing.Size(31, 15)
        Me.lblSEIKYU_KAISU.TabIndex = 1086
        Me.lblSEIKYU_KAISU.Text = "999"
        Me.lblSEIKYU_KAISU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(523, 498)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(22, 15)
        Me.Label17.TabIndex = 1087
        Me.Label17.Text = "回"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(582, 498)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(105, 15)
        Me.Label21.TabIndex = 1088
        Me.Label21.Text = "徴収・返還区分"
        '
        'lblSEIKYU_HENKAN_KBN_NM
        '
        Me.lblSEIKYU_HENKAN_KBN_NM.AutoSize = True
        Me.lblSEIKYU_HENKAN_KBN_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblSEIKYU_HENKAN_KBN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblSEIKYU_HENKAN_KBN_NM.Location = New System.Drawing.Point(693, 498)
        Me.lblSEIKYU_HENKAN_KBN_NM.Name = "lblSEIKYU_HENKAN_KBN_NM"
        Me.lblSEIKYU_HENKAN_KBN_NM.Size = New System.Drawing.Size(87, 15)
        Me.lblSEIKYU_HENKAN_KBN_NM.TabIndex = 1089
        Me.lblSEIKYU_HENKAN_KBN_NM.Text = "NNNNNNNN"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(77, 529)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(105, 15)
        Me.Label22.TabIndex = 1090
        Me.Label22.Text = "■入金・振込日"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(92, 561)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(105, 15)
        Me.Label23.TabIndex = 1091
        Me.Label23.Text = "請求・返還金額"
        '
        'lblSAGAKU_SEIKYU_KIN
        '
        Me.lblSAGAKU_SEIKYU_KIN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblSAGAKU_SEIKYU_KIN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblSAGAKU_SEIKYU_KIN.Location = New System.Drawing.Point(249, 561)
        Me.lblSAGAKU_SEIKYU_KIN.Name = "lblSAGAKU_SEIKYU_KIN"
        Me.lblSAGAKU_SEIKYU_KIN.Size = New System.Drawing.Size(85, 15)
        Me.lblSAGAKU_SEIKYU_KIN.TabIndex = 1092
        Me.lblSAGAKU_SEIKYU_KIN.Text = "999,999,999"
        Me.lblSAGAKU_SEIKYU_KIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(338, 561)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(22, 15)
        Me.Label25.TabIndex = 1093
        Me.Label25.Text = "円"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label32)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.lblSEIKYU_KIN)
        Me.Panel1.Controls.Add(Me.Label30)
        Me.Panel1.Controls.Add(Me.Label31)
        Me.Panel1.Controls.Add(Me.lblTESURYO)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Controls.Add(Me.lblTUMITATE_KIN)
        Me.Panel1.Location = New System.Drawing.Point(385, 549)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(466, 76)
        Me.Panel1.TabIndex = 1094
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(426, 44)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(22, 15)
        Me.Label32.TabIndex = 1103
        Me.Label32.Text = "円"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(230, 44)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(97, 15)
        Me.Label33.TabIndex = 1101
        Me.Label33.Text = "積立金等総計"
        '
        'lblSEIKYU_KIN
        '
        Me.lblSEIKYU_KIN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblSEIKYU_KIN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblSEIKYU_KIN.Location = New System.Drawing.Point(335, 44)
        Me.lblSEIKYU_KIN.Name = "lblSEIKYU_KIN"
        Me.lblSEIKYU_KIN.Size = New System.Drawing.Size(85, 15)
        Me.lblSEIKYU_KIN.TabIndex = 1102
        Me.lblSEIKYU_KIN.Text = "999,999,999"
        Me.lblSEIKYU_KIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(426, 11)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(22, 15)
        Me.Label30.TabIndex = 1100
        Me.Label30.Text = "円"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(228, 11)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(52, 15)
        Me.Label31.TabIndex = 1098
        Me.Label31.Text = "手数料"
        '
        'lblTESURYO
        '
        Me.lblTESURYO.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblTESURYO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblTESURYO.Location = New System.Drawing.Point(335, 11)
        Me.lblTESURYO.Name = "lblTESURYO"
        Me.lblTESURYO.Size = New System.Drawing.Size(85, 15)
        Me.lblTESURYO.TabIndex = 1099
        Me.lblTESURYO.Text = "999,999,999"
        Me.lblTESURYO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(173, 11)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(22, 15)
        Me.Label28.TabIndex = 1097
        Me.Label28.Text = "円"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(9, 11)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(67, 15)
        Me.Label29.TabIndex = 1095
        Me.Label29.Text = "積立金額"
        '
        'lblTUMITATE_KIN
        '
        Me.lblTUMITATE_KIN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblTUMITATE_KIN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lblTUMITATE_KIN.Location = New System.Drawing.Point(82, 11)
        Me.lblTUMITATE_KIN.Name = "lblTUMITATE_KIN"
        Me.lblTUMITATE_KIN.Size = New System.Drawing.Size(85, 15)
        Me.lblTUMITATE_KIN.TabIndex = 1096
        Me.lblTUMITATE_KIN.Text = "999,999,999"
        Me.lblTUMITATE_KIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_KEIYAKU_HENKO_KBN
        '
        Me.lbl_KEIYAKU_HENKO_KBN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_HENKO_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_HENKO_KBN.Location = New System.Drawing.Point(721, 102)
        Me.lbl_KEIYAKU_HENKO_KBN.Name = "lbl_KEIYAKU_HENKO_KBN"
        Me.lbl_KEIYAKU_HENKO_KBN.Size = New System.Drawing.Size(31, 15)
        Me.lbl_KEIYAKU_HENKO_KBN.TabIndex = 1095
        Me.lbl_KEIYAKU_HENKO_KBN.Text = "9"
        Me.lbl_KEIYAKU_HENKO_KBN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_KEIYAKU_HENKO_KBN.Visible = False
        '
        'frmGJ2091
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.lbl_KEIYAKU_HENKO_KBN)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.lblSAGAKU_SEIKYU_KIN)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.lblSEIKYU_HENKAN_KBN_NM)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lblSEIKYU_KAISU)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.lblSEIKYU_DATE)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblJIMUITAKU_NM)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblJIMUITAKU_CD)
        Me.Controls.Add(Me.lblFURI_KOZA_MEIGI_KANA)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.lblFURI_KOZA_SYUBETU_NM)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.lblFURI_BANK_SITEN_NAME)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.lblFURI_KOZA_NO)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblFURI_BANK_NAME)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblADDR_FAX)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblADDR_TEL2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblADDR_TEL1)
        Me.Controls.Add(Me.lblADDR)
        Me.Controls.Add(Me.lblADDR_POST)
        Me.Controls.Add(Me.lblKEIYAKUSYA_KANA)
        Me.Controls.Add(Me.lblKEIYAKUSYA_NAME)
        Me.Controls.Add(Me.lblSYORI_JOKYO_KBN)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblKEN_NM)
        Me.Controls.Add(Me.lblKEIYAKUSYA_CD)
        Me.Controls.Add(Me.txtBIKO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblKI)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.lbl_HasuSeigen)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.dateNYUKIN_DATE)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmGJ2091"
        Me.Text = "(GJ2091契約者積立金等入金・返還確認"
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.dateNYUKIN_DATE, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.lbl_HasuSeigen, 0)
        Me.Controls.SetChildIndex(Me.Label68, 0)
        Me.Controls.SetChildIndex(Me.Label65, 0)
        Me.Controls.SetChildIndex(Me.lblKI, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtBIKO, 0)
        Me.Controls.SetChildIndex(Me.lblKEIYAKUSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.lblKEN_NM, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblSYORI_JOKYO_KBN, 0)
        Me.Controls.SetChildIndex(Me.lblKEIYAKUSYA_NAME, 0)
        Me.Controls.SetChildIndex(Me.lblKEIYAKUSYA_KANA, 0)
        Me.Controls.SetChildIndex(Me.lblADDR_POST, 0)
        Me.Controls.SetChildIndex(Me.lblADDR, 0)
        Me.Controls.SetChildIndex(Me.lblADDR_TEL1, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.lblADDR_TEL2, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.lblADDR_FAX, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.lblFURI_BANK_NAME, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.lblFURI_KOZA_NO, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.lblFURI_BANK_SITEN_NAME, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.lblFURI_KOZA_SYUBETU_NM, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.lblFURI_KOZA_MEIGI_KANA, 0)
        Me.Controls.SetChildIndex(Me.lblJIMUITAKU_CD, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.lblJIMUITAKU_NM, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.lblSEIKYU_DATE, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.lblSEIKYU_KAISU, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.lblSEIKYU_HENKAN_KBN_NM, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.lblSAGAKU_SEIKYU_KIN, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_HENKO_KBN, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.dateNYUKIN_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBIKO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents cmdSave As JBD.Gjs.Win.JButton
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents GcDateValidator1 As GrapeCity.Win.Editors.GcDateValidator
    Friend WithEvents dateNYUKIN_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton13 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton14 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton15 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton16 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton17 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton18 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton19 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents txtBIKO As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents Label65 As JBD.Gjs.Win.Label
    Friend WithEvents Label68 As JBD.Gjs.Win.Label
    Friend WithEvents lblKI As JBD.Gjs.Win.JLabel
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_HasuSeigen As JBD.Gjs.Win.Label
    Friend WithEvents cmdBunkatu As JBD.Gjs.Win.JButton
    Friend WithEvents cmdTorikesi As JBD.Gjs.Win.JButton
    Friend WithEvents lblKEIYAKUSYA_CD As JBD.Gjs.Win.JLabel
    Friend WithEvents lblKEN_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents lblSYORI_JOKYO_KBN As JBD.Gjs.Win.JLabel
    Friend WithEvents lblKEIYAKUSYA_NAME As JBD.Gjs.Win.JLabel
    Friend WithEvents lblKEIYAKUSYA_KANA As JBD.Gjs.Win.JLabel
    Friend WithEvents lblADDR_POST As JBD.Gjs.Win.JLabel
    Friend WithEvents lblADDR As JBD.Gjs.Win.JLabel
    Friend WithEvents lblADDR_TEL1 As JBD.Gjs.Win.JLabel
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents lblADDR_TEL2 As JBD.Gjs.Win.JLabel
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents lblADDR_FAX As JBD.Gjs.Win.JLabel
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents lblFURI_BANK_NAME As JBD.Gjs.Win.JLabel
    Friend WithEvents lblFURI_KOZA_NO As JBD.Gjs.Win.JLabel
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents lblFURI_BANK_SITEN_NAME As JBD.Gjs.Win.JLabel
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents lblFURI_KOZA_SYUBETU_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents Label26 As JBD.Gjs.Win.Label
    Friend WithEvents lblFURI_KOZA_MEIGI_KANA As JBD.Gjs.Win.JLabel
    Friend WithEvents Label27 As JBD.Gjs.Win.Label
    Friend WithEvents lblJIMUITAKU_CD As JBD.Gjs.Win.JLabel
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents lblJIMUITAKU_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents lblSEIKYU_DATE As JBD.Gjs.Win.JLabel
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents lblSEIKYU_KAISU As JBD.Gjs.Win.JLabel
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents Label21 As JBD.Gjs.Win.Label
    Friend WithEvents lblSEIKYU_HENKAN_KBN_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents Label22 As JBD.Gjs.Win.Label
    Friend WithEvents Label23 As JBD.Gjs.Win.Label
    Friend WithEvents lblSAGAKU_SEIKYU_KIN As JBD.Gjs.Win.JLabel
    Friend WithEvents Label25 As JBD.Gjs.Win.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label32 As JBD.Gjs.Win.Label
    Friend WithEvents Label33 As JBD.Gjs.Win.Label
    Friend WithEvents lblSEIKYU_KIN As JBD.Gjs.Win.JLabel
    Friend WithEvents Label30 As JBD.Gjs.Win.Label
    Friend WithEvents Label31 As JBD.Gjs.Win.Label
    Friend WithEvents lblTESURYO As JBD.Gjs.Win.JLabel
    Friend WithEvents Label28 As JBD.Gjs.Win.Label
    Friend WithEvents Label29 As JBD.Gjs.Win.Label
    Friend WithEvents lblTUMITATE_KIN As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKU_HENKO_KBN As JBD.Gjs.Win.JLabel

End Class
