'*******************************************************************************
'*　　①　フォーム名　　　  frmGJ8101.vb
'*
'*　　②　機能概要　　　　　消費税率マスタ登録、変更
'*
'*******************************************************************************
Option Strict Off
Option Explicit On
'------------------------------------------------------------------
Imports Oracle.DataAccess.Client
Imports JbdGjsCommon
Imports JbdGjsControl

Public Class frmGJ8101

#Region "*** 変数定義 ***"
    Public pSyoriKbn As String = String.Empty           '処理区分
    Private pDataSet As New DataSet                     '検索結果一覧セット用データセット
    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ

    Public Const C_INSERT As Integer = 0                '新規処理
    Public Const C_UPDATE As Integer = 1                '変更処理

    Public pSel_TAX_DATE_FROM As String = String.Empty  '変更時、初期表示番号
    Public pSel_NO As Integer = 0                       '変更時、該当データ行番号

#End Region

#Region "*** 画面制御関連 ***"
#Region "frmGJ8101_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ8101_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ8101_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            Call f_FormClear("C")

            'コンピュータ名取得
            pPCNAME = System.Net.Dns.GetHostName

            Select Case pSyoriKbn
                Case C_INSERT       '新規入力
                    '画面内容をセット
                    If Not f_SetForm_TM_TAX1() Then
                        Exit Try
                    End If

                    '適用開始日にフォーカスセット
                    date_TAX_DATE_FROM.Focus()

                Case C_UPDATE       '変更
                    '画面内容をセット　'一覧で選択されたレコードの内容を表示
                    If Not f_SetForm_TM_TAX2(pSel_TAX_DATE_FROM) Then
                        Exit Try
                    End If

                    '適用終了日にフォーカスセット
                    date_TAX_DATE_TO.Focus()

            End Select

            'pErrDsp = True                      'エラー表示あり　◎
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
                '「キャンセル」を選択
                Exit Try
            End If

            'データ保存　
            If Not f_TM_TAX_Save() Then
                Exit Try
            End If

            DirectCast(Owner, frmGJ8100).pSaveTAX_DATE_FROM = date_TAX_DATE_FROM.Text.TrimEnd

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
    ''説明            :先頭行移動ボタンクリック処理
    ''------------------------------------------------------------------
    Private Sub cmdTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sKENCD As String = String.Empty
        Dim sSEIRICD As String = String.Empty

        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
                    '「いいえ」を選択
                    Exit Try
                End If
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
#Region "cmdEnd_Click 戻るボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdEnd_Click
    '説明            :戻るボタンクリック処理　
    '------------------------------------------------------------------
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try

            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
                    '「いいえ」を選択
                    Exit Try
                End If
            End If

            'フォームクローズ
            Me.AutoValidate = AutoValidate.Disable
            Me.Close()

            pblnTextChange = False      '画面入力内容変更フラグ初期化

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'フォームクローズ
            Me.AutoValidate = AutoValidate.Disable
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
        date_TAX_DATE_FROM.TextChanged,
        date_TAX_DATE_TO.TextChanged,
        num_TAX_RITU.TextChanged

        pblnTextChange = True

    End Sub
#End Region
#End Region

#Region "*** データ登録関連 ***"

#Region "f_SetForm_TM_TAX1 消費税率マスタデータ画面セット(新規)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TM_TAX1
    '説明            :消費税率マスタデータ画面セット(新規)
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_TM_TAX1() As Boolean

        Dim ret As Boolean = False

        Try
            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_SetForm_TM_TAX2 消費税率マスタデータ画面セット(変更)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TM_TAX2
    '説明            :消費税率マスタデータ画面セット(変更)　
    '引数            :適用開始日
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_TM_TAX2(ByVal strTAX_DATE_FROM As String) As Boolean

        Dim sSql As String = String.Empty
        Dim dstDataSet As New DataSet
        Dim ret As Boolean = False

        Try
            strTAX_DATE_FROM = CType(strTAX_DATE_FROM, Date)
            sSql = " SELECT " & vbCrLf
            sSql += "  * " & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_TAX" & vbCrLf
            sSql += " WHERE" & vbCrLf
            sSql += "  TAX_DATE_FROM = '" & strTAX_DATE_FROM.TrimEnd & "'" & vbCrLf

            Call f_Select_ODP(dstDataSet, sSql)

            If dstDataSet.Tables(0).Rows.Count > 0 Then
                Call f_FormClear("")        '画面初期化

                '画面にセット
                If Not f_SetForm_Data(dstDataSet) Then
                    Exit Try
                End If

                'コントロール使用不可　
                date_TAX_DATE_FROM.Enabled = False '開始日入力不可

            Else
                'データ未存在
                Show_MessageBox("I003", "")       '指定された条件に一致するデータは存在しません。
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

