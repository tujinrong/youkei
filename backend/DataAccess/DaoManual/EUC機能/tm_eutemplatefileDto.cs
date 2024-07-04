// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             帳票テンプレートファイルマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eutemplatefileDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eutemplatefile";
		public string siyokbn { get; set; }                       //使用区分
		public string filenm { get; set; }                        //ファイル名
		public EnumFileTypeKbn filetype { get; set; }             //ファイルタイプ
		public byte[] filedata { get; set; }                      //ファイルデータ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
