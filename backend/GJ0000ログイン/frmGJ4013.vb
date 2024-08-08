'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ4013.vb
'*
'*　　②　機能概要　　　　　焼却・埋却互助金申請情報入力（契約交付情報表示）
'*
'*　　③　作成日　　　　　　2015/01/24　BY JBD
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

Public Class frmGJ4013

#Region "***変数定義***"

    ''' <summary>
    ''' 固定項目
    ''' </summary>
    ''' <remarks></remarks>
    Property p4010_KI As Integer

    ''' <summary>
    ''' 結果一覧セット用データセット
    ''' </summary>
    ''' <remarks></remarks>
    Private pDataSet As New DataSet

    ''' <summary>
    ''' カレント主キー
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pCurrentKey As frmGJ4010.T_KEY

    ''' <summary>
    ''' 行No
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pSel_NO As Integer

    ''' <summary>
    ''' 処理区分
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pSyoriKbn As Enu_SyoriKubun    '画面処理区分

    ''' <summary>
    '''  画面入力内容変更フラグ
    ''' </summary>
    ''' <remarks></remarks>
    Private loblnTextChange As Boolean                      '画面入力内容変更フラグ

    ''' <summary>
    ''' 処理区分
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Enu_SyoriKubun
        ''' <summary>
        ''' 新規登録モード
        ''' </summary>
        ''' <remarks></remarks>
        Insert = 0
        ''' <summary>
        ''' 更新モード
        ''' </summary>
        ''' <remarks></remarks>
        Update = 1
    End Enum

    ''' <summary>
    '''  プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True
    '明細件数
    Private pLineMax As Integer = 999
    '行情報
    Private pCurrentRow As Integer = 0

    ''' <summary>
    '''  交付率 '2022/01/28 JBD9020 減額率交付率追加
    ''' </summary>
    Private pKofuRitu As Double = 100
    ''' <summary>
    '''  再計算フラグ '2022/01/28 JBD9020 減額率交付率追加
    ''' </summary>
    Private pBlnChange As Boolean = False
#End Region

#Region "***画面制御関連***"

#Region "frmXXXXXX_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ4011_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmXXXLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean
        Dim wSql As String = String.Empty

        Try
            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            '画面初期化
            ret = f_ObjectClear("C")

            'グリッド　クリア
            f_Grid_Clear()

            '変更判定イベント登録
            f_setControlChangeEvents()

            '★初期コントロールにフォーカスセット
            txt_HASSEI_KAISU.Focus()

            loblnTextChange = False

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        Finally
        End Try

    End Sub

#End Region

#End Region

#Region "***画面ボタンクリック関連***"

#Region "cmdSearch_Click 検索ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSearch_Click
    '説明            :検索ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            lblCOUNT.Text = ""      '2015/10/16　追加

            '入力チェック
            If Not f_Input_Check("") Then
                Exit Try
            End If


            '検索処理
            If Not f_Grid_Set("S", 0, 0, 0) Then
                Exit Try
            End If

            'ボタン制御
            If Not f_DtlButton_Enable(False) Then
                Exit Try
            End If

            '該当データ取得
            If dgv_Search.SelectedRows.Count > 0 Then
                '明細セット
                f_DtlSet(0)
                '====明細設定======================
                f_SetForm_Data(0)

            End If

            loblnTextChange = False

            '2022/01/28 JBD9020 減額率交付率追加 ADD START
            If pBlnChange Then
                loblnTextChange = True
            End If
            pBlnChange = False
            '2022/01/28 JBD9020 減額率交付率追加 ADD END

            '★初期コントロールにフォーカスセット
            dgv_Search.Focus()


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdSave_Click 保存ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSave_Click
    '説明            :保存ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim numSelectRowIdx As Integer
        Dim wStr As String = String.Empty
        Dim wMEISAI_NO As Integer = 0
        Dim wNOJO_CD As Integer = 0
        Dim wTORI_KBN As Integer = 0
        Dim ret As Boolean = False



        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")       'データが選択されていません。
                Exit Try
            End If

            '選択されている行を見つける
            For i As Integer = 0 To dgv_Search.RowCount - 1
                If dgv_Search.Rows(i).Selected Then
                    '選択されている行が見つかったのでインデックスをワークに退避
                    numSelectRowIdx = i
                    Exit For
                End If
            Next

            ''処理状況チェック
            'If WordHenkan("N", "Z", dgv_Search.Item("SYORI_JOKYO_KBN", numSelectRowIdx).Value) = 4 Then
            '    Show_MessageBox_Add("I007", "交付金計算済みのため修正できません。")
            '    Exit Try
            'End If

            'キー情報退避
            wMEISAI_NO = WordHenkan("N", "Z", dgv_Search.Item("MEISAI_NO", numSelectRowIdx).Value)
            wNOJO_CD = WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD", numSelectRowIdx).Value)
            wTORI_KBN = WordHenkan("N", "Z", dgv_Search.Item("TORI_KBN", numSelectRowIdx).Value)

            '処理状況チェック
            If WordHenkan("N", "Z", dgv_Search.Item("SYORI_JOKYO_KBN", numSelectRowIdx).Value) = 0 Then
                '事前チェック
                If Not f_Input_Check("S") Then
                    Exit Try
                End If

                '保存処理確認
                If Show_MessageBox_Add("Q004", "データ") = DialogResult.No Then    '保存します。よろしいですか？
                    Exit Try
                End If

                '追加
                If Not f_Data_Insert(wNOJO_CD, wTORI_KBN) Then
                    Exit Try
                End If
            Else
                If loblnTextChange Then
                Else
                    '画面に変更がない場合は、メッセージ表示
                    Show_MessageBox_Add("I007", "変更したデータはありません。")
                    Exit Try
                End If

                '事前チェック
                If Not f_Input_Check("S") Then
                    Exit Try
                End If

                '保存処理確認
                If Show_MessageBox_Add("Q005", "データ") = DialogResult.No Then    '保存します。よろしいですか？
                    Exit Try
                End If

                '更新
                If Not f_Data_update(wNOJO_CD, wTORI_KBN) Then
                    Exit Try
                End If
            End If

            '検索処理
            If Not f_Grid_Set("S", wMEISAI_NO, wNOJO_CD, wTORI_KBN) Then
                Exit Try
            End If

            'グリッド　再表示
            ret = f_GridReDisp(wMEISAI_NO, wNOJO_CD, wTORI_KBN)


            '明細　クリア
            f_DtlClear()

            'ボタン制御
            If Not f_DtlButton_Enable(False) Then
                Exit Sub
            End If

            loblnTextChange = False      '画面入力内容変更フラグクリア

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdDel_Click 削除ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdDel_Click
    '説明            :削除ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        Dim ret As Boolean = False
        Dim numSelectRowIdx As Integer
        Dim wDel_MEISAI_NO As Integer = 0
        Dim wDel_NOJO_CD As Integer = 0
        Dim wDel_TORI_KBN As Integer = 0

        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")       'データが選択されていません。
                Exit Try
            End If

            '選択されている行を見つける
            For i As Integer = 0 To dgv_Search.RowCount - 1
                If dgv_Search.Rows(i).Selected Then
                    '選択されている行が見つかったのでインデックスをワークに退避
                    numSelectRowIdx = i
                    Exit For
                End If
            Next

            '処理状況チェック
            If WordHenkan("N", "Z", dgv_Search.Item("SYORI_JOKYO_KBN", numSelectRowIdx).Value) = 4 Then
                Show_MessageBox_Add("I007", "交付金計算済みのため削除できません。")
                Exit Try
            End If
            If WordHenkan("N", "Z", dgv_Search.Item("SYORI_JOKYO_KBN", numSelectRowIdx).Value) = 0 Then
                Show_MessageBox_Add("I007", "互助金申請入力が行われていないため削除できません。")
                Exit Try
            End If


            '削除処理確認
            If Show_MessageBox_Add("Q006", "指定されたデータ") = DialogResult.No Then    '指定されたデータを削除します。よろしいですか？
                Exit Try
            End If


            'キー項目
            wDel_MEISAI_NO = WordHenkan("N", "Z", dgv_Search.Item("MEISAI_NO", numSelectRowIdx).Value)
            wDel_NOJO_CD = WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD", numSelectRowIdx).Value)
            wDel_TORI_KBN = WordHenkan("N", "Z", dgv_Search.Item("TORI_KBN", numSelectRowIdx).Value)

            '該当データ削除処理
            If Not f_Data_Deleate(numSelectRowIdx) Then
                Exit Try
            End If

            '検索処理
            If Not f_Grid_Set("S", 0, 0, 0) Then
                Exit Try
            End If
            '明細　クリア
            f_DtlClear()

            'ボタン制御
            If Not f_DtlButton_Enable(False) Then
                Exit Sub
            End If

            '明細入力制御
            If Not f_DtlInput_Enable(False) Then
                Exit Sub
            End If

            '画面入力内容変更フラグクリア
            loblnTextChange = False

            'グリッド　再表示
            f_Grid_Set("", wDel_MEISAI_NO, wDel_NOJO_CD, wDel_TORI_KBN)

            '★初期コントロールにフォーカスセット
            dgv_Search.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdCan_Click キャンセルボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdCan_Click
    '説明            :キャンセルボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdCan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCansel.Click

        If loblnTextChange Then
            '画面に変更があり保存していない場合は、メッセージ表示
            If Show_MessageBox("Q007", "") = DialogResult.No Then
                Exit Sub
            End If
        End If

        '明細　クリア
        f_DtlClear()

        'ボタン制御
        If Not f_DtlButton_Enable(False) Then
            Exit Sub
        End If

        '明細入力制御
        If Not f_DtlInput_Enable(False) Then
            Exit Sub
        End If


        '変更フラグクリア
        loblnTextChange = False

        '★初期コントロールにフォーカスセット
        dgv_Search.Focus()


    End Sub
#End Region

#Region "cmdEnd_Click 終了ボタンクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdEnd_Click
    '説明            :終了ボタンクリック時処理
    '------------------------------------------------------------------
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try
            If loblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then
                    Exit Try
                End If
            End If

            loblnTextChange = False      '画面入力内容変更フラグ初期化
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

