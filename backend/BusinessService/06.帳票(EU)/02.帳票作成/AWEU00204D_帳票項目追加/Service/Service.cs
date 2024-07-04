// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票項目追加
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using AIplus.AiReport.Enums;
using BCC.Affect.Service.AWEU00107D;
using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.FunctionVM;

namespace BCC.Affect.Service.AWEU00204D
{
    [DisplayName("帳票項目追加")]
    public class Service : CmServiceBase
    {
        [DisplayName("検索処理(一覧項目ツリー)")]
        public SearchNormalTreeResponse SearchNormalTree(SearchNormalTreeRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchNormalTreeResponse();

                if (!string.IsNullOrEmpty(req.procnm) && !string.IsNullOrEmpty(req.sql))
                {
                    //プロシージャ項目を検索
                    var returnparams = SearchProcItem(db, req.procnm, req.sql, req.itemids);
                    //プロシージャ項目リスト
                    res.itemtree = Wraper.GetFunctionItemTreeList(returnparams);
                }
                else
                {
                    if (string.IsNullOrEmpty(req.datasourceid)) return res;

                    //-------------------------------------------------------------
                    //１.データ取得
                    //-------------------------------------------------------------
                    var selectableItemDtl =
                        GetSelectableItemDtl(db, req.datasourceid, req.itemids, Enum使用区分.一覧項目, Enum使用区分.併用);

                    //-------------------------------------------------------------
                    //２.データ加工処理
                    //-------------------------------------------------------------
                    //一覧項目ツリー情報を取得
                    res.itemtree = Wraper.GetNormalItemTree(selectableItemDtl);
                }

                //特殊項目を取得
                var itemtree = GetSpecialItem(db, req);
                //特殊項目を追加
                res.itemtree.AddRange(itemtree);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(集計項目ツリー)")]
        public SearchNormalTreeResponse SearchStatisticTree(SearchStatisticTreeRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchNormalTreeResponse();

                if (!string.IsNullOrEmpty(req.procnm) && !string.IsNullOrEmpty(req.sql))
                {
                    //プロシージャ項目を検索
                    var returnparams = SearchProcItem(db, req.procnm, req.sql, req.itemids);
                    //プロシージャ項目リスト
                    res.itemtree = Wraper.GetFunctionItemTreeList(returnparams);
                }
                else
                {
                    if (string.IsNullOrEmpty(req.datasourceid)) return res;

                    //-------------------------------------------------------------
                    //１.データ取得
                    //-------------------------------------------------------------
                    var selectableItemDtl =
                        GetSelectableItemDtl(db, req.datasourceid, req.itemids, Enum使用区分.集計項目, Enum使用区分.併用);

                    //-------------------------------------------------------------
                    //２.データ加工処理
                    //-------------------------------------------------------------
                    //集計項目ツリー情報を取得
                    res.itemtree = Wraper.GetStatisticsItemTree(selectableItemDtl, req.crosskbn);
                }

                //特殊項目を取得
                var itemtree = GetSpecialItem(db, req);
                //特殊項目を追加
                res.itemtree.AddRange(itemtree);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(集計項目)")]
        public SearchStatisticResponse SearchStatistic(SearchStatisticRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchStatisticResponse();

                if (!string.IsNullOrEmpty(req.procnm) && !string.IsNullOrEmpty(req.sql))
                {
                    //プロシージャ項目を検索
                    var returnparams = SearchProcItem(db, req.procnm, req.sql, req.itemids);
                    //プロシージャ項目リスト
                    res.bunruilist = Wraper.GetFunctionItemList(returnparams, req.crosskbn);
                    //ドロップダウンリスト(集計項目区分)
                    res.syukeikbnlist = EucConstant.SYUKEI_KBN_OPTIONS
                        .Where(e => !e.value.Equals(DaConvertUtil.EnumToStr(Enum集計項目区分.GroupBy))).ToList();
                }
                else
                {
                    if (string.IsNullOrEmpty(req.datasourceid)) return res;

                    //-------------------------------------------------------------
                    //１.データ取得
                    //-------------------------------------------------------------
                    if (!string.IsNullOrEmpty(req.itemid))
                    {
                        req.itemids.Remove(req.itemid);
                    }

                    //項目リストを取得
                    var selectableItemDtl =
                        GetSelectableItemDtl(db, req.datasourceid, req.itemids, Enum使用区分.集計項目, Enum使用区分.併用);
                    var maintablealias = db.tm_eudatasource.GetDtoByKey(req.datasourceid).maintablealias;
                    //-------------------------------------------------------------
                    //２.データ加工処理
                    //-------------------------------------------------------------
                    //集計項目ー情報を取得
                    res.bunruilist = Wraper.GetItemBunruiList(selectableItemDtl, maintablealias, req.crosskbn);
                }

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// プロシージャ項目を検索
        /// </summary>
        public List<Param> SearchProcItem(DaDbContext db, string procnm, string sql,
            IReadOnlySet<string> selectedItemIds)
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //プロシージャ名称
            var functionName = procnm;
            var functionVm =
                DaEucBasicService.GetFunctionVMByName(db, functionName,
                    necessaryPrefix: EucConstant.EUC_FUNCTION_PREFIX);
            if (functionVm == null) throw new Exception($"「{functionName}」という名前の関数の取得に失敗しました。");

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //フィールドの説明（コメント）を取得する
            var dicName = FunctionParseUtil.GetReturnItemName(sql);
            var dicDBName = DaEucCacheService.GetColumnDescDic(db);
            //様式項目リスト
            var returnparams = functionVm.returnparams.Where(x => !selectedItemIds.Contains(x.Id)).ToList();
            //プロシージャパラメータ名称をセット(日本語に変換)
            SetPraName(ref returnparams, dicName, dicDBName);

            return returnparams;
        }

        /// <summary>
        /// プロシージャパラメータ名称をセット(日本語に変換)
        /// </summary>
        private void SetPraName(ref List<Param> proparams, Dictionary<string, string> dicName,
            Dictionary<string, string> dicDBName)
        {
            foreach (var param in proparams)
            {
                if (dicName.ContainsKey(param.Sqlcolumn))
                {
                    param.Name = dicName[param.Sqlcolumn];
                }
                else
                {
                    //項目名称をセット
                    param.SetName(dicDBName);
                }
            }
        }

        /// <summary>
        /// 項目リストを取得
        /// </summary>
        private static IEnumerable<tm_eutableitemDto> GetSelectableItemDtl(DaDbContext db, string datasourceId,
            IReadOnlySet<string> selectedItemIds, params Enum使用区分[]? useKbns)
        {
            //EUCデータソース項目マスタからSQLカラムリストを取得
            var datasourceSqlColumnList = db.tm_eudatasourceitem.SELECT
                .SetSelectItems(nameof(tm_eudatasourceitemDto.sqlcolumn))
                .WHERE.ByKey(datasourceId).GetDtoList()
                .Select(x => x.sqlcolumn)
                .ToList();

            //EUCテーブル項目名称マスタ
            var datasourceTableItemDtl = db.tm_eutableitem.SELECT.WHERE.ByKeyList(datasourceSqlColumnList)
                .ORDER.By(nameof(tm_eutableitemDto.orderseq)).GetDtoList()
                .Where(x => !selectedItemIds.Contains(x.itemid))
                .ToList();

            if (useKbns == null || !useKbns.Any())
            {
                return datasourceTableItemDtl;
            }
            else
            {
                return datasourceTableItemDtl.Where(x => useKbns.Contains(x.usekbn));
            }
        }



        static bool isNotMultipleFields(string sqlcolumn)
        {
            return !(sqlcolumn.Contains(" ") || sqlcolumn.Contains("("));
        }


        [DisplayName("チェック処理(登録押下)")]
        public DaResponseBase Check(CheckRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                if (!string.IsNullOrEmpty(req.formatkbn))
                {
                    string sqlcolumn = CStr(req.sqlcolumn);
                    int formatkbn = Convert.ToInt32(req.formatkbn);
                    int formatkbn2 = 0;
                    if (!string.IsNullOrEmpty(req.formatkbn2))
                    {
                         formatkbn2 = Convert.ToInt32(req.formatkbn2);
                    }
                    //フォーマットの「区分」と「詳細」を選択したのは「バーコード」と「カスタマーコード」
                    if (!string.IsNullOrEmpty(sqlcolumn) && formatkbn == (int)Enumデータタイプ.バーコード && formatkbn2 == (int)ArEnumBarCode.CustomerCode)
                    {
                        if (isNotMultipleFields(sqlcolumn))
                        {
                            var msg = DaMessageService.GetMsg(EnumMessage.E064018);
                            res.SetServiceError(msg);
                            return res;
                        }
                    }
                    else
                    {
                        List<tm_eutableitemDto> tableitemList  =DaEucCacheService.GetEutableitemDtoList(db);
                        
                        tm_eutableitemDto tableitem = tableitemList.FirstOrDefault(x => x.sqlcolumn == sqlcolumn)!;

                        if (tableitem != null)
                        {
                            EnumDataType datatype = tableitem.datatype;

                            bool[,] supportArray = new bool[6, 9]
                            {
                            // 文字, 数値, 年, 日付, 日時, 時間, 論理, バーコード, QRコード
                            { true, true, true, false, false, false, true, false, false }, // 整数
                            { true, true, false, false, false, false, false, false, false }, // 小数
                            { true, false, false, false, false, false, false, true, true }, // 文字列
                            { true, false, false, true, true, false, false, false, false }, // 日付
                            { true, false, false, false, false, true, false, false, false }, // 時間
                            { true, true, false, false, false, false, true, false, false } // フラグ
                            };

                            bool isSupport = supportArray[(int)datatype - 1, formatkbn - 1];

                            if (!isSupport)
                            {
                                var msg = DaMessageService.GetMsg(EnumMessage.E064018);
                                res.SetServiceError(msg);
                                return res;
                            }
                        } 
                    }
                }

                if (!string.IsNullOrEmpty(req.sqlcolumn))
                {
                    var msg = DaEucService.CheckItemSQL(db, req.sqlcolumn!);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        res.SetServiceError(msg);
                        return res;
                    }
                }
                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 特殊項目を取得
        /// </summary>
        private List<ItemTreeNode<ItemVM>> GetSpecialItem(DaDbContext db, SearchNormalTreeRequest req)
        {
            //特殊項目を取得
            var filter = $"{nameof(tm_eutableitemDto.tablealias)} ='SYSTEM' and {nameof(tm_eutableitemDto.daibunrui)} = '特殊項目'";
            //EUCテーブル項目名称マスタ
            var datasourceTableItemDtl = db.tm_eutableitem.SELECT.WHERE.ByFilter(filter).GetDtoList()
                .Where(x => !req.itemids.Contains(x.itemid))
                .ToList();
            //並び順
            datasourceTableItemDtl = datasourceTableItemDtl.OrderBy(e => e.orderseq).ThenBy(e => e.itemid).ToList();
            //一覧項目ツリーリストを取得
            var itemtree = Wraper.GetNormalItemTree(datasourceTableItemDtl);

            return itemtree;
        }
    }

}