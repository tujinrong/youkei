Imports GrapeCity.ActiveReports.SectionReportModel 
Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ8052
    Sub sub4(wkDSRep As DataSet)
    Sub sub3(dstDataRpt As DataSet, strRptNm As String, strOutPath As String, ByVal strDataMember As String)
End Interface
Public Class rptGJ8052
    Implements InterfaceRptGJ8052
    'Private iPage As Integer = 0                'ページ
    'Private blnUP_Line As Boolean = True        '罫線出力制御
    'Private bLine_Detail As Boolean = True      '罫線出力制御
    'Private strBuff As String
    'Private iCnt As Integer = 0
    'Private iToT As Integer = 0
    'Private strBANK_CD As String

    ''ページヘッダ
    'Private Sub PageHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader.Format

    '    'ページ加算
    '    iPage += 1
    '    txt_Page.Text = iPage
    '    strBANK_CD = ""

    'End Sub

    ''支店・支所
    'Private Sub GRP_HD_SITEN_CD_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRP_HD_SITEN_CD.Format

    '    If iCnt > 29 Then
    '        GRP_HD_SITEN_CD.NewPage = NewPage.Before
    '        iCnt = 0
    '    Else
    '        GRP_HD_SITEN_CD.NewPage = NewPage.None
    '    End If

    'End Sub

    ''明細   
    'Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
    '    If strBANK_CD = "" Then
    '        strBANK_CD = txt_BANK_CD.Value
    '    Else
    '        txt_BANK_CD.Text = ""
    '        txt_BANK_NAME.Text = ""
    '    End If
    'End Sub

    'Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint

    '    '件数加算
    '    iCnt += 1
    '    iToT += 1

    '    '５行毎に下線出力
    '    If iCnt Mod 5 = 0 Then
    '        DTL_DOWN_LINE.Visible = True
    '        blnUP_Line = False
    '    Else
    '        DTL_DOWN_LINE.Visible = False
    '        blnUP_Line = True
    '    End If

    'End Sub

    ''フッタ
    'Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format

    '    txt_KENSU.Value = Format(iToT, "###,##0")
    '    RPT_FT_UP_LINE.Visible = blnUP_Line


    'End Sub

    Sub sub4(dstDataSet As DataSet) Implements InterfaceRptGJ8052.sub4

    End Sub

    Sub sub3(dstDataRpt As DataSet, strRptNm As String, strOutPath As String, ByVal strDataMember As String) Implements InterfaceRptGJ8052.sub3

    End Sub

End Class
