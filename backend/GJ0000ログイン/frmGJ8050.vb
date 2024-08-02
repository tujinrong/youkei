'*******************************************************************************
'*　　①　フォーム名　　　  frmGJ8050.vb
'*
'*　　②　機能概要　　　　　金融機関マスタ一覧
'*
'*　　③　作成日　　　　　　2011/12/16  BY JBD200
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

Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.ActiveReports.Export
Imports GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport

Imports System.IO
Imports JbdGjsReport

Public Class frmGJ8050

#Region "*** 変数定義 ***"
    Public pApName As String = "GJ8050"                 'プログラムＩＤ
    Public pRptName As String = "金融機関マスタ"            '帳票名
    Public pUKEIRE_YMDHMS As String = String.Empty      '処理開始時間
    Public pPCNAME As String = String.Empty             '端末ＩＤ
    Public pCNT As Integer = 0                          '帳票出力件数
    Public pKEY As String = String.Empty
    'Public rpt As New rptGJ8050
    Private pJoken As String = String.Empty             '検索結果一覧セット用検索条件（金融機関）
    Private pDataSet As New DataSet                     '検索結果一覧セット用データセット（金融機関）
    Private pJoken2 As String = String.Empty            '検索結果一覧セット用検索条件（支店）
    Private pJoken2_BANK_CD As String = String.Empty
    Private pDataSet2 As New DataSet                    '検索結果一覧セット用データセット（支店）
    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ

    Public Const C_INSERT As Integer = 0                '新規処理
    Public Const C_UPDATE As Integer = 1                '変更処理
    Public Const C_TEST As Integer = 1                  '変更処理

    Private Const C_BANK_DATA_KBN As Integer = 0        'データ区分
    Private Const C_BANK_CD As Integer = 1              '金融機関コード
    Private Const C_BANK_KANA As Integer = 2            '金融機関（ｶﾅ）
    Private Const C_BANK_NAME As Integer = 3            '金融機関（漢字）

    Private Const C_SITEN_DATA_KBN As Integer = 0       'データ区分
    Private Const C_SITEN_BANK_CD As Integer = 1        '金融機関コード
    Private Const C_SITEN_CD As Integer = 2             '支店コード
    Private Const C_SITEN_KANA As Integer = 3           '支店名（ｶﾅ）
    Private Const C_SITEN_NAME As Integer = 4           '支店名（漢字）

    'グリッドキー項目構造体
    Public Class T_KEY
        Public strBANK_DATA_KBN As String = String.Empty
        Public strBANK_CD As String = String.Empty
        Public strBANK_KANA As String = String.Empty
        Public strBANK_NAME As String = String.Empty
        Public blnBANK_CHG_FLG As Boolean
    End Class

    Public Class T_KEY2
        Public strSITEN_DATA_KBN As String = String.Empty
        Public strSITEN_BANK_CD As String = String.Empty
        Public strSITEN_CD As String = String.Empty
        Public strSITEN_KANA As String = String.Empty
        Public strSITEN_NAME As String = String.Empty
        Public blnSITEN_CHG_FLG As Boolean
    End Class

    Public paryKEY_8051 As New ArrayList
    Public paryKEY_8052 As New ArrayList

    Public pSaveFlg As Boolean = False
    Public pSaveBANK_CD As String = String.Empty
    Public pSaveSITEN_BANK_CD As String = String.Empty
    Public pSaveSITEN_CD As String = String.Empty

#End Region

#Region "*** 画面制御関連 ***"

#Region "frmGJ8050_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ8050_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ8050_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ret As Boolean
        Try

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear()
            ret = f_LblBackColor()

            'コンピュータ名取得
            pPCNAME = System.Net.Dns.GetHostName

            'データ区分：有効にフォーカスセット
            rbtn_DATA_KBN1.Focus()
            rbtn_DATA_KBN3.Focus()

            pblnTextChange = False             '画面入力内容変更フラグ初期化

        Catch ex As Exception
            If ex.Message <> "Err" Then
                '共通例外処理
                Show_MessageBox("", ex.Message)
            End If

            'フォームクローズ
            Me.Close()
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region
#Region "frmGJ8050_Disposed Form_Disposedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ8050_Disposed
    '説明            :Form_Disposedイベント
    '------------------------------------------------------------------
    Private Sub frmGJ8050_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        ''pDataSet.Clear()
        ''pDataSet.Dispose()

        ''pDataSet2.Clear()
        ''pDataSet2.Dispose()

    End Sub

#End Region
#Region "f_ObjectClear 画面クリア処理（金融機関、支店）"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ObjectClear
    '説明            :画面クリア処理（金融機関、支店）
    '引数            :rKbn(処理区分)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ObjectClear() As Boolean

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '金融機関（上部）
            rbtn_DATA_KBN1.Checked = True
            rbtn_DATA_KBN2.Checked = False
            txt_BANK_CD.Text = ""
            txt_BANK_KANA.Text = ""
            txt_BANK_NAME.Text = ""

            rbtn_Search1.Checked = True
            rbtn_Search2.Checked = False

            lblCOUNT.Text = "0"

            paryKEY_8051 = New ArrayList

            pJoken = ""
            pDataSet.Clear()

            'ボタン使用不可
            f_Cmd_Set(False)

            '支店（下部）クリア
            f_ObjectClear2()

            f_ObjectClear = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally

            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Function
#End Region
#Region "f_ObjectClear2 画面クリア処理（支店）"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ObjectClear2
    '説明            :画面クリア処理（支店）
    '引数            :rKbn(処理区分)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ObjectClear2() As Boolean

        f_ObjectClear2 = False

        Try

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '支店（下部）
            rbtn_DATA_KBN3.Checked = True
            rbtn_DATA_KBN4.Checked = False
            txt_SITEN_CD.Text = ""
            txt_SITEN_KANA.Text = ""
            txt_SITEN_NAME.Text = ""

            rbtn_Search3.Checked = True
            rbtn_Search4.Checked = False

            lblCOUNT2.Text = "0"

            paryKEY_8052 = New ArrayList

            pJoken2 = ""
            pJoken2_BANK_CD = ""
            pDataSet2.Clear()

            '支店ボタン使用不可
            f_Cmd_Set2(False)

            If dgv_Search.RowCount = 0 Then
                '支店情報入力不可
                Panel3.Enabled = False
            Else
                '支店情報入力可
                Panel3.Enabled = True
            End If


            f_ObjectClear2 = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Function

#End Region
#Region "f_LblBackColor メインフォームと同一色のラベルセット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_LblBackColor
    '説明            :メインフォームと同一色のラベルセット
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '追加            :2015/01/19
    '------------------------------------------------------------------
    Private Function f_LblBackColor() As Boolean

        f_LblBackColor = False

        Try

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '銀行部分
            lbl_BANK_CD.BackColor = Me.BackColor
            lbl_BANK_KANA.BackColor = Me.BackColor
            lbl_BANK_NAME.BackColor = Me.BackColor
            lbl_DATA_KBN1.BackColor = Me.BackColor
            '支店部分
            lbl_SITEN_CD.BackColor = Me.BackColor
            lbl_SITEN_KANA.BackColor = Me.BackColor
            lbl_SITEN_NAME.BackColor = Me.BackColor
            lbl_DATA_KBN3.BackColor = Me.BackColor

            f_LblBackColor = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Function

#End Region

#End Region

#Region "*** 画面ボタンクリック関連 ***"

