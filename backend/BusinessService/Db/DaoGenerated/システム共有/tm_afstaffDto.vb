' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             事業従事者（担当者）情報マスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tm_afstaffDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afstaff"
        Public Property staffid As String                       '事業従事者ID
        Public Property staffsimei As String                    '事業従事者氏名
        Public Property kanastaffsimei As String                '事業従事者カナ氏名
        Public Property syokusyu As String                      '職種
        Public Property katudokbn As String                     '活動区分
        Public Property syokuinflg As Boolean                      '職員フラグ
        Public Property stopflg As Boolean                         '使用停止フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
