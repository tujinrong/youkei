'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ8080.vb
'*
'*　　②　機能概要　　　　　互助金交付単価算定基礎指数マスタメンテナンス
'*
'*　　③　作成日　　　　　　2014/01/15 JBD999
'*
'*　　④　更新日            
'*
'*　　⑤　注意点            単価の桁数を修正する場合は、最小値・最大値のプロパティに注意する。
'*                          GcNumberValidatorのValidateItems　MaxVlueとMinValueを確認する。
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

Public Class frmGJ8080

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

            '初期コントロールにフォーカスセット
            numKI.Focus()

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
            '処理対象期・年度マスタより期をセット
            If Not f_Syori_Ki_Set() Then
                Exit Try
            End If


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
            '基礎指標マスタマスタセット
            If Not f_Search_Set() Then
                Exit Try
            End If
            Call f_ObjectEnabledSet(False)
            pblnTextChange = False             '画面入力内容変更フラグ初期化

            '雇用労賃補正の上限単価にフォーカスセット
            numKOYO_JOGEN11.Focus()

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
            If Not f_TM_KISOSIHYO_Save() Then
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
            wkMsg = numKI.Text & "期 " & dateTAISYO_NENDO.Text & "年度のデータ"
            If Show_MessageBox_Add("Q006", wkMsg) = DialogResult.No Then    '削除します。よろしいですか？
                Exit Try
            End If

            '該当データ削除処理
            If Not f_TM_KISOSIHYO_Delete() Then
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
    '↓2017/07/13 修正 鳥の種類追加
    'Private Sub s_FormControls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles numKOYO_JOGEN11.TextChanged _
    '            , numKOYO_JOGEN12.TextChanged _
    '            , numKOYO_JOGEN13.TextChanged _
    '            , numKOYO_JOGEN14.TextChanged _
    '            , numKOYO_JOGEN15.TextChanged _
    '            , numKOYO_JOGEN21.TextChanged _
    '            , numKOYO_JOGEN22.TextChanged _
    '            , numKOYO_JOGEN23.TextChanged _
    '            , numKOYO_JOGEN24.TextChanged _
    '            , numKOYO_JOGEN25.TextChanged _
    '            , numKOYO_JOGEN36.TextChanged _
    '            , numKOYO_KOYO11.TextChanged _
    '            , numKOYO_KOYO12.TextChanged _
    '            , numKOYO_KOYO13.TextChanged _
    '            , numKOYO_KOYO14.TextChanged _
    '            , numKOYO_KOYO15.TextChanged _
    '            , numKOYO_KOYO21.TextChanged _
    '            , numKOYO_KOYO22.TextChanged _
    '            , numKOYO_KOYO23.TextChanged _
    '            , numKOYO_KOYO24.TextChanged _
    '            , numKOYO_KOYO25.TextChanged _
    '            , numKOYO_KOYO36.TextChanged _
    '            , numJIDAI_JOGEN11.TextChanged _
    '            , numJIDAI_JOGEN12.TextChanged _
    '            , numJIDAI_JOGEN13.TextChanged _
    '            , numJIDAI_JOGEN14.TextChanged _
    '            , numJIDAI_JOGEN15.TextChanged _
    '            , numJIDAI_JOGEN21.TextChanged _
    '            , numJIDAI_JOGEN22.TextChanged _
    '            , numJIDAI_JOGEN23.TextChanged _
    '            , numJIDAI_JOGEN24.TextChanged _
    '            , numJIDAI_JOGEN25.TextChanged _
    '            , numJIDAI_JOGEN36.TextChanged _
    '            , numGENKA_JOGEN11.TextChanged _
    '            , numGENKA_JOGEN12.TextChanged _
    '            , numGENKA_JOGEN13.TextChanged _
    '            , numGENKA_JOGEN14.TextChanged _
    '            , numGENKA_JOGEN15.TextChanged _
    '            , numGENKA_JOGEN21.TextChanged _
    '            , numGENKA_JOGEN22.TextChanged _
    '            , numGENKA_JOGEN23.TextChanged _
    '            , numGENKA_JOGEN24.TextChanged _
    '            , numGENKA_JOGEN25.TextChanged _
    '            , numGENKA_JOGEN36.TextChanged _
    '            , numGENKA_SYOKYAKU12.TextChanged _
    '            , numGENKA_SYOKYAKU13.TextChanged _
    '            , numGENKA_SYOKYAKU14.TextChanged _
    '            , numGENKA_SYOKYAKU15.TextChanged _
    '            , numGENKA_SYOKYAKU21.TextChanged _
    '            , numGENKA_SYOKYAKU22.TextChanged _
    '            , numGENKA_SYOKYAKU23.TextChanged _
    '            , numGENKA_SYOKYAKU24.TextChanged _
    '            , numGENKA_SYOKYAKU25.TextChanged _
    '            , numGENKA_SYOKYAKU36.TextChanged _
    '            , numKUSYA11.TextChanged _
    '            , numKUSYA12.TextChanged _
    '            , numKUSYA13.TextChanged _
    '            , numKUSYA14.TextChanged _
    '            , numKUSYA15.TextChanged _
    '            , numKUSYA21.TextChanged _
    '            , numKUSYA22.TextChanged _
    '            , numKUSYA23.TextChanged _
    '            , numKUSYA24.TextChanged _
    '            , numKUSYA25.TextChanged _
    '            , numKUSYA36.TextChanged
    Private Sub s_FormControls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles numKOYO_JOGEN11.TextChanged _
                , numKOYO_JOGEN12.TextChanged _
                , numKOYO_JOGEN13.TextChanged _
                , numKOYO_JOGEN14.TextChanged _
                , numKOYO_JOGEN15.TextChanged _
                , numKOYO_JOGEN21.TextChanged _
                , numKOYO_JOGEN22.TextChanged _
                , numKOYO_JOGEN23.TextChanged _
                , numKOYO_JOGEN24.TextChanged _
                , numKOYO_JOGEN25.TextChanged _
                , numKOYO_JOGEN36.TextChanged _
                , numKOYO_JOGEN37.TextChanged _
                , numKOYO_JOGEN38.TextChanged _
                , numKOYO_JOGEN39.TextChanged _
                , numKOYO_JOGEN40.TextChanged _
                , numKOYO_JOGEN41.TextChanged _
                , numKOYO_KOYO11.TextChanged _
                , numKOYO_KOYO12.TextChanged _
                , numKOYO_KOYO13.TextChanged _
                , numKOYO_KOYO14.TextChanged _
                , numKOYO_KOYO15.TextChanged _
                , numKOYO_KOYO21.TextChanged _
                , numKOYO_KOYO22.TextChanged _
                , numKOYO_KOYO23.TextChanged _
                , numKOYO_KOYO24.TextChanged _
                , numKOYO_KOYO25.TextChanged _
                , numKOYO_KOYO36.TextChanged _
                , numKOYO_KOYO37.TextChanged _
                , numKOYO_KOYO38.TextChanged _
                , numKOYO_KOYO39.TextChanged _
                , numKOYO_KOYO40.TextChanged _
                , numKOYO_KOYO41.TextChanged _
                , numJIDAI_JOGEN11.TextChanged _
                , numJIDAI_JOGEN12.TextChanged _
                , numJIDAI_JOGEN13.TextChanged _
                , numJIDAI_JOGEN14.TextChanged _
                , numJIDAI_JOGEN15.TextChanged _
                , numJIDAI_JOGEN21.TextChanged _
                , numJIDAI_JOGEN22.TextChanged _
                , numJIDAI_JOGEN23.TextChanged _
                , numJIDAI_JOGEN24.TextChanged _
                , numJIDAI_JOGEN25.TextChanged _
                , numJIDAI_JOGEN36.TextChanged _
                , numGENKA_JOGEN11.TextChanged _
                , numGENKA_JOGEN12.TextChanged _
                , numGENKA_JOGEN13.TextChanged _
                , numGENKA_JOGEN14.TextChanged _
                , numGENKA_JOGEN15.TextChanged _
                , numGENKA_JOGEN21.TextChanged _
                , numGENKA_JOGEN22.TextChanged _
                , numGENKA_JOGEN23.TextChanged _
                , numGENKA_JOGEN24.TextChanged _
                , numGENKA_JOGEN25.TextChanged _
                , numGENKA_JOGEN36.TextChanged _
                , numGENKA_JOGEN37.TextChanged _
                , numGENKA_JOGEN38.TextChanged _
                , numGENKA_JOGEN39.TextChanged _
                , numGENKA_JOGEN40.TextChanged _
                , numGENKA_JOGEN41.TextChanged _
                , numGENKA_SYOKYAKU12.TextChanged _
                , numGENKA_SYOKYAKU13.TextChanged _
                , numGENKA_SYOKYAKU14.TextChanged _
                , numGENKA_SYOKYAKU15.TextChanged _
                , numGENKA_SYOKYAKU21.TextChanged _
                , numGENKA_SYOKYAKU22.TextChanged _
                , numGENKA_SYOKYAKU23.TextChanged _
                , numGENKA_SYOKYAKU24.TextChanged _
                , numGENKA_SYOKYAKU25.TextChanged _
                , numGENKA_SYOKYAKU36.TextChanged _
                , numGENKA_SYOKYAKU37.TextChanged _
                , numGENKA_SYOKYAKU38.TextChanged _
                , numGENKA_SYOKYAKU39.TextChanged _
                , numGENKA_SYOKYAKU40.TextChanged _
                , numGENKA_SYOKYAKU41.TextChanged _
                , numKUSYA11.TextChanged _
                , numKUSYA12.TextChanged _
                , numKUSYA13.TextChanged _
                , numKUSYA14.TextChanged _
                , numKUSYA15.TextChanged _
                , numKUSYA21.TextChanged _
                , numKUSYA22.TextChanged _
                , numKUSYA23.TextChanged _
                , numKUSYA24.TextChanged _
                , numKUSYA25.TextChanged _
                , numKUSYA36.TextChanged _
                , numKUSYA37.TextChanged _
                , numKUSYA38.TextChanged _
                , numKUSYA39.TextChanged _
                , numKUSYA40.TextChanged _
                , numKUSYA41.TextChanged
        '↑2017/07/13 修正 鳥の種類追加

        pblnTextChange = True
    End Sub
#End Region
#End Region

