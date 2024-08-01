'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ1012.vb
'*
'*　　②　機能概要　　　　　互助基金契マスタメンテンテナンス(契約情報)
'*
'*　　③　作成日　　　　　　2015/01/24　BY JBD
'*
'*　　④　更新日            
'*
'*******************************************************************************
Option Strict Off
Option Explicit On
'------------------------------------------------------------------

Imports JbdGjsCommon
Imports JbdGjsControl
'------------------------------------------------------------------


Public Class frmGJ1012

#Region "***変数定義***"

    ''' <summary>
    ''' 固定項目
    ''' </summary>
    ''' <remarks></remarks>
    Property p1010_KI As Integer

    ''' <summary>
    ''' 処理状況
    ''' </summary>
    ''' <remarks></remarks>
    Property pLoadErr As Boolean

    ''' <summary>
    ''' グリッドキー項目構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T_KEY

        ''' <summary>
        ''' 契約者コード
        ''' </summary>
        ''' <remarks></remarks>
        Public KEIYAKUSYA_CD As String = String.Empty

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
    Public paryKEY_1010 As New List(Of frmGJ1010.T_KEY)

    ''' <summary>
    ''' カレント主キー
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pCurrentKey As frmGJ1010.T_KEY

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
    Private pJIGYO_KAISU_DATE As Date       '事業開始日
    Private pJIGYO_SYURYO_DATE As Date      '事業終了日
    '明細件数
    Private pLineMax As Integer = 999
    '契約情報
    Private pKEIYAKUSYA_NAME As String = String.Empty   '契約区分
    Private pKEIYAKU_KBN As Integer = 0                 '契約区分
    Private pNYURYOKU_JYOKYO As Integer = 0             '入力状況
    Private pTUMITATE_ARI As Boolean = False            '積立金有無
    'セーブ
    Private pTORI_KBN As String = ""

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
        Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI
        Dim wMsg As String = String.Empty

        Try

            pJIGYO_KAISU_DATE = clsNENDO_KI.pJIGYO_NENDO_byDate         '事業開始日
            pJIGYO_SYURYO_DATE = clsNENDO_KI.pJIGYO_SYURYO_NENDO_byDate '事業最終日

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            '画面初期化
            pJump = True
            ret = f_ObjectClear("C")
            pJump = False

            'スキーマ確認
            If pKikin2 Then
                cmdCopy.Visible = False
            End If

            'コンボボックスセット
            If Not f_ComboBox_Set("C") Then
                Exit Try
            End If

            '---------------------------------------------------
            'データの読み込み(画面のセットは行っていない)
            '---------------------------------------------------
            '契約情報セーブ
            If Not f_SetForm_Data(wMsg) Then
                pLoadErr = True
                'Throw New Exception("該当契約者が存在しませんでした")
                Throw New Exception(wMsg)
            End If

            '積立データ有無
            If Not f_Tumitate_Data() Then
                Exit Try
            End If

            'グリッド　表示
            If Not f_Grid_Set("C", 0, 0, 0) Then
                Exit Try
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
            If ex.Message <> "" Then
                Show_MessageBox("", ex.Message)
            End If
            'フォームクローズ
            Me.Close()
        Finally
            clsNENDO_KI = Nothing
        End Try

    End Sub

#End Region

#End Region

#Region "***画面ボタンクリック関連***"

