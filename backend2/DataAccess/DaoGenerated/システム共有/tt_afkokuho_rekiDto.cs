// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             【国民健康保険】国保資格情報履歴テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afkokuho_rekiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afkokuho_reki";
		public string atenano { get; set; }                       //宛名番号
		public int hihokensyarirekino { get; set; }               //被保険者履歴番号
		public string sikutyosonhokenjano { get; set; }           //市区町村保険者番号
		public string? hokenjanm { get; set; }                    //保険者名称
		public string kokuho_kigono { get; set; }                 //国保記号番号
		public string kokuho_edano { get; set; }                  //枝番
		public string kokuho_sikakukbn { get; set; }              //国保資格区分
		public string kokuho_sikakusyutokuymd { get; set; }       //国保資格取得年月日
		public string kokuho_sikakusyutokujiyu { get; set; }      //国保資格取得事由
		public string? kokuho_sikakusosituymd { get; set; }       //国保資格喪失年月日
		public string? kokuho_sikakusositujiyu { get; set; }      //国保資格喪失事由
		public string kokuho_tekiyoymdf { get; set; }             //国保適用開始年月日
		public string? kokuho_tekiyoymdt { get; set; }            //国保適用終了年月日
		public string syokbn { get; set; }                        //証区分
		public string yukokigenymd { get; set; }                  //有効期限
		public string? marugakumaruenkbn { get; set; }            //マル学マル遠区分
		public string renkeimotosousauserid { get; set; }         //連携元操作者ID
		public DateTime renkeimotosousadttm { get; set; }         //連携元操作日時
		public bool saisinflg { get; set; }                       //最新フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
