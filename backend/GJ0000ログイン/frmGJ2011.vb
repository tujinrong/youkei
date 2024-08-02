'*******************************************************************************
'*　　①　フォーム名　　　  frmGJ2011.vb
'*
'*　　②　機能概要　　　　　契約者積立金・互助金単価マスタメンテナンス登録、変更
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

Public Class frmGJ2011

#Region "*** 変数定義 ***"
    Public pApName As String = "GJ2011"                 'プログラムＩＤ
    Public pRptName As String = "契約者積立金・互助金単価マスタ"          '帳票名
    Public pSyoriKbn As String = String.Empty           '処理区分
    Public pUKEIRE_YMDHMS As String = String.Empty      '処理開始時間
    Public pPCNAME As String = String.Empty             '端末ＩＤ
    Private pDataSet As New DataSet                     '検索結果一覧セット用データセット
    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ
    Private pErrDsp As Boolean                          'エラー表示有無

    Public Const C_INSERT As Integer = 0                '新規処理
    Public Const C_UPDATE As Integer = 1                '変更処理

    Public pSel_TAISYO_DATE_FROM As String = String.Empty        '変更時、初期表示番号
    Public pSel_UP_FLG As String = String.Empty         '変更時、初期表示番号
    Public pSel_SEQNO As String = String.Empty          '変更時、初期表示番号

    Public pSel_NO As Integer = 0                       '変更時、該当データ行番号

    Public paryKEY_2011 As New ArrayList

    Private pJump As Boolean = True                     '処理回避   2017/07/11　追加
    Private pToriNm As New List(Of String) From {"", "", "", "", "", "", "", "", "", "", "", ""}    '鶏の種類   2017/07/11　追加

#End Region


#Region "*** 画面制御関連 ***"
#Region "frmGJ2011_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ2011_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ2011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean = False

        Try

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '---------------------------------------------------
            '閉じるボタンを不可
            '---------------------------------------------------
            'Call ACoSubFormControlBoxSet(Me)

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            '2017/07/11　修正開始
            'Call f_FormClear("C")
            pJump = True
            f_ClearFormALL(Me, "C")
            pJump = False
            '2017/07/11　修正終了

            ''コンピュータ名取得
            'pPCNAME = System.Net.Dns.GetHostName

            '処理内容によって画面の初期状態をセット
            pErrDsp = False                     'エラー表示なし

            '鶏名称取得
            ret = f_ToriNm_Get()    '2017/07/11　追加

            '処理区分ごとの処理
            Select Case pSyoriKbn
                Case C_INSERT       '新規入力
                    '画面内容をセット
                    If Not f_SetForm_TM_TANKA1() Then
                        Exit Try
                    End If

                    '年月日FROMにフォーカスセット
                    dateTAISYO_DATE_Fm.Focus()

                Case C_UPDATE       '変更
                    '画面内容をセット
                    If Not f_SetForm_TM_TANKA2(pSel_TAISYO_DATE_FROM) Then
                        Exit Try
                    End If

                    ''行遷移
                    'lblTotal.Text = paryKEY_8041.Count
                    'txt_Now.Text = pSel_NO
                    ''行遷移ボタン制御
                    'Call s_Set_RecValidate()

                    'ユーザー名にフォーカスセット
                    'txt_USER_NAME.Focus()

            End Select

            pErrDsp = True                      'エラー表示あり
            pblnTextChange = False              '画面入力内容変更フラグ初期化


        Catch ex As Exception
            If ex.Message <> "Err" Then
                '共通例外処理
                Show_MessageBox("", ex.Message)
            End If

            'フォームクローズ
            Me.Close()
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#End Region

#Region "*** 画面ボタンクリック関連 ***"
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
            '入力項目チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '保存処理確認
            If Show_MessageBox("Q003", "") = DialogResult.No Then    '保存します。よろしいですか？
                'If Show_MessageBox("保存します。よろしいですか？", C_MSGICON_QUESTION) = DialogResult.Cancel Then    '保存します。よろしいですか？
                '「キャンセル」を選択
                Exit Try
            End If

            'データ保存
            If Not f_TM_TANKA_Save() Then
                Exit Try
            End If

            '保存あり
            DirectCast(Owner, frmGJ2010).pSaveFlg = True
            DirectCast(Owner, frmGJ2010).pSaveTAISYO_DATE_FROM = dateTAISYO_DATE_Fm.Value

            'フォームクローズ
            Me.Close()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdTop_Click 先頭行移動ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdTop_Click
    '説明            :先頭行移動ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sKENCD As String = String.Empty
        Dim sSEIRICD As String = String.Empty

        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
                    'If Show_MessageBox("データが変更されています。よろしいですか？", C_MSGICON_QUESTION) = DialogResult.No Then       'データが変更されています。よろしいですか？
                    '「いいえ」を選択
                    Exit Try
                End If
            End If

            ''行遷移処理
            'If Not f_RecValidating(0) Then
            '    Exit Try
            'End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region
#Region "cmdBef_Click 前行移動ボタンクリック処理"
    ''------------------------------------------------------------------
    ''プロシージャ名  :cmdBef_Click
    ''説明            :前行移動ボタンクリック処理
    ''------------------------------------------------------------------
    'Private Sub cmdBef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim sKENCD As String = String.Empty
    '    Dim sSEIRICD As String = String.Empty
    '    Dim intRecNo As Integer = 0
    '    Try
    '        'カーソルを砂時計にする
    '        Me.Cursor = Cursors.WaitCursor

    '        If pblnTextChange Then
    '            '画面に変更があり保存していない場合は、メッセージ表示
    '            If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
    '                'If Show_MessageBox("データが変更されています。よろしいですか？", C_MSGICON_QUESTION) = DialogResult.No Then       'データが変更されています。よろしいですか？
    '                '「いいえ」を選択
    '                Exit Try
    '            End If
    '        End If


    '        intRecNo = CInt(txt_Now.Text.TrimEnd) - 1

    '        '行遷移処理
    '        If Not f_RecValidating(intRecNo - 1) Then
    '            Exit Try
    '        End If

    '    Catch ex As Exception
    '        '共通例外処理
    '        Show_MessageBox("", ex.Message)
    '    Finally
    '        'カーソルを標準に戻す
    '        Me.Cursor = Cursors.Default
    '    End Try

    'End Sub
#End Region
#Region "cmdNext_Click 後行移動ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdNext_Click
    '説明            :後行移動ボタンクリック処理
    '------------------------------------------------------------------
    'Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim sKENCD As String = String.Empty
    '    Dim sSEIRICD As String = String.Empty
    '    Dim intRecNo As Integer = 0
    '    Try
    '        'カーソルを砂時計にする
    '        Me.Cursor = Cursors.WaitCursor

    '        If pblnTextChange Then
    '            '画面に変更があり保存していない場合は、メッセージ表示
    '            If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
    '                'If Show_MessageBox("データが変更されています。よろしいですか？", C_MSGICON_QUESTION) = DialogResult.No Then       'データが変更されています。よろしいですか？
    '                '「いいえ」を選択
    '                Exit Try
    '            End If
    '        End If

    '        intRecNo = CInt(txt_Now.Text.TrimEnd) + 1

    '        '行遷移処理
    '        If Not f_RecValidating(intRecNo - 1) Then
    '            Exit Try
    '        End If

    '    Catch ex As Exception
    '        '共通例外処理
    '        Show_MessageBox("", ex.Message)
    '    Finally
    '        'カーソルを標準に戻す
    '        Me.Cursor = Cursors.Default
    '    End Try

    'End Sub
#End Region
#Region "cmdLast_Click 最終行移動ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdLast_Click
    '説明            :最終行移動ボタンクリック処理
    '------------------------------------------------------------------
    'Private Sub cmdLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim sKENCD As String = String.Empty
    '    Dim sSEIRICD As String = String.Empty
    '    Dim intRecNo As Integer = 0
    '    Try
    '        'カーソルを砂時計にする
    '        Me.Cursor = Cursors.WaitCursor

    '        If pblnTextChange Then
    '            '画面に変更があり保存していない場合は、メッセージ表示
    '            If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
    '                'If Show_MessageBox("データが変更されています。よろしいですか？", C_MSGICON_QUESTION) = DialogResult.No Then       'データが変更されています。よろしいですか？
    '                '「いいえ」を選択
    '                Exit Try
    '            End If
    '        End If

    '        intRecNo = CInt(lblTotal.Text)

    '        '行遷移処理
    '        If Not f_RecValidating(intRecNo - 1) Then
    '            Exit Try
    '        End If

    '    Catch ex As Exception
    '        '共通例外処理
    '        Show_MessageBox("", ex.Message)
    '    Finally
    '        'カーソルを標準に戻す
    '        Me.Cursor = Cursors.Default
    '    End Try

    'End Sub
