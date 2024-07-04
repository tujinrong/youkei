// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索条件編集(通常)
//             レスポンスインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00105D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<ItemDaiBunruiVM> itemdaibunruilist { get; set; }     //項目大分類リスト
        public List<DaSelectorModel> selectorlist { get; set; }          //コントロールドロップダウンリスト
        public List<MasterVM> masterlist { get; set; }                   //マスタリスト
        public List<tm_afmeisyoDto> toshilist { get; set; }              //年度マスタリスト
        public List<DaSelectorModel> kensakukbnlist { get; set; }        //検索区分リスト
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public string jyokenlabel { get; set; }                         //ラベル
        public string daibunrui { get; set; }                           //大分類
        public string itemid { get; set; }                              //項目ID
        public string sqlcolumn { get; set; }                           //SQLカラム
        public string itemhyojinm { get; set; }                         //表示名称
        public string datatype { get; set; }                            //データ型
        public Enumコントロール controlkbn { get; set; }                //コントロール区分
        public string? mastercd { get; set; }                           //名称マスタコード
        public string? masterpara { get; set; }                         //名称マスタパラメータ
        public string? sansyomotosql { get; set; }                      //参照元SQL
        public string? nendohanikbn { get; set; }                       //年度範囲区分
        public string? syokiti { get; set; }                            //初期値
        public string sql { get; set; }                                 //SQL
        public string? aimaikbn { get; set; }                           //曖昧検索区分
        public DateTime upddttm { get; set; }                           //更新日時
        public bool shiyoFlg { get; set; }                              //使用済み
    }

    /// <summary>
    /// 条件SQL取得
    /// </summary>
    public class SqlResponse : DaResponseBase
    {
        public string sql { get; set; }                                 //SQL
    }

    /// <summary>
    /// 選択条件情報を取得する
    /// </summary>
    public class SearchJokenDetailResponse : DaResponseBase
    {
        public List<DaSelectorModel>? selectlist { get; set; }  //選択リスト
    }
}