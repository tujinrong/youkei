' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: サービスGJ2010関数
' 作成日　　: 2024.10.09
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ2010

    Public Class FrmGJ2010Service

#Region "f_Search_SQLMake ＳＱＬ作成処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Search_SQLMake
    '説明            :ＳＱＬ作成処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Shared Function f_Search_SQLMake(iKbn As Integer) As String
        Dim sSql As String = String.Empty
        Dim sWhere As String = String.Empty
        Dim strER As String = String.Empty
        Dim strW1 As String = String.Empty
        Dim strW2 As String = String.Empty

        Select Case iKbn
            Case 0
                '検索
                sSql = " SELECT " & vbCrLf
                sSql += "  TO_CHAR(TAN.TAISYO_DATE_FROM,'YYYY/MM/DD') TAISYO_DATE_FROM," & vbCrLf
                sSql += "  TO_CHAR(TAN.TAISYO_DATE_TO,'YYYY/MM/DD') TAISYO_DATE_TO " & vbCrLf
                sSql += " FROM" & vbCrLf
                sSql += "  TM_TANKA TAN" & vbCrLf
            Case 1
                'チェックリスト
            Case 2
                'チェックリスト2
        End Select


        'WHERE条件句を作成
        sSql += " WHERE 1=1 " & vbCrLf
        '2009/01/27 チェックリスト2対応
        '2008/12/10 チェックリスト対応
        Select Case iKbn
            Case 0
                '検索
            Case 1
                'チェックリスト
            Case 2
                'チェックリスト2

        End Select

        '2009/01/27 JBD368 UPD チェックリスト2対応
        '2008/12/10 チェックリスト対応
        Select Case iKbn
            Case 0
                '検索
                sSql += "GROUP BY" & vbCrLf
                sSql += "  TAN.TAISYO_DATE_FROM," & vbCrLf
                sSql += "  TAN.TAISYO_DATE_TO" & vbCrLf
                sSql += "ORDER BY" & vbCrLf
                sSql += "  TAN.TAISYO_DATE_FROM" & vbCrLf

            Case 1
                'チェックリスト
            Case 2
                'チェックリスト2
        End Select

        Return sSql

    End Function

#End Region

    End Class

End Namespace
