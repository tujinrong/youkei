// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 詳細条件検索
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.04.28
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.Service.CmFilterVM;
namespace BCC.Affect.Service.AWAF00703D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 共通(左)/独自(右)条件リスト
        /// </summary>
        public static List<CommonFilterVM> GetVMList(DaDbContext db, List<tt_affilterDto> dtl, InitRequest req)
        {
            return dtl.Select(l => GetVM(db, l, req)).ToList();
        }

        /// <summary>
        /// 条件コントローラー
        /// </summary>
        private static CommonFilterVM GetVM(DaDbContext db, tt_affilterDto dto, InitRequest req)
        {
            var vm = new CommonFilterVM();
            vm.jyoseq = dto.jyoseq;                                                         //条件シーケンス
            vm.jyokbn = dto.jyokbn;                                                         //条件区分
            vm.hyojinm = dto.hyojinm;                                                       //詳細条件表示名
            vm.placeholder = CStr(dto.placeholder);                                         //入力説明
            vm.ctrltype = dto.ctrltype;                                                     //コントローラータイプ
            vm.rangeflg = dto.rangeflg;                                                     //範囲フラグ
            switch (vm.ctrltype)
            {
                case Enumコントローラータイプ.年齢生年月日:
                    vm.manflg = CInt(dto.sethanyokbn1) == 1;                                //男性フラグ
                    vm.womanflg = CInt(dto.sethanyokbn2) == 1;                              //女性フラグ
                    vm.bothflg = vm.manflg && vm.womanflg;                                  //両方フラグ
                    vm.unknownflg = CInt(dto.sethanyokbn3) == 1;                            //不明フラグ
                    break;
                case Enumコントローラータイプ.一覧選択:
                    vm.cdlist = CmLogicUtil.GetFilterCdList(db, dto, Enum名称区分.名称);    //一覧選択リスト
                    break;
                case Enumコントローラータイプ.通用項目:
                    vm.itemkbn = (Enum項目区分)CInt(dto.sethanyokbn1);                      //通用項目区分
                    break;
                case Enumコントローラータイプ.参照ダイアログ:
                    var kbn = (Enum参照ダイアログ項目区分)CInt(dto.sethanyokbn1);
                    vm.searchitemkbn = kbn;                                                          //参照ダイアログ項目区分
                    vm.cdlist = CmLogicUtil.GetCdList(db, req.kinoid!, req.patternno, kbn, true);   //一覧選択リスト
                    break;
                default:
                    throw new Exception("Enumコントローラータイプ error");
            }

            return vm;
        }
    }
}