' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 定数クラス
'
' 作成日　　: 2023.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service
    Public Class DaConst
        'システムユーザー：ユーザーIDとして使用
        Public Shared ReadOnly SYSTEM As String = "system"

        'SQL function page parameters name
        Public Const PAGE_PARAM_LIMIT As String = "limit_in"
        Public Const PAGE_PARAM_OFFSET As String = "offset_in"
        Public Const PAGE_PARAM_ORDER_BY As String = "orderby_in"

        ' downlaod response header: Content_Disposition
        Public Const Content_Disposition As String = "Content-Disposition"

        Public Const SessionID As String = "sessionid"

        'ログ記入文字(エラー時)
        Public Const LOG_ERR_VALUE As String = "ERROR"

        Public Const JapanDateFormat As String = "ggyy年MM月dd日"

        Public Const JapanTimeFormat As String = "ggyy年MM月dd日 HH:mm:ss"
        Public Const JapanTimeFormat2 As String = "ggyy年MM月dd日 HH時mm分ss秒"
        Public Const JapanTimeFormat3 As String = "yyyy/MM/dd HH:mm:ss"

        Public Const DateFormat As String = "yyyy-MM-dd"

        'タイムゾーン
        'Public Shared ReadOnly DateTimeZone TOKYO_TIME_ZONE = DateTimeZoneProviders.Tzdb["Asia/Tokyo"];
        'Public Shared ReadOnly TOKYO_TIME_ZONE_INFO As TimeZoneInfo = System.TimeZoneInfo.FindSystemTimeZoneById("Asia/Tokyo")

        'デフォルトの圧縮ファイル名
        Public Const DEFAULT_ZIP_FILE_NAME As String = "ZipFile"

        ' パスワードに必要な最小文字数
        Public Const PWD_MIN_LENGTH As Integer = 8

        ' selector delimiter
        Public Const SELECTOR_DELIMITER As String = " : "

        'エラー最大件数
        Public Const MAX_ERRORS As Integer = 1000
    End Class
End Namespace
