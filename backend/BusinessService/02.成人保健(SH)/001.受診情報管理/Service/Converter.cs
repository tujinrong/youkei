// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検診結果管理
//             DBデータへ変換処理
// 作成日　　: 2023.07.04
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWSH001
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得(詳細画面)
        /// </summary>
        public static List<AiKeyValue> GetParameters(InitDetailRequest req, string jigyocd)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(tt_shkensinDto.jigyocd)}_in", jigyocd),     //事業コード
                new($"{nameof(tt_shkensinDto.atenano)}_in", req.atenano), //宛名番号
                new($"{nameof(tt_shkensinDto.nendo)}_in", req.nendo)      //検診年度
            };
            return paras;
        }

        /// <summary>
        /// データ操作区分取得
        /// </summary>
        public static EnumActionType? GetKBN(DateTime? upddttm, bool? editflg)
        {
            //下記以外の場合、修正なし
            EnumActionType? kbn = null;
            if (upddttm != null)
            {
                if (editflg == true)
                {
                    //更新日あり、編集フラグ☑=>更新
                    kbn = EnumActionType.Update;
                }
                else if (editflg == false)
                {
                    //更新日あり、編集フラグ☐=>削除
                    kbn = EnumActionType.Delete;
                }
            }
            else if (editflg == true)
            {
                //更新日なし、編集フラグ☑=>新規
                kbn = EnumActionType.Insert;
            }

            return kbn;
        }

        /// <summary>
        /// キーリスト取得
        /// </summary>
        public static List<object[]> GetKeyList(string jigyocd, string atenano, int nendo, List<KsItemUpdVM> itemlist, EnumActionType? kbn, int? kensinkaisu)
        {
            var list = new List<object[]>();
            switch (kbn)
            {
                //新規の場合
                case EnumActionType.Insert:
                //更新の場合
                case EnumActionType.Update:
                    foreach (var item in itemlist)
                    {
                        //通常項目(通年項目ではない)の場合
                        if (item.kensinkaisu != Service.TSUNEN)
                        {
                            list.Add(new object[] { jigyocd, atenano, nendo, kensinkaisu!, item.itemcd });
                        }
                        //通年項目の場合
                        else
                        {
                            list.Add(new object[] { jigyocd, atenano, Service.TSUNEN, Service.TSUNEN, item.itemcd });
                        }
                    }
                    break;
                //削除の場合
                case EnumActionType.Delete:
                    foreach (var item in itemlist)
                    {
                        //通常項目(通年項目ではない)の場合：通年項目削除不可
                        if (item.kensinkaisu != Service.TSUNEN)
                        {
                            list.Add(new object[] { jigyocd, atenano, nendo, kensinkaisu!, item.itemcd });
                        }
                    }
                    break;
                default: break;
            }
            return list;
        }

        /// <summary>
        /// 成人保健一次検診結果（固定項目）テーブル
        /// </summary>
        public static tt_shkensinDto GetDto(tt_shkensinDto dto, string jigyocd, int kensinkaisu, SaveRequest req)
        {
            dto.jigyocd = jigyocd;                                                      //事業コード
            dto.atenano = req.atenano;                                                  //宛名番号
            dto.kensinkaisu = kensinkaisu;                                              //検診回数
            dto.nendo = req.nendo;                                                      //実施年度
            dto.jissiymd = FormatYMD(req.kekka.jissiymd1);                              //実施日
            dto.jissiage = req.kekka.jissiage1!;                                        //実施年齢
            dto.kensahohocd = ToNStr(DaSelectorService.GetCd(req.kekka.kensahoho1));    //検査方法
            return dto;
        }

        /// <summary>
        /// 成人保健精密検査結果（固定項目）テーブル
        /// </summary>
        public static tt_shseikenDto GetDto(tt_shseikenDto dto, string jigyocd, int kensinkaisu, SaveRequest req)
        {
            dto.jigyocd = jigyocd;                                                  //事業コード
            dto.atenano = req.atenano;                                              //宛名番号
            dto.kensinkaisu = kensinkaisu;                                          //検診回数
            dto.nendo = req.nendo;                                                  //実施年度
            dto.jissiymd = NFormatYMD(req.kekka.jissiymd2);                         //実施日
            dto.jissiage = req.kekka.jissiage2;                                     //実施年齢
            return dto;
        }

        /// <summary>
        /// 成人保健検診結果（フリー項目）テーブル
        /// </summary>
        public static List<tt_shfreeDto> GetDtl(DaDbContext db, List<object[]> keyList, List<KsItemUpdVM> items, int nendo, string atenano, string jigyocd, int kensinkaisu, EnumKensinKbn kbn)
        {
            var keys = keyList.Select(e => e[4].ToString()).ToList();
            return items.Where(x => x.value != null && keys.Contains(x.itemcd)).Select(x => GetDto(db, x, nendo, atenano, jigyocd, kensinkaisu, kbn)).ToList();
        }

        /// <summary>
        /// 成人保健一次検診結果（固定項目）テーブル：削除処理
        /// </summary>
        public static List<tt_shkensinDto> GetDtl(List<tt_shkensinDto> dtl, int kensinkaisu)
        {
            if (dtl.Count > 1)
            {
                dtl = dtl.Where(e => e.kensinkaisu != kensinkaisu).ToList();
                foreach (var dto in dtl)
                {
                    dto.kensinkaisu -= 1;
                }
            }
            else
            {
                return new List<tt_shkensinDto>();
            }
            return dtl;
        }
        /// <summary>
        /// 成人保健精密検査結果（固定項目）テーブル：削除処理
        /// </summary>
        public static List<tt_shseikenDto> GetDtl(List<tt_shseikenDto> dtl, int kensinkaisu)
        {
            if (dtl.Count > 1)
            {
                dtl = dtl.Where(e => e.kensinkaisu != kensinkaisu).ToList();
                foreach (var dto in dtl)
                {
                    dto.kensinkaisu -= 1;
                }
            }
            else
            {
                return new List<tt_shseikenDto>();
            }
            return dtl;
        }
        /// <summary>
        /// 成人保健検診結果（フリー項目）テーブル：削除処理
        /// </summary>
        public static List<tt_shfreeDto> GetDtl(List<tt_shfreeDto> dtl, int kensinkaisu)
        {
            var keyList = dtl.Select(e => e.kensinkaisu).Distinct().ToList();
            if (keyList.Count > 1)
            {
                dtl = dtl.Where(e => e.kensinkaisu != kensinkaisu).ToList();
                foreach (var dto in dtl)
                {
                    dto.kensinkaisu -= 1;
                }
            }
            else
            {
                return new List<tt_shfreeDto>();
            }
            return dtl;
        }

        /// <summary>
        /// 成人保健検診結果（フリー項目）テーブル
        /// </summary>
        private static tt_shfreeDto GetDto(DaDbContext db, KsItemUpdVM vm, int nendo, string atenano, string jigyocd, int kensinkaisu, EnumKensinKbn kbn)
        {
            var dto = new tt_shfreeDto();
            var tsunenflg = vm.kensinkaisu == Service.TSUNEN;
            dto.nendo = tsunenflg ? Service.TSUNEN : nendo;                                     //実施年度
            dto.jigyocd = jigyocd;                                                              //事業コード
            dto.itemcd = vm.itemcd;                                                             //項目コード
            dto.atenano = atenano;                                                              //宛名番号
            dto.kensinkaisu = tsunenflg ? Service.TSUNEN : kensinkaisu;                         //検診回数
            dto.kensinkbn = kbn;                                                                //区分
            dto.fusyoflg = vm.fusyoflg;                                                         //不詳フラグ
            dto.numvalue = CNDbl(CmLogicUtil.GetFreeValues(db, vm.inputtypekbn, vm.value)[0]);  //数値管理項目
            dto.strvalue = CNStr(CmLogicUtil.GetFreeValues(db, vm.inputtypekbn, vm.value)[1]);  //文字管理項目
            return dto;
        }
    }
}