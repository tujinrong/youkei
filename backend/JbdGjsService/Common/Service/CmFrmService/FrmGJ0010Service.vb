' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ0000関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ0010

    Public Class FrmGJ0010Service

#Region "f_Search_SQLMake 検索結果出力用ＳＱＬ作成"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :検索結果出力用ＳＱＬ作成
        '引数            :無し
        '戻り値          :String(SQL文)
        '更新日          :
        '------------------------------------------------------------------
        Public Shared Function f_Search_SQLMake(userId As String) As String
            '検索
            Dim sql = " SELECT " & vbCrLf
            sql += "     U.USER_ID USER_ID, " & vbCrLf
            sql += "     U.USER_NAME USER_NAME, " & vbCrLf
            sql += "     U.PASS PASS, " & vbCrLf
            sql += "     U.PASS_KIGEN_DATE PASS_KIGEN_DATE, " & vbCrLf
            sql += "     U.SIYO_KBN SIYO_KBN, " & vbCrLf
            sql += "     U.TEISI_DATE TEISI_DATE " & vbCrLf
            sql += " FROM" & vbCrLf
            sql += "     TM_USER U " & vbCrLf
            'WHERE条件句を作成
            sql += " WHERE" & vbCrLf
            sql += "    (U.USER_ID = '" & userId.TrimEnd & "')" & vbCrLf
            Return sql
        End Function
#End Region

    End Class

End Namespace
