// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: EUC帳票ロジック処理
//            その他の検索条件
// 作成日　　: 2023.05.07
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class DaSearchConditionVM 
    {
        public Enumコントロール controlkbn { get; set; }        //種類
        public string jyokenlabel { get; set; }                 //ラベル
        public string? variables { get; set; }                  //変数名
        public List<DaSelectorModel>? selectlist { get; set; }  //選択リスト

        public string defaultValue { get; set; }
    }
}