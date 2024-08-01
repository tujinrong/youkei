'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ1050.vb
'*
'*　　②　機能概要　　　　　事務委託先別・契約者別生産者積立金等一覧表作成処理
'*
'*　　③　作成日　　　　　　2014/01/15 JBD999
'*
'*　　④　更新日            
'*
'*******************************************************************************
Option Strict Off
Option Explicit On
Imports System.Text
'------------------------------------------------------------------

Imports JbdGjsCommon
Imports JbdGjsControl
Imports JbdGjsReport
'------------------------------------------------------------------



Public Class frmGJ1050

#Region "***変数定義***"

    'Private pblnTextChange As Boolean                   '画面入力内容変更フラグ R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL

    ''' <summary>
    ''' プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True                     '処理ジャンプ

    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "事務委託先別・契約者別生産者積立金等一覧表（仮計算）"

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
            'f_setControlChangeEvents() R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL

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
    Private Sub numKI_TextChanged(sender As Object, e As EventArgs) Handles numKI.TextChanged
        '2015/03/03 JBD368 MOVE ↓↓↓ 処理をValidatingイベントに移動
        ''画面クリアの時、処理しない
        'If pJump Then
        '    Exit Sub
        'End If

        'If numKI.Value Is Nothing Then
        '    cboITAKU_Cd_Fm.Items.Clear()
        '    cboITAKU_Nm_Fm.Items.Clear()
        '    cboITAKU_Cd_To.Items.Clear()
        '    cboITAKU_Nm_To.Items.Clear()

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
        '2015/03/03 JBD368 MOVE ↑↑↑
        'pblnTextChange = False             '画面入力内容変更フラグ初期化 R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL
    End Sub
    '2013/03/03 JBD368 ADD ↓↓↓
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
            '2015/03/03 JBD368 UPD ↓↓↓ クリア方法を変更
            'cboITAKU_Cd_Fm.Items.Clear()
            'cboITAKU_Nm_Fm.Items.Clear()
            'cboITAKU_Cd_To.Items.Clear()
            'cboITAKU_Nm_To.Items.Clear()

            'cboKEIYAKUSYA_Cd_Fm.Items.Clear()
            'cboKEIYAKUSYA_Nm_Fm.Items.Clear()
            'cboKEIYAKUSYA_Cd_To.Items.Clear()
            'cboKEIYAKUSYA_Nm_To.Items.Clear()

            cboITAKU_Cd_Fm.DataSource = Nothing
            cboITAKU_Cd_Fm.Clear()
            cboITAKU_Nm_Fm.DataSource = Nothing
            cboITAKU_Nm_Fm.Clear()
            cboITAKU_Cd_To.DataSource = Nothing
            cboITAKU_Cd_To.Clear()
            cboITAKU_Nm_To.DataSource = Nothing
            cboITAKU_Nm_To.Clear()

            cboKEIYAKUSYA_Cd_Fm.DataSource = Nothing
            cboKEIYAKUSYA_Cd_Fm.Clear()
            cboKEIYAKUSYA_Nm_Fm.DataSource = Nothing
            cboKEIYAKUSYA_Nm_Fm.Clear()
            cboKEIYAKUSYA_Cd_To.DataSource = Nothing
            cboKEIYAKUSYA_Cd_To.Clear()
            cboKEIYAKUSYA_Nm_To.DataSource = Nothing
            cboKEIYAKUSYA_Nm_To.Clear()
            '2015/03/03 JBD368 UPD ↑↑↑
            Exit Sub
        End If

        '---------------------------------------------------
        '初期表示
        '---------------------------------------------------
        'コンボの初期化
        f_ComboBox_Set("K")

    End Sub
    '2015/03/03 JBD368 ADD ↑↑↑
#End Region

#Region "契約区分FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_KBN_Cd_Fm_SelectedIndexChanged
    '説明            :契約区分コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_KBN_Cd_Fm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKEIYAKU_KBN_Cd_Fm.SelectedIndexChanged
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
    Private Sub cboKEIYAKU_KBN_Nm_Fm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKEIYAKU_KBN_Nm_Fm.SelectedIndexChanged
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
    Private Sub cboKEIYAKU_KBN_Cd_Fm_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboKEIYAKU_KBN_Cd_Fm.Validating
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
    Private Sub cboKEIYAKU_KBN_Cd_To_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKEIYAKU_KBN_Cd_To.SelectedIndexChanged
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
    Private Sub cboKEIYAKU_KBN_Nm_To_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKEIYAKU_KBN_Nm_To.SelectedIndexChanged
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
    Private Sub cboKEIYAKU_KBN_Cd_To_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboKEIYAKU_KBN_Cd_To.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboTo_Validating(cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To, cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_Fm)
    End Sub


#End Region

#Region "都道府県FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEN_Cd_Fm_SelectedIndexChanged
    '説明            :都道府県コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEN_Cd_Fm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKEN_Cd_Fm.SelectedIndexChanged
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
    Private Sub cboKEN_Nm_Fm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKEN_Nm_Fm.SelectedIndexChanged
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
    Private Sub cboKEN_Cd_Fm_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboKEN_Cd_Fm.Validating
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
    Private Sub cboKEN_Cd_To_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKEN_Cd_To.SelectedIndexChanged
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
    Private Sub cboKEN_Nm_To_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKEN_Nm_To.SelectedIndexChanged
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
    Private Sub cboKEN_Cd_To_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboKEN_Cd_To.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboTo_Validating(cboKEN_Cd_To, cboKEN_Nm_To, cboKEN_Cd_Fm, cboKEN_Nm_Fm)
    End Sub
#End Region

