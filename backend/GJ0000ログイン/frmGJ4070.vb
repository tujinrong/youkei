'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ4070.vb
'*
'*　　②　機能概要　　　　　互助金交付集計表
'*
'*　　③　作成日　　　　　　2015/03/18 JBD368
'*
'*　　④　更新日            2022/02/03 JBD437 R03年度減額対応
'*
'*******************************************************************************
Option Strict Off
Option Explicit On
Imports GrapeCity.ActiveReports
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


Public Class frmGJ4070

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
    Private Const con_ReportName As String = "互助金交付集計表"

    '処理対象期・年度マスタ
    Private pObjTM_SYORI_NENDO_KI As Obj_TM_SYORI_NENDO_KI

    Private pTUMITATE As String = String.Empty
    Private OutputKbn As Integer

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
            ret = f_ObjectClear("")
            '期にフォーカスセット
            numKI.Focus()
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
#Region "発生回数"
    '------------------------------------------------------------------
    'プロシージャ名  :numHasseiKaisuFrom_Validating
    '説明            :発生回数FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numHasseiKaisuFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numHasseiKaisuFrom.Validating

        Call s_From_Validating(numHasseiKaisuFrom, numHasseiKaisuTo)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :numHasseiKaisuTo_Validating
    '説明            :発生回数TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numHasseiKaisuTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numHasseiKaisuTo.Validating

        Call s_To_Validating(numHasseiKaisuTo, numHasseiKaisuFrom)

    End Sub
#End Region

#Region "s_FormControls_TextChanged 画面コントロールTextChangeイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :s_FormControls_TextChanged
    '説明            :画面コントロールTextChangeイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub s_FormControls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

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
        Dim wkDSRep As DataSet

        Try
            ''--------------------------------------------------
            ''データ存在チェック
            ''--------------------------------------------------
            wkDSRep = New DataSet
            If Not f_make_SQL_DataCheck(wkSql) Then
                Exit Try
            End If
            If Not f_Select_ODP(wkDSRep, wkSql) Then
                Exit Try
            End If
            If wkDSRep.Tables(0).Rows.Count > 0 Then
                If wkDSRep.Tables(0).Rows(0).Item(0) = 0 Then
                    'エラーリスト出力なし
                    Show_MessageBox("I002", "") '該当データが存在しません。
                    Return False
                End If
            End If
            ''--------------------------------------------------
            ''データ取得
            ''--------------------------------------------------
            wkDSRep = New DataSet
            wkDSRep.Tables.Add(con_ReportName)
            'SQL
            wkSql = ""
            If Not f_make_SQL(wkSql) Then
                Exit Try
            End If

            Debug.Print(wkSql)

            'データ取得
            Using wkAdp As New OracleDataAdapter(wkSql, Cnn)
                wkAdp.Fill(wkDSRep, wkDSRep.Tables(0).TableName)
            End Using

            If wkDSRep.Tables(0).Rows.Count > 0 Then

                'Using wkAR As New rptGJ4070

                '    '出力区分を設定
                If chkTori.Checked And chkUzura.Checked And chkOutput.Checked = False Then
                    '固定レイアウトの場合(すべての鶏でかつ発生しない鶏の種類も印字する)
                    OutputKbn = 0
                Else
                    'すべての鶏、また発生しない鶏は印字しない場合
                    OutputKbn = 1
                End If
                Dim w As New rptGJ4070
                w.sub1(wkDSRep, OutputKbn)

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
                Show_MessageBox("I002", "") '該当データが存在しません。
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

