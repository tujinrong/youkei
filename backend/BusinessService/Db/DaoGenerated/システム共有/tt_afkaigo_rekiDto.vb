' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             【介護保険】被保険者情報履歴テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_afkaigo_rekiDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afkaigo_reki"
        Public Property atenano As String                       '宛名番号
        Public Property kaigohokensyano As String               '介護保険者番号
        Public Property hihokensyano As String                  '被保険者番号
        Public Property sikakurirekino As Integer                   '資格履歴番号
        Public Property hihokensyakbncd As String               '被保険者区分コード
        Public Property sikakusyutokuymd As String              '資格取得日
        Public Property sikakusosituymd As String               '資格喪失日
        Public Property yokaigoninteijokyocd As String          '要介護認定状況コード
        Public Property yokaigojotaikbncd As String            '要介護状態区分コード
        Public Property yokaigoninteiymd As String             '要介護認定日
        Public Property yokaigoyukoymdf As String              '要介護認定有効期間開始日
        Public Property yokaigoyukoymdt As String              '要介護認定有効期間終了日
        Public Property kohijukyusyano As String                '公費受給者番号
        Public Property renkeimotosousauserid As String         '連携元操作者ID
        Public Property renkeimotosousadttm As Date         '連携元操作日時
        Public Property saisinflg As Boolean                       '最新フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
