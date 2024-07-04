// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             送付先管理テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afsofusakiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afsofusaki";
		public string atenano { get; set; }                       //宛名番号
		public string riyomokuteki { get; set; }                  //利用目的
		public string adrs_sikucd { get; set; }                   //住所_市区町村コード
		public string adrs_tyoazacd { get; set; }                 //住所_町字コード
		public string adrs_todofuken { get; set; }                //住所_都道府県
		public string adrs_sikunm { get; set; }                   //住所_市区郡町村名
		public string? adrs_tyoaza { get; set; }                  //住所_町字
		public string? adrs_bantihyoki { get; set; }              //住所_番地号表記
		public string? adrs_katagaki { get; set; }                //住所_方書
		public string? adrs_yubin { get; set; }                   //住所_郵便番号
		public string sofusaki_simei { get; set; }                //送付先氏名
		public string? torokujiyu { get; set; }                   //登録事由
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
