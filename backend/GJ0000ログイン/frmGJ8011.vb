'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ8011.vb
'*
'*　　②　機能概要　　　　　コードマスタメンテナンス
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

Public Class frmGJ8011

#Region "***変数定義***"


    ''' <summary>
    ''' グリッドキーリスト
    ''' </summary>
    ''' <remarks></remarks>
    Public paryKEY_8010 As New List(Of frmGJ8010.T_KEY)

    ''' <summary>
    ''' カレント主キー
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pCurrentKey As frmGJ8010.T_KEY

    ''' <summary>
    ''' 行No
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pSel_NO As Integer


    ''' <summary>
    '''  画面入力内容変更フラグ
    ''' </summary>
    ''' <remarks></remarks>
    Private loblnTextChange As Boolean                   '画面入力内容変更フラグ



    ''' <summary>
    ''' データ更新時刻避難用DATE
    ''' </summary>
    ''' <remarks></remarks>
    Private lo_REG_DATE As Date = Nothing
    ''' <summary>
    ''' データ更新時避難用ID
    ''' </summary>
    ''' <remarks></remarks>
    Private lo_REG_ID As String = ""

    ''' <summary>
    ''' 補てん金計算日
    ''' </summary>
    ''' <remarks></remarks>
    Private lo_KeisanDate As Date



    ''' <summary>
    ''' 受理日
    ''' </summary>
    ''' <remarks></remarks>
    Private loJYURI_DATE As Date
    ''' <summary>
    ''' 受理日
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pJYURI_DATE() As Date
        Get
            Return loJYURI_DATE
        End Get
        Set(ByVal value As Date)
            loJYURI_DATE = value
        End Set
    End Property

    ''' <summary>
    ''' 新規/更新モード
    ''' </summary>
    ''' <remarks></remarks>
    Enum enuMode
        search = 0
        Insert = 1
        Update = 2
    End Enum

    ''' <summary>
    ''' 現在モード
    ''' </summary>
    ''' <remarks></remarks>
    Friend loMode As enuMode = enuMode.search
#End Region

#Region "***画面制御関連***"

    ''' <summary>
    ''' フォームロード時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmGJ8011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean
        Try

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear()


            '★初期コントロールにフォーカスセット
            cob_MEISYO_CD.Focus()
            If loMode = enuMode.Update Then
                '画面内容をセット
                If Not f_SetForm_Data(pCurrentKey) Then
                    Exit Try
                End If
            Else
                lbl_SYURUI_KBN_NM.Text = pCurrentKey.SYURUI_KBN_NM
            End If

            f_setControlChangeEvents()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

    End Sub

    ''' <summary>
    ''' 変更判定イベント登録
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub f_setControlChangeEvents()
        For Each wkCtrl In Me.Controls
            Select Case True
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcComboBox
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcComboBox).TextChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcDate
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcDate).TextChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcMask
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcMask).TextChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcNumber
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcNumber).TextChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GcTextBox
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.GcTextBox).TextChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.RadioButton
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.RadioButton).CheckedChanged, AddressOf f_setChanged
                Case TypeOf wkCtrl Is JBD.Gjs.Win.CheckBox
                    AddHandler DirectCast(wkCtrl, JBD.Gjs.Win.CheckBox).CheckedChanged, AddressOf f_setChanged


            End Select
        Next
    End Sub

    ''' <summary>
    ''' コントロール変更時処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub f_setChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        loblnTextChange = True
    End Sub

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

            '====初期値設定======================


            ''事業対象年度取得
            'date_TaisyoNendo.Value = New frmPF1010.Obj_TM_SYORI_NENDO().pJIGYO_NENDO_byDate
            Select Case loMode
                Case enuMode.Insert
                    cob_MEISYO_CD.Enabled = True
                Case enuMode.Update
                    cob_MEISYO_CD.Enabled = False
            End Select



            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function

#End Region