#Region "f_make_SQL 帳票データ出力用ＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_make_SQL
    '説明            :帳票データ出力用ＳＱＬ作成
    '引数            :区分
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    ''' <summary>
    ''' ＳＱＬ文作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_make_SQL(ByRef wSQL As String) As Boolean
        Dim ret As Boolean = False

        Try

            wSQL = ""
            wSQL += "SELECT " & vbCrLf
            '作成日
            wSQL += "   TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', " & vbCrLf
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI " & vbCrLf
            '対象期・回数（ヘッダー）
            wSQL += " , ('対象期・回　： 第" & numKI.Value.ToString _
                        & "期　第" & numHasseiKaisuFrom.Value.ToString & "回 ～ " _
                        & "第" & numHasseiKaisuTo.Value.ToString & "回') AS H_TAISYO_KI " & vbCrLf
            '↓2022/02/04 JBD437 ADD R03年度減額対応
            '互助金交付率
            wSQL += "  , '" & f_KOFU_RITU() & "%' AS KOFU_RITU " & vbCrLf
            '↑2022/02/04 JBD437 ADD R03年度減額対応

            'データ区分(明細、合計判定用)
            wSQL += "  , D.KBN " & vbCrLf
            '★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            'wSQL += "  , DECODE(D.KBN, 1, KS.KEIYAKU_KBN, 9) AS KEIYAKU_KBN " & vbCrLf
            wSQL += "  , DECODE(D.KBN, 1, KS.KEIYAKU_KBN, 99) AS KEIYAKU_KBN " & vbCrLf
            '★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            wSQL += "  , DECODE(D.KBN, 1, KS.KEIYAKU_KBN_NM, '合計') AS KEIYAKU_KBN_NM " & vbCrLf
            wSQL += "  , KS.TORI_KBN " & vbCrLf
            wSQL += "  , KS.TORI_KBN_NM " & vbCrLf
            wSQL += "  , SUM(KS.NINZU1) AS NINZU1 " & vbCrLf
            wSQL += "  , SUM(KS.KOFU_HASU1) AS KOFU_HASU1 " & vbCrLf
            wSQL += "  , SUM(KS.SEI_TUMITATE_KIN1) AS SEI_TUMITATE_KIN1 " & vbCrLf
            wSQL += "  , SUM(KS.KUNI_KOFU_KIN1) AS KUNI_KOFU_KIN1 " & vbCrLf
            wSQL += "  , SUM(KS.KOFU_KIN1) AS KOFU_KIN1 " & vbCrLf
            wSQL += "  , SUM(KS.NINZU2) AS NINZU2 " & vbCrLf
            wSQL += "  , SUM(KS.KOFU_HASU2) AS KOFU_HASU2 " & vbCrLf
            wSQL += "  , SUM(KS.SEI_TUMITATE_KIN2) AS SEI_TUMITATE_KIN2 " & vbCrLf
            wSQL += "  , SUM(KS.KUNI_KOFU_KIN2) AS KUNI_KOFU_KIN2 " & vbCrLf
            wSQL += "  , SUM(KS.KOFU_KIN2) AS KOFU_KIN2 " & vbCrLf
            wSQL += "  , SUM(KS.NINZU_G) AS NINZU_G " & vbCrLf
            wSQL += "  , SUM(KS.KOFU_HASU_G) AS KOFU_HASU_G " & vbCrLf
            wSQL += "  , SUM(KS.SEI_TUMITATE_KIN_G) AS SEI_TUMITATE_KIN_G " & vbCrLf
            wSQL += "  , SUM(KS.KUNI_KOFU_KIN_G) AS KUNI_KOFU_KIN_G " & vbCrLf
            wSQL += "  , SUM(KS.KOFU_KIN_G) AS KOFU_KIN_G  " & vbCrLf
            wSQL += "FROM " & vbCrLf
            wSQL += "  (  " & vbCrLf
            wSQL += "    SELECT 1 AS KBN FROM DUAL  " & vbCrLf
            wSQL += "    UNION ALL  " & vbCrLf
            wSQL += "    SELECT 2 AS KBN FROM DUAL  " & vbCrLf
            wSQL += "  ) D " & vbCrLf
            wSQL += "  , (  " & vbCrLf
            wSQL += "    SELECT " & vbCrLf
            wSQL += "      C.KEIYAKU_KBN " & vbCrLf
            wSQL += "      , C.KEIYAKU_KBN_NM " & vbCrLf
            wSQL += "      , C.TORI_KBN " & vbCrLf
            wSQL += "      , C.TORI_KBN_NM " & vbCrLf
            wSQL += "      , SUM(DECODE(KS.GOJOKIN_SYURUI_KBN, 1, KS.NINZU, 0)) AS NINZU1 " & vbCrLf
            wSQL += "      , SUM(DECODE(KS.GOJOKIN_SYURUI_KBN, 1, KS.KOFU_HASU, 0)) AS KOFU_HASU1 " & vbCrLf
            wSQL += "      , SUM(DECODE(KS.GOJOKIN_SYURUI_KBN, 1, KS.SEI_TUMITATE_KIN, 0)) AS SEI_TUMITATE_KIN1 " & vbCrLf
            wSQL += "      , SUM(DECODE(KS.GOJOKIN_SYURUI_KBN, 1, KS.KUNI_KOFU_KIN, 0)) AS KUNI_KOFU_KIN1 " & vbCrLf
            wSQL += "      , SUM(DECODE(KS.GOJOKIN_SYURUI_KBN, 1, KS.KOFU_KIN, 0)) AS KOFU_KIN1 " & vbCrLf
            wSQL += "      , SUM(DECODE(KS.GOJOKIN_SYURUI_KBN, 2, KS.NINZU, 0)) AS NINZU2 " & vbCrLf
            wSQL += "      , SUM(DECODE(KS.GOJOKIN_SYURUI_KBN, 2, KS.KOFU_HASU, 0)) AS KOFU_HASU2 " & vbCrLf
            wSQL += "      , SUM(DECODE(KS.GOJOKIN_SYURUI_KBN, 2, KS.SEI_TUMITATE_KIN, 0)) AS SEI_TUMITATE_KIN2 " & vbCrLf
            wSQL += "      , SUM(DECODE(KS.GOJOKIN_SYURUI_KBN, 2, KS.KUNI_KOFU_KIN, 0)) AS KUNI_KOFU_KIN2 " & vbCrLf
            wSQL += "      , SUM(DECODE(KS.GOJOKIN_SYURUI_KBN, 2, KS.KOFU_KIN, 0)) AS KOFU_KIN2 " & vbCrLf
            wSQL += "      , 0 AS NINZU_G " & vbCrLf
            wSQL += "      , 0 AS KOFU_HASU_G " & vbCrLf
            wSQL += "      , 0 AS SEI_TUMITATE_KIN_G " & vbCrLf
            wSQL += "      , 0 AS KUNI_KOFU_KIN_G " & vbCrLf
            wSQL += "      , 0 AS KOFU_KIN_G  " & vbCrLf
            wSQL += "    FROM " & vbCrLf
            wSQL += "      (  " & vbCrLf
            wSQL += "        SELECT " & vbCrLf
            wSQL += "          M1.MEISYO_CD AS KEIYAKU_KBN " & vbCrLf
            '↓2017/07/13 修正 契約区分
            'wSQL += "          , M1.RYAKUSYO AS KEIYAKU_KBN_NM " & vbCrLf
            wSQL += "          , M1.MEISYO AS KEIYAKU_KBN_NM " & vbCrLf
            '↑2017/07/13 修正 契約区分
            wSQL += "          , M7.MEISYO_CD AS TORI_KBN " & vbCrLf
            wSQL += "          , M7.MEISYO AS TORI_KBN_NM  " & vbCrLf
            wSQL += "        FROM " & vbCrLf
            '↓2017/07/13 修正 契約区分
            'wSQL += "          (SELECT MEISYO_CD, RYAKUSYO FROM TM_CODE WHERE SYURUI_KBN = 1) M1 " & vbCrLf
            wSQL += "          (SELECT MEISYO_CD, MEISYO FROM TM_CODE WHERE SYURUI_KBN = 1) M1 " & vbCrLf
            '↑2017/07/13 修正 契約区分
            wSQL += "        , (SELECT MEISYO_CD, MEISYO FROM TM_CODE WHERE SYURUI_KBN = 7"
            '集計区分
            Dim strOutputKbn As String = String.Empty
            If chkTori.Checked Then
                strOutputKbn = "1,2,3,4,5"
            End If
            If chkUzura.Checked Then
                If strOutputKbn.Length > 0 Then
                    strOutputKbn += ","
                End If
                '↓2017/07/27 修正 鶏の種類を追加
                'strOutputKbn += "6"
                strOutputKbn += "6,7,8,9,10,11"
                '↑2017/07/27 修正
            End If
            wSQL += " AND MEISYO_CD IN (" & strOutputKbn & ")) M7 " & vbCrLf

            wSQL += "      ) C " & vbCrLf
            wSQL += "      , (  " & vbCrLf
            wSQL += "        SELECT " & vbCrLf
            wSQL += "          KS.GOJOKIN_SYURUI_KBN " & vbCrLf
            wSQL += "          , KS.KEIYAKU_KBN " & vbCrLf
            wSQL += "          , KS.TORI_KBN " & vbCrLf
            wSQL += "          , COUNT(DISTINCT KEIYAKUSYA_CD) NINZU " & vbCrLf
            wSQL += "          , SUM(KS.KOFU_HASU) KOFU_HASU " & vbCrLf
            wSQL += "          , SUM(KS.SEI_TUMITATE_KIN) SEI_TUMITATE_KIN " & vbCrLf
            wSQL += "          , SUM(KS.KUNI_KOFU_KIN) KUNI_KOFU_KIN " & vbCrLf
            wSQL += "          , SUM(KS.KOFU_KIN) KOFU_KIN  " & vbCrLf
            wSQL += "        FROM " & vbCrLf
            wSQL += "          TT_KOFU_SINSEI KS  " & vbCrLf
            wSQL += "        WHERE " & vbCrLf
            '期
            wSQL += "              KS.KI = " & numKI.Value.ToString & vbCrLf
            '発生回数
            wSQL += "          AND KS.HASSEI_KAISU BETWEEN " & numHasseiKaisuFrom.Value.ToString _
                            & " AND " & numHasseiKaisuTo.Value.ToString & vbCrLf
            '集計区分
            wSQL += "          AND KS.TORI_KBN IN (" & strOutputKbn & ") " & vbCrLf

            '処理状況
            wSQL += "          AND KS.SYORI_JOKYO_KBN = 4 " & vbCrLf

            wSQL += "        GROUP BY " & vbCrLf
            wSQL += "          KS.GOJOKIN_SYURUI_KBN " & vbCrLf
            wSQL += "          , KS.KEIYAKU_KBN " & vbCrLf
            wSQL += "          , KS.TORI_KBN " & vbCrLf
            wSQL += "      ) KS  " & vbCrLf
            wSQL += "    WHERE " & vbCrLf
            '出力区分
            If chkOutput.Checked Then
                '発生しない鶏の種類は印字しない
                wSQL += "          C.KEIYAKU_KBN = KS.KEIYAKU_KBN " & vbCrLf
                wSQL += "      AND C.TORI_KBN = KS.TORI_KBN " & vbCrLf
            Else
                '発生しない鶏の種類も印字する
                wSQL += "          C.KEIYAKU_KBN = KS.KEIYAKU_KBN(+) " & vbCrLf
                wSQL += "      AND C.TORI_KBN = KS.TORI_KBN(+) " & vbCrLf
            End If
            '契約区分：うずらの場合、その他の鶏、合計は出力しない
            wSQL += "      AND NOT (C.KEIYAKU_KBN = 3 AND C.TORI_KBN BETWEEN 1 AND 5) " & vbCrLf
            If chkUzura.Checked = False Then
                wSQL += "      AND C.KEIYAKU_KBN <> 3 " & vbCrLf
            End If

            wSQL += "    GROUP BY " & vbCrLf
            wSQL += "      C.KEIYAKU_KBN " & vbCrLf
            wSQL += "      , C.KEIYAKU_KBN_NM " & vbCrLf
            wSQL += "      , C.TORI_KBN " & vbCrLf
            wSQL += "      , C.TORI_KBN_NM  " & vbCrLf
            wSQL += "    UNION ALL " & vbCrLf
            wSQL += "    SELECT " & vbCrLf
            wSQL += "       M1.MEISYO_CD AS KEIYAKU_KBN " & vbCrLf
            '↓2017/07/13 修正 契約区分
            'wSQL += "     , M1.RYAKUSYO AS KEIYAKU_KBN_NM " & vbCrLf
            wSQL += "     , M1.MEISYO AS KEIYAKU_KBN_NM " & vbCrLf
            '↑2017/07/13 修正 契約区分
            '★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            'wSQL += "     , NVL(G.TORI_KBN,9) AS TORI_KBN " & vbCrLf
            wSQL += "     , NVL(G.TORI_KBN,99) AS TORI_KBN " & vbCrLf
            '★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            wSQL += "     , '合計' AS TORI_KBN_NM " & vbCrLf
            wSQL += "     , SUM(DECODE(G.GOJOKIN_SYURUI_KBN, 1, G.NINZU, 0)) AS NINZU1 " & vbCrLf
            wSQL += "     , SUM(DECODE(G.GOJOKIN_SYURUI_KBN, 1, G.KOFU_HASU, 0)) AS KOFU_HASU1 " & vbCrLf
            wSQL += "     , SUM(DECODE(G.GOJOKIN_SYURUI_KBN, 1, G.SEI_TUMITATE_KIN, 0)) AS SEI_TUMITATE_KIN1 " & vbCrLf
            wSQL += "     , SUM(DECODE(G.GOJOKIN_SYURUI_KBN, 1, G.KUNI_KOFU_KIN, 0)) AS KUNI_KOFU_KIN1 " & vbCrLf
            wSQL += "     , SUM(DECODE(G.GOJOKIN_SYURUI_KBN, 1, G.KOFU_KIN, 0)) AS KOFU_KIN1 " & vbCrLf
            wSQL += "     , SUM(DECODE(G.GOJOKIN_SYURUI_KBN, 2, G.NINZU, 0)) AS NINZU2 " & vbCrLf
            wSQL += "     , SUM(DECODE(G.GOJOKIN_SYURUI_KBN, 2, G.KOFU_HASU, 0)) AS KOFU_HASU2 " & vbCrLf
            wSQL += "     , SUM(DECODE(G.GOJOKIN_SYURUI_KBN, 2, G.SEI_TUMITATE_KIN, 0)) AS SEI_TUMITATE_KIN2 " & vbCrLf
            wSQL += "     , SUM(DECODE(G.GOJOKIN_SYURUI_KBN, 2, G.KUNI_KOFU_KIN, 0)) AS KUNI_KOFU_KIN2 " & vbCrLf
            wSQL += "     , SUM(DECODE(G.GOJOKIN_SYURUI_KBN, 2, G.KOFU_KIN, 0)) AS KOFU_KIN2 " & vbCrLf
            wSQL += "     , 0 AS NINZU_G " & vbCrLf
            wSQL += "     , 0 AS KOFU_HASU_G " & vbCrLf
            wSQL += "     , 0 AS SEI_TUMITATE_KIN_G " & vbCrLf
            wSQL += "     , 0 AS KUNI_KOFU_KIN_G " & vbCrLf
            wSQL += "     , 0 AS KOFU_KIN_G  " & vbCrLf
            wSQL += "    FROM " & vbCrLf
            '↓2017/07/13 修正 契約区分
            'wSQL += "       (SELECT MEISYO_CD, RYAKUSYO FROM TM_CODE WHERE SYURUI_KBN = 1) M1, " & vbCrLf
            wSQL += "       (SELECT MEISYO_CD, MEISYO FROM TM_CODE WHERE SYURUI_KBN = 1) M1, " & vbCrLf
            '↑2017/07/13 修正 契約区分
            wSQL += "       ( " & vbCrLf
            wSQL += "        SELECT " & vbCrLf
            wSQL += "            KS.GOJOKIN_SYURUI_KBN " & vbCrLf
            wSQL += "          , KS.KEIYAKU_KBN " & vbCrLf
            '★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            'wSQL += "          , 9 AS TORI_KBN " & vbCrLf
            wSQL += "          , 99 AS TORI_KBN " & vbCrLf
            '★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            wSQL += "          , COUNT(DISTINCT KEIYAKUSYA_CD) NINZU " & vbCrLf
            wSQL += "          , SUM(KS.KOFU_HASU) KOFU_HASU " & vbCrLf
            wSQL += "          , SUM(KS.SEI_TUMITATE_KIN) SEI_TUMITATE_KIN " & vbCrLf
            wSQL += "          , SUM(KS.KUNI_KOFU_KIN) KUNI_KOFU_KIN " & vbCrLf
            wSQL += "          , SUM(KS.KOFU_KIN) KOFU_KIN  " & vbCrLf
            wSQL += "        FROM " & vbCrLf
            wSQL += "          TT_KOFU_SINSEI KS " & vbCrLf
            wSQL += "        WHERE " & vbCrLf
            '期
            wSQL += "              KS.KI = " & numKI.Value.ToString & vbCrLf
            '発生回数
            wSQL += "          AND KS.HASSEI_KAISU BETWEEN " & numHasseiKaisuFrom.Value.ToString _
                            & " AND " & numHasseiKaisuTo.Value.ToString & vbCrLf
            '集計区分
            wSQL += "          AND KS.TORI_KBN IN (" & strOutputKbn & ") " & vbCrLf

            '処理状況
            wSQL += "          AND KS.SYORI_JOKYO_KBN = 4 " & vbCrLf

            wSQL += "        GROUP BY " & vbCrLf
            wSQL += "            KS.GOJOKIN_SYURUI_KBN " & vbCrLf
            wSQL += "          , KS.KEIYAKU_KBN " & vbCrLf
            wSQL += "       ) G " & vbCrLf
            wSQL += "    WHERE " & vbCrLf
            wSQL += "       M1.MEISYO_CD = G.KEIYAKU_KBN(+) " & vbCrLf
            wSQL += "    GROUP BY " & vbCrLf
            wSQL += "       M1.MEISYO_CD " & vbCrLf
            '↓2017/07/13 修正 契約区分
            'wSQL += "     , M1.RYAKUSYO " & vbCrLf
            wSQL += "     , M1.MEISYO " & vbCrLf
            '↑2017/07/13 修正 契約区分
            wSQL += "     , G.TORI_KBN " & vbCrLf
            wSQL += "     , '合計' " & vbCrLf

            wSQL += "    UNION ALL " & vbCrLf
            wSQL += "    SELECT " & vbCrLf
            wSQL += "        C.KEIYAKU_KBN " & vbCrLf
            wSQL += "      , C.KEIYAKU_KBN_NM " & vbCrLf
            wSQL += "      , C.TORI_KBN " & vbCrLf
            wSQL += "      , C.TORI_KBN_NM " & vbCrLf
            wSQL += "      , 0 AS NINZU1 " & vbCrLf
            wSQL += "      , 0 AS KOFU_HASU1 " & vbCrLf
            wSQL += "      , 0 AS SEI_TUMITATE_KIN1 " & vbCrLf
            wSQL += "      , 0 AS KUNI_KOFU_KIN1 " & vbCrLf
            wSQL += "      , 0 AS KOFU_KIN1 " & vbCrLf
            wSQL += "      , 0 AS NINZU2 " & vbCrLf
            wSQL += "      , 0 AS KOFU_HASU2 " & vbCrLf
            wSQL += "      , 0 AS SEI_TUMITATE_KIN2 " & vbCrLf
            wSQL += "      , 0 AS KUNI_KOFU_KIN2 " & vbCrLf
            wSQL += "      , 0 AS KOFU_KIN2 " & vbCrLf
            wSQL += "      , SUM(NVL(KS.NINZU, 0)) AS NINZU_G " & vbCrLf
            wSQL += "      , SUM(NVL(KS.KOFU_HASU, 0)) AS KOFU_HASU_G " & vbCrLf
            wSQL += "      , SUM(NVL(KS.SEI_TUMITATE_KIN, 0)) AS SEI_TUMITATE_KIN_G " & vbCrLf
            wSQL += "      , SUM(NVL(KS.KUNI_KOFU_KIN, 0)) AS KUNI_KOFU_KIN_G " & vbCrLf
            wSQL += "      , SUM(NVL(KS.KOFU_KIN, 0)) AS KOFU_KIN_G  " & vbCrLf
            wSQL += "    FROM " & vbCrLf
            wSQL += "      (  " & vbCrLf
            wSQL += "        SELECT " & vbCrLf
            wSQL += "          M1.MEISYO_CD AS KEIYAKU_KBN " & vbCrLf
            '↓2017/07/13 修正 契約区分
            'wSQL += "          , M1.RYAKUSYO AS KEIYAKU_KBN_NM " & vbCrLf
            wSQL += "          , M1.MEISYO AS KEIYAKU_KBN_NM " & vbCrLf
            '↑2017/07/13 修正 契約区分
            wSQL += "          , M7.MEISYO_CD AS TORI_KBN " & vbCrLf
            wSQL += "          , M7.MEISYO AS TORI_KBN_NM  " & vbCrLf
            wSQL += "        FROM " & vbCrLf
            '↓2017/07/13 修正 契約区分
            'wSQL += "          (SELECT MEISYO_CD, RYAKUSYO FROM TM_CODE WHERE SYURUI_KBN = 1) M1 " & vbCrLf
            wSQL += "          (SELECT MEISYO_CD, MEISYO FROM TM_CODE WHERE SYURUI_KBN = 1) M1 " & vbCrLf
            '↑2017/07/13 修正 契約区分
            wSQL += "        , (SELECT MEISYO_CD, MEISYO FROM TM_CODE WHERE SYURUI_KBN = 7  "
            wSQL += " AND MEISYO_CD IN (" & strOutputKbn & ")) M7 " & vbCrLf
            wSQL += "      ) C " & vbCrLf
            wSQL += "      , (  " & vbCrLf
            wSQL += "        SELECT " & vbCrLf
            wSQL += "            KS.KEIYAKU_KBN " & vbCrLf
            wSQL += "          , KS.TORI_KBN " & vbCrLf
            wSQL += "          , COUNT(DISTINCT KEIYAKUSYA_CD) NINZU " & vbCrLf
            wSQL += "          , SUM(KS.KOFU_HASU) KOFU_HASU " & vbCrLf
            wSQL += "          , SUM(KS.SEI_TUMITATE_KIN) SEI_TUMITATE_KIN " & vbCrLf
            wSQL += "          , SUM(KS.KUNI_KOFU_KIN) KUNI_KOFU_KIN " & vbCrLf
            wSQL += "          , SUM(KS.KOFU_KIN) KOFU_KIN  " & vbCrLf
            wSQL += "        FROM " & vbCrLf
            wSQL += "          TT_KOFU_SINSEI KS  " & vbCrLf
            wSQL += "        WHERE " & vbCrLf
            '期
            wSQL += "              KS.KI = " & numKI.Value.ToString & vbCrLf
            '発生回数
            wSQL += "          AND KS.HASSEI_KAISU BETWEEN " & numHasseiKaisuFrom.Value.ToString _
                            & " AND " & numHasseiKaisuTo.Value.ToString & vbCrLf
            '集計区分
            wSQL += "          AND KS.TORI_KBN IN (" & strOutputKbn & ") " & vbCrLf

            '処理状況
            wSQL += "          AND KS.SYORI_JOKYO_KBN = 4 " & vbCrLf
            wSQL += "        GROUP BY " & vbCrLf
            wSQL += "            KS.KEIYAKU_KBN " & vbCrLf
            wSQL += "          , KS.TORI_KBN " & vbCrLf
            wSQL += "      ) KS  " & vbCrLf
            wSQL += "    WHERE " & vbCrLf

            '出力区分
            If chkOutput.Checked Then
                '発生しない鶏の種類は印字しない
                wSQL += "          C.KEIYAKU_KBN = KS.KEIYAKU_KBN " & vbCrLf
                wSQL += "      AND C.TORI_KBN = KS.TORI_KBN " & vbCrLf
            Else
                '発生しない鶏の種類も印字する
                wSQL += "          C.KEIYAKU_KBN = KS.KEIYAKU_KBN(+) " & vbCrLf
                wSQL += "      AND C.TORI_KBN = KS.TORI_KBN(+) " & vbCrLf
            End If
            '契約区分：うずらの場合、その他の鶏、合計は出力しない
            wSQL += "      AND NOT (C.KEIYAKU_KBN = 3 AND C.TORI_KBN BETWEEN 1 AND 5) " & vbCrLf
            If chkUzura.Checked = False Then
                wSQL += "      AND C.KEIYAKU_KBN <> 3 " & vbCrLf
            End If

            wSQL += "    GROUP BY " & vbCrLf
            wSQL += "      C.KEIYAKU_KBN " & vbCrLf
            wSQL += "      , C.KEIYAKU_KBN_NM " & vbCrLf
            wSQL += "      , C.TORI_KBN " & vbCrLf
            wSQL += "      , C.TORI_KBN_NM  " & vbCrLf
            wSQL += "    UNION ALL  " & vbCrLf
            wSQL += "    SELECT " & vbCrLf
            wSQL += "        M1.MEISYO_CD AS KEIYAKU_KBN " & vbCrLf
            '↓2017/07/13 修正 契約区分
            'wSQL += "      , M1.RYAKUSYO AS KEIYAKU_KBN_NM " & vbCrLf
            wSQL += "      , M1.MEISYO AS KEIYAKU_KBN_NM " & vbCrLf
            '↑2017/07/13 修正 契約区分
            '★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            'wSQL += "      , NVL(G.TORI_KBN, 9) AS TORI_KBN " & vbCrLf
            wSQL += "      , NVL(G.TORI_KBN, 99) AS TORI_KBN " & vbCrLf
            '★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            wSQL += "      , '合計' AS TORI_KBN_NM " & vbCrLf
            wSQL += "      , 0 AS NINZU1 " & vbCrLf
            wSQL += "      , 0 AS KOFU_HASU1 " & vbCrLf
            wSQL += "      , 0 AS SEI_TUMITATE_KIN1 " & vbCrLf
            wSQL += "      , 0 AS KUNI_KOFU_KIN1 " & vbCrLf
            wSQL += "      , 0 AS KOFU_KIN1 " & vbCrLf
            wSQL += "      , 0 AS NINZU2 " & vbCrLf
            wSQL += "      , 0 AS KOFU_HASU2 " & vbCrLf
            wSQL += "      , 0 AS SEI_TUMITATE_KIN2 " & vbCrLf
            wSQL += "      , 0 AS KUNI_KOFU_KIN2 " & vbCrLf
            wSQL += "      , 0 AS KOFU_KIN2 " & vbCrLf
            wSQL += "      , SUM(NVL(G.NINZU, 0)) AS NINZU_G " & vbCrLf
            wSQL += "      , SUM(NVL(G.KOFU_HASU, 0)) AS KOFU_HASU_G " & vbCrLf
            wSQL += "      , SUM(NVL(G.SEI_TUMITATE_KIN, 0)) AS SEI_TUMITATE_KIN_G " & vbCrLf
            wSQL += "      , SUM(NVL(G.KUNI_KOFU_KIN, 0)) AS KUNI_KOFU_KIN_G " & vbCrLf
            wSQL += "      , SUM(NVL(G.KOFU_KIN, 0)) AS KOFU_KIN_G  " & vbCrLf
            wSQL += "    FROM " & vbCrLf
            '↓2017/07/13 修正 契約区分
            'wSQL += "        (SELECT MEISYO_CD, RYAKUSYO FROM TM_CODE WHERE SYURUI_KBN = 1) M1 " & vbCrLf
            wSQL += "        (SELECT MEISYO_CD, MEISYO FROM TM_CODE WHERE SYURUI_KBN = 1) M1 " & vbCrLf
            '↑2017/07/13 修正 契約区分
            wSQL += "      , (  " & vbCrLf
            wSQL += "        SELECT " & vbCrLf
            wSQL += "            KS.KEIYAKU_KBN " & vbCrLf
            '★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            'wSQL += "          , 9 AS TORI_KBN " & vbCrLf
            wSQL += "          , 99 AS TORI_KBN " & vbCrLf
            '★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            wSQL += "          , COUNT(DISTINCT KEIYAKUSYA_CD) NINZU " & vbCrLf
            wSQL += "          , SUM(KS.KOFU_HASU) KOFU_HASU " & vbCrLf
            wSQL += "          , SUM(KS.SEI_TUMITATE_KIN) SEI_TUMITATE_KIN " & vbCrLf
            wSQL += "          , SUM(KS.KUNI_KOFU_KIN) KUNI_KOFU_KIN " & vbCrLf
            wSQL += "          , SUM(KS.KOFU_KIN) KOFU_KIN  " & vbCrLf
            wSQL += "        FROM " & vbCrLf
            wSQL += "          TT_KOFU_SINSEI KS  " & vbCrLf
            wSQL += "        WHERE " & vbCrLf
            '期
            wSQL += "              KS.KI = " & numKI.Value.ToString & vbCrLf
            '発生回数
            wSQL += "          AND KS.HASSEI_KAISU BETWEEN " & numHasseiKaisuFrom.Value.ToString _
                            & " AND " & numHasseiKaisuTo.Value.ToString & vbCrLf
            '集計区分
            wSQL += "          AND KS.TORI_KBN IN (" & strOutputKbn & ") " & vbCrLf

            '処理状況
            wSQL += "          AND KS.SYORI_JOKYO_KBN = 4 " & vbCrLf

            wSQL += "        GROUP BY " & vbCrLf
            wSQL += "            KS.KEIYAKU_KBN " & vbCrLf
            wSQL += "      ) G  " & vbCrLf
            wSQL += "    WHERE " & vbCrLf
            wSQL += "      M1.MEISYO_CD = G.KEIYAKU_KBN(+)  " & vbCrLf
            wSQL += "    GROUP BY " & vbCrLf
            wSQL += "      M1.MEISYO_CD " & vbCrLf
            '↓2017/07/13 修正 契約区分
            'wSQL += "      , M1.RYAKUSYO " & vbCrLf
            wSQL += "      , M1.MEISYO " & vbCrLf
            '↑2017/07/13 修正 契約区分
            wSQL += "      , G.TORI_KBN " & vbCrLf
            wSQL += "      , '合計' " & vbCrLf

            wSQL += "  ) KS " & vbCrLf
            wSQL += "GROUP BY " & vbCrLf
            wSQL += "    D.KBN " & vbCrLf
            '★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            'wSQL += "  , DECODE(D.KBN, 1, KS.KEIYAKU_KBN, 9) " & vbCrLf
            wSQL += "  , DECODE(D.KBN, 1, KS.KEIYAKU_KBN, 99) " & vbCrLf
            '★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            wSQL += "  , DECODE(D.KBN, 1, KS.KEIYAKU_KBN_NM, '合計') " & vbCrLf
            wSQL += "  , KS.TORI_KBN " & vbCrLf
            wSQL += "  , KS.TORI_KBN_NM " & vbCrLf
            wSQL += "ORDER BY " & vbCrLf
            '★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            'wSQL += "    DECODE(D.KBN, 1, KS.KEIYAKU_KBN, 9) " & vbCrLf
            wSQL += "    DECODE(D.KBN, 1, KS.KEIYAKU_KBN, 99) " & vbCrLf
            '★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
            wSQL += "  , D.KBN " & vbCrLf
            wSQL += "  , KS.TORI_KBN " & vbCrLf

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_KOFU_RITU 互助金交付率取得 ↓2022/02/04 JBD437 ADD R03年度減額対応"
    '------------------------------------------------------------------
    'プロシージャ名  :f_KOFU_RITU
    '説明            :帳票に出力する互助金交付率の取得
    '引数            :なし
    '戻り値          :String　交付率が1種類の場合は交付率を戻し、複数ある場合は空文字を返す
    '------------------------------------------------------------------
    ''' <summary>
    ''' 互助金交付率を取得する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_KOFU_RITU() As String
        Dim ret As String = ""
        Dim wSQL As String
        Dim wDS As DataSet

        Try

            wSQL = ""
            wSQL += "SELECT " & vbCrLf
            wSQL += " KOFU_RITU " & vbCrLf
            wSQL += "FROM" & vbCrLf
            wSQL += " TT_KOFU_SINSEI " & vbCrLf
            wSQL += "WHERE"
            '期
            wSQL += "      KI = " & numKI.Value.ToString & vbCrLf
            '発生回数
            wSQL += "  AND HASSEI_KAISU BETWEEN " & numHasseiKaisuFrom.Value.ToString _
                            & " AND " & numHasseiKaisuTo.Value.ToString & vbCrLf

            '集計区分
            Dim strOutputKbn As String = String.Empty
            '「鶏以外を除く」にチェック
            If chkTori.Checked Then
                strOutputKbn = "1,2,3,4,5"
            End If
            '「鶏以外」にチェック
            If chkUzura.Checked Then
                If strOutputKbn.Length > 0 Then
                    strOutputKbn += ","
                End If
                strOutputKbn += "6,7,8,9,10,11"
            End If
            wSQL += "  AND TORI_KBN IN (" & strOutputKbn & ") " & vbCrLf

            '処理状況
            wSQL += "  AND SYORI_JOKYO_KBN = 4 " & vbCrLf

            wSQL += "  GROUP BY KOFU_RITU "

            wDS = New DataSet

            'データ存在チェック
            If Not f_Select_ODP(wDS, wSQL) Then
                Exit Try
            End If

            '交付率の件数チェック
            If wDS.Tables(0).Rows.Count > 1 Then
                '交付申請DBの互助金交付率が2つ以上存在する場合、非表示にするために""を戻り値とする
                ret = ""
            Else
                '交付申請DBの互助金交付率が2つ以上存在する場合、互助金交付率を戻り値とする
                ret = wDS.Tables(0).Rows(0)(0).ToString
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
    '↑2022/02/04 JBD437 ADD R03年度減額対応
