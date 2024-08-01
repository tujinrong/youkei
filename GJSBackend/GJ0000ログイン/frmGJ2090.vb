'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ2090.vb
'*
'*　　②　機能概要　　　　　契約者積立金等入金・返還入力一覧
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

Public Class frmGJ2090

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

        ''' <summary>
        ''' 入金日・振込日
        ''' </summary>
        ''' <remarks></remarks>
        Public NYURYOKU_YMD As String = String.Empty

        ''' <summary>
        ''' 請求（返還）回数
        ''' </summary>
        ''' <remarks></remarks>
        Public SEIKYU_KAISU As String = String.Empty

        ''' <summary>
        ''' 積立金区分
        ''' </summary>
        ''' <remarks></remarks>
        Public TUMITATE_KBN As String = String.Empty

        ''' <summary>
        ''' 積立金入金区分
        ''' </summary>
        ''' <remarks></remarks>
        Public NYUKIN_KBN As String = String.Empty


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
    Public paryKEY_2090 As New List(Of T_KEY)

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

            Dim SyoriKI = New Obj_TM_SYORI_NENDO_KI()
            pInitKi = SyoriKI.pKI

            '2016/05/20　追加開始
            If SyoriKI.pNOFU_KIGEN = New Date Then
                Show_MessageBox_Add("I007", "当初対象積立金納付期限が設定されていません。")
                Me.Close()
            End If
            '2016/05/20　追加終了

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
                lblCOUNT.Text = pDataSet.Tables(0).Rows.Count.ToString("#,##0")
                'cmdKakunin.Enabled = True
            Else
                'cmdKakunin.Enabled = False
                lblCOUNT.Text = "0"
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



