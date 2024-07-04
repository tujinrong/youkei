// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 名称マスタ
//
// 作成日　　: 2023.01.10
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class DaNameModel
    {
        public string nmcd { get; set; } = string.Empty;   //名称コード
        public string nm { get; set; } = string.Empty;     //名称
        public DaNameModel(string nmcd, string nm)
        {
            this.nmcd = nmcd;
            this.nm = nm;
        }
    }
}