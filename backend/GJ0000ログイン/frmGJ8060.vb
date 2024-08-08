'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ8060.vb
'*
'*　　②　機能概要　　　　　同一生産者マスタ一覧
'*
'*　　③　作成日　　　　　　2014/08/27　BY JBD
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

Public Class frmGJ8060

#Region "変数定義"

    ''' <summary>
    ''' グリッドキー項目構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T_KEY

        ''' <summary>
        ''' 委託先コード
        ''' </summary>
        ''' <remarks></remarks>
        Public ITAKU_CD As String = String.Empty

    End Class

    ''' <summary>
    ''' 結果一覧セット用データセット
    ''' </summary>
    ''' <remarks></remarks>
    Private pDataSet As New DataSet

    ''' <summary>
    ''' グリッドキーリスト
    ''' </summary>
    ''' <remarks></remarks>
    Public paryKEY_8060 As New List(Of T_KEY)

    ''' <summary>
    ''' 変更時、該当データ選択行
    ''' </summary>
    ''' <remarks></remarks>
    Public pSel_POS As Integer

    ''' <summary>
    ''' プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True         '処理ジャンプ 
    Private pInitKi As String               '期(初期値)

#End Region

#Region "画面制御関連"

#Region "frmEMXXXX_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmEMXXXX_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmEMXXXX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean
        Try

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            pInitKi = New Obj_TM_SYORI_NENDO_KI().pKI
            ret = f_ObjectClear("C")

            '先頭項目にフォーカスセット
            cob_KEN_CD_F.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

    End Sub

#End Region
#Region "frmEMXXXX_Disposed Form_Disposedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmEMXXXX_Disposed
    '説明            :Form_Disposedイベント
    '------------------------------------------------------------------
    Private Sub frmEMXXXX_Disposed(ByVal sender As Object, ByVal e As System.EventArgs)

        If Not pDataSet Is Nothing Then
            pDataSet.Clear()
            pDataSet.Dispose()
        End If

    End Sub

#End Region

#End Region

#Region "画面ボタンクリック関連"

#Region "cmdSearch_Click 検索ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSearch_Click
    '説明            :検索ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs, Optional ByVal wkAlertFlag As Boolean = True) Handles cmdSearch.Click
        Dim sSql As String = String.Empty

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '画面入力チェック
            If wkAlertFlag Then
                If Not f_Input_Check() Then
                    Exit Try
                End If
            End If

            'データセットクリア
            If Not pDataSet Is Nothing Then
                pDataSet.Clear()
            End If

            'SQL作成
            If Not f_Search_SQLMake(0, sSql) Then
                Exit Try
            End If

            'SQL実効
            If Not f_Select_ODP(pDataSet, sSql) Then
                Exit Try
            End If

            'グリッドセット
            If pDataSet.Tables(0).Rows.Count > 0 Then
                '画面に該当データを表示
                dgv_Search.DataSource = pDataSet.Tables(0)
                lblCOUNT.Text = pDataSet.Tables(0).Rows.Count.ToString("#,##0")
            Else
                pDataSet.Clear()
                lblCOUNT.Text = "0"
                If wkAlertFlag Then
                    'データ存在なし
                    Show_MessageBox("I003", "")       '指定された条件に一致するデータは存在しません。
                    Exit Sub
                End If
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

