'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ4020.vb
'*
'*　　②　機能概要　　　　　互助金申請情報入力チェックリスト
'*
'*　　③　作成日　　　　　　2015/03/09 JBD999
'*
'*　　④　更新日            2022/02/01 JBD439 R03年度修正
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


Public Class frmGJ4020

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
    Private Const con_ReportName As String = "互助金申請情報入力チェックリスト"

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
    '    'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL START
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
    '    'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL END

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

#Region "認定回数FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :numHASSEI_KAISU_Fm_Validating
    '説明            :認定回数FROM Validatingイベント　　　JBD439 UPD　発生回数を認定回数に変更
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numHASSEI_KAISU_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numHASSEI_KAISU_Fm.Validating

        Call s_From_Validating(numHASSEI_KAISU_Fm, numHASSEI_KAISU_To)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :numHASSEI_KAISU_To_Validating
    '説明            :認定回数TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numHASSEI_KAISU_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numHASSEI_KAISU_To.Validating

        'Call s_To_Validating(numHASSEI_KAISU_To, numHASSEI_KAISU_Fm)

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
            Using wkAdp As New OracleDataAdapter(wkSql, Cnn)
                wkAdp.Fill(wkDSRep, wkDSRep.Tables(0).TableName)
            End Using

            If wkDSRep.Tables(0).Rows.Count > 0 Then
                Dim w As New rptGJ4020
                w.sub1(wkDSRep)
                'Using wkAR As New rptGJ4020

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

        Try
            '対象期・年度の取得
            Dim SyoriKI = New Obj_TM_SYORI_NENDO_KI()

            sSQL = "SELECT "
            sSQL += "    TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI" & vbCrLf
            sSQL &= "   ,KEI.KI AS KI"
            sSQL &= "   ,'対象期・回数：第' || KEI.KI || '期　第' || SIN.HASSEI_KAISU || '回' AS TAISYO_KI"
            sSQL &= "   ,SIN.HASSEI_KAISU AS HASSEI_KAISU"
            sSQL &= "   ,KEI.KEIYAKUSYA_CD AS KEIYAKUSYA_CD"
            sSQL &= "   ,KEI.KEIYAKUSYA_NAME AS KEIYAKUSYA_NAME"
            sSQL &= "   ,KEI.KEN_CD AS KEN_CD"
            sSQL &= "   ,CD05.RYAKUSYO  AS KEN_CD_NM"
            sSQL &= "   ,ITK.ITAKU_RYAKU"
            sSQL &= "   ,CASE"
            sSQL &= "       WHEN ITK.ITAKU_CD = 0 THEN '(' || CD05.RYAKUSYO || ')' "
            sSQL &= "       WHEN ITK.ITAKU_CD = 999 THEN '(' || CD05.RYAKUSYO || ')' "
            sSQL &= "       ELSE '(' || CD05.RYAKUSYO || ')' || ITK.ITAKU_RYAKU"
            sSQL &= "    END ITAKU_RYAKU_NM"
            sSQL &= "   ,KEI.KEIYAKU_KBN AS KEIYAKU_KBN"
            '↓2017/07/13 修正 契約区分
            'sSQL &= "   ,CD01.RYAKUSYO AS KEIYAKU_KBN_NM"
            sSQL &= "   ,CD01.MEISYO AS KEIYAKU_KBN_NM"
            '↑2017/07/13 修正 契約区分
            sSQL &= "   ,SIN.SYORI_JOKYO_KBN AS SYORI_JOKYO_KBN"
            sSQL &= "   ,CD13.RYAKUSYO AS SYORI_JOKYO_KBN_NM"
            sSQL &= "   ,NOJO.NOJO_CD AS NOJO_CD"
            sSQL &= "   ,NOJO.NOJO_NAME AS NOJO_NAME"
            sSQL &= "   ,'(' || NOJO.NOJO_CD || ')' || NOJO.NOJO_NAME AS NOJO_CD_NM"
            sSQL &= "   ,NOJO.ADDR_1 || NOJO.ADDR_2 || NOJO.ADDR_3 || NOJO.ADDR_4 AS NOJO_ADDR"
            sSQL &= "   ,SIN.TORI_KBN AS TORI_KBN"
            sSQL &= "   ,CD07.MEISYO AS TORI_KBN_NM"
            sSQL &= "   ,SIN.GOJOKIN_SYURUI_KBN AS GOJOKIN_SYURUI_KBN"
            sSQL &= "   ,'(' || CD03.RYAKUSYO || ')' AS GOJOKIN_SYURUI_KBN_NM"
            sSQL &= "   ,JOHO.KEIYAKU_HASU AS KEIYAKU_HASU"
            sSQL &= "   ,SIN.KOFU_HASU AS KOFU_HASU"
            sSQL &= "   ,SIN.KOFU_KIN AS KOFU_KIN"
            '↓2022/02/07 JBD439 ADD  R03年度対応　算定金、減額率、交付率を追加
            sSQL &= "   ,SIN.SANTEI_KIN AS SANTEI_KIN"
            sSQL &= "   ,SIN.GENGAKU_RITU AS GENGAKU_RITU"
            sSQL &= "   ,LTRIM(RTRIM(RTRIM(TO_CHAR((SIN.KOFU_RITU),990.999999),0),'.')) || '%'  AS KOFU_RITU "
            '　　　　　 --帳票に互助金交付率を表示するか　2以上の時表示しない
            sSQL &= "   ,KS.KOFU_RITU_CNT"
            '↑2022/02/07 JBD439 ADD 
            sSQL &= "   ,CASE"
            sSQL &= "       WHEN SIN.KOFU_TANKA IS NULL THEN ''"
            sSQL &= "       ELSE '(' || TO_CHAR(SIN.KOFU_TANKA,'9G999') || ')'"
            sSQL &= "    END KOFU_TANKA"
            sSQL &= "   ,SIN.SEI_TUMITATE_KIN AS SEI_TUMITATE_KIN"
            sSQL &= "   ,SIN.KUNI_KOFU_KIN AS KUNI_KOFU_KIN"
            '↓2018/03/14 UPD 
            ''↓2022/02/07 JBD439 UPD　R03年度対応　互助金減額後を追加 互助金算定額の表示内容を変更　落ちることがあったので集計の仕方を変更
            ''　　　　　 --互助金算定額
            ''sSQL &= "   ,SUM(CASE WHEN SIN.GOJOKIN_SYURUI_KBN = 1 THEN SIN.KOFU_KIN END) OVER ( PARTITION BY SIN.KI,SIN.HASSEI_KAISU ORDER BY SIN.KI,SIN.HASSEI_KAISU ) as KOFU_KIN_1_SOKEI"
            ''sSQL &= "   ,SUM(CASE WHEN SIN.GOJOKIN_SYURUI_KBN = 2 THEN SIN.KOFU_KIN END) OVER ( PARTITION BY SIN.KI,SIN.HASSEI_KAISU ORDER BY SIN.KI,SIN.HASSEI_KAISU ) as KOFU_KIN_2_SOKEI"
            ''sSQL &= "   ,SUM(SIN.KOFU_KIN) OVER (PARTITION BY SIN.KI,SIN.HASSEI_KAISU ORDER BY SIN.KI,SIN.HASSEI_KAISU ) AS KOFU_KIN_SOKEI"
            ''　　　　　 --積立金部分
            'sSQL &= "   ,SUM(CASE WHEN SIN.GOJOKIN_SYURUI_KBN = 1 THEN SIN.SEI_TUMITATE_KIN END) OVER ( PARTITION BY SIN.KI,SIN.HASSEI_KAISU ORDER BY SIN.KI,SIN.HASSEI_KAISU ) as SEI_TUMITATE_KIN_1_SOKEI"
            'sSQL &= "   ,SUM(CASE WHEN SIN.GOJOKIN_SYURUI_KBN = 2 THEN SIN.SEI_TUMITATE_KIN END) OVER ( PARTITION BY SIN.KI,SIN.HASSEI_KAISU ORDER BY SIN.KI,SIN.HASSEI_KAISU ) as SEI_TUMITATE_KIN_2_SOKEI"
            'sSQL &= "   ,SUM(SIN.SEI_TUMITATE_KIN) OVER (PARTITION BY SIN.KI,SIN.HASSEI_KAISU ORDER BY SIN.KI,SIN.HASSEI_KAISU ) AS SEI_TUMITATE_KIN_SOKEI"
            ''　　　　　 --国庫交付額
            'sSQL &= "   ,SUM(CASE WHEN SIN.GOJOKIN_SYURUI_KBN = 1 THEN SIN.KUNI_KOFU_KIN END) OVER ( PARTITION BY SIN.KI,SIN.HASSEI_KAISU ORDER BY SIN.KI,SIN.HASSEI_KAISU ) as KUNI_KOFU_KIN_1_SOKEI"
            'sSQL &= "   ,SUM(CASE WHEN SIN.GOJOKIN_SYURUI_KBN = 2 THEN SIN.KUNI_KOFU_KIN END) OVER ( PARTITION BY SIN.KI,SIN.HASSEI_KAISU ORDER BY SIN.KI,SIN.HASSEI_KAISU ) as KUNI_KOFU_KIN_2_SOKEI"
            'sSQL &= "   ,SUM(SIN.KUNI_KOFU_KIN) OVER (PARTITION BY SIN.KI,SIN.HASSEI_KAISU ORDER BY SIN.KI,SIN.HASSEI_KAISU ) AS KUNI_KOFU_KIN_SOKEI"
            ''　　　　　  --互助金減額後  
            sSQL &= "   ,SS.KOFU_KIN_1_SOKEI AS KOFU_KIN_1_SOKEI"
            sSQL &= "   ,SS.KOFU_KIN_2_SOKEI AS KOFU_KIN_2_SOKEI"
            sSQL &= "   ,SS.KOFU_KIN_SOKEI AS KOFU_KIN_SOKEI"
            '             --互助金算定額
            sSQL &= "   ,SS.SANTEI_KIN_1_SOKEI AS SANTEI_KIN_1_SOKEI"
            sSQL &= "   ,SS.SANTEI_KIN_2_SOKEI AS SANTEI_KIN_2_SOKEI"
            sSQL &= "   ,SS.SANTEI_KIN_SOKEI AS SANTEI_KIN_SOKEI"
            '　　　　　 --積立金部分
            sSQL &= "   ,SS.SEI_TUMITATE_KIN_1_SOKEI AS SEI_TUMITATE_KIN_1_SOKEI"
            sSQL &= "   ,SS.SEI_TUMITATE_KIN_2_SOKEI AS SEI_TUMITATE_KIN_2_SOKEI"
            sSQL &= "   ,SS.SEI_TUMITATE_KIN_SOKEI AS SEI_TUMITATE_KIN_SOKEI"
            '　　　　　 --国庫交付額
            sSQL &= "   ,SS.KUNI_KOFU_KIN_1_SOKEI AS KUNI_KOFU_KIN_1_SOKEI"
            sSQL &= "   ,SS.KUNI_KOFU_KIN_2_SOKEI AS KUNI_KOFU_KIN_2_SOKEI"
            sSQL &= "   ,SS.KUNI_KOFU_KIN_SOKEI AS KUNI_KOFU_KIN_SOKEI"
            '↑2022/02/07 JBD439 UPD
            '　　　　　 --明細件数
            sSQL &= "   ,COUNT(SIN.KEIYAKUSYA_CD) OVER( PARTITION BY SIN.KI,SIN.HASSEI_KAISU,SIN.KEIYAKUSYA_CD ) AS DTL_CNT"
            '↑2018/03/14 UPD 

            sSQL &= " FROM TT_KOFU_SINSEI SIN"
            '↓2022/02/07 JBD439 UPD　R03年度対応　互助金減額後を追加 互助金算定額の表示内容を変更　落ちることがあったので集計の仕方を変更
            sSQL &= ",(SELECT " & vbCrLf
            sSQL &= "    SIN.KI AS KI" & vbCrLf
            sSQL &= "   ,SIN.HASSEI_KAISU AS HASSEI_KAISU" & vbCrLf
            '　　　　  --互助金減額後  
            sSQL &= "   ,SUM(CASE WHEN SIN.GOJOKIN_SYURUI_KBN = 1 THEN SIN.KOFU_KIN END) as KOFU_KIN_1_SOKEI" & vbCrLf
            sSQL &= "   ,SUM(CASE WHEN SIN.GOJOKIN_SYURUI_KBN = 2 THEN SIN.KOFU_KIN END) as KOFU_KIN_2_SOKEI" & vbCrLf
            sSQL &= "   ,SUM(SIN.KOFU_KIN) AS KOFU_KIN_SOKEI" & vbCrLf
            '             --互助金算定額
            sSQL &= "   ,SUM(CASE WHEN SIN.GOJOKIN_SYURUI_KBN = 1 THEN SIN.SANTEI_KIN END) as SANTEI_KIN_1_SOKEI" & vbCrLf
            sSQL &= "   ,SUM(CASE WHEN SIN.GOJOKIN_SYURUI_KBN = 2 THEN SIN.SANTEI_KIN END) as SANTEI_KIN_2_SOKEI" & vbCrLf
            sSQL &= "   ,SUM(SIN.SANTEI_KIN) AS SANTEI_KIN_SOKEI" & vbCrLf
            '　　　　　 --積立金部分
            sSQL &= "   ,SUM(CASE WHEN SIN.GOJOKIN_SYURUI_KBN = 1 THEN SIN.SEI_TUMITATE_KIN END) as SEI_TUMITATE_KIN_1_SOKEI" & vbCrLf
            sSQL &= "   ,SUM(CASE WHEN SIN.GOJOKIN_SYURUI_KBN = 2 THEN SIN.SEI_TUMITATE_KIN END) as SEI_TUMITATE_KIN_2_SOKEI" & vbCrLf
            sSQL &= "   ,SUM(SIN.SEI_TUMITATE_KIN) AS SEI_TUMITATE_KIN_SOKEI" & vbCrLf
            '　　　　　 --国庫交付額　
            sSQL &= "   ,SUM(CASE WHEN SIN.GOJOKIN_SYURUI_KBN = 1 THEN SIN.KUNI_KOFU_KIN END) as KUNI_KOFU_KIN_1_SOKEI" & vbCrLf
            sSQL &= "   ,SUM(CASE WHEN SIN.GOJOKIN_SYURUI_KBN = 2 THEN SIN.KUNI_KOFU_KIN END) as KUNI_KOFU_KIN_2_SOKEI" & vbCrLf
            sSQL &= "   ,SUM(SIN.KUNI_KOFU_KIN) AS KUNI_KOFU_KIN_SOKEI"

            sSQL &= " FROM TT_KOFU_SINSEI SIN" & vbCrLf
            sSQL &= "     ,TM_KEIYAKU KEI" & vbCrLf
            sSQL &= "     ,TT_KEIYAKU_JOHO JOHO" & vbCrLf
            sSQL &= " WHERE " & vbCrLf
            '             --契約者マスタ
            sSQL &= "     SIN.KI = KEI.KI(+)" & vbCrLf
            sSQL &= " AND SIN.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+)" & vbCrLf
            '             --契約情報
            sSQL &= " AND SIN.KI = JOHO.KI(+)" & vbCrLf
            sSQL &= " AND SIN.KEIYAKUSYA_CD = JOHO.KEIYAKUSYA_CD(+)" & vbCrLf
            sSQL &= " AND SIN.NOJO_CD = JOHO.NOJO_CD(+)" & vbCrLf
            sSQL &= " AND SIN.TORI_KBN = JOHO.TORI_KBN(+)" & vbCrLf
            '             -- 条件
            sSQL &= " AND SIN.KI  = " & numKI.Value & vbCrLf
            sSQL &= " AND JOHO.DATA_FLG = 1" & vbCrLf
            '==必須条件=======================
            '認定回数FROMTO　
            sSQL &= " AND SIN.HASSEI_KAISU BETWEEN " & numHASSEI_KAISU_Fm.Value & " and " & numHASSEI_KAISU_To.Value & vbCrLf
            '互助金の種類
            strChekVal = ""
            If chkGOJOKIN_SYURUI_KBN_1.Checked And chkGOJOKIN_SYURUI_KBN_2.Checked Then
                '全チェック
            Else
                '経営支援互助金
                If chkGOJOKIN_SYURUI_KBN_1.Checked Then
                    strChekVal = "1"
                End If
                '焼却・埋却互助金
                If chkGOJOKIN_SYURUI_KBN_2.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "2"
                    Else
                        strChekVal += ",2"
                    End If
                End If
                'SQL作成
                If strChekVal.Length > 0 Then
                    sSQL += " AND SIN.GOJOKIN_SYURUI_KBN IN( " & strChekVal & ")" & vbCrLf
                End If
            End If
            '入力状況
            strChekVal = ""
            If chkSYORI_JOKYO_KBN_1.Checked And chkSYORI_JOKYO_KBN_2.Checked And chkSYORI_JOKYO_KBN_3.Checked Then
                '全チェック
            Else
                '入力中
                If chkSYORI_JOKYO_KBN_1.Checked Then
                    strChekVal = "1"
                End If
                '審査中
                If chkSYORI_JOKYO_KBN_2.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "2"
                    Else
                        strChekVal += ",2"
                    End If
                End If
                '交付確定
                If chkSYORI_JOKYO_KBN_3.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "3,4"
                    Else
                        strChekVal += ",3,4"
                    End If
                End If
                'SQL作成
                If strChekVal.Length > 0 Then
                    sSQL += " AND SIN.SYORI_JOKYO_KBN IN( " & strChekVal & ")" & vbCrLf
                End If
            End If

            '==任意条件=======================
            '契約区分FROMTO
            If cboKEIYAKU_KBN_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.KEIYAKU_KBN BETWEEN " & cboKEIYAKU_KBN_Cd_Fm.Text & " and " & cboKEIYAKU_KBN_Cd_To.Text & vbCrLf
            End If
            '都道府県FROMTO
            If cboKEN_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.KEN_CD BETWEEN " & cboKEN_Cd_Fm.Text & " and " & cboKEN_Cd_To.Text & vbCrLf
            End If
            '事務委託先FROMTO
            If cboITAKU_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.JIMUITAKU_CD BETWEEN " & cboITAKU_Cd_Fm.Text & " and " & cboITAKU_Cd_To.Text & vbCrLf
            End If
            '契約者FROMTO
            If cboKEIYAKUSYA_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.KEIYAKUSYA_CD BETWEEN " & cboKEIYAKUSYA_Cd_Fm.Text & " and " & cboKEIYAKUSYA_Cd_To.Text & vbCrLf
            End If
            '減額率 
            If chkGENGAKU_RITU1.Checked = True And chkGENGAKU_RITU2.Checked = False Then
                sSQL += " AND SIN.GENGAKU_RITU > 0 "
            ElseIf chkGENGAKU_RITU1.Checked = False And chkGENGAKU_RITU2.Checked = True Then
                sSQL += " AND SIN.GENGAKU_RITU = 0 "
            End If
            sSQL &= " GROUP BY" & vbCrLf
            sSQL &= "     SIN.KI" & vbCrLf
            sSQL &= "    ,SIN.HASSEI_KAISU " & vbCrLf
            sSQL &= " ORDER BY" & vbCrLf
            sSQL &= "     SIN.KI" & vbCrLf
            sSQL &= "    ,SIN.HASSEI_KAISU) SS" & vbCrLf

            '交付率の件数
            sSQL &= "   ,(SELECT " & vbCrLf
            '　　　　　 --帳票に互助金交付率を表示するか　2以上の時表示しない
            sSQL &= " COUNT(DISTINCT SIN.KOFU_RITU) AS KOFU_RITU_CNT" & vbCrLf
            sSQL &= " FROM TT_KOFU_SINSEI SIN" & vbCrLf
            sSQL &= "     ,TM_KEIYAKU KEI" & vbCrLf
            sSQL &= "     ,TT_KEIYAKU_JOHO JOHO" & vbCrLf
            sSQL &= " WHERE " & vbCrLf
            '             --契約者マスタ
            sSQL &= "     SIN.KI = KEI.KI(+)" & vbCrLf
            sSQL &= " AND SIN.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+)" & vbCrLf
            '             --契約情報
            sSQL &= " AND SIN.KI = JOHO.KI(+)" & vbCrLf
            sSQL &= " AND SIN.KEIYAKUSYA_CD = JOHO.KEIYAKUSYA_CD(+)" & vbCrLf
            sSQL &= " AND SIN.NOJO_CD = JOHO.NOJO_CD(+)" & vbCrLf
            sSQL &= " AND SIN.TORI_KBN = JOHO.TORI_KBN(+)" & vbCrLf
            '             -- 条件
            sSQL &= " AND SIN.KI  = " & numKI.Value & vbCrLf
            sSQL &= " AND JOHO.DATA_FLG = 1" & vbCrLf
            '==必須条件=======================
            '↓2022/02/07 JBD439 UPD　R03年度対応　発生回数を認定回数に変更
            '’発生回数FROMTO
            '認定回数FROMTO　
            '↑2022/02/07 JBD439 UPD
            sSQL &= " AND SIN.HASSEI_KAISU BETWEEN " & numHASSEI_KAISU_Fm.Value & " and " & numHASSEI_KAISU_To.Value & vbCrLf
            '互助金の種類
            strChekVal = ""
            If chkGOJOKIN_SYURUI_KBN_1.Checked And chkGOJOKIN_SYURUI_KBN_2.Checked Then
                '全チェック
            Else
                '経営支援互助金
                If chkGOJOKIN_SYURUI_KBN_1.Checked Then
                    strChekVal = "1"
                End If
                '焼却・埋却互助金
                If chkGOJOKIN_SYURUI_KBN_2.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "2"
                    Else
                        strChekVal += ",2"
                    End If
                End If
                'SQL作成
                If strChekVal.Length > 0 Then
                    sSQL += " AND SIN.GOJOKIN_SYURUI_KBN IN( " & strChekVal & ")" & vbCrLf
                End If
            End If
            '入力状況
            strChekVal = ""
            If chkSYORI_JOKYO_KBN_1.Checked And chkSYORI_JOKYO_KBN_2.Checked And chkSYORI_JOKYO_KBN_3.Checked Then
                '全チェック
            Else
                '入力中
                If chkSYORI_JOKYO_KBN_1.Checked Then
                    strChekVal = "1"
                End If
                '審査中
                If chkSYORI_JOKYO_KBN_2.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "2"
                    Else
                        strChekVal += ",2"
                    End If
                End If
                '交付確定
                If chkSYORI_JOKYO_KBN_3.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "3,4"
                    Else
                        strChekVal += ",3,4"
                    End If
                End If
                'SQL作成
                If strChekVal.Length > 0 Then
                    sSQL += " AND SIN.SYORI_JOKYO_KBN IN( " & strChekVal & ")" & vbCrLf
                End If
            End If

            '==任意条件=======================
            '契約区分FROMTO
            If cboKEIYAKU_KBN_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.KEIYAKU_KBN BETWEEN " & cboKEIYAKU_KBN_Cd_Fm.Text & " and " & cboKEIYAKU_KBN_Cd_To.Text & vbCrLf
            End If
            '都道府県FROMTO
            If cboKEN_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.KEN_CD BETWEEN " & cboKEN_Cd_Fm.Text & " and " & cboKEN_Cd_To.Text & vbCrLf
            End If
            '事務委託先FROMTO
            If cboITAKU_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.JIMUITAKU_CD BETWEEN " & cboITAKU_Cd_Fm.Text & " and " & cboITAKU_Cd_To.Text & vbCrLf
            End If
            '契約者FROMTO
            If cboKEIYAKUSYA_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.KEIYAKUSYA_CD BETWEEN " & cboKEIYAKUSYA_Cd_Fm.Text & " and " & cboKEIYAKUSYA_Cd_To.Text & vbCrLf
            End If
            '減額率 
            If chkGENGAKU_RITU1.Checked = True And chkGENGAKU_RITU2.Checked = False Then
                sSQL += " AND SIN.GENGAKU_RITU > 0 "
            ElseIf chkGENGAKU_RITU1.Checked = False And chkGENGAKU_RITU2.Checked = True Then
                sSQL += " AND SIN.GENGAKU_RITU = 0 "
            End If

            sSQL &= ") KS"
            '↑2022/02/07 JBD439 UPD
            sSQL &= "     ,TM_KEIYAKU KEI"
            sSQL &= "     ,TM_KEIYAKU_NOJO NOJO"
            sSQL &= "     ,TT_KEIYAKU_JOHO JOHO"
            sSQL &= "     ,TM_JIMUITAKU ITK"
            sSQL &= "     ,TM_CODE CD01"
            sSQL &= "     ,TM_CODE CD03"
            sSQL &= "     ,TM_CODE CD05"
            sSQL &= "     ,TM_CODE CD07"
            sSQL &= "     ,TM_CODE CD13"
            sSQL &= " WHERE"
            '             --契約者マスタ
            sSQL &= "     SIN.KI = KEI.KI(+)"
            sSQL &= " AND SIN.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+)"
            '             --契約情報
            sSQL &= " AND SIN.KI = JOHO.KI(+)"
            sSQL &= " AND SIN.KEIYAKUSYA_CD = JOHO.KEIYAKUSYA_CD(+)"
            sSQL &= " AND SIN.NOJO_CD = JOHO.NOJO_CD(+)"
            sSQL &= " AND SIN.TORI_KBN = JOHO.TORI_KBN(+)"
            '             --農場マスタ
            sSQL &= " AND SIN.KI = NOJO.KI(+)"
            sSQL &= " AND SIN.KEIYAKUSYA_CD = NOJO.KEIYAKUSYA_CD(+)"
            sSQL &= " AND SIN.NOJO_CD = NOJO.NOJO_CD(+)"
            '             --事務委託先マスタ
            sSQL &= " AND KEI.KI = ITK.KI(+)"
            sSQL &= " AND KEI.JIMUITAKU_CD = ITK.ITAKU_CD(+)"
            '             --契約区分
            sSQL &= " AND KEI.KEIYAKU_KBN = CD01.MEISYO_CD(+)"
            sSQL &= " AND 1 = CD01.SYURUI_KBN(+)"
            '             --互助金の種類
            sSQL &= " AND SIN.GOJOKIN_SYURUI_KBN = CD03.MEISYO_CD(+)"
            sSQL &= " AND 3 = CD03.SYURUI_KBN(+)"
            '             --都道府県
            sSQL &= " AND KEI.KEN_CD = CD05.MEISYO_CD(+)"
            sSQL &= " AND 5 = CD05.SYURUI_KBN(+)"
            '             --鶏の種類
            sSQL &= " AND SIN.TORI_KBN = CD07.MEISYO_CD(+)"
            sSQL &= " AND 7 = CD07.SYURUI_KBN(+)"
            '             --互助金情報入力状況
            sSQL &= " AND SIN.SYORI_JOKYO_KBN = CD13.MEISYO_CD(+)"
            sSQL &= " AND 13 = CD13.SYURUI_KBN(+)"
            '↓2022/02/09 JBD439 ADD　R03年度対応　互助金減額後を追加 互助金算定額の表示内容を変更
            '             --合計
            sSQL &= " AND SIN.KI = SS.KI(+)"
            sSQL &= " AND SIN.HASSEI_KAISU = SS.HASSEI_KAISU(+)"
            '↑2022/02/09 JBD439 ADD
            '             -- 条件
            sSQL &= " AND SIN.KI  = " & numKI.Value
            sSQL &= " AND JOHO.DATA_FLG = 1"
            '==必須条件=======================
            '↓2022/02/07 JBD439 UPD　R03年度対応　発生回数を認定回数に変更
            '’発生回数FROMTO
            '認定回数FROMTO　
            '↑2022/02/07 JBD439 UPD
            sSQL &= " AND SIN.HASSEI_KAISU BETWEEN " & numHASSEI_KAISU_Fm.Value & " and " & numHASSEI_KAISU_To.Value
            '互助金の種類
            strChekVal = ""
            If chkGOJOKIN_SYURUI_KBN_1.Checked And chkGOJOKIN_SYURUI_KBN_2.Checked Then
                '全チェック
            Else
                '経営支援互助金
                If chkGOJOKIN_SYURUI_KBN_1.Checked Then
                    strChekVal = "1"
                End If
                '焼却・埋却互助金
                If chkGOJOKIN_SYURUI_KBN_2.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "2"
                    Else
                        strChekVal += ",2"
                    End If
                End If
                'SQL作成
                If strChekVal.Length > 0 Then
                    sSQL += " AND SIN.GOJOKIN_SYURUI_KBN IN( " & strChekVal & ")" & vbCrLf
                End If
            End If
            '入力状況
            strChekVal = ""
            If chkSYORI_JOKYO_KBN_1.Checked And chkSYORI_JOKYO_KBN_2.Checked And chkSYORI_JOKYO_KBN_3.Checked Then
                '全チェック
            Else
                '入力中
                If chkSYORI_JOKYO_KBN_1.Checked Then
                    strChekVal = "1"
                End If
                '審査中
                If chkSYORI_JOKYO_KBN_2.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "2"
                    Else
                        strChekVal += ",2"
                    End If
                End If
                '交付確定
                If chkSYORI_JOKYO_KBN_3.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "3,4"
                    Else
                        strChekVal += ",3,4"
                    End If
                End If
                'SQL作成
                If strChekVal.Length > 0 Then
                    sSQL += " AND SIN.SYORI_JOKYO_KBN IN( " & strChekVal & ")" & vbCrLf
                End If
            End If

            '==任意条件=======================
            '契約区分FROMTO
            If cboKEIYAKU_KBN_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.KEIYAKU_KBN BETWEEN " & cboKEIYAKU_KBN_Cd_Fm.Text & " and " & cboKEIYAKU_KBN_Cd_To.Text & vbCrLf
            End If

            '都道府県FROMTO
            If cboKEN_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.KEN_CD BETWEEN " & cboKEN_Cd_Fm.Text & " and " & cboKEN_Cd_To.Text & vbCrLf
            End If

            '事務委託先FROMTO
            If cboITAKU_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.JIMUITAKU_CD BETWEEN " & cboITAKU_Cd_Fm.Text & " and " & cboITAKU_Cd_To.Text & vbCrLf
            End If

            '契約者FROMTO
            If cboKEIYAKUSYA_Cd_Fm.Text <> "" Then
                sSQL += " AND KEI.KEIYAKUSYA_CD BETWEEN " & cboKEIYAKUSYA_Cd_Fm.Text & " and " & cboKEIYAKUSYA_Cd_To.Text & vbCrLf
            End If

            '↓2022/01/31 JBD439 ADD R03年度対応 減額率チェックボックスの分岐
            '減額率 
            If chkGENGAKU_RITU1.Checked = True And chkGENGAKU_RITU2.Checked = False Then
                sSQL += " AND SIN.GENGAKU_RITU > 0 "
            ElseIf chkGENGAKU_RITU1.Checked = False And chkGENGAKU_RITU2.Checked = True Then
                sSQL += " AND SIN.GENGAKU_RITU = 0 "
            End If
            '↑2022/01/31 JBD439 ADD

            sSQL &= " ORDER BY"
            sSQL &= "     SIN.KI"
            sSQL &= "    ,SIN.HASSEI_KAISU "
            sSQL &= "    ,SIN.KEIYAKUSYA_CD"
            sSQL &= "    ,NOJO.MEISAI_NO"
            sSQL &= "    ,SIN.TORI_KBN"
            sSQL &= "    ,SIN.GOJOKIN_SYURUI_KBN"

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
            '↓2022/02/07 JBD439 UPD　R03年度対応　発生回数を認定回数に変更
            '’発生回数
            '認定回数
            '↑2022/02/07 JBD439 UPD
            numHASSEI_KAISU_Fm.Value = clsNENDO_KI.pHASSEI_KAISU
            numHASSEI_KAISU_To.Value = clsNENDO_KI.pHASSEI_KAISU
            '互助金の種類
            chkGOJOKIN_SYURUI_KBN_1.Checked = True
            chkGOJOKIN_SYURUI_KBN_2.Checked = True
            '入力状況
            chkSYORI_JOKYO_KBN_1.Checked = True
            chkSYORI_JOKYO_KBN_2.Checked = True
            chkSYORI_JOKYO_KBN_3.Checked = True
            '↓ 2022/01/31 JBD439 ADD  R03年度対応　減額率チェックボックス
            '減額率 
            chkGENGAKU_RITU1.Checked = True
            chkGENGAKU_RITU2.Checked = True
            '↑ 2022/01/31 JBD439 ADD

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
            ' wkControlName = "発生回数"
            wkControlName = "認定回数"　　'JBD439 UPD　発生回数を認定回数に変更
            If numHASSEI_KAISU_Fm.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numHASSEI_KAISU_Fm.Focus() : Exit Try
            End If
            If numHASSEI_KAISU_To.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numHASSEI_KAISU_To.Focus() : Exit Try
            End If

            wkControlName = "互助金の種類"
            If chkGOJOKIN_SYURUI_KBN_1.Checked = True Or chkGOJOKIN_SYURUI_KBN_2.Checked = True Then
                '何もしない
            Else
                Call Show_MessageBox_Add("W008", wkControlName) : chkGOJOKIN_SYURUI_KBN_1.Focus() : Exit Try
            End If
            wkControlName = "入力状況"
            If chkSYORI_JOKYO_KBN_1.Checked = True Or chkSYORI_JOKYO_KBN_2.Checked = True Or chkSYORI_JOKYO_KBN_3.Checked = True Then
                '何もしない
            Else
                Call Show_MessageBox_Add("W008", wkControlName) : chkSYORI_JOKYO_KBN_1.Focus() : Exit Try
            End If

            '↓2022/01/31 JBD439 ADD　R03年度対応　家伝法違反減額率チェックボックスのエラー
            wkControlName = "家伝法違反減額率"
            If chkGENGAKU_RITU1.Checked = True Or chkGENGAKU_RITU2.Checked = True Then
                '何もしない
            Else
                Call Show_MessageBox_Add("W008", wkControlName) : chkGENGAKU_RITU1.Focus() : Exit Try
            End If
            '↑2022/01/31 JBD439 ADD

            '==いろいろチェック==================
            ''対象日（現在）チェック
            'Dim dtJIGYO_NENDO = New Obj_TM_SYORI_NENDO_KI().pJIGYO_NENDO_byDate
            'Dim dtJIGYO_SYURYO_NENDO = New Obj_TM_SYORI_NENDO_KI().pJIGYO_SYURYO_NENDO_byDate
            'If dtJIGYO_NENDO >= dateTAISYOBI_Ymd.Value And dtJIGYO_SYURYO_NENDO <= dateTAISYOBI_Ymd.Value Then
            '    wkControlName = "対象期年度以外の対象日（現在）"
            '    Call Show_MessageBox_Add("W029", wkControlName) : dateTAISYOBI_Ymd.Focus() : Exit Try
            'End If

            '==FromToチェック==================
            '↓2022/02/07 JBD439 ADD　R03年度対応　発生回数を認定回数に変更
            ''発生回数範囲　JBD439 UPD　
            'If f_Daisyo_Check(numHASSEI_KAISU_Fm, numHASSEI_KAISU_To, "発生回数", True, 2) = False Then
            '    Return False
            'End If
            '認定回数範囲　
            If f_Daisyo_Check(numHASSEI_KAISU_Fm, numHASSEI_KAISU_To, "認定回数", True, 2) = False Then
                Return False
            End If
            '↑2022/02/07 JBD439 ADD

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
