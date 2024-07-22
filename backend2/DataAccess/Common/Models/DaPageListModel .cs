// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 改ページ画面のモデル定義
//
// 作成日　　: 2024.07.10
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class DaPageListModel
    {
        public int TotalCount;
        public DataTable dataTable { get; set; } = new DataTable();
    }
}