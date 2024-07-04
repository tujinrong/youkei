// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 医療機関保守
//             ビューモデル定義
// 作成日　　: 2023.12.6
// 作成者　　: CNC張加恒
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00201G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class RowVM : BaseInfoVM
    {
        public string tel { get; set; }                 //電話番号
        public string yubin { get; set; }               //郵便番号
        public string adrs { get; set; }                //住所
        public string stopflg { get; set; }             //利用状態
    }

    /// <summary>
    /// 医療機関保守情報(メイン：ベース)
    /// </summary>
    public class BaseInfoVM
    {
        public string kikancd { get; set; }         //医療機関コード
        public string hokenkikancd { get; set; }    //保険医療機関コード
        public string kikannm { get; set; }    　　 //医療機関名
        public string kanakikannm { get; set; }     //医療機関名(カナ)
    }

    /// <summary>
    /// 医療機関保守情報
    /// </summary>
    public class MainInfoVM : BaseInfoVM
    {
        public string yubin { get; set; }             //郵便番号
        public string adrs { get; set; }              //住所
        public string katagaki { get; set; }          //方書
        public string tel { get; set; }               //電話番号
        public string fax { get; set; }               //FAX番号
        public string syozokuisikai { get; set; }     //所属医師会
        public bool stopflg { get; set; }             //使用停止フラグ
    }

    /// <summary>
    /// 実施事業モデル
    /// </summary>
    public class JissijigyoModel
    {
        public string jissijigyo { get; set; }      //実施事業コード
        public string jissijigyonm { get; set; }    //実施事業名称       
        public bool checkflg { get; set; }          //チェックフラグ
        public string hanyokbn1 { get; set; }           //汎用区分1
        public JissijigyoModel()
        {
        }
        public JissijigyoModel(string? jissijigyo, string? jissijigyonm, bool checkflg, string? hanyokbn1)
        {
            this.jissijigyo = jissijigyo ?? string.Empty;
            this.jissijigyonm = jissijigyonm ?? string.Empty;
            this.checkflg = checkflg;
            this.hanyokbn1 = hanyokbn1 ?? string.Empty;
        }
    }
}