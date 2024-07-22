// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索共通ロジック
//             納税ビュー
// 作成日　　: 2023.10.04
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Interface;

namespace BCC.Affect.DataAccess
{
    /// <summary>
    /// 【個人住民税】納税義務者情報
    /// </summary>
    public class NozeiView : IFrView
    {
        public const string TABLE_NAME = "vw_afkojinzeigimusya";

        //ビュー項目
        public const string atenano = nameof(tt_afkojinzeigimusyaDto.atenano);                    //宛名番号
        public const string kazeinendo = nameof(tt_afkojinzeigimusyaDto.kazeinendo);              //課税年度
        public const string tosi_gyoseikucd = nameof(tt_afkojinzeigimusyaDto.tosi_gyoseikucd);    //指定都市_行政区等コード
        public const string misinkokukbn = nameof(tt_afkojinzeigimusyaDto.misinkokukbn);          //未申告区分
        public const string takazeikbn = nameof(tt_afkojinzeigimusyaDto.takazeikbn);              //他団体課税対象者区分
        public const string takazeisikucd = nameof(tt_afkojinzeigimusyaDto.takazeisikucd);        //他団体課税対象者の課税先市区町村コード

        private string _SQL;
        public string SQL => _SQL;
        public string TableName => TABLE_NAME;

        public NozeiView()
        {
            _SQL = @$"
                    select
                      t.atenano,          --宛名番号
                      t.kazeinendo,       --課税年度
                      t.tosi_gyoseikucd,  --指定都市_行政区等コード
                      t.misinkokukbn,     --未申告区分
                      t.takazeikbn,       --他団体課税対象者区分
                      t.takazeisikucd     --他団体課税対象者の課税先市区町村コード
                    from (
                      select
                        *,
                        row_number() over (partition by atenano order by kazeinendo desc) as row_num
                      from
                        {tt_afkojinzeigimusyaDto.TABLE_NAME}
                    ) as t
                    where
                      row_num = 1        --最新年度のみ(宛名ごと)
                    ".Trim();
        }
    }
}