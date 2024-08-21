' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ログインのWEB処理
'
' 作成日　　: 2024.07.17
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.WebService
    <ApiController>
    <Route("api/AFCT/[controller]")>
    Public Class LoginController
        Inherits WebControllerBase

        Public Sub New(ByVal hostingEnvironment As Microsoft.AspNetCore.Hosting.IWebHostEnvironment, ByVal serviceFactory As ServiceFactory)
            MyBase.New(hostingEnvironment, serviceFactory)
        End Sub

        <HttpPost>
        Public Function Login(ByVal webReq As WebRequestModel) As Object

            ' サービス
            Dim service = _serviceFactory.GetService(webReq.SERVICE_NAME)
            Dim method = service.GetType().GetMethod(webReq.METHOD_NAME)

            ' パラメータを取得
            Dim bizReq = RequestFactory.GetRequestObject(webReq.BIZ_REQUEST, method.GetParameters()(CInt(0)).ParameterType)

            'Sessionの設定
            Dim r = SetSession(Of DaRequestBase)(bizReq, False)

            'サービス実行
            r.sessionid = DaDbLogService.WriteMainLog(r)
            Dim res = CType(method.Invoke(service, New Object() {bizReq}), JbdGjsService.JBD.GJS.Service.GJ0000.LoginResponse)

            'ログを記録
            r.Service = webReq.SERVICE_NAME
            r.Method = webReq.METHOD_NAME
            Using db = New JbdGjsService.JBD.GJS.Service.DaDbContext(r)
                DaDbLogService.UpdateMainLog(db, EnumLogStatus.正常終了)
                DaDbLogService.WriteTusinLog(db, r, res, String.Empty)
            End Using

            '結果を返す
            Return res
        End Function
    End Class
End Namespace
