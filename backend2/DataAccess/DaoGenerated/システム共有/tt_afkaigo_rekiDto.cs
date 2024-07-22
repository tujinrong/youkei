// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             【介護保険】被保険者情報履歴テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afkaigo_rekiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afkaigo_reki";
		public string atenano { get; set; }                       //宛名番号
		public string kaigohokensyano { get; set; }               //介護保険者番号
		public string hihokensyano { get; set; }                  //被保険者番号
		public int sikakurirekino { get; set; }                   //資格履歴番号
		public string hihokensyakbncd { get; set; }               //被保険者区分コード
		public string sikakusyutokuymd { get; set; }              //資格取得日
		public string sikakusosituymd { get; set; }               //資格喪失日
		public string yokaigoninteijokyocd { get; set; }          //要介護認定状況コード
		public string? yokaigojotaikbncd { get; set; }            //要介護状態区分コード
		public string? yokaigoninteiymd { get; set; }             //要介護認定日
		public string? yokaigoyukoymdf { get; set; }              //要介護認定有効期間開始日
		public string? yokaigoyukoymdt { get; set; }              //要介護認定有効期間終了日
		public string kohijukyusyano { get; set; }                //公費受給者番号
		public string renkeimotosousauserid { get; set; }         //連携元操作者ID
		public DateTime renkeimotosousadttm { get; set; }         //連携元操作日時
		public bool saisinflg { get; set; }                       //最新フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