#Region "cmdSearch_Click 検索ボタンクリック処理（金融機関）"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSearch_Click
    '説明            :検索ボタンクリック処理（金融機関）
    '------------------------------------------------------------------
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click

        Dim sSql As String = String.Empty

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '検索処理
            pJoken = ""
            pDataSet.Clear()
            pJoken2 = ""
            pJoken2_BANK_CD = ""
            pDataSet2.Clear()

            '検索条件セット
            If Not f_Search_Joken() Then
                Exit Try
            End If
            '金融機関グリッドビューセット
            pSaveBANK_CD = ""
            If Not f_GridView_Set() Then
                Exit Try
            End If

            '支店情報クリア
            If Not f_ObjectClear2() Then
                Exit Try
            End If

            If dgv_Search.RowCount = 0 Then
                'データ存在なし
                Show_MessageBox("I003", "")       '指定された条件に一致するデータは存在しません。
                pDataSet.Clear()
                lblCOUNT.Text = "0"
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
#Region "cmdSearch2_Click 検索ボタンクリック処理（支店）"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSearch2_Click
    '説明            :検索ボタンクリック処理（支店）
    '------------------------------------------------------------------
    Private Sub cmdSearch2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch2.Click

        Dim tKEY As New T_KEY
        Dim strBANK_CD As String = String.Empty
        Dim intNo As Integer = 0

        Dim sSql As String = String.Empty

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '検索処理
            pDataSet2.Clear()
            ''sSql = f_Search_SQLMake2()
            ''If Not f_Select_ODP(pDataSet2, sSql) Then
            ''    Exit Try
            ''End If

            ''If pDataSet2.Tables(0).Rows.Count > 0 Then

            ''    '支店・支所グリッドビューセット
            ''    pSaveSITEN_BANK_CD = ""
            ''    pSaveSITEN_CD = ""
            ''    If Not f_GridView_Set2() Then
            ''        Exit Try
            ''    End If

            ''Else
            ''    'データ存在なし
            ''    Show_MessageBox("I003", "")       '指定された条件に一致するデータは存在しません。
            ''    pDataSet.Clear()
            ''    lblCOUNT.Text = "0"

            ''    'コントロール使用不可（支店）
            ''    Panel3.Enabled = False

            ''    Exit Sub
            ''End If


            '検索条件セット
            If Not f_Search_Joken2() Then
                Exit Try
            End If
            '支店・支所グリッドビューセット
            pSaveSITEN_BANK_CD = ""
            pSaveSITEN_CD = ""
            If Not f_GridView_Set2() Then
                Exit Try
            End If

            If dgv_Search2.RowCount = 0 Then
                'データ存在なし
                Show_MessageBox("I003", "")       '指定された条件に一致するデータは存在しません。
                pDataSet2.Clear()
                lblCOUNT2.Text = "0"
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

#Region "cmdDel_Click 削除ボタンクリック処理（金融機関）"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdDel_Click
    '説明            :削除ボタンクリック処理（金融機関）
    '------------------------------------------------------------------
    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")       'データが選択されていません。
                Exit Try
            End If

            '削除処理確認
            If Show_MessageBox_Add("Q006", "指定されたデータ") = DialogResult.No Then    '指定されたデータを削除します。よろしいですか？
                '「いいえ」を選択
                Exit Try
            End If

            'カレントン金融機関セーブ
            If dgv_Search.RowCount = 0 Then
                pSaveBANK_CD = String.Empty
            Else
                pSaveBANK_CD = dgv_Search.Item(C_BANK_CD, dgv_Search.CurrentRow.Index).Value
            End If

            Dim intRow As Integer = 0       '行番号

            For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
                intRow = gRow.Index
            Next

            '該当データ削除処理
            If Not f_TM_BANK_Delete(intRow) Then
                Exit Try
            End If

            'グリッドビューセット
            If Not f_GridView_Set() Then
                Exit Try
            End If

            '支店情報クリア
            If Not f_ObjectClear2() Then
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
#Region "cmdDel2_Click 削除ボタンクリック処理（支店）"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdDel2_Click
    '説明            :削除ボタンクリック処理（支店）
    '------------------------------------------------------------------
    Private Sub cmdDel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel2.Click

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor


        Try
            '一覧より選択されていなければエラー
            If dgv_Search2.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")       'データが選択されていません。
                Exit Try
            End If

            '削除処理確認
            If Show_MessageBox_Add("Q006", "指定されたデータ") = DialogResult.No Then    '指定されたデータを削除します。よろしいですか？
                '「いいえ」を選択
                Exit Try
            End If

            'カレント金融機関・支店セーブ
            If dgv_Search.RowCount = 0 Then
                pSaveSITEN_BANK_CD = String.Empty
                pSaveSITEN_CD = String.Empty
            Else
                pSaveSITEN_BANK_CD = dgv_Search2.Item(C_SITEN_BANK_CD, dgv_Search2.CurrentRow.Index).Value
                pSaveSITEN_CD = dgv_Search2.Item(C_SITEN_CD, dgv_Search2.CurrentRow.Index).Value
            End If

            Dim intRow As Integer = 0       '行番号

            For Each gRow As DataGridViewRow In dgv_Search2.SelectedRows
                intRow = gRow.Index
            Next

            '該当データ削除処理
            If Not f_TM_SITEN_Delete(intRow) Then
                Exit Try
            End If

            '支店グリッドビューセット
            If Not f_GridView_Set2() Then
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

#Region "cmdIns_Click 新規入力ボタンクリック処理（金融機関）"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdIns_Click
    '説明            :新規入力ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIns.Click
        Dim tKEY As New T_KEY

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            'カレントン金融機関セーブ
            If dgv_Search.RowCount = 0 Then
                pSaveBANK_CD = String.Empty
            Else
                pSaveBANK_CD = dgv_Search.Item(C_BANK_CD, dgv_Search.CurrentRow.Index).Value
            End If

            '登録データ格納用の構造体を作成
            paryKEY_8051 = New ArrayList
            tKEY = New T_KEY
            pSaveFlg = False
            paryKEY_8051.Add(tKEY)

            'メンテナンス画面　表示
            Dim form As New frmGJ8051
            form.Owner = Me                         '2010/10/16 ADD JBD200
            form.pSyoriKbn = frmGJ8051.C_INSERT
            form.paryKEY_8051 = paryKEY_8051
            form.pSel_BANKCD = pSaveBANK_CD

            form.ShowDialog()

            '金融機関グリッドビューセット
            If Not f_GridView_Set() Then
                Exit Try
            End If

            '支店情報クリア
            If Not f_ObjectClear2() Then
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
#Region "cmdIns2_Click 新規入力ボタンクリック処理（支店）"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdIns2_Click
    '説明            :新規入力ボタンクリック処理（支店）
    '------------------------------------------------------------------
    Private Sub cmdIns2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIns2.Click

        Dim tKEY2 As New T_KEY2
        Dim strBANK_CD As String = String.Empty

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try


            'カレントユーザーＩＤセーブ
            If dgv_Search2.RowCount = 0 Then
                If pJoken2_BANK_CD = "" Then
                    '検索クリア後
                    pSaveSITEN_BANK_CD = dgv_Search.Item(C_BANK_CD, dgv_Search.CurrentRow.Index).Value  '選択された金融機関
                Else
                    '前回押下後
                    pSaveSITEN_BANK_CD = pJoken2_BANK_CD    '前回検索した金融機関
                End If
                pSaveSITEN_CD = String.Empty
            Else
                pSaveSITEN_BANK_CD = dgv_Search2.Item(C_SITEN_BANK_CD, dgv_Search2.CurrentRow.Index).Value
                pSaveSITEN_CD = dgv_Search2.Item(C_SITEN_CD, dgv_Search2.CurrentRow.Index).Value
            End If

            '登録データ格納用の構造体を作成
            paryKEY_8052 = New ArrayList
            tKEY2 = New T_KEY2
            pSaveFlg = False
            paryKEY_8052.Add(tKEY2)

            'メンテナンス画面　表示
            Dim form As New frmGJ8052
            form.Owner = Me                         '2010/10/16 ADD JBD200
            form.pSyoriKbn = frmGJ8052.C_INSERT
            form.paryKEY_8052 = paryKEY_8052
            form.pSel_SITEN_BANKCD = pSaveSITEN_BANK_CD     '現在選択されている行のキーを渡します
            form.pSel_SITENCD = pSaveSITEN_CD               '現在選択されている行のキーを渡します

            form.ShowDialog()

            'グリッドビューセット
            If Not f_GridView_Set2() Then
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

