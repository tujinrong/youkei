// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             一括取込入力項目定義マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktorinyuryoku_itemDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kktorinyuryoku_item";
		public string torinyuryokuno { get; set; }                //一括取込入力No
		public int gamenitemseq { get; set; }                     //画面項目シーケンス
		public string itemnm { get; set; }                        //項目名
		public string wktablecolnm { get; set; }                  //ワークテーブルカラム名
		public string inputkbn { get; set; }                      //入力区分
		public string inputhoho { get; set; }                     //入力方法
		public string? hikisu { get; set; }                       //引数
		public int ketasu { get; set; }                           //桁数
		public int? syosuketasu { get; set; }                     //桁数（小数部）
		public int width { get; set; }                            //幅
		public string? format { get; set; }                       //フォーマット
		public string hissuflg { get; set; }                      //必須フラグ
		public bool itiiflg { get; set; }                         //一意フラグ
		public string hyojiinputkbn { get; set; }                 //表示入力設定区分
		public int? orderseq { get; set; }                        //並びシーケンス
		public int? sansyomotoseq { get; set; }                   //参照元項目シーケンス
		public string? sansyomotofield { get; set; }              //参照元フィールド
		public string? syutokusakifield { get; set; }             //取得先フィールド
		public bool? nendoflg { get; set; }                       //年度フラグ
		public string? nendocheck { get; set; }                   //年度チェック
		public string? seikihyogen { get; set; }                  //正規表現
		public string? minvalue { get; set; }                     //最小値
		public string? maxvalue { get; set; }                     //最大値
		public string? syokiti { get; set; }                      //初期値
		public string? koteiti { get; set; }                      //固定値
		public string? masterchecktable { get; set; }             //マスタチェックテーブル
		public string? mastercheckjoken { get; set; }             //マスタチェック条件
		public string? mastercheckitem { get; set; }              //マスタチェック項目
		public string? jokenhissuerrorkbn { get; set; }           //条件必須エラーレベル区分
		public int? jokenhissuitemseq { get; set; }               //条件必須項目シーケンス
		public string? jokenhissuenzansi { get; set; }            //条件必須演算子
		public string? jokenhissuvalue { get; set; }              //条件必須値
		public string? jigyocd { get; set; }                      //医療機関・事業従事者（担当者）事業コード
		public string? itemtokuteikbn { get; set; }               //項目特定区分
    }
}
