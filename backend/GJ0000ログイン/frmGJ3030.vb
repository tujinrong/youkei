'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ3030.vb
'*
'*　　②　機能概要　　　　　互助基金契約者情報変更（譲渡）
'*
'*　　③　作成日　　　　　　2015/03/24　BY JBD
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

Public Class frmGJ3030

#Region "***変数定義***"

    ''' <summary>
    ''' 結果一覧セット用データセット
    ''' </summary>
    ''' <remarks></remarks>
    Private pHdDataSet As New DataSet
    Private pDtlDataSet As New DataSet

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
        ''' <summary>
        ''' 削除モード
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 2
    End Enum

    ''' <summary>
    ''' 変更時、該当データ選択行
    ''' </summary>
    ''' <remarks></remarks>
    Public pSel_POS As Integer
    Public pChk_Cnt As Integer

    ''' <summary>
    ''' グリッドキー項目構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T_KEY

        Public KI As Integer
        Public SEIKYU_KAISU As String
        Public SAKI_KEIYAKUSYA_CD As Integer
        Public SAKI_KEIYAKUSYA_NM As String
        Public SAKI_KEIYAKU_KBN As Integer
        Public KEIYAKU_DATE_FROM As Date
        Public KEIYAKU_DATE_FROM_X As String
        Public KEIYAKU_DATE_TO As Date
        Public SYORI_KBN As Integer
        Public MOTO_KEIYAKUSYA_CD As Integer
        Public MOTO_KEIYAKUSYA_NM As String
        Public MOTO_KEIYAKU_KBN As Integer
        Public KEIYAKU_HENKO_KBN As Integer     '2018/07/04　追加

    End Class

    ''' <summary>
    ''' カレント主キー
    ''' </summary>
    ''' <remarks></remarks>
    Property pCurrentKey As frmGJ3030.T_KEY

    ''' <summary>
    '''  プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True
    Private pJIGYO_KAISI_DATE As Date       '事業開始日
    Private pJIGYO_SYURYO_DATE As Date      '事業終了日

    Private pInitKi As String               '期(初期値)
    Private pEnterKi As String              '期(入力値)

    Private pSaveSyoriKbn As String         '(更新前)処理区分　(修正・削除処理用)
    Private pSaveKeiyakuDateFrom As Date    '(更新前)契約開始日(修正・削除処理用)

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

#If DEBUG Then
            Console.WriteLine("デバッグバージョンです。")
            'デバッグ
            If pLOGINUSERID = "" Then
                lbl_SAKI_KEIYAKU_KBN.Visible = True     'TEST
                lbl_MOTO_KEIYAKU_KBN.Visible = True     'TEST
            Else
                lbl_SAKI_KEIYAKU_KBN.Visible = False     'TEST
                lbl_MOTO_KEIYAKU_KBN.Visible = False     'TEST
            End If
#End If


            Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

            '初期値取得
            pJIGYO_KAISI_DATE = clsNENDO_KI.pJIGYO_NENDO_byDate         '事業開始日
            pJIGYO_SYURYO_DATE = clsNENDO_KI.pJIGYO_SYURYO_NENDO_byDate '事業最終日
            pInitKi = clsNENDO_KI.pKI   '当期

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            '画面初期化
            pJump = True
            ret = f_ObjectClear("C")
            pJump = False

            '変更判定イベント登録
            f_setControlChangeEvents()

            '入力制御
            ret = f_HdSearchEnableCtl(True)
            ret = f_HdEnableCtl(False)
            ret = f_DtlSearchEnableCtl(False, False, False)
            ret = f_DtlEnableCtl(False, False, False)

            '変更フラグ　クリア
            loblnTextChange = False

            '★初期コントロールにフォーカスセット
            txt_KI.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()

        End Try

    End Sub

    Private Sub frmGJ3030_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    End Sub

#End Region

#End Region

#Region "***画面ボタンクリック関連***"

#Region "cmdHdSearch_Click ヘッダ部検索ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdHdSearch_Click
    '説明            :ヘッダ部検索ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdHdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHdSearch.Click
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '画面入力チェック
            If Not f_Input_Check_HdSearch() Then
                Exit Try
            End If

            'SQL作成
            If Not f_HdGrid_Set("C", Now, 0) Then
                Exit Try
            End If

            '入力制御
            If dgv_HdSearch.Rows.Count = 0 Then
                pSyoriKbn = Enu_SyoriKubun.Insert
            Else
                pSyoriKbn = Enu_SyoriKubun.Update
            End If
            ret = f_HdSearchEnableCtl(False)
            ret = f_HdEnableCtl(True)
            ret = f_DtlSearchEnableCtl(False, False, False)
            ret = f_DtlEnableCtl(False, False, False)

            '変更フラグ　クリア
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

