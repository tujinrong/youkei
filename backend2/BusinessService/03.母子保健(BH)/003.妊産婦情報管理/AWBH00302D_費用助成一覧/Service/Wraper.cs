// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 妊産婦情報管理-費用助成一覧
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.05.14
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaHanyoService;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.Service.AWBH00301G.Service;

namespace BCC.Affect.Service.AWBH00302D
{
    public class Wraper : CmWraperBase
    {
        //妊婦歯科健診名の一回目コードは51から為、偏差値50に設定
        private const int KAISU_OFFSET = 50;

        /// <summary>
        /// 初期化処理（一覧のドロップダウンリストの初期化）
        /// </summary>
        public static InitListResponse GetVM(DaDbContext db, string jigyocd)
        {
            var vm = new InitListResponse();

            //母子保健事業コードから判断
            switch (jigyocd)
            {
                case JIGYO_00006:       //妊婦健診費用助成
                    vm.kensyuruilist = GetSelectorList(db, Enum名称区分.略称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.妊婦健診名)).ToString());
                    vm.kingakulimitlist = Service.GetSelectorList(db, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.妊婦健診名)).ToString());
                    break;

                case JIGYO_00032:       //妊産婦歯科健診費用助成
                    vm.kensyuruilist = GetSelectorList(db, Enum名称区分.略称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.妊婦歯科健診名)).ToString());
                    vm.kingakulimitlist = Service.GetSelectorList(db, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.妊婦歯科健診名)).ToString());
                    break;
                case JIGYO_00011:       //産婦健診費用助成
                    vm.kensyuruilist = GetSelectorList(db, Enum名称区分.略称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.産婦健診名)).ToString());
                    vm.kingakulimitlist = Service.GetSelectorList(db, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.産婦健診名)).ToString());
                    break;
                default:
                    break;
            }

            return vm;
        }

        //================================= ⑧費用助成一覧画面検索処理 =================================
        /// <summary>
        /// 妊婦健診費用助成リスト（一覧）
        /// </summary>
        public static List<JyoseiListInfoVM> GetJyoseiListInfoVMList(DaDbContext db, string jigyocd, IOrderedEnumerable<tt_bhnsninpukensinhiyojosei_subDto> dtl)
        {
            List<JyoseiListInfoVM> list = new List<JyoseiListInfoVM>();
            var i = 1;
            foreach (tt_bhnsninpukensinhiyojosei_subDto dto in dtl)
            {
                list.Add(GetJyoseiListInfoVM(db, jigyocd, dto, i));
                i++;
            }
            return list;
        }

        /// <summary>
        /// 妊婦健診費用助成（一行）
        public static JyoseiListInfoVM GetJyoseiListInfoVM(DaDbContext db, string jigyocd, tt_bhnsninpukensinhiyojosei_subDto dto, int i)
        {
            var vm = new JyoseiListInfoVM();

            var syurui = CStr(dto.joseikensyurui).PadLeft(2, '0');
            var hanyodto = new tm_afhanyoDto();

            vm.no = CStr(i);                                //No.
            //助成券種類
            switch (jigyocd)
            {
                case JIGYO_00006:                           // 妊婦健診結果
                    if (!string.IsNullOrEmpty(CStr(dto.joseikensyurui)))
                    {
                        vm.joseikensyurui = GetCdNm(db, EnumHanyoKbn.妊婦健診名, Enum名称区分.略称, syurui);   //助成券種類
                    }
                    hanyodto = GetHanyoDto(db, EnumHanyoKbn.妊婦健診名, syurui);
                    if (hanyodto != null) { vm.joseikingakulimit = CInt(hanyodto.hanyokbn2); }                 //助成金額（上限額）
                    break;

                case JIGYO_00032:                           // 妊産婦歯科健診結果（例：一回目は51）
                    try
                    {
                        if (!string.IsNullOrEmpty(CStr(dto.joseikensyurui)))
                        {
                            vm.joseikensyurui = GetCdNm(db, EnumHanyoKbn.妊婦歯科健診名, Enum名称区分.略称, syurui); //助成券種類
                        }
                    }
                    catch (Exception e)
                    {
                        //エラーが発生した場合
                        vm.joseikensyurui = string.Empty;
                    }
                    hanyodto = GetHanyoDto(db, EnumHanyoKbn.妊婦歯科健診名, syurui);
                    if (hanyodto != null) { vm.joseikingakulimit = CInt(hanyodto.hanyokbn2); }                 //助成金額（上限額）
                    break;
            }
            vm.jusinymd = dto.jusinymd;                     //受診年月日
            vm.siharaikingaku = dto.siharaikingaku;         //支払金額
            vm.joseikingaku = dto.joseikingaku;             //助成金額

            return vm;
        }

        /// <summary>
        /// 産婦健診費用助成リスト（一覧）
        /// </summary>
        public static List<JyoseiListInfoVM> GetJyoseiListInfoVMList(DaDbContext db, IOrderedEnumerable<tt_bhnssanpukensinhiyojosei_subDto> dtl)
        {
            List<JyoseiListInfoVM> list = new List<JyoseiListInfoVM>();
            var i = 1;
            foreach (tt_bhnssanpukensinhiyojosei_subDto dto in dtl)
            {
                list.Add(GetJyoseiListInfoVM(db, dto, i));
                i++;
            }
            return list;
        }

        /// <summary>
        /// 産婦健診費用助成（一行）
        public static JyoseiListInfoVM GetJyoseiListInfoVM(DaDbContext db, tt_bhnssanpukensinhiyojosei_subDto dto, int i)
        {
            var vm = new JyoseiListInfoVM();

            var syurui = CStr(dto.joseikensyurui).PadLeft(2, '0');
            vm.no = CStr(i);                                                                                        //No.
            if (!string.IsNullOrEmpty(CStr(dto.joseikensyurui)))
            {
                vm.joseikensyurui = DaHanyoService.GetCdNm(db, EnumHanyoKbn.産婦健診名, Enum名称区分.略称, syurui);     //助成券種類
            }
            vm.jusinymd = dto.jusinymd;                                                                             //受診年月日
            vm.siharaikingaku = dto.siharaikingaku;                                                                 //支払金額
            vm.joseikingaku = dto.joseikingaku;                                                                     //助成金額

            var hanyodto = GetHanyoDto(db, EnumHanyoKbn.産婦健診名, syurui);
            if (hanyodto != null) { vm.joseikingakulimit = CInt(hanyodto.hanyokbn2); }                              //助成金額（上限額）

            return vm;
        }
    }
}