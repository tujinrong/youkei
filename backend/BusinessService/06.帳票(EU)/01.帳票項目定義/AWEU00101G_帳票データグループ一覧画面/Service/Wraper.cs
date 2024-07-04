// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票データグループ一覧
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00101G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 検索処理
        /// </summary>
        public static List<SearchVM> GetSearchVMList(DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(GetSearchVM).ToList();
        }

        /// <summary>
        /// データソース詳細
        /// </summary>
        public static DatasourceTableVM GetDatasourceMainTableVM(tm_eudatasourceDto datasourceDto, IReadOnlyDictionary<string, List<tm_eutableitemDto>> tablealias2ItemsDic,
            IReadOnlyDictionary<string, tm_eutableDto> tableAlias2TableDtoDic, IReadOnlyDictionary<string, DateTime> sqlColumn2UpddttmDic)
        {
            var mainTableDto = tableAlias2TableDtoDic.GetValueOrDefault(datasourceDto.maintablealias);
            var vm = new DatasourceTableVM();
            vm.tablealias = mainTableDto?.tablealias ?? string.Empty;                                                       //テーブル別名
            vm.tablenm = mainTableDto?.tablenm ?? string.Empty;                                                             //テーブル物理名
            vm.tablehyojinm = mainTableDto?.tablehyojinm ?? string.Empty;                                                   //テーブル名称
            vm.itemlist = GetDatasourceItemVMList(datasourceDto.maintablealias, tablealias2ItemsDic, sqlColumn2UpddttmDic); //テーブル項目リスト
            vm.upddttm = datasourceDto.upddttm;                                                                             //更新日時
            return vm;
        }

        /// <summary>
        /// データソース詳細
        /// </summary>
        public static List<DatasourceTableVM> GetDatasourceTableVMList(IEnumerable<tm_eudatasourcejoinDto> datasourceTableDtl,
            IReadOnlyDictionary<string, List<tm_eutableitemDto>> tablealias2ItemsDic, IReadOnlyDictionary<string, tm_eutableDto> tableAlias2TableDtoDic,
            IReadOnlyDictionary<string, DateTime> sqlColumn2UpddttmDic, EnumTableKbn tableKbn, DatasourceTableAliasComparer comparer)
        {
            var filteredTableAlias2TableDtoDic = tableAlias2TableDtoDic
                .Where(x => x.Value.tablekbn == tableKbn)
                .ToDictionary(x => x.Key, x => x.Value);

            return datasourceTableDtl.Where(x => filteredTableAlias2TableDtoDic.ContainsKey(x.tablealias))
                .Select(x => GetDatasourceTableVM(x, tablealias2ItemsDic, filteredTableAlias2TableDtoDic, sqlColumn2UpddttmDic))
                .Where(x => x.itemlist.Any())
                .OrderBy(x => x.tablealias, comparer)
                .ToList();
        }

        /// <summary>
        /// 検索条件検索処理(通常)
        /// </summary>
        public static List<ConditionVM> GetConditionVMList(IEnumerable<tm_eudatasourcekensakuDto> dtl)
        {
            return dtl.Select(GetConditionVM).ToList();
        }

        /// <summary>
        /// 検索条件検索処理(固定)
        /// </summary>
        public static List<FixedConditionVM> GetFixedConditionVMList(IEnumerable<tm_eudatasourcekensakuDto> dtl)
        {
            return dtl.Select(GetFixedConditionVM).ToList();
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        private static SearchVM GetSearchVM(DataRow row)
        {
            var vm = new SearchVM();
            vm.datasourceid = row.Wrap(nameof(SearchVM.datasourceid));                                                   //データソースID
            vm.datasourcenm = row.Wrap(nameof(SearchVM.datasourcenm));                                                   //データソース名称
            vm.gyoumu = row.Wrap(nameof(SearchVM.gyoumu));                                                               //業務
            vm.maintablehyojinm = row.Wrap(nameof(SearchVM.maintablehyojinm));                                           //メインテーブル名称
            vm.maintablenm = row.Wrap(nameof(SearchVM.maintablenm));                                                     //メインテーブル物理名
            return vm;
        }

        /// <summary>
        /// データソース詳細
        /// </summary>
        private static DatasourceTableVM GetDatasourceTableVM(tm_eudatasourcejoinDto datasourceTableDto, IReadOnlyDictionary<string, List<tm_eutableitemDto>> tablealias2ItemsDic,
            IReadOnlyDictionary<string, tm_eutableDto> tableAlias2TableDtoDic, IReadOnlyDictionary<string, DateTime> sqlColumn2UpddttmDic)
        {
            var tableDto = tableAlias2TableDtoDic.GetValueOrDefault(datasourceTableDto.tablealias);
            var vm = new DatasourceTableVM();
            vm.tablealias = tableDto?.tablealias ?? string.Empty;                                                            //テーブル別名
            vm.tablenm = tableDto?.tablenm ?? string.Empty;                                                                  //テーブル物理名
            vm.tablehyojinm = tableDto?.tablehyojinm ?? string.Empty;                                                        //テーブル名称
            vm.itemlist = GetDatasourceItemVMList(datasourceTableDto.tablealias, tablealias2ItemsDic, sqlColumn2UpddttmDic); //テーブル項目リスト
            //vm.upddttm = datasourceTableDto.upddttm; //更新日時
            return vm;
        }

        /// <summary>
        /// データソース項目リスト
        /// </summary>
        private static List<DatasourceTableItemVM> GetDatasourceItemVMList(string tablealias, IReadOnlyDictionary<string, List<tm_eutableitemDto>> tablealias2ItemsDic,
            IReadOnlyDictionary<string, DateTime> sqlColumn2UpddttmDic)
        {
            return tablealias2ItemsDic.GetValueOrDefault(tablealias, new List<tm_eutableitemDto>())
                .Where(x => sqlColumn2UpddttmDic.ContainsKey(x.sqlcolumn))
                .Select(x => GetDatasourceItemVM(x, sqlColumn2UpddttmDic[x.sqlcolumn]))
                .OrderBy(e => e.itemid).ToList();
        }

        /// <summary>
        /// データソース項目
        /// </summary>
        private static DatasourceTableItemVM GetDatasourceItemVM(tm_eutableitemDto dto, DateTime upddttm)
        {
            var vm = new DatasourceTableItemVM();
            vm.itemid = dto.itemid;                                                                                          //データソース項目ID
            vm.itemhyojinm = dto.itemhyojinm;                                                                                //表示名称
            vm.sqlcolumn = dto.sqlcolumn;                                                                                    //SQLカラム
            vm.daibunrui = dto.daibunrui;                                                                                    //大分類
            vm.tyubunrui = dto.tyubunrui;                                                                                    //中分類
            vm.syobunrui = dto.syobunrui;                                                                                    //小分類
            vm.upddttm = upddttm;                                                                                            //更新日時
            return vm;
        }

        /// <summary>
        /// 検索条件検索処理(通常)
        /// </summary>
        private static ConditionVM GetConditionVM(tm_eudatasourcekensakuDto dto)
        {
            var vm = new ConditionVM();
            vm.jyokenid = dto.jyokenid;                                                                                      //条件ID
            vm.jyokenlabel = dto.jyokenlabel;                                                                                //ラベル
            vm.sql = dto.sql;                                                                                                //SQL
            vm.control = dto.controlkbn.ToString();                                                                          //コントロール
            if (dto.controlkbn == Enumコントロール.文字入力 && !string.IsNullOrEmpty(dto.aimaikbn))
            {
                vm.aimaikbn =　dto.aimaikbn;                                                                                 //曖昧検索区分
            }
            return vm;
        }

        /// <summary>
        /// 検索条件検索処理(固定)
        /// </summary>
        private static FixedConditionVM GetFixedConditionVM(tm_eudatasourcekensakuDto dto)
        {
            var vm = new FixedConditionVM();
            vm.jyokenid = dto.jyokenid;                                                                                       //条件ID
            vm.jyokenlabel = dto.jyokenlabel;                                                                                 //ラベル
            vm.sql = dto.sql;                                                                                                 //SQL
            vm.jyokenkbn = dto.jyokenkbn.ToString();                                                                          //検索条件区分
            vm.variables = dto.variables ?? string.Empty;                                                                     //変数名
            vm.tablealias = dto.tablealias;                                                                                   //テーブル名
            vm.mastercd = dto.mastercd ?? string.Empty;                                                                       //名称マスタコード
            vm.masterpara = dto.masterpara ?? string.Empty;                                                                   //名称マスタパラメータ
            vm.sansyomotosql = dto.sansyomotosql ?? string.Empty;                                                             //参照元SQL
            vm.controlkbn = dto.controlkbn;                                                                                   //コントロール区分
            vm.datatype = dto.datatype;                                                                                       //データ型
            if (dto.controlkbn == Enumコントロール.文字入力 && !string.IsNullOrEmpty(dto.aimaikbn))
            {
                vm.aimaikbn = dto.aimaikbn;                                                                                   //曖昧検索区分
            }                                                                                                               
            return vm;
        }
    }
}