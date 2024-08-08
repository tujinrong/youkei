'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ1040.vb
'*
'*　　②　機能概要　　　　　契約者別契約情報入力確認チェックリスト作成処理(農場別等)
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



Public Class frmGJ1040

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
    Private Const con_ReportName As String = "契約者別契約情報入力確認チェックリスト(農場別等)"

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

#Region "入力者FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboUSER_Cd_Fm_SelectedIndexChanged
    '説明            :入力者コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboUSER_Cd_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboUSER_Cd_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboUSER_Nm_Fm.SelectedIndex = cboUSER_Cd_Fm.SelectedIndex
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboUSER_Nm_Fm_SelectedIndexChanged
    '説明            :入力者FromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboUSER_Nm_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboUSER_Nm_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiFrom_SelectedIndexChanged(cboUSER_Nm_Fm, cboUSER_Cd_Fm, cboUSER_Nm_To, cboUSER_Cd_To)
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboUSER_Cd_Fm_Validating
    '説明            :入力者コードFromValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboUSER_Cd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboUSER_Cd_Fm.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call user_CboFrom_Validating(cboUSER_Cd_Fm, cboUSER_Nm_Fm, cboUSER_Cd_To, cboUSER_Nm_To)
        'Call s_CboFrom_Validating(cboUSER_Cd_Fm, cboUSER_Nm_Fm, cboUSER_Cd_To, cboUSER_Nm_To)

    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cboUSER_Cd_To_SelectedIndexChanged
    '説明            :入力者コードToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboUSER_Cd_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboUSER_Cd_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboUSER_Nm_To.SelectedIndex = cboUSER_Cd_To.SelectedIndex
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboUSER_Nm_To_SelectedIndexChanged
    '説明            :入力者ToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboUSER_Nm_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboUSER_Nm_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiTo_Validating(cboUSER_Nm_To, cboUSER_Cd_To, cboUSER_Nm_Fm, cboUSER_Cd_Fm)
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboUSER_Cd_To_Validating
    '説明            :入力者コードToValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboUSER_Cd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboUSER_Cd_To.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        'Call s_CboTo_Validating(cboUSER_Cd_To, cboUSER_Nm_To, cboUSER_Cd_Fm, cboUSER_Nm_Fm)
        Call user_CboTo_Validating(cboUSER_Cd_To, cboUSER_Nm_To, cboUSER_Cd_Fm, cboUSER_Nm_Fm)
    End Sub
#End Region

#Region "契約日"
    '------------------------------------------------------------------
    'プロシージャ名  :dateNYUKIN_Ymd_From_Validating
    '説明            :入金・返還日FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '2021/07/06 JBD9020 新契約日追加 ADD
    '------------------------------------------------------------------
    Private Sub dateKEIYAKU_Ymd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateKEIYAKU_Ymd_Fm.Validating

        Call s_From_Validating(dateKEIYAKU_Ymd_Fm, dateKEIYAKU_Ymd_To)

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
            'R05年度　OSバージョンアップ　既存バグ修正のため変更 DEL END
            ret = f_ObjectClear("")
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
#Region "処理区分　Changeイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :rdo_HANI_CheckedChanged　2018/07/20 追加
    '説明            :範囲　Changeイベント
    '------------------------------------------------------------------
    Private Sub rdo_HANI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTOROKU_HANI.CheckedChanged, rdoKOSHIN_HANI.CheckedChanged
        If rdoTOROKU_HANI.Checked Then
            dateNYURYOKU_Ymd_Fm.Enabled = True
            dateNYURYOKU_Ymd_To.Enabled = True
            dateKOSHIN_Ymd_Fm.Enabled = False
            dateKOSHIN_Ymd_To.Enabled = False
        Else
            dateNYURYOKU_Ymd_Fm.Enabled = False
            dateNYURYOKU_Ymd_To.Enabled = False
            dateKOSHIN_Ymd_Fm.Enabled = True
            dateKOSHIN_Ymd_To.Enabled = True
        End If
    End Sub
#End Region
#Region "契約日入力あり　Changeイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :chkKEIYAKUDATEARI_CheckedChanged
    '説明            :契約日入力のみ　Changeイベント
    '2021/07/06 JBD9020 金融機関情報追加 ADD
    '------------------------------------------------------------------
    Private Sub chkKEIYAKUDATEARI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKEIYAKUDATEARI.CheckedChanged
        If chkKEIYAKUDATEARI.Checked Then
            dateKEIYAKU_Ymd_Fm.Enabled = True
            dateKEIYAKU_Ymd_To.Enabled = True
        Else
            dateKEIYAKU_Ymd_Fm.Enabled = False
            dateKEIYAKU_Ymd_To.Enabled = False
            dateKEIYAKU_Ymd_Fm.Value = Nothing
            dateKEIYAKU_Ymd_To.Value = Nothing
        End If
    End Sub
