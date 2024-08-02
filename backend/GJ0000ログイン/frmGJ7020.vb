'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ7020.vb
'*
'*　　②　機能概要　　　　　互助基金契約者積立金情報検索ＣＳＶデータ作成
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

Public Class frmGJ7020

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
    Public paryKEY_7020 As New List(Of T_KEY)

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
            'f_makeCSVByDT(wkDS.Tables(0), "TUMITATEKIN_")
            If pKikin2 Then
                f_makeCSVByDT(wkDS.Tables(0), "TUMITATEKIN(追加納付)_")
            Else
                f_makeCSVByDT(wkDS.Tables(0), "TUMITATEKIN_")
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

#Region "請求・返還日関連"
    '------------------------------------------------------------------
    'プロシージャ名  :dateSEIKYU_Ymd_Fm_Validating
    '説明            :請求・返還日FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateSEIKYU_Ymd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateSEIKYU_Ymd_Fm.Validating

        Call s_From_Validating(dateSEIKYU_Ymd_Fm, dateSEIKYU_Ymd_To)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :dateSEIKYU_Ymd_To_Validating
    '説明            :請求・返還日TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateSEIKYU_Ymd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateSEIKYU_Ymd_To.Validating

        'Call s_To_Validating(dateSEIKYU_Ymd_To, dateSEIKYU_Ymd_Fm)

    End Sub
#End Region