#Region "cmdHdSearchClr_Click ヘッダ部クリアボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSearchClr
    '説明            :ヘッダ部クリアボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdHdSearchClr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdHdSearchClr.Click
        Dim ret As Boolean

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '画面クリア
            ret = f_ObjectClear("")

            '入力制御
            ret = f_HdSearchEnableCtl(True)
            ret = f_HdEnableCtl(False)
            ret = f_DtlSearchEnableCtl(False, False, False)
            ret = f_DtlEnableCtl(False, False, False)

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
        Dim wKeiyakuKbn As String = String.Empty
        Dim wStr As String = String.Empty

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '選択されている行を見つける
            For Each gRow As DataGridViewRow In dgv_HdSearch.SelectedRows
                pSel_POS = gRow.Index
                Exit For
            Next

            '未請求チェック
            If dgv_HdSearch.Rows.Count > 0 Then
                For i = 0 To dgv_HdSearch.Rows.Count - 1
                    If dgv_HdSearch.Item("SEIKYU_KAISU", i).Value Is DBNull.Value Then
                        '画面に変更がない場合は、メッセージ表示
                        Show_MessageBox_Add("I007", "未請求のデータが存在するため、新規登録はできません。")
                        Exit Try
                    End If
                Next
            End If


            '処理区分：登録
            pSyoriKbn = Enu_SyoriKubun.Insert

            '--------------------------------------------------
            '譲渡元契約者コンボセット
            '--------------------------------------------------
            ret = f_ComboBox_Set(txt_KI.Text.Trim.ToString,
                                 cob_MOTO_KEIYAKUSYA_CD,
                                 cob_MOTO_KEIYAKUSYA_NM)

            '--------------------------------------------------
            '入力項目
            '--------------------------------------------------
            '処理状況　1:入力中 2:入力確定    SYORI_KBN
            rbtn_SYORI_KBN1.Checked = True
            pSaveSyoriKbn = "1"

            '明細クリア
            f_DtlClear()

            '--------------------------------------------------
            '入力制御
            '--------------------------------------------------
            '処理区分：登録
            pSyoriKbn = Enu_SyoriKubun.Insert

            '入力制御
            ret = f_HdEnableCtl(False)
            ret = f_DtlSearchEnableCtl(True, False, True)
            'キャンセルは押下できるようにする
            ret = f_DtlEnableCtl(False, False, True)

            '変更フラグ　クリア
            loblnTextChange = False

            '★初期コントロールにフォーカスセット
            cob_MOTO_KEIYAKUSYA_CD.Focus()

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
        Dim wErr As Boolean = False
        Dim wStr As String = String.Empty

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '処理区分：修正
            pSyoriKbn = Enu_SyoriKubun.Update

            '--------------------------------------------------
            '選択行
            '--------------------------------------------------
            '一覧より選択されていなければエラー
            If dgv_HdSearch.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")       'データが選択されていません。
                Exit Try
            End If

            '選択されている行を見つける
            For Each gRow As DataGridViewRow In dgv_HdSearch.SelectedRows
                pSel_POS = gRow.Index
                Exit For
            Next

            '--------------------------------------------------
            '譲渡元契約者コンボセット
            '--------------------------------------------------
            ret = f_ComboBox_Set(txt_KI.Text.Trim.ToString,
                                 cob_MOTO_KEIYAKUSYA_CD,
                                 cob_MOTO_KEIYAKUSYA_NM)

            '--------------------------------------------------
            '選択された譲渡元契約者
            '--------------------------------------------------
            '選択された譲渡元契約者
            If dgv_HdSearch.Item("MOTO_KEIYAKUSYA_CD", pSel_POS).Value Is DBNull.Value Then
                Show_MessageBox_Add("W012", "契約者") '指定された@0が正しくありません。
                Exit Try
            End If

            '譲渡元契約者の設定
            cob_MOTO_KEIYAKUSYA_CD.SelectedValue = CDec(WordHenkan("N", "Z", dgv_HdSearch.Item("MOTO_KEIYAKUSYA_CD", pSel_POS).Value))

            If cob_MOTO_KEIYAKUSYA_CD.SelectedValue Is Nothing Then
                cob_MOTO_KEIYAKUSYA_CD.SelectedIndex = -1
                Show_MessageBox_Add("W012", "契約者") '指定された@0が正しくありません。
                Exit Try
            End If

            '--------------------------------------------------
            'グリッドセット
            '--------------------------------------------------
            If Not f_DtlGrid_Set("C", 0, 0) Then
                Exit Try
            End If

            '--------------------------------------------------
            '譲渡年月・入力確認有無
            '--------------------------------------------------
            '契約年月日From
            wStr = WordHenkan("N", "S", dgv_HdSearch.Item("KEIYAKU_DATE_FROM", pSel_POS).Value)
            If wStr = "" Then
                date_KEIYAKU_DATE_FROM.Value = Nothing
                pSaveKeiyakuDateFrom = Nothing
            Else
                date_KEIYAKU_DATE_FROM.Value = CDate(wStr)
                pSaveKeiyakuDateFrom = CDate(wStr)
            End If

            '処理状況　1:入力中 2:入力確定
            wStr = WordHenkan("N", "S", dgv_HdSearch.Item("SYORI_KBN", pSel_POS).Value)
            If wStr = "1" Then
                rbtn_SYORI_KBN1.Checked = True
                pSaveSyoriKbn = "1"
            Else
                rbtn_SYORI_KBN2.Checked = True
                pSaveSyoriKbn = "2"
            End If

            '請求区分
            If WordHenkan("N", "S", dgv_HdSearch.Item("SEIKYU_KAISU", pSel_POS).Value) = "" Then
                lbl_SEIKYU_KBN_NM.Text = ""
                wErr = False
            Else
                '明細の入力不可、通知書出力は可能
                ret = f_HdEnableCtl(True)
                ret = f_DtlSearchEnableCtl(False, True, False)
                'キャンセルボタンは押下可能
                ret = f_DtlEnableCtl(False, wErr, True)
                '請求済み            
                '2018/07/09　修正開始
                'lbl_SEIKYU_KBN_NM.Text = "請求書発行済"
                'Show_MessageBox_Add("I007", "請求済みのデータは変更できません。")
                lbl_SEIKYU_KBN_NM.Text = "通知書発行済"
                Show_MessageBox_Add("I007", "通知書発行済みのデータは変更できません。")
                '2018/07/09　修正終了
                wErr = True
                '変更フラグ　クリア
                loblnTextChange = False
                Exit Try
            End If

            '--------------------------------------------------
            '入力制御
            '--------------------------------------------------
            ret = f_HdEnableCtl(False)
            ret = f_DtlSearchEnableCtl(False, True, False)
            ret = f_DtlEnableCtl(True, wErr, True)


            '変更フラグ　クリア
            loblnTextChange = False

            '★初期コントロールにフォーカスセット
            date_KEIYAKU_DATE_FROM.Focus()

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
        Dim wDel_KEIYAKU_MOTO_CD As Integer = 0

        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '一覧より選択されていなければエラー
            If dgv_HdSearch.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")
                Exit Try
            End If

            '該当データ取得
            For Each gRow As DataGridViewRow In dgv_HdSearch.SelectedRows
                pSel_POS = gRow.Index
            Next

            '処理区分：削除
            pSyoriKbn = Enu_SyoriKubun.Delete

            '削除ボタン押下時のチェック
            If Not f_Input_Check_CmdDel() Then
                Exit Try
            End If

            '削除処理確認
            If Show_MessageBox_Add("Q006", "指定されたデータ") = DialogResult.No Then    '指定されたデータを削除します。よろしいですか？
                Exit Try
            End If

            'キー項目
            wDel_KEIYAKU_DATE = CDate(WordHenkan("N", "S", dgv_HdSearch.Item("KEIYAKU_DATE_FROM", pSel_POS).Value))
            wDel_KEIYAKU_MOTO_CD = CInt(WordHenkan("N", "Z", dgv_HdSearch.Item("MOTO_KEIYAKUSYA_CD", pSel_POS).Value))

            '該当データ削除処理
            If Not f_Data_Deleate() Then
                Exit Try
            End If

            'グリッド　再表示
            f_HdGrid_Set("", wDel_KEIYAKU_DATE, wDel_KEIYAKU_MOTO_CD)

            '入力制御
            ret = f_HdEnableCtl(True)
            ret = f_DtlSearchEnableCtl(False, False, False)
            ret = f_DtlEnableCtl(False, False, False)

            '画面入力内容変更フラグクリア
            loblnTextChange = False

            '★初期コントロールにフォーカスセット
            dgv_HdSearch.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdDtlSearch_Click データ部検索ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdDtlSearch_Click
    '説明            :ヘッダ部検索ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdDtlSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDtlSearch.Click
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '入力制御
            pSyoriKbn = Enu_SyoriKubun.Insert

            '画面入力チェック
            If Not f_Input_Check_DtlSearch() Then
                Exit Try
            End If

            'SQL作成
            If Not f_DtlGrid_Set("C", 0, 0) Then
                Exit Try
            End If

            'データなし
            If dgv_DtlSearch.Rows.Count = 0 Then
                '該当データなし
                Show_MessageBox_Add("I007", "譲渡可能なデータが存在しません。")
                Exit Try
            End If

            ret = f_DtlSearchEnableCtl(False, False, True)
            ret = f_DtlEnableCtl(True, False, False)

            '変更フラグ　クリア
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

#Region "cmdDtlSearchClr_Click データ部クリアボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdDtlSearchClr_Click
    '説明            :ヘッダ部クリアボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdDtlSearchClr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDtlSearchClr.Click
        Dim ret As Boolean

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '明細クリアつかえ
            ret = f_DtlClear()

            '入力制御
            ret = f_DtlSearchEnableCtl(True, False, True)
            'キャンセルは押下できるようにする
            ret = f_DtlEnableCtl(False, False, True)
            cmdCansel.Enabled = True

            'データ区分にフォーカスセット
            cob_MOTO_KEIYAKUSYA_CD.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region

#Region "cmdAllChk_Click 全選択ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSav_Click
    '説明            :全選択ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdAllChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllChk.Click

        f_All_Chk(True)

    End Sub
#End Region

#Region "cmdNoChk_Click 全解除ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSav_Click
    '説明            :全解除ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdNoChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNoChk.Click

        f_All_Chk(False)
    End Sub
#End Region

#Region "cmdSav_Click 保存ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSav_Click
    '説明            :保存ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim ret As Boolean = False
        Dim wBool As Boolean = False
        Dim wUpd_MEISAI_NO As Integer = 0
        Dim wUpd_KEIYAKU_DATE As Date = Nothing
        Dim wUpd_KEIYAKU_MOTO_CD As Integer = 0

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



            'キー項目セーブ(明細クリア前にセーブ)
            wUpd_KEIYAKU_DATE = f_DateTrim(date_KEIYAKU_DATE_FROM.Value)
            wUpd_KEIYAKU_MOTO_CD = cob_MOTO_KEIYAKUSYA_CD.Text.Trim

            'グリッド　再表示
            f_HdGrid_Set("", wUpd_KEIYAKU_DATE, wUpd_KEIYAKU_MOTO_CD)

            '明細クリア
            wBool = f_DtlClear()

            '入出力制御
            wBool = f_HdEnableCtl(True)
            wBool = f_DtlSearchEnableCtl(False, False, False)
            wBool = f_DtlEnableCtl(False, False, False)
            dgv_HdSearch.Focus()

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
    Private Sub cmdCansel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCansel.Click
        Dim ret As Boolean = False

        Try

            If loblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then
                    Exit Sub
                End If
            End If

            '画面クリア
            f_DtlClear()
            If dgv_HdSearch.Rows.Count = 0 Then
                pSyoriKbn = Enu_SyoriKubun.Insert
            Else
                pSyoriKbn = Enu_SyoriKubun.Update
            End If

            '入力制御
            ret = f_HdEnableCtl(True)
            ret = f_DtlSearchEnableCtl(False, False, False)
            ret = f_DtlEnableCtl(False, False, False)

            '変更フラグクリア
            loblnTextChange = False

            '★初期コントロールにフォーカスセット
            dgv_HdSearch.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try


    End Sub
#End Region

