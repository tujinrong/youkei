// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検診結果管理
// 　　　　　　サービス処理
// 作成日　　: 2024.07.23
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using Castle.Core.Logging;
using System.Linq;
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH001
{
    [DisplayName("検診結果管理")]
    public class Service : CmServiceBase
    {
        //通年項目の検診回数：0
        public const int TSUNEN = 0;

        //コントロールメッセージID
        private const string CTRL_MSG_ID = "AF_FreeItem";       //フリー項目
        private const string CTRL_MSG_ID2 = "SH_Nendo1";        //年度チェック(一次)
        private const string CTRL_MSG_ID3 = "SH_Nendo2";        //年度チェック(精密)
        private const string CTRL_MSG_ID4 = "SH_KensinKekka";   //一次結果チェック
        private const string CTRL_MSG_ID5 = "SH_KensinExist";   //一次検診結果存在チェック
        private const string CTRL_MSG_ID6 = "SH_KensinKekkaChange";   //一次健診結果を要精密→要精密以外チェック

        //検索処理(各回目のベース情報)
        private const string PROC_NAME = "sp_awsh001_01";

        /// <summary>
        /// 事前処理(ログ)
        /// </summary>
        public override void BeforeAction(DaDbContext db, DaRequestBase req)
        {
            req.Service = req.kinoid!;
            //機能名を取得
            req.ServiceDesc = db.tm_afkino.GetDtoByKey(req.kinoid!).hyojinm;
            db.Session.SessionData[DaConst.SessionID] = req.sessionid;
            DaDbLogService.WriteDbMessage(db, "Begin Service");
        }

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(InitListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //事業コード取得
                var jigyocd = GetJigyocd(db, req.kinoid!);

                //正常返し
                return InitList(db, req, jigyocd, req.kinoid!);
            });
        }

        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //事業コード取得
                var jigyocd = GetJigyocd(db, req.kinoid!);

                //正常返し
                return Search(db, req, jigyocd, req.kinoid!);
            });
        }

        [DisplayName("初期化処理(詳細画面)")]
        public InitDetailResponse InitDetail(InitDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //事業コード取得
                var jigyocd = GetJigyocd(db, req.kinoid!);

                //正常返し
                return InitDetail(db, req, jigyocd, req.kinoid!);
            });
        }

        [DisplayName("保存処理")]
        public CommonResponse Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //事業コード取得
                var jigyocd = GetJigyocd(db, req.kinoid!);

                //正常返し
                return Save(db, req, jigyocd, req.kinoid!);
            });
        }

        [DisplayName("削除処理")]
        public CommonResponse Delete(DeleteRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //事業コード取得
                var jigyocd = GetJigyocd(db, req.kinoid!);

                //正常返し
                return Delete(db, req, jigyocd, req.kinoid!);
            });
        }

        [DisplayName("基準値取得処理")]
        public GetKijunResponse GetKijun(GetKijunRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //事業コード取得
                var jigyocd = GetJigyocd(db, req.kinoid!);

                //正常返し
                return GetKijun(db, req, jigyocd);
            });
        }

        [DisplayName("実施年齢取得処理")]
        public GetAgeResponse GetAge(GetAgeRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return GetAge(db, req);
            });
        }

        [DisplayName("精密検診チェック処理")]
        public SeiKenEditCheckResponse SeiKenEditCheck(SeiKenEditCheckRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //事業コード取得
                var jigyocd = GetJigyocd(db, req.kinoid!);

                //正常返し
                return SeiKenEditCheck(db, req, jigyocd);
            });
        }

        [DisplayName("計算処理")]
        public CalculateResponse Calculate(CalculateRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //事業コード取得
                var jigyocd = GetJigyocd(db, req.kinoid!);

                //正常返し
                return Calculate(db, req, jigyocd);
            });
        }

        [DisplayName("新規追加権限チェック処理")]
        public AuthCheckResponse KensinAuthCheck(AuthCheckRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //URL遷移用
                var res = new AuthCheckResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //事業コード取得
                var jigyocd = GetJigyocd(db, req.kinoid!);

                //一次
                var ct1 = db.tt_shkensin.SELECT.WHERE.ByKey(jigyocd, req.atenano, req.nendo).GetCount();
                //精密
                var ct2 = db.tt_shseiken.SELECT.WHERE.ByKey(jigyocd, req.atenano, req.nendo).GetCount();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //新規追加権限チェックフラグ
                res.authflg = !(ct1 == 0 && ct2 == 0);

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// がん検診事業コード取得
        /// </summary>
        private string GetJigyocd(DaDbContext db, string kinoid)
        {
            var jigyocd = db.tm_afkino.GetDtoByKey(kinoid).hanyokbn;
            return jigyocd!;
        }

        /// <summary>
        /// 初期化処理(一覧画面)
        /// </summary>
        private InitListResponse InitList(DaDbContext db, InitListRequest req, string jigyocd, string kinoid)
        {
            var res = new InitListResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //成人健（検）診事業マスタ
            var dto = db.tm_shkensinjigyo.GetDtoByKey(jigyocd);
            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //表示フラグ設定
            res.showflg1 = (dto.seikenjissikbn == Enum精密検査実施区分.実施);

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(一覧画面)
        /// </summary>
        private SearchResponse Search(DaDbContext db, SearchRequest req, string jigyocd, string kinoid)
        {
            var res = new SearchResponse();
            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            if (!string.IsNullOrEmpty(req.atenano))
            {
                //宛名テーブル
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し
            }

            //-------------------------------------------------------------
            //２.条件設定
            //-------------------------------------------------------------
            //個人番号復号化
            req.SetPersonalno();
            //固定の検索条件
            var fixedCondition = Common.Converter.GetFixedCondition(req);
            //詳細の検索条件
            var conditon = CmSearchUtil.GetSearchJyoken(db, kinoid, req.syosailist, fixedCondition, req.pagenum, req.pagesize);
            //連絡先の事業コード
            var renraku_jigyocd = CmLogicUtil.GetRenrakujigyocd(db, kinoid);

            //-------------------------------------------------------------
            //３.データ取得
            //-------------------------------------------------------------
            //検索結果
            var result = DaFreeQuery.GetKensinQuery(db, renraku_jigyocd, req.nendo, jigyocd, conditon, req.orderby, true);
            //総件数
            var total = result.Count;
            //検診結果一覧
            var pageData = result.Data;
            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);
            //住所表記フラグ
            var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            //ページャー設定
            res.SetPageInfo(total, req.pagesize);
            //画面項目設定
            res.kekkalist = Wraper.GetVMList(db, pageData.Rows, alertviewflg, adrsFlg);
            //検索結果が一人の場合、詳細画面へ遷移する
            res.transflg = total > 0 && res.kekkalist.DistinctBy(e => e.atenano).Count() == 1;

            //正常返し
            return res;
        }

        /// <summary>
        /// 初期化処理(詳細画面)
        /// </summary>
        private InitDetailResponse InitDetail(DaDbContext db, InitDetailRequest req, string jigyocd, string kinoid)
        {
            var res = new InitDetailResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //宛名
            var afatenaDto = db.tt_afatena.GetDtoByKey(req.atenano);
            //存在チェック
            if (!CmCheckService.CheckDeleted(res, afatenaDto, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し

            //コントロールメッセージ
            var msgDto = DaMsgControlService.GetMsgDto(db, CTRL_MSG_ID);

            //部署（支所）別更新権限
            var autnVM = CmLogicUtil.GetAuthVM(db, req.token, req.userid, req.regsisyo, kinoid);

            //パラメータ取得
            var param = Converter.GetParameters(req, jigyocd);
            //検診結果一覧取得(1人)
            var dt = DaDbUtil.GetProcedureData(db, PROC_NAME, param);

            //登録支所
            var dtl1 = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.部署_支所);
            //検査方法
            var dtl2 = DaHanyoService.GetHanyoDtl(db, AWKK00801G.Service.MAINCD1,
                        CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, jigyocd));

            //全回目のベース情報
            var timeVMList = Wraper.GetVMList(dt.Rows, dtl1, dtl2);

            //該当回目
            var timeVM = new KsTimeVM();
            if (req.kensinkaisu == null)
            {
                //初回画面遷移の場合、最新
                if (req.kbn == Enum遷移区分.初期化 && timeVMList.Any())
                {
                    timeVM = timeVMList[^1];
                }
            }
            else
            {
                //排他チェック：回目切り替え時、該当回目既に削除された場合
                timeVM = timeVMList.Find(x => x.kensinkaisu == req.kensinkaisu);
                //存在チェック
                if (!CmCheckService.CheckDeleted(res, timeVM, EnumMessage.DATA_NOTEXIST_ERROR, "受診情報", "参照"))
                {
                    //異常返し
                    return res;
                }
            }

            //フリー項目マスタ
            var freeMstDtl = db.tm_shfreeitem.SELECT.WHERE.ByKey(jigyocd).GetDtoList();
            freeMstDtl = freeMstDtl.Where(e => (!e.rirekiflg ||         //通年項目
                                                (e.rirekiflg &&         //通年項目以外：有効期限絞り
                                                (e.hyojinendof == null || e.hyojinendof <= req.nendo) &&
                                                (e.hyojinendot == null || e.hyojinendot >= req.nendo)))).
                                                OrderByDescending(e => e.haitiflg)  //表示順ソート：固定項目
                                                .ThenBy(e => e.groupid)             //表示順ソート：kensinkbn
                                                .ThenBy(e => e.orderseq).ToList();  //表示順ソート：並び順

            //成人保健検診結果（フリー項目）テーブル
            var keyList = new List<object[]>();
            foreach (var item in freeMstDtl)
            {
                //通年項目の場合、年度：0、検診回数：0
                var nendo = TSUNEN;
                var kensinkaisu = TSUNEN;
                if (item.rirekiflg)
                {
                    nendo = req.nendo;
                    kensinkaisu = CInt(timeVM!.kensinkaisu);
                }
                keyList.Add(new object[] { jigyocd, req.atenano, nendo, kensinkaisu, item.itemcd });
            }
            //全項目データ
            var dataDtl = db.tt_shfree.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //暗号化
            var publickey = string.Empty;   //公開キー(暗号化)
            var privatekey = string.Empty;  //秘密キー(復号化)
            //キー取得
            DaEncryptUtil.GeneratePemRsaKeyPair(out publickey, out privatekey);

            //一次結果チェック区分
            var kbn = DaMsgControlService.GetMsgDto(db, CTRL_MSG_ID4).msgkbn;

            //成人健（検）診事業マスタ
            var jigyoDto = db.tm_shkensinjigyo.GetDtoByKey(jigyocd);

            //健（検）診予約希望者詳細フラグを取得
            var kensinkibosyasyosaiflg = db.tt_shkensinkibosyasyosai.SELECT.WHERE
                .ByFilter($"{ nameof(tt_shkensinkibosyasyosaiDto.nendo) } = { req.nendo } " +
                $"AND { nameof(tt_shkensinkibosyasyosaiDto.atenano) } = '{ afatenaDto.atenano }' " +
                $"AND { nameof(tt_shkensinkibosyasyosaiDto.jigyocd) } = '{ jigyocd }'")
                .Exists();

            //成人健（検）診事業マスタを取得
            var tm_shkensinjigyoDto = db.tm_shkensinjigyo.SELECT.WHERE.ByKey(jigyocd).GetDto();
            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            res.headerinfo = Wraper.GetHeaderVM(db, afatenaDto, autnVM.personalflg, autnVM.alertviewflg, publickey, kensinkibosyasyosaiflg);    //個人基本情報

            res.keylist = timeVMList.Cast<KsLockVM>().ToList();                                                         //全ての回目
            res.kekka = Wraper.GetVM(db, timeVM!, freeMstDtl, dataDtl, kinoid);                                         //該当回目の検診結果

            //成人保健フリー項目グループ１リスト
            res.grouplist1 = DaNameService.GetSelectorList(db, EnumNmKbn.成人保健フリー項目グループ１, Enum名称区分.名称);
            //成人保健フリー項目グループ２リスト
            
            if (!string.IsNullOrEmpty(tm_shkensinjigyoDto.groupid2_maincd) && !string.IsNullOrEmpty(CStr(tm_shkensinjigyoDto.groupid2_subcd)))
            {
            res.grouplist2 = DaHanyoService.GetSelectorList(db, tm_shkensinjigyoDto.groupid2_maincd, CInt(tm_shkensinjigyoDto.groupid2_subcd), Enum名称区分.名称);
            }
            else
            {
                res.grouplist2 = new List<DaSelectorModel>();
            }
            //検査方法一覧
            if (!string.IsNullOrEmpty(tm_shkensinjigyoDto.kensahoho_maincd) && !string.IsNullOrEmpty(CStr(tm_shkensinjigyoDto.kensahoho_subcd)))
            {
                res.selectorlist = DaHanyoService.GetSelectorList(db, tm_shkensinjigyoDto.kensahoho_maincd, CInt(tm_shkensinjigyoDto.kensahoho_subcd), Enum名称区分.名称);
            }
            else
            {
                res.selectorlist = new List<DaSelectorModel>();
            }
            //複数可能フラグ
            res.addflg = DaControlService.GetRow(db, EnumCtrlKbn.検診事業の複数回数指定, jigyocd).BoolValue1;
            //編集フラグ(一次：権限)
            res.editflg1 = string.IsNullOrEmpty(timeVM!.regsisyo1) || autnVM.editSisyos.Contains(timeVM!.regsisyo1);
            //編集フラグ(精密：権限)
            res.editflg2 = string.IsNullOrEmpty(timeVM!.regsisyo2) || autnVM.editSisyos.Contains(timeVM!.regsisyo2);
            //削除フラグ(削除ボタン)
            res.delflg = timeVMList.Any() && timeVMList.All(y =>
                                   (string.IsNullOrEmpty(y.regsisyo1) || autnVM.editSisyos.Contains(y.regsisyo1)) &&
                                   (string.IsNullOrEmpty(y.regsisyo2) || autnVM.editSisyos.Contains(y.regsisyo2)));
            res.errormsgid = msgDto.errormsgid;     //エラーメッセージID
            res.alertmsgid = msgDto.alertmsgid;     //アラートメッセージID

            //表示フラグ設定
            res.showflg1 = (jigyoDto.seikenjissikbn == Enum精密検査実施区分.実施);    //精密(一次必ず存在)
            res.showflg2 = (jigyoDto.cuponhyojikbn == Enum画面表示区分.表示);         //クーポン
            res.showflg3 = jigyoDto.kensahoho_setflg;                                 //一次検査方法

            //クーポン番号を取得
            if (res.showflg2)
            {
                string[] itemNames = new string[] { nameof(tt_kkhakkenDto.nendo), nameof(tt_kkhakkenDto.hakkendatasyosaikbn), nameof(tt_kkhakkenDto.atenano) };
                List<object[]> valuesList = new() { new object[] { req.nendo, jigyocd, req.atenano } };
                //年度、宛名番号、発券データ詳細（検診種別）より発券情報から取得して(複数の場合、抽出対象コードが一番小さいデータを表示)
                var dto = db.tt_kkhakken.SELECT.WHERE.ByItemList(itemNames, valuesList).ORDER.By(nameof(tt_kkhakkenDto.tyusyututaisyocd)).GetDto();
                res.coupon = dto?.hakkenno ?? null;
            }

            //rsaキー
            res.rsaprivatekey = privatekey;

            //一次結果項目リスト(一次固定)
            var keyList1 = res.kekka.itemlist1.Where(e => e.komokutokuteikbn == "01" || e.komokutokuteikbn == "02").Select(e => new KsKekkaItemVM { itemcd = e.itemcd, value = CStr(e.value) }).ToList();
            //一次結果項目リスト(一次フリー)
            var keyList2 = res.kekka.itemlist3.Where(e => (e.komokutokuteikbn == "01" || e.komokutokuteikbn == "02") && e.groupid == EnumKensinKbn.一次).Select(e => new KsKekkaItemVM { itemcd = e.itemcd, value = CStr(e.value) }).ToList();
            //一次結果項目リスト(全部)
            var kekkalist = keyList1.Concat(keyList2).ToList();

            //個人番号操作フラグ
            var pFlg = autnVM.personalflg && CmLogicUtil.GetPersonalnoFlg(db, req.atenano);
            //宛名ログ記録
            DaDbLogService.WriteAtenaLog(db, req.atenano, pFlg, EnumAtenaActionType.検索);

            //正常返し
            return res;
        }

        /// <summary>
        /// 保存処理(詳細画面)
        /// </summary>
        private CommonResponse Save(DaDbContext db, SaveRequest req, string jigyocd, string kinoid)
        {
            var res = new CommonResponse();
            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            if (req.checkflg)
            {
                var jissiymd1 = req.kekka.jissiymd1;    //実施日(一次)
                var jissiymd2 = req.kekka.jissiymd2;    //実施日(精密)

                //年度チェック
                if (jissiymd1 != null && !CmLogicUtil.CheckNendo(req.nendo, jissiymd1!.Value))
                {
                    res = DaMsgControlService.GetNotOkResponse<CommonResponse>(db, CTRL_MSG_ID2);
                    //異常返し
                    if (res.returncode != EnumServiceResult.Hidden)
                    {
                        return res;
                    }
                }
                if (jissiymd2 != null && req.nendo > GetNendo(jissiymd2))
                {
                    res = DaMsgControlService.GetNotOkResponse<CommonResponse>(db, CTRL_MSG_ID3);
                    //異常返し
                    if (res.returncode != EnumServiceResult.Hidden)
                    {
                        return res;
                    }

                }

                //一次結果チェック区分
                var dto = DaMsgControlService.GetMsgDto(db, CTRL_MSG_ID4);
                //編集フラグ(精密：一次結果)
                var editflg = GetSeikenEditFlg(db, req.kekka.kekkalist, jigyocd, dto.msgkbn);
                if (req.dataflg1 && req.dataflg2 && !editflg)
                {
                    res = GetResponse(db, dto, res);
                    //異常返し
                    if (res.returncode != EnumServiceResult.Hidden)
                    {
                        return res;
                    }
                }

                //正常返し
                return res;
            }

            //状態リセット
            res = new CommonResponse();

            //-------------------------------------------------------------
            //２.データ取得
            //-------------------------------------------------------------
            //データ操作区分取得
            var kbn1 = Converter.GetKBN(req.kekka.upddttm1, req.editflg1);   //一次
            var kbn2 = Converter.GetKBN(req.kekka.upddttm2, req.editflg2);   //精密

            //結果テーブルキーリスト取得
            var keyList1 = Converter.GetKeyList(jigyocd, req.atenano, req.nendo, req.kekka.itemlist1, kbn1, req.kensinkaisu);   //一次
            var keyList2 = Converter.GetKeyList(jigyocd, req.atenano, req.nendo, req.kekka.itemlist2, kbn2, req.kensinkaisu);   //精密
            var keyList = new List<object[]>().Concat(keyList1).Concat(keyList2).ToList();                                      //全て

            //成人保健一次検診結果（固定項目）テーブル
            tt_shkensinDto? oldDto1 = null;
            //更新の場合
            if (kbn1 == EnumActionType.Update)
            {
                oldDto1 = db.tt_shkensin.GetDtoByKey(jigyocd, req.atenano, req.nendo, req.kensinkaisu);
                //存在チェック=>排他とする
                if (oldDto1 == null) throw new AiExclusiveException();
            }

            //成人保健精密検査結果（固定項目）テーブル
            tt_shseikenDto? oldDto2 = null;
            //更新の場合
            if (kbn2 == EnumActionType.Update)
            {
                oldDto2 = db.tt_shseiken.GetDtoByKey(jigyocd, req.atenano, req.nendo, req.kensinkaisu);
                //存在チェック=>排他とする
                if (oldDto2 == null) throw new AiExclusiveException();
            }

            //権限関連
            var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, kinoid);

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------
            //成人保健一次検診結果（固定項目）テーブル
            var dto1 = new tt_shkensinDto();
            //更新の場合
            if (kbn1 == EnumActionType.Update)
            {
                dto1 = oldDto1!;
            }
            if (kbn1 != null && kbn1 != EnumActionType.Delete) dto1 = Converter.GetDto(dto1, jigyocd, req.kensinkaisu, req);

            //成人保健精密検査結果（固定項目）テーブル
            var dto2 = new tt_shseikenDto();
            //更新の場合
            if (kbn2 == EnumActionType.Update)
            {
                dto2 = oldDto2!;
            }
            if (kbn2 != null && kbn2 != EnumActionType.Delete) dto2 = Converter.GetDto(dto2, jigyocd, req.kensinkaisu, req);

            //成人保健検診結果（フリー項目）テーブル
            var dtl1 = new List<tt_shfreeDto>();    //一次
            if (kbn1 != null && kbn1 != EnumActionType.Delete)
            {
                dtl1 = Converter.GetDtl(db, keyList1!, req.kekka.itemlist1, req.nendo, req.atenano, jigyocd, req.kensinkaisu, EnumKensinKbn.一次);
            }
            var dtl2 = new List<tt_shfreeDto>();    //精密
            if (kbn2 != null && kbn2 != EnumActionType.Delete)
            {
                dtl2 = Converter.GetDtl(db, keyList2!, req.kekka.itemlist2, req.nendo, req.atenano, jigyocd, req.kensinkaisu, EnumKensinKbn.精密);
            }
            var dtl = dtl1.Concat(dtl2).ToList();   //全て

            //-------------------------------------------------------------
            //４.DB更新処理
            //-------------------------------------------------------------
            //成人保健一次検診結果（固定項目）テーブル
            //新規の場合
            if (kbn1 == EnumActionType.Insert)
            {
                db.tt_shkensin.INSERT.Execute(dto1);
            }
            //更新の場合
            else if (kbn1 == EnumActionType.Update)
            {
                db.tt_shkensin.UpdateDto(dto1, req.kekka.upddttm1!.Value);
            }
            //削除の場合
            else if (kbn1 == EnumActionType.Delete)
            {
                db.tt_shkensin.DeleteByKey(jigyocd, req.atenano, req.nendo, req.kekka.kensinkaisu!.Value, req.kekka.upddttm1!.Value);
            }

            //成人保健精密検査結果（固定項目）テーブル
            //新規の場合
            if (kbn2 == EnumActionType.Insert)
            {
                db.tt_shseiken.INSERT.Execute(dto2);
            }
            //更新の場合
            else if (kbn2 == EnumActionType.Update)
            {
                db.tt_shseiken.UpdateDto(dto2, req.kekka.upddttm2!.Value);
            }
            //削除の場合
            else if (kbn2 == EnumActionType.Delete)
            {
                db.tt_shseiken.DeleteByKey(jigyocd, req.atenano, req.nendo, req.kekka.kensinkaisu!.Value, req.kekka.upddttm2!.Value);
            }

            //成人保健検診結果（フリー項目）テーブル
            db.tt_shfree.UPDATE.WHERE.ByKeyList(keyList).Execute(dtl);

            //宛名ログ記録
            var kbn = EnumAtenaActionType.更新;
            //一次/精密のいずれかデータを追加する場合、新規追加と記録
            if ((kbn1 == EnumActionType.Insert || (kbn1 == null && !CBool(req.editflg1))) &&
                (kbn2 == EnumActionType.Insert || (kbn2 == null && !CBool(req.editflg2))))
            {
                kbn = EnumAtenaActionType.追加;
            }

            //状態列判断用
            res.atenano = req.atenano;                                              //宛名番号
            res.statuslist = Wraper.GetVMList(kbn, req.kensinkaisu);

            //個人番号操作フラグ
            var pFlg = personalflg && CmLogicUtil.GetPersonalnoFlg(db, req.atenano);
            DaDbLogService.WriteAtenaLog(db, req.atenano, pFlg, kbn);

            //正常返し
            return res;
        }

        /// <summary>
        /// 削除処理(詳細画面)
        /// </summary>
        private CommonResponse Delete(DaDbContext db, DeleteRequest req, string jigyocd, string kinoid)
        {
            var res = new CommonResponse();
            //-------------------------------------------------------------
            //１.データ取得(排他)
            //-------------------------------------------------------------
            //キーリスト(排他用)
            var keyList1 = new List<object[]>();
            var locklist = req.locklist.OrderBy(e => e.kensinkaisu).ToList();
            foreach (var vm in locklist)
            {
                keyList1.Add(new object[] { jigyocd, req.atenano, req.nendo, vm.kensinkaisu! });
            }

            //成人保健一次検診結果（固定項目）テーブル
            var oldDtl1 = db.tt_shkensin.SELECT.WHERE.ByKeyList(keyList1).GetDtoList();
            //成人保健精密検査結果（固定項目）テーブル
            var oldDtl2 = db.tt_shseiken.SELECT.WHERE.ByKeyList(keyList1).GetDtoList();

            //画面排他キー
            var vmList1 = req.locklist.Where(d => d.upddttm1 != null).Select(e => (e.kensinkaisu, e.upddttm1)).ToList();  //一次
            var vmList2 = req.locklist.Where(d => d.upddttm2 != null).Select(e => (e.kensinkaisu, e.upddttm2)).ToList();  //精密
            //DB排他キー
            var dbList1 = oldDtl1.Select(e => (e.kensinkaisu, e.upddttm)).ToList();    //一次
            var dbList2 = oldDtl2.Select(e => (e.kensinkaisu, e.upddttm)).ToList();    //精密

            //-------------------------------------------------------------
            //２.チェック処理
            //-------------------------------------------------------------
            if (!Check(vmList1, dbList1) || !Check(vmList2, dbList2))
            {
                throw new AiExclusiveException();
            }

            //-------------------------------------------------------------
            //３.データ取得
            //-------------------------------------------------------------
            //キーリスト(削除用)
            var keyList2 = new List<object[]>();
            foreach (var vm in locklist)
            {
                if (req.delkbn == Enum削除区分.単一削除 && vm.kensinkaisu >= req.kensinkaisu)
                {
                    keyList2.Add(new object[] { jigyocd, req.atenano, req.nendo, vm.kensinkaisu! });
                }
            }
            //成人保健一次検診結果（固定項目）テーブル
            var dtl1 = new List<tt_shkensinDto>();
            //成人保健精密検査結果（固定項目）テーブル
            var dtl2 = new List<tt_shseikenDto>();
            //成人保健検診結果（フリー項目）テーブル
            var dtl3 = new List<tt_shfreeDto>();
            if (req.delkbn == Enum削除区分.単一削除)
            {
                //成人保健一次検診結果（固定項目）テーブル
                dtl1 = db.tt_shkensin.SELECT.WHERE.ByKeyList(keyList2).GetDtoList();
                //成人保健精密検査結果（固定項目）テーブル
                dtl2 = db.tt_shseiken.SELECT.WHERE.ByKeyList(keyList2).GetDtoList();
                //成人保健検診結果（フリー項目）テーブル
                dtl3 = db.tt_shfree.SELECT.WHERE.ByKeyList(keyList2).GetDtoList();
            }

            //権限関連
            var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, kinoid);

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            if (req.delkbn == Enum削除区分.単一削除)
            {
                //成人保健一次検診結果（固定項目）テーブル
                dtl1 = Converter.GetDtl(dtl1, req.kensinkaisu!.Value);
                //成人保健精密検査結果（固定項目）テーブル
                dtl2 = Converter.GetDtl(dtl2, req.kensinkaisu!.Value);
                //成人保健検診結果（フリー項目）テーブル
                dtl3 = Converter.GetDtl(dtl3, req.kensinkaisu!.Value);
            }

            //-------------------------------------------------------------
            //５.DB更新処理
            //-------------------------------------------------------------
            if (req.delkbn == Enum削除区分.全削除)
            {
                //成人保健一次検診結果（固定項目）テーブル
                db.tt_shkensin.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.nendo).Execute();
                //成人保健精密検査結果（固定項目）テーブル
                db.tt_shseiken.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.nendo).Execute();
                //成人保健検診結果（フリー項目）テーブル
                db.tt_shfree.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.nendo).Execute();
            }
            else
            {
                //成人保健一次検診結果（固定項目）テーブル
                db.tt_shkensin.UPDATE.WHERE.ByKeyList(keyList2).SetUseModelCreateItems().Execute(dtl1);
                //成人保健精密検査結果（固定項目）テーブル
                db.tt_shseiken.UPDATE.WHERE.ByKeyList(keyList2).SetUseModelCreateItems().Execute(dtl2);
                //成人保健検診結果（フリー項目）テーブル
                db.tt_shfree.UPDATE.WHERE.ByKeyList(keyList2).SetUseModelCreateItems().Execute(dtl3);
            }

            //通年項目削除
            var kensinflg = db.tt_shkensin.SELECT.WHERE.ByKey(jigyocd, req.atenano).Exists();
            var seikenflg = db.tt_shkensin.SELECT.WHERE.ByKey(jigyocd, req.atenano).Exists();
            if (!kensinflg && !seikenflg)
            {
                db.tt_shfree.DELETE.WHERE.ByKey(jigyocd, req.atenano).Execute();
            }

            //-------------------------------------------------------------
            //６.データ加工処理
            //-------------------------------------------------------------
            //状態列判断用
            res.atenano = req.atenano;                      //宛名番号
            List<int> keyList3 = new List<int>();
            if (req.delkbn == Enum削除区分.単一削除)
            {
                keyList3 = keyList2.Select(e => CInt(e[3])).ToList();
            }
            else
            {
                keyList3 = keyList1.Select(e => CInt(e[3])).ToList();
            }
            res.statuslist = Wraper.GetVMList(keyList3, req.kensinkaisu, req.delkbn);

            //個人番号操作フラグ
            var pFlg = personalflg && CmLogicUtil.GetPersonalnoFlg(db, req.atenano);
            //宛名ログ記録
            DaDbLogService.WriteAtenaLog(db, req.atenano, pFlg, EnumAtenaActionType.削除);

            //正常返し
            return res;
        }

        /// <summary>
        /// 基準値取得処理
        /// </summary>
        private GetKijunResponse GetKijun(DaDbContext db, GetKijunRequest req, string jigyocd)
        {
            var res = new GetKijunResponse();
            //-------------------------------------------------------------
            //１.事前チェック
            //-------------------------------------------------------------
            //フリー項目リストが空の場合、正常返し
            if (!req.freeitemlist.Any()) return res;

            //-------------------------------------------------------------
            //２.データ取得
            //-------------------------------------------------------------
            //宛名テーブル
            var dto = db.tt_afatena.GetDtoByKey(req.atenano);
            //性別
            var sex = ParseEnum<Enum性別>(dto.sex);

            //年齢フラグ(true:確定;false:不明)
            var ageSureFlg = !CBool(dto.bymd_fusyoflg);
            //性別フラグ(true:確定;false:不明/その他)
            var sexSureFlg = (sex != Enum性別.不明 && sex != Enum性別.その他);

            //検査方法コード(一次)
            var kensahohocd1 = DaSelectorService.GetCd(req.kensahoho1);

            //基準値マスタ
            var dtl = CmKijunUtil.GetDtl(db, req.freeitemlist, req.jissiymd1, req.jissiymd2, kensahohocd1, req.nendo, sex, dto, jigyocd, ageSureFlg, sexSureFlg);

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------
            res.kekkalist = Wraper.GetVMList(req.freeitemlist, dtl, ageSureFlg, sexSureFlg, sex);

            return res;
        }

        /// <summary>
        /// 実施年齢取得処理
        /// </summary>
        private GetAgeResponse GetAge(DaDbContext db, GetAgeRequest req)
        {
            var res = new GetAgeResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //宛名テーブル
            var dto = db.tt_afatena.GetDtoByKey(req.atenano);
            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            res.jissiage = CmLogicUtil.GetAge(dto.bymd_fusyoflg, dto.bymd, req.jissiymd);

            return res;
        }

        /// <summary>
        /// 精密検診チェック処理
        /// </summary>
        private SeiKenEditCheckResponse SeiKenEditCheck(DaDbContext db, SeiKenEditCheckRequest req, string jigyocd)
        {
            var res = new SeiKenEditCheckResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //一次結果チェック区分
            var dto1 = DaMsgControlService.GetMsgDto(db, CTRL_MSG_ID4);
            //一次検診結果存在チェック区分
            var dto2 = DaMsgControlService.GetMsgDto(db, CTRL_MSG_ID5);
            //一次健診結果を要精密→要精密以外チェック区分
            var dto3 = DaMsgControlService.GetMsgDto(db, CTRL_MSG_ID6);

            //一次検診結果存在チェック
            if (!req.dataflg1)
            {
                return GetResponse(db, dto2, res);
            }
            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //編集フラグ(精密：一次結果)
            res.editflg3 = GetSeikenEditFlg(db, req.kekkalist, jigyocd, dto1.msgkbn);

            //一次結果チェック区分
            if (!req.dataflg2 && !res.editflg3)
            {
                return GetResponse(db, dto1, res);
            }

            //一次健診結果を要精密→要精密以外チェック
            if (req.oldlist != null)
            {
                //編集フラグ(精密：一次結果)old
                //要精密フラグ
                var flg = GetSeikenEditFlg(db, req.oldlist, jigyocd, dto1.msgkbn);
                if (flg && req.dataflg2 && !res.editflg3)
                {
                    return GetResponse(db, dto3, res);
                }
            }
            return res;
        }

        /// <summary>
        /// 計算処理
        /// </summary>
        private CalculateResponse Calculate(DaDbContext db, CalculateRequest req, string jigyocd)
        {
            var res = new CalculateResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //キーリスト(結果項目：全部)
            var keyList = new List<object[]>();
            foreach (var item in req.kekkalist)
            {
                keyList.Add(new object[] { jigyocd, item.itemcd });
            }
            //フリー項目マスタ
            var dtl = db.tm_shfreeitem.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //入力済項目キーリスト
            var keyList1 = req.kekkalist.Where(e => e.value != null).Select(e => e.itemcd).ToList();

            //計算対象キーリスト:入力済項目が対象外
            var keyList2 = dtl.Where(e => e.keisankbn != Enum計算区分.Empty && !keyList1.Contains(e.itemcd)).Select(e => e.itemcd).ToList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            res.kekkalist = Wraper.GetVMList(db, keyList2, keyList1, req.kekkalist, dtl);

            return res;
        }

        /// <summary>
        /// 排他チェック(削除)
        /// </summary>
        private static bool Check(List<(int? kensinkaisu, DateTime? upddttm)> list1, List<(int kensinkaisu, DateTime upddttm)> list2)
        {
            return list1.Count == list2.Count &&
                   list1.All(v => list2.Exists(o => o.kensinkaisu == v.kensinkaisu && o.upddttm == v.upddttm));
        }

        /// <summary>
        /// 精密編集フラグ取得
        /// </summary>
        private static bool GetSeikenEditFlg(DaDbContext db, List<KsKekkaItemVM> kekkalist, string jigyocd, EnumMsgCtrlKbn kbn)
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //キーリスト(結果項目：全部)
            var keyList = new List<object[]>();
            foreach (var item in kekkalist)
            {
                keyList.Add(new object[] { jigyocd, item.itemcd });
            }
            //フリー項目マスタ
            var dtl = db.tm_shfreeitem.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //キーリスト(結果項目：汎用マスタ)
            var keyList2 = new List<object[]>();
            foreach (var dto in dtl)
            {
                if (dto.codejoken1 != null && dto.codejoken2 != null)
                {
                    keyList2.Add(new object[] { dto.codejoken1!, CInt(dto.codejoken2) });
                }
            }
            //汎用マスタ
            var dtl2 = db.tm_afhanyo.SELECT.WHERE.ByKeyList(keyList2).GetDtoList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //編集フラグ(精密)
            var editflg = dtl.Any(dto =>
            {
                var value = kekkalist.Find(e => e.itemcd == dto.itemcd)?.value;
                if (value == null)
                {
                    return false;
                }

                switch (dto.inputtype)
                {
                    case Enum入力タイプ.コード_名称マスタ:
                        return !string.IsNullOrEmpty(DaNameService.GetKbn1(db, dto.codejoken1!, CInt(dto.codejoken2), DaSelectorService.GetCd(CStr(value))));

                    case Enum入力タイプ.コード_汎用マスタ:
                        var kbn1 = dtl2.Find(e => e.hanyomaincd == dto.codejoken1! && e.hanyosubcd == CInt(dto.codejoken2) && e.hanyocd == DaSelectorService.GetCd(CStr(value)))?.hanyokbn1;
                        return !string.IsNullOrEmpty(kbn1);

                    default:
                        throw new Exception("Enum入力タイプ error");
                }
            });

            //非表示の場合、チェックなし
            if (kbn == EnumMsgCtrlKbn.非表示) editflg = true;

            return editflg;
        }

        /// <summary>
        /// 一次結果チェックメッセージ設定
        /// </summary>
        private static TRes GetResponse<TRes>(DaDbContext db, tm_afmsgctrlDto dto, TRes res) where TRes : DaResponseBase, new()
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            switch (dto.msgkbn)
            {
                //エラーの場合
                case EnumMsgCtrlKbn.エラー:
                    res.SetServiceError(DaMessageService.GetMsg(dto.errormsgid));
                    break;
                //アラートの場合
                case EnumMsgCtrlKbn.アラート:
                    res.SetServiceAlert(DaMessageService.GetMsg(dto.alertmsgid));
                    break;
                //非表示の場合
                case EnumMsgCtrlKbn.非表示:
                    break;
                default:
                    throw new Exception("EnumMsgCtrlKbn error");
            }

            return res;
        }

        /// <summary>
        /// 年度取得
        /// </summary>
        private static int? GetNendo(DateTime? day)
        {
            if (day == null)
            {
                return null;
            }
            var nendo = day.Value.Year;
            if (day.Value.Month < 4)
            {
                nendo -= 1;
            }

            return nendo;
        }
    }
}