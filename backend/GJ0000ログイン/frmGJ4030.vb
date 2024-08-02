'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ4030.vb
'*
'*　　②　機能概要　　　　　互助交付金計算処理
'*
'*　　③　作成日　　　　　　2015/03/04 BY JBD
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

Public Class frmGJ4030

#Region "*** 変数定義 ***"



    ''' <summary>
    '''  プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pGridDataSet As New DataSet     'マスタグリッド用データセット
    Private pDataSet As New DataSet         'マスタ用データセット
    Private pblnTextChange As Boolean       '画面入力内容変更フラグ
    Private pJump As Boolean = True         '処理ジャンプ

    '確定データ
    Private pKI As Integer                  '対象年度
    Private pHASSEI_KAISU As String         '発動回数
    Private pKEISAN_KAISU As Integer        '計算回数
    Private pFURI_YOTEI_DATE As Date        '振込予定日

    '期
    Private pInitKi As String               '期(初期値)
    Private pEnterKi As String              '期(入力値)
    '発生回数
    Private pInitHasseiKaisu As String      '発生回数(初期値)
    Private pEnterHasseiKaisu As String     '発生回数(入力値)


#End Region

#Region "*** 画面制御関連 ***"

#Region "frmGJ4030_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ4030_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ4030_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean

        Try
            '処理年度・期　取得
            Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI

            '初期値取得
            pInitKi = clsNENDO_KI.pKI                                   '当期
            pInitHasseiKaisu = clsNENDO_KI.pHASSEI_KAISU                '発生回数

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
#Region "frmGJ4030_Disposed Form_Disposedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ4030_Disposed
    '説明            :Form_Disposedイベント
    '------------------------------------------------------------------
    Private Sub frmGJ4030_Disposed(ByVal sender As Object, ByVal e As System.EventArgs)

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
        Dim ea As New System.ComponentModel.CancelEventArgs
        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '入力項目チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '保存処理確認
            If rbtn_SYORI_KBN1.Checked Then
                If Show_MessageBox_Add("Q009", "計算") = DialogResult.No Then    '@0処理を実行します。よろしいですか？
                    '「キャンセル」を選択
                    Exit Try
                End If
            Else
                If Show_MessageBox_Add("Q009", "計算取消") = DialogResult.No Then    '@0処理を実行します。よろしいですか？
                    '「キャンセル」を選択
                    Exit Try
                End If
            End If


            'データ保存
            If Not f_Save() Then
                Exit Try
            End If
            
            'グリッド　再表示
            f_GridView_Set("", 0, 0)

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

            '1:計算 2:取消
            If sender.NAME.ToString = "rbtn_SYORI_KBN1" And rbtn_SYORI_KBN1.Checked Then
                '補填奨励金計算履歴の内容表示
                If Not f_Joken_Set1() Then
                    Exit Try
                End If
            Else
                If sender.NAME.ToString = "rbtn_SYORI_KBN2" And rbtn_SYORI_KBN2.Checked Then
                    '補填奨励金計算履歴の内容表示
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
                cob_KEIYAKUSYA_CD.DataSource = Nothing
                cob_KEIYAKUSYA_CD.Clear()
                cob_KEIYAKUSYA_NM.DataSource = Nothing
                cob_KEIYAKUSYA_NM.Clear()

                If Not (dgv_Search.DataSource Is Nothing) Then
                    pGridDataSet.Clear()
                End If

                Exit Try
            End If

            '期が変更になった場合、契約者コンボ再セット
            If pEnterKi = "" OrElse _
               CInt(txt_KI.Text) <> CInt(pEnterKi) Then
                ret = f_ComboBox_Set(txt_KI.Text.Trim.ToString)
                txt_HASSEI_KAISU.Text = ""
                pHASSEI_KAISU = ""
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
#Region "発生回数"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_HASSEI_KAISU_Validated
    '説明            :発生回数Validatedイベント
    '------------------------------------------------------------------    
    Private Sub txt_HASSEI_KAISU_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_HASSEI_KAISU.Validated

        Try

            '期・発生回数　未入力
            If txt_KI.Text = "" Then
                Exit Try
            End If

            '発動回数セーブ
            If txt_HASSEI_KAISU.Text.Trim = "" Then

            End If
            pHASSEI_KAISU = txt_HASSEI_KAISU.Text.Trim

            '1:請求 2:取消
            If rbtn_SYORI_KBN1.Checked Then
                '補填奨励金計算履歴の内容表示
                If Not f_Joken_Set1() Then
                    Exit Try
                End If
            Else
                '補填奨励金計算履歴の内容表示
                If Not f_Joken_Set2() Then
                    Exit Try
                End If
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub
#End Region
#Region "計算回数"
    '------------------------------------------------------------------
    'プロシージャ名  :txt_KEISAN_KAISU_Validated
    '説明            :計算回数Validatedイベント
    '------------------------------------------------------------------    
    Private Sub txt_KEISAN_KAISU_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_KEISAN_KAISU.Validated

        Dim sSql As String = String.Empty
        Dim dstDataControl As New DataSet
        Dim iHanki As Integer = 0

        Try
            '期・回数　未入力
            If txt_KI.Text = "" OrElse
               txt_HASSEI_KAISU.Text.Trim = "" OrElse
               txt_KEISAN_KAISU.Text.Trim = "" Then
                pFURI_YOTEI_DATE = Nothing
                date_FURI_YOTEI_DATE.Text = ""
                Exit Try
            End If

            '交付金計算履歴 読込
            sSql = " SELECT "
            sSql += "  KI, HASSEI_KAISU, KEISAN_KAISU, FURI_YOTEI_DATE"
            sSql += " FROM"
            sSql += "  TT_KOFU_KEISAN"
            sSql += " WHERE KI = " & txt_KI.Text
            sSql += "   AND HASSEI_KAISU = " & txt_HASSEI_KAISU.Text.Trim
            sSql += "   AND KEISAN_KAISU = " & txt_KEISAN_KAISU.Text.Trim

            Call f_Select_ODP(dstDataControl, sSql)

            '回数セーブ
            With dstDataControl.Tables(0)
                If .Rows.Count = 0 Then
                    pKEISAN_KAISU = 0
                    pFURI_YOTEI_DATE = Nothing
                    date_FURI_YOTEI_DATE.Text = ""
                    Show_MessageBox("I002", "") '該当データが存在しませんでした。
                    txt_KEISAN_KAISU.Focus()
                Else
                    pKEISAN_KAISU = txt_KEISAN_KAISU.Text.Trim
                    pFURI_YOTEI_DATE = WordHenkan("N", "S", .Rows(0)("FURI_YOTEI_DATE"))
                    date_FURI_YOTEI_DATE.Value = pFURI_YOTEI_DATE
                End If
            End With

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub
#End Region

