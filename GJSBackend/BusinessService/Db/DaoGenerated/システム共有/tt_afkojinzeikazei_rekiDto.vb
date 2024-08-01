' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             【個人住民税】個人住民税課税情報履歴テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tt_afkojinzeikazei_rekiDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afkojinzeikazei_reki"
        Public Property atenano As String                       '宛名番号
        Public Property kazeinendo As Integer                       '課税年度
        Public Property kazeirirekino As Integer                    '課税情報履歴番号
        Public Property tosi_gyoseikucd As String              '指定都市_行政区等コード
        Public Property kazeikbn As String                      '課税非課税区分
        Public Property renkeimotosousauserid As String         '連携元操作者ID
        Public Property renkeimotosousadttm As Date         '連携元操作日時
        Public Property saisinflg As Boolean                       '最新フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
