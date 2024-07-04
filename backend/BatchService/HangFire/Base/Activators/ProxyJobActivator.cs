//using BatchService.Common.Base.Proxy.Providers;
using BatchService.Trigger.Base.Proxy.Providers;
using Hangfire;

namespace BatchService.Trigger.Base.Activators;

public sealed class ProxyJobActivator : JobActivator
{
    private readonly BatchServiceProxyProvider _batchServiceProxyProvider;

    public ProxyJobActivator(BatchServiceProxyProvider batchServiceProxyProvider)
    {
        _batchServiceProxyProvider = batchServiceProxyProvider;
    }

    public override object ActivateJob(Type jobType)
    {
        return _batchServiceProxyProvider.GetProxyByType(jobType);
    }
}
