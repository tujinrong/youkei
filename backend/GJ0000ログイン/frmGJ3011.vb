'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmEM2030.vb
'*
'*　　②　機能概要　　　　　互助基金契約者情報変更（増羽）請求書発行
'*
'*　　③　作成日　　　　　　2015/02/06　BY JBD
'*
'*　　④　更新日            2023/08/08  BY JBD454
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

Public Class frmGJ3011

#Region "*** 変数定義 ***"


    ''' <summary>
    ''' カレント主キー
    ''' </summary>
    ''' <remarks></remarks>
    Property pCurrentKey As frmGJ3010.T_KEY

    ''' <summary>
    ''' リスト用
    ''' </summary>
    ''' <remarks></remarks>
    Public pRptName As String = "互助基金契約羽数増加請求書（増羽）"     '帳票名

    ''' <summary>
    ''' その他変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True                     '処理ジャンプ


    Private pDataSet As New DataSet                     'マスタ用データセット
    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ
    Private pFlag As Integer

#End Region

#Region "*** 画面制御関連 ***"

#Region "frmEM2030_Load Form_Loadイベント"

    '------------------------------------------------------------------
    'プロシージャ名  :frmEM2030_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmEM2030_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean

        Try

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

#Region "frmEM2030_Disposed Form_Disposedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmEM2030_Disposed
    '説明            :Form_Disposedイベント
    '------------------------------------------------------------------
    Private Sub frmEM2030_Disposed(ByVal sender As Object, ByVal e As System.EventArgs)

        pDataSet.Clear()
        pDataSet.Dispose()

    End Sub
#End Region

#End Region

#Region "*** 画面ボタンクリック関連 ***"

#Region "cmdPreview_Click プレビューボタンクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdPreview_Click
    '説明            :プレビューボタンクリック時処理
    '------------------------------------------------------------------
    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click

        Try
            'マウスカーソルを砂時計に変更
            Me.Cursor = Cursors.WaitCursor

            'チェック
            If f_Input_Check_Previw() = False Then
                Exit Try
            End If

            '採択通知書発行処理の更新確認メッセージ
            If Show_MessageBox_Add("Q012", "請求書の発行を行ってもよろしいですか？") = DialogResult.No Then    '@0
                Exit Try
            End If

            'データ更新処理
            If rbtn_SYORI_KBN0.Checked Then
                '仮請求
                If Not f_Data_Save0() Then
                    Exit Try
                End If
            ElseIf rbtn_SYORI_KBN1.Checked Then
                '初回請求
                If Not f_Data_Save1() Then
                    Exit Try
                End If
            ElseIf rbtn_SYORI_KBN2.Checked Then
                '再発行
                If Not f_Data_Save2() Then
                    Exit Try
                End If
            ElseIf rbtn_SYORI_KBN3.Checked Then
                '修正発行
                If Not f_Data_Save3() Then
                    Exit Try
                End If
            Else
                Exit Try
            End If

            '帳票出力処理
            If Not f_Report_Output() Then
                Exit Try
            End If

            '画面再表示 
            If rbtn_SYORI_KBN1.Checked Then
                f_InitSet()
                f_SyotiKbnEnable()
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルをデフォルトに戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub
#End Region
#Region "cmdTorikesi_Click 請求取消ボタンクリック時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdTorikesi_Click
    '説明            :請求取消ボタンクリック時処理
    '------------------------------------------------------------------
    Private Sub cmdTorikesi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTorikesi.Click
        Try
            'マウスカーソルを砂時計に変更
            Me.Cursor = Cursors.WaitCursor

            'チェック
            If f_Input_Check_Torikesi() = False Then
                Exit Try
            End If

            '採択通知書発行処理の更新確認メッセージ
            If Show_MessageBox_Add("Q012", "請求書の取消を行ってもよろしいですか？") = DialogResult.No Then    '@0
                Exit Try
            End If

            'データ更新処理
            If Not f_Data_Save4() Then
                Exit Try
            End If

            '画面再表示 
            pCurrentKey.SEIKYU_KAISU = ""
            f_InitSet()
            f_SyotiKbnEnable()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルをデフォルトに戻す
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
        Dim ret As Boolean = False

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try
            '画面初期表示
            ret = f_ObjectClear("")

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
                rbtn_SYORI_KBN0.CheckedChanged, rbtn_SYORI_KBN1.CheckedChanged,
                rbtn_SYORI_KBN2.CheckedChanged, rbtn_SYORI_KBN3.CheckedChanged,
                rbtn_SYORI_KBN4.CheckedChanged

        If pJump Then
            Exit Sub
        End If

        '入力制御
        If (sender.Equals(rbtn_SYORI_KBN0) AndAlso rbtn_SYORI_KBN0.Checked) Then
            '仮請求
            f_JokenEnable(False)
            f_cmdPreviewEnable(True)
            f_SeikyuJohoClr(0)
        ElseIf (sender.Equals(rbtn_SYORI_KBN1) AndAlso rbtn_SYORI_KBN1.Checked) Then
            '初回請求
            f_JokenEnable(True)
            f_cmdPreviewEnable(True)
            f_SeikyuJohoClr(1)
        ElseIf (sender.Equals(rbtn_SYORI_KBN2) AndAlso rbtn_SYORI_KBN2.Checked) Then
            '再発行
            f_JokenEnable(False)
            f_cmdPreviewEnable(True)
            f_SeikyuJoho()
        ElseIf (sender.Equals(rbtn_SYORI_KBN3) AndAlso rbtn_SYORI_KBN3.Checked) Then
            '修正発行
            f_JokenEnable(True)
            f_cmdPreviewEnable(True)
            f_SeikyuJoho()
        ElseIf (sender.Equals(rbtn_SYORI_KBN4) AndAlso rbtn_SYORI_KBN4.Checked) Then
            '初回発行・修正発行 '仮発行・再発行
            f_JokenEnable(False)
            f_cmdPreviewEnable(False)
            f_SeikyuJoho()
        End If

    End Sub
#End Region

#End Region

#Region "*** データ登録関連 ***"

