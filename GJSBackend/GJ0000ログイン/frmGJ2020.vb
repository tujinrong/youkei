'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ2020.vb
'*
'*　　②　機能概要　　　　　契約者積立金金計算
'*
'*　　③　作成日　　　　　　2015/02/12  BY JBD
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

Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.ActiveReports.Export
Imports GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport

Imports System.IO

Public Class frmGJ2020

#Region "*** 変数定義 ***"

    Private pGridDataSet As New DataSet                 'マスタグリッド用データセット
    Private pDataSet As New DataSet                     'マスタ用データセット
    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ
    Private pblnErrDsp As Boolean                       'コンボ　エラー表示

    Private pTUMITATE_TANKA_INV As Integer              '積立単価マスタ有無 0:有り 1:無し


    ''' <summary>
    '''  プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True
    Private pJIGYO_KAISU_DATE As Date       '事業開始日
    Private pJIGYO_SYURYO_DATE As Date      '事業終了日
    Private pHENKAN_KEISAN_DATE As Date     '返還計算日

    '期
    Private pInitKi As String               '期(初期値)
    Private pEnterKi As String              '期(入力値)
    Private pEnterKaisu As String           '回数(入力値)

    '単価マスタ
    Private pTESURYO_RITU As Double         '手数料率

    '積立計算
    Private pSEIKYU_KAISU As Integer        '請求回数
    Private pSEIKYU_DATE As Date            '請求日
    Private pKIGEN_DATE As Date             '納付期限
    Private pFURIKOMI_YOTEI_DATE As Date    '振込予定日

#End Region

#Region "*** 画面制御関連 ***"

#Region "frmFS2020_Load Form_Loadイベント"

    Private Property wUpd_KEIYAKU_DATE As Object

    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ2020_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ2020_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean

        Try

            '処理年度・期　取得
            Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

            '初期値取得
            pJIGYO_KAISU_DATE = clsNENDO_KI.pJIGYO_NENDO_byDate         '事業開始日
            pJIGYO_SYURYO_DATE = clsNENDO_KI.pJIGYO_SYURYO_NENDO_byDate '事業最終日
            pHENKAN_KEISAN_DATE = clsNENDO_KI.pHENKAN_KEISAN_DATE       '返還計算日
            pInitKi = clsNENDO_KI.pKI                                   '当期

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
#Region "frmGJ2020_Disposed Form_Disposedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ2020_Disposed
    '説明            :Form_Disposedイベント
    '------------------------------------------------------------------
    Private Sub frmGJ2020_Disposed(ByVal sender As Object, ByVal e As System.EventArgs)

        pDataSet.Clear()
        pDataSet.Dispose()

    End Sub

#End Region

#End Region

#Region "*** 画面ボタンクリック関連 ***"

#Region "cmdSav_Click 保存ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSav_Click
    '説明            :保存ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSav.Click
        Dim wKi As Integer = 0
        Dim wKaisu As Integer = 0

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '入力項目チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '保存処理確認
            If rbtn_SYORI_KBN1.Checked Then
                If Show_MessageBox_Add("Q009", "請求・返還") = DialogResult.No Then    '@0処理を行いますか？
                    '「キャンセル」を選択
                    Exit Try
                End If
            Else
                If Show_MessageBox_Add("Q009", "請求・返還取消") = DialogResult.No Then    '@0処理を行いますか？
                    '「キャンセル」を選択
                    Exit Try
                End If
            End If

            'データ保存
            If Not f_Save() Then
                Exit Try
            End If

            'グリッド　再表示
            f_GridView_Set("", txt_KI.Text, txt_SEIKYU_KAISU.Text)

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
    '注意            :rbtn_SYORI_KBN1とrbtn_SYORI_KBN2のイベントを一度に判定すると、
    '               　処理が２回実行される(ラジオボタンの処理は、ボタン毎に分ける)　
    '------------------------------------------------------------------
    Private Sub rbtn_SYORI_KBN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
                rbtn_SYORI_KBN1.CheckedChanged, rbtn_SYORI_KBN2.CheckedChanged

        Try
            If pJump Then
                Exit Try
            End If

            '1:請求 2:取消 3:頭数集計
            If sender.NAME.ToString = "rbtn_SYORI_KBN1" And rbtn_SYORI_KBN1.Checked Then
                '積立金請求計算履歴の内容表示
                If Not f_Joken_Set1() Then
                    Exit Try
                End If
            Else
                If sender.NAME.ToString = "rbtn_SYORI_KBN2" And rbtn_SYORI_KBN2.Checked Then
                    '積立金請求計算履歴の内容表示
                    If Not f_Joken_Set2() Then
                        Exit Try
                    End If
                End If
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub
#End Region

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

            '未入力のとき、契約者コンボ、グリッドクリア
            If txt_KI.Text = "" Then
                '2015/03/03 JBD368 UPD ↓↓↓ DataSourceへ変更に伴い、初期化方法変更
                'cob_KEIYAKUSYA_CD1.Items.Clear()
                'cob_KEIYAKUSYA_NM1.Items.Clear()
                cob_KEIYAKUSYA_CD1.DataSource = Nothing
                cob_KEIYAKUSYA_CD1.Clear()
                cob_KEIYAKUSYA_NM1.DataSource = Nothing
                cob_KEIYAKUSYA_NM1.Clear()
                '2015/03/03 JBD368 UPD ↑↑↑

                If Not (dgv_Search.DataSource Is Nothing) Then
                    pGridDataSet.Clear()
                End If
                Exit Try
            End If

            '期が変更になった場合、契約者コンボ再セット
            If pEnterKi = "" OrElse _
               CInt(txt_KI.Text) <> CInt(pEnterKi) Then
                ret = f_ComboBox_Set(txt_KI.Text.Trim.ToString)
                '積立金請求計算履歴の内容表示
                If rbtn_SYORI_KBN1.Checked Then
                    If Not f_Joken_Set1() Then
                        Exit Try
                    End If
                Else
                    If rbtn_SYORI_KBN2.Checked Then
                        If Not f_Joken_Set2() Then
                            Exit Try
                        End If
                    End If
                End If
                f_GridView_Set("C", 0, 0)
            End If


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#Region "請求回数"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_KI_Enter
    '説明            :期Enterイベント
    '------------------------------------------------------------------
    Private Sub txt_SEIKYU_KAISU_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txt_SEIKYU_KAISU.Enter

        pEnterKaisu = txt_SEIKYU_KAISU.Text

    End Sub
    '------------------------------------------------------------------
    'プロシージャ名  :txt_SEIKYU_KAISU_Validated
    '説明            :請求回数Validatedイベント
    '------------------------------------------------------------------    
    Private Sub txt_SEIKYU_KAISU_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_SEIKYU_KAISU.Validated
        Dim wSql As String = String.Empty
        Dim wDs As New DataSet
        Dim wBlnOk As Boolean = False

        Try

            '期・回数　未入力
            If txt_KI.Text.Trim = "" OrElse
               txt_SEIKYU_KAISU.Text.Trim = "" Then
                '請求日
                date_SEIKYU_DATE.Value = pSEIKYU_DATE
                '納付期限
                date_NOFUKIGEN_DATE.Value = pKIGEN_DATE
                '振込予定日
                date_FURIKOMI_YOTEI_DATE.Value = pFURIKOMI_YOTEI_DATE
                '契約番号
                cob_KEIYAKUSYA_CD1.SelectedIndex = -1
                Exit Try
            End If

            '積立金請求計算履歴読込
            f_TUMITATE_KEISAN_Select(wBlnOk, 1)

            If wBlnOk Then
                '積立金請求計算履歴より
                '回数セット
                txt_SEIKYU_KAISU.Text = pSEIKYU_KAISU
                '請求日
                date_SEIKYU_DATE.Value = pSEIKYU_DATE
                '納付期限
                date_NOFUKIGEN_DATE.Value = pKIGEN_DATE
                '振込予定日
                date_FURIKOMI_YOTEI_DATE.Value = pFURIKOMI_YOTEI_DATE
                '契約番号
                cob_KEIYAKUSYA_CD1.SelectedIndex = -1
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub
#End Region

