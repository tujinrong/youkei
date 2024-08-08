' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             事業従事者（担当者）サブマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tm_afstaff_subDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afstaff_sub"
        Public Property staffid As String                       '事業従事者ID
        Public Property jissijigyo As String                    '医療機関・事業従事者（担当者）事業コード
    End Class
End Namespace