#Region "cmdKakunin_Click 入金確認ボタンクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdKakunin_Click
    '説明            :入金確認ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdKakunin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKakunin.Click
        Dim strtNowKEY As T_KEY = Nothing
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '画面入力チェック(エラー表示あり)
            If Not f_Input_Check() Then
                Exit Try
            End If

            '一覧より選択されていなければエラー
            If dgv_Search.SelectedRows.Count = 0 Then
                Show_MessageBox("W011", "")     'データが選択されていません。
                'Show_MessageBox("データが選択されていません。", C_MSGICON_INFORMATION)       'データが選択されていません。
                Exit Try
            End If

            'グリッドのKey情報を構造体に格納
            For i As Integer = 0 To dgv_Search.RowCount - 1
                '選択行
                If dgv_Search.Rows(i).Selected Then
                    strtNowKEY = New T_KEY
                    strtNowKEY.KEIYAKUSYA_CD = dgv_Search.Item("KEIYAKUSYA_CD", i).Value
                    strtNowKEY.SEIKYU_KAISU = dgv_Search.Item("SEIKYU_KAISU", i).Value
                    strtNowKEY.NYUKIN_KBN = dgv_Search.Item("NYUKIN_KBN", i).Value
                    strtNowKEY.TUMITATE_KBN = dgv_Search.Item("TUMITATE_KBN", i).Value
                    strtNowKEY.NYURYOKU_YMD = dateNYURYOKU_Ymd.Value.ToString

                End If
            Next

            '表示対象画面の判定
            If strtNowKEY.NYUKIN_KBN = 2 Then
                '分割入金画面
                Using wkForm As New frmGJ2092
                    wkForm.Owner = Me
                    wkForm.pSyoriKbn = frmGJ2092.Enu_SyoriKubun.Update
                    wkForm.pCurrentKey = strtNowKEY     '現在選択されている行のキーを渡します
                    wkForm.p2090_KI = numKI.Text.Trim  '期を渡します

                    wkForm.ShowDialog()

                    '再抽出
                    'If dgv_Search.RowCount <> 0 Then cmdSearch_Click(cmdSearch, New EventArgs, False)

                    'グリッド　再表示
                    ret = f_GridReDisp(wkForm.pCurrentKey.KEIYAKUSYA_CD, wkForm.pCurrentKey.SEIKYU_KAISU)
                End Using

            Else
                '一括入金画面
                Using wkForm As New frmGJ2091
                    wkForm.Owner = Me
                    wkForm.pSyoriKbn = frmGJ2091.Enu_SyoriKubun.Update
                    wkForm.pCurrentKey = strtNowKEY     '現在選択されている行のキーを渡します
                    wkForm.p2090_KI = numKI.Text.Trim  '期を渡します

                    wkForm.ShowDialog()

                    '再抽出
                    'If dgv_Search.RowCount <> 0 Then cmdSearch_Click(cmdSearch, New EventArgs, False)

                    'グリッド　再表示
                    ret = f_GridReDisp(wkForm.pCurrentKey.KEIYAKUSYA_CD, wkForm.pCurrentKey.SEIKYU_KAISU)
                End Using
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
        Else
            pEnterKi = numKI.Value
        End If

    End Sub

    '2015/03/04 JBD368 UPD ↓↓↓
    ''------------------------------------------------------------------
    ''プロシージャ名  :numKI_Validated
    ''説明            :期Validatedベント
    ''------------------------------------------------------------------
    'Private Sub numKI_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles numKI.Validated
    '------------------------------------------------------------------
    'プロシージャ名  :numKI_Validating
    '説明            :期Validatingイベント
    '------------------------------------------------------------------
    Private Sub numKI_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numKI.Validating
        '2015/03/04 JBD368 UPD ↑↑↑

        Dim ret As Boolean = False

        Try

            '未入力のとき、事務委託先コンボクリア
            If numKI.Text = "" Then
                '2015/03/03 JBD368 UPD ↓↓↓ DataSourceへ変更に伴い、初期化方法変更
                'cobJIMUITAKU_CD.Items.Clear()
                'cobJIMUITAKU_NM.Items.Clear()
                cobJIMUITAKU_CD.DataSource = Nothing
                cobJIMUITAKU_CD.Clear()
                cobJIMUITAKU_NM.DataSource = Nothing
                cobJIMUITAKU_NM.Clear()
                '2015/03/03 JBD368 UPD ↑↑↑
                pEnterKi = ""       '2015/03/04 JBD368 ADD
                Exit Try
            End If

            '期に変更無し
            '2015/03/04 JBD368 UPD ↓↓↓
            'If CInt(numKI.Text) = CInt(pEnterKi) Then
            If CInt(numKI.Text) = WordHenkan("S", "Z", pEnterKi) Then
                '2015/03/04 JBD368 UPD ↑↑↑
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
    Private Sub cob_KEN_CD_F_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobKEN_CD_From.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cobKEN_NM_From.SelectedIndex = cobKEN_CD_From.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KenNm_F_SelectedIndexChanged
    '説明            :都道府県名(FROM)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KenNm_F_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobKEN_NM_From.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        s_CboMeiFrom_SelectedIndexChanged(cobKEN_NM_From, cobKEN_CD_From, cobKEN_NM_To, cobKEN_CD_To)


    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_F_Validating
    '説明            :都道府県コード(FROM)確定中処理
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_F_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cobKEN_CD_From.Validating

        Call s_CboFrom_Validating(cobKEN_CD_From, cobKEN_NM_From, cobKEN_CD_To, cobKEN_NM_To)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_T_SelectedIndexChanged
    '説明            :都道府県コード(TO)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_T_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobKEN_CD_To.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cobKEN_NM_To.SelectedIndex = cobKEN_CD_To.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KenNm_F_SelectedIndexChanged
    '説明            :都道府県名(TO)項目変更時
    '------------------------------------------------------------------
    Private Sub cob_KenNm_T_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobKEN_NM_To.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        s_CboMeiTo_Validating(cobKEN_NM_To, cobKEN_CD_To, cobKEN_NM_From, cobKEN_CD_From)

    End Sub


    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEN_CD_T_Validating
    '説明            :都道府県コード(TO)確定中処理
    '------------------------------------------------------------------
    Private Sub cob_KEN_CD_T_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cobKEN_CD_To.Validating

        Call s_CboTo_Validating(cobKEN_CD_To, cobKEN_NM_To, cobKEN_CD_From, cobKEN_NM_From)

    End Sub

#End Region

