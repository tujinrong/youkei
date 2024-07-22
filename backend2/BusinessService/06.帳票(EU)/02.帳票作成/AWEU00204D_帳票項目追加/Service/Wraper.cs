// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票項目追加
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWEU00107D;

namespace BCC.Affect.Service.AWEU00204D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 一覧項目ツリーリストを取得
        /// </summary>
        public static List<ItemTreeNode<ItemVM>> GetNormalItemTree(IEnumerable<tm_eutableitemDto> dtl)
        {
            return AWEU00107D.Wraper.GetNormalItemTree(dtl, GetLeafTreeNode, GetNotLeafTreeNode);
        }

        /// <summary>
        /// 集計項目ツリーリストを取得
        /// </summary>
        public static List<ItemTreeNode<ItemVM>> GetStatisticsItemTree(IEnumerable<tm_eutableitemDto> dtl, Enum集計区分? crosskbn = null)
        {
            if (crosskbn != null)
            {
                var isGroupBy = crosskbn != Enum集計区分.集計;
                dtl = dtl.Where(x => Enum.TryParse<Enum集計項目区分>(x.syukeikbn, out var syukeikbn) && syukeikbn == Enum集計項目区分.GroupBy == isGroupBy);
            }

            return AWEU00107D.Wraper.GetStatisticsItemTree(dtl, GetLeafTreeNode, GetNotLeafTreeNode);
        }

        /// <summary>
        /// 集計項目リストを取得
        /// </summary>
        public static List<BunruiItemVM> GetItemBunruiList(IEnumerable<tm_eutableitemDto> dtl, String maintablealias, Enum集計区分? crosskbn = null )
        {
            if (crosskbn != null)
            {
                var isGroupBy = crosskbn != Enum集計区分.集計;
                dtl = dtl.Where(x => Enum.TryParse<Enum集計項目区分>(x.syukeikbn, out var syukeikbn) && syukeikbn == Enum集計項目区分.GroupBy == isGroupBy);
            }

            return dtl.Where(x => !string.IsNullOrEmpty(x.daibunrui) && (crosskbn != Enum集計区分.集計|| x.tablealias == maintablealias))
                .GroupBy(x => x.daibunrui)
                .Select(g => GetBunruiItemVM(g.Key, g.ToList(), crosskbn))
                .ToList();
        }

        /// <summary>
        /// リーフノードの取得
        /// </summary>
        private static ItemTreeNode<ItemVM> GetLeafTreeNode(tm_eutableitemDto dto, Enum集計区分? crosskbn = null)
        {
            return new ItemTreeNode<ItemVM>(GetLeafItemVM(dto, crosskbn));
        }

        /// <summary>
        /// 非リーフノードを取得
        /// </summary>
        private static ItemTreeNode<ItemVM> GetNotLeafTreeNode(string burui, List<ItemTreeNode<ItemVM>> children)
        {
            return new ItemTreeNode<ItemVM>(GetNotLeafItemVM(burui), children);
        }

        /// <summary>
        /// リーフ項目を取得
        /// </summary>
        private static ItemVM GetLeafItemVM(tm_eutableitemDto dto, Enum集計区分? crosskbn = null)
        {
            Enum集計区分? ckbn = null;
            if (crosskbn == null)
            {
                if (dto.usekbn is Enum使用区分.集計項目 or Enum使用区分.併用 && Enum.TryParse<Enum集計項目区分>(dto.syukeikbn, out var syukeikbn))
                {
                    ckbn = syukeikbn == Enum集計項目区分.GroupBy ? Enum集計区分.GroupBy縦 : Enum集計区分.集計;
                }
            }
            else
            {
                ckbn = crosskbn;
            }

            var vm = new ItemVM(dto.sqlcolumn, dto.itemid, dto.itemhyojinm, true);
            vm.tablealias = dto.tablealias; 　//テーブル別名
            vm.orderkbn = Enum並び替え.無し;  //並び替え
            vm.orderseq = null;             　//並びシーケンス
            vm.reportoutputflg = true;      　//todo 帳票出力フラグ
            vm.csvoutputflg = true;         　//todo CSV出力フラグ
            vm.headerflg = false;           　//todo ヘッダーフラグ
            vm.kaipageflg = false;          　//todo 改ページフラグ
            vm.itemkbn = dto.itemkbn;       　//項目区分
            vm.formatkbn = null;            　//フォーマット区分
            vm.formatkbn2 = null;           　//フォーマット区分2
            vm.formatsyosai = null;         　//フォーマット詳細
            vm.height = null;               　//高
            vm.width = null;                　//幅
            vm.offsetx = null;              　//X軸オフセット
            vm.offsety = null;              　//Y軸オフセット
            vm.blankvalue = null;           　//白紙表示
            vm.mastercd = dto.mastercd;     　//todo 名称マスタコード
            vm.masterpara = dto.masterpara; 　//todo 名称マスタパラメータ
            vm.keyvaluepairsjson = null;    　//todo 複数のキー・値・ペアjson
            vm.crosskbn = ckbn;             　//todo 集計区分
            vm.syukeihoho = null;           　//todo 集計方法
            vm.kbn1 = null;                 　//todo 小計区分
            vm.level = null;                　//todo 集計レベル
            return vm;
        }

        /// <summary>
        /// 非リーフ項目の取得
        /// </summary>
        private static ItemVM GetNotLeafItemVM(string burui)
        {
            return new ItemVM(string.Empty, string.Empty, burui, false);
        }

        /// <summary>
        /// 集計項目検索処理
        /// </summary>
        private static BunruiItemVM GetBunruiItemVM(string daibunrui, IEnumerable<tm_eutableitemDto> itemList, Enum集計区分? crosskbn = null)
        {
            var vm = new BunruiItemVM();
            //大分類
            vm.daibunrui = daibunrui;
            //項目リスト
            vm.itemlist = itemList.Select(x => GetStatisticItemVM(x, crosskbn)).ToList();
            return vm;
        }

        /// <summary>
        /// 集計項目検索処理
        /// </summary>
        private static StatisticItemVM GetStatisticItemVM(tm_eutableitemDto dto, Enum集計区分? crosskbn = null)
        {
            var vm = new StatisticItemVM();
            Enum集計区分? ckbn = null;
            if (crosskbn == null)
            {
                if (dto.usekbn is Enum使用区分.集計項目 or Enum使用区分.併用 && Enum.TryParse<Enum集計項目区分>(dto.syukeikbn, out var syukeikbn))
                {
                    ckbn = syukeikbn == Enum集計項目区分.GroupBy ? Enum集計区分.GroupBy縦 : Enum集計区分.集計;
                }
            }
            else
            {
                ckbn = crosskbn;
            }

            vm.sqlcolumn = dto.sqlcolumn;       //SQLカラム
            vm.yosikiitemid = dto.itemid;       //様式項目ID
            vm.reportitemnm = dto.itemhyojinm;  //帳票項目名称
            vm.csvitemnm = dto.itemhyojinm;     //CSV項目名称
            vm.tablealias = dto.tablealias;     //テーブル別名
            vm.orderkbn = Enum並び替え.無し;    //並び替え
            vm.orderseq = null;                 //並びシーケンス
            vm.reportoutputflg = true;          //帳票出力フラグ
            vm.csvoutputflg = false;            //CSV出力フラグ
            vm.headerflg = false;               //todo ヘッダーフラグ
            vm.kaipageflg = false;              //todo 改ページフラグ
            vm.itemkbn = dto.itemkbn;           //項目区分
            vm.formatkbn = null;                //フォーマット区分
            vm.formatkbn2 = null;               //フォーマット区分2
            vm.formatsyosai = null;             //フォーマット詳細
            vm.height = null;                   //高
            vm.width = null;                    //幅
            vm.offsetx = null;                  //X軸オフセット
            vm.offsety = null;                  //Y軸オフセット
            vm.blankvalue = null;               //白紙表示
            vm.mastercd = dto.mastercd;         //todo 名称マスタコード
            vm.masterpara = dto.masterpara;     //todo 名称マスタパラメータ
            vm.keyvaluepairsjson = null;        //todo 複数のキー・値・ペアjson
            vm.crosskbn = ckbn;                 //todo 集計区分
            vm.syukeihoho = dto.syukeikbn;      //todo 集計方法
            vm.kbn1 = null;                     //todo 小計区分
            vm.level = null;                    //todo 集計レベル
            return vm;
        }

        /// <summary>
        /// プロシージャ項目ツリーの取得
        /// </summary>
        public static List<ItemTreeNode<ItemVM>> GetFunctionItemTreeList(IEnumerable<FunctionVM.Param> paramList)
        {
            var itemTreeVms = new List<ItemTreeNode<ItemVM>>();

            foreach (var param in paramList)
            {
                var vm = new ItemVM(param.Sqlcolumn, param.Id, param.Name, true);
                vm.tablealias = "";                       //テーブル別名
                vm.reportoutputflg = true;                //帳票出力フラグ
                vm.csvoutputflg = true;                   //CSV出力フラグ
                vm.itemkbn = Enum出力項目区分.普通項目;     //項目区分
                vm.orderkbn = Enum並び替え.無し;           //並び替え
                var itemNode = new ItemTreeNode<ItemVM>(vm);
                itemTreeVms.Add(itemNode);
            }
            return itemTreeVms;
        }

        /// <summary>
        /// プロシージャ項目の取得
        /// </summary>
        public static List<BunruiItemVM> GetFunctionItemList(List<FunctionVM.Param> paramList, Enum集計区分? crosskbn = null)
        {
            var vmList = new List<BunruiItemVM>();

            var subList = paramList.Where(e => (e.DataType == EnumDataType.整数 || e.DataType == EnumDataType.小数)).ToList();
            if (subList.Count > 0)
            {
                var bvm = new BunruiItemVM();
                bvm.daibunrui = "数値項目";
                bvm.itemlist = GetStatisticItemList(subList, crosskbn);
                vmList.Add(bvm);
            }


            subList = paramList.Where(e => !(e.DataType == EnumDataType.整数 || e.DataType == EnumDataType.小数)).ToList();
            if (subList.Count > 0)
            {
                var bvm = new BunruiItemVM();
                bvm.daibunrui = "文字項目";
                bvm.itemlist = GetStatisticItemList(subList, crosskbn);

                vmList.Add(bvm);
            }

            return vmList;
        }

        private static List<StatisticItemVM> GetStatisticItemList(IEnumerable<FunctionVM.Param> paramList, Enum集計区分? crosskbn = null)
        {
            var itemlist = new List<StatisticItemVM>();
            foreach (var param in paramList)
            {
                var vm = new StatisticItemVM();
                vm.sqlcolumn = param.Sqlcolumn;
                vm.sqlcolumn = param.Sqlcolumn;           //SQLカラム
                vm.yosikiitemid = param.Id;               //様式項目ID
                vm.reportitemnm = param.Name;             //帳票項目名称
                vm.csvitemnm = param.Name;                //CSV項目名称
                vm.crosskbn = crosskbn;                   //集計区分
                vm.tablealias = "";                       //テーブル別名
                vm.reportoutputflg = true;                //帳票出力フラグ
                vm.csvoutputflg = true;                   //CSV出力フラグ
                vm.itemkbn = Enum出力項目区分.普通項目;   //項目区分
                itemlist.Add(vm);
            }

            return itemlist;
        }
    }
}