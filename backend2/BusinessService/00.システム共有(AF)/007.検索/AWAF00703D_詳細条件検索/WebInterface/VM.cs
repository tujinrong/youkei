// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 詳細条件検索
// 　　　　　　ビューモデル定義
// 作成日　　: 2023.05.11
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00703D
{
    /// <summary>
    /// 詳細条件(検索)
    /// </summary>
    public class SearchVM
    {
        public Enum詳細検索条件区分 jyokbn { get; set; }    //条件区分
        public int jyoseq { get; set; }                     //条件シーケンス
        public ItemVM? itemvm { get; set; }                 //通用項目
        public AgeVM? agevm { get; set; }                   //年齢範囲
        public BirthVM? birthvm { get; set; }               //生年月日範囲
        public List<string>? cdlist { get; set; }           //一覧選択
    }
    /// <summary>
    /// 年齢範囲
    /// </summary>
    public class AgeVM
    {
        public DateTime basedate { get; set; }   //年齢計算基準日
        public string? man { get; set; }         //男性
        public string? woman { get; set; }       //女性
        public string? both { get; set; }        //両方
        public string? unknown { get; set; }     //不明
    }
    /// <summary>
    /// 生年月日範囲
    /// </summary>
    public class BirthVM
    {
        public ItemVM? man { get; set; }         //男性
        public ItemVM? woman { get; set; }       //女性
        public ItemVM? both { get; set; }        //両方
        public ItemVM? unknown { get; set; }     //不明
    }
    /// <summary>
    /// 通用項目
    /// </summary>
    public class ItemVM
    {
        public string? value1 { get; set; }         //値(開始)
        public string? value2 { get; set; }         //値(終了)
        public bool yearflg { get; set; }           //年(不詳)
        public bool monthflg { get; set; }          //月(不詳)
        public bool dayflg { get; set; }            //日(不詳)
    }
}