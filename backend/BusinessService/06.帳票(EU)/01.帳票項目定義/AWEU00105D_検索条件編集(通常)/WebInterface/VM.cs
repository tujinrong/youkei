// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索条件編集(通常)
//             ビューモデル定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00105D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class ItemDaiBunruiVM
    {
        public string daibunrui { get; set; }                       //大分類
        public List<DatasourceItemVM> itemlist { get; set; }        //項目リスト
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public class DatasourceItemVM
    {
        public string sqlcolumn { get; set; }                       //SQLカラム
        public string itemid { get; set; }                          //項目ID
        public string itemhyojinm { get; set; }                     //表示名称
        public string datatype { get; set; }                        //データ型
        public string? mastercd { get; set; }                       //名称マスタコード
        public string? masterpara { get; set; }                     //名称マスタパラメータ
        public int orderseq { get; set; }                           //並びシーケンス
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public class MasterVM
    {
        public string mastercd { get; set; }                        //マスタコード
        public string masterhyojinm { get; set; }                   //マスタ名称
        public List<CdVM> cdlist { get; set; }                      //コードリスト
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public class CdVM
    {
        public string columnnm { get; set; }                        //カラム
        public string columncomment { get; set; }                   //カラム名称
        public CodeTypeEnum codetype { get; set; }                  //コードタイプ
        public List<DaSelectorKeyModel>? selectorlist { get; set; } //選択リスト
    }
}