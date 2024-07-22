// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: パーセンタイル値保守
//             ビューモデル定義
// 作成日　　: 2024.06.01
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00501G
{
    /// <summary>
    /// 検索処理(結果一覧画面)
    /// </summary>
    public class PasentairuListVM
    {
        public string buicd { get; set; }                   //部位コード（キー項目、非表示）
        public string sex { get; set; }                     //性別（コード）（キー項目、非表示）
        public int prockbn { get; set; }                    //処理区分（非表示）　1：削除　2：新規　3：更新
        public int month { get; set; }                      //月 
        public int date { get; set; }                       //日
        public int pasentairustd { get; set; }              //パーセンタイル標準 
        public int pasentairu3p { get; set; }               //パーセンタイル3P
        public int pasentairu10p { get; set; }              //パーセンタイル10P
        public int pasentairu25p { get; set; }              //パーセンタイル25P
        public int pasentairu50p { get; set; }              //パーセンタイル50P
        public int pasentairu75p { get; set; }              //パーセンタイル75P
        public int pasentairu90p { get; set; }              //パーセンタイル90P
        public int pasentairu97p { get; set; }              //パーセンタイル97P
    }

    /// <summary>
    /// プロシージャ用項目ID（ambiguousエラーを避ける為）
    /// </summary>
    public class ProcedureVM
    {
        public string buicode { get; set; }                 //部位コード
        public string sexcode { get; set; }                 //性別（コード）
        public int tuki { get; set; }                       //月 
        public int bi { get; set; }                         //日
    }
}