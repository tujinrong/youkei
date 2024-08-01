' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             会場情報マスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tm_afkaijoDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afkaijo"
        Public Property kaijocd As String                       '会場コード
        Public Property kaijonm As String                       '会場名
        Public Property kanakaijonm As String                   '会場名（カナ）
        Public Property adrs As String                          '住所
        Public Property katagaki As String                      '方書
        Public Property kaijorenrakusaki As String              '会場連絡先
        Public Property gyoseikucd As String                   '行政区
        Public Property stopflg As Boolean                         '使用停止フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
