// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: CSV出力項目選択
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.02.26
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00307D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 帳票CSV出力パターンサブ情報リスト取得
        /// </summary>
        public static List<tt_eucsv_subDto> GetDtl(SaveRequest req, int outputptnno)
        {
            var dtl = new List<tt_eucsv_subDto>();
            var orderseq = 0;
            foreach (var reportitemid in req.kekkalist)
            {
                //データ処理
                dtl.Add(GetDto(req.rptid, req.yosikiid, outputptnno, reportitemid, ++orderseq));
            }
            return dtl;
        }

        /// <summary>
        /// 帳票CSV出力パターンサブ情報取得
        /// </summary>
        private static tt_eucsv_subDto GetDto(string rptid, string yosikiid, int outputptnno, string reportitemid, int orderseq)
        {
            var dto = new tt_eucsv_subDto();
            dto.rptid = rptid;                   //帳票ID
            dto.yosikiid = yosikiid;             //様式ID
            dto.outputptnno = outputptnno;       //出力パターン番号
            dto.reportitemid = reportitemid;     //帳票項目ID
            dto.orderseq = orderseq;             //並びシーケンス

            return dto;
        }
    }
}