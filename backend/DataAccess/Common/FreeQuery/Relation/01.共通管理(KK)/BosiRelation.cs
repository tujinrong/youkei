// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索共通ロジック
//             母子保健リレーション定義
// 作成日　　: 2024.01.24
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Interface;
using AIplus.FreeQuery.Join;
using AIplus.FreeQuery.Where;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.標準版;

namespace BCC.Affect.DataAccess
{
    public class BosiRelation : IFrRelation
    {
        //母子区分 1：妊産婦　2：乳幼児
        private string _bosikbn;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="bosikbn">母子区分</param>
        public BosiRelation(string bosikbn)
        {
            _bosikbn = bosikbn;
        }

        /// <summary>
        /// リレーションの取得
        /// </summary>
        /// <param name="itemList">Select項目一覧</param>
        /// <param name="condition">抽出条件</param>
        /// <returns></returns>
        public List<FrTableRelation> GetRelations(List<FrSelectItem> itemList, FrCondition condition, params string[]? paras)
        {
            var list = new List<FrTableRelation>();
            //宛名テーブル(メインテーブル)
            list.Add(new FrTableRelation() { TableID = tt_afatenaDto.TABLE_NAME, TableKeys = new List<FrJoinItem>() });

            if (_bosikbn.Equals(健康増進_実施対象者._1))
            {
                //母子健康手帳交付（固定）テーブル
                list.Add(new FrTableRelation()
                {
                    JoinType = FrEnumJoin.LEFT,
                    TableID = tt_bhnsbosikenkotetyokofuDto.TABLE_NAME,
                    ToTableID = tt_afatenaDto.TABLE_NAME,
                    TableKeys = new List<FrJoinItem>()
                {
                    new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                }
                });
            }

            var tblname = string.Empty;
            var bosikbn = string.Empty;
            var jigyocd = string.Empty;
            var torokunorenban = string.Empty;
            var itemcd = string.Empty;


            if (_bosikbn.Equals(健康増進_実施対象者._1))
            {
                //妊産婦の場合
                var condList = condition.ConditionModel.ConditionList.Where(e => e.TableOrSql.Contains(tt_bhnsfreeDto.TABLE_NAME));

                foreach (var codi in condList)
                {
                    var keycode = codi.KeyCode;
                    var sql = codi.TableOrSql;

                    bosikbn = GetKeyValue(sql, 1);
                    jigyocd = GetKeyValue(sql, 2);
                    torokunorenban = GetKeyValue(sql, 3);
                    itemcd = GetKeyValue(sql, 4);
                    tblname = GetTableId(sql);

                    var rel = new FrTableRelation()
                    {
                        TableName = tt_bhnsfreeDto.TABLE_NAME,
                        TableID = $"{tblname}",
                        ToTableID = tt_afatenaDto.TABLE_NAME,
                        TableKeys = new List<FrJoinItem>()
                    {
                        new FrJoinItem(nameof(tt_afatenaDto.atenano)),

                        new(nameof(tt_bhnsfreeDto.jigyocd)){Value=$"{jigyocd}"},
                        new(nameof(tt_bhnsfreeDto.torokunorenban)){Value=$"{torokunorenban}"},
                        new(nameof(tt_bhnsfreeDto.itemcd)){Value=$"{itemcd}"},
                    }
                    };
                    list.Add(rel);
                }

            } else if (_bosikbn.Equals(健康増進_実施対象者._2))
            {
                //乳幼児の場合
                var condList = condition.ConditionModel.ConditionList.Where(e => e.TableOrSql.Contains(tt_bhnyfreeDto.TABLE_NAME));

                foreach (var codi in condList)
                {
                    var keycode = codi.KeyCode;
                    var sql = codi.TableOrSql;

                    bosikbn = GetKeyValue(sql, 1);
                    jigyocd = GetKeyValue(sql, 2);
                    itemcd = GetKeyValue(sql, 3);
                    tblname = GetTableId(sql);

                    var rel = new FrTableRelation()
                    {
                        TableName = tt_bhnyfreeDto.TABLE_NAME,
                        TableID = $"{tblname}",
                        ToTableID = tt_afatenaDto.TABLE_NAME,
                        TableKeys = new List<FrJoinItem>()
                    {
                        new FrJoinItem(nameof(tt_afatenaDto.atenano)),

                        new(nameof(tt_bhnyfreeDto.jigyocd)){Value=$"{jigyocd}"},
                        new(nameof(tt_bhnyfreeDto.itemcd)){Value=$"{itemcd}"},
                    }
                    };
                    list.Add(rel);
                }
            }

            return list;
        }

        /// <summary>
        /// キー項目値を取得
        /// </summary>
        /// <param name="sql">検索条件</param>
        /// <param name="no">個数</param>
        /// <returns></returns>
        private static string GetKeyValue(string sql, int no)
        {
            var str = string.Empty;
            var strarr = sql.Split("_");
            if(strarr.Length <= no + 1) { return str; }
            str = strarr[no + 1];
            return str;
        }

        /// <summary>
        /// テーブル別名を取得
        /// </summary>
        /// <param name="sql">検索条件</param>
        /// <returns></returns>
        private static string GetTableId(string sql)
        {
            var str = string.Empty;
            var strarr = sql.Split(".");
            str = strarr[0];
            return str;
        }
    }
}