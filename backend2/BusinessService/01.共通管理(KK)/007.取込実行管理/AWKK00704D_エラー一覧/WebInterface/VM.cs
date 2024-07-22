// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行.エラー一覧
//             ビューモデル定義
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00704D
{
    /// <summary>
    /// 取込データエラー情報モデル(エラー一覧画面)
    /// </summary>
    public class KimpErrRowVM
    {
        public int No { get; set; }             //No
        public int rowno { get; set; }          //行
        public string? atenano { get; set; }    //宛名番号
        public string? shimei { get; set; }     //氏名
        public string? itemnm { get; set; }     //項目名
        public string? val { get; set; }        //項目値
        public string msg { get; set; }         //メッセージ(エラー内容)
    }
}