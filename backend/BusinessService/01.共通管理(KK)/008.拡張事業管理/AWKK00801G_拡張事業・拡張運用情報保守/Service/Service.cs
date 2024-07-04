// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 拡張事業・拡張運用情報保守
// 　　　　　　サービス処理
// 作成日　　: 2023.12.25
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaStrPool;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;

namespace BCC.Affect.Service.AWKK00801G
{
    [DisplayName("拡張事業・拡張運用情報保守")]
    public class Service : CmServiceBase
    {
        public const string AWSH001 = "AWSH001";//機能ID(固定頭)
        public const string AWKK00301G = "AWKK00301G"; //保健指導管理
        private const string AWSH00107G = "AWSH00107G";//機能ID(乳がん：詳細条件初期データ必要)
        public const string MAINCD1 = 名称マスタ.システム.名称マスタメインコード._3019; //検査方法：コード体系
        public const string MAINCD2 = 名称マスタ.システム.名称マスタメインコード._1002; //予約分類、グループ2：コード体系
        private int ST1 = 0;//関連事業コード体系スタートNo.(メモ事業コード)
        private int ST2 = 0;//関連事業コード体系スタートNo.(電子ファイル事業コード)
        private int ST3 = 0;//関連事業コード体系スタートNo.(医療機関・事業従事者（担当者）事業コード)
        private const int GRPKBN2LEN = 5;//保健指導・集団指導項目グループ用汎用区分2内容の固定長さ
        private int MAX = 0;//拡張事業上限件数
        private const string PROC_NAME1 = "sp_awkk00801g_01";
        private const string PROC_NAME2 = "sp_awkk00801g_02";
        private const string PROC_NAME3 = "sp_awkk00801g_03";
        private const string PROC_NAME4 = "sp_awkk00801g_04";
        private const string PROC_NAME5 = "sp_awkk00801g_05";
        private const string PROC_NAME6 = "sp_awkk00801g_06";
        private const string PROC_NAME7 = "sp_awkk00801g_07";
        private const string PROC_NAME8 = "sp_awkk00801g_08";

