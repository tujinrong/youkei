'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ5010.vb
'*
'*　　②　機能概要　　　　　互助基金納付・互助金交付・基金残高管理表
'*
'*　　③　作成日　　　　　　2015/03/19 JBD368
'*
'*　　④　更新日            2022/02/02 JBD439 R03年度対応
'*
'*******************************************************************************
Option Strict Off
Option Explicit On
'------------------------------------------------------------------
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
'------------------------------------------------------------------

Imports JbdGjsCommon
Imports JbdGjsControl
Imports System.Data
Imports System.Windows.Forms
Imports System.Collections
Imports System.IO
Imports System.Text

Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.ActiveReports.Export
Imports GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
Imports JbdGjsReport


Public Class frmGJ5010

#Region "***変数定義***"

    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ

    ''' <summary>
    ''' プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True                     '処理ジャンプ

    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "互助基金納付・互助金交付・基金残高管理表"

    '処理対象期・年度マスタ
    Private pObjTM_SYORI_NENDO_KI As Obj_TM_SYORI_NENDO_KI

    '事業対象年月日From
    Private pTaisyoNendoF As String = String.Empty
    '事業対象年月日To
    Private pTaisyoNendoT As String = String.Empty
    '対象年度1 FromTo
    Private pNendoFrom1 As String = String.Empty
    Private pNendoTo1 As String = String.Empty
    '対象年度2 FromTo
    Private pNendoFrom2 As String = String.Empty
    Private pNendoTo2 As String = String.Empty
    '対象年度3 FromTo
    Private pNendoFrom3 As String = String.Empty
    Private pNendoTo3 As String = String.Empty

    '処理年度 1:第1年度まで 2:第2年度まで 3:第3年度まで
    Private pSyori As Integer = 0
#End Region

#Region "***画面制御関連***"

#Region "Form_Loadイベント"
    ''' <summary>
    ''' フォームロード時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmXXXLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean
        Try

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear("C")

            'チェンジイベント
            f_setControlChangeEvents()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

    End Sub
#End Region

#Region "f_setControlChangeEvents 変更判定イベント登録"
    ''' <summary>
    ''' 変更判定イベント登録
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub f_setControlChangeEvents()
        For Each wkCtrl In Me.Controls
            Select Case True
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcComboBox
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcComboBox).TextChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcDate
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcDate).TextChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcMask
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcMask).TextChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcNumber
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcNumber).TextChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcTextBox
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcTextBox).TextChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.RadioButton
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.RadioButton).CheckedChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.CheckBox
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.CheckBox).CheckedChanged, AddressOf f_setChanged


            End Select
        Next
    End Sub

#End Region

#Region "f_setChanged コントロール変更時処理"

    ''' <summary>
    ''' コントロール変更時処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub f_setChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pblnTextChange = True
    End Sub
#End Region

#Region "期"
    '------------------------------------------------------------------
    'プロシージャ名  :numKI_Validating
    '説明            :期Validatingイベント
    '------------------------------------------------------------------
    Private Sub numKI_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numKI.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

    End Sub
#End Region

#End Region

#Region "***画面ボタンクリック関連***"

#Region "cmdPreview_Click プレビューボタンクリック処理"
    ''' <summary>
    ''' プレビューボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        Dim ea As New System.ComponentModel.CancelEventArgs

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '事前チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '帳票出力処理
            If Not f_Report_Output() Then
                Exit Try
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try
    End Sub
#End Region

#Region "cmdCancel_Click キャンセルボタンクリック処理"
    ''' <summary>
    ''' キャンセルボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Dim ret As Boolean

        Try
            'If pblnTextChange Then
            '    '画面に変更があり保存していない場合は、メッセージ表示
            '    If Show_MessageBox("Q007", "") = DialogResult.No Then
            '        '「いいえ」を選択
            '        Exit Sub
            '    End If
            'End If
            ret = f_ObjectClear("")
            '出力区分にフォーカスセット
            rdoSeikyu.Focus()
            pblnTextChange = False             '画面入力内容変更フラグ初期化

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try
    End Sub

#End Region

#Region "cmdEnd_Click 戻るボタンクリック処理"

    ''' <summary>
    ''' 戻るボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try
            'If pblnTextChange Then
            '    '画面に変更があり保存していない場合は、メッセージ表示
            '    If Show_MessageBox("Q007", "") = DialogResult.No Then
            '        Exit Try
            '    End If
            'Else
            If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                '処理を終了しますか？
                Exit Try
            End If
            'End If

            pblnTextChange = False      '画面入力内容変更フラグ初期化
            'フォームクローズ
            Me.AutoValidate = AutoValidate.Disable
            Me.Close()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'フォームクローズ
            Me.Close()
        End Try

    End Sub
#End Region

#End Region

#Region "*** 画面コントロール制御関連 ***"
#Region "s_FormControls_TextChanged 画面コントロールTextChangeイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :s_FormControls_TextChanged
    '説明            :画面コントロールTextChangeイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub s_FormControls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dateTaisyoYear.TextChanged

        pblnTextChange = True
    End Sub
#End Region
#End Region

#Region "帳票レポート出力関連"
#Region "f_Report_Output 帳票レポート出力処理"
    ''' <summary>
    '''  帳票レポート出力処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Report_Output() As Boolean
        Dim wkSql As String = String.Empty
        Dim wkDSRep As DataSet = New DataSet

        Try
            If rdoSeikyu.Checked Then
                ''--------------------------------------------------
                ''データ取得 請求ベース
                ''--------------------------------------------------
                '互助基金納付額データ
                If Not f_make_SQL_SeikyuNofu(wkDSRep) Then
                    'エラーリスト出力なし
                    Call Show_MessageBox("I002", "")
                    Exit Try
                End If
                '新規／契約変更データ
                If Not f_make_SQL_SeikyuSinki(wkDSRep) Then
                    Exit Try
                End If

            End If
            If rdoNyukin.Checked Then
                ''--------------------------------------------------
                ''データ取得 入金ベース
                ''--------------------------------------------------
                '互助基金納付額データ
                If Not f_make_SQL_NyukinNofu(wkDSRep) Then
                    'エラーリスト出力なし
                    Call Show_MessageBox("I002", "")
                    Exit Try
                End If
                '新規／契約変更データ
                If Not f_make_SQL_NyukinSinki(wkDSRep) Then
                    Exit Try
                End If

            End If

            '互助金交付額データ(請求ベース・入金ベース共通で使用）
            If Not f_make_SQL_Kofu(wkDSRep) Then
                Exit Try
            End If

            '互助金交付率取得
            If Not f_make_SQL_Kofu_Sinsei(wkDSRep) Then
                Exit Try
            End If

            If wkDSRep.Tables(0).Rows.Count > 0 Then
                Dim w As New rptGJ5010
                w.sub1(wkDSRep)
                'Using wkAR As New rptGJ5010

                '    '処理年度設定
                '    wkAR.pSyori = pSyori

                '    'ヘッダ用の値を保管
                '    wkAR.pKIKIN2 = pKikin2      '2017/07/14　追加
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
                '        Exit Try
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

            Else
                'エラーリスト出力なし
                Call Show_MessageBox("I002", "")
                Return False
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'メモリを解放します
            Call s_GC_Dispose()
        End Try

        Return True
    End Function
#End Region

