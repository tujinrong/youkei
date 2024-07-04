// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票データグループ一覧
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00101G
{
    public class Converter : CmConerterBase
    {
        private const int NM_SUB_CD = (int)((long)EnumNmKbn.EUC業務区分 % 100000000L);
        private static readonly string NM_MAIN_CD = $"{((long)EnumNmKbn.EUC業務区分 - NM_SUB_CD) / 100000000L}";

        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchRequest req)
        {
            var datasourcenm = string.IsNullOrEmpty(req.datasourcenm) ? null : $"%{req.datasourcenm}%";
            return new List<AiKeyValue>
            {
                new($"{nameof(SearchRequest.gyoumucd)}_in", DaSelectorService.GetCd(req.gyoumucd)),    //業務コード
                new($"{nameof(SearchRequest.datasourcenm)}_in", datasourcenm),                         //データソース名称
                new($"{nameof(tm_afmeisyoDto.nmmaincd)}_in", NM_MAIN_CD),                              //名称メインコード
                new($"{nameof(tm_afmeisyoDto.nmsubcd)}_in", NM_SUB_CD)                                 //名称サブコード
            };
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        public static tm_eudatasourceDto GetDataSourceDto(tm_eudatasourceDto dto, SaveRequest req)
        {
            dto.datasourcenm = req.datasourcenm;                                                       //データソース名称
            dto.gyoumucd = DaSelectorService.GetCd(req.gyoumu);                                        //業務コード
            return dto;
        }
    }
}