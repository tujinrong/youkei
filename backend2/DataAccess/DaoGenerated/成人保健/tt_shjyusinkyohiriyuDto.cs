// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             受診拒否理由テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shjyusinkyohiriyuDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_shjyusinkyohiriyu";
		public int nendo { get; set; }                            //年度
		public string atenano { get; set; }                       //宛名番号
		public string jigyocd { get; set; }                       //検診種別
		public string kyohiriyu { get; set; }                     //受診拒否理由
    }
}