#Region "f_make_SQL_SeikyuNofu 請求ベース納付額データＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_make_SQL_SeikyuNofu
    '説明            :請求ベース納付額データＳＱＬ作成
    '引数            :区分
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    ''' <summary>
    ''' ＳＱＬ文作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_make_SQL_SeikyuNofu(ByRef wkDSRep As DataSet) As Boolean
        Dim ret As Boolean = False
        Dim wSQL As String = String.Empty

        Try

            wSQL = ""
            wSQL += "SELECT " & vbCrLf
            '作成日
            wSQL += "  TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', " & vbCrLf
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI " & vbCrLf
            '集約区分（ヘッダー）
            wSQL += " , '請求ベース' AS OUTPUT_KBN" & vbCrLf
            '対象期・年度（ヘッダー）
            wSQL += " , '対象期・年度：第" & numKI.Value & "期（' || TO_CHAR(TO_DATE('" & pTaisyoNendoF & "'), 'EEYY""年度""',"
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '　～　' || "
            wSQL += "    TO_CHAR(TO_DATE('" & DateTime.Parse(pTaisyoNendoT).AddYears(-1).ToString("yyyy/MM/dd") & "'), 'EEYY""年度""',"
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '）' AS H_TAISYO_KI " & vbCrLf

            '契約開始日
            Dim culture As Globalization.CultureInfo = New Globalization.CultureInfo("ja-JP")
            Dim sWareki As String = String.Empty
            culture.DateTimeFormat.Calendar = New System.Globalization.JapaneseCalendar
            '和暦に変換（ggは元号を現す）
            sWareki = DateTime.Parse(pTaisyoNendoF).ToString("ggyy年度M月d日", culture)

            wSQL += " , '（" & sWareki & "契約）' AS KEIYAKU_DATE " & vbCrLf
            '第1年度
            wSQL += " , TO_CHAR(TO_DATE('" & pNendoFrom1 & "'),'EEYY""年度""',"
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NENDO1 " & vbCrLf
            '第2年度
            wSQL += " , TO_CHAR(TO_DATE('" & pNendoFrom2 & "'),'EEYY""年度""',"
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NENDO2 " & vbCrLf
            '第3年度
            wSQL += " , TO_CHAR(TO_DATE('" & pNendoFrom3 & "'),'EEYY""年度""',"
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NENDO3 " & vbCrLf

            '互助基金納付額 対象羽数
            wSQL += " ,M.HASU " & vbCrLf
            '互助基金納付額 積立金額
            'wSQL += " ,T.TUMITATE_KIN " & vbCrLf           '2017/07/27　修正
            wSQL += " ,NVL(T.TUMITATE_KIN,0) TUMITATE_KIN"  '2017/07/27　修正

            '以下は以降のSQL抽出結果を格納するための項目設定
            wSQL += " ,NULL AS SIN_HASU1 " & vbCrLf
            wSQL += " ,NULL AS SIN_HASU2 " & vbCrLf
            wSQL += " ,NULL AS SIN_HASU3 " & vbCrLf
            wSQL += " ,NULL AS SIN_TUMITATE_KIN1 " & vbCrLf
            wSQL += " ,NULL AS SIN_TUMITATE_KIN2 " & vbCrLf
            wSQL += " ,NULL AS SIN_TUMITATE_KIN3 " & vbCrLf
            wSQL += " ,NULL AS KEIEI_HASU1 " & vbCrLf
            wSQL += " ,NULL AS KEIEI_HASU2 " & vbCrLf
            wSQL += " ,NULL AS KEIEI_HASU3 " & vbCrLf
            wSQL += " ,NULL AS KEIEI_KOFU_KIN1 " & vbCrLf
            wSQL += " ,NULL AS KEIEI_KOFU_KIN2 " & vbCrLf
            wSQL += " ,NULL AS KEIEI_KOFU_KIN3 " & vbCrLf
            wSQL += " ,NULL AS SYOKYAKU_HASU1 " & vbCrLf
            wSQL += " ,NULL AS SYOKYAKU_HASU2 " & vbCrLf
            wSQL += " ,NULL AS SYOKYAKU_HASU3 " & vbCrLf
            wSQL += " ,NULL AS SYOKYAKU_KOFU_KIN1 " & vbCrLf
            wSQL += " ,NULL AS SYOKYAKU_KOFU_KIN2 " & vbCrLf
            wSQL += " ,NULL AS SYOKYAKU_KOFU_KIN3 " & vbCrLf

            '↓2022/02/03 JBD439 ADD  R03年度対応　 データ件数を追加
            wSQL += " ,NULL AS KOFU_RITU " & vbCrLf
            '↑2022/02/03 JBD439 ADD  R03年度対応　

            'FROM
            wSQL += "FROM " & vbCrLf
            wSQL += " ( " & vbCrLf
            wSQL += "  SELECT " & vbCrLf
            wSQL += "    SUM(T.TUMITATE_KIN) AS TUMITATE_KIN " & vbCrLf
            wSQL += "  FROM " & vbCrLf
            wSQL += "    TT_TUMITATE T " & vbCrLf
            wSQL += "  WHERE " & vbCrLf
            wSQL += "      T.KEIYAKU_DATE_FROM = TO_DATE('" & pTaisyoNendoF & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "  AND T.KEIYAKU_HENKO_KBN = 0 " & vbCrLf
            wSQL += "  AND T.KI = " & numKI.Value & vbCrLf
            wSQL += "  AND T.SEIKYU_HENKAN_KBN <> 4 " & vbCrLf
            wSQL += " ) T, " & vbCrLf
            wSQL += " ( " & vbCrLf
            wSQL += "  SELECT " & vbCrLf
            wSQL += "    SUM(M.HASU) AS HASU " & vbCrLf
            wSQL += "  FROM " & vbCrLf
            wSQL += "    TT_TUMITATE T, " & vbCrLf
            wSQL += "    TT_TUMITATE_MEISAI M " & vbCrLf
            wSQL += "  WHERE " & vbCrLf
            wSQL += "      T.KI = M.KI " & vbCrLf
            wSQL += "  AND T.SEIKYU_KAISU = M.SEIKYU_KAISU " & vbCrLf
            wSQL += "  AND T.KEIYAKUSYA_CD = M.KEIYAKUSYA_CD " & vbCrLf
            wSQL += "  AND T.TUMITATE_KBN = M.TUMITATE_KBN " & vbCrLf
            wSQL += "  AND T.KEIYAKU_DATE_FROM = TO_DATE('" & pTaisyoNendoF & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "  AND T.KEIYAKU_HENKO_KBN = 0 " & vbCrLf
            wSQL += "  AND T.KI = " & numKI.Value & vbCrLf
            wSQL += "  AND T.SEIKYU_HENKAN_KBN <> 4 " & vbCrLf
            wSQL += " ) M " & vbCrLf

            If Not f_Select_ODP(wkDSRep, wSQL) Then
                Exit Try
            End If

            'データ存在チェック
            If WordHenkan("N", "S", wkDSRep.Tables(0).Rows(0).Item("HASU")) = "" Then
                Exit Try
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_make_SQL_SeikyuSinki 請求ベース新規等データＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_make_SQL_SeikyuSinki
    '説明            :請求ベース新規等データＳＱＬ作成
    '引数            :区分
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    ''' <summary>
    ''' ＳＱＬ文作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_make_SQL_SeikyuSinki(ByRef wkDSRep As DataSet) As Boolean
        Dim ret As Boolean = False
        Dim wSQL As String = String.Empty
        Dim wkDs As DataSet = New DataSet

        Try
            wSQL = ""
            wSQL += "SELECT " & vbCrLf
            '新規加入者等 対象羽数1
            wSQL += "   NVL(M.SIN_HASU1,0) AS SIN_HASU1 " & vbCrLf
            '新規加入者等 積立金額1
            wSQL += " , NVL(T.SIN_TUMITATE_KIN1,0) AS SIN_TUMITATE_KIN1 " & vbCrLf
            '新規加入者等 対象羽数2
            wSQL += " , NVL(M.SIN_HASU2,0) AS SIN_HASU2 " & vbCrLf
            '新規加入者等 積立金額2
            wSQL += " , NVL(T.SIN_TUMITATE_KIN2,0) AS SIN_TUMITATE_KIN2 " & vbCrLf
            '新規加入者等 対象羽数3
            wSQL += " , NVL(M.SIN_HASU3,0) AS SIN_HASU3 " & vbCrLf
            '新規加入者等 積立金額3
            wSQL += " , NVL(T.SIN_TUMITATE_KIN3,0) AS SIN_TUMITATE_KIN3 " & vbCrLf

            '積立金抽出
            wSQL += "FROM " & vbCrLf
            wSQL += " ( " & vbCrLf
            wSQL += "  SELECT " & vbCrLf
            wSQL += "    SUM(CASE WHEN KEIYAKU_DATE_FROM >= TO_DATE('" & pNendoFrom1 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "                  AND KEIYAKU_DATE_FROM <= TO_DATE('" & pNendoTo1 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "         THEN TUMITATE_KIN " & vbCrLf
            wSQL += "         ELSE 0 END) AS SIN_TUMITATE_KIN1 " & vbCrLf
            wSQL += "   ,SUM(CASE WHEN KEIYAKU_DATE_FROM >= TO_DATE('" & pNendoFrom2 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "                  AND KEIYAKU_DATE_FROM <= TO_DATE('" & pNendoTo2 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "         THEN TUMITATE_KIN " & vbCrLf
            wSQL += "         ELSE 0 END) AS SIN_TUMITATE_KIN2 " & vbCrLf
            wSQL += "   ,SUM(CASE WHEN KEIYAKU_DATE_FROM >= TO_DATE('" & pNendoFrom3 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "                  AND KEIYAKU_DATE_FROM <= TO_DATE('" & pNendoTo3 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "         THEN TUMITATE_KIN " & vbCrLf
            wSQL += "         ELSE 0 END) AS SIN_TUMITATE_KIN3 " & vbCrLf
            wSQL += "  FROM " & vbCrLf
            wSQL += "   ( " & vbCrLf
            wSQL += "    SELECT " & vbCrLf
            wSQL += "      KEIYAKU_DATE_FROM " & vbCrLf
            '2022/11/09 JBD9020 契約変更区分が5（譲渡の企→家）の場合も引く UPD START
            'wSQL += "     ,DECODE(KEIYAKU_HENKO_KBN, 0, TUMITATE_KIN, 3, -1*SAGAKU_TUMITATE_KIN, SAGAKU_TUMITATE_KIN) AS TUMITATE_KIN " & vbCrLf
            wSQL += "     ,DECODE(KEIYAKU_HENKO_KBN, 0, TUMITATE_KIN, 3, -1*SAGAKU_TUMITATE_KIN, 5, -1*SAGAKU_TUMITATE_KIN, SAGAKU_TUMITATE_KIN) AS TUMITATE_KIN " & vbCrLf
            '2022/11/09 JBD9020 UPD END
            wSQL += "    FROM " & vbCrLf
            wSQL += "      TT_TUMITATE T " & vbCrLf
            wSQL += "    WHERE " & vbCrLf
            '期
            wSQL += "        T.KI = " & numKI.Value & vbCrLf
            wSQL += "    AND T.SEIKYU_HENKAN_KBN <> 4 " & vbCrLf
            '契約日From
            wSQL += "    AND T.KEIYAKU_DATE_FROM BETWEEN TO_DATE('" & pTaisyoNendoF & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "                                AND TO_DATE('" & pTaisyoNendoT & "','YYYY/MM/DD') " & vbCrLf

            '初年度4/1が契約日のデータは除外する
            wSQL += "    AND NOT EXISTS " & vbCrLf
            wSQL += "     ( " & vbCrLf
            wSQL += "      SELECT " & vbCrLf
            wSQL += "        T2.KI " & vbCrLf
            wSQL += "       ,T2.SEIKYU_KAISU " & vbCrLf
            wSQL += "       ,T2.KEIYAKUSYA_CD " & vbCrLf
            wSQL += "       ,T2.TUMITATE_KBN " & vbCrLf
            wSQL += "      FROM " & vbCrLf
            wSQL += "        TT_TUMITATE T2 " & vbCrLf
            wSQL += "      WHERE " & vbCrLf
            '契約日From
            wSQL += "          T2.KEIYAKU_DATE_FROM = TO_DATE('" & pTaisyoNendoF & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "      AND T2.KEIYAKU_HENKO_KBN = 0 " & vbCrLf
            '期
            wSQL += "      AND T2.KI = " & numKI.Value & vbCrLf
            wSQL += "      AND T2.SEIKYU_HENKAN_KBN <> 4 " & vbCrLf
            wSQL += "      AND T.KI = T2.KI " & vbCrLf
            wSQL += "      AND T.SEIKYU_KAISU = T2.SEIKYU_KAISU " & vbCrLf
            wSQL += "      AND T.KEIYAKUSYA_CD = T2.KEIYAKUSYA_CD " & vbCrLf
            wSQL += "      AND T.TUMITATE_KBN = T2.TUMITATE_KBN " & vbCrLf
            wSQL += "     ) " & vbCrLf
            wSQL += "   )  " & vbCrLf
            wSQL += " ) T " & vbCrLf
            wSQL += " , " & vbCrLf

            '対象羽数抽出
            wSQL += " ( " & vbCrLf
            wSQL += "  SELECT " & vbCrLf
            wSQL += "    SUM(CASE WHEN T.KEIYAKU_DATE_FROM >= TO_DATE('" & pNendoFrom1 & "','YYYY/MM/DD') "
            wSQL += "             AND T.KEIYAKU_DATE_FROM <= TO_DATE('" & pNendoTo1 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "         THEN M.HASU " & vbCrLf
            wSQL += "         ELSE 0 END) AS SIN_HASU1 " & vbCrLf
            wSQL += "   ,SUM(CASE WHEN T.KEIYAKU_DATE_FROM >= TO_DATE('" & pNendoFrom2 & "','YYYY/MM/DD') "
            wSQL += "             AND T.KEIYAKU_DATE_FROM <= TO_DATE('" & pNendoTo2 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "         THEN M.HASU " & vbCrLf
            wSQL += "         ELSE 0 END) AS SIN_HASU2 " & vbCrLf
            wSQL += "   ,SUM(CASE WHEN T.KEIYAKU_DATE_FROM >= TO_DATE('" & pNendoFrom3 & "','YYYY/MM/DD') "
            wSQL += "             AND T.KEIYAKU_DATE_FROM <= TO_DATE('" & pNendoTo3 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "         THEN M.HASU " & vbCrLf
            wSQL += "         ELSE 0 END) AS SIN_HASU3 " & vbCrLf
            wSQL += "  FROM " & vbCrLf
            wSQL += "    TT_TUMITATE T " & vbCrLf
            wSQL += "   ,TT_TUMITATE_MEISAI M " & vbCrLf
            wSQL += "  WHERE " & vbCrLf
            wSQL += "      T.KI = M.KI " & vbCrLf
            wSQL += "  AND T.SEIKYU_KAISU = M.SEIKYU_KAISU " & vbCrLf
            wSQL += "  AND T.KEIYAKUSYA_CD = M.KEIYAKUSYA_CD " & vbCrLf
            wSQL += "  AND T.TUMITATE_KBN = M.TUMITATE_KBN " & vbCrLf
            '期
            wSQL += "  AND T.KI = " & numKI.Value & vbCrLf
            wSQL += "  AND T.SEIKYU_HENKAN_KBN <> 4 " & vbCrLf
            '2022/11/09 JBD9020 羽数が増えるのは新規か増羽だけのはず、減ることはない ADD START
            'wSQL += "  AND (T.KEIYAKU_HENKO_KBN = 0 OR T.KEIYAKU_HENKO_KBN = 1) " & vbCrLf
            '2022/11/09 JBD9020 ADD END
            '契約日From
            wSQL += "  AND T.KEIYAKU_DATE_FROM BETWEEN TO_DATE('" & pTaisyoNendoF & "','YYYY/MM/DD') "
            wSQL += "                          AND TO_DATE('" & pTaisyoNendoT & "','YYYY/MM/DD') " & vbCrLf

            '初年度4/1が契約日のデータは除外する
            wSQL += "  AND NOT EXISTS " & vbCrLf
            wSQL += "   ( " & vbCrLf
            wSQL += "    SELECT " & vbCrLf
            wSQL += "      T2.KI " & vbCrLf
            wSQL += "     ,T2.SEIKYU_KAISU " & vbCrLf
            wSQL += "     ,T2.KEIYAKUSYA_CD " & vbCrLf
            wSQL += "     ,T2.TUMITATE_KBN " & vbCrLf
            wSQL += "    FROM " & vbCrLf
            wSQL += "      TT_TUMITATE T2 " & vbCrLf
            wSQL += "    WHERE " & vbCrLf
            '契約日From
            wSQL += "        T2.KEIYAKU_DATE_FROM = TO_DATE('" & pTaisyoNendoF & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "    AND T2.KEIYAKU_HENKO_KBN = 0 " & vbCrLf
            '期
            wSQL += "    AND T2.KI = " & numKI.Value & vbCrLf
            wSQL += "    AND T2.SEIKYU_HENKAN_KBN <> 4 " & vbCrLf
            wSQL += "    AND T.KI = T2.KI " & vbCrLf
            wSQL += "    AND T.SEIKYU_KAISU = T2.SEIKYU_KAISU " & vbCrLf
            wSQL += "    AND T.KEIYAKUSYA_CD = T2.KEIYAKUSYA_CD " & vbCrLf
            wSQL += "    AND T.TUMITATE_KBN = T2.TUMITATE_KBN " & vbCrLf
            wSQL += "   ) " & vbCrLf
            wSQL += " ) M " & vbCrLf

            If Not f_Select_ODP(wkDs, wSQL) Then
                Exit Try
            End If

            If wkDs.Tables(0).Rows.Count > 0 Then

                '新規加入者等 対象羽数1
                wkDSRep.Tables(0).Rows(0).Item("SIN_HASU1") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SIN_HASU1"))
                '新規加入者等 対象羽数2
                wkDSRep.Tables(0).Rows(0).Item("SIN_HASU2") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SIN_HASU2"))
                '新規加入者等 対象羽数3
                wkDSRep.Tables(0).Rows(0).Item("SIN_HASU3") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SIN_HASU3"))
                '新規加入者等 積立金額1
                wkDSRep.Tables(0).Rows(0).Item("SIN_TUMITATE_KIN1") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SIN_TUMITATE_KIN1"))
                '新規加入者等 積立金額2
                wkDSRep.Tables(0).Rows(0).Item("SIN_TUMITATE_KIN2") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SIN_TUMITATE_KIN2"))
                '新規加入者等 積立金額3
                wkDSRep.Tables(0).Rows(0).Item("SIN_TUMITATE_KIN3") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SIN_TUMITATE_KIN3"))

            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_make_SQL_Kofu 互助金交付金データＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_make_SQL_Kofu
    '説明            : 互助金交付金データＳＱＬ作成
    '引数            :区分
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    ''' <summary>
    ''' ＳＱＬ文作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_make_SQL_Kofu(ByRef wkDSRep As DataSet) As Boolean
        Dim ret As Boolean = False
        Dim wSQL As String = String.Empty
        Dim wkDs As DataSet = New DataSet

        Try
            wSQL = ""
            wSQL += "SELECT " & vbCrLf
            '経営支援互助金交付額 対象羽数1
            wSQL += "  SUM(CASE WHEN K.KEISAN_DATE >= TO_DATE('" & pNendoFrom1 & "','YYYY/MM/DD') "
            wSQL += "            AND K.KEISAN_DATE <= TO_DATE('" & pNendoTo1 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "       THEN NVL(K.KEIEI_HASU,0) " & vbCrLf
            wSQL += "       ELSE 0 END) AS KEIEI_HASU1 " & vbCrLf
            '経営支援互助金交付額 対象羽数2
            wSQL += " ,SUM(CASE WHEN K.KEISAN_DATE >= TO_DATE('" & pNendoFrom2 & "','YYYY/MM/DD') "
            wSQL += "            AND K.KEISAN_DATE <= TO_DATE('" & pNendoTo2 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "       THEN NVL(K.KEIEI_HASU,0) " & vbCrLf
            wSQL += "       ELSE 0 END) AS KEIEI_HASU2 " & vbCrLf
            '経営支援互助金交付額 対象羽数3
            wSQL += " ,SUM(CASE WHEN K.KEISAN_DATE >= TO_DATE('" & pNendoFrom3 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "       THEN NVL(K.KEIEI_HASU,0) " & vbCrLf
            wSQL += "       ELSE 0 END) KEIEI_HASU3 " & vbCrLf
            '経営支援互助金交付額 積立金額1
            wSQL += " ,SUM(CASE WHEN K.KEISAN_DATE >= TO_DATE('" & pNendoFrom1 & "','YYYY/MM/DD') "
            wSQL += "            AND K.KEISAN_DATE <= TO_DATE('" & pNendoTo1 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "       THEN NVL(K.KEIEI_SEI_TUMITATE_KIN,0) " & vbCrLf
            wSQL += "       ELSE 0 END) AS KEIEI_KOFU_KIN1 " & vbCrLf
            '経営支援互助金交付額 積立金額2
            wSQL += " ,SUM(CASE WHEN K.KEISAN_DATE >= TO_DATE('" & pNendoFrom2 & "','YYYY/MM/DD') "
            wSQL += "            AND K.KEISAN_DATE <= TO_DATE('" & pNendoTo2 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "       THEN NVL(K.KEIEI_SEI_TUMITATE_KIN,0) " & vbCrLf
            wSQL += "       ELSE 0 END) AS KEIEI_KOFU_KIN2 " & vbCrLf
            '経営支援互助金交付額 積立金額3
            wSQL += " ,SUM(CASE WHEN K.KEISAN_DATE >= TO_DATE('" & pNendoFrom3 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "       THEN NVL(K.KEIEI_SEI_TUMITATE_KIN,0) " & vbCrLf
            wSQL += "       ELSE 0 END) KEIEI_KOFU_KIN3 " & vbCrLf
            '焼却・埋却交付額 対象羽数1
            wSQL += " ,SUM(CASE WHEN K.KEISAN_DATE >= TO_DATE('" & pNendoFrom1 & "','YYYY/MM/DD') "
            wSQL += "            AND K.KEISAN_DATE <= TO_DATE('" & pNendoTo1 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "       THEN NVL(K.SYOKYAKU_HASU,0) " & vbCrLf
            wSQL += "       ELSE 0 END) AS SYOKYAKU_HASU1 " & vbCrLf
            '焼却・埋却交付額 対象羽数2
            wSQL += " ,SUM(CASE WHEN K.KEISAN_DATE >= TO_DATE('" & pNendoFrom2 & "','YYYY/MM/DD') "
            wSQL += "            AND K.KEISAN_DATE <= TO_DATE('" & pNendoTo2 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "       THEN NVL(K.SYOKYAKU_HASU,0) " & vbCrLf
            wSQL += "       ELSE 0 END) AS SYOKYAKU_HASU2 " & vbCrLf
            '焼却・埋却交付額 対象羽数3
            wSQL += " ,SUM(CASE WHEN K.KEISAN_DATE >= TO_DATE('" & pNendoFrom3 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "       THEN NVL(K.SYOKYAKU_HASU,0) " & vbCrLf
            wSQL += "       ELSE 0 END) AS SYOKYAKU_HASU3 " & vbCrLf
            '焼却・埋却交付額 積立金額1
            wSQL += " ,SUM(CASE WHEN K.KEISAN_DATE >= TO_DATE('" & pNendoFrom1 & "','YYYY/MM/DD') "
            wSQL += "            AND K.KEISAN_DATE <= TO_DATE('" & pNendoTo1 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "       THEN NVL(K.MAIKYAKU_SEI_TUMITATE_KIN,0) " & vbCrLf
            wSQL += "       ELSE 0 END) AS SYOKYAKU_KOFU_KIN1 " & vbCrLf
            '焼却・埋却交付額 積立金額2
            wSQL += " ,SUM(CASE WHEN K.KEISAN_DATE >= TO_DATE('" & pNendoFrom2 & "','YYYY/MM/DD') "
            wSQL += "            AND K.KEISAN_DATE <= TO_DATE('" & pNendoTo2 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "       THEN NVL(K.MAIKYAKU_SEI_TUMITATE_KIN,0) " & vbCrLf
            wSQL += "       ELSE 0 END) AS SYOKYAKU_KOFU_KIN2 " & vbCrLf
            '焼却・埋却交付額 積立金額3
            wSQL += " ,SUM(CASE WHEN K.KEISAN_DATE >= TO_DATE('" & pNendoFrom3 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "       THEN NVL(K.MAIKYAKU_SEI_TUMITATE_KIN,0) " & vbCrLf
            wSQL += "       ELSE 0 END) AS SYOKYAKU_KOFU_KIN3 " & vbCrLf

            'From
            wSQL += "FROM " & vbCrLf
            wSQL += "  TT_KOFU K " & vbCrLf
            wSQL += "WHERE " & vbCrLf
            '期
            wSQL += "    K.KI = " & numKI.Value & vbCrLf
            '計算処理日
            wSQL += "AND K.KEISAN_DATE >= TO_DATE('" & pTaisyoNendoF & "','YYYY/MM/DD') " & vbCrLf

            If Not f_Select_ODP(wkDs, wSQL) Then
                Exit Try
            End If

            If wkDs.Tables(0).Rows.Count > 0 Then

                '経営支援互助金交付額 対象羽数1～3
                wkDSRep.Tables(0).Rows(0).Item("KEIEI_HASU1") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("KEIEI_HASU1"))
                wkDSRep.Tables(0).Rows(0).Item("KEIEI_HASU2") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("KEIEI_HASU2"))
                wkDSRep.Tables(0).Rows(0).Item("KEIEI_HASU3") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("KEIEI_HASU3"))
                '経営支援互助金交付額 積立金額1～3
                wkDSRep.Tables(0).Rows(0).Item("KEIEI_KOFU_KIN1") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("KEIEI_KOFU_KIN1"))
                wkDSRep.Tables(0).Rows(0).Item("KEIEI_KOFU_KIN2") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("KEIEI_KOFU_KIN2"))
                wkDSRep.Tables(0).Rows(0).Item("KEIEI_KOFU_KIN3") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("KEIEI_KOFU_KIN3"))
                '焼却・埋却交付額 対象羽数1～3
                wkDSRep.Tables(0).Rows(0).Item("SYOKYAKU_HASU1") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SYOKYAKU_HASU1"))
                wkDSRep.Tables(0).Rows(0).Item("SYOKYAKU_HASU2") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SYOKYAKU_HASU2"))
                wkDSRep.Tables(0).Rows(0).Item("SYOKYAKU_HASU3") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SYOKYAKU_HASU3"))
                '焼却・埋却交付額 積立金額1～3
                wkDSRep.Tables(0).Rows(0).Item("SYOKYAKU_KOFU_KIN1") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SYOKYAKU_KOFU_KIN1"))
                wkDSRep.Tables(0).Rows(0).Item("SYOKYAKU_KOFU_KIN2") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SYOKYAKU_KOFU_KIN2"))
                wkDSRep.Tables(0).Rows(0).Item("SYOKYAKU_KOFU_KIN3") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SYOKYAKU_KOFU_KIN3"))

            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_make_SQL_NyukinNofu 入金ベース納付額データＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_make_SQL_NyukinNofu
    '説明            :入金ベース納付額データＳＱＬ作成
    '引数            :Dataset
    '戻り値          :正常終了:True 異常終了:False
    '------------------------------------------------------------------
    Private Function f_make_SQL_NyukinNofu(ByRef wkDSRep As DataSet) As Boolean
        Dim ret As Boolean = False
        Dim wSQL As String = String.Empty

        Try

            wSQL = ""
            wSQL += "SELECT " & vbCrLf
            '作成日
            wSQL += "  TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', " & vbCrLf
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI " & vbCrLf
            '集約区分（ヘッダー）
            wSQL += " , '入金ベース' AS OUTPUT_KBN" & vbCrLf
            '対象期・年度（ヘッダー）
            wSQL += " , '対象期・年度：第" & numKI.Value & "期（' || TO_CHAR(TO_DATE('" & pTaisyoNendoF & "'), 'EEYY""年度""',"
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '　～　' || "
            wSQL += "    TO_CHAR(TO_DATE('" & DateTime.Parse(pTaisyoNendoT).AddYears(-1).ToString("yyyy/MM/dd") & "'), 'EEYY""年度""',"
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '）' AS H_TAISYO_KI " & vbCrLf

            '契約開始日
            Dim culture As Globalization.CultureInfo = New Globalization.CultureInfo("ja-JP")
            Dim sWareki As String = String.Empty
            culture.DateTimeFormat.Calendar = New System.Globalization.JapaneseCalendar
            '和暦に変換（ggは元号を現す）
            sWareki = DateTime.Parse(pTaisyoNendoF).ToString("ggyy年度M月d日", culture)

            wSQL += " , '（" & sWareki & "契約）' AS KEIYAKU_DATE " & vbCrLf
            '第1年度
            wSQL += " , TO_CHAR(TO_DATE('" & pNendoFrom1 & "'),'EEYY""年度""',"
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NENDO1 " & vbCrLf
            '第2年度
            wSQL += " , TO_CHAR(TO_DATE('" & pNendoFrom2 & "'),'EEYY""年度""',"
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NENDO2 " & vbCrLf
            '第3年度
            wSQL += " , TO_CHAR(TO_DATE('" & pNendoFrom3 & "'),'EEYY""年度""',"
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NENDO3 " & vbCrLf

            '互助基金納付額 対象羽数
            wSQL += " ,M.HASU " & vbCrLf
            '互助基金納付額 積立金額
            'wSQL += " ,T.TUMITATE_KIN " & vbCrLf           '2017/07/27　修正
            wSQL += " ,NVL(T.TUMITATE_KIN,0) TUMITATE_KIN"  '2017/07/27　修正

            '以下は以降のSQL抽出結果を格納するための項目設定
            wSQL += " ,NULL AS SIN_HASU1 " & vbCrLf
            wSQL += " ,NULL AS SIN_HASU2 " & vbCrLf
            wSQL += " ,NULL AS SIN_HASU3 " & vbCrLf
            wSQL += " ,NULL AS SIN_TUMITATE_KIN1 " & vbCrLf
            wSQL += " ,NULL AS SIN_TUMITATE_KIN2 " & vbCrLf
            wSQL += " ,NULL AS SIN_TUMITATE_KIN3 " & vbCrLf
            wSQL += " ,NULL AS KEIEI_HASU1 " & vbCrLf
            wSQL += " ,NULL AS KEIEI_HASU2 " & vbCrLf
            wSQL += " ,NULL AS KEIEI_HASU3 " & vbCrLf
            wSQL += " ,NULL AS KEIEI_KOFU_KIN1 " & vbCrLf
            wSQL += " ,NULL AS KEIEI_KOFU_KIN2 " & vbCrLf
            wSQL += " ,NULL AS KEIEI_KOFU_KIN3 " & vbCrLf
            wSQL += " ,NULL AS SYOKYAKU_HASU1 " & vbCrLf
            wSQL += " ,NULL AS SYOKYAKU_HASU2 " & vbCrLf
            wSQL += " ,NULL AS SYOKYAKU_HASU3 " & vbCrLf
            wSQL += " ,NULL AS SYOKYAKU_KOFU_KIN1 " & vbCrLf
            wSQL += " ,NULL AS SYOKYAKU_KOFU_KIN2 " & vbCrLf
            wSQL += " ,NULL AS SYOKYAKU_KOFU_KIN3 " & vbCrLf

            '↓2022/02/03 JBD439 ADD  R03年度対応　 データ件数を追加
            wSQL += " ,NULL AS KOFU_RITU " & vbCrLf
            '↑2022/02/03 JBD439 ADD  R03年度対応

            'From
            wSQL += "FROM " & vbCrLf
            wSQL += " ( " & vbCrLf
            wSQL += "  SELECT " & vbCrLf
            '            未入金のとき、入金積立金はNULLのはず。
            '            但し、入金入力で入金取消しを実行すると、入金積立金にゼロがセットされる。
            '            よって、入金なしの判定は、0とNULLと両方必要となる。
            '            入金入力の入金取消を、入金積立金にNULLに修正したら、ゼロの判定を削除する。
            'wSQL += "    SUM(CASE WHEN T.NYUKIN_TUMITATE = 0 THEN 0 " & vbCrLf '2017/07/27　修正
            wSQL += "     SUM(CASE WHEN T.NYUKIN_TUMITATE IS NULL THEN 0 "      '2017/07/27　修正
            '2022/11/09 JBD9020 相殺で差額が手数料分しかなくて積立分がない場合を追加 UPD START
            wSQL += "              WHEN T.NYUKIN_TUMITATE =  0 AND SYORI_JOKYO_KBN = 3  THEN T.TUMITATE_KIN"
            '2022/11/09 JBD9020 UPD END
            wSQL += "              WHEN T.NYUKIN_TUMITATE =  0    THEN 0 "      '2017/07/27　修正
            wSQL += "              ELSE T.NYUKIN_TUMITATE+(T.TUMITATE_KIN - T.SAGAKU_TUMITATE_KIN) END) AS TUMITATE_KIN " & vbCrLf
            wSQL += "  FROM " & vbCrLf
            wSQL += "    TT_TUMITATE T " & vbCrLf
            wSQL += "  WHERE " & vbCrLf
            wSQL += "      T.KEIYAKU_DATE_FROM = TO_DATE('" & pTaisyoNendoF & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "  AND T.KEIYAKU_HENKO_KBN = 0 " & vbCrLf
            wSQL += "  AND T.KI = " & numKI.Value & vbCrLf
            wSQL += "  AND T.SEIKYU_HENKAN_KBN <> 4 " & vbCrLf
            wSQL += " ) T, " & vbCrLf
            wSQL += " ( " & vbCrLf
            wSQL += "  SELECT " & vbCrLf
            wSQL += "    SUM(M.HASU) AS HASU " & vbCrLf
            wSQL += "  FROM " & vbCrLf
            wSQL += "    TT_TUMITATE T " & vbCrLf
            wSQL += "   ,TT_TUMITATE_MEISAI M " & vbCrLf
            wSQL += "  WHERE " & vbCrLf
            wSQL += "      T.KI = M.KI " & vbCrLf
            wSQL += "  AND T.SEIKYU_KAISU = M.SEIKYU_KAISU " & vbCrLf
            wSQL += "  AND T.KEIYAKUSYA_CD = M.KEIYAKUSYA_CD " & vbCrLf
            wSQL += "  AND T.TUMITATE_KBN = M.TUMITATE_KBN " & vbCrLf
            wSQL += "  AND T.KEIYAKU_DATE_FROM = TO_DATE('" & pTaisyoNendoF & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "  AND T.KEIYAKU_HENKO_KBN = 0 " & vbCrLf
            wSQL += "  AND T.KI = " & numKI.Value & vbCrLf
            wSQL += "  AND T.SEIKYU_HENKAN_KBN <> 4 " & vbCrLf
            wSQL += " ) M " & vbCrLf

            If Not f_Select_ODP(wkDSRep, wSQL) Then
                Exit Try
            End If

            'データ存在チェック
            If WordHenkan("N", "S", wkDSRep.Tables(0).Rows(0).Item("HASU")) = "" Then
                Exit Try
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_make_SQL_NyukinSinki 入金ベース新規等データＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_make_SQL_NyukinSinki
    '説明            :入金ベース新規等データＳＱＬ作成
    '引数            :Dataset
    '戻り値          :正常終了:True 異常終了:False
    '------------------------------------------------------------------
    Private Function f_make_SQL_NyukinSinki(ByRef wkDSRep As DataSet) As Boolean
        Dim ret As Boolean = False
        Dim wSQL As String = String.Empty
        Dim wkDs As DataSet = New DataSet

        Try
            wSQL = ""
            wSQL += "SELECT " & vbCrLf
            '2017/07/27　修正開始
            '新規加入者 対象羽数1
            'wSQL += "   M.SIN_HASU1 " & vbCrLf
            wSQL += "   NVL(M.SIN_HASU1,0) SIN_HASU1"
            '新規加入者 積立金額1
            'wSQL += " , T.SIN_TUMITATE_KIN1 " & vbCrLf
            wSQL += " , NVL(T.SIN_TUMITATE_KIN1,0) SIN_TUMITATE_KIN1"
            '新規加入者 対象羽数2
            'wSQL += " , M.SIN_HASU2 " & vbCrLf
            wSQL += " , NVL(M.SIN_HASU2,0) SIN_HASU2"
            '新規加入者 積立金額2
            'wSQL += " , T.SIN_TUMITATE_KIN2 " & vbCrLf
            wSQL += " , NVL(T.SIN_TUMITATE_KIN2,0) SIN_TUMITATE_KIN2"
            '新規加入者 対象羽数3
            'wSQL += " , M.SIN_HASU3 " & vbCrLf
            wSQL += " , NVL(M.SIN_HASU3,0) SIN_HASU3"
            '新規加入者 積立金額3
            'wSQL += " , T.SIN_TUMITATE_KIN3 " & vbCrLf
            wSQL += " , NVL(T.SIN_TUMITATE_KIN3,0)SIN_TUMITATE_KIN3 "
            '2017/07/27　修正終了

            'FROM
            wSQL += "FROM " & vbCrLf
            '積立金抽出
            wSQL += " ( " & vbCrLf
            wSQL += "  SELECT " & vbCrLf
            wSQL += "    SUM(CASE WHEN KEIYAKU_DATE_FROM >= TO_DATE('" & pNendoFrom1 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "                  AND KEIYAKU_DATE_FROM <= TO_DATE('" & pNendoTo1 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "         THEN TUMITATE_KIN " & vbCrLf
            wSQL += "         ELSE 0 END) AS SIN_TUMITATE_KIN1 " & vbCrLf
            wSQL += "   ,SUM(CASE WHEN KEIYAKU_DATE_FROM >= TO_DATE('" & pNendoFrom2 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "                  AND KEIYAKU_DATE_FROM <= TO_DATE('" & pNendoTo2 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "         THEN TUMITATE_KIN " & vbCrLf
            wSQL += "         ELSE 0 END) AS SIN_TUMITATE_KIN2 " & vbCrLf
            wSQL += "   ,SUM(CASE WHEN KEIYAKU_DATE_FROM >= TO_DATE('" & pNendoFrom3 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "                  AND KEIYAKU_DATE_FROM <= TO_DATE('" & pNendoTo3 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "         THEN TUMITATE_KIN " & vbCrLf
            wSQL += "         ELSE 0 END) AS SIN_TUMITATE_KIN3 " & vbCrLf

            wSQL += "  FROM " & vbCrLf
            wSQL += "   ( " & vbCrLf
            wSQL += "    SELECT " & vbCrLf
            wSQL += "      T.KEIYAKU_DATE_FROM " & vbCrLf
            wSQL += "     ,CASE WHEN T.KEIYAKU_HENKO_KBN = 0 THEN " & vbCrLf
            '            未入金の場合、入金積立金はNULLのはず。
            '            但し、入金入力で入金取消しを実行すると、入金積立金にゼロがセットされる。
            '            よって、入金なしの判定は、0とNULLと両方必要となる。
            '            入金入力の入金取消を、入金積立金にNULLに修正したら、ゼロの判定を削除する。
            'wSQL += "           CASE WHEN T.NYUKIN_TUMITATE = 0 THEN 0 " & vbCrLf'2017/07/27　修正
            wSQL += "           CASE WHEN T.NYUKIN_TUMITATE IS NULL THEN 0"         '2017/07/27　修正
            '2022/11/09 JBD9020 相殺で差額が手数料分しかなくて積立分がない場合を追加 ADD START
            wSQL += "                WHEN T.NYUKIN_TUMITATE =  0 AND SYORI_JOKYO_KBN = 3  THEN T.TUMITATE_KIN"
            '2022/11/09 JBD9020 ADD END
            wSQL += "                WHEN T.NYUKIN_TUMITATE =  0    THEN 0"         '2017/07/27　修正
            wSQL += "                ELSE T.NYUKIN_TUMITATE+(T.TUMITATE_KIN - T.SAGAKU_TUMITATE_KIN) END " & vbCrLf
            '2022/11/09 JBD9020 返還の場合は引く UPD START
            'wSQL += "           ELSE T.NYUKIN_TUMITATE END AS TUMITATE_KIN " & vbCrLf
            wSQL += "           ELSE DECODE(KEIYAKU_HENKO_KBN, 3, -1*NYUKIN_TUMITATE, 5, -1*NYUKIN_TUMITATE, NYUKIN_TUMITATE) END AS TUMITATE_KIN " & vbCrLf
            '2022/11/09 JBD9020 UPD END
            wSQL += "    FROM " & vbCrLf
            wSQL += "      TT_TUMITATE T " & vbCrLf
            wSQL += "    WHERE " & vbCrLf
            '対象期
            wSQL += "        T.KI = " & numKI.Value & vbCrLf
            wSQL += "    AND T.SEIKYU_HENKAN_KBN <> 4 " & vbCrLf
            '契約日From
            wSQL += "    AND T.KEIYAKU_DATE_FROM BETWEEN TO_DATE('" & pTaisyoNendoF & "','YYYY/MM/DD') "
            wSQL += "                          AND TO_DATE('" & pTaisyoNendoT & "','YYYY/MM/DD') " & vbCrLf

            '初年度4/1が契約日のデータは除外する
            wSQL += "    AND NOT EXISTS " & vbCrLf
            wSQL += "     ( " & vbCrLf
            wSQL += "      SELECT " & vbCrLf
            wSQL += "        T2.KI " & vbCrLf
            wSQL += "       ,T2.SEIKYU_KAISU " & vbCrLf
            wSQL += "       ,T2.KEIYAKUSYA_CD " & vbCrLf
            wSQL += "       ,T2.TUMITATE_KBN " & vbCrLf
            wSQL += "      FROM " & vbCrLf
            wSQL += "        TT_TUMITATE T2 " & vbCrLf
            wSQL += "      WHERE " & vbCrLf
            '契約日From
            wSQL += "          T2.KEIYAKU_DATE_FROM = TO_DATE('" & pTaisyoNendoF & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "      AND T2.KEIYAKU_HENKO_KBN = 0 " & vbCrLf
            '対象期
            wSQL += "      AND T2.KI =" & numKI.Value & vbCrLf
            wSQL += "      AND T2.SEIKYU_HENKAN_KBN <> 4 " & vbCrLf
            wSQL += "      AND T.KI = T2.KI " & vbCrLf
            wSQL += "      AND T.SEIKYU_KAISU = T2.SEIKYU_KAISU " & vbCrLf
            wSQL += "      AND T.KEIYAKUSYA_CD = T2.KEIYAKUSYA_CD " & vbCrLf
            wSQL += "      AND T.TUMITATE_KBN = T2.TUMITATE_KBN " & vbCrLf
            wSQL += "     ) " & vbCrLf
            wSQL += "   )  " & vbCrLf
            wSQL += " ) T " & vbCrLf
            wSQL += " , " & vbCrLf

            '羽数抽出
            wSQL += " ( " & vbCrLf
            wSQL += "  SELECT " & vbCrLf
            wSQL += "    SUM(CASE WHEN T.KEIYAKU_DATE_FROM >= TO_DATE('" & pNendoFrom1 & "','YYYY/MM/DD') "
            wSQL += "             AND T.KEIYAKU_DATE_FROM <= TO_DATE('" & pNendoTo1 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "         THEN M.HASU " & vbCrLf
            wSQL += "         ELSE 0 END) AS SIN_HASU1 " & vbCrLf
            wSQL += "   ,SUM(CASE WHEN T.KEIYAKU_DATE_FROM >= TO_DATE('" & pNendoFrom2 & "','YYYY/MM/DD') "
            wSQL += "             AND T.KEIYAKU_DATE_FROM <= TO_DATE('" & pNendoTo2 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "         THEN M.HASU " & vbCrLf
            wSQL += "         ELSE 0 END) AS SIN_HASU2 " & vbCrLf
            wSQL += "   ,SUM(CASE WHEN T.KEIYAKU_DATE_FROM >= TO_DATE('" & pNendoFrom3 & "','YYYY/MM/DD') "
            wSQL += "             AND T.KEIYAKU_DATE_FROM <= TO_DATE('" & pNendoTo3 & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "         THEN M.HASU " & vbCrLf
            wSQL += "         ELSE 0 END) AS SIN_HASU3 " & vbCrLf
            wSQL += "  FROM " & vbCrLf
            wSQL += "    TT_TUMITATE T " & vbCrLf
            wSQL += "   ,TT_TUMITATE_MEISAI M " & vbCrLf
            wSQL += "  WHERE " & vbCrLf
            wSQL += "      T.KI = M.KI " & vbCrLf
            wSQL += "  AND T.SEIKYU_KAISU = M.SEIKYU_KAISU " & vbCrLf
            wSQL += "  AND T.KEIYAKUSYA_CD = M.KEIYAKUSYA_CD " & vbCrLf
            wSQL += "  AND T.TUMITATE_KBN = M.TUMITATE_KBN " & vbCrLf
            '対象期
            wSQL += "  AND T.KI = " & numKI.Value & vbCrLf
            wSQL += "  AND T.SEIKYU_HENKAN_KBN <> 4 " & vbCrLf
            '2022/11/09 JBD9020 羽数が増えるのは新規か増羽だけのはず、減ることはない ADD START
            'wSQL += "  AND (T.KEIYAKU_HENKO_KBN = 0 OR T.KEIYAKU_HENKO_KBN = 1) " & vbCrLf
            '2022/11/09 JBD9020 ADD END
            '契約日From
            wSQL += "  AND T.KEIYAKU_DATE_FROM BETWEEN TO_DATE('" & pTaisyoNendoF & "','YYYY/MM/DD') "
            wSQL += "                          AND TO_DATE('" & pTaisyoNendoT & "','YYYY/MM/DD') " & vbCrLf

            '初年度4/1が契約日のデータは除外する
            wSQL += "  AND NOT EXISTS " & vbCrLf
            wSQL += "   ( " & vbCrLf
            wSQL += "    SELECT " & vbCrLf
            wSQL += "      T2.KI " & vbCrLf
            wSQL += "     ,T2.SEIKYU_KAISU " & vbCrLf
            wSQL += "     ,T2.KEIYAKUSYA_CD " & vbCrLf
            wSQL += "     ,T2.TUMITATE_KBN " & vbCrLf
            wSQL += "    FROM " & vbCrLf
            wSQL += "      TT_TUMITATE T2 " & vbCrLf
            wSQL += "    WHERE " & vbCrLf
            '契約日From
            wSQL += "        T2.KEIYAKU_DATE_FROM = TO_DATE('" & pTaisyoNendoF & "','YYYY/MM/DD') " & vbCrLf
            wSQL += "    AND T2.KEIYAKU_HENKO_KBN = 0 " & vbCrLf
            '対象期
            wSQL += "    AND T2.KI = " & numKI.Value & vbCrLf
            wSQL += "    AND T2.SEIKYU_HENKAN_KBN <> 4 " & vbCrLf
            wSQL += "    AND T.KI = T2.KI " & vbCrLf
            wSQL += "    AND T.SEIKYU_KAISU = T2.SEIKYU_KAISU " & vbCrLf
            wSQL += "    AND T.KEIYAKUSYA_CD = T2.KEIYAKUSYA_CD " & vbCrLf
            wSQL += "    AND T.TUMITATE_KBN = T2.TUMITATE_KBN " & vbCrLf
            wSQL += "   ) " & vbCrLf
            wSQL += " ) M " & vbCrLf

            If Not f_Select_ODP(wkDs, wSQL) Then
                Exit Try
            End If

            '帳票用のDatasetに値を格納
            If wkDs.Tables(0).Rows.Count > 0 Then

                '新規加入者 対象羽数1
                wkDSRep.Tables(0).Rows(0).Item("SIN_HASU1") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SIN_HASU1"))
                '新規加入者 対象羽数2
                wkDSRep.Tables(0).Rows(0).Item("SIN_HASU2") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SIN_HASU2"))
                '新規加入者 対象羽数3
                wkDSRep.Tables(0).Rows(0).Item("SIN_HASU3") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SIN_HASU3"))
                '新規加入者 積立金1
                wkDSRep.Tables(0).Rows(0).Item("SIN_TUMITATE_KIN1") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SIN_TUMITATE_KIN1"))
                '新規加入者 積立金2
                wkDSRep.Tables(0).Rows(0).Item("SIN_TUMITATE_KIN2") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SIN_TUMITATE_KIN2"))
                '新規加入者 積立金3
                wkDSRep.Tables(0).Rows(0).Item("SIN_TUMITATE_KIN3") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0).Item("SIN_TUMITATE_KIN3"))

            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_make_SQL_Kofu_Sinsei 互助金交付率データＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_make_SQL_Kofu_Sinsei
    '説明            : 互助金交付率データＳＱＬ作成
    '引数            :区分
    '戻り値          :String(SQL文)  2022/02/02 JBD439 ADD  R03年度対応　交付率を追加
    '------------------------------------------------------------------
    ''' <summary>
    ''' ＳＱＬ文作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_make_SQL_Kofu_Sinsei(ByRef wkDSRep As DataSet) As Boolean
        Dim ret As Boolean = False
        Dim wSQL As String = String.Empty
        Dim wkDs As DataSet = New DataSet

        Try
            wSQL = ""
            wSQL += "SELECT " & vbCrLf
            wSQL += "LTRIM(RTRIM(RTRIM(TO_CHAR((SR.KOFU_RITU),990.999999),0),'.')) || '%'  AS KOFU_RITU " & vbCrLf
            'From
            wSQL += "FROM " & vbCrLf
            wSQL += "  TT_KOFU_SINSEI SR " & vbCrLf
            wSQL += " ,TT_KOFU K " & vbCrLf
            wSQL += " WHERE " & vbCrLf
            '互助金交付
            wSQL &= "     SR.KI = K.KI(+)" & vbCrLf
            wSQL &= " AND SR.HASSEI_KAISU = K.HASSEI_KAISU(+)" & vbCrLf
            wSQL &= " AND SR.KEIYAKUSYA_CD = K.KEIYAKUSYA_CD(+)" & vbCrLf
            '期
            wSQL += " AND SR.KI = " & numKI.Value & vbCrLf
            '計算処理日
            wSQL += " AND K.KEISAN_DATE >= TO_DATE('" & pTaisyoNendoF & "','YYYY/MM/DD') " & vbCrLf
            If pNendoTo3 <> pTaisyoNendoT Then
                wSQL += " AND K.KEISAN_DATE <= TO_DATE('" & pTaisyoNendoT & "','YYYY/MM/DD') " & vbCrLf
            End If
            wSQL += " GROUP BY SR.KOFU_RITU " & vbCrLf

            If Not f_Select_ODP(wkDs, wSQL) Then
                Exit Try
            End If

            '帳票用のDatasetに値を格納
            '互助金交付率が2つ以上存在する場合、非表示
            If wkDs.Tables(0).Rows.Count = 1 Then
                '互助金交付率が1つの場合、表示する
                wkDSRep.Tables(0).Rows(0)("KOFU_RITU") = WordHenkan("N", "Z", wkDs.Tables(0).Rows(0)("KOFU_RITU"))
            End If
            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#End Region

