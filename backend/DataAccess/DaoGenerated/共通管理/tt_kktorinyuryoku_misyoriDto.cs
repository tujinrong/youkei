// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             一括取込入力未処理テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kktorinyuryoku_misyoriDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kktorinyuryoku_misyori";
		public int impjikkoid { get; set; }                       //取込実行ID
		public string torinyuryokuno { get; set; }                //一括取込入力No
		public string? filenm { get; set; }                       //ファイル名
		public byte[] filedata { get; set; }                      //ファイルデータ
		public int? filetype { get; set; }                        //ファイルタイプ
		public int? filegokeirow { get; set; }                    //ファイル合計行
		public int totalcnt { get; set; }                         //件数
		public int errcnt { get; set; }                           //エラー件数
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
