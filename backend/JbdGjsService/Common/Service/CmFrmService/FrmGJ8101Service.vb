' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ8101関数
'
' 作成日　　: 2024.10.07
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8101

    Public Class FrmGJ8101Service

#Region "f_Search_SQLMake ＳＱＬ作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :String
    '------------------------------------------------------------------
    Public Shared Function f_Search_SQLMake(req As InitDetailRequest) As String

        'SQL
        Dim sSql = " SELECT " & vbCrLf
            sSql += "  * " & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_TAX" & vbCrLf
            sSql += " WHERE" & vbCrLf
            sSql += "  TAX_DATE_FROM = '" & req.TAX_DATE_FROM & "'" & vbCrLf
        Return sSql

    End Function

#End Region

#Region "f_TM_TAX_Deleate 消費税率マスタデータ削除"
    '----------------------------------------------------------------
    'プロシージャ名  :f_TM_TAX_Deleate
    '説明            :消費税率マスタデータ削除
    '引数            :1.intRow      Integer     選択されている行番号
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Shared Function f_TM_TAX_Deleate(db As DaDbContext, wNojoCd As DeleteRequest) As DaResponseBase
        Dim Cmd As New OracleCommand
        Dim sSql As String = String.Empty
        Dim blnIsTran As Boolean = False

        Dim ret As Boolean = False

        Dim sTAX_DATE_FROM As String = String.Empty

        'ストアドプロシージャの呼び出し
        Cmd.Connection = db.Session.Connection
        Cmd.CommandType = CommandType.StoredProcedure
        '
        Cmd.CommandText = "PKG_GJ8101.GJ8101_TAX_DEL"
        '引き渡し
        Dim paraTAX_DATE_FROM As OracleParameter = Cmd.Parameters.Add("IN_TAX_DATE_FROM", wNojoCd.TAX_DATE_FROM)

        '戻り
        Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
        Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

        Cmd.ExecuteNonQuery()
        Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
        If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
            Return New DaResponseBase(EnumServiceResult.Exception , Cmd.Parameters("OU_MSGNM").Value.ToString())　
        End If

        'データベースへの接続を閉じる
        If Not Cmd Is Nothing Then
            Cmd.Dispose()
        End If

        Return New DaResponseBase()

    End Function
#End Region

#Region "f_Data_Update 委託先更新処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Update
    '説明            :委託先更新処理
    '引数            :なし
    '戻り値          :DaResponseBase
    '------------------------------------------------------------------
    Public Shared Function f_Data_Update(db As DaDbContext, wNojoCd As SaveRequest) As DaResponseBase
        Dim Cmd As New OracleCommand
        Dim wNow As Date = Now

        'ストアドプロシージャの呼び出し
        Cmd.Connection = db.Session.Connection
        Cmd.CommandType = CommandType.StoredProcedure

        Select Case wNojoCd.EDIT_KBN
            Case EnumEditKbn.Add      '新規入力
                Cmd.CommandText = "PKG_GJ8101.GJ8101_TAX_INS"
            Case EnumEditKbn.Edit      '変更入力"
                Cmd.CommandText = "PKG_GJ8101.GJ8101_TAX_UPD"
        End Select

        '引き渡し　
        Dim paraTAX_DATE_FROM As OracleParameter = Cmd.Parameters.Add("IN_TAX_TAX_DATE_FROM", wNojoCd.TAX.TAX_DATE_FROM)     '適用開始日.Value
        Dim paraTAX_DATE_TO As OracleParameter = Cmd.Parameters.Add("IN_TAX_TAX_DATE_TO", wNojoCd.TAX.TAX_DATE_TO)           '適用終了日.Value
        Dim paraTAX_RITU As OracleParameter = Cmd.Parameters.Add("IN_TAX_TAX_RITU", wNojoCd.TAX.TAX_RITU)               　'消費税率（%）
        Dim paraREGDATE As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_REG_DATE", Now)                             　　  'データ登録日
        Dim paraREGID As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_REG_ID", pLOGINUSERID)                        　    'データ登録ＩＤ
        Dim paraUPDATE As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_UP_DATE", Now)                                　   'データ更新日
        Dim paraUPID As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_UP_ID", pLOGINUSERID)                         　　   'データ更新ＩＤ
        Dim paraCOMNM As OracleParameter = Cmd.Parameters.Add("IN_ITAKU_COM_NAME", pPCNAME)                          　　   'コンピュータ名

        '戻り
        Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
        Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

        Cmd.ExecuteNonQuery()
        Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
        If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
            Return New DaResponseBase(EnumServiceResult.Exception , Cmd.Parameters("OU_MSGCD").Value.ToString() & ":" & Cmd.Parameters("OU_MSGNM").Value.ToString())　
        End If

        'データベースへの接続を閉じる
        If Not Cmd Is Nothing Then
            Cmd.Dispose()
        End If

        Return New DaResponseBase
    End Function

#End Region

    End Class

End Namespace
