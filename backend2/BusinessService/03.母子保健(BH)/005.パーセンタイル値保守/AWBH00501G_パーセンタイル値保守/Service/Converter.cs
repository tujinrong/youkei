// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: パーセンタイル値保守
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.06.01
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWBH00501G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得（乳幼児パーセンタイル値一覧情報取得用）
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            var paras = new List<AiKeyValue>
            {
                new AiKeyValue($"{nameof(tm_bhnyhpasentairuDto.buicd)}_in", GetCd(req.buicd)),         //部位コード
                new AiKeyValue($"{nameof(tm_bhnyhpasentairuDto.sex)}_in", GetCd(req.sex)),             //性別（コード）
            };

            return paras;
        }

        /// <summary>
        /// 乳幼児パーセンタイル値マスタ
        /// </summary>
        public static List<tm_bhnyhpasentairuDto> GetDto(List<tm_bhnyhpasentairuDto> dtl, PasentairuListVM req, string? pasentairucd, int pasentairuti)
        {
            var dto = new tm_bhnyhpasentairuDto() 
            {
                buicd = req.buicd,                          //部位コード
                sex = req.sex,                              //性別（コード）
                month = req.month,                          //月
                date = req.date,                            //日
                pasentairucd = CStr(pasentairucd),          //パーセンタイル値コード'
                pasentairuti = pasentairuti,                //パーセンタイル値
            };

            dtl.Add(dto);
            return dtl;
        }
    }
}