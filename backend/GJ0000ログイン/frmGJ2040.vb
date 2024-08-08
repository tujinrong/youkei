'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ2040.vb
'*
'*　　②　機能概要　　　　　互助金生産者積立金等請求兼返還通知書（徴収）発行処理
'*
'*　　③　作成日　　　　　　2015/02/27  BY JBD
'*
'*　　④　更新日            2023/08/18　BY JBD454
'*
'*******************************************************************************
Option Strict Off
Option Explicit On
Imports GrapeCity.ActiveReports

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
Imports JbdGjsReport

Public Class frmGJ2040

#Region "*** 変数定義 ***"

    Public pRptName As String = "生産者積立金等請求・返還通知書（一部徴収）"     '帳票名

    Private pInitKI As Integer              '期(初期値)
    Private pEnterKI As String              '期(変更前)
    Private pKI As String                   '期
    Private pSEIKYU_KAISU As String         '請求回数
    Private pJump As Boolean = True         '処理ジャンプ
    Private pSyoriKbn As Integer

#End Region

#Region "*** 画面制御関連 ***"

#Region "frmGJ2040_Load Form_Loadイベント"

    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ2040_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ2040_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean

        Try

            pInitKI = New Obj_TM_SYORI_NENDO_KI().pKI
            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear("C")

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

    End Sub

#End Region

#End Region

#Region "*** 画面ボタンクリック関連 ***"

#Region "cmdPreview_Click プレビューボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdPreview_Click
    '説明            :保存ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim wSEIKYUSU As Integer           '2011/08/18　追加

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '入力項目チェック
            If Not f_Input_Check(wSEIKYUSU) Then
                Exit Try
            End If

            '再発行・修正発行で請求対象者なしは、処理なし
            If (rbtn_SYORI_KBN2.Checked Or rbtn_SYORI_KBN3.Checked) AndAlso
                wSEIKYUSU = 0 Then
                Exit Try
            End If

            '請求対象者ありのとき、帳票出力処理
            If wSEIKYUSU <> 0 Then
                If Not f_Report_Output() Then
                    Exit Try
                End If
            End If

            '請求入金更新
            If rbtn_SYORI_KBN0.Checked = False Then '2020/08/17 JBD9020 ADD
                If Not f_Save() Then
                    Exit Try
                End If
            End If '2020/08/17 JBD9020 ADD

            '正常終了
            If wSEIKYUSU = 0 Then
                Show_MessageBox("I001", "") '正常に終了しました。
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
#Region "cmdCan_Click キャンセルボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdCan_Click
    '説明            :キャンセルボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdCan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCan.Click

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '画面初期表示
            If f_ObjectClear("") Then
                Exit Try
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
#Region "cmdEnd_Click 終了ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdEnd_Click
    '説明            :終了ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try

            If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                'If Show_MessageBox("処理を終了しますか？", C_MSGICON_QUESTION) = Windows.Forms.DialogResult.Yes Then
                '処理を終了しますか？
                Exit Try
            End If

            'フォームクローズ
            Me.AutoValidate = AutoValidate.Disable      '2010/10/16 ADD JBD200
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

#Region "*** 画面コントロール制御関連 ***"

#Region "処理区分　Chanegeイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :rbtn_SYORI_KBN_CheckedChanged
    '説明            :処理区分　Chanegeイベント
    '------------------------------------------------------------------
    Private Sub rbtn_SYORI_KBN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
                rbtn_SYORI_KBN1.CheckedChanged, rbtn_SYORI_KBN2.CheckedChanged, rbtn_SYORI_KBN3.CheckedChanged, rbtn_SYORI_KBN0.CheckedChanged '2020/08/17 JBD9020 仮発行追加

        If pJump Then
            Exit Sub
        End If

        If (sender.Equals(rbtn_SYORI_KBN1) AndAlso rbtn_SYORI_KBN1.Checked) OrElse
           (sender.Equals(rbtn_SYORI_KBN2) AndAlso rbtn_SYORI_KBN2.Checked) OrElse
           (sender.Equals(rbtn_SYORI_KBN3) AndAlso rbtn_SYORI_KBN3.Checked) OrElse
           (sender.Equals(rbtn_SYORI_KBN0) AndAlso rbtn_SYORI_KBN0.Checked) Then '2020/08/17 JBD9020 仮発行追加
            '画面再表示
            If txt_KI.Text.Trim = "" Then
                '期：未入力
                f_Rireki_Set(0)
            ElseIf txt_SEIKYU_KAISU.Text.Trim = "" Then
                '期：入力　回数：未入力
                f_Rireki_Set(1)
            Else
                '期：入力　回数：入力
                f_Rireki_Set(2)
            End If

        End If

    End Sub
#End Region

