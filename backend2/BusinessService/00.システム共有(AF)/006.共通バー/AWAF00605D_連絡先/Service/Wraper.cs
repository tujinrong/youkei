// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 連絡先
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.07.13
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00605D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 検索処理(全タブ)
        /// </summary>
        public static List<SearchVM> GetVMList(DaDbContext db, List<string> sisyoList, List<tt_afrenrakusakiDto> dtl1, List<tt_afatenaDto> dtl2, List<tm_afhanyoDto> dtl3, List<KeyVM> keylist, string jigyocd, string jigyo)
        {
            var list = new List<SearchVM>();
            foreach (var key in keylist)
            {
                //連絡先テーブル
                var dto1 = dtl1.Find(d => d.atenano == key.atenano && d.jigyocd == jigyocd);
                //宛名テーブル
                var dto2 = dtl2.Find(d => d.atenano == key.atenano);
                list.Add(GetVM(db, key, sisyoList, dto1, dto2!, dtl3, jigyo));
            }
            return list;
        }

        /// <summary>
        /// 検索処理(タブごと)
        /// </summary>
        private static SearchVM GetVM(DaDbContext db, KeyVM key, List<string> sisyoList, tt_afrenrakusakiDto? dto1, tt_afatenaDto dto2, List<tm_afhanyoDto> dtl3, string jigyo)
        {
            var vm = new SearchVM();
            vm.tabnm = key.kbn.ToString();                      //タブ名
            vm.headerinfo = GetVM(db, dto2);                    //個人基本情報
            vm.detailinfo = GetVM(dto1, dto2.atenano, dtl3, jigyo);   //連絡先情報
            //更新権限フラグ
            vm.updflg = string.IsNullOrEmpty(dto1?.regsisyo) || sisyoList.Contains(dto1.regsisyo);
            return vm;
        }

        /// <summary>
        /// 個人基本情報(ヘッダー部)
        /// </summary>
        private static CommonBarHeaderBaseVM GetVM(DaDbContext db, tt_afatenaDto dto)
        {
            var vm = new CommonBarHeaderBaseVM();

            vm.name = dto.simei_yusen;                                                                  //氏名
            vm.kname = CStr(dto.simei_kana_yusen);                                                      //カナ氏名
            vm.sex = CmLogicUtil.GetSex(db, dto.sex);                                                   //性別
            vm.juminkbn = DaNameService.GetName(db, EnumNmKbn.住民区分, dto.juminkbn);                  //住民区分
            vm.bymd = CmLogicUtil.GetYMDStr(dto.bymd_fusyoflg, dto.bymd, dto.bymd_fusyohyoki);          //生年月日
            vm.age = CmLogicUtil.GetAgeStr(dto.bymd_fusyoflg, dto.bymd, DaUtil.Today);                  //年齢
            vm.agekijunymd = DaFormatUtil.FormatWaKjYMD(DaUtil.Today);                                  //年齡計算基準日

            return vm;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        private static SaveVM? GetVM(tt_afrenrakusakiDto? dto, string atenano, List<tm_afhanyoDto> dtl, string jigyo)
        {
            var vm = new SaveVM();
            vm.atenano = atenano;                                                               //宛名番号
            vm.jigyo = jigyo;                                                                   //利用事業(コード：名称)
            //新規の場合
            if (dto == null) return vm;

            vm.tel = CStr(dto.tel);                                                             //電話番号
            vm.keitaitel = CStr(dto.keitaitel);                                                 //携帯番号
            vm.emailadrs = CStr(dto.emailadrs);                                                 //E-mailアドレス
            vm.emailadrs2 = CStr(dto.emailadrs2);                                               //E-mailアドレス2
            vm.syosai = CStr(dto.syosai);                                                       //連絡先詳細
            vm.regsisyonm = DaHanyoService.GetName(dtl, Enum名称区分.名称, CStr(dto.regsisyo)); //登録支所名
            vm.upddttm = dto.upddttm;                                                           //更新日時
            return vm;
        }
    }
}