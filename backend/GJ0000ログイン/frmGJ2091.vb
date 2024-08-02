'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ2091.vb
'*
'*　　②　機能概要　　　　　契約者積立金等入金・返還確認
'*
'*　　③　作成日　　　　　　2015/02/22　BY JBD
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

Public Class frmGJ2091

#Region "***変数定義***"

    ''' <summary>
    ''' 固定項目
    ''' </summary>
    ''' <remarks></remarks>
    Property p2090_KI As Integer

    ''' <summary>
    ''' 処理状況
    ''' </summary>
    ''' <remarks></remarks>
    Property pLoadErr As Boolean

    ''' <summary>
    ''' グリッドキーリスト
    ''' </summary>
    ''' <remarks></remarks>
    Public paryKEY_2090 As New List(Of frmGJ2090.T_KEY)

    ''' <summary>
    ''' カレント主キー
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pCurrentKey As frmGJ2090.T_KEY

    ''' <summary>
    ''' 行No
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pSel_NO As Integer

    ''' <summary>
    ''' 処理区分
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pSyoriKbn As Enu_SyoriKubun

    ''' <summary>
    '''  画面入力内容変更フラグ
    ''' </summary>
    ''' <remarks></remarks>
    Private loblnTextChange As Boolean                   '画面入力内容変更フラグ

    ''' <summary>
    ''' 処理区分
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Enu_SyoriKubun
        ''' <summary>
        ''' 新規登録モード
        ''' </summary>
        ''' <remarks></remarks>
        Insert = 0
        ''' <summary>
        ''' 更新モード
        ''' </summary>
        ''' <remarks></remarks>
        Update = 1
    End Enum

    ''' <summary>
    '''  プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True             '処理ジャンプ
    Private pSyoriJyokyoKbn As Integer          '処理状況
    Private pSeikyuHenkanKbn As Integer         '請求変換区分

    Private pSAGAKU_SEIKYU_KIN As Long          '積立金DB.【差額】請求(返還)金額計
    Private pSAGAKU_TUMITATE_KIN As Long        '積立金DB.【差額】積立金
    Private pSAGAKU_TESURYO As Long             '積立金DB.【差額】手数料
    Private pTOKUSOKU_HAKKO_DATE As String      '積立金DB.督促状発行日
    Private pTUMI_NOFUKIGEN As Date             '積立金DB.納付期限 2021/07/13 JBD9020 新契約日追加 ADD
    Private pKEIYAKU_JOKYO As Integer           '契約マスタ.契約状況 2021/07/13 JBD9020 新契約日追加 ADD
    Private pKEIYAKU_DATE As Date               '契約マスタ.契約日 2021/07/13 JBD9020 新契約日追加 ADD

    '#54 ADD START
    Private pTUMITATE_KIN As Long        '積立金DB.積立金
    Private pTESURYO As Long             '積立金DB.手数料
    '#54 ADD END

#End Region

#Region "***画面制御関連***"

#Region "frmFS2020_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmEM2020_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmXXXLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ret As Boolean

        Try

            '---------------------------------------------------
            '初期表示
            '---------------------------------------------------
            ret = f_ObjectClear("C")

            '画面内容をセット
            If Not f_SetForm_Data(pCurrentKey) Then
                pLoadErr = True
                Throw New Exception("該当データが存在しませんでした")
            End If

            'ボタン


            '初期コントロールにフォーカスセット
            dateNYUKIN_DATE.Select()

            f_setControlChangeEvents()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try

    End Sub
#End Region

#End Region

#Region "***画面ボタンクリック関連***"

#Region "cmdSave_Click 入金登録ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdSave_Click
    '説明            :入金登録ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim ea As New System.ComponentModel.CancelEventArgs
        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try


            '事前チェック
            If Not f_Input_Check() Then
                Exit Try
            End If

            '入金登録確認
            If Show_MessageBox("", "入金登録します。よろしいですか？", 4, 4, 1) = DialogResult.No Then    '保存します。よろしいですか？
                '「キャンセル」を選択
                Exit Try
            End If

            '登録処理
            If Not f_Data_Toroku() Then
                Exit Try
            End If

            loblnTextChange = False      '画面入力内容変更フラグ

            'フォームクローズ
            Me.Close()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try


    End Sub

#End Region

#Region "cmdTorikesi_Click 入金取消ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdTorikesi_Click
    '説明            :入金取消ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdTorikesi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTorikesi.Click
        Dim ea As New System.ComponentModel.CancelEventArgs
        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            ''事前チェック
            'If Not f_Input_Check() Then
            '    Exit Try
            'End If

            '2016/05/17　追加開始
            '--------------------------------------------------
            '積立データチェック
            '--------------------------------------------------
            '通常積立金
            If pCurrentKey.TUMITATE_KBN = 1 Then
                If Not f_Delete_Check() Then
                    Exit Try
                End If
            End If
            '2016/05/17　追加終了


            '入金取消処理確認
            If Show_MessageBox("", "入金取消します。よろしいですか？", 4, 4, 1) = DialogResult.No Then    '保存します。よろしいですか？
                '「キャンセル」を選択
                Exit Try
            End If

            '取消処理
            If Not f_Data_Torikesi() Then
                Exit Try
            End If

            loblnTextChange = False      '画面入力内容変更フラグ

            'フォームクローズ
            Me.Close()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