#Region "***画面ボタンクリック関連***"

    ''' <summary>
    ''' 保存ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTouroku.Click
        Dim ea As New System.ComponentModel.CancelEventArgs
        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '事前チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '保存処理確認
            If Show_MessageBox_Add("Q003", "") = DialogResult.No Then    '保存します。よろしいですか？
                Exit Try
            End If


            'データ保存処理
            If Not f_Data_Update() Then
                Exit Try
            End If
            loblnTextChange = False
            '報告
            Show_MessageBox_Add("I001")
            Me.cmdEnd_Click(sender, New EventArgs)

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    ''' <summary>
    ''' 終了ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try
            If loblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then
                    Exit Try
                End If
            End If

            '親フォームに現在選択されている行のキーを渡します
            DirectCast(Owner, frmGJ8010).pSel_POS = pSel_NO - 1

            loblnTextChange = False      '画面入力内容変更フラグ初期化
            'フォームクローズ
            Me.AutoValidate = AutoValidate.Disable
            Me.Close()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'フォームクローズ
            Me.Close()
        End Try

    End Sub

#End Region

#Region "*** 画面コントロール制御関連 ***"

#End Region

#Region "*** データ登録関連 ***"


    ''' <summary>
    '''データ更新処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Data_Update() As Boolean
        Dim ret As Boolean = False

        Try

            '登録＆取り消し
            If Not f_TM_CODE_Update() Then
                Exit Try
            End If


            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

    ''' <summary>
    ''' 交付実績更新処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_TM_CODE_Update() As Boolean
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Select Case loMode
                Case enuMode.Update
                    Cmd.CommandText = "PKG_GJ8011.GJ8011_CODE_UPD"
                Case enuMode.Insert
                    Cmd.CommandText = "PKG_GJ8011.GJ8011_CODE_INS"
                    lo_REG_DATE = Now
                    lo_REG_ID = pLOGINUSERID
            End Select
            Cmd.Parameters.Add("IN_SYURUI_KBN", pCurrentKey.SYURUI_KBN)
            Cmd.Parameters.Add("IN_MEISYO_CD", cob_MEISYO_CD.Text)
            Cmd.Parameters.Add("IN_MEISYO", txt_MEISYO.Text)
            Cmd.Parameters.Add("IN_RYAKUSYO", txtRYAKUSYO.Text)
            Cmd.Parameters.Add("IN_REG_DATE", lo_REG_DATE)
            Cmd.Parameters.Add("IN_REG_ID", lo_REG_ID)
            Cmd.Parameters.Add("IN_UP_DATE", Now)
            Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)


            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Throw New Exception(Cmd.Parameters("OU_MSGCD").Value.ToString() & ":" & Cmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            If ex.Message <> "Err" Then
                Show_MessageBox("", ex.Message)
            End If
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
        End Try

        Return ret
    End Function

#End Region

#Region "***ローカル関数***"

    ''' <summary>
    ''' ＦＲＯＭＴＯ妥当性チェック
    ''' </summary>
    ''' <param name="wkFromControl"></param>
    ''' <param name="wkToControl"></param>
    ''' <param name="wkName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_CheckFromTo(ByVal wkFromControl As Object, ByVal wkToControl As Object, ByVal wkName As String) As Boolean

        Try
            Select Case True
                Case (wkFromControl.Text Is Nothing And Not wkToControl.Text Is Nothing) Or (wkFromControl.Text = "" And wkToControl.Text <> "")
                    'FROM入力なし
                    Call Show_MessageBox_Add("W008", wkName & "From")
                    wkFromControl.Focus()
                Case (Not wkFromControl.Text Is Nothing And wkToControl.Text Is Nothing) Or (wkFromControl.Text <> "" And wkToControl.Text = "")
                    'TO入力なし
                    Call Show_MessageBox_Add("W008", wkName & "To")
                    wkToControl.Focus()

                Case ((wkFromControl.text) <> "" And (wkToControl.text) <> "") AndAlso CDec(wkFromControl.text) > CDec(wkToControl.text)
                    'FROM>TO
                    Call Show_MessageBox_Add("W003", "指定された" & wkName)
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
    ''' 画面入力チェック処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Input_Check() As Boolean
        Dim ret As Boolean = False
        Dim wkControlName As String

        Try
            '==FromToチェック==================
            ''都道府県
            'If f_CheckFromTo(cob_KenCdFm, cob_KenCdTo, "都道府県") = False Then
            '    Return False
            'End If


            '==必須チェック==================

            wkControlName = "名称コード"
            If cob_MEISYO_CD.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : cob_MEISYO_CD.Focus() : Exit Try
            End If
            wkControlName = "名称"
            If txt_MEISYO.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : txt_MEISYO.Focus() : Exit Try
            End If
            wkControlName = "略称"
            If txtRYAKUSYO.Text = "" Then
                Call Show_MessageBox_Add("W008", wkControlName) : txtRYAKUSYO.Focus() : Exit Try
            End If




            '==いろいろチェック==================

            Dim wkDS As New DataSet


            '登録時チェック
            f_Select_ODP(wkDS, "select 1 from TM_CODE where " &
                                " SYURUI_KBN       = " & pCurrentKey.SYURUI_KBN &
                                " and MEISYO_CD = " & cob_MEISYO_CD.Text &
                                "")
            Select Case loMode
                Case enuMode.Insert

                    'データがすでに登録済み
                    If wkDS.Tables(0).Rows.Count <> 0 Then
                        Call Show_MessageBox("W001", "")
                        Return False
                    End If
                Case enuMode.Update

                    'データがすでに削除済み
                    If wkDS.Tables(0).Rows.Count = 0 Then
                        Call Show_MessageBox("W002", "")
                        Return False
                    End If
            End Select



            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

    ''' <summary>
    ''' フォームデータセット
    ''' </summary>
    ''' <param name="wkKey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_SetForm_Data(ByVal wkKey As frmGJ8010.T_KEY) As Boolean
        Dim ret As Boolean = False
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim wkDS As New DataSet
        Dim wkSb As New StringBuilder

        wkSb.AppendLine("select")
        wkSb.AppendLine("     T.SYURUI_KBN")
        wkSb.AppendLine("     ,KBN.MEISYO as SYURYUI_KBN_NM")
        wkSb.AppendLine("     ,T.MEISYO")
        wkSb.AppendLine("     ,T.MEISYO_CD")
        wkSb.AppendLine("     ,T.RYAKUSYO")
        wkSb.AppendLine("    , T.REG_DATE ")
        wkSb.AppendLine("    , T.REG_ID ")

        wkSb.AppendLine("  from")
        wkSb.AppendLine("    TM_CODE T ")
        wkSb.AppendLine("    left join TM_CODE  KBN")
        wkSb.AppendLine("      on 1 = 1 ")
        wkSb.AppendLine("      and KBN.SYURUI_KBN = 0 ")
        wkSb.AppendLine("      and KBN.MEISYO_CD = T.SYURUI_KBN ")



        wkSb.AppendLine("where " &
                     " T.SYURUI_KBN       = " & pCurrentKey.SYURUI_KBN &
                     " and T.MEISYO_CD = " & pCurrentKey.MEISYO_CD &
                    "")

        'DBからデータを取得
        If f_Select_ODP(wkDS, wkSb.ToString) = False Then
            Return False
        End If




        Try

            With wkDS.Tables(0)
                lbl_SYURUI_KBN_NM.Text = .Rows(0)("SYURYUI_KBN_NM").ToString
                cob_MEISYO_CD.Text = .Rows(0)("MEISYO_CD").ToString
                txt_MEISYO.Text = .Rows(0)("MEISYO").ToString
                txtRYAKUSYO.Text = .Rows(0)("RYAKUSYO").ToString


                '初回登録時刻＆初回登録ID避難用
                lo_REG_DATE = f_Str2DateOrNothing(WordHenkan("N", "S", .Rows(0)("REG_DATE").ToString))
                lo_REG_ID = WordHenkan("N", "S", .Rows(0)("REG_ID"))
            End With

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



End Class