#End Region
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
        Dim wkKbn As Integer = 0  '0:入力者別,1:契約者別

        Try
            ''--------------------------------------------------
            ''データ取得
            ''--------------------------------------------------
            wkDSRep.Tables.Add(con_ReportName)

            '入力者範囲判定
            If cboUSER_Nm_Fm.Text <> "" Then
                '入力者別
                wkKbn = 0
            Else
                '契約番号
                wkKbn = 1
            End If

            'SQL
            If Not f_make_SQL(wkKbn, wkSql) Then
                Exit Try
            End If

            Debug.Print(wkSql)

            'データ取得
            Using wkAdp As New OracleDataAdapter(wkSql, Cnn)
                wkAdp.Fill(wkDSRep, wkDSRep.Tables(0).TableName)
            End Using

            If wkDSRep.Tables(0).Rows.Count > 0 Then
                Dim w As New rptGJ1040
                w.sub1(wkDSRep, wkKbn)
                'Using wkAR As New rptGJ1040

                '    '入力者範囲
                'If wkKbn = 0 Then
                '        '入力者別
                '        wkAR.USER_NAME_HED.Visible = True
                '    Else
                '        '契約番号
                '        wkAR.USER_NAME_HED.Visible = False
                '    End If

                '    'ヘッダ用の値を保管
                '    wkAR.pKIKIN2 = pKikin2      '2017/07/14　追加
                '    ' 用紙サイズを B4横 に設定します。
                '    wkAR.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.B4
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

        '#27 ADD START
        Dim sKaishiNen As String
        Dim sSyuryoNen As String
        '#27 ADD END


        Try
            '対象期・年度の取得
            Dim SyoriKI = New Obj_TM_SYORI_NENDO_KI()

            '#27 ADD START
            '期の開始年と終了年の算出
            sKaishiNen = ((numKI.Value - 6) * 3) + 2015 & "/04/01"
            sSyuryoNen = ((numKI.Value - 6) * 3) + 2015 + 2 & "/03/31"
            '#27 ADD END

            sSQL = " SELECT " & vbCrLf
            sSQL += "   TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI " & vbCrLf
            '-- 対象期間
            '#27 ADD START
            sSQL += " ,'対象期：第" & numKI.Value & "期（' || TO_CHAR(TO_DATE('" & sKaishiNen & "'), '""""EEYY""年度～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & sSyuryoNen & "'), '""""EEYY""年度）""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS TAISYO_KI " & vbCrLf
            '#27 ADD END

            '↓2018/07/20 修正
            '-- 入力期間
            'sSQL += " ,'(入力期間：' || TO_CHAR(TO_DATE('" & dateNYURYOKU_Ymd_Fm.Value & "'), 'EEYY""/""MM""/""DD""""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '～' || TO_CHAR(TO_DATE('" & dateNYURYOKU_Ymd_To.Value & "'), 'EEYY""/""MM""/""DD""""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '）' AS NYURYOKU_KIKAN " & vbCrLf
            ''sSQL += " ,TO_CHAR(TO_DATE('" & dateNYURYOKU_Ymd_Fm.Value & "'), 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS TAISYOBI" & vbCrLf
            If rdoTOROKU_HANI.Checked Then
                sSQL += " ,'(登録期間：' || TO_CHAR(TO_DATE('" & dateNYURYOKU_Ymd_Fm.Value & "'), 'EEYY""/""MM""/""DD""""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '～' || TO_CHAR(TO_DATE('" & dateNYURYOKU_Ymd_To.Value & "'), 'EEYY""/""MM""/""DD""""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '）' AS NYURYOKU_KIKAN " & vbCrLf
            Else
                sSQL += " ,'(更新期間：' || TO_CHAR(TO_DATE('" & dateKOSHIN_Ymd_Fm.Value & "'), 'EEYY""/""MM""/""DD""""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '～' || TO_CHAR(TO_DATE('" & dateKOSHIN_Ymd_To.Value & "'), 'EEYY""/""MM""/""DD""""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '）' AS NYURYOKU_KIKAN " & vbCrLf
            End If
            '↑2018/07/20 修正
            '-- 期
            sSQL += " ,KEI.KI AS KI" & vbCrLf
            '-- 契約番号
            sSQL += " ,KEI.KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
            '-- 契約者名
            sSQL += " ,KEI.KEIYAKUSYA_NAME AS KEIYAKUSYA_NAME " & vbCrLf
            '-- 代表者名
            sSQL += " ,KEI.DAIHYO_NAME AS DAIHYO_NAME " & vbCrLf
            '2021/07/06 JBD9020 金融機関情報追加 ADD START
            sSQL += " ,KEI.ADDR_TEL1 " & vbCrLf
            sSQL += " ,KEI.ADDR_TEL2 " & vbCrLf
            sSQL += " ,KEI.ADDR_FAX " & vbCrLf
            sSQL += " ,KEI.ADDR_E_MAIL " & vbCrLf

            sSQL += " ,TO_CHAR(KEI.KEIYAKU_DATE,'YYYY/MM/DD') AS KEIYAKU_DATE " & vbCrLf

            sSQL += " ,COUNT(1) OVER (PARTITION BY KEIJOHO.KI,KEIJOHO.KEIYAKUSYA_CD) ROW_CNT" & vbCrLf
            'R05年度 OSバージョンアップ　既存バグ修正のため変更 JBD453 2024/03/13 UPD START
            'sSQL += " ,ROW_NUMBER() OVER (PARTITION BY KEIJOHO.KI,KEIJOHO.KEIYAKUSYA_CD  ORDER BY KEIJOHO.KI,KEIJOHO.KEIYAKUSYA_CD,KEIJOHO.UP_DATE,KEIJOHO.TORI_KBN,NOJO.MEISAI_NO ) ROW_NUM" & vbCrLf
            If iKbn = 0 Then
                sSQL += " ,ROW_NUMBER() OVER (PARTITION BY KEIJOHO.UP_ID,KEIJOHO.KI,KEIJOHO.KEIYAKUSYA_CD  ORDER BY KEIJOHO.UP_ID,KEIJOHO.KI,KEIJOHO.KEIYAKUSYA_CD,KEIJOHO.UP_DATE,KEIJOHO.TORI_KBN,NOJO.MEISAI_NO ) ROW_NUM" & vbCrLf
            Else
                sSQL += " ,ROW_NUMBER() OVER (PARTITION BY KEIJOHO.KI,KEIJOHO.KEIYAKUSYA_CD  ORDER BY KEIJOHO.KI,KEIJOHO.KEIYAKUSYA_CD,KEIJOHO.UP_DATE,KEIJOHO.TORI_KBN,NOJO.MEISAI_NO ) ROW_NUM" & vbCrLf
            End If
            'R05年度 OSバージョンアップ　既存バグ修正のため変更 JBD453 2024/03/13 UPD END
            sSQL += " ,KEI.FURI_BANK_CD        || ' ' || BNK.BANK_NAME    AS BANK " & vbCrLf
            sSQL += " ,KEI.FURI_BANK_SITEN_CD  || ' ' || SIT.SITEN_NAME   AS SITEN " & vbCrLf
            sSQL += " ,M04.MEISYO || ' ' || KEI.FURI_KOZA_NO AS KOZA " & vbCrLf
            sSQL += " ,KEI.FURI_KOZA_MEIGI " & vbCrLf
            sSQL += " ,KEI.FURI_KOZA_MEIGI_KANA " & vbCrLf

            '2021/07/06 JBD9020 金融機関情報追加 ADD END
            '-- 入力状況
            sSQL += " ,KEI.NYURYOKU_JYOKYO AS NYURYOKU_JYOKYO " & vbCrLf
            sSQL += " ,CD12.MEISYO AS NYURYOKU_JYOKYO_NM " & vbCrLf
            '-- 契約区分
            sSQL += " ,KEI.KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
            '↓2017/07/12 修正 契約区分
            'sSQL += " ,CD01.RYAKUSYO AS KEIYAKU_KBN_NM " & vbCrLf
            sSQL += " ,CD01.MEISYO AS KEIYAKU_KBN_NM " & vbCrLf
            '↑2017/07/12 修正 契約区分
            '-- 契約状況
            sSQL += " ,KEI.KEIYAKU_JYOKYO AS KEIYAKU_JYOKYO " & vbCrLf
            sSQL += " ,CD02.RYAKUSYO AS KEIYAKU_JYOKYO_NM " & vbCrLf
            '-- 契約者所在地
            sSQL += " ,KEI.ADDR_1 || KEI.ADDR_2 || KEI.ADDR_3 || KEI.ADDR_4 AS KEI_ADDR " & vbCrLf
            '-- 鶏の種類
            sSQL += " ,KEIJOHO.TORI_KBN AS TORI_KBN " & vbCrLf
            sSQL += " ,CD07.MEISYO AS TORI_KBN_NM " & vbCrLf
            '-- 契約羽数
            sSQL += " ,KEIJOHO.KEIYAKU_HASU AS KEIYAKU_HASU " & vbCrLf
            '-- 農場名
            sSQL += " ,'(' || KEIJOHO.NOJO_CD || ')' || NOJO.NOJO_NAME AS NOJO_NAME " & vbCrLf
            '-- 農場所在地
            sSQL += " ,NOJO.ADDR_1 || NOJO.ADDR_2 || NOJO.ADDR_3 || NOJO.ADDR_4 AS NOJO_ADDR " & vbCrLf
            '-- 入力日
            'sSQL += " ,KEIJOHO.REG_DATE AS REG_DATE " & vbCrLf
            '↓2018/07/20 修正
            'sSQL += " ,KEIJOHO.UP_DATE AS REG_DATE " & vbCrLf
            sSQL += " ,KEIJOHO.REG_DATE AS REG_DATE " & vbCrLf
            sSQL += " ,KEIJOHO.UP_DATE AS UP_DATE " & vbCrLf
            '↑2018/07/20 修正
            'sSQL += " ,TO_CHAR(KEIJOHO.REG_DATE, 'MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS REG_DATE_MD " & vbCrLf

            '-- 入力者
            If iKbn = 0 Then
                '入力者別
                'sSQL += " ,KEIJOHO.REG_ID AS USER_ID " & vbCrLf
                sSQL += " ,KEIJOHO.UP_ID AS USER_ID " & vbCrLf
            Else
                '契約番号
                sSQL += " ,'all' AS USER_ID " & vbCrLf
            End If
            '↓2018/07/20 修正
            'sSQL += " ,'入力者：' || US.USER_NAME AS USER_NAME_HED " & vbCrLf
            'sSQL += " ,US.USER_NAME AS USER_NAME " & vbCrLf
            If rdoTOROKU_HANI.Checked Then
                sSQL += " ,'入力者：' || USREG.USER_NAME AS USER_NAME_HED " & vbCrLf
            Else
                sSQL += " ,'入力者：' || USUP.USER_NAME AS USER_NAME_HED " & vbCrLf
            End If
            sSQL += " ,USREG.USER_NAME AS REG_NAME " & vbCrLf
            sSQL += " ,USUP.USER_NAME AS UP_NAME " & vbCrLf
            '↑2018/07/20 修正
            'FROM
            sSQL += " FROM TT_KEIYAKU_JOHO KEIJOHO " & vbCrLf
            sSQL += "     ,TM_KEIYAKU KEI " & vbCrLf
            sSQL += "     ,TM_KEIYAKU_NOJO NOJO " & vbCrLf
            '↓2018/07/20 修正
            'sSQL += "     ,TM_USER US " & vbCrLf
            sSQL += "     ,TM_USER USREG " & vbCrLf
            sSQL += "     ,TM_USER USUP " & vbCrLf
            '↑2018/07/20 修正
            sSQL += "     ,TM_CODE CD01 " & vbCrLf
            sSQL += "     ,TM_CODE CD02 " & vbCrLf
            sSQL += "     ,TM_CODE CD12 " & vbCrLf
            sSQL += "     ,TM_CODE CD07 " & vbCrLf

            '2021/07/06 JBD9020 金融機関情報追加 ADD START
            sSQL += "     ,TM_BANK BNK" & vbCrLf
            sSQL += "     ,TM_SITEN SIT " & vbCrLf
            sSQL += "     ,TM_CODE M04 " & vbCrLf
            '2021/07/06 JBD9020 金融機関情報追加 ADD END

            'WHERE
            sSQL += " WHERE " & vbCrLf
            '-- 契約者マスタ
            sSQL += "      KEIJOHO.KI = KEI.KI(+) " & vbCrLf
            sSQL += "  And KEIJOHO.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+) " & vbCrLf
            '-- 契約者農場マスタ
            sSQL += "  And KEIJOHO.KI = NOJO.KI(+) " & vbCrLf
            sSQL += "  And KEIJOHO.KEIYAKUSYA_CD = NOJO.KEIYAKUSYA_CD(+) " & vbCrLf
            sSQL += "  And KEIJOHO.NOJO_CD = NOJO.NOJO_CD(+) " & vbCrLf
            '-- ユーザマスタ
            'sSQL += "  And KEIJOHO.REG_ID = US.USER_ID(+) " & vbCrLf
            '↓2018/07/20 修正
            'sSQL += "  And KEIJOHO.UP_ID = US.USER_ID(+) " & vbCrLf
            sSQL += "  And KEIJOHO.REG_ID = USREG.USER_ID(+) " & vbCrLf
            sSQL += "  And KEIJOHO.UP_ID = USUP.USER_ID(+) " & vbCrLf
            '↑2018/07/20 修正
            '-- 入力状況
            sSQL += "  And 12 = CD12.SYURUI_KBN(+) " & vbCrLf
            sSQL += "  And KEI.NYURYOKU_JYOKYO = CD12.MEISYO_CD(+) " & vbCrLf
            '-- 契約区分
            sSQL += "  And 1 = CD01.SYURUI_KBN(+) " & vbCrLf
            sSQL += "  And KEI.KEIYAKU_KBN = CD01.MEISYO_CD(+) " & vbCrLf
            '-- 契約状況
            sSQL += "  And 2 = CD02.SYURUI_KBN(+) " & vbCrLf
            sSQL += "  And KEI.KEIYAKU_JYOKYO = CD02.MEISYO_CD(+) " & vbCrLf
            '-- 鶏の種類
            sSQL += "  And 7 = CD07.SYURUI_KBN(+) " & vbCrLf
            sSQL += "  And KEIJOHO.TORI_KBN = CD07.MEISYO_CD(+) " & vbCrLf

            '2021/07/06 JBD9020 金融機関情報追加 ADD START
            '  --銀行
            sSQL += "  And KEI.FURI_BANK_CD = BNK.BANK_CD(+)"
            '  --支店
            sSQL += "  And KEI.FURI_BANK_CD = SIT.BANK_CD(+)"
            sSQL += "  And KEI.FURI_BANK_SITEN_CD = SIT.SITEN_CD(+)"
            '  --コードマスタ(口座)
            sSQL += "  AND 4 = M04.SYURUI_KBN(+)"
            sSQL += "  AND KEI.FURI_KOZA_SYUBETU = M04.MEISYO_CD(+)"
            '2021/07/06 JBD9020 金融機関情報追加 ADD END

            '最新
            sSQL += "    And KEIJOHO.DATA_FLG = 1 " & vbCrLf

            '==必須条件=======================
            '期
            sSQL += "    And KEIJOHO.KI = " & numKI.Value & vbCrLf

            '入力範囲FROMTO
            '↓2018/07/20 修正
            ''sSQL += "    And KEIJOHO.REG_DATE BETWEEN TO_DATE('" & Format(dateNYURYOKU_Ymd_Fm.Value, "yyyy/MM/dd 00:00:00") & "','YYYY/MM/DD HH24:MI:SS') and TO_DATE('" & Format(dateNYURYOKU_Ymd_To.Value, "yyyy/MM/dd 23:59:59") & "','YYYY/MM/DD HH24:MI:SS') " & vbCrLf
            'sSQL += "    AND KEIJOHO.UP_DATE BETWEEN TO_DATE('" & Format(dateNYURYOKU_Ymd_Fm.Value, "yyyy/MM/dd 00:00:00") & "','YYYY/MM/DD HH24:MI:SS') and TO_DATE('" & Format(dateNYURYOKU_Ymd_To.Value, "yyyy/MM/dd 23:59:59") & "','YYYY/MM/DD HH24:MI:SS') " & vbCrLf
            If rdoTOROKU_HANI.Checked Then
                sSQL += "    AND KEIJOHO.REG_DATE BETWEEN TO_DATE('" & Format(dateNYURYOKU_Ymd_Fm.Value, "yyyy/MM/dd 00:00:00") & "','YYYY/MM/DD HH24:MI:SS') and TO_DATE('" & Format(dateNYURYOKU_Ymd_To.Value, "yyyy/MM/dd 23:59:59") & "','YYYY/MM/DD HH24:MI:SS') " & vbCrLf
            Else
                sSQL += "    AND KEIJOHO.UP_DATE BETWEEN TO_DATE('" & Format(dateKOSHIN_Ymd_Fm.Value, "yyyy/MM/dd 00:00:00") & "','YYYY/MM/DD HH24:MI:SS') and TO_DATE('" & Format(dateKOSHIN_Ymd_To.Value, "yyyy/MM/dd 23:59:59") & "','YYYY/MM/DD HH24:MI:SS') " & vbCrLf
            End If
            '↑2018/07/20 修正

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
                    sSQL += "    AND KEI.KEIYAKU_JYOKYO IN( " & strChekVal & ")" & vbCrLf
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
                    sSQL += "    AND KEI.NYURYOKU_JYOKYO IN( " & strChekVal & ")" & vbCrLf
                End If
            End If

            '2021/07/06 JBD9020 金融機関情報追加 ADD START
            '契約日チェックボックス
            If chkKEIYAKUDATEARI.Checked = True And chkKEIYAKUDATENASHI.Checked = False Then
                sSQL += "    AND KEI.KEIYAKU_DATE IS NOT NULL " & vbCrLf
            End If
            If chkKEIYAKUDATEARI.Checked = False And chkKEIYAKUDATENASHI.Checked = True Then
                sSQL += "    AND KEI.KEIYAKU_DATE IS NULL " & vbCrLf
            End If
            If Not (dateKEIYAKU_Ymd_Fm.Value Is Nothing) And Not (dateKEIYAKU_Ymd_To.Value Is Nothing) Then
                sSQL += "    AND KEI.KEIYAKU_DATE BETWEEN TO_DATE('" & Format(dateKEIYAKU_Ymd_Fm.Value, "yyyy/MM/dd") & "','YYYY/MM/DD') AND TO_DATE('" & Format(dateKEIYAKU_Ymd_To.Value, "yyyy/MM/dd") & "','YYYY/MM/DD') " & vbCrLf
            End If
            '2021/07/06 JBD9020 金融機関情報追加 ADD END

            '==任意条件=======================
            '契約区分FROMTO
            If cboKEIYAKU_KBN_Cd_Fm.Text <> "" Then
                sSQL += "    AND KEI.KEIYAKU_KBN BETWEEN " & cboKEIYAKU_KBN_Cd_Fm.Text & " and " & cboKEIYAKU_KBN_Cd_To.Text & vbCrLf
            End If

            '入力者FROMTO
            '↓2018/07/20 修正
            'If cboUSER_Cd_Fm.Text <> "" Then
            '    sSQL += "    AND KEIJOHO.UP_ID BETWEEN '" & cboUSER_Cd_Fm.Text & "' and '" & cboUSER_Cd_To.Text & "'" & vbCrLf
            'End If
            If rdoTOROKU_HANI.Checked Then
                If cboUSER_Cd_Fm.Text <> "" Then
                    sSQL += "    AND KEIJOHO.REG_ID BETWEEN '" & cboUSER_Cd_Fm.Text & "' and '" & cboUSER_Cd_To.Text & "'" & vbCrLf
                End If
            Else
                If cboUSER_Cd_Fm.Text <> "" Then
                    sSQL += "    AND KEIJOHO.UP_ID BETWEEN '" & cboUSER_Cd_Fm.Text & "' and '" & cboUSER_Cd_To.Text & "'" & vbCrLf
                End If
            End If
            '↑2018/07/20 修正

            '事務委託先FROMTO
            If cboITAKU_Cd_Fm.Text <> "" Then
                sSQL += "    AND KEI.JIMUITAKU_CD BETWEEN " & cboITAKU_Cd_Fm.Text & " and " & cboITAKU_Cd_To.Text & vbCrLf
            End If

            '契約者FROMTO
            If cboKEIYAKUSYA_Cd_Fm.Text <> "" Then
                sSQL += "    AND KEI.KEIYAKUSYA_CD BETWEEN " & cboKEIYAKUSYA_Cd_Fm.Text & " and " & cboKEIYAKUSYA_Cd_To.Text & vbCrLf
            End If

            'ORDER BY
            If iKbn = 0 Then
                '入力者別
                '#28 UPD START
                'R05年度 OSバージョンアップ 既存バグ修正のため変更 2024/03/13 JBD453 UPD START
                sSQL += " ORDER BY KEIJOHO.UP_ID,KEIJOHO.KI,KEIJOHO.KEIYAKUSYA_CD,KEIJOHO.UP_DATE,KEIJOHO.TORI_KBN,NOJO.MEISAI_NO " & vbCrLf
                'sSQL += " ORDER BY KEIJOHO.UP_ID,KEIJOHO.UP_DATE,KEIJOHO.KI,KEIJOHO.KEIYAKUSYA_CD,KEIJOHO.TORI_KBN,NOJO.MEISAI_NO " & vbCrLf
                'R05年度 OSバージョンアップ 既存バグ修正のため変更 2024/03/13 JBD453 UPD START
                '#28 UPD END
                'sSQL += " ORDER BY KEIJOHO.REG_ID,KEIJOHO.KI,KEIJOHO.KEIYAKUSYA_CD,KEIJOHO.REG_DATE,KEIJOHO.TORI_KBN " & vbCrLf
            Else
                '契約番号
                '#28 UPD START
                sSQL += " ORDER BY KEIJOHO.KI,KEIJOHO.KEIYAKUSYA_CD,KEIJOHO.UP_DATE,KEIJOHO.TORI_KBN,NOJO.MEISAI_NO " & vbCrLf
                '#28 UPD END
            End If


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
        Dim intIdxFrom As Integer = 0
        Dim intIdxTo As Integer = 0



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
                'TO
                'If Not f_CodeMaster_Data_Select(cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To, 1, True, 1) Then '2017/07/11 修正
                If Not f_CodeMaster_Data_Select(cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To, 1, True, 0) Then  '2017/07/11 修正
                    Exit Try
                End If

                '--------------------
                'ユーザ名
                '--------------------
                'FROM
                If Not f_User_Data_Select(cboUSER_Cd_Fm, cboUSER_Nm_Fm, True) Then
                    Exit Try
                End If
                'TO
                If Not f_User_Data_Select(cboUSER_Cd_To, cboUSER_Nm_To, True) Then
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

                cboUSER_Cd_Fm.Text = ""
                cboUSER_Cd_To.Text = ""

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
            '入力日範囲
            dateNYURYOKU_Ymd_Fm.Value = Format(Now, "yyyy/MM/dd")
            dateNYURYOKU_Ymd_To.Value = Format(Now, "yyyy/MM/dd")
            '↓2018/07/20 追加
            dateKOSHIN_Ymd_Fm.Value = Format(Now, "yyyy/MM/dd")
            dateKOSHIN_Ymd_To.Value = Format(Now, "yyyy/MM/dd")
            rdoTOROKU_HANI.Checked = True
            dateKOSHIN_Ymd_Fm.Enabled = False
            dateKOSHIN_Ymd_To.Enabled = False
            '↑2018/07/20 追加
            '契約状況
            chkSINKI.Checked = True
            chkKEIZOKU.Checked = True
            chkCYUSI.Checked = True
            '入力状況
            chkNYURYOKU_CYU.Checked = True
            chkNYURYOKU_KAKUTEI.Checked = True
            '2021/07/06 JBD9020 金融機関情報追加 ADD START
            chkKEIYAKUDATEARI.Checked = True
            chkKEIYAKUDATENASHI.Checked = True
            '2021/07/06 JBD9020 金融機関情報追加 ADD END

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
            '↓2018/07/20 修正
            'wkControlName = "入力日範囲"
            'If dateNYURYOKU_Ymd_Fm.Value Is Nothing Then
            '    Call Show_MessageBox_Add("W008", wkControlName) : dateNYURYOKU_Ymd_Fm.Focus() : Exit Try
            'End If
            'wkControlName = "入力日範囲"
            'If dateNYURYOKU_Ymd_To.Value Is Nothing Then
            '    Call Show_MessageBox_Add("W008", wkControlName) : dateNYURYOKU_Ymd_To.Focus() : Exit Try
            'End If
            If rdoTOROKU_HANI.Checked Then
                wkControlName = "登録日範囲"
                If dateNYURYOKU_Ymd_Fm.Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : dateNYURYOKU_Ymd_Fm.Focus() : Exit Try
                End If
                wkControlName = "登録日範囲"
                If dateNYURYOKU_Ymd_To.Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : dateNYURYOKU_Ymd_To.Focus() : Exit Try
                End If
            Else
                wkControlName = "更新日範囲"
                If dateKOSHIN_Ymd_Fm.Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : dateKOSHIN_Ymd_Fm.Focus() : Exit Try
                End If
                wkControlName = "更新日範囲"
                If dateKOSHIN_Ymd_To.Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : dateKOSHIN_Ymd_To.Focus() : Exit Try
                End If
            End If
            '↑2018/07/20 修正
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

            '2021/07/06 JBD9020 金融機関情報追加 ADD START
            wkControlName = "契約日"
            If chkKEIYAKUDATEARI.Checked = True Or chkKEIYAKUDATENASHI.Checked = True Then
                '何もしない
            Else
                Call Show_MessageBox_Add("W008", wkControlName) : chkKEIYAKUDATEARI.Focus() : Exit Try
            End If
            '2021/07/06 JBD9020 金融機関情報追加 ADD END

            '==いろいろチェック==================
            ''対象日（現在）チェック
            'Dim dtJIGYO_NENDO = New Obj_TM_SYORI_NENDO_KI().pJIGYO_NENDO_byDate
            'Dim dtJIGYO_SYURYO_NENDO = New Obj_TM_SYORI_NENDO_KI().pJIGYO_SYURYO_NENDO_byDate
            'If dtJIGYO_NENDO >= dateTAISYOBI_Ymd.Value And dtJIGYO_SYURYO_NENDO <= dateTAISYOBI_Ymd.Value Then
            '    wkControlName = "対象期年度以外の対象日（現在）"
            '    Call Show_MessageBox_Add("W029", wkControlName) : dateTAISYOBI_Ymd.Focus() : Exit Try
            'End If

            '==FromToチェック==================
            '↓2018/07/20 修正
            '入力日範囲
            'If f_Daisyo_Check(dateNYURYOKU_Ymd_Fm, dateNYURYOKU_Ymd_To, "入力日範囲", True, 2) = False Then
            '    Return False
            'End If
            If rdoTOROKU_HANI.Checked Then
                If f_Daisyo_Check(dateNYURYOKU_Ymd_Fm, dateNYURYOKU_Ymd_To, "登録日範囲", True, 2) = False Then
                    Return False
                End If
            Else
                If f_Daisyo_Check(dateKOSHIN_Ymd_Fm, dateKOSHIN_Ymd_To, "更新日範囲", True, 2) = False Then
                    Return False
                End If
            End If
            '↑2018/07/20 修正
            '契約区分
            If f_Daisyo_Check(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Cd_To, "契約区分", True, 1) = False Then
                Return False
            End If

            '2021/07/06 JBD9020 金融機関情報追加 ADD START
            If f_Daisyo_Check(dateKEIYAKU_Ymd_Fm, dateKEIYAKU_Ymd_To, "契約日", True, 2) = False Then
                Return False
            End If
            '2021/07/06 JBD9020 金融機関情報追加 ADD END

            '入力日者
            If f_Daisyo_Check(cboUSER_Cd_Fm, cboUSER_Cd_To, "入力日者", True, 0) = False Then
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


#Region "user_CboFrom_Validating FROM～TO項目のFROM側動作制御（対応オブジェクト：GcComboBox）"
    '------------------------------------------------------------------
    'プロシージャ名  :user_CboFrom_Validating
    '説明            :FROM～TO項目のFROM側動作制御（対応オブジェクト：GcComboBox）
    '                 FROM側項目のValidatingでCallする
    '引数            :1.cboCdFrom       Object       FROM側コードコンボオブジェクト
    '                 2.cboMeiFrom      Object       FROM側名称コンボオブジェクト
    '                 3.cboCdTo         Object       TO側コードコンボオブジェクト
    '                 4.cboMeiTo        Object       TO側名称コンボオブジェクト
    '戻り値          :無し
    '------------------------------------------------------------------
    Public Sub user_CboFrom_Validating(ByVal cboCdFrom As Object, ByVal cboMeiFrom As Object, ByVal cboCdTo As Object, ByVal cboMeiTo As Object)
        Dim strFmtwk As String = "0"

        If cboCdFrom.Text = "" Then
            'FM未入力でTOが入力だった時
            If cboCdTo.Text <> "" Then
                cboCdTo.SelectedIndex = -1
            End If
            Exit Sub
        End If

        cboCdFrom.Text = cboCdFrom.Text

        cboCdFrom.SelectedValue = cboCdFrom.Text
        If cboCdFrom.SelectedValue Is Nothing Then
            cboCdFrom.SelectedIndex = -1
            cboMeiFrom.SelectedIndex = -1
            Show_MessageBox_Add("W012", cboCdFrom.Tag) '指定された@0が正しくありません。
            cboCdFrom.Focus()
        Else
            'FROM入力でTOが未入力だった時
            If cboCdTo.Text = "" Then
                cboCdTo.SelectedValue = cboCdFrom.Text
            End If
        End If

    End Sub
#End Region


#Region "user_CboTo_Validating FROM～TO項目のTO側動作制御（対応オブジェクト：GcComboBox）"
    '------------------------------------------------------------------
    'プロシージャ名  :user_CboTo_Validating
    '説明            :FROM～TO項目のTO側動作制御（対応オブジェクト：GcComboBox）
    '                 TO側項目のValidatingでCallする
    '引数            :1.cboCdTo     Object       TO側コードコンボオブジェクト
    '                 2.cboMeiTo    Object       TO側名称コンボオブジェクト
    '                 3.cboCdFrom   Object       FROM側コードコンボオブジェクト
    '                 4.cboMeiFrom  Object       FROM側名称コンボオブジェクト
    '戻り値          :無し
    '------------------------------------------------------------------
    Public Sub user_CboTo_Validating(ByVal cboCdTo As Object, ByVal cboMeiTo As Object, ByVal cboCdFrom As Object, ByVal cboMeiFrom As Object)
        Dim strFmtwk As String = "0"

        If cboCdTo.Text = "" Then
            If cboCdFrom.Text <> "" Then
                'TO未入力でFROMが入力だった時、FROMの内容をTOにセット
                cboCdTo.SelectedValue = cboCdFrom.Text
            End If
            Exit Sub
        End If

        cboCdTo.Text = cboCdTo.Text

        cboCdTo.SelectedValue = cboCdTo.Text
        If cboCdTo.SelectedValue Is Nothing Then
            cboCdTo.SelectedIndex = -1
            cboMeiTo.SelectedIndex = -1
            Show_MessageBox_Add("W012", cboCdFrom.Tag) '指定された@0が正しくありません。

            cboCdTo.Focus()
        Else
            If cboCdFrom.Text <> "" Then
                'TO入力でFROMも入力だった時、何もせずスルー
            Else
                'TO入力でFROMが未入力だった時、TOの内容をFROMにセット
                cboCdFrom.SelectedValue = cboCdTo.Text
            End If
        End If

    End Sub
#End Region

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
