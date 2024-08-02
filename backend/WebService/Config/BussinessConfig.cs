// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************

using Jbd.Gjs.WebService;
using WebService.Common.Base;

namespace WebService.Config;

public static class BussinessConfig
{
    private static readonly IEnumerable<Type> BUSSINESS_SERVICE_TYPES = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes())
        .Where(type => typeof(CmServiceBase).IsAssignableFrom(type) && !type.IsAbstract && !string.IsNullOrEmpty(type.FullName));

    public static void ConfigureBussinessServiceGen(this IServiceCollection services)
    {
        services.AddSingleton(new ServiceFactory());
        foreach (var type in BUSSINESS_SERVICE_TYPES)
        {
            // 単一インスタンスとして登録
            services.AddSingleton(type);
        }
    }

    public static void Configure(IServiceProvider serviceProvider)
    {
        var serviceFactory = serviceProvider.GetRequiredService<ServiceFactory>();
        foreach (var serviceType in BUSSINESS_SERVICE_TYPES)
        {
            var serviceInstance = serviceProvider.GetService(serviceType);
            if (serviceInstance != null && !string.IsNullOrEmpty(serviceType.FullName))
            {
                serviceFactory.AddService(serviceType.FullName, serviceInstance);
            }
        }
    }
}