#Region "cmdIns_Click 新規入力ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdIns_Click
    '説明            :新規入力ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIns.Click
        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '再抽出
            'If dgv_Search.RowCount > 4 Then
            If dgv_Search.RowCount >= pLineMax Then
                Show_MessageBox_Add("W019", "これ以上登録できません。") '@0
                Exit Try
            End If

            '積立データチェック
            If pTUMITATE_ARI Then
                Show_MessageBox_Add("I007", "今事業期の積立金が存在する契約者は" & vbCrLf & "新規登録できません")
                Exit Try
            End If

            '処理区分：登録
            pSyoriKbn = Enu_SyoriKubun.Insert
            lbl_SEQNO.Text = 0

            '入力制御
            If Not f_HdEnableCtl(False) Then
                Exit Try
            End If
            If Not f_DtlEnableCtl(True) Then
                Exit Try
            End If

            date_KEIYAKU_DATE_FROM.Value = f_DateTrim(pJIGYO_KAISU_DATE) '2020/09/09 JBD9020 ADD 

            loblnTextChange = False

            '★初期コントロールにフォーカスセット
            cob_NOJO_CD.Focus()

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
        Dim numSelectRowIdx As Integer
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

            '選択されている行を見つける
            For i As Integer = 0 To dgv_Search.RowCount - 1
                If dgv_Search.Rows(i).Selected Then
                    '選択されている行が見つかったのでインデックスをワークに退避
                    numSelectRowIdx = i
                    Exit For
                End If
            Next

            '--------------------------------------------------
            'グリッド選択行の情報を各入力項目に格納
            '--------------------------------------------------
            '隠し項目
            lbl_SEQNO.Text = WordHenkan("N", "Z", dgv_Search.Item("SEQNO", numSelectRowIdx).Value)

            '明細番号
            lbl_MEISAI_NO.Text = WordHenkan("N", "Z", dgv_Search.Item("MEISAI_NO", numSelectRowIdx).Value)

            '農場名
            cob_NOJO_CD.Text = WordHenkan("N", "S", dgv_Search.Item("NOJO_CD", numSelectRowIdx).Value)

            '農場郵便番号
            wStr = WordHenkan("N", "S", dgv_Search.Item("ADDR_POST", numSelectRowIdx).Value)
            If wStr = "" Then
                lbl_ADDR_POST.Text = ""
            Else
                lbl_ADDR_POST.Text = f_MidB(wStr, 1, 3) & "-" & f_MidB(wStr, 4, 4)
            End If

            '農場住所
            lbl_ADDR_1.Text = WordHenkan("N", "S", dgv_Search.Item("ADDR_1", numSelectRowIdx).Value)
            lbl_ADDR_2.Text = WordHenkan("N", "S", dgv_Search.Item("ADDR_2", numSelectRowIdx).Value)
            lbl_ADDR_3.Text = WordHenkan("N", "S", dgv_Search.Item("ADDR_3", numSelectRowIdx).Value)
            lbl_ADDR_4.Text = WordHenkan("N", "S", dgv_Search.Item("ADDR_4", numSelectRowIdx).Value)

            '鶏の種類
            cob_TORI_KBN.Text = WordHenkan("N", "S", dgv_Search.Item("TORI_KBN", numSelectRowIdx).Value)

            '出荷羽数
            num_KEIYAKU_HASU.Value = CDec(WordHenkan("N", "Z", dgv_Search.Item("KEIYAKU_HASU", numSelectRowIdx).Value))

            '契約年月日（自）
            wStr = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_DATE_FROM", numSelectRowIdx).Value)
            If wStr = "" Then
                date_KEIYAKU_DATE_FROM.Value = Nothing
            Else
                date_KEIYAKU_DATE_FROM.Value = CDate(wStr)
            End If

            '契約年月日（至）
            wStr = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_DATE_TO", numSelectRowIdx).Value)
            If wStr = "" Then
                date_KEIYAKU_DATE_TO.Value = Nothing
            Else
                date_KEIYAKU_DATE_TO.Value = CDate(wStr)
            End If

            '備考
            txt_Biko.Text = WordHenkan("N", "S", dgv_Search.Item("BIKO", numSelectRowIdx).Value)

            '--------------------------------------------------
            '更新可能　判定
            '--------------------------------------------------
            '積立データチェック
            If pTUMITATE_ARI Then
                Show_MessageBox_Add("I007", "今事業期の積立金が存在する契約者は" & vbCrLf & "変更できません")
                '入力制御(キャンセルのみ)
                If Not f_HdEnableCtl(False) Then
                    Exit Try
                End If
                If Not f_DtlEnableCtl(False, False) Then
                    Exit Try
                End If
                cmdCansel.Enabled = True
                '画面入力内容変更フラグクリア
                loblnTextChange = False
                Exit Try
            End If

            '入力制御
            If Not f_HdEnableCtl(False) Then
                Exit Try
            End If
            If Not f_DtlEnableCtl(True) Then
                Exit Try
            End If

            '★初期コントロールにフォーカスセット
            cob_TORI_KBN.Focus()

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
        Dim wDel_MEISAI_NO As Integer = 0
        Dim wDel_NOJO_CD As Integer = 0
        Dim wDel_TORI_KBN As Integer = 0

        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")
                Exit Try
            End If

            '積立データチェック
            If pTUMITATE_ARI Then
                Show_MessageBox_Add("I007", "今事業期の積立金が存在する契約者は" & vbCrLf & "削除できません")
                Exit Try
            End If

            '削除処理確認
            If Show_MessageBox_Add("Q006", "指定されたデータ") = DialogResult.No Then    '指定されたデータを削除します。よろしいですか？
                Exit Try
            End If

            '該当データ取得
            Dim intRow As Integer = 0       '行番号
            For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
                intRow = gRow.Index
            Next

            'キー項目
            lbl_SEQNO.Text = WordHenkan("N", "Z", dgv_Search.Item("SEQNO", intRow).Value)
            wDel_MEISAI_NO = WordHenkan("N", "Z", dgv_Search.Item("MEISAI_NO", intRow).Value)
            wDel_NOJO_CD = WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD", intRow).Value)
            wDel_TORI_KBN = WordHenkan("N", "Z", dgv_Search.Item("TORI_KBN", intRow).Value)

            '該当データ削除処理
            If Not f_Data_Deleate(intRow) Then
                Exit Try
            End If

            'グリッド　再表示
            f_Grid_Set("", wDel_MEISAI_NO, wDel_NOJO_CD, wDel_TORI_KBN)

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

