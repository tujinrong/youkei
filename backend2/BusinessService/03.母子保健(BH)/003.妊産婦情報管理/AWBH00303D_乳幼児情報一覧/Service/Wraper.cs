// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 妊産婦情報管理-乳幼児情報一覧
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.05.14
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWBH00303D
{
    public class Wraper : CmWraperBase
    {
        //================================= 乳幼児情報一覧画面検索処理 =================================
        /// <summary>
        /// 乳幼児情報一覧画面--ヘッダー部
        /// </summary>
        public static HeaderInfoVM GetVM(DaDbContext db, tt_afatenaDto dto)
        {
            var juminkbn = CStr(dto.juminkbn);

            var vm = new HeaderInfoVM()
            {
                //ヘッダー部
                atenano = CStr(dto.atenano),                                            //宛名番号
                name = CStr(dto.simei_yusen),                                           //氏名（氏名_優先）
                kname = CStr(dto.simei_kana_yusen),                                     //カナ氏名（氏名_フリガナ_優先）
                sexhyoki = CmLogicUtil.GetSex(db, CStr(dto.sex)),                       //性別表記
                bymd = AWBH00301G.Wraper.GetBymd(dto),                                  //生年月日
                juminkbnnm = AWBH00301G.Wraper.MNm(db, juminkbn, EnumNmKbn.住民区分),   //住民区分
                age = CmLogicUtil.GetAgeStr(dto.bymd_fusyoflg, dto.bymd),               //年齢
                agekijunymd = FormatWaKjYMD(DaUtil.Today),                              //年齡計算基準日
            };

            return vm;
        }

        /// <summary>
        /// 乳幼児情報一覧画面（一覧）
        /// </summary>
        public static List<ListInfoVM> GetListInfoVMList(DaDbContext db, HeaderInfoVM hdvm, IOrderedEnumerable<tt_bhnsbosikenkotetyokofuDto> dtl)
        {
            List<ListInfoVM> list = new List<ListInfoVM>();
            var i = 1;
            foreach (tt_bhnsbosikenkotetyokofuDto dto in dtl)
            {
                list.Add(GetListInfoVM(db, hdvm, dto, i));
                i++;
            }
            return list;
        }

        /// <summary>
        /// 乳幼児情報一覧画面（一行）
        public static ListInfoVM GetListInfoVM(DaDbContext db, HeaderInfoVM hdvm, tt_bhnsbosikenkotetyokofuDto dto, int i)
        {
            var vm = new ListInfoVM()
            {
                no = CStr(i),                                                           //No.
                atenano = hdvm.atenano,                                                 //宛名番号
                name = hdvm.name,                                                       //氏名（氏名_優先）
                kname = hdvm.kname,                                                     //カナ氏名（氏名_フリガナ_優先）
                sexhyoki = hdvm.sexhyoki,                                               //性別表記
                bymd = hdvm.bymd,                                                       //生年月日
                torokuno = CStr(dto.torokuno),                                          //登録番号
                torokunorenban = CStr(dto.torokunorenban),                              //登録番号連番
                bositetyokofuno = CStr(dto.bositetyokofuno),                            //母子健康手帳交付番号
            };
            return vm;
        }
    }
}