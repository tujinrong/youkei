// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             一括取込入力プロシージャマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktorinyuryoku_procDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kktorinyuryoku_proc";
		public string procseq { get; set; }                       //プロシージャNo
		public string procnm { get; set; }                        //プロシージャ名
		public string prockbn { get; set; }                       //プロシージャ区分
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
