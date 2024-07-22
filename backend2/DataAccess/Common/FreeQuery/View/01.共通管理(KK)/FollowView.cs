// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             フォロー管理ビュー
// 作成日　　: 2023.12.05
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;
using AIplus.FreeQuery.Where;

namespace BCC.Affect.DataAccess
{
    /// <summary>
    /// フォロー管理情報
    /// </summary>
    public class FollowView : IFrView
    {
        public const string TABLE_NAME = "vw_kkfollow";

        //フォロー内容情報  ビュー項目
        public const string atenano = nameof(tt_kkfollownaiyoDto.atenano);                        //宛名番号

        //フォロー予定情報項目
        public const string followyoteiymd = nameof(tt_kkfollowyoteiDto.followyoteiymd);          //フォロー予定日

        //フォロー結果情報項目
        public const string followjissiymd = nameof(tt_kkfollowkekkaDto.followjissiymd);          //フォロー実施日

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public FollowView(List<FrConditionItem> conditionList)
        {
            _SQL = @$"
                    select
                         t1.atenano,                                                                  --宛名番号
                         t2.followyoteiymd,                                                           --フォロー予定日
                         t2.followjissiymd                                                            --フォロー実施日
                    from (
                        select
                             atenano,                                                                 --宛名番号
                             follownaiyoedano,                                                        --フォロー内容枝番
                             row_number() over (partition by atenano order by follownaiyoedano desc) as row_num
                        from
                            {tt_kkfollownaiyoDto.TABLE_NAME}                                          --フォロー内容情報テーブル
                        where {DaFrUtil.GetSql(conditionList, tt_kkfollownaiyoDto.TABLE_NAME)}
                    ) as t1
                    left join (
                        select
                             t.atenano,                                                               --宛名番号
                             t.follownaiyoedano,                                                      --フォロー内容枝番
                             t.followyoteiymd,                                                        --フォロー予定日
                             t.followjissiymd                                                         --フォロー実施日
                        from (
                            select
                                coalesce(a1.atenano, a2.atenano) atenano,                             --宛名番号
                                coalesce(a1.follownaiyoedano, a2.follownaiyoedano) follownaiyoedano,  --フォロー内容枝番
                                a1.followyoteiymd,                                                    --フォロー予定日
                                a2.followjissiymd,                                                    --フォロー実施日
                                row_number() over (partition by a1.atenano, a1.follownaiyoedano order by greatest(a1.edano, a2.edano) desc) as row_num
                            from (
                                select
                                     atenano,                                                         --宛名番号
                                     follownaiyoedano,                                                --フォロー内容枝番
                                     edano,                                                           --枝番
                                     followyoteiymd                                                   --フォロー予定日
                                from                                                                 
                                   {tt_kkfollowyoteiDto.TABLE_NAME}                                   --フォロー予定情報テーブル
                                where {DaFrUtil.GetSql(conditionList, tt_kkfollowyoteiDto.TABLE_NAME)}
                            ) as a1
                            full join (
                                select
                                     atenano,                                                         --宛名番号
                                     follownaiyoedano,                                                --フォロー内容枝番
                                     edano,                                                           --枝番
                                     followjissiymd                                                   --フォロー実施日
                                from                                                               
                                    {tt_kkfollowkekkaDto.TABLE_NAME}                                  --フォロー結果情報テーブル
                                where {DaFrUtil.GetSql(conditionList, tt_kkfollowkekkaDto.TABLE_NAME)}
                            ) as a2                                                                
                            on a1.atenano = a2.atenano                                                --宛名番号
                               and a1.follownaiyoedano = a2.follownaiyoedano                          --フォロー内容枝番
                        ) as t                                                                     
                        where t.row_num = 1                                                        
                    ) t2                                                                           
                    on t1.atenano = t2.atenano                                                        --宛名番号
                       and t1.follownaiyoedano = t2.follownaiyoedano                                  --フォロー内容枝番
                    where
                        t1.row_num = 1
                    ".Trim();
        }
    }
}