'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ8030.vb
'*
'*　　②　機能概要　　　　　日本養鶏協会マスタメンテナンス
'*
'*　　③　作成日　　　　　　2014/01/16  BY JBD
'*
'*　　④　更新日            2023/08/04  BY JBD454
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

Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.ActiveReports.Export
Imports GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport

Imports System.IO

Public Class frmGJ8030

#Region "*** 変数定義 ***"

    Private pMST_DataSet As New DataSet                 'マスタ用データセット
    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ
    Private pblnErrDsp As Boolean                       'コンボ　エラー表示


    ''' <summary>
    ''' 新規/更新モード
    ''' </summary>
    ''' <remarks></remarks>
    Enum enuMode
        search = 0
        Insert = 1
        Update = 2
        read = 3
    End Enum

    ''' <summary>
    ''' 現在モード
    ''' </summary>
    ''' <remarks></remarks>
    Private loMode As enuMode = enuMode.search
    
    ''' <summary>
    ''' プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True                     '処理ジャンプ

#End Region

#Region "*** 画面制御関連 ***"

#Region "frmGJ8030_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ8030_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ8030_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean

        Try

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            '画面初期表示
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
    '------------------------------------------------------------------
    'プロシージャ名  :f_setControlChangeEvents
    '説明            :変更判定イベント登録
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


            End Select
        Next
    End Sub
#End Region
#Region "f_setChanged コントロール変更時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_setChanged
    '説明            :コントロール変更時処理
    '------------------------------------------------------------------
    Private Sub f_setChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        pblnTextChange = True

    End Sub
#End Region

#End Region

#Region "*** 画面ボタンクリック関連 ***"

#Region "cmdCancel_Click キャンセルボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdCancel_Click
    '説明            :キャンセルボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            
            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then
                    Exit Try
                End If
            End If

            '画面クリア
            ret = f_ObjectClear("")

            '先頭入力フォーカスセット
            txt_KYOKAI_NAME.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdSav_Click 保存ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSav_Click
    '説明            :保存ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSav.Click
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '入力項目チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '保存処理確認
            If Show_MessageBox("Q003", "") = DialogResult.No Then    '保存します。よろしいですか？
                Exit Try
            End If

            'データ保存
            If f_Data_Update() Then
                Show_MessageBox_Add("I001")
            End If

            '画面初期表示
            ret = f_ObjectClear("")

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
            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
                    '「いいえ」を選択
                    Exit Try
                End If
            End If
            If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                '「いいえ」を選択
                Exit Try
            End If

            'フォームクローズ
            Me.AutoValidate = AutoValidate.Disable      '2010/10/16 ADD JBD200
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

#Region "*** 画面コントロール制御関連 ***"

#Region "振込口座情報　金融機関"
    '------------------------------------------------------------------
    'プロシージャ名  :cbo_FURI_BANK_CD_SelectedIndexChanged
    '説明            :金融機関コードChanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_FURI_BANK_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_FURI_BANK_CD.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_FURI_BANK_NM.SelectedIndex = cbo_FURI_BANK_CD.SelectedIndex

        '金融機関支店マスタコンボセット
        If cbo_FURI_BANK_CD.Text <> "" Then
            Call f_BankShop_Data_Select(cbo_FURI_BANK_SITEN_CD, cbo_FURI_BANK_SITEN_NM, cbo_FURI_BANK_CD.Text, True)
        Else
            cbo_FURI_BANK_SITEN_CD.Items.Clear()
            cbo_FURI_BANK_SITEN_NM.Items.Clear()
        End If

    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cbo_FURI_BANK_NM_SelectedIndexChanged
    '説明            :金融機関名Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_FURI_BANK_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_FURI_BANK_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_FURI_BANK_CD.SelectedIndex = cbo_FURI_BANK_NM.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_FURI_BANK_CD_Validating
    '説明            :金融機関コード_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cbo_FURI_BANK_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbo_FURI_BANK_CD.Validating

        If cbo_FURI_BANK_CD.Text = "" Then
            Exit Sub
        End If

        cbo_FURI_BANK_CD.SelectedValue = cbo_FURI_BANK_CD.Text
        If cbo_FURI_BANK_CD.SelectedValue Is Nothing Then
            cbo_FURI_BANK_CD.SelectedIndex = -1
            cbo_FURI_BANK_NM.SelectedIndex = -1
            If pblnErrDsp Then
                Show_MessageBox_Add("W012", "金融機関") '指定された@0が正しくありません。
                'Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION) '該当データが存在しません。
                cbo_FURI_BANK_CD.Focus()
            End If
        End If

    End Sub


