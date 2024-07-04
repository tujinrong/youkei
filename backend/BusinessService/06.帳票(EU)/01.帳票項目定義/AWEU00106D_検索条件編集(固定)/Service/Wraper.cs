// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索条件編集(固定)
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using System.Globalization;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00106D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 初期化処理
        /// </summary>
        public static List<ItemDaiBunruiVM> GetItemDaibunruiVMList(IEnumerable<tm_eutableitemDto> itemDtl)
        {
            return itemDtl.GroupBy(x => CStr(x.daibunrui))
                .OrderBy(group => group.Key)
                .Select(group => GetItemDaiBunruiVM(group.Key, group))
                .ToList();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        private static ItemDaiBunruiVM GetItemDaiBunruiVM(string daibunrui, IEnumerable<tm_eutableitemDto> dtl)
        {
            var vm = new ItemDaiBunruiVM();
            vm.daibunrui = daibunrui;                                                       //大分類
            vm.itemlist = dtl.Select(GetDatasourceItemVM).ToList();                         //項目リスト
            return vm;
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        private static DatasourceItemVM GetDatasourceItemVM(tm_eutableitemDto dto)
        {
            var vm = new DatasourceItemVM();
            vm.sqlcolumn = dto.sqlcolumn;                                                   //SQLカラム
            vm.itemid = dto.itemid;                                                         //項目ID
            vm.itemhyojinm = dto.itemhyojinm;                                               //表示名称
            vm.datatype = $"{(int)dto.datatype}{DaConst.SELECTOR_DELIMITER}{dto.datatype}"; //データ型
            return vm;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        public static SearchResponse GetSearchItem(tm_eutableitemDto tableItemDto, tm_eudatasourcekensakuDto jyokenDto)
        {
            var res = new SearchResponse();
            if (tableItemDto != null)
            {
                res.daibunrui = CStr(tableItemDto.daibunrui);                                                      //大分類
                res.sqlcolumn = tableItemDto.sqlcolumn;                                                            //SQLカラム
                res.itemid = tableItemDto.itemid;                                                                  //項目ID
                res.itemhyojinm = tableItemDto.itemhyojinm;                                                        //表示名称
                res.datatype = $"{(int)tableItemDto.datatype}{DaConst.SELECTOR_DELIMITER}{tableItemDto.datatype}"; //データ型
                res.syokiti = jyokenDto.syokiti;
            }
            res.jyokenkbn = jyokenDto.jyokenkbn;                                                                  //検索条件区分
            res.jyokenlabel = jyokenDto.jyokenlabel;                                                              //ラベル
            res.sql = jyokenDto.sql;                                                                              //SQL
            res.upddttm = jyokenDto.upddttm;                                                                      //更新日時
            
            return res;
        }

        /// <summary>
        /// SQL から値を取得
        /// </summary>
        internal static string GetValueFromSql(EnumDataType dataType, string sql)
        {
            var formattedValue = sql.Split(DaStrPool.C_EQ, 2, StringSplitOptions.TrimEntries)[1];
            formattedValue = RemoveStartAndEndQuotes(formattedValue);
            return dataType switch
            {
                EnumDataType.整数 => int.TryParse(formattedValue, out var num) ? num.ToString() : 0.ToString(),
                EnumDataType.小数 => decimal.TryParse(formattedValue, out var num) ? num.ToString(CultureInfo.InvariantCulture) : 0.ToString(),
                EnumDataType.文字列 => formattedValue,
                EnumDataType.日付 => DateTime.TryParse(formattedValue, out var date) ? $"{date:yyyy-MM-dd}" : $"{DateTime.MinValue:yyyy-MM-dd}",
                EnumDataType.時間 => DateTime.TryParse(formattedValue, out var time) ? $"{time:yyyy-MM-dd HH:mm:ss}" : $"{DateTime.MinValue:yyyy-MM-dd HH:mm:ss}",
                EnumDataType.フラグ => bool.TryParse(formattedValue, out var flag) ? flag.ToString().ToLower() : false.ToString().ToLower(),
                _ => formattedValue
            };
        }

        /// <summary>
        /// 開始と終了のシングルクォートを削除
        /// </summary>
        private static string RemoveStartAndEndQuotes(string? str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            return str.StartsWith(DaStrPool.C_SQT) && str.EndsWith(DaStrPool.C_SQT) ? str.Substring(1, Math.Max(0, str.Length - 2)) : str;
        }
    }
}