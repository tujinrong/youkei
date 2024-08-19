Imports GrapeCity.ActiveReports.SectionReportModel 
Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ4070
    Sub sub1(wkDSRep As DataSet, OutputKbn As Integer)
End Interface
Public Class rptGJ4070
    Implements InterfaceRptGJ4070

    '出力区分
    '0:固定レイアウトの場合(すべての鶏でかつ発生しない鶏の種類も印字する)
    '1:0以外のパターン
    Public OutputKbn As Integer = 0

    '合計出力判定
    Private SUM_Output As Boolean = False
    '↓2017/07/27 追加 鶏の種類追加
    Private topData As Boolean = False
    Private cntDetail As Integer = 0
    '↑2017/07/27 追加 鶏の種類追加
    ''' <summary>
    ''' 期金２
    ''' </summary>
    ''' <remarks></remarks>
    Friend pKIKIN2 As Boolean       '2017/07/14　追加
    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "互助金交付集計表"

    Private Sub rptGJ4070_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

        DTL_UNDER_LINE.Visible = True
        '2017/07/14　追加開始
        '第２基金の場合のみ、タイトルに(追加納付)を付加する
        If pKIKIN2 Then
            Label24.Text = "<<　互助金交付集計表(契約区分・互助金種類・鶏の種類)(追加納付)　>>"
        End If
        '2017/07/14　追加終了

    End Sub

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        '↓2017/07/27 修正 鶏の種類追加
        'If TORI_KBN.Text <> "9" Then
        If TORI_KBN.Text <> "99" Then
            '↑2017/07/27 修正 鶏の種類追加
            SUM_Output = True
            Detail.Visible = True
        Else
            If SUM_Output Then
                Detail.Visible = True
            Else
                Detail.Visible = False
            End If
            '↓2017/07/27 削除 鶏の種類追加
            'If KEIYAKU_KBN.Text = "3" Then
            '    'うずらの合計行は表示しない
            '    Detail.Visible = False
            'End If
            '↑2017/07/27 削除 鶏の種類追加
        End If

        '契約区分：うずらまたは合計行の場合、下罫線を出力しない
        '↓2017/07/27 削除 鶏の種類追加
        'If KEIYAKU_KBN.Text = "3" Or TORI_KBN.Text = "9" Then
        '    DTL_UNDER_LINE.Visible = False
        'Else
        '    DTL_UNDER_LINE.Visible = True
        'End If
        '↑2017/07/27 削除 鶏の種類追加

        '↓2017/07/27 追加 鶏の種類追加
        If Detail.Visible = True Then
            cntDetail = cntDetail + 1
            If cntDetail = 23 And topData = False Then
                DKEIYAKU_KBN_NM.Visible = True
            Else
                DKEIYAKU_KBN_NM.Visible = False
            End If
            If cntDetail = 22 Or TORI_KBN.Text = 99 Then
                DTL_UNDER_LINE.Visible = False
            Else
                DTL_UNDER_LINE.Visible = True
            End If
            topData = False
        End If
        '↑2017/07/27 追加 鶏の種類追加

    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

        '↓2017/07/27 削除 鶏の種類追加
        'If KEIYAKU_KBN.Text = "3" And TORI_KBN.Text = "9" Then
        '    'うずらの合計行は表示しない
        '    GroupHeader1.Visible = False
        '    Return
        'Else
        '    GroupHeader1.Visible = True
        'End If
        '↑2017/07/27 削除 鶏の種類追加

        '↓2017/07/27 修正 鶏の種類追加
        'If TORI_KBN.Text <> "9" Then
        If TORI_KBN.Text <> "99" Then
            '↑2017/07/27 修正 鶏の種類追加
            GroupHeader1.Visible = True
        Else
            GroupHeader1.Visible = False
        End If


    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

        '最終行の下罫線は出力しない
        '↓2017/07/27 修正 鶏の種類追加
        'If KEIYAKU_KBN.Text = "9" And OutputKbn = 0 Then
        If KEIYAKU_KBN.Text = "99" And OutputKbn = 0 Then
            '↑2017/07/27 修正 鶏の種類追加
            GroupFooter1.Visible = False
            Return
        Else
            GroupFooter1.Visible = True
        End If

        If SUM_Output Then
            GroupFooter1.Visible = True
            SUM_Output = False
        Else
            GroupFooter1.Visible = False
        End If
        '↓2017/07/27 追加 鶏の種類追加
        topData = True
        '↑2017/07/27 追加 鶏の種類追加
    End Sub
    '↓2017/07/27 追加 鶏の種類追加
    Private Sub PageHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader.Format
        cntDetail = 0

        '↓2022/02/04 JBD437 ADD R03年度減額対応 互助金交付率追加
        '抽出したデータの互助金交付率が2つ以上存在する場合、非表示にする
        If KOFU_RITU.Text = "%" Then
            KOFU_RITU.Visible = False
        End If
        '↑2022/02/01 JBD437 ADD R03年度減額対応 互助金交付率追加
    End Sub
    '↑2017/07/27 追加 鶏の種類追加
    Sub sub1(wkDSRep As DataSet, OutputKbn As Integer) Implements InterfaceRptGJ4070.sub1
        Using wkAR As New rptGJ4070

            ''出力区分を設定
            'If chkTori.Checked And chkUzura.Checked And chkOutput.Checked = False Then
            '    '固定レイアウトの場合(すべての鶏でかつ発生しない鶏の種類も印字する)
            '    wkAR.OutputKbn = 0
            'Else
            '    'すべての鶏、また発生しない鶏は印字しない場合
            wkAR.OutputKbn = OutputKbn
            'End If

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
