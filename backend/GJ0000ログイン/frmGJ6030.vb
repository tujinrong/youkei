'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ6030.vb
'*
'*　　②　機能概要　　　　　各種マスタの次期対応コピー処理
'*
'*　　③　作成日　　　　　　2015/03/11 JBD368
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

Imports GrapeCity.ActiveReports.SectionReportModel
Imports GrapeCity.ActiveReports.Export
Imports GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport


Public Class frmGJ6030

#Region "*** 変数定義 ***"

    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ

    ''' <summary>
    ''' プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True                     '処理ジャンプ

    Private pKI As Integer                              '当期 対象期
    Private pZENKI_KI As Integer                        '前期 対象期
    Private pSYSDATE As Date                            'データ登録日/データ更新日
    Private pWarn As Boolean = False                    'ワーニングメッセージ表示

#End Region

#Region "*** 定数定義 ***"

    Private Const C_JIMU As Integer = 1         '事務委託先マスタコピー処理
    Private Const C_KEIYAKU As Integer = 2      '契約者マスタコピー処理
    Private Const C_NOJO As Integer = 3         '農場マスタコピー処理

    Private Const C_S_JIMU As String = "事務委託先マスタコピー処理"
    Private Const C_S_KEIYAKU As String = "契約者マスタコピー処理"
    Private Const C_S_NOJO As String = "農場マスタコピー処理"

    Private Const C_S_JIMU_D As String = "事務委託先マスタ"
    Private Const C_S_KEIYAKU_D As String = "契約者マスタ"
    Private Const C_S_NOJO_D As String = "契約者農場マスタ"

    Private Const C_WAR001 As String = "データは修正されています。再度コピー処理を実行する場合は管理者に連絡してください。"
    Private Const C_WAR002 As String = "既にコピー処理が実行されています。再処理を行いますか？"
    Private Const C_WAR003 As String = "を実行後、実行してください。"

    Private Const C_QUE001 As String = "既にコピー処理が実行されています。再処理を行いますか？"

#End Region

#Region "*** 画面制御関連 ***"

#Region "Form_Loadイベント"
    ''' <summary>
    ''' フォームロード時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmGJ6030Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean
        Try

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear("C")

            'チェンジイベント
            f_setControlChangeEvents()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

    End Sub
#End Region

#Region "f_setControlChangeEvents 変更判定イベント登録"
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

#End Region

#Region "f_setChanged コントロール変更時処理"

    ''' <summary>
    ''' コントロール変更時処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub f_setChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pblnTextChange = True
    End Sub
#End Region

#End Region

#Region "*** 画面ボタンクリック関連 ***"

#Region "cmdExec_Click 実行ボタンクリック処理"
    ''' <summary>
    ''' 実行ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdExec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExec.Click
        Dim ea As New System.ComponentModel.CancelEventArgs

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '事前チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            'システム日付取得
            pSYSDATE = Now

            'コピー処理
            Select Case numSyori.Text
                Case C_JIMU
                    '事務委託先マスタ
                    If Not f_TM_JIMUITAKU_Copy() Then
                        Exit Try
                    End If

                Case C_KEIYAKU
                    '契約者マスタ
                    If Not f_TM_KEIYAKU_Copy() Then
                        Exit Try
                    End If

                Case C_NOJO
                    '契約者農場マスタ
                    If Not f_TM_KEIYAKU_NOJO_Copy() Then
                        Exit Try
                    End If
            End Select

            '終了メッセージ表示
            Show_MessageBox("I001", "")

            '画面初期化
            Call f_ObjectClear("C")


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try
    End Sub
#End Region

#Region "cmdCancel_Click キャンセルボタンクリック処理"
    ''' <summary>
    ''' キャンセルボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Dim ret As Boolean

        Try
            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then
                    '「いいえ」を選択
                    Exit Sub
                End If
            End If
            ret = f_ObjectClear("")
            '処理選択にフォーカスセット
            numSyori.Focus()
            pblnTextChange = False             '画面入力内容変更フラグ初期化

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try
    End Sub

#End Region

#Region "cmdEnd_Click 戻るボタンクリック処理"

    ''' <summary>
    ''' 戻るボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try
            'If pblnTextChange Then
            '    '画面に変更があり保存していない場合は、メッセージ表示
            '    If Show_MessageBox("Q007", "") = DialogResult.No Then
            '        Exit Try
            '    End If
            'Else
            If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                '処理を終了しますか？
                Exit Try
            End If
            'End If

            pblnTextChange = False      '画面入力内容変更フラグ初期化
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

#End Region

#Region "*** 画面コントロール制御関連 ***"
#End Region

#Region "*** ローカル関数 ***"

#Region "f_ObjectClear 画面クリア処理"
    ''' <summary>
    ''' 画面クリア
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

            '画面内容をセット
            If Not f_SetForm_Data() Then
                Exit Try
            End If

            '画面変更フラグ
            pblnTextChange = False

            '先頭入力へ
            numSyori.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Function
#End Region