#Region "cmdDel_Click 削除ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdDel_Click
    '説明            :削除ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        Dim wItakuCd As Integer = 0
        Dim intRow As Integer = 0       '行番号
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Dim wkDS As New DataSet

        Try

            '画面入力チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")
                Exit Try
            End If

            '選択行　取得
            For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
                intRow = gRow.Index
            Next
            '選択委託先　取得
            wItakuCd = dgv_Search.Item("ITAKU_CD", intRow).Value

            '削除処理確認
            If Show_MessageBox_Add("Q006", "指定されたデータ") = DialogResult.No Then    '@0を削除します。よろしいですか？
                Exit Try
            End If

            '該当データ削除処理
            If Not f_Data_Deleate(wItakuCd) Then
                Exit Try
            End If

            ''画面グリッドの更新
            'dgv_Search.Rows.RemoveAt(intRow)

            ''グリッドのKey情報を構造体に格納
            'paryKEY_8060 = New List(Of T_KEY)
            'For i As Integer = 0 To dgv_Search.RowCount - 1

            '    Dim tKEY = New T_KEY

            '    tKEY.ITAKU_CD = dgv_Search.Item("ITAKU_CD", i).Value
            '    If dgv_Search.Rows(i).Selected Then
            '        pSel_POS = i + 1
            '        dgv_Search.CurrentCell = dgv_Search(0, i)
            '    End If
            '    paryKEY_8060.Add(tKEY)

            'Next

            ''抽出件数の更新
            'lblCOUNT.Text = dgv_Search.RowCount.ToString("#,##0")
            ret = f_GridReDisp(wItakuCd)

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdIns_Click 新規入力ボタンクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSav_Click
    '説明            :新規入力ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIns.Click
        Dim strtNowKEY As T_KEY = Nothing
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '画面入力チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                strtNowKEY = New T_KEY
                strtNowKEY.ITAKU_CD = -1
            Else
                'グリッドのKey情報を構造体に格納
                For i As Integer = 0 To dgv_Search.RowCount - 1
                    '選択行
                    If dgv_Search.Rows(i).Selected Then
                        strtNowKEY = New T_KEY
                        strtNowKEY.ITAKU_CD = dgv_Search.Item("ITAKU_CD", i).Value
                    End If
                Next
            End If

            '登録画面表示
            Using wkForm As New frmGJ8061
                wkForm.Owner = Me
                wkForm.pSyoriKbn = frmGJ8061.Enu_SyoriKubun.Insert
                wkForm.pCurrentKey = strtNowKEY      '現在選択されている行のキーを渡します

                wkForm.p8060_KI = txt_KI.Text.Trim                          '期を渡します

                wkForm.ShowDialog()

                '再抽出
                'cmdSearch_Click(cmdSearch, New EventArgs, False)

                '委託先が１度でも指定されたとき
                'If wkForm.pCurrentKey.ITAKU_CD <> -1 Then
                '    For i As Integer = 0 To dgv_Search.RowCount - 1
                '        '選択行
                '        If dgv_Search.Item("ITAKU_CD", i).Value >= CInt(wkForm.pCurrentKey.ITAKU_CD) Then
                '            '現在セル　セットdgv_Search.CurrentCell
                '            dgv_Search.CurrentCell = dgv_Search(0, i)
                '            blnHit = True
                '            Exit For
                '        End If
                '    Next
                '    '最後まで該当データがなかった場合、最終行
                '    If Not blnHit Then
                '        dgv_Search.CurrentCell = dgv_Search(0, dgv_Search.RowCount - 1)
                '    End If
                'End If
                ret = f_GridReDisp(wkForm.pCurrentKey.ITAKU_CD)

            End Using

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdUpd_Click 変更表示ボタンクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdUpd_Click
    '説明            :変更表示ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpd.Click
        Dim tKEY As New T_KEY
        Dim strtNowKEY As T_KEY = Nothing
        Dim ret As Boolean = False


        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '画面入力チェック(エラー表示あり)
            If Not f_Input_Check() Then
                Exit Try
            End If

            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")       'データが選択されていません。
                Exit Try
            End If

            'グリッドのKey情報を構造体に格納
            paryKEY_8060 = New List(Of T_KEY)
            For i As Integer = 0 To dgv_Search.RowCount - 1
                '要素セット
                tKEY = New T_KEY
                tKEY.ITAKU_CD = dgv_Search.Item("ITAKU_CD", i).Value
                '選択行
                If dgv_Search.Rows(i).Selected Then
                    strtNowKEY = tKEY
                    pSel_POS = i + 1
                End If
                '配列セット
                paryKEY_8060.Add(tKEY)
            Next

            '変更画面表示
            Using wkForm As New frmGJ8061
                wkForm.Owner = Me
                wkForm.pCurrentKey = strtNowKEY      '現在選択されている行のキーを渡します
                wkForm.pSel_NO = pSel_POS                '現在選択されている行のキーを渡します
                wkForm.pSyoriKbn = frmGJ8061.Enu_SyoriKubun.Update
                wkForm.paryKEY_8060 = paryKEY_8060

                wkForm.p8060_KI = txt_KI.Text.Trim                          '期を渡します
                wkForm.pLoadErr = False

                wkForm.ShowDialog()

                '再抽出
                'cmdSearch_Click(cmdSearch, New EventArgs, False)

                '委託先が１度でも指定されたとき
                'If wkForm.pCurrentKey.ITAKU_CD <> -1 Then
                '    For i As Integer = 0 To dgv_Search.RowCount - 1
                '        '選択行
                '        If dgv_Search.Item("ITAKU_CD", i).Value >= CInt(wkForm.pCurrentKey.ITAKU_CD) Then
                '            '現在セル　セットdgv_Search.CurrentCell
                '            dgv_Search.CurrentCell = dgv_Search(0, i)
                '            blnHit = True
                '            Exit For
                '        End If
                '    Next
                '    '最後まで該当データがなかった場合、最終行
                '    If Not blnHit Then
                '        dgv_Search.CurrentCell = dgv_Search(0, dgv_Search.RowCount - 1)
                '    End If
                'End If

                If Not wkForm.pLoadErr Then
                    ret = f_GridReDisp(wkForm.pCurrentKey.ITAKU_CD)
                End If

            End Using

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
    Private Sub cmdCan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCan.Click

        Dim ret As Boolean

        ret = f_ObjectClear("")

        'データ区分にフォーカスセット
        cob_KEN_CD_F.Focus()

    End Sub
