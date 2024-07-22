// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             対象者抽出情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kktaisyosya_tyusyutuDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kktaisyosya_tyusyutu";
		public long tyusyutuseq { get; set; }                     //抽出シーケンス
		public int nendo { get; set; }                            //年度
		public string tyusyututaisyocd { get; set; }              //抽出対象コード
		public string? zentaikobetukbn { get; set; }              //全体個別区分
		public string tyusyutunaiyo { get; set; }                 //抽出内容
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
