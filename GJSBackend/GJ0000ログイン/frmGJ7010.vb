'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ7010.vb
'*
'*　　②　機能概要　　　　　互助基金契約者情報検索ＣＳＶデータ作成
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

Public Class frmGJ7010

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
    Public paryKEY_7010 As New List(Of T_KEY)

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
            'f_makeCSVByDT(wkDS.Tables(0), "KEIYAKUSYA_")
            If pKikin2 Then
                f_makeCSVByDT(wkDS.Tables(0), "KEIYAKUSYA(追加納付)_")
            Else
                f_makeCSVByDT(wkDS.Tables(0), "KEIYAKUSYA_")
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


#Region "未契約者を除く"
    '------------------------------------------------------------------
    'プロシージャ名  :chk_MikeiyakuNozoku_CheckedChanged
    '説明            :未契約者を除く項目変更時
    '作成日          :2015/12/21
    '------------------------------------------------------------------
    Private Sub chk_MikeiyakuNozoku_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_MikeiyakuNozoku.CheckedChanged

        Try
            If chk_MikeiyakuNozoku.Checked Then
                '契約情報の契約日(初期値)：システム日付
                dateTAISYO_Ym.Value = Now
                dateTAISYO_Ym.Enabled = True
                '2021/07/12 JBD9020 新契約日追加 ADD START
                'chk_MinyukinNozoku.Enabled = True
                'chk_MinyukinNozoku.Checked = True
                '2021/07/12 JBD9020 新契約日追加 ADD END
            Else
                '契約情報の契約日入力不可
                dateTAISYO_Ym.Value = Nothing
                dateTAISYO_Ym.Enabled = False
                '2021/07/12 JBD9020 新契約日追加 ADD START
                'chk_MinyukinNozoku.Enabled = False
                'chk_MinyukinNozoku.Checked = False
                '2021/07/12 JBD9020 新契約日追加 ADD END
            End If

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

#Region "鶏の種類区分FromTo"
    '------------------------------------------------------------------
    'プロシージャ名  :cboTORI_KBN_Cd_Fm_SelectedIndexChanged
    '説明            :鶏の種類区分コードFromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboTORI_KBN_Cd_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboTORI_KBN_Cd_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboTORI_KBN_Nm_Fm.SelectedIndex = cboTORI_KBN_Cd_Fm.SelectedIndex
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboTORI_KBN_Nm_Fm_SelectedIndexChanged
    '説明            :鶏の種類区分名FromChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboTORI_KBN_Nm_Fm_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboTORI_KBN_Nm_Fm.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiFrom_SelectedIndexChanged(cboTORI_KBN_Nm_Fm, cboTORI_KBN_Cd_Fm, cboTORI_KBN_Nm_To, cboTORI_KBN_Cd_To)
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cboTORI_KBN_Cd_Fm_Validating
    '説明            :鶏の種類区分コードFromValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboTORI_KBN_Cd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboTORI_KBN_Cd_Fm.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboFrom_Validating(cboTORI_KBN_Cd_Fm, cboTORI_KBN_Nm_Fm, cboTORI_KBN_Cd_To, cboTORI_KBN_Nm_To)
    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cboTORI_KBN_Cd_To_SelectedIndexChanged
    '説明            :鶏の種類区分コードToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboTORI_KBN_Cd_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboTORI_KBN_Cd_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        cboTORI_KBN_Nm_To.SelectedIndex = cboTORI_KBN_Cd_To.SelectedIndex
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboTORI_KBN_Nm_To_SelectedIndexChanged
    '説明            :鶏の種類区分名ToChanegeイベント
    '------------------------------------------------------------------
    Private Sub cboTORI_KBN_Nm_To_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboTORI_KBN_Nm_To.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        s_CboMeiTo_Validating(cboTORI_KBN_Nm_To, cboTORI_KBN_Cd_To, cboTORI_KBN_Nm_Fm, cboTORI_KBN_Cd_Fm)
    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :cboTORI_KBN_Cd_To_Validating
    '説明            :鶏の種類区分コードToValidatingイベント
    '------------------------------------------------------------------
    Private Sub cboTORI_KBN_Cd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboTORI_KBN_Cd_To.Validating
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If
        Call s_CboTo_Validating(cboTORI_KBN_Cd_To, cboTORI_KBN_Nm_To, cboTORI_KBN_Cd_Fm, cboTORI_KBN_Nm_Fm)
    End Sub
