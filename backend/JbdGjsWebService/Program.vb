' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: システムメイン処理
'
' 作成日　　: 2024.07.17
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Imports GrapeCity.ActiveReports.Aspnetcore.Viewer
Imports GrapeCity.ActiveReports.Web.Viewer
Imports JbdGjsReport

Public Class Program

    Private Shared ReadOnly CurrentDir As String = If(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), String.Empty)
    Public Shared ReadOnly ReportsDirectory As DirectoryInfo = New DirectoryInfo(Path.Combine(CurrentDir, "Reports"))

    Public Shared Sub Main(args As String())
        CultureInfo.DefaultThreadCurrentCulture = New CultureInfo("ja-JP")
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.DefaultThreadCurrentCulture
        'LinuxでSystem.Drawing.Commonを通常に使用するために必要な設定
        AppContext.SetSwitch("System.Drawing.EnableUnixSupport", True)
        Dim builder = WebApplication.CreateBuilder(args)
        MvcServiceCollectionExtensions.AddControllers(builder.Services).AddJsonOptions(Sub(options) options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper)
        Dim configuration = builder.Configuration
        StartFactory.Start(configuration)

        'System Start Up log
        Using db = New JbdGjsService.JBD.GJS.Service.DaDbContext()
            db.Session.SessionData(DaConst.SessionID) = -1L
            db.Session.UserID = DaConst.SYSTEM
            DaDbLogService.WriteDbMessage(db, "System Start Up")
        End Using

        builder.Services.AddControllers(Sub(options) options.Filters.Add(GetType(JBD.GJS.WebService.WebApiExceptionFilterAttribute)))
        Dim maxRequestBodySize = configuration.GetValue(Of Long)("MaxRequestBodySize")
        If maxRequestBodySize > 0L Then
            builder.Services.Configure(Of KestrelServerOptions)(Sub(options) options.Limits.MaxRequestBodySize = maxRequestBodySize) ' if don't set default value is: 30 MB
        End If

        ' Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer()

        'キャッシュを使用
        builder.Services.AddMemoryCache()

        'CORS
        builder.Services.AddCors(Sub(options)
                                     options.AddDefaultPolicy(Sub(policy)
                                                                  If builder.Environment.IsDevelopment() Then
                                                                      policy.AllowAnyOrigin()
                                                                      policy.AllowAnyHeader()
                                                                  End If
                                                              End Sub)
                                 End Sub)

        'Business Service
        builder.Services.ConfigureVbBussinessServiceGen()
        Dim app = builder.Build()
        VbBussinessConfig.Configure(app.Services)

        'app.UseCors(Sub(cors)
        '                cors.SetIsOriginAllowed(Function(origin) Equals(New Uri(origin).Host, "61.213.76.155")).AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithExposedHeaders("Content-Disposition")
        '            End Sub)
        app.UseCors(Sub(cors)
                      ' 允许的 IP 地址列表
                      Dim allowedIPs As String() = {"61.213.76.155", "localhost"}

                      ' 修改 SetIsOriginAllowed 方法来支持多个 IP 地址
                      cors.SetIsOriginAllowed(Function(origin)
                                                  Dim host As String = New Uri(origin).Host
                                                  Return allowedIPs.Contains(host)
                                              End Function).
                    AllowAnyMethod().
                    AllowAnyHeader().
                    AllowCredentials().
                    WithExposedHeaders("Content-Disposition")
                                End Sub)
        'app.UseCors()
        app.UseReportViewer(Sub(settings)
                                settings.UseReportProvider(New ReportProvider)
                            End Sub)
        app.UseAuthorization()

        app.MapControllers()

        app.Run()
    End Sub

End Class
Public Class ReportProvider
    Implements IReportProvider
    Public Function GetReport(reportId As String) As Stream Implements IReportProvider.GetReport
        Dim rar As String() = reportId.Split("|")
        Dim svc = rar(0)
        Dim param = rar(1)

        Select Case svc
            Case "GJ1030"  ' "家畜防疫互助基金契約者一覧表(連絡用)"
                Dim w As New rptGJ1030
                Dim ms = w.report(param)
                Return ms
        End Select
        Return New MemoryStream
    End Function

    Public Function GetReportDescriptor(reportId As String) As ReportDescriptor Implements IReportProvider.GetReportDescriptor

        Return New ReportDescriptor(ReportType.Rdf)

    End Function

End Class