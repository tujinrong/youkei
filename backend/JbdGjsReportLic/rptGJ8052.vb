Imports GrapeCity.ActiveReports.SectionReportModel 
Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ8052
    Sub sub4(wkDSRep As DataSet)
    Sub sub3(dstDataRpt As DataSet, strRptNm As String, strOutPath As String, ByVal strDataMember As String)
End Interface
Public Class rptGJ8052
    Implements InterfaceRptGJ8052
    Private iPage As Integer = 0                'ページ
    Private blnUP_Line As Boolean = True        '罫線出力制御
    Private bLine_Detail As Boolean = True      '罫線出力制御
    Private strBuff As String
    Private iCnt As Integer = 0
    Private iToT As Integer = 0
    Private strBANK_CD As String

    'ページヘッダ
    Private Sub PageHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader.Format

        'ページ加算
        iPage += 1
        txt_Page.Text = iPage
        strBANK_CD = ""

    End Sub

    '支店・支所
    Private Sub GRP_HD_SITEN_CD_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRP_HD_SITEN_CD.Format

        If iCnt > 29 Then
            GRP_HD_SITEN_CD.NewPage = NewPage.Before
            iCnt = 0
        Else
            GRP_HD_SITEN_CD.NewPage = NewPage.None
        End If

    End Sub

    '明細   
    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        If strBANK_CD = "" Then
            strBANK_CD = txt_BANK_CD.Value
        Else
            txt_BANK_CD.Text = ""
            txt_BANK_NAME.Text = ""
        End If
    End Sub

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

    'フッタ
    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format

        txt_KENSU.Value = Format(iToT, "###,##0")
        RPT_FT_UP_LINE.Visible = blnUP_Line


    End Sub

    Sub sub4(dstDataSet As DataSet) Implements InterfaceRptGJ8052.sub4
        ''--------------------------------------------------
        ''ＰＤＦ出力
        ''--------------------------------------------------
        'If Not f_Pdf_Output(rptPdf, dstDataSet, dstDataSet.Tables(0).TableName) Then
        '    Exit Try
        'End If


        '--------------------------------------------------
        'プレビュー表示
        '--------------------------------------------------
        Dim fm As Form
        Dim strRptNm As String = String.Empty
        Dim pRptName As String = "金融機関マスタ"            '帳票名
        Using rpt As New rptGJ8052


            rpt.DataSource = dstDataSet
            rpt.DataMember = dstDataSet.Tables(0).TableName

            ' 用紙サイズを A4横 に設定します。
            rpt.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
            rpt.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape

            ' 上下の余白を 1.0cm に設定します。
            rpt.PageSettings.Margins.Top = GrapeCity.ActiveReports.SectionReport.CmToInch(1.0)
            rpt.PageSettings.Margins.Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(1.0)
            ' 左右の余白を 1.0cm に設定します。
            rpt.PageSettings.Margins.Left = GrapeCity.ActiveReports.SectionReport.CmToInch(1.0)
            rpt.PageSettings.Margins.Right = GrapeCity.ActiveReports.SectionReport.CmToInch(0.0)

            'レポート名取得
            '「GJ8050金融機関一覧」
            strRptNm = pAPP & pRptName

            'レポートプレビュー
            fm = New frmViewer(rpt, strRptNm)
            fm.Show()
        End Using

    End Sub

    Sub sub3(dstDataRpt As DataSet, strRptNm As String, strOutPath As String, ByVal strDataMember As String) Implements InterfaceRptGJ8052.sub3


        'ファイル存在ﾁｪｯｸ
        If Not f_ReportPath_Check(strOutPath, 0, myREPORT_PDF_PATH, strRptNm) Then
            Exit Sub
        End If
        Dim rptPdf As New rptGJ8052
        'ＰＤＦにエクスポートを行います。
        rptPdf.DataSource = dstDataRpt
        rptPdf.DataMember = strDataMember
        'rptPdf.DataMember = dstDataRpt.DataSetName     ' こちらの方が良いかも

        ' 用紙サイズを A4横 に設定します。
        rptPdf.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        rptPdf.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape

        ' 上下の余白を 1.0cm に設定します。
        rptPdf.PageSettings.Margins.Top = GrapeCity.ActiveReports.SectionReport.CmToInch(1.0)
        rptPdf.PageSettings.Margins.Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(1.0)
        ' 左右の余白を 1.0cm に設定します。
        rptPdf.PageSettings.Margins.Left = GrapeCity.ActiveReports.SectionReport.CmToInch(0.5)
        rptPdf.PageSettings.Margins.Right = GrapeCity.ActiveReports.SectionReport.CmToInch(0.0)

        rptPdf.Run()
        Dim export As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
        export.Export(rptPdf.Document, strOutPath)
        export.Dispose()

        ' レポートインスタンスをDisposeします。
        rptPdf.Document.Dispose()
        rptPdf.Dispose()
        rptPdf = Nothing

        'メモリを解放します
        Call s_GC_Dispose()
    End Sub



End Class
