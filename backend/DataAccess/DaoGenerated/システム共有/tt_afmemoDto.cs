// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             メモテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afmemoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afmemo";
		public string atenano { get; set; }                       //宛名番号
		public int memoseq { get; set; }                          //メモシーケンス
		public string jigyokbn { get; set; }                      //メモ事業コード
		public string juyodo { get; set; }                        //重要度
		public string? title { get; set; }                        //件名（タイトル）
		public string memo { get; set; }                          //メモ（フリーテキスト）
		public string? kigenymd { get; set; }                     //期限日
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
