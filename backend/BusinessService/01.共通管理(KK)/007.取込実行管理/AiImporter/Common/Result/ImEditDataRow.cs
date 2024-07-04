// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行チェック
// 　　　　　　編集データ定義
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.CheckImporter
{
    public class ImEditDataRow
    {
        public int dataseq { get; set; }            //データID
        public int rowno { get; set; }              //行番号
        public int colno { get; set; }              //列番号
        public int pageitemseq { get; set; }        //項目ID
        public string itemnm { get; set; } = string.Empty;      //項目名
        public string? val { get; set; } = string.Empty;        //項目値

        public ImEditDataRow(int dataseq, int rowno,int colno, ImEditorColumnDef item)
        {
            this.dataseq = dataseq;
            this.rowno = rowno;
            this.colno = colno;
            this.pageitemseq = item.pageitemseq;
            this.itemnm = item.itemnm;
            this.val = item.Val;
        }
    }
}