#Region "発生回数"

    '------------------------------------------------------------------
    'プロシージャ名  :txt_HASSEI_KAISU_Validating
    '説明            :発生回数Validating時処理
    '------------------------------------------------------------------
    Private Sub txt_HASSEI_KAISU_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_HASSEI_KAISU.Validating
        If txt_HASSEI_KAISU.Text = "0" Then
            txt_HASSEI_KAISU.Text = ""
            Exit Sub
        End If
        f_getTT_KOFU_SINSEI_Date()
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :txt_HASSEI_KAISU_TextChanged
    '説明            :発生回数TextChanged時処理
    '------------------------------------------------------------------
    Private Sub txt_HASSEI_KAISU_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_HASSEI_KAISU.TextChanged

        Try

            '2017/07/21　追加開始
            If pJump Then
                Exit Sub
            End If
            '2017/07/21　追加終了

            'グリッド　クリア
            f_Grid_Clear()

            '明細　クリア
            f_DtlClear()

            'ボタン制御
            If Not f_DtlButton_Enable(False) Then
                Exit Try
            End If

            '明細入力制御
            If Not f_DtlInput_Enable(False) Then
                Exit Try
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        Finally
            cmdSearch.Enabled = True
        End Try


    End Sub


#End Region

#Region "dgv_Search グリッドクリック時処理"

    Private Sub dgv_Search_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_Search.Enter

        '2015/10/16　追加開始

        'Try

        '    If pJump Then
        '        Exit Try
        '    End If

        '    If loblnTextChange Then
        '        '画面に変更があり保存していない場合は、メッセージ表示
        '        If Show_MessageBox("Q007", "") = DialogResult.No Then
        '            num_KOFU_HASU.Focus()
        '            Exit Sub
        '        End If
        '    End If

        'Catch ex As Exception
        '    '共通例外処理
        '    Show_MessageBox("", ex.Message)
        '    'フォームクローズ
        '    Me.Close()
        'End Try

        '2015/10/16　追加終了
    End Sub

    Private Sub dgv_Search_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Search.RowEnter
        
        '2015/10/16　追加開始

        Try

            If pCurrentRow = e.RowIndex Then
                Exit Try
            End If

            '明細表示
            f_SetForm_Data(e.RowIndex)

            '変更フラグOFF
            loblnTextChange = False

            '2022/01/28 JBD9020 減額率交付率追加 ADD START
            If pBlnChange Then
                loblnTextChange = True
            End If
            pBlnChange = False
            '2022/01/28 JBD9020 減額率交付率追加 ADD END

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'フォームクローズ
            Me.Close()
        End Try

        '2015/10/16　追加終了

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :dgv_Search_Click
    '説明            :グリッドクリック時処理
    '------------------------------------------------------------------
    Private Sub dgv_Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_Search.Click


        '2015/10/16　削除開始
        'Try
        '    '該当データ取得
        '    If dgv_Search.SelectedRows.Count > 0 Then
        '        Dim intRow As Integer = 0       '行番号
        '        For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
        '            intRow = gRow.Index
        '        Next


        '        '====明細設定======================
        '        f_SetForm_Data(intRow)


        '        loblnTextChange = False
        '    End If


        'Catch ex As Exception
        '    '共通例外処理
        '    Show_MessageBox("", ex.Message)
        '    'フォームクローズ
        '    Me.Close()
        'End Try
        '2015/10/16　削除終了

    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :dgv_Search_KeyUp
    '説明            :キーUP時処理
    '------------------------------------------------------------------
    Private Sub dgv_Search_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_Search.KeyUp
        'If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
        '    '該当データ取得
        '    If dgv_Search.SelectedRows.Count > 0 Then
        '        Dim intRow As Integer = 0       '行番号
        '        For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
        '            intRow = gRow.Index
        '        Next
        '        '明細セット
        '        f_DtlSet(intRow)
        '        '明細入力制御
        '        f_DtlInput_Enable(True)
        '    End If
        'End If

        'loblnTextChange = False
    End Sub
#End Region

#Region "numKeisan_ValueChanged　互助金申請計算"
    '------------------------------------------------------------------
    'プロシージャ名  :numKeisan_ValueChanged
    '説明            :互助金申請計算
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Sub numKeisan_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num_KOFU_HASU_NYU.ValueChanged,
                                                                                                           num_SYOKYAKU_KEIHI.ValueChanged,
                                                                                                           num_KUNI_KOFUKIN.ValueChanged,
                                                                                                           num_GENGAKU_RITU.ValueChanged, '2022/01/28 JBD9020 減額率交付率追加 ADD
                                                                                                           num_KOFU_RITU.ValueChanged '2022/01/28 JBD9020 減額率交付率追加 ADD
        Dim wkKin As Decimal
        Dim wkKindb As Double

        '----------------------------------
        '互助金申請計算処理
        '----------------------------------
        Try

            '互助金交付対象羽数
            If Not num_KOFU_HASU_NYU.Value Is Nothing Then
                num_KOFU_HASU_DISP.Value = num_KOFU_HASU_NYU.Value
            Else
                num_KOFU_HASU_DISP.Value = Nothing
            End If

            '①互助金算定額
            If Not num_KOFU_HASU_DISP.Value Is Nothing And Not num_KOFU_TANKA.Value Is Nothing Then
                wkKin = num_KOFU_HASU_DISP.Value * num_KOFU_TANKA.Value
                num_MARU1.Value = wkKin
            Else
                num_MARU1.Value = Nothing
            End If

            '②焼却等経費(円未満切捨て)
            If Not num_SYOKYAKU_KEIHI.Value Is Nothing And Not num_KUNI_KOFUKIN.Value Is Nothing Then
                wkKin = num_SYOKYAKU_KEIHI.Value * 0.9
                wkKin = wkKin - num_KUNI_KOFUKIN.Value
                num_MARU2.Value = Math.Truncate(wkKin)
            Else
                num_MARU2.Value = Nothing
            End If

            '③焼却・埋却互助金算定額
            '2022/02/01 JBD9020 減額率交付率追加 UPD START
            If Not num_MARU1.Value Is Nothing And Not num_MARU2.Value Is Nothing Then
                If num_MARU1.Value <= num_MARU2.Value Then
                    num_KOME1.Value = num_MARU1.Value
                Else
                    num_KOME1.Value = num_MARU2.Value
                End If
                '2022/02/01 JBD9020 減額率追加 DEL START
                'num_MARU3_DISP1.Value = num_KOME1.Value
                'num_MARU3_DISP2.Value = num_KOME1.Value
                '2022/02/01 JBD9020 減額率追加 DEL END
            Else
                num_KOME1.Value = Nothing
                '2022/02/01 JBD9020 減額率交付率追加 DEL START
                'num_MARU3_DISP1.Value = Nothing
                'num_MARU3_DISP2.Value = Nothing
                '2022/02/01 JBD9020 減額率交付率追加 DEL END
            End If

            '2022/02/01 JBD9020 減額率交付率追加 ADD START
            '減額計算
            If Not num_KOME1.Value Is Nothing And Not num_GENGAKU_RITU.Value Is Nothing And Not num_KOME1.Value < 0 Then
                Dim wkGen As Double
                wkGen = num_KOME1.Value * num_GENGAKU_RITU.Value / 100
                num_KOME2.Value = Math.Ceiling(wkGen)
                num_MARU3_CALC.Value = num_KOME1.Value - num_KOME2.Value
                num_MARU3_DISP1.Value = num_MARU3_CALC.Value
                num_MARU3_DISP2.Value = num_MARU3_CALC.Value
            Else
                num_MARU3_DISP1.Value = Nothing
                num_MARU3_DISP2.Value = Nothing
                num_KOME2.Value = Nothing
                num_MARU3_CALC.Value = Nothing
            End If
            '2022/02/01 JBD9020 減額率交付率追加 ADD END


            '④焼却・埋却互助金（積立金分）（円未満切り上げ）
            '2022/02/01 JBD9020 減額率交付率追加 UPD START
            'If Not num_MARU3_DISP1.Value Is Nothing Then
            If Not num_MARU3_DISP1.Value Is Nothing And Not num_KOFU_RITU.Value Is Nothing Then
                '2022/02/01 JBD9020 減額率交付率追加 UPD END
                wkKindb = num_MARU3_DISP1.Value * 0.5
                num_KOME3_CALC.Value = Math.Ceiling(wkKindb)
                '2022/02/01 JBD9020 減額率交付率追加 UPD START
                'num_MARU4_DISP.Value = Math.Ceiling(wkKindb)
                num_KOME3_DISP1.Value = num_KOME3_CALC.Value
                num_KOME3_DISP2.Value = num_KOME3_CALC.Value
                Dim wkKof As Double
                wkKof = num_KOME3_CALC.Value * num_KOFU_RITU.Value / 100
                num_MARU4.Value = Math.Ceiling(wkKof)
                '2022/02/01 JBD9020 減額率交付率追加 UPD END
            Else
                num_KOME3_CALC.Value = Nothing
                num_KOME3_DISP2.Value = Nothing
                '2022/02/01 JBD9020 減額率交付率追加 ADD START
                num_KOME3_DISP1.Value = Nothing
                num_MARU4.Value = Nothing
                '2022/02/01 JBD9020 減額率交付率追加 ADD END
            End If


            '⑤焼却・埋却互助金（国庫交付金分）
            If Not num_MARU3_DISP2.Value Is Nothing And Not num_KOME3_DISP2.Value Is Nothing Then
                num_MARU5.Value = num_MARU3_DISP2.Value - num_KOME3_DISP2.Value
            Else
                num_MARU5.Value = Nothing
            End If

            '⑥焼却・埋却互助金
            '2022/02/01 JBD9020 減額率交付率追加 UPD START
            'If Not num_KOME3_CALC.Value Is Nothing And Not num_MARU5.Value Is Nothing Then
            '    num_MARU6.Value = num_KOME3_CALC.Value + num_MARU5.Value
            If Not num_KOME3_DISP2.Value Is Nothing And Not num_MARU5.Value Is Nothing Then
                num_MARU6.Value = num_MARU4.Value + num_MARU5.Value
                '2022/02/01 JBD9020 減額率交付率追加 UPD END
            Else
                num_MARU6.Value = Nothing
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
        End Try

    End Sub
