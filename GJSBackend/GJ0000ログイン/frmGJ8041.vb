'*******************************************************************************
'*　　①　フォーム名　　　  frmGJ8041.vb
'*
'*　　②　機能概要　　　　　使用者マスタ登録、変更
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

Public Class frmGJ8041

#Region "*** 変数定義 ***"
    Public pApName As String = "GJ8041"                 'プログラムＩＤ
    Public pRptName As String = "使用者マスタ"          '帳票名
    Public pSyoriKbn As String = String.Empty           '処理区分
    Public pUKEIRE_YMDHMS As String = String.Empty      '処理開始時間
    Public pPCNAME As String = String.Empty             '端末ＩＤ
    Private pDataSet As New DataSet                     '検索結果一覧セット用データセット
    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ
    Private pErrDsp As Boolean                          'エラー表示有無

    Public Const C_INSERT As Integer = 0                '新規処理
    Public Const C_UPDATE As Integer = 1                '変更処理

    Public pSel_USER_ID As String = String.Empty        '変更時、初期表示番号
    Public pSel_UP_FLG As String = String.Empty         '変更時、初期表示番号
    Public pSel_SEQNO As String = String.Empty          '変更時、初期表示番号


    Public pSel_NO As Integer = 0                       '変更時、該当データ行番号

    Public paryKEY_8041 As New ArrayList
    Private pintRecNo As Integer = 0
    Private Const pKEY As String = "1234567890- "       'TEL、FAX入力可能文字

    Dim pTOROKU_YMDHMS As String = String.Empty
    Dim pREG_DATE_A As Date = Nothing                   '参加者マスタ修正削除履歴登録用登録日
    Dim pUP_DATE_A As Date = Nothing                    '参加者マスタ修正削除履歴登録用更新日

    Dim pPASS_KIGEN As Integer = 0                      '有効期限(日数)
    Dim pPASS_UP_DATE As Date = Nothing                 'パスワード変更日
    Dim pPASS_KIGEN_DATE As Date = Nothing              'パスワード有効期限

#End Region


