// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             【後期高齢者医療】被保険者情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afkokihokenDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afkokihoken";
		public string atenano { get; set; }                       //宛名番号
		public string hihokensyano { get; set; }                  //被保険者番号
		public string kojinkbncd { get; set; }                    //個人区分コード
		public string hiho_sikakusyutokujiyucd { get; set; }      //被保険者資格取得事由コード
		public string hiho_sikakusyutokuymd { get; set; }         //被保険者資格取得年月日
		public string? hiho_sikakusositujiyucd { get; set; }      //被保険者資格喪失事由コード
		public string? hiho_sikakusosituymd { get; set; }         //被保険者資格喪失年月日
		public string hoken_tekiyoymdf { get; set; }              //保険者番号適用開始年月日
		public string? hoken_tekiyoymdt { get; set; }             //保険者番号適用終了年月日
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
