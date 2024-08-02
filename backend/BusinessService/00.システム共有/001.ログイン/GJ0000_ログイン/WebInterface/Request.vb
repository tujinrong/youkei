' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ログイン
'             リクエストインターフェース
' 作成日　　: 
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Service.GJ0000
    ''' <summary>
    ''' ログイン処理
    ''' </summary>
    Public Class LoginRequest
        Inherits Db.DaRequestBase
        Public Property PASS As String           'パスワード
        Public Property kbn As Enumログイン区分   'ログイン区分
    End Class
End Namespace