#Region "期・回数　Validatingイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_KI_Enter
    '説明            :期Enterイベント
    '------------------------------------------------------------------
    Private Sub txt_KI_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txt_KI.Enter

        pEnterKI = txt_KI.Text

    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :txt_KI_Validating
    '説明            :期・回数　Validatedイベント
    '------------------------------------------------------------------
    Private Sub txt_KI_Validating(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
                txt_KI.Validating, txt_SEIKYU_KAISU.Validating
        Dim ret As Boolean = False
        Dim wKBN As Integer

        Try

            '契約者コンボクリア
            If txt_KI.Text.Trim <> pEnterKI Then
                ret = f_ComboBox_Set(txt_KI.Text)
            End If

            '計算履歴の内容表示
            Select Case sender.NAME
                Case "txt_KI"
                    wKBN = 1
                Case Else
                    wKBN = 2
            End Select

            '期・回数　変更時、再表示
            If pKI <> txt_KI.Text.Trim OrElse
               pSEIKYU_KAISU <> txt_SEIKYU_KAISU.Text Then
                '画面表示
                f_Rireki_Set(wKBN)
            Else
                '入金期限が空白のとき、入金期限のみ再表示
                If date_KIGEN_DATE.Value Is Nothing OrElse date_KIGEN_DATE.Value = New Date Then
                    f_Rireki_Set(2)
                Else
                    If date_SEIKYU_HAKKO_DATE.Value Is Nothing Then
                        date_SEIKYU_HAKKO_DATE.Value = CDate(Format(Now, "yyyy/MM/dd"))
                    End If
                End If
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#Region "事務委託先(FROM)"
    '------------------------------------------------------------------
    'プロシージャ名  :cbo_SEISANSYA_CD_SelectedIndexChanged
    '説明            :事務委託先コード(FROM)Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_JIMUITAKU_CD_F_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_JIMUITAKU_CD_F.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_JIMUITAKU_NM_F.SelectedIndex = cbo_JIMUITAKU_CD_F.SelectedIndex


    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_SEISANSYA_NM_SelectedIndexChanged
    '説明            :事務委託先名(FROM)Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_JIMUITAKU_NM_F_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_JIMUITAKU_NM_F.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        Call s_CboMeiFrom_SelectedIndexChanged(cbo_JIMUITAKU_NM_F, cbo_JIMUITAKU_CD_F, cbo_JIMUITAKU_NM_T, cbo_JIMUITAKU_CD_T)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_JIMUITAKU_CD_F_Validating
    '説明            :事務委託先コード(FROM)_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cbo_JIMUITAKU_CD_F_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbo_JIMUITAKU_CD_F.Validating

        '2015/03/04　修正開始--▽▽▽   コンボボックスの動作変更
        'Call s_CboFrom_Validating(cbo_JIMUITAKU_CD_F, cbo_JIMUITAKU_NM_F, cbo_JIMUITAKU_CD_T, cbo_JIMUITAKU_CD_T)
        Call s_CboFrom_Validating(cbo_JIMUITAKU_CD_F, cbo_JIMUITAKU_NM_F, cbo_JIMUITAKU_CD_T, cbo_JIMUITAKU_CD_T, 2)
        '2015/03/04　修正終了--△△△


    End Sub
#End Region
#Region "事務委託先(TO)"
    '------------------------------------------------------------------
    'プロシージャ名  :cbo_SEISANSYA_CD_SelectedIndexChanged
    '説明            :事務委託先コード(TO)Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_JIMUITAKU_CD_T_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_JIMUITAKU_CD_T.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_JIMUITAKU_NM_T.SelectedIndex = cbo_JIMUITAKU_CD_T.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_SEISANSYA_NM_SelectedIndexChanged
    '説明            :事務委託先名(TO)Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_JIMUITAKU_NM_T_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_JIMUITAKU_NM_T.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        '↓***** 2010/11/08 ADD JBD200 FROM-TO制御共通化 *****↓
        'cbo_JIMUITAKU_CD_T.SelectedIndex = cbo_JIMUITAKU_NM_T.SelectedIndex
        Call s_CboMeiTo_Validating(cbo_JIMUITAKU_NM_T, cbo_JIMUITAKU_CD_T, cbo_JIMUITAKU_NM_F, cbo_JIMUITAKU_CD_F)
        '↑***** 2010/11/08 ADD JBD200 FROM-TO制御共通化 *****↑

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_JIMUITAKU_CD_T_Validating
    '説明            :事務委託先コード(TO)_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cbo_JIMUITAKU_CD_T_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbo_JIMUITAKU_CD_T.Validating

        '2015/03/04　修正開始--▽▽▽   コンボボックスの動作変更
        'Call s_CboTo_Validating(cbo_JIMUITAKU_CD_T, cbo_JIMUITAKU_NM_T, cbo_JIMUITAKU_CD_F, cbo_JIMUITAKU_NM_F)
        Call s_CboTo_Validating(cbo_JIMUITAKU_CD_T, cbo_JIMUITAKU_NM_T, cbo_JIMUITAKU_CD_F, cbo_JIMUITAKU_NM_F, 2)
        '2015/03/04　修正終了--△△△


    End Sub
#End Region

#Region "生産者(FROM)"
    '------------------------------------------------------------------
    'プロシージャ名  :cbo_SEISANSYA_CD_SelectedIndexChanged
    '説明            :生産者コード(FROM)Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_SEISANSYA_CD_F_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_KEIYAKUSYA_CD_F.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_KEIYAKUSYA_NM_F.SelectedIndex = cbo_KEIYAKUSYA_CD_F.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_SEISANSYA_NM_SelectedIndexChanged
    '説明            :生産者名(FROM)Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_SEISANSYA_NM_F_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_KEIYAKUSYA_NM_F.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        Call s_CboMeiFrom_SelectedIndexChanged(cbo_KEIYAKUSYA_NM_F, cbo_KEIYAKUSYA_CD_F, cbo_KEIYAKUSYA_NM_T, cbo_KEIYAKUSYA_CD_T)

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_SEISANSYA_CD_F_Validating
    '説明            :生産者コード(FROM)_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cbo_SEISANSYA_CD_F_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbo_KEIYAKUSYA_CD_F.Validating

        '2015/03/04　修正開始--▽▽▽   コンボボックスの動作変更
        'Call s_CboFrom_Validating(cbo_KEIYAKUSYA_CD_F, cbo_KEIYAKUSYA_NM_F, cbo_KEIYAKUSYA_CD_T, cbo_KEIYAKUSYA_NM_T)
        Call s_CboFrom_Validating(cbo_KEIYAKUSYA_CD_F, cbo_KEIYAKUSYA_NM_F, cbo_KEIYAKUSYA_CD_T, cbo_KEIYAKUSYA_NM_T, 2)
        '2015/03/04　修正終了--△△△

    End Sub
#End Region
#Region "生産者(TO)"
    '------------------------------------------------------------------
    'プロシージャ名  :cbo_SEISANSYA_CD_SelectedIndexChanged
    '説明            :生産者コード(TO)Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_SEISANSYA_CD_T_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_KEIYAKUSYA_CD_T.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cbo_KEIYAKUSYA_NM_T.SelectedIndex = cbo_KEIYAKUSYA_CD_T.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_SEISANSYA_NM_SelectedIndexChanged
    '説明            :生産者名(TO)Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cbo_SEISANSYA_NM_T_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_KEIYAKUSYA_NM_T.SelectedIndexChanged
        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        '↓***** 2010/11/08 ADD JBD200 FROM-TO制御共通化 *****↓
        Call s_CboMeiTo_Validating(cbo_KEIYAKUSYA_NM_T, cbo_KEIYAKUSYA_CD_T, cbo_KEIYAKUSYA_NM_F, cbo_KEIYAKUSYA_CD_F)
        '↑***** 2010/11/08 ADD JBD200 FROM-TO制御共通化 *****↑
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cbo_SEISANSYA_CD_T_Validating
    '説明            :生産者コード(TO)_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cbo_SEISANSYA_CD_T_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbo_KEIYAKUSYA_CD_T.Validating

        '2015/03/04　修正開始--▽▽▽   コンボボックスの動作変更
        'Call s_CboTo_Validating(cbo_KEIYAKUSYA_CD_T, cbo_KEIYAKUSYA_NM_T, cbo_KEIYAKUSYA_CD_F, cbo_KEIYAKUSYA_NM_F)
        Call s_CboTo_Validating(cbo_KEIYAKUSYA_CD_T, cbo_KEIYAKUSYA_NM_T, cbo_KEIYAKUSYA_CD_F, cbo_KEIYAKUSYA_NM_F, 2)
        '2015/03/04　修正終了--△△△

    End Sub
#End Region

#End Region

#Region "*** データ登録関連 ***"
#Region "f_Save 請求入金更新"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Save
    '説明            :請求入金更新
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Save() As Boolean
        Dim Cmd As New OracleCommand
        Dim wSql As String = String.Empty
        Dim ret As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            '処理区分
            Cmd.CommandText = "PKG_GJ2040.GJ2040_SEIKYU"
            '--------------------
            '請求
            '--------------------
            '期
            Dim paraNENGETU_FROM As OracleParameter = Cmd.Parameters.Add("IN_KI", txt_KI.Text.Trim)
            '回数
            Dim paraSEIKYU_KAISU As OracleParameter = Cmd.Parameters.Add("IN_SEIKYU_KAISU", CInt(txt_SEIKYU_KAISU.Text))
            '納付期限
            If date_KIGEN_DATE.Value Is Nothing Then
                Dim paraKIGEN_DATE As OracleParameter = Cmd.Parameters.Add("IN_NOFUKIGEN_DATE", DBNull.Value)
            Else
                Dim paraKIGEN_DATE As OracleParameter = Cmd.Parameters.Add("IN_NOFUKIGEN_DATE", f_DateTrim(date_KIGEN_DATE.Value))
            End If
            '発効日
            If date_SEIKYU_HAKKO_DATE.Value Is Nothing Then
                Dim paraHAKKO_DATE As OracleParameter = Cmd.Parameters.Add("IN_SEIKYU_HAKKO_DATE", DBNull.Value)
            Else
                Dim paraHAKKO_DATE As OracleParameter = Cmd.Parameters.Add("IN_SEIKYU_HAKKO_DATE", f_DateTrim(date_SEIKYU_HAKKO_DATE.Value))
            End If
            '発行年
            Dim paraHAKKO_NEN As OracleParameter = Cmd.Parameters.Add("IN_SEIKYU_HAKKO_NO_NEN", txt_SEIKYU_HAKKO_NO_NEN.Text.Trim)
            '発行連番
            Dim paraHAKKO_RENBAN As OracleParameter = Cmd.Parameters.Add("IN_SEIKYU_HAKKO_NO_RENBAN", txt_SEIKYU_HAKKO_NO_RENBAN.Text.Trim)
            '契約者番号(FROM)
            Dim paraKEIYAKUSYA_CD_F As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD_F", cbo_KEIYAKUSYA_CD_F.Text.Trim)
            '契約者番号(TO)
            Dim paraKEIYAKUSYA_CD_T As OracleParameter = Cmd.Parameters.Add("IN_SEISANSYA_CD_T", cbo_KEIYAKUSYA_CD_T.Text.Trim)
            '事務委託先(FROM)
            Dim paraJIMUITAKU_CD_F As OracleParameter = Cmd.Parameters.Add("IN_JIMUITAKU_CD_F", cbo_JIMUITAKU_CD_F.Text.Trim)
            '事務委託先(TO)
            Dim paraJIMUITAKU_CD_T As OracleParameter = Cmd.Parameters.Add("IN_JIMUITAKU_CD_T", cbo_JIMUITAKU_CD_T.Text.Trim)
            '処理区分
            If rbtn_SYORI_KBN1.Checked Then
                Dim paraKBN As OracleParameter = Cmd.Parameters.Add("IN_KBN", 1)
            Else
                If rbtn_SYORI_KBN2.Checked Then
                    Dim paraKBN As OracleParameter = Cmd.Parameters.Add("IN_KBN", 2)
                Else
                    Dim paraKBN As OracleParameter = Cmd.Parameters.Add("IN_KBN", 3)
                End If
            End If

            'データ登録日
            Dim paraREG_DATE As OracleParameter = Cmd.Parameters.Add("IN_REG_DATE", Now)
            'データ登録ＩＤ
            Dim paraREG_ID As OracleParameter = Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
            'データ更新日
            Dim paraUP_DATE As OracleParameter = Cmd.Parameters.Add("IN_UP_DATE", Now)
            'データ更新ＩＤ
            Dim paraUP_ID As OracleParameter = Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            'コンピュータ名
            Dim paraCOM_NAME As OracleParameter = Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            '--------------------
            '保存
            '--------------------
            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())

            'エラーチェック
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Show_MessageBox("", Cmd.Parameters("OU_MSGNM").Value.ToString())
                Exit Try
            End If

            ret = True

        Catch ex As Exception

            '共通例外処理
            If ex.Message <> "Err" Then
                '共通例外処理
                Show_MessageBox("", ex.Message)
            End If

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

