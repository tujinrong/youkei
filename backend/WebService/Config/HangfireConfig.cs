// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using Hangfire;

namespace JBD.GJS.WebService;

public static class HangfireConfig
{
    //private static readonly PostgreSqlStorageOptions PostgreSqlStorageOptions = new()
    //{
    //    // config your PostgreSqlStorageOptions
    //    SchemaName = "public"
    //};

    public static void ConfigureHangfireGen(this IServiceCollection services, IConfiguration configuration)
    {
        //var hangfireConnectionString = configuration.GetConnectionString("BatchScheduleConnection");
        //services.AddHangfire(config =>
        //    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        //        .UseSimpleAssemblyNameTypeSerializer()
        //        .UseRecommendedSerializerSettings()
        //        .UseDefaultCulture(CultureInfo.DefaultThreadCurrentCulture)
        //        .UsePostgreSqlStorage(c => c.UseNpgsqlConnection(hangfireConnectionString), PostgreSqlStorageOptions)
        //);

        services.AddHangfireServer();
        //タスク例外時の再試行回数
        GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 3 });
    }
}