#End Region
#Region "txt_Now_Validating 現在行ﾃｷｽﾄﾎﾞｯｸｽ_Validatingｲﾍﾞﾝﾄ処理"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_Now_Validating
    '説明            :現在行ﾃｷｽﾄﾎﾞｯｸｽ_Validatingｲﾍﾞﾝﾄ処理
    '------------------------------------------------------------------
    'Private Sub txt_Now_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    Dim sKENCD As String = String.Empty
    '    Dim sSEIRICD As String = String.Empty
    '    Dim intRecNo As Integer = 0
    '    Try
    '        'カーソルを砂時計にする
    '        Me.Cursor = Cursors.WaitCursor

    '        If pblnTextChange Then
    '            '画面に変更があり保存していない場合は、メッセージ表示
    '            If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
    '                'If Show_MessageBox("データが変更されています。よろしいですか？", C_MSGICON_QUESTION) = DialogResult.No Then       'データが変更されています。よろしいですか？
    '                '「いいえ」を選択
    '                Exit Try
    '            End If
    '        End If

    '        intRecNo = CInt(txt_Now.Text.TrimEnd)

    '        '指定行＞最終行
    '        If CInt(txt_Now.Text.TrimEnd) > CInt(lblTotal.Text) Then
    '            txt_Now.Text = lblTotal.Text
    '            intRecNo = CInt(lblTotal.Text)
    '        End If
    '        '指定行＝空白　または　ＺＥＲＯ
    '        If txt_Now.Text.TrimEnd = "" Then
    '            txt_Now.Text = 1
    '            intRecNo = 1
    '        ElseIf CInt(txt_Now.Text.TrimEnd) = 0 Then
    '            txt_Now.Text = 1
    '            intRecNo = 1
    '        End If

    '        '行遷移処理
    '        If Not f_RecValidating(intRecNo - 1) Then
    '            Exit Try
    '        End If

    '    Catch ex As Exception
    '        '共通例外処理
    '        Show_MessageBox("", ex.Message)
    '    Finally
    '        'カーソルを標準に戻す
    '        Me.Cursor = Cursors.Default
    '    End Try


    'End Sub
#End Region
#Region "f_RecValidating 行遷移処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_RecValidating
    '説明            :行遷移処理
    '------------------------------------------------------------------
    'Private Function f_RecValidating(ByVal intRecNo As Integer) As Boolean
    '    Dim sUSER_ID As String = String.Empty
    '    Dim sUP_FLG As String = String.Empty
    '    Dim sSEQNO As String = String.Empty

    '    Dim ret As Boolean = False
    '    Try
    '        'KEY取得
    '        Dim tKEY As New frmGJ8040.T_KEY
    '        tKEY = paryKEY_8041.Item(intRecNo)

    '        sUSER_ID = tKEY.strUSER_ID.TrimEnd

    '        '画面に内容をセット()
    '        If Not f_SetForm_TM_USER2(sUSER_ID) Then
    '            Exit Try
    '        End If

    '        '行遷移ボタンの制御
    '        txt_Now.Text = CStr(intRecNo + 1)
    '        Call s_Set_RecValidate()

    '        '使用者名：有効にフォーカスセット
    '        txt_USER_NAME.Focus()

    '        pblnTextChange = False             '画面入力内容変更フラグ初期化

    '        ret = True

    '    Catch ex As Exception
    '        '共通例外処理
    '        Show_MessageBox("", ex.Message)
    '    Finally
    '        'カーソルを標準に戻す
    '        Me.Cursor = Cursors.Default
    '    End Try

    '    Return ret
    'End Function
#End Region

#Region "cmdEnd_Click 終了ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdEnd_Click
    '説明            :終了ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try

            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
                    'If Show_MessageBox("データが変更されています。よろしいですか？", C_MSGICON_QUESTION) = DialogResult.No Then       'データが変更されています。よろしいですか？
                    '「いいえ」を選択
                    Exit Try
                End If
            End If

            'フォームクローズ
            Me.AutoValidate = AutoValidate.Disable      '2010/10/16 ADD JBD200
            Me.Close()

            pblnTextChange = False      '画面入力内容変更フラグ初期化

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'フォームクローズ
            Me.AutoValidate = AutoValidate.Disable      '2010/10/16 ADD JBD200
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
    Private Sub s_FormControls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
             dateTAISYO_DATE_Fm.TextChanged,
             dateTAISYO_DATE_To.TextChanged,
             numTUMITATE_TANKA11.TextChanged,
             numKEIEISIEN_TANKA11.TextChanged,
             numSYOKYAKU_TANKA11.TextChanged,
             numTUMITATE_TANKA12.TextChanged,
             numKEIEISIEN_TANKA12.TextChanged,
             numSYOKYAKU_TANKA12.TextChanged,
             numTUMITATE_TANKA13.TextChanged,
             numKEIEISIEN_TANKA13.TextChanged,
             numSYOKYAKU_TANKA13.TextChanged,
             numTUMITATE_TANKA14.TextChanged,
             numKEIEISIEN_TANKA14.TextChanged,
             numSYOKYAKU_TANKA14.TextChanged,
             numTUMITATE_TANKA15.TextChanged,
             numKEIEISIEN_TANKA15.TextChanged,
             numSYOKYAKU_TANKA15.TextChanged,
             numTUMITATE_TANKA21.TextChanged,
             numKEIEISIEN_TANKA21.TextChanged,
             numSYOKYAKU_TANKA21.TextChanged,
             numTUMITATE_TANKA22.TextChanged,
             numKEIEISIEN_TANKA22.TextChanged,
             numSYOKYAKU_TANKA22.TextChanged,
             numTUMITATE_TANKA23.TextChanged,
             numKEIEISIEN_TANKA23.TextChanged,
             numSYOKYAKU_TANKA23.TextChanged,
             numTUMITATE_TANKA24.TextChanged,
             numKEIEISIEN_TANKA24.TextChanged,
             numSYOKYAKU_TANKA24.TextChanged,
             numTUMITATE_TANKA25.TextChanged,
             numKEIEISIEN_TANKA25.TextChanged,
             numSYOKYAKU_TANKA25.TextChanged,
             numTUMITATE_TANKA36.TextChanged,
             numKEIEISIEN_TANKA36.TextChanged,
             numSYOKYAKU_TANKA36.TextChanged,
             numTESURYO_RITU.TextChanged,
             numKOFU_RITU.TextChanged '2022/01/24 JBD9020 交付率追加 ADD

        pblnTextChange = True

    End Sub
#End Region
#Region "s_FormRadioButton_CheckedChanged 画面ﾗｼﾞｵﾎﾞﾀﾝCheckedChangedイベント"
    '    '------------------------------------------------------------------
    '    'プロシージャ名  :s_FormCheckBox_CheckedChanged
    '    '説明            :画面ﾗｼﾞｵﾎﾞﾀﾝCheckedChangedイベント
    '    '引数            :省略
    '    '戻り値          :省略
    '    '------------------------------------------------------------------
    '    Private Sub s_FormRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '        pblnTextChange = True

    '    End Sub

