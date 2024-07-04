// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             ヘルプドキュメントマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afhelpdocDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tm_afhelpdoc";
        public long docseq { get; set; }                          //ドキュメントシーケンス
        public string kinoid { get; set; }                        //機能ID
        public string filenm { get; set; }                        //ファイル名
        public EnumFileTypeKbn filetype { get; set; }             //ファイルタイプ
        public int filesize { get; set; }                         //ファイルサイズ
        public byte[] filedata { get; set; }                      //ファイルデータ
    }
}
