// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索条件編集(通常)
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using BCC.Affect.Service.AWEU00201G;
using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00105D
{
    public class Wraper : CmWraperBase
    {
        private static readonly List<CdVM> EMPTY_CD_LIST = new(0);

        /// <summary>
        /// 初期化項目大分類リスト処理
        /// </summary>
        public static List<ItemDaiBunruiVM> GetItemDaibunruiVMList(IEnumerable<tm_eutableitemDto> itemDtl)
        {
            return itemDtl.GroupBy(x => CStr(x.daibunrui))
                .OrderBy(group => group.Key)
                .Select(group => GetItemDaiBunruiVM(group.Key, group))
                .ToList();
        }

        /// <summary>
        /// 初期化項目大分類リスト
        /// </summary>
        private static ItemDaiBunruiVM GetItemDaiBunruiVM(string daibunrui, IEnumerable<tm_eutableitemDto> dtl)
        {
            var vm = new ItemDaiBunruiVM();
            vm.daibunrui = daibunrui;                                                                                    //大分類
            vm.itemlist = dtl.Select(GetDatasourceItemVM).OrderBy(e => e.orderseq).ThenBy(x => x.itemhyojinm).ToList();  //項目リスト
            return vm;
        }

        /// <summary>
        /// 初期化項目大分類リスト
        /// </summary>
        private static DatasourceItemVM GetDatasourceItemVM(tm_eutableitemDto dto)
        {
            var vm = new DatasourceItemVM();
            vm.sqlcolumn = dto.sqlcolumn;                                                    //SQLカラム
            vm.itemid = dto.itemid;                                                          //項目ID
            vm.itemhyojinm = dto.itemhyojinm;                                                //表示名称
            vm.datatype = $"{(int)dto.datatype}{DaConst.SELECTOR_DELIMITER}{dto.datatype}";  //データ型
            vm.mastercd = dto.mastercd;                                                      //名称マスタコード
            vm.masterpara = dto.masterpara;                                                  //名称マスタパラメータ
            vm.orderseq = dto.orderseq;                                                      //並びシーケンス
            return vm;
        }

        /// <summary>
        /// 初期化マスタリスト処理
        /// </summary>
        public static List<MasterVM> GetMasterVMList(DaDbContext db, IEnumerable<tm_eutableitemnameDto> itemNameDtl, DataRowCollection rows)
        {
            var dict = rows.Cast<DataRow>().ToDictionary(r => (r.Wrap(nameof(tm_eutableitemnameDto.tablenm)), r.Wrap(nameof(CdVM.columnnm))), r => r.Wrap(nameof(CdVM.columncomment)));
            return itemNameDtl.Select(dto => GetMasterVM(db, dto, dict)).ToList();
        }

        /// <summary>
        ///  初期化マスタリスト
        /// </summary>
        private static MasterVM GetMasterVM(DaDbContext db, tm_eutableitemnameDto dto, IReadOnlyDictionary<(string, string), string> dict)
        {
            var vm = new MasterVM();
            vm.mastercd = dto.mastercd;             //マスタコード
            vm.masterhyojinm = dto.masterhyojinm;   //マスタ名称
            vm.cdlist = GetCdList(db, dto, dict);   //コードリスト
            return vm;
        }

        /// <summary>
        ///  初期化マスタリスト
        /// </summary>
        public static List<CdVM> GetCdList(DaDbContext db, tm_eutableitemnameDto dto, IReadOnlyDictionary<(string, string), string> dict)
        {
            if (string.IsNullOrEmpty(dto.maincd) && string.IsNullOrEmpty(dto.subcd))
            {
                //TODOi
                return EMPTY_CD_LIST;
            }

            var cdList = new List<CdVM>(2);
            if (!string.IsNullOrEmpty(dto.maincd))
            {
                var vm1 = new CdVM();
                //カラム
                vm1.columnnm = dto.maincd;
                //カラム名称
                vm1.columncomment = dict.GetValueOrDefault((dto.tablenm, dto.maincd), string.Empty);
                //選択リスト
                vm1.selectorlist = DaEucBasicService.GetMainCdSelectorList(db, dto.tablenm);
                //地区情報マスタ
                if (vm1.selectorlist != null && dto.tablenm == "tm_aftiku")
                {
                    vm1.selectorlist = vm1.selectorlist.OrderBy(r => CInt(r.value)).ToList();
                }
                //コードタイプ
                vm1.codetype = vm1.selectorlist == null
                    ? dto.maincdnumflg ? CodeTypeEnum.数値 : CodeTypeEnum.文字
                    : CodeTypeEnum.選択;
                cdList.Add(vm1);
            }

            if (!string.IsNullOrEmpty(dto.subcd))
            {
                var vm2 = new CdVM();
                //カラム
                vm2.columnnm = dto.subcd;
                //カラム名称
                vm2.columncomment = dict.GetValueOrDefault((dto.tablenm, dto.subcd), string.Empty);
                //選択リスト
                vm2.selectorlist = DaEucBasicService.GetSubCdSelectorList(db, dto.tablenm);
                //コードタイプ
                vm2.codetype = vm2.selectorlist == null
                    ? CodeTypeEnum.数値
                    : CodeTypeEnum.選択;
                cdList.Add(vm2);
            }

            return cdList;
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
                res.itemid = tableItemDto.itemid;                                                                  //項目ID
                res.sqlcolumn = tableItemDto.sqlcolumn;                                                            //SQLカラム
                res.itemhyojinm = tableItemDto.itemhyojinm;                                                        //表示名称
                res.datatype = $"{(int)tableItemDto.datatype}";                                                     //データ型
            }
            res.jyokenlabel = jyokenDto.jyokenlabel;                                                               //ラベル
            res.controlkbn = jyokenDto.controlkbn;                                                                 //コントロール区分
            res.mastercd = CStr(jyokenDto.mastercd);                                                               //名称マスタコード
            res.masterpara = CStr(jyokenDto.masterpara);                                                           //名称マスタパラメータ
            res.sansyomotosql = CStr(jyokenDto.sansyomotosql);                                                     //参照元SQL
            res.sql = jyokenDto.sql;                                                                               //SQL
            res.upddttm = jyokenDto.upddttm;                                                                       //更新日時
            res.nendohanikbn = jyokenDto.nendohanikbn;                                                             //年度範囲区分
            res.syokiti = CStr(jyokenDto.syokiti);                                                                 //初期値
            res.shiyoFlg = false;                                                                                  //使用済み
            if (jyokenDto.controlkbn == Enumコントロール.文字入力 && !string.IsNullOrEmpty(jyokenDto.aimaikbn))
            {
                res.aimaikbn = CStr(jyokenDto.aimaikbn);                                                           //曖昧検索区分
            }
            return res;
        }

        /// <summary>
        /// 選択条件情報を取得する
        /// </summary>
        public static List<DaSelectorModel> GetReportAddJokenVm(DaDbContext db, SearchJokenDetailRequest dto)
        {
            //選択リスト
            return CommonUtil.GetSelectorList(db, dto.mastercd, dto.masterpara);
        }
    }
}