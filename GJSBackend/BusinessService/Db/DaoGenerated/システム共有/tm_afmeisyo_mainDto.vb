' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             名称メインマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tm_afmeisyo_mainDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afmeisyo_main"
        Public Property nmmaincd As String                      '名称メインコード
        Public Property nmsubcd As Integer                          '名称サブコード
        Public Property nmsubcdnm As String                     '名称サブコード名称
        Public Property kananm As String                       'カナ名称
        Public Property shortnm As String                      '略称
        Public Property keta As Integer                            '桁数
        Public Property biko As String                         '備考
    End Class
End Namespace
