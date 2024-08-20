' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: システムメイン処理
'
' 作成日　　: 2024.07.17
' 作成者　　: AIPlus
' 変更履歴　:
' *******************************************************************

Public Class Program
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

        app.UseCors()

        app.UseAuthorization()

        app.MapControllers()

        app.Run()
    End Sub

End Class
