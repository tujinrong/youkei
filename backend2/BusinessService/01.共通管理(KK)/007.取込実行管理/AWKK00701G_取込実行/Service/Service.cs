// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行
// 　　　　　　サービス処理
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using AIplus.AiImporter;
using BCC.Affect.Service.CheckImporter;
using Microsoft.Extensions.Caching.Memory;
using System.Globalization;
using System.Text.RegularExpressions;
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaStrPool;

namespace BCC.Affect.Service.AWKK00701G
{
    [DisplayName("取込実行")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00701G = "AWKK00701G";

        //検索処理(取込設定一覧画面)
        private const string PROC_NAME1 = "sp_awkk00701g_01";
        //検索処理(未処理一覧画面)
        private const string PROC_NAME2 = "sp_awkk00701g_02";
        //検索処理(取込履歴一覧画面)
        private const string PROC_NAME3 = "sp_awkk00701g_03";
        //一時データテーブル名
        private const string TMP_TABLE_NAME_PREFIX = "wk_kktorinyuryoku_";

        /// <summary>
        /// 事前処理(ログ)
        /// </summary>
        public override void BeforeAction(DaDbContext db, DaRequestBase req)
        {
            req.Service = req.kinoid!;
            //機能名を取得
            req.ServiceDesc = $"Name{req.kinoid}";
            db.Session.SessionData[DaConst.SessionID] = req.sessionid;
            DaDbLogService.WriteDbMessage(db, "Begin Service");
        }

        [DisplayName("初期化処理(取込設定一覧画面)")]
        public InitKimpListResponse InitKimpList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitKimpListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //画面の入り口より、機能マスタの設定より該当業務区分と該当取込区分のみ実行可能とする
                var hanyokbn = CStr(db.tm_afkino.GetDtoByKey(req.kinoid!).hanyokbn);
                if (hanyokbn.Length == 3)
                {
                    //機能マスタ.汎用区分=取込区分(1桁)+業務区分(2桁)
                    //取込区分
                    res.impkbn = hanyokbn.Substring(0, 1);
                    //業務区分
                    res.gyoumukbn = hanyokbn.Substring(1, 2);
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(取込設定一覧画面)")]
        public SearchKimpListResponse SearchKimpList(SearchKimpListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchKimpListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ設定
                var parameters = Converter.GetParameters(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME1, parameters, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //汎用取込設定情報一覧
                res.kimpList = Wraper.GetKimpVMList(db, pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("初期検索処理(未処理一覧画面)")]
        public SearchKimpDataListResponse InitSearchKimpDataList(SearchKimpListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchKimpDataListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ設定
                var parameters = Converter.GetParametersDetail(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME2, parameters, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //取込データ情報一覧
                res.kimpDataList = Wraper.GetKimpDataVMList(db, pageList.dataTable.Rows, res);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("初期検索処理(取込履歴一覧画面)")]
        public SearchKimpHistoryListResponse InitSearchKimpHistoryList(SearchKimpListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchKimpHistoryListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ設定
                var parameters = Converter.GetParametersDetail(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME3, parameters, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //取込履歴情報一覧
                res.kimpHistoryList = Wraper.GetKimpHistoryVMList(db, pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(取込（一括入力）編集画面)")]
        public InitDetailResponse InitDetail(InitDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitDetailResponse();

                //一括取込入力マスタ
                tm_kktorinyuryokuDto tm_KkimpDto = GetKkimpDto(db, req.impno);

                //画面項目明細データをセットする
                if (req.editkbn == Enum編集区分.変更)
                {
                    //修正モードの場合
                    //取込実行ID
                    int impexeid = CInt(req.impexeid);
                    //一括取込入力未処理テーブル
                    tt_kktorinyuryoku_misyoriDto tt_KkimpdataDto = GetKkimpDataDto(db, impexeid);
                    if (req.editkbn == Enum編集区分.変更 && tt_KkimpdataDto == null)
                    {
                        //画面項目明細データ
                        res.detailList = new List<KimpDetailRowVM>();
                        //正常返し
                        return res;
                    }

                    //更新日時
                    res.upddttm = tt_KkimpdataDto.upddttm;

                    //取込データ詳細行番号リストを取得する
                    List<int> rownoList = GetKkimpDataDetailRownos(db, impexeid);

                    //該当行番号あり
                    if (req.rowNo != null)
                    {
                        int index = rownoList.IndexOf(CInt(req.rowNo));
                        if (index != -1)
                        {
                            req.pagenum = (index / req.pagesize) + 1;
                        }
                    }
                    //該当ページの行番号リスト
                    List<int> rownoSubList = rownoList.Skip((req.pagenum - 1) * req.pagesize).Take(req.pagesize).ToList();

                    //該当ページの取込データ詳データを取得する
                    List<tt_kktorinyuryoku_misyoriitemDto> subDatadetailDtl = GetKkimpDataDetailDtlByRownos(db, impexeid, rownoSubList);

                    //取込データエラーデータを取得する
                    List<tt_kktorinyuryoku_errDto> kkimpdataerrDtl = GetKkimpDataErrDtl(db, impexeid);
                    //該当ページの取込データエラーデータを取得する
                    var subDataErrDtl = kkimpdataerrDtl.FindAll(e => rownoList.Contains(e.rowno));

                    //該当ページへのデータをセット
                    res.detailList = Wraper.GetKimpDetailRowVMList(impexeid, subDatadetailDtl, subDataErrDtl);
                    //ページャー設定
                    res.SetPageInfo(rownoList.Count, req.pagesize);
                    //ページNo.設定
                    res.pagenum = req.pagenum;

                    //最大行数
                    res.rownoMax = rownoList.Max();
                    //ファイル取込の場合
                    if (tm_KkimpDto.torinyuryokbn.Equals(EnumToStr(Enum取込区分.ファイル取込)))
                    {
                        if (tt_KkimpdataDto.filegokeirow > res.rownoMax)
                        {
                            //最大行数=ファイル最大行数
                            res.rownoMax = CInt(tt_KkimpdataDto.filegokeirow);
                        }
                    }

                    //取込実行ID
                    res.impexeid = impexeid;

                    //一括取込入力エラーテーブルのデータを取得する
                    if (kkimpdataerrDtl.Count > 0)
                    {
                        //エラー件数
                        List<int> errRowList = kkimpdataerrDtl.Where(e => e.errkbn.Equals(EnumToStr(Enumエラーレベル.エラー))).Select(e => e.rowno).Distinct().ToList();
                        res.errCnt = errRowList.Count;
                        //警告件数
                        List<int> warnRowList = kkimpdataerrDtl.Where(e => e.errkbn.Equals(EnumToStr(Enumエラーレベル.警告)) && !errRowList.Contains(e.rowno)).Select(e => e.rowno).Distinct().ToList();
                        res.warnCnt = warnRowList.Count;
                        //情報件数
                        List<int> infoRowList = kkimpdataerrDtl.Where(e => e.errkbn.Equals(EnumToStr(Enumエラーレベル.情報)) && !errRowList.Contains(e.rowno) && !warnRowList.Contains(e.rowno)).Select(e => e.rowno).Distinct().ToList();
                        res.infoCnt = infoRowList.Count;
                    }

                    //正常件数
                    res.normalCnt = tt_KkimpdataDto.totalcnt - tt_KkimpdataDto.errcnt;
                }

                //画面項目ヘッダーデータを取得する
                res.PageItemHeaderList = GetPageItemHeaderData(db, req.impno);
                //年度表示フラグ
                res.yeardispflg = tm_KkimpDto.nendohyojiflg;
                //一括取込入力区分
                res.impkbn = tm_KkimpDto.torinyuryokbn;
                //業務区分名称
                res.gyoumukbnnm = DaNameService.GetName(db, EnumNmKbn.取込業務区分, CStr(tm_KkimpDto.gyomukbn));
                //一括取込入力名
                res.impnm = tm_KkimpDto.torinyuryokunm;
                //年度表示の場合
                if (tm_KkimpDto.nendohyojiflg && !string.IsNullOrEmpty(tm_KkimpDto.nendohanikbn))
                {
                    //初期表示年度と最大年度
                    var nendohanikbn = CStr(tm_KkimpDto.nendohanikbn);
                    (res.nendo, res.nendomax) = GetNendoAndNendomax(db, nendohanikbn);
                }
                //画面項目の入力区分がコード変換時用コードデータをセットする
                SetCdChangeSelectorData(db, req.impno, ref res);
                //画面項目の入力区分がプルダウンリスト時プルダウンリストをセットする
                SetPullDownListSelectorData(db, req.impno, ref res);
                //正常返し
                return res;
            });
        }

        [DisplayName("参照元項目入力後取得先項目の値を取得処理　(取込（一括入力）編集画面)")]
        public GetTargetItemValueResponse GetTargetItemValue(GetTargetItemValueRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new GetTargetItemValueResponse();
                res.targetItemValueList = new List<object[]>();
                //該当画面項目IDを参照元項目IDとして、該当取得先項目データを取得する
                var dtl = GetPageTargetItemData(db, req.impno, req.pageitemseq);
                foreach (var dto in dtl)
                {
                    var paraNames = new List<string>();
                    var paraValues = new List<object>();
                    var sqlSel = $"SELECT {dto.syutokusakifield} FROM {dto.inputhoho} WHERE {dto.sansyomotofield} = @{dto.sansyomotofield}";
                    //参照元フィールド
                    paraNames.Add(dto.sansyomotofield!);
                    //参照元フィールドの値
                    paraValues.Add(req.val);
                    ImDBUtil.SetParam(db.Session, dto.inputhoho, paraNames, ref paraValues);
                    var dt = DaDbUtil.GetDataTable(db, sqlSel, paraNames.ToArray(), paraValues.ToArray());
                    object value = string.Empty;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //取得先項目ID,取得先項目の値
                        value = dt.Rows[0][0];
                    }
                    if (!string.IsNullOrEmpty(dto.itemtokuteikbn) && dto.itemtokuteikbn.Equals(EnumToStr(Enum項目特定区分.性別)))
                    {
                        string sexName = DaNameService.GetName(db, EnumNmKbn.性別_システム共有, CStr(value));
                        value = sexName;
                    }
                    //取得先項目ID,取得先項目の値
                    res.targetItemValueList.Add(new object[] { dto.gamenitemseq, value });
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("項目特定処理 (取込（一括入力）編集画面)")]
        public DoSpecialPageItemResponse DoSpecialPageItem(DoSpecialPageItemRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new DoSpecialPageItemResponse();
                res.targetItemValueList = new List<object[]>();
                //一括取込入力項目定義マスタ
                var pageItemDtl = GetPageItemDtl(db, req.impno);
                //項目特定
                var dto = pageItemDtl.Find(e => e.gamenitemseq == req.pageitemseq);
                if (dto != null && !string.IsNullOrEmpty(dto.itemtokuteikbn))
                {
                    switch (ParseEnum<Enum項目特定区分>(dto.itemtokuteikbn))
                    {
                        case Enum項目特定区分.実施日_一次_申込:
                            //実施日
                            //実施年齢
                            var ageData = GetJissiAgeByInputData(db, pageItemDtl, req.detailRowVM.PageItemBodyList, EnumToStr(Enum項目特定区分.実施年齢_一次_申込), EnumToStr(Enum項目特定区分.実施日_一次_申込));
                            if (ageData != null)
                            {
                                res.targetItemValueList.Add(ageData);
                            }
                            //年度
                            var nendoData = GetNendoByInputData(db, pageItemDtl, req.detailRowVM.PageItemBodyList, EnumToStr(Enum項目特定区分.年度_一次_申込), req.pageitemseq);
                            if (nendoData != null)
                            {
                                res.targetItemValueList.Add(nendoData);
                            }
                            break;
                        case Enum項目特定区分.実施日_精密_結果:
                            //実施日（精密・結果）
                            //実施年齢（精密・結果）
                            ageData = GetJissiAgeByInputData(db, pageItemDtl, req.detailRowVM.PageItemBodyList, EnumToStr(Enum項目特定区分.実施年齢_精密_結果), EnumToStr(Enum項目特定区分.実施日_精密_結果));
                            if (ageData != null)
                            {
                                res.targetItemValueList.Add(ageData);
                            }
                            //年度（精密・結果）
                            nendoData = GetNendoByInputData(db, pageItemDtl, req.detailRowVM.PageItemBodyList, EnumToStr(Enum項目特定区分.年度_精密_結果), req.pageitemseq);
                            if (nendoData != null)
                            {
                                res.targetItemValueList.Add(nendoData);
                            }
                            break;
                        case Enum項目特定区分.生年月日:
                            //生年月日
                            //実施年齢
                            ageData = GetJissiAgeByInputData(db, pageItemDtl, req.detailRowVM.PageItemBodyList, EnumToStr(Enum項目特定区分.実施年齢_一次_申込), EnumToStr(Enum項目特定区分.実施日_一次_申込));
                            if (ageData != null)
                            {
                                res.targetItemValueList.Add(ageData);
                            }
                            //実施年齢（精密・結果）
                            ageData = GetJissiAgeByInputData(db, pageItemDtl, req.detailRowVM.PageItemBodyList, EnumToStr(Enum項目特定区分.実施年齢_精密_結果), EnumToStr(Enum項目特定区分.実施日_精密_結果));
                            if (ageData != null)
                            {
                                res.targetItemValueList.Add(ageData);
                            }
                            break;
                        case Enum項目特定区分.医療機関コード:
                            var kikanData = GetKikancdByInputData(db, pageItemDtl, req.detailRowVM.PageItemBodyList, Enum項目特定区分.検診実施機関番号, req.pageitemseq);
                            if (kikanData != null)
                            {
                                res.targetItemValueList.Add(kikanData);
                            }
                            break;
                        case Enum項目特定区分.検診実施機関番号:
                            kikanData = GetKikancdByInputData(db, pageItemDtl, req.detailRowVM.PageItemBodyList, Enum項目特定区分.医療機関コード, req.pageitemseq);
                            if (kikanData != null)
                            {
                                res.targetItemValueList.Add(kikanData);
                            }
                            break;
                        default:
                            break;
                    }
                }

                //正常返し
                return res;
            });
        }
        [DisplayName("関数値を取得処理 (取込（一括入力）編集画面)")]
        public DoKansuResponse DoKansu(DoKansuRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new DoKansuResponse();
                //結果情報
                var itemsResultDic = new Dictionary<int, List<object?>>();
                //各項目定義情報
                var itemsInfoDic = new Dictionary<int, object[]>();

                //一括取込入力項目定義マスタ
                var pageItemDtl = GetPageItemDtl(db, req.impno);
                //関数
                var itemList = pageItemDtl.Where(e => e.inputkbn == EnumToStr(Enum入力区分.関数) && e.inputhoho == req.inputhoho).ToList();
                if (itemList != null && itemList.Count > 0)
                {
                    foreach (var item in itemList)
                    {
                        //関数名
                        var procName = DaNameService.GetKanaName(db, EnumNmKbn.入力方法, item.inputhoho!);
                        //画面項目ID
                        var gamenitemseqList = new List<string>(item.hikisu!.Split(COMMA));

                        itemsInfoDic.Add(item.gamenitemseq, new object[] { procName, gamenitemseqList });
                    }
                }
                //各項目の毎行パラメータSql
                var itemsValueSqlDic = new Dictionary<int, List<string>>();
                foreach (var itemseq in itemsInfoDic.Keys)
                {
                    //毎行パラメータデータ
                    var valueList = new List<string>();
                    //関数名
                    var procName = (string)itemsInfoDic[itemseq][0];
                    //画面項目ID　or 固定値
                    var gamenitemseqList = (List<string>)itemsInfoDic[itemseq][1];
                    foreach (string name in gamenitemseqList)
                    {
                        //固定値をセット
                        if (name.Contains('\''))
                        {
                            valueList.Add(name.Replace("'", ""));
                        }
                        //画面項目をセット
                        else
                        {
                            var val = req.detailRowVM.PageItemBodyList.Find(e => e.pageitemseq == CInt(name))!.val;
                            valueList.Add(CStr(val));
                        }
                    }
                    //毎行パラメータデータ
                    valueList = valueList.Select(s => $"'{s}'").ToList();
                    var strValue = string.Join(",", valueList);
                    //パラメータsql
                    var sql = $"SELECT {procName}({strValue})";

                    if (!itemsValueSqlDic.ContainsKey(itemseq))
                    {
                        itemsValueSqlDic.Add(itemseq, new List<string>());
                    }
                    //各項目の毎行パラメータsqlを追加
                    itemsValueSqlDic[itemseq].Add(sql);
                }
                foreach (var itemseq in itemsValueSqlDic.Keys)
                {
                    //全て行のパラメータsql
                    var sqlList = itemsValueSqlDic[itemseq];
                    //全てsql
                    var strSql = string.Join(";", sqlList);
                    //結果リストに格納
                    List<object?> resultList = db.Session.GetAllValueList(strSql);

                    //各項目のデータを追加
                    itemsResultDic.Add(itemseq, resultList);
                }
                res.KansuValueList = itemsResultDic.Select(kvp => new object[] { kvp.Key, kvp.Value[0]! }).ToList();
                //正常返し
                return res;
            });
        }

        [DisplayName("チェック処理(取込（一括入力）編集画面)")]
        public CheckInfoResponse CheckDetail(DetailRequest req)
        {
            //※プログレスバーをセットする
            AiProgress.SetProgress(req.processKey, ImportProcess.PageItemCheck, 0);

            return Transction(req, (DaDbContext db) =>
            {
                var res = new CheckInfoResponse();
                //一括取込入力No
                string impno = req.impno;
                //取込実行ID
                int impexeid = req.impexeid;

                //画面項目情報詳細
                var detailList = new List<KimpDetailRowVM>();
                //一括取込入力未処理テーブル
                var tt_KkimpdataDto = new tt_kktorinyuryoku_misyoriDto();

                if (req.editkbn == Enum編集区分.変更)
                {
                    //編集前の取込データを取得
                    tt_KkimpdataDto = GetKkimpDataDto(db, impexeid);
                    //登録排他チェック
                    if (tt_KkimpdataDto == null || tt_KkimpdataDto.upddttm != req.upddttm)
                    {
                        throw new AiExclusiveException();
                    }

                    //取込データをDBから全て取得
                    List<tt_kktorinyuryoku_misyoriitemDto> kkimpdatadetailDtl = GetKkimpDataDetailDtl(db, impexeid);

                    //更新データ
                    var uptList = req.detailList.Where(e => e.impexeid.Equals(impexeid)).ToList();
                    if (uptList != null && uptList.Count > 0)
                    {
                        //DBから明細リスト
                        detailList = Wraper.GetKimpDetailRowVMList(impexeid, kkimpdatadetailDtl, null);
                        //更新データの行番号
                        List<int> rownoList = uptList.Select(e => e.rowno).Distinct().ToList();
                        //DBから明細リストに更新データを取り除く
                        detailList.RemoveAll(e => rownoList.Contains(e.rowno));
                        //更新データを取得する
                        detailList.AddRange(uptList);
                    }

                    //新規データ
                    var addList = req.detailList.Where(e => !e.impexeid.Equals(impexeid)).ToList();
                    if (addList != null && addList.Count > 0)
                    {
                        //DBから明細リストに更新データを追加
                        detailList.AddRange(addList);
                    }
                }
                else
                {
                    //新規
                    detailList = req.detailList;
                }
                //並び順
                detailList = detailList.OrderBy(e => e.rowno).ToList();

                //画面項目データ情報がデータテーブルに変換する
                DataTable dt = Converter.GetPageItemDetailDtByVmList(detailList);

                //一括取込入力マスタ
                tm_kktorinyuryokuDto tm_kkimpDto = GetKkimpDto(db, impno);

                //データのチェック
                var result = CheckEditData(db, req, dt, tm_kkimpDto);
                if (!result.Success)
                {
                    res.SetServiceError(result.ErrMsg);
                    return res;
                }

                //エラー件数
                int errcnt = 0;
                if (result.EditErrorList.Count > 0)
                {
                    //エラー件数
                    errcnt = result.EditErrorList.Select(e => e.rowno).Distinct().Count();
                }
                //件数
                int totalcnt = dt.Rows.Count;
                //更新日時
                var dttm = DaUtil.Now;

                //①　一括取込入力未処理テーブルデータ登録
                if (req.editkbn == Enum編集区分.変更)
                {
                    //一括取込入力未処理テーブル
                    tt_KkimpdataDto.totalcnt = totalcnt;        //件数
                    tt_KkimpdataDto.errcnt = errcnt;            //エラー件数
                    tt_KkimpdataDto.upddttm = dttm;             //更新日時
                    tt_KkimpdataDto.upduserid = req.userid;     //更新ユーザーID
                    //一括取込入力未処理テーブル登録
                    db.tt_kktorinyuryoku_misyori.UPDATE.Execute(tt_KkimpdataDto);

                    //一括取込入力未処理項目テーブル削除
                    RunSqlDeleteKkimpById(db, tt_kktorinyuryoku_misyoriitemDto.TABLE_NAME, impexeid);
                    //一括取込入力エラーテーブル削除
                    RunSqlDeleteKkimpById(db, tt_kktorinyuryoku_errDto.TABLE_NAME, impexeid);
                }
                else
                {
                    //取込データ情報を取得する(一括入力登録 新規用)
                    tt_KkimpdataDto = Converter.GetKkimpDataDto(db, req.impno, req.userid, null, null, null, totalcnt, errcnt);
                    //取込実行ID手動採番MAX+1
                    tt_KkimpdataDto.impjikkoid = db.tt_kktorinyuryoku_misyori.SELECT.GetMax<int>(nameof(tt_kktorinyuryoku_misyoriDto.impjikkoid)) + 1;
                    //エラー件数
                    tt_KkimpdataDto.errcnt = errcnt;
                    //一括取込入力未処理テーブル登録
                    db.tt_kktorinyuryoku_misyori.INSERT.Execute(tt_KkimpdataDto);

                    //取込実行ID
                    impexeid = tt_KkimpdataDto.impjikkoid;
                }

                //取込実行ID
                res.impexeid = impexeid;
                //更新日時
                res.upddttm = dttm;

                //②　一括取込入力未処理項目テーブル登録
                SaveKkimpDetailData(db, impexeid, result.EditDataList, req.processKey);

                if (result.EditErrorList.Count > 0)
                {
                    //③　一括取込入力エラーテーブル登録
                    SaveKkimpErrorData(db, impexeid, result.EditErrorList);
                }

                //チェックプロシージャありの場合
                if (result.EditErrorList.Count == 0 && !string.IsNullOrEmpty(tm_kkimpDto.proccheck))
                {
                    //一括取込入力項目定義マスタ
                    List<tm_kktorinyuryoku_itemDto> pageitemDtl = GetPageItemDtl(db, impno);
                    DataTable dt2 = Converter.GetPageItemDetailDtByVmList2(detailList, tm_kkimpDto, pageitemDtl);
                    //チェックプロシージャ
                    var msg = DoCheckProc(db, tm_kkimpDto.proccheck, impexeid, dt2, impno);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        res.SetServiceError(msg);
                        return res;
                    }
                }

                //一括取込入力エラーテーブルを取得する
                List<tt_kktorinyuryoku_errDto> errDtl = GetKkimpDataErrDtl(db, impexeid);

                if (errDtl.Count > 0)
                {
                    //エラー件数
                    List<int> errRowList = errDtl.Where(e => e.errkbn.Equals(EnumToStr(Enumエラーレベル.エラー))).Select(e => e.rowno).Distinct().ToList();
                    res.errCnt = errRowList.Count;
                    //警告件数
                    List<int> warnRowList = errDtl.Where(e => e.errkbn.Equals(EnumToStr(Enumエラーレベル.警告)) && !errRowList.Contains(e.rowno)).Select(e => e.rowno).Distinct().ToList();
                    res.warnCnt = warnRowList.Count;
                    //情報件数
                    List<int> infoRowList = errDtl.Where(e => e.errkbn.Equals(EnumToStr(Enumエラーレベル.情報)) && !errRowList.Contains(e.rowno) && !warnRowList.Contains(e.rowno)).Select(e => e.rowno).Distinct().ToList();
                    res.infoCnt = infoRowList.Count;
                }

                //正常件数
                res.normalCnt = tt_KkimpdataDto.totalcnt - res.errCnt - res.warnCnt - res.infoCnt;

                //※プログレスバーをセットする
                AiProgress.SetProgress(req.processKey, ImportProcess.PageItemCheck, 100);
                //正常返し
                return res;
            });
        }

        [DisplayName("登録実行処理(取込（一括入力）編集画面)")]
        public DaResponseBase Save(SaveRequest req)
        {
            //※プログレスバーをセットする
            AiProgress.SetProgress(req.processKey, ImportProcess.Save, 0);

            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //一括取込入力No
                string impno = req.impno;
                //取込実行ID
                int impexeid = req.impexeid;
                //一括取込入力マスタデータを取得する
                tm_kktorinyuryokuDto kkimpDto = GetKkimpDto(db, impno);

                //一括取込入力項目定義マスタ
                List<tm_kktorinyuryoku_itemDto> pageitemDtl = GetPageItemDtl(db, impno);
                //一時テーブルデータ用のデータテーブルを取得
                var dt = GetDataTable(db, impexeid, kkimpDto, pageitemDtl, "1");
                //画面項目データ情報から一時テーブルデータを登録(更新前、登録用)
                CheckWorkData(db.Session, dt, impexeid, kkimpDto, pageitemDtl);

                //登録実行前の取込データを取得
                tt_kktorinyuryoku_misyoriDto kkimpdataDto = GetKkimpDataDto(db, impexeid) ?? throw new AiExclusiveException();
                if (!string.IsNullOrEmpty(kkimpDto.procbefore))
                {
                    //更新前プロシージャ名
                    var msg = DoProcedure(db, kkimpDto.procbefore, impexeid, "更新前プロシージャ");
                    if (!string.IsNullOrEmpty(msg))
                    {
                        res.SetServiceError(msg);
                        return res;
                    }
                }

                //取込データ詳細情報を取得する（ワークテーブルから）
                var temptableData = db.Session.GetDataTable($"select * from {TMP_TABLE_NAME_PREFIX}{impexeid}");

                //※プログレスバーをセットする
                AiProgress.SetProgress(req.processKey, ImportProcess.Save, 2);

                if (temptableData.Rows.Count > 0)
                {
                    //画面取込データをインポート実行
                    var result = ImportFromEditData(db, req, kkimpDto, pageitemDtl, temptableData);

                    if (result.Success)
                    {
                        //一括取込入力履歴テーブル
                        tt_kktorinyuryoku_rirekiDto tt_KkimphistoryDto = Converter.GeKkimpHistoryDto(req, kkimpDto, kkimpdataDto);
                        //取込履歴No手動採番MAX+1
                        tt_KkimphistoryDto.imprirekino = db.tt_kktorinyuryoku_rireki.SELECT.GetMax<int>(nameof(tt_kktorinyuryoku_rirekiDto.imprirekino)) + 1;
                        //一括取込入力履歴テーブル登録
                        db.tt_kktorinyuryoku_rireki.INSERT.Execute(tt_KkimphistoryDto);

                        if (!string.IsNullOrEmpty(kkimpDto.procafter))
                        {
                            //更新後プロシージャ名
                            var msg = DoProcedure(db, kkimpDto.procafter, impexeid, "更新後プロシージャ");
                            if (!string.IsNullOrEmpty(msg))
                            {
                                res.SetServiceError(msg);
                                return res;
                            }
                        }
                    }
                    else
                    {
                        //メッセージ
                        var errMsg = "";
                        //対象データが存在しない場合
                        if (result.MsgId == MsgType.DATA_NOTEXIST_ERROR)
                        {
                            errMsg = DaMessageService.GetMsg(EnumMessage.DATA_NOTEXIST_ERROR, "対象", "更新");
                        }
                        else
                        {
                            errMsg = DaMessageService.GetMsg(EnumMessage.E004007, "取込実行");
                        }

                        res.SetServiceError(errMsg);
                        return res;
                    }
                }

                //※プログレスバーをセットする
                AiProgress.SetProgress(req.processKey, ImportProcess.Save, 95);

                //一括取込入力未処理テーブル削除
                RunSqlDeleteKkimpById(db, tt_kktorinyuryoku_misyoriDto.TABLE_NAME, impexeid);
                //一括取込入力未処理項目テーブル削除
                RunSqlDeleteKkimpById(db, tt_kktorinyuryoku_misyoriitemDto.TABLE_NAME, impexeid);
                //一括取込入力エラーテーブル削除
                RunSqlDeleteKkimpById(db, tt_kktorinyuryoku_errDto.TABLE_NAME, impexeid);

                //※プログレスバーをセットする
                AiProgress.SetProgress(req.processKey, ImportProcess.Save, 100);
                //正常返し
                return res;
            });
        }

        [DisplayName("仮保存処理(取込（一括入力）編集画面)")]
        public SaveWorkResponse SaveWork(DetailRequest req)
        {
            //※プログレスバーをセットする
            AiProgress.SetProgress(req.processKey, ImportProcess.SaveWork, 0);
            return Transction(req, (DaDbContext db) =>
            {
                var res = new SaveWorkResponse();

                //一括取込入力項目定義マスタ
                List<tm_kktorinyuryoku_itemDto> kkimppageitemDtl = GetPageItemDtl(db, req.impno);
                //取込画面項目ID + 画面項目名
                var itemDic = new Dictionary<int, string>();
                foreach (var dto in kkimppageitemDtl)
                {
                    itemDic.Add(dto.gamenitemseq, dto.itemnm);
                }

                //※プログレスバーをセットする
                AiProgress.SetProgress(req.processKey, ImportProcess.SaveWork, 5);

                var saveList = new List<tt_kktorinyuryoku_misyoriitemDto>();
                if (req.editkbn == Enum編集区分.変更)
                {
                    //編集前の取込データを取得
                    tt_kktorinyuryoku_misyoriDto oldDto = GetKkimpDataDto(db, req.impexeid);
                    //更新排他チェック
                    if (oldDto == null || oldDto.upddttm != req.upddttm)
                    {
                        throw new AiExclusiveException();
                    }

                    //最大データID
                    int maxdataseq = 1;
                    //更新データ
                    var uptList = req.detailList.Where(e => e.impexeid.Equals(req.impexeid)).ToList();
                    if (uptList != null && uptList.Count > 0)
                    {
                        //取込データ詳細情報を取得する(更新用)
                        saveList = Converter.GetKkimpDataDetailUptDtl(req.impexeid, uptList, itemDic);
                        //取込データ詳細情報を登録
                        db.tt_kktorinyuryoku_misyoriitem.UPDATE.Execute(saveList);
                    }
                    //新規データ
                    var addList = req.detailList.Where(e => !e.impexeid.Equals(req.impexeid)).ToList();
                    if (addList != null && addList.Count > 0)
                    {
                        //最大データIDを取得する
                        maxdataseq = saveList.Select(e => e.dataseq).Max();
                        maxdataseq++;
                        //取込データ詳細情報を取得する(仮保存新規用)
                        saveList = Converter.GetKkimpDataDetailAddDtl(req.impexeid, maxdataseq, addList, itemDic);
                        //取込データ詳細情報を登録
                        db.tt_kktorinyuryoku_misyoriitem.INSERT.Execute(saveList);
                    }
                    if (addList != null && addList.Count > 0)
                    {
                        //件数
                        oldDto.totalcnt = oldDto.totalcnt + addList.Count;
                    }
                    //更新ユーザーID
                    oldDto.upduserid = req.userid;
                    //更新日時
                    oldDto.upddttm = DaUtil.Now;
                    //取込データ情報を登録
                    db.tt_kktorinyuryoku_misyori.UPDATE.Execute(oldDto);

                    res.impexeid = req.impexeid;
                }
                else
                {
                    //新規モード場合

                    //取込データ情報を取得する(新規用)
                    var tt_KkimpdataDto = Converter.GetKkimpDataDto(db, req.impno, req.userid, null, null, null, req.detailList.Count, 0);
                    //取込データ情報を登録
                    db.tt_kktorinyuryoku_misyori.INSERT.Execute(tt_KkimpdataDto);

                    //※プログレスバーをセットする
                    AiProgress.SetProgress(req.processKey, ImportProcess.SaveWork, 30);

                    //取込データ詳細情報を取得する(仮保存新規用)
                    saveList = Converter.GetKkimpDataDetailAddDtl(tt_KkimpdataDto.impjikkoid, 0, req.detailList, itemDic);

                    //※プログレスバーをセットする
                    AiProgress.SetProgress(req.processKey, ImportProcess.SaveWork, 70);

                    //取込データ詳細情報を登録
                    db.tt_kktorinyuryoku_misyoriitem.INSERT.Execute(saveList);

                    //※プログレスバーをセットする
                    AiProgress.SetProgress(req.processKey, ImportProcess.SaveWork, 100);

                    res.impexeid = tt_KkimpdataDto.impjikkoid;
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("削除(取込（一括入力）編集画面)")]
        public DaResponseBase DeleteEdit(DeleteDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var impexeid = req.impexeid;
                //編集前の取込データを取得
                tt_kktorinyuryoku_misyoriDto oldDto = GetKkimpDataDto(db, impexeid);
                //削除排他チェック
                if (oldDto == null || oldDto.upddttm != req.upddttm)
                {
                    throw new AiExclusiveException();
                }
                //取込対象行数
                oldDto.totalcnt = oldDto.totalcnt - req.rownoList.Count;

                if (oldDto.totalcnt == 0)
                {
                    //一括取込入力未処理テーブル削除
                    RunSqlDeleteKkimpById(db, tt_kktorinyuryoku_misyoriDto.TABLE_NAME, impexeid);
                    //一括取込入力未処理項目テーブル削除
                    RunSqlDeleteKkimpById(db, tt_kktorinyuryoku_misyoriitemDto.TABLE_NAME, impexeid);
                    //一括取込入力エラーテーブル削除
                    RunSqlDeleteKkimpById(db, tt_kktorinyuryoku_errDto.TABLE_NAME, impexeid);
                }
                else
                {
                    //-------------------------------------------------------------
                    //２.DB更新処理
                    //-------------------------------------------------------------
                    string rownos = string.Join(",", req.rownoList);//選択した行
                    //一括取込入力エラーテーブル
                    var sqlErrSel = $"SELECT COUNT(DISTINCT {nameof(tt_kktorinyuryoku_errDto.rowno)}) FROM {tt_kktorinyuryoku_errDto.TABLE_NAME} WHERE {nameof(tt_kktorinyuryoku_errDto.impjikkoid)} =  {impexeid} AND {nameof(tt_kktorinyuryoku_errDto.rowno)} = ANY(ARRAY[{rownos}])";
                    var dt = DaDbUtil.GetDataTable(db, sqlErrSel);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int errcnt = CInt(dt.Rows[0][0]);
                        oldDto.errcnt = oldDto.errcnt - errcnt;//エラー件数
                    }

                    //一括取込入力未処理項目テーブル削除
                    var sqlDetailDel = $"DELETE FROM  {tt_kktorinyuryoku_misyoriitemDto.TABLE_NAME} WHERE {nameof(tt_kktorinyuryoku_misyoriitemDto.impjikkoid)} = {impexeid} AND {nameof(tt_kktorinyuryoku_misyoriitemDto.rowno)} = ANY(ARRAY[{rownos}])";
                    DaDbUtil.RunSql(db, sqlDetailDel);

                    //一括取込入力エラーテーブル削除
                    var sqlErrDel = $"DELETE FROM {tt_kktorinyuryoku_errDto.TABLE_NAME} WHERE {nameof(tt_kktorinyuryoku_errDto.impjikkoid)} = {impexeid} AND {nameof(tt_kktorinyuryoku_errDto.rowno)} = ANY(ARRAY[{rownos}])";
                    DaDbUtil.RunSql(db, sqlErrDel);

                    //取込データマスタ更新
                    db.tt_kktorinyuryoku_misyori.UpdateDto(oldDto, oldDto.upddttm);
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("削除(未処理一覧画面)")]
        public DaResponseBase DeleteKimpList(DeleteKimpListRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //取込実行IDリスト
                var impexeidList = req.locklist.Select(e => e.impexeid).ToList();
                //編集前の取込データを取得
                List<int> oldDtl = db.tt_kktorinyuryoku_misyori.SELECT.WHERE.ByKeyList(impexeidList).GetDtoList().Select(e => e.impjikkoid).ToList();

                //削除排他チェック
                if (oldDtl.Count == 0 || req.locklist.Any(d => !oldDtl.Contains(d.impexeid)))
                {
                    throw new AiExclusiveException();
                }

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------
                //一括取込入力未処理テーブル削除
                RunSqlDeleteKkimpByIds(db, tt_kktorinyuryoku_misyoriDto.TABLE_NAME, impexeidList);
                //一括取込入力未処理項目テーブル削除
                RunSqlDeleteKkimpByIds(db, tt_kktorinyuryoku_misyoriitemDto.TABLE_NAME, impexeidList);
                //一括取込入力エラーテーブル削除
                RunSqlDeleteKkimpByIds(db, tt_kktorinyuryoku_errDto.TABLE_NAME, impexeidList);

                //正常返し
                return res;
            });
        }

        [DisplayName("取込履歴ファイルダウンロード処理(取込履歴一覧画面)")]
        public CmDownloadResponseBase KimpHistoryFileDown(KimpHistoryFileDownRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new CmDownloadResponseBase();

                //一括取込入力履歴テーブル
                tt_kktorinyuryoku_rirekiDto dto = db.tt_kktorinyuryoku_rireki.SELECT.WHERE.ByKey(req.rirekiid).GetDto();
                //ファイルタイプ
                var filetype = DaNameService.GetName(db, EnumNmKbn.ファイルタイプ, CStr(dto.filetype));
                //単一ファイルのダウンロード応答を取得
                res = CmDownloadService.GetDownloadResponse(new DaFileModel(dto.filenm!, "." + filetype, dto.filedata));

                //正常返し
                return res;
            });
        }

        [DisplayName("取込実行のプログレスバー")]
        public ProcessTimerResponse ProcessTimer(ProcessTimerRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new ProcessTimerResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var key = req.processKey;

                var cache = AiProgress._cache;
                object[] objects;
                if (cache != null && cache.TryGetValue(key, out objects!))
                {
                    //処理内容
                    res.processnm = GetProcessName((ImportProcess)objects[0]);
                    //進捗値
                    res.value = (int)objects[1];
                }

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 編集画面：初期化処理画面項目の入力区分がコード変換時用システムコードデータをセットする
        /// </summary>
        private void SetCdChangeSelectorData(DaDbContext db, string impno, ref InitDetailResponse res)
        {

            //一括取込入力変換コードメインマスタを取得する
            List<tm_kktorinyuryoku_henkancode_mainDto> changeCodeMainDtl = GetChangeCodeMainDtl(db, impno);

            //画面項目の入力区分がコード変換時用システムコードデータ
            res.cdchangeSelectorDic = GetCodeChangeSysCodeDic(db, changeCodeMainDtl);

            if (res.impkbn == EnumToStr(Enum取込区分.ファイル取込))
            {
                //画面項目の入力区分がコード変換時用旧コードデータ
                res.cdchangeOldSelectorDic = GeCodeChangeOldDic(db, impno);
            }
        }

        /// <summary>
        /// 編集画面：画面項目の入力区分がコード変換時用システムコードデータを取得する
        /// </summary>
        private Dictionary<int, List<DaSelectorModel>> GetCodeChangeSysCodeDic(DaDbContext db, List<tm_kktorinyuryoku_henkancode_mainDto> changeCodeMainDtl)
        {
            //画面項目の入力区分がコード変換時用
            var cdchangekbnDic = new Dictionary<int, List<DaSelectorModel>>();
            foreach (tm_kktorinyuryoku_henkancode_mainDto dto in changeCodeMainDtl)
            {
                var sysCodeList = new List<DaSelectorModel>();
                //コード管理テーブル名
                string cdtableid = dto.codekanritablenm;
                //名称マスタ
                if (cdtableid.Equals(tm_afmeisyoDto.TABLE_NAME))
                {
                    sysCodeList = DaNameService.GetSelectorList(db, dto.maincd, CInt(dto.subcd), Enum名称区分.名称);
                }
                //汎用マスタ
                if (cdtableid.Equals(tm_afhanyoDto.TABLE_NAME))
                {
                    sysCodeList = DaHanyoService.GetSelectorList(db, dto.maincd, CInt(dto.subcd), Enum名称区分.名称);
                }
                cdchangekbnDic.Add(dto.codehenkankbn, sysCodeList);
            }
            //画面項目の入力区分がコード変換時用システムコードデータ
            return cdchangekbnDic;
        }

        /// <summary>
        /// 編集画面：画面項目の入力区分がコード変換時用旧コードデータを取得する
        /// </summary>
        private Dictionary<int, List<DaSelectorKeyModel>> GeCodeChangeOldDic(DaDbContext db, string impno)
        {
            //画面項目の入力区分がコード変換時用
            var cdchangekbnOldDic = new Dictionary<int, List<DaSelectorKeyModel>>();

            //取込変換コードマスタを取得する
            List<tm_kktori_henkancodeDto> changeCodeDtl = GetChangeCodeDtl(db, impno);
            //コード変換区分リスト
            var changeKbnList = changeCodeDtl.Select(e => e.codehenkankbn).Distinct().ToList();
            foreach (var changeKbn in changeKbnList)
            {
                List<DaSelectorKeyModel> list = changeCodeDtl.Where(e => e.codehenkankbn == changeKbn).Select(e => new DaSelectorKeyModel(e.motocd, e.motocdcomment, e.henkangocd)).ToList();
                cdchangekbnOldDic.Add(changeKbn, list);
            }
            //画面項目の入力区分がコード変換時用旧コードデータ
            return cdchangekbnOldDic;
        }

        /// <summary>
        /// 編集画面：初期化処理画面項目の入力区分がプルダウンリスト時データをセットする
        /// </summary>
        private void SetPullDownListSelectorData(DaDbContext db, string impno, ref InitDetailResponse res)
        {
            //一括取込入力項目定義マスタ
            List<tm_kktorinyuryoku_itemDto> kkimppageitemDtl = GetPageItemDtl(db, impno);
            //入力区分がプルダウンリストのデータ
            var itemDtl = kkimppageitemDtl.Where(e => e.inputkbn == EnumToStr(Enum入力区分.プルダウンリスト) || e.inputkbn == EnumToStr(Enum入力区分.プルダウン_画面検索)).ToList();
            var selectorDic = new Dictionary<string, List<DaSelectorModel>>();
            var models = new List<DaSelectorModel>();
            foreach (var item in itemDtl)
            {
                if (!selectorDic.ContainsKey(item.inputhoho))
                {
                    switch (ParseEnum<Enum入力方法>(item.inputhoho))
                    {
                        case Enum入力方法.コード_ユーザーマスタ:
                            //ユーザーマスタドロップリストを取得
                            models = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.ユーザーマスタ, false);
                            break;
                        case Enum入力方法.コード_所属グループマスタ:
                            //所属グループマスタドロップリストを取得
                            models = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.所属グループマスタ, false);
                            break;
                        case Enum入力方法.コード_地区情報マスタ:
                            //地区情報マスタドロップリストを取得
                            models = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.地区情報マスタ, false);
                            break;
                        case Enum入力方法.コード_会場情報マスタ:
                            //会場情報マスタドロップリストを取得
                            models = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ, false);
                            break;
                        case Enum入力方法.医療機関:
                            //医療機関マスタドロップリストを取得
                            if (!string.IsNullOrEmpty(item.jigyocd))
                            {
                                models = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, false, item.jigyocd);
                            }
                            break;
                        case Enum入力方法.検診実施機関:
                            //検診実施機関ドロップリストを取得
                            if (!string.IsNullOrEmpty(item.jigyocd))
                            {
                                models = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ_保険, false, item.jigyocd);
                            }
                            break;
                        case Enum入力方法.事業従事者:
                            //事業従事者ドロップリストを取得
                            if (!string.IsNullOrEmpty(item.jigyocd))
                            {
                                models = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, false, item.jigyocd);
                            }
                            break;
                        default:
                            //
                            models = new List<DaSelectorModel>();
                            break;
                    }
                    selectorDic.Add(item.inputhoho, models);
                }
            }
            res.selectorDic = selectorDic;
        }

        /// <summary>
        /// 編集画面：初期化処理画面項目ヘッダーデータを取得する
        /// </summary>
        private List<PageItemHeaderModel> GetPageItemHeaderData(DaDbContext db, string impno)
        {
            //一括取込入力項目定義マスタ
            List<tm_kktorinyuryoku_itemDto> kkimppageitemDtl = GetPageItemDtl(db, impno);
            //画面項目ヘッダーデータを取得する
            return Wraper.GetPageItemHeaderVMList(db, kkimppageitemDtl);
        }

        /// <summary>
        /// データのチェック
        /// </summary>
        private ImCheckResult CheckEditData(DaDbContext db, DetailRequest req, DataTable dt, tm_kktorinyuryokuDto tm_kkimpDto)
        {
            var imDef = new ImDef();
            var option = new ImCheckOption();

            //チェックデータを取得する
            GetCheckEditData(db, tm_kkimpDto, ref imDef, ref option);

            //年度
            option.nendo = req.nendo;
            option.ProcessKey = req.processKey;
            //データのチェック
            var result = CheckImporter.CheckImporter.CheckEditData(db, dt, imDef, option, null);
            return result;
        }

        /// <summary>
        /// チェックデータを取得する
        /// </summary>
        public static void GetCheckEditData(DaDbContext db, tm_kktorinyuryokuDto tm_kkimpDto, ref ImDef imDef, ref ImCheckOption option)
        {
            //一括取込入力No
            string impno = tm_kkimpDto.torinyuryokuno;

            //一括取込入力項目定義マスタデータを取得する
            List<tm_kktorinyuryoku_itemDto> kkimppageitemDtl = GetPageItemDtl(db, impno);
            //一括取込入力登録マスタ
            List<tm_kktorinyuryoku_torokuDto> insertdetailDtl = GetKkimpInsertDetailDtl(db, impno);

            //取込対象テーブルIDを取得
            List<string> tableidList = insertdetailDtl.Select(e => e.tableid).Distinct().ToList();

            //一括取込入力テーブルマスタを取得
            List<tm_kktorinyuryoku_tableDto> kkimptableDtl = GetKkmipTableDtl(db);
            //コード変換情報リストを取得する
            option.CdChangeDataList = GetCdChangeData(db, impno);
            // 取込対象テーブル
            option.TableidList = tableidList;
            // テーブル名称情報
            option.TableNameDic = kkimptableDtl.ToDictionary(e => e.tablenm, e => e.tableronrinm);

            //一括取込入力区分
            option.impkbn = tm_kkimpDto.torinyuryokbn;
            // データ型
            option.DataTypeDic = DaNameService.GetNameList(db, EnumNmKbn.入力方法).ToDictionary(e => e.nmcd, e => e.nm);
            // フォーマット_日付
            option.FormatDateDic = DaNameService.GetNameList(db, EnumNmKbn.フォーマット_日付).ToDictionary(e => e.nmcd, e => e.nm);
            // 性別
            option.SexNameDic = DaNameService.GetNameList(db, EnumNmKbn.性別_システム共有).ToDictionary(e => e.nmcd, e => e.nm);
            // 医療機関
            option.kikanDic = db.tm_afkikan.SELECT.GetDtoList().ToDictionary(e => e.hokenkikancd, e => e.kikancd);
            // 関数
            option.kansuDic = GetkansuResult(db);
            //登録区分
            option.regupdkbn = tm_kkimpDto.torokukbn;

            //取込画面項目情報リストを取得する
            imDef.EditorColumns = Wraper.GetImEditorColmunDefList(kkimppageitemDtl, insertdetailDtl);

            //登録区分が更新の場合
            if (tm_kkimpDto.torokukbn.Equals(EnumToStr(Enum登録区分.更新)))
            {

                //項目登録移送データを取得する
                imDef.InsertDetails = Wraper.GetInsertDetailData(insertdetailDtl);
            }
        }

        private static Dictionary<string, List<object?>> GetkansuResult(DaDbContext db)
        {
            var kansuDic = new Dictionary<string, List<object?>>();
            // 関数名称
            var arr = new string[] { "fn_kkgetothersiryokikan", "fn_kkgetotherskaijyo" };
            foreach (var item in arr)
            {
                kansuDic.Add(item, db.Session.GetValueList($"select * from {item}()"));
            };
            return kansuDic;
        }

        /// <summary>
        /// 画面取込データをインポート実行
        /// </summary>
        private ImResult ImportFromEditData(DaDbContext db, SaveRequest req, tm_kktorinyuryokuDto kkimpDto, List<tm_kktorinyuryoku_itemDto> kkimppageitemDtl, DataTable temptableData)
        {
            //一括取込入力No
            string impno = req.impno;
            //取込実行ID
            int impexeid = req.impexeid;
            //
            var wktableDic = kkimppageitemDtl.ToDictionary(item => item.wktablecolnm, item => item.gamenitemseq);
            //一括取込入力登録マスタを取得する
            List<tm_kktorinyuryoku_torokuDto> insertdetailDtl = GetKkimpInsertDetailDtl(db, impno);

            //一括取込入力テーブルマスタIDリスト
            List<string> tableidList = insertdetailDtl.Select(e => e.tableid).Distinct().ToList();

            var imDef = new ImportDef();
            var imDataBank = new ImDataBank();

            //項目登録移送データを取得する
            imDef.Tables = GetTableData(tableidList, insertdetailDtl, kkimppageitemDtl);
            //登録区分
            imDef.importType = GetRegupdKbn(kkimpDto.torokukbn);

            //取込データ詳細情報がデータテーブルに変換する
            DataTable dt = Converter.GetPageItemDetailDtByDtl(temptableData, wktableDic);

            //特定項目-実施年齢
            var isHasJissiAge = insertdetailDtl.Exists(d => d.syorikbn.Equals(EnumToStr(Enum処理区分.年齢登録_一次申込))
                                                            || d.syorikbn.Equals(EnumToStr(Enum処理区分.年齢登録_精密結果)));
            if (isHasJissiAge)
            {
                //明細データから取得した特定項目値を取得
                imDef.EditorRowTokuteData = GetTokuteItemValue(db, dt, kkimppageitemDtl);
            }

            //※プログレスバーをセットする
            AiProgress.SetProgress(req.processKey, ImportProcess.Save, 5);

            imDef.ProcessKey = req.processKey;
            imDef.Nendo = req.nendo;
            //インポート実行
            var result = new AiImporter().ImportFromEditData(db.Session, dt, imDef, imDataBank);
            return result;
        }


        /// <summary>
        /// 明細データから取得した特定項目値を取得
        /// </summary>
        public static List<ImEditorRowDef> GetTokuteItemValue(DaDbContext db, DataTable dt, List<tm_kktorinyuryoku_itemDto> kkimppageitemDtl)
        {
            var editorRowData = new List<ImEditorRowDef>();

            //設定した画面項目--宛名番号
            int? atenanoPageItemSeq = GetPageItemSeq(kkimppageitemDtl, EnumToStr(Enum項目特定区分.宛名番号));
            if (atenanoPageItemSeq == null)
            {
                return editorRowData;
            }

            //設定した画面項目--実施日
            int? jissiymdPageItemSeq = GetPageItemSeq(kkimppageitemDtl, EnumToStr(Enum項目特定区分.実施日_一次_申込));
            //設定した画面項目--実施日(精密)
            int? seiJissiymdPageItemSeq = GetPageItemSeq(kkimppageitemDtl, EnumToStr(Enum項目特定区分.実施日_精密_結果));
            //設定した画面項目--生年月日
            int? bymdPageItemSeq = GetPageItemSeq(kkimppageitemDtl, EnumToStr(Enum項目特定区分.生年月日));
            //設定した画面項目--実施年齢
            int? agePageItemSeq = GetPageItemSeq(kkimppageitemDtl, EnumToStr(Enum項目特定区分.実施年齢_一次_申込));
            //設定した画面項目--実施年齢(精密)
            int? seiAgePageItemSeq = GetPageItemSeq(kkimppageitemDtl, EnumToStr(Enum項目特定区分.実施年齢_精密_結果));

            List<DataTable> dataList = ImDBUtil.GetDataList(dt, 1000);

            foreach (var data in dataList)
            {
                var atenanoDic = new Dictionary<string, string>();
                //明細データから取得した特定項目値定義
                for (var rowIndex = 0; rowIndex < data.Rows.Count; rowIndex++)
                {
                    var dr = data.Rows[rowIndex];
                    var rowData = new ImEditorRowDef();
                    //行インデックス
                    rowData.RowIndex = rowIndex;

                    //実施年齢
                    var strJissiAge = agePageItemSeq == null ? "" : CStr(dr["Column" + agePageItemSeq]);
                    if (strJissiAge != "")
                    {
                        int.TryParse(strJissiAge, out int intissiAge);
                        //特定項目-実施年齢
                        rowData.JissiAge = intissiAge;
                    }
                    //実施年齢(精密)
                    var strSeiJissiAge = seiAgePageItemSeq == null ? "" : CStr(dr["Column" + seiAgePageItemSeq]);
                    if (strSeiJissiAge != "")
                    {
                        int.TryParse(strSeiJissiAge, out int intissiAge);
                        //特定項目-実施年齢(精密)
                        rowData.SeiJissiAge = intissiAge;
                    }

                    if (strJissiAge == "" || strSeiJissiAge == "")
                    {
                        if (atenanoDic.Count == 0)
                        {
                            //宛名テーブル
                            atenanoDic = GetAtenano(db.Session, CInt(atenanoPageItemSeq), bymdPageItemSeq, data);
                        }

                        //実施年齢計算
                        KeisanJissiAgeValue(atenanoDic, rowData, dr, CInt(atenanoPageItemSeq), bymdPageItemSeq, strJissiAge, jissiymdPageItemSeq, strSeiJissiAge, seiJissiymdPageItemSeq);
                    }

                    editorRowData.Add(rowData);
                }
            }

            return editorRowData;
        }

        /// <summary>
        /// 宛名テーブルデータを取得
        /// </summary>
        private static Dictionary<string, string> GetAtenano(AiSessionContext session, int atenanoPageItemSeq, int? bymdPageItemSeq, DataTable data)
        {
            //参照元フィールド値
            var fromfieldid = nameof(tt_afatenaDto.atenano);
            //選択フィールド（参照元フィールド値,取得先フィールド値）
            var selfieldids = string.Join(",", new List<string>() { $"{nameof(tt_afatenaDto.atenano)} {nameof(SearchDataModel.condictionvalue)}", $"{nameof(tt_afatenaDto.bymd)} {nameof(SearchDataModel.targetvalue)}" });

            //参照マスタチェックテーブルsqlを取得する
            var sql = GetSql(session, data, atenanoPageItemSeq, bymdPageItemSeq, tt_afatenaDto.TABLE_NAME, selfieldids, fromfieldid);

            var dataList = new List<SearchDataModel>();
            if (sql != "")
            {
                //参照マスタチェックテーブルデータを取得する
                dataList = session.Query<SearchDataModel>(sql);
            }

            var dic = dataList.ToDictionary(e => e.condictionvalue, e => e.targetvalue);

            return dic;
        }

        /// <summary>
        /// 参照マスタチェックテーブルsqlを取得する
        /// </summary>
        private static string GetSql(AiSessionContext session, DataTable data, int atenanoPageItemSeq, int? bymdPageItemSeq,
                                string tableid, string selfieldid, string confieldid)
        {
            string sql = "";
            var atenanoColumnName = "Column" + atenanoPageItemSeq;
            var valueList = new List<string>();
            //生年月日項目ありの場合
            if (bymdPageItemSeq != null)
            {
                var bymdColumnName = "Column" + bymdPageItemSeq;
                //条件値リスト
                valueList = data.AsEnumerable().Where(row => !string.IsNullOrEmpty(row.Field<string>(atenanoColumnName)) && string.IsNullOrEmpty(row.Field<string>(bymdColumnName)))
                                                .Select(row => row.Field<string>(atenanoColumnName)).ToList()!;
            }
            else
            {
                //条件値リスト
                valueList = data.AsEnumerable().Where(row => !string.IsNullOrEmpty(row.Field<string>(atenanoColumnName)))
                                                .Select(row => row.Field<string>(atenanoColumnName)).ToList()!;
            }

            if (valueList.Count == 0)
            {
                return "";
            }

            //条件値を取得する
            var values = ImDBUtil.GetConditionValues(session, tableid, confieldid, valueList!);
            if (!string.IsNullOrEmpty(values))
            {
                sql = $"SELECT {selfieldid} FROM {tableid} WHERE {confieldid} in ({values})";
            }

            return sql;
        }

        /// <summary>
        /// 実施年齢計算
        /// </summary>
        private static void KeisanJissiAgeValue(Dictionary<string, string> atenanoDic, ImEditorRowDef rowData, DataRow dr,
            int? atenanoPageItemSeq, int? bymdPageItemSeq
            , string strJissiAge, int? jissiymdPageItemSeq, string strSeiJissiAge, int? seiJissiymdPageItemSeq)
        {
            //宛名番号
            if (atenanoPageItemSeq == null)
            {
                return;
            }
            //生年月日
            var bymd = "";
            var bymd_fusyoflg = false;
            //宛名番号を取得
            var atenano = CStr(dr["Column" + atenanoPageItemSeq]);

            //生年月日を取得
            if (bymdPageItemSeq != null)
            {
                bymd = CStr(dr["Column" + bymdPageItemSeq]);
            }
            if (bymd == "" && atenanoDic.ContainsKey(atenano))
            {
                bymd = atenanoDic[atenano];
            }
            if (bymd == "")
            {
                return;
            }

            //生年月日不祥チェック
            if (Regex.IsMatch(bymd, @"^0000|A|-00|00$"))
            {
                bymd_fusyoflg = true;
            }

            //実施年齢が空白　かつ 実施日項目がありの場合
            if (strJissiAge == "" && jissiymdPageItemSeq != null)
            {
                //実施日を取得
                var jissiymd = CStr(dr["Column" + jissiymdPageItemSeq]);

                //実施日
                if (DateTime.TryParseExact(jissiymd, DaConst.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    //特定項目-実施年齢
                    rowData.JissiAge = CmLogicUtil.GetAge(bymd_fusyoflg, bymd, parsedDate);
                }
            }
            //実施年齢(精密)が空白　かつ 実施日(精密)項目がありの場合
            if (strSeiJissiAge == "" && seiJissiymdPageItemSeq != null)
            {
                //実施日(精密)を取得
                var seiJissiymd = CStr(dr["Column" + seiJissiymdPageItemSeq]);

                //実施日(精密)
                if (DateTime.TryParseExact(seiJissiymd, DaConst.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    //特定項目-実施年齢(精密)
                    rowData.SeiJissiAge = CmLogicUtil.GetAge(bymd_fusyoflg, bymd, parsedDate);
                }
            }
        }

        /// <summary>
        /// 画面項目IDリストを取得する(入力方法がコード変換の)
        /// </summary>
        private static List<int> GetsCdChangePageItemSeqList(List<tm_kktorinyuryoku_itemDto> kkimppageitemDtl)
        {
            //入力方法がコード変換の画面項目IDを取得する
            List<int> cdChangePageItemSeqList = kkimppageitemDtl.Where(e => e.inputkbn.Equals(EnumToStr(Enum入力区分.コード系))).Select(e => e.gamenitemseq).ToList();
            return cdChangePageItemSeqList;
        }

        /// <summary>
        /// 一括取込入力マスタを取得する
        /// </summary>
        public static tm_kktorinyuryokuDto GetKkimpDto(DaDbContext db, string impno)
        {
            //一括取込入力マスタを取得する
            tm_kktorinyuryokuDto dto = db.tm_kktorinyuryoku.GetDtoByKey(impno);
            return dto;
        }

        /// <summary>
        /// 一括取込入力変換コードメインマスタを取得する
        /// </summary>
        private static List<tm_kktorinyuryoku_henkancode_mainDto> GetChangeCodeMainDtl(DaDbContext db, string impno)
        {
            //一括取込入力変換コードメインマスタを取得する
            List<tm_kktorinyuryoku_henkancode_mainDto> dtl = db.tm_kktorinyuryoku_henkancode_main.SELECT.WHERE.ByKey(impno).GetDtoList();
            return dtl;
        }

        /// <summary>
        /// 取込変換コードマスタを取得する
        /// </summary>
        private static List<tm_kktori_henkancodeDto> GetChangeCodeDtl(DaDbContext db, string impno)
        {
            //取込変換コードマスタを取得する
            List<tm_kktori_henkancodeDto> dtl = db.tm_kktori_henkancode.SELECT.WHERE.ByKey(impno).GetDtoList();
            return dtl;
        }

        /// <summary>
        /// 一括取込入力項目定義マスタを取得する
        /// </summary>
        public static List<tm_kktorinyuryoku_itemDto> GetPageItemDtl(DaDbContext db, string impno)
        {
            //一括取込入力項目定義マスタ
            List<tm_kktorinyuryoku_itemDto> dtl = db.tm_kktorinyuryoku_item.SELECT.WHERE.ByKey(impno).ORDER.By(nameof(tm_kktorinyuryoku_itemDto.orderseq), nameof(tm_kktorinyuryoku_itemDto.gamenitemseq)).GetDtoList();
            return dtl;
        }

        /// <summary>
        /// 一括取込入力登録マスタを取得する
        /// </summary>
        private static List<tm_kktorinyuryoku_torokuDto> GetKkimpInsertDetailDtl(DaDbContext db, string impno)
        {
            //一括取込入力登録マスタを取得する
            List<tm_kktorinyuryoku_torokuDto> insertdetailDtl = db.tm_kktorinyuryoku_toroku.SELECT.WHERE.ByKey(impno).GetDtoList();
            return insertdetailDtl;
        }

        /// <summary>
        /// 一括取込入力未処理テーブルを取得する
        /// </summary>
        public static tt_kktorinyuryoku_misyoriDto GetKkimpDataDto(DaDbContext db, int impexeid)
        {
            //一括取込入力未処理テーブルを取得する
            tt_kktorinyuryoku_misyoriDto kkimpdataDto = db.tt_kktorinyuryoku_misyori.SELECT.WHERE.ByKey(impexeid).GetDto();
            return kkimpdataDto;
        }

        /// <summary>
        /// 一括取込入力未処理項目テーブルを取得する
        /// </summary>
        private static List<tt_kktorinyuryoku_misyoriitemDto> GetKkimpDataDetailDtl(DaDbContext db, int impexeid)
        {
            //一括取込入力未処理項目テーブルを取得する
            List<tt_kktorinyuryoku_misyoriitemDto> kkimpdatadetailDtl = db.tt_kktorinyuryoku_misyoriitem.SELECT.WHERE.ByKey(impexeid).GetDtoList();
            return kkimpdatadetailDtl;
        }

        /// <summary>
        /// 一括取込入力未処理項目テーブルを取得する
        /// </summary>
        private static List<tt_kktorinyuryoku_misyoriitemDto> GetKkimpDataDetailDtlByRownos(DaDbContext db, int impexeid, List<int> rownoSubList)
        {
            string[] itemNames = new string[] { nameof(tt_kktorinyuryoku_misyoriitemDto.impjikkoid), nameof(tt_kktorinyuryoku_misyoriitemDto.rowno) };
            List<object[]> valuesList = rownoSubList.Select(rowno => new object[] { impexeid, rowno }).ToList();

            //一括取込入力未処理項目テーブルを取得する
            List<tt_kktorinyuryoku_misyoriitemDto> kkimpdatadetailDtl = db.tt_kktorinyuryoku_misyoriitem.SELECT.WHERE.ByItemList(itemNames, valuesList).ORDER.By(nameof(tt_kktorinyuryoku_misyoriitemDto.rowno)).GetDtoList();
            return kkimpdatadetailDtl;
        }

        /// <summary>
        /// 取込データ詳細行番号リストを取得する
        /// </summary>
        private static List<int> GetKkimpDataDetailRownos(DaDbContext db, int impexeid)
        {
            var sql = $"SELECT DISTINCT {nameof(tt_kktorinyuryoku_misyoriitemDto.rowno)} " +
                        $" FROM {tt_kktorinyuryoku_misyoriitemDto.TABLE_NAME} " +
                        $" WHERE {nameof(tt_kktorinyuryoku_misyoriitemDto.impjikkoid)} = ({impexeid}) " +
                        $" ORDER BY {nameof(tt_kktorinyuryoku_misyoriitemDto.rowno)} ";

            List<tt_kkimpdatadetailModel> dataList = db.Session.Query<tt_kkimpdatadetailModel>(sql);

            //行番号リスト
            List<int> rownoList = dataList.Select(e => e.rowno).ToList();
            return rownoList;
        }

        /// <summary>
        /// 一括取込入力エラーテーブルを取得する
        /// </summary>
        private static List<tt_kktorinyuryoku_errDto> GetKkimpDataErrDtl(DaDbContext db, int impexeid)
        {
            //一括取込入力エラーテーブルを取得する
            List<tt_kktorinyuryoku_errDto> kkimpdataerrDtl = db.tt_kktorinyuryoku_err.SELECT.WHERE.ByKey(impexeid).GetDtoList();
            return kkimpdataerrDtl;
        }

        /// <summary>
        /// 一括取込入力テーブルマスタを取得する
        /// </summary>
        private static List<tm_kktorinyuryoku_tableDto> GetKkmipTableDtl(DaDbContext db)
        {
            // 一括取込入力テーブルマスタを取得する
            List<tm_kktorinyuryoku_tableDto> dtl = db.tm_kktorinyuryoku_table.SELECT.GetDtoList();
            return dtl;
        }

        /// <summary>
        /// コード変換データリストを取得する
        /// </summary>
        private static List<ImCdChangeDef> GetCdChangeData(DaDbContext db, string impno)
        {
            var cdChangeDataList = new List<ImCdChangeDef>();
            //取込変換コードマスタを取得する
            List<tm_kktori_henkancodeDto> changeCodeDtl = GetChangeCodeDtl(db, impno);
            //コード変換区分リスト
            var changeKbnList = changeCodeDtl.Select(e => e.codehenkankbn).Distinct().ToList();
            //コード変換情報リストを取得する
            foreach (var changeKbn in changeKbnList)
            {
                List<ImCdChangeDef> cdChangeData = changeCodeDtl.Where(e => e.codehenkankbn == changeKbn).Select(e => new ImCdChangeDef(changeKbn, e.motocd, e.henkangocd)).ToList();
                cdChangeDataList.AddRange(cdChangeData);
            }
            return cdChangeDataList;
        }

        /// <summary>
        /// 該当画面項目IDを参照元項目IDとして、該当取得先項目データを取得する
        /// </summary>
        private static List<tm_kktorinyuryoku_itemDto> GetPageTargetItemData(DaDbContext db, string impno, int pageitemseq)
        {
            //一括取込入力項目定義マスタ
            var dtl = db.tm_kktorinyuryoku_item.SELECT.WHERE.ByItemList(
                                     new string[] { nameof(tm_kktorinyuryoku_itemDto.torinyuryokuno), nameof(tm_kktorinyuryoku_itemDto.sansyomotoseq) },
            new List<object[]>() { new object[] { impno, pageitemseq } }).GetDtoList();
            return dtl;
        }

        /// <summary>
        /// 画面項目シーケンスを取得
        /// </summary>
        public static int? GetPageItemSeq(List<tm_kktorinyuryoku_itemDto> kkimppageitemDtl, string itemkbn)
        {
            var pageItemDto = kkimppageitemDtl.Find(e => e.itemtokuteikbn == itemkbn);
            if (pageItemDto != null)
            {
                return pageItemDto.gamenitemseq;
            }
            return null;
        }

        /// <summary>
        /// 項目登録移送データを取得する（登録保存用）
        /// </summary>
        private static List<ImTableDef> GetTableData(List<string> tableidList, List<tm_kktorinyuryoku_torokuDto> insertdetailDtl, List<tm_kktorinyuryoku_itemDto> kkimpPageItemDtl)
        {
            var tables = new List<ImTableDef>();

            foreach (var tableid in tableidList)
            {
                var imTableDef = new ImTableDef();

                imTableDef.TableName = tableid;

                //テーブルのレコードリスト
                List<tm_kktorinyuryoku_torokuDto> tableRecordList = insertdetailDtl.Where(x => x.tableid == tableid).ToList();
                for (int recordno = 1; recordno <= tableRecordList.Max(x => x.recordno); recordno++)
                {
                    //レコードのフィールドリスト
                    List<tm_kktorinyuryoku_torokuDto> recordFieldList = tableRecordList.Where(x => x.recordno == recordno).ToList();

                    //レコード不祥フィールド
                    var fusyoflgField = recordFieldList.Find(e => e.syorikbn.Equals(EnumToStr(Enum処理区分.不祥フラグ登録)));

                    foreach (var recordField in recordFieldList)
                    {
                        var fieldDef = new ImFieldDef();
                        fieldDef.TableName = imTableDef.TableName;                          //テーブル物理名
                        fieldDef.FieldName = recordField.fieldnm;                           //フィールド物理名
                        fieldDef.RecordNo = recordField.recordno;                           // レコードNo
                        fieldDef.Syorikbn = GetSyorikbn(recordField.syorikbn);              //処理区分
                        fieldDef.ColumnName = "Column" + CStr(recordField.datamotoitemseq); //データ元画面項目シーケンス
                        fieldDef.Fixedval = recordField.koteiti;                            //固定値
                        fieldDef.SaibanKey = recordField.saibankey;                         //採番キー
                        fieldDef.DataMotoTableName = recordField.datamototablenm;           //データ元テーブル
                        fieldDef.DataMotoFieldName = recordField.datamotofieldnm;           //データ元フィールド

                        //入力不祥フィールド判断
                        if (fusyoflgField != null && recordField.fieldnm.Equals(nameof(tt_shfreeDto.strvalue)) &&
                            recordField.syorikbn.Equals(EnumToStr(Enum処理区分.画面項目登録)))
                        {
                            //画面項目登録の入力方法（データ型）が14、16、32（不詳）の場合
                            var pageItem = kkimpPageItemDtl.Find(e => e.gamenitemseq == recordField.datamotoitemseq
                                                                && (e.inputhoho.Equals(EnumToStr(Enum入力方法.半角文字_年_不詳あり))
                                                                || e.inputhoho.Equals(EnumToStr(Enum入力方法.半角文字_年月_不詳あり))
                                                                || e.inputhoho.Equals(EnumToStr(Enum入力方法.日付_年月日_不詳あり))));
                            if (pageItem != null)
                            {
                                //レコード入力不祥フィールド
                                fieldDef.IsUnknowField = true;
                            }
                        }
                        //フィールド定義
                        imTableDef.FieldList.Add(fieldDef);
                    }
                }

                //テーブルの項目登録移送データ
                tables.Add(imTableDef);
            }
            return tables;
        }

        /// <summary>
        /// 一括取込入力未処理項目テーブル登録
        /// </summary>
        public static void SaveKkimpDetailData(DaDbContext db, int impexeid, List<ImEditDataRow> editDataList, string processKey)
        {
            AiTableInfo info = AiGlobal.DbInfoProvider.GetTableInfo(db.Session, tt_kktorinyuryoku_misyoriitemDto.TABLE_NAME);
            var dt = AiDataSetUtil.GetDateTable(info);

            //取込データ詳細情報を取得する
            Converter.SetKkimpDataDetailDt(impexeid, editDataList, ref dt);

            //※プログレスバーをセットする
            AiProgress.SetProgress(processKey, ImportProcess.PageItemCheck, 90);

            if (dt.Rows.Count > 0)
            {
                var api = new AiPostgreApi();
                //一括登録
                api.BulkInsert(db.Session, dt, tt_kktorinyuryoku_misyoriitemDto.TABLE_NAME, false);
            }
        }

        /// <summary>
        /// 一括取込入力エラーテーブル登録
        /// </summary>
        public static void SaveKkimpErrorData(DaDbContext db, int impexeid, List<ImEditErrorRow> editErrorList)
        {
            //一括取込入力エラーテーブルのデータを取得する
            List<tt_kktorinyuryoku_errDto> tt_kkimpdataerrDtl = Converter.GetKkimpDataErrDtl(impexeid, editErrorList);
            //一括取込入力エラーテーブルデータ登録
            db.tt_kktorinyuryoku_err.INSERT.Execute(tt_kkimpdataerrDtl);
        }

        /// <summary>
        /// 処理区分を取得する
        /// </summary>
        private static ImEnumFieldType GetSyorikbn(string syorikbn)
        {
            switch (ParseEnum<Enum処理区分>(syorikbn))
            {
                //画面項目登録
                case Enum処理区分.画面項目登録:
                    return ImEnumFieldType.Move;
                //固定値登録
                case Enum処理区分.固定値登録:
                    return ImEnumFieldType.FixValue;
                //自動
                case Enum処理区分.自動:
                    return ImEnumFieldType.AutoNumber;
                //設定しない
                case Enum処理区分.設定しない:
                    return ImEnumFieldType.None;
                //関連テーブルの項目から登録
                case Enum処理区分.関連テーブルの項目から登録:
                    return ImEnumFieldType.RelateToAutoNumber;
                //手動採番
                case Enum処理区分.手動採番:
                    return ImEnumFieldType.MaxPlus1;
                //不祥フラグ登録
                case Enum処理区分.不祥フラグ登録:
                    return ImEnumFieldType.Fusyo;
                //年齢登録_一次申込
                case Enum処理区分.年齢登録_一次申込:
                    return ImEnumFieldType.Age;
                //年齢登録_精密結果
                case Enum処理区分.年齢登録_精密結果:
                    return ImEnumFieldType.SeiAge;
                //年度登録
                case Enum処理区分.年度登録:
                    return ImEnumFieldType.Nendo;

                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 登録区分を取得する
        /// </summary>
        private static ImEnumImportType GetRegupdKbn(string regupdkbn)
        {
            switch (ParseEnum<Enum登録区分>(regupdkbn))
            {
                //削除新規
                case Enum登録区分.削除新規:
                    return ImEnumImportType.DeleteInsert;
                //新規
                case Enum登録区分.新規:
                    return ImEnumImportType.Insert;
                //更新
                case Enum登録区分.更新:
                    return ImEnumImportType.Update;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 実施年齢取得処理（画面特定項目入力後）
        /// </summary>
        private object[]? GetJissiAgeByInputData(DaDbContext db, List<tm_kktorinyuryoku_itemDto> pageItemDtl, List<PageItemBodyModel> pageItemBodyList,
            string ageKbn, string ymdKbn)
        {
            //実施年齢(設定した画面項目)
            var ageDto = pageItemDtl.Find(e => e.itemtokuteikbn == ageKbn);
            if (ageDto != null)
            {
                var data = new DataTable();
                var itemvalues = new List<string?>();
                foreach (var pageItem in pageItemBodyList)
                {
                    //データテーブル列名(データ元画面項目)
                    data.Columns.Add("Column" + pageItem.pageitemseq);
                    itemvalues.Add(pageItem.val);
                }
                data.Rows.Add(itemvalues.ToArray());

                //実施年齢取得処理
                var jissiage = GetJissiAge(db, pageItemDtl, data.Rows[0], ymdKbn);
                if (jissiage != null)
                {
                    //取得先項目ID,取得先項目の値
                    return new object[] { ageDto.gamenitemseq, jissiage };
                }
            }
            return null;
        }

        /// <summary>
        /// 年度取得処理（画面特定項目入力後）
        /// </summary>
        private object[]? GetNendoByInputData(DaDbContext db, List<tm_kktorinyuryoku_itemDto> pageItemDtl, List<PageItemBodyModel> pageItemBodyList,
            string nendoKbn, int pageitemseq)
        {
            var nendoDto = pageItemDtl.Find(e => e.itemtokuteikbn == nendoKbn);
            var dateItem = pageItemBodyList.Find(e => e.pageitemseq == pageitemseq);
            if (nendoDto != null && dateItem != null && !string.IsNullOrEmpty(dateItem.val))
            {
                //年度取得処理
                var nendo = ImFormatUtil.GetNendo(DateTime.Parse(dateItem.val!));
                return new object[] { nendoDto.gamenitemseq, nendo };
            }
            return null;
        }

        /// <summary>
        /// 医療機関コード、検診実施機関番号を取得処理（画面特定項目入力後）
        /// </summary>
        private object[]? GetKikancdByInputData(DaDbContext db, List<tm_kktorinyuryoku_itemDto> pageItemDtl, List<PageItemBodyModel> pageItemBodyList,
            Enum項目特定区分 kikanKbn, int pageitemseq)
        {
            var kikanDto = pageItemDtl.Find(e => e.itemtokuteikbn == EnumToStr(kikanKbn));
            var dateItem = pageItemBodyList.Find(e => e.pageitemseq == pageitemseq);
            if (kikanDto != null && dateItem != null && !string.IsNullOrEmpty(dateItem.val))
            {
                tm_afkikanDto? kikan;
                if (kikanKbn == Enum項目特定区分.医療機関コード)
                {
                    //医療機関コード取得処理
                    kikan = db.tm_afkikan.SELECT.WHERE.ByItem(nameof(tm_afkikanDto.hokenkikancd), DaSelectorService.GetCd(dateItem.val)).GetDto();
                }
                else
                {
                    //検診実施機関番号取得処理
                    kikan = db.tm_afkikan.SELECT.WHERE.ByKey(DaSelectorService.GetCd(dateItem.val)).GetDto();
                }

                if (kikan != null)
                {
                    return new object[] { kikanDto.gamenitemseq, kikanKbn == Enum項目特定区分.医療機関コード ? kikan.kikancd : kikan.hokenkikancd };
                }
            }
            return null;
        }

        /// <summary>
        /// 実施年齢取得処理
        /// </summary>
        private int? GetJissiAge(DaDbContext db, List<tm_kktorinyuryoku_itemDto> pageItemDtl, DataRow dr, string ymdKbn)
        {
            //宛名番号を取得
            var atenano = GetPageItemValue(pageItemDtl, dr, EnumToStr(Enum項目特定区分.宛名番号));
            if (string.IsNullOrEmpty(atenano))
            {
                return null;
            }

            //宛名テーブル
            var afatenaDto = db.tt_afatena.GetDtoByKey(atenano);
            if (afatenaDto == null)
            {
                return null;
            }

            //実施日を取得
            var jissiymd = GetPageItemValue(pageItemDtl, dr, ymdKbn);
            if (string.IsNullOrEmpty(jissiymd))
            {
                return null;
            }

            //実施日
            if (!DateTime.TryParseExact(jissiymd, DaConst.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                return null;
            }
            //生年月日を取得
            var bymd = GetPageItemValue(pageItemDtl, dr, EnumToStr(Enum項目特定区分.生年月日));
            if (string.IsNullOrEmpty(bymd))
            {
                bymd = afatenaDto.bymd;
            }
            if (string.IsNullOrEmpty(bymd))
            {
                return null;
            }

            //実施年齢
            var jissiage = CmLogicUtil.GetAge(afatenaDto.bymd_fusyoflg, bymd, parsedDate);
            return jissiage;
        }

        /// <summary>
        /// 入力画面項目値を取得
        /// </summary>
        private string? GetPageItemValue(List<tm_kktorinyuryoku_itemDto> pageItemDtl, DataRow dr, string itemkbn)
        {
            //設定した画面項目
            var pageItemDto = pageItemDtl.Find(e => e.itemtokuteikbn == itemkbn);
            if (pageItemDto == null)
            {
                return null;
            }
            //画面項目ID
            int pageitemseq = pageItemDto.gamenitemseq;
            return CStr(dr["Column" + pageitemseq]);
        }

        /// <summary>
        /// 関数実行
        /// </summary>
        private string DoProcedure(DaDbContext db, string procnm, object value, string msg)
        {
            try
            {
                var procDto = db.tm_kktorinyuryoku_proc.SELECT.WHERE.ByItem(nameof(tm_kktorinyuryoku_procDto.procnm), procnm).GetDto();
                if (procDto != null)
                {
                    //プロシージャ関数を実行する
                    DaDbUtil.GetProcedureValue(db, procDto.procnm.ToLower(), value);
                }
                else
                {
                    var errMsg = DaMessageService.GetMsg(EnumMessage.E004007, msg);
                    return errMsg;
                }
            }
            catch
            {
                var errMsg = DaMessageService.GetMsg(EnumMessage.E004007, msg);
                return errMsg;
            }
            return string.Empty;
        }

        /// <summary>
        /// 取込データを削除
        /// </summary>
        private void RunSqlDeleteKkimpById(DaDbContext db, string tableName, int impjikkoid)
        {
            //取込データ削除
            var sqlDetailDel = $"DELETE FROM  {tableName} WHERE {nameof(tt_kktorinyuryoku_misyoriitemDto.impjikkoid)} = {impjikkoid}";
            DaDbUtil.RunSql(db, sqlDetailDel);
        }

        /// <summary>
        /// 取込データを削除(一括)
        /// </summary>
        private void RunSqlDeleteKkimpByIds(DaDbContext db, string tableName, List<int> impjikkoidList)
        {
            //取込データ削除
            string impjikkoids = string.Join(",", impjikkoidList);
            var sqlDetailDel = $"DELETE FROM  {tableName} WHERE {nameof(tt_kktorinyuryoku_misyoriitemDto.impjikkoid)} = ANY(ARRAY[{impjikkoids}])";
            DaDbUtil.RunSql(db, sqlDetailDel);
        }

        /// <summary>
        /// 処理内容を取得
        /// </summary>
        private string GetProcessName(ImportProcess processName)
        {
            switch (processName)
            {
                case ImportProcess.FileCheck:
                    return "ファイルチェック";
                case ImportProcess.MappingCheck:
                    return "マッピングチェック";
                case ImportProcess.PageItemCheck:
                    return "画面項目チェック";
                case ImportProcess.SaveWork:
                    return "仮保存";
                case ImportProcess.Save:
                    return "登録実行";
                default:
                    break;
            }
            return "";
        }

        /// <summary>
        /// チェックプロシージャを行う
        /// </summary>
        public string DoCheckProc(DaDbContext db, string procName, int impexeid, DataTable dt, string impno)
        {
            //一括取込入力マスタデータを取得する
            tm_kktorinyuryokuDto kkimpDto = GetKkimpDto(db, impno);

            //一括取込入力項目定義マスタ
            List<tm_kktorinyuryoku_itemDto> pageitemDtl = GetPageItemDtl(db, impno);

            //画面項目データ情報から一時テーブルデータを登録(チェック用)
            CheckWorkData(db.Session, dt, impexeid, kkimpDto, pageitemDtl);

            //チェックプロシージャ
            var msg = DoProcedure(db, procName, impexeid, "チェックプロシージャ");
            return msg;
        }

        /// <summary>
        /// 一時テーブルデータを登録(チェック用)
        /// </summary>
        private void CheckWorkData(AiSessionContext session, DataTable dt, int impexeid, tm_kktorinyuryokuDto kkimpDto, List<tm_kktorinyuryoku_itemDto> pageitemDtl)
        {

            var tmpTableName = TMP_TABLE_NAME_PREFIX + impexeid;
            //一時データテーブル列名を取得
            var columnNameList = GetWorkTableColumnNameList(kkimpDto, pageitemDtl);

            //一時テーブルを作成
            ImDBUtil.CreateTempTab(session, tmpTableName, columnNameList);

            //一時データテーブルを登録
            ImDBUtil.SaveWorkData(session, tmpTableName, dt);
            var datatb = session.GetDataTable($"select * from { tmpTableName }");
        }

        /// <summary>
        /// 一時データテーブル列名を取得
        /// </summary>
        private List<string> GetWorkTableColumnNameList(tm_kktorinyuryokuDto kkimpDto, List<tm_kktorinyuryoku_itemDto> pageitemDtl)
        {
            //列名リスト
            var columnNameList = new List<string>
                {
                    // 行番号
                    "rowno"
                };

            //画面項目名
            foreach (var item in pageitemDtl)
            {
                if (kkimpDto.torinyuryokbn == EnumToStr(Enum取込区分.ファイル取込) && item.inputkbn == EnumToStr(Enum入力区分.コード系))
                {
                    columnNameList.Add(item.wktablecolnm + "_bef");
                }
                columnNameList.Add(item.wktablecolnm);
            }

            return columnNameList;
        }



        /// <summary>
        /// 初期表示年度と最大年度を取得
        /// </summary>
        private (string nendo, string nendomax) GetNendoAndNendomax(DaDbContext db, string nendohanikbn)
        {
            //初期表示年度
            string nendo;
            //最大年度
            string nendomax;

            switch (ParseEnum<Enum年度範囲区分>(nendohanikbn))
            {
                //システム年度~システム年度の場合
                case Enum年度範囲区分.システム年度_システム年度:
                    nendo = CStr(DaUtil.Now.Year);
                    nendomax = CStr(DaUtil.Now.Year);
                    break;

                //システム年度~システム年度 + 1の場合
                case Enum年度範囲区分.システム年度_システム年度Plus1:
                    nendo = CStr(DaUtil.Now.Year);
                    nendomax = CStr(DaUtil.Now.Year + 1);
                    break;

                //メニュー引き継ぐ~コントロールマスタ年度の場合
                case Enum年度範囲区分.メニュー引き継ぐ_コントロールマスタ年度:
                    nendo = string.Empty;
                    nendomax = CStr(DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._02).IntValue1);
                    break;

                default:
                    nendo = string.Empty;
                    nendomax = string.Empty;
                    break;
            }
            return (nendo, nendomax);
        }

        /// <summary>
        /// 一時テーブルデータ用のデータテーブルを取得
        /// </summary>
        /// <param name="db"></param>
        /// <param name="impexeid"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(DaDbContext db, int impexeid, tm_kktorinyuryokuDto kkimpDto, List<tm_kktorinyuryoku_itemDto> pageitemDtl, string? flg)
        {
            DataTable dt = new();
            dt.Columns.Add("RowNo");
            //一括取込入力エラーテーブルのデータを取得する
            List<tt_kktorinyuryoku_errDto> tt_kkimpdataerrDtl = GetKkimpDataErrDtl(db, impexeid);
            //取込データ詳細情報はDBから全てを取得する
            List<tt_kktorinyuryoku_misyoriitemDto> kkimpdatadetailDtl = GetKkimpDataDetailDtl(db, impexeid);
            if(flg != null)
            {
                //エラー件数
                List<int> errRowList = tt_kkimpdataerrDtl.Where(e => e.errkbn.Equals(EnumToStr(Enumエラーレベル.エラー))).Select(e => e.rowno).Distinct().ToList();
                //取込データ詳細情報(エラー以外)取得
                kkimpdatadetailDtl = kkimpdatadetailDtl.Where(e => !errRowList.Contains(e.rowno)).ToList();
            }
            
            //画面項目(コード変換)を取得する
            List<int> cdChangePageItemSeqList = GetsCdChangePageItemSeqList(pageitemDtl);
            var groupedKkimpdatadetailDtl = kkimpdatadetailDtl.GroupBy(p => p.rowno).ToList();
            for (int i = 0; i < groupedKkimpdatadetailDtl.Count; i++)
            {
                var group = groupedKkimpdatadetailDtl[i];
                var dataList = new List<string?>
                    {
                        group.First().rowno.ToString()//行番号
                    };
                foreach (var item in group)
                {
                    if (i == 0)
                    {
                        if (!cdChangePageItemSeqList.Contains(item.itemseq) || kkimpDto.torinyuryokbn.Equals(EnumToStr(Enum取込区分.一括入力)))
                        {
                            dt.Columns.Add("Column" + item.itemseq);
                        }
                        else if (kkimpDto.torinyuryokbn.Equals(EnumToStr(Enum取込区分.ファイル取込)))
                        {
                            dt.Columns.Add("Column" + item.itemseq + "_bef");
                            dt.Columns.Add("Column" + item.itemseq);
                        }
                    }
                    //コード変換以外の項目の場合
                    if (!cdChangePageItemSeqList.Contains(item.itemseq) || kkimpDto.torinyuryokbn.Equals(EnumToStr(Enum取込区分.一括入力)))
                    {
                        dataList.Add(CStr(item.itemvalue));
                    }
                    else if (kkimpDto.torinyuryokbn.Equals(EnumToStr(Enum取込区分.ファイル取込)))
                    {
                        //変換前後の値(コード変換)
                        var values = CStr(item.itemvalue).Split(",");
                        if (values.Length > 1)
                        {
                            dataList.Add(values[0]);
                            dataList.Add(values[1]);
                        }
                        else
                        {
                            dataList.Add("");
                            dataList.Add("");
                        }
                    }
                }
                dt.Rows.Add(dataList.ToArray());
            }
            return dt;
        }
    }
}