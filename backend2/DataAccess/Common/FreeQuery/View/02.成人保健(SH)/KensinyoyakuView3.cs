// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             検診予定希望者管理(予約分類)ビュー
// 作成日　　: 2024.02.20
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;

namespace BCC.Affect.DataAccess
{
    /// <summary>
    /// 健（検）診予約希望者詳細テーブル
    /// </summary>
    public class KensinyoyakuView3 : IFrView
    {
        public const string TABLE_NAME = "vw_shkensinkibosyasyosai";

        //ビュー項目
        public const string nitteino = nameof(tt_shkensinyoteisyosaiDto.nitteino);  //日程番号
        public const string ct1 = "ct1";                                            //予約申込人数
        public const string ct2 = "ct2";                                            //キャンセル待ち人数
        public const string ct3 = "ct3";                                            //定員
        public const string naiyo = "naiyo";                                        //予約内容

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public KensinyoyakuView3(int nendo, string jigyocd, string yoyakubunruicd, string? kensahohocds)
        {
            _SQL = @$"
                    select
                        t1.nitteino, --日程番号
                        t3.ct as {ct1},
                        t4.ct as {ct2},
                        --個別定員の場合、サブテーブルの定員>=0
                        case when (t2.nitteino is not null and t2.teiin_kensin >= 0) then
                            t2.teiin_kensin
                        else
                            null
                        end as {ct3},
                        null as {naiyo}
                    from {tt_shkensinyoteiDto.TABLE_NAME} t1
                    left join {tt_shkensinyoteisyosaiDto.TABLE_NAME} t2
                    on 
                        t1.nendo = t2.nendo and 
                        t1.nitteino = t2.nitteino and 
                        t2.jigyocd = '{jigyocd}' and 
                        t2.yoyakubunruicd = '{yoyakubunruicd}' 
                    inner join 
                        (
                            select 
                                distinct m1.jigyocd
                            from {tm_shyoyakujigyoDto.TABLE_NAME} m1
                            left join {tm_shyoyakujigyo_subDto.TABLE_NAME} m2
                            on 
                                m1.nendo = m2.nendo and
                                m1.jigyocd = m2.jigyocd
                            where 
                                m1.nendo = {nendo} and
                                m2.kensin_jigyocd = '{jigyocd}' and 
                                m2.kensahohocd = any(string_to_array('{kensahohocds}', ','))
                        ) m3
                    on t1.jigyocd = m3.jigyocd
                    left join 
                        (select 
                            nitteino, 
                            count(distinct(atenano)) as ct
                        from {tt_shkensinkibosyasyosaiDto.TABLE_NAME}
                        where 
                            nendo = {nendo} and 
                            jigyocd = '{jigyocd}' and 
                            kensahohocd = any(string_to_array('{kensahohocds}', ',')) and 
                            cancelmatiflg = '1' --予約済
                        group by nitteino) t3 
                    on t1.nitteino = t3.nitteino
                    left join 
                        (select 
                            nitteino, 
                            count(distinct(atenano)) as ct
                        from {tt_shkensinkibosyasyosaiDto.TABLE_NAME}
                        where 
                            nendo = {nendo} and 
                            jigyocd = '{jigyocd}' and 
                            kensahohocd = any(string_to_array('{kensahohocds}', ',')) and 
                            cancelmatiflg = '2' --キャンセル待ち
                        group by nitteino) t4 
                    on t1.nitteino = t4.nitteino
                    where 
                        t1.nendo = {nendo}
                    ".Trim();
        }
    }
}