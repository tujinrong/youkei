// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             妊産婦（フリー）項目テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnsfreeDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_bhnsfree";
		public string jigyocd { get; set; }                       //母子保健事業コード
		public string atenano { get; set; }                       //宛名番号
		public long torokuno { get; set; }                        //登録番号
		public int torokunorenban { get; set; }                   //登録番号連番
		public int edano { get; set; }                            //枝番
		public string kaisu { get; set; }						  //回数
		public string itemcd { get; set; }                        //項目コード
		public bool? fusyoflg { get; set; }                       //不詳フラグ
		public double? numvalue { get; set; }                     //数値項目
		public string? strvalue { get; set; }                     //文字項目
    }
}