#Region "cmdBunkatu_Click 分割入金ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdBunkatu_Click
    '説明            :分割入金ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdBunkatu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBunkatu.Click
        Dim ea As New System.ComponentModel.CancelEventArgs
        'カーソルを砂時計にする
        Me.Cursor = Cursors.WaitCursor

        Try

            Using wkForm As New frmGJ2092

                wkForm.Owner = Me
                wkForm.Owner = Me
                wkForm.pSyoriKbn = frmGJ2092.Enu_SyoriKubun.Update
                wkForm.pCurrentKey = pCurrentKey    '現在選択されている行のキーを渡します
                wkForm.p2090_KI = p2090_KI          '期を渡します

                wkForm.pLnk_GAMEN = 2               '画面番号を渡します
                wkForm.pLnk_BIKO = txtBIKO.Text    '備考を渡します
                wkForm.ShowDialog()

            End Using

            'フォームクローズ
            Me.Close()

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
            If loblnTextChange Then
                '画面に変更があり保存していない場合は、メッセージ表示
                If Show_MessageBox("Q007", "") = DialogResult.No Then
                    Exit Try
                End If
            End If

            '親フォームに現在選択されている行のキーを渡します
            DirectCast(Owner, frmGJ2090).pSel_POS = pSel_NO - 1

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

#End Region

#Region "*** 画面コントロール制御関連 ***"

#End Region

#Region "*** データ登録関連 ***"