#End Region

#Region "cmdEnd_Click 終了ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdEnd_Click
    '説明            :終了ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click

        Try
            If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                Exit Try
            End If

            Me.AutoValidate = AutoValidate.Disable
            'フォームクローズ
            Me.Close()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'データベースへの接断
            Cnn.Close()
            'フォームクローズ
            Me.Close()
        End Try
    End Sub
#End Region

#Region "cmdCSV_Click ＣＳＶ出力処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdCSV_Click
    '説明            :ＣＳＶ出力処理
    '------------------------------------------------------------------
    Private Sub cmdCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCSV.Click
        Dim wkDS As New DataSet
        Dim sSql As String = String.Empty

        Try

            '画面入力チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            'SQL作成
            If Not f_Search_SQLMake(1, sSql) Then
                Exit Try
            End If

            If Not f_Select_ODP(wkDS, sSql) Then
                Show_MessageBox("I002", "")       '指定された条件に一致するデータは存在しません。
                Exit Sub
            End If

            'CSV作成(日時はサブルーチンでセット)
            f_makeCSVByDT(wkDS.Tables(0), "JIMUITAKUSAKI_")

        Catch ex As Exception
            Show_MessageBox("", ex.Message)
        End Try


    End Sub
#End Region

#End Region

#Region "画面コントロール制御関連 "