#Region "請求年月日　Validatedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :date_SEIKYU_DATE_Validated
    '説明            :請求年月日　Validated
    '------------------------------------------------------------------
    Private Sub date_SEIKYU_DATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles date_SEIKYU_DATE.Validated
        Dim wOk As Boolean = False

        Try

            'エラー入力のとき、未入力に戻す
            If date_SEIKYU_DATE.Value Is Nothing Then
                date_SEIKYU_DATE.Text = ""
                Exit Try
            End If

            '手数料率　取得
            f_TUMITATE_TANKA_Select(wOk)
            If wOk Then
                lbl_TESURYO_RITU.Text = pTESURYO_RITU
            Else
                lbl_TESURYO_RITU.Text = ""
            End If


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region
#Region "納付期限　Validatedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :date_KIGEN_DATEE_Validated
    '説明            :納付期限　Validated
    '------------------------------------------------------------------
    Private Sub date_KIGEN_DATEE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles date_NOFUKIGEN_DATE.Validated

        Try

            'エラー入力のとき、未入力に戻す
            If date_NOFUKIGEN_DATE.Value Is Nothing Then
                date_NOFUKIGEN_DATE.Text = ""
                Exit Try
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region
#Region "振込予定日　Validatedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :date_FURIKOMI_YOTEI_DATE_Validated
    '説明            :振込予定日　Validated
    '------------------------------------------------------------------
    Private Sub date_FURIKOMI_YOTEI_DATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles date_FURIKOMI_YOTEI_DATE.Validated

        Try

            'エラー入力のとき、未入力に戻す
            If date_FURIKOMI_YOTEI_DATE.Value Is Nothing Then
                date_FURIKOMI_YOTEI_DATE.Text = ""
                Exit Try
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#Region "契約者"
    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEIYAKUSYA_CD1_SelectedIndexChanged
    '説明            :契約者コードChanegeイベント
    '------------------------------------------------------------------
    Private Sub cob_KEIYAKUSYA_CD1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEIYAKUSYA_CD1.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEIYAKUSYA_NM1.SelectedIndex = cob_KEIYAKUSYA_CD1.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEIYAKUSYA_NM1_SelectedIndexChanged
    '説明            :契約者名Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cob_KEIYAKUSYA_NM1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEIYAKUSYA_NM1.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEIYAKUSYA_CD1.SelectedIndex = cob_KEIYAKUSYA_NM1.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEIYAKUSYA_CD1_Validating
    '説明            :契約者コード_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cob_KEIYAKUSYA_CD1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_KEIYAKUSYA_CD1.Validating

        If cob_KEIYAKUSYA_CD1.Text = "" Then
            Exit Sub
        End If

        '2015/03/03 JBD368 UPD ↓↓↓ 値の設定方法を変更
        'cob_KEIYAKUSYA_CD1.SelectedValue = cob_KEIYAKUSYA_CD1.Text
        cob_KEIYAKUSYA_CD1.SelectedValue = CDec(cob_KEIYAKUSYA_CD1.Text)
        '2015/03/03 JBD368 UPD ↑↑↑
        If cob_KEIYAKUSYA_CD1.SelectedValue Is Nothing Then
            cob_KEIYAKUSYA_CD1.SelectedIndex = -1
            cob_KEIYAKUSYA_NM1.SelectedIndex = -1
            Show_MessageBox_Add("W012", "契約者") '指定された@0が正しくありません。
            cob_KEIYAKUSYA_CD1.Focus()
        End If

    End Sub