#End Region
#Region "振込口座情報　本支店"
    '------------------------------------------------------------------
    'プロシージャ名  :cbo_FURI_BANK_SITEN_CD_SelectedIndexChanged
    '説明            :本支店コードChanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_FURI_BANK_SITEN_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_FURI_BANK_SITEN_CD.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_FURI_BANK_SITEN_NM.SelectedIndex = cbo_FURI_BANK_SITEN_CD.SelectedIndex

    End Sub

    ''------------------------------------------------------------------
    ''プロシージャ名  :cbo_FURI_BANK_SITEN_NM_SelectedIndexChanged
    ''説明            :本支店名Chanegeイベント
    ''------------------------------------------------------------------
    Private Sub cbo_FURI_BANK_SITEN_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_FURI_BANK_SITEN_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_FURI_BANK_SITEN_CD.SelectedIndex = cbo_FURI_BANK_SITEN_NM.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_FURI_BANK_SITEN_CD_Validating
    '説明            :本支店コード_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cbo_FURI_BANK_SITEN_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbo_FURI_BANK_SITEN_CD.Validating

        If cbo_FURI_BANK_SITEN_CD.Text = "" Then
            Exit Sub
        End If

        cbo_FURI_BANK_SITEN_CD.SelectedValue = cbo_FURI_BANK_SITEN_CD.Text
        If cbo_FURI_BANK_SITEN_CD.SelectedValue Is Nothing Then
            cbo_FURI_BANK_SITEN_CD.SelectedIndex = -1
            cbo_FURI_BANK_SITEN_NM.SelectedIndex = -1
            If pblnErrDsp Then
                Show_MessageBox_Add("W012", "本支店") '指定された@0が正しくありません。
                'Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION) '該当データが存在しません。
                cbo_FURI_BANK_SITEN_CD.Focus()
            End If
        End If
    End Sub

#End Region
#Region "振込口座情報　口座種別"
    '------------------------------------------------------------------
    'プロシージャ名  :cbo_FURI_KOZA_SYUBETU_SelectedIndexChanged
    '説明            :口座種別コードChanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_FURI_KOZA_SYUBETU_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_FURI_KOZA_SYUBETU.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_FURI_KOZA_SYUBETU_NM.SelectedIndex = cbo_FURI_KOZA_SYUBETU.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_FURI_KOZA_SYUBETU_NM_SelectedIndexChanged
    '説明            :口座種別名Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_FURI_KOZA_SYUBETU_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_FURI_KOZA_SYUBETU_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_FURI_KOZA_SYUBETU.SelectedIndex = cbo_FURI_KOZA_SYUBETU_NM.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_FURI_KOZA_SYUBETU_Validating
    '説明            :口座種別コード_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cbo_FURI_KOZA_SYUBETU_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbo_FURI_KOZA_SYUBETU.Validating

        If cbo_FURI_KOZA_SYUBETU.Text = "" Then
            Exit Sub
        End If

        cbo_FURI_KOZA_SYUBETU.SelectedValue = cbo_FURI_KOZA_SYUBETU.Text
        If cbo_FURI_KOZA_SYUBETU.SelectedValue Is Nothing Then
            cbo_FURI_KOZA_SYUBETU.SelectedIndex = -1
            cbo_FURI_KOZA_SYUBETU_NM.SelectedIndex = -1
            If pblnErrDsp Then
                Show_MessageBox_Add("W012", "口座種別") '指定された@0が正しくありません。
                'Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION) '該当データが存在しません。
                cbo_FURI_KOZA_SYUBETU.Focus()
            End If
        End If

    End Sub

#End Region

#Region "支払口座情報　金融機関"
    '------------------------------------------------------------------
    'プロシージャ名  :cbo_KOFU_BANK_CD_SelectedIndexChanged
    '説明            :金融機関コードChanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_KOFU_BANK_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_KOFU_BANK_CD.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_KOFU_BANK_NM.SelectedIndex = cbo_KOFU_BANK_CD.SelectedIndex

        '金融機関支店マスタコンボセット
        If cbo_KOFU_BANK_CD.Text <> "" Then
            Call f_BankShop_Data_Select(cbo_KOFU_BANK_SITEN_CD, cbo_KOFU_BANK_SITEN_NM, cbo_KOFU_BANK_CD.Text, True)
        Else
            cbo_KOFU_BANK_SITEN_CD.Items.Clear()
            cbo_KOFU_BANK_SITEN_NM.Items.Clear()
        End If

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_KOFU_BANK_NM_SelectedIndexChanged
    '説明            :金融機関名Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_KOFU_BANK_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_KOFU_BANK_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_KOFU_BANK_CD.SelectedIndex = cbo_KOFU_BANK_NM.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_KOFU_BANK_CD_Validating
    '説明            :金融機関コード_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cbo_KOFU_BANK_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbo_KOFU_BANK_CD.Validating

        If cbo_KOFU_BANK_CD.Text = "" Then
            Exit Sub
        End If

        cbo_KOFU_BANK_CD.SelectedValue = cbo_KOFU_BANK_CD.Text
        If cbo_KOFU_BANK_CD.SelectedValue Is Nothing Then
            cbo_KOFU_BANK_CD.SelectedIndex = -1
            cbo_KOFU_BANK_NM.SelectedIndex = -1
            If pblnErrDsp Then
                Show_MessageBox_Add("W012", "金融機関") '指定された@0が正しくありません。
                'Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION) '該当データが存在しません。
                cbo_KOFU_BANK_CD.Focus()
            End If
        End If

    End Sub

