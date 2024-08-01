'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ9010.vb
'*
'*　　②　機能概要　　　　　契約者積立金金計算
'*
'*　　③　作成日　　　　　　2017/07/07 BY JBD
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

'Imports GrapeCity.ActiveReports.SectionReportModel
'Imports GrapeCity.ActiveReports.Export
'Imports GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport

Imports System.IO

Public Class frmGJ9010

#Region "*** 変数定義 ***"

    ''' <summary>
    '''  プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True
    Private pKi As String               '期(初期値)
    Private pGJS As String = "GJS"        'コピー元(初期値)
    Private pGJS29 As String = "GJS29"    'コピー先(初期値)

#End Region

#Region "*** 画面制御関連 ***"

#Region "frmFS2020_Load Form_Loadイベント"

    Private Property wUpd_KEIYAKU_DATE As Object

    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ9010_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ9010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 
        Try

            '処理年度・期　取得
            Dim clsNENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI
            pKi = clsNENDO_KI.pKI

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            pJump = True

            If Not f_ObjectClear("C") Then
                'フォームクローズ
                Me.Close()
            End If

            pJump = False

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

#Region "cmdSav_Click 保存ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSav_Click
    '説明            :保存ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSav.Click

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '入力項目チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '保存処理確認
            If Show_MessageBox_Add("Q009", "契約者マスタのコピー") = DialogResult.No Then    '@0処理を行いますか？
                '「キャンセル」を選択
                Exit Try
            End If

            'データ保存
            If Not f_Save() Then
                Exit Try
            End If

            '初期表示
            If Not f_ObjectClear("") Then
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

#Region "契約者"
    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEIYAKUSYA_CD1_SelectedIndexChanged
    '説明            :契約者コードChanegeイベント
    '------------------------------------------------------------------
    Private Sub cob_KEIYAKUSYA_CD1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEIYAKUSYA_CD.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEIYAKUSYA_NM.SelectedIndex = cob_KEIYAKUSYA_CD.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEIYAKUSYA_NM1_SelectedIndexChanged
    '説明            :契約者名Chanegeイベント
    '------------------------------------------------------------------
    Private Sub cob_KEIYAKUSYA_NM1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_KEIYAKUSYA_NM.SelectedIndexChanged

        '画面クリアの時、処理しない
        If pJump Then
            Exit Sub
        End If

        cob_KEIYAKUSYA_CD.SelectedIndex = cob_KEIYAKUSYA_NM.SelectedIndex

    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :cob_KEIYAKUSYA_CD1_Validating
    '説明            :契約者コード_Validating
    '引数            :省略
    '戻り値          :省略
    '------------------------------------------------------------------
    Private Sub cob_KEIYAKUSYA_CD1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cob_KEIYAKUSYA_CD.Validating

        If cob_KEIYAKUSYA_CD.Text = "" Then
            Exit Sub
        End If

        '2015/03/03 JBD368 UPD ↓↓↓ 値の設定方法を変更
        'cob_KEIYAKUSYA_CD1.SelectedValue = cob_KEIYAKUSYA_CD1.Text
        cob_KEIYAKUSYA_CD.SelectedValue = CDec(cob_KEIYAKUSYA_CD.Text)
        '2015/03/03 JBD368 UPD ↑↑↑
        If cob_KEIYAKUSYA_CD.SelectedValue Is Nothing Then
            cob_KEIYAKUSYA_CD.SelectedIndex = -1
            cob_KEIYAKUSYA_NM.SelectedIndex = -1
            Show_MessageBox_Add("W012", "契約者") '指定された@0が正しくありません。
            cob_KEIYAKUSYA_CD.Focus()
        End If

    End Sub

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
        Dim ret As Boolean = False

        Try

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '画面初期化
            pJump = True
            Call f_ClearFormALL(Me, wKbn)
            pJump = False

            '初期表示
            txt_KI.Text = pKi

            '初回のみ
            If wKbn = "C" Then
                'スキーマ取得
                If Not f_Schema_Get() Then
                    Exit Try
                End If
                'コンボボックスセット
                If Not f_ComboBox_Set() Then
                    Exit Try
                End If
            End If

            '先頭項目へ
            cob_KEIYAKUSYA_CD.Focus()

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'エラー表示
            pJump = False
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        End Try

        Return ret
    End Function
