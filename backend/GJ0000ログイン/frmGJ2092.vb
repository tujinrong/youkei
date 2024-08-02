'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ2092.vb
'*
'*　　②　機能概要　　　　　互助基金契マスタメンテンテナンス(契約情報)
'*
'*　　③　作成日　　　　　　2015/02/22　BY JBD
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

Public Class frmGJ2092

#Region "***変数定義***"

    ''' <summary>
    ''' 固定項目
    ''' </summary>
    ''' <remarks></remarks>
    Property p2090_KI As Integer

    ''' <summary>
    ''' 処理状況
    ''' </summary>
    ''' <remarks></remarks>
    Property pLoadErr As Boolean

    ''' <summary>
    ''' グリッドキーリスト
    ''' </summary>
    ''' <remarks></remarks>
    Public paryKEY_2090 As New List(Of frmGJ2090.T_KEY)

    ''' <summary>
    ''' カレント主キー
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pCurrentKey As frmGJ2090.T_KEY

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
    Property pSyoriKbn As Enu_SyoriKubun

    ''' <summary>
    '''  画面入力内容変更フラグ
    ''' </summary>
    ''' <remarks></remarks>
    Private loblnTextChange As Boolean                   '画面入力内容変更フラグ

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
    Private pJump As Boolean = True             '処理ジャンプ
    Public pLnk_BIKO As String                  '初期表示番号
    Public pLnk_GAMEN As Integer                '初期表示番号

    '抽出行
    Private pSelectRowIdx As Integer            '抽出行

    '計算用
    Private pSAGAKU_SEIKYU_KIN As Long          '差額 請求(返還)金額計

    Private pSEIKYU_KIN As Long                 '請求(返還)金額計
    Private pTUMITATE_KIN As Long               '積立金
    Private pTESURYO As Long                    '手数料
    Private pHENKAN_KIN As Long                 '返還金(預かり金)  

    Private pNYUKIN_TUMITATE_KEI As Long        '入金積立金額計
    Private pNYUKIN_TESU_KEI As Long            '入金手数料額計
    Private pNYUKIN_GAKU_KEI As Long            '入金額計
    Private pNYUKIN_ZAN As Long                 '入金額残

    Private pNYUKIN_GAKU_BEFOR As Long          '入金額(計算前の退避)
    Private pNYUKIN_GAKU_BEFOR_KEI As Long      '入金額計(計算前の退避)

    Private pNYUKIN_TUMITATE As Long            '入金積立金額
    Private pNYUKIN_TESU As Long                '入金手数料額
    Private pNYUKIN_GAKU As Long                '入金額
    Private pDataSet As New DataSet             '結果一覧セット用データセット

    Private pblnTextChange_BIKO As Boolean      '画面入力内容変更フラグ(備考)
    Private pDetailMax As Integer = 3           '最大明細数
    Private pTOKUSOKU_HAKKO_DATE As String      '積立金DB.督促状発行日

    Private pTUMI_NOFUKIGEN As Date             '積立金DB.納付期限 2021/07/13 JBD9020 新契約日追加 ADD
    Private pKEIYAKU_JOKYO As Integer           '契約マスタ.契約状況 2021/07/13 JBD9020 新契約日追加 ADD

#End Region

#Region "***画面制御関連***"

#Region "frmFS2020_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmEM2020_Load
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

            '---------------------------------------------------
            'データの読み込み
            '---------------------------------------------------
            If Not f_SetForm_Data("C", 0) Then
                pLoadErr = True
                Throw New Exception("該当データが存在しませんでした")
            End If


            '変更判定イベント登録
            f_setControlChangeEvents()

            '入力不可にセット
            If Not f_HdEnableCtl(True) Then
                Exit Try
            End If
            If Not f_DtlEnableCtl(False) Then
                Exit Try
            End If

            '★初期コントロールにフォーカスセット
            dgv_Search.Focus()


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

#Region "cmdIns_Click 新規入金ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdIns_Click
    '説明            :新規入金ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIns.Click
        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '再抽出
            If dgv_Search.RowCount >= pDetailMax Then
                Show_MessageBox_Add("W019", "これ以上登録できません。") '@0
                Exit Try
            End If

            '処理区分：登録
            pSyoriKbn = Enu_SyoriKubun.Insert
            '入金日
            If Not pCurrentKey.NYURYOKU_YMD = "" Then
                dateNYUKIN_DATE_W.Value = CDate(pCurrentKey.NYURYOKU_YMD)
            End If
            '入金回数
            If dgv_Search.RowCount = 0 Then
                lblNYUKIN_KAISU.Text = 1
            Else
                lblNYUKIN_KAISU.Text = WordHenkan("N", "S", dgv_Search.Item("NYUKIN_KAISU_MAX", 0).Value) + 1
            End If
            '明細番号
            If dgv_Search.RowCount = 0 Then
                lblMEISAI_NO.Text = 1
            Else
                lblMEISAI_NO.Text = WordHenkan("N", "S", dgv_Search.Item("MEISAI_NO", dgv_Search.RowCount - 1).Value) + 1
            End If
            '入力制御
            If Not f_HdEnableCtl(False) Then
                Exit Try
            End If
            If Not f_DtlEnableCtl(True) Then
                Exit Try
            End If
            '備考
            txtBiko.Text = pLnk_BIKO

            pNYUKIN_GAKU_BEFOR = 0



            loblnTextChange = False

            '初期コントロールにフォーカスセット
            dateNYUKIN_DATE_W.Select()

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
    'プロシージャ名  :cmdSav_Click
    '説明            :変更ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpd.Click
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim wStr As String = String.Empty


        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")       'データが選択されていません。
                Exit Try
            End If

            '処理区分：修正
            pSyoriKbn = Enu_SyoriKubun.Update

            '選択行取得
            For i As Integer = 0 To dgv_Search.RowCount - 1
                If dgv_Search.Rows(i).Selected Then
                    pSelectRowIdx = i
                    Exit For
                End If
            Next

            '--------------------------------------------------
            'グリッド選択行の情報を各入力項目に格納
            '--------------------------------------------------
            '入金回数
            lblNYUKIN_KAISU.Text = WordHenkan("N", "S", dgv_Search.Item("NYUKIN_KAISU", pSelectRowIdx).Value)
            '入金日
            dateNYUKIN_DATE.Value = CDate(dgv_Search.Item("NYUKIN_DATE", pSelectRowIdx).Value)
            dateNYUKIN_DATE_W.Value = CDate(dgv_Search.Item("NYUKIN_DATE", pSelectRowIdx).Value)

            '積立金額
            pNYUKIN_TUMITATE = CLng(dgv_Search.Item("NYUKIN_TUMITATE", pSelectRowIdx).Value)
            lblNYUKIN_TUMITATE.Text = Format(pNYUKIN_TUMITATE, "###,###,##0")

            '手数料金額
            pNYUKIN_TESU = CLng(dgv_Search.Item("NYUKIN_TESU", pSelectRowIdx).Value)
            lblNYUKIN_TESU.Text = Format(pNYUKIN_TESU, "###,###,##0")

            '入金額
            pJump = True
            numNYUKIN_GAKU.Value = CLng(dgv_Search.Item("NYUKIN_GAKU", pSelectRowIdx).Value)
            pNYUKIN_GAKU = CLng(dgv_Search.Item("NYUKIN_GAKU", pSelectRowIdx).Value)
            pNYUKIN_GAKU_BEFOR = CLng(dgv_Search.Item("NYUKIN_GAKU", pSelectRowIdx).Value)
            pJump = False
            '備考
            'txtBiko.Text = WordHenkan("N", "S", dgv_Search.Item("BIKO", pSelectRowIdx).Value)
            txtBiko.Text = pLnk_BIKO

            '明細番号
            If dgv_Search.RowCount = 0 Then
                lblMEISAI_NO.Text = 1
            Else
                lblMEISAI_NO.Text = WordHenkan("N", "S", dgv_Search.Item("MEISAI_NO", pSelectRowIdx).Value)
            End If

            '入力制御
            If Not f_HdEnableCtl(False) Then
                Exit Try
            End If
            If Not f_DtlEnableCtl(True) Then
                Exit Try
            End If

            '初期コントロールにフォーカスセット
            dateNYUKIN_DATE.Select()

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

        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")
                Exit Try
            End If

            '選択行取得
            For i As Integer = 0 To dgv_Search.RowCount - 1
                If dgv_Search.Rows(i).Selected Then
                    pSelectRowIdx = i
                    Exit For
                End If
            Next

            '最終明細のみ削除可
            If pSelectRowIdx <> dgv_Search.RowCount - 1 Then
                '削除処理確認
                Show_MessageBox_Add("W013", "最終明細以外")
                Exit Try
            End If

            '2016/05/17　追加開始
            '--------------------------------------------------
            '積立データチェック
            '--------------------------------------------------
            '通常積立金
            If pCurrentKey.TUMITATE_KBN = 1 Then
                If Not f_Delete_Check() Then
                    Exit Try
                End If
            End If
            '2016/05/17　追加終了

            '削除処理確認
            If Show_MessageBox_Add("Q006", "指定されたデータ") = DialogResult.No Then    '指定されたデータを削除します。よろしいですか？
                Exit Try
            End If

            '明細番号
            If dgv_Search.RowCount = 0 Then
                lblMEISAI_NO.Text = 1
            Else
                lblMEISAI_NO.Text = WordHenkan("N", "S", dgv_Search.Item("MEISAI_NO", dgv_Search.RowCount - 1).Value) + 1
            End If

            '該当データ削除処理
            If Not f_Data_Del() Then
                Exit Try
            End If

            '画面　再表示(pblnTextChangeのみクリア)
            If f_SetForm_Data("", pSelectRowIdx) Then
                Exit Try
            End If


            '画面入力内容変更フラグクリア
            loblnTextChange = False

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

