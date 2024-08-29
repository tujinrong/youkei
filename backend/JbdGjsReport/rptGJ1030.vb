' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: GJ1030
'            帳票処理
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsService
Imports JbdGjsService.JBD.GJS.Service
Imports JbdGjsService.JBD.GJS.Service.GJ1030

Public Interface InterfaceRptGJ1030
    Function report(param As String) As MemoryStream
End Interface

Public Class rptGJ1030
    Implements InterfaceRptGJ1030
    ''' <summary>
    ''' 2行ごとの線引きカウント
    ''' </summary>
    ''' <remarks></remarks>
    Dim LineCount As Integer = 0
    ''' <summary>
    ''' 2行ごとの線引きカウント
    ''' </summary>
    ''' <remarks></remarks>
    Dim LineCount2 As Integer = 0
    ''' <summary>
    ''' 期金２
    ''' </summary>
    ''' <remarks></remarks>
    Friend pKIKIN2 As Boolean       '2017/07/14　追加
    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "家畜防疫互助基金契約者一覧表(連絡用)"

    Private Sub rptGJ1030_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

        '2017/07/14　追加開始
        '第２基金の場合のみ、タイトルに(追加納付)を付加する
        If pKIKIN2 Then
            lblTitle.Text = "<<　家畜防疫互助基金契約者一覧表(連絡用)(追加納付)　>>"
        End If
        '2017/07/14　追加終了

    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint


    End Sub

    Private Sub GroupFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.BeforePrint


    End Sub

    Public Function report(param As String) As MemoryStream Implements InterfaceRptGJ1030.report

        Dim pr = System.Text.Json.JsonSerializer.Deserialize(Of JBD.GJS.Service.GJ1030.PreviewRequest)(param)
        '検索結果出力用ＳＱＬ作成
        Dim sql = FrmGJ1030Service.f_make_SQL(pr)

        'データSelect 
        Dim wkDSRep As New DataSet()
        Using db = New JbdGjsService.JBD.GJS.Service.DaDbContext()
            wkDSRep = FrmService.f_Select_ODP(db, sql, con_ReportName)
            'データ結果判定
            Dim dt = wkDSRep.Tables(0)
            If dt.Rows.Count = 0 Then
                Return New MemoryStream
            End If
        End Using

        ' Insert code here that implements this method.
        Using wkAR As New rptGJ1030

            'ヘッダ用の値を保管
            wkAR.pKIKIN2 = pKIKIN2      '2017/07/14　追加
            ' 用紙サイズを A4横 に設定します。
            wkAR.PageSettings.PaperKind = 9
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

            Dim ms As New MemoryStream()
            wkAR.Document.Save(ms, RdfFormat.ARNet)
            ms.Position = 0
            Return ms

        End Using
    End Function
End Class