#Region "振込予定日　Validatedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :date_KIGEN_DATEE_Validated
    '説明            :振込予定日　Validated
    '------------------------------------------------------------------
    Private Sub date_YOTEI_DATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles date_FURI_YOTEI_DATE.Validated

        Dim wBool As Boolean = False

        Try

            'エラー入力のとき、未入力に戻す
            If date_FURI_YOTEI_DATE.Value Is Nothing Then
                date_FURI_YOTEI_DATE.Text = ""
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

        If cob_KEIYAKUSYA_CD.Text = "" Then
            Exit Sub
        End If

        cob_KEIYAKUSYA_CD.SelectedValue = CDec(cob_KEIYAKUSYA_CD.Text)

        If cob_KEIYAKUSYA_CD.SelectedValue Is Nothing Then
            cob_KEIYAKUSYA_CD.SelectedIndex = -1
            cob_KEIYAKUSYA_NM.SelectedIndex = -1
            Show_MessageBox_Add("W012", "契約者") '指定された@0が正しくありません。
            cob_KEIYAKUSYA_CD.Focus()
        End If

    End Sub

#End Region

#End Region

#Region "*** データ登録関連 ***"
#Region "f_Save 奨励金計算　処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Save
    '説明            :奨励金計算　処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Save() As Boolean
        Dim Cmd As New OracleCommand
        Dim sSql As String = String.Empty
        Dim ret As Boolean = False

        Dim wTAISYO_SYASU As Long
        Dim wKEIEI_KINGAKU As Long
        Dim wSYOKYAKU_KINGAKU As Long
        Dim wKOFU_KINGAK As Long
        Dim wMsg As String

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            '処理区分
            If rbtn_SYORI_KBN1.Checked Then
                Cmd.CommandText = "PKG_GJ4030.GJ4030_KEISAN"
            Else
                Cmd.CommandText = "PKG_GJ4030.GJ4030_TORIKESI"
            End If

            '--------------------
            '請求
            '--------------------
            '年度
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", txt_KI.Text.Trim)
            '発生回数
            Dim paraHASSEI_KAISU As OracleParameter = Cmd.Parameters.Add("IN_HASSEI_KAISU", CInt(txt_HASSEI_KAISU.Text.Trim))
            '計算回数
            Dim paraKEISAN_KAISU As OracleParameter = Cmd.Parameters.Add("IN_KEISAN_KAISU", CInt(txt_KEISAN_KAISU.Text.Trim))
            '振込予定日
            If rbtn_SYORI_KBN1.Checked Then
                Dim paraYOTEI_DATE As OracleParameter = Cmd.Parameters.Add("IN_FURIKOMI_YOTEI_DATE", date_FURI_YOTEI_DATE.Value)
            End If
            '契約者番号
            If cob_KEIYAKUSYA_CD.Text.Trim = "" Then
                Dim paraSEISANSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", DBNull.Value)
            Else
                Dim paraSEISANSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", cob_KEIYAKUSYA_CD.Text.Trim)
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
            Dim p_TAISYO_SYASU As OracleParameter = Cmd.Parameters.Add("OU_TAISYO_SYASU", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_KEIEI_KINGAKU As OracleParameter = Cmd.Parameters.Add("OU_KEIEI_KINGAKU", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_SYOKYAKU_KINGAKU As OracleParameter = Cmd.Parameters.Add("OU_SYOKYAKU_KINGAKU", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_KOFU_KINGAK As OracleParameter = Cmd.Parameters.Add("OU_KOFU_KINGAKU", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            '--------------------
            '保存
            '--------------------
            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())

            'エラーチェック
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                'メッセージを文字列にキャスト
                wMsg = Cmd.Parameters("OU_MSGNM").Value.ToString()
                Show_MessageBox("", wMsg)
                Exit Try
            End If

            '結果表示 

            wTAISYO_SYASU = CLng(Cmd.Parameters("OU_TAISYO_SYASU").Value.ToString)
            wKEIEI_KINGAKU = CLng(Cmd.Parameters("OU_KEIEI_KINGAKU").Value.ToString)
            wSYOKYAKU_KINGAKU = CLng(Cmd.Parameters("OU_SYOKYAKU_KINGAKU").Value.ToString)
            wKOFU_KINGAK = CLng(Cmd.Parameters("OU_KOFU_KINGAKU").Value.ToString)

            If rbtn_SYORI_KBN1.Checked Then
                Show_MessageBox_Add("I007", "互助交付金計算処理が終了しました" & vbCrLf & _
                                            "対象人数 : " & Format(wTAISYO_SYASU, "##,##0") & " 人" & vbCrLf & _
                                            "経営支援金額 　: " & Format(wKEIEI_KINGAKU, "#,###,###,##0").PadLeft(13) & " 円" & vbCrLf & _
                                            "売却・埋却金額 : " & Format(wSYOKYAKU_KINGAKU, "#,###,###,##0").PadLeft(13) & " 円" & vbCrLf & _
                                            "合計交付金額　 : " & Format(wKOFU_KINGAK, "#,###,###,###,##0").PadLeft(13) & " 円")
            Else
                Show_MessageBox_Add("I007", "互助交付金計算取消処理が終了しました" & vbCrLf & _
                                            "対象人数 : " & Format(wTAISYO_SYASU, "##,##0") & " 人" & vbCrLf & _
                                            "経営支援金額 　: " & Format(wKEIEI_KINGAKU, "#,###,###,##0").PadLeft(13) & " 円" & vbCrLf & _
                                            "売却・埋却金額 : " & Format(wSYOKYAKU_KINGAKU, "#,###,###,##0").PadLeft(13) & " 円" & vbCrLf & _
                                            "合計交付金額　 : " & Format(wKOFU_KINGAK, "#,###,###,###,##0").PadLeft(13) & " 円")
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
    Private Function f_ObjectClear(ByVal rKbn As String) As Boolean

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            'エラー非表示
            pJump = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '変数クリア
            pKI = 0
            pHASSEI_KAISU = ""
            pKEISAN_KAISU = 0
            pFURI_YOTEI_DATE = Nothing

            '画面初期化
            Call f_ClearFormALL(Me, rKbn)

            'If rKbn = "C" Then
            'コンボボックスセット
            f_ComboBox_Set(pInitKi)
            'End If

            '初期表示
            txt_KI.Text = pInitKi

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
                cob_KEIYAKUSYA_CD.DataSource = Nothing
                cob_KEIYAKUSYA_CD.Clear()
                cob_KEIYAKUSYA_NM.DataSource = Nothing
                cob_KEIYAKUSYA_NM.Clear()
                Exit Try
            End If

            '契約者マスタコンボセット(期:画面の期　契約状況:3(未継続者)除く)
            wWhere = "KI = " & wKi
            pJump = True
            If Not f_Keiyaku_Data_Select(cob_KEIYAKUSYA_CD, cob_KEIYAKUSYA_NM, wWhere, True) Then
                Exit Try
            End If
            pJump = False

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
            If pInitHasseiKaisu = "" Then
                txt_HASSEI_KAISU.Text = ""
            Else
                txt_HASSEI_KAISU.Text = pInitHasseiKaisu
            End If

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
#Region "f_Joken_Set1 計算処理　条件画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Joken_Set1
    '説明            :計算処理　条件画面セット
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_Joken_Set1() As Boolean
        Dim ret As Boolean = False
        Dim wBlnOk As Boolean = False

        Try

            '交付金計算履歴取得
            f_TT_KEISAN_Data_Select(wBlnOk)

            '回数セット
            If wBlnOk Then
                If txt_HASSEI_KAISU.Text = "" OrElse txt_HASSEI_KAISU.Text = "0" Then
                    txt_HASSEI_KAISU.Text = pHASSEI_KAISU
                End If
                txt_KEISAN_KAISU.Text = pKEISAN_KAISU + 1
            Else
                txt_KEISAN_KAISU.Text = ""
            End If

            'クリア
            '振込予定日
            date_FURI_YOTEI_DATE.Text = ""
            '契約者番号
            cob_KEIYAKUSYA_CD.SelectedIndex = -1

            '入力制御
            txt_KEISAN_KAISU.Enabled = False
            date_FURI_YOTEI_DATE.Enabled = True

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

            '補填奨励金計算履歴読込
            f_TT_KEISAN_Data_Select(wBlnOk)

            If wBlnOk Then
                '補填奨励金計算履歴より
                '発生回数セット
                If txt_HASSEI_KAISU.Text = "" OrElse txt_HASSEI_KAISU.Text = "0" Then
                    txt_HASSEI_KAISU.Text = pHASSEI_KAISU
                End If
                '計算回数セット
                txt_KEISAN_KAISU.Text = pKEISAN_KAISU
                '振込予定日
                date_FURI_YOTEI_DATE.Value = pFURI_YOTEI_DATE
                '契約者番号
                cob_KEIYAKUSYA_CD.SelectedIndex = -1
            Else
                '画面クリア
                '回数セット
                txt_KEISAN_KAISU.Text = ""
                '振込予定日
                date_FURI_YOTEI_DATE.Text = ""
                '契約者番号
                cob_KEIYAKUSYA_CD.SelectedIndex = -1
            End If

            '入力制御
            txt_KEISAN_KAISU.Enabled = True
            date_FURI_YOTEI_DATE.Enabled = False

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_TT_KEISAN_Data_Select 交付金算履歴取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TT_KEISAN_Data_Select
    '説明            :交付金算履歴取得
    '引数            :Boolean(データ有りTrue/データ無しFalse)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_TT_KEISAN_Data_Select(ByRef wBlnOk As Boolean) As Boolean
        Dim ret As Boolean = False
        Dim wSQL As String = String.Empty
        Dim wDS As New DataSet
        Dim wStr As String

        Try

            '変数初期化
            wBlnOk = False
            pKEISAN_KAISU = 0
            pFURI_YOTEI_DATE = Nothing

            If txt_KI.Text.Trim = "" Then
                ret = True
                Exit Try
            End If

            '交付金計算履歴　読込
            wSQL = " SELECT "
            wSQL += " KI, HASSEI_KAISU, KEISAN_KAISU, SYORI_DATE, FURI_YOTEI_DATE,"
            wSQL += " TAISYO_SYASU, KEIEI_KINGAKU, SYOKYAKU_KINGAKU, KOFU_KINGAKU"
            wSQL += " FROM"
            wSQL += "  TT_KOFU_KEISAN"
            If txt_HASSEI_KAISU.Text.Trim = "" Then
                '期のみで検索
                wSQL += " WHERE KI = " & txt_KI.Text
                wSQL += " ORDER BY "
                wSQL += "   HASSEI_KAISU DESC, KEISAN_KAISU DESC"
            Else
                '期と発生回数で検索
                wSQL += " WHERE KI = " & txt_KI.Text
                wSQL += "   AND HASSEI_KAISU = " & txt_HASSEI_KAISU.Text
                wSQL += " ORDER BY "
                wSQL += "   KEISAN_KAISU DESC"
            End If

            Call f_Select_ODP(wDS, wSQL)

            '回数・振込予定日　セーブ
            With wDS.Tables(0)
                If .Rows.Count = 0 Then
                    If txt_KI.Text = "" Then
                        pKI = pInitKi
                    End If
                    If txt_KI.Text = pInitKi Then
                        pHASSEI_KAISU = pInitHasseiKaisu
                    Else
                        pHASSEI_KAISU = 1
                    End If
                    pKEISAN_KAISU = 0
                    pFURI_YOTEI_DATE = Nothing
                    '取消のとき、ないとエラー
                    If rbtn_SYORI_KBN1.Checked Then
                        wBlnOk = True
                    End If
                Else
                    If txt_HASSEI_KAISU.Text.Trim = "" Then
                        pHASSEI_KAISU = WordHenkan("N", "Z", .Rows(0)("HASSEI_KAISU"))
                    End If
                    pKEISAN_KAISU = WordHenkan("N", "Z", .Rows(0)("KEISAN_KAISU"))
                    wStr = WordHenkan("N", "S", .Rows(0)("FURI_YOTEI_DATE"))
                    If wStr = "" Then
                        pFURI_YOTEI_DATE = Nothing
                    Else
                        pFURI_YOTEI_DATE = Date.Parse(wStr)
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

#Region "f_GridView_Set グリッドビューセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_GridView_Set
    '説明            :グリッドビューセット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_GridView_Set(ByVal wKbn As String, _
                                    ByVal wHasseiKaisu As Integer, ByVal wKeisanKaisu As Integer) As Boolean
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
            wSql = wSql & " KEI.HASSEI_KAISU || '   ' HASSEI_KAISU,"
            wSql = wSql & " KEI.KEISAN_KAISU || '   ' KEISAN_KAISU,"
            wSql = wSql & " TO_CHAR(KEI.SYORI_DATE, 'YY/MM/DD','NLS_CALENDAR=''Japanese Imperial''') SYORI_DATE,"           '処理日
            wSql = wSql & " TO_CHAR(KEI.FURI_YOTEI_DATE, 'YY/MM/DD','NLS_CALENDAR=''Japanese Imperial''') FURI_YOTEI_DATE," '振込予定日
            wSql = wSql & " TO_CHAR(KEI.TAISYO_SYASU,      '9,999') || '   ' TAISYO_SYASU,"                 '計算対象者数
            wSql = wSql & " TO_CHAR(KEI.KEIEI_KINGAKU,     '9,999,999,999') || '   ' KEIEI_KINGAKU,"        '経営支援金額
            wSql = wSql & " TO_CHAR(KEI.SYOKYAKU_KINGAKU , '9,999,999,999') || '   ' SYOKYAKU_KINGAKU, "    '売却・埋却金額
            wSql = wSql & " TO_CHAR(KEI.KOFU_KINGAKU ,     '9,999,999,999') || '   ' KOFU_KINGAKU "         '合計交付金額
            wSql = wSql & " FROM"
            wSql = wSql & " TT_KOFU_KEISAN KEI"
            wSql = wSql & " WHERE KI = " & txt_KI.Text.Trim
            wSql = wSql & " ORDER BY"
            wSql = wSql & "   KEI.HASSEI_KAISU DESC, KEISAN_KAISU DESC"

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
                wBol = f_GridReDisp(txt_HASSEI_KAISU.Text.Trim, txt_KEISAN_KAISU.Text.Trim)
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
    Private Function f_GridReDisp(ByVal wHasseiKaisu As Integer, ByVal wKeisanKaisu As Integer) As Boolean
        Dim ret As Boolean = False
        Dim blnHit As Boolean = False

        Try
            'グリッドに有効データあり
            If dgv_Search.RowCount <> 0 Then

                '更新対象のデータ　または　その次のデータに、カーソルをせっと
                For i As Integer = 0 To dgv_Search.RowCount - 1
                    '発生回数
                    If CInt(WordHenkan("N", "Z", dgv_Search.Item("HASSEI_KAISU", i).Value)) < wHasseiKaisu Then
                        'ブレーク
                        dgv_Search.CurrentCell = dgv_Search(0, i)
                        blnHit = True
                        Exit For
                    ElseIf CInt(WordHenkan("N", "Z", dgv_Search.Item("HASSEI_KAISU", i).Value)) = wHasseiKaisu Then
                        '計算回数
                        If CInt(WordHenkan("N", "Z", dgv_Search.Item("KEISAN_KAISU", i).Value)) <= wKeisanKaisu Then
                            'ブレーク
                            dgv_Search.CurrentCell = dgv_Search(0, i)
                            blnHit = True
                            Exit For
                        End If
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
        Dim ret As Boolean = False
        Dim sSQL As String = String.Empty
        Dim wDS As New DataSet
        Dim wBlnOk As Boolean

        Try
            '--------------------------------------------------
            '必須入力チェック
            '--------------------------------------------------

            '対象年月
            If txt_KI.Text = "" Then
                Show_MessageBox_Add("W008", "対象期")         '@0は必須入力項目です。
                txt_KI.Focus()
                Exit Try
            End If

            '発生回数
            If txt_HASSEI_KAISU.Text.TrimEnd = "" Then
                '2022/02/01 JBD9020 発生回数→認定回数に変更 UPD START
                'Show_MessageBox_Add("W008", "発生回数")           '@0は必須入力項目です。
                Show_MessageBox_Add("W008", "認定回数")           '@0は必須入力項目です。
                '2022/02/01 JBD9020 発生回数→認定回数に変更 UPD END
                txt_HASSEI_KAISU.Focus()
                Exit Try
            End If

            '計算回数
            If txt_KEISAN_KAISU.Text.TrimEnd = "" Then
                Show_MessageBox_Add("W008", "計算回数")      '@0は必須入力項目です。
                txt_KEISAN_KAISU.Focus()
                Exit Try
            End If

            '振込予定日
            If rbtn_SYORI_KBN1.Checked Then
                If date_FURI_YOTEI_DATE.Value Is Nothing Then
                    Show_MessageBox_Add("W008", "振込予定日")      '@0は必須入力項目です。
                    date_FURI_YOTEI_DATE.Focus()
                    Exit Try
                End If
            End If

            '--------------------------------------------------
            '請求・取消対象　チェック
            '--------------------------------------------------
            If rbtn_SYORI_KBN1.Checked Then
                '計算チェック
                If Not f_KEISAN_Chk(wBlnOk) Then
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
#Region "f_KEISAN_Chk 計算処理チェック"
    '------------------------------------------------------------------
    'プロシージャ名  :f_KEISAN_Chk
    '説明            :計算処理チェック
    '引数            :Boolean(エラー有りFalse/エラー無しTrue)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_KEISAN_Chk(ByRef wBlnOk As Boolean) As Boolean

        Dim sSql As String = String.Empty
        Dim dstDataControl As New DataSet
        Dim ret As Boolean = False
        Dim wCHK As Boolean = False

        Try
            wBlnOk = False


            '交付金計算履歴　読込(処理終了後に、画面クリアをしていないので、再度実行ボタンが押せる)
            sSql = " SELECT COUNT(KI)KENSU FROM TT_KOFU_KEISAN" & vbCrLf
            sSql += " WHERE KI = " & txt_KI.Text.Trim
            sSql += "   AND HASSEI_KAISU = " & txt_HASSEI_KAISU.Text.Trim
            sSql += "   AND KEISAN_KAISU = " & txt_KEISAN_KAISU.Text.Trim

            Call f_Select_ODP(dstDataControl, sSql)

            'エラー　チェック
            If dstDataControl.Tables(0).Rows.Count > 0 Then
                If CInt(WordHenkan("N", "Z", dstDataControl.Tables(0).Rows(0)("KENSU"))) <> 0 Then
                    Show_MessageBox_Add("W019", "既に同一回数で交付金計算処理が行われています。") '@0
                    Exit Try
                End If
            End If

            '契約者指定のとき、計算済みチェック
            If cob_KEIYAKUSYA_CD.Text <> "" Then

                sSql = " SELECT COUNT(KI)KENSU FROM TT_KOFU" & vbCrLf
                sSql += " WHERE KI = " & txt_KI.Text.Trim
                sSql += "   AND KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text

                Call f_Select_ODP(dstDataControl, sSql)

                'エラー　チェック
                If dstDataControl.Tables(0).Rows.Count > 0 Then
                    If CInt(WordHenkan("N", "Z", dstDataControl.Tables(0).Rows(0)("KENSU"))) <> 0 Then
                        Show_MessageBox_Add("W019", "該当の契約者は、既に計算処理が行われています。") '@0
                        Exit Try
                    End If
                End If
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
    Public Function f_TORIKESHI_Chk(ByRef wBlnOk As Boolean) As Boolean
        Dim ret As Boolean = False
        Dim wSQL As String = String.Empty
        Dim wDS As New DataSet
        Dim wERR As String
        Dim wCHK As Boolean = False

        Try
            wBlnOk = False

            '**************************************************
            '   成鶏更新・契約者奨励金実績　チェック
            '**************************************************
            wSQL = " SELECT " & vbCrLf
            wSQL += "  COUNT(KI) KENSU, " & vbCrLf                            '計算件数
            wSQL += "  SUM(CASE WHEN SYORI_JOKYO = 1 THEN 0 ELSE 1 END) SUMI " & vbCrLf '通知済人数
            wSQL += " FROM" & vbCrLf
            wSQL += "  TT_KOFU" & vbCrLf
            wSQL += " WHERE KI = " & txt_KI.Text
            wSQL += "   AND HASSEI_KAISU = " & txt_HASSEI_KAISU.Text.Trim
            wSQL += "   AND KEISAN_KAISU = " & txt_KEISAN_KAISU.Text.Trim
            '契約者
            If cob_KEIYAKUSYA_CD.Text.Trim <> "" Then
                wSQL += "  AND KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim & vbCrLf
            End If

            Call f_Select_ODP(wDS, wSQL)

            '計算処理チェック
            If wDS.Tables(0).Rows.Count = 0 Then
                Show_MessageBox_Add("W019", "計算処理がされていません") '計算処理がされていません
                Exit Try
            End If
            '計算人数チェック
            If CInt(WordHenkan("N", "Z", wDS.Tables(0).Rows(0)("KENSU"))) = 0 Then
                Show_MessageBox_Add("W019", "計算処理がされていません") '計算処理がされていません
                Exit Try
            End If

            '発行済みチェック
            If CInt(WordHenkan("N", "Z", wDS.Tables(0).Rows(0)("SUMI"))) <> 0 Then
                If cob_KEIYAKUSYA_CD.Text.Trim = "" Then
                    '全員指定
                    wERR = Format(wDS.Tables(0).Rows(0)("SUMI"), "###,##0")
                    Show_MessageBox_Add("W019", "交付金通知発行済みが" & wERR & "人います。" & vbCrLf _
                                                  & "取消できません。") '交付金通知発行済みが99,999人います。取消できません。
                    Exit Try
                Else
                    '契約者指定
                    If Show_MessageBox_Add("Q012", "すでに交付金通知発行済みです。よろしいですか。") = DialogResult.No Then    '@0既に交付通知発行済みです。よろしいですか。
                        '「キャンセル」を選択
                        Exit Try
                    End If
                End If
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

#End Region

    Private Sub txt_HASSEI_KAISU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_HASSEI_KAISU.SelectedIndexChanged

    End Sub

    Private Sub date_NENDO_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_KI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_KI.TextChanged

    End Sub
End Class
