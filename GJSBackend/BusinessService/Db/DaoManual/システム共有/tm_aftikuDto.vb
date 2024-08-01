' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             地区情報マスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tm_aftikuDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_aftiku"
        Public Property tikukbn As Enum地区区分                 '地区区分
        Public Property tikucd As String                        '地区コード
        Public Property tikunm As String                        '地区名
        Public Property kanatikunm As String                    '地区名（カナ）
        Public Property stopflg As Boolean                         '使用停止フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