#Region "入金・振込日関連"
    '------------------------------------------------------------------
    'プロシージャ名  :dateNYUKIN_Ymd_Fm_Validating
    '説明            :入金・振込日FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateNYUKIN_Ymd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateNYUKIN_Ymd_Fm.Validating

        Call s_From_Validating(dateNYUKIN_Ymd_Fm, dateNYUKIN_Ymd_To)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :dateNYUKIN_Ymd_To_Validating
    '説明            :入金・振込日TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateNYUKIN_Ymd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateNYUKIN_Ymd_To.Validating

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
            '契約変更チェックボックス
            chkKEIYAKU_HENKO_KBN_1.Checked = True
            chkKEIYAKU_HENKO_KBN_2.Checked = True
            chkKEIYAKU_HENKO_KBN_3.Checked = True
            chkKEIYAKU_HENKO_KBN_4.Checked = True
            chkKEIYAKU_HENKO_KBN_9.Checked = True
            '請求。返還区分チェックボックス
            chkSEIKYU_HENKAN_KBN_1.Checked = True
            chkSEIKYU_HENKAN_KBN_2.Checked = True
            chkSEIKYU_HENKAN_KBN_3.Checked = True
            chkSEIKYU_HENKAN_KBN_4.Checked = True
            '入金・振込状況チェックボックス
            chkSYORI_JOKYO_KBN_1.Checked = True
            chkSYORI_JOKYO_KBN_2.Checked = True
            chkSYORI_JOKYO_KBN_3.Checked = True
            '未契約者除く
            chk_MikeiyakuNozoku.Checked = True '2015/12/07　追加

            rbtnOutMEISAI.Checked = True
            rbtnSearchAnd.Checked = True

            lblCOUNT_HED.Text = "0"     '抽出件数
            lblCOUNT_DTL.Text = "0"     '抽出件数

            '変数クリア
            paryKEY_7020 = New List(Of T_KEY)
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

            '契約変更チェックボックス
            'R05年度 OSバージョンアップ　既存バグ修正のために変更　2024/03/12 JBD453 UPD START
            'If chkKEIYAKU_HENKO_KBN_1.Checked = False _
            '     And chkKEIYAKU_HENKO_KBN_2.Checked = False _
            '     And chkKEIYAKU_HENKO_KBN_3.Checked = False _
            '     And chkKEIYAKU_HENKO_KBN_4.Checked = False Then

            If chkKEIYAKU_HENKO_KBN_1.Checked = False _
                 And chkKEIYAKU_HENKO_KBN_2.Checked = False _
                 And chkKEIYAKU_HENKO_KBN_3.Checked = False _
                 And chkKEIYAKU_HENKO_KBN_4.Checked = False _
                 And chkKEIYAKU_HENKO_KBN_9.Checked = False Then
                'R05年度 OSバージョンアップ　既存バグ修正のために変更　2024/03/12 JBD453 UPD END

                Show_MessageBox_Add("W008", "契約変更")
                chkKEIYAKU_HENKO_KBN_1.Focus()
                Exit Try
            End If


            '請求・返還区分チェックボックス
            If chkSEIKYU_HENKAN_KBN_1.Checked = False _
                 And chkSEIKYU_HENKAN_KBN_2.Checked = False _
                 And chkSEIKYU_HENKAN_KBN_3.Checked = False _
                 And chkSEIKYU_HENKAN_KBN_4.Checked = False Then
                Show_MessageBox_Add("W008", "請求・返還区分")
                chkSEIKYU_HENKAN_KBN_1.Focus()
                Exit Try
            End If

            '#110 ADD START
            '入金・振込状況チェックボックス
            If chkSYORI_JOKYO_KBN_1.Checked = False _
                 And chkSYORI_JOKYO_KBN_2.Checked = False _
                 And chkSYORI_JOKYO_KBN_3.Checked = False Then
                Show_MessageBox_Add("W008", "入金・振込状況")
                chkSYORI_JOKYO_KBN_1.Focus()
                Exit Try
            End If
            '#110 ADD END

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


            '請求・返還日
            If f_Daisyo_Check(dateSEIKYU_Ymd_Fm, dateSEIKYU_Ymd_To, "請求・返還日", True, 2) = False Then
                Exit Try
            End If

            '入金・振込日
            If f_Daisyo_Check(dateNYUKIN_Ymd_Fm, dateNYUKIN_Ymd_To, "入金・振込日", True, 2) = False Then
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

            '契約変更チェック
            strChekVal = ""
            If chkKEIYAKU_HENKO_KBN_1.Checked And chkKEIYAKU_HENKO_KBN_2.Checked And chkKEIYAKU_HENKO_KBN_3.Checked And chkKEIYAKU_HENKO_KBN_4.Checked Then
                '全チェック
            Else
                '新規契約（継続、非継続、新規）
                If chkKEIYAKU_HENKO_KBN_1.Checked Then
                    strChekVal = "0"
                End If
                '増羽
                If chkKEIYAKU_HENKO_KBN_2.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "1"
                        'strChekVal = "1,9"
                    Else
                        strChekVal += ",1"
                        'strChekVal += ",1,9"
                    End If
                End If
                '契約区分変更
                If chkKEIYAKU_HENKO_KBN_3.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "2,3"
                    Else
                        strChekVal += ",2,3"
                    End If
                End If
                '譲渡
                If chkKEIYAKU_HENKO_KBN_4.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "4"
                    Else
                        strChekVal += ",4"
                    End If
                End If
                '移動
                If chkKEIYAKU_HENKO_KBN_9.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "9"
                    Else
                        strChekVal += ",9"
                    End If
                End If

                'SQL作成
                If strChekVal.Length > 0 Then
                    If wWhere <> "" Then
                        wWhere = wWhere & wANDorOR
                    End If
                    ' ３：入金（返還）済
                    wWhere &= "( TUM.KEIYAKU_HENKO_KBN IN (" & strChekVal & ") )"
                End If
            End If


            '請求・返還チェック
            strChekVal = ""
            If chkSEIKYU_HENKAN_KBN_1.Checked And chkSEIKYU_HENKAN_KBN_2.Checked And chkSEIKYU_HENKAN_KBN_3.Checked And chkSEIKYU_HENKAN_KBN_4.Checked Then
                '全チェック
            Else
                '請求(新規)
                If chkSEIKYU_HENKAN_KBN_1.Checked Then
                    strChekVal = "1"
                End If
                '一部請求
                If chkSEIKYU_HENKAN_KBN_2.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "2"
                    Else
                        strChekVal += ",2"
                    End If
                End If
                '一部返還
                If chkSEIKYU_HENKAN_KBN_3.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "3"
                    Else
                        strChekVal += ",3"
                    End If
                End If
                '全額返還
                If chkSEIKYU_HENKAN_KBN_4.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "4"
                    Else
                        strChekVal += ",4"
                    End If
                End If
                'SQL作成
                If strChekVal.Length > 0 Then
                    If wWhere <> "" Then
                        wWhere = wWhere & wANDorOR
                    End If
                    ' ３：入金（返還）済
                    wWhere &= "( TUM.SEIKYU_HENKAN_KBN IN (" & strChekVal & ") )"
                End If
            End If


            '入金・振込状況チェックボックス
            strChekVal = ""
            If chkSYORI_JOKYO_KBN_1.Checked And chkSYORI_JOKYO_KBN_2.Checked And chkSYORI_JOKYO_KBN_3.Checked Then
                '全チェック
            Else
                '入金・振込済
                If chkSYORI_JOKYO_KBN_1.Checked Then
                    strChekVal = "3"
                End If
                '未入金・未振込
                If chkSYORI_JOKYO_KBN_2.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "1,2"
                    Else
                        strChekVal += ",1,2"
                    End If
                End If
                '一部入金
                If chkSYORI_JOKYO_KBN_3.Checked Then
                    If strChekVal.Length = 0 Then
                        strChekVal = "4,5"
                    Else
                        strChekVal += ",4,5"
                    End If
                End If
                'SQL作成
                If strChekVal.Length > 0 Then
                    If wWhere <> "" Then
                        wWhere = wWhere & wANDorOR
                    End If
                    wWhere &= "( TUM.SYORI_JOKYO_KBN IN (" & strChekVal & ") )"
                End If
            End If



            '請求・返還日From
            If Not (dateSEIKYU_Ymd_Fm.Value Is Nothing) And Not (dateSEIKYU_Ymd_To.Value Is Nothing) Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " TUM.SEIKYU_DATE BETWEEN TO_DATE('" & Format(dateSEIKYU_Ymd_Fm.Value, "yyyy/MM/dd").TrimEnd & "') and TO_DATE('" & Format(dateSEIKYU_Ymd_To.Value, "yyyy/MM/dd").TrimEnd & "'))"
            End If


            '入金・振込日From
            If Not (dateNYUKIN_Ymd_Fm.Value Is Nothing) And Not (dateNYUKIN_Ymd_To.Value Is Nothing) Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " TUM.NYUKIN_DATE BETWEEN TO_DATE('" & Format(dateNYUKIN_Ymd_Fm.Value, "yyyy/MM/dd").TrimEnd & "') and TO_DATE('" & Format(dateNYUKIN_Ymd_To.Value, "yyyy/MM/dd").TrimEnd & "'))"
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
                    wSql &= "    ,DTL.KEIYAKUSYA_CD AS KEIYAKUSYA_CD"
                    wSql &= "    ,MAX(DTL.KEIYAKUSYA_NAME) AS KEIYAKUSYA_NAME"
                    wSql &= "    ,MAX(DTL.KEIYAKU_KBN) AS KEIYAKU_KBN"
                    wSql &= "    ,MAX(DTL.KEIYAKU_KBN_NM) AS KEIYAKU_KBN_NM"
                    wSql &= "    ,MAX(DTL.KEN_CD) AS KEN_CD"
                    wSql &= "    ,MAX(DTL.KEN_CD_NM) AS KEN_CD_NM"
                    wSql &= "    ,MAX(DTL.JIMUITAKU_CD) AS JIMUITAKU_CD"
                    wSql &= "    ,MAX(DTL.JIMUITAKU_CD_NM) AS JIMUITAKU_CD_NM"
                    'wSql &= "    ,MAX(DTL.SEIKYU_KAISU) AS SEIKYU_KAISU"   '2018/03/07　修正
                    wSql &= "    ,DTL.SEIKYU_KAISU AS SEIKYU_KAISU"         '2018/03/07　修正
                    wSql &= "    ,MAX(DTL.SEIKYU_DATE) AS SEIKYU_DATE"
                    wSql &= "    ,MAX(DTL.KEIYAKU_HENKO_KBN) AS KEIYAKU_HENKO_KBN"
                    wSql &= "    ,MAX(DTL.KEIYAKU_HENKO_KBN_NM) AS KEIYAKU_HENKO_KBN_NM"
                    wSql &= "    ,MAX(DTL.SEIKYU_HENKAN_KBN) AS SEIKYU_HENKAN_KBN"
                    wSql &= "    ,MAX(DTL.SEIKYU_HENKAN_KBN_NM) AS SEIKYU_HENKAN_KBN_NM"

                    '2018/03/07　修正開始
                    'wSql &= "    ,MAX(DTL.SEIKYU_KIN) AS SEIKYU_KIN" 
                    If rbtnOutMEISAI.Checked Then
                        wSql &= "    ,MAX(DTL.SEIKYU_KIN) AS SEIKYU_KIN"
                    Else
                        wSql &= "    ,MAX(DTL.SAGAKU_SEIKYU_KIN) AS SEIKYU_KIN"
                    End If
                    '2018/03/07　修正終了

                    wSql &= "    ,MAX(DTL.DLT_CNT) AS COUNT_DTL"
                    wSql &= " FROM"
                    wSql &= "    ("
                    wSql &= "    SELECT"
                    wSql &= "         TUM.KI AS KI"
                    wSql &= "        ,TUM.KEIYAKUSYA_CD AS KEIYAKUSYA_CD"
                    wSql &= "        ,KEI.KEIYAKUSYA_NAME AS KEIYAKUSYA_NAME"
                    wSql &= "        ,KEI.KEIYAKU_KBN AS KEIYAKU_KBN"
                    '↓2017/07/13 修正 契約区分
                    'wSql &= "        ,CD01.RYAKUSYO AS KEIYAKU_KBN_NM"
                    wSql &= "        ,CD01.MEISYO AS KEIYAKU_KBN_NM"
                    '↑2017/07/13 修正 契約区分
                    wSql &= "        ,KEI.KEN_CD AS KEN_CD"
                    'wSql &= "        ,CD05.RYAKUSYO AS KEN_CD_NM"
                    wSql &= "        ,LPAD(KEI.KEN_CD,2) || CD05.RYAKUSYO KEN_CD_NM"
                    wSql &= "        ,KEI.JIMUITAKU_CD AS JIMUITAKU_CD"
                    wSql &= "        ,ITK.ITAKU_NAME AS JIMUITAKU_CD_NM"
                    wSql &= "        ,TUM.SEIKYU_KAISU AS SEIKYU_KAISU"
                    wSql &= "        ,SUBSTR(TO_CHAR(TUM.SEIKYU_DATE, 'EYY""/""MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL'''),2) AS SEIKYU_DATE"
                    'wSql &= "        ,TO_CHAR(TUM.SEIKYU_DATE, 'EYY"" / ""MM"" / ""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SEIKYU_DATE"
                    wSql &= "        ,TUM.KEIYAKU_HENKO_KBN AS KEIYAKU_HENKO_KBN"
                    wSql &= "        ,CD10.RYAKUSYO AS KEIYAKU_HENKO_KBN_NM"
                    wSql &= "        ,TUM.SEIKYU_HENKAN_KBN AS SEIKYU_HENKAN_KBN"
                    wSql &= "        ,CD08.RYAKUSYO AS SEIKYU_HENKAN_KBN_NM"

                    '2018/03/07　修正開始
                    'wSql &= "        ,TUM.SEIKYU_KIN AS SEIKYU_KIN"                
                    If rbtnOutMEISAI.Checked Then
                        wSql &= "        ,TUM.SEIKYU_KIN AS SEIKYU_KIN"
                    Else
                        wSql &= "        ,TUM.SAGAKU_SEIKYU_KIN AS SAGAKU_SEIKYU_KIN"
                    End If
                    '2018/03/07　修正終了

                    wSql &= "        ,COUNT(TUM.KI) OVER() AS DLT_CNT"
                    wSql &= "    FROM TT_TUMITATE TUM"
                    wSql &= "        ,TT_TUMITATE_MEISAI MEISAI"
                    wSql &= "        ,TM_KEIYAKU KEI"
                    wSql &= "        ,TM_KEIYAKU ZKY"       '2016/03/14　追加　 前期の契約マスタ
                    wSql &= "        ,TM_JIMUITAKU ITK"
                    wSql &= "        ,TM_CODE CD01"
                    wSql &= "        ,TM_CODE CD05"
                    wSql &= "        ,TM_CODE CD08"
                    wSql &= "        ,TM_CODE CD10"
                    wSql &= "    WHERE"
                    '                 -- 契約者マスタ
                    wSql &= "         TUM.KI = KEI.KI(+)"
                    wSql &= "     AND TUM.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+)"
                    '                 -- 前期の契約マスタ
                    wSql &= "     AND (TUM.KI - 1) = ZKY.KI(+)"                     '2016/03/14　追加
                    wSql &= "     AND TUM.KEIYAKUSYA_CD = ZKY.KEIYAKUSYA_CD(+)"     '2016/03/14　追加
                    '                 -- 積立金明細
                    wSql &= "     AND TUM.KI = MEISAI.KI(+)"
                    wSql &= "     AND TUM.KEIYAKUSYA_CD = MEISAI.KEIYAKUSYA_CD(+)"
                    wSql &= "     AND TUM.SEIKYU_KAISU = MEISAI.SEIKYU_KAISU(+)"
                    wSql &= "     AND TUM.TUMITATE_KBN = MEISAI.TUMITATE_KBN(+)"
                    '                 -- 契約区分
                    wSql &= "     AND KEI.KEIYAKU_KBN = CD01.MEISYO_CD(+)"
                    wSql &= "     AND 1 = CD01.SYURUI_KBN(+)"
                    '                 -- 都道府県
                    wSql &= "     AND KEI.KEN_CD = CD05.MEISYO_CD(+)"
                    wSql &= "     AND 5 = CD05.SYURUI_KBN(+)"
                    '                 -- 事務委託先
                    wSql &= "     AND KEI.KI = ITK.KI(+)"
                    wSql &= "     AND KEI.JIMUITAKU_CD = ITK.ITAKU_CD(+)"
                    '                 -- 契約変更区分
                    wSql &= "     AND TUM.KEIYAKU_HENKO_KBN = CD10.MEISYO_CD(+)"
                    wSql &= "     AND 10 = CD10.SYURUI_KBN(+)"
                    '                 -- 請求・返還区分
                    wSql &= "     AND TUM.SEIKYU_HENKAN_KBN = CD08.MEISYO_CD(+)"
                    wSql &= "     AND 8 = CD08.SYURUI_KBN(+)"
                    '                 -- 条件
                    wSql &= "     AND TUM.KI = " & numKI.Text.Trim
                    '                 --積立区分
                    wSql &= "     AND TUM.TUMITATE_KBN = 1"
                    'wSql &= "     AND (   MEISAI.KEIYAKU_DATE_FROM <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                    'wSql &= "         AND MEISAI.KEIYAKU_DATE_TO >= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                    'wSql &= "         )"

                    '2018/03/07　修正開始
                    'wSql &= "     AND (   TUM.KEIYAKU_DATE_FROM <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                    'wSql &= "         AND TUM.KEIYAKU_DATE_TO   >= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                    'wSql &= "         )"
                    If rbtnOutMEISAI.Checked Then
                        '--全データは、対象年月の末日で有効のデータのみ出力
                        wSql &= "     AND (   TUM.KEIYAKU_DATE_FROM <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                        wSql &= "         AND TUM.KEIYAKU_DATE_TO   >= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                        wSql &= "         )"
                    Else
                        '--全データ以外は、差額請求が０以外(請求あり)のデータのみ出力
                        wSql &= "     AND (TUM.SAGAKU_SEIKYU_KIN <> 0 OR TUM.SAGAKU_TUMITATE_KIN <> 0 OR TUM.SAGAKU_TESURYO <> 0)"  '2018/03/07　追加
                    End If
                    '2018/03/07　追加終了

                    '                 -- 未契約者および未来契約者を除く
                    If chk_MikeiyakuNozoku.Checked Then     '2015/12/07　追加
                        '2016/03/14　修正開始
                        'wSql &= "     AND KEI.KEIYAKU_DATE IS NOT NULL"
                        'wSql &= "     AND KEI.KEIYAKU_DATE <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                        wSql &= "    AND CASE WHEN TUM.SEIKYU_HENKAN_KBN = 4"                      '--全額返還"
                        wSql &= "             THEN CASE WHEN ZKY.KEIYAKU_DATE IS NULL THEN 0"      '--対象外"
                        wSql &= "                       WHEN ZKY.KEIYAKU_DATE <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd')) THEN 1"  '--対象"
                        wSql &= "                       ELSE 0 END"                                '--対象外"
                        wSql &= "             ELSE CASE WHEN KEI.KEIYAKU_DATE IS NULL THEN 0"      '--対象外"
                        wSql &= "                       WHEN KEI.KEIYAKU_DATE <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd')) THEN 1"  '--対象"
                        wSql &= "                       ELSE 0 END"                                '--対象外"
                        wSql &= "        END = 1"
                        '2016/03/14　修正開始
                    End If                                  '2015/12/07　追加

                    wSql &= wWhere & " "

                    'wSql &= "    ORDER BY"                 '2018/03/07　削除
                    'wSql &= "         TUM.KI"              '2018/03/07　削除
                    'wSql &= "        ,TUM.KEIYAKUSYA_CD"   '2018/03/07　削除

                    wSql &= "    ) DTL"
                    wSql &= " GROUP BY"
                    wSql &= "     DTL.KI"
                    wSql &= "    ,DTL.KEIYAKUSYA_CD"
                    wSql &= "    ,DTL.SEIKYU_KAISU"     '2018/03/07　追加
                    wSql &= " ORDER BY"
                    wSql &= "     DTL.KI"
                    wSql &= "    ,DTL.KEIYAKUSYA_CD"
                    wSql &= "    ,DTL.SEIKYU_KAISU"     '2018/03/07　追加

                Case 1      'CSV出力ボタンクリック時の検索条件


                    '==SQL作成====================
                    '請求金額、手数料のみ
                    '期／契約者番号／請求回数／積立区分　単位でサマリ   '2018/03/07　変更
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

                        'wSql &= "    ,MAX(""請求（返還）回数"") AS ""請求（返還）回数"""   '2018/03/07　修正
                        wSql &= "    ,""請求（返還）回数"""                                 '2018/03/07　修正

                        wSql &= "    ,MAX(""積立金区分コード"") AS ""積立金区分コード"""
                        wSql &= "    ,MAX(""積立金区分名"") AS ""積立金区分名"""
                        wSql &= "    ,MAX(""契約年月日From"") AS ""契約年月日From"""
                        wSql &= "    ,MAX(""契約年月日To"") AS ""契約年月日To"""
                        wSql &= "    ,MAX(""契約変更区分コード"") AS ""契約変更区分コード"""
                        wSql &= "    ,MAX(""契約変更区分名"") AS ""契約変更区分名"""
                        wSql &= "    ,MAX(""請求(返還)金額計"") AS ""請求(返還)金額計"""
                        wSql &= "    ,MAX(""積立金"") AS ""積立金"""
                        wSql &= "    ,MAX(""手数料"") AS ""手数料"""
                        wSql &= "    ,MAX(""【差額】請求(返還)金額計"") AS ""【差額】請求(返還)金額計"""
                        wSql &= "    ,MAX(""【差額】積立金（返還金）"") AS ""【差額】積立金（返還金）"""
                        wSql &= "    ,MAX(""【差額】手数料"") AS ""【差額】手数料"""
                        wSql &= "    ,MAX(""手数料率"") AS ""手数料率"""
                        wSql &= "    ,MAX(""請求（返還）日"") AS ""請求（返還）日"""
                        wSql &= "    ,MAX(""納付期限（振込予定日）"") AS ""納付期限（振込予定日）"""
                        wSql &= "    ,MAX(""請求返還区分コード"") AS ""請求返還区分コード"""
                        wSql &= "    ,MAX(""請求返還区分名"") AS ""請求返還区分名"""
                        wSql &= "    ,MAX(""入金区分コード"") AS ""入金区分コード"""
                        wSql &= "    ,MAX(""入金区分名"") AS ""入金区分名"""
                        wSql &= "    ,MAX(""請求書発行日"") AS ""請求書発行日"""
                        wSql &= "    ,MAX(""請求書発行番号(年)"") AS ""請求書発行番号(年)"""
                        wSql &= "    ,MAX(""請求書発行番号(連番)"") AS ""請求書発行番号(連番)"""
                        wSql &= "    ,MAX(""請求書再発行日"") AS ""請求書再発行日"""
                        wSql &= "    ,MAX(""督促状発行日"") AS ""督促状発行日"""
                        wSql &= "    ,MAX(""督促状発行番号(年)"") AS ""督促状発行番号(年)"""
                        wSql &= "    ,MAX(""督促状発行番号(連番)"") AS ""督促状発行番号(連番)"""
                        wSql &= "    ,MAX(""督促状再発行日"") AS ""督促状再発行日"""
                        wSql &= "    ,MAX(""督促納付期限"") AS ""督促納付期限"""
                        wSql &= "    ,MAX(""入金（返還）日"") AS ""入金（返還）日"""
                        wSql &= "    ,MAX(""入金(返還)入力日"") AS ""入金(返還)入力日"""
                        wSql &= "    ,MAX(""積立金入金区分コード"") AS ""積立金入金区分コード"""
                        wSql &= "    ,MAX(""積立金区分名"") AS ""積立金区分名"""
                        wSql &= "    ,MAX(""入金（返還）額計"") AS ""入金（返還）額計"""
                        wSql &= "    ,MAX(""積立金入金額"") AS ""積立金入金額"""
                        wSql &= "    ,MAX(""手数料入金額"") AS ""手数料入金額"""
                        wSql &= "    ,MAX(""備考"") AS ""備考"""
                        wSql &= "    ,MAX(""先請求回数"") AS ""先請求回数"""
                        wSql &= "    ,MAX(""データフラグ"") AS ""データフラグ"""
                        '             -- 積立金入金
                        wSql &= "    ,MAX(""入金回数１"") AS ""入金回数１"""
                        wSql &= "    ,MAX(""入金額１"") AS ""入金額１"""
                        wSql &= "    ,MAX(""積立金入金額１"") AS ""積立金入金額１"""
                        wSql &= "    ,MAX(""手数料入金額１"") AS ""手数料入金額１"""
                        wSql &= "    ,MAX(""入金残１"") AS ""入金残１"""
                        wSql &= "    ,MAX(""積立金入金日１"") AS ""積立金入金日１"""
                        wSql &= "    ,MAX(""積立金入金入力日１"") AS ""積立金入金入力日１"""
                        wSql &= "    ,MAX(""入金回数２"") AS ""入金回数２"""
                        wSql &= "    ,MAX(""入金額２"") AS ""入金額２"""
                        wSql &= "    ,MAX(""積立金入金額２"") AS ""積立金入金額２"""
                        wSql &= "    ,MAX(""手数料入金額２"") AS ""手数料入金額２"""
                        wSql &= "    ,MAX(""入金残２"") AS ""入金残２"""
                        wSql &= "    ,MAX(""積立金入金日２"") AS ""積立金入金日２"""
                        wSql &= "    ,MAX(""積立金入金入力日２"") AS ""積立金入金入力日２"""
                        wSql &= "    ,MAX(""入金回数３"") AS ""入金回数３"""
                        wSql &= "    ,MAX(""入金額３"") AS ""入金額３"""
                        wSql &= "    ,MAX(""積立金入金額３"") AS ""積立金入金額３"""
                        wSql &= "    ,MAX(""手数料入金額３"") AS ""手数料入金額３"""
                        wSql &= "    ,MAX(""入金残３"") AS ""入金残３"""
                        wSql &= "    ,MAX(""積立金入金日３"") AS ""積立金入金日３"""
                        wSql &= "    ,MAX(""積立金入金入力日３"") AS ""積立金入金入力日３"""
                        wSql &= " FROM"
                        wSql &= "    ("
                    End If

                    wSql &= "    SELECT"
                    wSql &= "         TUM.KI AS ""期"""
                    wSql &= "        ,TUM.KEIYAKUSYA_CD AS ""契約者番号"""
                    wSql &= "        ,KEI.KEN_CD AS ""都道府県コード"""
                    wSql &= "        ,CD05.MEISYO AS ""都道府県名"""
                    wSql &= "        ,KEI.KEIYAKU_KBN AS ""契約区分コード"""
                    wSql &= "        ,CD01.MEISYO AS ""契約区分名"""
                    wSql &= "        ,KEI.KEIYAKU_JYOKYO AS ""契約状況コード"""
                    wSql &= "        ,CD02.MEISYO AS ""契約状況名"""
                    wSql &= "        ,TO_CHAR(KEI.KEIYAKU_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""契約日"""
                    wSql &= "        ,KEI.KEIYAKUSYA_NAME AS ""契約者名"""
                    wSql &= "        ,KEI.KEIYAKUSYA_KANA AS ""契約者名（フリガナ）"""
                    wSql &= "        ,KEI.DAIHYO_NAME AS ""代表者名"""
                    wSql &= "        ,KEI.DAIHYO_KANA AS ""代表者氏名（フリガナ）"""
                    wSql &= "        ,KEI.JIMUITAKU_CD AS ""事務委託先番号"""
                    wSql &= "        ,ITK.ITAKU_NAME AS ""事務委託先名"""
                    '                -- 積立金 
                    wSql &= "        ,TUM.SEIKYU_KAISU AS ""請求（返還）回数"""
                    wSql &= "        ,TUM.TUMITATE_KBN AS ""積立金区分コード"""
                    wSql &= "        ,CASE"
                    wSql &= "            WHEN TUM.TUMITATE_KBN = 1 THEN '通常積立金'"
                    wSql &= "            WHEN TUM.TUMITATE_KBN = 2 THEN '特別積立金'"
                    wSql &= "         END ""積立金区分名"""
                    wSql &= "        ,TO_CHAR(TUM.KEIYAKU_DATE_FROM, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""契約年月日From"""
                    wSql &= "        ,TO_CHAR(TUM.KEIYAKU_DATE_TO, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""契約年月日To"""
                    wSql &= "        ,TUM.KEIYAKU_HENKO_KBN AS ""契約変更区分コード"""
                    wSql &= "        ,CD10.MEISYO AS ""契約変更区分名"""

                    wSql &= "        ,TUM.SEIKYU_KIN AS ""請求(返還)金額計"""
                    wSql &= "        ,TUM.TUMITATE_KIN AS ""積立金"""
                    wSql &= "        ,TUM.TESURYO AS ""手数料"""
                    wSql &= "        ,TUM.SAGAKU_SEIKYU_KIN AS ""【差額】請求(返還)金額計"""
                    wSql &= "        ,TUM.SAGAKU_TUMITATE_KIN AS ""【差額】積立金（返還金）"""
                    wSql &= "        ,TUM.SAGAKU_TESURYO AS ""【差額】手数料"""
                    wSql &= "        ,TUM.TESURYO_RITU AS ""手数料率"""

                    wSql &= "        ,TO_CHAR(TUM.SEIKYU_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""請求（返還）日"""
                    wSql &= "        ,TO_CHAR(TUM.NOFUKIGEN_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""納付期限（振込予定日）"""
                    wSql &= "        ,TUM.SEIKYU_HENKAN_KBN AS ""請求返還区分コード"""
                    wSql &= "        ,CD08.MEISYO AS ""請求返還区分名"""
                    wSql &= "        ,TUM.SYORI_JOKYO_KBN AS ""入金区分コード"""
                    wSql &= "        ,CD15.MEISYO AS ""入金区分名"""
                    wSql &= "        ,TO_CHAR(TUM.SEIKYU_HAKKO_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""請求書発行日"""
                    wSql &= "        ,TUM.SEIKYU_HAKKO_NO_NEN AS ""請求書発行番号(年)"""
                    wSql &= "        ,TUM.SEIKYU_HAKKO_NO_RENBAN AS ""請求書発行番号(連番)"""
                    wSql &= "        ,TO_CHAR(TUM.SEIKYU_SAIHAKKO_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""請求書再発行日"""
                    wSql &= "        ,TO_CHAR(TUM.TOKUSOKU_HAKKO_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""督促状発行日"""
                    wSql &= "        ,TUM.TOKUSOKU_HAKKO_NO_NEN AS ""督促状発行番号(年)"""
                    wSql &= "        ,TUM.TOKUSOKU_HAKKO_NO_RENBAN AS ""督促状発行番号(連番)"""
                    wSql &= "        ,TO_CHAR(TUM.TOKUSOKU_SAIHAKKO_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""督促状再発行日"""
                    wSql &= "        ,TO_CHAR(TUM.TOKUSOKU_KIGEN_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""督促納付期限"""
                    wSql &= "        ,TO_CHAR(TUM.NYUKIN_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""入金（返還）日"""
                    wSql &= "        ,TO_CHAR(TUM.NYUKIN_NYURYOKU_DATE, 'EEYY""年""MM""月""DD""日"" ', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""入金(返還)入力日"""
                    wSql &= "        ,TUM.NYUKIN_KBN AS ""積立金入金区分コード"""
                    wSql &= "        ,CASE"
                    wSql &= "            WHEN TUM.NYUKIN_KBN = 1 THEN '一括'"
                    wSql &= "            WHEN TUM.NYUKIN_KBN = 2 THEN '分割'"
                    wSql &= "            ELSE '未入金'"
                    wSql &= "         END ""積立金入金区分名"""
                    wSql &= "        ,TUM.NYUKIN_GAKU AS ""入金（返還）額計"""
                    wSql &= "        ,TUM.NYUKIN_TUMITATE AS ""積立金入金額"""
                    wSql &= "        ,TUM.NYUKIN_TESU AS ""手数料入金額"""
                    wSql &= "        ,REPLACE(TUM.BIKO, CHR(10), '')  AS ""備考"""
                    wSql &= "        ,TUM.SAKI_SEIKYU_KAISU AS ""先請求回数"""
                    wSql &= "        ,CASE WHEN TUM.DATA_FLG = 0 THEN '無効' ELSE '有効' END ""データフラグ"""
                    '                -- 積立金入金
                    wSql &= "        ,NYU.NYUKIN_KAISU_1 AS ""入金回数１"""
                    wSql &= "        ,NYU.NYUKIN_GAKU_1 AS ""入金額１"""
                    wSql &= "        ,NYU.NYUKIN_TUMITATE_1 AS ""積立金入金額１"""
                    wSql &= "        ,NYU.NYUKIN_TESU_1 AS ""手数料入金額１"""
                    wSql &= "        ,NYU.NYUKIN_ZAN_1 AS ""入金残１"""
                    wSql &= "        ,TO_CHAR(NYU.NYUKIN_DATE_1, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""積立金入金日１"""
                    wSql &= "        ,TO_CHAR(NYU.NYUKIN_NYURYOKU_DATE_1, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""積立金入金入力日１"""
                    '                 -- ,NYU.BIKO_1 AS ""備考１"""
                    wSql &= "        ,NYU.NYUKIN_KAISU_2 AS ""入金回数２"""
                    wSql &= "        ,NYU.NYUKIN_GAKU_2 AS ""入金額２"""
                    wSql &= "        ,NYU.NYUKIN_TUMITATE_2 AS ""積立金入金額２"""
                    wSql &= "        ,NYU.NYUKIN_TESU_2 AS ""手数料入金額２"""
                    wSql &= "        ,NYU.NYUKIN_ZAN_2 AS ""入金残２"""
                    wSql &= "        ,TO_CHAR(NYU.NYUKIN_DATE_2, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""積立金入金日２"""
                    wSql &= "        ,TO_CHAR(NYU.NYUKIN_NYURYOKU_DATE_2, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""積立金入金入力日２"""
                    '                 -- ,NYU.BIKO_2 AS ""備考２"""
                    wSql &= "        ,NYU.NYUKIN_KAISU_3 AS ""入金回数３"""
                    wSql &= "        ,NYU.NYUKIN_GAKU_3 AS ""入金額３"""
                    wSql &= "        ,NYU.NYUKIN_TUMITATE_3 AS ""積立金入金額３"""
                    wSql &= "        ,NYU.NYUKIN_TESU_3 AS ""手数料入金額３"""
                    wSql &= "        ,NYU.NYUKIN_ZAN_3 AS ""入金残３"""
                    wSql &= "        ,TO_CHAR(NYU.NYUKIN_DATE_3, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""積立金入金日３"""
                    wSql &= "        ,TO_CHAR(NYU.NYUKIN_NYURYOKU_DATE_3, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""積立金入金入力日３"""

                    '                 -- ,NYU.BIKO_3 AS ""備考３"""
                    '                 --積立金明細
                    wSql &= "        ,MEISAI.TORI_KBN AS ""鶏の種類コード"""
                    wSql &= "        ,CD07.MEISYO AS ""鶏の種類"""
                    wSql &= "        ,TO_CHAR(MEISAI.KEIYAKU_DATE_FROM, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""明細契約年月日FROM"""
                    wSql &= "        ,TO_CHAR(MEISAI.KEIYAKU_DATE_TO, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""明細契約年月日TO"""
                    wSql &= "        ,MEISAI.HASU AS ""明細羽数"""
                    wSql &= "        ,MEISAI.TUMITATE_TANKA AS ""明細積立単価"""
                    wSql &= "        ,MEISAI.TUMITATE_KIN AS ""明細積立金"""
                    wSql &= "        ,MEISAI.SAGAKU_TUMITATE_KIN AS ""明細【差額】積立金（返還金）"""
                    wSql &= "        ,MEISAI.SAKI_SEIKYU_KAISU AS ""明細先請求回数"""
                    wSql &= "        ,CASE WHEN MEISAI.DATA_FLG = 0 THEN '無効' ELSE '有効' END ""明細データフラグ"""
                    wSql &= "    FROM TT_TUMITATE TUM"
                    wSql &= "        ,TT_TUMITATE_MEISAI MEISAI"
                    '                 -- 積立金入金
                    wSql &= "        ,("
                    wSql &= "         SELECT "
                    wSql &= "              KI"
                    wSql &= "             ,SEIKYU_KAISU"
                    wSql &= "             ,KEIYAKUSYA_CD"
                    wSql &= "             ,TUMITATE_KBN"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 1 THEN NYUKIN_KAISU END) NYUKIN_KAISU_1"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 1 THEN NYUKIN_GAKU END) NYUKIN_GAKU_1"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 1 THEN NYUKIN_TUMITATE END) NYUKIN_TUMITATE_1"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 1 THEN NYUKIN_TESU END) NYUKIN_TESU_1"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 1 THEN NYUKIN_ZAN END) NYUKIN_ZAN_1"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 1 THEN NYUKIN_DATE END) NYUKIN_DATE_1"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 1 THEN NYUKIN_NYURYOKU_DATE END) NYUKIN_NYURYOKU_DATE_1"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 1 THEN BIKO END) BIKO_1"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 2 THEN NYUKIN_KAISU END) NYUKIN_KAISU_2"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 2 THEN NYUKIN_GAKU END) NYUKIN_GAKU_2"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 2 THEN NYUKIN_TUMITATE END) NYUKIN_TUMITATE_2"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 2 THEN NYUKIN_TESU END) NYUKIN_TESU_2"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 2 THEN NYUKIN_ZAN END) NYUKIN_ZAN_2"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 2 THEN NYUKIN_DATE END) NYUKIN_DATE_2"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 2 THEN NYUKIN_NYURYOKU_DATE END) NYUKIN_NYURYOKU_DATE_2"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 2 THEN BIKO END) BIKO_2"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 3 THEN NYUKIN_KAISU END) NYUKIN_KAISU_3"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 3 THEN NYUKIN_GAKU END) NYUKIN_GAKU_3"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 3 THEN NYUKIN_TUMITATE END) NYUKIN_TUMITATE_3"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 3 THEN NYUKIN_TESU END) NYUKIN_TESU_3"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 3 THEN NYUKIN_ZAN END) NYUKIN_ZAN_3"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 3 THEN NYUKIN_DATE END) NYUKIN_DATE_3"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 3 THEN NYUKIN_NYURYOKU_DATE END) NYUKIN_NYURYOKU_DATE_3"
                    wSql &= "             ,MAX(CASE WHEN ROW_NUM = 3 THEN BIKO END) BIKO_3"
                    wSql &= "          FROM"
                    wSql &= "             ("
                    wSql &= "             SELECT"
                    wSql &= "                  ROW_NUMBER() OVER (PARTITION BY KI,SEIKYU_KAISU,KEIYAKUSYA_CD,TUMITATE_KBN ORDER BY KI,SEIKYU_KAISU,KEIYAKUSYA_CD,TUMITATE_KBN,NYUKIN_KAISU) as ROW_NUM"
                    wSql &= "                 ,KI"
                    wSql &= "                 ,SEIKYU_KAISU"
                    wSql &= "                 ,KEIYAKUSYA_CD"
                    wSql &= "                 ,TUMITATE_KBN"
                    wSql &= "                 ,NYUKIN_KAISU"
                    wSql &= "                 ,NYUKIN_GAKU"
                    wSql &= "                 ,NYUKIN_TUMITATE"
                    wSql &= "                 ,NYUKIN_TESU"
                    wSql &= "                 ,NYUKIN_ZAN"
                    wSql &= "                 ,NYUKIN_DATE"
                    wSql &= "                 ,NYUKIN_NYURYOKU_DATE"
                    wSql &= "                 ,BIKO "
                    wSql &= "              FROM TT_TUMITATE_NYUKIN"
                    wSql &= "              WHERE"
                    '                           -- 条件
                    wSql &= "                  KI = " & numKI.Text.Trim
                    '                           --積立区分
                    wSql &= "              AND TUMITATE_KBN = 1"
                    wSql &= "             ORDER BY KI,SEIKYU_KAISU,KEIYAKUSYA_CD,TUMITATE_KBN"
                    wSql &= "             ) "
                    wSql &= "          GROUP BY KI,SEIKYU_KAISU,KEIYAKUSYA_CD,TUMITATE_KBN"
                    wSql &= "          ORDER BY KI,SEIKYU_KAISU,KEIYAKUSYA_CD,TUMITATE_KBN"
                    wSql &= "          ) NYU"
                    wSql &= "         ,TM_KEIYAKU KEI"
                    wSql &= "         ,TM_KEIYAKU ZKY"       '2016/03/14　追加　 前期の契約マスタ
                    wSql &= "         ,TM_JIMUITAKU ITK"
                    wSql &= "         ,TM_CODE CD01"
                    wSql &= "         ,TM_CODE CD02"
                    wSql &= "         ,TM_CODE CD05"
                    wSql &= "         ,TM_CODE CD07"
                    wSql &= "         ,TM_CODE CD08"
                    wSql &= "         ,TM_CODE CD10"
                    wSql &= "         ,TM_CODE CD15"
                    wSql &= "    WHERE"
                    '                  -- 契約者マスタ
                    wSql &= "          TUM.KI = KEI.KI(+)"
                    wSql &= "      AND TUM.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+)"
                    '                 -- 前期の契約マスタ
                    wSql &= "      AND (TUM.KI - 1) = ZKY.KI(+)"                    '2016/03/14　追加
                    wSql &= "      AND TUM.KEIYAKUSYA_CD = ZKY.KEIYAKUSYA_CD(+)"    '2016/03/14　追加
                    '                  -- 積立金明細
                    wSql &= "      AND TUM.KI = MEISAI.KI(+)"
                    wSql &= "      AND TUM.KEIYAKUSYA_CD = MEISAI.KEIYAKUSYA_CD(+)"
                    wSql &= "      AND TUM.SEIKYU_KAISU = MEISAI.SEIKYU_KAISU(+)"
                    wSql &= "      AND TUM.TUMITATE_KBN = MEISAI.TUMITATE_KBN(+)"
                    '                  -- 積立金入金
                    wSql &= "      AND TUM.KI = NYU.KI(+)"
                    wSql &= "      AND TUM.KEIYAKUSYA_CD = NYU.KEIYAKUSYA_CD(+)"
                    wSql &= "      AND TUM.SEIKYU_KAISU = NYU.SEIKYU_KAISU(+)"
                    wSql &= "      AND TUM.TUMITATE_KBN = NYU.TUMITATE_KBN(+)"
                    '                  -- 契約区分
                    wSql &= "      AND KEI.KEIYAKU_KBN = CD01.MEISYO_CD(+)"
                    wSql &= "      AND 1 = CD01.SYURUI_KBN(+)"
                    '                  -- 契約状況
                    wSql &= "      AND KEI.KEIYAKU_JYOKYO = CD02.MEISYO_CD(+)"
                    wSql &= "      AND 2 = CD02.SYURUI_KBN(+)"
                    '                  -- 都道府県
                    wSql &= "      AND KEI.KEN_CD = CD05.MEISYO_CD(+)"
                    wSql &= "      AND 5 = CD05.SYURUI_KBN(+)"
                    '                  -- 事務委託先
                    wSql &= "      AND KEI.KI = ITK.KI(+)"
                    wSql &= "      AND KEI.JIMUITAKU_CD = ITK.ITAKU_CD(+)"
                    '                  -- 契約変更区分
                    wSql &= "      AND TUM.KEIYAKU_HENKO_KBN = CD10.MEISYO_CD(+)"
                    wSql &= "      AND 10 = CD10.SYURUI_KBN(+)"
                    '                  -- 請求・返還区分
                    wSql &= "      AND TUM.SEIKYU_HENKAN_KBN = CD08.MEISYO_CD(+)"
                    wSql &= "      AND 8 = CD08.SYURUI_KBN(+)"
                    '                  -- 入金区分
                    wSql &= "      AND TUM.SYORI_JOKYO_KBN = CD15.MEISYO_CD(+)"
                    wSql &= "      AND 15 = CD15.SYURUI_KBN(+)"
                    '                  -- 鶏の種類
                    wSql &= "      AND MEISAI.TORI_KBN = CD07.MEISYO_CD(+)"
                    wSql &= "      AND 7 = CD07.SYURUI_KBN(+)"
                    '                  -- 条件
                    wSql &= "     AND TUM.KI = " & numKI.Text.Trim
                    '	               --積立区分
                    'wSql &= "     AND TUM.TUMITATE_KBN = 1"

                    '2018/03/07　修正開始
                    'wSql &= "     AND (   TUM.KEIYAKU_DATE_FROM <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                    'wSql &= "         AND TUM.KEIYAKU_DATE_TO   >= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                    'wSql &= "         )"
                    If rbtnOutMEISAI.Checked Then
                        '--全データは、対象年月の末日で有効のデータのみ出力
                        wSql &= "     AND (   TUM.KEIYAKU_DATE_FROM <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                        wSql &= "         AND TUM.KEIYAKU_DATE_TO   >= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                        wSql &= "         )"
                    Else
                        '--全データ以外は、差額請求が０以外(請求あり)のデータのみ出力
                        wSql &= "     AND (TUM.SAGAKU_SEIKYU_KIN <> 0 OR TUM.SAGAKU_TUMITATE_KIN <> 0 OR TUM.SAGAKU_TESURYO <> 0)"  '2018/03/07　追加
                    End If
                    '2018/03/07　追加終了

                    '                 -- 未契約者および未来契約者を除く
                    If chk_MikeiyakuNozoku.Checked Then     '2015/12/07　追加
                        '2016/03/14　修正開始
                        'wSql &= "     AND KEI.KEIYAKU_DATE IS NOT NULL"
                        'wSql &= "     AND KEI.KEIYAKU_DATE <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                        wSql &= "    AND CASE WHEN TUM.SEIKYU_HENKAN_KBN = 4"                      '--全額返還"
                        wSql &= "             THEN CASE WHEN ZKY.KEIYAKU_DATE IS NULL THEN 0"      '--対象外"
                        wSql &= "                       WHEN ZKY.KEIYAKU_DATE <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd')) THEN 1"  '--対象"
                        wSql &= "                       ELSE 0 END"                                '--対象外"
                        wSql &= "             ELSE CASE WHEN KEI.KEIYAKU_DATE IS NULL THEN 0"      '--対象外"
                        wSql &= "                       WHEN KEI.KEIYAKU_DATE <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd')) THEN 1"  '--対象"
                        wSql &= "                       ELSE 0 END"                                '--対象外"
                        wSql &= "        END = 1"
                        '2016/03/14　修正開始
                    End If                                  '2015/12/07　追加

                    wSql &= wWhere & " "

                    wSql &= "    ORDER BY"
                    wSql &= "         TUM.KI"
                    wSql &= "        ,TUM.KEIYAKUSYA_CD"
                    '↓2015/04/02 JBD368 ADD 出力順に請求（返還）回数を追加
                    wSql &= "        ,TUM.SEIKYU_KAISU"
                    '↑2015/04/02 JBD368 ADD
                    wSql &= "        ,MEISAI.TORI_KBN"
                    wSql &= "        ,MEISAI.KEIYAKU_DATE_FROM"    '2017/07/31　追加
                    '請求金額、手数料のみ
                    If rbtnOutKIHON.Checked Then
                        wSql &= "    )"
                        wSql &= " GROUP BY"
                        wSql &= "    ""期"""
                        wSql &= "   ,""契約者番号"""
                        wSql &= "   ,""請求（返還）回数"""      '2017/03/07　追加
                        wSql &= " ORDER BY"
                        wSql &= "    ""期"""
                        wSql &= "   ,""契約者番号"""
                        wSql &= "   ,""請求（返還）回数"""      '2017/03/07　追加

                        '↓2015/04/03 JBD368 DEL
                        'wSql &= "   ,""請求（返還）回数"""
                        'wSql &= "   ,""鶏の種類コード"""
                        '↑2015/04/03 JBD368 DEL
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