#Region "*** データ登録関連 ***"
#Region "f_TM_KISOSIHYO_Save 基礎指標マスタデータ登録"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_KISOSIHYO_Save
    '説明            :基礎指標マスタデータ登録
    '引数            :無し
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_KISOSIHYO_Save() As Boolean
        Dim ret As Boolean = False
        Dim dtNow As Date = Now()

        Try
            '家族型-採卵鶏(成鶏)
            If Not f_TM_KISOSIHYO_Save_Pro(11, dtNow) Then
                Return ret
            End If
            '家族型-採卵鶏(育成鶏)
            If Not f_TM_KISOSIHYO_Save_Pro(12, dtNow) Then
                Return ret
            End If
            '家族型-肉用鶏
            If Not f_TM_KISOSIHYO_Save_Pro(13, dtNow) Then
                Return ret
            End If
            '家族型-種鶏(成鶏)
            If Not f_TM_KISOSIHYO_Save_Pro(14, dtNow) Then
                Return ret
            End If
            '家族型-種鶏(育成鶏)
            If Not f_TM_KISOSIHYO_Save_Pro(15, dtNow) Then
                Return ret
            End If
            '家族型-うずら
            If Not f_TM_KISOSIHYO_Save_Pro(16, dtNow) Then
                Return ret
            End If
            '↓2017/07/21 追加 鳥の種類追加
            '家族型-あひる～だちょう
            For i = 47 To 51
                If Not f_TM_KISOSIHYO_Save_Pro(i, dtNow) Then
                    Return ret
                End If
            Next
            '↑2017/07/21 追加 鳥の種類追加
            '企業型-採卵鶏(成鶏)
            If Not f_TM_KISOSIHYO_Save_Pro(21, dtNow) Then
                Return ret
            End If
            '企業型-採卵鶏(育成鶏)
            If Not f_TM_KISOSIHYO_Save_Pro(22, dtNow) Then
                Return ret
            End If
            '企業型-肉用鶏
            If Not f_TM_KISOSIHYO_Save_Pro(23, dtNow) Then
                Return ret
            End If
            '企業型-種鶏(成鶏)
            If Not f_TM_KISOSIHYO_Save_Pro(24, dtNow) Then
                Return ret
            End If
            '企業型-種鶏(育成鶏)
            If Not f_TM_KISOSIHYO_Save_Pro(25, dtNow) Then
                Return ret
            End If
            '企業型-うずら
            If Not f_TM_KISOSIHYO_Save_Pro(26, dtNow) Then
                Return ret
            End If
            '↓2017/07/21 追加 鳥の種類追加
            '企業型-あひる～だちょう
            For i = 57 To 61
                If Not f_TM_KISOSIHYO_Save_Pro(i, dtNow) Then
                    Return ret
                End If
            Next
            '↑2017/07/20 追加 鳥の種類追加
            'うずら-うずら
            If Not f_TM_KISOSIHYO_Save_Pro(36, dtNow) Then
                Return ret
            End If
            '↓2017/07/13 追加 鳥の種類追加
            '鶏以外-あひる～だちょう
            For i = 37 To 41
                If Not f_TM_KISOSIHYO_Save_Pro(i, dtNow) Then
                    Return ret
                End If
            Next
            '↑2017/07/13 追加 鳥の種類追加
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

