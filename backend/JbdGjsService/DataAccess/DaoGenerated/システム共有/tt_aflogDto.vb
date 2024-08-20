' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             メインログテーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class tt_aflogDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_aflog"
        Public Property sessionseq As Long                      'セッションシーケンス
        Public Property syoridttmf As Date                  '処理日時（開始）
        Public Property syoridttmt As Date                 '処理日時（終了）
        Public Property milisec As Integer                         '処理時間
        Public Property statuscd As String                      '処理結果コード
        Public Property kinoid As String                       '機能ID
        Public Property service As String                      'サービス名
        Public Property method As String                       'メソッド
        Public Property methodnm As String                     'メソッド名
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
    End Class
End Namespace
