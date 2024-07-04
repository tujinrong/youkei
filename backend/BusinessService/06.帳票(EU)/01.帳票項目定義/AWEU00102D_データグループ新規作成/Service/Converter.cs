// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: データグループ新規作成
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00102D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 保存処理
        /// </summary>
        public static tm_eudatasourceDto GetDatasourceDto(SaveRequest req, int orderseq)
        {
            var dto = new tm_eudatasourceDto();
            dto.datasourceid = req.datasourceid;                               //データソースID
            dto.datasourcenm = req.datasourcenm;                               //データソース名称
            dto.gyoumucd = DaSelectorService.GetCd(req.gyoumucd);              //業務コード
            dto.orderseq = orderseq;                                           //並び順
            dto.maintablealias = req.maintablealias;                           //メインテーブル別名
            return dto;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        public static List<tm_eudatasourcejoinDto> GetDatasourceJoinDtl(string datasourceid, IEnumerable<tm_eutablejoinDto> tableJoinDtl)
        {
            return tableJoinDtl.Select(x => GetDatasourceJoinDto(datasourceid, x)).ToList();
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        public static List<tm_eudatasourceitemDto> GetDatasourceItemDtl(string datasourceid, IEnumerable<tm_eutableitemDto> tableitemDtl)
        {
            return tableitemDtl.Select(x => GetDatasourceItemDto(datasourceid, x)).ToList();
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        private static tm_eudatasourcejoinDto GetDatasourceJoinDto(string datasourceid, tm_eutablejoinDto tablejoinDto)
        {
            var dto = new tm_eudatasourcejoinDto();
            dto.datasourceid = datasourceid;                                   //データソースID
            dto.tablealias = tablejoinDto.tablealias;                          //テーブル別名
            dto.kanrentablealias = tablejoinDto.kanrentablealias;              //上位テーブル別名
            dto.ketugosql = tablejoinDto.ketugosql;                            //結合SQL
            dto.jokenflg = tablejoinDto.jokenflg;                              //条件フラグ
            dto.orderseq = tablejoinDto.orderseq;                              //並びシーケンス
            return dto;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        private static tm_eudatasourceitemDto GetDatasourceItemDto(string datasourceid, tm_eutableitemDto tableitemDto)
        {
            var dto = new tm_eudatasourceitemDto();
            dto.datasourceid = datasourceid;                                 //データソースID
            dto.sqlcolumn = tableitemDto.sqlcolumn;                          //項目ID
            return dto;
        }
    }
}