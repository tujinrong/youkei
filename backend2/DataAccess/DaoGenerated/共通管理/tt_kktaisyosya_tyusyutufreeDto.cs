// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             対象者抽出情報項目テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kktaisyosya_tyusyutufreeDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kktaisyosya_tyusyutufree";
		public long tyusyutuseq { get; set; }                     //抽出シーケンス
		public string itemcd { get; set; }                        //項目コード
		public bool? fusyoflg { get; set; }                       //不詳フラグ
		public double? numvalue { get; set; }                     //数値項目
		public string? strvalue { get; set; }                     //文字項目
    }
}
