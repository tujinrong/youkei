// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票発行履歴管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.03.22
// 作成者　　: 千秋
// 変更履歴　:
// *******************************************************************
using BCC.Affect.BatchService;
using BCC.Affect.Service.AWKK00111G;
using GaibuApiService.GaibuDemo.Domain.Others;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using Org.BouncyCastle.Ocsp;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWAF01101G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 帳票発行履歴管理情報一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, r)).ToList();
        }

        /// <summary>
        /// 帳票発行履歴管理情報(一覧画面)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, DataRow row)
        {
            var vm = new RowVM();
            var list = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumシステムマスタ区分.EUC帳票マスタ);
            //todo:テーブルレビューによりテーブル名変更、後日修正
            //vm.rptnm = DaSelectorService.GetCdNm(list, row.Wrap(nameof(tt_kkrptyosikihakkoDto.rptid)));               //帳票名(コード：名称)
            list = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumシステムマスタ区分.EUC様式詳細マスタ);
            //todo:テーブルレビューによりテーブル名変更、後日修正
            //vm.yosikinm = DaSelectorService.GetCdNm(list, row.Wrap(nameof(tt_kkrptyosikihakkoDto.yosikiid)));         //様式名(コード：名称)
            vm.nendo = row.Wrap(nameof(tt_kkrpthakkorirekiDto.nendo));                                                //年度
            //todo:テーブルレビューによりテーブル名変更、後日修正
            //vm.hakkodttm = row.Wrap(nameof(tt_kkrpthakkorirekiDto.hakkodttm));                                        //発行日時
            vm.hakkoninsu = row.Wrap(nameof(RowVM.hakkoninsu));                                                       //人数
            list = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumシステムマスタ区分.帳票発行抽出対象マスタ);
            vm.taisyocd = DaSelectorService.GetCdNm(list, row.Wrap(nameof(RowVM.taisyocd)));                          //抽出対象コード(コード：名称)

            return vm;
        }

    }
}