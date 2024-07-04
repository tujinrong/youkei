// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 初期処理
//
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using BCC.Affect.DataAccess;

namespace BCC.Affect.WebService
{
    public class StartFactory
    {
        public static void Start(ConfigurationManager configuration)
        {
            DaGlobal.GetConnectionStringFunc = key => configuration.GetConnectionString(key) ?? string.Empty;
            DaGlobal.GetSectionConfigStringValueFunc = (section, key) => configuration.GetSection(section).GetValue<string>(key) ?? string.Empty;
            // 名称サービスの初期化
            //DaNameService.Init();
            //// コントロールサービスの初期化
            //DaControlService.Init();
        }
    }
}