#Region "f_SetForm_Data データ画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_Data
    '説明            :データ画面セット処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_Data() As Boolean
        Dim ret As Boolean = False

        Try

            Dim objTM_SYORI_NENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI
            '初期値設定
            '当期 対象期
            pKI = objTM_SYORI_NENDO_KI.pKI
            '前期 対象期
            pZENKI_KI = pKI - 1

            '対象期
            lblKI.Text = pZENKI_KI

            '事務委託先
            lblJimuKi.Text = "（" & pKI.ToString & "期）"
            If Not f_DataCount("TM_JIMUITAKU", lblJimuKensu) Then
                Return False
            End If

            '契約者
            lblKeiyakuKi.Text = "（" & pKI.ToString & "期）"
            If Not f_DataCount("TM_KEIYAKU", lblKeiyakuKensu) Then
                Return False
            End If

            '契約者農場
            lblNojoKi.Text = "（" & pKI.ToString & "期）"
            If Not f_DataCount("TM_KEIYAKU_NOJO", lblNojoKensu) Then
                Return False
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
    ''' <summary>
    ''' 画面入力チェック処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Input_Check() As Boolean
        Dim wkControlName As String = String.Empty
        Dim wkMessage As String = String.Empty

        Try

            ''==必須チェック==================
            wkControlName = "処理選択"
            If numSyori.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numSyori.Focus() : Return False
            End If


            '==いろいろチェック==================

            'マスタ選択
            Select Case numSyori.Text
                Case "1", "2", "3"

                Case Else
                    '1,2,3以外が入力された場合はエラー
                    Call Show_MessageBox("W006", "") : numSyori.Focus() : Return False
            End Select

            '１：事務委託先マスタコピー処理が選択されている場合
            If numSyori.Text = C_JIMU Then
                If lblJimuKensu.Text = "0" Then
                    '初回実行の場合は以降のチェックはなし
                    Return True
                End If
                '共通エラーチェック
                If Not f_CheckSyori("TM_JIMUITAKU", lblJimuKensu) Then
                    Return False
                End If
            End If

            '２：契約者マスタコピー処理が選択されている場合
            If numSyori.Text = C_KEIYAKU Then
                '事前に事務委託先マスタコピーが完了しているかチェック
                If lblKeiyakuKensu.Text = "0" And lblJimuKensu.Text = "0" Then
                    wkMessage = ""
                    wkMessage = C_S_KEIYAKU & "は、" & C_S_JIMU & C_WAR003
                    Call Show_MessageBox_Add("W019", wkMessage) : numSyori.Focus() : Return False
                End If
                If lblKeiyakuKensu.Text = "0" Then
                    '初回実行の場合は以降のチェックはなし
                    Return True
                End If

                '共通エラーチェック
                If Not f_CheckSyori("TM_KEIYAKU", lblKeiyakuKensu) Then
                    Return False
                End If
            End If

            '３：農場マスタコピー処理が選択されている場合
            If numSyori.Text = C_NOJO Then
                '事前に契約者マスタコピーが完了しているかチェック
                If lblNojoKensu.Text = "0" And lblKeiyakuKensu.Text = "0" Then
                    wkMessage = ""
                    wkMessage = C_S_NOJO & "は、" & C_S_KEIYAKU & C_WAR003
                    Call Show_MessageBox_Add("W019", wkMessage) : numSyori.Focus() : Return False
                End If
                If lblNojoKensu.Text = "0" Then
                    '初回実行の場合は以降のチェックはなし
                    Return True
                End If

                '共通エラーチェック
                If Not f_CheckSyori("TM_KEIYAKU_NOJO", lblNojoKensu) Then
                    Return False
                End If
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return True

    End Function

#End Region

#Region "f_DataCount データ件数取得"
    ''' <summary>
    ''' データ件数取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_DataCount(ByVal tbl As String, ByVal lblKensu As JBD.Gjs.Win.JLabel) As Boolean

        Try
            '引数に指定のテーブルのデータ件数を取得する
            Dim dsMaster As DataSet = New DataSet
            Dim sSql As String = String.Empty
            sSql = sSql & "SELECT " & vbCrLf
            sSql = sSql & " COUNT(*) CNT " & vbCrLf
            sSql = sSql & "FROM " & vbCrLf
            sSql = sSql & " " & tbl & " TM " & vbCrLf
            sSql = sSql & "WHERE " & vbCrLf
            sSql = sSql & " TM.KI = " & pKI & vbCrLf

            If Not f_Select_ODP(dsMaster, sSql) Then
                Return False
            End If

            If dsMaster.Tables(0).Rows.Count = 0 Then
                '該当データなし
                lblKensu.Text = 0
            Else
                '該当データありの場合、件数を表示
                lblKensu.Text = Format(dsMaster.Tables(0).Rows(0)("CNT"), "#,##0")
            End If


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
            Return False
        End Try

        Return True

    End Function

#End Region

