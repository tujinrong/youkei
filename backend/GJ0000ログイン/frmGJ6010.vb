'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ6010.vb
'*
'*　　②　機能概要　　　　　生産者積立金返還金計算処理（契約者別）
'*
'*　　③　作成日　　　　　　2015/02/23 JBD368
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


Public Class frmGJ6010

#Region "*** 変数定義 ***"

    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ

    ''' <summary>
    ''' プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True                     '処理ジャンプ

    Private pKI As Integer          '当期 対象期
    Private pZENKI_KI As Integer    '前期 対象期
    Private pZENKI_TUMITATE_DATE As Date = Nothing      '処理対象期・年度マスタ.前期積立金取込日
    Private pZENKI_KOFU_DATE As Date = Nothing          '処理対象期・年度マスタ.前期交付金取込日
    Private pHENKAN_KEISAN_DATE As Date = Nothing       '処理対象期・年度マスタ.返還金計算日

#End Region

#Region "*** 定数定義 ***"

    Private Const C_TUMI As Integer = 1       '積立金納付額取込処理
    Private Const C_KOFU As Integer = 2       '互助金交付額取込処理
    Private Const C_SANTEI As Integer = 3     '繰越額算定処理

    Private Const C_S_TUMI As String = "前期積立金納付額取込処理"
    Private Const C_S_KOFU As String = "前期互助金交付額取込処理"
    Private Const C_S_SANTEI As String = "前期繰越額算定処理"

    Private Const C_WAR001 As String = "未処理の場合、取込処理済は選択できません。"
    Private Const C_WAR002 As String = "未処理の場合、処理キャンセルは実行できません。"
    Private Const C_WAR003 As String = "再処理を行う場合は処理キャンセルを実行後、再度取込処理を行ってください。"
    Private Const C_WAR004 As String = "の処理キャンセルを実行後、実行してください。"
    Private Const C_WAR005 As String = "請求（返還）が行われている契約者が存在するため、処理キャンセルは実行できません。"
    Private Const C_WAR006 As String = C_S_SANTEI & "は、" & C_S_TUMI & "、" & C_S_KOFU & "が完了後、実行してください。"
#End Region

#Region "*** 画面制御関連 ***"

