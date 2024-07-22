// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 名称マスタ
//
// 作成日　　: 2024.07.10
// 作成者　　: 
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