#Region "cmd_NOJO_INS_Click 契約農業登録ボタンクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmd_NOJO_INS_Click
    '説明            :契約農業登録ボタンクリック時処理
    '------------------------------------------------------------------
    Private Sub cmd_NOJO_INS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_NOJO_INS.Click
        Dim tKEY As New T_KEY
        Dim strtNowKEY As T_KEY = Nothing
        Dim ret As Boolean = False


        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            If pSyoriKbn = Enu_SyoriKubun.Update AndAlso cob_NOJO_CD.Text.Trim = "" Then
                Show_MessageBox_Add("I007", "農場コードが指定されていません")
                Exit Try
            End If

            Using wkForm As New frmGJ1013
                wkForm.Owner = Me
                wkForm.p1013_KI = p1010_KI
                wkForm.p1013_KEIYAKUSYA_CD = pCurrentKey.KEIYAKUSYA_CD
                wkForm.p1013_KEIYAKUSYA_NAME = pKEIYAKUSYA_NAME
                wkForm.p1013_SyoriKbn = pSyoriKbn
                If pSyoriKbn = Enu_SyoriKubun.Insert Then
                    wkForm.p1013_NOJO_CD = ""
                Else
                    wkForm.p1013_NOJO_CD = cob_NOJO_CD.Text.Trim
                End If

                wkForm.ShowDialog()

                '農場コード登録時
                If wkForm.p1013_NOJO_CD = "" Then
                    '農場未入力
                    cob_NOJO_CD.Focus()
                Else
                    'コンボ　再セット
                    ret = f_ComboBox_Set("")
                    '農場コード表示
                    cob_NOJO_CD.Text = wkForm.p1013_NOJO_CD
                    cob_NOJO_nm.SelectedIndex = cob_NOJO_CD.SelectedIndex
                    '農場住所表示
                    f_NojoAddr_Dsp()
                    '次項目
                    cob_TORI_KBN.Focus()
                End If

            End Using

            dgv_Search.Refresh()

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
        Dim wUpd_MEISAI_NO As Integer = 0
        Dim wUpd_NOJO_CD As Integer = 0
        Dim wUpd_TORI_KBN As Integer = 0

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            If pSyoriKbn = Enu_SyoriKubun.Update Then   '変更
                If loblnTextChange Then
                Else
                    '画面に変更がない場合は、メッセージ表示
                    Show_MessageBox_Add("I007", "変更したデータはありません。")
                    Exit Try
                End If
            End If

            '事前チェック
            If Not f_Input_Check(0) Then
                Exit Try
            End If

            Dim intRow As Integer = 0       '行番号

            For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
                intRow = gRow.Index
            Next

            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert       '新規入力

                    '保存処理確認
                    If Show_MessageBox_Add("Q004", "データ") = DialogResult.No Then    '保存します。よろしいですか？
                        Exit Try
                    End If

                    'データ保存処理
                    If Not f_Data_Insert() Then
                        Exit Try
                    End If

                Case Enu_SyoriKubun.Update       '変更

                    '保存処理確認
                    If Show_MessageBox_Add("Q005", "データ") = DialogResult.No Then    '保存します。よろしいですか？
                        Exit Try
                    End If

                    'データ保存処理
                    If Not f_Data_update(intRow) Then
                        Exit Try
                    End If

            End Select


            'キー項目
            wUpd_MEISAI_NO = lbl_MEISAI_NO.Text.Trim
            wUpd_NOJO_CD = cob_NOJO_CD.Text.Trim
            wUpd_TORI_KBN = cob_TORI_KBN.Text.Trim

            'グリッド　再表示
            f_Grid_Set("", wUpd_MEISAI_NO, wUpd_NOJO_CD, wUpd_TORI_KBN)

            '2020/09/09 JBD9020 ADD START
            If pSyoriKbn = Enu_SyoriKubun.Insert Then
                date_KEIYAKU_DATE_FROM.Value = f_DateTrim(pJIGYO_KAISU_DATE)
            End If
            '2020/09/09 JBD9020 ADD END

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

#Region "cmdCopy_Click コピーボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdCopy_Click
    '説明            :コピーボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy.Click
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '一覧より選択されていなければエラー
            If dgv_Search.Rows.Count > 0 Then
                Show_MessageBox_Add("I007", "既にデータが存在します")       '@0
                Exit Try
            End If

            '事前チェック
            If Not f_Input_Check(1) Then
                Exit Try
            End If

            '保存処理確認
            If Show_MessageBox_Add("Q013", "前期のデータをコピーします") = DialogResult.No Then    '@0。よろしいですか？
                Exit Try
            End If

            'データ保存処理
            If Not f_Data_Copy() Then
                Exit Try
            End If

            'グリッド　再表示
            f_Grid_Set("Z", 0, 0, 0)

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

        '画面クリア
        f_DtlClear()
        '入力制御
        f_HdEnableCtl(True)
        f_DtlEnableCtl(False)

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

#Region "農場関連"

    ''' <summary>
    ''' 農場コード項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_NOJO_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_NOJO_CD.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_NOJO_nm.SelectedIndex = cob_NOJO_CD.SelectedIndex

    End Sub

    ''' <summary>
    ''' 農場名項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_NOJO_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_NOJO_nm.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_NOJO_CD.SelectedIndex = cob_NOJO_nm.SelectedIndex
        '農場住所表示
        'If cob_NOJO_nm.SelectedIndex = -1 Then                                 '2024/02/13 JBD453 R05年度改修　コンボボックスの既存バグを修正するため　変更
        If cob_NOJO_nm.SelectedIndex = 0 Or cob_NOJO_nm.SelectedIndex = -1 Then '2024/02/13 JBD453 R05年度改修　コンボボックスの既存バグを修正するため　変更
            f_NojoAddr_Clr()
        Else
            f_NojoAddr_Dsp()
        End If
    End Sub

    ''' <summary>
    ''' 農場コード確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_NOJO_NM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_NOJO_CD.Validating

        Try

            If cob_NOJO_CD.Text = "" Then
                '住所クリア
                f_NojoAddr_Clr()
                Exit Sub
            End If


            '先頭ゼロを削除
            DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString

            cob_NOJO_CD.SelectedValue = cob_NOJO_CD.Text
            If cob_NOJO_CD.SelectedValue Is Nothing Then
                cob_NOJO_CD.SelectedIndex = -1
                cob_NOJO_nm.SelectedIndex = -1
                '住所クリア
                f_NojoAddr_Clr()
                Show_MessageBox_Add("W012", "農場") '指定された@0が正しくありません。
                cob_NOJO_CD.Focus()
                Exit Try
            End If

            '農場住所表示
            f_NojoAddr_Dsp()
        Catch ex As Exception
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 農場名確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_NOJO_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_NOJO_nm.Validating

        Try

            If cob_NOJO_nm.Text = "" Then
                f_NojoAddr_Clr()
                Exit Sub
            End If

            '農場住所表示
            f_NojoAddr_Dsp()

        Catch ex As Exception
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#Region "鶏の種類関連"

    Private Sub cob_TORI_KBN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_TORI_KBN.Enter
        pTORI_KBN = cob_TORI_KBN.Text
    End Sub

    ''' <summary>
    ''' 鶏の種類コード項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KeiyakusyaKbnCd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_TORI_KBN.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_TORI_KBN_NM.SelectedIndex = cob_TORI_KBN.SelectedIndex

    End Sub

    ''' <summary>
    ''' 鶏の種類名項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KeiyakusyaKbnNm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_TORI_KBN_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_TORI_KBN.SelectedIndex = cob_TORI_KBN_NM.SelectedIndex

    End Sub

    ''' <summary>
    ''' 鶏の種類コード確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KeiyakusyaKbnCd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_TORI_KBN.Validating

        If cob_TORI_KBN.Text = "" Then
            'date_KEIYAKU_DATE_FROM.Value = Nothing      '2015/10/16　追加  '2021/02/22 JBD9020 R02年度 DEL 
            Exit Sub
        End If

        '先頭ゼロを削除
        DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString

        cob_TORI_KBN.SelectedValue = cob_TORI_KBN.Text
        If cob_TORI_KBN.SelectedValue Is Nothing Then
            cob_TORI_KBN.SelectedIndex = -1
            cob_TORI_KBN_NM.SelectedIndex = -1
            Show_MessageBox_Add("W012", "鶏の種類") '指定された@0が正しくありません。
            'date_KEIYAKU_DATE_FROM.Value = Nothing      '2015/10/16　追加  '2021/02/22 JBD9020 R02年度 DEL
            cob_TORI_KBN.Focus()
        End If

        '2015/10/16　削除
        ''2015/10/16　追加開始
        ''値の変更時は単価マスタから契約日(FROM)表示
        'If pTORI_KBN <> cob_TORI_KBN.Text Then
        '    If Not f_KEIYAKU_DATE_FROM() Then
        '        date_KEIYAKU_DATE_FROM.Value = Nothing
        '    End If
        'End If
        ''2015/10/16　追加終了

    End Sub