#Region "*** ローカル関数 ***"

#Region "f_ObjectClear 画面クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ObjectClear
    '説明            :画面クリア処理
    '引数            :rKbn(処理区分)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ObjectClear(ByVal wKbn As String) As Boolean

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '画面初期化
            pJump = True
            Call f_ClearFormALL(Me, wKbn)
            pJump = False

            '画面初期化
            If wKbn = "C" Then

                '機構マスタ読込
                If Not f_TM_KYOKAI_Select() Then
                    Exit Try
                End If

            End If

            'コンボボックスセット(初期値)
            If Not f_ComboBox_Set(pInitKI) Then
                Exit Try
            End If

            '画面内容をセット
            If Not f_SetForm_Data() Then
                Exit Try
            End If

            chkRptKbn.Checked = True '2021/04/30 JBD9020 R03年度 ADD

            '請求処理へ
            '既存バグ修正のため変更 2024/03/12 JBD 453 UPD　START
            'rbtn_SYORI_KBN1.Focus() R05年度　OSバージョンアップ　
            rbtn_SYORI_KBN0.Focus()
            '既存バグ修正のため変更 2024/03/12 JBD 453 UPD END

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Function
#End Region
#Region "f_TM_KYOKAI_Select 機構マスタ取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_KYOKAI_Select
    '説明            :機構マスタ取得
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_TM_KYOKAI_Select() As Boolean

        Dim wSql As String = String.Empty
        Dim dstDataControl As New DataSet
        Dim ret As Boolean = False

        Try

            wSql = "SELECT HAKKO_NO_KANJI FROM TM_KYOKAI WHERE KYOKAI_KBN = 1"

            Call f_Select_ODP(dstDataControl, wSql)

            With dstDataControl.Tables(0)
                If .Rows.Count > 0 Then
                    lbl_HAKKO_NO_KANJI.Text = WordHenkan("N", "S", .Rows(0)("HAKKO_NO_KANJI"))
                Else
                    lbl_HAKKO_NO_KANJI.Text = ""
                    Show_MessageBox_Add("W019", "協会マスタが設定されていません") '@0
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
#Region "f_ComboBox_Set コンボボックスセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ComboBox_Set
    '説明            :コンボボックスセット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ComboBox_Set(ByVal wKI As String) As Boolean
        Dim ret As Boolean = False

        Try

            '期未入力のとき、コンボクリア
            If wKI = "" Then
                '2015/03/04　修正開始--▽▽▽    DataSourceへ変更に伴い、初期化方法変更
                'cbo_JIMUITAKU_CD_F.Items.Clear()
                'cbo_JIMUITAKU_NM_F.Items.Clear()
                'cbo_JIMUITAKU_CD_T.Items.Clear()
                'cbo_JIMUITAKU_NM_F.Items.Clear()
                'cbo_KEIYAKUSYA_CD_F.Items.Clear()
                'cbo_KEIYAKUSYA_NM_F.Items.Clear()
                'cbo_KEIYAKUSYA_CD_T.Items.Clear()
                'cbo_KEIYAKUSYA_NM_F.Items.Clear()

                cbo_JIMUITAKU_CD_F.DataSource = Nothing
                cbo_JIMUITAKU_CD_F.Clear()
                cbo_JIMUITAKU_NM_F.DataSource = Nothing
                cbo_JIMUITAKU_NM_F.Clear()

                cbo_JIMUITAKU_CD_T.DataSource = Nothing
                cbo_JIMUITAKU_CD_T.Clear()
                cbo_JIMUITAKU_NM_T.DataSource = Nothing
                cbo_JIMUITAKU_NM_T.Clear()

                cbo_KEIYAKUSYA_CD_F.DataSource = Nothing
                cbo_KEIYAKUSYA_CD_F.Clear()
                cbo_KEIYAKUSYA_NM_F.DataSource = Nothing
                cbo_KEIYAKUSYA_NM_F.Clear()

                cbo_KEIYAKUSYA_CD_T.DataSource = Nothing
                cbo_KEIYAKUSYA_CD_T.Clear()
                cbo_KEIYAKUSYA_NM_T.DataSource = Nothing
                cbo_KEIYAKUSYA_NM_T.Clear()
                '2015/03/04　修正終了--△△△
                ret = True
                Exit Try
            End If


            pJump = True   '2015/03/04　追加
            '委託先マスタコンボセット
            If Not f_JimuItaku_Data_Select(cbo_JIMUITAKU_CD_F, cbo_JIMUITAKU_NM_F, "KI = " & wKI, True, True) Then
                Exit Try
            End If
            If Not f_JimuItaku_Data_Select(cbo_JIMUITAKU_CD_T, cbo_JIMUITAKU_NM_T, "KI = " & wKI, True, True) Then
                Exit Try
            End If

            '生産者コンボ
            If Not f_Keiyaku_Data_Select(cbo_KEIYAKUSYA_CD_F, cbo_KEIYAKUSYA_NM_F, "KI = " & wKI, True, True) Then
                Exit Try
            End If
            If Not f_Keiyaku_Data_Select(cbo_KEIYAKUSYA_CD_T, cbo_KEIYAKUSYA_NM_T, "KI = " & wKI, True, True) Then
                Exit Try
            End If
            pJump = False   '2015/03/04　追加


            'コンボボックス初期化
            cbo_JIMUITAKU_CD_F.Text = ""
            cbo_JIMUITAKU_NM_F.Text = ""
            cbo_JIMUITAKU_CD_T.Text = ""
            cbo_JIMUITAKU_NM_T.Text = ""

            cbo_KEIYAKUSYA_CD_F.Text = ""
            cbo_KEIYAKUSYA_NM_F.Text = ""
            cbo_KEIYAKUSYA_CD_T.Text = ""
            cbo_KEIYAKUSYA_NM_T.Text = ""

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_SetForm_Data 初期画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_Data
    '説明            :初期画面セット
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_Data() As Boolean
        Dim ret As Boolean = False

        Try

            '処理区分　初期値
            '2020/08/17 JBS9020 UPD START
            'rbtn_SYORI_KBN1.Checked = True
            rbtn_SYORI_KBN1.Checked = False
            rbtn_SYORI_KBN0.Checked = True
            '2020/08/17 JBS9020 UPD END
            rbtn_SYORI_KBN2.Checked = False
            rbtn_SYORI_KBN3.Checked = False

            '期
            txt_KI.Text = pInitKI

            '請求処理　条件セット
            If Not f_Rireki_Set(0) Then
                Exit Try
            End If

            '2020/08/17 JBS9020 UPD START
            'rbtn_SYORI_KBN1.Focus()
            rbtn_SYORI_KBN0.Focus()
            '2020/08/17 JBS9020 UPD END

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_Rireki_Set 請求情報セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Rireki_Set1
    '説明            :請求情報セット
    '引数            :wKbn 0:初期表示　1:期入力 2:回数入力
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_Rireki_Set(ByVal wKbn As Integer) As Boolean
        Dim wSql As String = String.Empty
        Dim wDS As New DataSet
        Dim ret As Boolean = False
        Dim wBool As Boolean = False

        Try

            '年月　未入力
            If txt_KI.Text = "" Then
                pKI = 0
            Else
                pKI = txt_KI.Text
            End If

            '回数　未入力
            If txt_SEIKYU_KAISU.Text = "" Then
                pSEIKYU_KAISU = 0
            Else
                pSEIKYU_KAISU = txt_SEIKYU_KAISU.Text
            End If

            '計算履歴　読込　(契約変更区分=0(新規)のみ)
            Select Case wKbn
                Case 2
                    '回数入力
                    wSql = " SELECT * FROM TT_TUMITATE_KEISAN KEI"
                    wSql += " WHERE KI = " & pKI
                    wSql += " 　AND SEIKYU_KAISU = " & pSEIKYU_KAISU
                    wSql += "   AND KEIYAKU_HENKO_KBN = 0"
                Case Else
                    '初期表示・期入力
                    wSql = " SELECT * FROM TT_TUMITATE_KEISAN KEI"
                    wSql += " WHERE KI = " & pKI
                    wSql += "   AND KEIYAKU_HENKO_KBN = 0"
                    wSql += " ORDER BY SYORI_DATE DESC, SEIKYU_KAISU DESC "
            End Select

            Call f_Select_ODP(wDS, wSql)

            '請求履歴　表示
            With wDS.Tables(0)
                If .Rows.Count = 0 Then
                    'キークリア                    
                    pKI = 0
                    pSEIKYU_KAISU = 0
                    '画面クリア
                    If wKbn <> 2 Then
                        txt_SEIKYU_KAISU.Text = ""
                    End If
                    date_SEIKYU_DATE.Value = Nothing
                    date_KIGEN_DATE.Value = Nothing
                Else
                    'キーセット               
                    pKI = CInt(WordHenkan("N", "Z", .Rows(0)("KI")))
                    pSEIKYU_KAISU = CInt(WordHenkan("N", "Z", .Rows(0)("SEIKYU_KAISU")))
                    '回数
                    If wKbn <> 2 Then
                        txt_SEIKYU_KAISU.Text = CInt(WordHenkan("N", "Z", .Rows(0)("SEIKYU_KAISU")))
                    End If
                    '請求日
                    If WordHenkan("N", "S", .Rows(0)("SEIKYU_DATE")) = "" Then
                        date_SEIKYU_DATE.Text = ""
                    Else
                        date_SEIKYU_DATE.Value = CDate(WordHenkan("N", "S", .Rows(0)("SEIKYU_DATE")))
                    End If
                    '入金期限
                    If rbtn_SYORI_KBN2.Checked Then
                    Else
                        If WordHenkan("N", "S", .Rows(0)("KIGEN_DATE")) = "" Then
                            date_KIGEN_DATE.Text = ""
                        Else
                            date_KIGEN_DATE.Value = CDate(WordHenkan("N", "S", .Rows(0)("KIGEN_DATE")))
                        End If
                    End If
                End If

            End With

            '発行情報
            '2020/08/17 JBD9020 UPD START
            'If rbtn_SYORI_KBN2.Checked Then
            If rbtn_SYORI_KBN2.Checked Or rbtn_SYORI_KBN0.Checked Then
                '2020/08/17 JBD9020 UPD END
                date_KIGEN_DATE.Text = ""
                date_SEIKYU_HAKKO_DATE.Text = ""
                txt_SEIKYU_HAKKO_NO_NEN.Text = ""
                txt_SEIKYU_HAKKO_NO_RENBAN.Text = ""
            End If

            '入力制御
            '2020/08/17 JBD9020 UPD START
            'If rbtn_SYORI_KBN2.Checked Then
            If rbtn_SYORI_KBN2.Checked Or rbtn_SYORI_KBN0.Checked Then
                '2020/08/17 JBD9020 UPD END
                date_KIGEN_DATE.Enabled = False
                date_SEIKYU_HAKKO_DATE.Enabled = False
                txt_SEIKYU_HAKKO_NO_NEN.Enabled = False
                txt_SEIKYU_HAKKO_NO_RENBAN.Enabled = False
            Else
                date_KIGEN_DATE.Enabled = True
                date_SEIKYU_HAKKO_DATE.Enabled = True
                txt_SEIKYU_HAKKO_NO_NEN.Enabled = True
                txt_SEIKYU_HAKKO_NO_RENBAN.Enabled = True
                If date_SEIKYU_HAKKO_DATE.Value Is Nothing Then
                    date_SEIKYU_HAKKO_DATE.Value = CDate(Format(Now, "yyyy/MM/dd"))
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

