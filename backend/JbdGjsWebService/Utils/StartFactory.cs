// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 初期処理
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using JbdGjsService.JBD.GJS.Db;

namespace JBD.GJS.WebService
{
    public class StartFactory
    {
        public static void Start(ConfigurationManager configuration)
        {
            DaGlobal.GetConnectionStringFunc = key => configuration.GetConnectionString(key) ?? string.Empty;
            DaGlobal.GetSectionConfigStringValueFunc = (section, key) => configuration.GetSection(section).GetValue<string>(key) ?? string.Empty;
        }
    }
}