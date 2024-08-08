'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ8061.vb
'*
'*　　②　機能概要　　　　　同一生産者マスタメンテンテナンス
'*
'*　　③　作成日　　　　　　2014/08/27　BY JBD
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

Public Class frmGJ8061

#Region "***変数定義***"

    ''' <summary>
    ''' 固定項目
    ''' </summary>
    ''' <remarks></remarks>
    Property p8060_KI As Integer

    ''' <summary>
    ''' 処理状況
    ''' </summary>
    ''' <remarks></remarks>
    Property pLoadErr As Boolean


    ''' <summary>
    ''' グリッドキーリスト
    ''' </summary>
    ''' <remarks></remarks>
    Public paryKEY_8060 As New List(Of frmGJ8060.T_KEY)

    ''' <summary>
    ''' カレント主キー
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pCurrentKey As frmGJ8060.T_KEY

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
    Property pSyoriKbn As Enu_SyoriKubun

    ''' <summary>
    '''  画面入力内容変更フラグ
    ''' </summary>
    ''' <remarks></remarks>
    Private loblnTextChange As Boolean                   '画面入力内容変更フラグ

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
    ''' データ更新時刻避難用DATE
    ''' </summary>
    ''' <remarks></remarks>
    Private lo_REG_DATE As Date = Nothing
    ''' <summary>
    ''' データ更新時避難用ID
    ''' </summary>
    ''' <remarks></remarks>
    Private lo_REG_ID As String = ""

#End Region

#Region "***画面制御関連***"

#Region "frmFS2020_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmEM2020_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmXXXLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean
        Try

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear("C")

            '★初期コントロールにフォーカスセット
            cob_KEN_CD.Focus()         '2014/05/12　修正

            '処理内容によって画面の初期状態をセット
            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert       '新規入力
                    '行遷移ボタン使用不可
                    cmdTop.Enabled = False
                    cmdBef.Enabled = False
                    cmdNext.Enabled = False
                    cmdLast.Enabled = False
                    txt_Now.Enabled = False
                    txt_Now.Text = ""
                    lblTotal.Text = ""
                    'R05年度OSバージョンアップ改修　既存バグ修正　コードでなくプロパティで制御するように変更 2024/03/13 JBD453 DEL START
                    '必須入力制御
                    'f_InputChk_Set("C")
                    '★初期コントロールにフォーカスセット
                    'R05年度OSバージョンアップ改修　既存バグ修正　コードでなくプロパティで制御するように変更 DEL END
                    txt_ITAKU_CD.Focus()         '2014/05/12　修正

                Case Enu_SyoriKubun.Update       '変更

                    '画面内容をセット
                    If Not f_SetForm_Data(pCurrentKey) Then
                        pLoadErr = True
                        Throw New Exception("該当データが存在しませんでした")
                    End If

                    '主キーコントロール使用不可
                    txt_ITAKU_CD.Enabled = False

                    '行遷移
                    lblTotal.Text = paryKEY_8060.Count
                    txt_Now.Text = pSel_NO

                    Call s_Set_RecValidate()

            End Select

            f_setControlChangeEvents()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

    End Sub

#End Region

#End Region

#Region "***画面ボタンクリック関連***"

#Region "cmdSav_Click 保存ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSav_Click
    '説明            :保存ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim ea As New System.ComponentModel.CancelEventArgs
        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '事前チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '修正モードで変更なしのとき、メッセージ表示
            If pSyoriKbn = Enu_SyoriKubun.Update AndAlso Not loblnTextChange Then
                Show_MessageBox("I502", "")
                Exit Try
            End If

            '保存処理確認
            If Show_MessageBox("Q003", "") = DialogResult.No Then    '保存します。よろしいですか？
                Exit Try
            End If

            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert       '新規入力

                    pCurrentKey.ITAKU_CD = txt_ITAKU_CD.Text.Trim

                    'データ保存処理
                    If Not f_Data_Update() Then
                        Exit Try
                    End If

                    '画面初期化
                    Call f_ObjectClear("")
                    'フォーカスセット
                    txt_ITAKU_CD.Select()

                Case Enu_SyoriKubun.Update       '変更
                    'データ保存処理
                    If Not f_Data_Update() Then
                        Exit Try
                    End If
                    'フォーカスセット
                    cob_KEN_CD.Select()

            End Select

            loblnTextChange = False      '画面入力内容変更フラグ

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
            If loblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then
                    Exit Try
                End If
            End If

            '親フォームに現在選択されている行のキーを渡します
            DirectCast(Owner, frmGJ8060).pSel_POS = pSel_NO - 1

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

#Region "行移動ボタンクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdTopBefNextLast_Click
    '説明            :行移動ボタンクリック時処理
    '------------------------------------------------------------------
    Private Sub cmdTopBefNextLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBef.Click, cmdLast.Click, cmdNext.Click, cmdTop.Click
        Dim intRecNo As Integer = 0
        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            If loblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
                    Exit Try
                End If
            End If

            Select Case True
                Case sender.Equals(cmdTop) '最初
                    intRecNo = 0
                Case sender.Equals(cmdBef) '１つ前
                    intRecNo = CInt(txt_Now.Text.TrimEnd) - 1 - 1
                Case sender.Equals(cmdNext) '１つ次
                    intRecNo = CInt(txt_Now.Text.TrimEnd)
                Case sender.Equals(cmdLast) '最後
                    intRecNo = CInt(lblTotal.Text) - 1
            End Select

            '行遷移処理
            If Not f_RecValidating(intRecNo) Then
                Exit Try
            End If

            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

#End Region

#Region "*** 画面コントロール制御関連 ***"

#Region "委託先関係"
    'R05年度OSバージョンアップ改修　既存バグ修正　コードでなくプロパティで制御するように変更 2024/03/13 JBD453 DEL START
    '------------------------------------------------------------------
    'プロシージャ名  :txt_ITAKU_CD_TextChanged
    '説明            :委託先 TextChanged
    '------------------------------------------------------------------
    'Private Sub txt_ITAKU_CD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ITAKU_CD.TextChanged

    '    f_InputChk_Set("")

    'End Sub
    'R05年度OSバージョンアップ改修　既存バグ修正　コードでなくプロパティで制御するように変更 DEL END

    '------------------------------------------------------------------
    'プロシージャ名  :txt_ITAKU_CD_Validating
    '説明            :委託先 Validating
    '------------------------------------------------------------------
    Private Sub txt_ITAKU_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_ITAKU_CD.Validating

        Try
            If txt_ITAKU_CD.Text = "" Then
                Exit Try
            End If

            '同一委託先登録されている。
            If f_ExsistData() Then
                Call Show_MessageBox("W001", "")    'データは既に登録されています。
                e.Cancel = True
                Exit Try
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub


#End Region

#Region "都道府県関連"
    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_F_SelectedIndexChanged
    '説明            :都道府県コード項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEN_CD.SelectedIndexChanged

        cob_KEN_NM.SelectedIndex = cob_KEN_CD.SelectedIndex

        '住所１表示
        txt_ADDR_1.Text = cob_KEN_NM.Text

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_NM_SelectedIndexChanged
    '説明            :都道府県名項目変更時処理
    '------------------------------------------------------------------
    ''' <summary>
    ''' 都道府県名項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KEN_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEN_NM.SelectedIndexChanged

        cob_KEN_CD.SelectedIndex = cob_KEN_NM.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_NM_SelectedIndexChanged
    '説明            :都道府県コード確定時処理
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_KEN_CD.Validating

        If cob_KEN_CD.Text = "" Then
            Exit Sub
        End If

        '先頭ゼロを削除
        DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString

        cob_KEN_CD.SelectedValue = cob_KEN_CD.Text
        If cob_KEN_CD.SelectedValue Is Nothing Then
            cob_KEN_CD.SelectedIndex = -1
            cob_KEN_NM.SelectedIndex = -1
            Show_MessageBox_Add("W012", "都道府県") '指定された@0が正しくありません。
            cob_KEN_CD.Focus()
        End If

    End Sub

#End Region

#Region "現在行テキストボックス変更時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_Now_Validating
    '説明            :現在行テキストボックス変更時処理
    '------------------------------------------------------------------
    Private Sub txt_Now_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Now.Validating
        Dim sKENCD As String = String.Empty
        Dim sSEIRICD As String = String.Empty
        Dim intRecNo As Integer = 0
        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            If loblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
                    Exit Try
                End If
            End If

            If txt_Now.Text.Trim = "" OrElse CInt(txt_Now.Text.Trim) < 1 Then
                txt_Now.Text = 1
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
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#End Region

#Region "*** データ登録関連 ***"

#Region "f_Data_Insert 委託先更新処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Insert
    '説明            :委託先更新処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Update() As Boolean
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False
        Dim wNow As Date = Now

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure


            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert      '新規入力
                    Cmd.CommandText = "PKG_GJ8061.GJ8061_JIMUITAKU_INS"
                Case Enu_SyoriKubun.Update      '変更入力
                    Cmd.CommandText = "PKG_GJ8061.GJ8061_JIMUITAKU_UPD"
            End Select


            '引き渡し

            '期 
            Cmd.Parameters.Add("IN_KI", p8060_KI)
            '事務委託先番号 
            Cmd.Parameters.Add("IN_ITAKU_CD", txt_ITAKU_CD.Text)
            '都道府県コード
            Cmd.Parameters.Add("IN_KEN_CD", cob_KEN_CD.Text)
            '事務委託先名（正式）
            Cmd.Parameters.Add("IN_ITAKU_NAME", txt_ITAKU_NAME.Text)
            '事務委託先名（略称）
            Cmd.Parameters.Add("IN_ITAKU_RYAKU", txt_ITAKU_RYAKU.Text)
            '代表者名
            If txt_DAIHYO_NAME.Text.Trim = "" Then
                Cmd.Parameters.Add("IN_DAIHYO_NAME", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_DAIHYO_NAME", txt_DAIHYO_NAME.Text)
            End If
            '担当者名  
            If txt_TANTO_NAME.Text.Trim = "" Then
                Cmd.Parameters.Add("IN_TANTO_NAME", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_TANTO_NAME", txt_TANTO_NAME.Text)
            End If

            '郵便番号
            Cmd.Parameters.Add("IN_ADDR_POST", msk_ADDR_POST.Value)
            '住所１
            Cmd.Parameters.Add("IN_ADDR_1", txt_ADDR_1.Text)
            '住所２
            If txt_ADDR_2.Text.Trim = "" Then
                Cmd.Parameters.Add("IN_ADDR_2", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_ADDR_2", txt_ADDR_2.Text)
            End If
            '住所３
            If txt_ADDR_3.Text.Trim = "" Then
                Cmd.Parameters.Add("IN_ADDR_3", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_ADDR_3", txt_ADDR_3.Text)
            End If
            '住所４
            If txt_ADDR_4.Text.Trim = "" Then
                Cmd.Parameters.Add("IN_ADDR_4", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_ADDR_4", txt_ADDR_4.Text)
            End If
            '電話番号
            Cmd.Parameters.Add("IN_ADDR_TEL", txt_ADDR_TEL.Text)
            'ＦＡＸ
            If txt_ADDR_FAX.Text = "" Then
                Cmd.Parameters.Add("IN_ADDR_FAX", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_ADDR_FAX", txt_ADDR_FAX.Text)
            End If
            'メールアドレス
            If txt_ADDR_E_MAIL.Text = "" Then
                Cmd.Parameters.Add("IN_ADDR_E_MAIL", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_ADDR_E_MAIL", txt_ADDR_E_MAIL.Text)
            End If
            '金融機関情報印字有無(1:有 2:無)
            If rbtn_BANK_INJI_KBN1.Checked Then
                Cmd.Parameters.Add("IN_BANK_INJI_KBN", 1)
            Else
                Cmd.Parameters.Add("IN_BANK_INJI_KBN", 2)
            End If
            'まとめ先
            If txt_MATOMESAKI.Text = "" Then
                Cmd.Parameters.Add("IN_MATOMESAKI", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_MATOMESAKI", txt_MATOMESAKI.Text)
            End If
            '申込書類
            If txt_MOSIKOMISYORUI.Text = "" Then
                Cmd.Parameters.Add("IN_MOSIKOMISYORUI", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_MOSIKOMISYORUI", txt_MOSIKOMISYORUI.Text)
            End If
            '請求書・契約書
            If txt_SEIKYUSYO.Text = "" Then
                Cmd.Parameters.Add("IN_SEIKYUSYO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_SEIKYUSYO", txt_SEIKYUSYO.Text)
            End If
            '入金方法
            If txt_NYUKINHOHO.Text = "" Then
                Cmd.Parameters.Add("IN_NYUKINHOHO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_NYUKINHOHO", txt_NYUKINHOHO.Text)
            End If
            'ラベル発行
            If txt_LABELHAKKO.Text = "" Then
                Cmd.Parameters.Add("IN_LABELHAKKO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_LABELHAKKO", txt_LABELHAKKO.Text)
            End If
            '除外フラグ
            If txt_JYOGAI_FLG.Text = "" Then
                Cmd.Parameters.Add("IN_JYOGAI_FLG", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_JYOGAI_FLG", txt_JYOGAI_FLG.Text)
            End If
            '備考    BIKO
            If txt_BIKO.Text = "" Then
                Cmd.Parameters.Add("IN_BIKO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_BIKO", txt_BIKO.Text)
            End If

            '共通
            If pSyoriKbn = Enu_SyoriKubun.Insert Then
                'データ登録日
                Cmd.Parameters.Add("IN_REG_DATE", wNow)
                'データ登録ＩＤ
                Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
            End If

            'データ更新日
            Cmd.Parameters.Add("IN_UP_DATE", wNow)
            'データ更新ＩＤ
            Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            'コンピュータ名
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

            ret = True

        Catch ex As Exception
            '共通例外処理
            If ex.Message <> "Err" Then
                Show_MessageBox("", ex.Message)
            End If
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
        End Try

        Return ret
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
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GroupBox
                    For Each wkItem In DirectCast(wkCtrl, JBD.Gjs.Win.GroupBox).Controls
                        If TypeOf wkItem Is JBD.Gjs.Win.RadioButton Then
                            AddHandler DirectCast(wkItem, JBD.Gjs.Win.RadioButton).CheckedChanged, AddressOf f_setChanged
                        End If
                    Next

                    '↓===== 2012/01/27 JBD200 ADD タブコントロール内の項目の変更判定追加 =====↓
                Case TypeOf wkCtrl Is System.Windows.Forms.TabControl
                    For Each wkItem In DirectCast(wkCtrl, System.Windows.Forms.TabControl).Controls

                        Select Case True
                            Case TypeOf wkItem Is System.Windows.Forms.TabPage

                                For Each wkItem2 In DirectCast(wkItem, System.Windows.Forms.TabPage).Controls

                                    Select Case True
                                        Case TypeOf wkItem2 Is JBD.Gjs.Win.GcMask
                                            AddHandler DirectCast(wkItem2, JBD.Gjs.Win.GcMask).TextChanged, AddressOf f_setChanged
                                        Case TypeOf wkItem2 Is JBD.Gjs.Win.GcTextBox
                                            AddHandler DirectCast(wkItem2, JBD.Gjs.Win.GcTextBox).TextChanged, AddressOf f_setChanged

                                    End Select

                                Next

                        End Select

                    Next
                    '↑===== 2012/01/27 JBD200 ADD タブコントロール内の項目の変更判定追加 =====↑

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
        Dim sSql As String = String.Empty
        Dim dstDataControl As New DataSet
        Dim wHasu As Integer = 0
        Dim ret As Boolean = False

        Try

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            f_ClearFormALL(Me, wKbn)

            'ヘッダ表示
            lbl_KI.Text = "第" & p8060_KI & "期"

            If wKbn = "C" Then
                'コンボボックスセット
                If Not f_ComboBox_Set() Then
                    Exit Try
                End If
            End If

            'R05年度OSバージョンアップ改修　既存バグ修正　コードでなくプロパティで制御するように変更 2024/03/13 JBD453 DEL START
            '必須入力制御
            'f_InputChk_Set("C")
            'R05年度OSバージョンアップ改修　既存バグ修正　コードでなくプロパティで制御するように変更 DEL END

            '====初期値設定======================
            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert

                Case Enu_SyoriKubun.Update

            End Select

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
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

            '県マスタコンボセット
            If Not f_Ken_Data_Select(cob_KEN_CD, cob_KEN_NM, True) Then
                Exit Try
            End If

            'コンボボックス初期化
            cob_KEN_CD.Text = ""

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
    'R05年度OSバージョンアップ改修　既存バグ修正　コードでなくプロパティで制御するように変更 2024/03/13 JBD453 DEL START
    '#Region "f_InputChk_Set 必須入力制御処理"
    '    '------------------------------------------------------------------
    '    'プロシージャ名  :f_ComboBox_Set
    '    '説明            :コ必須入力制御処理
    '    '引数            :なし
    '    '戻り値          :Boolean(正常True/エラーFalse)
    '    '------------------------------------------------------------------
    '    Private Function f_InputChk_Set(ByVal wKbn As String) As Boolean
    '        Dim ret As Boolean = False

    '        Try
    '            If txt_ITAKU_CD.Text.Trim = "" Then
    '                If wKbn = "C" Then
    '                    cob_KEN_CD.InputCheck = True
    '                    cob_KEN_NM.InputCheck = True
    '                    msk_ADDR_POST.InputCheck = True
    '                    txt_ADDR_2.InputCheck = True
    '                    txt_ADDR_TEL.InputCheck = True
    '                Else
    '                    cob_KEN_CD.InputCheck = False
    '                    cob_KEN_NM.InputCheck = False
    '                    msk_ADDR_POST.InputCheck = False
    '                    txt_ADDR_2.InputCheck = False
    '                    txt_ADDR_TEL.InputCheck = False
    '                End If
    '            ElseIf CInt(txt_ITAKU_CD.Text.Trim) = 0 OrElse CInt(txt_ITAKU_CD.Text.Trim) = 999 Then
    '                cob_KEN_CD.InputCheck = False
    '                cob_KEN_NM.InputCheck = False
    '                msk_ADDR_POST.InputCheck = False
    '                txt_ADDR_2.InputCheck = False
    '                txt_ADDR_TEL.InputCheck = False
    '            Else
    '                cob_KEN_CD.InputCheck = True
    '                cob_KEN_NM.InputCheck = True
    '                msk_ADDR_POST.InputCheck = True
    '                txt_ADDR_2.InputCheck = True
    '                txt_ADDR_TEL.InputCheck = True
    '            End If

    '            ret = True

    '        Catch ex As Exception
    '            '共通例外処理
    '            Show_MessageBox("", ex.Message)
    '        End Try

    '        Return ret

    '    End Function
    '#End Region
    'R05年度OSバージョンアップ改修　既存バグ修正　コードでなくプロパティで制御するように変更 DEL END

#Region "f_ExsistData データ有無チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ExsistData
    '説明            :データ有無チェック
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ExsistData() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            wSql = "SELECT * FROM TM_JIMUITAKU WHERE KI = " & p8060_KI & " AND ITAKU_CD = " & txt_ITAKU_CD.Text.Trim

            'SQL実効
            If Not f_Select_ODP(wkDS, wSql) Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count > 0 Then
                'データ有り:TRUE
                ret = True
            Else
                'データ無し:FALSE
                ret = False
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region
#Region "f_SetForm_Data 初期画面表示(修正)処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_Data(ByVal wkKey As frmGJ8060.T_KEY) As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Dim sSeisanTaniKbn As String = ""


        Try

            'SQL
            wSql = "SELECT * FROM TM_JIMUITAKU " & _
                   "WHERE KI = " & p8060_KI & _
                   "  AND ITAKU_CD = " & pCurrentKey.ITAKU_CD

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Return False
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                'データ無し
                Exit Try
            End If

            With wkDS.Tables(0)


                '都道府県
                If WordHenkan("N", "S", .Rows(0)("KEN_CD")) = "" Then
                    cob_KEN_CD.SelectedIndex = -1
                Else
                    cob_KEN_CD.Text = WordHenkan("N", "S", .Rows(0)("KEN_CD"))
                End If
                '委託先
                txt_ITAKU_CD.Text = pCurrentKey.ITAKU_CD
                'R05年度OSバージョンアップ改修　既存バグ修正　コードでなくプロパティで制御するように変更 2024/03/13 JBD453 DEL START
                '必須入力制御
                'f_InputChk_Set("C")
                'R05年度OSバージョンアップ改修　既存バグ修正　コードでなくプロパティで制御するように変更 DEL END
                '委託先名(正式)
                txt_ITAKU_NAME.Text = WordHenkan("N", "S", .Rows(0)("ITAKU_NAME"))
                '委託先名(略称)
                txt_ITAKU_RYAKU.Text = WordHenkan("N", "S", .Rows(0)("ITAKU_RYAKU"))
                '代表者名
                txt_DAIHYO_NAME.Text = WordHenkan("N", "S", .Rows(0)("DAIHYO_NAME"))
                '担当者名
                txt_TANTO_NAME.Text = WordHenkan("N", "S", .Rows(0)("TANTO_NAME"))

                '郵便番号
                msk_ADDR_POST.Value = WordHenkan("N", "S", .Rows(0)("ADDR_POST"))
                '住所１
                txt_ADDR_1.Text = WordHenkan("N", "S", .Rows(0)("ADDR_1"))
                '住所２
                txt_ADDR_2.Text = WordHenkan("N", "S", .Rows(0)("ADDR_2"))
                '住所３
                txt_ADDR_3.Text = WordHenkan("N", "S", .Rows(0)("ADDR_3"))
                '住所４
                txt_ADDR_4.Text = WordHenkan("N", "S", .Rows(0)("ADDR_4"))
                '電話番号
                txt_ADDR_TEL.Text = WordHenkan("N", "S", .Rows(0)("ADDR_TEL"))
                'FAX
                txt_ADDR_FAX.Text = WordHenkan("N", "S", .Rows(0)("ADDR_FAX"))
                'メールアドレス
                txt_ADDR_E_MAIL.Text = WordHenkan("N", "S", .Rows(0)("ADDR_E_MAIL"))


                '金融機関情報印字有無(1:有 2:無)   
                If WordHenkan("N", "S", .Rows(0)("BANK_INJI_KBN")) = 1 Then
                    '印字有り
                    rbtn_BANK_INJI_KBN1.Checked = True
                Else
                    '印字無し
                    rbtn_BANK_INJI_KBN2.Checked = True
                End If
                'まとめ先
                txt_MATOMESAKI.Text = WordHenkan("N", "S", .Rows(0)("MATOMESAKI"))
                '申込書類
                txt_MOSIKOMISYORUI.Text = WordHenkan("N", "S", .Rows(0)("MOSIKOMISYORUI"))
                '請求書・契約書
                txt_SEIKYUSYO.Text = WordHenkan("N", "S", .Rows(0)("SEIKYUSYO"))
                '入金方法
                txt_NYUKINHOHO.Text = WordHenkan("N", "S", .Rows(0)("NYUKINHOHO"))
                'ラベル発行
                txt_LABELHAKKO.Text = WordHenkan("N", "S", .Rows(0)("LABELHAKKO"))
                '除外フラグ
                txt_JYOGAI_FLG.Text = WordHenkan("N", "S", .Rows(0)("JYOGAI_FLG"))
                '備考
                txt_BIKO.Text = WordHenkan("N", "S", .Rows(0)("BIKO"))

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
        Dim wkControl As Control
        Dim wkControlName As String

        Try

            '==FromToチェック==================

            '==必須チェック==================

            wkControlName = "委託先番号"
            wkControl = txt_ITAKU_CD
            If wkControl.Text Is Nothing OrElse wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            '2015/04/03 委託先＝0、999のとき、住所は必須入力にしない
            If CInt(txt_ITAKU_CD.Text.Trim) = 0 OrElse CInt(txt_ITAKU_CD.Text.Trim) = 999 Then
                'チェックなし
            Else
                '必須
                wkControlName = "都道府県"
                wkControl = cob_KEN_CD
                If wkControl.Text Is Nothing OrElse wkControl.Text = "" Then
                    Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
                End If

            End If

            wkControlName = "委託先名(正式)"
            wkControl = txt_ITAKU_NAME
            If wkControl.Text Is Nothing OrElse wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "委託先名(略称)"
            wkControl = txt_ITAKU_RYAKU
            If wkControl.Text Is Nothing OrElse wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            '2015/03/21 委託先＝0、999のとき、住所は必須入力にしない
            If CInt(txt_ITAKU_CD.Text.Trim) = 0 OrElse CInt(txt_ITAKU_CD.Text.Trim) = 999 Then
                'チェックなし
            Else
                wkControlName = "郵便番号"
                wkControl = msk_ADDR_POST
                If msk_ADDR_POST.Value Is Nothing OrElse msk_ADDR_POST.Value = "" OrElse msk_ADDR_POST.Value.Count <> 7 Then
                    Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
                End If

                'wkControlName = "住所1"
                'wkControl = txt_ADDR_1
                wkControlName = "住所2"
                wkControl = txt_ADDR_2
                If wkControl.Text Is Nothing OrElse wkControl.Text = "" Then
                    Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
                End If

                wkControlName = "電話番号"
                wkControl = txt_ADDR_TEL
                If wkControl.Text = "" Then
                    Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
                End If

            End If

            '==いろいろチェック==================

            'Select Case pSyoriKbn
            '    Case Enu_SyoriKubun.Insert '新規登録時チェック
            '
            '    Case Enu_SyoriKubun.Update '更新時チェック
            '
            'End Select

            ''住所2が未入力
            'If txt_ADDR_2.Text Is Nothing OrElse txt_ADDR_2.Text = "" Then
            '    '住所3が未入力以外はエラー
            '    If txt_ADDR_3.Text Is Nothing OrElse txt_ADDR_3.Text = "" Then
            '    Else
            '        Call Show_MessageBox_Add("I007", "前の住所入力欄が未入力です。")
            '        txt_ADDR_2.Focus()
            '        Exit Try
            '    End If
            'End If

            '住所3が未入力
            If txt_ADDR_3.Text Is Nothing OrElse txt_ADDR_3.Text = "" Then
                '住所4が未入力以外はエラー
                If txt_ADDR_4.Text Is Nothing OrElse txt_ADDR_4.Text = "" Then
                Else
                    Call Show_MessageBox_Add("I007", "前の住所入力欄が未入力です。")
                    txt_ADDR_4.Focus()
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

#Region "f_RecValidating 行遷移処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_RecValidating
    '説明            :行遷移処理
    '引数            :行番号
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_RecValidating(ByVal intRecNo As Integer) As Boolean
        Dim sKENCD As String = String.Empty
        Dim sITAKUCD As String = String.Empty
        Dim sUP_FLG As String = String.Empty
        Dim sSEQNO As String = String.Empty

        Dim ret As Boolean = False
        Try
            '★KEY取得
            Dim tKEY As New frmGJ8060.T_KEY
            tKEY = paryKEY_8060.Item(intRecNo)
            pCurrentKey = tKEY

            '画面に内容をセット
            If Not f_SetForm_Data(tKEY) Then
                Throw New Exception("該当データが存在しませんでした")
            End If

            '行遷移ボタンの制御
            txt_Now.Text = CStr(intRecNo + 1)
            Call s_Set_RecValidate()


            '★初期コントロールにフォーカスセット
            cob_KEN_CD.Focus()

            loblnTextChange = False             '画面入力内容変更フラグ初期化

            ret = True

        Catch ex As Exception
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

        Return ret
    End Function

#End Region

#Region "s_Set_RecValidate 行遷移ボタン制御"
    '------------------------------------------------------------------
    'プロシージャ名  :s_Set_RecValidate
    '説明            :行遷移ボタン制御
    '引数            :行番号
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

            pSel_NO = CInt(txt_Now.Text.TrimEnd)

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#End Region

    Private Sub txt_Now_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Now.TextChanged

    End Sub

End Class
