// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: フォロー管理(共通バー)
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.12.26
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00609D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// フォロー管理内容一覧情報取得
        /// </summary>
        public static List<RowFollowContentVM> GetFollowContentVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(r => GetFollowContentVM(db, r)).ToList();
        }

        /// <summary>
        /// フォロー管理内容情報取得(一覧)
        /// </summary>
        private static RowFollowContentVM GetFollowContentVM(DaDbContext db, DataRow row)
        {
            var vm = new RowFollowContentVM();
            vm.follownaiyoedano = CInt(row.Wrap($"{nameof(vm.follownaiyoedano)}_naiyo"));                                                       //フォロー内容枝番
            vm.haakukeiro = DaNameService.GetName(db, EnumNmKbn.把握経路_フォロー状況情報, row.Wrap($"{nameof(vm.haakukeiro)}_naiyo"));         //把握経路
            var haakujigyocd = row.Wrap($"{nameof(vm.haakujigyocd)}_naiyo");
            vm.haakujigyocd = string.IsNullOrEmpty(haakujigyocd) ?
                              string.Empty : DaHanyoService.GetName(db, EnumHanyoKbn.フォロー把握事業コード, Enum名称区分.名称, haakujigyocd);  //把握事業
            vm.follownaiyo = row.Wrap($"{nameof(vm.follownaiyo)}_naiyo");                                                                       //フォロー内容 
            vm.followstatus = DaNameService.GetName(db, EnumNmKbn.フォロー状況, row.Wrap($"{nameof(vm.followstatus)}_naiyo"));                  //フォロー状況
            var followjigyocd = row.Wrap($"{nameof(vm.followjigyocd)}_naiyo");
            vm.followjigyocd = string.IsNullOrEmpty(followjigyocd) ?
                               string.Empty : DaHanyoService.GetName(db, EnumHanyoKbn.フォロー事業コード, Enum名称区分.名称, followjigyocd);    //フォロー事業
            vm.followyoteiymd = DaFormatUtil.FormatWaKjYMD(CNDate(row.Wrap($"{nameof(vm.followyoteiymd)}_naiyo")));                             //フォロー予定情報  予定日
            vm.followtm_yotei = row.Wrap($"{nameof(vm.followtm_yotei)}_naiyo");                                                                 //フォロー予定情報  時間
            vm.followkaijocd_yotei = row.Wrap($"{nameof(vm.followkaijocd_yotei)}_naiyo");                                                       //フォロー予定情報  会場
            vm.followstaffid_yotei = row.Wrap($"{nameof(vm.followstaffid_yotei)}_naiyo");                                                       //フォロー予定情報  担当者
            vm.followjissiymd = DaFormatUtil.FormatWaKjYMD(CNDate(row.Wrap($"{nameof(vm.followjissiymd)}_naiyo")));                             //フォロー結果情報  実施日
            vm.followtm = row.Wrap($"{nameof(vm.followtm)}_naiyo");                                                                             //フォロー結果情報  時間
            vm.followkaijocd = row.Wrap($"{nameof(vm.followkaijocd)}_naiyo");                                                                   //フォロー結果情報  会場
            vm.followstaffid = row.Wrap($"{nameof(vm.followstaffid)}_naiyo");                                                                   //フォロー結果情報  担当者

            return vm;
        }
    }
}