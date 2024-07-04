// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 項目選択
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00103D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 保存処理
        /// </summary>
        public static List<tm_eudatasourceitemDto> GetDatasourceItemDtl(string datasourceId, IEnumerable<tm_eutableitemDto> tableitemDtl)
        {
            return tableitemDtl.Select(x => GetDatasourceItemDto(datasourceId, x)).ToList();
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        public static List<tm_eudatasourcejoinDto> GetDatasourceJoinDtl(string datasourceId, List<tm_eutablejoinDto> tablejoinDtl, HashSet<string> tablealiasSet)
        {
            return tablealiasSet.Where(tablealias => tablejoinDtl.Any(d => d.tablealias == tablealias)).Select(x => GetDatasourceJoinDto(datasourceId, tablejoinDtl, x)).ToList();
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        private static tm_eudatasourcejoinDto GetDatasourceJoinDto(string datasourceId, List<tm_eutablejoinDto> tablejoinDtl, string tablealias)
        {
            var tablejoinDto = tablejoinDtl.First(x => x.tablealias == tablealias);
            var dto = new tm_eudatasourcejoinDto();
            dto.datasourceid = datasourceId;                           //データソースID
            dto.tablealias = tablejoinDto.tablealias;                  //テーブル別名
            dto.kanrentablealias = tablejoinDto.kanrentablealias;      //上位テーブル別名
            dto.ketugosql = tablejoinDto.ketugosql;                    //結合SQL
            dto.jokenflg = tablejoinDto.jokenflg;                      //条件フラグ
            dto.orderseq = tablejoinDto.orderseq;                      //並びシーケンス
            return dto;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        private static tm_eudatasourceitemDto GetDatasourceItemDto(string datasourceId, tm_eutableitemDto itemDto)
        {
            var dto = new tm_eudatasourceitemDto();
            dto.datasourceid = datasourceId;                          //データソースID
            dto.sqlcolumn = itemDto.sqlcolumn;                        //項目ID
            return dto;
        }
    }
}