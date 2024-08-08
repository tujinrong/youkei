'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ1070.vb
'*
'*　　②　機能概要　　　　　事業加入状況表作成処理(農場別リスト)
'*
'*　　③　作成日　　　　　　2014/01/15 JBD999
'*
'*　　④　更新日            
'*
'*******************************************************************************
Option Strict Off
Option Explicit On
'------------------------------------------------------------------
'------------------------------------------------------------------

Imports System.Text
Imports JbdGjsCommon
Imports JbdGjsControl


Public Class frmGJ1070

#Region "***変数定義***"

    'Private pblnTextChange As Boolean                   '画面入力内容変更フラグ 'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL

    ''' <summary>
    ''' プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True                     '処理ジャンプ

    ''' <summary>
    ''' EXCEL
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "事業加入状況表(農場別リスト)"

#End Region

#Region "***画面制御関連***"

#Region "Form_Loadイベント"
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

            'チェンジイベント
            'f_setControlChangeEvents() 'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

    End Sub
#End Region
    'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL START
    '#Region "f_setControlChangeEvents 変更判定イベント登録"
    '    ''' <summary>
    '    ''' 変更判定イベント登録
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Private Sub f_setControlChangeEvents()
    '        For Each wkCtrl In Me.Controls
    '            Select Case True
    '                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcComboBox
    '                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcComboBox).TextChanged, AddressOf f_setChanged
    '                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcDate
    '                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcDate).TextChanged, AddressOf f_setChanged
    '                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcMask
    '                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcMask).TextChanged, AddressOf f_setChanged
    '                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcNumber
    '                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcNumber).TextChanged, AddressOf f_setChanged
    '                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcTextBox
    '                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcTextBox).TextChanged, AddressOf f_setChanged
    '                Case TypeOf wkCtrl Is JBD.Gjs.Win.RadioButton
    '                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.RadioButton).CheckedChanged, AddressOf f_setChanged
    '                Case TypeOf wkCtrl Is JBD.Gjs.Win.CheckBox
    '                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.CheckBox).CheckedChanged, AddressOf f_setChanged


    '            End Select
    '        Next
    '    End Sub

    '#End Region

    '#Region "f_setChanged コントロール変更時処理"

    '    ''' <summary>
    '    ''' コントロール変更時処理
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Private Sub f_setChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        pblnTextChange = True
    '    End Sub
    '#End Region
    'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL END
#Region "期"
    '------------------------------------------------------------------
    'プロシージャ名  :numKI_TextChanged
    '説明            :期Chanegeイベント
    '------------------------------------------------------------------
    Private Sub numKI_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles numKI.TextChanged
        ''画面クリアの時、処理しない
        'If pJump Then
        '    Exit Sub
        'End If

        'If numKI.Value Is Nothing Then
        '    cboKEIYAKUSYA_Cd_Fm.Items.Clear()
        '    cboKEIYAKUSYA_Nm_Fm.Items.Clear()
        '    cboKEIYAKUSYA_Cd_To.Items.Clear()
        '    cboKEIYAKUSYA_Nm_To.Items.Clear()
        '    Exit Sub
        'End If

        ''---------------------------------------------------
        ''初期表示
        ''---------------------------------------------------
        ''コンボの初期化
        'f_ComboBox_Set("K")

        ''期にフォーカスセット
        'numKI.Focus()
        'pblnTextChange = False             '画面入力内容変更フラグ初期化 'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :numKI_Validating
    '説明            :期Validatingイベント
    '------------------------------------------------------------------
    Private Sub numKI_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numKI.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        If numKI.Value Is Nothing Then
            cboKEIYAKUSYA_Cd_Fm.DataSource = Nothing
            cboKEIYAKUSYA_Cd_Fm.Clear()
            cboKEIYAKUSYA_Nm_Fm.DataSource = Nothing
            cboKEIYAKUSYA_Nm_Fm.Clear()
            cboKEIYAKUSYA_Cd_To.DataSource = Nothing
            cboKEIYAKUSYA_Cd_To.Clear()
            cboKEIYAKUSYA_Nm_To.DataSource = Nothing
            cboKEIYAKUSYA_Nm_To.Clear()
            Exit Sub
        End If

        '---------------------------------------------------
        '初期表示
        '---------------------------------------------------
        'コンボの初期化
        f_ComboBox_Set("K")
    End Sub
#End Region

#Region "契約区分FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_KBN_Cd_Fm_SelectedIndexChanged
    '説明            :契約区分コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_KBN_Cd_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKU_KBN_Cd_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboKEIYAKU_KBN_Nm_Fm.SelectedIndex = cboKEIYAKU_KBN_Cd_Fm.SelectedIndex
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_KBN_Nm_Fm_SelectedIndexChanged
    '説明            :契約区分名FromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_KBN_Nm_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKU_KBN_Nm_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiFrom_SelectedIndexChanged(cboKEIYAKU_KBN_Nm_Fm, cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_To, cboKEIYAKU_KBN_Cd_To)
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_KBN_Cd_Fm_Validating
    '説明            :契約区分コードFromValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_KBN_Cd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboKEIYAKU_KBN_Cd_Fm.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboFrom_Validating(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_Fm, cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To)
    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_KBN_Cd_To_SelectedIndexChanged
    '説明            :契約区分コードToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_KBN_Cd_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKU_KBN_Cd_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboKEIYAKU_KBN_Nm_To.SelectedIndex = cboKEIYAKU_KBN_Cd_To.SelectedIndex
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_KBN_Nm_To_SelectedIndexChanged
    '説明            :契約区分名ToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_KBN_Nm_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKU_KBN_Nm_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiTo_Validating(cboKEIYAKU_KBN_Nm_To, cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_Fm, cboKEIYAKU_KBN_Cd_Fm)
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_KBN_Cd_To_Validating
    '説明            :契約区分コードToValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_KBN_Cd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboKEIYAKU_KBN_Cd_To.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboTo_Validating(cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To, cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_Fm)
    End Sub


#End Region