#Region "*** 画面制御関連 ***"
#Region "frmGJ8041_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ8041_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ8041_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Call f_FormClear("C")

            ''コンピュータ名取得
            pPCNAME = System.Net.Dns.GetHostName

            'コントロールマスタ読み込み
            If Not f_TM_CONTROL_Data_Select() Then
                Throw New Exception("Err")
            End If

            'コンボボックスセット
            If Not f_ComboBox_Set() Then
                Throw New Exception("Err")
            End If

            '処理内容によって画面の初期状態をセット
            pErrDsp = False                     'エラー表示なし

            Select Case pSyoriKbn
                Case C_INSERT       '新規入力
                    '画面内容をセット
                    If Not f_SetForm_TM_USER1() Then
                        Exit Try
                    End If

                    'ユーザーIDにフォーカスセット
                    txt_USER_ID.Focus()

                Case C_UPDATE       '変更
                    '画面内容をセット
                    If Not f_SetForm_TM_USER2(pSel_USER_ID) Then
                        Exit Try
                    End If

                    ''行遷移
                    'lblTotal.Text = paryKEY_8041.Count
                    'txt_Now.Text = pSel_NO
                    ''行遷移ボタン制御
                    'Call s_Set_RecValidate()

                    'ユーザー名にフォーカスセット
                    txt_USER_NAME.Focus()

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
#Region "f_FormClear 画面クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_FormClear
    '説明            :画面クリア処理
    '引数            :rKbn(処理区分)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_FormClear(ByVal rKbn As String) As Boolean

        f_FormClear = False
        Try

            f_FormClear = True

            For Each objCtrl In Me.Controls
                Select Case TypeName(objCtrl)
                    Case "TabControl"
                        'タブ内のコントロールを順に確認
                        For Each objCtrl2 In objCtrl.controls

                            Select Case TypeName(objCtrl2)
                                Case "TabPage"
                                    'ﾀﾌﾞﾍﾟｰｼﾞ内のコントロールを順番に確認
                                    For Each objCtrl3 In objCtrl2.controls

                                        Select Case TypeName(objCtrl3)

                                            Case "GroupBox", "Panel"
                                                'ｸﾞﾙｰﾌﾟﾎﾞｯｸｽ又はﾊﾟﾈﾙ内のコントロールを順番に確認
                                                For Each objCtrl4 In objCtrl3.controls

                                                    Select Case TypeName(objCtrl4)
                                                        Case "GroupBox"

                                                            For Each objCtrl5 In objCtrl4.controls
                                                                'ｸﾞﾙｰﾌﾟﾎﾞｯｸｽ内のコントロールを順番にクリア
                                                                Call f_ObjectClear(rKbn, objCtrl5)

                                                            Next
                                                        Case "Panel"

                                                            Call f_ObjectClear(rKbn, objCtrl4)
                                                        Case Else
                                                            'ｸﾞﾙｰﾌﾟﾎﾞｯｸｽ又はﾊﾟﾈﾙ内のコントロールを順番にクリア
                                                            Call f_ObjectClear(rKbn, objCtrl4)

                                                    End Select
                                                Next
                                            Case Else
                                                'GroupBox、Panel以外に配置しているコントロールのクリア
                                                Call f_ObjectClear(rKbn, objCtrl3)
                                        End Select
                                    Next
                            End Select
                        Next

                    Case Else
                        'タブ以外に配置しているコントロールのクリア
                        Call f_ObjectClear(rKbn, objCtrl)

                End Select
            Next

            'If rKbn = "C" Then
            '    txt_Now.Text = ""
            '    lblTotal.Text = ""
            '    pblnTextChange = False
            'End If
            'lbl_SEQNO.Text = ""
            'rbtn_KOFU_FLG1.Checked = True
            'rbtn_KOFU_FLG2.Checked = False

            pDataSet.Clear()


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function
#End Region
#Region "f_ObjectClear コントロールクリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ObjectClear
    '説明            :画面クリア処理
    '引数            :rKbn(処理区分)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ObjectClear(ByVal rKbn As String, ByVal objCtrl As Object) As Boolean

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            Select Case TypeName(objCtrl)

                Case "GcTextBox", "GcDate"
                    'ﾃｷｽﾄﾎﾞｯｸｽ、日付型
                    If rKbn = "C" Then
                        If objCtrl.Name <> "txt_Now" Then
                            objCtrl.Text = ""
                        End If
                    Else
                        'ﾃｷｽﾄﾎﾞｯｸｽ、日付型
                        objCtrl.Text = ""
                    End If

                Case "GcMask"
                    'ﾏｽｸ
                    objCtrl.Value = ""

                Case "GcNumber"
                    '数値型
                    objCtrl.Text = ""

                Case "GcComboBox"
                    'ｺﾝﾎﾞﾎﾞｯｸｽ
                    If rKbn = "C" Then
                        objCtrl.Items.Clear()
                    Else
                        objCtrl.SelectedIndex = -1
                    End If
                Case "CheckBox"
                    'ﾁｪｯｸﾎﾞｯｸｽ
                    objCtrl.Checked = False

                Case "RadioButton"
                    'ﾗｼﾞｵﾎﾞﾀﾝ
                    If objCtrl.TabIndex = 0 Then
                        objCtrl.Checked = True
                    Else
                        objCtrl.Checked = False
                    End If
            End Select

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function
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
            If Not f_TM_USER_Save() Then
                Exit Try
            End If

            '保存あり
            'frmPF9060.pSaveFlg = True                                              '2010/10/16 DEL JBD200
            'frmPF9060.pSaveUSER_ID = txt_USER_ID.Text.TrimEnd                      '2010/10/16 DEL JBD200
            DirectCast(Owner, frmGJ8040).pSaveFlg = True                            '2010/10/16 ADD JBD200
            DirectCast(Owner, frmGJ8040).pSaveUSER_ID = txt_USER_ID.Text.TrimEnd    '2010/10/16 ADD JBD200

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
#Region "使用区分"
    '------------------------------------------------------------------
    'プロシージャ名  :cbo_SIYO_KBN_SelectedIndexChanged
    '説明            :使用区分コードChanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_SIYO_KBN_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_SIYO_KBN.SelectedIndexChanged

        cbo_SIYO_KBN_NAME.SelectedIndex = cbo_SIYO_KBN.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_SIYO_KBN_NAME_SelectedIndexChanged
    '説明            :使用区分名Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_SIYO_KBN_NAME_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_SIYO_KBN_NAME.SelectedIndexChanged

        cbo_SIYO_KBN.SelectedIndex = cbo_SIYO_KBN_NAME.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_SIYO_KBN_Validating
    '説明            :使用区分コード_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cbo_SIYO_KBN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbo_SIYO_KBN.Validating

        If cbo_SIYO_KBN.Text = "" Then
            Exit Sub
        End If

        cbo_SIYO_KBN.SelectedValue = cbo_SIYO_KBN.Text
        If cbo_SIYO_KBN.SelectedValue Is Nothing Then
            cbo_SIYO_KBN.SelectedIndex = -1
            cbo_SIYO_KBN_NAME.SelectedIndex = -1
            If pErrDsp Then
                Show_MessageBox_Add("W012", "使用区分") '指定された@0が正しくありません。
                'Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION) '該当データが存在しません。
                cbo_SIYO_KBN.Focus()
            End If
        End If

    End Sub
