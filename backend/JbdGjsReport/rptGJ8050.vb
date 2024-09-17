' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: GJ8050
'            帳票処理
' 作成日　　: 2024.09.12
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************
Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsService
Imports JbdGjsService.JBD.GJS.Service
Imports JbdGjsService.JBD.GJS.Service.GJ8050


Interface InterfaceRptGJ8050
    Function Report(param As String) As MemoryStream
End Interface

Public Class rptGJ8050
    Implements InterfaceRptGJ8050
    Private iPage As Integer = 0                'ページ
    Private blnUP_Line As Boolean = True        '罫線出力制御
    Private bLine_Detail As Boolean = True      '罫線出力制御
    Private strBuff As String
    Private iCnt As Integer = 0
    Private iToT As Integer = 0

    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "≪ 金融機関一覧表 ≫"

    'ページヘッダ
    Private Sub PageHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader.Format

        'ページ加算
        iPage += 1
        txt_Page.Text = iPage

    End Sub

    '金融機関ヘッダ
    Private Sub GRP_HD_BANK_CD_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRP_HD_BANK_CD.Format

        If iCnt > 34 Then
            GRP_HD_BANK_CD.NewPage = NewPage.Before
            iCnt = 0
        Else
            GRP_HD_BANK_CD.NewPage = NewPage.None
        End If

    End Sub

    '明細
    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint

        '件数加算
        iCnt += 1
        iToT += 1

        '５行毎に下線出力
        If iCnt Mod 5 = 0 Then
            DTL_DOWN_LINE.Visible = True
            blnUP_Line = False
        Else
            DTL_DOWN_LINE.Visible = False
            blnUP_Line = True
        End If

    End Sub

    '　レポートフッタ
    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format

        txt_KENSU.Value = Format(iToT, "###,##0")
        RPT_FT_UP_LINE.Visible = blnUP_Line

    End Sub

    Public Function Report(param As String) As MemoryStream Implements InterfaceRptGJ8050.Report

        Dim pr = System.Text.Json.JsonSerializer.Deserialize(Of JBD.GJS.Service.GJ8050.PreviewBankRequest)(param)
        '検索結果出力用ＳＱＬ作成
        Dim sql = FrmGJ8050Service.f_make_SQL(pr)

        'データSelect 
        Dim dstDataSet As New DataSet()
        Using db = New JbdGjsService.JBD.GJS.Service.DaDbContext()
            dstDataSet = FrmService.f_Select_ODP(db, sql, con_ReportName)
            'データ結果判定
            Dim dt = dstDataSet.Tables(0)
            If dt.Rows.Count = 0 Then
                Return New MemoryStream
            End If
        End Using

        '--------------------------------------------------
        'プレビュー表示
        '--------------------------------------------------
        'Dim fm As Form
        Dim strRptNm As String = String.Empty
        Dim pRptName As String = "金融機関マスタ"            '帳票名
        Using rpt As New rptGJ8050
            ''--------------------------------------------------
            ''プレビュー表示
            ''--------------------------------------------------

            ' 用紙サイズを A4横 に設定します。
            rpt.PageSettings.PaperKind = 9
            rpt.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape

            ' 上下の余白を 1.0cm に設定します。
            rpt.PageSettings.Margins.Top = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_UP)
            rpt.PageSettings.Margins.Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_DOWN)
            ' 左右の余白を 1.0cm に設定します。
            rpt.PageSettings.Margins.Left = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_LEFT)
            rpt.PageSettings.Margins.Right = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_RIGHT)

            'レポート名取得
            '「GJ8050金融機関一覧」
            strRptNm = pAPP & pRptName

            'レポートプレビュー
            rpt.DataSource = dstDataSet
            rpt.DataMember = dstDataSet.Tables(0).TableName
            rpt.Run() '実行

            Dim ms As New MemoryStream()
            rpt.Document.Save(ms, RdfFormat.ARNet)
            ms.Position = 0
            Return ms
        End Using

    End Function

End Class
