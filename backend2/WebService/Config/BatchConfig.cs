using System.ComponentModel;
using System.Reflection;
using BatchService.Trigger.Base.Activators;
using BatchService.Trigger.Base.Attributes;
using BatchService.Trigger.Base.Proxy.Interceptors;
using BatchService.Trigger.Base.Proxy.Providers;
using BatchService.Trigger.Operators.Default;



//using BatchService.Backup.Base.Activators;
//using BatchService.Backup.Base.Attributes;
//using BatchService.Backup.Base.Proxy.Interceptors;
using BCC.Affect.BatchService;
//using BatchService.Backup.Base.Proxy.Providers;
//using BatchService.Backup.Trigger.Operators.Default;
//using BatchService.Base.Activators;
//using BatchService.Base.Proxy.Providers;

//using BatchService.Base.Activators;
//using BatchService.Base.Proxy.Interceptors;
//using BatchService.Base.Proxy.Providers;
//using BatchService.Common;

//using BatchService.Trigger.Operators.Default;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using Hangfire;
//using BatchService.Common.Base.Attributes;
//using BatchService.Common.Service;

namespace WebService.Config;

public static class BatchConfig
{
    private static readonly IEnumerable<Type> BATCH_SERVICE_TYPES = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes())
        .Where(type => typeof(IBatchService).IsAssignableFrom(type) && !type.IsAbstract);
        //.Where(type => typeof(IBatchService).IsAssignableFrom(type) && !type.IsAbstract && type.GetCustomAttribute<BatchServiceAttribute>() != null);

    public static void ConfigureBatchServiceGen(this IServiceCollection services)
    {
        var batchServiceProxyProvider = new BatchServiceProxyProvider();
        var interceptor = new BatchServiceProxyInterceptor(new ConsoleLogger("BATCH_LOGGER"));
        var proxyGenerator = new ProxyGenerator();

        foreach (var type in BATCH_SERVICE_TYPES)
        {
            var serviceAttribute = type.GetCustomAttribute<BatchServiceAttribute>();
            var serviceName = string.IsNullOrEmpty(serviceAttribute?.Name) ? type.FullName : serviceAttribute.Name;
            if (string.IsNullOrEmpty(serviceName)) continue;

            // 単一インスタンスとして登録
            services.AddSingleton(type);
            // プロキシの作成
            var proxyObj = proxyGenerator.CreateClassProxy(type, interceptor);
            batchServiceProxyProvider.AddProxy(serviceName, type, proxyObj);
        }

        // タスク代理のサービスプロバイダーを登録
        services.AddSingleton(batchServiceProxyProvider);
        // デフォルトのタスクオペレーターの登録
        services.AddSingleton(new DefaultTaskOperator());

        // Hangfireはタスク実行時にプロキシオブジェクトを使用する
        var proxyJobActivator = new ProxyJobActivator(batchServiceProxyProvider);
        services.AddSingleton<JobActivator>(proxyJobActivator);
        GlobalConfiguration.Configuration.UseActivator(proxyJobActivator);
    }
}
