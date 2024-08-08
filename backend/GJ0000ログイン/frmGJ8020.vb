'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ8020.vb
'*
'*　　②　機能概要　　　　　処理対象期・年度マスタメンテナンス
'*
'*　　③　作成日　　　　　　2015/01/16　BY JBD
'*
'*　　④　更新日            2022/01/31　JBD437 R03年度減額対応　文言修正のみ（発生回数→認定回数）
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
Public Class frmGJ8020
#Region "変数定義"

    Private pMST_DataSet As New DataSet                 'マスタ用データセット
    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ
    Private pblnErrDsp As Boolean                       'コンボ　エラー表示

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
#Region "frmGJ8020_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ8020_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ8020_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean
        Try


            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            '画面初期表示
            ret = f_ObjectClear("C")

            '画面内容をセット
            ret = f_SetForm_Data(False)

            '事業対象年度FROMにフォーカスセット
            num_KI.Focus()

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
    '------------------------------------------------------------------
    'プロシージャ名  :f_setControlChangeEvents
    '説明            :変更判定イベント登録
    '------------------------------------------------------------------
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
    '------------------------------------------------------------------
    'プロシージャ名  :f_setChanged
    '説明            :コントロール変更時処理
    '------------------------------------------------------------------
    Private Sub f_setChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        pblnTextChange = True

    End Sub
#End Region

#End Region

#Region "画面ボタンクリック関連"

#Region "cmdCan_Click キャンセルボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdCan_Click
    '説明            :キャンセルボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdCan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Dim ret As Boolean = False

        Try
            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then
                    Exit Try
                End If
            End If

            '画面クリア
            ret = f_ObjectClear("")

            '先頭入力フォーカスセット
            num_KI.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub
#End Region

#Region "cmdSav_Click 保存ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSav_Click
    '説明            :保存ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSav.Click
        Dim ret As Boolean

        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            '事前チェック
            If Not f_Input_Check(loMode, True) Then
                Exit Try
            End If

            '保存処理確認
            If Show_MessageBox("Q003", "") = DialogResult.No Then    '保存します。よろしいですか？
                Exit Try
            End If

            'データ保存処理
            If f_Data_Update() Then
                Show_MessageBox_Add("I001")
            End If

            '画面クリア
            ret = f_ObjectClear("")

            '先頭入力フォーカスセット
            num_KI.Focus()

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
            If pblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then
                    Exit Try
                End If
            Else

                If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                    Exit Try
                End If
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
#End Region

#Region "画面コントロール制御関連 "

#Region "事業対象年度(自)"
    '------------------------------------------------------------------
    'プロシージャ名  :date_JIGYO_NENDO_Validating
    '説明            :事業対象年度FROM Validatingイベント
    '------------------------------------------------------------------
    Private Sub date_JIGYO_NENDO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles date_JIGYO_NENDO.Validating

        Dim wkDate As Date

        Try
            If date_JIGYO_NENDO.Value Is Nothing Then
                'FM未入力でTOが入力だった時
                If Not date_JIGYO_SYURYO_NENDO.Value Is Nothing Then
                    date_JIGYO_SYURYO_NENDO.Value = Nothing
                End If
                Exit Sub
            End If

            wkDate = date_JIGYO_NENDO.Value
            date_JIGYO_SYURYO_NENDO.Value = wkDate.AddYears(2)

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", C_MSGICON_ERROR)
        End Try


    End Sub
#End Region

#End Region

#Region "*** データ登録関連 ***"