#Region "Form_Loadイベント"
    ''' <summary>
    ''' フォームロード時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmGJ6010Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            '処理実行確認メッセージ設定
            Select Case numSyori.Text
                Case C_TUMI
                    '取込処理(未処理)
                    If rdoTumiTorikomi.Checked Then
                        If Not f_Tumitate_Process() Then
                            Exit Try
                        End If

                    End If
                    '処理キャンセル
                    If rdoTumiCancel.Checked Then
                        If Not f_Tumitate_Cancel() Then
                            Exit Try
                        End If
                    End If

                Case C_KOFU
                    '取込処理(未処理)
                    If rdoKofuTorikomi.Checked Then
                        If Not f_Kofugaku_Process() Then
                            Exit Try
                        End If
                    End If
                    '処理キャンセル
                    If rdoKofuCancel.Checked Then
                        If Not f_Kofugaku_Cancel() Then
                            Exit Try
                        End If
                    End If

                Case C_SANTEI
                    '取込処理(未処理)
                    If rdoSanteiTorikomi.Checked Then
                        If Not f_Santei_Process() Then
                            Exit Try
                        End If
                    End If
                    '処理キャンセル
                    If rdoSanteiCancel.Checked Then
                        If Not f_Santei_Cancel() Then
                            Exit Try
                        End If
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
            '日付和暦変換
            Dim culture As Globalization.CultureInfo = New Globalization.CultureInfo("ja-JP")
            culture.DateTimeFormat.Calendar = New System.Globalization.JapaneseCalendar

            Dim objTM_SYORI_NENDO_KI As Obj_TM_SYORI_NENDO_KI = New Obj_TM_SYORI_NENDO_KI
            '初期値設定
            '当期 対象期
            pKI = objTM_SYORI_NENDO_KI.pKI
            '前期 対象期
            pZENKI_KI = pKI - 1

            '対象期
            lblKI.Text = pZENKI_KI

            '１：積立金取込処理
            If Not f_DateNothingCheck(objTM_SYORI_NENDO_KI.pZENKI_TUMITATE_DATE) Then
                '前期積立金取込日がNullの場合、未処理
                rdoTumiTorikomi.Checked = True
            Else
                '前期積立金取込日が登録されている場合、取込済
                rdoTumiSumi.Checked = True
                lblTumiSumiYmd.Text = objTM_SYORI_NENDO_KI.pZENKI_TUMITATE_DATE.ToString("ggyy/MM/dd", culture)
            End If

            '２：交付額取込処理
            If Not f_DateNothingCheck(objTM_SYORI_NENDO_KI.pZENKI_KOFU_DATE) Then
                '前期交付額取込日がNullの場合、未処理
                rdoKofuTorikomi.Checked = True
            Else
                '前期交付額取込日が登録されている場合、取込済
                rdoKofuSumi.Checked = True
                lblKofuSumiYmd.Text = objTM_SYORI_NENDO_KI.pZENKI_KOFU_DATE.ToString("ggyy/MM/dd", culture)
            End If

            '３：繰越額算定処理
            If Not f_DateNothingCheck(objTM_SYORI_NENDO_KI.pHENKAN_KEISAN_DATE) Then
                '返還金計算日がNullの場合、未処理
                rdoSanteiTorikomi.Checked = True
                lblNinzu.Text = ""
                lblGokei.Text = ""
                lblRitu.Text = ""
            Else
                '返還金計算日が登録されている場合、計算済
                rdoSanteiSumi.Checked = True
                lblSanteiSumiYmd.Text = objTM_SYORI_NENDO_KI.pHENKAN_KEISAN_DATE.ToString("ggyy/MM/dd", culture)
                lblNinzu.Text = Format(objTM_SYORI_NENDO_KI.pHENKAN_NINZU, "#,###")
                '2021/06/07 R03年度 JBD9020 UPD START
                'lblGokei.Text = Format(objTM_SYORI_NENDO_KI.pHENKAN_GOKEI, "#,###")
                lblGokei.Text = Format(objTM_SYORI_NENDO_KI.pHENKAN_GOKEI, "#,##0")
                '2021/06/07 R03年度 JBD9020 UPD END
                lblRitu.Text = Format(objTM_SYORI_NENDO_KI.pHENKAN_RITU, "##0.0000000")
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
        Dim ret As Boolean = False
        Dim wkControlName As String = String.Empty
        Dim wkMessage As String = String.Empty

        Try

            ''==必須チェック==================
            wkControlName = "処理選択"
            If numSyori.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", wkControlName) : numSyori.Focus() : Exit Try
            End If
            wkControlName = C_S_TUMI
            If Not rdoTumiTorikomi.Checked And Not rdoTumiSumi.Checked And Not rdoTumiCancel.Checked Then
                Call Show_MessageBox_Add("W008", wkControlName) : grpTumi.Focus() : Exit Try
            End If
            wkControlName = C_S_KOFU
            If Not rdoKofuTorikomi.Checked And Not rdoKofuSumi.Checked And Not rdoKofuCancel.Checked Then
                Call Show_MessageBox_Add("W008", wkControlName) : grpKofu.Focus() : Exit Try
            End If
            wkControlName = C_S_SANTEI
            If Not rdoSanteiTorikomi.Checked And Not rdoSanteiSumi.Checked And Not rdoSanteiCancel.Checked Then
                Call Show_MessageBox_Add("W008", wkControlName) : grpSantei.Focus() : Exit Try
            End If


            '==いろいろチェック==================

            '処理選択
            Select Case numSyori.Text
                Case "1", "2", "3"

                Case Else
                    '1,2,3以外が入力された場合はエラー
                    Call Show_MessageBox("W006", "") : numSyori.Focus() : Return False
            End Select

            '１：積立金納付額取込処理が選択されている場合
            If numSyori.Text = C_TUMI Then
                '共通エラーチェック
                If Not f_CheckSyori(rdoTumiTorikomi, rdoTumiSumi, rdoTumiCancel _
                                        , lblTumiSumiYmd, grpTumi) Then
                    Return False
                End If
                '交付額取込処理がNull以外で処理キャンセルが選択されている場合
                If lblKofuSumiYmd.Text <> "" Then
                    If rdoTumiCancel.Checked Then
                        Call Show_MessageBox_Add("W019", C_S_KOFU & C_WAR004) : grpTumi.Focus() : Exit Try
                    End If
                End If
            End If

            '２：互助金交付額取込処理が選択されている場合
            If numSyori.Text = C_KOFU Then
                '共通エラーチェック
                If Not f_CheckSyori(rdoKofuTorikomi, rdoKofuSumi, rdoKofuCancel _
                                        , lblKofuSumiYmd, grpKofu) Then
                    Return False
                End If
                '繰越算定額処理日がNull以外で処理キャンセルが選択されている場合
                If lblSanteiSumiYmd.Text <> "" Then
                    If rdoKofuCancel.Checked Then
                        Call Show_MessageBox_Add("W019", C_S_SANTEI & C_WAR004) : grpKofu.Focus() : Exit Try
                    End If
                End If
            End If

            '３：繰越額算定処理が選択されている場合
            If numSyori.Text = C_SANTEI Then
                '共通エラーチェック
                If Not f_CheckSyori(rdoSanteiTorikomi, rdoSanteiSumi, rdoSanteiCancel _
                                        , lblSanteiSumiYmd, grpSantei) Then
                    Return False
                End If
                '繰越算定額処理日がNull以外で処理キャンセルが選択されている場合
                If lblTumiSumiYmd.Text = "" OrElse lblKofuSumiYmd.Text = "" Then
                    Call Show_MessageBox_Add("W019", C_WAR006) : grpSantei.Focus() : Exit Try
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

