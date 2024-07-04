// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索共通ロジック
//             健（検）診予定管理リレーション定義
// 作成日　　: 2024.02.14
// 作成者　　: 劉
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
    public class KensinyoyakuRelation : IFrRelation
    {
        private int _nendo;
        private string? _staffid;
        private List<object[]> _keylist;
        private List<object[]> _keylist2;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="keylist">検診事業予約分類キーリスト</param>
        public KensinyoyakuRelation(int nendo, string? staffid, string json, string json2)
        {
            _nendo = nendo;
            _staffid = staffid;
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

            //健（検）診予定担当者テーブル
            if ((condition.ConditionModel.ConditionList.Exists(e => e.TableOrSql == tt_shkensinyotei_staffDto.TABLE_NAME)
                || itemList.Exists(e => e.TableName == tt_shkensinyotei_staffDto.TABLE_NAME)) && (!string.IsNullOrEmpty(_staffid)))
            {
                var relation = new FrTableRelation
                {
                    JoinType = FrEnumJoin.INNER,
                    TableID = tt_shkensinyotei_staffDto.TABLE_NAME,
                    ToTableID = tt_shkensinyoteiDto.TABLE_NAME,
                    TableKeys = new List<FrJoinItem>
                    {
                        new(nameof(tt_shkensinyotei_staffDto.nendo)),
                        new(nameof(tt_shkensinyotei_staffDto.nitteino)),
                        new(nameof(tt_shkensinyotei_staffDto.staffid)){Value=$"{_staffid}"}
                    }
                };
                list.Add(relation);
            }
            //検診予定管理ビュー
            foreach (var key in _keylist)
            {
                var jigyocd = CStr(key[0]);
                var yoyakubunruicd = CStr(key[1]);
                var kensahohocds = ListToCommaStr(_keylist2.Where(e => CStr(e[0]) == jigyocd && CStr(e[1]) == yoyakubunruicd).
                                                            Select(e => CStr(e[2])).ToList());
                var kensinyoyakuView = new KensinyoyakuView(_nendo, jigyocd, yoyakubunruicd, kensahohocds);
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