'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ4060.vb
'*
'*　　②　機能概要　　　　　金融機関別・支店別振込明細表
'*
'*　　③　作成日　　　　　　2015/03/16 JBD368
'*
'*　　④　更新日            2022/01/27 JBD439 R03年度対応
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


Public Class frmGJ4060

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
    Private Const con_ReportName As String = "金融機関別・支店別振込明細表"

    '処理対象期・年度マスタ
    Private pObjTM_SYORI_NENDO_KI As Obj_TM_SYORI_NENDO_KI

    Private pTUMITATE As String = String.Empty
    Private TITLE As String

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
            rdoSyokai.Focus()
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
#Region "回数関連制御"
    '------------------------------------------------------------------
    'プロシージャ名  :numHasseiKaisuFrom_Validating
    '説明            :認定回数FROM Validatingイベント  '2022/01/31　JBD439 UPD　発生回数を認定回数に変更　R03年度対応
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numHasseiKaisuFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numHasseiKaisuFrom.Validating

        Call s_From_Validating(numHasseiKaisuFrom, numHasseiKaisuTo)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :numHasseiKaisuTo_Validating
    '説明            :認定回数TO Validatingイベント  '2022/01/31　JBD439 UPD　発生回数を認定回数に変更　R03年度対応
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numHasseiKaisuTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numHasseiKaisuTo.Validating

        Call s_To_Validating(numHasseiKaisuTo, numHasseiKaisuFrom)

    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :numKeisanKaisuFrom_Validating
    '説明            :計算回数FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numKeisanKaisuFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numKeisanKaisuFrom.Validating

        Call s_From_Validating(numKeisanKaisuFrom, numKeisanKaisuTo)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :numKeisanKaisuTo_Validating
    '説明            :計算回数TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numKeisanKaisuTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numKeisanKaisuTo.Validating

        Call s_To_Validating(numKeisanKaisuTo, numKeisanKaisuFrom)

    End Sub

#End Region

