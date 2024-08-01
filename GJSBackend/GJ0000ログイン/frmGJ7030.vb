'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ7030.vb
'*
'*　　②　機能概要　　　　　互助基金契約者互助金情報検索ＣＳＶデータ作成
'*
'*　　③　作成日　　　　　　2015/02/22　BY JBD
'*
'*　　④　更新日            2022/02/08  BY JBD437  R03年度減額対応
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

Public Class frmGJ7030

#Region "変数定義"

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
    Public paryKEY_7030 As New List(Of T_KEY)

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
    Private Sub frmXXXLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean
        Try

            pInitKi = New Obj_TM_SYORI_NENDO_KI().pKI
            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear("C")

            '期にフォーカスセット
            numKI.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

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
            If Not f_Input_Check(wkAlertFlag) Then
                Exit Try
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
                cmdCsv.Enabled = True
                lblCOUNT_HED.Text = pDataSet.Tables(0).Rows.Count.ToString("#,##0")
                'lblCOUNT_DTL.Text = dgv_Search.Item("COUNT_DTL", 0).Value.ToString("#,##0")
                lblCOUNT_DTL.Text = CInt(pDataSet.Tables(0).Rows(0).Item("COUNT_DTL")).ToString("#,##0")

            Else
                cmdCsv.Enabled = False
                lblCOUNT_HED.Text = "0"
                lblCOUNT_DTL.Text = "0"
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

#Region "cmdCsv_Click CSV出力ボタンクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdCsv_Click
    '説明            :CSV出力ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdCsv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs, Optional ByVal wkAlertFlag As Boolean = True) Handles cmdCsv.Click
        Dim sSql As String = String.Empty
        Dim wkDS As New DataSet
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '画面入力チェック(エラー表示あり)
            If Not f_Input_Check() Then
                Exit Try
            End If

            'SQL作成
            If Not f_Search_SQLMake(1, sSql) Then
                Exit Try
            End If

            'SQL実行
            If Not f_Select_ODP(wkDS, sSql) Then
                Exit Try
            End If

            'CSV作成
            '↓2017/07/14 追加 追加納付を追加
            'f_makeCSVByDT(wkDS.Tables(0), "GOJOKIN_")
            If pKikin2 Then
                f_makeCSVByDT(wkDS.Tables(0), "GOJOKIN(追加納付)_")
            Else
                f_makeCSVByDT(wkDS.Tables(0), "GOJOKIN_")
            End If
            '↑2017/07/14 修正 追加納付を追加

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

#Region "cmdClear_Click 条件クリアボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdClear_Click
    '説明            :条件クリアボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClear.Click

        Dim ret As Boolean

        ret = f_ObjectClear("")

        'データ区分にフォーカスセット
        numKI.Focus()

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
    'プロシージャ名  :numKI_Enter
    '説明            :期Enterイベント
    '------------------------------------------------------------------
    Private Sub numKI_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles numKI.Enter

        If numKI.Value Is Nothing Then
            pEnterKi = 0
        Else
            pEnterKi = numKI.Value
        End If

    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :numKI_Validated
    '説明            :期Validatedベント
    '------------------------------------------------------------------
    Private Sub numKI_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles numKI.Validated
        Dim ret As Boolean = False

        Try

            '未入力のとき、事務委託先コンボクリア
            If numKI.Text = "" Then
                cboITAKU_Cd_Fm.DataSource = Nothing
                cboITAKU_Cd_Fm.Clear()
                cboITAKU_Nm_Fm.DataSource = Nothing
                cboITAKU_Nm_Fm.Clear()
                cboITAKU_Cd_To.DataSource = Nothing
                cboITAKU_Cd_To.Clear()
                cboITAKU_Nm_To.DataSource = Nothing
                cboITAKU_Nm_To.Clear()

                cboKEIYAKUSYA_Cd_Fm.DataSource = Nothing
                cboKEIYAKUSYA_Cd_Fm.Clear()
                cboKEIYAKUSYA_Nm_Fm.DataSource = Nothing
                cboKEIYAKUSYA_Nm_Fm.Clear()
                cboKEIYAKUSYA_Cd_To.DataSource = Nothing
                cboKEIYAKUSYA_Cd_To.Clear()
                cboKEIYAKUSYA_Nm_To.DataSource = Nothing
                cboKEIYAKUSYA_Nm_To.Clear()

                Exit Try
            End If

            '期に変更無し
            If CInt(numKI.Text) = CInt(pEnterKi) Then
                Exit Try
            End If

            '期が変更になった場合、事務委託先コンボ再セット
            ret = f_ComboBox_Set("", numKI.Text.Trim.ToString)


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#Region "都道府県関連"

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_F_SelectedIndexChanged
    '説明            :都道府県コード(FROM)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_F_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobKEN_Cd_Fm.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cobKEN_Nm_Fm.SelectedIndex = cobKEN_Cd_Fm.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KenNm_F_SelectedIndexChanged
    '説明            :都道府県名(FROM)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KenNm_F_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobKEN_Nm_Fm.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        s_CboMeiFrom_SelectedIndexChanged(cobKEN_Nm_Fm, cobKEN_Cd_Fm, cobKEN_Nm_To, cobKEN_Cd_To)


    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_F_Validating
    '説明            :都道府県コード(FROM)確定中処理
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_F_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cobKEN_Cd_Fm.Validating

        Call s_CboFrom_Validating(cobKEN_Cd_Fm, cobKEN_Nm_Fm, cobKEN_Cd_To, cobKEN_Nm_To)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_T_SelectedIndexChanged
    '説明            :都道府県コード(TO)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_T_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobKEN_Cd_To.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cobKEN_Nm_To.SelectedIndex = cobKEN_Cd_To.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KenNm_F_SelectedIndexChanged
    '説明            :都道府県名(TO)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KenNm_T_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobKEN_Nm_To.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        s_CboMeiTo_Validating(cobKEN_Nm_To, cobKEN_Cd_To, cobKEN_Nm_Fm, cobKEN_Cd_Fm)

    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_T_Validating
    '説明            :都道府県コード(TO)確定中処理
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_T_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cobKEN_Cd_To.Validating

        Call s_CboTo_Validating(cobKEN_Cd_To, cobKEN_Nm_To, cobKEN_Cd_Fm, cobKEN_Nm_Fm)

    End Sub

#End Region