#Region "事務委託先FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboITAKU_Cd_Fm_SelectedIndexChanged
    '説明            :事務委託先コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboITAKU_Cd_Fm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboITAKU_Cd_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboITAKU_Nm_Fm.SelectedIndex = cboITAKU_Cd_Fm.SelectedIndex
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboITAKU_Nm_Fm_SelectedIndexChanged
    '説明            :事務委託先名FromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboITAKU_Nm_Fm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboITAKU_Nm_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiFrom_SelectedIndexChanged(cboITAKU_Nm_Fm, cboITAKU_Cd_Fm, cboITAKU_Nm_To, cboITAKU_Cd_To)
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboITAKU_Cd_Fm_Validating
    '説明            :事務委託先コードFromValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboITAKU_Cd_Fm_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboITAKU_Cd_Fm.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        '2015/03/03 JBD368 UPD ↓↓↓ コンボボックスの動作変更
        'Call s_CboFrom_Validating(cboITAKU_Cd_Fm, cboITAKU_Nm_Fm, cboITAKU_Cd_To, cboITAKU_Nm_To)
        Call s_CboFrom_Validating(cboITAKU_Cd_Fm, cboITAKU_Nm_Fm, cboITAKU_Cd_To, cboITAKU_Nm_To, "2")
        '2015/03/03 JBD368 UPD ↑↑↑
    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cboITAKU_Cd_To_SelectedIndexChanged
    '説明            :事務委託先コードToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboITAKU_Cd_To_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboITAKU_Cd_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboITAKU_Nm_To.SelectedIndex = cboITAKU_Cd_To.SelectedIndex
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboITAKU_Nm_To_SelectedIndexChanged
    '説明            :事務委託先名ToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboITAKU_Nm_To_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboITAKU_Nm_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiTo_Validating(cboITAKU_Nm_To, cboITAKU_Cd_To, cboITAKU_Nm_Fm, cboITAKU_Cd_Fm)
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboITAKU_Cd_To_Validating
    '説明            :事務委託先コードToValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboITAKU_Cd_To_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboITAKU_Cd_To.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        '2015/03/03 JBD368 UPD ↓↓↓ コンボボックスの動作変更
        'Call s_CboTo_Validating(cboITAKU_Cd_To, cboITAKU_Nm_To, cboITAKU_Cd_Fm, cboITAKU_Nm_Fm)
        Call s_CboTo_Validating(cboITAKU_Cd_To, cboITAKU_Nm_To, cboITAKU_Cd_Fm, cboITAKU_Nm_Fm, "2")
        '2015/03/03 JBD368 UPD ↑↑↑
    End Sub
#End Region

#Region "契約者FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKUSYA_Cd_Fm_SelectedIndexChanged
    '説明            :契約者コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKUSYA_Cd_Fm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKEIYAKUSYA_Cd_Fm.SelectedIndexChanged
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
    Private Sub cboKEIYAKUSYA_Nm_Fm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKEIYAKUSYA_Nm_Fm.SelectedIndexChanged
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
    Private Sub cboKEIYAKUSYA_Cd_Fm_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboKEIYAKUSYA_Cd_Fm.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        '2015/03/03 JBD368 UPD ↓↓↓ コンボボックスの動作変更
        'Call s_CboFrom_Validating(cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm, cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To)
        Call s_CboFrom_Validating(cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm, cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To, "2")
        '2015/03/03 JBD368 UPD ↑↑↑
    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKUSYA_Cd_To_SelectedIndexChanged
    '説明            :契約者コードToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKUSYA_Cd_To_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKEIYAKUSYA_Cd_To.SelectedIndexChanged
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
    Private Sub cboKEIYAKUSYA_Nm_To_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKEIYAKUSYA_Nm_To.SelectedIndexChanged
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
    Private Sub cboKEIYAKUSYA_Cd_To_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboKEIYAKUSYA_Cd_To.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        '2015/03/03 JBD368 UPD ↓↓↓ コンボボックスの動作変更
        'Call s_CboTo_Validating(cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To, cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm)
        Call s_CboTo_Validating(cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To, cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm, "2")
        '2015/03/03 JBD368 UPD ↑↑↑
    End Sub
#End Region



#End Region

#Region "***画面ボタンクリック関連***"

#Region "cmdPreview_Click プレビューボタンクリック処理"
    ''' <summary>
    ''' プレビューボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        Dim ea As New System.ComponentModel.CancelEventArgs

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '事前チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '帳票出力処理
            If Not f_Report_Output() Then
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
            'R05年度　OSバージョンアップ　既存バグ修正のため変更　2024/03/12 JBD 453 DEL START
            'If pblnTextChange Then
            '    '画面に変更があり保存していない場合は、メッセージ表示
            '    If Show_MessageBox("Q007", "") = DialogResult.No Then
            '        '「いいえ」を選択
            '        Exit Sub
            '    End If
            'End If
            'R05年度　OSバージョンアップ　既存バグ修正のため変更　 DEL END
            ret = f_ObjectClear("")

            rdoSEISANSYA.Checked = True '2021/04/13 JBD9020 R03年度追加基金対応 

            '期にフォーカスセット
            numKI.Focus()
            'pblnTextChange = False             '画面入力内容変更フラグ初期化 R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL

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

            'pblnTextChange = False      '画面入力内容変更フラグ初期化 R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL
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

