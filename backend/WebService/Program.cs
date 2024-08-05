// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: システムメイン処理
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using System.Globalization;
using JBD.GJS.WebService;
using JBD.GJS.WebService.Config;
using Hangfire;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using WebService.Common.Base.Response;
using WebService.Config;
using BusinessService.JBD.GJS.Db;


CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ja-JP");
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.DefaultThreadCurrentCulture;
//LinuxでSystem.Drawing.Commonを通常に使用するために必要な設定
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
    StartFactory.Start(configuration);

//System Start Up log
using (var db = new DaDbContext())
{
    db.Session.SessionData[BusinessService.JBD.GJS.Db.DaConst.SessionID] = -1L;
    db.Session.UserID = BusinessService.JBD.GJS.Db.DaConst.SYSTEM;
    DaDbLogService.WriteDbMessage
        (db, "System Start Up");
}

// Add services to the container.

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("UserAuthorization", policy => policy.Requirements.Add(new TokenPolicyRequirement(UserRole.User)));
//    options.AddPolicy("EveryoneAuthorization", policy => policy.Requirements.Add(new TokenPolicyRequirement(UserRole.Everyone)));
//});

builder.Services.AddControllers(options => { options.Filters.Add(typeof(WebApiExceptionFilterAttribute)); });

var maxRequestBodySize = configuration.GetValue<long>("MaxRequestBodySize");
if (maxRequestBodySize > 0L)
{
    builder.Services.Configure<KestrelServerOptions>(options =>
    {
        options.Limits.MaxRequestBodySize = maxRequestBodySize; // if don't set default value is: 30 MB
    });
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//キャッシュを使用
builder.Services.AddMemoryCache();
//Swagger
builder.Services.ConfigureSwaggerGen();
//CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            if (builder.Environment.IsDevelopment())
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
            }

            // Download Header need open
            policy.WithExposedHeaders(BusinessService.JBD.GJS.Db.DaConst.Content_Disposition,
                nameof(CmDownloadResponseBase.returncode),
                nameof(CmDownloadResponseBase.message));
        });
});

var hangfireAllowedMachines = configuration.GetSection("HangfireAllowedMachines").Get<string[]>()?.ToHashSet(StringComparer.OrdinalIgnoreCase);

if (hangfireAllowedMachines == null || hangfireAllowedMachines.Contains(Environment.MachineName))
{
    //Hangfire 監視サービス
    //builder.Services.ConfigureHangfireGen(configuration);

    //バッチ処理登録サービス
    //builder.Services.ConfigureBatchServiceGen();
}

//Business Service
builder.Services.ConfigureBussinessServiceGen();
builder.Services.ConfigureVbBussinessServiceGen();

var app = builder.Build();

BussinessConfig.Configure(app.Services);
VbBussinessConfig.Configure(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//DaJobService.Start();

app.UseCors();

if (hangfireAllowedMachines == null || hangfireAllowedMachines.Contains(Environment.MachineName))
{
    //Hangfireダッシュボードをオンにする
    app.UseHangfireDashboard("/hangfire", new DashboardOptions
    {
        AppPath = "/home",
        Authorization = new[] { new HangfireAuthFilter() }
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();