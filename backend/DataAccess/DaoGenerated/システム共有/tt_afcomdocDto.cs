// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             共通ドキュメントテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afcomdocDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afcomdoc";
		public long docseq { get; set; }                          //ドキュメントシーケンス
		public string filenm { get; set; }                        //ファイル名
		public string? jigyocd { get; set; }                      //事業コード
		public string? title { get; set; }                        //タイトル
		public int filetype { get; set; }                         //ファイルタイプ
		public int filesize { get; set; }                         //ファイルサイズ
		public byte[] filedata { get; set; }                      //ファイルデータ
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
