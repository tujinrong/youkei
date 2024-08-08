Imports GrapeCity.ActiveReports.SectionReportModel 
Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ5010
    Sub sub1(wkDSRep As DataSet)
End Interface

Public Class rptGJ5010
    Implements InterfaceRptGJ5010

    ''処理年度 1:第1年度まで 2:第2年度まで 3:第3年度まで
    'Public pSyori As Integer = 0
    '''' <summary>
    '''' 期金２
    '''' </summary>
    '''' <remarks></remarks>
    'Friend pKIKIN2 As Boolean       '2017/07/14　追加
    '''' <summary>
    '''' 帳票名
    '''' </summary>
    '''' <remarks></remarks>
    'Private Const con_ReportName As String = "互助基金納付・互助金交付・基金残高管理表"

    'Private Sub rptGJ5010_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

    '    '2017/07/14　追加開始
    '    '第２基金の場合のみ、タイトルに(追加納付)を付加する
    '    If pKIKIN2 Then
    '        lblTITLE.Text = "<<互助基金納付・互助金交付・基金残高管理表(請求・納入・交付・残高)(年度・3年間)(追加納付)>>"
    '    End If
    '    '2017/07/14　追加終了

    'End Sub
    ''Private Sub PageHeader_BeforePrint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader.BeforePrint
    ''    '↓2022/02/02 JBD439 ADD　R03年度対応　互助金交付率が2つ以上あるとき互助金交付率を表示しない
    ''    If KOFU_RITU_CNT.Text = 1 Then
    ''        KOFU_RITU.Visible = True
    ''    Else
    ''        KOFU_RITU.Visible = False
    ''    End If
    ''    '↑2022/02/02 JBD439 ADD
    ''End Sub
    'Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

    '    '画面の事業対象年度により表示する項目を変更する
    '    If pSyori = 1 Then
    '        '第2年度
    '        SIN_HASU2.Value = Nothing
    '        SIN_TUMITATE_KIN2.Value = Nothing
    '        HASU2_G.Value = Nothing
    '        TUMITATE_KIN2_G.Value = Nothing

    '        KEIEI_HASU2.Value = Nothing
    '        KEIEI_KOFU_KIN2.Value = Nothing
    '        SYOKYAKU_HASU2.Value = Nothing
    '        SYOKYAKU_KOFU_KIN2.Value = Nothing
    '        KOFU_KIN2_G.Value = Nothing
    '        ZANDAKA2.Value = Nothing
    '    End If

    '    If pSyori <= 2 Then
    '        '第3年度
    '        SIN_HASU3.Value = Nothing
    '        SIN_TUMITATE_KIN3.Value = Nothing
    '        HASU3_G.Value = Nothing
    '        TUMITATE_KIN3_G.Value = Nothing

    '        KEIEI_HASU3.Value = Nothing
    '        KEIEI_KOFU_KIN3.Value = Nothing
    '        SYOKYAKU_HASU3.Value = Nothing
    '        SYOKYAKU_KOFU_KIN3.Value = Nothing
    '        KOFU_KIN3_G.Value = Nothing
    '        ZANDAKA3.Value = Nothing
    '    End If


    '    '合計金額等の算出

    '    '新規加入者 契約変更者 合計 対象羽数
    '    SUM_SIN_HASU.Value = CDec(SIN_HASU1.Value) + CDec(SIN_HASU2.Value) + CDec(SIN_HASU3.Value)
    '    '新規加入者 契約変更者 合計 積立金額
    '    SUM_SIN_TUMITATE_KIN.Value = CDec(SIN_TUMITATE_KIN1.Value) + CDec(SIN_TUMITATE_KIN2.Value) + CDec(SIN_TUMITATE_KIN3.Value)

    '    '互助基金合計額 対象羽数
    '    SUM_HASU_G.Value = CDec(SUM_HASU.Value) + CDec(SUM_SIN_HASU.Value)
    '    '[５] 互助基金合計額 積立金額
    '    SUM_TUMITATE_KIN_G.Value = CDec(SUM_TUMITATE_KIN.Value) + CDec(SUM_SIN_TUMITATE_KIN.Value)

    '    '[７] 第1年度 互助基金 累計 積立金額
    '    TUMITATE_KIN1_R.Value = CDec(TUMITATE_KIN_R.Value) + CDec(TUMITATE_KIN1_G.Value)
    '    '[８] 第2年度 互助基金 累計 積立金額
    '    TUMITATE_KIN2_R.Value = CDec(TUMITATE_KIN1_R.Value) + CDec(TUMITATE_KIN2_G.Value)
    '    '[９] 第3年度 互助基金 累計 積立金額
    '    TUMITATE_KIN3_R.Value = CDec(TUMITATE_KIN2_R.Value) + CDec(TUMITATE_KIN3_G.Value)
    '    '[１０] 互助基金 累計 積立金額
    '    SUM_TUMITATE_KIN_R.Value = CDec(SUM_TUMITATE_KIN_G.Value)

    '    '[Ａ] 第1年度 互助金交付額 合計
    '    KOFU_KIN1_G.Value = CDec(KEIEI_KOFU_KIN1.Value) + CDec(SYOKYAKU_KOFU_KIN1.Value)
    '    '[Ｂ] 第2年度 互助金交付額 合計
    '    KOFU_KIN2_G.Value = CDec(KEIEI_KOFU_KIN2.Value) + CDec(SYOKYAKU_KOFU_KIN2.Value)
    '    '[Ｃ] 第3年度 互助金交付額 合計
    '    KOFU_KIN3_G.Value = CDec(KEIEI_KOFU_KIN3.Value) + CDec(SYOKYAKU_KOFU_KIN3.Value)

    '    '[Ｅ] 第1年度 互助金交付額 累計
    '    KOFU_KIN1_R.Value = CDec(KEIEI_KOFU_KIN1.Value) + CDec(SYOKYAKU_KOFU_KIN1.Value)
    '    '[Ｆ] 第2年度 互助金交付額 累計
    '    KOFU_KIN2_R.Value = CDec(KOFU_KIN1_R.Value) + CDec(KOFU_KIN2_G.Value)
    '    '[Ｇ] 第3年度 互助金交付額 累計
    '    KOFU_KIN3_R.Value = CDec(KOFU_KIN2_R.Value) + CDec(KOFU_KIN3_G.Value)

    '    '[ア] 第1年度 互助基金残高
    '    ZANDAKA1.Value = CDec(TUMITATE_KIN1_R.Value) - CDec(KOFU_KIN1_R.Value)
    '    '[イ] 第2年度 互助基金残高
    '    ZANDAKA2.Value = CDec(TUMITATE_KIN2_R.Value) - CDec(KOFU_KIN2_R.Value)
    '    '[ウ] 第3年度 互助基金残高
    '    ZANDAKA3.Value = CDec(TUMITATE_KIN3_R.Value) - CDec(KOFU_KIN3_R.Value)

    '    '経営支援 互助金交付額 対象羽数
    '    SUM_KEIEI_HASU.Value = CDec(KEIEI_HASU1.Value) + CDec(KEIEI_HASU2.Value) + CDec(KEIEI_HASU3.Value)
    '    '経営支援 互助金交付額 交付金額
    '    SUM_KEIEI_KOFU_KIN.Value = CDec(KEIEI_KOFU_KIN1.Value) + CDec(KEIEI_KOFU_KIN2.Value) + CDec(KEIEI_KOFU_KIN3.Value)
    '    '焼却・埋却 互助金交付額 対象羽数
    '    SUM_SYOKYAKU_HASU.Value = CDec(SYOKYAKU_HASU1.Value) + CDec(SYOKYAKU_HASU2.Value) + CDec(SYOKYAKU_HASU3.Value)
    '    '焼却・埋却 互助金交付額 交付金額
    '    SUM_SYOKYAKU_KOFU_KIN.Value = CDec(SYOKYAKU_KOFU_KIN1.Value) + CDec(SYOKYAKU_KOFU_KIN2.Value) + CDec(SYOKYAKU_KOFU_KIN3.Value)

    '    '[Ｄ] 互助金交付額 合計
    '    SUM_KOFU_KIN_G.Value = CDec(KOFU_KIN1_G.Value) + CDec(KOFU_KIN2_G.Value) + CDec(KOFU_KIN3_G.Value)
    '    '[Ｈ] 互助金交付額 累計
    '    SUM_KOFU_KIN_R.Value = CDec(SUM_KOFU_KIN_G.Value)
    '    '[エ] 互助基金残高
    '    SUM_ZANDAKA.Value = CDec(ZANDAKA3.Value)

    '    '第2年度
    '    TUMITATE_KIN2_R.Visible = True
    '    KOFU_KIN2_G.Visible = True
    '    KOFU_KIN2_R.Visible = True
    '    ZANDAKA2.Visible = True
    '    If pSyori = 1 Then
    '        '第2年度
    '        TUMITATE_KIN2_R.Visible = False
    '        KOFU_KIN2_G.Visible = False
    '        KOFU_KIN2_R.Visible = False
    '        ZANDAKA2.Visible = False
    '    End If

    '    '第3年度
    '    TUMITATE_KIN3_R.Visible = True
    '    KOFU_KIN3_G.Visible = True
    '    KOFU_KIN3_R.Visible = True
    '    ZANDAKA3.Visible = True
    '    If pSyori <= 2 Then
    '        TUMITATE_KIN3_R.Visible = False
    '        KOFU_KIN3_G.Visible = False
    '        KOFU_KIN3_R.Visible = False
    '        ZANDAKA3.Visible = False
    '    End If

    'End Sub

    'Private Sub PageFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.Format
    '    'ページフッタが、その前に出力されたセクションに
    '    '隣接するように、高さを設定します。
    '    Me.PageFooter.Height = Me.PageSettings.PaperWidth _
    '            - (Me.PageSettings.Margins.Top + Me.PageSettings.Margins.Bottom _
    '                 + Me.PageHeader.Height + Me.Detail.Height)

    'End Sub
    Sub sub1(wkDSRep As DataSet) Implements InterfaceRptGJ5010.sub1
        'Using wkAR As New rptGJ5010

        '    '処理年度設定
        '    wkAR.pSyori = pSyori

        '    'ヘッダ用の値を保管
        '    wkAR.pKIKIN2 = pKIKIN2      '2017/07/14　追加
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
