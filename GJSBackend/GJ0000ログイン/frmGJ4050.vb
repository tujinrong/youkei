'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ4050.vb
'*
'*　　②　機能概要　　　　　互助金交付通知書発行
'*
'*　　③　作成日　　　　　　2015/03/18  BY JBD
'*
'*　　④　更新日            2022/02/21 JBD439 R03年度対応
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

Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.ActiveReports.Export
Imports GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport

Imports System.IO
Imports JbdGjsReport

Public Class frmGJ4050

#Region "*** 変数定義 ***"

    Public pRptName As String = "家畜防疫互助金交付通知書（振込）"     '帳票名

    Private pInitKI As Integer              '期(初期値)
    Private pEnterKI As String              '期(変更前)
    Private pKI As String                   '期
    Private pHASSEI_KAISU As String         '認定回数    '2022/02/01 JBD439 ADD  R03年度対応　発生回数を認定回数に変更
    Private pKEISAN_KAISU As String         '計算回数
    Private pJump As Boolean = True         '処理ジャンプ
    Private pSyoriKbn As Integer

#End Region

#Region "*** 画面制御関連 ***"

#Region "frmGJ4050_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ4050_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ4050_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    '説明            :プレビューボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        Dim ea As New System.ComponentModel.CancelEventArgs

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '入力項目チェック
            If Not f_Input_Check() Then
                Exit Try
            End If


            '対象者ありのとき、帳票出力処理
            If Not f_Report_Output() Then
                Exit Try
            End If

            '互助金交付更新
            If Not f_Save() Then
                Exit Try
            End If

            '正常終了
            Show_MessageBox("I001", "") '正常に終了しました。

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
    Private Sub cmdCan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

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
                rbtn_SYORI_KBN1.CheckedChanged, rbtn_SYORI_KBN2.CheckedChanged, rbtn_SYORI_KBN3.CheckedChanged

        If pJump Then
            Exit Sub
        End If

        If (sender.Equals(rbtn_SYORI_KBN1) AndAlso rbtn_SYORI_KBN1.Checked) OrElse
           (sender.Equals(rbtn_SYORI_KBN2) AndAlso rbtn_SYORI_KBN2.Checked) OrElse
           (sender.Equals(rbtn_SYORI_KBN3) AndAlso rbtn_SYORI_KBN3.Checked) Then
            '画面再表示
            If txt_KI.Text.Trim = "" Then
                '期：未入力
                f_Rireki_Set(0)
            ElseIf txt_HASSEI_KAISU.Text.Trim = "" Then
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
                txt_KI.Validating, txt_HASSEI_KAISU.Validating, txt_KEISAN_KAISU.Validating
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
                Case "txt_HASSEI_KAISU"
                    wKBN = 2
                Case "txt_KEISAN_KAISU"
                    wKBN = 3
                Case Else
                    wKBN = 0
            End Select

            '期・回数　変更時、再表示
            If pKI <> txt_KI.Text.Trim OrElse
               pHASSEI_KAISU <> txt_HASSEI_KAISU.Text OrElse
               pKEISAN_KAISU <> txt_KEISAN_KAISU.Text Then
                '画面表示
                f_Rireki_Set(wKBN)
            Else
                '振込予定日が空白のとき、振込予定日のみ再表示
                If date_FURI_YOTEI_DATE.Value Is Nothing OrElse date_FURI_YOTEI_DATE.Value = New Date Then
                    f_Rireki_Set(2)
                Else
                    If date_HAKKO_DATE.Value Is Nothing Then
                        date_HAKKO_DATE.Value = CDate(Format(Now, "yyyy/MM/dd"))
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
#Region "f_Save 互助金交付更新"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Save
    '説明            :互助金交付更新
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
            Cmd.CommandText = "PKG_GJ4050.GJ4050_KOFU"
            '--------------------
            '交付
            '--------------------
            '期
            Dim paraNENGETU_FROM As OracleParameter = Cmd.Parameters.Add("IN_KI", txt_KI.Text.Trim)
            '’発生回数
            '認定回数    '2022/02/01 JBD439 UPD  R03年度対応　発生回数を認定回数に変更
            Dim paraHASSEI_KAISU As OracleParameter = Cmd.Parameters.Add("IN_HASSEI_KAISU", CInt(txt_HASSEI_KAISU.Text))
            '計算回数
            Dim paraKEISAN_KAISU As OracleParameter = Cmd.Parameters.Add("IN_KEISAN_KAISU", CInt(txt_KEISAN_KAISU.Text))
            '振込予定日
            Dim paraFURIKOMI_YOTEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_FURIKOMI_YOTEI_DATE", Format(date_FURI_YOTEI_DATE.Value, "yyyy/MM/dd"))
            '発行日
            Dim paraKOFUTUTI_HAKKO_DATE As OracleParameter = Cmd.Parameters.Add("IN_KOFUTUTI_HAKKO_DATE", Format(date_HAKKO_DATE.Value, "yyyy/MM/dd"))
            '発行年
            Dim paraKOFUTUTI_HAKKO_NO_NEN As OracleParameter = Cmd.Parameters.Add("IN_KOFUTUTI_HAKKO_NO_NEN", txt_HAKKO_NO_NEN.Text.Trim)
            '発行連番
            Dim paraKOFUTUTI_HAKKO_NO_RENBAN As OracleParameter = Cmd.Parameters.Add("IN_KOFUTUTI_HAKKO_NO_RENBAN", txt_HAKKO_NO_RENBAN.Text.Trim)
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

                'コンボボックスセット(初期値)
                If Not f_ComboBox_Set(pInitKI) Then
                    Exit Try
                End If

            End If

            '画面内容をセット
            If Not f_SetForm_Data() Then
                Exit Try
            End If

            '初回発行へ
            rbtn_SYORI_KBN1.Focus()

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
            rbtn_SYORI_KBN1.Checked = True
            rbtn_SYORI_KBN2.Checked = False
            rbtn_SYORI_KBN3.Checked = False

            '期
            txt_KI.Text = pInitKI

            '履歴処理　条件セット
            If Not f_Rireki_Set(0) Then
                Exit Try
            End If

            rbtn_SYORI_KBN1.Focus()

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Rireki_Set 履歴情報セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Rireki_Set1
    '説明            :履歴情報セット
    '引数            :wKbn 0:初期表示　1:期入力 2:認定回数入力 3:計算回数入力  '2022/02/01 JBD439 ADD  R03年度対応　発生回数を認定回数に変更
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_Rireki_Set(ByVal wKbn As Integer) As Boolean
        Dim wSql As String = String.Empty
        Dim wDS As New DataSet
        Dim ret As Boolean = False
        Dim wBool As Boolean = False

        Try

            '期　未入力
            If txt_KI.Text = "" Then
                pKI = 0
            Else
                pKI = txt_KI.Text
            End If

            '’発生回数　未入力
            '認定回数　未入力  '2022/02/01 JBD439 ADD  R03年度対応　発生回数を認定回数に変更
            If txt_HASSEI_KAISU.Text = "" Then
                pHASSEI_KAISU = 0
            Else
                pHASSEI_KAISU = txt_HASSEI_KAISU.Text
            End If

            '計算回数　未入力
            If txt_KEISAN_KAISU.Text = "" Then
                pKEISAN_KAISU = 0
            Else
                pKEISAN_KAISU = txt_KEISAN_KAISU.Text
            End If


            '計算履歴　読込　
            Select Case wKbn
                Case 3
                    '計算回数入力
                    wSql = " SELECT * FROM TT_KOFU_KEISAN "
                    wSql += " WHERE KI = " & pKI
                    wSql += " 　AND HASSEI_KAISU = " & pHASSEI_KAISU
                    wSql += " 　AND KEISAN_KAISU = " & pKEISAN_KAISU
                    wSql += " ORDER BY SYORI_DATE DESC, HASSEI_KAISU, KEISAN_KAISU DESC "
                Case 2
                    '’発生回数入力
                    '認定回数入力   '2022/02/01 JBD439 ADD  R03年度対応　発生回数を認定回数に変更
                    wSql = " SELECT * FROM TT_KOFU_KEISAN "
                    wSql += " WHERE KI = " & pKI
                    wSql += " 　AND HASSEI_KAISU = " & pHASSEI_KAISU
                    wSql += " ORDER BY SYORI_DATE DESC, HASSEI_KAISU, KEISAN_KAISU DESC "
                Case Else
                    '初期表示・期入力
                    wSql = " SELECT * FROM TT_KOFU_KEISAN"
                    wSql += " WHERE KI = " & pKI
                    wSql += " ORDER BY SYORI_DATE DESC, HASSEI_KAISU, KEISAN_KAISU DESC "
            End Select

            Call f_Select_ODP(wDS, wSql)

            '請求履歴　表示
            With wDS.Tables(0)
                If .Rows.Count = 0 Then
                    'キークリア                    
                    pKI = 0
                    pHASSEI_KAISU = 0
                    pKEISAN_KAISU = 0
                    '画面クリア
                    If wKbn = 2 Then
                        txt_KEISAN_KAISU.Text = ""
                    End If
                    date_FURI_YOTEI_DATE.Value = Nothing
                Else
                    'キーセット               
                    pKI = CInt(WordHenkan("N", "Z", .Rows(0)("KI")))
                    pHASSEI_KAISU = CInt(WordHenkan("N", "Z", .Rows(0)("HASSEI_KAISU")))
                    pKEISAN_KAISU = CInt(WordHenkan("N", "Z", .Rows(0)("KEISAN_KAISU")))
                    '’発生回数
                    '認定回数  '2022/02/01 JBD439 ADD  R03年度対応　発生回数を認定回数に変更
                    txt_HASSEI_KAISU.Text = CInt(WordHenkan("N", "Z", .Rows(0)("HASSEI_KAISU")))
                    '計算回数
                    txt_KEISAN_KAISU.Text = CInt(WordHenkan("N", "Z", .Rows(0)("KEISAN_KAISU")))
                    '振込予定日
                    If WordHenkan("N", "S", .Rows(0)("FURI_YOTEI_DATE")) = "" Then
                        date_FURI_YOTEI_DATE.Value = Nothing
                    Else
                        date_FURI_YOTEI_DATE.Value = CDate(WordHenkan("N", "S", .Rows(0)("FURI_YOTEI_DATE")))
                    End If
                End If

            End With

            '発行情報
            If rbtn_SYORI_KBN2.Checked Then
                date_FURI_YOTEI_DATE.Text = ""
                date_HAKKO_DATE.Text = ""
                txt_HAKKO_NO_NEN.Text = ""
                txt_HAKKO_NO_RENBAN.Text = ""
            End If

            '入力制御
            If rbtn_SYORI_KBN2.Checked Then
                date_FURI_YOTEI_DATE.Enabled = False
                date_HAKKO_DATE.Enabled = False
                txt_HAKKO_NO_NEN.Enabled = False
                txt_HAKKO_NO_RENBAN.Enabled = False
            Else
                date_FURI_YOTEI_DATE.Enabled = True
                date_HAKKO_DATE.Enabled = True
                txt_HAKKO_NO_NEN.Enabled = True
                txt_HAKKO_NO_RENBAN.Enabled = True
                If date_HAKKO_DATE.Value Is Nothing Then
                    date_HAKKO_DATE.Value = CDate(Format(Now, "yyyy/MM/dd"))
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
    Private Function f_Input_Check() As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty
        Dim wDS As New DataSet
        Dim wTAISYOSU As Long
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
            '↓2022/02/01 JBD439 UPD  R03年度対応　発生回数を認定回数に変更
            ''発生回数 
            'If txt_HASSEI_KAISU.Text = "" Then
            '    Show_MessageBox_Add("W008", "発生回数")      '@0は必須入力項目です。 
            '    txt_HASSEI_KAISU.Focus()
            '    Exit Try
            'End If
            '認定回数  '2022/02/01 JBD439 ADD  R03年度対応　発生回数を認定回数に変更
            If txt_HASSEI_KAISU.Text = "" Then
                Show_MessageBox_Add("W008", "認定回数")      '@0は必須入力項目です。  '2022/02/01 JBD439 ADD  R03年度対応　発生回数を認定回数に変更
                txt_HASSEI_KAISU.Focus()
                Exit Try
            End If
            '↑2022/02/01 JBD439 UPD

            '計算回数
            If txt_KEISAN_KAISU.Text = "" Then
                Show_MessageBox_Add("W008", "計算回数")      '@0は必須入力項目です。
                txt_KEISAN_KAISU.Focus()
                Exit Try
            End If

            If rbtn_SYORI_KBN2.Checked Then
            Else
                '振込予定日
                If date_FURI_YOTEI_DATE.Value Is Nothing Then
                    Show_MessageBox_Add("W008", "振込予定日")      '@0は必須入力項目です。
                    date_FURI_YOTEI_DATE.Focus()
                    Exit Try
                End If
                '発効日
                If date_HAKKO_DATE.Value Is Nothing Then
                    Show_MessageBox_Add("W008", "発行日")      '@0は必須入力項目です。
                    date_HAKKO_DATE.Focus()
                    Exit Try
                End If

                '発信番号(年)
                If txt_HAKKO_NO_NEN.Text.Trim = "" Then
                    Show_MessageBox_Add("W008", "発信番号")      '@0は必須入力項目です。
                    txt_HAKKO_NO_NEN.Focus()
                    Exit Try
                End If

                '発信番号(連番)
                If txt_HAKKO_NO_RENBAN.Text.Trim = "" Then
                    Show_MessageBox_Add("W008", "発信番号")      '@0は必須入力項目です。
                    txt_HAKKO_NO_RENBAN.Focus()
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
            '計算履歴のチェック   
            '--------------------------------------------------
            '計算履歴　読込
            wSql = " SELECT * FROM TT_KOFU_KEISAN"
            wSql &= " WHERE KI = " & txt_KI.Text.Trim
            wSql &= "   AND HASSEI_KAISU = " & txt_HASSEI_KAISU.Text.Trim
            wSql &= "   AND KEISAN_KAISU = " & txt_KEISAN_KAISU.Text.Trim

            If Not f_Select_ODP(wDS, wSql) Then
                Exit Try
            End If

            '計算履歴のチェック
            If wDS.Tables(0).Rows.Count = 0 Then
                Show_MessageBox_Add("W020", "指定された互助交付処理") '@0がありません。
                Exit Try
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
            wSql &= "   COUNT(KOFU.KEIYAKUSYA_CD) TAISYOSU,"
            wSql &= "   SUM(KOFU.KOFU_KIN_KEI) KINGAK "
            wSql &= "FROM"
            wSql &= "  TT_KOFU KOFU, "
            wSql &= "  TM_KEIYAKU KYK "
            wSql &= wWHERE

            If Not f_Select_ODP(wDS, wSql) Then
                Exit Try
            End If

            With wDS.Tables(0)
                If .Rows.Count > 0 Then
                    wTAISYOSU = CLng(WordHenkan("N", "Z", .Rows(0)("TAISYOSU")))
                    wKINGAK = CLng(WordHenkan("N", "Z", .Rows(0)("KINGAK")))
                    '計算対象人数なし:対象なし
                    If wTAISYOSU = 0 Then
                        Show_MessageBox_Add("W020", "指定された互助交付処理") '@0がありません。
                        Exit Try
                    Else
                        '対象人数あり:出力後、更新のみ実行
                        If Show_MessageBox_Add("Q012",
                           "交付対象人数 : " & Format(wTAISYOSU, "##,##0") & "人" & vbCrLf &
                           "交付金額 : " & Format(wKINGAK, "#,###,###,##0") & "円" & vbCrLf &
                           "家畜防疫互助金交付通知書を" & vbCrLf & "発行してもよろしいですか。") = System.Windows.Forms.DialogResult.No Then
                            Exit Try
                        End If
                        'End If

                    End If
                Else
                    '処理状況・振込予定日
                    If rbtn_SYORI_KBN1.Checked Then
                        Show_MessageBox_Add("W020", "指定された互助交付処理") '@0がありません。
                    Else
                        Show_MessageBox_Add("W019", "まだ発行されていないため処理できません。") '@0がありません。
                    End If

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
            wWHERE = "WHERE KOFU.KI = " & txt_KI.Text.Trim
            wWHERE &= "  AND KOFU.HASSEI_KAISU = " & txt_HASSEI_KAISU.Text.Trim
            wWHERE &= "  AND KOFU.KEISAN_KAISU = " & txt_KEISAN_KAISU.Text.Trim


            '処理状況・振込予定日
            If rbtn_SYORI_KBN1.Checked Then
                '初回発行
                wWHERE &= "  AND KOFU.SYORI_JOKYO = 1"
                'wWHERE &= "  AND KOFU.FURIKOMI_YOTEI_DATE IS NULL"
            Else
                If rbtn_SYORI_KBN2.Checked Then
                    '再発行
                    wWHERE &= "  AND KOFU.SYORI_JOKYO = 2 "
                    'wWHERE &= "  AND KOFU.FURIKOMI_YOTEI_DATE IS NOT NULL"
                Else
                    '修正発行
                    wWHERE &= "  AND KOFU.SYORI_JOKYO = 2 "
                    'wWHERE &= "  AND KOFU.FURIKOMI_YOTEI_DATE IS NOT NULL"
                End If
            End If

            '契約者
            If cbo_KEIYAKUSYA_CD_F.Text.Trim <> "" AndAlso cbo_KEIYAKUSYA_CD_T.Text.Trim <> "" Then
                wWHERE &= "  AND KOFU.KEIYAKUSYA_CD BETWEEN " & cbo_KEIYAKUSYA_CD_F.Text.Trim & " AND " & cbo_KEIYAKUSYA_CD_T.Text.Trim
            End If
            '事務委託先
            wWHERE += "  AND KOFU.KI = KYK.KI(+)"
            wWHERE += "  AND KOFU.KEIYAKUSYA_CD = KYK.KEIYAKUSYA_CD(+)"
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

            Using wkAdp As New OracleDataAdapter(wSql, Cnn)
                wkAdp.Fill(wkDSRep, wkDSRep.Tables(0).TableName)
            End Using

            If wkDSRep.Tables(0).Rows.Count > 0 Then

                'Using wkAR As New rptGJ4050
                '処理区分
                If rbtn_SYORI_KBN1.Checked Then
                    pSyoriKbn = 1
                ElseIf rbtn_SYORI_KBN1.Checked Then
                    pSyoriKbn = 2
                Else
                    pSyoriKbn = 3
                End If
                Dim w As New rptGJ4050
                w.sub1(wkDSRep, pSyoriKbn)
                '    'ヘッダ用の値を保管
                '    wkAR.pKikin2 = pKikin2      '2017/09/08　追加
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

            wSql = ""
            wSql &= "SELECT"
            wSql &= "      KOFU.KI AS KI"
            wSql &= "     ,KOFU.HASSEI_KAISU AS HASSEI_KAISU"
            wSql &= "     ,KOFU.KEISAN_KAISU AS KEISAN_KAISU"
            wSql &= "     ,TRIM(TO_CHAR(KOFU.KEIYAKUSYA_CD,'00000')) KEIYAKUSYA_CD"
            wSql &= "     ,NOJO.MEISAI_NO AS MEISAI_NO"
            wSql &= "     ,'〒' || SUBSTR(KYK.ADDR_POST,1,3) || '-' ||SUBSTR(KYK.ADDR_POST,4,4) KYK_POST"
            wSql &= "     ,RTRIM(KYK.ADDR_1) || RTRIM(KYK.ADDR_2) KYK_ADDR1"
            wSql &= "     ,KYK.ADDR_3 KYK_ADDR2"
            wSql &= "     ,KYK.ADDR_4 KYK_ADDR3"
            wSql &= "     ,CASE"
            wSql &= "        WHEN KYK.DAIHYO_NAME IS NULL THEN KYK.KEIYAKUSYA_NAME || '様'"
            wSql &= "        ELSE KYK.KEIYAKUSYA_NAME"
            wSql &= "      END KYK_KEIYAKUSYA_NAME"
            wSql &= "     ,CASE"
            wSql &= "         WHEN KYK.DAIHYO_NAME IS NULL THEN NULL"
            'wSql &= "         ELSE KYK.DAIHYO_NAME || '様'"
            wSql &= "         ELSE '　' || KYK.DAIHYO_NAME || '様'"
            wSql &= "      END KYK_DAIHYO_NAME"
            wSql &= "     ,'(' || TRIM(TO_CHAR(KYK.KEIYAKUSYA_CD,'00000')) || ')' KEIYAKUSYA_CD_KAKKO"

            wSql &= "     ,KYO.HAKKO_NO_KANJI AS HAKKO_NO_KANJI"
            If rbtn_SYORI_KBN1.Checked OrElse rbtn_SYORI_KBN3.Checked Then
                wSql &= "     ,TO_MULTI_BYTE(TO_CHAR(TO_DATE('" & Format(date_FURI_YOTEI_DATE.Value, "yyyy/MM/dd") & "'), 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''')) AS FURI_YOTEI_DATE"
                wSql &= "     ,TO_CHAR(TO_DATE('" & Format(date_HAKKO_DATE.Value, "yyyy/MM/dd") & "'), 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS HAKKO_DATE"
                wSql &= "     ,KYO.HAKKO_NO_KANJI || '" & txt_HAKKO_NO_NEN.Text.Trim & "' || '発第" & txt_HAKKO_NO_RENBAN.Text.Trim & "号' AS HAKKO_NO"
            Else
                wSql &= "     ,TO_MULTI_BYTE(TO_CHAR(KOFU.FURIKOMI_YOTEI_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''')) AS FURI_YOTEI_DATE"
                wSql &= "     ,TO_CHAR(KOFU.KOFUTUTI_HAKKO_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS HAKKO_DATE"
                wSql &= "     ,KYO.HAKKO_NO_KANJI || KOFU.KOFUTUTI_HAKKO_NO_NEN || '発第' || KOFU.KOFUTUTI_HAKKO_NO_RENBAN || '号' AS HAKKO_NO"
            End If

            wSql &= "     ,KYO.KYOKAI_NAME AS KYO_KYOKAI_NAME"
            wSql &= "     ,KYO.YAKUMEI AS KYO_YAKUMEI"
            wSql &= "     ,KYO.KAICHO_NAME AS KYO_KAICHO_NAME"
            wSql &= "     ,KYO.ADDR1  || ADDR2 AS KYO_ADDR"
            wSql &= "     ,'ＴＥＬ' || KYO.TEL1 AS KYO_TEL1"
            wSql &= "     ,'ＦＡＸ' || KYO.FAX1 AS KYO_FAX1"

            wSql &= "     ,SIN.SINSEI_DATE"
            wSql &= "     ,'　' || TO_MULTI_BYTE(TO_CHAR(SIN.SINSEI_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''')) "
            wSql &= "       || '付けで申請のあった、家畜防疫互助金について家畜防疫互助基金支' || CHR(13) || CHR(10)|| '援事業実施要綱に基づき、下記のとおり確定しました。つきましては、交付金額を下記の金融' || CHR(13) || CHR(10)|| '機関に振込みますので通知いたします。'"
            wSql &= "      AS BODY1"
            wSql &= "     ,KYK.KEIYAKU_KBN AS KEIYAKU_KBN"
            'wSql &= "     ,CD01.RYAKUSYO AS KEIYAKU_KBN_NM"    '2017/07/26　修正
            wSql &= "     ,CD01.MEISYO AS KEIYAKU_KBN_NM"       '2017/07/26　修正
            wSql &= "     ,KOFU.KOFU_KIN_KEI AS KOFU_KIN_KEI"
            'wSql &= "     ,TO_MULTI_BYTE(TO_CHAR(KOFU.KOFU_KIN_KEI,'99G999G999G999')) || '円' AS KOFU_KIN_KEI"

            wSql &= "     ,KYK.FURI_BANK_CD AS FURI_BANK_CD"
            wSql &= "     ,BANK.BANK_NAME AS FURI_BANK_CD_NM"
            wSql &= "     ,KYK.FURI_BANK_SITEN_CD AS FURI_BANK_SITEN_CD"
            wSql &= "     ,SITEN.SITEN_NAME AS FURI_BANK_SITEN_CD_NM"
            wSql &= "     ,KYK.FURI_KOZA_SYUBETU AS FURI_KOZA_SYUBETU"
            wSql &= "     ,CD04.MEISYO AS FURI_KOZA_SYUBETU_NM"
            wSql &= "     ,KYK.FURI_KOZA_NO AS FURI_KOZA_NO"
            wSql &= "     ,KYK.FURI_KOZA_MEIGI AS FURI_KOZA_MEIGI"
            wSql &= "     ,KYK.FURI_KOZA_MEIGI_KANA AS FURI_KOZA_MEIGI_KANA"

            wSql &= "     ,COUNT(KOFU.KEIYAKUSYA_CD) OVER (PARTITION BY KOFU.KEIYAKUSYA_CD) AS DTL_CNT"
            wSql &= "     ,ROW_NUMBER() OVER (PARTITION BY KOFU.KEIYAKUSYA_CD ORDER BY KOFU.KEIYAKUSYA_CD,NOJO.MEISAI_NO,SIN.TORI_KBN,SIN.GOJOKIN_SYURUI_KBN) AS DTL_RENBAN"
            wSql &= "     ,SIN.NOJO_CD AS NOJO_CD"
            wSql &= "     ,NOJO.NOJO_NAME AS NOJO_NAME"
            wSql &= "     ,SIN.TORI_KBN AS TORI_KBN"
            wSql &= "     ,CD07.MEISYO AS TORI_KBN_NM"
            wSql &= "     ,SIN.GOJOKIN_SYURUI_KBN"
            '--    ,CD03.RYAKUSYO AS GOJOKIN_SYURUI_KBN_NM
            wSql &= "     ,CD03.MEISYO AS GOJOKIN_SYURUI_KBN_NM"
            wSql &= "     ,SIN.KOFU_HASU AS KOFU_HASU"
            wSql &= "     ,'(' || TO_CHAR(SIN.KOFU_TANKA,'9G999') || ')' AS KOFU_TANKA "
            wSql &= "     ,SIN.SEI_TUMITATE_KIN AS SEI_TUMITATE_KIN"
            wSql &= "     ,SIN.KUNI_KOFU_KIN AS KUNI_KOFU_KIN"
            wSql &= "     ,SIN.KOFU_KIN AS KOFU_KIN"

            wSql &= "     ,KYK.JIMUITAKU_CD AS JIMUITAKU_CD "
            wSql &= "     ,CASE "
            wSql &= "         WHEN KYK.JIMUITAKU_CD = 0 OR KYK.JIMUITAKU_CD=999 THEN NULL"
            wSql &= "         ELSE '事務委託先名：' || ITK.ITAKU_NAME"
            wSql &= "      END ITAKU_NAME"
            wSql &= "     ,ITK.BANK_INJI_KBN AS BANK_INJI_KBN"
            wSql &= " FROM TT_KOFU KOFU"
            wSql &= "     ,TT_KOFU_SINSEI SIN"
            wSql &= "     ,TM_KEIYAKU KYK"
            wSql &= "     ,TM_KEIYAKU_NOJO NOJO"
            wSql &= "     ,TM_KYOKAI KYO"
            wSql &= "     ,TM_JIMUITAKU ITK"
            wSql &= "     ,TM_BANK BANK"
            wSql &= "     ,TM_SITEN SITEN"
            wSql &= "     ,TM_CODE CD01"
            wSql &= "     ,TM_CODE CD03"
            wSql &= "     ,TM_CODE CD04"
            wSql &= "     ,TM_CODE CD07"


            wSql &= " WHERE"
            '          -- 交付申請
            wSql &= "      KOFU.KI = SIN.KI(+) "
            wSql &= "  AND KOFU.HASSEI_KAISU = SIN.HASSEI_KAISU(+) "
            wSql &= "  AND KOFU.KEISAN_KAISU = SIN.KEISAN_KAISU(+) "
            wSql &= "  AND KOFU.KEIYAKUSYA_CD = SIN.KEIYAKUSYA_CD(+) "
            '          -- 契約者マスタ
            wSql &= "  AND KOFU.KI = KYK.KI(+)"
            wSql &= "  AND KOFU.KEIYAKUSYA_CD = KYK.KEIYAKUSYA_CD(+)"
            '          -- 契約者農場マスタ
            wSql &= "  AND SIN.KI = NOJO.KI(+)"
            wSql &= "  AND SIN.KEIYAKUSYA_CD = NOJO.KEIYAKUSYA_CD(+)"
            wSql &= "  AND SIN.NOJO_CD = NOJO.NOJO_CD(+)"
            '          -- 協会マスタ
            wSql &= "  AND 1 = KYO.KYOKAI_KBN(+)"
            '          -- 事務委託先マスタ
            wSql &= "  AND KYK.KI = ITK.KI(+)"
            wSql &= "  AND KYK.JIMUITAKU_CD = ITK.ITAKU_CD(+)"
            '          -- 金融機関マスタ
            wSql &= "  AND KYK.FURI_BANK_CD = BANK.BANK_CD(+)"
            '          -- 金融機関支店マスタ
            wSql &= "  AND KYK.FURI_BANK_CD = SITEN.BANK_CD(+)"
            wSql &= "  AND KYK.FURI_BANK_SITEN_CD = SITEN.SITEN_CD(+)"
            '          -- 契約区分
            wSql &= "  AND KYK.KEIYAKU_KBN = CD01.MEISYO_CD(+)"
            wSql &= "  AND 1 = CD01.SYURUI_KBN(+)"
            '          -- 互助金の種類
            wSql &= "  AND SIN.GOJOKIN_SYURUI_KBN = CD03.MEISYO_CD(+)"
            wSql &= "  AND 3 = CD03.SYURUI_KBN(+)"
            '          -- 口座種別
            wSql &= "  AND KYK.FURI_KOZA_SYUBETU = CD04.MEISYO_CD(+)"
            wSql &= "  AND 4 = CD04.SYURUI_KBN(+)"
            '          -- 鶏の種類
            wSql &= "  AND SIN.TORI_KBN = CD07.MEISYO_CD(+)"
            wSql &= "  AND 7 = CD07.SYURUI_KBN(+)"


            '          -- 条件
            wSql &= "  AND KOFU.KI = " & txt_KI.Text.Trim
            wSql &= "  AND KOFU.HASSEI_KAISU = " & txt_HASSEI_KAISU.Text.Trim
            wSql &= "  AND KOFU.KEISAN_KAISU = " & txt_KEISAN_KAISU.Text.Trim

            '処理状況・振込予定日
            If rbtn_SYORI_KBN1.Checked Then
                '初回発行
                wSql &= "  AND KOFU.SYORI_JOKYO = 1"
                'wSql &= "  AND KOFU.FURIKOMI_YOTEI_DATE IS NULL"
            Else
                If rbtn_SYORI_KBN2.Checked Then
                    '再発行
                    wSql &= "  AND KOFU.SYORI_JOKYO = 2"
                    'wSql &= "  AND KOFU.FURIKOMI_YOTEI_DATE IS NOT NULL"
                Else
                    '修正発行
                    wSql &= "  AND KOFU.SYORI_JOKYO = 2 "
                    'wSql &= "  AND KOFU.FURIKOMI_YOTEI_DATE IS NOT NULL"
                End If
            End If

            '契約者
            If cbo_KEIYAKUSYA_CD_F.Text.Trim <> "" AndAlso cbo_KEIYAKUSYA_CD_T.Text.Trim <> "" Then
                wSql &= "  AND KOFU.KEIYAKUSYA_CD BETWEEN " & cbo_KEIYAKUSYA_CD_F.Text.Trim & " AND " & cbo_KEIYAKUSYA_CD_T.Text.Trim
            End If
            '事務委託先
            If cbo_JIMUITAKU_CD_F.Text.Trim <> "" AndAlso cbo_JIMUITAKU_CD_T.Text.Trim <> "" Then
                wSql &= "  AND KYK.JIMUITAKU_CD BETWEEN " & cbo_JIMUITAKU_CD_F.Text.Trim & " AND " & cbo_JIMUITAKU_CD_T.Text.Trim
            End If


            wSql &= " ORDER BY"
            wSql &= "     KOFU.KI"
            wSql &= "    ,KOFU.KEIYAKUSYA_CD"
            wSql &= "    ,NOJO.MEISAI_NO"
            wSql &= "    ,SIN.TORI_KBN"
            wSql &= "    ,SIN.GOJOKIN_SYURUI_KBN"


            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#End Region


End Class
