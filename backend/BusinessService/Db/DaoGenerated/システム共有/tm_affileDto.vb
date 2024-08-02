' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             ファイルマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tm_affileDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_affile"
        Public Property siyokbn As String                       '使用区分
        Public Property filenm As String                        'ファイル名
        Public Property filetype As Integer                         'ファイルタイプ
        Public Property filedata As Byte()                      'ファイルデータ
    End Class
End Namespace
