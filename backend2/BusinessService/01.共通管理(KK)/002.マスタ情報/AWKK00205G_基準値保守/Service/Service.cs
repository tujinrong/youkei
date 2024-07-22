// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 基準値保守
// 　　　　　　サービス処理
// 作成日　　: 2024.07.16
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00205G
{
    [DisplayName("基準値保守")]
    public class Service : CmServiceBase
    {
        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(業務)
                res.selectorlist1 = DaNameService.GetSelectorList(db, EnumNmKbn.基準値業務区分, Enum名称区分.名称);

                //switch「成人保健、母子保健、予防接種」三つパターン仕様未定
                //ドロップダウンリスト(事業)
                res.selectorlist2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, true,
                    EnumToStr(EnumHanyoKbn.検診種別));

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(一覧画面)")]
        public SearchResponse SearchList(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var gyomukbn = DaSelectorService.GetCd(req.gyomukbn);             //業務
                var kijunjigyocd = DaSelectorService.GetCd(req.kijunjigyo);       //基準値事業コード
                var kbn = CmLogicUtil.GetKijunGyomukbn(gyomukbn);

                //基準値マスタ
                var dtl = db.tm_kkkijun.SELECT.WHERE.ByKey(gyomukbn, kijunjigyocd).GetDtoList().
                            OrderBy(e => e.itemcd).ThenBy(e => CInt(e.sex)).ThenBy(e => e.agef).ThenBy(e => e.aget).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //「成人保健、母子保健、予防接種」三つパターン仕様未定
                var freeitemDic = new Dictionary<string, ItemVM>();
                switch (kbn)
                {
                    case Enum基準値業務区分.成人保健:
                        //成人保健検診結果（フリー）項目コントロールマスタ
                        freeitemDic = GetFreeItemDic(db, kijunjigyocd);
                        //基準値保守情報一覧
                        res.kekkalist = Wraper.GetVMList(db, dtl, kijunjigyocd, freeitemDic);
                        break;

                    case Enum基準値業務区分.母子保健:
                        //todo cncliu
                        break;
                    case Enum基準値業務区分.予防接種:
                        //todo cncliu
                        break;
                    default:
                        throw new Exception("Enumコントローラータイプ error");
                }

                return res;
            });
        }

        [DisplayName("初期化処理(詳細画面)")]
        public InitDetailResponse InitDetail(InitDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitDetailResponse();

                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                var kkkijunDto = db.tm_kkkijun.GetDtoByKey(req.gyomukbn, req.kijunjigyocd, req.itemcd!, CInt(req.edano));

                var gyomukbnnm = DaNameService.GetName(db, EnumNmKbn.基準値業務区分, req.gyomukbn);
                var kijunjigyonm = DaHanyoService.GetCdNm(db, EnumHanyoKbn.検診種別,
                                                              Enum名称区分.名称, req.kijunjigyocd);
                res.gyomukbnnm = gyomukbnnm;                              //業務
                res.kijunjigyonm = kijunjigyonm;                          //事業
                //ドロップダウンリスト(性別)
                res.selectorlist2 = DaNameService.GetSelectorList(db, EnumNmKbn.性別_システム, Enum名称区分.名称);

                //初期化処理データをセットする
                if (req.editkbn == Enum編集区分.新規)
                {

                    //新規モードの場合
                    res.selectorlist1 = Wraper.GetVMList(db, req.kijunjigyocd);                    //ドロップダウンリスト(項目名称)
                }
                else
                {
                    //修正モードの場合
                    var kbn = CmLogicUtil.GetKijunGyomukbn(req.gyomukbn);  //Enum基準値業務区分取得
                    switch (kbn)
                    {
                        case Enum基準値業務区分.成人保健:
                            //成人保健検診結果（フリー）項目コントロールマスタ
                            var shfreeitemDto = DaFreeItemService.GetKensinItemInfo(db, req.kijunjigyocd, CStr(req.itemcd));
                            if (shfreeitemDto != null)
                            {
                                res.freemstinfo = new FreeMstInfoVM();
                                if (EnumToStr(shfreeitemDto!.inputtype) == EnumToStr(Enum入力タイプ.コード_名称マスタ)
                                                || EnumToStr(shfreeitemDto!.inputtype) == EnumToStr(Enum入力タイプ.コード_汎用マスタ))
                                {

                                    //ドロップダウンリスト(基準値（コード）、注意値（コード）、異常値（コード）)
                                    res.freemstinfo.selectorlist3 = GetCodeList(db, shfreeitemDto.inputtype,
                                                                                     CStr(shfreeitemDto.codejoken1), CStr(shfreeitemDto.codejoken2),
                                                                                     CStr(shfreeitemDto.codejoken3), req.kijunjigyocd, kbn);
                                }
                                res.itemnm = shfreeitemDto.itemnm;
                                res.saveinfo = Wraper.GetVM(db, kkkijunDto, shfreeitemDto);
                            }

                            break;
                        case Enum基準値業務区分.母子保健:
                            //todo cncliu
                            break;
                        case Enum基準値業務区分.予防接種:
                            //todo cncliu
                            break;
                        default:
                            throw new Exception("Enumコントローラータイプ error");
                    }
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("項目名称変更処理(詳細画面)")]
        public GetFreeMstInfoResponse GetFreeMstInfo(GetFreeMstInfoRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new GetFreeMstInfoResponse();
                var gyomukbn = req.gyomukbncd;                                    //業務
                var kijunjigyocd = req.kijunjigyocd;                              //基準値事業コード
                var kbn = CmLogicUtil.GetKijunGyomukbn(gyomukbn);                 //Enum基準値業務区分取得
                var itemcd = DaSelectorService.GetCd(req.itemcd);

                switch (kbn)
                {
                    case Enum基準値業務区分.成人保健:
                        //成人保健検診結果（フリー）項目コントロールマスタ
                        var shfreeitemDto = DaFreeItemService.GetKensinItemInfo(db, req.kijunjigyocd, CStr(itemcd));
                        //-------------------------------------------------------------
                        //２.データ加工処理
                        //-------------------------------------------------------------
                        //項目名称変更処理情報
                        if (shfreeitemDto != null)
                        {
                            res = GetKijunnInfo(db, shfreeitemDto, res, gyomukbn, kijunjigyocd);
                        }

                        break;
                    case Enum基準値業務区分.母子保健:
                        //todo cncliu
                        break;
                    case Enum基準値業務区分.予防接種:
                        //todo cncliu
                        break;
                    default:
                        throw new Exception("Enumコントローラータイプ error");
                }

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
                //１.チェック処理(事前)
                //-------------------------------------------------------------
                //業務区分
                var gyomukbn = req.gyomukbn;
                //基準値事業コード
                var kijunjigyocd = req.kijunjigyocd;
                //項目コード
                var itemcd = CStr(req.itemcd);
                //枝番
                var edano = CInt(req.edano);

                //新規登録際に自動採番MAX+1
                if (CInt(req.edano) <= 0)
                {
                    edano = db.tm_kkkijun.SELECT.WHERE.ByKey(gyomukbn, kijunjigyocd,
                                                itemcd).GetMax<int>(nameof(tm_kkkijunDto.edano)) + 1;
                }

                var flg = db.tm_kkkijun.SELECT.WHERE.ByKey(gyomukbn, kijunjigyocd, itemcd, edano).Exists();
                if (req.editkbn == Enum編集区分.新規 && flg)
                {
                    res.SetServiceError(EnumMessage.E002003, "項目コード");
                    //異常返す
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                var dto = new tm_kkkijunDto();    //基準値保守情報マスタ
                //更新の場合
                if (req.editkbn == Enum編集区分.変更)
                {
                    dto = db.tm_kkkijun.GetDtoByKey(gyomukbn, kijunjigyocd, itemcd, edano);
                }

                //同一キー項目（業務、事業コード、事業項目）の重複チェック
                var dtl = db.tm_kkkijun.SELECT.WHERE.ByKey(gyomukbn, kijunjigyocd, itemcd).GetDtoList().FindAll(e => e.edano != edano);
                var repflg = RepeatedCheck(req, dtl);
                if (repflg)
                {
                    res.SetServiceError(EnumMessage.E001008, "性別、年齢、有効期間");
                    //異常返す
                    return res;
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //基準値マスタ
                dto = Converter.GetDto(dto, gyomukbn, kijunjigyocd, itemcd, edano, req.saveinfo);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //基準値マスタ
                    db.tm_kkkijun.INSERT.Execute(dto);
                }
                //更新の場合
                else
                {
                    //基準値マスタ
                    db.tm_kkkijun.UpdateDto(dto, req.saveinfo.upddttm!.Value);
                }

                //キャシュークリア
                DaSelectorService.ClearCache();

                //正常返し
                return res;
            });
        }

        [DisplayName("削除処理(詳細画面)")]
        public DaResponseBase Delete(DeleteRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //業務区分
                var gyomukbn = req.gyomukbn;
                //基準値事業コード
                var kijunjigyocd = req.kijunjigyocd;
                //項目コード
                var itemcd = req.itemcd;
                //枝番
                var edano = req.edano;

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------
                db.tm_kkkijun.DELETE.WHERE.ByKey(gyomukbn, kijunjigyocd, 
                                                   itemcd, edano).SetLock(req.upddttm).Execute();

                //正常返し
                return new DaResponseBase();
            });
        }

        /// <summary>
        /// 年齢、性別、有効期間すべて重複範囲がある場合エラーとする
        /// </summary>
        private bool RepeatedCheck(SaveRequest req, List<tm_kkkijunDto> dtl)
        {
            var sexflg = false;
            var ageflg = false;
            var yukoflg = false;
            foreach(var dto in dtl)
            {
                //性別重複判断
                if ((string.IsNullOrEmpty(req.saveinfo.sex)) ||
                    (!string.IsNullOrEmpty(EnumToStr(dto.sex)) && req.saveinfo.sex == EnumToStr(dto.sex)))
                {
                    sexflg = true;
                }

                //年齢重複判断
                var agef = CInt(req.saveinfo.agef);
                var aget = CInt(req.saveinfo.aget);
                if ((agef <= 0 && aget <= 0) || (agef <= CInt(dto.aget) && aget >= CInt(dto.agef)))
                {
                    ageflg = true;
                }

                //有効年月日重複判断
                var yukoymdf = req.saveinfo.yukoymdf;
                var yukoymdt = req.saveinfo.yukoymdt;
                if (!string.IsNullOrEmpty(dto.yukoymdf) && yukoymdf <= DateTime.Parse(dto.yukoymdf)
                    && !string.IsNullOrEmpty(dto.yukoymdt) && yukoymdt >= DateTime.Parse(dto.yukoymdt))
                {
                    yukoflg = true;
                }

                if (sexflg && ageflg && yukoflg)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 項目名称変更処理情報取得
        /// </summary>
        private GetFreeMstInfoResponse GetKijunnInfo(DaDbContext db, tm_shfreeitemDto shfreeitemDto,
                                                            GetFreeMstInfoResponse res, string gyomukbn, string kijunjigyocd)
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            var kbn = CmLogicUtil.GetKijunGyomukbn(gyomukbn);  //Enum基準値業務区分取得
            res.freemstinfo = new FreeMstInfoVM();

            if (EnumToStr(shfreeitemDto!.inputtype) == EnumToStr(Enum入力タイプ.コード_名称マスタ)
                    || EnumToStr(shfreeitemDto!.inputtype) == EnumToStr(Enum入力タイプ.コード_汎用マスタ))
            {
                res.freemstinfo.numcdflg = false;                                                              //入力タイプフラグ

                switch (kbn)
                {
                    case Enum基準値業務区分.成人保健:
                        //ドロップダウンリスト(基準値（コード）、注意値（コード）、異常値（コード）)
                        res.freemstinfo.selectorlist3 = GetCodeList(db, shfreeitemDto.inputtype, CStr(shfreeitemDto.codejoken1),
                                                                        CStr(shfreeitemDto.codejoken2), CStr(shfreeitemDto.codejoken3), kijunjigyocd, kbn);

                        break;
                    case Enum基準値業務区分.母子保健:
                        //todo cncliu
                        break;
                    case Enum基準値業務区分.予防接種:
                        //todo cncliu
                        break;
                    default:
                        throw new Exception("Enumコントローラータイプ error");
                }
            }
            else
            {
                res.freemstinfo.numcdflg = true;                                                               //入力タイプフラグ
            }

            res.freemstinfo.tani = CStr(shfreeitemDto?.tani);                                                  //単位
            res.freemstinfo.inputflgstr = CStr(shfreeitemDto?.inputflg);                                       //入力フラグ
            res.freemstinfo.hyojinendof = CStr(shfreeitemDto?.hyojinendof);     　　　　　　　　　　　　　　　 //表示年度（開始） 
            res.freemstinfo.hyojinendot = CStr(shfreeitemDto?.hyojinendot);     　　　　　　　　　　　　　　　 //表示年度（終了） 

            //正常返し
            return res;
        }

        /// <summary>
        /// 基準値（コード）、注意値（コード）、異常値（コード）ドロップダウンリスト取得
        /// </summary>
        private List<DaSelectorModel> GetCodeList(DaDbContext db, Enum入力タイプ inputtype, string codejoken1,
                                                                  string codejoken2, string codejoken3,
                                                                  string kijunjigyocd, Enum基準値業務区分 kbn)
        {
            //todo cncliu 成人保健、母子保健、予防接種 三つケース追加 仕様未定がある
            var list = new List<DaSelectorModel>();
            switch (kbn)
            {
                case Enum基準値業務区分.成人保健:
                    var kinoid = db.tm_afkino.SELECT.WHERE.ByFilter($@"{nameof(tm_afkinoDto.hanyokbn)} = @{nameof(tm_afkinoDto.hanyokbn)} and 
                                                            {nameof(tm_afkinoDto.kinoid)} like '{AWKK00801G.Service.AWSH001}%'", kijunjigyocd).GetDto().kinoid;
                    list = CmLogicUtil.GetFreeItemCdList(db, Enum名称区分.名称, Enumフリーマスタ分類.成人,
                                                            inputtype, codejoken1, codejoken2, codejoken3,
                                                            kinoid, null);
                    break;
                case Enum基準値業務区分.母子保健:
                    //todo cncliu
                    break;
                case Enum基準値業務区分.予防接種:
                    //todo cncliu
                    break;
                default:
                    throw new Exception("Enumコントローラータイプ error");
            }

            return list;
        }

        /// <summary>
        /// 一覧画面フリー項目取得
        /// </summary>
        private Dictionary<string, ItemVM> GetFreeItemDic(DaDbContext db, string kijunjigyocd)
        {
            var freeitemDic = new Dictionary<string, ItemVM>();
            var shfreeitemDto = new tm_shfreeitemDto();
            var dtlshfreeitem = DaFreeItemService.GetKensinList(db, kijunjigyocd);
            foreach (var d in dtlshfreeitem)
            {
                var itemvm = new ItemVM();
                itemvm.itemnm = d.itemnm;
                itemvm.tani = CStr(d.tani);
                freeitemDic.Add(d.itemcd, itemvm);
            }

            return freeitemDic;
        }
    }
}