#Region "cmdUpd_Click 変更ボタンクリック処理（金融機関）"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdUpd_Click
    '説明            :変更ボタンクリック処理（金融機関）
    '------------------------------------------------------------------
    Private Sub cmdUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpd.Click

        Dim tKEY As New T_KEY
        Dim strBANK_CD As String = String.Empty
        Dim intNo As Integer = 0


        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")       'データが選択されていません。
                Exit Try
            End If

            'カレント金融機関セーブ
            If dgv_Search.RowCount = 0 Then
                pSaveBANK_CD = String.Empty         '金融機関情報
            Else
                pSaveBANK_CD = dgv_Search.Item(C_BANK_CD, dgv_Search.CurrentRow.Index).Value                '金融機関情報
            End If

            'グリッドの金融機関コードを構造体に格納
            paryKEY_8051 = New ArrayList
            For i As Integer = 0 To dgv_Search.RowCount - 1
                tKEY = New T_KEY
                tKEY.strBANK_CD = dgv_Search.Item(C_BANK_CD, i).Value
                If dgv_Search.Rows(i).Selected Then
                    strBANK_CD = tKEY.strBANK_CD
                    intNo = i + 1
                End If
                paryKEY_8051.Add(tKEY)
            Next

            'グリッドのユーザーIDを構造体に格納
            paryKEY_8051 = New ArrayList
            For i As Integer = 0 To dgv_Search.RowCount - 1
                tKEY = New T_KEY
                tKEY.strBANK_DATA_KBN = WordHenkan("N", "S", dgv_Search.Item(C_BANK_DATA_KBN, i).Value)
                tKEY.strBANK_CD = WordHenkan("N", "S", dgv_Search.Item(C_BANK_CD, i).Value)
                tKEY.strBANK_NAME = WordHenkan("N", "S", dgv_Search.Item(C_BANK_NAME, i).Value)
                tKEY.strBANK_KANA = WordHenkan("N", "S", dgv_Search.Item(C_BANK_KANA, i).Value)
                tKEY.blnBANK_CHG_FLG = False
                If dgv_Search.Rows(i).Selected Then
                    strBANK_CD = tKEY.strBANK_CD    '現在選択されている行のキー
                    intNo = i + 1                   '現在選択されている行の位置
                End If
                paryKEY_8051.Add(tKEY)
            Next

            Dim form As New frmGJ8051
            form.Owner = Me                         '2010/10/16 ADD JBD200
            form.pSel_BANKCD = strBANK_CD            '現在選択されている行のキーを渡します
            form.pSel_NO = intNo                    '現在選択されている行のキーを渡します
            form.pSyoriKbn = frmGJ8051.C_UPDATE
            form.paryKEY_8051 = paryKEY_8051

            form.ShowDialog()

            '金融機関グリッドビューセット
            If Not f_GridView_Set() Then
                Exit Try
            End If

            ' ''支店グリッドビューセット
            ''If Not f_GridView_Set2() Then
            ''    Exit Try
            ''End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region
#Region "cmdUpd2_Click 変更ボタンクリック処理（支店）"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdUpd2_Click
    '説明            :変更ボタンクリック処理（支店）
    '------------------------------------------------------------------
    Private Sub cmdUpd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpd2.Click

        Dim tKEY2 As New T_KEY2
        Dim strBANK_CD As String = String.Empty
        Dim strSITEN_CD As String = String.Empty
        Dim intNo As Integer = 0


        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '一覧より選択されていなければエラー
            If dgv_Search2.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")       'データが選択されていません。
                Exit Try
            End If

            'カレント金融機関セーブ
            If dgv_Search.RowCount = 0 Then
                pSaveBANK_CD = dgv_Search.Item(C_BANK_CD, dgv_Search.CurrentRow.Index).Value                '金融機関情報
                pSaveSITEN_BANK_CD = String.Empty   '支店情報
                pSaveSITEN_CD = String.Empty        '支店情報
            Else
                pSaveBANK_CD = dgv_Search.Item(C_BANK_CD, dgv_Search.CurrentRow.Index).Value                '金融機関情報
                pSaveSITEN_BANK_CD = dgv_Search2.Item(C_SITEN_BANK_CD, dgv_Search2.CurrentRow.Index).Value  '支店情報
                pSaveSITEN_CD = dgv_Search2.Item(C_BANK_CD, dgv_Search2.CurrentRow.Index).Value             '支店情報
            End If

            'グリッドの金融機関コード、支店コードを構造体に格納
            paryKEY_8052 = New ArrayList
            For i As Integer = 0 To dgv_Search2.RowCount - 1
                tKEY2 = New T_KEY2
                tKEY2.strSITEN_BANK_CD = dgv_Search2.Item(C_SITEN_BANK_CD, i).Value
                tKEY2.strSITEN_CD = dgv_Search2.Item(C_SITEN_CD, i).Value
                If dgv_Search2.Rows(i).Selected Then
                    strBANK_CD = tKEY2.strSITEN_BANK_CD
                    strSITEN_CD = tKEY2.strSITEN_CD
                    intNo = i + 1
                End If
                paryKEY_8052.Add(tKEY2)
            Next

            Dim form As New frmGJ8052
            form.Owner = Me                                 '2010/10/16 ADD JBD200
            form.pSel_SITEN_BANKCD = strBANK_CD            '現在選択されている行のキーを渡します
            form.pSel_SITENCD = strSITEN_CD        '現在選択されている行のキーを渡します
            form.pSel_NO = intNo                    '現在選択されている行のキーを渡します
            form.pSyoriKbn = frmGJ8052.C_UPDATE
            form.paryKEY_8052 = paryKEY_8052

            form.ShowDialog()

            '支店グリッドビューセット
            If Not f_GridView_Set2() Then
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

#Region "cmdPreview_Click プレビューボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdPreview_Click
    '説明            :プレビューボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        Try

            'マウスカーソルを砂時計に変更
            Me.Cursor = Cursors.WaitCursor

            pCNT = 0
            pKEY = ""       '変数初期化

            '必須入力チェック
            If dgv_Search.RowCount = 0 Then
                Show_MessageBox("W011", "")       'データが選択されていません。
                Exit Try
            End If

            '帳票出力処理
            If Not f_Report_Output() Then
                Exit Try
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        'カーソルをデフォルトに戻す
        Me.Cursor = Cursors.Default

    End Sub
#End Region
#Region "cmdPreview_Click2 プレビューボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdPreview_Click
    '説明            :プレビューボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdPreview_Click2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview2.Click
        Try

            'マウスカーソルを砂時計に変更
            Me.Cursor = Cursors.WaitCursor

            pCNT = 0
            pKEY = ""       '変数初期化

            '必須入力チェック
            'If dgv_Search.RowCount = 0 Then    '2015/01/19　修正
            If dgv_Search2.RowCount = 0 Then    '2015/01/19　修正
                Show_MessageBox("W011", "")     'データが選択されていません。
                Exit Try
            End If

            '帳票出力処理
            If Not f_Report_Output2() Then
                Exit Try
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        'カーソルをデフォルトに戻す
        Me.Cursor = Cursors.Default

    End Sub
