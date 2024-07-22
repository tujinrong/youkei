// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 登録部署設定
//             ビューモデル定義
// 作成日　　: 2024.07.10
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00902D
{
    /// <summary>
    /// 汎用データ情報モデル
    /// </summary>
    public class HanyoVM
    {
        public string hanyocd { get; set; }     //汎用コード
        public DateTime? upddttm { get; set; }  //更新日時
        public string nm { get; set; }              //名称
        public string kananm { get; set; }          //カナ名称
        public string shortnm { get; set; }         //略称
        public string biko { get; set; }            //備考
        public string hanyokbn1 { get; set; }       //汎用区分1
        public string hanyokbn2 { get; set; }       //汎用区分2
        public string hanyokbn3 { get; set; }       //汎用区分3
        public bool stopflg { get; set; }           //使用停止フラグ
    }
}