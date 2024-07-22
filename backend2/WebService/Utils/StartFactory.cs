// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 初期処理
//
// 作成日　　: 
// 作成者　　: 
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