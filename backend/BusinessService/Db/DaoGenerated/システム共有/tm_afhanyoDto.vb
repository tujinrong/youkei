' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             汎用マスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tm_afhanyoDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afhanyo"
        Public Property hanyomaincd As String                   '汎用メインコード
        Public Property hanyosubcd As Integer                       '汎用サブコード
        Public Property hanyocd As String                       '汎用コード
        Public Property nm As String                            '名称
        Public Property kananm As String                       'カナ名称
        Public Property shortnm As String                      '略称
        Public Property biko As String                         '備考
        Public Property hanyokbn1 As String                    '汎用区分1
        Public Property hanyokbn2 As String                    '汎用区分2
        Public Property hanyokbn3 As String                    '汎用区分3
        Public Property stopflg As Boolean                         '使用停止フラグ
        Public Property orderseq As Integer                        '並びシーケンス
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
