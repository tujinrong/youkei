// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票出力(一覧画面、出力画面)
//             ビューモデル定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.Service.CmFilterVM;
namespace BCC.Affect.Service.AWEU00301G
{
    /// <summary>
    /// 一覧画面検索処理
    /// </summary>
    public class ReportVM
    {
        public string rptid { get; set; }       //帳票ID
        public string rptnm { get; set; }       //帳票名
        public string rptgroupnm { get; set; }  //帳票グループ
        public string? rptbiko { get; set; }    //帳票説明
        public string regusernm { get; set; }   //作成者
        public DateTime regdttm { get; set; }   //作成日時
        public string rptgroupid { get; set; }  //帳票グループID
    }

    /// <summary>
    /// 出力画面初期化処理
    /// </summary>
    public class KensakuJyokenInitVM
    {
        public int jyokenseq { get; set; }                          //条件シーケンス
        public int? jyokenid { get; set; }                          //条件ID
        public Enum検索条件区分 jyokenkbn { get; set; }             //検索条件区分
        public string jyokenlabel { get; set; }                     //ラベル
        public string? variables { get; set; }                      //変数名
        public string sql { get; set; }                             //SQL
        public string tablealias { get; set; }                      //テーブル別名
        public Enumコントロール? controlkbn { get; set; }           //コントロール区分
        public bool hissuflg { get; set; }                          //必須フラグ
        public EnumDataType datatype { get; set; }                  //データ型
        public string? nendohanikbn { get; set; }                   //年度範囲区分
        public string nendo { get; set; }                           //初期表示年度
        public string nendomax { get; set; }                        //最大年度
        public string? syokiti { get; set; }                       //初期値
        public List<DaSelectorModel>? selectorlist { get; set; }    //選択リスト
        public object? value { get; set; }                          //値
        public string? targetitemseq { get; set; }                  //参照先項目ID(複数? ,)
    }

    /// <summary>
    /// 出力画面初期化処理
    /// </summary>
    public class DetailJyokenInitVM : CommonFilterVM
    {
        public string komokunm1 { get; set; } //項目物理名1
    }

    /// <summary>
    /// 出力画面検索処理
    /// </summary>
    public class AtenaVM
    {
        public bool formflg { get; set; }           //出力フラグ
        public string atenano { get; set; }         //宛名番号
        public string simei_yusen { get; set; }     //氏名_優先
        public string sex { get; set; }             //性別
        public string bymdhyoki { get; set; }       //生年月日表記
        public string gyoseikunm { get; set; }      //行政区
        public string juminkbn { get; set; }        //住民区分
        public string taisyogairiyu { get; set; }   //発行対象外者対象外理由
        public string warningtext { get; set; }     //警告内容
    }

    /// <summary>
    /// 参照元項目入力後参照先項目の選択リストを取得する処理
    /// </summary>
    public class TargetItemValueVM
    {
        public int jyokenid { get; set; }                          //条件ID
        public List<DaSelectorModel> selectorlist { get; set; }    //選択リスト
    }

    /// <summary>
    /// 抽出パネル用
    /// </summary>
    public class MyDaSelectorModel
    {
        public string value { get; set; }   //コード
        public string label { get; set; }   //名称
        public string key { get; set; }     //キー項目1
        public string key2 { get; set; }    //キー項目2
        public MyDaSelectorModel(string? value, string? label, string? key, string? key2) 
        {
            this.value = value ?? string.Empty;
            this.label = label ?? string.Empty;
            this.key = key ?? string.Empty;
            this.key2 = key2 ?? string.Empty;
        }
    }
}