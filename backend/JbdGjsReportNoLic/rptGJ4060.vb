Imports GrapeCity.ActiveReports.SectionReportModel 
Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ4060
    Sub sub1(wkDSRep As DataSet, TITLE As String)
End Interface
Public Class rptGJ4060
    Implements InterfaceRptGJ4060
    '''' <summary>
    '''' 帳票タイトル
    '''' </summary>
    '''' <remarks></remarks>
    'Public TITLE As String = String.Empty
    '''' <summary>
    '''' 帳票名
    '''' </summary>
    '''' <remarks></remarks>
    'Private Const con_ReportName As String = "金融機関別・支店別振込明細表"

    'Private Sub rptGJ4060_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
    '    lblTITLE.Text = TITLE

    '    'ヘッダー情報を表示可にする
    '    H_TAISYO_KI.Visible = True
    '    lblBank.Visible = True
    '    FURI_BANK_CD.Visible = True
    '    BANK_NAME.Visible = True

    'End Sub

    'Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.BeforePrint
    '    If totalPageCount.Text = PageCount.Text Then
    '        '最終ページ（総合計ページ）は対象期、金融機関は非表示にする
    '        H_TAISYO_KI.Visible = False
    '        lblBank.Visible = False
    '        FURI_BANK_CD.Visible = False
    '        BANK_NAME.Visible = False
    '    End If
    'End Sub
    Sub sub1(wkDSRep As DataSet, TITLE As String) Implements InterfaceRptGJ4060.sub1
        'Using wkAR As New rptGJ4060

        '    '↓2017/07/14 タイトルに追加納付を追加
        '    Dim tuika As String = ""
        '    If pKikin2 Then
        '        tuika = "(追加納付)"
        '    End If
        '    ''ヘッダ用の値を保管
        '    'If chkIchiHen.Checked Or chkHenkan.Checked Then
        '    '    wkAR.TITLE = "<<　" & con_ReportName & "（積立金返還）　>>"
        '    'End If
        '    'If chkGojo.Checked Then
        '    '    wkAR.TITLE = "<<　" & con_ReportName & "（互助金交付）　>>"
        '    'End If
        '    'ヘッダ用の値を保管
        '    'If chkIchiHen.Checked Or chkHenkan.Checked Then
        '    '    wkAR.TITLE = "<<　" & con_ReportName & "（積立金返還）" & tuika & "　>>"
        '    'End If
        '    'If chkGojo.Checked Then
        '    '    wkAR.TITLE = "<<　" & con_ReportName & "（互助金交付）" & tuika & "　>>"
        '    'End If
        '    wkAR.TITLE = TITLE

        '    '↑2017/07/14 タイトルに追加納付を追加
        '    ' 用紙サイズを A4横 に設定します。
        '    wkAR.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        '    wkAR.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape
        '    ' 上下の余白を 1.0cm に設定します。
        '    wkAR.PageSettings.Margins.Top = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_UP)
        '    wkAR.PageSettings.Margins.Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_DOWN)
        '    'wkAR.PageSettings.Margins.Bottom = 0.87
        '    ' 左右の余白を 1.0cm に設定します。
        '    wkAR.PageSettings.Margins.Left = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_LEFT)
        '    wkAR.PageSettings.Margins.Right = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_RIGHT)

        '    '----------------------------------------------------
        '    wkAR.DataSource = wkDSRep
        '    wkAR.DataMember = wkDSRep.Tables(0).TableName
        '    wkAR.Run() '実行

        '    ''--------------------------------------------------
        '    ''ＰＤＦ出力
        '    ''--------------------------------------------------
        '    'ファイル存在ﾁｪｯｸ()
        '    Dim strOutPath As String = ""
        '    If Not f_ReportPath_Check(strOutPath, 0, myREPORT_PDF_PATH, pAPP & con_ReportName) Then
        '        Exit Sub

        '    Else
        '        Using export As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
        '            export.Export(wkAR.Document, strOutPath)
        '        End Using
        '    End If

        '    '--------------------------------------------------
        '    'プレビュー表示
        '    '--------------------------------------------------
        '    Dim wkForm As New frmViewer(wkAR, pAPP & con_ReportName) '※このプレビューは関数を抜けたあとも生き残る。
        '    wkForm.Show()
        'End Using
    End Sub
End Class
