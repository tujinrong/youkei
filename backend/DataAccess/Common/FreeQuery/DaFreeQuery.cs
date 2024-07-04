// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索共通ロジック
//
// 作成日　　: 2023.07.04
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Join;
using AIplus.FreeQuery.Where;
using Newtonsoft.Json;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.標準版;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.DataAccess
{
    public static class DaFreeQuery
    {
        /// <summary>
        /// 成人保健(検診)の一覧検索
        /// </summary>
        /// <param name="db"></param>
        /// <param name="nendo">検索年度</param>
        /// <param name="jigyocd">事業コード</param>
        /// <param name="condition">検索条件</param>
        /// <param name="orderColumn">画面指定並び順</param>
        /// <param name="noCheck">件数チェック：暫定使用しない=>true</param>
        /// <returns></returns>
        public static FrResult GetKensinQuery(DaDbContext db, string renraku_jigyocd, int nendo, string jigyocd, FrCondition condition, int orderColumn, bool noCheck)
        {
            var query = new FrQuery();
            //検索対象項目
            List<FrSelectItem> itemList = new()
            {
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano)),              //宛名番号
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_yusen)),          //氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_kana_yusen)),     //カナ氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.sex)),                  //性別
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd)),                 //生年月日
                new FrSelectItem(@$"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs1)} || 
                                    {tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs2)}","adrs"),  //住所
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.gyoseikucd)),           //行政区コード
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.juminkbn)),             //住民区分
                new FrSelectItem(KensinView.TABLE_NAME, KensinView.jissiymd1),                          //実施日(一次)
                new FrSelectItem(KensinView.TABLE_NAME, KensinView.jissiymd2),                          //実施日(精密)
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.siensotikbn)),          //支援措置区分

                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.jutokbn)),              //住登区分
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyoflg)),        //生年月日_不詳フラグ
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyohyoki)),      //生年月日_不詳表記
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.adrs1)),                //住所1
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.adrs2)),                //住所2
                new FrSelectItem(KensinView.TABLE_NAME, KensinView.kensinkaisu),                        //検診回数
            };
            //デフォルト並び順
            List<FrOrderItem> defaultOrderList = new()
            {
                new FrOrderItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano), FrEnumOrder.ASC)
            };
            //優先順最下位の固定並び順
            List<FrOrderItem> fixedOrderList = new()
            {
                new FrOrderItem(KensinView.TABLE_NAME, KensinView.kensinkaisu, FrEnumOrder.DESC)
            };
            //フリー項目一覧
            List<tm_shfreeitemDto> freeItemList = DaFreeItemService.GetKensinList(db, jigyocd);

            //検診関連テーブル関係
            var relations = DaFrRelationFactory.GetRelation(Enum特殊一覧検索機能.AWSH001, freeItemList, renraku_jigyocd, jigyocd).GetRelations(itemList, condition, nendo.ToString());
            //DBデータ取得
            return query.GetQuery(db.Session, relations, itemList, condition, defaultOrderList, orderColumn, noCheck, fixedOrderList);
        }

        /// <summary>
        /// 住民・住登外の一覧検索
        /// </summary>
        /// <param name="db"></param>
        /// <param name="condition">検索条件</param>
        /// <param name="orderColumn">画面指定並び順</param>
        /// <param name="noCheck">件数チェック：暫定使用しない=>true</param>
        /// <returns></returns>
        public static FrResult GetAtenaQuery(DaDbContext db, string renraku_jigyocd, FrCondition condition, int orderColumn, bool noCheck)
        {
            var query = new FrQuery();
            //検索対象項目
            List<FrSelectItem> itemList = new()
            {
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano)),              //宛名番号
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_yusen)),          //氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_kana_yusen)),     //カナ氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.sex)),                  //性別
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd)),                 //生年月日
                new FrSelectItem(@$"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs1)} || 
                                    {tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs2)}","adrs"),  //住所
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.gyoseikucd)),           //行政区コード
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.juminkbn)),             //住民区分
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.siensotikbn)),          //支援措置区分

                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.jutokbn)),              //住登区分
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyoflg)),        //生年月日_不詳フラグ
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyohyoki)),      //生年月日_不詳表記
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.adrs1)),                //住所1
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.adrs2)),                //住所2
            };
            //デフォルト並び順
            List<FrOrderItem> defaultOrderList = new()
            {
                new FrOrderItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano), FrEnumOrder.ASC)
            };

            //住民・住登外関連テーブル関係
            var relations = DaFrRelationFactory.GetRelation(Enum特殊一覧検索機能.AWKK00101G, null, renraku_jigyocd).GetRelations(itemList, condition);
            //DBデータ取得
            return query.GetQuery(db.Session, relations, itemList, condition, defaultOrderList, orderColumn, noCheck);
        }

        /// <summary>
        /// フォロー管理の一覧検索
        /// </summary>
        /// <param name="db"></param>
        /// <param name="condition">検索条件</param>
        /// <param name="orderColumn">画面指定並び順</param>
        /// <param name="noCheck">件数チェック：暫定使用しない=>true</param>
        /// <returns></returns>
        public static FrResult GetFollowQuery(DaDbContext db, string renraku_jigyocd, FrCondition condition, int orderColumn, bool noCheck)
        {
            var query = new FrQuery();
            //検索対象項目
            List<FrSelectItem> itemList = new()
            {
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano)),              //宛名番号
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_yusen)),          //氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_kana_yusen)),     //カナ氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.sex)),                  //性別
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd)),                 //生年月日
                new FrSelectItem(@$"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs1)} || 
                                    {tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs2)}","adrs"),  //住所
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.gyoseikucd)),           //行政区コード
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.juminkbn)),             //住民区分
                new FrSelectItem(FollowView.TABLE_NAME, FollowView.followyoteiymd),                     //フォロー予定日
                new FrSelectItem(FollowView.TABLE_NAME, FollowView.followjissiymd),                     //フォロー実施日
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.siensotikbn)),          //支援措置区分

                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.jutokbn)),              //住登区分
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyoflg)),        //生年月日_不詳フラグ
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyohyoki)),      //生年月日_不詳表記
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.adrs1)),                //住所1
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.adrs2)),                //住所2
            };
            //デフォルト並び順
            List<FrOrderItem> defaultOrderList = new()
            {
                new FrOrderItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano), FrEnumOrder.ASC)
            };

            //フォロー管理関連テーブル関係
            var relations = DaFrRelationFactory.GetRelation(Enum特殊一覧検索機能.AWKK00401G, null, renraku_jigyocd).GetRelations(itemList, condition);
            //DBデータ取得
            return query.GetQuery(db.Session, relations, itemList, condition, defaultOrderList, orderColumn, noCheck);
        }

        /// <summary>
        /// 帳票発行対象外者管理の一覧検索
        /// </summary>
        /// <param name="db"></param>
        /// <param name="condition">検索条件</param>
        /// <param name="orderColumn">画面指定並び順</param>
        /// <param name="noCheck">件数チェック：暫定使用しない=>true</param>
        /// <returns></returns>
        public static FrResult GetTaisyogaiQuery(DaDbContext db, string renraku_jigyocd, FrCondition condition, int orderColumn, bool noCheck)
        {
            var query = new FrQuery();
            //検索対象項目
            List<FrSelectItem> itemList = new()
            {
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano)),              //宛名番号
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_yusen)),          //氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_kana_yusen)),     //カナ氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.sex)),                  //性別
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd)),                 //生年月日
                new FrSelectItem(@$"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs1)} || 
                                    {tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs2)}","adrs"),  //住所
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.gyoseikucd)),           //行政区コード
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.juminkbn)),             //住民区分
                new FrSelectItem(TaisyogaiView2.TABLE_NAME, TaisyogaiView2.taisyogaikbn),               //対象外者区分
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.siensotikbn)),          //支援措置区分

                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.jutokbn)),              //住登区分
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyoflg)),        //生年月日_不詳フラグ
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyohyoki)),      //生年月日_不詳表記
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.adrs1)),                //住所1
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.adrs2)),                //住所2
            };
            //デフォルト並び順
            List<FrOrderItem> defaultOrderList = new()
            {
                new FrOrderItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano), FrEnumOrder.ASC)
            };

            //帳票発行対象外者管理関連テーブル関係
            var relations = DaFrRelationFactory.GetRelation(Enum特殊一覧検索機能.AWKK01001G, null, renraku_jigyocd).GetRelations(itemList, condition);
            //DBデータ取得
            return query.GetQuery(db.Session, relations, itemList, condition, defaultOrderList, orderColumn, noCheck);
        }

        /// <summary>
        /// 各種検診対象者保守の一覧検索
        /// </summary>
        /// <param name="db"></param>
        /// <param name="condition">検索条件</param>
        /// <param name="orderColumn">画面指定並び順</param>
        /// <param name="noCheck">件数チェック：暫定使用しない=>true</param>
        /// <returns></returns>
        public static FrResult GetTaisyosignQuery(DaDbContext db, string renraku_jigyocd, int nendo, FrCondition condition, int orderColumn, bool noCheck)
        {
            var query = new FrQuery();
            //検索対象項目
            List<FrSelectItem> itemList = new()
            {
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano)),              //宛名番号
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_yusen)),          //氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_kana_yusen)),     //カナ氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.sex)),                  //性別
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd)),                 //生年月日
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.juminkbn)),             //住民区分
                new FrSelectItem(@$"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs1)} || 
                                    {tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs2)}","adrs"),  //住所
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.siensotikbn)),          //支援措置区分

                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.jutokbn)),              //住登区分
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyoflg)),        //生年月日_不詳フラグ
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyohyoki)),      //生年月日_不詳表記
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.adrs1)),                //住所1
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.adrs2)),                //住所2
            };
            //デフォルト並び順
            List<FrOrderItem> defaultOrderList = new()
            {
                new FrOrderItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano), FrEnumOrder.ASC)
            };

            //各種検診対象者保守関連テーブル関係
            var relations = DaFrRelationFactory.GetRelation(Enum特殊一覧検索機能.AWSH00302G, null, renraku_jigyocd, nendo.ToString()).GetRelations(itemList, condition);
            //DBデータ取得
            return query.GetQuery(db.Session, relations, itemList, condition, defaultOrderList, orderColumn, noCheck);
        }

        /// <summary>
        /// 検診予約の一覧検索
        /// </summary>
        /// <param name="db"></param>
        /// <param name="condition">検索条件</param>
        /// <param name="orderColumn">画面指定並び順</param>
        /// <param name="noCheck">件数チェック：暫定使用しない=>true</param>
        /// <returns></returns>
        public static FrResult GetKensinYoyakuQuery(DaDbContext db, int nendo, string? staffid, List<object[]> keyList, List<object[]> keyList2,
                                                    FrCondition condition, int orderColumn, bool noCheck)
        {
            var query = new FrQuery();
            //検索対象項目
            List<FrSelectItem> itemList = new()
            {
                new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.nitteino),"日程番号", null),            //日程番号
                new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.jigyocd),"事業名", null),               //成人健（検）診予約日程事業コード
                new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.yoteiymd ),"実施予定日", null),         //実施予定日
                new FrSelectItem(@$"{tt_shkensinyoteiDto.TABLE_NAME}.{nameof(tt_shkensinyoteiDto.tmf)} || 
                                    {tt_shkensinyoteiDto.TABLE_NAME}.{nameof(tt_shkensinyoteiDto.tmt)}","time","時間", null),     //開始時間～終了時間
                new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.kaijocd),"会場", null),                 //会場コード
                new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.kikancd),"医療機関", null),             //医療機関コード
                new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.teiin),"定員(全体)", null)              //定員(全体)
            };
            //予約設定状況：定員が0以上「○」で表示
            foreach (var r in keyList)
            {
                itemList.Add(new FrSelectItem(KensinyoyakuView.TABLE_NAME, KensinyoyakuView.useflg, CStr(r[2]),
                                                $"{CStr(r[0])}{DaStrPool.UNDERLINE}{CStr(r[1])}"));
            }

            itemList.Add(new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.tmf)));                      //開始時間
            itemList.Add(new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.tmt)));                      //終了時間

            //デフォルト並び順
            List<FrOrderItem> defaultOrderList = new()
            {
                new FrOrderItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.nitteino), FrEnumOrder.ASC)
            };
            //検診事業予約分類キー
            var list = keyList.Select(e => new object[] { e[0], e[1] }).ToList();
            string json = JsonConvert.SerializeObject(list);
            string json2 = JsonConvert.SerializeObject(keyList2);

            //検診予約関連テーブル関係
            var relations = DaFrRelationFactory.GetRelation(Enum特殊一覧検索機能.AWSH00401G, null, CStr(nendo), CStr(staffid), json, json2).GetRelations(itemList, condition);
            //DBデータ取得
            return query.GetQuery(db.Session, relations, itemList, condition, defaultOrderList, orderColumn, noCheck);
        }

        /// <summary>
        /// 検診予約希望者の一覧検索(日程一覧画面)
        /// </summary>
        /// <param name="db"></param>
        /// <param name="condition">検索条件</param>
        /// <param name="orderColumn">画面指定並び順</param>
        /// <param name="noCheck">件数チェック：暫定使用しない=>true</param>
        /// <returns></returns>
        public static FrResult GetKensinYoyakuPersonQuery(DaDbContext db, int nendo, string? staffid, List<object[]> keyList, List<object[]> keyList2,
                                                    FrCondition condition, int orderColumn, bool noCheck)
        {
            var query = new FrQuery();
            //検索対象項目
            List<FrSelectItem> itemList = new()
            {
                new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.nitteino),"日程番号", null),
                new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.teiin),"定員", null)
            };
            //予約状況
            foreach (var r in keyList)
            {
                itemList.Add(new FrSelectItem(KensinyoyakuView3.TABLE_NAME, KensinyoyakuView3.naiyo, CStr(r[2]),
                                                $"{CStr(r[0])}{DaStrPool.UNDERLINE}{CStr(r[1])}"));
            }

            itemList.Add(new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.jigyocd)));    //成人健（検）診予約日程事業コード
            itemList.Add(new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.tmf)));      //開始時間
            itemList.Add(new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.tmt)));      //終了時間
            itemList.Add(new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.kikancd)));    //医療機関コード
            itemList.Add(new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.yoteiymd)));   //実施予定日
            itemList.Add(new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.kaijocd)));    //会場コード
            itemList.Add(new FrSelectItem(KensinyoyakustaffView.TABLE_NAME, KensinyoyakustaffView.staffidnms));     //担当者
            itemList.Add(new FrSelectItem(KensinyoyakuView2.TABLE_NAME, KensinyoyakuView2.ct1));                    //予約合計人数(全体)
            itemList.Add(new FrSelectItem(KensinyoyakuView2.TABLE_NAME, KensinyoyakuView2.ct2));                    //キャンセル待ち人数(全体)

            //予約状況
            foreach (var r in keyList)
            {
                //予約申込人数
                itemList.Add(new FrSelectItem(KensinyoyakuView3.TABLE_NAME, KensinyoyakuView3.ct1, $"{CStr(r[0])}{DaStrPool.UNDERLINE}{CStr(r[1])}"));
                //キャンセル待ち人数
                itemList.Add(new FrSelectItem(KensinyoyakuView3.TABLE_NAME, KensinyoyakuView3.ct2, $"{CStr(r[0])}{DaStrPool.UNDERLINE}{CStr(r[1])}"));
                //定員
                itemList.Add(new FrSelectItem(KensinyoyakuView3.TABLE_NAME, KensinyoyakuView3.ct3, $"{CStr(r[0])}{DaStrPool.UNDERLINE}{CStr(r[1])}"));
            }

            //デフォルト並び順
            List<FrOrderItem> defaultOrderList = new()
            {
                new FrOrderItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.nitteino), FrEnumOrder.ASC)
            };
            //検診事業予約分類キー
            var list = keyList.Select(e => new object[] { e[0], e[1] }).ToList();
            string json = JsonConvert.SerializeObject(list);
            string json2 = JsonConvert.SerializeObject(keyList2);

            //検診予約関連テーブル関係
            var relations = DaFrRelationFactory.GetRelation(Enum特殊一覧検索機能.AWSH00402G_1, null, CStr(nendo), CStr(staffid), json, json2).GetRelations(itemList, condition);
            //DBデータ取得
            return query.GetQuery(db.Session, relations, itemList, condition, defaultOrderList, orderColumn, noCheck);
        }

        /// <summary>
        /// 検診予約希望者の一覧検索(予約者一覧画面：予約情報)
        /// </summary>
        /// <param name="db"></param>
        /// <param name="condition">検索条件</param>
        /// <returns></returns>
        public static FrResult GetKensinYoyakuPersonQuery2(DaDbContext db, int nendo, List<object[]> keyList, List<object[]> keyList2, FrCondition condition)
        {
            var query = new FrQuery();
            //検索対象項目
            List<FrSelectItem> itemList = new()
            {
                new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.nitteino)), //日程番号
                new FrSelectItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.teiin)),    //定員(全体)
                new FrSelectItem(KensinyoyakuView2.TABLE_NAME, KensinyoyakuView2.ct1),                  //予約合計人数(全体)
                new FrSelectItem(KensinyoyakuView2.TABLE_NAME, KensinyoyakuView2.ct2)                   //キャンセル待ち人数(全体)
            };

            //予約状況
            foreach (var r in keyList)
            {
                //予約申込人数
                itemList.Add(new FrSelectItem(KensinyoyakuView3.TABLE_NAME, KensinyoyakuView3.ct1, $"{CStr(r[0])}{DaStrPool.UNDERLINE}{CStr(r[1])}"));
                //キャンセル待ち人数
                itemList.Add(new FrSelectItem(KensinyoyakuView3.TABLE_NAME, KensinyoyakuView3.ct2, $"{CStr(r[0])}{DaStrPool.UNDERLINE}{CStr(r[1])}"));
                //定員
                itemList.Add(new FrSelectItem(KensinyoyakuView3.TABLE_NAME, KensinyoyakuView3.ct3, $"{CStr(r[0])}{DaStrPool.UNDERLINE}{CStr(r[1])}"));
            }

            //デフォルト並び順
            List<FrOrderItem> defaultOrderList = new()
            {
                new FrOrderItem(tt_shkensinyoteiDto.TABLE_NAME, nameof(tt_shkensinyoteiDto.nitteino), FrEnumOrder.ASC)
            };
            //検診事業予約分類キー
            var list = keyList.Select(e => new object[] { e[0], e[1] }).ToList();
            string json = JsonConvert.SerializeObject(list);
            string json2 = JsonConvert.SerializeObject(keyList2);

            //検診予約関連テーブル関係
            var relations = DaFrRelationFactory.GetRelation(Enum特殊一覧検索機能.AWSH00402G_2, null, CStr(nendo), json, json2).GetRelations(itemList, condition);
            //DBデータ取得
            return query.GetQuery(db.Session, relations, itemList, condition, defaultOrderList, 0, true);
        }

        /// <summary>
        /// 検診予約希望者の一覧検索(予約者一覧画面：予約者情報)
        /// </summary>
        /// <param name="db"></param>
        /// <param name="condition">検索条件</param>
        /// <returns></returns>
        public static FrResult GetKensinYoyakuPersonQuery3(DaDbContext db, int nendo, int nitteino, List<object[]> keyList, List<object[]> keyList2, FrCondition condition)
        {
            var query = new FrQuery();
            //検索対象項目
            List<FrSelectItem> itemList = new()
            {
                new FrSelectItem(tt_shkensinyoyakukibosyaDto.TABLE_NAME, nameof(tt_shkensinyoyakukibosyaDto.yoyakuno),"予約番号", null),    //予約番号
                new FrSelectItem(tt_shkensinyoyakukibosyaDto.TABLE_NAME, nameof(tt_shkensinyoyakukibosyaDto.atenano),"宛名番号", null),     //宛名番号
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_yusen),"氏名", null),                                 //氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_kana_yusen),"カナ氏名", null),                        //カナ氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.sex),"性別", null),                                         //性別
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd),"生年月日", null),                                    //生年月日
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.juminkbn),"住民区分", null)                                 //住民区分
            };

            //予約状況
            foreach (var r in keyList)
            {
                //待機フラグ
                itemList.Add(new FrSelectItem(KensinyoyakuView5.TABLE_NAME, KensinyoyakuView5.taikiflg, CStr(r[2]),
                                                $"{CStr(r[0])}{DaStrPool.UNDERLINE}{CStr(r[1])}"));
            }

            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.siensotikbn), "警告内容", null));  //警告内容
            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyoflg)));                  //生年月日_不詳フラグ
            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyohyoki)));                //生年月日_不詳表記

            //デフォルト並び順
            List<FrOrderItem> defaultOrderList = new()
            {
                new FrOrderItem(tt_shkensinyoyakukibosyaDto.TABLE_NAME, nameof(tt_shkensinyoyakukibosyaDto.yoyakuno), FrEnumOrder.ASC)
            };
            //検診事業予約分類キー
            var list = keyList.Select(e => new object[] { e[0], e[1] }).ToList();
            string json = JsonConvert.SerializeObject(list);
            string json2 = JsonConvert.SerializeObject(keyList2);

            //検診予約関連テーブル関係
            var relations = DaFrRelationFactory.GetRelation(Enum特殊一覧検索機能.AWSH00402G_3, null, CStr(nendo), CStr(nitteino), json, json2).GetRelations(itemList, condition);
            //DBデータ取得
            return query.GetQuery(db.Session, relations, itemList, condition, defaultOrderList, 0, true);
        }

        /// <summary>
        /// 住登外者の一覧検索
        /// </summary>
        /// <param name="db"></param>
        /// <param name="condition">検索条件</param>
        /// <param name="orderColumn">画面指定並び順</param>
        /// <param name="noCheck">件数チェック：暫定使用しない=>true</param>
        /// <returns></returns>
        public static FrResult GetJutogaiQuery(DaDbContext db, string renraku_jigyocd, FrCondition condition, int orderColumn, bool noCheck)
        {
            var query = new FrQuery();
            //検索対象項目
            List<FrSelectItem> itemList = new()
            {   //住登外者情報テーブルの項目
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.atenano), null),                          //宛名番号
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.rirekino), null),                         //履歴番号
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.stopflg), null),                          //削除
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.simei_yusen), null),                      //氏名
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.simei_kana_yusen), null),                 //カナ氏名
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.sexhyoki), null),                         //性別
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.jutogaisyasyubetu), null),                //住民種別コード
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.jutogaisyajotai), null),                  //住民状態コード
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.bymd), null),                             //生年月日
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.bymd_fusyoflg), null),                    //生年月日_不詳フラグ
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.bymd_fusyohyoki), null),                  //生年月日_不詳表記
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.adrs_todofuken), null),                   //住所_都道府県
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.adrs_sikunm), null),                      //住所_市区郡町村名
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.adrs_tyoaza), null),                      //住所_町字
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.adrs_bantihyoki), null),                  //住所_番地号表記
                new FrSelectItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.adrs_katagaki), null),                    //住所_方書

                //宛名テーブルの項目
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.setaino), null),                              //世帯番号
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.personalno), null),                           //個人番号
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.jutokbn), null),                              //住登区分

                //【住民基本台帳】支援措置対象者情報テーブルの項目
                new FrSelectItem(tt_afsiensotitaisyosyaDto.TABLE_NAME, nameof(tt_afsiensotitaisyosyaDto.siensotikbn), null),  //支援措置区分
            };
            //デフォルト並び順
            List<FrOrderItem> defaultOrderList = new()
            {
                new FrOrderItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.atenano), FrEnumOrder.ASC),
                new FrOrderItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.saisinflg), FrEnumOrder.DESC),
                new FrOrderItem(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.rirekino), FrEnumOrder.DESC)
            };

            //住登外者関連テーブル関係
            var relations = DaFrRelationFactory.GetRelation(Enum特殊一覧検索機能.AWKK00111G, null, renraku_jigyocd).GetRelations(itemList, condition);

            //DBデータ取得
            return query.GetQuery(db.Session, relations, itemList, condition, defaultOrderList, orderColumn, noCheck);
        }

        /// <summary>
        /// 住民の一覧検索
        /// </summary>
        /// <param name="db"></param>
        /// <param name="condition">検索条件</param>
        /// <param name="orderColumn">画面指定並び順</param>
        /// <param name="noCheck">件数チェック：暫定使用しない=>true</param>
        /// <returns></returns>
        public static FrResult GetSidoQuery(DaDbContext db, string renraku_jigyocd, FrCondition condition, int orderColumn, bool noCheck)
        {
            var query = new FrQuery();
            //検索対象項目
            List<FrSelectItem> itemList = new()
            {
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano)),              //宛名番号
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_yusen)),          //氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_kana_yusen)),     //カナ氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.sex)),                  //性別
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd)),                 //生年月日
                new FrSelectItem(@$"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs1)} || 
                                    {tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs2)}","adrs"),  //住所
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.gyoseikucd)),           //行政区コード
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.juminkbn)),             //住民区分
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.siensotikbn)),          //支援措置区分

                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.jutokbn)),              //住登区分
                //TODO 仕様変更UP208により削除
                //new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.sexhyoki)),             //性別表記
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyoflg)),        //生年月日_不詳フラグ
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyohyoki)),      //生年月日_不詳表記
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.adrs1)),                //住所1
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.adrs2)),                //住所2
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano)),              //宛名番号（ソート用）
                
            };

            //宛名番号毎表示する
            itemList[0].TableID = $"DISTINCT {itemList[0].TableID}";

            //デフォルト並び順
            List<FrOrderItem> defaultOrderList = new()
            {
                new FrOrderItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano), FrEnumOrder.ASC),
            };

            ////優先順最下位の固定並び順
            List<FrOrderItem> fixedOrderList = new();

            //フリー項目一覧
            List<tm_kksidofreeitemDto> freeItemList = DaFreeItemService.GetSidoList(db, Enum項目用途区分.集団以外);

            //関連テーブル関係
            var relations = DaFrRelationFactory.GetRelation(Enum特殊一覧検索機能.AWKK00301G, freeItemList, renraku_jigyocd).GetRelations(itemList, condition);

            //DBデータ取得
            return query.GetQuery(db.Session, relations, itemList, condition, defaultOrderList, orderColumn, noCheck, fixedOrderList);
        }

        /// <summary>
        /// 母子の一覧検索
        /// </summary>
        /// <param name="db"></param>
        /// <param name="condition">検索条件</param>
        /// <param name="orderColumn">画面指定並び順</param>
        /// <param name="noCheck">件数チェック：暫定使用しない=>true</param>
        /// <returns></returns>
        public static FrResult GetBosiQuery(DaDbContext db, string bhsyurui, FrCondition condition, int orderColumn, bool noCheck)
        {
            var query = new FrQuery();


            //検索対象項目
            List<FrSelectItem> itemList = new();

            //表示項目
            //宛名テーブルの項目
            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano)));            //宛名番号
            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_yusen)));        //氏名
            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_kana_yusen)));   //カナ氏名
            //TODO 仕様変更UP208により性別表記の取得方法変更
            //itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.sexhyoki)));         //性別表記
            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.sex)));                //性別（コード）
            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd)));               //生年月日
            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.tosi_gyoseikucd)));    //指定都市_行政区等コード
            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.juminkbn)));           //住民区分コード
            if (bhsyurui.Equals(健康増進_実施対象者._1))
            {
                //妊産婦の場合
                //（母子健康手帳交付（固定）テーブルの項目）
                itemList.Add(new FrSelectItem(tt_bhnsbosikenkotetyokofuDto.TABLE_NAME, nameof(tt_bhnsbosikenkotetyokofuDto.bositetyokofuno)));  //母子手帳番号
                itemList.Add(new FrSelectItem(tt_bhnsbosikenkotetyokofuDto.TABLE_NAME, nameof(tt_bhnsbosikenkotetyokofuDto.torokuno)));   //登録番号
            }
            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.siensotikbn)));        //支援措置区分

            //非表示項目
            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.personalno)));         //個人番号
            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyoflg)));      //生年月日_不詳フラグ
            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyohyoki)));    //生年月日_不詳表記
            itemList.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano)));            //宛名番号（ソート用）

            //宛名番号毎表示する
            itemList[0].TableID = $"DISTINCT {itemList[0].TableID}";

            //デフォルト並び順
            List<FrOrderItem> defaultOrderList = new()
            {
                new FrOrderItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano), FrEnumOrder.ASC),
            };

            //優先順最下位の固定並び順
            List<FrOrderItem> fixedOrderList = new();

            //母子関連テーブル関係
            var relations = DaFrRelationFactory.GetRelation(Enum特殊一覧検索機能.Bosi, null, bhsyurui).GetRelations(itemList, condition);

            //DBデータ取得
            return query.GetQuery(db.Session, relations, itemList, condition, defaultOrderList, orderColumn, noCheck, fixedOrderList);
        }


        /// <summary>
        /// 予防接種の一覧検索
        /// </summary>
        /// <param name="db"></param>
        /// <param name="condition">検索条件</param>
        /// <param name="orderColumn">画面指定並び順</param>
        /// <param name="noCheck">件数チェック：暫定使用しない=>true</param>
        /// <returns></returns>
        public static FrResult GetSessyuQuery(DaDbContext db, FrCondition condition, int orderColumn, bool noCheck)
        {
            var query = new FrQuery();
            //検索対象項目
            List<FrSelectItem> itemList = new()
            {
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano)),              //宛名番号
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_yusen)),          //氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_kana_yusen)),     //カナ氏名
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.sex)),                  //性別
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd)),                 //生年月日
                new FrSelectItem(@$"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs1)} || 
                                    {tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs2)}","adrs"),  //住所
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.gyoseikucd)),           //行政区コード
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.juminkbn)),             //住民区分
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.siensotikbn)),          //支援措置区分

                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.jutokbn)),              //住登区分
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyoflg)),        //生年月日_不詳フラグ
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd_fusyohyoki)),      //生年月日_不詳表記
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.adrs1)),                //住所1
                new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.adrs2)),                //住所2
            };
            //デフォルト並び順
            List<FrOrderItem> defaultOrderList = new()
            {
                new FrOrderItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano), FrEnumOrder.ASC)
            };

            var relations = new List<FrTableRelation>();

            //宛名テーブル(メインテーブル)
            relations.Add(new FrTableRelation() { TableID = tt_afatenaDto.TABLE_NAME, TableKeys = new List<FrJoinItem>() });

            //DBデータ取得
            return query.GetQuery(db.Session, relations, itemList, condition, defaultOrderList, orderColumn, noCheck);
        }
    }
}