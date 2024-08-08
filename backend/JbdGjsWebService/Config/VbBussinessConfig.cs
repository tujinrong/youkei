// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************

using JBD.GJS.WebService;

namespace WebService.Config;

public static class VbBussinessConfig
{
    private static readonly IEnumerable<Type> VBBUSSINESS_SERVICE_TYPES = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes())
        .Where(type => typeof(JbdGjsService.JBD.GJS.Service.CmServiceBase).IsAssignableFrom(type) && !type.IsAbstract && !string.IsNullOrEmpty(type.FullName));

    public static void ConfigureVbBussinessServiceGen(this IServiceCollection services)
    {
        services.AddSingleton(new ServiceFactory());
        foreach (var type in VBBUSSINESS_SERVICE_TYPES)
        {
            // 単一インスタンスとして登録
            services.AddSingleton(type);
        }
    }

    public static void Configure(IServiceProvider serviceProvider)
    {
        var serviceFactory = serviceProvider.GetRequiredService<ServiceFactory>();
        foreach (var serviceType in VBBUSSINESS_SERVICE_TYPES)
        {
            var serviceInstance = serviceProvider.GetService(serviceType);
            if (serviceInstance != null && !string.IsNullOrEmpty(serviceType.FullName))
            {
                serviceFactory.AddService(serviceType.FullName, serviceInstance);
            }
        }
    }
}