#Region "f_Data_Toroku 入金データ登録"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Toroku
    '説明            :入金データ登録
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '作成日          :2012/08/10
    '------------------------------------------------------------------
    Private Function f_Data_Toroku() As Boolean
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.CommandText = "PKG_GJ2090.GJ2090_NYUKIN_TOROKU"


            '引き渡し
            '期
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", p2090_KI)
            '請求（返還）回数
            Dim paraSEIKYU_KAISU As OracleParameter = Cmd.Parameters.Add("IN_SEIKYU_KAISU", pCurrentKey.SEIKYU_KAISU)
            '契約者番号
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", pCurrentKey.KEIYAKUSYA_CD)
            '積立金区分
            Dim paraTUMITATE_KBN As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_KBN", pCurrentKey.TUMITATE_KBN)


            '入金（返還）日 積立入金日
            Dim paraNYUKIN_DATE As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_DATE", CDate(Format(dateNYUKIN_DATE.Value, "yyyy/MM/dd").TrimEnd))
            '入金(返還)入力日 積立入金入力日
            '#88 UPD START
            'Dim paraNYUKIN_NYURYOKU_DATE As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_NYURYOKU_DATE", Now)
            Dim paraNYUKIN_NYURYOKU_DATE As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_NYURYOKU_DATE", CDate(Format(Now, "yyyy/MM/dd").TrimEnd))
            '#88 UPD END
            '備考
            Dim paraBIKO As OracleParameter = Cmd.Parameters.Add("IN_BIKO", txtBIKO.Text.TrimEnd)


            '積立入金DB
            '入金回数(回数：1)
            Dim paraNYUKIN_KAISU As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_KAISU", 1)
            '入金額(積立金DB.【差額】請求(返還)金額計)
            Dim paraNYUKIN_GAKU As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_GAKU", pSAGAKU_SEIKYU_KIN)
            '積立入金額(積立金DB.【差額】積立金)
            Dim paraNYUKIN_TUMITATE As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_TUMITATE", pSAGAKU_TUMITATE_KIN)
            '手数料入金額(積立金DB.【差額】手数料)
            Dim paraNYUKIN_TESU As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_TESU", pSAGAKU_TESURYO)
            '入金残
            Dim paraNYUKIN_ZAN As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_ZAN", 0)

            '#54 ADD START
            '積立金額
            Dim paraNYUKIN_TUMITATE_HENKAN As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_TUMITATE_HENKAN", pTUMITATE_KIN)
            '手数料
            Dim paraNYUKIN_TESU_HENKAN As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_TESU_HENKAN", pTESURYO)
            '#54 ADD END

            '積立金DB
            '処理状況(入金済：3)
            Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 3)
            '積立金入金区分(一括：1)
            Dim paraNYUKIN_KBN As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_KBN", 1)

            '契約日
            '納付期限の判定
            Dim SyoriKI = New Obj_TM_SYORI_NENDO_KI()
            Dim dtKEIYAKU_DATE As Date

            '2021/07/13 JBD9020 新契約日追加 UPD START
            'If SyoriKI.pNOFU_KIGEN < dateNYUKIN_DATE.Value Then
            '    '契約日を入金日にする
            '    dtKEIYAKU_DATE = dateNYUKIN_DATE.Value
            'Else
            '    '契約日を事業開始年月日する
            '    dtKEIYAKU_DATE = SyoriKI.pJIGYO_NENDO_byDate
            'End If
            'Dim paraKEIYAKU_DATE As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_DATE", CDate(Format(dtKEIYAKU_DATE, "yyyy/MM/dd").TrimEnd))

            '未継続の場合
            If pKEIYAKU_JOKYO = 3 Then
                Dim paraKEIYAKU_DATE As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_DATE", DBNull.Value)
            Else
                '新規の場合
                If pKEIYAKU_JOKYO = 1 Then
                    '入金日が納付期限より後の場合
                    If pTUMI_NOFUKIGEN < dateNYUKIN_DATE.Value Then
                        '契約日が入金日
                        dtKEIYAKU_DATE = dateNYUKIN_DATE.Value
                        '入金日が納付期限以前の場合
                    Else
                        '契約日は更新なし
                        dtKEIYAKU_DATE = pKEIYAKU_DATE
                    End If
                    '継続の場合
                Else
                    '一部返還の場合
                    'If pSeikyuHenkanKbn = 3 Then
                    '    dtKEIYAKU_DATE = SyoriKI.pJIGYO_NENDO_byDate
                    'End If
                    '入金日が当初納付期限より後の場合
                    If SyoriKI.pNOFU_KIGEN < dateNYUKIN_DATE.Value Then
                        '入金日が納付期限より後の場合
                        If pTUMI_NOFUKIGEN < dateNYUKIN_DATE.Value Then
                            '契約日が入金日
                            dtKEIYAKU_DATE = dateNYUKIN_DATE.Value
                            '入金日が納付期限以前の場合
                        Else
                            '契約日は更新なし
                            dtKEIYAKU_DATE = pKEIYAKU_DATE
                        End If
                    Else
                        '契約日を事業開始年月日する
                        dtKEIYAKU_DATE = SyoriKI.pJIGYO_NENDO_byDate
                    End If
                End If
                Dim paraKEIYAKU_DATE As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_DATE", CDate(Format(dtKEIYAKU_DATE, "yyyy/MM/dd").TrimEnd))
            End If
            '2021/07/13 JBD9020 新契約日追加 UPD END

            '契約マスタ．契約日は、変更区分=0(新規)のときのみ更新
            Dim paraKEIYAKU_HENKO_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_HENKO_KBN", lbl_KEIYAKU_HENKO_KBN.Text)   '2016/05/20　追加

            Dim paraREGDATE As OracleParameter = Cmd.Parameters.Add("IN_REG_DATE", Now)                 'データ登録日
            Dim paraREGID As OracleParameter = Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)            'データ登録ＩＤ
            Dim paraUPDATE As OracleParameter = Cmd.Parameters.Add("IN_UP_DATE", Now)                   'データ更新日
            Dim paraUPID As OracleParameter = Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)              'データ更新ＩＤ
            Dim paraCOMNM As OracleParameter = Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)               'コンピュータ名

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 4000, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()

            If p_MSGCD.Value.ToString = "0" Then
                '正常
            Else
                Show_MessageBox("", p_MSGNM.Value.ToString)
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

