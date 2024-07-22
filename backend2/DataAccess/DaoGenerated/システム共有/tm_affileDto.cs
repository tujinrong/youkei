// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             ファイルマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_affileDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_affile";
		public string siyokbn { get; set; }                       //使用区分
		public string filenm { get; set; }                        //ファイル名
		public int filetype { get; set; }                         //ファイルタイプ
		public byte[] filedata { get; set; }                      //ファイルデータ
    }
}