#Region "f_CheckSyori 処理共通チェック処理"
    ''' <summary>
    ''' 処理共通チェック処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_CheckSyori(ByVal tbl As String, ByVal lblKensu As JBD.Gjs.Win.JLabel) As Boolean

        '変数初期化
        pWarn = False

        Try
            '引数に指定のテーブルのデータ件数を取得する
            Dim dsMaster As DataSet = New DataSet
            Dim sSql As String = String.Empty
            sSql = sSql & "SELECT " & vbCrLf
            sSql = sSql & "   TM.REG_DATE " & vbCrLf
            sSql = sSql & " , TM.UP_DATE "
            sSql = sSql & "FROM " & vbCrLf
            sSql = sSql & " " & tbl & " TM " & vbCrLf
            sSql = sSql & "WHERE " & vbCrLf
            sSql = sSql & " TM.KI = " & pKI & vbCrLf
            sSql = sSql & "GROUP BY " & vbCrLf
            sSql = sSql & "   TM.REG_DATE " & vbCrLf
            sSql = sSql & " , TM.UP_DATE"

            If Not f_Select_ODP(dsMaster, sSql) Then
                Return False
            End If

            If dsMaster.Tables(0).Rows.Count >= 2 Then
                Dim wkMessage As String = String.Empty
                Select Case numSyori.Text
                    Case "1"
                        '事務委託先マスタコピー
                        wkMessage = C_S_JIMU_D
                    Case "2"
                        '契約者マスタコピー
                        wkMessage = C_S_KEIYAKU_D
                    Case "3"
                        '農場マスタコピー
                        wkMessage = C_S_NOJO_D
                End Select
                '該当データが2件以上の場合、エラー
                Call Show_MessageBox_Add("W019", wkMessage & C_WAR001) : numSyori.Focus() : Return False

            ElseIf dsMaster.Tables(0).Rows.Count = 1 Then
                '該当データが1件でかつ処理件数が0件以上の場合、ワーニング
                If lblKensu.Text <> "0" Then
                    pWarn = True
                End If
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
            Return False
        End Try

        Return True

    End Function

#End Region

#Region "f_TM_JIMUITAKU_Copy 事務委託先マスタコピー処理"
    ''' <summary>
    ''' 事務委託先マスタコピー処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_TM_JIMUITAKU_Copy() As Boolean

        Dim Cmd As New OracleCommand
        Try

            '実行確認
            If pWarn Then
                pWarn = False
                If Show_MessageBox_Add("Q012", C_QUE001) = DialogResult.No Then
                    Return False
                End If
            Else
                If Show_MessageBox_Add("Q013", C_S_JIMU & "を実行します") = DialogResult.No Then
                    Return False
                End If
            End If



            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.CommandText = "PKG_GJ6030.GJ6030_JIMUITAKU_COPY"
            Cmd.Parameters.Add("IN_KI", pKI)
            Cmd.Parameters.Add("IN_ZENKI_KI", pZENKI_KI)
            Cmd.Parameters.Add("IN_DATE", pSYSDATE)
            Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
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


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
            Return False
        End Try

        Return True
    End Function
#End Region

#Region "f_TM_KEIYAKU_Copy 契約者マスタコピー処理"
    ''' <summary>
    ''' 契約者マスタコピー処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_TM_KEIYAKU_Copy() As Boolean
        Dim Cmd As New OracleCommand

        Try

            '実行確認
            If pWarn Then
                pWarn = False
                If Show_MessageBox_Add("Q012", C_QUE001) = DialogResult.No Then
                    Return False
                End If
            Else
                If Show_MessageBox_Add("Q013", C_S_KEIYAKU & "を実行します") = DialogResult.No Then
                    Return False
                End If
            End If

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.CommandText = "PKG_GJ6030.GJ6030_KEIYAKU_COPY"
            Cmd.Parameters.Add("IN_KI", pKI)
            Cmd.Parameters.Add("IN_ZENKI_KI", pZENKI_KI)
            Cmd.Parameters.Add("IN_DATE", pSYSDATE)
            Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
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


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
            Return False
        End Try

        Return True
    End Function
#End Region

#Region "f_TM_KEIYAKU_NOJO_Copy 農場マスタコピー処理"
    ''' <summary>
    ''' 農場マスタコピー処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_TM_KEIYAKU_NOJO_Copy() As Boolean

        Dim Cmd As New OracleCommand
        Try
            '実行確認
            If pWarn Then
                pWarn = False
                If Show_MessageBox_Add("Q012", C_QUE001) = DialogResult.No Then
                    Return False
                End If
            Else
                If Show_MessageBox_Add("Q013", C_S_NOJO & "を実行します") = DialogResult.No Then
                    Return False
                End If
            End If

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.CommandText = "PKG_GJ6030.GJ6030_NOJO_COPY"
            Cmd.Parameters.Add("IN_KI", pKI)
            Cmd.Parameters.Add("IN_ZENKI_KI", pZENKI_KI)
            Cmd.Parameters.Add("IN_DATE", pSYSDATE)
            Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
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


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
            Return False
        End Try

        Return True
    End Function

#End Region

#End Region

#Region "Util"

    ''' <summary>
    ''' bool値を数値に変換。
    ''' </summary>
    ''' <param name="wkBool"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
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
