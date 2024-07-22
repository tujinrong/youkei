// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             一括取込入力変換コードメインマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktorinyuryoku_henkancode_mainDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kktorinyuryoku_henkancode_main";
		public string torinyuryokuno { get; set; }                //一括取込入力No
		public int codehenkankbn { get; set; }                    //コード変換区分
		public string henkankbnnm { get; set; }                   //変換区分名称
		public string codekanritablenm { get; set; }              //コード管理テーブル名
		public string maincd { get; set; }                        //メインコード
		public string subcd { get; set; }                         //サブコード
		public string? sonotajoken { get; set; }                  //その他条件
    }
}
