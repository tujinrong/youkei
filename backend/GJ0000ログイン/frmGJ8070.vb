'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ8070.vb
'*
'*　　②　機能概要　　　　　互助金発生・終了要件登録
'*
'*　　③　作成日　　　　　　2014/02/02 JBD999
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

Public Class frmGJ8070

#Region "***変数定義***"

    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ

#End Region

#Region "***画面制御関連***"

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
            ret = f_ObjectEnabledSet(True)
            pblnTextChange = False             '画面入力内容変更フラグ初期化


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

    End Sub

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

    ''' <summary>
    ''' コントロール変更時処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub f_setChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pblnTextChange = True
    End Sub

    ''' <summary>
    ''' 画面クリア
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_ObjectClear(ByVal rKbn As String) As Boolean

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            f_ClearFormALL(Me, rKbn)

            '====初期値設定======================

            '処理対象期・年度マスタより期と回数をセット
            If Not f_Syori_Ki_Set() Then
                Exit Try
            End If

            '初期コントロールにフォーカスセット
            numKI.Focus()


            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function

#End Region

#Region "***画面ボタンクリック関連***"

#Region "cmdSearch_Click 検索ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSearch_Click
    '説明            :検索ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim sSql As String = String.Empty

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '画面入力チェック
            If Not f_Input_Check_Search() Then
                Exit Try
            End If
            '発生・終了要件マスタセット
            If Not f_Yoken_Set() Then
                Exit Try
            End If
            Call f_ObjectEnabledSet(False)
            pblnTextChange = False             '画面入力内容変更フラグ初期化

            '事業開始日にフォーカスセット
            dateKAISI_Ymd.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try
    End Sub
#End Region

#Region "cmdSave_Click 保存ボタンクリック処理"
    ''' <summary>
    ''' 保存ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim ret As Boolean

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '事前チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '保存処理確認
            If Show_MessageBox_Add("Q003", "") = DialogResult.No Then    '保存します。よろしいですか？
                Exit Try
            End If

            'データ保存処理
            If Not f_TM_YOKEN_Save() Then
                Exit Try
            End If

            'ret = f_ObjectClear("")
            ret = f_ObjectEnabledSet(True)

            '期にフォーカスセット
            numKI.Focus()
            pblnTextChange = False             '画面入力内容変更フラグ初期化

            '終了メッセージ
            Show_MessageBox("I001", "")

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try
    End Sub
#End Region

#Region "cmdDelete_Click 削除ボタンクリック処理"
    ''' <summary>
    ''' 削除ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim wkMsg As String
        Dim ret As Boolean

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '削除処理確認
            wkMsg = numKI.Text & "期 第" & numKAISU.Text & "回のデータ"
            If Show_MessageBox_Add("Q006", wkMsg) = DialogResult.No Then    '削除します。よろしいですか？
                Exit Try
            End If


            '該当データ削除処理
            If Not f_TM_YOKEN_Delete() Then
                Exit Try
            End If

            ret = f_ObjectClear("")
            ret = f_ObjectEnabledSet(True)

            '期にフォーカスセット
            numKI.Focus()
            pblnTextChange = False             '画面入力内容変更フラグ初期化

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
            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then
                    '「いいえ」を選択
                    Exit Sub
                End If
            End If
            ret = f_ObjectClear("")
            ret = f_ObjectEnabledSet(True)
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
            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then
                    Exit Try
                End If
            Else
                If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                    '処理を終了しますか？
                    Exit Try
                End If
            End If

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
    Private Sub s_FormControls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dateKAISI_Ymd.TextChanged, _
                                                                                                        dateHASSEI_Ymd.TextChanged, _
                                                                                                        dateSYURYO_Ymd.TextChanged, _
                                                                                                        txtBIKO.TextChanged

        pblnTextChange = True
    End Sub
#End Region
#Region "　対象期と回数のTextChangeイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :numKI_TextChanged
    '説明            :対象期と回数のTextChangeイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub s_numKI_KAISU_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles numKI.TextChanged, _
                                                                                                        numKAISU.TextChanged
        'If numKI.Value <= 0 Then
        '    numKI.Value = Nothing
        'End If
        'If numKAISU.Value <= 0 Then
        '    numKAISU.Value = Nothing
        'End If
    End Sub
#End Region
#End Region