#Region "***ローカル関数***"
#Region "f_ObjectClear 画面クリア処理"
    ''' <summary>
    ''' 画面クリア
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_ObjectClear(ByVal wKbn As String) As Boolean

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '画面初期化
            pJump = True
            Call f_ClearFormALL(Me, wKbn)

            '画面内容をセット
            If Not f_SetForm_Data() Then
                Exit Try
            End If

            '画面変更フラグ
            pblnTextChange = False
            pJump = False

            '先頭入力へ
            rdoSeikyu.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Function
#End Region

#Region "f_SetForm_Data データ画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_Data
    '説明            :データ画面セット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_Data() As Boolean
        Dim sSql As New StringBuilder
        Dim dstDataSet As New DataSet
        Dim ret As Boolean = False

        Try
            pObjTM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

            '初期値
            numKI.Value = pObjTM_SYORI_NENDO_KI.pKI
            dateTaisyoYear.Value = DateTime.Parse(pObjTM_SYORI_NENDO_KI.pJIGYO_SYURYO_NENDO.ToString & "/04/01")
            rdoSeikyu.Checked = True

            ret = True
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try
        Return ret
    End Function

#End Region

#Region "f_Input_Check 画面入力チェック処理"
    ''' <summary>
    ''' 画面入力チェック処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Input_Check() As Boolean
        Dim ret As Boolean = False
        Dim wkControlName As String

        Try

            '==必須チェック==================
            wkControlName = "期"
            If numKI.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKI.Focus() : Exit Try
            End If
            wkControlName = "事業対象年度"
            If dateTaisyoYear.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : dateTaisyoYear.Focus() : Exit Try
            End If

            '==いろいろチェック==================
            '事業対象年度チェック
            '対象年度（自）算出
            pTaisyoNendoF = ((numKI.Value - 6) * 3) + 2015
            '対象年度（至）算出
            pTaisyoNendoT = pTaisyoNendoF + 2
            '画面.事業対象年度
            Dim sTaisyoNendo As String = String.Empty
            sTaisyoNendo = Format(dateTaisyoYear.Value, "yyyy/MM/dd").Substring(0, 4)

            If sTaisyoNendo >= pTaisyoNendoF And sTaisyoNendo <= pTaisyoNendoT Then
                '範囲内の場合はエラーなし
            Else
                '範囲外の場合はエラー
                Call Show_MessageBox_Add("W019", "入力した事業対象年度に誤りがあります。") : dateTaisyoYear.SelectAll() : dateTaisyoYear.Focus() : Exit Try
            End If

            '処理年度期の設定
            pSyori = sTaisyoNendo - pTaisyoNendoF + 1

            '事業対象年度日付の設定
            pTaisyoNendoF = pTaisyoNendoF & "/04/01"
            pTaisyoNendoT = DateTime.Parse(sTaisyoNendo & "/03/31").AddYears(1).ToString("yyyy/MM/dd")

            '対象年度1～3を設定
            pNendoFrom1 = pTaisyoNendoF
            pNendoTo1 = DateTime.Parse(pNendoFrom1).AddYears(1).ToString.Substring(0, 4) & "/03/31"
            pNendoFrom2 = DateTime.Parse(pTaisyoNendoF).AddYears(1).ToString("yyyy/MM/dd")
            pNendoTo2 = DateTime.Parse(pNendoFrom2).AddYears(1).ToString.Substring(0, 4) & "/03/31"
            pNendoFrom3 = DateTime.Parse(pTaisyoNendoF).AddYears(2).ToString("yyyy/MM/dd")
            pNendoTo3 = DateTime.Parse(pNendoFrom3).AddYears(1).ToString.Substring(0, 4) & "/03/31"

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#End Region

#Region "Util"



    ''' <summary>
    ''' bool値を数値に変換。
    ''' </summary>
    ''' <param name="wkBool"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Bool2Num(ByVal wkBool As Boolean) As Integer
        If wkBool Then
            Return 1
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    '''文字列をDateかNothingに変換。
    ''' </summary>
    ''' <param name="wkDateStr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Str2DateOrNothing(ByVal wkDateStr As String) As Date
        Dim wkdate As New Date
        If Date.TryParse(wkDateStr, wkdate) Then
            Return wkdate
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 強制数字変換
    ''' </summary>
    ''' <param name="wkString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_toInt(ByVal wkString As String) As Integer
        Select Case True
            Case wkString Is Nothing, IsDBNull(wkString), Not (IsNumeric(wkString))
                Return 0
            Case Else
                Return CInt(wkString)
        End Select

    End Function

    ''' <summary>
    ''' 数字以外を削除
    ''' </summary>
    ''' <param name="wkStr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_NumFilter(ByVal wkStr As String) As String
        Return (New System.Text.RegularExpressions.Regex("\D")).Replace(wkStr, "")
    End Function

#End Region


End Class
