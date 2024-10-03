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

    End Class

End Namespace