#Region "*** データ登録関連 ***"
#Region "f_TM_YOKEN_Save 互助金発生・終了要件マスタデータ登録"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_YOKEN_Save
    '説明            :互助金発生・終了要件マスタデータ登録
    '引数            :無し
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_YOKEN_Save() As Boolean
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False

        Try
            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ8070.GJ8070_YOKEN_INS_UPD"

            '引き渡し
            '期
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_YOUKEN_KI", numKI.Value)
            '回数
            Dim paraKAISU As OracleParameter = Cmd.Parameters.Add("IN_YOUKEN_KAISU", numKAISU.Value)
            '事業開始日
            Dim paraKAISI_DATE As OracleParameter = Cmd.Parameters.Add("IN_YOUKEN_KAISI_DATE", Format(dateKAISI_Ymd.Value, "yyyy/MM/dd"))
            '発生日
            Dim paraHASSEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_YOUKEN_HASSEI_DATE", Format(dateHASSEI_Ymd.Value, "yyyy/MM/dd"))
            '事業終了日
            Dim paraSYURYO_DATE As OracleParameter = Cmd.Parameters.Add("IN_YOUKEN_SYURYO_DATE", Format(dateSYURYO_Ymd.Value, "yyyy/MM/dd"))
            '備考欄
            Dim paraBIKO As OracleParameter = Cmd.Parameters.Add("IN_YOUKEN_BIKO", txtBIKO.Text)


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

#Region "f_TM_YOKEN_Delete 互助金発生・終了要件マスタデータ削除"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_YOKEN_Delete
    '説明            :互助金発生・終了要件マスタデータ削除
    '引数            :無し
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_YOKEN_Delete() As Boolean
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False

        Try
            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ8070.GJ8070_YOKEN_DEL"

            '引き渡し
            '期
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_YOKEN_KI", numKI.Value)
            '回数
            Dim paraKAISU As OracleParameter = Cmd.Parameters.Add("IN_YOUKEN_KAISU", numKAISU.Value)


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

#Region "***ローカル関数***"
#Region "f_ObjectEnabledSet 画面項目使用可・不可設定処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ObjectClear
    '説明            :画面項目使用可・不可設定処理
    '引数            :bolEnabledFlg(処理区分)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ObjectEnabledSet(ByVal bolEnabledFlg As Boolean) As Boolean

        f_ObjectEnabledSet = False
        Try

            f_ObjectEnabledSet = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            If bolEnabledFlg Then
                numKI.Enabled = True
                numKAISU.Enabled = True
                dateKAISI_Ymd.Enabled = False
                dateHASSEI_Ymd.Enabled = False
                dateSYURYO_Ymd.Enabled = False
                txtBIKO.Enabled = False

                cmdSave.Enabled = False
                cmdDelete.Enabled = False
                cmdSearch.Enabled = True
            Else
                numKI.Enabled = False
                numKAISU.Enabled = False
                dateKAISI_Ymd.Enabled = True
                dateHASSEI_Ymd.Enabled = True
                dateSYURYO_Ymd.Enabled = True
                txtBIKO.Enabled = True

                cmdSave.Enabled = True
                cmdDelete.Enabled = True
                cmdSearch.Enabled = False

            End If

            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function
#End Region

#Region "f_Syori_Ki_Set 処理対象期・年度マスタより期と回数をセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Syori_Ki_Set
    '説明            :処理対象期・年度マスタセット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Syori_Ki_Set() As Boolean
        Dim sSql As New StringBuilder
        Dim dstDataSet As New DataSet
        Dim ret As Boolean = False

        Try
            '期　回数 初期化
            numKI.Text = New Obj_TM_SYORI_NENDO_KI().pKI
            numKAISU.Text = New Obj_TM_SYORI_NENDO_KI().pHASSEI_KAISU

            If numKI.Value <= 0 Then
                numKI.Value = 1
            End If
            If numKAISU.Value <= 0 Then
                numKAISU.Value = 1
            End If

            ret = True
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try
        Return ret
    End Function

#End Region

