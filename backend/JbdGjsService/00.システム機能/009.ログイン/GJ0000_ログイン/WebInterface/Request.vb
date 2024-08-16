' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ログイン
'            リクエストインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ0000

    ''' <summary>
    ''' ログイン処理
    ''' </summary>
    Public Class LoginRequest
        Inherits Db.DaRequestBase

        ''' <summary>
        ''' パスワード
        ''' </summary>
        Public Property PASS As String = String.Empty

    End Class
End Namespace
