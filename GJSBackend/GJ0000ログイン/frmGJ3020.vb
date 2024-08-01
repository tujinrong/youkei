'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ3020.vb
'*
'*　　②　機能概要　　　　　互助基金契約者情報変更（契約区分変更）
'*
'*　　③　作成日　　　　　　2015/02/17　BY JBD
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

Public Class frmGJ3020

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

    ''' <summary>
    ''' グリッドキー項目構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T_KEY

        Public KI As Integer
        Public SEIKYU_KAISU As String
        Public KEIYAKUSYA_CD As Integer
        Public KEIYAKUSYA_NM As String
        Public KEIYAKU_DATE_FROM As Date
        Public KEIYAKU_DATE_FROM_X As String
        Public KEIYAKU_DATE_TO As Date
        Public SYORI_KBN As Integer
        Public KEIYAKU_KBN_MAE As Integer
        Public KEIYAKU_KBN_MAE_NM As String
        Public KEIYAKU_KBN_ATO As Integer
        Public KEIYAKU_KBN_ATO_NM As String

    End Class

    ''' <summary>
    ''' カレント主キー
    ''' </summary>
    ''' <remarks></remarks>
    Property pCurrentKey As frmGJ3020.T_KEY

    ''' <summary>
    '''  プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True
    Private pJIGYO_KAISU_DATE As Date       '事業開始日
    Private pJIGYO_SYURYO_DATE As Date      '事業終了日

    Private pInitKi As String               '期(初期値)
    Private pEnterKi As String              '期(入力値)

    Private pSaveSyoriKbn As String         '(更新前)処理区分　(修正・削除処理用)
    Private pSaveKeiyakuDateFrom As Date    '(更新前)契約開始日(修正・削除処理用)
    Private pSaveNojoCd As String           '(更新前)契約開始日(修正・削除処理用)
    Private pSaveToriKbn As String          '(更新前)契約開始日(修正・削除処理用)

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

            Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

            '初期値取得
            pJIGYO_KAISU_DATE = clsNENDO_KI.pJIGYO_NENDO_byDate         '事業開始日
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
            ret = f_SearchEnableCtl(True)
            ret = f_HdEnableCtl(False)
            ret = f_DtlEnableCtl(False, False)

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

#End Region

#End Region

#Region "***画面ボタンクリック関連***"