#Region "f_Yoken_Set 発生・終了要件マスタセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Yoken_Set
    '説明            :発生・終了要件マスタセット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Yoken_Set() As Boolean
        Dim sSql As New StringBuilder
        Dim dstDataSet As New DataSet
        Dim ret As Boolean = False

        Try

            '事業開始日　発生日　事業終了日　備考欄 初期化
            dateKAISI_Ymd.Text = ""
            dateHASSEI_Ymd.Text = ""
            dateSYURYO_Ymd.Text = ""
            txtBIKO.Text = ""

            '発生・終了要件マスタ取得
            sSql.AppendLine("SELECT  ")
            sSql.AppendLine("  KI,")
            sSql.AppendLine("  KAISU,")
            sSql.AppendLine("  KAISI_DATE,")
            sSql.AppendLine("  HASSEI_DATE,")
            sSql.AppendLine("  SYURYO_DATE,")
            sSql.AppendLine("  BIKO")
            sSql.AppendLine("FROM TM_YOKEN")
            sSql.AppendLine("WHERE")
            sSql.AppendLine("        KI = " & numKI.Value)
            sSql.AppendLine("    AND KAISU = " & numKAISU.Value)

            Call f_Select_ODP(dstDataSet, sSql.ToString())

            With dstDataSet.Tables(0)
                If .Rows.Count > 0 Then
                    If Not IsDBNull(.Rows(0)("KAISI_DATE")) Then
                        dateKAISI_Ymd.Value = .Rows(0)("KAISI_DATE")
                    Else
                        dateKAISI_Ymd.Value = Nothing
                    End If
                    If Not IsDBNull(.Rows(0)("HASSEI_DATE")) Then
                        dateHASSEI_Ymd.Value = .Rows(0)("HASSEI_DATE")
                    Else
                        dateHASSEI_Ymd.Value = Nothing
                    End If
                    If Not IsDBNull(.Rows(0)("SYURYO_DATE")) Then
                        dateSYURYO_Ymd.Value = .Rows(0)("SYURYO_DATE")
                    Else
                        dateSYURYO_Ymd.Value = Nothing
                    End If

                    txtBIKO.Text = WordHenkan("N", "S", .Rows(0)("BIKO"))
                Else
                    dateKAISI_Ymd.Value = Nothing
                    dateHASSEI_Ymd.Value = Nothing
                    dateSYURYO_Ymd.Value = Nothing
                    txtBIKO.Text = ""
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

#Region "f_Input_Check_Search 検索時画面入力チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check_Search
    '説明            :検索時画面入力チェック処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_Search() As Boolean
        Dim ret As Boolean = False
        Dim wkControlName As String

        ret = False
        Try
            '検索時の入力チェック
            wkControlName = "期"
            If numKI.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKI.Focus() : Exit Try
            End If
            wkControlName = "回数"
            If numKAISU.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKAISU.Focus() : Exit Try
            End If

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
            wkControlName = "回数"
            If numKAISU.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKAISU.Focus() : Exit Try
            End If
            wkControlName = "事業開始日"
            If dateKAISI_Ymd.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : dateKAISI_Ymd.Focus() : Exit Try
            End If


            '==いろいろチェック==================
            '事業開始年度チェック
            Dim dtJIGYO_NENDO = New Obj_TM_SYORI_NENDO_KI().pJIGYO_NENDO_byDate
            Dim dtJIGYO_SYURYO_NENDO = New Obj_TM_SYORI_NENDO_KI().pJIGYO_SYURYO_NENDO_byDate
            If dtJIGYO_NENDO > dateKAISI_Ymd.Value Or dtJIGYO_SYURYO_NENDO < dateKAISI_Ymd.Value Then
                wkControlName = "対象期年度以外の事業開始日"
                Call Show_MessageBox_Add("W029", wkControlName) : dateKAISI_Ymd.Focus() : Exit Try
            End If
            If dateSYURYO_Ymd Is Nothing Then
            Else
                If dtJIGYO_NENDO > dateSYURYO_Ymd.Value Or dtJIGYO_SYURYO_NENDO < dateSYURYO_Ymd.Value Then
                    wkControlName = "対象期年度以外の事業終了日"
                    Call Show_MessageBox_Add("W029", wkControlName) : dateSYURYO_Ymd.Focus() : Exit Try
                End If
            End If

            '事業終了日チェック
            wkControlName = "事業終了日は事業開始日以前に"
            If dateSYURYO_Ymd IsNot Nothing Then
                If dateKAISI_Ymd.Value > dateSYURYO_Ymd.Value Then
                    Call Show_MessageBox_Add("W029", wkControlName) : dateSYURYO_Ymd.Focus() : Exit Try
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
