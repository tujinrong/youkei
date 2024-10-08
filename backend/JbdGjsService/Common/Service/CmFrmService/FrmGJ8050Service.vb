' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ8050関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8050

    Public Class FrmGJ8050Service

#Region "f_Search_SQLMake ＳＱＬ作成処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :ＳＱＬ作成処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Shared Function f_Search_SQLMake(wKbn As SearchBankRequest) As String
            Dim wkANDorOR As String = String.Empty
            Dim wkWhere As String = String.Empty
            Dim wSql As String = String.Empty
            Dim wkOrderby As String = String.Empty
            Dim pJoken As String = String.Empty

            'WHERE句の AND条件、OR条件の判定
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

            pJoken = ""

            '金融機関
            If wKbn.BANK_CD <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(BNK.BANK_CD  LIKE '" & wKbn.BANK_CD & "%')" & vbCrLf
            End If

            '金融機関名(カナ)
            If wKbn.BANK_KANA <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(BNK.BANK_KANA LIKE '" & wKbn.BANK_KANA & "%')" & vbCrLf
            End If
            '金融機関名(漢字)
            If wKbn.BANK_NAME <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(BNK.BANK_NAME LIKE '" & wKbn.BANK_NAME & "%')" & vbCrLf
            End If

            '==SQL作成====================
            'SQL作成
            wSql = " SELECT"
            wSql = wSql & " BNK.BANK_CD," & vbCrLf          '金融機関コード
            wSql = wSql & " BNK.BANK_KANA," & vbCrLf        '金融機関名（ｶﾅ）
            wSql = wSql & " BNK.BANK_NAME" & vbCrLf         '金融機関名（漢字）
            wSql = wSql & " FROM" & vbCrLf
            wSql = wSql & " TM_BANK BNK" & vbCrLf

            If pJoken = "" Then
            Else
                wSql += " WHERE (" & pJoken & ")" & vbCrLf
            End If

            wSql += "ORDER BY" & vbCrLf

            wkOrderby = "  BNK.BANK_CD "
            Dim wkOrderbyFlg = "  ASC " 
            Select Case True
                Case wKbn.ORDER_BY = 2 Or wKbn.ORDER_BY = -2 
                    wkOrderby = "  BNK.BANK_KANA "
                Case wKbn.ORDER_BY = 3 Or wKbn.ORDER_BY = -3
                    wkOrderby = "  BNK.BANK_NAME"
            End Select

            If wKbn.ORDER_BY < 0 Then
                    wkOrderbyFlg = "  DESC " 
            End If

            Dim wOrder = wkOrderby  &  wkOrderbyFlg
            If wKbn.ORDER_BY = 2 OrElse wKbn.ORDER_BY = -2 OrElse wKbn.ORDER_BY = 3 OrElse wKbn.ORDER_BY = -3 
                wOrder = " UTL_I18N.TRANSLITERATE(case when  "  & wkOrderby  &  " is null then '0' else "  & wkOrderby  &  " end, 'hwkatakana_fwkatakana')  "   & wkOrderbyFlg 
            End If
            wSql += wOrder & vbCrLf

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
        Public Shared Function f_Search_SQLMakePage(psize As Integer, pnum As Integer, sql As String) As String
            '==SQL作成====================
            Dim wSql = ""
            wSql &= "SELECT * "
            wSql &= "  FROM ( "
            wSql &= " SELECT T1.BANK_CD,                              "
            wSql &= "        T1.BANK_KANA,                            "
            wSql &= "        T1.BANK_NAME,                            "
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

