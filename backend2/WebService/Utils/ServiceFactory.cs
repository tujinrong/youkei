// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ビジネスサービスインスタンス管理
//
// 作成日　　: 
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service;

namespace BCC.Affect.WebService
{
    public class ServiceFactory
    {
        private readonly Dictionary<string, CmServiceBase> _businessServices = new();

        public object GetService(string svcName)
        {
            var serviceFullName = svcName.StartsWith("Common.")
                ? $"BCC.Affect.Service.{svcName}"
                : $"BCC.Affect.Service.{svcName}.Service";

            if (_businessServices.TryGetValue(serviceFullName, out var service))
            {
                return service;
            }

            var t = new Service.AWAF00101G.Service().GetType().Assembly.GetType(serviceFullName);
            return Activator.CreateInstance(t!)!;
        }

        public void AddService(string name, object serviceObj)
        {
            if (serviceObj is not CmServiceBase service) return;

            if (_businessServices.ContainsKey(name))
            {
                throw new InvalidOperationException($"「{name}」という名前のサービスはすでに存在します。");
            }

            _businessServices.Add(name, service);
        }
    }
}