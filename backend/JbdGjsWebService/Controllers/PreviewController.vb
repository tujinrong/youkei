' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: プレビュー
'
' 作成日　　: 2024.07.17
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.WebService
    <Authorize>
    <ApiController>
    <Route("api/GJS/[controller]")>
    Public Class PreviewController
        Inherits WebControllerBase
        Public Sub New(hostingEnvironment As Microsoft.AspNetCore.Hosting.IWebHostEnvironment, serviceFactory As ServiceFactory)
            MyBase.New(hostingEnvironment, serviceFactory)
        End Sub

        <HttpPost>
        <ResponseCache(Duration:=0, Location:=ResponseCacheLocation.None, NoStore:=True)>
        Public Function Preview(webReq As WebRequestModel) As IActionResult

            '初期処理
            Dim service = _serviceFactory.GetService(webReq.SERVICE_NAME)
            Dim method = service.GetType().GetMethod(webReq.METHOD_NAME)

            ' パラメータを取得
            Dim bizReq = RequestFactory.GetRequestObject(webReq.BIZ_REQUEST, method.GetParameters()(0).ParameterType)

            'Sessionの設定
            Dim r = SetSession(Of DaRequestBase)(bizReq, True)

            'チェックトークン
            Dim uid = CheckToken(r.token, Program.ReportsDirectory.ToString())
            If String.IsNullOrEmpty(uid) Then Return New DaResponseBase("トークンが正しくありません。")

            'サービス実行
            r.sessionid = DaDbLogService.WriteMainLog(r)
            Dim res = method.Invoke(service, New Object() {bizReq})
            Dim ret As CmPreviewResponseBase = DirectCast(res, CmPreviewResponseBase)

            'ログを記録
            r.Service = webReq.SERVICE_NAME
            r.Method = webReq.METHOD_NAME
            Using db = New JbdGjsService.JBD.GJS.Service.DaDbContext(r)
                DaDbLogService.UpdateMainLog(db, EnumLogStatus.正常終了)
                DaDbLogService.WriteTusinLog(db, r, res, String.Empty)
            End Using

            If ret.RETURN_CODE = EnumServiceResult.OK Then
                'Return New FileStreamResult(New MemoryStream(ret.data), ret.contenttype)
                Return Ok(New With {Key .report = ret.sectionDocument})
            End If

            Return ret
        End Function
    End Class
End Namespace
