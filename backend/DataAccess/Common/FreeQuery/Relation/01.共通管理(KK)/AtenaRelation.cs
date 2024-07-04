// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索共通ロジック
//             受診者リレーション定義
// 作成日　　: 2023.10.03
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Interface;
using AIplus.FreeQuery.Join;
using AIplus.FreeQuery.Where;

namespace BCC.Affect.DataAccess
{
    public class AtenaRelation : IFrRelation
    {
        //連絡先の事業コード
        private string _renraku_jigyocd;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="renraku_jigyocd">連絡先の事業コード</param>
        public AtenaRelation(string renraku_jigyocd)
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

            //【住民基本台帳】住民情報テーブル
            list.Add(new FrTableRelation()
            {
                JoinType = FrEnumJoin.LEFT,
                TableID = tt_afjuminDto.TABLE_NAME,
                ToTableID = tt_afatenaDto.TABLE_NAME,
                TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                        }
            });
            //【個人住民税】個人住民税課税情報
            var atenaKazeiView = new KazeiView();
            list.Add(new FrTableRelation()
            {
                JoinType = FrEnumJoin.LEFT,
                TableID = atenaKazeiView.TableName,
                SQL = atenaKazeiView.SQL,
                ToTableID = tt_afatenaDto.TABLE_NAME,
                TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                        }
            });
            //【個人住民税】納税義務者情報
            var atenaNozeiView = new NozeiView();
            list.Add(new FrTableRelation()
            {
                JoinType = FrEnumJoin.LEFT,
                TableID = atenaNozeiView.TableName,
                SQL = atenaNozeiView.SQL,
                ToTableID = tt_afatenaDto.TABLE_NAME,
                TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                        }
            });
            //【国民健康保険】国保資格情報テーブル
            list.Add(new FrTableRelation()
            {
                JoinType = FrEnumJoin.LEFT,
                TableID = tt_afkokuhoDto.TABLE_NAME,
                ToTableID = tt_afatenaDto.TABLE_NAME,
                TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                        }
            });
            //【後期高齢者医療】被保険者情報テーブル
            list.Add(new FrTableRelation()
            {
                JoinType = FrEnumJoin.LEFT,
                TableID = tt_afkokihokenDto.TABLE_NAME,
                ToTableID = tt_afatenaDto.TABLE_NAME,
                TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                        }
            });
            //【生活保護】生活保護受給情報テーブル
            list.Add(new FrTableRelation()
            {
                JoinType = FrEnumJoin.LEFT,
                TableID = tt_afseihoDto.TABLE_NAME,
                ToTableID = tt_afatenaDto.TABLE_NAME,
                TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                        }
            });
            //【介護保険】被保険者情報テーブル
            list.Add(new FrTableRelation()
            {
                JoinType = FrEnumJoin.LEFT,
                TableID = tt_afkaigoDto.TABLE_NAME,
                ToTableID = tt_afatenaDto.TABLE_NAME,
                TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                        }
            });
            //【障害者福祉】身体障害者手帳等情報テーブル
            list.Add(new FrTableRelation()
            {
                JoinType = FrEnumJoin.LEFT,
                TableID = tt_afsyogaitetyoDto.TABLE_NAME,
                ToTableID = tt_afatenaDto.TABLE_NAME,
                TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                        }
            });
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

            //【個人住民税】個人住民税税額控除情報
            //TODO 控除区分指定
            if (condition.ConditionModel.ConditionList.Exists(e=>e.TableOrSql==KojoView.TABLE_NAME && string.IsNullOrEmpty(e.KeyCode)))
            {
                var atenaKojoView = new KojoView(condition, "");
                list.Add(new FrTableRelation()
                {
                    JoinType = FrEnumJoin.LEFT,
                    TableID = atenaKojoView.TableName,
                    SQL = atenaKojoView.SQL,
                    ToTableID = tt_afatenaDto.TABLE_NAME,
                    TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                        }
                });
            }
            //2023.11.05
            var kojoList = condition.ConditionModel.ConditionList.Where(e => e.TableOrSql.StartsWith($"{KojoView.TABLE_NAME}") && !string.IsNullOrEmpty(e.KeyCode)).ToList();
            //var kojoList = condition.ConditionModel.ConditionList.Where(e => e.TableOrSql.StartsWith($"{KojoView.TABLE_NAME}__")).ToList();
            foreach (var kojocd in kojoList)
            {
                //2023.11.05
                var code = kojocd.KeyCode!;
                //var code = kojocd.TableOrSql.Split('_')[2];
                var atenaKojoView = new KojoView(condition, code);
                list.Add(new FrTableRelation()
                {
                    JoinType = FrEnumJoin.INNER,
                    TableID = kojocd.TableOrSql,
                    SQL = atenaKojoView.SQL,
                    ToTableID = tt_afatenaDto.TABLE_NAME,
                    TableKeys = new List<FrJoinItem>()
                        {
                            new FrJoinItem(nameof(tt_afatenaDto.atenano)),
                        }
                });
            }


            //Where条件にあるキーコードを求める
            //var kojoList = condition.ConditionModel.ConditionList.Where(e => e.TableOrSql == atenaKojoView.TableName).Select(e => e.KeyCode).ToList();
            //foreach (var kojocd in kojoList)
            //{
            //    var rel = new FrTableRelation()
            //    {
            //        TableName = atenaKojoView.TableName,
            //        TableID = $"{atenaKojoView.TableName}_{kojocd}",
            //        ToTableID = tt_afatenaDto.TABLE_NAME,
            //        TableKeys = new List<FrJoinItem>()
            //            {
            //                new FrJoinItem(nameof(tt_afatenaDto.atenano))
            //            }
            //    };
            //    list.Add(rel);
            //}

            return list;
        }
    }
}