#Region "f_Data_Torikesi 入金データ削除"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Torikesi
    '説明            :入金データ削除
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '作成日          :2012/08/10
    '------------------------------------------------------------------
    Private Function f_Data_Torikesi() As Boolean
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False

        Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure

            Cmd.CommandText = "PKG_GJ2090.GJ2090_NYUKIN_TORIKESI"

            '引き渡し
            '期
            Dim paraKI As OracleParameter = Cmd.Parameters.Add("IN_KI", p2090_KI)
            '請求（返還）回数
            Dim paraSEIKYU_KAISU As OracleParameter = Cmd.Parameters.Add("IN_SEIKYU_KAISU", pCurrentKey.SEIKYU_KAISU)
            '契約者番号
            Dim paraKEIYAKUSYA_CD As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", pCurrentKey.KEIYAKUSYA_CD)
            '積立金区分
            Dim paraTUMITATE_KBN As OracleParameter = Cmd.Parameters.Add("IN_TUMITATE_KBN", pCurrentKey.TUMITATE_KBN)


            '入金（返還）日 積立入金日
            Dim paraNYUKIN_DATE As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_DATE", DBNull.Value)
            '入金(返還)入力日 積立入金入力日
            Dim paraNYUKIN_NYURYOKU_DATE As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_NYURYOKU_DATE", DBNull.Value)
            '備考
            Dim paraBIKO As OracleParameter = Cmd.Parameters.Add("IN_BIKO", txtBIKO.Text.TrimEnd)


            '積立入金DB
            '入金回数(回数：0)
            Dim paraNYUKIN_KAISU As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_KAISU", 0)
            '入金額(積立金DB.【差額】請求(返還)金額計)
            Dim paraNYUKIN_GAKU As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_GAKU", 0)
            '積立入金額(積立金DB.【差額】積立金)
            Dim paraNYUKIN_TUMITATE As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_TUMITATE", 0)
            '手数料入金額(積立金DB.【差額】手数料)
            Dim paraNYUKIN_TESU As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_TESU", 0)
            '入金残
            Dim paraNYUKIN_ZAN As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_ZAN", 0)

            '積立金DB
            '処理状況(請求中：1 or 督促中：2)
            If pTOKUSOKU_HAKKO_DATE Is Nothing Then
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 1)
            Else
                Dim paraSYORI_JOKYO_KBN As OracleParameter = Cmd.Parameters.Add("IN_SYORI_JOKYO_KBN", 2)
            End If
            '積立金入金区分(一括：1)
            Dim paraNYUKIN_KBN As OracleParameter = Cmd.Parameters.Add("IN_NYUKIN_KBN", DBNull.Value)


            '契約日(NULL)
            Dim paraKEIYAKU_DATE As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_DATE", DBNull.Value)
            '契約マスタ．契約日は、変更区分=0(新規)のときのみ更新
            Dim paraKEIYAKU_HENKO_KBN As OracleParameter = Cmd.Parameters.Add("IN_KEIYAKU_HENKO_KBN", lbl_KEIYAKU_HENKO_KBN.Text)   '2016/05/20　追加


            Dim paraREGDATE As OracleParameter = Cmd.Parameters.Add("IN_REG_DATE", Now)                 'データ登録日
            Dim paraREGID As OracleParameter = Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)            'データ登録ＩＤ
            Dim paraUPDATE As OracleParameter = Cmd.Parameters.Add("IN_UP_DATE", Now)                   'データ更新日
            Dim paraUPID As OracleParameter = Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)              'データ更新ＩＤ
            Dim paraCOMNM As OracleParameter = Cmd.Parameters.Add("IN_COM_NAME", pPCNAME)               'コンピュータ名


            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()

            If p_MSGCD.Value.ToString = "0" Then
                '正常
            Else
                Show_MessageBox("", p_MSGNM.Value.ToString)
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

#Region "***ローカル関数***"

#Region "f_setControlChangeEvents 変更判定イベント登録処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_setControlChangeEvents
    '説明            :変更判定イベント登録処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
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
                Case TypeOf wkCtrl Is JBD.Gjs.Win.GroupBox
                    For Each wkItem In DirectCast(wkCtrl, JBD.Gjs.Win.GroupBox).Controls
                        If TypeOf wkItem Is JBD.Gjs.Win.RadioButton Then
                            AddHandler DirectCast(wkItem, JBD.Gjs.Win.RadioButton).CheckedChanged, AddressOf f_setChanged
                        End If
                    Next

                    '↓===== 2012/01/27 JBD200 ADD タブコントロール内の項目の変更判定追加 =====↓
                Case TypeOf wkCtrl Is System.Windows.Forms.TabControl
                    For Each wkItem In DirectCast(wkCtrl, System.Windows.Forms.TabControl).Controls

                        Select Case True
                            Case TypeOf wkItem Is System.Windows.Forms.TabPage

                                For Each wkItem2 In DirectCast(wkItem, System.Windows.Forms.TabPage).Controls

                                    Select Case True
                                        Case TypeOf wkItem2 Is JBD.Gjs.Win.GcMask
                                            AddHandler DirectCast(wkItem2, JBD.Gjs.Win.GcMask).TextChanged, AddressOf f_setChanged
                                        Case TypeOf wkItem2 Is JBD.Gjs.Win.GcTextBox
                                            AddHandler DirectCast(wkItem2, JBD.Gjs.Win.GcTextBox).TextChanged, AddressOf f_setChanged

                                    End Select

                                Next

                        End Select

                    Next
                    '↑===== 2012/01/27 JBD200 ADD タブコントロール内の項目の変更判定追加 =====↑

            End Select

        Next
    End Sub
#End Region

#Region "f_setChanged コントロール変更時処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_setChanged
    '説明            :コントロール変更時処理
    '引数            :
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Sub f_setChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        loblnTextChange = True

    End Sub
#End Region

#Region "f_ObjectClear 画面クリア処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ObjectClear
    '説明            :画面クリア処理
    '引数            :rKbn(処理区分)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ObjectClear(ByVal wKbn As String) As Boolean
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim sSql As String = String.Empty
        Dim dstDataControl As New DataSet
        Dim wHasu As Integer = 0
        Dim ret As Boolean = False

        Try

            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            pJump = True
            f_ClearFormALL(Me, wKbn)
            pJump = False

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

        Return ret

    End Function

#End Region

