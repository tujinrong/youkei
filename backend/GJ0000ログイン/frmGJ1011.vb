'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ1011.vb
'*
'*　　②　機能概要　　　　　互助基金契マスタメンテンテナンス
'*
'*　　③　作成日　　　　　　2015/01/23　BY JBD
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
Imports Oracle.DataAccess.Client

Public Class frmGJ1011

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
    Private pOld_JIMUITAKU_CD As String         '変更前事務委託先
    Private pOld_KEIYAKU_KBN As String          '変更前契約区分

#End Region

#Region "***画面制御関連***"

#Region "frmFS2020_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmEM2020_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmXXXLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean

        Try

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear("C")

            '処理内容によって画面の初期状態をセット
            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert       '新規入力
                    '行遷移ボタン使用不可
                    cmdTop.Enabled = False
                    cmdBef.Enabled = False
                    cmdNext.Enabled = False
                    cmdLast.Enabled = False
                    txt_Now.Enabled = False
                    txt_Now.Text = ""
                    lblTotal.Text = ""
                    pOld_JIMUITAKU_CD = ""
                    pOld_KEIYAKU_KBN = ""

                    '★初期コントロールにフォーカスセット
                    txt_KEIYAKUSYA_CD.Focus()         '2014/05/12　修正

                Case Enu_SyoriKubun.Update       '変更

                    '画面内容をセット
                    If Not f_SetForm_Data(pCurrentKey) Then
                        pLoadErr = True
                        Throw New Exception("該当データが存在しませんでした")
                    End If

                    '主キーコントロール使用不可
                    txt_KEIYAKUSYA_CD.Enabled = False

                    '行遷移
                    lblTotal.Text = paryKEY_1010.Count
                    txt_Now.Text = pSel_NO

                    Call s_Set_RecValidate()

            End Select

            f_setControlChangeEvents()

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

#Region "cmdSav_Click 保存ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSav_Click
    '説明            :保存ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim ea As New System.ComponentModel.CancelEventArgs
        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '修正モードで変更なしのとき、メッセージ表示
            If pSyoriKbn = Enu_SyoriKubun.Update AndAlso Not loblnTextChange Then
                Show_MessageBox("I502", "")
                Exit Try
            End If

            '事前チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '保存処理確認
            If Show_MessageBox("Q003", "") = DialogResult.No Then    '保存します。よろしいですか？
                Exit Try
            End If

            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert          '新規入力

                    pCurrentKey.KEIYAKUSYA_CD = txt_KEIYAKUSYA_CD.Text.Trim

                    'データ保存処理
                    If Not f_Data_Update() Then
                        Exit Try
                    End If

                    Call f_ObjectClear("")          '画面初期化

                    txt_KEIYAKUSYA_CD.Select()

                Case Enu_SyoriKubun.Update       '変更

                    'データ保存処理
                    If Not f_Data_Update() Then
                        Exit Try
                    End If

                    'データセーブ
                    pOld_JIMUITAKU_CD = cob_JIMUITAKU_CD.Text.Trim
                    pOld_KEIYAKU_KBN = cob_KEIYAKU_KBN.Text.Trim

            End Select

            loblnTextChange = False      '画面入力内容変更フラグ

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

#Region "行移動関連処理"

    ''' <summary>
    '''行移動ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdTopBefNextLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBef.Click, cmdLast.Click, cmdNext.Click, cmdTop.Click
        Dim intRecNo As Integer = 0
        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            If loblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
                    Exit Try
                End If
            End If

            Select Case True
                Case sender.Equals(cmdTop) '最初
                    intRecNo = 0
                Case sender.Equals(cmdBef) '１つ前
                    intRecNo = CInt(txt_Now.Text.TrimEnd) - 1 - 1
                Case sender.Equals(cmdNext) '１つ次
                    intRecNo = CInt(txt_Now.Text.TrimEnd)
                Case sender.Equals(cmdLast) '最後
                    intRecNo = CInt(lblTotal.Text) - 1
            End Select

            '行遷移処理
            If Not f_RecValidating(intRecNo) Then
                Exit Try
            End If

            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region
#Region "現在行テキストボックス変更時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_Now_Validating
    '説明            :現在行テキストボックス変更時処理
    '------------------------------------------------------------------
    Private Sub txt_Now_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Now.Validating
        Dim sKENCD As String = String.Empty
        Dim sSEIRICD As String = String.Empty
        Dim intRecNo As Integer = 0
        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            If loblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then       'データが変更されています。よろしいですか？
                    Exit Try
                End If
            End If

            If txt_Now.Text.Trim = "" OrElse CInt(txt_Now.Text.Trim) < 1 Then
                txt_Now.Text = 1
            End If

            intRecNo = CInt(txt_Now.Text.TrimEnd)

            If CInt(txt_Now.Text.TrimEnd) > CInt(lblTotal.Text) Then
                txt_Now.Text = lblTotal.Text
                intRecNo = CInt(lblTotal.Text)
            End If

            '行遷移処理
            If Not f_RecValidating(intRecNo - 1) Then
                Exit Try
            End If

            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region
#Region "f_RecValidating 行遷移処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_RecValidating
    '説明            :行遷移処理
    '引数            :行番号
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_RecValidating(ByVal intRecNo As Integer) As Boolean
        Dim sKENCD As String = String.Empty
        Dim sITAKUCD As String = String.Empty
        Dim sUP_FLG As String = String.Empty
        Dim sSEQNO As String = String.Empty

        Dim ret As Boolean = False
        Try
            '★KEY取得
            Dim tKEY As New frmGJ1010.T_KEY
            tKEY = paryKEY_1010.Item(intRecNo)
            pCurrentKey = tKEY

            '画面に内容をセット
            If Not f_SetForm_Data(tKEY) Then
                Exit Try
            End If

            '行遷移ボタンの制御
            txt_Now.Text = CStr(intRecNo + 1)
            Call s_Set_RecValidate()


            '★初期コントロールにフォーカスセット
            cob_KEN_CD.Focus()

            loblnTextChange = False             '画面入力内容変更フラグ初期化

            ret = True

        Catch ex As Exception
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

        Return ret
    End Function
#End Region

#Region "cmdEnd_Click 終了ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdEnd_Click
    '説明            :終了ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try
            If loblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then
                    Exit Try
                End If
            End If

            '親フォームに現在選択されている行のキーを渡します
            DirectCast(Owner, frmGJ1010).pSel_POS = pSel_NO - 1

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

#Region "契約者 Validating"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_KEIYAKUSYA_CD_Validating
    '説明            :契約者 Validating
    '------------------------------------------------------------------
    Private Sub txt_KEIYAKUSYA_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_KEIYAKUSYA_CD.Validating

        Try
            If txt_KEIYAKUSYA_CD.Text = "" Then
                Exit Try
            End If

            '同一農場登録されている。
            If f_ExsistData() Then
                Call Show_MessageBox("W001", "")    'データは既に登録されています。
                e.Cancel = True
                Exit Try
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub


