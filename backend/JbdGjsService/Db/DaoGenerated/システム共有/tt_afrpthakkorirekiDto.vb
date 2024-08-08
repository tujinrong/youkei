' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             帳票発行履歴テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_afrpthakkorirekiDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afrpthakkorireki"
        Public Property hakkoseq As Long                        '発行シーケンス
        Public Property hakkoseqeda As Integer                      '発行シーケンス枝番
        Public Property tyusyutuseq As Long                     '抽出シーケンス
        Public Property nendo As String                         '年度
        Public Property taisyocd As String                      '抽出対象CD
        Public Property gyoumucd As String                      '業務コード
        Public Property rptyosikihakkocd As String              '帳票様式発行コード
        Public Property hakkodttm As Date                   '発行日時
        Public Property hakkokbn As String                      '発行区分
        Public Property hakkobasyo As String                   '発行場所
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