#End Region
#Region "s_FormCheckBox_CheckedChanged 画面ﾁｪｯｸﾎﾞｯｸｽCheckedChangedイベント"
    '    '------------------------------------------------------------------
    '    'プロシージャ名  :s_FormCheckBox_CheckedChanged
    '    '説明            :画面ﾁｪｯｸﾎﾞｯｸｽCheckedChangedイベント
    '    '引数            :省略
    '    '戻り値          :省略
    '    '------------------------------------------------------------------
    '    Private Sub s_FormCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_SankaCd.CheckedChanged, chk_Sanka_YMD.CheckedChanged, chk_SankaNm.CheckedChanged, _
    '                                                            chk_SankaNm_K.CheckedChanged, chk_POST.CheckedChanged, chk_Jusyo_K.CheckedChanged, chk_Jusyo.CheckedChanged, chk_Jusyo2.CheckedChanged, _
    '                                                            chk_TEL.CheckedChanged, chk_FAX.CheckedChanged, chk_BankCd.CheckedChanged, chk_BankMei.CheckedChanged, chk_BankShopCd.CheckedChanged, _
    '                                                            chk_BankShopMei.CheckedChanged, chk_BankYokinKbn.CheckedChanged, chk_BankYokinEtc.CheckedChanged, _
    '                                                            chk_BankKoza.CheckedChanged, chk_BankKozaNm_K.CheckedChanged, chk_BankKozaNm.CheckedChanged, chk_ItakuCd.CheckedChanged, _
    '                                                            chk_ItakuMei.CheckedChanged, chk_Jigyo.CheckedChanged, chk_Gosenen.CheckedChanged, chk_Marukin.CheckedChanged, _
    '                                                            chk_Marukin_Yotei.CheckedChanged, chk_StepTosu.CheckedChanged, chk_UpTosu.CheckedChanged, chk_Step.CheckedChanged, _
    '                                                            chk_Kanki.CheckedChanged, chk_Bousyo.CheckedChanged, chk_Kyuji.CheckedChanged, chk_Sikiryo.CheckedChanged, chk_Gaityu.CheckedChanged, _
    '                                                            chk_Syodoku.CheckedChanged, chk_Ecofeed.CheckedChanged, chk_Noujyo.CheckedChanged, chk_Jikyu.CheckedChanged, _
    '                                                            chk_Up.CheckedChanged, chk_Suisitu.CheckedChanged, chk_Syuki.CheckedChanged, chk_Syosyu.CheckedChanged, chk_Kujyo.CheckedChanged, _
    '                                                            chk_Senmon.CheckedChanged, chk_Taihi.CheckedChanged, chk_Kousi.CheckedChanged, chk_Jyakurei.CheckedChanged, _
    '                                                            chk_SoukiNiku.CheckedChanged, chk_SoukiKozatu.CheckedChanged, chk_Niku_KeiyakusyaNm.CheckedChanged, _
    '                                                            chk_Niku_KeiyakusyaNo.CheckedChanged, chk_Niku_ItakuCd.CheckedChanged, chk_Niku_ItakuNm.CheckedChanged, _
    '                                                            chk_Hiiku_SankasyaNm.CheckedChanged, chk_Hiiku_SeiriNo.CheckedChanged, chk_Hiiku_ItakuCd.CheckedChanged, chk_Hiiku_ItakuNm.CheckedChanged, _
    '                                                            chk_RecEr.CheckedChanged


    '        pblnTextChange = True

    '    End Sub

#End Region
#Region "s_FormNumber_CheckedChanged 画面数値型ｺﾝﾄﾛｰﾙCheckedChangedイベント"
    '    '------------------------------------------------------------------
    '    'プロシージャ名  :s_FormNumber_CheckedChanged
    '    '説明            :画面数値型ｺﾝﾄﾛｰﾙCheckedChangedイベント
    '    '引数            :省略
    '    '戻り値          :省略
    '    '------------------------------------------------------------------
    '    Private Sub s_FormNumber_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles num_StepNiku.TextChanged, num_StepKou.TextChanged, _
    '                                                            num_StepNyu.TextChanged, num_StepGokei.TextChanged, num_UpNiku.TextChanged, _
    '                                                            num_UpKou.TextChanged, num_UpNyu.TextChanged, num_UpGokei.TextChanged


    '        pblnTextChange = True

    '    End Sub

#End Region
#End Region

#Region "*** データ登録関連 ***"

#Region "f_ToriNm_Get 鶏名称取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ToriNm_Get
    '説明            :鶏名称取得
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '追加日          :2017/07/11
    '------------------------------------------------------------------
    Public Function f_ToriNm_Get() As Boolean
        Dim sSql As String = String.Empty
        Dim wDS As New DataSet
        Dim ret As Boolean = False
        Dim wIdx As Integer = 0

        Try

            sSql = " SELECT"
            sSql += "  MEISYO_CD, MEISYO"
            sSql += " FROM"
            sSql += "  TM_CODE"
            sSql += " WHERE SYURUI_KBN = 7"
            sSql += "   AND MEISYO_CD < 12"
            sSql += " ORDER BY"
            sSql += "  MEISYO_CD"

            Call f_Select_ODP(wDS, sSql)

            If wDS.Tables(0).Rows.Count > 0 Then
                For i = 0 To wDS.Tables(0).Rows.Count - 1
                    wIdx = CInt(wDS.Tables(0).Rows(i)("MEISYO_CD").ToString)
                    pToriNm(wIdx) = wDS.Tables(0).Rows(i)("MEISYO").ToString
                Next
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_SetForm_TM_TANKA1 契約者積立金・互助単価マスタデータ画面セット(新規)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TM_TANKA1
    '説明            :契約者積立金・互助単価マスタデータ画面セット(新規)
    '引数            :ユーザーID
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_TM_TANKA1() As Boolean

        Dim ret As Boolean = False

        Try

            ''行遷移ボタン表示制御
            's_Set_RecVisible(False)
            ''コントロール使用不可
            'txt_TEISI_RIYU.Enabled = False

            ''行遷移ボタン表示制御
            's_Set_RecVisible(False)

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_SetForm_TM_TANKA2 f_SetForm_TM_TANKA2画面セット(変更)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TM_TANKA2
    '説明            :契約者積立金・互助単価マスタデータ画面セット(変更)
    '引数            :年月日(FROM)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_TM_TANKA2(ByVal strTAISYO_DATE_FROM As String) As Boolean

        Dim sSql As String = String.Empty
        Dim dstDataSet As New DataSet
        Dim ret As Boolean = False

        Try

            sSql = " SELECT " & vbCrLf
            sSql += "  * " & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_TANKA" & vbCrLf
            sSql += " WHERE" & vbCrLf
            sSql += "  TAISYO_DATE_FROM = '" & strTAISYO_DATE_FROM.TrimEnd & "'" & vbCrLf


            Call f_Select_ODP(dstDataSet, sSql)

            If dstDataSet.Tables(0).Rows.Count > 0 Then
                '2017/07/11　修正開始
                'Call f_FormClear("")        '画面初期化
                pJump = True
                f_ClearFormALL(Me, "")
                pJump = False
                '2017/07/11　修正終了

                '画面にセット
                If Not f_SetForm_Data(dstDataSet) Then
                    Exit Try
                End If

                'コントロール使用不可
                dateTAISYO_DATE_Fm.Enabled = False

                ''行遷移ボタン表示制御
                's_Set_RecVisible(False)

            Else
                'データ未存在
                Show_MessageBox("I003", "")       '指定された条件に一致するデータは存在しません。
                'Show_MessageBox("指定された条件に一致するデータは存在しません。", C_MSGICON_INFORMATION)
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

#Region "f_TM_TANKA_Save 契約者積立金・互助単価マスタデータ更新"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_TANKA_Save
    '説明            :契約者積立金・互助単価マスタデータ更新
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_TANKA_Save() As Boolean
        Dim ret As Boolean = False
        Dim dtNow As Date = Now()
        Dim wNo As Integer = 0

        Try

            '2017/07/11　修正開始
            ''家族型-採卵鶏(成鶏)
            'If Not f_TM_TANKA_Save_Pro(11, dtNow) Then
            '    Return ret
            'End If
            ''家族型-採卵鶏(育成鶏)
            'If Not f_TM_TANKA_Save_Pro(12, dtNow) Then
            '    Return ret
            'End If
            ''家族型-肉用鶏
            'If Not f_TM_TANKA_Save_Pro(13, dtNow) Then
            '    Return ret
            'End If
            ''家族型-種鶏(成鶏)
            'If Not f_TM_TANKA_Save_Pro(14, dtNow) Then
            '    Return ret
            'End If
            ''家族型-種鶏(育成鶏)
            'If Not f_TM_TANKA_Save_Pro(15, dtNow) Then
            '    Return ret
            'End If
            ''家族型-うずら
            'If Not f_TM_TANKA_Save_Pro(16, dtNow) Then
            '    Return ret
            'End If
            '家族型-1:採卵鶏(成鶏)～11:だちょう
            For i = 1 To 11
                wNo = 100 + i
                If Not f_TM_TANKA_Save_Pro(wNo, dtNow) Then
                    Return ret
                End If
            Next
            '2017/07/11　修正終了


            '2017/07/11　修正開始
            ''企業型-採卵鶏(成鶏)
            'If Not f_TM_TANKA_Save_Pro(21, dtNow) Then
            '    Return ret
            'End If
            ''企業型-採卵鶏(育成鶏)
            'If Not f_TM_TANKA_Save_Pro(22, dtNow) Then
            '    Return ret
            'End If
            ''企業型-肉用鶏
            'If Not f_TM_TANKA_Save_Pro(23, dtNow) Then
            '    Return ret
            'End If
            ''企業型-種鶏(成鶏)
            'If Not f_TM_TANKA_Save_Pro(24, dtNow) Then
            '    Return ret
            'End If
            ''企業型-種鶏(育成鶏)
            'If Not f_TM_TANKA_Save_Pro(25, dtNow) Then
            '    Return ret
            'End If
            ''企業型-うずら
            'If Not f_TM_TANKA_Save_Pro(26, dtNow) Then
            '    Return ret
            'End If
            '企業型--1:採卵鶏(成鶏)～11:だちょう～11:だちょう
            For i = 1 To 11
                wNo = 200 + i
                If Not f_TM_TANKA_Save_Pro(wNo, dtNow) Then
                    Return ret
                End If
            Next
            '2017/07/11　修正終了

            '2017/07/11　修正開始
            ''うずら-うずら
            'If Not f_TM_TANKA_Save_Pro(36, dtNow) Then
            '    Return ret
            'End If
            '鶏以外-6:うずら～11:だちょう
            For i = 6 To 11
                wNo = 300 + i
                If Not f_TM_TANKA_Save_Pro(wNo, dtNow) Then
                    Return ret
                End If
            Next
            '2017/07/11　修正終了

            '手数料率
            If Not f_TM_TANKA_Save_Pro(99, dtNow) Then
                Return ret
            End If


            ret = True

        Catch ex As Exception
            '共通例外処理
            If ex.Message <> "Err" Then
                Show_MessageBox("", ex.Message)
            End If
        End Try

        Return ret


    End Function
