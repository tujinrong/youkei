' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 文字定数プール
'
' 作成日　　: 2024.07.17
' 作成者　　: AIPlus
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Module DaStrPool
#Region "char const"

        Public Const C_SPACE As Char = " "c
        Public Const C_TAB As Char = ChrW(9)
        Public Const C_DOT As Char = "."c
        Public Const C_SLASH As Char = "/"c
        Public Const C_SLASH_FULL As Char = "／"c
        Public Const C_BACKSLASH As Char = "\"c
        Public Const C_CR As Char = ChrW(13)
        Public Const C_LF As Char = ChrW(10)
        Public Const C_UNDERLINE As Char = "_"c
        Public Const C_COMMA As Char = ","c
        Public Const C_COMMA2 As Char = "、"c
        Public Const C_DELIM_START As Char = "{"c
        Public Const C_DELIM_END As Char = "}"c
        Public Const C_BRACKET_START As Char = "["c
        Public Const C_BRACKET_END As Char = "]"c
        Public Const C_COLON As Char = ":"c
        Public Const C_COLON_FULL As Char = "："c
        Public Const C_AT As Char = "@"c
        Public Const C_DASHED As Char = "-"c
        Public Const C_LEFT_BRACKET_HALF As Char = "("c
        Public Const C_RIGHT_BRACKET_HALF As Char = ")"c
        Public Const C_LEFT_BRACKET_FULL As Char = "（"c
        Public Const C_RIGHT_BRACKET_FULL As Char = "）"c
        Public Const C_GT As Char = ">"c
        Public Const C_LT As Char = "<"c
        Public Const C_GE As Char = "≥"c
        Public Const C_LE As Char = "≤"c
        Public Const C_TILDE_HALF As Char = "~"c
        Public Const C_TILDE_FULL As Char = "～"c
        Public Const C_EQ As Char = "="c
        Public Const C_SQT As Char = "'"c
        Public Const C_SEM As Char = ";"c
        Public Const C_ASTERISK As Char = "*"c

#End Region

#Region "string const"

        Public Const SPACE As String = " "
        Public Const SPACE_FULL As String = "　"
        Public Const TAB As String = vbTab
        Public Const DOT As String = "."
        Public Const DOUBLE_DOT As String = ".."
        Public Const SLASH As String = "/"
        Public Const BACKSLASH As String = "\"
        Public Const CR As String = vbCr
        Public Const LF As String = vbLf
        Public Const CRLF As String = vbCrLf
        Public Const UNDERLINE As String = "_"
        Public Const DASHED As String = "-"
        Public Const COMMA As String = ","
        Public Const DELIM_START As String = "{"
        Public Const DELIM_END As String = "}"
        Public Const BRACKET_START As String = "["
        Public Const BRACKET_END As String = "]"
        Public Const BRACKET2_START As String = "【"
        Public Const BRACKET2_END As String = "】"
        Public Const COLON As String = ":"
        Public Const AT As String = "@"
        Public Const HTML_NBSP As String = "&nbsp;"
        Public Const HTML_AMP As String = "&amp;"
        Public Const HTML_QUOTE As String = "&quot;"
        Public Const HTML_APOS As String = "&apos;"
        Public Const HTML_LT As String = "&lt;"
        Public Const HTML_GT As String = "&gt;"
        Public Const EMPTY_JSON As String = "{}"
        Public Const GE As String = ">="
        Public Const LE As String = "<="
        Public Const EQ As String = "="
        Public Const FILE_ZIP_SUFFIX As String = ".zip"
        Public Const ASTERISK As String = "*"

#End Region
    End Module
End Namespace
