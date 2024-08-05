' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             メッセージコントロールマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tm_afmsgctrlDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afmsgctrl"
        Public Property ctrlmsgid As String                     'コントロールメッセージID
        Public Property ctrlmsgnm As String                     'コントロールメッセージ名
        Public Property msgkbn As EnumMsgCtrlKbn                'メッセージ区分
        Public Property errormsgid As String                    'エラーメッセージID
        Public Property alertmsgid As String                    'アラートメッセージID
        Public Property biko As String                          '備考
    End Class
End Namespace