#End Region
#Region "停止日"
    '------------------------------------------------------------------
    'プロシージャ名  :date_TEISI_DATE_ValueChanged
    '説明            :停止日_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub date_TEISI_DATE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles date_TEISI_DATE.ValueChanged

        '停止日未入力のとき、停止理由クリア・入力不可
        If IsNothing(date_TEISI_DATE.Value) Then
            txt_TEISI_RIYU.Text = ""
            txt_TEISI_RIYU.Enabled = False
        Else
            '停止日入力時のとき、停止理由入力可
            txt_TEISI_RIYU.Enabled = True
        End If

    End Sub
#End Region

#Region "s_FormControls_TextChanged 画面コントロールTextChangeイベント"

    '------------------------------------------------------------------
    'プロシージャ名  :s_FormControls_TextChanged
    '説明            :画面コントロールTextChangeイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub s_FormControls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
                                                            txt_USER_ID.TextChanged, _
                                                            txt_USER_NAME.TextChanged, txt_PASS.TextChanged, _
                                                            cbo_SIYO_KBN.TextChanged, _
                                                            date_TEISI_DATE.TextChanged, txt_TEISI_RIYU.TextChanged

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

#Region "f_SetForm_TM_USER1 使用者マスタデータ画面セット(新規)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TM_USER1
    '説明            :使用者マスタデータ画面セット(新規)
    '引数            :ユーザーID
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_TM_USER1() As Boolean

        Dim ret As Boolean = False
        Dim strPASS_KIGEN_DATE As String = String.Empty
        Dim strPASS_UP_DATE As String = String.Empty

        Try
            '日付和暦変換
            Dim culture As Globalization.CultureInfo = New Globalization.CultureInfo("ja-JP")
            culture.DateTimeFormat.Calendar = New System.Globalization.JapaneseCalendar

            pPASS_UP_DATE = Now
            strPASS_UP_DATE = pPASS_UP_DATE.ToString("ggyy/MM/dd", culture)
            pPASS_KIGEN_DATE = DateAdd(DateInterval.Day, pPASS_KIGEN, pPASS_UP_DATE)
            strPASS_KIGEN_DATE = pPASS_KIGEN_DATE.ToString("ggyy/MM/dd", culture)

            'パスワード有効期限、パスワード変更日を画面設定
            '↓2015/04/02 JBD368 UPD
            'date_PASS_KIGEN_DATE.Text = strPASS_UP_DATE
            'date_PASS_UP_DATE.Text = strPASS_KIGEN_DATE
            date_PASS_KIGEN_DATE.Text = strPASS_KIGEN_DATE
            date_PASS_UP_DATE.Text = strPASS_UP_DATE
            '↑2015/04/02 jbd368 UPD

            ''行遷移ボタン表示制御
            's_Set_RecVisible(False)
            ''コントロール使用不可
            date_TEISI_DATE.Enabled = False
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
#Region "f_SetForm_TM_USER2 使用者マスタデータ画面セット(変更)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TM_USER2
    '説明            :使用者マスタデータ画面セット(変更)
    '引数            :ユーザーID
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_TM_USER2(ByVal strUSER_ID As String) As Boolean

        Dim sSql As String = String.Empty
        Dim dstDataSet As New DataSet
        Dim ret As Boolean = False

        Try

            sSql = " SELECT " & vbCrLf
            sSql += "  * " & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_USER" & vbCrLf
            sSql += " WHERE" & vbCrLf
            sSql += "  USER_ID = '" & strUSER_ID.TrimEnd & "'" & vbCrLf


            Call f_Select_ODP(dstDataSet, sSql)

            If dstDataSet.Tables(0).Rows.Count > 0 Then
                Call f_FormClear("")        '画面初期化

                '画面にセット
                If Not f_SetForm_Data(dstDataSet) Then
                    Exit Try
                End If

                'コントロール使用不可
                txt_USER_ID.Enabled = False
                If IsNothing(date_TEISI_DATE.Value) Then
                    txt_TEISI_RIYU.Enabled = False
                Else
                    txt_TEISI_RIYU.Enabled = True
                End If

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

