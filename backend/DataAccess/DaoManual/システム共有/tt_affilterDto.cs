// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             詳細条件設定テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_affilterDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tt_affilter";
        public string kinoid { get; set; }                        //機能ID
        public Enum詳細検索条件区分 jyokbn { get; set; }          //条件区分
        public int jyoseq { get; set; }                           //条件シーケンス
        public string hyojinm { get; set; }                       //詳細条件表示名
        public Enumコントローラータイプ ctrltype { get; set; }    //コントローラータイプ
        public bool hyojiflg { get; set; }                        //表示フラグ
        public int? sort { get; set; }                            //並び順
        public string? placeholder { get; set; }                  //入力説明
        public bool rangeflg { get; set; }                        //範囲フラグ
        public string sethanyokbn1 { get; set; }                  //設定用汎用区分1
        public string? sethanyokbn2 { get; set; }                 //設定用汎用区分2
        public string? sethanyokbn3 { get; set; }                 //設定用汎用区分3
        public string? sethanyokbn4 { get; set; }                 //設定用汎用区分4
        public string? sethanyokbn5 { get; set; }                 //設定用汎用区分5
        public Enum取得元区分 getkbn { get; set; }                //検索対象データ取得区分
        public string tablenm1 { get; set; }                      //テーブル物理名1
        public string komokunm1 { get; set; }                     //項目物理名1
        public string? keycd1 { get; set; }                       //主キーコード1
        public string? itemcd1 { get; set; }                      //項目コード1
        public string? tablenm2 { get; set; }                     //テーブル物理名2
        public string? komokunm2 { get; set; }                    //項目物理名2
        public string? keycd2 { get; set; }                       //主キーコード2
        public string? itemcd2 { get; set; }                      //項目コード2
        public string? tablenm3 { get; set; }                     //テーブル物理名3
        public string? komokunm3 { get; set; }                    //項目物理名3
        public string? keycd3 { get; set; }                       //主キーコード3
        public string? itemcd3 { get; set; }                      //項目コード3
    }
}
