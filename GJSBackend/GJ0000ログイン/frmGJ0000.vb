'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ0000.vb
'*
'*　　②　機能概要　　　　　鶏卵生産者経営安定対策事業電算システム　ログイン
'*
'*　　③　作成日　　　　　　2011/12/16  BY JBD200　新規作成
'*
'*　　④　更新日            
'*
'*******************************************************************************
Option Strict Off
Option Explicit On

'------------------------------------------------------------------

'------------------------------------------------------------------

Imports JbdGjsCommon


Public Class frmGJ0000

#Region "*** 変数定義 ***"

    Private pDataSet As New DataSet                         '検索結果一覧セット用データセット

    Public pUKEIRE_YMDHMS As String = String.Empty          '処理開始時間
    'Public pSel_POS As Integer = 0                         '変更時、該当データ行番号
    Public pCNT As Integer = 0                               '帳票出力件数
    Public pKEY As String = String.Empty
    'Private Const pKEY As String = "1234 "                  '四半期入力可能文字

    Private Const C_TAISYONENDO As Integer = 0              '対象年度
    Private Const C_SEIKYUSIHANKI As Integer = 1            '請求四半期
    Private Const C_SEIKYUKAISU As Integer = 2              '請求回数
    Private Const C_SEISANSYACD As Integer = 3              '生産者番号

#End Region

