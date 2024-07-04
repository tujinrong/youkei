// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             一括取込入力マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktorinyuryokuDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kktorinyuryoku";
		public string torinyuryokuno { get; set; }                //一括取込入力No
		public string torinyuryokunm { get; set; }                //一括取込入力名
		public string torinyuryokbn { get; set; }                 //一括取込入力区分
		public string gyomukbn { get; set; }                      //業務区分
		public bool nendohyojiflg { get; set; }                   //年度表示フラグ
		public string? nendohanikbn { get; set; }                 //年度範囲区分
		public string torokukbn { get; set; }                     //登録区分
		public string? comment { get; set; }                      //説明
		public string? proccheck { get; set; }                    //チェックプロシージャ名
		public string? procbefore { get; set; }                   //更新前プロシージャ名
		public string? procafter { get; set; }                    //更新後プロシージャ名
		public int orderseq { get; set; }                         //並び順シーケンス
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