#End Region
#Region "支払口座情報　本支店"
    '------------------------------------------------------------------
    'プロシージャ名  :cbo_KOFU_BANK_SITEN_CD_SelectedIndexChanged
    '説明            :本支店コードChanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_KOFU_BANK_SITEN_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_KOFU_BANK_SITEN_CD.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_KOFU_BANK_SITEN_NM.SelectedIndex = cbo_KOFU_BANK_SITEN_CD.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_KOFU_BANK_SITEN_NM_SelectedIndexChanged
    '説明            :本支店名Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_KOFU_BANK_SITEN_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_KOFU_BANK_SITEN_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_KOFU_BANK_SITEN_CD.SelectedIndex = cbo_KOFU_BANK_SITEN_NM.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_KOFU_BANK_SITEN_CD_Validating
    '説明            :本支店コード_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cbo_KOFU_BANK_SITEN_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbo_KOFU_BANK_SITEN_CD.Validating

        If cbo_KOFU_BANK_SITEN_CD.Text = "" Then
            Exit Sub
        End If

        cbo_KOFU_BANK_SITEN_CD.SelectedValue = cbo_KOFU_BANK_SITEN_CD.Text
        If cbo_KOFU_BANK_SITEN_CD.SelectedValue Is Nothing Then
            cbo_KOFU_BANK_SITEN_CD.SelectedIndex = -1
            cbo_KOFU_BANK_SITEN_NM.SelectedIndex = -1
            If pblnErrDsp Then
                Show_MessageBox_Add("W012", "本支店") '指定された@0が正しくありません。
                'Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION) '該当データが存在しません。
                cbo_KOFU_BANK_SITEN_CD.Focus()
            End If
        End If
    End Sub



#End Region
#Region "支払口座情報　口座種別"
    '------------------------------------------------------------------
    'プロシージャ名  :cbo_KOFU_KOZA_SYUBETU_SelectedIndexChanged
    '説明            :口座種別コードChanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_KOFU_KOZA_SYUBETU_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_KOFU_KOZA_SYUBETU.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_KOFU_KOZA_SYUBETU_NM.SelectedIndex = cbo_KOFU_KOZA_SYUBETU.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_KOFU_KOZA_SYUBETU_NM_SelectedIndexChanged
    '説明            :口座種別名Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_KOFU_KOZA_SYUBETU_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_KOFU_KOZA_SYUBETU_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_KOFU_KOZA_SYUBETU.SelectedIndex = cbo_KOFU_KOZA_SYUBETU_NM.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_KOFU_KOZA_SYUBETU_Validating
    '説明            :口座種別コード_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cbo_KOFU_KOZA_SYUBETU_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbo_KOFU_KOZA_SYUBETU.Validating

        If cbo_KOFU_KOZA_SYUBETU.Text = "" Then
            Exit Sub
        End If

        cbo_KOFU_KOZA_SYUBETU.SelectedValue = cbo_KOFU_KOZA_SYUBETU.Text
        If cbo_KOFU_KOZA_SYUBETU.SelectedValue Is Nothing Then
            cbo_KOFU_KOZA_SYUBETU.SelectedIndex = -1
            cbo_KOFU_KOZA_SYUBETU_NM.SelectedIndex = -1
            If pblnErrDsp Then
                Show_MessageBox_Add("W012", "口座種別") '指定された@0が正しくありません。
                'Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION) '該当データが存在しません。
                cbo_KOFU_KOZA_SYUBETU.Focus()
            End If
        End If

    End Sub

#End Region

#Region "画面先頭項目のIME_MODEが無効になるのを防ぐ"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_TEST_GotFocus
    '説明            :画面先頭項目のIME_MODEが無効になるのを防ぐ為に
    '                 隠し項目(TEXT以外)を作成
    '                 GotFocusしたら、隠し項目を不可視にする
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub btnFIRST_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFIRST.GotFocus
        btnFIRST.Visible = False
    End Sub
#End Region

#End Region