#End Region

#End Region

#Region "*** データ登録関連 ***"

#Region "契約情報　登録"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Insert
    '説明            :契約情報　登録
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Insert() As Boolean
        Dim ret As Boolean = False
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ1012.GJ1012_KEIYAKU_JOHO_INS"


            '----------------------------------------
            '   情報
            '----------------------------------------
            '期
            Cmd.Parameters.Add("IN_KI", p1010_KI)
            '契約者
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", pCurrentKey.KEIYAKUSYA_CD) '自動採番    SEQNO

            '契約年月日From  
            If date_KEIYAKU_DATE_FROM.Value Is Nothing OrElse date_KEIYAKU_DATE_FROM.Value = New Date Then
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_FROM", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_FROM", f_DateTrim(date_KEIYAKU_DATE_FROM.Value))
            End If
            '契約年月日To    
            If date_KEIYAKU_DATE_TO.Value Is Nothing OrElse date_KEIYAKU_DATE_TO.Value = New Date Then
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", f_DateTrim(date_KEIYAKU_DATE_TO.Value))
            End If

            '農場コード   
            Cmd.Parameters.Add("IN_NOJO_CD", cob_NOJO_CD.Text.Trim)

            '契約区分　1:家族 2:企業 3:うずら  
            Cmd.Parameters.Add("IN_KEIYAKU_KBN", pKEIYAKU_KBN)

            '鶏の種類    
            Cmd.Parameters.Add("IN_TORI_KBN", cob_TORI_KBN.Text.Trim)

            'データフラグ 0:無効 1:有効    DATA_FLG
            Cmd.Parameters.Add("IN_DATA_FLG", 1)

            '契約変更区分 0:新規 1:羽数増加 2:契約変更(家族→企業) 3:契約変更(企業→家族) 4:譲渡(家族→企業)    KEIYAKU_HENKO_KBN
            Cmd.Parameters.Add("IN_KEIYAKU_HENKO_KBN", 0)

            '契約羽数    KEIYAKU_HASU
            Cmd.Parameters.Add("IN_KEIYAKU_HASU", num_KEIYAKU_HASU.Value)

            '増羽：増えた分 譲渡：増えた分or減った分    ZOGEN_HASU
            Cmd.Parameters.Add("IN_ZOGEN_HASU", num_KEIYAKU_HASU.Value)

            '備考    BIKO
            Cmd.Parameters.Add("IN_BIKO", txt_Biko.Text)

            '----------------------------------------
            '   共通情報
            '----------------------------------------
            'データ登録日    
            Cmd.Parameters.Add("IN_REG_DATE", wNow)
            'データ登録ＩＤ   
            Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
            'データ更新日    
            Cmd.Parameters.Add("IN_UP_DATE", wNow)
            'データ更新ＩＤ    
            Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            'コンピュータ名 
            Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)

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

#Region "契約情報　更新"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_update
    '説明            :契約情報　更新
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_update(ByVal intRow As Integer) As Boolean
        Dim ret As Boolean = False
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ1012.GJ1012_KEIYAKU_JOHO_UPD"

            '----------------------------------------
            '   情報
            '----------------------------------------
            'SEQNO
            Dim paraSEQ As OracleParameter = Cmd.Parameters.Add("IN_SEQ", dgv_Search.Item("SEQNO", intRow).Value)

            '契約年月日From  
            If date_KEIYAKU_DATE_FROM.Value Is Nothing OrElse date_KEIYAKU_DATE_FROM.Value = New Date Then
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_FROM", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_FROM", f_DateTrim(date_KEIYAKU_DATE_FROM.Value))
            End If
            '契約年月日To 
            If date_KEIYAKU_DATE_TO.Value Is Nothing OrElse date_KEIYAKU_DATE_TO.Value = New Date Then
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", f_DateTrim(date_KEIYAKU_DATE_TO.Value))
            End If

            '契約区分　1:家族 2:企業 3:うずら  
            Cmd.Parameters.Add("IN_KEIYAKU_KBN", pKEIYAKU_KBN)

            '契約羽数  
            Cmd.Parameters.Add("IN_KEIYAKU_HASU", num_KEIYAKU_HASU.Value)
            '増減羽数  
            Cmd.Parameters.Add("IN_ZOGEN_HASU", num_KEIYAKU_HASU.Value)

            '備考    BIKO
            Cmd.Parameters.Add("IN_BIKO", txt_Biko.Text)

            '----------------------------------------
            '   共通情報
            '----------------------------------------
            'データ更新日    
            Cmd.Parameters.Add("IN_UP_DATE", wNow)
            'データ更新ＩＤ    
            Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            'コンピュータ名 
            Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)

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