#Region "契約者FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKUSYA_Cd_Fm_SelectedIndexChanged
    '説明            :契約者コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKUSYA_Cd_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKUSYA_Cd_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboKEIYAKUSYA_Nm_Fm.SelectedIndex = cboKEIYAKUSYA_Cd_Fm.SelectedIndex
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKUSYA_Nm_Fm_SelectedIndexChanged
    '説明            :契約者名FromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKUSYA_Nm_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKUSYA_Nm_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiFrom_SelectedIndexChanged(cboKEIYAKUSYA_Nm_Fm, cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_To, cboKEIYAKUSYA_Cd_To)
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKUSYA_Cd_Fm_Validating
    '説明            :契約者コードFromValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKUSYA_Cd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboKEIYAKUSYA_Cd_Fm.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboFrom_Validating(cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm, cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To, "2")
    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKUSYA_Cd_To_SelectedIndexChanged
    '説明            :契約者コードToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKUSYA_Cd_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKUSYA_Cd_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboKEIYAKUSYA_Nm_To.SelectedIndex = cboKEIYAKUSYA_Cd_To.SelectedIndex
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKUSYA_Nm_To_SelectedIndexChanged
    '説明            :契約者名ToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKUSYA_Nm_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKUSYA_Nm_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiTo_Validating(cboKEIYAKUSYA_Nm_To, cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_Fm, cboKEIYAKUSYA_Cd_Fm)
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKUSYA_Cd_To_Validating
    '説明            :契約者コードToValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKUSYA_Cd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboKEIYAKUSYA_Cd_To.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboTo_Validating(cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To, cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm, "2")
    End Sub
#End Region

#Region "契約区分FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_KBN_Cd_Fm_SelectedIndexChanged
    '説明            :契約区分コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_KBN_Cd_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKU_KBN_Cd_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboKEIYAKU_KBN_Nm_Fm.SelectedIndex = cboKEIYAKU_KBN_Cd_Fm.SelectedIndex
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_KBN_Nm_Fm_SelectedIndexChanged
    '説明            :契約区分名FromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_KBN_Nm_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKU_KBN_Nm_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiFrom_SelectedIndexChanged(cboKEIYAKU_KBN_Nm_Fm, cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_To, cboKEIYAKU_KBN_Cd_To)
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_KBN_Cd_Fm_Validating
    '説明            :契約区分コードFromValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_KBN_Cd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboKEIYAKU_KBN_Cd_Fm.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboFrom_Validating(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_Fm, cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To)
    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_KBN_Cd_To_SelectedIndexChanged
    '説明            :契約区分コードToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_KBN_Cd_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKU_KBN_Cd_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboKEIYAKU_KBN_Nm_To.SelectedIndex = cboKEIYAKU_KBN_Cd_To.SelectedIndex
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_KBN_Nm_To_SelectedIndexChanged
    '説明            :契約区分名ToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_KBN_Nm_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKU_KBN_Nm_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiTo_Validating(cboKEIYAKU_KBN_Nm_To, cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_Fm, cboKEIYAKU_KBN_Cd_Fm)
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_KBN_Cd_To_Validating
    '説明            :契約区分コードToValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_KBN_Cd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboKEIYAKU_KBN_Cd_To.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboTo_Validating(cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To, cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_Fm)
    End Sub


#End Region

#Region "契約状況FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_JYOKYO_Cd_Fm_SelectedIndexChanged
    '説明            :契約状況コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_JYOKYO_Cd_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKU_JYOKYO_Cd_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboKEIYAKU_JYOKYO_Nm_Fm.SelectedIndex = cboKEIYAKU_JYOKYO_Cd_Fm.SelectedIndex
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_JYOKYO_Nm_Fm_SelectedIndexChanged
    '説明            :契約状況名FromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_JYOKYO_Nm_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKU_JYOKYO_Nm_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiFrom_SelectedIndexChanged(cboKEIYAKU_JYOKYO_Nm_Fm, cboKEIYAKU_JYOKYO_Cd_Fm, cboKEIYAKU_JYOKYO_Nm_To, cboKEIYAKU_JYOKYO_Cd_To)
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_JYOKYO_Cd_Fm_Validating
    '説明            :契約状況コードFromValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_JYOKYO_Cd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboKEIYAKU_JYOKYO_Cd_Fm.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboFrom_Validating(cboKEIYAKU_JYOKYO_Cd_Fm, cboKEIYAKU_JYOKYO_Nm_Fm, cboKEIYAKU_JYOKYO_Cd_To, cboKEIYAKU_JYOKYO_Nm_To)
    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_JYOKYO_Cd_To_SelectedIndexChanged
    '説明            :契約状況コードToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_JYOKYO_Cd_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKU_JYOKYO_Cd_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboKEIYAKU_JYOKYO_Nm_To.SelectedIndex = cboKEIYAKU_JYOKYO_Cd_To.SelectedIndex
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_JYOKYO_Nm_To_SelectedIndexChanged
    '説明            :契約状況名ToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_JYOKYO_Nm_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboKEIYAKU_JYOKYO_Nm_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiTo_Validating(cboKEIYAKU_JYOKYO_Nm_To, cboKEIYAKU_JYOKYO_Cd_To, cboKEIYAKU_JYOKYO_Nm_Fm, cboKEIYAKU_JYOKYO_Cd_Fm)
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboKEIYAKU_JYOKYO_Cd_To_Validating
    '説明            :契約状況コードToValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboKEIYAKU_JYOKYO_Cd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboKEIYAKU_JYOKYO_Cd_To.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboTo_Validating(cboKEIYAKU_JYOKYO_Cd_To, cboKEIYAKU_JYOKYO_Nm_To, cboKEIYAKU_JYOKYO_Cd_Fm, cboKEIYAKU_JYOKYO_Nm_Fm)
    End Sub
#End Region

#Region "事務委託先FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboITAKU_Cd_Fm_SelectedIndexChanged
    '説明            :事務委託先コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboITAKU_Cd_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboITAKU_Cd_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboITAKU_Nm_Fm.SelectedIndex = cboITAKU_Cd_Fm.SelectedIndex
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboITAKU_Nm_Fm_SelectedIndexChanged
    '説明            :事務委託先名FromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboITAKU_Nm_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboITAKU_Nm_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiFrom_SelectedIndexChanged(cboITAKU_Nm_Fm, cboITAKU_Cd_Fm, cboITAKU_Nm_To, cboITAKU_Cd_To)
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboITAKU_Cd_Fm_Validating
    '説明            :事務委託先コードFromValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboITAKU_Cd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboITAKU_Cd_Fm.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboFrom_Validating(cboITAKU_Cd_Fm, cboITAKU_Nm_Fm, cboITAKU_Cd_To, cboITAKU_Nm_To, "2")
    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cboITAKU_Cd_To_SelectedIndexChanged
    '説明            :事務委託先コードToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboITAKU_Cd_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboITAKU_Cd_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboITAKU_Nm_To.SelectedIndex = cboITAKU_Cd_To.SelectedIndex
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboITAKU_Nm_To_SelectedIndexChanged
    '説明            :事務委託先名ToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboITAKU_Nm_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboITAKU_Nm_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiTo_Validating(cboITAKU_Nm_To, cboITAKU_Cd_To, cboITAKU_Nm_Fm, cboITAKU_Cd_Fm)
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboITAKU_Cd_To_Validating
    '説明            :事務委託先コードToValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboITAKU_Cd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboITAKU_Cd_To.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboTo_Validating(cboITAKU_Cd_To, cboITAKU_Nm_To, cboITAKU_Cd_Fm, cboITAKU_Nm_Fm, "2")
    End Sub
#End Region

