// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             一括取込入力履歴テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kktorinyuryoku_rirekiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kktorinyuryoku_rireki";
		public int imprirekino { get; set; }                      //取込履歴No
		public string gyomukbn { get; set; }                      //業務区分
		public string torinyuryokunm { get; set; }                //一括取込入力名
		public string torinyuryokbn { get; set; }                 //一括取込入力区分
		public string? filenm { get; set; }                       //ファイル名
		public int? filetype { get; set; }                        //ファイルタイプ
		public byte[] filedata { get; set; }                      //ファイルデータ
		public int torokucnt { get; set; }                        //登録件数
		public int errcnt { get; set; }                           //エラー件数
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
    }
}