#Region "契約情報　削除処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Deleate
    '説明            :契約情報　削除処理
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
            Cmd.CommandText = "PKG_GJ1012.GJ1012_KEIYAKU_JOHO_DEL"

            '引き渡し
            'SEQNO
            Dim paraSEQ As OracleParameter = Cmd.Parameters.Add("IN_SEQ", WordHenkan("N", "Z", dgv_Search.Item("SEQNO", intRow).Value))

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

#Region "契約情報　コピー"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Insert
    '説明            :契約情報　登録
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Copy() As Boolean
        Dim ret As Boolean = False
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ1012.GJ1012_KEIYAKU_JOHO_CPY"

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期
            Cmd.Parameters.Add("IN_KI", p1010_KI)
            '契約者
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", pCurrentKey.KEIYAKUSYA_CD) '自動採番    SEQNO
            '契約区分　1:家族 2:企業 3:うずら  
            Cmd.Parameters.Add("IN_KEIYAKU_KBN", pKEIYAKU_KBN)

            '契約年月日From  
            If date_KEIYAKU_DATE_FROM.Value Is Nothing OrElse date_KEIYAKU_DATE_FROM.Value = New Date Then
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_FROM", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_FROM", f_DateTrim(date_KEIYAKU_DATE_FROM.Value))
            End If
            '契約年月日To    
            If date_KEIYAKU_DATE_TO.Value Is Nothing OrElse date_KEIYAKU_DATE_TO.Value = New Date Then
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", f_DateTrim(date_KEIYAKU_DATE_TO.Value))
            End If

            '----------------------------------------
            '   共通情報
            '----------------------------------------
            'データ登録日    
            Cmd.Parameters.Add("IN_REG_DATE", wNow)
            'データ登録ＩＤ   
            Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
            'データ更新日    
            Cmd.Parameters.Add("IN_UP_DATE", wNow)
            'データ更新ＩＤ    
            Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            'コンピュータ名 
            Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)

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

        'フォーム上に配置されているすべてのコントロールを列挙
        Dim All_Ctl As Control() = f_GetAllControls(Me)

        For Each wkCtrl As Control In All_Ctl

            Select Case True
                Case (TypeOf wkCtrl Is JBD.Gjs.Win.GcComboBox)
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

        f_ObjectClear = False

        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            pJump = True
            f_ClearFormALL(Me, wKbn)
            pJump = False

            'ヘッダ表示
            lbl_KI.Text = "第" & p1010_KI & "期"
            lbl_KEIYAKUSYA_CD.Text = pCurrentKey.KEIYAKUSYA_CD
            lbl_KEIYAKUSYA_NM.Text = pKEIYAKUSYA_NAME
            lbl_KENSU.Text = ""     '2015/10/16　追加

            '====初期値設定======================
            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert

                Case Enu_SyoriKubun.Update

            End Select

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
#Region "f_ComboBox_Set コンボボックスセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ComboBox_Set
    '説明            :コンボボックスセット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ComboBox_Set(ByVal wKbn As String) As Boolean
        Dim ret As Boolean = False
        Dim wWhere As String = String.Empty

        Try

            wWhere = "KI = " & p1010_KI & " AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD

            '農場コンボセット
            If Not f_KeiyakuNojo_Data_Select(cob_NOJO_CD, cob_NOJO_nm, wWhere, True) Then
                Exit Try
            End If
            'コンボボックス初期化()
            cob_NOJO_CD.Text = ""

            '初期処理のときのみ
            If wKbn = "C" Then
                '鳥の種類コンボセット
                If Not f_CodeMaster_Data_Select(cob_TORI_KBN, cob_TORI_KBN_NM, 7, True, 1) Then
                    Exit Try
                End If
                'コンボボックス初期化()
                cob_TORI_KBN.Text = ""
            End If


            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region


