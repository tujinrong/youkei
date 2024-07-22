// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             保健指導リレーション定義
// 作成日　　: 2024.01.18
// 作成者　　: 
// 変更履歴　:  陳 ビュー追加
// *******************************************************************
using AIplus.FreeQuery;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Interface;
using AIplus.FreeQuery.Join;
using AIplus.FreeQuery.Where;
using static BCC.Affect.DataAccess.DaStrPool;

namespace BCC.Affect.DataAccess
{
    public class SidoRelation : IFrRelation
    {
        private string _renraku_jigyocd;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="sidoDic">項目コードから保健指導フラグDictionary</param>
        public SidoRelation(string renraku_jigyocd)
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
            //宛名テーブル(メインテーブル)
            list.Add(new FrTableRelation() { TableID = tt_afatenaDto.TABLE_NAME, TableKeys = new List<FrJoinItem>() });

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
            
            //保健指導管理固定情報・担当者との絞り込み
            if ((condition.ConditionModel.ConditionList.Exists(e => e.TableOrSql.Contains(SidoView.ViewName))
                || itemList.Exists(e => e.TableName.Contains(SidoView.ViewName)))
                || (condition.ConditionModel.ConditionList.Exists(e => e.TableOrSql.Contains(SidoView.ViewName_1))
                || itemList.Exists(e => e.TableName.Contains(SidoView.ViewName_1)))
                || (condition.ConditionModel.ConditionList.Exists(e => e.TableOrSql.Contains(SidoView.ViewName_2))
                || itemList.Exists(e => e.TableName.Contains(SidoView.ViewName_2)))
                || (condition.ConditionModel.ConditionList.Exists(e => e.TableOrSql.Contains(SidoView.ViewName_3))
                || itemList.Exists(e => e.TableName.Contains(SidoView.ViewName_3)))
                )
            {
                //保健指導管理固定情報SQL VIEW
                var sidoView = new SidoView(condition.ConditionModel.ConditionList);
                //固定情報を絞り込み条件としてINNER JOINする
                var relation = new FrTableRelation
                {
                    JoinType = FrEnumJoin.INNER,
                    TableID = sidoView.TableName,
                    SQL = sidoView.SQL,
                    ToTableID = tt_afatenaDto.TABLE_NAME,
                    TableKeys = new List<FrJoinItem>()
                    {
                        new(nameof(tt_afatenaDto.atenano))
                    }
                };
                list.Add(relation);
            }

            //保健指導申込・結果データとの絞り込み        
            if ((condition.ConditionModel.ConditionList.Exists(e => e.TableOrSql.Contains(SidoView2.ViewName))
                || itemList.Exists(e => e.TableName.Contains(SidoView2.ViewName))))
            {
                var tableIDs = new List<FrConditionItem>().Concat(condition.ConditionModel.ConditionList)
                                                          .Where(e => e.TableOrSql.Contains(SidoView2.ViewName)).Select(e => e.TableOrSql).Distinct().ToList();
                foreach (var tableID in tableIDs)
                {
                    var keys = tableID.Replace($"{SidoView2.ViewName}{UNDERLINE}", string.Empty).Split(UNDERLINE);
                    var hokensidokbn = keys[0];
                    var gyomukbn = keys[1];
                    var mosikomikekkakbn = keys[2];
                    var itemcd = keys[3];
                        
                    var sidoView2 = new SidoView2(condition.ConditionModel.ConditionList, tableID, hokensidokbn, gyomukbn, mosikomikekkakbn, itemcd);

                    //結果情報を絞り込み条件としてINNER JOINする
                    var rel_free = new FrTableRelation
                    {
                        JoinType = FrEnumJoin.INNER,
                        TableID = sidoView2.TableName,
                        SQL = sidoView2.SQL,
                        ToTableID = tt_afatenaDto.TABLE_NAME,
                        TableKeys = new List<FrJoinItem>()
                        {
                            new(nameof(tt_kkhokensidofreeDto.atenano))
                        }
                    };
                    list.Add(rel_free);
                }
            }

            //【住民基本台帳】支援措置対象者情報テーブル
            list.Add(new FrTableRelation()
            {
                JoinType = FrEnumJoin.LEFT,
                TableID = tt_afsiensotitaisyosyaDto.TABLE_NAME,
                ToTableID = tt_afatenaDto.TABLE_NAME,
                TableKeys = new List<FrJoinItem>()
                {
                    new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                }
            });

            var tblname1 = string.Empty;
            var hokensidokbn1 = string.Empty;
            var gyomukbn1 = string.Empty;
            var mosikomikekkakbn1 = string.Empty;
            var itemcd1 = string.Empty;

            var condList = condition.ConditionModel.ConditionList.Where(e => e.TableOrSql.Contains(tt_kkhokensidofreeDto.TABLE_NAME));
            foreach (var codi in condList)
            {
                var keycode = codi.KeyCode;
                var sql = codi.TableOrSql;

                hokensidokbn1 = GetKeyValue(sql, 1);
                gyomukbn1 = GetKeyValue(sql, 2);
                mosikomikekkakbn1 = GetKeyValue(sql, 3);
                itemcd1 = GetKeyValue(sql, 4);
                tblname1 = GetTableId(sql);

                var rel = new FrTableRelation()
                {
                    TableName = tt_kkhokensidofreeDto.TABLE_NAME,
                    TableID = $"{tblname1}",
                    ToTableID = tt_afatenaDto.TABLE_NAME,
                    TableKeys = new List<FrJoinItem>()
                    {
                        new FrJoinItem(nameof(tt_afatenaDto.atenano)),

                        new(nameof(tt_kkhokensidofreeDto.hokensidokbn)){Value=$"{hokensidokbn1}"},
                        new(nameof(tt_kkhokensidofreeDto.gyomukbn)){Value=$"{gyomukbn1}"},
                        new(nameof(tt_kkhokensidofreeDto.mosikomikekkakbn)){Value=$"{mosikomikekkakbn1}"},
                        new(nameof(tt_kkhokensidofreeDto.itemcd)){Value=$"{itemcd1}"},
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