#Region "*** データ登録関連 ***"
#Region "f_Data_Update 協会マスタデータ更新"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Update
    '説明            :協会マスタデータ更新
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Update() As Boolean
        Dim Cmd As New OracleCommand
        Dim sSql As String = String.Empty
        Dim ret As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            If loMode = enuMode.Insert Then
                '新規入力
                Cmd.CommandText = "PKG_GJ8030.GJ8030_KYOKAI_INS"
            ElseIf loMode = enuMode.Update Then
                '変更
                Cmd.CommandText = "PKG_GJ8030.GJ8030_KYOKAI_UPD"
            End If

            '--------------------
            '基本情報
            '--------------------
            '協会区分 １を固定で設定
            Cmd.Parameters.Add("IN_KYOKAI_KBN", 1)
            '協会名称 ”社団法人　日本養鶏協会”
            Cmd.Parameters.Add("IN_KYOKAI_NAME", txt_KYOKAI_NAME.Text.Trim)
            '役職名 ”会長”
            Cmd.Parameters.Add("IN_YAKUMEI", txt_YAKUMEI.Text.Trim)
            '会長名 ”木下　寛之”
            Cmd.Parameters.Add("IN_KAICHO_NAME", txt_KAICHO_NAME.Text.Trim)

            '事業名
            Cmd.Parameters.Add("IN_JIGYO_NAME", txt_JIGYO_NAME.Text.Trim)
            '予備1
            Cmd.Parameters.Add("IN_YOBI1", txt_YOBI1.Text.Trim)

            '郵便番号
            Cmd.Parameters.Add("IN_POST", msk_POST.Value)
            '住所１
            Cmd.Parameters.Add("IN_ADDR1", txt_ADDR1.Text.Trim)
            '住所２
            Cmd.Parameters.Add("IN_ADDR2", txt_ADDR2.Text.Trim)

            '電話番号１ 連絡先１
            Cmd.Parameters.Add("IN_TEL1", txt_TEL1.Text.Trim)
            'ＦＡＸ１
            Cmd.Parameters.Add("IN_FAX1", txt_FAX1.Text.Trim)
            'Ｅ－ｍａｉｌ１
            Cmd.Parameters.Add("IN_E_MAIL1", txt_E_MAIL1.Text.Trim)

            '電話番号２ 連絡先２
            Cmd.Parameters.Add("IN_TEL2", txt_TEL2.Text.Trim)
            'ＦＡＸ２
            Cmd.Parameters.Add("IN_FAX2", txt_FAX2.Text.Trim)
            'Ｅ－ｍａｉｌ２
            Cmd.Parameters.Add("IN_E_MAIL2", txt_E_MAIL2.Text.Trim)
            'ホームページURL
            Cmd.Parameters.Add("IN_HP_URL", txt_HP_URL.Text.Trim)

            '登録番号  2023/08/04 JBD454 R5年度インボイス対応 ADD
            Cmd.Parameters.Add("IN_TOUROKU_NO", txt_TOUROKU_NO.Text.Trim)

            '発行番号・漢字
            Cmd.Parameters.Add("IN_HAKKO_NO_KANJI", txt_HAKKO_NO_KANJI.Text.Trim)

            '--------------------
            '振込口座情報
            '--------------------
            '振込口座（金融機関） 生産者積立金振込先金融機関情報１
            Cmd.Parameters.Add("IN_FURI_BANK_CD", cbo_FURI_BANK_CD.Text.Trim)
            '振込先支店コード
            Cmd.Parameters.Add("IN_FURI_BANK_SITEN_CD", cbo_FURI_BANK_SITEN_CD.Text.Trim)
            '口座種別
            Cmd.Parameters.Add("IN_FURI_KOZA_SYUBETU", CInt(cbo_FURI_KOZA_SYUBETU.Text.Trim))
            '口座番号
            Cmd.Parameters.Add("IN_FURI_KOZA_NO", txt_FURI_KOZA_NO.Text.Trim)
            '種別コード
            Cmd.Parameters.Add("IN_FURI_SYUBETU", CInt(txt_FURI_SYUBETU.Text.Trim))
            '口座名義人
            Cmd.Parameters.Add("IN_FURI_KOZA_MEIGI", txt_FURI_KOZA_MEIGI.Text.Trim)
            '口座名義人（カナ）
            Cmd.Parameters.Add("IN_FURI_KOZA_MEIGI_KANA", txt_FURI_KOZA_MEIGI_KANA.Text.Trim)

            '--------------------
            '支払口座情報
            '--------------------
            '交付金支払口座（金融機関） 交付金の支払い金融機関情報
            Cmd.Parameters.Add("IN_KOFU_BANK_CD", cbo_KOFU_BANK_CD.Text.Trim)
            '支払先支店コード
            Cmd.Parameters.Add("IN_KOFU_BANK_SITEN_CD", cbo_KOFU_BANK_SITEN_CD.Text.Trim)
            '口座種別
            'Cmd.Parameters.Add("IN_KOFU_KOZA_SYUBETU", CInt(cbo_KOFU_KOZA_SYUBETU.Text.Trim))
            Cmd.Parameters.Add("IN_KOFU_KOZA_SYUBETU", cbo_KOFU_KOZA_SYUBETU.Text.Trim)
            '口座番号
            Cmd.Parameters.Add("IN_KOFU_KOZA_NO", txt_KOFU_KOZA_NO.Text.Trim)
            '種別コード
            'Cmd.Parameters.Add("IN_KOFU_SYUBETU", CInt(txt_KOFU_SYUBETU.Text.Trim))
            Cmd.Parameters.Add("IN_KOFU_SYUBETU", txt_KOFU_SYUBETU.Text.Trim)
            'コード区分
            'Cmd.Parameters.Add("IN_KOFU_CD_KBN", CInt(txt_KOFU_CD_KBN.Text.Trim))
            Cmd.Parameters.Add("IN_KOFU_CD_KBN", txt_KOFU_CD_KBN.Text.Trim)

            '--------------------
            'その他
            '--------------------
            '依頼人コード
            'Cmd.Parameters.Add("IN_KOFU_KAISYA_CD", CLng(txt_KOFU_KAISYA_CD.Text))
            Cmd.Parameters.Add("IN_KOFU_KAISYA_CD", txt_KOFU_KAISYA_CD.Text)
            '振込依頼人名
            Cmd.Parameters.Add("IN_KOFU_KAISYA_NAME", txt_KOFU_KAISYA_NAME.Text)

            '--------------------
            '更新情報
            '--------------------
            'データ登録日
            Cmd.Parameters.Add("IN_REG_DATE", Now)
            'データ登録ＩＤ
            Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
            'データ更新日
            Cmd.Parameters.Add("IN_UP_DATE", Now)
            'データ更新ＩＤ
            Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            'コンピュータ名
            Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            '--------------------
            '保存
            '--------------------
            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Show_MessageBox("", Cmd.Parameters("OU_MSGNM").Value.ToString())
                Exit Try
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