#End Region

#Region "都道府県関連"

    ''' <summary>
    ''' 都道府県コード項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KenCd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEN_CD.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEN_NM.SelectedIndex = cob_KEN_CD.SelectedIndex
        txt_ADDR_1.Text = cob_KEN_NM.Text.Trim

    End Sub

    ''' <summary>
    ''' 都道府県名項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KenNm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEN_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEN_CD.SelectedIndex = cob_KEN_NM.SelectedIndex

    End Sub

    ''' <summary>
    ''' 都道府県コード確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KenCd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_KEN_CD.Validating

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

#Region "契約区分関連"

    ''' <summary>
    ''' 契約区分コード項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KeiyakusyaKbnCd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEIYAKU_KBN.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEIYAKU_KBN_NM.SelectedIndex = cob_KEIYAKU_KBN.SelectedIndex

    End Sub

    ''' <summary>
    ''' 契約区分名項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KeiyakusyaKbnNm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEIYAKU_KBN_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEIYAKU_KBN.SelectedIndex = cob_KEIYAKU_KBN_NM.SelectedIndex

    End Sub

    ''' <summary>
    ''' 契約区分コード確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KeiyakusyaKbnCd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_KEIYAKU_KBN.Validating

        If cob_KEIYAKU_KBN.Text = "" Then
            Exit Sub
        End If


        '先頭ゼロを削除
        DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString

        cob_KEIYAKU_KBN.SelectedValue = cob_KEIYAKU_KBN.Text
        If cob_KEIYAKU_KBN.SelectedValue Is Nothing Then
            cob_KEIYAKU_KBN.SelectedIndex = -1
            cob_KEIYAKU_KBN_NM.SelectedIndex = -1
            Show_MessageBox_Add("W012", "契約区分") '指定された@0が正しくありません。
            cob_KEIYAKU_KBN.Focus()
        End If

    End Sub

#End Region

#Region "契約状況関連"

    ''' <summary>
    ''' 契約状況コード項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KEIYAKU_JYOKYO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEIYAKU_JYOKYO.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEIYAKU_JYOKYO_NM.SelectedIndex = cob_KEIYAKU_JYOKYO.SelectedIndex

    End Sub

    ''' <summary>
    ''' 契約状況名項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KEIYAKU_JYOKYO_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEIYAKU_JYOKYO_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEIYAKU_JYOKYO.SelectedIndex = cob_KEIYAKU_JYOKYO_NM.SelectedIndex

    End Sub

    ''' <summary>
    ''' 契約状況コード確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KEIYAKU_JYOKYO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_KEIYAKU_JYOKYO.Validating

        If cob_KEIYAKU_JYOKYO.Text = "" Then
            Exit Sub
        End If


        '先頭ゼロを削除
        DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString

        cob_KEIYAKU_JYOKYO.SelectedValue = cob_KEIYAKU_JYOKYO.Text
        If cob_KEIYAKU_JYOKYO.SelectedValue Is Nothing Then
            cob_KEIYAKU_JYOKYO.SelectedIndex = -1
            cob_KEIYAKU_JYOKYO_NM.SelectedIndex = -1
            Show_MessageBox_Add("W012", "契約状況") '指定された@0が正しくありません。
            cob_KEIYAKU_JYOKYO.Focus()
        End If

    End Sub

#End Region

