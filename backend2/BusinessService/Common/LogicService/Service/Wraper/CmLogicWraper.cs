// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ロジック共通仕様処理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.07.04
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.Common
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 支所取得
        /// </summary>
        public static CmSisyoVM GetSisyoVM(tm_afhanyoDto dto)
        {
            var vm = new CmSisyoVM();
            vm.sisyocd = dto.hanyocd;   //支所コード
            vm.sisyonm = dto.nm;        //支所名
            return vm;
        }

        /// <summary>
        /// 個人基本情報(ヘッダー部：共通)
        /// </summary>
        public static CmHeaderBaseVM GetHeaderBaseVM(DaDbContext db, CmHeaderBaseVM vm, tt_afatenaDto dto)
        {
            vm.name = dto.simei_yusen;                                                                  //氏名
            vm.kname = CStr(dto.simei_kana_yusen);                                                      //カナ氏名
            vm.sex = DaNameService.GetName(db, EnumNmKbn.性別_システム共有, dto.sex);                   //性別
            vm.juminkbn = DaNameService.GetName(db, EnumNmKbn.住民区分, dto.juminkbn);                  //住民区分
            vm.bymd = CmLogicUtil.GetYMDStr(dto.bymd_fusyoflg, dto.bymd, dto.bymd_fusyohyoki);          //生年月日

            return vm;
        }

        /// <summary>
        /// 個人基本情報(ヘッダー部：共通)
        /// </summary>
        public static CommonBarHeaderBaseVM GetHeaderVM(DaDbContext db, CommonBarHeaderBaseVM vm, tt_afatenaDto dto)
        {
            vm = (CommonBarHeaderBaseVM)GetHeaderBaseVM(db, vm, dto);
            vm.age = CmLogicUtil.GetAgeStr(dto.bymd_fusyoflg, dto.bymd, DaUtil.Today);                  //年齢
            vm.agekijunymd = FormatWaKjYMD(DaUtil.Today);                                               //年齡計算基準日

            return vm;
        }

        /// <summary>
        /// 個人基本情報(ヘッダー部：共通バー)
        /// </summary>
        public static CommonBarHeaderBase2VM GetHeaderVM(DaDbContext db, CommonBarHeaderBase2VM vm, tt_afatenaDto dto, bool alertviewflg)
        {
            vm = (CommonBarHeaderBase2VM)GetHeaderVM(db, vm, dto);

            vm.keikoku = CmLogicUtil.GetKeikoku(db, dto.siensotikbn, alertviewflg);     //警告内容
            return vm;
        }

        /// <summary>
        /// 個人基本情報(ヘッダー部：共通バー)
        /// </summary>
        public static CommonBarHeaderBase3VM GetHeaderVM(DaDbContext db, CommonBarHeaderBase3VM vm, tt_afatenaDto dto, bool alertviewflg, bool adrsflg)
        {
            vm = (CommonBarHeaderBase3VM)GetHeaderVM(db, vm, dto, alertviewflg);

            vm.adrs = CmLogicUtil.GetAdrs(dto.jutokbn, dto.adrs1, dto.adrs2, adrsflg);  //住所
            return vm;
        }

        /// <summary>
        /// 個人基本情報(ヘッダー部：画面)
        /// </summary>
        public static GamenHeaderBaseVM GetHeaderVM(DaDbContext db, GamenHeaderBaseVM vm, tt_afatenaDto dto, bool personalflg, string publickey)
        {
            vm = (GamenHeaderBaseVM)GetHeaderVM(db, vm, dto);

            vm.personalno = (personalflg && !string.IsNullOrEmpty(dto.personalno)) ?
                DaEncryptUtil.AesDecryptAndRsaEncrypt(dto.personalno, publickey) : string.Empty;        //個人番号(暗号化)

            return vm;
        }

        /// <summary>
        /// 個人基本情報(ヘッダー部：画面)
        /// </summary>
        public static GamenHeaderBase2VM GetHeaderVM(DaDbContext db, GamenHeaderBase2VM vm, tt_afatenaDto dto, bool personalflg, string publickey, bool alertviewflg, bool adrsflg)
        {
            vm = (GamenHeaderBase2VM)GetHeaderVM(db, vm, dto, personalflg, publickey);

            vm.adrs = CmLogicUtil.GetAdrs(dto.jutokbn, dto.adrs1, dto.adrs2, adrsflg);  //住所
            vm.keikoku = CmLogicUtil.GetKeikoku(db, dto.siensotikbn, alertviewflg);     //警告内容
            return vm;
        }

        /// <summary>
        /// 年度管理区分を取得　1:管理する 2:しない
        /// </summary>
        public static string GetNendoSetting(DaDbContext db, string kinoid)
        {
            var mstDtl = new List<tm_kktyusyutuDto>();
            mstDtl = db.tm_kktyusyutu.SELECT.WHERE.ByItem(nameof(tm_kktyusyutuDto.tyusyutukinoid), kinoid).GetDtoList();

            //もし一つでも抽出対象が年度管理される場合、年度管理=trueとする
            if (mstDtl.Exists(e => e.tuticycle == 名称マスタ.システム.通知サイクル._1))
            {
                return 名称マスタ.システム.通知サイクル._1;
            }
            else return 名称マスタ.システム.通知サイクル._2;
        }

        /// <summary>
        /// 対象区分取得
        /// </summary>
        public static Enum対象区分 GetKbn(tt_afatenaDto dto1, tm_shnendoDto dto2, bool fusyoflg, int age,
                                                               List<tt_shjyusinkyohiriyuDto> dtl, Enum対象区分 kbn)
        {
            //受診拒否判断用
            var flg = dtl.Exists(e => e.jigyocd == dto2.jigyocd);
            //年齢範囲判断用
            var ages = CmLogicUtil.ParseAgeRanges(dto2.age);
            if (kbn == Enum対象区分.対象)
            {
                if (flg)
                {
                    //受診拒否理由を設定あり
                    return Enum対象区分.対象外;
                }
                else
                {
                    //受診拒否理由を設定なし
                    if (fusyoflg)
                    {
                        //生年月日不詳は不詳
                        return Enum対象区分.不明;
                    }
                    else
                    {
                        //生年月日不詳は不詳でない
                        if (ages.Contains(age))
                        {
                            //年齢条件を満たす
                            return Enum対象区分.対象;
                        }
                        else
                        {
                            //年齢条件を満たさない
                            return Enum対象区分.対象外;
                        }
                    }
                }
            }
            else if (kbn == Enum対象区分.不明)
            {
                if (flg)
                {
                    //受診拒否理由を設定あり
                    return Enum対象区分.対象外;
                }
                else
                {
                    //受診拒否理由を設定なし
                    if (fusyoflg)
                    {
                        //生年月日不詳は不詳
                        return Enum対象区分.不明;
                    }
                    else
                    {
                        //生年月日不詳は不詳でない
                        if (ages.Contains(age))
                        {
                            //年齢条件を満たす
                            return Enum対象区分.不明;
                        }
                        else
                        {
                            //年齢条件を満たさない
                            return Enum対象区分.対象外;
                        }
                    }
                }
            }

            //一時対象サインは対象外
            return Enum対象区分.対象外;
        }
    }
}