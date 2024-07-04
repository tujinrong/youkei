// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索共通ロジック
//             控除ビュー
// 作成日　　: 2023.10.04
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;
using AIplus.FreeQuery.Where;

namespace BCC.Affect.DataAccess
{
    /// <summary>
    /// 【個人住民税】個人住民税税額控除情報
    /// </summary>
    public class KojoView : IFrView
    {
        public const string TABLE_NAME = "vw_afkojinzeikojo";

        //ビュー項目
        public const string atenano = nameof(tt_afkojinzeikojoDto.atenano);                     //宛名番号
        public const string kazeinendo = nameof(tt_afkojinzeikojoDto.kazeinendo);               //課税年度
        public const string kojocd = nameof(tt_afkojinzeikojoDto.kojocd);                       //税額・税額控除コード
        public const string tosi_gyoseikucd = nameof(tt_afkojinzeikojoDto.tosi_gyoseikucd);     //指定都市_行政区等コード
        public const string kojokingaku = nameof(tt_afkojinzeikojoDto.kojokingaku);             //税額控除金額

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public KojoView(FrCondition condition, string kojocd)
        {
            if (!string.IsNullOrEmpty(kojocd))
            {
                _SQL = @$"
                    select
                      t.atenano,          --宛名番号
                      t.kazeinendo,       --課税年度
                      t.kojocd,           --税額・税額控除コード
                      t.tosi_gyoseikucd,  --指定都市_行政区等コード
                      t.kojokingaku       --税額控除金額
                    from (
                      select
                        *,
                        row_number() over (partition by atenano,kojocd order by kazeinendo desc) as row_num
                      from
                        {tt_afkojinzeikojoDto.TABLE_NAME}
                    ) as t
                    where
                      row_num = 1        --最新年度のみ(宛名と控除ごと)
                      and kojocd='{kojocd}'
                    ".Trim();
            }
            else
            {
                _SQL = @$"
                    select distinct
                      t.atenano,          --宛名番号
                      t.kazeinendo,       --課税年度
                      t.kojokingaku       --税額控除金額
                    from (
                      select
                        *,
                        row_number() over (partition by atenano,kojocd order by kazeinendo desc) as row_num
                      from
                        {tt_afkojinzeikojoDto.TABLE_NAME}
                    ) as t
                    where
                      row_num = 1        --最新年度のみ(宛名と控除ごと)
                      {GetWhere(condition)}
                    ".Trim();

            }
        }
        /// <summary>
        /// 絞り条件設定
        /// </summary>
        private string GetWhere(FrCondition condition)
        {
            var item = condition.ConditionModel.ConditionList.Find(e => e.TableOrSql == TABLE_NAME);
            if (item == null)
            {
                return "and 1=1";
            }
            else
            {
                return $"and {item.GetSql().Replace(TABLE_NAME, "t")}";
            }
        }
    }
}