        // **************************************************************************************************************************************
        // 選択画面
        // **************************************************************************************************************************************
        [DisplayName("初期化処理(選択画面)")]
        public InitChoiceResponse InitChoice(InitChoiceRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitChoiceResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //拡張事業種類データ取得
                var list = DaNameService.GetNameList(db, EnumNmKbn.拡張事業種類);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //業務区分ドロップダウンリスト
                res.selectorlist1 = DaNameService.GetSelectorList(db, EnumNmKbn.拡張事業業務, req.kbn1);
                //種類区分ドロップダウンリスト
                res.selectorlist2 = Wraper.GetSelectorList(list, req.kbn2);

                //正常返し
                return res;
            });
        }
        // **************************************************************************************************************************************
        // 検診事業一覧画面
        // **************************************************************************************************************************************
        [DisplayName("初期化処理(検診事業一覧画面)")]
        public InitKensinListResponse InitKensinJigyoList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitKensinListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //事業一覧を取得(停止を含む)
                var dtl1 = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.検診種別).ToList();
                //事業コード一覧
                var keyList = dtl1.Select(e => e.hanyocd).ToList();
                //成人健（検）診事業マスタ
                var dtl2 = db.tm_shkensinjigyo.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

                //拡張事業上限件数
                MAX = DaControlService.GetRow(db, EnumCtrlKbn.拡張事業関連上限件数, コントロールマスタ.システム.拡張事業関連上限件数._01).IntValue1;

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //停止していない事業コード一覧
                var keyList2 = dtl1.Where(e => !e.stopflg).Select(e => e.hanyocd).ToList();
                //停止していない拡張事業一覧
                var dtl3 = dtl2.Where(e => e.kihonkakutyokbn == Enum事業区分.市区町村拡張事業 && keyList2.Contains(e.jigyocd)).ToList();
                //拡張事業一次件数
                var ct = dtl3.Count();
                //拡張事業精密件数
                var ct2 = dtl3.Where(e => e.seikenjissikbn == Enum精密検査実施区分.実施).ToList().Count();

                //検診事業一覧
                res.kekkalist = Wraper.GetVMList(db, dtl1, dtl2);
                //新規フラグ
                res.insertflg = (ct < MAX);
                //拡張事業入力件数カウント
                res.kensucnt = $"市区町村拡張事業（一次{ct}/{MAX}、精密{ct2}/{MAX}）";

                //正常返し
                return res;
            });
        }
        // **************************************************************************************************************************************
        // 検診事業詳細画面
        // **************************************************************************************************************************************
        [DisplayName("初期化処理(検診事業詳細画面)")]
        public InitKensinDetailResponse InitKensinJigyoDetail(InitKensinCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitKensinDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //汎用マスタ：事業名
                tm_afhanyoDto? dto1 = null;
                if (!string.IsNullOrEmpty(req.jigyocd))
                {
                    dto1 = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.検診種別, req.jigyocd!);
                }
                //機能マスタ
                tm_afkinoDto? dto2 = null;
                if (!string.IsNullOrEmpty(req.jigyocd))
                {
                    dto2 = db.tm_afkino.SELECT.WHERE.ByFilter($@"{nameof(tm_afkinoDto.hanyokbn)} = @{nameof(tm_afkinoDto.hanyokbn)} and 
                                                            {nameof(tm_afkinoDto.kinoid)} like '{AWSH001}%'", req.jigyocd).GetDto();
                }
                //成人健（検）診事業マスタ
                tm_shkensinjigyoDto? dto3 = null;
                if (!string.IsNullOrEmpty(req.jigyocd))
                {
                    dto3 = db.tm_shkensinjigyo.GetDtoByKey(req.jigyocd!);
                }
                //汎用メインマスタ：サブコード名
                tm_afhanyo_mainDto? dto4 = null;
                //汎用マスタ：検査方法一覧
                var dtl1 = new List<tm_afhanyoDto>();
                if (!string.IsNullOrEmpty(req.jigyocd))
                {
                    //サブコード(検査方法)
                    var kensahoho_subcd = CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, req.jigyocd!);
                    dto4 = db.tm_afhanyo_main.GetDtoByKey(MAINCD1, CInt(kensahoho_subcd));
                    dtl1 = DaHanyoService.GetHanyoNoDelDtl(db, MAINCD1, CInt(kensahoho_subcd));
                }
                //汎用メインマスタ：サブコード名
                tm_afhanyo_mainDto? dto5 = null;
                //汎用マスタ：予約分類一覧
                var dtl2 = new List<tm_afhanyoDto>();
                if (!string.IsNullOrEmpty(req.jigyocd))
                {
                    //サブコード(予約分類)
                    var yoyakubunrui_subcd = CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.予約分類, req.jigyocd!);
                    dto5 = db.tm_afhanyo_main.GetDtoByKey(MAINCD2, CInt(yoyakubunrui_subcd));
                    dtl2 = DaHanyoService.GetHanyoNoDelDtl(db, MAINCD2, CInt(yoyakubunrui_subcd));
                }
                //汎用メインマスタ：サブコード名
                tm_afhanyo_mainDto? dto6 = null;
                //汎用マスタ：検査分類一覧
                var dtl3 = new List<tm_afhanyoDto>();
                if (!string.IsNullOrEmpty(req.jigyocd))
                {
                    //サブコード(グループ2)
                    var groupid2_subcd = CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.グループ2, req.jigyocd!);
                    dto6 = db.tm_afhanyo_main.GetDtoByKey(MAINCD2, CInt(groupid2_subcd));
                    dtl3 = DaHanyoService.GetHanyoNoDelDtl(db, MAINCD2, CInt(groupid2_subcd));
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //------------------------------------------------------------- 
                //検診項目一覧画面ヘッダー情報
                res.headerinfo = Wraper.GetHeaderVM(db, dto1);
                //検診事業情報(事業内容)
                res.jigyoinfo = Wraper.GetJigyoVM(db, dto2, dto3);
                //検診事業情報(検査方法)
                res.hohoinfo = Wraper.GetHohoVM(db, MAINCD1, dto3, dto4, dtl1);
                //検診事業情報(予約分類)
                res.yoyakuinfo = Wraper.GetYoyakuVM(db, MAINCD2, dto5, dtl2);
                //検診事業情報(フリー項目)
                res.freeinfo = Wraper.GetFreeVM(db, MAINCD2, dto6, dtl3);
                //検診事業情報(エラーチェック)
                res.errorchkinfo = Wraper.GetErrorchkVM(db, dto3);
                //精密検査実施区分ドロップダウンリスト
                res.selectorlist1 = DaNameService.GetSelectorList(db, EnumNmKbn.精密検査実施区分, Enum名称区分.名称);
                //クーポン券表示区分ドロップダウンリスト
                res.selectorlist2 = DaNameService.GetSelectorList(db, EnumNmKbn.クーポン券表示区分, Enum名称区分.名称);
                //減免区分ドロップダウンリスト
                res.selectorlist3 = DaNameService.GetSelectorList(db, EnumNmKbn.減免区分種別, Enum名称区分.名称);
                //生涯１回フラグドロップダウンリスト
                res.selectorlist4 = DaNameService.GetSelectorList(db, EnumNmKbn.生涯一回フラグ, Enum名称区分.名称);
                //メッセージ区分一覧ドロップダウンリスト
                res.selectorlist5 = DaNameService.GetSelectorList(db, EnumNmKbn.メッセージ切替区分, Enum名称区分.名称);

                //更新日時(排他用)
                if (dto3 != null)
                {
                    res.upddttm = dto3.upddttm;
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理(検診事業詳細画面)")]
        public SaveKensinJigyoDetailResponse SaveKensinJigyoDetail(SaveKensinJigyoDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new SaveKensinJigyoDetailResponse();

                //-------------------------------------------------------------
                //１.チェック処理(新規の場合のみ)
                //-------------------------------------------------------------
                //事業一覧を取得(停止を含む)
                var dtl1 = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.検診種別).ToList();
                //事業コード一覧
                var keyList1 = dtl1.Select(e => e.hanyocd).ToList();
                //成人健（検）診事業マスタ
                var dtl2 = db.tm_shkensinjigyo.SELECT.WHERE.ByKeyList(keyList1).GetDtoList();

                //停止していない事業コード一覧
                var keyList2 = dtl1.Where(e => !e.stopflg).Select(e => e.hanyocd).ToList();
                //停止していない拡張事業一覧
                var dtl3 = dtl2.Where(e => e.kihonkakutyokbn == Enum事業区分.市区町村拡張事業 && keyList2.Contains(e.jigyocd)).ToList();
                //拡張事業一次件数
                var ct = dtl3.Count();

                //-------------------------------------------------------------
                //２.データ取得(事業コード)
                //-------------------------------------------------------------
                //成人健（検）診事業マスタ
                var dto1 = new tm_shkensinjigyoDto();
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    MAX = DaControlService.GetRow(db, EnumCtrlKbn.拡張事業関連上限件数, コントロールマスタ.システム.拡張事業関連上限件数._01).IntValue1;
                    if (ct >= MAX)
                    {
                        //エラーメッセージ設定
                        res.SetServiceError(EnumMessage.E014006);
                        //異常返し
                        return res;
                    }
                    var cdMax = CInt(db.tm_shkensinjigyo.SELECT.GetMax<int>(nameof(tm_shkensinjigyoDto.jigyocd)));
                    if (cdMax > CmLogicUtil.AWSH001_CT)
                    {
                        cdMax += 1;
                    }
                    else
                    {
                        cdMax = CmLogicUtil.AWSH001_ST;
                    }
                    //新規事業コード
                    req.jigyocd = cdMax.ToString();
                }
                //変更の場合
                else
                {
                    dto1 = db.tm_shkensinjigyo.GetDtoByKey(req.jigyocd!);
                }

                //-------------------------------------------------------------
                //３.データ加工処理(事業コード)
                //-------------------------------------------------------------
                //成人健（検）診事業マスタ
                dto1 = Converter.GetDto(dto1, req, MAINCD1, MAINCD2);

                //-------------------------------------------------------------
                //４.DB更新処理(事業コード)
                //-------------------------------------------------------------
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //成人健（検）診事業マスタ：ベースで主キー重複チェック
                    db.tm_shkensinjigyo.INSERT.Execute(dto1);
                }
                //変更の場合
                else
                {
                    //成人健（検）診事業マスタ：排他チェック
                    db.tm_shkensinjigyo.UpdateDto(dto1, req.upddttm!.Value);
                }

                //-------------------------------------------------------------
                //５.データ取得
                //-------------------------------------------------------------
                //メニューマスタ
                var dto2 = new tm_afmenuDto();
                //変更の場合
                if (req.editkbn == Enum編集区分.変更)
                {
                    dto2 = db.tm_afmenu.GetDtoByKey(req.jigyoinfo.kinoid!);
                }
                //汎用マスタ：事業名
                var dto4 = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.検診種別, req.jigyocd!);

                //-------------------------------------------------------------
                //６.データ加工処理
                //-------------------------------------------------------------
                //メニューマスタ
                int seqmax = 0;
                if (string.IsNullOrEmpty(req.jigyoinfo.kinoid))
                {
                    seqmax = db.tm_afmenu.SELECT.WHERE.ByItem(nameof(tm_afmenuDto.oyamenuid), AWSH001).GetMax<int>(nameof(tm_afmenuDto.orderseq));
                }
                dto2 = Converter.GetDto(dto2, req, AWSH001, seqmax);
                //機能マスタ
                var dto3 = Converter.GetDto(req, AWSH001);
                //汎用メインマスタ
                var dtl4 = Converter.GetMainDtl(req, MAINCD1, MAINCD2);
                //汎用メインマスタ/汎用マスタ：キーリスト
                var keyList3 = new List<object[]>();
                keyList3.Add(new object[] { MAINCD1, CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, req.jigyocd!) });
                keyList3.Add(new object[] { MAINCD2, CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.予約分類, req.jigyocd!) });
                keyList3.Add(new object[] { MAINCD2, CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.グループ2, req.jigyocd!) });
                //汎用マスタ：事業名
                var maincd = 名称マスタ.システム.汎用マスタメインコード._3019;
                var subcd = (int)((long)EnumHanyoKbn.検診種別 % DaNameService.MAINCODE_DIGIT);
                dto4 = Converter.GetDto(dto4, req, maincd, subcd);
                //汎用マスタ
                var dtl5 = Converter.GetDtl(req, MAINCD1, MAINCD2);

                //-------------------------------------------------------------
                //７.DB更新処理
                //-------------------------------------------------------------
                //機能ID
                var kinoid = Converter.GetKinoid(req);
                //メニューマスタ
                db.tm_afmenu.UPDATE.WHERE.ByKey(kinoid).Execute(new List<tm_afmenuDto>() { dto2 });
                //機能マスタ
                db.tm_afkino.UPDATE.WHERE.ByKey(kinoid).Execute(new List<tm_afkinoDto>() { dto3 });
                //汎用メインマスタ
                db.tm_afhanyo_main.UPDATE.WHERE.ByKeyList(keyList3).Execute(dtl4);
                //汎用マスタ：事業名
                db.tm_afhanyo.UPDATE.WHERE.ByKey(maincd, subcd, req.jigyocd!).Execute(new List<tm_afhanyoDto>() { dto4 });
                //汎用マスタ
                db.tm_afhanyo.UPDATE.WHERE.ByKeyList(keyList3).Execute(dtl5);

                //-------------------------------------------------------------
                //８.データ取得(ディフォルト設定処理：詳細条件、共通バー)
                //-------------------------------------------------------------
                //詳細条件設定テーブル
                List<tt_affilterDto> dtl6 = new List<tt_affilterDto>();
                //共通バー設定
                var barList = DaNameService.GetNameList(db, EnumNmKbn.共通バー表示);
                //共通バー設定(該当機能)
                var dtl8 = barList.Where(e => e.hanyokbn1 == kinoid).ToList();
                //関連事業コード設定
                List<tm_afhanyoDto>? dtl9 = null;
                //事業コード管理
                var maincd4 = 名称マスタ.システム.汎用マスタメインコード._1000;
                var subcd8 = (int)((long)EnumHanyoKbn.メモ事業コード管理 % DaNameService.MAINCODE_DIGIT);                //メモ事業コード管理
                var subcd9 = (int)((long)EnumHanyoKbn.電子ファイル事業コード管理 % DaNameService.MAINCODE_DIGIT);        //電子ファイル事業コード管理
                var subcd10 = (int)((long)EnumHanyoKbn.連絡先事業コード管理 % DaNameService.MAINCODE_DIGIT);             //連絡先事業コード管理
                var subcd6 = (int)((long)EnumHanyoKbn.医療機関事業コード管理 % DaNameService.MAINCODE_DIGIT);            //医療機関事業コード管理
                var subcd7 = (int)((long)EnumHanyoKbn.事業従事者事業コード管理 % DaNameService.MAINCODE_DIGIT);          //事業従事者事業コード管理

                //キーリスト(事業コード管理)
                var keyList5 = new List<object[]>();
                keyList5.Add(new object[] { maincd4, subcd8, kinoid });
                keyList5.Add(new object[] { maincd4, subcd9, kinoid });
                keyList5.Add(new object[] { maincd4, subcd10, kinoid });
                keyList5.Add(new object[] { maincd4, subcd6, kinoid });
                keyList5.Add(new object[] { maincd4, subcd7, kinoid });
                var dtl10 = db.tm_afhanyo.SELECT.WHERE.ByKeyList(keyList5).GetDtoList();
                //各種事業コード設定対象
                var dto5 = DaNameService.GetNameList(db, EnumNmKbn.各種事業コード設定対象).Find(e => e.nmcd == kinoid);

                //-------------------------------------------------------------
                //９.データ加工処理(ディフォルト設定処理：詳細条件、共通バー、関連事業コード)
                //-------------------------------------------------------------
                //関連事業コード設定
                var maincd3 = 名称マスタ.システム.汎用マスタメインコード._3019;
                //汎用マスタ：メモ事業コード
                var subcd3 = (int)((long)EnumHanyoKbn.メモ事業コード % DaNameService.MAINCODE_DIGIT);
                var subcd4 = (int)((long)EnumHanyoKbn.電子ファイル事業コード % DaNameService.MAINCODE_DIGIT);
                var subcd5 = (int)((long)EnumHanyoKbn.医療機関_事業従事者_担当者_事業コード % DaNameService.MAINCODE_DIGIT);

                //ユーザー領域コード体系 
                res = GetUserRyoikiInfo(db, res, maincd3, subcd3, subcd4, subcd5,
                                            out string cd1, out string cd2, out string cd3);
                if (!string.IsNullOrEmpty(res.message))
                {
                    //エラーメッセージ設定がる、異常返し
                    return res;
                }

                //キーリスト(詳細条件)
                var keyList6 = new List<object[]>();
                keyList6.Add(new object[] { kinoid, EnumToStr(Enum詳細検索条件区分.独自), 2 });
                keyList6.Add(new object[] { kinoid, EnumToStr(Enum詳細検索条件区分.独自), 3 });

                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //詳細条件設定テーブル
                    var dtl11 = db.tt_affilter.SELECT.WHERE.ByKey(AWSH00107G, EnumToStr(Enum詳細検索条件区分.共通)).GetDtoList();
                    dtl6 = Converter.GetDtl(dtl11, kinoid, MAINCD1, CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, req.jigyocd!),
                                            dto1.seikenjissikbn == Enum精密検査実施区分.実施, dto1.kensahoho_setflg, req.editkbn);
                    //共通バー設定(ディフォルト設定)
                    var dtl7 = barList.Where(e => e.hanyokbn1 == AWSH00107G).ToList();
                    dtl8 = Converter.GetDtl(dtl7, AWSH00107G, kinoid, dto3.hyojinm);
                }
                else
                {
                    //詳細条件設定テーブル
                    var dtl12 = db.tt_affilter.SELECT.WHERE.ByKeyList(keyList6).GetDtoList();
                    dtl6 = Converter.GetDtl(dtl12, kinoid, MAINCD1, CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, req.jigyocd!),
                                            dto1.seikenjissikbn == Enum精密検査実施区分.実施, dto1.kensahoho_setflg, req.editkbn);
                    //共通バー設定(名称変更)
                    dtl8 = Converter.GetDtl(dtl8, AWSH00107G, kinoid, dto3.hyojinm);
                }
                dtl9 = new List<tm_afhanyoDto>();
                //関連事業コード
                if (req.editkbn == Enum編集区分.新規)
                {
                    dtl9 = Converter.GetDtl(maincd3, subcd3, subcd4, subcd5, subcd6, subcd7, cd1, cd2, cd3, kinoid, req.jigyonm);
                }
                //事業コード管理
                dtl10 = Converter.GetDtl(dtl10, maincd4, subcd8, subcd9, subcd10, subcd6, subcd7, cd3, kinoid, req.jigyonm, req.editkbn);

                //メインコード(共通バー設定、各種事業コード設定対象)
                var maincd2 = 名称マスタ.システム.名称マスタメインコード._1000;
                //各種事業コード設定対象
                var subcd11 = (int)((long)EnumNmKbn.各種事業コード設定対象 % DaNameService.MAINCODE_DIGIT);
                //集約コード設定フラグ
                var flg = DaNameService.GetKbn1(db, EnumNmKbn.各種事業コード設定対象, AWSH00107G);
                dto5 = Converter.GetDto(dto5, maincd2, subcd11, kinoid, req.jigyonm, flg, req.editkbn);

                //-------------------------------------------------------------
                //１０.DB更新処理(ディフォルト設定処理：詳細条件、共通バー、関連事業コード)
                //-------------------------------------------------------------
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //詳細条件設定テーブル
                    db.tt_affilter.UPDATE.WHERE.ByKey(kinoid).Execute(dtl6);
                }
                //編集の場合
                else
                {
                    //詳細条件設定テーブル
                    db.tt_affilter.UPDATE.WHERE.ByKeyList(keyList6).Execute(dtl6);
                }
                //共通バー設定
                var subcd2 = (int)((long)EnumNmKbn.共通バー表示 % DaNameService.MAINCODE_DIGIT);
                db.tm_afmeisyo.UPDATE.WHERE.ByFilter($@"{nameof(tm_afmeisyoDto.nmmaincd)} = @{nameof(tm_afmeisyoDto.nmmaincd)}  
                                                        and {nameof(tm_afmeisyoDto.nmsubcd)} = @{nameof(tm_afmeisyoDto.nmsubcd)} 
                                                        and {nameof(tm_afmeisyoDto.hanyokbn1)} = @{nameof(tm_afmeisyoDto.hanyokbn1)}",
                                                        maincd2, subcd2, kinoid).Execute(dtl8);
                //関連事業コード
                var keyList4 = new List<object[]>();
                keyList4.Add(new object[] { maincd3, subcd3, cd1 });
                keyList4.Add(new object[] { maincd3, subcd4, cd2 });
                keyList4.Add(new object[] { maincd3, subcd5, cd3 });
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    keyList4.Add(new object[] { maincd4, subcd6, kinoid });
                    keyList4.Add(new object[] { maincd4, subcd7, kinoid });
                }
                db.tm_afhanyo.UPDATE.WHERE.ByKeyList(keyList4.Concat(keyList5).ToList()).Execute(dtl9.Concat(dtl10).ToList());

                //各種事業コード設定対象
                db.tm_afmeisyo.UPDATE.WHERE.ByKey(maincd2, subcd11, kinoid).Execute(new List<tm_afmeisyoDto>() { dto5 });

                //キャシュークリア
                DaSelectorService.ClearCache();

                //-------------------------------------------------------------
                //１１.データ加工処理
                //-------------------------------------------------------------
                //機能ID
                res.kinoid = CmLogicUtil.GetKensinKinoid(req.jigyocd!);

                //正常返し
                return res;
            });
        }

        // **************************************************************************************************************************************
        // 検診項目一覧画面
        // **************************************************************************************************************************************
        [DisplayName("初期化処理(検診項目一覧画面)")]
        public InitKensinItemListResponse InitKensinItemList(InitKensinCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitKensinItemListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //汎用マスタ：事業名
                var dto1 = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.検診種別, req.jigyocd!);

                //成人保健検診結果（フリー）項目コントロールマスタ
                var dtl1 = db.tm_shfreeitem.SELECT.WHERE.ByKey(req.jigyocd!).GetDtoList().OrderBy(e => e.orderseq).ToList();

                //成人健（検）診事業マスタ
                var dto2 = db.tm_shkensinjigyo.GetDtoByKey(req.jigyocd!);

                //汎用マスタ：検査方法
                var dtl2 = new List<tm_afhanyoDto>();
                if (dto2.kensahoho_setflg)
                {
                    dtl2 = DaHanyoService.GetHanyoDtl(db, dto2.kensahoho_maincd!, dto2.kensahoho_subcd!.Value);
                }

                //拡張事業上限件数
                var maxList = DaControlService.GetList(db, EnumCtrlKbn.拡張事業関連上限件数);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //検診項目一覧画面ヘッダー情報
                res.headerinfo = Wraper.GetHeaderVM(db, dto1);
                //検診項目一覧
                res.kekkalist = Wraper.GetVMList(db, dtl1, dtl2);

                //半角タイプ入力項目の上限件数
                var halfMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._02)!.IntValue1;
                //日付タイプ入力項目の上限件数
                var dayMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._03)!.IntValue1;
                //全角タイプ入力項目の上限件数
                var fullMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._04)!.IntValue1;
                //コードタイプ入力項目の上限件数
                var cdMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._05)!.IntValue1;
                //半角タイプ入力項目の件数
                var halfCt = res.kekkalist.Where(e => e.kakutyokbn == "○" && e.inputtypekbn == Enum入力タイプ分類.半角).Count();
                //日付タイプ入力項目の件数
                var dayCt = res.kekkalist.Where(e => e.kakutyokbn == "○" && e.inputtypekbn == Enum入力タイプ分類.日付).Count();
                //全角タイプ入力項目の件数
                var fullCt = res.kekkalist.Where(e => e.kakutyokbn == "○" && e.inputtypekbn == Enum入力タイプ分類.全角).Count();
                //コードタイプ入力項目の件数
                var cdCt = res.kekkalist.Where(e => e.kakutyokbn == "○" && e.inputtypekbn == Enum入力タイプ分類.コード).Count();

                //半角タイプ入力項目の件数（一次）
                var halfCt1 = res.kekkalist.Where(e => e.kakutyokbn == "○" && e.inputtypekbn == Enum入力タイプ分類.半角
                                                                            && e.groupid == EnumToStr(EnumKensinKbn.一次)).Count();
                //日付タイプ入力項目の件数（一次）
                var dayCt1 = res.kekkalist.Where(e => e.kakutyokbn == "○" && e.inputtypekbn == Enum入力タイプ分類.日付
                                                                           && e.groupid == EnumToStr(EnumKensinKbn.一次)).Count();
                //全角タイプ入力項目の件数（一次）
                var fullCt1 = res.kekkalist.Where(e => e.kakutyokbn == "○" && e.inputtypekbn == Enum入力タイプ分類.全角
                                                                            && e.groupid == EnumToStr(EnumKensinKbn.一次)).Count();
                //コードタイプ入力項目の件数（一次）
                var cdCt1 = res.kekkalist.Where(e => e.kakutyokbn == "○" && e.inputtypekbn == Enum入力タイプ分類.コード
                                                                          && e.groupid == EnumToStr(EnumKensinKbn.一次)).Count();
                //コードタイプの場合、「検査方法」が設定されている場合、1をカウントする（一次検診の場合だけ）
                var keasahohoCt = res.kekkalist.Where(e => e.kakutyokbn == "○" && e.inputtypekbn == Enum入力タイプ分類.コード
                                                                          && e.groupid == EnumToStr(EnumKensinKbn.一次)
                                                                          && !string.IsNullOrEmpty(e.riyokensahohonms)).Count();
                var cdAndkensahohoCt1 = cdCt1 + keasahohoCt;

                //半角タイプ入力上限値フラグ（一次）
                res.halfflg1 = halfCt1 >= halfMax;
                //日付タイプ入力上限値フラグ（一次）
                res.dayflg1 = dayCt1 >= dayMax;
                //全角タイプ入力上限値フラグ（一次）
                res.fullflg1 = fullCt1 >= fullMax;
                //コードタイプ入力上限値フラグ（一次）
                res.cdflg1 = cdAndkensahohoCt1 >= cdMax;

                //半角タイプ入力項目の件数（精密）
                var halfCt2 = halfCt - halfCt1;
                //日付タイプ入力項目の件数（精密）
                var dayCt2 = dayCt - dayCt1;
                //全角タイプ入力項目の件数（精密）
                var fullCt2 = fullCt - fullCt1;
                //コードタイプ入力項目の件数（精密）
                var cdCt2 = cdCt - cdCt1;

                //半角タイプ入力上限値フラグ（精密）
                res.halfflg2 = halfCt2 >= halfMax;
                //日付タイプ入力上限値フラグ（精密）
                res.dayflg2 = dayCt2 >= dayMax;
                //全角タイプ入力上限値フラグ（精密）
                res.fullflg2 = fullCt2 >= fullMax;
                //コードタイプ入力上限値フラグ（精密）
                res.cdflg2 = cdCt2 >= cdMax;

                //拡張事業入力件数カウント（一次）
                res.kensuichijicnt = $"市区町村拡張項目（一次検診）（半角{halfCt1}/{halfMax}、日付{dayCt1}/{dayMax}、全角{fullCt1}/{fullMax}、コード{cdAndkensahohoCt1}/{cdMax}）";
                //拡張事業入力件数カウント（精密）
                res.kensuseimitsucnt = $"市区町村拡張項目（精密検査）（半角{halfCt2}/{halfMax}、日付{dayCt2}/{dayMax}、全角{fullCt2}/{fullMax}、コード{cdCt2}/{cdMax}）";

                //ボタン制御フラグ(新規・コピー)
                res.buttonflg = (halfCt1 < halfMax || dayCt1 < dayMax || fullCt1 < fullMax || cdAndkensahohoCt1 < cdMax)
                                || (halfCt2 < halfMax || dayCt2 < dayMax || fullCt2 < fullMax || cdCt2 < cdMax);

                //正常返し
                return res;
            });
        }
        // **************************************************************************************************************************************
        // 検診項目詳細画面
        // **************************************************************************************************************************************
        [DisplayName("初期化処理(検診項目詳細画面)")]
        public InitKensinItemDetailResponse InitKensinItemDetail(InitKensinItemDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitKensinItemDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //汎用マスタ：事業名
                var dto1 = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.検診種別, req.jigyocd);
                //成人保健検診結果（フリー）項目コントロールマスタ
                tm_shfreeitemDto? dto2 = null;
                if (req.editkbn == Enum編集区分.変更 || (req.editkbn == Enum編集区分.新規 && req.copyflg))
                {
                    dto2 = db.tm_shfreeitem.GetDtoByKey(req.jigyocd, req.itemcd!);
                }
                //成人健（検）診事業マスタ
                var dto3 = db.tm_shkensinjigyo.GetDtoByKey(req.jigyocd);
                //成人保健検診結果（フリー）項目コントロールマスタ
                var dtl = db.tm_shfreeitem.SELECT.WHERE.ByKey(req.jigyocd).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //条件コード一覧取得
                if (dto2?.inputtype != null)
                {
                    res = (InitKensinItemDetailResponse)GetCodejokenListResponse(db, res, dto2.inputtype, dto2.codejoken1, dto2.codejoken2, dto2.codejoken3, req.jigyocd, EnumToStr(dto2.groupid));
                }

                //検診項目詳細画面ヘッダー情報
                res.headerinfo = Wraper.GetHeaderVM(db, dto1);
                //検診項目詳細
                res.detailinfo = Wraper.GetVM(db, dto2, req.copyflg, MAINCD2, req.jigyocd);

                //グループIDドロップダウンリスト
                res.selectorlist1 = DaNameService.GetSelectorList(db, EnumNmKbn.成人保健フリー項目グループ１, Enum名称区分.名称);
                //メッセージ区分ドロップダウンリスト
                res.selectorlist3 = DaNameService.GetSelectorList(db, EnumNmKbn.メッセージ切替区分, Enum名称区分.名称);
                //入力タイプドロップダウンリスト（一次）
                res.selectorlist4_1 = GetInputTypeList(db, req.halfflg1, req.dayflg1, req.cdflg1, req.fullflg1);
                //入力タイプドロップダウンリスト（精密）
                res.selectorlist4_2 = GetInputTypeList(db, req.halfflg2, req.dayflg2, req.cdflg2, req.fullflg2);
                //計算区分ドロップダウンリスト
                res.selectorlist9 = DaNameService.GetSelectorList(db, EnumNmKbn.計算区分, Enum名称区分.名称);
                //計算関数ID(内部)ドロップダウンリスト(キー：引数個数)
                res.selectorlist10 = DaNameService.GetNameList(db, EnumNmKbn.計算関数_内部).Select(e => new DaSelectorKeyModel(e.nmcd, e.nm, e.hanyokbn1)).ToList();
                //計算関数ID(内部)備考
                res.idNaibubiko = DaNameService.GetBiko(db, EnumNmKbn.計算関数_内部, 計算関数_内部._1);
                //計算関数ID(DB)ドロップダウンリスト(キー：引数個数)
                var dtlDB = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.計算関数_DB);
                res.selectorlist11 = dtlDB.Select(e => new DaSelectorKeyModel(e.hanyocd, e.nm, e.hanyokbn1)).ToList();
                //計算関数ID(DB)備考
                var 計算関数_DB_1 = "1";
                res.idDbbiko = CStr(DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.計算関数_DB, 計算関数_DB_1).biko);

                if (!string.IsNullOrEmpty(dto3.groupid2_maincd))
                {
                    //グループID2ドロップダウンリスト
                    res.selectorlist2 = DaHanyoService.GetSelectorList(db, dto3.groupid2_maincd, CInt(dto3.groupid2_subcd), Enum名称区分.名称, false);
                    //表示区分(グループID2)
                    res.showkbn1 = true;
                }

                res.selectorlist8 = new List<DaSelectorModel>();
                if (!string.IsNullOrEmpty(dto3.kensahoho_maincd))
                {
                    //検査方法ドロップダウンリスト
                    res.selectorlist8 = DaHanyoService.GetSelectorList(db, dto3.kensahoho_maincd, CInt(dto3.kensahoho_subcd), Enum名称区分.名称, false);
                }
                //表示区分(検査方法)
                res.showkbn2 = true;

                //項目一覧ドロップダウンリスト
                res.selectorlist12 = dtl.OrderBy(e => e.itemcd).Select(e => new DaSelectorModel(e.itemcd, e.itemnm)).ToList();
                if (req.editkbn == Enum編集区分.変更)
                {
                    res.selectorlist12 = res.selectorlist12.Where(e => e.value != req.itemcd!).ToList();
                }

                //項目特定区分ドロップダウンリスト
                res.selectorlist13 = DaNameService.GetSelectorList(db, EnumNmKbn.フリー項目特定区分, Enum名称区分.名称);

                //削除ボタン活性フラグ
                res.deleteFlg = true;
                //計算パラメータチェック
                var keisanFlg = db.tm_shfreeitem.SELECT.WHERE.ByFilter($@"{nameof(tm_shfreeitemDto.jigyocd)} = @{nameof(tm_shfreeitemDto.jigyocd)} and 
                                @{nameof(tm_shfreeitemDto.keisanparam)} = any(string_to_array({nameof(tm_shfreeitemDto.keisanparam)}, ','))",
                                req.jigyocd, req.itemcd!).Exists();
                //基準値チェック
                var kijunFlg = db.tm_kkkijun.SELECT.WHERE.ByKey(名称マスタ.システム.基準値業務区分._01, req.jigyocd, req.itemcd!).Exists();
                //結果チェック
                var kekkaFlg = db.tt_shfree.SELECT.WHERE.ByFilter($@"{nameof(tt_shfreeDto.jigyocd)} = @{nameof(tt_shfreeDto.jigyocd)} and 
                                                                     {nameof(tt_shfreeDto.itemcd)} = @{nameof(tt_shfreeDto.itemcd)}",
                                                                     req.jigyocd, req.itemcd!).Exists();
                if (keisanFlg || kijunFlg || kekkaFlg) res.deleteFlg = false;

                //更新日時(排他用)
                if (dto2 != null)
                {
                    res.upddttm = dto2.upddttm;
                }

                //正常返し
                return res;
            });
        }
        [DisplayName("保存処理(検診項目詳細画面)")]
        public DaResponseBase SaveKensinItemDetail(SaveKensinItemDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理(上限チェック：新規の場合のみ)
                //-------------------------------------------------------------
                //成人保健検診結果（フリー）項目コントロールマスタ
                var dtl1 = db.tm_shfreeitem.SELECT.WHERE.ByKey(req.jigyocd).GetDtoList();
                //拡張項目リスト取得
                var ctList = dtl1.Where(e => e.itemkbn != Enumフリー項目区分区分.PKG標準項目拡張領域不使用).ToList();

                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //拡張事業上限件数
                    var maxList = DaControlService.GetList(db, EnumCtrlKbn.拡張事業関連上限件数);

                    //半角タイプ入力項目の上限件数
                    var halfMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._02)!.IntValue1;
                    //日付タイプ入力項目の上限件数
                    var dayMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._03)!.IntValue1;
                    //全角タイプ入力項目の上限件数
                    var fullMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._04)!.IntValue1;
                    //コードタイプ入力項目の上限件数
                    var cdMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._05)!.IntValue1;

                    //半角タイプ入力項目の件数
                    var halfCt = ctList.Where(e => Wraper.GetInputtypekbn(db, e.inputtype) == Enum入力タイプ分類.半角).Count();
                    //日付タイプ入力項目の件数
                    var dayCt = ctList.Where(e => Wraper.GetInputtypekbn(db, e.inputtype) == Enum入力タイプ分類.日付).Count();
                    //全角タイプ入力項目の件数
                    var fullCt = ctList.Where(e => Wraper.GetInputtypekbn(db, e.inputtype) == Enum入力タイプ分類.全角).Count();
                    //コードタイプ入力項目の件数
                    var cdCt = ctList.Where(e => Wraper.GetInputtypekbn(db, e.inputtype) == Enum入力タイプ分類.コード).Count();
                    //上限フラグ
                    var maxFlg = false;
                    //入力タイプ
                    var inputtype = (Enum入力タイプ)CInt(DaSelectorService.GetCd(req.detailinfo.inputtype));
                    switch (Wraper.GetInputtypekbn(db, inputtype))
                    {
                        case Enum入力タイプ分類.半角:
                            maxFlg = halfCt >= halfMax;
                            break;
                        case Enum入力タイプ分類.日付:
                            maxFlg = dayCt >= dayMax;
                            break;
                        case Enum入力タイプ分類.全角:
                            maxFlg = fullCt >= fullMax;
                            break;
                        case Enum入力タイプ分類.コード:
                            maxFlg = cdCt >= cdMax;
                            break;
                        default:
                            throw new Exception("Enum入力タイプ分類 error");
                    }

                    //拡張事業件数上限の場合
                    if (maxFlg)
                    {
                        //エラーメッセージ設定
                        res.SetServiceError(EnumMessage.E014006);
                        //異常返し
                        return res;
                    }
                }

                //-------------------------------------------------------------
                //２.チェック処理(既存データチェック(利用検査方法コード、表示年度、必須、入力範囲、桁数)：変更の場合のみ)
                //-------------------------------------------------------------
                //成人保健検診結果（フリー）項目コントロールマスタ
                tm_shfreeitemDto dto1 = new tm_shfreeitemDto();
                if (req.editkbn == Enum編集区分.変更)
                {
                    //データ取得
                    dto1 = db.tm_shfreeitem.GetDtoByKey(req.jigyocd, req.detailinfo.itemcd!);
                    //①利用検査方法コード（利用検査方法コードの指定がなくなった場合、エラーチェック不要）
                    if (req.detailinfo.riyokensahohocds.Count > 0)
                    {
                        //元利用検査方法コードリスト取得
                        var oldCdList = CommaStrToList(dto1.riyokensahohocd);
                        //検査方法コードリスト(チェック用)
                        var checkCdList = oldCdList.Where(e => !req.detailinfo.riyokensahohocds.Contains(e)).ToList();
                        //削除検査方法コードが存在する場合
                        if (checkCdList.Count > 0)
                        {
                            //パラメータ取得
                            var param = Converter.GetParameters(req.jigyocd, req.detailinfo.itemcd!, ListToCommaStr(checkCdList)!);
                            //削除検査方法コードの使用チェック
                            var useFlg = CBool(DaDbUtil.GetProcedureValue(db, PROC_NAME1, param));
                            //使用された場合
                            if (useFlg)
                            {
                                //エラーメッセージ設定
                                res.SetServiceError(EnumMessage.E014005);
                                //異常返し
                                return res;
                            }
                        }
                    }

                    //②表示年度
                    //フィルターSQL
                    var filterStr = $@"{nameof(tt_shfreeDto.jigyocd)} = @{nameof(tt_shfreeDto.jigyocd)} and 
                                        {nameof(tt_shfreeDto.itemcd)} = @{nameof(tt_shfreeDto.itemcd)}";
                    if (req.detailinfo.hyojinendof != null || req.detailinfo.hyojinendot != null)
                    {
                        //表示年度チェックフィルターSQL
                        var filterStr1 = filterStr;
                        //表示年度（開始）、表示年度（終了）が設定する場合
                        if (req.detailinfo.hyojinendof != null && req.detailinfo.hyojinendot != null)
                        {
                            filterStr1 = $@"{filterStr1} and 
                                            {DaStrPool.C_LEFT_BRACKET_HALF}{nameof(tt_shfreeDto.nendo)} < {req.detailinfo.hyojinendof}
                                            or {nameof(tt_shfreeDto.nendo)} > {req.detailinfo.hyojinendot}{DaStrPool.C_RIGHT_BRACKET_HALF}";
                        }
                        else if (req.detailinfo.hyojinendof != null)
                        {
                            filterStr1 = $"{filterStr1} and {nameof(tt_shfreeDto.nendo)} < {req.detailinfo.hyojinendof}";
                        }
                        else if (req.detailinfo.hyojinendot != null)
                        {
                            filterStr1 = $"{filterStr1} and {nameof(tt_shfreeDto.nendo)} > {req.detailinfo.hyojinendot}";
                        }

                        //表示年度外存在フラグ
                        var yearFlg = db.tt_shfree.SELECT.WHERE.ByFilter(filterStr1, req.jigyocd, req.detailinfo.itemcd!).Exists();
                        //設定表示年度以外既にデータが格納した場合
                        if (yearFlg)
                        {
                            //エラーメッセージ設定
                            res.SetServiceError(EnumMessage.E014005);
                            //異常返し
                            return res;
                        }
                    }
                    //③必須項目チェック
                    //メッセージ区分
                    var msgkbn = (EnumMsgCtrlKbn)CInt(DaSelectorService.GetCd(req.detailinfo.msgkbn!));
                    if (req.detailinfo.hissuflg && msgkbn == EnumMsgCtrlKbn.エラー)
                    {
                        //パラメータ取得
                        var param = Converter.GetParameters(req.jigyocd, req.detailinfo.itemcd!);
                        //Null項目チェック
                        var nullFlg = CBool(DaDbUtil.GetProcedureValue(db, PROC_NAME3, param));
                        //未入力が存在する場合
                        if (nullFlg)
                        {
                            //エラーメッセージ設定
                            res.SetServiceError(EnumMessage.E014005);
                            //異常返し
                            return res;
                        }
                    }
                    //④入力範囲チェック
                    if (!string.IsNullOrEmpty(req.detailinfo.hanif) || !string.IsNullOrEmpty(req.detailinfo.hanit))
                    {
                        //入力範囲チェックフィルターSQL
                        var filterStr2 = Converter.GetFilterSql(db, filterStr, req.detailinfo, nameof(tt_shfreeDto.strvalue), nameof(tt_shfreeDto.numvalue));
                        //入力範囲外存在フラグ
                        var haniFlg = db.tt_shfree.SELECT.WHERE.ByFilter(filterStr2, req.jigyocd, req.detailinfo.itemcd!).Exists();
                        //設定入力範囲以外既にデータが格納した場合
                        if (haniFlg)
                        {
                            //エラーメッセージ設定
                            res.SetServiceError(EnumMessage.E014005);
                            //異常返し
                            return res;
                        }
                    }
                    //⑤桁数チェック
                    if (!string.IsNullOrEmpty(req.detailinfo.keta))
                    {
                        //入力桁取得
                        var ketas = CmLogicUtil.GetKetas(req.detailinfo.keta);
                        //パラメータ取得
                        var param = Converter.GetParameters(db, req.jigyocd, req.detailinfo.itemcd!, req.detailinfo.inputtype!,
                                                            CInt(ketas.keta1), ketas.keta2);
                        //桁数超えフラグ
                        var ketaFlg = CBool(DaDbUtil.GetProcedureValue(db, PROC_NAME5, param));
                        //桁数超える場合
                        if (ketaFlg)
                        {
                            //エラーメッセージ設定
                            res.SetServiceError(EnumMessage.E014005);
                            //異常返し
                            return res;
                        }
                    }
                }

                //-------------------------------------------------------------
                //３.データ加工処理(項目コード)
                //-------------------------------------------------------------
                //項目コード
                var itemcd = string.Empty;
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    var dtlist = dtl1.Where(e => e.itemkbn == Enumフリー項目区分区分.市区町村独自項目).ToList();
                    var itemcdMax = dtlist.Select(e => e.itemcd).Max();
                    if (!string.IsNullOrEmpty(itemcdMax))
                    {
                        itemcdMax = itemcdMax.Substring(4, 5);
                    }
                    itemcd = $"3002{(CInt(itemcdMax) + 1).ToString().PadLeft(5, '0')}001";
                }
                else
                {
                    itemcd = req.detailinfo.itemcd!;
                }
                //成人保健検診結果（フリー）項目コントロールマスタ
                dto1 = Converter.GetDto(dto1, req.detailinfo, req.editkbn, req.jigyocd, itemcd, dtl1.Count() + 1);

                //-------------------------------------------------------------
                //４.DB更新処理(項目コード)
                //-------------------------------------------------------------
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //成人保健検診結果（フリー）項目コントロールマスタ：ベースで主キー重複チェック
                    db.tm_shfreeitem.INSERT.Execute(dto1);
                }
                //変更の場合
                else
                {
                    //成人保健検診結果（フリー）項目コントロールマスタ：排他チェック
                    db.tm_shfreeitem.UpdateDto(dto1, req.upddttm!.Value);
                }

                //-------------------------------------------------------------
                //５.データ取得(ディフォルト設定処理：詳細条件)
                //-------------------------------------------------------------
                //機能マスタ
                var dto2 = db.tm_afkino.SELECT.WHERE.ByFilter($@"{nameof(tm_afkinoDto.hanyokbn)} = @{nameof(tm_afkinoDto.hanyokbn)} and 
                                                            {nameof(tm_afkinoDto.kinoid)} like '{AWSH001}%'", req.jigyocd).GetDto();
                //詳細条件設定テーブル
                var dto3 = new tt_affilterDto();
                if (req.editkbn == Enum編集区分.変更)
                {
                    dto3 = db.tt_affilter.SELECT.WHERE.ByFilter($@"{nameof(tt_affilterDto.kinoid)} = @{nameof(tt_affilterDto.kinoid)} and 
                                                            {nameof(tt_affilterDto.jyokbn)} = @{nameof(tt_affilterDto.jyokbn)} and 
                                                            {nameof(tt_affilterDto.keycd1)} = @{nameof(tt_affilterDto.keycd1)} and 
                                                            {nameof(tt_affilterDto.itemcd1)} = @{nameof(tt_affilterDto.itemcd1)} ",
                                                            dto2.kinoid, EnumToStr(Enum詳細検索条件区分.独自), req.jigyocd, itemcd).GetDto();
                }
                var max = db.tt_affilter.SELECT.WHERE.ByKey(dto2.kinoid, EnumToStr(Enum詳細検索条件区分.独自)).GetMax<int>(nameof(tt_affilterDto.jyoseq));
                if (max < 4) max = 3;

                //-------------------------------------------------------------
                //６.データ加工処理(ディフォルト設定処理：詳細条件)
                //-------------------------------------------------------------
                //詳細条件設定テーブル
                dto3 = Converter.GetDto(db, dto3, req.detailinfo, req.editkbn, dto2.kinoid, req.jigyocd, itemcd, max + 1,
                                        tt_shfreeDto.TABLE_NAME, nameof(tt_shfreeDto.strvalue), nameof(tt_shfreeDto.numvalue), nameof(tt_shfreeDto.fusyoflg));
                //表示名
                dto3.hyojinm = $"{BRACKET_START}{dto1.groupid}{BRACKET_END}{dto3.hyojinm}";

                //-------------------------------------------------------------
                //７.DB更新処理(ディフォルト設定処理：詳細条件)
                //-------------------------------------------------------------
                db.tt_affilter.UPDATE.WHERE.ByKey(dto2.kinoid, EnumToStr(Enum詳細検索条件区分.独自), dto3.jyoseq).Execute(new List<tt_affilterDto>() { dto3 });

                //キャシュークリア
                DaFreeItemService.ClearCache();

                //正常返し
                return res;
            });
        }
        [DisplayName("削除処理(検診項目詳細画面)")]
        public DaResponseBase DeleteKensinItemDetail(DeteleKensinItemDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //計算パラメータチェック
                var keisanFlg = db.tm_shfreeitem.SELECT.WHERE.ByFilter($@"{nameof(tm_shfreeitemDto.jigyocd)} = @{nameof(tm_shfreeitemDto.jigyocd)} and 
                                @{nameof(tm_shfreeitemDto.keisanparam)} = any(string_to_array({nameof(tm_shfreeitemDto.keisanparam)}, ','))",
                                req.jigyocd, req.itemcd).Exists();
                //基準値チェック
                var kijunFlg = db.tm_kkkijun.SELECT.WHERE.ByKey(名称マスタ.システム.基準値業務区分._01, req.jigyocd, req.itemcd).Exists();
                //結果チェック
                var kekkaFlg = db.tt_shfree.SELECT.WHERE.ByFilter($@"{nameof(tt_shfreeDto.jigyocd)} = @{nameof(tt_shfreeDto.jigyocd)} and 
                                                                     {nameof(tt_shfreeDto.itemcd)} = @{nameof(tt_shfreeDto.itemcd)}",
                                                                     req.jigyocd, req.itemcd).Exists();
                if (keisanFlg || kijunFlg || kekkaFlg)
                {
                    //エラーメッセージ設定
                    res.SetServiceError(EnumMessage.E014001, "成人健（検）診項目");
                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                //機能マスタ
                var kinoid = db.tm_afkino.SELECT.WHERE.ByFilter($@"{nameof(tm_afkinoDto.hanyokbn)} = @{nameof(tm_afkinoDto.hanyokbn)} and 
                                                                   {nameof(tm_afkinoDto.kinoid)} like '{AWSH001}%'", req.jigyocd).GetDto().kinoid;

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //成人保健検診結果（フリー）項目コントロールマスタ
                db.tm_shfreeitem.DeleteByKey(req.jigyocd, req.itemcd, req.upddttm);
                //詳細条件設定テーブル
                db.tt_affilter.DELETE.WHERE.ByFilter($@"{nameof(tt_affilterDto.kinoid)} = @{nameof(tt_affilterDto.kinoid)} and 
                                                            {nameof(tt_affilterDto.jyokbn)} = @{nameof(tt_affilterDto.jyokbn)} and 
                                                            {nameof(tt_affilterDto.keycd1)} = @{nameof(tt_affilterDto.keycd1)} and 
                                                            {nameof(tt_affilterDto.itemcd1)} = @{nameof(tt_affilterDto.itemcd1)} ",
                                                            kinoid, EnumToStr(Enum詳細検索条件区分.独自), req.jigyocd, req.itemcd).Execute();

                //キャシュークリア
                DaFreeItemService.ClearCache();

                //正常返し
                return new DaResponseBase();
            });
        }
        // **************************************************************************************************************************************
        // 項目詳細画面(共通)
        // **************************************************************************************************************************************
        [DisplayName("条件コードリスト取得(項目詳細画面)")]
        public GetCodejokenListResponse GetCodejokenList(GetCodejokenListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new GetCodejokenListResponse();

                //正常返し
                return GetCodejokenListResponse(db, res, req.inputtype, req.codejoken1, req.codejoken2, req.codejoken3, req.jigyocd, req.group);
            });
        }

        // **************************************************************************************************************************************
        // 指導項目一覧画面
        // **************************************************************************************************************************************
        [DisplayName("初期化処理(指導項目一覧画面)")]
        public InitSidoItemListResponse InitSidoItemList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitSidoItemListResponse();
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------

                //指導区分ドロップダウンリスト
                res.selectorlist1 = DaNameService.GetSelectorList(db, EnumNmKbn.指導区分, Enum名称区分.名称);
                //業務区分ドロップダウンリスト
                res.selectorlist2 = DaNameService.GetSelectorList(db, EnumNmKbn.拡張_予約_保健指導業務区分,
                                                    Enum名称区分.名称).Where(e => CInt(e.value) != CInt(EnumToStr(Enum拡張予約指導業務区分.予防接種))).ToList();
                //申込結果ドロップダウンリスト
                res.selectorlist3 = DaNameService.GetSelectorList(db, EnumNmKbn.申込結果区分, Enum名称区分.名称);
                //項目用途区分ドロップダウンリスト
                res.selectorlist4 = DaNameService.GetSelectorList(db, EnumNmKbn.フリー項目用途区分, Enum名称区分.名称);

                //正常返し
                return res;
            });
        }
        [DisplayName("検索処理(指導項目一覧画面)")]
        public SearchSidoItemListResponse SearchSidoItemList(SidoCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchSidoItemListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //指導（フリー項目）コントロールマスタ
                var dtl = db.tm_kksidofreeitem.SELECT.WHERE.ByKey(EnumToStr(req.sidokbn),
                                req.gyomukbn, EnumToStr(req.mosikomikekkakbn)).GetDtoList().OrderBy(e => e.orderseq).ToList();

                //拡張事業上限件数
                var maxList = DaControlService.GetList(db, EnumCtrlKbn.拡張事業関連上限件数);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //フリー項目一覧
                var vmList = Wraper.GetVMList(db, dtl);
                if (req.sidokbn == Enum指導区分.集団指導)
                {
                    res.kekkalist = vmList.Where(e => e.itemyotokbn == req.itemyotokbn).Cast<ItemListRowBaseVM>().ToList();
                }
                else
                {
                    res.kekkalist = vmList.Cast<ItemListRowBaseVM>().ToList();
                }

                //半角タイプ入力項目の上限件数
                var halfMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._02)!.IntValue1;
                //日付タイプ入力項目の上限件数
                var dayMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._03)!.IntValue1;
                //全角タイプ入力項目の上限件数
                var fullMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._04)!.IntValue1;
                //コードタイプ入力項目の上限件数
                var cdMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._05)!.IntValue1;
                //半角タイプ入力項目の件数
                var halfCt = res.kekkalist.Where(e => e.kakutyokbn == "○" && e.inputtypekbn == Enum入力タイプ分類.半角).Count();
                //日付タイプ入力項目の件数
                var dayCt = res.kekkalist.Where(e => e.kakutyokbn == "○" && e.inputtypekbn == Enum入力タイプ分類.日付).Count();
                //全角タイプ入力項目の件数
                var fullCt = res.kekkalist.Where(e => e.kakutyokbn == "○" && e.inputtypekbn == Enum入力タイプ分類.全角).Count();
                //コードタイプ入力項目の件数
                var cdCt = res.kekkalist.Where(e => e.kakutyokbn == "○" && e.inputtypekbn == Enum入力タイプ分類.コード).Count();

                //半角タイプ入力上限値フラグ
                res.halfflg = halfCt >= halfMax;
                //日付タイプ入力上限値フラグ
                res.dayflg = dayCt >= dayMax;
                //全角タイプ入力上限値フラグ
                res.fullflg = fullCt >= fullMax;
                //コードタイプ入力上限値フラグ
                res.cdflg = cdCt >= cdMax;

                //ボタン制御フラグ(新規・コピー)
                res.buttonflg = (halfCt < halfMax || dayCt < dayMax || fullCt < fullMax || cdCt < cdMax);

                //拡張事業入力件数カウント
                res.kensucnt = $"市区町村拡張項目（半角{halfCt}/{halfMax}、日付{dayCt}/{dayMax}、全角{fullCt}/{fullMax}、コード{cdCt}/{cdMax}）";

                //正常返し
                return res;
            });
        }
        // **************************************************************************************************************************************
        // 指導項目詳細画面
        // **************************************************************************************************************************************
        [DisplayName("初期化処理(指導項目詳細画面)")]
        public InitSidoItemDetailResponse InitSidoItemDetail(InitSidoItemDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitSidoItemDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //指導（フリー項目）コントロールマスタ
                tm_kksidofreeitemDto? dto = null;
                if (req.editkbn == Enum編集区分.変更 || (req.editkbn == Enum編集区分.新規 && req.copyflg))
                {
                    dto = db.tm_kksidofreeitem.GetDtoByKey(EnumToStr(req.sidokbn), req.gyomukbn, EnumToStr(req.mosikomikekkakbn), EnumToStr(req.itemyotokbn), req.itemcd!);
                }
                //利用地域保健集計区分一覧
                var dtl = DaNameService.GetNameList(db, EnumNmKbn.地域保健集計区分).
                            Where(e => CInt(e.hanyokbn1) == (int)req.sidokbn && e.hanyokbn2 == req.gyomukbn).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //条件コード一覧取得
                if (dto?.inputtype != null)
                {
                    res = (InitSidoItemDetailResponse)GetCodejokenListResponse(db, res, dto.inputtype, dto.codejoken1, dto.codejoken2, dto.codejoken3);
                }

                //指導項目詳細画面ヘッダー情報
                res.headerinfo = Wraper.GetHeaderVM(db, req);
                //指導項目詳細
                res.detailinfo = Wraper.GetVM(db, dto, req.copyflg);
                //グループIDドロップダウンリスト
                res.selectorlist1 = GetGroupList(db, req, Enumフリー項目グループNo.グループ);
                //グループID2ドロップダウンリスト
                res.selectorlist2 = GetGroupList(db, req, Enumフリー項目グループNo.グループ2);
                //メッセージ区分ドロップダウンリスト
                res.selectorlist3 = DaNameService.GetSelectorList(db, EnumNmKbn.メッセージ切替区分, Enum名称区分.名称);
                //入力タイプドロップダウンリスト
                res.selectorlist4 = GetInputTypeList(db, req.halfflg, req.dayflg, req.cdflg, req.fullflg);
                //利用地域保健集計区分ドロップダウンリスト
                res.selectorlist8 = DaNameService.GetSelectorList(dtl, Enum名称区分.名称);
                //項目特定区分ドロップダウンリスト
                res.selectorlist9 = DaNameService.GetSelectorList(db, EnumNmKbn.フリー項目特定区分, Enum名称区分.名称);

                //更新日時(排他用)
                if (dto != null)
                {
                    res.upddttm = dto.upddttm;
                }

                //正常返し
                return res;
            });
        }
        [DisplayName("保存処理(指導項目詳細画面)")]
        public DaResponseBase SaveSidoItemDetail(SaveSidoItemDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();

                //-------------------------------------------------------------
                //１.チェック処理(上限チェック：新規の場合のみ)
                //-------------------------------------------------------------

                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //指導（フリー項目）コントロールマスタ
                    var dtl1 = db.tm_kksidofreeitem.SELECT.WHERE.ByKey(EnumToStr(req.sidokbn), req.gyomukbn, EnumToStr(req.mosikomikekkakbn)).GetDtoList();
                    //拡張事業上限件数
                    var maxList = DaControlService.GetList(db, EnumCtrlKbn.拡張事業関連上限件数);
                    //拡張項目リスト取得
                    var ctList = dtl1.Where(e => e.itemkbn != Enumフリー項目区分区分.PKG標準項目拡張領域不使用).ToList();

                    //半角タイプ入力項目の上限件数
                    var halfMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._02)!.IntValue1;
                    //日付タイプ入力項目の上限件数
                    var dayMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._03)!.IntValue1;
                    //全角タイプ入力項目の上限件数
                    var fullMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._04)!.IntValue1;
                    //コードタイプ入力項目の上限件数
                    var cdMax = maxList.Find(e => e.ctrlcd == コントロールマスタ.システム.拡張事業関連上限件数._05)!.IntValue1;

                    //半角タイプ入力項目の件数
                    var halfCt = ctList.Where(e => Wraper.GetInputtypekbn(db, e.inputtype) == Enum入力タイプ分類.半角).Count();
                    //日付タイプ入力項目の件数
                    var dayCt = ctList.Where(e => Wraper.GetInputtypekbn(db, e.inputtype) == Enum入力タイプ分類.日付).Count();
                    //全角タイプ入力項目の件数
                    var fullCt = ctList.Where(e => Wraper.GetInputtypekbn(db, e.inputtype) == Enum入力タイプ分類.全角).Count();
                    //コードタイプ入力項目の件数
                    var cdCt = ctList.Where(e => Wraper.GetInputtypekbn(db, e.inputtype) == Enum入力タイプ分類.コード).Count();
                    //上限フラグ
                    var maxFlg = false;
                    //入力タイプ
                    var inputtype = (Enum入力タイプ)CInt(DaSelectorService.GetCd(req.detailinfo.inputtype));
                    switch (Wraper.GetInputtypekbn(db, inputtype))
                    {
                        case Enum入力タイプ分類.半角:
                            maxFlg = halfCt >= halfMax;
                            break;
                        case Enum入力タイプ分類.日付:
                            maxFlg = dayCt >= dayMax;
                            break;
                        case Enum入力タイプ分類.全角:
                            maxFlg = fullCt >= fullMax;
                            break;
                        case Enum入力タイプ分類.コード:
                            maxFlg = cdCt >= cdMax;
                            break;
                        default:
                            throw new Exception("Enum入力タイプ分類 error");
                    }

                    //拡張事業件数上限の場合
                    if (maxFlg)
                    {
                        //エラーメッセージ設定
                        res.SetServiceError(EnumMessage.E014006);
                        //異常返し
                        return res;
                    }
                }

                //-------------------------------------------------------------
                //２.チェック処理(既存データチェック(必須、入力範囲、桁数)：変更の場合のみ)
                //-------------------------------------------------------------

                if (req.editkbn == Enum編集区分.変更)
                {
                    //①必須項目チェック
                    //メッセージ区分
                    var msgkbn = (EnumMsgCtrlKbn)CInt(DaSelectorService.GetCd(req.detailinfo.msgkbn!));
                    if (req.detailinfo.hissuflg && msgkbn == EnumMsgCtrlKbn.エラー)
                    {
                        //パラメータ取得
                        var param = Converter.GetParameters(req, req.detailinfo.itemcd!);
                        //Null項目チェック
                        var nullFlg = CBool(DaDbUtil.GetProcedureValue(db, PROC_NAME4, param));
                        //未入力が存在する場合
                        if (nullFlg)
                        {
                            //エラーメッセージ設定
                            res.SetServiceError(EnumMessage.E014005);
                            //異常返し
                            return res;
                        }
                    }
                    //②入力範囲チェック
                    if (!string.IsNullOrEmpty(req.detailinfo.hanif) || !string.IsNullOrEmpty(req.detailinfo.hanit))
                    {
                        //入力範囲外存在フラグ
                        var haniFlg = false;
                        switch (req.sidokbn)
                        {
                            case Enum指導区分.訪問指導:
                            case Enum指導区分.個別指導:
                                //フィルターSQL
                                var filterStr1 = $@"{nameof(tt_kkhokensidofreeDto.hokensidokbn)} = @{nameof(tt_kkhokensidofreeDto.hokensidokbn)} and 
                                        {nameof(tt_kkhokensidofreeDto.gyomukbn)} = @{nameof(tt_kkhokensidofreeDto.gyomukbn)} and 
                                        {nameof(tt_kkhokensidofreeDto.mosikomikekkakbn)} = @{nameof(tt_kkhokensidofreeDto.mosikomikekkakbn)} and 
                                        {nameof(tt_kkhokensidofreeDto.itemcd)} = @{nameof(tt_kkhokensidofreeDto.itemcd)}";
                                //入力範囲チェックフィルターSQL
                                filterStr1 = Converter.GetFilterSql(db, filterStr1, req.detailinfo, nameof(tt_kkhokensidofreeDto.strvalue), nameof(tt_kkhokensidofreeDto.numvalue));
                                //入力範囲外存在フラグ
                                haniFlg = db.tt_kkhokensidofree.SELECT.WHERE.ByFilter(filterStr1, EnumToStr(req.sidokbn), req.gyomukbn,
                                                                EnumToStr(req.mosikomikekkakbn), req.detailinfo.itemcd!).Exists();
                                break;
                            case Enum指導区分.集団指導:
                                switch (req.itemyotokbn)
                                {
                                    case Enum項目用途区分.事業用:
                                        //フィルターSQL
                                        var filterStr2 = $@"{nameof(tt_kksyudansidofreeDto.gyomukbn)} = @{nameof(tt_kksyudansidofreeDto.gyomukbn)} and 
                                        {nameof(tt_kksyudansidofreeDto.mosikomikekkakbn)} = @{nameof(tt_kksyudansidofreeDto.mosikomikekkakbn)} and 
                                        {nameof(tt_kksyudansidofreeDto.itemcd)} = @{nameof(tt_kksyudansidofreeDto.itemcd)}";
                                        //入力範囲チェックフィルターSQL
                                        filterStr2 = Converter.GetFilterSql(db, filterStr2, req.detailinfo, nameof(tt_kksyudansidofreeDto.strvalue), nameof(tt_kksyudansidofreeDto.numvalue));
                                        //入力範囲外存在フラグ
                                        haniFlg = db.tt_kksyudansidofree.SELECT.WHERE.ByFilter(filterStr2, req.gyomukbn,
                                                                        EnumToStr(req.mosikomikekkakbn), req.detailinfo.itemcd!).Exists();
                                        break;
                                    case Enum項目用途区分.参加者用:
                                        //フィルターSQL
                                        var filterStr3 = $@"{nameof(tt_kksyudansido_sankasyafreeDto.gyomukbn)} = @{nameof(tt_kksyudansido_sankasyafreeDto.gyomukbn)} and 
                                        {nameof(tt_kksyudansido_sankasyafreeDto.mosikomikekkakbn)} = @{nameof(tt_kksyudansido_sankasyafreeDto.mosikomikekkakbn)} and 
                                        {nameof(tt_kksyudansido_sankasyafreeDto.itemcd)} = @{nameof(tt_kksyudansido_sankasyafreeDto.itemcd)}";
                                        //入力範囲チェックフィルターSQL
                                        filterStr3 = Converter.GetFilterSql(db, filterStr3, req.detailinfo, nameof(tt_kksyudansido_sankasyafreeDto.strvalue), nameof(tt_kksyudansido_sankasyafreeDto.numvalue));
                                        //入力範囲外存在フラグ
                                        haniFlg = db.tt_kksyudansido_sankasyafree.SELECT.WHERE.ByFilter(filterStr3, req.gyomukbn,
                                                                        EnumToStr(req.mosikomikekkakbn), req.detailinfo.itemcd!).Exists();
                                        break;
                                    default:
                                        throw new Exception("Enum項目用途区分 error");
                                }
                                break;
                            default:
                                throw new Exception("Enum指導区分 error");
                        }
                        //設定入力範囲以外既にデータが格納した場合
                        if (haniFlg)
                        {
                            //エラーメッセージ設定
                            res.SetServiceError(EnumMessage.E014005);
                            //異常返し
                            return res;
                        }
                    }
                    //③桁数チェック
                    if (!string.IsNullOrEmpty(req.detailinfo.keta))
                    {
                        //入力桁取得
                        var ketas = CmLogicUtil.GetKetas(req.detailinfo.keta);

                        //パラメータ取得
                        var param = Converter.GetParameters(db, req, req.detailinfo.itemcd!, req.detailinfo.inputtype,
                                                            CInt(ketas.keta1), ketas.keta2);
                        //桁数超えフラグ
                        var ketaFlg = CBool(DaDbUtil.GetProcedureValue(db, PROC_NAME6, param));
                        //桁数超える場合
                        if (ketaFlg)
                        {
                            //エラーメッセージ設定
                            res.SetServiceError(EnumMessage.E014005);
                            //異常返し
                            return res;
                        }
                    }
                }

                //-------------------------------------------------------------
                //３.データ加工処理(項目コード)
                //-------------------------------------------------------------
                var itemcd = string.Empty;
                var ct = 0;
                if (req.editkbn == Enum編集区分.新規)
                {
                    //項目コード
                    var itemcdMax = db.tm_kksidofreeitem.SELECT.WHERE.ByKey(EnumToStr(req.sidokbn), req.gyomukbn,
                                                                EnumToStr(req.mosikomikekkakbn), EnumToStr(req.itemyotokbn)).GetDtoList().
                                                                Where(e => e.itemcd.StartsWith("3")).Select(e => e.itemcd).Max();
                    if (!string.IsNullOrEmpty(itemcdMax))
                    {
                        ct = CInt(itemcdMax.Substring(4, 5));
                    }

                    //先頭3001固定＋連番＋001※指導区分・業務区分・申込結果・項目用途区分ごとに連番設定
                    itemcd = $"3001{(ct + 1).ToString().PadLeft(5, '0')}001";
                }
                else
                {
                    itemcd = req.itemcd;
                }

                //指導（フリー項目）コントロールマスタ
                var dto1 = new tm_kksidofreeitemDto();
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //指導（フリー項目）コントロールマスタ
                    dto1 = Converter.GetDto(dto1, req.detailinfo, req.editkbn, req, itemcd, ct + 1);
                }
                //変更の場合
                else
                {
                    //指導（フリー項目）コントロールマスタ：排他チェック
                    dto1 = db.tm_kksidofreeitem.SELECT.WHERE.ByKey(EnumToStr(req.sidokbn), req.gyomukbn,
                                                                   EnumToStr(req.mosikomikekkakbn),
                                                                   EnumToStr(req.itemyotokbn), req.itemcd).GetDto();

                    //指導（フリー項目）コントロールマスタ
                    dto1 = Converter.GetDto(dto1, req.detailinfo, req.editkbn, req, itemcd, ct + 1);
                }

                //-------------------------------------------------------------
                //４.DB更新処理(項目コード)
                //-------------------------------------------------------------
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //指導（フリー項目）コントロールマスタ：ベースで主キー重複チェック
                    db.tm_kksidofreeitem.INSERT.Execute(dto1);
                }
                //変更の場合
                else
                {
                    //指導（フリー項目）コントロールマスタ：排他チェック
                    db.tm_kksidofreeitem.UpdateDto(dto1, req.upddttm!.Value);
                }

                //-------------------------------------------------------------
                //５.データ取得(ディフォルト設定処理：詳細条件)
                //-------------------------------------------------------------
                //詳細条件設定テーブル
                var dto2 = new tt_affilterDto();
                var keycd = $"{EnumToStr(req.sidokbn)}{C_UNDERLINE}{req.gyomukbn}{C_UNDERLINE}{EnumToStr(req.mosikomikekkakbn)}{C_UNDERLINE}{EnumToStr(req.itemyotokbn)}";
                if (req.editkbn == Enum編集区分.変更 && req.sidokbn != Enum指導区分.集団指導)
                {
                    dto2 = db.tt_affilter.SELECT.WHERE.ByFilter($@"{nameof(tt_affilterDto.kinoid)} = @{nameof(tt_affilterDto.kinoid)} and 
                                                                    {nameof(tt_affilterDto.jyokbn)} = @{nameof(tt_affilterDto.jyokbn)} and 
                                                                    {nameof(tt_affilterDto.keycd1)} = @{nameof(tt_affilterDto.keycd1)} and 
                                                                    {nameof(tt_affilterDto.itemcd1)} = @{nameof(tt_affilterDto.itemcd1)} ",
                                                                    AWKK00301G, EnumToStr(Enum詳細検索条件区分.独自), keycd, itemcd).GetDto();
                }
                var max = db.tt_affilter.SELECT.WHERE.ByKey(AWKK00301G, EnumToStr(Enum詳細検索条件区分.独自)).GetMax<int>(nameof(tt_affilterDto.jyoseq));

                //-------------------------------------------------------------
                //６.データ加工処理(ディフォルト設定処理：詳細条件)
                //-------------------------------------------------------------
                var tablenm = string.Empty;     //テーブル名
                var strvaluenm = string.Empty;  //文字項目
                var numvaluenm = string.Empty;  //数値項目
                var fusyoflgnm = string.Empty;  //不詳フラグ
                switch (req.sidokbn)
                {
                    case Enum指導区分.訪問指導:
                    case Enum指導区分.個別指導:
                        tablenm = tt_kkhokensidofreeDto.TABLE_NAME;                             //テーブル名
                        strvaluenm = nameof(tt_kkhokensidofreeDto.strvalue);                    //文字項目
                        numvaluenm = nameof(tt_kkhokensidofreeDto.numvalue);                    //数値項目
                        fusyoflgnm = nameof(tt_kkhokensidofreeDto.fusyoflg);                    //不詳フラグ
                        break;
                    case Enum指導区分.集団指導:
                        switch (req.itemyotokbn)
                        {
                            case Enum項目用途区分.事業用:
                                tablenm = tt_kksyudansidofreeDto.TABLE_NAME;                    //テーブル名
                                strvaluenm = nameof(tt_kksyudansidofreeDto.strvalue);           //文字項目
                                numvaluenm = nameof(tt_kksyudansidofreeDto.numvalue);           //数値項目
                                fusyoflgnm = nameof(tt_kksyudansidofreeDto.fusyoflg);           //不詳フラグ
                                break;
                            case Enum項目用途区分.参加者用:
                                tablenm = tt_kksyudansido_sankasyafreeDto.TABLE_NAME;           //テーブル名
                                strvaluenm = nameof(tt_kksyudansido_sankasyafreeDto.strvalue);  //文字項目
                                numvaluenm = nameof(tt_kksyudansido_sankasyafreeDto.numvalue);  //数値項目
                                fusyoflgnm = nameof(tt_kksyudansido_sankasyafreeDto.fusyoflg);  //不詳フラグ
                                break;
                            default:
                                throw new Exception("Enum項目用途区分 error");
                        }
                        break;
                    default:
                        throw new Exception("Enum指導区分 error");
                }
                //詳細条件設定テーブル
                dto2 = Converter.GetDto(db, dto2, req.detailinfo, req.editkbn, AWKK00301G, keycd, itemcd, max + 1, tablenm, strvaluenm, numvaluenm, fusyoflgnm);
                //表示名
                dto2.hyojinm = $"{BRACKET_START}{dto1.sidokbn}{CmLogicUtil.GetKakuYoyakuSidoGyomukbn(dto1.gyomukbn).ToString().Substring(0, 2)}{dto1.mosikomikekkakbn}{BRACKET_END}{dto2.hyojinm}";

                //-------------------------------------------------------------
                //７.DB更新処理(ディフォルト設定処理：詳細条件)
                //-------------------------------------------------------------
                if (req.sidokbn != Enum指導区分.集団指導)
                {
                    db.tt_affilter.UPDATE.WHERE.ByKey(AWKK00301G, EnumToStr(Enum詳細検索条件区分.独自), dto2.jyoseq).Execute(new List<tt_affilterDto>() { dto2 });
                }

                //キャシュークリア
                DaFreeItemService.ClearCache();

                //正常返し
                return res;
            });
        }
        [DisplayName("削除処理(指導項目詳細画面)")]
        public DaResponseBase DeleteSidoItemDetail(DeteleSidoItemDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //結果チェック
                var kekkaFlg = false;
                switch (req.sidokbn)
                {
                    case Enum指導区分.訪問指導:
                    case Enum指導区分.個別指導:
                        //保健指導事業（フリー項目）入力情報テーブル
                        kekkaFlg = db.tt_kkhokensidofree.SELECT.WHERE.ByKey(EnumToStr(req.sidokbn), req.gyomukbn,
                                                                EnumToStr(req.mosikomikekkakbn), req.itemcd).Exists();
                        break;
                    case Enum指導区分.集団指導:
                        switch (req.itemyotokbn)
                        {
                            case Enum項目用途区分.事業用:
                                //集団指導事業（フリー項目）入力情報テーブル
                                kekkaFlg = db.tt_kksyudansidofree.SELECT.WHERE.ByFilter(
                                    $@"{nameof(tt_kksyudansidofreeDto.gyomukbn)} = @{nameof(tt_kksyudansidofreeDto.gyomukbn)} and 
                                        {nameof(tt_kksyudansidofreeDto.mosikomikekkakbn)} = @{nameof(tt_kksyudansidofreeDto.mosikomikekkakbn)} and 
                                        {nameof(tt_kksyudansidofreeDto.itemcd)} = @{nameof(tt_kksyudansidofreeDto.itemcd)} ",
                                        req.gyomukbn, EnumToStr(req.mosikomikekkakbn), req.itemcd).Exists();
                                break;
                            case Enum項目用途区分.参加者用:
                                //集団指導参加者（フリー項目）入力情報テーブル
                                kekkaFlg = db.tt_kksyudansido_sankasyafree.SELECT.WHERE.ByFilter(
                                    $@"{nameof(tt_kksyudansido_sankasyafreeDto.gyomukbn)} = @{nameof(tt_kksyudansido_sankasyafreeDto.gyomukbn)} and 
                                        {nameof(tt_kksyudansido_sankasyafreeDto.mosikomikekkakbn)} = @{nameof(tt_kksyudansido_sankasyafreeDto.mosikomikekkakbn)} and 
                                        {nameof(tt_kksyudansido_sankasyafreeDto.itemcd)} = @{nameof(tt_kksyudansido_sankasyafreeDto.itemcd)} ",
                                        req.gyomukbn, EnumToStr(req.mosikomikekkakbn), req.itemcd).Exists();
                                break;
                            default:
                                throw new Exception("Enum項目用途区分 error");
                        }
                        break;
                    default:
                        throw new Exception("Enum指導区分 error");
                }

                if (kekkaFlg)
                {
                    //エラーメッセージ設定
                    res.SetServiceError(EnumMessage.E014001, "保健指導・集団指導項目");
                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------
                //指導（フリー項目）コントロールマスタ
                db.tm_kksidofreeitem.DeleteByKey(EnumToStr(req.sidokbn), req.gyomukbn,
                                                EnumToStr(req.mosikomikekkakbn), EnumToStr(req.itemyotokbn), req.itemcd, req.upddttm);

                var keycd = $"{EnumToStr(req.sidokbn)}{C_UNDERLINE}{req.gyomukbn}{C_UNDERLINE}{EnumToStr(req.mosikomikekkakbn)}{C_UNDERLINE}{EnumToStr(req.itemyotokbn)}";
                //詳細条件設定テーブル
                db.tt_affilter.DELETE.WHERE.ByFilter($@"{nameof(tt_affilterDto.kinoid)} = @{nameof(tt_affilterDto.kinoid)} and 
                                                                    {nameof(tt_affilterDto.jyokbn)} = @{nameof(tt_affilterDto.jyokbn)} and 
                                                                    {nameof(tt_affilterDto.keycd1)} = @{nameof(tt_affilterDto.keycd1)} and 
                                                                    {nameof(tt_affilterDto.itemcd1)} = @{nameof(tt_affilterDto.itemcd1)} ",
                                                                    AWKK00301G, EnumToStr(Enum詳細検索条件区分.独自), keycd, req.itemcd).Execute();

                //キャシュークリア
                DaFreeItemService.ClearCache();

                //正常返し
                return new DaResponseBase();
            });
        }
        [DisplayName("検索処理(検診予約事業一覧画面)")]
        public SearchKensinYoyakuJigyoListResponse SearchKensinYoyakuJigyoList(KensinYoyakuJigyoListCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchKensinYoyakuJigyoListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //成人健（検）診予約日程事業マスタ
                var dtl1 = db.tm_shyoyakujigyo.SELECT.WHERE.ByKey(req.nendo).GetDtoList().OrderBy(e => e.jigyocd).ToList();
                //成人健（検）診予約日程事業サブマスタ
                var dtl2 = db.tm_shyoyakujigyo_sub.SELECT.WHERE.ByKey(req.nendo).GetDtoList().
                            OrderBy(e => e.jigyocd).ThenBy(e => e.kensin_jigyocd).ThenBy(e => e.kensahohocd).ToList();
                //成人健（検）診事業マスタ
                var dtl3 = db.tm_shkensinjigyo.SELECT.WHERE.
                            ByFilter($"{nameof(tm_shkensinjigyoDto.kensahoho_setflg)} = @{nameof(tm_shkensinjigyoDto.kensahoho_setflg)}", true).
                            GetDtoList();

                //キーリスト
                var keyList = Converter.GetKeyList(dtl3);
                //汎用マスタ
                var dtl4 = db.tm_afhanyo.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //検査方法がある検診事業
                var cdList = dtl3.Select(e => e.jigyocd).ToList();
                //検診予約事業一覧
                res.kekkalist = Wraper.GetVMList(dtl1, dtl2, dtl4, MAINCD1, cdList);

                //正常返し
                return res;
            });
        }
        [DisplayName("引継ぎ処理(検診予約事業一覧画面)")]
        public DaResponseBase SaveKensinYoyakuJigyoList(KensinYoyakuJigyoListCommonRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                var dtl = db.tm_shyoyakujigyo.SELECT.WHERE.ByKey(req.nendo).GetDtoList();
                var dtl2 = db.tm_shyoyakujigyo_sub.SELECT.WHERE.ByKey(req.nendo).GetDtoList();
                if (dtl.Count > 0 || dtl2.Count > 0) throw new AiExclusiveException();
                //-------------------------------------------------------------
                //１.DB更新処理
                //-------------------------------------------------------------
                //パラメータ取得
                var param = new List<AiKeyValue>
                {
                    new($"{nameof(tm_shyoyakujigyoDto.nendo)}_in", req.nendo),          //年度
                    new($"{nameof(tm_shyoyakujigyoDto.reguserid)}_in", req.userid),     //登録ユーザーID
                    new($"{nameof(tm_shyoyakujigyoDto.upduserid)}_in", req.userid)      //更新ユーザーID
                };
                DaDbUtil.RunProcedure(db, PROC_NAME7, param);

                //正常返し
                return new DaResponseBase();
            });
        }
        // **************************************************************************************************************************************
        // 検診予約事業詳細画面
        // **************************************************************************************************************************************
        [DisplayName("初期化処理(検診予約事業詳細画面)")]
        public InitKensinYoyakuJigyoDetailResponse InitKensinYoyakuJigyoDetail(InitKensinYoyakuJigyoDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitKensinYoyakuJigyoDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //年度マスタ
                var dtl1 = db.tm_shnendo.SELECT.WHERE.ByKey(req.nendo).GetDtoList();

                //成人健（検）診事業マスタ
                var dtl2 = db.tm_shkensinjigyo.SELECT.WHERE.
                            ByFilter($"{nameof(tm_shkensinjigyoDto.kensahoho_setflg)} = @{nameof(tm_shkensinjigyoDto.kensahoho_setflg)}", true).
                            GetDtoList();

                //成人健（検）診予約日程事業マスタ
                var dto1 = new tm_shyoyakujigyoDto();
                //成人健（検）診予約日程事業サブマスタ
                var dtl3 = new List<tm_shyoyakujigyo_subDto>();
                if (req.editkbn == Enum編集区分.変更)
                {
                    //成人健（検）診予約日程事業マスタ
                    dto1 = db.tm_shyoyakujigyo.GetDtoByKey(req.nendo, req.jigyocd!);
                    //成人健（検）診予約日程事業サブマスタ
                    dtl3 = db.tm_shyoyakujigyo_sub.SELECT.WHERE.ByKey(req.nendo, req.jigyocd!).GetDtoList();
                }

                //キーリスト
                var keyList = Converter.GetKeyList(dtl2);
                //汎用マスタ
                var dtl4 = db.tm_afhanyo.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

                //健（検）診予約希望者詳細テーブル
                var dtl5 = db.tt_shkensinkibosyasyosai.SELECT.WHERE.
                           ByFilter(@$"{nameof(tt_shkensinkibosyasyosaiDto.nendo)} = @{nameof(tt_shkensinkibosyasyosaiDto.nendo)}",
                                       req.nendo).GetDtoList();
                //健（検）診予定テーブル
                var dtl6 = db.tt_shkensinyotei.SELECT.WHERE.
                                ByFilter(@$"{nameof(tt_shkensinyoteiDto.nendo)} = @{nameof(tt_shkensinyoteiDto.nendo)} and 
                                            {nameof(tt_shkensinyoteiDto.jigyocd)} = @{nameof(tt_shkensinyoteiDto.jigyocd)}",
                                            req.nendo, req.jigyocd!).GetDtoList();
                dtl5 = dtl5.Where(e => dtl6.Select(d => d.nitteino).ToList().Contains(e.nitteino)).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //検査方法がある検診事業
                var cdList = dtl2.Select(e => e.jigyocd).ToList();

                //メイン情報
                res.maininfo = Wraper.GetVM(req.editkbn, dto1, dtl4);
                //検査方法一覧
                res.kekkalist = Wraper.GetVMList(dtl1, dtl3, dtl4, MAINCD1, cdList, dtl5).OrderBy(e => e.jigyocd).ThenBy(e => e.kensahohocd).ToList();

                if (req.editkbn == Enum編集区分.新規)
                {
                    //検診予約事業ドロップダウンリスト(新規の場合のみ)
                    res.selectorlist2 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.成人健_検_診予約日程事業名, Enum名称区分.名称, false);
                }
                //料金パターンドロップダウンリスト
                res.selectorlist1 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.料金パターン, Enum名称区分.名称, false);

                //正常返し
                return res;
            });
        }
        [DisplayName("保存処理(検診予約事業詳細画面)")]
        public DaResponseBase SaveKensinYoyakuJigyoDetail(SaveKensinYoyakuJigyoDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //検診予約事業コード
                var jigyocd = string.Empty;
                if (req.editkbn == Enum編集区分.新規)
                {
                    jigyocd = DaSelectorService.GetCd(req.maininfo.jigyocdnm);
                }
                //更新の場合
                else
                {
                    jigyocd = req.jigyocd!;
                }
                //成人健（検）診予約日程事業マスタ
                var dto = db.tm_shyoyakujigyo.GetDtoByKey(req.nendo, jigyocd);
                if (dto == null) dto = new tm_shyoyakujigyoDto();

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                //料金パターン
                var ryokinpattern = DaSelectorService.GetCd(req.maininfo.ryokinpatterncdnm);
                //特殊の場合(変更前：予約データなし=>変更後：予約データあり)
                //変更の場合
                if (req.editkbn == Enum編集区分.変更 && req.chkflg)
                {
                    var existsFlg2 = false;
                    //料金パターン変更の場合
                    if (ryokinpattern != dto.ryokinpattern)
                    {
                        existsFlg2 = ChkHantei(db, jigyocd, req.nendo, req.kekkalist, true);
                    }
                    //実施チェック外す場合
                    else
                    {
                        existsFlg2 = ChkHantei(db, jigyocd, req.nendo, req.kekkalist, false);
                    }

                    if (existsFlg2)
                    {
                        //エラーメッセージ設定
                        res.SetServiceError(EnumMessage.E014010, "検診種別・検査方法");
                        //異常返し
                        return res;
                    }
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //成人健（検）診予約日程事業マスタ
                dto = Converter.GetDto(dto, ryokinpattern, req.nendo, jigyocd);
                //成人健（検）診予約日程事業サブマスタ
                var dtl = Converter.GetDtl(req.kekkalist, req.nendo, jigyocd);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //成人健（検）診予約日程事業マスタ：ベースで主キー重複チェック
                    var existflg = db.tm_shyoyakujigyo.SELECT.WHERE.ByKey(dto.nendo, dto.jigyocd).Exists();
                    if (existflg == true)
                    {
                        res.SetServiceError(EnumMessage.E002003, "成人健（検）診予約日程事業");

                        //異常返す
                        return res;
                    }
                    db.tm_shyoyakujigyo.INSERT.Execute(dto);
                }
                //変更の場合
                else
                {
                    //成人健（検）診予約日程事業マスタ：排他チェック
                    db.tm_shyoyakujigyo.UpdateDto(dto, req.maininfo.upddttm!.Value);
                }
                //成人健（検）診予約日程事業サブマスタ
                db.tm_shyoyakujigyo_sub.UPDATE.WHERE.ByKey(req.nendo, jigyocd).Execute(dtl);

                //正常返し
                return res;
            });
        }
        [DisplayName("削除処理(検診予約事業詳細画面)")]
        public DaResponseBase DeleteKensinYoyakuJigyoDetail(DeleteKensinYoyakuJigyoDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //健（検）診予定テーブル
                var existsFlg = db.tt_shkensinyotei.SELECT.WHERE.
                                ByFilter(@$"{nameof(tt_shkensinyoteiDto.nendo)} = @{nameof(tt_shkensinyoteiDto.nendo)} and 
                                            {nameof(tt_shkensinyoteiDto.jigyocd)} = @{nameof(tt_shkensinyoteiDto.jigyocd)}",
                                            req.nendo, req.jigyocd).Exists();
                if (existsFlg)
                {
                    //エラーメッセージ設定
                    res.SetServiceError(EnumMessage.E014001, "成人健（検）診予約日程事業");
                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------
                //成人健（検）診予約日程事業マスタ：排他チェック
                db.tm_shyoyakujigyo.DeleteByKey(req.nendo, req.jigyocd, req.upddttm);

                //成人健（検）診予約日程事業サブマスタ
                db.tm_shyoyakujigyo_sub.DELETE.WHERE.ByKey(req.nendo, req.jigyocd).Execute();

                //正常返し
                return new DaResponseBase();
            });
        }
        // **************************************************************************************************************************************
        // その他予約事業一覧画面
        // **************************************************************************************************************************************
        [DisplayName("初期化処理(その他予約事業一覧画面)")]
        public InitYoyakuSidoJigyoListResponse InitYoyakuSidoJigyoList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitYoyakuSidoJigyoListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //一覧抽出：その他日程事業・保健指導事業マスタ
                var dt = DaDbUtil.GetProcedureData(db, PROC_NAME8);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //その他予約事業一覧
                res.kekkalist = Wraper.GetVMList(db, dt.Rows).OrderBy(e => e.jigyocd).ToList();
                //業務区分ドロップダウンリスト
                res.selectorlist = Wraper.GetSelectorList(db);

                //正常返し
                return res;
            });
        }
        [DisplayName("保存処理(その他予約事業一覧画面)")]
        public DaResponseBase SaveYoyakuSidoJigyoList(SaveYoyakuSidoJigyoListRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //一覧抽出
                var dt = DaDbUtil.GetProcedureData(db, PROC_NAME8);
                //その他予約事業一覧
                var oldList = Wraper.GetVMList(db, dt.Rows);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //その他日程事業・保健指導事業マスタ
                var dtl = Converter.GetDtl(req.kekkalist);

                //-------------------------------------------------------------
                //３.チェック処理
                //-------------------------------------------------------------
                //排他チェック
                if (!Check(oldList, req.locklist)) throw new AiExclusiveException();
                var checkList = oldList.Where(e => !e.editflg).ToList();

                //行削除チェック
                var rowdelMsgStr = RowDeleteExist(db, req, oldList);
                if (!string.IsNullOrEmpty(rowdelMsgStr))
                {
                    //エラーメッセージ設定
                    res.SetServiceError(EnumMessage.E014001, "その他日程・保健指導事業");
                    res.message = $"{res.message}{rowdelMsgStr}";
                    //異常返し
                    return res;
                }

                var existsMsgStr = Check(db, checkList, dtl);
                //存在チェック：予約、訪問、相談、集団のデータ存在チェック
                if (!string.IsNullOrEmpty(existsMsgStr))
                {
                    //エラーメッセージ設定
                    res.SetServiceError(EnumMessage.E014010, "その他日程・保健指導事業");
                    res.message = $"{res.message}{existsMsgStr}";
                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //その他日程事業・保健指導事業マスタ
                db.tm_kksonotasidojigyo.UPDATE.DiffUpdate(dtl);

                //正常返し
                return res;
            });
        }
        // **************************************************************************************************************************************
        // private function
        // **************************************************************************************************************************************
        /// <summary>
        /// 排他チェック
        /// </summary>
        private static bool Check(List<YoyakuSidoJigyoRowVM> oldList, List<YoyakuSidoJigyoLockVM> locklist)
        {
            return oldList.Count == locklist.Count &&
                   oldList.All(dto => locklist.Exists(e => e.jigyocd == dto.jigyocd && e.upddttm == dto.upddttm));
        }
        /// <summary>
        /// 存在チェック
        /// </summary>
        private static string Check(DaDbContext db, List<YoyakuSidoJigyoRowVM> checkList, List<tm_kksonotasidojigyoDto> dtl)
        {
            var existsMsgStr = string.Empty;
            foreach (var vm in checkList)
            {
                //業務区分変更
                var dto = dtl.Find(e => e.jigyocd == vm.jigyocd && e.gyomukbn == DaSelectorService.GetCd(vm.gyomukbncdnm));
                if (dto == null)
                {
                    existsMsgStr = $"{existsMsgStr}{CRLF}事業コード{C_COLON_FULL}{vm.jigyocd}{SPACE_FULL}事業名{C_COLON_FULL}{vm.jigyonm}";
                    continue;
                }

                //予約、訪問、相談、集団の利用チェックを外す
                var existFlg = IsExistTable(db, vm, dtl);
                if (existFlg)
                {
                    existsMsgStr = $"{existsMsgStr}{CRLF}事業コード{C_COLON_FULL}{vm.jigyocd}{SPACE_FULL}事業名{C_COLON_FULL}{vm.jigyonm}";
                    continue;
                }
            }

            return existsMsgStr;
        }
        /// <summary>
        /// 条件コードリスト取得
        /// </summary>
        private GetCodejokenListResponse GetCodejokenListResponse(DaDbContext db, GetCodejokenListResponse res, Enum入力タイプ inputtype, string? codejoken1, string? codejoken2, string? codejoken3, string? jigyocd = null, string? group = null)
        {
            var kbn = Wraper.GetCtrlkbn(db, inputtype);
            if (kbn != Enumコントローラー分類.選択) return res;
            //コード条件1ドロップダウンリスト
            res.selectorlist5 = CmLogicUtil.GetFreeItemCdList(db, Enum名称区分.名称, inputtype, Enum条件コード区分.コード1).OrderBy(e => CInt(e.value)).ToList();
            //コード条件2ドロップダウンリスト
            if (!string.IsNullOrEmpty(codejoken1))
            {
                var cd = DaSelectorService.GetCd(codejoken1);
                if (!string.IsNullOrEmpty(jigyocd) && !string.IsNullOrEmpty(group) && inputtype == Enum入力タイプ.コード_汎用マスタ && cd == 名称マスタ.システム.名称マスタメインコード._3019)
                {
                    res.selectorlist6 = CmLogicUtil.GetFreeItemCdList(db, Enum名称区分.名称, inputtype, Enum条件コード区分.コード2, cd, jigyocd, DaSelectorService.GetCd(group));
                }
                res.selectorlist6 = CmLogicUtil.GetFreeItemCdList(db, Enum名称区分.名称, inputtype, Enum条件コード区分.コード2, cd).OrderBy(e => CInt(e.value)).ToList();
            }
            else
            {
                res.selectorlist6 = CmLogicUtil.GetFreeItemCdList(db, Enum名称区分.名称, inputtype, Enum条件コード区分.コード2).OrderBy(e => CInt(e.value)).ToList();
            }
            //コード条件3ドロップダウンリスト
            res.selectorlist7 = CmLogicUtil.GetFreeItemCdList(db, Enum名称区分.名称, inputtype, Enum条件コード区分.コード3).OrderBy(e => CInt(e.value)).ToList();

            return res;
        }

        /// <summary>
        /// 行削除チェック
        /// </summary>
        private string RowDeleteExist(DaDbContext db, SaveYoyakuSidoJigyoListRequest req, List<YoyakuSidoJigyoRowVM> oldList)
        {
            var rowdelMsgStr = string.Empty;
            var jigyocdsGamen = req.kekkalist.Select(e => new { e.jigyocd, e.jigyonm });       //画面のコード
            var jigyocdsDb = oldList.Select(e => new { e.jigyocd, e.jigyonm });                //DBのコード
            var delList = jigyocdsDb.Except(jigyocdsGamen).ToList();                           //行削除のコード
            foreach (var item in delList)
            {
                if (db.tt_kkjigyoyotei.SELECT.WHERE.ByItem(nameof(tt_kkjigyoyoteiDto.jigyocd), item.jigyocd).Exists()
                                          || db.tt_kkhokensido_mosikomi.SELECT.WHERE.ByItem(nameof(tt_kkhokensido_mosikomiDto.jigyocd), item.jigyocd).Exists()
                                          || db.tt_kkhokensido_kekka.SELECT.WHERE.ByItem(nameof(tt_kkhokensido_kekkaDto.jigyocd), item.jigyocd).Exists()
                                          || db.tt_kksyudansido_mosikomi.SELECT.WHERE.ByItem(nameof(tt_kksyudansido_mosikomiDto.jigyocd), item.jigyocd).Exists()
                                          || db.tt_kksyudansido_kekka.SELECT.WHERE.ByItem(nameof(tt_kksyudansido_kekkaDto.jigyocd), item.jigyocd).Exists())
                {
                    rowdelMsgStr = $"{rowdelMsgStr}{CRLF}事業コード{C_COLON_FULL}{item.jigyocd}{SPACE_FULL}事業名{C_COLON_FULL}{item.jigyonm}";
                }
            }

            return rowdelMsgStr;
        }

        /// <summary>
        /// 予約、訪問、相談、集団の利用状況を判断
        /// </summary>
        private static bool IsExistTable(DaDbContext db, YoyakuSidoJigyoRowVM vm, List<tm_kksonotasidojigyoDto> dtl)
        {
            var gyomukbncd = DaSelectorService.GetCd(vm.gyomukbncdnm);
            var kbn = CmLogicUtil.GetKakuYoyakuSidoGyomukbn(gyomukbncd);
            //todo チェック仕様について保留とする
            if (kbn == Enum拡張予約指導業務区分.予防接種) return false;

            //予約利用フラグ ※事業予定テーブル
            var yoyakuriyoflg = db.tt_kkjigyoyotei.SELECT.WHERE.ByItem(nameof(tt_kkjigyoyoteiDto.jigyocd), vm.jigyocd).Exists()
                                && (vm.yoyakuriyoflg == true)
                                && (dtl.Find(e => e.jigyocd == vm.jigyocd && e.yoyakuriyoflg == false) != null);

            //訪問利用フラグ
            var homonriyoflg = (vm.homonriyoflg == true) && (dtl.Find(e => e.jigyocd == vm.jigyocd && e.homonriyoflg == false) != null);
            var homonriyoflg2 = false;
            var homonriyoflg3 = false;
            if (homonriyoflg)
            {
                switch (kbn)
                {
                    case Enum拡張予約指導業務区分.成人保健:
                    case Enum拡張予約指導業務区分.母子保健:
                        //保健指導申込情報（固定項目）テーブル
                        homonriyoflg2 = db.tt_kkhokensido_mosikomi.SELECT.WHERE.ByFilter($@"{nameof(tt_kkhokensido_mosikomiDto.jigyocd)} = @jigyocd and
                                                                          {nameof(tt_kkhokensido_mosikomiDto.hokensidokbn)} = @hokensidokbn and
                                                                          {nameof(tt_kkhokensido_mosikomiDto.gyomukbn)} = @gyomukbn"
                                                                          , vm.jigyocd, EnumToStr(Enum指導区分.訪問指導), gyomukbncd).Exists();
                        //保健指導結果情報（固定項目）テーブル
                        homonriyoflg3 = db.tt_kkhokensido_kekka.SELECT.WHERE.ByFilter($@"{nameof(tt_kkhokensido_kekkaDto.jigyocd)} = @jigyocd and
                                                                          {nameof(tt_kkhokensido_kekkaDto.hokensidokbn)} = @hokensidokbn and
                                                                          {nameof(tt_kkhokensido_kekkaDto.gyomukbn)} = @gyomukbn"
                                                                          , vm.jigyocd, EnumToStr(Enum指導区分.訪問指導), gyomukbncd).Exists();

                        homonriyoflg = homonriyoflg && (homonriyoflg2 || homonriyoflg3);
                        break;
                    default:
                        throw new Exception("業務区分 error");
                }
            }

            //相談利用フラグ
            var sodanriyoflg = (vm.sodanriyoflg) && (dtl.Find(e => e.jigyocd == vm.jigyocd && e.sodanriyoflg == false) != null);
            var sodanriyoflg2 = false;
            var sodanriyoflg3 = false;
            if (sodanriyoflg)
            {
                switch (kbn)
                {
                    case Enum拡張予約指導業務区分.成人保健:
                    case Enum拡張予約指導業務区分.母子保健:
                        //保健指導申込情報（固定項目）テーブル
                        sodanriyoflg2 = db.tt_kkhokensido_mosikomi.SELECT.WHERE.ByFilter($@"{nameof(tt_kkhokensido_mosikomiDto.jigyocd)} = @jigyocd and
                                                                          {nameof(tt_kkhokensido_mosikomiDto.hokensidokbn)} = @hokensidokbn and
                                                                          {nameof(tt_kkhokensido_mosikomiDto.gyomukbn)} = @gyomukbn"
                                                                          , vm.jigyocd, EnumToStr(Enum指導区分.個別指導), gyomukbncd).Exists();
                        //保健指導結果情報（固定項目）テーブル
                        sodanriyoflg3 = db.tt_kkhokensido_kekka.SELECT.WHERE.ByFilter($@"{nameof(tt_kkhokensido_kekkaDto.jigyocd)} = @jigyocd and
                                                                          {nameof(tt_kkhokensido_kekkaDto.hokensidokbn)} = @hokensidokbn and
                                                                          {nameof(tt_kkhokensido_kekkaDto.gyomukbn)} = @gyomukbn"
                                                                          , vm.jigyocd, EnumToStr(Enum指導区分.個別指導), gyomukbncd).Exists();

                        sodanriyoflg = sodanriyoflg && (sodanriyoflg2 || sodanriyoflg3);
                        break;
                    default:
                        throw new Exception("業務区分 error");
                }
            }

            //集団利用フラグ
            var syudanriyoflg = (vm.syudanriyoflg) && (dtl.Find(e => e.jigyocd == vm.jigyocd && e.syudanriyoflg == false) != null);
            var syudanriyoflg2 = false;
            var syudanriyoflg3 = false;
            if (syudanriyoflg)
            {
                switch (kbn)
                {
                    case Enum拡張予約指導業務区分.成人保健:
                    case Enum拡張予約指導業務区分.母子保健:
                        //集団指導申込情報（固定項目）テーブル
                        syudanriyoflg2 = db.tt_kksyudansido_mosikomi.SELECT.WHERE.ByFilter($@"{nameof(tt_kksyudansido_mosikomiDto.jigyocd)} = @jigyocd and
                                                                                              {nameof(tt_kksyudansido_mosikomiDto.gyomukbn)} = @gyomukbn"
                                                                                              , vm.jigyocd, gyomukbncd).Exists();
                        //集団指導結果情報（固定項目）テーブル
                        syudanriyoflg3 = db.tt_kksyudansido_kekka.SELECT.WHERE.ByFilter($@"{nameof(tt_kksyudansido_kekkaDto.jigyocd)} =  @jigyocd and
                                                                                           {nameof(tt_kksyudansido_kekkaDto.gyomukbn)}= @gyomukbn"
                                                                                           , vm.jigyocd, gyomukbncd).Exists();

                        syudanriyoflg = syudanriyoflg && (syudanriyoflg2 || syudanriyoflg3);
                        break;
                    default:
                        throw new Exception("業務区分 error");
                }
            }

            if (yoyakuriyoflg || homonriyoflg || sodanriyoflg || syudanriyoflg) return true;

            return false;
        }

        /// <summary>
        /// 保健指導・集団指導項目グループを取得
        /// </summary>
        private List<DaSelectorModel> GetGroupList(DaDbContext db, InitSidoItemDetailRequest req, Enumフリー項目グループNo group)
        {
            var dtlGrp = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.保健指導_集団指導項目グループ);
            var listGrp = new List<DaSelectorModel>();
            foreach (var dtoHanyo in dtlGrp)
            {
                var hanyokbn2Arr = dtoHanyo.hanyokbn2!.ToArray();
                if (hanyokbn2Arr.Length == GRPKBN2LEN)
                {
                    //項目のグループ値を取得
                    if (dtoHanyo.hanyokbn1 == EnumToStr(group)
                        && CStr(hanyokbn2Arr[0]) == EnumToStr(req.sidokbn)
                        && CStr($"{hanyokbn2Arr[1]}{hanyokbn2Arr[2]}") == req.gyomukbn
                        && CStr(hanyokbn2Arr[3]) == EnumToStr(req.mosikomikekkakbn)
                        && CStr(hanyokbn2Arr[4]) == EnumToStr(req.itemyotokbn))
                    {
                        listGrp.Add(new DaSelectorModel(dtoHanyo.hanyocd, CStr(dtoHanyo.nm)));
                    }
                }
            }
            listGrp = listGrp.OrderBy(e => e.value).ToList();

            return listGrp;
        }

        /// <summary>
        /// 入力タイプドロップダウンリストを取得
        /// </summary>
        private List<DaSelectorModel> GetInputTypeList(DaDbContext db, bool halfflg, bool dayflg, bool cdflg, bool fullflg)
        {
            //入力タイプドロップダウンリスト
            var list = DaNameService.GetSelectorList(db, EnumNmKbn.フリー項目データタイプ,
                                                                Enum名称区分.名称).OrderBy(e => CInt(e.value)).ToList();
            //入力制限件数に達したタイプがリストに表示しない
            var dtlInputType = DaNameService.GetNameList(db, EnumNmKbn.フリー項目データタイプ);

            if (halfflg) dtlInputType = dtlInputType.Where(e => e.hanyokbn2 != EnumToStr(Enum入力タイプ分類.半角)).ToList();
            if (dayflg) dtlInputType = dtlInputType.Where(e => e.hanyokbn2 != EnumToStr(Enum入力タイプ分類.日付)).ToList();
            if (cdflg) dtlInputType = dtlInputType.Where(e => e.hanyokbn2 != EnumToStr(Enum入力タイプ分類.コード)).ToList();
            if (fullflg) dtlInputType = dtlInputType.Where(e => e.hanyokbn2 != EnumToStr(Enum入力タイプ分類.全角)).ToList();
            if (dtlInputType != null && dtlInputType.Count != list.Count)
            {
                var vallist = dtlInputType.Select(e => e.nmcd).ToList();
                list = list.Where(e => vallist.Contains(e.value)).ToList();
            }

            return list;
        }

        /// <summary>
        /// ユーザー領域体系
        /// </summary>
        private SaveKensinJigyoDetailResponse GetUserRyoikiInfo(DaDbContext db, SaveKensinJigyoDetailResponse res,
                                                                                string maincd3, int subcd3, int subcd4, int subcd5,
                                                                                out string cd1, out string cd2, out string cd3)
        {
            cd1 = string.Empty;
            cd2 = string.Empty;
            cd3 = string.Empty;
            //コード体系（メモ事業コード）
            ST1 = GetUserRyoikiCd(db, maincd3, subcd3);
            var dtoMain1 = db.tm_afhanyo_main.SELECT.WHERE.ByKey(maincd3, subcd3).GetDto();
            var ST1Max = CmLogicUtil.GetUserRyoikiMaxCd(dtoMain1.keta);
            if (ST1 > ST1Max)
            {
                //エラーメッセージ設定
                res.SetServiceError(EnumMessage.E004011, CStr(ST1Max));
                //異常返し
                return res;
            }
            cd1 = CStr(ST1);
            //コード体系（電子ファイル事業コード）
            ST2 = GetUserRyoikiCd(db, maincd3, subcd4);
            var dtoMain2 = db.tm_afhanyo_main.SELECT.WHERE.ByKey(maincd3, subcd4).GetDto();
            var ST2Max = CmLogicUtil.GetUserRyoikiMaxCd(dtoMain2.keta);
            if (ST2 > ST2Max)
            {
                //エラーメッセージ設定
                res.SetServiceError(EnumMessage.E004011, CStr(ST2Max));
                //異常返し
                return res;
            }
            cd2 = CStr(ST2);
            //コード体系（医療機関・事業従事者（担当者）事業コード）
            ST3 = GetUserRyoikiCd(db, maincd3, subcd5);
            var dtoMain3 = db.tm_afhanyo_main.SELECT.WHERE.ByKey(maincd3, subcd5).GetDto();
            var ST3Max = CmLogicUtil.GetUserRyoikiMaxCd(dtoMain3.keta);
            if (ST3 > ST3Max)
            {
                //エラーメッセージ設定
                res.SetServiceError(EnumMessage.E004011, CStr(ST3Max));
                //異常返し
                return res;
            }
            cd3 = CStr(ST3);

            return res;
        }

        /// <summary>
        /// ユーザ領域コードを取得
        /// </summary>
        private int GetUserRyoikiCd(DaDbContext db, string hanyomaincd, int hanyosubcd)
        {
            var ryoikiCd = 0;
            var dtoMain = db.tm_afhanyo_main.SELECT.WHERE.ByKey(hanyomaincd, hanyosubcd).GetDto();

            //汎用マスタのユーザ領域開始コード
            if (CInt(dtoMain.keta) > 0 && CInt(dtoMain.userryoikikaisicd) > 0)
            {
                var cdMax = CmLogicUtil.GetUserRyoikiMaxCd(dtoMain.keta);
                var cdMin = CInt(dtoMain.userryoikikaisicd);

                var dtlHanyo = db.tm_afhanyo.SELECT.WHERE.ByKey(hanyomaincd, hanyosubcd).GetDtoList()
                                                   .Where(e => CInt(e.hanyocd) >= cdMin && CInt(e.hanyocd) <= cdMax
                                                                    && CInt(e.hanyocd) > CmLogicUtil.AWSH001_CT)
                                                   .OrderBy(e => CInt(e.hanyocd)).Select(e => CInt(e.hanyocd)).ToList();
                if (dtlHanyo.Count == 0)
                {
                    ryoikiCd = cdMin;
                }
                else
                {
                    var list = new List<int>();
                    for (int i = cdMin; i <= cdMax; i++)
                    {
                        list.Add(i);
                    }
                    if (list.Count > dtlHanyo.Count)
                    {
                        ryoikiCd = list.Except(dtlHanyo).First();
                    }
                    else
                    {
                        //上限値に達する
                        ryoikiCd = ++cdMax;
                    }
                }
            }
            return ryoikiCd;
        }

        /// <summary>
        /// 登録チェック（「実施」のチェック外す、料金パターン変更）
        /// </summary>
        private bool ChkHantei(DaDbContext db, string jigyocd, int nendo, List<KensinYoyakuDetailRowSaveVM> kekkalist, bool jissiflgHantei)
        {
            var existsFlg2 = false;
            //健（検）診予定テーブル
            var dtl4 = db.tt_shkensinyotei.SELECT.WHERE.
                           ByFilter(@$"{nameof(tt_shkensinyoteiDto.nendo)} = @{nameof(tt_shkensinyoteiDto.nendo)} and 
                                       {nameof(tt_shkensinyoteiDto.jigyocd)} = @{nameof(tt_shkensinyoteiDto.jigyocd)}",
                                       nendo, jigyocd).GetDtoList();
            //料金パターン変更の場合
            if (jissiflgHantei == true)
            {
                //健（検）診予約希望者詳細テーブル
                var dtl3 = db.tt_shkensinkibosyasyosai.SELECT.WHERE.
                           ByFilter(@$"{nameof(tt_shkensinkibosyasyosaiDto.nendo)} = @{nameof(tt_shkensinkibosyasyosaiDto.nendo)}", nendo).GetDtoList();
                existsFlg2 = dtl3.Where(e => dtl4.Select(e => e.nitteino).ToList().Contains(e.nitteino)).Count() > 0 ? true : false;
                
                return existsFlg2;
            }
            //実施チェック外す場合
            else
            {
                //健（検）診予約希望者詳細テーブル
                var dtl2 = kekkalist
                              .Where(e => e.jissiflg == jissiflgHantei)
                              .Select(e => new
                              {
                                  jigyocd = e.jigyocd,
                                  kensahohocd = string.IsNullOrEmpty(e.kensahohocd) ? AWSH00301G.Service.KENSAHOHOCD : e.kensahohocd
                              }).ToList();

                foreach (var d in dtl2)
                {
                    //健（検）診予約希望者詳細テーブル
                    var dtl3 = db.tt_shkensinkibosyasyosai.SELECT.WHERE.
                               ByFilter(@$"{nameof(tt_shkensinkibosyasyosaiDto.nendo)} = @{nameof(tt_shkensinkibosyasyosaiDto.nendo)} and 
                                           {nameof(tt_shkensinkibosyasyosaiDto.jigyocd)} = @{nameof(tt_shkensinkibosyasyosaiDto.jigyocd)} and
                                           {nameof(tt_shkensinkibosyasyosaiDto.kensahohocd)} = @{nameof(tt_shkensinkibosyasyosaiDto.kensahohocd)}",
                                           nendo, d.jigyocd, d.kensahohocd).GetDtoList();
                    existsFlg2 = dtl3.Where(e => dtl4.Select(e => e.nitteino).ToList().Contains(e.nitteino)).Count() > 0 ? true : false;
                    if (existsFlg2) break;
                }
            }

            return existsFlg2;
        }
    }
}