' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             医療機関サブマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tm_afkikan_subDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afkikan_sub"
        Public Property kikancd As String                       '医療機関コード（自治体独自）
        Public Property jissijigyo As String                    '医療機関・事業従事者（担当者）事業コード
    End Class
End Namespace
