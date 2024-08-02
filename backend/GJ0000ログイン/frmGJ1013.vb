'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ1013.vb
'*
'*　　②　機能概要　　　　　互助基金契マスタメンテンテナンス(農場情報)
'*
'*　　③　作成日　　　　　　2015/01/28　BY JBD
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


Public Class frmGJ1013

#Region "***変数定義***"

    ''' <summary>
    ''' 固定項目
    ''' </summary>
    ''' <remarks></remarks>
    Property p1013_KI As Integer
    Property p1013_KEIYAKUSYA_CD As Integer
    Property p1013_KEIYAKUSYA_NAME As String
    Property p1013_NOJO_CD As String
    Property p1013_SyoriKbn As Enu_SyoriKubun    '画面処理区分    2015/12/01　追加

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
    ''' 結果一覧セット用データセット
    ''' </summary>
    ''' <remarks></remarks>
    Private pDataSet As New DataSet

    ''' <summary>
    '''  画面入力内容変更フラグ
    ''' </summary>
    ''' <remarks></remarks>
    Private loblnTextChange As Boolean                      '画面入力内容変更フラグ

    ''' <summary>
    '''  プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True
    Private pNOJO_CD As String = String.Empty

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
        Dim wRow As Integer = -1

        Try

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            '画面初期化
            pJump = True
            ret = f_ObjectClear("C")
            pJump = False

            'コンボボックスセット
            If Not f_ComboBox_Set() Then
                Exit Try
            End If

            'グリッド　表示
            If Not f_Grid_Set("C", p1013_NOJO_CD, wRow) Then
                Exit Try
            End If

            '変更判定イベント登録
            f_setControlChangeEvents()

            '★初期コントロールにフォーカスセット
            '2015/12/01　修正開始
            'txt_NOJO_CD.Focus()
            If p1013_SyoriKbn = Enu_SyoriKubun.Insert Then
                txt_NOJO_CD.Enabled = True
                txt_NOJO_CD.Focus()
            ElseIf wRow = -1 Then
                p1013_SyoriKbn = Enu_SyoriKubun.Insert
                txt_NOJO_CD.Text = p1013_NOJO_CD
                txt_MEISAI_NO.Text = p1013_NOJO_CD
                txt_NOJO_CD.Enabled = False
                txt_NOJO_NAME.Focus()
            Else
                txt_NOJO_CD.Enabled = False
                txt_NOJO_NAME.Focus()
            End If
            '2015/12/01　修正終了


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

            '事前チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '保存処理確認
            If Show_MessageBox_Add("Q004", "データ") = DialogResult.No Then    '保存します。よろしいですか？
                Exit Try
            End If

            'データ保存処理
            If Not f_Data_Insert() Then
                Exit Try
            End If
            loblnTextChange = False

            'キー項目セーブ
            p1013_NOJO_CD = txt_NOJO_CD.Text.Trim

            '2015/03/21　修正開始
            ''グリッド　再表示
            'f_Grid_Set("", p1013_NOJO_CD)

            ''画面入力内容変更フラグクリア
            'loblnTextChange = False

            ''★初期コントロールにフォーカスセット
            'txt_NOJO_CD.Focus()
            '2015/03/21　修正終了

            cmdEnd_Click(cmdEnd, New EventArgs)

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
    Private Sub cmdCan_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If loblnTextChange Then
            '画面に変更があり保存していない場合は、メッセージ表示
            If Show_MessageBox("Q007", "") = DialogResult.No Then
                Exit Sub
            End If
        End If

        '画面クリア
        f_DtlClear()

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

#Region "契約者農場 Validating"

    '------------------------------------------------------------------
    'プロシージャ名  :txt_NOJO_CD_Enter
    '説明            :契約者農場 Enter
    '------------------------------------------------------------------
    Private Sub txt_NOJO_CD_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_NOJO_CD.Enter

        Try
            pNOJO_CD = txt_NOJO_CD.Text.Trim        '2015/10/18　追加
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :txt_NOJO_CD_Validating
    '説明            :契約者農場 Validating
    '------------------------------------------------------------------
    Private Sub txt_NOJO_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_NOJO_CD.Validating

        Try
            If txt_NOJO_CD.Text = "" Then
                '2015/10/16　追加開始
                If pNOJO_CD <> txt_NOJO_CD.Text.Trim Then
                    txt_MEISAI_NO.Text = txt_NOJO_CD.Text.Trim
                End If
                '2015/10/16　追加終了
                Exit Try
            End If

            '同一農場登録されている。
            If f_ExsistData() Then
                Call Show_MessageBox("W001", "")    'データは既に登録されています。
                e.Cancel = True
                Exit Try
            End If

            '2015/10/16　追加開始
            If pNOJO_CD <> txt_NOJO_CD.Text.Trim Then
                txt_MEISAI_NO.Text = txt_NOJO_CD.Text.Trim
            End If
            '2015/10/16　追加終了

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub


#End Region

#Region "都道府県関連"
    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_F_SelectedIndexChanged
    '説明            :都道府県コード項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEN_CD.SelectedIndexChanged

        If pJump Then
            Exit Sub
        End If

        cob_KEN_NM.SelectedIndex = cob_KEN_CD.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_NM_SelectedIndexChanged
    '説明            :都道府県名項目変更時処理
    '------------------------------------------------------------------
    ''' <summary>
    ''' 都道府県名項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KEN_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEN_NM.SelectedIndexChanged

        If pJump Then
            Exit Sub
        End If

        cob_KEN_CD.SelectedIndex = cob_KEN_NM.SelectedIndex
        '住所１表示
        txt_ADDR_1.Text = cob_KEN_NM.Text

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_NM_SelectedIndexChanged
    '説明            :都道府県コード確定時処理
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_KEN_CD.Validating

        If cob_KEN_CD.Text = "" Then
            Exit Sub
        End If

        '先頭ゼロを削除
        DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString

        cob_KEN_CD.SelectedValue = cob_KEN_CD.Text
        If cob_KEN_CD.SelectedValue Is Nothing Then
            cob_KEN_CD.SelectedIndex = -1
            cob_KEN_NM.SelectedIndex = -1
            Show_MessageBox_Add("W012", "都道府県") '指定された@0が正しくありません。
            cob_KEN_CD.Focus()
        End If

    End Sub

#End Region

#End Region

#Region "*** データ登録関連 ***"

#Region "f_Data_Insert 契約者農場登録処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Insert
    '説明            :契約者農場登録処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Insert() As Boolean
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '2015/12/01　修正開始
            'Cmd.CommandText = "PKG_GJ8091.GJ8091_KEIYAKU_NOJO_INS"
            If p1013_SyoriKbn = Enu_SyoriKubun.Insert Then
                Cmd.CommandText = "PKG_GJ8091.GJ8091_KEIYAKU_NOJO_INS"
            Else
                Cmd.CommandText = "PKG_GJ8091.GJ8091_KEIYAKU_NOJO_UPD"
            End If
            '2015/12/01　修正終了

            '引き渡し

            '期 
            Cmd.Parameters.Add("IN_KI", p1013_KI)
            '契約者番号
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", p1013_KEIYAKUSYA_CD)
            '農場番号 
            Cmd.Parameters.Add("IN_NOJO_CD", txt_NOJO_CD.Text)
            '都道府県コード
            Cmd.Parameters.Add("IN_KEN_CD", cob_KEN_CD.Text)
            '農場名
            Cmd.Parameters.Add("IN_NOJO_NAME", txt_NOJO_NAME.Text)

            '郵便番号
            Cmd.Parameters.Add("IN_ADDR_POST", msk_ADDR_POST.Value)
            '住所１
            Cmd.Parameters.Add("IN_ADDR_1", txt_ADDR_1.Text)
            '住所２
            Cmd.Parameters.Add("IN_ADDR_2", txt_ADDR_2.Text)
            '住所３
            If txt_ADDR_3.Text.Trim = "" Then
                Cmd.Parameters.Add("IN_ADDR_3", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_ADDR_3", txt_ADDR_3.Text)
            End If
            '住所４
            If txt_ADDR_4.Text.Trim = "" Then
                Cmd.Parameters.Add("IN_ADDR_4", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_ADDR_4", txt_ADDR_4.Text)
            End If

            '電話番号
            Cmd.Parameters.Add("IN_MEISAI_NO", txt_MEISAI_NO.Text)

            If p1013_SyoriKbn = Enu_SyoriKubun.Insert Then  '2015/12/01　追加
                'データ登録日
                Cmd.Parameters.Add("IN_REG_DATE", Now)
                'データ登録ＩＤ
                Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
            End If                                          '2015/12/01　追加

            'データ更新日
            Cmd.Parameters.Add("IN_UP_DATE", Now)
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

            'ヘッダ表示
            lbl_KI.Text = "第" & p1013_KI & "期"
            lbl_KEIYAKUSYA_CD.Text = p1013_KEIYAKUSYA_CD
            lbl_KEIYAKUSYA_NM.Text = p1013_KEIYAKUSYA_NAME

            '====初期値設定======================

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
    Private Function f_ComboBox_Set() As Boolean
        Dim ret As Boolean = False
        Dim wWhere As String = String.Empty

        Try

            '県マスタコンボセット
            If Not f_Ken_Data_Select(cob_KEN_CD, cob_KEN_NM, True) Then
                Exit Try
            End If

            'コンボボックス初期化
            cob_KEN_CD.Text = ""

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_ExsistData データ有無チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ExsistData
    '説明            :データ有無チェック
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ExsistData() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            wSql = "SELECT * FROM TM_KEIYAKU_NOJO" & _
                    " WHERE KI = " & p1013_KI & _
                    "  AND KEIYAKUSYA_CD = " & p1013_KEIYAKUSYA_CD & _
                    "  AND NOJO_CD = " & txt_NOJO_CD.Text

            'SQL実効
            If Not f_Select_ODP(wkDS, wSql) Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count > 0 Then
                'データ有り:TRUE
                ret = True
            Else
                'データ無し:FALSE
                ret = False
            End If

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
    Private Function f_Grid_Set(ByVal wKbn As String, ByVal wNOJO_CD As String, ByRef wRow As Integer) As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty

        Try

            'グリッドが入力不可の場合、スクロールバーが連動しないので、グリッドを入力可能にする
            dgv_Search.Enabled = True

            If wKbn <> "C" Then
                '画面初期化
                ret = f_ObjectClear("")
            End If

            '--------------------------------------------------
            '   グリッド
            '--------------------------------------------------
            'グリッド用ＳＱＬ　作成
            If Not f_Search_SQLMake(wSql) Then
                Exit Try
            End If

            'ＳＱＬ実行
            If Not f_Select_ODP(pDataSet, wSql) Then
                Exit Try
            End If

            '画面に該当データを表示
            dgv_Search.DataSource = pDataSet.Tables(0)

            '--------------------------------------------------
            '   グリッド表示位置
            '--------------------------------------------------
            '2015/12/01　修正開始
            'If wKbn = "" Then
            '    ret = f_GridReDisp(wNOJO_CD)
            'End If
            If p1013_SyoriKbn = Enu_SyoriKubun.Update Then
                'グリッドの該当データ選択
                ret = f_GridReDisp(wNOJO_CD, wRow)
                'グリッドの該当データを明細に表示
                If wRow <> -1 Then
                    ret = f_DtlSet(wRow)
                End If
            End If
            '2015/12/01　修正修理用

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
            wSql &= "  KNO.NOJO_CD,"
            wSql &= "  KNO.NOJO_NAME NOJO_NM,"
            wSql &= "  KNO.ADDR_1||ADDR_2||ADDR_3||ADDR_4 ADDR,"
            wSql &= "  KNO.KEN_CD,"
            wSql &= "  KNO.MEISAI_NO,"
            wSql &= "  KNO.ADDR_POST,"
            wSql &= "  KNO.ADDR_1,"
            wSql &= "  KNO.ADDR_2,"
            wSql &= "  KNO.ADDR_3,"
            wSql &= "  KNO.ADDR_4 "
            wSql &= "FROM"
            wSql &= "  TM_KEIYAKU_NOJO KNO "
            wSql &= "WHERE KNO.KI = " & p1013_KI
            wSql &= "  AND KNO.KEIYAKUSYA_CD = " & p1013_KEIYAKUSYA_CD
            wSql &= "ORDER BY"
            wSql &= "  KNO.NOJO_CD"

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
    Private Function f_GridReDisp(ByVal wNOJO_CD As Integer, ByRef wRow As Integer) As Boolean
        Dim ret As Boolean = False

        Try

            wRow = -1

            'グリッドに有効データあり
            If dgv_Search.RowCount <> 0 Then

                '更新対象のデータ　または　その次のデータに、カーソルをせっと
                For i As Integer = 0 To dgv_Search.RowCount - 1
                    If CInt(WordHenkan("N", "Z", dgv_Search.Item("NOJO_CD", i).Value)) = wNOJO_CD Then
                        '現在セル　セット
                        dgv_Search.CurrentCell = dgv_Search(0, i)
                        wRow = i
                        Exit For
                    End If
                Next
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
            txt_NOJO_CD.Text = ""
            txt_NOJO_NAME.Text = ""
            cob_KEN_CD.SelectedIndex = -1
            cob_KEN_NM.SelectedIndex = -1
            msk_ADDR_POST.Value = Nothing
            txt_ADDR_1.Text = ""
            txt_ADDR_2.Text = ""
            txt_ADDR_3.Text = ""
            txt_ADDR_4.Text = ""
            txt_MEISAI_NO.Text = ""

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
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_DtlSet(ByVal wRow As Integer) As Boolean
        Dim ret As Boolean = False

        Try

            '農場番号
            txt_NOJO_CD.Text = pDataSet.Tables(0).Rows(wRow)("NOJO_CD").ToString
            '農場名
            txt_NOJO_NAME.Text = pDataSet.Tables(0).Rows(wRow)("NOJO_NM").ToString
            '都道府県
            cob_KEN_CD.Text = pDataSet.Tables(0).Rows(wRow)("KEN_CD").ToString
            cob_KEN_CD.SelectedValue = pDataSet.Tables(0).Rows(wRow)("KEN_CD").ToString
            '郵便番号
            msk_ADDR_POST.Value = pDataSet.Tables(0).Rows(wRow)("ADDR_POST").ToString
            '住所
            txt_ADDR_1.Text = pDataSet.Tables(0).Rows(wRow)("ADDR_1").ToString
            txt_ADDR_2.Text = pDataSet.Tables(0).Rows(wRow)("ADDR_2").ToString
            txt_ADDR_3.Text = pDataSet.Tables(0).Rows(wRow)("ADDR_3").ToString
            txt_ADDR_4.Text = pDataSet.Tables(0).Rows(wRow)("ADDR_4").ToString
            '明細番号
            txt_MEISAI_NO.Text = pDataSet.Tables(0).Rows(wRow)("MEISAI_NO").ToString

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
        Dim wkControl As Control
        Dim wkControlName As String

        Try

            '==FromToチェック==================

            '==必須チェック==================

            wkControlName = "農場番号"
            wkControl = txt_NOJO_CD
            If wkControl.Text Is Nothing OrElse wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "農場名"
            wkControl = txt_NOJO_NAME
            If wkControl.Text Is Nothing OrElse wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "都道府県"
            wkControl = cob_KEN_CD
            If wkControl.Text Is Nothing OrElse wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "郵便番号"
            wkControl = msk_ADDR_POST
            If msk_ADDR_POST.Value Is Nothing OrElse msk_ADDR_POST.Value = "" Or msk_ADDR_POST.Value.Count <> 7 Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "住所2"
            wkControl = txt_ADDR_2
            If wkControl.Text Is Nothing OrElse wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "明細番号"
            wkControl = txt_MEISAI_NO
            If wkControl.Text Is Nothing OrElse wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            '==いろいろチェック==================

            'Select Case pSyoriKbn
            '    Case Enu_SyoriKubun.Insert '新規登録時チェック
            '
            '    Case Enu_SyoriKubun.Update '更新時チェック
            '
            'End Select

            '住所４入力時、住所３が未入力はエラー
            If Not txt_ADDR_4.Text Is Nothing AndAlso Not txt_ADDR_4.Text = "" Then
                If txt_ADDR_3.Text Is Nothing OrElse txt_ADDR_3.Text = "" Then
                    Call Show_MessageBox_Add("I007", "前の住所入力欄が未入力です。")
                    txt_ADDR_4.Focus()
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

    Private Sub txt_NOJO_CD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_NOJO_CD.TextChanged

    End Sub

    Private Sub txt_MEISAI_NO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_MEISAI_NO.TextChanged

    End Sub

    Private Sub dgv_Search_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Search.CellContentClick

    End Sub

End Class