#Region "f_SetForm_Data 初期画面表示処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_SetForm_Data(ByVal wkKey As frmGJ2090.T_KEY) As Boolean
        Dim ret As Boolean = False
        Dim ea As New System.ComponentModel.CancelEventArgs
        Dim wkDS As New DataSet
        Dim wSql As String = String.Empty

        Try

            '==SQL作成====================
            wSql &= "SELECT"
            wSql &= "     KEI.KEIYAKUSYA_CD AS KEIYAKUSYA_CD"
            wSql &= "    ,KEI.KEN_CD AS KEN_CD"
            wSql &= "    ,CD05.MEISYO AS KEN_CD_NM"
            wSql &= "    ,TUM.SYORI_JOKYO_KBN AS SYORI_JOKYO_KBN"
            wSql &= "    ,CD15.MEISYO AS SYORI_JOKYO_KBN_NM"
            wSql &= "    ,KEI.KEIYAKUSYA_NAME AS KEIYAKUSYA_NAME"
            wSql &= "    ,KEI.KEIYAKUSYA_KANA AS KEIYAKUSYA_KANA"
            wSql &= "    ,DECODE(KEI.ADDR_POST, NULL, '', ('〒' || SUBSTR(KEI.ADDR_POST,1,3) || '-' || SUBSTR(KEI.ADDR_POST,4,4))) AS ADDR_POST"
            wSql &= "    ,KEI.ADDR_1 || KEI.ADDR_2 || KEI.ADDR_3 || KEI.ADDR_4 AS ADDR"
            wSql &= "    ,KEI.ADDR_TEL1 AS ADDR_TEL1"
            wSql &= "    ,KEI.ADDR_TEL2 AS ADDR_TEL2 "
            wSql &= "    ,KEI.ADDR_FAX AS ADDR_FAX"
            wSql &= "    ,KEI.FURI_BANK_CD AS FURI_BANK_CD"
            wSql &= "    ,BANK.BANK_NAME As FURI_BANK_NAME"
            wSql &= "    ,KEI.FURI_BANK_SITEN_CD AS FURI_BANK_SITEN_CD"
            wSql &= "    ,SITEN.SITEN_NAME AS FURI_BANK_SITEN_NAME"
            wSql &= "    ,KEI.FURI_KOZA_SYUBETU AS FURI_KOZA_SYUBETU"
            wSql &= "    ,CD04.MEISYO AS FURI_KOZA_SYUBETU_NM"
            wSql &= "    ,KEI.FURI_KOZA_NO AS FURI_KOZA_NO"
            wSql &= "    ,KEI.FURI_KOZA_MEIGI_KANA AS FURI_KOZA_MEIGI_KANA"
            wSql &= "    ,KEI.JIMUITAKU_CD AS JIMUITAKU_CD"
            wSql &= "    ,JIM.ITAKU_NAME AS JIMUITAKU_NM"
            wSql &= "	 ,KEI.KI AS KI"
            wSql &= "	 ,TO_CHAR(TUM.SEIKYU_DATE, 'EEYY/mm/dd','nls_calendar = ''Japanese Imperial''') AS SEIKYU_DATE"
            wSql &= "	 ,TUM.SEIKYU_KAISU AS SEIKYU_KAISU"
            wSql &= "	 ,TUM.SEIKYU_HENKAN_KBN AS SEIKYU_HENKAN_KBN"
            wSql &= "	 ,CD08.MEISYO AS SEIKYU_HENKAN_KBN_NM"
            wSql &= "	 ,TUM.NYUKIN_DATE AS NYUKIN_DATE"
            '2017/08/30　修正開始
            'wSql &= "	 ,TO_CHAR(TUM.SAGAKU_SEIKYU_KIN, '999,999,999') AS SAGAKU_SEIKYU_KIN"
            'wSql &= "	 ,TO_CHAR(TUM.TUMITATE_KIN, '999,999,999') AS TUMITATE_KIN"
            'wSql &= "	 ,TO_CHAR(TUM.TESURYO, '999,999,999') AS TESURYO"
            'wSql &= "	 ,TO_CHAR(TUM.SEIKYU_KIN, '999,999,999') AS SEIKYU_KIN"
            wSql &= "	 ,TO_CHAR(TUM.SAGAKU_SEIKYU_KIN, 'FM999,999,999') AS SAGAKU_SEIKYU_KIN"
            wSql &= "	 ,TO_CHAR(TUM.TUMITATE_KIN, 'FM999,999,999') AS TUMITATE_KIN"
            wSql &= "	 ,TO_CHAR(TUM.TESURYO, 'FM999,999,999') AS TESURYO"
            wSql &= "	 ,TO_CHAR(TUM.SEIKYU_KIN, 'FM999,999,999') AS SEIKYU_KIN"
            '2017/08/30　修正終了
            wSql &= "	 ,TUM.BIKO AS BIKO"

            wSql &= "	 ,TUM.SAGAKU_SEIKYU_KIN AS SAGAKU_SEIKYU_KIN_SAVE"
            wSql &= "	 ,TUM.SAGAKU_TUMITATE_KIN AS SAGAKU_TUMITATE_KIN_SAVE"
            wSql &= "	 ,TUM.SAGAKU_TESURYO AS SAGAKU_TESURYO_SAVE"
            wSql &= "	 ,TUM.TOKUSOKU_HAKKO_DATE AS TOKUSOKU_HAKKO_DATE_SAVE"
            wSql &= "	 ,TUM.KEIYAKU_HENKO_KBN AS KEIYAKU_HENKO_KBN"       '2016/05/20　追加
            wSql &= "	 ,TUM.NOFUKIGEN_DATE " '2021/07/13 JBD9020 新契約日追加 ADD
            wSql &= "    ,KEI.KEIYAKU_JYOKYO " '2021/07/13 JBD9020 新契約日追加 ADD
            wSql &= "    ,KEI.KEIYAKU_DATE " '2021/07/13 JBD9020 新契約日追加 ADD

            wSql &= " FROM"
            wSql &= "     TM_KEIYAKU KEI"
            wSql &= "    ,TT_TUMITATE TUM"
            wSql &= "    ,TM_CODE CD15"
            wSql &= "    ,TM_CODE CD08"
            wSql &= "    ,TM_CODE CD05"
            wSql &= "    ,TM_CODE CD04"
            wSql &= "    ,TM_BANK BANK"
            wSql &= "    ,TM_SITEN SITEN"
            wSql &= "    ,TM_JIMUITAKU JIM"
            wSql &= " WHERE"
            '-- 積立金DB
            wSql &= "      KEI.KI = TUM.KI(+)"
            wSql &= "  AND KEI.KEIYAKUSYA_CD = TUM.KEIYAKUSYA_CD(+)"
            wSql &= "  AND 1 = TUM.TUMITATE_KBN(+)"
            '-- 処理状況
            wSql &= "  AND TUM.SYORI_JOKYO_KBN = CD15.MEISYO_CD(+)"
            wSql &= "  AND 15 = CD15.SYURUI_KBN(+)"
            '-- 積立金請求・返還区分
            wSql &= "  AND TUM.SEIKYU_HENKAN_KBN = CD08.MEISYO_CD(+)"
            wSql &= "  AND 8 = CD08.SYURUI_KBN(+)"
            '-- 都道府県
            wSql &= "  AND KEI.KEN_CD = CD05.MEISYO_CD(+)"
            wSql &= "  AND 5 = CD05.SYURUI_KBN(+)"
            '-- 口座種別
            wSql &= "  AND KEI.FURI_KOZA_SYUBETU = CD04.MEISYO_CD(+)"
            wSql &= "  AND 4 = CD04.SYURUI_KBN(+)"
            '-- 金融機関
            wSql &= "  AND KEI.FURI_BANK_CD = BANK.BANK_CD(+)"
            '-- 金融機関支店マスタ
            wSql &= "  AND KEI.FURI_BANK_CD = SITEN.BANK_CD(+)"
            wSql &= "  AND KEI.FURI_BANK_SITEN_CD = SITEN.SITEN_CD(+)"
            '-- 事務委託
            wSql &= "  AND KEI.KI = JIM.KI(+)"
            wSql &= "  AND KEI.JIMUITAKU_CD = JIM.ITAKU_CD(+)"

            '-- 条件
            wSql &= "  AND KEI.KI =  " & p2090_KI
            wSql &= "  AND TUM.DATA_FLG = 1"
            wSql &= "  AND TUM.TUMITATE_KBN = " & pCurrentKey.TUMITATE_KBN
            wSql &= "  AND KEI.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND TUM.SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU

            'DBからデータを取得
            If f_Select_ODP(wkDS, wSql) = False Then
                Return False
            End If

            'データ有無
            If wkDS.Tables(0).Rows.Count = 0 Then
                'データ無し
                Show_MessageBox("I003", "")         '指定された条件に一致するデータは存在しません。
                dateNYUKIN_DATE.Enabled = False
                txtBIKO.Enabled = False
                cmdSave.Enabled = False
                cmdTorikesi.Enabled = False
                cmdBunkatu.Enabled = False
                Exit Try
            End If

            With wkDS.Tables(0)

                '契約者番号
                lblKEIYAKUSYA_CD.Text = WordHenkan("N", "S", .Rows(0)("KEIYAKUSYA_CD"))
                '都道府県
                lblKEN_NM.Text = WordHenkan("N", "S", .Rows(0)("KEN_CD_NM"))
                '処理状況
                lblSYORI_JOKYO_KBN.Text = WordHenkan("N", "S", .Rows(0)("SYORI_JOKYO_KBN_NM"))
                '契約者名
                lblKEIYAKUSYA_NAME.Text = WordHenkan("N", "S", .Rows(0)("KEIYAKUSYA_NAME"))
                '契約者名(カナ)
                lblKEIYAKUSYA_KANA.Text = WordHenkan("N", "S", .Rows(0)("KEIYAKUSYA_KANA"))
                '郵便番号
                lblADDR_POST.Text = WordHenkan("N", "S", .Rows(0)("ADDR_POST"))
                '住所
                lblADDR.Text = WordHenkan("N", "S", .Rows(0)("ADDR"))
                '電話1
                lblADDR_TEL1.Text = WordHenkan("N", "S", .Rows(0)("ADDR_TEL1"))
                '電話2
                lblADDR_TEL2.Text = WordHenkan("N", "S", .Rows(0)("ADDR_TEL2"))
                'FAX
                lblADDR_FAX.Text = WordHenkan("N", "S", .Rows(0)("ADDR_FAX"))
                '金融機関
                lblFURI_BANK_NAME.Text = WordHenkan("N", "S", .Rows(0)("FURI_BANK_NAME"))
                '金融機関支店
                lblFURI_BANK_SITEN_NAME.Text = WordHenkan("N", "S", .Rows(0)("FURI_BANK_SITEN_NAME"))
                '口座種別
                lblFURI_KOZA_SYUBETU_NM.Text = WordHenkan("N", "S", .Rows(0)("FURI_KOZA_SYUBETU_NM"))
                '口座番号
                lblFURI_KOZA_NO.Text = WordHenkan("N", "S", .Rows(0)("FURI_KOZA_NO"))
                '口座名義人(カナ)
                lblFURI_KOZA_MEIGI_KANA.Text = WordHenkan("N", "S", .Rows(0)("FURI_KOZA_MEIGI_KANA"))
                '事務委託先CD
                lblJIMUITAKU_CD.Text = WordHenkan("N", "S", .Rows(0)("JIMUITAKU_CD"))
                '事務委託先名
                lblJIMUITAKU_NM.Text = WordHenkan("N", "S", .Rows(0)("JIMUITAKU_NM"))

                '---------------------------------------------------
                '請求入金内容
                '---------------------------------------------------
                '期
                'lbl_KI.Text = "第" & p2090_KI & "期"
                lblKI.Text = p2090_KI
                '請求・返還日
                lblSEIKYU_DATE.Text = WordHenkan("N", "S", .Rows(0)("SEIKYU_DATE"))
                '請求・返還回数
                lblSEIKYU_KAISU.Text = WordHenkan("N", "S", .Rows(0)("SEIKYU_KAISU"))
                '徴収・返還区分
                lblSEIKYU_HENKAN_KBN_NM.Text = WordHenkan("N", "S", .Rows(0)("SEIKYU_HENKAN_KBN_NM"))
                pSeikyuHenkanKbn = CInt(WordHenkan("N", "Z", .Rows(0)("SEIKYU_HENKAN_KBN")))
                '入金・振込日
                If .Rows(0)("NYUKIN_DATE") Is DBNull.Value Then
                    If Not pCurrentKey.NYURYOKU_YMD = "" Then
                        dateNYUKIN_DATE.Value = CDate(pCurrentKey.NYURYOKU_YMD)
                    End If
                Else
                    dateNYUKIN_DATE.Value = CDate(.Rows(0)("NYUKIN_DATE"))
                End If
                '請求・返還金額
                lblSAGAKU_SEIKYU_KIN.Text = WordHenkan("N", "S", .Rows(0)("SAGAKU_SEIKYU_KIN"))

                '積立金額
                lblTUMITATE_KIN.Text = WordHenkan("N", "S", .Rows(0)("TUMITATE_KIN"))
                '#54 ADD START
                pTUMITATE_KIN = WordHenkan("N", "Z", .Rows(0)("TUMITATE_KIN"))        '積立金DB.積立金
                '#54 ADD END

                '手数料
                lblTESURYO.Text = WordHenkan("N", "S", .Rows(0)("TESURYO"))
                '#54 ADD START
                pTESURYO = WordHenkan("N", "Z", .Rows(0)("TESURYO"))                  '積立金DB.手数料
                '#54 ADD END

                '積立金等総計
                lblSEIKYU_KIN.Text = WordHenkan("N", "S", .Rows(0)("SEIKYU_KIN"))

                '備考 
                txtBIKO.Text = WordHenkan("N", "S", .Rows(0)("BIKO"))

                '処理状況により使用できるボタンを切替
                pSyoriJyokyoKbn = CInt(WordHenkan("N", "Z", .Rows(0)("SYORI_JOKYO_KBN")))

                '退避
                '積立金DB.【差額】請求(返還)金額計
                pSAGAKU_SEIKYU_KIN = .Rows(0)("SAGAKU_SEIKYU_KIN_SAVE")
                '積立金DB.【差額】積立金
                pSAGAKU_TUMITATE_KIN = .Rows(0)("SAGAKU_TUMITATE_KIN_SAVE")
                '積立金DB.【差額】手数料
                pSAGAKU_TESURYO = .Rows(0)("SAGAKU_TESURYO_SAVE")
                '積立金DB.督促状発行日
                If .Rows(0)("TOKUSOKU_HAKKO_DATE_SAVE") Is DBNull.Value Then
                    pTOKUSOKU_HAKKO_DATE = Nothing
                Else
                    pTOKUSOKU_HAKKO_DATE = CDate(.Rows(0)("TOKUSOKU_HAKKO_DATE_SAVE")).ToString
                End If

                '契約変更区分
                lbl_KEIYAKU_HENKO_KBN.Text = .Rows(0)("KEIYAKU_HENKO_KBN")

                '2021/07/13 JBD9020 新契約日追加 ADD START
                '納付期限
                Date.TryParse(.Rows(0)("NOFUKIGEN_DATE"), pTUMI_NOFUKIGEN)
                '契約状況
                pKEIYAKU_JOKYO = .Rows(0)("KEIYAKU_JYOKYO")
                '契約日
                If .Rows(0)("KEIYAKU_DATE") Is DBNull.Value Then
                    pKEIYAKU_DATE = Nothing
                Else
                    pKEIYAKU_DATE = CDate(.Rows(0)("KEIYAKU_DATE")).ToString
                End If
                '2021/07/13 JBD9020 新契約日追加 ADD END
            End With

            '処理状況により使用できるボタンを切替()
            If pSyoriJyokyoKbn = 3 Then
                '入金済
                cmdSave.Enabled = False       '一括入金　×
                cmdTorikesi.Enabled = True      '取消　　　○
                cmdBunkatu.Enabled = False    '分割入金　×
            Else
                '未入金
                cmdSave.Enabled = True       '一括入金　○
                cmdTorikesi.Enabled = False      '取消　　　×
                cmdBunkatu.Enabled = True    '分割入金　○
            End If

            '#40 ADD START
            '請求返還区分が3（請求兼返還（返還））または4（全額返還）の場合は分割入金ボタンを使用不可とする
            If pSeikyuHenkanKbn = 3 Or pSeikyuHenkanKbn = 4 Then
                cmdBunkatu.Enabled = False
            End If
            '#40 ADD END


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

        Dim sSql As String = String.Empty
        Dim dstDataSet As New DataSet

        Try

            '==FromToチェック==================



            '==必須チェック==================
            If dateNYUKIN_DATE.Value Is Nothing Then
                Call Show_MessageBox_Add("W008", "入金・振込日") : dateNYUKIN_DATE.Focus() : Exit Try
            End If


            '==いろいろチェック==================

            Select Case pSyoriKbn
                Case Enu_SyoriKubun.Insert '新規登録時チェック

                Case Enu_SyoriKubun.Update '更新時チェック

            End Select

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function

