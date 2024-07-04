// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業コード管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.01.25
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00805D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 集約コード情報
        /// </summary>
        public static SaveVM GetVM(DaDbContext db, string hanyokbn1, string? cd1, string? cd2, string? cd3, string? cd4)
        {
            var vm = new SaveVM();
            //個人連絡先集約コード(コード：名称)
            vm.cdnm1 = DaNameService.GetCdNm(db, EnumNmKbn.事業集約コード, Enum名称区分.名称, CStr(cd1));
            vm.cdnmlist2 = CommaStrToList(cd2);         //集約コードリスト(メモ情報)
            vm.cdnmlist3 = CommaStrToList(cd3);         //集約コードリスト(電子ファイル情報)
            vm.cdnmlist4 = CommaStrToList(cd4);         //集約コードリスト(フォロー管理)

            var flgList = CommaStrToList(hanyokbn1)!;   
            vm.flg1 = !CBool(flgList[0]);               //設定不要フラグ(個人連絡先)
            vm.flg2 = !CBool(flgList[1]);               //設定不要フラグ(メモ情報)
            vm.flg3 = !CBool(flgList[2]);               //設定不要フラグ(電子ファイル情報)
            vm.flg4 = !CBool(flgList[3]);               //設定不要フラグ(フォロー管理)

            return vm;
        }
    }
}