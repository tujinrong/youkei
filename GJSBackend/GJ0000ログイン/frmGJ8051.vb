'*******************************************************************************
'*　　①　フォーム名　　　  frmGJ8051.vb
'*
'*　　②　機能概要　　　　　金融機関マスタ登録、変更
'*
'*　　③　作成日　　　　　　2009/10/23  BY JBD368　FMES用に変更
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

Public Class frmGJ8051

#Region "*** 変数定義 ***"
    Public pApName As String = "GJ8051"                 'プログラムＩＤ
    Public pRptName As String = "金融機関マスタ"        '帳票名
    Public pSyoriKbn As String = String.Empty           '処理区分
    Public pUKEIRE_YMDHMS As String = String.Empty      '処理開始時間
    Public pPCNAME As String = String.Empty             '端末ＩＤ
    Private pDataSet As New DataSet                     '検索結果一覧セット用データセット
    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ

    Public Const C_INSERT As Integer = 0                '新規処理
    Public Const C_UPDATE As Integer = 1                '変更処理

    Public pSel_BANKCD As String = String.Empty         '変更時、初期表示番号
    Public pSel_SITENCD As String = String.Empty        '変更時、初期表示番号
    Public pSel_NO As Integer = 0                       '変更時、該当データ行番号

    Private Const pKEY As String = "1234567890- "       'TEL、FAX入力可能文字

    Public paryKEY_8051 As New ArrayList
    Private pintRecNo As Integer = 0

#End Region

#Region "*** 画面制御関連 ***"
#Region "frmGJ8051_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ8051_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ8051_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean
        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear("C")

            ' 郵便番号用の書式を設定します。
            'txt_YuubinNo.Fields.AddRange("\D{3}-\D{4}")

            'コンピュータ名取得
            pPCNAME = System.Net.Dns.GetHostName

            '処理内容によって画面の初期状態をセット
            Select Case pSyoriKbn
                Case C_INSERT       '新規入力
                    '行遷移ボタン使用不可
                    cmdTop.Enabled = False
                    cmdBef.Enabled = False
                    cmdNext.Enabled = False
                    cmdLast.Enabled = False
                    txt_Now.Enabled = False

                    'データ区分：有効にフォーカスセット
                    'rbtn_DATA_KBN1.Select()
                    'rbtn_DATA_KBN1.Focus()
                    txt_BANK_CD.Focus()

                Case C_UPDATE       '変更
                    '画面内容をセット
                    If Not f_SetForm_TM_Bank(pSel_BANKCD) Then
                        Exit Try
                    End If
                    'コントロール使用不可
                    txt_BANK_CD.Enabled = False

                    '行遷移
                    lblTotal.Text = paryKEY_8051.Count
                    txt_Now.Text = pSel_NO

                    Call s_Set_RecValidate()

                    ''If rbtn_DATA_KBN1.Checked Then
                    ''    'データ区分：有効にフォーカスセット
                    ''    rbtn_DATA_KBN1.Select()
                    ''    rbtn_DATA_KBN1.Focus()
                    ''Else
                    ''    'データ区分：無効にフォーカスセット
                    ''    rbtn_DATA_KBN2.Select()
                    ''    rbtn_DATA_KBN2.Focus()
                    ''End If
                    txt_BANK_KANA.Focus()

            End Select

            pblnTextChange = False             '画面入力内容変更フラグ初期化


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

