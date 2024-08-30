' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: モデル定義
'
' 作成日　　: 2024.07.17
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.WebService
    Public Class WebRequestModel
        '[FromBody]
        Public Property SERVICE_NAME As String
        Public Property METHOD_NAME As String
        Public Property BIZ_REQUEST As CmRequestJson

    End Class

    Public Class CmRequestJson
        Public Property DATA As String       'データ
    End Class
End Namespace