#Region "f_ObjectClear 画面クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ObjectClear
    '説明            :画面クリア処理
    '引数            :rKbn(処理区分)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ObjectClear(ByVal wKbn As String) As Boolean

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '画面初期化
            pJump = True
            Call f_ClearFormALL(Me, wKbn)
            pJump = False

            'コンボセット
            If wKbn = "C" Then
                f_ComboBox_Set()
            End If

            '画面内容をセット
            If Not f_SetForm_Data(False) Then
                Exit Try
            End If

            '画面変更フラグ
            pblnTextChange = False

            '先頭入力へ
            txt_KYOKAI_NAME.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        End Try

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
        Dim sSql As String = String.Empty
        Dim ret As Boolean = False

        Try
            '--------------------
            '振込口座情報
            '--------------------
            '金融機関コードコンボセット
            If Not f_Bank_Data_Select(cbo_FURI_BANK_CD, cbo_FURI_BANK_NM, True) Then
                Exit Try
            End If

            '本支店コードコンボセット
            'If Not f_Bank_Data_Select(cbo_FURI_BANK_SITEN_CD, cbo_FURI_BANK_SITEN_NM, True) Then
            '    Exit Try
            'End If
            cbo_KOFU_BANK_SITEN_CD.Items.Clear()
            cbo_KOFU_BANK_SITEN_NM.Items.Clear()

            '口座区分コンボセット
            If Not f_CodeMaster_Data_Select(cbo_FURI_KOZA_SYUBETU, cbo_FURI_KOZA_SYUBETU_NM, 4, True) Then
                Exit Try
            End If

            '--------------------
            '支払口座情報
            '--------------------
            '金融機関コードコンボセット
            If Not f_Bank_Data_Select(cbo_KOFU_BANK_CD, cbo_KOFU_BANK_NM, True) Then
                Exit Try
            End If

            '本支店コードコンボセット
            'If Not f_Bank_Data_Select(cbo_KOFU_BANK_SITEN_CD, cbo_KOFU_BANK_SITEN_NM, True) Then
            '    Exit Try
            'End If
            cbo_KOFU_BANK_SITEN_CD.Items.Clear()
            cbo_KOFU_BANK_SITEN_NM.Items.Clear()

            '口座区分コンボセット
            If Not f_CodeMaster_Data_Select(cbo_KOFU_KOZA_SYUBETU, cbo_KOFU_KOZA_SYUBETU_NM, 4, True) Then
                Exit Try
            End If


            'コンボボックス初期化
            cbo_FURI_BANK_CD.Text = ""
            cbo_FURI_BANK_SITEN_CD.Text = ""
            cbo_FURI_KOZA_SYUBETU.Text = ""

            cbo_KOFU_BANK_CD.Text = ""
            cbo_KOFU_BANK_SITEN_CD.Text = ""
            cbo_KOFU_KOZA_SYUBETU.Text = ""

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_SetForm_Data 日本養鶏協会マスタデータ画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_Data
    '説明            :日本養鶏協会マスタデータ画面セット
    '引数            :エラー表示有無
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_Data(ByRef wErrDsp As Integer) As Boolean

        Dim sSql As String = String.Empty
        Dim ret As Boolean = False

        Try

            sSql = " SELECT " & vbCrLf
            sSql += "  * " & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_KYOKAI" & vbCrLf
            sSql += " WHERE" & vbCrLf
            sSql += "  KYOKAI_KBN = 1" & vbCrLf

            Call f_Select_ODP(pMST_DataSet, sSql)

            If pMST_DataSet.Tables(0).Rows.Count = 0 Then
                cmdCancel.Enabled = False   'キャンセル不可
                loMode = enuMode.Insert
            Else
                pblnErrDsp = False      'エラー　表示なし
                '画面にセット
                If Not f_DspForm_Data(pMST_DataSet, wErrDsp) Then
                    Exit Try
                End If
                cmdCancel.Enabled = True   'キャンセル可
                loMode = enuMode.Update
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            pblnErrDsp = True       'エラー　表示あり
            pblnTextChange = False

        End Try

        Return ret

    End Function