#Region "f_CheckSyori 処理共通チェック処理"
    ''' <summary>
    ''' 処理共通チェック処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_CheckSyori(ByVal rdoTorikomi As JBD.Gjs.Win.RadioButton _
                                    , ByVal rdoSumi As JBD.Gjs.Win.RadioButton _
                                    , ByVal rdoCancel As JBD.Gjs.Win.RadioButton _
                                    , ByVal lblSyoriYmd As JBD.Gjs.Win.JLabel _
                                    , ByVal groupBox As JBD.Gjs.Win.GroupBox) As Boolean


        '処理日がNullで取込処理済が選択されている場合、エラー
        If lblSyoriYmd.Text = "" Then
            If rdoSumi.Checked Then
                Call Show_MessageBox_Add("W019", C_WAR001) : groupBox.Focus() : Return False
            End If
        End If

        '処理日がNullで処理キャンセルが選択されている場合エラー
        If lblSyoriYmd.Text = "" Then
            If rdoCancel.Checked Then
                Call Show_MessageBox_Add("W019", C_WAR002) : groupBox.Focus() : Return False
            End If
        End If

        '処理日がNull以外で取込処理(未処理)が選択されている場合エラー
        If lblSyoriYmd.Text <> "" Then
            If rdoTorikomi.Checked Then
                Call Show_MessageBox_Add("W019", C_WAR003) : groupBox.Focus() : Return False
            End If
        End If

        '処理日がNull以外で取込処理済が選択されている場合エラー
        If lblSyoriYmd.Text <> "" Then
            If rdoSumi.Checked Then
                Call Show_MessageBox_Add("W019", C_WAR003) : groupBox.Focus() : Return False
            End If
        End If

        Try
            '処理キャンセルが選択されている場合、前期積立金返還テーブル(TT_ZENKI_TUMITATE_HENKAN)に
            '請求（返還）回数がNull以外のデータが1件でも存在するときエラー
            Dim dsZenki As DataSet = New DataSet
            Dim sSql As String = String.Empty
            sSql = sSql & "SELECT " & vbCrLf
            sSql = sSql & " COUNT(*) CNT " & vbCrLf
            sSql = sSql & "FROM " & vbCrLf
            sSql = sSql & " TT_ZENKI_TUMITATE_HENKAN Z " & vbCrLf
            sSql = sSql & "WHERE " & vbCrLf
            sSql = sSql & "     Z.KI = " & pKI & vbCrLf
            sSql = sSql & " AND Z.SEIKYU_KAISU IS NOT NULL  " & vbCrLf
            sSql = sSql & " AND Z.SEIKYU_KAISU <> 0 " & vbCrLf
            If Not f_Select_ODP(dsZenki, sSql) Then
                Return False
            End If

            If dsZenki.Tables(0).Rows.Count > 0 Then
                If dsZenki.Tables(0).Rows(0)("CNT") > 0 Then
                    Call Show_MessageBox_Add("W019", C_WAR005) : groupBox.Focus() : Return False
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

