' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ1012関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1012

    Public Class FrmGJ1012Service

#Region "f_SetForm_Data データ取得SQL"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :ＳＱＬ作成処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Shared Function f_Search_SQLMake(wKbn As SearchRequest) As String
            Dim wSql As String = String.Empty

            '==SQL作成====================
            'SQL作成
            wSql &= "SELECT"
            wSql &= "  NOJ.MEISAI_NO,"
            wSql &= "  KJO.SEQNO,"
            wSql &= "  KJO.KEIYAKU_DATE_FROM,"
            wSql &= "  KJO.KEIYAKU_DATE_TO,"
            wSql &= "  KJO.NOJO_CD,"
            wSql &= "  NOJ.NOJO_NAME NOJO_NM,"
            wSql &= "  NOJ.ADDR_1||ADDR_2||ADDR_3||ADDR_4 ADDR, "
            wSql &= "  KJO.TORI_KBN,"
            wSql &= "  M07.RYAKUSYO TORI_KBN_NM,"
            wSql &= "  KJO.KEIYAKU_HASU,"
            wSql &= "  KJO.BIKO,"
            wSql &= "  NOJ.ADDR_POST,"
            wSql &= "  NOJ.ADDR_1,"
            wSql &= "  NOJ.ADDR_2,"
            wSql &= "  NOJ.ADDR_3,"
            wSql &= "  NOJ.ADDR_4 "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO KJO,"
            wSql &= "  TM_KEIYAKU_NOJO NOJ,"
            wSql &= "  TM_CODE M07 "
            wSql &= "WHERE KJO.KI = " & wKbn.KI
            wSql &= "  AND KJO.KEIYAKUSYA_CD = " & wKbn.KEIYAKUSYA_CD
            wSql &= "  AND KJO.DATA_FLG = 1"
            wSql &= "  AND KJO.KI = NOJ.KI(+)"
            wSql &= "  AND KJO.KEIYAKUSYA_CD = NOJ.KEIYAKUSYA_CD(+)"
            wSql &= "  AND KJO.NOJO_CD = NOJ.NOJO_CD(+)"
            wSql &= "  AND 7 = M07.SYURUI_KBN(+)"
            wSql &= "  AND KJO.TORI_KBN = M07.MEISYO_CD(+) "
            wSql &= "ORDER BY"
            wSql &= "  NOJ.MEISAI_NO, KJO.NOJO_CD, KJO.TORI_KBN "

            Return wSql
        End Function
#End Region

#Region "f_Hasu_SQLMake データ取得SQL"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Hasu_SQLMake
        '説明            :ＳＱＬ作成処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Shared Function f_Hasu_SQLMake(wKbn As SearchRequest) As String
            Dim wSql As String = String.Empty

            '==SQL作成====================
            'SQL作成
            wSql &= "SELECT"
            For i = 1 To 11
                wSql &= "  SUM( CASE WHEN TORI_KBN = " & i & " THEN KEIYAKU_HASU ELSE 0 END ) HASU" & Format(i, "00") & ","
            Next
            wSql &= "  SUM( CASE WHEN TORI_KBN BETWEEN 1 AND 11 THEN KEIYAKU_HASU ELSE 0 END ) HASU00 "
            wSql &= "FROM"
            wSql &= "  TT_KEIYAKU_JOHO "
            wSql &= "WHERE KI = " & wKbn.KI
            wSql &= "  AND KEIYAKUSYA_CD = " & wKbn.KEIYAKUSYA_CD
            wSql &= "  AND DATA_FLG = 1"

            Return wSql
        End Function
#End Region