#Region "f_TM_USER_Save 使用者マスタデータ更新"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_USER_Save
    '説明            :使用者マスタデータ更新
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_USER_Save() As Boolean
        Dim Cmd As New OracleCommand
        Dim sSql As String = String.Empty
        Dim ret As Boolean = False
        Dim wMsgTitle As String = String.Empty

        Try


            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Select Case pSyoriKbn
                Case C_INSERT       '新規入力
                    wMsgTitle = "新規登録"
                    Cmd.CommandText = "PKG_GJ8041.GJ8041_USER_INS"
                Case C_UPDATE       '変更
                    wMsgTitle = "変更"
                    Cmd.CommandText = "PKG_GJ8041.GJ8041_USER_UPD"
            End Select

            '引き渡し
            Dim paraUSER_ID As OracleParameter = Cmd.Parameters.Add("IN_USER_USER_ID", txt_USER_ID.Text.Trim)               'ユーザーID
            Dim paraNEW_LOGIN_NO As OracleParameter = Cmd.Parameters.Add("IN_USER_NEW_LOGIN_NO", pAPP)                      '最新ログイン番号
            Dim paraUSER_NAME As OracleParameter = Cmd.Parameters.Add("IN_USER_USER_NAME", txt_USER_NAME.Text.TrimEnd)      'ユーザー名
            Dim paraPASS As OracleParameter = Cmd.Parameters.Add("IN_USER_PASS", txt_PASS.Text.TrimEnd)                     'パスワード
            Dim paraPASS_UP_DATE As OracleParameter = Cmd.Parameters.Add("IN_USER_PASS_UP_DATE", pPASS_UP_DATE)             'パスワード変更日
            Dim paraPASS_KIGEN_DATE As OracleParameter = Cmd.Parameters.Add("IN_USER_PASS_KIGEN_DATE", pPASS_KIGEN_DATE)    'パスワード有効期限
            Dim paraPASS_KAISU As OracleParameter = Cmd.Parameters.Add("IN_USER_PASS_KAISU", 0)                             'パスワード変更回数
            Dim paraSIYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_USER_SIYO_KBN", cbo_SIYO_KBN.Text.TrimEnd)         '使用区分
            Dim paraTEISI_DATE As OracleParameter = Cmd.Parameters.Add("IN_USER_TEISI_DATE", date_TEISI_DATE.Value)         '停止日
            Dim paraTEISI_RIYU As OracleParameter = Cmd.Parameters.Add("IN_USER_TEISI_RIYU", txt_TEISI_RIYU.Text.TrimEnd)   '停止理由コード

            Dim paraREGDATE As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_REG_DATE", Now)                               'データ登録日
            Dim paraREGID As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_REG_ID", pAPP)                                  'データ登録ＩＤ
            Dim paraUPDATE As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_UP_DATE", Now)                                 'データ更新日
            Dim paraUPID As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_UP_ID", pAPP)                                    'データ更新ＩＤ
            Dim paraCOMNM As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_COM_NAME", pPCNAME)                             'コンピュータ名

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Show_MessageBox("", Cmd.Parameters("OU_MSGNM").Value.ToString())
            End If


            ret = True

        Catch ex As Exception

            '共通例外処理
            If ex.Message <> "Err" Then
                '共通例外処理
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

