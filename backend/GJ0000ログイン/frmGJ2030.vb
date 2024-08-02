'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ2030.vb
'*
'*　　②　機能概要　　　　　生産者積立金等請求・返還一覧表
'*
'*　　③　作成日　　　　　　2015/03/12 JBD368
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
Imports JbdGjsReport
Imports System.Data
Imports System.Windows.Forms
Imports System.Collections
Imports System.IO
Imports System.Text




Public Class frmGJ2030

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
    Private Const con_ReportName As String = "生産者積立金等請求・返還一覧表"

    '処理対象期・年度マスタ
    Private pObjTM_SYORI_NENDO_KI As Obj_TM_SYORI_NENDO_KI

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
    'プロシージャ名  :numKI_Validating
    '説明            :期Validatingイベント
    '------------------------------------------------------------------
    Private Sub numKI_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numKI.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        If numKI.Value Is Nothing Then
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
            If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                '処理を終了しますか？
                Exit Try
            End If
            'End If

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
#Region "請求回数"
    '------------------------------------------------------------------
    'プロシージャ名  :numSeiKaisuFrom_Validating
    '説明            :請求回数FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numSeiKaisuFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numSeiKaisuFrom.Validating

        Call s_From_Validating(numSeiKaisuFrom, numSeiKaisuTo)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :numSeiKaisuTo_Validating
    '説明            :請求回数TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numSeiKaisuTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numSeiKaisuTo.Validating

        Call s_To_Validating(numSeiKaisuTo, numSeiKaisuFrom)

    End Sub
#End Region