#Region "cmdSeikyu_Click 通知書発行ボタンクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSeikyu_Click
    '説明            :通知書発行ボタンクリック時処理
    '------------------------------------------------------------------
    Private Sub cmdSeikyu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeikyu.Click
        Dim wUpd_KEIYAKU_DATE As Date = Nothing
        Dim wUpd_KEIYAKU_SAKI_CD As Integer = 0

        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '一覧より選択されていなければエラー
            If dgv_HdSearch.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")       'データが選択されていません。
                Exit Try
            End If

            If loblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox_Add("I007", "データが変更されましたが、保存されていません") Then
                    Exit Try
                End If
            End If

            '選択されている行を見つける
            For Each gRow As DataGridViewRow In dgv_HdSearch.SelectedRows
                pSel_POS = gRow.Index
                Exit For
            Next

            'キー項目セーブ
            wUpd_KEIYAKU_DATE = WordHenkan("N", "S", dgv_HdSearch.Item("KEIYAKU_DATE_FROM", pSel_POS).Value)
            wUpd_KEIYAKU_SAKI_CD = WordHenkan("N", "Z", dgv_HdSearch.Item("MOTO_KEIYAKUSYA_CD", pSel_POS).Value)

            '通知書発行画面
            If Not f_SeikyuSyori() Then
                Exit Try
            End If

            'ヘッダ部グリッド　再表示
            f_HdGrid_Set("", wUpd_KEIYAKU_DATE, wUpd_KEIYAKU_SAKI_CD)
            dgv_HdSearch.Refresh()
            '明細クリア
            f_DtlClear()

            '入力制御
            ret = f_HdEnableCtl(True)
            ret = f_DtlSearchEnableCtl(False, False, False)
            ret = f_DtlEnableCtl(False, False, False)

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
    Private Sub txt_KI_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txt_KI.Enter

        pEnterKi = txt_KI.Text

    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :txt_KI_Validated
    '説明            :期Validatedベント
    '------------------------------------------------------------------
    Private Sub txt_KI_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles txt_KI.Validated
        Dim ret As Boolean = False

        Try

            '未入力のとき、契約者コンボクリア
            If txt_KI.Text = "" Then
                cob_SAKI_KEIYAKUSYA_CD.DataSource = Nothing
                cob_SAKI_KEIYAKUSYA_CD.Clear()
                cob_SAKI_KEIYAKUSYA_NM.DataSource = Nothing
                cob_SAKI_KEIYAKUSYA_NM.Clear()
                Exit Try
            End If

            '期が変更になった場合、譲渡先契約者コンボ再セット
            ret = f_ComboBox_Set(txt_KI.Text.Trim.ToString,
                                 cob_SAKI_KEIYAKUSYA_CD,
                                 cob_SAKI_KEIYAKUSYA_NM)

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#Region "契約者(譲渡先)"
    '------------------------------------------------------------------
    'プロシージャ名  :cob_SAKI_KEIYAKUSYA_CD_SelectedIndexChanged
    '説明            :契約者コードChanegeイベント
    '------------------------------------------------------------------
    Private Sub cob_SAKI_KEIYAKUSYA_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_SAKI_KEIYAKUSYA_CD.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_SAKI_KEIYAKUSYA_NM.SelectedIndex = cob_SAKI_KEIYAKUSYA_CD.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_SAKI_KEIYAKUSYA_NM_SelectedIndexChanged
    '説明            :契約者名Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cob_SAKI_KEIYAKUSYA_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_SAKI_KEIYAKUSYA_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_SAKI_KEIYAKUSYA_CD.SelectedIndex = cob_SAKI_KEIYAKUSYA_NM.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_SAKI_KEIYAKUSYA_CD_Validating
    '説明            :契約者コード_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cob_SAKI_KEIYAKUSYA_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_SAKI_KEIYAKUSYA_CD.Validating
        Dim ret As Boolean = False

        Try

            If cob_SAKI_KEIYAKUSYA_CD.Text = "" Then
                lbl_SAKI_KEIYAKU_KBN.Text = ""
                Exit Try
            End If

            '値の設定方法
            cob_SAKI_KEIYAKUSYA_CD.SelectedValue = CDec(cob_SAKI_KEIYAKUSYA_CD.Text)

            If cob_SAKI_KEIYAKUSYA_CD.SelectedValue Is Nothing Then
                cob_SAKI_KEIYAKUSYA_CD.SelectedIndex = -1
                cob_SAKI_KEIYAKUSYA_NM.SelectedIndex = -1
                Show_MessageBox_Add("W012", "契約者") '指定された@0が正しくありません。

                lbl_SAKI_KEIYAKU_KBN.Text = ""
                cob_SAKI_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#Region "契約者(譲渡元)"
    '------------------------------------------------------------------
    'プロシージャ名  :cob_MOTO_KEIYAKUSYA_CD_SelectedIndexChanged
    '説明            :契約者コードChanegeイベント
    '------------------------------------------------------------------
    Private Sub cob_MOTO_KEIYAKUSYA_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_MOTO_KEIYAKUSYA_CD.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_MOTO_KEIYAKUSYA_NM.SelectedIndex = cob_MOTO_KEIYAKUSYA_CD.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_MOTO_KEIYAKUSYA_NM_SelectedIndexChanged
    '説明            :契約者名Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cob_MOTO_KEIYAKUSYA_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_MOTO_KEIYAKUSYA_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_MOTO_KEIYAKUSYA_CD.SelectedIndex = cob_MOTO_KEIYAKUSYA_NM.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_MOTO_KEIYAKUSYA_CD_Validating
    '説明            :契約者コード_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cob_MOTO_KEIYAKUSYA_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_MOTO_KEIYAKUSYA_CD.Validating
        Dim ret As Boolean = False

        Try

            If cob_MOTO_KEIYAKUSYA_CD.Text = "" Then
                lbl_MOTO_KEIYAKU_KBN.Text = ""
                Exit Try
            End If

            '値の設定方法
            cob_MOTO_KEIYAKUSYA_CD.SelectedValue = CDec(cob_MOTO_KEIYAKUSYA_CD.Text)

            If cob_MOTO_KEIYAKUSYA_CD.SelectedValue Is Nothing Then
                cob_MOTO_KEIYAKUSYA_CD.SelectedIndex = -1
                cob_MOTO_KEIYAKUSYA_NM.SelectedIndex = -1
                Show_MessageBox_Add("W012", "契約者") '指定された@0が正しくありません。
                lbl_MOTO_KEIYAKU_KBN.Text = ""
                cob_MOTO_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If

            '契約マスタ．契約区分取得
            'If Not f_KeiyakuSaki_Data() Then
            '    cob_MOTO_KEIYAKUSYA_CD.Focus()
            'End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_MOTO_KEIYAKUSYA_NM_Validating
    '説明            :契約者コード_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cob_MOTO_KEIYAKUSYA_NM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_MOTO_KEIYAKUSYA_NM.Validating
        Dim ret As Boolean = False

        Try

            If cob_MOTO_KEIYAKUSYA_CD.Text = "" Then
                lbl_MOTO_KEIYAKU_KBN.Text = ""
            Else
                '契約マスタ．契約区分取得
                'If Not f_KeiyakuSaki_Data() Then
                '    cob_MOTO_KEIYAKUSYA_NM.Focus()
                'End If
            End If

        Catch ex As Exception

            '共通例外処理
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
        '配列
        Dim wIdx As Integer = 0
        Dim intNojoCd() As Integer = Nothing        '農場コード
        Dim intToriKbn() As Integer = Nothing       '鶏の種類
        Dim intKeiyakuHasu() As Integer = Nothing   '契約羽数
        Dim intMotoSeqNo() As Integer = Nothing     '鶏の種類
        Dim strKeihiCd_FubiCd() As String = Nothing

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            If pSyoriKbn = Enu_SyoriKubun.Insert Then
                Cmd.CommandText = "PKG_GJ3030.GJ3030_JOTO_INS"
            Else
                Cmd.CommandText = "PKG_GJ3030.GJ3030_JOTO_UPD"
            End If

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", txt_KI.Text.Trim)

            '契約者番号(譲渡先)
            Dim paraSAKI_KEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_SAKI_KEIYAKUSYA_CD", cob_SAKI_KEIYAKUSYA_CD.Text.Trim)

            '契約年月日From  
            If date_KEIYAKU_DATE_FROM.Value Is Nothing OrElse date_KEIYAKU_DATE_FROM.Value = New Date Then
                Cmd.Parameters.Add("KEIYAKU_DATE_FROM", DBNull.Value)
            Else
                Cmd.Parameters.Add("KEIYAKU_DATE_FROM", f_DateTrim(date_KEIYAKU_DATE_FROM.Value))
            End If

            '契約年月日To 
            Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", pJIGYO_SYURYO_DATE)

            '契約者番号(譲渡元)
            Dim paraMOTO_KEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_MOTO_KEIYAKUSYA_CD", cob_MOTO_KEIYAKUSYA_CD.Text.Trim)

            '契約区分(譲渡先)
            Dim paraSAKI_KEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_SAKI_KEIYAKU_KBN", lbl_SAKI_KEIYAKU_KBN.Text.Trim)
            '契約区分(譲渡元)
            Dim paraMOTO_KEIYAKU_KBN As OracleParameter = Cmd.Parameters.Add("IN_MOTO_KEIYAKU_KBN", lbl_MOTO_KEIYAKU_KBN.Text.Trim) '2018/07/03　追加

            '処理状況　1:入力中 2:入力確定
            If rbtn_SYORI_KBN1.Checked Then
                Cmd.Parameters.Add("IN_SYORI_KBN", 1)
            Else
                Cmd.Parameters.Add("IN_SYORI_KBN", 2)
            End If

            If pSyoriKbn = Enu_SyoriKubun.Update Then
                '契約開始日
                If IsNothing(pSaveKeiyakuDateFrom) Then
                    Cmd.Parameters.Add("IN_OLD_KEIYAKU_DATE_FROM", DBNull.Value)
                Else
                    Cmd.Parameters.Add("IN_OLD_KEIYAKU_DATE_FROM", pSaveKeiyakuDateFrom)
                End If
            End If

            '--------------------------------------------------
            '   配列
            '--------------------------------------------------
            wIdx = pChk_Cnt - 1
            ReDim intNojoCd(wIdx)
            ReDim intToriKbn(wIdx)
            ReDim intKeiyakuHasu(wIdx)
            ReDim intMotoSeqNo(wIdx)

            '配列作成
            wIdx = 0
            For i = 0 To dgv_DtlSearch.Rows.Count - 1
                If WordHenkan("N", "Z", dgv_DtlSearch.Item("CHK", i).Value) = "1" Then
                    intNojoCd(wIdx) = WordHenkan("N", "Z", dgv_DtlSearch.Item("MOTO_NOJO_CD", i).Value)
                    intToriKbn(wIdx) = WordHenkan("N", "Z", dgv_DtlSearch.Item("TORI_KBN", i).Value)
                    intKeiyakuHasu(wIdx) = WordHenkan("N", "Z", dgv_DtlSearch.Item("KEIYAKU_HASU", i).Value)
                    intMotoSeqNo(wIdx) = WordHenkan("N", "Z", dgv_DtlSearch.Item("MOTO_SEQNO", i).Value)
                    wIdx += 1
                End If
            Next

            '農場(譲渡元)
            Dim parNojoCd As New OracleParameter
            With parNojoCd
                .OracleDbType = OracleDbType.Int32   '数値
                .Direction = ParameterDirection.Input
                .CollectionType = OracleCollectionType.PLSQLAssociativeArray '数値配列
                .Value = intNojoCd
                .Size = intNojoCd.Length
            End With
            '鶏の種類
            Dim parToriKbn As New OracleParameter
            With parToriKbn
                .OracleDbType = OracleDbType.Int16   '数値
                .Direction = ParameterDirection.Input
                .CollectionType = OracleCollectionType.PLSQLAssociativeArray '数値配列
                .Value = intToriKbn
                .Size = intToriKbn.Length
            End With
            '契約羽数
            Dim parKeiyakuHasu As New OracleParameter
            With parKeiyakuHasu
                .OracleDbType = OracleDbType.Int32   '数値
                .Direction = ParameterDirection.Input
                .CollectionType = OracleCollectionType.PLSQLAssociativeArray '数値配列
                .Value = intKeiyakuHasu
                .Size = intKeiyakuHasu.Length
            End With
            'SEQNO
            Dim parMotoSeqNo As New OracleParameter
            With parMotoSeqNo
                .OracleDbType = OracleDbType.Int32   '数値
                .Direction = ParameterDirection.Input
                .CollectionType = OracleCollectionType.PLSQLAssociativeArray '数値配列
                .Value = intMotoSeqNo
                .Size = intMotoSeqNo.Length
            End With

            Cmd.Parameters.Add(parNojoCd)       '農場(譲渡元)
            Cmd.Parameters.Add(parToriKbn)      '鶏の種類
            Cmd.Parameters.Add(parKeiyakuHasu)  '契約羽数
            Cmd.Parameters.Add(parMotoSeqNo)    'SEQNO

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
    Private Function f_Data_Deleate() As Boolean
        Dim ret As Boolean = False
        Dim wStr As String = String.Empty
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ3030.GJ3030_JOTO_DEL"

            '引き渡し

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", txt_KI.Text.Trim)

            '契約者番号 県コード＋連番３桁    
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_SAKI_KEIYAKUSYA_CD", cob_SAKI_KEIYAKUSYA_CD.Text.Trim)

            '契約年月日From  
            wStr = WordHenkan("N", "S", dgv_HdSearch.Item("KEIYAKU_DATE_FROM", pSel_POS).Value)
            If wStr = "" Then
                Cmd.Parameters.Add("KEIYAKU_DATE_FROM", DBNull.Value)
            Else
                Cmd.Parameters.Add("KEIYAKU_DATE_FROM", CDate(wStr))
            End If

            '契約年月日To 
            Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", pJIGYO_SYURYO_DATE)

            '契約者番号(譲渡元)
            Dim paraMOTO_KEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_MOTO_KEIYAKUSYA_CD", dgv_HdSearch.Item("MOTO_KEIYAKUSYA_CD", pSel_POS).Value)

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
                Case TypeOf wkCtrl Is JBD.Gjs.Win.DataGridView
                    AddHandler DirectCast(wkCtrl, DataGridView).CellValueChanged, AddressOf f_setChanged
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
        Dim ret As Boolean = False

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
            pHdDataSet.Clear()
            pDtlDataSet.Clear()

            'コンボボックスセット(譲渡先契約者)
            ret = f_ComboBox_Set(pInitKi.ToString,
                                 cob_SAKI_KEIYAKUSYA_CD,
                                 cob_SAKI_KEIYAKUSYA_NM)

            'ラベルクリア
            txt_KI.Text = pInitKi
            lblCOUNT.Text = ""

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
#Region "f_ComboBox_Set コンボボックスセット処理(契約者)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ComboBox_Set
    '説明            :コンボボックスセット処理(契約者)
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ComboBox_Set(ByVal wKi As String,
                                    ByRef wKeiyakusyaCd As JBD.Gjs.Win.GcComboBox,
                                    ByRef wKeiyakusyaNm As JBD.Gjs.Win.GcComboBox) As Boolean
        Dim ret As Boolean = False
        Dim wWhere As String = String.Empty

        Try

            '期が未入力のとき
            If wKi = "" OrElse wKi = String.Empty Then
                '譲渡先
                wKeiyakusyaCd.DataSource = Nothing
                wKeiyakusyaCd.Clear()
                wKeiyakusyaNm.DataSource = Nothing
                wKeiyakusyaNm.Clear()
                Exit Try
            End If

            '契約者マスタコンボセット(期:画面の期　契約状況:3(未継続者)除く)
            wWhere = "KI = " & wKi & " AND KEIYAKU_JYOKYO <> 3 "
            pJump = True
            If Not f_Keiyaku_Data_Select(wKeiyakusyaCd, wKeiyakusyaNm, wWhere, True) Then
                Exit Try
            End If
            pJump = False

            'コンボボックス初期化
            wKeiyakusyaCd.Text = ""

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_HdGrid_Set ヘッダ部グリッド表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ヘッダ部グリッド表示処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_HdGrid_Set(ByVal wKbn As String,
                                  ByVal wKeiyakuDate As Date,
                                  ByVal wKeiyakuMotoCd As Integer) As Boolean
        Dim ret As Boolean = False
        Dim bol As Boolean = False
        Dim wSql As String = String.Empty

        Try

            'グリッドが入力不可の場合、スクロールバーが連動しないので、グリッドを入力可能にする
            dgv_HdSearch.Enabled = True

            '--------------------------------------------------
            '   グリッド
            '--------------------------------------------------
            'データセット　クリア
            If Not pHdDataSet Is Nothing Then
                pHdDataSet.Clear()
            End If

            'グリッド用ＳＱＬ　作成
            wSql = ""
            If Not f_HdSearch_SQLMake(wSql) Then
                Exit Try
            End If

            'ＳＱＬ実行
            If Not f_Select_ODP(pHdDataSet, wSql) Then
                Exit Try
            End If

            'グリッドセット
            dgv_HdSearch.DataSource = pHdDataSet.Tables(0)
            lblCOUNT.Text = pHdDataSet.Tables(0).Rows.Count.ToString("#,##0")

            '--------------------------------------------------
            '   グリッド表示位置
            '--------------------------------------------------
            If pHdDataSet.Tables(0).Rows.Count > 0 AndAlso wKbn = "" Then
                bol = f_HdGridReDisp(wKeiyakuDate, wKeiyakuMotoCd)
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_Search_SQLMake ヘッダ部グリッド用SQL作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ヘッダ部グリッド用SQL作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_HdSearch_SQLMake(ByRef wSql As String) As Boolean
        Dim ret As Boolean = False

        Try
            wSql = "SELECT"
            wSql &= "  TO_CHAR(RIR.KEIYAKU_DATE_FROM, 'EEYY""/""MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') KEIYAKU_DATE_FROM_X,"
            wSql &= "  RIR.KEIYAKU_DATE_FROM,"
            wSql &= "  RIR.MOTO_KEIYAKUSYA_CD,"
            wSql &= "  KYK.KEIYAKUSYA_NAME,"
            wSql &= "  RIR.SYORI_KBN,"
            wSql &= "  M12.MEISYO SYORI_KBN_NM,"
            wSql &= "  RIR.SEIKYU_KAISU "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOTO_RIREKI RIR,"
            wSql &= "  TM_KEIYAKU KYK,"
            wSql &= "  TM_CODE M12 "
            wSql &= "WHERE RIR.KI = " & txt_KI.Text.Trim
            wSql &= "  AND RIR.KEIYAKUSYA_CD = " & cob_SAKI_KEIYAKUSYA_CD.Text.Trim
            wSql &= "  AND RIR.KI = KYK.KI(+)"
            'wSql &= "  AND RIR.KEIYAKUSYA_CD = KYK.KEIYAKUSYA_CD(+)"       '2016/05/11　修正
            wSql &= "  AND RIR.MOTO_KEIYAKUSYA_CD = KYK.KEIYAKUSYA_CD(+)"   '2016/05/11　修正
            wSql &= "  AND 12 = M12.SYURUI_KBN(+)"
            wSql &= "  AND RIR.SYORI_KBN = M12.MEISYO_CD(+) "
            'ソート順はf_GridReDispと同一にする
            wSql &= "ORDER BY "
            wSql &= "  RIR.KEIYAKU_DATE_FROM DESC, MOTO_KEIYAKUSYA_CD ASC"

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_HdGridReDisp ヘッダ部グリッド再表示"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridReDisp
    '説明            :ヘッダ部グリッド再表示
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_HdGridReDisp(ByVal wKEIYAKU_DATE As Date, ByVal wMOTO_KEIYAKUSYA_CD As Integer) As Boolean
        Dim ret As Boolean = False
        Dim blnHit As Boolean = False

        Try
            If dgv_HdSearch.RowCount <> 0 Then

                '更新対象のデータ　または　その次のデータに、カーソルをせっと
                For i As Integer = 0 To dgv_HdSearch.RowCount - 1
                    '契約日(降順)　ブレーク
                    If f_DateTrim(WordHenkan("N", "Z", dgv_HdSearch.Item("KEIYAKU_DATE_FROM", i).Value)) < f_DateTrim(wKEIYAKU_DATE) Then
                        '現在セル　セット
                        dgv_HdSearch.CurrentCell = dgv_HdSearch(0, i)
                        blnHit = True
                        Exit For
                    Else
                        '譲渡元契約者 ブレーク
                        If CInt(WordHenkan("N", "Z", dgv_HdSearch.Item("MOTO_KEIYAKUSYA_CD", i).Value)) >= wMOTO_KEIYAKUSYA_CD Then
                            '鶏種類　ブレーク
                            dgv_HdSearch.CurrentCell = dgv_HdSearch(0, i)
                            blnHit = True
                            Exit For
                        End If
                    End If
                Next

                '最後まで該当データがなかった場合、最終行
                If Not blnHit Then
                    dgv_HdSearch.CurrentCell = dgv_HdSearch(0, dgv_HdSearch.RowCount - 1)
                End If

            End If

            ret = True

        Catch ex As Exception
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_DtlGrid_Set データ部グリッド表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :グリッドグリッド表示処理
    '引数            :I:新規登録　U:変更
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_DtlGrid_Set(ByVal wKbn As String,
                                   ByVal wNojoCd As Integer,
                                   ByVal wToriKbn As Integer) As Boolean
        Dim ret As Boolean = False
        Dim bol As Boolean = False
        Dim wSql As String = String.Empty

        Try

            'グリッドが入力不可の場合、スクロールバーが連動しないので、グリッドを入力可能にする
            dgv_DtlSearch.Enabled = True

            '明細クリア
            If wKbn <> "C" Then
                bol = f_DtlClear()
            End If

            '--------------------------------------------------
            '   グリッド
            '--------------------------------------------------
            'データセット　クリア
            If Not pDtlDataSet Is Nothing Then
                pDtlDataSet.Clear()
            End If

            'グリッド用ＳＱＬ　作成
            wSql = ""
            If Not f_DtlSearch_SQLMake(wSql) Then
                Exit Try
            End If

            'ＳＱＬ実行
            If Not f_Select_ODP(pDtlDataSet, wSql) Then
                Exit Try
            End If

            'グリッドセット
            dgv_DtlSearch.DataSource = pDtlDataSet.Tables(0)
            If dgv_DtlSearch.Rows.Count > 0 Then
                lbl_MOTO_KEIYAKU_KBN.Text = dgv_DtlSearch.Item("KEIYAKU_KBN_MOTO", 0).Value
            End If

            '--------------------------------------------------
            '   グリッド表示位置
            '--------------------------------------------------
            If wKbn = "" Then
                bol = f_DtlGridReDisp(wNojoCd, wToriKbn)
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_DtlSearch_SQLMake データ部グリッド用SQL作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :データ部グリッド用SQL作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_DtlSearch_SQLMake(ByRef wSql As String) As Boolean
        Dim ret As Boolean = False

        Try
            wSql = "SELECT"
            wSql &= "  CASE WHEN RDT.KEIYAKUSYA_CD IS NULL THEN 0 ELSE 1 END CHK,"
            wSql &= "  JOH.NOJO_CD   MOTO_NOJO_CD,"
            wSql &= "  NOJ.NOJO_NAME MOTO_NOJO_NM,"
            wSql &= "  ADDR_1 || ADDR_2 || ADDR_3 || ADDR_4 MOTO_NOJO_ADDR,"
            wSql &= "  JOH.TORI_KBN,"
            wSql &= "  M07.MEISYO TORI_KBN_NM,"
            wSql &= "  JOH.KEIYAKU_HASU,"
            wSql &= "  JOH.SEQNO MOTO_SEQNO,"
            wSql &= "  JOH.KEIYAKU_KBN KEIYAKU_KBN_MOTO "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO JOH,"
            wSql &= "  TT_KEIYAKU_JOTO_MEISAI_RIREKI RDT,"
            wSql &= "  TM_KEIYAKU_NOJO NOJ,"
            wSql &= "  TT_TUMITATE TUM," '2021/07/13 JBD9020 新契約日追加 ADD
            wSql &= "  TM_CODE M07 "
            wSql &= "WHERE JOH.KI  = " & txt_KI.Text.Trim
            wSql &= "  AND JOH.KEIYAKUSYA_CD = " & cob_MOTO_KEIYAKUSYA_CD.Text.Trim
            '--履歴明細
            wSql &= "  AND JOH.KI = RDT.KI(+)"
            wSql &= "  AND " & cob_SAKI_KEIYAKUSYA_CD.Text.Trim & " = RDT.KEIYAKUSYA_CD(+)"
            If pSyoriKbn = Enu_SyoriKubun.Update Then
                wSql &= "  AND TO_DATE('" & Format(dgv_HdSearch.Item("KEIYAKU_DATE_FROM", pSel_POS).Value, "yyyy/MM/dd") & "') = RDT.KEIYAKU_DATE_FROM(+)"
            End If
            wSql &= "  AND JOH.KEIYAKUSYA_CD = RDT.MOTO_KEIYAKUSYA_CD(+)"
            wSql &= "  AND JOH.NOJO_CD = RDT.MOTO_NOJO_CD(+)"
            wSql &= "  AND JOH.TORI_KBN = RDT.TORI_KBN(+)"
            '--契約農場"
            wSql &= "  AND JOH.KI = NOJ.KI(+)"
            wSql &= "  AND JOH.KEIYAKUSYA_CD =NOJ.KEIYAKUSYA_CD(+)"
            wSql &= "  AND JOH.NOJO_CD = NOJ.NOJO_CD(+)"
            '2021/07/13 JBD9020 新契約日追加 ADD START
            '--積立金
            wSql &= "  AND JOH.KI = TUM.KI(+)"
            wSql &= "  AND JOH.KEIYAKUSYA_CD =TUM.KEIYAKUSYA_CD(+)"
            wSql &= "  AND JOH.SEIKYU_KAISU = TUM.SEIKYU_KAISU(+)"
            '2021/07/13 JBD9020 新契約日追加 ADD END
            '--コードマスタ(鶏の種類)"
            wSql &= "  AND 7 = M07.SYURUI_KBN(+)"
            wSql &= "  AND JOH.TORI_KBN = M07.MEISYO_CD(+) "
            '--未請求と請求済み
            If pSyoriKbn = Enu_SyoriKubun.Insert Then
                '請求前はデータ区分1のみ
                wSql &= "  AND JOH.DATA_FLG  = 1 "
            Else
                '請求後はデータ区分1　または　履歴あり
                wSql &= "  AND (JOH.DATA_FLG  = 1 OR RDT.MOTO_SEQNO = JOH.SEQNO) "
            End If
            '2022/10/11 JBD9020 UPD START
            'wSql &= "  AND TUM.SYORI_JOKYO_KBN  = 3 " '2021/07/13 JBD9020 新契約日追加 ADD 
            wSql &= "  AND (TUM.SYORI_JOKYO_KBN  = 3 OR JOH.KEIYAKU_HENKO_KBN  = 9)"
            '2022/10/11 JBD9020 UPD END
            'ソート順はf_GridReDispと同一にする
            wSql &= "ORDER BY "
            wSql &= "  JOH.NOJO_CD, JOH.TORI_KBN"

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_DtlGridReDisp データ部グリッド再表示"
    '------------------------------------------------------------------
    'プロシージャ名  :f_DtlGridReDisp
    '説明            :データ部グリッド再表示
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_DtlGridReDisp(ByVal wNOJO_CD As Integer, ByVal TORI_KBN As Integer) As Boolean
        Dim ret As Boolean = False
        Dim blnHit As Boolean = False

        Try
            If dgv_DtlSearch.RowCount <> 0 Then

                '更新対象のデータ　または　その次のデータに、カーソルをせっと
                For i As Integer = 0 To dgv_DtlSearch.RowCount - 1
                    '農場　ブレーク
                    If CInt(WordHenkan("N", "Z", dgv_DtlSearch.Item("MOTO_NOJO_CD", i).Value)) < CInt(wNOJO_CD) Then
                        '現在セル　セット
                        dgv_DtlSearch.CurrentCell = dgv_DtlSearch(0, i)
                        blnHit = True
                        Exit For
                    Else
                        '鶏の種類　ブレーク
                        If CInt(WordHenkan("N", "Z", dgv_DtlSearch.Item("TORI_KBN", i).Value)) >= TORI_KBN Then
                            '鶏種類　ブレーク
                            dgv_DtlSearch.CurrentCell = dgv_DtlSearch(0, i)
                            blnHit = True
                            Exit For
                        End If
                    End If
                Next

                '最後まで該当データがなかった場合、最終行
                If Not blnHit Then
                    dgv_DtlSearch.CurrentCell = dgv_DtlSearch(0, dgv_DtlSearch.RowCount - 1)
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

        Try

            '譲渡元契約者
            cob_MOTO_KEIYAKUSYA_CD.SelectedIndex = -1
            'データ部グリッド
            If Not pDtlDataSet Is Nothing Then
                pDtlDataSet.Clear()
                If pDtlDataSet.Tables.Count <> 0 Then
                    dgv_DtlSearch.DataSource = pDtlDataSet.Tables(0)
                End If
            End If
            '明細
            date_KEIYAKU_DATE_FROM.Value = Nothing
            rbtn_SYORI_KBN1.Checked = True
            lbl_SEIKYU_KBN_NM.Text = ""

            '変更フラグクリア
            loblnTextChange = False

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_All_Chk 全選択・全解除処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_All_Chk
    '説明            :全選択・全解除処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_All_Chk(ByVal wChk As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            For i = 0 To dgv_DtlSearch.Rows.Count - 1
                If wChk Then
                    '選択
                    dgv_DtlSearch.Item("CHK", i).Value = 1
                Else
                    '解除
                    dgv_DtlSearch.Item("CHK", i).Value = 0
                End If
            Next

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_HdSearchEnableCtl 入力制御処理(ヘッダ部検索)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_HdSearchEnableCtl
    '説明            :入力制御処理(検索)
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_HdSearchEnableCtl(ByVal wEnable As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            '検索条件
            txt_KI.Enabled = wEnable
            cob_SAKI_KEIYAKUSYA_CD.Enabled = wEnable
            cob_SAKI_KEIYAKUSYA_NM.Enabled = wEnable
            cmdHdSearch.Enabled = wEnable

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
            dgv_HdSearch.Enabled = wEnable
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
#Region "f_DtlSearchEnableCtl 入力制御処理(明細部検索)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_DtlSearchEnableCtl
    '説明            :入力制御処理(明細部検索)
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_DtlSearchEnableCtl(ByVal wEnable As Boolean, ByVal wLstEnable As Boolean, ByVal wClrEnable As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            '検索条件
            cob_MOTO_KEIYAKUSYA_CD.Enabled = wEnable
            cob_MOTO_KEIYAKUSYA_NM.Enabled = wEnable

            '検索・クリアボタン
            cmdDtlSearch.Enabled = wEnable
            cmdDtlSearchClr.Enabled = wClrEnable

            ''通知書発行の使用　不可
            If dgv_HdSearch.Rows.Count = 0 Then
                cmdSeikyu.Enabled = False
            Else
                cmdSeikyu.Enabled = wLstEnable
            End If

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
    Private Function f_DtlEnableCtl(ByVal wEnable As Boolean, ByVal wErr As Boolean, ByRef wCancelEnable As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            '明細グリッド
            cmdAllChk.Enabled = wEnable
            cmdNoChk.Enabled = wEnable
            dgv_DtlSearch.Enabled = wEnable

            '明細
            If wErr Then
                date_KEIYAKU_DATE_FROM.Enabled = False
                pnl_SYORI_KBN.Enabled = False
                cmdSave.Enabled = False
            Else
                date_KEIYAKU_DATE_FROM.Enabled = wEnable
                pnl_SYORI_KBN.Enabled = wEnable
                cmdSave.Enabled = wEnable
            End If

            '処理区分
            'If pSyoriKbn = Enu_SyoriKubun.Insert Then
            '    '請求書発行の使用　不可
            '    cmdSeikyu.Enabled = False
            'Else
            '    '請求書発行の使用　可能
            '    If wEnable = True Then
            '        cmdSeikyu.Enabled = wEnable
            '    End If
            'End If

            'フッタ
            cmdCansel.Enabled = wCancelEnable

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Input_Check_HdSearch  画面入力チェック処理(ヘッダ部検索)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check_HdSearch
    '説明            :画面入力チェック処理(ヘッダ部検索)
    '引数            :0:保存　1:コピー
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_HdSearch() As Boolean
        Dim ret As Boolean = False
        Dim wKeiyakuKbn As String = String.Empty

        Try

            '==必須チェック================== 

            '期入力なし
            If txt_KI.Text.Trim = "" Then
                Show_MessageBox_Add("W008", "期")
                txt_KI.Focus()
                Exit Try
            End If

            '契約者入力なし
            If cob_SAKI_KEIYAKUSYA_CD.Text.Trim = "" Then
                Show_MessageBox_Add("W008", "契約者(譲渡先)")
                cob_SAKI_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If

            '==FromToチェック==================

            '==いろいろチェック==================

            '--------------------------------------------------
            '譲渡先契約者のチェック
            '--------------------------------------------------
            If Not f_Input_Check_Keiyakusya(CInt(cob_SAKI_KEIYAKUSYA_CD.Text.Trim), wKeiyakuKbn) Then
                Exit Try
            End If

            '契約区分セーブ
            lbl_SAKI_KEIYAKU_KBN.Text = wKeiyakuKbn

            '--------------------------------------------------
            '譲渡先がべつの契約者の譲渡元になっている場合のチェック
            '--------------------------------------------------
            If Not f_SakiKeiyakusya_MiSeikyu() Then
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
#Region "f_SakiKeiyakusya_MiSeikyu  画面入力チェック処理(先契約者の未請求)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_MotoKeiyaku_MiSeikyu
    '説明            :契約者が、他の契約者の譲渡元の場合
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SakiKeiyakusya_MiSeikyu() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty

        Try

            '--------------------------------------------------
            '譲渡先契約者が、他の契約者の譲渡元になっていて
            '請求前のときエラー
            '--------------------------------------------------
            wSql &= "SELECT"
            wSql &= "  SUM(CASE WHEN SEIKYU_KAISU IS NULL THEN 1 ELSE 0 END) MI_SEIKYU_CNT "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOTO_RIREKI "
            wSql &= "WHERE KI = " & txt_KI.Text.Trim
            wSql &= "  AND MOTO_KEIYAKUSYA_CD = " & cob_SAKI_KEIYAKUSYA_CD.Text.Trim

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                cob_SAKI_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count > 0 Then
                '未請求数チェック
                If CInt(WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("MI_SEIKYU_CNT"))) > 0 Then
                    Show_MessageBox_Add("I007", "未請求データが存在するため" & vbCrLf & "選択できません。")
                    cob_SAKI_KEIYAKUSYA_CD.Focus()
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

#Region "f_Input_Check_CmdDel  画面入力チェック処理(削除ボタン)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check_CmdDel
    '説明            :画面入力チェック処理(ボタン)
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_CmdDel() As Boolean
        Dim ret As Boolean = False

        Try

            '請求済み         
            If WordHenkan("N", "S", dgv_HdSearch.Item("SEIKYU_KAISU", pSel_POS).Value) <> "" Then
                Show_MessageBox_Add("I007", "請求済みのデータは削除できません。")
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
#Region "f_Input_Check_Keiyakusya  画面入力チェック処理(新規登録ボタン)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check_Keiyakusya
    '説明            :画面入力チェック処理(新規登録ボタン)
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_Keiyakusya(ByVal wKEIYAKU_CD As Integer, ByRef wKeiyakuKbn As String) As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty

        Try

            '--------------------------------------------------
            '契約日・廃業日　チェック
            '--------------------------------------------------
            wSql &= "SELECT"
            wSql &= "  KEIYAKU_DATE, HAIGYO_DATE, KEIYAKU_KBN "
            wSql &= "  ,NYU_HEN_DATE " '2021/07/13 JBD9020 新契約日追加 ADD 
            wSql &= "FROM"
            wSql &= "  TM_KEIYAKU KYK "
            wSql &= "WHERE KI = " & txt_KI.Text.Trim
            wSql &= "  AND KEIYAKUSYA_CD = " & wKEIYAKU_CD

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                Show_MessageBox_Add("I007", "該当の契約者は登録されていません。")
                Exit Try
            End If

            '契約日チェック
            If wkDS.Tables(0).Rows(0)("KEIYAKU_DATE") Is DBNull.Value Then
                Show_MessageBox_Add("I007", "契約が完了していない契約者です。")
                Exit Try
            End If

            '2021/07/13 JBD9020 新契約日追加 ADD START
            '入金返還日チェック
            If wkDS.Tables(0).Rows(0)("NYU_HEN_DATE") Is DBNull.Value Then
                Show_MessageBox_Add("I007", "契約が完了していない契約者です。")
                Exit Try
            End If
            '2021/07/13 JBD9020 新契約日追加 ADD END

            '廃業日チェック
            If Not (wkDS.Tables(0).Rows(0)("HAIGYO_DATE") Is DBNull.Value) Then
                Show_MessageBox_Add("I007", "廃業されている契約者です。")
                Exit Try
            End If

            '契約区分チェック
            wKeiyakuKbn = WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("KEIYAKU_KBN"))

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region
#Region "f_Input_Check_DtlSearch  画面入力チェック処理(ヘッダ部検索)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check_HdSearch
    '説明            :画面入力チェック処理(ヘッダ部検索)
    '引数            :0:保存　1:コピー
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_DtlSearch() As Boolean
        Dim ret As Boolean = False
        Dim wKeiyakuKbn As String = String.Empty

        Try

            '==必須チェック================== 

            '契約者入力なし
            If cob_MOTO_KEIYAKUSYA_CD.Text.Trim = "" Then
                Show_MessageBox_Add("W008", "契約者(譲渡元)")
                cob_MOTO_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If

            '==FromToチェック==================

            '==いろいろチェック==================

            If cob_MOTO_KEIYAKUSYA_CD.Text.Trim = cob_SAKI_KEIYAKUSYA_CD.Text.Trim Then
                Show_MessageBox_Add("I007", "契約者(譲渡元)と契約者(譲渡先)が同一です。")
                cob_MOTO_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If

            '--------------------------------------------------
            '譲渡元契約者
            '--------------------------------------------------
            If Not f_Input_Check_Keiyakusya(CInt(cob_MOTO_KEIYAKUSYA_CD.Text.Trim), wKeiyakuKbn) Then
                Exit Try
            End If
            '譲渡元の契約区分
            lbl_MOTO_KEIYAKU_KBN.Text = wKeiyakuKbn

            '--------------------------------------------------
            '契約区分のチェック
            '--------------------------------------------------
            Select Case wKeiyakuKbn
                Case "1"
                    '家族→うずら
                    If lbl_SAKI_KEIYAKU_KBN.Text = "3" Then
                        'Call Show_MessageBox_Add("I007", "家族型からうずら型への譲渡はできません。")   '@0    '2018/07/03　修正
                        Call Show_MessageBox_Add("I007", "家族型から鶏以外への譲渡はできません。")      '@0    '2018/07/03　修正
                        date_KEIYAKU_DATE_FROM.Focus()
                        Exit Try
                    End If
                Case "2"
                    '2018/07/03　削除開始
                    ''企業→家族
                    'If lbl_SAKI_KEIYAKU_KBN.Text = "1" Then
                    '    Call Show_MessageBox_Add("I007", "企業型から家族型への譲渡はできません。")     '@0
                    '    date_KEIYAKU_DATE_FROM.Focus()
                    '    Exit Try
                    'End If
                    '2018/07/03　削除終了
                    '企業→うずら
                    If lbl_SAKI_KEIYAKU_KBN.Text = "3" Then
                        '2017/09/08 修正開始
                        'Call Show_MessageBox_Add("I007", "企業型からうずら型への譲渡はできません。")    '@0
                        Call Show_MessageBox_Add("I007", "企業型から鶏以外への譲渡はできません。")    '@0
                        '2017/09/08 修正終了
                        date_KEIYAKU_DATE_FROM.Focus()
                        Exit Try
                    End If
                Case "3"
                    'うずら→家族
                    If lbl_SAKI_KEIYAKU_KBN.Text = "1" Then
                        '2017/09/08 修正開始
                        'Call Show_MessageBox_Add("I007", "うずら型から企業型への譲渡はできません。")    '@0
                        Call Show_MessageBox_Add("I007", "鶏以外から家族型への譲渡はできません。")    '@0
                        '2017/09/08 修正終了
                        date_KEIYAKU_DATE_FROM.Focus()
                        Exit Try
                    End If
                    'うずら→企業
                    If lbl_SAKI_KEIYAKU_KBN.Text = "2" Then
                        '2017/09/08 修正開始
                        'Call Show_MessageBox_Add("I007", "うずら型から企業型への譲渡はできません。")    '@0
                        Call Show_MessageBox_Add("I007", "鶏以外から企業型への譲渡はできません。")    '@0
                        '2017/09/08 修正終了
                        date_KEIYAKU_DATE_FROM.Focus()
                        Exit Try
                    End If
            End Select

            '--------------------------------------------------
            '譲渡元が他の契約者の譲渡先になっている場合、
            '譲渡元が他の契約者の譲渡元になっている場合のチェック
            '--------------------------------------------------
            If Not f_MotoKeiyakusya_MiSeikyu() Then
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

#Region "f_MotoKeiyakusya_MiSeikyu  画面入力チェック処理(元契約者の未請求)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_MotoKeiyaku_MiSeikyu
    '説明            :契約者が、他の契約者の譲渡元の場合
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_MotoKeiyakusya_MiSeikyu() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty

        Try

            '--------------------------------------------------
            '譲渡元契約者が、ほかの契約者の譲渡先になっていて
            '請求前のときエラー
            '--------------------------------------------------
            wSql &= "SELECT"
            wSql &= "  SUM(CASE WHEN SEIKYU_KAISU IS NULL THEN 1 ELSE 0 END) MI_SEIKYU_CNT "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOTO_RIREKI "
            wSql &= "WHERE KI = " & txt_KI.Text.Trim
            wSql &= "  AND KEIYAKUSYA_CD = " & cob_MOTO_KEIYAKUSYA_CD.Text.Trim

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                cob_MOTO_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count > 0 Then
                '未請求数チェック
                If CInt(WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("MI_SEIKYU_CNT"))) > 0 Then
                    Show_MessageBox_Add("I007", "未請求データが存在するため" & vbCrLf & "選択できません。")
                    cob_MOTO_KEIYAKUSYA_CD.Focus()
                    Exit Try
                End If
            End If

            '--------------------------------------------------
            '譲渡元契約者が、他の契約者の譲渡元になっていて
            '請求前のときエラー
            '--------------------------------------------------
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  SUM(CASE WHEN SEIKYU_KAISU IS NULL THEN 1 ELSE 0 END) MI_SEIKYU_CNT "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOTO_RIREKI "
            wSql &= "WHERE KI = " & txt_KI.Text.Trim
            wSql &= "  AND KEIYAKUSYA_CD <> " & cob_SAKI_KEIYAKUSYA_CD.Text.Trim
            wSql &= "  AND MOTO_KEIYAKUSYA_CD = " & cob_MOTO_KEIYAKUSYA_CD.Text.Trim

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                cob_MOTO_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count > 0 Then
                '未請求数チェック
                If CInt(WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("MI_SEIKYU_CNT"))) > 0 Then
                    Show_MessageBox_Add("I007", "未請求データが存在するため" & vbCrLf & "選択できません。")
                    cob_MOTO_KEIYAKUSYA_CD.Focus()
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