#Region "cmdSav_Click 保存ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSav_Click
    '説明            :保存ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            If pSyoriKbn = Enu_SyoriKubun.Update Then   '変更
                '明細を変更　または　備考変更
                If loblnTextChange OrElse pblnTextChange_BIKO Then
                Else
                    '画面に変更がない場合は、メッセージ表示
                    Show_MessageBox_Add("I007", "変更したデータはありません。")
                    Exit Try
                End If
            End If

            '事前チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert       '新規入力

                    '保存処理確認
                    If Show_MessageBox_Add("Q004", "データ") = DialogResult.No Then    '@0を登録します。よろしいですか？
                        Exit Try
                    End If

                    '追加行
                    '2016/05/20　修正開始
                    'If dgv_Search.RowCount = 0 Then
                    '    pSelectRowIdx = 0
                    'Else
                    '    pSelectRowIdx = 1
                    'End If
                    '追加した行を選択
                    If dgv_Search.RowCount = 0 Then
                        pSelectRowIdx = 0
                    ElseIf dgv_Search.RowCount = 1 Then
                        pSelectRowIdx = 1
                    Else
                        pSelectRowIdx = 2
                    End If
                    '2016/05/20　修正終了

                    'データ保存処理
                    If Not f_Data_Insert() Then
                        Exit Try
                    End If

                Case Enu_SyoriKubun.Update       '変更
                    '選択行
                    For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
                        pSelectRowIdx = gRow.Index
                    Next

                    '保存処理確認
                    If Show_MessageBox_Add("Q005", "データ") = DialogResult.No Then    '@0を更新します。よろしいですか？
                        Exit Try
                    End If

                    'データ保存処理
                    If Not f_Data_update() Then
                        Exit Try
                    End If

            End Select


            '画面　再表示(pblnTextChange_BIKOもクリア)
            pblnTextChange_BIKO = False
            If f_SetForm_Data("", pSelectRowIdx) Then
                Exit Try
            End If

            '画面入力内容変更フラグクリア
            loblnTextChange = False

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

#Region "cmdCancel_Click キャンセルボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdCancel_Click
    '説明            :キャンセルボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

        If loblnTextChange Then
            '画面に変更があり保存していない場合は、メッセージ表示
            If Show_MessageBox("Q007", "") = DialogResult.No Then
                Exit Sub
            End If
        End If

        '画面クリア
        f_DtlClear()
        '入力制御
        f_HdEnableCtl(True)
        f_DtlEnableCtl(False)

        '計算クリア
        pNYUKIN_TUMITATE = 0           '入金積立金額
        pNYUKIN_TESU = 0               '入金手数料額
        pNYUKIN_GAKU = 0               '入金額
        pNYUKIN_GAKU_BEFOR = 0
        f_SetForm_TT_TUMITATE_NYUKIN()
        f_SetForm_KEISAN_AREA(0)


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

#Region "num_NYUKIN_ValueChanged 金額変更処理"
    '------------------------------------------------------------------
    'プロシージャ名  :numNYUKIN_GAKU_ValueChanged
    '説明            :金額変更処理
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numNYUKIN_GAKU_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numNYUKIN_GAKU.ValueChanged
        Dim wkNYUKIN_GOKEI As Long
        Dim wkNYUKIN_TESU_GOKEI As Long
        Dim wkNYUKIN_TIMITATE As Long
        Dim wkNYUKIN_TESU As Long
        Dim wkNYU_TESU_KIN As Long = 0

        Try

            '初期処理の時は、実行しない
            If pJump Then
                Exit Try
            End If


            '入金額
            If numNYUKIN_GAKU.Value Is Nothing Then
                pNYUKIN_GAKU = 0
            Else
                If numNYUKIN_GAKU.Value Is Nothing Then
                    pNYUKIN_GAKU = 0
                Else
                    pNYUKIN_GAKU = numNYUKIN_GAKU.Value
                End If
            End If


            'aaa

            '合計(全入金額)
            'wkNYUKIN_GOKEI = pNYUKIN_GAKU + pNYUKIN_GAKU_KEI + pHENKAN_KIN
            wkNYUKIN_GOKEI = pNYUKIN_GAKU + pNYUKIN_GAKU_BEFOR_KEI - pNYUKIN_GAKU_BEFOR + pHENKAN_KIN
            '入金済み手数料の算出
            'wkNYUKIN_TESU_GOKEI = wkNYUKIN_GOKEI - pHENKAN_KIN - pNYUKIN_GAKU
            wkNYUKIN_TESU_GOKEI = 0
            If wkNYUKIN_GOKEI > pTUMITATE_KIN Then
                'グリッド内データ加算して計を取得
                For i As Integer = 0 To dgv_Search.RowCount - 1
                    If i = pSelectRowIdx Then
                    Else
                        wkNYUKIN_TESU_GOKEI += CLng(dgv_Search.Item("NYUKIN_TESU", i).Value)
                    End If
                Next
            End If


            '積立金入金額計の判定
            If pTUMITATE_KIN <= wkNYUKIN_GOKEI Then
                pNYUKIN_TUMITATE = pTUMITATE_KIN
                '残
                wkNYUKIN_GOKEI = wkNYUKIN_GOKEI - pTUMITATE_KIN
            Else
                pNYUKIN_TUMITATE = wkNYUKIN_GOKEI
                '残
                wkNYUKIN_GOKEI = wkNYUKIN_GOKEI - wkNYUKIN_GOKEI
            End If

            '積立入金額(表示)
            '入金額合計残の判定
            If wkNYUKIN_GOKEI > 0 Then
                '入金額合計残がある場合
                wkNYUKIN_TIMITATE = pNYUKIN_GAKU - wkNYUKIN_GOKEI

                '積立金がマイナスの場合
                If wkNYUKIN_TIMITATE < 0 Then
                    '積立金がマイナスなら積立金済なので0
                    wkNYUKIN_TIMITATE = 0
                End If
            Else
                '入金額合計残がない場合
                '入金額を積立金入金
                wkNYUKIN_TIMITATE = wkNYUKIN_GOKEI + pNYUKIN_GAKU
            End If


            '手数料入金額計の判定
            If pTESURYO <= wkNYUKIN_GOKEI Then
                pNYUKIN_TESU = pTESURYO
            Else
                pNYUKIN_TESU = wkNYUKIN_GOKEI
            End If

            '手数料入金額(表示)　
            If wkNYUKIN_GOKEI = 0 Then
                '手数料なし
                wkNYUKIN_TESU = 0

            ElseIf wkNYUKIN_GOKEI > 0 And wkNYUKIN_TIMITATE > 0 Then
                '残0以上で且つ入金積立金が0以上の場合

                If pTESURYO >= wkNYUKIN_GOKEI Then
                    '入金済手数料 = 入金残 - 既に入金済手数料 
                    wkNYUKIN_TESU = wkNYUKIN_GOKEI - wkNYUKIN_TESU_GOKEI
                    If wkNYUKIN_TESU < 0 Then
                        wkNYUKIN_TESU = 0
                        '積立入金の算出(入金済手数料分を加算)
                        wkNYUKIN_TIMITATE = wkNYUKIN_TIMITATE + wkNYUKIN_GOKEI
                    Else
                        '積立入金の算出(入金済手数料分を加算)
                        wkNYUKIN_TIMITATE = wkNYUKIN_TIMITATE + wkNYUKIN_TESU_GOKEI
                    End If
                Else
                    '入金済手数料 = 手数料　-　既に入金済手数料   
                    wkNYUKIN_TESU = pTESURYO - wkNYUKIN_TESU_GOKEI
                    '積立入金の算出(入金済手数料分を加算)
                    wkNYUKIN_TIMITATE = wkNYUKIN_TIMITATE + wkNYUKIN_TESU_GOKEI

                End If

            Else
                '積立金入金済
                If pTESURYO - wkNYUKIN_GOKEI >= 0 Then
                    '入金額を手数料に
                    wkNYUKIN_TESU = pNYUKIN_GAKU
                Else
                    wkNYUKIN_TESU = pNYUKIN_GAKU + (pTESURYO - wkNYUKIN_GOKEI)
                End If
            End If



            '表示
            'lblNYUKIN_TUMITATE.Text = Format(pNYUKIN_TUMITATE, "###,###,##0")
            'lblNYUKIN_TESU.Text = Format(pNYUKIN_TESU, "###,###,##0")

            If lblMEISAI_NO.Text = 1 Then
                lblNYUKIN_TUMITATE.Text = Format(wkNYUKIN_TIMITATE + pHENKAN_KIN, "###,###,##0")
            Else
                lblNYUKIN_TUMITATE.Text = Format(wkNYUKIN_TIMITATE, "###,###,##0")
            End If
            lblNYUKIN_TESU.Text = Format(wkNYUKIN_TESU, "###,###,##0")

            'グリッド横　合計・残高表示
            If pSyoriKbn = Enu_SyoriKubun.Insert Then
                f_SetForm_KEISAN_AREA(1)
            Else
                f_SetForm_KEISAN_AREA(2)
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region


