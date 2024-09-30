' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービス共通関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8091

    Public Class FrmGJ8091Service

#Region "f_SetForm_Data データ取得SQL"
        '------------------------------------------------------------------
        'プロシージャ名  :f_SetForm_Data
        '説明            :データ取得SQL
        '引数            :1.req SearchDetailRequest  データセット
        '戻り値          :String(SQL)
        '------------------------------------------------------------------
        Public Shared Function f_SetForm_Data(req As InitDetailRequest) As String
            Dim ret As Boolean = False
            Dim wkDS As New DataSet
            Dim wSql As String = String.Empty
            'SQL
            wSql = "SELECT * FROM TM_KEIYAKU_NOJO" & _
                    " WHERE KI = " & req.KI & _
                    "  AND KEIYAKUSYA_CD = " & req.KEIYAKUSYA_CD & _
                    "  AND NOJO_CD = " & req.NOJO_CD
            Return wSql
        End Function
#End Region

#Region "f_Data_Deleate 契約者農場削除処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Deleate
    '説明            :契約者農場削除処理
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
        wkCmd.CommandText = "PKG_GJ8091.GJ8091_KEIYAKU_NOJO_DEL"

        '引き渡し
        'グループコード
        Dim paraKI As OracleParameter = wkCmd.Parameters.Add("IN_KI", wNojoCd.KI)
        Dim paraKEIYAKU_CD As OracleParameter = wkCmd.Parameters.Add("IN_KEIYAKU", wNojoCd.KEIYAKUSYA_CD)
        Dim paraNOJO_CD As OracleParameter = wkCmd.Parameters.Add("IN_NOJO_CD", wNojoCd.NOJO_CD)

        '戻り
        Dim p_MSGCD As OracleParameter = wkCmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
        Dim p_MSGNM As OracleParameter = wkCmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

        wkCmd.ExecuteNonQuery()

        Debug.Print(wkCmd.Parameters("OU_MSGCD").Value.ToString())
        If wkCmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
            Return New DaResponseBase(EnumServiceResult.Exception , wkCmd.Parameters("OU_MSGNM").Value.ToString())　
        End If

        wkRet = True

        'データベースへの接続を閉じる
        If Not wkCmd Is Nothing Then
            wkCmd.Dispose()
        End If

        Return New DaResponseBase

    End Function
#End Region

#Region "f_Data_Insert 契約者農場更新処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Insert
    '説明            :契約者農場更新処理
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
                Cmd.CommandText = "PKG_GJ8091.GJ8091_KEIYAKU_NOJO_UPD"
            Case EnumEditKbn.Add       '新規入力
                Cmd.CommandText = "PKG_GJ8091.GJ8091_KEIYAKU_NOJO_INS"
        End Select

        '引き渡し
        '期 
        Cmd.Parameters.Add("IN_KI", wNojoCd.KEIYAKUSYA_NOJO.KI)
        '契約者番号
        Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", wNojoCd.KEIYAKUSYA_NOJO.KEIYAKUSYA_CD
                            )
        '農場番号 
        Cmd.Parameters.Add("IN_NOJO_CD", wNojoCd.KEIYAKUSYA_NOJO.NOJO_CD
                            )
        '都道府県コード
        Cmd.Parameters.Add("IN_KEN_CD", wNojoCd.KEIYAKUSYA_NOJO.KEN_CD
                            )
        '農場名
        Cmd.Parameters.Add("IN_NOJO_NAME", wNojoCd.KEIYAKUSYA_NOJO.NOJO_NAME
                            )

        '郵便番号
        Cmd.Parameters.Add("IN_ADDR_POST", wNojoCd.KEIYAKUSYA_NOJO.ADDR_POST
                            )
        '住所１
        Cmd.Parameters.Add("IN_ADDR_1", wNojoCd.KEIYAKUSYA_NOJO.ADDR_1
                            )
        '住所２
        Cmd.Parameters.Add("IN_ADDR_2", wNojoCd.KEIYAKUSYA_NOJO.ADDR_2
                            )
        '住所３
        If wNojoCd.KEIYAKUSYA_NOJO.ADDR_3.Trim = "" Then
            Cmd.Parameters.Add("IN_ADDR_3", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_ADDR_3", wNojoCd.KEIYAKUSYA_NOJO.ADDR_3)
        End If
        '住所４
        If wNojoCd.KEIYAKUSYA_NOJO.ADDR_4.Trim = "" Then
            Cmd.Parameters.Add("IN_ADDR_4", DBNull.Value)
        Else
            Cmd.Parameters.Add("IN_ADDR_4", wNojoCd.KEIYAKUSYA_NOJO.ADDR_4)
        End If

        '電話番号
        Cmd.Parameters.Add("IN_MEISAI_NO", wNojoCd.KEIYAKUSYA_NOJO.MEISAI_NO)

        Select Case wNojoCd.EDIT_KBN
            Case EnumEditKbn.Add       '新規入力
            'データ登録日
            Cmd.Parameters.Add("IN_REG_DATE", Now)
            'データ登録ＩＤ
            Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
        End Select

        'データ更新日
        Cmd.Parameters.Add("IN_UP_DATE", Now)
        'データ更新ＩＤ
        Cmd.Parameters.Add("IN_UP_ID", pLOGINUSERID)
        'コンピュータ名
        Cmd.Parameters.Add("IN_COM_NAME",  pPCNAME )

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

    End Class

End Namespace
