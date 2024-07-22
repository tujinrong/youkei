//using BatchService.Common.Service;
using BCC.Affect.BatchService;

namespace BatchService.Trigger.Base.Proxy.Providers;

public sealed class BatchServiceProxyProvider
{
    private readonly Dictionary<string, object> NameToProxyDictionary = new();

    private readonly Dictionary<Type, object> TypeToProxyDictionary = new();

    public T GetProxyByType<T>() where T : IBatchService
    {
        return (T)GetProxyByType(typeof(T));
    }

    public object GetProxyByType(Type type)
    {
        if (!typeof(IBatchService).IsAssignableFrom(type))
        {
            throw new ArgumentException($"パラメータ「{nameof(type)}」はIBatchService型でなければならない。");
        }

        if (!TypeToProxyDictionary.TryGetValue(type, out var proxy))
        {
            throw new InvalidOperationException($"「{type}」型のプロキシオブジェクトが存在しない。");
        }

        return proxy;
    }

    public T GetProxyByName<T>(string name) where T : IBatchService
    {
        if (!NameToProxyDictionary.TryGetValue(name, out var proxy))
        {
            throw new InvalidOperationException($"「{name}」という名前のプロキシオブジェクトが存在しません。");
        }

        return (T)proxy;
    }

    public void AddProxy(string name, Type type, object proxy)
    {
        if (NameToProxyDictionary.ContainsKey(name))
        {
            throw new InvalidOperationException($"「{name}」という名前のプロキシオブジェクトがすでに存在する。");
        }

        if (TypeToProxyDictionary.ContainsKey(type))
        {
            throw new InvalidOperationException($"「{type}」型のプロキシオブジェクトが既に存在する。");
        }

        NameToProxyDictionary.Add(name, proxy);
        TypeToProxyDictionary.Add(type, proxy);
    }
}