#Region "s_FormControls_TextChanged 画面コントロールTextChangeイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :s_FormControls_TextChanged
    '説明            :画面コントロールTextChangeイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub s_FormControls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dateFurikomiYmd.TextChanged

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
        Dim wkDSRep As New DataSet

        Try
            ''--------------------------------------------------
            ''データ取得
            ''--------------------------------------------------
            wkDSRep.Tables.Add(con_ReportName)
            'SQL
            If Not f_make_SQL(wkSql) Then
                Exit Try
            End If

            Debug.Print(wkSql)

            'データ取得
            Using wkAdp As New OracleDataAdapter(wkSql, Cnn)
                wkAdp.Fill(wkDSRep, wkDSRep.Tables(0).TableName)
            End Using

            If wkDSRep.Tables(0).Rows.Count > 0 Then
                'Using wkAR As New rptGJ4060

                '    '↓2017/07/14 タイトルに追加納付を追加
                Dim tuika As String = ""
                If pKikin2 Then
                    tuika = "(追加納付)"
                End If
                '    ''ヘッダ用の値を保管
                '    'If chkIchiHen.Checked Or chkHenkan.Checked Then
                '    '    wkAR.TITLE = "<<　" & con_ReportName & "（積立金返還）　>>"
                '    'End If
                '    'If chkGojo.Checked Then
                '    '    wkAR.TITLE = "<<　" & con_ReportName & "（互助金交付）　>>"
                '    'End If
                'ヘッダ用の値を保管
                If chkIchiHen.Checked Or chkHenkan.Checked Then
                    TITLE = "<<　" & con_ReportName & "（積立金返還）" & tuika & "　>>"
                End If
                If chkGojo.Checked Then
                    TITLE = "<<　" & con_ReportName & "（互助金交付）" & tuika & "　>>"
                End If
                Dim w As New rptGJ4060
                w.sub1(wkDSRep, TITLE)
                '    '↑2017/07/14 タイトルに追加納付を追加
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

                '振込予定日の更新
                If chkIchiHen.Checked Or chkHenkan.Checked Then
                    '積立金ＤＢの更新
                    If Not f_UPD_TT_TUMITATE() Then
                        Exit Try
                    End If
                End If
                If chkGojo.Checked Then
                    '交付金ＤＢの更新
                    If Not f_UPD_TT_KOFU() Then
                        Exit Try
                    End If
                End If

            Else
                'エラーリスト出力なし
                Call Show_MessageBox_Add("W020", "指定された条件では振込情報")
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

            '一部返還(積立金) または、全額返還(未継続者)が選択の場合
            If chkIchiHen.Checked Or chkHenkan.Checked Then
                If Not f_make_SQL_Henkan(wSQL) Then
                    Exit Try
                End If
            End If

            '互助金支払いが選択の場合
            If chkGojo.Checked Then
                If Not f_make_SQL_Kofu(wSQL) Then
                    Exit Try
                End If
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_make_SQL_Henkan 積立金返還 帳票データ出力用ＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_make_SQL_Henkan
    '説明            :積立金返還 帳票データ出力用ＳＱＬ作成
    '引数            :区分
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    ''' <summary>
    ''' ＳＱＬ文作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_make_SQL_Henkan(ByRef wSQL As String) As Boolean
        Dim ret As Boolean = False

        Try
            wSQL = ""
            wSQL += "SELECT " & vbCrLf
            '作成日
            wSQL += "   TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', " & vbCrLf
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI " & vbCrLf
            '対象期・回数（ヘッダー）
            wSQL += " , ('対象期 第' || T.KI || '期  計算回数：' || T.SEIKYU_KAISU) AS H_TAISYO_KI " & vbCrLf
            '’発生回数(積立金返還の場合はNULL)
            '認定回数(積立金返還の場合はNULL) '2022/01/31　JBD439 UPD　発生回数を認定回数に変更　R03年度対応
            wSQL += " , NULL AS HASSEI_KAISU " & vbCrLf
            '計算回数
            wSQL += " , T.SEIKYU_KAISU " & vbCrLf
            '振込予定日
            wSQL += " , '（振込予定日：' || TO_CHAR(TO_DATE('" & Format(dateFurikomiYmd.Value, "yyyy/MM/dd") & "'), 'EEYY""年""MM""月""DD""日）""',"
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS FURIKOMIBI " & vbCrLf
            '金融機関コード
            wSQL += " , K.FURI_BANK_CD " & vbCrLf
            '金融機関名
            wSQL += " , B.BANK_NAME " & vbCrLf
            '支店コード
            wSQL += " , K.FURI_BANK_SITEN_CD " & vbCrLf
            '支店名
            wSQL += " , S.SITEN_NAME " & vbCrLf
            '↓2017/07/27 追加 合計出力用に金融機関コード+支店コード
            wSQL += " , K.FURI_BANK_CD || K.FURI_BANK_SITEN_CD AS FURI_BANKANDSITEN_CD" & vbCrLf
            '↑2017/07/27 追加 
            '契約者番号
            wSQL += " , T.KEIYAKUSYA_CD " & vbCrLf
            '契約者名
            wSQL += " , K.KEIYAKUSYA_NAME " & vbCrLf
            '代表者名
            wSQL += " , K.DAIHYO_NAME " & vbCrLf
            '口座種別
            wSQL += " , M4.MEISYO AS FURI_KOZA_SYUBETU " & vbCrLf
            '口座番号
            wSQL += " , K.FURI_KOZA_NO " & vbCrLf
            '口座名義人
            wSQL += " , K.FURI_KOZA_MEIGI " & vbCrLf
            '振込金額
            wSQL += " , T.SAGAKU_SEIKYU_KIN AS FURIKOMI_KIN " & vbCrLf

            'FROM
            wSQL += "FROM " & vbCrLf
            wSQL += " TT_TUMITATE T, " & vbCrLf
            wSQL += " TM_KEIYAKU K, " & vbCrLf
            wSQL += " TM_BANK B, " & vbCrLf
            wSQL += " TM_SITEN S, " & vbCrLf
            '口座種別
            wSQL += " (SELECT MEISYO_CD, MEISYO FROM TM_CODE WHERE SYURUI_KBN = 4) M4 " & vbCrLf

            'WHERE
            wSQL += "WHERE " & vbCrLf
            wSQL += "     T.KI = K.KI(+) " & vbCrLf
            wSQL += " AND T.KEIYAKUSYA_CD = K.KEIYAKUSYA_CD(+) " & vbCrLf
            wSQL += " AND K.FURI_BANK_CD = B.BANK_CD(+) " & vbCrLf
            wSQL += " AND K.FURI_BANK_CD = S.BANK_CD(+) " & vbCrLf
            wSQL += " AND K.FURI_BANK_SITEN_CD = S.SITEN_CD(+) " & vbCrLf
            wSQL += " AND K.FURI_KOZA_SYUBETU = M4.MEISYO_CD(+) " & vbCrLf

            '==必須条件=======================
            '期
            wSQL += " AND T.KI = " & numKI.Value & vbCrLf
            '計算回数
            wSQL += " AND T.SEIKYU_KAISU BETWEEN " & numKeisanKaisuFrom.Value & " AND " & numKeisanKaisuTo.Value & vbCrLf
            '振込予定日
            If rdoSyokai.Checked Then
                '初回発行の場合
                wSQL += " AND T.FURIKOMI_MEISAI_YOTEI_DATE IS NULL " & vbCrLf
            Else
                '修正発行の場合
                wSQL += " AND T.FURIKOMI_MEISAI_YOTEI_DATE IS NOT NULL " & vbCrLf
            End If
            '対象データ
            pTUMITATE = ""
            If chkIchiHen.Checked Then
                pTUMITATE = "3"
            End If
            If chkHenkan.Checked Then
                If pTUMITATE.Length > 0 Then
                    pTUMITATE += ","
                End If
                pTUMITATE += " 4"
            End If
            wSQL += " AND T.SEIKYU_HENKAN_KBN IN (" & pTUMITATE & ") " & vbCrLf
            '【差額】請求(返還)金額計が0以外が対象
            wSQL += " AND T.SAGAKU_SEIKYU_KIN <> 0 " & vbCrLf

            'ORDER BY
            wSQL += "ORDER BY " & vbCrLf
            wSQL += "   T.SEIKYU_KAISU " & vbCrLf
            wSQL += " , K.FURI_BANK_CD " & vbCrLf
            wSQL += " , K.FURI_BANK_SITEN_CD " & vbCrLf
            wSQL += " , T.KEIYAKUSYA_CD " & vbCrLf

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_make_SQL_Kofu 互助金交付 帳票データ出力用ＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_make_SQL_Kofu
    '説明            :互助金交付 帳票データ出力用ＳＱＬ作成
    '引数            :区分
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    ''' <summary>
    ''' ＳＱＬ文作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_make_SQL_Kofu(ByRef wSQL As String) As Boolean
        Dim ret As Boolean = False

        Try
            wSQL = ""
            wSQL += "SELECT " & vbCrLf
            '作成日
            wSQL += "   TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', " & vbCrLf
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI " & vbCrLf
            '対象期・回数（ヘッダー）
            wSQL += " , ('対象期 第' || KO.KI || '期 第' || KO.HASSEI_KAISU || '回  計算回数：' || KO.KEISAN_KAISU) AS H_TAISYO_KI " & vbCrLf
            '’発生回数
            '認定回数  '2022/01/31　JBD439 UPD　発生回数を認定回数に変更　R03年度対応
            wSQL += " , KO.HASSEI_KAISU " & vbCrLf
            '計算回数
            wSQL += " , KO.KEISAN_KAISU AS KEISAN_KAISU " & vbCrLf
            '振込予定日
            wSQL += " , '（振込予定日：' || TO_CHAR(TO_DATE('" & Format(dateFurikomiYmd.Value, "yyyy/MM/dd") & "'), 'EEYY""年""MM""月""DD""日）""',"
            wSQL += "    'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS FURIKOMIBI " & vbCrLf
            '金融機関コード
            wSQL += " , K.FURI_BANK_CD " & vbCrLf
            '金融機関名
            wSQL += " , B.BANK_NAME " & vbCrLf
            '支店コード
            wSQL += " , K.FURI_BANK_SITEN_CD " & vbCrLf
            '支店名
            wSQL += " , S.SITEN_NAME " & vbCrLf
            '↓2017/07/27 追加 合計出力用に金融機関コード+支店コード
            wSQL += " , K.FURI_BANK_CD || K.FURI_BANK_SITEN_CD AS FURI_BANKANDSITEN_CD" & vbCrLf
            '↑2017/07/27 追加 
            '契約者番号
            wSQL += " , KO.KEIYAKUSYA_CD " & vbCrLf
            '契約者名
            wSQL += " , K.KEIYAKUSYA_NAME " & vbCrLf
            '代表者名
            wSQL += " , K.DAIHYO_NAME " & vbCrLf
            '口座種別
            wSQL += " , M4.MEISYO AS FURI_KOZA_SYUBETU " & vbCrLf
            '口座番号
            wSQL += " , K.FURI_KOZA_NO " & vbCrLf
            '口座名義人
            wSQL += " , K.FURI_KOZA_MEIGI " & vbCrLf
            '振込金額
            wSQL += " , KO.KOFU_KIN_KEI AS FURIKOMI_KIN " & vbCrLf

            'FROM
            wSQL += "FROM " & vbCrLf
            wSQL += " TT_KOFU KO, " & vbCrLf
            wSQL += " TM_KEIYAKU K, " & vbCrLf
            wSQL += " TM_BANK B, " & vbCrLf
            wSQL += " TM_SITEN S, " & vbCrLf
            '口座種別
            wSQL += " (SELECT MEISYO_CD, MEISYO FROM TM_CODE WHERE SYURUI_KBN = 4) M4 " & vbCrLf

            'WHERE
            wSQL += "WHERE " & vbCrLf
            wSQL += "     KO.KI = K.KI(+) " & vbCrLf
            wSQL += " AND KO.KEIYAKUSYA_CD = K.KEIYAKUSYA_CD(+) " & vbCrLf
            wSQL += " AND K.FURI_BANK_CD = B.BANK_CD(+) " & vbCrLf
            wSQL += " AND K.FURI_BANK_CD = S.BANK_CD(+) " & vbCrLf
            wSQL += " AND K.FURI_BANK_SITEN_CD = S.SITEN_CD(+) " & vbCrLf
            wSQL += " AND K.FURI_KOZA_SYUBETU = M4.MEISYO_CD(+) " & vbCrLf

            '==必須条件=======================
            '期
            wSQL += " AND KO.KI = " & numKI.Value & vbCrLf
            '’発生回数
            '認定回数  '2022/01/31　JBD439 UPD　発生回数を認定回数に変更　R03年度対応
            wSQL += " AND KO.HASSEI_KAISU BETWEEN " & numHasseiKaisuFrom.Value & " AND " & numHasseiKaisuTo.Value & vbCrLf
            '計算回数
            wSQL += " AND KO.KEISAN_KAISU BETWEEN " & numKeisanKaisuFrom.Value & " AND " & numKeisanKaisuTo.Value & vbCrLf
            '振込予定日
            If rdoSyokai.Checked Then
                '初回発行の場合
                wSQL += " AND KO.FURIKOMI_MEISAI_YOTEI_DATE IS NULL " & vbCrLf
            Else
                '修正発行の場合
                wSQL += " AND KO.FURIKOMI_MEISAI_YOTEI_DATE IS NOT NULL " & vbCrLf
            End If
            '交付額合計が0以外が対象
            wSQL += " AND KO.KOFU_KIN_KEI <> 0 " & vbCrLf

            'ORDER BY
            wSQL += "ORDER BY " & vbCrLf
            wSQL += "   KO.HASSEI_KAISU " & vbCrLf
            wSQL += " , KO.KEISAN_KAISU " & vbCrLf
            wSQL += " , K.FURI_BANK_CD " & vbCrLf
            wSQL += " , K.FURI_BANK_SITEN_CD " & vbCrLf
            wSQL += " , KO.KEIYAKUSYA_CD " & vbCrLf

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_UPD_TT_TUMITATE 積立金ＤＢ 振込予定日更新処理"
    ''' <summary>
    ''' 積立金ＤＢ 振込予定日更新処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_UPD_TT_TUMITATE() As Boolean

        Dim Cmd As New OracleCommand
        Try

            'パラメータ値の設定

            '出力区分
            Dim iOutputKbn As Integer = 0
            '初回発行の場合、OUTPUT_KBNに0を設定
            If rdoSyokai.Checked Then iOutputKbn = 0
            '修正発行の場合、OUTPUT_KBNに1を設定
            If rdoSyusei.Checked Then iOutputKbn = 1

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.CommandText = "PKG_GJ4060.GJ4060_TT_TUMITATE_UPD"
            Cmd.Parameters.Add("IN_OUTPUT_KBN", iOutputKbn)
            Cmd.Parameters.Add("IN_TAISYO_KBN", pTUMITATE)
            Cmd.Parameters.Add("IN_KI", numKI.Value)
            Cmd.Parameters.Add("IN_SEIKYU_KAISU_FROM", numKeisanKaisuFrom.Value)
            Cmd.Parameters.Add("IN_SEIKYU_KAISU_TO", numKeisanKaisuTo.Value)
            Cmd.Parameters.Add("IN_FURIKOMI_MEISAI_YOTEI_DATE", Format(dateFurikomiYmd.Value, "yyyy/MM/dd"))
            Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)


            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Throw New Exception(Cmd.Parameters("OU_MSGCD").Value.ToString() & ":" & Cmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
            Return False
        End Try

        Return True
    End Function
#End Region

#Region "f_UPD_TT_KOFU 交付金ＤＢ 振込予定日更新処理"
    ''' <summary>
    ''' 交付金ＤＢ 振込予定日更新処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_UPD_TT_KOFU() As Boolean

        Dim Cmd As New OracleCommand
        Try

            'パラメータ値の設定

            '出力区分
            Dim iOutputKbn As Integer = 0
            '初回発行の場合、OUTPUT_KBNに0を設定
            If rdoSyokai.Checked Then iOutputKbn = 0
            '修正発行の場合、OUTPUT_KBNに1を設定
            If rdoSyusei.Checked Then iOutputKbn = 1

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.CommandText = "PKG_GJ4060.GJ4060_TT_KOFU_UPD"
            Cmd.Parameters.Add("IN_OUTPUT_KBN", iOutputKbn)
            Cmd.Parameters.Add("IN_KI", numKI.Value)
            Cmd.Parameters.Add("IN_HASSEI_KAISU_FROM", numHasseiKaisuFrom.Value)
            Cmd.Parameters.Add("IN_HASSEI_KAISU_TO", numHasseiKaisuTo.Value)
            Cmd.Parameters.Add("IN_KEISAN_KAISU_FROM", numKeisanKaisuFrom.Value)
            Cmd.Parameters.Add("IN_KEISAN_KAISU_TO", numKeisanKaisuTo.Value)
            Cmd.Parameters.Add("IN_FURIKOMI_MEISAI_YOTEI_DATE", Format(dateFurikomiYmd.Value, "yyyy/MM/dd"))
            Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)


            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Throw New Exception(Cmd.Parameters("OU_MSGCD").Value.ToString() & ":" & Cmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
            Return False
        End Try

        Return True
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
            rdoSyokai.Focus()

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
            rdoSyokai.Checked = True
            chkIchiHen.Checked = False
            chkHenkan.Checked = False
            chkGojo.Checked = False
            numKI.Value = pObjTM_SYORI_NENDO_KI.pKI
            numHasseiKaisuFrom.Value = pObjTM_SYORI_NENDO_KI.pHASSEI_KAISU
            numHasseiKaisuTo.Value = pObjTM_SYORI_NENDO_KI.pHASSEI_KAISU
            numKeisanKaisuFrom.Value = 1
            numKeisanKaisuTo.Value = 999
            dateFurikomiYmd.Value = Nothing

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
            wkControlName = "対象データ"
            If chkIchiHen.Checked = False And chkHenkan.Checked = False And chkGojo.Checked = False Then
                'すべてチェックOFFの場合エラー
                Call Show_MessageBox_Add("W008", wkControlName) : chkIchiHen.Select() : chkIchiHen.Focus() : Exit Try
            End If
            wkControlName = "期"
            If numKI.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKI.Focus() : Exit Try
            End If
            '↓2022/01/31　JBD439 UPD　発生回数を認定回数に変更　R03年度対応
            'wkControlName = "発生回数From"  
            'If numHasseiKaisuFrom.Value Is Nothing Then
            '    Call Show_MessageBox_Add("W008", wkControlName) : numHasseiKaisuFrom.Focus() : Exit Try
            'End If
            'wkControlName = "発生回数To"  
            'If numHasseiKaisuTo.Value Is Nothing Then
            '    Call Show_MessageBox_Add("W008", wkControlName) : numHasseiKaisuTo.Focus() : Exit Try
            'End If
            wkControlName = "認定回数From"
            If numHasseiKaisuFrom.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numHasseiKaisuFrom.Focus() : Exit Try
            End If
            wkControlName = "認定回数To"
            If numHasseiKaisuTo.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numHasseiKaisuTo.Focus() : Exit Try
            End If
            '↑2022/01/31　JBD439 UPD　
            wkControlName = "計算回数From"
            If numKeisanKaisuFrom.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKeisanKaisuFrom.Focus() : Exit Try
            End If
            wkControlName = "計算回数To"
            If numKeisanKaisuTo.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKeisanKaisuTo.Focus() : Exit Try
            End If
            wkControlName = "振込予定日"
            If dateFurikomiYmd.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : dateFurikomiYmd.Focus() : Exit Try
            End If

            '==いろいろチェック==================
            '対象データ選択チェック
            If chkIchiHen.Checked Or chkHenkan.Checked Then
                If chkGojo.Checked Then
                    Call Show_MessageBox_Add("W019", "返還と互助金支払を同時に指定することはできません。")
                    chkIchiHen.Focus()
                    Exit Try
                End If
            End If

            '==FromToチェック==================
            '↓2022/01/31　JBD439 UPD　発生回数を認定回数に変更　R03年度対応
            ''発生回数
            'If f_Daisyo_Check(numHasseiKaisuFrom, numHasseiKaisuTo, "発生回数", True, 1) = False Then 
            '    Return False
            'End If
            '認定回数
            If f_Daisyo_Check(numHasseiKaisuFrom, numHasseiKaisuTo, "認定回数", True, 1) = False Then
                Return False
            End If
            '↑2022/01/31　JBD439 UPD　
            '計算回数
            If f_Daisyo_Check(numKeisanKaisuFrom, numKeisanKaisuTo, "計算回数", True, 1) = False Then
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
