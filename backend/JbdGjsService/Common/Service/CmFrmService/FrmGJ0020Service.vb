' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ0000関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ0020

    Public Class FrmGJ0020Service


#Region "f_Search_SQLHome 検索結果出力用ＳＱＬ作成"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLHome
        '説明            :検索結果出力用ＳＱＬ作成
        '引数            :無し
        '戻り値          :String(SQL文)
        '更新日          :
        '------------------------------------------------------------------
        Public Shared Function f_Search_SQLHome() As String
            '検索
            Dim sSql =  "SELECT  "
            sSql = sSql & "      SUM(MEI.HASU) AS HASU,  "
            sSql = sSql & "      SUM(MEI.TUMITATE_KIN) AS TUMI,  "
            sSql = sSql & "      COUNT(DISTINCT KEI_S.KEIYAKUSYA_CD) AS CNT_SHINKI,  "
            sSql = sSql & "      COUNT(DISTINCT KEI_K.KEIYAKUSYA_CD) AS CNT_KEI  "
            sSql = sSql & " FROM TT_TUMITATE_MEISAI MEI, TT_TUMITATE TUM, TM_SYORI_KI B, "
            sSql = sSql & "      (SELECT KI, KEIYAKUSYA_CD FROM TM_KEIYAKU WHERE KEIYAKU_JYOKYO = 1) KEI_S, "
            sSql = sSql & "      (SELECT KI, KEIYAKUSYA_CD FROM TM_KEIYAKU WHERE KEIYAKU_JYOKYO = 2) KEI_K "
            sSql = sSql & " WHERE TUM.NYUKIN_DATE <= TRUNC(SYSDATE) AND TUM.SYORI_JOKYO_KBN = 3 AND TUM.SEIKYU_HENKAN_KBN BETWEEN 1 AND 3"
            sSql = sSql & "   AND TUM.DATA_FLG = 1 AND TUM.KI = MEI.KI AND TUM.SEIKYU_KAISU = MEI.SEIKYU_KAISU AND TUM.KEIYAKUSYA_CD = MEI.KEIYAKUSYA_CD"
            sSql = sSql & "   AND TUM.TUMITATE_KBN = MEI.TUMITATE_KBN AND MEI.DATA_FLG = 1 AND TUM.KI = B.KI"
            sSql = sSql & "   AND MEI.KEIYAKUSYA_CD = KEI_S.KEIYAKUSYA_CD(+) AND MEI.KI = KEI_S.KI(+)"
            sSql = sSql & "   AND MEI.KEIYAKUSYA_CD = KEI_K.KEIYAKUSYA_CD(+) AND MEI.KI = KEI_K.KI(+)"
            Return sSql
        End Function
#End Region

    End Class

End Namespace
