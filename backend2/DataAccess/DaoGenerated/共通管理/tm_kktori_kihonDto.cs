// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             取込基本情報マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktori_kihonDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kktori_kihon";
		public string torinyuryokuno { get; set; }                //一括取込入力No
		public string filekeisiki { get; set; }                   //ファイル形式
		public string fileencode { get; set; }                    //ファイルエンコード
		public string? filenm { get; set; }                       //ファイル名称
		public bool seikihyogen { get; set; }                     //正規表現
		public string datakeisiki { get; set; }                   //データ形式
		public int? recordlen { get; set; }                       //レコード長
		public string? inyofusonzaikbn { get; set; }              //引用符存在区分
		public string? kugirikigo { get; set; }                   //区切り記号
		public int headerrows { get; set; }                       //ヘッダー行数
		public int footerrows { get; set; }                       //フッター行数
    }
}
