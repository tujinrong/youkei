// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             検診予定担当者管理ビュー
// 作成日　　: 2024.02.20
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;

namespace BCC.Affect.DataAccess
{
    /// <summary>
    /// 健（検）診予定担当者テーブル
    /// </summary>
    public class KensinyoyakustaffView : IFrView
    {
        public const string TABLE_NAME = "vw_shkensinyoteistaff";

        //ビュー項目
        public const string nitteino = nameof(tt_shkensinyoteisyosaiDto.nitteino);          //日程番号
        public const string staffidnms = $"{nameof(tt_shkensinyotei_staffDto.staffid)}nms"; //担当者名称

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public KensinyoyakustaffView(int nendo)
        {
            _SQL = @$"
                    select 
                        t.nitteino, 
                        string_agg(t.staffsimei, '{DaStrPool.C_COMMA2}') as {staffidnms}
                    from 
                        (select 
                            t1.nitteino, 
                            m1.staffsimei
                        from {tt_shkensinyotei_staffDto.TABLE_NAME} t1
                        left join {tm_afstaffDto.TABLE_NAME} m1
                        on t1.staffid = m1.staffid
                        where t1.nendo = {nendo}
                        order by t1.staffid) t
                    group by t.nitteino
                    ".Trim();
        }
    }
}