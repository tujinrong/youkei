// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票項目追加
//             ビューモデル定義
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using BCC.Affect.Service.AWEU00107D;

namespace BCC.Affect.Service.AWEU00204D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class ItemVM : SimpleItemVM
    {
        public string yosikiitemid { get; } //様式項目ID
        public string reportitemnm { get; } //帳票項目名称
        public string csvitemnm { get; } //CSV項目名称
        public string tablealias { get; set; } //テーブル別名
        public Enum並び替え orderkbn { get; set; } //並び替え
        public int? orderseq { get; set; } //並びシーケンス
        public bool reportoutputflg { get; set; } //帳票出力フラグ
        public bool csvoutputflg { get; set; } //CSV出力フラグ
        public bool headerflg { get; set; } //ヘッダーフラグ
        public bool kaipageflg { get; set; } //改ページフラグ
        public Enum出力項目区分 itemkbn { get; set; } //項目区分
        public string? formatkbn { get; set; } //フォーマット区分
        public int? formatkbn2 { get; set; } //フォーマット区分2
        public string? formatsyosai { get; set; } //フォーマット詳細
        public int? height { get; set; } //高
        public int? width { get; set; } //幅
        public int? offsetx { get; set; } //X軸オフセット
        public int? offsety { get; set; } //Y軸オフセット
        public string? blankvalue { get; set; } //白紙表示
        public string? mastercd { get; set; } //名称マスタコード
        public string? masterpara { get; set; } //名称マスタパラメータ
        public string? keyvaluepairsjson { get; set; } //複数のキー・値・ペアjson
        public Enum集計区分? crosskbn { get; set; } //集計区分
        public Enum集計方法? syukeihoho { get; set; } //集計方法
        public Enum小計区分? kbn1 { get; set; } //小計区分
        public int? level { get; set; } //集計レベル

        public ItemVM(string sqlcolumn, string itemid, string itemhyojinm, bool isleaf) : base(sqlcolumn, itemid, itemhyojinm, isleaf)
        {
            yosikiitemid = itemid;
            reportitemnm = itemhyojinm;
            csvitemnm = itemhyojinm;
        }
    }

    /// <summary>
    /// 集計項目検索処理
    /// </summary>
    public class BunruiItemVM
    {
        public string daibunrui { get; set; } //大分類
        public List<StatisticItemVM> itemlist { get; set; } //項目リスト
    }

    /// <summary>
    /// 集計項目検索処理
    /// </summary>
    public class StatisticItemVM
    {
        public string sqlcolumn { get; set; } //SQLカラム
        public string yosikiitemid { get; set; } //様式項目ID
        public string reportitemnm { get; set; } //帳票項目名称
        public string csvitemnm { get; set; } //CSV項目名称
        public string tablealias { get; set; } //テーブル別名
        public Enum並び替え orderkbn { get; set; } //並び替え
        public int? orderseq { get; set; } //並びシーケンス
        public bool reportoutputflg { get; set; } //帳票出力フラグ
        public bool csvoutputflg { get; set; } //CSV出力フラグ
        public bool headerflg { get; set; } //ヘッダーフラグ
        public bool kaipageflg { get; set; } //改ページフラグ
        public Enum出力項目区分 itemkbn { get; set; } //項目区分
        public string? formatkbn { get; set; } //フォーマット区分
        public int? formatkbn2 { get; set; } //フォーマット区分2
        public string? formatsyosai { get; set; } //フォーマット詳細
        public int? height { get; set; } //高
        public int? width { get; set; } //幅
        public int? offsetx { get; set; } //X軸オフセット
        public int? offsety { get; set; } //Y軸オフセット
        public string? blankvalue { get; set; } //白紙表示
        public string? mastercd { get; set; } //名称マスタコード
        public string? masterpara { get; set; } //名称マスタパラメータ
        public string? keyvaluepairsjson { get; set; } //複数のキー・値・ペアjson
        public Enum集計区分? crosskbn { get; set; } //集計区分
        public string? syukeihoho { get; set; } //集計方法
        public Enum小計区分? kbn1 { get; set; } //小計区分
        public int? level { get; set; } //集計レベル
    }
}