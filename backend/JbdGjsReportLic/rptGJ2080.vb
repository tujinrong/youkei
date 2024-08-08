Imports GrapeCity.ActiveReports.SectionReportModel 
Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ2080
    Sub sub1(wkDSRep As DataSet)
End Interface
Public Class rptGJ2080
    Implements InterfaceRptGJ2080
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
    Private Const con_ReportName As String = "生産者積立請求・返還一覧表（確定処理・未処理）"

    Private Sub rptGJ2080_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

        '2017/07/14　追加開始
        '第２基金の場合のみ、タイトルに(追加納付)を付加する
        If pKIKIN2 Then
            Label36.Text = "<<　生産者積立金等請求・返還一覧表(処理確定・未処理)(追加納付)　>>"
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

        Detail.Visible = True

        '2016/03/10　修正開始
        '入金区分で未入金のものはDetailを表示しない
        'If NYUKIN_KBN.Text = Nothing Then
        '    Detail.Visible = False
        'End If

        If DTL_FLG.Text = 0 Then
            Detail.Visible = False
        End If
        '2016/03/10　修正終了
    End Sub

    Private Sub GroupFooter3_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter3.BeforePrint


    End Sub

    Private Sub GroupHeader4_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader4.BeforePrint

        '2016/12/28　追加開始
        '契約者の2回目以降の請求の場合のみ、上罫線を出力
        If txtLINE_NO.Text.Trim = "1" Then
            GroupHeader4_OverLine.Visible = False
        Else
            GroupHeader4_OverLine.Visible = True
        End If
        '2016/12/28　追加終了

    End Sub

    Private Sub GroupHeader4_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader4.Format

    End Sub

    Private Sub GroupFooter2_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter2.Format
        Dim wNYUKIN_GAKU_SEI As Decimal = 0
        Dim wNYUKIN_GAKU_NYU As Decimal = 0
        Dim wNYUKIN_GAKU_HEN As Decimal = 0
        Dim wNYUKIN_GAKU_FRI As Decimal = 0

        '請求
        wNYUKIN_GAKU_SEI = SAGAKU_SEIKYU_KIN_NOFU_ITK_KEI.Value
        wNYUKIN_GAKU_NYU = NYUKIN_GAKU_NYU.Value
        NYUKIN_GAKU_ZAN_NYU.Value = wNYUKIN_GAKU_SEI - wNYUKIN_GAKU_NYU

        '返還
        wNYUKIN_GAKU_HEN = NYUKIN_GAKU_HEN.Value
        wNYUKIN_GAKU_FRI = NYUKIN_GAKU_FRI.Value
        NYUKIN_GAKU_ZAN_FRI.Value = NYUKIN_GAKU_HEN.Value - NYUKIN_GAKU_FRI.Value

    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Dim wNYUKIN_GAKU_SEI_SOKEI As Decimal = 0
        Dim wNYUKIN_GAKU_NYU_SOKEI As Decimal = 0
        Dim wNYUKIN_GAKU_HEN_SOKEI As Decimal = 0
        Dim wNYUKIN_GAKU_FRI_SOKEI As Decimal = 0

        '請求
        wNYUKIN_GAKU_SEI_SOKEI = SAGAKU_SEIKYU_KIN_NOFU_SOKEI.Value
        wNYUKIN_GAKU_NYU_SOKEI = NYUKIN_GAKU_NYU_SOKEI.Value
        NYUKIN_GAKU_ZAN_NYU_SOKEI.Value = wNYUKIN_GAKU_SEI_SOKEI - wNYUKIN_GAKU_NYU_SOKEI

        '返還
        wNYUKIN_GAKU_HEN_SOKEI = NYUKIN_GAKU_HEN_SOKEI.Value
        wNYUKIN_GAKU_FRI_SOKEI = NYUKIN_GAKU_FRI_SOKEI.Value
        NYUKIN_GAKU_ZAN_FRI_SOKEI.Value = NYUKIN_GAKU_HEN_SOKEI.Value - NYUKIN_GAKU_FRI_SOKEI.Value
    End Sub
    Sub sub1(wkDSRep As DataSet) Implements InterfaceRptGJ2080.sub1
        Using wkAR As New rptGJ2080

            'ヘッダ用の値を保管
            wkAR.pKIKIN2 = pKIKIN2      '2017/07/14　追加
            ' 用紙サイズを B4横 に設定します。
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