#End Region
#Region "f_DspForm_Data 日本養鶏協会マスタデータ画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_Data
    '説明            :日本養鶏協会マスタデータ画面セット
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_DspForm_Data(ByVal dstDataSet As DataSet, ByRef wErrDsp As Integer) As Boolean
        Dim ret As Boolean = False
        Dim ea As New System.ComponentModel.CancelEventArgs

        Try
            If dstDataSet.Tables(0).Rows.Count > 0 Then
                With dstDataSet.Tables(0)
                    '協会名称 ”社団法人　日本養鶏協会”
                    txt_KYOKAI_NAME.Text = WordHenkan("N", "S", .Rows(0)("KYOKAI_NAME"))
                    '役職名 ”会長”
                    txt_YAKUMEI.Text = WordHenkan("N", "S", .Rows(0)("YAKUMEI"))
                    '会長名 
                    txt_KAICHO_NAME.Text = WordHenkan("N", "S", .Rows(0)("KAICHO_NAME"))

                    '事業名
                    txt_JIGYO_NAME.Text = WordHenkan("N", "S", .Rows(0)("JIGYO_NAME"))
                    '予備１
                    txt_YOBI1.Text = WordHenkan("N", "S", .Rows(0)("YOBI1"))

                    '郵便番号
                    msk_POST.Value = WordHenkan("N", "S", .Rows(0)("POST"))
                    '住所１
                    txt_ADDR1.Text = WordHenkan("N", "S", .Rows(0)("ADDR1"))
                    '住所２
                    txt_ADDR2.Text = WordHenkan("N", "S", .Rows(0)("ADDR2"))

                    '電話番号１ 連絡先１
                    txt_TEL1.Text = WordHenkan("N", "S", .Rows(0)("TEL1"))
                    'ＦＡＸ１
                    txt_FAX1.Text = WordHenkan("N", "S", .Rows(0)("FAX1"))
                    'Ｅ－ｍａｉｌ１
                    txt_E_MAIL1.Text = WordHenkan("N", "S", .Rows(0)("E_MAIL1"))

                    '電話番号２ 連絡先２
                    txt_TEL2.Text = WordHenkan("N", "S", .Rows(0)("TEL2"))
                    'ＦＡＸ２
                    txt_FAX2.Text = WordHenkan("N", "S", .Rows(0)("FAX2"))
                    'Ｅ－ｍａｉｌ２
                    txt_E_MAIL2.Text = WordHenkan("N", "S", .Rows(0)("E_MAIL2"))
                    'ホームページURL
                    txt_HP_URL.Text = WordHenkan("N", "S", .Rows(0)("HP_URL"))

                    '登録番号  2023/08/04 JBD454 R5年度インボイス対応 ADD
                    txt_TOUROKU_NO.Text = WordHenkan("N", "S", .Rows(0)("TOUROKU_NO"))

                    '発行番号・漢字
                    txt_HAKKO_NO_KANJI.Text = WordHenkan("N", "S", .Rows(0)("HAKKO_NO_KANJI"))

                    '--------------------
                    '振込口座情報
                    '--------------------
                    '交付金支払口座（金融機関） 交付金の支払い金融機関情報
                    cbo_FURI_BANK_CD.SelectedValue = WordHenkan("N", "S", .Rows(0)("FURI_BANK_CD"))
                    cbo_FURI_BANK_CD_Validating(cbo_FURI_BANK_CD, ea)
                    '支払先支店コード
                    cbo_FURI_BANK_SITEN_CD.SelectedValue = WordHenkan("N", "S", .Rows(0)("FURI_BANK_SITEN_CD"))
                    cbo_FURI_BANK_SITEN_CD_Validating(cbo_FURI_BANK_SITEN_CD, ea)
                    '口座種別
                    cbo_FURI_KOZA_SYUBETU.SelectedValue = WordHenkan("N", "S", .Rows(0)("FURI_KOZA_SYUBETU"))
                    cbo_FURI_KOZA_SYUBETU_Validating(cbo_FURI_KOZA_SYUBETU, ea)
                    '口座番号
                    txt_FURI_KOZA_NO.Text = WordHenkan("N", "S", .Rows(0)("FURI_KOZA_NO"))
                    '種別コード
                    txt_FURI_SYUBETU.Text = WordHenkan("N", "S", .Rows(0)("FURI_SYUBETU"))
                    '口座名義人
                    txt_FURI_KOZA_MEIGI.Text = WordHenkan("N", "S", .Rows(0)("FURI_KOZA_MEIGI"))
                    '口座名義人（カナ）
                    txt_FURI_KOZA_MEIGI_KANA.Text = WordHenkan("N", "S", .Rows(0)("FURI_KOZA_MEIGI_KANA"))

                    '--------------------
                    '支払口座情報
                    '--------------------
                    '交付金支払口座（金融機関） 交付金の支払い金融機関情報
                    cbo_KOFU_BANK_CD.SelectedValue = WordHenkan("N", "S", .Rows(0)("KOFU_BANK_CD"))
                    Call cbo_KOFU_BANK_CD_Validating(cbo_KOFU_BANK_CD, ea)
                    '支払先支店コード
                    cbo_KOFU_BANK_SITEN_CD.SelectedValue = WordHenkan("N", "S", .Rows(0)("KOFU_BANK_SITEN_CD"))
                    Call cbo_KOFU_BANK_SITEN_CD_Validating(cbo_KOFU_BANK_SITEN_CD, ea)
                    '口座種別
                    cbo_KOFU_KOZA_SYUBETU.SelectedValue = WordHenkan("N", "S", .Rows(0)("KOFU_KOZA_SYUBETU"))
                    Call cbo_KOFU_KOZA_SYUBETU_Validating(cbo_KOFU_KOZA_SYUBETU, ea)
                    '口座番号
                    txt_KOFU_KOZA_NO.Text = WordHenkan("N", "S", .Rows(0)("KOFU_KOZA_NO"))
                    '種別コード
                    txt_KOFU_SYUBETU.Text = WordHenkan("N", "S", .Rows(0)("KOFU_SYUBETU"))
                    'コード区分
                    txt_KOFU_CD_KBN.Text = WordHenkan("N", "S", .Rows(0)("KOFU_CD_KBN"))
                    ''依頼人コード
                    txt_KOFU_KAISYA_CD.Text = WordHenkan("N", "S", .Rows(0)("KOFU_KAISYA_CD"))
                    '振込依頼人名
                    txt_KOFU_KAISYA_NAME.Text = WordHenkan("N", "S", .Rows(0)("KOFU_KAISYA_NAME"))

                End With
            Else

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

            '協会名称
            If txt_KYOKAI_NAME.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "協会名称")      '@0は必須入力項目です。
                txt_KYOKAI_NAME.Focus()
                Exit Try
            End If
            '役職名
            If txt_YAKUMEI.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "役職名")      '@0は必須入力項目です。
                txt_YAKUMEI.Focus()
                Exit Try
            End If
            '会長名
            If txt_KAICHO_NAME.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "会長名")      '@0は必須入力項目です。
                txt_KAICHO_NAME.Focus()
                Exit Try
            End If

            '事業名
            If txt_JIGYO_NAME.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "事業名")      '@0は必須入力項目です。
                txt_JIGYO_NAME.Focus()
                Exit Try
            End If

            '郵便番号
            If msk_POST.Value = "" Then
                Show_MessageBox_Add("W008", "郵便番号")      '@0は必須入力項目です。
                msk_POST.Focus()
                Exit Try
            End If
            '住所１
            If txt_ADDR1.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "住所１")      '@0は必須入力項目です。
                txt_ADDR1.Focus()
                Exit Try
            End If
            ''住所２
            'If txt_ADDR2.Text.TrimEnd = "" Then
            '    Show_MessageBox_Add("W008", "住所２")      '@0は必須入力項目です。
            '    txt_ADDR2.Focus()
            '    Exit Try
            'End If

            '電話番号１
            If txt_TEL1.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "電話番号１")      '@0は必須入力項目です。
                txt_TEL1.Focus()
                Exit Try
            End If
            'ＦＡＸ１
            If txt_FAX1.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "ＦＡＸ１")      '@0は必須入力項目です。
                txt_FAX1.Focus()
                Exit Try
            End If

            'ホームページURL
            If txt_HP_URL.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "ホームページURL")      '@0は必須入力項目です。
                txt_HP_URL.Focus()
                Exit Try
            End If

            '登録番号   2023/08/04 JBD454 R5年度インボイス対応 ADD
            If txt_TOUROKU_NO.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "登録番号")      '@0は必須入力項目です。
                txt_TOUROKU_NO.Focus()
                Exit Try
            End If

            '発行番号・漢字
            If txt_HAKKO_NO_KANJI.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "発行番号・漢字")      '@0は必須入力項目です。
                txt_HAKKO_NO_KANJI.Focus()
                Exit Try
            End If

            '--------------------
            '振込口座情報
            '--------------------
            '振込口座（金融機関）
            If cbo_FURI_BANK_CD.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "振込口座（金融機関）")      '@0は必須入力項目です。
                cbo_FURI_BANK_CD.Focus()
                Exit Try
            End If
            '振込支店コード
            If cbo_FURI_BANK_SITEN_CD.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "振込口座（本支店）")      '@0は必須入力項目です。
                cbo_FURI_BANK_SITEN_CD.Focus()
                Exit Try
            End If
            '口座種別
            If cbo_FURI_KOZA_SYUBETU.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "振込口座（口座種別）")      '@0は必須入力項目です。
                cbo_FURI_KOZA_SYUBETU.Focus()
                Exit Try
            End If
            '口座番号
            If txt_FURI_KOZA_NO.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "口座番号")      '@0は必須入力項目です。
                txt_FURI_KOZA_NO.Focus()
                Exit Try
            End If
            '種別コード
            If txt_FURI_SYUBETU.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "振込口座（種別コード）")      '@0は必須入力項目です。
                txt_FURI_SYUBETU.Focus()
                Exit Try
            End If
            '口座名義人（カナ）
            If txt_FURI_KOZA_MEIGI_KANA.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "振込口座（口座名義人（カナ））")      '@0は必須入力項目です。
                txt_FURI_KOZA_MEIGI_KANA.Focus()
                Exit Try
            End If
            '口座名義人
            If txt_FURI_KOZA_MEIGI.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "振込口座（口座名義人（漢字））")      '@0は必須入力項目です。
                txt_FURI_KOZA_MEIGI.Focus()
                Exit Try
            End If

            '--------------------
            '支払口座情報
            '--------------------
            '2015/03/31　修正開始
            ''支払口座（金融機関）
            'If cbo_KOFU_BANK_CD.Text.TrimEnd = "" Then
            '    Show_MessageBox_Add("W008", "支払口座（金融機関）")      '@0は必須入力項目です。
            '    cbo_KOFU_BANK_CD.Focus()
            '    Exit Try
            'End If
            ''支払先支店コード
            'If cbo_KOFU_BANK_SITEN_CD.Text.TrimEnd = "" Then
            '    Show_MessageBox_Add("W008", "支払口座（本支店）")      '@0は必須入力項目です。
            '    cbo_KOFU_BANK_SITEN_CD.Focus()
            '    Exit Try
            'End If
            ''口座種別
            'If cbo_KOFU_KOZA_SYUBETU.Text.TrimEnd = "" Then
            '    Show_MessageBox_Add("W008", "支払口座（口座種別）")      '@0は必須入力項目です。
            '    cbo_KOFU_KOZA_SYUBETU.Focus()
            '    Exit Try
            'End If
            ''口座番号
            'If txt_KOFU_KOZA_NO.Text.TrimEnd = "" Then
            '    Show_MessageBox_Add("W008", "支払口座（口座番号）")      '@0は必須入力項目です。
            '    txt_KOFU_KOZA_NO.Focus()
            '    Exit Try
            'End If
            ''種別コード
            'If txt_KOFU_SYUBETU.Text.TrimEnd = "" Then
            '    Show_MessageBox_Add("W008", "支払口座（種別コード）")      '@0は必須入力項目です。
            '    txt_KOFU_SYUBETU.Focus()
            '    Exit Try
            'End If
            ''コード区分
            'If txt_KOFU_CD_KBN.Text.TrimEnd = "" Then
            '    Show_MessageBox_Add("W008", "支払口座（コード区分）")      '@0は必須入力項目です。
            '    txt_KOFU_CD_KBN.Focus()
            '    Exit Try
            'End If
            ''依頼人コード
            'If txt_KOFU_KAISYA_CD.Text.TrimEnd = "" Then
            '    Show_MessageBox_Add("W008", "支払口座（依頼人コード）")      '@0は必須入力項目です。
            '    txt_KOFU_KAISYA_CD.Focus()
            '    Exit Try
            'End If
            ''振込依頼人名
            'If txt_KOFU_KAISYA_NAME.Text.TrimEnd = "" Then
            '    Show_MessageBox_Add("W008", "支払口座（振込依頼人名）")      '@0は必須入力項目です。
            '    txt_KOFU_KAISYA_NAME.Focus()
            '    Exit Try
            'End If
            '2015/03/31　修正終了

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