#Region "f_ObjectClear 画面クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ObjectClear
    '説明            :画面クリア処理
    '引数            :rKbn(処理区分)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ObjectClear(ByVal rKbn As String) As Boolean

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            For Each objCtrl In Me.Controls
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

                    Case "GroupBox"
                        'ｸﾞﾙｰﾌﾟﾎﾞｯｸｽ内のコントロールを順番にクリア
                        For Each objCtrl2 In objCtrl.controls
                            Select Case TypeName(objCtrl2)
                                Case "RadioButton"
                                    'ﾗｼﾞｵﾎﾞﾀﾝ
                                    If objCtrl2.TabIndex = 0 Then
                                        objCtrl2.Checked = True
                                    Else
                                        objCtrl2.Checked = False
                                    End If
                            End Select
                        Next

                    Case "Panel"
                        'パネル内のコントロールを順番にクリア
                        If objCtrl.Name = "pnlJyokyo" Then
                            For Each objCtrl2 In objCtrl.controls
                                Select Case TypeName(objCtrl2)
                                    Case "GcTextBox", "GcDate"
                                        'ﾃｷｽﾄﾎﾞｯｸｽ、日付型
                                        objCtrl2.Text = ""

                                    Case "CheckBox"
                                        'ﾁｪｯｸﾎﾞｯｸｽ
                                        objCtrl2.Checked = False
                                End Select
                            Next
                        End If
                End Select
            Next

            If rKbn = "C" Then
                txt_Now.Text = ""
                lblTotal.Text = ""
                pblnTextChange = False
            End If

            pDataSet.Clear()


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
        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '金融機関コード未登録チェック
            If Not f_Input_Check() Then
                Exit Try
            End If


            '保存処理確認
            'If Show_MessageBox("Q003", "") = DialogResult.Cancel Then    '保存します。よろしいですか？  '2024/2/7 UPD JBD453 R05年度OSバージョンアップ既存バグ修正のため キャンセルボタンが存在しないためNoボタンに修正　削除
            If Show_MessageBox("Q003", "") = DialogResult.No Then          '2024/2/7 UPD JBD453 R05年度OSバージョンアップ既存バグ修正
                Exit Try
            End If


            '保存あり
            'frmGJ8050.pSaveFlg = True                                                  '2010/10/16 DEL JBD200
            'frmGJ8050.pSaveBANK_CD = txt_BANK_CD.Text.TrimEnd                          '2010/10/16 DEL JBD200
            DirectCast(Owner, frmGJ8050).pSaveFlg = True                                '2010/10/16 ADD JBD200
            DirectCast(Owner, frmGJ8050).pSaveBANK_CD = txt_BANK_CD.Text.TrimEnd        '2010/10/16 ADD JBD200

            Select Case pSyoriKbn
                Case C_INSERT       '新規入力
                    'データ保存処理
                    If Not f_Data_Insert() Then
                        Exit Try
                    End If

                    Call f_ObjectClear("")        '画面初期化

                    ''rbtn_DATA_KBN1.Select()
                    ''rbtn_DATA_KBN1.Focus()       'データ区分にフォーカス
                    txt_BANK_CD.Focus()
                    pblnTextChange = False      '画面入力内容変更フラグ


                Case C_UPDATE       '変更
                    'データ保存処理
                    If Not f_Data_Update() Then
                        Exit Try
                    End If

                    ''If rbtn_DATA_KBN1.Checked Then
                    ''    'データ区分：有効にフォーカスセット
                    ''    rbtn_DATA_KBN1.Select()
                    ''    rbtn_DATA_KBN1.Focus()
                    ''Else
                    ''    'データ区分：無効にフォーカスセット
                    ''    rbtn_DATA_KBN2.Select()
                    ''    rbtn_DATA_KBN2.Focus()
                    ''End If
                    txt_BANK_KANA.Focus()
                    pblnTextChange = False      '画面入力内容変更フラグ

            End Select



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
    Private Sub cmdTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTop.Click
        Dim sKENCD As String = String.Empty
        Dim sSEIRICD As String = String.Empty

        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
                    '「いいえ」を選択
                    'カーソルを標準に戻す
                    Me.Cursor = Cursors.Default
                    Exit Try
                End If
            End If

            '行遷移処理
            If Not f_RecValidating(0) Then
                Exit Try
            End If

            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub
