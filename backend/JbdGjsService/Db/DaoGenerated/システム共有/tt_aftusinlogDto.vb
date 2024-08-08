' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             通信ログテーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_aftusinlogDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_aftusinlog"
        Public Property tusinlogseq As Long                     '通信ログシーケンス
        Public Property sessionseq As Long?                      'セッションシーケンス
        Public Property syoridttmf As Date                  '処理日時（開始）
        Public Property syoridttmt As Date                  '処理日時（終了）
        Public Property msg As String                          'メッセージ
        Public Property request As String                      'リクエスト
        Public Property response As String                     'レスポンス
        Public Property ipadrs As String                       'IPアドレス
        Public Property os As String                           'OS
        Public Property browser As String                      'ブラウザー情報
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
    End Class
End Namespace
