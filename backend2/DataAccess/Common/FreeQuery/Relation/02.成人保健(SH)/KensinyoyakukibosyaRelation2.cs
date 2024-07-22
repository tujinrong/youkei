// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             健（検）診予約希望者管理(予約者一覧画面：予約情報)リレーション定義
// 作成日　　: 2024.02.21
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Interface;
using AIplus.FreeQuery.Join;
using AIplus.FreeQuery.Where;
using Newtonsoft.Json;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.DataAccess
{
    public class KensinyoyakukibosyaRelation2 : IFrRelation
    {
        private int _nendo;
        private List<object[]> _keylist;
        private List<object[]> _keylist2;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="keylist">検診事業予約分類キーリスト</param>
        public KensinyoyakukibosyaRelation2(int nendo, string json, string json2)
        {
            _nendo = nendo;
            _keylist = JsonConvert.DeserializeObject<List<object[]>>(json)!;
            _keylist2 = JsonConvert.DeserializeObject<List<object[]>>(json2)!;
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
            //健（検）診予定テーブル(メインテーブル)
            list.Add(new FrTableRelation() { TableID = tt_shkensinyoteiDto.TABLE_NAME, TableKeys = new List<FrJoinItem>() });

            //定員情報(全体)
            var view1 = new KensinyoyakuView2(_nendo);
            list.Add(new FrTableRelation()
            {
                JoinType = FrEnumJoin.LEFT,
                TableID = view1.TableName,
                SQL = view1.SQL,
                ToTableID = tt_shkensinyoteiDto.TABLE_NAME,
                TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_shkensinyoteiDto.nitteino)),
                        }
            });

            //検診予定希望者管理ビュー
            foreach (var key in _keylist)
            {
                var jigyocd = CStr(key[0]);
                var yoyakubunruicd = CStr(key[1]);
                var kensahohocds = ListToCommaStr(_keylist2.Where(e => CStr(e[0]) == jigyocd && CStr(e[1]) == yoyakubunruicd).
                                                            Select(e => CStr(e[2])).ToList());
                var kensinyoyakuView = new KensinyoyakuView3(_nendo, jigyocd, yoyakubunruicd, kensahohocds);
                list.Add(new FrTableRelation()
                {
                    JoinType = FrEnumJoin.LEFT,
                    TableID = $"{kensinyoyakuView.TableName}{DaStrPool.UNDERLINE}{jigyocd}{DaStrPool.UNDERLINE}{yoyakubunruicd}",
                    SQL = kensinyoyakuView.SQL,
                    ToTableID = tt_shkensinyoteiDto.TABLE_NAME,
                    TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_shkensinyoteiDto.nitteino)),
                        }
                });
            }

            return list;
        }
    }
}