#Region "事務委託先関連"

    '------------------------------------------------------------------
    'プロシージャ名  :cobJIMUITAKU_CD_SelectedIndexChanged
    '説明            :事務委託先コード項目変更時
    '------------------------------------------------------------------
    Private Sub cobJIMUITAKU_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobJIMUITAKU_CD.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cobJIMUITAKU_NM.SelectedIndex = cobJIMUITAKU_CD.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cobJIMUITAKU_NM_SelectedIndexChanged
    '説明            :事務委託先名項目変更時
    '------------------------------------------------------------------
    Private Sub cobJIMUITAKU_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cobJIMUITAKU_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cobJIMUITAKU_CD.SelectedIndex = cobJIMUITAKU_NM.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cobJIMUITAKU_CD_Validating
    '説明            :事務委託先確定時処理
    '------------------------------------------------------------------
    Private Sub cobJIMUITAKU_CD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cobJIMUITAKU_CD.Validating
        If cobJIMUITAKU_CD.Text = "" Then
            Exit Sub
        End If


        '先頭ゼロを削除
        DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text = CInt(DirectCast(sender, JBD.Gjs.Win.GcComboBox).Text).ToString

        '2015/03/03 JBD368 UPD ↓↓↓ 値の設定方法を変更
        'cobJIMUITAKU_CD.SelectedValue = cobJIMUITAKU_CD.Text
        cobJIMUITAKU_CD.SelectedValue = CDec(cobJIMUITAKU_CD.Text)
        '2015/03/03 JBD368 UPD ↑↑↑
        If cobJIMUITAKU_CD.SelectedValue Is Nothing Then
            cobJIMUITAKU_CD.SelectedIndex = -1
            cobJIMUITAKU_CD.SelectedIndex = -1
            Show_MessageBox_Add("W012", "事務委託先") '指定された@0が正しくありません。
            cobJIMUITAKU_CD.Focus()
        End If

    End Sub


#End Region

#Region "請求回数関連"
    '------------------------------------------------------------------
    'プロシージャ名  :numSEIKYU_KAISU_From_Validating
    '説明            :請求回数FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numSEIKYU_KAISU_From_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numSEIKYU_KAISU_From.Validating

        Call s_From_Validating(numSEIKYU_KAISU_From, numSEIKYU_KAISU_To)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :numSEIKYU_KAISU_To_Validating
    '説明            :請求回数TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numSEIKYU_KAISU_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numSEIKYU_KAISU_To.Validating

        Call s_To_Validating(numSEIKYU_KAISU_To, numSEIKYU_KAISU_From)

    End Sub
#End Region

#Region "請求・返還金額（入金金額）関連"
    '------------------------------------------------------------------
    'プロシージャ名  :numSEIKYU_KIN_From_Validating
    '説明            :請求・返還金額FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numSEIKYU_KIN_From_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numSEIKYU_KIN_From.Validating

        Call s_From_Validating(numSEIKYU_KIN_From, numSEIKYU_KIN_To)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :numSEIKYU_KIN_To_Validating
    '説明            :請求・返還金額TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub numSEIKYU_KIN_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numSEIKYU_KIN_To.Validating

        'Call s_To_Validating(numSEIKYU_KIN_To, numSEIKYU_KIN_From)

    End Sub
#End Region