#Region "f_SetForm_Data 初期画面表示(修正)処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_Data(ByRef wMsg As String) As Boolean
        Dim ret As Boolean = False
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            'SQL
            wSql = "SELECT * FROM TM_KEIYAKU " & _
                   "WHERE KI = " & p1010_KI & _
                   "  AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                wMsg = "該当契約者が存在しませんでした。"
                'データ無し
                Exit Try
            End If

            'データセーブ
            With wkDS.Tables(0)

                '契約区分
                'pKEIYAKU_KBN = WordHenkan("N", "Z", .Rows(0)("KEIYAKU_KBN"))
                If .Rows(0)("KEIYAKU_KBN").ToString = "" Then
                    wMsg = "契約区分が設定されていません。"
                    'データ無し
                    Exit Try
                Else
                    pKEIYAKU_KBN = WordHenkan("N", "Z", .Rows(0)("KEIYAKU_KBN"))
                End If

                '契約者名
                pKEIYAKUSYA_NAME = WordHenkan("N", "S", .Rows(0)("KEIYAKUSYA_NAME"))

                '入力状況  
                'pNYURYOKU_JYOKYO = WordHenkan("N", "Z", .Rows(0)("NYURYOKU_JYOKYO"))
                If .Rows(0)("NYURYOKU_JYOKYO").ToString = "" Then
                    wMsg = "入力確認有無が設定されていません。"
                    'データ無し
                    Exit Try
                Else
                    pNYURYOKU_JYOKYO = WordHenkan("N", "Z", .Rows(0)("NYURYOKU_JYOKYO"))
                End If

            End With

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region
#Region "f_Tumitate_Data 積立データ有無チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Tumitate_Data
    '説明            :積立データ有無チェック処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Tumitate_Data() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            'SQL
            wSql = "SELECT COUNT(*) CNT FROM TT_TUMITATE " & _
                   "WHERE KI = " & p1010_KI & _
                   "  AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD & _
                   "  AND TUMITATE_KBN = 1"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                'データ無し
                pTUMITATE_ARI = False
            Else
                If WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("CNT")) = 0 Then
                    'データ無し
                    pTUMITATE_ARI = False
                Else
                    'データ無し
                    pTUMITATE_ARI = True
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
#Region "f_Grid_Set コンボボックスセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ComboBox_Set
    '説明            :コンボボックスセット処理
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

            '初期処理以外は、画面クリア
            If wKbn <> "C" Then
                ret1 = f_ObjectClear("")
            End If

            '--------------------------------------------------
            '   羽数合計
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
                    '2017/07/10　修正開始
                    'num_HASU1.Value = CLng(WordHenkan("N", "Z", .Rows(0)("HASU1")))
                    'num_HASU2.Value = CLng(WordHenkan("N", "Z", .Rows(0)("HASU2")))
                    'num_HASU3.Value = CLng(WordHenkan("N", "Z", .Rows(0)("HASU3")))
                    'num_HASU4.Value = CLng(WordHenkan("N", "Z", .Rows(0)("HASU4")))
                    'num_HASU5.Value = CLng(WordHenkan("N", "Z", .Rows(0)("HASU5")))
                    'num_HASU6.Value = CLng(WordHenkan("N", "Z", .Rows(0)("HASU6")))
                    'num_HASU0.Value = CLng(WordHenkan("N", "Z", .Rows(0)("HASU0")))
                    For I = 0 To 11
                        DirectCast(Me.Controls("num_HASU" & Format(I, "00")), JBD.Gjs.Win.GcNumber).Value = CLng(WordHenkan("N", "Z", .Rows(0)("HASU" & Format(I, "00"))))
                    Next
                    '2017/07/10　修正終了
                End If
            End With

            '--------------------------------------------------
            '   グリッド
            '--------------------------------------------------
            'データセット　クリア
            If Not pDataSet Is Nothing Then
                pDataSet.Clear()
                lbl_KENSU.Text = ""                     '2015/10/16
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
            lbl_KENSU.Text = Format(dgv_Search.Rows.Count, "##,##0")  '2015/10/16

            '--------------------------------------------------
            '   グリッド表示位置
            '--------------------------------------------------
            If wKbn = "" Then
                ret1 = f_GridReDisp(wMEISAI_NO, wNOJO_CD, wTORI_KBN)
            End If

            '--------------------------------------------------
            '   入力制御
            '--------------------------------------------------
            If pSyoriKbn = Enu_SyoriKubun.Insert Then
                If Not f_HdEnableCtl(False) Then
                    Exit Try
                End If
                If Not f_DtlEnableCtl(True) Then
                    Exit Try
                End If
                cob_NOJO_CD.Focus()
            Else
                If Not f_HdEnableCtl(True) Then
                    Exit Try
                End If
                If Not f_DtlEnableCtl(False) Then
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
#Region "f_Hasu_SQLMake 合計羽数表示ＳＱＬ作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :グリッド表示ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Hasu_SQLMake(ByRef wSql As String) As Boolean
        Dim ret As Boolean = False

        Try

            wSql &= "SELECT"
            '2017/07/10　修正開始
            'wSql &= "  SUM( CASE WHEN TORI_KBN = 1 THEN KEIYAKU_HASU ELSE 0 END ) HASU1,"
            'wSql &= "  SUM( CASE WHEN TORI_KBN = 2 THEN KEIYAKU_HASU ELSE 0 END ) HASU2,"
            'wSql &= "  SUM( CASE WHEN TORI_KBN = 3 THEN KEIYAKU_HASU ELSE 0 END ) HASU3,"
            'wSql &= "  SUM( CASE WHEN TORI_KBN = 4 THEN KEIYAKU_HASU ELSE 0 END ) HASU4,"
            'wSql &= "  SUM( CASE WHEN TORI_KBN = 5 THEN KEIYAKU_HASU ELSE 0 END ) HASU5,"
            'wSql &= "  SUM( CASE WHEN TORI_KBN = 6 THEN KEIYAKU_HASU ELSE 0 END ) HASU6,"
            'wSql &= "  SUM( CASE WHEN TORI_KBN BETWEEN 1 AND 6 THEN KEIYAKU_HASU ELSE 0 END ) HASU0 "
            For i = 1 To 11
                wSql &= "  SUM( CASE WHEN TORI_KBN = " & i & " THEN KEIYAKU_HASU ELSE 0 END ) HASU" & Format(i, "00") & ","
            Next
            wSql &= "  SUM( CASE WHEN TORI_KBN BETWEEN 1 AND 11 THEN KEIYAKU_HASU ELSE 0 END ) HASU00 "
            '2017/07/10　修正終了
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO "
            wSql &= "WHERE KI = " & p1010_KI
            wSql &= "  AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND DATA_FLG = 1"

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

            wSql &= "SELECT"
            wSql &= "  NOJ.MEISAI_NO,"
            wSql &= "  KJO.SEQNO,"
            wSql &= "  KJO.KEIYAKU_DATE_FROM,"
            wSql &= "  KJO.KEIYAKU_DATE_TO,"
            wSql &= "  KJO.NOJO_CD,"
            wSql &= "  NOJ.NOJO_NAME NOJO_NM,"
            wSql &= "  NOJ.ADDR_1||ADDR_2||ADDR_3||ADDR_4 ADDR, "
            wSql &= "  KJO.TORI_KBN,"
            wSql &= "  M07.RYAKUSYO TORI_KBN_NM,"
            wSql &= "  KJO.KEIYAKU_HASU,"
            wSql &= "  KJO.BIKO,"
            wSql &= "  NOJ.ADDR_POST,"
            wSql &= "  NOJ.ADDR_1,"
            wSql &= "  NOJ.ADDR_2,"
            wSql &= "  NOJ.ADDR_3,"
            wSql &= "  NOJ.ADDR_4 "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO KJO,"
            wSql &= "  TM_KEIYAKU_NOJO NOJ,"
            wSql &= "  TM_CODE M07 "
            wSql &= "WHERE KJO.KI = " & p1010_KI
            wSql &= "  AND KJO.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND KJO.DATA_FLG = 1"
            wSql &= "  AND KJO.KI = NOJ.KI(+)"
            wSql &= "  AND KJO.KEIYAKUSYA_CD = NOJ.KEIYAKUSYA_CD(+)"
            wSql &= "  AND KJO.NOJO_CD = NOJ.NOJO_CD(+)"
            wSql &= "  AND 7 = M07.SYURUI_KBN(+)"
            wSql &= "  AND KJO.TORI_KBN = M07.MEISYO_CD(+) "
            wSql &= "ORDER BY"
            wSql &= "  NOJ.MEISAI_NO, KJO.NOJO_CD, KJO.TORI_KBN "

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
            lbl_MEISAI_NO.Text = ""
            cob_NOJO_CD.SelectedIndex = -1
            cob_NOJO_nm.SelectedIndex = -1
            lbl_ADDR_POST.Text = ""
            lbl_ADDR_1.Text = ""
            lbl_ADDR_2.Text = ""
            lbl_ADDR_3.Text = ""
            lbl_ADDR_4.Text = ""
            cob_TORI_KBN.SelectedIndex = -1
            cob_TORI_KBN_NM.SelectedIndex = -1
            num_KEIYAKU_HASU.Value = Nothing
            date_KEIYAKU_DATE_FROM.Value = Nothing
            date_KEIYAKU_DATE_TO.Value = Nothing
            txt_Biko.Text = ""

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
    '引数            :Enable
    '                :契約年月日のクリア有無(TRUE:クリアあり　FALSE:CLEARなし) 2015/10/07　追加
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_DtlEnableCtl(ByVal wEnable As Boolean, Optional ByVal wClear As Boolean = True) As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty

        Try

            'キー
            If pSyoriKbn = Enu_SyoriKubun.Insert Then
                '新規
                cob_NOJO_CD.Enabled = wEnable
                cob_NOJO_nm.Enabled = wEnable
                cmd_NOJO_INS.Enabled = wEnable
                cob_TORI_KBN.Enabled = wEnable
                cob_TORI_KBN_NM.Enabled = wEnable
                cmdCopy.Enabled = wEnable
            Else
                '修正・削除
                cob_NOJO_CD.Enabled = False
                cob_NOJO_nm.Enabled = False
                'cmd_NOJO_INS.Enabled = False   '2015/12/01　修正
                cmd_NOJO_INS.Enabled = wEnable  '2015/12/01　修正
                cob_TORI_KBN.Enabled = False
                cob_TORI_KBN_NM.Enabled = False
                cmdCopy.Enabled = False
            End If

            '明細
            num_KEIYAKU_HASU.Enabled = wEnable
            date_KEIYAKU_DATE_FROM.Enabled = wEnable
            txt_Biko.Enabled = wEnable

            If wEnable = True Then
                date_KEIYAKU_DATE_TO.Value = f_DateTrim(pJIGYO_SYURYO_DATE)
            Else
                '▽▽▽--2015/10/07　修正開始--▽▽▽
                'date_KEIYAKU_DATE_TO.Value = Nothing
                If wClear Then
                    date_KEIYAKU_DATE_TO.Value = Nothing
                    date_KEIYAKU_DATE_FROM.Value = Nothing
                End If
                '△△△--2015/10/07　修正終了--△△△
            End If

            'フッタ
            cmdSave.Enabled = wEnable
            cmdCansel.Enabled = wEnable

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_KEIYAKU_DATE_FROM 契約年月日セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_DtlEnableCtl
    '説明            :契約年月日セット
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '作成日          :2015/10/16
    '------------------------------------------------------------------
    Private Function f_KEIYAKU_DATE_FROM() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            'うずら以外のデータ件数
            wSql &= "SELECT"
            wSql &= "  COUNT(*) CNT, MIN(TAISYO_DATE_FROM)TAISYO_DATE_FROM "
            wSql &= "FROM TM_TANKA "
            wSql &= "WHERE KEIYAKU_KBN = " & pKEIYAKU_KBN
            wSql &= "  AND TORI_KBN =" & cob_TORI_KBN.Text

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                'データなし
                date_KEIYAKU_DATE_FROM.Value = Nothing
            Else
                If CInt(WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("CNT"))) = 1 Then
                    'データなし、データ複数
                    date_KEIYAKU_DATE_FROM.Value = CDate(wkDS.Tables(0).Rows(0)("TAISYO_DATE_FROM"))
                Else
                    'データなし、データ複数
                    date_KEIYAKU_DATE_FROM.Value = Nothing
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

