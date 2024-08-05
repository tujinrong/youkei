' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             メモテーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_afmemoDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afmemo"
        Public Property atenano As String                       '宛名番号
        Public Property memoseq As Integer                          'メモシーケンス
        Public Property jigyokbn As String                      'メモ事業コード
        Public Property juyodo As String                        '重要度
        Public Property title As String                        '件名（タイトル）
        Public Property memo As String                          'メモ（フリーテキスト）
        Public Property kigenymd As String                     '期限日
        Public Property regsisyo As String                     '登録支所
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
