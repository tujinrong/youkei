' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             【後期高齢者医療】被保険者情報履歴テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_afkokihoken_rekiDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afkokihoken_reki"
        Public Property hihokensyano As String                  '被保険者番号
        Public Property rirekino As Integer                         '履歴番号
        Public Property kojinkbncd As String                    '個人区分コード
        Public Property atenano As String                       '宛名番号
        Public Property hiho_sikakusyutokujiyucd As String      '被保険者資格取得事由コード
        Public Property hiho_sikakusyutokuymd As String         '被保険者資格取得年月日
        Public Property hiho_sikakusositujiyucd As String      '被保険者資格喪失事由コード
        Public Property hiho_sikakusosituymd As String         '被保険者資格喪失年月日
        Public Property hoken_tekiyoymdf As String              '保険者番号適用開始年月日
        Public Property hoken_tekiyoymdt As String             '保険者番号適用終了年月日
        Public Property renkeimotosousauserid As String         '連携元操作者ID
        Public Property renkeimotosousadttm As Date         '連携元操作日時
        Public Property saisinflg As Boolean                       '最新フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
