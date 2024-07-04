// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定.プロシージャ管理画面
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.09
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00607D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// プロシージャ情報を取得する
        /// </summary>
        public static ProcedureVM GetProcedureVM(tm_kktorinyuryoku_procDto dto, FunctionVM func)
        {
            var vm = new ProcedureVM();

            vm.procseq = dto.procseq;           //プロシージャシーケンス
            vm.procnm = dto.procnm;             //プロシージャ名
            vm.prockbn = dto.prockbn;           //種別区分
            vm.procsql = func.src;              //sql

            return vm;
        }
    }
}
