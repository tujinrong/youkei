// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診結果・保健指導履歴照会
//             ビューモデル定義
// 作成日　　: 2024.02.13
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWAF00610D
{
    /// <summary>
    /// 初期化処理(ヘッダー情報)
    /// </summary>
    public class PersonHeaderVM : CommonBarHeaderBaseVM
    {
        public string atenano { get; set; }               //宛名番号
    }

    /// <summary>
    /// 初期化処理（一覧項目）
    /// </summary>
    public class RowVM
    {
        public string jissiage { get; set; }               //実施時年齢
        public string kstype { get; set; }                 //健（検）診種別
        public string ksymd { get; set; }                  //健（検）診年月日
        public string kskbn { get; set; }                  //一次 / 精密
        public string kshoho { get; set; }                 //検査方法
        public string hokensidokbn { get; set; }           //保健指導区分コード
        public string hskbnnm { get; set; }                //保健指導区分
        public string gyomukbn { get; set; }               //業務区分
        public string jigyocd { get; set; }                //事業コード
        public string jigyonm { get; set; }                //事業名
        public string jissiymd { get; set; }               //実施日
        public string jissitm { get; set; }                //実施時間
        public string jissistaffnm { get; set; }           //実施者
        public int edano { get; set; }                     //枝番
        public int nendo { get; set; }                     //年度（各健（検）診結果情報）
        public int kensinkaisu { get; set; }               //検診回数
    }
}