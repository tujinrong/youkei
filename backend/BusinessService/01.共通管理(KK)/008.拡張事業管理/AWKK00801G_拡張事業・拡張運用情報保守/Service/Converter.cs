// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 拡張事業・拡張運用情報保守
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.01.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaStrPool;
using static BCC.Affect.DataAccess.DaCodeConst;

namespace BCC.Affect.Service.AWKK00801G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 成人健（検）診事業マスタ
        /// </summary>
        public static tm_shkensinjigyoDto GetDto(tm_shkensinjigyoDto dto, SaveKensinJigyoDetailRequest req, string maincd1, string maincd2)
        {
            dto.jigyocd = req.jigyocd!;                                                                                 //成人健（検）診事業コード
            if (req.editkbn == Enum編集区分.新規)
            {
                dto.kihonkakutyokbn = Enum事業区分.市区町村拡張事業;                                                    //基本／拡張事業区分
            }
            dto.seikenjissikbn = (Enum精密検査実施区分)CInt(DaSelectorService.GetCd(req.jigyoinfo.seikenjissikbn));     //精密検査実施区分
            dto.genmenkbn = (Enum減免区分種別)CInt(DaSelectorService.GetCd(req.jigyoinfo.genmenkbn));                   //減免区分
            dto.syogaiikaiflg = CBool(DaSelectorService.GetCd(CStr(req.jigyoinfo.syogaiikaiflg)));                      //生涯１回フラグ
            dto.cuponhyojikbn = (Enum画面表示区分)CInt(DaSelectorService.GetCd(req.jigyoinfo.cuponhyojikbn));           //クーポン券表示区分
            dto.kensahoho_setflg = req.hohoinfo.kensahoho_setflg;                                                       //検査方法設定フラグ
            if (dto.kensahoho_setflg)
            {
                dto.kensahoho_maincd = maincd1;                                                                         //検査方法メインコード
                //検査方法サブコード                                                                                    
                dto.kensahoho_subcd = CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, req.jigyocd!);
                dto.yoyakubunrui_maincd = maincd2;                                                                      //予約分類メインコード
                //予約分類サブコード
                dto.yoyakubunrui_subcd = CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.予約分類, req.jigyocd!);
            }
            else
            {
                dto.kensahoho_maincd = null;                                                                            //検査方法メインコード
                dto.kensahoho_subcd = null;                                                                             //検査方法サブコード
                dto.yoyakubunrui_maincd = null;                                                                         //予約分類メインコード
                dto.yoyakubunrui_subcd = null;                                                                          //予約分類サブコード
            }
            //明細件数がない場合、使わないと認識する
            if (req.freeinfo.kekkalist.Count > 0)
            {
                dto.groupid2_maincd = maincd2;                                                                      //フリー項目グループ右設定メインコード
                //フリー項目グループ右設定サブコード
                dto.groupid2_subcd = CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.グループ2, req.jigyocd!);
            }
            else
            {
                dto.groupid2_maincd = null;                                                                         //フリー項目グループ右設定メインコード
                dto.groupid2_subcd = null;                                                                          //フリー項目グループ右設定サブコード
            }

            //エラーチェック
            dto.yoyakuchk = (EnumMsgCtrlKbn)CInt(DaSelectorService.GetCd(req.errorchkinfo.yoyakuchk));              //予約画面チェック区分
            dto.kensinchk = (EnumMsgCtrlKbn)CInt(DaSelectorService.GetCd(req.errorchkinfo.kensinchk));              //健（検）診画面チェック区分

            return dto;
        }
        /// <summary>
        /// 機能ID
        /// </summary>
        public static string GetKinoid(SaveKensinJigyoDetailRequest req)
        {
            if (string.IsNullOrEmpty(req.jigyoinfo.kinoid))
            {
                return CmLogicUtil.GetKensinKinoid(req.jigyocd!);
            }
            else
            {
                return req.jigyoinfo.kinoid;
            }
        }
        /// <summary>
        /// 機能マスタ
        /// </summary>
        public static tm_afkinoDto GetDto(SaveKensinJigyoDetailRequest req, string programid)
        {
            var dto = new tm_afkinoDto();
            dto.kinoid = GetKinoid(req);            //機能ID
            dto.hyojinm = req.jigyoinfo.hyojinm;    //表示名称
            dto.programid = programid;              //プログラムID（共用）
            dto.hanyokbn = req.jigyocd;             //汎用区分

            return dto;
        }
        /// <summary>
        /// メニューマスタ
        /// </summary>
        public static tm_afmenuDto GetDto(tm_afmenuDto dto, SaveKensinJigyoDetailRequest req, string menuid, int seqmax)
        {
            dto.kinoid = GetKinoid(req);                                    //機能ID
            if (string.IsNullOrEmpty(req.jigyoinfo.kinoid))
            {
                //新規採番の場合、親メニューIDのグループに最大値＋１
                dto.orderseq = seqmax + 1;                                  //並びシーケンス
            }
            dto.oyamenuid = menuid;                                         //親メニューID
            dto.paramkeisyoflg = true;                                      //検索パラメーター継承フラグ
            dto.addctrlflg = true;                                          //追加権限制御フラグ
            dto.updctrlflg = true;                                          //修正権限制御フラグ
            dto.delctrlflg = true;                                          //削除権限制御フラグ
            dto.pnousectrlflg = true;                                       //個人番号利用権限制御フラグ

            return dto;
        }
        /// <summary>
        /// 汎用メインマスタ
        /// </summary>
        public static List<tm_afhanyo_mainDto> GetMainDtl(SaveKensinJigyoDetailRequest req, string maincd1, string maincd2)
        {
            var list = new List<tm_afhanyo_mainDto>();
            //汎用メインマスタ：検査方法
            var dto1 = GetDto(req, maincd1, Enum検診関連汎用マスタ区分.検査方法);
            if (dto1 != null) list.Add(dto1);
            //汎用メインマスタ：予約分類
            var dto2 = GetDto(req, maincd2, Enum検診関連汎用マスタ区分.予約分類);
            if (dto2 != null) list.Add(dto2);
            //汎用メインマスタ：グループ2
            var dto3 = GetDto(req, maincd2, Enum検診関連汎用マスタ区分.グループ2);
            if (dto3 != null) list.Add(dto3);

            return list;
        }
        /// <summary>
        /// 汎用マスタ
        /// </summary>
        public static tm_afhanyoDto GetDto(tm_afhanyoDto? dto, SaveKensinJigyoDetailRequest req, string maincd, int subcd)
        {
            if (dto == null)
            {
                dto = new tm_afhanyoDto();
                dto.hanyomaincd = maincd;   //汎用メインコード
                dto.hanyosubcd = subcd;     //汎用サブコード
                dto.hanyocd = req.jigyocd!; //汎用コード
            }
            dto.nm = req.jigyonm;           //事業名
            dto.shortnm = req.jigyoshortnm; //事業名略称

            return dto;
        }
        /// <summary>
        /// 汎用マスタリスト
        /// </summary>
        public static List<tm_afhanyoDto> GetDtl(SaveKensinJigyoDetailRequest req, string maincd1, string maincd2)
        {
            var list = new List<tm_afhanyoDto>();
            //汎用マスタ：検査方法
            var dtl1 = GetDtl(req, maincd1, Enum検診関連汎用マスタ区分.検査方法);
            if (dtl1.Count > 0) list.AddRange(dtl1);
            //汎用マスタ：予約分類
            var dtl2 = GetDtl(req, maincd2, Enum検診関連汎用マスタ区分.予約分類);
            if (dtl2.Count > 0) list.AddRange(dtl2);
            //汎用マスタ：グループ2
            var dtl3 = GetDtl(req, maincd2, Enum検診関連汎用マスタ区分.グループ2);
            if (dtl3.Count > 0) list.AddRange(dtl3);

            return list;
        }
        /// <summary>
        /// 詳細条件設定テーブル
        /// </summary>
        public static List<tt_affilterDto> GetDtl(List<tt_affilterDto> dtl, string kinoid, string maincd, int subcd,
                                                    bool seikenflg, bool hohoflg, Enum編集区分 kbn)
        {
            var list = new List<tt_affilterDto>();
            if (kbn == Enum編集区分.新規)
            {
                //左部分(共通項目)
                foreach (var dto in dtl)
                {
                    dto.kinoid = kinoid;
                    list.Add(dto);
                }
                //右部分(ディフォルト項目)
                list.AddRange(GetDtl(kinoid, maincd, subcd, seikenflg, hohoflg));
            }
            else
            {
                list = GetDtl(dtl, kinoid, maincd, subcd, seikenflg, hohoflg);
            }

            return list;
        }

        /// <summary>
        /// 共通バー設定
        /// </summary>
        public static List<tm_afmeisyoDto> GetDtl(List<tm_afmeisyoDto> dtl, string AWSH00101G, string kinoid, string kinonm)
        {
            var list = new List<tm_afmeisyoDto>();
            foreach (var dto in dtl)
            {
                dto.nmcd = dto.nmcd.Replace(AWSH00101G, kinoid);
                dto.hanyokbn1 = kinoid;
                dto.nm = $"{kinonm}{DASHED}{dto.nm.Split(DASHED)[1]}";

                list.Add(dto);
            }

            return list;
        }
        /// <summary>
        /// 汎用マスタリスト(関連事業コード)
        /// </summary>
        public static List<tm_afhanyoDto> GetDtl(string maincd, int subcd1, int subcd2, int subcd3, int subcd4, int subcd5,
                                                    string cd1, string cd2, string cd3,
                                                    string kinoid, string jigyonm)
        {
            var list = new List<tm_afhanyoDto>();
            //汎用マスタ：メモ事業コード
            var dto1 = new tm_afhanyoDto();
            dto1.hanyomaincd = maincd;
            dto1.hanyosubcd = subcd1;
            dto1.hanyocd = cd1;
            dto1.nm = jigyonm ;
            dto1.hanyokbn1 = 名称マスタ.システム.事業集約コード._2;
            list.Add(dto1);

            //汎用マスタ：電子ファイル事業コード
            var dto2 = new tm_afhanyoDto();
            dto2.hanyomaincd = maincd;
            dto2.hanyosubcd = subcd2;
            dto2.hanyocd = cd2;
            dto2.nm = jigyonm;
            dto2.hanyokbn1 = 名称マスタ.システム.事業集約コード._2;
            list.Add(dto2);

            //汎用マスタ：医療機関・事業従事者（担当者）事業コード
            var dto3 = new tm_afhanyoDto();
            dto3.hanyomaincd = maincd;
            dto3.hanyosubcd = subcd3;
            dto3.hanyocd = cd3;
            dto3.nm = jigyonm;
            dto3.hanyokbn1 = 名称マスタ.システム.医療機関_事業従事者業務区分._01;
            list.Add(dto3);

            return list;
        }
        /// <summary>
        /// 汎用マスタリスト(関連事業コード)
        /// </summary>
        public static List<tm_afhanyoDto> GetDtl(List<tm_afhanyoDto> dtl, string maincd, int subcd1, int subcd2, int subcd3,
                                                int subcd4, int subcd5, string cd3,
                                                string kinoid, string jigyonm, Enum編集区分 kbn)
        {
            if (kbn == Enum編集区分.新規)
            {
                dtl = new List<tm_afhanyoDto>();

                //汎用マスタ：メモ事業コード管理
                var dto1 = new tm_afhanyoDto();
                dto1.hanyomaincd = maincd;
                dto1.hanyosubcd = subcd1;
                dto1.hanyocd = kinoid;
                dtl.Add(dto1);

                //汎用マスタ：電子ファイル事業コード管理
                var dto2 = new tm_afhanyoDto();
                dto2.hanyomaincd = maincd;
                dto2.hanyosubcd = subcd2;
                dto2.hanyocd = kinoid;
                dtl.Add(dto2);

                //汎用マスタ：連絡先事業コード管理
                var dto3 = new tm_afhanyoDto();
                dto3.hanyomaincd = maincd;
                dto3.hanyosubcd = subcd3;
                dto3.hanyocd = kinoid;
                dtl.Add(dto3);

                //汎用マスタ：医療機関事業コード管理
                var dto4 = new tm_afhanyoDto();
                dto4.hanyomaincd = maincd;
                dto4.hanyosubcd = subcd4;
                dto4.hanyocd = kinoid;
                dto4.hanyokbn1 = cd3;
                dtl.Add(dto4);

                //汎用マスタ：事業従事者事業コード管理
                var dto5 = new tm_afhanyoDto();
                dto5.hanyomaincd = maincd;
                dto5.hanyosubcd = subcd5;
                dto5.hanyocd = kinoid;
                dto5.hanyokbn1 = cd3;
                dtl.Add(dto5);
            }
            foreach (var dto in dtl)
            {
                switch (dto.hanyosubcd)
                {
                    //メモ事業コード管理
                    case int subcd when subcd == subcd1:
                        dto.nm = $"メモ（{jigyonm}）";
                        break;
                    //電子ファイル事業コード管理
                    case int subcd when subcd == subcd2:
                        dto.nm = $"電子ファイル（{jigyonm}）";
                        break;
                    //連絡先事業コード管理
                    case int subcd when subcd == subcd3:
                        dto.nm = $"連絡先（{jigyonm}）";
                        break;
                    //医療機関事業コード管理
                    case int subcd when subcd == subcd4:
                        dto.nm = $"医療機関（{jigyonm}）";
                        break;
                    //事業従事者事業コード管理
                    case int subcd when subcd == subcd5:
                        dto.nm = $"事業従事者（{jigyonm}）";
                        break;
                    default:
                        throw new Exception("汎用マスタサブコード error");
                }
            }

            return dtl;
        }
        /// <summary>
        /// 各種事業コード設定対象
        /// </summary>
        public static tm_afmeisyoDto GetDto(tm_afmeisyoDto? dto, string maincd, int subcd, string kinoid, string jigyonm, string hanyokbn1, Enum編集区分 kbn)
        {
            if (kbn == Enum編集区分.新規)
            {
                dto = new tm_afmeisyoDto();
            }
            dto!.nmmaincd = maincd;
            dto.nmsubcd = subcd;
            dto.nmcd = kinoid;
            dto.nm = jigyonm;
            dto.hanyokbn1 = hanyokbn1;  //集約コード設定フラグ

            return dto;
        }
        /// <summary>
        /// 成人保健検診結果（フリー）項目コントロールマスタ
        /// </summary>
        public static tm_shfreeitemDto GetDto(tm_shfreeitemDto dto, KensinItemDetailSaveVM vm, Enum編集区分 kbn, string jigyocd, string itemcd, int cdCt)
        {
            if (kbn == Enum編集区分.新規)
            {
                dto.jigyocd = jigyocd;                                                          //事業コード
                dto.itemcd = itemcd;                                                            //項目コード
                dto.itemkbn = Enumフリー項目区分区分.市区町村独自項目;                          //項目区分
                dto.groupid = (EnumKensinKbn)CInt(DaSelectorService.GetCd(vm.group));           //グループID
                dto.inputtype = (Enum入力タイプ)CInt(DaSelectorService.GetCd(vm.inputtype));    //入力タイプ
                dto.codejoken1 = ToNStr(DaSelectorService.GetCd(vm.codejoken1));                //コード条件1
                dto.codejoken2 = ToNStr(DaSelectorService.GetCd(vm.codejoken2));                //コード条件2
                dto.codejoken3 = ToNStr(DaSelectorService.GetCd(vm.codejoken3));                //コード条件3
                dto.rirekiflg = vm.rirekiflg;                                                   //履歴管理フラグ
                dto.haitiflg = false;                                                           //画面配置フラグ
                dto.orderseq = cdCt;                                                            //並びシーケンス
            }
            dto.komokutokuteikbn = ToNStr(DaSelectorService.GetCd(vm.komokutokuteikbn));        //項目特定区分
            dto.itemnm = vm.itemnm;                                                             //項目名
            dto.groupid2 = ToNStr(DaSelectorService.GetCd(vm.group2));                          //グループID2
            dto.inputflg = vm.inputflg;                                                         //入力フラグ
            dto.tani = ToNStr(vm.tani);                                                         //単位
            dto.syokiti = ToNStr(vm.syokiti);                                                   //初期値
            dto.biko = ToNStr(vm.biko);                                                         //備考
            dto.hyojinendof = CNInt(vm.hyojinendof);                                            //表示年度（開始）
            dto.hyojinendot = CNInt(vm.hyojinendot);                                            //表示年度（終了）
            dto.riyokensahohocd = ListToCommaStr(vm.riyokensahohocds);                          //利用検査方法コード
            dto.keta = vm.keta;                                                           　　　//入力桁
            dto.hissuflg = vm.hissuflg;                                                         //必須フラグ
            dto.msgkbn = (EnumMsgCtrlKbn)CInt(DaSelectorService.GetCd(vm.msgkbn));              //メッセージ区分
            dto.hanif = ToNStr(vm.hanif);                                                       //入力範囲（開始）
            dto.hanit = ToNStr(vm.hanit);                                                       //入力範囲（終了）
                                                                                                //計算区分コード
            var keisankbn = DaSelectorService.GetCd(vm.keisankbn);
            //計算区分設定なしの場合
            if (string.IsNullOrEmpty(keisankbn))
            {
                dto.keisankbn = Enum計算区分.Empty;                                         //計算区分
                //関連クリア項目
                dto.keisansusiki = string.Empty;                                            //計算数式
                dto.keisankansuid = string.Empty;                                           //計算関数ID
                dto.keisanparam = string.Empty;                                             //計算パラメータ
            }
            //計算区分設定ありの場合
            else
            {
                dto.keisankbn = (Enum計算区分)CInt(keisankbn);                              //計算区分
                switch (dto.keisankbn)
                {
                    case Enum計算区分.数式計算:
                        dto.keisansusiki = vm.keisansusiki;                                 //計算数式
                        break;
                    case Enum計算区分.内部関数:
                    case Enum計算区分.DB関数:
                        dto.keisankansuid = DaSelectorService.GetCd(vm.keisankansu);        //計算関数ID
                        dto.keisanparam = ListToCommaStr(vm.keisanparams, false);           //計算パラメータ
                        break;
                    default:
                        throw new Exception("Enum計算区分 error");
                }
            }

            return dto;
        }
        /// <summary>
        /// パラメータ取得(検診詳細画面：利用検査方法コード)
        /// </summary>
        public static List<AiKeyValue> GetParameters(string jigyocd, string itemcd, string riyokensahohocd)
        {
            var paras = GetParameters(jigyocd, itemcd);
            //利用検査方法コード(削除)
            paras.Add(new AiKeyValue($"{nameof(tm_shfreeitemDto.riyokensahohocd)}s_in", riyokensahohocd));
            return paras;
        }
        /// <summary>
        /// パラメータ取得(検診項目詳細画面：桁数)
        /// </summary>
        public static List<AiKeyValue> GetParameters(DaDbContext db, string jigyocd, string itemcd, string inputtype, int keta1, int? keta2)
        {
            //入力タイプ
            var kbn1 = (Enum入力タイプ)CInt(DaSelectorService.GetCd(inputtype));
            var kbn2 = (Enum入力タイプ型)CInt(DaNameService.GetKbn1(db, EnumNmKbn.フリー項目データタイプ, EnumToStr(kbn1)));
            var paras = GetParameters(jigyocd, itemcd);
            paras.Add(new AiKeyValue($"{nameof(tm_shfreeitemDto.inputtype)}kbn_in", (int)kbn2));    //入力タイプ型
            paras.Add(new AiKeyValue($"{nameof(tm_shfreeitemDto.keta)}1_in", keta1));               //入力桁(整数)
            paras.Add(new AiKeyValue($"{nameof(tm_shfreeitemDto.keta)}2_in", keta2));               //入力桁(小数)

            return paras;
        }
        /// <summary>
        /// パラメータ取得(検診項目詳細画面：必須)
        /// </summary>
        public static List<AiKeyValue> GetParameters(string jigyocd, string itemcd)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(tm_shfreeitemDto.jigyocd)}_in", jigyocd), //事業コード
                new($"{nameof(tm_shfreeitemDto.itemcd)}_in", itemcd)    //項目コード
            };
            return paras;
        }
        /// <summary>
        /// パラメータ取得(項目詳細画面：必須)
        /// </summary>
        public static string GetFilterSql(DaDbContext db, string filterStr, FreeItemDetailBaseVM vm, string strNm, string numNm)
        {
            //入力タイプ
            var inputtype = (Enum入力タイプ)CInt(DaSelectorService.GetCd(vm.inputtype!));
            //項目物理名
            var komokuNm = CmLogicUtil.GetFreeKoumokuNm(db, inputtype, strNm, numNm);
            var kbn = (Enum入力タイプ型)CInt(DaNameService.GetKbn1(db, EnumNmKbn.フリー項目データタイプ, EnumToStr(inputtype)));
            switch (kbn)
            {
                case Enum入力タイプ型.数値:
                    //入力範囲（開始）、入力範囲（終了）が設定する場合
                    if (!string.IsNullOrEmpty(vm.hanif) && !string.IsNullOrEmpty(vm.hanit))
                    {
                        filterStr = $@"{filterStr} and 
                                        {DaStrPool.C_LEFT_BRACKET_HALF}{komokuNm} < {vm.hanif}
                                        or {komokuNm} > {vm.hanit}{DaStrPool.C_RIGHT_BRACKET_HALF}";
                    }
                    else if (!string.IsNullOrEmpty(vm.hanif))
                    {
                        //入力範囲（開始）のみが設定する場合
                        filterStr = $"{filterStr} and {komokuNm} < {vm.hanif}";
                    }
                    else if (!string.IsNullOrEmpty(vm.hanit))
                    {
                        //入力範囲（終了）のみが設定する場合
                        filterStr = $"{filterStr} and {komokuNm} > {vm.hanit}";
                    }

                    break;
                case Enum入力タイプ型.文字:
                    //入力範囲（開始）、入力範囲（終了）が設定する場合
                    if (!string.IsNullOrEmpty(vm.hanif) && !string.IsNullOrEmpty(vm.hanit))
                    {
                        filterStr = $@"{filterStr} and
                                        {DaStrPool.C_LEFT_BRACKET_HALF} {komokuNm} < '{vm.hanif}'
                                        or {komokuNm} > '{vm.hanit}'{DaStrPool.C_RIGHT_BRACKET_HALF}";
                    }
                    else if (!string.IsNullOrEmpty(vm.hanif))
                    {
                        //入力範囲（開始）のみが設定する場合
                        filterStr = $"{filterStr} and {komokuNm} < '{vm.hanif}'";
                    }
                    else if (!string.IsNullOrEmpty(vm.hanit))
                    {
                        //入力範囲（終了）のみが設定する場合
                        filterStr = $"{filterStr} and {komokuNm} > '{vm.hanit}'";
                    }

                    break;
                default:
                    throw new Exception("Enum入力タイプ型 error");
            }
            return filterStr;
        }
        /// <summary>
        /// 詳細条件設定テーブル
        /// </summary>
        public static tt_affilterDto GetDto(DaDbContext db, tt_affilterDto dto, FreeItemDetailBaseVM vm, Enum編集区分 kbn, string kinoid,
                                            string keycd, string itemcd, int max, string tablenm, string strvaluenm, string numvaluenm, string fusyoflgnm)
        {
            if (kbn == Enum編集区分.新規)
            {
                dto.kinoid = kinoid;                                                                    //機能ID
                dto.jyokbn = Enum詳細検索条件区分.独自;                                                 //条件区分
                dto.jyoseq = max;                                                                       //条件シーケンス
                var inputtype = (Enum入力タイプ)CInt(DaSelectorService.GetCd(vm.inputtype));            //入力タイプ
                dto.ctrltype = CmLogicUtil.GetFreeKoumokuCtrltype(db, inputtype);                       //コントローラータイプ
                dto.hyojiflg = false;                                                                   //表示フラグ
                dto.rangeflg = CmLogicUtil.GetFreeKoumokuRangeflg(db, inputtype);                       //範囲フラグ
                dto.sethanyokbn1 = CmLogicUtil.GetFreeKoumokuSethanyokbn1(inputtype, dto.ctrltype);     //設定用汎用区分1
                dto.sethanyokbn2 = ToNStr(DaSelectorService.GetCd(vm.codejoken1));                      //設定用汎用区分2
                dto.sethanyokbn3 = ToNStr(DaSelectorService.GetCd(vm.codejoken2));                      //設定用汎用区分3
                dto.sethanyokbn4 = ToNStr(DaSelectorService.GetCd(vm.codejoken3));                      //設定用汎用区分4
                dto.getkbn = Enum取得元区分.フリー項目;                                                 //検索対象データ取得区分
                dto.tablenm1 = tablenm;                                                                 //テーブル物理名1
                dto.komokunm1 = CmLogicUtil.GetFreeKoumokuNm(db, inputtype, strvaluenm, numvaluenm);    //項目物理名1
                dto.keycd1 = keycd;                                                                     //主キーコード1
                dto.itemcd1 = itemcd;                                                                   //項目コード1
                //不詳の場合のみ
                if (inputtype == Enum入力タイプ.半角文字_年_不詳あり ||
                    inputtype == Enum入力タイプ.半角文字_年月_不詳あり ||
                    inputtype == Enum入力タイプ.日付_年月日_不詳あり)
                {
                    dto.tablenm2 = tablenm;                                                             //テーブル物理名2
                    dto.komokunm2 = fusyoflgnm;                                                         //項目物理名2
                    dto.keycd2 = keycd;                                                                 //主キーコード2
                    dto.itemcd2 = itemcd;                                                               //項目コード2
                }
                dto.sort = max;                                                                         //並び順
            }
            dto.hyojinm = vm.itemnm;                                                                    //詳細条件表示名

            return dto;
        }
        /// <summary>
        /// パラメータ取得(指導項目詳細画面：利用地域保健集計区分)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SidoCommonRequest req, string itemcd, string syukeikbns)
        {
            var paras = GetParameters(req, itemcd);
            //利用地域保健集計区分(削除)
            paras.Add(new AiKeyValue("syukeikbns_in", syukeikbns));
            return paras;
        }
        /// <summary>
        /// パラメータ取得(指導項目詳細画面：桁数)
        /// </summary>
        public static List<AiKeyValue> GetParameters(DaDbContext db, SidoCommonRequest req, string itemcd, string inputtype, int keta1, int? keta2)
        {
            //入力タイプ
            var kbn1 = (Enum入力タイプ)CInt(DaSelectorService.GetCd(inputtype));
            var kbn2 = (Enum入力タイプ型)CInt(DaNameService.GetKbn1(db, EnumNmKbn.フリー項目データタイプ, EnumToStr(kbn1)));
            var paras = GetParameters(req, itemcd);
            paras.Add(new AiKeyValue($"{nameof(tm_shfreeitemDto.inputtype)}kbn_in", (int)kbn2));    //入力タイプ型
            paras.Add(new AiKeyValue($"{nameof(tm_shfreeitemDto.keta)}1_in", keta1));               //入力桁(整数)
            paras.Add(new AiKeyValue($"{nameof(tm_shfreeitemDto.keta)}2_in", keta2));               //入力桁(小数)
            return paras;
        }
        /// <summary>
        /// パラメータ取得(指導項目詳細画面：必須)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SidoCommonRequest req, string itemcd)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(SidoCommonRequest.sidokbn)}_in", EnumToStr(req.sidokbn)),                     //指導区分
                new($"{nameof(SidoCommonRequest.gyomukbn)}_in", req.gyomukbn),                              //業務区分
                new($"{nameof(SidoCommonRequest.mosikomikekkakbn)}_in", EnumToStr(req.mosikomikekkakbn)),   //申込結果区分
                new($"{nameof(SidoCommonRequest.itemyotokbn)}_in", EnumToStr(req.itemyotokbn)),             //項目用途区分
                new($"{nameof(SaveSidoItemDetailRequest.itemcd)}_in", itemcd)                               //項目コード
            };
            return paras;
        }
        /// <summary>
        /// 指導（フリー項目）コントロールマスタ
        /// </summary>
        public static tm_kksidofreeitemDto GetDto(tm_kksidofreeitemDto dto, SidoItemDetailVM vm, Enum編集区分 kbn, SidoCommonRequest req, string itemcd, int cdCt)
        {
            if (kbn == Enum編集区分.新規)
            {
                dto.sidokbn = req.sidokbn;                                                      //指導区分
                dto.gyomukbn = req.gyomukbn;                                                    //業務区分
                dto.mosikomikekkakbn = req.mosikomikekkakbn;                                    //申込結果区分
                dto.itemyotokbn = req.itemyotokbn;                                              //項目用途区分
                dto.itemcd = itemcd;                                                            //項目コード
                dto.itemkbn = Enumフリー項目区分区分.市区町村独自項目;                          //項目区分
                dto.inputtype = (Enum入力タイプ)CInt(DaSelectorService.GetCd(vm.inputtype));    //入力タイプ
                dto.codejoken1 = ToNStr(DaSelectorService.GetCd(vm.codejoken1));                //コード条件1
                dto.codejoken2 = ToNStr(DaSelectorService.GetCd(vm.codejoken2));                //コード条件2
                dto.codejoken3 = ToNStr(DaSelectorService.GetCd(vm.codejoken3));                //コード条件3
                dto.orderseq = cdCt;                                                            //並びシーケンス
            }
            dto.itemnm = vm.itemnm;                                                             //項目名
            dto.groupid = ToNStr(DaSelectorService.GetCd(vm.group));                            //グループID
            dto.groupid2 = ToNStr(DaSelectorService.GetCd(vm.group2));                          //グループID2
            dto.inputflg = vm.inputflg;                                                         //入力フラグ
            dto.tani = ToNStr(vm.tani);                                                         //単位
            dto.syokiti = ToNStr(vm.syokiti);                                                   //初期値
            dto.komokutokuteikbn = ToNStr(DaSelectorService.GetCd(vm.komokutokuteikbn));        //項目特定区分
            dto.biko = ToNStr(vm.biko);                                                         //備考
            dto.syukeikbn = ListToCommaStr(vm.syukeikbns);                                      //利用地域保健集計区分
            dto.keta = vm.keta;                                                                 //入力桁
            dto.hissuflg = vm.hissuflg;                                                         //必須フラグ
            dto.msgkbn = (EnumMsgCtrlKbn)CInt(DaSelectorService.GetCd(vm.msgkbn));              //メッセージ区分
            dto.hanif = ToNStr(vm.hanif);                                                       //入力範囲（開始）
            dto.hanit = ToNStr(vm.hanit);                                                       //入力範囲（終了）

            return dto;
        }
        /// <summary>
        /// 汎用マスタキーリスト取得(検診予約)
        /// </summary>
        public static List<object[]> GetKeyList(List<tm_shkensinjigyoDto> dtl)
        {
            var maincd1 = 名称マスタ.システム.汎用マスタメインコード._1002;
            var maincd2 = 名称マスタ.システム.汎用マスタメインコード._3019;
            var subcd1 = (int)((long)EnumHanyoKbn.成人健_検_診予約日程事業名 % 100000000L);
            var subcd2 = (int)((long)EnumHanyoKbn.料金パターン % 100000000L);
            var subcd3 = (int)((long)EnumHanyoKbn.検診種別 % 100000000L);
            //キーリスト
            var keyList = new List<object[]>();
            keyList.Add(new object[] { maincd1, subcd1 });
            keyList.Add(new object[] { maincd1, subcd2 });
            keyList.Add(new object[] { maincd2, subcd3 });
            //検査方法
            foreach (var dto in dtl)
            {
                keyList.Add(new object[] { dto.kensahoho_maincd!, dto.kensahoho_subcd! });
            }
            return keyList;
        }
        /// <summary>
        /// 成人健（検）診予約日程事業マスタ
        /// </summary>
        public static tm_shyoyakujigyoDto GetDto(tm_shyoyakujigyoDto dto, string ryokinpattern, int nendo, string jigyocd)
        {
            dto.nendo = nendo;                  //年度
            dto.jigyocd = jigyocd;              //成人健（検）診予約日程事業コード
            dto.ryokinpattern = ryokinpattern;  //料金パターン

            return dto;
        }
        /// <summary>
        /// 成人健（検）診予約日程事業サブマスタ
        /// </summary>
        public static List<tm_shyoyakujigyo_subDto> GetDtl(List<KensinYoyakuDetailRowSaveVM> vmList, int nendo, string jigyocd)
        {
            var dtl = new List<tm_shyoyakujigyo_subDto>();
            foreach (var vm in vmList)
            {
                //実施チェックのデータ更新のみ
                if (vm.jissiflg)
                {
                    dtl.Add(GetDto(vm, nendo, jigyocd));
                }
            }

            return dtl;
        }
        /// <summary>
        /// その他日程事業・保健指導事業マスタ
        /// </summary>
        public static List<tm_kksonotasidojigyoDto> GetDtl(List<YoyakuSidoJigyoRowSaveVM> vmList)
        {
            var dtl = new List<tm_kksonotasidojigyoDto>();
            foreach (var vm in vmList)
            {
                dtl.Add(GetDto(vm));
            }

            return dtl;
        }
        /// <summary>
        /// その他日程事業・保健指導事業マスタ
        /// </summary>
        private static tm_kksonotasidojigyoDto GetDto(YoyakuSidoJigyoRowSaveVM vm)
        {
            var dto = new tm_kksonotasidojigyoDto();
            dto.jigyocd = vm.jigyocd;                                   //その他日程事業・保健指導事業コード
            dto.jigyonm = vm.jigyonm;                                   //その他日程事業・保健指導事業名
            dto.gyomukbn = DaSelectorService.GetCd(vm.gyomukbncdnm);    //業務区分
            dto.yoyakuriyoflg = vm.yoyakuriyoflg;                       //予約利用フラグ
            dto.homonriyoflg = vm.homonriyoflg;                         //訪問利用フラグ
            dto.sodanriyoflg = vm.sodanriyoflg;                         //相談利用フラグ
            dto.syudanriyoflg = vm.syudanriyoflg;                       //集団利用フラグ
            dto.stopflg = vm.stopflg;                                   //使用停止フラグ           

            return dto;
        }
        /// <summary>
        /// 成人健（検）診予約日程事業サブマスタ
        /// </summary>
        private static tm_shyoyakujigyo_subDto GetDto(KensinYoyakuDetailRowSaveVM vm, int nendo, string jigyocd)
        {
            var dto = new tm_shyoyakujigyo_subDto();
            dto.nendo = nendo;                                      //年度
            dto.jigyocd = jigyocd;                                  //成人健（検）診予約日程事業コード
            dto.kensin_jigyocd = vm.jigyocd;                        //成人健（検）診事業コード
            if (string.IsNullOrEmpty(vm.kensahohocd))
            {
                dto.kensahohocd = AWSH00301G.Service.KENSAHOHOCD; 　//成人健（検）診検査方法コード設定されていない場合
            }
            else
            {
                dto.kensahohocd = vm.kensahohocd;                   //成人健（検）診検査方法コード
            }
            dto.optionflg = vm.optionflg;                           //オプションフラグ                 

            return dto;
        }
        /// <summary>
        /// 汎用メインマスタ
        /// </summary>
        private static tm_afhanyo_mainDto? GetDto(SaveKensinJigyoDetailRequest req, string maincd, Enum検診関連汎用マスタ区分 kbn)
        {
            tm_afhanyo_mainDto? dto = null;
            switch (kbn)
            {
                case Enum検診関連汎用マスタ区分.検査方法:
                    if (req.hohoinfo.kensahoho_setflg)
                    {
                        dto = GetDto(maincd, CmLogicUtil.GetHanyoSubcd(kbn, req.jigyocd!));
                        dto.hanyosubcdnm = req.hohoinfo.kensahoho_subcdnm;                  //検査方法サブコード名
                    }
                    break;
                case Enum検診関連汎用マスタ区分.予約分類:
                    if (req.hohoinfo.kensahoho_setflg)
                    {
                        dto = GetDto(maincd, CmLogicUtil.GetHanyoSubcd(kbn, req.jigyocd!));
                        dto.hanyosubcdnm = req.yoyakuinfo.yoyakubunrui_subcdnm;             //予約分類サブコード名
                    }
                    break;
                case Enum検診関連汎用マスタ区分.グループ2:
                    if (req.freeinfo.kekkalist.Count > 0)
                    {
                        dto = GetDto(maincd, CmLogicUtil.GetHanyoSubcd(kbn, req.jigyocd!));
                        dto.hanyosubcdnm = req.freeinfo.groupid2_subcdnm;                   //グループ2サブコード名
                    }
                    break;
                default:
                    throw new Exception("Enum検診関連汎用マスタ区分 error");
            }

            return dto;
        }
        /// <summary>
        /// 汎用メインマスタ：共通
        /// </summary>
        private static tm_afhanyo_mainDto GetDto(string maincd, int subcd)
        {
            var dto = new tm_afhanyo_mainDto();
            dto.hanyomaincd = maincd;   //汎用メインコード
            dto.hanyosubcd = subcd;     //汎用サブコード
            dto.iflg = false;           //INSERT可能フラグ 
            dto.uflg = false;           //UPDATE可能フラグ 
            dto.dflg = false;           //DELETE可能フラグ 

            return dto;
        }
        /// <summary>
        /// 汎用マスタ
        /// </summary>
        private static List<tm_afhanyoDto> GetDtl(SaveKensinJigyoDetailRequest req, string maincd, Enum検診関連汎用マスタ区分 kbn)
        {
            var list = new List<tm_afhanyoDto>();
            switch (kbn)
            {
                case Enum検診関連汎用マスタ区分.検査方法:
                    if (req.hohoinfo.kensahoho_setflg)
                    {
                        list.AddRange(GetHohoDtl(req.hohoinfo.kekkalist, maincd, CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, req.jigyocd!)));
                    }
                    break;
                case Enum検診関連汎用マスタ区分.予約分類:
                    if (req.hohoinfo.kensahoho_setflg)
                    {
                        list.AddRange(GetYoyakuDtl(req.yoyakuinfo.kekkalist, maincd, CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.予約分類, req.jigyocd!)));
                    }
                    break;
                case Enum検診関連汎用マスタ区分.グループ2:
                    if (req.freeinfo.kekkalist.Count > 0)
                    {
                        list.AddRange(GetFreeDtl(req.freeinfo.kekkalist, maincd, CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.グループ2, req.jigyocd!)));
                    }
                    break;
                default:
                    throw new Exception("Enum検診関連汎用マスタ区分 error");
            }

            return list;
        }
        /// <summary>
        /// 汎用マスタ：検査方法
        /// </summary>
        private static List<tm_afhanyoDto> GetHohoDtl(List<KensinDetailHohoRowVM> vmList, string maincd, int subcd)
        {
            var list = new List<tm_afhanyoDto>();
            foreach (var vm in vmList)
            {
                var dto = new tm_afhanyoDto();
                dto.hanyomaincd = maincd;           //汎用メインコード
                dto.hanyosubcd = subcd;             //汎用サブコード
                dto.hanyocd = vm.kensahohocd;       //検査方法コード
                dto.nm = vm.kensahohonm;            //検査方法名
                dto.shortnm = vm.kensahohoshortnm;  //検査方法略称
                list.Add(dto);
            }

            return list;
        }
        /// <summary>
        /// 汎用マスタ：予約分類
        /// </summary>
        private static List<tm_afhanyoDto> GetYoyakuDtl(List<KensinDetailYoyakuRowVM> vmList, string maincd, int subcd)
        {
            var list = new List<tm_afhanyoDto>();
            foreach (var vm in vmList)
            {
                var dto = new tm_afhanyoDto();
                dto.hanyomaincd = maincd;                               //汎用メインコード
                dto.hanyosubcd = subcd;                                 //汎用サブコード
                dto.hanyocd = vm.yoyakubunrui;                          //予約分類コード
                dto.nm = vm.yoyakubunruinm;                             //予約分類名
                dto.shortnm = vm.yoyakubunruishortnm;                   //予約分類表示名
                dto.hanyokbn1 = ListToCommaStr(vm.yoyakubunruilist);    //検査方法コード一覧
                list.Add(dto);
            }

            return list;
        }
        /// <summary>
        /// 汎用マスタ：グループ2
        /// </summary>
        private static List<tm_afhanyoDto> GetFreeDtl(List<DaSelectorModel> vmList, string maincd, int subcd)
        {
            var list = new List<tm_afhanyoDto>();
            foreach (var vm in vmList)
            {
                var dto = new tm_afhanyoDto();
                dto.hanyomaincd = maincd;   //汎用メインコード
                dto.hanyosubcd = subcd;     //汎用サブコード
                dto.hanyocd = vm.value;     //汎用コード
                dto.nm = vm.label;          //名称
                list.Add(dto);
            }

            return list;
        }
        /// <summary>
        /// 詳細条件設定テーブル
        /// </summary>
        private static List<tt_affilterDto> GetDtl(string kinoid, string maincd, int subcd, bool seikenflg, bool hohoflg)
        {
            var dtl = new List<tt_affilterDto>();
            //一次実施日
            var dto1 = new tt_affilterDto();
            dto1.kinoid = kinoid;                                                               //機能ID
            dto1.jyokbn = Enum詳細検索条件区分.独自;                                            //条件区分
            dto1.jyoseq = 1;                                                                    //条件シーケンス
            dto1.hyojinm = $"{BRACKET_START}{EnumKensinKbn.一次}{BRACKET_END}実施日";           //詳細条件表示名
            dto1.ctrltype = Enumコントローラータイプ.通用項目;                                  //コントローラータイプ
            dto1.hyojiflg = false;                                                              //表示フラグ
            dto1.rangeflg = true;                                                               //範囲フラグ
            dto1.sethanyokbn1 = EnumToStr(Enum項目区分.日付);                                   //設定用汎用区分1
            dto1.getkbn = Enum取得元区分.テーブル固定項目;                                      //検索対象データ取得区分
            dto1.tablenm1 = KensinView.TABLE_NAME;                                              //テーブル物理名1
            dto1.komokunm1 = KensinView.jissiymd1;                                              //項目物理名1
            dto1.sort = 1;                                                                       //並び順
            dtl.Add(dto1);

            if (hohoflg)
            {
                //一次検査方法
                dtl.Add(GetDto(kinoid, maincd, subcd));
            }

            if (seikenflg)
            {
                //精密実施日
                dtl.Add(GetDto(kinoid));
            }

            return dtl;
        }
        /// <summary>
        /// 詳細条件設定テーブル
        /// </summary>
        private static List<tt_affilterDto> GetDtl(List<tt_affilterDto> dtl, string kinoid, string maincd, int subcd,
                                                    bool seikenflg, bool hohoflg)
        {
            var list = new List<tt_affilterDto>();
            if (hohoflg)
            {
                //一次検査方法
                var dto = dtl.Find(e => e.jyoseq == 2);
                if (dto != null)
                {
                    list.Add(dto);
                }
                else
                {
                    list.Add(GetDto(kinoid, maincd, subcd));
                }
            }

            if (seikenflg)
            {
                //精密実施日
                var dto = dtl.Find(e => e.jyoseq == 3);
                if (dto != null)
                {
                    list.Add(dto);
                }
                else
                {
                    list.Add(GetDto(kinoid));
                }
            }

            return list;
        }
        /// <summary>
        /// 詳細条件設定テーブル(一次検査方法)
        /// </summary>
        private static tt_affilterDto GetDto(string kinoid, string maincd, int subcd)
        {
            //一次検査方法
            var dto = new tt_affilterDto();
            dto.kinoid = kinoid;                                                           //機能ID
            dto.jyokbn = Enum詳細検索条件区分.独自;                                        //条件区分
            dto.jyoseq = 2;                                                                //条件シーケンス
            dto.hyojinm = $"{BRACKET_START}{EnumKensinKbn.一次}{BRACKET_END}検査方法";     //詳細条件表示名
            dto.ctrltype = Enumコントローラータイプ.一覧選択;                              //コントローラータイプ
            dto.hyojiflg = false;                                                          //表示フラグ
            dto.rangeflg = false;                                                          //範囲フラグ
            dto.sethanyokbn1 = EnumToStr(Enumマスタ区分.汎用マスタ);                       //設定用汎用区分1（検査方法は汎用マスタから値を取得）
            dto.sethanyokbn2 = maincd;                                                     //設定用汎用区分2
            dto.sethanyokbn3 = subcd.ToString();                                           //設定用汎用区分3
            dto.getkbn = Enum取得元区分.テーブル固定項目;                                  //検索対象データ取得区分
            dto.tablenm1 = KensinView.TABLE_NAME;                                          //テーブル物理名1
            dto.komokunm1 = KensinView.kensahoho1;                                         //項目物理名1
            dto.sort = 2;                                                                  //並び順

            return dto;
        }
        /// <summary>
        /// 詳細条件設定テーブル(精密実施日)
        /// </summary>
        private static tt_affilterDto GetDto(string kinoid)
        {
            //精密実施日
            var dto = new tt_affilterDto();
            dto.kinoid = kinoid;                                                           //機能ID
            dto.jyokbn = Enum詳細検索条件区分.独自;                                        //条件区分
            dto.jyoseq = 3;                                                                //条件シーケンス
            dto.hyojinm = $"{BRACKET_START}{EnumKensinKbn.精密}{BRACKET_END}実施日";       //詳細条件表示名
            dto.ctrltype = Enumコントローラータイプ.通用項目;                              //コントローラータイプ
            dto.hyojiflg = false;                                                          //表示フラグ
            dto.rangeflg = true;                                                           //範囲フラグ
            dto.sethanyokbn1 = EnumToStr(Enum項目区分.日付);                               //設定用汎用区分1
            dto.getkbn = Enum取得元区分.テーブル固定項目;                                  //検索対象データ取得区分
            dto.tablenm1 = KensinView.TABLE_NAME;                                          //テーブル物理名1
            dto.komokunm1 = KensinView.jissiymd2;                                          //項目物理名1
            dto.sort = 3;                                                                  //並び順

            return dto;
        }
    }
}