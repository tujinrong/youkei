' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             タスクスケジュールマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tm_aftaskscheduleDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_aftaskschedule"
        Public Property taskid As String                        'タスクID
        Public Property tasknm As String                        'タスク名
        Public Property renkeiid As String                     'HangFire連携ID
        Public Property biko As String                         '説明
        Public Property zenjikkodttmf As Date              '前回の実行日時（開始）
        Public Property zenjikkodttmt As Date              '前回の実行日時（終了）
        Public Property jikaijikkodttmt As Date            '次回実行日時
        Public Property syorikbn As String                      '処理区分
        Public Property gyomukbn As String                      '業務区分
        Public Property modulecd As String                      'モジュールコード
        Public Property hikisu As String                       '引数
        Public Property yukoymdf As String                      '有効年月日（開始）
        Public Property yukotmf As String                       '有効時間（開始）
        Public Property hindokbn As String                      '頻度区分
        Public Property syukustopflg As Boolean                    '祝日停止フラグ
        Public Property yobi As String                         '曜日
        Public Property maitukihiyobikbn As String             '毎月の日・曜日区分
        Public Property maitukituki As String                  '毎月の月
        Public Property maitukihi As String                    '毎月の日
        Public Property maitukisyu As String                   '毎月の週
        Public Property statuscd As String                     '処理結果コード
        Public Property kurikaesikanflg As Boolean                '繰り返し間隔フラグ
        Public Property kurikaesikankbn As String              '繰り返し間隔区分
        Public Property jikantaif As String                    '時間帯開始_時
        Public Property jikantait As String                    '時間帯終了_時
        Public Property jikannaif As String                    '時間内開始_分
        Public Property jikannait As String                    '時間内終了_分
        Public Property stopflg As Boolean                         '使用停止フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