#End Region

#Region "*** データ登録関連 ***"

#Region "f_Data_Insert 新規登録処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Insert
    '説明            :新規入金処理
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Function f_Data_Insert() As Boolean
        Dim ret As Boolean = False

        Try

            '新規登録保存
            If Not f_TT_TUMITATE_SEIKYU_BUNKATU(1) Then
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

#Region "f_Data_Update 変更保存処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Update
    '説明            :変更保存処理
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Function f_Data_Update() As Boolean
        Dim ret As Boolean = False

        Try

            '変更保存
            If Not f_TT_TUMITATE_SEIKYU_BUNKATU(2) Then
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

#Region "f_Data_Del　削除処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Del
    '説明            :削除処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Del() As Boolean
        Dim ret As Boolean = False
        'Dim delRowIdx As Integer
        'Dim wkSEIKYU_KIN As Long
        'Dim wkTESURYO As Long
        'Dim wkZan As Long


        Try
            '削除
            If Not f_TT_TUMITATE_SEIKYU_BUNKATU(3) Then
                Exit Try
            End If

            ''削除時はすでに登録済の入金残を再計算
            ''削除後の明細数判定
            'If dgv_Search.RowCount > 1 Then
            '    delRowIdx = pSelectRowIdx
            '    wkSEIKYU_KIN = CLng(IIf(lblSAGAKU_SEIKYU_KIN.Text = "" Or lblSAGAKU_SEIKYU_KIN.Text Is Nothing, 0, lblSAGAKU_SEIKYU_KIN.Text))
            '    wkTESURYO = CLng(IIf(lblTESURYO.Text = "" Or lblTESURYO.Text Is Nothing, 0, lblTESURYO.Text))
            '    wkSEIKYU_KIN = wkSEIKYU_KIN - wkTESURYO
            '    For i As Integer = 0 To dgv_Search.RowCount - 1
            '        '削除対象外の情報取得
            '        If delRowIdx <> i Then
            '            '入金日
            '            dateNYUKIN_DATE_W.Value = CDate(dgv_Search.Item("NYUKIN_DATE", i).Value.ToString)
            '            '入金回数
            '            lblNYUKIN_KAISU.Text = dgv_Search.Item("NYUKIN_KAISU", i).Value

            '            '入金額
            '            pNYUKIN_GAKU = CLng(dgv_Search.Item("NYUKIN_GAKU", i).Value)
            '            If wkSEIKYU_KIN >= pNYUKIN_GAKU Then
            '                lblNYUKIN_TUMITATE.Text = pNYUKIN_GAKU
            '                lblNYUKIN_TESU.Text = 0
            '                lblNYUKIN_ZAN_KEI.Text = wkSEIKYU_KIN - pNYUKIN_GAKU
            '            Else
            '                If wkSEIKYU_KIN < 0 Then
            '                    lblNYUKIN_TUMITATE.Text = 0
            '                    lblNYUKIN_TESU.Text = pNYUKIN_GAKU
            '                    lblNYUKIN_ZAN_KEI.Text = wkZan - pNYUKIN_GAKU
            '                Else
            '                    If wkSEIKYU_KIN + wkTESURYO >= pNYUKIN_GAKU Then
            '                        lblNYUKIN_TUMITATE.Text = wkSEIKYU_KIN
            '                        lblNYUKIN_TESU.Text = pNYUKIN_GAKU - wkSEIKYU_KIN
            '                        lblNYUKIN_ZAN_KEI.Text = wkSEIKYU_KIN + wkTESURYO - pNYUKIN_GAKU
            '                    End If
            '                End If

            '            End If
            '            wkSEIKYU_KIN = wkSEIKYU_KIN - pNYUKIN_GAKU
            '            wkZan = lblNYUKIN_ZAN_KEI.Text

            '            '更新
            '            pSelectRowIdx = i
            '            If Not f_TT_TUMITATE_SEIKYU_BUNKATU(2) Then
            '                Exit Try
            '            End If
            '        End If
            '    Next
            'End If




            ret = True
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try
        Return ret
    End Function
#End Region