#Region "f_Data_Save0 仮請求処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Save0
    '説明            :仮請求処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Save0() As Boolean
        Dim ret As Boolean = False
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ3011.GJ3011_KARI_SEIKYU"

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", pCurrentKey.KI)

            '回数
            If pCurrentKey.SEIKYU_KAISU = "" Then
                Dim paraSEIKYU_KAISU As OracleParameter = Cmd.Parameters.Add("IN_SEIKYU_KAISU", DBNull.Value)
            Else
                Dim paraSEIKYU_KAISU As OracleParameter = Cmd.Parameters.Add("IN_SEIKYU_KAISU", CInt(pCurrentKey.SEIKYU_KAISU))
            End If
            '契約者番号 県コード＋連番３桁    
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", pCurrentKey.KEIYAKUSYA_CD)
            '契約年月日From  
            Cmd.Parameters.Add("KEIYAKU_DATE_FROM", pCurrentKey.KEIYAKU_DATE_FROM)
            '契約年月日To 
            Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", pCurrentKey.KEIYAKU_DATE_TO)
            '契約区分　1:家族 2:企業 3:うずら 
            Cmd.Parameters.Add("IN_KEIYAKU_KBN", pCurrentKey.KEIYAKU_KBN)

            '----------------------------------------
            '   共通情報
            '----------------------------------------
            'データ登録日    
            Cmd.Parameters.Add("IN_REG_DATE", wNow)
            'データ登録ＩＤ   
            Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
            'データ更新日    
            Cmd.Parameters.Add("IN_UP_DATE", wNow)
            'データ更新ＩＤ    
            Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            'コンピュータ名 
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
#Region "f_Data_Save1 初回請求処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Save1
    '説明            :初回請求処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Save1() As Boolean
        Dim ret As Boolean = False
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ3011.GJ3011_SYOKAI_SEIKYU"

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Cmd.Parameters.Add("IN_KI", pCurrentKey.KI)
            '請求回数
            Cmd.Parameters.Add("IN_SEIKYU_KAISU", DBNull.Value)
            '契約者番号 県コード＋連番３桁    
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", pCurrentKey.KEIYAKUSYA_CD)
            '契約年月日From  
            Cmd.Parameters.Add("KEIYAKU_DATE_FROM", pCurrentKey.KEIYAKU_DATE_FROM)
            '契約年月日To 
            Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", pCurrentKey.KEIYAKU_DATE_TO)
            '契約区分　1:家族 2:企業 3:うずら 
            Cmd.Parameters.Add("IN_KEIYAKU_KBN", pCurrentKey.KEIYAKU_KBN)

            '納付期限（振込予定日）
            Cmd.Parameters.Add("IN_NOFUKIGEN_DATE", f_DateTrim(date_KIGEN_DATE.Value))
            '請求書発行日
            Cmd.Parameters.Add("IN_SEIKYU_HAKKO_DATE", f_DateTrim(date_HAKKO_DATE.Value))
            '請求書発行番号(年)
            Cmd.Parameters.Add("IN_SEIKYU_HAKKO_NO_NEN", txt_SEIKYU_HAKKO_NO_NEN.Text.Trim)
            '請求書発行番号(連番)
            Cmd.Parameters.Add("IN_SEIKYU_HAKKO_NO_RENBAN", txt_SEIKYU_HAKKO_NO_RENBAN.Text.Trim)

            '----------------------------------------
            '   共通情報
            '----------------------------------------
            'データ登録日    
            Cmd.Parameters.Add("IN_REG_DATE", wNow)
            'データ登録ＩＤ   
            Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
            'データ更新日    
            Cmd.Parameters.Add("IN_UP_DATE", wNow)
            'データ更新ＩＤ    
            Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            'コンピュータ名 
            Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)

            '戻り
            Dim p_SEIKYU_KAISU As OracleParameter = Cmd.Parameters.Add("OU_SEIKYU_KAISU", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Throw New Exception(Cmd.Parameters("OU_MSGCD").Value.ToString() & ":" & Cmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            '請求回数
            pCurrentKey.SEIKYU_KAISU = Cmd.Parameters("OU_SEIKYU_KAISU").Value.ToString()

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
#Region "f_Data_Save2 再発行処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Save2
    '説明            :再発行処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Save2() As Boolean
        Dim ret As Boolean = False
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ3011.GJ3011_SAI_HAKKO"

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Cmd.Parameters.Add("IN_KI", pCurrentKey.KI)
            '請求回数
            Cmd.Parameters.Add("IN_SEIKYU_KAISU", pCurrentKey.SEIKYU_KAISU)
            '契約者番号 県コード＋連番３桁    
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", pCurrentKey.KEIYAKUSYA_CD)

            '----------------------------------------
            '   共通情報
            '----------------------------------------
            'データ更新日    
            Cmd.Parameters.Add("IN_UP_DATE", wNow)
            'データ更新ＩＤ    
            Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            'コンピュータ名 
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
#Region "f_Data_Save3 修正発行処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Save3
    '説明            :修正発行処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Save3() As Boolean
        Dim ret As Boolean = False
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ3011.GJ3011_SYUSEI_HAKKO"

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Cmd.Parameters.Add("IN_KI", pCurrentKey.KI)
            '請求回数
            Cmd.Parameters.Add("IN_SEIKYU_KAISU", pCurrentKey.SEIKYU_KAISU)
            '契約者番号 県コード＋連番３桁    
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", pCurrentKey.KEIYAKUSYA_CD)

            '納付期限（振込予定日）
            Cmd.Parameters.Add("IN_NOFUKIGEN_DATE", f_DateTrim(date_KIGEN_DATE.Value))
            '請求書発行日
            Cmd.Parameters.Add("IN_SEIKYU_HAKKO_DATE", f_DateTrim(date_HAKKO_DATE.Value))
            '請求書発行番号(年)
            Cmd.Parameters.Add("IN_SEIKYU_HAKKO_NO_NEN", txt_SEIKYU_HAKKO_NO_NEN.Text.Trim)
            '請求書発行番号(連番)
            Cmd.Parameters.Add("IN_SEIKYU_HAKKO_NO_RENBAN", txt_SEIKYU_HAKKO_NO_RENBAN.Text.Trim)

            '----------------------------------------
            '   共通情報
            '----------------------------------------
            'データ更新日    
            Cmd.Parameters.Add("IN_UP_DATE", wNow)
            'データ更新ＩＤ    
            Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            'コンピュータ名 
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
#Region "f_Data_Save4 請求取消処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Save4
    '説明            :請求取消処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Data_Save4() As Boolean
        Dim ret As Boolean = False
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ3011.GJ3011_SEIKYU_TORIKESI"

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Cmd.Parameters.Add("IN_KI", pCurrentKey.KI)
            '請求回数
            Cmd.Parameters.Add("IN_SEIKYU_KAISU", pCurrentKey.SEIKYU_KAISU)
            '契約者番号 県コード＋連番３桁    
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", pCurrentKey.KEIYAKUSYA_CD)

            '契約年月日From  
            Cmd.Parameters.Add("KEIYAKU_DATE_FROM", pCurrentKey.KEIYAKU_DATE_FROM)
            '契約年月日To 
            Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", pCurrentKey.KEIYAKU_DATE_TO)


            '----------------------------------------
            '   共通情報
            '----------------------------------------
            'データ登録日    
            Cmd.Parameters.Add("IN_REG_DATE", wNow)
            'データ登録ＩＤ   
            Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
            'データ更新日    
            Cmd.Parameters.Add("IN_UP_DATE", wNow)
            'データ更新ＩＤ    
            Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            'コンピュータ名 
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

        f_ObjectClear = False
        Try

            f_ObjectClear = True

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '画面初期化'画面初期化
            pJump = True
            ret = f_ClearFormALL(Me, wKbn)
            pJump = False

            '契約者
            ret = f_InitSet()

            'ボタン入力制御
            If Not f_SyotiKbnEnable() Then
                Exit Try
            End If

            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function
#End Region
#Region "f_InitSet ラベルセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_InitSet
    '説明            :ラベルセット
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_InitSet() As Boolean
        Dim ret As Boolean = False
        Dim sSql As String = String.Empty
        Dim wDS As New DataSet
        Dim wStr As String = String.Empty

        Try

            '契約者
            lbl_KI.Text = "第" & pCurrentKey.KI & "期"
            lbl_KEIYAKUSYA_CD.Text = pCurrentKey.KEIYAKUSYA_CD
            lbl_KEIYAKUSYA_NM.Text = pCurrentKey.KEIYAKUSYA_NM

            ''請求回数
            'If pCurrentKey.SEIKYU_KAISU = "" Then
            '    lbl_SEIKYU_KAISU.Text = "未請求"
            '    lbl_SEIKYU_KAISU_FT.Visible = False
            'Else
            '    lbl_SEIKYU_KAISU.Text = pCurrentKey.SEIKYU_KAISU
            '    lbl_SEIKYU_KAISU_FT.Visible = True
            'End If

            ''増羽年月日
            'lbl_KEIYAKU_DATE_FROM_X.Text = pCurrentKey.KEIYAKU_DATE_FROM_X

            '協会マスタ読込
            If Not f_TM_KYOKAI_Select() Then
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
#Region "f_TM_KYOKAI_Select 機構マスタ取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_KYOKAI_Select
    '説明            :機構マスタ取得
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_TM_KYOKAI_Select() As Boolean
        Dim ret As Boolean = False
        Dim sSql As String = String.Empty
        Dim dstDataControl As New DataSet

        Try

            sSql = "SELECT HAKKO_NO_KANJI FROM TM_KYOKAI WHERE KYOKAI_KBN = 1" & vbCrLf

            Call f_Select_ODP(dstDataControl, sSql)

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

#Region "f_SeikyuJoho 請求情報表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SeikyuJoho
    '説明            :請求情報表示処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SeikyuJoho() As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty
        Dim wDS As New DataSet
        Dim wStr As String = String.Empty

        Try

            '請求情報　初期表示
            wSql &= "SELECT * FROM TT_TUMITATE "
            wSql &= "WHERE KI = " & pCurrentKey.KI
            wSql &= "  AND SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU
            wSql &= "  AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND TUMITATE_KBN  = 1"

            Call f_Select_ODP(wDS, wSql)

            '納付期限・発効日・発信番号
            With wDS.Tables(0)
                If .Rows.Count > 0 Then
                    '納付期限
                    wStr = WordHenkan("N", "S", .Rows(0)("NOFUKIGEN_DATE"))
                    If wStr = "" Then
                        date_KIGEN_DATE.Value = Nothing
                    Else
                        date_KIGEN_DATE.Value = CDate(wStr)
                    End If
                    '請求書発行日    
                    wStr = WordHenkan("N", "S", .Rows(0)("SEIKYU_HAKKO_DATE"))
                    If wStr = "" Then
                        date_HAKKO_DATE.Value = Nothing
                    Else
                        date_HAKKO_DATE.Value = CDate(wStr)
                    End If
                    '発信番号
                    txt_SEIKYU_HAKKO_NO_NEN.Text = WordHenkan("N", "S", .Rows(0)("SEIKYU_HAKKO_NO_NEN"))
                    txt_SEIKYU_HAKKO_NO_RENBAN.Text = WordHenkan("N", "S", .Rows(0)("SEIKYU_HAKKO_NO_RENBAN"))
                    '処理状況区分
                    lbl_SYORI_JOKYO_KBN.Text = WordHenkan("N", "S", .Rows(0)("SYORI_JOKYO_KBN"))
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
#Region "f_SeikyuJoho 請求情報クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SeikyuJohoClr
    '説明            :請求情報クリア処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SeikyuJohoClr(ByVal wSyoriKbn As Integer) As Boolean
        Dim ret As Boolean = False

        Try

            '初期値
            If wSyoriKbn = 1 Then
                If date_HAKKO_DATE.Value Is Nothing Then
                    date_HAKKO_DATE.Value = CDate(Format(Now, "yyyy/MM/dd"))
                End If
            Else
                date_KIGEN_DATE.Text = ""
                date_HAKKO_DATE.Text = ""
                txt_SEIKYU_HAKKO_NO_NEN.Text = ""
                txt_SEIKYU_HAKKO_NO_RENBAN.Text = ""
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_SyotiKbnEnable 処理区分入力制御"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SyotiKbnEnable
    '説明            :処理区分入力制御
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SyotiKbnEnable() As Boolean
        Dim ret As Boolean = False

        Try

            '入力中のときは、仮請求のみ
            If pCurrentKey.SYORI_KBN = 1 Then
                '入力中のとき、仮請求のみ
                rbtn_SYORI_KBN0.Enabled = True
                rbtn_SYORI_KBN1.Enabled = False
                rbtn_SYORI_KBN2.Enabled = False
                rbtn_SYORI_KBN3.Enabled = False
                rbtn_SYORI_KBN4.Enabled = False
                '初期値
                rbtn_SYORI_KBN0.Checked = True
            ElseIf pCurrentKey.SEIKYU_KAISU = "" Then
                '未請求のとき、仮請求、初回請求
                rbtn_SYORI_KBN0.Enabled = True
                rbtn_SYORI_KBN1.Enabled = True
                rbtn_SYORI_KBN2.Enabled = False
                rbtn_SYORI_KBN3.Enabled = False
                rbtn_SYORI_KBN4.Enabled = False
                '初期値
                rbtn_SYORI_KBN0.Checked = True
            Else
                '請求済のとき、再発行、修正発行、取消
                rbtn_SYORI_KBN0.Enabled = False
                rbtn_SYORI_KBN1.Enabled = False
                rbtn_SYORI_KBN2.Enabled = True
                rbtn_SYORI_KBN3.Enabled = True
                rbtn_SYORI_KBN4.Enabled = True
                '初期値
                rbtn_SYORI_KBN2.Checked = True
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_JokenEnable 条件入力制御"
    '------------------------------------------------------------------
    'プロシージャ名  :f_JokenEnable
    '説明            :条件入力制御
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_JokenEnable(ByVal wEnable As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            '条件入力
            date_KIGEN_DATE.Enabled = wEnable
            date_HAKKO_DATE.Enabled = wEnable
            txt_SEIKYU_HAKKO_NO_NEN.Enabled = wEnable
            txt_SEIKYU_HAKKO_NO_RENBAN.Enabled = wEnable

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region
#Region "f_cmdPreviewEnable コマンドボタン入力制御"
    '------------------------------------------------------------------
    'プロシージャ名  :f_cmdPreviewEnable
    '説明            :コマンドボタン入力制御
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_cmdPreviewEnable(ByVal wEnable As Boolean) As Boolean
        Dim ret As Boolean = False

        Try

            cmdPreview.Enabled = wEnable
            cmdTorikesi.Enabled = Not wEnable

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "f_Input_Check_Previw 画面入力チェック処理(プレビュー)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check_Previw
    '説明            :画面入力チェック処理(プレビュー)
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_Previw() As Boolean
        Dim ret As Boolean = False
        Dim sSql As String = String.Empty
        Dim dstDataControl As New DataSet

        Try

            '--------------------------------------------------
            '必須入力　チェック
            '--------------------------------------------------
            If rbtn_SYORI_KBN0.Checked OrElse rbtn_SYORI_KBN2.Checked Then
            Else
                '納付期限
                If date_KIGEN_DATE.Value Is Nothing Then
                    Show_MessageBox_Add("W008", "納付期限")      '@0は必須入力項目です。
                    date_KIGEN_DATE.Focus()
                    Exit Try
                End If

                '発効日
                If date_HAKKO_DATE.Value Is Nothing Then
                    Show_MessageBox_Add("W008", "発行日")      '@0は必須入力項目です。
                    date_HAKKO_DATE.Focus()
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
            'マスタ　チェック
            '--------------------------------------------------
            '単価マスタなしの場合、エラー
            If Not f_TankaChk() Then
                Exit Try
            End If

            '2023/08/09 JBD9020 R5インボイス対応 ADD START
            '消費税率マスタなしの場合、エラー
            If Not f_SYOHIZEIRITU_Select() Then
                Exit Try
            End If
            '2023/08/09 JBD9020 R5インボイス対応 ADD END

            '--------------------------------------------------
            '請求回数　チェック
            '--------------------------------------------------
            If rbtn_SYORI_KBN0.Checked Then

                '仮発行
                If pCurrentKey.SEIKYU_KAISU <> "" Then
                    Show_MessageBox_Add("I007", "既に発行済のため仮発行できません。")    '@0
                    Exit Try
                End If

                'データ区分　チェック
                If Not F_DataKbnChk() Then
                    Exit Try
                End If

            ElseIf rbtn_SYORI_KBN1.Checked Then

                '初回発行
                If pCurrentKey.SEIKYU_KAISU <> "" Then
                    Show_MessageBox_Add("I007", "既に発行済のため初回発行できません。")   '@0
                    Exit Try
                End If

                '入力中ありの場合、エラー
                If Not f_SyoriKbnChk() Then
                    Exit Try
                End If

                'データ区分　チェック
                If Not F_DataKbnChk Then
                    Exit Try
                End If

            ElseIf rbtn_SYORI_KBN2.Checked Then
                '再発行
                If pCurrentKey.SEIKYU_KAISU = "" Then
                    Show_MessageBox_Add("I007", "まだ発行されていないため再発行できません。")    '@0
                    Exit Try
                End If

                '請求済みなしの場合、エラー
                If Not f_SeikyuNasiChk() Then
                    Exit Try
                End If

                '処理状況判定
                '2015/03/03　削除　(GJ2040と同条件に変更)
                'If lbl_SYORI_JOKYO_KBN.Text <> "1" AndAlso lbl_SYORI_JOKYO_KBN.Text <> "3" Then
                '    Show_MessageBox_Add("I007", "請求中または入金済みではありません。")    '@0
                '    Exit Try
                'End If

            ElseIf rbtn_SYORI_KBN3.Checked Then

                '修正発行
                If pCurrentKey.SEIKYU_KAISU = "" Then
                    Show_MessageBox_Add("I007", "まだ発行されていないため修正発行できません。")   '@0
                    Exit Try
                End If

                '請求済みなしの場合、エラー
                If Not f_SeikyuNasiChk() Then
                    Exit Try
                End If

                '処理状況判定
                If lbl_SYORI_JOKYO_KBN.Text <> "1" Then
                    Show_MessageBox_Add("I007", "請求中ではありません。")    '@0
                    Exit Try
                End If

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
#Region "F_DataKbnChk データ区分チェック"
    '------------------------------------------------------------------
    'プロシージャ名  :F_DataKbnChk
    '説明            :データ区分チェック処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function F_DataKbnChk() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty

        Try

            'SQL
            wSql &= "SELECT"
            wSql &= "  COUNT(*) CNT, "
            wSql &= "  MIN( NVL(DATA_FLG, 0) ) DATA_FLG "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_ZOHA_RIREKI ZOH,"
            wSql &= "  TT_KEIYAKU_JOHO JOH "
            wSql &= "WHERE ZOH.KI = " & pCurrentKey.KI
            wSql &= "  AND ZOH.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND ZOH.KEIYAKU_DATE_FROM = TO_DATE('" & Format(pCurrentKey.KEIYAKU_DATE_FROM, "yyyy/MM/dd") & "','YYYY/MM/DD') "
            wSql &= "  AND ZOH.SEIKYU_KAISU IS NULL"
            wSql &= "  AND ZOH.MAE_SEQNO IS NOT NULL"
            wSql &= "  AND ZOH.MAE_SEQNO = JOH.SEQNO(+)"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 OrElse CInt(WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("CNT"))) = 0 Then
                '新規農場だけの場合、データなし
                ret = True
                Exit Try
            Else
                'データフラグ=0(無効)　はエラー
                If WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("DATA_FLG")) = 0 Then
                    Show_MessageBox_Add("I007", "契約情報が既に無効のため、処理できません。")
                    Exit Try
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
#Region "f_SyoriKbnChk 入力中チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SyoriKbnChk
    '説明            :入力中チェック処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SyoriKbnChk() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty
        Dim wLngMae As Long = 0
        Dim wLngAto As Long = 0

        Try

            'SQL
            wSql &= "SELECT"
            wSql &= "  MIN(CASE WHEN ZOH.SYORI_KBN = 2 THEN 2 ELSE 1 END) SYORI_KBN_MIN,"
            wSql &= "  MAX(CASE WHEN ZOH.SYORI_KBN = 2 THEN 2 ELSE 1 END) SYORI_KBN_MAX "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_ZOHA_RIREKI ZOH "
            wSql &= "WHERE ZOH.KI = " & pCurrentKey.KI
            wSql &= "  AND ZOH.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND ZOH.KEIYAKU_DATE_FROM = '" & pCurrentKey.KEIYAKU_DATE_FROM & "'"
            wSql &= "  AND ZOH.SEIKYU_KAISU IS NULL"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                '該当データなし
                Show_MessageBox_Add("I002", "") '該当データが存在しませんでした。
                Exit Try
            End If

            '入力中あり
            If WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("SYORI_KBN_MIN")) < 2 Then
                Show_MessageBox_Add("I007", "入力中のデータが存在するため" & vbCrLf & "処理できません。")
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
#Region "f_SeikyuNasiChk 未請求　存在チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SeikyuNasiChk
    '説明            :未請求　存在チェック処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SeikyuNasiChk() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty
        Dim wLngMae As Long = 0
        Dim wLngAto As Long = 0

        Try

            'SQL
            wSql &= "SELECT"
            wSql &= "  COUNT(*) CNT "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_ZOHA_RIREKI ZOH "
            wSql &= "WHERE ZOH.KI = " & pCurrentKey.KI
            wSql &= "  AND ZOH.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND ZOH.KEIYAKU_DATE_FROM = TO_DATE('" & Format(pCurrentKey.KEIYAKU_DATE_FROM, "yyyy/MM/dd") & "','YYYY/MM/DD') "
            wSql &= "  AND ZOH.SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                '該当データなし
                Show_MessageBox_Add("I002", "") '該当データが存在しませんでした。
                Exit Try
            End If

            'SQL
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  TUM.SYORI_JOKYO_KBN "
            wSql &= "FROM"
            wSql &= "  TT_TUMITATE TUM "
            wSql &= "WHERE TUM.KI = " & pCurrentKey.KI
            wSql &= "  AND TUM.SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU
            wSql &= "  AND TUM.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND TUM.TUMITATE_KBN = 1"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                '該当データなし
                Show_MessageBox_Add("I002", "") '該当データが存在しませんでした。
                Exit Try
            Else
                lbl_SYORI_JOKYO_KBN.Text = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("SYORI_JOKYO_KBN"))
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region
#Region "f_TankaChk 単価マスタ　存在チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TankaChk
    '説明            :単価マスタ　存在チェック処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_TankaChk() As Boolean
        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wStr As String = String.Empty

        Try

            'SQL
            wSql &= "SELECT"
            wSql &= "  COUNT(*) CNT "
            wSql &= "FROM"
            wSql &= "  TM_TANKA TAN "
            wSql &= "WHERE TAN.TAISYO_DATE_FROM <= TO_DATE('" & Format(pCurrentKey.KEIYAKU_DATE_FROM, "yyyy/MM/dd") & "','YYYY/MM/DD') "
            wSql &= "  AND TAN.TAISYO_DATE_TO   >= TO_DATE('" & Format(pCurrentKey.KEIYAKU_DATE_FROM, "yyyy/MM/dd") & "','YYYY/MM/DD') "
            wSql &= "  AND TAN.KEIYAKU_KBN = " & pCurrentKey.KEIYAKU_KBN

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 OrElse WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("CNT")) = 0 Then
                '該当データなし
                Show_MessageBox_Add("W018", "単価") '@0が設定されていません。
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
#Region "f_SYOHIZEIRITU_Select 消費税率取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SYOHIZEIRITU_Select
    '説明            :消費税率取得
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '2023/08/08 JBD454 R5インボイス対応 ADD
    '------------------------------------------------------------------
    'プレビュー処理日で該当するデータが消費税率マスタにない場合、
    'エラーメッセージ「消費税率が設定されていません。」を表示し処理を終了する。
    Private Function f_SYOHIZEIRITU_Select() As Boolean

        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            '適用開始日＜＝システム日付AND　適用終了日＞＝システム日付
            'SQL
            wSql &= "SELECT"
            wSql &= "  COUNT(*) CNT "
            wSql &= "FROM"
            wSql &= "  TM_TAX TAX "
            wSql &= "WHERE TAX.TAX_DATE_FROM <= TO_DATE('" & DateTime.Today & " ','YYYY/MM/DD') "
            wSql &= "  AND TAX.TAX_DATE_TO   >= TO_DATE('" & DateTime.Today & " ','YYYY/MM/DD') "

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 OrElse WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("CNT")) = 0 Then
                '該当データなし
                Show_MessageBox_Add("W018", "消費税率") '@0が設定されていません。
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

