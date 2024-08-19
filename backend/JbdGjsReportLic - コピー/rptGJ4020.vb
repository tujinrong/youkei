Imports GrapeCity.ActiveReports.SectionReportModel 
Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ4020
    Sub sub1(wkDSRep As DataSet)
End Interface
Public Class rptGJ4020
    Implements InterfaceRptGJ4020

    '前のページのグループ情報を保持
    Private lo_BeforeKenCD As String
    Private lo_BeforeKenNM As String
    '↓2017/07/28 追加 罫線
    Private count As Integer = 0
    '↑2017/07/28 追加 罫線
    ''' <summary>
    ''' 期金２
    ''' </summary>
    ''' <remarks></remarks>
    Friend pKIKIN2 As Boolean
    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "互助金申請情報入力チェックリスト"

    Private Sub rptGJ4020_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

        '2017/07/14　追加開始
        '第２基金の場合のみ、タイトルに(追加納付)を付加する
        If pKIKIN2 Then
            Label36.Text = "<<　互助金申請情報入力チェックリスト(農場・互助種類・鶏の種類別)(追加納付)　>>"
        End If
        '2017/07/14　追加終了

    End Sub

    Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.BeforePrint
        '↓2017/07/28 追加 同じグループ内は回を同じにする
        ''詳細データが1ページちょうどの場合の対応
        Dim wkIsNoDetail As Boolean = CInt(txtGroupPage.Text) >= 2 '2ページ目以降かどうか。

        If wkIsNoDetail Then '前のページのグループ情報をセット
            TAISYO_KI.Text = lo_BeforeKenCD
        End If

        '前のページのグループ情報を待避
        lo_BeforeKenCD = TAISYO_KI.Text
        '↑2017/07/28 追加 
    End Sub

    Private Sub PageHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader.Format
        '↓2022/01/31 JBD439 ADD　R03年度対応　互助金交付率が2つ以上あるとき互助金交付率を表示しない
        If KOFU_RITU_CNT.Text = 1 Then
            KOFU_RITU.Visible = True
        Else
            KOFU_RITU.Visible = False
        End If
        '↑2022/01/31 JBD439 ADD
    End Sub

    Private Sub Detail_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail.Format
        'If txt_DOITU_SEISANSYA_NAME.Text.Trim = "" Then
        '    txt_Kakko1.Text = ""
        '    txt_Kakko2.Text = ""
        'Else
        '    txt_Kakko1.Text = "("
        '    txt_Kakko2.Text = ")"
        'End If
        '件数が1の場合は契約者計は表示させない
        If DTL_CNT.Value = 1 Then
            Me.GroupFooter3.Visible = False
        Else
            Me.GroupFooter3.Visible = True
        End If

    End Sub

    Private Sub rptGJ4020_ReportEnd(ByVal sender As Object, ByVal e As EventArgs) Handles Me.ReportEnd
        'sw.Close()
        '        Line8.Visible = False
    End Sub
    '↓2017/07/28 追加 罫線
    '改ページ後一行目の場合は線を表示しない
    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint
        If count = 15 Then
            Line2.Visible = True
            count = -1
        ElseIf count = 0 Then
            Line2.Visible = False
        Else
            Line2.Visible = True
        End If
        count += 1
    End Sub
    Private Sub GroupHeader3_BeforePrint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader3.BeforePrint
        If count = 0 Then
            Line12.Visible = False
        Else
            Line12.Visible = True
        End If
    End Sub
    Private Sub GroupFooter3_BeforePrint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter3.BeforePrint
        If count = 0 Then
            Line10.Visible = False
        Else
            Line10.Visible = True
        End If
        count += 1
    End Sub
    Private Sub GroupFooter2_BeforePrint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter2.BeforePrint
        If count = 0 Or count = 13 Or count = 14 Or count = 15 Then
            Line3.Visible = False
        Else
            Line3.Visible = True
        End If
        count = 0
    End Sub
    '↑2017/07/28 追加 罫線
    Sub sub1(wkDSRep As DataSet) Implements InterfaceRptGJ4020.sub1
        Using wkAR As New rptGJ4020

            'ヘッダ用の値を保管
            wkAR.pKIKIN2 = pKIKIN2      '2017/07/14　追加
            ' 用紙サイズを B4横 に設定します。
            wkAR.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.B4
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