#Region "f_Data_Update データ更新処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Update
    '説明            :データ更新処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    ''' <summary>
    '''データ更新処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_Data_Update() As Boolean
        Dim ret As Boolean = False

        Try

            '処理対象年度マスタ登録
            If Not f_TM_SYORI_NENDO_Update() Then
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

#End Region

#Region "ローカル関数"

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

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '画面初期化
            Call f_ClearFormALL(Me, rKbn)

            '画面内容をセット
            If Not f_SetForm_Data(False) Then
                Exit Try
            End If

            '画面変更フラグ
            pblnTextChange = False

            '請求処理へ
            num_KI.Focus()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default

        End Try

    End Function
#End Region

#Region "f_SetForm_Data マスタデータ画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_SetForm_TM_KYOKAI
    '説明            :マスタデータ画面セット
    '引数            :ユーザーID
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_SetForm_Data(ByRef wErrDsp As Boolean) As Boolean
        Dim ret As Boolean = False
        Dim wkSQL As String = String.Empty

        Try

            wkSQL += "SELECT"
            wkSQL += "  KI,"                 '--期
            wkSQL += "  JIGYO_NENDO,"        '--事業対象開始年度
            wkSQL += "  JIGYO_SYURYO_NENDO," '--事業対象終了年度

            '2015/03/21  追加開始
            'wkSQL += "  ZENKI_TUMITATE_DATE,"   '--前期積立金取込日   '2015/01/19　追加
            'wkSQL += "  ZENKI_KOFU_DATE,"       '--前期交付金取込日   '2015/01/19　追加
            'wkSQL += "  HENKAN_KEISAN_DATE,"    '--返還金計算日       '2015/01/19　追加
            '--前期積立金取込日
            wkSQL &= "  TO_CHAR(ZENKI_TUMITATE_DATE, 'EEYY""/""MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ZENKI_TUMITATE_DATE,"
            '--前期交付金取込日
            wkSQL &= "  TO_CHAR(ZENKI_KOFU_DATE,     'EEYY""/""MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS ZENKI_KOFU_DATE,"
            '--返還金計算日
            wkSQL &= "  TO_CHAR(HENKAN_KEISAN_DATE,  'EEYY""/""MM""/""DD', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS HENKAN_KEISAN_DATE,"
            '2015/03/21  追加終了

            wkSQL += "  HENKAN_NINZU,"      '--積立金返還人数
            wkSQL += "  HENKAN_GOKEI,"      '--積立金返還額合計
            wkSQL += "  HENKAN_RITU,"       '--前期積立金返還率

            wkSQL += "  TAISYO_NENDO,"       '--対象年度
            wkSQL += "  NOFU_KIGEN,"         '--当初対象積立金納付期限
            wkSQL += "  HASSEI_KAISU,"       '--現在の発生回数
            wkSQL += "  BIKO,"               '--備考
            wkSQL += "  REG_DATE,"           '--データ登録日
            wkSQL += "  REG_ID,"             '--データ登録ＩＤ
            wkSQL += "  UP_DATE,"            '--データ更新日
            wkSQL += "  UP_ID,"              '--データ更新ＩＤ
            wkSQL += "  COM_NAME "           '--コンピュータ名"
            wkSQL += "FROM"
            wkSQL += "  TM_SYORI_KI"

            Call f_Select_ODP(pMST_DataSet, wkSQL)

            If pMST_DataSet.Tables(0).Rows.Count = 0 Then
                cmdCancel.Enabled = False   'キャンセル不可
                loMode = enuMode.Insert
            Else
                pblnErrDsp = False          'エラー　表示なし
                '画面にセット
                If Not f_DspForm_Data(pMST_DataSet, wErrDsp) Then
                    Exit Try
                End If
                cmdCancel.Enabled = True   'キャンセル可
                loMode = enuMode.Update
            End If

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            pblnErrDsp = True       'エラー　表示あり
            pblnTextChange = False

        End Try

        Return ret

    End Function
#End Region
#Region "f_DspForm_Data マスタデータ画面セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_DstForm_Data
    '説明            :マスタデータ画面セット
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_DspForm_Data(ByVal dstDataSet As DataSet, ByRef wErrDsp As Boolean) As Boolean
        Dim ret As Boolean = False

        Try
            If dstDataSet.Tables(0).Rows.Count > 0 Then

                With dstDataSet.Tables(0)
                    '期
                    If .Rows(0)("KI") Is DBNull.Value Then
                        num_KI.Value = Nothing
                    Else
                        num_KI.Value = CInt(WordHenkan("N", "Z", .Rows(0)("KI")))
                    End If
                    '事業対象開始年度
                    If .Rows(0)("JIGYO_NENDO") Is DBNull.Value Then
                        date_JIGYO_NENDO.Value = Nothing
                    Else
                        date_JIGYO_NENDO.Value = CDate(WordHenkan("N", "S", .Rows(0)("JIGYO_NENDO") & "/04/01"))
                    End If
                    '事業対象終了年度
                    If .Rows(0)("JIGYO_SYURYO_NENDO") Is DBNull.Value Then
                        date_JIGYO_SYURYO_NENDO.Value = Nothing
                    Else
                        date_JIGYO_SYURYO_NENDO.Value = CDate(WordHenkan("N", "S", .Rows(0)("JIGYO_SYURYO_NENDO") & "/04/01"))
                    End If

                    '2015/03/21　修正開始
                    '2015/01/019　追加開始
                    ''前期積立金取込日
                    'If .Rows(0)("ZENKI_TUMITATE_DATE") Is DBNull.Value Then
                    '    date_ZENKI_TUMITATE.Value = Nothing
                    'Else
                    '    date_ZENKI_TUMITATE.Value = CDate(WordHenkan("N", "S", .Rows(0)("ZENKI_TUMITATE_DATE")))
                    'End If
                    lbl_ZENKI_TUMITATE_DATE.Text = (WordHenkan("N", "S", .Rows(0)("ZENKI_TUMITATE_DATE")))
                    ''前期交付金取込日
                    'If .Rows(0)("ZENKI_KOFU_DATE") Is DBNull.Value Then
                    '    date_ZENKI_KOFU.Value = Nothing
                    'Else
                    '    date_ZENKI_KOFU.Value = CDate(WordHenkan("N", "S", .Rows(0)("ZENKI_KOFU_DATE")))
                    'End If
                    lbl_ZENKI_KOFU_DATE.Text = (WordHenkan("N", "S", .Rows(0)("ZENKI_KOFU_DATE")))
                    ''返還金計算日
                    'If .Rows(0)("HENKAN_KEISAN_DATE") Is DBNull.Value Then
                    '    date_HENKAN_KEISAN.Value = Nothing
                    'Else
                    '    date_HENKAN_KEISAN.Value = CDate(WordHenkan("N", "S", .Rows(0)("HENKAN_KEISAN_DATE")))
                    'End If
                    lbl_HENKAN_KEISAN_DATE.Text = (WordHenkan("N", "S", .Rows(0)("HENKAN_KEISAN_DATE")))
                    '2015/01/019　追加終了

                    '積立金返還人数
                    'If .Rows(0)("HENKAN_NINZU") Is DBNull.Value Then
                    '    num_HENKAN_NINZU.Value = Nothing
                    'Else
                    '    num_HENKAN_NINZU.Value = CInt(WordHenkan("N", "Z", .Rows(0)("HENKAN_NINZU")))
                    'End If
                    lbl_HENKAN_NINZU.Text = Format(CDbl(WordHenkan("N", "Z", .Rows(0)("HENKAN_NINZU"))), "##,###")
                    ''積立金返還額合計
                    'If .Rows(0)("HENKAN_GOKEI") Is DBNull.Value Then
                    '    num_HENKAN_GOKEI.Value = Nothing
                    'Else
                    '    num_HENKAN_GOKEI.Value = CLng(WordHenkan("N", "Z", .Rows(0)("HENKAN_GOKEI")))
                    'End If
                    lbl_HENKAN_GOKEI.Text = Format(CDbl(WordHenkan("N", "Z", .Rows(0)("HENKAN_GOKEI"))), "###,###,###")
                    ''前期積立金返還率
                    'If .Rows(0)("HENKAN_RITU") Is DBNull.Value Then
                    '    num_HENKAN_RITU.Value = Nothing
                    'Else
                    '    num_HENKAN_RITU.Value = CDbl(WordHenkan("N", "Z", .Rows(0)("HENKAN_RITU")))
                    'End If
                    lbl_HENKAN_RITU.Text = Format(CDbl(WordHenkan("N", "Z", .Rows(0)("HENKAN_RITU"))), "##.########")

                    '2015/03/21　修正終了

                    '対象年度
                    If .Rows(0)("TAISYO_NENDO") Is DBNull.Value Then
                        date_TAISYO_NENDO.Value = Nothing
                    Else
                        date_TAISYO_NENDO.Value = CDate(WordHenkan("N", "S", .Rows(0)("TAISYO_NENDO") & "/04/01"))
                    End If
                    '当初対象積立金納付期限
                    If .Rows(0)("NOFU_KIGEN") Is DBNull.Value Then
                        date_NOFU_KIGEN.Value = Nothing
                    Else
                        date_NOFU_KIGEN.Value = CDate(WordHenkan("N", "S", .Rows(0)("NOFU_KIGEN")))
                    End If
                    '現在の発生回数
                    If .Rows(0)("HASSEI_KAISU") Is DBNull.Value Then
                        num_HASSEI_KAISU.Value = Nothing
                    Else
                        num_HASSEI_KAISU.Value = CInt(WordHenkan("N", "Z", .Rows(0)("HASSEI_KAISU")))
                    End If
                    '備考
                    txt_BIKO.Text = WordHenkan("N", "S", .Rows(0)("BIKO"))

                End With
            Else

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
    '引数            :1：登録、3削除
    '            　　:警告メッセージを表示するか。
    '戻り値          :Boolean(正常True/エラーFalse)
    '作成日          :2012/01/20 H.Y
    '------------------------------------------------------------------
    Private Function f_Input_Check(ByVal wkMode As Integer, Optional ByVal wkAlertFlag As Boolean = True) As Boolean
        Dim ret As Boolean = False

        Try


            '==FromToチェック==================

            '==必須チェック==================
            '期なし
            If num_KI.Value Is Nothing Then
                Show_MessageBox_Add("W008", "事業対象期")
                num_KI.Focus()
                Exit Try
            End If

            '事業対象年度入力なし
            If date_JIGYO_NENDO.Value Is Nothing Or date_JIGYO_NENDO.Value = New Date Then
                Show_MessageBox_Add("W008", "事業対象年度")
                date_JIGYO_NENDO.Focus()
                Exit Try
            End If

            '対象年度入力なし
            If date_TAISYO_NENDO.Value Is Nothing Or date_TAISYO_NENDO.Value = New Date Then
                Show_MessageBox_Add("W008", "対象年度")
                date_TAISYO_NENDO.Focus()
                Exit Try
            End If


            '==いろいろチェック==================

            '対象年月
            If CInt(Format(date_TAISYO_NENDO.Value, "yyyy")) > CInt(Format(date_JIGYO_SYURYO_NENDO.Value, "yyyy")) OrElse _
               CInt(Format(date_TAISYO_NENDO.Value, "yyyy")) < CInt(Format(date_JIGYO_NENDO.Value, "yyyy")) Then
                '対象年度が事業対象年度の範囲外の場合
                If wkAlertFlag Then
                    Show_MessageBox_Add("W019", "対象年月は事業対象年度の範囲で指定して下さい。")
                    date_TAISYO_NENDO.Focus()
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

#Region "f_TM_SYORI_NENDO_Update DB登録処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_SYORI_NENDO_Update
    '説明            :DB登録処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    ''' <summary>
    ''' DB登録処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function f_TM_SYORI_NENDO_Update() As Boolean
        Dim wkCmd As New OracleCommand
        Dim ret As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            wkCmd.Connection = Cnn
            wkCmd.CommandType = CommandType.StoredProcedure

            If loMode = enuMode.Insert Then
                wkCmd.CommandText = "PKG_GJ8020.GJ8020_SYORI_KI_INS"
            Else
                wkCmd.CommandText = "PKG_GJ8020.GJ8020_SYORI_KI_UPD"
            End If

            '--期
            wkCmd.Parameters.Add("IN_KI", num_KI.Value)
            '--事業対象開始年度
            wkCmd.Parameters.Add("IN_JIGYO_NENDO", CDate(date_JIGYO_NENDO.Value).Year)
            '--事業対象終了年度
            wkCmd.Parameters.Add("IN_JIGYO_SYURYO_NENDO", CDate(date_JIGYO_SYURYO_NENDO.Value).Year)

            '--対象年度
            wkCmd.Parameters.Add("IN_TAISYO_NENDO", CDate(date_TAISYO_NENDO.Value).Year)
            '--当初対象積立金納付期限
            If date_NOFU_KIGEN.Value Is Nothing Then
                wkCmd.Parameters.Add("IN_NOFU_KIGEN", DBNull.Value)
            Else
                wkCmd.Parameters.Add("IN_NOFU_KIGEN", f_DateTrim(CDate(date_NOFU_KIGEN.Value)))
            End If
            '--現在の発生回数
            If num_HASSEI_KAISU.Value Is Nothing Then
                wkCmd.Parameters.Add("IN_HASSEI_KAISU", DBNull.Value)
            Else
                wkCmd.Parameters.Add("IN_HASSEI_KAISU", num_HASSEI_KAISU.Value)
            End If
            '--備考
            wkCmd.Parameters.Add("IN_BIKO", txt_BIKO.Text)

            wkCmd.Parameters.Add("IN_SYORI_NENDO_REG_DATE", Now)
            wkCmd.Parameters.Add("IN_SYORI_NENDO_REG_ID", pLOGINUSERID)
            wkCmd.Parameters.Add("IN_SYORI_NENDO_UP_DATE", Now)
            wkCmd.Parameters.Add("IN_SYORI_NENDO_UP_ID", pLOGINUSERID)
            wkCmd.Parameters.Add("IN_SYORI_NENDO_COM_NAME", pPCNAME)

            '戻り
            Dim p_MSGCD As OracleParameter = wkCmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = wkCmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            wkCmd.ExecuteNonQuery()

            If p_MSGCD.Value.ToString = "0" Then
                '正常
            Else
                Show_MessageBox("", p_MSGNM.Value.ToString)
            End If

            'データベースへの接続を閉じる
            If Not wkCmd Is Nothing Then
                wkCmd.Dispose()
            End If

            '戻り値
            If p_MSGCD.Value.ToString = "0" Then
                ret = True
            End If

        Catch ex As Exception
            '共通例外処理
            If ex.Message <> "Err" Then
                Show_MessageBox("", ex.Message)
            End If
            If Not wkCmd Is Nothing Then
                wkCmd.Dispose()
            End If
        End Try

        Return ret
    End Function
#End Region

#End Region

End Class
