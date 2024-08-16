' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: サービスGJ8090関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8090

    Public Module FrmGJ8090Service

#Region "f_Search_SQLMake ＳＱＬ作成処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :ＳＱＬ作成処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Search_SQLMake(wKbn As SearchRequest) As String
            Dim wkANDorOR As String = String.Empty
            Dim wkWhere As String = String.Empty
            Dim wSql As String = String.Empty
            Dim wkOrderby As String = String.Empty

            'ＳＱＬ
            Select Case wKbn.SEARCH_METHOD
                Case EnumAndOr.AndCode
                    '検索方法で[すべてを含む]を選択
                    wkANDorOR = " AND "
                Case EnumAndOr.OrCode
                    '検索方法で[いずれかを含む]を選択
                    wkANDorOR = " OR "
                Case Else
                    wkANDorOR = " AND "
            End Select

            '==オプション条件====================
            ' 以下は省略可能な条件なので指定されていた場合にのみ編集
            ' 但し、検索方法が全てを含むなのかいずれかを含むなのかによりwkANDorORの内容がANDかORに変わる

            '農場番号
            If (wKbn.NOJO_CD.HasValue) = True Then
                wkWhere &= " KNJ.NOJO_CD = " & wKbn.NOJO_CD
            End If

            '農場名
            If wKbn.NOJO_NAME.Trim <> "" Then
                If wkWhere <> "" Then
                    wkWhere = wkWhere & wkANDorOR
                End If
                wkWhere &= " KNJ.NOJO_NAME LIKE '%" & wKbn.NOJO_NAME.Trim & "%'"
            End If

            '条件編集
            If wkWhere <> "" Then
                wkWhere = "  AND (" & wkWhere & ")"
            End If

            wkOrderby = "  KNJ.NOJO_CD"
            Select Case wKbn.ORDER_BY
                Case 1
                    wkOrderby = "  KNJ.NOJO_CD ASC "
                Case -1
                    wkOrderby = "  KNJ.NOJO_CD DESC "
                Case 2
                    wkOrderby = "  KNJ.NOJO_NAME ASC "
                Case -2
                    wkOrderby = "  KNJ.NOJO_NAME DESC "
                Case 2
                    wkOrderby = "  KNJ.ADDR_1 || KNJ.ADDR_2 || KNJ.ADDR_3 || KNJ.ADDR_4  ASC "
                Case -2
                    wkOrderby = "  KNJ.ADDR_1 || KNJ.ADDR_2 || KNJ.ADDR_3 || KNJ.ADDR_4  DESC "
            End Select

            '==SQL作成====================
            'SQL作成
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  KNJ.NOJO_CD,"
            wSql &= "  KNJ.NOJO_NAME,"
            wSql &= "  KNJ.ADDR_1 || KNJ.ADDR_2 || KNJ.ADDR_3 || KNJ.ADDR_4 ADDR "
            wSql &= "FROM"
            wSql &= "  TM_KEIYAKU_NOJO KNJ "
            wSql &= "WHERE KNJ.KI = " & wKbn.KI    '期
            wSql &= "  AND KNJ.KEIYAKUSYA_CD = " & wKbn.KEIYAKUSYA_CD    '契約者
            wSql &= wkWhere & " "
            wSql &= "ORDER BY"
            wSql &= wkOrderby & " "
            Return wSql
        End Function
#End Region

#Region "f_Search_SQLMakePage ページ分割されたデータＳＱＬ作成処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMakePage
        '説明            :ページ分割されたデータＳＱＬ作成処理
        '引数            :なし
        '戻り値          :Sql String
        '------------------------------------------------------------------
        Public Function f_Search_SQLMakePage(psize As Integer, pnum As Integer, sql As String) As String
            '==SQL作成====================
            Dim wSql = ""
            wSql &= "SELECT * "
            wSql &= "  FROM ( "
            wSql &= " SELECT T1.NOJO_CD,                              "
            wSql &= "        T1.NOJO_NAME,                            "
            wSql &= "        T1.ADDR,                                 "
            wSql &= "        COUNT(1) OVER() AS RCNT,               "
            wSql &= "        CEIL(COUNT(1) OVER()/ " & psize & " ) AS PCNT   , ROWNUM AS RM  "
            wSql &= " FROM                                            "
            wSql &= " ( " & sql & " ) "
            wSql &= "  T1  )  "
            wSql &= " WHERE RM <= (" & psize & " * " & pnum & " )    "
            wSql &= "   AND RM >  (" & psize & " * " & pnum & " - " & psize & ") "
            Return wSql
        End Function
#End Region

    End Module

End Namespace
