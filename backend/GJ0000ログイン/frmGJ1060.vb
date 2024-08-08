'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ1060.vb
'*
'*　　②　機能概要　　　　　家畜防疫互助基金事業状況表作成処理
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


Public Class frmGJ1060

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
    Private Const con_ReportName As String = "家畜防疫互助基金事業状況表作成処理(EXCEL)"

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
        '画面クリアの時、処理しない
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
    '2020/09/07 JBD9020 DEL START
    ''------------------------------------------------------------------
    ''プロシージャ名  :cboKEIYAKU_KBN_Cd_Fm_SelectedIndexChanged
    ''説明            :契約区分コードFromChanegeイベント
    ''------------------------------------------------------------------
    'Private Sub cboKEIYAKU_KBN_Cd_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    '画面クリアの時、処理しない
    '    If pJump Then
    '        Exit Sub
    '    End If
    '    cboKEIYAKU_KBN_Nm_Fm.SelectedIndex = cboKEIYAKU_KBN_Cd_Fm.SelectedIndex
    'End Sub

    ''------------------------------------------------------------------
    ''プロシージャ名  :cboKEIYAKU_KBN_Nm_Fm_SelectedIndexChanged
    ''説明            :契約区分名FromChanegeイベント
    ''------------------------------------------------------------------
    'Private Sub cboKEIYAKU_KBN_Nm_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    '画面クリアの時、処理しない
    '    If pJump Then
    '        Exit Sub
    '    End If
    '    s_CboMeiFrom_SelectedIndexChanged(cboKEIYAKU_KBN_Nm_Fm, cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_To, cboKEIYAKU_KBN_Cd_To)
    'End Sub

    ''------------------------------------------------------------------
    ''プロシージャ名  :cboKEIYAKU_KBN_Cd_Fm_Validating
    ''説明            :契約区分コードFromValidatingイベント
    ''------------------------------------------------------------------
    'Private Sub cboKEIYAKU_KBN_Cd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    '画面クリアの時、処理しない
    '    If pJump Then
    '        Exit Sub
    '    End If
    '    Call s_CboFrom_Validating(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_Fm, cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To)
    'End Sub


    ''------------------------------------------------------------------
    ''プロシージャ名  :cboKEIYAKU_KBN_Cd_To_SelectedIndexChanged
    ''説明            :契約区分コードToChanegeイベント
    ''------------------------------------------------------------------
    'Private Sub cboKEIYAKU_KBN_Cd_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    '画面クリアの時、処理しない
    '    If pJump Then
    '        Exit Sub
    '    End If
    '    cboKEIYAKU_KBN_Nm_To.SelectedIndex = cboKEIYAKU_KBN_Cd_To.SelectedIndex
    'End Sub
    ''------------------------------------------------------------------
    ''プロシージャ名  :cboKEIYAKU_KBN_Nm_To_SelectedIndexChanged
    ''説明            :契約区分名ToChanegeイベント
    ''------------------------------------------------------------------
    'Private Sub cboKEIYAKU_KBN_Nm_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    '画面クリアの時、処理しない
    '    If pJump Then
    '        Exit Sub
    '    End If
    '    s_CboMeiTo_Validating(cboKEIYAKU_KBN_Nm_To, cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_Fm, cboKEIYAKU_KBN_Cd_Fm)
    'End Sub
    ''------------------------------------------------------------------
    ''プロシージャ名  :cboKEIYAKU_KBN_Cd_To_Validating
    ''説明            :契約区分コードToValidatingイベント
    ''------------------------------------------------------------------
    'Private Sub cboKEIYAKU_KBN_Cd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    '画面クリアの時、処理しない
    '    If pJump Then
    '        Exit Sub
    '    End If
    '    Call s_CboTo_Validating(cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To, cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_Fm)
    'End Sub
    '2020/09/07 JBD9020 DEL END
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
            'R05年度改修 OSバージョンアップ　既存バグ修正のため削除　2024/03/12 JBD453 DEL END
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
            If Not f_make_SQL_TUMI(0, wkSql) Then
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