#Region "帳票レポート出力関連"
#Region "f_Report_Output 帳票レポート出力処理"
    ''' <summary>
    '''  帳票レポート出力処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Report_Output() As Boolean
        Dim wkSql As String = String.Empty
        Dim wkDSRep As New DataSet

        Try
            ''--------------------------------------------------
            ''データ取得
            ''--------------------------------------------------
            wkDSRep.Tables.Add(con_ReportName)


            'SQL
            If Not f_make_SQL(0, wkSql) Then
                Exit Try
            End If


            'データ取得
            Using wkAdp As New OracleDataAdapter(wkSql, Cnn)
                wkAdp.Fill(wkDSRep, wkDSRep.Tables(0).TableName)
            End Using

            If wkDSRep.Tables(0).Rows.Count > 0 Then
                Dim w As New rptGJ1050
                w.sub1(wkDSRep)
                'Using wkAR As New rptGJ1050

                '    'ヘッダ用の値を保管
                '    wkAR.pKIKIN2 = pKikin2      '2017/07/14　追加
                '    ' 用紙サイズを B4横 に設定します。
                '    wkAR.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
                '    wkAR.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape
                '    ' 上下の余白を 1.0cm に設定します。
                '    wkAR.PageSettings.Margins.Top = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_UP)
                '    wkAR.PageSettings.Margins.Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_DOWN)
                '    'wkAR.PageSettings.Margins.Bottom = 0.87
                '    ' 左右の余白を 1.0cm に設定します。
                '    wkAR.PageSettings.Margins.Left = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_LEFT)
                '    wkAR.PageSettings.Margins.Right = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_RIGHT)

                '    '----------------------------------------------------
                '    wkAR.DataSource = wkDSRep
                '    wkAR.DataMember = wkDSRep.Tables(0).TableName
                '    wkAR.Run() '実行

                '    ''--------------------------------------------------
                '    ''ＰＤＦ出力
                '    ''--------------------------------------------------
                '    'ファイル存在ﾁｪｯｸ()
                '    Dim strOutPath As String = ""
                '    If Not f_ReportPath_Check(strOutPath, 0, myREPORT_PDF_PATH, pAPP & con_ReportName) Then
                '        Exit Try
                '    Else
                '        Using export As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                '            export.Export(wkAR.Document, strOutPath)
                '        End Using
                '    End If

                '    '--------------------------------------------------
                '    'プレビュー表示
                '    '--------------------------------------------------
                '    Dim wkForm As New frmViewer(wkAR, pAPP & con_ReportName) '※このプレビューは関数を抜けたあとも生き残る。
                '    wkForm.Show()
                'End Using

            Else
                'エラーリスト出力なし
                Show_MessageBox("I002", "") '該当データが存在しません。
                Return False
            End If

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
        Dim strChekVal As String

        '#29 ADD START
        Dim sKaishiNen As String
        Dim sSyuryoNen As String
        '#29 ADD END


        Try
            '対象期・年度の取得
            Dim SyoriKI = New Obj_TM_SYORI_NENDO_KI()

            '#29 ADD START
            '期の開始年と終了年の算出
            sKaishiNen = ((numKI.Value - 6) * 3) + 2015 & "/04/01"
            sSyuryoNen = ((numKI.Value - 6) * 3) + 2015 + 2 & "/03/31"
            '#29 ADD END


            sSQL = " SELECT " & vbCrLf
            sSQL += "   TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI " & vbCrLf
            '-- 対象期間
            '#29 ADD START
            sSQL += " ,'対象期：第" & numKI.Value & "期（' || TO_CHAR(TO_DATE('" & sKaishiNen & "'), '""""EEYY""年度～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & sSyuryoNen & "'), '""""EEYY""年度）""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS TAISYO_KI " & vbCrLf
            '#29 ADD END

            '-- 事務委託先
            '2021/04/13 JBD9020 R03年度追加基金対応 UPD START
            If rdoJIMUITAKU.Checked Then
                sSQL += " ,GRP.JIMUITAKU_CD AS JIMUITAKU_CD " & vbCrLf
            Else
                sSQL += " ,99999 AS JIMUITAKU_CD " & vbCrLf
            End If
            '2021/04/13 JBD9020 R03年度追加基金対応 UPD END
            sSQL += " ,JIM.ITAKU_NAME AS ITAKU_NAME " & vbCrLf
            sSQL += " ,'事務委託先(' || GRP.JIMUITAKU_CD || ')：' || JIM.ITAKU_NAME AS ITAKU_NAME_HED " & vbCrLf

            '-- 契約者
            sSQL += " ,GRP.KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            sSQL += "    WHEN GRP.JIMUITAKU_CD = 9999 THEN '総合計' " & vbCrLf
            sSQL += "    WHEN GRP.KEIYAKUSYA_CD = 999999 THEN '事務委託先合計' " & vbCrLf
            sSQL += "    ELSE KEI.KEIYAKUSYA_NAME " & vbCrLf
            sSQL += "  END KEIYAKUSYA_NAME " & vbCrLf

            '-- 入力状況
            sSQL += " ,KEI.NYURYOKU_JYOKYO AS NYURYOKU_JYOKYO " & vbCrLf

            sSQL += " ,CD12.MEISYO AS NYURYOKU_JYOKYO_NM " & vbCrLf
            '▽▽▽--2015/10/07　修正開始--▽▽▽
            'sSQL += " ,'入力状況：' || CD12.MEISYO AS NYURYOKU_JYOKYO_NM_HED " & vbCrLf
            If chkNYURYOKU_CYU.Checked AndAlso chkNYURYOKU_KAKUTEI.Checked Then
                sSQL += " ,'入力状況：両方' AS NYURYOKU_JYOKYO_NM_HED " & vbCrLf
            Else
                sSQL += " ,'入力状況：' || CD12.MEISYO AS NYURYOKU_JYOKYO_NM_HED " & vbCrLf
            End If
            '△△△--2015/10/07　修正開始--△△△

            '-- 契約区分
            sSQL += " ,KEI.KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
            '↓2017/07/12 修正 契約区分
            'sSQL += " ,CD01.RYAKUSYO AS KEIYAKU_KBN_NM " & vbCrLf
            sSQL += " ,CD01.MEISYO AS KEIYAKU_KBN_NM " & vbCrLf
            '↑2017/07/12 修正 契約区分
            '-- 契約状況
            sSQL += " ,KEI.KEIYAKU_JYOKYO AS KEIYAKU_JYOKYO " & vbCrLf
            sSQL += " ,CD02.RYAKUSYO AS KEIYAKU_JYOKYO_NM " & vbCrLf
            '-- 都道府県
            sSQL += " ,KEI.KEN_CD AS KEN_CD " & vbCrLf
            sSQL += " ,CD05.MEISYO AS KEN_NM " & vbCrLf
            '-- 鶏の種類
            sSQL += " ,GRP.TORI_KBN AS TORI_KBN " & vbCrLf
            sSQL += " ,CD07.MEISYO AS TORI_KBN_NM " & vbCrLf
            '-- 鶏の種類別件数
            sSQL += " ,GRP.TORI_KBN_CNT AS TORI_KBN_CNT " & vbCrLf
            '-- 飼育農場数
            'sSQL += " ,GRP.NOJO_CNT AS NOJO_CNT " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            sSQL += "    WHEN GRP.JIMUITAKU_CD = 9999 THEN NULL " & vbCrLf
            sSQL += "    WHEN GRP.KEIYAKUSYA_CD = 999999 THEN NULL " & vbCrLf
            sSQL += "    ELSE TO_CHAR(GRP.NOJO_CNT) " & vbCrLf
            sSQL += "  END NOJO_CNT " & vbCrLf
            'sSQL += " ,GRP.NOJO_CNT_KEI AS NOJO_CNT_SUM " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            sSQL += "    WHEN GRP.JIMUITAKU_CD = 9999 THEN NULL " & vbCrLf
            sSQL += "    WHEN GRP.KEIYAKUSYA_CD = 999999 THEN NULL " & vbCrLf
            sSQL += "    ELSE TO_CHAR(GRP.NOJO_CNT_KEI) " & vbCrLf
            sSQL += "  END NOJO_CNT_SUM " & vbCrLf

            '-- 契約羽数
            sSQL += " ,GRP.KEIYAKU_HASU AS KEIYAKU_HASU " & vbCrLf
            '-- 単価
            'sSQL += " ,GRP.TUMITATE_TANKA AS TUMITATE_TANKA " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            sSQL += "    WHEN GRP.JIMUITAKU_CD = 9999 THEN NULL " & vbCrLf
            sSQL += "    WHEN GRP.KEIYAKUSYA_CD = 999999 THEN NULL " & vbCrLf
            sSQL += "    ELSE TO_CHAR(GRP.TUMITATE_TANKA) " & vbCrLf
            sSQL += "  END TUMITATE_TANKA " & vbCrLf



            '-- 生産者積立金
            sSQL += " ,GRP.TUMITATE_KIN AS TUMITATE_KIN " & vbCrLf

            '-- 生産者積立金 合計
            'sSQL += " ,GRP.TUMITATE_KIN_SUM AS TUMITATE_KIN_SUM " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            sSQL += "     WHEN GRP.JIMUITAKU_CD = 9999 THEN SUM(GRP.TUMITATE_KIN) OVER (PARTITION BY GRP.KI,GRP.JIMUITAKU_CD,GRP.KEIYAKUSYA_CD ORDER BY GRP.KI,GRP.JIMUITAKU_CD,GRP.KEIYAKUSYA_CD) " & vbCrLf
            sSQL += "     WHEN GRP.KEIYAKUSYA_CD = 999999 THEN SUM(GRP.TUMITATE_KIN) OVER (PARTITION BY GRP.KI,GRP.JIMUITAKU_CD,GRP.KEIYAKUSYA_CD ORDER BY GRP.KI,GRP.JIMUITAKU_CD,GRP.KEIYAKUSYA_CD) " & vbCrLf
            sSQL += "     ELSE GRP.TUMITATE_KIN_SUM " & vbCrLf
            sSQL += "  END TUMITATE_KIN_SUM " & vbCrLf

            '-- 事務手数料 合計
            'sSQL += " ,GRP.JIMU_TESURRYO_SUM AS JIMU_TESURRYO_SUM " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            sSQL += "     WHEN GRP.JIMUITAKU_CD = 9999 THEN SUM(DISTINCT GRP.JIMU_TESURRYO_SUM) OVER (PARTITION BY GRP.KI) " & vbCrLf
            sSQL += "     WHEN GRP.KEIYAKUSYA_CD = 999999 THEN SUM(DISTINCT GRP.JIMU_TESURRYO_SUM) OVER (PARTITION BY GRP.KI,GRP.JIMUITAKU_CD) " & vbCrLf
            sSQL += "     ELSE GRP.JIMU_TESURRYO_SUM " & vbCrLf
            sSQL += "  END JIMU_TESURRYO_SUM " & vbCrLf


            '-- 手数料率
            sSQL += " ,GRP.TESURYO_RITU AS TESURYO_RITU " & vbCrLf

            '-- 契約者数
            sSQL += " ,CASE " & vbCrLf
            sSQL += "    WHEN GRP.JIMUITAKU_CD = 9999 THEN '合計(' || KEIYAKUSYA_CNT_ALL || ')人' " & vbCrLf
            sSQL += "    WHEN GRP.KEIYAKUSYA_CD = 999999 THEN '合計(' || KEIYAKUSYA_CNT_ITK || ')人' " & vbCrLf
            sSQL += "    ELSE '合計' " & vbCrLf
            sSQL += "  END KEIYAKUSYA_CNT " & vbCrLf

            '#32 ADD START
            '-- 事務手数料
            sSQL += " ,CASE"
            sSQL += "    WHEN GRP.KEIYAKUSYA_CD < 999999 and GRP.TORI_KBN_CNT = 1 THEN GRP.JIMU_TESURRYO_SUM"
            sSQL += "    ELSE NULL"
            sSQL += "  END JIMU_TESURRYO"
            '-- 納付金
            sSQL += " ,CASE"
            sSQL += "    WHEN GRP.KEIYAKUSYA_CD < 999999 and GRP.TORI_KBN_CNT = 1 THEN GRP.JIMU_TESURRYO_SUM + GRP.TUMITATE_KIN_SUM"
            sSQL += "    ELSE NULL"
            sSQL += "  END NOFU_KIN"
            '#32 ADD END



            'FROM
            sSQL += " FROM " & vbCrLf
            '-- 集計(事務委託先別、総合計)
            sSQL += "    ( " & vbCrLf
            sSQL += "    SELECT " & vbCrLf
            sSQL += "         MAX(DTL.KI) AS KI " & vbCrLf
            sSQL += "        ,GROUPING_ID(DTL.ROW_NUM,DTL.KI,DTL.JIMUITAKU_CD,DTL.TORI_KBN) AS GRPID " & vbCrLf
            sSQL += "        ,CASE " & vbCrLf
            sSQL += "            WHEN GROUPING_ID(DTL.ROW_NUM,DTL.KI,DTL.JIMUITAKU_CD,DTL.TORI_KBN) = 10 THEN 9999 " & vbCrLf
            sSQL += "            ELSE MAX(DTL.JIMUITAKU_CD) " & vbCrLf
            sSQL += "         END JIMUITAKU_CD " & vbCrLf
            sSQL += "        ,CASE " & vbCrLf
            sSQL += "            WHEN GROUPING_ID(DTL.ROW_NUM,DTL.KI,DTL.JIMUITAKU_CD,DTL.TORI_KBN) = 8 THEN 999999 " & vbCrLf
            sSQL += "            WHEN GROUPING_ID(DTL.ROW_NUM,DTL.KI,DTL.JIMUITAKU_CD,DTL.TORI_KBN) = 10 THEN 999999 " & vbCrLf
            sSQL += "            ELSE MAX(DTL.KEIYAKUSYA_CD) " & vbCrLf
            sSQL += "         END KEIYAKUSYA_CD " & vbCrLf
            sSQL += "        ,MAX(DTL.TORI_KBN) AS TORI_KBN " & vbCrLf
            sSQL += "        ,MAX(DTL.NOJO_CNT) AS NOJO_CNT " & vbCrLf
            sSQL += "        ,MAX(DTL.NOJO_CNT_KEI) AS NOJO_CNT_KEI " & vbCrLf
            sSQL += "        ,MAX(DTL.TORI_KBN_CNT) AS TORI_KBN_CNT " & vbCrLf
            sSQL += "        ,SUM(DTL.KEIYAKU_HASU) AS KEIYAKU_HASU " & vbCrLf
            sSQL += "        ,MAX(DTL.TUMITATE_TANKA) AS TUMITATE_TANKA " & vbCrLf
            sSQL += "        ,SUM(DTL.TUMITATE_KIN) AS TUMITATE_KIN " & vbCrLf
            sSQL += "        ,MAX(DTL.TUMITATE_KIN_SUM) AS TUMITATE_KIN_SUM " & vbCrLf
            sSQL += "        ,MAX(DTL.JIMU_TESURRYO_SUM) AS JIMU_TESURRYO_SUM " & vbCrLf
            sSQL += "        ,MAX(DTL.TESURYO_RITU) AS TESURYO_RITU " & vbCrLf
            sSQL += "        ,MAX(DTL.KEIYAKUSYA_CNT_ITK) AS KEIYAKUSYA_CNT_ITK " & vbCrLf
            sSQL += "        ,MAX(DTL.KEIYAKUSYA_CNT_ALL) AS KEIYAKUSYA_CNT_ALL " & vbCrLf
            sSQL += "    FROM " & vbCrLf
            sSQL += "       ( " & vbCrLf
            sSQL += "       SELECT " & vbCrLf
            sSQL += "           ROWNUM AS ROW_NUM " & vbCrLf
            sSQL += "          ,KI " & vbCrLf
            sSQL += "          ,JIMUITAKU_CD " & vbCrLf
            sSQL += "          ,KEIYAKUSYA_CD " & vbCrLf
            sSQL += "          ,TORI_KBN " & vbCrLf
            sSQL += "          ,NOJO_CNT " & vbCrLf
            sSQL += "          ,NOJO_CNT_KEI " & vbCrLf
            sSQL += "          ,TORI_KBN_CNT " & vbCrLf
            sSQL += "          ,KEIYAKU_HASU " & vbCrLf
            sSQL += "          ,TUMITATE_TANKA " & vbCrLf
            sSQL += "          ,TUMITATE_KIN " & vbCrLf
            '-- 積立金の合計
            sSQL += "          ,TUMITATE_KIN_SUM " & vbCrLf
            '-- 積立金の手数料
            sSQL += "          ,CASE " & vbCrLf
            sSQL += "              WHEN JIMU_TESURRYO_SUM = JIMU_TESURRYO_SUM_TES THEN JIMU_TESURRYO_SUM " & vbCrLf
            sSQL += "              ELSE SUM(JIMU_TESURRYO_SUM_TES) OVER (PARTITION BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD ORDER BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD) " & vbCrLf
            sSQL += "           END JIMU_TESURRYO_SUM " & vbCrLf
            sSQL += "          ,TESURYO_RITU " & vbCrLf
            sSQL += "          ,KEIYAKUSYA_CNT_ITK " & vbCrLf
            sSQL += "          ,KEIYAKUSYA_CNT_ALL " & vbCrLf
            sSQL += "       FROM " & vbCrLf
            sSQL += "          ( " & vbCrLf
            sSQL += "          SELECT " & vbCrLf
            sSQL += "               KI " & vbCrLf
            sSQL += "              ,JIMUITAKU_CD " & vbCrLf
            sSQL += "              ,KEIYAKUSYA_CD " & vbCrLf
            sSQL += "              ,TORI_KBN " & vbCrLf
            sSQL += "              ,NOJO_CNT " & vbCrLf
            sSQL += "              ,SUM(NOJO_CNT) OVER (PARTITION BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD ORDER BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD) AS NOJO_CNT_KEI " & vbCrLf
            sSQL += "              ,TORI_KBN_CNT " & vbCrLf
            sSQL += "              ,KEIYAKU_HASU " & vbCrLf
            sSQL += "              ,TUMITATE_TANKA " & vbCrLf
            sSQL += "              ,TUMITATE_KIN " & vbCrLf
            ' 	                    --積立金の合計
            sSQL += "              ,SUM(TUMITATE_KIN) OVER (PARTITION BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD ORDER BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD) AS TUMITATE_KIN_SUM " & vbCrLf
            '↓2018/07/03 修正
            '' 	                    --積立金の手数料
            'sSQL += "              ,TRUNC(SUM(TUMITATE_KIN) OVER (PARTITION BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD ORDER BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD) * (TESURYO_RITU / 100),-2) AS JIMU_TESURRYO_SUM " & vbCrLf
            '' 	                    --手数料率別の手数料
            'sSQL += "              ,TRUNC(SUM(TUMITATE_KIN) OVER (PARTITION BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD,TESURYO_RITU ORDER BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD,KEIYAKUSYA_CD,TESURYO_RITU) * (TESURYO_RITU / 100),-2) AS JIMU_TESURRYO_SUM_TES " & vbCrLf
            ' 	                    --積立金の手数料
            sSQL += "              ,CASE WHEN TRUNC(SUM(TUMITATE_KIN) OVER (PARTITION BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD ORDER BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD) * (TESURYO_RITU / 100),-2) = 0 THEN 100  " & vbCrLf
            sSQL += "                    ELSE TRUNC(SUM(TUMITATE_KIN) OVER (PARTITION BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD ORDER BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD) * (TESURYO_RITU / 100),-2) END AS JIMU_TESURRYO_SUM " & vbCrLf
            ' 	                    --手数料率別の手数料
            sSQL += "              ,CASE WHEN TRUNC(SUM(TUMITATE_KIN) OVER (PARTITION BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD,TESURYO_RITU ORDER BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD,KEIYAKUSYA_CD,TESURYO_RITU) * (TESURYO_RITU / 100),-2) = 0 THEN 100 " & vbCrLf
            sSQL += "                    ELSE TRUNC(SUM(TUMITATE_KIN) OVER (PARTITION BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD,TESURYO_RITU ORDER BY KI,JIMUITAKU_CD,KEIYAKUSYA_CD,KEIYAKUSYA_CD,TESURYO_RITU) * (TESURYO_RITU / 100),-2) END AS JIMU_TESURRYO_SUM_TES " & vbCrLf
            '↑2018/07/03 修正
            sSQL += "              ,TESURYO_RITU " & vbCrLf
            sSQL += "              ,COUNT(DISTINCT KEIYAKUSYA_CD) OVER (PARTITION BY JIMUITAKU_CD) AS KEIYAKUSYA_CNT_ITK " & vbCrLf
            sSQL += "              ,COUNT(DISTINCT KEIYAKUSYA_CD) OVER (PARTITION BY KI) AS KEIYAKUSYA_CNT_ALL " & vbCrLf
            sSQL += "          FROM " & vbCrLf
            sSQL += "             ( " & vbCrLf
            sSQL += "             SELECT " & vbCrLf
            '                          -- 事務委託先
            sSQL += "                  KEI.JIMUITAKU_CD AS JIMUITAKU_CD " & vbCrLf
            '                          -- 期
            sSQL += "                 ,KEIJOHO.KI AS KI " & vbCrLf
            '                          -- 契約者
            sSQL += "                 ,KEIJOHO.KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
            '                          -- 鶏の種類区分
            sSQL += "                 ,KEIJOHO.TORI_KBN AS TORI_KBN " & vbCrLf
            '                          -- 農場件数
            sSQL += "                 ,COUNT(KEIJOHO.NOJO_CD) AS NOJO_CNT " & vbCrLf
            '                          -- 鶏の種類区分の件数
            sSQL += "                 ,COUNT(DISTINCT KEIJOHO.TORI_KBN) OVER (PARTITION BY KEIJOHO.KI,KEI.JIMUITAKU_CD,KEIJOHO.KEIYAKUSYA_CD) AS TORI_KBN_CNT " & vbCrLf
            '                          -- 羽数合計
            sSQL += "                 ,SUM(KEIJOHO.KEIYAKU_HASU) AS KEIYAKU_HASU " & vbCrLf
            '                          -- 単価
            sSQL += "                 ,TAN.TUMITATE_TANKA AS TUMITATE_TANKA " & vbCrLf
            '                          -- 生産者積立金
            '2015/12/22　修正開始
            'sSQL += "                 ,CASE " & vbCrLf
            'sSQL += "                     WHEN KEIJOHO.TORI_KBN = 6 THEN CEIL((SUM(KEIJOHO.KEIYAKU_HASU) / 5) * TAN.TUMITATE_TANKA) " & vbCrLf
            'sSQL += "                     ELSE CEIL(SUM(KEIJOHO.KEIYAKU_HASU) * TAN.TUMITATE_TANKA) " & vbCrLf
            'sSQL += "                  END TUMITATE_KIN " & vbCrLf
            sSQL += "                  ,CEIL(SUM(KEIJOHO.KEIYAKU_HASU) * TAN.TUMITATE_TANKA) TUMITATE_KIN" & vbCrLf
            '2015/12/22　修正終了
            '                          -- 手数料
            sSQL += "                 ,TES.TESURYO_RITU AS TESURYO_RITU " & vbCrLf
            sSQL += "             FROM TT_KEIYAKU_JOHO KEIJOHO" & vbCrLf
            sSQL += "                 ,TM_KEIYAKU KEI " & vbCrLf
            sSQL += "                 ,TM_TANKA TAN " & vbCrLf
            sSQL += "                 ,TM_TANKA TES " & vbCrLf
            sSQL += "             WHERE " & vbCrLf
            '                          -- 契約者マスタ
            sSQL += "                  KEIJOHO.KI = KEI.KI(+) " & vbCrLf
            sSQL += "              AND KEIJOHO.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+) " & vbCrLf
            '                          -- 単価マスタ
            sSQL += "              AND KEIJOHO.KEIYAKU_KBN = TAN.KEIYAKU_KBN(+) " & vbCrLf
            sSQL += "              AND KEIJOHO.TORI_KBN = TAN.TORI_KBN(+) " & vbCrLf
            sSQL += "              AND KEIJOHO.KEIYAKU_DATE_FROM BETWEEN TAN.TAISYO_DATE_FROM AND TAN.TAISYO_DATE_TO " & vbCrLf
            '                          -- 手数料
            sSQL += "              AND 9 = TES.KEIYAKU_KBN " & vbCrLf
            sSQL += "              AND 9 = TES.TORI_KBN " & vbCrLf
            sSQL += "              AND KEIJOHO.KEIYAKU_DATE_FROM BETWEEN TES.TAISYO_DATE_FROM AND TES.TAISYO_DATE_TO " & vbCrLf
            '                          -- 条件(有効フラグ)
            sSQL += "              AND KEIJOHO.DATA_FLG = 1 " & vbCrLf
            '                          -- 期条件
            sSQL += "              AND KEIJOHO.KI = " & numKI.Value & vbCrLf

            ''==必須条件=======================
            '契約状況
            strChekVal = ""
            If chkSINKI.Checked And chkKEIZOKU.Checked And chkCYUSI.Checked Then
                '全チェック
            Else
                '新規契約者
                If chkSINKI.Checked Then
                    strChekVal = "1"
                End If
                '継続契約者
                If chkKEIZOKU.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "2"
                    Else
                        strChekVal += ",2"
                    End If
                End If
                '中止者
                If chkCYUSI.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "3"
                    Else
                        strChekVal += ",3"
                    End If
                End If
                'SQL作成
                If strChekVal.Length > 0 Then
                    sSQL += "              AND KEI.KEIYAKU_JYOKYO IN( " & strChekVal & ")" & vbCrLf
                End If
            End If

            '入力状況
            strChekVal = ""
            If chkNYURYOKU_CYU.Checked And chkNYURYOKU_KAKUTEI.Checked Then
                '全チェック
            Else
                '入力中
                If chkNYURYOKU_CYU.Checked Then
                    strChekVal = "1"
                End If
                '入力確定
                If chkNYURYOKU_KAKUTEI.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "2"
                    Else
                        strChekVal += ",2"
                    End If
                End If
                'SQL作成
                If strChekVal.Length > 0 Then
                    sSQL += "              AND KEI.NYURYOKU_JYOKYO IN( " & strChekVal & ")" & vbCrLf
                End If
            End If



            '==任意条件=======================
            '契約区分FROMTO
            If cboKEIYAKU_KBN_Cd_Fm.Text <> "" Then
                sSQL += "              AND KEI.KEIYAKU_KBN BETWEEN " & cboKEIYAKU_KBN_Cd_Fm.Text & " and " & cboKEIYAKU_KBN_Cd_To.Text & vbCrLf
            End If

            '都道府県FROMTO
            If cboKEN_Cd_Fm.Text <> "" Then
                '2021/06/28 JBD9020 R03年度追加基金対応 既存バグ修正 UPD START
                'sSQL += "              AND KEI.KEN_CD BETWEEN " & cboKEN_Cd_Fm.Text & " and " & cboKEN_Cd_Fm.Text & vbCrLf
                sSQL += "              AND KEI.KEN_CD BETWEEN " & cboKEN_Cd_Fm.Text & " and " & cboKEN_Cd_To.Text & vbCrLf
                '2021/06/28 JBD9020 UPD START
            End If

            '事務委託先FROMTO
            If cboITAKU_Cd_Fm.Text <> "" Then
                sSQL += "              AND KEI.JIMUITAKU_CD BETWEEN " & cboITAKU_Cd_Fm.Text & " and " & cboITAKU_Cd_To.Text & vbCrLf
            End If

            '契約者FROMTO
            If cboKEIYAKUSYA_Cd_Fm.Text <> "" Then
                sSQL += "              AND KEI.KEIYAKUSYA_CD BETWEEN " & cboKEIYAKUSYA_Cd_Fm.Text & " and " & cboKEIYAKUSYA_Cd_To.Text & vbCrLf
            End If
            sSQL += "            GROUP BY " & vbCrLf
            sSQL += "                KEI.JIMUITAKU_CD " & vbCrLf
            sSQL += "               ,KEIJOHO.KI " & vbCrLf
            sSQL += "               ,KEIJOHO.KEIYAKUSYA_CD " & vbCrLf
            sSQL += "               ,KEIJOHO.KEIYAKU_KBN " & vbCrLf
            sSQL += "               ,KEIJOHO.TORI_KBN " & vbCrLf
            sSQL += "               ,TAN.TUMITATE_TANKA " & vbCrLf
            sSQL += "               ,TES.TESURYO_RITU " & vbCrLf
            sSQL += "            ORDER BY " & vbCrLf
            sSQL += "                KEIJOHO.KI " & vbCrLf
            sSQL += "               ,KEI.JIMUITAKU_CD " & vbCrLf
            sSQL += "               ,KEIJOHO.KEIYAKUSYA_CD " & vbCrLf
            sSQL += "               ,KEIJOHO.TORI_KBN " & vbCrLf
            sSQL += "            ) " & vbCrLf
            sSQL += "         ) " & vbCrLf
            sSQL += "      ORDER BY " & vbCrLf
            sSQL += "          KI " & vbCrLf
            sSQL += "         ,JIMUITAKU_CD " & vbCrLf
            sSQL += "         ,KEIYAKUSYA_CD " & vbCrLf
            sSQL += "         ,TORI_KBN " & vbCrLf
            sSQL += "      ) DTL " & vbCrLf
            sSQL += "    GROUP BY " & vbCrLf
            sSQL += "      GROUPING SETS( " & vbCrLf
            '            -- 事務委託先計(事務委託先別、鶏の種類別)
            sSQL += "         (DTL.KI,DTL.JIMUITAKU_CD,DTL.TORI_KBN) " & vbCrLf
            '            -- 明細
            sSQL += "        ,(DTL.ROW_NUM) " & vbCrLf
            '            -- 総合計（期別、鶏の種類別）
            sSQL += "        ,(DTL.KI,DTL.TORI_KBN) " & vbCrLf
            sSQL += "        ) " & vbCrLf
            sSQL += "    ORDER BY " & vbCrLf
            sSQL += "        KI " & vbCrLf
            sSQL += "       ,JIMUITAKU_CD " & vbCrLf
            sSQL += "       ,KEIYAKUSYA_CD " & vbCrLf
            sSQL += "       ,TORI_KBN " & vbCrLf
            sSQL += "    ) GRP " & vbCrLf
            sSQL += "    ,TM_KEIYAKU KEI " & vbCrLf
            sSQL += "    ,TM_JIMUITAKU JIM " & vbCrLf
            sSQL += "    ,TM_CODE CD01 " & vbCrLf
            sSQL += "    ,TM_CODE CD02 " & vbCrLf
            sSQL += "    ,TM_CODE CD12 " & vbCrLf
            sSQL += "    ,TM_CODE CD07 " & vbCrLf
            sSQL += "    ,TM_CODE CD05 " & vbCrLf

            'WHERE
            sSQL += " WHERE " & vbCrLf
            '-- 契約者マスタ
            sSQL += "      GRP.KI = KEI.KI(+) " & vbCrLf
            sSQL += "  AND GRP.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+) " & vbCrLf
            sSQL += "  AND GRP.JIMUITAKU_CD = KEI.JIMUITAKU_CD(+) " & vbCrLf
            '-- 事務委託先
            sSQL += "  AND GRP.KI = JIM.KI(+) " & vbCrLf
            sSQL += "  AND GRP.JIMUITAKU_CD = JIM.ITAKU_CD(+) " & vbCrLf
            '-- 入力状況
            sSQL += "  AND 12 = CD12.SYURUI_KBN(+) " & vbCrLf
            sSQL += "  AND KEI.NYURYOKU_JYOKYO = CD12.MEISYO_CD(+) " & vbCrLf
            '-- 契約区分
            sSQL += "  AND 1 = CD01.SYURUI_KBN(+) " & vbCrLf
            sSQL += "  AND KEI.KEIYAKU_KBN = CD01.MEISYO_CD(+) " & vbCrLf
            '-- 契約状況
            sSQL += "  AND 2 = CD02.SYURUI_KBN(+) " & vbCrLf
            sSQL += "  AND KEI.KEIYAKU_JYOKYO = CD02.MEISYO_CD(+) " & vbCrLf
            '-- 鶏の種類
            sSQL += "  AND 7 = CD07.SYURUI_KBN(+) " & vbCrLf
            sSQL += "  AND GRP.TORI_KBN = CD07.MEISYO_CD(+) " & vbCrLf
            '-- 都道府県
            sSQL += "  AND 5 = CD05.SYURUI_KBN(+) " & vbCrLf
            sSQL += "  AND KEI.KEN_CD = CD05.MEISYO_CD(+) " & vbCrLf
            '2021/04/13 JBD9020 R03年度追加基金対応 UPD START
            'sSQL += "    ,GRP.JIMUITAKU_CD " & vbCrLf
            If rdoSEISANSYA.Checked Then
                'sSQL += "  AND NOT (GRP.JIMUITAKU_CD = '9999' AND GRP.KEIYAKUSYA_CD = '999999')" & vbCrLf
                sSQL += "  AND (GRP.JIMUITAKU_CD = '9999' OR GRP.KEIYAKUSYA_CD <> '999999')" & vbCrLf
            End If

            'ORDER BY
            sSQL += " ORDER BY " & vbCrLf
            sSQL += "     GRP.KI " & vbCrLf
            '2021/04/13 JBD9020 R03年度追加基金対応 UPD START
            'sSQL += "    ,GRP.JIMUITAKU_CD " & vbCrLf
            If rdoJIMUITAKU.Checked Then
                sSQL += "    ,GRP.JIMUITAKU_CD " & vbCrLf
            End If
            '2021/04/13 JBD9020 R03年度追加基金対応 UPD END
            sSQL += "    ,GRP.KEIYAKUSYA_CD " & vbCrLf
            sSQL += "    ,GRP.TORI_KBN " & vbCrLf


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
            'pJump = False      '2015/03/03 JBD368 DEL コンボボックス設定までTRUEにしておく
            '#005 修正END

            'コンボセット
            If wKbn = "C" Then
                f_ComboBox_Set(wKbn)
            End If

            pJump = False       '2015/03/03 JBD368 ADD

            '画面変更フラグ
            'pblnTextChange = False R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL

            rdoSEISANSYA.Checked = True '2021/04/13 JBD9020 R03年度追加基金対応 

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
            pJump = True    '2015/03/04 JBD368 ADD

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
                '事務委託先
                '--------------------
                sWhere = "KI = " & numKI.Text
                'FROM
                If Not f_JimuItaku_Data_Select(cboITAKU_Cd_Fm, cboITAKU_Nm_Fm, sWhere, True) Then
                    Exit Try
                End If
                'FROM
                If Not f_JimuItaku_Data_Select(cboITAKU_Cd_To, cboITAKU_Nm_To, sWhere, True) Then
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

                cboKEN_Cd_Fm.Text = ""
                cboKEN_Cd_To.Text = ""

                cboITAKU_Cd_Fm.Text = ""
                cboITAKU_Cd_To.Text = ""

                cboKEIYAKUSYA_Cd_Fm.Text = ""
                cboKEIYAKUSYA_Cd_To.Text = ""

            End If

            If wKbn = "K" Then
                '--------------------
                '事務委託先
                '--------------------
                sWhere = "KI = " & numKI.Text
                'FROM
                If Not f_JimuItaku_Data_Select(cboITAKU_Cd_Fm, cboITAKU_Nm_Fm, sWhere, True) Then
                    Exit Try
                End If
                'FROM
                If Not f_JimuItaku_Data_Select(cboITAKU_Cd_To, cboITAKU_Nm_To, sWhere, True) Then
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
                cboITAKU_Cd_Fm.Text = ""
                cboITAKU_Cd_To.Text = ""

                cboKEIYAKUSYA_Cd_Fm.Text = ""
                cboKEIYAKUSYA_Cd_To.Text = ""

            End If

            pJump = False    '2015/03/04 JBD368 ADD

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
            '契約状況
            chkSINKI.Checked = True
            chkKEIZOKU.Checked = True
            chkCYUSI.Checked = True
            '入力状況
            chkNYURYOKU_CYU.Checked = True
            chkNYURYOKU_KAKUTEI.Checked = True

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

            wkControlName = "契約状況"
            If chkSINKI.Checked = True Or chkKEIZOKU.Checked = True Or chkCYUSI.Checked = True Then
                '何もしない
            Else
                Call Show_MessageBox_Add("W008", wkControlName) : chkSINKI.Focus() : Exit Try
            End If
            wkControlName = "入力状況"
            If chkNYURYOKU_CYU.Checked = True Or chkNYURYOKU_KAKUTEI.Checked = True Then
                '何もしない
            Else
                Call Show_MessageBox_Add("W008", wkControlName) : chkNYURYOKU_CYU.Focus() : Exit Try
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

            '都道府県
            If f_Daisyo_Check(cboKEN_Cd_Fm, cboKEN_Cd_To, "都道府県", True, 1) = False Then
                Return False
            End If

            '事務委託先
            If f_Daisyo_Check(cboITAKU_Cd_Fm, cboITAKU_Cd_To, "事務委託先", True, 1) = False Then
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
