'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ8090.vb
'*
'*　　②　機能概要　　　　　契約農場マスタ一覧
'*
'*　　③　作成日　　　　　　2015/01/20　BY JBD
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

Public Class frmGJ8090

#Region "変数定義"

    ''' <summary>
    ''' グリッドキー項目構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T_KEY

        ''' <summary>
        ''' 契約者農場コード
        ''' </summary>
        ''' <remarks></remarks>
        Public NOJO_CD As String = String.Empty

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
    Public paryKEY_8090 As New List(Of T_KEY)

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
    Private pEnterKi As String              '期(入力値)

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
            txt_KI.Select()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        Finally
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

            'SQL実行
            If Not f_Select_ODP(pDataSet, sSql) Then
                Exit Try
            End If

            'グリッドセット
            If pDataSet.Tables(0).Rows.Count > 0 Then
                '画面に該当データを表示
                dgv_Search.DataSource = pDataSet.Tables(0)
                lblCOUNT.Text = pDataSet.Tables(0).Rows.Count.ToString("#,##0")
            Else
                lblCOUNT.Text = "0"
                pDataSet.Clear()
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
        Dim wNojoCd As Integer = 0
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
            '選択契約者農場　取得
            wNojoCd = dgv_Search.Item("NOJO_CD", intRow).Value

            '削除処理確認
            If Show_MessageBox_Add("Q006", "指定されたデータ") = DialogResult.No Then    '@0を削除します。よろしいですか？
                Exit Try
            End If

            '該当データ削除処理
            If Not f_Data_Deleate(wNojoCd) Then
                Exit Try
            End If

            ''画面グリッドの更新
            'dgv_Search.Rows.RemoveAt(intRow)

            ''グリッドのKey情報を構造体に格納
            'paryKEY_8090 = New List(Of T_KEY)
            'For i As Integer = 0 To dgv_Search.RowCount - 1

            '    Dim tKEY = New T_KEY

            '    tKEY.SEQNO = dgv_Search.Item("SEQNO", i).Value
            '    If dgv_Search.Rows(i).Selected Then
            '        pSel_POS = i + 1
            '        dgv_Search.CurrentCell = dgv_Search(0, i)
            '    End If
            '    paryKEY_8090.Add(tKEY)

            'Next

            ''抽出件数の更新
            'lblCOUNT.Text = dgv_Search.RowCount.ToString("#,##0")
            ret = f_GridReDisp(wNojoCd)

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

            '一覧が表示されていない場合、戻り位置の農場番号はなし
            If dgv_Search.SelectedRows.Count = 0 Then
                strtNowKEY = New T_KEY
                strtNowKEY.NOJO_CD = -1
            Else
                'グリッドのKey情報を構造体に格納
                For i As Integer = 0 To dgv_Search.RowCount - 1
                    '選択行
                    If dgv_Search.Rows(i).Selected Then
                        strtNowKEY = New T_KEY
                        strtNowKEY.NOJO_CD = dgv_Search.Item("NOJO_CD", i).Value
                    End If
                Next
            End If

            '登録画面表示
            Using wkForm As New frmGJ8091
                wkForm.Owner = Me
                wkForm.pSyoriKbn = frmGJ8091.Enu_SyoriKubun.Insert
                wkForm.pCurrentKey = strtNowKEY     '現在選択されている行のキーを渡します

                wkForm.p8090_KI = txt_KI.Text.Trim                          '期を渡します
                wkForm.p8090_KEIYAKUSYA_CD = cob_KEIYAKUSYA_CD.Text.Trim    '契約情報を渡します
                wkForm.p8090_KEIYAKUSYA_NM = cob_KEIYAKUSYA_NM.Text.Trim    '契約情報を渡します

                wkForm.ShowDialog()

                '再抽出
                'cmdSearch_Click(cmdSearch, New EventArgs, False)

                '契約者農場が１度でも指定されたとき
                'If wkForm.pCurrentKey.SEQNO <> -1 Then
                '    For i As Integer = 0 To dgv_Search.RowCount - 1
                '        '選択行
                '        If dgv_Search.Item("SEQNO", i).Value >= CInt(wkForm.pCurrentKey.SEQNO) Then
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
                ret = f_GridReDisp(wkForm.pCurrentKey.NOJO_CD)

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
            paryKEY_8090 = New List(Of T_KEY)
            For i As Integer = 0 To dgv_Search.RowCount - 1
                '要素セット
                tKEY = New T_KEY
                tKEY.NOJO_CD = dgv_Search.Item("NOJO_CD", i).Value
                '選択行
                If dgv_Search.Rows(i).Selected Then
                    strtNowKEY = tKEY
                    pSel_POS = i + 1
                End If
                '配列セット
                paryKEY_8090.Add(tKEY)
            Next

            '変更画面表示
            Using wkForm As New frmGJ8091
                wkForm.Owner = Me
                wkForm.pCurrentKey = strtNowKEY      '現在選択されている行のキーを渡します
                wkForm.pSel_NO = pSel_POS                '現在選択されている行のキーを渡します
                wkForm.pSyoriKbn = frmGJ8091.Enu_SyoriKubun.Update
                wkForm.paryKEY_8090 = paryKEY_8090

                wkForm.p8090_KI = txt_KI.Text.Trim                          '期を渡します
                wkForm.p8090_KEIYAKUSYA_CD = cob_KEIYAKUSYA_CD.Text.Trim    '契約情報を渡します
                wkForm.p8090_KEIYAKUSYA_NM = cob_KEIYAKUSYA_NM.Text.Trim    '契約情報を渡します
                wkForm.pLoadErr = False

                wkForm.ShowDialog()

                '再抽出
                'cmdSearch_Click(cmdSearch, New EventArgs, False)

                '契約者農場が１度でも指定されたとき
                'If wkForm.pCurrentKey.SEQNO <> -1 Then
                '    For i As Integer = 0 To dgv_Search.RowCount - 1
                '        '選択行
                '        If dgv_Search.Item("SEQNO", i).Value >= CInt(wkForm.pCurrentKey.SEQNO) Then
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
                    ret = f_GridReDisp(wkForm.pCurrentKey.NOJO_CD)
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
        txt_KI.Focus()

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