#Region "f_TM_TAX_Save 消費税率マスタデータ更新"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_TAX_Save
    '説明            :消費税率マスタデータ更新
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_TAX_Save() As Boolean
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
                    Cmd.CommandText = "PKG_GJ8101.GJ8101_TAX_INS"
                Case C_UPDATE       '変更
                    wMsgTitle = "変更"
                    Cmd.CommandText = "PKG_GJ8101.GJ8101_TAX_UPD"
            End Select

            '引き渡し　
            Dim paraTAX_DATE_FROM As OracleParameter = Cmd.Parameters.Add("IN_TAX_TAX_DATE_FROM", date_TAX_DATE_FROM.Value)     '適用開始日.Value
            Dim paraTAX_DATE_TO As OracleParameter = Cmd.Parameters.Add("IN_TAX_TAX_DATE_TO", date_TAX_DATE_TO.Value)           '適用終了日.Value
            Dim paraTAX_RITU As OracleParameter = Cmd.Parameters.Add("IN_TAX_TAX_RITU", num_TAX_RITU.Text.Trim)               　'消費税率（%）
            Dim paraREGDATE As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_REG_DATE", Now)                             　　  'データ登録日
            Dim paraREGID As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_REG_ID", pLOGINUSERID)                        　    'データ登録ＩＤ
            Dim paraUPDATE As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_UP_DATE", Now)                                　   'データ更新日
            Dim paraUPID As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_UP_ID", pLOGINUSERID)                         　　   'データ更新ＩＤ
            Dim paraCOMNM As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_COM_NAME", pPCNAME)                          　　   'コンピュータ名

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