#Region "鶏の種類区分FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboTORI_KBN_Cd_Fm_SelectedIndexChanged
    '説明            :鶏の種類区分コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboTORI_KBN_Cd_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboTORI_KBN_Cd_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboTORI_KBN_Nm_Fm.SelectedIndex = cboTORI_KBN_Cd_Fm.SelectedIndex
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboTORI_KBN_Nm_Fm_SelectedIndexChanged
    '説明            :鶏の種類区分名FromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboTORI_KBN_Nm_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboTORI_KBN_Nm_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiFrom_SelectedIndexChanged(cboTORI_KBN_Nm_Fm, cboTORI_KBN_Cd_Fm, cboTORI_KBN_Nm_To, cboTORI_KBN_Cd_To)
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboTORI_KBN_Cd_Fm_Validating
    '説明            :鶏の種類区分コードFromValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboTORI_KBN_Cd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboTORI_KBN_Cd_Fm.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboFrom_Validating(cboTORI_KBN_Cd_Fm, cboTORI_KBN_Nm_Fm, cboTORI_KBN_Cd_To, cboTORI_KBN_Nm_To)
    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cboTORI_KBN_Cd_To_SelectedIndexChanged
    '説明            :鶏の種類区分コードToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboTORI_KBN_Cd_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboTORI_KBN_Cd_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboTORI_KBN_Nm_To.SelectedIndex = cboTORI_KBN_Cd_To.SelectedIndex
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboTORI_KBN_Nm_To_SelectedIndexChanged
    '説明            :鶏の種類区分名ToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboTORI_KBN_Nm_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboTORI_KBN_Nm_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiTo_Validating(cboTORI_KBN_Nm_To, cboTORI_KBN_Cd_To, cboTORI_KBN_Nm_Fm, cboTORI_KBN_Cd_Fm)
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboTORI_KBN_Cd_To_Validating
    '説明            :鶏の種類区分コードToValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboTORI_KBN_Cd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboTORI_KBN_Cd_To.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboTo_Validating(cboTORI_KBN_Cd_To, cboTORI_KBN_Nm_To, cboTORI_KBN_Cd_Fm, cboTORI_KBN_Nm_Fm)
    End Sub
#End Region

#Region "都道府県FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEN_Cd_Fm_SelectedIndexChanged
    '説明            :都道府県コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEN_Cd_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEN_Cd_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboKEN_Nm_Fm.SelectedIndex = cboKEN_Cd_Fm.SelectedIndex
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboKEN_Nm_Fm_SelectedIndexChanged
    '説明            :都道府県FromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEN_Nm_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEN_Nm_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiFrom_SelectedIndexChanged(cboKEN_Nm_Fm, cboKEN_Cd_Fm, cboKEN_Nm_To, cboKEN_Cd_To)
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboKEN_Cd_Fm_Validating
    '説明            :都道府県コードFromValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboKEN_Cd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboKEN_Cd_Fm.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboFrom_Validating(cboKEN_Cd_Fm, cboKEN_Nm_Fm, cboKEN_Cd_To, cboKEN_Nm_To)
    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cboKEN_Cd_To_SelectedIndexChanged
    '説明            :都道府県コードToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEN_Cd_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEN_Cd_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboKEN_Nm_To.SelectedIndex = cboKEN_Cd_To.SelectedIndex
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEN_Nm_To_SelectedIndexChanged
    '説明            :都道府県ToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEN_Nm_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEN_Nm_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiTo_Validating(cboKEN_Nm_To, cboKEN_Cd_To, cboKEN_Nm_Fm, cboKEN_Cd_Fm)
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEN_Cd_To_Validating
    '説明            :都道府県コードToValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboKEN_Cd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboKEN_Cd_To.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboTo_Validating(cboKEN_Cd_To, cboKEN_Nm_To, cboKEN_Cd_Fm, cboKEN_Nm_Fm)
    End Sub
#End Region

#Region "契約者FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKUSYA_Cd_Fm_SelectedIndexChanged
    '説明            :契約者コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKUSYA_Cd_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKUSYA_Cd_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboKEIYAKUSYA_Nm_Fm.SelectedIndex = cboKEIYAKUSYA_Cd_Fm.SelectedIndex
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKUSYA_Nm_Fm_SelectedIndexChanged
    '説明            :契約者名FromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKUSYA_Nm_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKUSYA_Nm_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiFrom_SelectedIndexChanged(cboKEIYAKUSYA_Nm_Fm, cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_To, cboKEIYAKUSYA_Cd_To)
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKUSYA_Cd_Fm_Validating
    '説明            :契約者コードFromValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKUSYA_Cd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboKEIYAKUSYA_Cd_Fm.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboFrom_Validating(cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm, cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To, "2")
    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKUSYA_Cd_To_SelectedIndexChanged
    '説明            :契約者コードToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKUSYA_Cd_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKUSYA_Cd_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboKEIYAKUSYA_Nm_To.SelectedIndex = cboKEIYAKUSYA_Cd_To.SelectedIndex
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKUSYA_Nm_To_SelectedIndexChanged
    '説明            :契約者名ToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKUSYA_Nm_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKUSYA_Nm_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiTo_Validating(cboKEIYAKUSYA_Nm_To, cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_Fm, cboKEIYAKUSYA_Cd_Fm)
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKUSYA_Cd_To_Validating
    '説明            :契約者コードToValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKUSYA_Cd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboKEIYAKUSYA_Cd_To.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboTo_Validating(cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To, cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm, "2")
    End Sub
#End Region



#End Region


#Region "***画面ボタンクリック関連***"

#Region "cmdExcel_Click EXCELボタンクリック処理"
    ''' <summary>
    ''' EXCELボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Dim ea As New System.ComponentModel.CancelEventArgs

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '事前チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            'EXCEL出力処理
            If Not f_Excel_Output() Then
                Exit Try
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
            'R05年度改修 OSバージョンアップ　既存バグ修正のため削除　2024/03/12 JBD453 DEL START
            'If pblnTextChange Then
            '    '画面に変更があり保存していない場合は、メッセージ表示
            '    If Show_MessageBox("Q007", "") = DialogResult.No Then
            '        '「いいえ」を選択
            '        Exit Sub
            '    End If
            'End If
            'R05年度改修 OSバージョンアップ　既存バグ修正のため削除 JBD453 DEL END
            ret = f_ObjectClear("")
            '期にフォーカスセット
            numKI.Focus()
            'pblnTextChange = False             '画面入力内容変更フラグ初期化 'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL

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
            'If pblnTextChange Then
            '    '画面に変更があり保存していない場合は、メッセージ表示
            '    If Show_MessageBox("Q007", "") = DialogResult.No Then
            '        Exit Try
            '    End If
            'Else
            If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                '処理を終了しますか？
                Exit Try
            End If
            'End If

            'pblnTextChange = False      '画面入力内容変更フラグ初期化 'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL
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
#End Region

#Region "EXCEL出力関連"
#Region "f_Excel_Output EXCEL出力処理"
    ''' <summary>
    '''  EXCEL出力処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Excel_Output() As Boolean
        Dim wkSql As String = String.Empty
        Dim wkDS As New DataSet

        Try
            'SQL
            If Not f_make_SQL(0, wkSql) Then
                Exit Try
            End If
            If Not f_Select_ODP(wkDS, wkSql) Then
                Show_MessageBox("I002", "") '該当データが存在しません。
                Exit Try
            End If
            'Excelデータ作成
            If Not f_makeExcel(wkDS.Tables(0)) Then
                Exit Try
            End If
            Show_MessageBox("I005", "")     'EXCEL出力が終了しました。

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'メモリを解放します
            Call s_GC_Dispose()
        End Try

        Return True
    End Function
