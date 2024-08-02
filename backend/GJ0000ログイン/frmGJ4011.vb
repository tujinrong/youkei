'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ4011.vb
'*
'*　　②　機能概要　　　　　互助金申請情報入力（経営支援登録）
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

Public Class frmGJ4011

#Region "***変数定義***"

    ''' <summary>
    ''' 固定項目
    ''' </summary>
    ''' <remarks></remarks>
    Property p4010_KI As Integer

    ''' <summary>
    ''' 処理状況
    ''' </summary>
    ''' <remarks></remarks>
    Property pLoadErr As Boolean

    ''' <summary>
    ''' グリッドキー項目構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T_KEY_PARAM

        ''' <summary>
        ''' 明細番号
        ''' </summary>
        ''' <remarks></remarks>
        Public MEISAI_NO As String = String.Empty

        ''' <summary>
        ''' 農場コード
        ''' </summary>
        ''' <remarks></remarks>
        Public NOJO_CD As String = String.Empty

        ''' <summary>
        ''' 農場名
        ''' </summary>
        ''' <remarks></remarks>
        Public NOJO_NAME As String = String.Empty

        ''' <summary>
        ''' 鶏の種類コード
        ''' </summary>
        ''' <remarks></remarks>
        Public TORI_KBN As String = String.Empty

        ''' <summary>
        ''' 鶏の種類名
        ''' </summary>
        ''' <remarks></remarks>
        Public TORI_KBN_NM As String = String.Empty

        ''' <summary>
        ''' 契約羽数
        ''' </summary>
        ''' <remarks></remarks>
        Public KEIYAKU_HASU As String = String.Empty

        ''' <summary>
        ''' 住所1
        ''' </summary>
        ''' <remarks></remarks>
        Public ADDR_1 As String = String.Empty

        ''' <summary>
        ''' 住所2
        ''' </summary>
        ''' <remarks></remarks>
        Public ADDR_2 As String = String.Empty

        ''' <summary>
        ''' 住所3
        ''' </summary>
        ''' <remarks></remarks>
        Public ADDR_3 As String = String.Empty

        ''' <summary>
        ''' 住所4
        ''' </summary>
        ''' <remarks></remarks>
        Public ADDR_4 As String = String.Empty

        ''' <summary>
        ''' 発生回数
        ''' </summary>
        ''' <remarks></remarks>
        Public HASSEI_KAISU As String = String.Empty

        ''' <summary>
        ''' 申請日
        ''' </summary>
        ''' <remarks></remarks>
        Public SINSEI_DATE As String = String.Empty

        ''' <summary>
        ''' 編集フラグ
        ''' </summary>
        ''' <remarks></remarks>
        Public EDIT_KBN As Boolean = True
    End Class

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
    '契約情報


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
            pJump = True
            ret = f_ObjectClear("C")
            pJump = False

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
            If Not f_Input_Check() Then
                Exit Try
            End If

            '検索処理
            If Not f_Grid_Set("S", 0, 0, 0) Then
                Exit Try
            End If

            'ボタン制御
            If Not f_DtlButton_Enable(True) Then
                Exit Try
            End If

            '★初期コントロールにフォーカスセット
            dgv_Search.Focus()

            '該当データ取得
            If dgv_Search.SelectedRows.Count > 0 Then
                '明細セット
                f_DtlSet(0)
            End If

            loblnTextChange = False      '画面入力内容変更フラグクリア JBD9020 R3減額対応 2022/02/24 ADD

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdMeisa_Click 互助金明細入力ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdMeisa_Click
    '説明            :互助金明細入力ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdMeisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMeisai.Click
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim numSelectRowIdx As Integer
        Dim wStr As String = String.Empty
        Dim wMEISAI_NO As Integer = 0
        Dim wNOJO_CD As Integer = 0
        Dim wTORI_KBN As Integer = 0
        Dim ret As Boolean = False
        Dim wEditKbn As Boolean = True



        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '入力チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

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
                Show_MessageBox_Add("W019", "交付金計算済みのため修正できません。")
                wEditKbn = False
                'Exit Try
            End If

            '交付金計算済みチェック
            Dim intCnt As Integer
            f_TT_KOFU_Check(intCnt)
            If intCnt > 0 Then
                If wEditKbn Then
                    Show_MessageBox_Add("W019", "交付金計算済みのため追加できません。")
                End If
                wEditKbn = False
                'Exit Try
            End If


            'キー情報退避
            wMEISAI_NO = WordHenkan("N", "Z", dgv_Search.Item("MEISAI_NO", numSelectRowIdx).Value)
            wNOJO_CD = WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD", numSelectRowIdx).Value)
            wTORI_KBN = WordHenkan("N", "Z", dgv_Search.Item("TORI_KBN", numSelectRowIdx).Value)

            'グリッドのKey情報を構造体に格納
            Dim tKEY_PARAM As New T_KEY_PARAM
            tKEY_PARAM.MEISAI_NO = WordHenkan("N", "Z", dgv_Search.Item("MEISAI_NO", numSelectRowIdx).Value)
            tKEY_PARAM.NOJO_CD = WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD", numSelectRowIdx).Value)
            tKEY_PARAM.NOJO_NAME = WordHenkan("N", "S", dgv_Search.Item("NOJO_NAME", numSelectRowIdx).Value)
            tKEY_PARAM.TORI_KBN = WordHenkan("N", "Z", dgv_Search.Item("TORI_KBN", numSelectRowIdx).Value)
            tKEY_PARAM.TORI_KBN_NM = WordHenkan("N", "S", dgv_Search.Item("TORI_KBN_NM", numSelectRowIdx).Value)
            tKEY_PARAM.KEIYAKU_HASU = WordHenkan("N", "Z", dgv_Search.Item("KEIYAKU_HASU", numSelectRowIdx).Value)

            tKEY_PARAM.ADDR_1 = WordHenkan("N", "S", dgv_Search.Item("ADDR_1", numSelectRowIdx).Value)
            tKEY_PARAM.ADDR_2 = WordHenkan("N", "S", dgv_Search.Item("ADDR_2", numSelectRowIdx).Value)
            tKEY_PARAM.ADDR_3 = WordHenkan("N", "S", dgv_Search.Item("ADDR_3", numSelectRowIdx).Value)
            tKEY_PARAM.ADDR_4 = WordHenkan("N", "S", dgv_Search.Item("ADDR_4", numSelectRowIdx).Value)

            tKEY_PARAM.HASSEI_KAISU = txt_HASSEI_KAISU.Text
            tKEY_PARAM.SINSEI_DATE = Format(dateSINSEI_DATE.Value, "yyyy/MM/dd")

            tKEY_PARAM.EDIT_KBN = wEditKbn



            Using wkForm As New frmGJ4012
                wkForm.Owner = Me
                wkForm.pCurrentKey = pCurrentKey         '現在選択されている行のキーを渡します
                wkForm.pSel_NO = numSelectRowIdx         '現在選択されている行のキーを渡します
                '処理状況チェック
                If WordHenkan("N", "Z", dgv_Search.Item("SYORI_JOKYO_KBN", numSelectRowIdx).Value) = 0 Then
                    wkForm.pSyoriKbn = frmGJ4012.Enu_SyoriKubun.Insert
                Else
                    wkForm.pSyoriKbn = frmGJ4012.Enu_SyoriKubun.Update
                End If
                wkForm.paryKEY_4011_PARAM = tKEY_PARAM
                wkForm.p4010_KI = p4010_KI      '期を渡します
                wkForm.pLoadErr = False         'エラー区分

                wkForm.ShowDialog()


                '検索処理
                If Not f_Grid_Set("S", 0, 0, 0) Then
                    Exit Try
                End If
                '明細セット
                f_DtlSet(numSelectRowIdx)

                '該当データ無のエラー以外なら、再表示
                If Not wkForm.pLoadErr Then
                    'グリッド　再表示
                    ret = f_GridReDisp(wMEISAI_NO, wNOJO_CD, wTORI_KBN)
                End If

            End Using

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

        '画面初期化
        f_ObjectClear("")

        'グリッド　クリア
        f_Grid_Clear()

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

        '2017/07/20　追加開始
        If pJump Then
            Exit Sub
        End If
        '2017/07/20　追加終了

        'グリッド　クリア
        f_Grid_Clear()

        '明細　クリア
        f_DtlClear()
    End Sub