#End Region

#Region "cmdCan_Click キャンセルボタンクリック処理（金融機関）"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdCan_Click
    '説明            :キャンセルボタンクリック処理（金融機関）
    '------------------------------------------------------------------
    Private Sub cmdCan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCan.Click

        Dim ret As Boolean

        ret = f_ObjectClear()

        'データ区分にフォーカスセット
        rbtn_DATA_KBN1.Focus()

    End Sub
#End Region
#Region "cmdCan2_Click キャンセルボタンクリック処理（支店）"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdCan2_Click
    '説明            :キャンセルボタンクリック処理（支店）
    '------------------------------------------------------------------
    Private Sub cmdCan2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCan2.Click

        f_ObjectClear2()

        'データ区分にフォーカスセット
        rbtn_DATA_KBN3.Focus()

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
                'If Show_MessageBox("処理を終了しますか？", C_MSGICON_QUESTION) = Windows.Forms.DialogResult.Yes Then
                '処理を終了しますか？
                Exit Try
            End If

            'フォームクローズ
            Me.AutoValidate = AutoValidate.Disable      '2010/10/16 ADD JBD200
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

#Region "*** 画面コントロール制御関連 ***"

#End Region

#Region "*** データベース制御関連 ***"

#Region "f_TM_BANK_Delete 金融機関マスタデータ削除"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_BANK_Delete
    '説明            :金融機関マスタデータ削除
    '引数            :1.intRow      Integer     選択されている行番号
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_BANK_Delete(ByVal intRow As Integer) As Boolean
        Dim Cmd As New OracleCommand
        Dim sSql As String = String.Empty
        Dim myTrans As Oracle.ManagedDataAccess.Client.OracleTransaction = Nothing
        Dim blnIsTran As Boolean = False

        Dim ret As Boolean = False

        Dim sBANK_CD As String = String.Empty

        Dim dstDataSet As New DataSet

        Try

            '条件キーの取得
            sBANK_CD = dgv_Search.Item(C_BANK_CD, intRow).Value

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Cmd.CommandText = "PKG_GJ8051.GJ8051_BANK_DEL"
            '引き渡し
            Dim paraBANK_CD As OracleParameter = Cmd.Parameters.Add("IN_BANK_BANK_CD", sBANK_CD.Trim)       '金融機関

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()

            If p_MSGCD.Value.ToString = "0" Then
                '正常
            Else
                Show_MessageBox("", p_MSGNM.Value.ToString)
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            If ex.Message <> "Err" Then
                Show_MessageBox("", ex.Message)
            End If
        Finally

            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If

        End Try

        Return ret

    End Function
#End Region
#Region "f_TM_SITEN_Delete 支店マスタデータ削除(支店単位)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_SITEN_Delete
    '説明            :支店マスタデータ削除(支店単位)
    '引数            :1.intRow      Integer     選択されている行番号
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TM_SITEN_Delete(ByVal intRow As Integer) As Boolean

        Dim Cmd As New OracleCommand
        Dim sSql As String = String.Empty
        Dim myTrans As Oracle.ManagedDataAccess.Client.OracleTransaction = Nothing
        Dim blnIsTran As Boolean = False

        Dim ret As Boolean = False

        Dim sSITENBANKCD As String = String.Empty
        Dim sSITENCD As String = String.Empty

        Dim dstDataSet As New DataSet

        Try

            '条件キーの取得
            sSITENBANKCD = dgv_Search2.Item(C_SITEN_BANK_CD, intRow).Value
            sSITENCD = dgv_Search2.Item(C_SITEN_CD, intRow).Value

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Cmd.CommandText = "PKG_GJ8052.GJ8052_SITEN_DEL"

            '引き渡し
            Dim paraBANKCD As OracleParameter = Cmd.Parameters.Add("IN_SITEN_BANK_CD", sSITENBANKCD.Trim)    '金融機関
            Dim paraSITENCD As OracleParameter = Cmd.Parameters.Add("IN_SITEN_BANK_CD", sSITENCD.Trim)       '支店コード

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()

            If p_MSGCD.Value.ToString = "0" Then
                '正常
            Else
                Show_MessageBox("", p_MSGNM.Value.ToString)
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            If ex.Message <> "Err" Then
                Show_MessageBox("", ex.Message)
            End If
        Finally

            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If

        End Try

        Return ret

    End Function
#End Region

#Region "f_Data_Insert(未使用) "
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Insert
    '説明            :データ更新処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Insert() As Boolean
        Dim sSql As String
        Dim myTrans As Oracle.ManagedDataAccess.Client.OracleTransaction = Nothing
        Dim blnIsTran As Boolean = False

        f_Data_Insert = False

        Try
            myTrans = Cnn.BeginTransaction()
            blnIsTran = True

            'ログ更新--------------------------------------------------------------------

            sSql = vbNullString
            sSql = " INSERT INTO TM_SYORI_RIREKI" & vbCrLf
            sSql = sSql & "(" & vbCrLf
            sSql = sSql & "  SEQNO," & vbCrLf
            sSql = sSql & "  SYORI_START_DATE," & vbCrLf
            sSql = sSql & "  SYORI_END_DATE," & vbCrLf
            sSql = sSql & "  PG_CD," & vbCrLf
            sSql = sSql & "  SYORI1_CNT," & vbCrLf
            sSql = sSql & "  SYORI2_CNT," & vbCrLf
            sSql = sSql & "  SYORI3_CNT," & vbCrLf
            sSql = sSql & "  MESSAGE1," & vbCrLf
            sSql = sSql & "  MESSAGE2," & vbCrLf
            sSql = sSql & "  MESSAGE3," & vbCrLf
            sSql = sSql & "  REG_DATE," & vbCrLf
            sSql = sSql & "  UP_DATE," & vbCrLf
            sSql = sSql & "  DATA_KBN" & vbCrLf
            sSql = sSql & ")" & vbCrLf
            sSql = sSql & "  VALUES" & vbCrLf
            sSql = sSql & "(" & vbCrLf
            sSql = sSql & "SEQ_SYORI_RIREKI.NEXTVAL," & vbCrLf                                          'SEQNO
            sSql = sSql & "TO_DATE('" & pUKEIRE_YMDHMS & "','yyyy/mm/dd hh24:mi:ss')," & vbCrLf   '処理開始日時
            sSql = sSql & "TO_DATE('" & System.DateTime.Now & "','yyyy/mm/dd hh24:mi:ss')," & vbCrLf     '処理終了日時
            sSql = sSql & "'" & pApName & "',"                                                          'プログラムＩＤ
            sSql = sSql & "NULL,"
            sSql = sSql & "NULL,"
            sSql = sSql & "NULL,"
            sSql = sSql & "NULL,"
            sSql = sSql & "NULL,"
            sSql = sSql & "NULL,"
            sSql = sSql & "TO_DATE('" & System.DateTime.Now & "','yyyy/mm/dd hh24:mi:ss')," & vbCrLf
            sSql = sSql & "NULL,"
            sSql = sSql & "0"
            sSql = sSql & ")"

            Call f_ExecuteSQLODP(sSql)
            myTrans.Commit()        'コミット

            f_Data_Insert = True

        Catch ex As Exception

            'エラーの内容を表示
            Show_MessageBox("", Err.Description)
            'Err オブジェクトのすべてのプロパティの設定値をクリアします
            Err.Clear()

            'RollBack
            If blnIsTran = True Then
                myTrans.Rollback()
            End If

            'データベースへの接断
            Cnn.Close()
            ''フォームクローズ
            'Me.Close()

        End Try

        Exit Function

    End Function
#End Region

#End Region

#Region "*** ローカル関数 ***"

