' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ8100関数
'
' 作成日　　: 2024.10.03
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8100

    Public Class FrmGJ8100Service

#Region "f_Search_SQLMake ＳＱＬ作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Shared Function f_Search_SQLMake(req As SearchRequest) As String
        Dim sSql As String = String.Empty

        'ＳＱＬ
        sSql = ""

        '検索
        sSql = " SELECT " & vbCrLf
        sSql += "  CASE WHEN TAX.TAX_DATE_FROM IS NULL THEN '' ELSE '令和' || TO_CHAR(TO_NUMBER(TO_CHAR(TAX.TAX_DATE_FROM, 'YYYY')) - 2018) || '年' || TO_CHAR(TAX.TAX_DATE_FROM, 'MM""月""DD""日""') END AS TAX_DATE_FROM," & vbCrLf '適用開始日
        sSql += "  CASE WHEN TAX.TAX_DATE_TO IS NULL THEN '' ELSE '令和' || TO_CHAR(TO_NUMBER(TO_CHAR(TAX.TAX_DATE_TO, 'YYYY')) - 2018) || '年' || TO_CHAR(TAX.TAX_DATE_TO, 'MM""月""DD""日""') END AS TAX_DATE_TO," & vbCrLf 　　'適用終了日
        sSql += "  TAX.TAX_RITU TAX_RITU" & vbCrLf                     '消費税率（%）
        sSql += " FROM" & vbCrLf
        sSql += "  TM_TAX TAX" & vbCrLf

        '適用開始日を基準に降順
        sSql += "ORDER BY" & vbCrLf
        sSql += "TAX.TAX_DATE_FROM" & vbCrLf
        sSql += "DESC" & vbCrLf

        Return sSql

    End Function

#End Region

    End Class

End Namespace
