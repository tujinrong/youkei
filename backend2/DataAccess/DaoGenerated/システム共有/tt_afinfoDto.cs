// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             お知らせテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afinfoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afinfo";
		public long infoseq { get; set; }                         //お知らせシーケンス
		public string juyodo { get; set; }                        //重要度
		public string kigenymd { get; set; }                      //掲示期限年月日
		public string? syosai { get; set; }                       //詳細
		public bool atesakiflg { get; set; }                      //宛先指定フラグ
		public string? atesaki { get; set; }                      //宛先
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
