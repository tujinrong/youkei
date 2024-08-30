' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 排他処理
' 　　　　　　レスポンスインターフェースベース
' 作成日　　: 2024.07.26
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class CmLockResponseBase
        Inherits DaResponseBase
        Public Property timestamp As Date    'タイムスタンプ
    End Class
End Namespace
