' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: サービスGJ1030関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1030

    Public Module FrmGJ1030Service

#Region "***変数定義***"

    Private pblnTextChange As Boolean                   '画面入力内容変更フラグ

    ''' <summary>
    ''' プログラム毎の変数
    ''' </summary>
    ''' <remarks></remarks>
    Private pJump As Boolean = True                     '処理ジャンプ

    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "家畜防疫互助基金契約者一覧表(連絡用)"

#End Region

#Region "f_ComboBox_Set コンボボックスセット処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ComboBox_Set
    '説明            :コンボボックスセット処理
    '引数            :区分
    '戻り値          :InitResponse
    '------------------------------------------------------------------
    Public Function f_ComboBox_Set(ByVal wKbn As String, ki As Integer) As InitResponse
        Dim sSql As String = String.Empty
        Dim sWhere As String = String.Empty
        Dim ret As Boolean = False
        Dim res = New InitResponse()

        If wKbn = "C" Then
            '--------------------
            '契約区分
            '--------------------
            Dim cdt = f_CodeMaster_Data_Select(1, 0)
            'データ結果判定
            If cdt.Rows.Count > 0 Then
                res.KEIYAKU_KBN_CD_NAME_LIST = New List(Of CodeNameModel)
                ' dt をループし、List にデータを追加します。
                For Each row As DataRow In cdt.Rows
                    Dim item As New CodeNameModel
                    item.CODE = Cint(row("MEISYO_CD").ToString())
                    item.NAME = row("MEISYO").ToString()
                    res.KEIYAKU_KBN_CD_NAME_LIST.Add(item)
                Next
            End If

        End If
            
        '--------------------
        '事務委託先
        '--------------------
        sWhere = "KI = " & ki
        Dim jdt = f_JimuItaku_Data_Select(sWhere)
        'データ結果判定
        If jdt.Rows.Count > 0 Then
            res.ITAKU_CD_NAME_LIST = New List(Of CodeNameModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In jdt.Rows
                Dim item As New CodeNameModel
                item.CODE = Cint(row("ITAKU_CD").ToString())
                item.NAME = row("ITAKU_NAME").ToString()
                res.ITAKU_CD_NAME_LIST.Add(item)
            Next
        End If

        '--------------------
        '契約者
        '--------------------
        sWhere = "KI = " & ki
        Dim kdt = f_Keiyaku_Data_Select(ki, True, String.Empty)
        'データ結果判定
        If kdt.Rows.Count > 0 Then
            res.KEIYAKUSYA_CD_NAME_LIST = New List(Of CodeNameModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In kdt.Rows
                Dim item As New CodeNameModel
                item.CODE = Cint(row("KEIYAKUSYA_CD").ToString())
                item.NAME = row("KEIYAKUSYA_NAME").ToString()
                res.KEIYAKUSYA_CD_NAME_LIST.Add(item)
            Next
        End If

        res.KI= ki
        
        Return res
    End Function
#End Region

#Region "帳票レポート出力関連"
#Region "f_Report_Output 帳票レポート出力処理"
        '' <summary>
        ''  帳票レポート出力処理
        '' </summary>
        '' <returns></returns>
        '' <remarks></remarks>
        Private Function f_Report_Output(ByVal req As PreviewRequest) As Boolean

            'Dim wkDSRep As New DataSet

                ''--------------------------------------------------
                ''データ取得
                ''--------------------------------------------------
                'wkDSRep.Tables.Add(con_ReportName)

                'SQL
                Dim wkSql = f_make_SQL(req)

                ''データ取得
                'Using db = New DaDbContext()
                '    f_Select_ODP_New(db, wkDSRep, wkSql)
                'End Using

                'Using wkAdp As New OracleDataAdapter(wkSql, Cnn)
                '    wkAdp.Fill(wkDSRep, wkDSRep.Tables(0).TableName)
                'End Using

                'If wkDSRep.Tables(0).Rows.Count > 0 Then
                '    Dim w As New rptGJ1030
                '    w.sub1(wkDSRep)

 
                'Else
                '    Return False
                'End If

            Return True
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
        Public Function f_make_SQL(ByVal req As PreviewRequest) As String
            Dim ret As Boolean = False
            Dim sSQL As String = vbNullString
            Dim sSQL2 As String = vbNullString
            Dim sSQL3 As String = vbNullString
            'Dim dstDataSanka As DataSet

            '#25 ADD START
            Dim sKaishiNen As String
            Dim sSyuryoNen As String
            '#25 ADD END

                Dim SyoriKI = req.KI

                '#25 ADD START
                '期の開始年と終了年の算出
                sKaishiNen = ((SyoriKI - 6) * 3) + 2015 & "/04/01"
                sSyuryoNen = ((SyoriKI - 6) * 3) + 2015 + 2 & "/03/31"
                '#25 ADD END
                Dim dateTAISYOBI_Ymd = Format(req.TAISYOBI_YMD, "yyyy/MM/dd")

                sSQL = " SELECT " & vbCrLf
                sSQL += "   TO_CHAR(SYSDATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS SAKUSEIBI" & vbCrLf
                '-- 対象期間
                '#25 ADD START
                sSQL += " ,'対象期：第" & SyoriKI & "期（' || TO_CHAR(TO_DATE('" & sKaishiNen & "'), '""""EEYY""年度～""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') || TO_CHAR(TO_DATE('" & sSyuryoNen & "'), '""""EEYY""年度）""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS TAISYO_KI " & vbCrLf
                '#25 ADD END
                '-- 対象日
                sSQL += " ,'対象日：' || TO_CHAR(TO_DATE('" & dateTAISYOBI_Ymd & "'), 'EEYY""年""MM""月""DD""日現在""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS TAISYOBI " & vbCrLf

                '-- 期
                sSQL += " ,KEI.KI AS KI " & vbCrLf
                '-- 契約番号
                sSQL += " ,KEI.KEIYAKUSYA_CD AS KEIYAKUSYA_CD " & vbCrLf
                '-- 契約者名
                sSQL += " ,KEI.KEIYAKUSYA_NAME AS KEIYAKUSYA_NAME " & vbCrLf
                '-- 代表者名
                sSQL += " ,KEI.DAIHYO_NAME AS DAIHYO_NAME " & vbCrLf
                '-- 事務委託先
                sSQL += " ,KEI.JIMUITAKU_CD AS JIMUITAKU_CD " & vbCrLf
                '#003 修正START 
                'sSQL += " ,'(' || JIM.ITAKU_RYAKU || ')' AS ITAKU_RYAKU " & vbCrLf
                sSQL += " , JIM.ITAKU_RYAKU  AS ITAKU_RYAKU " & vbCrLf
                '#003 修正END 



                '-- 契約区分
                sSQL += " ,KEI.KEIYAKU_KBN AS KEIYAKU_KBN " & vbCrLf
                '↓2017/07/12 修正 契約区分
                'sSQL += " ,CD01.RYAKUSYO AS KEIYAKU_KBN_NM " & vbCrLf
                sSQL += " ,CD01.MEISYO AS KEIYAKU_KBN_NM " & vbCrLf
                '↑2017/07/12 修正 契約区分
                '-- 契約状況
                sSQL += " ,KEI.KEIYAKU_JYOKYO AS KEIYAKU_JYOKYO " & vbCrLf
                sSQL += " ,CD02.RYAKUSYO AS KEIYAKU_JYOKYO_NM " & vbCrLf
                '-- SEQNO
                sSQL += " ,KEIJOHO.SEQNO AS SEQNO " & vbCrLf
                '-- 変更状況
                sSQL += " ,KEIJOHO.KEIYAKU_HENKO_KBN " & vbCrLf
                sSQL += " ,CD10.RYAKUSYO AS KEIYAKU_HENKO_KBN_NM  " & vbCrLf
                '-- 契約日
                sSQL += " ,KEI.KEIYAKU_DATE AS KEIYAKU_DATE " & vbCrLf
                sSQL += " ,TO_CHAR(KEI.KEIYAKU_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS KEIYAKU_DATE_W " & vbCrLf
                '-- 中止日
                sSQL += " ,KEI.HAIGYO_DATE AS HAIGYO_DATE " & vbCrLf
                sSQL += " ,TO_CHAR(KEI.HAIGYO_DATE, 'EEYY""年""MM""月""DD""日""', 'NLS_CALENDAR=''JAPANESE IMPERIAL''') AS HAIGYO_DATE_W " & vbCrLf
                '-- 郵便番号
                sSQL += " ,DECODE(KEI.ADDR_POST, NULL, '', ('〒' || SUBSTR(KEI.ADDR_POST,1,3) || '-' || SUBSTR(KEI.ADDR_POST,4,4))) AS ADDR_POST " & vbCrLf
                '-- 住所1-4
                sSQL += " ,KEI.ADDR_1 AS ADDR_1 " & vbCrLf
                sSQL += " ,KEI.ADDR_2 AS ADDR_2 " & vbCrLf
                sSQL += " ,KEI.ADDR_3 AS ADDR_3 " & vbCrLf
                sSQL += " ,KEI.ADDR_4 AS ADDR_4 " & vbCrLf
                '-- 電話1-2
                sSQL += " ,KEI.ADDR_TEL1 AS TEL1 " & vbCrLf
                sSQL += " ,KEI.ADDR_TEL2 AS TEL2 " & vbCrLf
                '-- FAX
                sSQL += " ,KEI.ADDR_FAX AS FAX " & vbCrLf
                '-- E-MAIL
                sSQL += " ,KEI.ADDR_E_MAIL AS E_MAIL " & vbCrLf
                '-- 都道府県
                sSQL += " ,KEI.KEN_CD AS KEN_CD " & vbCrLf
                sSQL += " ,'(' || CD05.RYAKUSYO || ')' AS KEN_NM " & vbCrLf
                '-- 金融機関情報印字有無(1:有 2:無)
                sSQL += " ,JIM.BANK_INJI_KBN AS BANK_INJI_KBN " & vbCrLf
                sSQL += " ,DECODE( JIM.BANK_INJI_KBN, 1, '○', 2, '', NULL) AS BANK_INJI_KBN_NM " & vbCrLf

                'FROM
                sSQL += " FROM TM_KEIYAKU KEI " & vbCrLf
                sSQL += "   ,(SELECT " & vbCrLf
                sSQL += "       SEQNO " & vbCrLf
                sSQL += "      ,KI " & vbCrLf
                sSQL += "      ,KEIYAKUSYA_CD " & vbCrLf
                sSQL += "      ,KEIYAKU_HENKO_KBN " & vbCrLf
                sSQL += "     FROM TT_KEIYAKU_JOHO " & vbCrLf
                '最新(SEQNO)を取得
                sSQL += "        ,(SELECT " & vbCrLf
                sSQL += "            max( SEQNO ) over( partition by KI,KEIYAKUSYA_CD ) AS MAX_SEQNO " & vbCrLf
                sSQL += "          FROM TT_KEIYAKU_JOHO " & vbCrLf
                sSQL += "          WHERE DATA_FLG = 1 " & vbCrLf
                sSQL += "         ) MAX_JOHO " & vbCrLf
                '最新(SEQNO)を取得
                sSQL += "     WHERE SEQNO = MAX_JOHO.MAX_SEQNO " & vbCrLf
                sSQL += "     GROUP BY SEQNO,KI,KEIYAKUSYA_CD,KEIYAKU_HENKO_KBN " & vbCrLf
                sSQL += "    ) KEIJOHO " & vbCrLf
                sSQL += "   ,TM_JIMUITAKU JIM " & vbCrLf
                sSQL += "   ,TM_CODE CD01 " & vbCrLf
                sSQL += "   ,TM_CODE CD02 " & vbCrLf
                sSQL += "   ,TM_CODE CD10 " & vbCrLf
                sSQL += "   ,TM_CODE CD05 " & vbCrLf

                'WHERE
                sSQL += " WHERE " & vbCrLf
                '契約情報
                sSQL += "        KEI.KI = KEIJOHO.KI(+) " & vbCrLf
                sSQL += "    AND KEI.KEIYAKUSYA_CD = KEIJOHO.KEIYAKUSYA_CD(+) " & vbCrLf
                '事務委託先
                sSQL += "    AND KEI.KI = JIM.KI(+) " & vbCrLf
                sSQL += "    AND KEI.JIMUITAKU_CD = JIM.ITAKU_CD(+) " & vbCrLf
                '契約区分
                sSQL += "    AND 1 = CD01.SYURUI_KBN(+) " & vbCrLf
                sSQL += "    AND KEI.KEIYAKU_KBN = CD01.MEISYO_CD(+) " & vbCrLf
                '契約状況
                sSQL += "    AND 2 = CD02.SYURUI_KBN(+) " & vbCrLf
                sSQL += "    AND KEI.KEIYAKU_JYOKYO = CD02.MEISYO_CD(+) " & vbCrLf
                '変更状況
                sSQL += "    AND 10 = CD10.SYURUI_KBN(+) " & vbCrLf
                sSQL += "    AND KEIJOHO.KEIYAKU_HENKO_KBN = CD10.MEISYO_CD(+) " & vbCrLf
                '都道府県
                sSQL += "    AND 5 = CD05.SYURUI_KBN(+) " & vbCrLf
                sSQL += "    AND KEI.KEN_CD = CD05.MEISYO_CD(+) " & vbCrLf


                '==必須条件=======================
                '期
                sSQL += "    AND KEI.KI = " & SyoriKI & vbCrLf
                '対象日(現在)
                'sSQL += "    AND ( KEI.KEIYAKU_DATE <= TO_DATE('" & Format(dateTAISYOBI_Ymd.Value, "yyyy/MM/dd") & "','YYYY/MM/DD')" & vbCrLf
                'sSQL += "       OR KEI.KEIYAKU_DATE IS NULL )" & vbCrLf
                '2021/07/12 JBD9020 新契約日追加 UPD START
                'sSQL += "    AND KEI.KEIYAKU_DATE <= TO_DATE('" & Format(dateTAISYOBI_Ymd.Value, "yyyy/MM/dd") & "','YYYY/MM/DD')" & vbCrLf
                sSQL += "    AND ((KEI.KEIYAKU_JYOKYO <> 3 AND KEI.KEIYAKU_DATE <= TO_DATE('" & dateTAISYOBI_Ymd & "','YYYY/MM/DD'))" & vbCrLf
                sSQL += "     OR  (KEI.KEIYAKU_JYOKYO = 3))" & vbCrLf
                '2021/07/12 JBD9020 新契約日追加 UPD END
                '契約状況
                If req.KEIYAKU_JYOKYO.SHINKI And req.KEIYAKU_JYOKYO.KEIZOKU And req.KEIYAKU_JYOKYO.CHUSHI And req.KEIYAKU_JYOKYO.HAIGYO Then
                    '全チェック
                Else
                    Dim strKeiyakuKbn As String = ""
                    '新規契約者
                    If req.KEIYAKU_JYOKYO.SHINKI Then
                        strKeiyakuKbn = "1"
                    End If
                    '継続契約者
                    If req.KEIYAKU_JYOKYO.KEIZOKU Then
                        If strKeiyakuKbn.Length = 0 Then
                            strKeiyakuKbn = "2"
                        Else
                            strKeiyakuKbn += ",2"
                        End If
                    End If
                    '中止者
                    If req.KEIYAKU_JYOKYO.CHUSHI Then
                        If strKeiyakuKbn.Length = 0 Then
                            strKeiyakuKbn = "3"
                        Else
                            strKeiyakuKbn += ",3"
                        End If
                    End If

                    '廃業者
                    If req.KEIYAKU_JYOKYO.HAIGYO Then
                        If strKeiyakuKbn.Length > 0 Then
                            sSQL += "    AND (KEI.KEIYAKU_JYOKYO IN( " & strKeiyakuKbn & ")" & vbCrLf
                            sSQL += "     OR KEI.HAIGYO_DATE IS NOT NULL)" & vbCrLf
                        Else
                            sSQL += "    AND KEI.HAIGYO_DATE IS NOT NULL" & vbCrLf
                        End If
                    Else
                        If strKeiyakuKbn.Length > 0 Then
                            sSQL += "    AND KEI.KEIYAKU_JYOKYO IN( " & strKeiyakuKbn & ")" & vbCrLf
                        End If
                    End If
                End If



                '==任意条件=======================
                '契約区分FROMTO
                If req.KEIYAKU_KBN_CD.VALUE_FM.HasValue And req.KEIYAKU_KBN_CD.VALUE_TO.HasValue Then
                    sSQL += "    AND KEI.KEIYAKU_KBN BETWEEN " & req.KEIYAKU_KBN_CD.VALUE_FM & " and " & req.KEIYAKU_KBN_CD.VALUE_TO & vbCrLf
                End If

                '事務委託先FROMTO
                If req.ITAKU_CD.VALUE_FM.HasValue And req.ITAKU_CD.VALUE_TO.HasValue  Then
                    sSQL += "    AND KEI.JIMUITAKU_CD BETWEEN " & req.ITAKU_CD.VALUE_FM & " and " & req.ITAKU_CD.VALUE_TO & vbCrLf
                End If

                '契約者FROMTO
                If req.KEIYAKUSYA_CD.VALUE_FM.HasValue And  req.KEIYAKUSYA_CD.VALUE_TO.HasValue  Then
                    sSQL += "    AND KEI.KEIYAKUSYA_CD BETWEEN " & req.KEIYAKUSYA_CD.VALUE_FM & " and " & req.KEIYAKUSYA_CD.VALUE_TO & vbCrLf
                End If

                'ORDER BY
                sSQL += " ORDER BY KEI.KEIYAKUSYA_CD " & vbCrLf
            Return sSQL

        End Function
#End Region

#End Region

    End Module

End Namespace
