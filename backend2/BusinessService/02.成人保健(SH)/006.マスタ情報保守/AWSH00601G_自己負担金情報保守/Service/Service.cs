// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 自己負担金情報保守
// 　　　　　　サービス処理
// 作成日　　: 2024.03.05
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00601G
{
    [DisplayName("自己負担金情報保守")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWSH00601G = "AWSH00601G";

        //自己負担金検索
        private const string PROC_NAME = "sp_awsh00601g_01";

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var dtl = db.tm_shjikofutankin.SELECT.GetDtoList();     //自己負担金マスタ

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                int nendo = dtl.Max(x => x.nendo);                      //年度
                res.nendo = nendo;
                res.hikitsudugiflg = CheckHikitsudugi(db, nendo);       //「前年度引続ぎ」活性フラグ
                res.selectorlist1 = GetDtlKensin(db, nendo);            //検診種別
                res.selectorlist2 = GetDtlRyokin(db, nendo);            //料金パターン

                //正常返し
                return res;
            });
        }

        [DisplayName("年度変更処理(一覧画面)")]
        public SearchNendoResponse SearchNendo(SearchNendoRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchNendoResponse();
                //-------------------------------------------------------------
                //1.データ加工処理
                //-------------------------------------------------------------
                res.hikitsudugiflg = CheckHikitsudugi(db, req.nendo);   //「前年度引続ぎ」活性フラグ
                res.selectorlist1 = GetDtlKensin(db, req.nendo);        //検診種別
                res.selectorlist2 = GetDtlRyokin(db, req.nendo);        //料金パターン

                //正常返し
                return res;
            });
        }

        [DisplayName("前年度引継ぎ処理(一覧画面)")]
        public SearchNendoResponse SearchHikitsudugi(SearchHikitsudugiRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchNendoResponse();
                //1.データ加工処理
                //-------------------------------------------------------------
                //自己負担金マスタに前年度の全部データを新年度にコピーして登録
                var copyList = db.tm_shjikofutankin.SELECT.WHERE.ByItem(nameof(tm_shjikofutankinDto.nendo), req.nendo - 1).GetDtoList();
                //コピーできるデータが0件の場合
                if (copyList.Count <= 0)
                {
                    res.SetServiceError(EnumMessage.DATA_NOTEXIST_ERROR, "引継", "登録");

                    //異常返し
                    return res;
                }

                foreach (var dto in copyList)
                {
                    dto.nendo++;
                }
                db.tm_shjikofutankin.DELETE.WHERE.ByItem(nameof(tm_shjikofutankinDto.nendo), req.nendo).Execute();
                db.tm_shjikofutankin.INSERT.Execute(copyList);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(一覧画面)")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //年度マスタ
                var dtl = db.tm_shjikofutankin.SELECT.WHERE.ByItem(nameof(tm_shjikofutankinDto.nendo), req.nendo).GetDtoList();
                var jigyocd = DaSelectorService.GetCd(req.kensin_jigyocd);
                var ryokinpattern = DaSelectorService.GetCd(req.ryokinpattern);             //料金パターン
                res.selectorlist3 = GetKensahoho(db, req.nendo, jigyocd, ryokinpattern);    //ドロップダウンリスト(検査方法)
                var dto = db.tm_shkensinjigyo.SELECT.WHERE.ByKey(jigyocd).GetDto();
                if (dto != null)
                {
                    if (dto.genmenkbn == Enum減免区分種別.特定健診)
                    {
                        res.selectorlist4 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.減免区分_特定健診, Enum名称区分.名称, true);    //ドロップダウンリスト(減免区分＝1(特定健診))
                    }
                    else
                    {
                        res.selectorlist4 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.減免区分_がん検診, Enum名称区分.名称, true);    //ドロップダウンリスト(減免区分＝2(がん検診))
                    }
                }
                res.selectorlist5 = DaNameService.GetSelectorList(db, EnumNmKbn.性別_システム共有, Enum名称区分.名称);                      //ドロップダウンリスト(性別)

                var parameters = Converter.GetParameters(req);
                //一覧データ取得
                var dt = DaDbUtil.GetProcedureData(db, PROC_NAME, parameters);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //自己負担金一覧情報
                res.kekkalist = Wraper.GetVMList(db, dt.Rows);
                //排他チェック用リスト
                res.locklist = Wraper.GetVMList(res.kekkalist, dtl);

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //自己負担金リスト取得
                var kensin_jigyocd = DaSelectorService.GetCd(req.kensin_jigyocd);   //検診種別
                var ryokinpattern = DaSelectorService.GetCd(req.ryokinpattern);     //料金パターン
                var keyList = Converter.GetKeyList(req.nendo, kensin_jigyocd, ryokinpattern, req.locklist);

                //自己負担金マスタ
                var oldDtl = db.tm_shjikofutankin.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (!Check(req.locklist, oldDtl)) throw new AiExclusiveException();

                //検査方法・減免区分・性別が同じ、年齢に被りがあるの重複チェック
                var repflg = RepeatedCheck(req.savelist);
                if (repflg)
                {
                    res.SetServiceError(EnumMessage.E001008, "検査方法・減免区分・性別・年齢範囲");
                    //異常返す
                    return res;
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //更新リスト
                var updDtl = Converter.GetDtl(req.nendo, req.savelist);
                db.tm_shjikofutankin.DELETE.WHERE.ByKeyList(keyList);
                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //差分更新
                db.tm_shjikofutankin.UPDATE.WHERE.ByKeyList(keyList).Execute(updDtl);

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 排他チェック
        /// </summary>
        private static bool Check(List<LockVM> locklist, List<tm_shjikofutankinDto> oldDtl)
        {
            //新規場所
            if (oldDtl.Count <= 0) return true;
            //更新場所
            foreach (var vm in oldDtl)
            {
                //更新時間排他チェック
                if (locklist.Exists(d => d.kensahohocd == vm.kensahohocd
                                      && d.sex == vm.sex
                                      && d.agehani == vm.agehani
                                      && d.genmenkbncd == vm.genmenkbn
                                      && d.upddttm != vm.upddttm))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 検診種別を取得
        /// </summary>
        private List<DaSelectorModel> GetDtlKensin(DaDbContext db, int nendo)
        {
            //成人健（検）診予約日程事業サブマスタ → 検診種別
            var dtl = db.tm_shyoyakujigyo_sub.SELECT.WHERE
                                                    .ByItem(nameof(tm_shyoyakujigyo_subDto.nendo), nendo)
                                                    .GetDtoList().Select(e => e.kensin_jigyocd).Distinct();
            var dtl2 = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.検診種別).Where(e => dtl.Contains(e.hanyocd));
            var dtl3 = dtl2.Select(e => new DaSelectorModel(e.hanyocd, e.nm)).OrderBy(e => e.value).ToList();

            return dtl3;
        }

        /// <summary>
        /// 料金パターンを取得
        /// </summary>
        private List<DaSelectorModel> GetDtlRyokin(DaDbContext db, int nendo)
        {
            //料金パターン
            var dtl = db.tm_shyoyakujigyo.SELECT.WHERE.ByItem(nameof(tm_shyoyakujigyoDto.nendo), nendo)
                                                      .GetDtoList().Select(e => e.ryokinpattern).Distinct();
            var dtl2 = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.料金パターン).Where(e => dtl.Contains(e.hanyocd));
            var dtl3 = dtl2.Select(e => new DaSelectorModel(e.hanyocd, e.nm)).OrderBy(e => e.value).ToList();

            return dtl3;
        }

        /// <summary>
        /// 「前年度引続ぎ」活性判断
        /// </summary>
        private bool CheckHikitsudugi(DaDbContext db, int nendo)
        {
            //前年度のデータがあり、且つ、新年度のデータが登録されていない場合、「前年度引継ぎ」ボタンを活性化表示する
            int maenendo = nendo - 1;
            var dtlFutankin = db.tm_shjikofutankin.SELECT.WHERE.ByItem(nameof(tm_shjikofutankinDto.nendo), maenendo).GetDtoList();
            if (dtlFutankin.Count <= 0) return false;

            var dtl = db.tm_shyoyakujigyo.SELECT.WHERE.ByItem(nameof(tm_shjikofutankinDto.nendo), nendo).GetDtoList();
            var dtlSub = db.tm_shyoyakujigyo_sub.SELECT.WHERE.ByItem(nameof(tm_shjikofutankinDto.nendo), nendo).GetDtoList();
            dtlSub = dtlSub.FindAll(e => dtl.Select(e => e.nendo).Contains(e.nendo)
                                           && dtl.Select(e => e.jigyocd).Contains(e.jigyocd));
            var data = dtlFutankin.FindAll(e => dtlSub.Select(e => e.kensin_jigyocd).Contains(e.kensin_jigyocd)
                                             && dtlSub.Select(e => e.kensahohocd).Contains(e.kensahohocd));

            if (data.Count <= 0) return false;

            return true;
        }

        /// <summary>
        /// 検査方法・減免区分・性別が同じ、年齢に被りがある場合エラーとする
        /// </summary>
        private bool RepeatedCheck(List<RowVM> savelist)
        {
            for (int i = 0; i < savelist.Count; i++)
            {
                for (int j = i + 1; j < savelist.Count; j++)
                {
                    if (AreListsEqual(savelist[i], savelist[j]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 検査方法・減免区分・性別が同じ、年齢行ずつ比較
        /// </summary>
        private bool AreListsEqual(RowVM row1, RowVM row2)
        {
            if (row1.kensahohocd == row2.kensahohocd && row1.genmenkbncd == row2.genmenkbncd 
                                                     && CStrSex(row1.sex) == CStrSex(row2.sex))
            {
                var age1 = row1.agehani.Split(DaStrPool.COMMA);
                var age2 = row2.agehani.Split(DaStrPool.COMMA);
                var list1 = new List<string>();
                var list2 = new List<string>();

                foreach (var agehani in age1)
                {
                    if (agehani.Contains(DaStrPool.DASHED))
                    {
                        var ageStart = CInt(agehani.Split(DaStrPool.DASHED)[0]);
                        var ageEnd = CInt(agehani.Split(DaStrPool.DASHED)[1]);
                        for (var age = ageStart; age <= ageEnd; age++)
                        {
                            list1.Add(CStr(age));
                        }
                    }
                    else
                    {
                        list1.Add(agehani);
                    }
                }

                foreach (var agehani in age2)
                {
                    if (agehani.Contains(DaStrPool.DASHED))
                    {
                        var ageStart = CInt(agehani.Split(DaStrPool.DASHED)[0]);
                        var ageEnd = CInt(agehani.Split(DaStrPool.DASHED)[1]);
                        for (var age = ageStart; age <= ageEnd; age++)
                        {
                            list2.Add(CStr(age));
                        }
                    }
                    else
                    {
                        list2.Add(agehani);
                    }
                }

                if (list1.Intersect(list2).Any()) return true;
            }

            return false;
        }

        /// <summary>
        /// 性別値ソート
        /// </summary>
        private string CStrSex(string sex)
        {
             return string.Join(DaStrPool.COMMA, sex.Split(DaStrPool.COMMA)
                                           .Select(int.Parse)
                                           .OrderBy(n => n));
        }

        /// <summary>
        /// ドロップダウンリスト(検査方法)リストを取得
        /// </summary>
        private List<DaSelectorModel> GetKensahoho(DaDbContext db, int nendo, string jigyocd, string ryokinpattern)
        {
            var list = new List<DaSelectorModel>();
            //成人健（検）診予約日程事業マスタ
            var dtl = db.tm_shyoyakujigyo.SELECT.WHERE.ByFilter($"{nameof(tm_shyoyakujigyoDto.nendo)} = @nendo " +
                                                                 $"And {nameof(tm_shyoyakujigyoDto.ryokinpattern)} = @ryokinpattern"
                                                                 , nendo, ryokinpattern).GetDtoList();
            //成人健（検）診予約日程事業サブマスタ
            var dtl2 = db.tm_shyoyakujigyo_sub.SELECT.WHERE.ByFilter($"{nameof(tm_shyoyakujigyo_subDto.nendo)} = @nendo " +
                                                                 $"And {nameof(tm_shyoyakujigyo_subDto.kensin_jigyocd)} = @kensin_jigyocd"
                                                                 , nendo, jigyocd).GetDtoList();
            //予約日程検査方法
            var dtlKensahoho = dtl2.Where(e => dtl.Select(e => e.jigyocd).Contains(e.jigyocd)).Select(d => d.kensahohocd).ToList();

            //検査方法
            var maincd = AWKK00801G.Service.MAINCD1;
            var subcd = CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, jigyocd);
            var dtlhanyo = db.tm_afhanyo.SELECT.WHERE.ByKey(maincd, subcd).GetDtoList();
            list = dtlhanyo.Where(e => dtlKensahoho.Contains(e.hanyocd)).Select(e => new DaSelectorModel(e.hanyocd, e.nm)).ToList();

            return list;
        }
    }
}