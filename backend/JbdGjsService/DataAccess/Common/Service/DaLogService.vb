' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ログ処理
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service
    Public Class DaLogService
        Public Enum Level
            [ERROR]
            WARN
            DEBUG
            INFO
        End Enum

        'private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()!.DeclaringType);

        'public static void WriteMessage(string method, string msg)
        '{
        '    _logger.Info($"{method} {msg}");
        '}

        'public static void WriteException(string method, Exception ex)
        '{
        '    _logger.Error($"{method} {ex.Message} {ex.StackTrace}");
        '}

        Public Shared Sub WriteMessage(method As String, msg As String)
            'DaLogService._logger.Info($"{method} {msg}")
        End Sub

        Public Shared Sub WriteException(method As String, ex As Exception)
            'DaLogService._logger.Error($"{method} {ex.Message} {ex.StackTrace}")
        End Sub

    End Class
End Namespace
