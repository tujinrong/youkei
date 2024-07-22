// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行チェック
// 　　　　　　異常定義
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.CheckImporter
{
    public class ImErrorOverExcetion : Exception
    {
        public ImErrorOverExcetion() : base("エラー数超える")
        {
        }
    }
}