#Region "事務委託先関連"

    ''' <summary>
    ''' 事務委託先コード項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_JIMUITAKU_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_JIMUITAKU_CD.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_JIMUITAKU_NM.SelectedIndex = cob_JIMUITAKU_CD.SelectedIndex

    End Sub

    ''' <summary>
    ''' 事務委託先名項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_JIMUITAKU_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_JIMUITAKU_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_JIMUITAKU_CD.SelectedIndex = cob_JIMUITAKU_NM.SelectedIndex

    End Sub

    ''' <summary>
    ''' 事務委託先コード確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_JIMUITAKU_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_JIMUITAKU_CD.Validating

        If cob_JIMUITAKU_CD.Text = "" Then
            Exit Sub
        End If


        '先頭ゼロを削除
        DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CDec(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString

        'cob_JIMUITAKU_CD.SelectedValue = cob_JIMUITAKU_CD.Text
        cob_JIMUITAKU_CD.SelectedValue = CDec(cob_JIMUITAKU_CD.Text)
        If cob_JIMUITAKU_CD.SelectedValue Is Nothing Then
            cob_JIMUITAKU_CD.SelectedIndex = -1
            cob_JIMUITAKU_NM.SelectedIndex = -1
            Show_MessageBox_Add("W012", "事務委託先") '指定された@0が正しくありません。
            cob_JIMUITAKU_CD.Focus()
        End If

    End Sub

#End Region

#Region "金融機関情報入力有無関連"

    ''' <summary>
    ''' 金融機関情報入力有無項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbtn_BANK_ARI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                rbtn_BANK_ARI.CheckedChanged, rbtn_BANK_NASI.CheckedChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        If sender.Equals(rbtn_BANK_ARI) AndAlso rbtn_BANK_ARI.Checked Then
            '金融情報入力可能
            f_BankEnable(True)
        ElseIf sender.Equals(rbtn_BANK_NASI) AndAlso rbtn_BANK_NASI.Checked Then
            '金融情報入力不可
            f_BankClear()
            f_BankEnable(False)
        End If


    End Sub

#End Region

#Region "金融機関関連"

    ''' <summary>
    ''' 金融機関コード項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_FURI_BANK_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_FURI_BANK_CD.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_FURI_BANK_NM.SelectedIndex = cob_FURI_BANK_CD.SelectedIndex

        '金融機関(支店)コンボセット
        f_BanksIten_Set()


    End Sub

    ''' <summary>
    ''' 金融機関名項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_FURI_BANK_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_FURI_BANK_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_FURI_BANK_CD.SelectedIndex = cob_FURI_BANK_NM.SelectedIndex

        '金融機関(支店)コンボセット
        f_BanksIten_Set()

        cob_KinyukikanSitenCd_Validating(cob_FURI_BANK_CD, New System.ComponentModel.CancelEventArgs)
    End Sub

    ''' <summary>
    ''' 金融機関コード確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_FURI_BANK_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_FURI_BANK_CD.Validating

        If cob_FURI_BANK_CD.Text = "" Then
            Exit Sub
        End If


        ''先頭ゼロを削除
        DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString("0000")


        cob_FURI_BANK_CD.SelectedValue = cob_FURI_BANK_CD.Text
        If cob_FURI_BANK_CD.SelectedValue Is Nothing Then
            cob_FURI_BANK_CD.SelectedIndex = -1
            cob_FURI_BANK_NM.SelectedIndex = -1
            Show_MessageBox_Add("W012", "金融機関") '指定された@0が正しくありません。
            cob_FURI_BANK_CD.Focus()
            Exit Sub
        End If


        If cob_FURI_BANK_SITEN_CD.Items.Count = 0 And cob_FURI_BANK_CD.Text <> "" Then
            Show_MessageBox("W015", "") 'この金融機関には本支店データが存在しません。別のPCで本支店データを登録後、再度選択してください。
            cob_FURI_BANK_CD.Focus()
        End If

    End Sub

#End Region

#Region "支店関連"

    ''' <summary>
    ''' 支店コード項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KinyukikanSitenCd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_FURI_BANK_SITEN_CD.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_FURI_BANK_SITEN_NM.SelectedIndex = cob_FURI_BANK_SITEN_CD.SelectedIndex

    End Sub

    ''' <summary>
    ''' 支店名項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KinyukikanSitenNm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_FURI_BANK_SITEN_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_FURI_BANK_SITEN_CD.SelectedIndex = cob_FURI_BANK_SITEN_NM.SelectedIndex

    End Sub

    ''' <summary>
    ''' 支店コード確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KinyukikanSitenCd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_FURI_BANK_SITEN_CD.Validating

        If cob_FURI_BANK_SITEN_CD.Text = "" Then
            Exit Sub
        End If


        ''先頭ゼロを削除
        'DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString
        '先頭ゼロを追加
        DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = Microsoft.VisualBasic.Right("000" & DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text, 3)

        cob_FURI_BANK_SITEN_CD.SelectedValue = cob_FURI_BANK_SITEN_CD.Text
        If cob_FURI_BANK_SITEN_CD.SelectedValue Is Nothing Then
            cob_FURI_BANK_SITEN_CD.SelectedIndex = -1
            cob_FURI_BANK_SITEN_NM.SelectedIndex = -1
            Show_MessageBox_Add("W012", "金融機関支店") '指定された@0が正しくありません。
            cob_FURI_BANK_SITEN_CD.Focus()
        End If

    End Sub

#End Region

#Region "口座種別関連"

    ''' <summary>
    ''' 口座種別コード項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KouzaSyubetuCd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_FURI_KOZA_SYUBETU.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_FURI_KOZA_SYUBETU_NM.SelectedIndex = cob_FURI_KOZA_SYUBETU.SelectedIndex

    End Sub

    ''' <summary>
    ''' 口座種別名項目変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KouzaSyubetuNm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_FURI_KOZA_SYUBETU_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_FURI_KOZA_SYUBETU.SelectedIndex = cob_FURI_KOZA_SYUBETU_NM.SelectedIndex

    End Sub

    ''' <summary>
    ''' 口座種別コード確定時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_KouzaSyubetuCd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs, _
                                              Optional ByVal wMsgAri As Boolean = True) Handles cob_FURI_KOZA_SYUBETU.Validating

        If cob_FURI_KOZA_SYUBETU.Text = "" Then
            Exit Sub
        End If


        '先頭ゼロを削除
        DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString

        cob_FURI_KOZA_SYUBETU.SelectedValue = cob_FURI_KOZA_SYUBETU.Text
        If cob_FURI_KOZA_SYUBETU.SelectedValue Is Nothing Then
            cob_FURI_KOZA_SYUBETU.SelectedIndex = -1
            cob_FURI_KOZA_SYUBETU_NM.SelectedIndex = -1
            If wMsgAri Then
                Show_MessageBox_Add("W012", "口座種別") '指定された@0が正しくありません。
                cob_FURI_KOZA_SYUBETU.Focus()
            End If
        End If

    End Sub

#End Region

#Region "口座番号関連"

    ''' <summary>
    ''' 口座番号変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_kouzaCD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_FURI_KOZA_NO.Validated

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        txt_FURI_KOZA_NO.Text = (txt_FURI_KOZA_NO.Text).PadLeft(7, "0")
        If CInt(txt_FURI_KOZA_NO.Text) = 0 Then
            txt_FURI_KOZA_NO.Text = ""
        End If
    End Sub

#End Region


#End Region