#End Region

#Region "dgv_Search グリッドクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :dgv_Search_Click
    '説明            :グリッドクリック時処理
    '------------------------------------------------------------------
    Private Sub dgv_Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_Search.Click
        '該当データ取得
        If dgv_Search.SelectedRows.Count > 0 Then
            Dim intRow As Integer = 0       '行番号
            For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
                intRow = gRow.Index
            Next
            '明細セット
            f_DtlSet(intRow)
        End If
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
        '    End If
        'End If
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
            Dim paraGOJOKIN_SYURUI_KBN As OracleParameter = Cmd.Parameters.Add("IN_GOJOKIN_SYURUI_KBN", 1)
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
    '説明            :グリッド処理
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
            '2017/07/20　修正開始
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
            '2017/07/20　修正終了

            '--------------------------------------------------
            '   グリッド
            '--------------------------------------------------
            'データセット　クリア
            If Not pDataSet Is Nothing Then
                pDataSet.Clear()
            End If

            '--------------------------------------------------
            '   ボタン制御
            '--------------------------------------------------
            If Not f_DtlButton_Enable(False) Then
                Exit Try
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
            '   互助金対象羽数合計・経営支援互助金額合計
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
                    '2017/07/20　修正開始
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
                    '2017/07/20　修正終了
                End If
            End With

            '--------------------------------------------------
            '   グリッド
            '--------------------------------------------------
            'データセット　クリア
            If Not pDataSet Is Nothing Then
                pDataSet.Clear()
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
            dgv_Search.DataSource = pDataSet.Tables(0)
            '件数表示
            lblCOUNT.Text = dgv_Search.Rows.Count   '2015/10/16　追加

            '--------------------------------------------------
            '   グリッド表示位置
            '--------------------------------------------------
            If wKbn = "" Then
                ret1 = f_GridReDisp(wMEISAI_NO, wNOJO_CD, wTORI_KBN)
            End If

            '--------------------------------------------------
            '   ボタン制御
            '--------------------------------------------------
            If Not f_DtlButton_Enable(True) Then
                Exit Try
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Hasu_SQLMake 合計羽数・合計経営支援金額表示ＳＱＬ作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Hasu_SQLMake
    '説明            :合計羽数・合計経営支援金額表示ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Hasu_SQLMake(ByRef wSql As String) As Boolean
        Dim ret As Boolean = False

        Try
            wSql = "SELECT"
            '2017/07/20　修正開始
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
            '2017/07/20　修正終了
            wSql &= " FROM TT_KOFU_SINSEI"
            wSql &= " WHERE KI = " & p4010_KI
            wSql &= "   AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "   AND HASSEI_KAISU = " & txt_HASSEI_KAISU.Text.Trim
            wSql &= "   AND GOJOKIN_SYURUI_KBN = 1"
            wSql &= "   AND TORI_KBN BETWEEN 1 AND 11"

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
            wSql &= "        AND GOJOKIN_SYURUI_KBN = 1"
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
            lbl_KOFU_HASU.Text = ""
            lbl_KOFU_KIN.Text = ""
            lbl_SEI_TUMITATE_KIN.Text = ""
            lbl_KUNI_KOFU_KIN.Text = ""

            '2022/01/24 JBD9020 減額率交付率追加 ADD START
            lbl_KOFU_RITU.Text = ""
            lbl_GENGAKU_RITU.Text = ""
            '2022/01/24 JBD9020 減額率交付率追加 ADD END

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
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
            lbl_KOFU_HASU.Text = WordHenkan("N", "S", dgv_Search.Item("KOFU_HASU", intRow).Value)
            lbl_KOFU_KIN.Text = WordHenkan("N", "S", dgv_Search.Item("KOFU_KIN", intRow).Value)
            lbl_SEI_TUMITATE_KIN.Text = WordHenkan("N", "S", dgv_Search.Item("SEI_TUMITATE_KIN", intRow).Value)
            lbl_KUNI_KOFU_KIN.Text = WordHenkan("N", "S", dgv_Search.Item("KUNI_KOFU_KIN", intRow).Value)

            '2022/01/24 JBD9020 減額率交付率追加 ADD START
            lbl_KOFU_RITU.Text = WordHenkan("N", "S", dgv_Search.Item("KOFU_RITU", intRow).Value)
            If lbl_KOFU_RITU.Text <> "" Then
                lbl_KOFU_RITU.Text = lbl_KOFU_RITU.Text & "%"
            End If
            lbl_GENGAKU_RITU.Text = WordHenkan("N", "S", dgv_Search.Item("GENGAKU_RITU", intRow).Value)
            If lbl_GENGAKU_RITU.Text <> "" Then
                lbl_GENGAKU_RITU.Text = lbl_GENGAKU_RITU.Text & "%"
            End If
            '2022/01/24 JBD9020 減額率交付率追加 ADD END

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
            cmdMeisai.Enabled = wEnable
            cmdDel.Enabled = wEnable
            cmdCansel.Enabled = wEnable

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
    Private Function f_Input_Check() As Boolean
        Dim ret As Boolean = False
        Dim wkControl As Control
        Dim wkControlName As String

        Try

            '==必須チェック==================
            '2022/02/01 JBD9020 発生回数→認定回数に変更 UPD START
            'wkControlName = "発生回数"
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

            '==FromToチェック==================

            '==いろいろチェック==================


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

    Private Sub dateSINSEI_DATE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateSINSEI_DATE.ValueChanged

    End Sub
End Class