#Region "*** 画面制御関連 ***"
#Region "frmGJ0000_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ0000_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Public Sub frmGJ0000_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean
        Try

            'カーソルポインタを砂時計に設定する。
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

            '---------------------------------------------------
            '二重起動チェック
            '---------------------------------------------------
            Dim mt As New System.Threading.Mutex(
                                    False, Process.GetCurrentProcess.ProcessName)
            'WaitHandle.WaitOne メソッド
            '現在の WaitHandle がシグナルを受入するまで現在のスレッドをブロックします
            If mt.WaitOne(0, False) = False Then
                'このプログラムは、すでに起動しています。
                MessageBox.Show("このプログラムは、すでに起動しています。", "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1)
                mt.Close()
                Me.Close()
            End If

            '-------------------------------------------------------
            ' GJS.iniより各種設定値を取得しグローバル変数へセット
            '-------------------------------------------------------
            If Get_IniFile() = True Then
            Else
                Exit Sub
            End If

            Me.BackColor = myBACKCOLOR


            '-------------------------------------------------------
            ' コネクション文字列の設定
            '-------------------------------------------------------
            If DbConnect() = True Then

            Else
                Exit Sub
            End If

            If Cnn.State = ConnectionState.Closed Then
                'データベースへの接続
                Cnn.Open()
            End If

            '---------------------------------------------------

            '---------------------------------------------------
            'メッセージの取得
            If f_Message_Select() = True Then
                '取得成功
            Else
                '取得失敗
                Exit Sub
            End If

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_FormClear("C")

            '画面内容をセット

            'ユーザーIDにフォーカスセット
            txt_UserId.Select()
            txt_UserId.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

#Region "frmGJ0000_KeyPress KeyPressイベント"

    '------------------------------------------------------------------
    'プロシージャ名  :Form_KeyPress
    '説明            :Enterキー押下時タブ移動処理
    '------------------------------------------------------------------
    Public Sub frmGJ0000_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Try

            'SendKeys.Send メソッド を使った方法(Shift + Enter で逆方向に移動）
            'Enterキーが押された事を取得
            If e.KeyChar = Chr(Keys.Enter) Then
                e.Handled = True    'KeyPress イベントをキャンセルしBeep音を消音に
                SendKeys.Send(Constants.vbTab)
            Else
            End If

        Catch ex As Exception
            '共通例外処理
            'Show_MessageBox("", ex.Message)

        End Try

    End Sub

#End Region

#Region "frmGJ0000_FormClosed Form_Closeイベント"

    Private Sub frmGJ0000_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Not Me.DesignMode Then
            '' フォームＩＤからＡＰＩＤを取得する
            'pAPP = Mid(Me.GetType.Name, 4)
            ''画面からＡＰＴＩＴＬＥを取得する
            'pAPPTITLE = lblTitle.Text

            ''操作ログ出力
            'Call f_InfoLog_Put(1)
            Me.Dispose()
        End If
    End Sub

#End Region

#Region "frmGJ0000_Disposed Form_Disposedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ0000_Disposed
    '説明            :Form_Disposedイベント
    '------------------------------------------------------------------
    Private Sub frmGJ0000_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        'データベースへの切断
        Cnn.Close()

    End Sub

#End Region

    '#Region "f_ObjectClear 画面クリア処理"
    '    '------------------------------------------------------------------
    '    'プロシージャ名  :f_ObjectClear
    '    '説明            :画面クリア処理
    '    '引数            :rKbn(処理区分)
    '    '戻り値          :Boolean(正常True/エラーFalse)
    '    '------------------------------------------------------------------
    '    Private Function f_ObjectClear() As Boolean

    '        f_ObjectClear = False
    '        Try

    '            f_ObjectClear = True

    '            'カーソルを砂時計にする
    '            Me.Cursor = Cursors.WaitCursor

    '            cob_KenCdFm.Items.Clear()
    '            cob_KenMeiFm.Items.Clear()
    '            cob_KenCdTo.Items.Clear()
    '            cob_KenMeiTo.Items.Clear()
    '            txt_SeisansyaNm.Text = ""
    '            txt_DairininNo.Text = ""
    '            rbtn_Nofu1.Checked = True
    '            rbtn_Nofu2.Checked = False
    '            lblCOUNT.Text = "0"


    '            paryKEY_3110 = New ArrayList

    '            pDataSet.Clear()

    '            'カーソルを標準に戻す
    '            Me.Cursor = Cursors.Default

    '        Catch ex As Exception
    '            '共通例外処理
    '            Show_MessageBox("", ex.Message)
    '            'Show_MessageBox(ex.Message, C_MSGICON_ERROR)
    '        End Try

    '    End Function
    '#End Region

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

#Region "cmdLogin_Click ログインボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdLogin_Click
    '説明            :ログインボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        Dim sSql As String = String.Empty
        Dim dstDataSet As New DataSet

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '画面入力チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            sSql = f_Search_SQLMake()
            If Not f_Select_ODP(dstDataSet, sSql) Then
                Exit Try
            End If

            If dstDataSet.Tables(0).Rows.Count > 0 Then

                '画面に該当データを表示
                '画面にセット
                If Not f_User_Check(dstDataSet) Then
                    Exit Try
                End If

            Else
                'データ存在なし
                Show_MessageBox_Add("W019", "ユーザーＩＤ、パスワードが正しくありません。") 'ユーザーＩＤ、パスワードが正しくありません。
                pDataSet.Clear()
                Exit Sub
            End If


            Dim pGJSINI_Array As pGJSINI = Nothing
            'txt_UserId.Text.TrimEnd
            pGJSINI_Array.LOGINUSERID = txt_UserId.Text.TrimEnd             '2010/10/23 ADD JBD200
            pGJSINI_Array.LOGINUSERNM = WordHenkan("N", "S", dstDataSet.Tables(0).Rows(0)("USER_NAME"))
            pGJSINI_Array.DBUSER = myDBUSER
            pGJSINI_Array.DBPASS = myDBPASS
            pGJSINI_Array.DBSID = myDBSID
            '2021/04/12 JBD9020 R03年度追加基金対応 DEL START
            'pGJSINI_Array.CSV_SANKA_ENTRY = myCSV_SANKA_ENTRY
            'pGJSINI_Array.CSV_SANKA_ENTRY_SERVER = myCSV_SANKA_ENTRY_SERVER
            'pGJSINI_Array.CSV_KANRI_DATA_SERVER = myCSV_KANRI_DATA_SERVER
            'pGJSINI_Array.TXT_KANRI_ENTRY = myTXT_KANRI_ENTRY
            'pGJSINI_Array.TXT_KANRI_ENTRY_SERVER = myTXT_KANRI_ENTRY_SERVER
            '2021/04/12 JBD9020 R03年度追加基金対応 DEL END
            pGJSINI_Array.TXT_FURIKOMI_ENTRY = myTXT_FURIKOMI_ENTRY
            '2021/04/12 JBD9020 R03年度追加基金対応 DEL START
            'pGJSINI_Array.TXT_FURIKOMI_ENTRY_SERVER = myTXT_FURIKOMI_ENTRY_SERVER
            'pGJSINI_Array.TXT_HIKIOTOSHI_ENTRY = myTXT_HIKIOTOSHI_ENTRY
            'pGJSINI_Array.DMP_FILE_PATH = myDMP_FILE_PATH
            'pGJSINI_Array.DMP_LOG_PATH = myDMP_LOG_PATH
            'pGJSINI_Array.DMP_DBUSER = myDMP_DBUSER
            'pGJSINI_Array.DMP_DBPASS = myDMP_DBPASS
            'pGJSINI_Array.DMP_DBSID = myDMP_DBSID
            'pGJSINI_Array.DMP_TIME_OUT = myDMP_TIME_OUT
            '2021/04/12 JBD9020 R03年度追加基金対応 DEL END
            pGJSINI_Array.REPORT_PDF_PATH = myREPORT_PDF_PATH
            pGJSINI_Array.REPORT_EXCEL_PATH = myREPORT_EXCEL_PATH
            '2021/04/12 JBD9020 R03年度追加基金対応 DEL START
            'pGJSINI_Array.ZIP_PASSWORD = myZIP_PASSWORD
            'pGJSINI_Array.ZIP_PATH = myZIP_PATH
            'pGJSINI_Array.BACKUP_PATH = myBACKUP_PATH
            '2021/04/12 JBD9020 R03年度追加基金対応 DEL END
            pGJSINI_Array.REPORT_PDF_OUTKBN = myREPORT_PDF_OUTKBN

            pGJSINI_Array.YOHAKU_UP = C_YOHAKU_UP
            pGJSINI_Array.YOHAKU_DOWN = C_YOHAKU_DOWN
            pGJSINI_Array.YOHAKU_LEFT = C_YOHAKU_LEFT
            pGJSINI_Array.YOHAKU_RIGHT = C_YOHAKU_RIGHT

            pGJSINI_Array.SCR_BACKCOLOR = myBACKCOLOR
            pGJSINI_Array.SCR_BACKCOLOR_STRING = myBACKCOLOR_STRING

            Dim form As New frmGJ0010(pGJSINI_Array)
            form.Owner = Me
            ''form.pSel_KENCD = strKENCD          '現在選択されている行のキーを渡します
            'form.pSel_ITAKUCD = strITAKUCD      '現在選択されている行のキーを渡します
            'form.pSel_NO = intNo                '現在選択されている行のキーを渡します
            form.pSiyoKbn = dstDataSet.Tables(0).Rows(0)("SIYO_KBN")
            'form.paryKEY_9081 = paryKEY_9080

            'フォームクローズ
            Me.Visible = False

            form.ShowDialog()

            'dgv_Search.Refresh()
            'Call cmdSearch_Click(sender, e)
            'dgv_Search.Rows(pSel_POS).Selected = True

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

#Region "cmdEnd_Click 終了ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdEnd_Click
    '説明            :終了ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try
            'If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
            '    '処理を終了しますか？
            '    Exit Try
            'End If

            'フォームクローズ
            Me.Close()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'データベースへの接断
            Cnn.Close()
            'フォームクローズ
            Me.Close()
        End Try
    End Sub
#End Region

#End Region

#Region "*** ローカル関数 ***"

#Region "f_User_Check ログインユーザー情報チェック処理"

    Private Function f_User_Check(ByVal dstDataSet As DataSet) As Boolean
        Dim ret As Boolean = False

        Try

            With dstDataSet.Tables(0)

                'パスワードチェック
                If txt_PassWord.Text.TrimEnd <> WordHenkan("N", "S", .Rows(0)("PASS")).ToString.TrimEnd Then
                    Show_MessageBox_Add("W019", "ユーザーＩＤ、パスワードが正しくありません。") 'ユーザーＩＤ、パスワードが正しくありません。
                    Exit Try
                End If

                'パスワード有効期限チェック
                If .Rows(0)("PASS_KIGEN_DATE") < Now Then
                    'パスワード有効期限切れ
                    Show_MessageBox_Add("W019", "使用できません。管理者に確認してください。") '使用できません。管理者に確認してください。
                    Exit Try
                End If

                '利用停止チェック
                If Not .Rows(0)("TEISI_DATE") Is DBNull.Value Then
                    '利用停止ユーザー
                    Show_MessageBox_Add("W019", "使用できません。管理者に確認してください。") '使用できません。管理者に確認してください。
                    Exit Try
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
    '作成日          :2010/02/08 JBD368
    '------------------------------------------------------------------
    Private Function f_Input_Check() As Boolean
        Dim ret As Boolean = False

        Try

            'ユーザーＩＤ
            If txt_UserId.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "ユーザーＩＤ")      '@0は必須入力項目です。
                txt_UserId.Focus()
                Exit Try
            End If

            'パスワード
            If txt_PassWord.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "パスワード")      '@0は必須入力項目です。
                txt_PassWord.Focus()
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

