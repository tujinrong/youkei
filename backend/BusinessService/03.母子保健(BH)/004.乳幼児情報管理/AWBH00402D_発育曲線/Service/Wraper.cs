// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 乳幼児情報管理-発育曲線
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.05.17
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWBH00402D
{
    public class Wraper : CmWraperBase
    {
        //================================= 発育曲線 =================================
        /// <summary>
        /// 発育曲線ヘッダー情報
        public static HeaderInfoVM GetHeaderVM(DaDbContext db, tt_afatenaDto dto)
        {
            var vm = new HeaderInfoVM()
            {
                //ヘッダー部
                atenano = CStr(dto.atenano),                //宛名番号
                name = CStr(dto.simei_yusen),               //氏名（氏名_優先）
            };

            return vm;
        }

        /// <summary>
        /// 発育曲線データリスト（全件）
        /// </summary>
        public static List<CurveInfoVM> GetCurveInfoVMList(DaDbContext db, List<tt_bhnyfreeDto> dtl)
        {
            List<CurveInfoVM> list = new List<CurveInfoVM>();
            foreach (tt_bhnyfreeDto dto in dtl)
            {
                list.Add(GetCurveInfoVM(db, dto));
            }
            return list;
        }

        /// <summary>
        /// 発育曲線データリスト（個別）
        public static CurveInfoVM GetCurveInfoVM(DaDbContext db, tt_bhnyfreeDto dto)
        {
            var vm = new CurveInfoVM()
            {
                kaisu = dto.edano,                          //回数
                value = dto.numvalue,                       //値
            };

            return vm;
        }
    }
}