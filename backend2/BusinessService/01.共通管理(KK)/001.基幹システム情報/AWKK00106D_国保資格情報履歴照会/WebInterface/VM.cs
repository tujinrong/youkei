// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 国保資格情報履歴照会
//             ビューモデル定義
// 作成日　　: 2023.10.10
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00106D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class RowVM
    {
        public int rirekinum { get; set; }                      //履歴No.
        public int hihokensyarirekino { get; set; }             //被保険者履歴番号
        public string kokuho_kigono { get; set; }               //国保記号番号
        public string kokuho_edano { get; set; }                //枝番
        public string kokuho_sikakusyutokuymd { get; set; }     //国保資格取得年月日
        public string kokuho_sikakusosituymd { get; set; }      //国保資格喪失年月日
        public string kokuho_sikakusyutokujiyu { get; set; }    //国保資格取得事由
        public string kokuho_sikakusositujiyu { get; set; }     //国保資格喪失事由
        public string upddttm { get; set; }                     //更新日時
        public string saisinflg { get; set; }                   //最新フラグ
    }
}