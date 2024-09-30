' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ8051関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8051

    Public Class FrmGJ8051Service

#Region "f_SetForm_Data データ取得SQL"
        '------------------------------------------------------------------
        'プロシージャ名  :f_SetForm_Data
        '説明            :データ取得SQL
        '引数            :1.req SearchDetailRequest  データセット
        '戻り値          :String(SQL)
        '------------------------------------------------------------------
        Public Shared Function f_SetForm_Data(BANK_CD As String) As String
            Dim wSql As String = String.Empty
            'SQL
            wSql = " SELECT " & vbCrLf
            wSql += "  * " & vbCrLf
            wSql += " FROM" & vbCrLf
            wSql += "  TM_BANK" & vbCrLf
            wSql += " WHERE" & vbCrLf
            wSql += "  BANK_CD = " & BANK_CD
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
        Public Shared Function f_Data_Update(db As DaDbContext, wNojoCd As SaveBankRequest) As DaResponseBase
            Dim Cmd As New OracleCommand
            Dim ret As Boolean = False

            'ストアドプロシージャの呼び出し
            Cmd.Connection = db.Session.Connection
            Cmd.CommandType = CommandType.StoredProcedure

            Select Case wNojoCd.EDIT_KBN
                Case EnumEditKbn.Edit       '変更入力
                    Cmd.CommandText = "PKG_GJ8051.GJ8051_BANK_UPD"
                Case EnumEditKbn.Add       '新規入力
                    Cmd.CommandText = "PKG_GJ8051.GJ8051_BANK_INS"
                    wNojoCd.BANK.BANK_CD = Format(CInt(wNojoCd.BANK.BANK_CD), "0000")
            End Select

            '引き渡し
            '金融機関コード
            Cmd.Parameters.Add("IN_BANK_BANK_CD", wNojoCd.BANK.BANK_CD)
            '金融機関号(カナ)
            Cmd.Parameters.Add("IN_BANK_BANK_KANA", wNojoCd.BANK.BANK_KANA
                            )
            '金融機関号(漢字)
            Cmd.Parameters.Add("IN_BANK_BANK_NAME", wNojoCd.BANK.BANK_NAME
                            )
            'データ区分
            Cmd.Parameters.Add("IN_BANK_DATAKBN", 0
                            )
            'bug 1 modify sf
            'Select Case wNojoCd.EDIT_KBN
            '    Case EnumEditKbn.Add       '新規入力
            '        'データ登録日
            '        Cmd.Parameters.Add("IN_REG_DATE", Now)
            '        'データ登録ＩＤ
            '        Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
            'End Select

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

#Region "f_Data_Deleate 契約者農場削除処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Data_Deleate
        '説明            :契約者農場削除処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Shared Function f_Data_Deleate(db As DaDbContext, wNojoCd As DeleteBankRequest) As DaResponseBase

            Dim wkCmd As New OracleCommand
            Dim wkSql As String = String.Empty
            Dim wkRet As Boolean = False

            'ストアドプロシージャの呼び出し
            wkCmd.Connection = db.Session.Connection
            wkCmd.CommandType = CommandType.StoredProcedure
            wkCmd.CommandText = "PKG_GJ8051.GJ8051_BANK_DEL"

            '引き渡し
            wkCmd.Parameters.Add("IN_BANK_BANK_CD", wNojoCd.BANK_CD)

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

    End Class

End Namespace
