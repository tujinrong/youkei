// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 会場保守
//             ビューモデル定義
// 作成日　　: 2023.11.02
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00202G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class RowVM : BaseInfoVM
    {
        public string kaijorenrakusaki { get; set; }    //会場連絡先
        public string adrskatagaki { get; set; }        //住所方書
        public string gyoseiku { get; set; }            //行政区
        public string stopflg { get; set; }             //利用状態
    }

    /// <summary>
    /// 会場情報(メイン：ベース)
    /// </summary>
    public class BaseInfoVM
    {
        public string kaijocd { get; set; }        //会場コード
        public string kaijonm { get; set; }    　　//会場名
        public string kanakaijonm { get; set; }   //会場名(カナ)
    }

    /// <summary>
    /// 会場情報
    /// </summary>
    public class MainInfoVM : BaseInfoVM
    {
        public bool stopflg { get; set; }               //使用停止フラグ
        public string adrs { get; set; }                //住所
        public string katagaki { get; set; }       　　 //方書
        public string kaijorenrakusaki { get; set; }    //会場連絡先
        public string gyoseikucd { get; set; }          //行政区
        public DateTime? upddttm { get; set; }          //更新日時(排他用)
    }

    /// <summary>
    /// 単一地区情報初期化モデル
    /// </summary>
    public class TikuOneInitVM : TikuOneSaveVM
    {
        public string tikukbnnm { get; set; }                    //地区区分名称
        public List<DaSelectorModel> tikucdnmList { get; set; }  //地区一覧(コード：名称)
    }

    /// <summary>
    /// 単一地区情報保存モデル
    /// </summary>
    public class TikuOneSaveVM
    {
        public Enum地区区分 tikukbn { get; set; }             //地区区分
        public List<string> tikucdList { get; set; }          //地区一覧(コード)
    }
}