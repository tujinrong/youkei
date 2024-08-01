Imports GrapeCity.ActiveReports.SectionReportModel 
Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ4040
    Sub sub1(wkDSRep As DataSet)
End Interface
Public Class rptGJ4040
    Implements InterfaceRptGJ4040
    Dim LineCount As Integer = 0
    '↓2017/07/28 追加 罫線
    Dim count As Integer = 0
    Dim oneline As Integer = False
    Dim firstline As Boolean = False
    '↑2017/07/28 追加
    ''' <summary>
    ''' 期金２
    ''' </summary>
    ''' <remarks></remarks>
    Friend pKIKIN2 As Boolean
    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "互助金交付一覧表（互助金種類・鶏の種類・農場）"

    Private Sub rptGJ4040_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        '2017/07/14　追加開始
        '第２基金の場合のみ、タイトルに(追加納付)を付加する
        If pKIKIN2 Then
            Label36.Text = "<<　互助金交付一覧表(互助種類・鶏の種類・農場)(追加納付)　>>"
        End If
        '2017/07/14　追加終了
    End Sub

    '↓2022/02/01 JBD437 ADD R03年度減額対応 互助金交付率追加
    '抽出したデータの互助金交付率が2つ以上存在する場合、非表示にする
    Private Sub PageHeader_Format(sender As Object, e As EventArgs) Handles PageHeader.Format
        If KOFU_RITU_CNT.Value > 1 Or KOFU_RITU.Text = "%" Then

            KOFU_RITU.Visible = False
        End If
    End Sub
    '↑2022/02/01 JBD437 ADD R03年度減額対応 互助金交付率追加

    '↓2017/07/28 追加 罫線
    '改ページ後一行目の場合は線を表示しない
    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint

        count += 2
        If count = 23 Then
            Line2.Visible = True
            count = 0
            oneline = True
        ElseIf count = 24 Then
            Line2.Visible = True
            count = 0
            oneline = False
        ElseIf count <= 2 Then
            Line2.Visible = False
        Else
            Line2.Visible = True
        End If

        If firstline Then
            Line2.Visible = False
            firstline = False
        End If
    End Sub
    Private Sub GroupHeader3_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader3.BeforePrint
        firstline = True
    End Sub
    Private Sub GroupFooter3_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter3.BeforePrint
        count += 1

        If count = 1 And oneline Then
            Line8.Visible = True
            Line9.Visible = False
            count = 0
        ElseIf count = 1 And Not oneline Then
            Line8.Visible = False
        Else
            Line8.Visible = True
        End If

        If count = 23 Then
            count = 0
            oneline = True
        ElseIf count = 24 Then
            count = 0
            oneline = False
        End If
    End Sub
    Private Sub GroupFooter2_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.BeforePrint
        If count = 0 And Not oneline Then
            Line8.Visible = False
        Else
            Line8.Visible = True
        End If
        count = 0
    End Sub
    '↑2017/07/28 追加
    Sub sub1(wkDSRep As DataSet) Implements InterfaceRptGJ4040.sub1
        Using wkAR As New rptGJ4040

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
