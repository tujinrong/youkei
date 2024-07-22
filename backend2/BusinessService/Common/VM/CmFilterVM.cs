// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: システム共通(業務)
//             区分列挙型
// 作成日　　: 2024.07.12
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service;
public static class CmFilterVM
{
    /// <summary>
    /// 詳細条件(初期化)
    /// </summary>
    public class CommonFilterVM
    {
        public Enum詳細検索条件区分 jyokbn { get; set; }          //条件区分
        public int jyoseq { get; set; }                           //条件シーケンス
        public string hyojinm { get; set; }                       //詳細条件表示名
        public string placeholder { get; set; }                   //入力説明
        public Enumコントローラータイプ ctrltype { get; set; }    //コントローラータイプ
        public Enum項目区分? itemkbn { get; set; }                //通用項目区分
        public bool rangeflg { get; set; }                        //範囲フラグ
        public bool manflg { get; set; }                          //男性
        public bool womanflg { get; set; }                        //女性
        public bool bothflg { get; set; }                         //両方
        public bool unknownflg { get; set; }                      //不明
        public List<DaSelectorModel> cdlist { get; set; }         //一覧選択リスト
        public Enum参照ダイアログ項目区分? searchitemkbn { get; set; }  //参照ダイアログ項目区分
    }
}