#End Region

#Region "入力確認有無"
    '------------------------------------------------------------------
    'プロシージャ名  :rbtnSYORI_JOKYO_KBN_3_CheckedChanged
    '説明            :交付確定CheckedChanged時処理
    '------------------------------------------------------------------
    Private Sub rbtnSYORI_JOKYO_KBN_3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtnSYORI_JOKYO_KBN_3.CheckedChanged
        If rbtnSYORI_JOKYO_KBN_3.Checked Then
            dateKOFU_KAKUTEI_Ymd.Enabled = True
        Else
            dateKOFU_KAKUTEI_Ymd.Enabled = False
        End If
    End Sub
#End Region

#End Region

#Region "*** データ登録関連 ***"

#Region "互助金申請情報　削除処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Deleate
    '説明            :互助金申請情報　削除処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Deleate(ByVal intRow As Integer) As Boolean
        Dim Cmd As New OracleCommand
        Dim wkNow As Date = Now
        Dim wkRet As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Cmd.CommandText = "PKG_GJ4010.GJ4010_KOFU_SINSEI_DEL"

            '引き渡し
            '期
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", WordHenkan("N", "Z", p4010_KI))
            '発生回数
            Dim paraHASSEI_KAISU As OracleParameter = Cmd.Parameters.Add("IN_HASSEI_KAISU", WordHenkan("N", "Z", txt_HASSEI_KAISU.Text))
            '契約者番号
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", WordHenkan("N", "Z", pCurrentKey.KEIYAKUSYA_CD))
            '互助金種類区分
            Dim paraGOJOKIN_SYURUI_KBN As OracleParameter = Cmd.Parameters.Add("IN_GOJOKIN_SYURUI_KBN", 2)
            '農場コード
            Dim paraNOJO_CD As OracleParameter = Cmd.Parameters.Add("IN_NOJO_CD", WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD", intRow).Value))
            '鶏の種類
            Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", WordHenkan("N", "Z", dgv_Search.Item("TORI_KBN", intRow).Value))

            Dim paraREGDATE As OracleParameter = Cmd.Parameters.Add("IN_REG_DATE", Now)                 'データ登録日
            Dim paraREGID As OracleParameter = Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)            'データ登録ＩＤ
            Dim paraUPDATE As OracleParameter = Cmd.Parameters.Add("IN_UP_DATE", Now)                   'データ更新日
            Dim paraUPID As OracleParameter = Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)              'データ更新ＩＤ
            Dim paraCOMNM As OracleParameter = Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)               'コンピュータ名

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Throw New Exception(Cmd.Parameters("OU_MSGCD").Value.ToString() & ":" & Cmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If

            wkRet = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
        End Try


        Return wkRet


    End Function

#End Region

#Region "f_Data_Insert　互助金申請情報　追加処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Insert
    '説明            :互助金申請情報　追加処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Insert(ByVal wNOJO_CD As Integer, ByVal wTORI_KBN As Integer) As Boolean
        Dim Cmd As New OracleCommand
        Dim wkNow As Date = Now
        Dim wkRet As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Cmd.CommandText = "PKG_GJ4010.GJ4010_KOFU_SINSEI_INS"

            '引き渡し
            '期
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", WordHenkan("N", "Z", p4010_KI))
            '発生回数
            Dim paraHASSEI_KAISU As OracleParameter = Cmd.Parameters.Add("IN_HASSEI_KAISU", WordHenkan("N", "Z", txt_HASSEI_KAISU.Text))
            '契約者番号
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", WordHenkan("N", "Z", pCurrentKey.KEIYAKUSYA_CD))
            '互助金種類区分
            Dim paraGOJOKIN_SYURUI_KBN As OracleParameter = Cmd.Parameters.Add("IN_GOJOKIN_SYURUI_KBN", 2)
            '農場コード
            Dim paraNOJO_CD As OracleParameter = Cmd.Parameters.Add("IN_NOJO_CD", WordHenkan("N", "Z", wNOJO_CD))
            '鶏の種類
            Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", WordHenkan("N", "Z", wTORI_KBN))

            '契約区分
            Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", WordHenkan("N", "Z", pCurrentKey.KEIYAKU_KBN))
            '処理状況区分
            If rbtnSYORI_JOKYO_KBN_1.Checked Then
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 1)
            End If
            If rbtnSYORI_JOKYO_KBN_2.Checked Then
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 2)
            End If
            If rbtnSYORI_JOKYO_KBN_3.Checked Then
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 3)
            End If

            '雇用労賃
            Dim paraKOYO_ROTIN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_ROTIN", DBNull.Value)
            '地代
            Dim paraJIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI", DBNull.Value)
            '減価償却
            Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", DBNull.Value)
            '空舎期間
            Dim paraKUSYA_KIKAN As OracleParameter = Cmd.Parameters.Add("IN_KUSYA_KIKAN", DBNull.Value)
            'その他固定費
            Dim paraSONOTA_KOTEIHI As OracleParameter = Cmd.Parameters.Add("IN_SONOTA_KOTEIHI", DBNull.Value)

            '焼却等経費
            Dim paraSYOKYAKU_KEIHI As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_KEIHI", WordHenkan("N", "Z", num_SYOKYAKU_KEIHI.Value))
            '国交付金
            Dim paraKUNI_KOFUKIN As OracleParameter = Cmd.Parameters.Add("IN_KUNI_KOFUKIN", WordHenkan("N", "Z", num_KUNI_KOFUKIN.Value))
            '交付確定日
            If rbtnSYORI_JOKYO_KBN_3.Checked Then
                Dim paraKOFU_KAKUTEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_KOFU_KAKUTEI_DATE", Format(dateKOFU_KAKUTEI_Ymd.Value, "yyyy/MM/dd"))
            Else
                Dim paraKOFU_KAKUTEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_KOFU_KAKUTEI_DATE", DBNull.Value)
            End If
            '交付単価
            Dim paraKOFU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KOFU_TANKA", WordHenkan("N", "Z", num_KOFU_TANKA.Value))
            '交付羽数
            Dim paraKOFU_HASU As OracleParameter = Cmd.Parameters.Add("IN_KOFU_HASU", WordHenkan("N", "Z", num_KOFU_HASU_NYU.Value))
            '生産者積立金分
            '2022/02/01 JBD9020 減額率交付率追加 UPD START
            'Dim paraSEI_TUMITATE_KIN As OracleParameter = Cmd.Parameters.Add("IN_SEI_TUMITATE_KIN", WordHenkan("N", "Z", num_KOME3_CALC.Value))
            Dim paraSEI_TUMITATE_KIN As OracleParameter = Cmd.Parameters.Add("IN_SEI_TUMITATE_KIN", WordHenkan("N", "Z", num_MARU4.Value))
            '2022/02/01 JBD9020 減額率交付率追加 UPD END
            '国庫交付金分
            Dim paraKUNI_KOFU_KIN As OracleParameter = Cmd.Parameters.Add("IN_KUNI_KOFU_KIN", WordHenkan("N", "Z", num_MARU5.Value))
            '交付金額
            Dim paraKOFU_KIN As OracleParameter = Cmd.Parameters.Add("IN_KOFU_KIN", WordHenkan("N", "Z", num_MARU6.Value))

            '互助金単価マスタ参照日
            Dim paraTANKA_MST_DATE As OracleParameter = Cmd.Parameters.Add("IN_TANKA_MST_DATE", pCurrentKey.TANKA_MST_DATE)
            '申請日
            Dim paraSINSEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_SINSEI_DATE", Format(dateSINSEI_DATE.Value, "yyyy/MM/dd"))

            '2022/01/28 JBD9020 減額率交付率追加 ADD START
            '算定金額
            Dim paraSANTEI_KIN As OracleParameter = Cmd.Parameters.Add("IN_SANTEI_KIN", WordHenkan("N", "Z", num_KOME1.Value))
            '減額率
            Dim paraGENGAKU_RITU As OracleParameter = Cmd.Parameters.Add("IN_GENGAKU_RITU", WordHenkan("N", "Z", num_GENGAKU_RITU.Value))
            '交付率
            Dim paraKOFU_RITU As OracleParameter = Cmd.Parameters.Add("IN_KOFU_RITU", WordHenkan("N", "Z", num_KOFU_RITU.Value))
            '2022/01/28 JBD9020 減額率交付率追加 ADD END

            Dim paraREGDATE As OracleParameter = Cmd.Parameters.Add("IN_REG_DATE", Now)                 'データ登録日
            Dim paraREGID As OracleParameter = Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)            'データ登録ＩＤ
            Dim paraUPDATE As OracleParameter = Cmd.Parameters.Add("IN_UP_DATE", Now)                   'データ更新日
            Dim paraUPID As OracleParameter = Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)              'データ更新ＩＤ
            Dim paraCOMNM As OracleParameter = Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)               'コンピュータ名

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Throw New Exception(Cmd.Parameters("OU_MSGCD").Value.ToString() & ":" & Cmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If

            wkRet = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
        End Try
        Return wkRet
    End Function

#End Region

#Region "f_Data_update　互助金申請情報　更新処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_update
    '説明            :互助金申請情報　更新処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_update(ByVal wNOJO_CD As Integer, ByVal wTORI_KBN As Integer) As Boolean
        Dim Cmd As New OracleCommand
        Dim wkNow As Date = Now
        Dim wkRet As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Cmd.CommandText = "PKG_GJ4010.GJ4010_KOFU_SINSEI_UPD"

            '引き渡し
            '期
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", WordHenkan("N", "Z", p4010_KI))
            '発生回数
            Dim paraHASSEI_KAISU As OracleParameter = Cmd.Parameters.Add("IN_HASSEI_KAISU", WordHenkan("N", "Z", txt_HASSEI_KAISU.Text))
            '契約者番号
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", WordHenkan("N", "Z", pCurrentKey.KEIYAKUSYA_CD))
            '互助金種類区分
            Dim paraGOJOKIN_SYURUI_KBN As OracleParameter = Cmd.Parameters.Add("IN_GOJOKIN_SYURUI_KBN", 2)
            '農場コード
            Dim paraNOJO_CD As OracleParameter = Cmd.Parameters.Add("IN_NOJO_CD", WordHenkan("N", "Z", wNOJO_CD))
            '鶏の種類
            Dim paraTORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_TORI_KBN", WordHenkan("N", "Z", wTORI_KBN))

            '契約区分
            Dim paraKEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_KBN", WordHenkan("N", "Z", pCurrentKey.KEIYAKU_KBN))
            '処理状況区分
            If rbtnSYORI_JOKYO_KBN_1.Checked Then
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 1)
            End If
            If rbtnSYORI_JOKYO_KBN_2.Checked Then
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 2)
            End If
            If rbtnSYORI_JOKYO_KBN_3.Checked Then
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 3)
            End If

            '雇用労賃
            Dim paraKOYO_ROTIN As OracleParameter = Cmd.Parameters.Add("IN_KOYO_ROTIN", DBNull.Value)
            '地代
            Dim paraJIDAI As OracleParameter = Cmd.Parameters.Add("IN_JIDAI", DBNull.Value)
            '減価償却
            Dim paraGENKA_SYOKYAKU As OracleParameter = Cmd.Parameters.Add("IN_GENKA_SYOKYAKU", DBNull.Value)
            '空舎期間
            Dim paraKUSYA_KIKAN As OracleParameter = Cmd.Parameters.Add("IN_KUSYA_KIKAN", DBNull.Value)
            'その他固定費
            Dim paraSONOTA_KOTEIHI As OracleParameter = Cmd.Parameters.Add("IN_SONOTA_KOTEIHI", DBNull.Value)

            '焼却等経費
            Dim paraSYOKYAKU_KEIHI As OracleParameter = Cmd.Parameters.Add("IN_SYOKYAKU_KEIHI", WordHenkan("N", "Z", num_SYOKYAKU_KEIHI.Value))
            '国交付金
            Dim paraKUNI_KOFUKIN As OracleParameter = Cmd.Parameters.Add("IN_KUNI_KOFUKIN", WordHenkan("N", "Z", num_KUNI_KOFUKIN.Value))
            '交付確定日
            If rbtnSYORI_JOKYO_KBN_3.Checked Then
                Dim paraKOFU_KAKUTEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_KOFU_KAKUTEI_DATE", Format(dateKOFU_KAKUTEI_Ymd.Value, "yyyy/MM/dd"))
            Else
                Dim paraKOFU_KAKUTEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_KOFU_KAKUTEI_DATE", DBNull.Value)
            End If
            '交付単価
            Dim paraKOFU_TANKA As OracleParameter = Cmd.Parameters.Add("IN_KOFU_TANKA", WordHenkan("N", "Z", num_KOFU_TANKA.Value))
            '交付羽数
            Dim paraKOFU_HASU As OracleParameter = Cmd.Parameters.Add("IN_KOFU_HASU", WordHenkan("N", "Z", num_KOFU_HASU_NYU.Value))
            '生産者積立金分
            '2022/02/01 JBD9020 減額率交付率追加 UPD START
            'Dim paraSEI_TUMITATE_KIN As OracleParameter = Cmd.Parameters.Add("IN_SEI_TUMITATE_KIN", WordHenkan("N", "Z", num_KOME3_CALC.Value))
            Dim paraSEI_TUMITATE_KIN As OracleParameter = Cmd.Parameters.Add("IN_SEI_TUMITATE_KIN", WordHenkan("N", "Z", num_MARU4.Value))
            '2022/02/01 JBD9020 減額率交付率追加 UPD END
            '国庫交付金分
            Dim paraKUNI_KOFU_KIN As OracleParameter = Cmd.Parameters.Add("IN_KUNI_KOFU_KIN", WordHenkan("N", "Z", num_MARU5.Value))
            '交付金額
            Dim paraKOFU_KIN As OracleParameter = Cmd.Parameters.Add("IN_KOFU_KIN", WordHenkan("N", "Z", num_MARU6.Value))

            '互助金単価マスタ参照日
            Dim paraTANKA_MST_DATE As OracleParameter = Cmd.Parameters.Add("IN_TANKA_MST_DATE", pCurrentKey.TANKA_MST_DATE)
            '申請日
            Dim paraSINSEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_SINSEI_DATE", Format(dateSINSEI_DATE.Value, "yyyy/MM/dd"))

            '2022/01/28 JBD9020 減額率交付率追加 ADD START
            '算定金額
            Dim paraSANTEI_KIN As OracleParameter = Cmd.Parameters.Add("IN_SANTEI_KIN", WordHenkan("N", "Z", num_KOME1.Value))
            '減額率
            Dim paraGENGAKU_RITU As OracleParameter = Cmd.Parameters.Add("IN_GENGAKU_RITU", WordHenkan("N", "Z", num_GENGAKU_RITU.Value))
            '交付率
            Dim paraKOFU_RITU As OracleParameter = Cmd.Parameters.Add("IN_KOFU_RITU", WordHenkan("N", "Z", num_KOFU_RITU.Value))
            '2022/01/28 JBD9020 減額率交付率追加 ADD END

            Dim paraREGDATE As OracleParameter = Cmd.Parameters.Add("IN_REG_DATE", Now)                 'データ登録日
            Dim paraREGID As OracleParameter = Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)            'データ登録ＩＤ
            Dim paraUPDATE As OracleParameter = Cmd.Parameters.Add("IN_UP_DATE", Now)                   'データ更新日
            Dim paraUPID As OracleParameter = Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)              'データ更新ＩＤ
            Dim paraCOMNM As OracleParameter = Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)               'コンピュータ名

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Throw New Exception(Cmd.Parameters("OU_MSGCD").Value.ToString() & ":" & Cmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If

            wkRet = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
        End Try


        Return wkRet


    End Function

#End Region

#End Region

#Region "***ローカル関数***"

#Region "f_setControlChangeEvents 変更判定イベント登録処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_setControlChangeEvents
    '説明            :変更判定イベント登録処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Sub f_setControlChangeEvents()

        'フォーム上に配置されているすべてのコントロールを列挙
        Dim All_Ctl As Control() = f_GetAllControls(Me)

        For Each wkCtrl As Control In All_Ctl

            Select Case True
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcComboBox
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcComboBox).TextChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcDate
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcDate).ValueChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcMask
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcMask).ValueChanged, AddressOf f_setChanged
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
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Sub f_setChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        loblnTextChange = True

    End Sub
