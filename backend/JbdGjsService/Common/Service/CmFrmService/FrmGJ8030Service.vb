' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 処理対象期・年度マスタメンテナンス
'
' 作成日　　: 2024.07.12
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Imports OracleInternal.Json

Namespace JBD.GJS.Service.GJ8030

    Public Class FrmGJ8030Service

#Region "f_SetForm_Data データ取得SQL"
        '------------------------------------------------------------------
        'プロシージャ名  :f_SetForm_Data
        '説明            :データ取得SQL
        '引数            :1.req DaRequestBase  データセット
        '戻り値          :String(SQL)
        '------------------------------------------------------------------
        Public Shared Function f_SetForm_Data(req As DaRequestBase) As String
            Dim ret As Boolean = False
            Dim wkDS As New DataSet
            Dim wSql As String = String.Empty
            'SQL
            wSql = " SELECT " & vbCrLf
            wSql += "  * " & vbCrLf
            wSql += " FROM" & vbCrLf
            wSql += "  TM_KYOKAI" & vbCrLf
            wSql += " WHERE" & vbCrLf
            wSql += "  KYOKAI_KBN = 1" & vbCrLf
            Return wSql
        End Function
#End Region

#Region "f_Data_Insert 協会マスタデータ更新処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Data_Insert
        '説明            :協会マスタデータ更新処理
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
                    Cmd.CommandText = "PKG_GJ8030.GJ8030_KYOKAI_UPD"
                Case EnumEditKbn.Add       '新規入力
                    Cmd.CommandText = "PKG_GJ8030.GJ8030_KYOKAI_INS"
            End Select

            '引き渡し
            '協会区分 １を固定で設定 
            Cmd.Parameters.Add("IN_KYOKAI_KBN", 1)
            '協会名称 ”社団法人　日本養鶏協会”
            Cmd.Parameters.Add("IN_KYOKAI_NAME", wNojoCd.KYOKAI.KYOKAI_NAME
                            )
            '役職名 ”会長”
            Cmd.Parameters.Add("IN_YAKUMEI", wNojoCd.KYOKAI.YAKUMEI
                            )
            '会長名 ”木下　寛之”
            Cmd.Parameters.Add("IN_KAICHO_NAME", wNojoCd.KYOKAI.KAICHO_NAME
                            )
            '事業名
            Cmd.Parameters.Add("IN_JIGYO_NAME", wNojoCd.KYOKAI.JIGYO_NAME
                            )
            '予備1
            Cmd.Parameters.Add("IN_YOBI1", wNojoCd.KYOKAI.YOBI1
                            )
            '郵便番号
            Cmd.Parameters.Add("IN_POST", wNojoCd.KYOKAI.POST
                            )
            '住所１
            Cmd.Parameters.Add("IN_ADDR1", wNojoCd.KYOKAI.ADDR1
                            )
            '住所２
            Cmd.Parameters.Add("IN_ADDR2", wNojoCd.KYOKAI.ADDR2
                            )
            '電話番号１ 連絡先１
            Cmd.Parameters.Add("IN_TEL1", wNojoCd.KYOKAI.TEL1
                            )
            'ＦＡＸ１
            Cmd.Parameters.Add("IN_FAX1", wNojoCd.KYOKAI.FAX1
                            )
            'Ｅ－ｍａｉｌ１
            Cmd.Parameters.Add("IN_E_MAIL1", wNojoCd.KYOKAI.E_MAIL1
                            )
            '電話番号２ 連絡先２
            Cmd.Parameters.Add("IN_TEL2", wNojoCd.KYOKAI.TEL2
                            )
            'ＦＡＸ２
            Cmd.Parameters.Add("IN_FAX2", wNojoCd.KYOKAI.FAX2
                            )
            'Ｅ－ｍａｉｌ２
            Cmd.Parameters.Add("IN_E_MAIL2", wNojoCd.KYOKAI.E_MAIL2
                            )
            'ホームページURL
            Cmd.Parameters.Add("IN_HP_URL", wNojoCd.KYOKAI.HP_URL
                            )

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
