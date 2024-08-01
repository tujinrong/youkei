'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ8010.vb
'*
'*　　②　機能概要　　　　　コードマスタ一覧
'*
'*　　③　作成日　　　　　　2014/12/26 JBD368 
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

Public Class frmGJ8010
#Region "変数定義"

    ''' <summary>
    ''' グリッドキー項目構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Class T_KEY
        ''' <summary>
        ''' 生産者コード
        ''' </summary>
        ''' <remarks></remarks>
        Public SYURUI_KBN As String = String.Empty
        Public MEISYO_CD As String = String.Empty
        Public MEISYO As String = String.Empty
        Public RYAKUSYO As String = String.Empty
        Public SYURUI_KBN_NM As String = String.Empty
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
    Public paryKEY_8010 As New List(Of T_KEY)

    ''' <summary>
    ''' 変更時、該当データ選択行
    ''' </summary>
    ''' <remarks></remarks>
    Public pSel_POS As Integer

    ''' <summary>
    ''' 新規/更新モード
    ''' </summary>
    ''' <remarks></remarks>
    Enum enuMode
        search = 0
        Insert = 1
        Update = 2
        read = 3
    End Enum

    ''' <summary>
    ''' 現在モード
    ''' </summary>
    ''' <remarks></remarks>
    Private loMode As enuMode = enuMode.search



#End Region

#Region "画面制御関連"
#Region "フォームロード時処理"

    ''' <summary>
    ''' フォームロード時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmGJ8010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean
        Try


            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear()

            'コンボボックスセット
            If Not f_ComboBox_Set() Then
                Exit Try
            End If

            '種類区分にフォーカスセット
            cob_SYURUI_KBN_NM.Focus()
            cob_SYURUI_KBN_NM_SelectedIndexChanged(cob_SYURUI_KBN_NM, New EventArgs)
            cmdIns.Enabled = False

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

    End Sub
#End Region
#Region "画面クリア"
    ''' <summary>
    ''' 画面クリア
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_ObjectClear() As Boolean

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            f_ClearFormALL(Me, "")

            paryKEY_8010 = New List(Of T_KEY)

            pDataSet.Clear()

            '-^-v-^初期値設定-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v

            '-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v-^-v

            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function

#End Region
#End Region