#End Region

#Region "f_ObjectClear 画面クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ObjectClear
    '説明            :画面クリア処理
    '引数            :rKbn(処理区分)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ObjectClear(ByVal wKbn As String) As Boolean
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

        f_ObjectClear = False

        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            pJump = True
            f_ClearFormALL(Me, wKbn)
            pJump = False

            '====初期値設定======================
            lbl_KI.Text = "第" & p4010_KI & "期"
            lbl_KEIYAKUSYA_CD.Text = pCurrentKey.KEIYAKUSYA_CD
            lbl_KEIYAKUSYA_NM.Text = pCurrentKey.KEIYAKUSYA_NAME
            If clsNENDO_KI.pHASSEI_KAISU = 0 Then
                txt_HASSEI_KAISU.Text = Nothing
            Else
                txt_HASSEI_KAISU.Text = clsNENDO_KI.pHASSEI_KAISU
            End If
            lblCOUNT.Text = ""      '2015/10/16　追加

            '申請日の取得
            f_getTT_KOFU_SINSEI_Date()

            'ボタン制御
            If Not f_DtlButton_Enable(False) Then
                Exit Try
            End If

            '明細入力制御
            If Not f_DtlInput_Enable(False) Then
                Exit Try
            End If

            f_ObjectClear = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            clsNENDO_KI = Nothing
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Function
#End Region