#Region "f_GridView_Set 金融機関グリッドビューセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridView_Set
    '説明            :金融機関グリッドビューセット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_GridView_Set() As Boolean
        Dim sSql As String = String.Empty
        Dim ret As Boolean = False

        Try
            '検索処理
            pDataSet.Clear()
            sSql = f_Search_SQLMake()
            If Not f_Select_ODP(pDataSet, sSql) Then
                Exit Try
            End If

            If pDataSet.Tables(0).Rows.Count > 0 Then

                '画面に該当データを表示
                dgv_Search.DataSource = pDataSet.Tables(0)
                lblCOUNT.Text = pDataSet.Tables(0).Rows.Count

                'コントロール使用可（支店）
                Panel2.Enabled = True

            Else
                'コントロール使用不可（支店）
                Panel2.Enabled = False

            End If

            'カーソルセット
            If Not f_GridRow_Set(pSaveBANK_CD) Then
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
#Region "f_GridRow_Set 金融機関グリッドビュー現在行セット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridRow_Set
    '説明            :金融機関グリッドビュー現在行セット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_GridRow_Set(ByVal wBANK_CD As String) As Boolean
        Dim ret As Boolean = False
        Dim wIdx As Integer = 0

        Try

            If dgv_Search.RowCount = 0 Then
                '表示データなし
                'ボタン使用不可
                f_Cmd_Set(False)

                'データなしの時、新規登録ボタンへ
                cmdIns.Focus()
            Else
                '表示データあり
                '登録のとき、登録したユーザＩＤに位置づけ
                '変更のとき、変更したユーザＩＤに位置づけ
                '削除のとき、削除したユーザＩＤにの次のユーザＩＤに位置づけ
                '　　　　　　削除したユーザＩＤが最終行の場合は、最終行に位置づけ
                For i As Integer = 0 To dgv_Search.RowCount - 1
                    wIdx = i
                    If dgv_Search.Item(C_BANK_CD, i).Value >= wBANK_CD Then
                        Exit For
                    End If
                Next
                '変更、削除ボタン　有効
                f_Cmd_Set(True)
                'カーソルセット
                dgv_Search.CurrentCell = dgv_Search.Rows(wIdx).Cells(1)

            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_GridView_Set 支店グリッドビューセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridView_Set2
    '説明            :支店グリッドビューセット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_GridView_Set2() As Boolean
        Dim sSql As String = String.Empty
        Dim ret As Boolean = False

        Try

            '検索処理
            pDataSet2.Clear()
            sSql = f_Search_SQLMake2()
            If Not f_Select_ODP(pDataSet2, sSql) Then
                Exit Try
            End If

            If pDataSet2.Tables(0).Rows.Count > 0 Then

                '画面に該当データを表示
                dgv_Search2.DataSource = pDataSet2.Tables(0)
                lblCOUNT2.Text = pDataSet2.Tables(0).Rows.Count

            Else
                '処理なし
            End If

            'カーソルセット
            If Not f_GridRow_Set2(pSaveSITEN_BANK_CD, pSaveSITEN_CD) Then
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
#Region "f_GridRow_Set 支店グリッドビュー現在行セット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridRow_Set2
    '説明            :支店グリッドビュー現在行セット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_GridRow_Set2(ByVal wSITEN_BANK_CD As String, ByVal wSITEN_CD As String) As Boolean
        Dim ret As Boolean = False
        Dim wIdx As Integer = 0

        Try

            If dgv_Search2.RowCount = 0 Then
                '表示データなし
                '支店ボタン使用不可
                f_Cmd_Set2(False)
            Else
                '表示データあり
                '登録のとき、登録したユーザＩＤに位置づけ
                '変更のとき、変更したユーザＩＤに位置づけ
                '削除のとき、削除したユーザＩＤにの次のユーザＩＤに位置づけ
                '　　　　　　削除したユーザＩＤが最終行の場合は、最終行に位置づけ
                For i As Integer = 0 To dgv_Search2.RowCount - 1
                    wIdx = i
                    If dgv_Search2.Item(C_SITEN_CD, i).Value >= wSITEN_CD Then
                        Exit For
                    End If
                Next

                '支店ボタン使用可
                f_Cmd_Set2(True)
                'カーソルセット
                dgv_Search2.CurrentCell = dgv_Search2.Rows(wIdx).Cells(1)

            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Search_Joken 検索条件作成（金融機関）"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_Joken
    '説明            :f_Search_Joken 検索条件作成（金融機関）"
    '引数            :なし
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    Private Function f_Search_Joken() As Boolean
        Dim ret As Boolean = False
        Dim strW2 As String = String.Empty

        Try

            'WHERE句の AND条件、OR条件の判定

            If rbtn_Search1.Checked Then
                '検索方法で[すべてを含む]を選択
                strW2 = " AND" & vbCrLf
            Else
                '検索方法で[いずれかを含む]を選択
                strW2 = " OR" & vbCrLf
            End If

            pJoken = ""

            '検索
            ' 生産者積立金負担有無は検索条件として省略できないので固定条件として編集
            ''If rbtn_DATA_KBN1.Checked Then
            ''    pJoken += "   (BNK.DATA_KBN = 0)" & vbCrLf
            ''Else
            ''    pJoken += "   (BNK.DATA_KBN = 1)" & vbCrLf
            ''End If

            '金融機関
            If txt_BANK_CD.Text.TrimEnd <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += strW2 & vbCrLf
                End If
                pJoken += "(BNK.BANK_CD  LIKE '" & txt_BANK_CD.Text.TrimEnd & "%')" & vbCrLf
            End If

            '金融機関名(カナ)
            If txt_BANK_KANA.Text.TrimEnd <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += strW2 & vbCrLf
                End If
                pJoken += "(BNK.BANK_KANA LIKE '" & txt_BANK_KANA.Text.TrimEnd & "%')" & vbCrLf
            End If
            '金融機関名(漢字)
            If txt_BANK_NAME.Text.TrimEnd <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += strW2 & vbCrLf
                End If
                pJoken += "(BNK.BANK_NAME LIKE '" & txt_BANK_NAME.Text.TrimEnd & "%')" & vbCrLf
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_Search_SQLMake 検索結果出力用ＳＱＬ作成（金融機関）"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :検索結果出力用ＳＱＬ作成（金融機関）
    '引数            :なし
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    Private Function f_Search_SQLMake() As String
        Dim sSql As String = String.Empty
        'Dim sWhere As String = String.Empty
        'Dim strER As String = String.Empty
        'Dim strW1 As String = String.Empty
        Dim strW2 As String = String.Empty

        Try

            sSql = " SELECT"
            'sSql = sSql & " DECODE(TM.DATA_KBN,0,'有効',1,'無効','') DATA_KBN," & vbCrLf         'データ区分
            sSql = sSql & " BNK.BANK_CD," & vbCrLf          '金融機関コード
            sSql = sSql & " BNK.BANK_KANA," & vbCrLf        '金融機関名（ｶﾅ）
            sSql = sSql & " BNK.BANK_NAME" & vbCrLf         '金融機関名（漢字）
            sSql = sSql & " FROM" & vbCrLf
            sSql = sSql & " TM_BANK BNK" & vbCrLf
            'sSql = sSql & " WHERE" & vbCrLf

            'WHERE句の AND条件、OR条件の判定

            If rbtn_Search1.Checked Then
                '検索方法で[すべてを含む]を選択
                strW2 = " AND" & vbCrLf
            Else
                '検索方法で[いずれかを含む]を選択
                strW2 = " OR" & vbCrLf
            End If

            '検索
            ' 生産者積立金負担有無は検索条件として省略できないので固定条件として編集
            ''If rbtn_DATA_KBN1.Checked Then
            ''    sSql += "   (BNK.DATA_KBN = 0)" & vbCrLf
            ''Else
            ''    sSql += "   (BNK.DATA_KBN = 1)" & vbCrLf
            ''End If


            ' '' 以下は省略可能な条件なので指定されていた場合にのみ編集
            ' '' 但し、検索方法が全てを含むなのかいずれかを含むなのかによりstrW2の内容がANDかORに変わる
            ''pJoken = ""

            ' ''金融機関
            ''If txt_BANK_CD.Text.TrimEnd <> "" Then
            ''    If pJoken = "" Then
            ''    Else
            ''        pJoken += strW2 & vbCrLf
            ''    End If
            ''    pJoken += "(BNK.BANK_CD  LIKE '" & txt_BANK_CD.Text.TrimEnd & "%')" & vbCrLf
            ''End If

            ' ''金融機関名(カナ)
            ''If txt_BANK_KANA.Text.TrimEnd <> "" Then
            ''    If pJoken = "" Then
            ''    Else
            ''        pJoken += strW2 & vbCrLf
            ''    End If
            ''    pJoken += "(BNK.BANK_KANA LIKE '" & txt_BANK_KANA.Text.TrimEnd & "%')" & vbCrLf
            ''End If
            ' ''金融機関名(漢字)
            ''If txt_BANK_NAME.Text.TrimEnd <> "" Then
            ''    If pJoken = "" Then
            ''    Else
            ''        pJoken += strW2 & vbCrLf
            ''    End If
            ''    pJoken += "(BNK.txt_BANK_NAME LIKE '" & txt_BANK_NAME.Text.TrimEnd & "%')" & vbCrLf
            ''End If

            If pJoken = "" Then
            Else
                sSql += " WHERE (" & pJoken & ")" & vbCrLf
            End If

            sSql += "ORDER BY" & vbCrLf
            sSql += "  BNK.BANK_CD" & vbCrLf

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return sSql

    End Function
