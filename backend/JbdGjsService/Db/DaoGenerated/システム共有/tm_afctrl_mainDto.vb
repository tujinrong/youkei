' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             コントロールメインマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tm_afctrl_mainDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afctrl_main"
        Public Property ctrlmaincd As String                    'コントロールメインコード
        Public Property ctrlsubcd As Integer                        'コントロールサブコード
        Public Property ctrlsubcdnm As String                   'コントロールサブコード名称
        Public Property kananm As String                       'カナ名称
        Public Property shortnm As String                      '略称
        Public Property biko As String                         '備考
    End Class
End Namespace
