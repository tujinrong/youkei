// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票出力履歴画面		
//          　 ビューモデル定義
// 作成日　　: 2023.09.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00305D
{
    /// <summary>
    /// 検索一覧情報
    /// </summary>
    public class RirekiVM
    {
        public long rirekiseq { get; set; }              //履歴シーケンス
        public DateTime regdttm { get; set; }            //登録日時
        public string regusernm { get; set; }            //登録ユーザー名
        public string jyotai { get; set; }               //状態区分
        public DateTime syoridttmf { get; set; }         //実行日時
        public string outputkbn { get; set; }            //出力方式
        public int? num { get; set; }                    //結果件数
        public string jyoken { get; set; }               //検索条件
        public string? memo { get; set; }                //検索条件メモ
        public bool fileflg { get; set; }                //ファイルフラグ
        public List<JyokenVM> jyokenlist { get; set; }   //検索条件リスト
    }

    /// <summary>
    /// 条件情報
    /// </summary>
    public class JyokenVM
    {
        public long jyokenseq { get; set; }              //条件シーケンス
        public string jyokenlabel { get; set; }          //ラベル
        public string value { get; set; }                //値

        public JyokenVM(long jyokenseq, string jyokenlabel, string value)
        { 
            this.jyokenseq = jyokenseq;
            this.jyokenlabel = jyokenlabel;
            this.value = value;
        }
    }
}