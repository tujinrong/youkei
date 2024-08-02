'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ8100.vb
'*
'*　　②　機能概要　　　　　消費税率マスタメンテナンス 
'*
'*　　③　作成日　　　　　　2023/07/28  BY JBD454
'*
'*　　④　更新日            
'*
'*******************************************************************************
Option Strict Off
Option Explicit On
'------------------------------------------------------------------
Imports Oracle.DataAccess.Client
Imports JbdGjsCommon
Imports JbdGjsControl

Public Class frmGJ8100

#Region "*** 変数定義 ***"

    Private pDataSet As New DataSet                      '検索結果一覧セット用データセット

    Private Const C_TAX_DATE_FROM As Integer = 0         '適用開始日
    Private Const C_TAX_DATE_TO As Integer = 1           '適用終了日
    Private Const C_TAX_RITU As Integer = 2              '消費税率(%)

    Public pSaveTAX_DATE_FROM As String = String.Empty   '適用開始日セーブ

#End Region

#Region "*** 画面制御関連 ***"

#Region "frmGJ8100_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ8100_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ8100_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean

        Try
            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear()

            ''コンピュータ名取得
            pPCNAME = System.Net.Dns.GetHostName

            'グリッドビューセット
            If Not f_GridView_Set() Then
                Exit Try
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

    End Sub

#End Region
#Region "frmGJ8100_Disposed Form_Disposedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ8100_Disposed
    '説明            :Form_Disposedイベント
    '------------------------------------------------------------------
    Private Sub frmGJ8100_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        pDataSet.Clear()
        pDataSet.Dispose()

    End Sub

#End Region
#Region "frmGJ8100_Activated Form_Activatedイベント"

    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ8100_Activated
    '説明            :Form_Activatedイベント
    '------------------------------------------------------------------
    Private Sub frmGJ8100_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Try

            If dgv_Search.Rows.Count = 0 Then
                cmdUpd.Enabled = False
                cmdDel.Enabled = False
                'データなしの時、新規登録ボタンへ
                dgv_Search.Enabled = True
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub
#End Region
#Region "f_ObjectClear 画面クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ObjectClear
    '説明            :画面クリア処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ObjectClear() As Boolean

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            pDataSet.Clear()

            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function
#End Region

#End Region

#Region "*** 画面ボタンクリック関連 ***"