#Region "f_make_SQL_TUMI EXCEデータ出力用ＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_make_SQL_TUMI
    '説明            :EXCELデータ出力用ＳＱＬ作成(積立ベース)
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
    Private Function f_make_SQL_TUMI(ByVal iKbn As Integer, ByRef wSQL As String) As Boolean
        Dim ret As Boolean = False
        Dim sSQL As String = vbNullString
        Dim sSQL2 As String = vbNullString
        Dim sSQL3 As String = vbNullString

        Try
            '対象期・年度の取得
            Dim SyoriKI = New Obj_TM_SYORI_NENDO_KI()

            sSQL = " SELECT " & vbCrLf
            sSQL += "   TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI " & vbCrLf
            '-- 期
            If SyoriKI.pKI = numKI.Value Then
                sSQL += " ,'対象期：第" & numKI.Value & "期（' || TO_CHAR(TO_DATE('" & SyoriKI.pTAISYO_NENDO_byDate & "'), '""""EEYY""年度～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & SyoriKI.pJIGYO_SYURYO_NENDO_byDate & "'), '""""EEYY""年度）""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS TAISYO_KI " & vbCrLf
            Else
                sSQL += " ,'対象期：第" & numKI.Value & "期' AS TAISYO_KI " & vbCrLf
            End If

            '2016/10/26　修正開始
            '-- 契約締結日範囲
            'sSQL += " ,'＜＜　家畜防疫互助基金事業加入状況表（' || TO_CHAR(TO_DATE('" & dateKEIYAKU_Ymd_Fm.Value & "'), 'EEYY""年""MM""月""DD""日～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & dateKEIYAKU_Ymd_To.Value & "'), 'EEYY""年""MM""月""DD""日）　＞＞""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ITAKU_NAME_HED " & vbCrLf
            '↓2017/07/14 修正 追加納付を追加
            'sSQL += " ,'＜＜　家畜防疫互助基金事業加入状況表（' || TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日現在""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '）　＞＞' AS ITAKU_NAME_HED " & vbCrLf
            '2020/09/07 JBD9020 UPD START
            'If pKikin2 Then
            '    sSQL += " ,'＜＜　家畜防疫互助基金事業加入状況表(追加納付)（' || TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日現在""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '）　＞＞' AS ITAKU_NAME_HED " & vbCrLf
            'Else
            '    sSQL += " ,'＜＜　家畜防疫互助基金事業加入状況表（' || TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日現在""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '）　＞＞' AS ITAKU_NAME_HED " & vbCrLf
            'End If
            If pKikin2 Then
                sSQL += " ,'＜＜　家畜防疫互助基金事業加入状況表(追加納付)（指定日：' || TO_CHAR(TO_DATE('" & dateTAISYOBI_Ymd.Value & "'), 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '）　＞＞' AS ITAKU_NAME_HED " & vbCrLf
            Else
                sSQL += " ,'＜＜　家畜防疫互助基金事業加入状況表（指定日：' || TO_CHAR(TO_DATE('" & dateTAISYOBI_Ymd.Value & "'), 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || '）　＞＞' AS ITAKU_NAME_HED " & vbCrLf
            End If
            '2020/09/07 JBD9020 UPD END
            '↑2017/07/14 修正 追加納付を追加
            '2016/10/26　修正終了

            '--  連番
            sSQL += " ,CASE " & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 0 THEN TO_CHAR(GRP.ROW_NUM) " & vbCrLf
            sSQL += "    ELSE NULL " & vbCrLf
            sSQL += "  END ROW_NUM " & vbCrLf
            '-- 期
            sSQL += " ,GRP.KI AS KI " & vbCrLf

            '-- 都道府県
            sSQL += " ,GRP.KEN_CD AS KEN_CD " & vbCrLf
            sSQL += " ,CD05.MEISYO AS KEN_NM " & vbCrLf
            '-- 契約区分 
            sSQL += " ,GRP.KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
            '↓2017/07/12 修正 契約区分変更
            'sSQL += " ,CD01.RYAKUSYO AS KEIYAKU_KBN_NM " & vbCrLf
            sSQL += " ,CD01.MEISYO AS KEIYAKU_KBN_NM " & vbCrLf
            '↑2017/07/12 修正 契約区分変更
            '2021/07/12 JBD9020 新契約日追加 ADD START
            sSQL += " ,KEI.KEIYAKU_DATE " & vbCrLf
            sSQL += " ,KEI.NYU_HEN_DATE " & vbCrLf
            '2021/07/12 JBD9020 新契約日追加 ADD END
            '-- 契約者 
            sSQL += " ,GRP.KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
            sSQL += " ,CASE " & vbCrLf
            '↓2017/07/12 修正 契約区分変更
            'sSQL += "    WHEN GRP.GRPID = 1 THEN CD01.RYAKUSYO || '計' " & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 1 THEN CD01.MEISYO || '計' " & vbCrLf
            '↑2017/07/12 修正 契約区分変更
            sSQL += "    WHEN GRP.GRPID = 3 THEN CD05.MEISYO || '計' " & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 5 THEN CD05.MEISYO || '合計' " & vbCrLf
            sSQL += "    WHEN GRP.GRPID = 7 THEN CD05.MEISYO || '総合計' " & vbCrLf
            sSQL += "    ELSE KEI.KEIYAKUSYA_NAME " & vbCrLf
            sSQL += "  END KEIYAKUSYA_NAME " & vbCrLf
            sSQL += " ,KEI.ADDR_1 || KEI.ADDR_2 || KEI.ADDR_3 || KEI.ADDR_4 AS ADDR " & vbCrLf

            sSQL += " ,GRP.GRPID AS GRPID " & vbCrLf

            '-- 採卵鶏 成鶏 
            sSQL += " ,GRP.TOSU1 AS TOSU1 " & vbCrLf
            sSQL += " ,GRP.KEIYAKU_HASU1 AS KEIYAKU_HASU1 " & vbCrLf
            sSQL += " ,GRP.TUMITATE_KIN1 AS TUMITATE_KIN1 " & vbCrLf

            '-- 採卵鶏 育成
            sSQL += " ,GRP.TOSU2 AS TOSU2 " & vbCrLf
            sSQL += " ,GRP.KEIYAKU_HASU2 AS KEIYAKU_HASU2 " & vbCrLf
            sSQL += " ,GRP.TUMITATE_KIN2 AS TUMITATE_KIN2 " & vbCrLf

            '-- 肉用鶏
            sSQL += " ,GRP.TOSU3 AS TOSU3 " & vbCrLf
            sSQL += " ,GRP.KEIYAKU_HASU3 AS KEIYAKU_HASU3 " & vbCrLf
            sSQL += " ,GRP.TUMITATE_KIN3 AS TUMITATE_KIN3 " & vbCrLf

            '-- 種鶏 成鶏
            sSQL += " ,GRP.TOSU4 AS TOSU4 " & vbCrLf
            sSQL += " ,GRP.KEIYAKU_HASU4 AS KEIYAKU_HASU4 " & vbCrLf
            sSQL += " ,GRP.TUMITATE_KIN4 AS TUMITATE_KIN4 " & vbCrLf

            '-- 種鶏 育成
            sSQL += " ,GRP.TOSU5 AS TOSU5 " & vbCrLf
            sSQL += " ,GRP.KEIYAKU_HASU5 AS KEIYAKU_HASU5 " & vbCrLf
            sSQL += " ,GRP.TUMITATE_KIN5 AS TUMITATE_KIN5 " & vbCrLf

            '-- うずら
            sSQL += " ,GRP.TOSU6 AS TOSU6 " & vbCrLf
            sSQL += " ,GRP.KEIYAKU_HASU6 AS KEIYAKU_HASU6 " & vbCrLf
            sSQL += " ,GRP.TUMITATE_KIN6 AS TUMITATE_KIN6 " & vbCrLf

            '↓2017/07/12 追加 鳥区分追加
            '-- あひる
            sSQL += " ,GRP.TOSU7 AS TOSU7 " & vbCrLf
            sSQL += " ,GRP.KEIYAKU_HASU7 AS KEIYAKU_HASU7 " & vbCrLf
            sSQL += " ,GRP.TUMITATE_KIN7 AS TUMITATE_KIN7 " & vbCrLf

            '-- きじ
            sSQL += " ,GRP.TOSU8 AS TOSU8 " & vbCrLf
            sSQL += " ,GRP.KEIYAKU_HASU8 AS KEIYAKU_HASU8 " & vbCrLf
            sSQL += " ,GRP.TUMITATE_KIN8 AS TUMITATE_KIN8 " & vbCrLf

            '-- ほろほろ鳥
            sSQL += " ,GRP.TOSU9 AS TOSU9 " & vbCrLf
            sSQL += " ,GRP.KEIYAKU_HASU9 AS KEIYAKU_HASU9 " & vbCrLf
            sSQL += " ,GRP.TUMITATE_KIN9 AS TUMITATE_KIN9 " & vbCrLf

            '-- 七面鳥
            sSQL += " ,GRP.TOSU10 AS TOSU10 " & vbCrLf
            sSQL += " ,GRP.KEIYAKU_HASU10 AS KEIYAKU_HASU10 " & vbCrLf
            sSQL += " ,GRP.TUMITATE_KIN10 AS TUMITATE_KIN10 " & vbCrLf

            '-- だちょう
            sSQL += " ,GRP.TOSU11 AS TOSU11 " & vbCrLf
            sSQL += " ,GRP.KEIYAKU_HASU11 AS KEIYAKU_HASU11 " & vbCrLf
            sSQL += " ,GRP.TUMITATE_KIN11 AS TUMITATE_KIN11 " & vbCrLf
            '↑2017/07/12 追加 鳥区分追加

            '-- 合計(横計)
            sSQL += " ,GRP.TOSU_SUM AS TOSU_SUM " & vbCrLf
            sSQL += " ,GRP.HASU_SUM AS HASU_SUM " & vbCrLf
            sSQL += " ,GRP.TUMITATE_SUM AS TUMITATE_SUM " & vbCrLf

            sSQL += " FROM " & vbCrLf
            '-- 契約区分別、都道府県別の集計
            sSQL += "    (" & vbCrLf
            sSQL += "    SELECT " & vbCrLf
            sSQL += "         MAX(ROWNUM) AS ROW_NUM " & vbCrLf
            sSQL += "        ,MAX(KI) AS KI " & vbCrLf
            sSQL += "        ,KEN_CD  AS KEN_CD " & vbCrLf
            sSQL += "        ,KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
            sSQL += "        ,KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
            sSQL += "        ,GROUPING_ID(KEN_CD, KEIYAKU_KBN, KEIYAKUSYA_CD) AS GRPID " & vbCrLf
            '                 -- 採卵鶏 成鶏
            sSQL += "        ,SUM(TOSU1) AS TOSU1 " & vbCrLf
            sSQL += "        ,SUM(KEIYAKU_HASU1) AS KEIYAKU_HASU1 " & vbCrLf
            sSQL += "        ,SUM(TUMITATE_KIN1) AS TUMITATE_KIN1 " & vbCrLf
            '                 -- 採卵鶏 育成
            sSQL += "        ,SUM(TOSU2) AS TOSU2 " & vbCrLf
            sSQL += "        ,SUM(KEIYAKU_HASU2) AS KEIYAKU_HASU2 " & vbCrLf
            sSQL += "        ,SUM(TUMITATE_KIN2) AS TUMITATE_KIN2 " & vbCrLf
            '                 -- 肉用鶏
            sSQL += "        ,SUM(TOSU3) AS TOSU3 " & vbCrLf
            sSQL += "        ,SUM(KEIYAKU_HASU3) AS KEIYAKU_HASU3 " & vbCrLf
            sSQL += "        ,SUM(TUMITATE_KIN3) AS TUMITATE_KIN3 " & vbCrLf
            '                 -- 種鶏 成鶏
            sSQL += "        ,SUM(TOSU4) AS TOSU4 " & vbCrLf
            sSQL += "        ,SUM(KEIYAKU_HASU4) AS KEIYAKU_HASU4 " & vbCrLf
            sSQL += "        ,SUM(TUMITATE_KIN4) AS TUMITATE_KIN4 " & vbCrLf
            '                 -- 種鶏 育成
            sSQL += "        ,SUM(TOSU5) AS TOSU5 " & vbCrLf
            sSQL += "        ,SUM(KEIYAKU_HASU5) AS KEIYAKU_HASU5 " & vbCrLf
            sSQL += "        ,SUM(TUMITATE_KIN5) AS TUMITATE_KIN5 " & vbCrLf
            '                 -- うずら
            sSQL += "        ,SUM(TOSU6) AS TOSU6 " & vbCrLf
            sSQL += "        ,SUM(KEIYAKU_HASU6) AS KEIYAKU_HASU6 " & vbCrLf
            sSQL += "        ,SUM(TUMITATE_KIN6) AS TUMITATE_KIN6 " & vbCrLf
            '↓2017/07/12 追加 鳥区分追加
            '                 -- あひる
            sSQL += "        ,SUM(TOSU7) AS TOSU7 " & vbCrLf
            sSQL += "        ,SUM(KEIYAKU_HASU7) AS KEIYAKU_HASU7 " & vbCrLf
            sSQL += "        ,SUM(TUMITATE_KIN7) AS TUMITATE_KIN7 " & vbCrLf
            '                 -- きじ
            sSQL += "        ,SUM(TOSU8) AS TOSU8 " & vbCrLf
            sSQL += "        ,SUM(KEIYAKU_HASU8) AS KEIYAKU_HASU8 " & vbCrLf
            sSQL += "        ,SUM(TUMITATE_KIN8) AS TUMITATE_KIN8 " & vbCrLf
            '                 -- ほろほろ鳥
            sSQL += "        ,SUM(TOSU9) AS TOSU9 " & vbCrLf
            sSQL += "        ,SUM(KEIYAKU_HASU9) AS KEIYAKU_HASU9 " & vbCrLf
            sSQL += "        ,SUM(TUMITATE_KIN9) AS TUMITATE_KIN9 " & vbCrLf
            '                 -- 七面鳥
            sSQL += "        ,SUM(TOSU10) AS TOSU10 " & vbCrLf
            sSQL += "        ,SUM(KEIYAKU_HASU10) AS KEIYAKU_HASU10 " & vbCrLf
            sSQL += "        ,SUM(TUMITATE_KIN10) AS TUMITATE_KIN10 " & vbCrLf
            '                 -- だちょう
            sSQL += "        ,SUM(TOSU11) AS TOSU11 " & vbCrLf
            sSQL += "        ,SUM(KEIYAKU_HASU11) AS KEIYAKU_HASU11 " & vbCrLf
            sSQL += "        ,SUM(TUMITATE_KIN11) AS TUMITATE_KIN11 " & vbCrLf
            '↑2017/07/12 追加 鳥区分追加
            '                 -- 合計(横計)
            sSQL += "        ,SUM(1) AS TOSU_SUM " & vbCrLf
            sSQL += "        ,SUM(HASU_SUM) AS HASU_SUM " & vbCrLf
            sSQL += "        ,SUM(TUMITATE_SUM) AS TUMITATE_SUM " & vbCrLf
            sSQL += "    FROM " & vbCrLf
            sSQL += "       ( " & vbCrLf
            sSQL += "       SELECT " & vbCrLf
            sSQL += "            KI " & vbCrLf
            sSQL += "           ,ROWNUM " & vbCrLf
            sSQL += "           ,KEN_CD " & vbCrLf
            sSQL += "           ,KEIYAKU_KBN " & vbCrLf
            sSQL += "           ,KEIYAKUSYA_CD " & vbCrLf
            '                    -- 採卵鶏 成鶏
            sSQL += "           ,TOSU1 " & vbCrLf
            sSQL += "           ,KEIYAKU_HASU1 " & vbCrLf
            sSQL += "           ,TUMITATE_KIN1 " & vbCrLf
            '                    -- 採卵鶏 育成
            sSQL += "           ,TOSU2 " & vbCrLf
            sSQL += "           ,KEIYAKU_HASU2 " & vbCrLf
            sSQL += "           ,TUMITATE_KIN2 " & vbCrLf
            '                    -- 肉用鶏
            sSQL += "           ,TOSU3 " & vbCrLf
            sSQL += "           ,KEIYAKU_HASU3 " & vbCrLf
            sSQL += "           ,TUMITATE_KIN3 " & vbCrLf
            '                    -- 種鶏 成鶏
            sSQL += "           ,TOSU4 " & vbCrLf
            sSQL += "           ,KEIYAKU_HASU4 " & vbCrLf
            sSQL += "           ,TUMITATE_KIN4 " & vbCrLf
            '                    -- 種鶏 育成
            sSQL += "           ,TOSU5 " & vbCrLf
            sSQL += "           ,KEIYAKU_HASU5 " & vbCrLf
            sSQL += "           ,TUMITATE_KIN5 " & vbCrLf
            '                    -- うずら
            sSQL += "           ,TOSU6 " & vbCrLf
            sSQL += "           ,KEIYAKU_HASU6 " & vbCrLf
            sSQL += "           ,TUMITATE_KIN6 " & vbCrLf
            '↓2017/07/12 追加 鳥区分追加
            '                    -- あひる
            sSQL += "           ,TOSU7 " & vbCrLf
            sSQL += "           ,KEIYAKU_HASU7 " & vbCrLf
            sSQL += "           ,TUMITATE_KIN7 " & vbCrLf
            '                    -- きじ
            sSQL += "           ,TOSU8 " & vbCrLf
            sSQL += "           ,KEIYAKU_HASU8 " & vbCrLf
            sSQL += "           ,TUMITATE_KIN8 " & vbCrLf
            '                    -- ほろほろ鳥
            sSQL += "           ,TOSU9 " & vbCrLf
            sSQL += "           ,KEIYAKU_HASU9 " & vbCrLf
            sSQL += "           ,TUMITATE_KIN9 " & vbCrLf
            '                    -- 七面鳥
            sSQL += "           ,TOSU10 " & vbCrLf
            sSQL += "           ,KEIYAKU_HASU10 " & vbCrLf
            sSQL += "           ,TUMITATE_KIN10 " & vbCrLf
            '                    -- だちょう
            sSQL += "           ,TOSU11 " & vbCrLf
            sSQL += "           ,KEIYAKU_HASU11 " & vbCrLf
            sSQL += "           ,TUMITATE_KIN11 " & vbCrLf
            '↑2017/07/12 追加 鳥区分追加
            '                    -- 合計(横計)
            sSQL += "           ,HASU_SUM " & vbCrLf
            sSQL += "           ,TUMITATE_SUM " & vbCrLf
            sSQL += "       FROM " & vbCrLf
            sSQL += "          ( " & vbCrLf
            sSQL += "          SELECT " & vbCrLf
            sSQL += "               DTL.KI " & vbCrLf
            sSQL += "              ,DTL.KEN_CD " & vbCrLf
            sSQL += "              ,DTL.KEIYAKU_KBN " & vbCrLf
            sSQL += "              ,DTL.KEIYAKUSYA_CD " & vbCrLf
            '                       -- 採卵鶏 成鶏
            sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 1 THEN 1 END) AS TOSU1 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 1 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU1 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 1 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN1 " & vbCrLf
            '                       -- 採卵鶏 育成
            sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 2 THEN 1 END) AS TOSU2 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 2 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU2 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 2 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN2 " & vbCrLf
            '                       -- 肉用鶏
            sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 3 THEN 1 END) AS TOSU3 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 3 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU3 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 3 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN3 " & vbCrLf
            '                       -- 種鶏 成鶏
            sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 4 THEN 1 END) AS TOSU4 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 4 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU4 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 4 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN4 " & vbCrLf
            '                       -- 種鶏 育成
            sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 5 THEN 1 END) AS TOSU5 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 5 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU5 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 5 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN5 " & vbCrLf
            '                       -- うずら
            '↓2015/06/02 JBD368 UPD 戸数の集計方法を変更
            sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 6 THEN 1 END) AS TOSU6 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 6 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU6 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 6 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN6 " & vbCrLf
            '↓2017/07/12 追加 鳥区分追加
            '                       -- あひる
            sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 7 THEN 1 END) AS TOSU7 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 7 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU7 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 7 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN7 " & vbCrLf
            '                       -- きじ
            sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 8 THEN 1 END) AS TOSU8 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 8 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU8 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 8 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN8 " & vbCrLf
            '                       -- ほろほろ鳥
            sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 9 THEN 1 END) AS TOSU9 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 9 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU9 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 9 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN9 " & vbCrLf
            '                       -- 七面鳥
            sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 10 THEN 1 END) AS TOSU10 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 10 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU10 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 10 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN10 " & vbCrLf
            '                       -- だちょう
            sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 11 THEN 1 END) AS TOSU11 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 11 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU11 " & vbCrLf
            sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 11 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN11 " & vbCrLf
            '↑2017/07/12 追加 鳥区分追加
            '                       -- 合計 戸数(正味)
            sSQL += "              ,SUM(NVL(DTL.KEIYAKU_HASU,0)) AS HASU_SUM " & vbCrLf
            sSQL += "              ,SUM(NVL(DTL.TUMITATE_KIN,0)) AS TUMITATE_SUM " & vbCrLf

            sSQL += "          FROM " & vbCrLf
            sSQL += "             ( " & vbCrLf
            sSQL += "             SELECT " & vbCrLf
            '                          -- 期
            sSQL += "                  KEIJOHO.KI AS KI " & vbCrLf
            '                          -- 都道府県
            sSQL += "                 ,KEI.KEN_CD AS KEN_CD " & vbCrLf
            '                          -- 契約者
            sSQL += "                 ,KEIJOHO.KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
            '                          -- 契約区分
            sSQL += "                 ,KEIJOHO.KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
            '                          -- 鶏区分
            sSQL += "                 ,KEIJOHO.TORI_KBN AS TORI_KBN " & vbCrLf
            '                          -- 羽数合計
            sSQL += "                 ,SUM(KEIJOHO.KEIYAKU_HASU) AS KEIYAKU_HASU " & vbCrLf
            '                          -- 単価
            'sSQL += "                 ,TAN.TUMITATE_TANKA AS TUMITATE_TANKA " & vbCrLf
            '                          -- 生産者積立金
            'sSQL += "                 ,CEIL(SUM(KEIJOHO.KEIYAKU_HASU) * TAN.TUMITATE_TANKA) TUMITATE_KIN " & vbCrLf
            sSQL += "                 ,SUM(KEIJOHO.TUMITATE_KIN) TUMITATE_KIN " & vbCrLf
            '                          -- 手数料
            'sSQL += "                 ,TES.TESURYO_RITU AS TESURYO_RITU " & vbCrLf '2016/05/13　削除
            sSQL += "             FROM ( " & vbCrLf
            '2016/05/13　修正開始
            'メインテーブルを契約情報からに積立明細に変更。
            '一部入金の場合は、どの鳥の種類を入金したかは不明。(積立明細にのみ、鳥の種類別の請求・返還額がセットされている。)
            '全体に対していくら入金されたかは、積立データにしかセットされてしない(積立データは鳥の種類別ではない。)
            'よって、全額入金のデータしか抽出できない。
            sSQL += "                  SELECT " & vbCrLf
            sSQL += "                       MEI.KI AS KI "
            sSQL += "                      ,MEI.KEIYAKUSYA_CD AS KEIYAKUSYA_CD "
            sSQL += "                      ,MEI.KEIYAKU_KBN AS KEIYAKU_KBN "
            sSQL += "                      ,MEI.TORI_KBN AS TORI_KBN "
            sSQL += "                      ,MEI.HASU AS KEIYAKU_HASU "
            sSQL += "                      ,MEI.TUMITATE_KIN AS TUMITATE_KIN "
            'sSQL += "                      ,TUM.KEIYAKU_DATE_FROM "
            sSQL += "                  FROM TT_TUMITATE_MEISAI MEI "
            sSQL += "                      ,TT_TUMITATE TUM "
            sSQL += "                  WHERE TUM.KI = " & numKI.Value
            '2016/10/31　修正開始
            '2016/05/20　追加開始
            'If dateKEIYAKU_Ymd_Fm.Text <> "" Then
            '    sSQL += "              AND TUM.NYUKIN_DATE BETWEEN TO_DATE('" & Format(dateKEIYAKU_Ymd_Fm.Value, "yyyy/MM/dd") & "')" & _
            '                                                 " AND TO_DATE('" & Format(dateKEIYAKU_Ymd_To.Value, "yyyy/MM/dd") & "')"
            'End If
            '2020/09/07 JBD9020 UPD START
            'sSQL += "              AND TUM.NYUKIN_DATE <= TRUNC(SYSDATE)"
            sSQL += "              AND TUM.NYUKIN_DATE <= TO_DATE('" & Format(dateTAISYOBI_Ymd.Value, "yyyy/MM/dd") & "','YYYY/MM/DD')" & vbCrLf
            sSQL += "              AND MEI.KEIYAKU_DATE_FROM <= TO_DATE('" & Format(dateTAISYOBI_Ymd.Value, "yyyy/MM/dd") & "','YYYY/MM/DD')" & vbCrLf
            sSQL += "              AND MEI.KEIYAKU_DATE_TO >= TO_DATE('" & Format(dateTAISYOBI_Ymd.Value, "yyyy/MM/dd") & "','YYYY/MM/DD')" & vbCrLf
            '2020/09/07 JBD9020 UPD END
            '2016/05/20　追加終了
            '2016/10/31　修正終了
            sSQL += "                    AND TUM.SYORI_JOKYO_KBN = 3"
            sSQL += "                    AND TUM.SEIKYU_HENKAN_KBN BETWEEN 1 AND 3"
            'sSQL += "                    AND TUM.DATA_FLG = 1" '2020/09/07 JBD9020 DEL
            sSQL += "                    AND TUM.KI = MEI.KI"
            sSQL += "                    AND TUM.SEIKYU_KAISU = MEI.SEIKYU_KAISU"
            sSQL += "                    AND TUM.KEIYAKUSYA_CD = MEI.KEIYAKUSYA_CD"
            sSQL += "                    AND TUM.TUMITATE_KBN = MEI.TUMITATE_KBN"
            'sSQL += "                    AND MEI.DATA_FLG = 1" '2020/09/07 JBD9020 DEL
            '2016/05/13　修正終了
            sSQL += "                  ) KEIJOHO " & vbCrLf
            sSQL += "                 ,TM_KEIYAKU KEI " & vbCrLf
            'sSQL += "                 ,TM_TANKA TAN " & vbCrLf         '2016/05/13　削除
            'sSQL += "                 ,TM_TANKA TES " & vbCrLf         '2016/05/13　削除
            sSQL += "             WHERE " & vbCrLf
            '                          -- 契約者マスタ
            sSQL += "                  KEIJOHO.KI = KEI.KI(+) " & vbCrLf
            sSQL += "              AND KEIJOHO.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+) " & vbCrLf
            '                          -- 単価マスタ
            'sSQL += "              AND KEIJOHO.KEIYAKU_KBN = TAN.KEIYAKU_KBN(+) " & vbCrLf     '2016/05/13　削除
            'sSQL += "              AND KEIJOHO.TORI_KBN = TAN.TORI_KBN(+) " & vbCrLf           '2016/05/13　削除
            'sSQL += "              AND KEIJOHO.KEIYAKU_DATE_FROM BETWEEN TAN.TAISYO_DATE_FROM AND TAN.TAISYO_DATE_TO " & vbCrLf    '2016/05/13　削除
            '                          -- 手数料
            'sSQL += "              AND 9 = TES.KEIYAKU_KBN " & vbCrLf  '2016/05/13　削除
            'sSQL += "              AND 9 = TES.TORI_KBN " & vbCrLf     '2016/05/13　削除
            'sSQL += "              AND KEI.KEIYAKU_DATE BETWEEN TES.TAISYO_DATE_FROM AND TES.TAISYO_DATE_TO " & vbCrLf '2016/05/13　削除
            '                          -- 条件
            'sSQL += "              AND KEIJOHO.DATA_FLG = 1 " & vbCrLf         '2016/05/13　削除  (KEIJOHOのSELECT部分に移動)
            '                          -- 期条件
            'sSQL += "              AND KEIJOHO.KI = " & numKI.Value & vbCrLf   '2016/05/13　削除  (KEIJOHOのSELECT部分に移動)

            ''==必須条件=======================
            '2016/10/31　修正開始
            ''契約締結日範囲FROMTO
            'If dateKEIYAKU_Ymd_Fm.Text <> "" Then
            '    sSQL += "              AND KEI.KEIYAKU_DATE BETWEEN TO_DATE('" & Format(dateKEIYAKU_Ymd_Fm.Value, "yyyy/MM/dd") & "') AND TO_DATE('" & Format(dateKEIYAKU_Ymd_To.Value, "yyyy/MM/dd") & "') " & vbCrLf
            'End If
            '2020/09/07 JBD9020 UPD START
            'sSQL += "              AND KEI.KEIYAKU_DATE <= TRUNC(SYSDATE)"
            sSQL += "              AND KEI.KEIYAKU_DATE <= TO_DATE('" & Format(dateTAISYOBI_Ymd.Value, "yyyy/MM/dd") & "','YYYY/MM/DD')" & vbCrLf
            '2020/09/07 JBD9020 UPD END
            '2016/10/31　修正終了

            '==任意条件=======================
            '契約区分FROMTO
            '2020/09/07 JBD9020 UPD START
            'If cboKEIYAKU_KBN_Cd_Fm.Text <> "" Then
            '    sSQL += "              AND KEI.KEIYAKU_KBN BETWEEN " & cboKEIYAKU_KBN_Cd_Fm.Text & " AND " & cboKEIYAKU_KBN_Cd_To.Text & vbCrLf
            'End If
            If chkKAZOKU.Checked And chkKIGYOU.Checked And chkIGAI.Checked Then
                '全チェック
            Else
                Dim strKeiyakuKbn As String = ""
                '新規契約者
                If chkKAZOKU.Checked Then
                    strKeiyakuKbn = "1"
                End If
                '継続契約者
                If chkKIGYOU.Checked Then
                    If strKeiyakuKbn.Length = 0 Then
                        strKeiyakuKbn = "2"
                    Else
                        strKeiyakuKbn += ",2"
                    End If
                End If
                '中止者
                If chkIGAI.Checked Then
                    If strKeiyakuKbn.Length = 0 Then
                        strKeiyakuKbn = "3"
                    Else
                        strKeiyakuKbn += ",3"
                    End If
                End If
                If strKeiyakuKbn.Length > 0 Then
                    '2021/01/28 JBD9020 UPD START
                    'sSQL += "    AND KEI.KEIYAKU_KBN IN( " & strKeiyakuKbn & ")" & vbCrLf
                    sSQL += "    AND KEIJOHO.KEIYAKU_KBN IN( " & strKeiyakuKbn & ")" & vbCrLf
                    '2021/01/28 JBD9020 UPD END
                End If
            End If
            '2020/09/07 JBD9020 UPD END

            '都道府県FROMTO
            If cboKEN_Cd_Fm.Text <> "" Then
                sSQL += "              AND KEI.KEN_CD BETWEEN " & cboKEN_Cd_Fm.Text & " AND " & cboKEN_Cd_To.Text & vbCrLf
            End If

            '契約者FROMTO
            If cboKEIYAKUSYA_Cd_Fm.Text <> "" Then
                sSQL += "              AND KEI.KEIYAKUSYA_CD BETWEEN " & cboKEIYAKUSYA_Cd_Fm.Text & " AND " & cboKEIYAKUSYA_Cd_To.Text & vbCrLf
            End If


            sSQL += "             GROUP BY " & vbCrLf
            sSQL += "                 KEIJOHO.KI " & vbCrLf
            sSQL += "                ,KEI.KEN_CD " & vbCrLf
            sSQL += "                ,KEIJOHO.KEIYAKU_KBN " & vbCrLf
            sSQL += "                ,KEIJOHO.KEIYAKUSYA_CD " & vbCrLf
            sSQL += "                ,KEIJOHO.TORI_KBN " & vbCrLf
            'sSQL += "                ,TAN.TUMITATE_TANKA " & vbCrLf
            'sSQL += "                ,TES.TESURYO_RITU " & vbCrLf  '2016/05/13　削除
            sSQL += "             ORDER BY " & vbCrLf
            sSQL += "                 KI " & vbCrLf
            sSQL += "                ,KEN_CD " & vbCrLf
            sSQL += "                ,KEIYAKU_KBN " & vbCrLf
            sSQL += "                ,KEIYAKUSYA_CD " & vbCrLf
            sSQL += "                ,TORI_KBN " & vbCrLf
            sSQL += "             ) DTL " & vbCrLf



            'sSQL += "            ,( " & vbCrLf
            'sSQL += "             SELECT " & vbCrLf
            'sSQL += "                  KI " & vbCrLf
            'sSQL += "                 ,KEIYAKU_KBN " & vbCrLf
            'sSQL += "                 ,KEIYAKUSYA_CD " & vbCrLf
            'sSQL += "                 ,COUNT(DISTINCT NOJO_CD) OVER (PARTITION BY KEIYAKU_KBN,KEIYAKUSYA_CD) AS NOJO_CNT_SUM " & vbCrLf
            'sSQL += "             FROM TT_KEIYAKU_JOHO " & vbCrLf
            'sSQL += "             WHERE " & vbCrLf
            ''                          -- 条件
            'sSQL += "                  DATA_FLG = 1 " & vbCrLf
            ''                          -- 期条件
            'sSQL += "              AND KI = " & numKI.Value & vbCrLf

            'sSQL += "             ) TOSU_SUM " & vbCrLf
            'sSQL += "          WHERE DTL.KI = TOSU_SUM.KI(+) " & vbCrLf
            'sSQL += "            AND DTL.KEIYAKU_KBN = TOSU_SUM.KEIYAKU_KBN(+) " & vbCrLf
            'sSQL += "            AND DTL.KEIYAKUSYA_CD = TOSU_SUM.KEIYAKUSYA_CD(+) " & vbCrLf




            sSQL += "          GROUP BY " & vbCrLf
            sSQL += "              DTL.KI " & vbCrLf
            sSQL += "             ,DTL.KEN_CD " & vbCrLf
            sSQL += "             ,DTL.KEIYAKU_KBN " & vbCrLf
            sSQL += "             ,DTL.KEIYAKUSYA_CD " & vbCrLf
            sSQL += "          ORDER BY " & vbCrLf
            sSQL += "              KI " & vbCrLf
            sSQL += "             ,KEN_CD " & vbCrLf
            sSQL += "             ,KEIYAKU_KBN " & vbCrLf
            sSQL += "             ,KEIYAKUSYA_CD " & vbCrLf
            sSQL += "          ) " & vbCrLf
            sSQL += "       ORDER BY " & vbCrLf
            sSQL += "           KI " & vbCrLf
            sSQL += "          ,KEN_CD " & vbCrLf
            sSQL += "          ,KEIYAKU_KBN " & vbCrLf
            sSQL += "          ,KEIYAKUSYA_CD " & vbCrLf
            sSQL += "       ) " & vbCrLf
            sSQL += "    GROUP BY CUBE ( " & vbCrLf
            sSQL += "             KEN_CD " & vbCrLf
            sSQL += "            ,KEIYAKU_KBN " & vbCrLf
            sSQL += "            ,KEIYAKUSYA_CD " & vbCrLf
            sSQL += "             ) " & vbCrLf
            sSQL += "    ORDER BY " & vbCrLf
            sSQL += "        KI " & vbCrLf
            sSQL += "       ,KEN_CD " & vbCrLf
            sSQL += "       ,KEIYAKU_KBN " & vbCrLf
            sSQL += "       ,KEIYAKUSYA_CD " & vbCrLf
            sSQL += "    ) GRP " & vbCrLf
            sSQL += "    ,TM_KEIYAKU KEI " & vbCrLf
            sSQL += "    ,TM_CODE CD01 " & vbCrLf
            sSQL += "    ,TM_CODE CD05 " & vbCrLf
            sSQL += " WHERE " & vbCrLf
            If rdoKEIYAKU_KEI.Checked Then
                '        -- 0:明細,1:契約者別,3:都道府県別,5:契約区分別,7:総合計
                sSQL += "    GRPID IN (0,1,3,5,7) " & vbCrLf
            Else
                '        -- 1:契約者別,3:都道府県別,5:契約区分別,7:総合計
                sSQL += "    GRPID IN (1,3,5,7) " & vbCrLf
            End If
            '            -- 契約者マスタ
            sSQL += " AND GRP.KI = KEI.KI(+) " & vbCrLf
            sSQL += " AND GRP.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+) " & vbCrLf
            '            -- 契約区分
            sSQL += " AND 1 = CD01.SYURUI_KBN(+) " & vbCrLf
            sSQL += " AND GRP.KEIYAKU_KBN = CD01.MEISYO_CD(+) " & vbCrLf
            '            -- 都道府県
            sSQL += " AND 5 = CD05.SYURUI_KBN(+) " & vbCrLf
            sSQL += " AND GRP.KEN_CD = CD05.MEISYO_CD(+) " & vbCrLf
            sSQL += " ORDER BY " & vbCrLf
            sSQL += "     KI " & vbCrLf
            sSQL += "    ,KEN_CD " & vbCrLf
            sSQL += "    ,KEIYAKU_KBN " & vbCrLf
            sSQL += "    ,KEIYAKUSYA_CD " & vbCrLf

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
#Region "f_make_SQL_old EXCEデータ出力用ＳＱＬ作成(2016/05/13　削除)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :EXCELデータ出力用ＳＱＬ作成(契約情報ベース)
    '引数            :区分
    '引数            :SQLを返す
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    ' ''' <summary>
    ' ''' ＳＱＬ文作成
    ' ''' </summary>
    ' ''' <param name="iKbn">
    ' ''' 
    ' ''' </param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function f_make_SQL(ByVal iKbn As Integer, ByRef wSQL As String) As Boolean
    '    Dim ret As Boolean = False
    '    Dim sSQL As String = vbNullString
    '    Dim sSQL2 As String = vbNullString
    '    Dim sSQL3 As String = vbNullString

    '    Try
    '        '対象期・年度の取得
    '        Dim SyoriKI = New Obj_TM_SYORI_NENDO_KI()

    '        sSQL = " SELECT " & vbCrLf
    '        sSQL += "   TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI " & vbCrLf
    '        '-- 期
    '        If SyoriKI.pKI = numKI.Value Then
    '            sSQL += " ,'対象期：第" & numKI.Value & "期（' || TO_CHAR(TO_DATE('" & SyoriKI.pTAISYO_NENDO_byDate & "'), '""""EEYY""年度～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & SyoriKI.pJIGYO_SYURYO_NENDO_byDate & "'), '""""EEYY""年度）""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS TAISYO_KI " & vbCrLf
    '        Else
    '            sSQL += " ,'対象期：第" & numKI.Value & "期' AS TAISYO_KI " & vbCrLf
    '        End If

    '        '-- 契約締結日範囲
    '        sSQL += " ,'＜＜　家畜防疫互助基金事業加入状況表（' || TO_CHAR(TO_DATE('" & dateKEIYAKU_Ymd_Fm.Value & "'), 'EEYY""年""MM""月""DD""日～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & dateKEIYAKU_Ymd_To.Value & "'), 'EEYY""年""MM""月""DD""日）　＞＞""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ITAKU_NAME_HED " & vbCrLf

    '        '--  連番
    '        sSQL += " ,CASE " & vbCrLf
    '        sSQL += "    WHEN GRP.GRPID = 0 THEN TO_CHAR(GRP.ROW_NUM) " & vbCrLf
    '        sSQL += "    ELSE NULL " & vbCrLf
    '        sSQL += "  END ROW_NUM " & vbCrLf
    '        '-- 期
    '        sSQL += " ,GRP.KI AS KI " & vbCrLf

    '        '-- 都道府県
    '        sSQL += " ,GRP.KEN_CD AS KEN_CD " & vbCrLf
    '        sSQL += " ,CD05.MEISYO AS KEN_NM " & vbCrLf
    '        '-- 契約区分 
    '        sSQL += " ,GRP.KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
    '        sSQL += " ,CD01.RYAKUSYO AS KEIYAKU_KBN_NM " & vbCrLf
    '        '-- 契約者 
    '        sSQL += " ,GRP.KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += " ,CASE " & vbCrLf
    '        sSQL += "    WHEN GRP.GRPID = 1 THEN CD01.RYAKUSYO || '計' " & vbCrLf
    '        sSQL += "    WHEN GRP.GRPID = 3 THEN CD05.MEISYO || '計' " & vbCrLf
    '        sSQL += "    WHEN GRP.GRPID = 5 THEN CD05.MEISYO || '合計' " & vbCrLf
    '        sSQL += "    WHEN GRP.GRPID = 7 THEN CD05.MEISYO || '総合計' " & vbCrLf
    '        sSQL += "    ELSE KEI.KEIYAKUSYA_NAME " & vbCrLf
    '        sSQL += "  END KEIYAKUSYA_NAME " & vbCrLf
    '        sSQL += " ,KEI.ADDR_1 || KEI.ADDR_2 || KEI.ADDR_3 || KEI.ADDR_4 AS ADDR " & vbCrLf

    '        sSQL += " ,GRP.GRPID AS GRPID " & vbCrLf

    '        '-- 採卵鶏 成鶏 
    '        sSQL += " ,GRP.TOSU1 AS TOSU1 " & vbCrLf
    '        sSQL += " ,GRP.KEIYAKU_HASU1 AS KEIYAKU_HASU1 " & vbCrLf
    '        sSQL += " ,GRP.TUMITATE_KIN1 AS TUMITATE_KIN1 " & vbCrLf

    '        '-- 採卵鶏 育成
    '        sSQL += " ,GRP.TOSU2 AS TOSU2 " & vbCrLf
    '        sSQL += " ,GRP.KEIYAKU_HASU2 AS KEIYAKU_HASU2 " & vbCrLf
    '        sSQL += " ,GRP.TUMITATE_KIN2 AS TUMITATE_KIN2 " & vbCrLf

    '        '-- 肉用鶏
    '        sSQL += " ,GRP.TOSU3 AS TOSU3 " & vbCrLf
    '        sSQL += " ,GRP.KEIYAKU_HASU3 AS KEIYAKU_HASU3 " & vbCrLf
    '        sSQL += " ,GRP.TUMITATE_KIN3 AS TUMITATE_KIN3 " & vbCrLf

    '        '-- 種鶏 成鶏
    '        sSQL += " ,GRP.TOSU4 AS TOSU4 " & vbCrLf
    '        sSQL += " ,GRP.KEIYAKU_HASU4 AS KEIYAKU_HASU4 " & vbCrLf
    '        sSQL += " ,GRP.TUMITATE_KIN4 AS TUMITATE_KIN4 " & vbCrLf

    '        '-- 種鶏 育成
    '        sSQL += " ,GRP.TOSU5 AS TOSU5 " & vbCrLf
    '        sSQL += " ,GRP.KEIYAKU_HASU5 AS KEIYAKU_HASU5 " & vbCrLf
    '        sSQL += " ,GRP.TUMITATE_KIN5 AS TUMITATE_KIN5 " & vbCrLf

    '        '-- うずら
    '        sSQL += " ,GRP.TOSU6 AS TOSU6 " & vbCrLf
    '        sSQL += " ,GRP.KEIYAKU_HASU6 AS KEIYAKU_HASU6 " & vbCrLf
    '        sSQL += " ,GRP.TUMITATE_KIN6 AS TUMITATE_KIN6 " & vbCrLf

    '        '-- 合計(横計)
    '        sSQL += " ,GRP.TOSU_SUM AS TOSU_SUM " & vbCrLf
    '        sSQL += " ,GRP.HASU_SUM AS HASU_SUM " & vbCrLf
    '        sSQL += " ,GRP.TUMITATE_SUM AS TUMITATE_SUM " & vbCrLf

    '        sSQL += " FROM " & vbCrLf
    '        '-- 契約区分別、都道府県別の集計
    '        sSQL += "    (" & vbCrLf
    '        sSQL += "    SELECT " & vbCrLf
    '        sSQL += "         MAX(ROWNUM) AS ROW_NUM " & vbCrLf
    '        sSQL += "        ,MAX(KI) AS KI " & vbCrLf
    '        sSQL += "        ,KEN_CD  AS KEN_CD " & vbCrLf
    '        sSQL += "        ,KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
    '        sSQL += "        ,KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "        ,GROUPING_ID(KEN_CD, KEIYAKU_KBN, KEIYAKUSYA_CD) AS GRPID " & vbCrLf
    '        '                 -- 採卵鶏 成鶏
    '        sSQL += "        ,SUM(TOSU1) AS TOSU1 " & vbCrLf
    '        sSQL += "        ,SUM(KEIYAKU_HASU1) AS KEIYAKU_HASU1 " & vbCrLf
    '        sSQL += "        ,SUM(TUMITATE_KIN1) AS TUMITATE_KIN1 " & vbCrLf
    '        '                 -- 採卵鶏 育成
    '        sSQL += "        ,SUM(TOSU2) AS TOSU2 " & vbCrLf
    '        sSQL += "        ,SUM(KEIYAKU_HASU2) AS KEIYAKU_HASU2 " & vbCrLf
    '        sSQL += "        ,SUM(TUMITATE_KIN2) AS TUMITATE_KIN2 " & vbCrLf
    '        '                 -- 肉用鶏
    '        sSQL += "        ,SUM(TOSU3) AS TOSU3 " & vbCrLf
    '        sSQL += "        ,SUM(KEIYAKU_HASU3) AS KEIYAKU_HASU3 " & vbCrLf
    '        sSQL += "        ,SUM(TUMITATE_KIN3) AS TUMITATE_KIN3 " & vbCrLf
    '        '                 -- 種鶏 成鶏
    '        sSQL += "        ,SUM(TOSU4) AS TOSU4 " & vbCrLf
    '        sSQL += "        ,SUM(KEIYAKU_HASU4) AS KEIYAKU_HASU4 " & vbCrLf
    '        sSQL += "        ,SUM(TUMITATE_KIN4) AS TUMITATE_KIN4 " & vbCrLf
    '        '                 -- 種鶏 育成
    '        sSQL += "        ,SUM(TOSU5) AS TOSU5 " & vbCrLf
    '        sSQL += "        ,SUM(KEIYAKU_HASU5) AS KEIYAKU_HASU5 " & vbCrLf
    '        sSQL += "        ,SUM(TUMITATE_KIN5) AS TUMITATE_KIN5 " & vbCrLf
    '        '                 -- うずら
    '        sSQL += "        ,SUM(TOSU6) AS TOSU6 " & vbCrLf
    '        sSQL += "        ,SUM(KEIYAKU_HASU6) AS KEIYAKU_HASU6 " & vbCrLf
    '        sSQL += "        ,SUM(TUMITATE_KIN6) AS TUMITATE_KIN6 " & vbCrLf
    '        '                 -- 合計(横計)
    '        '↓2015/06/02 JBD368 UPD 戸数の集計方法を変更のためここでは取得を廃止
    '        'sSQL += "        ,SUM(TOSU_SUM) AS TOSU_SUM " & vbCrLf
    '        sSQL += "        ,SUM(1) AS TOSU_SUM " & vbCrLf
    '        '↑2015/06/02 JBD368 UPD
    '        sSQL += "        ,SUM(HASU_SUM) AS HASU_SUM " & vbCrLf
    '        sSQL += "        ,SUM(TUMITATE_SUM) AS TUMITATE_SUM " & vbCrLf
    '        sSQL += "    FROM " & vbCrLf
    '        sSQL += "       ( " & vbCrLf
    '        sSQL += "       SELECT " & vbCrLf
    '        sSQL += "            KI " & vbCrLf
    '        sSQL += "           ,ROWNUM " & vbCrLf
    '        sSQL += "           ,KEN_CD " & vbCrLf
    '        sSQL += "           ,KEIYAKU_KBN " & vbCrLf
    '        sSQL += "           ,KEIYAKUSYA_CD " & vbCrLf
    '        '                    -- 採卵鶏 成鶏
    '        sSQL += "           ,TOSU1 " & vbCrLf
    '        sSQL += "           ,KEIYAKU_HASU1 " & vbCrLf
    '        sSQL += "           ,TUMITATE_KIN1 " & vbCrLf
    '        '                    -- 採卵鶏 育成
    '        sSQL += "           ,TOSU2 " & vbCrLf
    '        sSQL += "           ,KEIYAKU_HASU2 " & vbCrLf
    '        sSQL += "           ,TUMITATE_KIN2 " & vbCrLf
    '        '                    -- 肉用鶏
    '        sSQL += "           ,TOSU3 " & vbCrLf
    '        sSQL += "           ,KEIYAKU_HASU3 " & vbCrLf
    '        sSQL += "           ,TUMITATE_KIN3 " & vbCrLf
    '        '                    -- 種鶏 成鶏
    '        sSQL += "           ,TOSU4 " & vbCrLf
    '        sSQL += "           ,KEIYAKU_HASU4 " & vbCrLf
    '        sSQL += "           ,TUMITATE_KIN4 " & vbCrLf
    '        '                    -- 種鶏 育成
    '        sSQL += "           ,TOSU5 " & vbCrLf
    '        sSQL += "           ,KEIYAKU_HASU5 " & vbCrLf
    '        sSQL += "           ,TUMITATE_KIN5 " & vbCrLf
    '        '                    -- うずら
    '        sSQL += "           ,TOSU6 " & vbCrLf
    '        sSQL += "           ,KEIYAKU_HASU6 " & vbCrLf
    '        sSQL += "           ,TUMITATE_KIN6 " & vbCrLf
    '        '                    -- 合計(横計)
    '        '↓2015/06/02 JBD368 DEL 戸数の集計方法を変更のためここでは取得を廃止
    '        'sSQL += "           ,TOSU_SUM " & vbCrLf
    '        '↑2015/06/02 JBD368 DEL
    '        sSQL += "           ,HASU_SUM " & vbCrLf
    '        sSQL += "           ,TUMITATE_SUM " & vbCrLf
    '        sSQL += "       FROM " & vbCrLf
    '        sSQL += "          ( " & vbCrLf
    '        sSQL += "          SELECT " & vbCrLf
    '        sSQL += "               DTL.KI " & vbCrLf
    '        sSQL += "              ,DTL.KEN_CD " & vbCrLf
    '        sSQL += "              ,DTL.KEIYAKU_KBN " & vbCrLf
    '        sSQL += "              ,DTL.KEIYAKUSYA_CD " & vbCrLf
    '        '                       -- 採卵鶏 成鶏
    '        '↓2015/06/02 JBD368 UPD 戸数の集計方法を変更
    '        'sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 1 THEN NVL(DTL.TOSU1,0) END) AS TOSU1 " & vbCrLf
    '        sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 1 THEN 1 END) AS TOSU1 " & vbCrLf
    '        '↑2015/06/02 JBD368 UPD
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 1 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU1 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 1 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN1 " & vbCrLf
    '        '                       -- 採卵鶏 育成
    '        '↓2015/06/02 JBD368 UPD 戸数の集計方法を変更
    '        'sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 2 THEN NVL(DTL.TOSU2,0) END) AS TOSU2 " & vbCrLf
    '        sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 2 THEN 1 END) AS TOSU2 " & vbCrLf
    '        '↑2015/06/02 JBD368 UPD
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 2 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU2 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 2 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN2 " & vbCrLf
    '        '                       -- 肉用鶏
    '        '↓2015/06/02 JBD368 UPD 戸数の集計方法を変更
    '        'sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 3 THEN NVL(DTL.TOSU3,0) END) AS TOSU3 " & vbCrLf
    '        sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 3 THEN 1 END) AS TOSU3 " & vbCrLf
    '        '↑2015/06/02 JBD368 UPD
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 3 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU3 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 3 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN3 " & vbCrLf
    '        '                       -- 種鶏 成鶏
    '        '↓2015/06/02 JBD368 UPD 戸数の集計方法を変更
    '        'sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 4 THEN NVL(DTL.TOSU4,0) END) AS TOSU4 " & vbCrLf
    '        sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 4 THEN 1 END) AS TOSU4 " & vbCrLf
    '        '↑2015/06/02 JBD368 UPD
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 4 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU4 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 4 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN4 " & vbCrLf
    '        '                       -- 種鶏 育成
    '        '↓2015/06/02 JBD368 UPD 戸数の集計方法を変更
    '        'sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 5 THEN NVL(DTL.TOSU5,0) END) AS TOSU5 " & vbCrLf
    '        sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 5 THEN 1 END) AS TOSU5 " & vbCrLf
    '        '↑2015/06/02 JBD368 UPD
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 5 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU5 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 5 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN5 " & vbCrLf
    '        '                       -- うずら
    '        '↓2015/06/02 JBD368 UPD 戸数の集計方法を変更
    '        'sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 6 THEN NVL(DTL.TOSU6,0) END) AS TOSU6 " & vbCrLf
    '        sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 6 THEN 1 END) AS TOSU6 " & vbCrLf
    '        '↑2015/06/02 JBD368 UPD
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 6 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU6 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 6 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN6 " & vbCrLf
    '        '                       -- 合計 戸数(正味)
    '        '↓2015/06/02 JBD368 UPD 戸数の集計方法を変更のためここでは取得を廃止
    '        'sSQL += "              ,MAX(NVL(DTL.TOSU_SUM,0)) AS TOSU_SUM " & vbCrLf
    '        '↑2015/06/02 JBD368 UPD
    '        sSQL += "              ,SUM(NVL(DTL.KEIYAKU_HASU,0)) AS HASU_SUM " & vbCrLf
    '        sSQL += "              ,SUM(NVL(DTL.TUMITATE_KIN,0)) AS TUMITATE_SUM " & vbCrLf

    '        sSQL += "          FROM " & vbCrLf
    '        sSQL += "             ( " & vbCrLf
    '        sSQL += "             SELECT " & vbCrLf
    '        '                          -- 期
    '        sSQL += "                  KEIJOHO.KI AS KI " & vbCrLf
    '        '                          -- 都道府県
    '        sSQL += "                 ,KEI.KEN_CD AS KEN_CD " & vbCrLf
    '        '                          -- 契約者
    '        sSQL += "                 ,KEIJOHO.KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
    '        '                          -- 契約区分
    '        sSQL += "                 ,KEIJOHO.KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
    '        '                          -- 鶏区分
    '        sSQL += "                 ,KEIJOHO.TORI_KBN AS TORI_KBN " & vbCrLf
    '        '↓2015/06/02 JBD368 DEL 戸数は農場数ではなく契約者数のためここでの集計は廃止
    '        '                          -- 戸数
    '        'sSQL += "                 ,MAX(KEIJOHO.TOSU1) AS TOSU1 " & vbCrLf
    '        'sSQL += "                 ,MAX(KEIJOHO.TOSU2) AS TOSU2 " & vbCrLf
    '        'sSQL += "                 ,MAX(KEIJOHO.TOSU3) AS TOSU3 " & vbCrLf
    '        'sSQL += "                 ,MAX(KEIJOHO.TOSU4) AS TOSU4 " & vbCrLf
    '        'sSQL += "                 ,MAX(KEIJOHO.TOSU5) AS TOSU5 " & vbCrLf
    '        'sSQL += "                 ,MAX(KEIJOHO.TOSU6) AS TOSU6 " & vbCrLf
    '        'sSQL += "                 ,MAX(KEIJOHO.TOSU_SUM) AS TOSU_SUM " & vbCrLf
    '        '↑2015/06/02 JBD368 DEL
    '        '                          -- 羽数合計
    '        sSQL += "                 ,SUM(KEIJOHO.KEIYAKU_HASU) AS KEIYAKU_HASU " & vbCrLf
    '        '                          -- 単価
    '        sSQL += "                 ,TAN.TUMITATE_TANKA AS TUMITATE_TANKA " & vbCrLf
    '        '                          -- 生産者積立金
    '        'うずらの単価は1/5ではなく、そのまま使用
    '        sSQL += "                 ,CEIL(SUM(KEIJOHO.KEIYAKU_HASU) * TAN.TUMITATE_TANKA) TUMITATE_KIN " & vbCrLf
    '        '                          -- 手数料
    '        'sSQL += "                 ,TES.TESURYO_RITU AS TESURYO_RITU " & vbCrLf     '2016/05/13　削除
    '        sSQL += "             FROM ( " & vbCrLf
    '        sSQL += "                  SELECT " & vbCrLf
    '        sSQL += "                       KEIJOHO.KI AS KI " & vbCrLf
    '        sSQL += "                      ,KEIJOHO.KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "                      ,KEIJOHO.KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
    '        sSQL += "                      ,KEIJOHO.TORI_KBN AS TORI_KBN " & vbCrLf
    '        sSQL += "                      ,KEIJOHO.NOJO_CD AS NOJO_CD " & vbCrLf
    '        sSQL += "                      ,KEIJOHO.KEIYAKU_HASU AS KEIYAKU_HASU " & vbCrLf
    '        sSQL += "                      ,KEIJOHO.KEIYAKU_DATE_FROM " & vbCrLf
    '        sSQL += "                      ,KEIJOHO.DATA_FLG " & vbCrLf
    '        '2016/05/12　追加開始
    '        sSQL += "                      ,CASE WHEN KEIJOHO.KEIYAKU_HENKO_KBN = 9 THEN 1"     '--移動のときは、入金済み"
    '        sSQL += "                            WHEN NVL(TUM.SYORI_JOKYO_KBN,0) = 3 THEN 1"    '--積立．処理状況=3.入金済み"
    '        sSQL += "                            ELSE 0 END NYUKIN_FLG "
    '        '2016/05/12　追加終了
    '        '↓2015/06/02 JBD368 DEL 戸数は農場数ではなく契約者数のためここでの集計は廃止
    '        'sSQL += "                      ,CASE WHEN KEIJOHO.TORI_KBN = 1 THEN COUNT(DISTINCT KEIJOHO.NOJO_CD) OVER (PARTITION BY KEIJOHO.KEIYAKU_KBN,KEIJOHO.KEIYAKUSYA_CD,KEIJOHO.TORI_KBN) END TOSU1 " & vbCrLf
    '        'sSQL += "                      ,CASE WHEN KEIJOHO.TORI_KBN = 2 THEN COUNT(DISTINCT KEIJOHO.NOJO_CD) OVER (PARTITION BY KEIJOHO.KEIYAKU_KBN,KEIJOHO.KEIYAKUSYA_CD,KEIJOHO.TORI_KBN) END TOSU2 " & vbCrLf
    '        'sSQL += "                      ,CASE WHEN KEIJOHO.TORI_KBN = 3 THEN COUNT(DISTINCT KEIJOHO.NOJO_CD) OVER (PARTITION BY KEIJOHO.KEIYAKU_KBN,KEIJOHO.KEIYAKUSYA_CD,KEIJOHO.TORI_KBN) END TOSU3 " & vbCrLf
    '        'sSQL += "                      ,CASE WHEN KEIJOHO.TORI_KBN = 4 THEN COUNT(DISTINCT KEIJOHO.NOJO_CD) OVER (PARTITION BY KEIJOHO.KEIYAKU_KBN,KEIJOHO.KEIYAKUSYA_CD,KEIJOHO.TORI_KBN) END TOSU4 " & vbCrLf
    '        'sSQL += "                      ,CASE WHEN KEIJOHO.TORI_KBN = 5 THEN COUNT(DISTINCT KEIJOHO.NOJO_CD) OVER (PARTITION BY KEIJOHO.KEIYAKU_KBN,KEIJOHO.KEIYAKUSYA_CD,KEIJOHO.TORI_KBN) END TOSU5 " & vbCrLf
    '        'sSQL += "                      ,CASE WHEN KEIJOHO.TORI_KBN = 6 THEN COUNT(DISTINCT KEIJOHO.NOJO_CD) OVER (PARTITION BY KEIJOHO.KEIYAKU_KBN,KEIJOHO.KEIYAKUSYA_CD,KEIJOHO.TORI_KBN) END TOSU6 " & vbCrLf
    '        'sSQL += "                      ,COUNT(DISTINCT KEIJOHO.NOJO_CD) OVER (PARTITION BY KEIJOHO.KEIYAKU_KBN,KEIJOHO.KEIYAKUSYA_CD) AS TOSU_SUM " & vbCrLf
    '        '↑2015/06/02 JBD368 DEL
    '        sSQL += "                  FROM TT_KEIYAKU_JOHO KEIJOHO " & vbCrLf
    '        sSQL += "                      ,TT_TUMITATE TUM "           '2016/05/12　追加
    '        sSQL += "                  WHERE KEIJOHO.KI = TUM.KI(+) "                       '2016/05/12　追加
    '        sSQL += "                    AND KEIJOHO.SEIKYU_KAISU = TUM.SEIKYU_KAISU(+) "   '2016/05/12　追加
    '        sSQL += "                    AND KEIJOHO.KEIYAKUSYA_CD = TUM.KEIYAKUSYA_CD(+) " '2016/05/12　追加
    '        sSQL += "                    AND 1 = TUM.TUMITATE_KBN(+) "                      '2016/05/12　追加
    '        sSQL += "                    AND 1 = TUM.DATA_FLG(+) "                          '2016/05/12　追加
    '        sSQL += "                  ) KEIJOHO " & vbCrLf
    '        sSQL += "                 ,TM_KEIYAKU KEI " & vbCrLf
    '        sSQL += "                 ,TM_TANKA TAN " & vbCrLf
    '        sSQL += "                 ,TM_TANKA TES " & vbCrLf
    '        sSQL += "             WHERE " & vbCrLf
    '        '                          -- 契約者マスタ
    '        sSQL += "                  KEIJOHO.KI = KEI.KI(+) " & vbCrLf
    '        sSQL += "              AND KEIJOHO.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+) " & vbCrLf
    '        '                          -- 単価マスタ
    '        sSQL += "              AND KEIJOHO.KEIYAKU_KBN = TAN.KEIYAKU_KBN(+) " & vbCrLf
    '        sSQL += "              AND KEIJOHO.TORI_KBN = TAN.TORI_KBN(+) " & vbCrLf
    '        sSQL += "              AND KEIJOHO.KEIYAKU_DATE_FROM BETWEEN TAN.TAISYO_DATE_FROM AND TAN.TAISYO_DATE_TO " & vbCrLf
    '        '                          -- 手数料
    '        sSQL += "              AND 9 = TES.KEIYAKU_KBN " & vbCrLf
    '        sSQL += "              AND 9 = TES.TORI_KBN " & vbCrLf
    '        sSQL += "              AND KEI.KEIYAKU_DATE BETWEEN TES.TAISYO_DATE_FROM AND TES.TAISYO_DATE_TO " & vbCrLf
    '        '                          -- 条件
    '        sSQL += "              AND KEIJOHO.DATA_FLG = 1 " & vbCrLf
    '        '                          -- 期条件
    '        sSQL += "              AND KEIJOHO.KI = " & numKI.Value & vbCrLf
    '        '                          -- 入金済み条件
    '        sSQL += "              AND KEIJOHO.NYUKIN_FLG = 1 "     '2016/05/12　追加

    '        ''==必須条件=======================
    '        '契約締結日範囲FROMTO
    '        If dateKEIYAKU_Ymd_Fm.Text <> "" Then
    '            sSQL += "              AND KEI.KEIYAKU_DATE BETWEEN TO_DATE('" & Format(dateKEIYAKU_Ymd_Fm.Value, "yyyy/MM/dd") & "') AND TO_DATE('" & Format(dateKEIYAKU_Ymd_To.Value, "yyyy/MM/dd") & "') " & vbCrLf
    '        End If

    '        '==任意条件=======================
    '        '契約区分FROMTO
    '        If cboKEIYAKU_KBN_Cd_Fm.Text <> "" Then
    '            sSQL += "              AND KEI.KEIYAKU_KBN BETWEEN " & cboKEIYAKU_KBN_Cd_Fm.Text & " AND " & cboKEIYAKU_KBN_Cd_To.Text & vbCrLf
    '        End If

    '        '都道府県FROMTO
    '        If cboKEN_Cd_Fm.Text <> "" Then
    '            '↓2015/06/02 JBD368 UPD
    '            'sSQL += "              AND KEI.KEN_CD BETWEEN " & cboKEN_Cd_Fm.Text & " AND " & cboKEN_Cd_Fm.Text & vbCrLf
    '            sSQL += "              AND KEI.KEN_CD BETWEEN " & cboKEN_Cd_Fm.Text & " AND " & cboKEN_Cd_To.Text & vbCrLf
    '            '↑2015/06/02 JBD368 UPD 
    '        End If

    '        '契約者FROMTO
    '        If cboKEIYAKUSYA_Cd_Fm.Text <> "" Then
    '            sSQL += "              AND KEI.KEIYAKUSYA_CD BETWEEN " & cboKEIYAKUSYA_Cd_Fm.Text & " AND " & cboKEIYAKUSYA_Cd_To.Text & vbCrLf
    '        End If


    '        sSQL += "             GROUP BY " & vbCrLf
    '        sSQL += "                 KEIJOHO.KI " & vbCrLf
    '        sSQL += "                ,KEI.KEN_CD " & vbCrLf
    '        sSQL += "                ,KEIJOHO.KEIYAKU_KBN " & vbCrLf
    '        sSQL += "                ,KEIJOHO.KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "                ,KEIJOHO.TORI_KBN " & vbCrLf
    '        sSQL += "                ,TAN.TUMITATE_TANKA " & vbCrLf
    '        sSQL += "                ,TES.TESURYO_RITU " & vbCrLf
    '        sSQL += "             ORDER BY " & vbCrLf
    '        sSQL += "                 KI " & vbCrLf
    '        sSQL += "                ,KEN_CD " & vbCrLf
    '        sSQL += "                ,KEIYAKU_KBN " & vbCrLf
    '        sSQL += "                ,KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "                ,TORI_KBN " & vbCrLf
    '        sSQL += "             ) DTL " & vbCrLf



    '        'sSQL += "            ,( " & vbCrLf
    '        'sSQL += "             SELECT " & vbCrLf
    '        'sSQL += "                  KI " & vbCrLf
    '        'sSQL += "                 ,KEIYAKU_KBN " & vbCrLf
    '        'sSQL += "                 ,KEIYAKUSYA_CD " & vbCrLf
    '        'sSQL += "                 ,COUNT(DISTINCT NOJO_CD) OVER (PARTITION BY KEIYAKU_KBN,KEIYAKUSYA_CD) AS NOJO_CNT_SUM " & vbCrLf
    '        'sSQL += "             FROM TT_KEIYAKU_JOHO " & vbCrLf
    '        'sSQL += "             WHERE " & vbCrLf
    '        ''                          -- 条件
    '        'sSQL += "                  DATA_FLG = 1 " & vbCrLf
    '        ''                          -- 期条件
    '        'sSQL += "              AND KI = " & numKI.Value & vbCrLf

    '        'sSQL += "             ) TOSU_SUM " & vbCrLf
    '        'sSQL += "          WHERE DTL.KI = TOSU_SUM.KI(+) " & vbCrLf
    '        'sSQL += "            AND DTL.KEIYAKU_KBN = TOSU_SUM.KEIYAKU_KBN(+) " & vbCrLf
    '        'sSQL += "            AND DTL.KEIYAKUSYA_CD = TOSU_SUM.KEIYAKUSYA_CD(+) " & vbCrLf




    '        sSQL += "          GROUP BY " & vbCrLf
    '        sSQL += "              DTL.KI " & vbCrLf
    '        sSQL += "             ,DTL.KEN_CD " & vbCrLf
    '        sSQL += "             ,DTL.KEIYAKU_KBN " & vbCrLf
    '        sSQL += "             ,DTL.KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "          ORDER BY " & vbCrLf
    '        sSQL += "              KI " & vbCrLf
    '        sSQL += "             ,KEN_CD " & vbCrLf
    '        sSQL += "             ,KEIYAKU_KBN " & vbCrLf
    '        sSQL += "             ,KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "          ) " & vbCrLf
    '        sSQL += "       ORDER BY " & vbCrLf
    '        sSQL += "           KI " & vbCrLf
    '        sSQL += "          ,KEN_CD " & vbCrLf
    '        sSQL += "          ,KEIYAKU_KBN " & vbCrLf
    '        sSQL += "          ,KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "       ) " & vbCrLf
    '        sSQL += "    GROUP BY CUBE ( " & vbCrLf
    '        sSQL += "             KEN_CD " & vbCrLf
    '        sSQL += "            ,KEIYAKU_KBN " & vbCrLf
    '        sSQL += "            ,KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "             ) " & vbCrLf
    '        sSQL += "    ORDER BY " & vbCrLf
    '        sSQL += "        KI " & vbCrLf
    '        sSQL += "       ,KEN_CD " & vbCrLf
    '        sSQL += "       ,KEIYAKU_KBN " & vbCrLf
    '        sSQL += "       ,KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "    ) GRP " & vbCrLf
    '        sSQL += "    ,TM_KEIYAKU KEI " & vbCrLf
    '        sSQL += "    ,TM_CODE CD01 " & vbCrLf
    '        sSQL += "    ,TM_CODE CD05 " & vbCrLf
    '        sSQL += " WHERE " & vbCrLf
    '        If rdoKEIYAKU_KEI.Checked Then
    '            '        -- 0:明細,1:契約者別,3:都道府県別,5:契約区分別,7:総合計
    '            sSQL += "    GRPID IN (0,1,3,5,7) " & vbCrLf
    '        Else
    '            '        -- 1:契約者別,3:都道府県別,5:契約区分別,7:総合計
    '            sSQL += "    GRPID IN (1,3,5,7) " & vbCrLf
    '        End If
    '        '            -- 契約者マスタ
    '        sSQL += " AND GRP.KI = KEI.KI(+) " & vbCrLf
    '        sSQL += " AND GRP.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+) " & vbCrLf
    '        '            -- 契約区分
    '        sSQL += " AND 1 = CD01.SYURUI_KBN(+) " & vbCrLf
    '        sSQL += " AND GRP.KEIYAKU_KBN = CD01.MEISYO_CD(+) " & vbCrLf
    '        '            -- 都道府県
    '        sSQL += " AND 5 = CD05.SYURUI_KBN(+) " & vbCrLf
    '        sSQL += " AND GRP.KEN_CD = CD05.MEISYO_CD(+) " & vbCrLf
    '        sSQL += " ORDER BY " & vbCrLf
    '        sSQL += "     KI " & vbCrLf
    '        sSQL += "    ,KEN_CD " & vbCrLf
    '        sSQL += "    ,KEIYAKU_KBN " & vbCrLf
    '        sSQL += "    ,KEIYAKUSYA_CD " & vbCrLf

    '        'ＳＱＬ
    '        wSQL = sSQL

    '        ret = True

    '    Catch ex As Exception
    '        '共通例外処理
    '        Show_MessageBox("", ex.Message)
    '    End Try

    '    Return ret

    'End Function
