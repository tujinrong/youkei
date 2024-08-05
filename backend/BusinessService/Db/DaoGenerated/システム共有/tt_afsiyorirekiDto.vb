' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             使用履歴テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_afsiyorirekiDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afsiyorireki"
        Public Property userid As String                        'ユーザーID
        Public Property kinoid As String                        '機能ID
        Public Property syoridttm As Date                   '処理日時
    End Class
End Namespace
