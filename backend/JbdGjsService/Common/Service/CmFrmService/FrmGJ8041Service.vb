' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ8041関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8041

    Public Class FrmGJ8041Service

#Region "f_SetForm_Data データ取得SQL"
        '------------------------------------------------------------------
        'プロシージャ名  :f_SetForm_Data
        '説明            :データ取得SQL
        '引数            :1.req SearchDetailRequest  データセット
        '戻り値          :String(SQL)
        '------------------------------------------------------------------
        Public Shared Function f_SetForm_Data(req As InitDetailRequest) As String
            Dim wSql As String = String.Empty
            'SQL
            wSql = " SELECT " & vbCrLf
            wSql += "  * " & vbCrLf
            wSql += " FROM" & vbCrLf
            wSql += "  TM_USER" & vbCrLf
            wSql += " WHERE" & vbCrLf
            wSql += "  USER_ID = '" & req.USER_ID & "'" & vbCrLf
            Return wSql
        End Function
#End Region

#Region "f_Data_Update 使用者マスタデータ更新"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Data_Insert
        '説明            :使用者マスタデータ更新
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Shared Function f_Data_Update(db As DaDbContext, wNojoCd As SaveRequest) As DaResponseBase
            Dim Cmd As New OracleCommand
            Dim ret As Boolean = False

            'ストアドプロシージャの呼び出し
            Cmd.Connection = db.Session.Connection
            Cmd.CommandType = CommandType.StoredProcedure

            Select Case wNojoCd.EDIT_KBN
                Case EnumEditKbn.Edit       '変更入力
                    Cmd.CommandText = "PKG_GJ8041.GJ8041_USER_UPD"
                Case EnumEditKbn.Add       '新規入力
                    Cmd.CommandText = "PKG_GJ8041.GJ8041_USER_INS"
            End Select

            '引き渡し
            'ユーザーID 
            Cmd.Parameters.Add("IN_USER_USER_ID", wNojoCd.USER.USER_ID)
            '最新ログイン番号
            Cmd.Parameters.Add("IN_USER_NEW_LOGIN_NO", pLOGINUSERID)
            'ユーザー名 
            Cmd.Parameters.Add("IN_USER_USER_NAME", wNojoCd.USER.USER_NAME)
            'パスワード
            Cmd.Parameters.Add("IN_USER_PASS", wNojoCd.USER.PASS)
            'パスワード変更日
            Cmd.Parameters.Add("IN_USER_PASS_UP_DATE", wNojoCd.USER.PASS_UP_DATE)
            'パスワード有効期限
            Cmd.Parameters.Add("IN_USER_PASS_KIGEN_DATE", wNojoCd.USER.PASS_KIGEN_DATE)
            'パスワード変更回数
            Cmd.Parameters.Add("IN_USER_PASS_KAISU", 0)
            '使用区分
            Cmd.Parameters.Add("IN_USER_SIYO_KBN", wNojoCd.USER.SIYO_KBN)
            '停止日
            Cmd.Parameters.Add("IN_USER_TEISI_DATE", wNojoCd.USER.TEISI_DATE)
            '停止理由コード
            Cmd.Parameters.Add("IN_USER_TEISI_RIYU", wNojoCd.USER.TEISI_RIYU)

            'データ登録日
            Cmd.Parameters.Add("IN_ITAKU_REG_DATE", Now)
            'データ登録ＩＤ
            Cmd.Parameters.Add("IN_ITAKU_REG_ID", pLOGINUSERID)
            'データ更新日
            Cmd.Parameters.Add("IN_ITAKU_UP_DATE", Now)
            'データ更新ＩＤ
            Cmd.Parameters.Add("IN_ITAKU_UP_ID", pLOGINUSERID)
            'コンピュータ名
            Cmd.Parameters.Add("IN_ITAKU_COM_NAME", pPCNAME)

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
            Return New DaResponseBase
        End Function

#End Region

#Region "f_Data_Deleate 使用者マスタデータ削除処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Data_Deleate
        '説明            :使用者マスタデータ削除処理
        '引数            :なし
        '戻り値          :DaResponseBase
        '------------------------------------------------------------------
        Public Shared Function f_Data_Deleate(db As DaDbContext, wNojoCd As DeleteRequest) As DaResponseBase

            Dim wkCmd As New OracleCommand
            Dim wkSql As String = String.Empty
            Dim wkRet As Boolean = False

            'ストアドプロシージャの呼び出し
            wkCmd.Connection = db.Session.Connection
            wkCmd.CommandType = CommandType.StoredProcedure
            wkCmd.CommandText = "PKG_GJ8041.GJ8041_USER_DEL"

            '引き渡し
            wkCmd.Parameters.Add("IN_USER_USER_ID", wNojoCd.USER_ID)

            '戻り
            Dim p_MSGCD As OracleParameter = wkCmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = wkCmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            wkCmd.ExecuteNonQuery()

            Debug.Print(wkCmd.Parameters("OU_MSGCD").Value.ToString())
            If wkCmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                If wkCmd.Parameters("OU_MSGCD").Value.ToString() = "99" Then
                    '削除済みは政情終了とみなす
                    wkRet = True
                    Return New DaResponseBase(EnumServiceResult.Exception , wkCmd.Parameters("OU_MSGNM").Value.ToString() & "。")
                End If
            End If

            wkRet = True

            'データベースへの接続を閉じる
            If Not wkCmd Is Nothing Then
                wkCmd.Dispose()
            End If

            Return New DaResponseBase

        End Function
#End Region

#Region "f_TM_CONTROL_Data_Select コントロールマスタデータ取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_TM_CONTROL_Data_Select
    '説明            :コントロールマスタデータ取得
    '引数            :
    '戻り値          :String
    '------------------------------------------------------------------
    Public Shared Function f_TM_CONTROL_Data_Select() As String

        Dim sSql As String = String.Empty
        Dim dstDataControl As New DataSet
        Dim ret As Boolean = False
        sSql = " SELECT " & vbCrLf
        sSql += "  PASS_KIGEN" & vbCrLf
        sSql += " FROM" & vbCrLf
        sSql += "  TM_CONTROL" & vbCrLf
        Return sSql
    End Function
#End Region

    End Class

End Namespace