#Region "f_Input_Check 画面入力チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check
    '説明            :画面入力チェック処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check(ByRef wSEIKYUSU As Integer) As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty
        Dim wDS As New DataSet
        Dim wKEISANSU As Long
        Dim wKINGAK As Long
        Dim wWHERE As String = ""

        Try
            '--------------------------------------------------
            '必須入力チェック
            '--------------------------------------------------

            '対象期
            If txt_KI.Text = "" Then
                Show_MessageBox_Add("W008", "対象期")  '@0は必須入力項目です。
                txt_KI.Focus()
                Exit Try
            End If

            '回数
            If txt_SEIKYU_KAISU.Text = "" Then
                Show_MessageBox_Add("W008", "回数")      '@0は必須入力項目です。
                txt_SEIKYU_KAISU.Focus()
                Exit Try
            End If

            If rbtn_SYORI_KBN2.Checked Then
            ElseIf rbtn_SYORI_KBN0.Checked Then '2020/08/17 JBD9020 ADD 
            Else
                '納付期限
                If date_KIGEN_DATE.Value Is Nothing Then
                    Show_MessageBox_Add("W008", "納付期限")      '@0は必須入力項目です。
                    date_KIGEN_DATE.Focus()
                    Exit Try
                End If
                '発効日
                If date_SEIKYU_HAKKO_DATE.Value Is Nothing Then
                    Show_MessageBox_Add("W008", "発行日")      '@0は必須入力項目です。
                    date_SEIKYU_HAKKO_DATE.Focus()
                    Exit Try
                End If

                '発信番号(年)
                If txt_SEIKYU_HAKKO_NO_NEN.Text.Trim = "" Then
                    Show_MessageBox_Add("W008", "発信番号")      '@0は必須入力項目です。
                    txt_SEIKYU_HAKKO_NO_NEN.Focus()
                    Exit Try
                End If

                '発信番号(連番)
                If txt_SEIKYU_HAKKO_NO_RENBAN.Text.Trim = "" Then
                    Show_MessageBox_Add("W008", "発信番号")      '@0は必須入力項目です。
                    txt_SEIKYU_HAKKO_NO_RENBAN.Focus()
                    Exit Try
                End If
            End If

            '--------------------------------------------------
            '範囲指定のチェック   
            '--------------------------------------------------
            '事務委託先
            If Not f_Daisyo_Check(cbo_JIMUITAKU_CD_F, cbo_JIMUITAKU_CD_T, "事務委託先", True, 1) Then
                Exit Try
            End If
            '契約者番号
            If Not f_Daisyo_Check(cbo_KEIYAKUSYA_CD_F, cbo_KEIYAKUSYA_CD_T, "契約者番号", True, 1) Then
                Exit Try
            End If

            '--------------------------------------------------
            '請求計算履歴のチェック   
            '--------------------------------------------------
            '請求計算履歴　読込
            wSql = " SELECT * FROM TT_TUMITATE_KEISAN"
            wSql &= " WHERE KI = " & txt_KI.Text.Trim
            wSql &= "   AND SEIKYU_KAISU = " & txt_SEIKYU_KAISU.Text.Trim

            If Not f_Select_ODP(wDS, wSql) Then
                Exit Try
            End If

            '請求計算履歴のチェック
            If wDS.Tables(0).Rows.Count = 0 Then
                Show_MessageBox_Add("W020", "指定された請求（返還）処理") '@0がありません。
                Exit Try
            Else
                If WordHenkan("N", "Z", wDS.Tables(0).Rows(0)("KEIYAKU_HENKO_KBN")) <> "0" Then
                    Show_MessageBox_Add("I007", "計算処理で作成された請求（返還）処理ではありません。") '@0
                    Exit Try
                End If
            End If

            '--------------------------------------------------
            '積立ＤＢのチェック   
            '--------------------------------------------------

            '条件セット
            If Not f_Where_Set(0, wWHERE) Then
                wWHERE = ""
                'エラーリスト出力なし
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            '対象人数、金額　計算
            wSql = "SELECT"
            wSql &= "   COUNT(TUM.KEIYAKUSYA_CD) KEISANSU,"
            wSql &= "   SUM(CASE WHEN TUM.SAGAKU_SEIKYU_KIN = 0 THEN 0 ELSE 1 END) SEIKYUSU,"
            wSql &= "   SUM(TUM.SAGAKU_SEIKYU_KIN) KINGAK "
            wSql &= "FROM"
            wSql &= "  TT_TUMITATE TUM, "
            wSql &= "  TM_KEIYAKU KYK "
            wSql &= wWHERE

            If Not f_Select_ODP(wDS, wSql) Then
                Exit Try
            End If

            With wDS.Tables(0)
                If .Rows.Count > 0 Then
                    wKEISANSU = CLng(WordHenkan("N", "Z", .Rows(0)("KEISANSU")))
                    wSEIKYUSU = CLng(WordHenkan("N", "Z", .Rows(0)("SEIKYUSU")))
                    wKINGAK = CLng(WordHenkan("N", "Z", .Rows(0)("KINGAK")))
                    '計算対象人数なし:対象なし
                    If wKEISANSU = 0 Then
                        Show_MessageBox_Add("W020", "指定された請求（返還）処理") '@0がありません。
                        Exit Try
                        '2019/03/20　追加開始
                    ElseIf wSEIKYUSU = 0 Then
                        Show_MessageBox_Add("I007", "請求金額が０円のため、請求書は出力されません。" & vbCrLf &
                                                    "更新処理のみ実行します。")      '@0
                        '2019/03/20　追加終了
                    Else
                        ''請求対象人数なし:請求更新のみ実行
                        'If wSEIKYUSU = 0 Then
                        '    If Show_MessageBox_Add("Q012", "計算対象人数 : " & Format(wKEISANSU, "##,##0") & "人" & vbCrLf & _
                        '       "請求対象人数 : " & Format(wSEIKYUSU, "##,##0") & "人" & vbCrLf & _
                        '       "納付金額 :  " & Format(wKINGAK, "#,###,###,##0") & "円" & vbCrLf & _
                        '       "生産者積立金等請求書兼返還通知書(徴収)は出力されませんが、" & vbCrLf & "処理済みとしてもよろしいですか。") = Windows.Forms.DialogResult.No Then
                        '        Exit Try
                        '    End If
                        'Else
                        '請求対象人数あり:請求諸出力後、請求更新のみ実行
                        If Show_MessageBox_Add("Q012",
                           "請求対象人数 : " & Format(wSEIKYUSU, "##,##0") & "人" & vbCrLf &
                           "納付金額 : " & Format(wKINGAK, "#,###,###,##0") & "円" & vbCrLf &
                           "生産者積立金等請求書兼返還通知書(徴収)を" & vbCrLf & "発行してもよろしいですか。") = System.Windows.Forms.DialogResult.No Then
                            Exit Try
                        End If
                        'End If

                    End If
                Else
                    Show_MessageBox_Add("W020", "指定された請求（返還）処理") '@0がありません。
                    Exit Try
                End If
            End With

            'エラーなし
            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_Where_Set 条件セット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Where_Set
    '説明            :条件セット処理
    '引数            :wKBN:0:件数カウント 1:帳票出力
    '                 wWHERE:抽出条件
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Where_Set(ByVal wKBN As Integer, ByRef wWHERE As String) As Boolean
        Dim ret As Boolean = False
        Dim dstDataControl As New DataSet

        Try

            '期・回数
            wWHERE = "WHERE TUM.KI = " & txt_KI.Text.Trim
            wWHERE &= "  AND TUM.SEIKYU_KAISU = " & txt_SEIKYU_KAISU.Text.Trim
            wWHERE &= "  AND TUM.TUMITATE_KBN = 1"

            '変更請求区分:2(請求権返還(徴収)のみ対象)
            wWHERE &= "  AND SEIKYU_HENKAN_KBN = 2"
            '契約変更区分:0(新規のみ対象)
            wWHERE &= "  AND KEIYAKU_HENKO_KBN = 0"

            '初回は、有効データのみ
            '請求書出力後の入金入力が終了しないと、ほかの処理は行えないので、初回は有効データのみ
            '再発行・修正発行の時は、一部データが無効になっている可能性がある
            '2020/08/17 JBD9020 UPD START
            'If rbtn_SYORI_KBN1.Checked Then
            If rbtn_SYORI_KBN1.Checked Or rbtn_SYORI_KBN0.Checked Then
                '2020/08/17 JBD9020 UPD END
                wWHERE &= "  AND TUM.DATA_FLG = 1"
            End If

            ''請求金額
            'If wKBN = 1 Then
            '    '請求書出力は、金額で判断
            '    wWHERE &= "  AND TUM.SAGAKU_SEIKYU_KIN > 0"
            'Else
            '    '計算対象数は、金額=0もカウントするので、ここでは抽出に含めない
            'End If

            '処理状況・請求発効日
            'If rbtn_SYORI_KBN1.Checked Then
            If rbtn_SYORI_KBN1.Checked Or rbtn_SYORI_KBN0.Checked Then
                '2020/08/17 JBD9020 UPD END
                '初回発行
                wWHERE &= "  AND TUM.SYORI_JOKYO_KBN = 1"
                wWHERE &= "  AND TUM.SEIKYU_HAKKO_DATE IS NULL"
            Else
                If rbtn_SYORI_KBN2.Checked Then
                    '再発行
                    wWHERE &= "  AND TUM.SEIKYU_HAKKO_DATE IS NOT NULL"
                Else
                    '修正発行
                    wWHERE &= "  AND TUM.SYORI_JOKYO_KBN = 1 "
                    wWHERE &= "  AND TUM.SEIKYU_HAKKO_DATE IS NOT NULL"
                End If
            End If

            '契約者
            If cbo_KEIYAKUSYA_CD_F.Text.Trim <> "" AndAlso cbo_KEIYAKUSYA_CD_T.Text.Trim <> "" Then
                wWHERE &= "  AND TUM.KEIYAKUSYA_CD BETWEEN " & cbo_KEIYAKUSYA_CD_F.Text.Trim & " AND " & cbo_KEIYAKUSYA_CD_T.Text.Trim
            End If
            '事務委託先
            wWHERE += "  AND TUM.KI = KYK.KI(+)"
            wWHERE += "  AND TUM.KEIYAKUSYA_CD = KYK.KEIYAKUSYA_CD(+)"
            If cbo_JIMUITAKU_CD_F.Text.Trim <> "" AndAlso cbo_JIMUITAKU_CD_T.Text.Trim <> "" Then
                wWHERE &= "  AND KYK.JIMUITAKU_CD BETWEEN " & cbo_JIMUITAKU_CD_F.Text.Trim & " AND " & cbo_JIMUITAKU_CD_T.Text.Trim
            End If

            'エラーなし
            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Report_Output 帳票レポート出力処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Report_Output
    '説明            :帳票レポート出力処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Report_Output() As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty
        Dim wkDSRep As New DataSet

        Dim wkAR1 As New rptGJ2040
        Dim wkAR2 As New rptGJ2070

        Try

            '--------------------------------------------------
            '   SQL作成
            '--------------------------------------------------
            If Not f_make_SQL(wSql) Then
                Exit Try
            End If

            '--------------------------------------------------
            '   データ取得
            '--------------------------------------------------
            wkDSRep.Tables.Add(pRptName)

            '2017/07/20 修正開始
            'Using wkAdp As New OracleDataAdapter(wSql, Cnn)
            '    wkAdp.Fill(wkDSRep, wkDSRep.Tables(0).TableName)
            'End Using
            'SQL実行
            If Not f_Select_ODP(wkDSRep, wSql) Then
                Exit Try
            End If
            '2017/07/20 修正終了

            If wkDSRep.Tables(0).Rows.Count > 0 Then

                '2021/04/30 JBD9020 R03年度 UPD START
                'Using wkAR As New rptGJ2040
                Dim wkAR As New Object
                If chkRptKbn.Checked Then
                    'wkAR = New rptGJ2070
                    Dim w As New rptGJ2070
                    w.sub1(wkDSRep, pSyoriKbn)
                Else
                    Dim w As New rptGJ2040
                    w.sub1(wkDSRep, pSyoriKbn)
                End If
                'Using wkAR
                '    '2021/04/30 JBD9020 R03年度 UPD END

                '    '処理区分
                '    If rbtn_SYORI_KBN1.Checked Then
                '        wkAR.pSyoriKbn = 1
                '    ElseIf rbtn_SYORI_KBN1.Checked Then
                '        wkAR.pSyoriKbn = 2
                '        '2020/09/09 JBD9020 ADD START
                '    ElseIf rbtn_SYORI_KBN0.Checked Then
                '        wkAR.pSyoriKbn = 0
                '        '2020/09/09 JBD9020 ADD END
                '    Else
                '        wkAR.pSyoriKbn = 3
                '    End If

                '    '印影を取得
                '    wkAR.imgInei = f_inei_Get() '2018/06/12 追加
                '    'ヘッダ用の値を保管
                '    wkAR.pKikin2 = pKikin2      '2017/07/14　追加
                '    ' 用紙サイズを A4縦 に設定します。
                '    wkAR.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
                '    wkAR.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait
                '    ' 上下の余白を 1.0cm に設定します。
                '    wkAR.PageSettings.Margins.Top = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_UP)
                '    wkAR.PageSettings.Margins.Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_DOWN)
                '    ' 左の余白を 1.0cm に設定します。
                '    wkAR.PageSettings.Margins.Left = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_LEFT)
                '    ' 右の余白を 0.0cm に設定します。
                '    myYOHAKU_RIGHT = 0
                '    wkAR.PageSettings.Margins.Right = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_RIGHT)

                '    '----------------------------------------------------

                '    '----------------------------------------------------
                '    wkAR.DataSource = wkDSRep
                '    wkAR.DataMember = wkDSRep.Tables(0).TableName
                '    wkAR.Run(False) '実行

                '    ''--------------------------------------------------
                '    ''ＰＤＦ出力
                '    ''--------------------------------------------------
                '    'ファイル存在ﾁｪｯｸ()
                '    Dim strOutPath As String = ""
                '    If Not f_ReportPath_Check(strOutPath, 0, myREPORT_PDF_PATH, pAPP & pRptName) Then
                '        Exit Try
                '    Else
                '        Using export As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                '            export.Export(wkAR.Document, strOutPath)
                '        End Using
                '    End If

                '    '--------------------------------------------------
                '    'プレビュー表示
                '    '--------------------------------------------------
                '    Dim wkForm As New frmViewer(wkAR, pAPP & pRptName) '※このプレビューは関数を抜けたあとも生き残る。
                '    wkForm.Show()

                'End Using

                ret = True
            Else
                'エラーリスト出力なし
                Show_MessageBox("I002", "") '該当データが存在しません。
                ret = False
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'メモリを解放します
            Call s_GC_Dispose()
        End Try

        Return ret

    End Function
