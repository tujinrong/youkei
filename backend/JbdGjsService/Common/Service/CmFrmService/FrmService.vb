' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービス共通関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service

    Public Class FrmService
        Public Const strGjs As String = "gjs"

#Region "f_Select_ODP データSelect"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Select_ODP
        '説明            :データSelect
        '引数            :1.db DaDbContext  
        '*                2.sql    SQL
        '戻り値          :データセット
        '------------------------------------------------------------------
        Public Shared Function f_Select_ODP(db As DaDbContext, sql As String) As DataSet
            Dim dt As DataSet = New DataSet()
            Dim daDataAdapter As OracleDataAdapter
            daDataAdapter = New OracleDataAdapter(sql, db.Session.Connection)
            daDataAdapter.Fill(dt)
            daDataAdapter.Dispose()
            Return dt
        End Function

        Public Shared Function f_Select_ODP(db As DaDbContext, sql As String, rn As String) As DataSet
            Dim dt As DataSet = New DataSet()
            dt.Tables.Add(rn)
            Dim daDataAdapter As OracleDataAdapter
            daDataAdapter = New OracleDataAdapter(sql, db.Session.Connection)
            daDataAdapter.Fill(dt, dt.Tables(0).TableName)
            daDataAdapter.Dispose()
            Return dt
        End Function
#End Region

#Region "CheckToken チェックトークン"
        '------------------------------------------------------------------
        'プロシージャ名  :チェックトークン
        '説明       :
        'ﾊﾟﾗﾒｰﾀ     :① token       i,  String  
        '           :② uid         o,  String  
        '------------------------------------------------------------------
        Public Shared Function CheckToken(token As String, dir As String) As String
            'トークンの取得
            Dim ret = CmTokenService.GetTokenUDGjs(token, strGjs, strGjs)
            Dim uids = ret.Split("|")
            Dim uid = uids(0)
            pLOGINUSERID = uid
            pPCNAME = System.Net.Dns.GetHostName
	        myREPORT_PDF_PATH = dir

            ' 比較する
            If String.IsNullOrEmpty(uid) Then
                Return "|トークンが正しくありません。"
            End If

            Dim time = uids(1)
            Dim format As String = "yyyyMMddHHmmss"
            Dim dateValue As DateTime
            dateValue = DateTime.ParseExact(time, format, CultureInfo.InvariantCulture)
            '24時間を追加
            dateValue = dateValue.AddHours(24)
            '現在時刻を取得する
            Dim currentTime As DateTime = DateTime.Now
            ' 比较
            If dateValue > currentTime Then
                Return uid & "|"
            Else
                Return "|長時間未操作のため、再びログインしてください。"
            End If
        End Function

        Public Shared Function CheckToken(token As String) As String
            'トークンの取得
            Dim ret = CmTokenService.GetTokenUDGjs(token, strGjs, strGjs)
            Dim uids = ret.Split("|")
            Dim uid = uids(0)
            pLOGINUSERID = uid
            pPCNAME = System.Net.Dns.GetHostName

            ' 比較する
            If String.IsNullOrEmpty(uid) Then
                Return "|トークンが正しくありません。"
            End If

            Dim time = uids(1)
            Dim format As String = "yyyyMMddHHmmss"
            Dim dateValue As DateTime
            dateValue = DateTime.ParseExact(time, format, CultureInfo.InvariantCulture)
            '24時間を追加
            dateValue = dateValue.AddHours(24)
            '現在時刻を取得する
            Dim currentTime As DateTime = DateTime.Now
            ' 比较
            If dateValue > currentTime Then
                Return uid & "|"
            Else
                Return "|長時間未操作のため、再びログインしてください。"
            End If
        End Function
#End Region

#Region "f_Search_SQLMakePage ページ分割されたデータＳＱＬ作成処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMakePage
        '説明            :ページ分割されたデータＳＱＬ作成処理
        '引数            :なし
        '戻り値          :Sql String
        '------------------------------------------------------------------
        Public Shared Function f_Search_SQLMakePage(psize As Integer, pnum As Integer, sql1 As String, sql2 As String) As String
            '==SQL作成====================
            Dim wSql = ""
            wSql &= "SELECT * "
            wSql &= "  FROM ( "
            wSql &= " SELECT " & sql1 & "                              "
            wSql &= "        COUNT(1) OVER() AS RCNT,               "
            wSql &= "        CEIL(COUNT(1) OVER()/ " & psize & " ) AS PCNT   , ROWNUM AS RM  "
            wSql &= " FROM                                            "
            wSql &= " ( " & sql2 & " ) "
            wSql &= "  T1  )  "
            wSql &= " WHERE RM <= (" & psize & " * " & pnum & " )    "
            wSql &= "   AND RM >  (" & psize & " * " & pnum & " - " & psize & ") "
            Return wSql
        End Function
#End Region

    End Class

End Namespace
