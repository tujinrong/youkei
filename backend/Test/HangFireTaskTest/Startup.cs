using BCC.Affect.BatchService;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HangFireTaskTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //var hangfireConnectionString = "server=43.163.201.169;port=5435;database=postgres;SearchPath=public;uid=postgres;password=AIplus2023!";

            var hangfireConnectionString = "Host=43.163.201.169;Port=5433;Database=postgres;SearchPath=public;uid=postgres;pwd=AIplus2023!";

            //services.AddHangfire(config =>
            //    config.UsePostgreSqlStorage(c => { c.UseNpgsqlConnection(hangfireConnectionString); },
            //        new PostgreSqlStorageOptions
            //        {
            //            // config your PostgreSqlStorageOptions
            //            SchemaName = "public"
            //        }
            //    ));

            services.AddHangfire(config =>
            {
                config.UsePostgreSqlStorage(c => { c.UseNpgsqlConnection(hangfireConnectionString); },
                    new PostgreSqlStorageOptions
                    {
                        // config your PostgreSqlStorageOptions
                        SchemaName = "public"
                    });

                GlobalJobFilters.Filters.Add(new CaptureJobIdFilter());
                //タスク例外時の再試行回数
                GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 3 });
            });

            services.AddHangfireServer();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                AppPath = "/home",
                Authorization = new[] { new HangfireAuthFilter() }
            });
        }





































































    }
}
