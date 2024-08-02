'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ2080.vb
'*
'*　　②　機能概要　　　　　生産者積立請求・返還一覧表（確定処理・未処理）
'*
'*　　③　作成日　　　　　　2015/03/09 JBD999
'*
'*　　④　更新日            
'*
'*******************************************************************************
Option Strict Off
Option Explicit On
Imports GrapeCity.ActiveReports
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

Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.ActiveReports.Export
Imports GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
Imports JbdGjsReport


Public Class frmGJ2080

#Region "***変数定義***"

    'Private pblnTextChange As Boolean                   '画面入力内容変更フラグ 'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL

    ''' <summary>
    ''' プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True                     '処理ジャンプ

    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "生産者積立請求・返還一覧表（確定処理・未処理）"

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
        'pblnTextChange = False             '画面入力内容変更フラグ初期化 'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL
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

#Region "請求回数FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :numSEIKYU_KAISU_Fm_Validating
    '説明            :請求回数FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numSEIKYU_KAISU_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numSEIKYU_KAISU_Fm.Validating

        Call s_From_Validating(numSEIKYU_KAISU_Fm, numSEIKYU_KAISU_To)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :numSEIKYU_KAISU_To_Validating
    '説明            :請求回数TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numSEIKYU_KAISU_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numSEIKYU_KAISU_To.Validating

        'Call s_To_Validating(numSEIKYU_KAISU_To, numSEIKYU_KAISU_Fm)

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

#Region "事務委託先FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboITAKU_Cd_Fm_SelectedIndexChanged
    '説明            :事務委託先コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboITAKU_Cd_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboITAKU_Cd_Fm.SelectedIndexChanged
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
    Private Sub cboITAKU_Nm_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboITAKU_Nm_Fm.SelectedIndexChanged
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
    Private Sub cboITAKU_Cd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboITAKU_Cd_Fm.Validating
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
    Private Sub cboITAKU_Cd_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboITAKU_Cd_To.SelectedIndexChanged
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
    Private Sub cboITAKU_Nm_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboITAKU_Nm_To.SelectedIndexChanged
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
    Private Sub cboITAKU_Cd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboITAKU_Cd_To.Validating
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
        '2015/03/03 JBD368 UPD ↓↓↓ コンボボックスの動作変更
        'Call s_CboFrom_Validating(cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm, cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To)
        Call s_CboFrom_Validating(cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm, cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To, "2")
        '2015/03/03 JBD368 UPD ↑↑↑
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
        '2015/03/03 JBD368 UPD ↓↓↓ コンボボックスの動作変更
        'Call s_CboTo_Validating(cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To, cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm)
        Call s_CboTo_Validating(cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To, cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm, "2")
        '2015/03/03 JBD368 UPD ↑↑↑
    End Sub
#End Region

#Region "請求・返還日FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :dateSEIKYU_Ymd_Fm_Validating
    '説明            :請求・返還日FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateSEIKYU_Ymd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateSEIKYU_Ymd_Fm.Validating

        Call s_From_Validating(dateSEIKYU_Ymd_Fm, dateSEIKYU_Ymd_To)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :dateSEIKYU_Ymd_To_Validating
    '説明            :請求・返還日TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateSEIKYU_Ymd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateSEIKYU_Ymd_To.Validating

        'Call s_To_Validating(dateSEIKYU_Ymd_To, dateSEIKYU_Ymd_Fm)

    End Sub
#End Region