#End Region
#Region "f_Delete_Check 削除チェック"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Delete_Check
    '説明            :削除チェック
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '追加日          :2016/05/18　追加
    '------------------------------------------------------------------
    Private Function f_Delete_Check() As Boolean
        Dim ret As Boolean = False
        Dim wDS As New DataSet
        Dim wSql As String = String.Empty
        Dim wRow As Integer = 0

        Try

            '------------------------------------------------------------
            '   積立金入金済み　チェック
            '------------------------------------------------------------
            '積立金データ取得
            wSql &= "SELECT"
            wSql &= "  COUNT(TUM.KEIYAKUSYA_CD) KENSU,"
            wSql &= "  MIN(KJO.DATA_FLG) DATA_FLG "
            wSql &= "FROM"
            wSql &= "  TT_TUMITATE TUM,"
            wSql &= "  TT_KEIYAKU_JOHO KJO "
            wSql &= "WHERE TUM.KI = " & p2090_KI
            wSql &= "  AND TUM.SEIKYU_KAISU = " & pCurrentKey.SEIKYU_KAISU
            wSql &= "  AND TUM.KEIYAKUSYA_CD = " & pCurrentKey.KEIYAKUSYA_CD
            wSql &= "  AND TUM.TUMITATE_KBN = " & pCurrentKey.TUMITATE_KBN
            wSql &= "  AND TUM.KI = KJO.KI(+)"
            wSql &= "  AND TUM.KEIYAKUSYA_CD = KJO.KEIYAKUSYA_CD(+)"
            wSql &= "  AND TUM.SEIKYU_KAISU = KJO.SEIKYU_KAISU(+)"

            'DBからデータを取得
            If Not f_Select_ODP(wDS, wSql) Then
                Exit Try
            End If

            'データ有無
            If wDS.Tables(0).Rows.Count = 0 OrElse wDS.Tables(0).Rows(0)("KENSU").ToString = "0" Then
                Show_MessageBox_Add("I007", "該当のデータが存在しません。")
            ElseIf pSeikyuHenkanKbn = 4 Then
                '全額返還のときは、契約情報は存在しない
            ElseIf wDS.Tables(0).Rows(0)("DATA_FLG").ToString <> "1" Then
                '無効データは入金取消不可
                Show_MessageBox_Add("I007", "該当の契約は既に変更済みです。" & vbCrLf &
                                            "入金取消できません。")
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


End Class
