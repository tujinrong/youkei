' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             お気に入りテーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tt_afokiniiriDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afokiniiri"
        Public Property userid As String                        'ユーザーID
        Public Property kinoid As String                        '機能ID
        Public Property orderseq As Integer                         '並びシーケンス
    End Class
End Namespace
