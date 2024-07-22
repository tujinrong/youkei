// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票出力(CSV出力設定)
//             ビューモデル定義
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00302D
{
    /// <summary>
    /// ダウンロード処理
    /// </summary>
    public class AtenaVM
    {
        public string atenano { get; set; }         //宛名番号
        public string personalno { get; set; }      //個人番号
        public string simei_yusen { get; set; }     //氏名_優先
        public string sexhyoki { get; set; }        //性別表記
        public string bymdhyoki { get; set; }       //生年月日表記
        public string gyoseikunm { get; set; }      //行政区
        public string juminkbn { get; set; }        //住民区分
        public string taisyogairiyu { get; set; }   //発行対象外者対象外理由
        public string warningtext { get; set; }     //警告内容
    }
}