#End Region
#Region "cmdBef_Click 前行移動ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdBef_Click
    '説明            :前行移動ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdBef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBef.Click
        Dim sKENCD As String = String.Empty
        Dim sSEIRICD As String = String.Empty
        Dim intRecNo As Integer = 0
        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
                    '「いいえ」を選択
                    'カーソルを標準に戻す
                    Me.Cursor = Cursors.Default
                    Exit Try
                End If
            End If

            intRecNo = CInt(txt_Now.Text.TrimEnd) - 1

            '行遷移処理
            If Not f_RecValidating(intRecNo - 1) Then
                Exit Try
            End If

            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub
#End Region
#Region "cmdNext_Click 後行移動ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdNext_Click
    '説明            :後行移動ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        Dim sKENCD As String = String.Empty
        Dim sSEIRICD As String = String.Empty
        Dim intRecNo As Integer = 0
        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
                    '「いいえ」を選択
                    'カーソルを標準に戻す
                    Me.Cursor = Cursors.Default
                    Exit Try
                End If
            End If

            intRecNo = CInt(txt_Now.Text.TrimEnd) + 1

            '行遷移処理
            If Not f_RecValidating(intRecNo - 1) Then
                Exit Try
            End If

            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub
#End Region
#Region "cmdLast_Click 最終行移動ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdLast_Click
    '説明            :最終行移動ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLast.Click
        Dim sKENCD As String = String.Empty
        Dim sSEIRICD As String = String.Empty
        Dim intRecNo As Integer = 0
        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
                    '「いいえ」を選択
                    'カーソルを標準に戻す
                    Me.Cursor = Cursors.Default
                    Exit Try
                End If
            End If

            intRecNo = CInt(lblTotal.Text)

            '行遷移処理
            If Not f_RecValidating(intRecNo - 1) Then
                Exit Try
            End If

            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub
#End Region
#Region "txt_Now_Validating 現在行ﾃｷｽﾄﾎﾞｯｸｽ_Validatingｲﾍﾞﾝﾄ処理"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_Now_Validating
    '説明            :現在行ﾃｷｽﾄﾎﾞｯｸｽ_Validatingｲﾍﾞﾝﾄ処理
    '------------------------------------------------------------------
    Private Sub txt_Now_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Now.Validating
        Dim sKENCD As String = String.Empty
        Dim sSEIRICD As String = String.Empty
        Dim intRecNo As Integer = 0
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

            intRecNo = CInt(txt_Now.Text.TrimEnd)

            If CInt(txt_Now.Text.TrimEnd) > CInt(lblTotal.Text) Then
                txt_Now.Text = lblTotal.Text
                intRecNo = CInt(lblTotal.Text)
            End If

            '行遷移処理
            If Not f_RecValidating(intRecNo - 1) Then
                Exit Try
            End If

            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try


    End Sub
#End Region
#Region "f_RecValidating 行遷移処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_RecValidating
    '説明            :行遷移処理
    '------------------------------------------------------------------
    Private Function f_RecValidating(ByVal intRecNo As Integer) As Boolean
        Dim sBANKCD As String = String.Empty
        ''''Dim sSEIRICD As String = String.Empty
        Dim ret As Boolean = False
        Try
            'KEY取得
            Dim tKEY As New frmGJ8050.T_KEY
            tKEY = paryKEY_8051.Item(intRecNo)

            sBANKCD = tKEY.strBANK_CD.TrimEnd
            ''''sSEIRICD = tKEY.strSEIRICD.TrimEnd

            '画面内容をセット
            If Not f_SetForm_TM_Bank(sBANKCD) Then
                Exit Try
            End If

            '行遷移ボタンの制御
            txt_Now.Text = CStr(intRecNo + 1)
            Call s_Set_RecValidate()

            If rbtn_DATA_KBN1.Checked Then
                'データ区分：有効にフォーカスセット
                rbtn_DATA_KBN1.Select()
                rbtn_DATA_KBN1.Focus()
            Else
                'データ区分：無効にフォーカスセット
                rbtn_DATA_KBN2.Select()
                rbtn_DATA_KBN2.Focus()
            End If

            pblnTextChange = False             '画面入力内容変更フラグ初期化

            ret = True

        Catch ex As Exception
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret
    End Function
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
                    '「いいえ」を選択
                    Exit Try
                End If
            Else

            End If

            pblnTextChange = False      '画面入力内容変更フラグ初期化
            'フォームクローズ
            Me.AutoValidate = AutoValidate.Disable      '2010/10/16 ADD JBD200
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
    Private Sub s_FormControls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
                txt_BANK_CD.TextChanged, txt_BANK_KANA.TextChanged, txt_BANK_NAME.TextChanged
        pblnTextChange = True

    End Sub
