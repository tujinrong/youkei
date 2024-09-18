' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ8011関数
'
' 作成日　　: 2024.09.18
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8011

    Public Class FrmGJ8011Service

#Region "f_SetForm_Data データ取得SQL処理"
   ''' <summary>
    ''' フォームデータセット
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function f_SetForm_Data(iKbn As Integer?, iMcd As Integer?) As String
        Dim wkSb As New StringBuilder
        wkSb.AppendLine("select")
        wkSb.AppendLine("     T.SYURUI_KBN")
        wkSb.AppendLine("     ,KBN.MEISYO as SYURYUI_KBN_NM")
        wkSb.AppendLine("     ,T.MEISYO")
        wkSb.AppendLine("     ,T.MEISYO_CD")
        wkSb.AppendLine("     ,T.RYAKUSYO")
        wkSb.AppendLine("    , T.REG_DATE ")
        wkSb.AppendLine("    , T.REG_ID ")

        wkSb.AppendLine("  from")
        wkSb.AppendLine("    TM_CODE T ")
        wkSb.AppendLine("    left join TM_CODE  KBN")
        wkSb.AppendLine("      on 1 = 1 ")
        wkSb.AppendLine("      and KBN.SYURUI_KBN = 0 ")
        wkSb.AppendLine("      and KBN.MEISYO_CD = T.SYURUI_KBN ")
        wkSb.AppendLine("where " &
                     " T.SYURUI_KBN       = " & iKbn &
                     " and T.MEISYO_CD = " & iMcd &
                    "")
        Return wkSb.ToString()
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
        wkCmd.CommandText = "PKG_GJ8011.GJ8011_CODE_DEL"

        '引き渡し
        wkCmd.Parameters.Add("IN_CODE_SYURUI_KBN", wNojoCd.SYURUI_KBN) 
        wkCmd.Parameters.Add("IN_CODE_MEISYO_CD", wNojoCd.MEISYO_CD)

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

#Region "f_TM_CODE_Update 交付実績更新処理"
    ''' <summary>
    ''' 交付実績更新処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function f_TM_CODE_Update(db As DaDbContext, wNojoCd As SaveRequest, bNew As Boolean) As DaResponseBase
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False
        Dim lo_REG_DATE As Date = Now
        Dim lo_REG_ID As String = String.Empty

        'ストアドプロシージャの呼び出し
        Cmd.Connection = db.Session.Connection
        Cmd.CommandType = CommandType.StoredProcedure

        If bNew Then 
            Cmd.CommandText = "PKG_GJ8011.GJ8011_CODE_INS"
            lo_REG_DATE = Now
            lo_REG_ID = pLOGINUSERID
        Else
            Cmd.CommandText = "PKG_GJ8011.GJ8011_CODE_UPD"
        End If   
        Cmd.Parameters.Add("IN_SYURUI_KBN", wNojoCd.CODE.SYURUI_KBN)
        Cmd.Parameters.Add("IN_MEISYO_CD", wNojoCd.CODE.MEISYO_CD)
        Cmd.Parameters.Add("IN_MEISYO", wNojoCd.CODE.MEISYO)
        Cmd.Parameters.Add("IN_RYAKUSYO", wNojoCd.CODE.RYAKUSYO)
        Cmd.Parameters.Add("IN_REG_DATE", lo_REG_DATE)
        Cmd.Parameters.Add("IN_REG_ID", lo_REG_ID)
        Cmd.Parameters.Add("IN_UP_DATE", Now)
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

        ret = True

        Return New DaResponseBase
    End Function
#End Region

    End Class

End Namespace
