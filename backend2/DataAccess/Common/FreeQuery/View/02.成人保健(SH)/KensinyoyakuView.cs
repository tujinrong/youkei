// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             検診予定管理ビュー
// 作成日　　: 2024.02.14
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;

namespace BCC.Affect.DataAccess
{
    /// <summary>
    /// 健（検）診予定テーブル
    /// </summary>
    public class KensinyoyakuView : IFrView
    {
        public const string TABLE_NAME = "vw_shkensinyoyaku";

        //ビュー項目
        public const string nitteino = nameof(tt_shkensinyoteisyosaiDto.nitteino);  //日程番号
        public const string useflg = "useflg";                                      //予約可能フラグ

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public KensinyoyakuView(int nendo, string jigyocd, string yoyakubunruicd, string? kensahohocds)
        {
            _SQL = @$"
                    select
                        t1.nitteino, --日程番号
                        --個別定員の場合、サブテーブルの定員>=0
                        case when(t2.nitteino is not null and t2.teiin_kensin >= 0) then
                            true
                        else
                            false
                        end as {useflg}
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
                    where 
                        t1.nendo = {nendo}
                    ".Trim();
        }
    }
}