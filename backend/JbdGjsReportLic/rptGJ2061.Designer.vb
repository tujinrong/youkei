<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptGJ2061
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptGJ2061))
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.txt_NOWYMD = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label6 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txt_Page = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label59 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label50 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label70 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Line2 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Label22 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Line3 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.Line5 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line6 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line8 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line9 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.KYK_POST = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KYK_ADDR1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KYK_ADDR2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_Title = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_HD_TEXT = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KYK_ADDR3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_KYOKAI_ADDR = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_KYOKAI_TEL = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_KYOKAI_FAX = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KYK_KEIYAKUSYA_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KYK_DAIHYO_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKUSYA_CD_KAKKO = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_HAKKO = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_HAKKO_DATE = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_KYO_KYOKAI_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_YAKUMEI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_KAICHO_NAM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.HAKKO_NO_KANJI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.SEIKYU_HAKKO_NO_NEN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.SEIKYU_HAKKO_NO_RENBAN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.JIMUITAKU_CD = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.BANK_INJI_KBN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_SaiHakko = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line32 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.txt_FURI_FT1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_ITAKU_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lbl_ITAKU_NAME = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.txt_NOFUKIGEN_DATE = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_FURI_BANK_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_FURI_SITEN_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_FURI_KOZA_SYUBETU = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_FURI_KOZA_NO_N = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.txt_FURI_KOZA_MEIGI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.lbl_FURI_BANK_NAME = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl_FURI_SITEN_NAME = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl_FURI_KOZA_SYUBETU = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl_FURI_KOZA_MEIGI = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl_FURI_KOZA_NO_N = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl_NOFUKIGEN_DATE23 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl_FURI_BANK_TITLE23 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl_NOFUKIGEN_DATE22 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl_FURI_BANK_TITLE22 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label19 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox27 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line1 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line4 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line7 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line10 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line26 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line27 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line28 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line33 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.lbl_HD1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label20 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl_HD2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox1 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox2 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label23 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox4 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line34 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line35 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line36 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line37 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line38 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line11 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.lbl_HD3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.lbl_HD4 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox3 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TextBox5 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label5 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TextBox6 = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line12 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line13 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line14 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line15 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Line16 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.KEIYAKU_KBN_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ZEN_KI_N = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TOU_KI_N = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKU_KBN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.inei = New GrapeCity.ActiveReports.SectionReportModel.Picture()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.ReportHeader1 = New GrapeCity.ActiveReports.SectionReportModel.ReportHeader()
        Me.ReportFooter1 = New GrapeCity.ActiveReports.SectionReportModel.ReportFooter()
        Me.GRP_HD_KEIYAKUSYA_CD = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.GRP_FT_SINSEI_NO = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.GRP_HD_JIMUITAKU_CD = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.GRP_FT_ALL = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        CType(Me.txt_NOWYMD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Page, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label59, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label70, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KYK_POST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KYK_ADDR1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KYK_ADDR2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Title, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_HD_TEXT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KYK_ADDR3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KYOKAI_ADDR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KYOKAI_TEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KYOKAI_FAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KYK_KEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KYK_DAIHYO_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKUSYA_CD_KAKKO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_HAKKO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_HAKKO_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KYO_KYOKAI_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_YAKUMEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_KAICHO_NAM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HAKKO_NO_KANJI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEIKYU_HAKKO_NO_NEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEIKYU_HAKKO_NO_RENBAN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JIMUITAKU_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BANK_INJI_KBN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SaiHakko, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FURI_FT1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ITAKU_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_ITAKU_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_NOFUKIGEN_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FURI_BANK_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FURI_SITEN_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FURI_KOZA_SYUBETU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FURI_KOZA_NO_N, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FURI_KOZA_MEIGI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_FURI_BANK_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_FURI_SITEN_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_FURI_KOZA_SYUBETU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_FURI_KOZA_MEIGI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_FURI_KOZA_NO_N, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_NOFUKIGEN_DATE23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_FURI_BANK_TITLE23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_NOFUKIGEN_DATE22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_FURI_BANK_TITLE22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_HD1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_HD2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_HD3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_HD4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKU_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZEN_KI_N, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOU_KI_N, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKU_KBN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.inei, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader
        '
        Me.PageHeader.CanGrow = False
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.txt_NOWYMD, Me.Label6, Me.txt_Page, Me.Label59, Me.Label50, Me.Label70, Me.Line2, Me.Label22, Me.Line3, Me.Label2})
        Me.PageHeader.Height = 0.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'txt_NOWYMD
        '
        Me.txt_NOWYMD.DataField = "SAKUSEIBI"
        Me.txt_NOWYMD.Height = 0.1889764!
        Me.txt_NOWYMD.Left = 8.958268!
        Me.txt_NOWYMD.MultiLine = False
        Me.txt_NOWYMD.Name = "txt_NOWYMD"
        Me.txt_NOWYMD.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; vertical-align: middle" & _
            "; white-space: inherit; ddo-char-set: 1"
        Me.txt_NOWYMD.Text = "作成日：平成99年99月99日"
        Me.txt_NOWYMD.Top = 0.2669291!
        Me.txt_NOWYMD.Width = 1.855906!
        '
        'Label6
        '
        Me.Label6.Height = 0.1889764!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 9.903151!
        Me.Label6.MultiLine = False
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left; vertical-align: middle;" & _
            " white-space: inherit; ddo-char-set: 1"
        Me.Label6.Text = "ページ："
        Me.Label6.Top = 0.4732284!
        Me.Label6.Width = 0.5208654!
        '
        'txt_Page
        '
        Me.txt_Page.Height = 0.1889764!
        Me.txt_Page.Left = 10.38228!
        Me.txt_Page.MultiLine = False
        Me.txt_Page.Name = "txt_Page"
        Me.txt_Page.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; vertical-align: middle" & _
            "; white-space: inherit; ddo-char-set: 1"
        Me.txt_Page.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.txt_Page.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.txt_Page.Text = "Z,ZZ9"
        Me.txt_Page.Top = 0.4732284!
        Me.txt_Page.Width = 0.402441!
        '
        'Label59
        '
        Me.Label59.Height = 0.1875!
        Me.Label59.HyperLink = Nothing
        Me.Label59.Left = 9.886221!
        Me.Label59.MultiLine = False
        Me.Label59.Name = "Label59"
        Me.Label59.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label59.Text = "携帯番号"
        Me.Label59.Top = 0.9590552!
        Me.Label59.Width = 0.8984251!
        '
        'Label50
        '
        Me.Label50.Height = 0.1875!
        Me.Label50.HyperLink = Nothing
        Me.Label50.Left = 9.000001!
        Me.Label50.MultiLine = False
        Me.Label50.Name = "Label50"
        Me.Label50.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label50.Text = "電話番号"
        Me.Label50.Top = 0.9590555!
        Me.Label50.Width = 0.8492117!
        '
        'Label70
        '
        Me.Label70.Height = 0.1875!
        Me.Label70.HyperLink = Nothing
        Me.Label70.Left = 9.000001!
        Me.Label70.MultiLine = False
        Me.Label70.Name = "Label70"
        Me.Label70.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label70.Text = "メールアドレス"
        Me.Label70.Top = 1.149606!
        Me.Label70.Width = 1.784645!
        '
        'Line2
        '
        Me.Line2.Height = 0.0007879734!
        Me.Line2.Left = 0.0!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.519685!
        Me.Line2.Width = 1.168504!
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 1.168504!
        Me.Line2.Y1 = 1.519685!
        Me.Line2.Y2 = 1.520473!
        '
        'Label22
        '
        Me.Label22.Height = 0.1875!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 9.000001!
        Me.Label22.MultiLine = False
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left"
        Me.Label22.Text = "業種区分名"
        Me.Label22.Top = 1.333858!
        Me.Label22.Width = 1.784645!
        '
        'Line3
        '
        Me.Line3.Height = 0.0007879734!
        Me.Line3.Left = 0.0!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 1.515748!
        Me.Line3.Width = 10.83858!
        Me.Line3.X1 = 0.0!
        Me.Line3.X2 = 10.83858!
        Me.Line3.Y1 = 1.515748!
        Me.Line3.Y2 = 1.516536!
        '
        'Label2
        '
        Me.Label2.Height = 0.1889764!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 9.903151!
        Me.Label2.MultiLine = False
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; vertical-align: middle" & _
            "; white-space: inherit; ddo-char-set: 1"
        Me.Label2.Text = "(単位：円)"
        Me.Label2.Top = 0.6858268!
        Me.Label2.Width = 0.9110231!
        '
        'Detail
        '
        Me.Detail.CanGrow = False
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Line5, Me.Line6, Me.Line8, Me.Line9, Me.KYK_POST, Me.KYK_ADDR1, Me.KYK_ADDR2, Me.txt_Title, Me.txt_HD_TEXT, Me.KYK_ADDR3, Me.txt_KYOKAI_ADDR, Me.txt_KYOKAI_TEL, Me.txt_KYOKAI_FAX, Me.KYK_KEIYAKUSYA_NAME, Me.KYK_DAIHYO_NAME, Me.KEIYAKUSYA_CD_KAKKO, Me.txt_HAKKO, Me.txt_HAKKO_DATE, Me.txt_KYO_KYOKAI_NAME, Me.txt_YAKUMEI, Me.txt_KAICHO_NAM, Me.HAKKO_NO_KANJI, Me.SEIKYU_HAKKO_NO_NEN, Me.SEIKYU_HAKKO_NO_RENBAN, Me.JIMUITAKU_CD, Me.BANK_INJI_KBN, Me.txt_SaiHakko, Me.Line32, Me.txt_FURI_FT1, Me.txt_ITAKU_NAME, Me.lbl_ITAKU_NAME, Me.txt_NOFUKIGEN_DATE, Me.txt_FURI_BANK_NAME, Me.txt_FURI_SITEN_NAME, Me.txt_FURI_KOZA_SYUBETU, Me.txt_FURI_KOZA_NO_N, Me.txt_FURI_KOZA_MEIGI, Me.lbl_FURI_BANK_NAME, Me.lbl_FURI_SITEN_NAME, Me.lbl_FURI_KOZA_SYUBETU, Me.lbl_FURI_KOZA_MEIGI, Me.lbl_FURI_KOZA_NO_N, Me.lbl_NOFUKIGEN_DATE23, Me.lbl_FURI_BANK_TITLE23, Me.lbl_NOFUKIGEN_DATE22, Me.lbl_FURI_BANK_TITLE22, Me.Label19, Me.TextBox27, Me.Line1, Me.Line4, Me.Line7, Me.Line10, Me.Line26, Me.Line27, Me.Line28, Me.Line33, Me.lbl_HD1, Me.Label20, Me.lbl_HD2, Me.TextBox1, Me.TextBox2, Me.Label23, Me.TextBox4, Me.Line34, Me.Line35, Me.Line36, Me.Line37, Me.Line38, Me.Line11, Me.lbl_HD3, Me.Label3, Me.lbl_HD4, Me.TextBox3, Me.TextBox5, Me.Label5, Me.TextBox6, Me.Line12, Me.Line13, Me.Line14, Me.Line15, Me.Line16, Me.KEIYAKU_KBN_NM, Me.ZEN_KI_N, Me.TOU_KI_N, Me.KEIYAKU_KBN, Me.inei})
        Me.Detail.Height = 10.28738!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'Line5
        '
        Me.Line5.Height = 0.001181126!
        Me.Line5.Left = 0.3173229!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.0!
        Me.Line5.Visible = False
        Me.Line5.Width = 3.663385!
        Me.Line5.X1 = 0.3173229!
        Me.Line5.X2 = 3.980708!
        Me.Line5.Y1 = 0.001181126!
        Me.Line5.Y2 = 0.0!
        '
        'Line6
        '
        Me.Line6.Height = 0.001181006!
        Me.Line6.Left = 0.3173229!
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 1.516929!
        Me.Line6.Visible = False
        Me.Line6.Width = 3.663385!
        Me.Line6.X1 = 0.3173229!
        Me.Line6.X2 = 3.980708!
        Me.Line6.Y1 = 1.516929!
        Me.Line6.Y2 = 1.51811!
        '
        'Line8
        '
        Me.Line8.Height = 1.514567!
        Me.Line8.Left = 0.3173229!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0.00118134!
        Me.Line8.Visible = False
        Me.Line8.Width = 0.0!
        Me.Line8.X1 = 0.3173229!
        Me.Line8.X2 = 0.3173229!
        Me.Line8.Y1 = 0.00118134!
        Me.Line8.Y2 = 1.515748!
        '
        'Line9
        '
        Me.Line9.Height = 1.515748!
        Me.Line9.Left = 3.990944!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.00118134!
        Me.Line9.Visible = False
        Me.Line9.Width = 0.001181126!
        Me.Line9.X1 = 3.990944!
        Me.Line9.X2 = 3.992125!
        Me.Line9.Y1 = 0.00118134!
        Me.Line9.Y2 = 1.516929!
        '
        'KYK_POST
        '
        Me.KYK_POST.DataField = "KYK_POST"
        Me.KYK_POST.Height = 0.1665355!
        Me.KYK_POST.Left = 0.4838583!
        Me.KYK_POST.MultiLine = False
        Me.KYK_POST.Name = "KYK_POST"
        Me.KYK_POST.Style = "font-family: ＭＳ 明朝; font-size: 12pt; text-align: left; white-space: nowrap"
        Me.KYK_POST.Text = "〒999-9999"
        Me.KYK_POST.Top = 0.04763804!
        Me.KYK_POST.Width = 0.9633861!
        '
        'KYK_ADDR1
        '
        Me.KYK_ADDR1.DataField = "KYK_ADDR1"
        Me.KYK_ADDR1.Height = 0.1602362!
        Me.KYK_ADDR1.Left = 0.4838583!
        Me.KYK_ADDR1.MultiLine = False
        Me.KYK_ADDR1.Name = "KYK_ADDR1"
        Me.KYK_ADDR1.Style = "font-family: ＭＳ 明朝; font-size: 10pt; white-space: nowrap"
        Me.KYK_ADDR1.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.KYK_ADDR1.Top = 0.2614175!
        Me.KYK_ADDR1.Width = 3.384252!
        '
        'KYK_ADDR2
        '
        Me.KYK_ADDR2.DataField = "KYK_ADDR2"
        Me.KYK_ADDR2.Height = 0.1602363!
        Me.KYK_ADDR2.Left = 0.4838583!
        Me.KYK_ADDR2.MultiLine = False
        Me.KYK_ADDR2.Name = "KYK_ADDR2"
        Me.KYK_ADDR2.Style = "font-family: ＭＳ 明朝; font-size: 10pt; white-space: nowrap"
        Me.KYK_ADDR2.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.KYK_ADDR2.Top = 0.4271655!
        Me.KYK_ADDR2.Width = 3.384252!
        '
        'txt_Title
        '
        Me.txt_Title.Height = 0.2334641!
        Me.txt_Title.Left = 0.0!
        Me.txt_Title.MultiLine = False
        Me.txt_Title.Name = "txt_Title"
        Me.txt_Title.Style = "font-family: ＭＳ ゴシック; font-size: 15.75pt; text-align: center; white-space: inheri" & _
            "t"
        Me.txt_Title.Text = "家畜防疫互助基金積立金返還通知書"
        Me.txt_Title.Top = 3.036221!
        Me.txt_Title.Width = 7.379134!
        '
        'txt_HD_TEXT
        '
        Me.txt_HD_TEXT.DataField = "BODY1"
        Me.txt_HD_TEXT.Height = 0.9330708!
        Me.txt_HD_TEXT.Left = 0.3450789!
        Me.txt_HD_TEXT.LineSpacing = 2.0!
        Me.txt_HD_TEXT.Name = "txt_HD_TEXT"
        Me.txt_HD_TEXT.Style = "font-family: ＭＳ 明朝; font-size: 11pt; text-align: left; white-space: inherit; ddo-" & _
            "char-set: 1"
        Me.txt_HD_TEXT.Text = "　平素は家畜防疫互助事業にご協力いただきありがとうございます。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第９期互助事業の生産者積立金の残額に係る返還金は、下記のとおりとなりましたので通知いたします。な" & _
            "お、返還金は下記の金融機関にお振込みいたします。"
        Me.txt_HD_TEXT.Top = 3.449607!
        Me.txt_HD_TEXT.Width = 6.688976!
        '
        'KYK_ADDR3
        '
        Me.KYK_ADDR3.DataField = "KYK_ADDR3"
        Me.KYK_ADDR3.Height = 0.1602363!
        Me.KYK_ADDR3.Left = 0.4838583!
        Me.KYK_ADDR3.MultiLine = False
        Me.KYK_ADDR3.Name = "KYK_ADDR3"
        Me.KYK_ADDR3.Style = "font-family: ＭＳ 明朝; font-size: 10pt; white-space: nowrap"
        Me.KYK_ADDR3.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.KYK_ADDR3.Top = 0.5874019!
        Me.KYK_ADDR3.Width = 3.384252!
        '
        'txt_KYOKAI_ADDR
        '
        Me.txt_KYOKAI_ADDR.DataField = "KYO_ADDR"
        Me.txt_KYOKAI_ADDR.Height = 0.1574803!
        Me.txt_KYOKAI_ADDR.Left = 0.5409449!
        Me.txt_KYOKAI_ADDR.MultiLine = False
        Me.txt_KYOKAI_ADDR.Name = "txt_KYOKAI_ADDR"
        Me.txt_KYOKAI_ADDR.Style = "font-family: ＭＳ 明朝; font-size: 9.75pt; text-align: right; white-space: nowrap"
        Me.txt_KYOKAI_ADDR.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.txt_KYOKAI_ADDR.Top = 2.357874!
        Me.txt_KYOKAI_ADDR.Width = 5.95315!
        '
        'txt_KYOKAI_TEL
        '
        Me.txt_KYOKAI_TEL.DataField = "KYO_TEL1"
        Me.txt_KYOKAI_TEL.Height = 0.1574803!
        Me.txt_KYOKAI_TEL.Left = 4.988977!
        Me.txt_KYOKAI_TEL.MultiLine = False
        Me.txt_KYOKAI_TEL.Name = "txt_KYOKAI_TEL"
        Me.txt_KYOKAI_TEL.Style = "font-family: ＭＳ 明朝; font-size: 9.75pt; text-align: left; white-space: nowrap"
        Me.txt_KYOKAI_TEL.Text = "ＴＥＬ・99-9999-9999"
        Me.txt_KYOKAI_TEL.Top = 2.540945!
        Me.txt_KYOKAI_TEL.Width = 1.390551!
        '
        'txt_KYOKAI_FAX
        '
        Me.txt_KYOKAI_FAX.DataField = "KYO_FAX1"
        Me.txt_KYOKAI_FAX.Height = 0.1574803!
        Me.txt_KYOKAI_FAX.Left = 4.988977!
        Me.txt_KYOKAI_FAX.MultiLine = False
        Me.txt_KYOKAI_FAX.Name = "txt_KYOKAI_FAX"
        Me.txt_KYOKAI_FAX.Style = "font-family: ＭＳ 明朝; font-size: 9.75pt; text-align: left; white-space: nowrap"
        Me.txt_KYOKAI_FAX.Text = "ＦＡＸ・99-9999-9999"
        Me.txt_KYOKAI_FAX.Top = 2.711023!
        Me.txt_KYOKAI_FAX.Width = 1.390551!
        '
        'KYK_KEIYAKUSYA_NAME
        '
        Me.KYK_KEIYAKUSYA_NAME.DataField = "KYK_KEIYAKUSYA_NAME"
        Me.KYK_KEIYAKUSYA_NAME.Height = 0.1614173!
        Me.KYK_KEIYAKUSYA_NAME.Left = 0.4838583!
        Me.KYK_KEIYAKUSYA_NAME.MultiLine = False
        Me.KYK_KEIYAKUSYA_NAME.Name = "KYK_KEIYAKUSYA_NAME"
        Me.KYK_KEIYAKUSYA_NAME.Style = "font-family: ＭＳ 明朝; font-size: 10pt; white-space: nowrap"
        Me.KYK_KEIYAKUSYA_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠様"
        Me.KYK_KEIYAKUSYA_NAME.Top = 0.8759845!
        Me.KYK_KEIYAKUSYA_NAME.Width = 3.874016!
        '
        'KYK_DAIHYO_NAME
        '
        Me.KYK_DAIHYO_NAME.DataField = "KYK_DAIHYO_NAME"
        Me.KYK_DAIHYO_NAME.Height = 0.1614173!
        Me.KYK_DAIHYO_NAME.Left = 0.4838583!
        Me.KYK_DAIHYO_NAME.MultiLine = False
        Me.KYK_DAIHYO_NAME.Name = "KYK_DAIHYO_NAME"
        Me.KYK_DAIHYO_NAME.Style = "font-family: ＭＳ 明朝; font-size: 10pt; white-space: nowrap"
        Me.KYK_DAIHYO_NAME.Text = "　＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠様"
        Me.KYK_DAIHYO_NAME.Top = 1.036221!
        Me.KYK_DAIHYO_NAME.Width = 3.874016!
        '
        'KEIYAKUSYA_CD_KAKKO
        '
        Me.KEIYAKUSYA_CD_KAKKO.DataField = "KEIYAKUSYA_CD_KAKKO"
        Me.KEIYAKUSYA_CD_KAKKO.Height = 0.1732284!
        Me.KEIYAKUSYA_CD_KAKKO.Left = 0.6433072!
        Me.KEIYAKUSYA_CD_KAKKO.MultiLine = False
        Me.KEIYAKUSYA_CD_KAKKO.Name = "KEIYAKUSYA_CD_KAKKO"
        Me.KEIYAKUSYA_CD_KAKKO.Style = "font-family: ＭＳ 明朝; font-size: 9.75pt; white-space: nowrap; ddo-char-set: 1"
        Me.KEIYAKUSYA_CD_KAKKO.Text = "(99999)"
        Me.KEIYAKUSYA_CD_KAKKO.Top = 1.26811!
        Me.KEIYAKUSYA_CD_KAKKO.Width = 0.9799216!
        '
        'txt_HAKKO
        '
        Me.txt_HAKKO.Height = 0.1732284!
        Me.txt_HAKKO.Left = 5.60315!
        Me.txt_HAKKO.MultiLine = False
        Me.txt_HAKKO.Name = "txt_HAKKO"
        Me.txt_HAKKO.Style = "font-family: ＭＳ 明朝; font-size: 12pt; text-align: justify; text-justify: distribut" & _
            "e-all-lines; white-space: inherit"
        Me.txt_HAKKO.Text = "日鶏99発第9999号"
        Me.txt_HAKKO.Top = 0.4712599!
        Me.txt_HAKKO.Width = 1.390551!
        '
        'txt_HAKKO_DATE
        '
        Me.txt_HAKKO_DATE.DataField = "SEIKYU_HAKKO_DATE"
        Me.txt_HAKKO_DATE.Height = 0.1732284!
        Me.txt_HAKKO_DATE.Left = 5.60315!
        Me.txt_HAKKO_DATE.MultiLine = False
        Me.txt_HAKKO_DATE.Name = "txt_HAKKO_DATE"
        Me.txt_HAKKO_DATE.Style = "font-family: ＭＳ 明朝; font-size: 12pt; text-align: justify; text-justify: distribut" & _
            "e-all-lines; white-space: inherit"
        Me.txt_HAKKO_DATE.Text = "平成99年99月99日"
        Me.txt_HAKKO_DATE.Top = 0.6948816!
        Me.txt_HAKKO_DATE.Width = 1.390551!
        '
        'txt_KYO_KYOKAI_NAME
        '
        Me.txt_KYO_KYOKAI_NAME.DataField = "KYO_KYOKAI_NAME"
        Me.txt_KYO_KYOKAI_NAME.Height = 0.230315!
        Me.txt_KYO_KYOKAI_NAME.Left = 4.18937!
        Me.txt_KYO_KYOKAI_NAME.MultiLine = False
        Me.txt_KYO_KYOKAI_NAME.Name = "txt_KYO_KYOKAI_NAME"
        Me.txt_KYO_KYOKAI_NAME.Style = "font-family: ＭＳ 明朝; font-size: 14.25pt; text-align: right; white-space: nowrap"
        Me.txt_KYO_KYOKAI_NAME.Text = "社団法人　日本養鶏協会"
        Me.txt_KYO_KYOKAI_NAME.Top = 1.674803!
        Me.txt_KYO_KYOKAI_NAME.Width = 2.544882!
        '
        'txt_YAKUMEI
        '
        Me.txt_YAKUMEI.DataField = "KYO_YAKUMEI"
        Me.txt_YAKUMEI.Height = 0.230315!
        Me.txt_YAKUMEI.Left = 4.158662!
        Me.txt_YAKUMEI.MultiLine = False
        Me.txt_YAKUMEI.Name = "txt_YAKUMEI"
        Me.txt_YAKUMEI.Style = "font-family: ＭＳ 明朝; font-size: 14.25pt; text-align: right; white-space: nowrap"
        Me.txt_YAKUMEI.Text = "会　長"
        Me.txt_YAKUMEI.Top = 1.93937!
        Me.txt_YAKUMEI.Width = 1.266535!
        '
        'txt_KAICHO_NAM
        '
        Me.txt_KAICHO_NAM.DataField = "KYO_KAICHO_NAME"
        Me.txt_KAICHO_NAM.Height = 0.230315!
        Me.txt_KAICHO_NAM.Left = 5.603152!
        Me.txt_KAICHO_NAM.MultiLine = False
        Me.txt_KAICHO_NAM.Name = "txt_KAICHO_NAM"
        Me.txt_KAICHO_NAM.Style = "font-family: ＭＳ 明朝; font-size: 14.25pt; text-align: left; white-space: nowrap"
        Me.txt_KAICHO_NAM.Text = "竹下　正幸"
        Me.txt_KAICHO_NAM.Top = 1.93937!
        Me.txt_KAICHO_NAM.Width = 1.164173!
        '
        'HAKKO_NO_KANJI
        '
        Me.HAKKO_NO_KANJI.DataField = "HAKKO_NO_KANJI"
        Me.HAKKO_NO_KANJI.Height = 0.1732284!
        Me.HAKKO_NO_KANJI.Left = 5.60315!
        Me.HAKKO_NO_KANJI.MultiLine = False
        Me.HAKKO_NO_KANJI.Name = "HAKKO_NO_KANJI"
        Me.HAKKO_NO_KANJI.Style = "color: Magenta; font-family: ＭＳ 明朝; font-size: 12pt; text-align: left; text-justi" & _
            "fy: distribute-all-lines; white-space: nowrap"
        Me.HAKKO_NO_KANJI.Text = "日鶏"
        Me.HAKKO_NO_KANJI.Top = 0.2484252!
        Me.HAKKO_NO_KANJI.Visible = False
        Me.HAKKO_NO_KANJI.Width = 0.484252!
        '
        'SEIKYU_HAKKO_NO_NEN
        '
        Me.SEIKYU_HAKKO_NO_NEN.DataField = "SEIKYU_HAKKO_NO_NEN"
        Me.SEIKYU_HAKKO_NO_NEN.Height = 0.1732284!
        Me.SEIKYU_HAKKO_NO_NEN.Left = 6.145276!
        Me.SEIKYU_HAKKO_NO_NEN.MultiLine = False
        Me.SEIKYU_HAKKO_NO_NEN.Name = "SEIKYU_HAKKO_NO_NEN"
        Me.SEIKYU_HAKKO_NO_NEN.Style = "color: Magenta; font-family: ＭＳ 明朝; font-size: 12pt; text-align: left; text-justi" & _
            "fy: distribute-all-lines; white-space: nowrap"
        Me.SEIKYU_HAKKO_NO_NEN.Text = "99"
        Me.SEIKYU_HAKKO_NO_NEN.Top = 0.253937!
        Me.SEIKYU_HAKKO_NO_NEN.Visible = False
        Me.SEIKYU_HAKKO_NO_NEN.Width = 0.234252!
        '
        'SEIKYU_HAKKO_NO_RENBAN
        '
        Me.SEIKYU_HAKKO_NO_RENBAN.DataField = "SEIKYU_HAKKO_NO_RENBAN"
        Me.SEIKYU_HAKKO_NO_RENBAN.Height = 0.1732284!
        Me.SEIKYU_HAKKO_NO_RENBAN.Left = 6.413386!
        Me.SEIKYU_HAKKO_NO_RENBAN.MultiLine = False
        Me.SEIKYU_HAKKO_NO_RENBAN.Name = "SEIKYU_HAKKO_NO_RENBAN"
        Me.SEIKYU_HAKKO_NO_RENBAN.Style = "color: Magenta; font-family: ＭＳ 明朝; font-size: 12pt; text-align: left; text-justi" & _
            "fy: distribute-all-lines; white-space: nowrap"
        Me.SEIKYU_HAKKO_NO_RENBAN.Text = "9999"
        Me.SEIKYU_HAKKO_NO_RENBAN.Top = 0.253937!
        Me.SEIKYU_HAKKO_NO_RENBAN.Visible = False
        Me.SEIKYU_HAKKO_NO_RENBAN.Width = 0.484252!
        '
        'JIMUITAKU_CD
        '
        Me.JIMUITAKU_CD.DataField = "JIMUITAKU_CD"
        Me.JIMUITAKU_CD.Height = 0.1979167!
        Me.JIMUITAKU_CD.Left = 6.133859!
        Me.JIMUITAKU_CD.MultiLine = False
        Me.JIMUITAKU_CD.Name = "JIMUITAKU_CD"
        Me.JIMUITAKU_CD.OutputFormat = resources.GetString("JIMUITAKU_CD.OutputFormat")
        Me.JIMUITAKU_CD.Style = "color: Magenta; font-family: ＭＳ 明朝; font-size: 11pt; text-align: right; vertical-" & _
            "align: middle; white-space: nowrap; ddo-char-set: 1"
        Me.JIMUITAKU_CD.Text = "999"
        Me.JIMUITAKU_CD.Top = 6.272048!
        Me.JIMUITAKU_CD.Visible = False
        Me.JIMUITAKU_CD.Width = 0.2456694!
        '
        'BANK_INJI_KBN
        '
        Me.BANK_INJI_KBN.DataField = "BANK_INJI_KBN"
        Me.BANK_INJI_KBN.Height = 0.1979167!
        Me.BANK_INJI_KBN.Left = 6.521652!
        Me.BANK_INJI_KBN.MultiLine = False
        Me.BANK_INJI_KBN.Name = "BANK_INJI_KBN"
        Me.BANK_INJI_KBN.OutputFormat = resources.GetString("BANK_INJI_KBN.OutputFormat")
        Me.BANK_INJI_KBN.Style = "color: Magenta; font-family: ＭＳ 明朝; font-size: 11pt; text-align: right; vertical-" & _
            "align: middle; white-space: nowrap; ddo-char-set: 1"
        Me.BANK_INJI_KBN.Text = "9"
        Me.BANK_INJI_KBN.Top = 6.272048!
        Me.BANK_INJI_KBN.Visible = False
        Me.BANK_INJI_KBN.Width = 0.2456694!
        '
        'txt_SaiHakko
        '
        Me.txt_SaiHakko.Height = 0.1732284!
        Me.txt_SaiHakko.Left = 3.798425!
        Me.txt_SaiHakko.MultiLine = False
        Me.txt_SaiHakko.Name = "txt_SaiHakko"
        Me.txt_SaiHakko.Style = "color: Fuchsia; font-family: ＭＳ 明朝; font-size: 9.75pt; white-space: nowrap; ddo-c" & _
            "har-set: 1"
        Me.txt_SaiHakko.Text = "9"
        Me.txt_SaiHakko.Top = 1.26811!
        Me.txt_SaiHakko.Visible = False
        Me.txt_SaiHakko.Width = 0.1255906!
        '
        'Line32
        '
        Me.Line32.Height = 0.0!
        Me.Line32.Left = 7.480315!
        Me.Line32.LineWeight = 1.0!
        Me.Line32.Name = "Line32"
        Me.Line32.Top = 3.818898!
        Me.Line32.Width = 0.3791347!
        Me.Line32.X1 = 7.480315!
        Me.Line32.X2 = 7.85945!
        Me.Line32.Y1 = 3.818898!
        Me.Line32.Y2 = 3.818898!
        '
        'txt_FURI_FT1
        '
        Me.txt_FURI_FT1.Height = 0.4102361!
        Me.txt_FURI_FT1.Left = 1.331496!
        Me.txt_FURI_FT1.LineSpacing = 2.0!
        Me.txt_FURI_FT1.Name = "txt_FURI_FT1"
        Me.txt_FURI_FT1.Style = "font-family: ＭＳ 明朝; font-size: 10pt; text-align: left; vertical-align: top; white" & _
            "-space: nowrap; ddo-char-set: 1"
        Me.txt_FURI_FT1.Text = "※なお、事務処理の都合上、若干の日程のズレが生じる場合がございます。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "　あらかじめご了承ください。"
        Me.txt_FURI_FT1.Top = 7.549563!
        Me.txt_FURI_FT1.Width = 4.882677!
        '
        'txt_ITAKU_NAME
        '
        Me.txt_ITAKU_NAME.DataField = "ITAKU_NAME"
        Me.txt_ITAKU_NAME.Height = 0.1979167!
        Me.txt_ITAKU_NAME.Left = 1.610234!
        Me.txt_ITAKU_NAME.MultiLine = False
        Me.txt_ITAKU_NAME.Name = "txt_ITAKU_NAME"
        Me.txt_ITAKU_NAME.Style = "font-family: ＭＳ 明朝; font-size: 11pt; text-align: left; vertical-align: top; white" & _
            "-space: nowrap; ddo-char-set: 1"
        Me.txt_ITAKU_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.txt_ITAKU_NAME.Top = 6.291337!
        Me.txt_ITAKU_NAME.Width = 4.298426!
        '
        'lbl_ITAKU_NAME
        '
        Me.lbl_ITAKU_NAME.Height = 0.1968504!
        Me.lbl_ITAKU_NAME.HyperLink = Nothing
        Me.lbl_ITAKU_NAME.Left = 0.5106275!
        Me.lbl_ITAKU_NAME.MultiLine = False
        Me.lbl_ITAKU_NAME.Name = "lbl_ITAKU_NAME"
        Me.lbl_ITAKU_NAME.Style = "font-family: ＭＳ ゴシック; font-size: 11pt; text-align: left; vertical-align: top; whi" & _
            "te-space: nowrap; ddo-char-set: 1"
        Me.lbl_ITAKU_NAME.Text = "事務委託先名："
        Me.lbl_ITAKU_NAME.Top = 6.291337!
        Me.lbl_ITAKU_NAME.Width = 1.101575!
        '
        'txt_NOFUKIGEN_DATE
        '
        Me.txt_NOFUKIGEN_DATE.DataField = "NOFUKIGEN_DATE"
        Me.txt_NOFUKIGEN_DATE.Height = 0.1979167!
        Me.txt_NOFUKIGEN_DATE.Left = 1.935037!
        Me.txt_NOFUKIGEN_DATE.MultiLine = False
        Me.txt_NOFUKIGEN_DATE.Name = "txt_NOFUKIGEN_DATE"
        Me.txt_NOFUKIGEN_DATE.Style = "font-family: ＭＳ 明朝; font-size: 10pt; text-align: left; vertical-align: top; white" & _
            "-space: nowrap; ddo-char-set: 1"
        Me.txt_NOFUKIGEN_DATE.Text = "平成９９年９９月９９日"
        Me.txt_NOFUKIGEN_DATE.Top = 6.558648!
        Me.txt_NOFUKIGEN_DATE.Width = 1.790945!
        '
        'txt_FURI_BANK_NAME
        '
        Me.txt_FURI_BANK_NAME.DataField = "FURI_BANK_NAME"
        Me.txt_FURI_BANK_NAME.Height = 0.1979167!
        Me.txt_FURI_BANK_NAME.Left = 2.763384!
        Me.txt_FURI_BANK_NAME.MultiLine = False
        Me.txt_FURI_BANK_NAME.Name = "txt_FURI_BANK_NAME"
        Me.txt_FURI_BANK_NAME.Style = "font-family: ＭＳ 明朝; font-size: 10pt; text-align: left; vertical-align: top; white" & _
            "-space: nowrap; ddo-char-set: 1"
        Me.txt_FURI_BANK_NAME.Text = "三菱東京ＵＦＪ銀行＠" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txt_FURI_BANK_NAME.Top = 6.758639!
        Me.txt_FURI_BANK_NAME.Width = 4.649608!
        '
        'txt_FURI_SITEN_NAME
        '
        Me.txt_FURI_SITEN_NAME.DataField = "FURI_SITEN_NAME"
        Me.txt_FURI_SITEN_NAME.Height = 0.1979167!
        Me.txt_FURI_SITEN_NAME.Left = 2.763384!
        Me.txt_FURI_SITEN_NAME.MultiLine = False
        Me.txt_FURI_SITEN_NAME.Name = "txt_FURI_SITEN_NAME"
        Me.txt_FURI_SITEN_NAME.Style = "font-family: ＭＳ 明朝; font-size: 10pt; text-align: left; vertical-align: top; white" & _
            "-space: nowrap; ddo-char-set: 1"
        Me.txt_FURI_SITEN_NAME.Text = "八重洲通支店＠" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txt_FURI_SITEN_NAME.Top = 6.956665!
        Me.txt_FURI_SITEN_NAME.Width = 4.649608!
        '
        'txt_FURI_KOZA_SYUBETU
        '
        Me.txt_FURI_KOZA_SYUBETU.DataField = "FURI_KOZA_SYUBETU"
        Me.txt_FURI_KOZA_SYUBETU.Height = 0.1979167!
        Me.txt_FURI_KOZA_SYUBETU.Left = 2.763384!
        Me.txt_FURI_KOZA_SYUBETU.MultiLine = False
        Me.txt_FURI_KOZA_SYUBETU.Name = "txt_FURI_KOZA_SYUBETU"
        Me.txt_FURI_KOZA_SYUBETU.Style = "font-family: ＭＳ 明朝; font-size: 10pt; text-align: left; vertical-align: top; white" & _
            "-space: nowrap; ddo-char-set: 1"
        Me.txt_FURI_KOZA_SYUBETU.Text = "（そのた）"
        Me.txt_FURI_KOZA_SYUBETU.Top = 7.154698!
        Me.txt_FURI_KOZA_SYUBETU.Width = 0.7279527!
        '
        'txt_FURI_KOZA_NO_N
        '
        Me.txt_FURI_KOZA_NO_N.DataField = "FURI_KOZA_NO_N"
        Me.txt_FURI_KOZA_NO_N.Height = 0.1979167!
        Me.txt_FURI_KOZA_NO_N.Left = 4.233857!
        Me.txt_FURI_KOZA_NO_N.MultiLine = False
        Me.txt_FURI_KOZA_NO_N.Name = "txt_FURI_KOZA_NO_N"
        Me.txt_FURI_KOZA_NO_N.Style = "font-family: ＭＳ 明朝; font-size: 10pt; text-align: left; vertical-align: top; white" & _
            "-space: nowrap; ddo-char-set: 1"
        Me.txt_FURI_KOZA_NO_N.Text = "９９９９９９９"
        Me.txt_FURI_KOZA_NO_N.Top = 7.155871!
        Me.txt_FURI_KOZA_NO_N.Width = 1.198032!
        '
        'txt_FURI_KOZA_MEIGI
        '
        Me.txt_FURI_KOZA_MEIGI.DataField = "FURI_KOZA_MEIGI"
        Me.txt_FURI_KOZA_MEIGI.Height = 0.1979167!
        Me.txt_FURI_KOZA_MEIGI.Left = 2.762597!
        Me.txt_FURI_KOZA_MEIGI.MultiLine = False
        Me.txt_FURI_KOZA_MEIGI.Name = "txt_FURI_KOZA_MEIGI"
        Me.txt_FURI_KOZA_MEIGI.Style = "font-family: ＭＳ 明朝; font-size: 10pt; text-align: left; vertical-align: top; white" & _
            "-space: nowrap; ddo-char-set: 1"
        Me.txt_FURI_KOZA_MEIGI.Text = "一般社団法人　日本養鶏協会＠"
        Me.txt_FURI_KOZA_MEIGI.Top = 7.351534!
        Me.txt_FURI_KOZA_MEIGI.Width = 4.650393!
        '
        'lbl_FURI_BANK_NAME
        '
        Me.lbl_FURI_BANK_NAME.Height = 0.1968504!
        Me.lbl_FURI_BANK_NAME.HyperLink = Nothing
        Me.lbl_FURI_BANK_NAME.Left = 1.935037!
        Me.lbl_FURI_BANK_NAME.MultiLine = False
        Me.lbl_FURI_BANK_NAME.Name = "lbl_FURI_BANK_NAME"
        Me.lbl_FURI_BANK_NAME.Style = "font-family: ＭＳ 明朝; font-size: 10pt; text-align: justify; text-justify: distribut" & _
            "e-all-lines; vertical-align: top; white-space: nowrap; ddo-char-set: 1"
        Me.lbl_FURI_BANK_NAME.Text = "金融機関名"
        Me.lbl_FURI_BANK_NAME.Top = 6.757857!
        Me.lbl_FURI_BANK_NAME.Width = 0.7677166!
        '
        'lbl_FURI_SITEN_NAME
        '
        Me.lbl_FURI_SITEN_NAME.Height = 0.1968504!
        Me.lbl_FURI_SITEN_NAME.HyperLink = Nothing
        Me.lbl_FURI_SITEN_NAME.Left = 1.935037!
        Me.lbl_FURI_SITEN_NAME.MultiLine = False
        Me.lbl_FURI_SITEN_NAME.Name = "lbl_FURI_SITEN_NAME"
        Me.lbl_FURI_SITEN_NAME.Style = "font-family: ＭＳ 明朝; font-size: 10pt; text-align: justify; text-justify: distribut" & _
            "e-all-lines; vertical-align: top; white-space: nowrap; ddo-char-set: 1"
        Me.lbl_FURI_SITEN_NAME.Text = "支店名"
        Me.lbl_FURI_SITEN_NAME.Top = 6.954704!
        Me.lbl_FURI_SITEN_NAME.Width = 0.7677166!
        '
        'lbl_FURI_KOZA_SYUBETU
        '
        Me.lbl_FURI_KOZA_SYUBETU.Height = 0.1968504!
        Me.lbl_FURI_KOZA_SYUBETU.HyperLink = Nothing
        Me.lbl_FURI_KOZA_SYUBETU.Left = 1.935037!
        Me.lbl_FURI_KOZA_SYUBETU.MultiLine = False
        Me.lbl_FURI_KOZA_SYUBETU.Name = "lbl_FURI_KOZA_SYUBETU"
        Me.lbl_FURI_KOZA_SYUBETU.Style = "font-family: ＭＳ 明朝; font-size: 10pt; text-align: justify; text-justify: distribut" & _
            "e-all-lines; vertical-align: top; white-space: nowrap; ddo-char-set: 1"
        Me.lbl_FURI_KOZA_SYUBETU.Text = "口座種別"
        Me.lbl_FURI_KOZA_SYUBETU.Top = 7.154691!
        Me.lbl_FURI_KOZA_SYUBETU.Width = 0.7677166!
        '
        'lbl_FURI_KOZA_MEIGI
        '
        Me.lbl_FURI_KOZA_MEIGI.Height = 0.1968504!
        Me.lbl_FURI_KOZA_MEIGI.HyperLink = Nothing
        Me.lbl_FURI_KOZA_MEIGI.Left = 1.935037!
        Me.lbl_FURI_KOZA_MEIGI.MultiLine = False
        Me.lbl_FURI_KOZA_MEIGI.Name = "lbl_FURI_KOZA_MEIGI"
        Me.lbl_FURI_KOZA_MEIGI.Style = "font-family: ＭＳ 明朝; font-size: 10pt; text-align: justify; text-justify: distribut" & _
            "e-all-lines; vertical-align: top; white-space: nowrap; ddo-char-set: 1"
        Me.lbl_FURI_KOZA_MEIGI.Text = "口座名義"
        Me.lbl_FURI_KOZA_MEIGI.Top = 7.351542!
        Me.lbl_FURI_KOZA_MEIGI.Width = 0.7677166!
        '
        'lbl_FURI_KOZA_NO_N
        '
        Me.lbl_FURI_KOZA_NO_N.Height = 0.1968504!
        Me.lbl_FURI_KOZA_NO_N.HyperLink = Nothing
        Me.lbl_FURI_KOZA_NO_N.Left = 3.581888!
        Me.lbl_FURI_KOZA_NO_N.MultiLine = False
        Me.lbl_FURI_KOZA_NO_N.Name = "lbl_FURI_KOZA_NO_N"
        Me.lbl_FURI_KOZA_NO_N.Style = "font-family: ＭＳ 明朝; font-size: 10pt; text-align: left; vertical-align: top; white" & _
            "-space: nowrap; ddo-char-set: 1"
        Me.lbl_FURI_KOZA_NO_N.Text = "口座番号"
        Me.lbl_FURI_KOZA_NO_N.Top = 7.155871!
        Me.lbl_FURI_KOZA_NO_N.Width = 0.580315!
        '
        'lbl_NOFUKIGEN_DATE23
        '
        Me.lbl_NOFUKIGEN_DATE23.Height = 0.1968504!
        Me.lbl_NOFUKIGEN_DATE23.HyperLink = Nothing
        Me.lbl_NOFUKIGEN_DATE23.Left = 1.720077!
        Me.lbl_NOFUKIGEN_DATE23.MultiLine = False
        Me.lbl_NOFUKIGEN_DATE23.Name = "lbl_NOFUKIGEN_DATE23"
        Me.lbl_NOFUKIGEN_DATE23.Style = "font-family: ＭＳ 明朝; font-size: 10pt; text-align: left; text-justify: auto; vertic" & _
            "al-align: top; white-space: nowrap; ddo-char-set: 1"
        Me.lbl_NOFUKIGEN_DATE23.Text = "：" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lbl_NOFUKIGEN_DATE23.Top = 6.558648!
        Me.lbl_NOFUKIGEN_DATE23.Width = 0.1748026!
        '
        'lbl_FURI_BANK_TITLE23
        '
        Me.lbl_FURI_BANK_TITLE23.Height = 0.1968504!
        Me.lbl_FURI_BANK_TITLE23.HyperLink = Nothing
        Me.lbl_FURI_BANK_TITLE23.Left = 1.718896!
        Me.lbl_FURI_BANK_TITLE23.MultiLine = False
        Me.lbl_FURI_BANK_TITLE23.Name = "lbl_FURI_BANK_TITLE23"
        Me.lbl_FURI_BANK_TITLE23.Style = "font-family: ＭＳ 明朝; font-size: 10pt; text-align: left; text-justify: auto; vertic" & _
            "al-align: top; white-space: nowrap; ddo-char-set: 1"
        Me.lbl_FURI_BANK_TITLE23.Text = "："
        Me.lbl_FURI_BANK_TITLE23.Top = 6.757857!
        Me.lbl_FURI_BANK_TITLE23.Width = 0.1759838!
        '
        'lbl_NOFUKIGEN_DATE22
        '
        Me.lbl_NOFUKIGEN_DATE22.Height = 0.1968504!
        Me.lbl_NOFUKIGEN_DATE22.HyperLink = Nothing
        Me.lbl_NOFUKIGEN_DATE22.Left = 0.7192886!
        Me.lbl_NOFUKIGEN_DATE22.MultiLine = False
        Me.lbl_NOFUKIGEN_DATE22.Name = "lbl_NOFUKIGEN_DATE22"
        Me.lbl_NOFUKIGEN_DATE22.Style = "font-family: ＭＳ ゴシック; font-size: 9.75pt; text-align: justify; text-justify: distr" & _
            "ibute-all-lines; vertical-align: top; white-space: nowrap; ddo-char-set: 128"
        Me.lbl_NOFUKIGEN_DATE22.Text = "お振込み予定日"
        Me.lbl_NOFUKIGEN_DATE22.Top = 6.558648!
        Me.lbl_NOFUKIGEN_DATE22.Width = 1.029134!
        '
        'lbl_FURI_BANK_TITLE22
        '
        Me.lbl_FURI_BANK_TITLE22.Height = 0.1968504!
        Me.lbl_FURI_BANK_TITLE22.HyperLink = Nothing
        Me.lbl_FURI_BANK_TITLE22.Left = 0.7181073!
        Me.lbl_FURI_BANK_TITLE22.MultiLine = False
        Me.lbl_FURI_BANK_TITLE22.Name = "lbl_FURI_BANK_TITLE22"
        Me.lbl_FURI_BANK_TITLE22.Style = "font-family: ＭＳ ゴシック; font-size: 9.75pt; text-align: justify; text-justify: distr" & _
            "ibute-all-lines; vertical-align: top; white-space: nowrap; ddo-char-set: 128"
        Me.lbl_FURI_BANK_TITLE22.Text = "お振込み口座"
        Me.lbl_FURI_BANK_TITLE22.Top = 6.757857!
        Me.lbl_FURI_BANK_TITLE22.Width = 1.030315!
        '
        'Label19
        '
        Me.Label19.Height = 0.2165354!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 0.4996063!
        Me.Label19.MultiLine = False
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "font-family: ＭＳ ゴシック; font-size: 11pt; text-align: left; vertical-align: middle; " & _
            "white-space: nowrap; ddo-char-set: 1"
        Me.Label19.Text = "　返還金額　(Ａ) + (Ｂ)"
        Me.Label19.Top = 5.736615!
        Me.Label19.Width = 4.667717!
        '
        'TextBox27
        '
        Me.TextBox27.DataField = "HENKAN_KAKUTEI_KIN"
        Me.TextBox27.Height = 0.2165354!
        Me.TextBox27.Left = 5.747639!
        Me.TextBox27.MultiLine = False
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.OutputFormat = resources.GetString("TextBox27.OutputFormat")
        Me.TextBox27.Style = "font-family: ＭＳ ゴシック; font-size: 11.25pt; text-align: right; vertical-align: midd" & _
            "le; ddo-char-set: 128"
        Me.TextBox27.Text = "99,999,999"
        Me.TextBox27.Top = 5.736615!
        Me.TextBox27.Width = 0.9023625!
        '
        'Line1
        '
        Me.Line1.Height = 0.001574993!
        Me.Line1.Left = 0.498819!
        Me.Line1.LineWeight = 3.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 5.633467!
        Me.Line1.Width = 6.389765!
        Me.Line1.X1 = 0.498819!
        Me.Line1.X2 = 6.888584!
        Me.Line1.Y1 = 5.633467!
        Me.Line1.Y2 = 5.635042!
        '
        'Line4
        '
        Me.Line4.Height = 0.001574039!
        Me.Line4.Left = 0.498819!
        Me.Line4.LineWeight = 3.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 6.067718!
        Me.Line4.Width = 6.389765!
        Me.Line4.X1 = 0.498819!
        Me.Line4.X2 = 6.888584!
        Me.Line4.Y1 = 6.069292!
        Me.Line4.Y2 = 6.067718!
        '
        'Line7
        '
        Me.Line7.Height = 0.001574993!
        Me.Line7.Left = 0.498819!
        Me.Line7.LineWeight = 2.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 5.683071!
        Me.Line7.Width = 6.389765!
        Me.Line7.X1 = 0.498819!
        Me.Line7.X2 = 6.888584!
        Me.Line7.Y1 = 5.683071!
        Me.Line7.Y2 = 5.684646!
        '
        'Line10
        '
        Me.Line10.Height = 0.001573086!
        Me.Line10.Left = 0.498819!
        Me.Line10.LineWeight = 2.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 6.012205!
        Me.Line10.Width = 6.389765!
        Me.Line10.X1 = 0.498819!
        Me.Line10.X2 = 6.888584!
        Me.Line10.Y1 = 6.012205!
        Me.Line10.Y2 = 6.013778!
        '
        'Line26
        '
        Me.Line26.Height = 0.3307071!
        Me.Line26.Left = 6.887797!
        Me.Line26.LineWeight = 2.0!
        Me.Line26.Name = "Line26"
        Me.Line26.Top = 5.683071!
        Me.Line26.Width = 0.0007872581!
        Me.Line26.X1 = 6.887797!
        Me.Line26.X2 = 6.888584!
        Me.Line26.Y1 = 5.683071!
        Me.Line26.Y2 = 6.013778!
        '
        'Line27
        '
        Me.Line27.Height = 0.3307071!
        Me.Line27.Left = 0.498819!
        Me.Line27.LineWeight = 2.0!
        Me.Line27.Name = "Line27"
        Me.Line27.Top = 5.683071!
        Me.Line27.Width = 0.0!
        Me.Line27.X1 = 0.498819!
        Me.Line27.X2 = 0.498819!
        Me.Line27.Y1 = 5.683071!
        Me.Line27.Y2 = 6.013778!
        '
        'Line28
        '
        Me.Line28.Height = 0.330708!
        Me.Line28.Left = 5.572049!
        Me.Line28.LineWeight = 2.0!
        Me.Line28.Name = "Line28"
        Me.Line28.Top = 5.683075!
        Me.Line28.Width = 0.000784874!
        Me.Line28.X1 = 5.572049!
        Me.Line28.X2 = 5.572834!
        Me.Line28.Y1 = 5.683075!
        Me.Line28.Y2 = 6.013783!
        '
        'Line33
        '
        Me.Line33.Height = 0.001568317!
        Me.Line33.Left = 0.498819!
        Me.Line33.LineWeight = 2.0!
        Me.Line33.Name = "Line33"
        Me.Line33.Top = 4.582678!
        Me.Line33.Width = 6.389765!
        Me.Line33.X1 = 0.498819!
        Me.Line33.X2 = 6.888584!
        Me.Line33.Y1 = 4.582678!
        Me.Line33.Y2 = 4.584246!
        '
        'lbl_HD1
        '
        Me.lbl_HD1.Height = 0.200786!
        Me.lbl_HD1.HyperLink = Nothing
        Me.lbl_HD1.Left = 0.6007875!
        Me.lbl_HD1.MultiLine = False
        Me.lbl_HD1.Name = "lbl_HD1"
        Me.lbl_HD1.Style = "font-family: ＭＳ ゴシック; font-size: 11pt; text-align: center; vertical-align: middle" & _
            "; white-space: nowrap; ddo-char-set: 1"
        Me.lbl_HD1.Text = "第９期生産者積立金（既存分）　返還金"
        Me.lbl_HD1.Top = 4.595669!
        Me.lbl_HD1.Width = 4.868898!
        '
        'Label20
        '
        Me.Label20.Height = 0.200786!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 5.594096!
        Me.Label20.MultiLine = False
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "font-family: ＭＳ ゴシック; font-size: 11pt; text-align: center; vertical-align: middle" & _
            "; white-space: nowrap; ddo-char-set: 1"
        Me.Label20.Text = "返還金額(Ａ)"
        Me.Label20.Top = 4.595668!
        Me.Label20.Width = 1.295275!
        '
        'lbl_HD2
        '
        Me.lbl_HD2.Height = 0.1771654!
        Me.lbl_HD2.HyperLink = Nothing
        Me.lbl_HD2.Left = 0.6007875!
        Me.lbl_HD2.MultiLine = False
        Me.lbl_HD2.Name = "lbl_HD2"
        Me.lbl_HD2.Style = "font-family: ＭＳ ゴシック; font-size: 11pt; text-align: left; vertical-align: middle; " & _
            "white-space: nowrap; ddo-char-set: 1"
        Me.lbl_HD2.Text = "第９期積立金(既存分)"
        Me.lbl_HD2.Top = 4.827165!
        Me.lbl_HD2.Width = 1.751181!
        '
        'TextBox1
        '
        Me.TextBox1.DataField = "TUMITATE_KIN_KEI_1"
        Me.TextBox1.Height = 0.1771654!
        Me.TextBox1.Left = 2.594095!
        Me.TextBox1.MultiLine = False
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
        Me.TextBox1.Style = "font-family: ＭＳ 明朝; font-size: 11pt; text-align: right; vertical-align: middle; w" & _
            "hite-space: nowrap; ddo-char-set: 1"
        Me.TextBox1.Text = "999,999,999"
        Me.TextBox1.Top = 4.827167!
        Me.TextBox1.Width = 0.9948819!
        '
        'TextBox2
        '
        Me.TextBox2.DataField = "HENKAN_KEISU_1"
        Me.TextBox2.Height = 0.1771654!
        Me.TextBox2.Left = 4.036222!
        Me.TextBox2.MultiLine = False
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "font-family: ＭＳ 明朝; font-size: 11pt; text-align: right; vertical-align: middle; w" & _
            "hite-space: nowrap; ddo-char-set: 1"
        Me.TextBox2.Text = "9.999999"
        Me.TextBox2.Top = 4.827167!
        Me.TextBox2.Width = 0.7748027!
        '
        'Label23
        '
        Me.Label23.Height = 0.1771654!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 3.728346!
        Me.Label23.MultiLine = False
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "font-family: ＭＳ ゴシック; font-size: 11pt; text-align: left; vertical-align: middle; " & _
            "white-space: nowrap; ddo-char-set: 1"
        Me.Label23.Text = "×"
        Me.Label23.Top = 4.827167!
        Me.Label23.Width = 0.2283465!
        '
        'TextBox4
        '
        Me.TextBox4.DataField = "HENKAN_KAKUTEI_KIN_1"
        Me.TextBox4.Height = 0.1771654!
        Me.TextBox4.Left = 5.65512!
        Me.TextBox4.MultiLine = False
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "font-family: ＭＳ 明朝; font-size: 11pt; text-align: right; vertical-align: middle; w" & _
            "hite-space: nowrap; ddo-char-set: 1"
        Me.TextBox4.Text = "999,999,999"
        Me.TextBox4.Top = 4.827165!
        Me.TextBox4.Width = 0.9948819!
        '
        'Line34
        '
        Me.Line34.Height = 0.001567841!
        Me.Line34.Left = 0.498819!
        Me.Line34.LineWeight = 2.0!
        Me.Line34.Name = "Line34"
        Me.Line34.Top = 5.035435!
        Me.Line34.Width = 6.389765!
        Me.Line34.X1 = 0.498819!
        Me.Line34.X2 = 6.888584!
        Me.Line34.Y1 = 5.035435!
        Me.Line34.Y2 = 5.037003!
        '
        'Line35
        '
        Me.Line35.Height = 0.4527559!
        Me.Line35.Left = 0.4996063!
        Me.Line35.LineWeight = 2.0!
        Me.Line35.Name = "Line35"
        Me.Line35.Tag = "13.53"
        Me.Line35.Top = 4.58386!
        Me.Line35.Width = 0.0!
        Me.Line35.X1 = 0.4996063!
        Me.Line35.X2 = 0.4996063!
        Me.Line35.Y1 = 4.58386!
        Me.Line35.Y2 = 5.036616!
        '
        'Line36
        '
        Me.Line36.Height = 0.4523621!
        Me.Line36.Left = 6.887797!
        Me.Line36.LineWeight = 2.0!
        Me.Line36.Name = "Line36"
        Me.Line36.Tag = "13.53"
        Me.Line36.Top = 4.584254!
        Me.Line36.Width = 0.0!
        Me.Line36.X1 = 6.887797!
        Me.Line36.X2 = 6.887797!
        Me.Line36.Y1 = 4.584254!
        Me.Line36.Y2 = 5.036616!
        '
        'Line37
        '
        Me.Line37.Height = 0.4523621!
        Me.Line37.Left = 5.574411!
        Me.Line37.LineWeight = 2.0!
        Me.Line37.Name = "Line37"
        Me.Line37.Tag = "13.53"
        Me.Line37.Top = 4.584254!
        Me.Line37.Width = 0.0!
        Me.Line37.X1 = 5.574411!
        Me.Line37.X2 = 5.574411!
        Me.Line37.Y1 = 4.584254!
        Me.Line37.Y2 = 5.036616!
        '
        'Line38
        '
        Me.Line38.Height = 0.001571178!
        Me.Line38.Left = 0.4996063!
        Me.Line38.LineWeight = 2.0!
        Me.Line38.Name = "Line38"
        Me.Line38.Top = 4.806694!
        Me.Line38.Width = 6.389765!
        Me.Line38.X1 = 0.4996063!
        Me.Line38.X2 = 6.889371!
        Me.Line38.Y1 = 4.806694!
        Me.Line38.Y2 = 4.808265!
        '
        'Line11
        '
        Me.Line11.Height = 0.001568794!
        Me.Line11.Left = 0.498819!
        Me.Line11.LineWeight = 2.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 5.083465!
        Me.Line11.Width = 6.389765!
        Me.Line11.X1 = 0.498819!
        Me.Line11.X2 = 6.888584!
        Me.Line11.Y1 = 5.083465!
        Me.Line11.Y2 = 5.085034!
        '
        'lbl_HD3
        '
        Me.lbl_HD3.Height = 0.200786!
        Me.lbl_HD3.HyperLink = Nothing
        Me.lbl_HD3.Left = 0.6007875!
        Me.lbl_HD3.MultiLine = False
        Me.lbl_HD3.Name = "lbl_HD3"
        Me.lbl_HD3.Style = "font-family: ＭＳ ゴシック; font-size: 11pt; text-align: center; vertical-align: middle" & _
            "; white-space: nowrap; ddo-char-set: 1"
        Me.lbl_HD3.Text = "第９期生産者積立金（追加分）　返還金"
        Me.lbl_HD3.Top = 5.096456!
        Me.lbl_HD3.Width = 4.868898!
        '
        'Label3
        '
        Me.Label3.Height = 0.200786!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 5.594096!
        Me.Label3.MultiLine = False
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-family: ＭＳ ゴシック; font-size: 11pt; text-align: center; vertical-align: middle" & _
            "; white-space: nowrap; ddo-char-set: 1"
        Me.Label3.Text = "返還金額(Ｂ)"
        Me.Label3.Top = 5.096456!
        Me.Label3.Width = 1.295275!
        '
        'lbl_HD4
        '
        Me.lbl_HD4.Height = 0.1771654!
        Me.lbl_HD4.HyperLink = Nothing
        Me.lbl_HD4.Left = 0.6007875!
        Me.lbl_HD4.MultiLine = False
        Me.lbl_HD4.Name = "lbl_HD4"
        Me.lbl_HD4.Style = "font-family: ＭＳ ゴシック; font-size: 11pt; text-align: left; vertical-align: middle; " & _
            "white-space: nowrap; ddo-char-set: 1"
        Me.lbl_HD4.Text = "第９期積立金(追加分)"
        Me.lbl_HD4.Top = 5.327953!
        Me.lbl_HD4.Width = 1.751181!
        '
        'TextBox3
        '
        Me.TextBox3.DataField = "TUMITATE_KIN_KEI_2"
        Me.TextBox3.Height = 0.1771654!
        Me.TextBox3.Left = 2.594095!
        Me.TextBox3.MultiLine = False
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "font-family: ＭＳ 明朝; font-size: 11pt; text-align: right; vertical-align: middle; w" & _
            "hite-space: nowrap; ddo-char-set: 1"
        Me.TextBox3.Text = "999,999,999"
        Me.TextBox3.Top = 5.327953!
        Me.TextBox3.Width = 0.9948819!
        '
        'TextBox5
        '
        Me.TextBox5.DataField = "HENKAN_KEISU_2"
        Me.TextBox5.Height = 0.1771654!
        Me.TextBox5.Left = 4.036222!
        Me.TextBox5.MultiLine = False
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
        Me.TextBox5.Style = "font-family: ＭＳ 明朝; font-size: 11pt; text-align: right; vertical-align: middle; w" & _
            "hite-space: nowrap; ddo-char-set: 1"
        Me.TextBox5.Text = "9.999999"
        Me.TextBox5.Top = 5.327953!
        Me.TextBox5.Width = 0.7748027!
        '
        'Label5
        '
        Me.Label5.Height = 0.1771654!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 3.728346!
        Me.Label5.MultiLine = False
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-family: ＭＳ ゴシック; font-size: 11pt; text-align: left; vertical-align: middle; " & _
            "white-space: nowrap; ddo-char-set: 1"
        Me.Label5.Text = "×"
        Me.Label5.Top = 5.327953!
        Me.Label5.Width = 0.2283465!
        '
        'TextBox6
        '
        Me.TextBox6.DataField = "HENKAN_KAKUTEI_KIN_2"
        Me.TextBox6.Height = 0.1771654!
        Me.TextBox6.Left = 5.655121!
        Me.TextBox6.MultiLine = False
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "font-family: ＭＳ 明朝; font-size: 11pt; text-align: right; vertical-align: middle; w" & _
            "hite-space: nowrap; ddo-char-set: 1"
        Me.TextBox6.Text = "999,999,999"
        Me.TextBox6.Top = 5.327953!
        Me.TextBox6.Width = 0.9948819!
        '
        'Line12
        '
        Me.Line12.Height = 0.001566887!
        Me.Line12.Left = 0.498819!
        Me.Line12.LineWeight = 2.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 5.536222!
        Me.Line12.Width = 6.389765!
        Me.Line12.X1 = 0.498819!
        Me.Line12.X2 = 6.888584!
        Me.Line12.Y1 = 5.536222!
        Me.Line12.Y2 = 5.537789!
        '
        'Line13
        '
        Me.Line13.Height = 0.4527559!
        Me.Line13.Left = 0.4996063!
        Me.Line13.LineWeight = 2.0!
        Me.Line13.Name = "Line13"
        Me.Line13.Tag = "13.53"
        Me.Line13.Top = 5.084647!
        Me.Line13.Width = 0.0!
        Me.Line13.X1 = 0.4996063!
        Me.Line13.X2 = 0.4996063!
        Me.Line13.Y1 = 5.084647!
        Me.Line13.Y2 = 5.537403!
        '
        'Line14
        '
        Me.Line14.Height = 0.4523611!
        Me.Line14.Left = 5.574411!
        Me.Line14.LineWeight = 2.0!
        Me.Line14.Name = "Line14"
        Me.Line14.Tag = "13.53"
        Me.Line14.Top = 5.085042!
        Me.Line14.Width = 0.0!
        Me.Line14.X1 = 5.574411!
        Me.Line14.X2 = 5.574411!
        Me.Line14.Y1 = 5.085042!
        Me.Line14.Y2 = 5.537403!
        '
        'Line15
        '
        Me.Line15.Height = 0.001572132!
        Me.Line15.Left = 0.4996063!
        Me.Line15.LineWeight = 2.0!
        Me.Line15.Name = "Line15"
        Me.Line15.Top = 5.30748!
        Me.Line15.Width = 6.389765!
        Me.Line15.X1 = 0.4996063!
        Me.Line15.X2 = 6.889371!
        Me.Line15.Y1 = 5.30748!
        Me.Line15.Y2 = 5.309052!
        '
        'Line16
        '
        Me.Line16.Height = 0.4523611!
        Me.Line16.Left = 6.887797!
        Me.Line16.LineWeight = 2.0!
        Me.Line16.Name = "Line16"
        Me.Line16.Tag = "13.53"
        Me.Line16.Top = 5.093309!
        Me.Line16.Width = 0.0!
        Me.Line16.X1 = 6.887797!
        Me.Line16.X2 = 6.887797!
        Me.Line16.Y1 = 5.093309!
        Me.Line16.Y2 = 5.54567!
        '
        'KEIYAKU_KBN_NM
        '
        Me.KEIYAKU_KBN_NM.DataField = "KEIYAKU_KBN_NM"
        Me.KEIYAKU_KBN_NM.Height = 0.1980308!
        Me.KEIYAKU_KBN_NM.Left = 6.803544!
        Me.KEIYAKU_KBN_NM.MultiLine = False
        Me.KEIYAKU_KBN_NM.Name = "KEIYAKU_KBN_NM"
        Me.KEIYAKU_KBN_NM.OutputFormat = resources.GetString("KEIYAKU_KBN_NM.OutputFormat")
        Me.KEIYAKU_KBN_NM.Style = "color: Magenta; font-family: ＭＳ 明朝; font-size: 11pt; text-align: left; white-spac" & _
            "e: nowrap; ddo-char-set: 1"
        Me.KEIYAKU_KBN_NM.Text = "うずら"
        Me.KEIYAKU_KBN_NM.Top = 4.397638!
        Me.KEIYAKU_KBN_NM.Visible = False
        Me.KEIYAKU_KBN_NM.Width = 0.4850392!
        '
        'ZEN_KI_N
        '
        Me.ZEN_KI_N.DataField = "ZEN_KI_N"
        Me.ZEN_KI_N.Height = 0.1980308!
        Me.ZEN_KI_N.Left = 5.499999!
        Me.ZEN_KI_N.MultiLine = False
        Me.ZEN_KI_N.Name = "ZEN_KI_N"
        Me.ZEN_KI_N.OutputFormat = resources.GetString("ZEN_KI_N.OutputFormat")
        Me.ZEN_KI_N.Style = "color: Magenta; font-family: ＭＳ 明朝; font-size: 11pt; text-align: left; white-spac" & _
            "e: nowrap; ddo-char-set: 1"
        Me.ZEN_KI_N.Text = "９期"
        Me.ZEN_KI_N.Top = 4.397638!
        Me.ZEN_KI_N.Visible = False
        Me.ZEN_KI_N.Width = 0.4850392!
        '
        'TOU_KI_N
        '
        Me.TOU_KI_N.DataField = "TOU_KI_N"
        Me.TOU_KI_N.Height = 0.1980308!
        Me.TOU_KI_N.Left = 6.036614!
        Me.TOU_KI_N.MultiLine = False
        Me.TOU_KI_N.Name = "TOU_KI_N"
        Me.TOU_KI_N.OutputFormat = resources.GetString("TOU_KI_N.OutputFormat")
        Me.TOU_KI_N.Style = "color: Magenta; font-family: ＭＳ 明朝; font-size: 11pt; text-align: left; white-spac" & _
            "e: nowrap; ddo-char-set: 1"
        Me.TOU_KI_N.Text = "９期"
        Me.TOU_KI_N.Top = 4.397638!
        Me.TOU_KI_N.Visible = False
        Me.TOU_KI_N.Width = 0.4850392!
        '
        'KEIYAKU_KBN
        '
        Me.KEIYAKU_KBN.DataField = "KEIYAKU_KBN"
        Me.KEIYAKU_KBN.Height = 0.1980308!
        Me.KEIYAKU_KBN.Left = 6.58622!
        Me.KEIYAKU_KBN.MultiLine = False
        Me.KEIYAKU_KBN.Name = "KEIYAKU_KBN"
        Me.KEIYAKU_KBN.OutputFormat = resources.GetString("KEIYAKU_KBN.OutputFormat")
        Me.KEIYAKU_KBN.Style = "color: Magenta; font-family: ＭＳ 明朝; font-size: 11pt; text-align: left; white-spac" & _
            "e: nowrap; ddo-char-set: 1"
        Me.KEIYAKU_KBN.Text = "9"
        Me.KEIYAKU_KBN.Top = 4.397638!
        Me.KEIYAKU_KBN.Visible = False
        Me.KEIYAKU_KBN.Width = 0.1047244!
        '
        'inei
        '
        Me.inei.Height = 0.8976375!
        Me.inei.HyperLink = Nothing
        Me.inei.ImageBytes = CType(resources.GetObject("inei.ImageBytes"), System.Byte())
        Me.inei.Left = 6.524804!
        Me.inei.Name = "inei"
        Me.inei.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom
        Me.inei.Top = 1.431103!
        Me.inei.Width = 0.8976375!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Height = 0.0!
        Me.ReportHeader1.Name = "ReportHeader1"
        Me.ReportHeader1.Visible = False
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'GRP_HD_KEIYAKUSYA_CD
        '
        Me.GRP_HD_KEIYAKUSYA_CD.DataField = "KEIYAKUSYA_CD"
        Me.GRP_HD_KEIYAKUSYA_CD.Height = 0.0!
        Me.GRP_HD_KEIYAKUSYA_CD.Name = "GRP_HD_KEIYAKUSYA_CD"
        '
        'GRP_FT_SINSEI_NO
        '
        Me.GRP_FT_SINSEI_NO.CanGrow = False
        Me.GRP_FT_SINSEI_NO.Height = 0.0!
        Me.GRP_FT_SINSEI_NO.KeepTogether = True
        Me.GRP_FT_SINSEI_NO.Name = "GRP_FT_SINSEI_NO"
        Me.GRP_FT_SINSEI_NO.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.After
        '
        'GRP_HD_JIMUITAKU_CD
        '
        Me.GRP_HD_JIMUITAKU_CD.DataField = "JIMUITAKU_CD"
        Me.GRP_HD_JIMUITAKU_CD.Height = 0.0!
        Me.GRP_HD_JIMUITAKU_CD.Name = "GRP_HD_JIMUITAKU_CD"
        '
        'GRP_FT_ALL
        '
        Me.GRP_FT_ALL.Height = 0.0!
        Me.GRP_FT_ALL.Name = "GRP_FT_ALL"
        Me.GRP_FT_ALL.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.After
        '
        'rptGJ2061
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.3937007!
        Me.PageSettings.Margins.Left = 0.3937007!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.Margins.Top = 0.5905512!
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.69291!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PageSettings.PaperWidth = 8.267716!
        Me.PrintWidth = 7.859531!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GRP_HD_JIMUITAKU_CD)
        Me.Sections.Add(Me.GRP_HD_KEIYAKUSYA_CD)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GRP_FT_SINSEI_NO)
        Me.Sections.Add(Me.GRP_FT_ALL)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
                    "color: Black; font-family: ""ＭＳ 明朝""; ddo-char-set: 186", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.txt_NOWYMD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Page, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label59, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label70, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KYK_POST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KYK_ADDR1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KYK_ADDR2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Title, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_HD_TEXT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KYK_ADDR3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KYOKAI_ADDR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KYOKAI_TEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KYOKAI_FAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KYK_KEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KYK_DAIHYO_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKUSYA_CD_KAKKO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_HAKKO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_HAKKO_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KYO_KYOKAI_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_YAKUMEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_KAICHO_NAM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HAKKO_NO_KANJI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEIKYU_HAKKO_NO_NEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEIKYU_HAKKO_NO_RENBAN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JIMUITAKU_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BANK_INJI_KBN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SaiHakko, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FURI_FT1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ITAKU_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_ITAKU_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_NOFUKIGEN_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FURI_BANK_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FURI_SITEN_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FURI_KOZA_SYUBETU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FURI_KOZA_NO_N, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FURI_KOZA_MEIGI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_FURI_BANK_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_FURI_SITEN_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_FURI_KOZA_SYUBETU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_FURI_KOZA_MEIGI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_FURI_KOZA_NO_N, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_NOFUKIGEN_DATE23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_FURI_BANK_TITLE23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_NOFUKIGEN_DATE22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_FURI_BANK_TITLE22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_HD1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_HD2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_HD3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_HD4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKU_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZEN_KI_N, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOU_KI_N, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKU_KBN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.inei, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents txt_NOWYMD As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label6 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txt_Page As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents ReportHeader1 As GrapeCity.ActiveReports.SectionReportModel.ReportHeader
    Private WithEvents ReportFooter1 As GrapeCity.ActiveReports.SectionReportModel.ReportFooter
    Private WithEvents Label59 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents GRP_HD_KEIYAKUSYA_CD As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GRP_FT_SINSEI_NO As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents Label50 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label70 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Line2 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Label22 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Line3 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents GRP_HD_JIMUITAKU_CD As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GRP_FT_ALL As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents Line5 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line8 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line9 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents KYK_POST As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KYK_ADDR1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KYK_ADDR2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_Title As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_HD_TEXT As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line6 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents KYK_ADDR3 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_KYOKAI_ADDR As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_KYOKAI_TEL As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_KYOKAI_FAX As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KYK_KEIYAKUSYA_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KYK_DAIHYO_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEIYAKUSYA_CD_KAKKO As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_HAKKO As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_HAKKO_DATE As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_KYO_KYOKAI_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_YAKUMEI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_KAICHO_NAM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents HAKKO_NO_KANJI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents SEIKYU_HAKKO_NO_NEN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents SEIKYU_HAKKO_NO_RENBAN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents JIMUITAKU_CD As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents BANK_INJI_KBN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Friend WithEvents txt_SaiHakko As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line32 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents txt_FURI_FT1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_ITAKU_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lbl_ITAKU_NAME As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents txt_NOFUKIGEN_DATE As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_FURI_BANK_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_FURI_SITEN_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_FURI_KOZA_SYUBETU As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_FURI_KOZA_NO_N As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents txt_FURI_KOZA_MEIGI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents lbl_FURI_BANK_NAME As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl_FURI_SITEN_NAME As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl_FURI_KOZA_SYUBETU As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl_FURI_KOZA_MEIGI As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl_FURI_KOZA_NO_N As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl_NOFUKIGEN_DATE23 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl_FURI_BANK_TITLE23 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl_NOFUKIGEN_DATE22 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl_FURI_BANK_TITLE22 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label19 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox27 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line1 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line4 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line7 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line10 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line26 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line27 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line28 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line33 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents lbl_HD1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label20 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl_HD2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox1 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox2 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label23 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox4 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line34 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line35 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line36 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line37 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line38 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line11 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents lbl_HD3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents lbl_HD4 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox3 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TextBox5 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label5 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox6 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line12 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line13 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line14 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line15 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Line16 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents KEIYAKU_KBN_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents ZEN_KI_N As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents TOU_KI_N As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEIYAKU_KBN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents inei As GrapeCity.ActiveReports.SectionReportModel.Picture
End Class
