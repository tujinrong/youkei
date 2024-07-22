// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 項目編集
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00104D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 初期化処理
        /// </summary>
        public static List<TableVM> GetTableVMList(tm_eutableDto mainTableDto, List<tm_eutableDtoJoin> canJoinTableDtl)
        {
            var tableList = new List<TableVM>(canJoinTableDtl.Count + 1) { GetTableVM(mainTableDto, string.Empty) };
            tableList.AddRange(canJoinTableDtl.Where(x => x.tablealias != mainTableDto.tablealias).Select(x => GetTableVM(x, x.kanrentablealias)));
            return tableList;
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        private static TableVM GetTableVM(tm_eutableDto tableDto, string kanrentablealias)
        {
            var vm = new TableVM();
            vm.tablealias = tableDto.tablealias;                                                   //テーブル·別名
            vm.tablenm = tableDto.tablenm;                                                         //テーブル物理名
            vm.tablehyojinm = tableDto.tablehyojinm;                                               //テーブル名称
            vm.kanrentablealias = kanrentablealias;                                                //関連テーブル別名
            return vm;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        public static void SetSearchItem(SearchResponse res, tm_eutableitemDto tableitemDto)
        {
            //編集フラグ
            res.editflg = int.TryParse(tableitemDto.itemid.Split(DaStrPool.C_UNDERLINE, StringSplitOptions.TrimEntries)[0], out var num) &&
                              num is >= tm_eutableitemDto.EDITABLE_ITEM_ID_MIN_PREFIX and <= tm_eutableitemDto.EDITABLE_ITEM_ID_MAX_PREFIX; 
            res.itemhyojinm = tableitemDto.itemhyojinm;                                            //表示名称
            res.sqlcolumn = tableitemDto.sqlcolumn;                                                //SQLカラム
            res.tablealias = tableitemDto.tablealias;                                              //テーブル別名
            res.itemid = tableitemDto.itemid;                                                      //項目ID
            res.daibunrui = tableitemDto.daibunrui;                                                //大分類
            res.tyubunrui = tableitemDto.tyubunrui;                                                //中分類
            res.syobunrui = tableitemDto.syobunrui;                                                //小分類
            res.usekbn = tableitemDto.usekbn;                                                      //使用区分
            res.itemkbn = tableitemDto.itemkbn;                                                    //todo 出力項目区分
            res.syukeikbn = tableitemDto.usekbn is Enum使用区分.集計項目 or Enum使用区分.併用 &&
                Enum.TryParse<Enum集計項目区分>(tableitemDto.syukeikbn, out var kbn) ? kbn : null; //集計項目区分
            res.datatype = tableitemDto.datatype;                                                  //データ型
            res.mastercd = CNStr(tableitemDto.mastercd);                                           //マスタコード
            res.masterpara = CNStr(tableitemDto.masterpara);                                       //マスタパラメータ
        }
    }
}