// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             課税ビュー
// 作成日　　: 2023.10.04
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;

namespace BCC.Affect.DataAccess
{
    /// <summary>
    /// 【個人住民税】個人住民税課税情報
    /// </summary>
    public class KazeiView : IFrView
    {
        public const string TABLE_NAME = "vw_afkojinzeikazei";

        //ビュー項目
        public const string atenano = nameof(tt_afkojinzeikazeiDto.atenano);                    //宛名番号
        public const string kazeinendo = nameof(tt_afkojinzeikazeiDto.kazeinendo);              //課税年度
        public const string tosi_gyoseikucd = nameof(tt_afkojinzeikazeiDto.tosi_gyoseikucd);    //指定都市_行政区等コード
        public const string kazeikbn = nameof(tt_afkojinzeikazeiDto.kazeikbn);                  //課税非課税区分

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public KazeiView()
        {
            _SQL = @$"
                    select
                      t.atenano,          --宛名番号
                      t.kazeinendo,       --課税年度
                      t.tosi_gyoseikucd,  --指定都市_行政区等コード
                      t.kazeikbn          --課税非課税区分
                    from (
                      select
                        *,
                        row_number() over (partition by atenano order by kazeinendo desc) as row_num
                      from
                        {tt_afkojinzeikazeiDto.TABLE_NAME}
                    ) as t
                    where
                      row_num = 1        --最新年度のみ(宛名ごと)
                    ".Trim();
        }
    }
}