#End Region
#Region "f_Search_Joken2 検索条件作成（支店）"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_Joken2
    '説明            :f_Search_Joken2 検索条件作成（支店）"
    '引数            :なし
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    Private Function f_Search_Joken2() As Boolean
        Dim ret As Boolean = False
        Dim strW1 As String = String.Empty
        Dim strW2 As String = String.Empty
        'Dim strBANKCD As String = String.Empty

        Try
            '金融機関
            ''For i As Integer = 0 To dgv_Search.RowCount - 1
            ''    If dgv_Search.Rows(i).Selected Then
            ''        strBANKCD = dgv_Search.Item(C_BANK_CD, i).Value
            ''        Exit For
            ''    End If
            ''Next

            'WHERE句の AND条件、OR条件の判定
            If rbtn_Search3.Checked Then
                '検索方法で[すべてを含む]を選択
                strW2 = " AND"
            Else
                '検索方法で[いずれかを含む]を選択
                strW2 = " OR"
            End If

            '検索
            ' 生産者積立金負担有無は検索条件として省略できないので固定条件として編集
            ''If rbtn_Search3.Checked Then
            ''    pJoken += "   (STN.DATA_KBN = 0)" & vbCrLf
            ''Else
            ''    pJoken += "   (STN.DATA_KBN = 1)" & vbCrLf
            ''End If

            '検索方法が全てを含むなのかいずれかを含むなのかによりstrW2の内容がANDかORに変わる

            '支店・支所
            If txt_SITEN_CD.Text.TrimEnd <> "" Then
                If strW1 = "" Then
                Else
                    strW1 += strW2 & vbCrLf
                End If
                strW1 += "(STN.SITEN_CD LIKE '" & txt_SITEN_CD.Text.TrimEnd & "%')" & vbCrLf
            End If

            '支店・支所名(カナ)
            If txt_SITEN_KANA.Text.TrimEnd <> "" Then
                If strW1 = "" Then
                Else
                    strW1 += strW2 & vbCrLf
                End If
                strW1 += "(STN.SITEN_KANA LIKE '" & txt_SITEN_KANA.Text.TrimEnd & "%')" & vbCrLf
            End If

            '支店・支所名(漢字)
            If txt_SITEN_NAME.Text.TrimEnd <> "" Then
                If strW1 = "" Then
                Else
                    strW1 += strW2 & vbCrLf
                End If
                strW1 += "(STN.SITEN_NAME LIKE '" & txt_SITEN_NAME.Text.TrimEnd & "%')" & vbCrLf
            End If

            '条件結合
            pJoken2_BANK_CD = dgv_Search.Item(C_BANK_CD, dgv_Search.CurrentRow.Index).Value
            pJoken2 = " (STN.BANK_CD = " & dgv_Search.Item(C_BANK_CD, dgv_Search.CurrentRow.Index).Value & ")" & vbCrLf
            If strW1 = "" Then
            Else
                pJoken2 += " AND (" & strW1 & ")" & vbCrLf
            End If
            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_Search_SQLMake2 検索結果出力用ＳＱＬ作成（支店）"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake2
    '説明            :検索結果出力用ＳＱＬ作成（支店）
    '引数            :なし
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    Private Function f_Search_SQLMake2() As String
        Dim sSql As String = String.Empty
        'Dim sWhere As String = String.Empty
        Dim strER As String = String.Empty
        Dim strW1 As String = String.Empty
        Dim strW2 As String = String.Empty
        'Dim strBANKCD As String = String.Empty

        Try

            'WHERE句の AND条件、OR条件の判定
            If rbtn_Search3.Checked Then
                '検索方法で[すべてを含む]を選択
                strW2 = " AND"
            Else
                '検索方法で[いずれかを含む]を選択
                strW2 = " OR"
            End If

            '検索
            sSql = " SELECT " & vbCrLf
            'sSql += "  DECODE(S.DATA_KBN,0,'有効',1,'無効','') DATA_KBN," & vbCrLf
            sSql += "  STN.BANK_CD BANK_CD," & vbCrLf
            sSql += "  STN.SITEN_CD," & vbCrLf
            sSql += "  STN.SITEN_KANA," & vbCrLf
            sSql += "  STN.SITEN_NAME" & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_SITEN STN" & vbCrLf
            sSql += " WHERE" & vbCrLf
            'sSql += "      STN.BANK_CD = " & strBANKCD & vbCrLf

            'WHERE条件句を作成
            'sSql += " WHERE" & vbCrLf

            '検索
            ' 生産者積立金負担有無は検索条件として省略できないので固定条件として編集
            ''If rbtn_Search3.Checked Then
            ''    sSql += "   (STN.DATA_KBN = 0)" & vbCrLf
            ''Else
            ''    sSql += "   (STN.DATA_KBN = 1)" & vbCrLf
            ''End If

            ' 以下は省略可能な条件なので指定されていた場合にのみ編集
            ' 但し、検索方法が全てを含むなのかいずれかを含むなのかによりstrW2の内容がANDかORに変わる
            ''sWhere = ""

            ' ''支店・支所
            ''If txt_SITEN_CD.Text.TrimEnd <> "" Then
            ''    If sWhere = "" Then
            ''    Else
            ''        sWhere += strW2 & vbCrLf
            ''    End If
            ''    sWhere += "(STN.SITEN_CD LIKE '" & txt_SITEN_CD.Text.TrimEnd & "%')" & vbCrLf
            ''End If

            ' ''支店・支所名(カナ)
            ''If txt_SITEN_KANA.Text.TrimEnd <> "" Then
            ''    If sWhere = "" Then
            ''    Else
            ''        sWhere += strW2 & vbCrLf
            ''    End If
            ''    sWhere += "(STN.SITEN_KANA LIKE '" & txt_SITEN_KANA.Text.TrimEnd & "%')" & vbCrLf
            ''End If

            ' ''支店・支所名(漢字)
            ''If txt_SITEN_NAME.Text.TrimEnd <> "" Then
            ''    If sWhere = "" Then
            ''    Else
            ''        sWhere += strW2 & vbCrLf
            ''    End If
            ''    sWhere += "(STN.SITEN_NAME LIKE '" & txt_SITEN_NAME.Text.TrimEnd & "%')" & vbCrLf
            ''End If

            ''If sWhere = "" Then
            ''Else
            ''    sSql += " AND (" & sWhere & ")" & vbCrLf
            ''End If

            If pJoken2 = "" Then
                If pJoken2_BANK_CD = "" Then
                    sSql += " (STN.BANK_CD = " & dgv_Search.Item(C_BANK_CD, dgv_Search.CurrentRow.Index).Value & ")" & vbCrLf
                Else
                    sSql += " (STN.BANK_CD = " & pJoken2_BANK_CD & ")" & vbCrLf
                End If
            Else
                sSql += pJoken2
            End If


            sSql += "ORDER BY" & vbCrLf
            sSql += "  STN.BANK_CD, STN.SITEN_CD" & vbCrLf

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return sSql

    End Function
