' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             【国民健康保険】国保資格情報履歴テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_afkokuho_rekiDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afkokuho_reki"
        Public Property atenano As String                       '宛名番号
        Public Property hihokensyarirekino As Integer               '被保険者履歴番号
        Public Property sikutyosonhokenjano As String           '市区町村保険者番号
        Public Property hokenjanm As String                    '保険者名称
        Public Property kokuho_kigono As String                 '国保記号番号
        Public Property kokuho_edano As String                  '枝番
        Public Property kokuho_sikakukbn As String              '国保資格区分
        Public Property kokuho_sikakusyutokuymd As String       '国保資格取得年月日
        Public Property kokuho_sikakusyutokujiyu As String      '国保資格取得事由
        Public Property kokuho_sikakusosituymd As String       '国保資格喪失年月日
        Public Property kokuho_sikakusositujiyu As String      '国保資格喪失事由
        Public Property kokuho_tekiyoymdf As String             '国保適用開始年月日
        Public Property kokuho_tekiyoymdt As String            '国保適用終了年月日
        Public Property syokbn As String                        '証区分
        Public Property yukokigenymd As String                  '有効期限
        Public Property marugakumaruenkbn As String            'マル学マル遠区分
        Public Property renkeimotosousauserid As String         '連携元操作者ID
        Public Property renkeimotosousadttm As Date         '連携元操作日時
        Public Property saisinflg As Boolean                       '最新フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
