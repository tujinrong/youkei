' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             【個人住民税】個人住民税税額控除情報テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tt_afkojinzeikojoDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afkojinzeikojo"
        Public Property atenano As String                       '宛名番号
        Public Property kazeinendo As Integer                       '課税年度
        Public Property kojocd As String                        '税額・税額控除コード
        Public Property tosi_gyoseikucd As String              '指定都市_行政区等コード
        Public Property kojokingaku As Long                     '税額控除金額
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
