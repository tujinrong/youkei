' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             帳票発行抽出対象マスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tm_afrpthakkotyusyututaisyoDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afrpthakkotyusyututaisyo"
        Public Property taisyocd As String                      '抽出対象CD
        Public Property rptid As String                         '帳票№
        Public Property yosikiid As String                      '帳票様式
        Public Property taisyonm As String                      '抽出対象名
        Public Property gyomucd As String                       '業務コード
        Public Property noticecycle As String                   '通知サイクル
        Public Property jogaiflg As Boolean                       '再抽出除外フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
