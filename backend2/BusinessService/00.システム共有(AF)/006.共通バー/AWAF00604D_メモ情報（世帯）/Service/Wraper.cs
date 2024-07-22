// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: メモ情報（世帯）
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.07.13
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00604D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 世帯基本情報(ヘッダー部)
        /// </summary>
        public static HeaderVM GetVM(DaDbContext db, tt_afatenaDto dto, string setaino)
        {
            var vm = new HeaderVM();

            if (dto != null)
            {
                vm = (HeaderVM)Common.Wraper.GetHeaderVM(db, vm, dto);
            }

            vm.setaino = setaino;   //世帯番号

            return vm;
        }
    }
}