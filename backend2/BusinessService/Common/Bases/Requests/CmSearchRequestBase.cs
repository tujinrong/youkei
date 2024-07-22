// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索処理
// 　　　　　　リクエストインターフェースベース
// 作成日　　: 2024.07.26
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service
{
    public class CmSearchRequestBase : DaRequestBase
    {
        public int pagesize { get; set; } = 20;             //ページサイズ
        public int pagenum { get; set; } = 1;               //ページNo.
        public int orderby { get; set; } = 0;               //並び順
        //public bool? queryflg { get; set; }                 //
        public virtual string? personalno { get; set; }     //個人番号
        public void SetPersonalno()
        {
            if (!string.IsNullOrEmpty(personalno))
            {
                //復号化
                personalno = DaEncryptUtil.RsaDecrypt(personalno);
            }
        }
    }
}