#Region "f_Tumitate_Process 積立金納付額取込処理"
    ''' <summary>
    ''' 積立金納付額取込処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Tumitate_Process() As Boolean

        Dim Cmd As New OracleCommand
        Try

            '実行確認
            If Show_MessageBox_Add("Q013", C_S_TUMI & "を実行します") = DialogResult.No Then
                Return False
            End If


            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.CommandText = "PKG_GJ6010.GJ6010_TUMITATE_PROCESS"
            Cmd.Parameters.Add("IN_KI", pKI)
            Cmd.Parameters.Add("IN_ZENKI_KI", pZENKI_KI)
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

#Region "f_Tumitate_Cancel 積立金納付額取込処理キャンセル"
    ''' <summary>
    ''' 積立金納付額取込処理キャンセル
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Tumitate_Cancel() As Boolean

        Dim Cmd As New OracleCommand
        Try

            '実行確認
            If Show_MessageBox_Add("Q013", C_S_TUMI & "キャンセルを実行します") = DialogResult.No Then
                Return False
            End If

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.CommandText = "PKG_GJ6010.GJ6010_TUMITATE_CANCEL"
            Cmd.Parameters.Add("IN_KI", pKI)
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

#Region "f_Kofugaku_Process 互助金交付額取込処理"
    ''' <summary>
    ''' 互助金交付額取込処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Kofugaku_Process() As Boolean
        Dim Cmd As New OracleCommand

        Try

            '実行確認
            If Show_MessageBox_Add("Q013", C_S_KOFU & "を実行します") = DialogResult.No Then
                Return False
            End If

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.CommandText = "PKG_GJ6010.GJ6010_KOFU_PROCESS"
            Cmd.Parameters.Add("IN_KI", pKI)
            Cmd.Parameters.Add("IN_ZENKI_KI", pZENKI_KI)
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

#Region "f_Kofugaku_Cancel 互助金交付額取込処理キャンセル"
    ''' <summary>
    ''' 互助金交付額取込処理キャンセル
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Kofugaku_Cancel() As Boolean

        Dim Cmd As New OracleCommand
        Try
            '実行確認
            If Show_MessageBox_Add("Q013", C_S_KOFU & "キャンセルを実行します") = DialogResult.No Then
                Return False
            End If

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.CommandText = "PKG_GJ6010.GJ6010_KOFU_CANCEL"
            Cmd.Parameters.Add("IN_KI", pKI)
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

#Region "f_Santei_Process 繰越額算定処理"
    ''' <summary>
    ''' 繰越額算定処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Santei_Process() As Boolean

        Dim Cmd As New OracleCommand
        Try
            '実行確認
            If Show_MessageBox_Add("Q013", C_S_SANTEI & "を実行します") = DialogResult.No Then
                Return False
            End If

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.CommandText = "PKG_GJ6010.GJ6010_SANTEI_PROCESS"
            Cmd.Parameters.Add("IN_KI", pKI)
            Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
            Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)


            '戻り
            Dim p_HENKAN_NINZU As OracleParameter = Cmd.Parameters.Add("OU_HENKAN_NINZU", OracleDbType.Decimal, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_HENKAN_GOKEI As OracleParameter = Cmd.Parameters.Add("OU_HENKAN_GOKEI", OracleDbType.Decimal, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_HENKAN_RITU As OracleParameter = Cmd.Parameters.Add("OU_HENKAN_RITU", OracleDbType.BinaryFloat, 255, DBNull.Value, ParameterDirection.Output)
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

#Region "f_Santei_Cancel 繰越額算定処理キャンセル"
    ''' <summary>
    ''' 繰越額算定処理キャンセル
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Santei_Cancel() As Boolean

        Dim Cmd As New OracleCommand
        Try

            '実行確認
            If Show_MessageBox_Add("Q013", C_S_SANTEI & "キャンセルを実行します") = DialogResult.No Then
                Return False
            End If

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.CommandText = "PKG_GJ6010.GJ6010_SANTEI_CANCEL"
            Cmd.Parameters.Add("IN_KI", pKI)
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
