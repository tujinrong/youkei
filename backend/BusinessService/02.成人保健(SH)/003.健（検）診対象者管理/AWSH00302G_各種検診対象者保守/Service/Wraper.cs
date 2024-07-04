// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 各種検診対象者保守
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.02.05
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00302G
{
    public class Wraper : CmWraperBase
    {
        private const string FUSYOSTR = "不詳";                               //年齢不祥の場合表示用

        /// <summary>
        /// 対象者一覧取得
        /// </summary>
        public static List<PersonRowVM> GetVMList(DaDbContext db, DataRowCollection rows, bool alertviewflg, bool adrsFlg)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, r, alertviewflg, adrsFlg)).ToList();
        }

        /// <summary>
        /// 検診状況一覧取得
        /// </summary>
        public static List<Row2VM> GetVMList(DaDbContext db, tt_afatenaDto dto1, List<tm_shnendoDto> dtl1, List<tm_afhanyoDto> dtl2,
                                            List<tt_shkensinrirekikanriDto> dtl3, List<tt_shjyusinkyohiriyuDto> dtl4, List<DaSelectorModel> cdnmList)
        {
            var list = new List<Row2VM>();
            foreach (var dto2 in dtl1)
            {
                var vm = new Row2VM();
                list.Add(GetVM(db, vm, dto1, dto2, dtl2, dtl3, dtl4, cdnmList));
            }
            return list;
        }

        /// <summary>
        /// 検診状況一覧(基準日変更可能検診のみ)取得
        /// </summary>
        public static List<tt_shkensinrirekikanriDto> GetDtl(DataRowCollection rows)
        {
            var list = new List<tt_shkensinrirekikanriDto>();
            foreach (DataRow row in rows)
            {
                list.Add(GetDto(row));
            }
            return list;
        }

        /// <summary>
        /// 検診状況一覧(基準日変更可能検診のみ)取得
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, tt_afatenaDto dto1, List<Row3VM> vmList, List<tm_shnendoDto> dtl, List<tt_shjyusinkyohiriyuDto> dtl2)
        {
            var list = new List<RowVM>();
            foreach (var vm in vmList)
            {
                list.Add(GetVM(db, dto1, vm, dtl, dtl2));
            }
            return list;
        }

        /// <summary>
        /// 検診状況(1行)
        /// </summary>
        public static Row2VM GetVM(DaDbContext db, Row2VM vm, tt_afatenaDto dto1, tm_shnendoDto dto2, List<tm_afhanyoDto> dtl2,
                                    List<tt_shkensinrirekikanriDto> dtl3, List<tt_shjyusinkyohiriyuDto> dtl4, List<DaSelectorModel> cdnmList,
                                    List<object[]>? keyList = null)
        {
            //予約フラグ
            var yoyakuflg = (keyList != null);
            object[]? key = null;
            if (yoyakuflg) key = keyList!.Find(e => CStr(e[0]) == dto2.jigyocd && CStr(e[1]) == dto2.kensahohocd);

            vm.jigyocd = dto2.jigyocd;                                                                           //検診事業コード
            vm.kensahohocd = dto2.kensahohocd;                                                                   //検査方法コード
            var jigyonm = cdnmList.Find(e => e.value == vm.jigyocd)!.label;
            var kensahohonm = dtl2.Find(e => e.hanyosubcd == CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, vm.jigyocd) &&
                                        e.hanyocd == vm.kensahohocd)?.nm;
            vm.kensahoho = $"{DaStrPool.BRACKET2_START}{jigyonm}{DaStrPool.BRACKET2_END}{kensahohonm}";          //成人健（検）診事業・検査方法
            if (dto2.kijunkbn == Enum年齢基準日区分.指定日)
            {
                vm.kijunflg = false;                                                                             //年齢基準日フラグ(false:指定日;true:受診日時点)
                vm.kijunymd = dto2.kijunymd!;                                                                    //年齢計算基準日
            }
            else
            {
                vm.kijunflg = true;                                                                              //年齢基準日フラグ(false:指定日;true:受診日時点)
                vm.kijunymd = yoyakuflg ? CStr(key?[2]) : FormatYMD(DaUtil.Today);                               //年齢計算基準日
            }
            //一時対象サイン
            var kbn = Enum対象区分.対象外;
            var dto = dtl3.Find(e => e.jigyocd == vm.jigyocd && e.kensahohocd == vm.kensahohocd && e.atenano == dto1.atenano);
            if(dto != null)
            {
                var flg = dto.taisyoflg;
                if (flg == EnumToStr(Enum対象区分.対象)) kbn = Enum対象区分.対象;
                if (flg == EnumToStr(Enum対象区分.不明)) kbn = Enum対象区分.不明;
            }
        
            vm.sign1 = DaNameService.GetName(db, EnumNmKbn.対象サイン, EnumToStr(kbn));

            //年齢初期値
            var age = 0;
            //不祥フラグ対象サイン判断用
            var fusyoflg = true;
            //年齢取得
            if (!CBool(dto1.bymd_fusyoflg) && !string.IsNullOrEmpty(vm.kijunymd))
            {
                fusyoflg = false;
                //基準日
                var kijunymd = CDate(vm.kijunymd);
                age = DaUtil.GetAge(CDate(dto1.bymd), kijunymd);
                vm.age = $"{age}歳";                                                                             //年齢

                var kbn2 = Common.Wraper.GetKbn(dto1, dto2, fusyoflg, CInt(age), dtl4, kbn);
                vm.sign2 = DaNameService.GetName(db, EnumNmKbn.対象サイン, EnumToStr(kbn2));                     //対象サイン
            }
            else
            {
                //生年月日が不詳の場合、「不詳」を表示する
                vm.age = FUSYOSTR;

                var kbn2 = Common.Wraper.GetKbn(dto1, dto2, fusyoflg, CInt(age), dtl4, kbn);
                vm.sign2 = DaNameService.GetName(db, EnumNmKbn.対象サイン, EnumToStr(kbn2));                     //対象サイン
            }
            if (yoyakuflg)
            {
                vm.kijunflg = false;
            }

            return vm;
        }

        /// <summary>
        /// 対象者情報(1行)
        /// </summary>
        private static PersonRowVM GetVM(DaDbContext db, DataRow row, bool alertviewflg, bool adrsFlg)
        {
            var vm = new PersonRowVM();
            vm.atenano = row.Wrap(nameof(tt_afatenaDto.atenano));                   //宛名番号
            vm.name = row.Wrap(nameof(tt_afatenaDto.simei_yusen));                  //氏名
            vm.kname = row.Wrap(nameof(tt_afatenaDto.simei_kana_yusen));            //カナ氏名
            vm.sex = DaNameService.GetName(db, EnumNmKbn.性別_システム共有,
                                row.Wrap(nameof(tt_afatenaDto.sex)));               //性別
            vm.bymd = CmLogicUtil.GetBymd(row);                                     //生年月日
            vm.adrs = CmLogicUtil.GetAdrs(row, adrsFlg);                            //住所
            vm.juminkbn = CmLogicUtil.GetJuminkbn(db, row);                         //住民区分
            var siensotikbn = row.Wrap(nameof(tt_afatenaDto.siensotikbn));          //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);     //警告内容
            vm.jutokbn = (Enum住登区分)row.CInt(nameof(tt_afatenaDto.jutokbn));     //住登区分

            return vm;
        }

        /// <summary>
        /// 検診履歴管理テーブル
        /// </summary>
        private static tt_shkensinrirekikanriDto GetDto(DataRow row)
        {
            var dto = new tt_shkensinrirekikanriDto();
            dto.nendo = row.CInt(nameof(tt_shkensinrirekikanriDto.nendo));              //年度
            dto.jigyocd = row.Wrap(nameof(tt_shkensinrirekikanriDto.jigyocd));          //成人健（検）診事業コード
            dto.kensahohocd = row.Wrap(nameof(tt_shkensinrirekikanriDto.kensahohocd));  //検査方法コード
            dto.atenano = row.Wrap(nameof(tt_shkensinrirekikanriDto.atenano));          //宛名番号
            dto.taisyoflg = row.Wrap(nameof(tt_shkensinrirekikanriDto.taisyoflg));      //一時対象サイン

            return dto;
        }

        /// <summary>
        /// 検診状況(1行)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, tt_afatenaDto dto1, Row3VM oldvm, List<tm_shnendoDto> dtl, List<tt_shjyusinkyohiriyuDto> dtl2)
        {
            //不祥フラグ対象サイン判断用
            var fusyoflg = true;
            if (!CBool(dto1.bymd_fusyoflg) && !string.IsNullOrEmpty(oldvm.kijunymd)) fusyoflg = false;

            var kbn = (Enum対象区分)Enum.Parse(typeof(Enum対象区分), oldvm.sign1);
            var vm = new RowVM();
            vm.jigyocd = oldvm.jigyocd;                                                             //検診事業コード
            vm.kensahohocd = oldvm.kensahohocd;                                                     //検査方法コード
            //基準日
            var kijunymd = CDate(oldvm.kijunymd);
            //年齢取得
            var age = 0;
            if (fusyoflg)
            {
                //生年月日が不詳の場合、「不詳」を表示する
                vm.age = FUSYOSTR;
            }
            else
            {
                age = DaUtil.GetAge(CDate(dto1.bymd), kijunymd);
                vm.age = $"{age}歳";
            }
            //年齢
            var dto2 = dtl.Find(e => e.jigyocd == vm.jigyocd && e.kensahohocd == vm.kensahohocd)!;

            var kbn2 = Common.Wraper.GetKbn(dto1, dto2, fusyoflg, CInt(age), dtl2, kbn);
            vm.sign2 = DaNameService.GetName(db, EnumNmKbn.対象サイン, EnumToStr(kbn2));            //対象サイン

            return vm;
        }
    }
}