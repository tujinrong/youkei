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
using Microsoft.AspNetCore.Server.Kestrel.Core;
using WebService.Common.Base.Response;
using WebService.Config;
using JbdGjsService.JBD.GJS.Db;
using Jbd.Gjs.WebService.Config;
using System.Text.Json;


CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ja-JP");
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.DefaultThreadCurrentCulture;
//LinuxでSystem.Drawing.Commonを通常に使用するために必要な設定
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper;
    });

var configuration = builder.Configuration;
    StartFactory.Start(configuration);

//System Start Up log
using (var db = new DaDbContext())
{
    db.Session.SessionData[JbdGjsService.JBD.GJS.Db.DaConst.SessionID] = -1L;
    db.Session.UserID = JbdGjsService.JBD.GJS.Db.DaConst.SYSTEM;
    DaDbLogService.WriteDbMessage
        (db, "System Start Up");
}

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
            policy.WithExposedHeaders(JbdGjsService.JBD.GJS.Db.DaConst.Content_Disposition,
                nameof(CmDownloadResponseBase.returncode),
                nameof(CmDownloadResponseBase.message));
        });
});

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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();