#Region "f_Grid_Clear グリッドクリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Grid_Clear
    '説明            :グリッドクリア処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Grid_Clear() As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty

        Try

            '--------------------------------------------------
            '   羽数合計
            '--------------------------------------------------
            '2017/07/21　修正開始
            'num_KOFU_HASU01.Value = Nothing
            'num_KOFU_HASU02.Value = Nothing
            'num_KOFU_HASU03.Value = Nothing
            'num_KOFU_HASU04.Value = Nothing
            'num_KOFU_HASU05.Value = Nothing
            'num_KOFU_HASU06.Value = Nothing
            'num_KOFU_HASU00.Value = Nothing


            'num_KOFU_KIN01.Value = Nothing
            'num_KOFU_KIN02.Value = Nothing
            'num_KOFU_KIN03.Value = Nothing
            'num_KOFU_KIN04.Value = Nothing
            'num_KOFU_KIN05.Value = Nothing
            'num_KOFU_KIN06.Value = Nothing
            'num_KOFU_KIN00.Value = Nothing

            For I = 0 To 11
                DirectCast(Me.Controls("num_KOFU_HASU" & Format(I, "00")), JBD.Gjs.Win.GcNumber).Value = Nothing
                DirectCast(Me.Controls("num_KOFU_KIN" & Format(I, "00")), JBD.Gjs.Win.GcNumber).Value = Nothing
            Next
            '2017/07/21　修正終了

            '--------------------------------------------------
            '   グリッド
            '--------------------------------------------------
            'データセット　クリア
            If Not pDataSet Is Nothing Then
                pDataSet.Clear()
            End If


            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Grid_Set グリッドセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Grid_Set
    '説明            :グリッドセット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Grid_Set(ByVal wKbn As String, ByVal wMEISAI_NO As Integer, ByVal wNOJO_CD As Integer, ByVal wTORI_KBN As Integer) As Boolean
        Dim ret As Boolean = False
        Dim ret1 As Boolean = False
        Dim wSql As String = String.Empty

        Try
            'グリッドが入力不可の場合、スクロールバーが連動しないので、グリッドを入力可能にする
            dgv_Search.Enabled = True

            ''初期処理以外は、画面クリア
            'If wKbn <> "C" Then
            '    ret1 = f_ObjectClear(wKbn)
            'End If


            '--------------------------------------------------
            '   互助金対象羽数合計・焼却・埋却等互助金額合計
            '--------------------------------------------------
            'グリッド用ＳＱＬ　作成
            If Not f_Hasu_SQLMake(wSql) Then
                Exit Try
            End If

            'ＳＱＬ実行
            If Not f_Select_ODP(pDataSet, wSql) Then
                Exit Try
            End If

            '画面に該当データを表示
            With pDataSet.Tables(0)
                If .Rows.Count > 0 Then
                    '2017/07/21　修正開始
                    ''互助金対象羽数合計
                    'num_KOFU_HASU01.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_HASU1")))
                    'num_KOFU_HASU02.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_HASU2")))
                    'num_KOFU_HASU03.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_HASU3")))
                    'num_KOFU_HASU04.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_HASU4")))
                    'num_KOFU_HASU05.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_HASU5")))
                    'num_KOFU_HASU06.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_HASU6")))
                    'num_KOFU_HASU00.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_HASU0")))
                    ''経営支援互助金額合計
                    'num_KOFU_KIN01.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_KIN1")))
                    'num_KOFU_KIN02.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_KIN2")))
                    'num_KOFU_KIN03.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_KIN3")))
                    'num_KOFU_KIN04.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_KIN4")))
                    'num_KOFU_KIN05.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_KIN5")))
                    'num_KOFU_KIN06.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_KIN6")))
                    'num_KOFU_KIN00.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_KIN0")))
                    For I = 0 To 11
                        '互助金対象羽数合計
                        DirectCast(Me.Controls("num_KOFU_HASU" & Format(I, "00")), JBD.Gjs.Win.GcNumber).Value _
                                   = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_HASU" & Format(I, "00"))))
                        '経営支援互助金額合計
                        DirectCast(Me.Controls("num_KOFU_KIN" & Format(I, "00")), JBD.Gjs.Win.GcNumber).Value _
                                   = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_KIN" & Format(I, "00"))))
                    Next
                    '2017/07/21　修正終了
                End If
            End With

            '--------------------------------------------------
            '   グリッド
            '--------------------------------------------------
            'データセット　クリア
            If Not pDataSet Is Nothing Then
                pDataSet.Clear()
            End If

            'グリッド用ＳＱＬ　作成
            wSql = ""
            If Not f_Search_SQLMake(wSql) Then
                Exit Try
            End If

            'ＳＱＬ実行
            If Not f_Select_ODP(pDataSet, wSql) Then
                Exit Try
            End If

            '画面に該当データを表示
            pJump = True                                '2015/10/16　追加
            loblnTextChange = False                     '2015/10/16　追加
            pCurrentRow = 0                             '2015/10/16　追加
            '2015/10/16　追加
            dgv_Search.DataSource = pDataSet.Tables(0)

            '件数表示
            lblCOUNT.Text = dgv_Search.Rows.Count       '2015/10/16　追加

            '--------------------------------------------------
            '   グリッド表示位置
            '--------------------------------------------------
            If wKbn = "" Then
                ret1 = f_GridReDisp(wMEISAI_NO, wNOJO_CD, wTORI_KBN)
            End If

            '--------------------------------------------------
            '   ボタン制御
            '--------------------------------------------------

            If Not f_DtlButton_Enable(False) Then
                Exit Try
            End If
            pJump = False                           '2015/10/16　追加

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            pJump = False                           '2015/10/16　追加
        End Try

        Return ret

    End Function
#End Region

