' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 処理対象期・年度マスタメンテナンス
'
' 作成日　　: 2024.07.12
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8020

    Public Class FrmGJ8020Service

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
            wSql = "SELECT * FROM TM_SYORI_KI"
            Return wSql
        End Function
#End Region

#Region "f_Data_Insert 処理対象期・年度マスタメンテナンス更新処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Data_Insert
        '説明            :処理対象期・年度マスタメンテナンス更新処理
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
                    Cmd.CommandText = "PKG_GJ8020.GJ8020_SYORI_KI_UPD"
                Case EnumEditKbn.Add       '新規入力
                    Cmd.CommandText = "PKG_GJ8020.GJ8020_SYORI_KI_INS"
            End Select

            '引き渡し
            '期 
            Cmd.Parameters.Add("IN_KI", wNojoCd.SYORI_KI.KI)
            '事業対象開始年度
            Cmd.Parameters.Add("IN_JIGYO_NENDO", wNojoCd.SYORI_KI.JIGYO_NENDO
                            )
            '事業対象終了年度 
            Cmd.Parameters.Add("IN_JIGYO_SYURYO_NENDO", wNojoCd.SYORI_KI.JIGYO_SYURYO_NENDO
                            )
            '前期積立金取込日
            Cmd.Parameters.Add("IN_ZENKI_TUMITATE_DATE", wNojoCd.SYORI_KI.ZENKI_TUMITATE_DATE
                            )
            '前期交付金取込日
            Cmd.Parameters.Add("IN_ZENKI_KOFU_DATE", wNojoCd.SYORI_KI.ZENKI_KOFU_DATE
                            )
            '返還金計算日
            Cmd.Parameters.Add("IN_HENKAN_KEISAN_DATE", wNojoCd.SYORI_KI.HENKAN_KEISAN_DATE
                            )
            '積立金返還人数
            Cmd.Parameters.Add("IN_HENKAN_NINZU", wNojoCd.SYORI_KI.HENKAN_NINZU
                            )
            '積立金返還額合計
            Cmd.Parameters.Add("IN_HENKAN_GOKEI", wNojoCd.SYORI_KI.HENKAN_GOKEI
                            )
            '前期積立金返還率
            Cmd.Parameters.Add("IN_HENKAN_RITU", wNojoCd.SYORI_KI.HENKAN_RITU
                            )
            '対象年度
            Cmd.Parameters.Add("IN_TAISYO_NENDO", wNojoCd.SYORI_KI.TAISYO_NENDO
                            )
            '当初対象積立金納付期限
            Cmd.Parameters.Add("IN_NOFU_KIGEN", wNojoCd.SYORI_KI.NOFU_KIGEN
                            )
            '現在の認定回数
            Cmd.Parameters.Add("IN_HASSEI_KAISU", wNojoCd.SYORI_KI.HASSEI_KAISU
                            )
            '備考
            Cmd.Parameters.Add("IN_BIKO", wNojoCd.SYORI_KI.BIKO
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
