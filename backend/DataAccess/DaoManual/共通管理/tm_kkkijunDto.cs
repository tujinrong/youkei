// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             基準値マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kkkijunDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tm_kkkijun";
        public string gyomukbn { get; set; }                      //業務区分
        public string kijunjigyocd { get; set; }                  //基準値事業コード
        public string itemcd { get; set; }                        //項目コード
        public int edano { get; set; }                            //枝番
        public string yukoymdf { get; set; }                      //有効年月日（開始）
        public string yukoymdt { get; set; }                      //有効年月日（終了）
        public int? agef { get; set; }                            //年齢（開始）
        public int? aget { get; set; }                            //年齢（終了）
        public EnumSex sex { get; set; }                          //性別
        public string kijunvaluehyoki { get; set; }               //基準値表記
        public string alertvaluehyoki { get; set; }               //注意値表記
        public string errvaluehyoki { get; set; }                 //異常値表記
        public double? errvalue1t { get; set; }                   //異常値（数値）以下
        public double? alertvalue1f { get; set; }                 //注意値（数値）開始
        public double? alertvalue1t { get; set; }                 //注意値（数値）終了
        public double? kijunvaluef { get; set; }                  //基準値（数値）開始
        public double? kijunvaluet { get; set; }                  //基準値（数値）終了
        public double? alertvalue2f { get; set; }                 //注意値（数値）開始
        public double? alertvalue2t { get; set; }                 //注意値（数値）終了
        public double? errvalue2f { get; set; }                   //異常値（数値）以上
        public string hanteicd { get; set; }                      //基準値（コード）
        public string alerthanteicd { get; set; }                 //注意値（コード）
        public string errhanteicd { get; set; }                   //異常値（コード）
        public string reguserid { get; set; }                     //登録ユーザーID
        public DateTime regdttm { get; set; }                     //登録日時
        public string upduserid { get; set; }                     //更新ユーザーID
        public DateTime upddttm { get; set; }                     //更新日時
    }
}
