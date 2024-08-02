'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ4012.vb
'*
'*　　②　機能概要　　　　　互助金申請情報明細入力（経営支援登録）
'*
'*　　③　作成日　　　　　　2015/01/24　BY JBD
'*
'*　　④　更新日            
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

Public Class frmGJ4012

#Region "***変数定義***"

    ''' <summary>
    ''' 固定項目
    ''' </summary>
    ''' <remarks></remarks>
    Property p4010_KI As Integer

    ''' <summary>
    ''' 処理状況
    ''' </summary>
    ''' <remarks></remarks>
    Property pLoadErr As Boolean


    ''' <summary>
    ''' 結果一覧セット用データセット
    ''' </summary>
    ''' <remarks></remarks>
    Private pDataSet As New DataSet

    ''' <summary>
    ''' グリッドキーリスト
    ''' </summary>
    ''' <remarks></remarks>
    Public paryKEY_4011_PARAM As frmGJ4011.T_KEY_PARAM

    ''' <summary>
    ''' カレント主キー
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pCurrentKey As frmGJ4010.T_KEY

    ''' <summary>
    ''' 行No
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pSel_NO As Integer

    ''' <summary>
    ''' 処理区分
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pSyoriKbn As Enu_SyoriKubun    '画面処理区分

    ''' <summary>
    '''  画面入力内容変更フラグ
    ''' </summary>
    ''' <remarks></remarks>
    Private loblnTextChange As Boolean                      '画面入力内容変更フラグ

    ''' <summary>
    ''' 処理区分
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Enu_SyoriKubun
        ''' <summary>
        ''' 新規登録モード
        ''' </summary>
        ''' <remarks></remarks>
        Insert = 0
        ''' <summary>
        ''' 更新モード
        ''' </summary>
        ''' <remarks></remarks>
        Update = 1
    End Enum

    ''' <summary>
    '''  プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True

    ''' <summary>
    '''  交付率 '2022/01/28 JBD9020 減額率交付率追加
    ''' </summary>
    Private pKofuRitu As Double = 100

#End Region

#Region "***画面制御関連***"

#Region "frmXXXXXX_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ4011_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmXXXLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean
        Dim wSql As String = String.Empty

        Try
            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            '画面初期化
            pJump = True
            ret = f_ObjectClear("C")
            pJump = False

            '変更判定イベント登録
            f_setControlChangeEvents()

            '★初期コントロールにフォーカスセット
            num_KOYO_ROTIN.Focus()


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        Finally
        End Try

    End Sub

#End Region

#End Region

#Region "***画面ボタンクリック関連***"

#Region "cmdSave_Click 保存ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSave_Click
    '説明            :保存ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim ea As New System.ComponentModel.CancelEventArgs


        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            If pSyoriKbn = Enu_SyoriKubun.Update Then   '変更
                If loblnTextChange Then
                Else
                    '画面に変更がない場合は、メッセージ表示
                    Show_MessageBox_Add("I007", "変更したデータはありません。")
                    Exit Try
                End If
            End If

            '事前チェック
            If Not f_Input_Check() Then
                Exit Try
            End If


            '処理区分
            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert       '新規入力

                    '保存処理確認
                    If Show_MessageBox_Add("Q004", "データ") = DialogResult.No Then    '保存します。よろしいですか？
                        Exit Try
                    End If

                    'データ保存処理
                    If Not f_Data_Insert() Then
                        Exit Try
                    End If

                    'フォームクローズ
                    Me.AutoValidate = AutoValidate.Disable
                    Me.Close()

                Case Enu_SyoriKubun.Update       '変更

                    '保存処理確認
                    If Show_MessageBox_Add("Q005", "データ") = DialogResult.No Then    '保存します。よろしいですか？
                        Exit Try
                    End If

                    'データ保存処理
                    If Not f_Data_update() Then
                        Exit Try
                    End If

                    'フォームクローズ
                    Me.AutoValidate = AutoValidate.Disable
                    Me.Close()
            End Select

            loblnTextChange = False      '画面入力内容変更フラグクリア

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdCan_Click キャンセルボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdCan_Click
    '説明            :キャンセルボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdCan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCansel.Click
        If loblnTextChange Then
            '画面に変更があり保存していない場合は、メッセージ表示
            If Show_MessageBox("Q007", "") = DialogResult.No Then
                Exit Sub
            End If
        End If

        '画面初期化
        If f_ObjectClear("") Then
            Exit Sub
        End If

        '変更フラグクリア
        loblnTextChange = False

        '★初期コントロールにフォーカスセット
        num_KOYO_ROTIN.Focus()

    End Sub
#End Region

#Region "cmdEnd_Click 終了ボタンクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdEnd_Click
    '説明            :終了ボタンクリック時処理
    '------------------------------------------------------------------
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try
            If loblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then
                    Exit Try
                End If
            End If

            loblnTextChange = False      '画面入力内容変更フラグ初期化
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

#Region "numKeisan_ValueChanged　互助金申請計算"

    Private Sub num_KUSYA_KIKAN_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Debug.Print(num_KUSYA_KIKAN.Value)
    End Sub

    Private Sub num_KUSYA_KIKAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        'Debug.Print(num_KUSYA_KIKAN.Value)
    End Sub

    Private Sub num_KUSYA_KIKAN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Debug.Print(num_KUSYA_KIKAN.Value)
    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :numKeisan_ValueChanged
    '説明            :互助金申請計算
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Sub numKeisan_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num_KOYO_ROTIN.ValueChanged,
                                                                                                           num_JIDAI.ValueChanged,
                                                                                                           num_GENKA_SYOKYAKU.ValueChanged,
                                                                                                           num_KUSYA_KIKAN.ValueChanged,
                                                                                                           num_SONOTA_KOTEIHI.ValueChanged,
                                                                                                           num_KOFU_HASU.ValueChanged,
                                                                                                           num_GENGAKU_RITU.ValueChanged, '2022/01/28 JBD9020 減額率交付率追加 ADD
                                                                                                           num_KOFU_RITU.ValueChanged '2022/01/28 JBD9020 減額率交付率追加 ADD
        Dim wkKin As Decimal
        Dim wkKin2 As Decimal
        'Dim wkKindb As Double '2022/01/28 JBD9020 減額率交付率追加 DEL 

        '----------------------------------
        '互助金申請計算処理
        '----------------------------------
        Try

            '2017/07/04　追加開始
            If pJump Then
                Exit Try
            End If
            '2017/07/04　追加終了

            num_KOYO_HOSEI_1.Value = Nothing
            num_JIDAI_HOSEI_2.Value = Nothing
            num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Value = Nothing


            '算定単価(補正係数)
            '①雇用労賃の補正（小数点第３位切り捨て）
            If Not num_KOYO_ROTIN.Value Is Nothing And Not num_KOYO_JOGEN.Value Is Nothing And Not num_KOYO_KOYO.Value Then
                wkKin = num_KOYO_JOGEN.Value * num_KOYO_ROTIN.Value
                wkKin2 = wkKin / num_KOYO_KOYO.Value
                wkKin = Math.Truncate(wkKin2 * 100) / 100
                num_KOYO_HOSEI.Value = wkKin
                num_KOYO_HOSEI_1.Value = wkKin
                'num_KOYO_HOSEI.Value = IIf(wkKin = 0, Nothing, wkKin)
                'num_KOYO_HOSEI_1.Value = IIf(wkKin = 0, Nothing, wkKin)
            End If

            '②地代の補正（小数点第３位切り捨て）
            If Not num_JIDAI.Value Is Nothing And Not num_JIDAI_JOGEN.Value Is Nothing And Not num_JIDAI_JIDAI.Value Then
                wkKin = num_JIDAI_JOGEN.Value * num_JIDAI.Value
                wkKin2 = wkKin / num_JIDAI_JIDAI.Value
                wkKin = Math.Truncate(wkKin2 * 100) / 100
                num_JIDAI_HOSEI.Value = wkKin
                num_JIDAI_HOSEI_2.Value = wkKin
            End If

            '③減価償却の補正（小数点第３位切り捨て）
            If Not num_GENKA_SYOKYAKU.Value Is Nothing And Not num_GENKA_JOGEN.Value Is Nothing And Not num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Value Then
                wkKin = num_GENKA_JOGEN.Value * num_GENKA_SYOKYAKU.Value
                wkKin2 = wkKin / num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Value
                wkKin = Math.Truncate(wkKin2 * 100) / 100
                num_GENKA_SYOKYAKU_GENKA_HOSEI.Value = wkKin
                num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Value = wkKin
            End If

            '④空舎期間の補正
            '2017/07/04　削除開始
            'If Not num_KUSYA_KIKAN.Value Is Nothing And Not num_KUSYA.Value Is Nothing Then
            '    wkKin = num_KUSYA_KIKAN.Value / num_KUSYA.Value
            '    wkKin = Math.Truncate(wkKin * 100) / 100
            '    num_KUSYA_HOSEI.Value = wkKin
            '    num_KUSYA_HOSEI_4.Value = wkKin
            'End If
            '2017/07/04　削除終了

            '2017/07/04　追加開始
            '⑤小計 ＝　①＋②＋③＋④
            If Not num_KOYO_HOSEI_1.Value Is Nothing And
               Not num_JIDAI_HOSEI_2.Value Is Nothing And
               Not num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Value Is Nothing Then
                wkKin = num_KOYO_HOSEI_1.Value + num_JIDAI_HOSEI_2.Value + num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Value
                'その他固定費の判定
                If Not num_SONOTA_KOTEIHI.Value Then
                    wkKin += num_SONOTA_KOTEIHI.Value
                End If
                num_Syokei5.Value = wkKin
            Else
                '⑤小計のクリア
                num_Syokei5.Value = Nothing
            End If
            '2017/07/04　追加終了

            '2017/07/04　修正開始
            ''⑤交付金単価
            'If Not num_KOYO_HOSEI_1.Value Is Nothing And Not num_JIDAI_HOSEI_2.Value Is Nothing And Not num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Value Is Nothing And Not num_KUSYA_HOSEI_4.Value Is Nothing Then
            '    wkKin = num_KOYO_HOSEI_1.Value + num_JIDAI_HOSEI_2.Value + num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Value
            '    'その他固定費の判定
            '    If Not num_SONOTA_KOTEIHI.Value Is Nothing Then
            '        wkKin = wkKin + num_SONOTA_KOTEIHI.Value
            '    End If
            '    wkKin2 = wkKin * num_KUSYA_HOSEI_4.Value
            '    wkKin = Math.Truncate(wkKin2)
            '    num_KOFU_KIN_TANKA.Value = wkKin
            '    num_KOFU_KIN_TANKA_SANTEI_JOGEN.Value = wkKin
            'Else
            '    '⑤交付金単価のクリア
            '    num_KOFU_KIN_TANKA.Value = Nothing
            '    num_KOFU_KIN_TANKA_SANTEI_JOGEN.Value = Nothing
            '    '決定交付上限単価のクリア
            '    num_KOFU_TANKA.Value = Nothing
            '    num_KOFU_TANKA_SAISYU.Value = Nothing
            '    '経営支援互助金　算定のクリア
            '    num_KEIEISIEN_SANTEI.Value = Nothing
            '    num_KEIEISIEN_SANTEI_1.Value = Nothing
            '    num_KEIEISIEN_SANTEI_2.Value = Nothing
            '    '①積立金交付金額のクリア
            '    num_SEI_TUMITATE_KIN.Value = Nothing
            '    num_SEI_TUMITATE_KIN2.Value = Nothing
            '    '②国庫交付金額
            '    num_KUNI_KOFU_KIN.Value = Nothing   '2017/01/18　追加
            '    '③経営支援互助金
            '    num_KOFU_KIN.Value = Nothing
            'End If
            '⑧交付金単価
            If Not num_Syokei5.Value Is Nothing AndAlso
               Not num_KUSYA_KIKAN.Value Is Nothing AndAlso
               Not num_KUSYA.Value Is Nothing Then
                wkKin2 = num_Syokei5.Value * num_KUSYA_KIKAN.Value / num_KUSYA.Value
                wkKin = Math.Truncate(wkKin2)
                num_KOFU_KIN_TANKA_SANTEI8.Value = wkKin
                num_KOFU_KIN_TANKA_SANTEI_JOGEN.Value = wkKin
            Else
                '⑧交付金単価のクリア
                num_KOFU_KIN_TANKA_SANTEI8.Value = Nothing
                num_KOFU_KIN_TANKA_SANTEI_JOGEN.Value = Nothing
                '決定交付上限単価のクリア
                num_KOFU_TANKA.Value = Nothing
                num_KOFU_TANKA_SAISYU.Value = Nothing
                '経営支援互助金　算定のクリア
                num_KOME1_CALC.Value = Nothing
                num_KOME1HIKU2_CALC.Value = Nothing
                num_KOME1HIKU2_DISP.Value = Nothing
                '家伝法違反減額のクリア           '2022/01/28 JBD9020 減額率交付率追加 ADD
                num_KOME1_DISP.Value = Nothing    '2022/01/28 JBD9020 減額率交付率追加 ADD
                num_KOME2.Value = Nothing         '2022/01/28 JBD9020 減額率交付率追加 ADD
                '①積立金交付金額のクリア
                num_KOME1HIKU2_DISP.Value = Nothing    '2022/01/28 JBD9020 減額率交付率追加 ADD
                num_KOME3_CALC.Value = Nothing
                num_KOME3_DISP1.Value = Nothing        '2022/01/28 JBD9020 減額率交付率追加 ADD
                num_MARU1.Value = Nothing              '2022/01/28 JBD9020 減額率交付率追加 ADD
                '②国庫交付金額
                num_KOME1HIKU2_DISP.Value = Nothing '2022/01/28 JBD9020 減額率交付率追加 ADD
                num_KOME3_DISP2.Value = Nothing
                num_MARU2.Value = Nothing   '2017/01/18　追加
                '③経営支援互助金
                num_MARU3.Value = Nothing
            End If
            '2017/07/04　修正終了

            '決定交付上限単価
            If Not num_KOFU_KIN_TANKA_BET2.Value Is Nothing And Not num_KOFU_KIN_TANKA_SANTEI_JOGEN.Value Is Nothing Then
                If num_KOFU_KIN_TANKA_BET2.Value > num_KOFU_KIN_TANKA_SANTEI_JOGEN.Value Then
                    num_KOFU_TANKA.Value = num_KOFU_KIN_TANKA_SANTEI_JOGEN.Value
                    num_KOFU_TANKA_SAISYU.Value = num_KOFU_KIN_TANKA_SANTEI_JOGEN.Value
                Else
                    num_KOFU_TANKA.Value = num_KOFU_KIN_TANKA_BET2.Value
                    num_KOFU_TANKA_SAISYU.Value = num_KOFU_KIN_TANKA_BET2.Value
                End If
            Else
                '決定交付上限単価のクリア
                num_KOFU_TANKA.Value = Nothing
                num_KOFU_TANKA_SAISYU.Value = Nothing
                '経営支援互助金　算定のクリア
                num_KOME1_CALC.Value = Nothing
                num_KOME1HIKU2_CALC.Value = Nothing
                num_KOME1HIKU2_DISP.Value = Nothing
                '家伝法違反減額のクリア           '2022/01/28 JBD9020 減額率交付率追加 ADD
                num_KOME1_DISP.Value = Nothing    '2022/01/28 JBD9020 減額率交付率追加 ADD
                num_KOME2.Value = Nothing         '2022/01/28 JBD9020 減額率交付率追加 ADD
                '①積立金交付金額のクリア
                num_KOME1HIKU2_DISP.Value = Nothing    '2022/01/28 JBD9020 減額率交付率追加 ADD
                num_KOME3_CALC.Value = Nothing
                num_KOME3_DISP1.Value = Nothing        '2022/01/28 JBD9020 減額率交付率追加 ADD
                num_MARU1.Value = Nothing              '2022/01/28 JBD9020 減額率交付率追加 ADD
                '②国庫交付金額
                num_KOME1HIKU2_DISP.Value = Nothing '2022/01/28 JBD9020 減額率交付率追加 ADD
                num_KOME3_DISP2.Value = Nothing
                num_MARU2.Value = Nothing   '2017/01/18　追加
                '③経営支援互助金
                num_MARU3.Value = Nothing
            End If

            '2022/01/28 JBD9020 減額率交付率追加 UPD START
            ''経営支援互助金　算定
            'If Not num_KOFU_HASU.Value Is Nothing And Not num_KOFU_TANKA_SAISYU.Value Is Nothing Then
            '    num_KOME1_CALC.Value = num_KOFU_HASU.Value * num_KOFU_TANKA_SAISYU.Value
            '    num_KOME1HIKU2_CALC.Value = num_KOME1_CALC.Value
            '    num_KOME1HIKU2_DISP.Value = num_KOME1_CALC.Value
            'Else
            '    '経営支援互助金　算定のクリア
            '    num_KOME1_CALC.Value = Nothing
            '    num_KOME1HIKU2_CALC.Value = Nothing
            '    num_KOME1HIKU2_DISP.Value = Nothing
            '    '①積立金交付金額のクリア
            '    num_KOME3_CALC.Value = Nothing
            '    num_KOME3_DISP2.Value = Nothing
            '    '②国庫交付金額
            '    num_MARU2.Value = Nothing   '2017/01/18　追加
            '    '③経営支援互助金
            '    num_MARU3.Value = Nothing
            'End If

            ''①積立金交付金額(円未満切り上げ)
            'If Not num_KOME1HIKU2_CALC.Value Is Nothing Then
            '    wkKindb = num_KOME1HIKU2_CALC.Value / 2
            '    num_KOME3_CALC.Value = Math.Ceiling(wkKindb)
            '    num_KOME3_DISP2.Value = Math.Ceiling(wkKindb)
            'Else

            '    '①積立金交付金額のクリア
            '    num_KOME3_CALC.Value = Nothing
            '    num_KOME3_DISP2.Value = Nothing
            '    '②国庫交付金額
            '    num_MARU2.Value = Nothing   '2017/01/18　追加
            '    '③経営支援互助金
            '    num_MARU3.Value = Nothing
            'End If

            ''2017/01/18　追加開始
            ''②国庫交付金額(経営支援互助金　算定　－　積立金交付金額)
            'If Not num_KOME1HIKU2_DISP.Value Is Nothing AndAlso Not num_KOME3_DISP2 Is Nothing Then
            '    num_MARU2.Value = num_KOME1HIKU2_DISP.Value - num_KOME3_DISP2.Value
            'Else
            '    '②国庫交付金額
            '    num_MARU2.Value = Nothing   '2017/01/18　追加
            '    '③経営支援互助金
            '    num_MARU3.Value = Nothing
            'End If
            ''2017/01/18　追加終了

            ''③経営支援互助金
            'If Not num_KOME3_CALC.Value Is Nothing And Not num_MARU2.Value Is Nothing Then
            '    num_MARU3.Value = num_KOME3_CALC.Value + num_MARU2.Value
            'Else
            '    num_MARU3.Value = Nothing
            'End If

            '経営支援互助金　算定
            If Not num_KOFU_HASU.Value Is Nothing And Not num_KOFU_TANKA_SAISYU.Value Is Nothing Then
                num_KOME1_CALC.Value = num_KOFU_HASU.Value * num_KOFU_TANKA_SAISYU.Value
                num_KOME1_DISP.Value = num_KOME1_CALC.Value
            Else
                '経営支援互助金　算定のクリア
                num_KOME1_CALC.Value = Nothing
                num_KOME1HIKU2_CALC.Value = Nothing
                num_KOME1HIKU2_DISP.Value = Nothing
                '家伝法違反減額のクリア 
                num_KOME1_DISP.Value = Nothing
                num_KOME2.Value = Nothing
                '①積立金交付金額のクリア
                num_KOME1HIKU2_DISP.Value = Nothing
                num_KOME3_CALC.Value = Nothing
                num_KOME3_DISP1.Value = Nothing
                num_MARU1.Value = Nothing
                '②国庫交付金額
                num_KOME1HIKU2_DISP.Value = Nothing
                num_KOME3_DISP2.Value = Nothing
                num_MARU2.Value = Nothing
                '③経営支援互助金
                num_MARU3.Value = Nothing
            End If

            '家伝法違反減額※３
            If Not num_KOFU_HASU.Value Is Nothing And Not num_KOFU_TANKA_SAISYU.Value Is Nothing And Not num_GENGAKU_RITU.Value Is Nothing Then
                Dim wkKome2 As Double
                Dim wkKome3 As Double

                wkKome2 = num_KOME1_DISP.Value * num_GENGAKU_RITU.Value / 100
                num_KOME2.Value = Math.Ceiling(wkKome2)
                num_KOME1HIKU2_CALC.Value = num_KOME1_CALC.Value - num_KOME2.Value
                num_KOME1HIKU2_DISP.Value = num_KOME1_CALC.Value - num_KOME2.Value

                wkKome3 = num_KOME1HIKU2_DISP.Value / 2
                num_KOME3_CALC.Value = Math.Ceiling(wkKome3)
                num_KOME3_DISP1.Value = num_KOME3_CALC.Value
                num_KOME3_DISP2.Value = num_KOME3_CALC.Value

                num_MARU2.Value = num_KOME1HIKU2_DISP.Value - num_KOME3_DISP2.Value
            Else
                '家伝法違反減額のクリア 
                num_KOME2.Value = Nothing
                '①積立金交付金額のクリア
                num_KOME1HIKU2_DISP.Value = Nothing
                num_KOME3_CALC.Value = Nothing
                num_KOME3_DISP1.Value = Nothing
                num_MARU1.Value = Nothing
                '②国庫交付金額
                num_KOME1HIKU2_DISP.Value = Nothing
                num_KOME3_DISP2.Value = Nothing
                num_MARU2.Value = Nothing
                '③経営支援互助金
                num_MARU3.Value = Nothing
            End If

            '家伝法違反減額※３
            If Not num_KOFU_HASU.Value Is Nothing And Not num_KOFU_TANKA_SAISYU.Value Is Nothing And Not num_GENGAKU_RITU.Value Is Nothing And Not num_KOFU_RITU.Value Is Nothing Then
                Dim wkmaru1 As Double

                wkmaru1 = num_KOME3_DISP1.Value * num_KOFU_RITU.Value / 100
                num_MARU1.Value = Math.Ceiling(wkmaru1)
                num_MARU3.Value = num_MARU1.Value + num_MARU2.Value
            Else
                num_MARU1.Value = Nothing
                num_MARU3.Value = Nothing
            End If

            '2022/01/28 JBD9020 減額率交付率追加 UPD END

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
        End Try


    End Sub
#End Region

#Region "入力確認有無"
    '------------------------------------------------------------------
    'プロシージャ名  :rbtnSYORI_JOKYO_KBN_3_CheckedChanged
    '説明            :交付確定CheckedChanged時処理
    '------------------------------------------------------------------
    Private Sub rbtnSYORI_JOKYO_KBN_3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtnSYORI_JOKYO_KBN_3.CheckedChanged
        If rbtnSYORI_JOKYO_KBN_3.Checked Then
            dateKOFU_KAKUTEI_Ymd.Enabled = True
        Else
            dateKOFU_KAKUTEI_Ymd.Enabled = False
        End If
    End Sub
#End Region

#End Region

#Region "*** データ登録関連 ***"

#Region "f_Data_Insert　互助金申請情報　追加処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Insert
    '説明            :互助金申請情報　追加処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Insert() As Boolean
        Dim Cmd As New OracleCommand
        Dim wkNow As Date = Now
        Dim wkRet As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Cmd.CommandText = "PKG_GJ4010.GJ4010_KOFU_SINSEI_INS"

            '引き渡し
            '期
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", WordHenkan("N", "Z", p4010_KI))
            '発生回数
            Dim paraHASSEI_KAISU As OracleParameter = Cmd.Parameters.Add("IN_HASSEI_KAISU", WordHenkan("N", "Z", paryKEY_4011_PARAM.HASSEI_KAISU))
            '契約者番号
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", WordHenkan("N", "Z", pCurrentKey.KEIYAKUSYA_CD))
            '互助金種類区分
            Dim paraGOJOKIN_SYURUI_KBN As OracleParameter = Cmd.Parameters.Add("IN_GOJOKIN_SYURUI_KBN", 1)
            '農場コード
            Dim paraNOJO_CD As OracleParameter = Cmd.Parameters.Add("IN_NOJO_CD", WordHenkan("N", "Z", paryKEY_4011_PARAM.NOJO_CD))
            '鶏の種類
            Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", WordHenkan("N", "Z", paryKEY_4011_PARAM.TORI_KBN))

            '契約区分
            Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", WordHenkan("N", "Z", pCurrentKey.KEIYAKU_KBN))
            '処理状況区分
            If rbtnSYORI_JOKYO_KBN_1.Checked Then
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 1)
            End If
            If rbtnSYORI_JOKYO_KBN_2.Checked Then
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 2)
            End If
            If rbtnSYORI_JOKYO_KBN_3.Checked Then
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 3)
            End If

            '雇用労賃
            Dim paraKOYO_ROTIN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_ROTIN", WordHenkan("N", "Z", num_KOYO_ROTIN.Value))
            '地代
            Dim paraJIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI", WordHenkan("N", "Z", num_JIDAI.Value))
            '減価償却
            Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", WordHenkan("N", "Z", num_GENKA_SYOKYAKU.Value))
            '空舎期間
            Dim paraKUSYA_KIKAN As OracleParameter = Cmd.Parameters.Add("IN_KUSYA_KIKAN", WordHenkan("N", "Z", num_KUSYA_KIKAN.Value))
            'その他固定費
            Dim paraSONOTA_KOTEIHI As OracleParameter = Cmd.Parameters.Add("IN_SONOTA_KOTEIHI", WordHenkan("N", "Z", num_SONOTA_KOTEIHI.Value))

            '焼却等経費
            Dim paraSYOKYAKU_KEIHI As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_KEIHI", DBNull.Value)
            '国交付金
            Dim paraKUNI_KOFUKIN As OracleParameter = Cmd.Parameters.Add("IN_KUNI_KOFUKIN", DBNull.Value)
            '交付確定日
            If rbtnSYORI_JOKYO_KBN_3.Checked Then
                Dim paraKOFU_KAKUTEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_KOFU_KAKUTEI_DATE", Format(dateKOFU_KAKUTEI_Ymd.Value, "yyyy/MM/dd"))
            Else
                Dim paraKOFU_KAKUTEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_KOFU_KAKUTEI_DATE", DBNull.Value)
            End If
            '交付単価
            Dim paraKOFU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KOFU_TANKA", WordHenkan("N", "Z", num_KOFU_TANKA.Value))
            '交付羽数
            Dim paraKOFU_HASU As OracleParameter = Cmd.Parameters.Add("IN_KOFU_HASU", WordHenkan("N", "Z", num_KOFU_HASU.Value))
            '生産者積立金分
            Dim paraSEI_TUMITATE_KIN As OracleParameter = Cmd.Parameters.Add("IN_SEI_TUMITATE_KIN", WordHenkan("N", "Z", num_MARU1.Value))
            '国庫交付金分
            'Dim paraKUNI_KOFU_KIN As OracleParameter = Cmd.Parameters.Add("IN_KUNI_KOFU_KIN", WordHenkan("N", "Z", num_SEI_TUMITATE_KIN2.Value))   '2017/01/18　修正
            Dim paraKUNI_KOFU_KIN As OracleParameter = Cmd.Parameters.Add("IN_KUNI_KOFU_KIN", WordHenkan("N", "Z", num_MARU2.Value))        '2017/01/18　修正
            '交付金額
            Dim paraKOFU_KIN As OracleParameter = Cmd.Parameters.Add("IN_KOFU_KIN", WordHenkan("N", "Z", num_MARU3.Value))

            '互助金単価マスタ参照日
            Dim paraTANKA_MST_DATE As OracleParameter = Cmd.Parameters.Add("IN_TANKA_MST_DATE", pCurrentKey.TANKA_MST_DATE)
            '申請日
            Dim paraSINSEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_SINSEI_DATE", paryKEY_4011_PARAM.SINSEI_DATE)

            '2022/01/28 JBD9020 減額率交付率追加 ADD START
            '算定金額
            Dim paraSANTEI_KIN As OracleParameter = Cmd.Parameters.Add("IN_SANTEI_KIN", WordHenkan("N", "Z", num_KOME1_CALC.Value))
            '減額率
            Dim paraGENGAKU_RITU As OracleParameter = Cmd.Parameters.Add("IN_GENGAKU_RITU", WordHenkan("N", "Z", num_GENGAKU_RITU.Value))
            '交付率
            Dim paraKOFU_RITU As OracleParameter = Cmd.Parameters.Add("IN_KOFU_RITU", WordHenkan("N", "Z", num_KOFU_RITU.Value))
            '2022/01/28 JBD9020 減額率交付率追加 ADD END

            Dim paraREGDATE As OracleParameter = Cmd.Parameters.Add("IN_REG_DATE", Now)                 'データ登録日
            Dim paraREGID As OracleParameter = Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)            'データ登録ＩＤ
            Dim paraUPDATE As OracleParameter = Cmd.Parameters.Add("IN_UP_DATE", Now)                   'データ更新日
            Dim paraUPID As OracleParameter = Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)              'データ更新ＩＤ
            Dim paraCOMNM As OracleParameter = Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)               'コンピュータ名

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

            wkRet = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
        End Try
        Return wkRet
    End Function

#End Region

#Region "f_Data_update　互助金申請情報　更新処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_update
    '説明            :互助金申請情報　更新処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_update() As Boolean
        Dim Cmd As New OracleCommand
        Dim wkNow As Date = Now
        Dim wkRet As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Cmd.CommandText = "PKG_GJ4010.GJ4010_KOFU_SINSEI_UPD"

            '引き渡し
            '期
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", WordHenkan("N", "Z", p4010_KI))
            '発生回数
            Dim paraHASSEI_KAISU As OracleParameter = Cmd.Parameters.Add("IN_HASSEI_KAISU", WordHenkan("N", "Z", paryKEY_4011_PARAM.HASSEI_KAISU))
            '契約者番号
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", WordHenkan("N", "Z", pCurrentKey.KEIYAKUSYA_CD))
            '互助金種類区分
            Dim paraGOJOKIN_SYURUI_KBN As OracleParameter = Cmd.Parameters.Add("IN_GOJOKIN_SYURUI_KBN", 1)
            '農場コード
            Dim paraNOJO_CD As OracleParameter = Cmd.Parameters.Add("IN_NOJO_CD", WordHenkan("N", "Z", paryKEY_4011_PARAM.NOJO_CD))
            '鶏の種類
            Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", WordHenkan("N", "Z", paryKEY_4011_PARAM.TORI_KBN))

            '契約区分
            Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", WordHenkan("N", "Z", pCurrentKey.KEIYAKU_KBN))
            '処理状況区分
            If rbtnSYORI_JOKYO_KBN_1.Checked Then
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 1)
            End If
            If rbtnSYORI_JOKYO_KBN_2.Checked Then
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 2)
            End If
            If rbtnSYORI_JOKYO_KBN_3.Checked Then
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 3)
            End If

            '雇用労賃
            Dim paraKOYO_ROTIN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_ROTIN", WordHenkan("N", "Z", num_KOYO_ROTIN.Value))
            '地代
            Dim paraJIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI", WordHenkan("N", "Z", num_JIDAI.Value))
            '減価償却
            Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", WordHenkan("N", "Z", num_GENKA_SYOKYAKU.Value))
            '空舎期間
            Dim paraKUSYA_KIKAN As OracleParameter = Cmd.Parameters.Add("IN_KUSYA_KIKAN", WordHenkan("N", "Z", num_KUSYA_KIKAN.Value))
            'その他固定費
            Dim paraSONOTA_KOTEIHI As OracleParameter = Cmd.Parameters.Add("IN_SONOTA_KOTEIHI", WordHenkan("N", "Z", num_SONOTA_KOTEIHI.Value))

            '焼却等経費
            Dim paraSYOKYAKU_KEIHI As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_KEIHI", DBNull.Value)
            '国交付金
            Dim paraKUNI_KOFUKIN As OracleParameter = Cmd.Parameters.Add("IN_KUNI_KOFUKIN", DBNull.Value)
            '交付確定日
            If rbtnSYORI_JOKYO_KBN_3.Checked Then
                Dim paraKOFU_KAKUTEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_KOFU_KAKUTEI_DATE", Format(dateKOFU_KAKUTEI_Ymd.Value, "yyyy/MM/dd"))
            Else
                Dim paraKOFU_KAKUTEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_KOFU_KAKUTEI_DATE", DBNull.Value)
            End If
            '交付単価
            Dim paraKOFU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KOFU_TANKA", WordHenkan("N", "Z", num_KOFU_TANKA.Value))
            '交付羽数
            Dim paraKOFU_HASU As OracleParameter = Cmd.Parameters.Add("IN_KOFU_HASU", WordHenkan("N", "Z", num_KOFU_HASU.Value))
            '生産者積立金分
            Dim paraSEI_TUMITATE_KIN As OracleParameter = Cmd.Parameters.Add("IN_SEI_TUMITATE_KIN", WordHenkan("N", "Z", num_MARU1.Value))
            '国庫交付金分
            'Dim paraKUNI_KOFU_KIN As OracleParameter = Cmd.Parameters.Add("IN_KUNI_KOFU_KIN", WordHenkan("N", "Z", num_SEI_TUMITATE_KIN2.Value))   '2017/01/18　修正
            Dim paraKUNI_KOFU_KIN As OracleParameter = Cmd.Parameters.Add("IN_KUNI_KOFU_KIN", WordHenkan("N", "Z", num_MARU2.Value))        '2017/01/18　修正
            '交付金額
            Dim paraKOFU_KIN As OracleParameter = Cmd.Parameters.Add("IN_KOFU_KIN", WordHenkan("N", "Z", num_MARU3.Value))

            '互助金単価マスタ参照日
            Dim paraTANKA_MST_DATE As OracleParameter = Cmd.Parameters.Add("IN_TANKA_MST_DATE", pCurrentKey.TANKA_MST_DATE)
            '申請日
            Dim paraSINSEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_SINSEI_DATE", paryKEY_4011_PARAM.SINSEI_DATE)

            '2022/01/28 JBD9020 減額率交付率追加 ADD START
            '算定金額
            Dim paraSANTEI_KIN As OracleParameter = Cmd.Parameters.Add("IN_SANTEI_KIN", WordHenkan("N", "Z", num_KOME1_CALC.Value))
            '減額率
            Dim paraGENGAKU_RITU As OracleParameter = Cmd.Parameters.Add("IN_GENGAKU_RITU", WordHenkan("N", "Z", num_GENGAKU_RITU.Value))
            '交付率
            Dim paraKOFU_RITU As OracleParameter = Cmd.Parameters.Add("IN_KOFU_RITU", WordHenkan("N", "Z", num_KOFU_RITU.Value))
            '2022/01/28 JBD9020 減額率交付率追加 ADD END

            Dim paraREGDATE As OracleParameter = Cmd.Parameters.Add("IN_REG_DATE", Now)                 'データ登録日
            Dim paraREGID As OracleParameter = Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)            'データ登録ＩＤ
            Dim paraUPDATE As OracleParameter = Cmd.Parameters.Add("IN_UP_DATE", Now)                   'データ更新日
            Dim paraUPID As OracleParameter = Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)              'データ更新ＩＤ
            Dim paraCOMNM As OracleParameter = Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)               'コンピュータ名

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

            wkRet = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
        End Try


        Return wkRet


    End Function

#End Region

#End Region

#Region "***ローカル関数***"

#Region "f_setControlChangeEvents 変更判定イベント登録処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_setControlChangeEvents
    '説明            :変更判定イベント登録処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Sub f_setControlChangeEvents()

        'フォーム上に配置されているすべてのコントロールを列挙
        Dim All_Ctl As Control() = f_GetAllControls(Me)

        For Each wkCtrl As Control In All_Ctl

            Select Case True
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcComboBox
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcComboBox).TextChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcDate
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcDate).ValueChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcMask
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcMask).ValueChanged, AddressOf f_setChanged
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
    '------------------------------------------------------------------
    'プロシージャ名  :f_setChanged
    '説明            :コントロール変更時処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Sub f_setChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        loblnTextChange = True

    End Sub
#End Region

#Region "f_ObjectClear 画面クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ObjectClear
    '説明            :画面クリア処理
    '引数            :rKbn(処理区分)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ObjectClear(ByVal wKbn As String) As Boolean
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

        f_ObjectClear = False

        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            pJump = True
            f_ClearFormALL(Me, wKbn)
            pJump = False

            '====初期値設定======================
            If f_SetForm_Data() Then
                Exit Try
            End If

            f_ObjectClear = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            clsNENDO_KI = Nothing
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Function
#End Region

#Region "f_SetForm_Data 初期画面表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_Data
    '説明            :画面表示
    '引数            :wKbn  "C":初期表示  "":再表示
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_Data() As Boolean
        Dim ret As Boolean = False
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim blnChange As Boolean = False '2022/01/28 JBD9020 減額率交付率追加 ADD START

        Try

            'pJump = True   '2017/07/04　削除

            'フォームロード時のみ
            'ヘッダ表示
            lbl_KEIYAKUSYA_CD.Text = pCurrentKey.KEIYAKUSYA_CD
            lbl_KEIYAKUSYA_NM.Text = pCurrentKey.KEIYAKUSYA_NAME
            lbl_KEIYAKU_KBN.Text = pCurrentKey.KEIYAKU_KBN
            lbl_KEIYAKU_KBN_NM.Text = pCurrentKey.KEIYAKU_KBN_NM

            lbl_NOJO_CD.Text = paryKEY_4011_PARAM.NOJO_CD
            lbl_NOJO_NAME.Text = paryKEY_4011_PARAM.NOJO_NAME
            lbl_TORI_KBN.Text = paryKEY_4011_PARAM.TORI_KBN
            lbl_TORI_KBN_NM.Text = paryKEY_4011_PARAM.TORI_KBN_NM
            lbl_KEIYAKU_HASU.Text = paryKEY_4011_PARAM.KEIYAKU_HASU
            lbl_ADDR_1.Text = paryKEY_4011_PARAM.ADDR_1
            lbl_ADDR_2.Text = paryKEY_4011_PARAM.ADDR_2
            lbl_ADDR_3.Text = paryKEY_4011_PARAM.ADDR_3
            lbl_ADDR_4.Text = paryKEY_4011_PARAM.ADDR_4

            '基礎指標マスタの取得
            If Not f_SetForm_TM_KISOSIHYO() Then
                Exit Try
            End If
            '別表２の交付上限単価の取得
            If Not f_SetForm_TM_TANKA() Then
                Exit Try
            End If
            '2022/02/01 JBD9020 減額率交付率追加 ADD START
            If Not f_SetForm_KOFU_RITU() Then
                Exit Try
            End If
            '2022/02/01 JBD9020 減額率交付率追加 ADD END

            '入力明細制御
            If Not f_DtlInput_Enable(paryKEY_4011_PARAM.EDIT_KBN) Then
                Exit Try
            End If

            'ボタン制御
            If Not f_DtlButton_Enable(paryKEY_4011_PARAM.EDIT_KBN) Then
                Exit Try
            End If

            '入力項目初期値
            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert
                    num_KOFU_RITU.Value = pKofuRitu '2022/01/28 JBD9020 減額率交付率追加 ADD
                    lbl_SYORI_JOKYO_KBN_NM.Text = ""
                    rbtnSYORI_JOKYO_KBN_1.Checked = True
                    dateKOFU_KAKUTEI_Ymd.Enabled = False
                Case Enu_SyoriKubun.Update
                    '互助申請の取得
                    If Not f_SetForm_TT_KOFU_SINSEI() Then
                        Exit Try
                    End If
                    '2022/01/28 JBD9020 減額率交付率追加 ADD START
                    If num_KOFU_RITU.Value <> pKofuRitu And lbl_SYORI_JOKYO_KBN_NM.Text = "" Then
                        If Show_MessageBox_Add("Q012", "マスタに登録されている交付率と異なります。再計算を行いますか？") = DialogResult.Yes Then
                            num_KOFU_RITU.Value = pKofuRitu
                            blnChange = True
                        End If
                    End If
                    '2022/01/28 JBD9020 減額率交付率追加 ADD END
            End Select

            '初期コントロールにフォーカスセット
            num_KOYO_ROTIN.Focus()


            'フラグ　クリア
            loblnTextChange = False
            'pJump = False      '2017/07/04　削除

            '2022/01/28 JBD9020 減額率交付率追加 ADD START
            If blnChange Then
                loblnTextChange = True
            End If
            '2022/01/28 JBD9020 減額率交付率追加 ADD END

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_SetForm_TM_KISOSIHYO 基礎指標マスタの取得表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TM_KISOSIHYO
    '説明            :基礎指標マスタの取得表示処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_TM_KISOSIHYO() As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty
        Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

        Try

            '--------------------------------------------------
            '   基礎指標マスタの取得
            '--------------------------------------------------
            '基礎指標マスタ用ＳＱＬ　作成
            wSql = "SELECT"
            wSql &= "      KISO.KOYO_JOGEN"
            wSql &= "     ,KISO.KOYO_KOYO"
            wSql &= "     ,KISO.JIDAI_JOGEN"
            wSql &= "     ,KISO.JIDAI_JIDAI"
            wSql &= "     ,KISO.GENKA_JOGEN"
            wSql &= "     ,KISO.GENKA_SYOKYAKU"
            wSql &= "     ,KISO.KUSYA"
            wSql &= " FROM TM_KISOSIHYO KISO"
            '               --条件
            wSql &= " WHERE KISO.KI = " & p4010_KI
            '#81 UPD START
            'wSql &= "  AND KISO.TAISYO_NENDO = " & clsNENDO_KI.pJIGYO_NENDO
            wSql &= "  AND KISO.TAISYO_NENDO = " & clsNENDO_KI.pTAISYO_NENDO
            '#81 UPD END
            wSql &= "  AND KISO.KEIYAKU_KBN =  " & pCurrentKey.KEIYAKU_KBN
            wSql &= "  AND KISO.TORI_KBN =  " & paryKEY_4011_PARAM.TORI_KBN

            'ＳＱＬ実行
            If Not f_Select_ODP(pDataSet, wSql) Then
                Exit Try
            End If

            '画面に該当データを表示
            With pDataSet.Tables(0)
                If .Rows.Count > 0 Then
                    '基礎指標
                    '2017/01/18　修正開始
                    'num_KOYO_JOGEN.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOYO_JOGEN")))
                    'num_KOYO_KOYO.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOYO_KOYO")))
                    'num_JIDAI_JOGEN.Value = CLng(WordHenkan("N", "Z", .Rows(0)("JIDAI_JOGEN")))
                    'num_JIDAI_JIDAI.Value = CLng(WordHenkan("N", "Z", .Rows(0)("JIDAI_JIDAI")))
                    'num_GENKA_JOGEN.Value = CLng(WordHenkan("N", "Z", .Rows(0)("GENKA_JOGEN")))
                    'num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Value = CLng(WordHenkan("N", "Z", .Rows(0)("GENKA_SYOKYAKU")))
                    'num_KUSYA.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KUSYA")))
                    '小数点対応
                    If .Rows(0)("KOYO_JOGEN").ToString = "" Then
                        num_KOYO_JOGEN.Value = Nothing
                    Else
                        num_KOYO_JOGEN.Value = CDec(.Rows(0)("KOYO_JOGEN").ToString)
                    End If
                    If .Rows(0)("KOYO_KOYO").ToString = "" Then
                        num_KOYO_KOYO.Value = Nothing
                    Else
                        num_KOYO_KOYO.Value = CDec(.Rows(0)("KOYO_KOYO").ToString)
                    End If
                    If .Rows(0)("JIDAI_JOGEN").ToString = "" Then
                        num_JIDAI_JOGEN.Value = Nothing
                    Else
                        num_JIDAI_JOGEN.Value = CDec(.Rows(0)("JIDAI_JOGEN").ToString)
                    End If
                    If .Rows(0)("JIDAI_JIDAI").ToString = "" Then
                        num_JIDAI_JIDAI.Value = Nothing
                    Else
                        num_JIDAI_JIDAI.Value = CDec(.Rows(0)("JIDAI_JIDAI").ToString)
                    End If
                    If .Rows(0)("GENKA_JOGEN").ToString = "" Then
                        num_GENKA_JOGEN.Value = Nothing
                    Else
                        num_GENKA_JOGEN.Value = CDec(.Rows(0)("GENKA_JOGEN").ToString)
                    End If
                    If .Rows(0)("GENKA_SYOKYAKU").ToString = "" Then
                        num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Value = Nothing
                    Else
                        num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Value = CDec(.Rows(0)("GENKA_SYOKYAKU").ToString)
                    End If
                    If .Rows(0)("KUSYA").ToString = "" Then
                        num_KUSYA.Value = Nothing
                    Else
                        num_KUSYA.Value = CDec(.Rows(0)("KUSYA").ToString)
                    End If
                    '2017/01/18　修正終了
                End If
            End With

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            clsNENDO_KI = Nothing
        End Try

        Return ret

    End Function

#End Region

#Region "f_SetForm_TM_TANKA 契約者積立金・互助金単価マスタの取得表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TM_TANKA
    '説明            :契約者積立金・互助金単価マスタの取得表示処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_TM_TANKA() As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty
        Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

        Try

            '--------------------------------------------------
            '   契約者積立金・互助金単価マスタの取得
            '--------------------------------------------------
            '契約者積立金・互助金単価マスタ用ＳＱＬ　作成
            wSql = "SELECT"
            wSql &= "     TNK.KEIEISIEN_TANKA"
            wSql &= "	 ,TNK.TAISYO_DATE_FROM"
            wSql &= "    ,TNK.TAISYO_DATE_TO"
            wSql &= " FROM"
            wSql &= "     TM_TANKA TNK"
            wSql &= " WHERE"
            '             --条件
            wSql &= "     TNK.KEIYAKU_KBN = " & pCurrentKey.KEIYAKU_KBN
            wSql &= " AND TNK.TORI_KBN = " & paryKEY_4011_PARAM.TORI_KBN
            wSql &= " AND (   TNK.TAISYO_DATE_FROM <= TO_DATE('" & pCurrentKey.TANKA_MST_DATE & "','yyyy/mm/dd')"
            wSql &= "     AND TNK.TAISYO_DATE_TO   >= TO_DATE('" & pCurrentKey.TANKA_MST_DATE & "','yyyy/mm/dd')"
            wSql &= "     )"

            'ＳＱＬ実行
            If Not f_Select_ODP(pDataSet, wSql) Then
                Exit Try
            End If

            '画面に該当データを表示
            With pDataSet.Tables(0)
                If .Rows.Count > 0 Then
                    '基礎指標
                    num_KOFU_KIN_TANKA_BET2.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KEIEISIEN_TANKA")))
                End If
            End With

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            clsNENDO_KI = Nothing
        End Try

        Return ret

    End Function

#End Region

#Region "f_SetForm_KOFU_RITU 契約者積立金・交付率の取得表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_KOFU_RITU
    '説明            :交付率の取得表示処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '2022/02/01 JBD9020 減額率交付率追加 ADD
    '------------------------------------------------------------------
    Private Function f_SetForm_KOFU_RITU() As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty
        Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

        Try

            '--------------------------------------------------
            '   契約者積立金・互助金単価マスタの取得
            '--------------------------------------------------
            '契約者積立金・互助金単価マスタ用ＳＱＬ　作成
            wSql = "SELECT"
            wSql &= "    TNK.KOFU_RITU"
            wSql &= " FROM"
            wSql &= "     TM_TANKA TNK"
            wSql &= " WHERE"
            '             --条件
            wSql &= "     TNK.KEIYAKU_KBN = 9"
            wSql &= " AND TNK.TORI_KBN = 9"
            wSql &= " AND (   TNK.TAISYO_DATE_FROM <= TO_DATE('" & pCurrentKey.TANKA_MST_DATE & "','yyyy/mm/dd')"
            wSql &= "     AND TNK.TAISYO_DATE_TO   >= TO_DATE('" & pCurrentKey.TANKA_MST_DATE & "','yyyy/mm/dd')"
            wSql &= "     )"

            'ＳＱＬ実行
            If Not f_Select_ODP(pDataSet, wSql) Then
                Exit Try
            End If

            '画面に該当データを表示
            With pDataSet.Tables(0)
                If .Rows.Count > 0 Then
                    '基礎指標
                    pKofuRitu = CDbl(WordHenkan("N", "Z", .Rows(0)("KOFU_RITU")))
                End If
            End With

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            clsNENDO_KI = Nothing
        End Try

        Return ret

    End Function

#End Region

#Region "f_SetForm_TT_KOFU_SINSEI 互助交付申請の取得表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TT_KOFU_SINSEI
    '説明            :互助交付申請の取得表示処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_TT_KOFU_SINSEI() As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty
        Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

        Try

            '--------------------------------------------------
            '   互助交付申請の取得
            '--------------------------------------------------
            '互助交付申請の取得用ＳＱＬ　作成
            wSql = "SELECT"
            wSql &= "      SIN.SYORI_JOKYO_KBN"
            wSql &= "     ,M13.MEISYO AS SYORI_JOKYO_KBN_NM"
            wSql &= "     ,SIN.KOYO_ROTIN"
            wSql &= "     ,SIN.JIDAI"
            wSql &= "     ,SIN.GENKA_SYOKYAKU"
            wSql &= "     ,SIN.KUSYA_KIKAN"
            wSql &= "     ,SIN.SONOTA_KOTEIHI"
            wSql &= "     ,SIN.KUNI_KOFUKIN"
            wSql &= "     ,SIN.KOFU_KAKUTEI_DATE"
            wSql &= "     ,SIN.KOFU_TANKA"
            wSql &= "     ,SIN.KOFU_HASU"
            wSql &= "     ,SIN.SEI_TUMITATE_KIN"
            wSql &= "     ,SIN.KUNI_KOFU_KIN"
            wSql &= "     ,SIN.KOFU_KIN"
            '2022/01/28 JBD9020 減額率交付率追加 ADD START
            wSql &= "     ,SIN.SANTEI_KIN"
            wSql &= "     ,SIN.GENGAKU_RITU"
            wSql &= "     ,SIN.KOFU_RITU"
            '2022/01/28 JBD9020 減額率交付率追加 ADD END
            wSql &= " FROM TT_KOFU_SINSEI SIN"
            wSql &= "     ,TM_CODE M13"
            wSql &= " WHERE"
            '              -- 互助金情報入力状況
            wSql &= "      SYORI_JOKYO_KBN = M13.MEISYO_CD"
            wSql &= "  AND 13 = M13.SYURUI_KBN"
            '              -- 条件
            wSql &= "  AND SIN.KI = " & p4010_KI
            wSql &= "  AND SIN.HASSEI_KAISU = " & paryKEY_4011_PARAM.HASSEI_KAISU
            wSql &= "  AND SIN.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND SIN.GOJOKIN_SYURUI_KBN = 1"
            wSql &= "  AND SIN.NOJO_CD = " & paryKEY_4011_PARAM.NOJO_CD
            wSql &= "  AND SIN.TORI_KBN= " & paryKEY_4011_PARAM.TORI_KBN

            'ＳＱＬ実行
            If Not f_Select_ODP(pDataSet, wSql) Then
                Exit Try
            End If

            '画面に該当データを表示
            With pDataSet.Tables(0)
                If .Rows.Count > 0 Then
                    '互助金申請
                    '2017/01/18　修正開始
                    'num_KOYO_ROTIN.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOYO_ROTIN")))
                    'num_JIDAI.Value = CLng(WordHenkan("N", "Z", .Rows(0)("JIDAI")))
                    'num_GENKA_SYOKYAKU.Value = CLng(WordHenkan("N", "Z", .Rows(0)("GENKA_SYOKYAKU")))
                    'num_KUSYA_KIKAN.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KUSYA_KIKAN")))
                    'num_SONOTA_KOTEIHI.Value = CLng(WordHenkan("N", "Z", .Rows(0)("SONOTA_KOTEIHI")))
                    'num_KUNI_KOFU_KIN.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KUNI_KOFU_KIN")))
                    '小数点対応
                    If .Rows(0)("KOYO_ROTIN").ToString = "" Then
                        num_KOYO_ROTIN.Value = Nothing
                    Else
                        num_KOYO_ROTIN.Value = CDec(.Rows(0)("KOYO_ROTIN").ToString)
                    End If
                    If .Rows(0)("JIDAI").ToString = "" Then
                        num_JIDAI.Value = Nothing
                    Else
                        num_JIDAI.Value = CDec(.Rows(0)("JIDAI").ToString)
                    End If
                    If .Rows(0)("GENKA_SYOKYAKU").ToString = "" Then
                        num_GENKA_SYOKYAKU.Value = Nothing
                    Else
                        num_GENKA_SYOKYAKU.Value = CDec(.Rows(0)("GENKA_SYOKYAKU").ToString)
                    End If
                    If .Rows(0)("KUSYA_KIKAN").ToString = "" Then
                        num_KUSYA_KIKAN.Value = Nothing
                    Else
                        num_KUSYA_KIKAN.Value = CDec(.Rows(0)("KUSYA_KIKAN").ToString)
                    End If
                    If .Rows(0)("SONOTA_KOTEIHI").ToString = "" Then
                        num_SONOTA_KOTEIHI.Value = Nothing
                    Else
                        num_SONOTA_KOTEIHI.Value = CDec(.Rows(0)("SONOTA_KOTEIHI").ToString)
                    End If
                    If .Rows(0)("KUNI_KOFU_KIN").ToString = "" Then
                        num_KOME3_DISP2.Value = Nothing
                    Else
                        num_KOME3_DISP2.Value = CDec(.Rows(0)("KUNI_KOFU_KIN").ToString)
                    End If
                    '2017/01/18　修正終了

                    If .Rows(0)("KOFU_KAKUTEI_DATE") Is DBNull.Value Then
                        dateKOFU_KAKUTEI_Ymd.Value = Nothing
                    Else
                        dateKOFU_KAKUTEI_Ymd.Value = CDate(.Rows(0)("KOFU_KAKUTEI_DATE"))
                    End If

                    num_KOFU_TANKA.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_TANKA")))
                    num_KOFU_HASU.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_HASU")))
                    '2017/01/18　修正開始
                    'num_SEI_TUMITATE_KIN.Value = CLng(WordHenkan("N", "Z", .Rows(0)("SEI_TUMITATE_KIN")))
                    'num_SEI_TUMITATE_KIN2.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KUNI_KOFU_KIN")))
                    'num_KOFU_KIN.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_KIN")))
                    '2022/01/28 JBD9020 減額率交付率追加 UPD START
                    'If .Rows(0)("SEI_TUMITATE_KIN").ToString = "" Then
                    '    num_KOME3_CALC.Value = Nothing
                    'Else
                    '    num_KOME3_CALC.Value = CDec(.Rows(0)("SEI_TUMITATE_KIN").ToString)
                    'End If
                    'If .Rows(0)("SEI_TUMITATE_KIN").ToString = "" Then
                    '    num_MARU1.Value = Nothing
                    'Else
                    '    num_MARU1.Value = CDec(.Rows(0)("SEI_TUMITATE_KIN").ToString)
                    'End If
                    If .Rows(0)("SANTEI_KIN").ToString = "" Then
                        num_KOME1_CALC.Value = Nothing
                    Else
                        num_KOME1_CALC.Value = CDec(.Rows(0)("SANTEI_KIN").ToString)
                    End If
                    If .Rows(0)("GENGAKU_RITU").ToString = "" Then
                        num_GENGAKU_RITU.Value = Nothing
                    Else
                        num_GENGAKU_RITU.Value = CDec(.Rows(0)("GENGAKU_RITU").ToString)
                    End If
                    If .Rows(0)("KOFU_RITU").ToString = "" Then
                        num_KOFU_RITU.Value = Nothing
                    Else
                        num_KOFU_RITU.Value = CDbl(.Rows(0)("KOFU_RITU").ToString)
                    End If
                    If .Rows(0)("SEI_TUMITATE_KIN").ToString = "" Then
                        num_MARU1.Value = Nothing
                    Else
                        num_MARU1.Value = CDec(.Rows(0)("SEI_TUMITATE_KIN").ToString)
                    End If
                    '2022/01/28 JBD9020 減額率交付率追加 UPD END

                    If .Rows(0)("KUNI_KOFU_KIN").ToString = "" Then
                        num_MARU2.Value = Nothing
                    Else
                        num_MARU2.Value = CDec(.Rows(0)("KUNI_KOFU_KIN").ToString)
                    End If
                    If .Rows(0)("KOFU_KIN").ToString = "" Then
                        num_MARU3.Value = Nothing
                    Else
                        num_MARU3.Value = CDec(.Rows(0)("KOFU_KIN").ToString)
                    End If
                    '2017/01/18　修正終了

                    '交付金計算済の判定
                    If CLng(WordHenkan("N", "Z", .Rows(0)("SYORI_JOKYO_KBN"))) = 4 Then
                        lbl_SYORI_JOKYO_KBN_NM.Text = WordHenkan("N", "Z", .Rows(0)("SYORI_JOKYO_KBN_NM"))
                    Else
                        lbl_SYORI_JOKYO_KBN_NM.Text = ""
                        '処理状況オプションの設定
                        If CLng(WordHenkan("N", "Z", .Rows(0)("SYORI_JOKYO_KBN"))) = 1 Then
                            '入力中
                            rbtnSYORI_JOKYO_KBN_1.Checked = True
                            dateKOFU_KAKUTEI_Ymd.Enabled = False
                        ElseIf CLng(WordHenkan("N", "Z", .Rows(0)("SYORI_JOKYO_KBN"))) = 2 Then
                            '審査中
                            rbtnSYORI_JOKYO_KBN_2.Checked = True
                            dateKOFU_KAKUTEI_Ymd.Enabled = False
                        ElseIf CLng(WordHenkan("N", "Z", .Rows(0)("SYORI_JOKYO_KBN"))) = 3 Then
                            '交付確定
                            rbtnSYORI_JOKYO_KBN_3.Checked = True
                            dateKOFU_KAKUTEI_Ymd.Enabled = True
                        End If
                    End If
                End If
            End With

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            clsNENDO_KI = Nothing
        End Try

        Return ret

    End Function

#End Region

#Region "f_DtlInput_Enable 明細データ制御"
    '------------------------------------------------------------------
    'プロシージャ名  :f_DtlInput_Enable
    '説明            :明細データ制御
    '引数            :Boolean
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_DtlInput_Enable(ByVal wEnable As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            If wEnable Then
                num_KOYO_ROTIN.ReadOnly = False
                num_JIDAI.ReadOnly = False
                num_GENKA_SYOKYAKU.ReadOnly = False
                num_KUSYA_KIKAN.ReadOnly = False
                num_SONOTA_KOTEIHI.ReadOnly = False
                num_KOFU_HASU.ReadOnly = False
            Else
                num_KOYO_ROTIN.ReadOnly = True
                num_JIDAI.ReadOnly = True
                num_GENKA_SYOKYAKU.ReadOnly = True
                num_KUSYA_KIKAN.ReadOnly = True
                num_SONOTA_KOTEIHI.ReadOnly = True
                num_KOFU_HASU.ReadOnly = True

            End If

            'num_KOYO_ROTIN.Enabled = wEnable
            'num_JIDAI.Enabled = wEnable
            'num_GENKA_SYOKYAKU.Enabled = wEnable
            'num_KUSYA_KIKAN.Enabled = wEnable
            'num_SONOTA_KOTEIHI.Enabled = wEnable
            'num_KOFU_HASU.Enabled = wEnable

            rbtnSYORI_JOKYO_KBN_1.Enabled = wEnable
            rbtnSYORI_JOKYO_KBN_2.Enabled = wEnable
            rbtnSYORI_JOKYO_KBN_3.Enabled = wEnable
            dateKOFU_KAKUTEI_Ymd.Enabled = wEnable

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_DtlButton_Enable ボタン制御"
    '------------------------------------------------------------------
    'プロシージャ名  :f_DtlButton_Enable
    '説明            :明細ボタン制御
    '引数            :Boolean
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_DtlButton_Enable(ByVal wEnable As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            'ボタン
            cmdSave.Enabled = wEnable
            cmdCansel.Enabled = wEnable

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Input_Check  画面入力チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check
    '説明            :画面入力チェック処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check() As Boolean
        Dim ret As Boolean = False
        Dim wkControlName As String

        Try

            '==必須チェック==================
            wkControlName = "①雇用労賃の補正" & vbCrLf & "交付対象農場における1羽1ヶ月当たりの雇用労賃"
            If num_KOYO_ROTIN.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : num_KOYO_ROTIN.Focus() : Exit Try
            End If

            wkControlName = "②地代の補正" & vbCrLf & "交付対象農場における1羽1ヶ月当たりの地代"
            If num_JIDAI.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : num_JIDAI.Focus() : Exit Try
            End If

            wkControlName = "③減価償却の補正" & vbCrLf & "交付対象農場における1羽1ヶ月当たりの減価償却"
            If num_GENKA_SYOKYAKU.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : num_GENKA_SYOKYAKU.Focus() : Exit Try
            End If

            wkControlName = "④空舎期間の補正" & vbCrLf & "交付対象農場の可家畜導入計画における空舎期間"
            If num_KUSYA_KIKAN.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : num_KUSYA_KIKAN.Focus() : Exit Try
            End If

            wkControlName = "その他固定費"
            If num_SONOTA_KOTEIHI.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : num_SONOTA_KOTEIHI.Focus() : Exit Try
            End If

            wkControlName = "対象羽数(導入羽数等)"
            If num_KOFU_HASU.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : num_KOFU_HASU.Focus() : Exit Try
            End If

            '2022/02/01 JBD9020 減額率交付率追加 ADD START
            wkControlName = "家伝法違反減額率"
            If num_GENGAKU_RITU.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : num_GENGAKU_RITU.Focus() : Exit Try
            End If
            wkControlName = "互助金交付率"
            If num_KOFU_RITU.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : num_KOFU_RITU.Focus() : Exit Try
            End If
            '2022/02/01 JBD9020 減額率交付率追加 ADD END

            '==FromToチェック==================

            '==いろいろチェック==================
            '交付確定時の確定年月日チェック
            If rbtnSYORI_JOKYO_KBN_3.Checked Then
                wkControlName = "確定年月日"
                If dateKOFU_KAKUTEI_Ymd.Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : dateKOFU_KAKUTEI_Ymd.Focus() : Exit Try
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

#Region "f_MidB メソッド (文字列、開始位置、抽出文字数)　"
    ''' -----------------------------------------------------------------------------------------
    ''' <summary>
    '''     文字列の指定されたバイト位置から、指定されたバイト数分の文字列を返します。</summary>
    ''' <param name="stTarget">
    '''     取り出す元になる文字列。</param>
    ''' <param name="iStart">
    '''     取り出しを開始する位置。</param>
    ''' <param name="iByteSize">
    '''     取り出すバイト数。</param>
    ''' <returns>
    '''     指定されたバイト位置から指定されたバイト数分の文字列。</returns>
    ''' -----------------------------------------------------------------------------------------
    Public Function f_MidB _
    (ByVal stTarget As String, ByVal iStart As Integer, ByVal iByteSize As Integer) As String
        Dim hEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncoding.GetBytes(stTarget)

        Try
            If iStart <= btBytes.Length Then
                '開始位置から、抽出文字数の文字列を返します
                If iStart + iByteSize - 1 <= btBytes.Length Then
                    Return hEncoding.GetString(btBytes, iStart - 1, iByteSize)
                Else
                    Return hEncoding.GetString(btBytes, iStart - 1, btBytes.Length - iStart + 1)
                End If
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            Return ""
        End Try

    End Function
#End Region

#End Region

    Private Sub num_KEIEISIEN_SANTEI_1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num_KOME1HIKU2_CALC.ValueChanged

    End Sub

    Private Sub num_KOYO_HOSEI_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num_KOYO_HOSEI.ValueChanged

    End Sub


End Class