#End Region

#Region "f_Cmd_Set 金融機関　変更・削除。プレビューボタンの制御"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Cmd_Set
    '説明            :金融機関　変更・削除。プレビューボタンの制御
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Cmd_Set(ByVal wBool As Boolean) As Boolean
        Dim ret As Boolean = False

        Try
            cmdUpd.Enabled = wBool
            cmdDel.Enabled = wBool
            cmdPreview.Enabled = wBool

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_Cmd_Set2 支店　変更・削除。プレビューボタンの制御"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Cmd_Set2
    '説明            :支店　変更・削除。プレビューボタンの制御
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Cmd_Set2(ByVal wBool As Boolean) As Boolean
        Dim ret As Boolean = False

        Try
            cmdUpd2.Enabled = wBool
            cmdDel2.Enabled = wBool
            cmdPreview2.Enabled = wBool

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Report_Output レポート出力処理"
    Private Function f_Report_Output() As Boolean
        'Dim rpt As GrapeCity.ActiveReports.SectionReport
        'Dim rptPdf As New rptGJ8050
        Dim fm As Form
        Dim strRptNm As String = String.Empty

        Dim sSql As String

        Dim dstDataSet As New DataSet


        Dim strDate As String

        f_Report_Output = False
        Try

            sSql = f_Output_SQLMake()

            If Not f_Select_ODP(dstDataSet, sSql) Then
                Exit Try
            End If

            pCNT = 0        'データ件数初期化

            If dstDataSet.Tables(0).Rows.Count > 0 Then
                '作成日
                strDate = WordHenkan("N", "S", dstDataSet.Tables(0).Rows(0)("NOWYMD"))
                strDate = Mid(strDate, 1, 4) & "年" & Mid(strDate, 6, 2) & "月" & Mid(strDate, 9, 2) & "日"

                ''--------------------------------------------------
                ''ＰＤＦ出力
                ''--------------------------------------------------
                If Not f_Pdf_Output(dstDataSet, dstDataSet.Tables(0).TableName) Then
                    Exit Try
                End If

                Dim w As New rptGJ8050
                w.sub1(dstDataSet)

                ''--------------------------------------------------
                ''プレビュー表示
                ''--------------------------------------------------
                'rpt = New rptGJ8050()

                'rpt.DataSource = dstDataSet
                'rpt.DataMember = dstDataSet.Tables(0).TableName

                '' 用紙サイズを A4横 に設定します。
                'rpt.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
                'rpt.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape

                '' 上下の余白を 1.0cm に設定します。
                'rpt.PageSettings.Margins.Top = GrapeCity.ActiveReports.SectionReport.CmToInch(1.0)
                'rpt.PageSettings.Margins.Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(1.0)
                '' 左右の余白を 1.0cm に設定します。
                'rpt.PageSettings.Margins.Left = GrapeCity.ActiveReports.SectionReport.CmToInch(1.0)
                'rpt.PageSettings.Margins.Right = GrapeCity.ActiveReports.SectionReport.CmToInch(0.0)

                ''レポート名取得
                ''「GJ8050金融機関一覧」
                'strRptNm = pAPP & pRptName

                ''レポートプレビュー
                'fm = New frmViewer(rpt, strRptNm)
                'fm.Show()

            Else
                'エラーリスト出力なし
                Show_MessageBox("I002", "") '該当データが存在しません。
                Exit Function
            End If

            f_Report_Output = True
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function

#End Region
#Region "f_Pdf_Output ＰＤＦ出力処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Pdf_Output
    '説明            :ＰＤＦ出力処理
    '引数            :1.rptPdf          GrapeCity.ActiveReports.SectionReport    ActiveReports Class
    '                 2.dstDataRpt      DataSet     データソース
    '                 3.strDataMember   String      データメンバー名
    '戻り値          :Boolean(正常True/エラーFalse)
    '更新日          :2010/02/08 JBD368 ADD 申請日を追加
    '------------------------------------------------------------------
    Private Function f_Pdf_Output(ByVal dstDataRpt As DataSet, ByVal strDataMember As String) As Boolean
        Dim strRptNm As String = String.Empty
        Dim strOutPath As String = String.Empty

        f_Pdf_Output = False

        Try

            '--------------------------------------------------
            'ＰＤＦ出力
            '--------------------------------------------------
            'レポート名取得
            '「GJ8050金融機関一覧」
            strRptNm = pAPP & pRptName

            Dim w As New rptGJ8050
            w.sub2(dstDataRpt, strRptNm, strOutPath, strDataMember)

            f_Pdf_Output = True
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function
#End Region
#Region "f_Output_SQLMake レポート出力用ＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Output_SQLMake
    '説明            :レポート出力用ＳＱＬ作成
    '引数            :区分(0:ﾌﾟﾚﾋﾞｭｰ 1:PDF出力)
    '               　県コード
    '戻り値          :String(SQL文)
    '更新日          :2010/02/08 JBD368 UPD 申請日を追加
    '------------------------------------------------------------------
    Private Function f_Output_SQLMake() As String
        Dim sSql As String = String.Empty
        Dim strW2 As String = String.Empty

        Try

            sSql = " SELECT"
            sSql = sSql & " BNK.BANK_CD," & vbCrLf          '金融機関コード
            sSql = sSql & " BNK.BANK_KANA," & vbCrLf        '金融機関名（ｶﾅ）
            sSql = sSql & " BNK.BANK_NAME," & vbCrLf         '金融機関名（漢字）

            sSql = sSql & " TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') NOWYMD" & vbCrLf

            sSql = sSql & " FROM" & vbCrLf
            sSql = sSql & " TM_BANK BNK" & vbCrLf

            'WHERE句の AND条件、OR条件の判定

            If rbtn_Search1.Checked Then
                '検索方法で[すべてを含む]を選択
                strW2 = " AND"
            Else
                '検索方法で[いずれかを含む]を選択
                strW2 = " OR"
            End If

            If pJoken = "" Then
            Else
                sSql += " WHERE (" & pJoken & ")" & vbCrLf
            End If

            sSql += "ORDER BY" & vbCrLf
            sSql += "  BNK.BANK_CD" & vbCrLf


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return sSql

    End Function
#End Region