#End Region
#Region "f_make_SQL_old EXCEデータ出力用ＳＱＬ作成(2015/06/02 JBD368  削除)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :EXCELデータ出力用ＳＱＬ作成
    '引数            :区分
    '引数            :SQLを返す
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    ' ''' <summary>
    ' ''' ＳＱＬ文作成
    ' ''' </summary>
    ' ''' <param name="iKbn">
    ' ''' 
    ' ''' </param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function f_make_SQL_old(ByVal iKbn As Integer, ByRef wSQL As String) As Boolean
    '    Dim ret As Boolean = False
    '    Dim sSQL As String = vbNullString
    '    Dim sSQL2 As String = vbNullString
    '    Dim sSQL3 As String = vbNullString

    '    Try
    '        '対象期・年度の取得
    '        Dim SyoriKI = New Obj_TM_SYORI_NENDO_KI()

    '        sSQL = " SELECT " & vbCrLf
    '        sSQL += "   TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI " & vbCrLf
    '        '-- 期
    '        If SyoriKI.pKI = numKI.Value Then
    '            sSQL += " ,'対象期：第" & numKI.Value & "期（' || TO_CHAR(TO_DATE('" & SyoriKI.pTAISYO_NENDO_byDate & "'), '""""EEYY""年度～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & SyoriKI.pJIGYO_SYURYO_NENDO_byDate & "'), '""""EEYY""年度）""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS TAISYO_KI " & vbCrLf
    '        Else
    '            sSQL += " ,'対象期：第" & numKI.Value & "期' AS TAISYO_KI " & vbCrLf
    '        End If

    '        '-- 契約締結日範囲
    '        sSQL += " ,'＜＜　家畜防疫互助基金事業加入状況表（' || TO_CHAR(TO_DATE('" & dateKEIYAKU_Ymd_Fm.Value & "'), 'EEYY""年""MM""月""DD""日～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & dateKEIYAKU_Ymd_To.Value & "'), 'EEYY""年""MM""月""DD""日）　＞＞""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ITAKU_NAME_HED " & vbCrLf

    '        '--  連番
    '        sSQL += " ,CASE " & vbCrLf
    '        sSQL += "    WHEN GRP.GRPID = 0 THEN TO_CHAR(GRP.ROW_NUM) " & vbCrLf
    '        sSQL += "    ELSE NULL " & vbCrLf
    '        sSQL += "  END ROW_NUM " & vbCrLf
    '        '-- 期
    '        sSQL += " ,GRP.KI AS KI " & vbCrLf

    '        '-- 都道府県
    '        sSQL += " ,GRP.KEN_CD AS KEN_CD " & vbCrLf
    '        sSQL += " ,CD05.MEISYO AS KEN_NM " & vbCrLf
    '        '-- 契約区分 
    '        sSQL += " ,GRP.KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
    '        sSQL += " ,CD01.RYAKUSYO AS KEIYAKU_KBN_NM " & vbCrLf
    '        '-- 契約者 
    '        sSQL += " ,GRP.KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += " ,CASE " & vbCrLf
    '        sSQL += "    WHEN GRP.GRPID = 1 THEN CD01.RYAKUSYO || '計' " & vbCrLf
    '        sSQL += "    WHEN GRP.GRPID = 3 THEN CD05.MEISYO || '計' " & vbCrLf
    '        sSQL += "    WHEN GRP.GRPID = 5 THEN CD05.MEISYO || '合計' " & vbCrLf
    '        sSQL += "    WHEN GRP.GRPID = 7 THEN CD05.MEISYO || '総合計' " & vbCrLf
    '        sSQL += "    ELSE KEI.KEIYAKUSYA_NAME " & vbCrLf
    '        sSQL += "  END KEIYAKUSYA_NAME " & vbCrLf
    '        sSQL += " ,KEI.ADDR_1 || KEI.ADDR_2 || KEI.ADDR_3 || KEI.ADDR_4 AS ADDR " & vbCrLf

    '        sSQL += " ,GRP.GRPID AS GRPID " & vbCrLf

    '        '-- 採卵鶏 成鶏 
    '        sSQL += " ,GRP.TOSU1 AS TOSU1 " & vbCrLf
    '        sSQL += " ,GRP.KEIYAKU_HASU1 AS KEIYAKU_HASU1 " & vbCrLf
    '        sSQL += " ,GRP.TUMITATE_KIN1 AS TUMITATE_KIN1 " & vbCrLf

    '        '-- 採卵鶏 育成
    '        sSQL += " ,GRP.TOSU2 AS TOSU2 " & vbCrLf
    '        sSQL += " ,GRP.KEIYAKU_HASU2 AS KEIYAKU_HASU2 " & vbCrLf
    '        sSQL += " ,GRP.TUMITATE_KIN2 AS TUMITATE_KIN2 " & vbCrLf

    '        '-- 肉用鶏
    '        sSQL += " ,GRP.TOSU3 AS TOSU3 " & vbCrLf
    '        sSQL += " ,GRP.KEIYAKU_HASU3 AS KEIYAKU_HASU3 " & vbCrLf
    '        sSQL += " ,GRP.TUMITATE_KIN3 AS TUMITATE_KIN3 " & vbCrLf

    '        '-- 種鶏 成鶏
    '        sSQL += " ,GRP.TOSU4 AS TOSU4 " & vbCrLf
    '        sSQL += " ,GRP.KEIYAKU_HASU4 AS KEIYAKU_HASU4 " & vbCrLf
    '        sSQL += " ,GRP.TUMITATE_KIN4 AS TUMITATE_KIN4 " & vbCrLf

    '        '-- 種鶏 育成
    '        sSQL += " ,GRP.TOSU5 AS TOSU5 " & vbCrLf
    '        sSQL += " ,GRP.KEIYAKU_HASU5 AS KEIYAKU_HASU5 " & vbCrLf
    '        sSQL += " ,GRP.TUMITATE_KIN5 AS TUMITATE_KIN5 " & vbCrLf

    '        '-- うずら
    '        sSQL += " ,GRP.TOSU6 AS TOSU6 " & vbCrLf
    '        sSQL += " ,GRP.KEIYAKU_HASU6 AS KEIYAKU_HASU6 " & vbCrLf
    '        sSQL += " ,GRP.TUMITATE_KIN6 AS TUMITATE_KIN6 " & vbCrLf

    '        '-- 合計(横計)
    '        sSQL += " ,GRP.TOSU_SUM AS TOSU_SUM " & vbCrLf
    '        sSQL += " ,GRP.HASU_SUM AS HASU_SUM " & vbCrLf
    '        sSQL += " ,GRP.TUMITATE_SUM AS TUMITATE_SUM " & vbCrLf

    '        sSQL += " FROM " & vbCrLf
    '        '-- 契約区分別、都道府県別の集計
    '        sSQL += "    (" & vbCrLf
    '        sSQL += "    SELECT " & vbCrLf
    '        sSQL += "         MAX(ROWNUM) AS ROW_NUM " & vbCrLf
    '        sSQL += "        ,MAX(KI) AS KI " & vbCrLf
    '        sSQL += "        ,KEN_CD  AS KEN_CD " & vbCrLf
    '        sSQL += "        ,KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
    '        sSQL += "        ,KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "        ,GROUPING_ID(KEN_CD, KEIYAKU_KBN, KEIYAKUSYA_CD) AS GRPID " & vbCrLf
    '        '                 -- 採卵鶏 成鶏
    '        sSQL += "        ,SUM(TOSU1) AS TOSU1 " & vbCrLf
    '        sSQL += "        ,SUM(KEIYAKU_HASU1) AS KEIYAKU_HASU1 " & vbCrLf
    '        sSQL += "        ,SUM(TUMITATE_KIN1) AS TUMITATE_KIN1 " & vbCrLf
    '        '                 -- 採卵鶏 育成
    '        sSQL += "        ,SUM(TOSU2) AS TOSU2 " & vbCrLf
    '        sSQL += "        ,SUM(KEIYAKU_HASU2) AS KEIYAKU_HASU2 " & vbCrLf
    '        sSQL += "        ,SUM(TUMITATE_KIN2) AS TUMITATE_KIN2 " & vbCrLf
    '        '                 -- 肉用鶏
    '        sSQL += "        ,SUM(TOSU3) AS TOSU3 " & vbCrLf
    '        sSQL += "        ,SUM(KEIYAKU_HASU3) AS KEIYAKU_HASU3 " & vbCrLf
    '        sSQL += "        ,SUM(TUMITATE_KIN3) AS TUMITATE_KIN3 " & vbCrLf
    '        '                 -- 種鶏 成鶏
    '        sSQL += "        ,SUM(TOSU4) AS TOSU4 " & vbCrLf
    '        sSQL += "        ,SUM(KEIYAKU_HASU4) AS KEIYAKU_HASU4 " & vbCrLf
    '        sSQL += "        ,SUM(TUMITATE_KIN4) AS TUMITATE_KIN4 " & vbCrLf
    '        '                 -- 種鶏 育成
    '        sSQL += "        ,SUM(TOSU5) AS TOSU5 " & vbCrLf
    '        sSQL += "        ,SUM(KEIYAKU_HASU5) AS KEIYAKU_HASU5 " & vbCrLf
    '        sSQL += "        ,SUM(TUMITATE_KIN5) AS TUMITATE_KIN5 " & vbCrLf
    '        '                 -- うずら
    '        sSQL += "        ,SUM(TOSU6) AS TOSU6 " & vbCrLf
    '        sSQL += "        ,SUM(KEIYAKU_HASU6) AS KEIYAKU_HASU6 " & vbCrLf
    '        sSQL += "        ,SUM(TUMITATE_KIN6) AS TUMITATE_KIN6 " & vbCrLf
    '        '                 -- 合計(横計)
    '        sSQL += "        ,SUM(TOSU_SUM) AS TOSU_SUM " & vbCrLf
    '        sSQL += "        ,SUM(HASU_SUM) AS HASU_SUM " & vbCrLf
    '        sSQL += "        ,SUM(TUMITATE_SUM) AS TUMITATE_SUM " & vbCrLf
    '        sSQL += "    FROM " & vbCrLf
    '        sSQL += "       ( " & vbCrLf
    '        sSQL += "       SELECT " & vbCrLf
    '        sSQL += "            KI " & vbCrLf
    '        sSQL += "           ,ROWNUM " & vbCrLf
    '        sSQL += "           ,KEN_CD " & vbCrLf
    '        sSQL += "           ,KEIYAKU_KBN " & vbCrLf
    '        sSQL += "           ,KEIYAKUSYA_CD " & vbCrLf
    '        '                    -- 採卵鶏 成鶏
    '        sSQL += "           ,TOSU1 " & vbCrLf
    '        sSQL += "           ,KEIYAKU_HASU1 " & vbCrLf
    '        sSQL += "           ,TUMITATE_KIN1 " & vbCrLf
    '        '                    -- 採卵鶏 育成
    '        sSQL += "           ,TOSU2 " & vbCrLf
    '        sSQL += "           ,KEIYAKU_HASU2 " & vbCrLf
    '        sSQL += "           ,TUMITATE_KIN2 " & vbCrLf
    '        '                    -- 肉用鶏
    '        sSQL += "           ,TOSU3 " & vbCrLf
    '        sSQL += "           ,KEIYAKU_HASU3 " & vbCrLf
    '        sSQL += "           ,TUMITATE_KIN3 " & vbCrLf
    '        '                    -- 種鶏 成鶏
    '        sSQL += "           ,TOSU4 " & vbCrLf
    '        sSQL += "           ,KEIYAKU_HASU4 " & vbCrLf
    '        sSQL += "           ,TUMITATE_KIN4 " & vbCrLf
    '        '                    -- 種鶏 育成
    '        sSQL += "           ,TOSU5 " & vbCrLf
    '        sSQL += "           ,KEIYAKU_HASU5 " & vbCrLf
    '        sSQL += "           ,TUMITATE_KIN5 " & vbCrLf
    '        '                    -- うずら
    '        sSQL += "           ,TOSU6 " & vbCrLf
    '        sSQL += "           ,KEIYAKU_HASU6 " & vbCrLf
    '        sSQL += "           ,TUMITATE_KIN6 " & vbCrLf
    '        '                    -- 合計(横計)
    '        'sSQL += "           ,NVL(TOSU_SUM,0) AS TOSU_SUM " & vbCrLf
    '        sSQL += "           ,NVL(TOSU1,0) + NVL(TOSU2,0) + NVL(TOSU3,0) + NVL(TOSU4,0) + NVL(TOSU5,0) + NVL(TOSU6,0) AS TOSU_SUM " & vbCrLf
    '        sSQL += "           ,NVL(KEIYAKU_HASU1,0) + NVL(KEIYAKU_HASU2,0) + NVL(KEIYAKU_HASU3,0) + NVL(KEIYAKU_HASU4,0) + NVL(KEIYAKU_HASU5,0) + NVL(KEIYAKU_HASU6,0) AS HASU_SUM " & vbCrLf
    '        sSQL += "           ,NVL(TUMITATE_KIN1,0) + NVL(TUMITATE_KIN2,0) + NVL(TUMITATE_KIN3,0) + NVL(TUMITATE_KIN4,0) + NVL(TUMITATE_KIN5,0) + NVL(TUMITATE_KIN6,0) AS TUMITATE_SUM " & vbCrLf
    '        sSQL += "       FROM " & vbCrLf
    '        sSQL += "          ( " & vbCrLf
    '        sSQL += "          SELECT " & vbCrLf
    '        sSQL += "               DTL.KI " & vbCrLf
    '        sSQL += "              ,DTL.KEN_CD " & vbCrLf
    '        sSQL += "              ,DTL.KEIYAKU_KBN " & vbCrLf
    '        sSQL += "              ,DTL.KEIYAKUSYA_CD " & vbCrLf
    '        '                       -- 採卵鶏 成鶏
    '        sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 1 THEN NVL(DTL.NOJO_CNT,0) END) AS TOSU1 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 1 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU1 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 1 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN1 " & vbCrLf
    '        '                       -- 採卵鶏 育成
    '        sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 2 THEN NVL(DTL.NOJO_CNT,0) END) AS TOSU2 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 2 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU2 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 2 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN2 " & vbCrLf
    '        '                       -- 肉用鶏
    '        sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 3 THEN NVL(DTL.NOJO_CNT,0) END) AS TOSU3 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 3 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU3 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 3 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN3 " & vbCrLf
    '        '                       -- 種鶏 成鶏
    '        sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 4 THEN NVL(DTL.NOJO_CNT,0) END) AS TOSU4 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 4 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU4 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 4 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN4 " & vbCrLf
    '        '                       -- 種鶏 育成
    '        sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 5 THEN NVL(DTL.NOJO_CNT,0) END) AS TOSU5 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 5 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU5 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 5 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN5 " & vbCrLf
    '        '                       -- うずら
    '        sSQL += "              ,MAX(CASE WHEN DTL.TORI_KBN = 6 THEN NVL(DTL.NOJO_CNT,0) END) AS TOSU6 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 6 THEN NVL(DTL.KEIYAKU_HASU,0) END) AS KEIYAKU_HASU6 " & vbCrLf
    '        sSQL += "              ,SUM(CASE WHEN DTL.TORI_KBN = 6 THEN NVL(DTL.TUMITATE_KIN,0) END) AS TUMITATE_KIN6 " & vbCrLf
    '        '                       -- 合計 戸数(正味)
    '        'sSQL += "              ,MAX(TOSU_SUM.NOJO_CNT_SUM) AS TOSU_SUM " & vbCrLf

    '        sSQL += "          FROM " & vbCrLf
    '        sSQL += "             ( " & vbCrLf
    '        sSQL += "             SELECT " & vbCrLf
    '        '                          -- 期
    '        sSQL += "                  KEIJOHO.KI AS KI " & vbCrLf
    '        '                          -- 都道府県
    '        sSQL += "                 ,KEI.KEN_CD AS KEN_CD " & vbCrLf
    '        '                          -- 契約者
    '        sSQL += "                 ,KEIJOHO.KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
    '        '                          -- 契約区分
    '        sSQL += "                 ,KEIJOHO.KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
    '        '                          -- 鶏区分
    '        sSQL += "                 ,KEIJOHO.TORI_KBN AS TORI_KBN " & vbCrLf
    '        '                          -- 農場件数
    '        sSQL += "                 ,COUNT(KEIJOHO.NOJO_CD) AS NOJO_CNT " & vbCrLf
    '        '                          -- 羽数合計
    '        sSQL += "                 ,SUM(KEIJOHO.KEIYAKU_HASU) AS KEIYAKU_HASU " & vbCrLf
    '        '                          -- 単価
    '        sSQL += "                 ,TAN.TUMITATE_TANKA AS TUMITATE_TANKA " & vbCrLf
    '        '                          -- 生産者積立金
    '        sSQL += "                 ,CASE " & vbCrLf
    '        sSQL += "                    WHEN KEIJOHO.TORI_KBN = 6 THEN CEIL((SUM(KEIJOHO.KEIYAKU_HASU) / 5) * TAN.TUMITATE_TANKA) " & vbCrLf
    '        sSQL += "                    ELSE CEIL(SUM(KEIJOHO.KEIYAKU_HASU) * TAN.TUMITATE_TANKA) " & vbCrLf
    '        sSQL += "                  END TUMITATE_KIN " & vbCrLf
    '        '                          -- 手数料
    '        sSQL += "                 ,TES.TESURYO_RITU AS TESURYO_RITU " & vbCrLf
    '        sSQL += "             FROM TT_KEIYAKU_JOHO KEIJOHO " & vbCrLf
    '        sSQL += "                 ,TM_KEIYAKU KEI " & vbCrLf
    '        sSQL += "                 ,TM_TANKA TAN " & vbCrLf
    '        sSQL += "                 ,TM_TANKA TES " & vbCrLf
    '        sSQL += "             WHERE " & vbCrLf
    '        '                          -- 契約者マスタ
    '        sSQL += "                  KEIJOHO.KI = KEI.KI(+) " & vbCrLf
    '        sSQL += "              AND KEIJOHO.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+) " & vbCrLf
    '        '                          -- 単価マスタ
    '        sSQL += "              AND KEIJOHO.KEIYAKU_KBN = TAN.KEIYAKU_KBN(+) " & vbCrLf
    '        sSQL += "              AND KEIJOHO.TORI_KBN = TAN.TORI_KBN(+) " & vbCrLf
    '        sSQL += "              AND KEIJOHO.KEIYAKU_DATE_FROM BETWEEN TAN.TAISYO_DATE_FROM AND TAN.TAISYO_DATE_TO " & vbCrLf
    '        '                          -- 手数料
    '        sSQL += "              AND 9 = TES.KEIYAKU_KBN " & vbCrLf
    '        sSQL += "              AND 9 = TES.TORI_KBN " & vbCrLf
    '        sSQL += "              AND KEI.KEIYAKU_DATE BETWEEN TES.TAISYO_DATE_FROM AND TES.TAISYO_DATE_TO " & vbCrLf
    '        '                          -- 条件
    '        sSQL += "              AND KEIJOHO.DATA_FLG = 1 " & vbCrLf
    '        '                          -- 期条件
    '        sSQL += "              AND KEIJOHO.KI = " & numKI.Value & vbCrLf

    '        ''==必須条件=======================
    '        '契約締結日範囲FROMTO
    '        If dateKEIYAKU_Ymd_Fm.Text <> "" Then
    '            sSQL += "              AND KEI.KEIYAKU_DATE BETWEEN TO_DATE('" & Format(dateKEIYAKU_Ymd_Fm.Value, "yyyy/MM/dd") & "') AND TO_DATE('" & Format(dateKEIYAKU_Ymd_To.Value, "yyyy/MM/dd") & "') " & vbCrLf
    '        End If

    '        '==任意条件=======================
    '        '契約区分FROMTO
    '        If cboKEIYAKU_KBN_Cd_Fm.Text <> "" Then
    '            sSQL += "              AND KEI.KEIYAKU_KBN BETWEEN " & cboKEIYAKU_KBN_Cd_Fm.Text & " AND " & cboKEIYAKU_KBN_Cd_To.Text & vbCrLf
    '        End If

    '        '都道府県FROMTO
    '        If cboKEN_Cd_Fm.Text <> "" Then
    '            sSQL += "              AND KEI.KEN_CD BETWEEN " & cboKEN_Cd_Fm.Text & " AND " & cboKEN_Cd_Fm.Text & vbCrLf
    '        End If

    '        '契約者FROMTO
    '        If cboKEIYAKUSYA_Cd_Fm.Text <> "" Then
    '            sSQL += "              AND KEI.KEIYAKUSYA_CD BETWEEN " & cboKEIYAKUSYA_Cd_Fm.Text & " AND " & cboKEIYAKUSYA_Cd_To.Text & vbCrLf
    '        End If


    '        sSQL += "             GROUP BY " & vbCrLf
    '        sSQL += "                 KEIJOHO.KI " & vbCrLf
    '        sSQL += "                ,KEI.KEN_CD " & vbCrLf
    '        sSQL += "                ,KEIJOHO.KEIYAKU_KBN " & vbCrLf
    '        sSQL += "                ,KEIJOHO.KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "                ,KEIJOHO.TORI_KBN " & vbCrLf
    '        sSQL += "                ,TAN.TUMITATE_TANKA " & vbCrLf
    '        sSQL += "                ,TES.TESURYO_RITU " & vbCrLf
    '        sSQL += "             ORDER BY " & vbCrLf
    '        sSQL += "                 KI " & vbCrLf
    '        sSQL += "                ,KEN_CD " & vbCrLf
    '        sSQL += "                ,KEIYAKU_KBN " & vbCrLf
    '        sSQL += "                ,KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "                ,TORI_KBN " & vbCrLf
    '        sSQL += "             ) DTL " & vbCrLf



    '        'sSQL += "            ,( " & vbCrLf
    '        'sSQL += "             SELECT " & vbCrLf
    '        'sSQL += "                  KI " & vbCrLf
    '        'sSQL += "                 ,KEIYAKU_KBN " & vbCrLf
    '        'sSQL += "                 ,KEIYAKUSYA_CD " & vbCrLf
    '        'sSQL += "                 ,COUNT(DISTINCT NOJO_CD) OVER (PARTITION BY KEIYAKU_KBN,KEIYAKUSYA_CD) AS NOJO_CNT_SUM " & vbCrLf
    '        'sSQL += "             FROM TT_KEIYAKU_JOHO " & vbCrLf
    '        'sSQL += "             WHERE " & vbCrLf
    '        ''                          -- 条件
    '        'sSQL += "                  DATA_FLG = 1 " & vbCrLf
    '        ''                          -- 期条件
    '        'sSQL += "              AND KI = " & numKI.Value & vbCrLf

    '        'sSQL += "             ) TOSU_SUM " & vbCrLf
    '        'sSQL += "          WHERE DTL.KI = TOSU_SUM.KI(+) " & vbCrLf
    '        'sSQL += "            AND DTL.KEIYAKU_KBN = TOSU_SUM.KEIYAKU_KBN(+) " & vbCrLf
    '        'sSQL += "            AND DTL.KEIYAKUSYA_CD = TOSU_SUM.KEIYAKUSYA_CD(+) " & vbCrLf




    '        sSQL += "          GROUP BY " & vbCrLf
    '        sSQL += "              DTL.KI " & vbCrLf
    '        sSQL += "             ,DTL.KEN_CD " & vbCrLf
    '        sSQL += "             ,DTL.KEIYAKU_KBN " & vbCrLf
    '        sSQL += "             ,DTL.KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "          ORDER BY " & vbCrLf
    '        sSQL += "              KI " & vbCrLf
    '        sSQL += "             ,KEN_CD " & vbCrLf
    '        sSQL += "             ,KEIYAKU_KBN " & vbCrLf
    '        sSQL += "             ,KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "          ) " & vbCrLf
    '        sSQL += "       ORDER BY " & vbCrLf
    '        sSQL += "           KI " & vbCrLf
    '        sSQL += "          ,KEN_CD " & vbCrLf
    '        sSQL += "          ,KEIYAKU_KBN " & vbCrLf
    '        sSQL += "          ,KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "       ) " & vbCrLf
    '        sSQL += "    GROUP BY CUBE ( " & vbCrLf
    '        sSQL += "             KEN_CD " & vbCrLf
    '        sSQL += "            ,KEIYAKU_KBN " & vbCrLf
    '        sSQL += "            ,KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "             ) " & vbCrLf
    '        sSQL += "    ORDER BY " & vbCrLf
    '        sSQL += "        KI " & vbCrLf
    '        sSQL += "       ,KEN_CD " & vbCrLf
    '        sSQL += "       ,KEIYAKU_KBN " & vbCrLf
    '        sSQL += "       ,KEIYAKUSYA_CD " & vbCrLf
    '        sSQL += "    ) GRP " & vbCrLf
    '        sSQL += "    ,TM_KEIYAKU KEI " & vbCrLf
    '        sSQL += "    ,TM_CODE CD01 " & vbCrLf
    '        sSQL += "    ,TM_CODE CD05 " & vbCrLf
    '        sSQL += " WHERE " & vbCrLf
    '        If rdoKEIYAKU_KEI.Checked Then
    '            '        -- 0:明細,1:契約者別,3:都道府県別,5:契約区分別,7:総合計
    '            sSQL += "    GRPID IN (0,1,3,5,7) " & vbCrLf
    '        Else
    '            '        -- 1:契約者別,3:都道府県別,5:契約区分別,7:総合計
    '            sSQL += "    GRPID IN (1,3,5,7) " & vbCrLf
    '        End If
    '        '            -- 契約者マスタ
    '        sSQL += " AND GRP.KI = KEI.KI(+) " & vbCrLf
    '        sSQL += " AND GRP.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+) " & vbCrLf
    '        '            -- 契約区分
    '        sSQL += " AND 1 = CD01.SYURUI_KBN(+) " & vbCrLf
    '        sSQL += " AND GRP.KEIYAKU_KBN = CD01.MEISYO_CD(+) " & vbCrLf
    '        '            -- 都道府県
    '        sSQL += " AND 5 = CD05.SYURUI_KBN(+) " & vbCrLf
    '        sSQL += " AND GRP.KEN_CD = CD05.MEISYO_CD(+) " & vbCrLf
    '        sSQL += " ORDER BY " & vbCrLf
    '        sSQL += "     KI " & vbCrLf
    '        sSQL += "    ,KEN_CD " & vbCrLf
    '        sSQL += "    ,KEIYAKU_KBN " & vbCrLf
    '        sSQL += "    ,KEIYAKUSYA_CD " & vbCrLf

    '        'ＳＱＬ
    '        wSQL = sSQL

    '        ret = True

    '    Catch ex As Exception
    '        '共通例外処理
    '        Show_MessageBox("", ex.Message)
    '    End Try

    '    Return ret

    'End Function
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
        Dim filNm As String = "家畜防疫互助基金事業状況表_"
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
                filNm = "家畜防疫互助基金事業状況表(追加納付)_"
            End If
            '↑2017/07/14 追加 追加納付を追加
            'ファイル出力パス
            If f_FileDialog("xlsx", filNm) = False Then
                Exit Try
            End If
            If filNm = "" Then
                Exit Try
            End If

            'テンプレートファイルの保存
            If xl.SetExcelFile_xlsx("家畜防疫互助基金事業状況表.xlsx", filNm) = False Then
                '家畜防疫互助基金事業状況表
                Exit Try
            End If

            Me.Cursor = Cursors.WaitCursor



            'テンプレートファイルのOPEN保存
            If xl.XlOpen_xlsx(filNm, "Sheet1") = False Then
                Exit Try
            End If


            'データ作成
            xl.SetdataCell(1, 1, wkDT.Rows(0)("ITAKU_NAME_HED"))

            PrgBar.Visible = True
            PrgBar.Minimum = 0
            PrgBar.Maximum = wkDT.Rows.Count
            PrgBar.Minimum = 0

            Dim rowMaxRow As Integer
            Dim rowWkCnt As Integer
            Dim rowPos As Integer
            Dim rowCnt As Integer

            rowPos = 5      '開始位置 #78対応
            rowCnt = 1
            rowMaxRow = 500  '最大配列件数
            'rowMaxRow = wkDT.Rows.Count  '最大配列件数
            rowWkCnt = 0
            xl.SetRangeCopy(rowPos & ":" & rowPos, wkDT.Rows.Count - 1)      '行コピー

            '↓2017/07/12 修正 鳥区分追加
            'Dim data(rowMaxRow, 26) As Object
            '2021/07/14 JBD9020 新契約日追加 UPD START
            'Dim data(rowMaxRow, 41) As Object
            Dim data(rowMaxRow, 43) As Object
            '2021/07/14 JBD9020 新契約日追加 UPD END
            '↑2017/07/12 修正 鳥区分追加
            For Each wkRow As DataRow In wkDT.Rows

                PrgBar.Value = rowCnt


                '項目
                'xl.SetdataCell(rowPos, 1, WordHenkan("N", "S", wkRow("ROW_NUM")))               '連番号
                'xl.SetdataCell(rowPos, 2, WordHenkan("N", "S", wkRow("KEIYAKUSYA_CD")))         '契約者番号
                'xl.SetdataCell(rowPos, 3, WordHenkan("N", "S", wkRow("KEIYAKU_KBN_NM")))        '契約区分名
                'xl.SetdataCell(rowPos, 4, WordHenkan("N", "S", wkRow("KEIYAKUSYA_NAME")))       '契約者名
                'xl.SetdataCell(rowPos, 5, WordHenkan("N", "S", wkRow("ADDR")))                  '契約者住所

                'xl.SetdataCell(rowPos, 6, WordHenkan("N", "Z", wkRow("TOSU1")))                 '戸数-採卵鶏成鶏
                'xl.SetdataCell(rowPos, 7, WordHenkan("N", "Z", wkRow("KEIYAKU_HASU1")))         '羽数-採卵鶏成鶏
                'xl.SetdataCell(rowPos, 8, WordHenkan("N", "Z", wkRow("TUMITATE_KIN1")))         '金額-採卵鶏成鶏

                'xl.SetdataCell(rowPos, 9, WordHenkan("N", "Z", wkRow("TOSU2")))                 '戸数-採卵鶏育成
                'xl.SetdataCell(rowPos, 10, WordHenkan("N", "Z", wkRow("KEIYAKU_HASU2")))        '羽数-採卵鶏育成
                'xl.SetdataCell(rowPos, 11, WordHenkan("N", "Z", wkRow("TUMITATE_KIN2")))        '金額-採卵鶏育成

                'xl.SetdataCell(rowPos, 12, WordHenkan("N", "Z", wkRow("TOSU3")))                '戸数-肉用種
                'xl.SetdataCell(rowPos, 13, WordHenkan("N", "Z", wkRow("KEIYAKU_HASU3")))        '羽数-肉用種
                'xl.SetdataCell(rowPos, 14, WordHenkan("N", "Z", wkRow("TUMITATE_KIN3")))        '金額-肉用種

                'xl.SetdataCell(rowPos, 15, WordHenkan("N", "Z", wkRow("TOSU4")))                '戸数-種鶏成鶏
                'xl.SetdataCell(rowPos, 16, WordHenkan("N", "Z", wkRow("KEIYAKU_HASU4")))        '羽数-種鶏成鶏
                'xl.SetdataCell(rowPos, 17, WordHenkan("N", "Z", wkRow("TUMITATE_KIN4")))        '金額-種鶏成鶏

                'xl.SetdataCell(rowPos, 18, WordHenkan("N", "Z", wkRow("TOSU5")))                '戸数-種鶏育成
                'xl.SetdataCell(rowPos, 19, WordHenkan("N", "Z", wkRow("KEIYAKU_HASU5")))        '羽数-種鶏育成
                'xl.SetdataCell(rowPos, 20, WordHenkan("N", "Z", wkRow("TUMITATE_KIN5")))        '金額-種鶏育成

                'xl.SetdataCell(rowPos, 21, WordHenkan("N", "Z", wkRow("TOSU6")))                '戸数-うずら
                'xl.SetdataCell(rowPos, 22, WordHenkan("N", "Z", wkRow("KEIYAKU_HASU6")))        '羽数-うずら
                'xl.SetdataCell(rowPos, 23, WordHenkan("N", "Z", wkRow("TUMITATE_KIN6")))        '金額-うずら

                'xl.SetdataCell(rowPos, 24, WordHenkan("N", "Z", wkRow("TOSU_SUM")))             '戸数-合計
                'xl.SetdataCell(rowPos, 25, WordHenkan("N", "Z", wkRow("HASU_SUM")))             '羽数-合計
                'xl.SetdataCell(rowPos, 26, WordHenkan("N", "Z", wkRow("TUMITATE_SUM")))         '金額-合計

                '2021/07/12 JBD9020 新契約日追加 UPD START
                'data(rowWkCnt, 0) = WordHenkan("N", "S", wkRow("ROW_NUM"))                             '連番号
                'data(rowWkCnt, 1) = WordHenkan("N", "S", wkRow("KEIYAKUSYA_CD"))                       '契約者番号
                'data(rowWkCnt, 2) = WordHenkan("N", "S", wkRow("KEIYAKU_KBN_NM"))                      '契約区分名
                'data(rowWkCnt, 3) = WordHenkan("N", "S", wkRow("KEIYAKUSYA_NAME"))                     '契約者名
                'data(rowWkCnt, 4) = WordHenkan("N", "S", wkRow("ADDR"))                                '契約者住所

                ''2015/06/02 JBD368 UPD 明細の戸数は空白を出力
                ''data(rowWkCnt, 5) = WordHenkan("N", "Z", wkRow("TOSU1"))
                'If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                '    data(rowWkCnt, 5) = ""
                'Else
                '    data(rowWkCnt, 5) = WordHenkan("N", "Z", wkRow("TOSU1"))                           '戸数-採卵鶏成鶏
                'End If
                ''↑2015/06/02 JBD368 UPD

                'data(rowWkCnt, 6) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU1"))                       '羽数-採卵鶏成鶏
                'data(rowWkCnt, 7) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN1"))                       '金額-採卵鶏成鶏

                ''2015/06/02 JBD368 UPD 明細の戸数は空白を出力
                ''data(rowWkCnt, 8) = WordHenkan("N", "Z", wkRow("TOSU2"))
                'If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                '    data(rowWkCnt, 8) = ""
                'Else
                '    data(rowWkCnt, 8) = WordHenkan("N", "Z", wkRow("TOSU2"))                           '戸数-採卵鶏育成
                'End If
                ''↑2015/06/02 JBD368 UPD
                'data(rowWkCnt, 9) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU2"))                       '羽数-採卵鶏育成
                'data(rowWkCnt, 10) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN2"))                      '金額-採卵鶏育成

                ''2015/06/02 JBD368 UPD 明細の戸数は空白を出力
                ''data(rowWkCnt, 11) = WordHenkan("N", "Z", wkRow("TOSU3"))
                'If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                '    data(rowWkCnt, 11) = ""
                'Else
                '    data(rowWkCnt, 11) = WordHenkan("N", "Z", wkRow("TOSU3"))                          '戸数-肉用種
                'End If
                ''↑2015/06/02 JBD368 UPD
                'data(rowWkCnt, 12) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU3"))                      '羽数-肉用種
                'data(rowWkCnt, 13) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN3"))                      '金額-肉用種

                ''2015/06/02 JBD368 UPD 明細の戸数は空白を出力
                ''data(rowWkCnt, 14) = WordHenkan("N", "Z", wkRow("TOSU4"))
                'If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                '    data(rowWkCnt, 14) = ""
                'Else
                '    data(rowWkCnt, 14) = WordHenkan("N", "Z", wkRow("TOSU4"))                          '戸数-種鶏成鶏
                'End If
                ''↑2015/06/02 JBD368 UPD
                'data(rowWkCnt, 15) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU4"))                      '羽数-種鶏成鶏
                'data(rowWkCnt, 16) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN4"))                      '金額-種鶏成鶏

                ''2015/06/02 JBD368 UPD 明細の戸数は空白を出力
                ''data(rowWkCnt, 17) = WordHenkan("N", "Z", wkRow("TOSU5"))
                'If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                '    data(rowWkCnt, 17) = ""
                'Else
                '    data(rowWkCnt, 17) = WordHenkan("N", "Z", wkRow("TOSU5"))                          '戸数-種鶏育成
                'End If
                ''↑2015/06/02 JBD368 UPD
                'data(rowWkCnt, 18) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU5"))                      '羽数-種鶏育成
                'data(rowWkCnt, 19) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN5"))                      '金額-種鶏育成

                ''2015/06/02 JBD368 UPD 明細の戸数は空白を出力
                ''data(rowWkCnt, 20) = WordHenkan("N", "Z", wkRow("TOSU6"))
                'If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                '    data(rowWkCnt, 20) = ""
                'Else
                '    data(rowWkCnt, 20) = WordHenkan("N", "Z", wkRow("TOSU6"))                          '戸数-うずら
                'End If
                ''↑2015/06/02 JBD368 UPD
                'data(rowWkCnt, 21) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU6"))                      '羽数-うずら
                'data(rowWkCnt, 22) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN6"))                      '金額-うずら

                ''↓2017/07/12 追加 鳥区分追加
                'If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                '    data(rowWkCnt, 23) = ""
                'Else
                '    data(rowWkCnt, 23) = WordHenkan("N", "Z", wkRow("TOSU7"))                          '戸数-あひる
                'End If
                'data(rowWkCnt, 24) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU7"))                      '羽数-あひる
                'data(rowWkCnt, 25) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN7"))                      '金額-あひる

                'If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                '    data(rowWkCnt, 26) = ""
                'Else
                '    data(rowWkCnt, 26) = WordHenkan("N", "Z", wkRow("TOSU8"))                          '戸数-きじ
                'End If
                'data(rowWkCnt, 27) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU8"))                      '羽数-きじ
                'data(rowWkCnt, 28) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN8"))                      '金額-きじ

                'If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                '    data(rowWkCnt, 29) = ""
                'Else
                '    data(rowWkCnt, 29) = WordHenkan("N", "Z", wkRow("TOSU9"))                          '戸数-ほろほろ鳥
                'End If
                'data(rowWkCnt, 30) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU9"))                      '羽数-ほろほろ鳥
                'data(rowWkCnt, 31) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN9"))                      '金額-ほろほろ鳥

                'If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                '    data(rowWkCnt, 32) = ""
                'Else
                '    data(rowWkCnt, 32) = WordHenkan("N", "Z", wkRow("TOSU10"))                          '戸数-七面鳥
                'End If
                'data(rowWkCnt, 33) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU10"))                      '羽数-七面鳥
                'data(rowWkCnt, 34) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN10"))                      '金額-七面鳥

                'If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                '    data(rowWkCnt, 35) = ""
                'Else
                '    data(rowWkCnt, 35) = WordHenkan("N", "Z", wkRow("TOSU11"))                          '戸数-だちょう
                'End If
                'data(rowWkCnt, 36) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU11"))                      '羽数-だちょう
                'data(rowWkCnt, 37) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN11"))                      '金額-だちょう
                ''↑2017/07/12 追加 鳥区分追加

                ''↓2017/07/12 修正 鳥区分追加
                ''2015/06/02 JBD368 UPD 明細の戸数は空白を出力
                ''data(rowWkCnt, 23) = WordHenkan("N", "Z", wkRow("TOSU_SUM"))
                ''If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                ''    data(rowWkCnt, 23) = ""
                ''Else
                ''    data(rowWkCnt, 23) = WordHenkan("N", "Z", wkRow("TOSU_SUM"))                       '戸数-合計
                ''End If
                ''↑2015/06/02 JBD368 UPD
                ''data(rowWkCnt, 24) = WordHenkan("N", "Z", wkRow("HASU_SUM"))                           '羽数-合計
                ''data(rowWkCnt, 25) = WordHenkan("N", "Z", wkRow("TUMITATE_SUM"))                       '金額-合計
                '''配列数の判定
                ''If rowWkCnt >= rowMaxRow Then
                ''    '配列セット
                ''    xl.SetRangeValue(rowPos - rowMaxRow, rowPos, 26, data)
                ''    rowWkCnt = 0
                ''ElseIf rowCnt >= wkDT.Rows.Count Then
                ''    '配列セット
                ''    xl.SetRangeValue(rowPos - rowWkCnt, rowPos, 26, data)
                ''Else
                ''    rowWkCnt = rowWkCnt + 1
                ''End If
                'If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                '    data(rowWkCnt, 38) = ""
                'Else
                '    data(rowWkCnt, 38) = WordHenkan("N", "Z", wkRow("TOSU_SUM"))                       '戸数-合計
                'End If
                'data(rowWkCnt, 39) = WordHenkan("N", "Z", wkRow("HASU_SUM"))                           '羽数-合計
                'data(rowWkCnt, 40) = WordHenkan("N", "Z", wkRow("TUMITATE_SUM"))                       '金額-合計
                ''配列数の判定
                'If rowWkCnt >= rowMaxRow Then
                '    '配列セット
                '    xl.SetRangeValue(rowPos - rowMaxRow, rowPos, 41, data)
                '    rowWkCnt = 0
                'ElseIf rowCnt >= wkDT.Rows.Count Then
                '    '配列セット
                '    xl.SetRangeValue(rowPos - rowWkCnt, rowPos, 41, data)
                'Else
                '    rowWkCnt = rowWkCnt + 1
                'End If

                data(rowWkCnt, 0) = WordHenkan("N", "S", wkRow("ROW_NUM"))                             '連番号
                data(rowWkCnt, 1) = WordHenkan("N", "S", wkRow("KEIYAKUSYA_CD"))                       '契約者番号
                data(rowWkCnt, 2) = WordHenkan("N", "S", wkRow("KEIYAKU_KBN_NM"))                      '契約区分名
                data(rowWkCnt, 3) = WordHenkan("N", "S", wkRow("KEIYAKU_DATE"))                        '契約日
                data(rowWkCnt, 4) = WordHenkan("N", "S", wkRow("NYU_HEN_DATE"))                        '入金・返還日
                data(rowWkCnt, 5) = WordHenkan("N", "S", wkRow("KEIYAKUSYA_NAME"))                     '契約者名
                data(rowWkCnt, 6) = WordHenkan("N", "S", wkRow("ADDR"))                                '契約者住所
                If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                    data(rowWkCnt, 7) = ""
                Else
                    data(rowWkCnt, 7) = WordHenkan("N", "Z", wkRow("TOSU1"))                           '戸数-採卵鶏成鶏
                End If
                data(rowWkCnt, 8) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU1"))                       '羽数-採卵鶏成鶏
                data(rowWkCnt, 9) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN1"))                       '金額-採卵鶏成鶏
                If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                    data(rowWkCnt, 10) = ""
                Else
                    data(rowWkCnt, 10) = WordHenkan("N", "Z", wkRow("TOSU2"))                           '戸数-採卵鶏育成
                End If
                data(rowWkCnt, 11) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU2"))                       '羽数-採卵鶏育成
                data(rowWkCnt, 12) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN2"))                      '金額-採卵鶏育成
                If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                    data(rowWkCnt, 13) = ""
                Else
                    data(rowWkCnt, 13) = WordHenkan("N", "Z", wkRow("TOSU3"))                          '戸数-肉用種
                End If
                data(rowWkCnt, 14) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU3"))                      '羽数-肉用種
                data(rowWkCnt, 15) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN3"))                      '金額-肉用種
                If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                    data(rowWkCnt, 16) = ""
                Else
                    data(rowWkCnt, 16) = WordHenkan("N", "Z", wkRow("TOSU4"))                          '戸数-種鶏成鶏
                End If
                data(rowWkCnt, 17) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU4"))                      '羽数-種鶏成鶏
                data(rowWkCnt, 18) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN4"))                      '金額-種鶏成鶏
                If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                    data(rowWkCnt, 19) = ""
                Else
                    data(rowWkCnt, 19) = WordHenkan("N", "Z", wkRow("TOSU5"))                          '戸数-種鶏育成
                End If
                data(rowWkCnt, 20) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU5"))                      '羽数-種鶏育成
                data(rowWkCnt, 21) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN5"))                      '金額-種鶏育成
                If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                    data(rowWkCnt, 22) = ""
                Else
                    data(rowWkCnt, 22) = WordHenkan("N", "Z", wkRow("TOSU6"))                          '戸数-うずら
                End If
                data(rowWkCnt, 23) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU6"))                      '羽数-うずら
                data(rowWkCnt, 24) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN6"))                      '金額-うずら
                If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                    data(rowWkCnt, 25) = ""
                Else
                    data(rowWkCnt, 25) = WordHenkan("N", "Z", wkRow("TOSU7"))                          '戸数-あひる
                End If
                data(rowWkCnt, 26) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU7"))                      '羽数-あひる
                data(rowWkCnt, 27) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN7"))                      '金額-あひる

                If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                    data(rowWkCnt, 28) = ""
                Else
                    data(rowWkCnt, 28) = WordHenkan("N", "Z", wkRow("TOSU8"))                          '戸数-きじ
                End If
                data(rowWkCnt, 29) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU8"))                      '羽数-きじ
                data(rowWkCnt, 30) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN8"))                      '金額-きじ

                If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                    data(rowWkCnt, 31) = ""
                Else
                    data(rowWkCnt, 31) = WordHenkan("N", "Z", wkRow("TOSU9"))                          '戸数-ほろほろ鳥
                End If
                data(rowWkCnt, 32) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU9"))                      '羽数-ほろほろ鳥
                data(rowWkCnt, 33) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN9"))                      '金額-ほろほろ鳥

                If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                    data(rowWkCnt, 34) = ""
                Else
                    data(rowWkCnt, 34) = WordHenkan("N", "Z", wkRow("TOSU10"))                          '戸数-七面鳥
                End If
                data(rowWkCnt, 35) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU10"))                      '羽数-七面鳥
                data(rowWkCnt, 36) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN10"))                      '金額-七面鳥

                If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                    data(rowWkCnt, 37) = ""
                Else
                    data(rowWkCnt, 37) = WordHenkan("N", "Z", wkRow("TOSU11"))                          '戸数-だちょう
                End If
                data(rowWkCnt, 38) = WordHenkan("N", "Z", wkRow("KEIYAKU_HASU11"))                      '羽数-だちょう
                data(rowWkCnt, 39) = WordHenkan("N", "Z", wkRow("TUMITATE_KIN11"))                      '金額-だちょう
                If WordHenkan("N", "S", wkRow("GRPID")) = 0 Then
                    data(rowWkCnt, 40) = ""
                Else
                    data(rowWkCnt, 40) = WordHenkan("N", "Z", wkRow("TOSU_SUM"))                       '戸数-合計
                End If
                data(rowWkCnt, 41) = WordHenkan("N", "Z", wkRow("HASU_SUM"))                           '羽数-合計
                data(rowWkCnt, 42) = WordHenkan("N", "Z", wkRow("TUMITATE_SUM"))                       '金額-合計

                '配列数の判定
                If rowWkCnt >= rowMaxRow Then
                    '配列セット
                    xl.SetRangeValue(rowPos - rowMaxRow, rowPos, 43, data)
                    rowWkCnt = 0
                ElseIf rowCnt >= wkDT.Rows.Count Then
                    '配列セット
                    xl.SetRangeValue(rowPos - rowWkCnt, rowPos, 43, data)
                Else
                    rowWkCnt = rowWkCnt + 1
                End If
                '2021/07/12 JBD9020 新契約日追加 UPD END


                '↑2017/07/12 修正 鳥区分追加

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
                '2020/09/07 JBD9020 DEL START
                ''FROM
                ''If Not f_CodeMaster_Data_Select(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_Fm, 1, True, 1) Then '2017/07/11 修正
                'If Not f_CodeMaster_Data_Select(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_Fm, 1, True, 0) Then  '2017/07/11 修正
                '    Exit Try
                'End If
                ''FROM
                ''If Not f_CodeMaster_Data_Select(cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To, 1, True, 1) Then '2017/07/11 修正
                'If Not f_CodeMaster_Data_Select(cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To, 1, True, 0) Then  '2017/07/11 修正
                '    Exit Try
                'End If
                '2020/09/07 JBD9020 DEL END
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
                '2020/09/07 JBD9020 DEL START
                'cboKEIYAKU_KBN_Cd_Fm.Text = ""
                'cboKEIYAKU_KBN_Cd_To.Text = ""
                '2020/09/07 JBD9020 DEL END

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
            rdoKEIYAKU_KEI.Checked = True
            '2016/10/26　削除開始
            'dateKEIYAKU_Ymd_Fm.Value = New Obj_TM_SYORI_NENDO_KI().pJIGYO_NENDO_byDate
            'dateKEIYAKU_Ymd_To.Value = Format(Now, "yyyy/MM/dd")
            '2016/10/26　削除終了

            '2020/09/07 JBD9020 ADD START
            dateTAISYOBI_Ymd.Value = Format(Now, "yyyy/MM/dd")
            chkKAZOKU.Checked = True
            chkKIGYOU.Checked = True
            chkIGAI.Checked = True
            '2020/09/07 JBD9020 ADD END

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

            '2016/10/26　削除開始
            'wkControlName = "契約締結日範囲"
            'If dateKEIYAKU_Ymd_Fm.Value Is Nothing Then
            '    Call Show_MessageBox_Add("W008", wkControlName) : dateKEIYAKU_Ymd_Fm.Focus() : Exit Try
            'End If
            'wkControlName = "契約締結日範囲"
            'If dateKEIYAKU_Ymd_To.Value Is Nothing Then
            '    Call Show_MessageBox_Add("W008", wkControlName) : dateKEIYAKU_Ymd_To.Focus() : Exit Try
            'End If
            '2016/10/26　削除終了

            '==いろいろチェック==================
            ''対象日（現在）チェック
            'Dim dtJIGYO_NENDO = New Obj_TM_SYORI_NENDO_KI().pJIGYO_NENDO_byDate
            'Dim dtJIGYO_SYURYO_NENDO = New Obj_TM_SYORI_NENDO_KI().pJIGYO_SYURYO_NENDO_byDate
            'If dtJIGYO_NENDO >= dateTAISYOBI_Ymd.Value And dtJIGYO_SYURYO_NENDO <= dateTAISYOBI_Ymd.Value Then
            '    wkControlName = "対象期年度以外の対象日（現在）"
            '    Call Show_MessageBox_Add("W029", wkControlName) : dateTAISYOBI_Ymd.Focus() : Exit Try
            'End If

            '==FromToチェック==================
            '2016/10/26　削除開始
            ''契約締結日範囲
            'If f_Daisyo_Check(dateKEIYAKU_Ymd_Fm, dateKEIYAKU_Ymd_To, "契約締結日", True, 2) = False Then
            '    Return False
            'End If
            '2016/10/26　削除終了

            '契約区分
            '2020/09/07 JBD9020 DEL START
            'If f_Daisyo_Check(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Cd_To, "契約区分", True, 1) = False Then
            '    Return False
            'End If
            '2020/09/07 JBD9020 DEL END

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
