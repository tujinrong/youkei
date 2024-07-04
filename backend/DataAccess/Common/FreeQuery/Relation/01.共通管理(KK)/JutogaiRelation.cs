// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索共通ロジック
//             住登外者リレーション定義
// 作成日　　: 2023.11.14
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Interface;
using AIplus.FreeQuery.Join;
using AIplus.FreeQuery.Where;

namespace BCC.Affect.DataAccess
{
    public class JutogaiRelation : IFrRelation
    {
        //連絡先の事業コード
        private string _renraku_jigyocd;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="renraku_jigyocd">連絡先の事業コード</param>
        public JutogaiRelation(string renraku_jigyocd)
        {
            _renraku_jigyocd = renraku_jigyocd;
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
            //住登外者情報テーブル(メインテーブル)
            list.Add(new FrTableRelation() { TableID = tt_afjutogaiDto.TABLE_NAME, TableKeys = new List<FrJoinItem>() });

            //【住民基本台帳】支援措置対象者情報テーブル
            list.Add(new FrTableRelation()
            {
                JoinType = FrEnumJoin.LEFT,
                TableID = tt_afsiensotitaisyosyaDto.TABLE_NAME,
                ToTableID = tt_afjutogaiDto.TABLE_NAME,
                TableKeys = new List<FrJoinItem>()
                {
                    new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                }
            });

            //宛名テーブル
            list.Add(new FrTableRelation()
            {
                JoinType = FrEnumJoin.LEFT,
                TableID = tt_afatenaDto.TABLE_NAME,
                ToTableID = tt_afjutogaiDto.TABLE_NAME,
                TableKeys = new List<FrJoinItem>()
                {
                    new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                }
            });
            //連絡先テーブルとの連携関係
            if ((condition.ConditionModel.ConditionList.Exists(e => e.TableOrSql == tt_afrenrakusakiDto.TABLE_NAME)
                || itemList.Exists(e => e.TableName == tt_afrenrakusakiDto.TABLE_NAME)) && (!string.IsNullOrEmpty(_renraku_jigyocd)))
            {
                var renra = new FrTableRelation
                {
                    JoinType = FrEnumJoin.LEFT,
                    TableID = tt_afrenrakusakiDto.TABLE_NAME,
                    ToTableID = tt_afatenaDto.TABLE_NAME,
                    TableKeys = new List<FrJoinItem>
                    {
                        new(nameof(tt_afrenrakusakiDto.atenano)),
                        new(nameof(tt_afrenrakusakiDto.jigyocd)){Value=$"{_renraku_jigyocd}"}
                    }
                };
                list.Add(renra);
            }

            var tblname = string.Empty;
            var hokensidokbn = string.Empty;
            var gyomukbn = string.Empty;
            var mosikomikekkakbn = string.Empty;

            var condList = condition.ConditionModel.ConditionList.Where(e => e.TableOrSql.Contains(tt_kkhokensidofreeDto.TABLE_NAME));
            foreach (var codi in condList)
            {
                var keycode = codi.KeyCode;
                var sql = codi.TableOrSql;

                hokensidokbn = GetKeyValue(sql, 1);
                gyomukbn = GetKeyValue(sql, 2);
                mosikomikekkakbn = GetKeyValue(sql, 3);
                tblname = GetTableId(sql);

                var rel = new FrTableRelation()
                {
                    TableName = tt_kkhokensidofreeDto.TABLE_NAME,
                    TableID = $"{tblname}",
                    ToTableID = tt_afatenaDto.TABLE_NAME,
                    TableKeys = new List<FrJoinItem>()
                    {
                        new FrJoinItem(nameof(tt_afatenaDto.atenano)),

                        new(nameof(tt_kkhokensidofreeDto.hokensidokbn)){Value=$"{hokensidokbn}"},
                        new(nameof(tt_kkhokensidofreeDto.gyomukbn)){Value=$"{gyomukbn}"},
                        new(nameof(tt_kkhokensidofreeDto.mosikomikekkakbn)){Value=$"{mosikomikekkakbn}"},
                    }
                };
                list.Add(rel);
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
            if (strarr.Length <= no + 1) { return str; }
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