#Region "f_Search_SQLMake ＳＱＬ作成処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :ＳＱＬ作成処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Shared Function f_Search_SQLMake2(wKbn As SearchSitenRequest) As String
            Dim wkANDorOR As String = String.Empty
            Dim wkWhere As String = String.Empty
            Dim wSql As String = String.Empty
            Dim wkOrderby As String = String.Empty
            Dim pJoken As String = String.Empty

            'WHERE句の AND条件、OR条件の判定
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

            pJoken = ""

            '金融機関
            If wKbn.BANK_CD <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(BANK_CD  = '" & wKbn.BANK_CD & "')" & vbCrLf
            End If

            '支店・支所
            If wKbn.SITEN_CD <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(STN.SITEN_CD LIKE '" & wKbn.SITEN_CD & "%')" & vbCrLf
            End If

            '支店・支所名(カナ)
            If wKbn.SITEN_KANA <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(STN.SITEN_KANA LIKE '" & wKbn.SITEN_KANA & "%')" & vbCrLf
            End If

            '支店・支所名(漢字)
            If wKbn.SITEN_NAME <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(STN.SITEN_NAME LIKE '" & wKbn.SITEN_NAME & "%')" & vbCrLf
            End If

            '==SQL作成====================
            'SQL作成
            wSql = " SELECT " & vbCrLf
            wSql += "  STN.BANK_CD BANK_CD," & vbCrLf
            wSql += "  STN.SITEN_CD," & vbCrLf
            wSql += "  STN.SITEN_KANA," & vbCrLf
            wSql += "  STN.SITEN_NAME" & vbCrLf
            wSql += " FROM" & vbCrLf
            wSql += "  TM_SITEN STN" & vbCrLf


            If pJoken = "" Then
            Else
                wSql += " WHERE (" & pJoken & ")" & vbCrLf
            End If

            wSql += "ORDER BY" & vbCrLf

            If wKbn.ORDER_BY = -1 Then
                wSql += "  STN.BANK_CD DESC " & vbCrLf
            Else If wKbn.ORDER_BY = 1 Then
                wSql += "  STN.BANK_CD ASC " & vbCrLf
            Else If wKbn.ORDER_BY = -2 Then
                wSql += "  STN.SITEN_CD DESC " & vbCrLf
            Else If wKbn.ORDER_BY = 2 Then
                wSql += "  STN.SITEN_CD ASC " & vbCrLf
            Else If wKbn.ORDER_BY = -3 Then
                wSql += " UTL_I18N.TRANSLITERATE(case when  STN.SITEN_KANA is null then '0' else STN.SITEN_KANA end, 'hwkatakana_fwkatakana')  DESC "     & vbCrLf
            Else If wKbn.ORDER_BY = 3 Then
                wSql += " UTL_I18N.TRANSLITERATE(case when  STN.SITEN_KANA is null then '0' else STN.SITEN_KANA end, 'hwkatakana_fwkatakana')  ASC "     & vbCrLf
            Else If wKbn.ORDER_BY = -4 Then
                wSql += " UTL_I18N.TRANSLITERATE(case when  STN.SITEN_NAME is null then '0' else STN.SITEN_NAME end, 'hwkatakana_fwkatakana')  DESC "     & vbCrLf
            Else If wKbn.ORDER_BY = 4 Then
                wSql += " UTL_I18N.TRANSLITERATE(case when  STN.SITEN_NAME is null then '0' else STN.SITEN_NAME end, 'hwkatakana_fwkatakana')  ASC "     & vbCrLf
            Else
                wSql += "  STN.BANK_CD, STN.SITEN_CD" & vbCrLf
            End If

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
        Public Shared Function f_Search_SQLMakePage2(psize As Integer, pnum As Integer,  sql As String) As String
            '==SQL作成====================
            Dim wSql = ""
            wSql &= "SELECT * "
            wSql &= "  FROM ( "
            wSql &= " SELECT T1.BANK_CD,                              "
            wSql &= "        T1.SITEN_CD,                            "
            wSql &= "        T1.SITEN_KANA,                            "
            wSql &= "        T1.SITEN_NAME,                            "
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

#Region "f_make_SQL 帳票データ出力用ＳＱＬ作成"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :帳票データ出力用ＳＱＬ作成
        '引数            :区分
        '戻り値          :String(SQL文)
        '------------------------------------------------------------------
        '' <summary>
        '' ＳＱＬ文作成
        '' </summary>
        '' <param name="iKbn">
        '' 
        '' </param>
        '' <returns></returns>
        '' <remarks></remarks>
        Public Shared Function f_make_SQL(ByVal wKbn As PreviewBankRequest) As String

            Dim wkANDorOR As String = String.Empty
            Dim wkWhere As String = String.Empty
            Dim wSql As String = String.Empty
            Dim wkOrderby As String = String.Empty
            Dim pJoken As String = String.Empty

            'WHERE句の AND条件、OR条件の判定
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

            pJoken = ""

            '金融機関
            If wKbn.BANK_CD <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(BNK.BANK_CD  LIKE '" & wKbn.BANK_CD & "%')" & vbCrLf
            End If

            '金融機関名(カナ)
            If wKbn.BANK_KANA <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(BNK.BANK_KANA LIKE '" & wKbn.BANK_KANA & "%')" & vbCrLf
            End If
            '金融機関名(漢字)
            If wKbn.BANK_NAME <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(BNK.BANK_NAME LIKE '" & wKbn.BANK_NAME & "%')" & vbCrLf
            End If

            wSql = " SELECT"
            wSql = wSql & " BNK.BANK_CD," & vbCrLf          '金融機関コード
            wSql = wSql & " BNK.BANK_KANA," & vbCrLf        '金融機関名（ｶﾅ）
            wSql = wSql & " BNK.BANK_NAME," & vbCrLf         '金融機関名（漢字）

            wSql = wSql & " CASE WHEN (TO_NUMBER(TO_CHAR(SYSDATE, 'YYYY')) - 2018) < 0 THEN TO_CHAR(SYSDATE,'EEYY','NLS_CALENDAR=''Japanese Imperial''') WHEN (TO_NUMBER(TO_CHAR(SYSDATE, 'YYYY')) - 2018) < 10 THEN  '令和0' || TO_CHAR(TO_NUMBER(TO_CHAR(SYSDATE, 'YYYY')) - 2018) ELSE '令和' || TO_CHAR(TO_NUMBER(TO_CHAR(SYSDATE, 'YYYY')) - 2018) END  || '年' ||  TO_CHAR(SYSDATE, 'MM""月""DD""日""') NOWYMD" & vbCrLf

            wSql = wSql & " FROM" & vbCrLf
            wSql = wSql & " TM_BANK BNK" & vbCrLf

            If pJoken = "" Then
            Else
                wSql += " WHERE (" & pJoken & ")" & vbCrLf
            End If

            wSql += "ORDER BY" & vbCrLf
            wSql += "  BNK.BANK_CD" & vbCrLf

            Return wSql

        End Function