#End Region

#End Region

#Region "*** データ登録関連 ***"
#Region "f_Save 請求データ更新"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Save
    '説明            :使用者マスタデータ更新
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Save() As Boolean
        Dim ret As Boolean = False
        Dim Cmd As New OracleCommand
        '請求返還区分
        Dim wSeikyuHenkoKbn As String = String.Empty
        '計算結果
        Dim wSEIKYU_TAISYO_SYASU As Long
        Dim wTUMITATE_KINGAKU As Long
        Dim wCYOSYU_KINGAKU As Long
        Dim wHENKAN_KINGAKU As Long

        Try

            '請求変更
            If rbtn_SYORI_KBN1.Checked Then
                '請求返還区分
                If Not f_SEIKYU_HENKO_KBN(wSeikyuHenkoKbn) Then
                    Exit Try
                End If
            End If

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            '処理区分
            If rbtn_SYORI_KBN1.Checked Then
                Cmd.CommandText = "PKG_GJ2020.GJ2020_KEISAN"
            Else
                Cmd.CommandText = "PKG_GJ2020.GJ2020_TORIKESI"
            End If

            '--------------------
            '請求
            '--------------------
            '期
            Cmd.Parameters.Add("IN_KI", txt_KI.Text.Trim)
            '回数
            Cmd.Parameters.Add("IN_SEIKYU_KAISU", CInt(txt_SEIKYU_KAISU.Text))

            '計算のときのみ
            If rbtn_SYORI_KBN1.Checked Then
                '請求新規
                If chk_SEIKYU_HENKAN_KBN1.Checked Then
                    Cmd.Parameters.Add("IN_SEIKYU_HENKAN_KBN1", 1)
                Else
                    Cmd.Parameters.Add("IN_SEIKYU_HENKAN_KBN1", 0)
                End If
                '請求兼返還(徴収)
                If chk_SEIKYU_HENKAN_KBN2.Checked Then
                    Cmd.Parameters.Add("IN_SEIKYU_HENKAN_KBN2", 1)
                Else
                    Cmd.Parameters.Add("IN_SEIKYU_HENKAN_KBN2", 0)
                End If
                '請求兼返還(返還)
                If chk_SEIKYU_HENKAN_KBN3.Checked Then
                    Cmd.Parameters.Add("IN_SEIKYU_HENKAN_KBN3", 1)
                Else
                    Cmd.Parameters.Add("IN_SEIKYU_HENKAN_KBN3", 0)
                End If
                '全額返還
                If chk_SEIKYU_HENKAN_KBN4.Checked Then
                    Cmd.Parameters.Add("IN_SEIKYU_HENKAN_KBN4", 1)
                Else
                    Cmd.Parameters.Add("IN_SEIKYU_HENKAN_KBN4", 0)
                End If
                '徴収・返還区分
                Cmd.Parameters.Add("IN_SEIKYU_HENKAN_KBN", wSeikyuHenkoKbn)
                '手数料率
                Cmd.Parameters.Add("IN_TESURYO_RITU", lbl_TESURYO_RITU.Text.Trim)

                '請求日
                Cmd.Parameters.Add("IN_SEIKYU_DATE", f_DateTrim(date_SEIKYU_DATE.Value))
                '納付期限
                Cmd.Parameters.Add("IN_NOFUKIGEN_DATE", f_DateTrim(date_NOFUKIGEN_DATE.Value))
                '振込予定日
                Cmd.Parameters.Add("IN_FURIKOMI_YOTEI_DATE", f_DateTrim(date_FURIKOMI_YOTEI_DATE.Value))
            End If

            '契約番号
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", cob_KEIYAKUSYA_CD1.Text.Trim)

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
            Dim p_SEIKYU_TAISYO_SYASU As OracleParameter = Cmd.Parameters.Add("OU_SEIKYU_TAISYO_SYASU", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_TUMITATE_KINGAKU As OracleParameter = Cmd.Parameters.Add("OU_TUMITATE_KINGAKU", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_CYOSYU_KINGAKU As OracleParameter = Cmd.Parameters.Add("OU_CYOSYU_KINGAKU", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_HENKAN_KINGAKU As OracleParameter = Cmd.Parameters.Add("OU_HENKAN_KINGAKU", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            '--------------------
            '保存
            '--------------------
            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Throw New Exception(Cmd.Parameters("OU_MSGCD").Value.ToString() & ":" & Cmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            '結果表示   
            wSEIKYU_TAISYO_SYASU = CLng(Cmd.Parameters("OU_SEIKYU_TAISYO_SYASU").Value.ToString)
            wTUMITATE_KINGAKU = CLng(Cmd.Parameters("OU_TUMITATE_KINGAKU").Value.ToString)
            wCYOSYU_KINGAKU = CLng(Cmd.Parameters("OU_CYOSYU_KINGAKU").Value.ToString)
            wHENKAN_KINGAKU = CLng(Cmd.Parameters("OU_HENKAN_KINGAKU").Value.ToString)

            If rbtn_SYORI_KBN1.Checked Then
                Show_MessageBox_Add("I007", "請求・返還処理が終了しました" & vbCrLf & _
                                            "請求・返還対象者数 : " & Format(wSEIKYU_TAISYO_SYASU, "##,##0") & " 人" & vbCrLf & _
                                            "積立金等総額 : " & Format(wTUMITATE_KINGAKU, "###,###,##0").PadLeft(11) & " 円" & vbCrLf & _
                                            "徴収金額　　 : " & Format(wCYOSYU_KINGAKU, "###,###,##0").PadLeft(11) & " 円" & vbCrLf & _
                                            "返還金額　　 : " & Format(wHENKAN_KINGAKU, "###,###,##0").PadLeft(11) & " 円")
            Else
                Show_MessageBox_Add("I007", "請求・返還取消処理が終了しました" & vbCrLf & _
                                            "請求・返還対象者数 : " & Format(wSEIKYU_TAISYO_SYASU, "##,##0") & " 人" & vbCrLf & _
                                            "積立金等総額 : " & Format(wTUMITATE_KINGAKU, "###,###,##0").PadLeft(11) & " 円" & vbCrLf & _
                                            "徴収金額　　 : " & Format(wCYOSYU_KINGAKU, "###,###,##0").PadLeft(11) & " 円" & vbCrLf & _
                                            "返還金額　　 : " & Format(wHENKAN_KINGAKU, "###,###,##0").PadLeft(11) & " 円")
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

            'エラー非表示
            pJump = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '変数クリア
            pSEIKYU_KAISU = 0
            pSEIKYU_DATE = Nothing
            pKIGEN_DATE = Nothing
            pFURIKOMI_YOTEI_DATE = Nothing
            pTESURYO_RITU = 0

            '画面初期化
            Call f_ClearFormALL(Me, wKbn)

            '初回のみ
            'If wKbn = "C" OrElse txt_KI.Text <> pInitKi Then
            'コンボボックスセット
            If Not f_ComboBox_Set(pInitKi) Then
                Exit Try
            End If
            'End If

            '初期表示
            txt_KI.Text = pInitKi
            chk_SEIKYU_HENKAN_KBN1.Checked = True
            chk_SEIKYU_HENKAN_KBN2.Checked = True
            chk_SEIKYU_HENKAN_KBN3.Checked = True
            chk_SEIKYU_HENKAN_KBN4.Checked = True

            '画面内容をセット
            If Not f_SetForm_Data() Then
                Exit Try
            End If

            '請求処理へ
            rbtn_SYORI_KBN1.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'エラー表示
            pJump = False
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
    Private Function f_ComboBox_Set(ByVal wKi As String) As Boolean
        Dim wWhere As String = String.Empty
        Dim ret As Boolean = False

        Try

            '期が未入力のとき
            If wKi = "" OrElse wKi = String.Empty Then
                '2015/03/03 JBD368 UPD ↓↓↓ DataSourceへ変更に伴い、初期化方法変更
                'cob_KEIYAKUSYA_CD1.Items.Clear()
                'cob_KEIYAKUSYA_NM1.Items.Clear()
                cob_KEIYAKUSYA_CD1.DataSource = Nothing
                cob_KEIYAKUSYA_CD1.Clear()
                cob_KEIYAKUSYA_NM1.DataSource = Nothing
                cob_KEIYAKUSYA_NM1.Clear()
                '2015/03/03 JBD368 UPD ↑↑↑
                Exit Try
            End If

            '契約者マスタコンボセット(期:画面の期　契約状況:3(未継続者)除く)
            wWhere = "KI = " & wKi
            pJump = True    '2015/03/04　追加
            If Not f_Keiyaku_Data_Select(cob_KEIYAKUSYA_CD1, cob_KEIYAKUSYA_NM1, wWhere, True) Then
                Exit Try
            End If
            pJump = False   '2015/03/04　追加

            'コンボボックス初期化
            cob_KEIYAKUSYA_CD1.Text = ""

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
            '期　初期値
            txt_KI.Text = pInitKi

            '請求処理　条件セット
            If Not f_Joken_Set1() Then
                Exit Try
            End If

            'グリッドビューセット
            If Not f_GridView_Set("C", 0, 0) Then
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

#Region "f_Joken_Set1 請求処理　条件画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Joken_Set1
    '説明            :請求処理　条件画面セット
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_Joken_Set1() As Boolean
        Dim ret As Boolean = False
        Dim wBlnOk As Boolean = False

        Try

            '積立金請求計算履歴読込
            f_TUMITATE_KEISAN_Select(wBlnOk, 0)

            '回数セット
            If wBlnOk Then
                txt_SEIKYU_KAISU.Text = pSEIKYU_KAISU + 1
            Else
                txt_SEIKYU_KAISU.Text = ""
            End If

            'クリア
            '請求日
            date_SEIKYU_DATE.Value = Nothing
            '納付期限
            date_NOFUKIGEN_DATE.Value = Nothing
            '納付期限
            date_FURIKOMI_YOTEI_DATE.Value = Nothing
            '契約番号
            cob_KEIYAKUSYA_CD1.SelectedIndex = -1

            '単価セット
            f_TUMITATE_TANKA_Select(wBlnOk)

            If wBlnOk Then
                lbl_TESURYO_RITU.Text = pTESURYO_RITU.ToString
            Else
                lbl_TESURYO_RITU.Text = ""
            End If


            '入力制御
            txt_SEIKYU_KAISU.Enabled = False
            date_SEIKYU_DATE.Enabled = True
            date_NOFUKIGEN_DATE.Enabled = True
            date_FURIKOMI_YOTEI_DATE.Enabled = True

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_Joken_Set2 取消処理　条件画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Joken_Set2
    '説明            :取消処理　条件画面セット
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_Joken_Set2() As Boolean
        Dim ret As Boolean = False
        Dim wBlnOk As Boolean = False

        Try

            '積立金請求計算履歴読込
            f_TUMITATE_KEISAN_Select(wBlnOk, 0)

            If wBlnOk Then
                '積立金請求計算履歴より
                '回数セット
                txt_SEIKYU_KAISU.Text = pSEIKYU_KAISU
                '請求日
                date_SEIKYU_DATE.Value = pSEIKYU_DATE
                '納付期限
                date_NOFUKIGEN_DATE.Value = pKIGEN_DATE
                '振込予定日
                date_FURIKOMI_YOTEI_DATE.Value = pFURIKOMI_YOTEI_DATE
                '契約番号
                cob_KEIYAKUSYA_CD1.SelectedIndex = -1
            Else
                '画面クリア
                '回数セット
                txt_SEIKYU_KAISU.Text = ""
                '請求日
                date_SEIKYU_DATE.Value = Nothing
                '納付期限
                date_NOFUKIGEN_DATE.Value = Nothing
                '振込予定日
                date_FURIKOMI_YOTEI_DATE.Value = Nothing
                '契約番号
                cob_KEIYAKUSYA_CD1.SelectedIndex = -1
            End If

            '単価セット
            f_TUMITATE_TANKA_Select(wBlnOk)

            If wBlnOk Then
                lbl_TESURYO_RITU.Text = pTESURYO_RITU.ToString
            Else
                lbl_TESURYO_RITU.Text = ""
            End If

            '入力制御
            txt_SEIKYU_KAISU.Enabled = True
            date_SEIKYU_DATE.Enabled = False
            date_NOFUKIGEN_DATE.Enabled = False
            date_FURIKOMI_YOTEI_DATE.Enabled = False

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_TUMITATE_KEISAN_Select 積立金請求計算履歴取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TUMITATE_KEISAN_Select
    '説明            :積立金請求計算履歴取得
    '引数            :Boolean(データ有りTrue/データ無しFalse)
    '                :Integer(条件 0:期のみ　1:期+回数)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_TUMITATE_KEISAN_Select(ByRef wBlnOk As Boolean, ByVal wKbn As Integer) As Boolean
        Dim wSql As String = String.Empty
        Dim wDs As New DataSet
        Dim ret As Boolean = False
        Dim iHanki As Integer = 0

        Try

            wBlnOk = False
            pSEIKYU_KAISU = 0

            '対象年月　未入力
            If txt_KI.Text.Trim = "" Then
                ret = True
                Exit Try
            End If

            '積立金請求計算履歴 読込
            wSql = " SELECT "
            wSql += "  KI, SEIKYU_KAISU, SEIKYU_DATE, KIGEN_DATE, FURIKOMI_YOTEI_DATE"
            wSql += " FROM"
            wSql += "  TT_TUMITATE_KEISAN"
            wSql += " WHERE KI = " & txt_KI.Text.Trim
            '
            If wKbn = 1 Then
                wSql += " AND SEIKYU_KAISU = " & txt_SEIKYU_KAISU.Text.Trim
            End If
            wSql += " ORDER BY "
            wSql += "  SEIKYU_KAISU DESC"

            Call f_Select_ODP(wDs, wSql)

            '回数セーブ
            With wDs.Tables(0)
                If .Rows.Count = 0 Then
                    pSEIKYU_KAISU = 0
                    pSEIKYU_DATE = Nothing
                    pKIGEN_DATE = Nothing
                    pFURIKOMI_YOTEI_DATE = Nothing
                    '請求のときは、なくてもＯＫ
                    If rbtn_SYORI_KBN1.Checked Then
                        wBlnOk = True
                    End If
                Else
                    pSEIKYU_KAISU = WordHenkan("N", "Z", .Rows(0)("SEIKYU_KAISU"))
                    '請求日
                    If wDs.Tables(0).Rows(0)("SEIKYU_DATE") Is DBNull.Value Then
                        pSEIKYU_DATE = Nothing
                    Else
                        pSEIKYU_DATE = CDate(wDs.Tables(0).Rows(0)("SEIKYU_DATE"))
                    End If
                    '入金期限
                    If wDs.Tables(0).Rows(0)("KIGEN_DATE") Is DBNull.Value Then
                        pKIGEN_DATE = Nothing
                    Else
                        pKIGEN_DATE = CDate(wDs.Tables(0).Rows(0)("KIGEN_DATE"))
                    End If
                    '振込予定日
                    If wDs.Tables(0).Rows(0)("FURIKOMI_YOTEI_DATE") Is DBNull.Value Then
                        pFURIKOMI_YOTEI_DATE = Nothing
                    Else
                        pFURIKOMI_YOTEI_DATE = CDate(wDs.Tables(0).Rows(0)("FURIKOMI_YOTEI_DATE"))
                    End If
                    '正常
                    wBlnOk = True
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
#Region "f_TUMITATE_TANKA_Select 積立金等単価取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TUMITATE_TANKA_Select
    '説明            :積立金等単価取得
    '引数            :Boolean(データ有りTrue/データ無しFalse)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_TUMITATE_TANKA_Select(ByRef wBlnOk As Boolean) As Boolean
        Dim wSql As String = String.Empty
        Dim dstDataControl As New DataSet
        Dim ret As Boolean = False
        Dim iHanki As Integer = 0

        Try
            '初期化
            wBlnOk = False
            pTESURYO_RITU = 0
            pTUMITATE_TANKA_INV = 1

            '対象年月　未入力
            If date_SEIKYU_DATE.Value Is Nothing OrElse date_SEIKYU_DATE.Value = New Date Then
                ret = True
                Exit Try
            End If

            '積立金単価マスタ 読込
            wSql = " SELECT "
            wSql += "  TESURYO_RITU"
            wSql += " FROM"
            wSql += "  TM_TANKA"
            wSql += " WHERE TAISYO_DATE_FROM <= '" & Format(date_SEIKYU_DATE.Value, "yyyy/MM/dd") & "'"
            wSql += "   AND TAISYO_DATE_TO   >= '" & Format(date_SEIKYU_DATE.Value, "yyyy/MM/dd") & "'"
            wSql += "   AND KEIYAKU_KBN = 9"
            wSql += "   AND TORI_KBN = 9"

            Call f_Select_ODP(dstDataControl, wSql)

            '回数セーブ
            With dstDataControl.Tables(0)
                If .Rows.Count = 0 Then
                    pTUMITATE_TANKA_INV = 1
                    Exit Try
                Else
                    pTESURYO_RITU = CDbl(WordHenkan("N", "S", .Rows(0)("TESURYO_RITU")))
                    pTUMITATE_TANKA_INV = 0
                    wBlnOk = True
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
#Region "f_SYOHIZEIRITU_Select 消費税率取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SYOHIZEIRITU_Select
    '説明            :消費税率取得
    '引数            :Boolean(データ有りTrue/データ無しFalse)
    '戻り値          :Boolean(正常True/エラーFalse)
    '2023/08/09 JBD9020 R5インボイス対応 ADD
    '------------------------------------------------------------------
    Public Function f_SYOHIZEIRITU_Select(ByRef wBlnOk As Boolean) As Boolean

        Dim wSql As String = String.Empty
        Dim dstDataControl As New DataSet
        Dim ret As Boolean = False

        Try
            '初期化
            wBlnOk = False

            '対象年月　未入力
            If date_SEIKYU_DATE.Value Is Nothing OrElse date_SEIKYU_DATE.Value = New Date Then
                ret = True
                Exit Try
            End If

            '積立金単価マスタ 読込
            wSql = " SELECT "
            wSql += "  TAX_RITU"
            wSql += " FROM"
            wSql += "  TM_TAX"
            wSql += " WHERE TAX_DATE_FROM <= '" & Format(date_SEIKYU_DATE.Value, "yyyy/MM/dd") & "'"
            wSql += "   AND TAX_DATE_TO   >= '" & Format(date_SEIKYU_DATE.Value, "yyyy/MM/dd") & "'"

            Call f_Select_ODP(dstDataControl, wSql)

            '回数セーブ
            With dstDataControl.Tables(0)
                If .Rows.Count > 0 Then
                    wBlnOk = True
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

#Region "f_GridView_Set グリッドビューセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridView_Set
    '説明            :グリッドビューセット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_GridView_Set(ByVal wKbn As String, ByVal wKi As Integer, ByVal wKaisu As Integer) As Boolean
        Dim wSql As String = String.Empty
        Dim ret As Boolean = False
        Dim wBol As Boolean = False

        Try

            'グリッド　クリア
            If Not IsNothing(pGridDataSet) Then
                pGridDataSet.Clear()
            End If

            '期が未入力のとき、表示なし
            If txt_KI.Text = "" Then
                ret = True
                Exit Try
            End If

            '抽出条件
            wSql = " SELECT"
            wSql = wSql & " KEI.KI || '   ' KI,"
            wSql = wSql & " KEI.SEIKYU_KAISU,"
            wSql = wSql & " TO_CHAR(KEI.SYORI_DATE, 'YY/MM/DD','NLS_CALENDAR=''Japanese Imperial''') SYORI_DATE_X,"     '処理日
            wSql = wSql & " KEI.KEIYAKU_HENKO_KBN,"
            wSql = wSql & " M10.RYAKUSYO KEIYAKU_HENKO_KBN_NM,"
            wSql = wSql & " TO_CHAR(KEI.SEIKYU_DATE, 'YY/MM/DD','NLS_CALENDAR=''Japanese Imperial''') SEIKYU_DATE,"     '請求日
            wSql = wSql & " TO_CHAR(KEI.KIGEN_DATE,'YY/MM/DD','NLS_CALENDAR=''Japanese Imperial''') KIGEN_DATE,"        '納付期限
            wSql = wSql & " TO_CHAR(KEI.FURIKOMI_YOTEI_DATE,'YY/MM/DD','NLS_CALENDAR=''Japanese Imperial''') FURIKOMI_YOTEI_DATE,"  '振込予定日
            wSql = wSql & " TO_CHAR(KEI.SEIKYU_TAISYO_SYASU,'99,999')        || '    ' SEIKYU_TAISYO_SYASU,"    '請求対象者数
            wSql = wSql & " TO_CHAR(KEI.TUMITATE_KINGAKU,   '9,999,999,999') || '   ' TUMITATE_KINGAKU,"        '計算対象者数
            wSql = wSql & " TO_CHAR(KEI.CYOSYU_KINGAKU ,    '9,999,999,999') || '   ' CYOSYU_KINGAKU, "         '対象数量
            wSql = wSql & " TO_CHAR(KEI.HENKAN_KINGAKU ,    '9,999,999,999') || '   ' HENKAN_KINGAKU  "         '納付金額
            wSql = wSql & " FROM"
            wSql = wSql & " TT_TUMITATE_KEISAN KEI,"
            wSql = wSql & " TM_CODE M10"
            wSql = wSql & " WHERE KI = " & txt_KI.Text.Trim
            wSql = wSql & "   AND 10 = M10.SYURUI_KBN(+)"
            wSql = wSql & "   AND KEI.KEIYAKU_HENKO_KBN = M10.MEISYO_CD(+)"
            wSql = wSql & " ORDER BY"
            wSql = wSql & "   KEI.SEIKYU_KAISU DESC"

            'COM_NAME,
            If Not f_Select_ODP(pGridDataSet, wSql) Then
                Exit Try
            End If

            If pGridDataSet.Tables(0).Rows.Count > 0 Then

                '画面に該当データを表示
                dgv_Search.DataSource = pGridDataSet.Tables(0)

            End If

            '--------------------------------------------------
            '   グリッド表示位置
            '--------------------------------------------------
            If wKbn = "" Then
                wBol = f_GridReDisp(wKi, wKaisu)
            End If

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
    Private Function f_GridReDisp(ByVal wKi As Integer, ByVal wKaisu As Integer) As Boolean
        Dim ret As Boolean = False
        Dim blnHit As Boolean = False

        Try
            'グリッドに有効データあり
            If dgv_Search.RowCount <> 0 Then

                '更新対象のデータ　または　その次のデータに、カーソルをせっと
                For i As Integer = 0 To dgv_Search.RowCount - 1
                    '回数
                    If CInt(WordHenkan("N", "Z", dgv_Search.Item("SEIKYU_KAISU", i).Value)) <= wKaisu Then
                        'ブレーク
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

#Region "f_Input_Check 画面入力チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check
    '説明            :画面入力チェック処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check() As Boolean
        Dim wSql As String = String.Empty
        Dim dstDataControl As New DataSet
        Dim ret As Boolean = False
        Dim strMSG As String = String.Empty
        Dim obj As Object = Nothing
        Dim wBlnOk As Boolean

        Try
            '--------------------------------------------------
            '必須入力チェック
            '--------------------------------------------------

            '対象期
            If txt_KI.Text.Trim = "" Then
                Show_MessageBox_Add("W008", "対象期")      '@0は必須入力項目です。
                txt_KI.Focus()
                Exit Try
            End If

            '請求回数
            If txt_SEIKYU_KAISU.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "請求・返還回数")  '@0は必須入力項目です。
                txt_SEIKYU_KAISU.Focus()
                Exit Try
            End If

            '請求回数
            If txt_SEIKYU_KAISU.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "請求・返還回数")  '@0は必須入力項目です。
                txt_SEIKYU_KAISU.Focus()
                Exit Try
            End If

            '請求
            If rbtn_SYORI_KBN1.Checked Then
                '徴収・返還区分
                If chk_SEIKYU_HENKAN_KBN1.Checked OrElse chk_SEIKYU_HENKAN_KBN2.Checked OrElse _
                   chk_SEIKYU_HENKAN_KBN3.Checked OrElse chk_SEIKYU_HENKAN_KBN4.Checked Then
                Else
                    Show_MessageBox_Add("W008", "徴収・返還区分")  '@0は必須入力項目です。
                    chk_SEIKYU_HENKAN_KBN1.Focus()
                    Exit Try
                End If

                '請求・返還年月日
                If date_SEIKYU_DATE.Value Is Nothing Then
                    Show_MessageBox_Add("W008", "請求・返還年月日") '@0は必須入力項目です。
                    date_SEIKYU_DATE.Focus()
                    Exit Try
                End If
                '納付期限
                If date_NOFUKIGEN_DATE.Value Is Nothing Then
                    Show_MessageBox_Add("W008", "納付期限")         '@0は必須入力項目です。
                    date_NOFUKIGEN_DATE.Focus()
                    Exit Try
                End If
                '振込予定日
                If date_FURIKOMI_YOTEI_DATE.Value Is Nothing Then
                    Show_MessageBox_Add("W008", "振込予定日")        '@0は必須入力項目です。
                    date_FURIKOMI_YOTEI_DATE.Focus()
                    Exit Try
                End If
            End If

            '--------------------------------------------------
            '請求・取消対象　チェック
            '--------------------------------------------------
            If rbtn_SYORI_KBN1.Checked Then
                '請求チェック
                If Not f_SEIKYU_Chk(wBlnOk) Then
                    Exit Try
                End If
                'エラーあり
                If wBlnOk = False Then
                    rbtn_SYORI_KBN1.Focus()
                End If
            ElseIf rbtn_SYORI_KBN2.Checked Then
                '取消チェック
                If Not f_TORIKESHI_Chk(wBlnOk) Then
                    Exit Try
                End If
                'エラーあり
                If wBlnOk = False Then
                    rbtn_SYORI_KBN2.Focus()
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
#Region "f_SEIKYU_Chk 請求処理チェック"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SEIKYU_Chk
    '説明            :請求処理チェック
    '引数            :Boolean(エラー有りFalse/エラー無しTrue)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SEIKYU_Chk(ByRef wBlnOk As Boolean) As Boolean

        Dim wSql As String = String.Empty
        Dim dstDataControl As New DataSet
        Dim ret As Boolean = False
        Dim wOk As Boolean = False

        Try
            wBlnOk = False

            '返還金計算日　チェック
            If IsNothing(pHENKAN_KEISAN_DATE) OrElse pHENKAN_KEISAN_DATE = New Date Then
                Show_MessageBox_Add("I007", "返還金計算が実行されていません。") '@0
                cmdEnd.Focus()
                Exit Try
            End If

            '積立金単価　読込
            f_TUMITATE_TANKA_Select(wOk)
            If Not wOk Then
                Show_MessageBox_Add("W018", "手数料率") '@0が設定されていません。
                txt_KI.Focus()
                Exit Try
            End If

            '2023/08/09 JBD9020 R5インボイス対応 ADD START
            f_SYOHIZEIRITU_Select(wOk)
            If Not wOk Then
                Show_MessageBox_Add("W018", "消費税率") '@0が設定されていません。
                txt_KI.Focus()
                Exit Try
            End If
            '2023/08/09 JBD9020 R5インボイス対応 ADD END

            '積立金請求履歴(積立金)　読込(処理終了後に、画面クリアをしていないので、再度実行ボタンが押せる)
            wSql = " SELECT COUNT(KI)KENSU FROM TT_TUMITATE_KEISAN"
            wSql += " WHERE KI = " & txt_KI.Text.Trim
            wSql += "   AND SEIKYU_KAISU = " & txt_SEIKYU_KAISU.Text.Trim

            Call f_Select_ODP(dstDataControl, wSql)

            'エラー　チェック
            If CInt(WordHenkan("N", "Z", dstDataControl.Tables(0).Rows(0)("KENSU"))) <> 0 Then
                Show_MessageBox_Add("I007", "既に同一回数で請求処理が行われています") '@0
                Exit Try
            End If

            '契約者指定なし
            If cob_KEIYAKUSYA_CD1.Text.Trim = "" Then
                wBlnOk = True
                ret = True
                Exit Try
            End If

            '積立金請求入金(積立金)　読込
            wSql = " SELECT "
            wSql += "  COUNT(KI) KENSU "
            wSql += " FROM"
            wSql += "  TT_TUMITATE"
            wSql += " WHERE KI = " & txt_KI.Text.Trim
            wSql += "   AND KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD1.Text.Trim
            wSql += "   AND TUMITATE_KBN = 1"

            Call f_Select_ODP(dstDataControl, wSql)

            '請求回数チェック
            If CInt(WordHenkan("N", "Z", dstDataControl.Tables(0).Rows(0)("KENSU"))) <> 0 Then
                Show_MessageBox_Add("I007", "該当の契約者は、既に請求・返還処理が行われています")   '@0
                Exit Try
            End If

            wBlnOk = True
            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_TORIKESHI_Chk 取消処理チェック"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TORIKESHI_Chk
    '説明            :取消処理チェック
    '引数            :Boolean(エラー有りFalse/エラー無しTrue)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_TORIKESHI_Chk(ByRef wBool As Boolean) As Boolean

        Dim wSql As String = String.Empty
        Dim dstDataControl As New DataSet
        Dim ret As Boolean = False
        Dim sERR As String
        Dim wCHK As Boolean = False

        Try
            wBool = False

            '積立金請求入金DB　読込
            wSql = " SELECT "
            wSql += "  COUNT(KI) KENSU, " '請求件数
            wSql += "  SUM( CASE WHEN SYORI_JOKYO_KBN < 3 THEN 0 ELSE 1 END ) NYUKIN, "     '入金件数
            wSql += "  SUM( CASE WHEN KEIYAKU_HENKO_KBN = 0 THEN 0 ELSE 1 END ) ZOHA "      '新規以外の件数
            wSql += " FROM"
            wSql += "  TT_TUMITATE"
            wSql += " WHERE KI = " & txt_KI.Text.Trim
            wSql += "   AND SEIKYU_KAISU = " & txt_SEIKYU_KAISU.Text.Trim
            wSql += "   AND TUMITATE_KBN = 1"
            '契約者
            If cob_KEIYAKUSYA_CD1.Text.Trim <> "" Then
                wSql += "  AND KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD1.Text.Trim
            End If

            Call f_Select_ODP(dstDataControl, wSql)

            '請求処理チェック
            If dstDataControl.Tables(0).Rows.Count = 0 Then
                Show_MessageBox_Add("I007", "返還・請求処理がされていません") '@0
                Exit Try
            End If
            '人数チェック
            If CInt(WordHenkan("N", "Z", dstDataControl.Tables(0).Rows(0)("KENSU"))) = 0 Then
                Show_MessageBox_Add("I007", "返還・請求処理がされていません") '@0
                Exit Try
            End If
            '入金処理チェック
            If CInt(WordHenkan("N", "Z", dstDataControl.Tables(0).Rows(0)("NYUKIN"))) <> 0 Then
                sERR = Format(dstDataControl.Tables(0).Rows(0)("NYUKIN"), "###,##0")
                Show_MessageBox_Add("I007", "入金済が" & sERR & "人います。取消できません。") '入金済が99,999人います。取消できません。
                Exit Try
            End If
            '入金処理チェック
            If CInt(WordHenkan("N", "Z", dstDataControl.Tables(0).Rows(0)("ZOHA"))) <> 0 Then
                Show_MessageBox_Add("I007", "積立金計算処理で請求したデータではありません。") '@0
                Exit Try
            End If

            wBool = True
            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_SEIKYU_HENKO_KBN 請求変更区分条件"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SEIKYU_HENKO_KBN
    '説明            :請求変更区分条件
    '引数            :Boolean(エラー有りFalse/エラー無しTrue)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SEIKYU_HENKO_KBN(ByRef wStr As String) As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty

        Try

            wStr = ""
            '請求(新規)
            If chk_SEIKYU_HENKAN_KBN1.Checked Then
                wStr = "1"
            End If
            '請求(請求兼返還・徴収)　または　請求(請求兼返還・返還)
            If chk_SEIKYU_HENKAN_KBN2.Checked OrElse chk_SEIKYU_HENKAN_KBN3.Checked Then
                If wStr = "" Then
                    wStr = "2"
                Else
                    wStr &= ",2"
                End If
            End If
            '全額返還
            If chk_SEIKYU_HENKAN_KBN4.Checked Then
                If wStr = "" Then
                    wStr = "3"
                Else
                    wStr &= ",3"
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

#End Region

    Private Sub txt_KI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_KI.TextChanged

    End Sub
End Class
