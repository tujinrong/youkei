// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             【介護保険】被保険者情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afkaigoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afkaigo";
		public string atenano { get; set; }                       //宛名番号
		public string kaigohokensyano { get; set; }               //介護保険者番号
		public string hihokensyano { get; set; }                  //被保険者番号
		public string hihokensyakbncd { get; set; }               //被保険者区分コード
		public string sikakusyutokuymd { get; set; }              //資格取得日
		public string sikakusosituymd { get; set; }               //資格喪失日
		public string yokaigoninteijokyocd { get; set; }          //要介護認定状況コード
		public string? yokaigojotaikbncd { get; set; }            //要介護状態区分コード
		public string? yokaigoninteiymd { get; set; }             //要介護認定日
		public string? yokaigoyukoymdf { get; set; }              //要介護認定有効期間開始日
		public string? yokaigoyukoymdt { get; set; }              //要介護認定有効期間終了日
		public string kohijukyusyano { get; set; }                //公費受給者番号
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
