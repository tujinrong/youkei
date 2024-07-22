// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             一括取込入力未処理項目テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kktorinyuryoku_misyoriitemDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kktorinyuryoku_misyoriitem";
		public int impjikkoid { get; set; }                       //取込実行ID
		public int dataseq { get; set; }                          //データシーケンス
		public int rowno { get; set; }                            //行番号
		public int colno { get; set; }                            //列番号
		public int itemseq { get; set; }                          //項目シーケンス
		public string itemnm { get; set; }                        //項目名
		public string? itemvalue { get; set; }                    //項目値
    }
}