#Region "都道府県関連"

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_F_SelectedIndexChanged
    '説明            :都道府県コード(FROM)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_F_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEN_CD_F.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEN_NM_F.SelectedIndex = cob_KEN_CD_F.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KenNm_F_SelectedIndexChanged
    '説明            :都道府県名(FROM)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KenNm_F_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEN_NM_F.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEN_CD_F.SelectedIndex = cob_KEN_NM_F.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_F_Validating
    '説明            :都道府県コード(FROM)確定中処理
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_F_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
                cob_KEN_CD_F.Validating, cob_KEN_NM_F.Validating

        Call s_CboFrom_Validating(cob_KEN_CD_F, cob_KEN_NM_F, cob_KEN_CD_T, cob_KEN_NM_T)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_T_SelectedIndexChanged
    '説明            :都道府県コード(TO)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_T_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEN_CD_T.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEN_NM_T.SelectedIndex = cob_KEN_CD_T.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KenNm_F_SelectedIndexChanged
    '説明            :都道府県名(TO)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KenNm_T_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEN_NM_T.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEN_CD_T.SelectedIndex = cob_KEN_NM_T.SelectedIndex

    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_T_Validating
    '説明            :都道府県コード(TO)確定中処理
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_T_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
                cob_KEN_CD_T.Validating, cob_KEN_NM_T.Validating

        Call s_CboTo_Validating(cob_KEN_CD_T, cob_KEN_NM_T, cob_KEN_CD_F, cob_KEN_NM_F)

    End Sub

#End Region

#End Region

#Region "ローカル関数"

#Region "f_ObjectClear 画面クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ObjectClear
    '説明            :画面クリア処理
    '引数            :rKbn(処理区分)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ObjectClear(ByVal wKbn As String) As Boolean
        Dim ret As Boolean = False

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '画面初期化
            pJump = True
            f_ClearFormALL(Me, wKbn)
            txt_KI.Text = pInitKi   '期
            lblCOUNT.Text = "0"     '抽出
            pJump = False

            'コンボボックスセット
            If wKbn = "C" Then
                ret = f_ComboBox_Set()
            End If

            '変数クリア
            paryKEY_8060 = New List(Of T_KEY)

            If Not pDataSet Is Nothing Then
                pDataSet.Clear()
            End If

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
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ComboBox_Set() As Boolean
        Dim ret As Boolean = False

        Try

            '県マスタコンボセット
            If Not f_Ken_Data_Select(cob_KEN_CD_F, cob_KEN_NM_F, True) Then
                Exit Try
            End If
            If Not f_Ken_Data_Select(cob_KEN_CD_T, cob_KEN_NM_T, True) Then
                Exit Try
            End If

            'コンボボックス初期化
            cob_KEN_CD_F.Text = ""
            cob_KEN_CD_T.Text = ""

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Input_Check 画面入力チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check
    '説明            :画面入力チェック処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check() As Boolean
        Dim ret As Boolean = False

        Try

            '==必須チェック==================

            '期入力なし
            If txt_KI.Text.Trim = "" Then
                Show_MessageBox_Add("W008", "期")
                txt_KI.Focus()
                Exit Try
            End If

            '==FromToチェック==================

            '都道府県
            If f_Daisyo_Check(cob_KEN_CD_F, cob_KEN_CD_T, "都道府県", True) = False Then
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