#Region "入金・返還日関連"
    '------------------------------------------------------------------
    'プロシージャ名  :dateNYUKIN_Ymd_From_Validating
    '説明            :入金・返還日FROM Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateNYUKIN_Ymd_From_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateNYUKIN_Ymd_From.Validating

        Call s_From_Validating(dateNYUKIN_Ymd_From, dateNYUKIN_Ymd_To)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :dateNYUKIN_Ymd_To_Validating
    '説明            :入金・返還日TO Validatingイベント
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub dateNYUKIN_Ymd_To_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dateNYUKIN_Ymd_To.Validating

        'Call s_To_Validating(dateNYUKIN_Ymd_To, dateNYUKIN_Ymd_From)

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
            rbtnNYUKIN.Checked = True    '入金
            rbtnMI.Checked = True        '未入金・未返還分
            rbtnSearchAnd.Checked = True


            lblCOUNT.Text = "0"     '抽出
            'pJump = False      '2015/03/03 JBD368 DEL コンボボックス設定までTRUEにしておく

            'コンボボックスセット
            ret = f_ComboBox_Set(wKbn, numKI.Text)

            pJump = False       '2015/03/03 JBD368 ADD

            '変数クリア
            paryKEY_2090 = New List(Of T_KEY)

            If Not pDataSet Is Nothing Then
                pDataSet.Clear()
            End If

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

            pJump = True    '2015/03/04 JBD368 ADD

            '初期処理
            If wKbn = "C" Then

                '県マスタコンボセット
                If Not f_Ken_Data_Select(cobKEN_CD_From, cobKEN_NM_From, True) Then
                    Exit Try
                End If
                If Not f_Ken_Data_Select(cobKEN_CD_To, cobKEN_NM_To, True) Then
                    Exit Try
                End If


                'コンボボックス初期化
                cobKEN_CD_From.Text = ""
                cobKEN_CD_To.Text = ""

            End If

            '期が未入力のとき
            If wKI = "" OrElse wKI = String.Empty Then
                '2015/03/03 JBD368 UPD ↓↓↓ DataSourceへ変更に伴い、初期化方法変更
                'cobJIMUITAKU_CD.Items.Clear()
                'cobJIMUITAKU_NM.Items.Clear()
                cobJIMUITAKU_CD.DataSource = Nothing
                cobJIMUITAKU_CD.Clear()
                cobJIMUITAKU_NM.DataSource = Nothing
                cobJIMUITAKU_NM.Clear()
                '2015/03/03 JBD368 UPD ↑↑↑
                Exit Try
            End If

            '契約者マスタコンボセット
            wWhere = "KI = " & wKI
            If Not f_JimuItaku_Data_Select(cobJIMUITAKU_CD, cobJIMUITAKU_NM, wWhere, True) Then
                Exit Try
            End If

            'コンボボックス初期化
            cobJIMUITAKU_CD.Text = ""

            pJump = False    '2015/03/04 JBD368 ADD

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

            '==FromToチェック==================
            '請求・返還回数
            If f_Daisyo_Check(numSEIKYU_KAISU_From, numSEIKYU_KAISU_To, "請求・返還回数", True, 1) = False Then
                Exit Try
            End If

            '都道府県
            If f_Daisyo_Check(cobKEN_CD_From, cobKEN_CD_To, "都道府県", True, 1) = False Then
                Exit Try
            End If

            '請求・返還金額（入金金額）
            If f_Daisyo_Check(numSEIKYU_KIN_From, numSEIKYU_KIN_To, "請求・返還金額（入金金額）", True, 1) = False Then
                Exit Try
            End If

            '入金・返還日
            If f_Daisyo_Check(dateNYUKIN_Ymd_From, dateNYUKIN_Ymd_To, "入金・返還日", True, 2) = False Then
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
            If cobKEN_CD_From.Text.Trim <> "" AndAlso cobKEN_CD_To.Text.Trim <> "" Then
                wWhere = "(" & " KEI.KEN_CD BETWEEN " & cobKEN_CD_From.Text.Trim & " and " & cobKEN_CD_To.Text.Trim & ")"
            End If

            '請求・返還回数From
            If numSEIKYU_KAISU_From.Text.Trim <> "" AndAlso numSEIKYU_KAISU_To.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere = "(" & " TUM.SEIKYU_KAISU BETWEEN " & numSEIKYU_KAISU_From.Text.Trim & " and " & numSEIKYU_KAISU_To.Text.Trim & ")"
            End If

            '事務委託先
            If cobJIMUITAKU_CD.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= " KEI.JIMUITAKU_CD = " & cobJIMUITAKU_CD.Text.Trim
            End If

            '契約者番号
            If txtKEIYAKUSYA_CD.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= " KEI.KEIYAKUSYA_CD = " & txtKEIYAKUSYA_CD.Text.Trim
            End If

            '契約者名
            If txtKEIYAKUSYA_NAME.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= " KEI.KEIYAKUSYA_NAME LIKE '%" & f_SqlEdit(txtKEIYAKUSYA_NAME.Text) & "%'"
            End If

            '契約者名(フリガナ)
            If txtKEIYAKUSYA_KANA.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= " KEI.KEIYAKUSYA_KANA LIKE '%" & f_SqlEdit(txtKEIYAKUSYA_KANA.Text) & "%'"
            End If

            '請求・返還金額（入金金額）From
            If numSEIKYU_KIN_From.Text.Trim <> "" AndAlso numSEIKYU_KIN_To.Text.Trim <> "" Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " TUM.NYUKIN_GAKU BETWEEN " & numSEIKYU_KIN_From.Text.Trim & " and " & numSEIKYU_KIN_To.Text.Trim & ")"
            End If

            '納付方法(入金)
            If rbtnNYUKIN.Checked Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                ' １：請求(全額),２：一部請求
                wWhere &= "( TUM.SEIKYU_HENKAN_KBN IN (1,2) )"
            End If

            '納付方法(返還)
            If rbtnHENKAN.Checked Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                ' ３：一部返還,４：全額返還
                wWhere &= "( TUM.SEIKYU_HENKAN_KBN IN (3,4) )"
            End If

            '処理状況(未入金・未返還分)
            If rbtnMI.Checked Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                ' １：請求(返還)中,２：督促中,４：一部入金,５：督促中(一部入金)
                wWhere &= "( TUM.SYORI_JOKYO_KBN IN (1,2,4,5) )"
            End If

            '処理状況(入金・返還済分)
            If rbtnSUMI.Checked Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                ' ３：入金（返還）済
                wWhere &= "( TUM.SYORI_JOKYO_KBN IN (3) )"
            End If

            '入金・返還日From
            If Not (dateNYUKIN_Ymd_From.Value Is Nothing) And Not (dateNYUKIN_Ymd_To.Value Is Nothing) Then
                If wWhere <> "" Then
                    wWhere = wWhere & wANDorOR
                End If
                wWhere &= "(" & " TUM.NYUKIN_DATE BETWEEN TO_DATE('" & Format(dateNYUKIN_Ymd_From.Value, "yyyy/MM/dd").TrimEnd & "') and TO_DATE('" & Format(dateNYUKIN_Ymd_To.Value, "yyyy/MM/dd").TrimEnd & "'))"
            End If

            '条件編集
            If wWhere <> "" Then
                wWhere = "  AND (" & wWhere & ")"
            End If

            '==SQL作成====================
            wSql &= "SELECT"
            wSql &= "     KEI.KEIYAKUSYA_CD AS KEIYAKUSYA_CD"
            wSql &= "    ,KEI.KEIYAKUSYA_NAME AS KEIYAKUSYA_NAME"
            wSql &= "    ,KEI.KEIYAKUSYA_KANA AS KEIYAKUSYA_KANA"
            wSql &= "    ,TUM.SYORI_JOKYO_KBN AS SYORI_JOKYO_KBN"
            wSql &= "	 ,CD15.MEISYO AS SYORI_JOKYO_KBN_NM"
            wSql &= "	 ,TUM.SEIKYU_HENKAN_KBN AS SEIKYU_HENKAN_KBN"
            wSql &= "	 ,CD08.MEISYO AS SEIKYU_HENKAN_KBN_NM"
            wSql &= "	 ,TO_CHAR(TUM.SEIKYU_DATE, 'EEYY/mm/dd','nls_calendar = ''Japanese Imperial''') AS SEIKYU_DATE"
            wSql &= "	 ,TO_CHAR(TUM.NYUKIN_DATE, 'EEYY/mm/dd','nls_calendar = ''Japanese Imperial''') AS NYUKIN_DATE"
            wSql &= "    ,CASE"
            wSql &= "	     WHEN TUM.SEIKYU_HENKAN_KBN = 1 OR TUM.SEIKYU_HENKAN_KBN = 2 THEN TO_CHAR(TUM.SEIKYU_KIN, '999,999,999') "
            wSql &= "     END SEIKYU_KINGAKU"
            wSql &= "    ,CASE"
            wSql &= "	     WHEN TUM.SEIKYU_HENKAN_KBN = 3 OR TUM.SEIKYU_HENKAN_KBN = 4 THEN TO_CHAR(TUM.SEIKYU_KIN, '999,999,999')"
            wSql &= "     END HEMKAN_KINGAKU"
            wSql &= "    ,TUM.SEIKYU_KAISU AS SEIKYU_KAISU"
            wSql &= "    ,TUM.TUMITATE_KBN AS TUMITATE_KBN"
            wSql &= "    ,NVL(TUM.NYUKIN_KBN,0) AS NYUKIN_KBN"
            wSql &= " FROM"
            wSql &= "     TM_KEIYAKU KEI"
            wSql &= "    ,TT_TUMITATE TUM"
            wSql &= "    ,TM_CODE CD15"
            wSql &= "    ,TM_CODE CD08"
            wSql &= " WHERE"
            '             -- 積立金DB
            wSql &= "      KEI.KI = TUM.KI(+)"
            wSql &= "  AND KEI.KEIYAKUSYA_CD = TUM.KEIYAKUSYA_CD(+)"
            wSql &= "  AND 1 = TUM.TUMITATE_KBN(+)"
            '             -- 処理状況
            wSql &= "  AND TUM.SYORI_JOKYO_KBN = CD15.MEISYO_CD(+)"
            wSql &= "  AND 15 = CD15.SYURUI_KBN(+)"
            '             -- 積立金請求・返還区分
            wSql &= "  AND TUM.SEIKYU_HENKAN_KBN = CD08.MEISYO_CD(+)"
            wSql &= "  AND 8 = CD08.SYURUI_KBN(+)"
            '             -- 条件
            wSql &= "  AND KEI.KI = " & numKI.Text.Trim
            wSql &= "  AND TUM.DATA_FLG = 1"
            '             -- 請求書発行済が対象
            wSql &= "  AND TUM.SEIKYU_HAKKO_DATE IS NOT NULL"
            wSql &= wWhere & " "
            wSql &= " ORDER BY"
            wSql &= "  KEI.KEIYAKUSYA_CD"
            wSql &= " ,TUM.SEIKYU_KAISU"

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
