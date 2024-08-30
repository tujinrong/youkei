' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: DTO定義
'             名称マスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class tm_afmeisyoDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afmeisyo"
        Public Property nmmaincd As String                      '名称メインコード
        Public Property nmsubcd As Integer                          '名称サブコード
        Public Property nmcd As String                          '名称コード
        Public Property nm As String                            '名称
        Public Property kananm As String                       'カナ名称
        Public Property shortnm As String                      '略称
        Public Property biko As String                         '備考
        Public Property hanyokbn1 As String                    '汎用区分1
        Public Property hanyokbn2 As String                    '汎用区分2
        Public Property hanyokbn3 As String                    '汎用区分3
    End Class
End Namespace
