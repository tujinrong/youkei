<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptGJ2030
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptGJ2030))
        Me.Detail = New GrapeCity.ActiveReports.SectionReportModel.Detail()
        Me.KEIYAKUSYA_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKUSYA_CD = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKU_KBN_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.TUMITATE_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.SEIKYU_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.HENKAN_KAKUTEI_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.SAGAKU_SEIKYU_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.DTL_UPPER_LINE = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.TESURYO = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.NOFUKIGEN_DATE = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.SEIKYU_DATE = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.KEIYAKU_JYOKYO_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.SEIKYU_HENKAN_KBN_NM = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.SEIKYU_KAISU = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.ITAKU_NAME = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageHeader = New GrapeCity.ActiveReports.SectionReportModel.PageHeader()
        Me.Label24 = New GrapeCity.ActiveReports.SectionReportModel.Label()
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
        Me.Label11 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label12 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.H_SEIKYU_KAISU = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label7 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label1 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label15 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label16 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label6 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label10 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.TAISYO_KI = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label2 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label21 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionLine1 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine2 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine3 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine4 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.Label5 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionLine6 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.CrossSectionLine7 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.Label14 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label17 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionLine9 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.H_SEIKYU_HENKAN_KBN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.H_SEIKYU_DATE = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.H_JIMUITAKU_CD = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label4 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label18 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label9 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label13 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionLine5 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.Label3 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label8 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionLine11 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.Label19 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label22 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionLine12 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.Label25 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label26 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Line6 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.JIMUITAKU_CD = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.PageFooter = New GrapeCity.ActiveReports.SectionReportModel.PageFooter()
        Me.Label55 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.GroupHeader1 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.GroupFooter1 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.Label20 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label23 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.G1_KEIYAKUSYASU = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label34 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.G1_TUMITATE_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.G1_TESURYO = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.G1_SEIKYU_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.G1_HENKAN_KAKUTEI_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.G1_SAGAKU_SEIKYU_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.GroupHeader2 = New GrapeCity.ActiveReports.SectionReportModel.GroupHeader()
        Me.GroupFooter2 = New GrapeCity.ActiveReports.SectionReportModel.GroupFooter()
        Me.Label27 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.G2_KEIYAKUSYASU = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Label32 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label33 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.G2_TUMITATE_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.G2_TESURYO = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.G2_SEIKYU_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.G2_HENKAN_KAKUTEI_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.G2_SAGAKU_SEIKYU_KIN = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        Me.Line1 = New GrapeCity.ActiveReports.SectionReportModel.Line()
        Me.Label35 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.CrossSectionLine13 = New GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine()
        Me.Label47 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.Label36 = New GrapeCity.ActiveReports.SectionReportModel.Label()
        Me.MUKOU = New GrapeCity.ActiveReports.SectionReportModel.TextBox()
        CType(Me.KEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKU_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TUMITATE_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEIKYU_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HENKAN_KAKUTEI_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SAGAKU_SEIKYU_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TESURYO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NOFUKIGEN_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEIKYU_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KEIYAKU_JYOKYO_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEIKYU_HENKAN_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEIKYU_KAISU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ITAKU_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lbl_Seikyu3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sakuseibi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.H_SEIKYU_KAISU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TAISYO_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.H_SEIKYU_HENKAN_KBN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.H_SEIKYU_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.H_JIMUITAKU_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JIMUITAKU_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G1_KEIYAKUSYASU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G1_TUMITATE_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G1_TESURYO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G1_SEIKYU_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G1_HENKAN_KAKUTEI_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G1_SAGAKU_SEIKYU_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G2_KEIYAKUSYASU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G2_TUMITATE_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G2_TESURYO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G2_SEIKYU_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G2_HENKAN_KAKUTEI_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G2_SAGAKU_SEIKYU_KIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MUKOU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.CanGrow = False
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.KEIYAKUSYA_NAME, Me.KEIYAKUSYA_CD, Me.KEIYAKU_KBN_NM, Me.TUMITATE_KIN, Me.SEIKYU_KIN, Me.HENKAN_KAKUTEI_KIN, Me.SAGAKU_SEIKYU_KIN, Me.DTL_UPPER_LINE, Me.TESURYO, Me.NOFUKIGEN_DATE, Me.SEIKYU_DATE, Me.KEIYAKU_JYOKYO_NM, Me.SEIKYU_HENKAN_KBN_NM, Me.SEIKYU_KAISU, Me.MUKOU})
        Me.Detail.Height = 0.1732284!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'KEIYAKUSYA_NAME
        '
        Me.KEIYAKUSYA_NAME.CanGrow = False
        Me.KEIYAKUSYA_NAME.DataField = "KEIYAKUSYA_NAME"
        Me.KEIYAKUSYA_NAME.Height = 0.1535433!
        Me.KEIYAKUSYA_NAME.Left = 0.5222366!
        Me.KEIYAKUSYA_NAME.MultiLine = False
        Me.KEIYAKUSYA_NAME.Name = "KEIYAKUSYA_NAME"
        Me.KEIYAKUSYA_NAME.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; vertical-align: middle; white-space: inherit" & _
            ""
        Me.KEIYAKUSYA_NAME.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ"
        Me.KEIYAKUSYA_NAME.Top = 0.009842406!
        Me.KEIYAKUSYA_NAME.Width = 2.353748!
        '
        'KEIYAKUSYA_CD
        '
        Me.KEIYAKUSYA_CD.CanGrow = False
        Me.KEIYAKUSYA_CD.DataField = "KEIYAKUSYA_CD"
        Me.KEIYAKUSYA_CD.Height = 0.1535433!
        Me.KEIYAKUSYA_CD.Left = 0.04094492!
        Me.KEIYAKUSYA_CD.MultiLine = False
        Me.KEIYAKUSYA_CD.Name = "KEIYAKUSYA_CD"
        Me.KEIYAKUSYA_CD.OutputFormat = resources.GetString("KEIYAKUSYA_CD.OutputFormat")
        Me.KEIYAKUSYA_CD.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" & _
            "hite-space: inherit; ddo-char-set: 128"
        Me.KEIYAKUSYA_CD.Text = "99999"
        Me.KEIYAKUSYA_CD.Top = 0.009842401!
        Me.KEIYAKUSYA_CD.Width = 0.3543307!
        '
        'KEIYAKU_KBN_NM
        '
        Me.KEIYAKU_KBN_NM.CanGrow = False
        Me.KEIYAKU_KBN_NM.DataField = "KEIYAKU_KBN_NM"
        Me.KEIYAKU_KBN_NM.Height = 0.1535433!
        Me.KEIYAKU_KBN_NM.Left = 3.064173!
        Me.KEIYAKU_KBN_NM.MultiLine = False
        Me.KEIYAKU_KBN_NM.Name = "KEIYAKU_KBN_NM"
        Me.KEIYAKU_KBN_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " & _
            "white-space: inherit"
        Me.KEIYAKU_KBN_NM.Text = "＠＠＠"
        Me.KEIYAKU_KBN_NM.Top = 0.009842461!
        Me.KEIYAKU_KBN_NM.Width = 0.407479!
        '
        'TUMITATE_KIN
        '
        Me.TUMITATE_KIN.DataField = "TUMITATE_KIN"
        Me.TUMITATE_KIN.Height = 0.1535433!
        Me.TUMITATE_KIN.Left = 6.522441!
        Me.TUMITATE_KIN.MultiLine = False
        Me.TUMITATE_KIN.Name = "TUMITATE_KIN"
        Me.TUMITATE_KIN.OutputFormat = resources.GetString("TUMITATE_KIN.OutputFormat")
        Me.TUMITATE_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.TUMITATE_KIN.Text = "9,999,999,999"
        Me.TUMITATE_KIN.Top = 0.009842525!
        Me.TUMITATE_KIN.Width = 0.8181114!
        '
        'SEIKYU_KIN
        '
        Me.SEIKYU_KIN.DataField = "SEIKYU_KIN"
        Me.SEIKYU_KIN.Height = 0.1535433!
        Me.SEIKYU_KIN.Left = 8.166929!
        Me.SEIKYU_KIN.MultiLine = False
        Me.SEIKYU_KIN.Name = "SEIKYU_KIN"
        Me.SEIKYU_KIN.OutputFormat = resources.GetString("SEIKYU_KIN.OutputFormat")
        Me.SEIKYU_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.SEIKYU_KIN.Text = "9,999,999,999"
        Me.SEIKYU_KIN.Top = 0.009842525!
        Me.SEIKYU_KIN.Width = 0.8181114!
        '
        'HENKAN_KAKUTEI_KIN
        '
        Me.HENKAN_KAKUTEI_KIN.DataField = "HENKAN_KAKUTEI_KIN"
        Me.HENKAN_KAKUTEI_KIN.Height = 0.1535433!
        Me.HENKAN_KAKUTEI_KIN.Left = 9.072835!
        Me.HENKAN_KAKUTEI_KIN.MultiLine = False
        Me.HENKAN_KAKUTEI_KIN.Name = "HENKAN_KAKUTEI_KIN"
        Me.HENKAN_KAKUTEI_KIN.OutputFormat = resources.GetString("HENKAN_KAKUTEI_KIN.OutputFormat")
        Me.HENKAN_KAKUTEI_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.HENKAN_KAKUTEI_KIN.Text = "9,999,999,999"
        Me.HENKAN_KAKUTEI_KIN.Top = 0.009842525!
        Me.HENKAN_KAKUTEI_KIN.Width = 0.8181114!
        '
        'SAGAKU_SEIKYU_KIN
        '
        Me.SAGAKU_SEIKYU_KIN.DataField = "SAGAKU_SEIKYU_KIN"
        Me.SAGAKU_SEIKYU_KIN.Height = 0.1535433!
        Me.SAGAKU_SEIKYU_KIN.Left = 9.979528!
        Me.SAGAKU_SEIKYU_KIN.MultiLine = False
        Me.SAGAKU_SEIKYU_KIN.Name = "SAGAKU_SEIKYU_KIN"
        Me.SAGAKU_SEIKYU_KIN.OutputFormat = resources.GetString("SAGAKU_SEIKYU_KIN.OutputFormat")
        Me.SAGAKU_SEIKYU_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.SAGAKU_SEIKYU_KIN.Text = "9,999,999,999"
        Me.SAGAKU_SEIKYU_KIN.Top = 0.009842521!
        Me.SAGAKU_SEIKYU_KIN.Width = 0.8181114!
        '
        'DTL_UPPER_LINE
        '
        Me.DTL_UPPER_LINE.Height = 0.0!
        Me.DTL_UPPER_LINE.Left = 0.01023622!
        Me.DTL_UPPER_LINE.LineWeight = 1.0!
        Me.DTL_UPPER_LINE.Name = "DTL_UPPER_LINE"
        Me.DTL_UPPER_LINE.Top = 0.0!
        Me.DTL_UPPER_LINE.Width = 10.8937!
        Me.DTL_UPPER_LINE.X1 = 0.01023622!
        Me.DTL_UPPER_LINE.X2 = 10.90394!
        Me.DTL_UPPER_LINE.Y1 = 0.0!
        Me.DTL_UPPER_LINE.Y2 = 0.0!
        '
        'TESURYO
        '
        Me.TESURYO.DataField = "TESURYO"
        Me.TESURYO.Height = 0.1535433!
        Me.TESURYO.Left = 7.428347!
        Me.TESURYO.MultiLine = False
        Me.TESURYO.Name = "TESURYO"
        Me.TESURYO.OutputFormat = resources.GetString("TESURYO.OutputFormat")
        Me.TESURYO.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.TESURYO.Text = "99,999,999"
        Me.TESURYO.Top = 0.009842525!
        Me.TESURYO.Width = 0.6307087!
        '
        'NOFUKIGEN_DATE
        '
        Me.NOFUKIGEN_DATE.CanGrow = False
        Me.NOFUKIGEN_DATE.DataField = "NOFUKIGEN_DATE"
        Me.NOFUKIGEN_DATE.Height = 0.1535433!
        Me.NOFUKIGEN_DATE.Left = 6.076378!
        Me.NOFUKIGEN_DATE.MultiLine = False
        Me.NOFUKIGEN_DATE.Name = "NOFUKIGEN_DATE"
        Me.NOFUKIGEN_DATE.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " & _
            "white-space: inherit"
        Me.NOFUKIGEN_DATE.Text = "99/99"
        Me.NOFUKIGEN_DATE.Top = 0.009842521!
        Me.NOFUKIGEN_DATE.Width = 0.3866143!
        '
        'SEIKYU_DATE
        '
        Me.SEIKYU_DATE.CanGrow = False
        Me.SEIKYU_DATE.DataField = "SEIKYU_DATE"
        Me.SEIKYU_DATE.Height = 0.1535433!
        Me.SEIKYU_DATE.Left = 5.136221!
        Me.SEIKYU_DATE.MultiLine = False
        Me.SEIKYU_DATE.Name = "SEIKYU_DATE"
        Me.SEIKYU_DATE.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " & _
            "white-space: inherit"
        Me.SEIKYU_DATE.Text = "平成99/99/99"
        Me.SEIKYU_DATE.Top = 0.009842521!
        Me.SEIKYU_DATE.Width = 0.8240161!
        '
        'KEIYAKU_JYOKYO_NM
        '
        Me.KEIYAKU_JYOKYO_NM.CanGrow = False
        Me.KEIYAKU_JYOKYO_NM.DataField = "KEIYAKU_JYOKYO_NM"
        Me.KEIYAKU_JYOKYO_NM.Height = 0.1535433!
        Me.KEIYAKU_JYOKYO_NM.Left = 3.555512!
        Me.KEIYAKU_JYOKYO_NM.MultiLine = False
        Me.KEIYAKU_JYOKYO_NM.Name = "KEIYAKU_JYOKYO_NM"
        Me.KEIYAKU_JYOKYO_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " & _
            "white-space: inherit"
        Me.KEIYAKU_JYOKYO_NM.Text = "＠＠＠"
        Me.KEIYAKU_JYOKYO_NM.Top = 0.009842342!
        Me.KEIYAKU_JYOKYO_NM.Width = 0.407479!
        '
        'SEIKYU_HENKAN_KBN_NM
        '
        Me.SEIKYU_HENKAN_KBN_NM.CanGrow = False
        Me.SEIKYU_HENKAN_KBN_NM.DataField = "SEIKYU_HENKAN_KBN_NM"
        Me.SEIKYU_HENKAN_KBN_NM.Height = 0.1535433!
        Me.SEIKYU_HENKAN_KBN_NM.Left = 4.067323!
        Me.SEIKYU_HENKAN_KBN_NM.MultiLine = False
        Me.SEIKYU_HENKAN_KBN_NM.Name = "SEIKYU_HENKAN_KBN_NM"
        Me.SEIKYU_HENKAN_KBN_NM.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " & _
            "white-space: inherit"
        Me.SEIKYU_HENKAN_KBN_NM.Text = "＠＠＠＠"
        Me.SEIKYU_HENKAN_KBN_NM.Top = 0.009842521!
        Me.SEIKYU_HENKAN_KBN_NM.Width = 0.5405514!
        '
        'SEIKYU_KAISU
        '
        Me.SEIKYU_KAISU.CanGrow = False
        Me.SEIKYU_KAISU.DataField = "SEIKYU_KAISU"
        Me.SEIKYU_KAISU.Height = 0.1535433!
        Me.SEIKYU_KAISU.Left = 4.757481!
        Me.SEIKYU_KAISU.MultiLine = False
        Me.SEIKYU_KAISU.Name = "SEIKYU_KAISU"
        Me.SEIKYU_KAISU.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" & _
            "hite-space: inherit"
        Me.SEIKYU_KAISU.Text = "999"
        Me.SEIKYU_KAISU.Top = 0.009842521!
        Me.SEIKYU_KAISU.Width = 0.2641732!
        '
        'ITAKU_NAME
        '
        Me.ITAKU_NAME.DataField = "ITAKU_NAME"
        Me.ITAKU_NAME.Height = 0.1732284!
        Me.ITAKU_NAME.Left = 1.183465!
        Me.ITAKU_NAME.Name = "ITAKU_NAME"
        Me.ITAKU_NAME.Style = "font-family: ＭＳ Ｐゴシック; font-size: 9.75pt; vertical-align: middle; white-space: no" & _
            "wrap"
        Me.ITAKU_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        Me.ITAKU_NAME.Top = 0.55!
        Me.ITAKU_NAME.Width = 3.24567!
        '
        'PageHeader
        '
        Me.PageHeader.CanGrow = False
        Me.PageHeader.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label24, Me.Lbl_Seikyu3, Me.Label28, Me.sakuseibi, Me.Label29, Me.Label30, Me.TextBox7, Me.Label31, Me.CrossSectionBox2, Me.CrossSectionLine8, Me.CrossSectionLine10, Me.Label47, Me.Label11, Me.Label12, Me.H_SEIKYU_KAISU, Me.Label7, Me.Label1, Me.Label15, Me.Label16, Me.Label6, Me.Label10, Me.TAISYO_KI, Me.Label2, Me.Label21, Me.CrossSectionLine1, Me.CrossSectionLine2, Me.CrossSectionLine3, Me.CrossSectionLine4, Me.Label5, Me.CrossSectionLine6, Me.CrossSectionLine7, Me.Label14, Me.Label17, Me.CrossSectionLine9, Me.ITAKU_NAME, Me.H_SEIKYU_HENKAN_KBN, Me.H_SEIKYU_DATE, Me.H_JIMUITAKU_CD, Me.Label4, Me.Label18, Me.Label9, Me.Label13, Me.CrossSectionLine5, Me.Label3, Me.Label8, Me.CrossSectionLine11, Me.Label19, Me.Label22, Me.CrossSectionLine12, Me.Label25, Me.Label26, Me.Line6, Me.JIMUITAKU_CD, Me.Label35, Me.CrossSectionLine13, Me.Label36})
        Me.PageHeader.Height = 1.15748!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label24
        '
        Me.Label24.Height = 0.2401575!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 0.04094489!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "font-family: ＭＳ Ｐゴシック; font-size: 14pt; text-align: center"
        Me.Label24.Text = "<<　生産者積立金等請求・返還一覧表　>>"
        Me.Label24.Top = 0.0!
        Me.Label24.Width = 10.88504!
        '
        'Lbl_Seikyu3
        '
        Me.Lbl_Seikyu3.Height = 0.1875!
        Me.Lbl_Seikyu3.HyperLink = Nothing
        Me.Lbl_Seikyu3.Left = 3.24567!
        Me.Lbl_Seikyu3.Name = "Lbl_Seikyu3"
        Me.Lbl_Seikyu3.Style = "font-family: ＭＳ Ｐゴシック; font-size: 9.75pt; text-align: left; ddo-char-set: 128"
        Me.Lbl_Seikyu3.Text = "請求等回数："
        Me.Lbl_Seikyu3.Top = 0.388189!
        Me.Lbl_Seikyu3.Width = 0.8200792!
        '
        'Label28
        '
        Me.Label28.Height = 0.1875!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 9.083466!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left; ddo-char-set: 1"
        Me.Label28.Text = "作成日："
        Me.Label28.Top = 0.2228347!
        Me.Label28.Width = 0.5708662!
        '
        'sakuseibi
        '
        Me.sakuseibi.DataField = "SAKUSEIBI"
        Me.sakuseibi.Height = 0.1875!
        Me.sakuseibi.Left = 9.655437!
        Me.sakuseibi.MultiLine = False
        Me.sakuseibi.Name = "sakuseibi"
        Me.sakuseibi.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; ddo-char-set: 1"
        Me.sakuseibi.Text = "平成99年99月99日"
        Me.sakuseibi.Top = 0.2228347!
        Me.sakuseibi.Width = 1.187402!
        '
        'Label29
        '
        Me.Label29.Height = 0.1875!
        Me.Label29.HyperLink = Nothing
        Me.Label29.Left = 9.910555!
        Me.Label29.Name = "Label29"
        Me.Label29.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left; vertical-align: middle;" & _
            " ddo-char-set: 1"
        Me.Label29.Text = "ページ"
        Me.Label29.Top = 0.388189!
        Me.Label29.Width = 0.4375!
        '
        'Label30
        '
        Me.Label30.Height = 0.1875!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 10.31055!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e; ddo-char-set: 1"
        Me.Label30.Text = ":"
        Me.Label30.Top = 0.388189!
        Me.Label30.Width = 0.125!
        '
        'TextBox7
        '
        Me.TextBox7.Height = 0.1875!
        Me.TextBox7.Left = 10.4404!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; vertical-align: middle" & _
            "; ddo-char-set: 1"
        Me.TextBox7.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.TextBox7.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount
        Me.TextBox7.Text = "Z,ZZ9"
        Me.TextBox7.Top = 0.388189!
        Me.TextBox7.Width = 0.402441!
        '
        'Label31
        '
        Me.Label31.Height = 0.1889764!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 0.5220473!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label31.Text = "契約者名"
        Me.Label31.Top = 0.8291339!
        Me.Label31.Width = 2.353748!
        '
        'CrossSectionBox2
        '
        Me.CrossSectionBox2.Bottom = 0.02047244!
        Me.CrossSectionBox2.Left = 0.0!
        Me.CrossSectionBox2.LineWeight = 3.0!
        Me.CrossSectionBox2.Name = "CrossSectionBox2"
        Me.CrossSectionBox2.Right = 10.91!
        Me.CrossSectionBox2.Top = 0.7070869!
        '
        'CrossSectionLine8
        '
        Me.CrossSectionLine8.Bottom = 0.01181103!
        Me.CrossSectionLine8.Left = 0.4417323!
        Me.CrossSectionLine8.LineWeight = 1.0!
        Me.CrossSectionLine8.Name = "CrossSectionLine8"
        Me.CrossSectionLine8.Top = 0.7181103!
        '
        'CrossSectionLine10
        '
        Me.CrossSectionLine10.Bottom = 0.01181097!
        Me.CrossSectionLine10.Left = 2.919291!
        Me.CrossSectionLine10.LineWeight = 1.0!
        Me.CrossSectionLine10.Name = "CrossSectionLine10"
        Me.CrossSectionLine10.Top = 0.7181103!
        '
        'Label11
        '
        Me.Label11.Height = 0.1889764!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 6.543702!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label11.Text = "生産者積立金"
        Me.Label11.Top = 0.835827!
        Me.Label11.Width = 0.869685!
        '
        'Label12
        '
        Me.Label12.Height = 0.1889764!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 6.018898!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label12.Text = "納付振"
        Me.Label12.Top = 0.7472443!
        Me.Label12.Width = 0.4748034!
        '
        'H_SEIKYU_KAISU
        '
        Me.H_SEIKYU_KAISU.DataField = "H_SEIKYU_KAISU"
        Me.H_SEIKYU_KAISU.Height = 0.1875!
        Me.H_SEIKYU_KAISU.Left = 4.057875!
        Me.H_SEIKYU_KAISU.MultiLine = False
        Me.H_SEIKYU_KAISU.Name = "H_SEIKYU_KAISU"
        Me.H_SEIKYU_KAISU.Style = "font-family: ＭＳ Ｐゴシック; font-size: 9.75pt; text-align: left; ddo-char-set: 128"
        Me.H_SEIKYU_KAISU.Text = "999 ～ 999"
        Me.H_SEIKYU_KAISU.Top = 0.388189!
        Me.H_SEIKYU_KAISU.Width = 0.7476379!
        '
        'Label7
        '
        Me.Label7.Height = 0.1889764!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.05157451!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label7.Text = "番号"
        Me.Label7.Top = 0.9279526!
        Me.Label7.Width = 0.348!
        '
        'Label1
        '
        Me.Label1.Height = 0.1889764!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 3.106299!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label1.Text = "契約"
        Me.Label1.Top = 0.7472441!
        Me.Label1.Width = 0.348!
        '
        'Label15
        '
        Me.Label15.Height = 0.1889764!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 3.106299!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label15.Text = "区分"
        Me.Label15.Top = 0.9279525!
        Me.Label15.Width = 0.348!
        '
        'Label16
        '
        Me.Label16.Height = 0.1889764!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 6.018898!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label16.Text = "込期限"
        Me.Label16.Top = 0.9279526!
        Me.Label16.Width = 0.4748034!
        '
        'Label6
        '
        Me.Label6.Height = 0.1889764!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 7.438583!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label6.Text = "事務手数料"
        Me.Label6.Top = 0.8358268!
        Me.Label6.Width = 0.7228346!
        '
        'Label10
        '
        Me.Label10.Height = 0.1889764!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 8.183858!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label10.Text = "等算定額"
        Me.Label10.Top = 0.9279526!
        Me.Label10.Width = 0.8696855!
        '
        'TAISYO_KI
        '
        Me.TAISYO_KI.DataField = "TAISYO_KI"
        Me.TAISYO_KI.Height = 0.1874016!
        Me.TAISYO_KI.Left = 3.371386!
        Me.TAISYO_KI.MultiLine = False
        Me.TAISYO_KI.Name = "TAISYO_KI"
        Me.TAISYO_KI.Style = "font-family: ＭＳ Ｐゴシック; font-size: 9.75pt; text-align: center; ddo-char-set: 128"
        Me.TAISYO_KI.Text = "対象期：　第9期（平成99年度～平成99年度）"
        Me.TAISYO_KI.Top = 0.2330709!
        Me.TAISYO_KI.Width = 4.151969!
        '
        'Label2
        '
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 4.808661!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-family: ＭＳ Ｐゴシック; font-size: 9.75pt; text-align: left; ddo-char-set: 128"
        Me.Label2.Text = "請求・返還日："
        Me.Label2.Top = 0.388189!
        Me.Label2.Width = 0.8771658!
        '
        'Label21
        '
        Me.Label21.Height = 0.1875!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 9.830292!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: right; ddo-char-set: 1"
        Me.Label21.Text = "（単位：羽、円）"
        Me.Label21.Top = 0.55!
        Me.Label21.Width = 1.012547!
        '
        'CrossSectionLine1
        '
        Me.CrossSectionLine1.Bottom = 0.01181103!
        Me.CrossSectionLine1.Left = 3.51063!
        Me.CrossSectionLine1.LineWeight = 1.0!
        Me.CrossSectionLine1.Name = "CrossSectionLine1"
        Me.CrossSectionLine1.Top = 0.7173229!
        '
        'CrossSectionLine2
        '
        Me.CrossSectionLine2.Bottom = 0.01181097!
        Me.CrossSectionLine2.Left = 5.099607!
        Me.CrossSectionLine2.LineWeight = 1.0!
        Me.CrossSectionLine2.Name = "CrossSectionLine2"
        Me.CrossSectionLine2.Top = 0.7181103!
        '
        'CrossSectionLine3
        '
        Me.CrossSectionLine3.Bottom = 0.01181097!
        Me.CrossSectionLine3.Left = 6.522441!
        Me.CrossSectionLine3.LineWeight = 1.0!
        Me.CrossSectionLine3.Name = "CrossSectionLine3"
        Me.CrossSectionLine3.Top = 0.7181103!
        '
        'CrossSectionLine4
        '
        Me.CrossSectionLine4.Bottom = 0.01181097!
        Me.CrossSectionLine4.Left = 7.423229!
        Me.CrossSectionLine4.LineWeight = 1.0!
        Me.CrossSectionLine4.Name = "CrossSectionLine4"
        Me.CrossSectionLine4.Top = 0.7181103!
        '
        'Label5
        '
        Me.Label5.Height = 0.1889764!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 8.183858!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label5.Text = "生産者積立金"
        Me.Label5.Top = 0.7472443!
        Me.Label5.Width = 0.8696855!
        '
        'CrossSectionLine6
        '
        Me.CrossSectionLine6.Bottom = 0.01181097!
        Me.CrossSectionLine6.Left = 8.160236!
        Me.CrossSectionLine6.LineWeight = 1.0!
        Me.CrossSectionLine6.Name = "CrossSectionLine6"
        Me.CrossSectionLine6.Top = 0.7181103!
        '
        'CrossSectionLine7
        '
        Me.CrossSectionLine7.Bottom = 0.01181097!
        Me.CrossSectionLine7.Left = 9.07126!
        Me.CrossSectionLine7.LineWeight = 1.0!
        Me.CrossSectionLine7.Name = "CrossSectionLine7"
        Me.CrossSectionLine7.Top = 0.7181103!
        '
        'Label14
        '
        Me.Label14.Height = 0.1889764!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 10.00354!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label14.Text = "等請求納付額"
        Me.Label14.Top = 0.9279526!
        Me.Label14.Width = 0.8696855!
        '
        'Label17
        '
        Me.Label17.Height = 0.1889764!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 10.00354!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label17.Text = "生産者積立金"
        Me.Label17.Top = 0.7472442!
        Me.Label17.Width = 0.8696855!
        '
        'CrossSectionLine9
        '
        Me.CrossSectionLine9.Bottom = 0.01181103!
        Me.CrossSectionLine9.Left = 9.972048!
        Me.CrossSectionLine9.LineWeight = 1.0!
        Me.CrossSectionLine9.Name = "CrossSectionLine9"
        Me.CrossSectionLine9.Top = 0.7181103!
        '
        'H_SEIKYU_HENKAN_KBN
        '
        Me.H_SEIKYU_HENKAN_KBN.DataField = "H_SEIKYU_HENKAN_KBN"
        Me.H_SEIKYU_HENKAN_KBN.Height = 0.1874016!
        Me.H_SEIKYU_HENKAN_KBN.Left = 0.07362206!
        Me.H_SEIKYU_HENKAN_KBN.MultiLine = False
        Me.H_SEIKYU_HENKAN_KBN.Name = "H_SEIKYU_HENKAN_KBN"
        Me.H_SEIKYU_HENKAN_KBN.Style = "font-family: ＭＳ Ｐゴシック; font-size: 9.75pt; text-align: left; ddo-char-set: 128"
        Me.H_SEIKYU_HENKAN_KBN.Text = "出力区分：全額請求、一部請求、一部返還、全額返還"
        Me.H_SEIKYU_HENKAN_KBN.Top = 0.2330709!
        Me.H_SEIKYU_HENKAN_KBN.Width = 3.256299!
        '
        'H_SEIKYU_DATE
        '
        Me.H_SEIKYU_DATE.DataField = "H_SEIKYU_DATE"
        Me.H_SEIKYU_DATE.Height = 0.1875!
        Me.H_SEIKYU_DATE.Left = 5.696063!
        Me.H_SEIKYU_DATE.MultiLine = False
        Me.H_SEIKYU_DATE.Name = "H_SEIKYU_DATE"
        Me.H_SEIKYU_DATE.Style = "font-family: ＭＳ Ｐゴシック; font-size: 9.75pt; text-align: left; ddo-char-set: 128"
        Me.H_SEIKYU_DATE.Text = "平成99年99月99日～平成99年99月99日"
        Me.H_SEIKYU_DATE.Top = 0.388189!
        Me.H_SEIKYU_DATE.Width = 2.455906!
        '
        'H_JIMUITAKU_CD
        '
        Me.H_JIMUITAKU_CD.DataField = "H_JIMUITAKU_CD"
        Me.H_JIMUITAKU_CD.Height = 0.1732284!
        Me.H_JIMUITAKU_CD.Left = 0.07362135!
        Me.H_JIMUITAKU_CD.Name = "H_JIMUITAKU_CD"
        Me.H_JIMUITAKU_CD.Style = "font-family: ＭＳ Ｐゴシック; font-size: 9.75pt; vertical-align: middle; white-space: no" & _
            "wrap"
        Me.H_JIMUITAKU_CD.Text = "事務委託先(999)："
        Me.H_JIMUITAKU_CD.Top = 0.55!
        Me.H_JIMUITAKU_CD.Width = 1.089764!
        '
        'Label4
        '
        Me.Label4.Height = 0.1889764!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 3.584252!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label4.Text = "契約"
        Me.Label4.Top = 0.7472441!
        Me.Label4.Width = 0.348!
        '
        'Label18
        '
        Me.Label18.Height = 0.1889764!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 3.584252!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label18.Text = "状況"
        Me.Label18.Top = 0.9279524!
        Me.Label18.Width = 0.348!
        '
        'Label9
        '
        Me.Label9.Height = 0.1889764!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 9.094093!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label9.Text = "返還額"
        Me.Label9.Top = 0.9279526!
        Me.Label9.Width = 0.8696855!
        '
        'Label13
        '
        Me.Label13.Height = 0.1889764!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 9.094093!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label13.Text = "生産者積立金"
        Me.Label13.Top = 0.7472443!
        Me.Label13.Width = 0.8696855!
        '
        'CrossSectionLine5
        '
        Me.CrossSectionLine5.Bottom = 0.01181097!
        Me.CrossSectionLine5.Left = 6.000394!
        Me.CrossSectionLine5.LineWeight = 1.0!
        Me.CrossSectionLine5.Name = "CrossSectionLine5"
        Me.CrossSectionLine5.Top = 0.7181103!
        '
        'Label3
        '
        Me.Label3.Height = 0.1889764!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 5.194489!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label3.Text = "請求・返還"
        Me.Label3.Top = 0.7637797!
        Me.Label3.Width = 0.7003942!
        '
        'Label8
        '
        Me.Label8.Height = 0.1889764!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 5.194489!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label8.Text = "年月日"
        Me.Label8.Top = 0.9444885!
        Me.Label8.Width = 0.7003942!
        '
        'CrossSectionLine11
        '
        Me.CrossSectionLine11.Bottom = 0.01181097!
        Me.CrossSectionLine11.Left = 3.991733!
        Me.CrossSectionLine11.LineWeight = 1.0!
        Me.CrossSectionLine11.Name = "CrossSectionLine11"
        Me.CrossSectionLine11.Top = 0.7181103!
        '
        'Label19
        '
        Me.Label19.Height = 0.1889764!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 4.032284!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label19.Text = "請求返還"
        Me.Label19.Top = 0.7472443!
        Me.Label19.Width = 0.6023626!
        '
        'Label22
        '
        Me.Label22.Height = 0.1889764!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 4.032284!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label22.Text = "状況"
        Me.Label22.Top = 0.9279536!
        Me.Label22.Width = 0.6023626!
        '
        'CrossSectionLine12
        '
        Me.CrossSectionLine12.Bottom = 0.001574585!
        Me.CrossSectionLine12.Left = 4.679922!
        Me.CrossSectionLine12.LineWeight = 1.0!
        Me.CrossSectionLine12.Name = "CrossSectionLine12"
        Me.CrossSectionLine12.Top = 0.7181103!
        '
        'Label25
        '
        Me.Label25.Height = 0.1889764!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 4.730709!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label25.Text = "請求"
        Me.Label25.Top = 0.7472443!
        Me.Label25.Width = 0.348!
        '
        'Label26
        '
        Me.Label26.Height = 0.1889764!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 4.730709!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label26.Text = "回数"
        Me.Label26.Top = 0.9279536!
        Me.Label26.Width = 0.348!
        '
        'Line6
        '
        Me.Line6.Height = 0.0!
        Me.Line6.Left = 0.0!
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 1.13937!
        Me.Line6.Width = 10.8937!
        Me.Line6.X1 = 0.0!
        Me.Line6.X2 = 10.8937!
        Me.Line6.Y1 = 1.13937!
        Me.Line6.Y2 = 1.13937!
        '
        'JIMUITAKU_CD
        '
        Me.JIMUITAKU_CD.CanGrow = False
        Me.JIMUITAKU_CD.DataField = "JIMUITAKU_CD"
        Me.JIMUITAKU_CD.Height = 0.1535433!
        Me.JIMUITAKU_CD.Left = 0.6555114!
        Me.JIMUITAKU_CD.MultiLine = False
        Me.JIMUITAKU_CD.Name = "JIMUITAKU_CD"
        Me.JIMUITAKU_CD.OutputFormat = resources.GetString("JIMUITAKU_CD.OutputFormat")
        Me.JIMUITAKU_CD.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle; w" & _
            "hite-space: inherit; ddo-char-set: 128"
        Me.JIMUITAKU_CD.Text = "999"
        Me.JIMUITAKU_CD.Top = 0.4098425!
        Me.JIMUITAKU_CD.Visible = False
        Me.JIMUITAKU_CD.Width = 0.3543307!
        '
        'PageFooter
        '
        Me.PageFooter.CanGrow = False
        Me.PageFooter.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label55})
        Me.PageFooter.Height = 0.1945538!
        Me.PageFooter.Name = "PageFooter"
        '
        'Label55
        '
        Me.Label55.Height = 0.1563976!
        Me.Label55.HyperLink = Nothing
        Me.Label55.Left = 10.31693!
        Me.Label55.Name = "Label55"
        Me.Label55.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left; ddo-char-set: 1"
        Me.Label55.Text = "(S2030)"
        Me.Label55.Top = 0.03070866!
        Me.Label55.Width = 0.5043316!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.CanGrow = False
        Me.GroupHeader1.Height = 0.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.CanGrow = False
        Me.GroupFooter1.CanShrink = True
        Me.GroupFooter1.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label20, Me.Label23, Me.G1_KEIYAKUSYASU, Me.Label34, Me.G1_TUMITATE_KIN, Me.G1_TESURYO, Me.G1_SEIKYU_KIN, Me.G1_HENKAN_KAKUTEI_KIN, Me.G1_SAGAKU_SEIKYU_KIN})
        Me.GroupFooter1.Height = 0.1732284!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Label20
        '
        Me.Label20.Height = 0.1535433!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 0.6755906!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " & _
            "ddo-char-set: 1"
        Me.Label20.Text = "総合計"
        Me.Label20.Top = 0.01181102!
        Me.Label20.Width = 1.014961!
        '
        'Label23
        '
        Me.Label23.Height = 0.1535433!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 1.686614!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " & _
            "ddo-char-set: 1"
        Me.Label23.Text = "（"
        Me.Label23.Top = 0.01181102!
        Me.Label23.Width = 0.119291!
        '
        'G1_KEIYAKUSYASU
        '
        Me.G1_KEIYAKUSYASU.DataField = "KEIYAKUSYA_CD"
        Me.G1_KEIYAKUSYASU.DistinctField = "KEIYAKUSYA_CD"
        Me.G1_KEIYAKUSYASU.Height = 0.1535433!
        Me.G1_KEIYAKUSYASU.Left = 1.804331!
        Me.G1_KEIYAKUSYASU.MultiLine = False
        Me.G1_KEIYAKUSYASU.Name = "G1_KEIYAKUSYASU"
        Me.G1_KEIYAKUSYASU.OutputFormat = resources.GetString("G1_KEIYAKUSYASU.OutputFormat")
        Me.G1_KEIYAKUSYASU.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.G1_KEIYAKUSYASU.SummaryFunc = GrapeCity.ActiveReports.SectionReportModel.SummaryFunc.DCount
        Me.G1_KEIYAKUSYASU.SummaryGroup = "GroupHeader1"
        Me.G1_KEIYAKUSYASU.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.G1_KEIYAKUSYASU.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal
        Me.G1_KEIYAKUSYASU.Text = "9,999"
        Me.G1_KEIYAKUSYASU.Top = 0.01181102!
        Me.G1_KEIYAKUSYASU.Width = 0.344488!
        '
        'Label34
        '
        Me.Label34.Height = 0.1535433!
        Me.Label34.HyperLink = Nothing
        Me.Label34.Left = 2.187795!
        Me.Label34.Name = "Label34"
        Me.Label34.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " & _
            "ddo-char-set: 1"
        Me.Label34.Text = "人）"
        Me.Label34.Top = 0.01181102!
        Me.Label34.Width = 0.2523622!
        '
        'G1_TUMITATE_KIN
        '
        Me.G1_TUMITATE_KIN.DataField = "TUMITATE_KIN"
        Me.G1_TUMITATE_KIN.Height = 0.1535433!
        Me.G1_TUMITATE_KIN.Left = 6.522441!
        Me.G1_TUMITATE_KIN.MultiLine = False
        Me.G1_TUMITATE_KIN.Name = "G1_TUMITATE_KIN"
        Me.G1_TUMITATE_KIN.OutputFormat = resources.GetString("G1_TUMITATE_KIN.OutputFormat")
        Me.G1_TUMITATE_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.G1_TUMITATE_KIN.SummaryGroup = "GroupHeader1"
        Me.G1_TUMITATE_KIN.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.G1_TUMITATE_KIN.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal
        Me.G1_TUMITATE_KIN.Text = "9,999,999,999"
        Me.G1_TUMITATE_KIN.Top = 0.01181102!
        Me.G1_TUMITATE_KIN.Width = 0.8181111!
        '
        'G1_TESURYO
        '
        Me.G1_TESURYO.DataField = "TESURYO"
        Me.G1_TESURYO.Height = 0.1535433!
        Me.G1_TESURYO.Left = 7.438583!
        Me.G1_TESURYO.MultiLine = False
        Me.G1_TESURYO.Name = "G1_TESURYO"
        Me.G1_TESURYO.OutputFormat = resources.GetString("G1_TESURYO.OutputFormat")
        Me.G1_TESURYO.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.G1_TESURYO.SummaryGroup = "GroupHeader1"
        Me.G1_TESURYO.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.G1_TESURYO.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal
        Me.G1_TESURYO.Text = "99,999,999"
        Me.G1_TESURYO.Top = 0.01181102!
        Me.G1_TESURYO.Width = 0.6307087!
        '
        'G1_SEIKYU_KIN
        '
        Me.G1_SEIKYU_KIN.DataField = "SEIKYU_KIN"
        Me.G1_SEIKYU_KIN.Height = 0.1535433!
        Me.G1_SEIKYU_KIN.Left = 8.166929!
        Me.G1_SEIKYU_KIN.MultiLine = False
        Me.G1_SEIKYU_KIN.Name = "G1_SEIKYU_KIN"
        Me.G1_SEIKYU_KIN.OutputFormat = resources.GetString("G1_SEIKYU_KIN.OutputFormat")
        Me.G1_SEIKYU_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.G1_SEIKYU_KIN.SummaryGroup = "GroupHeader1"
        Me.G1_SEIKYU_KIN.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.G1_SEIKYU_KIN.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal
        Me.G1_SEIKYU_KIN.Text = "9,999,999,999"
        Me.G1_SEIKYU_KIN.Top = 0.01181102!
        Me.G1_SEIKYU_KIN.Width = 0.8181111!
        '
        'G1_HENKAN_KAKUTEI_KIN
        '
        Me.G1_HENKAN_KAKUTEI_KIN.DataField = "HENKAN_KAKUTEI_KIN"
        Me.G1_HENKAN_KAKUTEI_KIN.Height = 0.1535433!
        Me.G1_HENKAN_KAKUTEI_KIN.Left = 9.072835!
        Me.G1_HENKAN_KAKUTEI_KIN.MultiLine = False
        Me.G1_HENKAN_KAKUTEI_KIN.Name = "G1_HENKAN_KAKUTEI_KIN"
        Me.G1_HENKAN_KAKUTEI_KIN.OutputFormat = resources.GetString("G1_HENKAN_KAKUTEI_KIN.OutputFormat")
        Me.G1_HENKAN_KAKUTEI_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.G1_HENKAN_KAKUTEI_KIN.SummaryGroup = "GroupHeader1"
        Me.G1_HENKAN_KAKUTEI_KIN.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.G1_HENKAN_KAKUTEI_KIN.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal
        Me.G1_HENKAN_KAKUTEI_KIN.Text = "9,999,999,999"
        Me.G1_HENKAN_KAKUTEI_KIN.Top = 0.01181102!
        Me.G1_HENKAN_KAKUTEI_KIN.Width = 0.8181111!
        '
        'G1_SAGAKU_SEIKYU_KIN
        '
        Me.G1_SAGAKU_SEIKYU_KIN.DataField = "SAGAKU_SEIKYU_KIN_KEI"
        Me.G1_SAGAKU_SEIKYU_KIN.Height = 0.1535433!
        Me.G1_SAGAKU_SEIKYU_KIN.Left = 9.979528!
        Me.G1_SAGAKU_SEIKYU_KIN.MultiLine = False
        Me.G1_SAGAKU_SEIKYU_KIN.Name = "G1_SAGAKU_SEIKYU_KIN"
        Me.G1_SAGAKU_SEIKYU_KIN.OutputFormat = resources.GetString("G1_SAGAKU_SEIKYU_KIN.OutputFormat")
        Me.G1_SAGAKU_SEIKYU_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.G1_SAGAKU_SEIKYU_KIN.SummaryGroup = "GroupHeader1"
        Me.G1_SAGAKU_SEIKYU_KIN.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All
        Me.G1_SAGAKU_SEIKYU_KIN.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal
        Me.G1_SAGAKU_SEIKYU_KIN.Text = "9,999,999,999"
        Me.G1_SAGAKU_SEIKYU_KIN.Top = 0.01023622!
        Me.G1_SAGAKU_SEIKYU_KIN.Width = 0.8181111!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.DataField = "JIMUITAKU_CD"
        Me.GroupHeader2.Height = 0.0!
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.Before
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New GrapeCity.ActiveReports.SectionReportModel.ARControl() {Me.Label27, Me.G2_KEIYAKUSYASU, Me.Label32, Me.Label33, Me.G2_TUMITATE_KIN, Me.G2_TESURYO, Me.G2_SEIKYU_KIN, Me.G2_HENKAN_KAKUTEI_KIN, Me.G2_SAGAKU_SEIKYU_KIN, Me.Line1})
        Me.GroupFooter2.Height = 0.1732284!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'Label27
        '
        Me.Label27.Height = 0.1535433!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 0.6755906!
        Me.Label27.Name = "Label27"
        Me.Label27.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " & _
            "ddo-char-set: 1"
        Me.Label27.Text = "事務委託先合計"
        Me.Label27.Top = 0.01023622!
        Me.Label27.Width = 1.014961!
        '
        'G2_KEIYAKUSYASU
        '
        Me.G2_KEIYAKUSYASU.DataField = "KEIYAKUSYA_CD"
        Me.G2_KEIYAKUSYASU.DistinctField = "KEIYAKUSYA_CD"
        Me.G2_KEIYAKUSYASU.Height = 0.1535433!
        Me.G2_KEIYAKUSYASU.Left = 1.804331!
        Me.G2_KEIYAKUSYASU.MultiLine = False
        Me.G2_KEIYAKUSYASU.Name = "G2_KEIYAKUSYASU"
        Me.G2_KEIYAKUSYASU.OutputFormat = resources.GetString("G2_KEIYAKUSYASU.OutputFormat")
        Me.G2_KEIYAKUSYASU.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.G2_KEIYAKUSYASU.SummaryFunc = GrapeCity.ActiveReports.SectionReportModel.SummaryFunc.DCount
        Me.G2_KEIYAKUSYASU.SummaryGroup = "GroupHeader2"
        Me.G2_KEIYAKUSYASU.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.G2_KEIYAKUSYASU.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.G2_KEIYAKUSYASU.Text = "9,999"
        Me.G2_KEIYAKUSYASU.Top = 0.01023622!
        Me.G2_KEIYAKUSYASU.Width = 0.344488!
        '
        'Label32
        '
        Me.Label32.Height = 0.1535433!
        Me.Label32.HyperLink = Nothing
        Me.Label32.Left = 1.686614!
        Me.Label32.Name = "Label32"
        Me.Label32.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " & _
            "ddo-char-set: 1"
        Me.Label32.Text = "（"
        Me.Label32.Top = 0.01023622!
        Me.Label32.Width = 0.1192911!
        '
        'Label33
        '
        Me.Label33.Height = 0.1535433!
        Me.Label33.HyperLink = Nothing
        Me.Label33.Left = 2.187795!
        Me.Label33.Name = "Label33"
        Me.Label33.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " & _
            "ddo-char-set: 1"
        Me.Label33.Text = "人）"
        Me.Label33.Top = 0.01023622!
        Me.Label33.Width = 0.2523622!
        '
        'G2_TUMITATE_KIN
        '
        Me.G2_TUMITATE_KIN.DataField = "TUMITATE_KIN"
        Me.G2_TUMITATE_KIN.Height = 0.1535433!
        Me.G2_TUMITATE_KIN.Left = 6.522441!
        Me.G2_TUMITATE_KIN.MultiLine = False
        Me.G2_TUMITATE_KIN.Name = "G2_TUMITATE_KIN"
        Me.G2_TUMITATE_KIN.OutputFormat = resources.GetString("G2_TUMITATE_KIN.OutputFormat")
        Me.G2_TUMITATE_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.G2_TUMITATE_KIN.SummaryGroup = "GroupHeader2"
        Me.G2_TUMITATE_KIN.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.G2_TUMITATE_KIN.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.G2_TUMITATE_KIN.Text = "9,999,999,999"
        Me.G2_TUMITATE_KIN.Top = 0.01023623!
        Me.G2_TUMITATE_KIN.Width = 0.8181111!
        '
        'G2_TESURYO
        '
        Me.G2_TESURYO.DataField = "TESURYO"
        Me.G2_TESURYO.Height = 0.1535433!
        Me.G2_TESURYO.Left = 7.438583!
        Me.G2_TESURYO.MultiLine = False
        Me.G2_TESURYO.Name = "G2_TESURYO"
        Me.G2_TESURYO.OutputFormat = resources.GetString("G2_TESURYO.OutputFormat")
        Me.G2_TESURYO.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.G2_TESURYO.SummaryGroup = "GroupHeader2"
        Me.G2_TESURYO.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.G2_TESURYO.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.G2_TESURYO.Text = "99,999,999"
        Me.G2_TESURYO.Top = 0.01023623!
        Me.G2_TESURYO.Width = 0.6307087!
        '
        'G2_SEIKYU_KIN
        '
        Me.G2_SEIKYU_KIN.DataField = "SEIKYU_KIN"
        Me.G2_SEIKYU_KIN.Height = 0.1535433!
        Me.G2_SEIKYU_KIN.Left = 8.166929!
        Me.G2_SEIKYU_KIN.MultiLine = False
        Me.G2_SEIKYU_KIN.Name = "G2_SEIKYU_KIN"
        Me.G2_SEIKYU_KIN.OutputFormat = resources.GetString("G2_SEIKYU_KIN.OutputFormat")
        Me.G2_SEIKYU_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.G2_SEIKYU_KIN.SummaryGroup = "GroupHeader2"
        Me.G2_SEIKYU_KIN.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.G2_SEIKYU_KIN.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.G2_SEIKYU_KIN.Text = "9,999,999,999"
        Me.G2_SEIKYU_KIN.Top = 0.01023623!
        Me.G2_SEIKYU_KIN.Width = 0.8181114!
        '
        'G2_HENKAN_KAKUTEI_KIN
        '
        Me.G2_HENKAN_KAKUTEI_KIN.DataField = "HENKAN_KAKUTEI_KIN"
        Me.G2_HENKAN_KAKUTEI_KIN.Height = 0.1535433!
        Me.G2_HENKAN_KAKUTEI_KIN.Left = 9.072835!
        Me.G2_HENKAN_KAKUTEI_KIN.MultiLine = False
        Me.G2_HENKAN_KAKUTEI_KIN.Name = "G2_HENKAN_KAKUTEI_KIN"
        Me.G2_HENKAN_KAKUTEI_KIN.OutputFormat = resources.GetString("G2_HENKAN_KAKUTEI_KIN.OutputFormat")
        Me.G2_HENKAN_KAKUTEI_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.G2_HENKAN_KAKUTEI_KIN.SummaryGroup = "GroupHeader2"
        Me.G2_HENKAN_KAKUTEI_KIN.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.G2_HENKAN_KAKUTEI_KIN.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.G2_HENKAN_KAKUTEI_KIN.Text = "9,999,999,999"
        Me.G2_HENKAN_KAKUTEI_KIN.Top = 0.01023623!
        Me.G2_HENKAN_KAKUTEI_KIN.Width = 0.8181111!
        '
        'G2_SAGAKU_SEIKYU_KIN
        '
        Me.G2_SAGAKU_SEIKYU_KIN.DataField = "SAGAKU_SEIKYU_KIN_KEI"
        Me.G2_SAGAKU_SEIKYU_KIN.Height = 0.1535433!
        Me.G2_SAGAKU_SEIKYU_KIN.Left = 9.979528!
        Me.G2_SAGAKU_SEIKYU_KIN.MultiLine = False
        Me.G2_SAGAKU_SEIKYU_KIN.Name = "G2_SAGAKU_SEIKYU_KIN"
        Me.G2_SAGAKU_SEIKYU_KIN.OutputFormat = resources.GetString("G2_SAGAKU_SEIKYU_KIN.OutputFormat")
        Me.G2_SAGAKU_SEIKYU_KIN.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: right; vertical-align: middle"
        Me.G2_SAGAKU_SEIKYU_KIN.SummaryGroup = "GroupHeader2"
        Me.G2_SAGAKU_SEIKYU_KIN.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group
        Me.G2_SAGAKU_SEIKYU_KIN.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal
        Me.G2_SAGAKU_SEIKYU_KIN.Text = "9,999,999,999"
        Me.G2_SAGAKU_SEIKYU_KIN.Top = 0.01023622!
        Me.G2_SAGAKU_SEIKYU_KIN.Width = 0.8181111!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.0!
        Me.Line1.Width = 10.8937!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 10.8937!
        Me.Line1.Y1 = 0.0!
        Me.Line1.Y2 = 0.0!
        '
        'Label35
        '
        Me.Label35.Height = 0.1571851!
        Me.Label35.HyperLink = Nothing
        Me.Label35.Left = 4.525985!
        Me.Label35.Name = "Label35"
        Me.Label35.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: left; ddo-char-set: 1"
        Me.Label35.Text = "（*：無効）　　　　（対象期の全データを出力しています）"
        Me.Label35.Top = 0.55!
        Me.Label35.Width = 3.762598!
        '
        'CrossSectionLine13
        '
        Me.CrossSectionLine13.Bottom = 0.01181103!
        Me.CrossSectionLine13.Left = 3.039764!
        Me.CrossSectionLine13.LineWeight = 1.0!
        Me.CrossSectionLine13.Name = "CrossSectionLine13"
        Me.CrossSectionLine13.Top = 0.7173229!
        '
        'Label47
        '
        Me.Label47.Height = 0.1889764!
        Me.Label47.HyperLink = Nothing
        Me.Label47.Left = 0.05157451!
        Me.Label47.Name = "Label47"
        Me.Label47.Style = "font-family: ＭＳ Ｐゴシック; font-size: 10pt; text-align: center; vertical-align: middl" & _
            "e"
        Me.Label47.Text = "契約"
        Me.Label47.Top = 0.7472442!
        Me.Label47.Width = 0.348!
        '
        'Label36
        '
        Me.Label36.Height = 0.1889764!
        Me.Label36.HyperLink = Nothing
        Me.Label36.Left = 2.929528!
        Me.Label36.Name = "Label36"
        Me.Label36.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " & _
            "ddo-char-set: 1"
        Me.Label36.Text = "*"
        Me.Label36.Top = 0.8291339!
        Me.Label36.Width = 0.1102362!
        '
        'MUKOU
        '
        Me.MUKOU.CanGrow = False
        Me.MUKOU.DataField = "MUKO"
        Me.MUKOU.Height = 0.1535433!
        Me.MUKOU.Left = 2.929134!
        Me.MUKOU.MultiLine = False
        Me.MUKOU.Name = "MUKOU"
        Me.MUKOU.Style = "font-family: ＭＳ Ｐ明朝; font-size: 9pt; text-align: center; vertical-align: middle; " & _
            "white-space: inherit"
        Me.MUKOU.Text = "*"
        Me.MUKOU.Top = 0.007874016!
        Me.MUKOU.Width = 0.1102361!
        '
        'rptGJ2030
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.3937008!
        Me.PageSettings.Margins.Left = 0.3937008!
        Me.PageSettings.Margins.Right = 0.3937008!
        Me.PageSettings.Margins.Top = 0.5905512!
        Me.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.69291!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PageSettings.PaperWidth = 8.267716!
        Me.PrintWidth = 10.89474!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " & _
                    "color: Black; font-family: MS UI Gothic; ddo-char-set: 128", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"))
        CType(Me.KEIYAKUSYA_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKU_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TUMITATE_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEIKYU_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HENKAN_KAKUTEI_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SAGAKU_SEIKYU_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TESURYO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NOFUKIGEN_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEIKYU_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KEIYAKU_JYOKYO_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEIKYU_HENKAN_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEIKYU_KAISU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ITAKU_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lbl_Seikyu3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sakuseibi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.H_SEIKYU_KAISU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TAISYO_KI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.H_SEIKYU_HENKAN_KBN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.H_SEIKYU_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.H_JIMUITAKU_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JIMUITAKU_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G1_KEIYAKUSYASU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G1_TUMITATE_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G1_TESURYO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G1_SEIKYU_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G1_HENKAN_KAKUTEI_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G1_SAGAKU_SEIKYU_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G2_KEIYAKUSYASU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G2_TUMITATE_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G2_TESURYO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G2_SEIKYU_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G2_HENKAN_KAKUTEI_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G2_SAGAKU_SEIKYU_KIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MUKOU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents PageHeader As GrapeCity.ActiveReports.SectionReportModel.PageHeader
    Private WithEvents PageFooter As GrapeCity.ActiveReports.SectionReportModel.PageFooter
    Private WithEvents GroupHeader1 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter1 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents KEIYAKUSYA_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents DTL_UPPER_LINE As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents ITAKU_NAME As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents KEIYAKUSYA_CD As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label55 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label24 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Lbl_Seikyu3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label28 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents sakuseibi As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label29 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label30 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TextBox7 As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label31 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents CrossSectionLine8 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine10 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents Line6 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents Label11 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label12 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents KEIYAKU_KBN_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents H_SEIKYU_KAISU As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label7 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label1 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label15 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label16 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label6 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label10 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label20 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TAISYO_KI As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label2 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label21 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents CrossSectionLine1 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine2 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine4 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine6 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine7 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents Label14 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label17 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents CrossSectionLine9 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents CrossSectionLine3 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents TUMITATE_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents SEIKYU_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents HENKAN_KAKUTEI_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents SAGAKU_SEIKYU_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents H_SEIKYU_HENKAN_KBN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents H_SEIKYU_DATE As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents H_JIMUITAKU_CD As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label4 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label18 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label9 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label13 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents TESURYO As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label5 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents CrossSectionLine5 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents NOFUKIGEN_DATE As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents SEIKYU_DATE As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label3 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label8 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents KEIYAKU_JYOKYO_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents SEIKYU_HENKAN_KBN_NM As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents SEIKYU_KAISU As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents CrossSectionLine11 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents Label19 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label22 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents CrossSectionLine12 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents Label25 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label26 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents JIMUITAKU_CD As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents GroupHeader2 As GrapeCity.ActiveReports.SectionReportModel.GroupHeader
    Private WithEvents GroupFooter2 As GrapeCity.ActiveReports.SectionReportModel.GroupFooter
    Private WithEvents Label27 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents G2_KEIYAKUSYASU As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label32 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label33 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents G2_TUMITATE_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents G2_TESURYO As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents G2_SEIKYU_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents G2_HENKAN_KAKUTEI_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents G2_SAGAKU_SEIKYU_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label23 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents G1_KEIYAKUSYASU As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label34 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents G1_TUMITATE_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents G1_TESURYO As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents G1_SEIKYU_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents G1_HENKAN_KAKUTEI_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents G1_SAGAKU_SEIKYU_KIN As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Line1 As GrapeCity.ActiveReports.SectionReportModel.Line
    Private WithEvents CrossSectionBox2 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionBox
    Private WithEvents MUKOU As GrapeCity.ActiveReports.SectionReportModel.TextBox
    Private WithEvents Label47 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents Label35 As GrapeCity.ActiveReports.SectionReportModel.Label
    Private WithEvents CrossSectionLine13 As GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine
    Private WithEvents Label36 As GrapeCity.ActiveReports.SectionReportModel.Label
End Class