#Region "*** データ登録関連 ***"
#Region "契約マスタ更新"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Update
    '説明            :契約マスタ更新
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Update() As Boolean
        Dim ret As Boolean = False
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert '新規登録時チェック
                    Cmd.CommandText = "PKG_GJ1011.GJ1011_KEIYAKU_INS"
                Case Enu_SyoriKubun.Update '更新時チェック
                    Cmd.CommandText = "PKG_GJ1011.GJ1011_KEIYAKU_UPD"
                    'PKG_GJ1011.GJ1011_KEIYAKU_UPD
            End Select

            '----------------------------------------
            '   申請者基本情報1
            '----------------------------------------
            '期
            Cmd.Parameters.Add("IN_KI", p1010_KI)
            '契約者
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", txt_KEIYAKUSYA_CD.Text.Trim)
            '都道府県コード
            Cmd.Parameters.Add("IN_KEN_CD", cob_KEN_CD.Text.Trim)
            '契約区分
            Cmd.Parameters.Add("IN_KEIYAKU_KBN", cob_KEIYAKU_KBN.Text.Trim)
            '契約状況
            Cmd.Parameters.Add("IN_KEIYAKU_JYOKYO", cob_KEIYAKU_JYOKYO.Text.Trim)
            '2021/07/06 JBD 9020 ADD START
            '契約日
            If date_KEIYAKU_DATE.Value Is Nothing OrElse date_KEIYAKU_DATE.Value = New Date Then
                Cmd.Parameters.Add("IN_KEIYAKU_DATE", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_DATE", f_DateTrim(date_KEIYAKU_DATE.Value))
            End If
            '2021/07/06 JBD 9020 ADD END
            '----------------------------------------
            '   申請者基本情報2
            '----------------------------------------
            '契約者名    
            Cmd.Parameters.Add("IN_KEIYAKUSYA_NAME", txt_KEIYAKUSYA_NAME.Text)
            '契約者名（フリガナ）    
            Cmd.Parameters.Add("IN_KEIYAKUSYA_KANA", txt_KEIYAKUSYA_KANA.Text)
            '代表者名    
            Cmd.Parameters.Add("IN_DAIHYO_NAME", txt_DAIHYO_NAME.Text)
            '郵便番号    
            Cmd.Parameters.Add("IN_ADDR_POST", msk_ADDR_POST.Value)
            '住所１    ADDR_1
            Cmd.Parameters.Add("IN_ADDR_1", txt_ADDR_1.Text)
            '住所２    ADDR_2
            Cmd.Parameters.Add("IN_ADDR_2", txt_ADDR_2.Text)
            '住所３    ADDR_3
            Cmd.Parameters.Add("IN_txt_ADDR_3", txt_ADDR_3.Text)
            '住所４
            Cmd.Parameters.Add("IN_txt_ADDR_4", txt_ADDR_4.Text)
            '電話番号1
            Cmd.Parameters.Add("IN_ADDR_TEL1", txt_ADDR_TEL1.Text)
            '電話番号2
            Cmd.Parameters.Add("IN_txt_ADDR_TEL2", txt_ADDR_TEL2.Text)
            'ＦＡＸ    
            Cmd.Parameters.Add("IN_ADDR_FAX", txt_ADDR_FAX.Text)
            'メールアドレス    
            Cmd.Parameters.Add("IN_ADDR_E_MAIL", txt_ADDR_E_MAIL.Text)
            '事務委託先番号    
            Cmd.Parameters.Add("IN_NEW_JIMUITAKU_CD", cob_JIMUITAKU_CD.Text)
            If pSyoriKbn = Enu_SyoriKubun.Update Then
                '変更前　事務委託先番号  
                If pOld_JIMUITAKU_CD = "" Then
                    Cmd.Parameters.Add("IN_OLD_JIMUITAKU_CD", DBNull.Value)
                Else
                    Cmd.Parameters.Add("IN_OLD_JIMUITAKU_CD", pOld_JIMUITAKU_CD)
                End If
            End If

            '----------------------------------------
            '   申請者基本情報3
            '----------------------------------------
            '振込先コード（金融機関） 
            Cmd.Parameters.Add("IN_FURI_BANK_CD", cob_FURI_BANK_CD.Text)
            '振込先支店コード    
            Cmd.Parameters.Add("IN_FURI_BANK_SITEN_CD", cob_FURI_BANK_SITEN_CD.Text)
            '口座種別    
            Cmd.Parameters.Add("IN_FURI_KOZA_SYUBETU", cob_FURI_KOZA_SYUBETU.Text)
            '口座番号    
            Cmd.Parameters.Add("IN_FURI_KOZA_NO", txt_FURI_KOZA_NO.Text)
            '口座名義人    
            Cmd.Parameters.Add("IN_FURI_KOZA_MEIGI", txt_FURI_KOZA_MEIGI.Text)
            '口座名義人（カナ）   
            Cmd.Parameters.Add("IN_FURI_KOZA_MEIGI_KANA", txt_FURI_KOZA_MEIGI_KANA.Text)

            '----------------------------------------
            '   その他
            '----------------------------------------
            '備考   
            Cmd.Parameters.Add("IN_FURI_KOZA_BIKO", txt_BIKO.Text)
            '入力状況
            If rbtn_NYURYOKU_JYOKYO1.Checked = True Then
                Cmd.Parameters.Add("IN_NYURYOKU_JYOKYO", "2")
            Else
                Cmd.Parameters.Add("IN_NYURYOKU_JYOKYO", "1")
            End If
            '廃業日
            If date_HAIGYO_DATE.Value Is Nothing OrElse date_HAIGYO_DATE.Value = New Date Then
                Cmd.Parameters.Add("IN_HAIGYO_DATE", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_HAIGYO_DATE", f_DateTrim(date_HAIGYO_DATE.Value))
            End If

            '経営安定対策事業生産者番号
            Cmd.Parameters.Add("IN_SEISANSYA_CD", txt_SEISANSYA_CD.Text.Trim)
            '日鶏協番号
            Cmd.Parameters.Add("IN_NIKKEIKYO_CD", txt_NIKKEIKYO_CD.Text.Trim)

            '----------------------------------------
            '   共通情報
            '----------------------------------------
            If pSyoriKbn = Enu_SyoriKubun.Insert Then
                'データ登録日    
                Cmd.Parameters.Add("IN_REG_DATE", wNow)
                'データ登録ＩＤ   
                Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
            End If
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
        Dim sSql As String = String.Empty
        Dim dstDataControl As New DataSet
        Dim wHasu As Integer = 0
        Dim ret As Boolean = False

        Try

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            pJump = True
            f_ClearFormALL(Me, wKbn)
            pJump = False

            'ヘッダ表示
            lbl_KI.Text = "第" & p1010_KI & "期"

            If wKbn = "C" Then
                'コンボボックスセット
                If Not f_ComboBox_Set() Then
                    Exit Try
                End If
            Else
                If Not f_BankSiten_Set() Then
                    Exit Try
                End If
            End If

            '====初期値設定======================
            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert

                Case Enu_SyoriKubun.Update

            End Select

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

        Return ret

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
            If Not f_Ken_Data_Select(cob_KEN_CD, cob_KEN_NM, True, 5) Then
                Exit Try
            End If

            '契約区分コンボセット
            'If Not f_CodeMaster_Data_Select(cob_KEIYAKU_KBN, cob_KEIYAKU_KBN_NM, 1, True, 1) Then  '名称：略称→正式名称  '2017/07/11　修正
            If Not f_CodeMaster_Data_Select(cob_KEIYAKU_KBN, cob_KEIYAKU_KBN_NM, 1, True, 0) Then   '名称：略称→正式名称  '2017/07/11　修正
                Exit Try
            End If

            '契約状況コンボセット
            If Not f_CodeMaster_Data_Select(cob_KEIYAKU_JYOKYO, cob_KEIYAKU_JYOKYO_NM, 2, True, 1) Then
                Exit Try
            End If

            '金融機関コンボセット
            If Not f_Bank_Data_Select(cob_FURI_BANK_CD, cob_FURI_BANK_NM, True) Then
                Exit Try
            End If

            '金融機関(支店)コンボセット
            If Not f_BankSiten_Set() Then
                Exit Try
            End If

            '口座種別コンボセット
            If Not f_CodeMaster_Data_Select(cob_FURI_KOZA_SYUBETU, cob_FURI_KOZA_SYUBETU_NM, 4, True, 0) Then
                Exit Try
            End If

            '事務委託先コンボセット
            wWhere = "KI = " & p1010_KI
            pJump = True
            If Not f_JimuItaku_Data_Select(cob_JIMUITAKU_CD, cob_JIMUITAKU_NM, wWhere, True) Then
                Exit Try
            End If
            pJump = False

            'コンボボックス初期化
            cob_KEN_CD.Text = ""
            cob_KEIYAKU_KBN.Text = ""
            cob_KEIYAKU_JYOKYO.Text = ""
            cob_JIMUITAKU_CD.Text = ""
            cob_FURI_BANK_CD.Text = ""
            cob_FURI_BANK_SITEN_CD.Text = ""
            cob_FURI_KOZA_SYUBETU.Text = ""

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_BanksIten_Set コンボボックスセット(支店)処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ComboBox_Set
    '説明            :コンボボックスセット(支店)処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_BankSiten_Set() As Boolean
        Dim ret As Boolean = False

        Try

            '金融機関(支店)コンボセット
            If cob_FURI_BANK_CD.Text <> "" Then
                If Not f_BankShop_Data_Select(cob_FURI_BANK_SITEN_CD, cob_FURI_BANK_SITEN_NM, cob_FURI_BANK_CD.Text, True) Then
                    Exit Try
                End If
            Else
                cob_FURI_BANK_SITEN_CD.Items.Clear()
                cob_FURI_BANK_SITEN_NM.Items.Clear()
            End If

            cob_FURI_BANK_SITEN_CD.Text = ""

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

            wSql = "SELECT * FROM TM_KEIYAKU" &
                    " WHERE KI = " & p1010_KI &
                    "  AND KEIYAKUSYA_CD = " & txt_KEIYAKUSYA_CD.Text.Trim

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
#Region "f_SetForm_Data 初期画面表示(修正)処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_Data(ByVal wkKey As frmGJ1010.T_KEY) As Boolean
        Dim ret As Boolean = False
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            'SQL
            wSql = "SELECT * FROM TM_KEIYAKU " &
                   "WHERE KI = " & p1010_KI &
                   "  AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Return False
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                'データ無し
                Exit Try
            End If

            With wkDS.Tables(0)

                '↓==========================================================================↓
                '↓      申請者基本情報１                    　                              ↓
                '↓==========================================================================↓

                '契約者番号
                txt_KEIYAKUSYA_CD.Text = WordHenkan("N", "S", .Rows(0)("KEIYAKUSYA_CD"))

                '都道府県
                cob_KEN_CD.Text = WordHenkan("N", "S", .Rows(0)("KEN_CD"))
                'Call cob_KenCd_Validating(cob_KEN_CD, ea)
                'cob_KenCd_SelectedIndexChanged(cob_KEN_CD, New EventArgs)

                '契約区分   KEIYAKU_KBN
                cob_KEIYAKU_KBN.Text = WordHenkan("N", "S", .Rows(0)("KEIYAKU_KBN"))
                pOld_KEIYAKU_KBN = WordHenkan("N", "S", .Rows(0)("KEIYAKU_KBN"))

                '契約状況   KEIYAKU_JYOKYO
                cob_KEIYAKU_JYOKYO.Text = WordHenkan("N", "S", .Rows(0)("KEIYAKU_JYOKYO"))

                '2021/07/06 JBD9020 新契約日追加 UPD START
                '契約日    KEIYAKU_DATE
                'If WordHenkan("N", "S", .Rows(0)("KEIYAKU_DATE")) Is DBNull.Value Then
                '    date_KEIYAKU_DATE.Value = Nothing
                'Else
                '    date_KEIYAKU_DATE.Value = f_Str2DateOrNothing(WordHenkan("N", "S", .Rows(0)("KEIYAKU_DATE")))
                'End If
                If WordHenkan("N", "S", .Rows(0)("NYU_HEN_DATE")) Is DBNull.Value Or WordHenkan("N", "S", .Rows(0)("NYU_HEN_DATE")) = "" Then
                    date_NYUHEN_DATE.Value = Nothing
                    date_KEIYAKU_DATE.Enabled = True
                Else
                    date_NYUHEN_DATE.Value = f_Str2DateOrNothing(WordHenkan("N", "S", .Rows(0)("NYU_HEN_DATE")))
                    date_KEIYAKU_DATE.Enabled = False
                End If
                If .Rows(0)("KEIYAKU_DATE") Is DBNull.Value Then
                    date_KEIYAKU_DATE.Value = Nothing
                Else
                    date_KEIYAKU_DATE.Value = f_Str2DateOrNothing(WordHenkan("N", "S", .Rows(0)("KEIYAKU_DATE")))
                End If
                '2021/07/06 JBD9020 新契約日追加 UPD END

                '経営安定対策事業生産者番号    SEISANSYA_CD
                txt_SEISANSYA_CD.Text = WordHenkan("N", "S", .Rows(0)("SEISANSYA_CD"))

                '日鶏協番号    NIKKEIKYO_CD
                txt_NIKKEIKYO_CD.Text = WordHenkan("N", "S", .Rows(0)("NIKKEIKYO_CD"))

                '↓==========================================================================↓
                '↓      申請者基本情報２                    　                              ↓
                '↓==========================================================================↓
                '契約者名    KEIYAKUSYA_NAME
                'txt_KEIYAKUSYA_NAME.Text = WordHenkan("N", "S", .Rows(0)("KEIYAKUSYA_NAME"))
                If .Rows(0)("KEIYAKUSYA_NAME") Is DBNull.Value Then
                    txt_KEIYAKUSYA_NAME.Text = ""
                Else
                    txt_KEIYAKUSYA_NAME.Text = .Rows(0)("KEIYAKUSYA_NAME")
                End If

                '契約者名（フリガナ）    KEIYAKUSYA_KANA
                'txt_KEIYAKUSYA_KANA.Text = WordHenkan("N", "S", .Rows(0)("KEIYAKUSYA_KANA"))
                If .Rows(0)("KEIYAKUSYA_KANA") Is DBNull.Value Then
                    txt_KEIYAKUSYA_KANA.Text = ""
                Else
                    txt_KEIYAKUSYA_KANA.Text = .Rows(0)("KEIYAKUSYA_KANA")
                End If

                '代表者名    DAIHYO_NAME
                'txt_DAIHYO_NAME.Text = WordHenkan("N", "S", .Rows(0)("DAIHYO_NAME"))
                If .Rows(0)("DAIHYO_NAME") Is DBNull.Value Then
                    txt_DAIHYO_NAME.Text = ""
                Else
                    txt_DAIHYO_NAME.Text = .Rows(0)("DAIHYO_NAME")
                End If

                '郵便番号    ADDR_POST
                msk_ADDR_POST.Value = WordHenkan("N", "S", .Rows(0)("ADDR_POST"))

                '住所１    ADDR_1
                'txt_ADDR_1.Text = WordHenkan("N", "S", .Rows(0)("ADDR_1"))
                If .Rows(0)("ADDR_1") Is DBNull.Value Then
                    txt_ADDR_1.Text = ""
                Else
                    txt_ADDR_1.Text = .Rows(0)("ADDR_1")
                End If

                '住所２    ADDR_2
                'txt_ADDR_2.Text = WordHenkan("N", "S", .Rows(0)("ADDR_2"))
                If .Rows(0)("ADDR_2") Is DBNull.Value Then
                    txt_ADDR_2.Text = ""
                Else
                    txt_ADDR_2.Text = .Rows(0)("ADDR_2")
                End If

                '住所３    ADDR_3
                'txt_ADDR_3.Text = WordHenkan("N", "S", .Rows(0)("ADDR_3"))
                If .Rows(0)("ADDR_3") Is DBNull.Value Then
                    txt_ADDR_3.Text = ""
                Else
                    txt_ADDR_3.Text = .Rows(0)("ADDR_3")
                End If

                '住所４    ADDR_4
                'txt_ADDR_4.Text = WordHenkan("N", "S", .Rows(0)("ADDR_4"))
                If .Rows(0)("ADDR_4") Is DBNull.Value Then
                    txt_ADDR_4.Text = ""
                Else
                    txt_ADDR_4.Text = .Rows(0)("ADDR_4")
                End If

                '電話番号1    ADDR_TEL1
                txt_ADDR_TEL1.Text = WordHenkan("N", "S", .Rows(0)("ADDR_TEL1"))

                '電話番号2    ADDR_TEL2
                txt_ADDR_TEL2.Text = WordHenkan("N", "S", .Rows(0)("ADDR_TEL2"))

                'ＦＡＸ    ADDR_FAX
                txt_ADDR_FAX.Text = WordHenkan("N", "S", .Rows(0)("ADDR_FAX"))

                'メールアドレス    ADDR_E_MAIL
                txt_ADDR_E_MAIL.Text = WordHenkan("N", "S", .Rows(0)("ADDR_E_MAIL"))

                '事務委託先番号    JIMUITAKU_CD
                cob_JIMUITAKU_CD.Text = WordHenkan("N", "S", .Rows(0)("JIMUITAKU_CD"))
                pOld_JIMUITAKU_CD = WordHenkan("N", "S", .Rows(0)("JIMUITAKU_CD"))

                '↓==========================================================================↓
                '↓      申請者基本情報３                    　                              ↓
                '↓==========================================================================↓
                '振込先コード（金融機関）
                cob_FURI_BANK_CD.Text = WordHenkan("N", "S", .Rows(0)("FURI_BANK_CD"))

                If cob_FURI_BANK_CD.Text = "" Then

                    '金融情報入力不可
                    rbtn_BANK_NASI.Checked = True
                    f_BankEnable(False)
                Else

                    '振込先コード（金融機関）
                    Call cob_FURI_BANK_CD_Validating(cob_FURI_BANK_CD, ea)
                    cob_FURI_BANK_CD_SelectedIndexChanged(cob_FURI_BANK_CD, New EventArgs)

                    '振込先支店コード
                    cob_FURI_BANK_SITEN_CD.Text = WordHenkan("N", "S", .Rows(0)("FURI_BANK_SITEN_CD"))
                    If cob_FURI_BANK_SITEN_CD.Text = "" Then
                        cob_FURI_BANK_SITEN_NM.SelectedIndex = -1
                    Else
                        Call cob_KinyukikanSitenCd_Validating(cob_FURI_BANK_SITEN_CD, ea)
                        cob_KinyukikanSitenCd_SelectedIndexChanged(cob_FURI_BANK_SITEN_CD, New EventArgs)
                    End If

                    '口座種別
                    cob_FURI_KOZA_SYUBETU.Text = WordHenkan("N", "S", .Rows(0)("FURI_KOZA_SYUBETU"))
                    If cob_FURI_KOZA_SYUBETU.Text = "" Then
                        cob_FURI_KOZA_SYUBETU_NM.SelectedIndex = -1
                    Else
                        Call cob_KouzaSyubetuCd_Validating(cob_FURI_KOZA_SYUBETU, ea, False)
                        cob_KouzaSyubetuCd_SelectedIndexChanged(cob_FURI_KOZA_SYUBETU, New EventArgs)
                    End If

                    '口座番号
                    txt_FURI_KOZA_NO.Text = WordHenkan("N", "S", .Rows(0)("FURI_KOZA_NO"))

                    '口座名義人
                    'txt_FURI_KOZA_MEIGI.Text = WordHenkan("N", "S", .Rows(0)("FURI_KOZA_MEIGI"))
                    If .Rows(0)("FURI_KOZA_MEIGI") Is DBNull.Value Then
                        txt_FURI_KOZA_MEIGI.Text = ""
                    Else
                        txt_FURI_KOZA_MEIGI.Text = .Rows(0)("FURI_KOZA_MEIGI")
                    End If

                    '口座名義人（カナ）
                    'txt_FURI_KOZA_MEIGI_KANA.Text = WordHenkan("N", "S", .Rows(0)("FURI_KOZA_MEIGI_KANA"))
                    If .Rows(0)("FURI_KOZA_MEIGI_KANA") Is DBNull.Value Then
                        txt_FURI_KOZA_MEIGI_KANA.Text = ""
                    Else
                        txt_FURI_KOZA_MEIGI_KANA.Text = .Rows(0)("FURI_KOZA_MEIGI_KANA")
                    End If

                    '値セット前に入力可能にすると、一時的にBACKCOLORが変更されるので、
                    '値セット後に入力可能に変更する。
                    '金融情報入力可能
                    rbtn_BANK_ARI.Checked = True
                    f_BankEnable(True)

                End If

                '備考 
                txt_BIKO.Text = WordHenkan("N", "S", .Rows(0)("BIKO"))

                '入力状況  
                If WordHenkan("N", "S", .Rows(0)("NYURYOKU_JYOKYO")) = "2" Then
                    rbtn_NYURYOKU_JYOKYO1.Checked = True    '有
                Else
                    rbtn_NYURYOKU_JYOKYO2.Checked = True    '無
                End If

                '廃業日    HAIGYO_DATE
                If .Rows(0)("HAIGYO_DATE") Is DBNull.Value Then
                    date_HAIGYO_DATE.Value = Nothing
                Else
                    date_HAIGYO_DATE.Value = f_Str2DateOrNothing(WordHenkan("N", "S", .Rows(0)("HAIGYO_DATE")))
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

#Region "f_BankClear 金融機関クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_BankClear
    '説明            :金融機関クリア処理
    '引数            :Enable情報
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_BankClear() As Boolean
        Dim ret As Boolean = False

        Try

            '振込先コード
            cob_FURI_BANK_CD.SelectedIndex = -1
            cob_FURI_BANK_NM.SelectedIndex = -1
            '振込先支店コード
            cob_FURI_BANK_SITEN_CD.SelectedIndex = -1
            cob_FURI_BANK_SITEN_NM.SelectedIndex = -1
            '口座種別   
            cob_FURI_KOZA_SYUBETU.SelectedIndex = -1
            cob_FURI_KOZA_SYUBETU_NM.SelectedIndex = -1
            '口座番号 
            txt_FURI_KOZA_NO.Text = ""
            '口座名義人I
            txt_FURI_KOZA_MEIGI.Text = ""
            '口座名義人（カナ
            txt_FURI_KOZA_MEIGI_KANA.Text = ""

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region
#Region "f_BankEnable 金融機関入力制御処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_BankEnable
    '説明            :金融機関入力制御処理
    '引数            :Enable情報
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_BankEnable(ByVal wEnable As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            '振込先コード
            cob_FURI_BANK_CD.Enabled = wEnable
            cob_FURI_BANK_NM.Enabled = wEnable
            '振込先支店コード
            cob_FURI_BANK_SITEN_CD.Enabled = wEnable
            cob_FURI_BANK_SITEN_NM.Enabled = wEnable
            '口座種別   
            cob_FURI_KOZA_SYUBETU.Enabled = wEnable
            cob_FURI_KOZA_SYUBETU_NM.Enabled = wEnable
            '口座番号 
            txt_FURI_KOZA_NO.Enabled = wEnable
            '口座名義人I
            txt_FURI_KOZA_MEIGI.Enabled = wEnable
            '口座名義人（カナ
            txt_FURI_KOZA_MEIGI_KANA.Enabled = wEnable

            'このコーディングを入れると、動きがおきしくなるため、削除
            ''振込先コード
            'cob_FURI_BANK_CD.InputCheck = wEnable
            'cob_FURI_BANK_NM.InputCheck = wEnable
            ''振込先支店コード
            'cob_FURI_BANK_SITEN_CD.InputCheck = wEnable
            'cob_FURI_BANK_SITEN_NM.InputCheck = wEnable
            ''口座種別   
            'cob_FURI_KOZA_SYUBETU.InputCheck = wEnable
            'cob_FURI_KOZA_SYUBETU_NM.InputCheck = wEnable
            ''口座番号 
            'txt_FURI_KOZA_NO.InputCheck = wEnable
            ''口座名義人I
            'txt_FURI_KOZA_MEIGI.InputCheck = wEnable
            ''口座名義人（カナ
            'txt_FURI_KOZA_MEIGI_KANA.InputCheck = wEnable


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

        Dim sSql As String = String.Empty
        Dim dstDataSet As New DataSet

        Try

            '==FromToチェック==================



            '==必須チェック==================

            wkControlName = "契約者番号"
            wkControl = txt_KEIYAKUSYA_CD
            If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "都道府県"
            wkControl = cob_KEN_CD
            If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "契約区分"
            wkControl = cob_KEIYAKU_KBN
            If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "契約状況"
            wkControl = cob_KEIYAKU_JYOKYO
            If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "契約者名（フリガナ）"
            wkControl = txt_KEIYAKUSYA_KANA
            If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "契約者名"
            wkControl = txt_KEIYAKUSYA_NAME
            If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "郵便番号"
            wkControl = msk_ADDR_POST
            If msk_ADDR_POST.Value Is Nothing Or msk_ADDR_POST.Value = "" Or msk_ADDR_POST.Value.Count <> 7 Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "住所2"
            wkControl = txt_ADDR_2
            If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "電話番号"
            wkControl = txt_ADDR_TEL1
            If wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If

            wkControlName = "事務委託先"
            wkControl = cob_JIMUITAKU_CD
            If wkControl.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
            End If


            If rbtn_BANK_ARI.Checked Then

                wkControlName = "金融機関"
                wkControl = cob_FURI_BANK_CD
                If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                    Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
                End If

                wkControlName = "金融機関(本支店) "
                wkControl = cob_FURI_BANK_SITEN_CD
                If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                    Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
                End If

                wkControlName = "口座種別"
                wkControl = cob_FURI_KOZA_SYUBETU
                If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                    Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
                End If

                wkControlName = "口座番号"
                wkControl = txt_FURI_KOZA_NO
                If wkControl.Text Is Nothing Or wkControl.Text = "" OrElse wkControl.Text.Count <> 7 Then
                    Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
                End If

                wkControlName = "口座名義人(カナ)"
                wkControl = txt_FURI_KOZA_MEIGI_KANA
                If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                    Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
                End If
                '↓2018/07/04　追加
                If f_chk_Zengin(wkControl.Text) = False Then
                    wkControl.Focus()
                    Exit Try
                End If
                '↑2018/07/04　追加

                wkControlName = "口座名義人"
                wkControl = txt_FURI_KOZA_MEIGI
                If wkControl.Text Is Nothing Or wkControl.Text = "" Then
                    Call Show_MessageBox_Add("W008", wkControlName) : wkControl.Focus() : Exit Try
                End If

            End If


            '==いろいろチェック==================

            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert '新規登録時チェック

                Case Enu_SyoriKubun.Update '更新時チェック

            End Select

            '住所４入力時、住所３が未入力はエラー
            If Not txt_ADDR_4.Text Is Nothing AndAlso Not txt_ADDR_4.Text = "" Then
                If txt_ADDR_3.Text Is Nothing OrElse txt_ADDR_3.Text = "" Then
                    Call Show_MessageBox_Add("I007", "前の住所入力欄が未入力です。")
                    txt_ADDR_4.Focus()
                    Exit Try
                End If
            End If

            '2021/07/12 JBD9020 新契約日追加 ADD START
            If date_KEIYAKU_DATE.Value Is Nothing OrElse date_KEIYAKU_DATE.Value = New Date Then
                '入力確認有無でありの場合契約日は必須入力
                If rbtn_NYURYOKU_JYOKYO1.Checked And cob_KEIYAKU_JYOKYO.Text <> "3" Then
                    Show_MessageBox_Add("I007", "入力確認有無で有を選択した場合、契約日を入力してください。")
                    date_KEIYAKU_DATE.Focus()
                    Exit Try
                End If
            Else
                '契約日は事業開始年度の4月1日より前はダメ
                Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI
                If date_KEIYAKU_DATE.Value < clsNENDO_KI.pJIGYO_NENDO & "/04/01" Then
                    Show_MessageBox_Add("I007", "契約日が事業開始年度より前の日付です。")
                    date_KEIYAKU_DATE.Focus()
                    Exit Try
                End If
                '契約日に未来日はダメ
                If date_KEIYAKU_DATE.Value > Format(Now, "yyyy/MM/dd") Then
                    Show_MessageBox_Add("I007", "契約日が未来日です。")
                    date_KEIYAKU_DATE.Focus()
                    Exit Try
                End If
            End If
            '2021/07/12 JBD9020 新契約日追加 ADD END

            '廃業日
            If date_HAIGYO_DATE.Value Is Nothing OrElse date_HAIGYO_DATE.Value = New Date Then
                '未入力
            Else
                '契約日なし
                If date_NYUHEN_DATE.Value Is Nothing Then
                    Show_MessageBox_Add("I007", "契約日の確定前に、" & "廃業日は入力できません。")
                    date_HAIGYO_DATE.Focus()
                    Exit Try
                Else
                    '契約日あり
                    If date_HAIGYO_DATE.Value < date_NYUHEN_DATE.Value Then
                        Show_MessageBox_Add("I007", "廃業日＜契約日は入力できません。")
                        date_HAIGYO_DATE.Focus()
                        Exit Try
                    End If
                End If
                '契約情報(契約日)チェック
                If Not f_KeiyakuJoho_Chk() Then
                    date_HAIGYO_DATE.Focus()
                    Exit Try
                End If
            End If

            '契約区分変更時
            If pSyoriKbn = Enu_SyoriKubun.Update AndAlso pOld_KEIYAKU_KBN <> cob_KEIYAKU_KBN.Text.Trim Then
                '積立データ(積立区分=1)チェック
                If Not f_Tumitate_Chk() Then
                    cob_KEIYAKU_KBN.Focus()
                    Exit Try
                End If

                '契約情報(鶏の種類)チェック
                If Not f_ToriKbn_Chk() Then
                    cob_KEIYAKU_KBN.Focus()
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
#Region "f_KeiyakuJoho_Chk契約情報(契約日)チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :F_KEIYAKU_JOHO_CHK
    '説明            :契約情報(契約日)チェック
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_KeiyakuJoho_Chk() As Boolean
        Dim ret As Boolean = False
        Dim sSql As String = String.Empty
        Dim dstDataSet As New DataSet
        Dim wStr As String = String.Empty

        Try

            '該当契約者の有効なデータの中で、最大の契約年月を取得
            '廃業日は、この契約年月以上でなくてはならない
            sSql &= " SELECT "
            sSql &= "  MAX(KEIYAKU_DATE_FROM) KEIYAKU_DATE_FROM "
            sSql &= " FROM"
            sSql &= "  TT_KEIYAKU_JOHO"
            sSql &= " WHERE KI = " & p1010_KI
            sSql &= "   AND KEIYAKUSYA_CD = " & txt_KEIYAKUSYA_CD.Text.Trim
            sSql &= "   AND DATA_FLG = 1"

            Call f_Select_ODP(dstDataSet, sSql)

            With dstDataSet.Tables(0)
                If .Rows.Count > 0 Then
                    '契約日
                    wStr = WordHenkan("N", "S", .Rows(0)("KEIYAKU_DATE_FROM"))
                    '契約情報の契約開始日≧廃業日はエラー
                    If wStr <> "" AndAlso CDate(wStr) >= f_DateTrim(date_HAIGYO_DATE.Value) Then
                        Show_MessageBox_Add("I007", "廃業日は、契約情報の契約年月日より" & vbCrLf & "後の日付をセットしてください。")
                        Exit Try
                    End If
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

#Region "f_Tumitate_Chk 積立デーチェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Tumitate_Chk
    '説明            :積立デーチェック処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Tumitate_Chk() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            '積立データ(積立区分=1)チェック
            wSql = ""
            wSql &= " SELECT "
            wSql &= "  KI,"
            wSql &= "  KEIYAKUSYA_CD,"
            wSql &= "  TUMITATE_KBN"
            wSql &= " FROM"
            wSql &= "  TT_TUMITATE"
            wSql &= " WHERE KI = " & p1010_KI
            wSql &= "   AND KEIYAKUSYA_CD = " & txt_KEIYAKUSYA_CD.Text.Trim
            wSql &= "   AND TUMITATE_KBN = 1"

            Call f_Select_ODP(wkDS, wSql)

            With wkDS.Tables(0)
                If .Rows.Count > 0 Then
                    '積立データ有のとき、変更不可
                    Show_MessageBox_Add("I007", "今事業期の積立金が存在する契約者は" & vbCrLf & "契約区分の変更はできません")
                    Exit Try
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
#Region "f_ToriKbn_Chk 契約情報(鶏の種類)チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_CopyData_Chk
    '説明            :前期データチェック処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ToriKbn_Chk() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        'pOld_KEIYAKU_KBN <> cob_KEIYAKU_KBN.Text.Trim

        Try

            'うずら以外のデータ件数
            wSql &= "SELECT"
            wSql &= "  COUNT(*) CNT "
            wSql &= "FROM TT_KEIYAKU_JOHO "
            wSql &= "WHERE KI = " & p1010_KI
            wSql &= " AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= " AND DATA_FLG = 1"
            'wSql &= " AND TORI_KBN <> 6"   '2017/07/10　修正
            wSql &= " AND TORI_KBN < 6"     '2017/07/10　修正

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Exit Try
            End If

            'データ有無

            If wkDS.Tables(0).Rows.Count > 0 Then
                '2015/11/05　修正開始
                'If CInt(WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("CNT"))) > 0 Then
                '    Show_MessageBox_Add("I007", "契約情報にうずら以外が登録されているため" & vbCrLf & "契約区分にうずらは指定できません。")
                '    Exit Try
                'End If
                If cob_KEIYAKU_KBN.Text = "3" Then
                    If CInt(WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("CNT"))) > 0 Then
                        'Show_MessageBox_Add("I007", "契約情報にうずら以外が登録されているため" & vbCrLf & "契約区分にうずらは指定できません。") '2017/07/10　修正
                        Show_MessageBox_Add("I007", "採卵鶏・肉用鶏・種鶏が登録されているため" & vbCrLf &
                                                    "契約区分に鶏以外は指定できません。")  '2017/07/10　修正
                        Exit Try
                    End If
                End If
                '2015/11/05　修正終了
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region
#Region "s_Set_RecValidate 行遷移ボタン制御"
    '------------------------------------------------------------------
    'プロシージャ名  :s_Set_RecValidate
    '説明            :行遷移ボタン制御
    '引数            :行番号
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Sub s_Set_RecValidate()
        Dim intRecMax As Integer = 0

        Try

            If txt_Now.Text.TrimEnd = "" OrElse txt_Now.Text.TrimEnd <= 0 Then
                txt_Now.Text = 1
            End If

            If lblTotal.Text.TrimEnd = "" OrElse lblTotal.Text.TrimEnd = "0" Then
                lblTotal.Text = "1"
            End If

            intRecMax = CInt(lblTotal.Text.TrimEnd)

            If txt_Now.Text.TrimEnd > intRecMax Then
                txt_Now.Text = intRecMax
            End If

            If lblTotal.Text = 1 Then
                '該当データ１件のみ
                cmdTop.Enabled = False
                cmdBef.Enabled = False
                cmdNext.Enabled = False
                cmdLast.Enabled = False
            ElseIf txt_Now.Text.TrimEnd = 1 OrElse txt_Now.Text.TrimEnd = 0 Then
                '先頭行を表示
                cmdTop.Enabled = False
                cmdBef.Enabled = False
                cmdNext.Enabled = True
                cmdLast.Enabled = True
            ElseIf txt_Now.Text.TrimEnd = intRecMax Then
                '最終行を表示
                cmdTop.Enabled = True
                cmdBef.Enabled = True
                cmdNext.Enabled = False
                cmdLast.Enabled = False
            Else
                '中間の行を表示
                cmdTop.Enabled = True
                cmdBef.Enabled = True
                cmdNext.Enabled = True
                cmdLast.Enabled = True
            End If

            pSel_NO = CInt(txt_Now.Text.TrimEnd)

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region
#End Region

End Class
