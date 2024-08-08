' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             共通ドキュメントテーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_afcomdocDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afcomdoc"
        Public Property docseq As Long                          'ドキュメントシーケンス
        Public Property filenm As String                        'ファイル名
        Public Property jigyocd As String                      '事業コード
        Public Property title As String                        'タイトル
        Public Property filetype As Integer                         'ファイルタイプ
        Public Property filesize As Integer                         'ファイルサイズ
        Public Property filedata As Byte()                      'ファイルデータ
        Public Property regsisyo As String                     '登録支所
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
