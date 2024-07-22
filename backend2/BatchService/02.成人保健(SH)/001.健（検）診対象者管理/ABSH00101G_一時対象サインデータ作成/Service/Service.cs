// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 一時対象サインデータ作成
//             サービス処理
// 作成日　　: 2024.02.07
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.BatchService.ABSH00101G
{
    [DisplayName("一時対象サインデータ作成")]
    public class Service : BtServiceBase, IBtService
    {
        private const string PROC_NAME = "sp_absh00101g_01";
        public void Execute(string? jobId, object? param = null, long? sessionseq = null, bool? nowFlg = false)
        {
            Transction(jobId, sessionseq, param, nowFlg ,(db) =>
            {
                ParameterModel pm = (ParameterModel)param!;
                //パラメータ取得
                var p = Converter.GetParameters(pm.nendo);
                //DB更新
                DaDbUtil.RunProcedure(db, PROC_NAME, p);
            });
        }
    }
}