#End Region

#Region "f_TM_TANKA_Save_Pro 単価マスタデータ登録処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_TANKA_Save_Pro
    '説明            :単価マスタデータ登録処理
    '引数            :区分
    '引数            :日付
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_TANKA_Save_Pro(ByVal kbn As Integer, ByVal dtNow As Date) As Boolean
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False
        Dim wMsgTitle As String = String.Empty
        Dim wNo As Integer = 0

        Try
            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Select Case pSyoriKbn
                Case C_INSERT       '新規入力
                    wMsgTitle = "新規登録"
                    Cmd.CommandText = "PKG_GJ2011.GJ2011_TANKA_INS"
                Case C_UPDATE       '変更
                    wMsgTitle = "変更"
                    Cmd.CommandText = "PKG_GJ2011.GJ2011_TANKA_UPD"
            End Select



            '引き渡し
            '年月日FROM
            Dim paraTAISYO_DATE_FROM As OracleParameter = Cmd.Parameters.Add("IN_TAISYO_DATE_FROM", Format(dateTAISYO_DATE_Fm.Value, "yyyy/MM/dd"))
            '年月日TO
            Dim paraTAISYO_DATE_TO As OracleParameter = Cmd.Parameters.Add("IN_TAISYO_DATE_TO", Format(dateTAISYO_DATE_To.Value, "yyyy/MM/dd"))

            '2017/07/11　修正開始
            ''家族型-採卵鶏(成鶏)
            'If kbn = 11 Then
            '    '契約区分
            '    Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 1)
            '    '鳥の種類
            '    Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 1)

            '    '契約者積立金-単価
            '    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", IIf(numTUMITATE_TANKA11.Value Is Nothing, 0, numTUMITATE_TANKA11.Value))
            '    '経営支援互助金-単価
            '    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", IIf(numKEIEISIEN_TANKA11.Value Is Nothing, 0, numKEIEISIEN_TANKA11.Value))
            '    '焼却・埋却等互助金-単価
            '    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", IIf(numSYOKYAKU_TANKA11.Value Is Nothing, 0, numSYOKYAKU_TANKA11.Value))
            '    '手数料率
            '    Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", DBNull.Value)
            'End If

            ''家族型-採卵鶏(育成鶏)
            'If kbn = 12 Then
            '    '契約区分
            '    Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 1)
            '    '鳥の種類
            '    Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 2)

            '    '契約者積立金-単価
            '    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", IIf(numTUMITATE_TANKA12.Value Is Nothing, 0, numTUMITATE_TANKA12.Value))
            '    '経営支援互助金-単価
            '    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", IIf(numKEIEISIEN_TANKA12.Value Is Nothing, 0, numKEIEISIEN_TANKA12.Value))
            '    '焼却・埋却等互助金-単価
            '    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", IIf(numSYOKYAKU_TANKA12.Value Is Nothing, 0, numSYOKYAKU_TANKA12.Value))
            '    '手数料率
            '    Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", DBNull.Value)
            'End If

            ''家族型-肉用鶏
            'If kbn = 13 Then
            '    '契約区分
            '    Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 1)
            '    '鳥の種類
            '    Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 3)

            '    '契約者積立金-単価
            '    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", IIf(numTUMITATE_TANKA13.Value Is Nothing, 0, numTUMITATE_TANKA13.Value))
            '    '経営支援互助金-単価
            '    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", IIf(numKEIEISIEN_TANKA13.Value Is Nothing, 0, numKEIEISIEN_TANKA13.Value))
            '    '焼却・埋却等互助金-単価
            '    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", IIf(numSYOKYAKU_TANKA13.Value Is Nothing, 0, numSYOKYAKU_TANKA13.Value))
            '    '手数料率
            '    Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", DBNull.Value)
            'End If

            ''家族型-種鶏(成鶏)
            'If kbn = 14 Then
            '    '契約区分
            '    Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 1)
            '    '鳥の種類
            '    Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 4)

            '    '契約者積立金-単価
            '    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", IIf(numTUMITATE_TANKA14.Value Is Nothing, 0, numTUMITATE_TANKA14.Value))
            '    '経営支援互助金-単価
            '    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", IIf(numKEIEISIEN_TANKA14.Value Is Nothing, 0, numKEIEISIEN_TANKA14.Value))
            '    '焼却・埋却等互助金-単価
            '    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", IIf(numSYOKYAKU_TANKA14.Value Is Nothing, 0, numSYOKYAKU_TANKA14.Value))
            '    '手数料率
            '    Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", DBNull.Value)
            'End If

            ''家族型-種鶏(育成鶏)
            'If kbn = 15 Then
            '    '契約区分
            '    Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 1)
            '    '鳥の種類
            '    Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 5)

            '    '契約者積立金-単価
            '    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", IIf(numTUMITATE_TANKA15.Value Is Nothing, 0, numTUMITATE_TANKA15.Value))
            '    '経営支援互助金-単価
            '    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", IIf(numKEIEISIEN_TANKA15.Value Is Nothing, 0, numKEIEISIEN_TANKA15.Value))
            '    '焼却・埋却等互助金-単価
            '    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", IIf(numSYOKYAKU_TANKA15.Value Is Nothing, 0, numSYOKYAKU_TANKA15.Value))
            '    '手数料率
            '    Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", DBNull.Value)
            'End If

            ''家族型-うずら
            'If kbn = 16 Then
            '    '契約区分
            '    Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 1)
            '    '鳥の種類
            '    Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 6)

            '    '契約者積立金-単価
            '    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", IIf(numTUMITATE_TANKA36.Value Is Nothing, 0, numTUMITATE_TANKA36.Value))
            '    '経営支援互助金-単価
            '    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", IIf(numKEIEISIEN_TANKA36.Value Is Nothing, 0, numKEIEISIEN_TANKA36.Value))
            '    '焼却・埋却等互助金-単価
            '    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", IIf(numSYOKYAKU_TANKA36.Value Is Nothing, 0, numSYOKYAKU_TANKA36.Value))
            '    '手数料率
            '    Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", DBNull.Value)
            'End If


            ''企業型-採卵鶏(成鶏)
            'If kbn = 21 Then
            '    '契約区分
            '    Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 2)
            '    '鳥の種類
            '    Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 1)

            '    '契約者積立金-単価
            '    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", IIf(numTUMITATE_TANKA21.Value Is Nothing, 0, numTUMITATE_TANKA21.Value))
            '    '経営支援互助金-単価
            '    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", IIf(numKEIEISIEN_TANKA21.Value Is Nothing, 0, numKEIEISIEN_TANKA21.Value))
            '    '焼却・埋却等互助金-単価
            '    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", IIf(numSYOKYAKU_TANKA21.Value Is Nothing, 0, numSYOKYAKU_TANKA21.Value))
            '    '手数料率
            '    Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", DBNull.Value)
            'End If


            ''企業型-採卵鶏(育成鶏)
            'If kbn = 22 Then
            '    '契約区分
            '    Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 2)
            '    '鳥の種類
            '    Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 2)

            '    '契約者積立金-単価
            '    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", IIf(numTUMITATE_TANKA22.Value Is Nothing, 0, numTUMITATE_TANKA22.Value))
            '    '経営支援互助金-単価
            '    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", IIf(numKEIEISIEN_TANKA22.Value Is Nothing, 0, numKEIEISIEN_TANKA22.Value))
            '    '焼却・埋却等互助金-単価
            '    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", IIf(numSYOKYAKU_TANKA22.Value Is Nothing, 0, numSYOKYAKU_TANKA22.Value))
            '    '手数料率
            '    Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", DBNull.Value)
            'End If

            ''企業型-肉用鶏
            'If kbn = 23 Then
            '    '契約区分
            '    Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 2)
            '    '鳥の種類
            '    Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 3)

            '    '契約者積立金-単価
            '    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", IIf(numTUMITATE_TANKA23.Value Is Nothing, 0, numTUMITATE_TANKA23.Value))
            '    '経営支援互助金-単価
            '    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", IIf(numKEIEISIEN_TANKA23.Value Is Nothing, 0, numKEIEISIEN_TANKA23.Value))
            '    '焼却・埋却等互助金-単価
            '    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", IIf(numSYOKYAKU_TANKA23.Value Is Nothing, 0, numSYOKYAKU_TANKA23.Value))
            '    '手数料率
            '    Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", DBNull.Value)
            'End If

            ''企業型-種鶏(成鶏)
            'If kbn = 24 Then
            '    '契約区分
            '    Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 2)
            '    '鳥の種類
            '    Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 4)

            '    '契約者積立金-単価
            '    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", IIf(numTUMITATE_TANKA24.Value Is Nothing, 0, numTUMITATE_TANKA24.Value))
            '    '経営支援互助金-単価
            '    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", IIf(numKEIEISIEN_TANKA24.Value Is Nothing, 0, numKEIEISIEN_TANKA24.Value))
            '    '焼却・埋却等互助金-単価
            '    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", IIf(numSYOKYAKU_TANKA24.Value Is Nothing, 0, numSYOKYAKU_TANKA24.Value))
            '    '手数料率
            '    Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", DBNull.Value)
            'End If

            ''企業型-種鶏(育成鶏)
            'If kbn = 25 Then
            '    '契約区分
            '    Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 2)
            '    '鳥の種類
            '    Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 5)

            '    '契約者積立金-単価
            '    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", IIf(numTUMITATE_TANKA25.Value Is Nothing, 0, numTUMITATE_TANKA25.Value))
            '    '経営支援互助金-単価
            '    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", IIf(numKEIEISIEN_TANKA25.Value Is Nothing, 0, numKEIEISIEN_TANKA25.Value))
            '    '焼却・埋却等互助金-単価
            '    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", IIf(numSYOKYAKU_TANKA25.Value Is Nothing, 0, numSYOKYAKU_TANKA25.Value))
            '    '手数料率
            '    Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", DBNull.Value)
            'End If

            ''企業型-うずら
            'If kbn = 26 Then
            '    '契約区分
            '    Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 2)
            '    '鳥の種類
            '    Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 6)

            '    '契約者積立金-単価
            '    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", IIf(numTUMITATE_TANKA36.Value Is Nothing, 0, numTUMITATE_TANKA36.Value))
            '    '経営支援互助金-単価
            '    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", IIf(numKEIEISIEN_TANKA36.Value Is Nothing, 0, numKEIEISIEN_TANKA36.Value))
            '    '焼却・埋却等互助金-単価
            '    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", IIf(numSYOKYAKU_TANKA36.Value Is Nothing, 0, numSYOKYAKU_TANKA36.Value))
            '    '手数料率
            '    Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", DBNull.Value)
            'End If

            ''うずら-うずら
            'If kbn = 36 Then
            '    '契約区分
            '    Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 3)
            '    '鳥の種類
            '    Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 6)

            '    '契約者積立金-単価
            '    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", IIf(numTUMITATE_TANKA36.Value Is Nothing, 0, numTUMITATE_TANKA36.Value))
            '    '経営支援互助金-単価
            '    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", IIf(numKEIEISIEN_TANKA36.Value Is Nothing, 0, numKEIEISIEN_TANKA36.Value))
            '    '焼却・埋却等互助金-単価
            '    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", IIf(numSYOKYAKU_TANKA36.Value Is Nothing, 0, numSYOKYAKU_TANKA36.Value))
            '    '手数料率
            '    Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", DBNull.Value)
            'End If


            'うずら-6:うずら～11:ダチョウ
            If kbn <> 99 Then

                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", CInt(kbn.ToString.Substring(0, 1)))
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", CInt(kbn.ToString.Substring(1, 2)))

                '項目番号
                If CInt(kbn.ToString.Substring(1, 2)) > 5 Then
                    '6:うずら～11:ダチョウ
                    wNo = 30 + CInt(kbn.ToString.Substring(1, 2))
                Else
                    '1:採卵鶏(成鶏)～5:種鶏(育成鶏)
                    wNo = CInt(kbn.ToString.Substring(0, 1)) * 10 + CInt(kbn.ToString.Substring(1, 2))
                End If


                '契約者積立金-単価
                If DirectCast(Me.Controls("numTUMITATE_TANKA" & wNo.ToString), JBD.Gjs.Win.GcNumber).Value Is Nothing Then
                    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", 0)
                Else
                    Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", DirectCast(Me.Controls("numTUMITATE_TANKA" & wNo.ToString), JBD.Gjs.Win.GcNumber).Value)
                End If

                '経営支援互助金-単価
                If DirectCast(Me.Controls("numKEIEISIEN_TANKA" & wNo.ToString), JBD.Gjs.Win.GcNumber).Value Is Nothing Then
                    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", 0)
                Else
                    Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", DirectCast(Me.Controls("numKEIEISIEN_TANKA" & wNo.ToString), JBD.Gjs.Win.GcNumber).Value)
                End If

                '焼却・埋却等互助金-単価
                If DirectCast(Me.Controls("numSYOKYAKU_TANKA" & wNo.ToString), JBD.Gjs.Win.GcNumber).Value Is Nothing Then
                    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", 0)
                Else
                    Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", DirectCast(Me.Controls("numSYOKYAKU_TANKA" & wNo.ToString), JBD.Gjs.Win.GcNumber).Value)
                End If

                '手数料率
                Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", DBNull.Value)

                '2022/01/24 JBD9020 交付率追加 ADD START
                '交付率
                Dim paraKOFU_RITU As OracleParameter = Cmd.Parameters.Add("IN_KOFU_RITU", DBNull.Value)
                '2022/01/24 JBD9020 交付率追加 ADD END

            End If
            '2017/07/11　修正終了

            '手数料率
            If kbn = 99 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 9)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 9)

                '契約者積立金-単価
                Dim paraTUMITATE_TANKA As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_TANKA", DBNull.Value)
                '経営支援互助金-単価
                Dim paraKEIEISIEN_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KEIEISIEN_TANKA", DBNull.Value)
                '焼却・埋却等互助金-単価
                Dim paraSYOKYAKU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_TANKA", DBNull.Value)
                '手数料率
                Dim paraTESURYO_RITU As OracleParameter = Cmd.Parameters.Add("IN_TESURYO_RITU", IIf(numTESURYO_RITU.Value Is Nothing, 0, numTESURYO_RITU.Value))
                '2022/01/24 JBD9020 交付率追加 ADD START
                '手数料率
                Dim paraKOFU_RITU As OracleParameter = Cmd.Parameters.Add("IN_KOFU_RITU", IIf(numKOFU_RITU.Value Is Nothing, 0, numKOFU_RITU.Value))
                '2022/01/24 JBD9020 交付率追加 ADD END
            End If

            'データ登録日
            Dim paraREG_DATE As OracleParameter = Cmd.Parameters.Add("IN_REG_DATE", Now)
            'データ登録ＩＤ
            Dim paraREG_ID As OracleParameter = Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
            'データ更新日
            Dim paraUP_DATE As OracleParameter = Cmd.Parameters.Add("IN_UP_DATE", Now)
            'データ更新ＩＤ
            Dim paraUP_ID As OracleParameter = Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            'コンピュータ名
            Dim paraCOM_NAME As OracleParameter = Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()

            If p_MSGCD.Value.ToString = "0" Then
                '正常
            Else
                Show_MessageBox("", p_MSGNM.Value.ToString)
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            If ex.Message <> "Err" Then
                Show_MessageBox("", ex.Message)
            End If
        Finally
            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
        End Try

        Return ret

    End Function
