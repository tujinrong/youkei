' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             地区情報サブマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tm_aftiku_subDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_aftiku_sub"
        Public Property tikukbn As String                       '地区区分
        Public Property tikucd As String                        '地区コード
        Public Property staffid As String                       '地区担当者
    End Class
End Namespace
