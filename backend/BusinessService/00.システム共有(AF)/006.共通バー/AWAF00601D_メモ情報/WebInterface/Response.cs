// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: メモ情報
//             レスポンスインターフェース
// 作成日　　: 2023.03.02
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWAF00601D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }    //ドロップダウンリスト(重要度)
        public List<DaSelectorModel> selectorlist2 { get; set; }    //ドロップダウンリスト(登録事業)
        public bool showflg { get; set; }                           //表示フラグ(登録支所)
        public string regsisyo { get; set; }                        //登録支所
        public bool csvoutflg { get; set; }                         //CSV出力フラグ
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public CommonBarHeaderBaseVM headerinfo { get; set; }   //個人基本情報
        public List<SearchVM> kekkalist { get; set; }           //メモ情報
        public string[] jigyokbns { get; set; }                 //登録事業(登録範囲-CSV出力用)
    }
}