#Region "f_Report_Output2 レポート出力処理"
    Private Function f_Report_Output2() As Boolean
        'Dim rpt As GrapeCity.ActiveReports.SectionReport
        'Dim rptPdf As New rptGJ8052
        Dim fm As Form
        Dim strRptNm As String = String.Empty

        Dim sSql As String

        Dim dstDataSet As New DataSet

        Dim strDate As String

        f_Report_Output2 = False
        Try

            sSql = f_Output_SQLMake2()

            If Not f_Select_ODP(dstDataSet, sSql) Then
                Exit Try
            End If

            pCNT = 0        'データ件数初期化

            If dstDataSet.Tables(0).Rows.Count > 0 Then
                '作成日
                strDate = WordHenkan("N", "S", dstDataSet.Tables(0).Rows(0)("NOWYMD"))
                strDate = Mid(strDate, 1, 4) & "年" & Mid(strDate, 6, 2) & "月" & Mid(strDate, 9, 2) & "日"

                '--------------------------------------------------
                'ＰＤＦ出力
                '--------------------------------------------------
                If Not f_Pdf_Output2(dstDataSet, dstDataSet.Tables(0).TableName) Then
                    Exit Try
                End If

                Dim w As New rptGJ8052
                w.sub4(dstDataSet)
                ''--------------------------------------------------
                ''プレビュー表示
                ''--------------------------------------------------
                'rpt = New rptGJ8052()

                'rpt.DataSource = dstDataSet
                'rpt.DataMember = dstDataSet.Tables(0).TableName

                '' 用紙サイズを A4横 に設定します。
                'rpt.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
                'rpt.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape

                '' 上下の余白を 1.0cm に設定します。
                'rpt.PageSettings.Margins.Top = GrapeCity.ActiveReports.SectionReport.CmToInch(1.0)
                'rpt.PageSettings.Margins.Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(1.0)
                '' 左右の余白を 1.0cm に設定します。
                'rpt.PageSettings.Margins.Left = GrapeCity.ActiveReports.SectionReport.CmToInch(1.0)
                'rpt.PageSettings.Margins.Right = GrapeCity.ActiveReports.SectionReport.CmToInch(0.0)

                ''レポート名取得
                ''「GJ8050金融機関一覧」
                'strRptNm = pAPP & pRptName

                ''レポートプレビュー
                'fm = New frmViewer(rpt, strRptNm)
                'fm.Show()

            Else
                'エラーリスト出力なし
                Show_MessageBox("I002", "") '該当データが存在しません。
                Exit Function
            End If

            f_Report_Output2 = True
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function

#End Region
#Region "f_Pdf_Output2 ＰＤＦ出力処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Pdf_Output2
    '説明            :ＰＤＦ出力処理
    '引数            :1.rptPdf          GrapeCity.ActiveReports.SectionReport    ActiveReports Class
    '                 2.dstDataRpt      DataSet     データソース
    '                 3.strDataMember   String      データメンバー名
    '戻り値          :Boolean(正常True/エラーFalse)
    '更新日          :2010/02/08 JBD368 ADD 申請日を追加
    '------------------------------------------------------------------
    Private Function f_Pdf_Output2(ByVal dstDataRpt As DataSet, ByVal strDataMember As String) As Boolean
        Dim strRptNm As String = String.Empty
        Dim strOutPath As String = String.Empty

        f_Pdf_Output2 = False

        Try

            '--------------------------------------------------
            'ＰＤＦ出力
            '--------------------------------------------------
            'レポート名取得
            '「GJ8050金融機関一覧」
            strRptNm = pAPP & pRptName

            Dim w As New rptGJ8052
            w.sub3(dstDataRpt, strRptNm, strOutPath, strDataMember)

            ''ファイル存在ﾁｪｯｸ
            'If Not f_ReportPath_Check(strOutPath, 0, myREPORT_PDF_PATH, strRptNm) Then
            '    Exit Try
            'End If

            ''ＰＤＦにエクスポートを行います。
            'rptPdf.DataSource = dstDataRpt
            'rptPdf.DataMember = strDataMember
            ''rptPdf.DataMember = dstDataRpt.DataSetName     ' こちらの方が良いかも

            '' 用紙サイズを A4横 に設定します。
            'rptPdf.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
            'rptPdf.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape

            '' 上下の余白を 1.0cm に設定します。
            'rptPdf.PageSettings.Margins.Top = GrapeCity.ActiveReports.SectionReport.CmToInch(1.0)
            'rptPdf.PageSettings.Margins.Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(1.0)
            '' 左右の余白を 1.0cm に設定します。
            'rptPdf.PageSettings.Margins.Left = GrapeCity.ActiveReports.SectionReport.CmToInch(0.5)
            'rptPdf.PageSettings.Margins.Right = GrapeCity.ActiveReports.SectionReport.CmToInch(0.0)

            'rptPdf.Run()
            'Dim export As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
            'export.Export(rptPdf.Document, strOutPath)
            'export.Dispose()

            '' レポートインスタンスをDisposeします。
            'rptPdf.Document.Dispose()
            'rptPdf.Dispose()
            'rptPdf = Nothing

            ''メモリを解放します
            'Call s_GC_Dispose()


            f_Pdf_Output2 = True
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function
#End Region
#Region "f_Output_SQLMake2 レポート出力用ＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Output_SQLMake2
    '説明            :レポート出力用ＳＱＬ作成
    '引数            :区分(0:ﾌﾟﾚﾋﾞｭｰ 1:PDF出力)
    '               　県コード
    '戻り値          :String(SQL文)
    '更新日          :2010/02/08 JBD368 UPD 申請日を追加
    '------------------------------------------------------------------
    Private Function f_Output_SQLMake2() As String
        Dim sSql As String = String.Empty
        Dim sWhere As String = String.Empty
        Dim strW2 As String = String.Empty

        Dim blnAnd As Boolean = False
        Dim blnOr As Boolean = False

        Try

            'WHERE句の AND条件、OR条件の判定
            If rbtn_Search3.Checked Then
                '検索方法で[すべてを含む]を選択
                strW2 = " AND"
            Else
                '検索方法で[いずれかを含む]を選択
                strW2 = " OR"
            End If

            '検索
            sSql = " SELECT " & vbCrLf
            sSql += "  STN.BANK_CD BANK_CD," & vbCrLf
            sSql += "  BNK.BANK_NAME BANK_NAME," & vbCrLf
            sSql += "  STN.SITEN_CD SITEN_CD," & vbCrLf
            sSql += "  STN.SITEN_NAME SITEN_NAME," & vbCrLf
            sSql += "  STN.SITEN_KANA SITEN_KANA," & vbCrLf
            sSql += "  TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') NOWYMD" & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_SITEN STN," & vbCrLf

            '金融機関マスタより金融機関コード・名称を取得
            sSql += "  TM_BANK BNK " & vbCrLf

            'WHERE条件句を作成
            sSql += " WHERE" & vbCrLf

            sSql += "       (STN.BANK_CD = BNK.BANK_CD(+)) " & vbCrLf
            sSql += " AND " & vbCrLf

            If pJoken2 = "" Then
                If pJoken2_BANK_CD = "" Then
                    pJoken2 += " (STN.BANK_CD = " & dgv_Search.Item(C_BANK_CD, dgv_Search.CurrentRow.Index).Value & ")" & vbCrLf
                Else
                    pJoken2 += " (STN.BANK_CD = " & pJoken2_BANK_CD & ")" & vbCrLf
                End If
                sSql += pJoken2 '2015/01/19　追加
            Else
                sSql += pJoken2
            End If

            sSql += "ORDER BY" & vbCrLf
            sSql += "  STN.BANK_CD, STN.SITEN_CD" & vbCrLf

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return sSql

    End Function
#End Region
#End Region

    Private Sub txt_SITEN_CD_TextChanged(sender As Object, e As EventArgs) Handles txt_SITEN_CD.TextChanged

    End Sub
End Class