#End Region




#End Region


#Region "*** ローカル関数 ***"


#Region "f_TANKA_Exist_Check 契約者積立金・互助単価マスタデータ存在チェック"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TANKA_Exist_Check
    '説明            :契約者積立金・互助単価マスタデータ存在チェック
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_TANKA_Exist_Check() As Boolean

        Dim sSql As String = String.Empty
        Dim dstDataSet As New DataSet
        Dim strTAISYO_DATE_FROM As String = String.Empty
        Dim ret As Boolean = False

        Try
            strTAISYO_DATE_FROM = dateTAISYO_DATE_Fm.Value

            sSql = ""
            sSql = " SELECT " & vbCrLf
            sSql += "  * " & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_TANKA" & vbCrLf
            sSql += " WHERE" & vbCrLf
            sSql += "      TAISYO_DATE_FROM <= '" & Format(dateTAISYO_DATE_Fm.Value, "yyyy/MM/dd") & "'" & vbCrLf
            sSql += "  AND TAISYO_DATE_TO   >= '" & Format(dateTAISYO_DATE_Fm.Value, "yyyy/MM/dd") & "'" & vbCrLf


            Call f_Select_ODP(dstDataSet, sSql)

            If dstDataSet.Tables(0).Rows.Count > 0 Then
                'データ未存在
                Show_MessageBox("W001", "")    'データは既に登録されています。
                Exit Try
            End If

            '#33 ADD START
            sSql = ""
            sSql = " SELECT " & vbCrLf
            sSql += "  * " & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_TANKA" & vbCrLf
            sSql += " WHERE" & vbCrLf
            sSql += "      TAISYO_DATE_FROM <= '" & Format(dateTAISYO_DATE_To.Value, "yyyy/MM/dd") & "'" & vbCrLf
            sSql += "  AND TAISYO_DATE_TO   >= '" & Format(dateTAISYO_DATE_To.Value, "yyyy/MM/dd") & "'" & vbCrLf


            Call f_Select_ODP(dstDataSet, sSql)

            If dstDataSet.Tables(0).Rows.Count > 0 Then
                'データ未存在
                Show_MessageBox("W001", "")    'データは既に登録されています。
                Exit Try
            End If
            '#33 ADD END


            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_SetForm_Data 契約者積立金・互助単価マスタデータ画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_Data
    '説明            :契約者積立金・互助単価マスタデータ画面セット
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_Data(ByVal dstDataSet As DataSet) As Boolean
        Dim ret As Boolean = False
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim wNo As Integer = 0

        Try

            '結果数文繰返す
            For i As Integer = 0 To dstDataSet.Tables(0).Rows.Count - 1
                With dstDataSet.Tables(0)

                    '年月日FROM
                    If Not IsDBNull(.Rows(0)("TAISYO_DATE_FROM")) Then
                        dateTAISYO_DATE_Fm.Value = .Rows(0)("TAISYO_DATE_FROM")
                    Else
                        dateTAISYO_DATE_Fm.Value = Nothing
                    End If

                    '年月日TO
                    If Not IsDBNull(.Rows(0)("TAISYO_DATE_TO")) Then
                        dateTAISYO_DATE_To.Value = .Rows(0)("TAISYO_DATE_TO")
                    Else
                        dateTAISYO_DATE_To.Value = Nothing
                    End If


                    '家族型-採卵鶏(成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 1 And .Rows(i)("TORI_KBN") = 1 Then
                        If Not IsDBNull(.Rows(i)("TUMITATE_TANKA")) Then
                            numTUMITATE_TANKA11.Value = CDec(WordHenkan("N", "S", .Rows(i)("TUMITATE_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("KEIEISIEN_TANKA")) Then
                            numKEIEISIEN_TANKA11.Value = CDec(WordHenkan("N", "S", .Rows(i)("KEIEISIEN_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("SYOKYAKU_TANKA")) Then
                            numSYOKYAKU_TANKA11.Value = CDec(WordHenkan("N", "S", .Rows(i)("SYOKYAKU_TANKA")))
                        End If
                    End If

                    '家族型-採卵鶏(育成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 1 And .Rows(i)("TORI_KBN") = 2 Then
                        If Not IsDBNull(.Rows(i)("TUMITATE_TANKA")) Then
                            numTUMITATE_TANKA12.Value = CDec(WordHenkan("N", "S", .Rows(i)("TUMITATE_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("KEIEISIEN_TANKA")) Then
                            numKEIEISIEN_TANKA12.Value = CDec(WordHenkan("N", "S", .Rows(i)("KEIEISIEN_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("SYOKYAKU_TANKA")) Then
                            numSYOKYAKU_TANKA12.Value = CDec(WordHenkan("N", "S", .Rows(i)("SYOKYAKU_TANKA")))
                        End If
                    End If

                    '家族型-肉用鶏
                    If .Rows(i)("KEIYAKU_KBN") = 1 And .Rows(i)("TORI_KBN") = 3 Then
                        If Not IsDBNull(.Rows(i)("TUMITATE_TANKA")) Then
                            numTUMITATE_TANKA13.Value = CDec(WordHenkan("N", "S", .Rows(i)("TUMITATE_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("KEIEISIEN_TANKA")) Then
                            numKEIEISIEN_TANKA13.Value = CDec(WordHenkan("N", "S", .Rows(i)("KEIEISIEN_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("SYOKYAKU_TANKA")) Then
                            numSYOKYAKU_TANKA13.Value = CDec(WordHenkan("N", "S", .Rows(i)("SYOKYAKU_TANKA")))
                        End If
                    End If

                    '家族型-種鶏(成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 1 And .Rows(i)("TORI_KBN") = 4 Then
                        If Not IsDBNull(.Rows(i)("TUMITATE_TANKA")) Then
                            numTUMITATE_TANKA14.Value = CDec(WordHenkan("N", "S", .Rows(i)("TUMITATE_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("KEIEISIEN_TANKA")) Then
                            numKEIEISIEN_TANKA14.Value = CDec(WordHenkan("N", "S", .Rows(i)("KEIEISIEN_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("SYOKYAKU_TANKA")) Then
                            numSYOKYAKU_TANKA14.Value = CDec(WordHenkan("N", "S", .Rows(i)("SYOKYAKU_TANKA")))
                        End If
                    End If

                    '家族型-種鶏(育成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 1 And .Rows(i)("TORI_KBN") = 5 Then
                        If Not IsDBNull(.Rows(i)("TUMITATE_TANKA")) Then
                            numTUMITATE_TANKA15.Value = CDec(WordHenkan("N", "S", .Rows(i)("TUMITATE_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("KEIEISIEN_TANKA")) Then
                            numKEIEISIEN_TANKA15.Value = CDec(WordHenkan("N", "S", .Rows(i)("KEIEISIEN_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("SYOKYAKU_TANKA")) Then
                            numSYOKYAKU_TANKA15.Value = CDec(WordHenkan("N", "S", .Rows(i)("SYOKYAKU_TANKA")))
                        End If
                    End If

                    '企業型-採卵鶏(成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 2 And .Rows(i)("TORI_KBN") = 1 Then
                        If Not IsDBNull(.Rows(i)("TUMITATE_TANKA")) Then
                            numTUMITATE_TANKA21.Value = CDec(WordHenkan("N", "S", .Rows(i)("TUMITATE_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("KEIEISIEN_TANKA")) Then
                            numKEIEISIEN_TANKA21.Value = CDec(WordHenkan("N", "S", .Rows(i)("KEIEISIEN_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("SYOKYAKU_TANKA")) Then
                            numSYOKYAKU_TANKA21.Value = CDec(WordHenkan("N", "S", .Rows(i)("SYOKYAKU_TANKA")))
                        End If
                    End If

                    '企業型-採卵鶏(育成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 2 And .Rows(i)("TORI_KBN") = 2 Then
                        If Not IsDBNull(.Rows(i)("TUMITATE_TANKA")) Then
                            numTUMITATE_TANKA22.Value = CDec(WordHenkan("N", "S", .Rows(i)("TUMITATE_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("KEIEISIEN_TANKA")) Then
                            numKEIEISIEN_TANKA22.Value = CDec(WordHenkan("N", "S", .Rows(i)("KEIEISIEN_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("SYOKYAKU_TANKA")) Then
                            numSYOKYAKU_TANKA22.Value = CDec(WordHenkan("N", "S", .Rows(i)("SYOKYAKU_TANKA")))
                        End If
                    End If

                    '企業型-肉用鶏
                    If .Rows(i)("KEIYAKU_KBN") = 2 And .Rows(i)("TORI_KBN") = 3 Then
                        If Not IsDBNull(.Rows(i)("TUMITATE_TANKA")) Then
                            numTUMITATE_TANKA23.Value = CDec(WordHenkan("N", "S", .Rows(i)("TUMITATE_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("KEIEISIEN_TANKA")) Then
                            numKEIEISIEN_TANKA23.Value = CDec(WordHenkan("N", "S", .Rows(i)("KEIEISIEN_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("SYOKYAKU_TANKA")) Then
                            numSYOKYAKU_TANKA23.Value = CDec(WordHenkan("N", "S", .Rows(i)("SYOKYAKU_TANKA")))
                        End If
                    End If


                    '企業型-種鶏(成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 2 And .Rows(i)("TORI_KBN") = 4 Then
                        If Not IsDBNull(.Rows(i)("TUMITATE_TANKA")) Then
                            numTUMITATE_TANKA24.Value = CDec(WordHenkan("N", "S", .Rows(i)("TUMITATE_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("KEIEISIEN_TANKA")) Then
                            numKEIEISIEN_TANKA24.Value = CDec(WordHenkan("N", "S", .Rows(i)("KEIEISIEN_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("SYOKYAKU_TANKA")) Then
                            numSYOKYAKU_TANKA24.Value = CDec(WordHenkan("N", "S", .Rows(i)("SYOKYAKU_TANKA")))
                        End If
                    End If

                    '企業型-種鶏(育成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 2 And .Rows(i)("TORI_KBN") = 5 Then
                        If Not IsDBNull(.Rows(i)("TUMITATE_TANKA")) Then
                            numTUMITATE_TANKA25.Value = CDec(WordHenkan("N", "S", .Rows(i)("TUMITATE_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("KEIEISIEN_TANKA")) Then
                            numKEIEISIEN_TANKA25.Value = CDec(WordHenkan("N", "S", .Rows(i)("KEIEISIEN_TANKA")))
                        End If
                        If Not IsDBNull(.Rows(i)("SYOKYAKU_TANKA")) Then
                            numSYOKYAKU_TANKA25.Value = CDec(WordHenkan("N", "S", .Rows(i)("SYOKYAKU_TANKA")))
                        End If
                    End If

                    '2017/07/11　修正開始
                    ''うずら-うずら
                    'If .Rows(i)("KEIYAKU_KBN") = 3 And .Rows(i)("TORI_KBN") = 6 Then
                    '    If Not IsDBNull(.Rows(i)("TUMITATE_TANKA")) Then
                    '        numTUMITATE_TANKA36.Value = CDec(WordHenkan("N", "S", .Rows(i)("TUMITATE_TANKA")))
                    '    End If
                    '    If Not IsDBNull(.Rows(i)("KEIEISIEN_TANKA")) Then
                    '        numKEIEISIEN_TANKA36.Value = CDec(WordHenkan("N", "S", .Rows(i)("KEIEISIEN_TANKA")))
                    '    End If
                    '    If Not IsDBNull(.Rows(i)("SYOKYAKU_TANKA")) Then
                    '        numSYOKYAKU_TANKA36.Value = CDec(WordHenkan("N", "S", .Rows(i)("SYOKYAKU_TANKA")))
                    '    End If
                    'End If

                    '鶏以外-6:うずら～11:だちょう
                    If .Rows(i)("KEIYAKU_KBN") = "3" AndAlso
                        CInt(.Rows(i)("TORI_KBN")) > 5 AndAlso CInt(.Rows(i)("TORI_KBN")) < 12 Then
                        '項目番号
                        wNo = 30 + CInt(.Rows(i)("TORI_KBN").ToString)
                        '契約者積立金
                        If Not IsDBNull(.Rows(i)("TUMITATE_TANKA")) Then
                            DirectCast(Me.Controls("numTUMITATE_TANKA" & wNo), JBD.Gjs.Win.GcNumber).Value =
                                 CDec(WordHenkan("N", "Z", .Rows(i)("TUMITATE_TANKA")))
                        End If
                        '経営支援互助金単価
                        If Not IsDBNull(.Rows(i)("KEIEISIEN_TANKA")) Then
                            DirectCast(Me.Controls("numKEIEISIEN_TANKA" & wNo), JBD.Gjs.Win.GcNumber).Value =
                                 CDec(WordHenkan("N", "Z", .Rows(i)("KEIEISIEN_TANKA")))
                        End If
                        '焼却・埋却互助金単価
                        If Not IsDBNull(.Rows(i)("SYOKYAKU_TANKA")) Then
                            DirectCast(Me.Controls("numSYOKYAKU_TANKA" & wNo), JBD.Gjs.Win.GcNumber).Value =
                                 CDec(WordHenkan("N", "Z", .Rows(i)("SYOKYAKU_TANKA")))
                        End If
                    End If
                    '2017/07/11　修正終了

                    '手数料率
                    If .Rows(i)("KEIYAKU_KBN") = 9 And .Rows(i)("TORI_KBN") = 9 Then
                        If Not IsDBNull(.Rows(i)("TESURYO_RITU")) Then
                            numTESURYO_RITU.Value = CDec(WordHenkan("N", "S", .Rows(i)("TESURYO_RITU")))
                        Else
                            numTESURYO_RITU.Value = Nothing
                        End If
                        '2022/01/24 JBD9020 交付率追加 ADD START
                        If Not IsDBNull(.Rows(i)("KOFU_RITU")) Then
                            numKOFU_RITU.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOFU_RITU")))
                        Else
                            numKOFU_RITU.Value = Nothing
                        End If
                        '2022/01/24 JBD9020 交付率追加 ADD END
                    End If
                End With
            Next

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_Input_Check 画面入力チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check
    '説明            :画面入力チェック処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check() As Boolean
        Dim ret As Boolean = False
        Dim strMSG As String = String.Empty
        Dim obj As Object = Nothing
        Dim wNo As Integer = 0

        Try
            '--------------------------------------------------
            '必須入力チェック
            '--------------------------------------------------
            '年月日FROM
            If pSyoriKbn = C_INSERT Then
                '必須入力
                If dateTAISYO_DATE_Fm.Value Is Nothing Then
                    'Show_MessageBox("ユーザーIDは必須入力項目です。", C_MSGICON_INFORMATION)
                    Show_MessageBox_Add("W008", "年月日")      '@0は必須入力項目です。
                    dateTAISYO_DATE_Fm.Focus()
                    Exit Try
                End If
                '二重キー　チェック
                If Not f_TANKA_Exist_Check() Then
                    dateTAISYO_DATE_Fm.Focus()
                    Exit Try
                End If
            End If

            '年月日TO
            If dateTAISYO_DATE_To.Value Is Nothing Then
                Show_MessageBox_Add("W008", "年月日")      '@0は必須入力項目です。
                dateTAISYO_DATE_To.Focus()
                Exit Try
            End If


            '各項目の必須チェック
            If numTUMITATE_TANKA11.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　採卵鶏（成鶏）契約者積立金単価") : numTUMITATE_TANKA11.Focus() : Exit Try
            End If
            If numKEIEISIEN_TANKA11.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　採卵鶏（成鶏）経営支援互助金単価") : numKEIEISIEN_TANKA11.Focus() : Exit Try
            End If
            If numSYOKYAKU_TANKA11.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　採卵鶏（成鶏）焼却・埋却等互助金単価") : numSYOKYAKU_TANKA11.Focus() : Exit Try
            End If

            If numTUMITATE_TANKA12.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　採卵鶏（育成鶏）契約者積立金単価") : numTUMITATE_TANKA12.Focus() : Exit Try
            End If
            If numKEIEISIEN_TANKA12.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　採卵鶏（育成鶏）経営支援互助金単価") : numKEIEISIEN_TANKA12.Focus() : Exit Try
            End If
            If numSYOKYAKU_TANKA12.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　採卵鶏（育成鶏）焼却・埋却等互助金単価") : numSYOKYAKU_TANKA12.Focus() : Exit Try
            End If

            If numTUMITATE_TANKA13.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　肉用鶏　契約者積立金単価") : numTUMITATE_TANKA13.Focus() : Exit Try
            End If
            If numKEIEISIEN_TANKA13.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　肉用鶏　経営支援互助金単価") : numKEIEISIEN_TANKA13.Focus() : Exit Try
            End If
            If numSYOKYAKU_TANKA13.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　肉用鶏　焼却・埋却等互助金単価") : numSYOKYAKU_TANKA13.Focus() : Exit Try
            End If

            If numTUMITATE_TANKA14.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　種鶏（成鶏）契約者積立金単価") : numTUMITATE_TANKA14.Focus() : Exit Try
            End If
            If numKEIEISIEN_TANKA14.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　種鶏（成鶏）経営支援互助金単価") : numKEIEISIEN_TANKA14.Focus() : Exit Try
            End If
            If numSYOKYAKU_TANKA14.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　種鶏（成鶏）焼却・埋却等互助金単価") : numSYOKYAKU_TANKA14.Focus() : Exit Try
            End If

            If numTUMITATE_TANKA15.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　種鶏（育成鶏）契約者積立金単価") : numTUMITATE_TANKA15.Focus() : Exit Try
            End If
            If numKEIEISIEN_TANKA15.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　種鶏（育成鶏）経営支援互助金単価") : numKEIEISIEN_TANKA15.Focus() : Exit Try
            End If
            If numSYOKYAKU_TANKA15.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "家族型　種鶏（育成鶏）焼却・埋却等互助金単価") : numSYOKYAKU_TANKA15.Focus() : Exit Try
            End If


            If numTUMITATE_TANKA21.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　採卵鶏（成鶏）契約者積立金単価") : numTUMITATE_TANKA21.Focus() : Exit Try
            End If
            If numKEIEISIEN_TANKA21.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　採卵鶏（成鶏）経営支援互助金単価") : numKEIEISIEN_TANKA21.Focus() : Exit Try
            End If
            If numSYOKYAKU_TANKA21.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　採卵鶏（成鶏）焼却・埋却等互助金単価") : numSYOKYAKU_TANKA21.Focus() : Exit Try
            End If

            If numTUMITATE_TANKA22.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　採卵鶏（育成鶏）契約者積立金単価") : numTUMITATE_TANKA22.Focus() : Exit Try
            End If
            If numKEIEISIEN_TANKA22.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　採卵鶏（育成鶏）経営支援互助金単価") : numKEIEISIEN_TANKA22.Focus() : Exit Try
            End If
            If numSYOKYAKU_TANKA22.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　採卵鶏（育成鶏）焼却・埋却等互助金単価") : numSYOKYAKU_TANKA22.Focus() : Exit Try
            End If

            If numTUMITATE_TANKA23.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　肉用鶏　契約者積立金単価") : numTUMITATE_TANKA23.Focus() : Exit Try
            End If
            If numKEIEISIEN_TANKA23.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　肉用鶏　経営支援互助金単価") : numKEIEISIEN_TANKA23.Focus() : Exit Try
            End If
            If numSYOKYAKU_TANKA23.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　肉用鶏　焼却・埋却等互助金単価") : numSYOKYAKU_TANKA23.Focus() : Exit Try
            End If

            If numTUMITATE_TANKA24.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　種鶏（成鶏）契約者積立金単価") : numTUMITATE_TANKA24.Focus() : Exit Try
            End If
            If numKEIEISIEN_TANKA24.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　種鶏（成鶏）経営支援互助金単価") : numKEIEISIEN_TANKA24.Focus() : Exit Try
            End If
            If numSYOKYAKU_TANKA24.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　種鶏（成鶏）焼却・埋却等互助金単価") : numSYOKYAKU_TANKA24.Focus() : Exit Try
            End If

            If numTUMITATE_TANKA25.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　種鶏（育成鶏）契約者積立金単価") : numTUMITATE_TANKA25.Focus() : Exit Try
            End If
            If numKEIEISIEN_TANKA25.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　種鶏（育成鶏）経営支援互助金単価") : numKEIEISIEN_TANKA25.Focus() : Exit Try
            End If
            If numSYOKYAKU_TANKA25.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "企業型　種鶏（育成鶏）焼却・埋却等互助金単価") : numSYOKYAKU_TANKA25.Focus() : Exit Try
            End If

            '2017/07/11　修正開始
            'If numTUMITATE_TANKA36.Value Is Nothing Then
            '    Call Show_MessageBox_Add("W008", "うずら　契約者積立金単価") : numTUMITATE_TANKA36.Focus() : Exit Try
            'End If
            'If numKEIEISIEN_TANKA36.Value Is Nothing Then
            '    Call Show_MessageBox_Add("W008", "うずら　経営支援互助金単価") : numKEIEISIEN_TANKA36.Focus() : Exit Try
            'End If
            'If numSYOKYAKU_TANKA36.Value Is Nothing Then
            '    Call Show_MessageBox_Add("W008", "うずら　焼却・埋却等互助金単価") : numSYOKYAKU_TANKA36.Focus() : Exit Try
            'End If

            For i = 6 To 11
                wNo = 30 + i
                '積立金単価
                If DirectCast(Me.Controls("numTUMITATE_TANKA" & wNo), JBD.Gjs.Win.GcNumber).Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", "鶏以外　" & pToriNm(i) & "　契約者積立金単価")
                    DirectCast(Me.Controls("numTUMITATE_TANKA" & wNo), JBD.Gjs.Win.GcNumber).Focus()
                    Exit Try
                End If
                '経営支援互助金単価
                If DirectCast(Me.Controls("numKEIEISIEN_TANKA" & wNo), JBD.Gjs.Win.GcNumber).Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", "鶏以外　" & pToriNm(i) & "　経営支援互助金単価")
                    DirectCast(Me.Controls("numKEIEISIEN_TANKA" & wNo), JBD.Gjs.Win.GcNumber).Focus()
                    Exit Try
                End If
                '焼却・埋却等互助金単価
                If DirectCast(Me.Controls("numSYOKYAKU_TANKA" & wNo), JBD.Gjs.Win.GcNumber).Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", "鶏以外　" & pToriNm(i) & "　焼却・埋却等互助金単価")
                    DirectCast(Me.Controls("numSYOKYAKU_TANKA" & wNo), JBD.Gjs.Win.GcNumber).Focus()
                    Exit Try
                End If
            Next
            '2017/07/11　修正終了


            '手数料率
            If numTESURYO_RITU.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "手数料率") : numTESURYO_RITU.Focus() : Exit Try
            End If

            '2022/01/24 JBD9020 交付率追加 ADD START
            '手数料率
            If numKOFU_RITU.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "互助金交付") : numKOFU_RITU.Focus() : Exit Try
            End If
            If numKOFU_RITU.Value = 0 Then
                Call Show_MessageBox_Add("W019", "互助金交付率は0より上の数値を入力してください。") : numKOFU_RITU.Focus() : Exit Try
            End If
            '2022/01/24 JBD9020 交付率追加 ADD END

            '==FromToチェック==================
            '年月日
            If f_Daisyo_Check(dateTAISYO_DATE_Fm, dateTAISYO_DATE_To, "年月日", True, 2) = False Then
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

#Region "s_Set_RecVisible 行遷移ボタン表示制御"
    '------------------------------------------------------------------
    'プロシージャ名  :s_Set_RecVisible
    '説明            :行遷移ボタン表示制御
    '引数            :Boolean(表示true/非表示false)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    'Private Sub s_Set_RecVisible(ByRef wBoolean)
    '    Dim intRecMax As Integer = 0

    '    Try

    '        txt_Now.Visible = wBoolean
    '        lblKigo.Visible = wBoolean
    '        lblTotal.Visible = wBoolean
    '        cmdTop.Visible = wBoolean
    '        cmdBef.Visible = wBoolean
    '        cmdNext.Visible = wBoolean
    '        cmdLast.Visible = wBoolean

    '    Catch ex As Exception
    '        '共通例外処理
    '        Show_MessageBox("", ex.Message)
    '    End Try

    'End Sub
#End Region
#Region "s_Set_RecValidate 行遷移ボタン制御"
    ''------------------------------------------------------------------
    ''プロシージャ名  :s_Set_RecValidate
    ''説明            :行遷移ボタン制御
    ''引数            :なし
    ''戻り値          :Boolean(正常True/エラーFalse)
    ''------------------------------------------------------------------
    'Private Sub s_Set_RecValidate()
    '    Dim intRecMax As Integer = 0

    '    Try

    '        If txt_Now.Text.TrimEnd = "" OrElse txt_Now.Text.TrimEnd <= 0 Then
    '            txt_Now.Text = 1
    '        End If

    '        If lblTotal.Text.TrimEnd = "" OrElse lblTotal.Text.TrimEnd = "0" Then
    '            lblTotal.Text = "1"
    '        End If

    '        intRecMax = CInt(lblTotal.Text.TrimEnd)

    '        If txt_Now.Text.TrimEnd > intRecMax Then
    '            txt_Now.Text = intRecMax
    '        End If

    '        'If paryKEY.Count = 0 Then
    '        '    maryListMeisai.Add(New T_SID2_D)
    '        '    Call LoSubVarClear_Meisai()
    '        'End If

    '        If lblTotal.Text = 1 Then
    '            '該当データ１件のみ
    '            cmdTop.Enabled = False
    '            cmdBef.Enabled = False
    '            cmdNext.Enabled = False
    '            cmdLast.Enabled = False
    '        ElseIf txt_Now.Text.TrimEnd = 1 OrElse txt_Now.Text.TrimEnd = 0 Then
    '            '先頭行を表示
    '            cmdTop.Enabled = False
    '            cmdBef.Enabled = False
    '            cmdNext.Enabled = True
    '            cmdLast.Enabled = True
    '        ElseIf txt_Now.Text.TrimEnd = intRecMax Then
    '            '最終行を表示
    '            cmdTop.Enabled = True
    '            cmdBef.Enabled = True
    '            cmdNext.Enabled = False
    '            cmdLast.Enabled = False
    '        Else
    '            '中間の行を表示
    '            cmdTop.Enabled = True
    '            cmdBef.Enabled = True
    '            cmdNext.Enabled = True
    '            cmdLast.Enabled = True
    '        End If

    '        pintRecNo = CInt(txt_Now.Text.TrimEnd)

    '    Catch ex As Exception
    '        '共通例外処理
    '        Show_MessageBox("", ex.Message)
    '    End Try

    'End Sub
#End Region

#End Region


End Class
