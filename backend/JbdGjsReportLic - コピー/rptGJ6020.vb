Imports GrapeCity.ActiveReports.SectionReportModel 
Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ6020
    Sub sub1(wkDSRep As DataSet)
End Interface
Public Class rptGJ6020
    Implements InterfaceRptGJ6020

    ''' <summary>
    ''' 2行ごとの線引きカウント
    ''' </summary>
    ''' <remarks></remarks>
    Dim LineCount As Integer = 0
    ''' <summary>
    ''' SEQ
    ''' </summary>
    ''' <remarks></remarks>
    Dim wSeq As Integer = 0
    ''' <summary>
    ''' 期金２
    ''' </summary>
    ''' <remarks></remarks>
    Friend pKIKIN2 As Boolean       '2017/07/14　追加
    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "生産者積立金繰越額及び返還額算定一覧表"

    Private Sub rptGJ6020_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        LineCount = 0
        wSeq = 0
        '2017/07/14　追加開始
        '第２基金の場合のみ、タイトルに(追加納付)を付加する
        If pKIKIN2 Then
            Label24.Text = "<<　生産者積立金繰越額及び返還額算定一覧表(契約者別)(追加納付)　>>"
        End If
        '2017/07/14　追加終了
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint

        LineCount = LineCount + 1
        Dim wLine As Integer = 0
        wLine = LineCount Mod 2

        If LineCount = 1 Then
            'ページの先頭行の罫線は非表示
            Me.DTL_UPPER_LINE.Visible = False

        ElseIf LineCount > 1 And wLine = 1 Then
            '2行目以降の場合は2行ごとに罫線を表示
            Me.DTL_UPPER_LINE.Visible = True
        Else
            Me.DTL_UPPER_LINE.Visible = False
        End If

        wSeq += 1
        SEQ.Text = wSeq

    End Sub

    Private Sub GroupFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.BeforePrint

        '生産者積立金繰越額（合計）の計算
        If SUM_HENKAN_KAKUTEI_KIN.Text = "" Then
            KURIKOSHIGAKU.Value = 0
        Else
            KURIKOSHIGAKU.Value = CDec(SUM_TUMITATE_KIN_KEI.Value) - CDec(SUM_KOFU_KIN_KEI.Value)
        End If

    End Sub

    Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.BeforePrint

        'ページブレイクで変数を初期化
        LineCount = 0
    End Sub
    Sub sub1(wkDSRep As DataSet) Implements InterfaceRptGJ6020.sub1
        Using wkAR As New rptGJ6020

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