#Region "f_TT_TUMITATE_SEIKYU_BUNKATU 積立請求入金ＤＢデータ更新"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TT_TUMITATE_SEIKYU_BUNKATU
    '説明            :積立請求入金ＤＢデータ更新
    '引数            :intSyoriKbn     Integer     処理区分(1:入金登録  2:入金取消)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TT_TUMITATE_SEIKYU_BUNKATU(ByVal intSyoriKbn As Integer) As Boolean
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False
        Dim wDate As Date = Nothing
        Dim wkKin As Long

        Dim wKeiyakuDate As Date = Nothing
        Dim wKeiyakuUpKbn As Integer = 0

        Try

            '削除のとき、選択したデータを引数にセット
            If intSyoriKbn = 3 Then
                '入金番号
                lblNYUKIN_KAISU.Text = dgv_Search.Item("NYUKIN_KAISU", pSelectRowIdx).Value
                '入金日
                wDate = CDate(dgv_Search.Item("NYUKIN_DATE", pSelectRowIdx).Value.ToString)
                '積立金額
                pNYUKIN_TUMITATE = CLng(dgv_Search.Item("NYUKIN_TUMITATE", pSelectRowIdx).Value)
                '手数料額
                pNYUKIN_TESU = CLng(dgv_Search.Item("NYUKIN_TESU", pSelectRowIdx).Value)
                '入金額
                pNYUKIN_GAKU = CLng(dgv_Search.Item("NYUKIN_GAKU", pSelectRowIdx).Value)
                '入金残
                pNYUKIN_ZAN = CLng(dgv_Search.Item("NYUKIN_ZAN", pSelectRowIdx).Value)
            Else
                '入金日
                wDate = dateNYUKIN_DATE_W.Value
            End If


            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.CommandText = "PKG_GJ2090.GJ2090_NYUKIN_BUNKATU"

            '引き渡し
            '期
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", p2090_KI)
            '請求（返還）回数
            Dim paraSEIKYU_KAISU As OracleParameter = Cmd.Parameters.Add("IN_SEIKYU_KAISU", pCurrentKey.SEIKYU_KAISU)
            '契約者番号
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", pCurrentKey.KEIYAKUSYA_CD)
            '積立金区分
            Dim paraTUMITATE_KBN As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_KBN", pCurrentKey.TUMITATE_KBN)

            '入金（返還）日 積立入金日
            Dim paraNYUKIN_DATE As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_DATE", CDate(Format(wDate, "yyyy/MM/dd").TrimEnd))
            '入金(返還)入力日 積立入金入力日
            '#89 UPD START
            'Dim paraNYUKIN_NYURYOKU_DATE As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_NYURYOKU_DATE", Now)
            Dim paraNYUKIN_NYURYOKU_DATE As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_NYURYOKU_DATE", CDate(Format(Now, "yyyy/MM/dd").TrimEnd))
            '#89 UPD END


            '備考
            Dim paraBIKO As OracleParameter = Cmd.Parameters.Add("IN_BIKO", txtBiko.Text.TrimEnd)
            pLnk_BIKO = txtBiko.Text.TrimEnd

            '積立入金DB
            '入金回数
            Dim paraNYUKIN_KAISU As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_KAISU", lblNYUKIN_KAISU.Text)
            '入金額
            Dim paraNYUKIN_GAKU As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_GAKU", pNYUKIN_GAKU)


            '積立入金額
            wkKin = CLng(IIf(lblNYUKIN_TUMITATE.Text = "" Or lblNYUKIN_TUMITATE.Text Is Nothing, 0, lblNYUKIN_TUMITATE.Text))
            If lblMEISAI_NO.Text = 1 Then
                wkKin = wkKin - pHENKAN_KIN
            End If
            Dim paraNYUKIN_TUMITATE As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_TUMITATE", wkKin)

            '手数料入金額
            wkKin = CLng(IIf(lblNYUKIN_TESU.Text = "" Or lblNYUKIN_TESU.Text Is Nothing, 0, lblNYUKIN_TESU.Text))
            Dim paraNYUKIN_TESU As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_TESU", wkKin)

            '入金残
            'Dim paraNYUKIN_ZAN As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_ZAN", pNYUKIN_ZAN)
            wkKin = CLng(IIf(lblNYUKIN_ZAN_KEI.Text = "" Or lblNYUKIN_ZAN_KEI.Text Is Nothing, 0, lblNYUKIN_ZAN_KEI.Text))
            Dim paraNYUKIN_ZAN As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_ZAN", wkKin)

            '#54 ADD START
            '積立金額
            wkKin = CLng(IIf(lblNYUKIN_TUMITATE_KEI.Text = "" Or lblNYUKIN_TUMITATE_KEI.Text Is Nothing, 0, lblNYUKIN_TUMITATE_KEI.Text))
            Dim paraNYUKIN_TUMITATE_HENKAN As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_TUMITATE_HENKAN", wkKin)
            '手数料
            wkKin = CLng(IIf(lblNYUKIN_TESU_KEI.Text = "" Or lblNYUKIN_TESU_KEI.Text Is Nothing, 0, lblNYUKIN_TESU_KEI.Text))
            Dim paraNYUKIN_TESU_HENKAN As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_TESU_HENKAN", wkKin)
            '#54 ADD END


            '積立金DB
            '処理状況(入金済：3)
            If pNYUKIN_ZAN = 0 Then
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 3)
            Else
                '処理状況(一部入金請求中：4 or 一部入金督促中：5)
                If pTOKUSOKU_HAKKO_DATE Is Nothing Then
                    Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 4)
                Else
                    Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 5)
                End If

            End If
            '積立金入金区分(分割：2)
            Dim paraNYUKIN_KBN As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_KBN", 2)

            '契約日
            '2016/05/23　修正開始
            'Dim dtKEIYAKU_DATE As Date
            'If pNYUKIN_ZAN = 0 Then
            '    Dim SyoriKI = New Obj_TM_SYORI_NENDO_KI()
            '    If SyoriKI.pNOFU_KIGEN < dateNYUKIN_DATE.Value Then
            '        '契約日を入金日にする
            '        dtKEIYAKU_DATE = dateNYUKIN_DATE.Value
            '    Else
            '        '契約日を事業開始年月日する
            '        dtKEIYAKU_DATE = SyoriKI.pJIGYO_NENDO_byDate
            '    End If
            '    Dim paraKEIYAKU_DATE As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_DATE", CDate(Format(dtKEIYAKU_DATE, "yyyy/MM/dd").TrimEnd))
            'Else
            '    '入金ありのときは、契約日クリア
            '    Dim paraKEIYAKU_DATE As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_DATE", DBNull.Value)
            'End If
            
            '納付期限の判定
            If Not f_KeiyakuUpdateHantei(intSyoriKbn, wKeiyakuUpKbn, wKeiyakuDate) Then
                Exit Try
            End If
            '契約マスタ．契約日
            If wKeiyakuDate = Nothing Then
                Dim paraKEIYAKU_DATE As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_DATE", DBNull.Value)
            Else
                Dim paraKEIYAKU_DATE As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_DATE", wKeiyakuDate)
            End If
            '契約マスタ更新有無
            Dim paraKEIYAKU_HENKO_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_UPDATE_KBN", wKeiyakuUpKbn)
            '2016/05/23　修正終了

            '処理区分(1:新規登録 2:変更 3:削除)
            Dim paraSYORI_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_KBN", intSyoriKbn)

            '2021/07/12 JBD9020 新契約日追加 ADD START
            Dim wDate_MAX As New Date
            If intSyoriKbn = 3 Or pNYUKIN_ZAN <> 0 Then
                wDate_MAX = Nothing
            ElseIf intSyoriKbn = 1 Then
                '入力した入力日
                wDate_MAX = f_DateTrim(dateNYUKIN_DATE_W.Value)
            Else
                '修正のとき、入力した入力日
                If pSelectRowIdx = dgv_Search.Rows.Count - 1 Then
                    '最終行を選択時は、入力値
                    wDate_MAX = f_DateTrim(dateNYUKIN_DATE_W.Value)
                Else
                    '最終行以外を選択時、最終行の入力日
                    wDate_MAX = f_DateTrim(CDate(dgv_Search.Item("NYUKIN_DATE", dgv_Search.Rows.Count - 1).Value.ToString))
                End If
            End If
            If wDate_MAX = Nothing Then
                Dim paraLAST_DATE As OracleParameter = Cmd.Parameters.Add("IN_SAISYU_NYUKIN_DATE", DBNull.Value)
            Else
                Dim paraLAST_DATE As OracleParameter = Cmd.Parameters.Add("IN_SAISYU_NYUKIN_DATE", wDate_MAX)
            End If
            '2021/07/12 JBD9020 新契約日追加 ADD END

            Dim paraREGDATE As OracleParameter = Cmd.Parameters.Add("IN_REG_DATE", Now)                 'データ登録日
            Dim paraREGID As OracleParameter = Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)            'データ登録ＩＤ
            Dim paraUPDATE As OracleParameter = Cmd.Parameters.Add("IN_UP_DATE", Now)                   'データ更新日
            Dim paraUPID As OracleParameter = Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)              'データ更新ＩＤ
            Dim paraCOMNM As OracleParameter = Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)               'コンピュータ名

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 4000, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()

            If p_MSGCD.Value.ToString = "0" Then
                '正常
                '契約日は、更新した日付をセット
                If wKeiyakuUpKbn = 1 Then
                    dateKEIYAKU_DATE.Value = wKeiyakuDate
                End If
            Else
                Show_MessageBox("", p_MSGNM.Value.ToString)
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
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
        End Try

        Return ret

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
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GroupBox
                    For Each wkItem In DirectCast(wkCtrl, JBD.Gjs.Win.GroupBox).Controls
                        If TypeOf wkItem Is JBD.Gjs.Win.RadioButton Then
                            AddHandler DirectCast(wkItem, JBD.Gjs.Win.RadioButton).CheckedChanged, AddressOf f_setChanged
                        End If
                    Next

                    '↓===== 2012/01/27 JBD200 ADD タブコントロール内の項目の変更判定追加 =====↓
                Case TypeOf wkCtrl Is System.Windows.Forms.TabControl
                    For Each wkItem In DirectCast(wkCtrl, System.Windows.Forms.TabControl).Controls

                        Select Case True
                            Case TypeOf wkItem Is System.Windows.Forms.TabPage

                                For Each wkItem2 In DirectCast(wkItem, System.Windows.Forms.TabPage).Controls

                                    Select Case True
                                        Case TypeOf wkItem2 Is JBD.Gjs.Win.GcMask
                                            AddHandler DirectCast(wkItem2, JBD.Gjs.Win.GcMask).TextChanged, AddressOf f_setChanged
                                        Case TypeOf wkItem2 Is JBD.Gjs.Win.GcTextBox
                                            AddHandler DirectCast(wkItem2, JBD.Gjs.Win.GcTextBox).TextChanged, AddressOf f_setChanged

                                    End Select

                                Next

                        End Select

                    Next
                    '↑===== 2012/01/27 JBD200 ADD タブコントロール内の項目の変更判定追加 =====↑

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

        f_ObjectClear = False

        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            pJump = True
            f_ClearFormALL(Me, wKbn)
            pJump = False

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