#Region "発生回数関連"
    '------------------------------------------------------------------
    'プロシージャ名  :dateKOFUTUTI_HAKKO_Ymd_Fm_Validating
    '説明            :発生回数FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateHASSEI_KAISU_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numHASSEI_KAISU_Fm.Validating

        Call s_From_Validating(numHASSEI_KAISU_Fm, numHASSEI_KAISU_To)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :dateKOFUTUTI_HAKKO_Ymd_To_Validating
    '説明            :発生回数TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateHASSEI_KAISU_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numHASSEI_KAISU_To.Validating

        'Call s_To_Validating(numHASSEI_KAISU_To, numHASSEI_KAISU_Fm)

    End Sub
#End Region

#Region "交付通知書発行日関連"
    '------------------------------------------------------------------
    'プロシージャ名  :dateKOFUTUTI_HAKKO_Ymd_Fm_Validating
    '説明            :交付通知書発行日FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateKOFUTUTI_HAKKO_Ymd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateKOFUTUTI_HAKKO_Ymd_Fm.Validating

        Call s_From_Validating(dateKOFUTUTI_HAKKO_Ymd_Fm, dateKOFUTUTI_HAKKO_Ymd_To)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :dateKOFUTUTI_HAKKO_Ymd_To_Validating
    '説明            :交付通知書発行日TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateKOFUTUTI_HAKKO_Ymd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateKOFUTUTI_HAKKO_Ymd_To.Validating

        'Call s_To_Validating(dateNYUKIN_Ymd_To, dateNYUKIN_Ymd_Fm)

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

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '画面初期化
            pJump = True
            f_ClearFormALL(Me, wKbn)
            numKI.Text = pInitKi        '期
            dateTAISYO_Ym.Value = Now   '対象年月
            '交付通知書チェックボックス
            chkKOFUTUTI_1.Checked = True
            chkKOFUTUTI_2.Checked = True

            rbtnOutMEISAI.Checked = True
            rbtnSearchAnd.Checked = True

            lblCOUNT_HED.Text = "0"     '抽出件数
            lblCOUNT_DTL.Text = "0"     '抽出件数

            '変数クリア
            paryKEY_7030 = New List(Of T_KEY)
            If Not pDataSet Is Nothing Then
                pDataSet.Clear()
            End If

            cmdCsv.Enabled = False

            'コンボボックスセット
            ret = f_ComboBox_Set(wKbn, numKI.Text)

            pJump = False


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
    Private Function f_ComboBox_Set(ByVal wKbn As String, ByVal wKI As String) As Boolean
        Dim ret As Boolean = False
        Dim wWhere As String = String.Empty

        Try
            pJump = True
            '初期処理
            If wKbn = "C" Then

                '県マスタコンボセット
                'FROM
                If Not f_Ken_Data_Select(cobKEN_Cd_Fm, cobKEN_Nm_Fm, True) Then
                    Exit Try
                End If
                'TO
                If Not f_Ken_Data_Select(cobKEN_Cd_To, cobKEN_Nm_To, True) Then
                    Exit Try
                End If


                '契約区分
                'FROM
                'If Not f_CodeMaster_Data_Select(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_Fm, 1, True, 1) Then '2017/07/11 修正
                If Not f_CodeMaster_Data_Select(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Nm_Fm, 1, True, 0) Then  '2017/07/11 修正
                    Exit Try
                End If
                'TO
                'If Not f_CodeMaster_Data_Select(cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To, 1, True, 1) Then '2017/07/11 修正
                If Not f_CodeMaster_Data_Select(cboKEIYAKU_KBN_Cd_To, cboKEIYAKU_KBN_Nm_To, 1, True, 0) Then  '2017/07/11 修正
                    Exit Try
                End If

                '契約状況
                'FROM
                If Not f_CodeMaster_Data_Select(cboKEIYAKU_JYOKYO_Cd_Fm, cboKEIYAKU_JYOKYO_Nm_Fm, 2, True, 1) Then
                    Exit Try
                End If
                'TO
                If Not f_CodeMaster_Data_Select(cboKEIYAKU_JYOKYO_Cd_To, cboKEIYAKU_JYOKYO_Nm_To, 2, True, 1) Then
                    Exit Try
                End If



                'コンボボックス初期化
                cobKEN_Cd_Fm.Text = ""
                cobKEN_Cd_To.Text = ""
                cboKEIYAKUSYA_Cd_Fm.Text = ""
                cboKEIYAKUSYA_Cd_To.Text = ""
                cboKEIYAKU_KBN_Cd_Fm.Text = ""
                cboKEIYAKU_KBN_Cd_To.Text = ""
                cboKEIYAKU_JYOKYO_Cd_Fm.Text = ""
                cboKEIYAKU_JYOKYO_Cd_To.Text = ""
                cboITAKU_Cd_Fm.Text = ""
                cboITAKU_Cd_To.Text = ""


            End If

            '期が未入力のとき
            If wKI = "" OrElse wKI = String.Empty Then
                cboITAKU_Cd_Fm.DataSource = Nothing
                cboITAKU_Cd_Fm.Clear()
                cboITAKU_Nm_Fm.DataSource = Nothing
                cboITAKU_Nm_Fm.Clear()
                cboITAKU_Cd_To.DataSource = Nothing
                cboITAKU_Cd_To.Clear()
                cboITAKU_Nm_To.DataSource = Nothing
                cboITAKU_Nm_To.Clear()

                cboKEIYAKUSYA_Cd_Fm.DataSource = Nothing
                cboKEIYAKUSYA_Cd_Fm.Clear()
                cboKEIYAKUSYA_Nm_Fm.DataSource = Nothing
                cboKEIYAKUSYA_Nm_Fm.Clear()
                cboKEIYAKUSYA_Cd_To.DataSource = Nothing
                cboKEIYAKUSYA_Cd_To.Clear()
                cboKEIYAKUSYA_Nm_To.DataSource = Nothing
                cboKEIYAKUSYA_Nm_To.Clear()
                Exit Try
            End If

            '事務委託先マスタコンボセット
            wWhere = "KI = " & wKI
            If Not f_JimuItaku_Data_Select(cboITAKU_Cd_Fm, cboITAKU_Nm_Fm, wWhere, True) Then
                Exit Try
            End If
            If Not f_JimuItaku_Data_Select(cboITAKU_Cd_To, cboITAKU_Nm_To, wWhere, True) Then
                Exit Try
            End If

            '契約者番号マスタコンボセット
            wWhere = "KI = " & wKI
            If Not f_Keiyaku_Data_Select(cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Nm_Fm, wWhere, True) Then
                Exit Try
            End If
            If Not f_Keiyaku_Data_Select(cboKEIYAKUSYA_Cd_To, cboKEIYAKUSYA_Nm_To, wWhere, True) Then
                Exit Try
            End If


            'コンボボックス初期化
            cboITAKU_Cd_Fm.Text = ""
            cboITAKU_Cd_To.Text = ""

            cboKEIYAKU_KBN_Cd_Fm.Text = ""
            cboKEIYAKU_KBN_Cd_To.Text = ""

            pJump = False
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
    Private Function f_Input_Check(Optional ByVal wkAlertFlag As Boolean = True) As Boolean
        Dim ret As Boolean = False

        Try


            '==必須チェック================== 
            '期入力なし
            If numKI.Text.Trim = "" Then
                Show_MessageBox_Add("W008", "期")
                numKI.Focus()
                Exit Try
            End If

            '対象年月入力なし
            If dateTAISYO_Ym.Value Is Nothing Then
                Show_MessageBox_Add("W008", "対象年月")
                dateTAISYO_Ym.Focus()
                Exit Try
            End If

            '交付通知書チェックボックス
            If chkKOFUTUTI_1.Checked = False And chkKOFUTUTI_2.Checked = False Then
                Show_MessageBox_Add("W008", "交付通知書")
                chkKOFUTUTI_1.Focus()
                Exit Try
            End If




            '==FromToチェック==================
            '都道府県
            If f_Daisyo_Check(cobKEN_Cd_Fm, cobKEN_Cd_To, "都道府県", True, 1) = False Then
                Exit Try
            End If

            '契約者番号
            If f_Daisyo_Check(cboKEIYAKUSYA_Cd_Fm, cboKEIYAKUSYA_Cd_To, "契約者番号", True, 1) = False Then
                Exit Try
            End If

            '契約区分
            If f_Daisyo_Check(cboKEIYAKU_KBN_Cd_Fm, cboKEIYAKU_KBN_Cd_To, "契約区分", True, 1) = False Then
                Exit Try
            End If

            '契約状況
            If f_Daisyo_Check(cboKEIYAKU_JYOKYO_Cd_Fm, cboKEIYAKU_JYOKYO_Cd_To, "契約状況", True, 1) = False Then
                Exit Try
            End If

            '事務委託先
            If f_Daisyo_Check(cboITAKU_Cd_Fm, cboITAKU_Cd_To, "事務委託先", True, 1) = False Then
                Exit Try
            End If

            '↓2022/02/08 JBD437 UPD R03年度減額対応
            '発生回数
            'If f_Daisyo_Check(numHASSEI_KAISU_Fm, numHASSEI_KAISU_To, "発生回数", True, 1) = False Then
            '認定回数
            If f_Daisyo_Check(numHASSEI_KAISU_Fm, numHASSEI_KAISU_To, "認定回数", True, 1) = False Then
                '↑2022/02/08 JBD437 UPD R03年度減額対応
                Exit Try
            End If

            '通知書発行日
            If f_Daisyo_Check(dateKOFUTUTI_HAKKO_Ymd_Fm, dateKOFUTUTI_HAKKO_Ymd_To, "通知書発行日", True, 2) = False Then
                Exit Try
            End If

            '==いろいろチェック==================



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
        Dim wANDorOR As String = String.Empty
        Dim wWhere As String = String.Empty
        Dim strChekVal As String

        Try

            'ＳＱＬ
            wSql = ""

            If rbtnSearchAnd.Checked Then
                '検索方法で[すべてを含む]を選択
                wANDorOR = " AND "
            Else
                '検索方法で[いずれかを含む]を選択
                wANDorOR = " OR "
            End If

            '==オプション条件====================
            ' 以下は省略可能な条件なので指定されていた場合にのみ編集
            ' 但し、検索方法が全てを含むなのかいずれかを含むなのかによりwkANDorORの内容がANDかORに変わる

            '都道府県FROM
            If cobKEN_Cd_Fm.Text.Trim <> "" AndAlso cobKEN_Cd_To.Text.Trim <> "" Then
                wWhere = "(" & " KEI.KEN_CD BETWEEN " & cobKEN_Cd_Fm.Text.Trim & " and " & cobKEN_Cd_To.Text.Trim & ")"
            End If

            '契約者番号FROM
            If cboKEIYAKUSYA_Cd_Fm.Text.Trim <> "" AndAlso cboKEIYAKUSYA_Cd_To.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " KEI.KEIYAKUSYA_CD BETWEEN " & cboKEIYAKUSYA_Cd_Fm.Text.Trim & " and " & cboKEIYAKUSYA_Cd_To.Text.Trim & ")"
            End If

            '契約区分FROM
            If cboKEIYAKU_KBN_Cd_Fm.Text.Trim <> "" AndAlso cboKEIYAKU_KBN_Cd_To.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " KEI.KEIYAKU_KBN BETWEEN " & cboKEIYAKU_KBN_Cd_Fm.Text.Trim & " and " & cboKEIYAKU_KBN_Cd_To.Text.Trim & ")"
            End If

            '契約状況FROM
            If cboKEIYAKU_JYOKYO_Cd_Fm.Text.Trim <> "" AndAlso cboKEIYAKU_JYOKYO_Cd_To.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " KEI.KEIYAKU_JYOKYO BETWEEN " & cboKEIYAKU_JYOKYO_Cd_Fm.Text.Trim & " and " & cboKEIYAKU_JYOKYO_Cd_To.Text.Trim & ")"
            End If

            '事務委託先FROM
            If cboITAKU_Cd_Fm.Text.Trim <> "" AndAlso cboITAKU_Cd_To.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " KEI.JIMUITAKU_CD BETWEEN " & cboITAKU_Cd_Fm.Text.Trim & " and " & cboITAKU_Cd_To.Text.Trim & ")"
            End If

            '発生回数FROM
            If numHASSEI_KAISU_Fm.Text.Trim <> "" AndAlso numHASSEI_KAISU_To.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " KOFU.HASSEI_KAISU BETWEEN " & numHASSEI_KAISU_Fm.Text.Trim & " and " & numHASSEI_KAISU_To.Text.Trim & ")"
            End If

            '交付通知書チェック
            strChekVal = ""
            If chkKOFUTUTI_1.Checked And chkKOFUTUTI_2.Checked Then
                '全チェック
            Else
                '発行済
                If chkKOFUTUTI_1.Checked Then
                    strChekVal = "2"
                End If
                '未発行
                If chkKOFUTUTI_2.Checked Then
                    strChekVal = "1"
                End If

                'SQL作成
                If strChekVal.Length > 0 Then
                    If wWhere <> "" Then
                        wWhere = wWhere & wANDorOR
                    End If
                    ' ３：入金（返還）済
                    wWhere &= "( KOFU.SYORI_JOKYO IN (" & strChekVal & ") )"
                End If
            End If


            '通知書発行日From
            If Not (dateKOFUTUTI_HAKKO_Ymd_Fm.Value Is Nothing) And Not (dateKOFUTUTI_HAKKO_Ymd_To.Value Is Nothing) Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " KOFU.KOFUTUTI_HAKKO_DATE BETWEEN TO_DATE('" & Format(dateKOFUTUTI_HAKKO_Ymd_Fm.Value, "yyyy/MM/dd").TrimEnd & "') and TO_DATE('" & Format(dateKOFUTUTI_HAKKO_Ymd_To.Value, "yyyy/MM/dd").TrimEnd & "'))"
            End If

            '条件編集
            If wWhere <> "" Then
                wWhere = "  AND (" & wWhere & ")"
            End If

            Select Case wKbn
                Case 0  '検索ボタンクリック時の検索条件

                    '==SQL作成====================
                    wSql = "SELECT"
                    wSql &= "     DTL.KI AS KI"
                    wSql &= "    ,DTL.HASSEI_KAISU AS HASSEI_KAISU"
                    wSql &= "    ,DTL.KEIYAKUSYA_CD AS KEIYAKUSYA_CD"
                    wSql &= "    ,MAX(DTL.KEIYAKUSYA_NAME) AS KEIYAKUSYA_NAME"
                    wSql &= "    ,MAX(DTL.KEIYAKUSYA_KANA) AS KEIYAKUSYA_KANA"
                    wSql &= "    ,MAX(DTL.KEIYAKU_KBN) AS KEIYAKU_KBN"
                    wSql &= "    ,MAX(DTL.KEIYAKU_KBN_NM) AS KEIYAKU_KBN_NM"
                    wSql &= "    ,MAX(DTL.KEN_CD) AS KEN_CD"
                    wSql &= "    ,MAX(DTL.KEN_CD_NM) AS KEN_CD_NM"
                    wSql &= "    ,MAX(DTL.JIMUITAKU_CD) AS JIMUITAKU_CD"
                    wSql &= "    ,MAX(DTL.ITAKU_NAME) AS ITAKU_NAME"
                    wSql &= "    ,MAX(DTL.FURIKOMI_YOTEI_DATE) AS FURIKOMI_YOTEI_DATE"
                    wSql &= "    ,MAX(DTL.KOFU_KIN_KEI) AS KOFU_KIN_KEI"
                    wSql &= "    ,MAX(DTL.DLT_CNT) AS COUNT_DTL"
                    wSql &= " FROM"
                    wSql &= "    ("
                    wSql &= "    SELECT"
                    wSql &= "         KOFU.KI AS KI"
                    wSql &= "        ,KOFU.HASSEI_KAISU AS HASSEI_KAISU"
                    wSql &= "        ,KOFU.KEIYAKUSYA_CD AS KEIYAKUSYA_CD"
                    wSql &= "        ,KEI.KEIYAKUSYA_NAME AS KEIYAKUSYA_NAME"
                    wSql &= "        ,KEI.KEIYAKUSYA_KANA AS KEIYAKUSYA_KANA"
                    wSql &= "        ,KEI.KEIYAKU_KBN AS KEIYAKU_KBN"
                    '↓2017/07/13 修正 契約区分
                    'wSql &= "        ,CD01.RYAKUSYO AS KEIYAKU_KBN_NM"
                    wSql &= "        ,CD01.MEISYO AS KEIYAKU_KBN_NM"
                    '↑2017/07/13 修正 契約区分
                    wSql &= "        ,KEI.KEN_CD AS KEN_CD"
                    'wSql &= "        ,CD05.RYAKUSYO AS KEN_CD_NM"
                    wSql &= "        ,LPAD(KEI.KEN_CD,2) || CD05.RYAKUSYO KEN_CD_NM"
                    wSql &= "        ,KEI.JIMUITAKU_CD AS JIMUITAKU_CD"
                    wSql &= "        ,ITK.ITAKU_NAME AS ITAKU_NAME"
                    wSql &= "        ,TO_CHAR(KOFU.FURIKOMI_YOTEI_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS FURIKOMI_YOTEI_DATE"
                    wSql &= "        ,KOFU.KOFU_KIN_KEI AS KOFU_KIN_KEI"
                    wSql &= "        ,COUNT(KOFU.KI) OVER() AS DLT_CNT"
                    wSql &= "    FROM TT_KOFU KOFU"
                    wSql &= "        ,TT_KOFU_SINSEI SINSEI "
                    wSql &= "        ,TM_KEIYAKU KEI"
                    wSql &= "        ,TM_KEIYAKU_NOJO NOJO"
                    wSql &= "        ,TM_CODE CD01"
                    wSql &= "        ,TM_CODE CD05"
                    wSql &= "        ,TM_CODE CD05N"
                    wSql &= "        ,TM_CODE CD07"
                    wSql &= "        ,TM_JIMUITAKU ITK"
                    wSql &= "    WHERE"
                    '                 -- 契約者マスタ
                    wSql &= "         KOFU.KI = KEI.KI(+)"
                    wSql &= "     AND KOFU.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+)"
                    '                 -- 互助金申請
                    wSql &= "     AND KOFU.KI = SINSEI.KI(+)"
                    wSql &= "     AND KOFU.KEIYAKUSYA_CD = SINSEI.KEIYAKUSYA_CD(+)"
                    wSql &= "     AND KOFU.HASSEI_KAISU = SINSEI.HASSEI_KAISU(+)"
                    wSql &= "     AND KOFU.KEISAN_KAISU = SINSEI.KEISAN_KAISU(+)"
                    '                 -- 契約者農場マスタ
                    wSql &= "     AND SINSEI.KI = NOJO.KI(+)"
                    wSql &= "     AND SINSEI.KEIYAKUSYA_CD = NOJO.KEIYAKUSYA_CD(+)"
                    wSql &= "     AND SINSEI.NOJO_CD = NOJO.NOJO_CD(+)"
                    '                 -- 契約区分
                    wSql &= "     AND KEI.KEIYAKU_KBN = CD01.MEISYO_CD(+)"
                    wSql &= "     AND 1 = CD01.SYURUI_KBN(+)"
                    '                 -- 都道府県
                    wSql &= "     AND KEI.KEN_CD = CD05.MEISYO_CD(+)"
                    wSql &= "     AND 5 = CD05.SYURUI_KBN(+)"
                    '                 -- 事務委託先
                    wSql &= "     AND KEI.KI = ITK.KI(+)"
                    wSql &= "     AND KEI.JIMUITAKU_CD = ITK.ITAKU_CD(+)"
                    '                 -- 都道府県(農場)
                    wSql &= "     AND NOJO.KEN_CD = CD05N.MEISYO_CD(+)"
                    wSql &= "     AND 5 = CD05N.SYURUI_KBN(+)"
                    '                 -- 鶏の種類
                    wSql &= "     AND SINSEI.TORI_KBN = CD07.MEISYO_CD(+)"
                    wSql &= "     AND 7 = CD07.SYURUI_KBN(+)"
                    '                 -- 条件
                    wSql &= "     AND KOFU.KI = " & numKI.Text.Trim
                    wSql &= "     AND KOFU.KEISAN_DATE <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                    '                 -- 未契約者および未来契約者を除く
                    wSql &= "     AND KEI.KEIYAKU_DATE IS NOT NULL"
                    wSql &= "     AND KEI.KEIYAKU_DATE <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"

                    wSql &= wWhere & " "

                    wSql &= "    ORDER BY"
                    wSql &= "         KOFU.KI"
                    wSql &= "        ,KOFU.HASSEI_KAISU"
                    wSql &= "        ,KOFU.KEIYAKUSYA_CD"
                    wSql &= "        ,NOJO.MEISAI_NO"
                    wSql &= "        ,SINSEI.TORI_KBN"
                    wSql &= "        ,SINSEI.GOJOKIN_SYURUI_KBN"    '2017/08/01　修正
                    wSql &= "    ) DTL"
                    wSql &= " GROUP BY"
                    wSql &= "     DTL.KI"
                    wSql &= "    ,DTL.HASSEI_KAISU"
                    wSql &= "    ,DTL.KEIYAKUSYA_CD"
                    wSql &= " ORDER BY"
                    wSql &= "     KI"
                    wSql &= "    ,HASSEI_KAISU"
                    wSql &= "    ,KEIYAKUSYA_CD"

                Case 1      'CSV出力ボタンクリック時の検索条件


                    '==SQL作成====================
                    '振込金額等のみ
                    If rbtnOutKIHON.Checked Then
                        wSql = "SELECT"
                        wSql &= "     ""期"""
                        wSql &= "    ,""契約者番号"""
                        wSql &= "    ,MAX(""都道府県コード"") AS ""都道府県コード"""
                        wSql &= "    ,MAX(""都道府県名"") AS ""都道府県名"""
                        wSql &= "    ,MAX(""契約区分コード"") AS ""契約区分コード"""
                        wSql &= "    ,MAX(""契約区分名"") AS ""契約区分名"""
                        wSql &= "    ,MAX(""契約状況コード"") AS ""契約状況コード"""
                        wSql &= "    ,MAX(""契約状況名"") AS ""契約状況名"""
                        wSql &= "    ,MAX(""契約日"") AS ""契約日"""
                        wSql &= "    ,MAX(""契約者名"") AS ""契約者名"""
                        wSql &= "    ,MAX(""契約者名（フリガナ）"") AS ""契約者名（フリガナ）"""
                        wSql &= "    ,MAX(""代表者名"") AS ""代表者名"""
                        wSql &= "    ,MAX(""代表者氏名（フリガナ）"") AS ""代表者氏名（フリガナ）"""
                        wSql &= "    ,MAX(""事務委託先番号"") AS ""事務委託先番号"""
                        wSql &= "    ,MAX(""事務委託先名"") AS ""事務委託先名"""
                        '             -- 互助交付
                        '↓2022/02/08 JBD437 UPD R03年度減額対応
                        'wSql &= "    ,""発生回数"""
                        wSql &= "    ,""認定回数"""
                        '↑2022/02/08 JBD437 UPD R03年度減額対応
                        wSql &= "    ,MAX(""交付計算回数"") AS ""交付計算回数"""
                        wSql &= "    ,MAX(""互助金交付状況コード"") AS ""互助金交付状況コード"""
                        wSql &= "    ,MAX(""互助金交付状況名"") AS ""互助金交付状況名"""
                        wSql &= "    ,MAX(""互助金交付率"") AS ""互助金交付率"""        '2022/02/08 JBD437 ADD R03年度減額対応
                        wSql &= "    ,MAX(""①経営支援互助金 生産者積立"") AS ""①経営支援互助金 生産者積立"""
                        wSql &= "    ,MAX(""②経営支援互助金 国庫交付"") AS ""②経営支援互助金 国庫交付"""
                        wSql &= "    ,MAX(""③経営支援互助金合計＝①＋②"") AS ""③経営支援互助金合計＝①＋②"""
                        wSql &= "    ,MAX(""④焼却・埋却互助金 生産者積立"") AS ""④焼却・埋却互助金 生産者積立"""
                        wSql &= "    ,MAX(""⑤焼却・埋却互助金 国庫交付"") AS ""⑤焼却・埋却互助金 国庫交付"""
                        wSql &= "    ,MAX(""⑥焼却・埋却互助金合計＝④＋⑤"") AS ""⑥焼却・埋却互助金合計＝④＋⑤"""
                        wSql &= "    ,MAX(""⑦生産者積立金合計＝①＋④"") AS ""⑦生産者積立金合計＝①＋④"""
                        wSql &= "    ,MAX(""⑧国庫交付金部分＝②＋⑤"") AS ""⑧国庫交付金部分＝②＋⑤"""
                        wSql &= "    ,MAX(""⑨交付額合計＝③＋⑥"") AS ""⑨交付額合計＝③＋⑥"""
                        wSql &= "    ,MAX(""経営支援羽数"") AS ""経営支援羽数"""
                        wSql &= "    ,MAX(""焼却埋却羽数"") AS ""焼却埋却羽数"""
                        wSql &= "    ,MAX(""計算処理日"") AS ""計算処理日"""
                        wSql &= "    ,MAX(""振込予定日"") AS ""振込予定日"""
                        wSql &= "    ,MAX(""交付金通知 発信年"") AS ""交付金通知 発信年"""
                        wSql &= "    ,MAX(""交付金通知 発信連番"") AS ""交付金通知 発信連番"""
                        wSql &= "    ,MAX(""交付金通知日"") AS ""交付金通知日"""
                        wSql &= "    ,MAX(""交付金通知書作成日（ハガキ）"") AS ""交付金通知書作成日（ハガキ）"""
                        wSql &= "    ,MAX(""交付通知書 出力日"") AS ""交付通知書 出力日"""
                        wSql &= " FROM"
                        wSql &= "    ("
                    End If

                    wSql &= "    SELECT"
                    wSql &= "         KOFU.KI AS ""期"""
                    wSql &= "        ,KOFU.KEIYAKUSYA_CD AS ""契約者番号"""
                    wSql &= "        ,KEI.KEN_CD AS ""都道府県コード"""
                    wSql &= "        ,CD05.MEISYO AS ""都道府県名"""
                    wSql &= "        ,KEI.KEIYAKU_KBN AS ""契約区分コード"""
                    wSql &= "        ,CD01.MEISYO AS ""契約区分名"""
                    wSql &= "        ,KEI.KEIYAKU_JYOKYO AS ""契約状況コード"""
                    wSql &= "        ,CD02.MEISYO AS ""契約状況名"""
                    '↓2022/02/08 JBD437 UPD R03年度減額対応
                    'wSql &= "        ,TO_CHAR(KEI.KEIYAKU_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""契約日"""
                    wSql &= "        ,TO_CHAR(KEI.KEIYAKU_DATE, 'FMEYY.MM.DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""契約日"""
                    '↑2022/02/08 JBD437 UPD R03年度減額対応
                    wSql &= "        ,KEI.KEIYAKUSYA_NAME AS ""契約者名"""
                    wSql &= "        ,KEI.KEIYAKUSYA_KANA AS ""契約者名（フリガナ）"""
                    wSql &= "        ,KEI.DAIHYO_NAME AS ""代表者名"""
                    wSql &= "        ,KEI.DAIHYO_KANA AS ""代表者氏名（フリガナ）"""
                    wSql &= "        ,KEI.JIMUITAKU_CD AS ""事務委託先番号"""
                    wSql &= "        ,ITK.ITAKU_NAME AS ""事務委託先名"""
                    '                 -- 互助交付
                    '↓2022/02/08 JBD437 UPD R03年度減額対応
                    'wSql &= "        ,KOFU.HASSEI_KAISU AS ""発生回数"""
                    wSql &= "        ,KOFU.HASSEI_KAISU AS ""認定回数"""
                    '↓2022/02/08 JBD437 UPD R03年度減額対応
                    wSql &= "        ,KOFU.KEISAN_KAISU AS ""交付計算回数"""
                    wSql &= "        ,KOFU.SYORI_JOKYO AS ""互助金交付状況コード"""
                    wSql &= "        ,CD11.MEISYO AS ""互助金交付状況名"""
                    wSql &= "        ,SINSEI.KOFU_RITU AS ""互助金交付率"""       '2022/02/08 JBD437 ADD R03年度減額対応
                    wSql &= "        ,KOFU.KEIEI_SEI_TUMITATE_KIN AS ""①経営支援互助金 生産者積立"""
                    wSql &= "        ,KOFU.KEIEI_KUNI_KOFU_KIN AS ""②経営支援互助金 国庫交付"""
                    wSql &= "        ,KOFU.KEIEI_GOJO_KIN_KEI AS ""③経営支援互助金合計＝①＋②"""
                    wSql &= "        ,KOFU.MAIKYAKU_SEI_TUMITATE_KIN AS ""④焼却・埋却互助金 生産者積立"""
                    wSql &= "        ,KOFU.MAIKYAKU_KUNI_KOFU_KIN AS ""⑤焼却・埋却互助金 国庫交付"""
                    wSql &= "        ,KOFU.MAIKYAKU_GOJO_KIN_KEI AS ""⑥焼却・埋却互助金合計＝④＋⑤"""
                    wSql &= "        ,KOFU.SEI_TUMITATE_KIN_KEI AS ""⑦生産者積立金合計＝①＋④"""
                    wSql &= "        ,KOFU.KUNI_KOFU_KIN_KEI AS ""⑧国庫交付金部分＝②＋⑤"""
                    wSql &= "        ,KOFU.KOFU_KIN_KEI AS ""⑨交付額合計＝③＋⑥"""
                    wSql &= "        ,KOFU.KEIEI_HASU AS ""経営支援羽数"""
                    wSql &= "        ,KOFU.SYOKYAKU_HASU AS ""焼却埋却羽数"""
                    '↓2022/02/08 JBD437 UPD R03年度減額対応
                    'wSql &= "        ,TO_CHAR(KOFU.KEISAN_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""計算処理日"""
                    'wSql &= "        ,TO_CHAR(KOFU.FURIKOMI_YOTEI_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""振込予定日"""
                    wSql &= "        ,TO_CHAR(KOFU.KEISAN_DATE, 'FMEYY.MM.DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""計算処理日"""
                    wSql &= "        ,TO_CHAR(KOFU.FURIKOMI_YOTEI_DATE, 'FMEYY.MM.DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""振込予定日"""
                    '↑2022/02/08 JBD437 UPD R03年度減額対応
                    wSql &= "        ,KOFU.KOFUTUTI_HAKKO_NO_NEN AS ""交付金通知 発信年"""
                    wSql &= "        ,KOFU.KOFUTUTI_HAKKO_NO_RENBAN AS ""交付金通知 発信連番"""
                    '↓2022/02/08 JBD437 UPD R03年度減額対応
                    'wSql &= "        ,TO_CHAR(KOFU.KOFUTUTI_HAKKO_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""交付金通知日"""
                    'wSql &= "        ,TO_CHAR(KOFU.KOFUTUTI_SAKUSEI_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""交付金通知書作成日（ハガキ）"""
                    'wSql &= "        ,TO_CHAR(KOFU.KOFUTUTI_SYUTURYOKU_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""交付通知書 出力日"""
                    wSql &= "        ,TO_CHAR(KOFU.KOFUTUTI_HAKKO_DATE, 'FMEYY.MM.DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""交付金通知日"""
                    wSql &= "        ,TO_CHAR(KOFU.KOFUTUTI_SAKUSEI_DATE, 'FMEYY.MM.DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""交付金通知書作成日（ハガキ）"""
                    wSql &= "        ,TO_CHAR(KOFU.KOFUTUTI_SYUTURYOKU_DATE, 'FMEYY.MM.DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""交付通知書 出力日"""
                    '↑2022/02/08 JBD437 UPD R03年度減額対応
                    '                 -- 互助交付申請
                    wSql &= "       ,SINSEI.GOJOKIN_SYURUI_KBN AS ""互助金種類区分コード"""
                    wSql &= "        ,CD03.MEISYO AS ""互助金種類区分"""
                    wSql &= "        ,SINSEI.NOJO_CD AS ""農場コード"""
                    wSql &= "        ,NOJO.NOJO_NAME AS ""農場名"""
                    wSql &= "        ,SINSEI.TORI_KBN AS ""鶏の種類コード"""
                    wSql &= "        ,CD07.MEISYO AS ""鶏の種類"""
                    wSql &= "        ,SINSEI.SYORI_JOKYO_KBN AS ""互助金情報入力状況コード"""
                    wSql &= "        ,CD13.MEISYO AS ""互助金情報入力状況"""
                    wSql &= "        ,SINSEI.KOYO_ROTIN AS ""雇用労賃"""
                    wSql &= "        ,SINSEI.JIDAI AS ""地代"""
                    wSql &= "        ,SINSEI.GENKA_SYOKYAKU AS ""減価償却"""
                    wSql &= "        ,SINSEI.KUSYA_KIKAN AS ""空舎期間"""
                    wSql &= "        ,SINSEI.SONOTA_KOTEIHI AS ""その他固定費"""
                    wSql &= "        ,SINSEI.SYOKYAKU_KEIHI AS ""焼却等経費"""
                    wSql &= "        ,SINSEI.KUNI_KOFUKIN AS ""国交付金"""
                    '↓2022/02/08 JBD437 UPD R03年度減額対応
                    'wSql &= "        ,TO_CHAR(SINSEI.KOFU_KAKUTEI_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""交付確定日"""
                    wSql &= "        ,TO_CHAR(SINSEI.KOFU_KAKUTEI_DATE, 'FMEYY.MM.DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""交付確定日"""
                    '↑2022/02/08 JBD437 UPD R03年度減額対応
                    wSql &= "        ,SINSEI.KOFU_TANKA AS ""交付単価"""
                    wSql &= "        ,SINSEI.KOFU_HASU AS ""交付羽数"""
                    '↓2022/02/08 JBD437 ADD R03年度減額対応
                    wSql &= "        ,SINSEI.SANTEI_KIN AS ""交付金額（減額算定前）"""
                    wSql &= "        ,SINSEI.GENGAKU_RITU AS ""家伝法違反減額率"""
                    '↑2022/02/08 JBD437 ADD R03年度減額対応
                    wSql &= "        ,SINSEI.SEI_TUMITATE_KIN AS ""生産者積立金分"""
                    wSql &= "        ,SINSEI.KUNI_KOFU_KIN AS ""国庫交付金分"""
                    '↓2022/02/08 JBD437 UPD R03年度減額対応
                    'wSql &= "        ,SINSEI.KOFU_KIN AS ""交付金額"""
                    wSql &= "        ,SINSEI.KOFU_KIN AS ""交付金額（減額算定後）"""
                    '↑2022/02/08 JBD437 UPD R03年度減額対応
                    wSql &= "        ,SINSEI.KEISAN_KAISU AS ""明細交付計算回数"""
                    wSql &= "    FROM TT_KOFU KOFU"
                    wSql &= "        ,TT_KOFU_SINSEI SINSEI "
                    wSql &= "        ,TM_KEIYAKU KEI"
                    wSql &= "        ,TM_KEIYAKU_NOJO NOJO"
                    wSql &= "        ,TM_CODE CD01"
                    wSql &= "        ,TM_CODE CD02"
                    wSql &= "        ,TM_CODE CD03"
                    wSql &= "        ,TM_CODE CD05"
                    wSql &= "        ,TM_CODE CD05N"
                    wSql &= "        ,TM_CODE CD07"
                    wSql &= "        ,TM_CODE CD11"
                    wSql &= "        ,TM_CODE CD13"
                    wSql &= "        ,TM_JIMUITAKU ITK"
                    wSql &= "    WHERE"
                    '                 -- 契約者マスタ
                    wSql &= "         KOFU.KI = KEI.KI(+)"
                    wSql &= "     AND KOFU.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+)"
                    '                 -- 互助金申請
                    wSql &= "     AND KOFU.KI = SINSEI.KI(+)"
                    wSql &= "     AND KOFU.KEIYAKUSYA_CD = SINSEI.KEIYAKUSYA_CD(+)"
                    wSql &= "     AND KOFU.HASSEI_KAISU = SINSEI.HASSEI_KAISU(+)"
                    wSql &= "     AND KOFU.KEISAN_KAISU = SINSEI.KEISAN_KAISU(+)"
                    '                 -- 契約者農場マスタ
                    wSql &= "     AND SINSEI.KI = NOJO.KI(+)"
                    wSql &= "     AND SINSEI.KEIYAKUSYA_CD = NOJO.KEIYAKUSYA_CD(+)"
                    wSql &= "     AND SINSEI.NOJO_CD = NOJO.NOJO_CD(+)"
                    '                 -- 契約区分
                    wSql &= "     AND KEI.KEIYAKU_KBN = CD01.MEISYO_CD(+)"
                    wSql &= "     AND 1 = CD01.SYURUI_KBN(+)"
                    '                 -- 契約状況
                    wSql &= "     AND KEI.KEIYAKU_JYOKYO = CD02.MEISYO_CD(+)"
                    wSql &= "     AND 2 = CD02.SYURUI_KBN(+)"
                    '                 -- 互助金種類区分
                    wSql &= "     AND SINSEI.GOJOKIN_SYURUI_KBN = CD03.MEISYO_CD(+)"
                    wSql &= "     AND 3 = CD03.SYURUI_KBN(+)"
                    '                 -- 都道府県
                    wSql &= "     AND KEI.KEN_CD = CD05.MEISYO_CD(+)"
                    wSql &= "     AND 5 = CD05.SYURUI_KBN(+)"
                    '                 -- 事務委託先
                    wSql &= "     AND KEI.KI = ITK.KI(+)"
                    wSql &= "     AND KEI.JIMUITAKU_CD = ITK.ITAKU_CD(+)"
                    '                 -- 都道府県(農場)
                    wSql &= "     AND NOJO.KEN_CD = CD05N.MEISYO_CD(+)"
                    wSql &= "     AND 5 = CD05N.SYURUI_KBN(+)"
                    '                 -- 鶏の種類
                    wSql &= "     AND SINSEI.TORI_KBN = CD07.MEISYO_CD(+)"
                    wSql &= "     AND 7 = CD07.SYURUI_KBN(+)"
                    '                 -- 互助金交付状況
                    wSql &= "     AND KOFU.SYORI_JOKYO = CD11.MEISYO_CD(+)"
                    wSql &= "     AND 11 = CD11.SYURUI_KBN(+)"
                    '                 -- 互助金交付状況
                    wSql &= "     AND SINSEI.SYORI_JOKYO_KBN = CD13.MEISYO_CD(+)"
                    wSql &= "     AND 13 = CD13.SYURUI_KBN(+)"
                    '                 -- 条件
                    wSql &= "     AND KOFU.KI = " & numKI.Text.Trim
                    wSql &= "     AND KOFU.KEISAN_DATE <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                    '                 -- 未契約者および未来契約者を除く
                    wSql &= "     AND KEI.KEIYAKU_DATE IS NOT NULL"
                    wSql &= "     AND KEI.KEIYAKU_DATE <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"

                    wSql &= wWhere & " "

                    wSql &= "    ORDER BY"
                    wSql &= "        KOFU.KI"
                    wSql &= "       ,KOFU.HASSEI_KAISU"
                    wSql &= "       ,KOFU.KEIYAKUSYA_CD"
                    wSql &= "       ,NOJO.MEISAI_NO"
                    wSql &= "       ,SINSEI.TORI_KBN"
                    wSql &= "       ,SINSEI.GOJOKIN_SYURUI_KBN"     '2017/08/01　修正
                    '振込金額等のみ
                    If rbtnOutKIHON.Checked Then
                        wSql &= "    )"
                        wSql &= "    GROUP BY"
                        wSql &= "        ""期"""
                        '↓2022/02/08 JBD437 UPD R03年度減額対応
                        'wSql &= "       ,""発生回数"""
                        wSql &= "       ,""認定回数"""
                        '↑2022/02/08 JBD437 UPD R03年度減額対応
                        wSql &= "       ,""契約者番号"""
                        wSql &= "    ORDER BY"
                        wSql &= "        ""期"""
                        '↓2022/02/08 JBD437 UPD R03年度減額対応
                        'wSql &= "       ,""発生回数"""
                        wSql &= "       ,""認定回数"""
                        '↑2022/02/08 JBD437 UPD R03年度減額対応
                        wSql &= "       ,""契約者番号"""
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



#Region "f_GridReDisp グリッド再表示"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridReDisp
    '説明            :グリッド再表示
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_GridReDisp(ByVal wKeiyakusyaCd As Integer, ByVal wkSeikyuKaisu As Integer) As Boolean
        Dim ret As Boolean = False
        Dim blnHit As Boolean = False

        Try

            '再抽出
            cmdSearch_Click(cmdSearch, New EventArgs, False)

            'グリッドに有効データあり
            If dgv_Search.RowCount <> 0 Then
                '契約者が指定されたとき
                If wKeiyakusyaCd <> -1 Then
                    For i As Integer = 0 To dgv_Search.RowCount - 1
                        '選択行
                        If dgv_Search.Item("KEIYAKUSYA_CD", i).Value >= wKeiyakusyaCd And dgv_Search.Item("SEIKYU_KAISU", i).Value >= wkSeikyuKaisu Then
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
