// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             保健指導管理ビュー
// 作成日　　: 2024.03.06
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;
using AIplus.FreeQuery.Where;

namespace BCC.Affect.DataAccess
{
    /// <summary>
    /// 保健指導結果情報
    /// </summary>
    public class SidoView2 : IFrView
    {
        public const string TABLE_NAME = "vw_kksido2";

        //結果項目
        public const string atenano = nameof(tt_kkhokensidofreeDto.atenano);

        public const string ViewName = "vw_sidofree";

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public SidoView2(List<FrConditionItem> conditionList, string tableID, string hokensidokbn, string gyomukbn, string mosikomikekkakbn, string itemcd)
        {
            _SQL = @$"
                    select distinct
                        v1.atenano
                    from (
                        select
                            {tableID}.atenano,
                            {tableID}.hokensidokbn,
                            {tableID}.gyomukbn,
                            {tableID}.mosikomikekkakbn,
                            {tableID}.itemcd,
                            {tableID}.edano,
                            {tableID}.fusyoflg,
                            {tableID}.numvalue,
                            {tableID}.strvalue
                        from(
                            select
                                atenano,
                                hokensidokbn,
                                gyomukbn,
                                mosikomikekkakbn,
                                itemcd,
                                edano,
                                fusyoflg,
                                numvalue,
                                strvalue
                            from {tt_kkhokensidofreeDto.TABLE_NAME} t1
                            where
                                1 = 1
                                and t1.hokensidokbn = '{hokensidokbn}'
                                and t1.gyomukbn = '{gyomukbn}'
                                and t1.mosikomikekkakbn = '{mosikomikekkakbn}'
                                and t1.itemcd = '{itemcd}'
                        ) {tableID}
                        where 1 = 1
                        and {DaFrUtil.GetSql(conditionList, $"{tableID}")} 
                    ) v1
            ".Trim();
        }
    }
}