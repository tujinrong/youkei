' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             EUCテーブルマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Db
    Public Class tm_eutableDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_eutable"
        Public Property tablealias As String 'テーブル·別名
        Public Property tablenm As String 'テーブル物理名
        Public Property tablehyojinm As String 'テーブル名称
        Public Property tablekbn As EnumTableKbn 'テーブル区分
        Public Property tableflg As Boolean 'テーブルフラグ
        Public Property orderseq As Integer '並びシーケンス
    End Class
End Namespace
