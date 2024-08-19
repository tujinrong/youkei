<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptGJ1030
    Inherits GrapeCity.ActiveReports.SectionReport

    'ActiveReport がコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
        End If
        MyBase.Dispose(disposing)
    End Sub

    'メモ: 以下のプロシージャは ActiveReport デザイナで必要です。
    'ActiveReport デザイナを使用して変更できます。
    'コード エディタを使って変更しないでください。
    Private WithEvents Detail As GrapeCity.ActiveReports.SectionReportModel.Detail
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptGJ1030))
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.KEIYAKUSYA_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKU_DATE_W = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKUSYA_CD = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.DTL_UNDER_LINE = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.DAIHYO_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ITAKU_RYAKU = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKU_KBN_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TEL1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TEL2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKU_JYOKYO_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.FAX = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKU_HENKO_KBN_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.HAIGYO_DATE_W = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ADDR_POST = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ADDR_2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ADDR_1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ADDR_3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ADDR_4 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEN_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.E_MAIL = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.BANK_INJI_KBN_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Shape2 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.lblTitle = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Lbl_Seikyu3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label28 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.sakuseibi = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label29 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label30 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox7 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label31 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionBox2 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionBox()
        Me.CrossSectionLine8 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine10 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.Label34 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label35 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label37 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label47 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label11 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label12 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TAISYOBI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label7 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label4 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label5 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label9 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label13 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label14 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label15 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label16 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label6 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label8 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label10 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label17 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label18 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label19 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TAISYO_KI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line6 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.Label55 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.FT_UNDER_LINE = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.FT_UPPER_LINE = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Label20 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label22 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label23 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        CType(Me.KEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKU_DATE_W, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DAIHYO_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ITAKU_RYAKU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKU_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEL1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEL2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKU_JYOKYO_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKU_HENKO_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HAIGYO_DATE_W, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADDR_POST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADDR_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADDR_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADDR_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADDR_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.E_MAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BANK_INJI_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lbl_Seikyu3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sakuseibi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TAISYOBI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TAISYO_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.CanGrow = False
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.KEIYAKUSYA_NAME, Me.KEIYAKU_DATE_W, Me.KEIYAKUSYA_CD, Me.DTL_UNDER_LINE, Me.DAIHYO_NAME, Me.ITAKU_RYAKU, Me.KEIYAKU_KBN_NM, Me.TEL1, Me.TEL2, Me.KEIYAKU_JYOKYO_NM, Me.FAX, Me.KEIYAKU_HENKO_KBN_NM, Me.HAIGYO_DATE_W, Me.ADDR_POST, Me.ADDR_2, Me.ADDR_1, Me.ADDR_3, Me.ADDR_4, Me.KEN_NM, Me.E_MAIL, Me.BANK_INJI_KBN_NM, Me.TextBox1, Me.TextBox2})
        Me.Detail.Height = 0.6417323!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'KEIYAKUSYA_NAME
        '
        Me.KEIYAKUSYA_NAME.CanGrow = False
        Me.KEIYAKUSYA_NAME.DataField = "KEIYAKUSYA_NAME"
        Me.KEIYAKUSYA_NAME.Height = 0.1732284!
        Me.KEIYAKUSYA_NAME.Left = 0.471!
        Me.KEIYAKUSYA_NAME.MultiLine = False
        Me.KEIYAKUSYA_NAME.Name = "KEIYAKUSYA_NAME"
        Me.KEIYAKUSYA_NAME.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.KEIYAKUSYA_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.KEIYAKUSYA_NAME.Top = 0.02!
        Me.KEIYAKUSYA_NAME.Width = 2.692!
        '
        'KEIYAKU_DATE_W
        '
        Me.KEIYAKU_DATE_W.DataField = "KEIYAKU_DATE_W"
        Me.KEIYAKU_DATE_W.Height = 0.1732284!
        Me.KEIYAKU_DATE_W.Left = 5.051!
        Me.KEIYAKU_DATE_W.Name = "KEIYAKU_DATE_W"
        Me.KEIYAKU_DATE_W.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: nowrap"
        Me.KEIYAKU_DATE_W.Text = "平成99年99月99日"
        Me.KEIYAKU_DATE_W.Top = 0.03!
        Me.KEIYAKU_DATE_W.Width = 1.027!
        '
        'KEIYAKUSYA_CD
        '
        Me.KEIYAKUSYA_CD.CanGrow = False
        Me.KEIYAKUSYA_CD.DataField = "KEIYAKUSYA_CD"
        Me.KEIYAKUSYA_CD.Height = 0.1732284!
        Me.KEIYAKUSYA_CD.Left = 0.01!
        Me.KEIYAKUSYA_CD.MultiLine = False
        Me.KEIYAKUSYA_CD.Name = "KEIYAKUSYA_CD"
        Me.KEIYAKUSYA_CD.OutputFormat = resources.GetString("KEIYAKUSYA_CD.OutputFormat")
        Me.KEIYAKUSYA_CD.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; white-space: inherit; ddo" & _
            "-char-set: 128"
        Me.KEIYAKUSYA_CD.Text = "99999"
        Me.KEIYAKUSYA_CD.Top = 0.02!
        Me.KEIYAKUSYA_CD.Width = 0.4207638!
        '
        'DTL_UNDER_LINE
        '
        Me.DTL_UNDER_LINE.Height = 0.0!
        Me.DTL_UNDER_LINE.Left = 0.0!
        Me.DTL_UNDER_LINE.LineWeight = 1.0!
        Me.DTL_UNDER_LINE.Name = "DTL_UNDER_LINE"
        Me.DTL_UNDER_LINE.Top = 0.6417323!
        Me.DTL_UNDER_LINE.Width = 10.90158!
        Me.DTL_UNDER_LINE.X1 = 0.0!
        Me.DTL_UNDER_LINE.X2 = 10.90158!
        Me.DTL_UNDER_LINE.Y1 = 0.6417323!
        Me.DTL_UNDER_LINE.Y2 = 0.6417323!
        '
        'DAIHYO_NAME
        '
        Me.DAIHYO_NAME.CanGrow = False
        Me.DAIHYO_NAME.DataField = "DAIHYO_NAME"
        Me.DAIHYO_NAME.Height = 0.1732284!
        Me.DAIHYO_NAME.Left = 0.471!
        Me.DAIHYO_NAME.MultiLine = False
        Me.DAIHYO_NAME.Name = "DAIHYO_NAME"
        Me.DAIHYO_NAME.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.DAIHYO_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.DAIHYO_NAME.Top = 0.195!
        Me.DAIHYO_NAME.Width = 2.692!
        '
        'ITAKU_RYAKU
        '
        Me.ITAKU_RYAKU.CanGrow = False
        Me.ITAKU_RYAKU.DataField = "ITAKU_RYAKU"
        Me.ITAKU_RYAKU.Height = 0.1732284!
        Me.ITAKU_RYAKU.Left = 0.5122048!
        Me.ITAKU_RYAKU.MultiLine = False
        Me.ITAKU_RYAKU.Name = "ITAKU_RYAKU"
        Me.ITAKU_RYAKU.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.ITAKU_RYAKU.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.ITAKU_RYAKU.Top = 0.3909449!
        Me.ITAKU_RYAKU.Width = 2.538055!
        '
        'KEIYAKU_KBN_NM
        '
        Me.KEIYAKU_KBN_NM.CanGrow = False
        Me.KEIYAKU_KBN_NM.DataField = "KEIYAKU_KBN_NM"
        Me.KEIYAKU_KBN_NM.Height = 0.1732284!
        Me.KEIYAKU_KBN_NM.Left = 3.238!
        Me.KEIYAKU_KBN_NM.MultiLine = False
        Me.KEIYAKU_KBN_NM.Name = "KEIYAKU_KBN_NM"
        Me.KEIYAKU_KBN_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.KEIYAKU_KBN_NM.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.KEIYAKU_KBN_NM.Top = 0.02!
        Me.KEIYAKU_KBN_NM.Width = 0.553!
        '
        'TEL1
        '
        Me.TEL1.CanGrow = False
        Me.TEL1.DataField = "TEL1"
        Me.TEL1.Height = 0.1732284!
        Me.TEL1.Left = 3.238!
        Me.TEL1.MultiLine = False
        Me.TEL1.Name = "TEL1"
        Me.TEL1.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.TEL1.Text = "@@@@@@@@@@@@@@"
        Me.TEL1.Top = 0.195!
        Me.TEL1.Width = 1.356!
        '
        'TEL2
        '
        Me.TEL2.CanGrow = False
        Me.TEL2.DataField = "TEL2"
        Me.TEL2.Height = 0.1732284!
        Me.TEL2.Left = 3.238!
        Me.TEL2.MultiLine = False
        Me.TEL2.Name = "TEL2"
        Me.TEL2.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.TEL2.Text = "@@@@@@@@@@@@@@"
        Me.TEL2.Top = 0.4!
        Me.TEL2.Width = 1.356!
        '
        'KEIYAKU_JYOKYO_NM
        '
        Me.KEIYAKU_JYOKYO_NM.CanGrow = False
        Me.KEIYAKU_JYOKYO_NM.DataField = "KEIYAKU_JYOKYO_NM"
        Me.KEIYAKU_JYOKYO_NM.Height = 0.1732284!
        Me.KEIYAKU_JYOKYO_NM.Left = 4.041!
        Me.KEIYAKU_JYOKYO_NM.MultiLine = False
        Me.KEIYAKU_JYOKYO_NM.Name = "KEIYAKU_JYOKYO_NM"
        Me.KEIYAKU_JYOKYO_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.KEIYAKU_JYOKYO_NM.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.KEIYAKU_JYOKYO_NM.Top = 0.022!
        Me.KEIYAKU_JYOKYO_NM.Width = 0.5529999!
        '
        'FAX
        '
        Me.FAX.CanGrow = False
        Me.FAX.DataField = "FAX"
        Me.FAX.Height = 0.1732284!
        Me.FAX.Left = 4.642!
        Me.FAX.MultiLine = False
        Me.FAX.Name = "FAX"
        Me.FAX.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.FAX.Text = "@@@@@@@@@@@@@@"
        Me.FAX.Top = 0.391!
        Me.FAX.Width = 1.366!
        '
        'KEIYAKU_HENKO_KBN_NM
        '
        Me.KEIYAKU_HENKO_KBN_NM.CanGrow = False
        Me.KEIYAKU_HENKO_KBN_NM.DataField = "KEIYAKU_HENKO_KBN_NM"
        Me.KEIYAKU_HENKO_KBN_NM.Height = 0.35!
        Me.KEIYAKU_HENKO_KBN_NM.Left = 4.594!
        Me.KEIYAKU_HENKO_KBN_NM.Name = "KEIYAKU_HENKO_KBN_NM"
        Me.KEIYAKU_HENKO_KBN_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.KEIYAKU_HENKO_KBN_NM.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.KEIYAKU_HENKO_KBN_NM.Top = 0.018!
        Me.KEIYAKU_HENKO_KBN_NM.Width = 0.421!
        '
        'HAIGYO_DATE_W
        '
        Me.HAIGYO_DATE_W.DataField = "HAIGYO_DATE_W"
        Me.HAIGYO_DATE_W.Height = 0.1732284!
        Me.HAIGYO_DATE_W.Left = 5.051!
        Me.HAIGYO_DATE_W.Name = "HAIGYO_DATE_W"
        Me.HAIGYO_DATE_W.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: nowrap"
        Me.HAIGYO_DATE_W.Text = "平成99年99月99日"
        Me.HAIGYO_DATE_W.Top = 0.215!
        Me.HAIGYO_DATE_W.Width = 1.027!
        '
        'ADDR_POST
        '
        Me.ADDR_POST.DataField = "ADDR_POST"
        Me.ADDR_POST.Height = 0.1732284!
        Me.ADDR_POST.Left = 6.124!
        Me.ADDR_POST.Name = "ADDR_POST"
        Me.ADDR_POST.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: nowrap"
        Me.ADDR_POST.Text = "〒@@@@@@@"
        Me.ADDR_POST.Top = 0.03!
        Me.ADDR_POST.Width = 0.8040004!
        '
        'ADDR_2
        '
        Me.ADDR_2.CanGrow = False
        Me.ADDR_2.DataField = "ADDR_2"
        Me.ADDR_2.Height = 0.1732284!
        Me.ADDR_2.Left = 7.535!
        Me.ADDR_2.MultiLine = False
        Me.ADDR_2.Name = "ADDR_2"
        Me.ADDR_2.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.ADDR_2.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.ADDR_2.Top = 0.032!
        Me.ADDR_2.Width = 3.160999!
        '
        'ADDR_1
        '
        Me.ADDR_1.CanGrow = False
        Me.ADDR_1.DataField = "ADDR_1"
        Me.ADDR_1.Height = 0.1732284!
        Me.ADDR_1.Left = 6.959!
        Me.ADDR_1.MultiLine = False
        Me.ADDR_1.Name = "ADDR_1"
        Me.ADDR_1.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.ADDR_1.Text = "＠＠＠＠"
        Me.ADDR_1.Top = 0.032!
        Me.ADDR_1.Width = 0.5560002!
        '
        'ADDR_3
        '
        Me.ADDR_3.CanGrow = False
        Me.ADDR_3.DataField = "ADDR_3"
        Me.ADDR_3.Height = 0.1732284!
        Me.ADDR_3.Left = 6.124!
        Me.ADDR_3.MultiLine = False
        Me.ADDR_3.Name = "ADDR_3"
        Me.ADDR_3.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.ADDR_3.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.ADDR_3.Top = 0.217!
        Me.ADDR_3.Width = 2.005001!
        '
        'ADDR_4
        '
        Me.ADDR_4.CanGrow = False
        Me.ADDR_4.DataField = "ADDR_4"
        Me.ADDR_4.Height = 0.1732284!
        Me.ADDR_4.Left = 8.149!
        Me.ADDR_4.MultiLine = False
        Me.ADDR_4.Name = "ADDR_4"
        Me.ADDR_4.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.ADDR_4.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.ADDR_4.Top = 0.217!
        Me.ADDR_4.Width = 2.691999!
        '
        'KEN_NM
        '
        Me.KEN_NM.CanGrow = False
        Me.KEN_NM.DataField = "KEN_NM"
        Me.KEN_NM.Height = 0.1732284!
        Me.KEN_NM.Left = 6.124!
        Me.KEN_NM.MultiLine = False
        Me.KEN_NM.Name = "KEN_NM"
        Me.KEN_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.KEN_NM.Text = "(＠＠＠＠)"
        Me.KEN_NM.Top = 0.391!
        Me.KEN_NM.Width = 0.6690001!
        '
        'E_MAIL
        '
        Me.E_MAIL.CanGrow = False
        Me.E_MAIL.DataField = "E_MAIL"
        Me.E_MAIL.Height = 0.1732284!
        Me.E_MAIL.Left = 6.793!
        Me.E_MAIL.MultiLine = False
        Me.E_MAIL.Name = "E_MAIL"
        Me.E_MAIL.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.E_MAIL.Text = "(@@@@@@@@@@@@@@)"
        Me.E_MAIL.Top = 0.396!
        Me.E_MAIL.Width = 3.820001!
        '
        'BANK_INJI_KBN_NM
        '
        Me.BANK_INJI_KBN_NM.CanGrow = False
        Me.BANK_INJI_KBN_NM.DataField = "BANK_INJI_KBN_NM"
        Me.BANK_INJI_KBN_NM.Height = 0.1732284!
        Me.BANK_INJI_KBN_NM.Left = 10.613!
        Me.BANK_INJI_KBN_NM.MultiLine = False
        Me.BANK_INJI_KBN_NM.Name = "BANK_INJI_KBN_NM"
        Me.BANK_INJI_KBN_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " & _
            "white-space: inherit"
        Me.BANK_INJI_KBN_NM.Text = "○"
        Me.BANK_INJI_KBN_NM.Top = 0.396!
        Me.BANK_INJI_KBN_NM.Width = 0.2079992!
        '
        'TextBox1
        '
        Me.TextBox1.CanGrow = False
        Me.TextBox1.Height = 0.1732284!
        Me.TextBox1.Left = 0.4523622!
        Me.TextBox1.MultiLine = False
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.TextBox1.Text = "("
        Me.TextBox1.Top = 0.3988189!
        Me.TextBox1.Width = 0.08779526!
        '
        'TextBox2
        '
        Me.TextBox2.CanGrow = False
        Me.TextBox2.Height = 0.1732284!
        Me.TextBox2.Left = 3.070473!
        Me.TextBox2.MultiLine = False
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.TextBox2.Text = ")"
        Me.TextBox2.Top = 0.4!
        Me.TextBox2.Width = 0.08779528!
        '
        'PageHeader
        '
        Me.PageHeader.CanGrow = False
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape2, Me.lblTitle, Me.Lbl_Seikyu3, Me.Label28, Me.sakuseibi, Me.Label29, Me.Label30, Me.TextBox7, Me.Label31, Me.CrossSectionBox2, Me.CrossSectionLine8, Me.CrossSectionLine10, Me.Label34, Me.Label35, Me.Label37, Me.Label47, Me.Label11, Me.Label12, Me.TAISYOBI, Me.Label7, Me.Label4, Me.Label5, Me.Label9, Me.Label13, Me.Label14, Me.Label1, Me.Label15, Me.Label16, Me.Label3, Me.Label6, Me.Label8, Me.Label10, Me.Label17, Me.Label18, Me.Label19, Me.TAISYO_KI, Me.Line6})
        Me.PageHeader.Height = 1.23622!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape2.Height = 0.5886457!
        Me.Shape2.Left = 0.0!
        Me.Shape2.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.Shape2.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Transparent
        Me.Shape2.LineWeight = 0.0!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(9.999999!)
        Me.Shape2.Top = 0.605!
        Me.Shape2.Width = 10.90158!
        '
        'lblTitle
        '
        Me.lblTitle.Height = 0.2401575!
        Me.lblTitle.HyperLink = Nothing
        Me.lblTitle.Left = 0.04094489!
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Style = "font-family: ＭＳ Ｐゴシック; font-size: 14pt; text-align: center"
        Me.lblTitle.Text = "<<　家畜防疫互助基金契約者一覧表（連絡用）　>>"
        Me.lblTitle.Top = 0.0!
        Me.lblTitle.Width = 10.88504!
        '
        'Lbl_Seikyu3
        '
        Me.Lbl_Seikyu3.Height = 0.1875!
        Me.Lbl_Seikyu3.HyperLink = Nothing
        Me.Lbl_Seikyu3.Left = 7.975!
        Me.Lbl_Seikyu3.Name = "Lbl_Seikyu3"
        Me.Lbl_Seikyu3.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left; ddo-char-set: 1"
        Me.Lbl_Seikyu3.Text = "（○：事務委託先取纏有無）"
        Me.Lbl_Seikyu3.Top = 0.427!
        Me.Lbl_Seikyu3.Width = 1.893834!
        '
        'Label28
        '
        Me.Label28.Height = 0.1875!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 9.114!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left; ddo-char-set: 1"
        Me.Label28.Text = "作成日："
        Me.Label28.Top = 0.233!
        Me.Label28.Width = 0.5708662!
        '
        'sakuseibi
        '
        Me.sakuseibi.DataField = "SAKUSEIBI"
        Me.sakuseibi.Height = 0.1875!
        Me.sakuseibi.Left = 9.685972!
        Me.sakuseibi.MultiLine = False
        Me.sakuseibi.Name = "sakuseibi"
        Me.sakuseibi.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; ddo-char-set: 1"
        Me.sakuseibi.Text = "平成99年99月99日"
        Me.sakuseibi.Top = 0.233!
        Me.sakuseibi.Width = 1.187402!
        '
        'Label29
        '
        Me.Label29.Height = 0.1875!
        Me.Label29.HyperLink = Nothing
        Me.Label29.Left = 9.941001!
        Me.Label29.Name = "Label29"
        Me.Label29.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left; ddo-char-set: 1"
        Me.Label29.Text = "ページ"
        Me.Label29.Top = 0.431!
        Me.Label29.Width = 0.4375!
        '
        'Label30
        '
        Me.Label30.Height = 0.1875!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 10.34099!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; ddo-char-set: 1"
        Me.Label30.Text = ":"
        Me.Label30.Top = 0.431!
        Me.Label30.Width = 0.125!
        '
        'TextBox7
        '
        Me.TextBox7.Height = 0.1875!
        Me.TextBox7.Left = 10.46101!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; ddo-char-set: 1"
        Me.TextBox7.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.TextBox7.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox7.Text = "Z,ZZ9"
        Me.TextBox7.Top = 0.431!
        Me.TextBox7.Width = 0.402441!
        '
        'Label31
        '
        Me.Label31.Height = 0.1574803!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 0.509!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label31.Text = "契約者名（法人名）"
        Me.Label31.Top = 0.669!
        Me.Label31.Width = 1.325198!
        '
        'CrossSectionBox2
        '
        Me.CrossSectionBox2.Bottom = 0.0000002980232!
        Me.CrossSectionBox2.Left = 0.00000005960464!
        Me.CrossSectionBox2.LineWeight = 3.0!
        Me.CrossSectionBox2.Name = "CrossSectionBox2"
        Me.CrossSectionBox2.Right = 10.91!
        Me.CrossSectionBox2.Top = 0.6149607!
        '
        'CrossSectionLine8
        '
        Me.CrossSectionLine8.Bottom = 0.00001728535!
        Me.CrossSectionLine8.Left = 0.431!
        Me.CrossSectionLine8.LineWeight = 1.0!
        Me.CrossSectionLine8.Name = "CrossSectionLine8"
        Me.CrossSectionLine8.Top = 0.626!
        '
        'CrossSectionLine10
        '
        Me.CrossSectionLine10.Bottom = 0.0006225407!
        Me.CrossSectionLine10.Left = 3.195!
        Me.CrossSectionLine10.LineWeight = 1.0!
        Me.CrossSectionLine10.Name = "CrossSectionLine10"
        Me.CrossSectionLine10.Top = 0.6259999!
        '
        'Label34
        '
        Me.Label34.Height = 0.1562992!
        Me.Label34.HyperLink = Nothing
        Me.Label34.Left = 0.509!
        Me.Label34.Name = "Label34"
        Me.Label34.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label34.Text = "代表者名"
        Me.Label34.Top = 0.839!
        Me.Label34.Width = 1.325!
        '
        'Label35
        '
        Me.Label35.Height = 0.1875!
        Me.Label35.HyperLink = Nothing
        Me.Label35.Left = 9.868505!
        Me.Label35.Name = "Label35"
        Me.Label35.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; ddo-char-set: 1"
        Me.Label35.Text = ""
        Me.Label35.Top = 0.4275591!
        Me.Label35.Width = 1.024413!
        '
        'Label37
        '
        Me.Label37.Height = 0.1562992!
        Me.Label37.HyperLink = Nothing
        Me.Label37.Left = 3.238!
        Me.Label37.Name = "Label37"
        Me.Label37.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label37.Text = "契約区分"
        Me.Label37.Top = 0.679!
        Me.Label37.Width = 0.6790003!
        '
        'Label47
        '
        Me.Label47.Height = 0.1562992!
        Me.Label47.HyperLink = Nothing
        Me.Label47.Left = 0.062!
        Me.Label47.Name = "Label47"
        Me.Label47.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center"
        Me.Label47.Text = "契約"
        Me.Label47.Top = 0.737!
        Me.Label47.Width = 0.348!
        '
        'Label11
        '
        Me.Label11.Height = 0.1889764!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 6.124!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center"
        Me.Label11.Text = "郵便番号"
        Me.Label11.Top = 0.67!
        Me.Label11.Width = 0.8040003!
        '
        'Label12
        '
        Me.Label12.Height = 0.1889764!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 5.051!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label12.Text = "契約年月日"
        Me.Label12.Top = 0.68!
        Me.Label12.Width = 0.7860003!
        '
        'TAISYOBI
        '
        Me.TAISYOBI.DataField = "TAISYOBI"
        Me.TAISYOBI.Height = 0.1875!
        Me.TAISYOBI.Left = 3.973!
        Me.TAISYOBI.MultiLine = False
        Me.TAISYOBI.Name = "TAISYOBI"
        Me.TAISYOBI.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; ddo-char-set: 1"
        Me.TAISYOBI.Text = "対象日：平成99年99月99日現在"
        Me.TAISYOBI.Top = 0.429!
        Me.TAISYOBI.Width = 3.045!
        '
        'Label7
        '
        Me.Label7.Height = 0.1562992!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.041!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center"
        Me.Label7.Text = "番号"
        Me.Label7.Top = 0.938!
        Me.Label7.Width = 0.369!
        '
        'Label4
        '
        Me.Label4.Height = 0.1562992!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.509!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label4.Text = "（事務委託先名）"
        Me.Label4.Top = 1.023!
        Me.Label4.Width = 1.325!
        '
        'Label5
        '
        Me.Label5.Height = 0.1562992!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 3.238!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label5.Text = "電話番号１"
        Me.Label5.Top = 0.859!
        Me.Label5.Width = 0.8141736!
        '
        'Label9
        '
        Me.Label9.Height = 0.1562992!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 3.238!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label9.Text = "電話番号２"
        Me.Label9.Top = 1.032!
        Me.Label9.Width = 0.8141736!
        '
        'Label13
        '
        Me.Label13.Height = 0.1562992!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 4.04!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label13.Text = "契約状況"
        Me.Label13.Top = 0.683!
        Me.Label13.Width = 0.6020002!
        '
        'Label14
        '
        Me.Label14.Height = 0.1562992!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 4.642!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label14.Text = "ＦＡＸ番号"
        Me.Label14.Top = 1.038!
        Me.Label14.Width = 0.8141736!
        '
        'Label1
        '
        Me.Label1.Height = 0.1562992!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 4.642!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label1.Text = "変更"
        Me.Label1.Top = 0.67!
        Me.Label1.Width = 0.3730001!
        '
        'Label15
        '
        Me.Label15.Height = 0.1562992!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 4.642!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label15.Text = "状況"
        Me.Label15.Top = 0.848!
        Me.Label15.Width = 0.3730001!
        '
        'Label16
        '
        Me.Label16.Height = 0.1889764!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 5.051!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label16.Text = "中止年月日"
        Me.Label16.Top = 0.881!
        Me.Label16.Width = 0.786!
        '
        'Label3
        '
        Me.Label3.Height = 0.1889764!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 6.959!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label3.Text = "住所１"
        Me.Label3.Top = 0.67!
        Me.Label3.Width = 0.5560004!
        '
        'Label6
        '
        Me.Label6.Height = 0.1889764!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 7.515!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label6.Text = "住所２"
        Me.Label6.Top = 0.678!
        Me.Label6.Width = 0.5560004!
        '
        'Label8
        '
        Me.Label8.Height = 0.1889764!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 6.124!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label8.Text = "住所3"
        Me.Label8.Top = 0.848!
        Me.Label8.Width = 0.5560004!
        '
        'Label10
        '
        Me.Label10.Height = 0.1889764!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 8.149!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label10.Text = "住所４"
        Me.Label10.Top = 0.826!
        Me.Label10.Width = 0.5560004!
        '
        'Label17
        '
        Me.Label17.Height = 0.1889764!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 6.124!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label17.Text = "(都道府県)"
        Me.Label17.Top = 1.013!
        Me.Label17.Width = 0.6690001!
        '
        'Label18
        '
        Me.Label18.Height = 0.1889764!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 6.793!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label18.Text = "(メールアドレス)"
        Me.Label18.Top = 1.015!
        Me.Label18.Width = 2.331!
        '
        'Label19
        '
        Me.Label19.Height = 0.1889764!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 10.613!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center"
        Me.Label19.Text = "○"
        Me.Label19.Top = 1.003!
        Me.Label19.Width = 0.2079992!
        '
        'TAISYO_KI
        '
        Me.TAISYO_KI.DataField = "TAISYO_KI"
        Me.TAISYO_KI.Height = 0.1874016!
        Me.TAISYO_KI.Left = 3.383071!
        Me.TAISYO_KI.MultiLine = False
        Me.TAISYO_KI.Name = "TAISYO_KI"
        Me.TAISYO_KI.Style = "font-family: ＭＳ Ｐゴシック; font-size: 11pt; text-align: center; ddo-char-set: 1"
        Me.TAISYO_KI.Text = "対象期：（平成99年度～平成99年度）"
        Me.TAISYO_KI.Top = 0.2330709!
        Me.TAISYO_KI.Width = 4.151969!
        '
        'Line6
        '
        Me.Line6.Height = 0.0!
        Me.Line6.Left = 0.0!
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 1.199!
        Me.Line6.Width = 10.90158!
        Me.Line6.X1 = 0.0!
        Me.Line6.X2 = 10.90158!
        Me.Line6.Y1 = 1.199!
        Me.Line6.Y2 = 1.199!
        '
        'PageFooter
        '
        Me.PageFooter.CanGrow = False
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label55})
        Me.PageFooter.Height = 0.2720636!
        Me.PageFooter.Name = "PageFooter"
        '
        'Label55
        '
        Me.Label55.Height = 0.1875!
        Me.Label55.HyperLink = Nothing
        Me.Label55.Left = 10.31693!
        Me.Label55.Name = "Label55"
        Me.Label55.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left; ddo-char-set: 1"
        Me.Label55.Text = "(S1030)"
        Me.Label55.Top = 0.0!
        Me.Label55.Width = 0.5043316!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanGrow = False
        Me.GroupHeader1.Height = 0.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.Before
        Me.GroupHeader1.RepeatStyle = GrapeCity.ActiveReports.SectionReportModel.RepeatStyle.OnPageIncludeNoDetail
        '
        'GroupFooter1
        '
        Me.GroupFooter1.CanGrow = False
        Me.GroupFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.FT_UNDER_LINE, Me.FT_UPPER_LINE, Me.Label20, Me.Label22, Me.Label23, Me.TextBox3})
        Me.GroupFooter1.Height = 0.6417323!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.After
        '
        'FT_UNDER_LINE
        '
        Me.FT_UNDER_LINE.Height = 0.0!
        Me.FT_UNDER_LINE.Left = 0.004!
        Me.FT_UNDER_LINE.LineWeight = 1.0!
        Me.FT_UNDER_LINE.Name = "FT_UNDER_LINE"
        Me.FT_UNDER_LINE.Top = 0.6417323!
        Me.FT_UNDER_LINE.Width = 10.90158!
        Me.FT_UNDER_LINE.X1 = 0.004!
        Me.FT_UNDER_LINE.X2 = 10.90558!
        Me.FT_UNDER_LINE.Y1 = 0.6417323!
        Me.FT_UNDER_LINE.Y2 = 0.6417323!
        '
        'FT_UPPER_LINE
        '
        Me.FT_UPPER_LINE.Height = 0.0!
        Me.FT_UPPER_LINE.Left = 0.0!
        Me.FT_UPPER_LINE.LineWeight = 1.0!
        Me.FT_UPPER_LINE.Name = "FT_UPPER_LINE"
        Me.FT_UPPER_LINE.Top = 0.0!
        Me.FT_UPPER_LINE.Width = 10.90158!
        Me.FT_UPPER_LINE.X1 = 0.0!
        Me.FT_UPPER_LINE.X2 = 10.90158!
        Me.FT_UPPER_LINE.Y1 = 0.0!
        Me.FT_UPPER_LINE.Y2 = 0.0!
        '
        'Label20
        '
        Me.Label20.Height = 0.1875!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 0.743!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: left; vertical-align: middle; dd" & _
            "o-char-set: 1"
        Me.Label20.Text = "総合計"
        Me.Label20.Top = 0.055!
        Me.Label20.Width = 0.694693!
        '
        'Label22
        '
        Me.Label22.Height = 0.19!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 1.438!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; d" & _
            "do-char-set: 1"
        Me.Label22.Text = "("
        Me.Label22.Top = 0.05500001!
        Me.Label22.Width = 0.17!
        '
        'Label23
        '
        Me.Label23.Height = 0.192!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 1.994!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: left; vertical-align: middle; dd" & _
            "o-char-set: 1"
        Me.Label23.Text = "人)"
        Me.Label23.Top = 0.05!
        Me.Label23.Width = 0.2750001!
        '
        'TextBox3
        '
        Me.TextBox3.CanGrow = False
        Me.TextBox3.DataField = "KEIYAKUSYA_CD"
        Me.TextBox3.DistinctField = "KEIYAKUSYA_CD"
        Me.TextBox3.Height = 0.1897638!
        Me.TextBox3.Left = 1.607874!
        Me.TextBox3.MultiLine = False
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" & _
            "hite-space: inherit; ddo-char-set: 128"
        Me.TextBox3.SummaryFunc = GrapeCity.ActiveReports.SectionReportModel.SummaryFunc.DCount
        Me.TextBox3.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.TextBox3.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal
        Me.TextBox3.Text = "9,999"
        Me.TextBox3.Top = 0.05511811!
        Me.TextBox3.Width = 0.3862205!
        '
        'rptGJ1030
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.3937008!
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.Margins.Top = 0.5905512!
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.69291!
        Me.PageSettings.PaperKind = 9
        Me.PageSettings.PaperWidth = 8.267716!
        Me.PrintWidth = 10.88858!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
                    "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.KEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKU_DATE_W, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DAIHYO_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ITAKU_RYAKU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKU_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEL1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEL2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKU_JYOKYO_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKU_HENKO_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HAIGYO_DATE_W, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADDR_POST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADDR_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADDR_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADDR_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADDR_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.E_MAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BANK_INJI_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lbl_Seikyu3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sakuseibi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TAISYOBI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TAISYO_KI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents PageHeader As GrapeCity.ActiveReports.SectionReportModel.PageHeader
    Private WithEvents PageFooter As GrapeCity.ActiveReports.SectionReportModel.PageFooter
    Private WithEvents GroupHeader1 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter1 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents KEIYAKUSYA_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents DTL_UNDER_LINE As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents KEIYAKU_DATE_W As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEIYAKUSYA_CD As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label55 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents FT_UPPER_LINE As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Shape2 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents lblTitle As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Lbl_Seikyu3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label28 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents sakuseibi As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label29 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label30 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox7 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label31 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents CrossSectionLine8 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine10 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents Label34 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Line6 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Label35 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label37 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label47 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents FT_UNDER_LINE As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Label11 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label12 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents DAIHYO_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents ITAKU_RYAKU As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEIYAKU_KBN_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TEL1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TEL2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEIYAKU_JYOKYO_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents FAX As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEIYAKU_HENKO_KBN_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents HAIGYO_DATE_W As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents ADDR_POST As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents ADDR_2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents ADDR_1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents ADDR_3 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents ADDR_4 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEN_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents E_MAIL As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents BANK_INJI_KBN_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TAISYOBI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label7 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label4 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label5 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label9 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label13 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label14 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label15 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label16 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label6 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label8 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label10 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label17 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label18 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label19 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label20 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label22 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label23 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TAISYO_KI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents CrossSectionBox2 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionBox
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox3 As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