#End Region


#Region "f_make_SQL_DataCheck 帳票データ存在チェック用ＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_make_SQL_DataCheck
    '説明            :帳票データ存在チェック用ＳＱＬ作成
    '引数            :区分
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    ''' <summary>
    ''' ＳＱＬ文作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_make_SQL_DataCheck(ByRef wSQL As String) As Boolean
        Dim ret As Boolean = False

        Try

            wSQL = ""
            wSQL += "SELECT " & vbCrLf
            wSQL += " COUNT(*) " & vbCrLf
            wSQL += "FROM" & vbCrLf
            wSQL += " TT_KOFU_SINSEI " & vbCrLf
            wSQL += "WHERE"
            '期
            wSQL += "      KI = " & numKI.Value.ToString & vbCrLf
            '発生回数
            wSQL += "  AND HASSEI_KAISU BETWEEN " & numHasseiKaisuFrom.Value.ToString _
                            & " AND " & numHasseiKaisuTo.Value.ToString & vbCrLf
            '集計区分
            Dim strOutputKbn As String = String.Empty
            If chkTori.Checked Then
                strOutputKbn = "1,2,3,4,5"
            End If
            If chkUzura.Checked Then
                If strOutputKbn.Length > 0 Then
                    strOutputKbn += ","
                End If
                '↓2017/07/27 修正 鶏の種類追加
                'strOutputKbn += "6"
                strOutputKbn += "6,7,8,9,10,11"
                '↑2017/07/27 修正 
            End If
            wSQL += "  AND TORI_KBN IN (" & strOutputKbn & ") " & vbCrLf

            '処理状況
            wSQL += "  AND SYORI_JOKYO_KBN = 4 " & vbCrLf

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

            pJump = False

            '画面変更フラグ
            pblnTextChange = False

            '先頭入力へ
            numKI.Focus()

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
            numHasseiKaisuFrom.Value = pObjTM_SYORI_NENDO_KI.pHASSEI_KAISU
            numHasseiKaisuTo.Value = pObjTM_SYORI_NENDO_KI.pHASSEI_KAISU
            chkTori.Checked = True
            chkUzura.Checked = True
            chkOutput.Checked = False

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
            '↓2022/02/03 JBD437 UPD R03年度減額対応
            'wkControlName = "発生回数From"
            wkControlName = "認定回数From"
            '↑2022/02/03 JBD437 UPD R03年度減額対応
            If numHasseiKaisuFrom.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numHasseiKaisuFrom.Focus() : Exit Try
            End If
            '↓2022/02/03 JBD437 UPD R03年度減額対応
            'wkControlName = "発生回数To"
            wkControlName = "発生回数To"
            '↑2022/02/03 JBD437 UPD R03年度減額対応
            If numHasseiKaisuTo.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numHasseiKaisuTo.Focus() : Exit Try
            End If
            wkControlName = "集計区分"
            If chkTori.Checked = False And chkUzura.Checked = False Then
                'すべてチェックOFFの場合エラー
                Call Show_MessageBox_Add("W008", wkControlName) : chkTori.Select() : chkTori.Focus() : Exit Try
            End If

            '==いろいろチェック==================

            '==FromToチェック==================
            '↓2022/02/03 JBD437 UPD R03年度減額対応
            '発生回数
            'If f_Daisyo_Check(numHasseiKaisuFrom, numHasseiKaisuTo, "発生回数", True, 1) = False Then
            '認定回数
            If f_Daisyo_Check(numHasseiKaisuFrom, numHasseiKaisuTo, "認定回数", True, 1) = False Then
                '↑2022/02/03 JBD437 UPD R03年度減額対応
                Return False
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
