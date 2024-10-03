' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ8061関数
'
' 作成日　　: 2024.09.27
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8061

    Public Class FrmGJ8061Service

#Region "f_Search_SQLMake ＳＱＬ作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :String
    '------------------------------------------------------------------
    Public Shared Function f_Search_SQLMake(req As InitDetailRequest) As String

        'SQL
        Dim wSql = "SELECT * FROM TM_JIMUITAKU " & _
                "WHERE KI = " & req.KI & _
                "  AND ITAKU_CD = " & req.ITAKU_CD
        Return wSql

    End Function

#End Region

#Region "f_Data_Deleate 委託先削除処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Deleate
    '説明            :委託先削除処理
    '引数            :なし
    '戻り値          :DaResponseBase
    '------------------------------------------------------------------
    Public Shared Function f_Data_Deleate(db As DaDbContext, wNojoCd As DeleteRequest) As DaResponseBase

        Dim wkCmd As New OracleCommand
        Dim wkSql As String = String.Empty

        'ストアドプロシージャの呼び出し
        wkCmd.Connection = db.Session.Connection
        wkCmd.CommandType = CommandType.StoredProcedure
        '
        wkCmd.CommandText = "PKG_GJ8061.GJ8061_JIMUITAKU_DEL"

        '引き渡し
        'グループコード
        Dim paraKI As OracleParameter = wkCmd.Parameters.Add("IN_KI", wNojoCd.KI)
        Dim paraGROUP_CD As OracleParameter = wkCmd.Parameters.Add("IN_ITAKU_CD", wNojoCd.ITAKU_CD)

        '戻り
        Dim p_MSGCD As OracleParameter = wkCmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
        Dim p_MSGNM As OracleParameter = wkCmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

        wkCmd.ExecuteNonQuery()

        Debug.Print(wkCmd.Parameters("OU_MSGCD").Value.ToString())
        If wkCmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
            If wkCmd.Parameters("OU_MSGCD").Value.ToString() <> "99" Then
                '削除済みは正常終了とみなす
                Return New DaResponseBase(EnumServiceResult.Exception , wkCmd.Parameters("OU_MSGNM").Value.ToString())　
            End If
        End If

        'データベースへの接続を閉じる
        If Not wkCmd Is Nothing Then
            wkCmd.Dispose()
        End If

        Return New DaResponseBase

    End Function
#End Region

    End Class

End Namespace