#Region "f_SetForm_Data 初期画面表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :画面表示
    '引数            :wKbn  "C":初期表示  "":再表示
    '　　            :wRow  選択行
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_Data(ByVal wKbn As String, ByVal wRow As Integer) As Boolean
        Dim ret As Boolean = False
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim wMaxRowIdx As Integer

        Try

            pJump = True

            'フォームロード時のみ
            If wKbn = "C" Then
                '積立金ＤＢデータ画面セット
                If Not f_SetForm_TT_TUMITATE() Then
                    '入力不可
                    f_Gamen_Lock()
                    Exit Try
                End If
            End If

            '積立金入金ＤＢデータ画面セット
            If Not f_SetForm_TT_TUMITATE_NYUKIN() Then
                '入力不可
                f_Gamen_Lock()
                Exit Try
            End If

            '入力項目初期値
            '計算クリア
            pNYUKIN_TUMITATE = 0           '入金積立金額
            pNYUKIN_TESU = 0               '入金手数料額
            pNYUKIN_GAKU = 0               '入金額
            pNYUKIN_GAKU_BEFOR = 0

            If Not f_SetForm_KEISAN_AREA(0) Then
                '入力不可
                f_Gamen_Lock()
                Exit Try
            End If

            '明細クリア
            If Not f_Input_DataClr() Then
                '入力不可
                f_Gamen_Lock()
                Exit Try
            End If

            dgv_Search.Enabled = True
            f_DtlButton_Enable(True)
            f_DtlInput_Enable(False)
            f_Button_Enable(False)

            '行選択
            pSelectRowIdx = -1
            If dgv_Search.RowCount > 0 Then
                wMaxRowIdx = dgv_Search.RowCount - 1
                If wMaxRowIdx < wRow Then
                    '最終行
                    pSelectRowIdx = wMaxRowIdx
                Else
                    '更新行
                    pSelectRowIdx = wRow
                End If
                '行選択
                'dgv_Search.Rows(pSelectRowIdx).Selected = True     '2016/05/20　削除
            End If

            '初期コントロールにフォーカスセット
            dgv_Search.Enabled = True
            dgv_Search.Focus()

            '2016/05/20　追加開始
            '該当行を選択する
            If pSelectRowIdx <> -1 Then
                dgv_Search.CurrentCell = dgv_Search(0, pSelectRowIdx)
            End If
            '2016/05/20　追加終了

            'フラグ　クリア
            loblnTextChange = False
            pJump = False

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_SetForm_TT_TUMITATE 積立データ取得処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TT_TUMITATE
    '説明            :積立データ取得処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_TT_TUMITATE() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            '==SQL作成====================
            wSql &= "SELECT"
            wSql &= "     KEI.KEIYAKUSYA_CD AS KEIYAKUSYA_CD"
            wSql &= "    ,KEI.KEN_CD AS KEN_CD"
            wSql &= "    ,CD05.MEISYO AS KEN_CD_NM"
            wSql &= "    ,TUM.SYORI_JOKYO_KBN AS SYORI_JOKYO_KBN"
            wSql &= "    ,CD15.MEISYO AS SYORI_JOKYO_KBN_NM"
            wSql &= "    ,KEI.KEIYAKUSYA_NAME AS KEIYAKUSYA_NAME"
            wSql &= "	 ,KEI.KI AS KI"
            wSql &= "	 ,TO_CHAR(TUM.SEIKYU_DATE, 'EEYY/mm/dd','nls_calendar = ''Japanese Imperial''') AS SEIKYU_DATE"
            wSql &= "	 ,TUM.SEIKYU_KAISU AS SEIKYU_KAISU"
            '2017/08/30　修正開始
            'wSql &= "	 ,TO_CHAR(TUM.SAGAKU_SEIKYU_KIN, '999,999,999') AS SAGAKU_SEIKYU_KIN"
            'wSql &= "	 ,TO_CHAR(TUM.TUMITATE_KIN, '999,999,999') AS TUMITATE_KIN"
            'wSql &= "	 ,TO_CHAR(TUM.TESURYO, '999,999,999') AS TESURYO"
            'wSql &= "	 ,TO_CHAR(TUM.SEIKYU_KIN, '999,999,999') AS SEIKYU_KIN"
            wSql &= "	 ,TO_CHAR(TUM.SAGAKU_SEIKYU_KIN, 'FM999,999,999') AS SAGAKU_SEIKYU_KIN"
            wSql &= "	 ,TO_CHAR(TUM.TUMITATE_KIN, 'FM999,999,999') AS TUMITATE_KIN"
            wSql &= "	 ,TO_CHAR(TUM.TESURYO, 'FM999,999,999') AS TESURYO"
            wSql &= "	 ,TO_CHAR(TUM.SEIKYU_KIN, 'FM999,999,999') AS SEIKYU_KIN"
            '2017/08/30　修正終了
            wSql &= "	 ,TUM.BIKO AS BIKO"
            '    --返還金額(預かり金)
            wSql &= "	 ,TO_CHAR(TUM.SEIKYU_KIN-TUM.SAGAKU_SEIKYU_KIN, 'FM999,999,999') AS HENKAN_KIN"
            wSql &= "	 ,TUM.SEIKYU_KIN-TUM.SAGAKU_SEIKYU_KIN AS HENKAN_KIN_GAKU"
            wSql &= "	 ,TUM.TOKUSOKU_HAKKO_DATE AS TOKUSOKU_HAKKO_DATE_SAVE"
            wSql &= "	 ,TUM.KEIYAKU_HENKO_KBN AS KEIYAKU_HENKO_KBN"       '2016/05/20　追加
            wSql &= "	 ,KEI.KEIYAKU_DATE AS KEIYAKU_DATE"                 '2016/05/20　追加
            wSql &= "	 ,TUM.NOFUKIGEN_DATE " '2021/07/13 JBD9020 新契約日追加 ADD
            wSql &= "    ,KEI.KEIYAKU_JYOKYO " '2021/07/13 JBD9020 新契約日追加 ADD
            wSql &= "    ,KEI.NYU_HEN_DATE " '2021/07/13 JBD9020 新契約日追加 ADD
            wSql &= " FROM"
            wSql &= "     TM_KEIYAKU KEI"
            wSql &= "    ,TT_TUMITATE TUM"
            wSql &= "    ,TM_CODE CD15"
            wSql &= "    ,TM_CODE CD05"
            wSql &= " WHERE"
            '-- 積立金DB
            wSql &= "      KEI.KI = TUM.KI(+)"
            wSql &= "  AND KEI.KEIYAKUSYA_CD = TUM.KEIYAKUSYA_CD(+)"
            wSql &= "  AND 1 = TUM.TUMITATE_KBN(+)"
            '-- 処理状況
            wSql &= "  AND TUM.SYORI_JOKYO_KBN = CD15.MEISYO_CD(+)"
            wSql &= "  AND 15 = CD15.SYURUI_KBN(+)"
            '-- 都道府県
            wSql &= "  AND KEI.KEN_CD = CD05.MEISYO_CD(+)"
            wSql &= "  AND 5 = CD05.SYURUI_KBN(+)"
            '-- 条件
            wSql &= "  AND KEI.KI =  " & p2090_KI
            wSql &= "  AND TUM.DATA_FLG = 1"
            wSql &= "  AND TUM.TUMITATE_KBN = " & pCurrentKey.TUMITATE_KBN
            wSql &= "  AND KEI.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND TUM.SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU


            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                'データ無し
                Show_MessageBox("I003", "")         '指定された条件に一致するデータは存在しません。
                dateNYUKIN_DATE_W.Enabled = False
                txtBiko.Enabled = False
                cmdSave.Enabled = False
                cmdIns.Enabled = False
                cmdUpd.Enabled = False
                cmdDel.Enabled = False
                cmdCancel.Enabled = False
                Exit Try
            End If

            'データセーブ
            With wkDS.Tables(0)
                '契約者番号
                lblKEIYAKUSYA_CD.Text = WordHenkan("N", "S", .Rows(0)("KEIYAKUSYA_CD"))
                '都道府県
                lblKEN_NM.Text = WordHenkan("N", "S", .Rows(0)("KEN_CD_NM"))
                '処理状況
                lblSYORI_JOKYO_KBN.Text = WordHenkan("N", "S", .Rows(0)("SYORI_JOKYO_KBN_NM"))
                '契約者名
                lblKEIYAKUSYA_NAME.Text = WordHenkan("N", "S", .Rows(0)("KEIYAKUSYA_NAME"))
                '契約日
                '2016/05/20　追加開始
                If .Rows(0)("KEIYAKU_DATE") Is DBNull.Value Then
                    dateKEIYAKU_DATE.Value = Nothing
                Else
                    dateKEIYAKU_DATE.Value = CDate(.Rows(0)("KEIYAKU_DATE"))
                End If
                '2016/05/20　追加終了

                '---------------------------------------------------
                '請求入金内容
                '---------------------------------------------------
                '期
                'lblKI.Text = "第" & p2090_KI & "期"
                lblKI.Text = p2090_KI
                '請求日
                lblSEIKYU_DATE.Text = WordHenkan("N", "S", .Rows(0)("SEIKYU_DATE"))
                '請求回数
                lblSEIKYU_KAISU.Text = WordHenkan("N", "S", .Rows(0)("SEIKYU_KAISU"))
                '請求金額
                lblSAGAKU_SEIKYU_KIN.Text = WordHenkan("N", "S", .Rows(0)("SAGAKU_SEIKYU_KIN"))

                '積立金額
                lblTUMITATE_KIN.Text = WordHenkan("N", "S", .Rows(0)("TUMITATE_KIN"))
                '手数料
                lblTESURYO.Text = WordHenkan("N", "S", .Rows(0)("TESURYO"))
                '積立金等総計
                lblSEIKYU_KIN.Text = WordHenkan("N", "S", .Rows(0)("SEIKYU_KIN"))
                '返還金額
                lblHENKAN_KIN.Text = WordHenkan("N", "S", .Rows(0)("HENKAN_KIN"))

                '計算用
                '差額 請求(返還)金額計
                pSAGAKU_SEIKYU_KIN = WordHenkan("N", "S", .Rows(0)("SAGAKU_SEIKYU_KIN"))

                '請求(返還)金額計
                pSEIKYU_KIN = WordHenkan("N", "S", .Rows(0)("SEIKYU_KIN"))
                '積立金
                pTUMITATE_KIN = WordHenkan("N", "S", .Rows(0)("TUMITATE_KIN"))
                '手数料
                pTESURYO = WordHenkan("N", "S", .Rows(0)("TESURYO"))

                '返還金(預かり金)  
                pHENKAN_KIN = WordHenkan("N", "S", .Rows(0)("HENKAN_KIN"))

                '督促状発行日
                If .Rows(0)("TOKUSOKU_HAKKO_DATE_SAVE") Is DBNull.Value Then
                    pTOKUSOKU_HAKKO_DATE = Nothing
                Else
                    pTOKUSOKU_HAKKO_DATE = CDate(.Rows(0)("TOKUSOKU_HAKKO_DATE_SAVE")).ToString
                End If

                '備考
                If .Rows(0)("BIKO") Is DBNull.Value Then
                    pLnk_BIKO = ""
                Else
                    pLnk_BIKO = WordHenkan("N", "S", .Rows(0)("BIKO"))
                End If
                txtBiko.Text = pLnk_BIKO

                '契約変更区分
                lbl_KEIYAKU_HENKO_KBN.Text = .Rows(0)("KEIYAKU_HENKO_KBN").ToString     '2016/05/20　追加

                '2021/07/13 JBD9020 新契約日追加 ADD START
                '納付期限
                Date.TryParse(.Rows(0)("NOFUKIGEN_DATE"), pTUMI_NOFUKIGEN)
                '契約状況
                pKEIYAKU_JOKYO = .Rows(0)("KEIYAKU_JYOKYO")
                '入金返還日
                If .Rows(0)("NYU_HEN_DATE") Is DBNull.Value Then
                    dateNYUHEN_DATE.Value = Nothing
                Else
                    dateNYUHEN_DATE.Value = CDate(.Rows(0)("NYU_HEN_DATE"))
                End If
                '2021/07/13 JBD9020 新契約日追加 ADD END
            End With

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_SetForm_TT_TUMITATE_NYUKIN 積立入金データ取得処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TT_TUMITATE_NYUKIN
    '説明            :積立入金データ取得処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_TT_TUMITATE_NYUKIN() As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty

        Try

            '検索処理
            pDataSet.Clear()

            wSql &= "SELECT"
            wSql &= "     NYU.MEISAI_NO AS MEISAI_NO"
            wSql &= "    ,MAX(NYU.NYUKIN_KAISU) OVER (PARTITION BY NYU.KEIYAKUSYA_CD ORDER BY NYU.KEIYAKUSYA_CD) AS NYUKIN_KAISU_MAX"
            wSql &= "    ,NYU.NYUKIN_KAISU AS NYUKIN_KAISU"
            wSql &= "    ,NYU.NYUKIN_DATE  AS NYUKIN_DATE"
            wSql &= "    ,TO_CHAR(NYU.NYUKIN_DATE, 'EEYY/mm/dd','nls_calendar = ''Japanese Imperial''') NYUKIN_DATE_W"
            wSql &= "    ,NYU.NYUKIN_GAKU AS NYUKIN_GAKU"
            '    --積立金額
            wSql &= "	,CASE"
            wSql &= "	   WHEN NYU.MEISAI_NO = 1 THEN NYU.NYUKIN_TUMITATE + HENKAN_KIN"
            wSql &= "	   ELSE NYU.NYUKIN_TUMITATE"
            wSql &= "	 END NYUKIN_TUMITATE"
            wSql &= "   ,NYU.NYUKIN_TESU AS NYUKIN_TESU"
            '    --合計金額
            wSql &= "	,CASE"
            wSql &= "	   WHEN NYU.MEISAI_NO = 1 THEN NYU.NYUKIN_TUMITATE + NYU.NYUKIN_TESU + HENKAN_KIN"
            wSql &= "	   ELSE NYU.NYUKIN_TUMITATE + NYU.NYUKIN_TESU"
            wSql &= "	 END GOKEI"

            wSql &= "   ,NYU.NYUKIN_ZAN AS NYUKIN_ZAN"
            wSql &= "   ,NYU.BIKO AS BIKO"
            wSql &= " FROM"
            wSql &= "    ("
            wSql &= "    SELECT"
            wSql &= "         ROW_NUMBER() OVER (ORDER BY NYUKIN_KAISU) MEISAI_NO"
            wSql &= "        ,NYUKIN_KAISU"
            wSql &= "        ,KEIYAKUSYA_CD"
            wSql &= "        ,NYUKIN_DATE"
            wSql &= "        ,NYUKIN_GAKU"
            wSql &= "        ,NYUKIN_TUMITATE"
            wSql &= "        ,NYUKIN_TESU"
            wSql &= "        ,NYUKIN_ZAN"
            wSql &= "        ,NYUKIN_NYURYOKU_DATE"
            wSql &= "        ,BIKO"
            '                 -- 返還金
            wSql &= "        ," & pHENKAN_KIN & " AS HENKAN_KIN"
            wSql &= "    FROM"
            wSql &= "         TT_TUMITATE_NYUKIN"
            wSql &= "    WHERE"
            wSql &= "         KI = " & p2090_KI
            wSql &= "     AND SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU
            wSql &= "     AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "     AND TUMITATE_KBN = " & pCurrentKey.TUMITATE_KBN
            wSql &= "    ORDER BY"
            wSql &= "     NYUKIN_KAISU"
            wSql &= "    ) NYU"
            wSql &= " ORDER BY"
            wSql &= "    MEISAI_NO"
            'DBからデータを取得
            If f_Select_ODP(pDataSet, wSql) = False Then
                Exit Try
            End If

            If pDataSet.Tables(0).Rows.Count > 0 Then
                '------------------------------
                '画面に該当データを表示
                '------------------------------
                dgv_Search.DataSource = pDataSet.Tables(0)

            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_SetForm_KEISAN_AREA 入力項目初期値"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_KEISAN_AREA
    '説明            :グリッド横　合計・残高表示
    '引数            :0:初期表示  1:新規　2:変更
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_KEISAN_AREA(ByVal wKbn As Integer) As Boolean
        Dim ret As Boolean = False

        Try

            '------------------------------
            '計算用変数　セット
            '------------------------------
            pNYUKIN_TUMITATE_KEI = 0       '入金積立金額計
            pNYUKIN_TESU_KEI = 0           '入金手数料額計
            pNYUKIN_GAKU_KEI = 0           '入金額計
            pNYUKIN_ZAN = 0                '入金残



            'グリッド内データ加算して計を取得
            For i As Integer = 0 To dgv_Search.RowCount - 1
                ''If wKbn = 2 AndAlso i = pSelectRowIdx Then
                ''    変更元データは加算しない()
                ''Else
                ''    合計加算()
                ''    pNYUKIN_TUMITATE_KEI += CLng(dgv_Search.Item("NYUKIN_TUMITATE", i).Value)
                ''    pNYUKIN_TESU_KEI += CLng(dgv_Search.Item("NYUKIN_TESU", i).Value)
                ''    pNYUKIN_GAKU_KEI += CLng(dgv_Search.Item("NYUKIN_GAKU", i).Value)
                ''End If
                '合計加算
                pNYUKIN_TUMITATE_KEI += CLng(dgv_Search.Item("NYUKIN_TUMITATE", i).Value)
                pNYUKIN_TESU_KEI += CLng(dgv_Search.Item("NYUKIN_TESU", i).Value)
                pNYUKIN_GAKU_KEI += CLng(dgv_Search.Item("NYUKIN_GAKU", i).Value)
            Next
            '入金額計(計算前の退避)
            If wKbn = 0 Then
                pNYUKIN_GAKU_BEFOR_KEI = pNYUKIN_GAKU_KEI
            End If


            '新規・変更のとき、入力値加算
            If wKbn <> 0 Then
                pNYUKIN_TUMITATE_KEI = pNYUKIN_TUMITATE
                pNYUKIN_TESU_KEI = pNYUKIN_TESU
                'pNYUKIN_GAKU_KEI = pNYUKIN_GAKU_KEI + pNYUKIN_GAKU
                pNYUKIN_GAKU_KEI = pNYUKIN_GAKU_BEFOR_KEI - pNYUKIN_GAKU_BEFOR + pNYUKIN_GAKU
            End If

            '残取得
            'pNYUKIN_ZAN = (pSEIKYU_KIN - pHENKAN_KIN) - (pNYUKIN_GAKU_KEI + pNYUKIN_GAKU)
            pNYUKIN_ZAN = (pSEIKYU_KIN - pHENKAN_KIN) - (pNYUKIN_GAKU_BEFOR_KEI - pNYUKIN_GAKU_BEFOR + pNYUKIN_GAKU)

            '------------------------------
            '計算用変数　表示
            '------------------------------
            lblNYUKIN_TUMITATE_KEI.Text = Format(pNYUKIN_TUMITATE_KEI, "###,###,##0")
            lblNYUKIN_TESU_KEI.Text = Format(pNYUKIN_TESU_KEI, "###,###,##0")
            lblNYUKIN_GAKU_KEI.Text = Format(pNYUKIN_GAKU_KEI, "###,###,##0")
            lblNYUKIN_ZAN_KEI.Text = Format(pNYUKIN_ZAN, "###,###,##0")

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_Input_DataClr 入力項目クリア"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_DataClr
    '説明            :入力項目クリア
    '引数            :追加する明細番号
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_Input_DataClr() As Boolean
        Dim ret As Boolean = False

        Try

            '明細番号(隠し項目)
            lblNYUKIN_KAISU.Text = 0
            '入金日
            dateNYUKIN_DATE.Value = Nothing
            dateNYUKIN_DATE_W.Value = Nothing
            '積立金額
            lblNYUKIN_TUMITATE.Text = ""
            '手数料額
            lblNYUKIN_TESU.Text = Nothing
            '入金額
            numNYUKIN_GAKU.Value = Nothing




            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Gamen_Lock エラー時画面入力不可"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Gamen_Lock
    '説明            :エラー時画面入力不可
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_Gamen_Lock() As Boolean
        Dim ret As Boolean = False

        Try

            '入力不可
            f_DtlButton_Enable(False)
            f_DtlInput_Enable(False)
            f_Button_Enable(False)

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_DtlButton_Enable 明細ボタン制御"
    '------------------------------------------------------------------
    'プロシージャ名  :f_DtlButton_Enable
    '説明            :明細ボタン制御
    '引数            :Boolean
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_DtlButton_Enable(ByVal wBool As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            cmdIns.Enabled = wBool
            cmdUpd.Enabled = wBool
            cmdDel.Enabled = wBool

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_DtlInput_Enable 明細データ制御"
    '------------------------------------------------------------------
    'プロシージャ名  :f_DtlInput_Enable
    '説明            :明細データ制御
    '引数            :Boolean
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_DtlInput_Enable(ByVal wBool As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            dateNYUKIN_DATE_W.Enabled = wBool
            numNYUKIN_GAKU.Enabled = wBool
            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_Button_Enable フッタボタン制御"
    '------------------------------------------------------------------
    'プロシージャ名  :f_FtButton_Enable
    '説明            :フッタボタン制御
    '引数            :Boolean
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_Button_Enable(ByVal wBool As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            cmdSave.Enabled = wBool
            cmdCancel.Enabled = wBool

            ret = True

        Catch ex As Exception
            '共通例外処理
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
            lblNYUKIN_KAISU.Text = 0
            dateNYUKIN_DATE.Value = Nothing
            dateNYUKIN_DATE_W.Value = Nothing
            numNYUKIN_GAKU.Value = Nothing
            lblNYUKIN_TUMITATE.Text = ""
            lblNYUKIN_TESU.Text = ""
            txtBiko.Text = ""





            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_HdEnableCtl 入力制御処理(ヘッダ)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_HdEnableCtl
    '説明            :入力制御処理(ヘッダ)
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_HdEnableCtl(ByVal wEnable As Boolean) As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty

        Try

            'ヘッダ
            dgv_Search.Enabled = wEnable
            cmdIns.Enabled = wEnable
            cmdUpd.Enabled = wEnable
            cmdDel.Enabled = wEnable

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_DtlEnableCtl 入力制御処理(明細)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_DtlEnableCtl
    '説明            :入力制御処理(明細)
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_DtlEnableCtl(ByVal wEnable As Boolean) As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty

        Try


            '明細
            dateNYUKIN_DATE_W.Enabled = wEnable
            numNYUKIN_GAKU.Enabled = wEnable
            txtBiko.Enabled = wEnable

            'If wEnable = True Then
            '    'date_KEIYAKU_DATE_TO.Value = f_DateTrim(pJIGYO_SYURYO_DATE)
            'Else
            '    date_KEIYAKU_DATE_TO.Value = Nothing
            'End If

            'フッタ
            cmdSave.Enabled = wEnable
            cmdCancel.Enabled = wEnable

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Input_Check 入力チェック"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check
    '説明            :入力チェック
    '引数            :Boolean
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check() As Boolean
        Dim ret As Boolean = False
        Dim wDate As Date = Nothing         '2016/05/23　追加
        Dim wDate_Max As Date = Nothing     '2016/05/23　追加
        Dim wRow As Integer = 0             '2016/05/23　追加

        Try

            '----------------------------------------
            '必須チェック 
            '---------------------------------------
            '入金日
            If dateNYUKIN_DATE_W.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "入金日・振込日")     '@0は必須入力項目です。
                dateNYUKIN_DATE_W.Focus()
                Exit Try
            End If

            '入金額
            If numNYUKIN_GAKU.Text Is Nothing OrElse numNYUKIN_GAKU.Text = "" Then
                Call Show_MessageBox_Add("W008", "入金額")      '@0は必須入力項目です。
                numNYUKIN_GAKU.Focus()
                Exit Try
            End If
            If numNYUKIN_GAKU.Value = 0 Then
                Call Show_MessageBox_Add("W019", "金額が未入力です")    '@0
                numNYUKIN_GAKU.Focus()
                Exit Try
            End If


            '----------------------------------------
            'その他チェック 
            '---------------------------------------
            '1行入力の時、チェックなし
            'Select Case pSyoriKbn
            '    Case Enu_SyoriKubun.Insert
            '        '新規登録でグリッド０件のとき、エラーチェックなし
            '        If dgv_Search.RowCount = 0 Then
            '            ret = True
            '            Exit Try
            '        End If
            '    Case Enu_SyoriKubun.Update
            '        '変更でグリッド１件のみのとき、エラーチェックなし
            '        If dgv_Search.RowCount = 1 Then
            '            ret = True
            '            Exit Try
            '        End If
            '    Case Else
            '        Exit Try
            'End Select

            '2016/05/23　追加開始
            'グリッドの最終
            If pSyoriKbn = Enu_SyoriKubun.Insert Then
                '新規のとき
                If dgv_Search.Rows.Count > 0 Then
                    wRow = dgv_Search.Rows.Count - 1
                    '最終行と入力した入金日と比較
                    If f_DateTrim(dateNYUKIN_DATE_W.Value) <= f_DateTrim(CDate(dgv_Search.Item("NYUKIN_DATE", wRow).Value.ToString)) Then
                        Call Show_MessageBox_Add("I007", "前回入金日より大きい日付を入力してください")    '@0
                        dateNYUKIN_DATE_W.Focus()
                        Exit Try
                    End If
                End If
            Else
                '選択行
                For i As Integer = 0 To dgv_Search.RowCount - 1
                    If dgv_Search.Rows(i).Selected Then
                        wRow = i
                        Exit For
                    End If
                Next
                '日付の大小チェック
                For i As Integer = 0 To dgv_Search.RowCount - 1
                    If i < wRow Then
                        '選択行以前の場合、グリッドの日付＞入力した入金日はエラー
                        If f_DateTrim(dateNYUKIN_DATE_W.Value) <= f_DateTrim(CDate(dgv_Search.Item("NYUKIN_DATE", i).Value.ToString)) Then
                            Call Show_MessageBox_Add("I007", "前回入金日より大きい日付を入力してください")    '@0
                            dateNYUKIN_DATE_W.Focus()
                            Exit Try
                        End If
                    ElseIf i > wRow Then
                        '選択行以降の場合、グリッドの日付＜入力した入金日はエラー
                        If f_DateTrim(dateNYUKIN_DATE_W.Value) >= f_DateTrim(CDate(dgv_Search.Item("NYUKIN_DATE", i).Value.ToString)) Then
                            Call Show_MessageBox_Add("I007", "次回入金日より小さい日付を入力してください")    '@0
                            dateNYUKIN_DATE_W.Focus()
                            Exit Try
                        End If
                    End If
                Next

            End If
            '2016/05/23　追加終了

            '入金額　チェック
            If lblMEISAI_NO.Text = 3 Then
                If pNYUKIN_ZAN <> 0 Then
                    Call Show_MessageBox_Add("W019", "入金額があやまっています")    '@0
                    numNYUKIN_GAKU.Focus()
                    Exit Try
                End If
            Else
                '入金残が多い時(マイナス表示)にチェックする
                If pNYUKIN_ZAN < 0 Then
                    Call Show_MessageBox_Add("W019", "入金額があやまっています")    '@0
                    numNYUKIN_GAKU.Focus()
                    Exit Try
                End If
            End If



            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_KeiyakuUpdateHantei 契約マスタ．契約日の更新判定"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check
    '説明            :契約マスタ．契約日の更新判定
    '引数            :Boolean
    '戻り値          :Boolean(正常True/エラーFalse)
    '追加日          :2016/05/18　追加
    '------------------------------------------------------------------
    Private Function f_KeiyakuUpdateHantei(ByVal intSyoriKbn As Integer, ByRef wKeiyakuUpKbn As Integer, ByRef wKeiyakuDate As Date) As Boolean
        Dim ret As Boolean = False
        Dim wDate As Date = Nothing
        Dim wDate_MAX As Date = Nothing

        Try

            '------------------------------------------------------------
            '変更区分≠０(新規)のときは更新なし
            '------------------------------------------------------------
            If lbl_KEIYAKU_HENKO_KBN.Text <> "0" Then
                wKeiyakuUpKbn = 0
                wKeiyakuDate = Nothing
                ret = True
                Exit Try
            End If

            '------------------------------------------------------------
            '処理区分が削除のときは、契約日クリア
            '契約日のセーブが未入力のときは、クリアしない
            '------------------------------------------------------------
            If intSyoriKbn = 3 Then
                '2021/07/13 JBD9020 新契約日追加 UPD START
                'If dateKEIYAKU_DATE.Value Is Nothing OrElse dateKEIYAKU_DATE.Value = New Date Then
                If dateNYUHEN_DATE.Value Is Nothing OrElse dateNYUHEN_DATE.Value = New Date Then
                    '2021/07/13 JBD9020 新契約日追加 UPD END
                    wKeiyakuUpKbn = 0
                    wKeiyakuDate = Nothing
                Else
                    wKeiyakuUpKbn = 1
                    wKeiyakuDate = Nothing
                End If
                ret = True
                Exit Try
            End If

            '------------------------------------------------------------
            '追加・修正で入金残高ありのとき、契約日クリア
            '契約日のセーブが未入力のときは、クリアしない
            '------------------------------------------------------------
            If pNYUKIN_ZAN <> 0 Then
                '2021/07/13 JBD9020 新契約日追加 UPD START
                'If dateKEIYAKU_DATE.Value Is Nothing OrElse dateKEIYAKU_DATE.Value = New Date Then
                If dateNYUHEN_DATE.Value Is Nothing OrElse dateNYUHEN_DATE.Value = New Date Then
                    '2021/07/13 JBD9020 新契約日追加 UPD END
                    wKeiyakuUpKbn = 0
                    wKeiyakuDate = Nothing
                Else
                    wKeiyakuUpKbn = 1
                    wKeiyakuDate = Nothing
                End If
                ret = True
                Exit Try
            End If

            '------------------------------------------------------------
            '追加・修正で入金残高なしのとき、グリッドの最終行の契約日
            '------------------------------------------------------------
            '新規登録のとき
            If intSyoriKbn = 1 Then
                '入力した入力日
                wDate_MAX = f_DateTrim(dateNYUKIN_DATE_W.Value)
            Else
                '修正のとき、入力した入力日
                If pSelectRowIdx = dgv_Search.Rows.Count - 1 Then
                    '最終行を選択時は、入力値
                    wDate_MAX = f_DateTrim(dateNYUKIN_DATE_W.Value)
                Else
                    '最終行以外を選択時、最終行の入力日
                    wDate_MAX = f_DateTrim(CDate(dgv_Search.Item("NYUKIN_DATE", dgv_Search.Rows.Count - 1).Value.ToString))
                End If
            End If

            '当初対象積立金納付期限までは、事業開始年度の４月１日
            Dim SyoriKI = New Obj_TM_SYORI_NENDO_KI()

            '2021/07/13 JBD9020 新契約日追加 UPD START
            'If SyoriKI.pNOFU_KIGEN >= wDate_MAX Then
            '    '契約日を事業開始年月日する
            '    wDate_MAX = SyoriKI.pJIGYO_NENDO_byDate
            'End If

            ''契約日の更新判定
            'If dateKEIYAKU_DATE.Value Is Nothing OrElse dateKEIYAKU_DATE.Value = New Date Then
            '    '契約マスタ．契約日=NULLのとき、契約日更新
            '    wKeiyakuUpKbn = 1
            '    wKeiyakuDate = wDate_MAX
            'ElseIf wDate_MAX = f_DateTrim(dateKEIYAKU_DATE.Value) Then
            '    '最大値＝契約日のとき、更新なし
            '    wKeiyakuUpKbn = 0
            '    wKeiyakuDate = Nothing
            'Else
            '    '最大値≠契約日のとき、契約日更新
            '    wKeiyakuUpKbn = 1
            '    wKeiyakuDate = wDate_MAX
            'End If

            '新規の場合
            If pKEIYAKU_JOKYO = 1 Then
                '入金日が納付期限より後の場合
                If pTUMI_NOFUKIGEN < wDate_MAX Then
                    '契約日が入金日
                    wKeiyakuDate = wDate_MAX
                    '入金日が納付期限以前の場合
                Else
                    '契約日は更新なし
                    wKeiyakuDate = dateKEIYAKU_DATE.Value
                End If
                '継続の場合
            Else
                '入金日が当初納付期限より後の場合
                If SyoriKI.pNOFU_KIGEN < wDate_MAX Then
                    '入金日が納付期限より後の場合
                    If pTUMI_NOFUKIGEN < wDate_MAX Then
                        '契約日が入金日
                        wKeiyakuDate = wDate_MAX
                        '入金日が納付期限以前の場合
                    Else
                        '契約日は更新なし
                        wKeiyakuDate = dateKEIYAKU_DATE.Value
                    End If
                Else
                    '契約日を事業開始年月日する
                    wKeiyakuDate = SyoriKI.pJIGYO_NENDO_byDate
                End If
            End If
            wKeiyakuUpKbn = 1
            '2021/07/13 JBD9020 新契約日追加 UPD END

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region
#Region "f_Delete_Check 削除チェック"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Delete_Check
    '説明            :削除チェック
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '追加日          :2016/05/18　追加
    '------------------------------------------------------------------
    Private Function f_Delete_Check() As Boolean
        Dim ret As Boolean = False
        Dim wDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wRow As Integer = 0

        Try

            '------------------------------------------------------------
            '   積立金入金済み　チェック
            '------------------------------------------------------------
            '積立金データ取得
            wSql &= "SELECT"
            wSql &= "  COUNT(TUM.KEIYAKUSYA_CD) KENSU,"
            wSql &= "  MIN(KJO.DATA_FLG) DATA_FLG "
            wSql &= "FROM"
            wSql &= "  TT_TUMITATE TUM,"
            wSql &= "  TT_KEIYAKU_JOHO KJO "
            wSql &= "WHERE TUM.KI = " & p2090_KI
            wSql &= "  AND TUM.SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU
            wSql &= "  AND TUM.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND TUM.TUMITATE_KBN = " & pCurrentKey.TUMITATE_KBN
            wSql &= "  AND TUM.KI = KJO.KI(+)"
            wSql &= "  AND TUM.KEIYAKUSYA_CD = KJO.KEIYAKUSYA_CD(+)"
            wSql &= "  AND TUM.SEIKYU_KAISU = KJO.SEIKYU_KAISU(+)"

            'DBからデータを取得
            If Not f_Select_ODP(wDS, wSql) Then
                Exit Try
            End If

            'データ有無
            If wDS.Tables(0).Rows.Count = 0 OrElse wDS.Tables(0).Rows(0)("KENSU").ToString = "0" Then
                Show_MessageBox_Add("I007", "該当のデータが存在しません。")
            ElseIf wDS.Tables(0).Rows(0)("DATA_FLG").ToString <> "1" Then
                '無効データは入金取消不可
                Show_MessageBox_Add("I007", "該当の契約は既に変更済みです。" & vbCrLf &
                                            "入金取消できません。")
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


End Class
