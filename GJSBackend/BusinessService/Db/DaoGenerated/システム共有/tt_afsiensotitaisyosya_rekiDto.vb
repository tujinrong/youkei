' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             【住民基本台帳】支援措置対象者情報履歴テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tt_afsiensotitaisyosya_rekiDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afsiensotitaisyosya_reki"
        Public Property atenano As String                       '宛名番号
        Public Property rirekino As Integer                         '履歴番号
        Public Property siensotiymdf As String                  '支援措置開始年月日
        Public Property siensotiymdt As String                  '支援措置終了年月日
        Public Property siensotikbn As String                   '支援措置区分
        Public Property renkeimotosousauserid As String         '連携元操作者ID
        Public Property renkeimotosousadttm As Date         '連携元操作日時
        Public Property saisinflg As Boolean                       '最新フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