#Region "s_FormControls_TextChanged 画面コントロールTextChangeイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :s_FormControls_TextChanged
    '説明            :画面コントロールTextChangeイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub s_FormControls_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dateSeikyuYmdFrom.TextChanged

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
            If Not f_make_SQL(wkSql) Then
                Exit Try
            End If

            'Debug.Print(wkSql)

            'データ取得
            Using wkAdp As New OracleDataAdapter(wkSql, Cnn)
                wkAdp.Fill(wkDSRep, wkDSRep.Tables(0).TableName)
            End Using

            If wkDSRep.Tables(0).Rows.Count > 0 Then
                Dim w As New rptGJ2030
                w.sub1(wkDSRep)
                'Using wkAR As New rptGJ2030

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
    'プロシージャ名  :f_make_SQL
    '説明            :帳票データ出力用ＳＱＬ作成
    '引数            :区分
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    ''' <summary>
    ''' ＳＱＬ文作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_make_SQL(ByRef wSQL As String) As Boolean
        Dim ret As Boolean = False

        Try

            wSQL &= "SELECT " & vbCrLf
            '作成日
            wSQL &= "    TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', " & vbCrLf
            wSQL &= "      'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI " & vbCrLf
            '契約区分（ヘッダー）
            Dim strSeikyuKbn As String = ""
            If chkSeikyu.Checked Then
                strSeikyuKbn &= "全額請求"
            End If
            If chkIchiSei.Checked Then
                If strSeikyuKbn.Length > 0 Then
                    strSeikyuKbn &= "、"
                End If
                strSeikyuKbn &= "一部請求"
            End If
            If chkIchiHen.Checked Then
                If strSeikyuKbn.Length > 0 Then
                    strSeikyuKbn &= "、"
                End If
                strSeikyuKbn &= "一部返還"
            End If
            If chkHenkan.Checked Then
                If strSeikyuKbn.Length > 0 Then
                    strSeikyuKbn &= "、"
                End If
                strSeikyuKbn &= "全額返還"
            End If
            wSQL &= "    , '出力区分：" & strSeikyuKbn & "' AS H_SEIKYU_HENKAN_KBN" & vbCrLf
            '対象期、対象年度期間
            If pObjTM_SYORI_NENDO_KI.pKI = numKI.Value Then
                wSQL &= "  , '対象期　：　第" & numKI.Value.ToString & "期（' || " & vbCrLf
                wSQL &= "TO_CHAR(TO_DATE(TO_CHAR(S.JIGYO_NENDO) || '/04/01','YYYY/MM/DD'), 'EEYY""年度""', "
                wSQL &= "'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '～' || " & vbCrLf
                wSQL &= "TO_CHAR(TO_DATE(TO_CHAR(S.JIGYO_SYURYO_NENDO) || '/12/31','YYYY/MM/DD'), 'EEYY""年度""', "
                wSQL &= "'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '）' AS TAISYO_KI " & vbCrLf
            Else
                '対象年度（自）算出
                Dim TaisyoNendoF As String = (((numKI.Value - 6) * 3) + 2015).ToString
                '対象年度（至）算出
                Dim TaisyoNendoT As String = (Integer.Parse(TaisyoNendoF) + 2).ToString

                '事業対象年度日付の設定
                TaisyoNendoF = TaisyoNendoF & "/04/01"
                TaisyoNendoT = DateTime.Parse(TaisyoNendoT & "/04/01").ToString("yyyy/MM/dd")

                Dim culture As Globalization.CultureInfo = New Globalization.CultureInfo("ja-JP")
                culture.DateTimeFormat.Calendar = New System.Globalization.JapaneseCalendar
                '和暦に変換（ggは元号を現す）
                TaisyoNendoF = DateTime.Parse(TaisyoNendoF).ToString("ggyy年度", culture)
                TaisyoNendoT = DateTime.Parse(TaisyoNendoT).ToString("ggyy年度", culture)

                wSQL &= "  , '対象期　：　第" & numKI.Value.ToString & "期（"
                wSQL &= TaisyoNendoF & "～" & TaisyoNendoT & "）' AS TAISYO_KI" & vbCrLf

            End If
            '請求回数(ヘッダー)
            wSQL &= " , '" & numSeiKaisuFrom.Value & " ～ " & numSeiKaisuTo.Value & "' AS H_SEIKYU_KAISU " & vbCrLf
            '請求・返還日(ヘッダー)
            wSQL &= " , TO_CHAR(TO_DATE('" & Format(dateSeikyuYmdFrom.Value, "yyyy/MM/dd") & "'), 'EEYY""年""MM""月""DD""日～""'" & vbCrLf
            wSQL &= "   , 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & Format(dateSeikyuYmdTo.Value, "yyyy/MM/dd") & "'), 'EEYY""年""MM""月""DD""日""'" & vbCrLf
            wSQL &= "   , 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS H_SEIKYU_DATE " & vbCrLf
            '事務委託先コード
            wSQL &= " , K.JIMUITAKU_CD " & vbCrLf
            '事務委託先コード（ヘッダー）
            wSQL &= " , '事務委託先(' || K.JIMUITAKU_CD || ')：' AS H_JIMUITAKU_CD " & vbCrLf
            '事務委託先名
            wSQL &= " , J.ITAKU_NAME " & vbCrLf
            '契約者番号
            wSQL &= " , T.KEIYAKUSYA_CD " & vbCrLf
            '契約者名
            wSQL &= " , K.KEIYAKUSYA_NAME " & vbCrLf
            '↓2018/03/13 追加
            'データ区分 0:無効 1:有効
            wSQL &= " , CASE T.DATA_FLG WHEN 0 THEN '*' ELSE ' ' END AS MUKO" & vbCrLf
            '↑2018/03/13 追加
            '契約区分
            '↓2017/07/12 修正 
            'wSQL &= " , M1.RYAKUSYO AS KEIYAKU_KBN_NM " & vbCrLf
            wSQL &= " , M1.MEISYO AS KEIYAKU_KBN_NM " & vbCrLf
            '↑2017/07/12 修正 
            '契約状況
            wSQL &= " , M2.RYAKUSYO AS KEIYAKU_JYOKYO_NM " & vbCrLf
            '請求返還状況
            wSQL &= " , M8.RYAKUSYO AS SEIKYU_HENKAN_KBN_NM " & vbCrLf
            '請求回数
            wSQL &= " , T.SEIKYU_KAISU " & vbCrLf
            '請求・返還年月日
            wSQL &= " , TO_CHAR(T.SEIKYU_DATE, 'EEYY/MM/DD', " & vbCrLf
            wSQL &= "      'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SEIKYU_DATE " & vbCrLf
            '納付振込期限
            wSQL &= " , TO_CHAR(T.NOFUKIGEN_DATE, 'MM/DD', " & vbCrLf
            wSQL &= "      'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NOFUKIGEN_DATE " & vbCrLf
            '生産者積立金
            wSQL &= " , DECODE(T.SEIKYU_HENKAN_KBN,4,NULL,T.TUMITATE_KIN) AS TUMITATE_KIN " & vbCrLf
            '事務手数料
            wSQL &= " , DECODE(T.SEIKYU_HENKAN_KBN,4,NULL,T.TESURYO) AS TESURYO " & vbCrLf
            '生産者積立金等算定額
            wSQL &= " , DECODE(T.SEIKYU_HENKAN_KBN,4,NULL,T.SEIKYU_KIN) AS SEIKYU_KIN " & vbCrLf
            '生産者積立金返還額
            wSQL &= " , DECODE(T.KEIYAKU_HENKO_KBN,0,Z.HENKAN_KAKUTEI_KIN,NULL) AS HENKAN_KAKUTEI_KIN " & vbCrLf
            '生産者積立金等請求納付額
            wSQL &= " , T.SAGAKU_SEIKYU_KIN " & vbCrLf
            '2016/12/29　追加開始
            '生産者積立金等請求納付額(合計)
            '全額請求・一部請求は、加算
            '全額返還・一部返還は、減算
            wSQL &= " ,CASE WHEN T.SEIKYU_HENKAN_KBN = 1 OR T.SEIKYU_HENKAN_KBN = 2"
            wSQL &= "       THEN T.SAGAKU_SEIKYU_KIN"
            wSQL &= "       ELSE T.SAGAKU_SEIKYU_KIN * -1"
            wSQL &= "   END SAGAKU_SEIKYU_KIN_KEI "
            '2016/12/29　追加終了

            'FROM
            wSQL &= "FROM " & vbCrLf
            wSQL &= "  TT_TUMITATE T, " & vbCrLf
            wSQL &= "  TT_ZENKI_TUMITATE_HENKAN Z, " & vbCrLf
            wSQL &= "  TM_KEIYAKU K, " & vbCrLf
            wSQL &= "  TM_SYORI_KI S, " & vbCrLf
            wSQL &= "  TM_JIMUITAKU J, " & vbCrLf
            '↓2017/07/12 修正 
            'wSQL &= "  (SELECT C.MEISYO_CD, C.RYAKUSYO FROM TM_CODE C WHERE C.SYURUI_KBN = 1) M1, " & vbCrLf
            wSQL &= "  (SELECT C.MEISYO_CD, C.MEISYO FROM TM_CODE C WHERE C.SYURUI_KBN = 1) M1, " & vbCrLf
            '↑2017/07/12 修正 
            wSQL &= "  (SELECT C.MEISYO_CD, C.RYAKUSYO FROM TM_CODE C WHERE C.SYURUI_KBN = 2) M2, " & vbCrLf
            wSQL &= "  (SELECT C.MEISYO_CD, C.RYAKUSYO FROM TM_CODE C WHERE C.SYURUI_KBN = 8) M8 " & vbCrLf
            'WHERE
            wSQL &= "WHERE " & vbCrLf
            wSQL &= "     T.KI = Z.KI(+) " & vbCrLf
            wSQL &= " AND T.KEIYAKUSYA_CD = Z.KEIYAKUSYA_CD(+) " & vbCrLf
            wSQL &= " AND T.KI = K.KI(+) " & vbCrLf
            wSQL &= " AND T.KEIYAKUSYA_CD = K.KEIYAKUSYA_CD(+) " & vbCrLf
            wSQL &= " AND T.KI = S.KI(+) " & vbCrLf
            wSQL &= " AND K.KI = J.KI(+) " & vbCrLf
            wSQL &= " AND K.JIMUITAKU_CD = J.ITAKU_CD(+) " & vbCrLf
            wSQL &= " AND T.KEIYAKU_KBN = M1.MEISYO_CD(+) " & vbCrLf
            wSQL &= " AND K.KEIYAKU_JYOKYO = M2.MEISYO_CD(+) " & vbCrLf
            wSQL &= " AND T.SEIKYU_HENKAN_KBN = M8.MEISYO_CD(+) " & vbCrLf

            '==必須条件=======================
            '積立金区分＝1：通常積立金
            wSQL &= " AND T.TUMITATE_KBN = 1 " & vbCrLf
            '期
            wSQL &= " AND T.KI = " & numKI.Value & vbCrLf
            '請求回数
            wSQL &= " AND T.SEIKYU_KAISU BETWEEN " & numSeiKaisuFrom.Value & " AND " & numSeiKaisuTo.Value & vbCrLf
            '請求・返還日
            wSQL &= " AND T.SEIKYU_DATE BETWEEN TO_DATE('" & Format(dateSeikyuYmdFrom.Value, "yyyy/MM/dd") & "','YYYY/MM/DD')" & vbCrLf
            wSQL &= " AND TO_DATE('" & Format(dateSeikyuYmdTo.Value, "yyyy/MM/dd") & "','YYYY/MM/DD')" & vbCrLf
            '請求・返還区分
            If chkSeikyu.Checked And chkIchiSei.Checked And chkIchiHen.Checked And chkHenkan.Checked Then
                '全チェックの場合条件を指定しない
            Else
                strSeikyuKbn = ""
                '請求(新規)
                If chkSeikyu.Checked Then
                    strSeikyuKbn = "1"
                End If
                '一部請求
                If chkIchiSei.Checked Then
                    If strSeikyuKbn.Length = 0 Then
                        strSeikyuKbn = "2"
                    Else
                        strSeikyuKbn &= ", 2"
                    End If
                End If
                '一部返還
                If chkIchiHen.Checked Then
                    If strSeikyuKbn.Length = 0 Then
                        strSeikyuKbn = "3"
                    Else
                        strSeikyuKbn &= ", 3"
                    End If
                End If
                '全額返還
                If chkHenkan.Checked Then
                    If strSeikyuKbn.Length = 0 Then
                        strSeikyuKbn = "4"
                    Else
                        strSeikyuKbn &= ", 4"
                    End If
                End If
                wSQL &= " AND T.SEIKYU_HENKAN_KBN IN ( " & strSeikyuKbn & ")" & vbCrLf
            End If

            '契約状況
            If chkSINKI.Checked And chkKEIZOKU.Checked And chkHAIGYO.Checked Then
                '全チェックの場合条件指定しない
            Else
                Dim strKeiyakuJyokyo As String = String.Empty
                '継続契約者
                If chkKEIZOKU.Checked Then
                    strKeiyakuJyokyo &= "     (K.KEIYAKU_JYOKYO = 2" & vbCrLf
                    strKeiyakuJyokyo &= "     AND K.HAIGYO_DATE IS NULL)" & vbCrLf
                End If
                '新規加入者
                If chkSINKI.Checked Then
                    If strKeiyakuJyokyo <> "" Then
                        strKeiyakuJyokyo &= "    OR"
                    End If
                    strKeiyakuJyokyo &= "     (K.KEIYAKU_JYOKYO = 1" & vbCrLf
                    strKeiyakuJyokyo &= "     AND K.HAIGYO_DATE IS NULL)" & vbCrLf
                End If
                '未継続者・廃業
                If chkHAIGYO.Checked Then
                    If strKeiyakuJyokyo.Length > 0 Then
                        strKeiyakuJyokyo &= "    OR"
                    End If
                    strKeiyakuJyokyo &= "     (K.KEIYAKU_JYOKYO = 3" & vbCrLf
                    strKeiyakuJyokyo &= "     OR K.HAIGYO_DATE IS NOT NULL)" & vbCrLf
                End If
                wSQL &= " AND (" & strKeiyakuJyokyo & ")" & vbCrLf
            End If

            '==任意条件=======================
            '契約区分
            If cboKEIYAKU_KBN_Cd_Fm.Text <> "" Or cboKEIYAKU_KBN_Cd_To.Text <> "" Then
                wSQL &= " AND T.KEIYAKU_KBN BETWEEN " & cboKEIYAKU_KBN_Cd_Fm.SelectedValue
                wSQL &= " AND " & cboKEIYAKU_KBN_Cd_To.SelectedValue & vbCrLf
            End If

            '事務委託先FROMTO
            If cboITAKU_Cd_Fm.Text <> "" Then
                wSQL &= "    AND K.JIMUITAKU_CD BETWEEN " & cboITAKU_Cd_Fm.Text & " AND " & cboITAKU_Cd_To.Text & vbCrLf
            End If

            '契約者FROMTO
            If cboKEIYAKUSYA_Cd_Fm.Text <> "" Then
                wSQL &= "    AND K.KEIYAKUSYA_CD BETWEEN " & cboKEIYAKUSYA_Cd_Fm.Text & " AND " & cboKEIYAKUSYA_Cd_To.Text & vbCrLf
            End If

            'ORDER BY
            wSQL &= "ORDER BY " & vbCrLf
            wSQL &= "   K.JIMUITAKU_CD " & vbCrLf
            wSQL &= " , T.KEIYAKUSYA_CD " & vbCrLf
            wSQL &= " , T.SEIKYU_KAISU "

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

            '画面内容をセット
            If Not f_SetForm_Data() Then
                Exit Try
            End If
            pJump = False

            'コンボセット
            If wKbn = "C" Then
                f_ComboBox_Set(wKbn)
            End If

            pJump = False

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
                'TO
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
                'TO
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
                'TO
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
                'TO
                If Not f_Keiyaku_Data_Select(cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To, sWhere, True) Then
                    Exit Try
                End If


                'コンボボックス初期化
                cboITAKU_Cd_Fm.Text = ""
                cboITAKU_Cd_To.Text = ""

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
            pObjTM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

            '初期値
            numKI.Value = pObjTM_SYORI_NENDO_KI.pKI
            numSeiKaisuFrom.Value = 1
            numSeiKaisuTo.Value = 999
            dateSeikyuYmdFrom.Value = Format(pObjTM_SYORI_NENDO_KI.pJIGYO_NENDO_byDate, "yyyy/MM/dd")
            dateSeikyuYmdTo.Value = Format(Now, "yyyy/MM/dd")
            chkSeikyu.Checked = True
            chkIchiSei.Checked = True
            chkIchiHen.Checked = True
            chkHenkan.Checked = True
            chkKEIZOKU.Checked = True
            chkSINKI.Checked = True
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
            wkControlName = "請求回数From"
            If numSeiKaisuFrom.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numSeiKaisuFrom.Focus() : Exit Try
            End If
            wkControlName = "請求回数To"
            If numSeiKaisuTo.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numSeiKaisuTo.Focus() : Exit Try
            End If
            wkControlName = "請求・返還日From"
            If dateSeikyuYmdFrom.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : dateSeikyuYmdFrom.Focus() : Exit Try
            End If
            wkControlName = "請求・返還日To"
            If dateSeikyuYmdTo.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : dateSeikyuYmdTo.Focus() : Exit Try
            End If
            wkControlName = "請求・返還区分"
            If chkSeikyu.Checked = False And chkIchiSei.Checked = False _
                And chkIchiHen.Checked = False And chkHenkan.Checked = False Then
                'すべてチェックOFFの場合エラー
                Call Show_MessageBox_Add("W008", wkControlName) : chkSeikyu.Focus() : Exit Try
            End If
            wkControlName = "契約状況"
            If chkSINKI.Checked = False And chkKEIZOKU.Checked = False And chkHAIGYO.Checked = False Then
                'すべてチェックOFFの場合エラー
                Call Show_MessageBox_Add("W008", wkControlName) : chkKEIZOKU.Focus() : Exit Try
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
            '請求回数
            If f_Daisyo_Check(numSeiKaisuFrom, numSeiKaisuTo, "請求回数", True, 1) = False Then
                Return False
            End If
            '請求・返還日
            If f_Daisyo_Check(dateSeikyuYmdFrom, dateSeikyuYmdTo, "請求・返還日", True, 2) = False Then
                Return False
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
