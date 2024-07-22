// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 汎用情報保守
// 　　　　　　サービス処理
// 作成日　　: 2024.07.28
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00801G
{
    [DisplayName("汎用情報保守")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWAF00801G = "AWAF00801G";

        [DisplayName("メインコード初期化処理")]
        public InitMainCodeResponse InitMainCode(InitMainCodeRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitMainCodeResponse();
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(メインコード)
                res.selectorlist = DaNameService.GetSelectorList(db, EnumNmKbn.汎用マスタメインコード, req.kbn);

                //EXCEL出力フラグ
                res.exceloutflg = CmLogicUtil.GetExceloutflg(db, req.token, req.userid, req.regsisyo, AWAF00801G);

                //正常返し
                return res;
            });
        }

        [DisplayName("サブコード初期化処理")]
        public InitSubCodeResponse InitSubCode(InitSubCodeRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitSubCodeResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //汎用メインマスタ
                var dtl = db.tm_afhanyo_main.SELECT.WHERE.ByKey(req.hanyomaincd).ORDER.By(nameof(tm_afhanyo_mainDto.hanyosubcd)).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(サブコード)
                res.selectorlist = Wraper.GetSelectorList(dtl, req.kbn);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var hanyomaincd = DaSelectorService.GetCd(req.hanyomaincd);     //汎用メインコード
                var hanyosubcd = CInt(DaSelectorService.GetCd(req.hanyosubcd)); //汎用サブコード
                //汎用マスタ
                var dtl = DaHanyoService.GetHanyoDtl(db, hanyomaincd, CInt(hanyosubcd));

                //汎用メインマスタ
                var mainDto = db.tm_afhanyo_main.GetDtoByKey(hanyomaincd, hanyosubcd);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面項目設定(ヘッダー部)
                Wraper.SetHeader(res, mainDto);

                //ユーザ領域開始コードがある場合
                if (mainDto.userryoikikaisicd != null)
                {
                    //最大汎用コード
                    res.maxHanyocd = CmLogicUtil.GetUserRyoikiMaxCd(mainDto.keta);
                }

                //画面項目設定(明細部)
                res.kekkalist = Wraper.GetVMList(dtl, mainDto);
                //汎用データリスト(ロック用)
                res.locklist = res.kekkalist.Select(e => new LockVM(e.hanyocd, e.upddttm)).ToList();

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return CommonSave(db, req);
            });
        }

        [DisplayName("サブコード情報登録(初期処理)")]
        public InitSubCodeInfoResponse InitSubCodeInfo(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitSubCodeInfoResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                if(!string.IsNullOrEmpty(req.hanyomaincd) && !string.IsNullOrEmpty(req.hanyosubcd))
                {
                    var hanyomaincd = DaSelectorService.GetCd(req.hanyomaincd);     //汎用メインコード
                    var hanyosubcd = CInt(DaSelectorService.GetCd(req.hanyosubcd)); //汎用サブコード

                    //汎用メインマスタ
                    var mainDto = db.tm_afhanyo_main.GetDtoByKey(hanyomaincd, hanyosubcd);
                    res.subcdInfoVM = Wraper.GetSubCodeIndo(mainDto);
                }

                //ドロップダウンリスト(メインコード)
                res.maincdlist = DaNameService.GetSelectorList(db, EnumNmKbn.汎用マスタメインコード, Enum名称区分.名称);

                //正常返し
                return res;
            });
        }

        [DisplayName("サブコード情報登録(保存処理)")]
        public DaResponseBase SaveSubCodeInfo(SaveSubCodeInfoRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new InitSubCodeInfoResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------

                //サブコード情報
                var info = req.subcdInfoVM;
                //汎用メインコード
                var hanyomaincd = DaSelectorService.GetCd(info.hanyomaincd);  
                
                //既存汎用メインマスタ情報を取得
                var oldDto = db.tm_afhanyo_main.GetDtoByKey(hanyomaincd, info.hanyosubcd);
                if ((req.editkbn == Enum編集区分.新規 && oldDto != null)
                    || (req.editkbn == Enum編集区分.変更 && oldDto == null))
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, "サブコード");
                    res.SetServiceError(msg);
                    return res;
                }

                //既存汎用サブコード名称を取得
                var filter = $"{nameof(tm_afhanyo_mainDto.hanyosubcdnm)} = '{info.hanyosubcdnm}'";
                oldDto = db.tm_afhanyo_main.SELECT.WHERE.ByFilter(filter).GetDto();
                if ((req.editkbn == Enum編集区分.新規 &&  oldDto != null) 
                || (req.editkbn == Enum編集区分.変更 && oldDto != null && !(oldDto.hanyomaincd == info.hanyomaincd && oldDto.hanyosubcd == info.hanyosubcd)))
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, "サブコード名称");
                    res.SetServiceError(msg);
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ加工
                //-------------------------------------------------------------
                //汎用メインマスタ情報を取得
                var mainDto = Converter.GetMainDto(info);

                if (req.editkbn == Enum編集区分.新規)
                {
                    //汎用メインマスタ登録
                    db.tm_afhanyo_main.INSERT.Execute(mainDto);
                }
                else
                {
                    //汎用メインマスタ登録
                    db.tm_afhanyo_main.UPDATE.Execute(mainDto);
                }

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 汎用マスタ保存処理(共通)
        /// </summary>
        public DaResponseBase CommonSave(DaDbContext db, SaveRequest req)
        {
            var res = new DaResponseBase();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //汎用コードリスト取得
            var hanyocdList = req.locklist.Select(d => d.hanyocd).Union(req.savelist.Select(d => d.hanyocd)).ToList();

            //汎用キーリスト取得
            var hanyomaincd = DaSelectorService.GetCd(req.hanyomaincd);             //汎用メインコード
            var hanyosubcd = int.Parse(DaSelectorService.GetCd(req.hanyosubcd));    //汎用サブコード
            var keyList = Converter.GetKeyList(hanyomaincd, hanyosubcd, hanyocdList);

            //編集前の汎用マスタリスト取得
            var oldDtl = db.tm_afhanyo.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //-------------------------------------------------------------
            //２.チェック処理
            //-------------------------------------------------------------
            if (!Check(req.savelist, req.locklist, oldDtl))
            {
                throw new AiExclusiveException();
            }

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------
            //更新リスト
            var updDtl = Converter.GetDtl(req.savelist, hanyomaincd, hanyosubcd);

            //-------------------------------------------------------------
            //４.DB更新処理
            //-------------------------------------------------------------
            //差分更新
            db.tm_afhanyo.UPDATE.WHERE.ByKeyList(keyList).Execute(updDtl);

            //正常返し
            return res;
        }

        /// <summary>
        /// 排他チェック
        /// </summary>
        private static bool Check(List<HanyoVM> savelist, List<LockVM> locklist, List<tm_afhanyoDto> oldDtl)
        {
            if (locklist.Count != oldDtl.Count) throw new AiExclusiveException();
            foreach (var vm in savelist)
            {
                var lockvm = locklist.Find(d => d.hanyocd == vm.hanyocd);
                if (lockvm == null)
                {
                    //新規排他チェック
                    if (oldDtl.Exists(d => d.hanyocd == vm.hanyocd))
                    {
                        return false;
                    }
                }
                else
                {
                    vm.upddttm = lockvm.upddttm;
                    //更新排他チェック
                    if (!oldDtl.Exists(d => d.hanyocd == vm.hanyocd && d.upddttm == vm.upddttm))
                    {
                        return false;
                    }
                }
            }
            //削除排他チェック
            var delList = locklist.Where(x => savelist.All(s => s.hanyocd != x.hanyocd));
            if (delList.Any(d => oldDtl.Exists(x => x.hanyocd == d.hanyocd && x.upddttm != d.upddttm)))
            {
                return false;
            }
            return true;
        }
    }
}