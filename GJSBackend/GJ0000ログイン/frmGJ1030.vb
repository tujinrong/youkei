'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ1030.vb
'*
'*　　②　機能概要　　　　　契約者一覧表（連絡用）
'*
'*　　③　作成日　　　　　　2014/02/02 JBD999
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
Imports Oracle.DataAccess.Client


Public Class frmGJ1030

#Region "***変数定義***"

    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ

    ''' <summary>
    ''' プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True                     '処理ジャンプ

    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "家畜防疫互助基金契約者一覧表(連絡用)"

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

#End Region

#Region "f_setChanged コントロール変更時処理"

    ''' <summary>
    ''' コントロール変更時処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub f_setChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pblnTextChange = True
    End Sub
#End Region

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

        ''対象日の初期化
        ''dateTAISYOBI_Ymd.Value = Format(Now, "yyyy/MM/dd")

        ''チェックボックスの初期化
        ''chkSINKI.Checked = True
        ''chkKEIZOKU.Checked = True
        ''chkCYUSI.Checked = True
        ''chkHAIGYO.Checked = True

        ''期にフォーカスセット
        'numKI.Focus()
        '2015/03/03 JBD368 MOVE ↑↑↑

        pblnTextChange = False             '画面入力内容変更フラグ初期化
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

        ''対象日の初期化
        'dateTAISYOBI_Ymd.Value = Format(Now, "yyyy/MM/dd")

        ''チェックボックスの初期化
        'chkSINKI.Checked = True
        'chkKEIZOKU.Checked = True
        'chkCYUSI.Checked = True
        'chkHAIGYO.Checked = True

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
            'If pblnTextChange Then
            '    '画面に変更があり保存していない場合は、メッセージ表示
            '    If Show_MessageBox("Q007", "") = DialogResult.No Then
            '        '「いいえ」を選択
            '        Exit Sub
            '    End If
            'End If
            ret = f_ObjectClear("")
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
            'If pblnTextChange Then
            '    '画面に変更があり保存していない場合は、メッセージ表示
            '    If Show_MessageBox("Q007", "") = DialogResult.No Then
            '        Exit Try
            '    End If
            'Else
            'If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
            '    '処理を終了しますか？
            '    Exit Try
            'End If
            'End If
            If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                '処理を終了しますか？
                Exit Try
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
    Private Sub s_FormControls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dateTAISYOBI_Ymd.TextChanged

        pblnTextChange = True
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

        Try
            ''--------------------------------------------------
            ''データ取得
            ''--------------------------------------------------
            wkDSRep.Tables.Add(con_ReportName)
            'SQL
            If Not f_make_SQL(0, wkSql) Then
                Exit Try
            End If

            Debug.Print(wkSql)

            'データ取得
            Using wkAdp As New OracleDataAdapter(wkSql, Cnn)
                wkAdp.Fill(wkDSRep, wkDSRep.Tables(0).TableName)
            End Using

            If wkDSRep.Tables(0).Rows.Count > 0 Then
                Dim w As New rptGJ1030
                w.sub1(wkDSRep)

                'Dim result As Integer = rptGJ1030.AddNumbers(5, 3)
                'Dim value = frmGJ1030.f_Report_Output_rptGJ1030(wkDSRep)
                'Using wkAR As New rptGJ1030

                '    'ヘッダ用の値を保管
                '    wkAR.pKIKIN2 = pKikin2      '2017/07/14　追加
                '    ' 用紙サイズを A4横 に設定します。
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

        '#25 ADD START
        Dim sKaishiNen As String
        Dim sSyuryoNen As String
        '#25 ADD END


        Try

            Dim SyoriKI = New Obj_TM_SYORI_NENDO_KI()

            '#25 ADD START
            '期の開始年と終了年の算出
            sKaishiNen = ((numKI.Value - 6) * 3) + 2015 & "/04/01"
            sSyuryoNen = ((numKI.Value - 6) * 3) + 2015 + 2 & "/03/31"
            '#25 ADD END

            sSQL = " SELECT " & vbCrLf
            sSQL += "   TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI" & vbCrLf
            '-- 対象期間
            '#25 ADD START
            sSQL += " ,'対象期：第" & numKI.Value & "期（' || TO_CHAR(TO_DATE('" & sKaishiNen & "'), '""""EEYY""年度～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & sSyuryoNen & "'), '""""EEYY""年度）""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS TAISYO_KI " & vbCrLf
            '#25 ADD END
            '-- 対象日
            sSQL += " ,'対象日：' || TO_CHAR(TO_DATE('" & dateTAISYOBI_Ymd.Value & "'), 'EEYY""年""MM""月""DD""日現在""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS TAISYOBI " & vbCrLf

            '-- 期
            sSQL += " ,KEI.KI AS KI " & vbCrLf
            '-- 契約番号
            sSQL += " ,KEI.KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
            '-- 契約者名
            sSQL += " ,KEI.KEIYAKUSYA_NAME AS KEIYAKUSYA_NAME " & vbCrLf
            '-- 代表者名
            sSQL += " ,KEI.DAIHYO_NAME AS DAIHYO_NAME " & vbCrLf
            '-- 事務委託先
            sSQL += " ,KEI.JIMUITAKU_CD AS JIMUITAKU_CD " & vbCrLf
            '#003 修正START 
            'sSQL += " ,'(' || JIM.ITAKU_RYAKU || ')' AS ITAKU_RYAKU " & vbCrLf
            sSQL += " , JIM.ITAKU_RYAKU  AS ITAKU_RYAKU " & vbCrLf
            '#003 修正END 



            '-- 契約区分
            sSQL += " ,KEI.KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
            '↓2017/07/12 修正 契約区分
            'sSQL += " ,CD01.RYAKUSYO AS KEIYAKU_KBN_NM " & vbCrLf
            sSQL += " ,CD01.MEISYO AS KEIYAKU_KBN_NM " & vbCrLf
            '↑2017/07/12 修正 契約区分
            '-- 契約状況
            sSQL += " ,KEI.KEIYAKU_JYOKYO AS KEIYAKU_JYOKYO " & vbCrLf
            sSQL += " ,CD02.RYAKUSYO AS KEIYAKU_JYOKYO_NM " & vbCrLf
            '-- SEQNO
            sSQL += " ,KEIJOHO.SEQNO AS SEQNO " & vbCrLf
            '-- 変更状況
            sSQL += " ,KEIJOHO.KEIYAKU_HENKO_KBN " & vbCrLf
            sSQL += " ,CD10.RYAKUSYO AS KEIYAKU_HENKO_KBN_NM  " & vbCrLf
            '-- 契約日
            sSQL += " ,KEI.KEIYAKU_DATE AS KEIYAKU_DATE " & vbCrLf
            sSQL += " ,TO_CHAR(KEI.KEIYAKU_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS KEIYAKU_DATE_W " & vbCrLf
            '-- 中止日
            sSQL += " ,KEI.HAIGYO_DATE AS HAIGYO_DATE " & vbCrLf
            sSQL += " ,TO_CHAR(KEI.HAIGYO_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS HAIGYO_DATE_W " & vbCrLf
            '-- 郵便番号
            sSQL += " ,DECODE(KEI.ADDR_POST, NULL, '', ('〒' || SUBSTR(KEI.ADDR_POST,1,3) || '-' || SUBSTR(KEI.ADDR_POST,4,4))) AS ADDR_POST " & vbCrLf
            '-- 住所1-4
            sSQL += " ,KEI.ADDR_1 AS ADDR_1 " & vbCrLf
            sSQL += " ,KEI.ADDR_2 AS ADDR_2 " & vbCrLf
            sSQL += " ,KEI.ADDR_3 AS ADDR_3 " & vbCrLf
            sSQL += " ,KEI.ADDR_4 AS ADDR_4 " & vbCrLf
            '-- 電話1-2
            sSQL += " ,KEI.ADDR_TEL1 AS TEL1 " & vbCrLf
            sSQL += " ,KEI.ADDR_TEL2 AS TEL2 " & vbCrLf
            '-- FAX
            sSQL += " ,KEI.ADDR_FAX AS FAX " & vbCrLf
            '-- E-MAIL
            sSQL += " ,KEI.ADDR_E_MAIL AS E_MAIL " & vbCrLf
            '-- 都道府県
            sSQL += " ,KEI.KEN_CD AS KEN_CD " & vbCrLf
            sSQL += " ,'(' || CD05.RYAKUSYO || ')' AS KEN_NM " & vbCrLf
            '-- 金融機関情報印字有無(1:有 2:無)
            sSQL += " ,JIM.BANK_INJI_KBN AS BANK_INJI_KBN " & vbCrLf
            sSQL += " ,DECODE( JIM.BANK_INJI_KBN, 1, '○', 2, '', NULL) AS BANK_INJI_KBN_NM " & vbCrLf

            'FROM
            sSQL += " FROM TM_KEIYAKU KEI " & vbCrLf
            sSQL += "   ,(SELECT " & vbCrLf
            sSQL += "       SEQNO " & vbCrLf
            sSQL += "      ,KI " & vbCrLf
            sSQL += "      ,KEIYAKUSYA_CD " & vbCrLf
            sSQL += "      ,KEIYAKU_HENKO_KBN " & vbCrLf
            sSQL += "     FROM TT_KEIYAKU_JOHO " & vbCrLf
            '最新(SEQNO)を取得
            sSQL += "        ,(SELECT " & vbCrLf
            sSQL += "            max( SEQNO ) over( partition by KI,KEIYAKUSYA_CD ) AS MAX_SEQNO " & vbCrLf
            sSQL += "          FROM TT_KEIYAKU_JOHO " & vbCrLf
            sSQL += "          WHERE DATA_FLG = 1 " & vbCrLf
            sSQL += "         ) MAX_JOHO " & vbCrLf
            '最新(SEQNO)を取得
            sSQL += "     WHERE SEQNO = MAX_JOHO.MAX_SEQNO " & vbCrLf
            sSQL += "     GROUP BY SEQNO,KI,KEIYAKUSYA_CD,KEIYAKU_HENKO_KBN " & vbCrLf
            sSQL += "    ) KEIJOHO " & vbCrLf
            sSQL += "   ,TM_JIMUITAKU JIM " & vbCrLf
            sSQL += "   ,TM_CODE CD01 " & vbCrLf
            sSQL += "   ,TM_CODE CD02 " & vbCrLf
            sSQL += "   ,TM_CODE CD10 " & vbCrLf
            sSQL += "   ,TM_CODE CD05 " & vbCrLf

            'WHERE
            sSQL += " WHERE " & vbCrLf
            '契約情報
            sSQL += "        KEI.KI = KEIJOHO.KI(+) " & vbCrLf
            sSQL += "    AND KEI.KEIYAKUSYA_CD = KEIJOHO.KEIYAKUSYA_CD(+) " & vbCrLf
            '事務委託先
            sSQL += "    AND KEI.KI = JIM.KI(+) " & vbCrLf
            sSQL += "    AND KEI.JIMUITAKU_CD = JIM.ITAKU_CD(+) " & vbCrLf
            '契約区分
            sSQL += "    AND 1 = CD01.SYURUI_KBN(+) " & vbCrLf
            sSQL += "    AND KEI.KEIYAKU_KBN = CD01.MEISYO_CD(+) " & vbCrLf
            '契約状況
            sSQL += "    AND 2 = CD02.SYURUI_KBN(+) " & vbCrLf
            sSQL += "    AND KEI.KEIYAKU_JYOKYO = CD02.MEISYO_CD(+) " & vbCrLf
            '変更状況
            sSQL += "    AND 10 = CD10.SYURUI_KBN(+) " & vbCrLf
            sSQL += "    AND KEIJOHO.KEIYAKU_HENKO_KBN = CD10.MEISYO_CD(+) " & vbCrLf
            '都道府県
            sSQL += "    AND 5 = CD05.SYURUI_KBN(+) " & vbCrLf
            sSQL += "    AND KEI.KEN_CD = CD05.MEISYO_CD(+) " & vbCrLf


            '==必須条件=======================
            '期
            sSQL += "    AND KEI.KI = " & numKI.Value & vbCrLf
            '対象日(現在)
            'sSQL += "    AND ( KEI.KEIYAKU_DATE <= TO_DATE('" & Format(dateTAISYOBI_Ymd.Value, "yyyy/MM/dd") & "','YYYY/MM/DD')" & vbCrLf
            'sSQL += "       OR KEI.KEIYAKU_DATE IS NULL )" & vbCrLf
            '2021/07/12 JBD9020 新契約日追加 UPD START
            'sSQL += "    AND KEI.KEIYAKU_DATE <= TO_DATE('" & Format(dateTAISYOBI_Ymd.Value, "yyyy/MM/dd") & "','YYYY/MM/DD')" & vbCrLf
            sSQL += "    AND ((KEI.KEIYAKU_JYOKYO <> 3 AND KEI.KEIYAKU_DATE <= TO_DATE('" & Format(dateTAISYOBI_Ymd.Value, "yyyy/MM/dd") & "','YYYY/MM/DD'))" & vbCrLf
            sSQL += "     OR  (KEI.KEIYAKU_JYOKYO = 3))" & vbCrLf
            '2021/07/12 JBD9020 新契約日追加 UPD END
            '契約状況
            If chkSINKI.Checked And chkKEIZOKU.Checked And chkCYUSI.Checked And chkHAIGYO.Checked Then
                '全チェック
            Else
                Dim strKeiyakuKbn As String = ""
                '新規契約者
                If chkSINKI.Checked Then
                    strKeiyakuKbn = "1"
                End If
                '継続契約者
                If chkKEIZOKU.Checked Then
                    If strKeiyakuKbn.Length = 0 Then
                        strKeiyakuKbn = "2"
                    Else
                        strKeiyakuKbn += ",2"
                    End If
                End If
                '中止者
                If chkCYUSI.Checked Then
                    If strKeiyakuKbn.Length = 0 Then
                        strKeiyakuKbn = "3"
                    Else
                        strKeiyakuKbn += ",3"
                    End If
                End If

                '廃業者
                If chkHAIGYO.Checked Then
                    If strKeiyakuKbn.Length > 0 Then
                        sSQL += "    AND (KEI.KEIYAKU_JYOKYO IN( " & strKeiyakuKbn & ")" & vbCrLf
                        sSQL += "     OR KEI.HAIGYO_DATE IS NOT NULL)" & vbCrLf
                    Else
                        sSQL += "    AND KEI.HAIGYO_DATE IS NOT NULL" & vbCrLf
                    End If
                Else
                    If strKeiyakuKbn.Length > 0 Then
                        sSQL += "    AND KEI.KEIYAKU_JYOKYO IN( " & strKeiyakuKbn & ")" & vbCrLf
                    End If
                End If
            End If



            '==任意条件=======================
            '契約区分FROMTO
            If cboKEIYAKU_KBN_Cd_Fm.Text <> "" Then
                sSQL += "    AND KEI.KEIYAKU_KBN BETWEEN " & cboKEIYAKU_KBN_Cd_Fm.Text & " and " & cboKEIYAKU_KBN_Cd_To.Text & vbCrLf
            End If

            '事務委託先FROMTO
            If cboITAKU_Cd_Fm.Text <> "" Then
                sSQL += "    AND KEI.JIMUITAKU_CD BETWEEN " & cboITAKU_Cd_Fm.Text & " and " & cboITAKU_Cd_To.Text & vbCrLf
            End If

            '契約者FROMTO
            If cboKEIYAKUSYA_Cd_Fm.Text <> "" Then
                sSQL += "    AND KEI.KEIYAKUSYA_CD BETWEEN " & cboKEIYAKUSYA_Cd_Fm.Text & " and " & cboKEIYAKUSYA_Cd_To.Text & vbCrLf
            End If

            'ORDER BY
            sSQL += " ORDER BY KEI.KEIYAKUSYA_CD " & vbCrLf

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
            pblnTextChange = False

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
        Dim dstDataSet As New DataSet
        Dim ret As Boolean = False

        Try
            '初期値
            numKI.Text = New Obj_TM_SYORI_NENDO_KI().pKI
            dateTAISYOBI_Ymd.Value = Format(Now, "yyyy/MM/dd")
            chkSINKI.Checked = True
            chkKEIZOKU.Checked = True
            chkCYUSI.Checked = True
            chkHAIGYO.Checked = True

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
            wkControlName = "対象日（現在）"
            If dateTAISYOBI_Ymd.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : dateTAISYOBI_Ymd.Focus() : Exit Try
            End If

            wkControlName = "契約状況"
            If chkSINKI.Checked = True Or chkKEIZOKU.Checked = True Or chkCYUSI.Checked = True Or chkHAIGYO.Checked = True Then
                '何もしない
            Else
                Call Show_MessageBox_Add("W008", wkControlName) : chkSINKI.Focus() : Exit Try
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
