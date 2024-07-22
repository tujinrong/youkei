// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             母子保健健診対象者テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhkensinDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_bhkensin";
		public string bhsyurui { get; set; }                      //母子種類
		public string bhdatalistcd { get; set; }                  //母子データリストコード
		public string atenano { get; set; }                       //宛名番号
		public string uketukeymd { get; set; }                    //受付日
		public string kensinyoteiymd { get; set; }                //健診予定日
		public string uketukedttm { get; set; }                   //受付開始時間
		public string kaijocd { get; set; }                       //会場コード
		public bool osiraseflg { get; set; }                      //お知らせ出力フラグ
		public bool annaiflg { get; set; }                        //案内出力フラグ
    }
}