#Region "画面ボタンクリック関連"
#Region "変更ボタンクリック時処理"
    ''' <summary>
    ''' 変更ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUpd.Click, cmdIns.Click
        Dim tKEY As New T_KEY
        Dim strtNowKEY As T_KEY = Nothing
        Dim wkSYORI_KBN As Integer = 0

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            Select Case True
                Case sender.Equals(cmdIns)
                    'グリッドのKey情報を構造体に格納
                    paryKEY_8010 = New List(Of T_KEY)
                    tKEY = New T_KEY

                    tKEY.SYURUI_KBN = cob_SYURUI_KBN.Text
                    tKEY.MEISYO_CD = ""
                    tKEY.MEISYO = ""
                    tKEY.RYAKUSYO = ""
                    tKEY.SYURUI_KBN_NM = cob_SYURUI_KBN_NM.Text
                    paryKEY_8010.Add(tKEY)
                    strtNowKEY = tKEY
                Case sender.Equals(CmdUpd)
                    '一覧より選択されていなければエラー
                    If dgv_Search.SelectedRows.Count = 0 Then
                        Show_MessageBox("W011", "")       'データが選択されていません。
                        Exit Try
                    End If

                    'グリッドのKey情報を構造体に格納
                    paryKEY_8010 = New List(Of T_KEY)
                    For i As Integer = 0 To dgv_Search.RowCount - 1

                        tKEY = New T_KEY

                        tKEY.SYURUI_KBN = dgv_Search.Item("SYURUI_KBN", i).Value
                        tKEY.MEISYO_CD = dgv_Search.Item("MEISYO_CD", i).Value
                        tKEY.MEISYO = dgv_Search.Item("MEISYO", i).Value
                        tKEY.RYAKUSYO = dgv_Search.Item("RYAKUSYO", i).Value.ToString
                        tKEY.SYURUI_KBN_NM = dgv_Search.Item("SYURUI_KBN_NM", i).Value


                        If dgv_Search.Rows(i).Selected Then

                            strtNowKEY = tKEY
                            pSel_POS = i + 1
                        End If
                        paryKEY_8010.Add(tKEY)
                    Next
            End Select



            Using wkForm As New frmGJ8011
                wkForm.Owner = Me
                Select Case True
                    Case sender.Equals(cmdIns)
                        wkForm.loMode = frmGJ8011.enuMode.Insert
                    Case sender.Equals(CmdUpd)
                        wkForm.loMode = frmGJ8011.enuMode.Update
                End Select
                wkForm.pCurrentKey = strtNowKEY      '現在選択されている行のキーを渡します
                wkForm.pSel_NO = pSel_POS                '現在選択されている行のキーを渡します


                wkForm.paryKEY_8010 = paryKEY_8010

                wkForm.ShowDialog()

                'カーソルを砂時計にする
                Me.Cursor = Cursors.WaitCursor

                '再抽出
                cob_SYURUI_KBN_NM_SelectedIndexChanged(cob_SYURUI_KBN_NM, New EventArgs)

                '行選択
                For Each wkRow As DataGridViewRow In dgv_Search.Rows
                    If wkForm.pCurrentKey.SYURUI_KBN.ToString = wkRow.Cells("SYURUI_KBN").Value.ToString And
                        wkForm.pCurrentKey.MEISYO_CD.ToString = wkRow.Cells("MEISYO_CD").Value.ToString Then
                        dgv_Search.CurrentCell = wkRow.Cells(0)

                    End If
                Next


            End Using

            dgv_Search.Refresh()
            dgv_Search.Focus()
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try
    End Sub
#End Region
#Region "キャンセルボタンクリック時処理"
    ''' <summary>
    ''' キャンセルボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdCan_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim ret As Boolean

        ret = f_ObjectClear()

        'コンボボックスセット
        If Not f_ComboBox_Set() Then
            Exit Sub
        End If

        'データ区分にフォーカスセット
        cob_SYURUI_KBN_NM.Focus()

    End Sub
#End Region
#Region "終了ボタンクリック時処理"
    ''' <summary>
    ''' 終了ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try
            If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                Exit Try
            End If


            'フォームクローズ
            Me.AutoValidate = AutoValidate.Disable
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
#Region "削除ボタンクリック時処理"
    ''' <summary>
    ''' 削除ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDel.Click

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor
        Dim wkDS As New DataSet

        Try
            '画面入力チェック
            If Not f_Input_Check(3, True) Then
                Exit Try
            End If

            '削除処理確認
            If Show_MessageBox_Add("Q006", "指定されたデータ") = DialogResult.No Then    '指定されたデータを削除します。よろしいですか？

                Exit Try
            End If
            Dim intRow As Integer = 0       '行番号

            For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
                intRow = gRow.Index
            Next

            '該当データ削除処理
            If Not f_TM_HAGAKI_ANNAI_Delete(intRow) Then
                Exit Try
            End If

            'f_ObjectClear()
            cob_SYURUI_KBN_NM_SelectedIndexChanged(cob_SYURUI_KBN_NM, New EventArgs)

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region
#End Region

#Region "画面コントロール制御関連 "