#Region "cmdSearch_Click 検索ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSearch_Click
    '説明            :検索ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '画面入力チェック
            If Not f_Input_Check_Search() Then
                Exit Try
            End If

            'SQL作成
            If Not f_Grid_Set("C", Now) Then
                Exit Try
            End If
            
            '入力制御
            If dgv_Search.Rows.Count = 0 Then
                pSyoriKbn = Enu_SyoriKubun.Insert
            Else
                pSyoriKbn = Enu_SyoriKubun.Update
            End If
            ret = f_SearchEnableCtl(False)
            ret = f_HdEnableCtl(True)
            ret = f_DtlEnableCtl(False, False)

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
            ret = f_DtlEnableCtl(False, False)

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
        Dim wMaeKeiyakuKbn As Integer = 0
        Dim wStr As String = String.Empty

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '新規登録ボタン押下時のチェック
            If Not f_Input_Check_CmdIns(wMaeKeiyakuKbn) Then
                Exit Try
            End If

            '処理区分：登録
            pSyoriKbn = Enu_SyoriKubun.Insert

            '--------------------------------------------------
            '入力項目
            '--------------------------------------------------
            '変更前　契約区分
            lbl_KEIYAKU_KBN_MAE.Text = wMaeKeiyakuKbn
            If f_KeiyakuKbnNm(lbl_KEIYAKU_KBN_MAE.Text.Trim, wStr) Then
                lbl_KEIYAKU_KBN_MAE_NM.Text = wStr
            Else
                Exit Try
            End If

            '変更後　契約区分
            If lbl_KEIYAKU_KBN_MAE.Text = 1 Then
                lbl_KEIYAKU_KBN_ATO.Text = 2
            Else
                lbl_KEIYAKU_KBN_ATO.Text = 1
            End If
            If f_KeiyakuKbnNm(lbl_KEIYAKU_KBN_ATO.Text.Trim, wStr) Then
                lbl_KEIYAKU_KBN_ATO_NM.Text = wStr
            Else
                Exit Try
            End If

            '処理状況　1:入力中 2:入力確定    SYORI_KBN
            rbtn_SYORI_KBN1.Checked = True
            pSaveSyoriKbn = "1"

            '請求区分
            lbl_SEIKYU_KBN_NM.Text = ""

            '--------------------------------------------------
            '入力制御
            '--------------------------------------------------
            '処理区分：登録
            pSyoriKbn = Enu_SyoriKubun.Insert

            '入力制御
            ret = f_HdEnableCtl(False)
            ret = f_DtlEnableCtl(True, False)

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

            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")       'データが選択されていません。
                Exit Try
            End If

            '選択されている行を見つける
            For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
                pSel_POS = gRow.Index
                Exit For
            Next

            '処理区分：修正
            pSyoriKbn = Enu_SyoriKubun.Update

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

            '変更前　契約区分
            lbl_KEIYAKU_KBN_MAE.Text = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_KBN_MAE", pSel_POS).Value)
            lbl_KEIYAKU_KBN_MAE_NM.Text = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_KBN_MAE_NM", pSel_POS).Value)
            
            '変更後　契約区分
            lbl_KEIYAKU_KBN_ATO.Text = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_KBN_ATO", pSel_POS).Value)
            lbl_KEIYAKU_KBN_ATO_NM.Text = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_KBN_ATO_NM", pSel_POS).Value)

            '処理状況　1:入力中 2:入力確定    SYORI_KBN
            wStr = WordHenkan("N", "S", dgv_Search.Item("SYORI_KBN", pSel_POS).Value)
            If wStr = "1" Then
                rbtn_SYORI_KBN1.Checked = True
                pSaveSyoriKbn = "1"
            Else
                rbtn_SYORI_KBN2.Checked = True
                pSaveSyoriKbn = "2"
            End If
            
            '請求区分
            If WordHenkan("N", "S", dgv_Search.Item("SEIKYU_KAISU", pSel_POS).Value) = "" Then
                lbl_SEIKYU_KBN_NM.Text = ""
                wErr = False
            Else
                '請求済み
                '2018/07/09　修正開始
                'lbl_SEIKYU_KBN_NM.Text = "請求書発行済"
                'Show_MessageBox_Add("I007", "請求済みのデータは変更できません。")
                lbl_SEIKYU_KBN_NM.Text = "通知書発行済"
                Show_MessageBox_Add("I007", "通知書発行済みのデータは変更できません。")
                '2018/07/09　修正終了
                wErr = True
            End If

            '--------------------------------------------------
            '入力制御
            '--------------------------------------------------
            ret = f_HdEnableCtl(False)
            ret = f_DtlEnableCtl(True, wErr)


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

            '該当データ取得
            For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
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
            wDel_KEIYAKU_DATE = CDate(WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_DATE_FROM", pSel_POS).Value))

            '該当データ削除処理
            If Not f_Data_Deleate() Then
                Exit Try
            End If

            'グリッド　再表示
            f_Grid_Set("", wDel_KEIYAKU_DATE)

            '入力制御
            ret = f_HdEnableCtl(True)
            ret = f_DtlEnableCtl(False, False)

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
        Dim wUpd_MEISAI_NO As Integer = 0
        Dim wUpd_KEIYAKU_DATE As Date = Nothing
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

            'グリッド　再表示
            f_Grid_Set("", wUpd_KEIYAKU_DATE)

            '入出力制御
            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert       '新規入力
                    f_HdEnableCtl(False)
                    f_DtlEnableCtl(True, False)
                Case Enu_SyoriKubun.Update       '変更
                    f_HdEnableCtl(True)
                    f_DtlEnableCtl(False, False)
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
    Private Sub cmdCansel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCansel.Click

        If loblnTextChange Then
            '画面に変更があり保存していない場合は、メッセージ表示
            If Show_MessageBox("Q007", "") = DialogResult.No Then
                Exit Sub
            End If
        End If

        '画面クリア
        f_DtlClear()
        If dgv_Search.Rows.Count = 0 Then
            pSyoriKbn = Enu_SyoriKubun.Insert
        Else
            pSyoriKbn = Enu_SyoriKubun.Update
        End If
        '入力制御
        f_HdEnableCtl(True)
        f_DtlEnableCtl(False, False)

        '変更フラグクリア
        loblnTextChange = False

        '★初期コントロールにフォーカスセット
        dgv_Search.Focus()

    End Sub
#End Region

#Region "cmdSeikyu_Click 請求書発行ボタンクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSeikyu_Click
    '説明            :請求書発行ボタンクリック時処理
    '------------------------------------------------------------------
    Private Sub cmdSeikyu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeikyu.Click
        Dim wUpd_KEIYAKU_DATE As Date = Nothing

        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
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
            For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
                pSel_POS = gRow.Index
                Exit For
            Next

            'キー項目セーブ
            wUpd_KEIYAKU_DATE = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_DATE_FROM", pSel_POS).Value)

            '請求書発行画面
            If Not f_SeikyuSyori() Then
                Exit Try
            End If

            'グリッド　再表示
            f_Grid_Set("", wUpd_KEIYAKU_DATE)
            dgv_Search.Refresh()

            '入力制御
            f_HdEnableCtl(True)
            f_DtlEnableCtl(False, False)
            dgv_Search.Focus()

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
        Dim ret As Boolean = False

        Try

            If cob_KEIYAKUSYA_CD.Text = "" Then
                lbl_KEIYAKU_KBN_NOW.Text = ""
                lbl_KEIYAKU_KBN_NOW_NM.Text = ""
                Exit Try
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
                Exit Try
            End If

            '契約マスタ．契約区分取得
            If Not f_Keiyaku_Data() Then
                cob_KEIYAKUSYA_CD.Focus()
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEIYAKUSYA_CD_Validating
    '説明            :契約者コード_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cob_KEIYAKUSYA_NM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_KEIYAKUSYA_NM.Validating
        Dim ret As Boolean = False

        Try

            If cob_KEIYAKUSYA_CD.Text = "" Then
                lbl_KEIYAKU_KBN_NOW.Text = ""
                lbl_KEIYAKU_KBN_NOW_NM.Text = ""
                Exit Sub
            End If

            '契約マスタ．契約区分取得
            If Not f_Keiyaku_Data() Then
                cob_KEIYAKUSYA_NM.Focus()
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

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            If pSyoriKbn = Enu_SyoriKubun.Insert Then
                Cmd.CommandText = "PKG_GJ3020.GJ3020_KBN_HENKO_INS"
            Else
                Cmd.CommandText = "PKG_GJ3020.GJ3020_KBN_HENKO_UPD"
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

            '契約区分（増羽前）
            If lbl_KEIYAKU_KBN_MAE.Text = "" Then
                Cmd.Parameters.Add("IN_KEIYAKU_KBN_MAE", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_KBN_MAE", CLng(lbl_KEIYAKU_KBN_MAE.Text))
            End If

            '契約区分（増羽後）
            If lbl_KEIYAKU_KBN_ATO.Text = "" Then
                Cmd.Parameters.Add("IN_KEIYAKU_KBN_ATO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_KBN_ATO", CLng(lbl_KEIYAKU_KBN_ATO.Text))
            End If
  
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

           'データ登録日    
            Cmd.Parameters.Add("IN_REG_DATE", wNow)
            'データ登録ＩＤ   
            Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)

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
    Private Function f_Data_Deleate() As Boolean
        Dim ret As Boolean = False
        Dim wStr As String = String.Empty
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ3020.GJ3020_KBN_HENKO_DEL"

            '引き渡し

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", txt_KI.Text.Trim)

            '契約者番号 県コード＋連番３桁    
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", cob_KEIYAKUSYA_CD.Text.Trim)

            '契約年月日From  
            wStr = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_DATE_FROM", pSel_POS).Value)
            If wStr = "" Then
                Cmd.Parameters.Add("KEIYAKU_DATE_FROM", DBNull.Value)
            Else
                Cmd.Parameters.Add("KEIYAKU_DATE_FROM", CDate(wStr))
            End If

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

            'コンボボックスセット(契約者)
            If Not f_ComboBox_Set(pInitKi) Then
                Exit Try
            End If

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
    Private Function f_ComboBox_Set(ByVal wKi As String) As Boolean
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
#Region "f_Keiyaku_Data 契約区分表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Keiyaku_Data
    '説明            :契約区分表示処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Keiyaku_Data() As Boolean
        Dim ret As Boolean = False
        Dim wDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wKeiyakuHenkoKbn As Integer = 0

        Try

            '------------------------------------------------------------
            '   期、契約者が未入力のとき、契約区分クリア
            '------------------------------------------------------------
            If txt_KI.Text.Trim = "" OrElse cob_KEIYAKUSYA_CD.Text.Trim = "" Then
                lbl_KEIYAKU_KBN_NOW.Text = ""
                lbl_KEIYAKU_KBN_NOW_NM.Text = ""
                ret = True
                Exit Try
            End If

            '------------------------------------------------------------
            '   契約データ　チェック
            '------------------------------------------------------------
            'SQL
            wSql &= "SELECT"
            wSql &= "  KYK.KEIYAKU_KBN, M01.RYAKUSYO KEIYAKU_KBN_NM "
            wSql &= "FROM"
            wSql &= " TM_KEIYAKU KYK,"
            wSql &= " TM_CODE M01 "
            wSql &= "WHERE KI = " & txt_KI.Text.Trim
            wSql &= "  AND KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim
            wSql &= "  AND 1 = M01.SYURUI_KBN(+)"
            wSql &= "  AND KYK.KEIYAKU_KBN = M01.MEISYO_CD(+)"

            'DBからデータを取得
            If Not f_Select_ODP(wDS, wSql) Then
                Exit Try
            End If

            'データ有無
            If wDS.Tables(0).Rows.Count = 0 Then
                Show_MessageBox_Add("W012", "契約者") '指定された@0が正しくありません。
                Exit Try
            End If

            '契約区分　表示
            With wDS.Tables(0)
                lbl_KEIYAKU_KBN_NOW.Text = WordHenkan("N", "S", .Rows(0)("KEIYAKU_KBN"))
                lbl_KEIYAKU_KBN_NOW_NM.Text = WordHenkan("N", "S", .Rows(0)("KEIYAKU_KBN_NM"))
            End With

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region
#Region "f_KeiyakuKbnNm 契約区分名取得処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_KeiyakuKbnNm
    '説明            :契約区分名取得処理
    '引数            :契約区分コード
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_KeiyakuKbnNm(ByRef wKbnCd As String, ByRef wKbnNm As String) As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            'SQL
            wSql &= "SELECT"
            'wSql &= "  M01.RYAKUSYO "  '2017/07/18　修正
            wSql &= "  M01.MEISYO "     '2017/07/18　修正
            wSql &= "FROM"
            wSql &= " TM_CODE M01 "
            wSql &= "WHERE M01.SYURUI_KBN = 1"
            wSql &= "  AND M01.MEISYO_CD = " & wKbnCd

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                wKbnNm = ""
                Show_MessageBox_Add("W012", "契約者") '指定された@0が正しくありません。
            Else
                'wKbnNm = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("RYAKUSYO"))      '2017/07/18　修正
                wKbnNm = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("MEISYO"))         '2017/07/18　修正
            End If

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
                                ByVal wKeiyakuDate As Date) As Boolean
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
                bol = f_GridReDisp(wKeiyakuDate)
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
            wSql &= "  TO_CHAR(RIR.KEIYAKU_DATE_FROM, 'EEYY""/""MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') KEIYAKU_DATE_FROM_X,"
            wSql &= "  RIR.KEIYAKU_DATE_FROM,"
            '  --変更前　契約区分
            wSql &= "  RIR.KEIYAKU_KBN_MAE,"
            '↓2017/07/12 修正
            'wSql &= "  M01.RYAKUSYO KEIYAKU_KBN_MAE_NM,"
            wSql &= "  M01.MEISYO KEIYAKU_KBN_MAE_NM,"
            '↑2017/07/12 修正
            '  --変更後　契約区分
            wSql &= "  RIR.KEIYAKU_KBN_ATO,"
            '↓2017/07/12 修正
            'wSql &= "  M02.RYAKUSYO KEIYAKU_KBN_ATO_NM,"
            wSql &= "  M02.MEISYO KEIYAKU_KBN_ATO_NM,"
            '↑2017/07/12 修正
            '  --処理区分
            wSql &= "  SYORI_KBN,"
            wSql &= "  M12.MEISYO SYORI_KBN_NM,"
            '  --請求回数
            wSql &= "  RIR.SEIKYU_KAISU "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_KBN_RIREKI RIR,"
            wSql &= "  TM_CODE M01,"
            wSql &= "  TM_CODE M02,"
            wSql &= "  TM_CODE M12 "
            wSql &= "WHERE RIR.KI = " & txt_KI.Text.Trim
            wSql &= "  AND RIR.KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim
            '  --コードマスタ
            wSql &= "  AND 01 = M01.SYURUI_KBN(+)"
            wSql &= "  AND RIR.KEIYAKU_KBN_MAE  = M01.MEISYO_CD(+)"
            wSql &= "  AND 01 = M02.SYURUI_KBN(+)"
            wSql &= "  AND RIR.KEIYAKU_KBN_ATO  = M02.MEISYO_CD(+)"
            wSql &= "  AND 12 = M12.SYURUI_KBN(+)"
            wSql &= "  AND RIR.SYORI_KBN = M12.MEISYO_CD(+) "
            ' ソート順はf_GridReDispと同一にする
            wSql &= "ORDER BY "
            wSql &= "  RIR.KEIYAKU_DATE_FROM DESC"

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
    Private Function f_GridReDisp(ByVal wKEIYAKU_DATE As Date) As Boolean
        Dim ret As Boolean = False
        Dim blnHit As Boolean = False

        Try
            'グリッドに有効データあり
            If dgv_Search.RowCount <> 0 Then

                '更新対象のデータ　または　その次のデータに、カーソルをせっと
                For i As Integer = 0 To dgv_Search.RowCount - 1
                    '契約日(降順)　ブレーク
                    If f_DateTrim(WordHenkan("N", "Z", dgv_Search.Item("KEIYAKU_DATE_FROM", i).Value)) <= f_DateTrim(wKEIYAKU_DATE) Then
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

            '明細
            date_KEIYAKU_DATE_FROM.Value = Nothing
            lbl_KEIYAKU_KBN_MAE.Text = ""
            lbl_KEIYAKU_KBN_MAE_NM.Text = ""
            lbl_KEIYAKU_KBN_ATO.Text = ""
            lbl_KEIYAKU_KBN_ATO_NM.Text = ""
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
            ''通知書発行の使用　不可
            If dgv_Search.Rows.Count = 0 Then
                cmdSeikyu.Enabled = False
            Else
                cmdSeikyu.Enabled = wEnable
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
    Private Function f_DtlEnableCtl(ByVal wEnable As Boolean, ByVal wErr As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            '農場登録
            If pSyoriKbn = Enu_SyoriKubun.Insert Then
                '通知書発行の使用　不可
                cmdSeikyu.Enabled = False
            Else
                '通知書発行の使用　可能
                If wEnable = True Then
                    cmdSeikyu.Enabled = wEnable
                End If
            End If

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

            'フッタ
            cmdCansel.Enabled = wEnable

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
#Region "f_Input_Check_CmdIns  画面入力チェック処理(新規登録ボタン)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check_CmdIns
    '説明            :画面入力チェック処理(新規登録ボタン)
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_CmdIns(ByRef wMaeKeiyakuKbn As Integer) As Boolean
        Dim ret As Boolean = False
        Dim wDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty

        Try

            '------------------------------------------------------------
            '   契約マスタ　チェック
            '------------------------------------------------------------
            'SQL
            wSql &= "SELECT"
            wSql &= "  KEIYAKU_DATE, HAIGYO_DATE, KEIYAKU_KBN "
            wSql &= "  ,NYU_HEN_DATE " '2021/07/13 JBD9020 新契約日追加 ADD 
            wSql &= "FROM"
            wSql &= "  TM_KEIYAKU KYK "
            wSql &= "WHERE KI = " & txt_KI.Text.Trim
            wSql &= "  AND KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim

            'DBからデータを取得
            If f_Select_ODP(wDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wDS.Tables(0).Rows.Count = 0 Then
                Show_MessageBox_Add("I007", "該当の契約者は登録されていません。")
                Exit Try
            End If

            '契約日チェック
            If wDS.Tables(0).Rows(0)("KEIYAKU_DATE") Is DBNull.Value Then
                Show_MessageBox_Add("I007", "契約が完了していない契約者です。")
                Exit Try
            End If

            '2021/07/13 JBD9020 新契約日追加 ADD START
            '入金返還日チェック
            If wDS.Tables(0).Rows(0)("NYU_HEN_DATE") Is DBNull.Value Then
                Show_MessageBox_Add("I007", "契約が完了していない契約者です。")
                cob_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If
            '2021/07/13 JBD9020 新契約日追加 ADD END

            '廃業日チェック
            If Not (wDS.Tables(0).Rows(0)("HAIGYO_DATE") Is DBNull.Value) Then
                Show_MessageBox_Add("I007", "廃業されている契約者です。")
                Exit Try
            End If

            '契約区分チェック
            If WordHenkan("N", "Z", wDS.Tables(0).Rows(0)("KEIYAKU_KBN")) = "3" Then
                'Show_MessageBox_Add("I007", "契約区分がうずの契約者です。")      '2017/07/18　修正
                Show_MessageBox_Add("I007", "契約区分が鶏以外の契約者です。")     '2017/07/18　修正
                Exit Try
            End If

            '変更前　契約区分
            wMaeKeiyakuKbn = WordHenkan("N", "Z", wDS.Tables(0).Rows(0)("KEIYAKU_KBN"))

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
            If WordHenkan("N", "S", dgv_Search.Item("SEIKYU_KAISU", pSel_POS).Value) <> "" Then
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
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            '==必須チェック==================


            wkControlName = "変更年月日"
            wkControl = date_KEIYAKU_DATE_FROM
            If date_KEIYAKU_DATE_FROM.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            '==FromToチェック==================

            '事業開始日  >　増羽年月日　はエラー
            If pJIGYO_KAISU_DATE > f_DateTrim(date_KEIYAKU_DATE_FROM.Value) Then
                Call Show_MessageBox_Add("I007", "変更年月日の指定が正しくありません。")    '@0
                date_KEIYAKU_DATE_FROM.Focus()
                Exit Try
            End If

            '増羽年月日  >  事業終了日　はエラー
            If f_DateTrim(date_KEIYAKU_DATE_FROM.Value) > pJIGYO_SYURYO_DATE Then
                Call Show_MessageBox_Add("I007", "変更年月日の指定が正しくありません。")    '@0
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

            '--------------------------------------------------
            '契約情報の有効契約年月日
            '--------------------------------------------------
            '変更前データをチェック
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  KEIYAKU_DATE_FROM "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO JOH "
            wSql &= "WHERE JOH.KI = " & txt_KI.Text.Trim
            wSql &= "  AND JOH.KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim
            wSql &= "  AND JOH.DATA_FLG = 1"
            wSql &= "ORDER BY"
            wSql &= "  KEIYAKU_DATE_FROM DESC"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
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
                '契約開始日　≧　増羽年月日　はエラー
                If CDate(wStr) >= f_DateTrim(date_KEIYAKU_DATE_FROM.Value) Then
                    Show_MessageBox_Add("I007", "現在、有効な契約情報の年月日より" & vbCrLf & "前の変更年月日は指定できません。")
                    If pSyoriKbn = Enu_SyoriKubun.Insert Then
                        date_KEIYAKU_DATE_FROM.Focus()
                    End If
                    Exit Try
                End If
            End If

            '以降は新規のときのみ　チェック
            If pSyoriKbn = Enu_SyoriKubun.Update Then
                ret = True
                Exit Try
            End If

            '--------------------------------------------------
            '入力中身請求データ　チェック
            '--------------------------------------------------
            If dgv_Search.Rows.Count > 0 Then
                For i = 0 To dgv_Search.Rows.Count - 1

                    '未請求(請求回数がNULL)のデータが存在するとき、エラー
                    If dgv_Search.Item("SEIKYU_KAISU", i).Value Is DBNull.Value Then
                        Call Show_MessageBox_Add("I007", "未請求のデータが存在するため登録できません。")    '@0
                        Exit Try
                    End If

                Next

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
            strtNowKEY.SEIKYU_KAISU = WordHenkan("N", "S", dgv_Search.Item("SEIKYU_KAISU", pSel_POS).Value)
            '契約者
            strtNowKEY.KEIYAKUSYA_CD = CInt(cob_KEIYAKUSYA_CD.Text.Trim)
            strtNowKEY.KEIYAKUSYA_NM = cob_KEIYAKUSYA_NM.Text.Trim
            '契約開始日
            strtNowKEY.KEIYAKU_DATE_FROM = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_DATE_FROM", pSel_POS).Value)
            strtNowKEY.KEIYAKU_DATE_FROM_X = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_DATE_FROM_X", pSel_POS).Value)
            '契約終了日
            strtNowKEY.KEIYAKU_DATE_TO = pJIGYO_SYURYO_DATE
            '処理区分
            strtNowKEY.SYORI_KBN = WordHenkan("N", "S", dgv_Search.Item("SYORI_KBN", pSel_POS).Value)
            '契約データ.契約区分(変更前)
            strtNowKEY.KEIYAKU_KBN_MAE = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_KBN_MAE", pSel_POS).Value)
            strtNowKEY.KEIYAKU_KBN_MAE_NM = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_KBN_MAE_NM", pSel_POS).Value)
            '契約データ.契約区分(変更後)
            strtNowKEY.KEIYAKU_KBN_ATO = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_KBN_ATO", pSel_POS).Value)
            strtNowKEY.KEIYAKU_KBN_ATO_NM = WordHenkan("N", "S", dgv_Search.Item("KEIYAKU_KBN_ATO_NM", pSel_POS).Value)

            '請求画面
            Using wkForm As New frmGJ3021
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

    Private Sub txt_KI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_KI.TextChanged

    End Sub

    Private Sub lbl_OLD_KEIYAKU_KBN_NM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_KEIYAKU_KBN_MAE_NM.Click

    End Sub

    Private Sub rbtn_SYORI_KBN1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtn_SYORI_KBN1.CheckedChanged

    End Sub
End Class