#End Region

#Region "契約年月日関連"
    '------------------------------------------------------------------
    'プロシージャ名  :dateKEIYAKU_Ymd_Fm_Validating
    '説明            :契約年月日FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateKEIYAKU_Ymd_Fm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateKEIYAKU_Ymd_Fm.Validating

        Call s_From_Validating(dateKEIYAKU_Ymd_Fm, dateKEIYAKU_Ymd_To)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :dateKEIYAKU_Ymd_To_Validating
    '説明            :契約年月日TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateKEIYAKU_Ymd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateKEIYAKU_Ymd_To.Validating

        'Call s_To_Validating(dateKEIYAKU_Ymd_To, dateKEIYAKU_Ymd_Fm)

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
            rbtnOutMEISAI.Checked = True
            rbtnSearchAnd.Checked = True
            chk_MikeiyakuNozoku.Checked = True    '2015/12/07　追加
            chk_MinyukinNozoku.Checked = True    '2021/07/06 JBD9020 新契約日追加 ADD

            lblCOUNT_HED.Text = "0"     '抽出件数
            lblCOUNT_DTL.Text = "0"     '抽出件数

            '変数クリア
            paryKEY_7010 = New List(Of T_KEY)
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


                '鶏区分
                'FROM
                If Not f_CodeMaster_Data_Select(cboTORI_KBN_Cd_Fm, cboTORI_KBN_Nm_Fm, 7, True, 1) Then
                    Exit Try
                End If
                'TO
                If Not f_CodeMaster_Data_Select(cboTORI_KBN_Cd_To, cboTORI_KBN_Nm_To, 7, True, 1) Then
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
                cboTORI_KBN_Cd_Fm.Text = ""
                cboTORI_KBN_Cd_To.Text = ""


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
            cboKEIYAKUSYA_Cd_Fm.Text = ""
            cboKEIYAKUSYA_Cd_To.Text = ""

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
            If chk_MikeiyakuNozoku.Checked Then     '2015/12/12　追加
                If dateTAISYO_Ym.Value Is Nothing Then
                    Show_MessageBox_Add("W008", "対象年月")
                    dateTAISYO_Ym.Focus()
                    Exit Try
                End If
            End If                                  '2015/12/12　追加

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

            '鶏の種類
            If f_Daisyo_Check(cboTORI_KBN_Cd_Fm, cboTORI_KBN_Cd_To, "鶏の種類", True, 1) = False Then
                Exit Try
            End If


            '契約年月日
            If f_Daisyo_Check(dateKEIYAKU_Ymd_Fm, dateKEIYAKU_Ymd_To, "契約年月日", True, 2) = False Then
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

            '鶏の種類FROM
            If cboTORI_KBN_Cd_Fm.Text.Trim <> "" AndAlso cboTORI_KBN_Cd_To.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " KEIJOHO.TORI_KBN BETWEEN " & cboTORI_KBN_Cd_Fm.Text.Trim & " and " & cboTORI_KBN_Cd_To.Text.Trim & ")"
            End If

            '契約年月日From
            If Not (dateKEIYAKU_Ymd_Fm.Value Is Nothing) And Not (dateKEIYAKU_Ymd_To.Value Is Nothing) Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " KEI.KEIYAKU_DATE BETWEEN TO_DATE('" & Format(dateKEIYAKU_Ymd_Fm.Value, "yyyy/MM/dd").TrimEnd & "') and TO_DATE('" & Format(dateKEIYAKU_Ymd_To.Value, "yyyy/MM/dd").TrimEnd & "'))"
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
                    wSql &= "    ,MAX(DTL.KEIYAKUSYA_KANA) AS KEIYAKUSYA_KANA"
                    wSql &= "    ,MAX(DTL.KEIYAKU_KBN) AS KEIYAKU_KBN"
                    wSql &= "    ,MAX(DTL.KEIYAKU_KBN_NM) AS KEIYAKU_KBN_NM"
                    wSql &= "    ,MAX(DTL.KEIYAKU_JYOKYO) AS KEIYAKU_JYOKYO"
                    wSql &= "    ,MAX(DTL.KEIYAKU_JYOKYO_NM) AS KEIYAKU_JYOKYO_NM"
                    wSql &= "    ,MAX(DTL.ADDR_TEL1) AS ADDR_TEL1"
                    wSql &= "    ,MAX(DTL.KEN_CD) AS KEN_CD"
                    wSql &= "    ,MAX(DTL.KEN_CD_NM) AS KEN_CD_NM"
                    wSql &= "    ,MAX(DTL.JIMUITAKU_CD) AS JIMUITAKU_CD"
                    wSql &= "    ,MAX(DTL.ITAKU_NAME) AS ITAKU_NAME"
                    wSql &= "    ,MAX(DTL.DLT_CNT) AS COUNT_DTL"

                    wSql &= " FROM"
                    wSql &= "    ("
                    wSql &= "    SELECT"
                    '2015/12/21　修正開始
                    'wSql &= "         KEIJOHO.KI AS KI"
                    'wSql &= "        ,KEIJOHO.KEIYAKUSYA_CD AS KEIYAKUSYA_CD"
                    wSql &= "         KEI.KI AS KI"
                    wSql &= "        ,KEI.KEIYAKUSYA_CD AS KEIYAKUSYA_CD"
                    '2015/12/21　修正終了
                    wSql &= "        ,KEI.KEIYAKUSYA_NAME AS KEIYAKUSYA_NAME"
                    wSql &= "        ,KEI.KEIYAKUSYA_KANA AS KEIYAKUSYA_KANA"
                    wSql &= "        ,KEI.KEIYAKU_KBN AS KEIYAKU_KBN"
                    '↓2017/07/13 修正 契約区分
                    'wSql &= "        ,CD01.RYAKUSYO AS KEIYAKU_KBN_NM"
                    wSql &= "        ,CD01.MEISYO AS KEIYAKU_KBN_NM"
                    '↑2017/07/13 修正 契約区分
                    wSql &= "        ,KEI.KEIYAKU_JYOKYO AS KEIYAKU_JYOKYO"
                    wSql &= "        ,CD02.RYAKUSYO AS KEIYAKU_JYOKYO_NM"
                    wSql &= "        ,KEI.ADDR_TEL1 AS ADDR_TEL1"
                    wSql &= "        ,KEI.KEN_CD AS KEN_CD"
                    '                    wSql &= "        ,CD05.RYAKUSYO AS KEN_CD_NM"
                    wSql &= "        ,LPAD(KEI.KEN_CD,2) || CD05.RYAKUSYO KEN_CD_NM"
                    wSql &= "        ,KEI.JIMUITAKU_CD AS JIMUITAKU_CD"
                    wSql &= "        ,ITK.ITAKU_NAME AS ITAKU_NAME"
                    wSql &= "        ,COUNT(KEIJOHO.KI) OVER() AS DLT_CNT"
                    wSql &= "    FROM TT_KEIYAKU_JOHO KEIJOHO"
                    wSql &= "        ,TM_KEIYAKU KEI"
                    wSql &= "        ,TM_KEIYAKU_NOJO NOJO"
                    wSql &= "        ,TM_CODE CD01"
                    wSql &= "        ,TM_CODE CD02"
                    wSql &= "        ,TM_CODE CD05"
                    wSql &= "        ,TM_JIMUITAKU ITK"
                    wSql &= "    WHERE"
                    '2015/12/21　修正開始
                    'メインテーブルを契約情報から契約マスタに変更
                    '                 -- 契約者マスタ
                    'wSql &= "         KEIJOHO.KI = KEI.KI(+)"
                    'wSql &= "     AND KEIJOHO.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+)"
                    '                 -- 契約者マスタ
                    wSql &= "         KEI.KI = " & numKI.Text.Trim
                    wSql &= "     AND KEI.KI = KEIJOHO.KI(+)"
                    wSql &= "     AND KEI.KEIYAKUSYA_CD = KEIJOHO.KEIYAKUSYA_CD(+)"
                    '2015/12/21　修正終了
                    '                 -- 契約者農場マスタ
                    wSql &= "     AND KEIJOHO.KI = NOJO.KI(+)"
                    wSql &= "     AND KEIJOHO.KEIYAKUSYA_CD = NOJO.KEIYAKUSYA_CD(+)"
                    wSql &= "     AND KEIJOHO.NOJO_CD = NOJO.NOJO_CD(+)"
                    '                 -- 契約区分
                    wSql &= "     AND KEI.KEIYAKU_KBN = CD01.MEISYO_CD(+)"
                    wSql &= "     AND 1 = CD01.SYURUI_KBN(+)"
                    '                 -- 契約状況
                    wSql &= "     AND KEI.KEIYAKU_JYOKYO = CD02.MEISYO_CD(+)"
                    wSql &= "     AND 2 = CD02.SYURUI_KBN(+)"
                    '                 -- 都道府県
                    wSql &= "     AND KEI.KEN_CD = CD05.MEISYO_CD(+)"
                    wSql &= "     AND 5 = CD05.SYURUI_KBN(+)"
                    '                 -- 事務委託先
                    wSql &= "     AND KEI.KI = ITK.KI(+)"
                    wSql &= "     AND KEI.JIMUITAKU_CD = ITK.ITAKU_CD(+)"

                    '                 -- 条件
                    'wSql &= "     AND KEIJOHO.KI = " & numKI.Text.Trim     '2015/12/07　削除

                    '未契約者除くとき
                    If chk_MikeiyakuNozoku.Checked Then     '2015/12/07　修正
                        '契約情報の契約日
                        wSql &= "     AND (   KEIJOHO.KEIYAKU_DATE_FROM <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                        wSql &= "         AND KEIJOHO.KEIYAKU_DATE_TO   >= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                        wSql &= "         )"
                    End If                                  '2015/12/07　修正

                    '未契約者除くとき
                    If chk_MikeiyakuNozoku.Checked Then       '2015/12/07　修正
                        '                 -- 未契約者および未来契約者を除く
                        wSql &= "     AND KEI.KEIYAKU_DATE IS NOT NULL"
                        wSql &= "     AND KEI.KEIYAKU_DATE <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                    End If                              '2015/12/07　修正

                    '2021/07/06 JBD9020 新契約日追加 ADD START
                    '未入金除くとき
                    If chk_MinyukinNozoku.Checked Then
                        wSql &= "     AND KEI.NYU_HEN_DATE IS NOT NULL"
                    End If
                    '2021/07/06 JBD9020 新契約日追加 ADD END

                    wSql &= wWhere & " "

                    wSql &= "    ORDER BY"
                    '2015/12/21　修正開始
                    'wSql &= "         KEIJOHO.KI"
                    'wSql &= "        ,KEIJOHO.KEIYAKUSYA_CD"
                    wSql &= "         KEI.KI"
                    wSql &= "        ,KEI.KEIYAKUSYA_CD"
                    '2015/12/21　修正終了
                    wSql &= "    ) DTL"
                    wSql &= " GROUP BY"
                    wSql &= "     DTL.KI"
                    wSql &= "    ,DTL.KEIYAKUSYA_CD "
                    wSql &= " ORDER BY"
                    wSql &= "     DTL.KI"
                    wSql &= "    ,DTL.KEIYAKUSYA_CD "

                Case 1      'CSV出力ボタンクリック時の検索条件


                    '==SQL作成====================
                    '契約基本情報のみ
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
                        wSql &= "    ,MAX(""郵便番号"") AS ""郵便番号"""
                        wSql &= "    ,MAX(""住所１"") AS ""住所１"""
                        wSql &= "    ,MAX(""住所２"") AS ""住所２"""
                        wSql &= "    ,MAX(""住所３"") AS ""住所３"""
                        wSql &= "    ,MAX(""住所４"") AS ""住所４"""
                        wSql &= "    ,MAX(""電話番号1"") AS ""電話番号1"""
                        wSql &= "    ,MAX(""電話番号2"") AS ""電話番号2"""
                        wSql &= "    ,MAX(""ＦＡＸ"") AS ""ＦＡＸ"""
                        wSql &= "    ,MAX(""メールアドレス"") AS ""メールアドレス"""
                        wSql &= "    ,MAX(""事務委託先番号"") AS ""事務委託先番号"""
                        wSql &= "    ,MAX(""事務委託先名"") AS ""事務委託先名"""
                        wSql &= "    ,MAX(""金融機関コード"") AS ""金融機関コード"""
                        wSql &= "    ,MAX(""金融機関名"") AS ""金融機関名"""
                        wSql &= "    ,MAX(""支店コード"") AS ""支店コード"""
                        wSql &= "    ,MAX(""支店名"") AS ""支店名"""
                        wSql &= "    ,MAX(""口座種別コード"") AS ""口座種別コード"""
                        wSql &= "    ,MAX(""口座種別名"") AS ""口座種別名"""
                        wSql &= "    ,MAX(""口座番号"") AS ""口座番号"""
                        wSql &= "    ,MAX(""口座名義人"") AS ""口座名義人"""
                        wSql &= "    ,MAX(""口座名義人（カナ）"") AS ""口座名義人（カナ）"""
                        wSql &= "    ,MAX(""備考"") AS ""備考"""
                        wSql &= "    ,MAX(""入力状況コード"") AS ""入力状況コード"""
                        wSql &= "    ,MAX(""入力状況"") AS ""入力状況"""
                        wSql &= "    ,MAX(""廃業日"") AS ""廃業日"""
                        wSql &= "    ,MAX(""経営安定対策事業生産者番号"") AS ""経営安定対策事業生産者番号"""
                        wSql &= "    ,MAX(""日鶏協番号"") AS ""日鶏協番号"""
                        wSql &= " FROM"
                        wSql &= "    ("
                    End If

                    wSql &= "    SELECT"
                    '2015/12/21　修正開始
                    'wSql &= "         KEIJOHO.KI AS ""期"""
                    'wSql &= "        ,KEIJOHO.KEIYAKUSYA_CD AS ""契約者番号"""
                    wSql &= "         KEI.KI AS ""期"""
                    wSql &= "        ,KEI.KEIYAKUSYA_CD AS ""契約者番号"""
                    '2015/12/21　修正終了
                    wSql &= "        ,KEI.KEN_CD AS ""都道府県コード"""
                    wSql &= "        ,CD05.MEISYO AS ""都道府県名"""
                    wSql &= "        ,KEI.KEIYAKU_KBN AS ""契約区分コード"""
                    wSql &= "        ,CD01.MEISYO AS ""契約区分名"""
                    wSql &= "        ,KEI.KEIYAKU_JYOKYO AS ""契約状況コード"""
                    wSql &= "        ,CD02.MEISYO AS ""契約状況名"""
                    wSql &= "        ,TO_CHAR(KEI.KEIYAKU_DATE, 'EEYY""年""MM""月""DD""日"" ', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""契約日"""
                    wSql &= "        ,TO_CHAR(KEI.NYU_HEN_DATE, 'EEYY""年""MM""月""DD""日"" ', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""入金返還日"""
                    wSql &= "        ,KEI.KEIYAKUSYA_NAME AS ""契約者名"""
                    wSql &= "        ,KEI.KEIYAKUSYA_KANA AS ""契約者名（フリガナ）"""
                    wSql &= "        ,KEI.DAIHYO_NAME AS ""代表者名"""
                    wSql &= "        ,KEI.DAIHYO_KANA AS ""代表者氏名（フリガナ）"""
                    wSql &= "        ,DECODE(KEI.ADDR_POST, NULL, '', ('〒' || SUBSTR(KEI.ADDR_POST,1,3) || '-' || SUBSTR(KEI.ADDR_POST,4,4))) AS ""郵便番号"""
                    wSql &= "        ,KEI.ADDR_1 AS ""住所１"""
                    wSql &= "        ,KEI.ADDR_2 AS ""住所２"""
                    wSql &= "        ,KEI.ADDR_3 AS ""住所３"""
                    wSql &= "        ,KEI.ADDR_4 AS ""住所４"""
                    wSql &= "        ,KEI.ADDR_TEL1 AS ""電話番号1"""
                    wSql &= "        ,KEI.ADDR_TEL2 AS ""電話番号2"""
                    wSql &= "        ,KEI.ADDR_FAX AS ""ＦＡＸ"""
                    wSql &= "        ,KEI.ADDR_E_MAIL AS ""メールアドレス"""
                    wSql &= "        ,KEI.JIMUITAKU_CD AS ""事務委託先番号"""
                    wSql &= "        ,ITK.ITAKU_NAME AS ""事務委託先名"""
                    wSql &= "        ,KEI.FURI_BANK_CD AS ""金融機関コード"""
                    wSql &= "        ,BANK.BANK_NAME AS ""金融機関名"""
                    wSql &= "        ,KEI.FURI_BANK_SITEN_CD AS ""支店コード"""
                    wSql &= "        ,SITEN.SITEN_NAME AS ""支店名"""
                    wSql &= "        ,KEI.FURI_KOZA_SYUBETU AS ""口座種別コード"""
                    wSql &= "        ,CD04.MEISYO AS ""口座種別名"""
                    wSql &= "        ,KEI.FURI_KOZA_NO AS ""口座番号"""
                    wSql &= "        ,KEI.FURI_KOZA_MEIGI AS ""口座名義人"""
                    wSql &= "        ,KEI.FURI_KOZA_MEIGI_KANA AS ""口座名義人（カナ）"""
                    wSql &= "        ,REPLACE(KEI.BIKO, CHR(10), '') AS ""備考"""
                    wSql &= "        ,KEI.NYURYOKU_JYOKYO AS ""入力状況コード"""
                    wSql &= "        ,CD12.MEISYO AS ""入力状況"""
                    wSql &= "        ,TO_CHAR(KEI.HAIGYO_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""廃業日"""
                    wSql &= "        ,KEI.SEISANSYA_CD AS ""経営安定対策事業生産者番号"""
                    wSql &= "        ,KEI.NIKKEIKYO_CD AS ""日鶏協番号"""
                    '                --契約者農場マスタ情報
                    wSql &= "        ,NOJO.MEISAI_NO AS ""明細番号"""
                    wSql &= "        ,KEIJOHO.NOJO_CD AS ""農場コード"""
                    wSql &= "        ,NOJO.KEN_CD AS ""農場都道府県コード"""
                    wSql &= "        ,CD05N.MEISYO AS ""農場都道府県名"""
                    wSql &= "        ,NOJO.NOJO_NAME AS ""農場名"""
                    '↓2015/03/29 JBD368 UPD 郵便番号の出力項目を修正
                    'wSql &= "        ,DECODE(NOJO.ADDR_POST, NULL, '', ('〒' || SUBSTR(KEI.ADDR_POST,1,3) || '-' || SUBSTR(KEI.ADDR_POST,4,4))) AS ""農場郵便番号"""
                    wSql &= "        ,DECODE(NOJO.ADDR_POST, NULL, '', ('〒' || SUBSTR(NOJO.ADDR_POST,1,3) || '-' || SUBSTR(NOJO.ADDR_POST,4,4))) AS ""農場郵便番号"""
                    '↑2015/03/29 JBD368 UPD
                    wSql &= "        ,NOJO.ADDR_1 AS ""農場住所１"""
                    wSql &= "        ,NOJO.ADDR_2 AS ""農場住所２"""
                    wSql &= "        ,NOJO.ADDR_3 AS ""農場住所３"""
                    wSql &= "        ,NOJO.ADDR_4 AS ""農場住所４"""
                    '                -- 契約情報
                    wSql &= "        ,TO_CHAR(KEIJOHO.KEIYAKU_DATE_FROM, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""契約年月日From"""
                    wSql &= "        ,TO_CHAR(KEIJOHO.KEIYAKU_DATE_TO, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ""契約年月日To"""
                    wSql &= "        ,KEIJOHO.TORI_KBN AS ""鶏の種類コード"""
                    wSql &= "        ,CD07.MEISYO AS ""鶏の種類"""
                    wSql &= "        ,KEIJOHO.KEIYAKU_HASU AS ""契約羽数"""
                    wSql &= "        ,KEIJOHO.KEIYAKU_HENKO_KBN AS ""契約変更区分コード"""
                    wSql &= "        ,CD10.MEISYO AS ""契約変更区分名"""
                    wSql &= "        ,KEIJOHO.ZOGEN_HASU AS ""増減羽数"""
                    wSql &= "        ,KEIJOHO.MOTO_SEQNO AS ""譲渡元SEQNO"""
                    wSql &= "        ,KEIJOHO.SEIKYU_KAISU AS ""請求（返還）回数"""
                    wSql &= "        ,REPLACE(KEIJOHO.BIKO, CHR(10), '') AS ""契約情報備考"""
                    wSql &= "        ,CASE WHEN KEIJOHO.DATA_FLG = 0 THEN '無効' ELSE '有効' END ""データフラグ"""
                    wSql &= "    FROM TT_KEIYAKU_JOHO KEIJOHO"
                    wSql &= "        ,TM_KEIYAKU KEI"
                    wSql &= "        ,TM_KEIYAKU_NOJO NOJO"
                    wSql &= "        ,TM_CODE CD01"
                    wSql &= "        ,TM_CODE CD02"
                    wSql &= "        ,TM_CODE CD04"
                    wSql &= "        ,TM_CODE CD05"
                    wSql &= "        ,TM_CODE CD05N"
                    wSql &= "        ,TM_CODE CD07"
                    wSql &= "        ,TM_CODE CD10"
                    wSql &= "        ,TM_CODE CD12"
                    wSql &= "        ,TM_JIMUITAKU ITK"
                    wSql &= "        ,TM_BANK BANK"
                    wSql &= "        ,TM_SITEN SITEN"
                    wSql &= "    WHERE"

                    '2015/12/21　修正開始
                    'メインテーブルを契約情報から契約マスタに変更
                    '                 -- 契約者マスタ
                    'wSql &= "         KEIJOHO.KI = KEI.KI(+)"
                    'wSql &= "     AND KEIJOHO.KEIYAKUSYA_CD = KEI.KEIYAKUSYA_CD(+)"
                    '                 -- 契約者マスタ
                    wSql &= "         KEI.KI = " & numKI.Text.Trim
                    wSql &= "     AND KEI.KI = KEIJOHO.KI(+)"
                    wSql &= "     AND KEI.KEIYAKUSYA_CD = KEIJOHO.KEIYAKUSYA_CD(+)"
                    '2015/12/21　修正終了
                    '                 -- 契約者農場マスタ
                    wSql &= "     AND KEIJOHO.KI = NOJO.KI(+)"
                    wSql &= "     AND KEIJOHO.KEIYAKUSYA_CD = NOJO.KEIYAKUSYA_CD(+)"
                    wSql &= "     AND KEIJOHO.NOJO_CD = NOJO.NOJO_CD(+)"
                    '                 -- 契約区分
                    wSql &= "     AND KEI.KEIYAKU_KBN = CD01.MEISYO_CD(+)"
                    wSql &= "     AND 1 = CD01.SYURUI_KBN(+)"
                    '                 -- 契約状況
                    wSql &= "     AND KEI.KEIYAKU_JYOKYO = CD02.MEISYO_CD(+)"
                    wSql &= "     AND 2 = CD02.SYURUI_KBN(+)"
                    '                 -- 都道府県
                    wSql &= "     AND KEI.KEN_CD = CD05.MEISYO_CD(+)"
                    wSql &= "     AND 5 = CD05.SYURUI_KBN(+)"
                    '                 -- 事務委託先
                    wSql &= "     AND KEI.KI = ITK.KI(+)"
                    wSql &= "     AND KEI.JIMUITAKU_CD = ITK.ITAKU_CD(+)"
                    '                 -- 金融機関マスタ
                    wSql &= "     AND KEI.FURI_BANK_CD = BANK.BANK_CD(+)"
                    '                 -- 金融機関支店マスタ
                    wSql &= "     AND KEI.FURI_BANK_CD = SITEN.BANK_CD(+)"
                    wSql &= "     AND KEI.FURI_BANK_SITEN_CD = SITEN.SITEN_CD(+)"
                    '                 -- 口座種別
                    wSql &= "     AND KEI.FURI_KOZA_SYUBETU = CD04.MEISYO_CD(+)"
                    wSql &= "     AND 4 = CD04.SYURUI_KBN(+)"
                    '                 -- 入力状況
                    wSql &= "     AND KEI.NYURYOKU_JYOKYO = CD12.MEISYO_CD(+)"
                    wSql &= "     AND 12 = CD12.SYURUI_KBN(+)"
                    '                 -- 都道府県(農場)
                    wSql &= "     AND NOJO.KEN_CD = CD05N.MEISYO_CD(+)"
                    wSql &= "     AND 5 = CD05N.SYURUI_KBN(+)"
                    '                 -- 鶏の種類
                    wSql &= "     AND KEIJOHO.TORI_KBN = CD07.MEISYO_CD(+)"
                    wSql &= "     AND 7 = CD07.SYURUI_KBN(+)"
                    '                 -- 契約変更区分
                    wSql &= "     AND KEIJOHO.KEIYAKU_HENKO_KBN = CD10.MEISYO_CD(+)"
                    wSql &= "     AND 10 = CD10.SYURUI_KBN(+)"

                    '                 -- 条件
                    'wSql &= "     AND KEIJOHO.KI = " & numKI.Text.Trim     '2015/12/07　削除

                    '未契約者除くとき
                    If chk_MikeiyakuNozoku.Checked Then     '2015/12/07　修正
                        '契約情報の契約日
                        wSql &= "     AND (   KEIJOHO.KEIYAKU_DATE_FROM <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                        wSql &= "         AND KEIJOHO.KEIYAKU_DATE_TO   >= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                        wSql &= "         )"
                    End If                                  '2015/12/07　修正

                    '未契約者除くとき
                    If chk_MikeiyakuNozoku.Checked Then       '2015/12/07　修正
                        '                 -- 未契約者および未来契約者を除く
                        wSql &= "     AND KEI.KEIYAKU_DATE IS NOT NULL"
                        wSql &= "     AND KEI.KEIYAKU_DATE <= LAST_DAY(TO_DATE('" & Format(dateTAISYO_Ym.Value, "yyyy/MM/dd") & "','yyyy/mm/dd'))"
                    End If                              '2015/12/07　修正

                    '2021/07/06 JBD9020 新契約日追加 ADD START
                    '未入金除くとき
                    If chk_MinyukinNozoku.Checked Then
                        wSql &= "     AND KEI.NYU_HEN_DATE IS NOT NULL"
                    End If
                    '2021/07/06 JBD9020 新契約日追加 ADD END

                    wSql &= wWhere & " "

                    wSql &= "    ORDER BY"
                    '2015/12/21　修正開始
                    'wSql &= "         KEIJOHO.KI"
                    'wSql &= "        ,KEIJOHO.KEIYAKUSYA_CD"
                    'wSql &= "        ,KEIJOHO.NOJO_CD"
                    'wSql &= "        ,KEIJOHO.TORI_KBN"
                    wSql &= "         KEI.KI"
                    wSql &= "        ,KEI.KEIYAKUSYA_CD"
                    wSql &= "        ,KEIJOHO.NOJO_CD"
                    wSql &= "        ,KEIJOHO.TORI_KBN"
                    '2015/12/21　修正終了

                    '契約基本情報のみ
                    If rbtnOutKIHON.Checked Then
                        wSql &= "    )"
                        wSql &= " GROUP BY"
                        wSql &= "    ""期"""
                        wSql &= "   ,""契約者番号"""
                        wSql &= " ORDER BY"
                        wSql &= "    ""期"""
                        wSql &= "   ,""契約者番号"""
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
