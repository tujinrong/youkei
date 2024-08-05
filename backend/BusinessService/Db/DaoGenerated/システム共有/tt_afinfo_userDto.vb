' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             お知らせ確認状態テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_afinfo_userDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afinfo_user"
        Public Property infoseq As Long                         'お知らせシーケンス
        Public Property userid As String                        'ユーザーID
    End Class
End Namespace
