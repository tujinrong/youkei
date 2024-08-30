' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: DTO定義
'             外部連携処理結果履歴テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class tt_afgaibulogDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afgaibulog"
        Public Property gaibulogseq As Long                     '外部連携ログシーケンス
        Public Property sessionseq As Long                      'セッションシーケンス
        Public Property syoridttmf As Date                  '処理日時（開始）
        Public Property syoridttmt As Date                  '処理日時（終了）
        Public Property msg As String                           'メッセージ
        Public Property ipadrs As String                        'IPアドレス（実行）
        Public Property kbn As String                           '連携区分
        Public Property kbn2 As String                          '連携方式
        Public Property kbn3 As String                          '処理区分
        Public Property apidata As String                       'API連携データ
        Public Property filenm As String                        'ファイル名
        Public Property filetype As EnumFileTypeKbn             'ファイルタイプ
        Public Property filesize As Integer                        'ファイルサイズ
        Public Property filedata As Byte()                      'ファイルデータ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
    End Class
End Namespace