#Region "cmdDel_Click 削除ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdDel_Click
    '説明            :削除ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")     'データが選択されていません。
                Exit Try
            End If

            '削除処理確認
            If Show_MessageBox_Add("Q006", "指定されたデータ") = DialogResult.No Then    '指定されたデータを削除します。よろしいですか？
                '「いいえ」を選択
                Exit Try
            End If

            Dim intRow As Integer = 0       '行番号

            For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
                intRow = gRow.Index
            Next

            '該当データ削除処理
            If Not f_TM_TAX_Deleate(intRow) Then
                Exit Try
            End If

            ' ''GlidView対応--▼
            pSaveTAX_DATE_FROM = dgv_Search.Item(C_TAX_DATE_FROM, intRow).Value
            'グリッドビューセット
            If Not f_GridView_Set() Then
                Exit Try
            End If
            ' ''GlidView対応--▲

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdIns_Click 新規入力ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdIns_Click
    '説明            :新規入力ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIns.Click
        Dim intNo As Integer = 0

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            ' ''GlidView対応--▼
            'カレント適用開始日セーブ
            If dgv_Search.RowCount = 0 Then
                pSaveTAX_DATE_FROM = String.Empty
            Else
                pSaveTAX_DATE_FROM = dgv_Search.Item(C_TAX_DATE_FROM, dgv_Search.CurrentRow.Index).Value
            End If
            ' ''GlidView対応--▲

            'メンテナンス画面　表示
            Dim form As New frmGJ8101
            form.Owner = Me
            form.pSyoriKbn = frmGJ8101.C_INSERT　　'新規登録モード

            form.ShowDialog()  'メンテナンス画面（新規登録）の表示

            ' ''GlidView対応--▼
            'グリッドビューセット
            If Not f_GridView_Set() Then
                Exit Try
            End If
            ' ''GlidView対応--▲

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdUpd_Click 変更ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdUpd_Click
    '説明            :変更ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpd.Click

        Dim strTAX_DATE_FROM As String = String.Empty　
        Dim intNo As Integer = 0

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")     'データが選択されていません。
                Exit Try
            End If

            ' ''GlidView対応--▼
            'カレント適用開始日セーブ
            If dgv_Search.RowCount = 0 Then
                pSaveTAX_DATE_FROM = String.Empty
            Else
                pSaveTAX_DATE_FROM = dgv_Search.Item(C_TAX_DATE_FROM, dgv_Search.CurrentRow.Index).Value
            End If
            ' ''GlidView対応--▲

            '適用開始日に修正
            For i As Integer = 0 To dgv_Search.RowCount - 1
                If dgv_Search.Rows(i).Selected Then
                    strTAX_DATE_FROM = WordHenkan("N", "S", dgv_Search.Item(C_TAX_DATE_FROM, i).Value)    '現在選択されている行のキー
                    intNo = i + 1                   '現在選択されている行の位置
                End If
            Next

            'メンテナンス画面へ
            Dim form As New frmGJ8101
            form.Owner = Me                     '2010/10/16 ADD JBD200
            form.pSel_TAX_DATE_FROM = strTAX_DATE_FROM      '現在選択されている行のキーを渡します
            form.pSel_NO = intNo                '現在選択されている行の位置を渡します
            form.pSyoriKbn = frmGJ8101.C_UPDATE

            form.ShowDialog()  'メンテナンス画面（変更(表示)）の表示

            ' ''GlidView対応--▼
            'グリッドビューセット
            If Not f_GridView_Set() Then
                Exit Try
            End If
            ' ''GlidView対応--▲

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdEnd_Click 戻るボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdEnd_Click
    '説明            :戻るボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try
            If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                Exit Try
            End If

            'フォームクローズ
            Me.AutoValidate = AutoValidate.Disable
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

#Region "*** ローカル関数 ***"