#Region "f_Input_Check_Save  画面入力チェック処理(更新ボタン)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check
    '説明            :画面入力チェック処理(更新ボタン)
    '引数            :0:保存　1:コピー
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_Save() As Boolean
        Dim ret As Boolean = False
        Dim wkControl As Control
        Dim wkControlName As String

        Try

            '==必須チェック==================
            pChk_Cnt = 0
            For i = 0 To dgv_DtlSearch.Rows.Count - 1
                If dgv_DtlSearch.Item("CHK", i).Value = 1 Then
                    pChk_Cnt += 1
                End If
            Next
            If pChk_Cnt = 0 Then
                Call Show_MessageBox_Add("I007", "選択が１件もされていません。")    '@0
                dgv_DtlSearch.Focus()
                Exit Try
            End If

            wkControlName = "譲渡年月日"
            wkControl = date_KEIYAKU_DATE_FROM
            If date_KEIYAKU_DATE_FROM.Value Is Nothing OrElse date_KEIYAKU_DATE_FROM.Value = New Date Then
                Call Show_MessageBox_Add("W008", wkControlName)
                wkControl.Focus()
                Exit Try
            End If

            '==FromToチェック==================

            '事業開始日  >　譲渡年月日　はエラー
            If pJIGYO_KAISI_DATE > f_DateTrim(date_KEIYAKU_DATE_FROM.Value) Then
                Call Show_MessageBox_Add("I007", "譲渡年月日の指定が正しくありません。")    '@0
                date_KEIYAKU_DATE_FROM.Focus()
                Exit Try
            End If

            '譲渡年月日  >  事業終了日　はエラー
            If f_DateTrim(date_KEIYAKU_DATE_FROM.Value) > pJIGYO_SYURYO_DATE Then
                Call Show_MessageBox_Add("I007", "譲渡年月日の指定が正しくありません。")    '@0
                date_KEIYAKU_DATE_FROM.Focus()
                Exit Try
            End If

            '==いろいろチェック==================

            '新規・変更の共通チェック
            If Not f_Input_Check_SaveBoth() Then
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
#Region "f_Input_Check_SaveBoth  画面入力チェック処理(新規と変更　保存ボタン)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check_SaveBoth
    '説明            :画面入力チェック処理(新規と変更　保存ボタン)"
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_SaveBoth() As Boolean
        Dim ret As Boolean = False
        Dim wKeiyakuKbn As String = String.Empty
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty

        Try

            '--------------------------------------------------
            '譲渡元の契約者チェック
            '--------------------------------------------------
            '入力中の状態で、契約区分の変更が実行されると、家族→家族の譲渡が、企業→家族の譲渡に変わってしまう。
            'よって、変更のときに、新規のときデータ部検索で行ったチェックと同じ契約者チェックを行う。
            If Not f_Input_Check_DtlSearch() Then
                Exit Try
            End If

            '--------------------------------------------------
            '譲渡元契約者の有効契約年月日
            '--------------------------------------------------
            '譲渡元データをチェック
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  KEIYAKU_DATE_FROM "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO JOH "
            wSql &= "WHERE JOH.KI = " & txt_KI.Text.Trim
            wSql &= "  AND JOH.KEIYAKUSYA_CD = " & cob_MOTO_KEIYAKUSYA_CD.Text.Trim
            wSql &= "  AND JOH.DATA_FLG = 1"
            wSql &= "ORDER BY"
            wSql &= "  KEIYAKU_DATE_FROM DESC"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                '該当データなし
                Show_MessageBox_Add("I007", "契約情報がすでに削除されています。")
                Exit Try
            Else
                '契約日チェック
                wStr = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("KEIYAKU_DATE_FROM"))
                '2016/09/23　修正開始
                '契約開始日　≧　増羽年月日　はエラー
                'If CDate(wStr) >= f_DateTrim(date_KEIYAKU_DATE_FROM.Value) Then
                '契約開始日　＞　増羽年月日　はエラー
                If CDate(wStr) > f_DateTrim(date_KEIYAKU_DATE_FROM.Value) Then
                    '2016/09/23　修正終了
                    Show_MessageBox_Add("I007", "現在、有効な契約情報の年月日より" & vbCrLf & "前の譲渡年月日は指定できません。")
                    date_KEIYAKU_DATE_FROM.Focus()
                    Exit Try
                End If
            End If

            '--------------------------------------------------
            '譲渡先契約者の有効契約年月日
            '--------------------------------------------------
            '譲渡先データをチェック
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  KEIYAKU_DATE_FROM "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO JOH "
            wSql &= "WHERE JOH.KI = " & txt_KI.Text.Trim
            wSql &= "  AND JOH.KEIYAKUSYA_CD = " & cob_SAKI_KEIYAKUSYA_CD.Text.Trim
            wSql &= "  AND JOH.DATA_FLG = 1"
            wSql &= "ORDER BY"
            wSql &= "  KEIYAKU_DATE_FROM DESC"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                '該当データなし
            Else
                '契約日チェック
                wStr = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("KEIYAKU_DATE_FROM"))
                '2016/09/23　修正開始
                '契約開始日　≧　増羽年月日　はエラー
                'If CDate(wStr) >= f_DateTrim(date_KEIYAKU_DATE_FROM.Value) Then   
                '契約開始日　＞　増羽年月日　はエラー
                If CDate(wStr) > f_DateTrim(date_KEIYAKU_DATE_FROM.Value) Then
                    '2016/09/23　修正終了
                    Show_MessageBox_Add("I007", "現在、有効な契約情報の年月日より" & vbCrLf & "前の譲渡年月日は指定できません。")
                    date_KEIYAKU_DATE_FROM.Focus()
                    Exit Try
                End If
            End If

            '--------------------------------------------------
            '譲渡元・契約年月日(開始)・譲渡先が同一のデータ
            '--------------------------------------------------
            For i = 0 To dgv_HdSearch.Rows.Count - 1
                If f_DateTrim(dgv_HdSearch.Item("KEIYAKU_DATE_FROM", i).Value) = f_DateTrim(date_KEIYAKU_DATE_FROM.Value) AndAlso
                   dgv_HdSearch.Item("MOTO_KEIYAKUSYA_CD", i).Value = cob_MOTO_KEIYAKUSYA_CD.Text.Trim Then
                    '変更のとき、選択行はチェックなし
                    If pSyoriKbn = Enu_SyoriKubun.Update AndAlso i = pSel_POS Then
                        '選択行
                    Else
                        Show_MessageBox_Add("I007", "既に同一の譲渡年月日・譲渡元が指定されています。")
                        date_KEIYAKU_DATE_FROM.Focus()
                        Exit Try
                    End If
                End If
            Next

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region

