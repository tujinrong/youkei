' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             DB操作ログテーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_aflogdbDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_aflogdb"
        Public Property dblogseq As Long                        'DB操作ログシーケンス
        Public Property sessionseq As Long                     'セッションシーケンス
        Public Property sql As String                          'SQL
        Public Property msg As String                          'メッセージ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
    End Class
End Namespace