#End Region
#Region "s_FormRadioButton_CheckedChanged 画面ﾗｼﾞｵﾎﾞﾀﾝCheckedChangedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :s_FormCheckBox_CheckedChanged
    '説明            :画面ﾗｼﾞｵﾎﾞﾀﾝCheckedChangedイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub s_FormRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
                rbtn_DATA_KBN1.CheckedChanged, rbtn_DATA_KBN2.CheckedChanged


        pblnTextChange = True

    End Sub

#End Region
#Region "s_FormCheckBox_CheckedChanged 画面ﾁｪｯｸﾎﾞｯｸｽCheckedChangedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :s_FormCheckBox_CheckedChanged
    '説明            :画面ﾁｪｯｸﾎﾞｯｸｽCheckedChangedイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub s_FormCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        pblnTextChange = True

    End Sub

#End Region

#End Region

#Region "*** データ登録関連 ***"
#Region "f_Data_Insert データ登録処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Insert
    '説明            :データ登録処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Insert() As Boolean
        Dim ret As Boolean = False

        Dim sKENCD As String = String.Empty
        Dim sSEIRICD As String = String.Empty

        Dim dstDataSet As New DataSet

        Try

            '金融機関マスタデータ存在チェック
            If Not f_Bank_Exist_Check() Then
                Exit Try
            End If

            '' 'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            '' 'myTrans = Cnn.BeginTransaction()
            '' 'blnIsTran = True

            '金融機関マスタ登録
            If Not f_TM_BANK_Insert() Then
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
#Region "f_Bank_Exist_Check 金融機関マスタデータ存在チェック"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Bank_Exist_Check
    '説明            :金融機関マスタデータ存在チェック
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_Bank_Exist_Check() As Boolean

        Dim sSql As String = String.Empty
        Dim dstDataSet As New DataSet
        Dim strSEIRICD As String = String.Empty
        Dim ret As Boolean = False
        Dim wBANK_CD As String

        Try
            '金融機関コード変換
            wBANK_CD = Format(CInt(txt_BANK_CD.Text.Trim), "0000")

            'データチェック
            sSql = " SELECT " & vbCrLf
            sSql += "  * " & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_BANK" & vbCrLf
            sSql += " WHERE" & vbCrLf
            sSql += "  BANK_CD = " & wBANK_CD & vbCrLf

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

