' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             機能マスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tm_afkinoDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afkino"
        Public Property kinoid As String                        '機能ID
        Public Property hyojinm As String                       '表示名称
        Public Property programid As String                    'プログラムID（共用）
        Public Property hanyokbn As String                     '汎用区分
    End Class
End Namespace