#Region "f_Input_Check_Torikesi 画面入力チェック処理(取消)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Input_Check_Torikesi
    '説明            :画面入力チェック処理(取消)
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_Input_Check_Torikesi() As Boolean
        Dim ret As Boolean = False
        Dim wSql As String = String.Empty
        Dim wkDS As New DataSet

        Try

            '--------------------------------------------------
            '請求回数　チェック
            '--------------------------------------------------
            '取消
            If pCurrentKey.SEIKYU_KAISU = "" Then
                Show_MessageBox_Add("I007", "まだ発行されていないため請求書取消できません。")  '@0
            End If

            '--------------------------------------------------
            '契約情報　無効　チェック
            '--------------------------------------------------
            'SQL
            wSql &= "SELECT"
            wSql &= "  MIN(DATA_FLG) DATA_FLG "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO "
            wSql &= "WHERE KI = " & pCurrentKey.KI
            wSql &= "  AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND KEIYAKU_DATE_FROM = TO_DATE('" & Format(pCurrentKey.KEIYAKU_DATE_FROM, "yyyy/MM/dd") & "','YYYY/MM/DD') "
            wSql &= "  AND SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If


            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                '該当データなし
                Show_MessageBox_Add("I007", "契約情報がすでに削除されています。")
                Exit Try
            Else
                'データフラグ=0(無効)　はエラー
                If WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("DATA_FLG")) = 0 Then
                    Show_MessageBox_Add("I007", "契約情報が既に無効のため、処理できません。")
                    Exit Try
                End If
            End If

            '--------------------------------------------------
            '積立金　入金　チェック
            '--------------------------------------------------
            'SQL
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  MAX(SYORI_JOKYO_KBN) SYORI_JOKYO_KBN "
            wSql &= "FROM"
            wSql &= "  TT_TUMITATE "
            wSql &= "WHERE KI = " & pCurrentKey.KI
            wSql &= "  AND SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU
            wSql &= "  AND KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND TUMITATE_KBN = 1"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Show_MessageBox_Add("I007", "データ取得でエラーが発生しました。")
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                '該当データなし
                Show_MessageBox_Add("I007", "積立データが既に削除されています。")
                Exit Try
            Else
                'データフラグ=0(無効)　はエラー
                If CInt(WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("SYORI_JOKYO_KBN"))) > 2 Then
                    Show_MessageBox_Add("I007", "入金されているため取消できません。")
                    Exit Try
                End If
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

                'Using wkAR As New rptGJ3011
                '    'ヘッダ用の値を保管
                '    wkAR.pKikin2 = pKikin2      '2017/07/14　追加
                '    '印影を取得
                '    wkAR.imgInei = f_inei_Get() '2018/07/09  追加
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
                If rbtn_SYORI_KBN0.Checked Then
                    pFlag = 0
                ElseIf rbtn_SYORI_KBN1.Checked Then
                    pFlag = 1
                ElseIf rbtn_SYORI_KBN2.Checked Then
                    pFlag = 2
                Else
                    pFlag = 3
                End If
                Dim w As New rptGJ3011
                w.sub1(wkDSRep, pFlag)
                '    '----------------------------------------------------
                '    wkAR.DataSource = wkDSRep
                '    wkAR.DataMember = wkDSRep.Tables(0).TableName
                '    wkAR.Run() '実行

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

            Else
                'エラーリスト出力なし
                Show_MessageBox("I002", "") '該当データが存在しません。
                Return False
            End If

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'メモリを解放します
            Call s_GC_Dispose()
        End Try

        Return True
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
        Dim wKouboNm As String = String.Empty
        Dim wSimeNm As String = String.Empty
        Dim wNendo As Integer = 0
        Dim wYmd As String = String.Empty

        Try

            wNendo = New Obj_TM_SYORI_NENDO_KI().pTAISYO_NENDO

            wSql = ""
            wSql &= "SELECT"
            wSql &= "  WK1.KI,"
            wSql &= "  TO_MULTI_BYTE(WK1.KI) KI_N,"
            wSql &= "  TO_MULTI_BYTE( TO_CHAR(TO_DATE('" & wNendo & "/04/01" & "','YYYY/MM/DD') , 'EEYY""年度""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') ) AS NENDO_N,"
            wSql &= "  WK1.SEIKYU_KAISU,"
            wSql &= "  TRIM(TO_CHAR(WK1.KEIYAKUSYA_CD,'00000')) KEIYAKUSYA_CD,"
            wSql &= "  WK1.TUMITATE_KBN,"
            '  --契約者マスタ
            wSql &= "  '〒' || SUBSTR(KYK.ADDR_POST,1,3) || '-' ||SUBSTR(KYK.ADDR_POST,4,4) KYK_POST,"
            wSql &= "  RTRIM(KYK.ADDR_1) || RTRIM(KYK.ADDR_2) KYK_ADDR1,"
            wSql &= "  KYK.ADDR_3 KYK_ADDR2,"
            wSql &= "  KYK.ADDR_4 KYK_ADDR3,"
            wSql &= "  CASE WHEN KYK.DAIHYO_NAME IS NULL THEN KYK.KEIYAKUSYA_NAME || '様' ELSE KYK.KEIYAKUSYA_NAME END KYK_KEIYAKUSYA_NAME,"
            'wSql &= "  CASE WHEN KYK.DAIHYO_NAME IS NULL THEN NULL ELSE KYK.DAIHYO_NAME || '様' END KYK_DAIHYO_NAME,"           '2015/12/01　修正
            wSql &= "  CASE WHEN KYK.DAIHYO_NAME IS NULL THEN NULL ELSE '　' || KYK.DAIHYO_NAME || '様' END KYK_DAIHYO_NAME,"    '2015/12/01　修正
            wSql &= "  '(' || TRIM(TO_CHAR(WK1.KEIYAKUSYA_CD,'00000')) || ')' KEIYAKUSYA_CD_KAKKO,"
            'wSql &= "  M01.RYAKUSYO KEIYAKU_KBN_NM,"
            wSql &= "  M01.MEISYO KEIYAKU_KBN_NM,"
            '  --協会マスタ
            wSql &= "  '(登録番号：' || KYO.TOUROKU_NO  || ')' TOUROKU_NO," '登録番号　2023/08/08 JBD454 R5年度インボイス対応 ADD
            wSql &= "  KYO.HAKKO_NO_KANJI,"
            wSql &= "  KYO.KYOKAI_NAME KYO_KYOKAI_NAME,"
            wSql &= "  KYO.YAKUMEI KYO_YAKUMEI,"
            wSql &= "  KYO.KAICHO_NAME KYO_KAICHO_NAME,"
            wSql &= "  KYO.ADDR1  || ADDR2 KYO_ADDR,"
            wSql &= "  'ＴＥＬ' || KYO.TEL1 KYO_TEL1,"
            wSql &= "  'ＦＡＸ' || KYO.FAX1 KYO_FAX1,"
            wSql &= "  BNK.BANK_NAME FURI_BANK_NAME,"
            'wSql &= "  '(' || BNK.BANK_KANA || ')' BANK_KANA,"
            wSql &= "  BNK.BANK_KANA BANK_KANA,"
            wSql &= "  SIT.SITEN_NAME FURI_SITEN_NAME,"
            'wSql &= "  '(' || SIT.SITEN_KANA || ')' SITEN_KANA,"
            wSql &= "  SIT.SITEN_KANA SITEN_KANA,"
            wSql &= "  '(' || M04.MEISYO || ')' FURI_KOZA_SYUBETU,"
            wSql &= "  TO_MULTI_BYTE(KYO.FURI_KOZA_NO) FURI_KOZA_NO_N,"
            wSql &= "  KYO.FURI_KOZA_MEIGI,"
            wSql &= "  KYO.FURI_KOZA_MEIGI_KANA,"
            '  --単価マスタ
            wSql &= "  TAN.TESURYO_RITU,"
            '  --積立情報
            wSql &= "  TO_CHAR(WK1.NOFUKIGEN_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NOFUKIGEN_DATE,"
            wSql &= "  TO_CHAR(WK1.SEIKYU_HAKKO_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SEIKYU_HAKKO_DATE,"
            wSql &= "  WK1.SEIKYU_HAKKO_NO_NEN,"
            wSql &= "  WK1.SEIKYU_HAKKO_NO_RENBAN,"

            For i = 1 To 6
                wSql &= "  WK1.TORI_KBN_NM" & i & ","
                wSql &= "  WK1.HASU" & i & ","
                wSql &= "  WK1.TUMITATE_TANKA" & i & ","
                wSql &= "  WK1.TUMITATE_KIN" & i & ","
            Next
            wSql &= "  WK1.HASU7,  WK1.TUMITATE_KIN7,"
            wSql &= "  WK1.SEIKYU_KIN, WK1.TESURYO,"
            wSql &= "  '　　内　' || WK1.TESURYO_SYOHIZEI_RITU || '％消費税 ' TESURYO_SYOHIZEI_RITU," '手数料消費税率　2023/08/08 JBD454 R5年度インボイス対応 ADD 
            wSql &= "  WK1.TESURYO_SYOHIZEI TESURYO_SYOHIZEI,"                                    　  '手数料消費税額　2023/08/08 JBD454 R5年度インボイス対応 ADD

            '  --委託先
            wSql &= "  KYK.JIMUITAKU_CD,"
            wSql &= "  ITK.ITAKU_NAME,"
            wSql &= "  ITK.BANK_INJI_KBN "
            wSql &= "FROM"
            wSql &= "  TM_KYOKAI KYO,"
            wSql &= "  TM_KEIYAKU KYK,"
            wSql &= "  TM_CODE M01,"
            wSql &= "  TM_TANKA TAN,"
            wSql &= "  TM_BANK BNK,"
            wSql &= "  TM_SITEN SIT,"
            wSql &= "  TM_CODE M04,"
            wSql &= "  TM_JIMUITAKU ITK,"
            wSql &= "  TM_SYORI_KI SKI,"

            '2017/07/14　修正開始
            wSql &= "  (SELECT"
            wSql &= "     WK2.KI,"
            wSql &= "     WK2.SEIKYU_KAISU,"
            wSql &= "     WK2.KEIYAKUSYA_CD,"
            wSql &= "     WK2.TUMITATE_KBN,"
            wSql &= "     WK2.KEIYAKU_KBN,"
            wSql &= "     WK2.KEIYAKU_DATE_FROM,"
            wSql &= "     MAX(WK2.SEIKYU_KIN) SEIKYU_KIN,"
            wSql &= "     MAX(WK2.TESURYO) TESURYO,"

            wSql &= "     MAX(WK2.TESURYO_SYOHIZEI_RITU) TESURYO_SYOHIZEI_RITU,"  '手数料消費税率　2023/08/08 JBD454 R5年度インボイス対応 ADD
            wSql &= "     MAX(WK2.TESURYO_SYOHIZEI) TESURYO_SYOHIZEI,"            '手数料消費税額　2023/08/08 JBD454 R5年度インボイス対応 ADD

            wSql &= "     MAX(WK2.NOFUKIGEN_DATE) NOFUKIGEN_DATE,"
            wSql &= "     MAX(WK2.SEIKYU_HAKKO_DATE) SEIKYU_HAKKO_DATE,"
            wSql &= "     MAX(WK2.SEIKYU_HAKKO_NO_NEN) SEIKYU_HAKKO_NO_NEN,"
            wSql &= "     MAX(WK2.SEIKYU_HAKKO_NO_RENBAN) SEIKYU_HAKKO_NO_RENBAN,"
            For i = 1 To 6
                wSql &= "     MAX(CASE WHEN WK2.GYO = " & i & " THEN WK2.TORI_KBN_NM    ELSE NULL END) TORI_KBN_NM" & i & ","
                wSql &= "     MAX(CASE WHEN WK2.GYO = " & i & " THEN WK2.HASU           ELSE NULL END) HASU" & i & ","
                wSql &= "     MAX(CASE WHEN WK2.GYO = " & i & " THEN WK2.TUMITATE_TANKA ELSE NULL END) TUMITATE_TANKA" & i & ","
                wSql &= "     MAX(CASE WHEN WK2.GYO = " & i & " THEN WK2.TUMITATE_KIN   ELSE NULL END) TUMITATE_KIN" & i & ","
            Next
            wSql &= "     SUM(WK2.HASU)  HASU7,"
            wSql &= "     SUM(WK2.TUMITATE_KIN)  TUMITATE_KIN7"
            wSql &= "   FROM"
            wSql &= "     (SELECT"
            wSql &= "        TUM.KI,"
            wSql &= "        TUM.SEIKYU_KAISU,"
            wSql &= "        TUM.KEIYAKUSYA_CD,"
            wSql &= "        TUM.TUMITATE_KBN,"
            wSql &= "        TUM.KEIYAKU_KBN,"
            wSql &= "        TUM.KEIYAKU_DATE_FROM,"
            wSql &= "        MEI.TORI_KBN,"
            wSql &= "        M07.MEISYO TORI_KBN_NM,"
            wSql &= "        DENSE_RANK() OVER(PARTITION BY TUM.KI, TUM.SEIKYU_KAISU, TUM.KEIYAKUSYA_CD ORDER BY MEI.TORI_KBN) GYO,"
            wSql &= "        MAX(SEIKYU_KIN) SEIKYU_KIN,"
            wSql &= "        MAX(TESURYO) TESURYO,"

            wSql &= "        MAX(TUM.TESURYO_SYOHIZEI_RITU) TESURYO_SYOHIZEI_RITU," 　'手数料消費税率　2023/08/08 JBD454 R5年度インボイス対応 ADD
            wSql &= "        MAX(TUM.TESURYO_SYOHIZEI) TESURYO_SYOHIZEI,"　     　　　'手数料消費税額　2023/08/08 JBD454 R5年度インボイス対応 ADD

            wSql &= "        MAX(NOFUKIGEN_DATE) NOFUKIGEN_DATE,"
            wSql &= "        MAX(TUM.SEIKYU_HAKKO_DATE) SEIKYU_HAKKO_DATE,"
            wSql &= "        MAX(TUM.SEIKYU_HAKKO_NO_NEN) SEIKYU_HAKKO_NO_NEN,"
            wSql &= "        MAX(TUM.SEIKYU_HAKKO_NO_RENBAN) SEIKYU_HAKKO_NO_RENBAN,"
            wSql &= "        SUM(MEI.HASU) HASU,"
            wSql &= "        SUM(MEI.TUMITATE_TANKA) TUMITATE_TANKA,"
            wSql &= "        SUM(MEI.TUMITATE_KIN) TUMITATE_KIN"
            wSql &= "      FROM"
            wSql &= "        TM_CODE M07,"

            If rbtn_SYORI_KBN0.Checked Then
                '仮請求
                wSql &= "        TW_TUMITATE TUM,"
                wSql &= "        TW_TUMITATE_MEISAI MEI"
                wSql &= "      WHERE TUM.KI = " & pCurrentKey.KI
                wSql &= "        AND TUM.SEIKYU_KAISU = 0"
                wSql &= "        AND TUM.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
                wSql &= "        AND TUM.TUMITATE_KBN = 1"
            Else
                '初回請求・再請求・修正請求
                wSql &= "        TT_TUMITATE TUM,"
                wSql &= "        TT_TUMITATE_MEISAI MEI"
                wSql &= "      WHERE TUM.KI = " & pCurrentKey.KI
                wSql &= "        AND TUM.SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU
                wSql &= "        AND TUM.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
                wSql &= "        AND TUM.TUMITATE_KBN = 1"
            End If

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
            wSql &= "        TUM.TUMITATE_KBN,"
            wSql &= "        TUM.KEIYAKU_KBN,"
            wSql &= "        TUM.KEIYAKU_DATE_FROM,"
            wSql &= "        MEI.TORI_KBN,"
            wSql &= "        M07.MEISYO"
            wSql &= "     ) WK2"
            wSql &= "   GROUP BY"
            wSql &= "     WK2.KI,"
            wSql &= "     WK2.SEIKYU_KAISU,"
            wSql &= "     WK2.KEIYAKUSYA_CD,"
            wSql &= "     WK2.TUMITATE_KBN,"
            wSql &= "     WK2.KEIYAKU_KBN,"
            wSql &= "     WK2.KEIYAKU_DATE_FROM"
            wSql &= "  ) WK1 "
            '2017/07/14　修正開始

            wSql &= "WHERE 1 = KYO.KYOKAI_KBN(+)"
            '  --契約者マスタ
            wSql &= "  AND WK1.KI = KYK.KI(+)"
            wSql &= "  AND WK1.KEIYAKUSYA_CD = KYK.KEIYAKUSYA_CD(+)"
            '  --コードマスタ(契約者区分)
            wSql &= "  AND 1 = M01.SYURUI_KBN(+)"
            wSql &= "  AND WK1.KEIYAKU_KBN = M01.MEISYO_CD(+)"
            '  --単価マスタ
            wSql &= "  AND WK1.KEIYAKU_DATE_FROM >= TAN.TAISYO_DATE_FROM(+)"
            wSql &= "  AND WK1.KEIYAKU_DATE_FROM <= TAN.TAISYO_DATE_TO(+)"
            wSql &= "  AND 9 = TAN.KEIYAKU_KBN(+)"
            wSql &= "  AND 9 = TAN.TORI_KBN(+)"
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