#End Region

#Region "f_make_SQL 帳票データ出力用ＳＱＬ作成"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :帳票データ出力用ＳＱＬ作成
        '引数            :区分
        '戻り値          :String(SQL文)
        '------------------------------------------------------------------
        '' <summary>
        '' ＳＱＬ文作成
        '' </summary>
        '' <param name="iKbn">
        '' 
        '' </param>
        '' <returns></returns>
        '' <remarks></remarks>
        Public Shared Function f_make_SQL2(ByVal wKbn As PreviewSitenRequest) As String

            Dim wkANDorOR As String = String.Empty
            Dim wkWhere As String = String.Empty
            Dim wSql As String = String.Empty
            Dim wkOrderby As String = String.Empty
            Dim pJoken As String = String.Empty

            'WHERE句の AND条件、OR条件の判定
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

            pJoken = ""

            '金融機関
            If wKbn.BANK_CD <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(BNK.BANK_CD  = '" & wKbn.BANK_CD & "')" & vbCrLf
            End If

            '支店・支所
            If wKbn.SITEN_CD <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(STN.SITEN_CD LIKE '" & wKbn.SITEN_CD & "%')" & vbCrLf
            End If

            '支店・支所名(カナ)
            If wKbn.SITEN_KANA <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(STN.SITEN_KANA LIKE '" & wKbn.SITEN_KANA & "%')" & vbCrLf
            End If

            '支店・支所名(漢字)
            If wKbn.SITEN_NAME <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(STN.SITEN_NAME LIKE '" & wKbn.SITEN_NAME & "%')" & vbCrLf
            End If

            wSql = " SELECT " & vbCrLf
            wSql += "  STN.BANK_CD BANK_CD," & vbCrLf
            wSql += "  BNK.BANK_NAME BANK_NAME," & vbCrLf
            wSql += "  STN.SITEN_CD SITEN_CD," & vbCrLf
            wSql += "  STN.SITEN_NAME SITEN_NAME," & vbCrLf
            wSql += "  STN.SITEN_KANA SITEN_KANA," & vbCrLf
            wSql += "  CASE WHEN (TO_NUMBER(TO_CHAR(SYSDATE, 'YYYY')) - 2018) < 0 THEN TO_CHAR(SYSDATE,'EEYY','NLS_CALENDAR=''Japanese Imperial''') WHEN (TO_NUMBER(TO_CHAR(SYSDATE, 'YYYY')) - 2018) < 10 THEN  '令和0' || TO_CHAR(TO_NUMBER(TO_CHAR(SYSDATE, 'YYYY')) - 2018) ELSE '令和' || TO_CHAR(TO_NUMBER(TO_CHAR(SYSDATE, 'YYYY')) - 2018) END  || '年' ||  TO_CHAR(SYSDATE, 'MM""月""DD""日""') NOWYMD" & vbCrLf
            wSql += " FROM" & vbCrLf
            wSql += "  TM_SITEN STN," & vbCrLf

            '金融機関マスタより金融機関コード・名称を取得
            wSql += "  TM_BANK BNK " & vbCrLf

            'WHERE条件句を作成
            wSql += " WHERE" & vbCrLf

            wSql += "       (STN.BANK_CD = BNK.BANK_CD(+)) " & vbCrLf
            wSql += " AND " & vbCrLf

            If pJoken = "" Then
            Else
                wSql += pJoken
            End If

            wSql += "ORDER BY" & vbCrLf
            wSql += "  STN.BANK_CD, STN.SITEN_CD" & vbCrLf

            Return wSql

        End Function
#End Region
    End Class

End Namespace
