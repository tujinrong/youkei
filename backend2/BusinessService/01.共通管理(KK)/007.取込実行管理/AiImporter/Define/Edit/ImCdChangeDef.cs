// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行チェック
// 　　　　　　コード変換項目定義
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.CheckImporter
{
    public class ImCdChangeDef
    {
        public int cdchangekbn { get; set; }

        public string oldcode { get; set; }

        public string newcode { get; set; }

        public ImCdChangeDef(int cdchangekbn, string oldcode, string newcode)
        {
            this.cdchangekbn = cdchangekbn;
            this.oldcode = oldcode;
            this.newcode = newcode;
        }
    }
}
