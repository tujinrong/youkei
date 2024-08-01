<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class rptGJ1040
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
    Private WithEvents PageHeader As GrapeCity.ActiveReports.SectionReportModel.PageHeader
    Private WithEvents Detail As GrapeCity.ActiveReports.SectionReportModel.Detail
    Private WithEvents PageFooter As GrapeCity.ActiveReports.SectionReportModel.PageFooter
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Shape1 = New GrapeCity.ActiveReports.SectionReportModel.Shape()
        Me.TAISYO_KI = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label36 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label37 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.SAKUSEIBI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label38 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtCurrentPage = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lblNo = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label41 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label42 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblNm = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lblNendo1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label46 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.USER_NAME_HED = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionBox1 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionBox()
        Me.CrossSectionLine1 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine3 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine4 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine5 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine6 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label6 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.NYURYOKU_KIKAN = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label4 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label5 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label7 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label8 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label9 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label10 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionLine2 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine7 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine8 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.Label13 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionLine9 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.Label14 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label15 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label16 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label17 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Line7 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label22 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label23 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label11 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label12 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label24 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.KEIYAKU_HASU = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line5 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.TORI_KBN_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.NOJO_ADDR = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line2 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.NOJO_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.REG_DATE = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.REG_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.UP_DATE = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.UP_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.DetailBankInfo_Bank = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.DetailBankInfo_Siten = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.DetailBankInfo_Koza = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.DetailBankInfo_Kana = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.DetailBankInfo_Meigi = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.DetailRowNum = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.DetailKeiyakuDate = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKUSYA_CD = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.DAIHYO_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.Label19 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.ReportHeader1 = New GrapeCity.ActiveReports.SectionReportModel.ReportHeader()
        Me.ReportFooter1 = New GrapeCity.ActiveReports.SectionReportModel.ReportFooter()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.Line1 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line4 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.GroupHeader2 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.GroupFooter2 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.SIKEI_KEIYAKU_HASU = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line8 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Label20 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.SOKEI_KEIYAKUSYA_CD = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label18 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Line3 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.GroupHeader3 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.NYURYOKU_JYOKYO_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKU_KBN_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKU_JYOKYO_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEI_ADDR = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKUSYA_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox4 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupFooter3 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.Label21 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.KEI_KEIYAKU_HASU = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line9 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line10 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.HasukeiBankInfo_Bank = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.HasukeiRowCnt = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.HasukeiBankInfo_Siten = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.HasukeiBankInfo_Koza = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.HasukeiBankInfo_Kana = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.HasukeiBankInfo_Meigi = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.HasukeiKeiyakuDate = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        CType(Me.TAISYO_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SAKUSEIBI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCurrentPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNendo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USER_NAME_HED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NYURYOKU_KIKAN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKU_HASU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TORI_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NOJO_ADDR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NOJO_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REG_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REG_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UP_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UP_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailBankInfo_Bank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailBankInfo_Siten, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailBankInfo_Koza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailBankInfo_Kana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailBankInfo_Meigi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailRowNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailKeiyakuDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DAIHYO_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SIKEI_KEIYAKU_HASU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SOKEI_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NYURYOKU_JYOKYO_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKU_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKU_JYOKYO_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEI_ADDR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEI_KEIYAKU_HASU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HasukeiBankInfo_Bank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HasukeiRowCnt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HasukeiBankInfo_Siten, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HasukeiBankInfo_Koza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HasukeiBankInfo_Kana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HasukeiBankInfo_Meigi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HasukeiKeiyakuDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape1, Me.TAISYO_KI, Me.Label36, Me.Label37, Me.SAKUSEIBI, Me.Label38, Me.txtCurrentPage, Me.lblNo, Me.Label41, Me.Label42, Me.lblNm, Me.lblNendo1, Me.Label46, Me.USER_NAME_HED, Me.CrossSectionBox1, Me.CrossSectionLine1, Me.CrossSectionLine3, Me.CrossSectionLine4, Me.CrossSectionLine5, Me.CrossSectionLine6, Me.Label2, Me.Label6, Me.NYURYOKU_KIKAN, Me.Label4, Me.Label5, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.CrossSectionLine2, Me.CrossSectionLine7, Me.CrossSectionLine8, Me.Label13, Me.CrossSectionLine9, Me.Label14, Me.Label15, Me.Label16, Me.Label17, Me.Line7, Me.Label3, Me.Label22, Me.Label23, Me.Label11, Me.Label12, Me.Label24})
        Me.PageHeader.Height = 1.342945!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape1.Height = 0.5009999!
        Me.Shape1.Left = 0.02!
        Me.Shape1.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.Shape1.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Transparent
        Me.Shape1.LineWeight = 0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(9.999999!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Top = 0.8330001!
        Me.Shape1.Width = 13.4!
        '
        'TAISYO_KI
        '
        Me.TAISYO_KI.DataField = "TAISYO_KI"
        Me.TAISYO_KI.Height = 0.1574803!
        Me.TAISYO_KI.HyperLink = Nothing
        Me.TAISYO_KI.Left = 0!
        Me.TAISYO_KI.Name = "TAISYO_KI"
        Me.TAISYO_KI.Style = "font-family: ＭＳ Ｐゴシック; font-size: 11pt; text-align: center; vertical-align: top; " &
    "ddo-char-set: 1"
        Me.TAISYO_KI.Text = "対象期：第9期（平成99年度～平成99年度）"
        Me.TAISYO_KI.Top = 0.3984252!
        Me.TAISYO_KI.Width = 13.42!
        '
        'Label36
        '
        Me.Label36.Height = 0.1968504!
        Me.Label36.HyperLink = Nothing
        Me.Label36.Left = 0!
        Me.Label36.Name = "Label36"
        Me.Label36.Style = "font-family: ＭＳ Ｐゴシック; font-size: 14pt; font-weight: normal; text-align: center"
        Me.Label36.Text = "<<　契約者別契約情報入力確認チェックリスト（農場別等）　>>"
        Me.Label36.Top = 0!
        Me.Label36.Width = 13.437!
        '
        'Label37
        '
        Me.Label37.Height = 0.1574803!
        Me.Label37.HyperLink = Nothing
        Me.Label37.Left = 11.60597!
        Me.Label37.Name = "Label37"
        Me.Label37.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left; ddo-char-set: 1"
        Me.Label37.Text = "作成日"
        Me.Label37.Top = 0.253!
        Me.Label37.Width = 0.4894686!
        '
        'SAKUSEIBI
        '
        Me.SAKUSEIBI.DataField = "SAKUSEIBI"
        Me.SAKUSEIBI.Height = 0.1574803!
        Me.SAKUSEIBI.Left = 12.254!
        Me.SAKUSEIBI.MultiLine = False
        Me.SAKUSEIBI.Name = "SAKUSEIBI"
        Me.SAKUSEIBI.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; ddo-char-set: 1"
        Me.SAKUSEIBI.Text = "平成99年99月99日"
        Me.SAKUSEIBI.Top = 0.253!
        Me.SAKUSEIBI.Width = 1.187402!
        '
        'Label38
        '
        Me.Label38.Height = 0.1574803!
        Me.Label38.HyperLink = Nothing
        Me.Label38.Left = 12.50865!
        Me.Label38.Name = "Label38"
        Me.Label38.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left; ddo-char-set: 1"
        Me.Label38.Text = "ページ"
        Me.Label38.Top = 0.4104804!
        Me.Label38.Width = 0.4375!
        '
        'txtCurrentPage
        '
        Me.txtCurrentPage.Height = 0.1574803!
        Me.txtCurrentPage.Left = 13.02873!
        Me.txtCurrentPage.Name = "txtCurrentPage"
        Me.txtCurrentPage.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; ddo-char-set: 1"
        Me.txtCurrentPage.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.txtCurrentPage.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.txtCurrentPage.Text = "Z,ZZ9"
        Me.txtCurrentPage.Top = 0.4104804!
        Me.txtCurrentPage.Width = 0.402441!
        '
        'lblNo
        '
        Me.lblNo.Height = 0.2182758!
        Me.lblNo.HyperLink = Nothing
        Me.lblNo.Left = 0.031!
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; ddo-char-set: 128"
        Me.lblNo.Text = "契約"
        Me.lblNo.Top = 0.874!
        Me.lblNo.Width = 0.3805276!
        '
        'Label41
        '
        Me.Label41.Height = 0.1885826!
        Me.Label41.HyperLink = Nothing
        Me.Label41.Left = 12.392!
        Me.Label41.Name = "Label41"
        Me.Label41.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; ddo-char-set: 1"
        Me.Label41.Text = "（単位：羽、人）"
        Me.Label41.Top = 0.654!
        Me.Label41.Width = 1.02795!
        '
        'Label42
        '
        Me.Label42.Height = 0.1574803!
        Me.Label42.HyperLink = Nothing
        Me.Label42.Left = 12.90394!
        Me.Label42.Name = "Label42"
        Me.Label42.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; ddo-char-set: 1"
        Me.Label42.Text = ":"
        Me.Label42.Top = 0.4104804!
        Me.Label42.Width = 0.125!
        '
        'lblNm
        '
        Me.lblNm.Height = 0.15!
        Me.lblNm.HyperLink = Nothing
        Me.lblNm.Left = 0.456!
        Me.lblNm.MultiLine = False
        Me.lblNm.Name = "lblNm"
        Me.lblNm.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.lblNm.Text = "契約者名　代表者名"
        Me.lblNm.Top = 0.864!
        Me.lblNm.Width = 2.82!
        '
        'lblNendo1
        '
        Me.lblNendo1.Height = 0.218!
        Me.lblNendo1.HyperLink = Nothing
        Me.lblNendo1.Left = 3.316536!
        Me.lblNendo1.MultiLine = False
        Me.lblNendo1.Name = "lblNendo1"
        Me.lblNendo1.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.lblNendo1.Text = "入力"
        Me.lblNendo1.Top = 0.8739213!
        Me.lblNendo1.Width = 0.3327482!
        '
        'Label46
        '
        Me.Label46.Height = 0.2190001!
        Me.Label46.HyperLink = Nothing
        Me.Label46.Left = 3.316536!
        Me.Label46.MultiLine = False
        Me.Label46.Name = "Label46"
        Me.Label46.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label46.Text = "状況"
        Me.Label46.Top = 1.091921!
        Me.Label46.Width = 0.3327482!
        '
        'USER_NAME_HED
        '
        Me.USER_NAME_HED.DataField = "USER_NAME_HED"
        Me.USER_NAME_HED.Height = 0.1885826!
        Me.USER_NAME_HED.HyperLink = Nothing
        Me.USER_NAME_HED.Left = 0.06653544!
        Me.USER_NAME_HED.Name = "USER_NAME_HED"
        Me.USER_NAME_HED.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: justify; vertical-align: top;" &
    " ddo-char-set: 1"
        Me.USER_NAME_HED.Text = "入力者：＠＠＠＠＠＠＠＠＠＠"
        Me.USER_NAME_HED.Top = 0.6480315!
        Me.USER_NAME_HED.Width = 2.174465!
        '
        'CrossSectionBox1
        '
        Me.CrossSectionBox1.Bottom = 0!
        Me.CrossSectionBox1.Left = 0!
        Me.CrossSectionBox1.LineWeight = 3.0!
        Me.CrossSectionBox1.Name = "CrossSectionBox1"
        Me.CrossSectionBox1.Radius = New GrapeCity.ActiveReports.Controls.CornersRadius(0!, Nothing, Nothing, Nothing, Nothing)
        Me.CrossSectionBox1.Right = 13.437!
        Me.CrossSectionBox1.Top = 0.8326772!
        '
        'CrossSectionLine1
        '
        Me.CrossSectionLine1.Bottom = 0!
        Me.CrossSectionLine1.Left = 0.436!
        Me.CrossSectionLine1.LineWeight = 1.0!
        Me.CrossSectionLine1.Name = "CrossSectionLine1"
        Me.CrossSectionLine1.Top = 0.8421259!
        '
        'CrossSectionLine3
        '
        Me.CrossSectionLine3.Bottom = 0!
        Me.CrossSectionLine3.Left = 3.296772!
        Me.CrossSectionLine3.LineWeight = 1.0!
        Me.CrossSectionLine3.Name = "CrossSectionLine3"
        Me.CrossSectionLine3.Top = 0.8421264!
        '
        'CrossSectionLine4
        '
        Me.CrossSectionLine4.Bottom = 1.421085E-14!
        Me.CrossSectionLine4.Left = 3.680709!
        Me.CrossSectionLine4.LineWeight = 1.0!
        Me.CrossSectionLine4.Name = "CrossSectionLine4"
        Me.CrossSectionLine4.Top = 0.8421264!
        '
        'CrossSectionLine5
        '
        Me.CrossSectionLine5.Bottom = 0.00001573563!
        Me.CrossSectionLine5.Left = 4.106299!
        Me.CrossSectionLine5.LineWeight = 1.0!
        Me.CrossSectionLine5.Name = "CrossSectionLine5"
        Me.CrossSectionLine5.Top = 0.8421421!
        '
        'CrossSectionLine6
        '
        Me.CrossSectionLine6.Bottom = 0!
        Me.CrossSectionLine6.Left = 4.558989!
        Me.CrossSectionLine6.LineWeight = 1.0!
        Me.CrossSectionLine6.Name = "CrossSectionLine6"
        Me.CrossSectionLine6.Top = 0.8421259!
        '
        'Label2
        '
        Me.Label2.Height = 0.1574803!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 12.04416!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; ddo-char-set: 1"
        Me.Label2.Text = ":"
        Me.Label2.Top = 0.253!
        Me.Label2.Width = 0.125!
        '
        'Label6
        '
        Me.Label6.Height = 0.2182758!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.031!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; ddo-char-set: 128"
        Me.Label6.Text = "番号"
        Me.Label6.Top = 1.092276!
        Me.Label6.Width = 0.3805276!
        '
        'NYURYOKU_KIKAN
        '
        Me.NYURYOKU_KIKAN.DataField = "NYURYOKU_KIKAN"
        Me.NYURYOKU_KIKAN.Height = 0.1574803!
        Me.NYURYOKU_KIKAN.HyperLink = Nothing
        Me.NYURYOKU_KIKAN.Left = 4.732!
        Me.NYURYOKU_KIKAN.Name = "NYURYOKU_KIKAN"
        Me.NYURYOKU_KIKAN.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: top; " &
    "ddo-char-set: 1"
        Me.NYURYOKU_KIKAN.Text = "（入力期間：平成99/99/99～平成99/99/99）"
        Me.NYURYOKU_KIKAN.Top = 0.568!
        Me.NYURYOKU_KIKAN.Width = 3.876!
        '
        'Label4
        '
        Me.Label4.Height = 0.15!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.456!
        Me.Label4.MultiLine = False
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left; vertical-align: middle;" &
    " white-space: nowrap; ddo-char-set: 1"
        Me.Label4.Text = "　 電話番号1       電話番号2　     　 FAX"
        Me.Label4.Top = 1.017!
        Me.Label4.Width = 2.82!
        '
        'Label5
        '
        Me.Label5.Height = 0.2179999!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 3.731496!
        Me.Label5.MultiLine = False
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label5.Text = "契約"
        Me.Label5.Top = 0.874126!
        Me.Label5.Width = 0.3327484!
        '
        'Label7
        '
        Me.Label7.Height = 0.2190001!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 3.731496!
        Me.Label7.MultiLine = False
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label7.Text = "区分"
        Me.Label7.Top = 1.092126!
        Me.Label7.Width = 0.3327484!
        '
        'Label8
        '
        Me.Label8.Height = 0.2179999!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 4.115748!
        Me.Label8.MultiLine = False
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label8.Text = "契約"
        Me.Label8.Top = 0.8740158!
        Me.Label8.Width = 0.447!
        '
        'Label9
        '
        Me.Label9.Height = 0.2190001!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 4.115748!
        Me.Label9.MultiLine = False
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label9.Text = "状況"
        Me.Label9.Top = 1.092016!
        Me.Label9.Width = 0.4469995!
        '
        'Label10
        '
        Me.Label10.Height = 0.2179999!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 7.509!
        Me.Label10.MultiLine = False
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label10.Text = "鶏の種類"
        Me.Label10.Top = 0.874!
        Me.Label10.Width = 0.77!
        '
        'CrossSectionLine2
        '
        Me.CrossSectionLine2.Bottom = 0!
        Me.CrossSectionLine2.Left = 7.479!
        Me.CrossSectionLine2.LineWeight = 1.0!
        Me.CrossSectionLine2.Name = "CrossSectionLine2"
        Me.CrossSectionLine2.Top = 0.8430001!
        '
        'CrossSectionLine7
        '
        Me.CrossSectionLine7.Bottom = 0!
        Me.CrossSectionLine7.Left = 8.299!
        Me.CrossSectionLine7.LineWeight = 1.0!
        Me.CrossSectionLine7.Name = "CrossSectionLine7"
        Me.CrossSectionLine7.Top = 0.8430001!
        '
        'CrossSectionLine8
        '
        Me.CrossSectionLine8.Bottom = 0!
        Me.CrossSectionLine8.Left = 12.609!
        Me.CrossSectionLine8.LineWeight = 1.0!
        Me.CrossSectionLine8.Name = "CrossSectionLine8"
        Me.CrossSectionLine8.Top = 0.8430001!
        '
        'Label13
        '
        Me.Label13.Height = 0.2179999!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 8.334001!
        Me.Label13.MultiLine = False
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label13.Text = "契約羽数"
        Me.Label13.Top = 0.876!
        Me.Label13.Width = 0.6979995!
        '
        'CrossSectionLine9
        '
        Me.CrossSectionLine9.Bottom = 0!
        Me.CrossSectionLine9.Left = 9.049!
        Me.CrossSectionLine9.LineWeight = 1.0!
        Me.CrossSectionLine9.Name = "CrossSectionLine9"
        Me.CrossSectionLine9.Top = 0.8430001!
        '
        'Label14
        '
        Me.Label14.Height = 0.2179999!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 9.081!
        Me.Label14.MultiLine = False
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label14.Text = "農場名"
        Me.Label14.Top = 0.876!
        Me.Label14.Width = 3.528!
        '
        'Label15
        '
        Me.Label15.Height = 0.2179999!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 9.081!
        Me.Label15.MultiLine = False
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label15.Text = "所在地"
        Me.Label15.Top = 1.096!
        Me.Label15.Width = 3.528!
        '
        'Label16
        '
        Me.Label16.Height = 0.1347561!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 12.63386!
        Me.Label16.MultiLine = False
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label16.Text = "登録日"
        Me.Label16.Top = 0.8346456!
        Me.Label16.Width = 0.749999!
        '
        'Label17
        '
        Me.Label17.Height = 0.1377953!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 12.63386!
        Me.Label17.MultiLine = False
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label17.Text = "登録者"
        Me.Label17.Top = 0.9566929!
        Me.Label17.Width = 0.7480315!
        '
        'Line7
        '
        Me.Line7.Height = 0!
        Me.Line7.Left = 0!
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 1.336!
        Me.Line7.Width = 13.42!
        Me.Line7.X1 = 0!
        Me.Line7.X2 = 13.42!
        Me.Line7.Y1 = 1.336!
        Me.Line7.Y2 = 1.336!
        '
        'Label3
        '
        Me.Label3.Height = 0.134756!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 12.63386!
        Me.Label3.MultiLine = False
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label3.Text = "更新日"
        Me.Label3.Top = 1.07874!
        Me.Label3.Width = 0.7499993!
        '
        'Label22
        '
        Me.Label22.Height = 0.134756!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 12.63386!
        Me.Label22.MultiLine = False
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label22.Text = "更新者"
        Me.Label22.Top = 1.200787!
        Me.Label22.Width = 0.7499993!
        '
        'Label23
        '
        Me.Label23.Height = 0.15!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 0.456!
        Me.Label23.MultiLine = False
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label23.Text = "金融機関　支店　契約日"
        Me.Label23.Top = 1.174!
        Me.Label23.Width = 2.82!
        '
        'Label11
        '
        Me.Label11.Height = 0.15!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 4.615!
        Me.Label11.MultiLine = False
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label11.Text = "契約者所在地住所"
        Me.Label11.Top = 0.851!
        Me.Label11.Width = 2.82!
        '
        'Label12
        '
        Me.Label12.Height = 0.15!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 4.615!
        Me.Label12.MultiLine = False
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label12.Text = "メールアドレス"
        Me.Label12.Top = 1.004!
        Me.Label12.Width = 2.82!
        '
        'Label24
        '
        Me.Label24.Height = 0.15!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 4.615!
        Me.Label24.MultiLine = False
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label24.Text = "口座情報"
        Me.Label24.Top = 1.161!
        Me.Label24.Width = 2.82!
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.KEIYAKU_HASU, Me.Line5, Me.TORI_KBN_NM, Me.NOJO_ADDR, Me.Line2, Me.NOJO_NAME, Me.REG_DATE, Me.REG_NAME, Me.UP_DATE, Me.UP_NAME, Me.DetailBankInfo_Bank, Me.DetailBankInfo_Siten, Me.DetailBankInfo_Koza, Me.DetailBankInfo_Kana, Me.DetailBankInfo_Meigi, Me.DetailRowNum, Me.DetailKeiyakuDate})
        Me.Detail.Height = 0.575!
        Me.Detail.Name = "Detail"
        '
        'KEIYAKU_HASU
        '
        Me.KEIYAKU_HASU.DataField = "KEIYAKU_HASU"
        Me.KEIYAKU_HASU.Height = 0.2!
        Me.KEIYAKU_HASU.Left = 8.334001!
        Me.KEIYAKU_HASU.MultiLine = False
        Me.KEIYAKU_HASU.Name = "KEIYAKU_HASU"
        Me.KEIYAKU_HASU.OutputFormat = "#,##0"
        Me.KEIYAKU_HASU.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KEIYAKU_HASU.Text = "99,999,999"
        Me.KEIYAKU_HASU.Top = 0.03!
        Me.KEIYAKU_HASU.Width = 0.698!
        '
        'Line5
        '
        Me.Line5.Height = 0!
        Me.Line5.Left = 0!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.58!
        Me.Line5.Visible = False
        Me.Line5.Width = 13.41953!
        Me.Line5.X1 = 0!
        Me.Line5.X2 = 13.41953!
        Me.Line5.Y1 = 0.58!
        Me.Line5.Y2 = 0.58!
        '
        'TORI_KBN_NM
        '
        Me.TORI_KBN_NM.DataField = "TORI_KBN_NM"
        Me.TORI_KBN_NM.Height = 0.2!
        Me.TORI_KBN_NM.Left = 7.509!
        Me.TORI_KBN_NM.Name = "TORI_KBN_NM"
        Me.TORI_KBN_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "white-space: inherit"
        Me.TORI_KBN_NM.Text = "採卵鶏(成鶏)"
        Me.TORI_KBN_NM.Top = 0.03!
        Me.TORI_KBN_NM.Width = 0.77!
        '
        'NOJO_ADDR
        '
        Me.NOJO_ADDR.DataField = "NOJO_ADDR"
        Me.NOJO_ADDR.Height = 0.3!
        Me.NOJO_ADDR.Left = 9.069!
        Me.NOJO_ADDR.Name = "NOJO_ADDR"
        Me.NOJO_ADDR.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: left; vertical-align: middle; wh" &
    "ite-space: inherit"
        Me.NOJO_ADDR.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.NOJO_ADDR.Top = 0.22!
        Me.NOJO_ADDR.Width = 3.54!
        '
        'Line2
        '
        Me.Line2.Height = 0!
        Me.Line2.Left = 0!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.005!
        Me.Line2.Width = 13.42!
        Me.Line2.X1 = 0!
        Me.Line2.X2 = 13.42!
        Me.Line2.Y1 = 0.005!
        Me.Line2.Y2 = 0.005!
        '
        'NOJO_NAME
        '
        Me.NOJO_NAME.DataField = "NOJO_NAME"
        Me.NOJO_NAME.Height = 0.2!
        Me.NOJO_NAME.Left = 9.081!
        Me.NOJO_NAME.MultiLine = False
        Me.NOJO_NAME.Name = "NOJO_NAME"
        Me.NOJO_NAME.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.NOJO_NAME.Text = "（999）ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.NOJO_NAME.Top = 0.04!
        Me.NOJO_NAME.Width = 3.527999!
        '
        'REG_DATE
        '
        Me.REG_DATE.DataField = "REG_DATE"
        Me.REG_DATE.Height = 0.1181102!
        Me.REG_DATE.Left = 12.63386!
        Me.REG_DATE.MultiLine = False
        Me.REG_DATE.Name = "REG_DATE"
        Me.REG_DATE.OutputFormat = "MM/dd"
        Me.REG_DATE.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "white-space: nowrap"
        Me.REG_DATE.Text = "99/99"
        Me.REG_DATE.Top = 0.003937008!
        Me.REG_DATE.Width = 0.7519685!
        '
        'REG_NAME
        '
        Me.REG_NAME.DataField = "REG_NAME"
        Me.REG_NAME.Height = 0.1287402!
        Me.REG_NAME.Left = 12.63386!
        Me.REG_NAME.MultiLine = False
        Me.REG_NAME.Name = "REG_NAME"
        Me.REG_NAME.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "white-space: nowrap"
        Me.REG_NAME.Text = "ＮＮＮＮＮＮ"
        Me.REG_NAME.Top = 0.1417323!
        Me.REG_NAME.Width = 0.750001!
        '
        'UP_DATE
        '
        Me.UP_DATE.DataField = "UP_DATE"
        Me.UP_DATE.Height = 0.1299213!
        Me.UP_DATE.Left = 12.63386!
        Me.UP_DATE.MultiLine = False
        Me.UP_DATE.Name = "UP_DATE"
        Me.UP_DATE.OutputFormat = "MM/dd"
        Me.UP_DATE.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "white-space: nowrap"
        Me.UP_DATE.Text = "99/99"
        Me.UP_DATE.Top = 0.2834646!
        Me.UP_DATE.Width = 0.7519685!
        '
        'UP_NAME
        '
        Me.UP_NAME.DataField = "UP_NAME"
        Me.UP_NAME.Height = 0.1287401!
        Me.UP_NAME.Left = 12.63386!
        Me.UP_NAME.MultiLine = False
        Me.UP_NAME.Name = "UP_NAME"
        Me.UP_NAME.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "white-space: nowrap"
        Me.UP_NAME.Text = "ＮＮＮＮＮＮ"
        Me.UP_NAME.Top = 0.4094488!
        Me.UP_NAME.Width = 0.7500007!
        '
        'DetailBankInfo_Bank
        '
        Me.DetailBankInfo_Bank.DataField = "BANK"
        Me.DetailBankInfo_Bank.Height = 0.1496063!
        Me.DetailBankInfo_Bank.Left = 0.477!
        Me.DetailBankInfo_Bank.MultiLine = False
        Me.DetailBankInfo_Bank.Name = "DetailBankInfo_Bank"
        Me.DetailBankInfo_Bank.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.DetailBankInfo_Bank.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.DetailBankInfo_Bank.Top = 0.03!
        Me.DetailBankInfo_Bank.Width = 2.779!
        '
        'DetailBankInfo_Siten
        '
        Me.DetailBankInfo_Siten.DataField = "SITEN"
        Me.DetailBankInfo_Siten.Height = 0.1496063!
        Me.DetailBankInfo_Siten.Left = 0.477!
        Me.DetailBankInfo_Siten.MultiLine = False
        Me.DetailBankInfo_Siten.Name = "DetailBankInfo_Siten"
        Me.DetailBankInfo_Siten.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.DetailBankInfo_Siten.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.DetailBankInfo_Siten.Top = 0.2203032!
        Me.DetailBankInfo_Siten.Width = 2.779!
        '
        'DetailBankInfo_Koza
        '
        Me.DetailBankInfo_Koza.DataField = "KOZA"
        Me.DetailBankInfo_Koza.Height = 0.1496063!
        Me.DetailBankInfo_Koza.Left = 4.615!
        Me.DetailBankInfo_Koza.MultiLine = False
        Me.DetailBankInfo_Koza.Name = "DetailBankInfo_Koza"
        Me.DetailBankInfo_Koza.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.DetailBankInfo_Koza.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.DetailBankInfo_Koza.Top = 0.03!
        Me.DetailBankInfo_Koza.Width = 2.779!
        '
        'DetailBankInfo_Kana
        '
        Me.DetailBankInfo_Kana.DataField = "FURI_KOZA_MEIGI_KANA"
        Me.DetailBankInfo_Kana.Height = 0.149!
        Me.DetailBankInfo_Kana.Left = 4.615!
        Me.DetailBankInfo_Kana.MultiLine = False
        Me.DetailBankInfo_Kana.Name = "DetailBankInfo_Kana"
        Me.DetailBankInfo_Kana.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.DetailBankInfo_Kana.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.DetailBankInfo_Kana.Top = 0.2203032!
        Me.DetailBankInfo_Kana.Width = 2.779!
        '
        'DetailBankInfo_Meigi
        '
        Me.DetailBankInfo_Meigi.DataField = "FURI_KOZA_MEIGI"
        Me.DetailBankInfo_Meigi.Height = 0.1496063!
        Me.DetailBankInfo_Meigi.Left = 4.615!
        Me.DetailBankInfo_Meigi.MultiLine = False
        Me.DetailBankInfo_Meigi.Name = "DetailBankInfo_Meigi"
        Me.DetailBankInfo_Meigi.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.DetailBankInfo_Meigi.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.DetailBankInfo_Meigi.Top = 0.41!
        Me.DetailBankInfo_Meigi.Width = 2.779!
        '
        'DetailRowNum
        '
        Me.DetailRowNum.DataField = "ROW_NUM"
        Me.DetailRowNum.Height = 0.1496063!
        Me.DetailRowNum.Left = 0.031!
        Me.DetailRowNum.MultiLine = False
        Me.DetailRowNum.Name = "DetailRowNum"
        Me.DetailRowNum.Style = "background-color: LightSkyBlue; font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: " &
    "justify; vertical-align: middle; white-space: nowrap"
        Me.DetailRowNum.Text = "Ｎ"
        Me.DetailRowNum.Top = 0.03!
        Me.DetailRowNum.Visible = False
        Me.DetailRowNum.Width = 0.332!
        '
        'DetailKeiyakuDate
        '
        Me.DetailKeiyakuDate.DataField = "KEIYAKU_DATE"
        Me.DetailKeiyakuDate.Height = 0.118!
        Me.DetailKeiyakuDate.Left = 0.477!
        Me.DetailKeiyakuDate.Name = "DetailKeiyakuDate"
        Me.DetailKeiyakuDate.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: left; vertical-align: middle; wh" &
    "ite-space: nowrap"
        Me.DetailKeiyakuDate.Text = "1234/56/78"
        Me.DetailKeiyakuDate.Top = 0.402!
        Me.DetailKeiyakuDate.Width = 1.11!
        '
        'KEIYAKUSYA_CD
        '
        Me.KEIYAKUSYA_CD.DataField = "KEIYAKUSYA_CD"
        Me.KEIYAKUSYA_CD.Height = 0.1496063!
        Me.KEIYAKUSYA_CD.Left = 0.031!
        Me.KEIYAKUSYA_CD.MultiLine = False
        Me.KEIYAKUSYA_CD.Name = "KEIYAKUSYA_CD"
        Me.KEIYAKUSYA_CD.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KEIYAKUSYA_CD.Text = "99999"
        Me.KEIYAKUSYA_CD.Top = 0.03!
        Me.KEIYAKUSYA_CD.Width = 0.3812914!
        '
        'DAIHYO_NAME
        '
        Me.DAIHYO_NAME.DataField = "DAIHYO_NAME"
        Me.DAIHYO_NAME.Height = 0.1496063!
        Me.DAIHYO_NAME.Left = 0.477!
        Me.DAIHYO_NAME.MultiLine = False
        Me.DAIHYO_NAME.Name = "DAIHYO_NAME"
        Me.DAIHYO_NAME.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.DAIHYO_NAME.Text = "あいうえおかきくけこさしすせそたちつてとなにぬねの"
        Me.DAIHYO_NAME.Top = 0.18!
        Me.DAIHYO_NAME.Width = 2.799!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label19})
        Me.PageFooter.Height = 0.2083333!
        Me.PageFooter.Name = "PageFooter"
        '
        'Label19
        '
        Me.Label19.Height = 0.1783465!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 12.904!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; ddo-char-set: 128"
        Me.Label19.Text = "（S1040）"
        Me.Label19.Top = 0!
        Me.Label19.Width = 0.5330682!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Height = 0!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0!
        Me.ReportFooter1.Name = "ReportFooter1"
        Me.ReportFooter1.PrintAtBottom = True
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Height = 0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Line1, Me.Line4})
        Me.GroupFooter1.Height = 0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Line1
        '
        Me.Line1.Height = 0!
        Me.Line1.Left = 0!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.3267716!
        Me.Line1.Width = 13.42!
        Me.Line1.X1 = 0!
        Me.Line1.X2 = 13.42!
        Me.Line1.Y1 = 0.3267716!
        Me.Line1.Y2 = 0.3267716!
        '
        'Line4
        '
        Me.Line4.Height = 0!
        Me.Line4.Left = 0!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0!
        Me.Line4.Width = 13.42!
        Me.Line4.X1 = 0!
        Me.Line4.X2 = 13.42!
        Me.Line4.Y1 = 0!
        Me.Line4.Y2 = 0!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.DataField = "USER_ID"
        Me.GroupHeader2.Height = 0!
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.Before
        Me.GroupHeader2.UnderlayNext = True
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.SIKEI_KEIYAKU_HASU, Me.Line8, Me.Label20, Me.Label1, Me.SOKEI_KEIYAKUSYA_CD, Me.Label18, Me.Line3})
        Me.GroupFooter2.Height = 0.575!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'SIKEI_KEIYAKU_HASU
        '
        Me.SIKEI_KEIYAKU_HASU.DataField = "KEIYAKU_HASU"
        Me.SIKEI_KEIYAKU_HASU.Height = 0.2!
        Me.SIKEI_KEIYAKU_HASU.Left = 8.334002!
        Me.SIKEI_KEIYAKU_HASU.MultiLine = False
        Me.SIKEI_KEIYAKU_HASU.Name = "SIKEI_KEIYAKU_HASU"
        Me.SIKEI_KEIYAKU_HASU.OutputFormat = "#,##0"
        Me.SIKEI_KEIYAKU_HASU.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.SIKEI_KEIYAKU_HASU.SummaryGroup = "GroupHeader2"
        Me.SIKEI_KEIYAKU_HASU.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.SIKEI_KEIYAKU_HASU.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.SIKEI_KEIYAKU_HASU.Text = "999,999,999"
        Me.SIKEI_KEIYAKU_HASU.Top = 0.02!
        Me.SIKEI_KEIYAKU_HASU.Width = 0.698!
        '
        'Line8
        '
        Me.Line8.Height = 0!
        Me.Line8.Left = 0!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0.58!
        Me.Line8.Width = 13.42!
        Me.Line8.X1 = 0!
        Me.Line8.X2 = 13.42!
        Me.Line8.Y1 = 0.58!
        Me.Line8.Y2 = 0.58!
        '
        'Label20
        '
        Me.Label20.Height = 0.2!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 7.509!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "ddo-char-set: 1"
        Me.Label20.Text = "総合計"
        Me.Label20.Top = 0.02!
        Me.Label20.Width = 0.77!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 5.169!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "ddo-char-set: 1"
        Me.Label1.Text = "（契約者数："
        Me.Label1.Top = 0.02!
        Me.Label1.Width = 0.7260003!
        '
        'SOKEI_KEIYAKUSYA_CD
        '
        Me.SOKEI_KEIYAKUSYA_CD.DataField = "KEIYAKUSYA_CD"
        Me.SOKEI_KEIYAKUSYA_CD.DistinctField = "KEIYAKUSYA_CD"
        Me.SOKEI_KEIYAKUSYA_CD.Height = 0.2!
        Me.SOKEI_KEIYAKUSYA_CD.Left = 5.895!
        Me.SOKEI_KEIYAKUSYA_CD.MultiLine = False
        Me.SOKEI_KEIYAKUSYA_CD.Name = "SOKEI_KEIYAKUSYA_CD"
        Me.SOKEI_KEIYAKUSYA_CD.OutputFormat = "#,##0"
        Me.SOKEI_KEIYAKUSYA_CD.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.SOKEI_KEIYAKUSYA_CD.SummaryFunc = GrapeCity.ActiveReports.SectionReportModel.SummaryFunc.DCount
        Me.SOKEI_KEIYAKUSYA_CD.SummaryGroup = "GroupHeader2"
        Me.SOKEI_KEIYAKUSYA_CD.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.SOKEI_KEIYAKUSYA_CD.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.SOKEI_KEIYAKUSYA_CD.Text = "99,999"
        Me.SOKEI_KEIYAKUSYA_CD.Top = 0.02!
        Me.SOKEI_KEIYAKUSYA_CD.Width = 0.4169998!
        '
        'Label18
        '
        Me.Label18.Height = 0.2!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 6.313!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: left; vertical-align: middle; dd" &
    "o-char-set: 1"
        Me.Label18.Text = "人）"
        Me.Label18.Top = 0.02!
        Me.Label18.Width = 0.2360002!
        '
        'Line3
        '
        Me.Line3.Height = 0!
        Me.Line3.Left = 0!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.005!
        Me.Line3.Width = 13.42!
        Me.Line3.X1 = 0!
        Me.Line3.X2 = 13.42!
        Me.Line3.Y1 = 0.005!
        Me.Line3.Y2 = 0.005!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.KEIYAKUSYA_CD, Me.DAIHYO_NAME, Me.NYURYOKU_JYOKYO_NM, Me.KEIYAKU_KBN_NM, Me.KEIYAKU_JYOKYO_NM, Me.KEI_ADDR, Me.KEIYAKUSYA_NAME, Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox4})
        Me.GroupHeader3.DataField = "KEIYAKUSYA_CD"
        Me.GroupHeader3.Height = 0.575!
        Me.GroupHeader3.Name = "GroupHeader3"
        Me.GroupHeader3.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.Before
        Me.GroupHeader3.RepeatStyle = GrapeCity.ActiveReports.SectionReportModel.RepeatStyle.OnPage
        Me.GroupHeader3.UnderlayNext = True
        '
        'NYURYOKU_JYOKYO_NM
        '
        Me.NYURYOKU_JYOKYO_NM.DataField = "NYURYOKU_JYOKYO_NM"
        Me.NYURYOKU_JYOKYO_NM.Height = 0.3!
        Me.NYURYOKU_JYOKYO_NM.Left = 3.316536!
        Me.NYURYOKU_JYOKYO_NM.Name = "NYURYOKU_JYOKYO_NM"
        Me.NYURYOKU_JYOKYO_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "white-space: inherit"
        Me.NYURYOKU_JYOKYO_NM.Text = "入力確定"
        Me.NYURYOKU_JYOKYO_NM.Top = 0.02992126!
        Me.NYURYOKU_JYOKYO_NM.Width = 0.3330004!
        '
        'KEIYAKU_KBN_NM
        '
        Me.KEIYAKU_KBN_NM.DataField = "KEIYAKU_KBN_NM"
        Me.KEIYAKU_KBN_NM.Height = 0.2992126!
        Me.KEIYAKU_KBN_NM.Left = 3.700394!
        Me.KEIYAKU_KBN_NM.Name = "KEIYAKU_KBN_NM"
        Me.KEIYAKU_KBN_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "white-space: inherit"
        Me.KEIYAKU_KBN_NM.Text = "うずら"
        Me.KEIYAKU_KBN_NM.Top = 0.02007874!
        Me.KEIYAKU_KBN_NM.Width = 0.4133858!
        '
        'KEIYAKU_JYOKYO_NM
        '
        Me.KEIYAKU_JYOKYO_NM.DataField = "KEIYAKU_JYOKYO_NM"
        Me.KEIYAKU_JYOKYO_NM.Height = 0.3!
        Me.KEIYAKU_JYOKYO_NM.Left = 4.115748!
        Me.KEIYAKU_JYOKYO_NM.Name = "KEIYAKU_JYOKYO_NM"
        Me.KEIYAKU_JYOKYO_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "white-space: inherit"
        Me.KEIYAKU_JYOKYO_NM.Text = "新規加入者"
        Me.KEIYAKU_JYOKYO_NM.Top = 0.02001579!
        Me.KEIYAKU_JYOKYO_NM.Width = 0.447!
        '
        'KEI_ADDR
        '
        Me.KEI_ADDR.DataField = "KEI_ADDR"
        Me.KEI_ADDR.Height = 0.369!
        Me.KEI_ADDR.Left = 4.586!
        Me.KEI_ADDR.Name = "KEI_ADDR"
        Me.KEI_ADDR.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: left; vertical-align: middle; wh" &
    "ite-space: inherit"
        Me.KEI_ADDR.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.KEI_ADDR.Top = 0.02!
        Me.KEI_ADDR.Width = 2.871!
        '
        'KEIYAKUSYA_NAME
        '
        Me.KEIYAKUSYA_NAME.DataField = "KEIYAKUSYA_NAME"
        Me.KEIYAKUSYA_NAME.Height = 0.1496063!
        Me.KEIYAKUSYA_NAME.Left = 0.477!
        Me.KEIYAKUSYA_NAME.MultiLine = False
        Me.KEIYAKUSYA_NAME.Name = "KEIYAKUSYA_NAME"
        Me.KEIYAKUSYA_NAME.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.KEIYAKUSYA_NAME.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.KEIYAKUSYA_NAME.Top = 0.03!
        Me.KEIYAKUSYA_NAME.Width = 2.799!
        '
        'TextBox1
        '
        Me.TextBox1.DataField = "ADDR_TEL1"
        Me.TextBox1.Height = 0.1496063!
        Me.TextBox1.Left = 0.477!
        Me.TextBox1.MultiLine = False
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.TextBox1.Text = "123-456-7890"
        Me.TextBox1.Top = 0.389!
        Me.TextBox1.Width = 0.8309996!
        '
        'TextBox2
        '
        Me.TextBox2.DataField = "ADDR_TEL2"
        Me.TextBox2.Height = 0.1496063!
        Me.TextBox2.Left = 1.416!
        Me.TextBox2.MultiLine = False
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.TextBox2.Text = "123-456-7890"
        Me.TextBox2.Top = 0.389!
        Me.TextBox2.Width = 0.8309993!
        '
        'TextBox3
        '
        Me.TextBox3.DataField = "ADDR_FAX"
        Me.TextBox3.Height = 0.1496063!
        Me.TextBox3.Left = 2.355!
        Me.TextBox3.MultiLine = False
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.TextBox3.Text = "123-456-7890"
        Me.TextBox3.Top = 0.389!
        Me.TextBox3.Width = 0.8309993!
        '
        'TextBox4
        '
        Me.TextBox4.DataField = "ADDR_E_MAIL"
        Me.TextBox4.Height = 0.1496063!
        Me.TextBox4.Left = 4.615!
        Me.TextBox4.MultiLine = False
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.TextBox4.Text = "aaa@mail.com"
        Me.TextBox4.Top = 0.389!
        Me.TextBox4.Width = 2.779!
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label21, Me.KEI_KEIYAKU_HASU, Me.Line9, Me.Line10, Me.HasukeiBankInfo_Bank, Me.HasukeiRowCnt, Me.HasukeiBankInfo_Siten, Me.HasukeiBankInfo_Koza, Me.HasukeiBankInfo_Kana, Me.HasukeiBankInfo_Meigi, Me.HasukeiKeiyakuDate})
        Me.GroupFooter3.Height = 0.5869444!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'Label21
        '
        Me.Label21.Height = 0.2!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 7.509!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "ddo-char-set: 1"
        Me.Label21.Text = "羽数計"
        Me.Label21.Top = 0.027!
        Me.Label21.Width = 0.77!
        '
        'KEI_KEIYAKU_HASU
        '
        Me.KEI_KEIYAKU_HASU.DataField = "KEIYAKU_HASU"
        Me.KEI_KEIYAKU_HASU.Height = 0.2!
        Me.KEI_KEIYAKU_HASU.Left = 8.334002!
        Me.KEI_KEIYAKU_HASU.MultiLine = False
        Me.KEI_KEIYAKU_HASU.Name = "KEI_KEIYAKU_HASU"
        Me.KEI_KEIYAKU_HASU.OutputFormat = "#,##0"
        Me.KEI_KEIYAKU_HASU.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KEI_KEIYAKU_HASU.SummaryGroup = "GroupHeader3"
        Me.KEI_KEIYAKU_HASU.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.KEI_KEIYAKU_HASU.Text = "99,999,999"
        Me.KEI_KEIYAKU_HASU.Top = 0.02!
        Me.KEI_KEIYAKU_HASU.Width = 0.698!
        '
        'Line9
        '
        Me.Line9.Height = 0!
        Me.Line9.Left = 0!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.58!
        Me.Line9.Visible = False
        Me.Line9.Width = 13.42!
        Me.Line9.X1 = 0!
        Me.Line9.X2 = 13.42!
        Me.Line9.Y1 = 0.58!
        Me.Line9.Y2 = 0.58!
        '
        'Line10
        '
        Me.Line10.Height = 0!
        Me.Line10.Left = 0!
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 0.005!
        Me.Line10.Width = 13.42!
        Me.Line10.X1 = 0!
        Me.Line10.X2 = 13.42!
        Me.Line10.Y1 = 0.005!
        Me.Line10.Y2 = 0.005!
        '
        'HasukeiBankInfo_Bank
        '
        Me.HasukeiBankInfo_Bank.DataField = "BANK"
        Me.HasukeiBankInfo_Bank.Height = 0.1496063!
        Me.HasukeiBankInfo_Bank.Left = 0.477!
        Me.HasukeiBankInfo_Bank.MultiLine = False
        Me.HasukeiBankInfo_Bank.Name = "HasukeiBankInfo_Bank"
        Me.HasukeiBankInfo_Bank.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.HasukeiBankInfo_Bank.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.HasukeiBankInfo_Bank.Top = 0.03!
        Me.HasukeiBankInfo_Bank.Width = 2.779!
        '
        'HasukeiRowCnt
        '
        Me.HasukeiRowCnt.DataField = "ROW_CNT"
        Me.HasukeiRowCnt.Height = 0.1496063!
        Me.HasukeiRowCnt.Left = 0.031!
        Me.HasukeiRowCnt.MultiLine = False
        Me.HasukeiRowCnt.Name = "HasukeiRowCnt"
        Me.HasukeiRowCnt.Style = "background-color: Plum; font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify;" &
    " vertical-align: middle; white-space: nowrap"
        Me.HasukeiRowCnt.Text = "Ｎ"
        Me.HasukeiRowCnt.Top = 0.03!
        Me.HasukeiRowCnt.Visible = False
        Me.HasukeiRowCnt.Width = 0.3319998!
        '
        'HasukeiBankInfo_Siten
        '
        Me.HasukeiBankInfo_Siten.DataField = "SITEN"
        Me.HasukeiBankInfo_Siten.Height = 0.1496063!
        Me.HasukeiBankInfo_Siten.Left = 0.477!
        Me.HasukeiBankInfo_Siten.MultiLine = False
        Me.HasukeiBankInfo_Siten.Name = "HasukeiBankInfo_Siten"
        Me.HasukeiBankInfo_Siten.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.HasukeiBankInfo_Siten.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.HasukeiBankInfo_Siten.Top = 0.22!
        Me.HasukeiBankInfo_Siten.Width = 2.779!
        '
        'HasukeiBankInfo_Koza
        '
        Me.HasukeiBankInfo_Koza.DataField = "KOZA"
        Me.HasukeiBankInfo_Koza.Height = 0.1496063!
        Me.HasukeiBankInfo_Koza.Left = 4.615!
        Me.HasukeiBankInfo_Koza.MultiLine = False
        Me.HasukeiBankInfo_Koza.Name = "HasukeiBankInfo_Koza"
        Me.HasukeiBankInfo_Koza.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.HasukeiBankInfo_Koza.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.HasukeiBankInfo_Koza.Top = 0.03!
        Me.HasukeiBankInfo_Koza.Width = 2.779!
        '
        'HasukeiBankInfo_Kana
        '
        Me.HasukeiBankInfo_Kana.DataField = "FURI_KOZA_MEIGI_KANA"
        Me.HasukeiBankInfo_Kana.Height = 0.1496063!
        Me.HasukeiBankInfo_Kana.Left = 4.615!
        Me.HasukeiBankInfo_Kana.MultiLine = False
        Me.HasukeiBankInfo_Kana.Name = "HasukeiBankInfo_Kana"
        Me.HasukeiBankInfo_Kana.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.HasukeiBankInfo_Kana.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.HasukeiBankInfo_Kana.Top = 0.22!
        Me.HasukeiBankInfo_Kana.Width = 2.779!
        '
        'HasukeiBankInfo_Meigi
        '
        Me.HasukeiBankInfo_Meigi.DataField = "FURI_KOZA_MEIGI"
        Me.HasukeiBankInfo_Meigi.Height = 0.1496063!
        Me.HasukeiBankInfo_Meigi.Left = 4.615!
        Me.HasukeiBankInfo_Meigi.MultiLine = False
        Me.HasukeiBankInfo_Meigi.Name = "HasukeiBankInfo_Meigi"
        Me.HasukeiBankInfo_Meigi.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.HasukeiBankInfo_Meigi.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.HasukeiBankInfo_Meigi.Top = 0.41!
        Me.HasukeiBankInfo_Meigi.Width = 2.779!
        '
        'HasukeiKeiyakuDate
        '
        Me.HasukeiKeiyakuDate.DataField = "KEIYAKU_DATE"
        Me.HasukeiKeiyakuDate.Height = 0.118!
        Me.HasukeiKeiyakuDate.Left = 0.4770002!
        Me.HasukeiKeiyakuDate.Name = "HasukeiKeiyakuDate"
        Me.HasukeiKeiyakuDate.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: left; vertical-align: middle; wh" &
    "ite-space: nowrap"
        Me.HasukeiKeiyakuDate.Text = "1234/56/78"
        Me.HasukeiKeiyakuDate.Top = 0.41!
        Me.HasukeiKeiyakuDate.Width = 1.11!
        '
        'rptGJ1040
        '
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 13.53049!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.GroupHeader3)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter3)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " &
            "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.TAISYO_KI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SAKUSEIBI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCurrentPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNendo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USER_NAME_HED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NYURYOKU_KIKAN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKU_HASU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TORI_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NOJO_ADDR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NOJO_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REG_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REG_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UP_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UP_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailBankInfo_Bank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailBankInfo_Siten, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailBankInfo_Koza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailBankInfo_Kana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailBankInfo_Meigi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailRowNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailKeiyakuDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DAIHYO_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SIKEI_KEIYAKU_HASU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SOKEI_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NYURYOKU_JYOKYO_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKU_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKU_JYOKYO_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEI_ADDR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEI_KEIYAKU_HASU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HasukeiBankInfo_Bank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HasukeiRowCnt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HasukeiBankInfo_Siten, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HasukeiBankInfo_Koza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HasukeiBankInfo_Kana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HasukeiBankInfo_Meigi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HasukeiKeiyakuDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents Line2 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Label19 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents ReportHeader1 As GrapeCity.ActiveReports.SectionReportModel.ReportHeader
    Private WithEvents ReportFooter1 As GrapeCity.ActiveReports.SectionReportModel.ReportFooter
    Private WithEvents KEIYAKUSYA_CD As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEIYAKU_HASU As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents GroupHeader1 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter1 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents SIKEI_KEIYAKU_HASU As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line8 As GrapeCity.ActiveReports.SectionReportModel.Line
    Public WithEvents GroupHeader2 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Public WithEvents GroupFooter2 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents Label36 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label37 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents SAKUSEIBI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label38 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txtCurrentPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label41 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label42 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label46 As GrapeCity.ActiveReports.SectionReportModel.Label
    Public WithEvents TAISYO_KI As GrapeCity.ActiveReports.SectionReportModel.Label
    Public WithEvents lblNo As GrapeCity.ActiveReports.SectionReportModel.Label
    Public WithEvents lblNm As GrapeCity.ActiveReports.SectionReportModel.Label
    Public WithEvents lblNendo1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Public WithEvents USER_NAME_HED As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents CrossSectionBox1 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionBox
    Private WithEvents Line1 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents CrossSectionLine1 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine3 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine4 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine5 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine6 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents Line5 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line7 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label21 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Line9 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line10 As GrapeCity.ActiveReports.SectionReportModel.Line
    Public WithEvents GroupHeader3 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Public WithEvents GroupFooter3 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents DAIHYO_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label6 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents NYURYOKU_KIKAN As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label4 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label5 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label7 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label8 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label9 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label10 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents CrossSectionLine2 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents TORI_KBN_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line4 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line3 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents NYURYOKU_JYOKYO_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEIYAKU_KBN_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEIYAKU_JYOKYO_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEI_KEIYAKU_HASU As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents CrossSectionLine7 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine8 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents KEI_ADDR As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEIYAKUSYA_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label13 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents CrossSectionLine9 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents Label14 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label15 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label16 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label17 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents NOJO_ADDR As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents NOJO_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents REG_DATE As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents REG_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label20 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents SOKEI_KEIYAKUSYA_CD As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label18 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents UP_DATE As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents UP_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label22 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents DetailBankInfo_Bank As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents HasukeiBankInfo_Bank As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents HasukeiRowCnt As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents DetailBankInfo_Siten As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents DetailBankInfo_Koza As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents DetailBankInfo_Kana As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents DetailBankInfo_Meigi As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents HasukeiBankInfo_Siten As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents HasukeiBankInfo_Koza As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents HasukeiBankInfo_Kana As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents HasukeiBankInfo_Meigi As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents DetailRowNum As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label23 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox3 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label11 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label12 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label24 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox4 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents DetailKeiyakuDate As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents HasukeiKeiyakuDate As GrapeCity.ActiveReports.SectionReportModel.TextBox
End Class
