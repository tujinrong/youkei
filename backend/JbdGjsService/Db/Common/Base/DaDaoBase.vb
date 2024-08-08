' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: Daoベースクラス
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Db
    Public Class DaDaoBase
        'public AiSessionContext Session { get; set; }

        Public Shared _method As String

        'public static AiSelectHelper<T> GetSelectHelper<T>(AiSessionContext session,string tableName) where T : notnull
        '{
        '    DaGlobal.InitDbLib();
        '    return new AiSelectHelper<T>(session, tableName);
        '}
    End Class
End Namespace