#Region "f_Search_SQLMake 検索結果出力用ＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :検索結果出力用ＳＱＬ作成
    '引数            :無し
    '戻り値          :String(SQL文)
    '更新日          :2009/01/27 jbd368 チェックリスト2を追加
    '------------------------------------------------------------------
    Private Function f_Search_SQLMake() As String
        Dim sSql As String = String.Empty

        Try

            '検索
            sSql = " SELECT " & vbCrLf
            sSql += "     U.USER_NAME USER_NAME, " & vbCrLf
            sSql += "     U.PASS PASS, " & vbCrLf
            sSql += "     U.PASS_KIGEN_DATE PASS_KIGEN_DATE, " & vbCrLf
            sSql += "     U.SIYO_KBN SIYO_KBN, " & vbCrLf
            sSql += "     U.TEISI_DATE TEISI_DATE " & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "     TM_USER U " & vbCrLf

            'WHERE条件句を作成
            sSql += " WHERE" & vbCrLf
            sSql += "    (U.USER_ID = '" & txt_UserId.Text.TrimEnd & "')" & vbCrLf

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return sSql

    End Function
#End Region

#End Region



    Public Shared Function AddNumbers(ByVal num1 As Integer, ByVal num2 As Integer) As Integer
        Return num1 + num2
    End Function


End Class