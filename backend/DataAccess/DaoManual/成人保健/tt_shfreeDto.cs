// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             成人保健検診結果（フリー項目）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shfreeDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tt_shfree";
        public string jigyocd { get; set; }                       //検診種別
        public string atenano { get; set; }                       //宛名番号
        public int nendo { get; set; }                            //実施年度
        public int kensinkaisu { get; set; }                      //検診回数
        public string itemcd { get; set; }                        //項目コード
        public EnumKensinKbn kensinkbn { get; set; }              //区分
        public bool? fusyoflg { get; set; }                       //不詳フラグ
        public double? numvalue { get; set; }                     //数値項目
        public string? strvalue { get; set; }                     //文字項目
    }
}
