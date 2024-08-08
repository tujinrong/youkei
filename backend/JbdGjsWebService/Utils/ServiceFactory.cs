// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ビジネスサービスインスタンス管理
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************

namespace JBD.GJS.WebService
{
    public class ServiceFactory
    {
        private readonly Dictionary<string, object> _businessServices = new();

        public object GetService(string svcName)
        {
            var serviceFullName = svcName.StartsWith("Common.")
                ? $"JbdGjsService.JBD.GJS.Service.{svcName}"
                : $"JbdGjsService.JBD.GJS.Service.{svcName}.Service";

            if (_businessServices.TryGetValue(serviceFullName, out var service))
            {
                return service;
            } 
            return new object();

        }

        public void AddService(string name, object serviceObj)
        {

            if (_businessServices.ContainsKey(name))
            {
                throw new InvalidOperationException($"「{name}」という名前のサービスはすでに存在します。");
            }

            _businessServices.Add(name, serviceObj);
        }
    }
}