// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 住登外者管理
// 　　　　　　サービス処理
// 作成日　　: 2023.11.09
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaStrPool;
using static BCC.Affect.DataAccess.DaConst;
using BCC.Affect.Service.AWKK00101G;

namespace BCC.Affect.Service.AWKK00111G
{
    [DisplayName("住登外者管理")]

    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00111G = "AWKK00111G";
        //検索処理(詳細画面：税額控除タブ)
        private const string PROC_NAME = "sp_awkk00101g_01";

        //定数定義
        private const int NEW_RIREKI = 1;                     //履歴番号（新規の場合）
        private const string C_TON_FULL = "、";               //全角トン記号（一時利用、後でDaStrPool.csで追加したら削除する予定）
        private const int RIREKINUM_ZERO = 0;                 //一覧から詳細画面を開く場合の履歴No.の設定値（０）
        private const string CHECKMSG_JYUTOGAI = "住登外者";  //メッセージ用

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return InitList(db);
            });
        }

        [DisplayName("検索処理(一覧画面)")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchList(db, req);
            });
        }

        [DisplayName("初期化処理(詳細画面)")]
        public InitDetailResponse InitDetail(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return InitDetail(db);
            });
        }

        [DisplayName("検索処理(詳細画面)")]
        public SearchDetailResponse SearchDetail(SearchDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchDetail(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：課税・納税義務者タブ_課税)")]
        public SearchKaZeiDetailResponse SearchKaZeiDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWKK00101G.Service();
                return service.GetSearchKaZeiDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：課税・納税義務者タブ_納税)")]
        public SearchNoZeiDetailResponse SearchNoZeiDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWKK00101G.Service();
                return service.GetSearchNoZeiDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：税額控除タブ)")]
        public SearchKojoDetailResponse SearchKojoDetail(SearchKojoDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWKK00101G.Service();
                return service.GetSearchKojoDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：税額控除タブ_明細)")]
        public SearchKojoDetailRowsResponse SearchKojoDetailRows(SearchKojoDetailRowsRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWKK00101G.Service();
                return service.GetSearchKojoDetailRowsResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：国保タブ)")]
        public SearchKokuhoDetailResponse SearchKokuhoDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWKK00101G.Service();
                return service.GetSearchKokuhoDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：後期タブ)")]
        public SearchKokiDetailResponse SearchKokiDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWKK00101G.Service();
                return service.GetSearchKokiDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：生保タブ)")]
        public SearchSeihoDetailResponse SearchSeihoDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWKK00101G.Service();
                return service.GetSearchSeihoDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：介護タブ)")]
        public SearchKaigoDetailResponse SearchKaigoDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWKK00101G.Service();
                return service.GetSearchKaigoDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：福祉タブ)")]
        public SearchSyogaiDetailResponse SearchSyogaiDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWKK00101G.Service();
                return service.GetSearchSyogaiDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(異動処理)")]
        public SearchDetailResponse SearchSeisinDetail(SearchSeisinDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchSeisinDetail(db, req);
            });
        }

        [DisplayName("保存処理")]
        public CommonResponse Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //Todo：kinoidから事業コード取得、共通関数があれば入れ替える
                var jigyocd = GetJigyocd(req.kinoid!);

                //正常返し
                return Save(db, req, jigyocd, req.kinoid!);
            });
        }

        [DisplayName("世帯更新処理")]
        public CommonResponse SaveSeitai(SaveSeitaiRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //Todo：kinoidから事業コード取得、共通関数があれば入れ替える
                var jigyocd = GetJigyocd(req.kinoid!);

                //正常返し
                return SaveSeitai(db, req, jigyocd, req.kinoid!);
            });
        }

        [DisplayName("削除処理")]
        public CommonResponse Delete(DeleteRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return Delete(db, req);
            });
        }

        [DisplayName("検索処理(郵便情報)")]
        public AutoSetResponse SearchYubin(AutoSetRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchYubin(db, req);
            });
        }

        [DisplayName("検索処理(個人番号)")]
        public SearchPersonalResponse SearchPersonal(SearchPersonalRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchPersonal(db, req);
            });
        }

        [DisplayName("検索処理(自動付番)")]
        public SearchAutoSaibanResponse AutoSaisin(AutoSaibanRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return AutoSaisin(db, req);
            });
        }

        //************************************************************** 処理ロジェック **************************************************************
        /// <summary>
        /// 初期化処理(一覧画面)
        /// </summary>
        private InitListResponse InitList(DaDbContext db)
        {
            var res = new InitListResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //住登外者情報テーブル
            //登録者
            var dtl = db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.saisinflg)}=true").GetDtoList().OrderBy(e => e.reguserid);
            //登録者一覧
            var keyList = dtl.Select(e => e.reguserid).Distinct().ToList();
            //事業従事者（担当者）情報マスタ
            var dtl1 = db.tm_afstaff.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //更新者
            dtl = db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.saisinflg)}=true").GetDtoList().OrderBy(e => e.upduserid);
            //更新者一覧
            keyList = dtl.Select(e => e.upduserid).Distinct().ToList();
            //事業従事者（担当者）情報マスタ
            var dtl2 = db.tm_afstaff.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //ドロップダウンリスト(登録者)
            res.selectorlist1 = dtl1.Select(e => new DaSelectorModel(e.staffid, e.staffsimei)).ToList();

            //ドロップダウンリスト(更新者)
            res.selectorlist2 = dtl2.Select(e => new DaSelectorModel(e.staffid, e.staffsimei)).ToList();

            //ドロップダウンリスト(削除フラグ)
            res.selectorlist3 = Wraper.MList(db, EnumNmKbn.削除条件指定);

            //ドロップダウンリスト(業務ID)
            var sansyogyomunmlist = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.業務ID);
            res.selectorlist4 = Wraper.MRefList(db, sansyogyomunmlist);

            //ドロップダウンリスト(独自施策システム等ID)
            var dokujisystemnmlist = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.独自施策システム等ID);
            res.selectorlist5 = Wraper.MRefList(db, dokujisystemnmlist);

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(一覧画面)
        /// </summary>
        private SearchListResponse SearchList(DaDbContext db, SearchListRequest req)
        {
            var res = new SearchListResponse();

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //宛名番号
            if (!string.IsNullOrEmpty(req.atenano))
            {
                //宛名テーブル
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住登外者情報")) { return res; }  //異常返し
            }

            //個人番号
            if (!string.IsNullOrEmpty(req.personalno))
            {
                //Page個人番号復号化
                req.SetPersonalno();

                //DB個人番号AES暗号化
                var dbpersonalno = DaEncryptUtil.AesEncrypt(req.personalno);

                if (!db.tt_afatena.SELECT.WHERE.ByFilter("personalno = @personalno", dbpersonalno).Exists())
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "検索対象", "住登外者情報");
                    res.SetServiceError(msg);
                    return res;   //異常返し
                }
            }

            //-------------------------------------------------------------
            //２.条件設定
            //-------------------------------------------------------------
            //固定の検索条件
            var fixedCondition = Converter.GetFixedCondition(req);
            //詳細の検索条件
            var conditon = CmSearchUtil.GetSearchJyoken(db, AWKK00111G, req.syosailist, fixedCondition, req.pagenum, req.pagesize);
            //連絡先の事業コード
            var renraku_jigyocd = CmLogicUtil.GetRenrakujigyocd(db, AWKK00111G);

            //-------------------------------------------------------------
            //３.データ取得
            //-------------------------------------------------------------
            //検索結果
            var result = DaFreeQuery.GetJutogaiQuery(db, renraku_jigyocd, conditon, req.orderby, true);
            //総件数
            var total = result.Count;
            //結果一覧
            var pageData = result.Data;
            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            //画面項目設定
            res.kekkalist = Wraper.GetVMList(db, pageData.Rows, alertviewflg);

            //ページャー設定
            res.SetPageInfo(total, req.pagesize);

            //正常返し
            return res;
        }

        /// <summary>
        /// 初期化処理(詳細画面)
        /// </summary>
        private InitDetailResponse InitDetail(DaDbContext db)
        {
            var res = new InitDetailResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            var strymd = FormatYMD(DaUtil.Today, DateFormat);

            //市区町村マスタ
            var dtl0 = db.tm_afsikutyoson.SELECT.WHERE.ByFilter($"({nameof(tm_afsikutyosonDto.koryokuhasseiymd)} IS NULL OR {nameof(tm_afsikutyosonDto.koryokuhasseiymd)}<=@strymd) " +
                                                 $"AND ({nameof(tm_afsikutyosonDto.haisiymd)} IS NULL OR {nameof(tm_afsikutyosonDto.haisiymd)}>=@strymd)", strymd)
                                         .GetDtoList().OrderBy(e => e.sikucd);

            var dtl1 = dtl0.Select(e => new DaSelectorModelExp(e.sikucd, $"{e.todofukennm}{e.sikunm}", e.todofukennm, e.sikunm)).ToList();

            //町字リスト
            var dtl2 = db.tm_aftyoaza.SELECT.WHERE.ByFilter($"({nameof(tm_afsikutyosonDto.koryokuhasseiymd)} IS NULL OR {nameof(tm_afsikutyosonDto.koryokuhasseiymd)}<=@strymd) " +
                                                 $"AND ({nameof(tm_afsikutyosonDto.haisiymd)} IS NULL OR {nameof(tm_afsikutyosonDto.haisiymd)}>=@strymd)", strymd)
                                     .GetDtoList().OrderBy(e => e.sikucd).ThenBy(e => e.tyoazaid);

            var dtl3 = dtl2.Select(e => new DaSelectorKeyModel(e.tyoazaid, $"{e.oazatyonm}{e.tyomeinm}{e.koazanm}", e.sikucd)).ToList();
            //「0000000：町字なし」と「9999999：町字マスタデータなし」をリストの最後に追加する
            var dt = new DaSelectorKeyModel("0000000", "町字なし", "000000");
            dtl3.Add(dt);
            dt = new DaSelectorKeyModel("9999999", "町字マスタデータなし", "000000");
            dtl3.Add(dt);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            res.initdetail = Wraper.GetVM(db, dtl1, dtl3);

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(詳細画面)
        /// </summary>
        private SearchDetailResponse SearchDetail(DaDbContext db, SearchDetailRequest req)
        {
            var res = new SearchDetailResponse();

            tt_afjutogaiDto? dto = new tt_afjutogaiDto();
            var curpageno = 0;
            var totalpageno = db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.atenano)}=@atenano", req.atenano).GetCount();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            if (req.rirekinum.CompareTo(RIREKINUM_ZERO) == 0)
            {
                //一覧から詳細画面を開く場合
                //住登外者情報テーブル（一覧で選択した宛名番号、履歴番号）
                dto = db.tt_afjutogai.GetDtoByKey(req.atenano, CInt(req.rirekino));
                if (dto == null) throw new AiExclusiveException();

                var olddtl = db.tt_afjutogai.SELECT.WHERE.ByKey(req.atenano).GetDtoList()
                            .OrderByDescending(e => e.saisinflg)       //最新フラグ
                            .ThenByDescending(e => e.rirekino)         //履歴番号
                            .ToList();

                foreach (var item in olddtl)
                {
                    curpageno++;

                    if (item.rirekino.CompareTo(req.rirekino) == 0)
                    {
                        break;
                    }
                }
            }
            else
            {
                //詳細画面で改ページの場合
                //住登外者情報テーブル
                var dtl = db.tt_afjutogai.SELECT.WHERE.ByKey(req.atenano).GetDtoList()
                                         .OrderByDescending(e => e.saisinflg)       //最新フラグ
                                         .ThenByDescending(e => e.rirekino)         //履歴番号
                                         .ToList();

                //ページャー設定
                if (dtl.Count == 0)
                {
                    res.rirekinum = 0;
                    //正常返し
                    return res;
                }
                else if (req.rirekinum > dtl.Count)
                {
                    res.SetServiceError(DaMessageService.GetMsg(EnumMessage.DATA_NOTEXIST_ERROR, "住登外者情報", "参照"));
                    //異常返し
                    return res;
                }

                dto = dtl[req.rirekinum - 1];

                curpageno = req.rirekinum;
            }

            //ページャー設定
            res.rirekitotal = totalpageno;
            res.rirekinum = curpageno;

            //-------------------------------------------------------------
            //２.チェック処理
            //-------------------------------------------------------------
            //詳細画面のヘッダー部表示項目は、常に住登外者の最新情報(※1)を表示する（概要4.2.1）
            //※1 住登外者の最新情報について
            //連携の機能などで一部の履歴が停止のデータもあるため、通常は削除されていないデータの履歴番号最大値、
            var newdto = db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.atenano)}=@atenano And {nameof(tt_afjutogaiDto.stopflg)}=false", req.atenano)
                                        .GetDtoList().OrderByDescending(e => e.rirekino).FirstOrDefault();
            if (newdto == null)
            {
                //全履歴が削除された場合は履歴番号最大値が最新情報とする
                newdto = db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.atenano)}=@atenano", req.atenano)
                                        .GetDtoList().OrderByDescending(e => e.rirekino).FirstOrDefault();
            }

            //宛名情報取得（ヘッダー部表示項目表示用【画面項目説明(AWKK00111G)_詳細_基本情報等タブ】--ヘッダー部）
            var atenadto = db.tt_afatena.GetDtoByKey(req.atenano);

            //個人番号取得
            var personalno = db.tt_afatena.GetDtoByKey(req.atenano).personalno;

            //世帯主名と住登区分取得
            var setainodto = db.tt_afatena.SELECT.WHERE.ByFilter($"{nameof(tt_afatenaDto.setaino)}=@setaino And " +
                                                                 $"{nameof(tt_afatenaDto.zokuhyoki)}=@zokuhyoki", dto.setaino, "世帯主")
                                           .GetDtoList().FirstOrDefault();
            if (setainodto == null)
            {
                //世帯主が存在していない場合、同世帯の一員を取得する
                setainodto = db.tt_afatena.SELECT.WHERE.ByFilter($"{nameof(tt_afatenaDto.setaino)}=@setaino", dto.setaino)
                                          .GetDtoList().OrderByDescending(e => e.atenano).FirstOrDefault();
                if (setainodto == null) { throw new AiExclusiveException(); }

            }

            var simei_yusen = setainodto.simei_yusen;

            var jutokbn = CStr((int)setainodto.jutokbn);

            //住登外者参照業務情報を取得（該当宛名番号、履歴番号単位）
            var gyomukeyList = db.tt_afjutogai_gyomu.SELECT.SetSelectItems(nameof(tt_afjutogai_gyomuDto.gyomuid)).WHERE.ByKey(dto.atenano, CInt(dto.rirekino))
                                                    .GetDtoList().OrderBy(e => e.atenano).ThenBy(e => e.rirekino).ThenBy(e => e.gyomuid).Select(e => e.gyomuid).ToList();

            //住登外者独自施策システム等情報を取得（該当宛名番号、履歴番号単位）
            var dokujikeyList = db.tt_afjutogai_dokujisystem.SELECT.SetSelectItems(nameof(tt_afjutogai_dokujisystemDto.dokujisystemid)).WHERE.ByKey(dto.atenano, CInt(dto.rirekino))
                                                            .GetDtoList().OrderBy(e => e.atenano).ThenBy(e => e.rirekino).ThenBy(e => e.dokujisystemid).Select(e => e.dokujisystemid).ToList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

            //権限関連
            var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, req.kinoid!);

            //暗号化
            var publickey = string.Empty;   //公開キー(暗号化)
            var privatekey = string.Empty;  //秘密キー(復号化)
                                            //キー取得
            DaEncryptUtil.GeneratePemRsaKeyPair(out publickey, out privatekey);

            res.baseinfo = Wraper.GetVM(db, atenadto, newdto, alertviewflg);
            res.maininfo = Wraper.GetVM(db, dto, personalno, simei_yusen, jutokbn, personalflg, publickey);

            //住登外者参照業務情報
            res.maininfo.sansyogyomucdlist = Wraper.GetVMList(db, gyomukeyList, EnumHanyoKbn.業務ID);

            //住登外者独自施策システム等情報
            res.maininfo.dokujisystemcdlist = Wraper.GetVMList(db, dokujikeyList, EnumHanyoKbn.独自施策システム等ID);

            //rsaキー
            res.rsaprivatekey = privatekey;

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(異動処理)
        /// </summary>
        private SearchDetailResponse SearchSeisinDetail(DaDbContext db, SearchSeisinDetailRequest req)
        {
            var res = new SearchDetailResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //該当宛名番号の住登外者の最新履歴情報を取得（4.2.1の※1を参照）
            //※1 住登外者の最新情報について
            //連携の機能などで一部の履歴が停止のデータもあるため、通常は削除されていないデータの履歴番号最大値、
            var dto = db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.atenano)}=@atenano And {nameof(tt_afjutogaiDto.stopflg)}=false", req.atenano)
                                        .GetDtoList().OrderByDescending(e => e.rirekino).FirstOrDefault();
            if (dto == null)
            {
                //全履歴が削除された場合は履歴番号最大値が最新情報とする
                dto = db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.atenano)}=@atenano", req.atenano)
                                        .GetDtoList().OrderByDescending(e => e.rirekino).FirstOrDefault();

                if (dto == null) return res;
            }

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            var dtreq = new SearchDetailRequest()
            {
                userid = req.userid,
                atenano = req.atenano,
                rirekino = dto.rirekino,
                regsisyo = req.regsisyo,
                token = req.token,
            };

            res = SearchDetail(db, dtreq);

            res.maininfo.idoymd = null;             //異動年月日
            res.maininfo.idojiyu = string.Empty;    //異動事由

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
            //データ操作区分取得
            var kbn = Converter.GetKBN(req.maininfo.upddttm, true);
            var oldpersonalno = string.Empty;

            tt_afjutogaiDto? oldDto = null;

            var seitaiinfo = new SeitaiInfoVM();

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                oldDto = db.tt_afjutogai.GetDtoByKey(req.maininfo.atenano, CInt(req.maininfo.rirekino));
                //存在チェック=>排他とする
                if (oldDto == null) throw new AiExclusiveException();

                //詳細画面の世帯情報を取得する（同一世帯員の情報更新の為）
                seitaiinfo = Wraper.GetVM(db, oldDto, seitaiinfo);

                var atenaDto = db.tt_afatena.GetDtoByKey(req.maininfo.atenano);
                if (atenaDto == null)
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, $"宛名番号{C_LEFT_BRACKET_HALF}{req.maininfo.atenano}{C_RIGHT_BRACKET_HALF}", tt_afatenaDto.TABLE_NAME);
                    res.SetServiceError(msg);
                    return res;   //異常返し
                }
                oldpersonalno = db.tt_afatena.GetDtoByKey(req.maininfo.atenano).personalno;
                if (string.IsNullOrEmpty(oldpersonalno))
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "個人番号", tt_afatenaDto.TABLE_NAME);
                    res.SetServiceError(msg);
                    return res;   //異常返し
                }

                DateTime oldupddttm = oldDto.upddttm;

                //排他チェック
                //if (DateTime.Compare(oldupddttm, req.maininfo.upddttm) != 0) throw new AiExclusiveException();
            }

            //-------------------------------------------------------------
            //２.データ取得
            //-------------------------------------------------------------
            //権限関連
            var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, kinoid);

            //Page個人番号復号化
            if (!string.IsNullOrEmpty(req.maininfo.personalno)) { req.maininfo.personalno = DaEncryptUtil.RsaDecrypt(req.maininfo.personalno); }

            //DB個人番号AES暗号化
            if (!string.IsNullOrEmpty(req.maininfo.personalno)) { req.maininfo.personalno = DaEncryptUtil.AesEncrypt(req.maininfo.personalno); }

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------
            //住登外者情報テーブル
            var newdto = new tt_afjutogaiDto();

            //最新履歴番号を取得する
            var dto = db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.atenano)}=@atenano", req.maininfo.atenano)
                            .GetDtoList().OrderByDescending(e => e.rirekino).FirstOrDefault();
            if (dto != null)
            {
                //宛名番号が存在している場合
                req.maininfo.rirekino = dto.rirekino + 1;
            }
            else
            {
                //宛名番号が存在していない場合（住登外者新規登録の場合、履歴番号を１からカウントする）
                req.maininfo.rirekino = NEW_RIREKI;
            }

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                newdto = oldDto!;
            }

            //性別表記取得
            var sex = GetCd(req.maininfo.sex)!;
            var sexhyoki = Wraper.MNm(db, sex, EnumNmKbn.性別_システム共有);    //仕様変更UP208により性別表記内容は名称マスタ1000-72から取得

            //データ加工
            newdto = Converter.GetDto(newdto, req.maininfo, sexhyoki);

            //-------------------------------------------------------------
            //４.DB更新処理
            //-------------------------------------------------------------
            //住登外者情報テーブル
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                db.tt_afjutogai.INSERT.Execute(newdto);
                if (req.maininfo.rirekino == NEW_RIREKI)
                {
                    //住登外者新規登録の場合
                    if (!db.tt_afatena.SELECT.WHERE.ByFilter($"{nameof(tt_afatenaDto.atenano)}=@atenano", req.maininfo.atenano).Exists())
                    {
                        //宛名テーブルには該当宛名番号が存在していない場合、レコードを追加する
                        var atenadto = new tt_afatenaDto();
                        atenadto = Converter.GetDto(atenadto, req.maininfo);
                        db.tt_afatena.INSERT.Execute(atenadto);
                    }
                }
            }
            else if (kbn == EnumActionType.Update)
            {
                //更新の場合
                //住登外者情報テーブル
                //①当該宛名番号に関するすべてのレコードを論理削除する（に設定）：停止フラグ：’1’（停止中）、最新フラグ：’0’（最新ではない）
                var dtl1 = db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.atenano)}=@atenano And {nameof(tt_afjutogaiDto.saisinflg)}=true", req.maininfo.atenano)
                                          .GetDtoList();
                foreach (var dt in dtl1)
                {
                    dt.saisinflg = false;              //最新フラグ
                }
                db.tt_afjutogai.UPDATE.Execute(dtl1);

                //②履歴番号をカウントアップしてレコード追加
                db.tt_afjutogai.INSERT.Execute(newdto);

                //宛名テーブル
                //対象の住登外者情報を変更された内容で更新する
                var atenadto = new tt_afatenaDto();
                atenadto = Converter.GetDto(atenadto, req.maininfo);
                db.tt_afatena.UPDATE.Execute(atenadto);

                //個人番号管理テーブル
                if (!oldpersonalno.Equals(req.maininfo.personalno))
                {
                    //個人番号が変更された場合
                    //①同一宛名番号のほかの個人番号履歴レコードの最新フラグをfalseに設定
                    var dtl2 = db.tt_afpersonalno.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.atenano)}=@atenano And {nameof(tt_afjutogaiDto.saisinflg)}=true", req.maininfo.atenano)
                                                 .GetDtoList();
                    foreach (var dt in dtl2)
                    {
                        dt.saisinflg = false;              //最新フラグ
                    }
                    db.tt_afpersonalno.UPDATE.Execute(dtl2);

                    //②履歴番号をカウントアップしてレコード追加
                    //最新履歴番号を取得する
                    var perrirekino = NEW_RIREKI;
                    var dto1 = db.tt_afpersonalno.SELECT.WHERE.ByFilter($"{nameof(tt_afpersonalnoDto.atenano)}=@atenano", req.maininfo.atenano)
                                                 .GetDtoList().OrderByDescending(e => e.rirekino).FirstOrDefault();
                    if (dto1 != null)
                    {
                        //宛名番号が存在している場合
                        perrirekino = dto1.rirekino + 1;
                    }
                    else
                    {
                        //宛名番号が存在していない場合（住登外者新規登録の場合、履歴番号を１からカウントする）
                        perrirekino = NEW_RIREKI;
                    }

                    var personaldto = new tt_afpersonalnoDto();
                    personaldto = Converter.GetDto(req, personaldto, req.maininfo, perrirekino);
                    db.tt_afpersonalno.INSERT.Execute(personaldto);
                }
            }

            //住登外者参照業務情報テーブルを登録
            //①該当宛名番号の参照業務を削除する
            db.tt_afjutogai_gyomu.DELETE.WHERE.ByKey(req.maininfo.atenano).Execute();

            //②該当宛名番号の参照業務を登録する
            var i = 1;
            foreach (var item in req.maininfo.sansyogyomucdlist)
            {
                var gyomudto = new tt_afjutogai_gyomuDto();
                gyomudto = Converter.GetDto(gyomudto, item, req.maininfo.atenano, i);
                db.tt_afjutogai_gyomu.INSERT.Execute(gyomudto);
                i++;
            }

            //住登外者独自施策システム等情報テーブルを登録
            //①該当宛名番号の独自施策システムを削除する
            db.tt_afjutogai_dokujisystem.DELETE.WHERE.ByKey(req.maininfo.atenano).Execute();

            //②該当宛名番号の独自施策システムを登録する
            i = 1;
            foreach (var item in req.maininfo.sansyogyomucdlist)
            {
                var dokujidto = new tt_afjutogai_dokujisystemDto();
                dokujidto = Converter.GetDto(dokujidto, item, req.maininfo.atenano, i);
                db.tt_afjutogai_dokujisystem.INSERT.Execute(dokujidto);
                i++;
            }

            //4.2.8.2  同一世帯員の情報更新について
            //①同一世帯員情報更新の実施条件を判定
            if (SeitaiChgChk(db, req.maininfo, seitaiinfo))
            {
                //更新となる場合
                //② 更新対象者の取得
                //同一世帯員の情報取得
                var seitaidtl = db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.setaino)}=@setaino And {nameof(tt_afjutogaiDto.atenano)}<>@atenano", req.maininfo.setaino, req.maininfo.atenano)
                                               .GetDtoList().OrderBy(e => e.atenano);

                //同一世帯員の宛名番号
                var seitaikeyList = seitaidtl.Select(e => e.atenano).Distinct().ToList();

                //住登外者のみの同一世帯員宛名番号を取得
                var seitaidtl1 = db.tt_afatena.SELECT.WHERE.ByKeyList(seitaikeyList).GetDtoList().Where(e => e.jutokbn == Enum住登区分.住登外);

                var seitaivm = new List<SeitaiDictVM>();
                var strseitai = string.Empty;
                i = 1;

                foreach (var item in seitaidtl1)
                {
                    //③同一世帯員情報更新の確認メッセージ表示
                    var vm1 = new SeitaiDictVM();

                    vm1.atenano = item.atenano;

                    //例：宛名番号：1、氏名：六本松　太郎
                    strseitai = $"{strseitai}{CStr(item.atenano)}{C_COLON_FULL}{CStr(i)}{C_TON_FULL}氏名{C_COLON_FULL}{CStr(item.simei)}{C_CR}{C_LF}";

                    seitaivm.Add(vm1);

                    i++;
                }

                res.seitaidictlist = seitaivm;

                var msg = DaMessageService.GetMsg(EnumMessage.C011001, strseitai);
                res.SetServiceAlert(msg);
                res.rirekino = req.maininfo.rirekino;

                return res;   //アラート返し
            }

            //-------------------------------------------------------------
            //５.ログ出力
            //-------------------------------------------------------------
            //宛名ログ記録
            var kbn1 = EnumAtenaActionType.更新;
            if (kbn == EnumActionType.Insert)
            {
                kbn1 = EnumAtenaActionType.追加;
            }

            //個人番号操作フラグ
            var pFlg = personalflg && CmLogicUtil.GetPersonalnoFlg(db, req.maininfo.atenano);

            //宛名ログ記録
            DaDbLogService.WriteAtenaLog(db, req.maininfo.atenano, pFlg, kbn1);

            //-------------------------------------------------------------
            //６.状態設定
            //-------------------------------------------------------------
            //状態列判断用
            res.atenano = req.maininfo.atenano;         //宛名番号
            res.rirekino = req.maininfo.rirekino;       //履歴番号

            //正常返し
            return res;
        }

        /// <summary>
        /// 削除処理(詳細画面)
        /// </summary>
        private CommonResponse Delete(DaDbContext db, DeleteRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.削除チェック処理
            //-------------------------------------------------------------
            //宛名番号が他のテーブルで使用されている場合、エラーメッセージを出力して削除処理を行わない
            //ログ以外の業務テーブルがすべてチェック対象とする（共通管理「６テーブル」）

            if (Check(db, req.atenano))
            {
                var msg = DaMessageService.GetMsg(EnumMessage.E014001, CHECKMSG_JYUTOGAI);
                res.SetServiceError(msg);
                return res;   //異常返し
            }

            //住登外者情報テーブル
            if (!db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.atenano)}=@atenano", req.atenano).Exists())
            {
                //E004006：'{0}は{1}に存在しません。'
                var msg = DaMessageService.GetMsg(EnumMessage.E004006, $"宛名番号{C_LEFT_BRACKET_HALF}{req.atenano}{C_RIGHT_BRACKET_HALF}", tt_afatenaDto.TABLE_NAME);
                res.SetServiceError(msg);
                return res;   //異常返し
            }

            //-------------------------------------------------------------
            //２.データ取得
            //-------------------------------------------------------------
            //権限関連
            var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, req.kinoid!);

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------
            //住登外者情報テーブル
            //当該宛名番号に関するすべてのレコードを論理削除する（に設定）
            var dtl = db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.atenano)}=@atenano", req.atenano).GetDtoList();
            foreach (var dt in dtl)
            {
                dt.stopflg = true;                  //使用停止フラグ
                dt.saisinflg = false;               //最新フラグ
            }

            //-------------------------------------------------------------
            //４.DB更新処理
            //-------------------------------------------------------------
            db.tt_afjutogai.UPDATE.Execute(dtl);

            //-------------------------------------------------------------
            //５.DB削除処理
            //-------------------------------------------------------------
            //宛名テーブル
            db.tt_afatena.DELETE.WHERE.ByKey(req.atenano).Execute();

            //-------------------------------------------------------------
            //６.ログ出力
            //-------------------------------------------------------------
            //個人番号操作フラグ
            var pFlg = personalflg && CmLogicUtil.GetPersonalnoFlg(db, req.atenano);

            //宛名ログ記録
            DaDbLogService.WriteAtenaLog(db, req.atenano, pFlg, EnumAtenaActionType.削除);

            //-------------------------------------------------------------
            //７.状態設定
            //-------------------------------------------------------------
            //状態列判断用
            res.atenano = req.atenano;         //宛名番号

            //正常返し
            return res;
        }

        /// <summary>
        /// 同一世帯員情報更新処理(詳細画面)
        /// </summary>
        private CommonResponse SaveSeitai(DaDbContext db, SaveSeitaiRequest req, string jigyocd, string kinoid)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            var dto = db.tt_afjutogai.GetDtoByKey(req.atenano, CInt(req.rirekino));

            //詳細画面の世帯情報を取得する（同一世帯員の情報更新の為）
            if (dto == null) throw new AiExclusiveException();

            var atenadto = db.tt_afatena.GetDtoByKey(req.atenano);
            if (atenadto == null)
            {
                var msg = DaMessageService.GetMsg(EnumMessage.E004006, $"宛名番号{C_LEFT_BRACKET_HALF}{req.atenano}{C_RIGHT_BRACKET_HALF}", tt_afatenaDto.TABLE_NAME);
                res.SetServiceError(msg);
                return res;   //異常返し
            }

            //-------------------------------------------------------------
            //２.データ取得
            //-------------------------------------------------------------
            //詳細画面の世帯情報を取得する（同一世帯員の情報更新の為）
            var seitaiinfo = new SeitaiInfoVM();                //世帯情報
            var idoinfo = new IdoInfoVM();                      //異動情報

            seitaiinfo = Wraper.GetVM(db, dto, seitaiinfo);     //世帯情報
            idoinfo = Wraper.GetVM(db, dto, idoinfo);           //異動情報

            //権限関連
            var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, kinoid);

            //-------------------------------------------------------------
            //３.データ加工処理（各同一世帯員処理で行う）
            //-------------------------------------------------------------

            //-------------------------------------------------------------
            //４.DB更新処理
            //-------------------------------------------------------------
            //同一世帯員の情報更新を行う
            foreach (var item in req.seitaidictlist)
            {
                //住登外者情報テーブル（※履歴番号カウントアップしてレコード追加）
                //①該当世帯員の最新住登外者情報を取得する
                var seijudto = db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.atenano)}=@atenano And {nameof(tt_afjutogaiDto.saisinflg)}=true", item.atenano)
                                              .GetDtoList().OrderByDescending(e => e.rirekino).FirstOrDefault();

                //排他チェック
                if (seijudto == null) throw new AiExclusiveException();

                //新規登録用履歴番号を取得
                var newdto = db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.atenano)}=@atenano", item.atenano)
                                                   .GetDtoList().OrderByDescending(e => e.rirekino).FirstOrDefault();
                var newrirekino = 1;
                if (newdto != null) { newrirekino = CInt(newdto.rirekino) + 1; }

                //②更新後住登外者情報のデータ加工処理
                var newseijudto = Converter.GetDto(seijudto, seitaiinfo, idoinfo, newrirekino);

                //③当該宛名番号に関するすべてのレコードを論理削除する（に設定）：最新フラグ：’0’（最新ではない）
                var seijudtl = db.tt_afjutogai.SELECT.WHERE.ByFilter($"{nameof(tt_afjutogaiDto.atenano)}=@atenano", item.atenano).GetDtoList();
                foreach (var dt in seijudtl)
                {
                    dt.saisinflg = false;              //最新フラグ
                }
                db.tt_afjutogai.UPDATE.Execute(seijudtl);

                //④履歴番号をカウントアップしてレコード追加
                db.tt_afjutogai.INSERT.Execute(newseijudto);

                //宛名テーブル
                //①該当世帯員の宛名情報を取得する
                var seiatedto = db.tt_afatena.GetDtoByKey(item.atenano);

                //排他チェック
                if (seiatedto == null) throw new AiExclusiveException();

                //②更新後宛名情報のデータ加工処理
                var newseiatedto = Converter.GetDto(seiatedto, seitaiinfo);

                //③更新処理を行う
                db.tt_afatena.UPDATE.Execute(newseiatedto);

                //-------------------------------------------------------------
                //５.ログ出力
                //-------------------------------------------------------------
                //個人番号操作フラグ
                var pFlg = personalflg && CmLogicUtil.GetPersonalnoFlg(db, item.atenano);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, item.atenano, pFlg, EnumAtenaActionType.更新);
            }

            //-------------------------------------------------------------
            //６.状態設定
            //-------------------------------------------------------------
            //状態列判断用
            res.atenano = req.atenano;          //宛名番号
            res.rirekino = req.rirekino;        //履歴番号

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(郵便情報)
        /// </summary>
        private AutoSetResponse SearchYubin(DaDbContext db, AutoSetRequest req)
        {
            var res = new AutoSetResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            var strymd = FormatYMD(DaUtil.Today, DateFormat);
            //町字マスタ情報取得
            var tyoazadto = db.tm_aftyoaza.SELECT.WHERE.ByFilter($"{nameof(tm_aftyoazaDto.yubin)}=@yubin" +
                                                 $" And ({nameof(tm_afsikutyosonDto.koryokuhasseiymd)} IS NULL OR {nameof(tm_afsikutyosonDto.koryokuhasseiymd)}<=@strymd)" +
                                                 $" And ({nameof(tm_afsikutyosonDto.haisiymd)} IS NULL OR {nameof(tm_afsikutyosonDto.haisiymd)}>=@strymd)", req.adrs_yubin, strymd)
                                          .GetDtoList().OrderByDescending(e => e.upddttm).FirstOrDefault();

            if (tyoazadto == null)
            {
                //{0}は{1}に存在しません。
                var msg = DaMessageService.GetMsg(EnumMessage.E004006, $"郵便情報{C_LEFT_BRACKET_HALF}{req.adrs_yubin}{C_RIGHT_BRACKET_HALF}", tm_aftyoazaDto.TABLE_NAME);
                res.SetServiceError(msg);
                return res;   //異常返し
            }

            //市区町村マスタ情報取得
            var sikudto = db.tm_afsikutyoson.GetDtoByKey(tyoazadto.sikucd);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //郵便情報取得
            res.yubininfo = Wraper.GetVM(db, tyoazadto, sikudto);

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(個人番号)
        /// </summary>
        private SearchPersonalResponse SearchPersonal(DaDbContext db, SearchPersonalRequest req)
        {
            var res = new SearchPersonalResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //個人番号取得
            var dtl = db.tt_afatena.GetDtoByKey(req.atenano);
            if (dtl == null) return res;

            var personalno = dtl.personalno;
            if (string.IsNullOrEmpty(personalno)) return res;

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------

            //権限関連
            var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, req.kinoid!);

            //暗号化
            var publickey = string.Empty;   //公開キー(暗号化)
            var privatekey = string.Empty;  //秘密キー(復号化)
                                            //キー取得
            DaEncryptUtil.GeneratePemRsaKeyPair(out publickey, out privatekey);

            res.personalno = (personalflg && !string.IsNullOrEmpty(personalno)) ?
                DaEncryptUtil.AesDecryptAndRsaEncrypt(personalno, publickey) : string.Empty;    //個人番号(暗号化)

            //rsaキー
            res.rsaprivatekey = privatekey;

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(自動付番)
        /// </summary>
        private SearchAutoSaibanResponse AutoSaisin(DaDbContext db, AutoSaibanRequest req)
        {
            var res = new SearchAutoSaibanResponse();

            var seqno = string.Empty;

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            if (req.seqflg.Equals("1"))
            {
                //世帯番号の場合
                seqno = DaControlService.GetRow(db, EnumCtrlKbn.付番開始番号, "01").value1;
            }
            else if (req.seqflg.Equals("2"))
            {
                //宛名番号の場合
                seqno = DaControlService.GetRow(db, EnumCtrlKbn.付番開始番号, "02").value1;
            }
            else
            {
                //異常の場合
                return res;
            }

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //最下位の１桁はチェックデジットを取得
            if (string.IsNullOrEmpty(seqno)) return res;

            var chkdigit = CalculateCheckDigit(seqno);

            res.seqno = $"{seqno}{CStr(chkdigit)}";

            //正常返し
            return res;
        }

        //************************************************************** 関数 **************************************************************
        /// <summary>
        /// kinoidから事業コード取得
        /// </summary>
        private string GetJigyocd(string kinoid)
        {
            return "090";
        }

        /// <summary>
        /// 存在チェック(削除)
        /// </summary>
        private static bool Check(DaDbContext db, string atenano)
        {
            //保健指導結果情報（固定項目）テーブル
            if (db.tt_kkhokensido_kekka.SELECT.WHERE.ByFilter($"{nameof(tt_kkhokensido_kekkaDto.atenano)}=@atenano", atenano).Exists()) { return true; }

            //保健指導申込情報（固定項目）テーブル
            if (db.tt_kkhokensido_mosikomi.SELECT.WHERE.ByFilter($"{nameof(tt_kkhokensido_mosikomiDto.atenano)}=@atenano", atenano).Exists()) { return true; }

            //集団指導参加者テーブル
            if (db.tt_kksyudansido_sankasya.SELECT.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyaDto.atenano)}=@atenano", atenano).Exists()) { return true; }

            //集団指導参加者（フリー項目）入力情報テーブル
            if (db.tt_kksyudansido_sankasyafree.SELECT.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyafreeDto.atenano)}=@atenano", atenano).Exists()) { return true; }

            //成人保健一次検診結果（固定項目）テーブル
            if (db.tt_shkensin.SELECT.WHERE.ByFilter($"{nameof(tt_shkensinDto.atenano)}=@atenano", atenano).Exists()) { return true; }

            //成人保健精密検査結果（固定項目）テーブル
            if (db.tt_shseiken.SELECT.WHERE.ByFilter($"{nameof(tt_shseikenDto.atenano)}=@atenano", atenano).Exists()) { return true; }

            return false;
        }

        /// <summary>
        /// 同一世帯員情報更新の実施条件チェック
        /// </summary>
        private static bool SeitaiChgChk(DaDbContext db, MainInfoVM mainvm, SeitaiInfoVM seitaivm)
        {
            //下記条件を満たす場合、同一世帯員の情報更新を実施する
            //①「基本情報（世帯）」項目の変更がある
            if (!ChkItemChanges(mainvm, seitaivm)) { return false; }

            //②同一世帯員情報の更新が設定されいる　※tm_afctrl(1001-2)に設定
            if (!CBool(DaControlService.GetRow(db, EnumCtrlKbn.同一世帯員更新フラグ, "01").value1)) { return false; }

            //③表示中の住登外者の住民区分は「住登外」である
            if (GetJutokbn(db, mainvm.atenano).Equals(Enum住登区分.住登外)) { return false; }

            return true;
        }


        /// <summary>
        /// 「基本情報（世帯）」項目変更があるかどうかのチェック
        /// </summary>
        private static bool ChkItemChanges(MainInfoVM mainvm, SeitaiInfoVM seitaivm)
        {
            if (!CStr(seitaivm.setaino).Equals(mainvm.setaino)) { return true; }                        //世帯番号
            if (!CStr(seitaivm.adrs_yubin).Equals(mainvm.adrs_yubin)) { return true; }                  //郵便番号
            if (!CStr(seitaivm.tosi_gyoseikucd).Equals(mainvm.tosi_gyoseikucd)) { return true; }        //指定都市_行政区等コード
            if (!CStr(seitaivm.adrs_sikucd).Equals(mainvm.adrs_sikucd)) { return true; }                //市区町村
            if (!CStr(seitaivm.adrs_tyoazacd).Equals(mainvm.adrs_tyoazacd)) { return true; }            //町字コード
            if (!CStr(seitaivm.adrs_tyoaza).Equals(mainvm.adrs_tyoaza)) { return true; }                //町字名
            if (!CStr(seitaivm.adrs_bantihyoki).Equals(mainvm.adrs_bantihyoki)) { return true; }        //番地号表記
            if (!CStr(seitaivm.adrs_katagaki_kana).Equals(mainvm.adrs_katagaki_kana)) { return true; }  //方書(フリガナ)
            if (!CStr(seitaivm.adrs_katagaki).Equals(mainvm.adrs_katagaki)) { return true; }            //方書(漢字)

            return false;
        }

        /// <summary>
        /// 表示中の住登外者の住民区分を取得
        /// </summary>
        private static string GetJutokbn(DaDbContext db, string atenano)
        {
            var value = db.tt_afatena.GetDtoByKey(atenano).jutokbn;

            return CStr(value);
        }


        /// <summary>
        /// チェックデジットの算出方式はモジュラス 11（M11W２～７）
        /// </summary>
        static int CalculateCheckDigit(string input)
        {
            int sum = 0;

            // 重み付けされた数字を計算
            for (int i = 0; i < input.Length; i++)
            {
                int digit = int.Parse(input[input.Length - i - 1].ToString());
                int weight = (i) % 6 + 2; // M11W2～7の規則に基づく重み付け
                sum += digit * weight;
            }

            // モジュラス11を計算
            int remainder = sum % 11;

            // チェックデジットを計算
            int checkDigit = (11 - remainder) % 11;

            if (checkDigit == 10) { return 0; }
            return checkDigit;
        }

        /// <summary>
        /// 住登外者種別、住登外者状態の値から住民区分の表示内容を取得
        /// </summary>
        public static string GetJuminkbn(DaDbContext db, string jutokbn, string juminbetu, string juminjotai)
        {
            var nmDto = DaNameService.GetNameList(db, EnumNmKbn.住民区分設定).Find(x => x.nmcd == $"{jutokbn}{juminbetu}{juminjotai}")!;

            if (nmDto == null || string.IsNullOrEmpty(nmDto.hanyokbn1)) { return string.Empty; }

            var hanyokbn1 = CStr(nmDto.hanyokbn1);                                      //住民種別内容

            var juminkbn = Wraper.MNm(db, hanyokbn1, EnumNmKbn.住民区分);
            return juminkbn;                                                            //住民区分
        }
    }
}