#Region "f_Search_SQLMake ＳＱＬ作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Search_SQLMake(ByVal wKbn As Integer, ByRef wSql As String) As Boolean
        Dim ret As Boolean = False
        Dim wkANDorOR As String = String.Empty
        Dim wkWhere As String = String.Empty

        Try

            'ＳＱＬ
            wSql = ""

            If rbtn_SearchAnd.Checked Then
                '検索方法で[すべてを含む]を選択
                wkANDorOR = " AND"
            Else
                '検索方法で[いずれかを含む]を選択
                wkANDorOR = " OR"
            End If

            '==オプション条件====================
            ' 以下は省略可能な条件なので指定されていた場合にのみ編集
            ' 但し、検索方法が全てを含むなのかいずれかを含むなのかによりwkANDorORの内容がANDかORに変わる

            '都道府県
            If cob_KEN_CD_F.Text <> "" AndAlso cob_KEN_CD_T.Text <> "" Then
                wkWhere &= "  ITK.KEN_CD BETWEEN " & cob_KEN_CD_F.Text & " AND " & cob_KEN_CD_T.Text
            End If

            '委託先名
            If txt_ITAKU_NAME.Text.Trim <> "" Then
                If wkWhere <> "" Then
                    wkWhere &= wkANDorOR
                End If
                wkWhere &= "  ITK.ITAKU_NAME LIKE '%" & f_SqlEdit(txt_ITAKU_NAME.Text) & "%'"
            End If

            '委託先コード
            If txt_ITAKU_CD.Text.Trim <> "" Then
                If wkWhere <> "" Then
                    wkWhere &= wkANDorOR
                End If
                wkWhere &= "  ITK.ITAKU_CD = " & txt_ITAKU_CD.Text.Trim
            End If

            '2015/03/31　追加開始
            If txt_MATOMESAKI.Text.Trim <> "" Then
                If wkWhere <> "" Then
                    wkWhere &= wkANDorOR
                End If
                wkWhere &= "  ITK.MATOMESAKI = " & txt_MATOMESAKI.Text.Trim
            End If
            '2015/03/31　追加終了

            '条件編集
            If wkWhere <> "" Then
                wkWhere = "  AND (" & wkWhere & ")"
            End If

            '==SQL作成====================
            Select Case wKbn

                Case 0  '検索ボタンクリック時の検索条件
                    'SQL作成
                    wSql = ""
                    wSql &= "SELECT"
                    wSql &= "  ITK.ITAKU_CD,"
                    wSql &= "  ITK.ITAKU_NAME,"
                    wSql &= "  ITK.ADDR_TEL,"
                    wSql &= "  CASE WHEN ITK.ADDR_POST IS NULL THEN NULL"
                    wSql &= "  ELSE SUBSTR(ITK.ADDR_POST,1,3) || '-' || SUBSTR(ITK.ADDR_POST,4,4) END ADDR_POST,"
                    wSql &= "  ITK.ADDR_1 || ITK.ADDR_2 || ITK.ADDR_3 || ITK.ADDR_4 ADDR "
                    wSql &= "FROM"
                    wSql &= "  TM_JIMUITAKU ITK "
                    wSql &= "WHERE ITK.KI = " & txt_KI.Text.Trim    '期
                    wSql &= wkWhere & " "
                    wSql &= "ORDER BY"
                    wSql &= "  ITK.ITAKU_CD"

                Case 1  'CSV出力ボタンクリック時の検索条件
                    wSql &= "SELECT"
                    wSql &= "  ITK.KI AS ""期"","
                    wSql &= "  ITK.ITAKU_CD AS ""事務委託先番号"","
                    wSql &= "  ITK.KEN_CD AS ""都道府県コード"","
                    wSql &= "  M05.MEISYO AS ""都道府県名称"","
                    wSql &= "  ITK.ITAKU_NAME AS ""事務委託先名（正式）"","
                    wSql &= "  ITK.ITAKU_RYAKU AS ""事務委託先名（略称）"","
                    wSql &= "  ITK.DAIHYO_NAME AS ""代表者名"","
                    wSql &= "  ITK.TANTO_NAME AS ""担当者名"","
                    wSql &= "  ITK.ADDR_POST AS ""郵便番号"","
                    wSql &= "  ITK.ADDR_1 AS ""住所１"","
                    wSql &= "  ITK.ADDR_2 AS ""住所２"","
                    wSql &= "  ITK.ADDR_3 AS ""住所３"","
                    wSql &= "  ITK.ADDR_4 AS ""住所４"","
                    wSql &= "  ITK.ADDR_TEL AS ""電話番号"","
                    wSql &= "  ITK.ADDR_FAX AS ""ＦＡＸ"","
                    wSql &= "  ITK.ADDR_E_MAIL AS ""メールアドレス"","
                    wSql &= "  ITK.BANK_INJI_KBN AS ""金融機関情報印字有無"","
                    wSql &= "  ITK.MATOMESAKI AS ""まとめ先"","
                    wSql &= "  ITK.MOSIKOMISYORUI AS ""申込書類"","
                    wSql &= "  ITK.SEIKYUSYO AS ""請求書・契約書"","
                    wSql &= "  ITK.NYUKINHOHO AS ""入金方法"","
                    wSql &= "  ITK.ITAKUKENSU AS ""委託件数"","
                    wSql &= "  ITK.LABELHAKKO AS ""ラベル発行"","
                    wSql &= "  ITK.JYOGAI_FLG AS ""除外フラグ"","
                    wSql &= "  ITK.BIKO AS ""備考"" "
                    wSql &= "FROM"
                    wSql &= "  TM_JIMUITAKU ITK,"
                    wSql &= "  TM_CODE M05 "
                    wSql &= "WHERE ITK.KI = " & txt_KI.Text.Trim    '期
                    wSql &= "  AND 05 = M05.SYURUI_KBN(+)"
                    wSql &= "  AND ITK.KEN_CD = M05.MEISYO_CD(+)"
                    wSql &= wkWhere & " "
                    wSql &= "ORDER BY"
                    wSql &= "  ITK.ITAKU_CD"

            End Select

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_Data_Deleate 委託先削除処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Deleate
    '説明            :委託先削除処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Deleate(ByVal wItakuCd As Integer) As Boolean

        Dim wkCmd As New OracleCommand
        Dim wkSql As String = String.Empty
        Dim wkRet As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            wkCmd.Connection = Cnn
            wkCmd.CommandType = CommandType.StoredProcedure
            '
            wkCmd.CommandText = "PKG_GJ8061.GJ8061_JIMUITAKU_DEL"

            '引き渡し
            'グループコード
            Dim paraKI As OracleParameter = wkCmd.Parameters.Add("IN_KI", txt_KI.Text.Trim)
            Dim paraGROUP_CD As OracleParameter = wkCmd.Parameters.Add("IN_ITAKU_CD", wItakuCd)

            '戻り
            Dim p_MSGCD As OracleParameter = wkCmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = wkCmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            wkCmd.ExecuteNonQuery()

            Debug.Print(wkCmd.Parameters("OU_MSGCD").Value.ToString())
            If wkCmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                If wkCmd.Parameters("OU_MSGCD").Value.ToString() = "99" Then
                    '削除済みは正常終了とみなす
                    wkRet = True
                End If
                Throw New Exception(wkCmd.Parameters("OU_MSGCD").Value.ToString() & ":" & wkCmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            wkRet = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'データベースへの接続を閉じる
            If Not wkCmd Is Nothing Then
                wkCmd.Dispose()
            End If
        End Try

        Return wkRet


    End Function
#End Region

#Region "f_GridReDisp グリッド再表示"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridReDisp
    '説明            :グリッド再表示
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_GridReDisp(ByVal wItakCd As Integer) As Boolean
        Dim ret As Boolean = False
        Dim blnHit As Boolean = False

        Try

            '再抽出
            cmdSearch_Click(cmdSearch, New EventArgs, False)


            'グリッドに有効データあり
            If dgv_Search.RowCount <> 0 Then
                '委託先が指定されたとき
                If wItakCd <> -1 Then
                    For i As Integer = 0 To dgv_Search.RowCount - 1
                        '選択行
                        If dgv_Search.Item("ITAKU_CD", i).Value >= wItakCd Then
                            '現在セル　セット
                            dgv_Search.CurrentCell = dgv_Search(0, i)
                            blnHit = True
                            Exit For
                        End If
                    Next
                    '最後まで該当データがなかった場合、最終行
                    If Not blnHit Then
                        dgv_Search.CurrentCell = dgv_Search(0, dgv_Search.RowCount - 1)
                    End If
                End If
            End If

            ret = True

        Catch ex As Exception
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#End Region

End Class
