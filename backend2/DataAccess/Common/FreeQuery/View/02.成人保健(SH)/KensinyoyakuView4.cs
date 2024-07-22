// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             検診予約希望者宛先ビュー
// 作成日　　: 2024.02.20
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;
using AIplus.FreeQuery.Where;

namespace BCC.Affect.DataAccess
{
    /// <summary>
    /// 宛名テーブル
    /// </summary>
    public class KensinyoyakuView4 : IFrView
    {
        public const string TABLE_NAME = "vw_shkensinyoyakuafatena";

        //ビュー項目
        public const string nitteino = nameof(tt_shkensinyoyakukibosyaDto.nitteino);    //日程番号

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public KensinyoyakuView4(int nendo, List<FrConditionItem> conditionList)
        {
            _SQL = @$"
                    select 
                        distinct(t1.nitteino) as {nitteino}
                    from {tt_shkensinyoyakukibosyaDto.TABLE_NAME} t1
                    left join {tt_afatenaDto.TABLE_NAME} 
                    on t1.atenano = {tt_afatenaDto.TABLE_NAME}.atenano
                    where 
                        t1.nendo = {nendo} and 
                        {DaFrUtil.GetSql(conditionList, tt_afatenaDto.TABLE_NAME)}
                    ".Trim();
        }
    }
}