' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 業務処理のリクエスト処理
'
' 作成日　　: 2024.07.17
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.WebService
    <Authorize>
    <ApiController>
    <Route("api/GJS/[controller]")>
    Public Class WebRequestController
        Inherits WebControllerBase
        Public Sub New(ByVal hostingEnvironment As Microsoft.AspNetCore.Hosting.IWebHostEnvironment, ByVal serviceFactory As ServiceFactory)
            MyBase.New(hostingEnvironment, serviceFactory)
        End Sub

        <HttpPost>
        Public Function WebRequest(ByVal webReq As WebRequestModel) As Object

            '初期処理
            Dim service = _serviceFactory.GetService(webReq.SERVICE_NAME)
            Dim method = service.GetType().GetMethod(webReq.METHOD_NAME)

            ' パラメータを取得
            Dim bizReq = RequestFactory.GetRequestObject(webReq.BIZ_REQUEST, method.GetParameters()(CInt(0)).ParameterType)

            'Sessionの設定
            Dim r = SetSession(Of DaRequestBase)(bizReq, True)

            'チェックトークン
            Dim rst = CheckToken(r.token,Program.ReportsDirectory.ToString())
            Dim rar As String() = rst.Split("|")
            Dim uid = rar(0)
            Dim err = rar(1)
            If String.IsNullOrEmpty(uid) Then Return New DaResponseBase(err)

            'サービス実行
            r.sessionid = DaDbLogService.WriteMainLog(r)
            Dim res = method.Invoke(service, New Object() {bizReq})

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