#Region "f_TM_KISOSIHYO_Save_Pro 基礎指標マスタデータ登録処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_KISOSIHYO_Save_Pro
    '説明            :基礎指標マスタデータ登録処理
    '引数            :区分
    '引数            :日付
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_KISOSIHYO_Save_Pro(ByVal kbn As Integer, ByVal dtNow As Date) As Boolean
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False

        Try
            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ8080.GJ8080_KISOSIHYO_INS_UPD"

            '引き渡し
            '期
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", numKI.Value)
            '年度
            Dim paraNENDO As OracleParameter = Cmd.Parameters.Add("IN_NENDO", Format(dateTAISYO_NENDO.Value, "yyyy"))

            '家族型-採卵鶏(成鶏)
            If kbn = 11 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 1)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 1)

                '雇用労賃補正-上限単価
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(numKOYO_JOGEN11.Value Is Nothing, 0, numKOYO_JOGEN11.Value))

                '雇用労賃補正-雇用労費
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(numKOYO_KOYO11.Value Is Nothing, 0, numKOYO_KOYO11.Value))
                '地代補正-上限地代
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(numJIDAI_JOGEN11.Value Is Nothing, 0, numJIDAI_JOGEN11.Value))
                '地代補正-地代
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(numJIDAI_JIDAI11.Value Is Nothing, 0, numJIDAI_JIDAI11.Value))
                '原価償却費補正-上限減価償却費
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(numGENKA_JOGEN11.Value Is Nothing, 0, numGENKA_JOGEN11.Value))
                '原価償却費補正-償却費
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(numGENKA_SYOKYAKU11.Value Is Nothing, 0, numGENKA_SYOKYAKU11.Value))
                '空舎期間の補正
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(numKUSYA11.Value Is Nothing, 0, numKUSYA11.Value))
            End If

            '家族型-採卵鶏(育成鶏)
            If kbn = 12 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 1)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 2)

                '雇用労賃補正-上限単価
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(numKOYO_JOGEN12.Value Is Nothing, 0, numKOYO_JOGEN12.Value))
                '雇用労賃補正-雇用労費
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(numKOYO_KOYO12.Value Is Nothing, 0, numKOYO_KOYO12.Value))
                '地代補正-上限地代
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(numJIDAI_JOGEN12.Value Is Nothing, 0, numJIDAI_JOGEN12.Value))
                '地代補正-地代
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(numJIDAI_JIDAI12.Value Is Nothing, 0, numJIDAI_JIDAI12.Value))
                '原価償却費補正-上限減価償却費
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(numGENKA_JOGEN12.Value Is Nothing, 0, numGENKA_JOGEN12.Value))
                '原価償却費補正-償却費
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(numGENKA_SYOKYAKU12.Value Is Nothing, 0, numGENKA_SYOKYAKU12.Value))
                '空舎期間の補正
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(numKUSYA12.Value Is Nothing, 0, numKUSYA12.Value))
            End If

            '家族型-肉用鶏
            If kbn = 13 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 1)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 3)

                '雇用労賃補正-上限単価
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(numKOYO_JOGEN13.Value Is Nothing, 0, numKOYO_JOGEN13.Value))
                '雇用労賃補正-雇用労費
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(numKOYO_KOYO13.Value Is Nothing, 0, numKOYO_KOYO13.Value))
                '地代補正-上限地代
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(numJIDAI_JOGEN13.Value Is Nothing, 0, numJIDAI_JOGEN13.Value))
                '地代補正-地代
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(numJIDAI_JIDAI13.Value Is Nothing, 0, numJIDAI_JIDAI13.Value))
                '原価償却費補正-上限減価償却費
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(numGENKA_JOGEN13.Value Is Nothing, 0, numGENKA_JOGEN13.Value))
                '原価償却費補正-償却費
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(numGENKA_SYOKYAKU13.Value Is Nothing, 0, numGENKA_SYOKYAKU13.Value))
                '空舎期間の補正
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(numKUSYA13.Value Is Nothing, 0, numKUSYA13.Value))
            End If

            '家族型-種鶏(成鶏)
            If kbn = 14 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 1)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 4)

                '雇用労賃補正-上限単価
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(numKOYO_JOGEN14.Value Is Nothing, 0, numKOYO_JOGEN14.Value))
                '雇用労賃補正-雇用労費
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(numKOYO_KOYO14.Value Is Nothing, 0, numKOYO_KOYO14.Value))
                '地代補正-上限地代
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(numJIDAI_JOGEN14.Value Is Nothing, 0, numJIDAI_JOGEN14.Value))
                '地代補正-地代
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(numJIDAI_JIDAI14.Value Is Nothing, 0, numJIDAI_JIDAI14.Value))
                '原価償却費補正-上限減価償却費
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(numGENKA_JOGEN14.Value Is Nothing, 0, numGENKA_JOGEN14.Value))
                '原価償却費補正-償却費
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(numGENKA_SYOKYAKU14.Value Is Nothing, 0, numGENKA_SYOKYAKU14.Value))
                '空舎期間の補正
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(numKUSYA14.Value Is Nothing, 0, numKUSYA14.Value))
            End If

            '家族型-種鶏(育成鶏)
            If kbn = 15 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 1)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 5)

                '雇用労賃補正-上限単価
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(numKOYO_JOGEN15.Value Is Nothing, 0, numKOYO_JOGEN15.Value))
                '雇用労賃補正-雇用労費
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(numKOYO_KOYO15.Value Is Nothing, 0, numKOYO_KOYO15.Value))
                '地代補正-上限地代
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(numJIDAI_JOGEN15.Value Is Nothing, 0, numJIDAI_JOGEN15.Value))
                '地代補正-地代
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(numJIDAI_JIDAI15.Value Is Nothing, 0, numJIDAI_JIDAI15.Value))
                '原価償却費補正-上限減価償却費
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(numGENKA_JOGEN15.Value Is Nothing, 0, numGENKA_JOGEN15.Value))
                '原価償却費補正-償却費
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(numGENKA_SYOKYAKU15.Value Is Nothing, 0, numGENKA_SYOKYAKU15.Value))
                '空舎期間の補正
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(numKUSYA15.Value Is Nothing, 0, numKUSYA15.Value))
            End If

            '家族型-うずら
            If kbn = 16 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 1)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 6)

                '雇用労賃補正-上限単価
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(numKOYO_JOGEN36.Value Is Nothing, 0, numKOYO_JOGEN36.Value))
                '雇用労賃補正-雇用労費
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(numKOYO_KOYO36.Value Is Nothing, 0, numKOYO_KOYO36.Value))
                '地代補正-上限地代
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(numJIDAI_JOGEN36.Value Is Nothing, 0, numJIDAI_JOGEN36.Value))
                '地代補正-地代
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(numJIDAI_JIDAI36.Value Is Nothing, 0, numJIDAI_JIDAI36.Value))
                '原価償却費補正-上限減価償却費
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(numGENKA_JOGEN36.Value Is Nothing, 0, numGENKA_JOGEN36.Value))
                '原価償却費補正-償却費
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(numGENKA_SYOKYAKU36.Value Is Nothing, 0, numGENKA_SYOKYAKU36.Value))
                '空舎期間の補正
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(numKUSYA36.Value Is Nothing, 0, numKUSYA36.Value))
            End If

            '↓2017/07/21 追加 鳥の種類追加
            '家族型-あひる～だちょう
            If kbn >= 47 And kbn <= 51 Then
                Dim wkbn As Integer = kbn - 10
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 1)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", kbn - 40)

                '雇用労賃補正-上限単価
                Dim kjogen As Object = DirectCast(Me.Controls("numKOYO_JOGEN" & wkbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(kjogen Is Nothing, 0, kjogen))
                '雇用労賃補正-雇用労費
                Dim kkoyo As Object = DirectCast(Me.Controls("numKOYO_KOYO" & wkbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(kkoyo Is Nothing, 0, kkoyo))
                '地代補正-上限地代
                Dim jjogen As Object = DirectCast(Me.Controls("numJIDAI_JOGEN" & wkbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(jjogen Is Nothing, 0, jjogen))
                '地代補正-地代
                Dim jjidai As Object = DirectCast(Me.Controls("numJIDAI_JIDAI" & wkbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(jjidai Is Nothing, 0, jjidai))
                '原価償却費補正-上限減価償却費
                Dim gjogen As Object = DirectCast(Me.Controls("numGENKA_JOGEN" & wkbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(gjogen Is Nothing, 0, gjogen))
                '原価償却費補正-償却費
                Dim gsyokyaku As Object = DirectCast(Me.Controls("numGENKA_SYOKYAKU" & wkbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(gsyokyaku Is Nothing, 0, gsyokyaku))
                '空舎期間の補正
                Dim inkusya As Object = DirectCast(Me.Controls("numKUSYA" & wkbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(inkusya Is Nothing, 0, inkusya))
            End If
            '↑2017/07/21 追加 鳥の種類追加

            '企業型-採卵鶏(成鶏)
            If kbn = 21 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 2)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 1)

                '雇用労賃補正-上限単価
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(numKOYO_JOGEN21.Value Is Nothing, 0, numKOYO_JOGEN21.Value))
                '雇用労賃補正-雇用労費
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(numKOYO_KOYO21.Value Is Nothing, 0, numKOYO_KOYO21.Value))
                '地代補正-上限地代
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(numJIDAI_JOGEN21.Value Is Nothing, 0, numJIDAI_JOGEN21.Value))
                '地代補正-地代
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(numJIDAI_JIDAI21.Value Is Nothing, 0, numJIDAI_JIDAI21.Value))
                '原価償却費補正-上限減価償却費
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(numGENKA_JOGEN21.Value Is Nothing, 0, numGENKA_JOGEN21.Value))
                '原価償却費補正-償却費
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(numGENKA_SYOKYAKU21.Value Is Nothing, 0, numGENKA_SYOKYAKU21.Value))
                '空舎期間の補正
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(numKUSYA21.Value Is Nothing, 0, numKUSYA21.Value))
            End If


            '企業型-採卵鶏(育成鶏)
            If kbn = 22 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 2)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 2)

                '雇用労賃補正-上限単価
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(numKOYO_JOGEN22.Value Is Nothing, 0, numKOYO_JOGEN22.Value))
                '雇用労賃補正-雇用労費
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(numKOYO_KOYO22.Value Is Nothing, 0, numKOYO_KOYO22.Value))
                '地代補正-上限地代
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(numJIDAI_JOGEN22.Value Is Nothing, 0, numJIDAI_JOGEN22.Value))
                '地代補正-地代
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(numJIDAI_JIDAI22.Value Is Nothing, 0, numJIDAI_JIDAI22.Value))
                '原価償却費補正-上限減価償却費
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(numGENKA_JOGEN22.Value Is Nothing, 0, numGENKA_JOGEN22.Value))
                '原価償却費補正-償却費
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(numGENKA_SYOKYAKU22.Value Is Nothing, 0, numGENKA_SYOKYAKU22.Value))
                '空舎期間の補正
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(numKUSYA22.Value Is Nothing, 0, numKUSYA22.Value))
            End If

            '企業型-肉用鶏
            If kbn = 23 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 2)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 3)

                '雇用労賃補正-上限単価
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(numKOYO_JOGEN23.Value Is Nothing, 0, numKOYO_JOGEN23.Value))
                '雇用労賃補正-雇用労費
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(numKOYO_KOYO23.Value Is Nothing, 0, numKOYO_KOYO23.Value))
                '地代補正-上限地代
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(numJIDAI_JOGEN23.Value Is Nothing, 0, numJIDAI_JOGEN23.Value))
                '地代補正-地代
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(numJIDAI_JIDAI23.Value Is Nothing, 0, numJIDAI_JIDAI23.Value))
                '原価償却費補正-上限減価償却費
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(numGENKA_JOGEN23.Value Is Nothing, 0, numGENKA_JOGEN23.Value))
                '原価償却費補正-償却費
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(numGENKA_SYOKYAKU23.Value Is Nothing, 0, numGENKA_SYOKYAKU23.Value))
                '空舎期間の補正
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(numKUSYA23.Value Is Nothing, 0, numKUSYA23.Value))
            End If

            '企業型-種鶏(成鶏)
            If kbn = 24 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 2)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 4)

                '雇用労賃補正-上限単価
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(numKOYO_JOGEN24.Value Is Nothing, 0, numKOYO_JOGEN24.Value))
                '雇用労賃補正-雇用労費
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(numKOYO_KOYO24.Value Is Nothing, 0, numKOYO_KOYO24.Value))
                '地代補正-上限地代
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(numJIDAI_JOGEN24.Value Is Nothing, 0, numJIDAI_JOGEN24.Value))
                '地代補正-地代
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(numJIDAI_JIDAI24.Value Is Nothing, 0, numJIDAI_JIDAI24.Value))
                '原価償却費補正-上限減価償却費
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(numGENKA_JOGEN24.Value Is Nothing, 0, numGENKA_JOGEN24.Value))
                '原価償却費補正-償却費
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(numGENKA_SYOKYAKU24.Value Is Nothing, 0, numGENKA_SYOKYAKU24.Value))
                '空舎期間の補正
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(numKUSYA24.Value Is Nothing, 0, numKUSYA24.Value))
            End If

            '企業型-種鶏(育成鶏)
            If kbn = 25 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 2)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 5)

                '雇用労賃補正-上限単価
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(numKOYO_JOGEN25.Value Is Nothing, 0, numKOYO_JOGEN25.Value))
                '雇用労賃補正-雇用労費
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(numKOYO_KOYO25.Value Is Nothing, 0, numKOYO_KOYO25.Value))
                '地代補正-上限地代
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(numJIDAI_JOGEN25.Value Is Nothing, 0, numJIDAI_JOGEN25.Value))
                '地代補正-地代
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(numJIDAI_JIDAI25.Value Is Nothing, 0, numJIDAI_JIDAI25.Value))
                '原価償却費補正-上限減価償却費
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(numGENKA_JOGEN25.Value Is Nothing, 0, numGENKA_JOGEN25.Value))
                '原価償却費補正-償却費
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(numGENKA_SYOKYAKU25.Value Is Nothing, 0, numGENKA_SYOKYAKU25.Value))
                '空舎期間の補正
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(numKUSYA25.Value Is Nothing, 0, numKUSYA25.Value))
            End If

            '企業型-うずら
            If kbn = 26 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 2)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 6)

                '雇用労賃補正-上限単価
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(numKOYO_JOGEN36.Value Is Nothing, 0, numKOYO_JOGEN36.Value))
                '雇用労賃補正-雇用労費
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(numKOYO_KOYO36.Value Is Nothing, 0, numKOYO_KOYO36.Value))
                '地代補正-上限地代
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(numJIDAI_JOGEN36.Value Is Nothing, 0, numJIDAI_JOGEN36.Value))
                '地代補正-地代
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(numJIDAI_JIDAI36.Value Is Nothing, 0, numJIDAI_JIDAI36.Value))
                '原価償却費補正-上限減価償却費
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(numGENKA_JOGEN36.Value Is Nothing, 0, numGENKA_JOGEN36.Value))
                '原価償却費補正-償却費
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(numGENKA_SYOKYAKU36.Value Is Nothing, 0, numGENKA_SYOKYAKU36.Value))
                '空舎期間の補正
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(numKUSYA36.Value Is Nothing, 0, numKUSYA36.Value))
            End If

            '↓2017/07/21 追加 鳥の種類追加
            '企業型-あひる～だちょう
            If kbn >= 57 And kbn <= 61 Then
                Dim wkbn As Integer = kbn - 20
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 2)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", kbn - 50)

                '雇用労賃補正-上限単価
                Dim kjogen As Object = DirectCast(Me.Controls("numKOYO_JOGEN" & wkbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(kjogen Is Nothing, 0, kjogen))
                '雇用労賃補正-雇用労費
                Dim kkoyo As Object = DirectCast(Me.Controls("numKOYO_KOYO" & wkbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(kkoyo Is Nothing, 0, kkoyo))
                '地代補正-上限地代
                Dim jjogen As Object = DirectCast(Me.Controls("numJIDAI_JOGEN" & wkbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(jjogen Is Nothing, 0, jjogen))
                '地代補正-地代
                Dim jjidai As Object = DirectCast(Me.Controls("numJIDAI_JIDAI" & wkbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(jjidai Is Nothing, 0, jjidai))
                '原価償却費補正-上限減価償却費
                Dim gjogen As Object = DirectCast(Me.Controls("numGENKA_JOGEN" & wkbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(gjogen Is Nothing, 0, gjogen))
                '原価償却費補正-償却費
                Dim gsyokyaku As Object = DirectCast(Me.Controls("numGENKA_SYOKYAKU" & wkbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(gsyokyaku Is Nothing, 0, gsyokyaku))
                '空舎期間の補正
                Dim inkusya As Object = DirectCast(Me.Controls("numKUSYA" & wkbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(inkusya Is Nothing, 0, inkusya))
            End If
            '↑2017/07/21 追加 鳥の種類追加

            'うずら-うずら
            If kbn = 36 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 3)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", 6)

                '雇用労賃補正-上限単価
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(numKOYO_JOGEN36.Value Is Nothing, 0, numKOYO_JOGEN36.Value))
                '雇用労賃補正-雇用労費
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(numKOYO_KOYO36.Value Is Nothing, 0, numKOYO_KOYO36.Value))
                '地代補正-上限地代
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(numJIDAI_JOGEN36.Value Is Nothing, 0, numJIDAI_JOGEN36.Value))
                '地代補正-地代
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(numJIDAI_JIDAI36.Value Is Nothing, 0, numJIDAI_JIDAI36.Value))
                '原価償却費補正-上限減価償却費
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(numGENKA_JOGEN36.Value Is Nothing, 0, numGENKA_JOGEN36.Value))
                '原価償却費補正-償却費
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(numGENKA_SYOKYAKU36.Value Is Nothing, 0, numGENKA_SYOKYAKU36.Value))
                '空舎期間の補正
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(numKUSYA36.Value Is Nothing, 0, numKUSYA36.Value))
            End If

            '↓2017/07/13 追加 鳥の種類追加
            '鶏以外-あひる～だちょう
            If kbn >= 37 And kbn <= 41 Then
                '契約区分
                Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", 3)
                '鳥の種類
                Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", kbn - 30)

                '雇用労賃補正-上限単価
                Dim kjogen As Object = DirectCast(Me.Controls("numKOYO_JOGEN" & kbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraKOYO_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_JOGEN", IIf(kjogen Is Nothing, 0, kjogen))
                '雇用労賃補正-雇用労費
                Dim kkoyo As Object = DirectCast(Me.Controls("numKOYO_KOYO" & kbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraKOYO_KOYO As OracleParameter = Cmd.Parameters.Add("IN_KOYO_KOYO", IIf(kkoyo Is Nothing, 0, kkoyo))
                '地代補正-上限地代
                Dim jjogen As Object = DirectCast(Me.Controls("numJIDAI_JOGEN" & kbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraJIDAI_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JOGEN", IIf(jjogen Is Nothing, 0, jjogen))
                '地代補正-地代
                Dim jjidai As Object = DirectCast(Me.Controls("numJIDAI_JIDAI" & kbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraJIDAI_JIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI_JIDAI", IIf(jjidai Is Nothing, 0, jjidai))
                '原価償却費補正-上限減価償却費
                Dim gjogen As Object = DirectCast(Me.Controls("numGENKA_JOGEN" & kbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraGENKA_JOGEN As OracleParameter = Cmd.Parameters.Add("IN_GENKA_JOGEN", IIf(gjogen Is Nothing, 0, gjogen))
                '原価償却費補正-償却費
                Dim gsyokyaku As Object = DirectCast(Me.Controls("numGENKA_SYOKYAKU" & kbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", IIf(gsyokyaku Is Nothing, 0, gsyokyaku))
                '空舎期間の補正
                Dim inkusya As Object = DirectCast(Me.Controls("numKUSYA" & kbn.ToString), JBD.Gjs.Win.GcNumber).Value
                Dim paraKUSYA As OracleParameter = Cmd.Parameters.Add("IN_KUSYA", IIf(inkusya Is Nothing, 0, inkusya))
            End If
            '↑2017/07/13 追加 鳥の種類追加

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

#Region "f_TM_KISOSIHYO_Delete 基礎指標マスタデータ削除"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_KISOSIHYO_Delete
    '説明            :基礎指標マスタデータ削除
    '引数            :無し
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_KISOSIHYO_Delete() As Boolean
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False

        Try
            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ8080.GJ8080_KISOSIHYO_DEL"

            '引き渡し
            '期
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", numKI.Value)
            '年度
            Dim paraNENDO As OracleParameter = Cmd.Parameters.Add("IN_NENDO", Format(dateTAISYO_NENDO.Value, "yyyy"))


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
                dateTAISYO_NENDO.Enabled = True
                rdoARI.Enabled = True
                rdoNASI.Enabled = True


                numKOYO_JOGEN11.Enabled = False
                numKOYO_KOYO11.Enabled = False
                numJIDAI_JOGEN11.Enabled = False
                numJIDAI_JIDAI11.Enabled = False
                numGENKA_JOGEN11.Enabled = False
                numGENKA_SYOKYAKU11.Enabled = False
                numKUSYA11.Enabled = False

                numKOYO_JOGEN12.Enabled = False
                numKOYO_KOYO12.Enabled = False
                numJIDAI_JOGEN12.Enabled = False
                numJIDAI_JIDAI12.Enabled = False
                numGENKA_JOGEN12.Enabled = False
                numGENKA_SYOKYAKU12.Enabled = False
                numKUSYA12.Enabled = False

                numKOYO_JOGEN13.Enabled = False
                numKOYO_KOYO13.Enabled = False
                numJIDAI_JOGEN13.Enabled = False
                numJIDAI_JIDAI13.Enabled = False
                numGENKA_JOGEN13.Enabled = False
                numGENKA_SYOKYAKU13.Enabled = False
                numKUSYA13.Enabled = False

                numKOYO_JOGEN14.Enabled = False
                numKOYO_KOYO14.Enabled = False
                numJIDAI_JOGEN14.Enabled = False
                numJIDAI_JIDAI14.Enabled = False
                numGENKA_JOGEN14.Enabled = False
                numGENKA_SYOKYAKU14.Enabled = False
                numKUSYA14.Enabled = False

                numKOYO_JOGEN15.Enabled = False
                numKOYO_KOYO15.Enabled = False
                numJIDAI_JOGEN15.Enabled = False
                numJIDAI_JIDAI15.Enabled = False
                numGENKA_JOGEN15.Enabled = False
                numGENKA_SYOKYAKU15.Enabled = False
                numKUSYA15.Enabled = False


                numKOYO_JOGEN21.Enabled = False
                numKOYO_KOYO21.Enabled = False
                numJIDAI_JOGEN21.Enabled = False
                numJIDAI_JIDAI21.Enabled = False
                numGENKA_JOGEN21.Enabled = False
                numGENKA_SYOKYAKU21.Enabled = False
                numKUSYA21.Enabled = False

                numKOYO_JOGEN22.Enabled = False
                numKOYO_KOYO22.Enabled = False
                numJIDAI_JOGEN22.Enabled = False
                numJIDAI_JIDAI22.Enabled = False
                numGENKA_JOGEN22.Enabled = False
                numGENKA_SYOKYAKU22.Enabled = False
                numKUSYA22.Enabled = False

                numKOYO_JOGEN23.Enabled = False
                numKOYO_KOYO23.Enabled = False
                numJIDAI_JOGEN23.Enabled = False
                numJIDAI_JIDAI23.Enabled = False
                numGENKA_JOGEN23.Enabled = False
                numGENKA_SYOKYAKU23.Enabled = False
                numKUSYA23.Enabled = False

                numKOYO_JOGEN24.Enabled = False
                numKOYO_KOYO24.Enabled = False
                numJIDAI_JOGEN24.Enabled = False
                numJIDAI_JIDAI24.Enabled = False
                numGENKA_JOGEN24.Enabled = False
                numGENKA_SYOKYAKU24.Enabled = False
                numKUSYA24.Enabled = False

                numKOYO_JOGEN25.Enabled = False
                numKOYO_KOYO25.Enabled = False
                numJIDAI_JOGEN25.Enabled = False
                numJIDAI_JIDAI25.Enabled = False
                numGENKA_JOGEN25.Enabled = False
                numGENKA_SYOKYAKU25.Enabled = False
                numKUSYA25.Enabled = False


                numKOYO_JOGEN36.Enabled = False
                numKOYO_KOYO36.Enabled = False
                numJIDAI_JOGEN36.Enabled = False
                numJIDAI_JIDAI36.Enabled = False
                numGENKA_JOGEN36.Enabled = False
                numGENKA_SYOKYAKU36.Enabled = False
                numKUSYA36.Enabled = False

                '↓2017/07/13 修正 鳥の種類追加
                '鶏以外-あひる～だちょう
                For i = 37 To 41
                    DirectCast(Me.Controls("numKOYO_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Enabled = False
                    DirectCast(Me.Controls("numKOYO_KOYO" & i.ToString), JBD.Gjs.Win.GcNumber).Enabled = False
                    DirectCast(Me.Controls("numJIDAI_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Enabled = False
                    DirectCast(Me.Controls("numJIDAI_JIDAI" & i.ToString), JBD.Gjs.Win.GcNumber).Enabled = False
                    DirectCast(Me.Controls("numGENKA_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Enabled = False
                    DirectCast(Me.Controls("numGENKA_SYOKYAKU" & i.ToString), JBD.Gjs.Win.GcNumber).Enabled = False
                    DirectCast(Me.Controls("numKUSYA" & i.ToString), JBD.Gjs.Win.GcNumber).Enabled = False
                Next
                '↑2017/07/13 修正 鳥の種類追加

                cmdSave.Enabled = False
                cmdDelete.Enabled = False
                cmdSearch.Enabled = True
            Else
                numKI.Enabled = False
                dateTAISYO_NENDO.Enabled = False
                rdoARI.Enabled = False
                rdoNASI.Enabled = False

                numKOYO_JOGEN11.Enabled = True
                numKOYO_KOYO11.Enabled = True
                numJIDAI_JOGEN11.Enabled = True
                numJIDAI_JIDAI11.Enabled = True
                numGENKA_JOGEN11.Enabled = True
                numGENKA_SYOKYAKU11.Enabled = True
                numKUSYA11.Enabled = True

                numKOYO_JOGEN12.Enabled = True
                numKOYO_KOYO12.Enabled = True
                numJIDAI_JOGEN12.Enabled = True
                numJIDAI_JIDAI12.Enabled = True
                numGENKA_JOGEN12.Enabled = True
                numGENKA_SYOKYAKU12.Enabled = True
                numKUSYA12.Enabled = True

                numKOYO_JOGEN13.Enabled = True
                numKOYO_KOYO13.Enabled = True
                numJIDAI_JOGEN13.Enabled = True
                numJIDAI_JIDAI13.Enabled = True
                numGENKA_JOGEN13.Enabled = True
                numGENKA_SYOKYAKU13.Enabled = True
                numKUSYA13.Enabled = True

                numKOYO_JOGEN14.Enabled = True
                numKOYO_KOYO14.Enabled = True
                numJIDAI_JOGEN14.Enabled = True
                numJIDAI_JIDAI14.Enabled = True
                numGENKA_JOGEN14.Enabled = True
                numGENKA_SYOKYAKU14.Enabled = True
                numKUSYA14.Enabled = True

                numKOYO_JOGEN15.Enabled = True
                numKOYO_KOYO15.Enabled = True
                numJIDAI_JOGEN15.Enabled = True
                numJIDAI_JIDAI15.Enabled = True
                numGENKA_JOGEN15.Enabled = True
                numGENKA_SYOKYAKU15.Enabled = True
                numKUSYA15.Enabled = True


                numKOYO_JOGEN21.Enabled = True
                numKOYO_KOYO21.Enabled = True
                numJIDAI_JOGEN21.Enabled = True
                numJIDAI_JIDAI21.Enabled = True
                numGENKA_JOGEN21.Enabled = True
                numGENKA_SYOKYAKU21.Enabled = True
                numKUSYA21.Enabled = True

                numKOYO_JOGEN22.Enabled = True
                numKOYO_KOYO22.Enabled = True
                numJIDAI_JOGEN22.Enabled = True
                numJIDAI_JIDAI22.Enabled = True
                numGENKA_JOGEN22.Enabled = True
                numGENKA_SYOKYAKU22.Enabled = True
                numKUSYA22.Enabled = True

                numKOYO_JOGEN23.Enabled = True
                numKOYO_KOYO23.Enabled = True
                numJIDAI_JOGEN23.Enabled = True
                numJIDAI_JIDAI23.Enabled = True
                numGENKA_JOGEN23.Enabled = True
                numGENKA_SYOKYAKU23.Enabled = True
                numKUSYA23.Enabled = True

                numKOYO_JOGEN24.Enabled = True
                numKOYO_KOYO24.Enabled = True
                numJIDAI_JOGEN24.Enabled = True
                numJIDAI_JIDAI24.Enabled = True
                numGENKA_JOGEN24.Enabled = True
                numGENKA_SYOKYAKU24.Enabled = True
                numKUSYA24.Enabled = True

                numKOYO_JOGEN25.Enabled = True
                numKOYO_KOYO25.Enabled = True
                numJIDAI_JOGEN25.Enabled = True
                numJIDAI_JIDAI25.Enabled = True
                numGENKA_JOGEN25.Enabled = True
                numGENKA_SYOKYAKU25.Enabled = True
                numKUSYA25.Enabled = True


                numKOYO_JOGEN36.Enabled = True
                numKOYO_KOYO36.Enabled = True
                numJIDAI_JOGEN36.Enabled = True
                numJIDAI_JIDAI36.Enabled = True
                numGENKA_JOGEN36.Enabled = True
                numGENKA_SYOKYAKU36.Enabled = True
                numKUSYA36.Enabled = True

                '↓2017/07/13 修正 鳥の種類追加
                '鶏以外-あひる～だちょう
                For i = 37 To 41
                    DirectCast(Me.Controls("numKOYO_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Enabled = True
                    DirectCast(Me.Controls("numKOYO_KOYO" & i.ToString), JBD.Gjs.Win.GcNumber).Enabled = True
                    DirectCast(Me.Controls("numJIDAI_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Enabled = True
                    DirectCast(Me.Controls("numJIDAI_JIDAI" & i.ToString), JBD.Gjs.Win.GcNumber).Enabled = True
                    DirectCast(Me.Controls("numGENKA_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Enabled = True
                    DirectCast(Me.Controls("numGENKA_SYOKYAKU" & i.ToString), JBD.Gjs.Win.GcNumber).Enabled = True
                    DirectCast(Me.Controls("numKUSYA" & i.ToString), JBD.Gjs.Win.GcNumber).Enabled = True
                Next
                '↑2017/07/13 修正 鳥の種類追加

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
            '期　 初期化
            numKI.Text = New Obj_TM_SYORI_NENDO_KI().pKI
            '年度
            dateTAISYO_NENDO.Value = Format(Now, "yyyy/01/01")
            dateTAISYO_NENDO.Value = New Obj_TM_SYORI_NENDO_KI().pTAISYO_NENDO_byDate
            rdoARI.Checked = True

            ret = True
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try
        Return ret
    End Function

#End Region

#Region "f_Search_Set 基礎指標マスタセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_Set
    '説明            :基礎指標マスタセット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Search_Set() As Boolean
        Dim sSql As New StringBuilder
        Dim dstDataSet As New DataSet
        Dim ret As Boolean = False

        Try

            '項目 初期化
            numKOYO_JOGEN11.Text = ""
            numKOYO_KOYO11.Text = ""
            numJIDAI_JOGEN11.Text = ""
            numJIDAI_JIDAI11.Text = ""
            numGENKA_JOGEN11.Text = ""
            numGENKA_SYOKYAKU11.Text = ""
            numKUSYA11.Text = ""

            numKOYO_JOGEN12.Text = ""
            numKOYO_KOYO12.Text = ""
            numJIDAI_JOGEN12.Text = ""
            numJIDAI_JIDAI12.Text = ""
            numGENKA_JOGEN12.Text = ""
            numGENKA_SYOKYAKU12.Text = ""
            numKUSYA12.Text = ""

            numKOYO_JOGEN13.Text = ""
            numKOYO_KOYO13.Text = ""
            numJIDAI_JOGEN13.Text = ""
            numJIDAI_JIDAI13.Text = ""
            numGENKA_JOGEN13.Text = ""
            numGENKA_SYOKYAKU13.Text = ""
            numKUSYA13.Text = ""

            numKOYO_JOGEN14.Text = ""
            numKOYO_KOYO14.Text = ""
            numJIDAI_JOGEN14.Text = ""
            numJIDAI_JIDAI14.Text = ""
            numGENKA_JOGEN14.Text = ""
            numGENKA_SYOKYAKU14.Text = ""
            numKUSYA14.Text = ""

            numKOYO_JOGEN15.Text = ""
            numKOYO_KOYO15.Text = ""
            numJIDAI_JOGEN15.Text = ""
            numJIDAI_JIDAI15.Text = ""
            numGENKA_JOGEN15.Text = ""
            numGENKA_SYOKYAKU15.Text = ""
            numKUSYA15.Text = ""


            numKOYO_JOGEN21.Text = ""
            numKOYO_KOYO21.Text = ""
            numJIDAI_JOGEN21.Text = ""
            numJIDAI_JIDAI21.Text = ""
            numGENKA_JOGEN21.Text = ""
            numGENKA_SYOKYAKU21.Text = ""
            numKUSYA21.Text = ""

            numKOYO_JOGEN22.Text = ""
            numKOYO_KOYO22.Text = ""
            numJIDAI_JOGEN22.Text = ""
            numJIDAI_JIDAI22.Text = ""
            numGENKA_JOGEN22.Text = ""
            numGENKA_SYOKYAKU22.Text = ""
            numKUSYA22.Text = ""

            numKOYO_JOGEN23.Text = ""
            numKOYO_KOYO23.Text = ""
            numJIDAI_JOGEN23.Text = ""
            numJIDAI_JIDAI23.Text = ""
            numGENKA_JOGEN23.Text = ""
            numGENKA_SYOKYAKU23.Text = ""
            numKUSYA23.Text = ""

            numKOYO_JOGEN24.Text = ""
            numKOYO_KOYO24.Text = ""
            numJIDAI_JOGEN24.Text = ""
            numJIDAI_JIDAI24.Text = ""
            numGENKA_JOGEN24.Text = ""
            numGENKA_SYOKYAKU24.Text = ""
            numKUSYA24.Text = ""

            numKOYO_JOGEN25.Text = ""
            numKOYO_KOYO25.Text = ""
            numJIDAI_JOGEN25.Text = ""
            numJIDAI_JIDAI25.Text = ""
            numGENKA_JOGEN25.Text = ""
            numGENKA_SYOKYAKU25.Text = ""
            numKUSYA25.Text = ""


            numKOYO_JOGEN36.Text = ""
            numKOYO_KOYO36.Text = ""
            numJIDAI_JOGEN36.Text = ""
            numJIDAI_JIDAI36.Text = ""
            numGENKA_JOGEN36.Text = ""
            numGENKA_SYOKYAKU36.Text = ""
            numKUSYA36.Text = ""

            '↓2017/07/13 修正 鳥の種類追加
            '鶏以外-あひる～だちょう
            For i = 37 To 41
                DirectCast(Me.Controls("numKOYO_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Text = ""
                DirectCast(Me.Controls("numKOYO_KOYO" & i.ToString), JBD.Gjs.Win.GcNumber).Text = ""
                DirectCast(Me.Controls("numJIDAI_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Text = ""
                DirectCast(Me.Controls("numJIDAI_JIDAI" & i.ToString), JBD.Gjs.Win.GcNumber).Text = ""
                DirectCast(Me.Controls("numGENKA_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Text = ""
                DirectCast(Me.Controls("numGENKA_SYOKYAKU" & i.ToString), JBD.Gjs.Win.GcNumber).Text = ""
                DirectCast(Me.Controls("numKUSYA" & i.ToString), JBD.Gjs.Win.GcNumber).Text = ""
            Next
            '↑2017/07/13 修正 鳥の種類追加

            '基礎指標マスタ取得
            sSql.AppendLine("SELECT  ")
            sSql.AppendLine("  KI,")
            sSql.AppendLine("  TAISYO_NENDO,")
            sSql.AppendLine("  KEIYAKU_KBN,")
            sSql.AppendLine("  TORI_KBN,")
            sSql.AppendLine("  KOYO_JOGEN,")
            sSql.AppendLine("  KOYO_KOYO,")
            sSql.AppendLine("  KOYO_JOGEN,")
            sSql.AppendLine("  JIDAI_JOGEN,")
            sSql.AppendLine("  JIDAI_JIDAI,")
            sSql.AppendLine("  GENKA_JOGEN,")
            sSql.AppendLine("  GENKA_SYOKYAKU,")
            sSql.AppendLine("  KUSYA ")
            sSql.AppendLine(" FROM TM_KISOSIHYO ")
            sSql.AppendLine(" WHERE ")
            sSql.AppendLine("        KI = " & numKI.Value)
            sSql.AppendLine("    AND TAISYO_NENDO = " & Format(dateTAISYO_NENDO.Value, "yyyy"))
            sSql.AppendLine(" ORDER BY KI,TAISYO_NENDO,KEIYAKU_KBN,TORI_KBN")

            Call f_Select_ODP(dstDataSet, sSql.ToString())

            'データの有無確認
            If dstDataSet.Tables(0).Rows.Count = 0 Then
                '前年度のコピー有無の判定
                If rdoARI.Checked Then
                    sSql.Clear()
                    sSql.AppendLine("SELECT  ")
                    sSql.AppendLine("  KI,")
                    sSql.AppendLine("  TAISYO_NENDO,")
                    sSql.AppendLine("  KEIYAKU_KBN,")
                    sSql.AppendLine("  TORI_KBN,")
                    sSql.AppendLine("  KOYO_JOGEN,")
                    sSql.AppendLine("  KOYO_KOYO,")
                    sSql.AppendLine("  KOYO_JOGEN,")
                    sSql.AppendLine("  JIDAI_JOGEN,")
                    sSql.AppendLine("  JIDAI_JIDAI,")
                    sSql.AppendLine("  GENKA_JOGEN,")
                    sSql.AppendLine("  GENKA_SYOKYAKU,")
                    sSql.AppendLine("  KUSYA ")
                    sSql.AppendLine(" FROM TM_KISOSIHYO ")
                    sSql.AppendLine(" WHERE ")
                    'sSql.AppendLine("        KI = " & numKI.Value)     '2017/01/18　削除
                    'sSql.AppendLine("    AND TAISYO_NENDO = " & Format(dateTAISYO_NENDO.Value, "yyyy") - 1)
                    sSql.AppendLine("        TAISYO_NENDO = " & Format(dateTAISYO_NENDO.Value, "yyyy") - 1)
                    sSql.AppendLine(" ORDER BY KEIYAKU_KBN,TORI_KBN")
                    dstDataSet.Clear()
                    Call f_Select_ODP(dstDataSet, sSql.ToString())
                End If
            End If


            '結果数文繰返す
            For i As Integer = 0 To dstDataSet.Tables(0).Rows.Count - 1
                With dstDataSet.Tables(0)
                    '家族型-採卵鶏(成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 1 And .Rows(i)("TORI_KBN") = 1 Then
                        If Not IsDBNull(.Rows(i)("KOYO_JOGEN")) Then
                            numKOYO_JOGEN11.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("KOYO_KOYO")) Then
                            numKOYO_KOYO11.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_KOYO")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JOGEN")) Then
                            numJIDAI_JOGEN11.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JIDAI")) Then
                            numJIDAI_JIDAI11.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JIDAI")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_JOGEN")) Then
                            numGENKA_JOGEN11.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_SYOKYAKU")) Then
                            numGENKA_SYOKYAKU11.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_SYOKYAKU")))
                        End If
                        If Not IsDBNull(.Rows(i)("KUSYA")) Then
                            numKUSYA11.Value = CDec(WordHenkan("N", "S", .Rows(i)("KUSYA")))
                        End If
                    End If

                    '家族型-採卵鶏(育成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 1 And .Rows(i)("TORI_KBN") = 2 Then
                        If Not IsDBNull(.Rows(i)("KOYO_JOGEN")) Then
                            numKOYO_JOGEN12.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("KOYO_KOYO")) Then
                            numKOYO_KOYO12.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_KOYO")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JOGEN")) Then
                            numJIDAI_JOGEN12.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JIDAI")) Then
                            numJIDAI_JIDAI12.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JIDAI")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_JOGEN")) Then
                            numGENKA_JOGEN12.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_SYOKYAKU")) Then
                            numGENKA_SYOKYAKU12.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_SYOKYAKU")))
                        End If
                        If Not IsDBNull(.Rows(i)("KUSYA")) Then
                            numKUSYA12.Value = CDec(WordHenkan("N", "S", .Rows(i)("KUSYA")))
                        End If
                    End If

                    '家族型-肉用鶏
                    If .Rows(i)("KEIYAKU_KBN") = 1 And .Rows(i)("TORI_KBN") = 3 Then
                        If Not IsDBNull(.Rows(i)("KOYO_JOGEN")) Then
                            numKOYO_JOGEN13.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("KOYO_KOYO")) Then
                            numKOYO_KOYO13.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_KOYO")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JOGEN")) Then
                            numJIDAI_JOGEN13.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JIDAI")) Then
                            numJIDAI_JIDAI13.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JIDAI")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_JOGEN")) Then
                            numGENKA_JOGEN13.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_SYOKYAKU")) Then
                            numGENKA_SYOKYAKU13.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_SYOKYAKU")))
                        End If
                        If Not IsDBNull(.Rows(i)("KUSYA")) Then
                            numKUSYA13.Value = CDec(WordHenkan("N", "S", .Rows(i)("KUSYA")))
                        End If
                    End If

                    '家族型-種鶏(成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 1 And .Rows(i)("TORI_KBN") = 4 Then
                        If Not IsDBNull(.Rows(i)("KOYO_JOGEN")) Then
                            numKOYO_JOGEN14.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("KOYO_KOYO")) Then
                            numKOYO_KOYO14.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_KOYO")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JOGEN")) Then
                            numJIDAI_JOGEN14.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JIDAI")) Then
                            numJIDAI_JIDAI14.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JIDAI")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_JOGEN")) Then
                            numGENKA_JOGEN14.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_SYOKYAKU")) Then
                            numGENKA_SYOKYAKU14.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_SYOKYAKU")))
                        End If
                        If Not IsDBNull(.Rows(i)("KUSYA")) Then
                            numKUSYA14.Value = CDec(WordHenkan("N", "S", .Rows(i)("KUSYA")))
                        End If
                    End If

                    '家族型-種鶏(育成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 1 And .Rows(i)("TORI_KBN") = 5 Then
                        If Not IsDBNull(.Rows(i)("KOYO_JOGEN")) Then
                            numKOYO_JOGEN15.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("KOYO_KOYO")) Then
                            numKOYO_KOYO15.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_KOYO")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JOGEN")) Then
                            numJIDAI_JOGEN15.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JIDAI")) Then
                            numJIDAI_JIDAI15.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JIDAI")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_JOGEN")) Then
                            numGENKA_JOGEN15.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_SYOKYAKU")) Then
                            numGENKA_SYOKYAKU15.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_SYOKYAKU")))
                        End If
                        If Not IsDBNull(.Rows(i)("KUSYA")) Then
                            numKUSYA15.Value = CDec(WordHenkan("N", "S", .Rows(i)("KUSYA")))
                        End If
                    End If


                    '企業型-採卵鶏(成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 2 And .Rows(i)("TORI_KBN") = 1 Then
                        If Not IsDBNull(.Rows(i)("KOYO_JOGEN")) Then
                            numKOYO_JOGEN21.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("KOYO_KOYO")) Then
                            numKOYO_KOYO21.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_KOYO")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JOGEN")) Then
                            numJIDAI_JOGEN21.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JIDAI")) Then
                            numJIDAI_JIDAI21.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JIDAI")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_JOGEN")) Then
                            numGENKA_JOGEN21.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_SYOKYAKU")) Then
                            numGENKA_SYOKYAKU21.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_SYOKYAKU")))
                        End If
                        If Not IsDBNull(.Rows(i)("KUSYA")) Then
                            numKUSYA21.Value = CDec(WordHenkan("N", "S", .Rows(i)("KUSYA")))
                        End If
                    End If

                    '企業型-採卵鶏(育成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 2 And .Rows(i)("TORI_KBN") = 2 Then
                        If Not IsDBNull(.Rows(i)("KOYO_JOGEN")) Then
                            numKOYO_JOGEN22.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("KOYO_KOYO")) Then
                            numKOYO_KOYO22.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_KOYO")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JOGEN")) Then
                            numJIDAI_JOGEN22.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JIDAI")) Then
                            numJIDAI_JIDAI22.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JIDAI")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_JOGEN")) Then
                            numGENKA_JOGEN22.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_SYOKYAKU")) Then
                            numGENKA_SYOKYAKU22.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_SYOKYAKU")))
                        End If
                        If Not IsDBNull(.Rows(i)("KUSYA")) Then
                            numKUSYA22.Value = CDec(WordHenkan("N", "S", .Rows(i)("KUSYA")))
                        End If
                    End If


                    '企業型-肉用鶏
                    If .Rows(i)("KEIYAKU_KBN") = 2 And .Rows(i)("TORI_KBN") = 3 Then
                        If Not IsDBNull(.Rows(i)("KOYO_JOGEN")) Then
                            numKOYO_JOGEN23.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("KOYO_KOYO")) Then
                            numKOYO_KOYO23.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_KOYO")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JOGEN")) Then
                            numJIDAI_JOGEN23.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JIDAI")) Then
                            numJIDAI_JIDAI23.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JIDAI")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_JOGEN")) Then
                            numGENKA_JOGEN23.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_SYOKYAKU")) Then
                            numGENKA_SYOKYAKU23.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_SYOKYAKU")))
                        End If
                        If Not IsDBNull(.Rows(i)("KUSYA")) Then
                            numKUSYA23.Value = CDec(WordHenkan("N", "S", .Rows(i)("KUSYA")))
                        End If
                    End If

                    '企業型-種鶏(成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 2 And .Rows(i)("TORI_KBN") = 4 Then
                        If Not IsDBNull(.Rows(i)("KOYO_JOGEN")) Then
                            numKOYO_JOGEN24.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("KOYO_KOYO")) Then
                            numKOYO_KOYO24.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_KOYO")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JOGEN")) Then
                            numJIDAI_JOGEN24.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JIDAI")) Then
                            numJIDAI_JIDAI24.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JIDAI")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_JOGEN")) Then
                            numGENKA_JOGEN24.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_SYOKYAKU")) Then
                            numGENKA_SYOKYAKU24.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_SYOKYAKU")))
                        End If
                        If Not IsDBNull(.Rows(i)("KUSYA")) Then
                            numKUSYA24.Value = CDec(WordHenkan("N", "S", .Rows(i)("KUSYA")))
                        End If
                    End If

                    '企業型-種鶏(育成鶏)
                    If .Rows(i)("KEIYAKU_KBN") = 2 And .Rows(i)("TORI_KBN") = 5 Then
                        If Not IsDBNull(.Rows(i)("KOYO_JOGEN")) Then
                            numKOYO_JOGEN25.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("KOYO_KOYO")) Then
                            numKOYO_KOYO25.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_KOYO")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JOGEN")) Then
                            numJIDAI_JOGEN25.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JIDAI")) Then
                            numJIDAI_JIDAI25.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JIDAI")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_JOGEN")) Then
                            numGENKA_JOGEN25.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_SYOKYAKU")) Then
                            numGENKA_SYOKYAKU25.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_SYOKYAKU")))
                        End If
                        If Not IsDBNull(.Rows(i)("KUSYA")) Then
                            numKUSYA25.Value = CDec(WordHenkan("N", "S", .Rows(i)("KUSYA")))
                        End If
                    End If


                    'うずら-うずら
                    If .Rows(i)("KEIYAKU_KBN") = 3 And .Rows(i)("TORI_KBN") = 6 Then
                        If Not IsDBNull(.Rows(i)("KOYO_JOGEN")) Then
                            numKOYO_JOGEN36.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("KOYO_KOYO")) Then
                            numKOYO_KOYO36.Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_KOYO")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JOGEN")) Then
                            numJIDAI_JOGEN36.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JIDAI")) Then
                            numJIDAI_JIDAI36.Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JIDAI")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_JOGEN")) Then
                            numGENKA_JOGEN36.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_SYOKYAKU")) Then
                            numGENKA_SYOKYAKU36.Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_SYOKYAKU")))
                        End If
                        If Not IsDBNull(.Rows(i)("KUSYA")) Then
                            numKUSYA36.Value = CDec(WordHenkan("N", "S", .Rows(i)("KUSYA")))
                        End If
                    End If

                    '↓2017/07/13 修正 鳥の種類追加
                    '鶏以外-あひる～だちょう
                    Dim tori As Integer = .Rows(i)("TORI_KBN")
                    If .Rows(i)("KEIYAKU_KBN") = 3 And (tori >= 7 And tori <= 11) Then
                        tori = tori + 30
                        If Not IsDBNull(.Rows(i)("KOYO_JOGEN")) Then
                            DirectCast(Me.Controls("numKOYO_JOGEN" & tori.ToString), JBD.Gjs.Win.GcNumber).Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("KOYO_KOYO")) Then
                            DirectCast(Me.Controls("numKOYO_KOYO" & tori.ToString), JBD.Gjs.Win.GcNumber).Value = CDec(WordHenkan("N", "S", .Rows(i)("KOYO_KOYO")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JOGEN")) Then
                            DirectCast(Me.Controls("numJIDAI_JOGEN" & tori.ToString), JBD.Gjs.Win.GcNumber).Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("JIDAI_JIDAI")) Then
                            DirectCast(Me.Controls("numJIDAI_JIDAI" & tori.ToString), JBD.Gjs.Win.GcNumber).Value = CDec(WordHenkan("N", "S", .Rows(i)("JIDAI_JIDAI")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_JOGEN")) Then
                            DirectCast(Me.Controls("numGENKA_JOGEN" & tori.ToString), JBD.Gjs.Win.GcNumber).Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_JOGEN")))
                        End If
                        If Not IsDBNull(.Rows(i)("GENKA_SYOKYAKU")) Then
                            DirectCast(Me.Controls("numGENKA_SYOKYAKU" & tori.ToString), JBD.Gjs.Win.GcNumber).Value = CDec(WordHenkan("N", "S", .Rows(i)("GENKA_SYOKYAKU")))
                        End If
                        If Not IsDBNull(.Rows(i)("KUSYA")) Then
                            DirectCast(Me.Controls("numKUSYA" & tori.ToString), JBD.Gjs.Win.GcNumber).Value = CDec(WordHenkan("N", "S", .Rows(i)("KUSYA")))
                        End If
                    End If
                    '↑2017/07/13 修正 鳥の種類追加

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

            '==必須チェック==================
            wkControlName = "期"
            If numKI.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKI.Focus() : Exit Try
            End If
            wkControlName = "対象年度"
            If dateTAISYO_NENDO.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : dateTAISYO_NENDO.Focus() : Exit Try
            End If

            '==いろいろチェック==================
            '年度範囲チェック
            'Dim dtJIGYO_NENDO = New Obj_TM_SYORI_NENDO_KI().pJIGYO_NENDO_byDate
            'Dim dtJIGYO_SYURYO_NENDO = New Obj_TM_SYORI_NENDO_KI().pJIGYO_SYURYO_NENDO_byDate
            'If dtJIGYO_NENDO > dateTAISYO_NENDO.Value Or dtJIGYO_SYURYO_NENDO < dateTAISYO_NENDO.Value Then
            '    wkControlName = "対象期範囲外の年度"
            '    Call Show_MessageBox_Add("W029", wkControlName) : dateTAISYO_NENDO.Focus() : Exit Try
            'End If

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
            wkControlName = "対象年度"
            If dateTAISYO_NENDO.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : dateTAISYO_NENDO.Focus() : Exit Try
            End If

            '各項目の必須チェック
            wkControlName = "家族型　採卵鶏（成鶏）上限単価"
            If numKOYO_JOGEN11.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_JOGEN11.Focus() : Exit Try
            End If
            wkControlName = "家族型　採卵鶏（成鶏）雇用労費"
            If numKOYO_KOYO11.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_KOYO11.Focus() : Exit Try
            End If
            wkControlName = "家族型　採卵鶏（成鶏）上限地代"
            If numJIDAI_JOGEN11.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JOGEN11.Focus() : Exit Try
            End If
            wkControlName = "家族型　採卵鶏（成鶏）地代"
            If numJIDAI_JIDAI11.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JIDAI11.Focus() : Exit Try
            End If
            wkControlName = "家族型　採卵鶏（成鶏）上限減価償却費"
            If numGENKA_JOGEN11.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_JOGEN11.Focus() : Exit Try
            End If
            wkControlName = "家族型　採卵鶏（成鶏）償却費"
            If numGENKA_SYOKYAKU11.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_SYOKYAKU11.Focus() : Exit Try
            End If
            wkControlName = "家族型　採卵鶏（成鶏）空舎期間"
            If numKUSYA11.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKUSYA11.Focus() : Exit Try
            End If


            wkControlName = "家族型　採卵鶏（育成鶏）上限単価"
            If numKOYO_JOGEN12.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_JOGEN12.Focus() : Exit Try
            End If
            wkControlName = "家族型　採卵鶏（育成鶏）雇用労費"
            If numKOYO_KOYO12.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_KOYO12.Focus() : Exit Try
            End If
            wkControlName = "家族型　採卵鶏（育成鶏）上限地代"
            If numJIDAI_JOGEN12.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JOGEN12.Focus() : Exit Try
            End If
            wkControlName = "家族型　採卵鶏（育成鶏）地代"
            If numJIDAI_JIDAI12.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JIDAI12.Focus() : Exit Try
            End If
            wkControlName = "家族型　採卵鶏（育成鶏）上限減価償却費"
            If numGENKA_JOGEN12.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_JOGEN12.Focus() : Exit Try
            End If
            wkControlName = "家族型　採卵鶏（育成鶏）償却費"
            If numGENKA_SYOKYAKU12.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_SYOKYAKU12.Focus() : Exit Try
            End If
            wkControlName = "家族型　採卵鶏（育成鶏）空舎期間"
            If numKUSYA12.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKUSYA12.Focus() : Exit Try
            End If



            wkControlName = "家族型　肉用鶏　上限単価"
            If numKOYO_JOGEN13.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_JOGEN13.Focus() : Exit Try
            End If
            wkControlName = "家族型　肉用鶏　雇用労費"
            If numKOYO_KOYO13.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_KOYO13.Focus() : Exit Try
            End If
            wkControlName = "家族型　肉用鶏　上限地代"
            If numJIDAI_JOGEN13.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JOGEN13.Focus() : Exit Try
            End If
            wkControlName = "家族型　肉用鶏　地代"
            If numJIDAI_JIDAI13.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JIDAI13.Focus() : Exit Try
            End If
            wkControlName = "家族型　肉用鶏　上限減価償却費"
            If numGENKA_JOGEN13.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_JOGEN13.Focus() : Exit Try
            End If
            wkControlName = "家族型　肉用鶏　償却費"
            If numGENKA_SYOKYAKU13.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_SYOKYAKU13.Focus() : Exit Try
            End If
            wkControlName = "家族型　肉用鶏　空舎期間"
            If numKUSYA13.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKUSYA13.Focus() : Exit Try
            End If



            wkControlName = "家族型　種鶏（成鶏）上限単価"
            If numKOYO_JOGEN14.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_JOGEN14.Focus() : Exit Try
            End If
            wkControlName = "家族型　種鶏（成鶏）雇用労費"
            If numKOYO_KOYO14.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_KOYO14.Focus() : Exit Try
            End If
            wkControlName = "家族型　種鶏（成鶏）上限地代"
            If numJIDAI_JOGEN14.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JOGEN14.Focus() : Exit Try
            End If
            wkControlName = "家族型　種鶏（成鶏）地代"
            If numJIDAI_JIDAI14.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JIDAI14.Focus() : Exit Try
            End If
            wkControlName = "家族型　種鶏（成鶏）上限減価償却費"
            If numGENKA_JOGEN14.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_JOGEN14.Focus() : Exit Try
            End If
            wkControlName = "家族型　種鶏（成鶏）償却費"
            If numGENKA_SYOKYAKU14.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_SYOKYAKU14.Focus() : Exit Try
            End If
            wkControlName = "家族型　種鶏（成鶏）空舎期間"
            If numKUSYA14.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKUSYA14.Focus() : Exit Try
            End If



            wkControlName = "家族型　種鶏（育成鶏）上限単価"
            If numKOYO_JOGEN15.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_JOGEN15.Focus() : Exit Try
            End If
            wkControlName = "家族型　種鶏（育成鶏）雇用労費"
            If numKOYO_KOYO15.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_KOYO15.Focus() : Exit Try
            End If
            wkControlName = "家族型　種鶏（育成鶏）上限地代"
            If numJIDAI_JOGEN15.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JOGEN15.Focus() : Exit Try
            End If
            wkControlName = "家族型　種鶏（育成鶏）地代"
            If numJIDAI_JIDAI15.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JIDAI15.Focus() : Exit Try
            End If
            wkControlName = "家族型　種鶏（育成鶏）上限減価償却費"
            If numGENKA_JOGEN15.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_JOGEN15.Focus() : Exit Try
            End If
            wkControlName = "家族型　種鶏（育成鶏）償却費"
            If numGENKA_SYOKYAKU15.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_SYOKYAKU15.Focus() : Exit Try
            End If
            wkControlName = "家族型　種鶏（育成鶏）空舎期間"
            If numKUSYA15.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKUSYA15.Focus() : Exit Try
            End If



            wkControlName = "企業型　採卵鶏（成鶏）上限単価"
            If numKOYO_JOGEN21.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_JOGEN21.Focus() : Exit Try
            End If
            wkControlName = "企業型　採卵鶏（成鶏）雇用労費"
            If numKOYO_KOYO21.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_KOYO21.Focus() : Exit Try
            End If
            wkControlName = "企業型　採卵鶏（成鶏）上限地代"
            If numJIDAI_JOGEN21.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JOGEN21.Focus() : Exit Try
            End If
            wkControlName = "企業型　採卵鶏（成鶏）地代"
            If numJIDAI_JIDAI21.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JIDAI21.Focus() : Exit Try
            End If
            wkControlName = "企業型　採卵鶏（成鶏）上限減価償却費"
            If numGENKA_JOGEN21.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_JOGEN21.Focus() : Exit Try
            End If
            wkControlName = "企業型　採卵鶏（成鶏）償却費"
            If numGENKA_SYOKYAKU21.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_SYOKYAKU21.Focus() : Exit Try
            End If
            wkControlName = "企業型　採卵鶏（成鶏）空舎期間"
            If numKUSYA21.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKUSYA21.Focus() : Exit Try
            End If


            wkControlName = "企業型　採卵鶏（育成鶏）上限単価"
            If numKOYO_JOGEN22.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_JOGEN22.Focus() : Exit Try
            End If
            wkControlName = "企業型　採卵鶏（育成鶏）雇用労費"
            If numKOYO_KOYO22.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_KOYO22.Focus() : Exit Try
            End If
            wkControlName = "企業型　採卵鶏（育成鶏）上限地代"
            If numJIDAI_JOGEN22.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JOGEN22.Focus() : Exit Try
            End If
            wkControlName = "企業型　採卵鶏（育成鶏）地代"
            If numJIDAI_JIDAI22.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JIDAI22.Focus() : Exit Try
            End If
            wkControlName = "企業型　採卵鶏（育成鶏）上限減価償却費"
            If numGENKA_JOGEN22.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_JOGEN22.Focus() : Exit Try
            End If
            wkControlName = "企業型　採卵鶏（育成鶏）償却費"
            If numGENKA_SYOKYAKU22.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_SYOKYAKU22.Focus() : Exit Try
            End If
            wkControlName = "企業型　採卵鶏（育成鶏）空舎期間"
            If numKUSYA22.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKUSYA22.Focus() : Exit Try
            End If


            wkControlName = "企業型　肉用鶏　上限単価"
            If numKOYO_JOGEN23.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_JOGEN23.Focus() : Exit Try
            End If
            wkControlName = "企業型　肉用鶏　雇用労費"
            If numKOYO_KOYO23.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_KOYO23.Focus() : Exit Try
            End If
            wkControlName = "企業型　肉用鶏　上限地代"
            If numJIDAI_JOGEN23.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JOGEN23.Focus() : Exit Try
            End If
            wkControlName = "企業型　肉用鶏　地代"
            If numJIDAI_JIDAI23.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JIDAI23.Focus() : Exit Try
            End If
            wkControlName = "企業型　肉用鶏　上限減価償却費"
            If numGENKA_JOGEN23.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_JOGEN23.Focus() : Exit Try
            End If
            wkControlName = "企業型　肉用鶏　償却費"
            If numGENKA_SYOKYAKU23.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_SYOKYAKU23.Focus() : Exit Try
            End If
            wkControlName = "企業型　肉用鶏　空舎期間"
            If numKUSYA23.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKUSYA23.Focus() : Exit Try
            End If



            wkControlName = "企業型　種鶏（成鶏）上限単価"
            If numKOYO_JOGEN24.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_JOGEN24.Focus() : Exit Try
            End If
            wkControlName = "企業型　種鶏（成鶏）雇用労費"
            If numKOYO_KOYO24.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_KOYO24.Focus() : Exit Try
            End If
            wkControlName = "企業型　種鶏（成鶏）上限地代"
            If numJIDAI_JOGEN24.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JOGEN24.Focus() : Exit Try
            End If
            wkControlName = "企業型　種鶏（成鶏）地代"
            If numJIDAI_JIDAI24.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JIDAI24.Focus() : Exit Try
            End If
            wkControlName = "企業型　種鶏（成鶏）上限減価償却費"
            If numGENKA_JOGEN24.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_JOGEN24.Focus() : Exit Try
            End If
            wkControlName = "企業型　種鶏（成鶏）償却費"
            If numGENKA_SYOKYAKU24.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_SYOKYAKU24.Focus() : Exit Try
            End If
            wkControlName = "企業型　種鶏（成鶏）空舎期間"
            If numKUSYA24.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKUSYA24.Focus() : Exit Try
            End If



            wkControlName = "企業型　種鶏（育成鶏）上限単価"
            If numKOYO_JOGEN25.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_JOGEN25.Focus() : Exit Try
            End If
            wkControlName = "企業型　種鶏（育成鶏）雇用労費"
            If numKOYO_KOYO25.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_KOYO25.Focus() : Exit Try
            End If
            wkControlName = "企業型　種鶏（育成鶏）上限地代"
            If numJIDAI_JOGEN25.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JOGEN25.Focus() : Exit Try
            End If
            wkControlName = "企業型　種鶏（育成鶏）地代"
            If numJIDAI_JIDAI25.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JIDAI25.Focus() : Exit Try
            End If
            wkControlName = "企業型　種鶏（育成鶏）上限減価償却費"
            If numGENKA_JOGEN25.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_JOGEN25.Focus() : Exit Try
            End If
            wkControlName = "企業型　種鶏（育成鶏）償却費"
            If numGENKA_SYOKYAKU25.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_SYOKYAKU25.Focus() : Exit Try
            End If
            wkControlName = "企業型　種鶏（育成鶏）空舎期間"
            If numKUSYA25.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKUSYA25.Focus() : Exit Try
            End If



            wkControlName = "うずら　上限単価"
            If numKOYO_JOGEN36.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_JOGEN36.Focus() : Exit Try
            End If
            wkControlName = "うずら　雇用労費"
            If numKOYO_KOYO36.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKOYO_KOYO36.Focus() : Exit Try
            End If
            wkControlName = "うずら　上限地代"
            If numJIDAI_JOGEN36.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JOGEN36.Focus() : Exit Try
            End If
            wkControlName = "うずら　地代"
            If numJIDAI_JIDAI36.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numJIDAI_JIDAI36.Focus() : Exit Try
            End If
            wkControlName = "うずら　上限減価償却費"
            If numGENKA_JOGEN36.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_JOGEN36.Focus() : Exit Try
            End If
            wkControlName = "うずら　償却費"
            If numGENKA_SYOKYAKU36.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numGENKA_SYOKYAKU36.Focus() : Exit Try
            End If
            wkControlName = "うずら　空舎期間"
            If numKUSYA36.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numKUSYA36.Focus() : Exit Try
            End If

            '↓2017/07/13 修正 鳥の種類追加
            '鶏以外-あひる～だちょう
            For i = 37 To 41
                Dim toriname As String()
                toriname = {"あひる", "きじ", "ほろほろ鳥", "七面鳥", "だちょう"}
                wkControlName = toriname(i - 37) & "　上限単価"
                If DirectCast(Me.Controls("numKOYO_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : DirectCast(Me.Controls("numKOYO_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Focus() : Exit Try
                End If
                wkControlName = toriname(i - 37) & "　雇用労費"
                If DirectCast(Me.Controls("numKOYO_KOYO" & i.ToString), JBD.Gjs.Win.GcNumber).Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : DirectCast(Me.Controls("numKOYO_KOYO" & i.ToString), JBD.Gjs.Win.GcNumber).Focus() : Exit Try
                End If
                wkControlName = toriname(i - 37) & "　上限地代"
                If DirectCast(Me.Controls("numJIDAI_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : DirectCast(Me.Controls("numJIDAI_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Focus() : Exit Try
                End If
                wkControlName = toriname(i - 37) & "　地代"
                If DirectCast(Me.Controls("numJIDAI_JIDAI" & i.ToString), JBD.Gjs.Win.GcNumber).Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : DirectCast(Me.Controls("numJIDAI_JIDAI" & i.ToString), JBD.Gjs.Win.GcNumber).Focus() : Exit Try
                End If
                wkControlName = toriname(i - 37) & "　上限減価償却費"
                If DirectCast(Me.Controls("numGENKA_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : DirectCast(Me.Controls("numGENKA_JOGEN" & i.ToString), JBD.Gjs.Win.GcNumber).Focus() : Exit Try
                End If
                wkControlName = toriname(i - 37) & "　償却費"
                If DirectCast(Me.Controls("numGENKA_SYOKYAKU" & i.ToString), JBD.Gjs.Win.GcNumber).Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : DirectCast(Me.Controls("numGENKA_SYOKYAKU" & i.ToString), JBD.Gjs.Win.GcNumber).Focus() : Exit Try
                End If
                wkControlName = toriname(i - 37) & "　空舎期間"
                If DirectCast(Me.Controls("numKUSYA" & i.ToString), JBD.Gjs.Win.GcNumber).Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : DirectCast(Me.Controls("numKUSYA" & i.ToString), JBD.Gjs.Win.GcNumber).Focus() : Exit Try
                End If
            Next
            '↑2017/07/13 修正 鳥の種類追加


            '==いろいろチェック==================
            '年度範囲チェック
            Dim dtJIGYO_NENDO = New Obj_TM_SYORI_NENDO_KI().pJIGYO_NENDO_byDate
            Dim dtJIGYO_SYURYO_NENDO = New Obj_TM_SYORI_NENDO_KI().pJIGYO_SYURYO_NENDO_byDate
            If dtJIGYO_NENDO > dateTAISYO_NENDO.Value Or dtJIGYO_SYURYO_NENDO < dateTAISYO_NENDO.Value Then
                wkControlName = "対象期範囲外の年度"
                Call Show_MessageBox_Add("W029", wkControlName) : dateTAISYO_NENDO.Focus() : Exit Try
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