#Region "f_TAX_Dup_Check 消費税率マスタデータ重複チェック"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TAX_Dup_Check
    '説明            :消費税率マスタデータ重複チェック
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_TAX_Dup_Check() As Boolean

        Dim sSql As String = String.Empty
        Dim dstDataSet As New DataSet
        Dim ret As Boolean = False

        Try
            sSql = ""
            sSql = " SELECT " & vbCrLf
            sSql += "  * " & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_TAX" & vbCrLf
            sSql += " WHERE" & vbCrLf
            sSql += " (TAX_DATE_FROM <> '" & date_TAX_DATE_FROM.Value & "' AND" & vbCrLf    'DB適用開始日　<>　画面.適用開始日 AND
            sSql += "'" & date_TAX_DATE_FROM.Value & "' <= TAX_DATE_FROM AND" & vbCrLf      '画面.適用開始日<＝DB適用開始日　AND
            sSql += " TAX_DATE_TO <= '" & date_TAX_DATE_TO.Value & "') OR" & vbCrLf         'DB適用終了日<= 画面.適用終了日

            If pSyoriKbn = C_INSERT Then　　'新規登録のとき
                sSql += " TAX_DATE_FROM <= '" & date_TAX_DATE_FROM.Value & "' AND" & vbCrLf    '（DB適用開始日　<=　画面.適用開始日 AND
                sSql += " TAX_DATE_TO >= '" & date_TAX_DATE_FROM.Value & "' OR" & vbCrLf       'DB適用終了日 >= 画面.適用開始日) OR
                sSql += " TAX_DATE_FROM <= '" & date_TAX_DATE_TO.Value & "' AND" & vbCrLf      '（DB適用開始日　<=　画面.適用終了日 AND
                sSql += " TAX_DATE_TO >= '" & date_TAX_DATE_TO.Value & "'" & vbCrLf            'DB適用終了日　>=　画面.適用終了日）

            End If

            If pSyoriKbn = C_UPDATE Then　　'変更のとき
                sSql += " TAX_DATE_FROM <> '" & date_TAX_DATE_FROM.Value & "' AND" & vbCrLf    'DB適用開始日　<>　画面.適用開始日 AND
                sSql += " TAX_DATE_FROM <= '" & date_TAX_DATE_TO.Value & "' AND" & vbCrLf      'DB適用開始日　<=　画面.適用終了日 AND
                sSql += " TAX_DATE_TO >= '" & date_TAX_DATE_TO.Value & "'" & vbCrLf            'DB適用終了日　>=　画面.適用終了日

            End If

            Call f_Select_ODP(dstDataSet, sSql)

            If dstDataSet.Tables(0).Rows.Count > 0 Then　　'データが存在するとき
                Show_MessageBox_Add("W019", "適用期間が他データと重複しています。")   'W019 @0。
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
#Region "f_SetForm_Data 消費税率マスタデータ画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_Data
    '説明            :消費税率マスタデータ画面セット
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_Data(ByVal dstDataSet As DataSet) As Boolean
        Dim ret As Boolean = False
        Dim ea As New System.ComponentModel.CancelEventArgs

        Try

            '日付和暦変換
            Dim culture As Globalization.CultureInfo = New Globalization.CultureInfo("ja-JP")
            culture.DateTimeFormat.Calendar = New System.Globalization.JapaneseCalendar

            With dstDataSet.Tables(0)

                '適用開始日
                If IsDBNull(.Rows(0)("TAX_DATE_FROM")) Then
                    date_TAX_DATE_FROM.Text = ""
                Else
                    date_TAX_DATE_FROM.Value = .Rows(0)("TAX_DATE_FROM")
                End If

                '適用終了日
                If IsDBNull(.Rows(0)("TAX_DATE_TO")) Then
                    date_TAX_DATE_TO.Text = ""
                Else
                    date_TAX_DATE_TO.Value = .Rows(0)("TAX_DATE_TO")
                End If

                '消費税率
                num_TAX_RITU.Text = WordHenkan("N", "Z", .Rows(0)("TAX_RITU"))

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

        Try
            '--------------------------------------------------
            '必須入力チェック
            '--------------------------------------------------
            '①未入力の場合エラー、②終了日＜開始日の場合エラー、③データ重複の場合エラー

            '①未入力の場合エラー（必須入力）
            '適用開始日
            If pSyoriKbn = C_INSERT Then
                '必須入力
                If IsNothing(date_TAX_DATE_FROM.Value) Then
                    Show_MessageBox_Add("W008", "適用開始日")      '@0は必須入力項目です。
                    date_TAX_DATE_FROM.Focus()
                    Exit Try
                End If

            End If

            '適用終了日
            If IsNothing(date_TAX_DATE_TO.Value) Then
                Show_MessageBox_Add("W008", "適用終了日")      '@0は必須入力項目です。
                date_TAX_DATE_TO.Focus()
                Exit Try
            End If

            '消費税率
            If num_TAX_RITU.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "消費税率（%）")      '@0は必須入力項目です。
                num_TAX_RITU.Focus()
                Exit Try
            End If

            '②終了日＜開始日のときエラー
            If Not IsNothing(date_TAX_DATE_TO.Value) Then
                If Format(date_TAX_DATE_TO.Value, "yyyyMMdd") < Format(date_TAX_DATE_FROM.Value, "yyyyMMdd") Then
                    Show_MessageBox_Add("W019", "適用開始日・適用終了日の範囲指定が正しくありません。")   'W019 @0。
                    date_TAX_DATE_TO.Focus()
                    Exit Try
                End If
            End If

            '③データ重複のときエラー
            If Not f_TAX_Dup_Check() Then

                If pSyoriKbn = C_INSERT Then
                    date_TAX_DATE_FROM.Focus()
                End If

                If pSyoriKbn = C_UPDATE Then
                    date_TAX_DATE_TO.Focus()
                End If

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
#End Region

End Class
