' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ8040関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Imports OracleInternal.Json

Namespace JBD.GJS.Service.GJ8040

    Public Class FrmGJ8040Service

#Region "f_Search_SQLMake ＳＱＬ作成処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :ＳＱＬ作成処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Shared Function f_Search_SQLMake() As String
            Dim sSql As String = String.Empty

            '==SQL作成====================
            'SQL作成
            sSql = " SELECT " & vbCrLf
            sSql += "  USR.USER_ID USER_ID, USR.USER_NAME USER_NAME," & vbCrLf
            sSql += "  CD6.MEISYO SIYO_KBN_NAME," & vbCrLf
            sSql += "  TO_CHAR(USR.TEISI_DATE,'EEYY/MM/DD','NLS_CALENDAR=''Japanese Imperial''') TEISI_DATE," & vbCrLf
            sSql += "  USR.TEISI_RIYU TEISI_RIYU" & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "  TM_USER USR," & vbCrLf
            sSql += "  (SELECT SYURUI_KBN, MEISYO_CD, MEISYO FROM TM_CODE WHERE SYURUI_KBN = 6) CD6" & vbCrLf
            sSql += " WHERE" & vbCrLf
            sSql += "  USR.SIYO_KBN = CD6.MEISYO_CD(+)" & vbCrLf
            sSql += "ORDER BY" & vbCrLf
            sSql += "  USR.USER_ID" & vbCrLf

            Return sSql
        End Function
#End Region

    End Class

End Namespace
