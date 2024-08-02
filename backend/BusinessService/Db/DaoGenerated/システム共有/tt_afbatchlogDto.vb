' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             バッチログテーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tt_afbatchlogDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afbatchlog"
        Public Property batchlogseq As Long                     'バッチログシーケンス
        Public Property sessionseq As Long                      'セッションシーケンス
        Public Property syoridttmf As Date                  '処理日時（開始）
        Public Property syoridttmt As Date                  '処理日時（終了）
        Public Property msg As String                          'メッセージ
        Public Property pram As String                         'パラメータ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
    End Class
End Namespace
