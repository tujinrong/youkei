' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: インスタンス管理
'
' 作成日　　: 2024.07.17
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.WebService
    Public Class RequestFactory
        ''' <summary>
        ''' パラメータを取得
        ''' </summary>
        Public Shared Function GetRequestObject(ByVal req As CmRequestJson, ByVal reqType As Type) As Object
            ' ユーザー情報設定
            Dim paramsStr = req.DATA
            Dim para = JsonConvert.DeserializeObject(paramsStr, reqType)
            If para Is Nothing Then para = New DaRequestBase()
            Return para
        End Function
    End Class
End Namespace
