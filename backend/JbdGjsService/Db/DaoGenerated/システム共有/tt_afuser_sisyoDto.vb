' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             ユーザー所属部署（支所）テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_afuser_sisyoDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afuser_sisyo"
        Public Property userid As String                        'ユーザーID
        Public Property sisyocd As String                       '部署（支所）コード
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
