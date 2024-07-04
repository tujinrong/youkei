// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: お気に入り
//             画面項目からDB項目に変換
// 作成日　　: 2023.02.15
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00303D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// お気に入りテーブルDtoリスト(更新処理)
        /// </summary>
        public static List<tt_afokiniiriDto> GetDtl(List<tt_afokiniiriDto> dtl, UpdateRequest req)
        {
            dtl = dtl.Where(d => d.kinoid != req.kinoid).ToList();
            if (req.updkbn == Enum更新区分.追加)
            {
                dtl.Add(GetDto(req.userid, req.kinoid));
            } 
            int orderseq = 0;
            return dtl.Select(d => GetDto(d.userid, d.kinoid, ++orderseq)).ToList();
        }

        /// <summary>
        /// お気に入りテーブルDtoリスト(保存処理)
        /// </summary>
        public static List<tt_afokiniiriDto> GetDtl(string userid, List<string> kinoids)
        {
            int orderseq = 0;
            return kinoids.Select(kinoid => GetDto(userid, kinoid, ++orderseq)).ToList();
        }

        /// <summary>
        /// お気に入りテーブルDto
        /// </summary>
        private static tt_afokiniiriDto GetDto(string userid, string kinoid, int orderseq = 0)
        {
            var dto = new tt_afokiniiriDto();
            dto.userid = userid;          //ユーザーID
            dto.kinoid = kinoid;    //機能ID
            dto.orderseq = orderseq;      //並びシーケンス
            return dto;
        }
    }
}