#End Region
#Region "f_make_SQL 帳票データ出力用ＳＱＬ作成"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :帳票データ出力用ＳＱＬ作成
    '引数            :区分
    '戻り値          :String(SQL文)
    '------------------------------------------------------------------
    Private Function f_make_SQL(ByRef wSql As String) As Boolean
        Dim ret As Boolean = False
        Dim wWHERE As String = String.Empty

        Try

            '条件セット
            If Not f_Where_Set(1, wWHERE) Then
                wWHERE = ""
                'エラーリスト出力なし
                'Show_MessageBox_Add("W020", "指定された請求（返還）処理") '@0がありません     '2017/07/20削除
                Exit Try
            End If

            wSql = ""
            wSql &= "SELECT"
            wSql &= "  WK1.KI,"
            wSql &= "  TO_MULTI_BYTE(WK1.KI) TOU_KI_N,"
            wSql &= "  TO_MULTI_BYTE(WK1.KI-1) ZEN_KI_N,"
            wSql &= "  WK1.SEIKYU_KAISU,"
            wSql &= "  TRIM(TO_CHAR(WK1.KEIYAKUSYA_CD,'00000')) KEIYAKUSYA_CD,"
            '  --契約者マスタ
            wSql &= "  '〒' || SUBSTR(KYK.ADDR_POST,1,3) || '-' ||SUBSTR(KYK.ADDR_POST,4,4) KYK_POST,"
            wSql &= "  RTRIM(KYK.ADDR_1) || RTRIM(KYK.ADDR_2) KYK_ADDR1,"
            wSql &= "  KYK.ADDR_3 KYK_ADDR2,"
            wSql &= "  KYK.ADDR_4 KYK_ADDR3,"
            wSql &= "  CASE WHEN KYK.DAIHYO_NAME IS NULL THEN KYK.KEIYAKUSYA_NAME || '様' ELSE KYK.KEIYAKUSYA_NAME END KYK_KEIYAKUSYA_NAME,"
            'wSql &= "  CASE WHEN KYK.DAIHYO_NAME IS NULL THEN NULL ELSE KYK.DAIHYO_NAME || '様' END KYK_DAIHYO_NAME,"           '2015/12/01　修正
            wSql &= "  CASE WHEN KYK.DAIHYO_NAME IS NULL THEN NULL ELSE '　' || KYK.DAIHYO_NAME || '様' END KYK_DAIHYO_NAME,"     '2015/12/01　修正
            wSql &= "  '(' || TRIM(TO_CHAR(WK1.KEIYAKUSYA_CD,'00000')) || ')' KEIYAKUSYA_CD_KAKKO,"
            wSql &= "  WK1.KEIYAKU_KBN,"
            'wSql &= "  M01.RYAKUSYO KEIYAKU_KBN_NM,"   '2017/07/20　修正
            wSql &= "  M01.MEISYO KEIYAKU_KBN_NM,"      '2017/07/20　修正
            '  --協会マスタ
            wSql &= "  '(登録番号：' || KYO.TOUROKU_NO  || ')' TOUROKU_NO," '登録番号　2023/08/17 JBD454 R5年度インボイス対応 ADD
            wSql &= "  KYO.HAKKO_NO_KANJI,"
            wSql &= "  KYO.KYOKAI_NAME KYO_KYOKAI_NAME,"
            wSql &= "  KYO.YAKUMEI KYO_YAKUMEI,"
            wSql &= "  KYO.KAICHO_NAME KYO_KAICHO_NAME,"
            wSql &= "  KYO.ADDR1  || ADDR2 KYO_ADDR,"
            wSql &= "  'ＴＥＬ' || KYO.TEL1 KYO_TEL1,"
            wSql &= "  'ＦＡＸ' || KYO.FAX1 KYO_FAX1,"
            wSql &= "  BNK.BANK_NAME FURI_BANK_NAME,"
            wSql &= "  BNK.BANK_KANA BANK_KANA,"
            wSql &= "  SIT.SITEN_NAME FURI_SITEN_NAME,"
            wSql &= "  SIT.SITEN_KANA SITEN_KANA,"
            wSql &= "  '(' || M04.MEISYO || ')' FURI_KOZA_SYUBETU,"
            wSql &= "  TO_MULTI_BYTE(KYO.FURI_KOZA_NO) FURI_KOZA_NO_N,"
            wSql &= "  KYO.FURI_KOZA_MEIGI,"
            wSql &= "  KYO.FURI_KOZA_MEIGI_KANA,"
            '  --前期積立金返還
            wSql &= "  ZEN.TUMITATE_KIN_KEI,"
            wSql &= "  ZEN.HENKAN_KEISU,"
            wSql &= "  ZEN.HENKAN_KAKUTEI_KIN,"
            '  --積立情報
            If rbtn_SYORI_KBN1.Checked OrElse rbtn_SYORI_KBN3.Checked Then
                wSql &= "  TO_CHAR(TO_DATE('" & Format(date_KIGEN_DATE.Value, "yyyy/MM/dd") & "'), 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NOFUKIGEN_DATE,"
                wSql &= "  TO_CHAR(TO_DATE('" & Format(date_SEIKYU_HAKKO_DATE.Value, "yyyy/MM/dd") & "'), 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SEIKYU_HAKKO_DATE,"
                wSql &= "  " & txt_SEIKYU_HAKKO_NO_NEN.Text.Trim & " SEIKYU_HAKKO_NO_NEN,"
                wSql &= "  " & txt_SEIKYU_HAKKO_NO_RENBAN.Text.Trim & " SEIKYU_HAKKO_NO_RENBAN,"
                '2020/08/17 JBD9020 ADD START
            ElseIf rbtn_SYORI_KBN0.Checked Then
                wSql &= "  '　　　　　　　　' AS NOFUKIGEN_DATE,"
                wSql &= "  '　　　　　　　　' AS SEIKYU_HAKKO_DATE,"
                wSql &= "  '  ' SEIKYU_HAKKO_NO_NEN,"
                wSql &= "  '    ' SEIKYU_HAKKO_NO_RENBAN,"
                '2020/08/17 JBD9020 ADD END
            Else
                wSql &= "  TO_CHAR(WK1.NOFUKIGEN_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NOFUKIGEN_DATE,"
                wSql &= "  TO_CHAR(WK1.SEIKYU_HAKKO_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SEIKYU_HAKKO_DATE,"
                wSql &= "  WK1.SEIKYU_HAKKO_NO_NEN,"
                wSql &= "  WK1.SEIKYU_HAKKO_NO_RENBAN,"
            End If
            For i = 1 To 6
                wSql &= "  WK1.TORI_KBN_NM" & i & ","       '2017/07/20　追加
                wSql &= "  WK1.HASU" & i & ","
                wSql &= "  WK1.TUMITATE_TANKA" & i & ","
                wSql &= "  WK1.TUMITATE_KIN" & i & ","
            Next
            wSql &= "  WK1.HASU7,  WK1.TUMITATE_KIN7,"
            wSql &= "  WK1.TUMITATE_KIN, WK1.TESURYO, WK1.SEIKYU_KIN, "
            wSql &= "  WK1.SAGAKU_SEIKYU_KIN,"
            wSql &= "  WK1.TESURYO_RITU,"
            wSql &= "  '　　内　' || WK1.TESURYO_SYOHIZEI_RITU || '％消費税 ' TESURYO_SYOHIZEI_RITU," '手数料消費税率　2023/08/17 JBD454 R5年度インボイス対応 ADD 
            wSql &= "  WK1.TESURYO_SYOHIZEI TESURYO_SYOHIZEI,"                                    　  '手数料消費税額　2023/08/17 JBD454 R5年度インボイス対応 ADD

            '  --委託先
            wSql &= "  KYK.JIMUITAKU_CD,"
            wSql &= "  ITK.ITAKU_NAME,"
            wSql &= "  ITK.BANK_INJI_KBN "
            wSql &= "FROM"
            wSql &= "  TM_KYOKAI KYO,"
            wSql &= "  TM_KEIYAKU KYK,"
            wSql &= "  TM_CODE M01,"
            wSql &= "  TM_BANK BNK,"
            wSql &= "  TM_SITEN SIT,"
            wSql &= "  TM_CODE M04,"
            wSql &= "  TM_JIMUITAKU ITK,"
            wSql &= "  TT_ZENKI_TUMITATE_HENKAN ZEN,"
            wSql &= "  (SELECT"
            wSql &= "     WK2.KI,"
            wSql &= "     WK2.KI - 1 ZEN_KI,"
            wSql &= "     WK2.SEIKYU_KAISU,"
            wSql &= "     WK2.KEIYAKUSYA_CD,"
            wSql &= "     WK2.KEIYAKU_KBN,"
            wSql &= "     MAX(WK2.TESURYO_RITU) TESURYO_RITU,"
            wSql &= "     MAX(WK2.KEIYAKU_DATE_FROM) KEIYAKU_DATE_FROM,"
            wSql &= "     MAX(WK2.TUMITATE_KIN) TUMITATE_KIN,"
            wSql &= "     MAX(WK2.TESURYO) TESURYO,"
            wSql &= "     MAX(WK2.TESURYO_SYOHIZEI_RITU) TESURYO_SYOHIZEI_RITU,"  '手数料消費税率　2023/08/08 JBD454 R5年度インボイス対応 ADD
            wSql &= "     MAX(WK2.TESURYO_SYOHIZEI) TESURYO_SYOHIZEI,"            '手数料消費税額　2023/08/08 JBD454 R5年度インボイス対応 ADD
            wSql &= "     MAX(WK2.SEIKYU_KIN) SEIKYU_KIN,"
            wSql &= "     MAX(WK2.SAGAKU_SEIKYU_KIN) SAGAKU_SEIKYU_KIN,"
            wSql &= "     MAX(WK2.NOFUKIGEN_DATE) NOFUKIGEN_DATE,"
            wSql &= "     MAX(WK2.SEIKYU_HAKKO_DATE) SEIKYU_HAKKO_DATE,"
            wSql &= "     MAX(WK2.SEIKYU_HAKKO_NO_NEN) SEIKYU_HAKKO_NO_NEN,"
            wSql &= "     MAX(WK2.SEIKYU_HAKKO_NO_RENBAN) SEIKYU_HAKKO_NO_RENBAN,"
            For i = 1 To 6
                wSql &= "     MAX(CASE WHEN WK2.GYO = " & i & " THEN WK2.TORI_KBN_NM    ELSE NULL END) TORI_KBN_NM" & i & ","   '2017/07/20　追加
                wSql &= "     SUM(CASE WHEN WK2.GYO = " & i & " THEN WK2.HASU           ELSE NULL END) HASU" & i & ","
                wSql &= "     MAX(CASE WHEN WK2.GYO = " & i & " THEN WK2.TUMITATE_TANKA ELSE NULL END) TUMITATE_TANKA" & i & ","
                wSql &= "     SUM(CASE WHEN WK2.GYO = " & i & " THEN WK2.TUMITATE_KIN   ELSE NULL END) TUMITATE_KIN" & i & ","
            Next
            wSql &= "     SUM(WK2.HASU)  HASU7,"
            wSql &= "     SUM(WK2.TUMITATE_KIN)  TUMITATE_KIN7"
            wSql &= "   FROM"
            '2017/07/20　修正開始
            wSql &= "     (SELECT"
            wSql &= "        TUM.KI,"
            wSql &= "        TUM.KI - 1 ZEN_KI,"
            wSql &= "        TUM.SEIKYU_KAISU,"
            wSql &= "        TUM.KEIYAKUSYA_CD,"
            wSql &= "        TUM.KEIYAKU_KBN,"
            wSql &= "        MEI.TORI_KBN,"
            wSql &= "        M07.MEISYO TORI_KBN_NM,"
            wSql &= "        DENSE_RANK() OVER(PARTITION BY TUM.KI, TUM.SEIKYU_KAISU, TUM.KEIYAKUSYA_CD ORDER BY MEI.TORI_KBN) GYO,"
            wSql &= "                MAX(TUM.TESURYO_RITU) TESURYO_RITU,"
            wSql &= "        MAX(TUM.KEIYAKU_DATE_FROM) KEIYAKU_DATE_FROM,"
            wSql &= "        MAX(TUM.TESURYO) TESURYO,"
            wSql &= "        MAX(TUM.TESURYO_SYOHIZEI_RITU) TESURYO_SYOHIZEI_RITU," 　'手数料消費税率　2023/08/08 JBD454 R5年度インボイス対応 ADD
            wSql &= "        MAX(TUM.TESURYO_SYOHIZEI) TESURYO_SYOHIZEI,"　     　　　'手数料消費税額　2023/08/08 JBD454 R5年度インボイス対応 ADD
            wSql &= "        MAX(TUM.SEIKYU_KIN) SEIKYU_KIN,"
            wSql &= "        MAX(TUM.SAGAKU_SEIKYU_KIN) SAGAKU_SEIKYU_KIN,"
            wSql &= "        MAX(TUM.NOFUKIGEN_DATE) NOFUKIGEN_DATE,"
            wSql &= "        MAX(TUM.SEIKYU_HAKKO_DATE) SEIKYU_HAKKO_DATE,"
            wSql &= "        MAX(TUM.SEIKYU_HAKKO_NO_NEN) SEIKYU_HAKKO_NO_NEN,"
            wSql &= "        MAX(TUM.SEIKYU_HAKKO_NO_RENBAN) SEIKYU_HAKKO_NO_RENBAN,"
            wSql &= "        SUM(MEI.HASU) HASU,"
            wSql &= "        MAX(MEI.TUMITATE_TANKA) TUMITATE_TANKA,"
            wSql &= "        SUM(MEI.TUMITATE_KIN) TUMITATE_KIN"
            wSql &= "      FROM"
            '初回請求・再請求・修正請求
            wSql &= "        TT_TUMITATE TUM,"
            wSql &= "        TM_KEIYAKU  KYK,"
            wSql &= "        TT_TUMITATE_MEISAI MEI,"
            wSql &= "        TM_CODE M07 "
            wSql &= wWHERE
            '積立明細
            wSql &= "        and TUM.SAGAKU_SEIKYU_KIN <> 0"    '2019/03/20　追加
            wSql &= "        AND TUM.KI = MEI.KI"
            wSql &= "        AND TUM.SEIKYU_KAISU = MEI.SEIKYU_KAISU"
            wSql &= "        AND TUM.KEIYAKUSYA_CD = MEI.KEIYAKUSYA_CD"
            wSql &= "        AND TUM.TUMITATE_KBN = MEI.TUMITATE_KBN"
            wSql &= "        AND 7 = M07.SYURUI_KBN(+)"
            wSql &= "        AND MEI.TORI_KBN = M07.MEISYO_CD(+)"
            wSql &= "      GROUP BY"
            wSql &= "        TUM.KI,"
            wSql &= "        TUM.SEIKYU_KAISU,"
            wSql &= "        TUM.KEIYAKUSYA_CD,"
            wSql &= "        TUM.KEIYAKU_KBN,"
            wSql &= "        MEI.TORI_KBN,"
            wSql &= "        M07.MEISYO"
            wSql &= "     ) WK2"
            '2017/07/20　修正終了

            wSql &= "   GROUP BY"
            wSql &= "     WK2.KI,"
            wSql &= "     WK2.SEIKYU_KAISU,"
            wSql &= "     WK2.KEIYAKUSYA_CD,"
            wSql &= "     WK2.KEIYAKU_KBN"
            wSql &= "  ) WK1 "
            wSql &= "WHERE 1 = KYO.KYOKAI_KBN(+)"
            '  --契約者マスタ
            wSql &= "  AND WK1.KI = KYK.KI(+)"
            wSql &= "  AND WK1.KEIYAKUSYA_CD = KYK.KEIYAKUSYA_CD(+)"
            '  --コードマスタ(契約者区分)
            wSql &= "  AND 1 = M01.SYURUI_KBN(+)"
            wSql &= "  AND WK1.KEIYAKU_KBN = M01.MEISYO_CD(+)"
            '  --委託先マスタ
            wSql &= "  AND KYK.KI = ITK.KI(+)"
            wSql &= "  AND KYK.JIMUITAKU_CD = ITK.ITAKU_CD(+)"
            '  --銀行
            wSql &= "  AND KYO.FURI_BANK_CD = BNK.BANK_CD(+)"
            '  --支店
            wSql &= "  AND KYO.FURI_BANK_CD = SIT.BANK_CD(+)"
            wSql &= "  AND KYO.FURI_BANK_SITEN_CD = SIT.SITEN_CD(+)"
            '  --コードマスタ(口座)
            wSql &= "  AND 4 = M04.SYURUI_KBN(+)"
            wSql &= "  AND KYO.FURI_KOZA_SYUBETU = M04.MEISYO_CD(+)"
            '  --前期積立金返還
            'wSql &= "  AND WK1.ZEN_KI = ZEN.KI(+)"     2015/03/23
            wSql &= "  AND WK1.KI = ZEN.KI(+)"
            wSql &= "  AND WK1.KEIYAKUSYA_CD = ZEN.KEIYAKUSYA_CD(+) "
            '--出力順
            wSql &= "ORDER BY"
            wSql &= "  KYK.JIMUITAKU_CD, WK1.KEIYAKUSYA_CD"

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#End Region

    Private Sub txt_KI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_KI.TextChanged

    End Sub
End Class
