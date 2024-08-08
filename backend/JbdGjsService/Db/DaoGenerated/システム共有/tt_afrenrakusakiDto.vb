' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             連絡先テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_afrenrakusakiDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afrenrakusaki"
        Public Property atenano As String                       '宛名番号
        Public Property jigyocd As String                       '個人連絡先利用事業コード
        Public Property tel As String                          '電話番号
        Public Property keitaitel As String                    '携帯番号
        Public Property emailadrs As String                    'E-mailアドレス
        Public Property emailadrs2 As String                   'E-mailアドレス2
        Public Property syosai As String                       '連絡先詳細
        Public Property regsisyo As String                     '登録支所
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
