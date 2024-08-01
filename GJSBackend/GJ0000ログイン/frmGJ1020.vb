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


Public Class frmGJ1020

#Region "***変数定義***"

    ''' <summary>
    ''' 結果一覧セット用データセット
    ''' </summary>
    ''' <remarks></remarks>
    Private pDataSet As New DataSet

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
    ''' 変更時、該当データ選択行
    ''' </summary>
    ''' <remarks></remarks>
    Public pSel_POS As Integer

    ''' <summary>
    '''  プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True
    Private pJIGYO_KAISU_DATE As Date       '事業開始日
    Private pJIGYO_SYURYO_DATE As Date      '事業終了日
    Private pKEIYAKU_KBN As Integer = 0     '契約区分

    Private pInitKi As String               '期(初期値)
    Private pEnterKi As String              '期(入力値)

    Private pSaveSyoriKbn As String         '更新前処理区分　(修正・削除処理用)
    Private pSaveKeiyakuDateFrom As Date    '更新前契約開始日(修正・削除処理用)

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

        Try

            '初期値取得
            pJIGYO_KAISU_DATE = clsNENDO_KI.pJIGYO_NENDO_byDate         '事業開始日
            pJIGYO_SYURYO_DATE = clsNENDO_KI.pJIGYO_SYURYO_NENDO_byDate '事業最終日
            pInitKi = clsNENDO_KI.pKI   '当期

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            '画面初期化
            ret = f_ObjectClear("C")

            'コンボボックスセット(鳥の種類)
            If Not f_ComboBox_Set_ToriKbn() Then
                Exit Try
            End If

            '変更判定イベント登録
            f_setControlChangeEvents()

            '入力制御
            ret = f_SearchEnableCtl(True)
            ret = f_HdEnableCtl(False)
            ret = f_DtlEnableCtl(False)

            '★初期コントロールにフォーカスセット
            txt_KI.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        Finally
            clsNENDO_KI = Nothing
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
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs, Optional ByVal wkAlertFlag As Boolean = True) Handles cmdSearch.Click
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '画面入力チェック
            If wkAlertFlag Then
                If Not f_Input_Check_Search() Then
                    Exit Try
                End If
            End If

            '契約情報セーブ
            If Not f_Keiyaku_Data() Then
                Throw New Exception("該当契約者が存在しませんでした")
            End If

            'SQL作成
            If Not f_Grid_Set("C", Now, 0, 0, 0) Then
                Exit Try
            End If

            'コンボボックスセット(農場)
            If Not f_ComboBox_Set_Nojo("") Then
                Exit Try
            End If

            '入力制御
            ret = f_SearchEnableCtl(False)
            ret = f_HdEnableCtl(True)
            ret = f_DtlEnableCtl(False)

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdSearchClr 検索クリアボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSearchClr
    '説明            :検索クリアボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSearchClr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSearchClr.Click
        Dim ret As Boolean

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '画面クリア
            ret = f_ObjectClear("")

            '入力制御
            ret = f_SearchEnableCtl(True)
            ret = f_HdEnableCtl(False)
            ret = f_DtlEnableCtl(False)

            'データ区分にフォーカスセット
            txt_KI.Focus()

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
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '新規登録ボタン押下時のチェック
            If Not f_Input_Check_CmdIns() Then
                Exit Try
            End If

            '処理区分：登録
            pSyoriKbn = Enu_SyoriKubun.Insert

            '入力制御
            ret = f_HdEnableCtl(False)
            ret = f_DtlEnableCtl(True)

            '変更フラグ　クリア
            loblnTextChange = False

            '羽数初期値
            'num_IDO_HASU.Value = 0

            '★初期コントロールにフォーカスセット
            cob_TORI_KBN.Focus()

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
        Dim ret As Boolean = False
        Dim bol As Boolean = False
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
                    pSel_POS = i
                    Exit For
                End If
            Next

            '-------------------------------------------------
            '鶏の種類    TORI_KBN
            '-------------------------------------------------
            cob_TORI_KBN.Text = WordHenkan("N", "S", dgv_Search.Item("TORI_KBN", pSel_POS).Value)
            cob_TORI_KBN_NM.SelectedIndex = cob_TORI_KBN.SelectedIndex

            '-------------------------------------------------
            '移動羽数
            '-------------------------------------------------
            num_IDO_HASU.Value = CLng(WordHenkan("N", "Z", dgv_Search.Item("IDO_HASU", pSel_POS).Value))

            '-------------------------------------------------
            '農場コード（移動元）
            '-------------------------------------------------
            '農場コード（移動元）
            cob_NOJO_CD_MOTO.Text = WordHenkan("N", "S", dgv_Search.Item("NOJO_CD_MOTO", pSel_POS).Value)
            cob_NOJO_NM_MOTO.SelectedIndex = cob_NOJO_CD_MOTO.SelectedIndex

            '農場住所(エラー表示なし)
            ret = f_NojoAddR_Dsp(cob_NOJO_CD_MOTO, lbl_ADDR_POST_MOTO,
                                 lbl_ADDR_1_MOTO, lbl_ADDR_2_MOTO, lbl_ADDR_3_MOTO, lbl_ADDR_4_MOTO,
                                 lbl_KEIYAKU_HASU_MOTO_MAE, lbl_KEIYAKU_HASU_MOTO_ATO, False)

            '契約羽数（移動元・移動前）
            wStr = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_HASU_MOTO_MAE", pSel_POS).Value)
            If wStr = "" Then
                lbl_KEIYAKU_HASU_MOTO_MAE.Text = ""
            Else
                lbl_KEIYAKU_HASU_MOTO_MAE.Text = CLng(wStr).ToString("##,###,##0")
            End If

            '契約羽数（移動元・移動後）
            wStr = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_HASU_MOTO_ATO", pSel_POS).Value)
            If wStr = "" Then
                lbl_KEIYAKU_HASU_MOTO_ATO.Text = ""
            Else
                lbl_KEIYAKU_HASU_MOTO_ATO.Text = CLng(wStr).ToString("##,###,##0")
            End If

            '-------------------------------------------------
            '農場コード（移動先）
            '-------------------------------------------------
            '農場コード（移動先）
            cob_NOJO_CD_SAKI.Text = WordHenkan("N", "S", dgv_Search.Item("NOJO_CD_SAKI", pSel_POS).Value)
            cob_NOJO_NM_SAKI.SelectedIndex = cob_NOJO_CD_SAKI.SelectedIndex

            '農場住所(エラー表示なし)
            ret = f_NojoAddR_Dsp(cob_NOJO_CD_SAKI, lbl_ADDR_POST_SAKI,
                                 lbl_ADDR_1_SAKI, lbl_ADDR_2_SAKI, lbl_ADDR_3_SAKI, lbl_ADDR_4_SAKI,
                                 lbl_KEIYAKU_HASU_SAKI_MAE, lbl_KEIYAKU_HASU_SAKI_ATO, False)

            '契約羽数（移動先・移動前）
            wStr = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_HASU_SAKI_MAE", pSel_POS).Value)
            If wStr = "" Then
                lbl_KEIYAKU_HASU_SAKI_MAE.Text = ""
            Else
                lbl_KEIYAKU_HASU_SAKI_MAE.Text = CLng(wStr).ToString("##,###,##0")
            End If

            '契約羽数（移動先・移動後）
            wStr = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_HASU_SAKI_ATO", pSel_POS).Value)
            If wStr = "" Then
                lbl_KEIYAKU_HASU_SAKI_ATO.Text = ""
            Else
                lbl_KEIYAKU_HASU_SAKI_ATO.Text = CLng(wStr).ToString("##,###,##0")
            End If

            '-------------------------------------------------
            '元SEQ
            '-------------------------------------------------
            '元SEQNO（移動前）　　移動前のＡ農場のSEQNO    MOTO_SEQNO_MAE
            lbl_MOTO_SEQNO_MAE.Text = WordHenkan("N", "S", dgv_Search.Item("MOTO_SEQNO_MAE", pSel_POS).Value)

            '元SEQNO（移動後）　　移動後のＡ農場のSEQNO    MOTO_SEQNO_ATO
            lbl_MOTO_SEQNO_ATO.Text = WordHenkan("N", "S", dgv_Search.Item("MOTO_SEQNO_ATO", pSel_POS).Value)

            '先SEQNO（移動前）　　移動前のＢ農場のSEQNO    SAKI_SEQNO_MAE
            lbl_SAKI_SEQNO_MAE.Text = WordHenkan("N", "S", dgv_Search.Item("SAKI_SEQNO_MAE", pSel_POS).Value)

            '先SEQNO（移動後）　　移動後のＢ農場のSEQNO    SAKI_SEQNO_ATO
            lbl_SAKI_SEQNO_ATO.Text = WordHenkan("N", "S", dgv_Search.Item("SAKI_SEQNO_ATO", pSel_POS).Value)

            '--------------------------------------------------
            '入力項目
            '--------------------------------------------------

            '契約年月日From
            wStr = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_DATE_FROM", pSel_POS).Value)
            If wStr = "" Then
                date_KEIYAKU_DATE_FROM.Value = Nothing
                pSaveKeiyakuDateFrom = Nothing
            Else
                date_KEIYAKU_DATE_FROM.Value = CDate(wStr)
                pSaveKeiyakuDateFrom = CDate(wStr)
            End If

            '処理状況　1:入力中 2:入力確定    SYORI_KBN
            wStr = WordHenkan("N", "S", dgv_Search.Item("SYORI_KBN", pSel_POS).Value)
            If wStr = "1" Then
                rbtn_SYORI_KBN1.Checked = True
                pSaveSyoriKbn = "1"
            Else
                rbtn_SYORI_KBN2.Checked = True
                pSaveSyoriKbn = "2"
            End If

            '入力制御
            ret = f_HdEnableCtl(False)
            ret = f_DtlEnableCtl(True)

            '変更フラグ　クリア
            loblnTextChange = False

            '★初期コントロールにフォーカスセット
            cob_TORI_KBN.Focus()

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
        Dim wDel_KEIYAKU_DATE As Date = Nothing
        Dim wDel_SAKI_NOJO_CD As Integer = 0
        Dim wDel_MOTO_NOJO_CD As Integer = 0
        Dim wDel_TORI_KBN As Integer = 0

        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")
                Exit Try
            End If

            '該当データ取得
            For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
                pSel_POS = gRow.Index
            Next

            '削除ボタン押下時のチェック
            If Not f_Input_Check_CmdDel(pSel_POS) Then
                Exit Try
            End If

            '削除処理確認
            If Show_MessageBox_Add("Q006", "指定されたデータ") = DialogResult.No Then    '指定されたデータを削除します。よろしいですか？
                Exit Try
            End If

            'キー項目
            wDel_KEIYAKU_DATE = CDate(WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_DATE_FROM", pSel_POS).Value))
            wDel_MOTO_NOJO_CD = WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD_MOTO", pSel_POS).Value)
            wDel_SAKI_NOJO_CD = WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD_SAKI", pSel_POS).Value)
            wDel_TORI_KBN = WordHenkan("N", "Z", dgv_Search.Item("TORI_KBN", pSel_POS).Value)

            '該当データ削除処理
            If Not f_Data_Deleate(pSel_POS) Then
                Exit Try
            End If

            'グリッド　再表示
            f_Grid_Set("", wDel_KEIYAKU_DATE, wDel_MOTO_NOJO_CD, wDel_SAKI_NOJO_CD, wDel_TORI_KBN)

            '入力制御
            ret = f_HdEnableCtl(True)
            ret = f_DtlEnableCtl(False)

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
        Dim ret As Boolean = False
        Dim wNojocdMoto As String = String.Empty
        Dim wNojocdSaki As String = String.Empty

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            'コンボの内容セーブ
            'R05年度　OSバージョンアップ　既存バグ修正のため更新 JBD453 2024/03/12 UPD START↓
            'wNojocdMoto = cob_NOJO_CD_MOTO.Text.Trim
            'wNojocdSaki = cob_NOJO_CD_SAKI.Text.Trim
            wNojocdMoto = cob_NOJO_CD_MOTO.SelectedIndex
            wNojocdSaki = cob_NOJO_CD_SAKI.SelectedIndex
            'R05年度　OSバージョンアップ　既存バグ修正のため更新 JBD453 2024/03/12 UPD END↑

            '農場登録画面
            Using wkForm As New GJ0000.frmGJ1013
                wkForm.Owner = Me
                wkForm.p1013_KI = txt_KI.Text.Trim
                wkForm.p1013_KEIYAKUSYA_CD = cob_KEIYAKUSYA_CD.Text.Trim
                wkForm.p1013_KEIYAKUSYA_NAME = cob_KEIYAKUSYA_NM.Text.Trim
                wkForm.p1013_NOJO_CD = ""

                wkForm.ShowDialog()

                '農場コード登録時
                If wkForm.p1013_NOJO_CD = "" Then
                    '農場未入力
                    Me.cob_NOJO_CD_SAKI.Focus()
                Else
                    'コンボ　再セット
                    ret = f_ComboBox_Set_Nojo("I")
                    '農場コード表示
                    Me.cob_NOJO_CD_MOTO.SelectedIndex = -1
                    'R05年度　OSバージョンアップ　既存バグ修正のため更新 JBD453 2024/03/12 UPD START↓
                    'Me.cob_NOJO_CD_MOTO.Text = wNojocdMoto
                    Me.cob_NOJO_CD_MOTO.SelectedIndex = wNojocdMoto
                    'Me.cob_NOJO_CD_MOTO.SelectedIndex = cob_NOJO_CD_MOTO.SelectedIndex
                    Me.cob_NOJO_NM_MOTO.SelectedIndex = cob_NOJO_CD_MOTO.SelectedIndex
                    'R05年度　OSバージョンアップ　既存バグ修正のため更新 JBD453 2024/03/12 UPD END↑
                    '農場コード表示
                    Me.cob_NOJO_CD_SAKI.SelectedIndex = -1
                    Me.cob_NOJO_CD_SAKI.Text = wkForm.p1013_NOJO_CD
                    Me.cob_NOJO_NM_SAKI.SelectedIndex = cob_NOJO_CD_SAKI.SelectedIndex
                    '農場住所表示
                    If Me.f_NojoAddR_Dsp(cob_NOJO_CD_SAKI, lbl_ADDR_POST_SAKI,
                                         lbl_ADDR_1_SAKI, lbl_ADDR_2_SAKI, lbl_ADDR_3_MOTO, lbl_ADDR_4_SAKI,
                                         lbl_KEIYAKU_HASU_SAKI_MAE, lbl_KEIYAKU_HASU_SAKI_ATO, True) Then
                        'エラーなしは、次項目
                        Me.date_KEIYAKU_DATE_FROM.Focus()
                    Else
                        'エラーありは、
                        Me.cob_NOJO_CD_SAKI.Focus()
                    End If
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
        Dim wUpd_KEIYAKU_DATE As Date = Nothing
        Dim wUpd_MOTO_NOJO_CD As Integer = 0
        Dim wUpd_SAKI_NOJO_CD As Integer = 0
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
            If Not f_Input_Check_Save() Then
                Exit Try
            End If

            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert       '新規入力

                    '保存処理確認
                    If Show_MessageBox_Add("Q004", "データ") = DialogResult.No Then    '保存します。よろしいですか？
                        Exit Try
                    End If

                    'データ保存処理
                    If Not f_Data_update() Then
                        Exit Try
                    End If

                Case Enu_SyoriKubun.Update       '変更

                    '保存処理確認
                    If Show_MessageBox_Add("Q005", "データ") = DialogResult.No Then    '保存します。よろしいですか？
                        Exit Try
                    End If

                    'データ保存処理
                    If Not f_Data_update() Then
                        Exit Try
                    End If

            End Select

            'キー項目
            wUpd_KEIYAKU_DATE = f_DateTrim(date_KEIYAKU_DATE_FROM.Value)
            wUpd_MOTO_NOJO_CD = cob_NOJO_CD_MOTO.Text.Trim
            wUpd_SAKI_NOJO_CD = cob_NOJO_CD_SAKI.Text.Trim
            wUpd_TORI_KBN = cob_TORI_KBN.Text.Trim

            'グリッド　再表示
            f_Grid_Set("", wUpd_KEIYAKU_DATE, wUpd_MOTO_NOJO_CD, wUpd_SAKI_NOJO_CD, wUpd_TORI_KBN)

            '入出力制御
            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert       '新規入力
                    f_HdEnableCtl(False)
                    f_DtlEnableCtl(True)
                    cob_TORI_KBN.Focus()
                Case Enu_SyoriKubun.Update       '変更
                    f_HdEnableCtl(True)
                    f_DtlEnableCtl(False)
                    dgv_Search.Focus()
            End Select

            '画面入力内容変更フラグクリア
            loblnTextChange = False

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
                '2015/03/04　修正開始--▽▽▽    DataSourceへ変更に伴い、初期化方法変更
                'cob_KEIYAKUSYA_CD.Items.Clear()
                'cob_KEIYAKUSYA_NM.Items.Clear()
                cob_KEIYAKUSYA_CD.DataSource = Nothing
                cob_KEIYAKUSYA_CD.Clear()
                cob_KEIYAKUSYA_NM.DataSource = Nothing
                cob_KEIYAKUSYA_NM.Clear()
                '2015/03/04　修正終了--△△△
                Exit Try
            End If

            '期が変更になった場合、契約者コンボ再セット
            If pEnterKi = "" OrElse _
               CInt(txt_KI.Text) <> CInt(pEnterKi) Then
                ret = f_ComboBox_Set_Keiyaku(txt_KI.Text.Trim.ToString)
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


        '2015/03/04　修正開始--▽▽▽   値の設定方法を変更
        'cob_KEIYAKUSYA_CD.SelectedValue = cob_KEIYAKUSYA_CD.Text
        cob_KEIYAKUSYA_CD.SelectedValue = CDec(cob_KEIYAKUSYA_CD.Text)
        '2015/03/04　修正終了--△△△
        If cob_KEIYAKUSYA_CD.SelectedValue Is Nothing Then
            cob_KEIYAKUSYA_CD.SelectedIndex = -1
            cob_KEIYAKUSYA_NM.SelectedIndex = -1
            Show_MessageBox_Add("W012", "契約者") '指定された@0が正しくありません。
            cob_KEIYAKUSYA_CD.Focus()
        End If

    End Sub

#End Region

#Region "鶏の種類関連(新規登録のみ)"

    ''' <summary>
    ''' 鶏の種類コード項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_TORI_KBN_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_TORI_KBN.SelectedIndexChanged

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
    Private Sub cob_TORI_KBN_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_TORI_KBN_NM.SelectedIndexChanged

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
    Private Sub cob_TORI_KBN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_TORI_KBN.Validating

        Try

            '未入力
            If cob_TORI_KBN.Text = "" Then
                '羽数クリア
                lbl_KEIYAKU_HASU_MOTO_MAE.Text = ""
                lbl_KEIYAKU_HASU_MOTO_ATO.Text = ""
                lbl_KEIYAKU_HASU_SAKI_MAE.Text = ""
                lbl_KEIYAKU_HASU_SAKI_ATO.Text = ""
                Exit Try
            End If

            '先頭ゼロを削除
            DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString

            cob_TORI_KBN.SelectedValue = cob_TORI_KBN.Text
            If cob_TORI_KBN.SelectedValue Is Nothing Then
                cob_TORI_KBN.SelectedIndex = -1
                cob_TORI_KBN_NM.SelectedIndex = -1
                '羽数クリア
                lbl_KEIYAKU_HASU_MOTO_MAE.Text = ""
                lbl_KEIYAKU_HASU_MOTO_ATO.Text = ""
                lbl_KEIYAKU_HASU_SAKI_MAE.Text = ""
                lbl_KEIYAKU_HASU_SAKI_ATO.Text = ""
                'エラーメッセージ
                Show_MessageBox_Add("W012", "鶏の種類") '指定された@0が正しくありません。
                cob_TORI_KBN.Focus()
                Exit Try
            End If

            '羽数表示
            If Not f_NojoHasu_BothDsp() Then
                cob_TORI_KBN.Focus()
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 鶏の種類コード確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_TORI_KBN_NM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_TORI_KBN_NM.Validating

        Try

            If cob_TORI_KBN_NM.Text = "" Then
                '羽数クリア
                lbl_KEIYAKU_HASU_MOTO_ATO.Text = ""
                lbl_KEIYAKU_HASU_SAKI_ATO.Text = ""
                Exit Try
            End If

            '羽数表示
            If Not f_NojoHasu_BothDsp() Then
                cob_TORI_KBN_NM.Focus()
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#Region "移動羽数"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_KI_Validated
    '説明            :期Validatedベント
    '------------------------------------------------------------------
    Private Sub num_IDO_HASU_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles num_IDO_HASU.Validating
        Dim wIdoHasu As Integer = 0
        Dim wHasuMotoMae As Integer = 0
        Dim wHasuMotoAto As Integer = 0
        Dim wHasuSakiMae As Integer = 0
        Dim wHasuSakiAto As Integer = 0

        Try

            '羽数入力なし
            If num_IDO_HASU.Value Is Nothing Then
                '羽数
                lbl_KEIYAKU_HASU_MOTO_ATO.Text = ""
                lbl_KEIYAKU_HASU_SAKI_ATO.Text = ""
                Exit Try
            End If

            ''移動元
            'If lbl_KEIYAKU_HASU_MOTO_MAE.Text.Trim = "" Then
            '    lbl_KEIYAKU_HASU_MOTO_ATO.Text = ""
            'Else
            '    wHasuMotoMae = CInt(lbl_KEIYAKU_HASU_MOTO_MAE.Text)
            '    '移動前契約羽数
            '    wHasuMotoAto = wHasuMotoMae - num_IDO_HASU.Value
            '    lbl_KEIYAKU_HASU_MOTO_ATO.Text = wHasuMotoAto.ToString("##,###,##0")
            'End If

            ''移動先
            'If lbl_KEIYAKU_HASU_SAKI_MAE.Text.Trim = "" Then
            '    If cob_TORI_KBN.SelectedIndex = -1 OrElse cob_TORI_KBN.Text = "" OrElse
            '        cob_NOJO_CD_SAKI.SelectedIndex = -1 OrElse cob_NOJO_CD_SAKI.Text = "" OrElse
            '        num_IDO_HASU.Value Is Nothing OrElse num_IDO_HASU.Text = "" Then
            '        lbl_KEIYAKU_HASU_SAKI_ATO.Text = ""
            '    Else
            '        lbl_KEIYAKU_HASU_SAKI_ATO.Text = CInt(num_IDO_HASU.Value).ToString("##,###,##0")
            '    End If
            'Else
            '    wHasuSakiMae = CInt(lbl_KEIYAKU_HASU_SAKI_MAE.Text)
            '    '移動前契約羽数
            '    wHasuSakiAto = wHasuSakiMae + num_IDO_HASU.Value
            '    lbl_KEIYAKU_HASU_SAKI_ATO.Text = wHasuSakiAto.ToString("##,###,##0")
            'End If

            '羽数表示
            If Not f_NojoHasu_BothDsp() Then
                num_IDO_HASU.Focus()
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#Region "農場(移動元)関連"

    ''' <summary>
    ''' 農場コード(移動元)項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_NOJO_CD_MOTO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_NOJO_CD_MOTO.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_NOJO_NM_MOTO.SelectedIndex = cob_NOJO_CD_MOTO.SelectedIndex

    End Sub

    ''' <summary>
    ''' 農場名(移動元)項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_NOJO_NM_MOTO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_NOJO_NM_MOTO.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_NOJO_CD_MOTO.SelectedIndex = cob_NOJO_NM_MOTO.SelectedIndex

    End Sub

    ''' <summary>
    ''' 農場コード(移動元)確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_NOJO_CD_MOTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_NOJO_CD_MOTO.Validating
        Dim ret As Boolean = False

        Try

            If cob_NOJO_CD_MOTO.Text = "" Then
                '住所クリア
                f_NojoAddr_Clr(lbl_ADDR_POST_MOTO,
                               lbl_ADDR_1_MOTO, lbl_ADDR_2_MOTO, lbl_ADDR_3_MOTO, lbl_ADDR_4_MOTO,
                               lbl_KEIYAKU_HASU_MOTO_MAE, lbl_KEIYAKU_HASU_MOTO_ATO)
                Exit Sub
            End If


            '先頭ゼロを削除
            DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString

            cob_NOJO_CD_MOTO.SelectedValue = cob_NOJO_CD_MOTO.Text
            If cob_NOJO_CD_MOTO.SelectedValue Is Nothing Then
                cob_NOJO_CD_MOTO.SelectedIndex = -1
                cob_NOJO_NM_MOTO.SelectedIndex = -1
                '住所クリア
                f_NojoAddr_Clr(lbl_ADDR_POST_MOTO,
                               lbl_ADDR_1_MOTO, lbl_ADDR_2_MOTO, lbl_ADDR_3_MOTO, lbl_ADDR_4_MOTO,
                               lbl_KEIYAKU_HASU_MOTO_MAE, lbl_KEIYAKU_HASU_MOTO_ATO)
                Show_MessageBox_Add("W012", "農場") '指定された@0が正しくありません。
                cob_NOJO_CD_MOTO.Focus()
                Exit Try
            End If

            '農場住所表示
            If Not f_NojoAddR_Dsp(cob_NOJO_CD_MOTO, lbl_ADDR_POST_MOTO,
                                  lbl_ADDR_1_MOTO, lbl_ADDR_2_MOTO, lbl_ADDR_3_MOTO, lbl_ADDR_4_MOTO,
                                  lbl_KEIYAKU_HASU_MOTO_MAE, lbl_KEIYAKU_HASU_MOTO_ATO, True) Then
                cob_NOJO_CD_MOTO.Focus()
                Exit Try
            End If

        Catch ex As Exception
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 農場名(移動元)確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_NOJO_NM_MOTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_NOJO_NM_MOTO.Validating
        Dim ret As Boolean = False

        Try

            If cob_NOJO_NM_MOTO.Text = "" Then
                '住所クリア
                f_NojoAddr_Clr(lbl_ADDR_POST_MOTO,
                               lbl_ADDR_1_MOTO, lbl_ADDR_2_MOTO, lbl_ADDR_3_MOTO, lbl_ADDR_4_MOTO,
                               lbl_KEIYAKU_HASU_MOTO_MAE, lbl_KEIYAKU_HASU_MOTO_ATO)
                Exit Sub
            End If

            '農場住所表示
            If Not f_NojoAddR_Dsp(cob_NOJO_CD_MOTO, lbl_ADDR_POST_MOTO,
                                  lbl_ADDR_1_MOTO, lbl_ADDR_2_MOTO, lbl_ADDR_3_MOTO, lbl_ADDR_4_MOTO,
                                  lbl_KEIYAKU_HASU_MOTO_MAE, lbl_KEIYAKU_HASU_MOTO_ATO, True) Then
                cob_NOJO_CD_MOTO.Focus()
                Exit Try
            End If

        Catch ex As Exception
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#Region "農場(移動先)関連"

    ''' <summary>
    ''' 農場コード(移動先)項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_NOJO_CD_SAKI_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_NOJO_CD_SAKI.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_NOJO_NM_SAKI.SelectedIndex = cob_NOJO_CD_SAKI.SelectedIndex

    End Sub

    ''' <summary>
    ''' 農場名(移動先)項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_NOJO_NM_SAKI_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_NOJO_NM_SAKI.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_NOJO_CD_SAKI.SelectedIndex = cob_NOJO_NM_SAKI.SelectedIndex

    End Sub

    ''' <summary>
    ''' 農場コード(移動先)確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_NOJO_CD_SAKI_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_NOJO_CD_SAKI.Validating
        Dim ret As Boolean = False

        Try

            If cob_NOJO_CD_SAKI.Text = "" Then
                '住所クリア
                f_NojoAddr_Clr(lbl_ADDR_POST_SAKI,
                               lbl_ADDR_1_SAKI, lbl_ADDR_2_SAKI, lbl_ADDR_3_SAKI, lbl_ADDR_4_SAKI,
                               lbl_KEIYAKU_HASU_SAKI_MAE, lbl_KEIYAKU_HASU_SAKI_ATO)
                Exit Sub
            End If


            '先頭ゼロを削除
            DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString

            cob_NOJO_CD_SAKI.SelectedValue = cob_NOJO_CD_SAKI.Text
            If cob_NOJO_CD_SAKI.SelectedValue Is Nothing Then
                cob_NOJO_CD_SAKI.SelectedIndex = -1
                cob_NOJO_NM_SAKI.SelectedIndex = -1
                '住所クリア
                f_NojoAddr_Clr(lbl_ADDR_POST_SAKI,
                               lbl_ADDR_1_SAKI, lbl_ADDR_2_SAKI, lbl_ADDR_3_SAKI, lbl_ADDR_4_SAKI,
                               lbl_KEIYAKU_HASU_SAKI_MAE, lbl_KEIYAKU_HASU_SAKI_ATO)
                Show_MessageBox_Add("W012", "農場") '指定された@0が正しくありません。
                cob_NOJO_CD_SAKI.Focus()
                Exit Try
            End If

            '農場住所表示
            If Not f_NojoAddR_Dsp(cob_NOJO_CD_SAKI, lbl_ADDR_POST_SAKI,
                                  lbl_ADDR_1_SAKI, lbl_ADDR_2_SAKI, lbl_ADDR_3_SAKI, lbl_ADDR_4_SAKI,
                                  lbl_KEIYAKU_HASU_SAKI_MAE, lbl_KEIYAKU_HASU_SAKI_ATO, True) Then
                cob_NOJO_CD_SAKI.Focus()
                Exit Try
            End If

        Catch ex As Exception
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 農場名(移動先)確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_NOJO_NM_SAKI_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_NOJO_NM_SAKI.Validating
        Dim ret As Boolean = False

        Try

            If cob_NOJO_NM_SAKI.Text = "" Then
                '住所クリア
                f_NojoAddr_Clr(lbl_ADDR_POST_SAKI,
                               lbl_ADDR_1_SAKI, lbl_ADDR_2_SAKI, lbl_ADDR_3_SAKI, lbl_ADDR_4_SAKI,
                               lbl_KEIYAKU_HASU_SAKI_MAE, lbl_KEIYAKU_HASU_SAKI_ATO)
                Exit Sub
            End If

            '農場住所表示
            If Not f_NojoAddR_Dsp(cob_NOJO_CD_SAKI, lbl_ADDR_POST_SAKI,
                                  lbl_ADDR_1_SAKI, lbl_ADDR_2_SAKI, lbl_ADDR_3_SAKI, lbl_ADDR_4_SAKI,
                                  lbl_KEIYAKU_HASU_SAKI_MAE, lbl_KEIYAKU_HASU_SAKI_ATO, True) Then
                cob_NOJO_NM_SAKI.Focus()
                Exit Try
            End If

        Catch ex As Exception
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#End Region

#Region "*** データ登録関連 ***"

#Region "契約情報　更新"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_update
    '説明            :契約情報　更新
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_update() As Boolean
        Dim ret As Boolean = False
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            If pSyoriKbn = Enu_SyoriKubun.Insert Then
                Cmd.CommandText = "PKG_GJ1020.GJ1020_IDO_INS"
            Else
                If pSaveSyoriKbn = 1 Then
                    If rbtn_SYORI_KBN1.Checked Then
                        '入力中→入力中(履歴の変更のみ)
                        Cmd.CommandText = "PKG_GJ1020.GJ1020_IDO_UPD11"
                    Else
                        '入力中→確定済(履歴の変更＋移動前・契約情報無効＋移動後・新契約情報追加)
                        Cmd.CommandText = "PKG_GJ1020.GJ1020_IDO_UPD12"
                    End If
                Else
                    If rbtn_SYORI_KBN1.Checked Then
                        '確定済→入力中(履歴の変更＋移動前・契約情報有効＋移動後・契約情報削除)
                        Cmd.CommandText = "PKG_GJ1020.GJ1020_IDO_UPD21"
                    Else
                        '確定済→確定済(履歴の変更＋移動前・契約情報更新＋移動後・契約情報更新)
                        Cmd.CommandText = "PKG_GJ1020.GJ1020_IDO_UPD22"
                    End If
                End If
            End If

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", txt_KI.Text.Trim)

            '契約者番号 県コード＋連番３桁    
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", cob_KEIYAKUSYA_CD.Text.Trim)

            '契約年月日From  
            If date_KEIYAKU_DATE_FROM.Value Is Nothing OrElse date_KEIYAKU_DATE_FROM.Value = New Date Then
                Cmd.Parameters.Add("KEIYAKU_DATE_FROM", DBNull.Value)
            Else
                Cmd.Parameters.Add("KEIYAKU_DATE_FROM", f_DateTrim(date_KEIYAKU_DATE_FROM.Value))
            End If

            '契約年月日To 
            Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", pJIGYO_SYURYO_DATE)

            '農場コード（移動元
            Cmd.Parameters.Add("IN_NOJO_CD_MOTO", cob_NOJO_CD_MOTO.Text.Trim)

            '農場コード（移動先）
            Cmd.Parameters.Add("IN_NOJO_CD_SAKI", cob_NOJO_CD_SAKI.Text.Trim)

            '契約区分　1:家族 2:企業 3:うずら 
            Cmd.Parameters.Add("IN_KEIYAKU_KBN", pKEIYAKU_KBN)

            '鶏の種類    TORI_KBN
            Cmd.Parameters.Add("IN_TORI_KBN", cob_TORI_KBN.Text.Trim)

            '移動羽数    IDO_HASU
            Cmd.Parameters.Add("IN_IDO_HASU", num_IDO_HASU.Value)

            '契約羽数（移動元・移動前）
            If lbl_KEIYAKU_HASU_MOTO_MAE.Text = "" Then
                Cmd.Parameters.Add("IN_KEIYAKU_HASU_MOTO_MAE", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_HASU_MOTO_MAE", CLng(lbl_KEIYAKU_HASU_MOTO_MAE.Text))
            End If

            '契約羽数（移動元・移動後）
            If lbl_KEIYAKU_HASU_MOTO_ATO.Text = "" Then
                Cmd.Parameters.Add("IN_KEIYAKU_HASU_MOTO_ATO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_HASU_MOTO_ATO", CLng(lbl_KEIYAKU_HASU_MOTO_ATO.Text))
            End If

            '契約羽数（移動先・移動前）
            If lbl_KEIYAKU_HASU_SAKI_MAE.Text = "" Then
                Cmd.Parameters.Add("IN_KEIYAKU_HASU_SAKI_MAE", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_HASU_SAKI_MAE", CLng(lbl_KEIYAKU_HASU_SAKI_MAE.Text))
            End If

            '契約羽数（移動先・移動後）
            If lbl_KEIYAKU_HASU_SAKI_ATO.Text = "" Then
                Cmd.Parameters.Add("IN_KEIYAKU_HASU_SAKI_ATO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_HASU_SAKI_ATO", CLng(lbl_KEIYAKU_HASU_SAKI_ATO.Text))
            End If

            '元SEQNO（移動前）　
            If lbl_MOTO_SEQNO_MAE.Text = "" Then
                Cmd.Parameters.Add("IN_MOTO_SEQNO_MAE", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_MOTO_SEQNO_MAE", CLng(lbl_MOTO_SEQNO_MAE.Text))
            End If
            '元SEQNO（移動後）　
            If lbl_MOTO_SEQNO_ATO.Text = "" Then
                Cmd.Parameters.Add("IN_MOTO_SEQNO_ATO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_MOTO_SEQNO_ATO", CLng(lbl_MOTO_SEQNO_ATO.Text))
            End If
            '先SEQNO（移動前）　
            If lbl_SAKI_SEQNO_MAE.Text = "" Then
                Cmd.Parameters.Add("IN_SAKI_SEQNO_MAE", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_SAKI_SEQNO_MAE", CLng(lbl_SAKI_SEQNO_MAE.Text))
            End If
            '先SEQNO（移動後）　
            If lbl_SAKI_SEQNO_ATO.Text = "" Then
                Cmd.Parameters.Add("IN_SAKI_SEQNO_ATO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_SAKI_SEQNO_ATO", CLng(lbl_SAKI_SEQNO_ATO.Text))
            End If

            '処理状況　1:入力中 2:入力確定
            If rbtn_SYORI_KBN1.Checked Then
                Cmd.Parameters.Add("IN_SYORI_KBN", 1)
            Else
                Cmd.Parameters.Add("IN_SYORI_KBN", 2)
            End If

            '修正前契約開始日
            If pSyoriKbn = Enu_SyoriKubun.Update Then
                If IsNothing(pSaveKeiyakuDateFrom) Then
                    Cmd.Parameters.Add("IN_OLD_KEIYAKU_DATE_FROM", DBNull.Value)
                Else
                    Cmd.Parameters.Add("IN_OLD_KEIYAKU_DATE_FROM", pSaveKeiyakuDateFrom)
                End If
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

#Region "契約情報　削除処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Deleate
    '説明            :契約情報　削除処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Deleate(ByVal intRow As Integer) As Boolean
        Dim ret As Boolean = False
        Dim wStr As String = String.Empty
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Cmd.CommandText = "PKG_GJ1020.GJ1020_IDO_DEL"

            '引き渡し

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", txt_KI.Text.Trim)

            '契約者番号 県コード＋連番３桁    
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", cob_KEIYAKUSYA_CD.Text.Trim)

            '契約年月日From  
            wStr = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_DATE_FROM", intRow).Value)
            If wStr = "" Then
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", CDate(wStr))
            End If

            '契約年月日To 
            Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", pJIGYO_SYURYO_DATE)

            '農場コード（移動元）
            Cmd.Parameters.Add("IN_NOJO_CD_MOTO", WordHenkan("N", "S", dgv_Search.Item("NOJO_CD_MOTO", intRow).Value))

            '農場コード（移動先）
            Cmd.Parameters.Add("IN_NOJO_CD_SAKI", WordHenkan("N", "S", dgv_Search.Item("NOJO_CD_SAKI", intRow).Value))

            '契約区分　1:家族 2:企業 3:うずら 
            Cmd.Parameters.Add("IN_KEIYAKU_KBN", pKEIYAKU_KBN)

            '鶏の種類    TORI_KBN
            Cmd.Parameters.Add("IN_TORI_KBN", WordHenkan("N", "S", dgv_Search.Item("TORI_KBN", intRow).Value))

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
            Show_MessageBox("", ex.Message)
        Finally
            'データベースへの接続を閉じる
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

        f_ObjectClear = False

        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            pJump = True
            f_ClearFormALL(Me, wKbn)
            pJump = False

            '変数クリア
            pEnterKi = ""
            pSyoriKbn = Enu_SyoriKubun.Insert
            pSaveKeiyakuDateFrom = Nothing
            pSaveSyoriKbn = ""
            pDataSet.Clear()

            'If wKbn = "C" OrElse txt_KI.Text.Trim <> pInitKi Then
            'コンボボックスセット(契約者)
            If Not f_ComboBox_Set_Keiyaku(pInitKi) Then
                Exit Try
            End If
            'End If

            'ラベルクリア
            txt_KI.Text = pInitKi
            lblCOUNT.Text = ""
            lbl_MOTO_SEQNO_MAE.Text = ""
            lbl_MOTO_SEQNO_ATO.Text = ""
            lbl_SAKI_SEQNO_MAE.Text = ""
            lbl_SAKI_SEQNO_ATO.Text = ""

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
#Region "f_ComboBox_Set_Keiyaku コンボボックスセット処理(契約者)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ComboBox_Set_Keiyaku
    '説明            :コンボボックスセット処理(契約者)
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ComboBox_Set_Keiyaku(ByVal wKi As String) As Boolean
        Dim ret As Boolean = False
        Dim wWhere As String = String.Empty

        Try

            '期が未入力のとき
            If wKi = "" OrElse wKi = String.Empty Then
                '2015/03/04　修正開始--▽▽▽    DataSourceへ変更に伴い、初期化方法変更
                'cob_KEIYAKUSYA_CD.Items.Clear()
                'cob_KEIYAKUSYA_NM.Items.Clear()
                cob_KEIYAKUSYA_CD.DataSource = Nothing
                cob_KEIYAKUSYA_CD.Clear()
                cob_KEIYAKUSYA_NM.DataSource = Nothing
                cob_KEIYAKUSYA_NM.Clear()
                '2015/03/04　修正終了--△△△
                Exit Try
            End If

            '契約者マスタコンボセット(期:画面の期　契約状況:3(未継続者)除く)
            wWhere = "KI = " & wKi & " AND KEIYAKU_JYOKYO <> 3 "
            pJump = True   '2015/03/04　追加
            If Not f_Keiyaku_Data_Select(cob_KEIYAKUSYA_CD, cob_KEIYAKUSYA_NM, wWhere, True) Then
                Exit Try
            End If
            pJump = False   '2015/03/04　追加

            'コンボボックス初期化
            cob_KEIYAKUSYA_CD.Text = ""

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_ComboBox_Set_ToriKbn コンボボックスセット処理(鶏の種類)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ComboBox_Set_ToriKbn
    '説明            :コンボボックスセット処理(鶏の種類)
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ComboBox_Set_ToriKbn() As Boolean
        Dim ret As Boolean = False
        Dim wWhere As String = String.Empty

        Try

            '鳥の種類コンボセット
            If Not f_CodeMaster_Data_Select(cob_TORI_KBN, cob_TORI_KBN_NM, 7, True, 1) Then
                Exit Try
            End If

            'コンボボックス初期化()
            cob_TORI_KBN.Text = ""

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_ComboBox_Set_Nojo コンボボックスセット処理(農場)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ComboBox_Set_Nojo
    '説明            :コンボボックスセット処理(農場)
    '引数            :"" 　通常コンボセット
    '                :"I"　農場登録後のコンボセット
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ComboBox_Set_Nojo(ByVal wKbn As String) As Boolean
        Dim ret As Boolean = False
        Dim wWhere As String = String.Empty

        Try

            '契約者マスタコンボセット
            wWhere = "KI = " & txt_KI.Text.Trim & " AND KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text

            If wKbn = "" Then

                '検索ボタン押下時(入力不可)
                If Not f_KeiyakuNojo_Data_Select(cob_NOJO_CD_MOTO, cob_NOJO_NM_MOTO, wWhere, True, False) Then
                    Exit Try
                End If
                If Not f_KeiyakuNojo_Data_Select(cob_NOJO_CD_SAKI, cob_NOJO_NM_SAKI, wWhere, True, False) Then
                    Exit Try
                End If

                'コンボボックス初期化
                cob_NOJO_CD_MOTO.Text = ""
                cob_NOJO_CD_SAKI.Text = ""

            Else

                '農場登録時(入力可)
                If Not f_KeiyakuNojo_Data_Select(cob_NOJO_CD_MOTO, cob_NOJO_NM_MOTO, wWhere, True, True) Then
                    Exit Try
                End If
                If Not f_KeiyakuNojo_Data_Select(cob_NOJO_CD_SAKI, cob_NOJO_NM_SAKI, wWhere, True, True) Then
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

#Region "f_SearchEnableCtl 入力制御処理(検索)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SearchEnableCtl
    '説明            :入力制御処理(検索)
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SearchEnableCtl(ByVal wEnable As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            '検索条件
            txt_KI.Enabled = wEnable
            cob_KEIYAKUSYA_CD.Enabled = wEnable
            cob_KEIYAKUSYA_NM.Enabled = wEnable
            cmdSearch.Enabled = wEnable

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

        Try

            'キー
            If pSyoriKbn = Enu_SyoriKubun.Insert Then
                '新規
                cob_TORI_KBN.Enabled = wEnable
                cob_TORI_KBN_NM.Enabled = wEnable
                cob_NOJO_CD_MOTO.Enabled = wEnable
                cob_NOJO_NM_MOTO.Enabled = wEnable
                cob_NOJO_CD_SAKI.Enabled = wEnable
                cob_NOJO_NM_SAKI.Enabled = wEnable
                cmd_NOJO_INS.Enabled = wEnable
            Else
                '修正・削除
                cob_TORI_KBN.Enabled = False
                cob_TORI_KBN_NM.Enabled = False
                cob_NOJO_CD_MOTO.Enabled = False
                cob_NOJO_NM_MOTO.Enabled = False
                cob_NOJO_CD_SAKI.Enabled = False
                cob_NOJO_NM_SAKI.Enabled = False
                cmd_NOJO_INS.Enabled = False
            End If

            '明細
            num_IDO_HASU.Enabled = wEnable
            date_KEIYAKU_DATE_FROM.Enabled = wEnable
            pnl_SYORI_KBN2.Enabled = wEnable

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

#Region "f_Keiyaku_Data 初期画面表示(修正)処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Keiyaku_Data() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            'SQL
            wSql = "SELECT * FROM TM_KEIYAKU " & _
                   "WHERE KI = " & txt_KI.Text.Trim & _
                   "  AND KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                'Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                'データ無し
                Exit Try
            End If

            'データセーブ
            With wkDS.Tables(0)
                '契約区分
                pKEIYAKU_KBN = WordHenkan("N", "S", .Rows(0)("KEIYAKU_KBN"))
            End With

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region
#Region "f_Grid_Set グリッド表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :グリッドグリッド表示処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Grid_Set(ByVal wKbn As String,
                                ByVal wKeiyakuDate As Date,
                                ByVal wMotoNojoCd As String,
                                ByVal wSakiNojoCd As String,
                                ByVal wToriKbn As String) As Boolean
        Dim ret As Boolean = False
        Dim bol As Boolean = False
        Dim wSql As String = String.Empty

        Try

            'グリッドが入力不可の場合、スクロールバーが連動しないので、グリッドを入力可能にする
            dgv_Search.Enabled = True

            '初期処理以外は、画面クリア
            If wKbn <> "C" Then
                bol = f_DtlClear()
            End If

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
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'グリッドセット
            dgv_Search.DataSource = pDataSet.Tables(0)
            lblCOUNT.Text = pDataSet.Tables(0).Rows.Count.ToString("#,##0")

            '--------------------------------------------------
            '   グリッド表示位置
            '--------------------------------------------------
            If wKbn = "" Then
                bol = f_GridReDisp(wKeiyakuDate, wMotoNojoCd, wSakiNojoCd, wToriKbn)
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_Search_SQLMake グリッド用SQL作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :グリッド用SQL作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Search_SQLMake(ByRef wSql As String) As Boolean
        Dim ret As Boolean = False

        Try

            wSql &= "SELECT"
            wSql &= "  RIR.KEIYAKU_DATE_FROM,"
            wSql &= "  TO_CHAR(RIR.KEIYAKU_DATE_FROM, 'EEYY""/""MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') KEIYAKU_DATE_FROM_X,"
            wSql &= "  RIR.TORI_KBN,"
            wSql &= "  M07.RYAKUSYO TORI_KBN_NM,"
            wSql &= "  RIR.IDO_HASU,"
            '  --移動元
            wSql &= "  RIR.NOJO_CD_MOTO,"
            wSql &= "  MOT.NOJO_NAME NOJO_NM_MOTO,"
            wSql &= "  RIR.KEIYAKU_HASU_MOTO_MAE,"
            wSql &= "  RIR.KEIYAKU_HASU_MOTO_ATO,"
            '  --移動先
            wSql &= "  RIR.NOJO_CD_SAKI,"
            wSql &= "  SAK.NOJO_NAME NOJO_NM_SAKI,"
            wSql &= "  RIR.KEIYAKU_HASU_SAKI_MAE,"
            wSql &= "  RIR.KEIYAKU_HASU_SAKI_ATO,"
            '  --元SEQ
            wSql &= "  RIR.MOTO_SEQNO_MAE,"
            wSql &= "  RIR.MOTO_SEQNO_ATO,"
            wSql &= "  RIR.SAKI_SEQNO_MAE,"
            wSql &= "  RIR.SAKI_SEQNO_ATO,"
            '  --処理区分
            wSql &= "  SYORI_KBN,"
            wSql &= "  M12.MEISYO SYORI_KBN_NM "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_IDO_RIREKI RIR,"
            wSql &= "  TM_KEIYAKU_NOJO MOT,"
            wSql &= "  TM_KEIYAKU_NOJO SAK,"
            wSql &= "  TM_CODE M07,"
            wSql &= "  TM_CODE M12 "
            wSql &= "WHERE RIR.KI = " & txt_KI.Text.Trim
            wSql &= "  AND RIR.KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim
            '  --移動元の農場
            wSql &= "  AND RIR.KI = MOT.KI(+)"
            wSql &= "  AND RIR.KEIYAKUSYA_CD = MOT.KEIYAKUSYA_CD(+)"
            wSql &= "  AND RIR.NOJO_CD_MOTO  = MOT.NOJO_CD(+)"
            '  --移動先の農場
            wSql &= "  AND RIR.KI = SAK.KI(+)"
            wSql &= "  AND RIR.KEIYAKUSYA_CD = SAK.KEIYAKUSYA_CD(+)"
            wSql &= "  AND RIR.NOJO_CD_SAKI  = SAK.NOJO_CD(+)"
            '  --コードマスタ
            wSql &= "  AND 07 = M07.SYURUI_KBN(+)"
            wSql &= "  AND RIR.TORI_KBN  = M07.MEISYO_CD(+)"
            wSql &= "  AND 12 = M12.SYURUI_KBN(+)"
            wSql &= "  AND RIR.SYORI_KBN = M12.MEISYO_CD(+) "
            wSql &= "ORDER BY "
            ' ソート順はf_GridReDispと同一にする
            wSql &= "  RIR.KEIYAKU_DATE_FROM DESC,"
            wSql &= "  RIR.NOJO_CD_MOTO ASC,"
            wSql &= "  RIR.NOJO_CD_SAKI ASC,"
            wSql &= "  RIR.TORI_KBN ASC"

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
    Private Function f_GridReDisp(ByVal wKEIYAKU_DATE As Date,
                                  ByVal wNOJO_CD_MOTO As Integer,
                                  ByVal wNOJO_CD_SAKI As Integer,
                                  ByVal wTORI_KBN As Integer) As Boolean
        Dim ret As Boolean = False
        Dim blnHit As Boolean = False

        Try

            'グリッドに有効データあり
            If dgv_Search.RowCount <> 0 Then

                '更新対象のデータ　または　その次のデータに、カーソルをせっと
                For i As Integer = 0 To dgv_Search.RowCount - 1
                    '契約日(降順)　ブレーク
                    If f_DateTrim(wKEIYAKU_DATE) > f_DateTrim(WordHenkan("N", "Z", dgv_Search.Item("KEIYAKU_DATE_FROM", i).Value)) Then
                        '現在セル　セット
                        dgv_Search.CurrentCell = dgv_Search(1, i)
                        blnHit = True
                        Exit For
                    Else
                        '契約日(降順)　同一
                        If f_DateTrim(wKEIYAKU_DATE) = f_DateTrim(WordHenkan("N", "Z", dgv_Search.Item("KEIYAKU_DATE_FROM", i).Value)) Then
                            '移動元農場 ブレーク
                            If CInt(WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD_MOTO", i).Value)) > wNOJO_CD_MOTO Then
                                '移動元農場　ブレーク
                                dgv_Search.CurrentCell = dgv_Search(1, i)
                                blnHit = True
                                Exit For
                            Else
                                '移動元農場　同一
                                If CInt(WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD_MOTO", i).Value)) = wNOJO_CD_MOTO Then
                                    '移動先農場 ブレーク
                                    If CInt(WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD_SAKI", i).Value)) > wNOJO_CD_SAKI Then
                                        '移動先農場　ブレーク
                                        dgv_Search.CurrentCell = dgv_Search(1, i)
                                        blnHit = True
                                        Exit For
                                    Else
                                        '移動先農場　同一
                                        If CInt(WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD_SAKI", i).Value)) = wNOJO_CD_SAKI Then
                                            '鶏種類 ブレーク
                                            If CInt(WordHenkan("N", "Z", dgv_Search.Item("TORI_KBN", i).Value)) >= wTORI_KBN Then
                                                '鶏種類　ブレーク
                                                dgv_Search.CurrentCell = dgv_Search(1, i)
                                                blnHit = True
                                                Exit For
                                            End If
                                        End If
                                    End If
                                End If
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
#Region "f_NojoAddR_BothDsp 農場住所両方表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_NojoAddR_BothDsp
    '説明            :農場住所両方表示処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_NojoAddR_BothDsp() As Boolean
        Dim ret As Boolean = False

        Try

            '農場クリア
            ret = f_NojoAddR_BothClr()

            '農場(移動元)住所表示
            If Not f_NojoAddR_Dsp(cob_NOJO_CD_MOTO, lbl_ADDR_POST_MOTO,
                                  lbl_ADDR_1_MOTO, lbl_ADDR_2_MOTO, lbl_ADDR_3_MOTO, lbl_ADDR_4_MOTO,
                                  lbl_KEIYAKU_HASU_MOTO_MAE, lbl_KEIYAKU_HASU_MOTO_ATO, True) Then
                cob_NOJO_CD_MOTO.Focus()
                Exit Try
            End If

            '農場(移動先)住所表示
            If Not f_NojoAddR_Dsp(cob_NOJO_CD_SAKI, lbl_ADDR_POST_SAKI,
                                  lbl_ADDR_1_SAKI, lbl_ADDR_2_SAKI, lbl_ADDR_3_SAKI, lbl_ADDR_4_SAKI,
                                  lbl_KEIYAKU_HASU_SAKI_MAE, lbl_KEIYAKU_HASU_SAKI_ATO, True) Then
                cob_NOJO_CD_SAKI.Focus()
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
#Region "f_NojoAddR_Dsp 農場住所表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_NojoAddR_Dsp
    '説明            :農場住所表示処理
    '引数            :農場コード
    '                :農場・郵便番号
    '                :農場・住所1
    '                :農場・住所2
    '                :農場・住所3
    '                :農場・住所4
    '                :農場・契約羽数(移動前)
    '                :農場・契約羽数(移動後)
    '                :エラー表示(TRUE:表示あり　FALSE:表示なし)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_NojoAddR_Dsp(ByRef wNojoCd As JBD.Gjs.Win.GcComboBox,
                                    ByRef wPost As JBD.Gjs.Win.JLabel,
                                    ByRef wAddr1 As JBD.Gjs.Win.JLabel,
                                    ByRef wAddr2 As JBD.Gjs.Win.JLabel,
                                    ByRef wAddr3 As JBD.Gjs.Win.JLabel,
                                    ByRef wAddr4 As JBD.Gjs.Win.JLabel,
                                    ByRef wHasuMae As JBD.Gjs.Win.JLabel,
                                    ByRef wHasuAto As JBD.Gjs.Win.JLabel,
                                    ByVal wErrDsp As Boolean) As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty
        Dim wLngMae As Long = 0
        Dim wLngAto As Long = 0

        Try

            '鶏種類、羽数、農場が未入力のときクリア
            If wNojoCd.SelectedIndex = -1 OrElse wNojoCd.Text.Trim = "" Then
                '住所クリア
                f_NojoAddr_Clr(wPost, wAddr1, wAddr2, wAddr3, wAddr4, wHasuMae, wHasuAto)
                ret = True
                Exit Try
            End If

            'SQL
            wSql &= "SELECT"
            wSql &= "  NOJ.KI, "
            wSql &= "  NOJ.KEIYAKUSYA_CD,"
            wSql &= "  NOJ.NOJO_CD,"
            wSql &= "  NOJ.ADDR_POST,"
            wSql &= "  NOJ.ADDR_1,"
            wSql &= "  NOJ.ADDR_2,"
            wSql &= "  NOJ.ADDR_3,"
            wSql &= "  NOJ.ADDR_4 "
            wSql &= "FROM"
            wSql &= "  TM_KEIYAKU_NOJO NOJ "
            wSql &= "WHERE NOJ.KI = " & txt_KI.Text.Trim
            wSql &= "  AND NOJ.KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim
            wSql &= "  AND NOJ.NOJO_CD = " & wNojoCd.Text.Trim

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                '住所クリア
                f_NojoAddr_Clr(wPost, wAddr1, wAddr2, wAddr3, wAddr4, wHasuMae, wHasuAto)
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                '住所クリア
                f_NojoAddr_Clr(wPost, wAddr1, wAddr2, wAddr3, wAddr4, wHasuMae, wHasuAto)
                If wErrDsp Then
                    Show_MessageBox_Add("I007", "該当の契約農場は登録されていません。")
                End If
                Exit Try
            Else
                '住所セット
                wStr = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("ADDR_POST"))
                wPost.Text = f_MidB(wStr, 1, 3) & "-" & f_MidB(wStr, 4, 4)
                wAddr1.Text = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("ADDR_1"))
                wAddr2.Text = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("ADDR_2"))
                wAddr3.Text = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("ADDR_3"))
                wAddr4.Text = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("ADDR_4"))
            End If

            '羽数セット
            If wErrDsp Then     '2017/07/14　追加
                If Not f_NojoHasu_Dsp(wNojoCd, wHasuMae, wHasuAto, wErrDsp) Then
                    wHasuMae.Text = ""
                    wHasuAto.Text = ""
                    Exit Try
                End If
            End If              '2017/07/14　追加
            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region
#Region "f_NojoHasu_BothDsp 農場羽数　両方表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_NojoAddR_BothDsp
    '説明            :農場住所両方表示処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_NojoHasu_BothDsp() As Boolean
        Dim ret As Boolean = False

        Try

            '羽数クリア
            lbl_KEIYAKU_HASU_MOTO_MAE.Text = ""
            lbl_KEIYAKU_HASU_MOTO_ATO.Text = ""
            lbl_KEIYAKU_HASU_SAKI_MAE.Text = ""
            lbl_KEIYAKU_HASU_SAKI_ATO.Text = ""

            '農場(移動元)羽数　表示
            If Not f_NojoHasu_Dsp(cob_NOJO_CD_MOTO, lbl_KEIYAKU_HASU_MOTO_MAE, lbl_KEIYAKU_HASU_MOTO_ATO, True) Then
                Exit Try
            End If

            '農場(移動先)羽数　表示
            If Not f_NojoHasu_Dsp(cob_NOJO_CD_SAKI, lbl_KEIYAKU_HASU_SAKI_MAE, lbl_KEIYAKU_HASU_SAKI_ATO, True) Then
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
#Region "f_NojoHasu_Dsp 農場住所表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_NojoHasu_Dsp
    '説明            :農場住所表示処理
    '引数            :農場コード
    '　　            :移動前羽数
    '　　            :移動後羽数
    '                :エラー表示(TRUE:表示あり　FALSE:表示なし)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_NojoHasu_Dsp(ByRef wNojoCd As JBD.Gjs.Win.GcComboBox,
                                    ByRef wHasuMae As JBD.Gjs.Win.JLabel,
                                    ByRef wHasuAto As JBD.Gjs.Win.JLabel,
                                    ByVal wErrDsp As Boolean) As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty
        Dim wLngMae As Long = 0
        Dim wLngAto As Long = 0
        Dim wSeqNo As String = String.Empty

        Try

            '鶏種類、農場が未入力のときクリア
            If wNojoCd.SelectedIndex = -1 OrElse wNojoCd.Text.Trim = "" OrElse _
                cob_TORI_KBN.SelectedIndex = -1 OrElse cob_TORI_KBN.Text.Trim = "" Then
                '金額
                wHasuMae.Text = ""
                wHasuAto.Text = ""
                ret = True
                Exit Try
            End If


            '2017/07/14　修正開始
            'SQL
            'wSql &= "SELECT"
            'wSql &= "  JOH.KEIYAKU_HASU "
            'wSql &= "FROM"
            'wSql &= "  TT_KEIYAKU_JOHO JOH "
            'wSql &= "WHERE JOH.KI = " & txt_KI.Text.Trim
            'wSql &= "  AND JOH.KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim
            'wSql &= "  AND JOH.NOJO_CD = " & wNojoCd.Text.Trim
            'wSql &= "  AND JOH.TORI_KBN = " & cob_TORI_KBN.Text.Trim
            'wSql &= "  AND JOH.DATA_FLG =  1"
            If pSyoriKbn = Enu_SyoriKubun.Insert Then
                '新規のとき、
                wSql &= "SELECT"
                wSql &= "  JOH.KEIYAKU_HASU "
                wSql &= "FROM"
                wSql &= "  TT_KEIYAKU_JOHO JOH "
                wSql &= "WHERE JOH.KI = " & txt_KI.Text.Trim
                wSql &= "  AND JOH.KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim
                wSql &= "  AND JOH.NOJO_CD = " & wNojoCd.Text.Trim
                wSql &= "  AND JOH.TORI_KBN = " & cob_TORI_KBN.Text.Trim
                wSql &= "  AND JOH.DATA_FLG =  1"
            Else
                If wNojoCd.Equals(cob_NOJO_CD_MOTO) Then
                    wSeqNo = lbl_MOTO_SEQNO_MAE.Text
                Else
                    If lbl_SAKI_SEQNO_MAE.Text = "" Then
                        wSeqNo = 0
                    Else
                        wSeqNo = lbl_SAKI_SEQNO_MAE.Text
                    End If
                End If
                wSql &= "SELECT"
                wSql &= "  JOH.KEIYAKU_HASU "
                wSql &= "FROM"
                wSql &= "  TT_KEIYAKU_JOHO JOH "
                wSql &= "WHERE JOH.SEQNO = " & wSeqNo.ToString
            End If
            '2017/07/14　修正終了

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                '金額クリア
                wHasuMae.Text = ""
                wHasuAto.Text = ""
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                If wNojoCd.Equals(cob_NOJO_CD_MOTO) Then
                    '移動元のときエラー
                    '金額クリア
                    wHasuMae.Text = ""
                    wHasuAto.Text = ""
                    If wErrDsp Then
                        Show_MessageBox_Add("I007", "該当の契約情報は登録されていません。")
                    End If
                    Exit Try
                Else
                    '移動先のときＯＫ
                    wHasuMae.Text = ""
                    wHasuAto.Text = Format(num_IDO_HASU.Value, "##,###,##0")
                    ret = True
                    Exit Try
                End If
            End If

            '移動前契約羽数
            wLngMae = WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("KEIYAKU_HASU"))

            If wkDS.Tables(0).Rows(0)("KEIYAKU_HASU") Is DBNull.Value Then
                wHasuMae.Text = ""
            Else
                wHasuMae.Text = wLngMae.ToString("##,###,###")
            End If

            '移動後契約羽数
            If num_IDO_HASU.Value Is Nothing OrElse num_IDO_HASU.Text.Trim = "" Then
                wHasuAto.Text = ""
            Else
                If wNojoCd.Equals(cob_NOJO_CD_MOTO) Then
                    wLngAto = wLngMae - num_IDO_HASU.Value
                    wHasuAto.Text = wLngAto.ToString("##,###,##0")
                Else
                    wLngAto = wLngMae + num_IDO_HASU.Value
                    wHasuAto.Text = wLngAto.ToString("##,###,##0")
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
#Region "f_NojoAddR_BothClr 農場住所　両方クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_NojoAddR_BothClr
    '説明            :農場住所両方クリア処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_NojoAddR_BothClr() As Boolean
        Dim ret As Boolean = False

        Try

            '農場(移動元)住所クリア
            f_NojoAddr_Clr(lbl_ADDR_POST_MOTO,
                           lbl_ADDR_1_MOTO, lbl_ADDR_2_MOTO, lbl_ADDR_3_MOTO, lbl_ADDR_4_MOTO,
                           lbl_KEIYAKU_HASU_MOTO_MAE, lbl_KEIYAKU_HASU_MOTO_ATO)
            Exit Try

            '農場(移動先)住所クリア
            f_NojoAddr_Clr(lbl_ADDR_POST_SAKI,
                           lbl_ADDR_1_SAKI, lbl_ADDR_2_SAKI, lbl_ADDR_3_SAKI, lbl_ADDR_4_SAKI,
                           lbl_KEIYAKU_HASU_SAKI_MAE, lbl_KEIYAKU_HASU_SAKI_ATO)
            Exit Try

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
    Private Function f_NojoAddr_Clr(ByRef wPost As JBD.Gjs.Win.JLabel,
                                    ByRef wAddr1 As JBD.Gjs.Win.JLabel,
                                    ByRef wAddr2 As JBD.Gjs.Win.JLabel,
                                    ByRef wAddr3 As JBD.Gjs.Win.JLabel,
                                    ByRef wAddr4 As JBD.Gjs.Win.JLabel,
                                    ByRef wHasuMae As JBD.Gjs.Win.JLabel,
                                    ByRef wHasuAto As JBD.Gjs.Win.JLabel) As Boolean
        Dim ret As Boolean = False

        Try

            wPost.Text = ""
            wAddr1.Text = ""
            wAddr2.Text = ""
            wAddr3.Text = ""
            wAddr4.Text = ""
            wHasuMae.Text = ""
            wHasuAto.Text = ""

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
            cob_TORI_KBN.SelectedIndex = -1
            cob_TORI_KBN_NM.SelectedIndex = -1

            num_IDO_HASU.Value = Nothing

            cob_NOJO_CD_MOTO.SelectedIndex = -1
            cob_NOJO_NM_MOTO.SelectedIndex = -1
            lbl_ADDR_POST_MOTO.Text = ""
            lbl_ADDR_1_MOTO.Text = ""
            lbl_ADDR_2_MOTO.Text = ""
            lbl_ADDR_3_MOTO.Text = ""
            lbl_ADDR_4_MOTO.Text = ""
            lbl_KEIYAKU_HASU_MOTO_MAE.Text = ""
            lbl_KEIYAKU_HASU_MOTO_ATO.Text = ""

            cob_NOJO_CD_SAKI.SelectedIndex = -1
            cob_NOJO_NM_SAKI.SelectedIndex = -1
            lbl_ADDR_POST_SAKI.Text = ""
            lbl_ADDR_1_SAKI.Text = ""
            lbl_ADDR_2_SAKI.Text = ""
            lbl_ADDR_3_SAKI.Text = ""
            lbl_ADDR_4_SAKI.Text = ""
            lbl_KEIYAKU_HASU_SAKI_MAE.Text = ""
            lbl_KEIYAKU_HASU_SAKI_ATO.Text = ""

            date_KEIYAKU_DATE_FROM.Value = Nothing
            rbtn_SYORI_KBN1.Checked = True

            lbl_MOTO_SEQNO_MAE.Text = ""
            lbl_MOTO_SEQNO_ATO.Text = ""
            lbl_SAKI_SEQNO_MAE.Text = ""
            lbl_SAKI_SEQNO_ATO.Text = ""

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Input_Check_Search  画面入力チェック処理(検索)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check
    '説明            :画面入力チェック処理
    '引数            :0:保存　1:コピー
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_Search() As Boolean
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

            '==いろいろチェック==================

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region
#Region "f_Input_Check_CmdDel  画面入力チェック処理(削除ボタン)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check_CmdIns
    '説明            :画面入力チェック処理(削除ボタン)
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_CmdDel(ByVal wIdx As Integer) As Boolean
        Dim ret As Boolean = False
        Dim wMOTO_SEQNO_ATO As String = String.Empty
        Dim wSAKI_SEQNO_ATO As String = String.Empty
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty

        Try

            '入力中の場合、チェックなし
            If WordHenkan("N", "S", dgv_Search.Item("SYORI_KBN", wIdx).Value) = 1 Then
                ret = True
                Exit Try
            End If

            '元SEQNO（移動後）　　移動後の移動元農場のSEQNO
            wMOTO_SEQNO_ATO = WordHenkan("N", "S", dgv_Search.Item("MOTO_SEQNO_ATO", wIdx).Value)
            '先SEQNO（移動後）　　移動後の移動先農場のSEQNO
            wSAKI_SEQNO_ATO = WordHenkan("N", "S", dgv_Search.Item("SAKI_SEQNO_ATO", wIdx).Value)

            If wMOTO_SEQNO_ATO = "" Then

            End If

            '-------------------------------------------------
            '移動元農場の移動後データ　チェック
            '-------------------------------------------------
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  DATA_FLG "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO "
            wSql &= "WHERE SEQNO = " & wMOTO_SEQNO_ATO

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                cob_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                Show_MessageBox_Add("I007", "移動元の契約情報が存在しません。")
                Exit Try
            End If

            'データ区分
            If WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("DATA_FLG")) = 0 Then
                Show_MessageBox_Add("I007", "移動元の移動後データが、すでに無効のため" & vbCrLf & "処理できません。")
                Exit Try
            End If

            '-------------------------------------------------
            '移動先農場の移動後データ　チェック
            '-------------------------------------------------
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  DATA_FLG "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO "
            wSql &= "WHERE SEQNO = " & wSAKI_SEQNO_ATO

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                cob_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                Show_MessageBox_Add("I007", "移動先の契約情報が存在しません。")
                Exit Try
            End If

            'データ区分
            If WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("DATA_FLG")) = 0 Then
                Show_MessageBox_Add("I007", "移動先の移動後データが、すでに無効のため" & vbCrLf & "処理できません。")
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
#Region "f_Input_Check_CmdIns  画面入力チェック処理(新規登録ボタン)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check_CmdIns
    '説明            :画面入力チェック処理(新規登録ボタン)
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_CmdIns() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty

        Try

            'SQL
            wSql &= "SELECT"
            wSql &= "  KEIYAKU_DATE, HAIGYO_DATE "
            wSql &= "  ,NYU_HEN_DATE " '2021/07/13 JBD9020 新契約日追加 ADD 
            wSql &= "FROM"
            wSql &= "  TM_KEIYAKU "
            wSql &= "WHERE KI = " & txt_KI.Text.Trim
            wSql &= "  AND KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                cob_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                Show_MessageBox_Add("I007", "該当の契約者は登録されていません。")
                cob_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If

            '契約日チェック
            If wkDS.Tables(0).Rows(0)("KEIYAKU_DATE") Is DBNull.Value Then
                Show_MessageBox_Add("I007", "契約が完了していない契約者です。")
                cob_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If
            '2021/07/13 JBD9020 新契約日追加 ADD START
            '入金返還日チェック
            If wkDS.Tables(0).Rows(0)("NYU_HEN_DATE") Is DBNull.Value Then
                Show_MessageBox_Add("I007", "契約が完了していない契約者です。")
                cob_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If
            '2021/07/13 JBD9020 新契約日追加 ADD END

            '廃業日チェック
            If Not (wkDS.Tables(0).Rows(0)("HAIGYO_DATE") Is DBNull.Value) Then
                Show_MessageBox_Add("I007", "廃業されている契約者です。")
                cob_KEIYAKUSYA_CD.Focus()
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
#Region "f_Input_Check_Save  画面入力チェック処理(更新)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check
    '説明            :画面入力チェック処理
    '引数            :0:保存　1:コピー
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_Save() As Boolean
        Dim ret As Boolean = False
        Dim wkControl As Control
        Dim wkControlName As String
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            '==必須チェック==================

            wkControlName = "鶏の種類"
            wkControl = cob_TORI_KBN
            If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "移動羽数"
            wkControl = num_IDO_HASU
            If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "農場(移動元)"
            wkControl = cob_NOJO_CD_MOTO
            If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "農場(移動先)"
            wkControl = cob_NOJO_CD_SAKI
            If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "移動年月日"
            wkControl = date_KEIYAKU_DATE_FROM
            If date_KEIYAKU_DATE_FROM.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            '==FromToチェック==================

            '事業開始日  >　移動日　はエラー
            If pJIGYO_KAISU_DATE > f_DateTrim(date_KEIYAKU_DATE_FROM.Value) Then
                Call Show_MessageBox_Add("I007", "移動日の指定が正しくありません。")    '@0
                date_KEIYAKU_DATE_FROM.Focus()
                Exit Try
            End If

            '移動日  >  事業終了日　はエラー
            If f_DateTrim(date_KEIYAKU_DATE_FROM.Value) > pJIGYO_SYURYO_DATE Then
                Call Show_MessageBox_Add("I007", "移動日の指定が正しくありません。")    '@0
                date_KEIYAKU_DATE_FROM.Focus()
                Exit Try
            End If


            '==いろいろチェック==================

            '新規・変更の共通チェック

            '------------------------------
            '契約区分と鳥の種類
            '------------------------------
            '2017/09/08 修正開始
            ''契約区分:3(うずら)のときは、鶏の種類は6:(うずら)のみ
            'If pKEIYAKU_KBN = 3 AndAlso Not cob_TORI_KBN.Text.Trim = 6 Then
            '    Show_MessageBox_Add("I007", "鶏の種類はうずらのみ有効な契約者です。")
            '    Exit Try
            'End If
            '契約区分:3(鶏以外)のときは、鶏の種類は6～11:(うずら～だちょう)のみ
            If pKEIYAKU_KBN = 3 AndAlso Not (cob_TORI_KBN.Text.Trim >= 6 And cob_TORI_KBN.Text.Trim <= 11) Then
                Show_MessageBox_Add("I007", "鶏の種類はうずら～だちょうのみ有効な契約者です。")
                Exit Try
            End If
            '2017/09/08 修正終了
            '------------------------------
            '移動後の契約羽数
            '------------------------------
            If CInt(lbl_KEIYAKU_HASU_MOTO_ATO.Text.Trim) < 0 Then
                Show_MessageBox_Add("I007", "移動羽数が誤っています。")
                Exit Try
            End If

            'If Not f_Input_Check_SaveBoth() Then
            '    Exit Try
            'End If

            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert       '新規入力

                    '新規のときのチェック
                    If Not f_Input_Check_SaveIns() Then
                        Exit Try
                    End If

                Case Enu_SyoriKubun.Update       '変更

                    '変更のときのチェック
                    If Not f_Input_Check_SaveUpd() Then
                        Exit Try
                    End If

            End Select

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_Input_Check_SaveBoth  画面入力チェック処理(新規と変更　保存ボタン)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check_CmdIns
    '説明            :画面入力チェック処理(新規と変更　保存ボタン)"
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_SaveBoth() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty

        Try

            '------------------------------
            '契約区分と鳥の種類
            '------------------------------
            '契約区分:3(うずら)のときは、鶏の種類は6:(うずら)のみ
            If pKEIYAKU_KBN = 3 AndAlso Not cob_TORI_KBN.Text.Trim = 6 Then
                Show_MessageBox_Add("I007", "鶏の種類はうずらのみ有効な契約者です。")
                Exit Try
            End If

            '------------------------------
            '移動後の契約羽数
            '------------------------------
            If CInt(lbl_KEIYAKU_HASU_MOTO_ATO.Text.Trim) < 0 Then
                Show_MessageBox_Add("I007", "移動羽数が誤っています。")
                Exit Try
            End If

            '------------------------------
            '移動元の有効契約年月日
            '------------------------------
            wSql &= "SELECT"
            wSql &= "  MAX(JOH.DATA_FLG) DATA_FLG,"
            wSql &= "  MAX(CASE WHEN JOH.DATA_FLG = 1 THEN KEIYAKU_DATE_FROM ELSE NULL END) KEIYAKU_DATE_FROM "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO JOH "
            wSql &= "WHERE JOH.KI = " & txt_KI.Text.Trim
            wSql &= "  AND JOH.KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim
            wSql &= "  AND JOH.NOJO_CD = " & cob_NOJO_CD_MOTO.Text.Trim
            wSql &= "  AND JOH.TORI_KBN = " & cob_TORI_KBN.Text.Trim

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                Show_MessageBox_Add("I007", "農場(移動元)に有効な契約情報が存在しません。")
                Exit Try
            End If

            '契約日チェック
            wStr = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("KEIYAKU_DATE_FROM"))
            '契約開始日　≧　移動日　はエラー
            If WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("DATA_FLG")) = 1 AndAlso
                CDate(wStr) >= f_DateTrim(date_KEIYAKU_DATE_FROM.Value) Then
                Show_MessageBox_Add("I007", "現在、有効な契約情報の年月日より" & vbCrLf & "前の移動年月日は指定できません。")
                If pSyoriKbn = Enu_SyoriKubun.Insert Then
                    cob_NOJO_CD_MOTO.Focus()
                End If
                Exit Try
            End If

            '------------------------------
            '移動先の有効契約年月日
            '------------------------------
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  MAX(JOH.DATA_FLG) DATA_FLG,"
            wSql &= "  MAX(CASE WHEN JOH.DATA_FLG = 1 THEN KEIYAKU_DATE_FROM ELSE NULL END) KEIYAKU_DATE_FROM "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO JOH "
            wSql &= "WHERE JOH.KI = " & txt_KI.Text.Trim
            wSql &= "  AND JOH.KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim
            wSql &= "  AND JOH.NOJO_CD = " & cob_NOJO_CD_SAKI.Text.Trim
            wSql &= "  AND JOH.TORI_KBN = " & cob_TORI_KBN.Text.Trim

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            '移動先が新規のときは、該当データなしでもOK
            If wkDS.Tables(0).Rows.Count = 0 Then
                ret = True
                Exit Try
            End If

            '契約日チェック
            wStr = WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("KEIYAKU_DATE_FROM"))
            '契約開始日　≧　移動日　はエラー
            If WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("DATA_FLG")) = 1 AndAlso
                CDate(wStr) >= f_DateTrim(date_KEIYAKU_DATE_FROM.Value) Then
                Show_MessageBox_Add("I007", "現在、有効な契約情報の年月日より" & vbCrLf & "前の移動年月日は指定できません。")
                If pSyoriKbn = Enu_SyoriKubun.Insert Then
                    cob_NOJO_CD_MOTO.Focus()
                End If
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
#Region "f_Input_Check_SaveIns  画面入力チェック処理(新規の保存ボタン)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check_SaveIns
    '説明            :画面入力チェック処理(新規の保存ボタン)
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_SaveIns() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty

        Try

            '--------------------------------------------------
            '移動元と移動先が同一のときエラー
            '--------------------------------------------------
            If cob_NOJO_CD_MOTO.Text.Trim = cob_NOJO_CD_SAKI.Text.Trim Then
                Call Show_MessageBox_Add("I007", "農場(移動元)と農場(移動元)が同一です。")    '@0
                cob_NOJO_CD_MOTO.Focus()
                Exit Try
            End If

            '--------------------------------------------------
            '入力中チェック
            '--------------------------------------------------
            If dgv_Search.Rows.Count > 0 Then
                For i = 0 To dgv_Search.Rows.Count - 1

                    '鶏の種類が同一で入力中のデータがあり
                    If dgv_Search.Item("TORI_KBN", i).Value = cob_TORI_KBN.Text.Trim AndAlso
                       dgv_Search.Item("SYORI_KBN", i).Value = 1 Then

                        '移動元農場　または　移動先農場のデータがあり
                        If dgv_Search.Item("NOJO_CD_MOTO", i).Value = cob_NOJO_CD_MOTO.Text.Trim OrElse
                           dgv_Search.Item("NOJO_CD_MOTO", i).Value = cob_NOJO_CD_SAKI.Text.Trim Then
                            Call Show_MessageBox_Add("I007", "入力中のデータが存在するため登録できません。")    '@0
                            cob_NOJO_CD_MOTO.Focus()
                            Exit Try
                        End If

                        '移動元農場　または　移動先農場のデータがあり
                        If dgv_Search.Item("NOJO_CD_SAKI", i).Value = cob_NOJO_CD_MOTO.Text.Trim OrElse
                           dgv_Search.Item("NOJO_CD_SAKI", i).Value = cob_NOJO_CD_SAKI.Text.Trim Then
                            Call Show_MessageBox_Add("I007", "入力中のデータが存在するため登録できません。")    '@0
                            cob_NOJO_CD_SAKI.Focus()
                            Exit Try
                        End If

                    End If

                Next
            End If

            '--------------------------------------------------
            '移動元の有効契約年月日
            '--------------------------------------------------
            wSql &= "SELECT"
            wSql &= "  KEIYAKU_DATE_FROM "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO JOH "
            wSql &= "WHERE JOH.KI = " & txt_KI.Text.Trim
            wSql &= "  AND JOH.KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim
            wSql &= "  AND JOH.NOJO_CD = " & cob_NOJO_CD_MOTO.Text.Trim
            wSql &= "  AND JOH.TORI_KBN = " & cob_TORI_KBN.Text.Trim
            wSql &= "  AND JOH.DATA_FLG = 1"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                Show_MessageBox_Add("I007", "農場(移動元)に有効な契約情報が存在しません。")
                Exit Try
            End If

            '契約日チェック
            wStr = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("KEIYAKU_DATE_FROM"))
            '登録の移動日　≦　現在の契約開始日　はエラー
            If f_DateTrim(date_KEIYAKU_DATE_FROM.Value) <= CDate(wStr) Then
                Show_MessageBox_Add("I007", "現在、有効な契約情報の年月日より" & vbCrLf & _
                                            "前の移動年月日は指定できません。" & vbCrLf & "(移動元農場)")
                If pSyoriKbn = Enu_SyoriKubun.Insert Then
                    date_KEIYAKU_DATE_FROM.Focus()
                End If
                Exit Try
            End If

            '--------------------------------------------------
            '移動先の有効契約年月日
            '--------------------------------------------------
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  KEIYAKU_DATE_FROM "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO JOH "
            wSql &= "WHERE JOH.KI = " & txt_KI.Text.Trim
            wSql &= "  AND JOH.KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim
            wSql &= "  AND JOH.NOJO_CD = " & cob_NOJO_CD_SAKI.Text.Trim
            wSql &= "  AND JOH.TORI_KBN = " & cob_TORI_KBN.Text.Trim
            wSql &= "  AND JOH.DATA_FLG = 1"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            '移動先が新規のときは、該当データなしでもOK
            If wkDS.Tables(0).Rows.Count = 0 Then
                ret = True
                Exit Try
            End If

            '契約日チェック
            wStr = WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("KEIYAKU_DATE_FROM"))
            '登録の移動日　≦　現在の契約開始日　はエラー
            If f_DateTrim(date_KEIYAKU_DATE_FROM.Value) <= CDate(wStr) Then
                Show_MessageBox_Add("I007", "現在、有効な契約情報の年月日より" & vbCrLf & _
                                            "前の移動年月日は指定できません。" & vbCrLf & "(移動先農場)")
                If pSyoriKbn = Enu_SyoriKubun.Insert Then
                    date_KEIYAKU_DATE_FROM.Focus()
                End If
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
#Region "f_Input_Check_SaveUpd  画面入力チェック処理(変更の保存ボタン)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check_SaveUpd
    '説明            :画面入力チェック処理(変更の保存ボタン)"
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_SaveUpd() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty

        Try

            '--------------------------------------------------
            '移動元農場が、変更可能かチェック
            '--------------------------------------------------
            '確定のとき
            If pSaveSyoriKbn = 2 Then

                '修正前が、入力中のとき、変更前データをチェック
                wSql &= "SELECT"
                wSql &= "  KEIYAKU_DATE_FROM, JOH.DATA_FLG "
                wSql &= "FROM"
                wSql &= "  TT_KEIYAKU_JOHO JOH "
                wSql &= "WHERE JOH.SEQNO = " & lbl_MOTO_SEQNO_ATO.Text.Trim

                'DBからデータを取得
                If f_Select_ODP(wkDS, wSql) = False Then
                    Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                    Exit Try
                End If

                'データ有無
                If wkDS.Tables(0).Rows.Count = 0 Then
                    Show_MessageBox_Add("I007", "農場(移動元)に有効な契約情報が存在しません。")
                    Exit Try
                End If

                'データフラグ=0(無効)　はエラー
                If WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("DATA_FLG")) = 0 Then
                    Show_MessageBox_Add("I007", "農場(移動元)データがすでに無効のため" & vbCrLf & "処理できません。")
                    Exit Try
                End If

            End If

            '--------------------------------------------------
            '移動元農場の、移動前契約日と入力した契約日をチェック
            '--------------------------------------------------
            '修正前が、入力中のとき、変更前データをチェック
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  KEIYAKU_DATE_FROM, JOH.DATA_FLG "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO JOH "
            wSql &= "WHERE JOH.SEQNO = " & lbl_MOTO_SEQNO_MAE.Text.Trim

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                Show_MessageBox_Add("I007", "農場(移動元)に有効な契約情報が存在しません。")
                Exit Try
            End If

            '契約日チェック
            wStr = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("KEIYAKU_DATE_FROM"))
            '修正の移動日　≦　現在の契約開始日　はエラー
            If f_DateTrim(date_KEIYAKU_DATE_FROM.Value) <= CDate(wStr) Then
                Show_MessageBox_Add("I007", "現在、有効な契約情報の年月日より" & vbCrLf & _
                                            "前の移動年月日は指定できません。" & vbCrLf & "(移動元農場)")
                If pSyoriKbn = Enu_SyoriKubun.Insert Then
                    date_KEIYAKU_DATE_FROM.Focus()
                End If
                Exit Try
            End If

            '--------------------------------------------------
            '移動先農場が、変更可能かチェック
            '--------------------------------------------------
            '確定のとき
            If pSaveSyoriKbn = 2 Then

                '修正前が、入力中のとき、変更前データをチェック
                wSql = ""
                wSql &= "SELECT"
                wSql &= "  KEIYAKU_DATE_FROM, JOH.DATA_FLG "
                wSql &= "FROM"
                wSql &= "  TT_KEIYAKU_JOHO JOH "
                wSql &= "WHERE JOH.SEQNO = " & lbl_SAKI_SEQNO_ATO.Text.Trim

                'DBからデータを取得
                If f_Select_ODP(wkDS, wSql) = False Then
                    Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                    Exit Try
                End If

                'データ有無
                If wkDS.Tables(0).Rows.Count = 0 Then
                    Show_MessageBox_Add("I007", "農場(移動先)に有効な契約情報が存在しません。")
                    Exit Try
                End If

                'データフラグ=0(無効)　はエラー
                If WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("DATA_FLG")) = 0 Then
                    Show_MessageBox_Add("I007", "農場(移動先)データがすでに無効のため" & vbCrLf & "処理できません。")
                    Exit Try
                End If

            End If

            '--------------------------------------------------
            '移動先農場の、移動前契約日と入力した契約日をチェック
            '--------------------------------------------------
            '新規農場の場合、契約情報がない場合がある。
            If lbl_SAKI_SEQNO_MAE.Text.Trim = "" Then
                ret = True
                Exit Try
            End If

            '入力中のとき、変更前データをチェック
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  KEIYAKU_DATE_FROM, JOH.DATA_FLG "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO JOH "
            wSql &= "WHERE JOH.SEQNO = " & lbl_SAKI_SEQNO_MAE.Text.Trim

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                Show_MessageBox_Add("I007", "農場(移動先)に有効な契約情報が存在しません。")
                Exit Try
            End If

            '契約日チェック
            wStr = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("KEIYAKU_DATE_FROM"))
            '修正の移動日　≦　現在の契約開始日　はエラー
            If f_DateTrim(date_KEIYAKU_DATE_FROM.Value) <= CDate(wStr) Then
                Show_MessageBox_Add("I007", "現在、有効な契約情報の年月日より" & vbCrLf & _
                                            "前の移動年月日は指定できません。" & vbCrLf & "(移動先農場)")
                If pSyoriKbn = Enu_SyoriKubun.Insert Then
                    date_KEIYAKU_DATE_FROM.Focus()
                End If
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

    Private Sub num_IDO_HASU_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles num_IDO_HASU.ValueChanged

    End Sub

    Private Sub txt_KI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_KI.TextChanged

    End Sub
End Class