#Region "f_SakiKeiyaku_MiSeikyu  画面入力チェック処理(先契約者の未請求)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Seikyu_Check_SakiKeiyakusya
    '説明            :契約者が、ほかの契約者の譲渡先の場合
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Seikyu_Check_SakiKeiyakusya(ByVal wKEIYAKU_CD As Integer) As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty

        Try

            '--------------------------------------------------
            '譲渡先契約者が、ほかの契約者の譲渡元になっていて
            '請求前のときエラー
            '--------------------------------------------------
            wSql &= "SELECT"
            wSql &= "  SUM(CASE WHEN SEIKYU_KAISU IS NULL THEN 1 ELSE 0 END) MI_SEIKYU_CNT "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOTO_RIREKI "
            wSql &= "WHERE KI = " & txt_KI.Text.Trim
            wSql &= "  AND SAKI_KEIYAKUSYA_CD = " & wKEIYAKU_CD

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                ret = True
                Exit Try
            End If

            '契約日チェック
            If CInt(WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("MI_SEIKYU_CNT"))) > 0 Then
                Show_MessageBox_Add("I007", "未請求データが存在するため" & vbCrLf & "選択できません。")
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

#Region "通知書出力処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SeikyuSyori
    '説明            :通知書出力処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SeikyuSyori() As Boolean
        Dim ret As Boolean = False
        Dim strtNowKEY As T_KEY = Nothing

        Try


            '期
            strtNowKEY = New T_KEY
            strtNowKEY.KI = txt_KI.Text.Trim
            '請求回数
            strtNowKEY.SEIKYU_KAISU = WordHenkan("N", "S", dgv_HdSearch.Item("SEIKYU_KAISU", pSel_POS).Value)
            '譲渡先契約者
            strtNowKEY.SAKI_KEIYAKUSYA_CD = CInt(cob_SAKI_KEIYAKUSYA_CD.Text.Trim)
            strtNowKEY.SAKI_KEIYAKUSYA_NM = cob_SAKI_KEIYAKUSYA_NM.Text.Trim
            strtNowKEY.SAKI_KEIYAKU_KBN = lbl_SAKI_KEIYAKU_KBN.Text.Trim
            '契約開始日
            strtNowKEY.KEIYAKU_DATE_FROM = WordHenkan("N", "S", dgv_HdSearch.Item("KEIYAKU_DATE_FROM", pSel_POS).Value)
            strtNowKEY.KEIYAKU_DATE_FROM_X = WordHenkan("N", "S", dgv_HdSearch.Item("KEIYAKU_DATE_FROM_X", pSel_POS).Value)
            '契約終了日
            strtNowKEY.KEIYAKU_DATE_TO = pJIGYO_SYURYO_DATE
            '処理区分
            strtNowKEY.SYORI_KBN = WordHenkan("N", "S", dgv_HdSearch.Item("SYORI_KBN", pSel_POS).Value)
            '譲渡元契約者
            strtNowKEY.MOTO_KEIYAKUSYA_CD = CInt(cob_MOTO_KEIYAKUSYA_CD.Text.Trim)
            strtNowKEY.MOTO_KEIYAKUSYA_NM = cob_MOTO_KEIYAKUSYA_NM.Text.Trim
            strtNowKEY.MOTO_KEIYAKU_KBN = lbl_MOTO_KEIYAKU_KBN.Text.Trim
            '2018/07/04　追加開始
            '契約変更区分
            If lbl_MOTO_KEIYAKU_KBN.Text.Trim = "2" AndAlso lbl_SAKI_KEIYAKU_KBN.Text = "1" Then
                strtNowKEY.KEIYAKU_HENKO_KBN = 5
            Else
                strtNowKEY.KEIYAKU_HENKO_KBN = 4
            End If
            '2018/07/04　追加終了
            
            '請求画面
            Using wkForm As New frmGJ3031
                '引数セット
                wkForm.Owner = Me
                '現在選択されている行の情報を渡します
                wkForm.pCurrentKey = strtNowKEY
                '請求画面表示
                wkForm.ShowDialog()

            End Using

            ret = True

        Catch ex As Exception
            '共通例外処理
            If ex.Message <> "Err" Then
                Show_MessageBox("", ex.Message)
            End If
        End Try

        Return ret

    End Function
#End Region

#End Region

End Class
