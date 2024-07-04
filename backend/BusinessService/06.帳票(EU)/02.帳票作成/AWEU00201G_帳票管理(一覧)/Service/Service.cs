// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票管理(一覧)
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using TSQL;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaSystemParameterManager;
using static BCC.Affect.DataAccess.FunctionVM;

namespace BCC.Affect.Service.AWEU00201G
{
    [DisplayName("帳票管理(一覧)")]
    public class Service : CmServiceBase
    {
        #region 一覧画面

        //検索処理
        private const string PROC_NAME = "sp_aweu00201g_01";

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, db =>
            {
                var res = new InitListResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------

                //帳票グループマスタを取得
                var rptGroupDtl = db.tm_eurptgroup.SELECT.SetSelectItems(nameof(tm_eurptgroupDto.rptgroupid), nameof(tm_eurptgroupDto.rptgroupnm))
                    .ORDER.By(nameof(tm_eurptgroupDto.rptgroupid)).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(業務)
                res.selectorlist1 = DaNameService.GetSelectorList(db, EnumNmKbn.EUC業務区分, Enum名称区分.名称);
                //ドロップダウンリスト(帳票グループ)
                res.selectorlist2 = rptGroupDtl.Select(x => new DaSelectorModel(x.rptgroupid, x.rptgroupnm)).ToList();
                //ドロップダウンリスト(帳票様式)
                res.selectorlist3 = EucConstant.YOSHIKI_BUNRUI;
                //ドロップダウンリスト(様式種別)
                res.selectorlist4 = EucConstant.YOSIKISYUBETU_OPTIONS;

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(一覧画面)")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータを取得
                var param = Converter.GetParameters(req);
                //検索実行
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, param, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //設定総ページ数、総件数
                res.SetPageInfo(pageList.TotalCount, req.pagesize);
                //一覧情報リスト
                res.kekkalist = Wraper.GetSearchVMList(db, pageList.dataTable.Rows);

                //正常返し
                return res;
            });
        }

        #endregion

        #region 詳細画面(共通部分)
        [DisplayName("初期化処理(詳細画面：共通部分)")]
        public InitDetailResponse InitDetail(InitDetailRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new InitDetailResponse();
                if ((req.editkbn == Enum編集区分.新規 && req.kbn == Enum帳票様式.別様式) 
                    || req.editkbn == Enum編集区分.変更)
                {
                    //最小様式ID
                    var minyosikiid = db.tm_euyosiki.SELECT.WHERE.ByFilter("rptid = @rptid", req.rptid)
                                                                .GetMin<String>(nameof(tm_euyosikiDto.yosikiid));
                    //EUC様式詳細マスタ
                    var yosikisyosaiDto = db.tm_euyosikisyosai.SELECT.WHERE.ByKey(req.rptid, minyosikiid, 0).GetDto();
                    if (yosikisyosaiDto != null)
                    {
                        //TODO
                        //様式作成方法
                        res.yosikihouhou = yosikisyosaiDto.yosikihouhou;
                    }

                    //EUC帳票マスタ
                    var dto = db.tm_eurpt.GetDtoByKey(req.rptid);
                    if (res.yosikihouhou == Enum様式作成方法.データソース)
                    {
                        //帳票データソースID
                        res.datasourceid = dto.datasourceid;
                    }
                    else
                    {
                        // プロシージャ名称
                        res.procnm = dto.procnm!;
                        res.sql = dto.sql;
                    }
                }
                else 
                {
                    //様式作成方法
                    res.yosikihouhou = req.yosikihouhou!.Value;
                    if (res.yosikihouhou == Enum様式作成方法.データソース)
                    {
                        //帳票データソースID
                        res.datasourceid = req.datasourceid;
                    }
                    else if (!string.IsNullOrEmpty(req.procnm))
                    {
                        // プロシージャ名称
                        res.procnm = req.procnm;
                        var functionVM = DaEucBasicService.GetFunctionByName(db, req.procnm, EucConstant.EUC_FUNCTION_PREFIX);
                        if (functionVM == null)
                        {
                            throw new Exception($"「{req.procnm}」という名前の関数の取得に失敗しました。");
                        }
                        res.sql = functionVM.src;
                    }
                }

                if (req.editkbn == Enum編集区分.新規)
                {
                    if (req.kbn != Enum帳票様式.サブ様式)
                    {
                        //様式枝番
                        res.yosikieda = 0;
                    }
                    else 
                    { 
                        //様式枝番最大＋１
                        res.yosikieda = db.tm_euyosikisyosai.SELECT.WHERE.ByKey(req.rptid, req.yosikiid!).GetMax<int>(nameof(tm_euyosikisyosaiDto.yosikieda)) + 1;
                    }

                    //追加時にyosikiidを取得する
                    if (req.kbn == Enum帳票様式.別様式)
                    {
                        //様式ID最大＋１
                        var sikiid = db.tm_euyosiki.SELECT.WHERE.ByKey(req.rptid).GetMax<int>(nameof(tm_euyosikiDto.yosikiid)) + 1;
                        res.yosikiid = sikiid.ToString().PadLeft(4, '0');
                    }
                }

                if (res.yosikihouhou == Enum様式作成方法.データソース)
                {
                    //データソース情報
                    var datasourceDto = db.tm_eudatasource.GetDtoByKey(res.datasourceid!);
                    if (datasourceDto != null)
                    {
                        // データソース名称
                        res.datasourcenm = datasourceDto.datasourcenm;
                    }
                }

                //初期化処理ドロップダウンリスト
                SetSelectorList(db, res, req.rptid);
                //プロシージャ提示用リスト
                res.parameterList = GetparameterValues();
                return res;
            });
        }

        #endregion

        #region 帳票設定タブ

        [DisplayName("検索処理(帳票設定タブ)")]
        public SearchReportTabResponse SearchReportTab(YosikiRequestTabBase req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchReportTabResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //EUC帳票マスタを取得
                var dto = db.tm_eurpt.GetDtoByKey(req.rptid);
                //帳票グループマスタを取得
                var rptgroup = db.tm_eurptgroup.GetDtoByKey(dto.rptgroupid);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //データソースID
                if (!string.IsNullOrEmpty(req.datasourceid))
                {
                    //固定条件を取得するフィルター
                    const string filter =
                        $"{nameof(tm_eudatasourcekensakuDto.datasourceid)} = @{nameof(tm_eudatasourcekensakuDto.datasourceid)} " +
                        $"AND {nameof(tm_eudatasourcekensakuDto.jyokenkbn)} = @{nameof(tm_eudatasourcekensakuDto.jyokenkbn)}";

                    //EUCデータソース検索マスタ
                    var dtl = db.tm_eudatasourcekensaku.SELECT
                        .WHERE.ByFilter(filter, req.datasourceid, (int)Enum検索条件区分.固定条件)
                        .ORDER.By(nameof(tm_eudatasourcekensakuDto.jyokenid))
                        .GetDtoList();

                    //固定条件
                    res.jyokenLabellist = dtl.Select(x => new DaSelectorModel(x.jyokenid.ToString(), x.jyokenlabel)).ToList();
                }

                //EUC帳票設定情報
                res.rptDetailParam = new ReportTabInfoVM();
                //帳票設定情報をセット
                res.rptDetailParam = Wraper.GetReportItemInfo(db,dto, rptgroup);
                //選択した固定条件
                res.rptDetailParam.jyokenLabels = GetSeletedFixConditionList(db, req.rptid);
                //更新日時
                res.upddttm = dto.upddttm;
                return res;
            });
        }

        #endregion

        #region 様式設定タブ

        [DisplayName("検索処理(様式設定タブ)")]
        public SearchYosikiTabResponse SearchYosikiTab(YosikiCommonRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchYosikiTabResponse();
                //EUC様式詳細情報
                res.styleDetailParam = new YosikiTabInfoVM();
                if ((req.editkbn == Enum編集区分.新規 && req.kbn == Enum帳票様式.別様式)
                    || req.editkbn == Enum編集区分.変更)
                {
                    //-------------------------------------------------------------
                    //１.データ取得
                    //-------------------------------------------------------------

                    //最小様式ID
                    var minyosikiid = db.tm_euyosiki.SELECT.WHERE.ByFilter("rptid = @rptid", req.rptid)
                                                               .GetMin<String>(nameof(tm_euyosikiDto.yosikiid));

                    //サブの場合、親帳票の様式を検索" OR "帳票の場合、本帳票の様式を調査
                    var yosikiID = minyosikiid;
                    if (req.editkbn == Enum編集区分.変更)
                    {
                        yosikiID = req.yosikiid;
                    }
                    //問い合わせ内容
                    var hanyoDtl2 = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.問い合わせ内容コード);
                    //EUC様式マスタ
                    var yosikiDto = db.tm_euyosiki.GetDtoByKey(req.rptid, yosikiID);
                    if (yosikiDto != null!)
                    {
                        //帳票様式情報をセット
                        Wraper.GetYosikiInfo(res, yosikiDto, hanyoDtl2);
                    }

                    //様式枝番
                    if (req.editkbn == Enum編集区分.変更)
                    {
                        //EUC様式詳細マスタ
                        var yosikisyosaiDto = db.tm_euyosikisyosai.GetDtoByKey(req.rptid, req.yosikiid, req.yosikieda!.Value);
                        if (yosikisyosaiDto != null)
                        {
                            //EUC様式詳細情報をセット
                            Wraper.SetYosikiSyosaiInfo(res, yosikisyosaiDto);
                        }
                    }
                    else 
                    {
                        var yosikisyosaiDto = db.tm_euyosikisyosai.GetDtoByKey(req.rptid, yosikiID, 0);
                        if (yosikisyosaiDto != null)
                        {
                            res.styleDetailParam.distinctflg = CBool(yosikisyosaiDto.distinctflg);               //重複データ排除フラグ
                        }
                    }
                }
                return res;
            });
        }

        #region SQL項目

        [DisplayName("SELECT文の解析(様式設定タブ)")]
        public ParseAndFormatSqlResponse ParseAndFormatSql(ParseAndFormatSqlRequest req)
        {
            var res = new ParseAndFormatSqlResponse();
            using var db = new DaDbContext(req);
            try
            {
                //サービス名とメソッド名を取得する
                req.SetMethodInfo(new StackTrace().GetFrame(0)!.GetMethod()!);
                //前処理
                BeforeAction(db, req);

                //SQL解析
                var selectSqlItem = SqlParseUtil.ParseSelectSql(db, req.sql);
                //SQLフォーマット
                var newSelectStr = $"{nameof(TSQLKeywords.SELECT)}{DaStrPool.C_SPACE}{string.Join(DaStrPool.C_COMMA, selectSqlItem.SelectPartItems.Select(x => x.ToString()))}";
                var formattedSql = CmSqlFormatUtil.Format($"{newSelectStr}{DaStrPool.C_LF}{req.sql[selectSqlItem.SelectPartEnd..]}", isFunction: false);

                //SQL
                res.sql = formattedSql;
                //様式項目リスト
                res.itemlist = Wraper.GetSqlItemList(selectSqlItem.SelectPartItems, req.itemlist);
                //検索条件リスト
                res.conditionlist = Wraper.GetSqlConditionList(selectSqlItem.WherePartItems, req.conditionlist);
            }
            catch (Exception e)
            {
                res.SetServiceError(e.Message);
            }

            //後処理
            AfterAction(db, res);

            return res;
        }

        #endregion

        #region プロシージャの解析

        [DisplayName("プロシージャの解析(様式設定タブ)")]
        public ParseAndFormatProcedureResponse ParseAndFormatProcedure(ParseAndFormatProcedureRequest req)
        {
            return Transction(req, db =>
            {
                //レスポンス
                var res = new ParseAndFormatProcedureResponse();
                var functionName = FunctionParseUtil.CheckAndGetFuctionName(req.sql, check: true, necessaryPrefix: EucConstant.EUC_FUNCTION_PREFIX);

                if (functionName.Equals(req.procedurenm) && req.procedurenm != EucConstant.EUC_FUNCTION_PREFIX)
                {
                    //編集前のプロシージャを削除
                    DaDbUtil.RunSql(db, $"DROP function {req.procedurenm}");
                }

                //プロシージャの解析
                var functionVm = FunctionParseUtil.ParseFunction(db, req.sql, beforeFuncName: req.procedurenm, necessaryPrefix: EucConstant.EUC_FUNCTION_PREFIX);

                if (functionVm != null && functionVm.name.Length > 50)
                {
                    res.SetServiceError(EnumMessage.E001010, "プロシージャ名");
                    return res;
                }

                if (functionVm == null) throw new Exception($"「{req.procedurenm}」という名前の関数の取得に失敗しました。");

                //検索条件リスト
                var conditionparams = RemoveSystemParameter(functionVm.conditionparams);

                //プロシージャ名
                res.procedurenm = functionVm.name;
                //SQL
                res.sql = req.sql;  //CmSqlFormatUtil.Format(req.sql, isFunction: true);  TODO!

                //DBフィールドの説明
                var dicDBName = DaEucCacheService.GetColumnDescDic(db);

                if (req.procedurenm != EucConstant.EUC_FUNCTION_PREFIX)
                {
                    //様式項目リスト
                    var dicReturnItemName = FunctionParseUtil.GetReturnItemName(req.sql);
                    var returnparams = functionVm.returnparams;
                    SetPraName(ref returnparams, dicReturnItemName, dicDBName);
                    res.itemlist = Wraper.GetFunctionItemList(returnparams, req.itemlist);
                }
                else
                {
                    res.itemlist = new List<ReportItemDetailVM>();
                }

                //検索条件リスト
                var dicName = FunctionParseUtil.GetParamItemName(req.sql);
                SetPraName(ref conditionparams, dicName, dicDBName);
                res.conditionlist = Wraper.GetFunctionConditionList(conditionparams, req.conditionlist, db);

                return res;
            });
        }

        /// <summary>
        /// プロシージャパラメータ名称をセット(日本語に変換)
        /// </summary>
        private void SetPraName(ref List<Param> proparams, Dictionary<string, string> dicName, Dictionary<string,string> dicDBName)
        {
            foreach(var param in proparams)
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

        #endregion

        #endregion

        #region 項目定義タブ

        [DisplayName("検索処理(項目定義タブ)")]
        public InitItemsTabResponse SearchItemsTab(YosikiCommonRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new InitItemsTabResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //EUC帳票項目マスタ
                var rptitemDtl = db.tm_eurptitem.SELECT.WHERE.ByKey(req.rptid, req.yosikiid).GetDtoList()
                    .OrderBy(x => x.orderseq).ToList();

                if (rptitemDtl == null || rptitemDtl.Count == 0)
                {
                    res.reportitemlist = new List<ReportItemDetailVM>();
                    return res;
                }
               
                //項目大分類
                var itemId2DaiBunruiDict = new Dictionary<string, string>();

                //EUC様式詳細マスタ
                var dto = db.tm_euyosikisyosai.GetDtoByKey(req.rptid, req.yosikiid, req.yosikieda ?? 0);
                //様式種別詳細がクロス集計の場合
                if (dto != null && dto.yosikikbn == Enum様式種別詳細.クロス集計)
                {
                    //データソース
                    if (req.yosikihouhou == Enum様式作成方法.データソース)
                    {
                        var filter = $"{nameof(tm_eutableitemDto.itemid)} = ANY(@{nameof(tm_eutableitemDto.itemid)})";
                        //様式項目IDリスト
                        var itemIdSet = rptitemDtl.Select(x => x.yosikiitemid).ToHashSet();
                        //EUCテーブル項目マスタ
                        itemId2DaiBunruiDict = db.tm_eutableitem.SELECT.WHERE.ByFilter(filter, itemIdSet.ToArray() as object).GetDtoList().ToDictionary(x => x.itemid, x => x.daibunrui);
                    }
                    else
                    {
                        var procnm = req.procnm;
                        var sql = req.sql;

                        if (!string.IsNullOrEmpty(procnm) && !string.IsNullOrEmpty(sql))
                        {
                            var functionVm = DaEucBasicService.GetFunctionVMByName(db, procnm, necessaryPrefix: EucConstant.EUC_FUNCTION_PREFIX);
                            if (functionVm == null) throw new Exception($"「{procnm}」という名前の関数の取得に失敗しました。");
                            //検索条件リスト
                            var returnparams = RemoveSystemParameter(functionVm.returnparams);

                            var subList = returnparams.Where(e => (e.DataType == EnumDataType.整数 || e.DataType == EnumDataType.小数)).ToList();
                            if (subList.Count > 0)
                            {
                                itemId2DaiBunruiDict = subList.ToDictionary(e => e.Id, e => "数値項目");
                            }
                            subList = returnparams.Where(e => !(e.DataType == EnumDataType.整数 || e.DataType == EnumDataType.小数)).ToList();
                            if (subList.Count > 0)
                            {
                                var dic = subList.ToDictionary(e => e.Id, e => "文字項目");
                                itemId2DaiBunruiDict = itemId2DaiBunruiDict.Concat(dic).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                            }
                        }
                    }
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                res.reportitemlist = Wraper.GetReportItemVMList(rptitemDtl, itemId2DaiBunruiDict);

                //正常返し
                return res;
            });
        }

        [DisplayName("データタイプのチェック)")]
        public DaResponseBase CheckDataType(CheckDataTypeRequestBase req)
        {
            return Nolock(req, db =>
            {
                var res = new DaResponseBase();
                //文字列のデータをString型に変換する
                if (req.datatype != null && req.controlkbn != null)
                {
                    // サポートされていない組み合わせ
                    if (DaEucService.IsInvalidCombination(req.datatype!.Value, req.controlkbn!.Value))
                    {
                        var errorMeg = DaMessageService.GetMsg(EnumMessage.E003008, "データタイプ", "コントロール");
                        res.SetServiceError(errorMeg);
                        return res;
                    }
                    if (!string.IsNullOrEmpty(req.syokiti))
                    {
                        // さまざまなデータ型の有効性を確認し、区別を制御する
                        if (!DaEucService.IsValidCombination(req.datatype!.Value, req.controlkbn!.Value, req.syokiti))
                        {
                            var errorMeg = DaMessageService.GetMsg(EnumMessage.ITEM_NOTEQUAL_ERROR, $"初期値{req.syokiti}はデータタイプ");
                            res.SetServiceError(errorMeg);
                            return res;
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

        #endregion

        #region 検索条件タブ

        [DisplayName("初期化処理(検索条件タブ)")]
        public InitConditionTabResponse InitConditionTab(DaRequestBase req)
        {
            return Nolock(req, db =>
            {
                var res = new InitConditionTabResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //EUCテーブル項目名称マスタを取得
                var itemNameDtl = DaEucBasicService.GetTableItemNameDtl(db);
                var sql = AWEU00105D.Service.GetMasterSql(itemNameDtl);
                var rows = DaDbUtil.GetDataTable(db, sql).Rows;

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //DataTypeのドロップダウンリスト
                res.selectorlist1 = EucConstant.DATA_TYPE_OPTIONS;
                //コントロールドのロップダウンリスト
                res.selectorlist2 = EucConstant.CONTROL_OPTIONS;
                //マスタリスト
                res.masterlist = AWEU00105D.Wraper.GetMasterVMList(db, itemNameDtl, rows);
                //正常返し
                return res;
            });
        }
        [DisplayName("初期化処理(検索条件以外タブ)")]
        public InitSpecialConditionsResponse InitSpecialConditions(InitSpecialConditionsRequest req)
        {
            return Nolock(req, _ =>
            {
                var res = new InitSpecialConditionsResponse();
                DaSpecialItemManager mngr = new DaSpecialItemManager();
                var labels = mngr.GetConditionNameList(req.isDataSource);
                var conditions = new List<SearchConditionVM>();
                //TODO
                res.specialConditions = conditions;
                res.labels = labels;
                return res;
            });
        }

        [DisplayName("検索処理(検索条件タブ)")]
        public SearchConditionTabResponse SearchConditionTab(YosikiCommonRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchConditionTabResponse();

                //データソースID
                if (req.yosikihouhou == Enum様式作成方法.データソース)
                {
                    //普通全て検索条件を取得するフィルター
                    const string filter =
                        $"{nameof(tm_eudatasourcekensakuDto.datasourceid)} = @{nameof(tm_eudatasourcekensakuDto.datasourceid)} " +
                        $"AND {nameof(tm_eudatasourcekensakuDto.jyokenkbn)} = @{nameof(tm_eudatasourcekensakuDto.jyokenkbn)}";

                    //EUCデータソース検索マスタ
                    var dtl = db.tm_eudatasourcekensaku.SELECT
                        .WHERE.ByFilter(filter, req.datasourceid!, (int)Enum検索条件区分.通常条件)
                        .ORDER.By(nameof(tm_eudatasourcekensakuDto.jyokenid))
                        .GetDtoList();

                    //普通全て検索条件リスト
                    res.itemlist = Wraper.GetDataSourseConditionVmList(db, dtl);
                }
                else
                {
                    var procnm = req.procnm;
                    var sql= req.sql;

                    if (!string.IsNullOrEmpty(procnm) && !string.IsNullOrEmpty(sql))
                    {
                        var functionVm = DaEucBasicService.GetFunctionVMByName(db, procnm, necessaryPrefix: EucConstant.EUC_FUNCTION_PREFIX);
                        if (functionVm == null) throw new Exception($"「{procnm}」という名前の関数の取得に失敗しました。");
                        //検索条件リスト
                        var conditionparams = RemoveSystemParameter(functionVm.conditionparams);

                        //フィールドの説明（コメント）を取得する
                        var dicName = FunctionParseUtil.GetParamItemName(sql);
                        var dicDBName = DaEucCacheService.GetColumnDescDic(db);

                        SetPraName(ref conditionparams, dicName, dicDBName);

                        res.itemlist = Wraper.GetFunctionConditionList(conditionparams, new List<SearchConditionVM>(), db);
                    } 
                }

                //検索条件の選択
                const string kensakufilter =
                    $"{nameof(tm_eurptkensakuDto.rptid)} = @{nameof(tm_eurptkensakuDto.rptid)} " +
                    $"AND {nameof(tm_eurptkensakuDto.jyokenkbn)} = @{nameof(tm_eurptkensakuDto.jyokenkbn)}";

                //EUC帳票検索マスタ
                var kensakuList = db.tm_eurptkensaku.SELECT.WHERE.ByFilter(kensakufilter, req.rptid, EnumToStr(Enum検索条件区分.通常条件)).ORDER.By(nameof(tm_eurptkensakuDto.orderseq)).GetDtoList();

                //検索条件区分リスト
                var normalDtl = kensakuList.Where(x =>  x.orderseq < 1000).ToList();
                // データソース 検索条件
                var selJokenList = new List<SelectedSearchConditionVM>();
                if (normalDtl != null && normalDtl.Count >0)
                {
                    if (req.yosikihouhou != Enum様式作成方法.データソース)
                    {
                        //プロシージャの検索条件の選択
                        res.selectedProcedjoklist = Wraper.GetReportCoditionVmList(db, normalDtl);
                    }
                    
                    //データ読み取り
                    selJokenList = normalDtl.Select(x => new SelectedSearchConditionVM
                    {
                        jyokenid = x.jyokenid!.Value,
                        datasourceid = x.datasourceid ?? string.Empty,
                        hissuflg = x.hissuflg ?? false,
                        orderseq = x.orderseq ?? 0
                    }).ToList();
                    
                }
                //通常条件の選択したリスト
                res.selectedjokenlist = selJokenList;

                //追加の条件
                res.conditionAddlist = new List<SearchConditionVM>();
                if (normalDtl != null)
                {
                    res.conditionAddlist = Wraper.GetReportCoditionVmList(db, normalDtl.Where(e => string.IsNullOrEmpty(e.datasourceid) ));
                }

                //検索条件以外の選択
                res.selectedjokenOtherlist = Wraper.GetReportCoditionVmList(db, kensakuList.Where(x => x.orderseq >= 1000).ToList()); 
                return res;
            });
        }

        #endregion

        #region 条件追加
        [DisplayName("検索処理(新規条件追加)")]
        public SearchJokenResponse SearchJokenDetail(SearchJokenDetailRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchJokenResponse();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //EUC帳票検索マスタ

                if (req.controlkbn != null && req.controlkbn == (int)Enumコントロール.選択)
                {
                    //検索条件情報を取得する
                    var selectList = Wraper.GetReportAddJokenVm(db, req);
                    res.selectlist = selectList;
                    res.masterCount = selectList.Count;
                }
                if (req.controlkbn != null && req.controlkbn  == (int)Enumコントロール.年度 && !string.IsNullOrEmpty(req.nendohanikbn))
                {
                    (res.nendo, res.nendomax) = CommonUtil.GetNendoAndNendomax(db, req.nendohanikbn); //年度範囲区分
                }
                //正常返し
                return res;
            });
        }


        [DisplayName("検索処理(条件追加)")]
        public SearchConditionDetailResponse SearchConditionDetail(SearchConditionDetailRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchConditionDetailResponse();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //EUC帳票検索マスタ
                var dto = db.tm_eurptkensaku.GetDtoByKey(req.jyokenseq);

                if (dto != null)
                {
                    //検索条件情報を取得する
                    res.eurptkensaku = Wraper.GetReportCoditionVm(db, dto);
                }

                //正常返し
                return res;
            });
        }

        #endregion

        #region Excelマッピングタブ

        [DisplayName("初期化処理(特殊項目)(Excelマッピングタブ)")]
        public InitSpecialItemsResponse InitSpecialItems(InitSpecialItemsRequest req)
        {
            return Nolock(req, _ =>
            {
                var res = new InitSpecialItemsResponse();
                //todo 特殊項目リスト
                //res.specialitemlist = ArGlobal.SpecialItemList;
                DaSpecialItemManager mngr = new DaSpecialItemManager();
                res.specialitemlist = mngr.GetNameList(req.isPageReport, req.IsCross, req.naigaikbn, req.isDataSource);
                return res;
            });
        }

        [DisplayName("検索処理(Excelマッピングタブ)")]
        public SearchExcelMappingTabResponse SearchExcelMappingTab(SearchExcelMappingTabRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchExcelMappingTabResponse();
                //様式種別詳細
                var yosikikbn = req.yosikikbn;
                //明細有無
                var meisaiflg = req.meisaiflg;
                //行（列）固定区分
                Enum行列固定? meisaikoteikbn = Enum.TryParse<Enum行列固定>(req.meisaikoteikbn, out var k1) ? k1 : null;

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                // 新しいものを追加するかどうかを決定します。 新しいテンプレートを追加するには、メイン アカウントからテンプレートを見つけます。
                if (req.excelStatus)
                {
                    var sql = $@"
                                SELECT A.rptid  AS rptid, 
                                MIN(A.yosikiid) AS minYosikiid
                                FROM tm_euyosiki A where A.rptid = '{req.rptid}'
                                GROUP BY A.rptid;
                                ".Trim();
                    var rptDtl = DaDbUtil.GetDataTable(db, sql);
                    // 結果にデータが含まれているかどうかを確認する
                    if (rptDtl != null && rptDtl.Rows.Count > 0)
                    {
                        // minYosikiid の値を取得する
                        req.yosikiid = CStr(rptDtl.Rows[0]["minYosikiid"]);
                    }
                }

                //EUC様式マスタ
                tm_euyosikiDto? yosikiDto = db.tm_euyosiki.GetDtoByKey(req.rptid, req.yosikiid);

                //EUC様式詳細マスタ
                tm_euyosikisyosaiDto? yosikisyosaiDto = null;
                if (req.yosikieda != null && req.yosikieda >= 0)
                {
                    //EUC様式詳細マスタ
                    yosikisyosaiDto = db.tm_euyosikisyosai.GetDtoByKey(req.rptid, req.yosikiid, req.yosikieda.Value);
                }
                if (!req.excelStatus && yosikisyosaiDto != null)
                {
                    //様式種別詳細
                    yosikikbn = yosikisyosaiDto.yosikikbn;
                    //明細有無
                    meisaiflg = yosikisyosaiDto.meisaiflg;
                    //行（列）固定区分
                    meisaikoteikbn = Enum.TryParse<Enum行列固定>(yosikisyosaiDto.meisaikoteikbn, out var k2) ? k2 : null;
                }
                res.excelmappingdata = new ExcelMappingVM();

                // AIplus 2024-06-24 SHOU ADD Start 
                //新規作成　かつ　カスタマイズの場合
                if (req.excelStatus && (
                    Enum様式種別詳細.アドレスシール.Equals(yosikikbn)
                    || Enum様式種別詳細.はがき.Equals(yosikikbn)
                    || Enum様式種別詳細.バーコードシール.Equals(yosikikbn)
                    || Enum様式種別詳細.宛名台帳.Equals(yosikikbn)
                ))
                {
                    // 固定のEUC様式詳細マスタを作成
                    yosikisyosaiDto = makeTmeuyosikisyosaiDto(yosikikbn, db);
                    // 固定のEUC様式マスタを作成
                    yosikiDto = makeTmeuyosikiDto(yosikikbn, yosikisyosaiDto);

                    //テンプレートファイル名
                    res.excelmappingdata.templatefilenm = yosikiDto?.templatefilenm ?? EucConstant.DEFAULT_TEMPLATE_FILE_NM;
                    //テンプレートファイル
                    res.excelmappingdata.templatefiledata = yosikiDto?.templatefiledata ?? Array.Empty<byte>();
                    //テンプレート終了行
                    res.excelmappingdata.endrow = yosikiDto?.endrow is null or < 1 ? CommonUtil.GetExcelEndRow(yosikiDto?.templatefiledata) : yosikiDto.endrow.Value;
                    //テンプレート終了列
                    res.excelmappingdata.endcol = yosikiDto?.endcol is null or < 1 ? CommonUtil.GetExcelEndCol(yosikiDto?.templatefiledata) : yosikiDto.endcol.Value;
                    //ページサイズ
                    res.excelmappingdata.pagesize = Enum.TryParse<Enumページサイズ>(yosikiDto?.pagesize?.ToString(), out var pageSize) ? pageSize : Enumページサイズ.A4;
                    //出力方向
                    res.excelmappingdata.landscape = yosikiDto?.landscape ?? false;
                    //行/列明細

                }
                // AIplus 2024-06-24 SHOU ADD End 

                //新しいルールはテンプレートを継承しません
                if (!req.excelStatus && yosikiDto != null)
                {
                    //テンプレートファイル名
                    res.excelmappingdata.templatefilenm = yosikiDto?.templatefilenm ?? EucConstant.DEFAULT_TEMPLATE_FILE_NM;
                    //テンプレートファイル
                    res.excelmappingdata.templatefiledata = yosikiDto?.templatefiledata ?? Array.Empty<byte>();
                    //テンプレート終了行
                    res.excelmappingdata.endrow = yosikiDto?.endrow is null or < 1 ? CommonUtil.GetExcelEndRow(yosikiDto?.templatefiledata) : yosikiDto.endrow.Value;
                    //テンプレート終了列
                    res.excelmappingdata.endcol = yosikiDto?.endcol is null or < 1 ? CommonUtil.GetExcelEndCol(yosikiDto?.templatefiledata) : yosikiDto.endcol.Value;
                    //ページサイズ
                    res.excelmappingdata.pagesize = Enum.TryParse<Enumページサイズ>(yosikiDto?.pagesize?.ToString(), out var pageSize) ? pageSize : Enumページサイズ.A4;
                    //出力方向
                    res.excelmappingdata.landscape = yosikiDto?.landscape ?? false;
                    //行/列明細
                }

                FillRowAndColDetail(yosikisyosaiDto, yosikikbn, meisaiflg, meisaikoteikbn, res);

                //正常返し
                return res;
            });
        }


        [DisplayName("エクセルテンプレートファイルのダウンロード処理")]
        public CmDownloadResponseBase DownloadExcelTemplate(DownloadExcelTemplateRequest req)
        {
            var excelFile = req.files[0];
            //セル値入力後のエクセルの取得
            var realExcelFileData = Converter.GetRealExcelFileData(excelFile.filedata, req.celldatas);
            //単一ファイルのダウンロード応答を取得
            return CmDownloadService.GetDownloadResponse(new DaFileModel(excelFile.filenm, excelFile.filetype, realExcelFileData));
        }

        #endregion

        #region 登録・保存更新処理

        [DisplayName("保存処理(画面全件情報)")]
        public DaResponseBase SaveProject(SaveProjectRequest req)
        {
            return Transction(req, db =>
            {
                //レスポンス
                var res = new DaResponseBase();

                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //項目定タブ情報のsqlcolumnのチェック
                if (req.checkflg)
                {
                    var msg = string.Empty;
                    if (req.definitionValue.Count > 0)
                    {
                        //項目定タブ情報のsqlcolumnを取得
                        var sqlcolumns = req.definitionValue.Where(e => !string.IsNullOrWhiteSpace(e.sqlcolumn)) 
                                .Select(e => e.sqlcolumn) .ToList();
                        if (sqlcolumns.Count > 0)
                        {
                            msg = Converter.CheckSqlcolumn(db, sqlcolumns);
                            if (!string.IsNullOrEmpty(msg))
                            {
                                res.SetServiceError(msg);
                                return res;
                            }
                        }    
                    }

                    //検索条件タブ情報のsqlcolumnのチェック
                    if (req.rptConditionList.Count > 0)
                    {
                        //検索条件タブ情報のsqlcolumnを取得
                        var sqlcolumns = req.rptConditionList.Where(e => !string.IsNullOrWhiteSpace(e.sql))
                                .Select(e => e.sql).ToList();
                        if (sqlcolumns.Count >0)
                        {
                            msg = Converter.CheckSqlcolumn(db, sqlcolumns);
                            if (!string.IsNullOrEmpty(msg))
                            {
                                res.SetServiceError(msg);
                                return res;
                            }
                        }
                    }
                    //経年表の場合、項目定義で改ページと年度フラグは必要
                    if (req.yosikisyubetu == Enum様式種別.集計表 && req.yosikikbn == Enum様式種別詳細.単純集計表)
                    {
                        List<ReportItemDetailVM> tanjunshukeiItemList = req.definitionValue.Where(e => e.crosskbn == Enum集計区分.集計).ToList();
                        var errorMsg = Converter.CheckTanjunshukeiItemList(tanjunshukeiItemList);
                        if (!string.IsNullOrEmpty(errorMsg))
                        {
                            res.SetServiceError(errorMsg);
                            return res;
                        }
                    }
                    //経年表の場合、項目定義で改ページと年度フラグは必要
                    if (req.yosikisyubetu == Enum様式種別.経年表 && req.yosikikbn == Enum様式種別詳細.経年表)
                    {
                        List<ReportItemDetailVM> kaipageflgItemList = req.definitionValue.Where(e => e.kaipageflg == true).ToList();
                        List<ReportItemDetailVM> headerflgItemList = req.definitionValue.Where(e => e.headerflg == true).ToList();
                        var errorMsg = Converter.CheckNendoReportItem(kaipageflgItemList, headerflgItemList);
                        if (!string.IsNullOrEmpty(errorMsg))
                        {
                            res.SetServiceError(errorMsg);
                            return res;
                        }
                    }

                    //項目定義にはメインテーブルのデータが必要です
                    if (Enum様式作成方法.データソース == req.yosikihouhou)
                    {
                        var reportItem = new List<ReportItemDetailVM>();
                        if (Enum様式種別詳細.クロス集計 == req.styleDetailParam.yosikikbn)
                        {
                            var defin = req.definitionValue.Where(e => e.crosskbn == Enum集計区分.集計).FirstOrDefault();
                            if (defin != null)
                            {
                                reportItem.Add(defin);
                            }
                        }
                        else
                        {
                            reportItem.AddRange(req.definitionValue);
                        }
                        var mainTableMeg = GetDataSourceMaintable(db, req.datasourceid, reportItem);
                        if (!string.IsNullOrEmpty(mainTableMeg))
                        {
                            res.SetServiceError(mainTableMeg);
                            return res;
                        }
                    }

                    if (!string.IsNullOrEmpty(req.styleDetailParam.updatesql))
                    {
                        //帳票様式のUpdateSqlを取得
                        var errorMsg = Converter.CheckUpdateSql(db, req.styleDetailParam.updatesql, req.rptConditionList);
                        if (!string.IsNullOrEmpty(errorMsg))
                        {
                            res.SetServiceError(errorMsg);
                            return res;
                        }
                    }
                    //正常返し
                    return res;
                }
                
                //帳票名チェック
                if (!IsValidReportFileName(req.rptnm))
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E003006, "帳票名");
                    res.SetServiceError(msg);
                    return res;
                }

                // 更新の場合 様式名チェック
                if (req.updflag)
                {
                    var stylefilter = $" {nameof(tm_euyosikisyosaiDto.yosikinm)} = @{nameof(tm_euyosikisyosaiDto.yosikinm)}";
                    var dto = db.tm_euyosikisyosai.SELECT.WHERE.ByFilter(stylefilter, req.yosikinm).GetDto();
                    if (dto != null && dto.rptid == req.rptid && dto.yosikiid != req.yosikiid)
                    {
                        var msg = DaMessageService.GetMsg(EnumMessage.E002003, "様式名");
                        res.SetServiceError(msg);
                        return res;
                    } 
                }

                // 新規様式ID存在チェックTODOi
                if (!req.updflag && req.kbn != Enum帳票様式.サブ様式)
                {
                    var euyosikifilter =
                    $"{nameof(tm_euyosikiDto.rptid)} = @{nameof(tm_euyosikiDto.rptid)} " +
                    $"and {nameof(tm_euyosikiDto.yosikiid)} = @{nameof(tm_euyosikiDto.yosikiid)} ";

                    if (db.tm_euyosiki.SELECT.WHERE.ByFilter(euyosikifilter, req.rptid, req.yosikiid).Exists())
                    {
                        var msg = DaMessageService.GetMsg(EnumMessage.E002003, "様式ID");
                        res.SetServiceError(msg);
                        return res;
                    }
                }

                // 新規様式枝番ID存在チェック
                if (!req.updflag)
                {
                    //EUC帳票マスタ
                    var dto = db.tm_eurpt.GetDtoByKey(req.rptid);
                    //帳票IDの存在チェック
                    if (req.kbn == Enum帳票様式.帳票 && dto != null )
                    {
                        var msg = DaMessageService.GetMsg(EnumMessage.E002003, "帳票ID");
                        res.SetServiceError(msg);
                        return res;
                    }
                    if (req.kbn == Enum帳票様式.別様式 && dto == null)
                    {
                        throw new AiExclusiveException();
                    }

                    var yosikiidfilter =
                    $"{nameof(tm_euyosikisyosaiDto.rptid)} = @{nameof(tm_euyosikisyosaiDto.rptid)} " +
                    $"and {nameof(tm_euyosikisyosaiDto.yosikiid)} = @{nameof(tm_euyosikisyosaiDto.yosikiid)} " +
                    $"and {nameof(tm_euyosikisyosaiDto.yosikieda)} = @{nameof(tm_euyosikisyosaiDto.yosikieda)} ";

                    if (db.tm_euyosikisyosai.SELECT.WHERE.ByFilter(yosikiidfilter, req.rptid, req.yosikiid, req.yosikieda).Exists())
                    {
                        var msg = DaMessageService.GetMsg(EnumMessage.E002003, "様式枝番ID");
                        res.SetServiceError(msg);
                        return res;
                    } 
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                var eurptDto = new tm_eurptDto();
                var euyosikiDto = new tm_euyosikiDto();
                var yosikisyosaiDto = new tm_euyosikisyosaiDto();
                var yosiki_id = db.tm_euyosiki.SELECT.WHERE.ByFilter("rptid = @rptid", req.rptid).GetMin<String>(nameof(tm_euyosikiDto.yosikiid));
                var yosikiSubID = req.kbn == Enum帳票様式.サブ様式 ? yosiki_id : req.yosikiid;
                //更新排他チェック
                if (req.updflag)
                {
                    //EUC様式詳細マスタ
                    yosikisyosaiDto = db.tm_euyosikisyosai.SELECT.WHERE.ByKey(req.rptid, req.yosikiid, req.yosikieda).GetDto();
                    if (yosikisyosaiDto == null || yosikisyosaiDto.upddttm != req.styleDetailParam.yosikisyosaiUpddttm)
                    {
                        throw new AiExclusiveException();
                    }

                    //更新前情報取得
                    //EUC様式マスタ
                    euyosikiDto = db.tm_euyosiki.GetDtoByKey(req.rptid, yosikiSubID);
                    if (euyosikiDto == null || euyosikiDto.upddttm != req.styleDetailParam.yosikiUpddttm)
                    {
                        throw new AiExclusiveException();
                    }

                    if (req.kbn == Enum帳票様式.帳票)
                    {
                        //EUC帳票マスタ
                        eurptDto = db.tm_eurpt.GetDtoByKey(req.rptid);
                        //TODOi
                        if (eurptDto == null || eurptDto.upddttm != req.upddttm)
                        {
                            throw new AiExclusiveException();
                        }
                        //帳票グループID
                        eurptDto.rptgroupid = req.rptDetailParam.rptgroupid;
                    }
                }
                else
                {
                    //並び順
                    euyosikiDto.orderseq = db.tm_euyosiki.SELECT.WHERE.ByFilter("rptid = @rptid", req.rptid).GetMax<int>(nameof(tm_euyosikiDto.orderseq)) + 1;
                }

                //-------------------------------------------------------------
                //３．EUC帳票マスタ[tm_eurpt]登録・更新処理
                //-------------------------------------------------------------
                //帳票情報を取得
                eurptDto = Converter.GetReportDto(eurptDto, req);
                
                //帳票様式を取得
                euyosikiDto = Converter.GetReportYosikiDto(euyosikiDto, req);
                //帳票様式詳細を取得
                yosikisyosaiDto = Converter.GetReportSyosaiDto(yosikisyosaiDto, req);

                //データベース登録・更新
                if (!req.updflag)
                {
                    //int subNumber = db.tm_euyosikisyosai.SELECT.WHERE.ByFilter("rptid = @rptid", req.rptid).GetMax<int>(nameof(tm_euyosikisyosaiDto.yosikieda)) + 1;
                    //様式枝番
                    yosikisyosaiDto.yosikieda = req.yosikieda;

                    //更新日時
                    var dttm = DateTime.Now;
                    if (req.kbn == Enum帳票様式.別様式 || req.kbn == Enum帳票様式.帳票)
                    {
                        //更新日時
                        euyosikiDto.upddttm = dttm;
                        //EUC様式マスタを登録
                        db.tm_euyosiki.INSERT.Execute(euyosikiDto);
                        yosikisyosaiDto.yosikieda = 0;
                    }

                    //Enum帳票様式.サブ様式
                    //更新日時
                    yosikisyosaiDto.upddttm = dttm;
                    //EUC様式詳細マスタを登録
                    db.tm_euyosikisyosai.INSERT.Execute(yosikisyosaiDto);

                    if (req.kbn == Enum帳票様式.帳票)
                    {
                        //EUC帳票マスタを登録
                        db.tm_eurpt.INSERT.Execute(eurptDto);
                    }
                }
                else
                {
                    //EUC様式マスタを更新
                    db.tm_euyosiki.UPDATE.WHERE.ByKey(euyosikiDto.rptid, yosikiSubID).Execute(euyosikiDto);
                    //EUC様式詳細マスタを更新
                    db.tm_euyosikisyosai.UPDATE.WHERE.ByKey(yosikisyosaiDto.rptid, yosikisyosaiDto.yosikiid, yosikisyosaiDto.yosikieda).Execute(yosikisyosaiDto);
                    //EUC帳票マスタを更新
                    db.tm_eurpt.UPDATE.WHERE.ByKey(eurptDto.rptid).Execute(eurptDto);
                }

                //-------------------------------------------------------------
                //4．EUC帳票項目マスタ[tm_eureportitem]登録・更新処理
                //-------------------------------------------------------------
                // var yosiki = req.updflag ? req.yosikieda : yosikisyosaiDto.yosikieda;
                //項目リストを取得取得   // 様式項目ID未知
                var groupTableItemDtl = db.tm_eurptitem.SELECT.WHERE.ByKey(req.rptid, req.yosikiid).GetDtoList();
                //更新対象
                var rptItemDtl = Converter.GetReportItemDtl(req.definitionValue, req, groupTableItemDtl);
                //EUC帳票項目マスタを削除
                db.tm_eurptitem.DELETE.WHERE.ByKey(eurptDto.rptid, req.yosikiid).Execute();
                //EUC帳票項目マスタを登録
                db.tm_eurptitem.INSERT.Execute(rptItemDtl);

                //-------------------------------------------------------------
                //5．EUC帳票検索条件マスタ[tm_eurptjyoken]登録・更新処理
                //-------------------------------------------------------------
                var filer = $"{nameof(tm_eurptkensakuDto.rptid)} = @{nameof(tm_eurptkensakuDto.rptid)} ";
                //EUC帳票検索条件マスタを削除
                db.tm_eurptkensaku.DELETE.WHERE.ByFilter(filer, req.rptid).Execute();
                //固定条件
                if (req.rptDetailParam.jyokenLabels.Count != 0)
                {
                    var jyokens = req.rptDetailParam.jyokenLabels.Select(x => new object[] { x.datasourceid, x.jyokenid }).ToList();
                    //EUCデータソース検索マスタから固定条件情報を取得する
                    var jyokenListdDtl = db.tm_eudatasourcekensaku.SELECT.WHERE.ByKeyList(jyokens).GetDtoList();
                    //データソースの固定条件リストを取得
                    var styleDtl = Converter.GetDataSourseCoditionDtl(jyokenListdDtl, req.rptid);
                    //EUC帳票検索条件マスタを登録
                    db.tm_eurptkensaku.INSERT.Execute(styleDtl);
                }

                //全て条件　帳票の検索条件リストを取得
                var dtl = Converter.GeReportCoditionDtl(req.rptConditionList, req.rptid, req.styleDetailParam.yosikihouhou);

                //EUC帳票検索条件マスタを登録
                db.tm_eurptkensaku.INSERT.Execute(dtl);

                //帳票項目に削除ありの場合
                if (rptItemDtl.Count < groupTableItemDtl.Count)
                {
                    //帳票設定関連テーブルを削除する
                    DelKanrenTable(db, req, groupTableItemDtl, rptItemDtl);
                }

                //戻る
                return res;
            });
        }

        /// <summary>
        /// 帳票設定関連テーブルを削除する
        /// </summary>
        private void DelKanrenTable(DaDbContext db, SaveProjectRequest req, List<tm_eurptitemDto> groupTableItemDtl, List<tm_eurptitemDto> rptItemDtl)
        {
            //削除した帳票項目リスト
            var delItemList = groupTableItemDtl.Where(x => !rptItemDtl.Any(y => y.yosikiitemid == x.yosikiitemid))
                              .Select(e => $"{e.yosikiitemid}")
                              .ToList();
            string delItems = $"'{string.Join("','", delItemList)}'";
            //検索SQL
            var sqlMain = $"{nameof(tm_eurptitemDto.rptid)} = '{req.rptid}' " +
                        $"AND {nameof(tm_eurptitemDto.yosikiid)} = '{req.yosikiid}' ";

            //CSV出力パターンテーブルを取得
            var oldDtlCsv = db.tt_eucsv.SELECT.WHERE.ByFilter(sqlMain).GetDtoList();
            if (oldDtlCsv != null && oldDtlCsv.Count > 0)
            {
                //CSV出力パターンサブテーブルを取得
                var oldDtlCsvSub = db.tt_eucsv_sub.SELECT.WHERE.ByFilter(sqlMain).GetDtoList();
                //削除SQL
                var sqlDel = $"{sqlMain} AND {nameof(tt_eucsv_subDto.reportitemid)} = ANY(ARRAY[{delItems}])";
                //CSV出力パターンサブテーブルを削除
                db.tt_eucsv_sub.DELETE.WHERE.ByFilter(sqlDel).Execute();

                //削除する出力パターン番号
                var delPtnnoList = oldDtlCsvSub.GroupBy(x => x.outputptnno).Where(g => g.All(x => delItemList.Contains(x.reportitemid)))
                                    .Select(g => g.Key).Distinct().ToList();
                if (delPtnnoList.Count > 0)
                {
                    //削除SQL
                    sqlDel = $"{sqlMain} AND {nameof(tt_eucsvDto.outputptnno)} = ANY(ARRAY[{string.Join(",", delPtnnoList)}])";
                    //CSV出力パターンテーブルを削除
                    db.tt_eucsv.DELETE.WHERE.ByFilter(sqlDel).Execute();
                }
            }

            //出力順パターンテーブルを取得
            var oldDtlSort = db.tt_eusort_sub.SELECT.WHERE.ByFilter(sqlMain).GetDtoList();
            if (oldDtlSort != null && oldDtlSort.Count > 0)
            {
                //出力順パターンサブテーブルを取得
                var oldDtlSortSub = db.tt_eusort_sub.SELECT.WHERE.ByFilter(sqlMain).GetDtoList();
                //削除SQL
                var sqlDel = $"{sqlMain} AND {nameof(tt_eusort_subDto.reportitemid)} = ANY(ARRAY[{delItems}])";
                //出力順パターンサブテーブルを削除
                db.tt_eusort_sub.DELETE.WHERE.ByFilter(sqlDel).Execute();

                //削除する出力パターン番号
                var delPtnnoList = oldDtlSortSub.GroupBy(x => x.sortptnno).Where(g => g.All(x => delItemList.Contains(x.reportitemid)))
                                    .Select(g => g.Key).Distinct().ToList();
                if (delPtnnoList.Count > 0)
                {
                    //削除SQL
                    sqlDel = $"{sqlMain} AND {nameof(tt_eusortDto.sortptnno)} = ANY(ARRAY[{string.Join(",", delPtnnoList)}])";
                    //出力順パターンテーブルを削除
                    db.tt_eusort.DELETE.WHERE.ByFilter(sqlDel).Execute();
                }
            }
        }

        #endregion

        #region 削除処理

        [DisplayName("削除処理")]
        public DaResponseBase Delete(YosikiRequestTabBase req)
        {
            return Transction(req, db =>
            {
                var res = new DaResponseBase();
                //EUC帳票項目マスタ
                var dtoOld = db.tm_eurptitem.SELECT.WHERE.ByKey(req.rptid, req.yosikiid, req.yosikieda ?? -1).GetDto();
                //排他チェック
                if (dtoOld == null)
                {
                    throw new AiExclusiveException();
                }
                // 様式詳細マスタを削除
                db.tm_euyosikisyosai.DELETE.WHERE.ByKey(req.rptid, req.yosikiid, req.yosikieda ?? -1).Execute();
                //EUC帳票項目マスタを削除
                db.tm_eurptitem.DELETE.WHERE.ByKey(req.rptid, req.yosikiid, req.yosikieda ?? -1).Execute();

                // 削除する場合、別様式を削除する前にすべてのブランチを削除する必要があります。
                var syosaiFiler =
                    $"{nameof(tm_euyosikisyosaiDto.rptid)} = @{nameof(tm_euyosikisyosaiDto.rptid)} and {nameof(tm_euyosikisyosaiDto.yosikiid)} = @{nameof(tm_euyosikisyosaiDto.yosikiid)} and {nameof(tm_eurptitemDto.yosikieda)} != @{nameof(tm_eurptitemDto.yosikieda)}";
                var syosaiList = db.tm_euyosikisyosai.SELECT.WHERE.ByFilter(syosaiFiler, req.rptid, req.yosikiid, req.yosikieda ?? -1).GetDtoList();
                if (syosaiList.Count == 0)
                {
                    //EUC様式マスタを削除
                    db.tm_euyosiki.DELETE.WHERE.ByKey(req.rptid, req.yosikiid).Execute();
                    //出力順パターンテーブルを削除
                    db.tt_eusort.DELETE.WHERE.ByKey(req.rptid, req.yosikiid).Execute();
                    //出力順パターンサブテーブルを削除
                    db.tt_eusort_sub.DELETE.WHERE.ByKey(req.rptid, req.yosikiid).Execute();
                }

                // 削除する場合、帳票を削除する前にすべてのブランチを削除する必要があります。
                var sokiFiler =
                $"{nameof(tm_euyosikisyosaiDto.rptid)} = @{nameof(tm_euyosikisyosaiDto.rptid)} " +
                $"and {nameof(tm_euyosikisyosaiDto.yosikiid)} != @{nameof(tm_euyosikisyosaiDto.yosikiid)}";

                var euyosikiList = db.tm_euyosiki.SELECT.WHERE.ByFilter(sokiFiler, req.rptid, req.yosikiid).GetDtoList();
                if (euyosikiList.Count == 0)
                {
                    //EUC帳票マスタ
                    db.tm_eurpt.DELETE.WHERE.ByKey(req.rptid).Execute();
                    //EUC様式マスタを削除
                    db.tm_euyosiki.DELETE.WHERE.ByKey(req.rptid).Execute();
                    //EUC帳票項目マスタ
                    db.tm_eurptitem.DELETE.WHERE.ByKey(req.rptid).Execute();
                    //EUC帳票検索条件マスタ
                    db.tm_eurptkensaku.DELETE.WHERE.ByItem(nameof(tm_eurptkensakuDto.rptid), req.rptid).Execute();
                }

                return res;
            });
        }

        #endregion

        /// <summary>
        /// 初期化処理ドロップダウンリスト
        /// </summary>
        /// <param name="res"></param>
        private void SetSelectorList(DaDbContext db, InitDetailResponse res, string rptid)
        {
            //ドロップダウンリスト(内外区分)
            res.selectorlist3 = EucConstant.NAIGAI_OPTIONS;
            //ドロップダウンリスト(利用目的)
            res.selectorlist4 = GetHanyoSelectorList(db, EnumHanyoKbn.利用目的);
            //ドロップダウンリスト(問い合わせ)
            res.settinglist = GetHanyoSelectorList(db, EnumHanyoKbn.問い合わせ内容コード); 
            //ドロップダウンリスト(課コード)
            res.kacdList = GetHanyoSelectorList(db, EnumHanyoKbn.課);
            //ドロップダウンリスト(係コード)
            res.kakaricdList = GetHanyoSelectorList(db, EnumHanyoKbn.係);

            //様式紐付けのドロップダウンリストを取得
            if (res.yosikihouhou == Enum様式作成方法.データソース)
            {
                // データソースIDからEUCデータソース検索マスタを取得
                var dtl = GeteurptkensakuList(db, rptid);

                //【様式紐付名】ドロップダウンリスト
                res.selectorlist = dtl.Select(x => new DaSelectorModel(x.jyokenid.ToString(), x.jyokenlabel)).ToList();
                //【様式紐付け値】ドロップダウンリスト
                res.himozukevalueList = Wraper.GetEurptkensakuConditionVmList(db, dtl);
            }
            else
            {
                //【様式紐付名】ドロップダウンリスト
                res.selectorlist = new List<DaSelectorModel>();
                //【様式紐付け値】ドロップダウンリスト
                res.himozukevalueList = new List<SearchConditionVM>();
            }
        }

        /// <summary>
        /// 選択した固定条件を取得する
        /// </summary>
        private List<SearchConditionVM> GetSeletedFixConditionList(DaDbContext db, string rptid)
        {
            //選択の固定条件を取得するフィルター
            const string kensakufilter =
                $"{nameof(tm_eurptkensakuDto.rptid)} = @{nameof(tm_eurptkensakuDto.rptid)} " +
                $"AND {nameof(tm_eurptkensakuDto.jyokenkbn)} = @{nameof(tm_eurptkensakuDto.jyokenkbn)}";

            var fixKbn = EnumToStr(Enum検索条件区分.固定条件);
            //EUC帳票検索マスタ
            var kensakuList = db.tm_eurptkensaku.SELECT.WHERE.ByFilter(kensakufilter, rptid, fixKbn).ORDER.By(nameof(tm_eurptkensakuDto.orderseq)).GetDtoList();
            var jyokenLabels = kensakuList.Select(x => new SearchConditionVM
            {
                jyokenid = x.jyokenid!.Value,
                datasourceid = CStr(x.datasourceid),
                jyokenlabel = CStr(x.jyokenlabel),
                jyokenkbn = CStr(x.jyokenkbn)
            }).ToList();

            return jyokenLabels;
        }

        /// <summary>
        /// データソースIDからEUCデータソース検索マスタを取得
        /// </summary>
        private static List<tm_eurptkensakuDto> GeteurptkensakuList(DaDbContext db, string rptid)
        {
            //様式紐付けを取得するフィルター
            const string filter =
                $"{nameof(tm_eurptkensakuDto.rptid)} = @{nameof(tm_eurptkensakuDto.rptid)} " +
                $"AND {nameof(tm_eurptkensakuDto.jyokenid)} >= 0 " +
                $"AND {nameof(tm_eurptkensakuDto.controlkbn)} = @{nameof(tm_eurptkensakuDto.controlkbn)}";

            //EUCデータソース検索マスタ
            var dtl = db.tm_eurptkensaku.SELECT
                .WHERE.ByFilter(filter, rptid, (int)Enumコントロール.選択)
                .ORDER.By(nameof(tm_eurptkensakuDto.jyokenid))
                .GetDtoList();
            return dtl;
        }

        /// <summary>
        /// 行/列明細
        /// </summary>
        private static void FillRowAndColDetail(tm_euyosikisyosaiDto? yosikisyosaiDto, Enum様式種別詳細 yosikikbn, bool meisaiflg, Enum行列固定? meisaikoteikbn, SearchExcelMappingTabResponse res)
        {
            //todo finish it
            switch (yosikikbn)
            {
                case Enum様式種別詳細.一覧表 or Enum様式種別詳細.単純集計表:
                    res.excelmappingdata.rowdetailflg = true;
                    res.excelmappingdata.coldetailflg = false;
                    res.excelmappingdata.startrow = yosikisyosaiDto?.startrow ?? 1;         //テンプレート明細開始行
                    res.excelmappingdata.loopmaxrow = yosikisyosaiDto?.loopmaxrow ?? 1;     //１ページあたりの最大行数
                    res.excelmappingdata.looprow = yosikisyosaiDto?.looprow ?? 1;           //1明細あたりの行数
                    break;
                case Enum様式種別詳細.台帳:
                    if (meisaiflg)
                    {
                        res.excelmappingdata.rowdetailflg = true;
                        res.excelmappingdata.coldetailflg = false;
                        res.excelmappingdata.startrow = yosikisyosaiDto?.startrow ?? 1;      //テンプレート明細開始行
                        res.excelmappingdata.loopmaxrow = yosikisyosaiDto?.loopmaxrow ?? 1;  //１ページあたりの最大行数
                        res.excelmappingdata.looprow = yosikisyosaiDto?.looprow ?? 1;        //1明細あたりの行数
                    }
                    else
                    {
                        res.excelmappingdata.rowdetailflg = false;
                        res.excelmappingdata.coldetailflg = false;
                    }

                    break;
                case Enum様式種別詳細.はがき or Enum様式種別詳細.アドレスシール or Enum様式種別詳細.バーコードシール
                or Enum様式種別詳細.経年表 or Enum様式種別詳細.クロス集計:
                    res.excelmappingdata.rowdetailflg = true;
                    res.excelmappingdata.coldetailflg = true;
                    res.excelmappingdata.startrow = yosikisyosaiDto?.startrow ?? 1;         //テンプレート明細開始行
                    res.excelmappingdata.loopmaxrow = yosikisyosaiDto?.loopmaxrow ?? 1;     //１ページあたりの最大行数
                    res.excelmappingdata.looprow = yosikisyosaiDto?.looprow ?? 1;           //1明細あたりの行数

                    res.excelmappingdata.startcol = yosikisyosaiDto?.startcol ?? 1;         //明細開始列数
                    res.excelmappingdata.loopmaxcol = yosikisyosaiDto?.loopmaxcol ?? 5;     //１ページあたりの最大列数
                    res.excelmappingdata.loopcol = yosikisyosaiDto?.loopcol ?? 1;           //１ページあたりの最大列数
                    break;
                case Enum様式種別詳細.宛名台帳:
                    res.excelmappingdata.rowdetailflg = false;                              //行明細フラグ
                    res.excelmappingdata.coldetailflg = false;                              //列明細フラグ
                    break;
                default:
                    res.excelmappingdata.rowdetailflg = false;                              //行明細フラグ
                    res.excelmappingdata.coldetailflg = false;                              //列明細フラグ
                    break;
            }
        }

        /// <summary>
        /// ファイル名が合法かどうかを判断する
        /// </summary>
        private static bool IsValidReportFileName(string? reportFileName)
        {
            if (string.IsNullOrEmpty(reportFileName)) return false;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Path.GetInvalidFileNameChars().All(c => !reportFileName.Contains(c));
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return reportFileName.Length <= byte.MaxValue
                       && !reportFileName.Contains(DaStrPool.C_SLASH)
                       && reportFileName != DaStrPool.DOT
                       && reportFileName != DaStrPool.DOUBLE_DOT;
            }

            return true;
        }

        /// <summary>
        /// 汎用マスタからドロップダウンリスト
        /// </summary>
        private List<DaSelectorModel> GetHanyoSelectorList(DaDbContext db, EnumHanyoKbn kbn)
        {
            return DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, EnumToStr(kbn)).ToList();
        }

        /// <summary>
        /// システム固定項目を排除（ストアド用）
        /// </summary>
        private List<Param> RemoveSystemParameter(List<Param> conditionparams)
        {
            // todo construct an dictionary of system params and if any of them exists in conditionparams, remove them from it.
            List<Param> selectitems = new List<Param>();
            foreach (Param condition in conditionparams)
            {
                if (!IsSystemParameter(condition.Name))
                {
                    selectitems.Add(condition);
                } 
            }
            return selectitems;
        }

        /// <summary>
        /// 項目定義にはメインテーブルのデータが必要
        /// </summary>
        private string GetDataSourceMaintable(DaDbContext db, string? datasourceid, List<ReportItemDetailVM> definitionValue)
        {           
            if (String.IsNullOrEmpty(datasourceid))
            {
                return DaMessageService.GetMsg(EnumMessage.E003005, "帳票データソースID");
            }

            //データソース情報
            var datasourceDto = db.tm_eudatasource.GetDtoByKey(datasourceid);
            if (datasourceDto == null)
            {
                return DaMessageService.GetMsg(EnumMessage.E003005, "帳票データソースの情報");
            }
            // データソース名称
            var maintable = datasourceDto.maintablealias;
            //データソースの全てSQLカラムリスト
            var datasourceAllSqlColumnList = new List<string>();
            if (definitionValue.Count == 1 && definitionValue[0].crosskbn == Enum集計区分.集計)
            {
                string valueInside = Regex.Match(definitionValue[0].sqlcolumn, @"\(([^)]*)\)").Groups[1].Value;
                datasourceAllSqlColumnList.Add(valueInside);
            }
            else 
            {
                datasourceAllSqlColumnList = definitionValue.Select(x => x.sqlcolumn).ToList();
            }

            //EUCテーブル項目マスタ
            var tableitemDtl = db.tm_eutableitem.SELECT.WHERE.ByKeyList(datasourceAllSqlColumnList).GetDtoList();
            if (tableitemDtl.Count == 0)
            {
                //マスターテーブルが必要です
                return DaMessageService.GetMsg(EnumMessage.E064016);
            }
            var tablealias = tableitemDtl.Select(x => x.tablealias).Distinct().ToList();
            bool isContained = tablealias.Contains(maintable);

            if (!isContained)
            {
                //マスターテーブルが必要です
                return DaMessageService.GetMsg(EnumMessage.E064016);
            }

            return string.Empty;
        }

        // AIplus 2024-06-24 SHOU ADD Start
        // 帳票新規が固定帳票(帳票種類)の場合、固定帳票用DTOを作成する。
        // EUC様式マスタ作成
        private tm_euyosikiDto makeTmeuyosikiDto(Enum様式種別詳細 yosikikbn, tm_euyosikisyosaiDto yosikisyosaiDto)
        {
            // 初期化
            var reTmeuyosikiDto = new tm_euyosikiDto();
            // テンプレートファイルパス
            var excelPath = "";
            // テンプレートパス
            var specialTemplateDir = Path.Combine(Environment.CurrentDirectory, "App_Data", "Test", "その他Templates");

            switch (yosikikbn)
            {
                case Enum様式種別詳細.アドレスシール:
                    //テンプレートファイルパス取得
                    excelPath = Path.Combine(specialTemplateDir, "アドレスシール.xlsx");
                    //テンプレートファイル名
                    reTmeuyosikiDto.templatefilenm = EucConstant.DEFAULT_TEMPLATE_FILE_NM;
                    //テンプレートファイル
                    reTmeuyosikiDto.templatefiledata = File.ReadAllBytes(excelPath);
                    //テンプレート終了行
                    reTmeuyosikiDto.endrow = 7 * yosikisyosaiDto.loopmaxrow;
                    //テンプレート終了列
                    reTmeuyosikiDto.endcol = 5 * yosikisyosaiDto.loopmaxcol;
                    //ページサイズ
                    reTmeuyosikiDto.pagesize = ((int)Enumページサイズ.A4);
                    //出力方向
                    reTmeuyosikiDto.landscape = false;

                    break;

                case Enum様式種別詳細.はがき:
                    //繰り返す数
                    var loopSu = 1;
                    //4人の場合
                    if (yosikisyosaiDto.loopmaxrow == 2)
                    {
                        //テンプレートファイルパス取得
                        excelPath = Path.Combine(specialTemplateDir, "はがき1.xlsx");
                        //ページサイズ
                        reTmeuyosikiDto.pagesize = ((int)Enumページサイズ.A4);
                        //繰り返す数
                        loopSu = 2;
                    }
                    else 
                    {
                        //テンプレートファイルパス取得
                        excelPath = Path.Combine(specialTemplateDir, "はがき2.xlsx");
                        //ページサイズ
                        reTmeuyosikiDto.pagesize = ((int)Enumページサイズ.A6);
                    }
                    //テンプレートファイル名
                    reTmeuyosikiDto.templatefilenm = EucConstant.DEFAULT_TEMPLATE_FILE_NM;
                    //テンプレートファイル
                    reTmeuyosikiDto.templatefiledata = File.ReadAllBytes(excelPath);

                    //テンプレート終了行
                    reTmeuyosikiDto.endrow = 21 * loopSu;
                    //テンプレート終了列
                    reTmeuyosikiDto.endcol = 12 * loopSu;
                    //出力方向
                    reTmeuyosikiDto.landscape = false;

                    break;

                case Enum様式種別詳細.バーコードシール:
                    //テンプレートファイルパス取得
                    excelPath = Path.Combine(specialTemplateDir, "バーコード.xlsx");
                    //テンプレートファイル名
                    reTmeuyosikiDto.templatefilenm = EucConstant.DEFAULT_TEMPLATE_FILE_NM;
                    //テンプレートファイル
                    reTmeuyosikiDto.templatefiledata = File.ReadAllBytes(excelPath);
                    //テンプレート終了行
                    reTmeuyosikiDto.endrow = 3 * yosikisyosaiDto.loopmaxrow;
                    //テンプレート終了列
                    reTmeuyosikiDto.endcol = 1 * yosikisyosaiDto.loopmaxcol;
                    //ページサイズ
                    reTmeuyosikiDto.pagesize = ((int)Enumページサイズ.A4);
                    //出力方向
                    reTmeuyosikiDto.landscape = false;

                    break;

                case Enum様式種別詳細.宛名台帳:
                    //テンプレートファイルパス取得
                    excelPath = Path.Combine(specialTemplateDir, "宛名台帳.xlsx");
                    //テンプレートファイル名
                    reTmeuyosikiDto.templatefilenm = EucConstant.DEFAULT_TEMPLATE_FILE_NM;
                    //テンプレートファイル
                    reTmeuyosikiDto.templatefiledata = File.ReadAllBytes(excelPath);
                    //テンプレート終了行
                    reTmeuyosikiDto.endrow = 32;
                    //テンプレート終了列
                    reTmeuyosikiDto.endcol = 22;
                    //ページサイズ
                    reTmeuyosikiDto.pagesize = ((int)Enumページサイズ.A4);
                    //出力方向
                    reTmeuyosikiDto.landscape = false;

                    break;
                default:
                    throw new ArgumentException();
            }
            // 結果戻る
            return reTmeuyosikiDto;
        }

        // EUC様式詳細マスタ作成
        private tm_euyosikisyosaiDto makeTmeuyosikisyosaiDto(Enum様式種別詳細 yosikikbn, DaDbContext db)
        {
            // 初期化
            var reTmeuyosikisyosaiDto = new tm_euyosikisyosaiDto();

            //メインコード
            var ctrlmaincd = "1006";

            switch (yosikikbn)
            {
                case Enum様式種別詳細.アドレスシール:
                    //サブコード
                    var ctrlsubcd_2 = 2;
                    //コントロールメインマスタ取得
                    var dtl_2 = db.tm_afctrl.SELECT.WHERE.ByKey(ctrlmaincd, ctrlsubcd_2).ORDER.By(nameof(tm_afctrlDto.ctrlcd)).GetDtoList();
                    //コントロールメインマスタ
                    var contorlList_2 = Wraper.GetVMList(dtl_2);


                    //テンプレート明細開始行
                    reTmeuyosikisyosaiDto.startrow = 1;
                    //１ページあたりの最大行数
                    reTmeuyosikisyosaiDto.loopmaxrow = DaConvertUtil.CNInt(contorlList_2.Find(item => item.ctrlcd == "3")?.value);
                    //1明細あたりの行数
                    reTmeuyosikisyosaiDto.looprow = 7;
                    //明細開始列数
                    reTmeuyosikisyosaiDto.startcol = 1;
                    //１ページあたりの最大列数
                    reTmeuyosikisyosaiDto.loopmaxcol = DaConvertUtil.CNInt(contorlList_2.Find(item => item.ctrlcd == "4")?.value);
                    //１ページあたりの最大列数
                    reTmeuyosikisyosaiDto.loopcol = 5;           

                    break;

                case Enum様式種別詳細.はがき:
                    //サブコード
                    var ctrlsubcd_4 = 4;
                    //コントロールメインマスタ
                    var dtl_4 = db.tm_afctrl.SELECT.WHERE.ByKey(ctrlmaincd, ctrlsubcd_4).ORDER.By(nameof(tm_afctrlDto.ctrlcd)).GetDtoList();
                    //コントロールメインマスタ
                    var contorlList_4 = Wraper.GetVMList(dtl_4);

                    var rowCol = 1;
                    if (DaConvertUtil.CNInt(contorlList_4.Find(item => item.ctrlcd == "1")?.value) == 4) 
                    {
                        rowCol = 2;
                    }

                    //テンプレート明細開始行
                    reTmeuyosikisyosaiDto.startrow = 1;
                    //１ページあたりの最大行数
                    reTmeuyosikisyosaiDto.loopmaxrow = rowCol;
                    //1明細あたりの行数
                    reTmeuyosikisyosaiDto.looprow = 21;
                    //明細開始列数
                    reTmeuyosikisyosaiDto.startcol = 1;
                    //１ページあたりの最大列数
                    reTmeuyosikisyosaiDto.loopmaxcol = rowCol;
                    //１ページあたりの最大列数
                    reTmeuyosikisyosaiDto.loopcol = 12;

                    break;

                case Enum様式種別詳細.バーコードシール:
                    //サブコード
                    var ctrlsubcd_3 = 3;
                    //コントロールメインマスタ
                    var dtl_3 = db.tm_afctrl.SELECT.WHERE.ByKey(ctrlmaincd, ctrlsubcd_3).ORDER.By(nameof(tm_afctrlDto.ctrlcd)).GetDtoList();
                    //コントロールメインマスタ
                    var contorlList_3 = Wraper.GetVMList(dtl_3);

                    //テンプレート明細開始行
                    reTmeuyosikisyosaiDto.startrow = 1;
                    //１ページあたりの最大行数
                    reTmeuyosikisyosaiDto.loopmaxrow = DaConvertUtil.CNInt(contorlList_3.Find(item => item.ctrlcd == "2")?.value);
                    //1明細あたりの行数
                    reTmeuyosikisyosaiDto.looprow = 3;
                    //明細開始列数
                    reTmeuyosikisyosaiDto.startcol = 1;
                    //１ページあたりの最大列数
                    reTmeuyosikisyosaiDto.loopmaxcol = DaConvertUtil.CNInt(contorlList_3.Find(item => item.ctrlcd == "3")?.value);
                    //１ページあたりの最大列数
                    reTmeuyosikisyosaiDto.loopcol = 1;

                    break;

                case Enum様式種別詳細.宛名台帳:
                    //テンプレート明細開始行
                    reTmeuyosikisyosaiDto.startrow = 1;
                    //１ページあたりの最大行数
                    reTmeuyosikisyosaiDto.loopmaxrow = 32;
                    //1明細あたりの行数
                    reTmeuyosikisyosaiDto.looprow = 1;
                    //明細開始列数
                    reTmeuyosikisyosaiDto.startcol = 1;
                    //１ページあたりの最大列数
                    reTmeuyosikisyosaiDto.loopmaxcol = 22;
                    //１ページあたりの最大列数
                    reTmeuyosikisyosaiDto.loopcol = 1;

                    break;
                default:
                    throw new ArgumentException();
            }


            // 結果戻る
            return reTmeuyosikisyosaiDto;
        }
        // AIplus 2024-06-24 SHOU ADD End
    }
}