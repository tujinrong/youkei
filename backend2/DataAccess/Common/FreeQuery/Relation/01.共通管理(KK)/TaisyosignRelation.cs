// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             各種検診対象者保守リレーション定義
// 作成日　　: 2024.02.05
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Interface;
using AIplus.FreeQuery.Join;
using AIplus.FreeQuery.Where;

namespace BCC.Affect.DataAccess
{
    public class TaisyosignRelation : IFrRelation
    {
        //連絡先の事業コード
        private string _renraku_jigyocd;
        private int _nendo;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="nendo">年度</param>
        public TaisyosignRelation(string renraku_jigyocd, int nendo)
        {
            _renraku_jigyocd = renraku_jigyocd;
            _nendo = nendo;
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
            //検診履歴管理テーブル
            var taisyosignView = new TaisyosginView(_nendo);
            list.Add(new FrTableRelation()
            {
                JoinType = FrEnumJoin.INNER,
                TableID = taisyosignView.TableName,
                SQL = taisyosignView.SQL,
                ToTableID = tt_afatenaDto.TABLE_NAME,
                TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                        }
            });
            return list;
        }
    }
}