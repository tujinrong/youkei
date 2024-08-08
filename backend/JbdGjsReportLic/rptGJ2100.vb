Imports GrapeCity.ActiveReports.SectionReportModel 
Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ2100
    Sub sub1(wkDSRep As DataSet)
End Interface
Public Class rptGJ2100
    Implements InterfaceRptGJ2100
    Dim LineCount As Integer = 0
    ''' <summary>
    ''' 期金２
    ''' </summary>
    ''' <remarks></remarks>
    Friend pKIKIN2 As Boolean       '2017/07/14　追加
    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "生産者積立金など集計表"

    Private Sub rptGJ2100_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

        '2017/07/14　追加開始
        '第２基金の場合のみ、タイトルに(追加納付)を付加する
        If pKIKIN2 Then
            Label36.Text = "<<　生産者積立金等集計表(鶏の種類別)(追加納付)　>>"
        End If
        '2017/07/14　追加終了

    End Sub
    Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.BeforePrint

    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint




    End Sub

    Private Sub Detail_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail.Format


    End Sub

    Private Sub GroupHeader3_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader3.BeforePrint

    End Sub

    Private Sub GroupFooter3_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter3.BeforePrint


    End Sub
    Sub sub1(wkDSRep As DataSet) Implements InterfaceRptGJ2100.sub1
        Using wkAR As New rptGJ2100

            'ヘッダ用の値を保管
            wkAR.pKIKIN2 = pKIKIN2      '2017/07/14　追加
            ' 用紙サイズを A4横 に設定します。
            wkAR.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
            wkAR.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape
            ' 上下の余白を 1.0cm に設定します。
            wkAR.PageSettings.Margins.Top = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_UP)
            wkAR.PageSettings.Margins.Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_DOWN)
            'wkAR.PageSettings.Margins.Bottom = 0.87
            ' 左右の余白を 1.0cm に設定します。
            wkAR.PageSettings.Margins.Left = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_LEFT)
            wkAR.PageSettings.Margins.Right = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_RIGHT)

            '----------------------------------------------------
            wkAR.DataSource = wkDSRep
            wkAR.DataMember = wkDSRep.Tables(0).TableName
            wkAR.Run() '実行

            ''--------------------------------------------------
            ''ＰＤＦ出力
            ''--------------------------------------------------
            'ファイル存在ﾁｪｯｸ()
            Dim strOutPath As String = ""
            If Not f_ReportPath_Check(strOutPath, 0, myREPORT_PDF_PATH, pAPP & con_ReportName) Then
                Exit Sub
            Else
                Using export As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                    export.Export(wkAR.Document, strOutPath)
                End Using
            End If

            '--------------------------------------------------
            'プレビュー表示
            '--------------------------------------------------
            Dim wkForm As New frmViewer(wkAR, pAPP & con_ReportName) '※このプレビューは関数を抜けたあとも生き残る。
            wkForm.Show()
        End Using
    End Sub
End Class
