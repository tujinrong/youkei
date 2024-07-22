// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             検診予定希望者管理(全体)ビュー
// 作成日　　: 2024.02.20
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;

namespace BCC.Affect.DataAccess
{
    /// <summary>
    /// 健（検）診予約希望者テーブル
    /// </summary>
    public class KensinyoyakuView2 : IFrView
    {
        public const string TABLE_NAME = "vw_shkensinyoyakukibosya";

        //ビュー項目
        public const string nitteino = nameof(tt_shkensinyoteisyosaiDto.nitteino);  //日程番号
        public const string ct1 = "ct1";                                            //予約合計人数
        public const string ct2 = "ct2";                                            //キャンセル待ち人数

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public KensinyoyakuView2(int nendo)
        {
            _SQL = @$"
                    select 
                        t1.nitteino, 
                        t2.ct as {ct1}, 
                        t3.ct as {ct2}
                    from
                        (select 
                            nitteino, 
                            count(atenano) as ct
                        from {tt_shkensinyoyakukibosyaDto.TABLE_NAME}
                        where nendo = {nendo}
                        group by nitteino) t1
                    left join 
                        (select nitteino, 
                                count(distinct(atenano)) as ct
                        from {tt_shkensinkibosyasyosaiDto.TABLE_NAME}
                        where nendo = {nendo} and cancelmatiflg = '1' --予約済
                        group by nitteino) t2
                    on t1.nitteino = t2.nitteino
                    left join 
                        (select nitteino, 
                                count(distinct(atenano)) as ct
                        from {tt_shkensinkibosyasyosaiDto.TABLE_NAME}
                        where nendo = {nendo} and cancelmatiflg = '2' --キャンセル待ち
                        group by nitteino) t3
                    on t1.nitteino = t3.nitteino
                    ".Trim();
        }
    }
}