#End Region
#Region "f_make_SQL 帳票データ出力用ＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :帳票データ出力用ＳＱＬ作成
    '引数            :区分
    '引数            :SQLを返す
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    ''' <summary>
    ''' ＳＱＬ文作成
    ''' </summary>
    ''' <param name="iKbn">
    ''' 
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_make_SQL(ByVal iKbn As Integer, ByRef wSQL As String) As Boolean
        Dim ret As Boolean = False
        Dim sSQL As String = vbNullString
        Dim sSQL2 As String = vbNullString
        Dim sSQL3 As String = vbNullString

        Try
            '対象期・年度の取得
            Dim SyoriKI = New Obj_TM_SYORI_NENDO_KI()

            sSQL = " SELECT " & vbCrLf
            sSQL += "   TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI " & vbCrLf
            '-- 対象期間
            If SyoriKI.pKI = numKI.Value Then
                sSQL += " ,'対象期：第" & numKI.Value & "期（' || TO_CHAR(TO_DATE('" & SyoriKI.pTAISYO_NENDO_byDate & "'), '""""EEYY""年度～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & SyoriKI.pJIGYO_SYURYO_NENDO_byDate & "'), '""""EEYY""年度）""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS TAISYO_KI " & vbCrLf
            Else
                sSQL += " ,'対象期：第" & numKI.Value & "期' AS TAISYO_KI " & vbCrLf
            End If
            '-- ヘッダ
            '↓2017/07/14 修正 追加納付を追加
            'sSQL += " ,'＜＜　事業加入状況表（農場別リスト）（第" & numKI.Value & "期）＞＞' AS NAME_HED " & vbCrLf
            If pKikin2 Then
                sSQL += " ,'＜＜　事業加入状況表（農場別リスト）(追加納付)（第" & numKI.Value & "期）＞＞' AS NAME_HED " & vbCrLf
            Else
                sSQL += " ,'＜＜　事業加入状況表（農場別リスト）（第" & numKI.Value & "期）＞＞' AS NAME_HED " & vbCrLf
            End If
            '↑2017/07/14 修正 追加納付を追加

            '-- 期
            sSQL += " ,GRP.KI AS KI " & vbCrLf
            sSQL += " ,GRP.GRPID AS GRPID " & vbCrLf
            '-- 事務委託先
            sSQL += " ,GRP.JIMUITAKU_CD AS JIMUITAKU_CD " & vbCrLf
            'sSQL += " ,JIM.ITAKU_NAME AS ITAKU_NM " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 4 THEN NULL" & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 7 THEN NULL" & vbCrLf
            sSQL += "    ELSE JIM.ITAKU_NAME " & vbCrLf
            sSQL += "  END ITAKU_NM " & vbCrLf

            '-- 契約者
            sSQL += " ,GRP.KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf

            'sSQL += " ,KEI.KEIYAKUSYA_NAME AS KEIYAKUSYA_NAME " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 4 THEN '契約者計'" & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 7 THEN '総合計'" & vbCrLf
            sSQL += "    ELSE KEI.KEIYAKUSYA_NAME " & vbCrLf
            sSQL += "  END KEIYAKUSYA_NAME " & vbCrLf
            'sSQL += " ,KEI.DAIHYO_NAME AS DAIHYO_NAME " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 4 THEN NULL" & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 7 THEN NULL" & vbCrLf
            sSQL += "    ELSE KEI.DAIHYO_NAME " & vbCrLf
            sSQL += "  END DAIHYO_NAME " & vbCrLf

            '-- 農場
            'sSQL += " ,GRP.NOJO_CD AS NOJO_CD " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 4 THEN NULL" & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 7 THEN NULL" & vbCrLf
            sSQL += "    ELSE GRP.NOJO_CD " & vbCrLf
            sSQL += "  END NOJO_CD " & vbCrLf
            'sSQL += " ,NOJO.NOJO_NAME AS NOJO_NAME " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 4 THEN NULL" & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 7 THEN NULL" & vbCrLf
            sSQL += "    ELSE NOJO.NOJO_NAME " & vbCrLf
            sSQL += "  END NOJO_NAME " & vbCrLf


            '-- 鶏区分
            sSQL += " ,GRP.TORI_KBN AS TORI_KBN " & vbCrLf
            'sSQL += " ,CD07.MEISYO AS TORI_KBN_NM " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 4 THEN NULL" & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 7 THEN NULL" & vbCrLf
            sSQL += "    ELSE CD07.MEISYO " & vbCrLf
            sSQL += "  END TORI_KBN_NM " & vbCrLf

            '-- 都道府県(農場)
            sSQL += " ,GRP.KEN_CD AS KEN_CD " & vbCrLf
            sSQL += " ,NOJO.KEN_CD AS NOJO_KEN_CD " & vbCrLf

            '-- 農場県名
            sSQL += " ,CASE " & vbCrLf
            '↓2021/02/22 JBD368 DEL 都道府県が同じでも農場県名を出力する
            'sSQL += "    WHEN GRP.KEN_CD = NOJO.KEN_CD THEN NULL " & vbCrLf
            '↑2021/02/22 JBD368 DEL 
            sSQL += "    WHEN GRP.GRPID = 4 THEN NULL" & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 7 THEN NULL" & vbCrLf
            sSQL += "    ELSE CD05N.MEISYO " & vbCrLf
            sSQL += "  END NOJO_KEN_NM " & vbCrLf
            '-- 農場所在地
            'sSQL += " ,(NOJO.ADDR_1 || NOJO.ADDR_2 || NOJO.ADDR_3 || NOJO.ADDR_4) AS NOJO_ADDR " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            '↓2021/02/22 JBD368 DEL 都道府県が同じでも農場県名を出力する
            'sSQL += "    WHEN GRP.KEN_CD = NOJO.KEN_CD THEN NULL " & vbCrLf
            '↑2021/02/22 JBD368 DEL 
            sSQL += "    WHEN GRP.GRPID = 4 THEN NULL" & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 7 THEN NULL" & vbCrLf
            sSQL += "    ELSE (NOJO.ADDR_1 || NOJO.ADDR_2 || NOJO.ADDR_3 || NOJO.ADDR_4) " & vbCrLf
            sSQL += "  END NOJO_ADDR " & vbCrLf
            '-- 採卵鶏 成鶏 羽数
            sSQL += " ,GRP.HASU1 AS HASU1 " & vbCrLf
            '-- 採卵鶏 育成 羽数
            sSQL += " ,GRP.HASU2 AS HASU2 " & vbCrLf
            '-- 肉用種 羽数
            sSQL += " ,GRP.HASU3 AS HASU3 " & vbCrLf
            '-- 種鶏 成鶏 羽数
            sSQL += " ,GRP.HASU4 AS HASU4 " & vbCrLf
            '-- 種鶏 育成 羽数
            sSQL += " ,GRP.HASU5 AS HASU5 " & vbCrLf
            '-- うずら 羽数
            sSQL += " ,GRP.HASU6 AS HASU6 " & vbCrLf
            '↓2017/07/12 追加 鳥区分追加
            '-- あひる 羽数
            sSQL += " ,GRP.HASU7 AS HASU7 " & vbCrLf
            '-- きじ 羽数
            sSQL += " ,GRP.HASU8 AS HASU8 " & vbCrLf
            '-- ほろほろ鳥 羽数
            sSQL += " ,GRP.HASU9 AS HASU9 " & vbCrLf
            '-- 七面鳥 羽数
            sSQL += " ,GRP.HASU10 AS HASU10 " & vbCrLf
            '-- だちょう 羽数
            sSQL += " ,GRP.HASU11 AS HASU11 " & vbCrLf
            '↑2017/07/12 追加 鳥区分追加
            '-- 横計 羽数
            sSQL += " ,GRP.HASU_SUM AS HASU_SUM " & vbCrLf
            '-- 契約区分
            sSQL += " ,GRP.KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 4 THEN NULL" & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 7 THEN NULL" & vbCrLf
            '↓2017/07/12 修正 契約区分変更
            'sSQL += "    ELSE CD01.RYAKUSYO " & vbCrLf
            sSQL += "    ELSE CD01.MEISYO " & vbCrLf
            '↑2017/07/12 修正 契約区分変更
            sSQL += "  END KEIYAKU_KBN_NM " & vbCrLf


            '-- グループID
            'sSQL += " ,GRP.GRPID AS GRPID " & vbCrLf

            '-- FROM
            sSQL += " FROM " & vbCrLf
            '--          県別、契約者別、総合計の集計 
            sSQL += "    ( " & vbCrLf
            sSQL += "    SELECT " & vbCrLf
            '                 -- 期
            sSQL += "         MAX(DTL.KI) AS KI " & vbCrLf
            sSQL += "        ,MAX(DTL.SEQ_NO) AS SEQ_NO " & vbCrLf
            '                 -- 事務委託先
            sSQL += "        ,MAX(DTL.JIMUITAKU_CD) AS JIMUITAKU_CD " & vbCrLf
            '                 -- 都道府県
            sSQL += "        ,MAX(DTL.KEN_CD) AS KEN_CD " & vbCrLf
            '                 -- 契約者
            sSQL += "        ,MAX(DTL.KEIYAKUSYA_CD) AS KEIYAKUSYA_CD " & vbCrLf
            '                 -- 契約区分
            sSQL += "        ,MAX(DTL.KEIYAKU_KBN) AS KEIYAKU_KBN " & vbCrLf
            '                 -- 鶏区分
            sSQL += "        ,MAX(DTL.TORI_KBN) AS TORI_KBN " & vbCrLf
            '                 -- 農場CD
            sSQL += "        ,MAX(DTL.NOJO_CD) AS NOJO_CD " & vbCrLf
            '                 -- グループID
            sSQL += "        ,GROUPING_ID(DTL.SEQ_NO,KEN_CD,DTL.KEIYAKUSYA_CD) AS GRPID " & vbCrLf
            '                 -- 採卵鶏 成鶏 羽数
            sSQL += "        ,SUM(DTL.HASU1) AS HASU1 " & vbCrLf
            '                 -- 採卵鶏 育成 羽数
            sSQL += "        ,SUM(DTL.HASU2) AS HASU2 " & vbCrLf
            '                 -- 肉用種 羽数
            sSQL += "        ,SUM(DTL.HASU3) AS HASU3 " & vbCrLf
            '                 -- 種鶏 成鶏 羽数
            sSQL += "        ,SUM(DTL.HASU4) AS HASU4 " & vbCrLf
            '                 -- 種鶏 育成 羽数
            sSQL += "        ,SUM(DTL.HASU5) AS HASU5 " & vbCrLf
            '                 -- うずら 羽数
            sSQL += "        ,SUM(DTL.HASU6) AS HASU6 " & vbCrLf
            '↓2017/07/12 追加 鳥区分追加
            '                 -- あひる 羽数
            sSQL += "        ,SUM(DTL.HASU7) AS HASU7 " & vbCrLf
            '                 -- きじ 羽数
            sSQL += "        ,SUM(DTL.HASU8) AS HASU8 " & vbCrLf
            '                 -- ほろほろ鳥 羽数
            sSQL += "        ,SUM(DTL.HASU9) AS HASU9 " & vbCrLf
            '                 -- 七面鳥 羽数
            sSQL += "        ,SUM(DTL.HASU10) AS HASU10 " & vbCrLf
            '                 -- だちょう 羽数
            sSQL += "        ,SUM(DTL.HASU11) AS HASU11 " & vbCrLf
            '↑2017/07/12 追加 鳥区分追加
            '                 -- 横計 羽数
            sSQL += "        ,SUM(DTL.HASU_SUM) AS HASU_SUM " & vbCrLf
            sSQL += "    FROM " & vbCrLf
            sSQL += "       ( " & vbCrLf
            sSQL += "       SELECT " & vbCrLf
            '                    -- 期
            sSQL += "            KEIJOHO.KI AS KI " & vbCrLf
            '                    -- SEQNO
            sSQL += "           ,MAX(KEIJOHO.SEQNO) AS SEQ_NO " & vbCrLf
            '                    -- 事務委託先
            sSQL += "           ,KEI.JIMUITAKU_CD AS JIMUITAKU_CD " & vbCrLf
            '                    -- 都道府県
            sSQL += "           ,KEI.KEN_CD AS KEN_CD " & vbCrLf
            '                    -- 契約者
            sSQL += "           ,KEIJOHO.KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
            '                    -- 契約区分
            sSQL += "           ,KEIJOHO.KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
            '                    -- 鶏区分
            sSQL += "           ,KEIJOHO.TORI_KBN AS TORI_KBN " & vbCrLf
            '                    -- 農場CD
            sSQL += "           ,KEIJOHO.NOJO_CD AS NOJO_CD " & vbCrLf
            '                    -- 採卵鶏 成鶏 羽数
            sSQL += "           ,SUM(CASE WHEN KEIJOHO.TORI_KBN =1 THEN NVL(KEIJOHO.KEIYAKU_HASU,0) END) AS HASU1 " & vbCrLf
            '                    -- 採卵鶏 育成 羽数
            sSQL += "           ,SUM(CASE WHEN KEIJOHO.TORI_KBN =2 THEN NVL(KEIJOHO.KEIYAKU_HASU,0) END) AS HASU2 " & vbCrLf
            '                    -- 肉用種 羽数
            sSQL += "           ,SUM(CASE WHEN KEIJOHO.TORI_KBN =3 THEN NVL(KEIJOHO.KEIYAKU_HASU,0) END) AS HASU3 " & vbCrLf
            '                    -- 種鶏 成鶏 羽数
            sSQL += "           ,SUM(CASE WHEN KEIJOHO.TORI_KBN =4 THEN NVL(KEIJOHO.KEIYAKU_HASU,0) END) AS HASU4 " & vbCrLf
            '                    -- 種鶏 育成 羽数
            sSQL += "           ,SUM(CASE WHEN KEIJOHO.TORI_KBN =5 THEN NVL(KEIJOHO.KEIYAKU_HASU,0) END) AS HASU5 " & vbCrLf
            '                    -- うずら 羽数
            sSQL += "           ,SUM(CASE WHEN KEIJOHO.TORI_KBN =6 THEN NVL(KEIJOHO.KEIYAKU_HASU,0) END) AS HASU6 " & vbCrLf
            '↓2017/07/12 追加 鳥区分追加
            '                    -- あひる 羽数
            sSQL += "           ,SUM(CASE WHEN KEIJOHO.TORI_KBN =7 THEN NVL(KEIJOHO.KEIYAKU_HASU,0) END) AS HASU7 " & vbCrLf
            '                    -- きじ 羽数
            sSQL += "           ,SUM(CASE WHEN KEIJOHO.TORI_KBN =8 THEN NVL(KEIJOHO.KEIYAKU_HASU,0) END) AS HASU8 " & vbCrLf
            '                    -- ほろほろ鳥 羽数
            sSQL += "           ,SUM(CASE WHEN KEIJOHO.TORI_KBN =9 THEN NVL(KEIJOHO.KEIYAKU_HASU,0) END) AS HASU9 " & vbCrLf
            '                    -- 七面鳥 羽数
            sSQL += "           ,SUM(CASE WHEN KEIJOHO.TORI_KBN =10 THEN NVL(KEIJOHO.KEIYAKU_HASU,0) END) AS HASU10 " & vbCrLf
            '                    -- だちょう 羽数
            sSQL += "           ,SUM(CASE WHEN KEIJOHO.TORI_KBN =11 THEN NVL(KEIJOHO.KEIYAKU_HASU,0) END) AS HASU11 " & vbCrLf
            '↑2017/07/12 追加 鳥区分追加
            '                    -- 横計 羽数
            sSQL += "           ,SUM(NVL(KEIJOHO.KEIYAKU_HASU,0)) AS HASU_SUM " & vbCrLf
            sSQL += "       FROM TT_KEIYAKU_JOHO KEIJOHO " & vbCrLf
            sSQL += "           ,TM_KEIYAKU KEI " & vbCrLf
            sSQL += "       WHERE " & vbCrLf
            '                     -- 契約者マスタ
            sSQL += "             KEIJOHO.KI = KEI.KI(+) " & vbCrLf
            sSQL += "         AND KEIJOHO.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+) " & vbCrLf
            '                     -- 条件
            sSQL += "         AND KEIJOHO.DATA_FLG = 1 " & vbCrLf
            '                     -- 期条件
            sSQL += "         AND KEIJOHO.KI = " & numKI.Value & vbCrLf

            '==必須条件=======================

            '==任意条件=======================
            '契約区分FROMTO
            If cboKEIYAKU_KBN_Cd_Fm.Text <> "" Then
                sSQL += "         AND KEI.KEIYAKU_KBN BETWEEN " & cboKEIYAKU_KBN_Cd_Fm.Text & " AND " & cboKEIYAKU_KBN_Cd_To.Text & vbCrLf
            End If

            '鶏の種類FROMTO
            If cboTORI_KBN_Cd_Fm.Text <> "" Then
                sSQL += "         AND KEIJOHO.TORI_KBN BETWEEN " & cboTORI_KBN_Cd_Fm.Text & " AND " & cboTORI_KBN_Cd_To.Text & vbCrLf
            End If

            '都道府県FROMTO
            If cboKEN_Cd_Fm.Text <> "" Then
                '↓2015/06/02 JBD368 UPD
                'sSQL += "         AND KEI.KEN_CD BETWEEN " & cboKEN_Cd_Fm.Text & " AND " & cboKEN_Cd_Fm.Text & vbCrLf
                sSQL += "         AND KEI.KEN_CD BETWEEN " & cboKEN_Cd_Fm.Text & " AND " & cboKEN_Cd_To.Text & vbCrLf
                '↑2015/06/02 JBD368 UPD
            End If

            '契約者FROMTO
            If cboKEIYAKUSYA_Cd_Fm.Text <> "" Then
                sSQL += "         AND KEI.KEIYAKUSYA_CD BETWEEN " & cboKEIYAKUSYA_Cd_Fm.Text & " AND " & cboKEIYAKUSYA_Cd_To.Text & vbCrLf
            End If

            sSQL += "       GROUP BY " & vbCrLf
            sSQL += "           KEIJOHO.KI " & vbCrLf
            sSQL += "          ,KEI.JIMUITAKU_CD " & vbCrLf
            sSQL += "          ,KEI.KEN_CD " & vbCrLf
            sSQL += "          ,KEIJOHO.KEIYAKUSYA_CD " & vbCrLf
            sSQL += "          ,KEIJOHO.KEIYAKU_KBN " & vbCrLf
            sSQL += "          ,KEIJOHO.TORI_KBN " & vbCrLf
            sSQL += "          ,KEIJOHO.NOJO_CD " & vbCrLf
            sSQL += "       ORDER BY " & vbCrLf
            sSQL += "           KI " & vbCrLf
            sSQL += "          ,JIMUITAKU_CD " & vbCrLf
            sSQL += "          ,KEN_CD " & vbCrLf
            sSQL += "          ,KEIYAKUSYA_CD " & vbCrLf
            sSQL += "          ,KEIYAKU_KBN " & vbCrLf
            sSQL += "          ,NOJO_CD " & vbCrLf
            sSQL += "          ,TORI_KBN " & vbCrLf
            sSQL += "       ) DTL " & vbCrLf
            sSQL += "    GROUP BY " & vbCrLf
            sSQL += "        GROUPING SETS " & vbCrLf
            sSQL += "                    ( " & vbCrLf
            '                            -- 契約者別
            sSQL += "                     (DTL.KI,DTL.JIMUITAKU_CD,DTL.KEN_CD,DTL.KEIYAKUSYA_CD) " & vbCrLf
            '                            -- 県別
            sSQL += "                    ,(DTL.KI,DTL.JIMUITAKU_CD,DTL.KEN_CD) " & vbCrLf
            '                            -- 明細
            sSQL += "                    ,(DTL.SEQ_NO) " & vbCrLf
            '                            --  総合計
            sSQL += "                    ,() " & vbCrLf
            sSQL += "                    ) " & vbCrLf
            sSQL += "    ORDER BY " & vbCrLf
            sSQL += "        KI " & vbCrLf
            sSQL += "       ,JIMUITAKU_CD " & vbCrLf
            sSQL += "       ,KEN_CD " & vbCrLf
            sSQL += "       ,KEIYAKUSYA_CD " & vbCrLf
            sSQL += "       ,KEIYAKU_KBN " & vbCrLf
            sSQL += "       ,NOJO_CD " & vbCrLf
            sSQL += "       ,TORI_KBN " & vbCrLf
            sSQL += "       ,GRPID " & vbCrLf
            sSQL += "    ) GRP " & vbCrLf
            sSQL += "   ,TM_KEIYAKU KEI " & vbCrLf
            sSQL += "   ,TM_JIMUITAKU JIM " & vbCrLf
            sSQL += "   ,TM_KEIYAKU_NOJO NOJO " & vbCrLf
            sSQL += "   ,TM_CODE CD01 " & vbCrLf
            sSQL += "   ,TM_CODE CD05N " & vbCrLf
            sSQL += "   ,TM_CODE CD07 " & vbCrLf
            sSQL += " WHERE " & vbCrLf
            '             -- 3:明細,4:契約者別,5:都道府県別,7:総合計
            'sSQL += "     GRPID IN (3,4,5,7) " & vbCrLf
            '             -- 3:明細,4:契約者別,7:総合計
            sSQL += "     GRPID IN (3,4,7) " & vbCrLf
            '             -- 契約者マスタ
            sSQL += " AND GRP.KI = KEI.KI(+) " & vbCrLf
            sSQL += " AND GRP.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+) " & vbCrLf
            '             -- 事務委託先マスタ
            sSQL += " AND GRP.KI = JIM.KI(+) " & vbCrLf
            sSQL += " AND GRP.JIMUITAKU_CD = JIM.ITAKU_CD(+) " & vbCrLf
            '             -- 契約者農場マスタ
            sSQL += " AND GRP.KI = NOJO.KI(+) " & vbCrLf
            sSQL += " AND GRP.KEIYAKUSYA_CD = NOJO.KEIYAKUSYA_CD(+) " & vbCrLf
            sSQL += " AND GRP.NOJO_CD = NOJO.NOJO_CD(+) " & vbCrLf
            '             -- 契約区分
            sSQL += " AND 1 = CD01.SYURUI_KBN(+) " & vbCrLf
            sSQL += " AND GRP.KEIYAKU_KBN = CD01.MEISYO_CD(+) " & vbCrLf
            '             -- 鶏の種類
            sSQL += " AND 7 = CD07.SYURUI_KBN(+) " & vbCrLf
            sSQL += " AND GRP.TORI_KBN = CD07.MEISYO_CD(+) " & vbCrLf
            '             -- 都道府県(農場)
            sSQL += " AND 5 = CD05N.SYURUI_KBN(+) " & vbCrLf
            sSQL += " AND NOJO.KEN_CD = CD05N.MEISYO_CD(+) " & vbCrLf

            sSQL += " ORDER BY " & vbCrLf
            sSQL += "     KI " & vbCrLf
            sSQL += "    ,JIMUITAKU_CD " & vbCrLf
            sSQL += "    ,KEN_CD " & vbCrLf
            sSQL += "    ,KEIYAKUSYA_CD " & vbCrLf
            sSQL += "    ,KEIYAKU_KBN " & vbCrLf
            sSQL += "    ,NOJO_CD " & vbCrLf
            sSQL += "    ,TORI_KBN " & vbCrLf
            sSQL += "    ,GRPID " & vbCrLf


            'ＳＱＬ
            wSQL = sSQL

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_makeExcel EXCELデータ生成"
    ''' <summary>
    ''' EXCELデータ生成
    ''' </summary>
    ''' <param name="wkDT"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function f_makeExcel(ByVal wkDT As DataTable) As Boolean
        Dim ret As Boolean = False
        Dim filNm As String = "事業加入状況表(農場別リスト)_"
        'Dim xl As New JBD.Silver.Win.Excel         '2012/04/25
        Dim xl As New Excel
        'Dim xl As New gjExcel

        Try

            '件数確認
            If wkDT.Rows.Count <= 0 Then
                Show_MessageBox("I002", "") '該当データが存在しません。
                Exit Try
            End If

            '↓2017/07/14 追加 追加納付を追加
            If pKikin2 Then
                filNm = "事業加入状況表(農場別リスト)(追加納付)_"
            End If
            'ファイル出力パス
            If f_FileDialog("xlsx", filNm) = False Then
                Exit Try
            End If
            If filNm = "" Then
                Exit Try
            End If

            'テンプレートファイルの保存
            If xl.SetExcelFile_xlsx("事業加入状況表(農場別リスト).xlsx", filNm) = False Then
                Exit Try
            End If

            Me.Cursor = Cursors.WaitCursor



            'テンプレートファイルのOPEN保存
            If xl.XlOpen_xlsx(filNm, "Sheet1") = False Then
                Exit Try
            End If


            'データ作成
            xl.SetdataCell(1, 1, wkDT.Rows(0)("NAME_HED"))

            PrgBar.Visible = True
            PrgBar.Minimum = 0
            PrgBar.Maximum = wkDT.Rows.Count

            Dim rowMaxRow As Integer
            Dim rowWkCnt As Integer
            Dim rowPos As Integer
            Dim rowCnt As Integer

            rowPos = 5      '開始位置 #79対応
            rowCnt = 1
            rowMaxRow = 500  '最大配列件数
            'rowMaxRow = wkDT.Rows.Count  '最大配列件数
            rowWkCnt = 0

            xl.SetRangeCopy(rowPos & ":" & rowPos, wkDT.Rows.Count - 1)      '枠コピー

            '↓2017/07/12 修正 鳥区分追加
            'Dim data(rowMaxRow, 17) As Object
            Dim data(rowMaxRow, 22) As Object
            '↓2017/07/12 修正 鳥区分追加
            For Each wkRow As DataRow In wkDT.Rows

                PrgBar.Value = rowCnt


                'xl.SetRangeCopy(rowPos & ":" & rowPos)      '行コピー

                '項目
                'xl.SetdataCell(rowPos, 1, WordHenkan("N", "S", wkRow("ITAKU_NM")))              '事務委託先名

                'If WordHenkan("N", "Z", wkRow("GRPID")) = 4 Then
                '    xl.SetdataCell(rowPos, 2, "")         '契約者番号
                'ElseIf WordHenkan("N", "Z", wkRow("GRPID")) = 7 Then
                '    xl.SetdataCell(rowPos, 2, "")         '契約者番号
                'Else
                '    xl.SetdataCell(rowPos, 2, WordHenkan("N", "S", wkRow("KEIYAKUSYA_CD")))         '契約者番号
                'End If


                'xl.SetdataCell(rowPos, 3, WordHenkan("N", "S", wkRow("KEIYAKUSYA_NAME")))       '契約者名
                'xl.SetdataCell(rowPos, 4, WordHenkan("N", "S", wkRow("DAIHYO_NAME")))           '代表者名
                'xl.SetdataCell(rowPos, 5, WordHenkan("N", "S", wkRow("NOJO_CD")))               '農場コード
                'xl.SetdataCell(rowPos, 6, WordHenkan("N", "S", wkRow("NOJO_NAME")))             '農場名
                'xl.SetdataCell(rowPos, 7, WordHenkan("N", "S", wkRow("TORI_KBN_NM")))           '鶏の種類名
                'xl.SetdataCell(rowPos, 8, WordHenkan("N", "S", wkRow("NOJO_KEN_NM")))           '都道府県名（農場）
                'xl.SetdataCell(rowPos, 9, WordHenkan("N", "S", wkRow("NOJO_ADDR")))             '農場住所

                'xl.SetdataCell(rowPos, 10, WordHenkan("N", "Z", wkRow("HASU1")))                '農場羽数-採卵鶏成鶏
                'xl.SetdataCell(rowPos, 11, WordHenkan("N", "Z", wkRow("HASU2")))                '農場羽数-採卵鶏育成
                'xl.SetdataCell(rowPos, 12, WordHenkan("N", "Z", wkRow("HASU3")))                '農場羽数-肉用種
                'xl.SetdataCell(rowPos, 13, WordHenkan("N", "Z", wkRow("HASU4")))                '農場羽数-種鶏成鶏
                'xl.SetdataCell(rowPos, 14, WordHenkan("N", "Z", wkRow("HASU5")))                '農場羽数-種鶏育成
                'xl.SetdataCell(rowPos, 15, WordHenkan("N", "Z", wkRow("HASU6")))                '農場羽数-うずら
                'xl.SetdataCell(rowPos, 16, WordHenkan("N", "Z", wkRow("HASU_SUM")))             '農場羽数-合計

                'xl.SetdataCell(rowPos, 17, WordHenkan("N", "Z", wkRow("KEIYAKU_KBN_NM")))       '契約区分名



                data(rowWkCnt, 0) = WordHenkan("N", "S", wkRow("ITAKU_NM"))                       '事務委託先名
                If WordHenkan("N", "Z", wkRow("GRPID")) = 4 Then
                    data(rowWkCnt, 1) = ""                                                        '契約者番号
                ElseIf WordHenkan("N", "Z", wkRow("GRPID")) = 7 Then
                    data(rowWkCnt, 1) = ""                                                        '契約者番号
                Else
                    data(rowWkCnt, 1) = WordHenkan("N", "S", wkRow("KEIYAKUSYA_CD"))              '契約者番号
                End If
                data(rowWkCnt, 2) = WordHenkan("N", "S", wkRow("KEIYAKUSYA_NAME"))                '契約者名
                data(rowWkCnt, 3) = WordHenkan("N", "S", wkRow("DAIHYO_NAME"))                    '代表者名
                data(rowWkCnt, 4) = WordHenkan("N", "S", wkRow("NOJO_CD"))                        '農場コード
                data(rowWkCnt, 5) = WordHenkan("N", "S", wkRow("NOJO_NAME"))                      '農場名
                data(rowWkCnt, 6) = WordHenkan("N", "S", wkRow("TORI_KBN_NM"))                    '鶏の種類名
                data(rowWkCnt, 7) = WordHenkan("N", "S", wkRow("NOJO_KEN_NM"))                    '都道府県名（農場）
                data(rowWkCnt, 8) = WordHenkan("N", "S", wkRow("NOJO_ADDR"))                      '農場住所

                data(rowWkCnt, 9) = WordHenkan("N", "Z", wkRow("HASU1"))                          '農場羽数-採卵鶏成鶏
                data(rowWkCnt, 10) = WordHenkan("N", "Z", wkRow("HASU2"))                         '農場羽数-採卵鶏育成
                data(rowWkCnt, 11) = WordHenkan("N", "Z", wkRow("HASU3"))                         '農場羽数-肉用種
                data(rowWkCnt, 12) = WordHenkan("N", "Z", wkRow("HASU4"))                         '農場羽数-種鶏成鶏
                data(rowWkCnt, 13) = WordHenkan("N", "Z", wkRow("HASU5"))                         '農場羽数-種鶏育成
                data(rowWkCnt, 14) = WordHenkan("N", "Z", wkRow("HASU6"))                         '農場羽数-うずら
                '↓2017/07/12 追加 鳥区分追加
                data(rowWkCnt, 15) = WordHenkan("N", "Z", wkRow("HASU7"))                         '農場羽数-あひる
                data(rowWkCnt, 16) = WordHenkan("N", "Z", wkRow("HASU8"))                         '農場羽数-きじ
                data(rowWkCnt, 17) = WordHenkan("N", "Z", wkRow("HASU9"))                         '農場羽数-ほろほろ鳥
                data(rowWkCnt, 18) = WordHenkan("N", "Z", wkRow("HASU10"))                         '農場羽数-七面鳥
                data(rowWkCnt, 19) = WordHenkan("N", "Z", wkRow("HASU11"))                         '農場羽数-だちょう
                '↑2017/07/12 追加 鳥区分追加
                '↓2017/07/12 修正 鳥区分追加
                'data(rowWkCnt, 15) = WordHenkan("N", "Z", wkRow("HASU_SUM"))                      '農場羽数-合計

                'data(rowWkCnt, 16) = WordHenkan("N", "S", wkRow("KEIYAKU_KBN_NM"))                '契約区分名
                data(rowWkCnt, 20) = WordHenkan("N", "Z", wkRow("HASU_SUM"))                      '農場羽数-合計

                data(rowWkCnt, 21) = WordHenkan("N", "S", wkRow("KEIYAKU_KBN_NM"))                '契約区分名
                '↑2017/07/12 修正 鳥区分追加


                '配列数の判定
                If rowWkCnt >= rowMaxRow Then
                    '配列セット
                    '↓2017/07/12 修正 鳥区分追加
                    'xl.SetRangeValue(rowPos - rowMaxRow, rowPos, 17, data)
                    xl.SetRangeValue(rowPos - rowWkCnt, rowPos, 22, data)
                    '↑2017/07/12 修正 鳥区分追加
                    rowWkCnt = 0
                ElseIf rowCnt >= wkDT.Rows.Count Then
                    '配列セット
                    '↓2017/07/12 修正 鳥区分追加
                    'xl.SetRangeValue(rowPos - rowWkCnt, rowPos, 17, data)
                    xl.SetRangeValue(rowPos - rowWkCnt, rowPos, 22, data)
                    '↑2017/07/12 修正 鳥区分追加
                Else
                    rowWkCnt = rowWkCnt + 1
                End If

                rowCnt = rowCnt + 1
                rowPos = rowPos + 1
            Next

            'Excel保存
            xl.XlSave_xlsx(filNm)

            PrgBar.Visible = False

            ret = True
        Catch ex As Exception
            Show_MessageBox("", ex.Message)
        Finally
            '---- Excelの終了処理
            Call xl.XlClose()

            Me.Cursor = Cursors.Default      '2005/11/30 jbd368
        End Try

        Return ret

    End Function
#End Region

#End Region

#Region "***ローカル関数***"

#Region "f_ObjectClear 画面クリア処理"
    ''' <summary>
    ''' 画面クリア
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_ObjectClear(ByVal wKbn As String) As Boolean

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor


            '画面初期化
            pJump = True
            Call f_ClearFormALL(Me, wKbn)
            '#005 修正START
            'pJump = False  '#005 修正

            '画面内容をセット
            If Not f_SetForm_Data() Then
                Exit Try
            End If

            'コンボセット
            If wKbn = "C" Then
                f_ComboBox_Set(wKbn)
            End If
            pJump = False
            '#005 修正END

            '画面変更フラグ
            'pblnTextChange = False 'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL
            PrgBar.Visible = False

            '先頭入力へ
            numKI.Focus()

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
    '引数            :区分
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ComboBox_Set(ByVal wKbn As String) As Boolean
        Dim sSql As String = String.Empty
        Dim sWhere As String = String.Empty
        Dim ret As Boolean = False

        Try
            pJump = True
            If wKbn = "C" Then
                '--------------------
                '契約区分
                '--------------------
                'FROM
                'If Not f_CodeMaster_Data_Select(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_Fm, 1, True, 1) Then '2017/07/11 修正
                If Not f_CodeMaster_Data_Select(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_Fm, 1, True, 0) Then  '2017/07/11 修正
                    Exit Try
                End If
                'FROM
                'If Not f_CodeMaster_Data_Select(cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To, 1, True, 1) Then '2017/07/11 修正
                If Not f_CodeMaster_Data_Select(cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To, 1, True, 0) Then  '2017/07/11 修正
                    Exit Try
                End If

                '--------------------
                '鶏区分
                '--------------------
                'FROM
                If Not f_CodeMaster_Data_Select(cboTORI_KBN_Cd_Fm, cboTORI_KBN_Nm_Fm, 7, True, 1) Then
                    Exit Try
                End If
                'FROM
                If Not f_CodeMaster_Data_Select(cboTORI_KBN_Cd_To, cboTORI_KBN_Nm_To, 7, True, 1) Then
                    Exit Try
                End If

                '--------------------
                '都道府県
                '--------------------
                'FROM
                If Not f_Ken_Data_Select(cboKEN_Cd_Fm, cboKEN_Nm_Fm, True) Then
                    Exit Try
                End If
                'FROM
                If Not f_Ken_Data_Select(cboKEN_Cd_To, cboKEN_Nm_To, True) Then
                    Exit Try
                End If


                '--------------------
                '契約者
                '--------------------
                sWhere = "KI = " & numKI.Text
                'FROM
                If Not f_Keiyaku_Data_Select(cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm, sWhere, True) Then
                    Exit Try
                End If
                'FROM
                If Not f_Keiyaku_Data_Select(cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To, sWhere, True) Then
                    Exit Try
                End If


                'コンボボックス初期化
                cboKEIYAKU_KBN_Cd_Fm.Text = ""
                cboKEIYAKU_KBN_Cd_To.Text = ""

                cboTORI_KBN_Cd_Fm.Text = ""
                cboTORI_KBN_Cd_To.Text = ""

                cboKEN_Cd_Fm.Text = ""
                cboKEN_Cd_To.Text = ""


                cboKEIYAKUSYA_Cd_Fm.Text = ""
                cboKEIYAKUSYA_Cd_To.Text = ""

            End If

            If wKbn = "K" Then

                '--------------------
                '契約者
                '--------------------
                sWhere = "KI = " & numKI.Text
                'FROM
                If Not f_Keiyaku_Data_Select(cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm, sWhere, True) Then
                    Exit Try
                End If
                'FROM
                If Not f_Keiyaku_Data_Select(cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To, sWhere, True) Then
                    Exit Try
                End If


                'コンボボックス初期化
                cboKEIYAKUSYA_Cd_Fm.Text = ""
                cboKEIYAKUSYA_Cd_To.Text = ""

            End If
            pJump = False


            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_SetForm_Data データ画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_Data
    '説明            :データ画面セット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_Data() As Boolean
        Dim sSql As New StringBuilder
        Dim dstDataSet As New DataSet
        Dim ret As Boolean = False

        Try
            '初期値
            numKI.Text = New Obj_TM_SYORI_NENDO_KI().pKI

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




            '==いろいろチェック==================
            ''対象日（現在）チェック
            'Dim dtJIGYO_NENDO = New Obj_TM_SYORI_NENDO_KI().pJIGYO_NENDO_byDate
            'Dim dtJIGYO_SYURYO_NENDO = New Obj_TM_SYORI_NENDO_KI().pJIGYO_SYURYO_NENDO_byDate
            'If dtJIGYO_NENDO >= dateTAISYOBI_Ymd.Value And dtJIGYO_SYURYO_NENDO <= dateTAISYOBI_Ymd.Value Then
            '    wkControlName = "対象期年度以外の対象日（現在）"
            '    Call Show_MessageBox_Add("W029", wkControlName) : dateTAISYOBI_Ymd.Focus() : Exit Try
            'End If

            '==FromToチェック==================
            '契約区分
            If f_Daisyo_Check(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Cd_To, "契約区分", True, 1) = False Then
                Return False
            End If

            '鶏区分
            If f_Daisyo_Check(cboTORI_KBN_Cd_Fm, cboTORI_KBN_Cd_To, "鶏の種類", True, 1) = False Then
                Return False
            End If

            '都道府県
            If f_Daisyo_Check(cboKEN_Cd_Fm, cboKEN_Cd_To, "都道府県", True, 1) = False Then
                Return False
            End If

            '契約者番号
            If f_Daisyo_Check(cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Cd_To, "契約者番号", True, 1) = False Then
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
