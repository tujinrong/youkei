<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class rptGJ4020
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptGJ4020))
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
        Me.CrossSectionBox1 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionBox()
        Me.CrossSectionLine1 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine3 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine4 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine5 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label6 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label4 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label5 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label7 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label10 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionLine2 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine7 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.Label11 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label12 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label13 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionLine9 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.Line7 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label8 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label9 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label14 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label15 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label16 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txtGroupPage = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label24 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label25 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionLine6 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine10 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine11 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.KOFU_RITU = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.KOFU_RITU_CNT = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label52 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.GOJOKIN_SYURUI_KBN_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKU_HASU = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line5 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.TORI_KBN_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line2 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.NOJO_ADDR = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.NOJO_CD_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.SYORI_JOKYO_KBN_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.SEI_TUMITATE_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KUNI_KOFU_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.SANTEI_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KOFU_TANKA = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KOFU_HASU = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.DTL_CNT = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KOFU_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GENGAKU_RITU = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label27 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label26 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.KEIYAKUSYA_CD = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ITAKU_RYAKU_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
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
        Me.Line8 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Label20 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.SOKEI_KEIYAKUSYA_CD = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label18 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Line3 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Label17 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label22 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label23 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.SANTEI_KIN_1_SOKEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.SANTEI_KIN_2_SOKEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.SANTEI_KIN_SOKEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line6 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.SEI_TUMITATE_KIN_1_SOKEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KUNI_KOFU_KIN_1_SOKEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.SEI_TUMITATE_KIN_2_SOKEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KUNI_KOFU_KIN_2_SOKEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line11 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.SEI_TUMITATE_KIN_SOKEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KUNI_KOFU_KIN_SOKEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KOFU_KIN_1_SOKEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KOFU_KIN_2_SOKEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KOFU_KIN_SOKEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupHeader3 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.KEIYAKU_KBN_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKUSYA_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line12 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.GroupFooter3 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.Label21 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Line9 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line10 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.SANTEI_KIN_KEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.SEI_TUMITATE_KIN_KEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KUNI_KOFU_KIN_KEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KOFU_KIN_KEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
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
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGroupPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KOFU_RITU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KOFU_RITU_CNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GOJOKIN_SYURUI_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKU_HASU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TORI_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NOJO_ADDR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NOJO_CD_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SYORI_JOKYO_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEI_TUMITATE_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KUNI_KOFU_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SANTEI_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KOFU_TANKA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KOFU_HASU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTL_CNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KOFU_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GENGAKU_RITU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ITAKU_RYAKU_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SOKEI_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SANTEI_KIN_1_SOKEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SANTEI_KIN_2_SOKEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SANTEI_KIN_SOKEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEI_TUMITATE_KIN_1_SOKEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KUNI_KOFU_KIN_1_SOKEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEI_TUMITATE_KIN_2_SOKEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KUNI_KOFU_KIN_2_SOKEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEI_TUMITATE_KIN_SOKEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KUNI_KOFU_KIN_SOKEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KOFU_KIN_1_SOKEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KOFU_KIN_2_SOKEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KOFU_KIN_SOKEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKU_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SANTEI_KIN_KEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEI_TUMITATE_KIN_KEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KUNI_KOFU_KIN_KEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KOFU_KIN_KEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Shape1, Me.TAISYO_KI, Me.Label36, Me.Label37, Me.SAKUSEIBI, Me.Label38, Me.txtCurrentPage, Me.lblNo, Me.Label41, Me.Label42, Me.lblNm, Me.lblNendo1, Me.Label46, Me.CrossSectionBox1, Me.CrossSectionLine1, Me.CrossSectionLine3, Me.CrossSectionLine4, Me.CrossSectionLine5, Me.Label2, Me.Label6, Me.Label4, Me.Label5, Me.Label7, Me.Label10, Me.CrossSectionLine2, Me.CrossSectionLine7, Me.Label11, Me.Label12, Me.Label13, Me.CrossSectionLine9, Me.Line7, Me.Label3, Me.Label8, Me.Label9, Me.Label14, Me.Label15, Me.Label16, Me.txtGroupPage, Me.Label24, Me.Label25, Me.CrossSectionLine6, Me.CrossSectionLine10, Me.CrossSectionLine11, Me.KOFU_RITU, Me.KOFU_RITU_CNT, Me.Label52})
        Me.PageHeader.Height = 1.365212!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Shape1.Height = 0.5252676!
        Me.Shape1.Left = 0.02!
        Me.Shape1.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.Shape1.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Transparent
        Me.Shape1.LineWeight = 0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = New GrapeCity.ActiveReports.Controls.CornersRadius(9.999999!, Nothing, Nothing, Nothing, Nothing)
        Me.Shape1.Top = 0.8330001!
        Me.Shape1.Width = 13.40158!
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
        Me.TAISYO_KI.Top = 0.253!
        Me.TAISYO_KI.Width = 13.42!
        '
        'Label36
        '
        Me.Label36.Height = 0.1968504!
        Me.Label36.HyperLink = Nothing
        Me.Label36.Left = 0!
        Me.Label36.Name = "Label36"
        Me.Label36.Style = "font-family: ＭＳ Ｐゴシック; font-size: 14pt; font-weight: normal; text-align: center"
        Me.Label36.Text = "<<　互助金申請情報入力チェックリスト（農場・互助種類・鶏の種類別）　>>"
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
        Me.Label41.Left = 12.18898!
        Me.Label41.Name = "Label41"
        Me.Label41.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; ddo-char-set: 1"
        Me.Label41.Text = "（単位：人、羽、円）"
        Me.Label41.Top = 0.654!
        Me.Label41.Width = 1.230973!
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
        Me.lblNm.Height = 0.2180001!
        Me.lblNm.HyperLink = Nothing
        Me.lblNm.Left = 0.456!
        Me.lblNm.MultiLine = False
        Me.lblNm.Name = "lblNm"
        Me.lblNm.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.lblNm.Text = "契約者名"
        Me.lblNm.Top = 0.874!
        Me.lblNm.Width = 2.696!
        '
        'lblNendo1
        '
        Me.lblNendo1.Height = 0.218!
        Me.lblNendo1.HyperLink = Nothing
        Me.lblNendo1.Left = 3.836!
        Me.lblNendo1.MultiLine = False
        Me.lblNendo1.Name = "lblNendo1"
        Me.lblNendo1.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.lblNendo1.Text = "入力"
        Me.lblNendo1.Top = 0.874!
        Me.lblNendo1.Width = 0.4268432!
        '
        'Label46
        '
        Me.Label46.Height = 0.2190001!
        Me.Label46.HyperLink = Nothing
        Me.Label46.Left = 3.836!
        Me.Label46.MultiLine = False
        Me.Label46.Name = "Label46"
        Me.Label46.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label46.Text = "状況"
        Me.Label46.Top = 1.139!
        Me.Label46.Width = 0.4268432!
        '
        'CrossSectionBox1
        '
        Me.CrossSectionBox1.Bottom = 0!
        Me.CrossSectionBox1.Left = 0!
        Me.CrossSectionBox1.LineWeight = 3.0!
        Me.CrossSectionBox1.Name = "CrossSectionBox1"
        Me.CrossSectionBox1.Radius = New GrapeCity.ActiveReports.Controls.CornersRadius(0!, Nothing, Nothing, Nothing, Nothing)
        Me.CrossSectionBox1.Right = 13.437!
        Me.CrossSectionBox1.Top = 0.833!
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
        Me.CrossSectionLine3.Left = 3.152!
        Me.CrossSectionLine3.LineWeight = 1.0!
        Me.CrossSectionLine3.Name = "CrossSectionLine3"
        Me.CrossSectionLine3.Top = 0.8420001!
        '
        'CrossSectionLine4
        '
        Me.CrossSectionLine4.Bottom = 1.421085E-14!
        Me.CrossSectionLine4.Left = 3.763!
        Me.CrossSectionLine4.LineWeight = 1.0!
        Me.CrossSectionLine4.Name = "CrossSectionLine4"
        Me.CrossSectionLine4.Top = 0.8420001!
        '
        'CrossSectionLine5
        '
        Me.CrossSectionLine5.Bottom = 0!
        Me.CrossSectionLine5.Left = 4.326!
        Me.CrossSectionLine5.LineWeight = 1.0!
        Me.CrossSectionLine5.Name = "CrossSectionLine5"
        Me.CrossSectionLine5.Top = 0.8330001!
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
        'Label4
        '
        Me.Label4.Height = 0.2180001!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.4559056!
        Me.Label4.MultiLine = False
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label4.Text = "（都道府県）事務委託先名"
        Me.Label4.Top = 1.094095!
        Me.Label4.Width = 2.696095!
        '
        'Label5
        '
        Me.Label5.Height = 0.2179999!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 3.286!
        Me.Label5.MultiLine = False
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label5.Text = "契約"
        Me.Label5.Top = 0.905!
        Me.Label5.Width = 0.3327484!
        '
        'Label7
        '
        Me.Label7.Height = 0.2190001!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 3.286!
        Me.Label7.MultiLine = False
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label7.Text = "区分"
        Me.Label7.Top = 1.109!
        Me.Label7.Width = 0.3327484!
        '
        'Label10
        '
        Me.Label10.Height = 0.2179999!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 8.554001!
        Me.Label10.MultiLine = False
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label10.Text = "鶏の種類"
        Me.Label10.Top = 0.8890001!
        Me.Label10.Width = 0.919292!
        '
        'CrossSectionLine2
        '
        Me.CrossSectionLine2.Bottom = 0.0008741021!
        Me.CrossSectionLine2.Left = 8.486!
        Me.CrossSectionLine2.LineWeight = 1.0!
        Me.CrossSectionLine2.Name = "CrossSectionLine2"
        Me.CrossSectionLine2.Top = 0.8430002!
        '
        'CrossSectionLine7
        '
        Me.CrossSectionLine7.Bottom = 0.0008740421!
        Me.CrossSectionLine7.Left = 9.517!
        Me.CrossSectionLine7.LineWeight = 1.0!
        Me.CrossSectionLine7.Name = "CrossSectionLine7"
        Me.CrossSectionLine7.Top = 0.8330002!
        '
        'Label11
        '
        Me.Label11.Height = 0.2179999!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 4.395!
        Me.Label11.MultiLine = False
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label11.Text = "（農場コード）農場名"
        Me.Label11.Top = 0.891!
        Me.Label11.Width = 3.923001!
        '
        'Label12
        '
        Me.Label12.Height = 0.2179999!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 4.395!
        Me.Label12.MultiLine = False
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label12.Text = "農場所在地"
        Me.Label12.Top = 1.107!
        Me.Label12.Width = 3.923001!
        '
        'Label13
        '
        Me.Label13.Height = 0.2179999!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 9.567!
        Me.Label13.MultiLine = False
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label13.Text = "契約羽数"
        Me.Label13.Top = 0.886!
        Me.Label13.Width = 0.6979995!
        '
        'CrossSectionLine9
        '
        Me.CrossSectionLine9.Bottom = 0.0008741613!
        Me.CrossSectionLine9.Left = 10.305!
        Me.CrossSectionLine9.LineWeight = 1.0!
        Me.CrossSectionLine9.Name = "CrossSectionLine9"
        Me.CrossSectionLine9.Top = 0.8430002!
        '
        'Line7
        '
        Me.Line7.Height = 0!
        Me.Line7.Left = 0!
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 1.358268!
        Me.Line7.Width = 13.42126!
        Me.Line7.X1 = 0!
        Me.Line7.X2 = 13.42126!
        Me.Line7.Y1 = 1.358268!
        Me.Line7.Y2 = 1.358268!
        '
        'Label3
        '
        Me.Label3.Height = 0.2179999!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 8.554001!
        Me.Label3.MultiLine = False
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label3.Text = "互助金の種類"
        Me.Label3.Top = 1.109!
        Me.Label3.Width = 0.919292!
        '
        'Label8
        '
        Me.Label8.Height = 0.2179999!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 9.567!
        Me.Label8.MultiLine = False
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label8.Text = "対象羽数"
        Me.Label8.Top = 1.095843!
        Me.Label8.Width = 0.6979995!
        '
        'Label9
        '
        Me.Label9.Height = 0.2179999!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 12.4252!
        Me.Label9.MultiLine = False
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label9.Text = "積立金部分"
        Me.Label9.Top = 0.8759843!
        Me.Label9.Width = 0.9374018!
        '
        'Label14
        '
        Me.Label14.Height = 0.2179999!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 12.4252!
        Me.Label14.MultiLine = False
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label14.Text = "国庫交付額"
        Me.Label14.Top = 1.085827!
        Me.Label14.Width = 0.9374018!
        '
        'Label15
        '
        Me.Label15.Height = 0.2179999!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 10.317!
        Me.Label15.MultiLine = False
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label15.Text = "互助金算定額"
        Me.Label15.Top = 0.876!
        Me.Label15.Width = 0.9893703!
        '
        'Label16
        '
        Me.Label16.Height = 0.2179999!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 10.317!
        Me.Label16.MultiLine = False
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label16.Text = "（単価）"
        Me.Label16.Top = 1.094!
        Me.Label16.Width = 0.9893703!
        '
        'txtGroupPage
        '
        Me.txtGroupPage.Height = 0.1574803!
        Me.txtGroupPage.Left = 2.593701!
        Me.txtGroupPage.Name = "txtGroupPage"
        Me.txtGroupPage.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; ddo-char-set: 1"
        Me.txtGroupPage.SummaryGroup = "GroupHeader2"
        Me.txtGroupPage.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.txtGroupPage.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.txtGroupPage.Text = "Z,ZZ9"
        Me.txtGroupPage.Top = 0.2531496!
        Me.txtGroupPage.Visible = False
        Me.txtGroupPage.Width = 0.402441!
        '
        'Label24
        '
        Me.Label24.Height = 0.2179999!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 11.312!
        Me.Label24.MultiLine = False
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label24.Text = "互助金減額後"
        Me.Label24.Top = 0.876!
        Me.Label24.Width = 0.9893701!
        '
        'Label25
        '
        Me.Label25.Height = 0.2179999!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 11.312!
        Me.Label25.MultiLine = False
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" &
    "e; white-space: nowrap; ddo-char-set: 1"
        Me.Label25.Text = "（減額率）"
        Me.Label25.Top = 1.092!
        Me.Label25.Width = 0.9893701!
        '
        'CrossSectionLine6
        '
        Me.CrossSectionLine6.Bottom = 0.0008741019!
        Me.CrossSectionLine6.Left = 11.317!
        Me.CrossSectionLine6.LineWeight = 1.0!
        Me.CrossSectionLine6.Name = "CrossSectionLine6"
        Me.CrossSectionLine6.Top = 0.8430001!
        '
        'CrossSectionLine10
        '
        Me.CrossSectionLine10.Bottom = 0!
        Me.CrossSectionLine10.Left = 0!
        Me.CrossSectionLine10.LineWeight = 1.0!
        Me.CrossSectionLine10.Name = "CrossSectionLine10"
        Me.CrossSectionLine10.Top = 0.8430002!
        '
        'CrossSectionLine11
        '
        Me.CrossSectionLine11.Bottom = 0!
        Me.CrossSectionLine11.Left = 12.312!
        Me.CrossSectionLine11.LineWeight = 1.0!
        Me.CrossSectionLine11.Name = "CrossSectionLine11"
        Me.CrossSectionLine11.Top = 0.8430001!
        '
        'KOFU_RITU
        '
        Me.KOFU_RITU.DataField = "KOFU_RITU"
        Me.KOFU_RITU.Height = 0.166!
        Me.KOFU_RITU.HyperLink = Nothing
        Me.KOFU_RITU.Left = 6.798!
        Me.KOFU_RITU.Name = "KOFU_RITU"
        Me.KOFU_RITU.Style = "font-family: ＭＳ Ｐゴシック; font-size: 11pt; text-align: left; vertical-align: top; dd" &
    "o-char-set: 1"
        Me.KOFU_RITU.Text = "999.999999％"
        Me.KOFU_RITU.Top = 0.488!
        Me.KOFU_RITU.Width = 0.9689997!
        '
        'KOFU_RITU_CNT
        '
        Me.KOFU_RITU_CNT.DataField = "KOFU_RITU_CNT"
        Me.KOFU_RITU_CNT.Height = 0.1574803!
        Me.KOFU_RITU_CNT.Left = 2.594!
        Me.KOFU_RITU_CNT.Name = "KOFU_RITU_CNT"
        Me.KOFU_RITU_CNT.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; ddo-char-set: 1"
        Me.KOFU_RITU_CNT.SummaryGroup = "GroupHeader2"
        Me.KOFU_RITU_CNT.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.KOFU_RITU_CNT.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.KOFU_RITU_CNT.Text = "9999"
        Me.KOFU_RITU_CNT.Top = 0.497!
        Me.KOFU_RITU_CNT.Visible = False
        Me.KOFU_RITU_CNT.Width = 0.402441!
        '
        'Label52
        '
        Me.Label52.Height = 0.166!
        Me.Label52.HyperLink = Nothing
        Me.Label52.Left = 5.707!
        Me.Label52.Name = "Label52"
        Me.Label52.Style = "font-family: ＭＳ Ｐゴシック; font-size: 11pt; text-align: left; ddo-char-set: 1"
        Me.Label52.Text = "互助金交付率："
        Me.Label52.Top = 0.488!
        Me.Label52.Width = 1.091!
        '
        'Detail
        '
        Me.Detail.CanGrow = False
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.GOJOKIN_SYURUI_KBN_NM, Me.KEIYAKU_HASU, Me.Line5, Me.TORI_KBN_NM, Me.Line2, Me.NOJO_ADDR, Me.NOJO_CD_NM, Me.SYORI_JOKYO_KBN_NM, Me.SEI_TUMITATE_KIN, Me.KUNI_KOFU_KIN, Me.SANTEI_KIN, Me.KOFU_TANKA, Me.KOFU_HASU, Me.DTL_CNT, Me.KOFU_KIN, Me.GENGAKU_RITU, Me.Label27, Me.Label26})
        Me.Detail.Height = 0.472441!
        Me.Detail.Name = "Detail"
        '
        'GOJOKIN_SYURUI_KBN_NM
        '
        Me.GOJOKIN_SYURUI_KBN_NM.DataField = "GOJOKIN_SYURUI_KBN_NM"
        Me.GOJOKIN_SYURUI_KBN_NM.Height = 0.2!
        Me.GOJOKIN_SYURUI_KBN_NM.Left = 8.602!
        Me.GOJOKIN_SYURUI_KBN_NM.Name = "GOJOKIN_SYURUI_KBN_NM"
        Me.GOJOKIN_SYURUI_KBN_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "white-space: inherit"
        Me.GOJOKIN_SYURUI_KBN_NM.Text = "（焼却・埋却）"
        Me.GOJOKIN_SYURUI_KBN_NM.Top = 0.231!
        Me.GOJOKIN_SYURUI_KBN_NM.Width = 0.8248029!
        '
        'KEIYAKU_HASU
        '
        Me.KEIYAKU_HASU.DataField = "KEIYAKU_HASU"
        Me.KEIYAKU_HASU.Height = 0.2!
        Me.KEIYAKU_HASU.Left = 9.549001!
        Me.KEIYAKU_HASU.MultiLine = False
        Me.KEIYAKU_HASU.Name = "KEIYAKU_HASU"
        Me.KEIYAKU_HASU.OutputFormat = resources.GetString("KEIYAKU_HASU.OutputFormat")
        Me.KEIYAKU_HASU.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KEIYAKU_HASU.Text = "99,999,999"
        Me.KEIYAKU_HASU.Top = 0.04!
        Me.KEIYAKU_HASU.Width = 0.698!
        '
        'Line5
        '
        Me.Line5.AnchorBottom = True
        Me.Line5.Height = 0!
        Me.Line5.Left = 3.763!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.433!
        Me.Line5.Visible = False
        Me.Line5.Width = 9.65708!
        Me.Line5.X1 = 3.763!
        Me.Line5.X2 = 13.42008!
        Me.Line5.Y1 = 0.433!
        Me.Line5.Y2 = 0.433!
        '
        'TORI_KBN_NM
        '
        Me.TORI_KBN_NM.DataField = "TORI_KBN_NM"
        Me.TORI_KBN_NM.Height = 0.2!
        Me.TORI_KBN_NM.Left = 8.602!
        Me.TORI_KBN_NM.Name = "TORI_KBN_NM"
        Me.TORI_KBN_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "white-space: inherit"
        Me.TORI_KBN_NM.Text = "採卵鶏(成鶏)"
        Me.TORI_KBN_NM.Top = 0.031!
        Me.TORI_KBN_NM.Width = 0.8248591!
        '
        'Line2
        '
        Me.Line2.Height = 0.0007875264!
        Me.Line2.Left = 3.763!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0!
        Me.Line2.Width = 9.657!
        Me.Line2.X1 = 3.763!
        Me.Line2.X2 = 13.42!
        Me.Line2.Y1 = 0!
        Me.Line2.Y2 = 0.0007875264!
        '
        'NOJO_ADDR
        '
        Me.NOJO_ADDR.DataField = "NOJO_ADDR"
        Me.NOJO_ADDR.Height = 0.2!
        Me.NOJO_ADDR.Left = 4.395!
        Me.NOJO_ADDR.MultiLine = False
        Me.NOJO_ADDR.Name = "NOJO_ADDR"
        Me.NOJO_ADDR.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: left; text-justify: auto; vertic" &
    "al-align: middle; white-space: inherit"
        Me.NOJO_ADDR.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.NOJO_ADDR.Top = 0.231!
        Me.NOJO_ADDR.Width = 4.069!
        '
        'NOJO_CD_NM
        '
        Me.NOJO_CD_NM.DataField = "NOJO_CD_NM"
        Me.NOJO_CD_NM.Height = 0.2007874!
        Me.NOJO_CD_NM.Left = 4.395!
        Me.NOJO_CD_NM.MultiLine = False
        Me.NOJO_CD_NM.Name = "NOJO_CD_NM"
        Me.NOJO_CD_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: left; vertical-align: middle; wh" &
    "ite-space: inherit"
        Me.NOJO_CD_NM.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.NOJO_CD_NM.Top = 0.029!
        Me.NOJO_CD_NM.Width = 4.069001!
        '
        'SYORI_JOKYO_KBN_NM
        '
        Me.SYORI_JOKYO_KBN_NM.DataField = "SYORI_JOKYO_KBN_NM"
        Me.SYORI_JOKYO_KBN_NM.Height = 0.3905512!
        Me.SYORI_JOKYO_KBN_NM.Left = 3.836!
        Me.SYORI_JOKYO_KBN_NM.Name = "SYORI_JOKYO_KBN_NM"
        Me.SYORI_JOKYO_KBN_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "white-space: inherit"
        Me.SYORI_JOKYO_KBN_NM.Text = "交付金計算済"
        Me.SYORI_JOKYO_KBN_NM.Top = 0.04!
        Me.SYORI_JOKYO_KBN_NM.Width = 0.4267716!
        '
        'SEI_TUMITATE_KIN
        '
        Me.SEI_TUMITATE_KIN.DataField = "SEI_TUMITATE_KIN"
        Me.SEI_TUMITATE_KIN.Height = 0.2!
        Me.SEI_TUMITATE_KIN.Left = 12.4252!
        Me.SEI_TUMITATE_KIN.MultiLine = False
        Me.SEI_TUMITATE_KIN.Name = "SEI_TUMITATE_KIN"
        Me.SEI_TUMITATE_KIN.OutputFormat = resources.GetString("SEI_TUMITATE_KIN.OutputFormat")
        Me.SEI_TUMITATE_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.SEI_TUMITATE_KIN.Text = "99,999,999,999"
        Me.SEI_TUMITATE_KIN.Top = 0.02992126!
        Me.SEI_TUMITATE_KIN.Width = 0.9373703!
        '
        'KUNI_KOFU_KIN
        '
        Me.KUNI_KOFU_KIN.DataField = "KUNI_KOFU_KIN"
        Me.KUNI_KOFU_KIN.Height = 0.2!
        Me.KUNI_KOFU_KIN.Left = 12.425!
        Me.KUNI_KOFU_KIN.MultiLine = False
        Me.KUNI_KOFU_KIN.Name = "KUNI_KOFU_KIN"
        Me.KUNI_KOFU_KIN.OutputFormat = resources.GetString("KUNI_KOFU_KIN.OutputFormat")
        Me.KUNI_KOFU_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KUNI_KOFU_KIN.Text = "99,999,999,999"
        Me.KUNI_KOFU_KIN.Top = 0.25!
        Me.KUNI_KOFU_KIN.Width = 0.9373701!
        '
        'SANTEI_KIN
        '
        Me.SANTEI_KIN.DataField = "SANTEI_KIN"
        Me.SANTEI_KIN.Height = 0.2!
        Me.SANTEI_KIN.Left = 10.335!
        Me.SANTEI_KIN.MultiLine = False
        Me.SANTEI_KIN.Name = "SANTEI_KIN"
        Me.SANTEI_KIN.OutputFormat = resources.GetString("SANTEI_KIN.OutputFormat")
        Me.SANTEI_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.SANTEI_KIN.Text = "99,999,999,999"
        Me.SANTEI_KIN.Top = 0.03!
        Me.SANTEI_KIN.Width = 0.9373701!
        '
        'KOFU_TANKA
        '
        Me.KOFU_TANKA.DataField = "KOFU_TANKA"
        Me.KOFU_TANKA.Height = 0.2!
        Me.KOFU_TANKA.Left = 10.335!
        Me.KOFU_TANKA.MultiLine = False
        Me.KOFU_TANKA.Name = "KOFU_TANKA"
        Me.KOFU_TANKA.OutputFormat = resources.GetString("KOFU_TANKA.OutputFormat")
        Me.KOFU_TANKA.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "white-space: nowrap"
        Me.KOFU_TANKA.Text = "99,999,999,999"
        Me.KOFU_TANKA.Top = 0.250063!
        Me.KOFU_TANKA.Width = 0.9373701!
        '
        'KOFU_HASU
        '
        Me.KOFU_HASU.DataField = "KOFU_HASU"
        Me.KOFU_HASU.Height = 0.2!
        Me.KOFU_HASU.Left = 9.549001!
        Me.KOFU_HASU.MultiLine = False
        Me.KOFU_HASU.Name = "KOFU_HASU"
        Me.KOFU_HASU.OutputFormat = resources.GetString("KOFU_HASU.OutputFormat")
        Me.KOFU_HASU.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KOFU_HASU.Text = "99,999,999"
        Me.KOFU_HASU.Top = 0.2502362!
        Me.KOFU_HASU.Width = 0.698!
        '
        'DTL_CNT
        '
        Me.DTL_CNT.DataField = "DTL_CNT"
        Me.DTL_CNT.Height = 0.2007874!
        Me.DTL_CNT.Left = 0.4771654!
        Me.DTL_CNT.MultiLine = False
        Me.DTL_CNT.Name = "DTL_CNT"
        Me.DTL_CNT.Style = "color: Red; font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-alig" &
    "n: middle; white-space: nowrap"
        Me.DTL_CNT.Text = "99999"
        Me.DTL_CNT.Top = 0.04015748!
        Me.DTL_CNT.Visible = False
        Me.DTL_CNT.Width = 0.3818898!
        '
        'KOFU_KIN
        '
        Me.KOFU_KIN.DataField = "KOFU_KIN"
        Me.KOFU_KIN.Height = 0.2!
        Me.KOFU_KIN.Left = 11.347!
        Me.KOFU_KIN.MultiLine = False
        Me.KOFU_KIN.Name = "KOFU_KIN"
        Me.KOFU_KIN.OutputFormat = resources.GetString("KOFU_KIN.OutputFormat")
        Me.KOFU_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KOFU_KIN.Text = "99,999,999,999"
        Me.KOFU_KIN.Top = 0.031!
        Me.KOFU_KIN.Width = 0.9373701!
        '
        'GENGAKU_RITU
        '
        Me.GENGAKU_RITU.DataField = "GENGAKU_RITU"
        Me.GENGAKU_RITU.Height = 0.2!
        Me.GENGAKU_RITU.Left = 11.704!
        Me.GENGAKU_RITU.MultiLine = False
        Me.GENGAKU_RITU.Name = "GENGAKU_RITU"
        Me.GENGAKU_RITU.OutputFormat = resources.GetString("GENGAKU_RITU.OutputFormat")
        Me.GENGAKU_RITU.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.GENGAKU_RITU.Text = "999"
        Me.GENGAKU_RITU.Top = 0.25!
        Me.GENGAKU_RITU.Width = 0.2919996!
        '
        'Label27
        '
        Me.Label27.Height = 0.2!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 11.996!
        Me.Label27.Name = "Label27"
        Me.Label27.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: left; vertical-align: middle; dd" &
    "o-char-set: 1"
        Me.Label27.Text = "%）"
        Me.Label27.Top = 0.25!
        Me.Label27.Width = 0.2360002!
        '
        'Label26
        '
        Me.Label26.Height = 0.2!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 11.561!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "ddo-char-set: 1"
        Me.Label26.Text = "（"
        Me.Label26.Top = 0.25!
        Me.Label26.Width = 0.1432501!
        '
        'KEIYAKUSYA_CD
        '
        Me.KEIYAKUSYA_CD.DataField = "KEIYAKUSYA_CD"
        Me.KEIYAKUSYA_CD.Height = 0.2007874!
        Me.KEIYAKUSYA_CD.Left = 0.031!
        Me.KEIYAKUSYA_CD.MultiLine = False
        Me.KEIYAKUSYA_CD.Name = "KEIYAKUSYA_CD"
        Me.KEIYAKUSYA_CD.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KEIYAKUSYA_CD.Text = "99999"
        Me.KEIYAKUSYA_CD.Top = 0.03!
        Me.KEIYAKUSYA_CD.Width = 0.3818898!
        '
        'ITAKU_RYAKU_NM
        '
        Me.ITAKU_RYAKU_NM.DataField = "ITAKU_RYAKU_NM"
        Me.ITAKU_RYAKU_NM.Height = 0.2007874!
        Me.ITAKU_RYAKU_NM.Left = 0.4771654!
        Me.ITAKU_RYAKU_NM.MultiLine = False
        Me.ITAKU_RYAKU_NM.Name = "ITAKU_RYAKU_NM"
        Me.ITAKU_RYAKU_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.ITAKU_RYAKU_NM.Text = "(北海道)あいうえおかきくけこさしすせそたちつてとなにぬねの"
        Me.ITAKU_RYAKU_NM.Top = 0.2314961!
        Me.ITAKU_RYAKU_NM.Width = 2.674835!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label19})
        Me.PageFooter.Height = 0.1968504!
        Me.PageFooter.Name = "PageFooter"
        '
        'Label19
        '
        Me.Label19.Height = 0.1783465!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 12.904!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; ddo-char-set: 128"
        Me.Label19.Text = "（S4020）"
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
        Me.GroupHeader2.DataField = "HASSEI_KAISU"
        Me.GroupHeader2.Height = 0!
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.Before
        Me.GroupHeader2.UnderlayNext = True
        '
        'GroupFooter2
        '
        Me.GroupFooter2.CanGrow = False
        Me.GroupFooter2.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Line8, Me.Label20, Me.Label1, Me.SOKEI_KEIYAKUSYA_CD, Me.Label18, Me.Line3, Me.Label17, Me.Label22, Me.Label23, Me.SANTEI_KIN_1_SOKEI, Me.SANTEI_KIN_2_SOKEI, Me.SANTEI_KIN_SOKEI, Me.Line6, Me.SEI_TUMITATE_KIN_1_SOKEI, Me.KUNI_KOFU_KIN_1_SOKEI, Me.SEI_TUMITATE_KIN_2_SOKEI, Me.KUNI_KOFU_KIN_2_SOKEI, Me.Line11, Me.SEI_TUMITATE_KIN_SOKEI, Me.KUNI_KOFU_KIN_SOKEI, Me.KOFU_KIN_1_SOKEI, Me.KOFU_KIN_2_SOKEI, Me.KOFU_KIN_SOKEI})
        Me.GroupFooter2.Height = 1.440945!
        Me.GroupFooter2.KeepTogether = True
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'Line8
        '
        Me.Line8.AnchorBottom = True
        Me.Line8.Height = 0!
        Me.Line8.Left = 0!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 1.417323!
        Me.Line8.Width = 13.431!
        Me.Line8.X1 = 0!
        Me.Line8.X2 = 13.431!
        Me.Line8.Y1 = 1.417323!
        Me.Line8.Y2 = 1.417323!
        '
        'Label20
        '
        Me.Label20.Height = 0.2!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 0.4771655!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "ddo-char-set: 1"
        Me.Label20.Text = "総合計"
        Me.Label20.Top = 0.02007874!
        Me.Label20.Width = 2.674835!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 5.655!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "ddo-char-set: 1"
        Me.Label1.Text = "（参加人数："
        Me.Label1.Top = 0.02!
        Me.Label1.Width = 0.7260003!
        '
        'SOKEI_KEIYAKUSYA_CD
        '
        Me.SOKEI_KEIYAKUSYA_CD.DataField = "KEIYAKUSYA_CD"
        Me.SOKEI_KEIYAKUSYA_CD.DistinctField = "KEIYAKUSYA_CD"
        Me.SOKEI_KEIYAKUSYA_CD.Height = 0.2!
        Me.SOKEI_KEIYAKUSYA_CD.Left = 6.381001!
        Me.SOKEI_KEIYAKUSYA_CD.MultiLine = False
        Me.SOKEI_KEIYAKUSYA_CD.Name = "SOKEI_KEIYAKUSYA_CD"
        Me.SOKEI_KEIYAKUSYA_CD.OutputFormat = resources.GetString("SOKEI_KEIYAKUSYA_CD.OutputFormat")
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
        Me.Label18.Left = 6.798!
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
        Me.Line3.Top = 0!
        Me.Line3.Width = 13.42!
        Me.Line3.X1 = 0!
        Me.Line3.X2 = 13.42!
        Me.Line3.Y1 = 0!
        Me.Line3.Y2 = 0!
        '
        'Label17
        '
        Me.Label17.Height = 0.2007874!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 8.602!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "ddo-char-set: 1"
        Me.Label17.Text = "経営支援"
        Me.Label17.Top = 0.03!
        Me.Label17.Width = 0.8228346!
        '
        'Label22
        '
        Me.Label22.Height = 0.2007874!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 8.602!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "ddo-char-set: 1"
        Me.Label22.Text = "焼却・埋却"
        Me.Label22.Top = 0.502!
        Me.Label22.Width = 0.8228346!
        '
        'Label23
        '
        Me.Label23.Height = 0.2007874!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 8.602!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "ddo-char-set: 1"
        Me.Label23.Text = "合計"
        Me.Label23.Top = 0.9910001!
        Me.Label23.Width = 0.8228346!
        '
        'SANTEI_KIN_1_SOKEI
        '
        Me.SANTEI_KIN_1_SOKEI.DataField = "SANTEI_KIN_1_SOKEI"
        Me.SANTEI_KIN_1_SOKEI.Height = 0.2007874!
        Me.SANTEI_KIN_1_SOKEI.Left = 10.335!
        Me.SANTEI_KIN_1_SOKEI.MultiLine = False
        Me.SANTEI_KIN_1_SOKEI.Name = "SANTEI_KIN_1_SOKEI"
        Me.SANTEI_KIN_1_SOKEI.OutputFormat = resources.GetString("SANTEI_KIN_1_SOKEI.OutputFormat")
        Me.SANTEI_KIN_1_SOKEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.SANTEI_KIN_1_SOKEI.Text = "99,999,999,999"
        Me.SANTEI_KIN_1_SOKEI.Top = 0.02!
        Me.SANTEI_KIN_1_SOKEI.Width = 0.9370079!
        '
        'SANTEI_KIN_2_SOKEI
        '
        Me.SANTEI_KIN_2_SOKEI.DataField = "SANTEI_KIN_2_SOKEI"
        Me.SANTEI_KIN_2_SOKEI.Height = 0.2007874!
        Me.SANTEI_KIN_2_SOKEI.Left = 10.335!
        Me.SANTEI_KIN_2_SOKEI.MultiLine = False
        Me.SANTEI_KIN_2_SOKEI.Name = "SANTEI_KIN_2_SOKEI"
        Me.SANTEI_KIN_2_SOKEI.OutputFormat = resources.GetString("SANTEI_KIN_2_SOKEI.OutputFormat")
        Me.SANTEI_KIN_2_SOKEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.SANTEI_KIN_2_SOKEI.Text = "99,999,999,999"
        Me.SANTEI_KIN_2_SOKEI.Top = 0.5019686!
        Me.SANTEI_KIN_2_SOKEI.Width = 0.9370079!
        '
        'SANTEI_KIN_SOKEI
        '
        Me.SANTEI_KIN_SOKEI.DataField = "SANTEI_KIN_SOKEI"
        Me.SANTEI_KIN_SOKEI.Height = 0.2007874!
        Me.SANTEI_KIN_SOKEI.Left = 10.335!
        Me.SANTEI_KIN_SOKEI.MultiLine = False
        Me.SANTEI_KIN_SOKEI.Name = "SANTEI_KIN_SOKEI"
        Me.SANTEI_KIN_SOKEI.OutputFormat = resources.GetString("SANTEI_KIN_SOKEI.OutputFormat")
        Me.SANTEI_KIN_SOKEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.SANTEI_KIN_SOKEI.Text = "99,999,999,999"
        Me.SANTEI_KIN_SOKEI.Top = 0.9909449!
        Me.SANTEI_KIN_SOKEI.Width = 0.9370079!
        '
        'Line6
        '
        Me.Line6.Height = 0!
        Me.Line6.Left = 8.486!
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.45!
        Me.Line6.Width = 4.945!
        Me.Line6.X1 = 8.486!
        Me.Line6.X2 = 13.431!
        Me.Line6.Y1 = 0.45!
        Me.Line6.Y2 = 0.45!
        '
        'SEI_TUMITATE_KIN_1_SOKEI
        '
        Me.SEI_TUMITATE_KIN_1_SOKEI.DataField = "SEI_TUMITATE_KIN_1_SOKEI"
        Me.SEI_TUMITATE_KIN_1_SOKEI.Height = 0.2007874!
        Me.SEI_TUMITATE_KIN_1_SOKEI.Left = 12.42559!
        Me.SEI_TUMITATE_KIN_1_SOKEI.MultiLine = False
        Me.SEI_TUMITATE_KIN_1_SOKEI.Name = "SEI_TUMITATE_KIN_1_SOKEI"
        Me.SEI_TUMITATE_KIN_1_SOKEI.OutputFormat = resources.GetString("SEI_TUMITATE_KIN_1_SOKEI.OutputFormat")
        Me.SEI_TUMITATE_KIN_1_SOKEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.SEI_TUMITATE_KIN_1_SOKEI.Text = "99,999,999,999"
        Me.SEI_TUMITATE_KIN_1_SOKEI.Top = 0.02007875!
        Me.SEI_TUMITATE_KIN_1_SOKEI.Width = 0.9370077!
        '
        'KUNI_KOFU_KIN_1_SOKEI
        '
        Me.KUNI_KOFU_KIN_1_SOKEI.DataField = "KUNI_KOFU_KIN_1_SOKEI"
        Me.KUNI_KOFU_KIN_1_SOKEI.Height = 0.2007874!
        Me.KUNI_KOFU_KIN_1_SOKEI.Left = 12.4252!
        Me.KUNI_KOFU_KIN_1_SOKEI.MultiLine = False
        Me.KUNI_KOFU_KIN_1_SOKEI.Name = "KUNI_KOFU_KIN_1_SOKEI"
        Me.KUNI_KOFU_KIN_1_SOKEI.OutputFormat = resources.GetString("KUNI_KOFU_KIN_1_SOKEI.OutputFormat")
        Me.KUNI_KOFU_KIN_1_SOKEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KUNI_KOFU_KIN_1_SOKEI.Text = "99,999,999,999"
        Me.KUNI_KOFU_KIN_1_SOKEI.Top = 0.2311024!
        Me.KUNI_KOFU_KIN_1_SOKEI.Width = 0.9370077!
        '
        'SEI_TUMITATE_KIN_2_SOKEI
        '
        Me.SEI_TUMITATE_KIN_2_SOKEI.DataField = "SEI_TUMITATE_KIN_2_SOKEI"
        Me.SEI_TUMITATE_KIN_2_SOKEI.Height = 0.2007874!
        Me.SEI_TUMITATE_KIN_2_SOKEI.Left = 12.4252!
        Me.SEI_TUMITATE_KIN_2_SOKEI.MultiLine = False
        Me.SEI_TUMITATE_KIN_2_SOKEI.Name = "SEI_TUMITATE_KIN_2_SOKEI"
        Me.SEI_TUMITATE_KIN_2_SOKEI.OutputFormat = resources.GetString("SEI_TUMITATE_KIN_2_SOKEI.OutputFormat")
        Me.SEI_TUMITATE_KIN_2_SOKEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.SEI_TUMITATE_KIN_2_SOKEI.Text = "99,999,999,999"
        Me.SEI_TUMITATE_KIN_2_SOKEI.Top = 0.5019686!
        Me.SEI_TUMITATE_KIN_2_SOKEI.Width = 0.9370077!
        '
        'KUNI_KOFU_KIN_2_SOKEI
        '
        Me.KUNI_KOFU_KIN_2_SOKEI.DataField = "KUNI_KOFU_KIN_2_SOKEI"
        Me.KUNI_KOFU_KIN_2_SOKEI.Height = 0.2007874!
        Me.KUNI_KOFU_KIN_2_SOKEI.Left = 12.4252!
        Me.KUNI_KOFU_KIN_2_SOKEI.MultiLine = False
        Me.KUNI_KOFU_KIN_2_SOKEI.Name = "KUNI_KOFU_KIN_2_SOKEI"
        Me.KUNI_KOFU_KIN_2_SOKEI.OutputFormat = resources.GetString("KUNI_KOFU_KIN_2_SOKEI.OutputFormat")
        Me.KUNI_KOFU_KIN_2_SOKEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KUNI_KOFU_KIN_2_SOKEI.Text = "99,999,999,999"
        Me.KUNI_KOFU_KIN_2_SOKEI.Top = 0.702756!
        Me.KUNI_KOFU_KIN_2_SOKEI.Width = 0.9370077!
        '
        'Line11
        '
        Me.Line11.Height = 0!
        Me.Line11.Left = 8.486!
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 0.904!
        Me.Line11.Width = 4.945!
        Me.Line11.X1 = 8.486!
        Me.Line11.X2 = 13.431!
        Me.Line11.Y1 = 0.904!
        Me.Line11.Y2 = 0.904!
        '
        'SEI_TUMITATE_KIN_SOKEI
        '
        Me.SEI_TUMITATE_KIN_SOKEI.DataField = "SEI_TUMITATE_KIN_SOKEI"
        Me.SEI_TUMITATE_KIN_SOKEI.Height = 0.2007874!
        Me.SEI_TUMITATE_KIN_SOKEI.Left = 12.4252!
        Me.SEI_TUMITATE_KIN_SOKEI.MultiLine = False
        Me.SEI_TUMITATE_KIN_SOKEI.Name = "SEI_TUMITATE_KIN_SOKEI"
        Me.SEI_TUMITATE_KIN_SOKEI.OutputFormat = resources.GetString("SEI_TUMITATE_KIN_SOKEI.OutputFormat")
        Me.SEI_TUMITATE_KIN_SOKEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.SEI_TUMITATE_KIN_SOKEI.Text = "99,999,999,999"
        Me.SEI_TUMITATE_KIN_SOKEI.Top = 0.9909449!
        Me.SEI_TUMITATE_KIN_SOKEI.Width = 0.9370077!
        '
        'KUNI_KOFU_KIN_SOKEI
        '
        Me.KUNI_KOFU_KIN_SOKEI.DataField = "KUNI_KOFU_KIN_SOKEI"
        Me.KUNI_KOFU_KIN_SOKEI.Height = 0.2007874!
        Me.KUNI_KOFU_KIN_SOKEI.Left = 12.4252!
        Me.KUNI_KOFU_KIN_SOKEI.MultiLine = False
        Me.KUNI_KOFU_KIN_SOKEI.Name = "KUNI_KOFU_KIN_SOKEI"
        Me.KUNI_KOFU_KIN_SOKEI.OutputFormat = resources.GetString("KUNI_KOFU_KIN_SOKEI.OutputFormat")
        Me.KUNI_KOFU_KIN_SOKEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KUNI_KOFU_KIN_SOKEI.Text = "99,999,999,999"
        Me.KUNI_KOFU_KIN_SOKEI.Top = 1.191732!
        Me.KUNI_KOFU_KIN_SOKEI.Width = 0.9370077!
        '
        'KOFU_KIN_1_SOKEI
        '
        Me.KOFU_KIN_1_SOKEI.DataField = "KOFU_KIN_1_SOKEI"
        Me.KOFU_KIN_1_SOKEI.Height = 0.2!
        Me.KOFU_KIN_1_SOKEI.Left = 11.347!
        Me.KOFU_KIN_1_SOKEI.MultiLine = False
        Me.KOFU_KIN_1_SOKEI.Name = "KOFU_KIN_1_SOKEI"
        Me.KOFU_KIN_1_SOKEI.OutputFormat = resources.GetString("KOFU_KIN_1_SOKEI.OutputFormat")
        Me.KOFU_KIN_1_SOKEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KOFU_KIN_1_SOKEI.Text = "99,999,999,999"
        Me.KOFU_KIN_1_SOKEI.Top = 0.02!
        Me.KOFU_KIN_1_SOKEI.Width = 0.9373701!
        '
        'KOFU_KIN_2_SOKEI
        '
        Me.KOFU_KIN_2_SOKEI.DataField = "KOFU_KIN_2_SOKEI"
        Me.KOFU_KIN_2_SOKEI.Height = 0.2!
        Me.KOFU_KIN_2_SOKEI.Left = 11.347!
        Me.KOFU_KIN_2_SOKEI.MultiLine = False
        Me.KOFU_KIN_2_SOKEI.Name = "KOFU_KIN_2_SOKEI"
        Me.KOFU_KIN_2_SOKEI.OutputFormat = resources.GetString("KOFU_KIN_2_SOKEI.OutputFormat")
        Me.KOFU_KIN_2_SOKEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KOFU_KIN_2_SOKEI.Text = "99,999,999,999"
        Me.KOFU_KIN_2_SOKEI.Top = 0.5023623!
        Me.KOFU_KIN_2_SOKEI.Width = 0.9373701!
        '
        'KOFU_KIN_SOKEI
        '
        Me.KOFU_KIN_SOKEI.DataField = "KOFU_KIN_SOKEI"
        Me.KOFU_KIN_SOKEI.Height = 0.2!
        Me.KOFU_KIN_SOKEI.Left = 11.347!
        Me.KOFU_KIN_SOKEI.MultiLine = False
        Me.KOFU_KIN_SOKEI.Name = "KOFU_KIN_SOKEI"
        Me.KOFU_KIN_SOKEI.OutputFormat = resources.GetString("KOFU_KIN_SOKEI.OutputFormat")
        Me.KOFU_KIN_SOKEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KOFU_KIN_SOKEI.Text = "99,999,999,999"
        Me.KOFU_KIN_SOKEI.Top = 0.9913386!
        Me.KOFU_KIN_SOKEI.Width = 0.9373701!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.CanGrow = False
        Me.GroupHeader3.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.KEIYAKUSYA_CD, Me.ITAKU_RYAKU_NM, Me.KEIYAKU_KBN_NM, Me.KEIYAKUSYA_NAME, Me.Line12})
        Me.GroupHeader3.DataField = "KEIYAKUSYA_CD"
        Me.GroupHeader3.GroupKeepTogether = GrapeCity.ActiveReports.SectionReportModel.GroupKeepTogether.FirstDetail
        Me.GroupHeader3.Height = 0.472441!
        Me.GroupHeader3.Name = "GroupHeader3"
        Me.GroupHeader3.UnderlayNext = True
        '
        'KEIYAKU_KBN_NM
        '
        Me.KEIYAKU_KBN_NM.DataField = "KEIYAKU_KBN_NM"
        Me.KEIYAKU_KBN_NM.Height = 0.4027559!
        Me.KEIYAKU_KBN_NM.Left = 3.225!
        Me.KEIYAKU_KBN_NM.Name = "KEIYAKU_KBN_NM"
        Me.KEIYAKU_KBN_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "white-space: inherit"
        Me.KEIYAKU_KBN_NM.Text = "うずら"
        Me.KEIYAKU_KBN_NM.Top = 0.03!
        Me.KEIYAKU_KBN_NM.Width = 0.476378!
        '
        'KEIYAKUSYA_NAME
        '
        Me.KEIYAKUSYA_NAME.DataField = "KEIYAKUSYA_NAME"
        Me.KEIYAKUSYA_NAME.Height = 0.2007874!
        Me.KEIYAKUSYA_NAME.Left = 0.477!
        Me.KEIYAKUSYA_NAME.MultiLine = False
        Me.KEIYAKUSYA_NAME.Name = "KEIYAKUSYA_NAME"
        Me.KEIYAKUSYA_NAME.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: justify; vertical-align: middle;" &
    " white-space: nowrap"
        Me.KEIYAKUSYA_NAME.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.KEIYAKUSYA_NAME.Top = 0.03!
        Me.KEIYAKUSYA_NAME.Width = 2.675!
        '
        'Line12
        '
        Me.Line12.Height = 0!
        Me.Line12.Left = 0!
        Me.Line12.LineWeight = 1.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 0!
        Me.Line12.Width = 13.42!
        Me.Line12.X1 = 0!
        Me.Line12.X2 = 13.42!
        Me.Line12.Y1 = 0!
        Me.Line12.Y2 = 0!
        '
        'GroupFooter3
        '
        Me.GroupFooter3.CanGrow = False
        Me.GroupFooter3.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label21, Me.Line9, Me.Line10, Me.SANTEI_KIN_KEI, Me.SEI_TUMITATE_KIN_KEI, Me.KUNI_KOFU_KIN_KEI, Me.KOFU_KIN_KEI})
        Me.GroupFooter3.Height = 0.472441!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'Label21
        '
        Me.Label21.Height = 0.2!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 4.395!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " &
    "ddo-char-set: 1"
        Me.Label21.Text = "契約者計"
        Me.Label21.Top = 0.027!
        Me.Label21.Width = 4.069!
        '
        'Line9
        '
        Me.Line9.AnchorBottom = True
        Me.Line9.Height = 0!
        Me.Line9.Left = 0!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.434!
        Me.Line9.Width = 13.42!
        Me.Line9.X1 = 0!
        Me.Line9.X2 = 13.42!
        Me.Line9.Y1 = 0.434!
        Me.Line9.Y2 = 0.434!
        '
        'Line10
        '
        Me.Line10.Height = 0.0007874966!
        Me.Line10.Left = 3.763!
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 0!
        Me.Line10.Width = 9.657!
        Me.Line10.X1 = 3.763!
        Me.Line10.X2 = 13.42!
        Me.Line10.Y1 = 0!
        Me.Line10.Y2 = 0.0007874966!
        '
        'SANTEI_KIN_KEI
        '
        Me.SANTEI_KIN_KEI.DataField = "SANTEI_KIN"
        Me.SANTEI_KIN_KEI.Height = 0.2!
        Me.SANTEI_KIN_KEI.Left = 10.335!
        Me.SANTEI_KIN_KEI.MultiLine = False
        Me.SANTEI_KIN_KEI.Name = "SANTEI_KIN_KEI"
        Me.SANTEI_KIN_KEI.OutputFormat = resources.GetString("SANTEI_KIN_KEI.OutputFormat")
        Me.SANTEI_KIN_KEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.SANTEI_KIN_KEI.SummaryGroup = "GroupHeader3"
        Me.SANTEI_KIN_KEI.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.SANTEI_KIN_KEI.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.SANTEI_KIN_KEI.Text = "99,999,999,999"
        Me.SANTEI_KIN_KEI.Top = 0.02718109!
        Me.SANTEI_KIN_KEI.Width = 0.9373701!
        '
        'SEI_TUMITATE_KIN_KEI
        '
        Me.SEI_TUMITATE_KIN_KEI.DataField = "SEI_TUMITATE_KIN"
        Me.SEI_TUMITATE_KIN_KEI.Height = 0.2!
        Me.SEI_TUMITATE_KIN_KEI.Left = 12.4252!
        Me.SEI_TUMITATE_KIN_KEI.MultiLine = False
        Me.SEI_TUMITATE_KIN_KEI.Name = "SEI_TUMITATE_KIN_KEI"
        Me.SEI_TUMITATE_KIN_KEI.OutputFormat = resources.GetString("SEI_TUMITATE_KIN_KEI.OutputFormat")
        Me.SEI_TUMITATE_KIN_KEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.SEI_TUMITATE_KIN_KEI.SummaryGroup = "GroupHeader3"
        Me.SEI_TUMITATE_KIN_KEI.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.SEI_TUMITATE_KIN_KEI.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.SEI_TUMITATE_KIN_KEI.Text = "99,999,999,999"
        Me.SEI_TUMITATE_KIN_KEI.Top = 0.02716535!
        Me.SEI_TUMITATE_KIN_KEI.Width = 0.9373701!
        '
        'KUNI_KOFU_KIN_KEI
        '
        Me.KUNI_KOFU_KIN_KEI.DataField = "KUNI_KOFU_KIN"
        Me.KUNI_KOFU_KIN_KEI.Height = 0.2!
        Me.KUNI_KOFU_KIN_KEI.Left = 12.425!
        Me.KUNI_KOFU_KIN_KEI.MultiLine = False
        Me.KUNI_KOFU_KIN_KEI.Name = "KUNI_KOFU_KIN_KEI"
        Me.KUNI_KOFU_KIN_KEI.OutputFormat = resources.GetString("KUNI_KOFU_KIN_KEI.OutputFormat")
        Me.KUNI_KOFU_KIN_KEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KUNI_KOFU_KIN_KEI.SummaryGroup = "GroupHeader3"
        Me.KUNI_KOFU_KIN_KEI.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.KUNI_KOFU_KIN_KEI.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.KUNI_KOFU_KIN_KEI.Text = "99,999,999,999"
        Me.KUNI_KOFU_KIN_KEI.Top = 0.25!
        Me.KUNI_KOFU_KIN_KEI.Width = 0.9373701!
        '
        'KOFU_KIN_KEI
        '
        Me.KOFU_KIN_KEI.DataField = "KOFU_KIN"
        Me.KOFU_KIN_KEI.Height = 0.2!
        Me.KOFU_KIN_KEI.Left = 11.347!
        Me.KOFU_KIN_KEI.MultiLine = False
        Me.KOFU_KIN_KEI.Name = "KOFU_KIN_KEI"
        Me.KOFU_KIN_KEI.OutputFormat = resources.GetString("KOFU_KIN_KEI.OutputFormat")
        Me.KOFU_KIN_KEI.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" &
    "hite-space: nowrap"
        Me.KOFU_KIN_KEI.SummaryGroup = "GroupHeader3"
        Me.KOFU_KIN_KEI.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.KOFU_KIN_KEI.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.KOFU_KIN_KEI.Text = "99,999,999,999"
        Me.KOFU_KIN_KEI.Top = 0.027!
        Me.KOFU_KIN_KEI.Width = 0.9373701!
        '
        'rptGJ4020
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 13.5445!
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
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGroupPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KOFU_RITU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KOFU_RITU_CNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GOJOKIN_SYURUI_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKU_HASU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TORI_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NOJO_ADDR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NOJO_CD_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SYORI_JOKYO_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEI_TUMITATE_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KUNI_KOFU_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SANTEI_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KOFU_TANKA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KOFU_HASU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTL_CNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KOFU_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GENGAKU_RITU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ITAKU_RYAKU_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SOKEI_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SANTEI_KIN_1_SOKEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SANTEI_KIN_2_SOKEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SANTEI_KIN_SOKEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEI_TUMITATE_KIN_1_SOKEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KUNI_KOFU_KIN_1_SOKEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEI_TUMITATE_KIN_2_SOKEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KUNI_KOFU_KIN_2_SOKEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEI_TUMITATE_KIN_SOKEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KUNI_KOFU_KIN_SOKEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KOFU_KIN_1_SOKEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KOFU_KIN_2_SOKEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KOFU_KIN_SOKEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKU_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SANTEI_KIN_KEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEI_TUMITATE_KIN_KEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KUNI_KOFU_KIN_KEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KOFU_KIN_KEI, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents CrossSectionBox1 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionBox
    Private WithEvents Line1 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents CrossSectionLine1 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine3 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine4 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine5 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents Line5 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line7 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label21 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Line9 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line10 As GrapeCity.ActiveReports.SectionReportModel.Line
    Public WithEvents GroupHeader3 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Public WithEvents GroupFooter3 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents ITAKU_RYAKU_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label6 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label4 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label5 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label7 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label10 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents CrossSectionLine2 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents TORI_KBN_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line4 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line3 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents SYORI_JOKYO_KBN_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEIYAKU_KBN_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents CrossSectionLine7 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents NOJO_ADDR As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEIYAKUSYA_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label11 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label12 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label13 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents CrossSectionLine9 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents Label20 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents SOKEI_KEIYAKUSYA_CD As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label18 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Shape1 As GrapeCity.ActiveReports.SectionReportModel.Shape
    Private WithEvents NOJO_CD_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents GOJOKIN_SYURUI_KBN_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label8 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label9 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label14 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label15 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label16 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents SEI_TUMITATE_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KUNI_KOFU_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents SANTEI_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KOFU_TANKA As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KOFU_HASU As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label17 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label22 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label23 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents SANTEI_KIN_1_SOKEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents SANTEI_KIN_2_SOKEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents SANTEI_KIN_SOKEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line6 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents SEI_TUMITATE_KIN_1_SOKEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KUNI_KOFU_KIN_1_SOKEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents SEI_TUMITATE_KIN_2_SOKEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KUNI_KOFU_KIN_2_SOKEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line11 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents SEI_TUMITATE_KIN_SOKEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KUNI_KOFU_KIN_SOKEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents SEI_TUMITATE_KIN_KEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KUNI_KOFU_KIN_KEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents DTL_CNT As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line12 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents txtGroupPage As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label24 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label25 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents CrossSectionLine6 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents KOFU_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents GENGAKU_RITU As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KOFU_KIN_1_SOKEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KOFU_KIN_2_SOKEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KOFU_KIN_SOKEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents SANTEI_KIN_KEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KOFU_KIN_KEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents CrossSectionLine10 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine11 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents KOFU_RITU As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents KOFU_RITU_CNT As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label27 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label26 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label52 As GrapeCity.ActiveReports.SectionReportModel.Label
End Class
