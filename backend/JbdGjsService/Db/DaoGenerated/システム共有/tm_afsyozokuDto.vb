' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             所属グループマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tm_afsyozokuDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afsyozoku"
        Public Property syozokucd As String                     '所属グループコード
        Public Property syozokunm As String                     '所属グループ名
        Public Property kanrisyaflg As Boolean                     '管理者フラグ
        Public Property pnoeditflg As Boolean                      '個人番号操作権限付与フラグ
        Public Property alertviewflg As Boolean                    '警告参照区分
        Public Property stopflg As Boolean                         '使用停止フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
