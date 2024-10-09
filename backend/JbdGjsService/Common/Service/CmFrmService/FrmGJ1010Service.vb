' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ1010関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1010

    Public Class FrmGJ1010Service

#Region "f_SetForm_Data データ取得SQL"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :ＳＱＬ作成処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Shared Function f_Search_SQLMake(wKbn As SearchRequest) As String
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

            '都道府県FROM
            If (wKbn.KEN_CD.VALUE_FM.HasValue) = True And (wKbn.KEN_CD.VALUE_TO.HasValue) = True Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(KYK.KEN_CD BETWEEN '" & wKbn.KEN_CD.VALUE_FM & "' and ')" & wKbn.KEN_CD.VALUE_TO & "'" & vbCrLf
            End If

            '契約者番号
            If (wKbn.KEIYAKUSYA_CD.HasValue) = True Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(KYK.KEIYAKUSYA_CD = '" & wKbn.KEIYAKUSYA_CD & "')" & vbCrLf
            End If

            '契約区分
            If (wKbn.KEIYAKU_KBN.HasValue) = True Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(KYK.KEIYAKU_KBN = '" & wKbn.KEIYAKU_KBN & "')" & vbCrLf
            End If

            '契約状況
            If (wKbn.KEIYAKU_JYOKYO.HasValue) = True Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(KYK.KEIYAKU_JYOKYO = '" & wKbn.KEIYAKU_JYOKYO & "')" & vbCrLf
            End If

            '契約者名
            If wKbn.KEIYAKUSYA_NAME <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(KYK.KEIYAKUSYA_NAME LIKE '%" & wKbn.KEIYAKUSYA_NAME & "%')" & vbCrLf
            End If

            '契約者名(フリガナ)
            If wKbn.KEIYAKUSYA_KANA <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(KYK.KEIYAKUSYA_KANA LIKE '%" & wKbn.KEIYAKUSYA_KANA & "%')" & vbCrLf
            End If

            '住所
            If wKbn.ADDR <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(KYK.ADDR_1||KYK.ADDR_2||KYK.ADDR_3||KYK.ADDR_4 LIKE '%" & wKbn.ADDR & "%')" & vbCrLf
            End If

            '電話番号
            If wKbn.ADDR_TEL1 <> "" Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(regexp_replace(KYK.ADDR_TEL1,'[^0-9]','') = '" & wKbn.ADDR_TEL1 & "')" & vbCrLf
            End If

            '事務委託先
            If (wKbn.JIMUITAKU_CD.VALUE_FM.HasValue) = True And (wKbn.JIMUITAKU_CD.VALUE_TO.HasValue) = True Then
                If pJoken = "" Then
                Else
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(KYK.JIMUITAKU_CD BETWEEN '" & wKbn.JIMUITAKU_CD.VALUE_FM & "' and ')" & wKbn.JIMUITAKU_CD.VALUE_TO & "'" & vbCrLf
            End If

            '未契約者(契約日=NULL)除く
            If wKbn.NOZOKU_FLG Then
                If pJoken = "" Then
                    pJoken += wkANDorOR & vbCrLf
                End If
                pJoken += "(KYK.KEIYAKU_DATE IS NOT NULL AND KEIYAKU_JYOKYO IN (1,2))" & vbCrLf
            End If

            wkOrderby = "  KYK.KEIYAKUSYA_CD "
            Select Case wKbn.ORDER_BY
                Case -1
                    wkOrderby = "  KYK.KEIYAKUSYA_CD DESC "
                Case 2
                    wkOrderby = " UTL_I18N.TRANSLITERATE(case when  KYK.KEIYAKUSYA_NAME is null then '0' else TO_MULTI_BYTE(KYK.KEIYAKUSYA_NAME) end, 'hwkatakana_fwkatakana') ASC, KYK.KEIYAKUSYA_CD  ASC "
                Case -2
                    wkOrderby = " UTL_I18N.TRANSLITERATE(case when  KYK.KEIYAKUSYA_NAME is null then '0' else TO_MULTI_BYTE(KYK.KEIYAKUSYA_NAME) end, 'hwkatakana_fwkatakana') DESC, KYK.KEIYAKUSYA_CD  ASC "
                Case 3
                    wkOrderby = " UTL_I18N.TRANSLITERATE(case when  KYK.KEIYAKUSYA_KANA is null then '0' else TO_MULTI_BYTE(KYK.KEIYAKUSYA_KANA) end, 'hwkatakana_fwkatakana') ASC, KYK.KEIYAKUSYA_CD  ASC "
                Case -3
                    wkOrderby = " UTL_I18N.TRANSLITERATE(case when  KYK.KEIYAKUSYA_KANA is null then '0' else TO_MULTI_BYTE(KYK.KEIYAKUSYA_KANA) end, 'hwkatakana_fwkatakana') DESC, KYK.KEIYAKUSYA_CD  ASC "
                Case 4
                    wkOrderby = "  KYK.KEIYAKU_KBN  ASC , KYK.KEIYAKUSYA_CD ASC "
                Case -4
                    wkOrderby = "  KYK.KEIYAKU_KBN DESC , KYK.KEIYAKUSYA_CD  ASC "
                Case 5
                    wkOrderby = "  KYK.KEIYAKU_JYOKYO ASC , KYK.KEIYAKUSYA_CD ASC "
                Case -5
                    wkOrderby = "  KYK.KEIYAKU_JYOKYO DESC , KYK.KEIYAKUSYA_CD ASC "
                Case 6
                    wkOrderby = "  UTL_I18N.TRANSLITERATE(case when  KYK.ADDR_TEL1 is null then '0' else TO_MULTI_BYTE(KYK.ADDR_TEL1) end, 'hwkatakana_fwkatakana') ASC  , KYK.KEIYAKUSYA_CD ASC "
                Case -6
                    wkOrderby = "  UTL_I18N.TRANSLITERATE(case when  KYK.ADDR_TEL1 is null then '0' else TO_MULTI_BYTE(KYK.ADDR_TEL1) end, 'hwkatakana_fwkatakana') DESC , KYK.KEIYAKUSYA_CD  ASC "
                Case 7
                    wkOrderby = "  LPAD(KYK.KEN_CD,2) || M05.RYAKUSYO ASC , KYK.KEIYAKUSYA_CD ASC "
                Case -7
                    wkOrderby = "  LPAD(KYK.KEN_CD,2) || M05.RYAKUSYO DESC , KYK.KEIYAKUSYA_CD ASC "
                Case 8
                    wkOrderby = " UTL_I18N.TRANSLITERATE(case when  ITK.ITAKU_RYAKU is null then '0' else TO_MULTI_BYTE(ITK.ITAKU_RYAKU) end, 'hwkatakana_fwkatakana') ASC, KYK.KEIYAKUSYA_CD  ASC "
                Case -8
                    wkOrderby = " UTL_I18N.TRANSLITERATE(case when  ITK.ITAKU_RYAKU is null then '0' else TO_MULTI_BYTE(ITK.ITAKU_RYAKU) end, 'hwkatakana_fwkatakana')  DESC,  KYK.KEIYAKUSYA_CD ASC "
            End Select

            '==SQL作成====================
            'SQL作成
            wSql &= "SELECT"
            wSql &= "  KYK.KEIYAKUSYA_CD,"
            wSql &= "  KYK.KEIYAKUSYA_NAME,"
            wSql &= "  KYK.KEIYAKUSYA_KANA,"
            wSql &= "  KYK.KEIYAKU_KBN,"
            wSql &= "  M01.MEISYO KEIYAKU_KBN_NM,"
            wSql &= "  KYK.KEIYAKU_JYOKYO,"
            wSql &= "  M02.RYAKUSYO KEIYAKU_JYOKYO_NM,"
            wSql &= "  KYK.ADDR_TEL1,"
            wSql &= "  KYK.KEN_CD,"
            wSql &= "  LPAD(KYK.KEN_CD,2) || M05.RYAKUSYO KEN_NM,"
            wSql &= "  KYK.JIMUITAKU_CD,"
            wSql &= "  ITK.ITAKU_RYAKU ITAKU_RYAKU, "
            wSql &= "  KYK.NYURYOKU_JYOKYO NYURYOKU_JYOKYO "
            wSql &= "FROM"
            wSql &= "  TM_KEIYAKU KYK,"
            wSql &= "  TM_CODE M01,"
            wSql &= "  TM_CODE M02,"
            wSql &= "  TM_CODE M05,"
            wSql &= "  TM_JIMUITAKU ITK "
            wSql &= "WHERE KYK.KI = " & wKbn.KI
            wSql &= "  AND 01 = M01.SYURUI_KBN(+)"
            wSql &= "  AND KYK.KEIYAKU_KBN = M01.MEISYO_CD(+)"
            wSql &= "  AND 02 = M02.SYURUI_KBN(+)"
            wSql &= "  AND KYK.KEIYAKU_JYOKYO = M02.MEISYO_CD(+)"
            wSql &= "  AND 05 = M05.SYURUI_KBN(+)"
            wSql &= "  AND KYK.KEN_CD = M05.MEISYO_CD(+)"
            wSql &= "  AND KYK.KI = ITK.KI(+)"
            wSql &= "  AND KYK.JIMUITAKU_CD = ITK.ITAKU_CD(+)"
            wSql &= pJoken & " "
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
        Public Shared Function f_Search_SQLMakePage(psize As Integer, pnum As Integer, sql As String) As String
            '==SQL作成====================
            Dim wSql = ""
            wSql &= "SELECT * "
            wSql &= "  FROM ( "
            wSql &= " SELECT T1.KEIYAKUSYA_CD,                              "
            wSql &= "        T1.KEIYAKUSYA_NAME,                            "
            wSql &= "        T1.KEIYAKUSYA_KANA,                            "
            wSql &= "        T1.KEIYAKU_KBN,                            "
            wSql &= "        T1.KEIYAKU_KBN_NM,                            "
            wSql &= "        T1.KEIYAKU_JYOKYO,                            "
            wSql &= "        T1.KEIYAKU_JYOKYO_NM,                            "
            wSql &= "        T1.ADDR_TEL1,                            "
            wSql &= "        T1.KEN_CD,                            "
            wSql &= "        T1.KEN_NM,                            "
            wSql &= "        T1.JIMUITAKU_CD,                            "
            wSql &= "        T1.ITAKU_RYAKU,                            "
            wSql &= "        T1.NYURYOKU_JYOKYO,                            "
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
    End Class

End Namespace
