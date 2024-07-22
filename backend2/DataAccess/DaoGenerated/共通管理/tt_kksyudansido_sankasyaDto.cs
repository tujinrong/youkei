// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             集団指導参加者テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kksyudansido_sankasyaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kksyudansido_sankasya";
		public string gyomukbn { get; set; }                      //業務区分
		public int edano { get; set; }                            //枝番
		public string atenano { get; set; }                       //宛名番号
		public string jigyocd { get; set; }                       //その他日程事業・保健指導事業コード
		public string syukketukbn { get; set; }                   //出欠区分
    }
}
