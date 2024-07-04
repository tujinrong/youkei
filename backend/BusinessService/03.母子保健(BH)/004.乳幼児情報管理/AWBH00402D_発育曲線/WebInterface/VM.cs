// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 乳幼児情報管理-発育曲線
//             ビューモデル定義
// 作成日　　: 2024.05.17
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00402D
{
    /// <summary>
    /// 発育曲線ヘッダー情報)
    /// </summary>
    public class HeaderInfoVM
    {
        public string atenano { get; set; }                         //宛名番号
        public string name { get; set; }                            //氏名
    }

    /// <summary>
    /// 発育曲線表示用
    /// </summary>
    public class CurveInfoVM
    {
        public int kaisu { get; set; }                              //回数（発育曲線のX軸）
        public object? value { get; set; }                          //値（発育曲線のY軸）
    }

    /// <summary>
    /// 発育曲線表示用
    /// </summary>
    public class GraphListVM
    {
        public int no { get; set; }                                 //発育曲線番号
        public string itemnm { get; set; }                          //部位名称
        public string tani { get; set; }                            //単位
        public List<CurveInfoVM> curveinfolist { get; set; }        //本人のグラフ
        public List<CurveInfoVM> p3curveinfolist { get; set; }      //P3(全体3%)のグラフ
        public List<CurveInfoVM> p97curveinfolist { get; set; }     //P97(全体97%)のグラフ
    }
}