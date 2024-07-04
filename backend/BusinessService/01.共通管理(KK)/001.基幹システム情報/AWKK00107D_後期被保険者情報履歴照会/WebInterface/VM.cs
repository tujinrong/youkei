// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 後期被保険者情報履歴照会
//             ビューモデル定義
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00107D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class RowVM
    {
        public int rirekinum { get; set; }                      //履歴No.
        public int rirekino { get; set; }                       //履歴番号
        public string hihokensyano { get; set; }                //被保険者番号
        public string hiho_sikakusyutokuymd { get; set; }       //被保険者資格取得年月日
        public string hiho_sikakusosituymd { get; set; }        //被保険者資格喪失年月日
        public string hiho_sikakusyutokujiyunm { get; set; }    //被保険者資格取得事由(名称)
        public string hiho_sikakusositujiyunm { get; set; }     //被保険者資格喪失事由(名称)
        public string upddttm { get; set; }                     //更新日時
        public string saisinflg { get; set; }                   //最新フラグ
    }
}