#End Region
#Region "f_Schema_Get スキーマ名取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Schema_Get
    '説明            :スキーマ名取得
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Schema_Get() As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty
        Dim wDS As New DataSet

        Try

            '--------------------------------------------------
            '第１基金スキーマ　コードマスタ　種別:17
            '--------------------------------------------------
            wSql = " SELECT "
            wSql += "  RYAKUSYO"
            wSql += " FROM"
            wSql += "  TM_CODE"
            wSql += " WHERE SYURUI_KBN = 17"
            wSql += "   AND MEISYO_CD = 1"

            Call f_Select_ODP(wDS, wSql)

            '回数セーブ
            With wDS.Tables(0)
                If .Rows.Count = 0 Then
                    Show_MessageBox_Add("I007", "第１基金のスキーマが設定されていません。")     '@0
                    cob_KEIYAKUSYA_CD.Focus()
                    Exit Try
                End If
                pGJS = .Rows(0)("RYAKUSYO").ToString.Trim
            End With

            wDS.Clear()
            '--------------------------------------------------
            '第２基金スキーマ　コードマスタ　種別:17
            '--------------------------------------------------
            wSql = " SELECT "
            wSql += "  RYAKUSYO"
            wSql += " FROM"
            wSql += "  TM_CODE"
            wSql += " WHERE SYURUI_KBN = 17"
            wSql += "   AND MEISYO_CD = 2"

            Call f_Select_ODP(wDS, wSql)

            '回数セーブ
            With wDS.Tables(0)
                If .Rows.Count = 0 Then
                    Show_MessageBox_Add("I007", "第２基金のスキーマが設定されていません。")     '@0
                    cob_KEIYAKUSYA_CD.Focus()
                    Exit Try
                End If
                pGJS29 = .Rows(0)("RYAKUSYO").ToString.Trim
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
    Private Function f_ComboBox_Set() As Boolean
        Dim wWhere As String = String.Empty
        Dim ret As Boolean = False

        Try

            '期が未入力のとき
            If pKi = "" OrElse pKi = String.Empty Then
                '2015/03/03 JBD368 UPD ↓↓↓ DataSourceへ変更に伴い、初期化方法変更
                'cob_KEIYAKUSYA_CD1.Items.Clear()
                'cob_KEIYAKUSYA_NM1.Items.Clear()
                cob_KEIYAKUSYA_CD.DataSource = Nothing
                cob_KEIYAKUSYA_CD.Clear()
                cob_KEIYAKUSYA_NM.DataSource = Nothing
                cob_KEIYAKUSYA_NM.Clear()
                '2015/03/03 JBD368 UPD ↑↑↑
                Exit Try
            End If

            '契約者マスタコンボセット(期:画面の期　契約状況:3(未継続者)除く)
            wWhere = "KI = " & pKi
            pJump = True    '2015/03/04　追加

            '引数:1.cmbKeiyakuCd  JBD.Gjs.Win.GcComboBox 契約者コードコンボボックス
            '     2.cmbKeiyakuMei JBD.Gjs.Win.GcComboBox 契約者名コンボボックス
            '     3.strWhere      String                 契約者マスタ検索条件 WHERE句を指定する
            '     4.blnNullAddFlg Boolean                スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
            '     5.blnEnable     Boolean                コンボの入力可否(TRUE:入力可能 FALSE:入力不可)
            '     6.strUser       Boolean                他スキーマのデータが必要な時、スキーマをセット(""のとき、自スキーマ)   '2017/07/07追加
            If Not f_Keiyaku_Data_Select(cob_KEIYAKUSYA_CD, cob_KEIYAKUSYA_NM, wWhere, True, True, pGJS) Then
                Exit Try
            End If

            pJump = False   '2015/03/04　追加

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

            '対象期
            If cob_KEIYAKUSYA_CD.Text.Trim = "" Then
                Show_MessageBox_Add("W008", "契約者番号")     '@0は必須入力項目です。
                cob_KEIYAKUSYA_CD.Focus()
                Exit Try
            End If

            '--------------------------------------------------
            'コピー元　契約者マスタ　チェック
            '--------------------------------------------------
            wSql = " SELECT "
            wSql += "  KEIYAKU_JYOKYO, HAIGYO_DATE"
            wSql += " FROM"
            wSql += "  " & pGJS & ".TM_KEIYAKU"
            wSql += " WHERE KI = " & txt_KI.Text.Trim
            wSql += "   AND KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim

            Call f_Select_ODP(wDS, wSql)

            '回数セーブ
            With wDS.Tables(0)
                If .Rows.Count = 0 Then
                    Show_MessageBox_Add("I007", "該当データは、既に削除されています。")     '@0
                    cob_KEIYAKUSYA_CD.Focus()
                    Exit Try
                End If
                If .Rows(0)("KEIYAKU_JYOKYO").ToString = "3" Then
                    Show_MessageBox_Add("I007", "未継続の契約者です。" & vbCrLf & "コピーできません。")     '@0
                    cob_KEIYAKUSYA_CD.Focus()
                    Exit Try
                End If
                If .Rows(0)("KEIYAKU_JYOKYO").ToString <> "1" AndAlso
                   .Rows(0)("KEIYAKU_JYOKYO").ToString <> "2" Then
                    Show_MessageBox_Add("I007", "新規加入者、継続契約者以外です。" & vbCrLf & "コピーできません。")     '@0
                    cob_KEIYAKUSYA_CD.Focus()
                    Exit Try
                End If
                If .Rows(0)("HAIGYO_DATE").ToString <> "" Then
                    Show_MessageBox_Add("I007", "廃業日が設定されている契約者です。" & vbCrLf & "コピーできません。")     '@0
                    cob_KEIYAKUSYA_CD.Focus()
                    Exit Try
                End If
            End With

            wDS.Clear()
            '--------------------------------------------------
            'コピー先　契約者マスタ　チェック
            '--------------------------------------------------
            wSql = " SELECT "
            wSql += "  KEIYAKU_JYOKYO, HAIGYO_DATE"
            wSql += " FROM"
            wSql += "  " & pGJS29 & ".TM_KEIYAKU"
            wSql += " WHERE KI = " & txt_KI.Text.Trim
            wSql += "   AND KEIYAKUSYA_CD = " & cob_KEIYAKUSYA_CD.Text.Trim

            Call f_Select_ODP(wDS, wSql)

            '回数セーブ
            With wDS.Tables(0)
                If .Rows.Count > 0 Then
                    Show_MessageBox_Add("I007", "該当データは、既に登録されています。")     '@0
                    cob_KEIYAKUSYA_CD.Focus()
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

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ9010.GJ9010_INSERT"

            '--------------------
            '請求
            '--------------------
            '期
            Cmd.Parameters.Add("IN_KI", txt_KI.Text.Trim)

            '契約番号
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", cob_KEIYAKUSYA_CD.Text.Trim)

            '入力状況
            If rbtn_NYURYOKU_JYOKYO1.Checked Then
                Cmd.Parameters.Add("INNYURYOKU_JYOKYO", 1)
            Else
                Cmd.Parameters.Add("INNYURYOKU_JYOKYO", 2)
            End If

            '第１基金スキーマ
            Dim paraSCHEMA1 As OracleParameter = Cmd.Parameters.Add("IN_SCHEMA1", pGJS)
            '第２基金スキーマ
            Dim paraSCHEMA2 As OracleParameter = Cmd.Parameters.Add("IN_SCHEMA2", pGJS29)

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
            If Cmd.Parameters("OU_MSGCD").Value.ToString() = "0" Then
                Show_MessageBox("I001", "") '正常に終了しました。
            Else
                Throw New Exception(Cmd.Parameters("OU_MSGCD").Value.ToString() & ":" & Cmd.Parameters("OU_MSGNM").Value.ToString())
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

End Class
