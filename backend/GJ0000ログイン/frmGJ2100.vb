'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ2100.vb
'*
'*　　②　機能概要　　　　　生産者積立金など集計表作成処理
'*
'*　　③　作成日　　　　　　2014/01/15 JBD999
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

Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.ActiveReports.Export
Imports GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
Imports JbdGjsReport


Public Class frmGJ2100

#Region "***変数定義***"

    'Private pblnTextChange As Boolean                   '画面入力内容変更フラグ     'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL START

    ''' <summary>
    ''' プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True                     '処理ジャンプ

    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "生産者積立金など集計表"

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
    Private Sub numKI_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles numKI.TextChanged
        '2015/03/03 JBD368 MOVE ↓↓↓ 処理をValidatingイベントに移動
        ''画面クリアの時、処理しない
        'If pJump Then
        '    Exit Sub
        'End If

        'If numKI.Value Is Nothing Then
        '    Exit Sub
        'End If

        ''---------------------------------------------------
        ''初期表示
        ''---------------------------------------------------
        ''コンボの初期化
        'f_ComboBox_Set("C")

        ''期にフォーカスセット
        'numKI.Focus()
        '2015/03/03 JBD368 MOVE ↑↑↑
        'pblnTextChange = False             '画面入力内容変更フラグ初期化     'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL 
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
            Exit Sub
        End If

        '---------------------------------------------------
        '初期表示
        '---------------------------------------------------
        'コンボの初期化
        f_ComboBox_Set("C")

    End Sub
    '2015/03/03 JBD368 ADD ↑↑↑

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


#Region "都道府県別"
    '------------------------------------------------------------------
    'プロシージャ名  :rdoKEN_Click
    '説明            :都道府県別クリックイベント
    '------------------------------------------------------------------
    Private Sub rdoKEN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoKEN.Click
        '事務委託先FromToは無効
        cboITAKU_Cd_Fm.Enabled = False
        cboITAKU_Cd_To.Enabled = False
        cboITAKU_Nm_Fm.Enabled = False
        cboITAKU_Nm_To.Enabled = False
    End Sub
#End Region

