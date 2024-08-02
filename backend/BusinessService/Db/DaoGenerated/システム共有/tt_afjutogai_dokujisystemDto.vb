' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             住登外者独自施策システム等情報テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tt_afjutogai_dokujisystemDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afjutogai_dokujisystem"
        Public Property atenano As String                       '宛名番号
        Public Property rirekino As Integer                         '履歴番号
        Public Property dokujisystemid As String                '独自施策システム等ID
    End Class
End Namespace
