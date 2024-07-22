// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             取込変換コードマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktori_henkancodeDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kktori_henkancode";
		public string torinyuryokuno { get; set; }                //一括取込入力No
		public int codehenkankbn { get; set; }                    //コード変換区分
		public string motocd { get; set; }                        //元コード
		public string? motocdcomment { get; set; }                //元コード説明
		public string henkangocd { get; set; }                    //変換後コード
		public string? henkangocdcomment { get; set; }            //変換後コード説明
    }
}
