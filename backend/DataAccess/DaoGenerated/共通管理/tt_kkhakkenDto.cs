// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             発券情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkhakkenDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kkhakken";
		public int nendo { get; set; }                            //年度
		public string tyusyututaisyocd { get; set; }              //抽出対象コード
		public string hakkendatasyosaikbn { get; set; }           //発券データ詳細区分
		public string atenano { get; set; }                       //宛名番号
		public string hakkenno { get; set; }                      //発券番号
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