#Region "f_KeiyakuNojo_Data_Select データ取得SQL"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :ＳＱＬ作成処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Shared Function f_KeiyakuNojo_Data_Select(wKbn As SearchRequest) As String
            Dim wSql As String = String.Empty

            '==SQL作成====================
            'SQL作成
            wSql &= "SELECT"
            wSql &= "  NOJO_CD, "
            wSql &= "  NOJO_NAME "
            wSql &= "FROM"
            wSql &= "  TM_KEIYAKU_NOJO "
            wSql &= "WHERE "
            wSql &= "  KI = " & wKbn.KI & " AND KEIYAKUSYA_CD = " & wKbn.KEIYAKUSYA_CD
            wSql &= " ORDER BY NOJO_CD"

            Return wSql
        End Function
#End Region

#Region "f_SetForm_Data データ取得SQL"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :ＳＱＬ作成処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Shared Function f_SetForm_Data(wKbn As SearchRequest) As String
            Dim wSql As String = String.Empty

            '==SQL作成====================
            'SQL作成
            wSql &= "SELECT * FROM TM_KEIYAKU "
            wSql &= "WHERE "
            wSql &= "  KI = " & wKbn.KI & " AND KEIYAKUSYA_CD = " & wKbn.KEIYAKUSYA_CD

            Return wSql
        End Function
#End Region

#Region "f_NojoAddr_Dsp データ取得SQL"
        '------------------------------------------------------------------
        'プロシージャ名  :f_NojoAddr_Dsp
        '説明            :ＳＱＬ作成処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Shared Function f_NojoAddr_Dsp(wKbn As InitNojoRequest) As String
            Dim wSql As String = String.Empty

            '==SQL作成====================
            'SQL作成
            wSql &= "SELECT * FROM TM_KEIYAKU_NOJO "
            wSql &= "WHERE "
            wSql &= "  KI = " & wKbn.KI & " AND KEIYAKUSYA_CD = " & wKbn.KEIYAKUSYA_CD & " AND NOJO_CD = " & wKbn.NOJO_CD

            Return wSql
        End Function
#End Region

#Region "契約情報　コピー"
        ''' <summary>
        ''' 契約情報　登録
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function f_Data_Copy(db As DaDbContext, wNojoCd As CopyRequest) As DaResponseBase
            Dim ret As Boolean = False
            Dim Cmd As New OracleCommand
            Dim wNow As Date = Now

            'ストアドプロシージャの呼び出し
            Cmd.Connection = db.Session.Connection
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "PKG_GJ1012.GJ1012_KEIYAKU_JOHO_CPY"

            '----------------------------------------
            '   情報
            '----------------------------------------
            '期
            Cmd.Parameters.Add("IN_KI", wNojoCd.KI)
            '契約者
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", wNojoCd.KEIYAKUSYA_CD)
            '契約区分　1:家族 2:企業 3:うずら  
            Cmd.Parameters.Add("IN_KEIYAKU_KBN", wNojoCd.KEIYAKU_KBN)


            '契約年月日From  
            If wNojoCd.KEIYAKU_DATE.VALUE_FM Is Nothing OrElse wNojoCd.KEIYAKU_DATE.VALUE_FM.Value = New Date Then
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_FROM", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_FROM", f_DateTrim(wNojoCd.KEIYAKU_DATE.VALUE_FM.Value))
            End If
            '契約年月日To    
            If wNojoCd.KEIYAKU_DATE.VALUE_TO Is Nothing OrElse wNojoCd.KEIYAKU_DATE.VALUE_TO.Value = New Date Then
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", f_DateTrim(wNojoCd.KEIYAKU_DATE.VALUE_TO.Value))
            End If

            '----------------------------------------
            '   共通情報
            '----------------------------------------
            'データ登録日
            Cmd.Parameters.Add("IN_REG_DATE", Now)
            'データ登録ＩＤ
            Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
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

