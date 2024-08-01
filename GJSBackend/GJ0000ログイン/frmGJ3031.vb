'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ3031.vb
'*
'*　　②　機能概要　　　　　互助基金契約者情報変更（譲渡）通知書発行
'*
'*　　③　作成日　　　　　　2015/03/25　BY JBD
'*
'*　　④　更新日            2017/07/19  BY JBD
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

Public Class frmGJ3031

#Region "*** 変数定義 ***"


    ''' <summary>
    ''' カレント主キー
    ''' </summary>
    ''' <remarks></remarks>
    Property pCurrentKey As frmGJ3030.T_KEY

    ''' <summary>
    ''' リスト用
    ''' </summary>
    ''' <remarks></remarks>
    Public pRptName As String = "互助基金契約譲渡の請求書（譲渡）"  '帳票名

    ''' <summary>
    ''' その他変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True                     '処理ジャンプ


    Private pDataSet As New DataSet                     'マスタ用データセット
    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ
    Private KEIYAKU_HENKO_KBN As Integer
    Private pSyoriKbn As Integer

#End Region

#Region "*** 画面制御関連 ***"

#Region "frmGJ3030_Load Form_Loadイベント"

    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ3030_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ3030_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

#Region "frmGJ3030_Disposed Form_Disposedイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmEM2030_Disposed
    '説明            :Form_Disposedイベント
    '------------------------------------------------------------------
    Private Sub frmGJ3030_Disposed(ByVal sender As Object, ByVal e As System.EventArgs)

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
            If Not f_Input_Check_Previw() Then
                Exit Try
            End If


            '契約区分が同じとき、通知書は発行しない(初回請求のときのみメッセージ表示後、更新を実行)
            If pCurrentKey.MOTO_KEIYAKU_KBN = pCurrentKey.SAKI_KEIYAKU_KBN Then
                '採択通知書発行処理の更新確認メッセージ
                If Show_MessageBox_Add("Q012", "請求処理を行います。" & vbCrLf &
                                               "但し、差額がない為、請求書は出力されません。" & vbCrLf &
                                               "請求処理を実行してよろしいですか？") = DialogResult.No Then    '@0
                    Exit Try
                End If
            Else
                '採択通知書発行処理の更新確認メッセージ
                '2018/07/09　修正開始
                'If Show_MessageBox_Add("Q012", "通知書の発行を行ってもよろしいですか？") = DialogResult.No Then    '@0
                '    Exit Try
                'End If
                If pCurrentKey.KEIYAKU_HENKO_KBN = 4 Then
                    '家族→企業
                    If Show_MessageBox_Add("Q012", "請求通知書の発行を行ってもよろしいですか？") = DialogResult.No Then    '@0
                        Exit Try
                    End If
                Else
                    '家族→企業
                    If Show_MessageBox_Add("Q012", "返還通知書の発行を行ってもよろしいですか？") = DialogResult.No Then    '@0
                        Exit Try
                    End If
                End If
                '2018/07/09　修正終了
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
            If pCurrentKey.MOTO_KEIYAKU_KBN <> pCurrentKey.SAKI_KEIYAKU_KBN Then
                If Not f_Report_Output() Then
                    Exit Try
                End If
            End If

            '画面再表示 
            If rbtn_SYORI_KBN1.Checked Then
                f_InitSet()
                f_SyoriKbnEnable()
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
            If Show_MessageBox_Add("Q012", "通知書の取消を行ってもよろしいですか？") = DialogResult.No Then    '@0
                Exit Try
            End If

            'データ更新処理
            If Not f_Data_Save4() Then
                Exit Try
            End If

            '画面再表示 
            pCurrentKey.SEIKYU_KAISU = ""
            f_InitSet()
            f_SyoriKbnEnable()

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
            Cmd.CommandText = "PKG_GJ3031.GJ3031_KARI_SEIKYU"

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Cmd.Parameters.Add("IN_KI", pCurrentKey.KI)
            '契約者番号(譲渡先)
            Cmd.Parameters.Add("IN_SAKI_KEIYAKUSYA_CD", pCurrentKey.SAKI_KEIYAKUSYA_CD)
            '契約年月日From  
            Cmd.Parameters.Add("KEIYAKU_DATE_FROM", pCurrentKey.KEIYAKU_DATE_FROM)
            '契約年月日To 
            Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", pCurrentKey.KEIYAKU_DATE_TO)
            '契約者番号(譲渡元)
            Cmd.Parameters.Add("IN_MOTO_KEIYAKUSYA_CD", pCurrentKey.MOTO_KEIYAKUSYA_CD)
            '契約区分(譲渡先)
            Cmd.Parameters.Add("IN_SAKI_KEIYAKU_KBN", pCurrentKey.SAKI_KEIYAKU_KBN)
            '契約区分(譲渡元)
            Cmd.Parameters.Add("IN_MOTO_KEIYAKU_KBN", pCurrentKey.MOTO_KEIYAKU_KBN)

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

            '請求回数(仮契約のときは０固定)
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
            Cmd.CommandText = "PKG_GJ3031.GJ3031_SYOKAI_SEIKYU"

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Cmd.Parameters.Add("IN_KI", pCurrentKey.KI)
            '契約者番号(譲渡先)
            Cmd.Parameters.Add("IN_SAKI_KEIYAKUSYA_CD", pCurrentKey.SAKI_KEIYAKUSYA_CD)
            '契約年月日From  
            Cmd.Parameters.Add("KEIYAKU_DATE_FROM", pCurrentKey.KEIYAKU_DATE_FROM)
            '契約年月日To 
            Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", pCurrentKey.KEIYAKU_DATE_TO)
            '契約者番号(譲渡元)
            Cmd.Parameters.Add("IN_MOTO_KEIYAKUSYA_CD", pCurrentKey.MOTO_KEIYAKUSYA_CD)
            '契約区分(譲渡先)
            Cmd.Parameters.Add("IN_SAKI_KEIYAKU_KBN", pCurrentKey.SAKI_KEIYAKU_KBN)
            '契約区分(譲渡元)
            Cmd.Parameters.Add("IN_MOTO_KEIYAKU_KBN", pCurrentKey.MOTO_KEIYAKU_KBN)

            '納付期限（振込予定日）
            Cmd.Parameters.Add("IN_NOFUKIGEN_DATE", f_DateTrim(date_KIGEN_DATE.Value))
            '通知書発行日
            Cmd.Parameters.Add("IN_SEIKYU_HAKKO_DATE", f_DateTrim(date_HAKKO_DATE.Value))
            '通知書発行番号(年)
            Cmd.Parameters.Add("IN_SEIKYU_HAKKO_NO_NEN", txt_SEIKYU_HAKKO_NO_NEN.Text.Trim)
            '通知書発行番号(連番)
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
            Cmd.CommandText = "PKG_GJ3032.GJ3032_SAI_HAKKO"

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Cmd.Parameters.Add("IN_KI", pCurrentKey.KI)
            '請求回数
            Cmd.Parameters.Add("IN_SEIKYU_KAISU", pCurrentKey.SEIKYU_KAISU)
            '契約者番号 県コード＋連番３桁    
            Cmd.Parameters.Add("IN_SAKI_KEIYAKUSYA_CD", pCurrentKey.SAKI_KEIYAKUSYA_CD)
            Cmd.Parameters.Add("IN_MOTO_KEIYAKUSYA_CD", pCurrentKey.MOTO_KEIYAKUSYA_CD)

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
            Cmd.CommandText = "PKG_GJ3032.GJ3032_SYUSEI_HAKKO"

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Cmd.Parameters.Add("IN_KI", pCurrentKey.KI)
            '請求回数
            Cmd.Parameters.Add("IN_SEIKYU_KAISU", pCurrentKey.SEIKYU_KAISU)
            '契約者番号 県コード＋連番３桁    
            Cmd.Parameters.Add("IN_SAKI_KEIYAKUSYA_CD", pCurrentKey.SAKI_KEIYAKUSYA_CD)
            Cmd.Parameters.Add("IN_MOTO_KEIYAKUSYA_CD", pCurrentKey.MOTO_KEIYAKUSYA_CD)

            '納付期限（振込予定日）
            Cmd.Parameters.Add("IN_NOFUKIGEN_DATE", f_DateTrim(date_KIGEN_DATE.Value))
            '通知書発行日
            Cmd.Parameters.Add("IN_SEIKYU_HAKKO_DATE", f_DateTrim(date_HAKKO_DATE.Value))
            '通知書発行番号(年)
            Cmd.Parameters.Add("IN_SEIKYU_HAKKO_NO_NEN", txt_SEIKYU_HAKKO_NO_NEN.Text.Trim)
            '通知書発行番号(連番)
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
            Cmd.CommandText = "PKG_GJ3032.GJ3032_SEIKYU_TORIKESI"
            '----------------------------------------
            '   情報
            '----------------------------------------
            '期   
            Cmd.Parameters.Add("IN_KI", pCurrentKey.KI)
            '契約者番号 県コード＋連番３桁    
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", pCurrentKey.SAKI_KEIYAKUSYA_CD)
            '契約年月日From  
            Cmd.Parameters.Add("KEIYAKU_DATE_FROM", pCurrentKey.KEIYAKU_DATE_FROM)
            '契約年月日To 
            Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", pCurrentKey.KEIYAKU_DATE_TO)
            '契約者番号 県コード＋連番３桁    
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", pCurrentKey.MOTO_KEIYAKUSYA_CD)
            '請求回数
            Cmd.Parameters.Add("IN_SEIKYU_KAISU", pCurrentKey.SEIKYU_KAISU)

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
            If Not f_SyoriKbnEnable() Then
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
            lbl_KEIYAKUSYA_CD.Text = pCurrentKey.SAKI_KEIYAKUSYA_CD
            lbl_KEIYAKUSYA_NM.Text = pCurrentKey.SAKI_KEIYAKUSYA_NM

            '請求回数
            lbl_SEIKYU_KAISU.Text = pCurrentKey.SEIKYU_KAISU

            '変更年月日
            lbl_KEIYAKU_DATE_FROM_X.Text = pCurrentKey.KEIYAKU_DATE_FROM_X

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
            wSql &= "  AND KEIYAKUSYA_CD = " & pCurrentKey.SAKI_KEIYAKUSYA_CD
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
                    '通知書発行日    
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
#Region "f_SeikyuJohoClr 請求情報クリア処理"
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
#Region "f_SyoriKbnEnable 処理区分入力制御"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SyoriKbnEnable
    '説明            :処理区分入力制御
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SyoriKbnEnable() As Boolean
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

                '発行日
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

            '2023/08/07 JBD9020 R5インボイス対応 ADD START
            '消費税率マスタなしの場合、エラー
            If rbtn_SYORI_KBN0.Checked And pCurrentKey.MOTO_KEIYAKU_KBN = pCurrentKey.SAKI_KEIYAKU_KBN Then
            ElseIf rbtn_SYORI_KBN0.Checked Or rbtn_SYORI_KBN1.Checked Then
                If Not f_TaxChk() Then
                    Exit Try
                End If
            End If
            '2023/08/07 JBD9020 R5インボイス対応 ADD END

            '--------------------------------------------------
            '請求回数　チェック
            '--------------------------------------------------
            If rbtn_SYORI_KBN0.Checked Then

                '仮発行
                If pCurrentKey.SEIKYU_KAISU <> "" AndAlso pCurrentKey.SEIKYU_KAISU <> 0 Then
                    Show_MessageBox_Add("I007", "既に発行済のため仮発行できません。")    '@0
                    Exit Try
                End If

                '通知書なしのとき、再発行は不可
                If pCurrentKey.MOTO_KEIYAKU_KBN = pCurrentKey.SAKI_KEIYAKU_KBN Then
                    'Show_MessageBox_Add("I007", "契約区分が同じため仮発行できません。")   '@0    
                    Show_MessageBox_Add("I007", "差額がない為、請求書は出力されません。" & vbCrLf &
                                                "よって、仮発行は実行できません。")   '2016/07/12　修正
                    Exit Try
                End If

                '契約情報　チェック
                If Not F_DataKbnChk() Then
                    Exit Try
                End If

            ElseIf rbtn_SYORI_KBN1.Checked Then

                '初回発行
                If pCurrentKey.SEIKYU_KAISU <> "" AndAlso pCurrentKey.SEIKYU_KAISU <> 0 Then
                    Show_MessageBox_Add("I007", "既に発行済のため初回発行できません。")   '@0
                    Exit Try
                End If

                '入力中ありの場合、エラー
                If Not f_SyoriKbnChk() Then
                    Exit Try
                End If

                'データ区分　チェック
                If Not F_DataKbnChk() Then
                    Exit Try
                End If

            ElseIf rbtn_SYORI_KBN2.Checked Then
                '再発行
                If pCurrentKey.SEIKYU_KAISU = "" OrElse pCurrentKey.SEIKYU_KAISU = 0 Then
                    Show_MessageBox_Add("I007", "まだ発行されていないため再発行できません。")    '@0
                    Exit Try
                End If

                '請求書なしのとき、再発行は不可
                If pCurrentKey.MOTO_KEIYAKU_KBN = pCurrentKey.SAKI_KEIYAKU_KBN Then
                    'Show_MessageBox_Add("I007", "契約区分が同じため再発行できません。")   '@0
                    Show_MessageBox_Add("I007", "差額がない為、請求書は出力されません。" & vbCrLf &
                                                "よって、再発行は実行できません。")   '2016/07/12　修正
                    Exit Try
                End If

                '請求済みなしの場合、エラー
                If Not f_SeikyuNasiChk() Then
                    Exit Try
                End If

                '処理状況判定
                '2015/03/03　削除　(GJ2040と同一条件に変更)
                'If lbl_SYORI_JOKYO_KBN.Text <> "1" AndAlso lbl_SYORI_JOKYO_KBN.Text <> "3" Then
                '    Show_MessageBox_Add("I007", "請求中または入金済みではありません。")    '@0
                '    Exit Try
                'End If

            ElseIf rbtn_SYORI_KBN3.Checked Then
                '修正発行
                If pCurrentKey.SEIKYU_KAISU = "" OrElse pCurrentKey.SEIKYU_KAISU = 0 Then
                    Show_MessageBox_Add("I007", "まだ発行されていないため修正発行できません。")   '@0
                    Exit Try
                End If

                '請求書なしのとき、修正発行は不可
                If pCurrentKey.MOTO_KEIYAKU_KBN = pCurrentKey.SAKI_KEIYAKU_KBN Then
                    'Show_MessageBox_Add("I007", "契約区分が同じため修正発行できません。")   '@0
                    Show_MessageBox_Add("I007", "差額がない為、請求書は出力されません。" & vbCrLf &
                                                "よって、修正発行は実行できません。")   '2016/07/12　修正
                    Exit Try
                End If

                '請求済みなしの場合、エラー
                If Not f_SeikyuNasiChk() Then
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
        Dim wRirekiCnt As Integer = 0
        Dim wJohoCnt As Integer = 0

        Try

            '--------------------------------------------------
            '履歴明細から契約情報取得
            '--------------------------------------------------
            wSql &= "SELECT"
            wSql &= "  MIN( NVL(DATA_FLG, 0) ) DATA_FLG "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOTO_MEISAI_RIREKI RME,"
            wSql &= "  TT_KEIYAKU_JOHO JOH "
            wSql &= "WHERE RME.KI = " & pCurrentKey.KI
            wSql &= "  AND RME.KEIYAKUSYA_CD = " & pCurrentKey.SAKI_KEIYAKUSYA_CD
            wSql &= "  AND RME.KEIYAKU_DATE_FROM = TO_DATE('" & Format(pCurrentKey.KEIYAKU_DATE_FROM, "yyyy/MM/dd") & "','YYYY/MM/DD') "
            wSql &= "  AND RME.KEIYAKU_DATE_TO   = TO_DATE('" & Format(pCurrentKey.KEIYAKU_DATE_TO, "yyyy/MM/dd") & "','YYYY/MM/DD') "
            wSql &= "  AND RME.MOTO_KEIYAKUSYA_CD = " & pCurrentKey.MOTO_KEIYAKUSYA_CD
            wSql &= "  AND RME.SEIKYU_KAISU IS NULL"
            wSql &= "  AND RME.MOTO_SEQNO = JOH.SEQNO(+)"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                '該当データなし
                Show_MessageBox_Add("I007", "すでに削除されています。")
                Exit Try
            Else
                'データフラグ=0(無効)　はエラー
                If WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("DATA_FLG")) = 0 Then
                    Show_MessageBox_Add("I007", "譲渡元データが既に無効のため、処理できません。")
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
            wSql &= "  MIN(CASE WHEN RIR.SYORI_KBN = 2 THEN 2 ELSE 1 END) SYORI_KBN_MIN "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOTO_RIREKI RIR "
            wSql &= "WHERE RIR.KI = " & pCurrentKey.KI
            wSql &= "  AND RIR.KEIYAKUSYA_CD = " & pCurrentKey.SAKI_KEIYAKUSYA_CD
            wSql &= "  AND RIR.KEIYAKU_DATE_FROM = '" & pCurrentKey.KEIYAKU_DATE_FROM & "'"
            wSql &= "  AND RIR.KEIYAKU_DATE_TO   = '" & pCurrentKey.KEIYAKU_DATE_TO & "'"
            wSql &= "  AND RIR.MOTO_KEIYAKUSYA_CD = " & pCurrentKey.MOTO_KEIYAKUSYA_CD
            wSql &= "  AND RIR.SEIKYU_KAISU IS NULL"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                '該当データなし
                Show_MessageBox_Add("I002", "") '該当データが存在しませんでした。
                Exit Try
            End If

            '入力中あり
            If CInt(WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("SYORI_KBN_MIN"))) < 2 Then
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
#Region "f_SeikyuNasiChk 請求　存在チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SeikyuNasiChk
    '説明            :請求　存在チェック処理
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
            wSql &= "  TT_KEIYAKU_JOTO_RIREKI RIR "
            wSql &= "WHERE RIR.KI = " & pCurrentKey.KI
            wSql &= "  AND RIR.KEIYAKUSYA_CD = " & pCurrentKey.SAKI_KEIYAKUSYA_CD
            wSql &= "  AND RIR.KEIYAKU_DATE_FROM = TO_DATE('" & Format(pCurrentKey.KEIYAKU_DATE_FROM, "yyyy/MM/dd") & "','YYYY/MM/DD') "
            wSql &= "  AND RIR.KEIYAKU_DATE_TO   = TO_DATE('" & Format(pCurrentKey.KEIYAKU_DATE_TO, "yyyy/MM/dd") & "','YYYY/MM/DD') "
            wSql &= "  AND RIR.MOTO_KEIYAKUSYA_CD = " & pCurrentKey.MOTO_KEIYAKUSYA_CD
            wSql &= "  AND RIR.SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
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
            wSql &= "  AND TUM.KEIYAKUSYA_CD = " & pCurrentKey.SAKI_KEIYAKUSYA_CD
            wSql &= "  AND TUM.TUMITATE_KBN = 1"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                '該当データなし
                Show_MessageBox_Add("I002", "") '該当データが存在しませんでした。
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

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
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
#Region "f_TaxChk 消費税率マスタ　存在チェック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TaxChk
    '説明            :消費税率マスタ　存在チェック処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '2023/08/07 JBD9020 R5インボイス対応 ADD
    '------------------------------------------------------------------
    Private Function f_TaxChk() As Boolean

        Dim ret As Boolean = False
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wNow As Date = Now

        Try

            'SQL
            wSql &= "SELECT"
            wSql &= "  TAX_RITU "
            wSql &= "FROM"
            wSql &= "  TM_TAX  "
            wSql &= "WHERE TAX_DATE_FROM <= '" & Format(wNow, "yyyy/MM/dd") & "'"
            wSql &= "  AND TAX_DATE_TO   >= '" & Format(wNow, "yyyy/MM/dd") & "'"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
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
                Show_MessageBox_Add("I007", "まだ発行されていないため通知書取消できません。")  '@0
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
            wSql &= "  AND KEIYAKUSYA_CD = " & pCurrentKey.SAKI_KEIYAKUSYA_CD
            wSql &= "  AND SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
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
                    Show_MessageBox_Add("I007", "譲渡後データが既に無効のため、" & vbCrLf & "処理できません。")
                    Exit Try
                End If
            End If

            '--------------------------------------------------
            '積立金　入金　チェック
            '--------------------------------------------------
            'SQL
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  MAX(SYORI_JOKYO_KBN) SYORI_JOKYO_KBN,"
            wSql &= "  SUM(SAGAKU_SEIKYU_KIN) SAGAKU_SEIKYU_KIN "
            wSql &= "FROM"
            wSql &= "  TT_TUMITATE "
            wSql &= "WHERE KI = " & pCurrentKey.KI
            wSql &= "  AND SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU
            wSql &= "  AND KEIYAKUSYA_CD = " & pCurrentKey.SAKI_KEIYAKUSYA_CD
            wSql &= "  AND TUMITATE_KBN = 1"

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Exit Try
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                '該当データなし
                Show_MessageBox_Add("I007", "積立データが既に削除されています。")
                Exit Try
            Else
                'データフラグ=0(無効)　はエラー
                If CInt(WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("SYORI_JOKYO_KBN"))) > 2 AndAlso
                   CLng(WordHenkan("N", "Z", wkDS.Tables(0).Rows(0)("SAGAKU_SEIKYU_KIN"))) <> 0 Then
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
            '仮請求のときは、請求番号クリア
            If rbtn_SYORI_KBN0.Checked Then
                pCurrentKey.SEIKYU_KAISU = 0
            End If

            '--------------------------------------------------
            '   データ取得
            '--------------------------------------------------
            wkDSRep.Tables.Add(pRptName)

            Using wkAdp As New OracleDataAdapter(wSql, Cnn)
                wkAdp.Fill(wkDSRep, wkDSRep.Tables(0).TableName)
            End Using

            If wkDSRep.Tables(0).Rows.Count > 0 Then

                'Using wkAR As New rptGJ3031
                '    'ヘッダ用の値を保管
                '    wkAR.pKikin2 = pKikin2      '2017/07/18　追加
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
                '    '契約変更区分
                '    wkAR.pKeiyakuHenkoKbn = pCurrentKey.KEIYAKU_HENKO_KBN

                '    If pCurrentKey.KEIYAKU_HENKO_KBN = 4 Then
                '        '徴収　(企業→家族以外)
                '        pRptName = "家畜防疫互助基金積立金等請求書（譲渡）"
                '        wkAR.GRP_FT_GOKEI_KINGAKU.Visible = True
                '        wkAR.GRP_FT_KEIYAKU_KBN1.Visible = True
                '        wkAR.GRP_FT_KEIYAKU_KBN2.Visible = False
                '    Else
                '        '返還　(企業→家族)
                '        pRptName = "家畜防疫互助基金積立金等返還通知書（譲渡）"
                '        wkAR.GRP_FT_GOKEI_KINGAKU.Visible = False
                '        wkAR.GRP_FT_KEIYAKU_KBN1.Visible = False
                '        wkAR.GRP_FT_KEIYAKU_KBN2.Visible = True
                '    End If

                '    pRptName = pRptName

                If rbtn_SYORI_KBN0.Checked Then
                    pSyoriKbn = 0
                ElseIf rbtn_SYORI_KBN1.Checked Then
                    pSyoriKbn = 1
                ElseIf rbtn_SYORI_KBN2.Checked Then
                    pSyoriKbn = 2
                Else
                    pSyoriKbn = 3
                End If
                Dim w As New rptGJ3031
                w.sub1(wkDSRep, pCurrentKey.KEIYAKU_HENKO_KBN, pSyoriKbn)

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

        Try

            wSql &= "SELECT"
            wSql &= "  TRIM(TO_CHAR(WK1.SAKI_KEIYAKUSYA_CD,'00000')) KEIYAKUSYA_CD," & vbCrLf
            '--譲渡先　契約者マスタ
            wSql &= "  '〒' || SUBSTR(KYK.ADDR_POST,1,3) || '-' ||SUBSTR(KYK.ADDR_POST,4,4) KYK_POST," & vbCrLf
            wSql &= "  RTRIM(KYK.ADDR_1) || RTRIM(KYK.ADDR_2) KYK_ADDR1," & vbCrLf
            wSql &= "  KYK.ADDR_3 KYK_ADDR2," & vbCrLf
            wSql &= "  KYK.ADDR_4 KYK_ADDR3," & vbCrLf
            wSql &= "  CASE WHEN KYK.DAIHYO_NAME IS NULL THEN KYK.KEIYAKUSYA_NAME || '様' ELSE KYK.KEIYAKUSYA_NAME END KYK_KEIYAKUSYA_NAME," & vbCrLf
            'wSql &= "  CASE WHEN KYK.DAIHYO_NAME IS NULL THEN NULL ELSE KYK.DAIHYO_NAME || '様' END KYK_DAIHYO_NAME,"           '2015/12/01　修正
            wSql &= "  CASE WHEN KYK.DAIHYO_NAME IS NULL THEN NULL ELSE '　' || KYK.DAIHYO_NAME || '様' END KYK_DAIHYO_NAME," & vbCrLf   '2015/12/01　修正
            wSql &= "  '(' || TRIM(TO_CHAR(WK1.SAKI_KEIYAKUSYA_CD,'00000')) || ')' KEIYAKUSYA_CD_KAKKO," & vbCrLf
            'wSql &= "  M01.RYAKUSYO SAKI_KEIYAKU_KBN_NM,"  '2017/07/18　修正
            wSql &= "  M01.MEISYO SAKI_KEIYAKU_KBN_NM," & vbCrLf     '2017/07/18　修正
            '--譲渡元　契約者マスタ
            wSql &= "  MOT.KEIYAKUSYA_NAME MOTO_KEIYAKUSYA_NAME," & vbCrLf
            wSql &= "  '(' || TRIM(TO_CHAR(WK1.MOTO_KEIYAKUSYA_CD,'00000')) || ')' MOTO_KEIYAKUSYA_CD_KAKKO," & vbCrLf
            'wSql &= "  M02.RYAKUSYO MOTO_KEIYAKU_KBN_NM,"  '2017/07/18　修正
            wSql &= "  M02.MEISYO MOTO_KEIYAKU_KBN_NM," & vbCrLf     '2017/07/18　修正
            '--協会マスタ
            wSql &= "  KYO.HAKKO_NO_KANJI," & vbCrLf
            wSql &= "  KYO.KYOKAI_NAME KYO_KYOKAI_NAME," & vbCrLf
            wSql &= "  KYO.YAKUMEI KYO_YAKUMEI," & vbCrLf
            wSql &= "  KYO.KAICHO_NAME KYO_KAICHO_NAME," & vbCrLf
            wSql &= "  KYO.ADDR1  || ADDR2 KYO_ADDR," & vbCrLf
            wSql &= "  'ＴＥＬ' || KYO.TEL1 KYO_TEL1," & vbCrLf
            wSql &= "  'ＦＡＸ' || KYO.FAX1 KYO_FAX1," & vbCrLf
            '--単価マスタ
            wSql &= "  TAN.TESURYO_RITU," & vbCrLf
            '--振込情報
            '2018/07/04　修正開始
            wSql &= "  BNK.BANK_NAME BANK_NAME," & vbCrLf
            wSql &= "  BNK.BANK_KANA BANK_KANA," & vbCrLf
            wSql &= "  SIT.SITEN_NAME SITEN_NAME," & vbCrLf
            wSql &= "  SIT.SITEN_KANA SITEN_KANA," & vbCrLf
            wSql &= "  '(' || M04.MEISYO || ')' KOZA_SYUBETU," & vbCrLf

            If pCurrentKey.KEIYAKU_HENKO_KBN = 4 Then
                '--振込先(徴収)
                wSql &= "  TO_MULTI_BYTE(KYO.FURI_KOZA_NO) FURI_KOZA_NO_N," & vbCrLf
                wSql &= "  KYO.FURI_KOZA_MEIGI FURI_KOZA_MEIGI," & vbCrLf
                wSql &= "  KYO.FURI_KOZA_MEIGI_KANA FURI_KOZA_MEIGI_KANA," & vbCrLf
                wSql &= "  KYO.FURI_BANK_CD FURI_BANK_CD1," & vbCrLf
                wSql &= "  KYO.FURI_BANK_SITEN_CD," & vbCrLf
            Else
                '--振込先(返還)
                wSql &= "  TO_MULTI_BYTE(KYK.FURI_KOZA_NO) FURI_KOZA_NO_N," & vbCrLf
                wSql &= "  KYK.FURI_KOZA_MEIGI FURI_KOZA_MEIGI," & vbCrLf
                wSql &= "  KYK.FURI_BANK_CD FURI_BANK_CD2," & vbCrLf
                wSql &= "  KYK.FURI_BANK_SITEN_CD," & vbCrLf
            End If
            '2018/07/04　修正終了

            '--振込先(徴収)
            wSql &= "  TO_MULTI_BYTE(KYO.FURI_KOZA_NO) FURI_KOZA_NO_N," & vbCrLf
            wSql &= "  KYO.FURI_KOZA_MEIGI FURI_KOZA_MEIGI," & vbCrLf
            wSql &= "  KYO.FURI_KOZA_MEIGI_KANA FURI_KOZA_MEIGI_KANA," & vbCrLf
            wSql &= "  KYO.FURI_BANK_CD FURI_BANK_CD1," & vbCrLf
            wSql &= "  KYO.FURI_BANK_SITEN_CD," & vbCrLf
            '--積立情報
            wSql &= "  TO_CHAR(WK1.NOFUKIGEN_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS NOFUKIGEN_DATE," & vbCrLf
            wSql &= "  TO_CHAR(WK1.SEIKYU_HAKKO_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SEIKYU_HAKKO_DATE," & vbCrLf
            wSql &= "  WK1.SEIKYU_HAKKO_NO_NEN," & vbCrLf
            wSql &= "  WK1.SEIKYU_HAKKO_NO_RENBAN," & vbCrLf
            '--鶏の種類
            For i = 1 To 6
                wSql &= "  WK1.TORI_KBN_NM" & i & ", WK1.MAE_HASU" & i &
                        ", WK1.MAE_TANKA" & i & ", WK1.MAE_TUMITATE" & i &
                        ", WK1.ATO_TANKA" & i & ", WK1.ATO_TUMITATE" & i &
                        ", WK1.ATO_SAGAKU" & i & ",WK1.JUNJO" & i & "," & vbCrLf
            Next
            '--変更前
            wSql &= "  WK1.MAE_HASU7, WK1.MAE_TUMITATE7, WK1.MAE_TESURYO7, WK1.MAE_SEIKYU7," & vbCrLf
            '--変更後
            wSql &= "  WK1.ATO_HASU7, WK1.ATO_TUMITATE7, WK1.ATO_TESURYO7, WK1.ATO_SEIKYU7," & vbCrLf
            '--差額
            wSql &= "  (WK1.MAE_HASU7 - WK1.ATO_HASU7) SA_HASU7, WK1.SAGAKU_TUMITATE7, SAGAKU_TESURYO7, SAGAKU_SEIKYU7," & vbCrLf
            '消費税関係　2023/08/07 JBD9020 R5インボイス対応 ADD START 
            wSql &= "  '(税率' || LBLZEI || '% ' || TRIM(TO_CHAR(SAGAKU_ZEI7,'999,999,999')) || ')' SAGAKU_ZEI7,  " & vbCrLf
            wSql &= "  '(登録番号：' || KYO.TOUROKU_NO  || ')' KYO_NUM," & vbCrLf
            '消費税関係　2023/08/07 JBD9020 R5インボイス対応 ADD END
            '--委託先
            wSql &= "  KYK.JIMUITAKU_CD," & vbCrLf
            wSql &= "  ITK.ITAKU_NAME," & vbCrLf
            wSql &= "  ITK.BANK_INJI_KBN " & vbCrLf
            wSql &= "FROM" & vbCrLf
            wSql &= "  TM_KYOKAI KYO," & vbCrLf
            wSql &= "  TM_KEIYAKU KYK," & vbCrLf
            wSql &= "  TM_KEIYAKU MOT," & vbCrLf
            wSql &= "  TM_TANKA TAN," & vbCrLf
            wSql &= "  TM_BANK BNK," & vbCrLf
            wSql &= "  TM_SITEN SIT," & vbCrLf
            wSql &= "  TM_CODE M04," & vbCrLf
            wSql &= "  TM_JIMUITAKU ITK," & vbCrLf
            wSql &= "  TM_SYORI_KI SKI," & vbCrLf
            wSql &= "  TM_CODE M01," & vbCrLf
            wSql &= "  TM_CODE M02," & vbCrLf
            wSql &= "  (SELECT" & vbCrLf
            wSql &= "     ATU.SAKI_KEIYAKUSYA_CD," & vbCrLf
            wSql &= "     ATU.MOTO_KEIYAKUSYA_CD," & vbCrLf
            wSql &= "     MAX(ATU.NOFUKIGEN_DATE) NOFUKIGEN_DATE," & vbCrLf
            wSql &= "     MAX(ATU.SEIKYU_HAKKO_DATE) SEIKYU_HAKKO_DATE," & vbCrLf
            wSql &= "     MAX(ATU.SEIKYU_HAKKO_NO_NEN) SEIKYU_HAKKO_NO_NEN," & vbCrLf
            wSql &= "     MAX(ATU.SEIKYU_HAKKO_NO_RENBAN) SEIKYU_HAKKO_NO_RENBAN," & vbCrLf
            For i = 1 To 6
                '--変更前　明細
                wSql &= "     MAX(CASE WHEN AME.JUNJO = " & i & " THEN M07.MEISYO ELSE NULL END) TORI_KBN_NM" & i & "," & vbCrLf
                wSql &= "     SUM(CASE WHEN AME.JUNJO = " & i & " THEN MME.HASU   ELSE NULL END) MAE_HASU" & i & "," & vbCrLf
                wSql &= "     SUM(CASE WHEN AME.JUNJO = " & i & " THEN MME.TUMITATE_TANKA ELSE NULL END) MAE_TANKA" & i & "," & vbCrLf
                wSql &= "     SUM(CASE WHEN AME.JUNJO = " & i & " THEN MME.TUMITATE_KIN   ELSE NULL END) MAE_TUMITATE" & i & "," & vbCrLf
                '--変更後　明細
                wSql &= "     MAX(CASE WHEN AME.JUNJO = " & i & " THEN AME.JUNJO ELSE NULL END) JUNJO" & i & "," & vbCrLf
                'wSql &= "     " & i & " JUNJO" & i & ","
                wSql &= "     SUM(CASE WHEN AME.JUNJO = " & i & " THEN AME.TUMITATE_TANKA ELSE NULL END) ATO_TANKA" & i & "," & vbCrLf
                wSql &= "     SUM(CASE WHEN AME.JUNJO = " & i & " THEN AME.TUMITATE_KIN   ELSE NULL END) ATO_TUMITATE" & i & "," & vbCrLf
                wSql &= "     SUM(CASE WHEN AME.JUNJO = " & i & " THEN AME.SAGAKU_TUMITATE_KIN  ELSE NULL END) ATO_SAGAKU" & i & "," & vbCrLf
            Next
            '--変更前　明細
            wSql &= "     SUM(MME.HASU) MAE_HASU7," & vbCrLf
            wSql &= "     SUM(MME.HASU) ATO_HASU7," & vbCrLf
            '--変更前　積立
            wSql &= "     MAX(MTU.TUMITATE_KIN) MAE_TUMITATE7," & vbCrLf
            wSql &= "     MAX(MTU.TESURYO)      MAE_TESURYO7," & vbCrLf
            wSql &= "     MAX(MTU.SEIKYU_KIN)   MAE_SEIKYU7," & vbCrLf
            '--変更後　積立
            wSql &= "     MAX(ATU.TUMITATE_KIN) ATO_TUMITATE7," & vbCrLf
            wSql &= "     MAX(ATU.TESURYO)      ATO_TESURYO7," & vbCrLf
            wSql &= "     MAX(ATU.SEIKYU_KIN)   ATO_SEIKYU7," & vbCrLf
            wSql &= "     MAX(ATU.SAGAKU_TUMITATE_KIN) SAGAKU_TUMITATE7," & vbCrLf
            wSql &= "     MAX(ATU.SAGAKU_TESURYO)      SAGAKU_TESURYO7," & vbCrLf
            wSql &= "     MAX(ATU.SAGAKU_SEIKYU_KIN)   SAGAKU_SEIKYU7" & vbCrLf
            '2023/08/07 JBD9020 R5インボイス対応 ADD START
            wSql &= "     ,MAX(ATU.SAGAKU_TESURYO_SYOHIZEI)    SAGAKU_ZEI7" & vbCrLf
            wSql &= "     ,MAX(ATU.TESURYO_SYOHIZEI_RITU)      LBLZEI" & vbCrLf
            '2023/08/07 JBD9020 R5インボイス対応 ADD END
            wSql &= "   FROM" & vbCrLf
            wSql &= "     TM_CODE M07," & vbCrLf
            '--変更後積立
            wSql &= "     (SELECT"
            wSql &= "        KEIYAKUSYA_CD SAKI_KEIYAKUSYA_CD,"
            wSql &= "        " & pCurrentKey.MOTO_KEIYAKUSYA_CD & " MOTO_KEIYAKUSYA_CD," & vbCrLf
            wSql &= "        MAX(NOFUKIGEN_DATE) NOFUKIGEN_DATE," & vbCrLf
            wSql &= "        MAX(SEIKYU_HAKKO_DATE) SEIKYU_HAKKO_DATE," & vbCrLf
            wSql &= "        MAX(SEIKYU_HAKKO_NO_NEN) SEIKYU_HAKKO_NO_NEN," & vbCrLf
            wSql &= "        MAX(SEIKYU_HAKKO_NO_RENBAN) SEIKYU_HAKKO_NO_RENBAN," & vbCrLf
            wSql &= "        SUM(TUMITATE_KIN) TUMITATE_KIN," & vbCrLf
            wSql &= "        SUM(TESURYO)      TESURYO," & vbCrLf
            wSql &= "        SUM(SEIKYU_KIN)   SEIKYU_KIN," & vbCrLf
            wSql &= "        SUM(SAGAKU_TUMITATE_KIN) SAGAKU_TUMITATE_KIN," & vbCrLf
            wSql &= "        SUM(SAGAKU_TESURYO)      SAGAKU_TESURYO," & vbCrLf
            wSql &= "        SUM(SAGAKU_SEIKYU_KIN)   SAGAKU_SEIKYU_KIN" & vbCrLf
            '2023/08/07 JBD9020 R5インボイス対応 ADD START
            wSql &= "        ,MAX(TESURYO_SYOHIZEI_RITU)    TESURYO_SYOHIZEI_RITU" & vbCrLf
            wSql &= "        ,SUM(SAGAKU_TESURYO_SYOHIZEI)  SAGAKU_TESURYO_SYOHIZEI" & vbCrLf
            '2023/08/07 JBD9020 R5インボイス対応 ADD END
            wSql &= "      FROM" & vbCrLf
            If rbtn_SYORI_KBN0.Checked Then
                wSql &= "        TW_TUMITATE" & vbCrLf   '仮発行
            Else
                wSql &= "        TT_TUMITATE" & vbCrLf   '仮発行以外
            End If
            wSql &= "      WHERE KI = " & pCurrentKey.KI & vbCrLf
            wSql &= "        AND SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU & vbCrLf
            wSql &= "        AND KEIYAKUSYA_CD = " & pCurrentKey.SAKI_KEIYAKUSYA_CD & vbCrLf
            wSql &= "        AND TUMITATE_KBN = 1" & vbCrLf
            wSql &= "      GROUP BY" & vbCrLf
            wSql &= "        KEIYAKUSYA_CD) ATU," & vbCrLf
            '--変更前積立
            wSql &= "     (SELECT" & vbCrLf
            wSql &= "        " & pCurrentKey.SAKI_KEIYAKUSYA_CD & " SAKI_KEIYAKUSYA_CD," & vbCrLf
            wSql &= "        KEIYAKUSYA_CD MOTO_KEIYAKUSYA_CD," & vbCrLf
            '2016/10/28　修正開始
            '2016/10/28　修正開始
            '( 無効にした積立金明細　－　再作成した積立金明細 ) の合計 
            'wSql &= "        SUM(TUMITATE_KIN) TUMITATE_KIN,"
            'wSql &= "        SUM(TESURYO)      TESURYO,"
            'wSql &= "        SUM(SEIKYU_KIN)  SEIKYU_KIN"
            wSql &= "        SUM(CASE WHEN DATA_FLG = 0 THEN TUMITATE_KIN ELSE TUMITATE_KIN * -1 END) TUMITATE_KIN," & vbCrLf
            wSql &= "        SUM(CASE WHEN DATA_FLG = 0 THEN TESURYO      ELSE TESURYO      * -1 END) TESURYO," & vbCrLf
            wSql &= "        SUM(CASE WHEN DATA_FLG = 0 THEN SEIKYU_KIN   ELSE SEIKYU_KIN   * -1 END) SEIKYU_KIN" & vbCrLf
            '2023/08/07 JBD9020 R5インボイス対応 ADD START
            wSql &= "       ,MAX(TESURYO_SYOHIZEI_RITU)   TESURYO_SYOHIZEI_RITU" & vbCrLf
            wSql &= "       ,SUM(CASE WHEN DATA_FLG = 0 THEN TESURYO_SYOHIZEI   ELSE TESURYO_SYOHIZEI   * -1 END) TESURYO_SYOHIZEI" & vbCrLf
            'wSql &= "       ,SUM(SAGAKU_TESURYO_SYOHIZEI)   SAGAKU_TESURYO_SYOHIZEI" & vbCrLf

            'wSql &= "       ,TRUNC(SUM(CASE WHEN DATA_FLG = 0 THEN TESURYO      ELSE TESURYO      * -1 END)" & vbCrLf
            'wSql &= "        * MAX(TESURYO_SYOHIZEI_RITU) / (100 + MAX(TESURYO_SYOHIZEI_RITU)))" & vbCrLf
            'wSql &= "        SAGAKU_TESURYO_SYOHIZEI" & vbCrLf

            '2023/08/07 JBD9020 R5インボイス対応 ADD END
            '2016/10/28　修正終了
            wSql &= "      FROM" & vbCrLf
            If rbtn_SYORI_KBN0.Checked Then
                wSql &= "        TW_TUMITATE" & vbCrLf   '仮発行
            Else
                wSql &= "        TT_TUMITATE" & vbCrLf   '仮発行以外
            End If
            wSql &= "      WHERE KI = " & pCurrentKey.KI & vbCrLf
            '2016/10/28　修正開始
            'wSql &= "        AND SAKI_SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU
            wSql &= "        AND (SAKI_SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU & " OR" & vbCrLf
            wSql &= "             SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU & ")" & vbCrLf
            '2016/10/28　修正終了
            wSql &= "        AND KEIYAKUSYA_CD = " & pCurrentKey.MOTO_KEIYAKUSYA_CD & vbCrLf
            wSql &= "        AND TUMITATE_KBN = 1" & vbCrLf
            wSql &= "      GROUP BY" & vbCrLf
            wSql &= "        KEIYAKUSYA_CD) MTU," & vbCrLf
            '--変更後積立明細
            wSql &= "     (SELECT" & vbCrLf
            wSql &= "        KEIYAKUSYA_CD SAKI_KEIYAKUSYA_CD," & vbCrLf
            wSql &= "        " & pCurrentKey.MOTO_KEIYAKUSYA_CD & " MOTO_KEIYAKUSYA_CD," & vbCrLf
            wSql &= "        TORI_KBN," & vbCrLf
            wSql &= "        RANK() OVER(ORDER BY TORI_KBN) JUNJO," & vbCrLf
            wSql &= "        SUM(HASU) HASU," & vbCrLf
            wSql &= "        MAX(TUMITATE_TANKA) TUMITATE_TANKA," & vbCrLf
            wSql &= "        SUM(TUMITATE_KIN) TUMITATE_KIN," & vbCrLf
            wSql &= "        SUM(SAGAKU_TUMITATE_KIN) SAGAKU_TUMITATE_KIN" & vbCrLf
            wSql &= "      FROM" & vbCrLf
            If rbtn_SYORI_KBN0.Checked Then
                wSql &= "        TW_TUMITATE_MEISAI" & vbCrLf    '仮発行
            Else
                wSql &= "        TT_TUMITATE_MEISAI" & vbCrLf    '仮発行以外
            End If
            wSql &= "      WHERE KI = " & pCurrentKey.KI & vbCrLf
            wSql &= "        AND SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU & vbCrLf
            wSql &= "        AND KEIYAKUSYA_CD = " & pCurrentKey.SAKI_KEIYAKUSYA_CD & vbCrLf
            wSql &= "        AND TUMITATE_KBN = 1" & vbCrLf
            wSql &= "      GROUP BY" & vbCrLf
            wSql &= "        KEIYAKUSYA_CD, TORI_KBN) AME," & vbCrLf
            '--変更前積立明細
            wSql &= "     (SELECT" & vbCrLf
            wSql &= "        " & pCurrentKey.SAKI_KEIYAKUSYA_CD & " SAKI_KEIYAKUSYA_CD," & vbCrLf
            wSql &= "        KEIYAKUSYA_CD MOTO_KEIYAKUSYA_CD," & vbCrLf
            wSql &= "        TORI_KBN," & vbCrLf
            wSql &= "        MAX(TUMITATE_TANKA) TUMITATE_TANKA," & vbCrLf
            '2016/10/28　修正開始
            '( 無効にした積立金明細　－　再作成した積立金明細 ) の合計  
            'wSql &= "        SUM(HASU) HASU,"
            'wSql &= "        SUM(TUMITATE_KIN) TUMITATE_KIN"
            wSql &= "        SUM(CASE WHEN DATA_FLG = 0 THEN HASU ELSE HASU * -1 END) HASU," & vbCrLf
            wSql &= "        SUM(CASE WHEN DATA_FLG = 0 THEN TUMITATE_KIN ELSE TUMITATE_KIN * -1 END) TUMITATE_KIN" & vbCrLf
            '2016/10/28　修正終了
            wSql &= "      FROM" & vbCrLf
            If rbtn_SYORI_KBN0.Checked Then
                wSql &= "        TW_TUMITATE_MEISAI" & vbCrLf    '仮発行
            Else
                wSql &= "        TT_TUMITATE_MEISAI" & vbCrLf    '仮発行以外
            End If
            wSql &= "      WHERE KI = " & pCurrentKey.KI & vbCrLf
            '2016/10/28　修正開始
            'wSql &= "        AND SAKI_SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU
            wSql &= "        AND (SAKI_SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU & " OR" & vbCrLf
            wSql &= "             SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU & ")" & vbCrLf
            '2016/10/28　修正終了
            wSql &= "        AND KEIYAKUSYA_CD = " & pCurrentKey.MOTO_KEIYAKUSYA_CD & vbCrLf
            wSql &= "        AND TUMITATE_KBN = 1" & vbCrLf
            wSql &= "      GROUP BY" & vbCrLf
            wSql &= "        KEIYAKUSYA_CD, TORI_KBN) MME" & vbCrLf

            wSql &= "   WHERE ATU.SAKI_KEIYAKUSYA_CD = MTU.SAKI_KEIYAKUSYA_CD" & vbCrLf
            wSql &= "     AND ATU.SAKI_KEIYAKUSYA_CD = AME.SAKI_KEIYAKUSYA_CD" & vbCrLf
            wSql &= "     AND AME.SAKI_KEIYAKUSYA_CD = MME.SAKI_KEIYAKUSYA_CD" & vbCrLf
            wSql &= "     AND AME.TORI_KBN = MME.TORI_KBN" & vbCrLf
            wSql &= "     AND 7 = M07.SYURUI_KBN(+)" & vbCrLf
            wSql &= "     AND AME.TORI_KBN = M07.MEISYO_CD(+)" & vbCrLf
            wSql &= "   GROUP BY" & vbCrLf
            wSql &= "     ATU.SAKI_KEIYAKUSYA_CD, ATU.MOTO_KEIYAKUSYA_CD" & vbCrLf
            wSql &= "  ) WK1 " & vbCrLf
            wSql &= "WHERE 1 = KYO.KYOKAI_KBN(+)" & vbCrLf
            '--譲渡先　契約者マスタ
            wSql &= "  AND " & pCurrentKey.KI & " = KYK.KI(+)" & vbCrLf
            wSql &= "  AND WK1.SAKI_KEIYAKUSYA_CD = KYK.KEIYAKUSYA_CD(+)" & vbCrLf
            '--譲渡元　契約者マスタ
            wSql &= "  AND " & pCurrentKey.KI & " = MOT.KI(+)" & vbCrLf
            wSql &= "  AND WK1.MOTO_KEIYAKUSYA_CD = MOT.KEIYAKUSYA_CD(+)" & vbCrLf
            '--単価マスタ
            wSql &= "  AND '" & Format(pCurrentKey.KEIYAKU_DATE_FROM, "yyyy/MM/dd") & "' >= TAN.TAISYO_DATE_FROM(+)" & vbCrLf
            wSql &= "  AND '" & Format(pCurrentKey.KEIYAKU_DATE_FROM, "yyyy/MM/dd") & "' <= TAN.TAISYO_DATE_TO(+)" & vbCrLf
            wSql &= "  AND 9 = TAN.KEIYAKU_KBN(+)" & vbCrLf
            wSql &= "  AND 9 = TAN.TORI_KBN(+)" & vbCrLf

            '--コードマスタ(譲渡先　契約区分)
            wSql &= "  AND 1 = M01.SYURUI_KBN(+)" & vbCrLf
            wSql &= "  AND KYK.KEIYAKU_KBN = M01.MEISYO_CD(+)" & vbCrLf
            '--コードマスタ(譲渡元　契約区分)
            wSql &= "  AND 1 = M02.SYURUI_KBN(+)" & vbCrLf
            wSql &= "  AND MOT.KEIYAKU_KBN = M02.MEISYO_CD(+)" & vbCrLf

            '--委託先マスタ
            wSql &= "  AND KYK.KI = ITK.KI(+)" & vbCrLf
            wSql &= "  AND KYK.JIMUITAKU_CD = ITK.ITAKU_CD(+)" & vbCrLf
            ''--銀行
            'wSql &= "  AND KYO.FURI_BANK_CD = BNK.BANK_CD(+)"
            ''--支店
            'wSql &= "  AND KYO.FURI_BANK_CD = SIT.BANK_CD(+)"
            'wSql &= "  AND KYO.FURI_BANK_SITEN_CD = SIT.SITEN_CD(+)"
            ''--コードマスタ(口座)
            'wSql &= "  AND 4 = M04.SYURUI_KBN(+)"
            'wSql &= "  AND KYO.FURI_KOZA_SYUBETU = M04.MEISYO_CD(+)"

            If pCurrentKey.KEIYAKU_HENKO_KBN = 4 Then
                '徴収　(家族→企業)
                '--銀行
                wSql &= "  AND KYO.FURI_BANK_CD = BNK.BANK_CD(+)" & vbCrLf
                '--支店
                wSql &= "  AND KYO.FURI_BANK_CD = SIT.BANK_CD(+)" & vbCrLf
                wSql &= "  AND KYO.FURI_BANK_SITEN_CD = SIT.SITEN_CD(+)" & vbCrLf
                '--コードマスタ(口座)
                wSql &= "  AND 4 = M04.SYURUI_KBN(+)" & vbCrLf
                wSql &= "  AND KYO.FURI_KOZA_SYUBETU = M04.MEISYO_CD(+)" & vbCrLf
            Else
                '返還　(企業→家族)
                '--銀行
                wSql &= "  AND KYK.FURI_BANK_CD = BNK.BANK_CD(+)" & vbCrLf
                '--支店
                wSql &= "  AND KYK.FURI_BANK_CD = SIT.BANK_CD(+)" & vbCrLf
                wSql &= "  AND KYK.FURI_BANK_SITEN_CD = SIT.SITEN_CD(+)" & vbCrLf
                '--コードマスタ(口座)
                wSql &= "  AND 4 = M04.SYURUI_KBN(+)" & vbCrLf
                wSql &= "  AND KYK.FURI_KOZA_SYUBETU = M04.MEISYO_CD(+)" & vbCrLf
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

End Class
