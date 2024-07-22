// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             共通関数
// 作成日　　: 2024.02.16
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Where;

namespace BCC.Affect.DataAccess
{
    public class DaFrUtil
    {
        public static string GetSql(List<FrConditionItem> conditionList, string tableName)
        {
            var list = conditionList.Where(e => e.TableOrSql == tableName).Select(e => e.GetSql()).ToList();
            if (list.Count > 0)
            {
                var sql = string.Join(" and ", list);
                conditionList.RemoveAll(e => e.TableOrSql == tableName);


                if (conditionList.Count == 0)
                {
                    conditionList = new List<FrConditionItem>();
                }
                return sql;
            }
            else
            {
                return "1 = 1";
            }
        }
    }
}