#Region "入金・振込日FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :dateNYUKIN_Ymd_Fm_Validating
    '説明            :入金・振込日FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateNYUKIN_Ymd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateNYUKIN_Ymd_Fm.Validating

        Call s_From_Validating(dateNYUKIN_Ymd_Fm, dateNYUKIN_Ymd_To)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :dateNYUKIN_Ymd_To_Validating
    '説明            :入金・振込日TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateNYUKIN_Ymd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateNYUKIN_Ymd_To.Validating

        'Call s_To_Validating(dateNYUKIN_Ymd_To, dateNYUKIN_Ymd_Fm)

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
            'R05年度　OSバージョンアップ　既存バグ修正のため削除 2024/03/12 JBD453 DEL START
            'If pblnTextChange Then
            '    '画面に変更があり保存していない場合は、メッセージ表示
            '    If Show_MessageBox("Q007", "") = DialogResult.No Then
            '        '「いいえ」を選択
            '        Exit Sub
            '    End If
            'End If
            'R05年度　OSバージョンアップ　既存バグ修正のため削除 2024/03/12 JBD453 DEL END
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


            'SQL
            If Not f_make_SQL(wkKbn, wkSql) Then
                Exit Try
            End If

            Debug.Print(wkSql)

            'データ取得
            If Not f_Select_ODP(wkDSRep, wkSql) Then
                Exit Try
            End If

            If wkDSRep.Tables(0).Rows.Count > 0 Then
                Dim w As New rptGJ2080
                w.sub1(wkDSRep)
                'Using wkAR As New rptGJ2080

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
        Dim wkBuff As String

        '#25 ADD START
        Dim sKaishiNen As String
        Dim sSyuryoNen As String
        '#25 ADD END

        Try
            '対象期・年度の取得
            Dim SyoriKI = New Obj_TM_SYORI_NENDO_KI()

            '#25 ADD START
            '期の開始年と終了年の算出
            sKaishiNen = ((numKI.Value - 6) * 3) + 2015 & "/04/01"
            sSyuryoNen = ((numKI.Value - 6) * 3) + 2015 + 2 & "/03/31"
            '#25 ADD END


            sSQL = " SELECT " & vbCrLf
            sSQL &= "     TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI " & vbCrLf
            '-- 期
            '#25 ADD START
            sSQL += " ,'対象期：第" & numKI.Value & "期（' || TO_CHAR(TO_DATE('" & sKaishiNen & "'), '""""EEYY""年度～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & sSyuryoNen & "'), '""""EEYY""年度）""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS TAISYO_KI " & vbCrLf
            '#25 ADD END

            '-- 出力区分
            wkBuff = ""
            If chkSEIKYU_HENKAN_KBN_1.Checked Then
                wkBuff = "全額請求"
            End If
            If chkSEIKYU_HENKAN_KBN_2.Checked Then
                If wkBuff.Length = 0 Then
                    wkBuff = "一部請求"
                Else
                    wkBuff &= "、一部請求"
                End If
            End If
            If chkSEIKYU_HENKAN_KBN_3.Checked Then
                If wkBuff.Length = 0 Then
                    wkBuff = "一部返還"
                Else
                    wkBuff &= "、一部返還"
                End If
            End If
            If chkSEIKYU_HENKAN_KBN_4.Checked Then
                If wkBuff.Length = 0 Then
                    wkBuff = "全額返還"
                Else
                    wkBuff &= "、全額返還"
                End If
            End If
            sSQL &= "     ,'出力区分：" & wkBuff & "' AS SEIKYU_HENKAN_KBN_HED " & vbCrLf
            '-- 請求等回数・請求日FROMTO
            sSQL &= "     ,'請求等回数：" & numSEIKYU_KAISU_Fm.Text & "～" & numSEIKYU_KAISU_To.Text & "　請求日：' || TO_CHAR(TO_DATE('" & Format(dateSEIKYU_Ymd_Fm.Value, "yyyy/MM/dd") & "'), 'EEYY""年""MM""月""DD""日～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & Format(dateSEIKYU_Ymd_To.Value, "yyyy/MM/dd") & "'), 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''')" & " AS SEIKYU_DATE_HED " & vbCrLf
            '-- 入金・振込日FROMTO
            sSQL &= "     ,'（入金・振込日：' || TO_CHAR(TO_DATE('" & Format(dateNYUKIN_Ymd_Fm.Value, "yyyy/MM/dd") & "'), 'EEYY""/""MM""/""DD""～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & Format(dateNYUKIN_Ymd_To.Value, "yyyy/MM/dd") & "'), 'EEYY""/""MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''')" & " || ')' AS NYUKIN_DATE_HED " & vbCrLf
            sSQL &= "    ,TUM.KI AS KI" & vbCrLf
            sSQL &= "    ,KEI.JIMUITAKU_CD AS JIMUITAKU_CD" & vbCrLf
            sSQL &= "    ,'('|| KEI.JIMUITAKU_CD || ')：' || ITK.ITAKU_NAME AS ITAKU_NAME_HED" & vbCrLf
            sSQL &= "    ,TUM.KEIYAKUSYA_CD AS KEIYAKUSYA_CD" & vbCrLf
            sSQL &= "    ,KEI.KEIYAKUSYA_NAME AS KEIYAKUSYA_NAME" & vbCrLf
            sSQL &= "    ,TUM.KEIYAKU_KBN AS KEIYAKU_KBN" & vbCrLf
            '↓2017/07/25 修正 契約区分
            'sSQL &= "    ,SUBSTR(CD01.MEISYO,1,1) AS KEIYAKU_KBN_NM"
            sSQL &= "    ,CD01.RYAKUSYO AS KEIYAKU_KBN_NM" & vbCrLf
            '↑2017/07/25 修正 契約区分
            sSQL &= "    ,KEI.KEIYAKU_JYOKYO AS KEIYAKU_JYOKYO " & vbCrLf
            sSQL &= "    ,SUBSTR(CD02.MEISYO,1,1) AS KEIYAKU_JYOKYO_NM" & vbCrLf
            sSQL &= "    ,TUM.SEIKYU_HENKAN_KBN AS SEIKYU_HENKAN_KBN" & vbCrLf
            sSQL &= "    ,SUBSTR(CD08.RYAKUSYO,1,2) AS SEIKYU_HENKAN_KBN_NM" & vbCrLf
            sSQL &= "    ,TUM.SEIKYU_KAISU AS SEIKYU_KAISU" & vbCrLf
            sSQL &= "    ,TO_CHAR(TUM.SEIKYU_DATE, 'EEYY""/""MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SEIKYU_DATE" & vbCrLf
            sSQL &= "    ,TO_CHAR(TUM.NOFUKIGEN_DATE, 'MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NOFUKIGEN_DATE" & vbCrLf
            sSQL &= "    ,CASE" & vbCrLf
            sSQL &= "        WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL" & vbCrLf
            '↓2018/03/13 UPD
            'sSQL &= "        ELSE TUM.TUMITATE_KIN" & vbCrLf
            sSQL &= "        WHEN TUM.KEIYAKU_HENKO_KBN = 0 THEN TUM.TUMITATE_KIN" & vbCrLf
            sSQL &= "        ELSE TUM.SAGAKU_TUMITATE_KIN" & vbCrLf
            '↑2018/03/13 UPD
            sSQL &= "     END TUMITATE_KIN" & vbCrLf
            sSQL &= "    ,CASE" & vbCrLf
            sSQL &= "        WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL" & vbCrLf
            '↓2018/03/13 UPD
            'sSQL &= "        ELSE TUM.TESURYO" & vbCrLf
            sSQL &= "        WHEN TUM.KEIYAKU_HENKO_KBN = 0 THEN TUM.TESURYO" & vbCrLf
            sSQL &= "        ELSE TUM.SAGAKU_TESURYO" & vbCrLf
            '↑2018/03/13 UPD
            sSQL &= "     END TESURYO" & vbCrLf
            sSQL &= "    ,CASE" & vbCrLf
            sSQL &= "        WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL" & vbCrLf
            '↓2018/03/13 UPD
            'sSQL &= "        ELSE TUM.SEIKYU_KIN" & vbCrLf
            sSQL &= "        WHEN TUM.KEIYAKU_HENKO_KBN = 0 THEN TUM.SEIKYU_KIN" & vbCrLf
            sSQL &= "        ELSE TUM.SAGAKU_SEIKYU_KIN" & vbCrLf
            '↑2018/03/13 UPD
            sSQL &= "     END SEIKYU_KIN" & vbCrLf
            sSQL &= "    ,CASE" & vbCrLf
            sSQL &= "        WHEN TUM.KEIYAKU_HENKO_KBN = 0 THEN ZEN.HENKAN_KAKUTEI_KIN" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "     END HENKAN_KAKUTEI_KIN" & vbCrLf
            sSQL &= "    ,TUM.SAGAKU_SEIKYU_KIN AS SAGAKU_SEIKYU_KIN_NOFU" & vbCrLf
            sSQL &= "    ,TUM.SAGAKU_SEIKYU_KIN AS SAGAKU_SEIKYU_KIN_MINOFU" & vbCrLf
            sSQL &= "    ,TUM.NYUKIN_KBN AS NYUKIN_KBN" & vbCrLf
            sSQL &= "    ,CASE WHEN TUM.NYUKIN_KBN IS NULL THEN 0" & vbCrLf      '積立金.入金区分=NULL(入金なし)のとき、入金明細出力しない
            sSQL &= "          WHEN NYU.KEIYAKUSYA_CD IS NULL THEN 0" & vbCrLf   '積立入金に指定した入金・振込日のデータなしのとき、入金明細出力しない
            sSQL &= "          ELSE 1 " & vbCrLf                                 '上記以外(指定した入金・振込日に入金あり)のとき、入金明細出力あり
            sSQL &= "     END DTL_FLG" & vbCrLf
            sSQL &= "    ,CASE" & vbCrLf
            sSQL &= "        WHEN TUM.NYUKIN_KBN IS NULL THEN " & vbCrLf     '--積立金入金区分　1:一括　2:分割　NULL:未入金　積立金区分＝１のときのみ
            sSQL &= "           CASE" & vbCrLf
            sSQL &= "             WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN '請求中'" & vbCrLf
            sSQL &= "              ELSE '返還中'" & vbCrLf
            sSQL &= "           END" & vbCrLf
            '2016/03/14　修正開始
            'sSQL &= "        ELSE NULL"
            sSQL &= "        ELSE" & vbCrLf
            sSQL &= "           CASE" & vbCrLf
            sSQL &= "             WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN" & vbCrLf '--請求返還区分　1:請求 2:請求兼返還（徴収）
            sSQL &= "           　     CASE" & vbCrLf     '--処理状況 1:請求（返還）中　2:督促中　3:入金（返還）済　4:一部入金　5:督促中（一部入金）
            sSQL &= "                     WHEN TUM.SYORI_JOKYO_KBN IN(3)   THEN '入金済'" & vbCrLf
            sSQL &= "                     WHEN TUM.SYORI_JOKYO_KBN IN(4,5) THEN '一部入'" & vbCrLf
            sSQL &= "                     ELSE NULL" & vbCrLf
            sSQL &= "                  END" & vbCrLf
            sSQL &= "             ELSE" & vbCrLf
            sSQL &= "                  CASE" & vbCrLf     '--処理状況 1:請求（返還）中　2:督促中　3:入金（返還）済　4:一部入金　5:督促中（一部入金）
            sSQL &= "                     WHEN TUM.SYORI_JOKYO_KBN IN(3)   THEN '返還済'" & vbCrLf
            sSQL &= "                     ELSE NULL" & vbCrLf
            sSQL &= "                  END" & vbCrLf
            sSQL &= "           END" & vbCrLf
            '2016/03/14　修正終了
            sSQL &= "     END NYUKIN_INFO" & vbCrLf
            '             -- 入金明細
            sSQL &= "    ,CASE" & vbCrLf
            sSQL &= "        WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN " & vbCrLf
            sSQL &= "           CASE" & vbCrLf
            sSQL &= "              WHEN NYU.NYUKIN_KAISU IS NULL THEN NULL" & vbCrLf
            sSQL &= "              ELSE '入金' || NYU.NYUKIN_KAISU" & vbCrLf
            sSQL &= "           END" & vbCrLf
            sSQL &= "        ELSE '振込'" & vbCrLf
            sSQL &= "     END NYU_NOFUKIGEN_DATE" & vbCrLf

            '2016/12/27　修正開始
            ''#55 UPD START
            ''sSQL &= "    ,NYU.NYUKIN_TUMITATE AS NYUKIN_TUMITATE"
            'sSQL &= "    ,CASE "
            'sSQL &= "        WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL"
            'sSQL &= "        ELSE NYU.NYUKIN_TUMITATE_HENKAN"
            'sSQL &= "     END NYUKIN_TUMITATE    "
            ''sSQL &= "    ,NYU.NYUKIN_TESU AS NYUKIN_TESU"
            'sSQL &= "    ,CASE"
            'sSQL &= "        WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL"
            'sSQL &= "        ELSE NYU.NYUKIN_TESU_HENKAN"
            'sSQL &= "     END NYUKIN_TESU    "
            ''sSQL &= "    ,NYU.NYUKIN_TUMITATE + NYU.NYUKIN_TESU AS SEI_TUMITATE_KIN_SANTEI"
            'sSQL &= "    ,CASE"
            'sSQL &= "        WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL"
            'sSQL &= "        ELSE NYU.NYUKIN_TUMITATE_HENKAN + NYU.NYUKIN_TESU_HENKAN"
            'sSQL &= "     END SEI_TUMITATE_KIN_SANTEI"
            ''sSQL &= "    ,CASE"
            ''sSQL &= "        WHEN NYU.NYUKIN_KAISU = 1 THEN ZEN.HENKAN_KAKUTEI_KIN"
            ''sSQL &= "        ELSE NULL"
            ''sSQL &= "     END NYU_HENKAN_KAKUTEI_KIN"
            'sSQL &= "    ,CASE"
            'sSQL &= "        WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL"
            'sSQL &= "        ELSE"
            'sSQL &= "           CASE"
            'sSQL &= "              WHEN NYU.NYUKIN_KAISU = 1 THEN ZEN.HENKAN_KAKUTEI_KIN"
            'sSQL &= "              ELSE NULL"
            'sSQL &= "             END"
            'sSQL &= "     END NYU_HENKAN_KAKUTEI_KIN"
            ''#55 UPD START
            '----生産者積立金----
            '　  ・全額返還の場合、空白
            '　  ・契約変更区分=0(新規)かつ入金１回目の場合、入金.積立金入金額(返還金含む)
            '　  ・上記以外の場合、入金.積立金入金額
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL" & vbCrLf
            sSQL &= "        WHEN TUM.KEIYAKU_HENKO_KBN = 0 AND NYU.NYUKIN_KAISU = 1 THEN NYU.NYUKIN_TUMITATE_HENKAN" & vbCrLf
            sSQL &= "        ELSE NYU.NYUKIN_TUMITATE" & vbCrLf
            sSQL &= "   END NYUKIN_TUMITATE" & vbCrLf
            '----事務手数料----
            '　  ・全額返還の場合、空白
            '　  ・契約変更区分=0(新規)かつ入金１回目の場合、入金.手数料入金額(返還金含む)
            '　  ・上記以外の場合、入金.手数料入金額
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL" & vbCrLf
            sSQL &= "        WHEN TUM.KEIYAKU_HENKO_KBN = 0 AND NYU.NYUKIN_KAISU = 1 THEN NYU.NYUKIN_TESU_HENKAN" & vbCrLf
            sSQL &= "        ELSE NYU.NYUKIN_TESU" & vbCrLf
            sSQL &= "   END NYUKIN_TESU" & vbCrLf
            '----生産者積立金等算定額----
            '　  ・生産者積立金　＋　事務手数料
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL" & vbCrLf
            sSQL &= "        WHEN TUM.KEIYAKU_HENKO_KBN = 0 AND NYU.NYUKIN_KAISU = 1 THEN NYU.NYUKIN_TUMITATE_HENKAN " & _
                                                                                       "+ NYU.NYUKIN_TESU_HENKAN" & vbCrLf
            sSQL &= "        ELSE NYU.NYUKIN_TUMITATE + NYU.NYUKIN_TESU" & vbCrLf
            sSQL &= "   END SEI_TUMITATE_KIN_SANTEI" & vbCrLf
            '----返還金による積立金等充当額----
            '　  ・契約変更区分=0(新規)かつ入金１回目の場合、返還.返還額(確定)
            '　  ・上記以外の場合、入金.手数料入金額
            sSQL &= "  ,CASE WHEN TUM.KEIYAKU_HENKO_KBN = 0 AND NYU.NYUKIN_KAISU = 1 THEN ZEN.HENKAN_KAKUTEI_KIN" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END NYU_HENKAN_KAKUTEI_KIN" & vbCrLf
            '2016/12/27　修正終了

            sSQL &= "  ,NYU.NYUKIN_GAKU AS NYUKIN_GAKU" & vbCrLf
            sSQL &= "  ,NYU.NYUKIN_ZAN AS NYUKIN_ZAN" & vbCrLf
            sSQL &= "  ,CASE WHEN NYU.NYUKIN_ZAN = 0 THEN '○' ELSE '△' END ZAN_KBN" & vbCrLf
            sSQL &= "  ,TO_CHAR(NYU.NYUKIN_DATE, 'MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NYUKIN_DATE" & vbCrLf

            '#55 UPD START
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN NYU.NYUKIN_TUMITATE  END NYUKIN_TUMITATE_NYU"
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN NYU.NYUKIN_TUMITATE  END NYUKIN_TUMITATE_FRI"
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN NYU.NYUKIN_TESU  END NYUKIN_TESU_NYU"
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN NYU.NYUKIN_TESU  END NYUKIN_TESU_FRI"
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN NYU.NYUKIN_TUMITATE + NYU.NYUKIN_TESU  END SEI_TUMITATE_KIN_SANTEI_NYU"
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN NYU.NYUKIN_TUMITATE + NYU.NYUKIN_TESU  END SEI_TUMITATE_KIN_SANTEI_FRI"
            'sSQL &= "    ,CASE"
            'sSQL &= "        WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN "
            'sSQL &= "           CASE"
            'sSQL &= "              WHEN NYU.NYUKIN_KAISU = 1 THEN ZEN.HENKAN_KAKUTEI_KIN"
            'sSQL &= "           ELSE NULL"
            'sSQL &= "            END"
            'sSQL &= "     END NYU_HENKAN_KAKUTEI_KIN_NYU"
            'sSQL &= "    ,CASE"
            'sSQL &= "        WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN "
            'sSQL &= "           CASE"
            'sSQL &= "              WHEN NYU.NYUKIN_KAISU = 1 THEN ZEN.HENKAN_KAKUTEI_KIN"
            'sSQL &= "           ELSE NULL"
            'sSQL &= "            END"
            'sSQL &= "     END NYU_HENKAN_KAKUTEI_KIN_FRI"
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN NYU.NYUKIN_GAKU  END NYUKIN_GAKU_NYU"
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN NYU.NYUKIN_GAKU  END NYUKIN_GAKU_FRI"
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN NYU.NYUKIN_ZAN  END NYUKIN_GAKU_ZAN_NYU"
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN NYU.NYUKIN_ZAN  END NYUKIN_GAKU_ZAN_FRI"

            '2016/12/27　修正開始
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN NYU.NYUKIN_TUMITATE_HENKAN END NYUKIN_TUMITATE_NYU"
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN NYU.NYUKIN_TUMITATE_HENKAN END NYUKIN_TUMITATE_FRI"
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN NYU.NYUKIN_TESU_HENKAN END NYUKIN_TESU_NYU"
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN NYU.NYUKIN_TESU_HENKAN END NYUKIN_TESU_FRI"
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN NYU.NYUKIN_TUMITATE_HENKAN + NYU.NYUKIN_TESU_HENKAN END SEI_TUMITATE_KIN_SANTEI_NYU"
            'sSQL &= "    ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN NYU.NYUKIN_TUMITATE_HENKAN + NYU.NYUKIN_TESU_HENKAN END SEI_TUMITATE_KIN_SANTEI_FRI"

            'sSQL &= "    ,CASE"
            'sSQL &= "        WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN "
            'sSQL &= "           CASE"
            'sSQL &= "              WHEN NYU.NYUKIN_KAISU = 1 THEN ZEN.HENKAN_KAKUTEI_KIN"
            'sSQL &= "           ELSE NULL"
            'sSQL &= "            END"
            'sSQL &= "     END NYU_HENKAN_KAKUTEI_KIN_NYU"
            'sSQL &= "    ,CASE"
            'sSQL &= "        WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN "
            'sSQL &= "           CASE"
            'sSQL &= "              WHEN NYU.NYUKIN_KAISU = 1 THEN ZEN.HENKAN_KAKUTEI_KIN"
            'sSQL &= "           ELSE NULL"
            'sSQL &= "            END"
            'sSQL &= "     END NYU_HENKAN_KAKUTEI_KIN_FRI"
            '#55 UPD END

            '----生産者積立金(合計)----
            '↓2018/03/13 UPD
            ''請求
            'sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 4  THEN NULL" & vbCrLf
            'sSQL &= "        WHEN NVL(NYU.NYUKIN_KAISU,0) < 2 THEN TUM.TUMITATE_KIN" & vbCrLf
            'sSQL &= "        ELSE NULL" & vbCrLf
            'sSQL &= "   END NYUKIN_TUMITATE_SEI" & vbCrLf
            '請求
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN" & vbCrLf
            sSQL &= "             CASE WHEN TUM.KEIYAKU_HENKO_KBN = 0 THEN TUM.TUMITATE_KIN" & vbCrLf
            sSQL &= "                  ELSE TUM.SAGAKU_TUMITATE_KIN" & vbCrLf
            sSQL &= "             END " & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END NYUKIN_TUMITATE_SEI" & vbCrLf
            '返還
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN" & vbCrLf
            sSQL &= "             CASE WHEN TUM.KEIYAKU_HENKO_KBN = 0 THEN TUM.TUMITATE_KIN" & vbCrLf
            sSQL &= "                  ELSE TUM.SAGAKU_TUMITATE_KIN" & vbCrLf
            sSQL &= "             END " & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END NYUKIN_TUMITATE_HEN" & vbCrLf
            '↑2018/03/13 UPD

            '入金
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN" & vbCrLf
            sSQL &= "             CASE WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL" & vbCrLf
            sSQL &= "                  WHEN TUM.KEIYAKU_HENKO_KBN = 0 AND NYU.NYUKIN_KAISU = 1 THEN NYU.NYUKIN_TUMITATE_HENKAN" & vbCrLf
            sSQL &= "                  ELSE NYU.NYUKIN_TUMITATE" & vbCrLf
            sSQL &= "             END" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END NYUKIN_TUMITATE_NYU" & vbCrLf
            '振込
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN" & vbCrLf
            sSQL &= "             CASE WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL" & vbCrLf
            sSQL &= "                  WHEN TUM.KEIYAKU_HENKO_KBN = 0 AND NYU.NYUKIN_KAISU = 1 THEN NYU.NYUKIN_TUMITATE_HENKAN" & vbCrLf
            sSQL &= "                  ELSE NYU.NYUKIN_TUMITATE" & vbCrLf
            sSQL &= "             END" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END NYUKIN_TUMITATE_FRI" & vbCrLf

            '----事務手数料(合計)----
            '↓2018/03/13 UPD
            ''請求
            'sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL" & vbCrLf
            'sSQL &= "        WHEN NVL(NYU.NYUKIN_KAISU,0) < 2 THEN TUM.TESURYO" & vbCrLf
            'sSQL &= "        ELSE NULL" & vbCrLf
            'sSQL &= "   END NYUKIN_TESU_SEI" & vbCrLf
            '請求
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN" & vbCrLf
            sSQL &= "             CASE WHEN TUM.KEIYAKU_HENKO_KBN = 0 THEN TUM.TESURYO" & vbCrLf
            sSQL &= "                  ELSE TUM.SAGAKU_TESURYO" & vbCrLf
            sSQL &= "             END" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END NYUKIN_TESU_SEI" & vbCrLf
            '返還
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN" & vbCrLf
            sSQL &= "             CASE WHEN TUM.KEIYAKU_HENKO_KBN = 0 THEN TUM.TESURYO" & vbCrLf
            sSQL &= "                  ELSE TUM.SAGAKU_TESURYO" & vbCrLf
            sSQL &= "             END" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END NYUKIN_TESU_HEN" & vbCrLf
            '↑2018/03/13 UPD
            '入金
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN" & vbCrLf
            sSQL &= "             CASE WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL" & vbCrLf
            sSQL &= "                  WHEN TUM.KEIYAKU_HENKO_KBN = 0 AND NYU.NYUKIN_KAISU = 1 THEN NYU.NYUKIN_TESU_HENKAN" & vbCrLf
            sSQL &= "                  ELSE NYU.NYUKIN_TESU" & vbCrLf
            sSQL &= "             END" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END NYUKIN_TESU_NYU" & vbCrLf
            '振込
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN" & vbCrLf
            sSQL &= "             CASE WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL" & vbCrLf
            sSQL &= "                  WHEN TUM.KEIYAKU_HENKO_KBN = 0 AND NYU.NYUKIN_KAISU = 1 THEN NYU.NYUKIN_TESU_HENKAN" & vbCrLf
            sSQL &= "                  ELSE NYU.NYUKIN_TESU" & vbCrLf
            sSQL &= "             END" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END NYUKIN_TESU_FRI" & vbCrLf

            '----生産者積立金等算定額(合計)----
            '↓2018/03/13 UPD
            ''請求
            'sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL" & vbCrLf
            'sSQL &= "        WHEN NVL(NYU.NYUKIN_KAISU,0) < 2 THEN TUM.SEIKYU_KIN" & vbCrLf
            'sSQL &= "        ELSE NULL" & vbCrLf
            'sSQL &= "   END SEI_TUMITATE_KIN_SANTEI_SEI" & vbCrLf
            '請求
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN" & vbCrLf
            sSQL &= "             CASE WHEN TUM.KEIYAKU_HENKO_KBN = 0 THEN TUM.SEIKYU_KIN" & vbCrLf
            sSQL &= "                  ELSE TUM.SAGAKU_SEIKYU_KIN" & vbCrLf
            sSQL &= "             END" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END SEI_TUMITATE_KIN_SANTEI_SEI" & vbCrLf
            '返還
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN" & vbCrLf
            sSQL &= "             CASE WHEN TUM.KEIYAKU_HENKO_KBN = 0 THEN TUM.SEIKYU_KIN" & vbCrLf
            sSQL &= "                  ELSE TUM.SAGAKU_SEIKYU_KIN" & vbCrLf
            sSQL &= "             END" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END SEI_TUMITATE_KIN_SANTEI_HEN" & vbCrLf
            '↑2018/03/13 UPD
            '入金
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN" & vbCrLf
            sSQL &= "             CASE WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL" & vbCrLf
            sSQL &= "                  WHEN TUM.KEIYAKU_HENKO_KBN = 0 AND NYU.NYUKIN_KAISU = 1 THEN NYU.NYUKIN_TUMITATE_HENKAN " & _
                                                                                                 "+ NYU.NYUKIN_TESU_HENKAN" & vbCrLf
            sSQL &= "                  ELSE NYU.NYUKIN_TUMITATE + NYU.NYUKIN_TESU" & vbCrLf
            sSQL &= "             END" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END SEI_TUMITATE_KIN_SANTEI_NYU" & vbCrLf
            '振込
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN" & vbCrLf
            sSQL &= "             CASE WHEN TUM.SEIKYU_HENKAN_KBN = 4 THEN NULL" & vbCrLf
            sSQL &= "                  WHEN TUM.KEIYAKU_HENKO_KBN = 0 AND NYU.NYUKIN_KAISU = 1 THEN NYU.NYUKIN_TUMITATE_HENKAN " & _
                                                                                                   "+ NYU.NYUKIN_TESU_HENKAN" & vbCrLf
            sSQL &= "                  ELSE NYU.NYUKIN_TUMITATE + NYU.NYUKIN_TESU" & vbCrLf
            sSQL &= "             END" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END SEI_TUMITATE_KIN_SANTEI_FRI" & vbCrLf

            '----返還金による積立金等充当額(合計)----
            '↓2018/03/13 UPD
            ''請求
            'sSQL &= "  ,CASE WHEN TUM.KEIYAKU_HENKO_KBN = 0 AND NVL(NYU.NYUKIN_KAISU,0) < 2 THEN ZEN.HENKAN_KAKUTEI_KIN" & vbCrLf
            'sSQL &= "        ELSE NULL" & vbCrLf
            'sSQL &= "   END NYU_HENKAN_KAKUTEI_KIN_SEI" & vbCrLf
            '請求
            sSQL &= "  ,CASE WHEN (TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2) AND TUM.KEIYAKU_HENKO_KBN = 0 THEN ZEN.HENKAN_KAKUTEI_KIN" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END NYU_HENKAN_KAKUTEI_KIN_SEI" & vbCrLf
            '返還
            sSQL &= "  ,CASE WHEN (TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4) AND TUM.KEIYAKU_HENKO_KBN = 0 THEN ZEN.HENKAN_KAKUTEI_KIN" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END NYU_HENKAN_KAKUTEI_KIN_HEN" & vbCrLf
            '↑2018/03/13 UPD
            '入金
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN" & vbCrLf
            sSQL &= "             CASE WHEN TUM.KEIYAKU_HENKO_KBN = 0 AND NYU.NYUKIN_KAISU = 1 THEN ZEN.HENKAN_KAKUTEI_KIN" & vbCrLf
            sSQL &= "                  ELSE NULL" & vbCrLf
            sSQL &= "             END" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END NYU_HENKAN_KAKUTEI_KIN_NYU" & vbCrLf
            '振込
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN" & vbCrLf
            sSQL &= "             CASE WHEN TUM.KEIYAKU_HENKO_KBN = 0 AND NYU.NYUKIN_KAISU = 1 THEN ZEN.HENKAN_KAKUTEI_KIN" & vbCrLf
            sSQL &= "                  ELSE NULL" & vbCrLf
            sSQL &= "             END" & vbCrLf
            sSQL &= "        ELSE NULL" & vbCrLf
            sSQL &= "   END NYU_HENKAN_KAKUTEI_KIN_FRI" & vbCrLf
            '2016/12/27　修正終了

            '↓2018/03/13 UPD
            ''2016/12/27　追加開始
            ''----生産者積立金等請求納付額(請求合計)----
            'sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN" & vbCrLf
            'sSQL &= "             CASE WHEN NVL(NYU.NYUKIN_KAISU,0) < 2 THEN TUM.SAGAKU_SEIKYU_KIN" & vbCrLf
            'sSQL &= "                  ELSE NULL" & vbCrLf
            'sSQL &= "             END" & vbCrLf
            'sSQL &= "        ELSE CASE WHEN NVL(NYU.NYUKIN_KAISU,0) < 2 THEN TUM.SAGAKU_SEIKYU_KIN * -1" & vbCrLf
            'sSQL &= "                  ELSE NULL" & vbCrLf
            'sSQL &= "             END" & vbCrLf
            'sSQL &= "   END NYUKIN_GAKU_SEI" & vbCrLf
            ''2016/12/27　追加終了
            '請求
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN" & vbCrLf
            sSQL &= "       TUM.SAGAKU_SEIKYU_KIN ELSE NULL" & vbCrLf
            sSQL &= "   END NYUKIN_GAKU_SEI" & vbCrLf
            '返還
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN" & vbCrLf
            'sSQL &= "      NYU.NYUKIN_GAKU ELSE NULL" & vbCrLf         '2018/03/19　修正
            sSQL &= "       TUM.SAGAKU_SEIKYU_KIN ELSE NULL" & vbCrLf   '2018/03/19　修正
            sSQL &= "   END NYUKIN_GAKU_HEN" & vbCrLf
            '↑2018/03/13 UPD

            '#55 UPD START
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN NYU.NYUKIN_GAKU END NYUKIN_GAKU_NYU" & vbCrLf
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN NYU.NYUKIN_GAKU END NYUKIN_GAKU_FRI" & vbCrLf
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN NYU.NYUKIN_ZAN END NYUKIN_GAKU_ZAN_NYU" & vbCrLf
            sSQL &= "  ,CASE WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN NYU.NYUKIN_ZAN END NYUKIN_GAKU_ZAN_FRI" & vbCrLf
            '#55 UPD END

            '2016/12/28　追加開始
            sSQL &= "  ,ROW_NUMBER() OVER(PARTITION BY KEI.JIMUITAKU_CD, TUM.KEIYAKUSYA_CD ORDER BY TUM.SEIKYU_KAISU, NYU.NYUKIN_KAISU) LINE_NO" & vbCrLf
            '2016/12/28　追加終了
            '↓2018/03/16 ADD
            sSQL &= "   ,TUM.KEIYAKUSYA_CD || TUM.SEIKYU_KAISU AS KEIKAI"
            '↑2018/03/16 ADD
            '2021/04/13 JBD9020 R03年度追加基金対応 ADD START
            sSQL &= "  ,ITK.ITAKU_NAME" & vbCrLf
            sSQL &= "  ,CASE WHEN NYU.NYUKIN_ZAN = 0 THEN '入金・振込完了' ELSE '一部入金' END ZAN_NAME" & vbCrLf
            sSQL &= "  ,CD01.MEISYO AS KEIYAKU_KBN_NAME" & vbCrLf
            sSQL &= "  ,CD02.RYAKUSYO AS KEIYAKU_JYOKYO_NAME" & vbCrLf
            sSQL &= "  ,CD08.MEISYO AS SEIKYU_HENKAN_KBN_NAME" & vbCrLf
            sSQL &= "  ,NVL(NYU.NYUKIN_KAISU,0) AS NYUKAISU" & vbCrLf
            sSQL &= "  ,TO_CHAR(TUM.SEIKYU_DATE,    'EYY"".""MM"".""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SEIKYU_DATEX" & vbCrLf
            sSQL &= "  ,TO_CHAR(TUM.NOFUKIGEN_DATE, 'EYY"".""MM"".""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NOFUKIGEN_DATEX" & vbCrLf
            sSQL &= "  ,TO_CHAR(NYU.NYUKIN_DATE,    'EYY"".""MM"".""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NYUKIN_DATEX" & vbCrLf
            sSQL &= "  ,ROW_NUMBER() OVER(PARTITION BY TUM.KEIYAKUSYA_CD ORDER BY TUM.SEIKYU_KAISU, NYU.NYUKIN_KAISU) KEI_NO" & vbCrLf
            '2021/04/13 JBD9020 R03年度追加基金対応 ADD END

            sSQL &= " FROM TT_TUMITATE TUM" & vbCrLf
            'sSQL &= "     ,TT_TUMITATE_NYUKIN NYU"
            sSQL &= "    ,(" & vbCrLf
            sSQL &= "     SELECT " & vbCrLf
            sSQL &= "           NYUKIN.KI AS KI" & vbCrLf
            sSQL &= "          ,NYUKIN.KEIYAKUSYA_CD AS KEIYAKUSYA_CD" & vbCrLf
            sSQL &= "          ,NYUKIN.SEIKYU_KAISU AS SEIKYU_KAISU" & vbCrLf
            sSQL &= "          ,NYUKIN.TUMITATE_KBN AS TUMITATE_KBN" & vbCrLf
            sSQL &= "          ,NYUKIN.NYUKIN_KAISU AS NYUKIN_KAISU" & vbCrLf
            sSQL &= "          ,NYUKIN.NYUKIN_TUMITATE AS NYUKIN_TUMITATE" & vbCrLf
            sSQL &= "          ,NYUKIN.NYUKIN_TESU AS NYUKIN_TESU" & vbCrLf
            sSQL &= "          ,NYUKIN.NYUKIN_GAKU AS NYUKIN_GAKU" & vbCrLf
            sSQL &= "          ,NYUKIN.NYUKIN_ZAN AS NYUKIN_ZAN" & vbCrLf
            sSQL &= "          ,NYUKIN.NYUKIN_DATE AS NYUKIN_DATE" & vbCrLf
            '#55 ADD START
            sSQL &= "          ,NYUKIN.NYUKIN_TUMITATE_HENKAN AS NYUKIN_TUMITATE_HENKAN" & vbCrLf
            sSQL &= "          ,NYUKIN.NYUKIN_TESU_HENKAN AS NYUKIN_TESU_HENKAN" & vbCrLf
            '#55 ADD END

            sSQL &= "     FROM TT_TUMITATE_NYUKIN NYUKIN" & vbCrLf
            sSQL &= "     WHERE" & vbCrLf
            sSQL &= "          NYUKIN.KI = " & numKI.Value & vbCrLf
            '                   入金・振込日FROMTO
            sSQL &= "      AND NYUKIN.NYUKIN_DATE BETWEEN TO_DATE('" & Format(dateNYUKIN_Ymd_Fm.Value, "yyyy/MM/dd") & "') and TO_DATE('" & Format(dateNYUKIN_Ymd_To.Value, "yyyy/MM/dd") & "')" & vbCrLf
            sSQL &= "     ) NYU" & vbCrLf

            sSQL &= "     ,TM_KEIYAKU KEI" & vbCrLf
            sSQL &= "     ,TM_JIMUITAKU ITK" & vbCrLf
            sSQL &= "     ,TT_ZENKI_TUMITATE_HENKAN ZEN" & vbCrLf
            sSQL &= "     ,TM_CODE CD01" & vbCrLf
            sSQL &= "     ,TM_CODE CD02" & vbCrLf
            sSQL &= "     ,TM_CODE CD08" & vbCrLf
            sSQL &= " WHERE" & vbCrLf
            '              --契約者マスタ
            sSQL &= "      TUM.KI = KEI.KI(+)" & vbCrLf
            sSQL &= "  AND TUM.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+)" & vbCrLf
            '              --積立金入金
            sSQL &= "  AND TUM.KI = NYU.KI(+)" & vbCrLf
            sSQL &= "  AND TUM.KEIYAKUSYA_CD = NYU.KEIYAKUSYA_CD(+)" & vbCrLf
            sSQL &= "  AND TUM.SEIKYU_KAISU = NYU.SEIKYU_KAISU(+)" & vbCrLf
            sSQL &= "  AND TUM.TUMITATE_KBN = NYU.TUMITATE_KBN(+)" & vbCrLf
            '              --事務委託先マスタ
            sSQL &= "  AND KEI.KI = ITK.KI(+)" & vbCrLf
            sSQL &= "  AND KEI.JIMUITAKU_CD = ITK.ITAKU_CD(+)" & vbCrLf
            '              --前期積立金返還
            sSQL &= "  AND TUM.KI = ZEN.KI(+)" & vbCrLf
            sSQL &= "  AND TUM.KEIYAKUSYA_CD = ZEN.KEIYAKUSYA_CD(+)" & vbCrLf
            '              --契約区分
            sSQL &= "  AND KEI.KEIYAKU_KBN = CD01.MEISYO_CD(+)" & vbCrLf
            sSQL &= "  AND 1 = CD01.SYURUI_KBN(+)" & vbCrLf
            '              --契約状況
            sSQL &= "  AND KEI.KEIYAKU_JYOKYO = CD02.MEISYO_CD(+)" & vbCrLf
            sSQL &= "  AND 2 = CD02.SYURUI_KBN(+)" & vbCrLf
            '              --請求返還状況
            sSQL &= "  AND TUM.SEIKYU_HENKAN_KBN = CD08.MEISYO_CD(+)" & vbCrLf
            sSQL &= "  AND 8 = CD08.SYURUI_KBN(+)" & vbCrLf

            '     -- 条件
            sSQL &= "  AND TUM.KI = " & numKI.Value & vbCrLf
            '↓2018/03/13 UPD 請求ベースの出力に修正
            'sSQL &= "  AND TUM.DATA_FLG = 1" & vbCrLf
            sSQL &= "  AND TUM.SAGAKU_SEIKYU_KIN <> 0" & vbCrLf
            '↑2018/03/13 UPD
            sSQL &= "  AND TUM.TUMITATE_KBN = 1" & vbCrLf  '2016/03/10　追加

            '==必須条件=======================
            '請求回数FROMTO
            sSQL &= " AND TUM.SEIKYU_KAISU BETWEEN " & numSEIKYU_KAISU_Fm.Value & " and " & numSEIKYU_KAISU_To.Value & vbCrLf
            '請求・返還日FROMTO
            sSQL &= " AND TUM.SEIKYU_DATE BETWEEN TO_DATE('" & Format(dateSEIKYU_Ymd_Fm.Value, "yyyy/MM/dd") & "') and TO_DATE('" & Format(dateSEIKYU_Ymd_To.Value, "yyyy/MM/dd") & "')" & vbCrLf

            '請求・返還区分
            strChekVal = ""
            If chkSEIKYU_HENKAN_KBN_1.Checked And chkSEIKYU_HENKAN_KBN_2.Checked And chkSEIKYU_HENKAN_KBN_3.Checked And chkSEIKYU_HENKAN_KBN_4.Checked Then
                '全チェック
            Else
                '請求(新規)
                If chkSEIKYU_HENKAN_KBN_1.Checked Then
                    strChekVal = "1"
                End If
                '一部請求
                If chkSEIKYU_HENKAN_KBN_2.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "2"
                    Else
                        strChekVal += ",2"
                    End If
                End If
                '一部返還
                If chkSEIKYU_HENKAN_KBN_3.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "3"
                    Else
                        strChekVal += ",3"
                    End If
                End If
                '全額返還
                If chkSEIKYU_HENKAN_KBN_4.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "4"
                    Else
                        strChekVal += ",4"
                    End If
                End If
                'SQL作成
                If strChekVal.Length > 0 Then
                    sSQL += " AND TUM.SEIKYU_HENKAN_KBN IN( " & strChekVal & ")" & vbCrLf
                End If
            End If

            '入金・振込状況
            strChekVal = ""
            If chkNYUKIN_KBN_1.Checked And chkNYUKIN_KBN_2.Checked And chkNYUKIN_KBN_3.Checked Then
                '全チェック
                '2018/08/22 入金請求済のみ入金請求日を見るに修正 ADD START
                sSQL += " AND ((TUM.NYUKIN_KBN IN(1,2) AND NYU.NYUKIN_DATE BETWEEN TO_DATE('" & Format(dateNYUKIN_Ymd_Fm.Value, "yyyy/MM/dd") & "') and TO_DATE('" & Format(dateNYUKIN_Ymd_To.Value, "yyyy/MM/dd") & "')) OR TUM.NYUKIN_KBN IS NULL )" & vbCrLf
                '2018/08/22 ADD END
            Else
                '入金・振込済
                If chkNYUKIN_KBN_1.Checked Then
                    strChekVal = "1"
                End If
                '一部入金
                If chkNYUKIN_KBN_3.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "2"
                    Else
                        strChekVal += ",2"
                    End If
                End If
                '未入金・未振込
                If chkNYUKIN_KBN_2.Checked Then
                    'SQL作成
                    If strChekVal.Length = 0 Then
                        sSQL += " AND TUM.NYUKIN_KBN IS NULL" & vbCrLf
                    Else
                        '2018/08/22 入金請求済のみ入金請求日を見るに修正 UPDATE START
                        'sSQL += " AND (TUM.NYUKIN_KBN IN( " & strChekVal & ") OR TUM.NYUKIN_KBN IS NULL )" & vbCrLf
                        sSQL += " AND ((TUM.NYUKIN_KBN IN( " & strChekVal & ") AND NYU.NYUKIN_DATE BETWEEN TO_DATE('" & Format(dateNYUKIN_Ymd_Fm.Value, "yyyy/MM/dd") & "') and TO_DATE('" & Format(dateNYUKIN_Ymd_To.Value, "yyyy/MM/dd") & "')) OR TUM.NYUKIN_KBN IS NULL )" & vbCrLf
                        '2018/08/22 UPDATE END
                    End If
                Else
                    'SQL作成
                    If strChekVal.Length > 0 Then
                        sSQL += " AND TUM.NYUKIN_KBN IN( " & strChekVal & ")" & vbCrLf
                        '2018/08/22 入金請求済のみ入金請求日を見るに修正 UPDATE START
                        sSQL &= " AND NYU.NYUKIN_DATE BETWEEN TO_DATE('" & Format(dateNYUKIN_Ymd_Fm.Value, "yyyy/MM/dd") & "') and TO_DATE('" & Format(dateNYUKIN_Ymd_To.Value, "yyyy/MM/dd") & "')" & vbCrLf
                        '2018/08/22 UPDATE END
                    End If
                End If

            End If

            '==任意条件=======================
            '契約区分FROMTO
            If cboKEIYAKU_KBN_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.KEIYAKU_KBN BETWEEN " & cboKEIYAKU_KBN_Cd_Fm.Text & " and " & cboKEIYAKU_KBN_Cd_To.Text & vbCrLf
            End If

            '事務委託先FROMTO
            If cboITAKU_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.JIMUITAKU_CD BETWEEN " & cboITAKU_Cd_Fm.Text & " and " & cboITAKU_Cd_To.Text & vbCrLf
            End If

            '契約者FROMTO
            If cboKEIYAKUSYA_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.KEIYAKUSYA_CD BETWEEN " & cboKEIYAKUSYA_Cd_Fm.Text & " and " & cboKEIYAKUSYA_Cd_To.Text & vbCrLf
            End If

            sSQL &= " ORDER BY" & vbCrLf
            sSQL &= "     TUM.KI" & vbCrLf
            sSQL &= "    ,KEI.JIMUITAKU_CD" & vbCrLf
            sSQL &= "    ,TUM.KEIYAKUSYA_CD" & vbCrLf
            sSQL &= "    ,TUM.SEIKYU_KAISU" & vbCrLf
            sSQL &= "    ,NYU.NYUKIN_KAISU" & vbCrLf

            'ＳＱＬ
            wSQL = sSQL

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
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
            'pblnTextChange = False 'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL

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
        Dim ret As Boolean = False
        Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

        Try
            '初期値
            numKI.Text = clsNENDO_KI.pKI
            '請求回数
            numSEIKYU_KAISU_Fm.Value = 1
            numSEIKYU_KAISU_To.Value = 999
            '請求・返還日
            dateSEIKYU_Ymd_Fm.Value = clsNENDO_KI.pJIGYO_NENDO_byDate
            dateSEIKYU_Ymd_To.Value = clsNENDO_KI.pJIGYO_SYURYO_NENDO_byDate
            '入金・振込日
            dateNYUKIN_Ymd_Fm.Value = clsNENDO_KI.pJIGYO_NENDO_byDate
            dateNYUKIN_Ymd_To.Value = clsNENDO_KI.pJIGYO_SYURYO_NENDO_byDate

            '互助金の種類
            chkSEIKYU_HENKAN_KBN_1.Checked = True
            chkSEIKYU_HENKAN_KBN_2.Checked = True
            chkSEIKYU_HENKAN_KBN_3.Checked = True
            chkSEIKYU_HENKAN_KBN_4.Checked = True
            '入力状況
            chkNYUKIN_KBN_1.Checked = True
            chkNYUKIN_KBN_2.Checked = True
            chkNYUKIN_KBN_3.Checked = True

            ret = True
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            clsNENDO_KI = Nothing
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
            wkControlName = "請求回数"
            If numSEIKYU_KAISU_Fm.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numSEIKYU_KAISU_Fm.Focus() : Exit Try
            End If
            If numSEIKYU_KAISU_To.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numSEIKYU_KAISU_To.Focus() : Exit Try
            End If
            wkControlName = "請求・返還日"
            If dateSEIKYU_Ymd_Fm.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : dateSEIKYU_Ymd_Fm.Focus() : Exit Try
            End If
            If dateSEIKYU_Ymd_To.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : dateSEIKYU_Ymd_To.Focus() : Exit Try
            End If
            wkControlName = "入金・振込日"
            If dateNYUKIN_Ymd_Fm.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : dateNYUKIN_Ymd_Fm.Focus() : Exit Try
            End If
            If dateNYUKIN_Ymd_To.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : dateNYUKIN_Ymd_To.Focus() : Exit Try
            End If


            wkControlName = "請求・返還区分"
            If chkSEIKYU_HENKAN_KBN_1.Checked = True Or chkSEIKYU_HENKAN_KBN_2.Checked = True Or chkSEIKYU_HENKAN_KBN_3.Checked = True Or chkSEIKYU_HENKAN_KBN_4.Checked = True Then
                '何もしない
            Else
                Call Show_MessageBox_Add("W008", wkControlName) : chkSEIKYU_HENKAN_KBN_1.Focus() : Exit Try
            End If
            wkControlName = "入金・振込状況"
            If chkNYUKIN_KBN_1.Checked = True Or chkNYUKIN_KBN_2.Checked = True Or chkNYUKIN_KBN_3.Checked = True Then
                '何もしない
            Else
                Call Show_MessageBox_Add("W008", wkControlName) : chkNYUKIN_KBN_1.Focus() : Exit Try
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
            '請求回数範囲
            If f_Daisyo_Check(numSEIKYU_KAISU_Fm, numSEIKYU_KAISU_To, "請求回数", True, 2) = False Then
                Return False
            End If

            '請求・返還日範囲
            If f_Daisyo_Check(dateSEIKYU_Ymd_Fm, dateSEIKYU_Ymd_To, "請求・返還日", True, 2) = False Then
                Exit Try
            End If

            '入金・振込状況範囲
            If f_Daisyo_Check(dateNYUKIN_Ymd_Fm, dateNYUKIN_Ymd_To, "入金・振込状況", True, 2) = False Then
                Exit Try
            End If

            '契約区分
            If f_Daisyo_Check(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Cd_To, "契約区分", True, 1) = False Then
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

    '2021/04/13 JBD9020 R03年度追加基金対応 ADD START
#Region "cmdExcel_Click EXCEL出力ボタンクリック処理"
    ''' <summary>
    ''' EXCEL出力ボタンクリック時処理
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
            If Not f_make_SQL(1, wkSql) Then
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
#Region "f_makeExcel EXCELデータ生成"
    ''' <summary>
    ''' EXCELデータ生成
    ''' </summary>
    ''' <param name="wkDT"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function f_makeExcel(ByVal wkDT As DataTable) As Boolean
        Dim ret As Boolean = False
        Dim filNm As String = "生産者積立金等請求返還一覧表_"
        Dim xl As New Excel

        Try

            '件数確認
            If wkDT.Rows.Count <= 0 Then
                Show_MessageBox("I002", "") '該当データが存在しません。
                Exit Try
            End If

            If pKikin2 Then
                filNm = "生産者積立金等請求返還一覧表(追加納付)_"
            End If
            'ファイル出力パス
            If f_FileDialog("xlsx", filNm) = False Then
                Exit Try
            End If
            If filNm = "" Then
                Exit Try
            End If

            'テンプレートファイルの保存
            If xl.SetExcelFile_xlsx("生産者積立金等請求返還一覧表.xlsx", filNm) = False Then
                '家畜防疫互助基金事業状況表
                Exit Try
            End If

            Me.Cursor = Cursors.WaitCursor

            'テンプレートファイルのOPEN保存
            If xl.XlOpen_xlsx(filNm, "Sheet1") = False Then
                Exit Try
            End If

            'データ作成
            xl.SetdataCell(2, 1, wkDT.Rows(0)("TAISYO_KI") & "　" & wkDT.Rows(0)("SEIKYU_HENKAN_KBN_HED") & "　" & wkDT.Rows(0)("SEIKYU_DATE_HED") & "　" & wkDT.Rows(0)("NYUKIN_DATE_HED"))

            'PrgBar.Visible = True
            'PrgBar.Minimum = 0
            'PrgBar.Maximum = wkDT.Rows.Count
            'PrgBar.Minimum = 0

            Dim rowMaxRow As Integer
            Dim rowWkCnt As Integer
            Dim rowPos As Integer
            Dim rowCnt As Integer

            rowPos = 4      '開始位置 #78対応
            rowCnt = 1
            rowMaxRow = 500  '最大配列件数
            rowWkCnt = 0
            xl.SetRangeCopy(rowPos & ":" & rowPos, wkDT.Rows.Count - 1)      '行コピー

            '鳥区分
            Dim data(rowMaxRow, 26) As Object
            Dim dataS(rowMaxRow, 26) As Object
            For Each wkRow As DataRow In wkDT.Rows

                'PrgBar.Value = rowCnt
                If CInt(WordHenkan("N", "S", wkRow("NYUKAISU"))) <= 1 Then
                    data(rowWkCnt, 0) = WordHenkan("N", "S", wkRow("JIMUITAKU_CD"))
                    data(rowWkCnt, 1) = WordHenkan("N", "S", wkRow("ITAKU_NAME"))
                    data(rowWkCnt, 2) = WordHenkan("N", "S", wkRow("KEIYAKUSYA_CD"))
                    data(rowWkCnt, 3) = WordHenkan("N", "S", wkRow("KEIYAKUSYA_NAME"))
                    data(rowWkCnt, 4) = WordHenkan("N", "S", wkRow("KEIYAKU_KBN_NAME"))
                    data(rowWkCnt, 5) = WordHenkan("N", "S", wkRow("KEIYAKU_JYOKYO_NAME"))
                    data(rowWkCnt, 6) = WordHenkan("N", "S", wkRow("SEIKYU_HENKAN_KBN_NAME"))
                    data(rowWkCnt, 7) = WordHenkan("N", "S", wkRow("SEIKYU_KAISU"))
                    data(rowWkCnt, 8) = WordHenkan("N", "S", wkRow("SEIKYU_DATEX"))
                    data(rowWkCnt, 9) = WordHenkan("N", "S", wkRow("NOFUKIGEN_DATEX"))
                    data(rowWkCnt, 10) = WordHenkan("N", "S", wkRow("TUMITATE_KIN"))
                    data(rowWkCnt, 11) = WordHenkan("N", "S", wkRow("TESURYO"))
                    data(rowWkCnt, 12) = WordHenkan("N", "S", wkRow("SEIKYU_KIN"))
                    data(rowWkCnt, 13) = WordHenkan("N", "S", wkRow("HENKAN_KAKUTEI_KIN"))
                    data(rowWkCnt, 14) = WordHenkan("N", "S", wkRow("SAGAKU_SEIKYU_KIN_NOFU"))
                    data(rowWkCnt, 15) = WordHenkan("N", "S", wkRow("SAGAKU_SEIKYU_KIN_MINOFU"))
                    data(rowWkCnt, 16) = WordHenkan("N", "S", wkRow("NYUKIN_INFO"))
                End If
                data(rowWkCnt, 17) = WordHenkan("N", "S", wkRow("NYU_NOFUKIGEN_DATE"))
                data(rowWkCnt, 18) = WordHenkan("N", "S", wkRow("NYUKIN_TUMITATE"))
                data(rowWkCnt, 19) = WordHenkan("N", "S", wkRow("NYUKIN_TESU"))
                data(rowWkCnt, 20) = WordHenkan("N", "S", wkRow("SEI_TUMITATE_KIN_SANTEI"))
                data(rowWkCnt, 21) = WordHenkan("N", "S", wkRow("NYU_HENKAN_KAKUTEI_KIN"))
                data(rowWkCnt, 22) = WordHenkan("N", "S", wkRow("NYUKIN_GAKU"))
                data(rowWkCnt, 23) = WordHenkan("N", "S", wkRow("NYUKIN_ZAN"))
                data(rowWkCnt, 24) = WordHenkan("N", "S", wkRow("ZAN_NAME"))
                data(rowWkCnt, 25) = WordHenkan("N", "S", wkRow("NYUKIN_DATEX"))

                '配列数の判定
                If rowWkCnt >= rowMaxRow Then
                    '配列セット
                    xl.SetRangeValue(rowPos - rowMaxRow, rowPos, 26, data)
                    rowWkCnt = 0
                ElseIf rowCnt >= wkDT.Rows.Count Then
                    '配列セット
                    xl.SetRangeValue(rowPos - rowWkCnt, rowPos, 26, data)
                Else
                    rowWkCnt = rowWkCnt + 1
                End If

                rowCnt = rowCnt + 1
                rowPos = rowPos + 1
            Next

            dataS(0, 7) = "【総合計】" & CInt(WordHenkan("N", "Z", wkDT.Compute("COUNT(KEIYAKUSYA_CD)", "KEI_NO = 1"))).ToString("#,0") & "人"
            dataS(0, 9) = "【請求】"
            dataS(0, 17) = "【入金】"
            dataS(0, 10) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_TUMITATE_SEI)", "NYUKAISU <= 1"))
            dataS(0, 11) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_TESU_SEI)", "NYUKAISU <= 1"))
            dataS(0, 12) = WordHenkan("N", "Z", wkDT.Compute("SUM(SEI_TUMITATE_KIN_SANTEI_SEI)", "NYUKAISU <= 1"))
            dataS(0, 13) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYU_HENKAN_KAKUTEI_KIN_SEI)", "NYUKAISU< = 1"))
            dataS(0, 14) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_GAKU_SEI)", "NYUKAISU <= 1"))

            dataS(0, 18) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_TUMITATE_NYU)", Nothing))
            dataS(0, 19) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_TESU_NYU)", Nothing))
            dataS(0, 20) = WordHenkan("N", "Z", wkDT.Compute("SUM(SEI_TUMITATE_KIN_SANTEI_NYU)", Nothing))
            dataS(0, 21) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYU_HENKAN_KAKUTEI_KIN_NYU)", Nothing))
            dataS(0, 22) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_GAKU_NYU)", Nothing))
            dataS(0, 23) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_GAKU_SEI)", "NYUKAISU <= 1")) - WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_GAKU_NYU)", Nothing))

            dataS(1, 9) = "【返還】"
            dataS(1, 17) = "【振込】"
            dataS(1, 10) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_TUMITATE_HEN)", "NYUKAISU <= 1"))
            dataS(1, 11) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_TESU_HEN)", "NYUKAISU <= 1"))
            dataS(1, 12) = WordHenkan("N", "Z", wkDT.Compute("SUM(SEI_TUMITATE_KIN_SANTEI_HEN)", "NYUKAISU <= 1"))
            dataS(1, 13) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYU_HENKAN_KAKUTEI_KIN_HEN)", "NYUKAISU <= 1"))
            dataS(1, 14) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_GAKU_HEN)", "NYUKAISU <= 1"))
            dataS(1, 18) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_TUMITATE_FRI)", Nothing))
            dataS(1, 19) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_TESU_FRI)", Nothing))
            dataS(1, 20) = WordHenkan("N", "Z", wkDT.Compute("SUM(SEI_TUMITATE_KIN_SANTEI_FRI)", Nothing))
            dataS(1, 21) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYU_HENKAN_KAKUTEI_KIN_FRI)", Nothing))
            dataS(1, 22) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_GAKU_FRI)", Nothing))
            dataS(1, 23) = WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_GAKU_HEN)", "NYUKAISU <= 1")) - WordHenkan("N", "Z", wkDT.Compute("SUM(NYUKIN_GAKU_FRI)", Nothing))

            '配列セット
            xl.SetRangeValue(rowPos, rowPos + 2, 26, dataS)

            'Excel保存
            xl.XlSave_xlsx(filNm)
            'PrgBar.Visible = False

            ret = True
        Catch ex As Exception
            Show_MessageBox("", ex.Message)
        Finally
            '---- Excelの終了処理
            Call xl.XlClose()

            Me.Cursor = Cursors.Default
        End Try

        Return ret

    End Function
#End Region
    '2021/04/13 JBD9020 R03年度追加基金対応 ADD END
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