#Region "f_GridView_Set グリッドビューセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridView_Set
    '説明            :グリッドビューセット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_GridView_Set() As Boolean
        Dim sSql As String = String.Empty
        Dim ret As Boolean = False

        Try
            '消費税率マスタ一覧セット 
            '検索処理
            pDataSet.Clear()

            sSql = f_Search_SQLMake()
            If Not f_Select_ODP(pDataSet, sSql) Then
                Exit Try
            End If

            If pDataSet.Tables(0).Rows.Count > 0 Then
                '画面に該当データを表示
                dgv_Search.DataSource = pDataSet.Tables(0)

            Else
                'データ存在なし
                pDataSet.Clear()
            End If

            ' ''GlidView対応--▼
            'カーソルセット
            If Not f_GridRow_Set(pSaveTAX_DATE_FROM) Then
                Exit Try
            End If
            ' ''GlidView対応--▲

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_GridRow_Set グリッドビュー現在行セット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridRow_Set
    '説明            :グリッドビュー現在行セット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_GridRow_Set(ByVal wTAX_DATE_FROM As String) As Boolean
        Dim ret As Boolean = False
        Dim wIdx As Integer = 0
        Dim wDATE_FROM1 As String = String.Empty
        Dim C_DATE_FROM As String = String.Empty

        Try

            If dgv_Search.RowCount = 0 Then
                '表示データなし
                cmdUpd.Enabled = False
                cmdDel.Enabled = False
                'データなしの時、新規登録ボタンへ
                dgv_Search.Enabled = True

            ElseIf wTAX_DATE_FROM = "" Then
                '初期処理＆表示データあり
                wIdx = 0
                '変更、削除ボタン　有効
                cmdUpd.Enabled = True
                cmdDel.Enabled = True

            Else
                '初期処理以外＆表示データあり
                '登録のとき、登録した適用開始日に位置づけ
                '変更のとき、変更した適用開始日に位置づけ
                '削除のとき、削除した適用開始日の次のユーザＩＤに位置づけ
                '　　　　　　削除した適用開始日が最終行の場合は、最終行に位置づけ

                For i As Integer = 0 To dgv_Search.RowCount - 1
                    wIdx = i

                    '和暦を西暦に
                    wDATE_FROM1 = CType(wTAX_DATE_FROM, Date)
                    C_DATE_FROM = CType(dgv_Search.Item(C_TAX_DATE_FROM, i).Value, Date)

                    If C_DATE_FROM <= wDATE_FROM1 Then
                        Exit For
                    End If

                Next

                '変更、削除ボタン　有効
                cmdUpd.Enabled = True
                cmdDel.Enabled = True
                'カーソルセット
                dgv_Search.CurrentCell = dgv_Search.Rows(wIdx).Cells(0)
                dgv_Search.Focus()

            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Search_SQLMake 検索結果出力用ＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :検索結果出力用ＳＱＬ作成
    '引数            :なし
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    Private Function f_Search_SQLMake() As String
        Dim sSql As String = String.Empty

        Try
            '検索
            sSql = " SELECT " & vbCrLf
            sSql += "  TO_CHAR(TAX.TAX_DATE_FROM,'EEYY/MM/DD','NLS_CALENDAR=''Japanese Imperial''')TAX_DATE_FROM," & vbCrLf '適用開始日
            sSql += "  TO_CHAR(TAX.TAX_DATE_TO,'EEYY/MM/DD','NLS_CALENDAR=''Japanese Imperial''')TAX_DATE_TO," & vbCrLf 　　'適用終了日
            sSql += "  TAX.TAX_RITU TAX_RITU" & vbCrLf                     '消費税率（%）
            sSql += " FROM" & vbCrLf
            sSql += "  TM_TAX TAX" & vbCrLf

            '適用開始日を基準に降順
            sSql += "ORDER BY" & vbCrLf
            sSql += "TAX.TAX_DATE_FROM" & vbCrLf
            sSql += "DESC" & vbCrLf

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return sSql

    End Function
#End Region

#Region "f_TM_TAX_Deleate 消費税率マスタデータ削除"
    '----------------------------------------------------------------
    'プロシージャ名  :f_TM_TAX_Deleate
    '説明            :消費税率マスタデータ削除
    '引数            :1.intRow      Integer     選択されている行番号
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_TAX_Deleate(ByVal intRow As Integer) As Boolean
        Dim Cmd As New OracleCommand
        Dim sSql As String = String.Empty
        Dim myTrans As Oracle.ManagedDataAccess.Client.OracleTransaction = Nothing
        Dim blnIsTran As Boolean = False

        Dim ret As Boolean = False

        Dim sTAX_DATE_FROM As String = String.Empty

        Dim dstDataSet As New DataSet

        Try
            '条件キーの取得
            sTAX_DATE_FROM = dgv_Search.Item(C_TAX_DATE_FROM, intRow).Value

            '和暦を西暦に
            sTAX_DATE_FROM = CType(sTAX_DATE_FROM, Date)

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Cmd.CommandText = "PKG_GJ8101.GJ8101_TAX_DEL"
            '引き渡し
            Dim paraTAX_DATE_FROM As OracleParameter = Cmd.Parameters.Add("IN_TAX_TAX_DATE_FROM", sTAX_DATE_FROM.Trim)

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Show_MessageBox("", Cmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            If ex.Message <> "Err" Then
                Show_MessageBox("", ex.Message)
            End If
            'RollBack
            If blnIsTran = True Then
                myTrans.Rollback()
            End If
        End Try

        Return ret

    End Function
#End Region

#End Region

End Class
