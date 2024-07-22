// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             公印マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eukoinDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eukoin";
		public int koinid { get; set; }                           //公印ID
		public byte[] sikutyosontyokoin { get; set; }             //市区町村長公印
		public byte[] dairisyakoin { get; set; }                  //職務代理者公印
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