#Region "事務委託先別"
    '------------------------------------------------------------------
    'プロシージャ名  :rdoITAKU_Click
    '説明            :事務委託先別クリックイベント
    '------------------------------------------------------------------
    Private Sub rdoITAKU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoITAKU.Click
        '事務委託先FromToは無効
        cboITAKU_Cd_Fm.Enabled = True
        cboITAKU_Cd_To.Enabled = True
        cboITAKU_Nm_Fm.Enabled = True
        cboITAKU_Nm_To.Enabled = True

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
            'pblnTextChange = False             '画面入力内容変更フラグ初期化     'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL START

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

            'pblnTextChange = False      '画面入力内容変更フラグ初期化     'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL 
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
                Dim w As New rptGJ2100
                w.sub1(wkDSRep)
                'Using wkAR As New rptGJ2100

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
        Dim sCheckVal As String

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
            sSQL &= "   TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI " & vbCrLf
            '-- 期
            '#25 ADD START
            sSQL += " ,'対象期：第" & numKI.Value & "期（' || TO_CHAR(TO_DATE('" & sKaishiNen & "'), '""""EEYY""年度～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & sSyuryoNen & "'), '""""EEYY""年度）""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS TAISYO_KI " & vbCrLf
            '#25 ADD END

            sSQL &= "    ,KI"
            sSQL &= "    ,KEIYAKU_KBN AS KEIYAKU_KBN"
            sSQL &= "    ,MAX(KEIYAKU_KBN_NM) AS KEIYAKU_KBN_NM"
            sSQL &= "    ,'契約区分：' || MAX(KEIYAKU_KBN_NM) AS KEIYAKU_KBN_NM_HED"
            If rdoKEN.Checked Then
                sSQL &= "    ,'集計区分：都道府県' AS SYUKEI_KBN_NM_HED"
            End If
            If rdoITAKU.Checked Then
                sSQL &= "    ,'集計区分：事務委託先' AS SYUKEI_KBN_NM_HED"
            End If
            If rdoKEN.Checked Then
                sSQL &= "    ,'都道府県' AS SYUKEI_KBN_NM_ITEM"
            End If
            If rdoITAKU.Checked Then
                sSQL &= "    ,'事務委託先' AS SYUKEI_KBN_NM_ITEM"
            End If

            If rdoKEN.Checked Then
                sSQL &= "    ,KEN_CD AS KBN_CD"
                sSQL &= "    ,MAX(KEN_NM) AS KBN_NM"
            End If
            If rdoITAKU.Checked Then
                sSQL &= "    ,JIMUITAKU_CD AS KBN_CD"
                sSQL &= "    ,MAX(ITAKU_NAME) AS KBN_NM"
            End If
            '↓2017/07/25 修正 事務手数料 
            'sSQL &= "    ,COUNT(DTL.KEIYAKUSYA_CD) AS KEIYAKUSYA_CD_CNT"
            sSQL &= "    ,COUNT(DISTINCT(DTL.KEIYAKUSYA_CD)) AS KEIYAKUSYA_CD_CNT"
            '↑2017/07/25 修正 事務手数料 
            sSQL &= "    ,SUM(NVL(DTL.HASU1,0)) AS HASU1"
            sSQL &= "    ,SUM(NVL(DTL.TUMITATE_KIN1,0)) AS TUMITATE_KIN1"
            sSQL &= "    ,SUM(NVL(DTL.HASU2,0)) AS HASU2"
            sSQL &= "    ,SUM(NVL(DTL.TUMITATE_KIN2,0)) AS TUMITATE_KIN2"
            sSQL &= "    ,SUM(NVL(DTL.HASU3,0)) AS HASU3"
            sSQL &= "    ,SUM(NVL(DTL.TUMITATE_KIN3,0)) AS TUMITATE_KIN3"
            sSQL &= "    ,SUM(NVL(DTL.HASU4,0)) AS HASU4"
            sSQL &= "    ,SUM(NVL(DTL.TUMITATE_KIN4,0)) AS TUMITATE_KIN4"
            sSQL &= "    ,SUM(NVL(DTL.HASU5,0)) AS HASU5"
            sSQL &= "    ,SUM(NVL(DTL.TUMITATE_KIN5,0)) AS TUMITATE_KIN5"
            sSQL &= "    ,SUM(NVL(DTL.HASU6,0)) AS HASU6"
            sSQL &= "    ,SUM(NVL(DTL.TUMITATE_KIN6,0)) AS TUMITATE_KIN6"
            '↓2017/07/14 追加 鳥の種類追加
            sSQL &= "    ,SUM(NVL(DTL.HASU7,0)) AS HASU7"
            sSQL &= "    ,SUM(NVL(DTL.TUMITATE_KIN7,0)) AS TUMITATE_KIN7"
            sSQL &= "    ,SUM(NVL(DTL.HASU8,0)) AS HASU8"
            sSQL &= "    ,SUM(NVL(DTL.TUMITATE_KIN8,0)) AS TUMITATE_KIN8"
            sSQL &= "    ,SUM(NVL(DTL.HASU9,0)) AS HASU9"
            sSQL &= "    ,SUM(NVL(DTL.TUMITATE_KIN9,0)) AS TUMITATE_KIN9"
            sSQL &= "    ,SUM(NVL(DTL.HASU10,0)) AS HASU10"
            sSQL &= "    ,SUM(NVL(DTL.TUMITATE_KIN10,0)) AS TUMITATE_KIN10"
            sSQL &= "    ,SUM(NVL(DTL.HASU11,0)) AS HASU11"
            sSQL &= "    ,SUM(NVL(DTL.TUMITATE_KIN11,0)) AS TUMITATE_KIN11"
            '↑2017/07/14 追加 鳥の種類追加
            sSQL &= "    ,SUM(NVL(DTL.HASU_KEI,0)) AS HASU_KEI"
            sSQL &= "    ,SUM(NVL(DTL.TUMITATE_KIN_KEI,0)) AS TUMITATE_KIN_KEI"
            sSQL &= "    ,SUM(NVL(DTL.TESURYO,0)) AS TESURYO"
            '#61 UPD START
            'sSQL &= "    ,SUM(NVL(DTL.NOUFU_KIN,0)) AS NOUFU_KIN"
            sSQL &= "    ,SUM(NVL(DTL.TUMITATE_KIN_KEI,0)) + SUM(NVL(DTL.TESURYO,0)) AS NOUFU_KIN"
            '#61 UPD END

            sSQL &= " FROM"
            sSQL &= "    ("
            sSQL &= "    SELECT "
            sSQL &= "         WK.KI"
            sSQL &= "        ,WK.KEN_CD"
            sSQL &= "        ,CD05.MEISYO AS KEN_NM	"
            sSQL &= "        ,WK.JIMUITAKU_CD"
            sSQL &= "        ,JIM.ITAKU_NAME AS ITAKU_NAME"
            sSQL &= "        ,WK.KEIYAKUSYA_CD"
            sSQL &= "        ,WK.KEIYAKU_KBN"
            '↓2017/07/14 修正 契約区分
            'sSQL &= "        ,CD01.RYAKUSYO AS KEIYAKU_KBN_NM	"
            sSQL &= "        ,CD01.MEISYO AS KEIYAKU_KBN_NM	"
            '↑2017/07/14 修正 契約区分
            sSQL &= "        ,WK.HASU1"
            sSQL &= "        ,WK.TUMITATE_KIN1"
            sSQL &= "        ,WK.HASU2"
            sSQL &= "        ,WK.TUMITATE_KIN2"
            sSQL &= "        ,WK.HASU3"
            sSQL &= "        ,WK.TUMITATE_KIN3"
            sSQL &= "        ,WK.HASU4"
            sSQL &= "        ,WK.TUMITATE_KIN4"
            sSQL &= "        ,WK.HASU5"
            sSQL &= "        ,WK.TUMITATE_KIN5"
            sSQL &= "        ,WK.HASU6"
            sSQL &= "        ,WK.TUMITATE_KIN6"
            '↓2017/07/14 追加 鳥の種類追加
            sSQL &= "        ,WK.HASU7"
            sSQL &= "        ,WK.TUMITATE_KIN7"
            sSQL &= "        ,WK.HASU8"
            sSQL &= "        ,WK.TUMITATE_KIN8"
            sSQL &= "        ,WK.HASU9"
            sSQL &= "        ,WK.TUMITATE_KIN9"
            sSQL &= "        ,WK.HASU10"
            sSQL &= "        ,WK.TUMITATE_KIN10"
            sSQL &= "        ,WK.HASU11"
            sSQL &= "        ,WK.TUMITATE_KIN11"
            '↑2017/07/14 追加 鳥の種類追加
            sSQL &= "        ,WK.HASU_KEI"
            sSQL &= "        ,WK.TUMITATE_KIN_KEI"
            sSQL &= "        ,WK.TESURYO"
            '                 -- 納付額
            '2017/07/26　削除開始    納付額は積立金＋手数料に変更された為
            'sSQL &= "        ,CASE "               
            'sSQL &= "            WHEN WK.NYUKIN_GAKU = 0 THEN 0"
            'sSQL &= "            ELSE WK.NYUKIN_GAKU + WK.HENKAN_KIN"
            'sSQL &= "         END NOUFU_KIN"
            '2017/07/26　削除終了
            sSQL &= "     FROM"
            sSQL &= "        ("
            sSQL &= "        SELECT"
            sSQL &= "             TUM.KI AS KI"
            sSQL &= "            ,KEI.KEN_CD AS KEN_CD"
            sSQL &= "            ,KEI.JIMUITAKU_CD AS JIMUITAKU_CD"
            sSQL &= "            ,TUM.KEIYAKUSYA_CD AS KEIYAKUSYA_CD"
            sSQL &= "            ,TUM.KEIYAKU_KBN AS KEIYAKU_KBN"
            '                     -- 採卵鶏 成鶏
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 1 THEN NVL(MEI.HASU,0) END) AS HASU1"
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 1 THEN NVL(MEI.TUMITATE_KIN,0) END) AS TUMITATE_KIN1"
            '                     -- 採卵鶏 育成
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 2 THEN NVL(MEI.HASU,0) END) AS HASU2"
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 2 THEN NVL(MEI.TUMITATE_KIN,0) END) AS TUMITATE_KIN2"
            '                     -- 肉用鶏
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 3 THEN NVL(MEI.HASU,0) END) AS HASU3"
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 3 THEN NVL(MEI.TUMITATE_KIN,0) END) AS TUMITATE_KIN3"
            '                     -- 種鶏 成鶏
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 4 THEN NVL(MEI.HASU,0) END) AS HASU4"
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 4 THEN NVL(MEI.TUMITATE_KIN,0) END) AS TUMITATE_KIN4"
            '                     -- 種鶏 育成
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 5 THEN NVL(MEI.HASU,0) END) AS HASU5"
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 5 THEN NVL(MEI.TUMITATE_KIN,0) END) AS TUMITATE_KIN5"
            '                     -- うずら
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 6 THEN NVL(MEI.HASU,0) END) AS HASU6"
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 6 THEN NVL(MEI.TUMITATE_KIN,0) END) AS TUMITATE_KIN6"
            '↓2017/07/14 追加 鳥の種類追加
            '                     -- あひる
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 7 THEN NVL(MEI.HASU,0) END) AS HASU7"
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 7 THEN NVL(MEI.TUMITATE_KIN,0) END) AS TUMITATE_KIN7"
            '                     -- きじ
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 8 THEN NVL(MEI.HASU,0) END) AS HASU8"
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 8 THEN NVL(MEI.TUMITATE_KIN,0) END) AS TUMITATE_KIN8"
            '                     -- ほろほろ鳥
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 9 THEN NVL(MEI.HASU,0) END) AS HASU9"
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 9 THEN NVL(MEI.TUMITATE_KIN,0) END) AS TUMITATE_KIN9"
            '                     -- 七面鳥
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 10 THEN NVL(MEI.HASU,0) END) AS HASU10"
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 10 THEN NVL(MEI.TUMITATE_KIN,0) END) AS TUMITATE_KIN10"
            '                     -- だちょう
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 11 THEN NVL(MEI.HASU,0) END) AS HASU11"
            sSQL &= "            ,SUM(CASE WHEN MEI.TORI_KBN = 11 THEN NVL(MEI.TUMITATE_KIN,0) END) AS TUMITATE_KIN11"
            '↑2017/07/14 追加 鳥の種類追加
            '                     -- 合計 
            sSQL &= "            ,SUM(NVL(MEI.HASU,0)) AS HASU_KEI"
            sSQL &= "            ,SUM(NVL(MEI.TUMITATE_KIN,0)) AS TUMITATE_KIN_KEI"
            '                     -- 事務手数料 
            '#61 UPD START
            'sSQL &= "            ,MAX(NVL(TUM.TESURYO,0)) AS TESURYO"
            '↓2017/07/25 修正 事務手数料 
            'sSQL &= "            ,SUM(NVL(TUM.TESURYO,0)) AS TESURYO"
            'sSQL &= "            ,NVL(TUM.TESURYO,0) AS TESURYO"
            sSQL &= "            ,MAX(NVL(TUM.TESURYO,0)) AS TESURYO"
            '↑2017/07/25 修正 事務手数料

            '                     -- 入金額 
            'sSQL &= "            ,MAX(NVL(TUM.NYUKIN_GAKU,0)) AS NYUKIN_GAKU"
            '2017/07/26　削除開始    納付額は積立金＋手数料に変更された為
            'sSQL &= "            ,SUM(NVL(TUM.NYUKIN_GAKU,0)) AS NYUKIN_GAKU"
            ''#61 UPD END
            ''                      -- 返還金
            'sSQL &= "            ,SUM(NVL(TUM.SEIKYU_KIN,0) - NVL(TUM.SAGAKU_SEIKYU_KIN,0)) AS HENKAN_KIN"
            '2017/07/26　削除終了

            sSQL &= "        FROM"
            sSQL &= "            TT_TUMITATE TUM"
            sSQL &= "           ,TT_TUMITATE_MEISAI MEI"
            sSQL &= "           ,TM_KEIYAKU KEI"
            sSQL &= "        WHERE"
            '                    -- 契約マスタ
            sSQL &= "             TUM.KI = KEI.KI(+)"
            sSQL &= "         AND TUM.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+)"
            '                    -- 積立金明細
            sSQL &= "         AND TUM.KI = MEI.KI(+)"
            sSQL &= "         AND TUM.KEIYAKUSYA_CD = MEI.KEIYAKUSYA_CD(+)"
            sSQL &= "         AND TUM.TUMITATE_KBN = MEI.TUMITATE_KBN(+)"
            sSQL &= "         AND TUM.SEIKYU_KAISU = MEI.SEIKYU_KAISU(+)"
            '                    -- 条件
            ''==必須条件=======================
            '期
            sSQL &= "         AND TUM.KI = " & numKI.Value
            sSQL &= "         AND TUM.DATA_FLG = 1"
            '#108 ADD START
            sSQL &= "         AND TUM.SEIKYU_HENKAN_KBN IN (1,2)"
            '#108 ADD END



            '入力状況
            sCheckVal = ""
            If chkNYURYOKU_CYU.Checked Then
                sCheckVal = "1"
            End If
            If chkNYURYOKU_KAKUTEI.Checked Then
                If sCheckVal = "" Then
                    sCheckVal = "2"
                Else
                    sCheckVal = "1,2"
                End If
            End If
            sSQL &= "         AND KEI.NYURYOKU_JYOKYO IN (" & sCheckVal & ")"

            '==任意条件=======================
            '契約区分FROMTO
            If cboKEIYAKU_KBN_Cd_Fm.Text <> "" Then
                sSQL &= "         AND KEI.KEIYAKU_KBN BETWEEN " & cboKEIYAKU_KBN_Cd_Fm.Text & " AND " & cboKEIYAKU_KBN_Cd_To.Text & vbCrLf
            End If

            '都道府県FROMTO
            If cboKEN_Cd_Fm.Text <> "" Then
                'R05年度　OSバージョンアップ　既存バグ修正のため変更　2024/03/12 JBD 453 UPD START
                'sSQL &= "         AND KEI.KEN_CD BETWEEN " & cboKEN_Cd_Fm.Text & " AND " & cboKEN_Cd_Fm.Text & vbCrLf
                sSQL &= "         AND KEI.KEN_CD BETWEEN " & cboKEN_Cd_Fm.Text & " AND " & cboKEN_Cd_To.Text & vbCrLf
                'R05年度　OSバージョンアップ　既存バグ修正のため変更 UPD END
            End If

            '事務委託先FROMTO
            If rdoITAKU.Checked Then
                If cboITAKU_Cd_Fm.Text <> "" Then
                    sSQL &= "         AND KEI.JIMUITAKU_CD BETWEEN " & cboITAKU_Cd_Fm.Text & " AND " & cboITAKU_Cd_To.Text & vbCrLf
                End If
            End If

            sSQL &= "        GROUP BY"
            sSQL &= "            TUM.KI"
            sSQL &= "           ,KEI.KEN_CD"
            sSQL &= "           ,KEI.JIMUITAKU_CD"
            sSQL &= "           ,TUM.KEIYAKU_KBN"
            sSQL &= "           ,TUM.KEIYAKUSYA_CD"
            '↓2017/07/25 追加 事務手数料 
            'sSQL &= "           ,TUM.TESURYO"      '2017/07/26　削除
            sSQL &= "           ,TUM.SEIKYU_KAISU"
            '↑2017/07/25 追加 事務手数料
            sSQL &= "        ORDER BY"
            sSQL &= "            KI"
            sSQL &= "           ,KEN_CD"
            sSQL &= "           ,JIMUITAKU_CD"
            sSQL &= "           ,KEIYAKU_KBN"
            sSQL &= "           ,KEIYAKUSYA_CD"
            sSQL &= "        ) WK"
            sSQL &= "	    ,TM_CODE CD05"
            sSQL &= "	    ,TM_CODE CD01"
            sSQL &= "       ,TM_JIMUITAKU JIM"
            sSQL &= "   WHERE"
            '                -- 都道府県"
            sSQL &= "        WK.KEN_CD = CD05.MEISYO_CD(+)"
            sSQL &= "    AND 5 = CD05.SYURUI_KBN(+)"
            '                -- 契約区分
            sSQL &= "    AND WK.KEIYAKU_KBN = CD01.MEISYO_CD(+)"
            sSQL &= "    AND 1 = CD01.SYURUI_KBN(+)"
            '        　　　  -- 事務委託先
            sSQL &= "    AND WK.KI = JIM.KI(+)"
            sSQL &= "    AND WK.JIMUITAKU_CD = JIM.ITAKU_CD(+)"
            sSQL &= "   ORDER BY"
            sSQL &= "       KI"
            sSQL &= "      ,KEN_CD"
            sSQL &= "      ,JIMUITAKU_CD"
            sSQL &= "      ,KEIYAKU_KBN"
            sSQL &= "   ) DTL"
            sSQL &= " GROUP BY"
            sSQL &= "     DTL.KI"
            sSQL &= "    ,DTL.KEIYAKU_KBN"
            If rdoKEN.Checked Then
                sSQL &= "    ,DTL.KEN_CD"
            End If
            If rdoITAKU.Checked Then
                sSQL &= "    ,DTL.JIMUITAKU_CD"
            End If
            sSQL &= " ORDER BY"
            sSQL &= "     KI"
            sSQL &= "    ,KEIYAKU_KBN"
            If rdoKEN.Checked Then
                sSQL &= "    ,KEN_CD"
            End If
            If rdoITAKU.Checked Then
                sSQL &= "    ,JIMUITAKU_CD"
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
            'pJump = False      '2015/03/03 JBD368 DEL コンボボックス設定までTRUEにしておく

            '画面内容をセット
            If Not f_SetForm_Data() Then
                Exit Try
            End If

            'コンボセット
            If wKbn = "C" Then
                f_ComboBox_Set(wKbn)
            End If

            pJump = False       '2015/03/03 JBD368 ADD

            '画面変更フラグ
            'pblnTextChange = False     'R05年度　OSバージョンアップ　既存バグ修正のため変更　データ変更のメッセージを表示しないので変更判定が不要のため削除　JBD453 2024/03/13 DEL START

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


                'コンボボックス初期化
                cboKEIYAKU_KBN_Cd_Fm.Text = ""
                cboKEIYAKU_KBN_Cd_To.Text = ""
                cboKEN_Cd_Fm.Text = ""
                cboKEN_Cd_To.Text = ""
                cboITAKU_Cd_Fm.Text = ""
                cboITAKU_Cd_To.Text = ""

                '事務委託先FromToは無効
                cboITAKU_Cd_Fm.Enabled = False
                cboITAKU_Cd_To.Enabled = False
                cboITAKU_Nm_Fm.Enabled = False
                cboITAKU_Nm_To.Enabled = False


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
            rdoKEN.Checked = True
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

        Try

            '==必須チェック==================
            If numKI.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "期") : numKI.Focus() : Exit Try
            End If
            If chkNYURYOKU_CYU.Checked = False And chkNYURYOKU_KAKUTEI.Checked = False Then
                Call Show_MessageBox_Add("W008", "入力状況") : chkNYURYOKU_CYU.Focus() : Exit Try
            End If


            '==FromToチェック==================
            '契約区分
            If f_Daisyo_Check(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Cd_To, "契約区分", True, 1) = False Then
                Return False
            End If
            '都道府県
            If f_Daisyo_Check(cboKEN_Cd_Fm, cboKEN_Cd_To, "都道府県", True, 1) = False Then
                Return False
            End If
            '事務委託先番号
            If rdoITAKU.Checked Then
                If f_Daisyo_Check(cboITAKU_Cd_Fm, cboITAKU_Cd_To, "事務委託先", True, 1) = False Then
                    Return False
                End If
            End If

            '==いろいろチェック==================

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
