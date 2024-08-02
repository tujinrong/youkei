' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             事業従事者（担当者）所属機関
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tm_afstaff_kikanDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afstaff_kikan"
        Public Property staffid As String                       '事業従事者ID
        Public Property kikancd As String                       '医療機関コード（自治体独自）
    End Class
End Namespace