#Region "f_Data_Update 交付実績更新処理"
        ''' <summary>
        ''' 交付実績更新処理
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function f_Data_Update(db As DaDbContext, wNojoCd As SaveRequest) As DaResponseBase
            Dim ret As Boolean = False
            Dim Cmd As New OracleCommand
            Dim wNow As Date = Now

            'ストアドプロシージャの呼び出し
            Cmd.Connection = db.Session.Connection
            Cmd.CommandType = CommandType.StoredProcedure

            Select Case wNojoCd.EDIT_KBN
                Case EnumEditKbn.Edit       '変更入力
                    Cmd.CommandText = "PKG_GJ1012.GJ1012_KEIYAKU_JOHO_UPD"
                Case EnumEditKbn.Add       '新規入力
                    Cmd.CommandText = "PKG_GJ1012.GJ1012_KEIYAKU_JOHO_INS"
            End Select

            '----------------------------------------
            '   申請者基本情報1
            '----------------------------------------
            '期
            Cmd.Parameters.Add("IN_KI", wNojoCd.KI)
            '契約者
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", wNojoCd.KEIYAKUSYA_CD)
            '契約年月日From  
            If wNojoCd.KEIYAKU_DATE.VALUE_FM Is Nothing OrElse wNojoCd.KEIYAKU_DATE.VALUE_FM.Value = New Date Then
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_FROM", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_FROM", f_DateTrim(wNojoCd.KEIYAKU_DATE.VALUE_FM.Value))
            End If
            '契約年月日To    
            If wNojoCd.KEIYAKU_DATE.VALUE_TO Is Nothing OrElse wNojoCd.KEIYAKU_DATE.VALUE_TO.Value = New Date Then
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_KEIYAKU_DATE_TO", f_DateTrim(wNojoCd.KEIYAKU_DATE.VALUE_TO.Value))
            End If

            '農場コード   
            Cmd.Parameters.Add("IN_NOJO_CD", wNojoCd.NOJO_CD)

            '契約区分　1:家族 2:企業 3:うずら  
            Cmd.Parameters.Add("IN_KEIYAKU_KBN", wNojoCd.KEIYAKU_KBN)

            '鶏の種類    
            Cmd.Parameters.Add("IN_TORI_KBN", wNojoCd.TORI_KBN)

            'データフラグ 0:無効 1:有効    DATA_FLG
            Cmd.Parameters.Add("IN_DATA_FLG", 1)

            '契約変更区分 0:新規 1:羽数増加 2:契約変更(家族→企業) 3:契約変更(企業→家族) 4:譲渡(家族→企業)    KEIYAKU_HENKO_KBN
            Cmd.Parameters.Add("IN_KEIYAKU_HENKO_KBN", 0)

            '契約羽数    KEIYAKU_HASU
            Cmd.Parameters.Add("IN_KEIYAKU_HASU", wNojoCd.KEIYAKU_HASU)

            '増羽：増えた分 譲渡：増えた分or減った分    ZOGEN_HASU
            Cmd.Parameters.Add("IN_ZOGEN_HASU", wNojoCd.KEIYAKU_HASU)

            '備考    BIKO
            Cmd.Parameters.Add("IN_BIKO", wNojoCd.BIKO)

            '----------------------------------------
            '   共通情報
            '----------------------------------------

            'データ登録日
            Cmd.Parameters.Add("IN_REG_DATE", Now)
            'データ登録ＩＤ
            Cmd.Parameters.Add("IN_REG_ID", pLOGINUSERID)
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

#Region "f_Data_Deleate 削除処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Data_Deleate
        '説明            :削除処理
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
            wkCmd.CommandText = "PKG_GJ1012.GJ1012_KEIYAKU_JOHO_DEL"

            '引き渡し
            wkCmd.Parameters.Add("IN_SEQ", wNojoCd.SEQNO)

            '戻り
            Dim p_MSGCD As OracleParameter = wkCmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = wkCmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            wkCmd.ExecuteNonQuery()
            Debug.Print(wkCmd.Parameters("OU_MSGCD").Value.ToString())
            If wkCmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Throw New Exception(wkCmd.Parameters("OU_MSGCD").Value.ToString() & ":" & wkCmd.Parameters("OU_MSGNM").Value.ToString())
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