#Region "f_NojoAddr_Dsp 委託先住所表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_NojoAddr_Dsp
    '説明            :委託先住所表示処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_NojoAddr_Dsp() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            'SQL
            wSql = "SELECT * FROM TM_KEIYAKU_NOJO " & _
                   "WHERE KI = " & p1010_KI & _
                   "  AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD & _
                   "  AND NOJO_CD = " & cob_NOJO_CD.Text.Trim

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                f_NojoAddr_Clr
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                f_NojoAddr_Clr
            Else
                lbl_MEISAI_NO.Text = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("MEISAI_NO"))
                Dim wStr As String = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("ADDR_POST"))
                If wStr = "" Then
                    lbl_ADDR_POST.Text = ""
                Else
                    lbl_ADDR_POST.Text = f_MidB(wStr, 1, 3) & "-" & f_MidB(wStr, 4, 4)
                End If
                lbl_ADDR_1.Text = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("ADDR_1"))
                lbl_ADDR_2.Text = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("ADDR_2"))
                lbl_ADDR_3.Text = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("ADDR_3"))
                lbl_ADDR_4.Text = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("ADDR_4"))
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region
#Region "f_NojoAddr_Clr 委託先住所クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_NojoAddr_Clr
    '説明            :委託先住所クリア処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_NojoAddr_Clr() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            lbl_MEISAI_NO.Text = ""
            lbl_ADDR_POST.Text = ""
            lbl_ADDR_1.Text = ""
            lbl_ADDR_2.Text = ""
            lbl_ADDR_3.Text = ""
            lbl_ADDR_4.Text = ""

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
    '引数            :0:保存　1:コピー
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check(ByVal wKbn As Integer) As Boolean
        Dim ret As Boolean = False
        Dim wkControl As Control
        Dim wkControlName As String

        Try

            '==必須チェック==================

            'セーブのときのみ
            If wKbn <> 1 Then

                wkControlName = "農場"
                wkControl = cob_NOJO_CD
                If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                    Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
                End If

                wkControlName = "鶏の種類"
                wkControl = cob_TORI_KBN
                If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                    Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
                End If

                wkControlName = "契約羽数"
                wkControl = num_KEIYAKU_HASU
                If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                    Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
                End If


            End If

            wkControlName = "契約年月日（自）"
            wkControl = date_KEIYAKU_DATE_FROM
            If date_KEIYAKU_DATE_FROM.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            '==FromToチェック==================
            '契約年月(自) > 契約年月(至)　はエラー
            If Not f_Daisyo_Check(date_KEIYAKU_DATE_FROM, date_KEIYAKU_DATE_TO, "契約年月", True, 0) Then
                Exit Try
            End If

            '==いろいろチェック==================

            '契約年度開始(事業開始日)＞契約年月(自)　チェック
            If pJIGYO_KAISU_DATE > f_DateTrim(date_KEIYAKU_DATE_FROM.Value) Then
                Call Show_MessageBox_Add("W503", "事業開始日", "契約年月日（自）")    '@0>@1は入力できません。
                date_KEIYAKU_DATE_FROM.Focus()
                Exit Try
            End If

            If wKbn = 1 Then
                'コピーのときのチェック
                If pKEIYAKU_KBN = 3 Then
                    ''契約区分=3(うずら)のとき、コピーデータをチェック    '2017/07/10　修正
                    '契約区分=3(鶏以外)のとき、コピーデータをチェック     '2017/07/10　修正
                    If Not f_CopyData_Chk() Then
                        cob_NOJO_CD.Focus()
                        Exit Try
                    End If
                End If
            ElseIf pSyoriKbn = Enu_SyoriKubun.Insert Then
                '新規のときのチェック
                '重複チェック
                If dgv_Search.Rows.Count > 0 Then
                    For i = 0 To dgv_Search.Rows.Count - 1
                        '契約者・農場・鶏の種類で一意チェック
                        If dgv_Search.Item("NOJO_CD", i).Value = cob_NOJO_CD.Text.Trim AndAlso
                            dgv_Search.Item("TORI_KBN", i).Value = cob_TORI_KBN.Text.Trim Then
                            Call Show_MessageBox_Add("I007", "すでに登録されている農場・鶏の種類です。")    '@0
                            cob_NOJO_CD.Focus()
                            Exit Try
                        End If
                    Next
                End If
                '鶏の種類チェック
                '2017/07/10　修正開始
                'If pKEIYAKU_KBN = 3 AndAlso cob_TORI_KBN.Text.Trim <> "6" Then
                '    Call Show_MessageBox_Add("I007", "鶏の種類はうずらのみ有効な契約者です。")    '@0
                '    cob_TORI_KBN.Focus()
                '    Exit Try
                'End If
                If pKEIYAKU_KBN = 3 AndAlso CInt(cob_TORI_KBN.Text.Trim) < "6" Then
                    Call Show_MessageBox_Add("I007", "鶏の種類はうずら～だちょうのみ" & vbCrLf & "有効な契約者です。")    '@0
                    cob_TORI_KBN.Focus()
                    Exit Try
                End If
                '2017/07/10　修正終了
            End If


            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region
#Region "f_CopyData_Chk 前期データチェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_CopyData_Chk
    '説明            :前期データチェック処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_CopyData_Chk() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            'うずら以外のデータ件数
            wSql &= "SELECT"
            wSql &= "  COUNT(SEQNO) CNT "
            wSql &= "FROM TT_KEIYAKU_JOHO "
            wSql &= "WHERE KI = " & (p1010_KI - 1)
            wSql &= " AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= " AND DATA_FLG = 1"
            'wSql &= " AND TORI_KBN <> 6"   '2017/07/10　修正
            wSql &= " AND TORI_KBN < 6"     '2017/07/10　修正

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count > 0 Then
                If CInt(WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("CNT"))) > 0 Then
                    'Show_MessageBox_Add("I007", "うずら以外の情報が前期にあるため" & vbCrLf & "処理できません。")
                    Call Show_MessageBox_Add("I007", "今期契約区分が鶏以外ですが、前期の契約に" & vbCrLf &
                                                     "採卵鶏・肉用鶏・種鶏が含まれる為、" & vbCrLf &
                                                     "コピーできません")    '@0
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
