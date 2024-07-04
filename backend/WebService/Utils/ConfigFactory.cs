// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: コンフィグ処理
//
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.WebService
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