#Region "f_TM_BANK_Insert 金融機関マスタデータ登録"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_BANK_Insert
    '説明            :金融機関マスタデータ登録
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_BANK_Insert() As Boolean
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False
        Dim wBANK_CD As String
        'Dim intDATAKBN As Integer

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Cmd.CommandText = "PKG_GJ8051.GJ8051_BANK_INS"

            '金融機関コード変換
            wBANK_CD = Format(CInt(txt_BANK_CD.Text.Trim), "0000")

            '引き渡し
            Dim paraBANK_CD As OracleParameter = Cmd.Parameters.Add("IN_BANK_BANK_CD", wBANK_CD)               '金融機関コード
            Dim paraBANK_KANA As OracleParameter = Cmd.Parameters.Add("IN_BANK_BANK_KANA", txt_BANK_KANA.Text.Trim)         '金融機関号(カナ)
            Dim paraBANK_NAME As OracleParameter = Cmd.Parameters.Add("IN_BANK_BANK_NAME", txt_BANK_NAME.Text.TrimEnd)      '金融機関号(漢字)
            ''If rbtn_DATA_KBN1.Checked = True Then
            ''    intDATAKBN = 0   '有効
            ''Else
            ''    intDATAKBN = 1   '無効
            ''End If
            ''Dim paraDATAKBN As OracleParameter = Cmd.Parameters.Add("IN_BANK_DATAKBN", intDATAKBN)                          'データ区分
            Dim paraDATAKBN As OracleParameter = Cmd.Parameters.Add("IN_BANK_DATAKBN", 0)                       'データ区分

            Dim paraREGDATE As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_REG_DATE", Now)                   'データ登録日
            Dim paraREGID As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_REG_ID", pLOGINUSERID)              'データ登録ＩＤ
            Dim paraUPDATE As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_UP_DATE", Now)                     'データ更新日
            Dim paraUPID As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_UP_ID", pLOGINUSERID)                'データ更新ＩＤ
            Dim paraCOMNM As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_COM_NAME", pPCNAME)                             'コンピュータ名

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

#Region "f_SetForm_TM_Bank 金融機関マスタデータ画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TM_Bank
    '説明            :金融機関マスタデータ画面セット
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_TM_Bank(ByVal strBANK_CD As String) As Boolean

        Dim sSql As String = String.Empty
        Dim dstDataSet As New DataSet
        Dim ret As Boolean = False

        Try

            sSql = " SELECT " & vbCrLf
            sSql += "  * " & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_BANK" & vbCrLf
            sSql += " WHERE" & vbCrLf
            sSql += "  BANK_CD = " & strBANK_CD.TrimEnd & vbCrLf

            Call f_Select_ODP(dstDataSet, sSql)

            If dstDataSet.Tables(0).Rows.Count > 0 Then
                Call f_ObjectClear("")        '画面初期化

                '画面にセット
                If Not f_SetForm_Data(dstDataSet) Then
                    Exit Try
                End If

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
#Region "f_Data_Update データ更新処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Update
    '説明            :データ更新処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Update() As Boolean
        Dim ret As Boolean = False

        Try

            '代理人マスタ登録
            If Not f_TM_BANK_Update() Then
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