#Region "種類選択関連"


    ''' <summary>
    ''' 種類選択変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cob_SYURUI_KBN_NM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cob_SYURUI_KBN_NM.SelectedIndexChanged



        cob_SYURUI_KBN_NM.Tag = cob_SYURUI_KBN_NM.SelectedIndex

        cob_SYURUI_KBN.SelectedIndex = cob_SYURUI_KBN_NM.SelectedIndex

        Dim wkDS As New DataSet
        Dim wkSql As String = String.Empty

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor


        Try

            '検索処理
            pDataSet.Clear()

            wkSql = f_Search_SQLMake(0)
            If Not f_Select_ODP(pDataSet, wkSql) Then
                Exit Try
            End If

            If pDataSet.Tables(0).Rows.Count > 0 Then

                '画面に該当データを表示
                dgv_Search.DataSource = pDataSet.Tables(0)

                '更新
                loMode = enuMode.Update
                cmdIns.Enabled = True
                CmdDel.Enabled = True
                cmdEnd.Enabled = True
                CmdUpd.Enabled = True

            Else
                '2015/02/05 JBD368 UPD ↓↓↓
                If cob_SYURUI_KBN_NM.Text <> "" Then

                    pDataSet.Clear()
                    '新規
                    loMode = enuMode.Insert
                    cmdIns.Enabled = True
                    CmdDel.Enabled = False
                    cmdEnd.Enabled = True
                    CmdUpd.Enabled = False
                    Exit Sub
                Else
                    '2015/02/05 JBD368 UPD ↑↑↑
                    pDataSet.Clear()
                    '登録・更新不可
                    loMode = enuMode.search
                    cmdIns.Enabled = False
                    CmdDel.Enabled = False
                    cmdEnd.Enabled = True
                    CmdUpd.Enabled = False
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


#End Region

