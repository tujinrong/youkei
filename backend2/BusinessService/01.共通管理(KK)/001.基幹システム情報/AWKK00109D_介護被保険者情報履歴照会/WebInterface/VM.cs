// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 介護被保険者情報履歴照会
//             ビューモデル定義
// 作成日　　: 2023.10.10
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00109D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class RowVM
    {
        public int rirekinum { get; set; }              //履歴No.
        public int sikakurirekino { get; set; }         //資格履歴番号
        public string kaigohokensyano { get; set; }     //介護保険者番号
        public string hihokensyano { get; set; }        //被保険者番号
        public string sikakusyutokuymd { get; set; }    //資格取得日
        public string sikakusosituymd { get; set; }     //資格喪失日
        public string yokaigoninteiymd { get; set; }    //要介護認定日
        public string yokaigojotaikbnnm { get; set; }   //要介護状態区分(名称)
        public string upddttm { get; set; }             //更新日時
        public string saisinflg { get; set; }           //最新フラグ
    }
}