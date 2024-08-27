' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: WEB処理のベースクラス
'
' 作成日　　: 2024.07.17
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.WebService
    Public Class WebControllerBase
        Inherits Controller
        ' Core では Server.MapPath が使えないことの対応
        Protected ReadOnly _hostingEnvironment As Microsoft.AspNetCore.Hosting.IWebHostEnvironment
        Protected ReadOnly _serviceFactory As ServiceFactory

        Public Sub New(ByVal hostingEnvironment As Microsoft.AspNetCore.Hosting.IWebHostEnvironment, ByVal serviceFactory As ServiceFactory)
            _hostingEnvironment = hostingEnvironment
            _serviceFactory = serviceFactory
        End Sub

        ''' <summary>
        ''' リクエストSessionを設定
        ''' </summary>
        Protected Function SetSession(Of TReq As {DaRequestBase, New})(ByVal req As Object, ByVal authflg As Boolean) As TReq
            Dim r = New TReq()
            Try
                If req IsNot Nothing Then
                    r = CType(req, TReq)
                        r.ip = GetInfo(nameof(DaRequestBase.ip))
                        r.os = GetInfo(nameof(DaRequestBase.os))
                        r.browser = GetInfo(nameof(DaRequestBase.browser))
                    If authflg Then
                        r.token = GetInfo("Token")
                        r.USER_ID = GetInfo(nameof(DaRequestBase.USER_ID))
                        r.kinoid = GetInfo(NameOf(DaRequestBase.kinoid))
                    End If
                End If

            Catch
            Finally

            End Try

            Return r
        End Function

        ''' <summary>
        ''' フロントエンドヘッダー情報取得
        ''' </summary>
        Private Function GetInfo(ByVal nm As String) As String
            Select Case nm
                Case NameOf(DaRequestBase.ip)
                    Return GetIp()
                Case NameOf(DaRequestBase.os), NameOf(DaRequestBase.browser), NameOf(DaRequestBase.USER_ID), "Token"
                    Return If(Request.Headers(nm).FirstOrDefault(), String.Empty)
                Case NameOf(DaRequestBase.kinoid)
                    Return Request.Headers(nm).FirstOrDefault()
                Case Else
                    Throw New Exception("DaRequestBase name error")
            End Select
        End Function

        ''' <summary>
        ''' クライアントIPを取得する
        ''' </summary>
        Private Function GetIp() As String
            Dim ip = If(Request.Headers("X-Forwarded-For").FirstOrDefault(), String.Empty)
            If String.IsNullOrEmpty(ip) Then
                ip = If(HttpContext.Connection.RemoteIpAddress?.ToString(), String.Empty)
            End If

            If String.IsNullOrEmpty(ip) OrElse ip.Contains("::1") OrElse ip.Contains("::ffff:") Then
                ip = "127.0.0.1"
            End If

            Return ip
        End Function
    End Class
End Namespace
