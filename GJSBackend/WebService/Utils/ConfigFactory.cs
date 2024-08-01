// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: コンフィグ処理
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
namespace Jbd.Gjs.WebService
{
    public class ConfigFactory
    {
        private readonly IConfiguration _configuration;

        public ConfigFactory(IConfiguration config)
        {
            _configuration = config;
        }

        public string GetConnectionString(string name)
        {
            return _configuration.GetConnectionString(name)!;
        }
    }
}