#End Region

#Region "画面コントロール制御関連 "

#Region "期"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_KI_Enter
    '説明            :期Enterイベント
    '------------------------------------------------------------------
    Private Sub txt_KI_Enter(sender As Object, e As EventArgs) Handles txt_KI.Enter

        pEnterKi = txt_KI.Text

    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :txt_KI_Validated
    '説明            :期Validatedベント
    '------------------------------------------------------------------
    Private Sub txt_KI_Validated(sender As Object, e As EventArgs) Handles txt_KI.Validated
        Dim ret As Boolean = False

        Try

            '未入力のとき、契約者コンボクリア
            If txt_KI.Text = "" Then
                '2015/03/03 JBD368 UPD ↓↓↓ DataSourceへ変更に伴い、初期化方法変更
                'cob_KEIYAKUSYA_CD.Items.Clear()
                'cob_KEIYAKUSYA_NM.Items.Clear()
                cob_KEIYAKUSYA_CD.DataSource = Nothing
                cob_KEIYAKUSYA_CD.Clear()
                cob_KEIYAKUSYA_NM.DataSource = Nothing
                cob_KEIYAKUSYA_NM.Clear()
                '2015/03/03 JBD368 UPD ↑↑↑
                Exit Try
            End If

            '期が変更になった場合、契約者コンボ再セット
            If pEnterKi = "" OrElse _
               CInt(txt_KI.Text) <> CInt(pEnterKi) Then
                ret = f_ComboBox_Set(txt_KI.Text.Trim.ToString)
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#Region "契約者"
    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEIYAKUSYA_CD_SelectedIndexChanged
    '説明            :契約者コードChanegeイベント
    '------------------------------------------------------------------
    Private Sub cob_KEIYAKUSYA_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEIYAKUSYA_CD.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEIYAKUSYA_NM.SelectedIndex = cob_KEIYAKUSYA_CD.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEIYAKUSYA_NM_SelectedIndexChanged
    '説明            :契約者名Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cob_KEIYAKUSYA_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEIYAKUSYA_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEIYAKUSYA_CD.SelectedIndex = cob_KEIYAKUSYA_NM.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEIYAKUSYA_CD_Validating
    '説明            :契約者コード_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cob_KEIYAKUSYA_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_KEIYAKUSYA_CD.Validating

        If cob_KEIYAKUSYA_CD.Text = "" Then
            Exit Sub
        End If

        '2015/03/03 JBD368 UPD ↓↓↓ 値の設定方法を変更
        'cob_KEIYAKUSYA_CD.SelectedValue = cob_KEIYAKUSYA_CD.Text
        cob_KEIYAKUSYA_CD.SelectedValue = CDec(cob_KEIYAKUSYA_CD.Text)
        '2015/03/03 JBD368 UPD ↑↑↑
        If cob_KEIYAKUSYA_CD.SelectedValue Is Nothing Then
            cob_KEIYAKUSYA_CD.SelectedIndex = -1
            cob_KEIYAKUSYA_NM.SelectedIndex = -1
            Show_MessageBox_Add("W012", "契約者") '指定された@0が正しくありません。
            cob_KEIYAKUSYA_CD.Focus()
        End If

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
        Dim blnKiChange As Boolean = False

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
            'pJump = False      '2015/03/03 JBD368 DEL コンボボックス設定までTRUEにしておく

            'コンボボックスセット
            ret = f_ComboBox_Set(pInitKi)

            pJump = False       '2015/03/03 JBD368 ADD

            '変数クリア
            paryKEY_8090 = New List(Of T_KEY)

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
    Private Function f_ComboBox_Set(ByVal wKI As String) As Boolean
        Dim ret As Boolean = False
        Dim wWhere As String = String.Empty

        Try

            '期が未入力のとき
            If wKI = "" OrElse wKI = String.Empty Then
                '2015/03/03 JBD368 UPD ↓↓↓ DataSourceへ変更に伴い、初期化方法変更
                'cob_KEIYAKUSYA_CD.Items.Clear()
                'cob_KEIYAKUSYA_NM.Items.Clear()
                cob_KEIYAKUSYA_CD.DataSource = Nothing
                cob_KEIYAKUSYA_CD.Clear()
                cob_KEIYAKUSYA_NM.DataSource = Nothing
                cob_KEIYAKUSYA_NM.Clear()
                '2015/03/03 JBD368 UPD ↑↑↑
                Exit Try
            End If

            pJump = True    '2015/03/04 JBD368 ADD

            '契約者マスタコンボセット
            wWhere = "KI = " & wKI
            If Not f_Keiyaku_Data_Select(cob_KEIYAKUSYA_CD, cob_KEIYAKUSYA_NM, wWhere, True) Then
                Exit Try
            End If

            'コンボボックス初期化
            cob_KEIYAKUSYA_CD.Text = ""

            pJump = False    '2015/03/04 JBD368 ADD

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

            '契約者入力なし
            If cob_KEIYAKUSYA_CD.Text.Trim = "" Then
                Show_MessageBox_Add("W008", "契約者")
                cob_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If

            '==FromToチェック==================

            '==その他チェック==================

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
                wkANDorOR = " AND "
            Else
                '検索方法で[いずれかを含む]を選択
                wkANDorOR = " OR "
            End If

            '==オプション条件====================
            ' 以下は省略可能な条件なので指定されていた場合にのみ編集
            ' 但し、検索方法が全てを含むなのかいずれかを含むなのかによりwkANDorORの内容がANDかORに変わる

            '農場番号
            If txt_NOJO_CD.Text.Trim <> "" Then
                wkWhere &= " KNJ.NOJO_CD = " & txt_NOJO_CD.Text.Trim
            End If

            '農場名
            If txt_NOJO_NAME.Text.Trim <> "" Then
                If wkWhere <> "" Then
                    wkWhere = wkWhere & wkANDorOR
                End If
                wkWhere &= " KNJ.NOJO_NAME LIKE '%" & f_SqlEdit(txt_NOJO_NAME.Text) & "%'"
            End If

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
                        wSql &= "  KNJ.NOJO_CD,"
                        wSql &= "  KNJ.NOJO_NAME,"
                        wSql &= "  KNJ.ADDR_1 || KNJ.ADDR_2 || KNJ.ADDR_3 || KNJ.ADDR_4 ADDR "
                        wSql &= "FROM"
                        wSql &= "  TM_KEIYAKU_NOJO KNJ "
                        wSql &= "WHERE KNJ.KI = " & txt_KI.Text.Trim    '期
                        wSql &= "  AND KNJ.KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim    '契約者
                        wSql &= wkWhere & " "
                        wSql &= "ORDER BY"
                        wSql &= "  KNJ.NOJO_CD"

                End Select

                ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_Data_Deleate 契約者農場削除処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Deleate
    '説明            :契約者農場削除処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Deleate(ByVal wNojoCd As Integer) As Boolean

        Dim wkCmd As New OracleCommand
        Dim wkSql As String = String.Empty
        Dim wkRet As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            wkCmd.Connection = Cnn
            wkCmd.CommandType = CommandType.StoredProcedure
            '
            wkCmd.CommandText = "PKG_GJ8091.GJ8091_KEIYAKU_NOJO_DEL"

            '引き渡し
            'グループコード
            Dim paraKI As OracleParameter = wkCmd.Parameters.Add("IN_KI", txt_KI.Text.Trim)
            Dim paraKEIYAKU_CD As OracleParameter = wkCmd.Parameters.Add("IN_KEIYAKU", cob_KEIYAKUSYA_CD.Text.Trim)
            Dim paraNOJO_CD As OracleParameter = wkCmd.Parameters.Add("IN_NOJO_CD", wNojoCd)

            '戻り
            Dim p_MSGCD As OracleParameter = wkCmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = wkCmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            wkCmd.ExecuteNonQuery()

            Debug.Print(wkCmd.Parameters("OU_MSGCD").Value.ToString())
            If wkCmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                If wkCmd.Parameters("OU_MSGCD").Value.ToString() = "99" Then
                    '削除済みは政情終了とみなす
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
    Private Function f_GridReDisp(ByVal wNojoCd As Integer) As Boolean
        Dim ret As Boolean = False
        Dim blnHit As Boolean = False

        Try

            '再抽出
            cmdSearch_Click(cmdSearch, New EventArgs, False)

            'グリッドに有効データあり
            If dgv_Search.RowCount <> 0 Then
                '契約者農場が指定されたとき
                If wNojoCd <> -1 Then
                    For i As Integer = 0 To dgv_Search.RowCount - 1
                        '選択行
                        If dgv_Search.Item("NOJO_CD", i).Value >= wNojoCd Then
                            '現在セル　セットdgv_Search.CurrentCell
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
