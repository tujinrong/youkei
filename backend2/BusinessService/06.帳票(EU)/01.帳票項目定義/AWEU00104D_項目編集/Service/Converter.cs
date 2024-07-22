// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 項目編集
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00104D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 新規処理
        /// </summary>
        public static List<tm_eudatasourcetableDto> GetDatasourceTableSingleDtl(string datasourceId, string tablealias)
        {
            var dto = new tm_eudatasourcetableDto();
            dto.datasourceid = datasourceId;                         //データソースID
            dto.tablealias = tablealias;                             //テーブル別名
            return new List<tm_eudatasourcetableDto> { dto };
        }

        /// <summary>
        /// 新規処理
        /// </summary>
        public static List<tm_eudatasourcejoinDto> GetDatasourceJoinSingleDtl(string datasourceid, tm_eutablejoinDto tablejoinDto)
        {
            var dto = new tm_eudatasourcejoinDto();
            dto.datasourceid = datasourceid;                        //データソースID
            dto.tablealias = tablejoinDto.tablealias;               //テーブル別名
            dto.kanrentablealias = tablejoinDto.kanrentablealias;   //上位テーブル別名
            dto.ketugosql = tablejoinDto.ketugosql;                 //結合SQL
            dto.jokenflg = tablejoinDto.jokenflg;                   //条件フラグ
            dto.orderseq = tablejoinDto.orderseq;                   //並びシーケンス
            //TODOi
            return new List<tm_eudatasourcejoinDto> { dto };
        }

        /// <summary>
        /// 新規/更新処理
        /// </summary>
        public static tm_eudatasourceitemDto GetDatasourceItemDto(string datasourceid, string sqlcolumn)
        {
            var dto = new tm_eudatasourceitemDto();
            dto.datasourceid = datasourceid;                       //データソースID
            dto.sqlcolumn = sqlcolumn;                             //SQLカラム
            return dto;
        }

        /// <summary>
        /// 新規処理
        /// </summary>
        public static tm_eutableitemDto GetTableItemDto(SaveRequest req, int orderseq)
        {
            var dto = new tm_eutableitemDto();
            dto.sqlcolumn = req.sqlcolumn;                        //SQLカラム
            dto.itemid = req.itemid;                              //項目ID
            dto.itemhyojinm = req.itemhyojinm;                    //表示名称
            dto.orderseq = orderseq;                              //並びシーケンス
            dto.datatype = req.datatype;                          //データ型
            dto.selectflg = false;                                //既定選択フラグ
            dto.usekbn = req.usekbn;                              //使用区分
            dto.itemkbn = req.itemkbn;                            //出力項目区分
            dto.syukeikbn = EnumToStr(req.syukeikbn);             //集計項目区分
            dto.tablealias = req.tablealias;                      //テーブル別名
            dto.tablealias2 = null;                               //テーブル別名２
            dto.mastercd = CNStr(req.mastercd);                   //名称マスタコード
            dto.masterpara = CNStr(req.masterpara);               //メインコード,サブコード
            dto.daibunrui = req.daibunrui;                        //大分類
            dto.tyubunrui = CNStr(req.tyubunrui);                 //中分類
            dto.syobunrui = CNStr(req.syobunrui);                 //小分類
            return dto;
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        public static tm_eutableitemDto GetTableItemDto(SaveRequest req, tm_eutableitemDto dto)
        {
            dto.sqlcolumn = req.sqlcolumn;                       //SQLカラム
            dto.itemid = req.itemid;                             //項目ID
            dto.itemhyojinm = req.itemhyojinm;                   //表示名称
            dto.datatype = req.datatype;                         //データ型
            dto.usekbn = req.usekbn;                             //使用区分
            dto.itemkbn = req.itemkbn;                           //出力項目区分
            dto.syukeikbn = EnumToStr(req.syukeikbn);            //集計項目区分
            dto.tablealias = req.tablealias;                     //テーブル別名
            dto.mastercd = CNStr(req.mastercd);                  //名称マスタコード
            dto.masterpara = CNStr(req.masterpara);              //メインコード,サブコード
            dto.daibunrui = req.daibunrui;                       //大分類
            dto.tyubunrui = CNStr(req.tyubunrui);                //中分類
            dto.syobunrui = CNStr(req.syobunrui);                //小分類
            return dto;
        }
    }
}