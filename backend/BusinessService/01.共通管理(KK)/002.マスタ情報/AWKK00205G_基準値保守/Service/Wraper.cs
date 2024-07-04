// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 基準値保守
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.01.16
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00205G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 基準値保守情報一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, List<tm_kkkijunDto> dtl, string kijunjigyocd, Dictionary<string, ItemVM> shfreeitemDic)
        {
            return dtl.Select(d =>
            {
                var itemnm = string.Empty;
                var tani = string.Empty;
                var vm = new RowVM();
                vm.itemcd = d.itemcd;                                                                         //項目コード
                if (shfreeitemDic.Keys.Contains(d.itemcd))                                                    
                {                                                                                             
                    itemnm = shfreeitemDic[d.itemcd].itemnm;                                                  
                    tani = shfreeitemDic[d.itemcd].tani;                                                      
                }                                                                                             
                vm.itemnm = $"{d.itemcd}{DaConst.SELECTOR_DELIMITER}{itemnm}";                                //項目名称
                vm.edano = d.edano;                                                                           //枝番
                vm.sex = DaNameService.GetName(db, EnumNmKbn.性別_システム, EnumToStr(d.sex));                //性別
                if (CInt(d.agef) > 0 && CInt(d.aget) > 0)                                                     
                {                                                                                             
                    vm.age = $"{d.agef}{DaStrPool.C_TILDE_FULL}{d.aget}";                                     //年齢範囲
                }                                                                                             
                vm.tani = CStr(tani);                                                                         //単位
                vm.kijunvaluehyoki = d.kijunvaluehyoki;                                                       //基準範囲
                vm.alertvaluehyoki = d.alertvaluehyoki;                                                       //要注意
                vm.errvaluehyoki = d.errvaluehyoki;                                                           //異常値
                var yukoymdf = DaFormatUtil.FormatWaKjYMD(CNDate(d.yukoymdf));                                
                var yukoymdt = DaFormatUtil.FormatWaKjYMD(CNDate(d.yukoymdt));
                vm.yukoymdf = CNDate(d.yukoymdf);                                                             //有効年月日開始
                vm.yukoymdt = CNDate(d.yukoymdt);                                                             //有効年月日終了
                vm.yukoymd = $"{yukoymdf}{DaStrPool.C_TILDE_FULL}{yukoymdt}";                                 //有効年月日範囲
                var today = DaUtil.Today;
                vm.yukoflg = ((!string.IsNullOrEmpty(d.yukoymdf) && DateTime.Parse(d.yukoymdf) > today)
                          || (!string.IsNullOrEmpty(d.yukoymdt) && DateTime.Parse(d.yukoymdt) < today));      //有効フラグ

                return vm;
            }).ToList();
        }

        /// <summary>
        /// 基準値保守情報(詳細画面)
        /// </summary>
        public static SaveMainVM GetVM(DaDbContext db, tm_kkkijunDto kkkijunDto, tm_shfreeitemDto shfreeitemDto)
        {
            var vm = new SaveMainVM();
            vm.maincodesetinfo = new MainCodesetInfoSaveVM();
            vm.mainnumsetinfo = new MainNumsetInfoVM();
            vm.freemstinfo = new FreeMstInfoVM();

            ///明細部                                                                                        
            vm.freemstinfo.tani = CStr(shfreeitemDto?.tani);                                                  //単位
            vm.freemstinfo.inputflgstr = CStr(shfreeitemDto?.inputflg);                                       //入力フラグ
            vm.freemstinfo.hyojinendof = DaFormatUtil.FormatWaKjYMD(CNDate(shfreeitemDto?.hyojinendof));      //表示年度（開始） 
            vm.freemstinfo.hyojinendot = DaFormatUtil.FormatWaKjYMD(CNDate(shfreeitemDto?.hyojinendot));      //表示年度（終了） 
            vm.freemstinfo.numcdflg = (EnumToStr(shfreeitemDto!.inputtype) == EnumToStr(Enum入力タイプ.コード_名称マスタ)
                || EnumToStr(shfreeitemDto!.inputtype) == EnumToStr(Enum入力タイプ.コード_汎用マスタ));       //入力タイプフラグ
            vm.ageflg = ((kkkijunDto.agef != null && kkkijunDto.agef > 0)
                      || (kkkijunDto.aget != null && kkkijunDto.aget > 0));

            vm.agef = kkkijunDto.agef;                                                                        //年齢（開始）                              
            vm.aget = kkkijunDto.aget;                                                                        //年齢（終了）
            vm.sexflg = (CInt(EnumToStr(kkkijunDto.sex)) > 0);                                                //性別指定フラグ
            vm.sex = EnumToStr(kkkijunDto.sex);                                                               //性別                
            vm.yukoymdf = CDate(kkkijunDto.yukoymdf);                                                         //有効年月日（開始）            
            vm.yukoymdt = CDate(kkkijunDto.yukoymdt);                                                         //有効年月日（終了）          

            ///数値設定部
            if (vm.mainnumsetinfo != null)
            {
                vm.mainnumsetinfo.errvalue1t = kkkijunDto.errvalue1t;                                         //有効年月日（終了）          
                vm.mainnumsetinfo.alertvalue1f = kkkijunDto.alertvalue1f;                                     //注意値1（開始）         
                vm.mainnumsetinfo.alertvalue1t = kkkijunDto.alertvalue1t;                                     //注意値1（終了）      
                vm.mainnumsetinfo.kijunvaluef = kkkijunDto.kijunvaluef;                                       //基準値1（開始）      
                vm.mainnumsetinfo.kijunvaluet = kkkijunDto.kijunvaluet;                                       //基準値1（終了）   
                vm.mainnumsetinfo.alertvalue2f = kkkijunDto.alertvalue2f;                                     //注意値2（開始）  
                vm.mainnumsetinfo.alertvalue2t = kkkijunDto.alertvalue2t;                                     //注意値2（終了）
                vm.mainnumsetinfo.errvalue2f = kkkijunDto.errvalue2f;                                         //異常値2
            }

            ///コード設定部
            if (vm.maincodesetinfo != null)
            {
                vm.maincodesetinfo.hanteicdlist = CommaStrToList(kkkijunDto.hanteicd);                        //基準値（コード）         
                vm.maincodesetinfo.alerthanteicdlist = CommaStrToList(kkkijunDto.alerthanteicd);              //注意値（コード）         
                vm.maincodesetinfo.errhanteicdlist = CommaStrToList(kkkijunDto.errhanteicd);                  //異常値（コード）  
            }

            ///表記設定部
            vm.kijunvaluehyoki = kkkijunDto.kijunvaluehyoki;                                                  //基準値表記        
            vm.alertvaluehyoki = kkkijunDto.alertvaluehyoki;                                                  //注意値表記     
            vm.errvaluehyoki = kkkijunDto.errvaluehyoki;                                                      //異常値表記  

            vm.upddttm = kkkijunDto.upddttm;                                                                   //更新日時

            return vm;
        }

        /// <summary>
        /// 項目名称ドロップダウンリスト
        /// </summary>
        public static List<DaSelectorModel> GetVMList(DaDbContext db, string jigyocd)
        {
            //フリー項目マスタ 「入力タイプ」が数値の項目
            var keylist = DaNameService.GetNameList(db, EnumNmKbn.フリー項目データタイプ)
                                                    .Where(e => CStr(e.hanyokbn1) == EnumToStr(Enum入力値保存型.数値))
                                                    .Select(e => e.nmcd).ToList();
            var dtlNum = DaFreeItemService.GetKensinList(db, jigyocd).Where(e => keylist.Contains(EnumToStr(e.inputtype)));

            //フリー項目マスタ 「入力タイプ」がコードの項目
            var dtlCode = DaFreeItemService.GetKensinList(db, jigyocd).Where(e => e.inputtype == Enum入力タイプ.コード_名称マスタ
                                                                || e.inputtype == Enum入力タイプ.コード_汎用マスタ);
            var result = dtlNum.Concat(dtlCode).Select(e =>
                                new DaSelectorModel(e.itemcd, e.itemnm)).Distinct().ToList();

            return result;
        }
    }
}