#Region "f_TM_CONTROL_Data_Select コントロールマスタデータ取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_CONTROL_Data_Select
    '説明            :コントロールマスタデータ取得
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_TM_CONTROL_Data_Select() As Boolean

        Dim sSql As String = String.Empty
        Dim dstDataControl As New DataSet
        Dim ret As Boolean = False

        Try

            sSql = " SELECT " & vbCrLf
            sSql += "  PASS_KIGEN" & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_CONTROL" & vbCrLf

            Call f_Select_ODP(dstDataControl, sSql)

            With dstDataControl.Tables(0)
                If .Rows.Count > 0 Then
                    pPASS_KIGEN = WordHenkan("N", "S", .Rows(0)("PASS_KIGEN"))
                    ret = True
                Else
                    'コントロールなし
                    Show_MessageBox("", "コントロールマスタが設定されていません") 'コントロールマスタが設定されていません
                End If
            End With

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_ComboBox_Set コンボボックスセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ComboBox_Set
    '説明            :コンボボックスセット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ComboBox_Set() As Boolean
        Dim ret As Boolean = False

        Try
            '使用区分コンボセット
            If Not f_CodeMaster_Data_Select(cbo_SIYO_KBN, cbo_SIYO_KBN_NAME, 6, True) Then
                Exit Try
            End If

            'コンボボックス初期化
            cbo_SIYO_KBN.Text = ""

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_USER_Exist_Check 使用者マスタデータ存在チェック"
    '------------------------------------------------------------------
    'プロシージャ名  :f_USER_Exist_Check
    '説明            :使用者マスタデータ存在チェック
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_USER_Exist_Check() As Boolean

        Dim sSql As String = String.Empty
        Dim dstDataSet As New DataSet
        Dim strUSER_ID As String = String.Empty
        Dim ret As Boolean = False

        Try
            strUSER_ID = txt_USER_ID.Text.TrimEnd

            sSql = ""
            sSql = " SELECT " & vbCrLf
            sSql += "  * " & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_USER" & vbCrLf
            sSql += " WHERE" & vbCrLf
            'sSql += "  SANKA_KEN_CD = " & cob_KenCd.Text.TrimEnd & " AND " & vbCrLf
            sSql += "  USER_ID = '" & txt_USER_ID.Text.TrimEnd & "'" & vbCrLf

            Call f_Select_ODP(dstDataSet, sSql)

            If dstDataSet.Tables(0).Rows.Count > 0 Then
                'データ未存在
                Show_MessageBox("W001", "")    'データは既に登録されています。
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
#Region "f_SetForm_Data 使用者マスタデータ画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_Data
    '説明            :使用者マスタデータ画面セット
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_Data(ByVal dstDataSet As DataSet) As Boolean
        Dim ret As Boolean = False
        Dim ea As New System.ComponentModel.CancelEventArgs

        Dim dPASS_KIGEN_DATE As Date
        Dim dPASS_UP_DATE As Date

        Try

            '日付和暦変換
            Dim culture As Globalization.CultureInfo = New Globalization.CultureInfo("ja-JP")
            culture.DateTimeFormat.Calendar = New System.Globalization.JapaneseCalendar

            With dstDataSet.Tables(0)

                'ユーザーID
                txt_USER_ID.Text = WordHenkan("N", "S", .Rows(0)("USER_ID"))

                'ユーザー名
                txt_USER_NAME.Text = WordHenkan("N", "S", .Rows(0)("USER_NAME"))

                'パスワード
                txt_PASS.Text = WordHenkan("N", "S", .Rows(0)("PASS"))

                'パスワード有効期限
                If IsDBNull(.Rows(0)("PASS_KIGEN_DATE")) Then
                    date_PASS_KIGEN_DATE.Text = ""
                Else
                    dPASS_KIGEN_DATE = .Rows(0)("PASS_KIGEN_DATE")
                    date_PASS_KIGEN_DATE.Text = dPASS_KIGEN_DATE.ToString("ggyy/MM/dd", culture)

                End If

                'パスワード変更日
                If IsDBNull(.Rows(0)("PASS_UP_DATE")) Then
                    date_PASS_UP_DATE.Text = ""
                Else
                    dPASS_UP_DATE = .Rows(0)("PASS_UP_DATE")
                    date_PASS_UP_DATE.Text = dPASS_UP_DATE.ToString("ggyy/MM/dd", culture)
                End If

                '使用区分
                cbo_SIYO_KBN.Text = WordHenkan("N", "Z", .Rows(0)("SIYO_KBN"))
                Call cbo_SIYO_KBN_Validating(cbo_SIYO_KBN, ea)

                '使用停止日
                If IsDBNull(.Rows(0)("TEISI_DATE")) Then
                    date_TEISI_DATE.Text = ""
                Else
                    date_TEISI_DATE.Value = .Rows(0)("TEISI_DATE")
                End If

                '使用停止理由
                txt_TEISI_RIYU.Text = WordHenkan("N", "S", .Rows(0)("TEISI_RIYU"))

                '登録日
                If IsDBNull(.Rows(0)("REG_DATE")) Then
                    date_REG_DATE.Text = ""
                Else
                    date_REG_DATE.Value = .Rows(0)("REG_DATE")
                End If

            End With


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

        Try
            '--------------------------------------------------
            '必須入力チェック
            '--------------------------------------------------
            'ユーザーID
            If pSyoriKbn = C_INSERT Then
                '必須入力
                If txt_USER_ID.Text.TrimEnd = "" Then
                    'Show_MessageBox("ユーザーIDは必須入力項目です。", C_MSGICON_INFORMATION)
                    Show_MessageBox_Add("W008", "ユーザーID")      '@0は必須入力項目です。
                    txt_USER_ID.Focus()
                    Exit Try
                End If
                '二重キー　チェック
                If Not f_USER_Exist_Check() Then
                    txt_USER_ID.Focus()
                    Exit Try
                End If
            End If


            'ユーザー名
            If txt_USER_NAME.Text.TrimEnd = "" Then
                'Show_MessageBox("ユーザー名は必須入力項目です。", C_MSGICON_INFORMATION)
                Show_MessageBox_Add("W008", "ユーザー名")      '@0は必須入力項目です。
                txt_USER_NAME.Focus()
                Exit Try
            End If

            'パスワード
            If txt_PASS.Text.TrimEnd = "" Then
                'Show_MessageBox("パスワードは必須入力項目です。", C_MSGICON_INFORMATION)
                Show_MessageBox_Add("W008", "パスワード")      '@0は必須入力項目です。
                txt_PASS.Focus()
                Exit Try
            End If
            If Len(txt_PASS.Text.TrimEnd) < 6 Then
                'Show_MessageBox("パスワードは6桁以上指定してください。", C_MSGICON_INFORMATION)
                Show_MessageBox("", "パスワードは6桁以上指定してください。")   'パスワードは6桁以上指定してください。
                txt_PASS.Focus()
                Exit Try
            End If

            '使用区分
            If cbo_SIYO_KBN.Text.TrimEnd = "" Then
                'Show_MessageBox("使用区分は必須入力項目です。", C_MSGICON_INFORMATION)
                Show_MessageBox_Add("W008", "使用区分")      '@0は必須入力項目です。
                cbo_SIYO_KBN.Focus()
                Exit Try
            End If

            '停止日＜登録日のときエラー
            If Not IsNothing(date_TEISI_DATE.Value) Then
                If Format(date_TEISI_DATE.Value, "yyyyMMdd") < Format(date_REG_DATE.Value, "yyyyMMdd") Then
                    'Show_MessageBox("停止日は登録日以降の日付を入力してください。", C_MSGICON_INFORMATION)
                    Show_MessageBox_Add("W503", "停止日", "登録日")      '@0<@1は入力できません。
                    date_TEISI_DATE.Focus()
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