#Region "f_Hasu_SQLMake 合計羽数・合計焼却・埋却等互助金額表示ＳＱＬ作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Hasu_SQLMake
    '説明            :合計羽数・合計焼却・埋却等互助金額表示ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Hasu_SQLMake(ByRef wSql As String) As Boolean
        Dim ret As Boolean = False

        Try
            wSql = "SELECT"
            '2017/07/21　修正開始
            'wSql &= "   SUM( CASE WHEN TORI_KBN = 1 THEN KOFU_HASU ELSE 0 END ) KOFU_HASU1"
            'wSql &= "  ,SUM( CASE WHEN TORI_KBN = 2 THEN KOFU_HASU ELSE 0 END ) KOFU_HASU2"
            'wSql &= "  ,SUM( CASE WHEN TORI_KBN = 3 THEN KOFU_HASU ELSE 0 END ) KOFU_HASU3"
            'wSql &= "  ,SUM( CASE WHEN TORI_KBN = 4 THEN KOFU_HASU ELSE 0 END ) KOFU_HASU4"
            'wSql &= "  ,SUM( CASE WHEN TORI_KBN = 5 THEN KOFU_HASU ELSE 0 END ) KOFU_HASU5"
            'wSql &= "  ,SUM( CASE WHEN TORI_KBN = 6 THEN KOFU_HASU ELSE 0 END ) KOFU_HASU6"
            'wSql &= "  ,SUM( CASE WHEN TORI_KBN BETWEEN 1 AND 6 THEN KOFU_HASU ELSE 0 END ) KOFU_HASU0"

            'wSql &= "  ,SUM( CASE WHEN TORI_KBN = 1 THEN KOFU_KIN ELSE 0 END ) KOFU_KIN1"
            'wSql &= "  ,SUM( CASE WHEN TORI_KBN = 2 THEN KOFU_KIN ELSE 0 END ) KOFU_KIN2"
            'wSql &= "  ,SUM( CASE WHEN TORI_KBN = 3 THEN KOFU_KIN ELSE 0 END ) KOFU_KIN3"
            'wSql &= "  ,SUM( CASE WHEN TORI_KBN = 4 THEN KOFU_KIN ELSE 0 END ) KOFU_KIN4"
            'wSql &= "  ,SUM( CASE WHEN TORI_KBN = 5 THEN KOFU_KIN ELSE 0 END ) KOFU_KIN5"
            'wSql &= "  ,SUM( CASE WHEN TORI_KBN = 6 THEN KOFU_KIN ELSE 0 END ) KOFU_KIN6"
            'wSql &= "  ,SUM( CASE WHEN TORI_KBN BETWEEN 1 AND 6 THEN KOFU_KIN ELSE 0 END ) KOFU_KIN0"
            For I = 1 To 11
                wSql &= "  SUM( CASE WHEN TORI_KBN = " & I & " THEN KOFU_HASU ELSE 0 END ) KOFU_HASU" & Format(I, "00") & ","
                wSql &= "  SUM( CASE WHEN TORI_KBN = " & I & " THEN KOFU_KIN  ELSE 0 END ) KOFU_KIN" & Format(I, "00") & ","
            Next
            wSql &= "  SUM( KOFU_HASU ) KOFU_HASU00,"
            wSql &= "  SUM( KOFU_KIN ) KOFU_KIN00"
            '2017/07/21　修正終了
            wSql &= " FROM TT_KOFU_SINSEI"
            wSql &= " WHERE"
            '               --条件
            wSql &= "       KI = " & p4010_KI
            wSql &= "   AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "   AND HASSEI_KAISU = " & txt_HASSEI_KAISU.Text.Trim
            wSql &= "   AND GOJOKIN_SYURUI_KBN = 2"

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Search_SQLMake グリッド表示ＳＱＬ作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :グリッド表示ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Search_SQLMake(ByRef wSql As String) As Boolean
        Dim ret As Boolean = False

        Try
            wSql = "SELECT"
            wSql &= "   NOJO.MEISAI_NO AS MEISAI_NO"
            wSql &= "  ,NOJO.NOJO_NAME AS NOJO_NAME"
            wSql &= "  ,NOJO.ADDR_1||NOJO.ADDR_2||NOJO.ADDR_3||NOJO.ADDR_4 AS ADDR"
            wSql &= "  ,JOHO.TORI_KBN AS TORI_KBN"
            wSql &= "  ,M07.RYAKUSYO AS TORI_KBN_NM"
            wSql &= "  ,SIN.HASSEI_KAISU AS HASSEI_KAISU"
            wSql &= "  ,SIN.KEISAN_KAISU AS KEISAN_KAISU"
            wSql &= "  ,SIN.SYORI_JOKYO_KBN AS SYORI_JOKYO_KBN"
            wSql &= "  ,SIN.SYORI_JOKYO_KBN_NM AS SYORI_JOKYO_KBN_NM"
            wSql &= "  ,TO_CHAR(SIN.KOFU_HASU , '999,999,999,999') AS KOFU_HASU"
            wSql &= "  ,SIN.GENGAKU_RITU AS GENGAKU_RITU" '2022/01/24 JBD9020 減額率追加 ADD
            wSql &= "  ,TO_CHAR(SIN.KOFU_KIN , '999,999,999,999') AS KOFU_KIN"
            wSql &= "  ,TO_CHAR(SIN.SEI_TUMITATE_KIN , '999,999,999,999') AS SEI_TUMITATE_KIN"
            wSql &= "  ,TO_CHAR(SIN.KUNI_KOFU_KIN , '999,999,999,999') AS KUNI_KOFU_KIN"
            wSql &= "  ,NOJO.NOJO_CD AS NOJO_CD"
            wSql &= "  ,DECODE(NOJO.ADDR_POST, NULL, '', (SUBSTR(NOJO.ADDR_POST,1,3) || '-' || SUBSTR(NOJO.ADDR_POST,4,4))) AS ADDR_POST "
            wSql &= "  ,NOJO.ADDR_1 AS ADDR_1"
            wSql &= "  ,NOJO.ADDR_2 AS ADDR_2"
            wSql &= "  ,NOJO.ADDR_3 AS ADDR_3"
            wSql &= "  ,NOJO.ADDR_4 AS ADDR_4"
            wSql &= "  ,TO_CHAR(JOHO.KEIYAKU_HASU , '999,999,999,999') AS KEIYAKU_HASU"
            wSql &= "  ,JOHO.KI AS KI"
            wSql &= "  ,JOHO.KEIYAKUSYA_CD AS KEIYAKUSYA_CD"
            wSql &= "  ,SIN.KOFU_RITU AS KOFU_RITU" '2022/01/24 JBD9020 交付率追加 ADD
            wSql &= " FROM TT_KEIYAKU_JOHO JOHO"
            wSql &= "     ,TM_KEIYAKU_NOJO NOJO"
            wSql &= "     ,("
            wSql &= "      SELECT"
            wSql &= "          KI"
            wSql &= "         ,KEIYAKUSYA_CD"
            wSql &= "         ,NOJO_CD"
            wSql &= "         ,TORI_KBN"
            wSql &= "         ,HASSEI_KAISU"
            wSql &= "         ,KEISAN_KAISU"
            wSql &= "         ,SYORI_JOKYO_KBN"
            wSql &= "         ,M13.MEISYO AS SYORI_JOKYO_KBN_NM"
            wSql &= "         ,KOFU_HASU"
            wSql &= "         ,GENGAKU_RITU" '2022/01/24 JBD9020 減額率追加 ADD
            wSql &= "         ,KOFU_RITU" '2022/01/24 JBD9020 減額率追加 ADD
            wSql &= "         ,KOFU_KIN"
            wSql &= "         ,SEI_TUMITATE_KIN"
            wSql &= "         ,KUNI_KOFU_KIN"
            wSql &= "      FROM TT_KOFU_SINSEI"
            wSql &= "          ,TM_CODE M13"
            wSql &= "      WHERE"
            '                    -- 互助金情報入力状況
            wSql &= "            SYORI_JOKYO_KBN = M13.MEISYO_CD"
            wSql &= "        AND 13 = M13.SYURUI_KBN"
            '                    --条件
            wSql &= "        AND KI = " & p4010_KI
            wSql &= "        AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "        AND HASSEI_KAISU = " & txt_HASSEI_KAISU.Text.Trim
            wSql &= "        AND GOJOKIN_SYURUI_KBN = 2"
            wSql &= "      ) SIN"
            wSql &= "     ,TM_CODE M07"
            wSql &= " WHERE"
            '           -- 契約者農場マスタ
            wSql &= "       JOHO.KI = NOJO.KI(+)"
            wSql &= "   AND JOHO.KEIYAKUSYA_CD = NOJO.KEIYAKUSYA_CD(+)"
            wSql &= "   AND JOHO.NOJO_CD = NOJO.NOJO_CD(+)"
            '           -- 互助金申請
            wSql &= "   AND JOHO.KI = SIN.KI(+)"
            wSql &= "   AND JOHO.KEIYAKUSYA_CD = SIN.KEIYAKUSYA_CD(+)"
            wSql &= "   AND JOHO.NOJO_CD = SIN.NOJO_CD(+)"
            wSql &= "   AND JOHO.TORI_KBN = SIN.TORI_KBN(+)"
            '           -- 鶏の種類
            wSql &= "   AND JOHO.TORI_KBN = M07.MEISYO_CD"
            wSql &= "   AND 7 = M07.SYURUI_KBN"
            '           -- 条件
            wSql &= "  AND JOHO.KI = " & p4010_KI
            wSql &= "  AND JOHO.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND JOHO.DATA_FLG = 1"
            wSql &= " ORDER BY"
            wSql &= "      JOHO.KI"
            wSql &= "     ,JOHO.KEIYAKUSYA_CD"
            wSql &= "     ,NOJO.MEISAI_NO"
            wSql &= "     ,NOJO.NOJO_CD"
            wSql &= "     ,JOHO.TORI_KBN"

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_GridReDisp グリッド再表示"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridReDisp
    '説明            :グリッド再表示
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_GridReDisp(ByVal wMEISAI_NO As Integer, ByVal wNOJO_CD As Integer, ByVal wTORI_KBN As Integer) As Boolean
        Dim ret As Boolean = False
        Dim blnHit As Boolean = False

        Try
            dgv_Search.Enabled = True
            'グリッドに有効データあり
            If dgv_Search.RowCount <> 0 Then

                '更新対象のデータ　または　その次のデータに、カーソルをせっと
                For i As Integer = 0 To dgv_Search.RowCount - 1
                    '明細番号ブレーク
                    If CInt(WordHenkan("N", "Z", dgv_Search.Item("MEISAI_NO", i).Value)) > wMEISAI_NO Then
                        '現在セル　セット
                        dgv_Search.CurrentCell = dgv_Search(0, i)
                        blnHit = True
                        Exit For
                    ElseIf CInt(WordHenkan("N", "Z", dgv_Search.Item("MEISAI_NO", i).Value)) = wMEISAI_NO Then
                        '明細番号が同一で、農場コードブレーク
                        If CInt(WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD", i).Value)) > wNOJO_CD Then
                            '現在セル　セット
                            dgv_Search.CurrentCell = dgv_Search(0, i)
                            blnHit = True
                            Exit For
                        ElseIf CInt(WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD", i).Value)) = wNOJO_CD Then
                            '明細番号、農場コードが同一で、鶏種類ブレーク
                            If CInt(WordHenkan("N", "Z", dgv_Search.Item("TORI_KBN", i).Value)) >= wTORI_KBN Then
                                '現在セル　セット
                                dgv_Search.CurrentCell = dgv_Search(0, i)
                                blnHit = True
                                Exit For
                            End If
                        End If
                    End If
                Next

                '最後まで該当データがなかった場合、最終行
                If Not blnHit Then
                    dgv_Search.CurrentCell = dgv_Search(0, dgv_Search.RowCount - 1)
                End If

            End If

            ret = True

        Catch ex As Exception
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_DtlClear 明細クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_DtlClear
    '説明            :明細クリア処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_DtlClear() As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty

        Try

            '明細
            lbl_NOJO_CD.Text = ""
            lbl_NOJO_NAME.Text = ""
            lbl_ADDR_POST.Text = ""
            lbl_ADDR_1.Text = ""
            lbl_ADDR_2.Text = ""
            lbl_ADDR_3.Text = ""
            lbl_ADDR_4.Text = ""

            lbl_TORI_KBN.Text = ""
            lbl_TORI_KBN_NM.Text = ""
            lbl_KEIYAKU_HASU.Text = ""

            num_KOFU_HASU_NYU.Value = Nothing

            num_KOFU_HASU_DISP.Value = Nothing
            num_KOFU_TANKA.Value = Nothing
            num_MARU1.Value = Nothing

            num_SYOKYAKU_KEIHI.Value = Nothing
            num_KUNI_KOFUKIN.Value = Nothing
            num_MARU2.Value = Nothing

            num_KOME1.Value = Nothing

            num_MARU3_DISP1.Value = Nothing
            num_KOME3_CALC.Value = Nothing

            num_MARU3_DISP2.Value = Nothing
            num_KOME3_DISP2.Value = Nothing
            num_MARU5.Value = Nothing

            num_MARU6.Value = Nothing

            rbtnSYORI_JOKYO_KBN_1.Checked = False
            rbtnSYORI_JOKYO_KBN_2.Checked = False
            rbtnSYORI_JOKYO_KBN_3.Checked = False
            dateKOFU_KAKUTEI_Ymd.Value = Nothing

            '2022/02/01 JBD9020 減額率交付率追加 ADD START
            num_GENGAKU_RITU.Value = Nothing
            num_KOME2.Value = Nothing
            num_MARU3_CALC.Value = Nothing
            num_KOME3_DISP1.Value = Nothing
            num_KOFU_RITU.Value = Nothing
            num_MARU4.Value = Nothing
            '2022/02/01 JBD9020 減額率交付率追加 ADD END

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_SetForm_Data 初期画面表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_Data
    '説明            :画面表示
    '引数            :intetegr  選択行番号
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_Data(ByVal intSelectRow As Integer) As Boolean
        Dim ret As Boolean = False
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim wNOJO_CD As Integer = 0
        Dim wTORI_KBN As Integer = 0
        Dim wEditKbn As Boolean = True

        Try

            pJump = True

            'フォームロード時のみ
            'ヘッダ表示
            If Not f_DtlSet(intSelectRow) Then
                Exit Try
            End If

            '処理状況チェック
            If WordHenkan("N", "Z", dgv_Search.Item("SYORI_JOKYO_KBN", intSelectRow).Value) = 4 Then
                Show_MessageBox_Add("W019", "交付金計算済みのため修正できません。")
                wEditKbn = False
            End If

            '交付金計算済みチェック
            Dim intCnt As Integer
            f_TT_KOFU_Check(intCnt)
            If intCnt > 0 Then
                If wEditKbn Then
                    Show_MessageBox_Add("W019", "交付金計算済みのため追加できません。")
                End If
                wEditKbn = False
            End If


            'キー情報退避
            wNOJO_CD = WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD", intSelectRow).Value)
            wTORI_KBN = WordHenkan("N", "Z", dgv_Search.Item("TORI_KBN", intSelectRow).Value)

            '焼却・埋却等単価の取得
            If Not f_SetForm_TM_TANKA(wTORI_KBN) Then
                Exit Try
            End If

            '2022/02/01 JBD9020 減額率交付率追加 ADD START
            If Not f_SetForm_KOFU_RITU() Then
                Exit Try
            End If
            '2022/02/01 JBD9020 減額率交付率追加 ADD END

            '処理状況チェック
            If WordHenkan("N", "Z", dgv_Search.Item("SYORI_JOKYO_KBN", intSelectRow).Value) = 0 Then
                '新規
                lbl_SYORI_JOKYO_KBN_NM.Text = ""
                rbtnSYORI_JOKYO_KBN_1.Checked = True
                dateKOFU_KAKUTEI_Ymd.Enabled = False
                num_KOFU_RITU.Value = pKofuRitu '2022/01/28 JBD9020 減額率交付率追加 ADD
            Else
                '更新
                '互助申請の取得
                If Not f_SetForm_TT_KOFU_SINSEI(wNOJO_CD, wTORI_KBN) Then
                    Exit Try
                End If
                '2022/01/28 JBD9020 減額率交付率追加 ADD START
                If num_KOFU_RITU.Value <> pKofuRitu And lbl_SYORI_JOKYO_KBN_NM.Text = "" Then
                    If Show_MessageBox_Add("Q012", "マスタに登録されている交付率と異なります。再計算を行いますか？") = DialogResult.Yes Then
                        num_KOFU_RITU.Value = pKofuRitu
                        pBlnChange = True
                    End If
                End If
                '2022/01/28 JBD9020 減額率交付率追加 ADD END
            End If

            '初期コントロールにフォーカスセット
            num_KOFU_HASU_NYU.Focus()

            '--------------------------------------------------
            '   ボタン制御
            '--------------------------------------------------
            If Not f_DtlInput_Enable(wEditKbn) Then
                Exit Try
            End If

            If Not f_DtlButton_Enable(wEditKbn) Then
                Exit Try
            End If

            'フラグ　クリア
            loblnTextChange = False
            pJump = False
            pCurrentRow = intSelectRow      '2017/07/21　追加

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_SetForm_TM_TANKA 契約者積立金・互助金単価マスタの取得表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TM_TANKA
    '説明            :契約者積立金・互助金単価マスタの取得表示処理
    '引数            :鶏の種類区分
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_TM_TANKA(ByVal wTORI_KBN As Integer) As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty
        Dim wDS As New DataSet

        Try

            '--------------------------------------------------
            '   契約者積立金・互助金単価マスタの取得
            '--------------------------------------------------
            '契約者積立金・互助金単価マスタ用ＳＱＬ　作成
            wSql = "SELECT"
            wSql &= "     TNK.SYOKYAKU_TANKA"
            wSql &= "	 ,TNK.TAISYO_DATE_FROM"
            wSql &= "    ,TNK.TAISYO_DATE_TO"
            wSql &= " FROM"
            wSql &= "     TM_TANKA TNK"
            wSql &= " WHERE"
            '             --条件
            wSql &= "     TNK.KEIYAKU_KBN = " & pCurrentKey.KEIYAKU_KBN
            wSql &= " AND TNK.TORI_KBN = " & wTORI_KBN
            wSql &= " AND (   TNK.TAISYO_DATE_FROM <= TO_DATE('" & pCurrentKey.TANKA_MST_DATE & "','yyyy/mm/dd')"
            wSql &= "     AND TNK.TAISYO_DATE_TO   >= TO_DATE('" & pCurrentKey.TANKA_MST_DATE & "','yyyy/mm/dd')"
            wSql &= "     )"

            'ＳＱＬ実行
            If Not f_Select_ODP(wDS, wSql) Then
                Exit Try
            End If

            '画面に該当データを表示
            With wDS.Tables(0)
                If .Rows.Count > 0 Then
                    '基礎指標
                    num_KOFU_TANKA.Value = CLng(WordHenkan("N", "Z", .Rows(0)("SYOKYAKU_TANKA")))
                End If
            End With

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
        End Try

        Return ret

    End Function

#End Region

#Region "f_SetForm_KOFU_RITU 契約者積立金・交付率の取得表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_KOFU_RITU
    '説明            :交付率の取得表示処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '2022/02/01 JBD9020 減額率交付率追加 ADD
    '------------------------------------------------------------------
    Private Function f_SetForm_KOFU_RITU() As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty
        Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

        Try

            '--------------------------------------------------
            '   契約者積立金・互助金単価マスタの取得
            '--------------------------------------------------
            '契約者積立金・互助金単価マスタ用ＳＱＬ　作成
            wSql = "SELECT"
            wSql &= "    TNK.KOFU_RITU"
            wSql &= " FROM"
            wSql &= "     TM_TANKA TNK"
            wSql &= " WHERE"
            '             --条件
            wSql &= "     TNK.KEIYAKU_KBN = 9"
            wSql &= " AND TNK.TORI_KBN = 9"
            wSql &= " AND (   TNK.TAISYO_DATE_FROM <= TO_DATE('" & pCurrentKey.TANKA_MST_DATE & "','yyyy/mm/dd')"
            wSql &= "     AND TNK.TAISYO_DATE_TO   >= TO_DATE('" & pCurrentKey.TANKA_MST_DATE & "','yyyy/mm/dd')"
            wSql &= "     )"

            'ＳＱＬ実行
            If Not f_Select_ODP(pDataSet, wSql) Then
                Exit Try
            End If

            '画面に該当データを表示
            With pDataSet.Tables(0)
                If .Rows.Count > 0 Then
                    '基礎指標
                    pKofuRitu = CDbl(WordHenkan("N", "Z", .Rows(0)("KOFU_RITU")))
                End If
            End With

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

#Region "f_SetForm_TT_KOFU_SINSEI 互助交付申請の取得表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TT_KOFU_SINSEI
    '説明            :互助交付申請の取得表示処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_TT_KOFU_SINSEI(ByVal wNOJO_CD As Integer, ByVal wTORI_KBN As Integer) As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty
        Dim wDS As New DataSet

        Try

            '--------------------------------------------------
            '   互助交付申請の取得
            '--------------------------------------------------
            '互助交付申請の取得用ＳＱＬ　作成
            wSql = "SELECT"
            wSql &= "      SIN.SYORI_JOKYO_KBN"
            wSql &= "     ,M13.MEISYO AS SYORI_JOKYO_KBN_NM"
            wSql &= "     ,SIN.SYOKYAKU_KEIHI"
            wSql &= "     ,SIN.KUNI_KOFUKIN"
            wSql &= "     ,SIN.KOFU_TANKA"
            wSql &= "     ,SIN.KOFU_KAKUTEI_DATE"
            wSql &= "     ,SIN.KOFU_HASU"
            wSql &= "     ,SIN.SEI_TUMITATE_KIN"
            wSql &= "     ,SIN.KUNI_KOFU_KIN"
            wSql &= "     ,SIN.KOFU_KIN"
            '2022/01/28 JBD9020 減額率交付率追加 ADD START
            wSql &= "     ,SIN.SANTEI_KIN"
            wSql &= "     ,SIN.GENGAKU_RITU"
            wSql &= "     ,SIN.KOFU_RITU"
            '2022/01/28 JBD9020 減額率交付率追加 ADD END
            wSql &= " FROM TT_KOFU_SINSEI SIN"
            wSql &= "     ,TM_CODE M13"
            wSql &= " WHERE"
            '              -- 互助金情報入力状況
            wSql &= "      SYORI_JOKYO_KBN = M13.MEISYO_CD"
            wSql &= "  AND 13 = M13.SYURUI_KBN"
            '              -- 条件
            wSql &= "  AND SIN.KI = " & p4010_KI
            wSql &= "  AND SIN.HASSEI_KAISU = " & txt_HASSEI_KAISU.Text
            wSql &= "  AND SIN.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND SIN.GOJOKIN_SYURUI_KBN = 2"
            wSql &= "  AND SIN.NOJO_CD = " & wNOJO_CD
            wSql &= "  AND SIN.TORI_KBN= " & wTORI_KBN

            'ＳＱＬ実行
            If Not f_Select_ODP(wDS, wSql) Then
                Exit Try
            End If

            '画面に該当データを表示
            With wDS.Tables(0)
                If .Rows.Count > 0 Then
                    '互助金申請
                    num_KOFU_HASU_NYU.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_HASU")))
                    num_SYOKYAKU_KEIHI.Value = CLng(WordHenkan("N", "Z", .Rows(0)("SYOKYAKU_KEIHI")))
                    num_KUNI_KOFUKIN.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KUNI_KOFUKIN")))
                    If .Rows(0)("KOFU_KAKUTEI_DATE") Is DBNull.Value Then
                        dateKOFU_KAKUTEI_Ymd.Value = Nothing
                    Else
                        dateKOFU_KAKUTEI_Ymd.Value = CDate(.Rows(0)("KOFU_KAKUTEI_DATE"))
                    End If
                    num_KOFU_TANKA.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_TANKA")))
                    num_KOFU_HASU_NYU.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_HASU")))
                    '2022/02/01 JBD9020 減額率交付率追加 UPD START
                    'num_KOME3_CALC.Value = CLng(WordHenkan("N", "Z", .Rows(0)("SEI_TUMITATE_KIN")))
                    num_KOME1.Value = CLng(WordHenkan("N", "Z", .Rows(0)("SANTEI_KIN")))
                    num_MARU4.Value = CLng(WordHenkan("N", "Z", .Rows(0)("SEI_TUMITATE_KIN")))
                    num_GENGAKU_RITU.Value = CLng(WordHenkan("N", "Z", .Rows(0)("GENGAKU_RITU")))
                    num_KOFU_RITU.Value = CDbl(WordHenkan("N", "Z", .Rows(0)("KOFU_RITU")))
                    '2022/02/01 JBD9020 減額率交付率追加 UPD END
                    num_MARU5.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KUNI_KOFU_KIN")))
                    num_MARU6.Value = CLng(WordHenkan("N", "Z", .Rows(0)("KOFU_KIN")))

                    '交付金計算済の判定
                    If CLng(WordHenkan("N", "Z", .Rows(0)("SYORI_JOKYO_KBN"))) = 4 Then
                        lbl_SYORI_JOKYO_KBN_NM.Text = WordHenkan("N", "Z", .Rows(0)("SYORI_JOKYO_KBN_NM"))
                        '入力明細制御
                        If Not f_DtlInput_Enable(False) Then
                            Exit Try
                        End If

                        'ボタン制御
                        If Not f_DtlButton_Enable(False) Then
                            Exit Try
                        End If
                    Else
                        lbl_SYORI_JOKYO_KBN_NM.Text = ""
                        '処理状況オプションの設定
                        If CLng(WordHenkan("N", "Z", .Rows(0)("SYORI_JOKYO_KBN"))) = 1 Then
                            '入力中
                            rbtnSYORI_JOKYO_KBN_1.Checked = True
                            dateKOFU_KAKUTEI_Ymd.Enabled = False
                        ElseIf CLng(WordHenkan("N", "Z", .Rows(0)("SYORI_JOKYO_KBN"))) = 2 Then
                            '審査中
                            rbtnSYORI_JOKYO_KBN_2.Checked = True
                            dateKOFU_KAKUTEI_Ymd.Enabled = False
                        ElseIf CLng(WordHenkan("N", "Z", .Rows(0)("SYORI_JOKYO_KBN"))) = 3 Then
                            '交付確定
                            rbtnSYORI_JOKYO_KBN_3.Checked = True
                            dateKOFU_KAKUTEI_Ymd.Enabled = True
                        End If
                    End If
                End If
            End With

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
        End Try

        Return ret

    End Function

#End Region

#Region "f_DtlSet 明細セット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_DtlSet
    '説明            :明細セット処理
    '引数            :row as int
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_DtlSet(ByVal intRow As Integer) As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty

        Try

            '明細
            f_DtlClear()
            lbl_NOJO_CD.Text = WordHenkan("N", "S", dgv_Search.Item("NOJO_CD", intRow).Value)
            lbl_NOJO_NAME.Text = WordHenkan("N", "S", dgv_Search.Item("NOJO_NAME", intRow).Value)
            lbl_ADDR_POST.Text = WordHenkan("N", "S", dgv_Search.Item("ADDR_POST", intRow).Value)
            lbl_ADDR_1.Text = WordHenkan("N", "S", dgv_Search.Item("ADDR_1", intRow).Value)
            lbl_ADDR_2.Text = WordHenkan("N", "S", dgv_Search.Item("ADDR_2", intRow).Value)
            lbl_ADDR_3.Text = WordHenkan("N", "S", dgv_Search.Item("ADDR_3", intRow).Value)
            lbl_ADDR_4.Text = WordHenkan("N", "S", dgv_Search.Item("ADDR_4", intRow).Value)
            lbl_TORI_KBN.Text = WordHenkan("N", "S", dgv_Search.Item("TORI_KBN", intRow).Value)
            lbl_TORI_KBN_NM.Text = WordHenkan("N", "S", dgv_Search.Item("TORI_KBN_NM", intRow).Value)

            lbl_KEIYAKU_HASU.Text = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_HASU", intRow).Value)

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_DtlButton_Enable ボタン制御"
    '------------------------------------------------------------------
    'プロシージャ名  :f_DtlButton_Enable
    '説明            :明細ボタン制御
    '引数            :Boolean
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_DtlButton_Enable(ByVal wEnable As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            'ボタン
            cmdSave.Enabled = wEnable
            cmdDel.Enabled = wEnable
            cmdCansel.Enabled = wEnable

            If dgv_Search.RowCount > 0 Then
                cmdDel.Enabled = True
                cmdSearch.Enabled = False
            Else
                cmdDel.Enabled = False
                cmdSearch.Enabled = True
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_DtlInput_Enable 明細入力制御"
    '------------------------------------------------------------------
    'プロシージャ名  :f_DtlInput_Enable
    '説明            :明細入力制御
    '引数            :Boolean
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_DtlInput_Enable(ByVal wEnable As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            '明細入力

            If wEnable Then
                num_KOFU_HASU_NYU.ReadOnly = False
                num_SYOKYAKU_KEIHI.ReadOnly = False
                num_KUNI_KOFUKIN.ReadOnly = False
            Else
                num_KOFU_HASU_NYU.ReadOnly = True
                num_SYOKYAKU_KEIHI.ReadOnly = True
                num_KUNI_KOFUKIN.ReadOnly = True
            End If


            rbtnSYORI_JOKYO_KBN_1.Enabled = wEnable
            rbtnSYORI_JOKYO_KBN_2.Enabled = wEnable
            rbtnSYORI_JOKYO_KBN_3.Enabled = wEnable

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Input_Check  画面入力チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check
    '説明            :画面入力チェック処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check(ByVal wKbn As String) As Boolean
        Dim ret As Boolean = False
        Dim wkControl As Control
        Dim wkControlName As String

        Try

            '==必須チェック==================
            '2022/02/01 JBD9020 発生回数→認定回数に変更 UPD START
            wkControlName = "認定回数"
            '2022/02/01 JBD9020 発生回数→認定回数に変更 UPD END
            wkControl = txt_HASSEI_KAISU
            If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "申請日"
            If dateSINSEI_DATE.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : dateSINSEI_DATE.Focus() : Exit Try
            End If


            '保存時チェック
            If wKbn = "S" Then
                wkControlName = "互助金交付対象羽数"
                If num_KOFU_HASU_NYU.Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : num_KOFU_HASU_NYU.Focus() : Exit Try
                End If
                wkControlName = "焼却等経費"
                If num_SYOKYAKU_KEIHI.Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : num_SYOKYAKU_KEIHI.Focus() : Exit Try
                End If
                wkControlName = "国交付金（家伝法２１条）"
                If num_KUNI_KOFUKIN.Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : num_KUNI_KOFUKIN.Focus() : Exit Try
                End If
                '2022/02/01 JBD9020 減額率交付率追加 ADD START
                wkControlName = "家伝法違反減額率"
                If num_GENGAKU_RITU.Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : num_GENGAKU_RITU.Focus() : Exit Try
                End If
                wkControlName = "互助金交付率"
                If num_KOFU_RITU.Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : num_KOFU_RITU.Focus() : Exit Try
                End If
                '2022/02/01 JBD9020 減額率交付率追加 ADD END
            End If


            '==FromToチェック==================

            '==いろいろチェック==================
            '交付確定時の確定年月日チェック
            If rbtnSYORI_JOKYO_KBN_3.Checked Then
                wkControlName = "確定年月日"
                If dateKOFU_KAKUTEI_Ymd.Value Is Nothing Then
                    Call Show_MessageBox_Add("W008", wkControlName) : dateKOFU_KAKUTEI_Ymd.Focus() : Exit Try
                End If
            End If

            '②焼却等経費
            If Not num_MARU2.Value Is Nothing AndAlso num_MARU2.Value < 0 Then
                wkControlName = "②焼却等経費"
                Call Show_MessageBox_Add("I007", "②焼却等経費の計算値が０未満になっています。") : num_SYOKYAKU_KEIHI.Focus() : Exit Try
            End If


            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_getTT_KOFU_SINSEI_Date 申請日の取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_getTT_KOFU_SINSEI_Date
    '説明            申請日の取得
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_getTT_KOFU_SINSEI_Date() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty


        Try

            '#100 UPD START
            '発生回数の有無
            If txt_HASSEI_KAISU.Text = "" Then
                'システム日
                dateSINSEI_DATE.Value = Format(Now, "yyyy/MM/dd")
            Else

                'ＳＱＬ
                wSql = ""

                '==SQL作成====================
                wSql &= " SELECT"
                wSql &= "      SIN.SINSEI_DATE AS SINSEI_DATE"
                wSql &= " FROM TT_KOFU_SINSEI SIN"
                wSql &= " WHERE SIN.KI = " & p4010_KI
                wSql &= "  AND SIN.HASSEI_KAISU = " & txt_HASSEI_KAISU.Text
                wSql &= "  AND SIN.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD

                'SQL実行
                If Not f_Select_ODP(wkDS, wSql) Then
                    Exit Try
                End If

                'グリッドセット
                If wkDS.Tables(0).Rows.Count > 0 Then
                    '申請日
                    If wkDS.Tables(0).Rows(0)("SINSEI_DATE") Is DBNull.Value Then
                        'システム日
                        dateSINSEI_DATE.Value = Format(Now, "yyyy/MM/dd")
                    Else
                        dateSINSEI_DATE.Value = Format(wkDS.Tables(0).Rows(0)("SINSEI_DATE"), "yyyy/MM/dd")
                    End If
                Else
                    'システム日
                    dateSINSEI_DATE.Value = Format(Now, "yyyy/MM/dd")
                End If
            End If
            '#100 UPD END
            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_TT_KOFU_Check 交付金計算済みチェック"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TT_KOFU_Check
    '説明            交付金計算済みチェック
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TT_KOFU_Check(ByRef intCnt As Integer) As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty


        Try

            'ＳＱＬ
            wSql = ""
            intCnt = 0

            '==SQL作成====================
            wSql &= " SELECT"
            wSql &= "       KOFU.SYORI_JOKYO"
            wSql &= " FROM  TT_KOFU KOFU"
            wSql &= " WHERE KOFU.KI = " & p4010_KI
            wSql &= "   AND KOFU.HASSEI_KAISU = " & txt_HASSEI_KAISU.Text
            wSql &= "   AND KOFU.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD


            'SQL実行
            If Not f_Select_ODP(wkDS, wSql) Then
                Exit Try
            End If

            'グリッドセット
            intCnt = wkDS.Tables(0).Rows.Count

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_MidB メソッド (文字列、開始位置、抽出文字数)　"
    ''' -----------------------------------------------------------------------------------------
    ''' <summary>
    '''     文字列の指定されたバイト位置から、指定されたバイト数分の文字列を返します。</summary>
    ''' <param name="stTarget">
    '''     取り出す元になる文字列。</param>
    ''' <param name="iStart">
    '''     取り出しを開始する位置。</param>
    ''' <param name="iByteSize">
    '''     取り出すバイト数。</param>
    ''' <returns>
    '''     指定されたバイト位置から指定されたバイト数分の文字列。</returns>
    ''' -----------------------------------------------------------------------------------------
    Public Function f_MidB _
    (ByVal stTarget As String, ByVal iStart As Integer, ByVal iByteSize As Integer) As String
        Dim hEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncoding.GetBytes(stTarget)

        Try
            If iStart <= btBytes.Length Then
                '開始位置から、抽出文字数の文字列を返します
                If iStart + iByteSize - 1 <= btBytes.Length Then
                    Return hEncoding.GetString(btBytes, iStart - 1, iByteSize)
                Else
                    Return hEncoding.GetString(btBytes, iStart - 1, btBytes.Length - iStart + 1)
                End If
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            Return ""
        End Try

    End Function
#End Region

#End Region

    Private Sub dgv_Search_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Search.CellContentClick

    End Sub

    Private Sub dgv_Search_RowErrorTextChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_Search.RowErrorTextChanged

    End Sub
End Class
