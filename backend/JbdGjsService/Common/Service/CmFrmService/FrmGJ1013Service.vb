' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ1013関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1013

    Public Class FrmGJ1013Service

#Region "f_Search_SQLMake データ取得SQL"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :データ取得SQL
        '引数            :1.req SearchRequest  データセット
        '戻り値          :String(SQL)
        '------------------------------------------------------------------
        Public Shared Function f_Search_SQLMake(req As SearchRequest) As String
            Dim wSql As String = String.Empty
            'SQL
            wSql &= "SELECT"
            wSql &= "  KNO.NOJO_CD,"
            wSql &= "  KNO.NOJO_NAME NOJO_NM,"
            wSql &= "  KNO.ADDR_1||ADDR_2||ADDR_3||ADDR_4 ADDR,"
            wSql &= "  KNO.KEN_CD,"
            wSql &= "  KNO.MEISAI_NO,"
            wSql &= "  KNO.ADDR_POST,"
            wSql &= "  KNO.ADDR_1,"
            wSql &= "  KNO.ADDR_2,"
            wSql &= "  KNO.ADDR_3,"
            wSql &= "  KNO.ADDR_4 "
            wSql &= "FROM"
            wSql &= "  TM_KEIYAKU_NOJO KNO "
            wSql &= "WHERE KNO.KI = " & req.KI
            wSql &= "  AND KNO.KEIYAKUSYA_CD = " & req.KEIYAKUSYA_CD
            wSql &= "ORDER BY"
            wSql &= "  KNO.NOJO_CD"
            Return wSql
        End Function
#End Region

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
            wSql = "SELECT * FROM TM_KEIYAKU_NOJO" &
                    " WHERE KI = " & req.KI &
                    "  AND KEIYAKUSYA_CD = " & req.KEIYAKUSYA_CD &
                    "  AND NOJO_CD = " & req.NOJO_CD
            Return wSql
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
            Cmd.Parameters.Add("IN_KI", wNojoCd.NOJO_JOHO.KI)
            '契約者番号
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", wNojoCd.NOJO_JOHO.KEIYAKUSYA_CD
                            )
            '農場番号 
            Cmd.Parameters.Add("IN_NOJO_CD", wNojoCd.NOJO_JOHO.NOJO_CD
                            )
            '都道府県コード
            Cmd.Parameters.Add("IN_KEN_CD", wNojoCd.NOJO_JOHO.KEN_CD
                            )
            '農場名
            Cmd.Parameters.Add("IN_NOJO_NAME", wNojoCd.NOJO_JOHO.NOJO_NAME
                            )

            '郵便番号
            Cmd.Parameters.Add("IN_ADDR_POST", wNojoCd.NOJO_JOHO.ADDR_POST
                            )
            '住所１
            Cmd.Parameters.Add("IN_ADDR_1", wNojoCd.NOJO_JOHO.ADDR_1
                            )
            '住所２
            Cmd.Parameters.Add("IN_ADDR_2", wNojoCd.NOJO_JOHO.ADDR_2
                            )
            '住所３
            If wNojoCd.NOJO_JOHO.ADDR_3.Trim = "" Then
                Cmd.Parameters.Add("IN_ADDR_3", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_ADDR_3", wNojoCd.NOJO_JOHO.ADDR_3)
            End If
            '住所４
            If wNojoCd.NOJO_JOHO.ADDR_4.Trim = "" Then
                Cmd.Parameters.Add("IN_ADDR_4", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_ADDR_4", wNojoCd.NOJO_JOHO.ADDR_4)
            End If

            '電話番号
            Cmd.Parameters.Add("IN_MEISAI_NO", wNojoCd.NOJO_JOHO.MEISAI_NO)

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
            Return New DaResponseBase
        End Function

#End Region

    End Class

End Namespace
