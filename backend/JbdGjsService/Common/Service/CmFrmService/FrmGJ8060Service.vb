' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ8060関数
'
' 作成日　　: 2024.09.27
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8060

    Public Class FrmGJ8060Service

#Region "f_Search_SQLMake ＳＱＬ作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Shared Function f_Search_SQLMake(wKbn As Integer, req As SearchRequest) As String
        Dim wSql As String = String.Empty
        Dim wkANDorOR As String = String.Empty
        Dim wkWhere As String = String.Empty

        'ＳＱＬ
        wSql = ""

        Select Case req.NYURYOKU_JOHO.SEARCH_METHOD
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

        '都道府県
        If req.NYURYOKU_JOHO.KEN_CD.VALUE_FM.HasValue AndAlso req.NYURYOKU_JOHO.KEN_CD.VALUE_TO.HasValue Then
            wkWhere &= "  ITK.KEN_CD BETWEEN " & req.NYURYOKU_JOHO.KEN_CD.VALUE_FM & " AND " & req.NYURYOKU_JOHO.KEN_CD.VALUE_TO
        End If

        '委託先名
        If req.NYURYOKU_JOHO.ITAKU_NAME.Trim <> "" Then
            If wkWhere <> "" Then
                wkWhere &= wkANDorOR
            End If
            wkWhere &= "  ITK.ITAKU_NAME LIKE '%" & f_SqlEdit(req.NYURYOKU_JOHO.ITAKU_NAME) & "%'"
        End If

        '委託先コード
        If req.NYURYOKU_JOHO.ITAKU_CD.HasValue Then
            If wkWhere <> "" Then
                wkWhere &= wkANDorOR
            End If
            wkWhere &= "  ITK.ITAKU_CD = " & req.NYURYOKU_JOHO.ITAKU_CD
        End If

        'まとめ先
        If req.NYURYOKU_JOHO.MATOMESAKI.HasValue Then
            If wkWhere <> "" Then
                wkWhere &= wkANDorOR
            End If
            wkWhere &= "  ITK.MATOMESAKI = " & req.NYURYOKU_JOHO.MATOMESAKI
        End If

        '条件編集
        If wkWhere <> "" Then
            wkWhere = "  AND (" & wkWhere & ")"
        End If

        '==SQL作成====================
        Select Case wKbn

            Case 0  '検索ボタンクリック時の検索条件
                'SQL作成
                wSql = ""
                wSql &= "SELECT"
                wSql &= "  ITK.ITAKU_CD,"
                wSql &= "  ITK.ITAKU_NAME,"
                wSql &= "  ITK.ADDR_TEL,"
                wSql &= "  CASE WHEN ITK.ADDR_POST IS NULL THEN NULL"
                wSql &= "  ELSE SUBSTR(ITK.ADDR_POST,1,3) || '-' || SUBSTR(ITK.ADDR_POST,4,4) END ADDR_POST,"
                wSql &= "  ITK.ADDR_1 || ITK.ADDR_2 || ITK.ADDR_3 || ITK.ADDR_4 ADDR "
                wSql &= "FROM"
                wSql &= "  TM_JIMUITAKU ITK "
                wSql &= "WHERE ITK.KI = " & req.NYURYOKU_JOHO.KI    '期
                wSql &= wkWhere & " "
                wSql &= "ORDER BY"
                wSql &= "  ITK.ITAKU_CD"

            Case 1  'CSV出力ボタンクリック時の検索条件
                wSql &= "SELECT"
                wSql &= "  ITK.KI AS ""期"","
                wSql &= "  ITK.ITAKU_CD AS ""事務委託先番号"","
                wSql &= "  ITK.KEN_CD AS ""都道府県コード"","
                wSql &= "  M05.MEISYO AS ""都道府県名称"","
                wSql &= "  ITK.ITAKU_NAME AS ""事務委託先名（正式）"","
                wSql &= "  ITK.ITAKU_RYAKU AS ""事務委託先名（略称）"","
                wSql &= "  ITK.DAIHYO_NAME AS ""代表者名"","
                wSql &= "  ITK.TANTO_NAME AS ""担当者名"","
                wSql &= "  ITK.ADDR_POST AS ""郵便番号"","
                wSql &= "  ITK.ADDR_1 AS ""住所１"","
                wSql &= "  ITK.ADDR_2 AS ""住所２"","
                wSql &= "  ITK.ADDR_3 AS ""住所３"","
                wSql &= "  ITK.ADDR_4 AS ""住所４"","
                wSql &= "  ITK.ADDR_TEL AS ""電話番号"","
                wSql &= "  ITK.ADDR_FAX AS ""ＦＡＸ"","
                wSql &= "  ITK.ADDR_E_MAIL AS ""メールアドレス"","
                wSql &= "  ITK.BANK_INJI_KBN AS ""金融機関情報印字有無"","
                wSql &= "  ITK.MATOMESAKI AS ""まとめ先"","
                wSql &= "  ITK.MOSIKOMISYORUI AS ""申込書類"","
                wSql &= "  ITK.SEIKYUSYO AS ""請求書・契約書"","
                wSql &= "  ITK.NYUKINHOHO AS ""入金方法"","
                wSql &= "  ITK.ITAKUKENSU AS ""委託件数"","
                wSql &= "  ITK.LABELHAKKO AS ""ラベル発行"","
                wSql &= "  ITK.JYOGAI_FLG AS ""除外フラグ"","
                wSql &= "  ITK.BIKO AS ""備考"" "
                wSql &= "FROM"
                wSql &= "  TM_JIMUITAKU ITK,"
                wSql &= "  TM_CODE M05 "
                wSql &= "WHERE ITK.KI = " & req.NYURYOKU_JOHO.KI   '期
                wSql &= "  AND 05 = M05.SYURUI_KBN(+)"
                wSql &= "  AND ITK.KEN_CD = M05.MEISYO_CD(+)"
                wSql &= wkWhere & " "
                wSql &= "ORDER BY"
                wSql &= "  ITK.ITAKU_CD"

        End Select

        Return wSql

    End Function

#End Region

    End Class

End Namespace
