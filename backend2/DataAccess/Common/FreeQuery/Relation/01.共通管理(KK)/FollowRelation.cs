// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             フォロー管理リレーション定義
// 作成日　　: 2023.11.28
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Interface;
using AIplus.FreeQuery.Join;
using AIplus.FreeQuery.Where;

namespace BCC.Affect.DataAccess
{
    public class FollowRelation : IFrRelation
    {
        //連絡先の事業コード
        private string _renraku_jigyocd;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="renraku_jigyocd">連絡先の事業コード</param>
        public FollowRelation(string renraku_jigyocd)
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

            //フォロー管理固定情報SQL VIEW
            var followView = new FollowView(condition.ConditionModel.ConditionList);
            var viewJoinType = FrEnumJoin.LEFT;
            if (condition.ConditionModel.ConditionList.Exists(e => e.TableOrSql == followView.TableName))
            {
                viewJoinType = FrEnumJoin.INNER;
            }
            list.Add(new FrTableRelation
            {
                JoinType = viewJoinType,
                TableID = followView.TableName,
                SQL = followView.SQL,
                ToTableID = tt_afatenaDto.TABLE_NAME,
                TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                        },
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

            return list;
        }
    }
}