#Region "ローカル関数"
#Region "マスタ削除処理"
    ''' <summary>
    ''' マスタ削除処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_TM_HAGAKI_ANNAI_Delete(ByVal intRow As Integer) As Boolean
        Dim wkCmd As New OracleCommand
        Dim wkSql As String = String.Empty
        Dim wkTrans As Oracle.ManagedDataAccess.Client.OracleTransaction = Nothing
        Dim wkblnIsTran As Boolean = False
        Dim wkRet As Boolean = False
        Dim wkDS As New DataSet


        Try
            'ストアドプロシージャの呼び出し
            wkCmd.Connection = Cnn
            wkCmd.CommandType = CommandType.StoredProcedure
            '
            wkCmd.CommandText = "PKG_GJ8011.GJ8011_CODE_DEL"
            '引き渡し
            wkCmd.Parameters.Add("IN_CODE_SYURUI_KBN", CInt(cob_SYURUI_KBN.Text))                   'kubunn
            wkCmd.Parameters.Add("IN_CODE_MEISYO_CD", dgv_Search.Item("MEISYO_CD", intRow).Value)
            '戻り
            Dim p_MSGCD As OracleParameter = wkCmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = wkCmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            wkCmd.ExecuteNonQuery()
            Debug.Print(wkCmd.Parameters("OU_MSGCD").Value.ToString())
            If wkCmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Throw New Exception(wkCmd.Parameters("OU_MSGCD").Value.ToString() & ":" & wkCmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            'データベースへの接続を閉じる
            If Not wkCmd Is Nothing Then
                wkCmd.Dispose()
            End If

            wkRet = True

        Catch ex As Exception
            '共通例外処理
            If "" <> "Err" Then
                Show_MessageBox("", "")
            End If
            'RollBack
            If wkblnIsTran = True Then
                wkTrans.Rollback()
            End If
        End Try

        Return wkRet


    End Function
#End Region
#Region "ＳＱＬ文作成"
    ''' <summary>
    ''' ＳＱＬ文作成
    ''' </summary>
    ''' <param name="iKbn">
    ''' 0・
    ''' 
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Search_SQLMake(ByVal iKbn As Integer) As String
        Dim wkSB As New StringBuilder
        Dim wkANDorOR As String = String.Empty
        Dim wkWhere As New StringBuilder
        Try



            Select Case iKbn
                Case 0
                    wkSB.AppendLine("select ")
                    wkSB.AppendLine("	T.MEISYO_CD,")
                    wkSB.AppendLine("	T.SYURUI_KBN,")
                    wkSB.AppendLine("	T.MEISYO,")
                    wkSB.AppendLine("	NVL(T.RYAKUSYO,'') as RYAKUSYO")
                    wkSB.AppendLine("     ,KBN.MEISYO as SYURUI_KBN_NM")
                    wkSB.AppendLine("From TM_CODE T")
                    wkSB.AppendLine("    left join TM_CODE  KBN")
                    wkSB.AppendLine("      on 1 = 1 ")
                    wkSB.AppendLine("      and KBN.SYURUI_KBN = 0 ")
                    wkSB.AppendLine("      and KBN.MEISYO_CD = T.SYURUI_KBN ")

                Case 1

            End Select

            '(
            ') Where 条件
            '(
            '==必須条件=======================
            If cob_SYURUI_KBN.Text <> "" Then
                wkWhere.AppendLine("and   T.SYURUI_KBN =   " & cob_SYURUI_KBN.Text)
            Else
                wkWhere.AppendLine("and  1=0")
            End If
            '----------------------------------/


            '==オプション条件====================
            ' 以下は省略可能な条件なので指定されていた場合にのみ編集
            ' 但し、検索方法が全てを含むなのかいずれかを含むなのかによりwkANDorORの内容がANDかORに変わる





            '==必須条(ここだけOR条件を指定されてもAND条件)======================
            'WHERE条件句を作成
            wkSB.AppendLine("Where 1=1")
            wkSB.AppendLine("and  1=1 " & wkWhere.ToString) 'AND条件

            '-------------------------/





            Select Case iKbn
                Case 0, 1
                    '検索
                    wkSB.AppendLine("ORDER BY")
                    wkSB.AppendLine(" T.MEISYO_CD")



            End Select

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return wkSB.ToString

    End Function
#End Region
#Region "画面項目チェック"
    ''' <summary>
    ''' 画面項目チェック
    ''' </summary>
    ''' <param name="wkMode">0:検索,1:新規,2：更新、3削除,</param>
    ''' <param name="wkAlertFlag">警告メッセージを表示するか。</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Input_Check(ByVal wkMode As Integer, Optional ByVal wkAlertFlag As Boolean = True) As Boolean
        Dim ret As Boolean = False

        Try
            '==共通チェック==================


            '==必須チェック==================

            ''年度入力なし
            'If date_TaisyoNendo.Value Is Nothing Or date_TaisyoNendo.Value = New Date Then
            '    If wkAlertFlag Then Call Show_MessageBox_Add("W008", "補てん金交付対象年度")
            '    date_TaisyoNendo.Focus()
            '    Exit Try
            'End If

            Dim wkDS As New DataSet
            Dim intRow As Integer = 0       '行番号

            For Each gRow As DataGridViewRow In dgv_Search.SelectedRows
                intRow = gRow.Index
            Next
            f_Select_ODP(wkDS, "select * from TM_CODE where SYURUI_KBN = " & cob_SYURUI_KBN.Text & " and MEISYO_CD = " & dgv_Search.Item("MEISYO_CD", intRow).Value)

            Select Case wkMode
                Case 0
                    '検索

                Case 1


                Case 2
                    '変更


                    '存在チェック
                    If wkDS.Tables(0).Rows.Count = 0 Then
                        If wkAlertFlag Then Call Show_MessageBox_Add("W010", "")
                        cob_SYURUI_KBN_NM.Focus()
                        Exit Try
                    End If


                Case 3
                    '削除
                    '存在チェック

                    If wkDS.Tables(0).Rows.Count = 0 Then
                        If wkAlertFlag Then Call Show_MessageBox_Add("W013", "データはすでに削除後")
                        cob_SYURUI_KBN_NM.Focus()
                        Exit Try
                    End If
            End Select

            '==いろいろチェック==================

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "コンボボックスセット"
    ''' <summary>
    ''' コンボボックスセット
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_ComboBox_Set() As Boolean
        Dim ret As Boolean = False


        Try

            'コードマスタコンボセット
            If Not f_CodeMaster_Data_Select(cob_SYURUI_KBN, cob_SYURUI_KBN_NM, 0, True) Then
                Exit Try
            End If


            'コンボボックス初期化
            cob_SYURUI_KBN.Text = ""
            cob_SYURUI_KBN_NM.Text = ""


            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "Util"


    ''' <summary>
    ''' ＦＲＯＭＴＯ妥当性チェック
    ''' </summary>
    ''' <param name="wkFromControl"></param>
    ''' <param name="wkToControl"></param>
    ''' <param name="wkName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_CheckFromTo(ByVal wkFromControl As Object, ByVal wkToControl As Object, ByVal wkName As String, Optional ByVal wkAlertFlag As Boolean = True) As Boolean

        Try
            Select Case True
                Case (wkFromControl.Text Is Nothing And Not wkToControl.Text Is Nothing) Or (wkFromControl.Text = "" And wkToControl.Text <> "")
                    'FROM入力なし
                    If wkAlertFlag Then Call Show_MessageBox_Add("W008", wkName & "From")
                    wkFromControl.Focus()
                Case (Not wkFromControl.Text Is Nothing And wkToControl.Text Is Nothing) Or (wkFromControl.Text <> "" And wkToControl.Text = "")
                    'TO入力なし
                    If wkAlertFlag Then Call Show_MessageBox_Add("W008", wkName & "To")
                    wkToControl.Focus()

                Case IsNumeric(wkFromControl.text) AndAlso ((wkFromControl.text) <> "" And (wkToControl.text) <> "") AndAlso CDec(wkFromControl.text) > CDec(wkToControl.text)
                    'FROM>TO
                    If wkAlertFlag Then Call Show_MessageBox_Add("W003", "指定された" & wkName)
                    wkFromControl.Focus()




                Case TypeOf wkFromControl Is JBD.Gjs.Win.GcDate AndAlso ((wkFromControl.value Is Nothing And Not wkToControl.value Is Nothing) Or (wkFromControl.value = New Date And wkToControl.value <> New Date))
                    'FROM入力なし
                    If wkAlertFlag Then Call Show_MessageBox_Add("W008", wkName & "From")
                    wkFromControl.Focus()
                Case TypeOf wkFromControl Is JBD.Gjs.Win.GcDate AndAlso ((Not wkFromControl.value Is Nothing And wkToControl.value Is Nothing) Or (wkFromControl.value <> New Date And wkToControl.value = New Date))
                    'TO入力なし
                    If wkAlertFlag Then Call Show_MessageBox_Add("W008", wkName & "To")
                    wkToControl.Focus()
                Case TypeOf wkFromControl Is JBD.Gjs.Win.GcDate AndAlso (Not wkFromControl.value Is Nothing Or wkFromControl.value <> New Date) AndAlso wkFromControl.value > wkToControl.value
                    'FROM>TO
                    If wkAlertFlag Then Call Show_MessageBox_Add("W003", "指定された" & wkName)
                    wkFromControl.Focus()


                Case Else
                    'ＯＫ
                    Return True
            End Select

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return False
    End Function

    ''' <summary>
    ''' bool値を数値に変換。
    ''' </summary>
    ''' <param name="wkBool"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Bool2Num(ByVal wkBool As Boolean) As Integer
        If wkBool Then
            Return 1
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    '''文字列をDateかNothingに変換。
    ''' </summary>
    ''' <param name="wkDateStr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Str2DateOrNothing(ByVal wkDateStr As String) As Date
        Dim wkdate As New Date
        If Date.TryParse(wkDateStr, wkdate) Then
            Return wkdate
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 強制数字変換
    ''' </summary>
    ''' <param name="wkString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_toInt(ByVal wkString As String) As Integer
        Select Case True
            Case wkString Is Nothing, IsDBNull(wkString), Not (IsNumeric(wkString))
                Return 0
            Case Else
                Return CInt(wkString)
        End Select

    End Function

    ''' <summary>
    ''' 数字以外を削除
    ''' </summary>
    ''' <param name="wkStr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_NumFilter(ByVal wkStr As String) As String
        Return (New System.Text.RegularExpressions.Regex("\D")).Replace(wkStr, "")
    End Function

#End Region


#End Region




End Class
