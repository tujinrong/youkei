' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             テーブル項目値変更ログテーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tt_aflogcolumnDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_aflogcolumn"
        Public Property columnlogseq As Long                    '項目値変更ログシーケンス
        Public Property sessionseq As Long                     'セッションシーケンス
        Public Property tablenm As String                       'テーブル名
        Public Property henkokbn As String                      '変更区分
        Public Property keys As String                         'キー
        Public Property itemnm As String                       '項目名
        Public Property valuebefore As String                  '変更前内容
        Public Property valueafter As String                   '更新後内容
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
    End Class
End Namespace