#Region "f_TM_BANK_Update 金融機関マスタデータ更新"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_BANK_Update
    '説明            :金融機関マスタデータ更新
    '引数            :1.blnIsTran       Boolean     ﾄﾗﾝｻﾞｸｼｮﾝフラグ
    '                 2.myTrans         Oracle.DataAccess.Client.OracleTransaction
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_BANK_Update() As Boolean
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Cmd.CommandText = "PKG_GJ8051.GJ8051_BANK_UPD"

            '引き渡し
            Dim paraBANK_CD As OracleParameter = Cmd.Parameters.Add("IN_BANK_BANK_CD", txt_BANK_CD.Text.Trim)               '金融機関コード
            Dim paraBANK_KANA As OracleParameter = Cmd.Parameters.Add("IN_BANK_BANK_KANA", txt_BANK_KANA.Text.Trim)         '金融機関号(カナ)
            Dim paraBANK_NAME As OracleParameter = Cmd.Parameters.Add("IN_BANK_BANK_NAME", txt_BANK_NAME.Text.TrimEnd)      '金融機関号(漢字)
            ''If rbtn_DATA_KBN1.Checked Then
            ''    intDATAKBN = 0   '有効
            ''Else
            ''    intDATAKBN = 1   '無効
            ''End If
            ''Dim paraDATAKBN As OracleParameter = Cmd.Parameters.Add("IN_BANK_DATAKBN", intDATAKBN)                          'データ区分
            Dim paraDATAKBN As OracleParameter = Cmd.Parameters.Add("IN_BANK_DATAKBN", 0)                                   'データ区分

            Dim paraREGDATE As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_REG_DATE", Now)                               'データ登録日
            Dim paraREGID As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_REG_ID", pLOGINUSERID)                                  'データ登録ＩＤ
            Dim paraUPDATE As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_UP_DATE", Now)                                 'データ更新日
            Dim paraUPID As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_UP_ID", pLOGINUSERID)                                    'データ更新ＩＤ
            Dim paraCOMNM As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_COM_NAME", pPCNAME)                             'コンピュータ名

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
            '必須入力チェック
            '金融機関コード
            If txt_BANK_CD.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "金融機関コード")      '@0は必須入力項目です。
                txt_BANK_CD.Focus()
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
#Region "f_SetForm_Data 金融機関マスタデータ画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_Data
    '説明            :金融機関マスタデータ画面セット
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_Data(ByVal dstDataSet As DataSet) As Boolean

        Dim ret As Boolean = False
        Dim ea As New System.ComponentModel.CancelEventArgs

        Try

            With dstDataSet.Tables(0)
                'データ区分
                If WordHenkan("N", "S", .Rows(0)("DATA_KBN")) = "" Then
                    rbtn_DATA_KBN1.Checked = False
                    rbtn_DATA_KBN2.Checked = False
                ElseIf WordHenkan("N", "S", .Rows(0)("DATA_KBN")) = "0" Then
                    rbtn_DATA_KBN1.Checked = True
                    rbtn_DATA_KBN2.Checked = False

                ElseIf WordHenkan("N", "S", .Rows(0)("DATA_KBN")) = "1" Then
                    rbtn_DATA_KBN1.Checked = False
                    rbtn_DATA_KBN2.Checked = True
                End If
                '金融機関コード
                txt_BANK_CD.Text = WordHenkan("N", "S", .Rows(0)("BANK_CD"))
                '金融機関名（ｶﾅ）
                txt_BANK_KANA.Text = WordHenkan("N", "S", .Rows(0)("BANK_KANA"))
                '金融機関名（漢字）
                txt_BANK_NAME.Text = WordHenkan("N", "S", .Rows(0)("BANK_NAME"))

            End With

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "s_Set_RecValidate 行遷移ボタン制御"
    '------------------------------------------------------------------
    'プロシージャ名  :s_Set_RecValidate
    '説明            :行遷移ボタン制御
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Sub s_Set_RecValidate()
        Dim intRecMax As Integer = 0

        Try

            If txt_Now.Text.TrimEnd = "" OrElse txt_Now.Text.TrimEnd <= 0 Then
                txt_Now.Text = 1
            End If

            If lblTotal.Text.TrimEnd = "" OrElse lblTotal.Text.TrimEnd = "0" Then
                lblTotal.Text = "1"
            End If

            intRecMax = CInt(lblTotal.Text.TrimEnd)

            If txt_Now.Text.TrimEnd > intRecMax Then
                txt_Now.Text = intRecMax
            End If

            'If paryKEY.Count = 0 Then
            '    maryListMeisai.Add(New T_SID2_D)
            '    Call LoSubVarClear_Meisai()
            'End If

            If lblTotal.Text = 1 Then
                '該当データ１件のみ
                cmdTop.Enabled = False
                cmdBef.Enabled = False
                cmdNext.Enabled = False
                cmdLast.Enabled = False
            ElseIf txt_Now.Text.TrimEnd = 1 OrElse txt_Now.Text.TrimEnd = 0 Then
                '先頭行を表示
                cmdTop.Enabled = False
                cmdBef.Enabled = False
                cmdNext.Enabled = True
                cmdLast.Enabled = True
            ElseIf txt_Now.Text.TrimEnd = intRecMax Then
                '最終行を表示
                cmdTop.Enabled = True
                cmdBef.Enabled = True
                cmdNext.Enabled = False
                cmdLast.Enabled = False
            Else
                '中間の行を表示
                cmdTop.Enabled = True
                cmdBef.Enabled = True
                cmdNext.Enabled = True
                cmdLast.Enabled = True
            End If

            pintRecNo = CInt(txt_Now.Text.TrimEnd)

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub
#End Region

#End Region



End Class
