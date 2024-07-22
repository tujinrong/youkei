// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             検診リレーション定義
// 作成日　　: 2023.06.12
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Interface;
using AIplus.FreeQuery.Join;
using AIplus.FreeQuery.Where;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.DataAccess
{
    public class KensinRelation : IFrRelation
    {
        //連絡先の事業コード
        private string _renraku_jigyocd;
        private string _jigyocd;
        private Dictionary<string, bool> _seikenDic;
        private Dictionary<string, bool> _rirekiDic;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="renraku_jigyocd">連絡先の事業コード</param>
        /// <param name="jigyocd">事業コード</param>
        /// <param name="seikenDic">項目コードから精密検査フラグDictionary</param>
        /// <param name="rirekiDic">項目コードから経年フラグDictionary</param>
        public KensinRelation(string renraku_jigyocd, string jigyocd, Dictionary<string, bool> seikenDic, Dictionary<string, bool> rirekiDic)
        {
            _renraku_jigyocd = renraku_jigyocd;
            _jigyocd = jigyocd;
            _seikenDic = seikenDic;
            _rirekiDic = rirekiDic;
        }

        /// <summary>
        /// リレーションの取得
        /// </summary>
        /// <param name="itemList">Select項目一覧</param>
        /// <param name="condition">抽出条件</param>
        /// <param name="paras">年度</param>
        /// <returns></returns>
        public List<FrTableRelation> GetRelations(List<FrSelectItem> itemList, FrCondition condition, params string[]? paras)
        {
            if (paras != null)
            {
                return GetRelations(itemList, condition, CInt(paras[0]));
            }

            return GetRelations(itemList, condition);
        }
        /// <summary>
        /// リレーションの取得(全年度の場合)
        /// </summary>
        private List<FrTableRelation> GetRelations(List<FrSelectItem> itemList, FrCondition condition)
        {
            var kensinView = new KensinView(condition, _jigyocd);

            var list = new List<FrTableRelation>()
                //宛名テーブル
                {new FrTableRelation(){TableID = tt_afatenaDto.TABLE_NAME,TableKeys = new List<FrJoinItem>()},
                //検診固定情報SQL VIEW
                {new FrTableRelation()
                    {
                        JoinType= FrEnumJoin.LEFT, TableID = kensinView.TableName, SQL=kensinView.SQL,  ToTableID=tt_afatenaDto.TABLE_NAME, TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                        },
                    }
                },
            };

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

            //フリー項目
            var kFreeList = itemList.Where(e => e.TableName == tt_shfreeDto.TABLE_NAME).Select(e => e.ItemID).ToList();
            //Where条件にあるキーコードを求める
            var kFreeList2 = condition.ConditionModel.ConditionList.Where(e => e.TableOrSql == tt_shfreeDto.TABLE_NAME).Select(e => e.KeyCode).ToList();
            if (kFreeList2.Count > 0)
            {
                var kFreeList3 = kFreeList2.Where(e => kFreeList.Contains(e) == false).ToList();
                if (kFreeList3.Count > 0)
                {
                    kFreeList.AddRange(kFreeList3);
                }
            }

            foreach (var item in kFreeList)
            {
                if (_rirekiDic.ContainsKey(item) == false) continue;
                if (_seikenDic.ContainsKey(item) == false) continue;

                //_rirekiDicがTrueの場合、通常（非通年）とする
                if (_rirekiDic[item] == true)
                {
                    if (_seikenDic[item] == true)
                    {
                        //精密検査
                        var rel = new FrTableRelation()
                        {
                            TableName = tt_shfreeDto.TABLE_NAME,
                            TableID = $"{tt_shfreeDto.TABLE_NAME}_{_jigyocd}_{item}",
                            ToTableID = KensinView.TABLE_NAME,
                            TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(KensinView.jigyocd),
                            new FrJoinItem(nameof(tt_shfreeDto.itemcd)){Value=item},
                            new FrJoinItem(KensinView.atenano),
                            new FrJoinItem(nameof(tt_shfreeDto.kensinkaisu), KensinView.kensinkaisu2),
                        },
                        };
                        list.Add(rel);
                    }
                    else
                    {
                        //一次検査
                        var rel = new FrTableRelation()
                        {
                            TableName = tt_shfreeDto.TABLE_NAME,
                            TableID = $"{tt_shfreeDto.TABLE_NAME}_{_jigyocd}_{item}",
                            ToTableID = KensinView.TABLE_NAME,
                            TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(KensinView.jigyocd),
                            new FrJoinItem(nameof(tt_shfreeDto.itemcd)){Value=item},
                            new FrJoinItem(KensinView.atenano),
                            new FrJoinItem(nameof(tt_shfreeDto.kensinkaisu), KensinView.kensinkaisu1),
                        },
                        };
                        list.Add(rel);
                    }
                }
                else
                {
                    //通年
                    var rel = new FrTableRelation()
                    {
                        TableName = tt_shfreeDto.TABLE_NAME,
                        TableID = $"{tt_shfreeDto.TABLE_NAME}_{_jigyocd}_{item}",
                        ToTableID = KensinView.TABLE_NAME,
                        TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(KensinView.jigyocd),
                            new FrJoinItem(nameof(tt_shfreeDto.itemcd)){Value=item},
                            new FrJoinItem(KensinView.atenano),
                            new FrJoinItem(KensinView.nendo),
                        },
                    };
                    list.Add(rel);
                }
            }

            return list;
        }
        /// <summary>
        /// リレーションの取得(指定年度の場合)
        /// </summary>
        private List<FrTableRelation> GetRelations(List<FrSelectItem> itemList, FrCondition condition, int nendo)
        {
            var kensinView = new KensinView(condition, _jigyocd);

            var relationList = new List<FrTableRelation>()
            {
                //住民VIEW
                new()
                {
                    TableID = tt_afatenaDto.TABLE_NAME,
                    TableKeys = new List<FrJoinItem>()
                },
                //検診固定情報SQL VIEW
                new() {
                    JoinType= FrEnumJoin.LEFT,
                    TableID = kensinView.TableName,
                    SQL=kensinView.SQL,
                    ToTableID=tt_afatenaDto.TABLE_NAME,
                    TableKeys = new List<FrJoinItem>
                    {
                        new(nameof(tt_afatenaDto.atenano)),
                        new(KensinView.nendo)
                        {
                            Value = nendo
                        }
                    }
                }
            };

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
                relationList.Add(renra);
            }

            //フリー項目
            var kFreeList = itemList.Where(e => e.TableName == tt_shfreeDto.TABLE_NAME).Select(e => e.ItemID).ToList();
            //Where条件にあるキーコードを求める
            var kFreeList2 = condition.ConditionModel.ConditionList.Where(e => e.TableOrSql != null
                                                                               && e.TableOrSql.StartsWith(tt_shfreeDto.TABLE_NAME, StringComparison.OrdinalIgnoreCase)).Select(e => e.KeyCode).ToList();
            if (kFreeList2.Any())
            {
                var kFreeList3 = kFreeList2.Where(e => kFreeList.Contains(e) == false).ToList();
                if (kFreeList3.Any())
                {
                    kFreeList.AddRange(kFreeList3);
                }
            }

            foreach (var item in kFreeList)
            {
                if (_rirekiDic.ContainsKey(item) == false) continue;
                if (_seikenDic.ContainsKey(item) == false) continue;

                if (_rirekiDic[item])
                {
                    if (_seikenDic[item])
                    {
                        //精密検査
                        var rel = new FrTableRelation
                        {
                            JoinType = FrEnumJoin.LEFT,
                            TableName = tt_shfreeDto.TABLE_NAME,
                            TableID = $"{tt_shfreeDto.TABLE_NAME}_{_jigyocd}_{item}",
                            ToTableID = KensinView.TABLE_NAME,
                            TableKeys = new List<FrJoinItem>
                            {
                                new(KensinView.jigyocd),
                                new(nameof(tt_shfreeDto.itemcd)){Value=item},
                                new(KensinView.atenano),
                                new(nameof(tt_shfreeDto.kensinkaisu), KensinView.kensinkaisu2),
                                new(KensinView.nendo){Value = nendo},
                            },
                        };
                        relationList.Add(rel);
                    }
                    else
                    {
                        //一次検査
                        var rel = new FrTableRelation
                        {
                            JoinType = FrEnumJoin.LEFT,
                            TableName = tt_shfreeDto.TABLE_NAME,
                            TableID = $"{tt_shfreeDto.TABLE_NAME}_{_jigyocd}_{item}",
                            ToTableID = KensinView.TABLE_NAME,
                            TableKeys = new List<FrJoinItem>
                            {
                                new(KensinView.jigyocd),
                                new(nameof(tt_shfreeDto.itemcd)){Value=item},
                                new(KensinView.atenano),
                                new(nameof(tt_shfreeDto.kensinkaisu), KensinView.kensinkaisu1),
                                new(KensinView.nendo){Value = nendo},
                            }
                        };
                        relationList.Add(rel);
                    }
                }
                else
                {
                    var rel = new FrTableRelation
                    {
                        JoinType = FrEnumJoin.LEFT,
                        TableName = tt_shfreeDto.TABLE_NAME,
                        TableID = $"{tt_shfreeDto.TABLE_NAME}_{_jigyocd}_{item}",
                        ToTableID = KensinView.TABLE_NAME,
                        TableKeys = new List<FrJoinItem>
                        {
                            new(KensinView.jigyocd),
                            new(nameof(tt_shfreeDto.itemcd)){Value=item},
                            new(KensinView.atenano),
                            new(KensinView.nendo){Value = nendo},
                        },
                    };
                    relationList.Add(rel);
                }
            }

            return relationList;
        }
    }
}