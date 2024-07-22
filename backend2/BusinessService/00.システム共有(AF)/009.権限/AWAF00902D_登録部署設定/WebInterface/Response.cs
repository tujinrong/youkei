// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 登録部署設定
//             レスポンスインターフェース
// 作成日　　: 2023.07.04
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWAF00801G;

namespace BCC.Affect.Service.AWAF00902D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public string hanyomaincd { get; set; } //汎用メインコード
        public string hanyosubcd { get; set; }  //汎用サブコード

        public string biko { get; set; }                //備考
        public int? keta { get; set; }                  //桁数
        public bool iflg { get; set; }                  //INSERT可能フラグ
        public bool uflg { get; set; }                  //UPDATE可能フラグ
        public bool dflg { get; set; }                  //DELETE可能フラグ
        public List<HanyoVM> kekkalist { get; set; }    //汎用データリスト
        public List<LockVM> locklist { get; set; }      //汎用データリスト(ロック用)
    }
}